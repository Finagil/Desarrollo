<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMemoria
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtVentasTotales = New System.Windows.Forms.TextBox
        Me.txtCostosOperacion = New System.Windows.Forms.TextBox
        Me.txtGastosFinancieros = New System.Windows.Forms.TextBox
        Me.txtSegurosAgropecuarios = New System.Windows.Forms.TextBox
        Me.txtDepreciacion = New System.Windows.Forms.TextBox
        Me.txtGastosAdministracion = New System.Windows.Forms.TextBox
        Me.txtINE = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.gbINE = New System.Windows.Forms.GroupBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtOtrosGastos = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.gbINP = New System.Windows.Forms.GroupBox
        Me.txtMujeres = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtSM = New System.Windows.Forms.TextBox
        Me.txtINP = New System.Windows.Forms.TextBox
        Me.txtNVSM = New System.Windows.Forms.TextBox
        Me.txtSociosActivos = New System.Windows.Forms.TextBox
        Me.txtSaldo = New System.Windows.Forms.TextBox
        Me.txtOtrosIngresos = New System.Windows.Forms.TextBox
        Me.txtINP1 = New System.Windows.Forms.TextBox
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.TextBox15 = New System.Windows.Forms.TextBox
        Me.txtEstrato = New System.Windows.Forms.TextBox
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.btnDeterminar = New System.Windows.Forms.Button
        Me.Label22 = New System.Windows.Forms.Label
        Me.cbProductores = New System.Windows.Forms.ComboBox
        Me.btnSalir = New System.Windows.Forms.Button
        Me.gbResultado = New System.Windows.Forms.GroupBox
        Me.gbActivosPasivos = New System.Windows.Forms.GroupBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.txtPasivoFijo = New System.Windows.Forms.TextBox
        Me.txtPasivoTotal = New System.Windows.Forms.TextBox
        Me.txtActivoFijo = New System.Windows.Forms.TextBox
        Me.txtActivoTotal = New System.Windows.Forms.TextBox
        Me.dgvMemorias = New System.Windows.Forms.DataGridView
        Me.btnNuevaMemoria = New System.Windows.Forms.Button
        Me.lblMensaje = New System.Windows.Forms.Label
        Me.lblNombreSucursal = New System.Windows.Forms.Label
        Me.lblNombreCliente = New System.Windows.Forms.Label
        Me.txtNombreCliente = New System.Windows.Forms.TextBox
        Me.txtNombreSucursal = New System.Windows.Forms.TextBox
        Me.dtpFechaCaptura = New System.Windows.Forms.DateTimePicker
        Me.lblFechaCaptura = New System.Windows.Forms.Label
        Me.gbINE.SuspendLayout()
        Me.gbINP.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.gbResultado.SuspendLayout()
        Me.gbActivosPasivos.SuspendLayout()
        CType(Me.dgvMemorias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtVentasTotales
        '
        Me.txtVentasTotales.Location = New System.Drawing.Point(143, 33)
        Me.txtVentasTotales.Name = "txtVentasTotales"
        Me.txtVentasTotales.Size = New System.Drawing.Size(100, 20)
        Me.txtVentasTotales.TabIndex = 0
        Me.txtVentasTotales.Text = "0.00"
        Me.txtVentasTotales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCostosOperacion
        '
        Me.txtCostosOperacion.Location = New System.Drawing.Point(143, 59)
        Me.txtCostosOperacion.Name = "txtCostosOperacion"
        Me.txtCostosOperacion.Size = New System.Drawing.Size(100, 20)
        Me.txtCostosOperacion.TabIndex = 1
        Me.txtCostosOperacion.Text = "0.00"
        Me.txtCostosOperacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGastosFinancieros
        '
        Me.txtGastosFinancieros.Location = New System.Drawing.Point(143, 85)
        Me.txtGastosFinancieros.Name = "txtGastosFinancieros"
        Me.txtGastosFinancieros.Size = New System.Drawing.Size(100, 20)
        Me.txtGastosFinancieros.TabIndex = 2
        Me.txtGastosFinancieros.Text = "0.00"
        Me.txtGastosFinancieros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSegurosAgropecuarios
        '
        Me.txtSegurosAgropecuarios.Location = New System.Drawing.Point(143, 111)
        Me.txtSegurosAgropecuarios.Name = "txtSegurosAgropecuarios"
        Me.txtSegurosAgropecuarios.Size = New System.Drawing.Size(100, 20)
        Me.txtSegurosAgropecuarios.TabIndex = 3
        Me.txtSegurosAgropecuarios.Text = "0.00"
        Me.txtSegurosAgropecuarios.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDepreciacion
        '
        Me.txtDepreciacion.Location = New System.Drawing.Point(143, 137)
        Me.txtDepreciacion.Name = "txtDepreciacion"
        Me.txtDepreciacion.Size = New System.Drawing.Size(100, 20)
        Me.txtDepreciacion.TabIndex = 4
        Me.txtDepreciacion.Text = "0.00"
        Me.txtDepreciacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGastosAdministracion
        '
        Me.txtGastosAdministracion.Location = New System.Drawing.Point(143, 163)
        Me.txtGastosAdministracion.Name = "txtGastosAdministracion"
        Me.txtGastosAdministracion.Size = New System.Drawing.Size(100, 20)
        Me.txtGastosAdministracion.TabIndex = 5
        Me.txtGastosAdministracion.Text = "0.00"
        Me.txtGastosAdministracion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtINE
        '
        Me.txtINE.Location = New System.Drawing.Point(143, 215)
        Me.txtINE.Name = "txtINE"
        Me.txtINE.ReadOnly = True
        Me.txtINE.Size = New System.Drawing.Size(100, 20)
        Me.txtINE.TabIndex = 6
        Me.txtINE.TabStop = False
        Me.txtINE.Text = "0.00"
        Me.txtINE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Ventas Totales"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Costos de Operación"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Gastos Financieros"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(5, 111)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(117, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Seguros Agropecuarios"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 137)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Depreciación"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 163)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(129, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Gastos por Administración"
        '
        'gbINE
        '
        Me.gbINE.Controls.Add(Me.Label21)
        Me.gbINE.Controls.Add(Me.txtOtrosGastos)
        Me.gbINE.Controls.Add(Me.Label13)
        Me.gbINE.Controls.Add(Me.Label6)
        Me.gbINE.Controls.Add(Me.Label5)
        Me.gbINE.Controls.Add(Me.Label4)
        Me.gbINE.Controls.Add(Me.Label3)
        Me.gbINE.Controls.Add(Me.Label2)
        Me.gbINE.Controls.Add(Me.Label1)
        Me.gbINE.Controls.Add(Me.txtINE)
        Me.gbINE.Controls.Add(Me.txtGastosAdministracion)
        Me.gbINE.Controls.Add(Me.txtDepreciacion)
        Me.gbINE.Controls.Add(Me.txtSegurosAgropecuarios)
        Me.gbINE.Controls.Add(Me.txtGastosFinancieros)
        Me.gbINE.Controls.Add(Me.txtCostosOperacion)
        Me.gbINE.Controls.Add(Me.txtVentasTotales)
        Me.gbINE.Location = New System.Drawing.Point(22, 315)
        Me.gbINE.Name = "gbINE"
        Me.gbINE.Size = New System.Drawing.Size(256, 250)
        Me.gbINE.TabIndex = 0
        Me.gbINE.TabStop = False
        Me.gbINE.Text = "Ingreso Neto Empresa"
        Me.gbINE.Visible = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(5, 189)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(68, 13)
        Me.Label21.TabIndex = 15
        Me.Label21.Text = "Otros Gastos"
        '
        'txtOtrosGastos
        '
        Me.txtOtrosGastos.Location = New System.Drawing.Point(143, 189)
        Me.txtOtrosGastos.Name = "txtOtrosGastos"
        Me.txtOtrosGastos.Size = New System.Drawing.Size(100, 20)
        Me.txtOtrosGastos.TabIndex = 6
        Me.txtOtrosGastos.Text = "0.00"
        Me.txtOtrosGastos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(5, 215)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(28, 13)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "INE"
        '
        'gbINP
        '
        Me.gbINP.Controls.Add(Me.txtMujeres)
        Me.gbINP.Controls.Add(Me.Label23)
        Me.gbINP.Controls.Add(Me.Label20)
        Me.gbINP.Controls.Add(Me.Label7)
        Me.gbINP.Controls.Add(Me.Label8)
        Me.gbINP.Controls.Add(Me.Label9)
        Me.gbINP.Controls.Add(Me.Label10)
        Me.gbINP.Controls.Add(Me.Label11)
        Me.gbINP.Controls.Add(Me.Label12)
        Me.gbINP.Controls.Add(Me.txtSM)
        Me.gbINP.Controls.Add(Me.txtINP)
        Me.gbINP.Controls.Add(Me.txtNVSM)
        Me.gbINP.Controls.Add(Me.txtSociosActivos)
        Me.gbINP.Controls.Add(Me.txtSaldo)
        Me.gbINP.Controls.Add(Me.txtOtrosIngresos)
        Me.gbINP.Controls.Add(Me.txtINP1)
        Me.gbINP.Location = New System.Drawing.Point(284, 315)
        Me.gbINP.Name = "gbINP"
        Me.gbINP.Size = New System.Drawing.Size(323, 253)
        Me.gbINP.TabIndex = 1
        Me.gbINP.TabStop = False
        Me.gbINP.Text = "Ingreso Neto Productor"
        Me.gbINP.Visible = False
        '
        'txtMujeres
        '
        Me.txtMujeres.Location = New System.Drawing.Point(208, 136)
        Me.txtMujeres.Name = "txtMujeres"
        Me.txtMujeres.Size = New System.Drawing.Size(100, 20)
        Me.txtMujeres.TabIndex = 3
        Me.txtMujeres.Text = "0"
        Me.txtMujeres.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(7, 139)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(78, 13)
        Me.Label23.TabIndex = 17
        Me.Label23.Text = "No. de mujeres"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(7, 195)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(137, 13)
        Me.Label20.TabIndex = 16
        Me.Label20.Text = "Salario mínimo considerado"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 218)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(172, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Número de veces el salario mínimo"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(7, 166)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(28, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "INP"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(7, 110)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(109, 13)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "No. de socios activos"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(7, 84)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 13)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "= Saldo"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(7, 58)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(180, 13)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "+ Otros ingresos ajenos a la empresa"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(7, 35)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(25, 13)
        Me.Label12.TabIndex = 7
        Me.Label12.Text = "INE"
        '
        'txtSM
        '
        Me.txtSM.Location = New System.Drawing.Point(208, 188)
        Me.txtSM.Name = "txtSM"
        Me.txtSM.Size = New System.Drawing.Size(100, 20)
        Me.txtSM.TabIndex = 4
        Me.txtSM.Text = "0.00"
        Me.txtSM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtINP
        '
        Me.txtINP.Location = New System.Drawing.Point(208, 162)
        Me.txtINP.Name = "txtINP"
        Me.txtINP.ReadOnly = True
        Me.txtINP.Size = New System.Drawing.Size(100, 20)
        Me.txtINP.TabIndex = 4
        Me.txtINP.TabStop = False
        Me.txtINP.Text = "0.00"
        Me.txtINP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNVSM
        '
        Me.txtNVSM.Location = New System.Drawing.Point(208, 214)
        Me.txtNVSM.Name = "txtNVSM"
        Me.txtNVSM.ReadOnly = True
        Me.txtNVSM.Size = New System.Drawing.Size(100, 20)
        Me.txtNVSM.TabIndex = 5
        Me.txtNVSM.TabStop = False
        Me.txtNVSM.Text = "0.00"
        Me.txtNVSM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSociosActivos
        '
        Me.txtSociosActivos.Location = New System.Drawing.Point(208, 110)
        Me.txtSociosActivos.Name = "txtSociosActivos"
        Me.txtSociosActivos.Size = New System.Drawing.Size(100, 20)
        Me.txtSociosActivos.TabIndex = 2
        Me.txtSociosActivos.Text = "0"
        Me.txtSociosActivos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSaldo
        '
        Me.txtSaldo.Location = New System.Drawing.Point(208, 84)
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.ReadOnly = True
        Me.txtSaldo.Size = New System.Drawing.Size(100, 20)
        Me.txtSaldo.TabIndex = 2
        Me.txtSaldo.TabStop = False
        Me.txtSaldo.Text = "0.00"
        Me.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtOtrosIngresos
        '
        Me.txtOtrosIngresos.Location = New System.Drawing.Point(208, 58)
        Me.txtOtrosIngresos.Name = "txtOtrosIngresos"
        Me.txtOtrosIngresos.Size = New System.Drawing.Size(100, 20)
        Me.txtOtrosIngresos.TabIndex = 1
        Me.txtOtrosIngresos.Text = "0.00"
        Me.txtOtrosIngresos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtINP1
        '
        Me.txtINP1.Location = New System.Drawing.Point(208, 32)
        Me.txtINP1.Name = "txtINP1"
        Me.txtINP1.ReadOnly = True
        Me.txtINP1.Size = New System.Drawing.Size(100, 20)
        Me.txtINP1.TabIndex = 0
        Me.txtINP1.TabStop = False
        Me.txtINP1.Text = "0.00"
        Me.txtINP1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.Controls.Add(Me.Label16, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label14, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label15, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label17, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label18, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label19, 1, 2)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(7, 19)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(189, 65)
        Me.TableLayoutPanel1.TabIndex = 15
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(148, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(31, 13)
        Me.Label16.TabIndex = 16
        Me.Label16.Text = "PD1"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(3, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 13)
        Me.Label14.TabIndex = 16
        Me.Label14.Text = "Hasta 1,000"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(3, 22)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(139, 13)
        Me.Label15.TabIndex = 17
        Me.Label15.Text = "Más de 1,000 y hasta 3,000"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(148, 22)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(31, 13)
        Me.Label17.TabIndex = 18
        Me.Label17.Text = "PD2"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(3, 44)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(72, 13)
        Me.Label18.TabIndex = 19
        Me.Label18.Text = "Más de 3,000"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(148, 44)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(31, 13)
        Me.Label19.TabIndex = 20
        Me.Label19.Text = "PD3"
        '
        'TextBox15
        '
        Me.TextBox15.Location = New System.Drawing.Point(212, 29)
        Me.TextBox15.Multiline = True
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.ReadOnly = True
        Me.TextBox15.Size = New System.Drawing.Size(264, 47)
        Me.TextBox15.TabIndex = 16
        Me.TextBox15.Text = "En base al número de salarios mínimos obtenidos, certificamos que el acreditado q" & _
            "ue nos ocupa se clasifica dentro del siguiente estrato:"
        '
        'txtEstrato
        '
        Me.txtEstrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEstrato.Location = New System.Drawing.Point(513, 41)
        Me.txtEstrato.Name = "txtEstrato"
        Me.txtEstrato.ReadOnly = True
        Me.txtEstrato.Size = New System.Drawing.Size(53, 23)
        Me.txtEstrato.TabIndex = 17
        Me.txtEstrato.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnGuardar
        '
        Me.btnGuardar.Enabled = False
        Me.btnGuardar.Location = New System.Drawing.Point(901, 344)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(99, 23)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        Me.btnGuardar.Visible = False
        '
        'btnDeterminar
        '
        Me.btnDeterminar.Location = New System.Drawing.Point(901, 315)
        Me.btnDeterminar.Name = "btnDeterminar"
        Me.btnDeterminar.Size = New System.Drawing.Size(99, 23)
        Me.btnDeterminar.TabIndex = 3
        Me.btnDeterminar.Text = "Determinar"
        Me.btnDeterminar.UseVisualStyleBackColor = True
        Me.btnDeterminar.Visible = False
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(20, 21)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(116, 19)
        Me.Label22.TabIndex = 59
        Me.Label22.Text = "Nombre del Productor"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbProductores
        '
        Me.cbProductores.Location = New System.Drawing.Point(142, 19)
        Me.cbProductores.Name = "cbProductores"
        Me.cbProductores.Size = New System.Drawing.Size(538, 21)
        Me.cbProductores.TabIndex = 67
        Me.cbProductores.Text = "ComboBox1"
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(901, 373)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(99, 23)
        Me.btnSalir.TabIndex = 5
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        Me.btnSalir.Visible = False
        '
        'gbResultado
        '
        Me.gbResultado.Controls.Add(Me.TableLayoutPanel1)
        Me.gbResultado.Controls.Add(Me.TextBox15)
        Me.gbResultado.Controls.Add(Me.txtEstrato)
        Me.gbResultado.Location = New System.Drawing.Point(21, 584)
        Me.gbResultado.Name = "gbResultado"
        Me.gbResultado.Size = New System.Drawing.Size(586, 101)
        Me.gbResultado.TabIndex = 69
        Me.gbResultado.TabStop = False
        Me.gbResultado.Text = "Resultado"
        Me.gbResultado.Visible = False
        '
        'gbActivosPasivos
        '
        Me.gbActivosPasivos.Controls.Add(Me.Label27)
        Me.gbActivosPasivos.Controls.Add(Me.Label28)
        Me.gbActivosPasivos.Controls.Add(Me.Label29)
        Me.gbActivosPasivos.Controls.Add(Me.Label30)
        Me.gbActivosPasivos.Controls.Add(Me.txtPasivoFijo)
        Me.gbActivosPasivos.Controls.Add(Me.txtPasivoTotal)
        Me.gbActivosPasivos.Controls.Add(Me.txtActivoFijo)
        Me.gbActivosPasivos.Controls.Add(Me.txtActivoTotal)
        Me.gbActivosPasivos.Location = New System.Drawing.Point(662, 315)
        Me.gbActivosPasivos.Name = "gbActivosPasivos"
        Me.gbActivosPasivos.Size = New System.Drawing.Size(213, 151)
        Me.gbActivosPasivos.TabIndex = 2
        Me.gbActivosPasivos.TabStop = False
        Me.gbActivosPasivos.Text = "Activos y Pasivos (en miles de pesos)"
        Me.gbActivosPasivos.Visible = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(6, 111)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(58, 13)
        Me.Label27.TabIndex = 10
        Me.Label27.Text = "Pasivo Fijo"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(6, 85)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(66, 13)
        Me.Label28.TabIndex = 9
        Me.Label28.Text = "Pasivo Total"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(6, 59)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(56, 13)
        Me.Label29.TabIndex = 8
        Me.Label29.Text = "Activo Fijo"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(6, 33)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(64, 13)
        Me.Label30.TabIndex = 7
        Me.Label30.Text = "Activo Total"
        '
        'txtPasivoFijo
        '
        Me.txtPasivoFijo.Location = New System.Drawing.Point(83, 110)
        Me.txtPasivoFijo.Name = "txtPasivoFijo"
        Me.txtPasivoFijo.Size = New System.Drawing.Size(100, 20)
        Me.txtPasivoFijo.TabIndex = 4
        Me.txtPasivoFijo.Text = "0"
        Me.txtPasivoFijo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPasivoTotal
        '
        Me.txtPasivoTotal.Location = New System.Drawing.Point(83, 84)
        Me.txtPasivoTotal.Name = "txtPasivoTotal"
        Me.txtPasivoTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtPasivoTotal.TabIndex = 3
        Me.txtPasivoTotal.Text = "0"
        Me.txtPasivoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtActivoFijo
        '
        Me.txtActivoFijo.Location = New System.Drawing.Point(83, 58)
        Me.txtActivoFijo.Name = "txtActivoFijo"
        Me.txtActivoFijo.Size = New System.Drawing.Size(100, 20)
        Me.txtActivoFijo.TabIndex = 2
        Me.txtActivoFijo.Text = "0"
        Me.txtActivoFijo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtActivoTotal
        '
        Me.txtActivoTotal.Location = New System.Drawing.Point(83, 32)
        Me.txtActivoTotal.Name = "txtActivoTotal"
        Me.txtActivoTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtActivoTotal.TabIndex = 1
        Me.txtActivoTotal.Text = "0"
        Me.txtActivoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgvMemorias
        '
        Me.dgvMemorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMemorias.Location = New System.Drawing.Point(22, 59)
        Me.dgvMemorias.Name = "dgvMemorias"
        Me.dgvMemorias.Size = New System.Drawing.Size(978, 116)
        Me.dgvMemorias.TabIndex = 71
        Me.dgvMemorias.Visible = False
        '
        'btnNuevaMemoria
        '
        Me.btnNuevaMemoria.Location = New System.Drawing.Point(901, 181)
        Me.btnNuevaMemoria.Name = "btnNuevaMemoria"
        Me.btnNuevaMemoria.Size = New System.Drawing.Size(99, 23)
        Me.btnNuevaMemoria.TabIndex = 72
        Me.btnNuevaMemoria.Text = "Nueva memoria"
        Me.btnNuevaMemoria.UseVisualStyleBackColor = True
        Me.btnNuevaMemoria.Visible = False
        '
        'lblMensaje
        '
        Me.lblMensaje.AutoSize = True
        Me.lblMensaje.Location = New System.Drawing.Point(19, 186)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(755, 13)
        Me.lblMensaje.TabIndex = 73
        Me.lblMensaje.Text = "Para modificar una memoria haz doble click sobre ella. Solo podrás modificar la m" & _
            "ás reciente.   Para generar una nueva memoria haz click en el siguiente botón"
        Me.lblMensaje.Visible = False
        '
        'lblNombreSucursal
        '
        Me.lblNombreSucursal.AutoSize = True
        Me.lblNombreSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreSucursal.Location = New System.Drawing.Point(25, 276)
        Me.lblNombreSucursal.Name = "lblNombreSucursal"
        Me.lblNombreSucursal.Size = New System.Drawing.Size(156, 13)
        Me.lblNombreSucursal.TabIndex = 74
        Me.lblNombreSucursal.Text = "Cliente atendido por la Sucursal"
        Me.lblNombreSucursal.Visible = False
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.AutoSize = True
        Me.lblNombreCliente.Location = New System.Drawing.Point(25, 249)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(185, 13)
        Me.lblNombreCliente.TabIndex = 75
        Me.lblNombreCliente.Text = "Nombre o Razón Social del Productor"
        Me.lblNombreCliente.Visible = False
        '
        'txtNombreCliente
        '
        Me.txtNombreCliente.Location = New System.Drawing.Point(219, 247)
        Me.txtNombreCliente.Name = "txtNombreCliente"
        Me.txtNombreCliente.ReadOnly = True
        Me.txtNombreCliente.Size = New System.Drawing.Size(656, 20)
        Me.txtNombreCliente.TabIndex = 76
        Me.txtNombreCliente.Visible = False
        '
        'txtNombreSucursal
        '
        Me.txtNombreSucursal.Location = New System.Drawing.Point(219, 273)
        Me.txtNombreSucursal.Name = "txtNombreSucursal"
        Me.txtNombreSucursal.ReadOnly = True
        Me.txtNombreSucursal.Size = New System.Drawing.Size(100, 20)
        Me.txtNombreSucursal.TabIndex = 77
        Me.txtNombreSucursal.Visible = False
        '
        'dtpFechaCaptura
        '
        Me.dtpFechaCaptura.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaCaptura.Location = New System.Drawing.Point(782, 548)
        Me.dtpFechaCaptura.Name = "dtpFechaCaptura"
        Me.dtpFechaCaptura.Size = New System.Drawing.Size(93, 20)
        Me.dtpFechaCaptura.TabIndex = 78
        Me.dtpFechaCaptura.Visible = False
        '
        'lblFechaCaptura
        '
        Me.lblFechaCaptura.AutoSize = True
        Me.lblFechaCaptura.Location = New System.Drawing.Point(668, 552)
        Me.lblFechaCaptura.Name = "lblFechaCaptura"
        Me.lblFechaCaptura.Size = New System.Drawing.Size(92, 13)
        Me.lblFechaCaptura.TabIndex = 79
        Me.lblFechaCaptura.Text = "Fecha de Captura"
        Me.lblFechaCaptura.Visible = False
        '
        'frmMemoria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1024, 702)
        Me.Controls.Add(Me.lblFechaCaptura)
        Me.Controls.Add(Me.dtpFechaCaptura)
        Me.Controls.Add(Me.txtNombreSucursal)
        Me.Controls.Add(Me.txtNombreCliente)
        Me.Controls.Add(Me.lblNombreCliente)
        Me.Controls.Add(Me.lblNombreSucursal)
        Me.Controls.Add(Me.lblMensaje)
        Me.Controls.Add(Me.btnNuevaMemoria)
        Me.Controls.Add(Me.dgvMemorias)
        Me.Controls.Add(Me.gbActivosPasivos)
        Me.Controls.Add(Me.gbResultado)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.cbProductores)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.btnDeterminar)
        Me.Controls.Add(Me.gbINP)
        Me.Controls.Add(Me.gbINE)
        Me.Name = "frmMemoria"
        Me.Text = "Memoria para la determinación del INE y del INP"
        Me.gbINE.ResumeLayout(False)
        Me.gbINE.PerformLayout()
        Me.gbINP.ResumeLayout(False)
        Me.gbINP.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.gbResultado.ResumeLayout(False)
        Me.gbResultado.PerformLayout()
        Me.gbActivosPasivos.ResumeLayout(False)
        Me.gbActivosPasivos.PerformLayout()
        CType(Me.dgvMemorias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtVentasTotales As System.Windows.Forms.TextBox
    Friend WithEvents txtCostosOperacion As System.Windows.Forms.TextBox
    Friend WithEvents txtGastosFinancieros As System.Windows.Forms.TextBox
    Friend WithEvents txtSegurosAgropecuarios As System.Windows.Forms.TextBox
    Friend WithEvents txtDepreciacion As System.Windows.Forms.TextBox
    Friend WithEvents txtGastosAdministracion As System.Windows.Forms.TextBox
    Friend WithEvents txtINE As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents gbINE As System.Windows.Forms.GroupBox
    Friend WithEvents gbINP As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtSM As System.Windows.Forms.TextBox
    Friend WithEvents txtNVSM As System.Windows.Forms.TextBox
    Friend WithEvents txtINP As System.Windows.Forms.TextBox
    Friend WithEvents txtSociosActivos As System.Windows.Forms.TextBox
    Friend WithEvents txtSaldo As System.Windows.Forms.TextBox
    Friend WithEvents txtOtrosIngresos As System.Windows.Forms.TextBox
    Friend WithEvents txtINP1 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TextBox15 As System.Windows.Forms.TextBox
    Friend WithEvents txtEstrato As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtOtrosGastos As System.Windows.Forms.TextBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnDeterminar As System.Windows.Forms.Button
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cbProductores As System.Windows.Forms.ComboBox
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents gbResultado As System.Windows.Forms.GroupBox
    Friend WithEvents gbActivosPasivos As System.Windows.Forms.GroupBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtPasivoFijo As System.Windows.Forms.TextBox
    Friend WithEvents txtPasivoTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtActivoFijo As System.Windows.Forms.TextBox
    Friend WithEvents txtActivoTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtMujeres As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents dgvMemorias As System.Windows.Forms.DataGridView
    Friend WithEvents btnNuevaMemoria As System.Windows.Forms.Button
    Friend WithEvents lblMensaje As System.Windows.Forms.Label
    Friend WithEvents lblNombreSucursal As System.Windows.Forms.Label
    Friend WithEvents lblNombreCliente As System.Windows.Forms.Label
    Friend WithEvents txtNombreCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtNombreSucursal As System.Windows.Forms.TextBox
    Friend WithEvents dtpFechaCaptura As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFechaCaptura As System.Windows.Forms.Label
End Class
