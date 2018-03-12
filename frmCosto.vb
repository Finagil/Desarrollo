Option Explicit On

Imports System.Data.SqlClient
Imports System.Math

Public Class frmCosto

    Private Sub frmCosto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración de variables de conexión

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim daAnexos As New SqlDataAdapter(cm1)
        Dim daEdoctav As New SqlDataAdapter(cm2)
        Dim dsAgil As New DataSet()
        Dim dtReporte As New DataTable("Reporte")
        Dim drAnexo As DataRow
        Dim drReporte As DataRow
        Dim drDataRow As DataRow
        Dim drEdoctav As DataRow()
        Dim relAnexosEdoctav As DataRelation
        Dim aPrimaryKey(1) As DataColumn

        ' Declaración de variables de datos

        Dim cAnexo As String
        Dim cFechacon As String
        Dim cFechaInicial As String
        Dim cFechafin As String
        Dim cFechaFinal As String
        Dim cFeven As String
        Dim cFlcan As String
        Dim cIndRec As String
        Dim nAmorin As Decimal
        Dim nAmorinENE As Decimal
        Dim nAmorinFEB As Decimal
        Dim nAmorinMAR As Decimal
        Dim nAmorinABR As Decimal
        Dim nAmorinMAY As Decimal
        Dim nAmorinJUN As Decimal
        Dim nAmorinJUL As Decimal
        Dim nAmorinAGO As Decimal
        Dim nAmorinSEP As Decimal
        Dim nAmorinOCT As Decimal
        Dim nAmorinNOV As Decimal
        Dim nAmorinDIC As Decimal
        Dim nImporteRentas As Decimal
        Dim nSaldoInsoluto As Decimal
        Dim cMes As String
        Dim nCostoEne As Decimal
        Dim nCostoFeb As Decimal
        Dim nCostoMar As Decimal
        Dim nCostoAbr As Decimal
        Dim nCostoMay As Decimal
        Dim nCostoJun As Decimal
        Dim nCostoJul As Decimal
        Dim nCostoAgo As Decimal
        Dim nCostoSep As Decimal
        Dim nCostoOct As Decimal
        Dim nCostoNov As Decimal
        Dim nCostoDic As Decimal
        Dim nMOI As Decimal
        Dim nRentaMes As Decimal


        cFechaInicial = "20050101"
        cFechaFinal = "20051231"

        ' Primero creo la tabla dtReporte

        dtReporte.Columns.Add("Anexo", Type.GetType("System.String"))
        dtReporte.Columns.Add("Flcan", Type.GetType("System.String"))
        dtReporte.Columns.Add("MOI", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("Amorin", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("SaldoInsoluto", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("Fechacon", Type.GetType("System.String"))
        dtReporte.Columns.Add("Fechafin", Type.GetType("System.String"))
        dtReporte.Columns.Add("ImporteRentas", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("ENE", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("FEB", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("MAR", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("ABR", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("MAY", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("JUN", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("JUL", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("AGO", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("SEP", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("OCT", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("NOV", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("DIC", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("TOTAL", Type.GetType("System.Decimal"))

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Costo1"
            .Connection = cnAgil
            .Parameters.Add("@FechaIni", SqlDbType.NVarChar)
            .Parameters(0).Value = cFechaInicial
            .Parameters.Add("@FechaFin", SqlDbType.NVarChar)
            .Parameters(1).Value = cFechaFinal
        End With

        With cm2
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Costo2"
            .Connection = cnAgil
            .Parameters.Add("@FechaIni", SqlDbType.NVarChar)
            .Parameters(0).Value = cFechaInicial
            .Parameters.Add("@FechaFin", SqlDbType.NVarChar)
            .Parameters(1).Value = cFechaFinal
        End With

        'Llenar el DataSet a través del DataAdapter, lo cual abre y cierra la conexión

        daAnexos.Fill(dsAgil, "Anexos")
        daEdoctav.Fill(dsAgil, "Edoctav")
        
        relAnexosEdoctav = New DataRelation("AnexosEdoctav", dsAgil.Tables("Anexos").Columns("Anexo"), dsAgil.Tables("Edoctav").Columns("Anexo"))
        dsAgil.EnforceConstraints = False
        dsAgil.Relations.Add(relAnexosEdoctav)
        dsAgil.EnforceConstraints = True
        
        ' Ahora defino la llave primaria de la tabla dtReporte para poder buscar un anexo en particular

        aPrimaryKey(0) = dtReporte.Columns("Anexo")
        dtReporte.PrimaryKey = aPrimaryKey

        For Each drAnexo In dsAgil.Tables("Anexos").Rows

            cFechacon = drAnexo("Fechacon")
            drEdoctav = drAnexo.GetChildRows("AnexosEdoctav")

            nSaldoInsoluto = 0
            nImporteRentas = 0
            For Each drDataRow In drEdoctav
                If cFechacon < cFechaInicial Then
                    nSaldoInsoluto = nSaldoInsoluto + drDataRow("Abcap")
                End If
                nImporteRentas = nImporteRentas + (drDataRow("Abcap") + drDataRow("Inter"))
            Next

            drReporte = dtReporte.NewRow()
            drReporte("Anexo") = "C" & drAnexo("Anexo")
            drReporte("Flcan") = drAnexo("Flcan")
            drReporte("MOI") = drAnexo("MOI")
            drReporte("Amorin") = 0
            drReporte("SaldoInsoluto") = nSaldoInsoluto
            drReporte("Fechacon") = drAnexo("Fechacon")
            drReporte("Fechafin") = drAnexo("Fechafin")
            drReporte("ImporteRentas") = nImporteRentas
            drReporte("ENE") = 0
            drReporte("FEB") = 0
            drReporte("MAR") = 0
            drReporte("ABR") = 0
            drReporte("MAY") = 0
            drReporte("JUN") = 0
            drReporte("JUL") = 0
            drReporte("AGO") = 0
            drReporte("SEP") = 0
            drReporte("OCT") = 0
            drReporte("NOV") = 0
            drReporte("DIC") = 0
            drReporte("Total") = 0
            dtReporte.Rows.Add(drReporte)

        Next

        For Each drAnexo In dsAgil.Tables("Anexos").Rows

            cAnexo = drAnexo("Anexo")
            cFlcan = drAnexo("Flcan")
            cFechacon = drAnexo("Fechacon")
            cFechaFin = drAnexo("Fechafin")

            drEdoctav = drAnexo.GetChildRows("AnexosEdoctav")

            nCostoEne = 0
            nCostoFeb = 0
            nCostoMar = 0
            nCostoAbr = 0
            nCostoMay = 0
            nCostoJun = 0
            nCostoJul = 0
            nCostoAgo = 0
            nCostoSep = 0
            nCostoOct = 0
            nCostoNov = 0
            nCostoDic = 0

            For Each drDataRow In drEdoctav

                cFeven = drDataRow("Feven")
                cIndRec = drDataRow("IndRec")

                If cFlcan = "A" Or cFlcan = "T" Then

                    If cFeven >= cFechaInicial And cFeven <= cFechaFinal Then
                        cMes = Mid(cFeven, 5, 2)
                        nRentaMes = drDataRow("Abcap") + drDataRow("Inter")
                        If nRentaMes > 0 Then
                            Select Case cMes
                                Case "01"
                                    nCostoEne = nCostoEne + nRentaMes
                                Case "02"
                                    nCostoFeb = nCostoFeb + nRentaMes
                                Case "03"
                                    nCostoMar = nCostoMar + nRentaMes
                                Case "04"
                                    nCostoAbr = nCostoAbr + nRentaMes
                                Case "05"
                                    nCostoMay = nCostoMay + nRentaMes
                                Case "06"
                                    nCostoJun = nCostoJun + nRentaMes
                                Case "07"
                                    nCostoJul = nCostoJul + nRentaMes
                                Case "08"
                                    nCostoAgo = nCostoAgo + nRentaMes
                                Case "09"
                                    nCostoSep = nCostoSep + nRentaMes
                                Case "10"
                                    nCostoOct = nCostoOct + nRentaMes
                                Case "11"
                                    nCostoNov = nCostoNov + nRentaMes
                                Case "12"
                                    nCostoDic = nCostoDic + nRentaMes
                            End Select
                        End If
                    End If

                ElseIf cFlcan = "C" Then

                    ' Los contratos cancelados tienen un tratamiento especial ya que debe tomar
                    ' los vencimientos normales y los posteriores a la fecha de cancelación y
                    ' considerar que ocurrieron en el mes de la cancelación.

                    cMes = ""
                    If cFeven >= cFechaInicial And cFeven <= cFechaFinal And cIndRec = "S" Then
                        cMes = Mid(cFeven, 5, 2)
                    ElseIf cFeven >= cFechaInicial And cIndRec = "N" Then
                        cMes = Mid(cFechafin, 5, 2)
                    ElseIf cFeven > cFechaFinal Then
                        cMes = Mid(cFechafin, 5, 2)
                    End If
                    nRentaMes = drDataRow("Abcap") + drDataRow("Inter")
                    Select Case cMes
                        Case "01"
                            nCostoEne = nCostoEne + nRentaMes
                        Case "02"
                            nCostoFeb = nCostoFeb + nRentaMes
                        Case "03"
                            nCostoMar = nCostoMar + nRentaMes
                        Case "04"
                            nCostoAbr = nCostoAbr + nRentaMes
                        Case "05"
                            nCostoMay = nCostoMay + nRentaMes
                        Case "06"
                            nCostoJun = nCostoJun + nRentaMes
                        Case "07"
                            nCostoJul = nCostoJul + nRentaMes
                        Case "08"
                            nCostoAgo = nCostoAgo + nRentaMes
                        Case "09"
                            nCostoSep = nCostoSep + nRentaMes
                        Case "10"
                            nCostoOct = nCostoOct + nRentaMes
                        Case "11"
                            nCostoNov = nCostoNov + nRentaMes
                        Case "12"
                            nCostoDic = nCostoDic + nRentaMes
                    End Select
                End If
            Next

            drReporte = dtReporte.Rows.Find("C" & cAnexo)

            If Not drReporte Is Nothing Then

                nMOI = drReporte("MOI")
                nSaldoInsoluto = drReporte("SaldoInsoluto")
                nImporteRentas = drReporte("ImporteRentas")

                If cFechacon < cFechaInicial Then
                    drReporte("ENE") = Round(nCostoEne / nImporteRentas * nSaldoInsoluto, 2)
                    drReporte("FEB") = Round(nCostoFeb / nImporteRentas * nSaldoInsoluto, 2)
                    drReporte("MAR") = Round(nCostoMar / nImporteRentas * nSaldoInsoluto, 2)
                    drReporte("ABR") = Round(nCostoAbr / nImporteRentas * nSaldoInsoluto, 2)
                    drReporte("MAY") = Round(nCostoMay / nImporteRentas * nSaldoInsoluto, 2)
                    drReporte("JUN") = Round(nCostoJun / nImporteRentas * nSaldoInsoluto, 2)
                    drReporte("JUL") = Round(nCostoJul / nImporteRentas * nSaldoInsoluto, 2)
                    drReporte("AGO") = Round(nCostoAgo / nImporteRentas * nSaldoInsoluto, 2)
                    drReporte("SEP") = Round(nCostoSep / nImporteRentas * nSaldoInsoluto, 2)
                    drReporte("OCT") = Round(nCostoOct / nImporteRentas * nSaldoInsoluto, 2)
                    drReporte("NOV") = Round(nCostoNov / nImporteRentas * nSaldoInsoluto, 2)
                    drReporte("DIC") = Round(nCostoDic / nImporteRentas * nSaldoInsoluto, 2)
                Else
                    drReporte("ENE") = Round(nCostoEne / nImporteRentas * nMOI, 2)
                    drReporte("FEB") = Round(nCostoFeb / nImporteRentas * nMOI, 2)
                    drReporte("MAR") = Round(nCostoMar / nImporteRentas * nMOI, 2)
                    drReporte("ABR") = Round(nCostoAbr / nImporteRentas * nMOI, 2)
                    drReporte("MAY") = Round(nCostoMay / nImporteRentas * nMOI, 2)
                    drReporte("JUN") = Round(nCostoJun / nImporteRentas * nMOI, 2)
                    drReporte("JUL") = Round(nCostoJul / nImporteRentas * nMOI, 2)
                    drReporte("AGO") = Round(nCostoAgo / nImporteRentas * nMOI, 2)
                    drReporte("SEP") = Round(nCostoSep / nImporteRentas * nMOI, 2)
                    drReporte("OCT") = Round(nCostoOct / nImporteRentas * nMOI, 2)
                    drReporte("NOV") = Round(nCostoNov / nImporteRentas * nMOI, 2)
                    drReporte("DIC") = Round(nCostoDic / nImporteRentas * nMOI, 2)
                End If

            End If

        Next


        For Each drAnexo In dsAgil.Tables("Anexos").Rows

            cAnexo = drAnexo("Anexo")
            cFechacon = drAnexo("Fechacon")
            nAmorin = drAnexo("Amorin")

            If cFechacon < cFechaInicial Then
                nAmorin = 0
            End If

            cMes = Mid(cFechacon, 5, 2)

            nAmorinENE = 0
            nAmorinFEB = 0
            nAmorinMAR = 0
            nAmorinABR = 0
            nAmorinMAY = 0
            nAmorinJUN = 0
            nAmorinJUL = 0
            nAmorinAGO = 0
            nAmorinSEP = 0
            nAmorinOCT = 0
            nAmorinNOV = 0
            nAmorinDIC = 0

            Select Case cMes
                Case "01"
                    nAmorinENE = nAmorin
                Case "02"
                    nAmorinFEB = nAmorin
                Case "03"
                    nAmorinMAR = nAmorin
                Case "04"
                    nAmorinABR = nAmorin
                Case "05"
                    nAmorinMAY = nAmorin
                Case "06"
                    nAmorinJUN = nAmorin
                Case "07"
                    nAmorinJUL = nAmorin
                Case "08"
                    nAmorinAGO = nAmorin
                Case "09"
                    nAmorinSEP = nAmorin
                Case "10"
                    nAmorinOCT = nAmorin
                Case "11"
                    nAmorinNOV = nAmorin
                Case "12"
                    nAmorinDIC = nAmorin
            End Select

            drReporte = dtReporte.Rows.Find("C" & cAnexo)

            If Not drReporte Is Nothing Then

                drReporte("Amorin") = nAmorin
                drReporte("ENE") = drReporte("ENE") + nAmorinENE
                drReporte("FEB") = drReporte("FEB") + nAmorinFEB
                drReporte("MAR") = drReporte("MAR") + nAmorinMAR
                drReporte("ABR") = drReporte("ABR") + nAmorinABR
                drReporte("MAY") = drReporte("MAY") + nAmorinMAY
                drReporte("JUN") = drReporte("JUN") + nAmorinJUN
                drReporte("JUL") = drReporte("JUL") + nAmorinJUL
                drReporte("AGO") = drReporte("AGO") + nAmorinAGO
                drReporte("SEP") = drReporte("SEP") + nAmorinSEP
                drReporte("OCT") = drReporte("OCT") + nAmorinOCT
                drReporte("NOV") = drReporte("NOV") + nAmorinNOV
                drReporte("DIC") = drReporte("DIC") + nAmorinDIC
                drReporte("Total") = drReporte("ENE") + drReporte("FEB") + drReporte("MAR") + drReporte("ABR")
                drReporte("Total") += drReporte("MAY") + drReporte("JUN") + drReporte("JUL") + drReporte("AGO")
                drReporte("Total") += drReporte("SEP") + drReporte("OCT") + drReporte("NOV") + drReporte("DIC")

            End If

        Next

        cnAgil.Dispose()
        cm1.Dispose()

        DataGridView1.DataSource = dtReporte

    End Sub

End Class

