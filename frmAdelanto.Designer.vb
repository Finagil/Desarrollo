<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdelanto
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnProcesar = New System.Windows.Forms.Button
        Me.lblFechaPago = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtSerie = New System.Windows.Forms.TextBox
        Me.txtAbonoOtros = New System.Windows.Forms.TextBox
        Me.lblAbonoOtros = New System.Windows.Forms.Label
        Me.lblSaldoOtros = New System.Windows.Forms.Label
        Me.txtSaldoOtros = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblConRec = New System.Windows.Forms.Label
        Me.txtFactura = New System.Windows.Forms.TextBox
        Me.lblDG = New System.Windows.Forms.Label
        Me.lblID = New System.Windows.Forms.Label
        Me.lblAbonoSeguro = New System.Windows.Forms.Label
        Me.txtDG = New System.Windows.Forms.TextBox
        Me.txtID = New System.Windows.Forms.TextBox
        Me.txtAbonoSeguro = New System.Windows.Forms.TextBox
        Me.txtIvaCapital = New System.Windows.Forms.TextBox
        Me.txtAbonoEquipo = New System.Windows.Forms.TextBox
        Me.lblIvaCapital = New System.Windows.Forms.Label
        Me.lblAbonoEquipo = New System.Windows.Forms.Label
        Me.btnAplicar = New System.Windows.Forms.Button
        Me.btnCalcular = New System.Windows.Forms.Button
        Me.txtIvaIntereses = New System.Windows.Forms.TextBox
        Me.lblIvaIntereses = New System.Windows.Forms.Label
        Me.txtUDIFinal = New System.Windows.Forms.TextBox
        Me.lblUdiFinal = New System.Windows.Forms.Label
        Me.txtUDIInicial = New System.Windows.Forms.TextBox
        Me.lblUdiInicial = New System.Windows.Forms.Label
        Me.txtIntereses = New System.Windows.Forms.TextBox
        Me.lblIntereses = New System.Windows.Forms.Label
        Me.txtTasaAplicada = New System.Windows.Forms.TextBox
        Me.lblTasaAplicada = New System.Windows.Forms.Label
        Me.txtDiasIntereses = New System.Windows.Forms.TextBox
        Me.lblDiasIntereses = New System.Windows.Forms.Label
        Me.txtSaldoSeguro = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.lblSaldoSeguro = New System.Windows.Forms.Label
        Me.txtIvaComision = New System.Windows.Forms.TextBox
        Me.txtIvaDiferido = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.lblIvaComision = New System.Windows.Forms.Label
        Me.lblIvaDiferido = New System.Windows.Forms.Label
        Me.txtComision = New System.Windows.Forms.TextBox
        Me.lblComision = New System.Windows.Forms.Label
        Me.txtImpDG = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.lblDeposito = New System.Windows.Forms.Label
        Me.txtPenalizacion = New System.Windows.Forms.TextBox
        Me.lblPenalizacion = New System.Windows.Forms.Label
        Me.txtSaldoEquipo = New System.Windows.Forms.TextBox
        Me.lblSaldoEquipo = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtCheque = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cbBancos = New System.Windows.Forms.ComboBox
        Me.txtImportePago = New System.Windows.Forms.TextBox
        Me.btnSalir = New System.Windows.Forms.Button
        Me.txtAnexo = New System.Windows.Forms.TextBox
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblAdeudaRentas = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnProcesar
        '
        Me.btnProcesar.Location = New System.Drawing.Point(641, 40)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(80, 24)
        Me.btnProcesar.TabIndex = 4
        Me.btnProcesar.Text = "Procesar"
        '
        'lblFechaPago
        '
        Me.lblFechaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaPago.Location = New System.Drawing.Point(528, 13)
        Me.lblFechaPago.Name = "lblFechaPago"
        Me.lblFechaPago.Size = New System.Drawing.Size(110, 23)
        Me.lblFechaPago.TabIndex = 66
        Me.lblFechaPago.Text = "Fecha de Pago"
        Me.lblFechaPago.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(531, 42)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(88, 20)
        Me.DateTimePicker1.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtSerie)
        Me.GroupBox1.Controls.Add(Me.txtAbonoOtros)
        Me.GroupBox1.Controls.Add(Me.lblAbonoOtros)
        Me.GroupBox1.Controls.Add(Me.lblSaldoOtros)
        Me.GroupBox1.Controls.Add(Me.txtSaldoOtros)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lblConRec)
        Me.GroupBox1.Controls.Add(Me.txtFactura)
        Me.GroupBox1.Controls.Add(Me.lblDG)
        Me.GroupBox1.Controls.Add(Me.lblID)
        Me.GroupBox1.Controls.Add(Me.lblAbonoSeguro)
        Me.GroupBox1.Controls.Add(Me.txtDG)
        Me.GroupBox1.Controls.Add(Me.txtID)
        Me.GroupBox1.Controls.Add(Me.txtAbonoSeguro)
        Me.GroupBox1.Controls.Add(Me.txtIvaCapital)
        Me.GroupBox1.Controls.Add(Me.txtAbonoEquipo)
        Me.GroupBox1.Controls.Add(Me.lblIvaCapital)
        Me.GroupBox1.Controls.Add(Me.lblAbonoEquipo)
        Me.GroupBox1.Controls.Add(Me.btnAplicar)
        Me.GroupBox1.Controls.Add(Me.btnCalcular)
        Me.GroupBox1.Controls.Add(Me.txtIvaIntereses)
        Me.GroupBox1.Controls.Add(Me.lblIvaIntereses)
        Me.GroupBox1.Controls.Add(Me.txtUDIFinal)
        Me.GroupBox1.Controls.Add(Me.lblUdiFinal)
        Me.GroupBox1.Controls.Add(Me.txtUDIInicial)
        Me.GroupBox1.Controls.Add(Me.lblUdiInicial)
        Me.GroupBox1.Controls.Add(Me.txtIntereses)
        Me.GroupBox1.Controls.Add(Me.lblIntereses)
        Me.GroupBox1.Controls.Add(Me.txtTasaAplicada)
        Me.GroupBox1.Controls.Add(Me.lblTasaAplicada)
        Me.GroupBox1.Controls.Add(Me.txtDiasIntereses)
        Me.GroupBox1.Controls.Add(Me.lblDiasIntereses)
        Me.GroupBox1.Controls.Add(Me.txtSaldoSeguro)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.lblSaldoSeguro)
        Me.GroupBox1.Controls.Add(Me.txtIvaComision)
        Me.GroupBox1.Controls.Add(Me.txtIvaDiferido)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.lblIvaComision)
        Me.GroupBox1.Controls.Add(Me.lblIvaDiferido)
        Me.GroupBox1.Controls.Add(Me.txtComision)
        Me.GroupBox1.Controls.Add(Me.lblComision)
        Me.GroupBox1.Controls.Add(Me.txtImpDG)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.lblDeposito)
        Me.GroupBox1.Controls.Add(Me.txtPenalizacion)
        Me.GroupBox1.Controls.Add(Me.lblPenalizacion)
        Me.GroupBox1.Controls.Add(Me.txtSaldoEquipo)
        Me.GroupBox1.Controls.Add(Me.lblSaldoEquipo)
        Me.GroupBox1.Location = New System.Drawing.Point(77, 121)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(741, 363)
        Me.GroupBox1.TabIndex = 64
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Visible = False
        '
        'txtSerie
        '
        Me.txtSerie.Location = New System.Drawing.Point(147, 326)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.ReadOnly = True
        Me.txtSerie.Size = New System.Drawing.Size(32, 20)
        Me.txtSerie.TabIndex = 119
        Me.txtSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtAbonoOtros
        '
        Me.txtAbonoOtros.Location = New System.Drawing.Point(610, 150)
        Me.txtAbonoOtros.Name = "txtAbonoOtros"
        Me.txtAbonoOtros.ReadOnly = True
        Me.txtAbonoOtros.Size = New System.Drawing.Size(100, 20)
        Me.txtAbonoOtros.TabIndex = 118
        Me.txtAbonoOtros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAbonoOtros.Visible = False
        '
        'lblAbonoOtros
        '
        Me.lblAbonoOtros.Location = New System.Drawing.Point(400, 152)
        Me.lblAbonoOtros.Name = "lblAbonoOtros"
        Me.lblAbonoOtros.Size = New System.Drawing.Size(204, 16)
        Me.lblAbonoOtros.TabIndex = 117
        Me.lblAbonoOtros.Text = "Adelanto Capital Otros Adeudos"
        Me.lblAbonoOtros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblAbonoOtros.Visible = False
        '
        'lblSaldoOtros
        '
        Me.lblSaldoOtros.Location = New System.Drawing.Point(29, 127)
        Me.lblSaldoOtros.Name = "lblSaldoOtros"
        Me.lblSaldoOtros.Size = New System.Drawing.Size(164, 16)
        Me.lblSaldoOtros.TabIndex = 116
        Me.lblSaldoOtros.Text = "Saldo Otros Adeudos"
        Me.lblSaldoOtros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSaldoOtros
        '
        Me.txtSaldoOtros.Location = New System.Drawing.Point(195, 125)
        Me.txtSaldoOtros.Name = "txtSaldoOtros"
        Me.txtSaldoOtros.ReadOnly = True
        Me.txtSaldoOtros.Size = New System.Drawing.Size(100, 20)
        Me.txtSaldoOtros.TabIndex = 115
        Me.txtSaldoOtros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 127)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(14, 17)
        Me.Label2.TabIndex = 114
        Me.Label2.Text = "+"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblConRec
        '
        Me.lblConRec.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConRec.Location = New System.Drawing.Point(132, 302)
        Me.lblConRec.Name = "lblConRec"
        Me.lblConRec.Size = New System.Drawing.Size(163, 23)
        Me.lblConRec.TabIndex = 113
        Me.lblConRec.Text = "Factura de Pago a Imprimir"
        Me.lblConRec.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFactura
        '
        Me.txtFactura.Location = New System.Drawing.Point(187, 326)
        Me.txtFactura.Name = "txtFactura"
        Me.txtFactura.Size = New System.Drawing.Size(89, 20)
        Me.txtFactura.TabIndex = 10
        Me.txtFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDG
        '
        Me.lblDG.Location = New System.Drawing.Point(400, 252)
        Me.lblDG.Name = "lblDG"
        Me.lblDG.Size = New System.Drawing.Size(204, 16)
        Me.lblDG.TabIndex = 69
        Me.lblDG.Text = "Aplicación Depósito vs Capital"
        Me.lblDG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblDG.Visible = False
        '
        'lblID
        '
        Me.lblID.Location = New System.Drawing.Point(400, 202)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(204, 16)
        Me.lblID.TabIndex = 70
        Me.lblID.Text = "Aplicación Depósito vs IVA del Capital"
        Me.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblID.Visible = False
        '
        'lblAbonoSeguro
        '
        Me.lblAbonoSeguro.Location = New System.Drawing.Point(400, 127)
        Me.lblAbonoSeguro.Name = "lblAbonoSeguro"
        Me.lblAbonoSeguro.Size = New System.Drawing.Size(204, 16)
        Me.lblAbonoSeguro.TabIndex = 71
        Me.lblAbonoSeguro.Text = "Adelanto Capital Seguro"
        Me.lblAbonoSeguro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblAbonoSeguro.Visible = False
        '
        'txtDG
        '
        Me.txtDG.Location = New System.Drawing.Point(610, 250)
        Me.txtDG.Name = "txtDG"
        Me.txtDG.ReadOnly = True
        Me.txtDG.Size = New System.Drawing.Size(100, 20)
        Me.txtDG.TabIndex = 107
        Me.txtDG.TabStop = False
        Me.txtDG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtDG.Visible = False
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(610, 200)
        Me.txtID.Name = "txtID"
        Me.txtID.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(100, 20)
        Me.txtID.TabIndex = 106
        Me.txtID.TabStop = False
        Me.txtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtID.Visible = False
        '
        'txtAbonoSeguro
        '
        Me.txtAbonoSeguro.Location = New System.Drawing.Point(610, 125)
        Me.txtAbonoSeguro.Name = "txtAbonoSeguro"
        Me.txtAbonoSeguro.ReadOnly = True
        Me.txtAbonoSeguro.Size = New System.Drawing.Size(100, 20)
        Me.txtAbonoSeguro.TabIndex = 105
        Me.txtAbonoSeguro.TabStop = False
        Me.txtAbonoSeguro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAbonoSeguro.Visible = False
        '
        'txtIvaCapital
        '
        Me.txtIvaCapital.Location = New System.Drawing.Point(610, 175)
        Me.txtIvaCapital.Name = "txtIvaCapital"
        Me.txtIvaCapital.ReadOnly = True
        Me.txtIvaCapital.Size = New System.Drawing.Size(100, 20)
        Me.txtIvaCapital.TabIndex = 104
        Me.txtIvaCapital.TabStop = False
        Me.txtIvaCapital.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtIvaCapital.Visible = False
        '
        'txtAbonoEquipo
        '
        Me.txtAbonoEquipo.Location = New System.Drawing.Point(610, 225)
        Me.txtAbonoEquipo.Name = "txtAbonoEquipo"
        Me.txtAbonoEquipo.ReadOnly = True
        Me.txtAbonoEquipo.Size = New System.Drawing.Size(100, 20)
        Me.txtAbonoEquipo.TabIndex = 103
        Me.txtAbonoEquipo.TabStop = False
        Me.txtAbonoEquipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAbonoEquipo.Visible = False
        '
        'lblIvaCapital
        '
        Me.lblIvaCapital.Location = New System.Drawing.Point(400, 177)
        Me.lblIvaCapital.Name = "lblIvaCapital"
        Me.lblIvaCapital.Size = New System.Drawing.Size(204, 16)
        Me.lblIvaCapital.TabIndex = 102
        Me.lblIvaCapital.Text = "IVA del Capital"
        Me.lblIvaCapital.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblIvaCapital.Visible = False
        '
        'lblAbonoEquipo
        '
        Me.lblAbonoEquipo.Location = New System.Drawing.Point(400, 227)
        Me.lblAbonoEquipo.Name = "lblAbonoEquipo"
        Me.lblAbonoEquipo.Size = New System.Drawing.Size(204, 16)
        Me.lblAbonoEquipo.TabIndex = 101
        Me.lblAbonoEquipo.Text = "Adelanto Capital Equipo"
        Me.lblAbonoEquipo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblAbonoEquipo.Visible = False
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(437, 325)
        Me.btnAplicar.Name = "btnAplicar"
        Me.btnAplicar.Size = New System.Drawing.Size(64, 24)
        Me.btnAplicar.TabIndex = 9
        Me.btnAplicar.Text = "Aplicar"
        '
        'btnCalcular
        '
        Me.btnCalcular.Location = New System.Drawing.Point(349, 325)
        Me.btnCalcular.Name = "btnCalcular"
        Me.btnCalcular.Size = New System.Drawing.Size(64, 24)
        Me.btnCalcular.TabIndex = 8
        Me.btnCalcular.Text = "Calcular"
        '
        'txtIvaIntereses
        '
        Me.txtIvaIntereses.Location = New System.Drawing.Point(610, 50)
        Me.txtIvaIntereses.Name = "txtIvaIntereses"
        Me.txtIvaIntereses.ReadOnly = True
        Me.txtIvaIntereses.Size = New System.Drawing.Size(100, 20)
        Me.txtIvaIntereses.TabIndex = 92
        Me.txtIvaIntereses.TabStop = False
        Me.txtIvaIntereses.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtIvaIntereses.Visible = False
        '
        'lblIvaIntereses
        '
        Me.lblIvaIntereses.Location = New System.Drawing.Point(400, 52)
        Me.lblIvaIntereses.Name = "lblIvaIntereses"
        Me.lblIvaIntereses.Size = New System.Drawing.Size(204, 16)
        Me.lblIvaIntereses.TabIndex = 90
        Me.lblIvaIntereses.Text = "IVA de los Intereses"
        Me.lblIvaIntereses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblIvaIntereses.Visible = False
        '
        'txtUDIFinal
        '
        Me.txtUDIFinal.Location = New System.Drawing.Point(195, 200)
        Me.txtUDIFinal.Name = "txtUDIFinal"
        Me.txtUDIFinal.ReadOnly = True
        Me.txtUDIFinal.Size = New System.Drawing.Size(100, 20)
        Me.txtUDIFinal.TabIndex = 89
        Me.txtUDIFinal.TabStop = False
        Me.txtUDIFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblUdiFinal
        '
        Me.lblUdiFinal.Location = New System.Drawing.Point(29, 202)
        Me.lblUdiFinal.Name = "lblUdiFinal"
        Me.lblUdiFinal.Size = New System.Drawing.Size(164, 16)
        Me.lblUdiFinal.TabIndex = 88
        Me.lblUdiFinal.Text = "UDI Final"
        Me.lblUdiFinal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUDIInicial
        '
        Me.txtUDIInicial.Location = New System.Drawing.Point(195, 175)
        Me.txtUDIInicial.Name = "txtUDIInicial"
        Me.txtUDIInicial.ReadOnly = True
        Me.txtUDIInicial.Size = New System.Drawing.Size(100, 20)
        Me.txtUDIInicial.TabIndex = 87
        Me.txtUDIInicial.TabStop = False
        Me.txtUDIInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblUdiInicial
        '
        Me.lblUdiInicial.Location = New System.Drawing.Point(29, 177)
        Me.lblUdiInicial.Name = "lblUdiInicial"
        Me.lblUdiInicial.Size = New System.Drawing.Size(164, 16)
        Me.lblUdiInicial.TabIndex = 86
        Me.lblUdiInicial.Text = "UDI Inicial"
        Me.lblUdiInicial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtIntereses
        '
        Me.txtIntereses.Location = New System.Drawing.Point(610, 25)
        Me.txtIntereses.Name = "txtIntereses"
        Me.txtIntereses.ReadOnly = True
        Me.txtIntereses.Size = New System.Drawing.Size(100, 20)
        Me.txtIntereses.TabIndex = 84
        Me.txtIntereses.TabStop = False
        Me.txtIntereses.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtIntereses.Visible = False
        '
        'lblIntereses
        '
        Me.lblIntereses.Location = New System.Drawing.Point(400, 27)
        Me.lblIntereses.Name = "lblIntereses"
        Me.lblIntereses.Size = New System.Drawing.Size(204, 16)
        Me.lblIntereses.TabIndex = 81
        Me.lblIntereses.Text = "Intereses"
        Me.lblIntereses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblIntereses.Visible = False
        '
        'txtTasaAplicada
        '
        Me.txtTasaAplicada.Location = New System.Drawing.Point(195, 150)
        Me.txtTasaAplicada.Name = "txtTasaAplicada"
        Me.txtTasaAplicada.ReadOnly = True
        Me.txtTasaAplicada.Size = New System.Drawing.Size(100, 20)
        Me.txtTasaAplicada.TabIndex = 80
        Me.txtTasaAplicada.TabStop = False
        Me.txtTasaAplicada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTasaAplicada
        '
        Me.lblTasaAplicada.Location = New System.Drawing.Point(29, 152)
        Me.lblTasaAplicada.Name = "lblTasaAplicada"
        Me.lblTasaAplicada.Size = New System.Drawing.Size(164, 16)
        Me.lblTasaAplicada.TabIndex = 79
        Me.lblTasaAplicada.Text = "Tasa Aplicada (%)"
        Me.lblTasaAplicada.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDiasIntereses
        '
        Me.txtDiasIntereses.Location = New System.Drawing.Point(195, 250)
        Me.txtDiasIntereses.Name = "txtDiasIntereses"
        Me.txtDiasIntereses.Size = New System.Drawing.Size(100, 20)
        Me.txtDiasIntereses.TabIndex = 7
        Me.txtDiasIntereses.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDiasIntereses
        '
        Me.lblDiasIntereses.Location = New System.Drawing.Point(29, 252)
        Me.lblDiasIntereses.Name = "lblDiasIntereses"
        Me.lblDiasIntereses.Size = New System.Drawing.Size(164, 16)
        Me.lblDiasIntereses.TabIndex = 74
        Me.lblDiasIntereses.Text = "Días de Intereses"
        Me.lblDiasIntereses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSaldoSeguro
        '
        Me.txtSaldoSeguro.Location = New System.Drawing.Point(195, 100)
        Me.txtSaldoSeguro.Name = "txtSaldoSeguro"
        Me.txtSaldoSeguro.ReadOnly = True
        Me.txtSaldoSeguro.Size = New System.Drawing.Size(100, 20)
        Me.txtSaldoSeguro.TabIndex = 61
        Me.txtSaldoSeguro.TabStop = False
        Me.txtSaldoSeguro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(14, 102)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(14, 17)
        Me.Label25.TabIndex = 58
        Me.Label25.Text = "+"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSaldoSeguro
        '
        Me.lblSaldoSeguro.Location = New System.Drawing.Point(29, 102)
        Me.lblSaldoSeguro.Name = "lblSaldoSeguro"
        Me.lblSaldoSeguro.Size = New System.Drawing.Size(164, 16)
        Me.lblSaldoSeguro.TabIndex = 56
        Me.lblSaldoSeguro.Text = "Saldo Insoluto Seguro"
        Me.lblSaldoSeguro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtIvaComision
        '
        Me.txtIvaComision.Location = New System.Drawing.Point(610, 100)
        Me.txtIvaComision.Name = "txtIvaComision"
        Me.txtIvaComision.ReadOnly = True
        Me.txtIvaComision.Size = New System.Drawing.Size(100, 20)
        Me.txtIvaComision.TabIndex = 54
        Me.txtIvaComision.TabStop = False
        Me.txtIvaComision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtIvaComision.Visible = False
        '
        'txtIvaDiferido
        '
        Me.txtIvaDiferido.Location = New System.Drawing.Point(195, 75)
        Me.txtIvaDiferido.Name = "txtIvaDiferido"
        Me.txtIvaDiferido.ReadOnly = True
        Me.txtIvaDiferido.Size = New System.Drawing.Size(100, 20)
        Me.txtIvaDiferido.TabIndex = 55
        Me.txtIvaDiferido.TabStop = False
        Me.txtIvaDiferido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(14, 77)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(14, 17)
        Me.Label24.TabIndex = 52
        Me.Label24.Text = "+"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIvaComision
        '
        Me.lblIvaComision.Location = New System.Drawing.Point(400, 102)
        Me.lblIvaComision.Name = "lblIvaComision"
        Me.lblIvaComision.Size = New System.Drawing.Size(204, 16)
        Me.lblIvaComision.TabIndex = 51
        Me.lblIvaComision.Text = "IVA de la Comisión"
        Me.lblIvaComision.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblIvaComision.Visible = False
        '
        'lblIvaDiferido
        '
        Me.lblIvaDiferido.Location = New System.Drawing.Point(29, 77)
        Me.lblIvaDiferido.Name = "lblIvaDiferido"
        Me.lblIvaDiferido.Size = New System.Drawing.Size(164, 16)
        Me.lblIvaDiferido.TabIndex = 50
        Me.lblIvaDiferido.Text = "IVA Diferido"
        Me.lblIvaDiferido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComision
        '
        Me.txtComision.Location = New System.Drawing.Point(610, 75)
        Me.txtComision.Name = "txtComision"
        Me.txtComision.ReadOnly = True
        Me.txtComision.Size = New System.Drawing.Size(100, 20)
        Me.txtComision.TabIndex = 66
        Me.txtComision.TabStop = False
        Me.txtComision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtComision.Visible = False
        '
        'lblComision
        '
        Me.lblComision.Location = New System.Drawing.Point(400, 77)
        Me.lblComision.Name = "lblComision"
        Me.lblComision.Size = New System.Drawing.Size(204, 16)
        Me.lblComision.TabIndex = 47
        Me.lblComision.Text = "Comisión por Adelanto"
        Me.lblComision.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblComision.Visible = False
        '
        'txtImpDG
        '
        Me.txtImpDG.Location = New System.Drawing.Point(195, 50)
        Me.txtImpDG.Name = "txtImpDG"
        Me.txtImpDG.ReadOnly = True
        Me.txtImpDG.Size = New System.Drawing.Size(100, 20)
        Me.txtImpDG.TabIndex = 60
        Me.txtImpDG.TabStop = False
        Me.txtImpDG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(14, 52)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(12, 16)
        Me.Label21.TabIndex = 44
        Me.Label21.Text = "-"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDeposito
        '
        Me.lblDeposito.Location = New System.Drawing.Point(29, 52)
        Me.lblDeposito.Name = "lblDeposito"
        Me.lblDeposito.Size = New System.Drawing.Size(164, 16)
        Me.lblDeposito.TabIndex = 43
        Me.lblDeposito.Text = "Depósito en Garantía"
        Me.lblDeposito.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPenalizacion
        '
        Me.txtPenalizacion.Location = New System.Drawing.Point(195, 225)
        Me.txtPenalizacion.Name = "txtPenalizacion"
        Me.txtPenalizacion.Size = New System.Drawing.Size(100, 20)
        Me.txtPenalizacion.TabIndex = 6
        Me.txtPenalizacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPenalizacion
        '
        Me.lblPenalizacion.Location = New System.Drawing.Point(29, 227)
        Me.lblPenalizacion.Name = "lblPenalizacion"
        Me.lblPenalizacion.Size = New System.Drawing.Size(164, 16)
        Me.lblPenalizacion.TabIndex = 41
        Me.lblPenalizacion.Text = "Penalización (%)"
        Me.lblPenalizacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSaldoEquipo
        '
        Me.txtSaldoEquipo.Location = New System.Drawing.Point(195, 25)
        Me.txtSaldoEquipo.Name = "txtSaldoEquipo"
        Me.txtSaldoEquipo.ReadOnly = True
        Me.txtSaldoEquipo.Size = New System.Drawing.Size(100, 20)
        Me.txtSaldoEquipo.TabIndex = 77
        Me.txtSaldoEquipo.TabStop = False
        Me.txtSaldoEquipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSaldoEquipo
        '
        Me.lblSaldoEquipo.Location = New System.Drawing.Point(29, 27)
        Me.lblSaldoEquipo.Name = "lblSaldoEquipo"
        Me.lblSaldoEquipo.Size = New System.Drawing.Size(164, 16)
        Me.lblSaldoEquipo.TabIndex = 1
        Me.lblSaldoEquipo.Text = "Saldo Insoluto Equipo"
        Me.lblSaldoEquipo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(171, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 23)
        Me.Label4.TabIndex = 111
        Me.Label4.Text = "No. de Cheque"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCheque
        '
        Me.txtCheque.Location = New System.Drawing.Point(171, 42)
        Me.txtCheque.MaxLength = 15
        Me.txtCheque.Name = "txtCheque"
        Me.txtCheque.Size = New System.Drawing.Size(120, 20)
        Me.txtCheque.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(293, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(132, 23)
        Me.Label5.TabIndex = 109
        Me.Label5.Text = "Seleccione el Banco"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbBancos
        '
        Me.cbBancos.Location = New System.Drawing.Point(297, 42)
        Me.cbBancos.MaxDropDownItems = 10
        Me.cbBancos.Name = "cbBancos"
        Me.cbBancos.Size = New System.Drawing.Size(224, 21)
        Me.cbBancos.TabIndex = 2
        '
        'txtImportePago
        '
        Me.txtImportePago.Location = New System.Drawing.Point(77, 42)
        Me.txtImportePago.Name = "txtImportePago"
        Me.txtImportePago.Size = New System.Drawing.Size(88, 20)
        Me.txtImportePago.TabIndex = 0
        Me.txtImportePago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnSalir
        '
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.Location = New System.Drawing.Point(738, 40)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(80, 24)
        Me.btnSalir.TabIndex = 5
        Me.btnSalir.Text = "Salir"
        '
        'txtAnexo
        '
        Me.txtAnexo.Location = New System.Drawing.Point(26, 98)
        Me.txtAnexo.Name = "txtAnexo"
        Me.txtAnexo.Size = New System.Drawing.Size(17, 20)
        Me.txtAnexo.TabIndex = 67
        Me.txtAnexo.Visible = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 493)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(898, 22)
        Me.StatusStrip1.TabIndex = 68
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(132, 17)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(74, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 112
        Me.Label1.Text = "Monto del Pago"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAdeudaRentas
        '
        Me.lblAdeudaRentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdeudaRentas.Location = New System.Drawing.Point(125, 84)
        Me.lblAdeudaRentas.Name = "lblAdeudaRentas"
        Me.lblAdeudaRentas.Size = New System.Drawing.Size(444, 23)
        Me.lblAdeudaRentas.TabIndex = 126
        '
        'frmAdelanto
        '
        Me.AcceptButton = Me.btnProcesar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnSalir
        Me.ClientSize = New System.Drawing.Size(898, 515)
        Me.Controls.Add(Me.lblAdeudaRentas)
        Me.Controls.Add(Me.txtImportePago)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.txtAnexo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cbBancos)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCheque)
        Me.Controls.Add(Me.btnProcesar)
        Me.Controls.Add(Me.lblFechaPago)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnSalir)
        Me.Name = "frmAdelanto"
        Me.Text = "Adelanto a Capital"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents lblFechaPago As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnAplicar As System.Windows.Forms.Button
    Friend WithEvents btnCalcular As System.Windows.Forms.Button
    Friend WithEvents txtIvaIntereses As System.Windows.Forms.TextBox
    Friend WithEvents lblIvaIntereses As System.Windows.Forms.Label
    Friend WithEvents txtUDIFinal As System.Windows.Forms.TextBox
    Friend WithEvents lblUdiFinal As System.Windows.Forms.Label
    Friend WithEvents txtUDIInicial As System.Windows.Forms.TextBox
    Friend WithEvents lblUdiInicial As System.Windows.Forms.Label
    Friend WithEvents txtImportePago As System.Windows.Forms.TextBox
    Friend WithEvents txtIntereses As System.Windows.Forms.TextBox
    Friend WithEvents lblIntereses As System.Windows.Forms.Label
    Friend WithEvents txtTasaAplicada As System.Windows.Forms.TextBox
    Friend WithEvents lblTasaAplicada As System.Windows.Forms.Label
    Friend WithEvents txtDiasIntereses As System.Windows.Forms.TextBox
    Friend WithEvents lblDiasIntereses As System.Windows.Forms.Label
    Friend WithEvents txtSaldoSeguro As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents lblSaldoSeguro As System.Windows.Forms.Label
    Friend WithEvents txtIvaComision As System.Windows.Forms.TextBox
    Friend WithEvents txtIvaDiferido As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents lblIvaComision As System.Windows.Forms.Label
    Friend WithEvents lblIvaDiferido As System.Windows.Forms.Label
    Friend WithEvents txtComision As System.Windows.Forms.TextBox
    Friend WithEvents lblComision As System.Windows.Forms.Label
    Friend WithEvents txtImpDG As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lblDeposito As System.Windows.Forms.Label
    Friend WithEvents txtPenalizacion As System.Windows.Forms.TextBox
    Friend WithEvents lblPenalizacion As System.Windows.Forms.Label
    Friend WithEvents txtSaldoEquipo As System.Windows.Forms.TextBox
    Friend WithEvents lblSaldoEquipo As System.Windows.Forms.Label
    Friend WithEvents txtIvaCapital As System.Windows.Forms.TextBox
    Friend WithEvents txtAbonoEquipo As System.Windows.Forms.TextBox
    Friend WithEvents lblIvaCapital As System.Windows.Forms.Label
    Friend WithEvents lblAbonoEquipo As System.Windows.Forms.Label
    Friend WithEvents txtDG As System.Windows.Forms.TextBox
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents txtAbonoSeguro As System.Windows.Forms.TextBox
    Friend WithEvents lblDG As System.Windows.Forms.Label
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents lblAbonoSeguro As System.Windows.Forms.Label
    Friend WithEvents txtAnexo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbBancos As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCheque As System.Windows.Forms.TextBox
    Friend WithEvents lblConRec As System.Windows.Forms.Label
    Friend WithEvents txtFactura As System.Windows.Forms.TextBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblAdeudaRentas As System.Windows.Forms.Label
    Friend WithEvents txtSaldoOtros As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblSaldoOtros As System.Windows.Forms.Label
    Friend WithEvents txtAbonoOtros As System.Windows.Forms.TextBox
    Friend WithEvents lblAbonoOtros As System.Windows.Forms.Label
    Friend WithEvents txtSerie As System.Windows.Forms.TextBox
End Class
