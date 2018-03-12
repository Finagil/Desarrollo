Option Explicit On

Imports System.Data.SqlClient
Imports System.Math

Public Class frmPagosBF

    ' Declaración de variables de conexión ADO .NET de alcance privado

    Dim dtPagados As New DataTable

    ' Declaración de variables de alcance privado

    Dim cAnexo As String = ""
    Dim cFechaInicial As String = 0
    Dim cFechaProceso As String = ""
    Dim cIDCredito As String = ""
    Dim cNombreAcreditado As String = ""
    Dim cTipoCredito As String = ""
    Dim nAdeudoTotal As Decimal = 0
    Dim nCapital As Decimal = 0
    Dim nFinanciados As Decimal = 0
    Dim nIntereses As Decimal = 0
    Dim nMontoTotal As Decimal = 0
    Dim nSaldoInicial As Decimal = 0
    Dim nTasaBP As Decimal = 0
    Dim nTasaFB As Decimal = 0

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)

        Dim dsAgil As New DataSet
        Dim myColArray(1) As DataColumn

        ' Declaración de variables de datos

        Dim i As Byte

        cFechaProceso = DTOC(dtpProceso.Value)

        ' La función EdoCtaFB me regresa una tabla con todos los clientes que tienen adeudo.

        dsAgil.Tables.Add(EdoCtaFB(cFechaProceso))

        ' Primero creo la tabla dtDeudores y le defino una llave primaria para que siempre esté ordenada y para poder localizar un
        ' contrato en particular

        'dtDeudores = dsAgil.Tables("Deudores")
        'myColArray(0) = dtDeudores.Columns("Descr")
        'dtDeudores.PrimaryKey = myColArray

        dgvDeudores.Visible = True

        dgvDeudores.DataSource = dsAgil.Tables(0)
        dgvDeudores.Columns(0).Width = 476
        dgvDeudores.Columns(1).Width = 60

        For i = 0 To dgvDeudores.Columns.Count - 1
            dgvDeudores.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            If i = 1 Then
                dgvDeudores.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alinea el encabezado
                dgvDeudores.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alinea el contenido
            End If
            If i > 1 Then
                dgvDeudores.Columns(i).Width = 100
                dgvDeudores.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight ' Alinea el encabezado
                dgvDeudores.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alinea el contenido
                dgvDeudores.Columns(i).DefaultCellStyle.Format = "##,##0.00"
            End If
        Next
        dgvDeudores.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        ' Ahora creo la tabla dtPagados

        dtPagados.Columns.Add("Acreditado", Type.GetType("System.String"))
        dtPagados.Columns.Add("TipoPago", Type.GetType("System.String"))
        dtPagados.Columns.Add("Fecha", Type.GetType("System.String"))
        dtPagados.Columns.Add("IDCredito", Type.GetType("System.String"))
        dtPagados.Columns.Add("Capital", Type.GetType("System.Decimal"))
        dtPagados.Columns.Add("Financiados", Type.GetType("System.Decimal"))
        dtPagados.Columns.Add("Intereses", Type.GetType("System.Decimal"))
        dtPagados.Columns.Add("MontoPagado", Type.GetType("System.Decimal"))
        dtPagados.Columns.Add("FechaInicial", Type.GetType("System.String"))
        dtPagados.Columns.Add("SaldoInicial", Type.GetType("System.Decimal"))
        dtPagados.Columns.Add("Anexo", Type.GetType("System.String"))
        dtPagados.Columns.Add("TasaFB", Type.GetType("System.Decimal"))
        dtPagados.Columns.Add("TasaBP", Type.GetType("System.Decimal"))
        dtPagados.Columns.Add("TipoCredito", Type.GetType("System.String"))

        dgvPagados.DataSource = dtPagados
        dgvPagados.Columns(0).Width = 356
        dgvPagados.Columns(1).Width = 50
        dgvPagados.Columns(2).Width = 70
        dgvPagados.Columns(3).Width = 60

        For i = 0 To dgvPagados.Columns.Count - 1
            dgvPagados.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            If i = 1 Or i = 2 Or i = 3 Then
                dgvPagados.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alinea el encabezado
                dgvPagados.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alinea el contenido
            End If
            If i > 3 Then
                dgvPagados.Columns(i).Width = 100
                dgvPagados.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight ' Alinea el encabezado
                dgvPagados.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alinea el contenido
            End If
        Next

        Panel1.Enabled = False

    End Sub

    Private Sub dgvDeudores_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvDeudores.CellMouseClick

        cNombreAcreditado = dgvDeudores.CurrentRow.Cells(0).Value
        cIDCredito = dgvDeudores.CurrentRow.Cells(1).Value
        nCapital = dgvDeudores.CurrentRow.Cells(2).Value
        nFinanciados = dgvDeudores.CurrentRow.Cells(3).Value
        nIntereses = dgvDeudores.CurrentRow.Cells(4).Value
        nAdeudoTotal = dgvDeudores.CurrentRow.Cells(5).Value
        cFechaInicial = dgvDeudores.CurrentRow.Cells(6).Value
        nSaldoInicial = dgvDeudores.CurrentRow.Cells(7).Value
        cAnexo = dgvDeudores.CurrentRow.Cells(8).Value
        nTasaFB = dgvDeudores.CurrentRow.Cells(9).Value
        nTasaBP = dgvDeudores.CurrentRow.Cells(10).Value
        cTipoCredito = dgvDeudores.CurrentRow.Cells(11).Value

        txtPagoTotal.Text = Format(nAdeudoTotal, "##,##0.00")
        txtPagoParcial.Text = ""

        Panel2.Visible = True
        rbTotal.Checked = False
        rbParcial.Checked = False
        btnAumentar.Enabled = False
        btnAumentar.Visible = True
        dgvPagados.Visible = True

    End Sub

    Private Sub btnAumentar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAumentar.Click

        ' Declaración de variables de datos

        Dim nPagoParcial As Decimal = 0

        Dim drPagado As DataRow

        btnAplicar.Visible = True

        If rbTotal.Checked = True Then

            drPagado = dtPagados.NewRow()
            drPagado("Acreditado") = Trim(cNombreAcreditado)
            drPagado("TipoPago") = "TOTAL"
            drPagado("Fecha") = Mid(cFechaProceso, 7, 2) + "/" + Mid(cFechaProceso, 5, 2) + "/" + Mid(cFechaProceso, 1, 4)
            drPagado("IDCredito") = cIDCredito
            drPagado("Capital") = Format(nCapital, "##,##0.00")
            drPagado("Financiados") = Format(nFinanciados, "##,##0.00")
            drPagado("Intereses") = Format(nIntereses, "##,##0.00")
            drPagado("MontoPagado") = Format(nAdeudoTotal, "##,##0.00")
            drPagado("FechaInicial") = cFechaInicial
            drPagado("SaldoInicial") = nSaldoInicial
            drPagado("Anexo") = cAnexo
            drPagado("TasaFB") = nTasaFB
            drPagado("TasaBP") = nTasaBP
            drPagado("TipoCredito") = cTipoCredito
            dtPagados.Rows.Add(drPagado)

            nMontoTotal += nAdeudoTotal
            txtMontoTotal.Text = Format(nMontoTotal, "##,##0.00")

        ElseIf rbParcial.Checked = True Then

            ' Tengo que validar que se haya introducido un importe y que sea mayor al interés calculado

            nPagoParcial = CDbl(txtPagoParcial.Text)

            If nPagoParcial < nIntereses Then
                MsgBox("El importe pagado no cubre los intereses", MsgBoxStyle.Critical, "Mensaje del Sistema")
            Else

                ' Cubre totalmente los intereses

                nPagoParcial = nPagoParcial - nIntereses
                If nPagoParcial > 0 Then
                    If nPagoParcial >= nFinanciados Then

                        ' Cubre totalmente los Financiados

                        nPagoParcial = nPagoParcial - nFinanciados

                        If nPagoParcial > 0 Then
                            nCapital = nPagoParcial
                        End If
                    Else
                        nFinanciados = nFinanciados - nPagoParcial
                        nPagoParcial = 0
                    End If
                End If
                drPagado = dtPagados.NewRow()
                drPagado("Acreditado") = Trim(cNombreAcreditado)
                drPagado("TipoPago") = "PARCIAL"
                drPagado("Fecha") = Mid(cFechaProceso, 7, 2) + "/" + Mid(cFechaProceso, 5, 2) + "/" + Mid(cFechaProceso, 1, 4)
                drPagado("IDCredito") = cIDCredito
                drPagado("Capital") = Format(nCapital, "##,##0.00")
                drPagado("Financiados") = Format(nFinanciados, "##,##0.00")
                drPagado("Intereses") = Format(nIntereses, "##,##0.00")
                drPagado("MontoPagado") = Format(Round(nCapital + nFinanciados + nIntereses, 2), "##,##0.00")
                drPagado("FechaInicial") = cFechaInicial
                drPagado("SaldoInicial") = nSaldoInicial
                drPagado("Anexo") = cAnexo
                drPagado("TasaFB") = nTasaFB
                drPagado("TasaBP") = nTasaBP
                drPagado("TipoCredito") = cTipoCredito
                dtPagados.Rows.Add(drPagado)
            End If

            txtPagoParcial.Text = Format(Round(nCapital + nFinanciados + nIntereses, 2), "##,##0.00")

        End If

        ' Quitar el contrato de Contratos con Adeudo

        btnAumentar.Enabled = False

    End Sub

    Private Sub rbTotal_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbTotal.CheckedChanged
        btnAumentar.Enabled = True
    End Sub

    Private Sub rbParcial_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbParcial.CheckedChanged
        btnAumentar.Enabled = True
    End Sub

    Private Sub btnAplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAplicar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim drPago As DataRow
        Dim drMinistracion As DataRow
        Dim strInsert As String

        ' Declaración de variables de datos

        Dim nImporte As Decimal = 0
        Dim nSaldoFinal As Decimal = 0
        Dim nMinistracionBase As Decimal = 0
        Dim nImporteBanco As Decimal = 0
        Dim nInteresesFinanciados As Decimal = 0
        Dim nInteresesOrdinarios As Decimal = 0

        ' Tengo que procesar la tabla dtPagados y por cada registro voy a afectar las siguientes tablas: 

        ' DetalleFIRA
        ' Egresos

        ' Para insertar el registro en DetalleFIRA necesito calcular el Estado de Cuenta de este crédito
        ' a fin de traer el saldo inicial y la fecha inicial

        cnAgil.Open()

        For Each drPago In dtPagados.Rows

            cIDCredito = drPago("IDCredito")
            nCapital = drPago("Capital")
            nFinanciados = drPago("Financiados")
            nIntereses = drPago("Intereses")
            nInteresesOrdinarios = nIntereses
            nImporte = drPago("MontoPagado")
            cFechaInicial = drPago("FechaInicial")
            nSaldoInicial = drPago("SaldoInicial")
            nSaldoFinal = Round(nSaldoInicial - nCapital - nFinanciados, 2)
            cAnexo = drPago("Anexo")
            nTasaFB = drPago("TasaFB")
            nTasaBP = drPago("TasaBP")
            cTipoCredito = drPago("TipoCredito")

            If nImporte > 0 Then

                strInsert = "INSERT INTO DetalleFIRA (IDCredito, FechaInicial, FechaFinal, TasaFB, TasaBP, SaldoInicial, SaldoFinal, MinistracionBase, InteresesFinanciados, InteresesOrdinarios, Capital, Financiados, Intereses) "
                strInsert = strInsert & "VALUES ('"
                strInsert = strInsert & cIDCredito & "', '"
                strInsert = strInsert & cFechaInicial & "', '"
                strInsert = strInsert & cFechaProceso & "', "
                strInsert = strInsert & nTasaFB & ", "
                strInsert = strInsert & nTasaBP & ", "
                strInsert = strInsert & nSaldoInicial & ", "
                strInsert = strInsert & nSaldoFinal & ", "
                strInsert = strInsert & nMinistracionBase & ", "
                strInsert = strInsert & nInteresesFinanciados & ", "
                strInsert = strInsert & nInteresesOrdinarios & ", "
                strInsert = strInsert & nCapital & ", "
                strInsert = strInsert & nFinanciados & ", "
                strInsert = strInsert & nIntereses
                strInsert = strInsert & ")"
                cm1 = New SqlCommand(strInsert, cnAgil)
                cm1.ExecuteNonQuery()

                ' Actualización del archivo de Egresos (Afectación Contable)

                If nCapital > 0 Then
                    strInsert = "INSERT INTO Egresos (Anexo, FechaEgreso, ClaveEgreso, ImporteEgreso, TipoCredito, CargoAbono, Banco, Concepto) "
                    strInsert = strInsert & "VALUES ('"
                    strInsert = strInsert & cAnexo & "', '"
                    strInsert = strInsert & cFechaProceso & "', "
                    If cTipoCredito = "A" Then
                        strInsert = strInsert & "'68'" & ", "
                    ElseIf cTipoCredito = "R" Then
                        strInsert = strInsert & "'76'" & ", "
                    End If
                    strInsert = strInsert & nCapital & ", '"
                    strInsert = strInsert & cTipoCredito & "', "
                    strInsert = strInsert & "'0'" & ", "
                    strInsert = strInsert & "'11'" & ", "
                    strInsert = strInsert & "'CREDITO FIRA ASOCIADO " & cIDCredito & "'"
                    strInsert = strInsert & ")"
                    cm1 = New SqlCommand(strInsert, cnAgil)
                    cm1.ExecuteNonQuery()
                End If

                If nFinanciados > 0 Then
                    strInsert = "INSERT INTO Egresos (Anexo, FechaEgreso, ClaveEgreso, ImporteEgreso, TipoCredito, CargoAbono, Banco, Concepto) "
                    strInsert = strInsert & "VALUES ('"
                    strInsert = strInsert & cAnexo & "', '"
                    strInsert = strInsert & cFechaProceso & "', "
                    strInsert = strInsert & "'70'" & ", "
                    strInsert = strInsert & nFinanciados & ", '"
                    strInsert = strInsert & cTipoCredito & "', "
                    strInsert = strInsert & "'0'" & ", "
                    strInsert = strInsert & "'11'" & ", "
                    strInsert = strInsert & "'CREDITO FIRA ASOCIADO " & cIDCredito & "'"
                    strInsert = strInsert & ")"
                    cm1 = New SqlCommand(strInsert, cnAgil)
                    cm1.ExecuteNonQuery()
                End If

                If nIntereses > 0 Then
                    strInsert = "INSERT INTO Egresos (Anexo, FechaEgreso, ClaveEgreso, ImporteEgreso, TipoCredito, CargoAbono, Banco, Concepto) "
                    strInsert = strInsert & "VALUES ('"
                    strInsert = strInsert & cAnexo & "', '"
                    strInsert = strInsert & cFechaProceso & "', "
                    strInsert = strInsert & "'69'" & ", "
                    strInsert = strInsert & nIntereses & ", '"
                    strInsert = strInsert & cTipoCredito & "', "
                    strInsert = strInsert & "'0'" & ", "
                    strInsert = strInsert & "'11'" & ", "
                    strInsert = strInsert & "'CREDITO FIRA ASOCIADO " & cIDCredito & "'"
                    strInsert = strInsert & ")"
                    cm1 = New SqlCommand(strInsert, cnAgil)
                    cm1.ExecuteNonQuery()
                End If

                nImporteBanco += nImporte

            End If

        Next

        ' Al final tengo que insertar un registro en Egresos por el importe total que salió de Bancos

        ' Faltaría hacer un desglose por Segmento de Negocio

        If nImporteBanco > 0 Then
            strInsert = "INSERT INTO Egresos (Anexo, FechaEgreso, ClaveEgreso, ImporteEgreso, TipoCredito, CargoAbono, Banco, Concepto) "
            strInsert = strInsert & "VALUES ('"
            strInsert = strInsert & Space(9) & "', '"
            strInsert = strInsert & cFechaProceso & "', "
            strInsert = strInsert & "'99'" & ", "
            strInsert = strInsert & nImporteBanco & ", "
            strInsert = strInsert & "'A'" & ", "
            strInsert = strInsert & "'1'" & ", "
            strInsert = strInsert & "'11'" & ", "
            strInsert = strInsert & "''"
            strInsert = strInsert & ")"
            cm1 = New SqlCommand(strInsert, cnAgil)
            cm1.ExecuteNonQuery()
        End If

        cnAgil.Close()
        cnAgil.Dispose()
        cm1.Dispose()

        Me.Close()

    End Sub

End Class
