Option Explicit On

Imports System.Data.SqlClient
Imports System.Math
Imports System.IO

Public Class frmRelaResp

    Dim dsAgil As New DataSet()

    Private Sub btnProcesar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProcesar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim cm4 As New SqlCommand()
        Dim cm5 As New SqlCommand()
        Dim daAnexos As New SqlDataAdapter(cm1)
        Dim daFactura As New SqlDataAdapter(cm2)
        Dim daProvinte As New SqlDataAdapter(cm3)
        Dim daGiros As New SqlDataAdapter(cm4)
        Dim daEdoctav As New SqlDataAdapter(cm5)
        Dim drGiros As DataRowCollection
        Dim drGiro As DataRow
        Dim drAnexo As DataRow
        Dim drFactura As DataRow
        Dim drEdoctav As DataRow
        Dim drProv As DataRow
        Dim drRepor As DataRow
        Dim drFinan As DataRow
        Dim drSuma As DataRow
        Dim drFacturas As DataRow()
        Dim drEstados As DataRow()
        Dim drProvinte As DataRowCollection
        Dim dtReporte As New DataTable("RelaResp")
        Dim dtTemporal As New DataTable("RepTexto")
        Dim dtRepFinal As New DataTable("Final")
        Dim dtFondeo As New DataTable("Fondeo")
        Dim dtSumas As New DataTable("Sumas")
        Dim relAnexoFacturas As DataRelation
        Dim relAnexoEdoctav As DataRelation
        Dim myColArray(6) As DataColumn
        Dim myColArray0(2) As DataColumn
        Dim myColArray1(2) As DataColumn
        Dim myColArray2(1) As DataColumn
        Dim myColArray3(2) As DataColumn
        Dim myColArray7(4) As DataColumn
        Dim myKeySearch(1) As String
        Dim myKeySearch1(1) As String
        Dim myKeySearch2(1) As String

        Dim cFecha As String
        Dim cAnexo As String
        Dim cCliente As String
        Dim cTipar As String
        Dim cTipeq As String
        Dim cFondeo As String
        Dim cCusnam As String
        Dim cBusca As String
        Dim cGiro As String
        Dim cDescg As String
        Dim cTipo As String
        Dim cPlaza As String
        Dim cRfc As String
        Dim cLocalidad As String
        Dim cDescGiro As String
        Dim cAuclave As String
        Dim cTipoArr As String
        Dim cSector As String
        Dim cRenglon As String
        Dim cGrupo As String
        Dim cDato1 As String
        Dim cCero As String
        Dim cFilename As String
        Dim lSdo As Boolean
        Dim nPlazo As Integer
        Dim nCounter As Integer
        Dim nDias As Integer
        Dim nMaxCounter As Integer = 100
        Dim Limite As Integer = 200
        Dim i As Integer
        Dim nSpread As Decimal
        Dim nSaldoVencido As Decimal
        Dim nSaldoInsoluto As Decimal
        Dim nCartera As Decimal
        Dim nExigible As Decimal
        Dim nProvision As Decimal
        Dim nSubTotal As Decimal
        Dim nEimp As Decimal
        Dim nEexi As Decimal
        Dim nSuma01 As Decimal = 0
        Dim nSuma02 As Decimal = 0
        Dim nSuma03 As Decimal = 0
        Dim nSuma04 As Decimal = 0
        Dim nSuma05 As Decimal = 0
        Dim oRelaResp As StreamWriter

        cFecha = DTOC(dtpFecha.Value)
        cFilename = Mid(cFecha, 3, 2) & Mid(cFecha, 5, 2) & "089R"

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Geneprov1"
            .Connection = cnAgil
            .Parameters.Add("@Fechafin", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        With cm2
            .CommandType = CommandType.StoredProcedure
            .CommandText = "CalcAnti1"
            .Connection = cnAgil
            .Parameters.Add("@Fecha", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        With cm3
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Provinte1"
            .Connection = cnAgil
        End With

        With cm4
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Giros1"
            .Connection = cnAgil
        End With

        With cm5
            .CommandType = CommandType.StoredProcedure
            .CommandText = "GeneProv2"
            .Connection = cnAgil
            .Parameters.Add("@Fechafin", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        ' Llenar el DataSet a través del DataAdapter, lo cual abre y cierra la conexión

        daAnexos.Fill(dsAgil, "Anexos")
        daFactura.Fill(dsAgil, "Facturas")
        daEdoctav.Fill(dsAgil, "Edoctav")
        daGiros.Fill(dsAgil, "Giros")
        myColArray2(0) = dsAgil.Tables("Giros").Columns("Giro")
        dsAgil.Tables("Giros").PrimaryKey = myColArray2

        daProvinte.Fill(dsAgil, "Provinte")
        myColArray0(0) = dsAgil.Tables("Provinte").Columns("Tipar")
        myColArray0(1) = dsAgil.Tables("Provinte").Columns("Anexo")
        dsAgil.Tables("Provinte").PrimaryKey = myColArray0

        drProvinte = dsAgil.Tables("Provinte").Rows
        drGiros = dsAgil.Tables("Giros").Rows

        ' Establecer la relación entre Anexos y Facturas

        relAnexoFacturas = New DataRelation("AnexoFacturas", dsAgil.Tables("Anexos").Columns("Anexo"), dsAgil.Tables("Facturas").Columns("Anexo"))
        dsAgil.EnforceConstraints = False
        dsAgil.Relations.Add(relAnexoFacturas)

        ' Establecer la relación entre Anexos y Facturas

        relAnexoEdoctav = New DataRelation("AnexoEdoctav", dsAgil.Tables("Anexos").Columns("Anexo"), dsAgil.Tables("Edoctav").Columns("Anexo"))
        dsAgil.EnforceConstraints = False
        dsAgil.Relations.Add(relAnexoEdoctav)

        ' Crear Tabla que nos registrara los datos de la relacion de responsabilidad

        dtReporte.Columns.Add("Grupo", Type.GetType("System.String"))
        dtReporte.Columns.Add("Giro", Type.GetType("System.String"))
        dtReporte.Columns.Add("Cusnam", Type.GetType("System.String"))
        dtReporte.Columns.Add("Anexo", Type.GetType("System.String"))
        dtReporte.Columns.Add("Plazo", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("DescGiro", Type.GetType("System.String"))
        dtReporte.Columns.Add("Importe", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("Exigible", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("Tipo", Type.GetType("System.String"))
        dtReporte.Columns.Add("RFC", Type.GetType("System.String"))
        dtReporte.Columns.Add("Auclave", Type.GetType("System.String"))
        dtReporte.Columns.Add("Tipar", Type.GetType("System.String"))
        dtReporte.Columns.Add("Localidad", Type.GetType("System.String"))
        dtReporte.Columns.Add("Sector", Type.GetType("System.String"))
        dtReporte.Columns.Add("Arrend", Type.GetType("System.String"))
        dtReporte.Columns.Add("Fondeo", Type.GetType("System.String"))
        dtReporte.Columns.Add("Ordena", Type.GetType("System.String"))
        myColArray(0) = dtReporte.Columns("Grupo")
        myColArray(1) = dtReporte.Columns("Giro")
        myColArray(2) = dtReporte.Columns("Cusnam")
        myColArray(3) = dtReporte.Columns("Anexo")
        myColArray(4) = dtReporte.Columns("Importe")
        myColArray(5) = dtReporte.Columns("DescGiro")
        dtReporte.PrimaryKey = myColArray

        'Tabla en la que se guardará la información para el reporte que se
        'va a un archivo de texto

        dtTemporal.Columns.Add("Dato1", Type.GetType("System.String"))
        dtTemporal.Columns.Add("Sector", Type.GetType("System.String"))
        dtTemporal.Columns.Add("RFC", Type.GetType("System.String"))
        dtTemporal.Columns.Add("Cusnam", Type.GetType("System.String"))
        dtTemporal.Columns.Add("Cero", Type.GetType("System.Decimal"))
        dtTemporal.Columns.Add("Localidad", Type.GetType("System.String"))
        dtTemporal.Columns.Add("Auclave", Type.GetType("System.String"))
        dtTemporal.Columns.Add("Dato2", Type.GetType("System.String"))
        dtTemporal.Columns.Add("Cartera", Type.GetType("System.Decimal"))
        dtTemporal.Columns.Add("Exigible", Type.GetType("System.Decimal"))
        dtTemporal.Columns.Add("Cero1", Type.GetType("System.Decimal"))
        dtTemporal.Columns.Add("CaryExi", Type.GetType("System.Decimal"))
        dtTemporal.Columns.Add("Mes", Type.GetType("System.String"))
        dtTemporal.Columns.Add("Año", Type.GetType("System.String"))
        dtTemporal.Columns.Add("Tipar", Type.GetType("System.String"))
        dtTemporal.Columns.Add("Provision", Type.GetType("System.Decimal"))
      
        ' Crear Tabla que nos registrara los datos finales de la relacion de responsabilidad

        dtRepFinal.Columns.Add("Cusnam", Type.GetType("System.String"))
        dtRepFinal.Columns.Add("Anexo", Type.GetType("System.String"))
        dtRepFinal.Columns.Add("Plazo", Type.GetType("System.Decimal"))
        dtRepFinal.Columns.Add("Importe", Type.GetType("System.Decimal"))
        dtRepFinal.Columns.Add("Exigible", Type.GetType("System.Decimal"))
        dtRepFinal.Columns.Add("Cero", Type.GetType("System.Decimal"))
        dtRepFinal.Columns.Add("Suma", Type.GetType("System.Decimal"))
        dtRepFinal.Columns.Add("Sector", Type.GetType("System.String"))
        dtRepFinal.Columns.Add("RFC", Type.GetType("System.String"))
        dtRepFinal.Columns.Add("DescGiro", Type.GetType("System.String"))
        dtRepFinal.Columns.Add("Auclave", Type.GetType("System.String"))
        dtRepFinal.Columns.Add("Tipar", Type.GetType("System.String"))
        dtRepFinal.Columns.Add("Localidad", Type.GetType("System.String"))
        dtRepFinal.Columns.Add("Grupo", Type.GetType("System.String"))
        dtRepFinal.Columns.Add("Ordena", Type.GetType("System.Decimal"))

        ' Tablas auxiliares

        dtFondeo.Columns.Add("Arrend", Type.GetType("System.String"))
        dtFondeo.Columns.Add("Fondeo", Type.GetType("System.String"))
        dtFondeo.Columns.Add("Giro", Type.GetType("System.String"))
        dtFondeo.Columns.Add("DescrGiro", Type.GetType("System.String"))
        dtFondeo.Columns.Add("SubTotal", Type.GetType("System.Decimal"))
        myColArray3(0) = dtFondeo.Columns("Fondeo")
        myColArray3(1) = dtFondeo.Columns("Giro")
        dtFondeo.PrimaryKey = myColArray3

        ' Tabla se Sumatorias

        dtSumas.Columns.Add("Suma01", Type.GetType("System.Decimal"))
        dtSumas.Columns.Add("Suma02", Type.GetType("System.Decimal"))
        dtSumas.Columns.Add("Suma03", Type.GetType("System.Decimal"))
        dtSumas.Columns.Add("Suma04", Type.GetType("System.Decimal"))
        dtSumas.Columns.Add("Suma05", Type.GetType("System.Decimal"))

        For Each drAnexo In dsAgil.Tables("Anexos").Rows
            cAnexo = drAnexo("Anexo")

            drFacturas = drAnexo.GetChildRows("AnexoFacturas")
            CalcAnti(cAnexo, cFecha, nMaxCounter, nCounter, drFacturas)

            cAnexo = drAnexo("Anexo")
            cCliente = drAnexo("Cliente")
            cTipar = drAnexo("Tipar")
            cFondeo = drAnexo("Fondeo")
            cTipeq = drAnexo("Tipeq")
            cCusnam = drAnexo("Descr")
            cGiro = drAnexo("Giro")
            cTipo = drAnexo("Tipo")
            cPlaza = drAnexo("Plaza")

            nPlazo = drAnexo("Plazo")
            nSpread = drAnexo("Difer")
            nSaldoVencido = 0
            nCartera = 0
            nExigible = 0
            nProvision = 0

            Select Case cPlaza
                Case Is = "01"
                    cLocalidad = "0100009"
                Case Is = "02"
                    cLocalidad = "0200009"
                Case Is = "03"
                    cLocalidad = "0300009"
                Case Is = "04"
                    cLocalidad = "0400009"
                Case Is = "05"
                    cLocalidad = "0700009"
                Case Is = "06"
                    cLocalidad = "0900009"
                Case Is = "07"
                    cLocalidad = "0500009"
                Case Is = "08"
                    cLocalidad = "0600009"
                Case Is = "09"
                    cLocalidad = "1001002"
                Case Is = "10"
                    cLocalidad = "1100008"
                Case Is = "11"
                    cLocalidad = "1800009"
                Case Is = "12"
                    cLocalidad = "1200003"
                Case Is = "13"
                    cLocalidad = "1300007"
                Case Is = "14"
                    cLocalidad = "1400002"
                Case Is = "15"
                    cLocalidad = "1500006"
                Case Is = "16"
                    cLocalidad = "1900004"
                Case Is = "17"
                    cLocalidad = "2100006"
                Case Is = "18"
                    cLocalidad = "2200005"
                Case Is = "19"
                    cLocalidad = "2300004"
                Case Is = "20"
                    cLocalidad = "2400003"
                Case Is = "21"
                    cLocalidad = "3000009"
                Case Is = "22"
                    cLocalidad = "3300009"
                Case Is = "23"
                    cLocalidad = "3400003"
                Case Is = "24"
                    cLocalidad = "3500006"
                Case Is = "25"
                    cLocalidad = "3600009"
                Case Is = "26"
                    cLocalidad = "3700003"
                Case Is = "27"
                    cLocalidad = "3800006"
                Case Is = "28"
                    cLocalidad = "3900009"
                Case Is = "29"
                    cLocalidad = "4000001"
                Case Is = "30"
                    cLocalidad = "4100008"
                Case Is = "31"
                    cLocalidad = "4400002"
                Case Is = "32"
                    cLocalidad = "4600007"
            End Select

            If cTipo = "F" Or cTipo = "E" Then
                cRfc = drAnexo("RFC")
            ElseIf cTipo = "M" Then
                cRfc = "0" & Mid(drAnexo("RFC"), 1, 12)
            End If

            drEstados = drAnexo.GetChildRows("AnexoEdoctav")

            'Cálculo de la Cartera de Arrendamiento Financiero

            lSdo = False
            For Each drEdoctav In drEstados
                If (drEdoctav("Feven") >= cFecha And drEdoctav("Nufac") <> 9999999) Or drEdoctav("Nufac") = 0 Then
                    If lSdo = False Then
                        nSaldoInsoluto = Round(drEdoctav("Saldo") / 1000, 0)
                        lSdo = True
                    End If
                    If drEdoctav("Nufac") <> 9999999 Then
                        nSaldoVencido += drEdoctav("Abcap")
                        nCartera += drEdoctav("Abcap") + drEdoctav("Inter")
                    End If
                End If
            Next

            'Cálculo de la cartera exigible ( la cual se considera como cartera )

            For Each drFactura In drFacturas
                nDias = DateDiff(DateInterval.Day, CTOD(drFactura("Feven")), CTOD(cFecha))
                nExigible += IIf(nDias > 0, drFactura("SaldoFac"), 0)
            Next

            'Cálculo la rentas devengadas parcialmente

            If cFondeo = "01" Then
                myKeySearch(0) = cTipar
                myKeySearch(1) = cAnexo
            Else
                myKeySearch(0) = "E"
                myKeySearch(1) = cAnexo
            End If
            drProv = drProvinte.Find(myKeySearch)

            If Not (drProv) Is Nothing Then
                nProvision = drProv("Importe")
            End If

            nSaldoVencido = Round(nSaldoVencido / 1000, 0)   'Capital Vencido
            nCartera = Round(nCartera / 1000, 0)
            nExigible = Round(nExigible / 1000, 0)
            nProvision = Round(nProvision / 1000, 0)

            If nCounter > nMaxCounter Then
                nSubTotal = Round(nSaldoVencido + nExigible + nProvision, 0)
            ElseIf cTipar = "F" Then
                nSubTotal = Round(nCartera + nExigible + nProvision, 0)
            ElseIf cTipar = "P" Then
                nSubTotal = Round(nSaldoInsoluto + nExigible + nProvision, 0)
            End If
            nSubTotal = Int(nSubTotal)

            'Trae la descripción del Giro

            drGiro = drGiros.Find(cGiro)

            If drGiro Is Nothing Then
                cDescGiro = "* ERROR ACTIVIDAD *"
                If nSubTotal <= Limite Then
                    cRfc = "* ERROR RFC *"
                End If
                cAuclave = "*******"
            Else
                cDescGiro = drGiro("DescGiro")
                If nSubTotal <= Limite Then
                    cRfc = drGiro("Rfc")
                End If
                cAuclave = drGiro("Auclave")
            End If

            If nSubTotal <= Limite Then
                If cTipar = "F" Then
                    cTipoArr = "66"
                ElseIf cTipar = "P" Then
                    cTipoArr = "80"
                End If
            ElseIf cTipar = "F" Then
                If cLocalidad = "" Then
                    MsgBox("Falta localidad del Anexo " & Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 6, 4), MsgBoxStyle.Information, "Mensaje")
                End If
                Select Case cTipeq
                    Case "1"
                        cTipoArr = "60"
                    Case "2"
                        cTipoArr = "61"
                    Case "3"
                        cTipoArr = "62"
                    Case "4"
                        cTipoArr = "63"
                    Case "5"
                        cTipoArr = "64"
                    Case "6"
                        cTipoArr = "65"
                    Case "9"
                        cTipoArr = "66"
                End Select
            ElseIf cTipar = "P" Then
                If cLocalidad = "" Then
                    MsgBox("Falta localidad del Anexo " & Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 6, 4), MsgBoxStyle.Information, "Mensaje")
                End If
                Select Case cTipeq
                    Case "1"
                        cTipoArr = "74"
                    Case "2"
                        cTipoArr = "75"
                    Case "3"
                        cTipoArr = "76"
                    Case "4"
                        cTipoArr = "77"
                    Case "5"
                        cTipoArr = "78"
                    Case "6"
                        cTipoArr = "79"
                    Case "9"
                        cTipoArr = "80"
                End Select
            End If

            If nSubTotal > 0 Then
                If cTipo = "F" Or cTipo = "E" Then
                    cSector = "32"
                ElseIf cTipo = "M" Then
                    cSector = "31"
                End If

                For i = 1 To 2
                    drRepor = dtReporte.NewRow()
                    drRepor("Importe") = 0
                    drRepor("Exigible") = 0
                    If i = 1 Then
                        Select Case cTipar
                            Case "F"
                                If nSubTotal <= Limite Then
                                    cGrupo = IIf(cFondeo = "01", "1", "5")

                                    If nCounter > nMaxCounter Then
                                        drRepor("Importe") = 0
                                        drRepor("Exigible") = nSaldoVencido + nExigible
                                    ElseIf nCartera + nExigible > 0 Then
                                        drRepor("Importe") = nCartera + nExigible
                                        drRepor("Exigible") = 0
                                    End If
                                    drRepor("Tipar") = IIf(cFondeo = "01", cTipoArr, "89")
                                    drRepor("Localidad") = "1808002"
                                    drRepor("Sector") = "32"
                                ElseIf nSubTotal > Limite Then
                                    cGrupo = IIf(cFondeo = "01", "2", "6")

                                    If nCounter > nMaxCounter Then
                                        drRepor("Importe") = 0
                                        drRepor("Exigible") = nSaldoVencido + nExigible
                                    ElseIf nCartera + nExigible > 0 Then
                                        drRepor("Importe") = nCartera + nExigible
                                        drRepor("Exigible") = 0
                                    End If
                                    drRepor("Tipar") = IIf(cFondeo = "01", cTipoArr, "89")
                                    drRepor("Localidad") = cLocalidad
                                    drRepor("Sector") = cSector

                                End If
                            Case "P"
                                If nSubTotal <= Limite Then
                                    cGrupo = "3"

                                    If nCounter > nMaxCounter Then
                                        drRepor("Importe") = 0
                                        drRepor("Exigible") = nSaldoVencido + nExigible
                                    ElseIf nCartera + nExigible > 0 Then
                                        drRepor("Importe") = nSaldoInsoluto + nExigible
                                        drRepor("Exigible") = 0
                                    End If
                                    drRepor("Tipar") = IIf(cFondeo = "01", cTipoArr, "89")
                                    drRepor("Localidad") = "1808002"
                                    drRepor("Sector") = "32"
                                ElseIf nSubTotal > Limite Then
                                    cGrupo = "4"

                                    If nCounter > nMaxCounter Then
                                        drRepor("Importe") = 0
                                        drRepor("Exigible") = nSaldoVencido + nExigible
                                    ElseIf nCartera + nExigible > 0 Then
                                        drRepor("Importe") = nSaldoInsoluto + nExigible
                                        drRepor("Exigible") = 0
                                    End If
                                    drRepor("Tipar") = IIf(cFondeo = "01", cTipoArr, "89")
                                    drRepor("Localidad") = cLocalidad
                                    drRepor("Sector") = cSector
                                End If
                        End Select
                        drRepor("Grupo") = cGrupo
                        drRepor("Anexo") = cAnexo
                        drRepor("Cusnam") = cCusnam
                        drRepor("Plazo") = nPlazo
                        drRepor("Giro") = cGiro
                        drRepor("Tipo") = cTipo
                        drRepor("DescGiro") = cDescGiro
                        drRepor("RFC") = cRfc
                        drRepor("Auclave") = cAuclave
                        drRepor("Arrend") = drAnexo("Tipar")
                        drRepor("Fondeo") = drAnexo("Fondeo")
                        drRepor("Ordena") = cGrupo & cGiro & cCusnam & cAnexo
                        dtReporte.Rows.Add(drRepor)
                    ElseIf i = 2 And nProvision > 0 Then
                        Select Case cTipar
                            Case "F"
                                If nSubTotal <= Limite Then
                                    cGrupo = IIf(cFondeo = "01", "1", "5")
                                    If nProvision > 0 Then
                                        drRepor("Importe") = nProvision
                                        drRepor("Exigible") = 0
                                        drRepor("Tipar") = "83"
                                    End If
                                    drRepor("Localidad") = "1808002"
                                    drRepor("Sector") = "32"
                                ElseIf nSubTotal > Limite Then
                                    cGrupo = IIf(cFondeo = "01", "2", "6")
                                    If nProvision > 0 Then
                                        drRepor("Importe") = nProvision
                                        drRepor("Exigible") = 0
                                        drRepor("Tipar") = "83"
                                    End If
                                    drRepor("Localidad") = cLocalidad
                                    drRepor("Sector") = cSector
                                End If
                            Case "P"
                                If nSubTotal <= Limite Then
                                    cGrupo = "3"
                                    If nProvision > 0 Then
                                        drRepor("Importe") = nProvision
                                        drRepor("Exigible") = 0
                                        drRepor("Tipar") = "83"
                                    End If
                                    drRepor("Localidad") = "18080002"
                                    drRepor("Sector") = "32"
                                ElseIf nSubTotal > Limite Then
                                    cGrupo = "4"
                                    If nProvision > 0 Then
                                        drRepor("Importe") = nProvision
                                        drRepor("Exigible") = 0
                                        drRepor("Tipar") = "83"
                                    End If
                                    drRepor("Localidad") = cLocalidad
                                    drRepor("Sector") = cSector
                                End If
                        End Select
                        drRepor("Grupo") = cGrupo
                        drRepor("Anexo") = cAnexo
                        drRepor("Cusnam") = cCusnam
                        drRepor("Plazo") = nPlazo
                        drRepor("Giro") = cGiro
                        drRepor("Tipo") = cTipo
                        drRepor("DescGiro") = cDescGiro
                        drRepor("RFC") = cRfc
                        drRepor("Auclave") = cAuclave
                        drRepor("Arrend") = drAnexo("Tipar")
                        drRepor("Fondeo") = drAnexo("Fondeo")
                        drRepor("Ordena") = cGrupo & cGiro & cCusnam & cAnexo
                        dtReporte.Rows.Add(drRepor)
                    End If
                Next

                If cTipar = "F" Then
                    myKeySearch2(0) = cFondeo
                    myKeySearch2(1) = cGiro
                Else
                    myKeySearch2(0) = "05"
                    myKeySearch2(1) = cGiro
                End If

                If cTipar = "F" Then

                    drFinan = dtFondeo.Rows.Find(myKeySearch2)

                    If drFinan Is Nothing Then
                        drFinan = dtFondeo.NewRow()
                        drFinan("Arrend") = drAnexo("Tipar")
                        drFinan("Fondeo") = cFondeo
                        drFinan("Giro") = cGiro
                        drFinan("DescrGiro") = cDescGiro
                        drFinan("SubTotal") = nSubTotal
                        If cFondeo = "01" And nSuma01 = 0 Then
                            nSuma01 = nSubTotal
                        ElseIf cFondeo = "01" And nSuma01 > 0 Then
                            nSuma01 += nSubTotal
                        End If
                        If cFondeo = "02" And nSuma02 = 0 Then
                            nSuma02 = nSubTotal
                        ElseIf cFondeo = "02" And nSuma02 > 0 Then
                            nSuma02 += nSubTotal
                        End If
                        If cFondeo = "03" And nSuma03 = 0 Then
                            nSuma03 = nSubTotal
                        ElseIf cFondeo = "03" And nSuma03 > 0 Then
                            nSuma03 += nSubTotal
                        End If
                        If cFondeo = "04" And nSuma04 = 0 Then
                            nSuma04 = nSubTotal
                        ElseIf cFondeo = "04" And nSuma04 > 0 Then
                            nSuma04 += nSubTotal
                        End If
                        dtFondeo.Rows.Add(drFinan)
                    Else
                        drFinan("SubTotal") += nSubTotal
                        If cFondeo = "01" Then
                            nSuma01 += nSubTotal
                        ElseIf cFondeo = "02" Then
                            nSuma02 += nSubTotal
                        ElseIf cFondeo = "03" Then
                            nSuma03 += nSubTotal
                        ElseIf cFondeo = "04" Then
                            nSuma04 += nSubTotal
                        End If
                    End If

                ElseIf cTipar = "P" Then

                    drFinan = dtFondeo.Rows.Find(myKeySearch2)
                    If drFinan Is Nothing Then
                        drFinan = dtFondeo.NewRow()
                        drFinan("Arrend") = drAnexo("Tipar")
                        drFinan("Fondeo") = "05"
                        drFinan("Giro") = cGiro
                        drFinan("DescrGiro") = cDescGiro
                        drFinan("SubTotal") = nSubTotal
                        dtFondeo.Rows.Add(drFinan)
                        If nSuma05 = 0 Then
                            nSuma05 = nSubTotal
                        End If
                    Else
                        drFinan("SubTotal") += nSubTotal
                        nSuma05 += nSubTotal
                    End If

                End If
            End If
        Next

        drSuma = dtSumas.NewRow()
        drSuma("Suma01") = nSuma01
        drSuma("Suma02") = nSuma02
        drSuma("Suma03") = nSuma03
        drSuma("Suma04") = nSuma04
        drSuma("Suma05") = nSuma05
        dtSumas.Rows.Add(drSuma)

        nCounter = dtReporte.Rows.Count

        DataGridView1.DataSource = dtReporte
        DataGridView1.Sort(DataGridView1.Columns(16), System.ComponentModel.ListSortDirection.Ascending)
       
        lSdo = True
        nCartera = 0
        nProvision = 0
        nExigible = 0
        i = 0
        For Each row As DataGridViewRow In DataGridView1.Rows
            If i = 0 Then
                cDescg = row.Cells("DescGiro").Value
                i = 1
            End If

            If cDescg <> row.Cells("DescGiro").Value Then
                drGiro = dtTemporal.NewRow()
                drGiro("Dato1") = cDato1
                drGiro("Sector") = cSector
                drGiro("RFC") = cRfc
                drGiro("Cusnam") = cCusnam
                drGiro("Cero") = 0
                drGiro("Localidad") = cLocalidad
                drGiro("Auclave") = cAuclave
                drGiro("Dato2") = cTipar
                drGiro("Cartera") = nCartera
                drGiro("Exigible") = nExigible
                drGiro("Cero1") = 0
                drGiro("CaryExi") = nCartera + nExigible
                drGiro("Mes") = Mid(cFecha, 5, 2)
                drGiro("Año") = Mid(cFecha, 1, 4) & Space(1)
                drGiro("Tipar") = cTipar
                drGiro("Provision") = nProvision
                dtTemporal.Rows.Add(drGiro)
                nCartera = 0
                nProvision = 0
                nExigible = 0
                i += 1

                If row.Cells("Plazo").Value > 0 Then
                    drRepor = dtRepFinal.NewRow()
                    drRepor("Cusnam") = row.Cells("Cusnam").Value
                    drRepor("Anexo") = row.Cells("Anexo").Value
                    drRepor("Plazo") = row.Cells("Plazo").Value
                    drRepor("Importe") = row.Cells("Importe").Value
                    drRepor("Exigible") = row.Cells("Exigible").Value
                    drRepor("Cero") = 0
                    drRepor("Suma") = row.Cells("Importe").Value + row.Cells("Exigible").Value
                    drRepor("Sector") = row.Cells("Sector").Value
                    drRepor("RFC") = row.Cells("RFC").Value
                    drRepor("DescGiro") = row.Cells("DescGiro").Value
                    drRepor("Auclave") = row.Cells("Auclave").Value
                    drRepor("Tipar") = row.Cells("Tipar").Value
                    drRepor("Localidad") = row.Cells("Localidad").Value
                    drRepor("Grupo") = row.Cells("Arrend").Value & row.Cells("Fondeo").Value
                    drRepor("Ordena") = i
                    dtRepFinal.Rows.Add(drRepor)
                End If
                
            Else
                cCusnam = row.Cells("Cusnam").Value
                cSector = row.Cells("Sector").Value
                cLocalidad = row.Cells("Localidad").Value
                cRfc = row.Cells("RFC").Value
                cAuclave = row.Cells("Auclave").Value
                cTipar = row.Cells("Tipar").Value
                cGrupo = row.Cells("Grupo").Value
                cDato1 = "08901808002"
                cCero = Stuff(0, "I", " ", 11)
                If cGrupo = "1" Or cGrupo = "3" Or cGrupo = "5" Then
                    If cTipar = "83" Then
                        nProvision += row.Cells("Importe").Value
                    Else
                        nCartera += row.Cells("Importe").Value
                        nExigible += row.Cells("Exigible").Value
                    End If

                    cCusnam = Stuff(row.Cells("DescGiro").Value, "D", " ", 55)

                    Select Case cGrupo
                        Case "1", "5"
                            cTipar = "66"
                        Case "3"
                            cTipar = "80"
                    End Select

                Else
                    nCartera = row.Cells("Importe").Value
                    nExigible = row.Cells("Exigible").Value

                    drGiro = dtTemporal.NewRow()
                    drGiro("Dato1") = cDato1
                    drGiro("Sector") = cSector
                    drGiro("RFC") = cRfc
                    drGiro("Cusnam") = cCusnam
                    drGiro("Cero") = 0
                    drGiro("Localidad") = cLocalidad
                    drGiro("Auclave") = cAuclave
                    drGiro("Dato2") = cTipar
                    drGiro("Cartera") = nCartera
                    drGiro("Exigible") = nExigible
                    drGiro("Cero1") = 0
                    drGiro("CaryExi") = nCartera + nExigible
                    drGiro("Mes") = Mid(cFecha, 5, 2)
                    drGiro("Año") = Mid(cFecha, 1, 4) & Space(1)
                    drGiro("Tipar") = cTipar
                    drGiro("Provision") = nProvision
                    dtTemporal.Rows.Add(drGiro)
                    nCartera = 0
                    nProvision = 0
                    nExigible = 0
                End If

                drRepor = dtRepFinal.NewRow()
                drRepor("Cusnam") = row.Cells("Cusnam").Value
                drRepor("Anexo") = row.Cells("Anexo").Value
                drRepor("Plazo") = row.Cells("Plazo").Value
                drRepor("Importe") = row.Cells("Importe").Value
                drRepor("Exigible") = row.Cells("Exigible").Value
                drRepor("Cero") = 0
                drRepor("Suma") = row.Cells("Importe").Value + row.Cells("Exigible").Value
                drRepor("Sector") = row.Cells("Sector").Value
                drRepor("RFC") = row.Cells("RFC").Value
                drRepor("DescGiro") = row.Cells("DescGiro").Value
                drRepor("Auclave") = row.Cells("Auclave").Value
                drRepor("Tipar") = row.Cells("Tipar").Value
                drRepor("Localidad") = row.Cells("Localidad").Value
                drRepor("Grupo") = row.Cells("Arrend").Value & row.Cells("Fondeo").Value
                drRepor("Ordena") = i
                dtRepFinal.Rows.Add(drRepor)

            End If

            cDescg = row.Cells("DescGiro").Value

        Next

        nProvision = dtTemporal.Rows.Count

        lSdo = False
        For Each drRepor In dtTemporal.Rows
            If drRepor("CaryExi") > 0 Then
                cRenglon = drRepor("Dato1") & drRepor("Sector") & Mid(drRepor("RFC"), 1, 13) & _
                           Mid(drRepor("Cusnam"), 1, 55) & drRepor("Cero") & drRepor("Localidad") & _
                           drRepor("Auclave") & drRepor("Dato2") & Stuff(drRepor("Cartera"), "I", " ", 11) & _
                           Stuff(drRepor("Exigible"), "I", " ", 11) & Stuff(drRepor("Cero1"), "I", " ", 11) & _
                           Stuff(drRepor("CaryExi"), "I", " ", 11) & drRepor("Mes") & drRepor("Año")

                If lSdo = True Then
                    oRelaResp.WriteLine(cRenglon)
                Else
                    oRelaResp = New StreamWriter("C:\" & cFilename & ".txt")
                    oRelaResp.WriteLine(cRenglon)
                    lSdo = True
                End If

                If drRepor("Provision") > 0 Then
                    cRenglon = drRepor("Dato1") & drRepor("Sector") & Mid(drRepor("RFC"), 1, 13) & _
                                Mid(drRepor("Cusnam"), 1, 55) & drRepor("Cero") & drRepor("Localidad") & _
                                drRepor("Auclave") & "83" & Stuff(drRepor("Provision"), "I", " ", 11) & _
                                Stuff(cCero, "I", " ", 11) & Stuff(drRepor("Cero1"), "I", " ", 11) & Stuff(drRepor("Provision"), "I", " ", 11) & _
                                drRepor("Mes") & drRepor("Año")
                    oRelaResp.WriteLine(cRenglon)
                End If
            End If
        Next
        oRelaResp.Close()

        dsAgil.Relations.Clear()
        dsAgil.Tables("Anexos").Constraints.Clear()
        dsAgil.Tables("Facturas").Constraints.Clear()
        dsAgil.Tables("Edoctav").Constraints.Clear()
        dsAgil.Tables.Remove("Anexos")
        dsAgil.Tables.Remove("Facturas")
        dsAgil.Tables.Remove("Edoctav")
        dsAgil.Tables.Remove("Giros")
        dsAgil.Tables.Remove("Provinte")
        dsAgil.Tables.Add(dtRepFinal)
        dsAgil.Tables.Add(dtFondeo)
        dsAgil.Tables.Add(dtSumas)

        ' Descomentar esta linea cuando se desee modificar rptRelaResp
        dsAgil.WriteXml("C:\Schema42.xml", XmlWriteMode.WriteSchema)

        btnProcesar.Enabled = False
        btnResumen.Enabled = True
        btnDetalle.Enabled = True
        MsgBox("Ya puedes Consultar Información del Resumen o Desglose de Datos", MsgBoxStyle.OkCancel, "Mensaje")

        cnAgil.Dispose()

    End Sub

    Private Sub btnResumen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnResumen.Click
        Dim newrptRelaResp As New rptRelaResp()
        Dim cReportTitle As String

        cReportTitle = "RESUMEN POR TIPO DE ARRENDAMIENTO Y POR ACTIVIDADES AL " & Mes(DTOC(dtpFecha.Value))
        newrptRelaResp.SetDataSource(dsAgil)
        newrptRelaResp.SummaryInfo.ReportTitle = cReportTitle
        CrystalReportViewer1.ReportSource = newrptRelaResp
        CrystalReportViewer1.Visible = True

    End Sub

    Private Sub btnDetalle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetalle.Click
        Dim newrptRelaResp2 As New rptRelaResp2()
        Dim cReportTitle As String

        cReportTitle = "REPORTE BANCO DE MEXICO Y NAFIN.- RELACION DE RESPONSABILIDADES AL " & Mes(DTOC(dtpFecha.Value))
        newrptRelaResp2.SetDataSource(dsAgil)
        newrptRelaResp2.SummaryInfo.ReportTitle = cReportTitle
        CrystalReportViewer1.ReportSource = newrptRelaResp2
        CrystalReportViewer1.Visible = True

    End Sub

End Class