Option Explicit On

Imports System.Data.SqlClient
Imports System.Math
Imports System.IO
Imports System.Text.ASCIIEncoding

Public Class frmAplicacion

    ' Declaración de variables de conexión ADO .NET de alcance privado

    Dim dtPagados As New DataTable
    Dim dtDetalleFINAGIL As New DataTable
    Dim drDetalleFINAGIL As DataRow
    Dim drSerie As DataRow

    ' Declaración de variables de alcance privado

    Dim cAnexo As String = ""
    Dim cCiclo As String = ""
    Dim cCliente As String = ""
    Dim cFecha As String = ""
    Dim cFechaFinal As String = ""
    Dim cFechaInicial As String = ""
    Dim cNombreProductor As String = ""
    Dim cTipar As String = ""
    Dim nCapital As Decimal = 0
    Dim nConsecutivo As Integer = 0
    Dim nConsecutivoSerie As Integer = 0
    Dim nDias As Integer = 0
    Dim nFEGA As Decimal = 0
    Dim nGarantia As Decimal = 0
    Dim nIntereses As Decimal = 0
    Dim nMontoTotal As Decimal = 0
    Dim nSaldoFinal As Decimal = 0
    Dim nSaldoInicial As Decimal = 0
    Dim nSumaIntereses As Decimal = 0
    Dim nTasaBP As Decimal = 0

    Private Sub frmAplicacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daDeudores As New SqlDataAdapter(cm1)

        Dim dsAgil As New DataSet
        Dim dtDeudores As New DataTable
        Dim myColArray(1) As DataColumn

        Dim i As Byte = 0

        ToolStripStatusLabel1.Text = "Fecha de Aplicación " & Now().ToShortDateString

        ' En primer lugar creo la estructura de la tabla dtDetalleFINAGIL

        dtDetalleFINAGIL.Columns.Add("Anexo", Type.GetType("System.String"))
        dtDetalleFINAGIL.Columns.Add("Ciclo", Type.GetType("System.String"))
        dtDetalleFINAGIL.Columns.Add("Cliente", Type.GetType("System.String"))
        dtDetalleFINAGIL.Columns.Add("Consecutivo", Type.GetType("System.Decimal"))
        dtDetalleFINAGIL.Columns.Add("FechaInicial", Type.GetType("System.String"))
        dtDetalleFINAGIL.Columns.Add("FechaFinal", Type.GetType("System.String"))
        dtDetalleFINAGIL.Columns.Add("Dias", Type.GetType("System.Decimal"))
        dtDetalleFINAGIL.Columns.Add("TasaBP", Type.GetType("System.Decimal"))
        dtDetalleFINAGIL.Columns.Add("SaldoInicial", Type.GetType("System.Decimal"))
        dtDetalleFINAGIL.Columns.Add("SaldoFinal", Type.GetType("System.Decimal"))
        dtDetalleFINAGIL.Columns.Add("Concepto", Type.GetType("System.String"))
        dtDetalleFINAGIL.Columns.Add("Importe", Type.GetType("System.Decimal"))
        dtDetalleFINAGIL.Columns.Add("FEGA", Type.GetType("System.Decimal"))
        dtDetalleFINAGIL.Columns.Add("Garantia", Type.GetType("System.Decimal"))
        dtDetalleFINAGIL.Columns.Add("Intereses", Type.GetType("System.Decimal"))
        dtDetalleFINAGIL.Columns.Add("Tipar", Type.GetType("System.String"))

        ' El siguiente Stored Procedure trae los datos del contrato de Habilitación o Avío

        With cm1
            .CommandType = CommandType.Text
            .CommandText = "SELECT * " & _
                           "FROM Vw_AdeudosAvio " & _
                           "ORDER BY Productor, Contrato, [Ciclo o Pagaré]"
            .Connection = cnAgil
        End With

        ' Llenar el dataset lo cual abre y cierra la conexión

        daDeudores.Fill(dsAgil, "Deudores")

        ' Primero creo la tabla dtDeudores y le defino una llave primaria para que siempre esté ordenada y para poder localizar un
        ' contrato en particular

        dtDeudores = dsAgil.Tables("Deudores")
        myColArray(0) = dtDeudores.Columns("Descr")
        dtDeudores.PrimaryKey = myColArray

        dgvDeudores.DataSource = dtDeudores
        dgvDeudores.Columns(0).Width = 500
        dgvDeudores.Columns(1).Width = 80
        dgvDeudores.Columns(2).Width = 100
        dgvDeudores.Columns(3).Width = 80

        For i = 0 To dgvDeudores.Columns.Count - 1
            dgvDeudores.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            If i = 1 Then
                dgvDeudores.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alinea el encabezado
                dgvDeudores.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alinea el contenido
            End If
            If i = 3 Then
                dgvDeudores.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight ' Alinea el encabezado
                dgvDeudores.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alinea el contenido
                dgvDeudores.Columns(i).DefaultCellStyle.Format = "##,##0.00"
            End If
        Next
        dgvDeudores.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        ' Ahora creo la tabla dtPagados

        dtPagados.Columns.Add("Productor", Type.GetType("System.String"))
        dtPagados.Columns.Add("Contrato", Type.GetType("System.String"))
        dtPagados.Columns.Add("Ciclo", Type.GetType("System.String"))
        dtPagados.Columns.Add("TipoPago", Type.GetType("System.String"))
        dtPagados.Columns.Add("Fecha", Type.GetType("System.String"))
        dtPagados.Columns.Add("Capital", Type.GetType("System.String"))
        dtPagados.Columns.Add("FEGA", Type.GetType("System.String"))
        dtPagados.Columns.Add("Intereses", Type.GetType("System.String"))
        dtPagados.Columns.Add("Total", Type.GetType("System.String"))

        dgvPagados.DataSource = dtPagados
        dgvPagados.Columns(0).Width = 420
        dgvPagados.Columns(1).Width = 80
        dgvPagados.Columns(2).Width = 70
        dgvPagados.Columns(3).Width = 70
        dgvPagados.Columns(4).Width = 80
        dgvPagados.Columns(5).Width = 80
        dgvPagados.Columns(6).Width = 80
        dgvPagados.Columns(7).Width = 80

        For i = 0 To dgvPagados.Columns.Count - 1
            dgvPagados.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            If i = 1 Or i = 2 Or i = 3 Then
                dgvPagados.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alinea el encabezado
                dgvPagados.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alinea el contenido
            End If
            If i > 3 Then
                dgvPagados.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight ' Alinea el encabezado
                dgvPagados.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alinea el contenido
            End If
        Next

        cm1.Dispose()

    End Sub

    Private Sub dgvDeudores_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvDeudores.CellMouseClick

        btnCalcularIntereses.Enabled = True

    End Sub

    Private Sub btnCalcularIntereses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalcularIntereses.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daDetalle As New SqlDataAdapter(cm1)

        Dim dsAgil As New DataSet
        Dim drDetalle As DataRow
        Dim dtTIIE As New DataTable
        Dim drTIIE As DataRow

        Dim myKeySearch(0) As String

        ' Declaración de variables de datos

        Dim cFechaTerminacion As String = ""
        Dim cTipta As String = ""
        Dim cUltimoCorte As String = ""
        Dim nDiferencial As Decimal = 0
        Dim nTasa As Decimal = 0

        cFecha = DTOC(dtpProceso.Value)

        cNombreProductor = dgvDeudores.CurrentRow.Cells(0).Value
        cAnexo = Mid(dgvDeudores.CurrentRow.Cells(1).Value, 1, 5) + Mid(dgvDeudores.CurrentRow.Cells(1).Value, 7, 4)
        cTipar = Mid(dgvDeudores.CurrentRow.Cells(2).Value, 1, 4)
        If cTipar = "Paga" Then
            cTipar = "C"
            cCiclo = Mid(dgvDeudores.CurrentRow.Cells(2).Value, 8, 2)
        Else
            cTipar = "H"
            cCiclo = Mid(dgvDeudores.CurrentRow.Cells(2).Value, 1, 2)
        End If
        nCapital = dgvDeudores.CurrentRow.Cells(3).Value

        ' Genero la tabla que contiene las TIIE promedio por mes.   Para FINAGIL considera todos los días del mes y redondea a 4 decimales

        dtTIIE = TIIEavg("FINAGIL")

        ' Tengo que copiar los movimientos que existan físicamente en DetalleFINAGIL en una tabla temporal para poder calcular el registro de intereses ordinarios
        ' (si procedieran) sin necesidad de insertar un registro en la tabla física

        ' El siguiente Command trae los movimientos que existan en DetalleFINAGIL del contrato seleccionado

        With cm1
            .CommandType = CommandType.Text
            .CommandText = "SELECT DetalleFINAGIL.*, Tipta, Tasas, DiferencialFINAGIL, UltimoCorte, FechaTerminacion FROM DetalleFINAGIL " & _
                           "INNER JOIN Avios ON DetalleFINAGIL.Anexo = Avios.Anexo AND DetalleFINAGIL.Ciclo = Avios.Ciclo " & _
                           "WHERE DetalleFINAGIL.Anexo = '" & cAnexo & "' AND DetalleFINAGIL.Ciclo = '" & cCiclo & "' " & _
                           "ORDER BY Consecutivo"
            .Connection = cnAgil
        End With

        ' Llenar el DataSet lo cual abre y cierra la conexión

        daDetalle.Fill(dsAgil, "Detalle")

        For Each drDetalle In dsAgil.Tables("Detalle").Rows

            nTasa = drDetalle("Tasas")
            nDiferencial = drDetalle("DiferencialFINAGIL")
            cTipta = drDetalle("Tipta")
            cUltimoCorte = drDetalle("UltimoCorte")
            cFechaTerminacion = drDetalle("FechaTerminacion")

            cCliente = drDetalle("Cliente")
            nConsecutivo = drDetalle("Consecutivo")
            cFechaInicial = drDetalle("FechaFinal")
            nSaldoInicial = drDetalle("SaldoFinal")

        Next

        If cFecha < cFechaInicial Then

            ' Se desea obtener el Estado de Cuenta a una fecha anterior al último movimiento registrado
            ' lo cual no es posible.   Lo que hace el sistema es cambiar la fecha de cálculo a la fecha
            ' del último movimiento registrado

            cFecha = cFechaInicial

        End If

        nConsecutivo += 1

        If cTipta = "7" Then

            nTasaBP = Round(nTasa + nDiferencial, 4)

        Else

            ' Construyo una fecha que me permita buscar el promedio de la tasa TIIE del mes inmediato anterior

            myKeySearch(0) = Mid(DTOC(DateAdd(DateInterval.Month, -1, CTOD(cFecha))), 1, 6)

            drTIIE = dtTIIE.Rows.Find(myKeySearch)

            If drTIIE Is Nothing Then
                nTasaBP = 0
            Else
                nTasaBP = drTIIE("Promedio")
            End If

            nTasaBP = Round(nTasaBP + nDiferencial, 4)

        End If

        If cFecha > cFechaTerminacion Then
            nTasaBP = Round(nTasaBP * 3, 4)
        End If

        nDias = DateDiff(DateInterval.Day, CTOD(cFechaInicial), CTOD(cFecha))

        drDetalle = dsAgil.Tables("Detalle").NewRow
        drDetalle("Anexo") = cAnexo
        drDetalle("Ciclo") = cCiclo
        drDetalle("Cliente") = cCliente
        drDetalle("Consecutivo") = nConsecutivo
        drDetalle("FechaInicial") = cFechaInicial
        drDetalle("FechaFinal") = cFecha
        drDetalle("Dias") = nDias
        drDetalle("TasaBP") = nTasaBP
        drDetalle("SaldoInicial") = nSaldoInicial
        drDetalle("SaldoFinal") = nSaldoFinal
        drDetalle("Concepto") = "INTERESES"
        drDetalle("Importe") = 0
        drDetalle("FEGA") = 0
        drDetalle("Garantia") = 0
        drDetalle("Intereses") = 0
        dsAgil.Tables("Detalle").Rows.Add(drDetalle)

        ' Aquí calculo los intereses del registro que acabo de aumentar (la variable nSumaIntereses contiene la sumatoria de los intereses de los movimientos posteriores
        ' a la fecha de último corte hasta la fecha del pago)

        nSumaIntereses = 0
        nIntereses = 0

        For Each drDetalle In dsAgil.Tables("Detalle").Rows

            cFechaFinal = drDetalle("FechaFinal")
            If Mid(cFechaFinal, 1, 6) = Mid(cFecha, 1, 6) And cFechaFinal > cUltimoCorte Then
                nSaldoInicial = drDetalle("SaldoInicial")
                nTasaBP = drDetalle("TasaBP")
                nDias = drDetalle("Dias")
                nIntereses = Round(nSaldoInicial * nTasaBP / 36000 * nDias, 2)
                nSumaIntereses = Round(nSumaIntereses + nIntereses, 2)
            End If

            nConsecutivo = drDetalle("Consecutivo")

        Next

        nSaldoFinal = nSaldoInicial + nSumaIntereses

        drDetalle("Intereses") = nSumaIntereses
        drDetalle("SaldoFinal") = nSaldoFinal

        If drDetalle("SaldoInicial") = 0 And drDetalle("SaldoFinal") = 0 Then
            dsAgil.Tables("Detalle").Rows(nConsecutivo - 1).Delete()
            nConsecutivo = nConsecutivo - 1
        ElseIf drDetalle("Importe") = 0 And drDetalle("FEGA") = 0 And drDetalle("Garantia") = 0 And drDetalle("Intereses") = 0 Then
            dsAgil.Tables("Detalle").Rows(nConsecutivo - 1).Delete()
            nConsecutivo = nConsecutivo - 1
        End If

        nCapital = 0
        nFEGA = 0
        nGarantia = 0
        nIntereses = 0

        For Each drDetalle In dsAgil.Tables("Detalle").Rows
            nCapital += drDetalle("Importe")
            nFEGA += drDetalle("FEGA")
            nGarantia += drDetalle("Garantia")
            nIntereses += drDetalle("Intereses")
        Next

        rbTotal.Checked = False
        rbParcial.Checked = False
        btnAumentar.Enabled = False

        txtPagoTotal.Text = Format(nSaldoFinal - nGarantia, "##,##0.00")
        txtPagoParcial.Text = Format(0, "##,##0.00")
        btnCalcularIntereses.Enabled = False

        cm1.Dispose()

    End Sub

    Private Sub btnAumentar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAumentar.Click

        Dim cnAgil As New SqlConnection(strConn)
        Dim drPagado As DataRow
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim daBancos As New SqlDataAdapter(cm1)
        Dim daSeries As New SqlDataAdapter(cm2)
        Dim dsAgil As New DataSet()
        Dim dsBcos As New DataSet()

        Dim nPagoParcial As Decimal = 0
        Dim nVeces As Integer = 0

        cFecha = DTOC(dtpProceso.Value)

        ' Este registro lo tengo que insertar hasta que se elige Añadir a la lista (contiene los intereses de la fecha de último corte a la fecha de pago)

        If nSumaIntereses > 0 Then
            drDetalleFINAGIL = dtDetalleFINAGIL.NewRow
            drDetalleFINAGIL("Anexo") = cAnexo
            drDetalleFINAGIL("Ciclo") = cCiclo
            drDetalleFINAGIL("Cliente") = cCliente
            drDetalleFINAGIL("Consecutivo") = nConsecutivo
            drDetalleFINAGIL("FechaInicial") = cFechaInicial
            drDetalleFINAGIL("FechaFinal") = cFecha
            drDetalleFINAGIL("Dias") = nDias
            drDetalleFINAGIL("TasaBP") = nTasaBP
            drDetalleFINAGIL("SaldoInicial") = nSaldoInicial
            drDetalleFINAGIL("SaldoFinal") = nSaldoFinal
            drDetalleFINAGIL("Concepto") = "INTERESES"
            drDetalleFINAGIL("Importe") = 0
            drDetalleFINAGIL("FEGA") = 0
            drDetalleFINAGIL("Garantia") = 0
            drDetalleFINAGIL("Intereses") = nSumaIntereses
            drDetalleFINAGIL("Tipar") = cTipar
            dtDetalleFINAGIL.Rows.Add(drDetalleFINAGIL)
        End If

        If rbTotal.Checked = True Then

            drPagado = dtPagados.NewRow()
            drPagado("Productor") = Trim(cNombreProductor)
            drPagado("Contrato") = Mid(cAnexo, 1, 5) + "/" + Mid(cAnexo, 6, 4)
            drPagado("Ciclo") = cCiclo
            drPagado("TipoPago") = "TOTAL"
            drPagado("Fecha") = Mid(cFecha, 7, 2) + "/" + Mid(cFecha, 5, 2) + "/" + Mid(cFecha, 1, 4)
            drPagado("Capital") = Format(nCapital, "##,##0.00")
            drPagado("FEGA") = Format(nFEGA, "##,##0.00")
            drPagado("Intereses") = Format(nIntereses, "##,##0.00")
            drPagado("Total") = Format(nIntereses + nFEGA + nCapital, "##,##0.00")
            dtPagados.Rows.Add(drPagado)

            nMontoTotal += nIntereses + nFEGA + nCapital
            txtMontoTotal.Text = Format(nMontoTotal, "##,##0.00")

            ' Inserto el segundo registro con los importes pagados

            drDetalleFINAGIL = dtDetalleFINAGIL.NewRow
            drDetalleFINAGIL("Anexo") = cAnexo
            drDetalleFINAGIL("Ciclo") = cCiclo
            drDetalleFINAGIL("Cliente") = cCliente
            drDetalleFINAGIL("Consecutivo") = nConsecutivo + 1
            drDetalleFINAGIL("FechaInicial") = cFecha
            drDetalleFINAGIL("FechaFinal") = cFecha
            drDetalleFINAGIL("Dias") = 0
            drDetalleFINAGIL("TasaBP") = nTasaBP
            drDetalleFINAGIL("SaldoInicial") = nSaldoFinal
            drDetalleFINAGIL("SaldoFinal") = 0
            drDetalleFINAGIL("Concepto") = "PAGO"
            drDetalleFINAGIL("Importe") = -nCapital
            drDetalleFINAGIL("FEGA") = -nFEGA
            drDetalleFINAGIL("Garantia") = -nGarantia
            drDetalleFINAGIL("Intereses") = -nIntereses
            drDetalleFINAGIL("Tipar") = cTipar
            dtDetalleFINAGIL.Rows.Add(drDetalleFINAGIL)

        ElseIf rbParcial.Checked = True Then

            nPagoParcial = CDbl(txtPagoParcial.Text)

            ' Primero reviso si el pago parcial cubre o no el importe de los intereses

            If nPagoParcial > 0 And nPagoParcial >= nIntereses Then

                ' El pago cubre totalmente los intereses

                nPagoParcial = Round(nPagoParcial - nIntereses, 2)

            Else

                ' El pago cubre parcialmente los intereses

                nIntereses = nPagoParcial
                nGarantia = 0
                nFEGA = 0
                nCapital = 0
                nPagoParcial = 0

            End If

            ' Ahora reviso si el pago parcial cubre o no el importe de la Garantía FEGA

            If nPagoParcial > 0 And nPagoParcial >= nFEGA Then

                ' El pago parcial cubre totalmente la Garantía FEGA

                nPagoParcial = Round(nPagoParcial - nFEGA, 2)

            Else

                ' El pago cubre parcialmente la Garantía FEGA

                nGarantia = 0
                nFEGA = nPagoParcial
                nCapital = 0
                nPagoParcial = 0

            End If

            ' Por último reviso si el pago parcial cubre o no el importe del Capital

            If nPagoParcial > 0 Then

                If nPagoParcial >= nCapital Then

                    ' El pago cubre totalmente el Capital

                    nPagoParcial = Round(nPagoParcial - nCapital, 2)

                Else

                    ' El pago cubre parcialmente el Capital

                    nCapital = nPagoParcial
                    nPagoParcial = 0

                End If

            Else

                nCapital = 0

            End If

            If nCapital > 0 And nGarantia > 0 Then
                nGarantia = Round(nCapital * 0.1, 2)
            End If

            drPagado = dtPagados.NewRow()
            drPagado("Contrato") = Mid(cAnexo, 1, 5) + "/" + Mid(cAnexo, 6, 4)
            drPagado("Ciclo") = cCiclo
            drPagado("Productor") = Trim(cNombreProductor)
            drPagado("TipoPago") = "PARCIAL"
            drPagado("Fecha") = Mid(cFecha, 7, 2) + "/" + Mid(cFecha, 5, 2) + "/" + Mid(cFecha, 1, 4)
            drPagado("Capital") = Format(nCapital, "##,##0.00")
            drPagado("FEGA") = Format(nFEGA, "##,##0.00")
            drPagado("Intereses") = Format(nIntereses, "##,##0.00")
            drPagado("Total") = Format(nIntereses + nFEGA + nCapital, "##,##0.00")
            dtPagados.Rows.Add(drPagado)

            ' Inserto el segundo registro con los importes pagados

            drDetalleFINAGIL = dtDetalleFINAGIL.NewRow
            drDetalleFINAGIL("Anexo") = cAnexo
            drDetalleFINAGIL("Ciclo") = cCiclo
            drDetalleFINAGIL("Cliente") = cCliente
            drDetalleFINAGIL("Consecutivo") = nConsecutivo + 1
            drDetalleFINAGIL("FechaInicial") = cFecha
            drDetalleFINAGIL("FechaFinal") = cFecha
            drDetalleFINAGIL("Dias") = 0
            drDetalleFINAGIL("TasaBP") = nTasaBP
            drDetalleFINAGIL("SaldoInicial") = nSaldoFinal
            drDetalleFINAGIL("SaldoFinal") = nSaldoFinal - Round(nIntereses + nFEGA + nCapital + nGarantia, 2)
            drDetalleFINAGIL("Concepto") = "PAGO"
            drDetalleFINAGIL("Importe") = -nCapital
            drDetalleFINAGIL("FEGA") = -nFEGA
            drDetalleFINAGIL("Garantia") = -nGarantia
            drDetalleFINAGIL("Intereses") = -nIntereses
            drDetalleFINAGIL("Tipar") = cTipar
            dtDetalleFINAGIL.Rows.Add(drDetalleFINAGIL)

            txtPagoParcial.Text = Format(nCapital + nFEGA + nIntereses, "##,##0.00")
            nMontoTotal += nIntereses + nFEGA + nCapital
            txtMontoTotal.Text = Format(nMontoTotal, "##,##0.00")

        End If

        ' Quitar el contrato de Contratos con Adeudo

        dgvDeudores.Rows.Remove(dgvDeudores.CurrentRow)
        dgvDeudores.Update()

        If nVeces = 0 Then

            ' Este Stored Procedure regresa los datos de los Bancos

            With cm1
                .CommandType = CommandType.StoredProcedure
                .CommandText = "Bancos1"
                .Connection = cnAgil
            End With

            ' El siguiente Command trae los consecutivos de cada Serie

            With cm2
                .CommandType = CommandType.Text
                .CommandText = "SELECT IDSerieA, IDSerieMXL FROM Llaves"
                .Connection = cnAgil
            End With

            ' Llenar los dataset lo cual abre y cierra la conexión

            daBancos.Fill(dsBcos, "Bancos")
            daSeries.Fill(dsAgil, "Series")

            ' Lleno cbBancos con el nombre de los Bancos

            cbBancos.DataSource = dsBcos
            cbBancos.DisplayMember = "Bancos.DescBanco"
            cbBancos.ValueMember = "Bancos.Banco"

            cbBancos.SelectedIndex = 0

            ' Toma el número consecutivo de facturas de pago -que depende de la Serie- y lo incrementa en uno

            drSerie = dsAgil.Tables("Series").Rows(0)
            txtSerieA.Text = drSerie("IDSerieA").ToString
            txtSerieMXL.Text = drSerie("IDSerieMXL").ToString

            Label8.Visible = True
            rbSerieA.Visible = True
            txtSerieA.Visible = True
            rbSerieMXL.Visible = True
            txtSerieMXL.Visible = True

            nVeces = 1

        End If

        btnAumentar.Enabled = False

        cm1.Dispose()
        cm2.Dispose()

    End Sub

    Private Sub btnAplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAplicar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim daFactura As New SqlDataAdapter(cm2)
        Dim daGrupo As New SqlDataAdapter(cm3)

        Dim drConceptos As DataRow()
        Dim drFactura As DataRow
        Dim drMinistracion As DataRow
        Dim drMovimientos As DataRow
        Dim drPago As DataRow
        Dim dsFactura As New DataSet
        Dim dtMovimientos As New DataTable
        Dim relFacturas As DataRelation

        Dim strInsert As String
        Dim strUpdate As String

        ' Declaración de variables de datos

        Dim cBanco As String = ""
        Dim cCheque As String = ""
        Dim cCuentaPago As String = ""
        Dim cFechaPago As String = ""
        Dim cFormaPago As String = ""
        Dim cObserva As String = ""
        Dim cPagado As String = ""
        Dim cRenglon As String = ""
        Dim cRFC As String = ""
        Dim cSerie As String = ""
        Dim i As Integer = 0
        Dim nCapital As Decimal = 0
        Dim nConsecutivoIni As Integer = 0
        Dim nIVA As Decimal = 0
        Dim nMinistracion As Decimal = 0
        Dim nNumero As Integer = 0
        Dim nPos As Integer = 0
        Dim nSaldoGarantia As Decimal = 0
        Dim nSaldoMinistracion As Decimal = 0
        Dim nSubTotal As Decimal = 0

        Dim oFactura As StreamWriter

        nConsecutivoIni = Val(txtFactuPago.Text)
        cBanco = cbBancos.SelectedValue

        ' Tengo que procesar la tabla dtPagados y por cada registro voy a afectar las siguientes tablas: 
        ' DetalleFINAGIL
        ' Historia
        ' Hisgin

        ' Además tengo que generar el archivo TXT de la factura electrónica

        ' En primer lugar creo la tabla dtMovimientos

        dtMovimientos.Columns.Add("Anexo", Type.GetType("System.String"))
        dtMovimientos.Columns.Add("Letra", Type.GetType("System.String"))
        dtMovimientos.Columns.Add("Tipos", Type.GetType("System.String"))
        dtMovimientos.Columns.Add("Fepag", Type.GetType("System.String"))
        dtMovimientos.Columns.Add("Cve", Type.GetType("System.String"))
        dtMovimientos.Columns.Add("Imp", Type.GetType("System.Decimal"))
        dtMovimientos.Columns.Add("Tip", Type.GetType("System.String"))
        dtMovimientos.Columns.Add("Catal", Type.GetType("System.String"))
        dtMovimientos.Columns.Add("Esp", Type.GetType("System.Decimal"))
        dtMovimientos.Columns.Add("Coa", Type.GetType("System.String"))
        dtMovimientos.Columns.Add("Tipmon", Type.GetType("System.String"))
        dtMovimientos.Columns.Add("Banco", Type.GetType("System.String"))
        dtMovimientos.Columns.Add("Concepto", Type.GetType("System.String"))

        cnAgil.Open()

        ' Grabo físicamente en DetalleFINAGIL los 2 registros que generó -para cada contrato- la aplicación de pago 

        For Each drDetalleFINAGIL In dtDetalleFINAGIL.Rows
            strInsert = "INSERT INTO DetalleFINAGIL(Anexo, Ciclo, Cliente, Consecutivo, FechaInicial, FechaFinal, Dias, TasaBP, SaldoInicial, SaldoFinal, Concepto, Importe, FEGA, Garantia, Intereses)"
            strInsert = strInsert & " VALUES ('"
            strInsert = strInsert & drDetalleFINAGIL("Anexo") & "', '"
            strInsert = strInsert & drDetalleFINAGIL("Ciclo") & "', '"
            strInsert = strInsert & drDetalleFINAGIL("Cliente") & "', "
            strInsert = strInsert & drDetalleFINAGIL("Consecutivo") & ", '"
            strInsert = strInsert & drDetalleFINAGIL("FechaInicial") & "', '"
            strInsert = strInsert & drDetalleFINAGIL("FechaFinal") & "', "
            strInsert = strInsert & drDetalleFINAGIL("Dias") & ", "
            strInsert = strInsert & drDetalleFINAGIL("TasaBP") & ", "
            strInsert = strInsert & drDetalleFINAGIL("SaldoInicial") & ", "
            strInsert = strInsert & drDetalleFINAGIL("SaldoFinal") & ", '"
            strInsert = strInsert & drDetalleFINAGIL("Concepto") & "', "
            strInsert = strInsert & drDetalleFINAGIL("Importe") & ", "
            strInsert = strInsert & drDetalleFINAGIL("FEGA") & ", "
            strInsert = strInsert & drDetalleFINAGIL("Garantia") & ", "
            strInsert = strInsert & drDetalleFINAGIL("Intereses") & ")"
            cm1 = New SqlCommand(strInsert, cnAgil)
            cm1.ExecuteNonQuery()
        Next

        ' Grabo físicamente en Avios la fecha de último corte para cada contrato afectado

        For Each drDetalleFINAGIL In dtDetalleFINAGIL.Rows
            cAnexo = drDetalleFINAGIL("Anexo")
            cFecha = drDetalleFINAGIL("FechaFinal")
            strUpdate = "UPDATE Avios SET UltimoCorte = '" & cFecha & "' WHERE Anexo = '" & cAnexo & "' AND Ciclo = '" & cCiclo & "'"
            cm1 = New SqlCommand(strUpdate, cnAgil)
            cm1.ExecuteNonQuery()
        Next

        'Insertamos los Registros correspondientes en la Historia de Pagos

        For Each drDetalleFINAGIL In dtDetalleFINAGIL.Rows

            If drDetalleFINAGIL("Concepto") = "PAGO" Then

                cAnexo = drDetalleFINAGIL("Anexo")

                drMovimientos = dtMovimientos.NewRow()
                drMovimientos("Anexo") = cAnexo
                drMovimientos("Letra") = "001"
                drMovimientos("Tipos") = "2"
                drMovimientos("Fepag") = DTOC(Now())
                drMovimientos("Cve") = "99"
                drMovimientos("Imp") = (drDetalleFINAGIL("Importe") + drDetalleFINAGIL("FEGA") + drDetalleFINAGIL("Intereses")) * -1
                drMovimientos("Tip") = "S"
                drMovimientos("Catal") = drDetalleFINAGIL("Tipar")
                drMovimientos("Esp") = 0.0
                drMovimientos("Coa") = "0"
                drMovimientos("Tipmon") = "01"
                drMovimientos("Banco") = cBanco
                drMovimientos("Concepto") = txtCheque.Text
                dtMovimientos.Rows.Add(drMovimientos)

                If (drDetalleFINAGIL("Importe") + drDetalleFINAGIL("FEGA")) * -1 > 0 Then

                    strInsert = "INSERT INTO Historia(Documento, Serie, Numero, Fecha, Anexo, Letra, Importe, Banco, Cheque, Observa1, Balance)"
                    strInsert = strInsert & " VALUES ('"
                    strInsert = strInsert & "6" & "', '"
                    If rbSerieA.Checked = True Then
                        strInsert = strInsert & "A" & "', "
                    ElseIf rbSerieMXL.Checked = True Then
                        strInsert = strInsert & "MXL" & "', "
                    End If
                    strInsert = strInsert & nConsecutivoSerie & ", '"
                    strInsert = strInsert & DTOC(Now()) & "', '"
                    strInsert = strInsert & drDetalleFINAGIL("Anexo") & "', '"
                    strInsert = strInsert & "001" & "', "
                    strInsert = strInsert & (drDetalleFINAGIL("Importe") + drDetalleFINAGIL("FEGA")) * -1 & ", '"
                    strInsert = strInsert & cBanco & "', '"
                    strInsert = strInsert & txtCheque.Text & "', '"
                    strInsert = strInsert & "PAGO CREDITO DE AVIO" & "', '"
                    strInsert = strInsert & "N" & "') "
                    cm1 = New SqlCommand(strInsert, cnAgil)
                    cm1.ExecuteNonQuery()

                    drMovimientos = dtMovimientos.NewRow()
                    drMovimientos("Anexo") = cAnexo
                    drMovimientos("Letra") = "001"
                    drMovimientos("Tipos") = "2"
                    drMovimientos("Fepag") = DTOC(Now())
                    drMovimientos("Cve") = "65"
                    drMovimientos("Imp") = (drDetalleFINAGIL("Importe") + drDetalleFINAGIL("FEGA")) * -1
                    drMovimientos("Tip") = "S"
                    drMovimientos("Catal") = drDetalleFINAGIL("Tipar")
                    drMovimientos("Esp") = 0.0
                    drMovimientos("Coa") = "1"
                    drMovimientos("Tipmon") = "01"
                    drMovimientos("Banco") = cBanco
                    drMovimientos("Concepto") = ""
                    dtMovimientos.Rows.Add(drMovimientos)

                End If

                If (drDetalleFINAGIL("Garantia")) * -1 > 0 Then

                    drMovimientos = dtMovimientos.NewRow()
                    drMovimientos("Anexo") = cAnexo
                    drMovimientos("Letra") = "001"
                    drMovimientos("Tipos") = "2"
                    drMovimientos("Fepag") = DTOC(Now())
                    drMovimientos("Cve") = "55"
                    drMovimientos("Imp") = (drDetalleFINAGIL("Garantia")) * -1
                    drMovimientos("Tip") = "S"
                    drMovimientos("Catal") = drDetalleFINAGIL("Tipar")
                    drMovimientos("Esp") = 0.0
                    drMovimientos("Coa") = "1"
                    drMovimientos("Tipmon") = "01"
                    drMovimientos("Banco") = cBanco
                    drMovimientos("Concepto") = ""
                    dtMovimientos.Rows.Add(drMovimientos)

                    drMovimientos = dtMovimientos.NewRow()
                    drMovimientos("Anexo") = cAnexo
                    drMovimientos("Letra") = "001"
                    drMovimientos("Tipos") = "2"
                    drMovimientos("Fepag") = DTOC(Now())
                    drMovimientos("Cve") = "67"
                    drMovimientos("Imp") = (drDetalleFINAGIL("Garantia")) * -1
                    drMovimientos("Tip") = "S"
                    drMovimientos("Catal") = drDetalleFINAGIL("Tipar")
                    drMovimientos("Esp") = 0.0
                    drMovimientos("Coa") = "0"
                    drMovimientos("Tipmon") = "01"
                    drMovimientos("Banco") = cBanco
                    drMovimientos("Concepto") = ""
                    dtMovimientos.Rows.Add(drMovimientos)
                End If

                If drDetalleFINAGIL("Intereses") * -1 > 0 Then

                    strInsert = "INSERT INTO Historia(Documento, Serie, Numero, Fecha, Anexo, Letra, Importe, Banco, Cheque, Observa1, Balance)"
                    strInsert = strInsert & " VALUES ('"
                    strInsert = strInsert & "6" & "', '"
                    If rbSerieA.Checked = True Then
                        strInsert = strInsert & "A" & "', "
                    ElseIf rbSerieMXL.Checked = True Then
                        strInsert = strInsert & "MXL" & "', "
                    End If
                    strInsert = strInsert & nConsecutivoSerie & ", '"
                    strInsert = strInsert & DTOC(Now()) & "', '"
                    strInsert = strInsert & drDetalleFINAGIL("Anexo") & "', '"
                    strInsert = strInsert & "001" & "', "
                    strInsert = strInsert & drDetalleFINAGIL("Intereses") * -1 & ", '"
                    strInsert = strInsert & cBanco & "', '"
                    strInsert = strInsert & txtCheque.Text & "', '"
                    strInsert = strInsert & "INTERESES AVIO" & "', '"
                    strInsert = strInsert & "N" & "') "
                    cm1 = New SqlCommand(strInsert, cnAgil)
                    cm1.ExecuteNonQuery()

                    drMovimientos = dtMovimientos.NewRow()
                    drMovimientos("Anexo") = cAnexo
                    drMovimientos("Letra") = "001"
                    drMovimientos("Tipos") = "2"
                    drMovimientos("Fepag") = DTOC(Now())
                    drMovimientos("Cve") = "72"
                    drMovimientos("Imp") = drDetalleFINAGIL("Intereses") * -1
                    drMovimientos("Tip") = "S"
                    drMovimientos("Catal") = drDetalleFINAGIL("Tipar")
                    drMovimientos("Esp") = 0.0
                    drMovimientos("Coa") = "1"
                    drMovimientos("Tipmon") = "01"
                    drMovimientos("Banco") = cBanco
                    drMovimientos("Concepto") = ""
                    dtMovimientos.Rows.Add(drMovimientos)

                End If

                nConsecutivoSerie += 1

            End If

        Next

        'Almacenamos los Movimientos Contables

        For Each drMovimientos In dtMovimientos.Rows
            strInsert = "INSERT INTO Hisgin(Anexo, Letra, Tipos, Fepag, Cve, Imp, Tip, Catal, Esp, Coa, Tipmon, Banco, Concepto)"
            strInsert = strInsert & " VALUES ('"
            strInsert = strInsert & drMovimientos("Anexo") & "', '"
            strInsert = strInsert & drMovimientos("Letra") & "', '"
            strInsert = strInsert & drMovimientos("Tipos") & "', '"
            strInsert = strInsert & drMovimientos("Fepag") & "', '"
            strInsert = strInsert & drMovimientos("Cve") & "', "
            strInsert = strInsert & drMovimientos("Imp") & ", '"
            strInsert = strInsert & drMovimientos("Tip") & "', '"
            strInsert = strInsert & drMovimientos("Catal") & "', '"
            strInsert = strInsert & drMovimientos("Esp") & "', '"
            strInsert = strInsert & drMovimientos("Coa") & "', '"
            strInsert = strInsert & drMovimientos("Tipmon") & "', '"
            strInsert = strInsert & drMovimientos("Banco") & "', '"
            strInsert = strInsert & drMovimientos("Concepto") & "') "
            cm1 = New SqlCommand(strInsert, cnAgil)
            cm1.ExecuteNonQuery()
        Next

        ' Generación de la factura electrónica

        cFechaPago = DTOC(Now())

        With cm2
            .CommandType = CommandType.Text
            .CommandText = "SELECT Numero, Fecha, Importe, Observa1 FROM Historia " & _
                           "WHERE Numero >= " & nConsecutivoIni & " AND Numero <= " & nConsecutivoSerie & " AND Fecha = " & "'" & cFechaPago & "'"
            .Connection = cnAgil
        End With

        With cm3
            .CommandType = CommandType.Text
            .CommandText = "SELECT DISTINCT Historia.Serie, Numero, Fecha, Historia.Anexo, Letra, Cheque, Clientes.Cliente, Descr, Calle, " & _
                           " Colonia, Delegacion, Copos, Clientes.Plaza, RFC, DescPlaza, CuentadePago1, FormadePago1, CuentadePago2, " & _
                           " FormadePago2, CuentadePago3, FormadePago3, CuentadePago4, FormadePago4 FROM Historia" & _
                           " INNER JOIN Avios ON Historia.Anexo = Avios.Anexo" & _
                           " INNER JOIN Clientes ON Avios.Cliente = Clientes. Cliente" & _
                           " INNER JOIN Plazas ON Clientes.Plaza = Plazas.Plaza" & _
                           " WHERE Numero >= " & nConsecutivoIni & " AND Numero <= " & nConsecutivoSerie & " AND Fecha = " & "'" & cFechaPago & "'"
            .Connection = cnAgil
        End With

        ' Llenar el dataset lo cual abre y cierra la conexión

        daFactura.Fill(dsFactura, "Facturas")
        daGrupo.Fill(dsFactura, "Grupo")

        relFacturas = New DataRelation("GpoFacturas", dsFactura.Tables("Grupo").Columns("Numero"), dsFactura.Tables("Facturas").Columns("Numero"))
        dsFactura.EnforceConstraints = False
        dsFactura.Relations.Add(relFacturas)
        dsFactura.EnforceConstraints = True

        For Each drFactura In dsFactura.Tables("Grupo").Rows

            cSerie = Trim(drFactura("Serie"))
            cCheque = Trim(drFactura("Cheque"))
            cRFC = Trim(drFactura("RFC"))
            nNumero = drFactura("Numero")

            For i = 1 To 5
                Select Case i
                    Case 1
                        If RTrim(drFactura("CuentadePago1")) <> "0" And RTrim(drFactura("FormadePago1")) <> "EFECTIVO" Then
                            cCuentaPago = drFactura("CuentadePago1")
                            cFormaPago = RTrim(drFactura("FormadePago1"))
                        ElseIf RTrim(drFactura("CuentadePago1")) = "0" And RTrim(drFactura("FormadePago1")) = "EFECTIVO" Then
                            cCuentaPago = "NO IDENTIFICABLE"
                            cFormaPago = RTrim(drFactura("FormadePago1"))
                        End If
                    Case 2
                        If RTrim(drFactura("CuentadePago2")) <> "0" And RTrim(drFactura("FormadePago2")) <> "EFECTIVO" Then
                            cCuentaPago = cCuentaPago & "," & drFactura("CuentadePago2")
                            cFormaPago = cFormaPago & "," & RTrim(drFactura("FormadePago2"))
                        ElseIf RTrim(drFactura("CuentadePago2")) = "0" And RTrim(drFactura("FormadePago2")) = "EFECTIVO" Then
                            cCuentaPago = cCuentaPago & "," & "NO IDENTIFICABLE"
                            cFormaPago = cFormaPago & "," & RTrim(drFactura("FormadePago2"))
                        End If
                    Case 3
                        If RTrim(drFactura("CuentadePago3")) <> "0" And RTrim(drFactura("FormadePago3")) <> "EFECTIVO" Then
                            cCuentaPago = cCuentaPago & "," & drFactura("CuentadePago3")
                            cFormaPago = cFormaPago & "," & RTrim(drFactura("FormadePago3"))
                        ElseIf RTrim(drFactura("CuentadePago3")) = "0" And RTrim(drFactura("FormadePago3")) = "EFECTIVO" Then
                            cCuentaPago = cCuentaPago & "," & "NO IDENTIFICABLE"
                            cFormaPago = cFormaPago & "," & RTrim(drFactura("FormadePago3"))
                        End If
                    Case 4
                        If RTrim(drFactura("CuentadePago4")) <> "0" And RTrim(drFactura("FormadePago4")) <> "EFECTIVO" Then
                            cCuentaPago = cCuentaPago & "," & drFactura("CuentadePago4")
                            cFormaPago = cFormaPago & "," & RTrim(drFactura("FormadePago4"))
                        ElseIf RTrim(drFactura("CuentadePago4")) = "0" And RTrim(drFactura("FormadePago4")) = "EFECTIVO" Then
                            cCuentaPago = cCuentaPago & "," & "NO IDENTIFICABLE"
                            cFormaPago = cFormaPago & "," & RTrim(drFactura("FormadePago4"))
                        End If
                    Case 5
                        If cCuentaPago = "" And cFormaPago = "" Then
                            cCuentaPago = "NO IDENTIFICABLE"
                            cFormaPago = "NO IDENTIFICABLE"
                        End If
                End Select
            Next

            Dim stmFactura As New FileStream("C:\Facturas\FACTURA_" & cSerie & "_" & nNumero.ToString & ".txt", FileMode.Create, FileAccess.Write, FileShare.None)
            Dim stmWriter As New StreamWriter(stmFactura, System.Text.Encoding.Default)

            cRenglon = "H3|" & drFactura("Cliente") & "|" & Mid(drFactura("Anexo"), 1, 5) & "/" & Mid(drFactura("Anexo"), 6, 4) & "|" & cSerie & "|" & nNumero & "|" & Trim(drFactura("Descr")) & "|" & _
            Trim(drFactura("Calle")) & "|||" & Trim(drFactura("Colonia")) & "|" & Trim(drFactura("Delegacion")) & "|" & Trim(drFactura("DescPlaza")) & "|" & drFactura("Copos") & "|" & cCuentaPago & "|" & cFormaPago & "|MEXICO|" & Trim(drFactura("RFC")) & "|M.N.|" & _
            "|FACTURA|" & drFactura("Cliente") & "|LEANDRO VALLE 402||REFORMA Y FFCCNN|TOLUCA|ESTADO DE MEXICO|50070|MEXICO"
            stmWriter.WriteLine(cRenglon)

            drConceptos = drFactura.GetChildRows("GpoFacturas")

            nIVA = 0
            nSubTotal = 0

            For Each drMovimientos In drConceptos

                If nNumero = drMovimientos("Numero") Then

                    cObserva = drMovimientos("Observa1")

                    cRenglon = "D1|" & drFactura("Cliente") & "|" & Mid(drFactura("Anexo"), 1, 5) & "/" & Mid(drFactura("Anexo"), 6, 4) & "|" & cSerie & "|" & drFactura("Numero") & "|1|||" & Trim(cObserva) & "||" & drMovimientos("Importe")

                    cRenglon = cRenglon.Replace("Ñ", Chr(165))
                    cRenglon = cRenglon.Replace("ñ", Chr(164))
                    cRenglon = cRenglon.Replace("á", Chr(160))
                    cRenglon = cRenglon.Replace("é", Chr(130))
                    cRenglon = cRenglon.Replace("í", Chr(161))
                    cRenglon = cRenglon.Replace("ó", Chr(162))
                    cRenglon = cRenglon.Replace("ú", Chr(163))
                    cRenglon = cRenglon.Replace("Á", Chr(181))
                    cRenglon = cRenglon.Replace("É", Chr(144))
                    cRenglon = cRenglon.Replace("Ó", Chr(224))
                    cRenglon = cRenglon.Replace("Ú", Chr(233))
                    cRenglon = cRenglon.Replace("°", Chr(167))
                    stmWriter.WriteLine(cRenglon)

                    If BuscarTexto(cObserva, "IVA") = True Then
                        nIVA += drMovimientos("Importe")
                    Else
                        nSubTotal += drMovimientos("Importe")
                    End If

                End If

            Next

            If nIVA = 0 Then
                cRenglon = "S1|" & drFactura("Cliente") & "|" & Mid(drFactura("Anexo"), 1, 5) & "/" & Mid(drFactura("Anexo"), 6, 4) & "|" & cSerie & "|" & nNumero.ToString & "|" & nSubTotal & "|" & nIVA & "|" & nSubTotal + nIVA & "|" & Letras((nSubTotal + nIVA).ToString) & "|||0"
            Else
                cRenglon = "S1|" & drFactura("Cliente") & "|" & Mid(drFactura("Anexo"), 1, 5) & "/" & Mid(drFactura("Anexo"), 6, 4) & "|" & cSerie & "|" & nNumero.ToString & "|" & nSubTotal & "|" & nIVA & "|" & nSubTotal + nIVA & "|" & Letras((nSubTotal + nIVA).ToString) & "|||16"
            End If
            stmWriter.WriteLine(cRenglon)
            cRenglon = "Z1|" & drFactura("Cliente") & "|" & Mid(drFactura("Anexo"), 1, 5) & "/" & Mid(drFactura("Anexo"), 6, 4) & "|" & cSerie & "|" & nNumero.ToString & "|" & cCheque & "|" & Trim(cRFC) & "|"
            stmWriter.WriteLine(cRenglon)

            stmWriter.Flush()
            stmFactura.Flush()
            stmFactura.Close()

        Next

        ' Debe actualizar el atributo IDSerieA ó el atributo IDSerieMXL de la tabla Llaves

        If cSerie = "A" Then
            strUpdate = "UPDATE Llaves SET IDSerieA = " & nNumero
        ElseIf cSerie = "MXL" Then
            strUpdate = "UPDATE Llaves SET IDSerieMXL = " & nNumero
        End If
        cm1 = New SqlCommand(strUpdate, cnAgil)
        cm1.ExecuteNonQuery()

        MsgBox("Proceso Completo", MsgBoxStyle.Information)

        cnAgil.Close()
        cm1.Dispose()
        cm2.Dispose()
        cm3.Dispose()

        Me.Close()

    End Sub

    Private Sub rbSerieA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSerieA.CheckedChanged

        nConsecutivoSerie = drSerie("IDSerieA")
        nConsecutivoSerie = nConsecutivoSerie + 1

        Label7.Visible = True
        txtCheque.Visible = True
        Label6.Visible = True
        cbBancos.Visible = True
        txtFactuPago.Text = nConsecutivoSerie
        Label5.Visible = True
        txtFactuPago.Visible = True
        txtFactuPago.ReadOnly = True
        btnAplicar.Visible = True

    End Sub

    Private Sub rbSerieMXL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSerieMXL.CheckedChanged
        nConsecutivoSerie = drSerie("IDSerieMXL")
        nConsecutivoSerie = nConsecutivoSerie + 1

        Label7.Visible = True
        txtCheque.Visible = True
        Label6.Visible = True
        cbBancos.Visible = True
        txtFactuPago.Text = nConsecutivoSerie
        Label5.Visible = True
        txtFactuPago.Text = nConsecutivoSerie
        Label5.Visible = True
        txtFactuPago.Visible = True
        btnAplicar.Visible = True

    End Sub

    Function BuscarTexto(ByVal Texto As String, ByVal Busca As String) As Boolean
        Dim i As Integer
        i = InStr(1, Texto, Busca)
        If i > 0 Then
            BuscarTexto = True
        Else
            BuscarTexto = False
        End If
    End Function

    Private Sub rbTotal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTotal.CheckedChanged
        btnAumentar.Enabled = True
    End Sub

    Private Sub rbParcial_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbParcial.CheckedChanged
        btnAumentar.Enabled = True
    End Sub

End Class