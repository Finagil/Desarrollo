Option Explicit On
Imports System.IO
Imports System.Data.SqlClient

Public Class frmProyecta

    ' Declaración de variables de conexión ADO .NET de alcance privado

    Dim dtReporte1 As New DataTable("Reporte1")
    Dim dtVenAn As New DataTable("VenAn")
    Dim dtVenAv As New DataTable("VenAv")
    Dim dtReporteAcum As New DataTable("ReporteAcum")
    Dim f1 As New StreamWriter("c:\Files\Detalle" & Date.Now.ToString("yyyyMMdd-hhmm") & ".txt")
    Dim f2 As New StreamWriter("c:\Files\DetalleTot" & Date.Now.ToString("yyyyMMdd-hhmm") & ".txt")
    ' Declaración de variables de datos de alcance privado

    Dim cFecha As String
    Dim cFechaInt As String
    Dim cFechaCortoPalzo As String
    Dim cYear As String
    Dim Total As Double

    Private Sub frmProyecta_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        f1.Close()
        f2.Close()
    End Sub

    Private Sub frmProyecta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        rbCapital.Checked = True
        rbTotalCartera.Checked = True
        rbPRNo.Checked = True
        f1.WriteLine("Contrato" & vbTab & "Cliente" & vbTab & "Tipar" & vbTab & "Monto" & vbTab & "Año" & vbTab & "Mes")
        f2.WriteLine("Contrato" & vbTab & "Cliente" & vbTab & "Tipar" & vbTab & "Monto" & vbTab & "Interes" & vbTab & "Partes" & vbTab & "Origen" & vbTab & "Monto Corto" & vbTab & "Inte Corto" & vbTab & "Monto Largo" & vbTab & "Inte Largo")

    End Sub

    Private Sub btnProceso_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProceso.Click
        dtReporte1.Clear()
        dtReporteAcum.Clear()
        Total = 0
        

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim cmAv As New SqlCommand()
        Dim cmAn As New SqlCommand()

        Dim daAnexo As New SqlDataAdapter(cm1)
        Dim daEdoctav As New SqlDataAdapter(cm2)
        Dim daFacturas As New SqlDataAdapter(cm3)
        Dim daVencimientosAV As New SqlDataAdapter(cmAv)
        Dim daVencimientosAn As New SqlDataAdapter(cmAn)
        Dim drAnexo As DataRow
        Dim dsAgil As New DataSet()
        Dim relAnexoEdoctav As DataRelation
        Dim relAnexoFacturas As DataRelation
        Dim dvReporte1 As DataView
        Dim dvReporteX As DataView
        Dim myColArray(1) As DataColumn
        Dim myColArrayX(1) As DataColumn
        Dim myColArrayY(1) As DataColumn
        Dim myColArrayZ(1) As DataColumn

        ' Declaración de variables de 


        Dim cAnexo As String = ""
        Dim cTipta As String = ""
        Dim cCliente As String = ""
        Dim cTipar As String = ""
        Dim nTasa As Double

        cFecha = DTOC(DateTimePicker1.Value)
        cFechaCortoPalzo = DTOC(DateTimePicker1.Value.AddYears(1))
        DateTimePicker1.Value = DateTimePicker1.Value.AddDays(1)
        cFechaInt = DTOC(DateTimePicker1.Value)
        DateTimePicker1.Value = DateTimePicker1.Value.AddDays(-1)

        ' Primero creo la tabla Temporal que me permitirá acumular los saldos de los 
        ' contratos por cliente

        cYear = Mid(cFecha, 1, 4)


        If dtReporte1.Columns.Count() = 0 Then
            dtReporte1.Columns.Add("Mes", Type.GetType("System.String"))
            dtReporte1.Columns.Add(cYear, Type.GetType("System.Decimal"))
            dtReporte1.Columns.Add(CStr(Val(cYear) + 1), Type.GetType("System.Decimal"))
            dtReporte1.Columns.Add(CStr(Val(cYear) + 2), Type.GetType("System.Decimal"))
            dtReporte1.Columns.Add(CStr(Val(cYear) + 3), Type.GetType("System.Decimal"))
            dtReporte1.Columns.Add(CStr(Val(cYear) + 4), Type.GetType("System.Decimal"))
            dtReporte1.Columns.Add(CStr(Val(cYear) + 5), Type.GetType("System.Decimal"))
            dtReporte1.Columns.Add(CStr(Val(cYear) + 6), Type.GetType("System.Decimal"))
            dtReporte1.Columns.Add(CStr(Val(cYear) + 7), Type.GetType("System.Decimal"))
            dtReporte1.Columns.Add(CStr(Val(cYear) + 8), Type.GetType("System.Decimal"))
            dtReporte1.Columns.Add(CStr(Val(cYear) + 9), Type.GetType("System.Decimal"))
            dtReporte1.Columns.Add(CStr(Val(cYear) + 10), Type.GetType("System.Decimal"))
            myColArray(0) = dtReporte1.Columns("Mes")
            dtReporte1.PrimaryKey = myColArray

        End If

        If dtReporteAcum.Columns.Count() = 0 Then
            dtReporteAcum.Columns.Add("Mes", Type.GetType("System.String"))
            dtReporteAcum.Columns.Add("Mes0", Type.GetType("System.String"))
            dtReporteAcum.Columns.Add(cYear, Type.GetType("System.Decimal"))
            dtReporteAcum.Columns.Add(cYear & "Variable", Type.GetType("System.Decimal"))
            dtReporteAcum.Columns.Add(cYear & "Fija", Type.GetType("System.Decimal"))

            dtReporteAcum.Columns.Add(CStr(Val(cYear) + 1), Type.GetType("System.Decimal"))
            dtReporteAcum.Columns.Add(CStr(Val(cYear) + 1) & "Variable", Type.GetType("System.Decimal"))
            dtReporteAcum.Columns.Add(CStr(Val(cYear) + 1) & "Fija", Type.GetType("System.Decimal"))

            dtReporteAcum.Columns.Add(CStr(Val(cYear) + 2), Type.GetType("System.Decimal"))
            dtReporteAcum.Columns.Add(CStr(Val(cYear) + 2) & "Variable", Type.GetType("System.Decimal"))
            dtReporteAcum.Columns.Add(CStr(Val(cYear) + 2) & "Fija", Type.GetType("System.Decimal"))

            dtReporteAcum.Columns.Add(CStr(Val(cYear) + 3), Type.GetType("System.Decimal"))
            dtReporteAcum.Columns.Add(CStr(Val(cYear) + 3) & "Variable", Type.GetType("System.Decimal"))
            dtReporteAcum.Columns.Add(CStr(Val(cYear) + 3) & "Fija", Type.GetType("System.Decimal"))

            dtReporteAcum.Columns.Add(CStr(Val(cYear) + 4), Type.GetType("System.Decimal"))
            dtReporteAcum.Columns.Add(CStr(Val(cYear) + 4) & "Variable", Type.GetType("System.Decimal"))
            dtReporteAcum.Columns.Add(CStr(Val(cYear) + 4) & "Fija", Type.GetType("System.Decimal"))

            dtReporteAcum.Columns.Add(CStr(Val(cYear) + 5), Type.GetType("System.Decimal"))
            dtReporteAcum.Columns.Add(CStr(Val(cYear) + 5) & "Variable", Type.GetType("System.Decimal"))
            dtReporteAcum.Columns.Add(CStr(Val(cYear) + 5) & "Fija", Type.GetType("System.Decimal"))

            dtReporteAcum.Columns.Add(CStr(Val(cYear) + 6), Type.GetType("System.Decimal"))
            dtReporteAcum.Columns.Add(CStr(Val(cYear) + 6) & "Variable", Type.GetType("System.Decimal"))
            dtReporteAcum.Columns.Add(CStr(Val(cYear) + 6) & "Fija", Type.GetType("System.Decimal"))

            dtReporteAcum.Columns.Add(CStr(Val(cYear) + 7), Type.GetType("System.Decimal"))
            dtReporteAcum.Columns.Add(CStr(Val(cYear) + 7) & "Variable", Type.GetType("System.Decimal"))
            dtReporteAcum.Columns.Add(CStr(Val(cYear) + 7) & "Fija", Type.GetType("System.Decimal"))

            dtReporteAcum.Columns.Add(CStr(Val(cYear) + 8), Type.GetType("System.Decimal"))
            dtReporteAcum.Columns.Add(CStr(Val(cYear) + 8) & "Variable", Type.GetType("System.Decimal"))
            dtReporteAcum.Columns.Add(CStr(Val(cYear) + 8) & "Fija", Type.GetType("System.Decimal"))

            dtReporteAcum.Columns.Add(CStr(Val(cYear) + 9), Type.GetType("System.Decimal"))
            dtReporteAcum.Columns.Add(CStr(Val(cYear) + 9) & "Variable", Type.GetType("System.Decimal"))
            dtReporteAcum.Columns.Add(CStr(Val(cYear) + 9) & "Fija", Type.GetType("System.Decimal"))

            dtReporteAcum.Columns.Add(CStr(Val(cYear) + 10), Type.GetType("System.Decimal"))
            dtReporteAcum.Columns.Add(CStr(Val(cYear) + 10) & "Variable", Type.GetType("System.Decimal"))
            dtReporteAcum.Columns.Add(CStr(Val(cYear) + 10) & "Fija", Type.GetType("System.Decimal"))

            myColArrayX(0) = dtReporteAcum.Columns("Mes")
            dtReporteAcum.PrimaryKey = myColArrayX
        End If

        ' Con este Stored Procedure obtengo los contratos activos a la fecha solicitada

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "GeneProv11"
            .Connection = cnAgil
            .Parameters.Add("@Fechafin", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        ' Con este Store Procedure obtengo la tabla de amortización del equipo de todos los contratos activos a la fecha solicitada

        With cm2
            .CommandType = CommandType.StoredProcedure
            .CommandText = "GeneProv22"
            .Connection = cnAgil
            .Parameters.Add("@Fechafin", SqlDbType.NVarChar)
            .Parameters.Add("@FechaInt", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
            .Parameters(1).Value = cFechaInt
        End With

        ' Este Stored Procedure trae todas las facturas no pagadas de todos los contratos activos con fecha de
        ' contratación menor o igual a la de proceso

        With cm3
            .CommandType = CommandType.StoredProcedure
            .CommandText = "CalcAnti1"
            .Connection = cnAgil
            .Parameters.Add("@Fecha", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        With cmAn
            .CommandType = CommandType.Text
            .CommandText = "select * from Vw_XRepAntiGeneralCarteraVencida"
            .Connection = cnAgil
        End With

        With cmAv
            .CommandType = CommandType.Text
            .CommandText = "select *, anexo+ciclo as anexox from Vw_CarteraVencidaAvio"
            .Connection = cnAgil
        End With

        ' Llenar el DataSet a través del DataAdapter, lo cual abre y cierra la conexión

        daAnexo.Fill(dsAgil, "Anexos")
        daEdoctav.Fill(dsAgil, "Edoctav")
        daFacturas.Fill(dsAgil, "Facturas")

        daVencimientosAn.Fill(dtVenAn)
        daVencimientosAV.Fill(dtVenAv)

        myColArrayZ(0) = dtVenAn.Columns("Anexo")
        dtVenAn.PrimaryKey = myColArrayZ
        myColArrayY(0) = dtVenAv.Columns("anexox")
        dtVenAv.PrimaryKey = myColArrayY


        ' Establecer la relación entre Anexos y Edoctav

        relAnexoEdoctav = New DataRelation("AnexoEdoctav", dsAgil.Tables("Anexos").Columns("Anexo"), dsAgil.Tables("Edoctav").Columns("Anexo"))
        dsAgil.EnforceConstraints = False
        dsAgil.Relations.Add(relAnexoEdoctav)

        ' Establecer la relación entre Anexos y Facturas

        relAnexoFacturas = New DataRelation("AnexoFacturas", dsAgil.Tables("Anexos").Columns("Anexo"), dsAgil.Tables("Facturas").Columns("Anexo"))
        dsAgil.EnforceConstraints = False
        dsAgil.Relations.Add(relAnexoFacturas)

        For Each drAnexo In dsAgil.Tables("Anexos").Rows

            cAnexo = Trim(drAnexo("Anexo"))
            cTipar = drAnexo("Tipar")
            cTipta = drAnexo("Tipta")
            cCliente = drAnexo("Cliente")
            'nTasa = drAnexo("Tasas")

            'exclulle castigados por valentin
            If InStr("021360003|022640002|025960001|027070001|027290001|027790001|027800001|027870001|030200001|019820004|027650001|022840002|009130005|014280004|014400005|017040007|017940006|018450004|019010003|022670002|023230002|023490002|023750001|025060001|025330001|025420001|025950002|026850001|027060002|027300001|027300002|028020001|028560002|029360001'", cAnexo) <= 0 Then

                If rbTotalCartera.Checked = True Then
                    If cTipar <> "PP" Then
                        Proyecta(cCliente, cAnexo, drAnexo, cTipta, cTipar)

                    End If
                ElseIf rbArrendamiento.Checked = True Then
                    If cTipar = "F" Then
                        Proyecta(cCliente, cAnexo, drAnexo, cTipta, cTipar)
                    End If
                ElseIf rbRefaccionario.Checked = True Then
                    If cTipar = "R" Then
                        Proyecta(cCliente, cAnexo, drAnexo, cTipta, cTipar)
                    End If
                ElseIf rbSimple.Checked = True Then
                    'If cTipar = "S" And nTasa = 20 Then
                    If cTipar = "S" And drAnexo("Reestructura") <> "S" Then
                        'If cTipar = "S" And Trim(drAnexo("CNEmpresa")) <> "" And drAnexo("anexo") <> "32740002" And drAnexo("anexo") <> "32350001" And drAnexo("anexo") <> "28990002" And drAnexo("anexo") <> "34270001" And drAnexo("anexo") <> "20970004" Then
                        Proyecta(cCliente, cAnexo, drAnexo, cTipta, cTipar)
                    End If
                ElseIf RbOtros.Checked = True Then
                    If cTipar = "S" And drAnexo("Reestructura") = "S" Then
                        Proyecta(cCliente, cAnexo, drAnexo, cTipta, cTipar)
                    End If

                ElseIf RBPuro.Checked = True Then
                    If cTipar = "P" And cAnexo <> "006430080" And cAnexo <> "006430081" And cAnexo <> "006430082" Then
                        Proyecta(cCliente, cAnexo, drAnexo, cTipta, cTipar)
                    End If
                End If
            End If
        Next

        If RBcc.Checked = True Then
            sacaAVCC("C")
        End If
        If RBav.Checked = True Then
            sacaAVCC("H")
        End If
        If rbTotalCartera.Checked = True Then
            sacaAVCC("C")
            sacaAVCC("H")
        End If
        dvReporte1 = New DataView(dtReporte1)
        dvReporte1.Sort = "Mes"
        dvReporteX = New DataView(dtReporteAcum)
        dvReporteX.Sort = "Mes0"
        DataGridView1.DataSource = dvReporte1
        DataGridView2.DataSource = dvReporteX
        DataGridView1.Columns(1).ToolTipText = "Primer año de amortizaciones"

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()
        cm3.Dispose()
        Total = Total
        'MsgBox(Total.ToString("c"))


    End Sub

    Private Sub Proyecta(ByVal cCliente As String, ByVal cAnexo As String, ByVal drAnexo As DataRow, ByVal cTipta As String, ByVal cTipar As String)

        ' Declaración de variables de conexión ADO .NET
        

        Dim drEdocta As DataRow
        Dim drEstados As DataRow()
        Dim drFacturas As DataRow()
        Dim drTemp As DataRow
        Dim drTempX As DataRow

        ' Declaración de variables de datos

        Dim cMonth As String
        Dim cMonthX As String
        Dim cYearPayment As String
        Dim lConsiderar As Boolean = False
        Dim nCounter As Integer
        Dim nMaxCounter As Integer = 100
        Dim nMonto As Decimal
        Dim nMontoI As Decimal
        Dim cOrigen As String = ""
        Dim cCiclo As String = ""
        Dim cad As String = ""
        Dim CliNom As String = ""
        Dim nMontoC As Decimal
        Dim nMontoL As Decimal
        Dim nMontoIC As Decimal
        Dim nMontoIL As Decimal
        Dim cAnexoX As String = ""
        Dim cTiparX As String = ""

        ' 00006 MOLINOS DEL SUDESTE
        ' 00015 PELICULAS PLASTICAS
        ' 00044 PAPELES CORRUGADOS
        ' 00045 CONSTRUCTORA Y URBANIZADORA PEGASO
        ' 00061 OPISEC
        ' 00066 TABLEX
        ' 00353 COMERCIALIZADORA LA MODERNA DE TOLUCA
        ' 00426 FABRICA DE GALLETAS LA MODERNA
        ' 00454 VICTORIA EUGENIA SAINT MARTIN DE MONROY
        ' 00457 CIA. NACIONAL DE HARINAS
        ' 00606 LA MODERNA DE OCCIDENTE
        ' 00676 PRODUCTOS ALIMENTICIOS LA MODERNA
        ' 00719 ARTE DIGITAL DE MEXICO
        ' 00898 TABLEX MILLER
        ' 01054 MOLINOS DEL FENIX
        ' 01101 CONCRETOS Y ASFALTOS DE TOLUCA
        ' 01455 CORPORATIVO LA MODERNA
        ' 01521 IMPULSORA DE BIENES INMUEBLES DE TOLUCA
        ' 01591 DEL REY INN HOTEL
        ' 01666 PASTAS CORA
        ' 02488 QUINTA DEL REY HOTEL
        ' 03193 GRUPO LA MODERNA
        ' 03348 TRANSPORTES ESPECIALIZADOS ROBLES NAVARRO
        ' 03671 SERVICIOS ARFIN
        ' 03921 JOSE ANTONIO MONROY CARRILLO
        ' 05107 HARINERA LOS PIRINEOS SA DE CV
        ' 05317 MCLIGHT OPERADORA SA DE CV
        ' 05318 INMOBILIARIA MEXICANA TURISTICA SA DE CV
        ' 05321 HARINERA LOS PIRINEOS SA DE CV (SUCURSAL IRAPUATO)

        If rbPRSi.Checked = True Then

            ' Solo considera contratos de créditos con partes relacionadas

            If InStr("00006|00015|00044|00045|00061|00066|00353|00426|00454|00457|00606|00676|00719|00898|01054|01101|01455|01521|01591|01666|02488|03193|03348|03671|03921|05107|05214|05317|05318|05321", cCliente) > 0 Then
                lConsiderar = True
                cad = "Relacionados" & vbTab
            End If

        ElseIf rbPRNo.Checked = True Then
            cad = "No Relacionados" & vbTab
            ' Solo considera contratos de créditos que no sean con partes relacionadas
            Dim x As Integer = InStr("00006|00015|00044|00045|00061|00066|00353|00426|00454|00457|00606|00676|00719|00898|01054|01101|01455|01521|01591|01666|02488|03193|03348|03671|03921|05107|05214|05317|05318|05321", cCliente)
            If InStr("00006|00015|00044|00045|00061|00066|00353|00426|00454|00457|00606|00676|00719|00898|01054|01101|01455|01521|01591|01666|02488|03193|03348|03671|03921|05107|05214|05317|05318|05321", cCliente) = 0 Then
                lConsiderar = True
            End If
        End If

        If rbCapital.Checked = True Then
            cad = cad & "Capital"
        ElseIf rbInteres.Checked = True Then
            cad = cad & "Interes"
        End If


        nCounter = 0
        drFacturas = drAnexo.GetChildRows("AnexoFacturas")
        CalcAnti(cAnexo, cFecha, nMaxCounter, nCounter, drFacturas)

        If lConsiderar = True And nCounter <= nMaxCounter Then

            drEstados = drAnexo.GetChildRows("AnexoEdoctav")
            For Each drEdocta In drEstados
                cOrigen = drEdocta("origen")
                
                If drEdocta("Feven") > cFecha And drEdocta("Nufac") <> 9999999 And cOrigen = "Contratos" Then
                    CliNom = drEdocta("Descr")
                    cYearPayment = Mid(drEdocta("Feven"), 1, 4)
                    cMonth = Mid(drEdocta("Feven"), 5, 2)
                    cMonthX = MonthName(Val(Mid(drEdocta("Feven"), 5, 2)))
                    If rbCapital.Checked = True Then
                        nMonto = drEdocta("Abcap")
                    ElseIf rbInteres.Checked = True Then
                        nMonto = drEdocta("Inter")
                    End If


                    drTemp = dtReporte1.Rows.Find(cMonth)

                    f1.WriteLine(cAnexo & vbTab & CliNom & vbTab & cTipar & vbTab & nMonto & vbTab & cMonth & vbTab & cad & vbTab & cOrigen)
                    If drTemp Is Nothing Then

                        ' El mes no existe en la tabla

                        drTemp = dtReporte1.NewRow()
                        drTemp("Mes") = cMonth
                        drTemp(cYear) = IIf(cYearPayment = cYear, nMonto, 0)
                        drTemp(CStr(Val(cYear) + 1)) = IIf(cYearPayment = CStr(Val(cYear) + 1), nMonto, 0)
                        drTemp(CStr(Val(cYear) + 2)) = IIf(cYearPayment = CStr(Val(cYear) + 2), nMonto, 0)
                        drTemp(CStr(Val(cYear) + 3)) = IIf(cYearPayment = CStr(Val(cYear) + 3), nMonto, 0)
                        drTemp(CStr(Val(cYear) + 4)) = IIf(cYearPayment = CStr(Val(cYear) + 4), nMonto, 0)
                        drTemp(CStr(Val(cYear) + 5)) = IIf(cYearPayment = CStr(Val(cYear) + 5), nMonto, 0)
                        drTemp(CStr(Val(cYear) + 6)) = IIf(cYearPayment = CStr(Val(cYear) + 6), nMonto, 0)
                        drTemp(CStr(Val(cYear) + 7)) = IIf(cYearPayment = CStr(Val(cYear) + 7), nMonto, 0)
                        drTemp(CStr(Val(cYear) + 8)) = IIf(cYearPayment = CStr(Val(cYear) + 8), nMonto, 0)
                        drTemp(CStr(Val(cYear) + 9)) = IIf(cYearPayment = CStr(Val(cYear) + 8), nMonto, 0)
                        drTemp(CStr(Val(cYear) + 10)) = IIf(cYearPayment = CStr(Val(cYear) + 8), nMonto, 0)
                        dtReporte1.Rows.Add(drTemp)

                    Else

                        ' El mes ya existe en la tabla

                        Select Case cYearPayment
                            Case cYear
                                drTemp(cYear) += nMonto
                            Case CStr(Val(cYear) + 1)
                                drTemp(CStr(Val(cYear) + 1)) += nMonto
                            Case CStr(Val(cYear) + 2)
                                drTemp(CStr(Val(cYear) + 2)) += nMonto
                            Case CStr(Val(cYear) + 3)
                                drTemp(CStr(Val(cYear) + 3)) += nMonto
                            Case CStr(Val(cYear) + 4)
                                drTemp(CStr(Val(cYear) + 4)) += nMonto
                            Case CStr(Val(cYear) + 5)
                                drTemp(CStr(Val(cYear) + 5)) += nMonto
                            Case CStr(Val(cYear) + 6)
                                drTemp(CStr(Val(cYear) + 6)) += nMonto
                            Case CStr(Val(cYear) + 7)
                                drTemp(CStr(Val(cYear) + 7)) += nMonto
                            Case CStr(Val(cYear) + 8)
                                drTemp(CStr(Val(cYear) + 8)) += nMonto
                            Case CStr(Val(cYear) + 9)
                                drTemp(CStr(Val(cYear) + 9)) += nMonto
                            Case CStr(Val(cYear) + 10)
                                drTemp(CStr(Val(cYear) + 10)) += nMonto
                        End Select

                    End If

                End If

            Next

        End If

        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        'nCounter = 0
        'drFacturas = drAnexo.GetChildRows("AnexoFacturas")
        'CalcAnti(cAnexo, cFecha, nMaxCounter, nCounter, drFacturas)
        'If nCounter <= nMaxCounter Then

        drEstados = drAnexo.GetChildRows("AnexoEdoctav")
        For Each drEdocta In drEstados

            If (drEdocta("Feven") > cFecha) And drEdocta("Nufac") <> 9999999 Then

                If InStr("00006|00015|00044|00045|00061|00066|00353|00426|00454|00457|00606|00676|00719|00898|01054|01101|01455|01521|01591|01666|02488|03193|03348|03671|03921|05107|05214|05317|05318|05321", cCliente) > 0 Then
                    cad = "Relacionados"
                Else
                    cad = "No Relacionados"
                End If
                cAnexoX = Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 6, 4)
                cOrigen = drEdocta("origen")
                If cOrigen = "Contratos" Or cOrigen = "Contratos Otros" Then
                    drTemp = dtVenAn.Rows.Find(cAnexoX)
                    If drTemp Is Nothing Then
                        cOrigen = "Contratos Vigentes"
                    Else
                        cOrigen = "Contratos Vencidos"
                    End If
                End If
                If cOrigen = "Seguros" Then
                    drTemp = dtVenAn.Rows.Find(cAnexoX)
                    If drTemp Is Nothing Then
                        cOrigen = "Seguros Vigentes"
                    Else
                        cOrigen = "Seguros Vencidos"
                    End If
                End If

                If cOrigen = "Avios" Then
                    cAnexoX = Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 6, 4) & drEdocta("letra")
                    If cTipar = "C" Then
                        cOrigen = "Cuenta Corriente"
                    End If
                    drTemp = dtVenAv.Rows.Find(cAnexoX)
                    If drTemp Is Nothing Then
                        cOrigen = cOrigen & " Vigentes"
                    Else
                        cOrigen = cOrigen & " Vencidos"
                    End If
                End If

                If cOrigen = "Garantias" Then
                    cTiparX = cTipar
                    cTipar = "S"
                End If

                cYearPayment = Mid(drEdocta("Feven"), 1, 4)
                cMonth = Mid(drEdocta("Feven"), 5, 2)
                cMonthX = MonthName(Val(Mid(drEdocta("Feven"), 5, 2)))
                Total = Total + drEdocta("Abcap")
                CliNom = drEdocta("Descr")

                nMonto = drEdocta("Abcap")
                nMontoI = drEdocta("Inter")

                If drEdocta("Feven") <= cFechaCortoPalzo Then
                    nMontoC = drEdocta("Abcap")
                    nMontoIC = drEdocta("Inter")
                    nMontoL = 0
                    nMontoIL = 0
                Else
                    nMontoL = drEdocta("Abcap")
                    nMontoIL = drEdocta("Inter")
                    nMontoC = 0
                    nMontoIC = 0
                End If

                drTempX = dtReporteAcum.Rows.Find(cMonthX)
                f2.WriteLine(cAnexo & vbTab & CliNom & vbTab & cTipar & vbTab & nMonto & vbTab & nMontoI & vbTab & cad & vbTab & cOrigen & vbTab & nMontoC & vbTab & nMontoIC & vbTab & nMontoL & vbTab & nMontoIL & vbTab & drEdocta("FechaIni") & vbTab & drEdocta("Feven"))

                If cOrigen = "Garantias" Then
                    cTipar = cTiparX
                End If

                'nMonto = drEdocta("Abcap") + drEdocta("Inter")

                If drTempX Is Nothing Then

                    ' El mes no existe en la tabla

                    drTempX = dtReporteAcum.NewRow()
                    drTempX("Mes") = cMonthX
                    drTempX("Mes0") = cMonth

                    drTempX(CStr(Val(cYear) + 0) & "Fija") = 0
                    drTempX(CStr(Val(cYear) + 1) & "Fija") = 0
                    drTempX(CStr(Val(cYear) + 2) & "Fija") = 0
                    drTempX(CStr(Val(cYear) + 3) & "Fija") = 0
                    drTempX(CStr(Val(cYear) + 4) & "Fija") = 0
                    drTempX(CStr(Val(cYear) + 5) & "Fija") = 0
                    drTempX(CStr(Val(cYear) + 6) & "Fija") = 0
                    drTempX(CStr(Val(cYear) + 7) & "Fija") = 0
                    drTempX(CStr(Val(cYear) + 8) & "Fija") = 0
                    drTempX(CStr(Val(cYear) + 9) & "Fija") = 0
                    drTempX(CStr(Val(cYear) + 10) & "Fija") = 0

                    drTempX(CStr(Val(cYear) + 0) & "Variable") = 0
                    drTempX(CStr(Val(cYear) + 1) & "Variable") = 0
                    drTempX(CStr(Val(cYear) + 2) & "Variable") = 0
                    drTempX(CStr(Val(cYear) + 3) & "Variable") = 0
                    drTempX(CStr(Val(cYear) + 4) & "Variable") = 0
                    drTempX(CStr(Val(cYear) + 5) & "Variable") = 0
                    drTempX(CStr(Val(cYear) + 6) & "Variable") = 0
                    drTempX(CStr(Val(cYear) + 7) & "Variable") = 0
                    drTempX(CStr(Val(cYear) + 8) & "Variable") = 0
                    drTempX(CStr(Val(cYear) + 9) & "Variable") = 0
                    drTempX(CStr(Val(cYear) + 10) & "Variable") = 0


                    drTempX(cYear) = IIf(cYearPayment = cYear, nMonto, 0)
                    If cTipta = "7" Then
                        drTempX(cYear & "Fija") = IIf(cYearPayment = cYear, nMonto, 0)
                    Else
                        drTempX(cYear & "Variable") = IIf(cYearPayment = cYear, nMonto, 0)
                    End If
                    drTempX(CStr(Val(cYear) + 1)) = IIf(cYearPayment = CStr(Val(cYear) + 1), nMonto, 0)
                    If cTipta = "7" Then
                        drTempX(CStr(Val(cYear) + 1) & "Fija") = IIf(cYearPayment = CStr(Val(cYear) + 1), nMonto, 0)
                    Else
                        drTempX(CStr(Val(cYear) + 1) & "Variable") = IIf(cYearPayment = CStr(Val(cYear) + 1), nMonto, 0)
                    End If
                    drTempX(CStr(Val(cYear) + 2)) = IIf(cYearPayment = CStr(Val(cYear) + 2), nMonto, 0)
                    If cTipta = "7" Then
                        drTempX(CStr(Val(cYear) + 2) & "Fija") = IIf(cYearPayment = CStr(Val(cYear) + 2), nMonto, 0)
                    Else
                        drTempX(CStr(Val(cYear) + 2) & "Variable") = IIf(cYearPayment = CStr(Val(cYear) + 2), nMonto, 0)
                    End If
                    drTempX(CStr(Val(cYear) + 3)) = IIf(cYearPayment = CStr(Val(cYear) + 3), nMonto, 0)
                    If cTipta = "7" Then
                        drTempX(CStr(Val(cYear) + 3) & "Fija") = IIf(cYearPayment = CStr(Val(cYear) + 3), nMonto, 0)
                    Else
                        drTempX(CStr(Val(cYear) + 3) & "Variable") = IIf(cYearPayment = CStr(Val(cYear) + 3), nMonto, 0)
                    End If
                    drTempX(CStr(Val(cYear) + 4)) = IIf(cYearPayment = CStr(Val(cYear) + 4), nMonto, 0)
                    If cTipta = "7" Then
                        drTempX(CStr(Val(cYear) + 4) & "Fija") = IIf(cYearPayment = CStr(Val(cYear) + 4), nMonto, 0)
                    Else
                        drTempX(CStr(Val(cYear) + 4) & "Variable") = IIf(cYearPayment = CStr(Val(cYear) + 4), nMonto, 0)
                    End If
                    drTempX(CStr(Val(cYear) + 5)) = IIf(cYearPayment = CStr(Val(cYear) + 5), nMonto, 0)
                    If cTipta = "7" Then
                        drTempX(CStr(Val(cYear) + 5) & "Fija") = IIf(cYearPayment = CStr(Val(cYear) + 5), nMonto, 0)
                    Else
                        drTempX(CStr(Val(cYear) + 5) & "Variable") = IIf(cYearPayment = CStr(Val(cYear) + 5), nMonto, 0)
                    End If
                    drTempX(CStr(Val(cYear) + 6)) = IIf(cYearPayment = CStr(Val(cYear) + 6), nMonto, 0)
                    If cTipta = "7" Then
                        drTempX(CStr(Val(cYear) + 6) & "Fija") = IIf(cYearPayment = CStr(Val(cYear) + 6), nMonto, 0)
                    Else
                        drTempX(CStr(Val(cYear) + 6) & "Variable") = IIf(cYearPayment = CStr(Val(cYear) + 6), nMonto, 0)
                    End If
                    drTempX(CStr(Val(cYear) + 7)) = IIf(cYearPayment = CStr(Val(cYear) + 7), nMonto, 0)
                    If cTipta = "7" Then
                        drTempX(CStr(Val(cYear) + 7) & "Fija") = IIf(cYearPayment = CStr(Val(cYear) + 7), nMonto, 0)
                    Else
                        drTempX(CStr(Val(cYear) + 7) & "Variable") = IIf(cYearPayment = CStr(Val(cYear) + 7), nMonto, 0)
                    End If
                    drTempX(CStr(Val(cYear) + 8)) = IIf(cYearPayment = CStr(Val(cYear) + 8), nMonto, 0)
                    If cTipta = "7" Then
                        drTempX(CStr(Val(cYear) + 8) & "Fija") = IIf(cYearPayment = CStr(Val(cYear) + 8), nMonto, 0)
                    Else
                        drTempX(CStr(Val(cYear) + 8) & "Variable") = IIf(cYearPayment = CStr(Val(cYear) + 8), nMonto, 0)
                    End If

                    drTempX(CStr(Val(cYear) + 9)) = IIf(cYearPayment = CStr(Val(cYear) + 9), nMonto, 0)
                    If cTipta = "7" Then
                        drTempX(CStr(Val(cYear) + 9) & "Fija") = IIf(cYearPayment = CStr(Val(cYear) + 9), nMonto, 0)
                    Else
                        drTempX(CStr(Val(cYear) + 9) & "Variable") = IIf(cYearPayment = CStr(Val(cYear) + 9), nMonto, 0)
                    End If

                    drTempX(CStr(Val(cYear) + 10)) = IIf(cYearPayment = CStr(Val(cYear) + 10), nMonto, 0)
                    If cTipta = "7" Then
                        drTempX(CStr(Val(cYear) + 10) & "Fija") = IIf(cYearPayment = CStr(Val(cYear) + 10), nMonto, 0)
                    Else
                        drTempX(CStr(Val(cYear) + 10) & "Variable") = IIf(cYearPayment = CStr(Val(cYear) + 10), nMonto, 0)
                    End If
                    dtReporteAcum.Rows.Add(drTempX)

                Else

                    ' El mes ya existe en la tabla
                    Select Case cYearPayment
                        Case cYear
                            drTempX(cYear) += nMonto
                            If cTipta = "7" Then
                                drTempX(cYear & "Fija") += nMonto
                            Else
                                drTempX(cYear & "Variable") += nMonto
                            End If
                        Case CStr(Val(cYear) + 1)
                            drTempX(CStr(Val(cYear) + 1)) += nMonto
                            If cTipta = "7" Then
                                drTempX(CStr(Val(cYear) + 1) & "Fija") += nMonto
                            Else
                                drTempX(CStr(Val(cYear) + 1) & "Variable") += nMonto
                            End If
                        Case CStr(Val(cYear) + 2)
                            drTempX(CStr(Val(cYear) + 2)) += nMonto
                            If cTipta = "7" Then
                                drTempX(CStr(Val(cYear) + 2) & "Fija") += nMonto
                            Else
                                drTempX(CStr(Val(cYear) + 2) & "Variable") += nMonto
                            End If
                        Case CStr(Val(cYear) + 3)
                            drTempX(CStr(Val(cYear) + 3)) += nMonto
                            If cTipta = "7" Then
                                drTempX(CStr(Val(cYear) + 3) & "Fija") += nMonto
                            Else
                                drTempX(CStr(Val(cYear) + 3) & "Variable") += nMonto
                            End If
                        Case CStr(Val(cYear) + 4)
                            drTempX(CStr(Val(cYear) + 4)) += nMonto
                            If cTipta = "7" Then
                                drTempX(CStr(Val(cYear) + 4) & "Fija") += nMonto
                            Else
                                drTempX(CStr(Val(cYear) + 4) & "Variable") += nMonto
                            End If
                        Case CStr(Val(cYear) + 5)
                            drTempX(CStr(Val(cYear) + 5)) += nMonto
                            If cTipta = "7" Then
                                drTempX(CStr(Val(cYear) + 5) & "Fija") += nMonto
                            Else
                                drTempX(CStr(Val(cYear) + 5) & "Variable") += nMonto
                            End If
                        Case CStr(Val(cYear) + 6)
                            drTempX(CStr(Val(cYear) + 6)) += nMonto
                            If cTipta = "7" Then
                                drTempX(CStr(Val(cYear) + 6) & "Fija") += nMonto
                            Else
                                drTempX(CStr(Val(cYear) + 6) & "Variable") += nMonto
                            End If
                        Case CStr(Val(cYear) + 7)
                            drTempX(CStr(Val(cYear) + 7)) += nMonto
                            If cTipta = "7" Then
                                drTempX(CStr(Val(cYear) + 7) & "Fija") += nMonto
                            Else
                                drTempX(CStr(Val(cYear) + 7) & "Variable") += nMonto
                            End If
                        Case CStr(Val(cYear) + 8)
                            drTempX(CStr(Val(cYear) + 8)) += nMonto
                            If cTipta = "7" Then
                                drTempX(CStr(Val(cYear) + 8) & "Fija") += nMonto
                            Else
                                drTempX(CStr(Val(cYear) + 8) & "Variable") += nMonto
                            End If
                        Case CStr(Val(cYear) + 9)
                            drTempX(CStr(Val(cYear) + 9)) += nMonto
                            If cTipta = "7" Then
                                drTempX(CStr(Val(cYear) + 9) & "Fija") += nMonto
                            Else
                                drTempX(CStr(Val(cYear) + 9) & "Variable") += nMonto
                            End If
                        Case CStr(Val(cYear) + 10)
                            drTempX(CStr(Val(cYear) + 10)) += nMonto
                            If cTipta = "7" Then
                                drTempX(CStr(Val(cYear) + 10) & "Fija") += nMonto
                            Else
                                drTempX(CStr(Val(cYear) + 10) & "Variable") += nMonto
                            End If
                    End Select

                End If

            End If

        Next
        'End If



        
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()

    End Sub

    Sub sacaAVCC(tipo As String)
        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand
        If tipo = "H" Then
            cm1.CommandText = "Select * from Vw_AmortizacionesAV where mes > '" & DateTimePicker1.Value.ToString("yyyyMM") & "'"
        Else
            cm1.CommandText = "Select * from Vw_AmortizacionesCC where mes > '" & DateTimePicker1.Value.ToString("yyyyMM") & "'"
        End If
        cm1.CommandType = CommandType.Text
        cm1.Connection = cnAgil

        Dim daAvios As New SqlDataAdapter(cm1)
        Dim TAvios As New DataTable
        Dim drTemp As DataRow
        Dim drTempX As DataRow
        Dim cYearPayment As String = ""
        Dim Mess As String = ""
        Dim cTipta As String = ""

        For x As Integer = 1 To 12
            If x < 10 Then Mess = "0" & x Else Mess = x
            drTemp = dtReporte1.Rows.Find(Mess)
            If drTemp Is Nothing Then
                drTemp = dtReporte1.NewRow()
                drTemp("Mes") = Mess
                drTemp(cYear) = 0
                drTemp(CStr(Val(cYear) + 1)) = 0
                drTemp(CStr(Val(cYear) + 2)) = 0
                drTemp(CStr(Val(cYear) + 3)) = 0
                drTemp(CStr(Val(cYear) + 4)) = 0
                drTemp(CStr(Val(cYear) + 5)) = 0
                drTemp(CStr(Val(cYear) + 6)) = 0
                drTemp(CStr(Val(cYear) + 7)) = 0
                drTemp(CStr(Val(cYear) + 8)) = 0
                drTemp(CStr(Val(cYear) + 9)) = 0
                drTemp(CStr(Val(cYear) + 10)) = 0
                dtReporte1.Rows.Add(drTemp)
            End If
        Next

        daAvios.Fill(TAvios)
        For Each r As DataRow In TAvios.Rows
            Mess = Mid(r("Mes"), 5, 2)
            drTemp = dtReporte1.Rows.Find(Mess)

            cYearPayment = Mid(r("Mes"), 1, 4)
            cTipta = r("Tipta")
            If drTemp Is Nothing Then

                ' El mes no existe en la tabla
                drTemp = dtReporte1.NewRow()
                drTemp("Mes") = Mess
                drTemp(cYear) = IIf(cYearPayment = cYear, r("Total"), 0)
                drTemp(CStr(Val(cYear) + 1)) = IIf(cYearPayment = CStr(Val(cYear) + 1), r("Total"), 0)
                drTemp(CStr(Val(cYear) + 2)) = IIf(cYearPayment = CStr(Val(cYear) + 2), r("Total"), 0)
                drTemp(CStr(Val(cYear) + 3)) = IIf(cYearPayment = CStr(Val(cYear) + 3), r("Total"), 0)
                drTemp(CStr(Val(cYear) + 4)) = IIf(cYearPayment = CStr(Val(cYear) + 4), r("Total"), 0)
                drTemp(CStr(Val(cYear) + 5)) = IIf(cYearPayment = CStr(Val(cYear) + 5), r("Total"), 0)
                drTemp(CStr(Val(cYear) + 6)) = IIf(cYearPayment = CStr(Val(cYear) + 6), r("Total"), 0)
                drTemp(CStr(Val(cYear) + 7)) = IIf(cYearPayment = CStr(Val(cYear) + 7), r("Total"), 0)
                drTemp(CStr(Val(cYear) + 8)) = IIf(cYearPayment = CStr(Val(cYear) + 8), r("Total"), 0)
                drTemp(CStr(Val(cYear) + 9)) = IIf(cYearPayment = CStr(Val(cYear) + 8), r("Total"), 0)
                drTemp(CStr(Val(cYear) + 10)) = IIf(cYearPayment = CStr(Val(cYear) + 8), r("Total"), 0)
                dtReporte1.Rows.Add(drTemp)

            Else

                ' El mes ya existe en la tabla

                Select Case cYearPayment
                    Case cYear
                        drTemp(cYear) += r("Total")
                    Case CStr(Val(cYear) + 1)
                        drTemp(CStr(Val(cYear) + 1)) += r("Total")
                    Case CStr(Val(cYear) + 2)
                        drTemp(CStr(Val(cYear) + 2)) += r("Total")
                    Case CStr(Val(cYear) + 3)
                        drTemp(CStr(Val(cYear) + 3)) += r("Total")
                    Case CStr(Val(cYear) + 4)
                        drTemp(CStr(Val(cYear) + 4)) += r("Total")
                    Case CStr(Val(cYear) + 5)
                        drTemp(CStr(Val(cYear) + 5)) += r("Total")
                    Case CStr(Val(cYear) + 6)
                        drTemp(CStr(Val(cYear) + 6)) += r("Total")
                    Case CStr(Val(cYear) + 7)
                        drTemp(CStr(Val(cYear) + 7)) += r("Total")
                    Case CStr(Val(cYear) + 8)
                        drTemp(CStr(Val(cYear) + 8)) += r("Total")
                    Case CStr(Val(cYear) + 9)
                        drTemp(CStr(Val(cYear) + 9)) += r("Total")
                    Case CStr(Val(cYear) + 10)
                        drTemp(CStr(Val(cYear) + 10)) += r("Total")
                End Select
            End If

            If rbTotalCartera.Checked = True Then
                drTempX = dtReporteAcum.Rows.Find(MonthName(Val(Mess)))
                ' El mes ya existe en la tabla
                Select Case cYearPayment
                    Case cYear
                        drTempX(cYear) += r("Total")
                        If cTipta = "7" Then
                            drTempX(cYear & "Fija") += r("Total")
                        Else
                            drTempX(cYear & "Variable") += r("Total")
                        End If
                    Case CStr(Val(cYear) + 1)
                        drTempX(CStr(Val(cYear) + 1)) += r("Total")
                        If cTipta = "7" Then
                            drTempX(CStr(Val(cYear) + 1) & "Fija") += r("Total")
                        Else
                            drTempX(CStr(Val(cYear) + 1) & "Variable") += r("Total")
                        End If
                    Case CStr(Val(cYear) + 2)
                        drTempX(CStr(Val(cYear) + 2)) += r("Total")
                        If cTipta = "7" Then
                            drTempX(CStr(Val(cYear) + 2) & "Fija") += r("Total")
                        Else
                            drTempX(CStr(Val(cYear) + 2) & "Variable") += r("Total")
                        End If
                    Case CStr(Val(cYear) + 3)
                        drTempX(CStr(Val(cYear) + 3)) += r("Total")
                        If cTipta = "7" Then
                            drTempX(CStr(Val(cYear) + 3) & "Fija") += r("Total")
                        Else
                            drTempX(CStr(Val(cYear) + 3) & "Variable") += r("Total")
                        End If
                    Case CStr(Val(cYear) + 4)
                        drTempX(CStr(Val(cYear) + 4)) += r("Total")
                        If cTipta = "7" Then
                            drTempX(CStr(Val(cYear) + 4) & "Fija") += r("Total")
                        Else
                            drTempX(CStr(Val(cYear) + 4) & "Variable") += r("Total")
                        End If
                    Case CStr(Val(cYear) + 5)
                        drTempX(CStr(Val(cYear) + 5)) += r("Total")
                        If cTipta = "7" Then
                            drTempX(CStr(Val(cYear) + 5) & "Fija") += r("Total")
                        Else
                            drTempX(CStr(Val(cYear) + 5) & "Variable") += r("Total")
                        End If
                    Case CStr(Val(cYear) + 6)
                        drTempX(CStr(Val(cYear) + 6)) += r("Total")
                        If cTipta = "7" Then
                            drTempX(CStr(Val(cYear) + 6) & "Fija") += r("Total")
                        Else
                            drTempX(CStr(Val(cYear) + 6) & "Variable") += r("Total")
                        End If
                    Case CStr(Val(cYear) + 7)
                        drTempX(CStr(Val(cYear) + 7)) += r("Total")
                        If cTipta = "7" Then
                            drTempX(CStr(Val(cYear) + 7) & "Fija") += r("Total")
                        Else
                            drTempX(CStr(Val(cYear) + 7) & "Variable") += r("Total")
                        End If
                    Case CStr(Val(cYear) + 8)
                        drTempX(CStr(Val(cYear) + 8)) += r("Total")
                        If cTipta = "7" Then
                            drTempX(CStr(Val(cYear) + 8) & "Fija") += r("Total")
                        Else
                            drTempX(CStr(Val(cYear) + 8) & "Variable") += r("Total")
                        End If
                    Case CStr(Val(cYear) + 9)
                        drTempX(CStr(Val(cYear) + 9)) += r("Total")
                        If cTipta = "7" Then
                            drTempX(CStr(Val(cYear) + 9) & "Fija") += r("Total")
                        Else
                            drTempX(CStr(Val(cYear) + 9) & "Variable") += r("Total")
                        End If
                    Case CStr(Val(cYear) + 10)
                        drTempX(CStr(Val(cYear) + 10)) += r("Total")
                        If cTipta = "7" Then
                            drTempX(CStr(Val(cYear) + 10) & "Fija") += r("Total")
                        Else
                            drTempX(CStr(Val(cYear) + 10) & "Variable") += r("Total")
                        End If
                End Select
            End If
        Next

    End Sub


End Class


'SELECT EdoctaO.*, Anexos.Tipar, Anexos.Flcan, Anexos.Vencida, Anexos.Fechacon, Anexos.Fondeo, Anexos.ImpRD, Anexos.RtasD, Anexos.Porieq, Anexos.Fecha_Pago, Clientes.Tipo, Clientes.Descr FROM EdoctaO
'INNER JOIN Anexos ON EdoctaO.Anexo = Anexos.Anexo
'INNER JOIN Clientes ON Anexos.Cliente = Clientes.Cliente
'WHERE Anexos.Flcan = 'A'
'AND ((Fechacon <= '20110930') OR (Fechacon >= '20111001' AND Fecha_Pago <> '' AND Fecha_Pago <= @FechaFin))
'AND Anexos.Tipar IN ('F','P','R','S')
'ORDER BY EdoctaO.Anexo, EdoctaO.Feven, EdoctaO.Saldo