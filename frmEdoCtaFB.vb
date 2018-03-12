Option Explicit On

Imports System.Data.SqlClient
Imports System.Math

Public Class frmEdoCtaFB

    ' Declaración de variables de datos de alcance privado

    Dim cIDCredito As String = ""
    Dim cFechaProceso As String = ""

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click

        Dim cAcreditado As String = ""

        cIDCredito = Trim(txtIDCredito.Text)
        cFechaProceso = DTOC(dtpProceso.Value)

        If rbPorCredito.Checked = True And cIDCredito = "" Then
            MsgBox("Necesitas especificar el ID del Crédito a consultar", MsgBoxStyle.Critical, "Información del Sistema")
        ElseIf rbPorAcreditado.Checked = True And cAcreditado = "" Then
            MsgBox("Necesitas especificar el nombre del Acreditado")
        ElseIf rbPasivoTotal.Checked = True Then

            ' Tendría que validar que exista por lo menos un Crédito con saldo

            TotalPasivo()

        ElseIf rbPorCredito.Checked = True And cIDCredito <> "" Then
            ValidaCredito(cIDCredito, cFechaProceso)
        ElseIf rbPorAcreditado.Checked = True And cAcreditado <> "" Then
            ' ValidaAcreditado()
        End If
        ' PorAcreditado()

    End Sub

    Private Sub ValidaCredito(ByVal cIDCredito As String, ByVal cFechaProceso As String)

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daCreditos As New SqlDataAdapter(cm1)

        Dim dsAgil As New DataSet()

        ' Declaración de variables de datos

        Dim cAcreditado As String = ""

        ' Lo primero que tengo que validar es que el IDCredito exista

        With cm1
            .CommandType = CommandType.Text
            .CommandText = "SELECT DISTINCT IDCredito, RTRIM(Descr) AS Acreditado FROM PasivoFIRA " & _
                           "INNER JOIN Clientes ON PasivoFIRA.Cliente = Clientes.Cliente " & _
                           "WHERE IDCredito = '" & cIDCredito & "'"
            .Connection = cnAgil
        End With

        ' El Crédito puede existir pero pudiera no tener movimientos

        ' Llenar el dataset lo cual abre y cierra la conexión

        daCreditos.Fill(dsAgil, "Creditos")

        If dsAgil.Tables("Creditos").Rows.Count = 0 Then
            MsgBox("No existe ningún Crédito con ese ID", MsgBoxStyle.Critical, "Mensaje del Sistema")
        Else
            cAcreditado = dsAgil.Tables("Creditos").Rows(0)("Acreditado")
            PorCredito(cIDCredito, cFechaProceso, cAcreditado)
        End If

        cm1.Dispose()
        cnAgil.Dispose()

    End Sub

    Private Sub PorCredito(ByVal cIDCredito As String, ByVal cFechaProceso As String, ByVal cAcreditado As String)

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim daCreditos As New SqlDataAdapter(cm1)
        Dim daMovimientos As New SqlDataAdapter(cm2)

        Dim dsAgil As New DataSet()
        Dim dtDetalle As New DataTable()
        Dim dtSaldos As New DataTable("Saldos")
        Dim dtTIIE As New DataTable()
        Dim drCredito As DataRow
        Dim drSaldo As DataRow
        Dim drTIIE As DataRow
        Dim drMovimiento As DataRow
        Dim drTemporal As DataRow
        Dim myKeySearch(0) As String

        ' Declaración de variables de Crystal Reports

        Dim newrptPorCredito As New rptPorCredito
        Dim cReportTitle As String = "ESTADO DE CUENTA DEL PASIVO CON FIRA"

        ' Declaración de variables de datos

        Dim cFechaFinal As String = ""
        Dim cFechaInicial As String = ""
        Dim cTipta As String = ""
        Dim cUltimoCorte As String = ""
        Dim dFechaFinal As Date
        Dim dFechaInicial As Date
        Dim nCapital As Decimal = 0
        Dim nDiasInteres As Integer = 0
        Dim nDiferencialBP As Decimal = 0
        Dim nDiferencialFB As Decimal = 0
        Dim nFIFAP As Decimal = 0
        Dim nFinanciados As Decimal = 0
        Dim nIntereses As Decimal = 0
        Dim nInteresesFinanciados As Decimal = 0
        Dim nInteresesOrdinarios As Decimal = 0
        Dim nMinistracionBase As Decimal = 0
        Dim nSaldoCapital As Decimal = 0
        Dim nSaldoFinal As Decimal = 0
        Dim nSaldoFinanciados As Decimal = 0
        Dim nSaldoInicial As Decimal = 0
        Dim nSaldoIntereses As Decimal = 0
        Dim nTasaBP As Decimal = 0
        Dim nTasaFB As Decimal = 0
        Dim nTIIE As Decimal = 0

        ' Ya que sé que el Crédito existe, creo la tabla dtDetalle para guardar la información resultante, recordando que
        ' el último registro es virtual (no debe afectar la tabla DetalleFIRA).

        dtDetalle.Columns.Add("IDCredito", Type.GetType("System.String"))
        dtDetalle.Columns.Add("FechaInicial", Type.GetType("System.String"))
        dtDetalle.Columns.Add("FechaFinal", Type.GetType("System.String"))
        dtDetalle.Columns.Add("TasaFB", Type.GetType("System.Decimal"))
        dtDetalle.Columns.Add("TasaBP", Type.GetType("System.Decimal"))
        dtDetalle.Columns.Add("SaldoInicial", Type.GetType("System.Decimal"))
        dtDetalle.Columns.Add("SaldoFinal", Type.GetType("System.Decimal"))
        dtDetalle.Columns.Add("MinistracionBase", Type.GetType("System.Decimal"))
        dtDetalle.Columns.Add("InteresesFinanciados", Type.GetType("System.Decimal"))
        dtDetalle.Columns.Add("InteresesOrdinarios", Type.GetType("System.Decimal"))
        dtDetalle.Columns.Add("Capital", Type.GetType("System.Decimal"))
        dtDetalle.Columns.Add("Financiados", Type.GetType("System.Decimal"))
        dtDetalle.Columns.Add("Intereses", Type.GetType("System.Decimal"))

        ' Además, creo una tabla para guardar los saldos vigentes

        dtSaldos.Columns.Add("Capital", Type.GetType("System.Decimal"))
        dtSaldos.Columns.Add("Financiados", Type.GetType("System.Decimal"))
        dtSaldos.Columns.Add("Intereses", Type.GetType("System.Decimal"))

        ' Traigo los datos generales del crédito de la tabla PasivoFIRA

        With cm1
            .CommandType = CommandType.Text
            .CommandText = "SELECT DISTINCT IDCredito, PasivoFIRA.Anexo, Tipta, TasaFB, DiferencialFB, TasaBP, DiferencialBP, FIFAP, RTRIM(Descr) AS Acreditado, UltimoCorte FROM PasivoFIRA " & _
                           "INNER JOIN Clientes ON PasivoFIRA.Cliente = Clientes.Cliente " & _
                           "WHERE IDCredito = '" & cIDCredito & "'"
            .Connection = cnAgil
        End With

        ' Necesito traer todos los movimientos que existan en DetalleFIRA para este IDCredito

        With cm2
            .CommandType = CommandType.Text
            .CommandText = "SELECT * FROM DetalleFIRA " & _
                           "WHERE IDCredito = '" & cIDCredito & "' " & _
                           "ORDER BY FechaFinal, SaldoFinal"
            .Connection = cnAgil
        End With

        ' Llenar el dataset lo cual abre y cierra la conexión

        daCreditos.Fill(dsAgil, "Creditos")
        daMovimientos.Fill(dsAgil, "Movimientos")

        drCredito = dsAgil.Tables("Creditos").Rows(0)

        cTipta = drCredito("Tipta")
        cUltimoCorte = drCredito("UltimoCorte")
        nFIFAP = drCredito("FIFAP")

        If cTipta = "6" Then

            ' Genero la tabla que contiene las TIIE promedio por mes 
            ' Para FIRA considera los días en que BANXICO publica el valor de la TIIE y redondea a 4 decimales

            dtTIIE = TIIEavg("FIRA")

            ' Construyo una fecha que me permita buscar el promedio de la tasa TIIE del mes inmediato anterior

            myKeySearch(0) = Mid(DTOC(DateAdd(DateInterval.Month, -1, CTOD(cFechaProceso))), 1, 6)

            drTIIE = dtTIIE.Rows.Find(myKeySearch)

            If drTIIE Is Nothing Then
                nTIIE = 0
            Else
                nTIIE = drTIIE("Promedio")
            End If

            nDiferencialFB = drCredito("DiferencialFB")
            nDiferencialBP = drCredito("DiferencialBP")
            nTasaFB = nTIIE + nDiferencialFB
            nTasaBP = nTIIE + nDiferencialBP
            If nTasaFB < 0 Then
                nTasaFB = 0
            End If
            If nTasaBP < 0 Then
                nTasaBP = 0
            End If
        Else
            nDiferencialFB = 0
            nDiferencialBP = 0
            nTasaFB = drCredito("TasaFB")
            nTasaBP = drCredito("TasaBP")
        End If

        ' A la tasa FIRA-BANCA tenemos que sumarle el monto del FIFAP mutual independientemente del tipo de tasa

        nTasaFB = nTasaFB + nFIFAP

        For Each drMovimiento In dsAgil.Tables("Movimientos").Rows

            cFechaInicial = drMovimiento("FechaInicial")
            cFechaFinal = drMovimiento("FechaFinal")

            ' Solamente procesaré los registros anteriores o iguales a la fecha de proceso. Esto con la finalidad
            ' de poder obtener un saldo a una fecha anterior a la de corte.

            If cFechaFinal <= cFechaProceso Then

                nMinistracionBase = drMovimiento("MinistracionBase")
                nInteresesFinanciados = drMovimiento("InteresesFinanciados")
                nInteresesOrdinarios = drMovimiento("InteresesOrdinarios")

                nCapital = drMovimiento("Capital")
                nFinanciados = drMovimiento("Financiados")
                nIntereses = drMovimiento("Intereses")

                nSaldoCapital = nSaldoCapital + nMinistracionBase - nCapital
                nSaldoFinanciados = nSaldoFinanciados + nInteresesFinanciados - nFinanciados
                nSaldoIntereses = nSaldoIntereses + nInteresesOrdinarios - nIntereses

                nSaldoInicial = drMovimiento("SaldoInicial")
                nSaldoFinal = drMovimiento("SaldoFinal")

            End If

        Next

        ' Solamente realizo cálculos si la fecha de proceso es mayor a la fecha de ultimo corte.
        ' Necesito tener cuidado que la fecha de proceso no exceda 1 mes o algo así

        If cFechaProceso > cUltimoCorte Then

            cFechaInicial = cFechaFinal
            cFechaFinal = cFechaProceso

            dFechaInicial = CTOD(cFechaInicial)
            dFechaFinal = CTOD(cFechaFinal)
            nSaldoInicial = nSaldoFinal
            nDiasInteres = DateDiff(DateInterval.Day, dFechaInicial, dFechaFinal)

            nInteresesOrdinarios = nSaldoInicial * (nTasaFB) / 36000 * nDiasInteres
            nInteresesOrdinarios = Round(nInteresesOrdinarios, 2)

            If nInteresesOrdinarios > 0 Then

                ' Esta validación se hace por si se emite el Estado de Cuenta el mismo día que se aplicó un pago,
                ' no aparezca un renglón en el que la fecha inicial y la fecha final son iguales,
                ' y el saldo inicial y final también son iguales.

                nSaldoFinal = nSaldoFinal + nInteresesOrdinarios

                drTemporal = dsAgil.Tables("Movimientos").NewRow
                drTemporal("IDCredito") = cIDCredito
                drTemporal("FechaInicial") = cFechaInicial
                drTemporal("FechaFinal") = cFechaFinal
                drTemporal("TasaFB") = nTasaFB
                drTemporal("TasaBP") = nTasaBP
                drTemporal("SaldoInicial") = nSaldoInicial
                drTemporal("SaldoFinal") = nSaldoFinal
                drTemporal("MinistracionBase") = 0
                drTemporal("InteresesFinanciados") = 0
                drTemporal("InteresesOrdinarios") = nInteresesOrdinarios
                drTemporal("Capital") = 0
                drTemporal("Financiados") = 0
                drTemporal("Intereses") = 0
                dsAgil.Tables("Movimientos").Rows.Add(drTemporal)

                nSaldoIntereses = nSaldoIntereses + nInteresesOrdinarios

            End If

        End If

        drSaldo = dtSaldos.NewRow
        drSaldo("Capital") = nSaldoCapital
        drSaldo("Financiados") = nSaldoFinanciados
        drSaldo("Intereses") = nSaldoIntereses
        dtSaldos.Rows.Add(drSaldo)

        dsAgil.Tables.Add(dtSaldos)

        ' Descomentar la siguiente línea en caso de que desee modificarse el reporte rptPorCredito
        dsAgil.WriteXml("C:\xmlPorCredito.xml", XmlWriteMode.WriteSchema)

        If Val(Mid(cFechaProceso, 7, 2)) < 10 Then
            cReportTitle = cReportTitle & " AL " + Mid(Mes(cFechaProceso), 2, Len(Mes(cFechaProceso)))
        Else
            cReportTitle = cReportTitle & " AL " + Mes(cFechaProceso)
        End If

        newrptPorCredito.SummaryInfo.ReportTitle = cReportTitle
        newrptPorCredito.SetDataSource(dsAgil)
        CrystalReportViewer1.ReportSource = newrptPorCredito

    End Sub

    Private Sub TotalPasivo()

        ' Declaración de variables de conexión ADO .NET

        Dim dsAgil As New DataSet()

        ' Declaración de variables de Crystal Reports

        Dim newrptTotalPasivo As New rptTotalPasivo
        Dim cReportTitle As String = "ESTADO DE CUENTA DEL PASIVO CON FIRA"

        ' Declaración de variables de datos

        Dim cFechaProceso As String = ""

        cFechaProceso = DTOC(dtpProceso.Value)

        dsAgil.Tables.Add(EdoCtaFB(cFechaProceso))

        If Val(Mid(cFechaProceso, 7, 2)) < 10 Then
            cReportTitle = cReportTitle & " AL " + Mid(Mes(cFechaProceso), 2, Len(Mes(cFechaProceso)))
        Else
            cReportTitle = cReportTitle & " AL " + Mes(cFechaProceso)
        End If

        newrptTotalPasivo.SummaryInfo.ReportTitle = cReportTitle

        newrptTotalPasivo.SetDataSource(dsAgil)
        CrystalReportViewer1.ReportSource = newrptTotalPasivo

    End Sub

    Private Sub rbPorCredito_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPorCredito.CheckedChanged

        If rbPorCredito.Checked = True Then

            ' Habilitar el cuadro de texto txtIDCredito para recibir información y mostrar el PanelProcesar

            txtIDCredito.ReadOnly = False
            PanelProcesar.Visible = True

        End If

    End Sub

    Private Sub rbPasivoTotal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPasivoTotal.CheckedChanged

        If rbPasivoTotal.Checked = True Then

            ' Ocultar el cuadro de texto txtIDCredito y su correspondiente etiqueta lblIDCredito

            lblIDCredito.Visible = False
            txtIDCredito.Visible = False

            ' Mostrar el panel Procesar donde aparecen la fecha de proceso y el botón Procesar

            PanelProcesar.Visible = True

        End If

    End Sub

End Class
