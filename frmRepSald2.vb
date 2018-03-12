Option Explicit On

Imports System.Data.SqlClient
Imports System.Math
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmRepSald2

    ' Declaración de variables de Crystal Reports de alcance privado

    Dim newrptRepsaldo As rptRepSaldo2
    Dim newrptRepSdoMpt As rptMptSaldo2
    Dim newrptMptSaldo As rptMptSaldo
    
    Private Sub frmRepSald2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbReportes.Items.Add("Por plaza")
        cbReportes.Items.Add("Por tipo de equipo")
        cbReportes.Items.Add("Por rangos de montos")
        cbReportes.Items.Add("Por MPT Saldo Insoluto")
        cbReportes.Items.Add("Por MPT Saldo Insoluto2")
        cbReportes.SelectedIndex = 0
    End Sub

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim cm4 As New SqlCommand()
        Dim cm5 As New SqlCommand()
        Dim daAnexos As New SqlDataAdapter(cm1)
        Dim daEdoctav As New SqlDataAdapter(cm2)
        Dim daPlazas As New SqlDataAdapter(cm3)
        Dim daFacturas As New SqlDataAdapter(cm4)
        Dim daActivo As New SqlDataAdapter(cm5)
        Dim dsAgil As New DataSet()
        Dim dsReporte As New DataSet()
        Dim dsGrafica As New DataSet()
        Dim dtReporte As New DataTable("Reporte")
        Dim dtReporte1 As New DataTable("Grafica")
        Dim drEdoctav As DataRow()
        Dim drFacturas As DataRow()
        Dim drActivos As DataRow()
        Dim drActivo As DataRow
        Dim drAnexo As DataRow
        Dim drReporte As DataRow
        Dim drPlaza As DataRow
        Dim relAnexoEdoctav As DataRelation
        Dim relAnexoFacturas As DataRelation
        Dim relAnexoPlaza As DataRelation
        Dim relAnexoActivo As DataRelation
        Dim myColArray(1) As DataColumn

        ' Declaración de variables de datos

        Dim cFecha As String
        Dim cDetalle As String
        Dim cDetalle1 As String
        Dim cFondeo As String
        Dim cAnexo As String
        Dim cTipeq As String
        Dim cAgrupa As String
        Dim cAgrupa1 As String
        Dim cTipar As String
        Dim cFvenc As String
        Dim nAutomovil As Integer
        Dim nCarga As Integer
        Dim nCounter As Integer
        Dim nPlazo As Integer
        Dim nMpt As Integer
        Dim nMaxCounter As Integer = 100
        Dim nPasaje As Integer
        Dim nSaldoEquipo As Decimal
        Dim nInteresEquipo As Decimal
        Dim nCarteraEquipo As Decimal
        Dim newrptRepsaldo2 As rptRepSaldo2

        cFecha = DTOC(dtpProcesar.Value)

        newrptRepsaldo2 = New rptRepSaldo2()

        ' Primero creo la tabla Reporte que será la base del reporte

        dtReporte.Columns.Add("Agrupa", Type.GetType("System.String"))
        dtReporte.Columns.Add("Descripcion", Type.GetType("System.String"))
        dtReporte.Columns.Add("Acumula1", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("Saldorp", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("Acumula2", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("Saldorn", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("Acumula3", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("Saldorf", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("Acumula4", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("Saldopf", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("AcumulaTotal", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("SaldoTotal", Type.GetType("System.Decimal"))

        ' Este Stored Procedure trae todos los contratos activos con fecha de contratación menor o igual
        ' a la de proceso

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "GeneProv1"
            .Connection = cnAgil
            .Parameters.Add("@FechaFin", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        ' Este Stored Procedure trae la tabla de amortización del equipo de todos los contratos activos
        ' con fecha de contratación menor o igual a la de proceso

        With cm2
            .CommandType = CommandType.StoredProcedure
            .CommandText = "GeneProv2"
            .Connection = cnAgil
            .Parameters.Add("@FechaFin", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        ' Este Stored Procedure trae la tabla de Plazas

        With cm3
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Plazas1"
            .Connection = cnAgil
        End With

        ' Este Stored Procedure trae todas las facturas no pagadas de todos los contratos activos con fecha de
        ' contratación menor o igual a la de proceso

        With cm4
            .CommandType = CommandType.StoredProcedure
            .CommandText = "CalcAnti1"
            .Connection = cnAgil
            .Parameters.Add("@Fecha", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        ' Este Stored Procedure trae todas las facturas de activo fijo 

        With cm5
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Actifijo5"
            .Connection = cnAgil
        End With

        ' Llenar el DataSet a través del DataAdapter, lo cual abre y cierra la conexión

        daAnexos.Fill(dsAgil, "Anexos")
        daEdoctav.Fill(dsAgil, "Edoctav")
        daPlazas.Fill(dsAgil, "Plazas")
        daFacturas.Fill(dsAgil, "Facturas")
        daActivo.Fill(dsAgil, "Activo")

        ' Establecer la relación entre Anexos y Edoctav

        relAnexoEdoctav = New DataRelation("AnexoEdoctav", dsAgil.Tables("Anexos").Columns("Anexo"), dsAgil.Tables("Edoctav").Columns("Anexo"))
        dsAgil.EnforceConstraints = False
        dsAgil.Relations.Add(relAnexoEdoctav)

        ' Establecer la relación entre Anexos y Edoctas

        relAnexoPlaza = New DataRelation("AnexoPlaza", dsAgil.Tables("Anexos").Columns("Plaza"), dsAgil.Tables("Plazas").Columns("Plaza"))
        dsAgil.EnforceConstraints = False
        dsAgil.Relations.Add(relAnexoPlaza)

        ' Establecer la relación entre Anexos y Facturas

        relAnexoFacturas = New DataRelation("AnexoFacturas", dsAgil.Tables("Anexos").Columns("Anexo"), dsAgil.Tables("Facturas").Columns("Anexo"))
        dsAgil.EnforceConstraints = False
        dsAgil.Relations.Add(relAnexoFacturas)

        ' Establecer la relación entre Anexos y ActivoFijo

        relAnexoActivo = New DataRelation("AnexoActivo", dsAgil.Tables("Anexos").Columns("Anexo"), dsAgil.Tables("Activo").Columns("Anexo"))
        dsAgil.EnforceConstraints = False
        dsAgil.Relations.Add(relAnexoActivo)

        If cbReportes.SelectedIndex = 3 Or cbReportes.SelectedIndex = 4 Then

            ' Tabla que nos permitirá almacenar los datos a ser graficados

            dtReporte1.Columns.Add("Agrupa1", Type.GetType("System.String"))
            dtReporte1.Columns.Add("Descripcion1", Type.GetType("System.String"))
            dtReporte1.Columns.Add("Acumulacr", Type.GetType("System.Decimal"))
            dtReporte1.Columns.Add("SaldoIncr", Type.GetType("System.Decimal"))
            dtReporte1.Columns.Add("Acumulaaf", Type.GetType("System.Decimal"))
            dtReporte1.Columns.Add("SaldoInaf", Type.GetType("System.Decimal"))
        End If

        For Each drAnexo In dsAgil.Tables("Anexos").Rows

            cAnexo = drAnexo("Anexo")
            cFondeo = drAnexo("Fondeo")
            cTipeq = drAnexo("Tipeq")
            cTipar = drAnexo("Tipar")
            cFvenc = drAnexo("Fvenc")
            nPlazo = drAnexo("Plazo")
            nMpt = Mpt(Termina(CTOD(cFvenc), nPlazo), dtpProcesar.Value)

            drFacturas = drAnexo.GetChildRows("AnexoFacturas")

            CalcAnti(cAnexo, cFecha, nMaxCounter, nCounter, drFacturas)

            If nCounter <= nMaxCounter Then

                ' Se trata de un contrato que NO está vencido (no tiene rentas vencidas a más de 89 días)

                nSaldoEquipo = 0
                nInteresEquipo = 0
                nCarteraEquipo = 0

                ' Esta instrucción trae la tabla de amortización del Equipo única y exclusivamente del contrato
                ' que está siendo procesado

                drEdoctav = drAnexo.GetChildRows("AnexoEdoctav")
                TraeSald(drEdoctav, cFecha, nSaldoEquipo, nInteresEquipo, nCarteraEquipo)

                If cTipeq = "4" Then
                    cTipeq = "6"
                ElseIf cTipeq = "5" Then
                    cTipeq = "7"
                ElseIf cTipeq = "6" Then
                    cTipeq = "8"
                ElseIf cTipeq = "7" Then
                    cTipeq = "9"
                End If

                Select Case cbReportes.SelectedIndex

                    Case Is = 0

                        drPlaza = drAnexo.GetChildRows("AnexoPlaza")(0)
                        cDetalle = drPlaza("DescPlaza")
                        cAgrupa = drPlaza("DescPlaza")

                    Case Is = 1

                        drActivos = drAnexo.GetChildRows("AnexoActivo")
                        cAgrupa = cTipeq
                        nAutomovil = 0
                        nCarga = 0
                        nPasaje = 0
                        If cTipeq = "3" Then
                            For Each drActivo In drActivos
                                If Not IsDBNull(drActivo("Detalle")) Then

                                    nAutomovil = InStr(1, drActivo("Detalle"), "AUTOMOVIL", CompareMethod.Text)

                                    nCarga = InStr(1, drActivo("Detalle"), "TRACTOCAMION", CompareMethod.Text)
                                    nCarga = IIf(nCarga = 0, InStr(1, drActivo("Detalle"), "TRAILER", CompareMethod.Text), nCarga)
                                    nCarga = IIf(nCarga = 0, InStr(1, drActivo("Detalle"), "CHASIS", CompareMethod.Text), nCarga)
                                    nCarga = IIf(nCarga = 0, InStr(1, drActivo("Detalle"), "KENWORTH", CompareMethod.Text), nCarga)
                                    nCarga = IIf(nCarga = 0, InStr(1, drActivo("Detalle"), "RAM VAN", CompareMethod.Text), nCarga)
                                    nCarga = IIf(nCarga = 0, InStr(1, drActivo("Detalle"), "PICK", CompareMethod.Text), nCarga)
                                    nCarga = IIf(nCarga = 0, InStr(1, drActivo("Detalle"), "REMOLQUE", CompareMethod.Text), nCarga)

                                    nPasaje = InStr(1, drActivo("Detalle"), "CAMION", CompareMethod.Text)
                                    nPasaje = IIf(nPasaje = 0, InStr(1, drActivo("Detalle"), "PASAJE", CompareMethod.Text), nPasaje)
                                    nPasaje = IIf(nPasaje = 0, InStr(1, drActivo("Detalle"), "AUTOBUS", CompareMethod.Text), nPasaje)
                                End If
                            Next
                            If nAutomovil > 0 Then
                                cTipeq = "3"
                            ElseIf nCarga > 0 Then
                                cTipeq = "4"
                            ElseIf nPasaje > 0 Then
                                cTipeq = "5"
                            Else
                                cTipeq = "5"
                            End If
                        End If
                        cAgrupa = cTipeq
                        Select Case cTipeq
                            Case Is = "1"
                                cDetalle = "COMERCIAL Y OF."
                            Case Is = "2"
                                cDetalle = "INDUSTRIAL"
                            Case Is = "3"
                                cDetalle = "AUTOMOVILES"
                            Case Is = "4"
                                cDetalle = "CAMIONES DE CARGA"
                            Case Is = "5"
                                cDetalle = "CAMIONES DE PASAJE"
                            Case Is = "6"
                                cDetalle = "COMPUTO"
                            Case Is = "7"
                                cDetalle = "CONSTRUCCION"
                            Case Is = "8"
                                cDetalle = "INMUEBLES"
                            Case Is = "9"
                                cDetalle = "OTROS EQUIPOS"
                        End Select

                    Case Is = 2

                        Select Case nSaldoEquipo
                            Case Is <= 100000
                                cAgrupa = "01"
                                cDetalle = "HASTA   100,000.00 PESOS"
                            Case Is <= 200000
                                cAgrupa = "02"
                                cDetalle = "HASTA   200,000.00 PESOS"
                            Case Is <= 300000
                                cAgrupa = "03"
                                cDetalle = "HASTA   300,000.00 PESOS"
                            Case Is <= 400000
                                cAgrupa = "04"
                                cDetalle = "HASTA   400,000.00 PESOS"
                            Case Is <= 500000
                                cAgrupa = "05"
                                cDetalle = "HASTA   500,000.00 PESOS"
                            Case Is <= 1000000
                                cAgrupa = "06"
                                cDetalle = "HASTA 1,000,000.00 PESOS"
                            Case Is <= 2000000
                                cAgrupa = "07"
                                cDetalle = "HASTA 2,000,000.00 PESOS"
                            Case Is <= 3000000
                                cAgrupa = "08"
                                cDetalle = "HASTA 3,000,000.00 PESOS"
                            Case Is <= 4000000
                                cAgrupa = "09"
                                cDetalle = "HASTA 4,000,000.00 PESOS"
                            Case Is <= 5000000
                                cAgrupa = "10"
                                cDetalle = "HASTA 5,000,000.00 PESOS"
                            Case Is <= 6000000
                                cAgrupa = "11"
                                cDetalle = "HASTA 6,000,000.00 PESOS"
                            Case Is <= 7000000
                                cAgrupa = "12"
                                cDetalle = "HASTA 7,000,000.00 PESOS"
                            Case Is <= 8000000
                                cAgrupa = "13"
                                cDetalle = "HASTA 8,000,000.00 PESOS"
                            Case Is <= 9999999
                                cAgrupa = "14"
                                cDetalle = "HASTA 9,999,999.00 PESOS"
                        End Select

                    Case 3, 4

                        If cFondeo = "01" Then
                            Select Case nMpt
                                Case Is <= 6
                                    cAgrupa1 = "HASTA 12"
                                    cDetalle1 = "01 a 06"
                                Case 7 To 12
                                    cAgrupa1 = "HASTA 12"
                                    cDetalle1 = "07 a 12"
                                Case 13 To 18
                                    cAgrupa1 = "HASTA 24"
                                    cDetalle1 = "13 a 18"
                                Case 19 To 24
                                    cAgrupa1 = "HASTA 24"
                                    cDetalle1 = "19 a 24"
                                Case 25 To 30
                                    cAgrupa1 = "HASTA 36"
                                    cDetalle1 = "25 a 30"
                                Case 31 To 36
                                    cAgrupa1 = "HASTA 36"
                                    cDetalle1 = "31 a 36"
                                Case 37 To 42
                                    cAgrupa1 = "HASTA 48"
                                    cDetalle1 = "37 a 42"
                                Case 43 To 48
                                    cAgrupa1 = "HASTA 48"
                                    cDetalle1 = "43 a 48"
                                Case 49 To 54
                                    cAgrupa1 = "HASTA 60"
                                    cDetalle1 = "49 a 54"
                                Case 55 To 60
                                    cAgrupa1 = "HASTA 60"
                                    cDetalle1 = "55 a 60"
                            End Select

                        End If

                End Select

                If cbReportes.SelectedIndex < 3 And nSaldoEquipo > 0 Then

                    drReporte = dtReporte.NewRow()
                    drReporte("Agrupa") = cAgrupa
                    drReporte("Descripcion") = cDetalle
                    drReporte("Acumula1") = IIf(cFondeo = "01", 1, 0)
                    drReporte("Saldorp") = IIf(cFondeo = "01", nSaldoEquipo, 0)
                    drReporte("Acumula2") = IIf(cFondeo = "02", 1, 0)
                    drReporte("Saldorn") = IIf(cFondeo = "02", nSaldoEquipo, 0)
                    drReporte("Acumula3") = IIf(cFondeo = "03", 1, 0)
                    drReporte("Saldorf") = IIf(cFondeo = "03", nSaldoEquipo, 0)
                    drReporte("Acumula4") = IIf(cFondeo = "04", 1, 0)
                    drReporte("Saldopf") = IIf(cFondeo = "04", nSaldoEquipo, 0)
                    drReporte("AcumulaTotal") = 1
                    drReporte("SaldoTotal") = nSaldoEquipo
                    dtReporte.Rows.Add(drReporte)

                ElseIf cbReportes.SelectedIndex = 3 Or cbReportes.SelectedIndex = 4 Then

                    drReporte = dtReporte1.NewRow()
                    drReporte("Agrupa1") = cAgrupa1
                    drReporte("Descripcion1") = cDetalle1
                    drReporte("Acumulacr") = IIf(cTipar = "R", 1, 0)
                    drReporte("SaldoIncr") = IIf(cTipar = "R", nSaldoEquipo, 0)
                    drReporte("Acumulaaf") = IIf(cTipar = "F", 1, 0)
                    drReporte("SaldoInaf") = IIf(cTipar = "F", nSaldoEquipo, 0)
                    dtReporte1.Rows.Add(drReporte)

                End If

            End If

        Next

        If cbReportes.SelectedIndex = 3 Then

            newrptMptSaldo = New rptMptSaldo()

            dsGrafica.Tables.Add(dtReporte1)

            ' Descomentar la siguiente línea en caso de que se deseara modificar el reporte rptRepsaldo2
            ' dsReporte.WriteXml("C:\Schema36.xml", XmlWriteMode.WriteSchema)

            newrptMptSaldo.SetDataSource(dsGrafica)
            CrystalReportViewer1.ReportSource = newrptMptSaldo

        ElseIf cbReportes.SelectedIndex = 4 Then

            newrptRepSdoMpt = New rptMptSaldo2()

            dsGrafica.Tables.Add(dtReporte1)

            ' Descomentar la siguiente línea en caso de que se deseara modificar el reporte rptRepsaldo2
            ' dsReporte.WriteXml("C:\Schema36.xml", XmlWriteMode.WriteSchema)

            newrptRepSdoMpt.SetDataSource(dsGrafica)
            CrystalReportViewer1.ReportSource = newrptRepSdoMpt

        Else

            dsReporte.Tables.Add(dtReporte)

            ' Descomentar la siguiente línea en caso de que se deseara modificar el reporte rptRepsaldo2
            ' dsReporte.WriteXml("C:\Schema36.xml", XmlWriteMode.WriteSchema)

            newrptRepsaldo2.SetDataSource(dsReporte)

            Select Case cbReportes.SelectedIndex
                Case Is = 0
                    newrptRepsaldo2.SummaryInfo.ReportTitle = "REPORTE DE SALDOS INSOLUTOS POR PLAZA AL " & Mes(cFecha)
                    newrptRepsaldo2.SummaryInfo.ReportComments = "PLAZA"
                Case Is = 1
                    newrptRepsaldo2.SummaryInfo.ReportTitle = "REPORTE DE SALDOS INSOLUTOS POR TIPO DE EQUIPO AL " & Mes(cFecha)
                    newrptRepsaldo2.SummaryInfo.ReportComments = "TIPO DE EQUIPO"
                Case Is = 2
                    newrptRepsaldo2.SummaryInfo.ReportTitle = "REPORTE DE SALDOS INSOLUTOS POR RANGO DE MONTO AL " & Mes(cFecha)
                    newrptRepsaldo2.SummaryInfo.ReportComments = "LIMITE SUPERIOR"
            End Select

            CrystalReportViewer1.ReportSource = newrptRepsaldo2

        End If

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()
        cm3.Dispose()
        cm4.Dispose()
        cm5.Dispose()

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
        CrystalReportViewer1.Dispose()
    End Sub

End Class
