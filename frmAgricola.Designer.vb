<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAgricola
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.lblMinistradoFIRA = New System.Windows.Forms.Label
        Me.panelFIRA = New System.Windows.Forms.Panel
        Me.btnCancelarFIRA = New System.Windows.Forms.Button
        Me.btnGuardarFIRA = New System.Windows.Forms.Button
        Me.cbFEGA = New System.Windows.Forms.ComboBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.cbEstado = New System.Windows.Forms.ComboBox
        Me.dtpFechaFIRA = New System.Windows.Forms.DateTimePicker
        Me.txtImporteFIRA = New System.Windows.Forms.TextBox
        Me.btnModificarFIRA = New System.Windows.Forms.Button
        Me.dgvFIRA = New System.Windows.Forms.DataGridView
        Me.btnInsertarFIRA = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.lblMinistradoFINAGIL = New System.Windows.Forms.Label
        Me.panelFINAGIL = New System.Windows.Forms.Panel
        Me.btnCancelarFINAGIL = New System.Windows.Forms.Button
        Me.btnGuardarFINAGIL = New System.Windows.Forms.Button
        Me.Label24 = New System.Windows.Forms.Label
        Me.cbDocumento = New System.Windows.Forms.ComboBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtImporteFINAGIL = New System.Windows.Forms.TextBox
        Me.dgvFINAGIL = New System.Windows.Forms.DataGridView
        Me.btnModificarFINAGIL = New System.Windows.Forms.Button
        Me.btnInsertarFINAGIL = New System.Windows.Forms.Button
        Me.txtLineaAutorizada = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.btnSalir = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblSumaPagares = New System.Windows.Forms.Label
        Me.dgvPagares = New System.Windows.Forms.DataGridView
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtHectareasActual = New System.Windows.Forms.TextBox
        Me.lblAnexo = New System.Windows.Forms.Label
        Me.txtBanco = New System.Windows.Forms.TextBox
        Me.txtCuentaBancomer = New System.Windows.Forms.TextBox
        Me.txtCuentaCLABE = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtCiclo = New System.Windows.Forms.TextBox
        Me.GroupBox3.SuspendLayout()
        Me.panelFIRA.SuspendLayout()
        CType(Me.dgvFIRA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.panelFINAGIL.SuspendLayout()
        CType(Me.dgvFINAGIL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvPagares, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblMinistradoFIRA)
        Me.GroupBox3.Controls.Add(Me.panelFIRA)
        Me.GroupBox3.Controls.Add(Me.btnModificarFIRA)
        Me.GroupBox3.Controls.Add(Me.dgvFIRA)
        Me.GroupBox3.Controls.Add(Me.btnInsertarFIRA)
        Me.GroupBox3.Location = New System.Drawing.Point(555, 233)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(457, 412)
        Me.GroupBox3.TabIndex = 17
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Ministraciones FIRA - FINAGIL"
        '
        'lblMinistradoFIRA
        '
        Me.lblMinistradoFIRA.AutoSize = True
        Me.lblMinistradoFIRA.Location = New System.Drawing.Point(114, 184)
        Me.lblMinistradoFIRA.Name = "lblMinistradoFIRA"
        Me.lblMinistradoFIRA.Size = New System.Drawing.Size(180, 13)
        Me.lblMinistradoFIRA.TabIndex = 16
        Me.lblMinistradoFIRA.Text = "Total Ministrado por FIRA a FINAGIL"
        '
        'panelFIRA
        '
        Me.panelFIRA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelFIRA.Controls.Add(Me.btnCancelarFIRA)
        Me.panelFIRA.Controls.Add(Me.btnGuardarFIRA)
        Me.panelFIRA.Controls.Add(Me.cbFEGA)
        Me.panelFIRA.Controls.Add(Me.Label20)
        Me.panelFIRA.Controls.Add(Me.Label19)
        Me.panelFIRA.Controls.Add(Me.Label18)
        Me.panelFIRA.Controls.Add(Me.Label17)
        Me.panelFIRA.Controls.Add(Me.cbEstado)
        Me.panelFIRA.Controls.Add(Me.dtpFechaFIRA)
        Me.panelFIRA.Controls.Add(Me.txtImporteFIRA)
        Me.panelFIRA.Location = New System.Drawing.Point(121, 216)
        Me.panelFIRA.Name = "panelFIRA"
        Me.panelFIRA.Size = New System.Drawing.Size(318, 183)
        Me.panelFIRA.TabIndex = 14
        '
        'btnCancelarFIRA
        '
        Me.btnCancelarFIRA.Location = New System.Drawing.Point(224, 145)
        Me.btnCancelarFIRA.Name = "btnCancelarFIRA"
        Me.btnCancelarFIRA.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelarFIRA.TabIndex = 8
        Me.btnCancelarFIRA.Text = "Cancelar"
        Me.btnCancelarFIRA.UseVisualStyleBackColor = True
        '
        'btnGuardarFIRA
        '
        Me.btnGuardarFIRA.Location = New System.Drawing.Point(23, 145)
        Me.btnGuardarFIRA.Name = "btnGuardarFIRA"
        Me.btnGuardarFIRA.Size = New System.Drawing.Size(75, 23)
        Me.btnGuardarFIRA.TabIndex = 7
        Me.btnGuardarFIRA.Text = "Guardar"
        Me.btnGuardarFIRA.UseVisualStyleBackColor = True
        '
        'cbFEGA
        '
        Me.cbFEGA.FormattingEnabled = True
        Me.cbFEGA.Location = New System.Drawing.Point(240, 74)
        Me.cbFEGA.Name = "cbFEGA"
        Me.cbFEGA.Size = New System.Drawing.Size(59, 21)
        Me.cbFEGA.TabIndex = 5
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(20, 105)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(118, 19)
        Me.Label20.TabIndex = 20
        Me.Label20.Text = "Estado"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(20, 75)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(118, 19)
        Me.Label19.TabIndex = 19
        Me.Label19.Text = "Garantía FEGA"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(20, 45)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(118, 19)
        Me.Label18.TabIndex = 18
        Me.Label18.Text = "Importe"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(20, 15)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(118, 19)
        Me.Label17.TabIndex = 17
        Me.Label17.Text = "Fecha Programada"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbEstado
        '
        Me.cbEstado.FormattingEnabled = True
        Me.cbEstado.Location = New System.Drawing.Point(178, 104)
        Me.cbEstado.Name = "cbEstado"
        Me.cbEstado.Size = New System.Drawing.Size(121, 21)
        Me.cbEstado.TabIndex = 6
        '
        'dtpFechaFIRA
        '
        Me.dtpFechaFIRA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFIRA.Location = New System.Drawing.Point(213, 14)
        Me.dtpFechaFIRA.Name = "dtpFechaFIRA"
        Me.dtpFechaFIRA.Size = New System.Drawing.Size(86, 20)
        Me.dtpFechaFIRA.TabIndex = 3
        '
        'txtImporteFIRA
        '
        Me.txtImporteFIRA.Location = New System.Drawing.Point(199, 44)
        Me.txtImporteFIRA.Name = "txtImporteFIRA"
        Me.txtImporteFIRA.Size = New System.Drawing.Size(100, 20)
        Me.txtImporteFIRA.TabIndex = 4
        Me.txtImporteFIRA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnModificarFIRA
        '
        Me.btnModificarFIRA.Location = New System.Drawing.Point(28, 252)
        Me.btnModificarFIRA.Name = "btnModificarFIRA"
        Me.btnModificarFIRA.Size = New System.Drawing.Size(75, 23)
        Me.btnModificarFIRA.TabIndex = 2
        Me.btnModificarFIRA.Text = "Modificar"
        Me.btnModificarFIRA.UseVisualStyleBackColor = True
        '
        'dgvFIRA
        '
        Me.dgvFIRA.AllowUserToDeleteRows = False
        Me.dgvFIRA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFIRA.Location = New System.Drawing.Point(9, 19)
        Me.dgvFIRA.Name = "dgvFIRA"
        Me.dgvFIRA.ReadOnly = True
        Me.dgvFIRA.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvFIRA.Size = New System.Drawing.Size(430, 158)
        Me.dgvFIRA.TabIndex = 2
        Me.dgvFIRA.TabStop = False
        '
        'btnInsertarFIRA
        '
        Me.btnInsertarFIRA.Location = New System.Drawing.Point(28, 214)
        Me.btnInsertarFIRA.Name = "btnInsertarFIRA"
        Me.btnInsertarFIRA.Size = New System.Drawing.Size(75, 23)
        Me.btnInsertarFIRA.TabIndex = 1
        Me.btnInsertarFIRA.Text = "Insertar"
        Me.btnInsertarFIRA.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lblMinistradoFINAGIL)
        Me.GroupBox4.Controls.Add(Me.panelFINAGIL)
        Me.GroupBox4.Controls.Add(Me.dgvFINAGIL)
        Me.GroupBox4.Controls.Add(Me.btnModificarFINAGIL)
        Me.GroupBox4.Controls.Add(Me.btnInsertarFINAGIL)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 233)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(517, 412)
        Me.GroupBox4.TabIndex = 18
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Ministraciones FINAGIL - Productor"
        '
        'lblMinistradoFINAGIL
        '
        Me.lblMinistradoFINAGIL.AutoSize = True
        Me.lblMinistradoFINAGIL.Location = New System.Drawing.Point(170, 184)
        Me.lblMinistradoFINAGIL.Name = "lblMinistradoFINAGIL"
        Me.lblMinistradoFINAGIL.Size = New System.Drawing.Size(204, 13)
        Me.lblMinistradoFINAGIL.TabIndex = 20
        Me.lblMinistradoFINAGIL.Text = "Total Ministrado por FINAGIL al Productor"
        '
        'panelFINAGIL
        '
        Me.panelFINAGIL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelFINAGIL.Controls.Add(Me.btnCancelarFINAGIL)
        Me.panelFINAGIL.Controls.Add(Me.btnGuardarFINAGIL)
        Me.panelFINAGIL.Controls.Add(Me.Label24)
        Me.panelFINAGIL.Controls.Add(Me.cbDocumento)
        Me.panelFINAGIL.Controls.Add(Me.Label22)
        Me.panelFINAGIL.Controls.Add(Me.txtImporteFINAGIL)
        Me.panelFINAGIL.Location = New System.Drawing.Point(177, 214)
        Me.panelFINAGIL.Name = "panelFINAGIL"
        Me.panelFINAGIL.Size = New System.Drawing.Size(322, 183)
        Me.panelFINAGIL.TabIndex = 19
        '
        'btnCancelarFINAGIL
        '
        Me.btnCancelarFINAGIL.Location = New System.Drawing.Point(227, 144)
        Me.btnCancelarFINAGIL.Name = "btnCancelarFINAGIL"
        Me.btnCancelarFINAGIL.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelarFINAGIL.TabIndex = 15
        Me.btnCancelarFINAGIL.Text = "Cancelar"
        Me.btnCancelarFINAGIL.UseVisualStyleBackColor = True
        '
        'btnGuardarFINAGIL
        '
        Me.btnGuardarFINAGIL.Location = New System.Drawing.Point(26, 144)
        Me.btnGuardarFINAGIL.Name = "btnGuardarFINAGIL"
        Me.btnGuardarFINAGIL.Size = New System.Drawing.Size(75, 23)
        Me.btnGuardarFINAGIL.TabIndex = 14
        Me.btnGuardarFINAGIL.Text = "Guardar"
        Me.btnGuardarFINAGIL.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(23, 15)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(118, 19)
        Me.Label24.TabIndex = 25
        Me.Label24.Text = "Documento"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbDocumento
        '
        Me.cbDocumento.FormattingEnabled = True
        Me.cbDocumento.Location = New System.Drawing.Point(165, 14)
        Me.cbDocumento.Name = "cbDocumento"
        Me.cbDocumento.Size = New System.Drawing.Size(137, 21)
        Me.cbDocumento.TabIndex = 11
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(23, 48)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(118, 19)
        Me.Label22.TabIndex = 21
        Me.Label22.Text = "Importe"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtImporteFINAGIL
        '
        Me.txtImporteFINAGIL.Location = New System.Drawing.Point(202, 47)
        Me.txtImporteFINAGIL.Name = "txtImporteFINAGIL"
        Me.txtImporteFINAGIL.Size = New System.Drawing.Size(100, 20)
        Me.txtImporteFINAGIL.TabIndex = 12
        Me.txtImporteFINAGIL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgvFINAGIL
        '
        Me.dgvFINAGIL.AllowUserToDeleteRows = False
        Me.dgvFINAGIL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFINAGIL.Location = New System.Drawing.Point(10, 19)
        Me.dgvFINAGIL.Name = "dgvFINAGIL"
        Me.dgvFINAGIL.ReadOnly = True
        Me.dgvFINAGIL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvFINAGIL.Size = New System.Drawing.Size(489, 160)
        Me.dgvFINAGIL.TabIndex = 18
        Me.dgvFINAGIL.TabStop = False
        '
        'btnModificarFINAGIL
        '
        Me.btnModificarFINAGIL.Location = New System.Drawing.Point(59, 252)
        Me.btnModificarFINAGIL.Name = "btnModificarFINAGIL"
        Me.btnModificarFINAGIL.Size = New System.Drawing.Size(75, 23)
        Me.btnModificarFINAGIL.TabIndex = 10
        Me.btnModificarFINAGIL.Text = "Modificar"
        Me.btnModificarFINAGIL.UseVisualStyleBackColor = True
        '
        'btnInsertarFINAGIL
        '
        Me.btnInsertarFINAGIL.Location = New System.Drawing.Point(59, 214)
        Me.btnInsertarFINAGIL.Name = "btnInsertarFINAGIL"
        Me.btnInsertarFINAGIL.Size = New System.Drawing.Size(75, 23)
        Me.btnInsertarFINAGIL.TabIndex = 9
        Me.btnInsertarFINAGIL.Text = "Insertar"
        Me.btnInsertarFINAGIL.UseVisualStyleBackColor = True
        '
        'txtLineaAutorizada
        '
        Me.txtLineaAutorizada.Location = New System.Drawing.Point(153, 155)
        Me.txtLineaAutorizada.Name = "txtLineaAutorizada"
        Me.txtLineaAutorizada.ReadOnly = True
        Me.txtLineaAutorizada.Size = New System.Drawing.Size(100, 20)
        Me.txtLineaAutorizada.TabIndex = 53
        Me.txtLineaAutorizada.TabStop = False
        Me.txtLineaAutorizada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(19, 156)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(109, 19)
        Me.Label16.TabIndex = 52
        Me.Label16.Text = "Línea autorizada"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(503, 661)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 49
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblSumaPagares)
        Me.GroupBox1.Controls.Add(Me.dgvPagares)
        Me.GroupBox1.Location = New System.Drawing.Point(555, 26)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(457, 201)
        Me.GroupBox1.TabIndex = 54
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pagarés Productor"
        '
        'lblSumaPagares
        '
        Me.lblSumaPagares.AutoSize = True
        Me.lblSumaPagares.Location = New System.Drawing.Point(169, 180)
        Me.lblSumaPagares.Name = "lblSumaPagares"
        Me.lblSumaPagares.Size = New System.Drawing.Size(171, 13)
        Me.lblSumaPagares.TabIndex = 20
        Me.lblSumaPagares.Text = "Suma de los pagarés capturados $"
        '
        'dgvPagares
        '
        Me.dgvPagares.AllowUserToAddRows = False
        Me.dgvPagares.AllowUserToDeleteRows = False
        Me.dgvPagares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPagares.Location = New System.Drawing.Point(10, 19)
        Me.dgvPagares.Name = "dgvPagares"
        Me.dgvPagares.ReadOnly = True
        Me.dgvPagares.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvPagares.Size = New System.Drawing.Size(430, 158)
        Me.dgvPagares.TabIndex = 18
        Me.dgvPagares.TabStop = False
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(19, 186)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(109, 19)
        Me.Label10.TabIndex = 90
        Me.Label10.Text = "No. de Hectáreas"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtHectareasActual
        '
        Me.txtHectareasActual.Location = New System.Drawing.Point(153, 185)
        Me.txtHectareasActual.Name = "txtHectareasActual"
        Me.txtHectareasActual.ReadOnly = True
        Me.txtHectareasActual.Size = New System.Drawing.Size(100, 20)
        Me.txtHectareasActual.TabIndex = 89
        Me.txtHectareasActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblAnexo
        '
        Me.lblAnexo.AutoSize = True
        Me.lblAnexo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAnexo.Location = New System.Drawing.Point(19, 26)
        Me.lblAnexo.Name = "lblAnexo"
        Me.lblAnexo.Size = New System.Drawing.Size(45, 13)
        Me.lblAnexo.TabIndex = 91
        Me.lblAnexo.Text = "Label1"
        '
        'txtBanco
        '
        Me.txtBanco.Location = New System.Drawing.Point(408, 125)
        Me.txtBanco.Name = "txtBanco"
        Me.txtBanco.ReadOnly = True
        Me.txtBanco.Size = New System.Drawing.Size(117, 20)
        Me.txtBanco.TabIndex = 92
        Me.txtBanco.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCuentaBancomer
        '
        Me.txtCuentaBancomer.Location = New System.Drawing.Point(398, 155)
        Me.txtCuentaBancomer.Name = "txtCuentaBancomer"
        Me.txtCuentaBancomer.ReadOnly = True
        Me.txtCuentaBancomer.Size = New System.Drawing.Size(127, 20)
        Me.txtCuentaBancomer.TabIndex = 93
        Me.txtCuentaBancomer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCuentaCLABE
        '
        Me.txtCuentaCLABE.Location = New System.Drawing.Point(398, 185)
        Me.txtCuentaCLABE.Name = "txtCuentaCLABE"
        Me.txtCuentaCLABE.ReadOnly = True
        Me.txtCuentaCLABE.Size = New System.Drawing.Size(127, 20)
        Me.txtCuentaCLABE.TabIndex = 94
        Me.txtCuentaCLABE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(291, 132)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 95
        Me.Label1.Text = "Banco"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(291, 162)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 13)
        Me.Label2.TabIndex = 96
        Me.Label2.Text = "Cuenta Bancomer"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(291, 192)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 97
        Me.Label3.Text = "Cuenta CLABE"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCiclo
        '
        Me.txtCiclo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCiclo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCiclo.Location = New System.Drawing.Point(22, 58)
        Me.txtCiclo.Name = "txtCiclo"
        Me.txtCiclo.ReadOnly = True
        Me.txtCiclo.Size = New System.Drawing.Size(503, 13)
        Me.txtCiclo.TabIndex = 99
        Me.txtCiclo.TabStop = False
        '
        'frmAgricola
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1024, 702)
        Me.Controls.Add(Me.txtCiclo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCuentaCLABE)
        Me.Controls.Add(Me.txtCuentaBancomer)
        Me.Controls.Add(Me.txtBanco)
        Me.Controls.Add(Me.lblAnexo)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtHectareasActual)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtLineaAutorizada)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.GroupBox4)
        Me.Name = "frmAgricola"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Control de Ministraciones"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.panelFIRA.ResumeLayout(False)
        Me.panelFIRA.PerformLayout()
        CType(Me.dgvFIRA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.panelFINAGIL.ResumeLayout(False)
        Me.panelFINAGIL.PerformLayout()
        CType(Me.dgvFINAGIL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvPagares, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnInsertarFIRA As System.Windows.Forms.Button
    Friend WithEvents dgvFIRA As System.Windows.Forms.DataGridView
    Friend WithEvents btnModificarFIRA As System.Windows.Forms.Button
    Friend WithEvents btnModificarFINAGIL As System.Windows.Forms.Button
    Friend WithEvents btnInsertarFINAGIL As System.Windows.Forms.Button
    Friend WithEvents dgvFINAGIL As System.Windows.Forms.DataGridView
    Friend WithEvents panelFINAGIL As System.Windows.Forms.Panel
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents cbDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtImporteFINAGIL As System.Windows.Forms.TextBox
    Friend WithEvents btnGuardarFINAGIL As System.Windows.Forms.Button
    Friend WithEvents btnCancelarFINAGIL As System.Windows.Forms.Button
    Friend WithEvents panelFIRA As System.Windows.Forms.Panel
    Friend WithEvents btnCancelarFIRA As System.Windows.Forms.Button
    Friend WithEvents btnGuardarFIRA As System.Windows.Forms.Button
    Friend WithEvents cbFEGA As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents dtpFechaFIRA As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtImporteFIRA As System.Windows.Forms.TextBox
    Friend WithEvents lblMinistradoFIRA As System.Windows.Forms.Label
    Friend WithEvents lblMinistradoFINAGIL As System.Windows.Forms.Label
    Friend WithEvents txtLineaAutorizada As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblSumaPagares As System.Windows.Forms.Label
    Friend WithEvents dgvPagares As System.Windows.Forms.DataGridView
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtHectareasActual As System.Windows.Forms.TextBox
    Friend WithEvents lblAnexo As System.Windows.Forms.Label
    Friend WithEvents txtBanco As System.Windows.Forms.TextBox
    Friend WithEvents txtCuentaBancomer As System.Windows.Forms.TextBox
    Friend WithEvents txtCuentaCLABE As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCiclo As System.Windows.Forms.TextBox
End Class
