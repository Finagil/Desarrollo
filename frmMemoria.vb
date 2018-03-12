Option Explicit On

Imports System.Data.SqlClient
Imports System.Math

Public Class frmMemoria

    ' Declaración de variables de conexión ADO .NET de alcance privado

    Dim dtMemorias As New DataTable("Memorias")

    ' Declaración de variables de alcance privado

    Dim cCliente As String = ""
    Dim cNombreCliente As String = ""
    Dim cNombreSucursal As String = ""
    Dim lCorrecto As Boolean = True
    Dim lFirstTime As Boolean = True
    Dim nVentasTotales As Decimal = 0
    Dim nCostosOperacion As Decimal = 0
    Dim nGastosFinancieros As Decimal = 0
    Dim nSegurosAgropecuarios As Decimal = 0
    Dim nDepreciacion As Decimal = 0
    Dim nGastosAdministracion As Decimal = 0
    Dim nOtrosGastos As Decimal = 0
    Dim nOtrosIngresos As Decimal = 0
    Dim nSM As Decimal = 0
    Dim nINE As Decimal = 0
    Dim nINP As Decimal = 0
    Dim nINPSaldo As Decimal = 0
    Dim nVSM As Decimal = 0
    Dim nSociosActivos As Decimal = 0
    Dim nHombres As Decimal = 0
    Dim nMujeres As Decimal = 0


    Private Sub frmMemoria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daClientes As New SqlDataAdapter(cm1)

        Dim dsAgil As New DataSet()

        ' Lo primero que hago es crear la tabla Memorias que será la base del reporte

        dtMemorias.Columns.Add("No. de Control", Type.GetType("System.Decimal"))
        dtMemorias.Columns.Add("FechaCaptura", Type.GetType("System.String"))
        dtMemorias.Columns.Add("Socios Activos", Type.GetType("System.Decimal"))
        dtMemorias.Columns.Add("Hombres", Type.GetType("System.Decimal"))
        dtMemorias.Columns.Add("Mujeres", Type.GetType("System.Decimal"))
        dtMemorias.Columns.Add("Estrato", Type.GetType("System.String"))
        dtMemorias.Columns.Add("Ventas Totales", Type.GetType("System.String"))
        dtMemorias.Columns.Add("Costos de Operación", Type.GetType("System.String"))
        dtMemorias.Columns.Add("Gastos Financieros", Type.GetType("System.String"))
        dtMemorias.Columns.Add("Seguros Agropecuarios", Type.GetType("System.String"))
        dtMemorias.Columns.Add("Depreciación", Type.GetType("System.String"))
        dtMemorias.Columns.Add("Gastos por Administración", Type.GetType("System.String"))
        dtMemorias.Columns.Add("Otros Gastos", Type.GetType("System.String"))
        dtMemorias.Columns.Add("INE", Type.GetType("System.String"))

        ' Este Stored Procedure trae el nombre de todos los clientes sin importar si tienen contratos generados o no

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "ContClie1"
            .Connection = cnAgil
        End With

        cbProductores.MaxDropDownItems = 25

        Try

            ' Llenar el DataSet lo cual abre y cierra la conexión

            daClientes.Fill(dsAgil, "Clientes")

            ' Ligar la tabla Clientes del dataset dsAgil al ComboBox

            cbProductores.DataSource = dsAgil
            cbProductores.DisplayMember = "Clientes.Descr"
            cbProductores.ValueMember = "Clientes.Cliente"
            lFirstTime = False

        Catch eException As Exception

            MsgBox(eException.Source & " " & eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")

        End Try

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub cbProductores_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbProductores.SelectedIndexChanged

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daMemorias As New SqlDataAdapter(cm1)

        Dim dsAgil As New DataSet()
        Dim drMemoria As DataRow
        Dim drTemporal As DataRow

        If Not cbProductores.SelectedValue Is Nothing And lFirstTime = False Then

            cCliente = cbProductores.SelectedValue.ToString()

            ' Este Command trae los datos de las memorias del productor seleccionado

            With cm1
                .CommandType = CommandType.Text
                .CommandText = "SELECT Memorias.*, Descr, Nombre_Sucursal FROM Memorias " & _
                               "INNER JOIN Clientes ON Memorias.Cliente = Clientes.Cliente " & _
                               "INNER JOIN Sucursales ON Clientes.Sucursal = Sucursales.ID_Sucursal " & _
                               "WHERE Memorias.Cliente = '" & cCliente & "' ORDER BY IDControl"
                .Connection = cnAgil
            End With

            ' Llenar el DataSet lo cual abre y cierra la conexión

            daMemorias.Fill(dsAgil, "Memorias")
            dtMemorias.Clear()

            cNombreCliente = RTrim(cbProductores.Text)

            cm1 = New SqlCommand("SELECT DescPlaza FROM Clientes INNER JOIN Plazas ON Clientes.Plaza = Plazas.Plaza WHERE Cliente = '" & cCliente & "'", cnAgil)
            cnAgil.Open()
            cNombreSucursal = cm1.ExecuteScalar()
            cnAgil.Close()

            txtNombreCliente.Text = RTrim(cNombreCliente)
            txtNombreSucursal.Text = RTrim(cNombreSucursal)

            For Each drMemoria In dsAgil.Tables("Memorias").Rows

                drTemporal = dtMemorias.NewRow

                drTemporal("No. de Control") = drMemoria("IDControl")
                drTemporal("FechaCaptura") = drMemoria("FechaCaptura")
                drTemporal("Socios Activos") = drMemoria("SociosActivos")
                drTemporal("Hombres") = drMemoria("SociosMasculinos")
                drTemporal("Mujeres") = drMemoria("SociosFemeninos")
                drTemporal("Estrato") = drMemoria("Estrato")
                drTemporal("Ventas Totales") = drMemoria("VentasTotales")
                drTemporal("Costos de Operación") = drMemoria("CostosOperacion")
                drTemporal("Gastos Financieros") = drMemoria("GastosFinancieros")
                drTemporal("Seguros Agropecuarios") = drMemoria("SegurosAgropecuarios")
                drTemporal("Depreciación") = drMemoria("Depreciacion")
                drTemporal("Gastos por Administración") = drMemoria("GastosAdministracion")
                drTemporal("Otros Gastos") = drMemoria("OtrosGastos")
                drTemporal("INE") = drMemoria("INE")

                dtMemorias.Rows.Add(drTemporal)

            Next

            dgvMemorias.DataSource = dtMemorias

            dgvMemorias.Visible = True
            lblMensaje.Visible = True
            btnNuevaMemoria.Visible = True

        End If

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub btnDeterminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeterminar.Click

        lCorrecto = True

        nSociosActivos = CDbl(txtSociosActivos.Text)
        nMujeres = CDbl(txtMujeres.Text)

        nHombres = nSociosActivos - nMujeres

        If CDbl(txtSM.Text) <= 0 Then
            MsgBox("El salario mínimo considerado debe ser mayor que cero", MsgBoxStyle.Critical, "Mensaje del Sistema")
            lCorrecto = False
        End If

        If nSociosActivos < 1 Then
            MsgBox("Debe haber por lo menos 1 socio activo", MsgBoxStyle.Critical, "Mensaje del Sistema")
            lCorrecto = False
        End If

        If nMujeres > nSociosActivos Then
            MsgBox("El número de mujeres es mayor al número de Socios Activos", MsgBoxStyle.Critical, "Mensaje del Sistema")
            lCorrecto = False
        End If

        If CDbl(txtNVSM.Text) < 0 Then
            MsgBox("El INE error en la información. Favor de verificarla.", MsgBoxStyle.Critical, "Mensaje del Sistema")
        End If

        If lCorrecto = True Then

            gbResultado.Visible = True
            nVentasTotales = CDbl(txtVentasTotales.Text)
            nCostosOperacion = CDbl(txtCostosOperacion.Text)
            nGastosFinancieros = CDbl(txtGastosFinancieros.Text)
            nSegurosAgropecuarios = CDbl(txtSegurosAgropecuarios.Text)
            nDepreciacion = CDbl(txtDepreciacion.Text)
            nGastosAdministracion = CDbl(txtGastosAdministracion.Text)
            nOtrosGastos = CDbl(txtOtrosGastos.Text)

            nOtrosIngresos = CDbl(txtOtrosIngresos.Text)

            nINE = Round(nVentasTotales - nCostosOperacion - nGastosFinancieros - nSegurosAgropecuarios - nDepreciacion - nGastosAdministracion - nOtrosGastos, 2)

            txtINE.Text = Format(nINE, "##,##0.00")
            txtINP1.Text = Format(nINE, "##,##0.00")

            nINPSaldo = Round(nINE + nOtrosIngresos, 2)
            txtSaldo.Text = Format(nINPSaldo, "##,##0.00")

            nINP = Round(nINPSaldo / nSociosActivos, 2)
            txtINP.Text = Format(nINP, "##,##0.00")

            nSM = CDbl(txtSM.Text)

            nVSM = Round(nINP / nSM, 0)
            txtNVSM.Text = Format(nVSM, "##,##0")

            txtVentasTotales.Text = Format(nVentasTotales, "##,##0.00")
            txtCostosOperacion.Text = Format(nCostosOperacion, "##,##0.00")
            txtGastosFinancieros.Text = Format(nGastosFinancieros, "##,##0.00")
            txtSegurosAgropecuarios.Text = Format(nSegurosAgropecuarios, "##,##0.00")
            txtDepreciacion.Text = Format(nDepreciacion, "##,##0.00")
            txtGastosAdministracion.Text = Format(nGastosAdministracion, "##,##0.00")
            txtOtrosGastos.Text = Format(nOtrosGastos, "##,##0.00")
            txtOtrosIngresos.Text = Format(nOtrosIngresos, "##,##0.00")

            txtVentasTotales.ReadOnly = True
            txtCostosOperacion.ReadOnly = True
            txtGastosFinancieros.ReadOnly = True
            txtSegurosAgropecuarios.ReadOnly = True
            txtDepreciacion.ReadOnly = True
            txtGastosAdministracion.ReadOnly = True
            txtOtrosGastos.ReadOnly = True
            txtOtrosIngresos.ReadOnly = True

            If nVSM >= 0 And nVSM <= 1000 Then
                txtEstrato.Text = "PD1"
            ElseIf nVSM > 1000 And nVSM <= 3000 Then
                txtEstrato.Text = "PD2"
            ElseIf nVSM > 3000 Then
                txtEstrato.Text = "PD3"
            Else
            End If

            btnDeterminar.Enabled = False
            btnGuardar.Enabled = True

        End If

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()

        Dim drTemporal As DataRow

        Dim strInsert As String = ""
        Dim strUpdate As String = ""

        ' Declaración de variables de datos

        Dim cFechaCaptura As String = ""
        Dim nControl As Decimal = 0

        cFechaCaptura = DTOC(dtpFechaCaptura.Value)

        ' En este momento reviso cuál es el último número de control y lo incremento en uno para actualizar la tabla Llaves

        cm1 = New SqlCommand("SELECT IDMemoria FROM Llaves", cnAgil)
        cnAgil.Open()
        nControl = CInt(cm1.ExecuteScalar()) + 1
        cnAgil.Close()

        strUpdate = "UPDATE Llaves SET IDMemoria = " & nControl
        cm1 = New SqlCommand(strUpdate, cnAgil)
        cnAgil.Open()
        cm1.ExecuteNonQuery()
        cnAgil.Close()

        strInsert = "INSERT INTO Memorias (IDControl, Cliente, VentasTotales, CostosOperacion, GastosFinancieros, SegurosAgropecuarios, Depreciacion, GastosAdministracion, OtrosGastos, INE, OtrosIngresos, Saldo, SociosActivos, SociosMasculinos, SociosFemeninos, INP, SalarioMinimo, NVSM, ActivoTotal, ActivoFijo, PasivoTotal, PasivoFijo, Estrato, FechaCaptura )"
        strInsert = strInsert & " VALUES ("
        strInsert = strInsert & nControl & ", '"
        strInsert = strInsert & cCliente & "', "
        strInsert = strInsert & CDbl(txtVentasTotales.Text) & ", "
        strInsert = strInsert & CDbl(txtCostosOperacion.Text) & ", "
        strInsert = strInsert & CDbl(txtGastosFinancieros.Text) & ", "
        strInsert = strInsert & CDbl(txtSegurosAgropecuarios.Text) & ", "
        strInsert = strInsert & CDbl(txtDepreciacion.Text) & ", "
        strInsert = strInsert & CDbl(txtGastosAdministracion.Text) & ", "
        strInsert = strInsert & CDbl(txtOtrosGastos.Text) & ", "
        strInsert = strInsert & CDbl(txtINE.Text) & ", "
        strInsert = strInsert & CDbl(txtOtrosIngresos.Text) & ", "
        strInsert = strInsert & CDbl(txtSaldo.Text) & ", "
        strInsert = strInsert & CDbl(txtSociosActivos.Text) & ", "
        strInsert = strInsert & nHombres & ", "
        strInsert = strInsert & CDbl(txtMujeres.Text) & ", "
        strInsert = strInsert & CDbl(txtINP.Text) & ", "
        strInsert = strInsert & CDbl(txtSM.Text) & ", "
        strInsert = strInsert & CDbl(txtNVSM.Text) & ", "
        strInsert = strInsert & CDbl(txtActivoTotal.Text) & ", "
        strInsert = strInsert & CDbl(txtActivoFijo.Text) & ", "
        strInsert = strInsert & CDbl(txtPasivoTotal.Text) & ", "
        strInsert = strInsert & CDbl(txtPasivoFijo.Text) & ", '"
        strInsert = strInsert & txtEstrato.Text & "', '"
        strInsert = strInsert & cFechaCaptura & "' "
        strInsert = strInsert & ")"
        cm2 = New SqlCommand(strInsert, cnAgil)
        cnAgil.Open()
        cm2.ExecuteNonQuery()
        cnAgil.Close()

        lblNombreCliente.Visible = False
        txtNombreCliente.Visible = False
        lblNombreSucursal.Visible = False
        txtNombreSucursal.Visible = False
        gbINE.Visible = False
        gbINP.Visible = False
        gbActivosPasivos.Visible = False
        btnDeterminar.Visible = False
        btnGuardar.Visible = False
        btnSalir.Visible = False
        gbResultado.Visible = False
        lblFechaCaptura.Visible = False
        dtpFechaCaptura.Visible = False

        drTemporal = dtMemorias.NewRow

        drTemporal("No. de Control") = nControl
        drTemporal("FechaCaptura") = cFechaCaptura
        drTemporal("Socios Activos") = CDbl(txtSociosActivos.Text)
        drTemporal("Hombres") = nHombres
        drTemporal("Mujeres") = CDbl(txtMujeres.Text)
        drTemporal("Estrato") = txtEstrato.Text
        drTemporal("Ventas Totales") = CDbl(txtVentasTotales.Text)
        drTemporal("Costos de Operación") = CDbl(txtCostosOperacion.Text)
        drTemporal("Gastos Financieros") = CDbl(txtGastosFinancieros.Text)
        drTemporal("Seguros Agropecuarios") = CDbl(txtSegurosAgropecuarios.Text)
        drTemporal("Depreciación") = CDbl(txtDepreciacion.Text)
        drTemporal("Gastos por Administración") = CDbl(txtGastosAdministracion.Text)
        drTemporal("Otros Gastos") = CDbl(txtOtrosGastos.Text)
        drTemporal("INE") = CDbl(txtINE.Text)

        dtMemorias.Rows.Add(drTemporal)
        dgvMemorias.Refresh()

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnNuevaMemoria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevaMemoria.Click

        ' Cuando se desee dar de alta una nueva memoria, todos los campos aparecerán en ceros

        lblNombreCliente.Visible = True
        txtNombreCliente.Visible = True
        lblNombreSucursal.Visible = True
        txtNombreSucursal.Visible = True
        gbINE.Visible = True
        gbINP.Visible = True
        gbActivosPasivos.Visible = True
        btnDeterminar.Visible = True
        btnGuardar.Visible = True
        btnSalir.Visible = True
        lblFechaCaptura.Visible = True
        dtpFechaCaptura.Visible = True

    End Sub

End Class
