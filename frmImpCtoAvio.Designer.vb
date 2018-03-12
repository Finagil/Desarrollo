<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImpCtoAvio
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
        Me.btnImprimir = New System.Windows.Forms.Button
        Me.btnSalir = New System.Windows.Forms.Button
        Me.gbDatosFINAGIL = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtNombreRepresentante = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtNombreProductor = New System.Windows.Forms.TextBox
        Me.txtAnexo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblFechaFirma = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblGarantiaPrendaria = New System.Windows.Forms.Label
        Me.lblGarantiaHipotecaria = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblGarantiaUsufructo = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblMontoCredito = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lbAvales = New System.Windows.Forms.ListBox
        Me.txtHectareas = New System.Windows.Forms.TextBox
        Me.lblHectareas = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtDiferencialFINAGIL = New System.Windows.Forms.TextBox
        Me.txtToneladasHectarea = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.lblNotarioRegistrador = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.ckbTrigo = New System.Windows.Forms.CheckBox
        Me.ckbMaiz = New System.Windows.Forms.CheckBox
        Me.ckbSorgo = New System.Windows.Forms.CheckBox
        Me.btnImpPagare = New System.Windows.Forms.Button
        Me.gbPagare = New System.Windows.Forms.GroupBox
        Me.txtImporte = New System.Windows.Forms.TextBox
        Me.dtpFFirma = New System.Windows.Forms.DateTimePicker
        Me.dtpFPago = New System.Windows.Forms.DateTimePicker
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.ckbCartamo = New System.Windows.Forms.CheckBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtPorcomi = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.txtGHipotecario = New System.Windows.Forms.TextBox
        Me.txtGPrendario = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.ckbAlgodon = New System.Windows.Forms.CheckBox
        Me.ckbGarbanzo = New System.Windows.Forms.CheckBox
        Me.gbDatosFINAGIL.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gbPagare.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnImprimir
        '
        Me.btnImprimir.Location = New System.Drawing.Point(926, 27)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(75, 23)
        Me.btnImprimir.TabIndex = 0
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(926, 109)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 70
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'gbDatosFINAGIL
        '
        Me.gbDatosFINAGIL.Controls.Add(Me.Label5)
        Me.gbDatosFINAGIL.Controls.Add(Me.txtNombreRepresentante)
        Me.gbDatosFINAGIL.Controls.Add(Me.Label6)
        Me.gbDatosFINAGIL.Controls.Add(Me.txtNombreProductor)
        Me.gbDatosFINAGIL.Location = New System.Drawing.Point(18, 10)
        Me.gbDatosFINAGIL.Name = "gbDatosFINAGIL"
        Me.gbDatosFINAGIL.Size = New System.Drawing.Size(885, 93)
        Me.gbDatosFINAGIL.TabIndex = 80
        Me.gbDatosFINAGIL.TabStop = False
        Me.gbDatosFINAGIL.Text = "Datos del Productor"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(6, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(143, 19)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "Nombre del Representante"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNombreRepresentante
        '
        Me.txtNombreRepresentante.Location = New System.Drawing.Point(151, 58)
        Me.txtNombreRepresentante.Name = "txtNombreRepresentante"
        Me.txtNombreRepresentante.ReadOnly = True
        Me.txtNombreRepresentante.Size = New System.Drawing.Size(639, 20)
        Me.txtNombreRepresentante.TabIndex = 55
        Me.txtNombreRepresentante.TabStop = False
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(6, 30)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(143, 19)
        Me.Label6.TabIndex = 54
        Me.Label6.Text = "Nombre o Razón Social"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNombreProductor
        '
        Me.txtNombreProductor.Location = New System.Drawing.Point(151, 30)
        Me.txtNombreProductor.Name = "txtNombreProductor"
        Me.txtNombreProductor.ReadOnly = True
        Me.txtNombreProductor.Size = New System.Drawing.Size(639, 20)
        Me.txtNombreProductor.TabIndex = 51
        Me.txtNombreProductor.TabStop = False
        '
        'txtAnexo
        '
        Me.txtAnexo.Location = New System.Drawing.Point(107, 334)
        Me.txtAnexo.Name = "txtAnexo"
        Me.txtAnexo.ReadOnly = True
        Me.txtAnexo.Size = New System.Drawing.Size(69, 20)
        Me.txtAnexo.TabIndex = 55
        Me.txtAnexo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(19, 335)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 19)
        Me.Label2.TabIndex = 49
        Me.Label2.Text = "No. de Contrato"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 393)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 83
        Me.Label1.Text = "Fecha de firma"
        '
        'lblFechaFirma
        '
        Me.lblFechaFirma.AutoSize = True
        Me.lblFechaFirma.Location = New System.Drawing.Point(126, 393)
        Me.lblFechaFirma.Name = "lblFechaFirma"
        Me.lblFechaFirma.Size = New System.Drawing.Size(77, 13)
        Me.lblFechaFirma.TabIndex = 84
        Me.lblFechaFirma.Text = "Fecha de firma"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 413)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 13)
        Me.Label3.TabIndex = 85
        Me.Label3.Text = "Garantía Prendaria"
        '
        'lblGarantiaPrendaria
        '
        Me.lblGarantiaPrendaria.AutoSize = True
        Me.lblGarantiaPrendaria.Location = New System.Drawing.Point(126, 413)
        Me.lblGarantiaPrendaria.Name = "lblGarantiaPrendaria"
        Me.lblGarantiaPrendaria.Size = New System.Drawing.Size(97, 13)
        Me.lblGarantiaPrendaria.TabIndex = 86
        Me.lblGarantiaPrendaria.Text = "Garantía Prendaria"
        '
        'lblGarantiaHipotecaria
        '
        Me.lblGarantiaHipotecaria.AutoSize = True
        Me.lblGarantiaHipotecaria.Location = New System.Drawing.Point(126, 432)
        Me.lblGarantiaHipotecaria.Name = "lblGarantiaHipotecaria"
        Me.lblGarantiaHipotecaria.Size = New System.Drawing.Size(106, 13)
        Me.lblGarantiaHipotecaria.TabIndex = 88
        Me.lblGarantiaHipotecaria.Text = "Garantía Hipotecaria"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 432)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(106, 13)
        Me.Label7.TabIndex = 87
        Me.Label7.Text = "Garantía Hipotecaria"
        '
        'lblGarantiaUsufructo
        '
        Me.lblGarantiaUsufructo.AutoSize = True
        Me.lblGarantiaUsufructo.Location = New System.Drawing.Point(126, 452)
        Me.lblGarantiaUsufructo.Name = "lblGarantiaUsufructo"
        Me.lblGarantiaUsufructo.Size = New System.Drawing.Size(23, 13)
        Me.lblGarantiaUsufructo.TabIndex = 90
        Me.lblGarantiaUsufructo.Text = "NO"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(15, 452)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 13)
        Me.Label9.TabIndex = 89
        Me.Label9.Text = "Garantía Usufructo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 472)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 13)
        Me.Label4.TabIndex = 91
        Me.Label4.Text = "Monto del Crédito"
        '
        'lblMontoCredito
        '
        Me.lblMontoCredito.AutoSize = True
        Me.lblMontoCredito.Location = New System.Drawing.Point(126, 472)
        Me.lblMontoCredito.Name = "lblMontoCredito"
        Me.lblMontoCredito.Size = New System.Drawing.Size(39, 13)
        Me.lblMontoCredito.TabIndex = 92
        Me.lblMontoCredito.Text = "Label5"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbAvales)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 109)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(885, 99)
        Me.GroupBox1.TabIndex = 94
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Aval o Avales"
        '
        'lbAvales
        '
        Me.lbAvales.BackColor = System.Drawing.SystemColors.Control
        Me.lbAvales.Location = New System.Drawing.Point(151, 18)
        Me.lbAvales.Name = "lbAvales"
        Me.lbAvales.Size = New System.Drawing.Size(639, 69)
        Me.lbAvales.TabIndex = 82
        '
        'txtHectareas
        '
        Me.txtHectareas.Location = New System.Drawing.Point(335, 334)
        Me.txtHectareas.Name = "txtHectareas"
        Me.txtHectareas.ReadOnly = True
        Me.txtHectareas.Size = New System.Drawing.Size(51, 20)
        Me.txtHectareas.TabIndex = 96
        Me.txtHectareas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblHectareas
        '
        Me.lblHectareas.Location = New System.Drawing.Point(218, 335)
        Me.lblHectareas.Name = "lblHectareas"
        Me.lblHectareas.Size = New System.Drawing.Size(114, 19)
        Me.lblHectareas.TabIndex = 95
        Me.lblHectareas.Text = "Hectáreas a Habilitar"
        Me.lblHectareas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(696, 335)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(161, 19)
        Me.Label18.TabIndex = 102
        Me.Label18.Text = "Diferencial FINAGIL-Productor"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDiferencialFINAGIL
        '
        Me.txtDiferencialFINAGIL.Location = New System.Drawing.Point(859, 334)
        Me.txtDiferencialFINAGIL.Name = "txtDiferencialFINAGIL"
        Me.txtDiferencialFINAGIL.ReadOnly = True
        Me.txtDiferencialFINAGIL.Size = New System.Drawing.Size(43, 20)
        Me.txtDiferencialFINAGIL.TabIndex = 101
        Me.txtDiferencialFINAGIL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtToneladasHectarea
        '
        Me.txtToneladasHectarea.Location = New System.Drawing.Point(581, 335)
        Me.txtToneladasHectarea.Name = "txtToneladasHectarea"
        Me.txtToneladasHectarea.ReadOnly = True
        Me.txtToneladasHectarea.Size = New System.Drawing.Size(50, 20)
        Me.txtToneladasHectarea.TabIndex = 103
        Me.txtToneladasHectarea.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(443, 335)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(135, 19)
        Me.Label8.TabIndex = 104
        Me.Label8.Text = "Toneladas por Hectárea"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNotarioRegistrador
        '
        Me.lblNotarioRegistrador.AutoSize = True
        Me.lblNotarioRegistrador.Location = New System.Drawing.Point(15, 680)
        Me.lblNotarioRegistrador.Name = "lblNotarioRegistrador"
        Me.lblNotarioRegistrador.Size = New System.Drawing.Size(45, 13)
        Me.lblNotarioRegistrador.TabIndex = 105
        Me.lblNotarioRegistrador.Text = "Label10"
        Me.lblNotarioRegistrador.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(15, 521)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(77, 13)
        Me.Label10.TabIndex = 106
        Me.Label10.Text = "Contrato para :"
        '
        'ckbTrigo
        '
        Me.ckbTrigo.AutoSize = True
        Me.ckbTrigo.Location = New System.Drawing.Point(104, 521)
        Me.ckbTrigo.Name = "ckbTrigo"
        Me.ckbTrigo.Size = New System.Drawing.Size(50, 17)
        Me.ckbTrigo.TabIndex = 107
        Me.ckbTrigo.Text = "Trigo"
        Me.ckbTrigo.UseVisualStyleBackColor = True
        '
        'ckbMaiz
        '
        Me.ckbMaiz.AutoSize = True
        Me.ckbMaiz.Location = New System.Drawing.Point(158, 521)
        Me.ckbMaiz.Name = "ckbMaiz"
        Me.ckbMaiz.Size = New System.Drawing.Size(48, 17)
        Me.ckbMaiz.TabIndex = 108
        Me.ckbMaiz.Text = "Maiz"
        Me.ckbMaiz.UseVisualStyleBackColor = True
        '
        'ckbSorgo
        '
        Me.ckbSorgo.AutoSize = True
        Me.ckbSorgo.Location = New System.Drawing.Point(210, 521)
        Me.ckbSorgo.Name = "ckbSorgo"
        Me.ckbSorgo.Size = New System.Drawing.Size(54, 17)
        Me.ckbSorgo.TabIndex = 109
        Me.ckbSorgo.Text = "Sorgo"
        Me.ckbSorgo.UseVisualStyleBackColor = True
        '
        'btnImpPagare
        '
        Me.btnImpPagare.Location = New System.Drawing.Point(926, 64)
        Me.btnImpPagare.Name = "btnImpPagare"
        Me.btnImpPagare.Size = New System.Drawing.Size(75, 23)
        Me.btnImpPagare.TabIndex = 110
        Me.btnImpPagare.Text = "Imp. Pagaré"
        Me.btnImpPagare.UseVisualStyleBackColor = True
        '
        'gbPagare
        '
        Me.gbPagare.Controls.Add(Me.txtImporte)
        Me.gbPagare.Controls.Add(Me.dtpFFirma)
        Me.gbPagare.Controls.Add(Me.dtpFPago)
        Me.gbPagare.Controls.Add(Me.Label14)
        Me.gbPagare.Controls.Add(Me.Label13)
        Me.gbPagare.Controls.Add(Me.Label11)
        Me.gbPagare.Location = New System.Drawing.Point(565, 521)
        Me.gbPagare.Name = "gbPagare"
        Me.gbPagare.Size = New System.Drawing.Size(261, 138)
        Me.gbPagare.TabIndex = 111
        Me.gbPagare.TabStop = False
        Me.gbPagare.Text = "Datos para Imprimir Pagaré"
        '
        'txtImporte
        '
        Me.txtImporte.Location = New System.Drawing.Point(146, 35)
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.Size = New System.Drawing.Size(88, 20)
        Me.txtImporte.TabIndex = 30
        '
        'dtpFFirma
        '
        Me.dtpFFirma.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFFirma.Location = New System.Drawing.Point(146, 95)
        Me.dtpFFirma.Name = "dtpFFirma"
        Me.dtpFFirma.Size = New System.Drawing.Size(88, 20)
        Me.dtpFFirma.TabIndex = 29
        '
        'dtpFPago
        '
        Me.dtpFPago.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFPago.Location = New System.Drawing.Point(146, 63)
        Me.dtpFPago.Name = "dtpFPago"
        Me.dtpFPago.Size = New System.Drawing.Size(88, 20)
        Me.dtpFPago.TabIndex = 28
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(24, 95)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(80, 13)
        Me.Label14.TabIndex = 3
        Me.Label14.Text = "Fecha de Firma"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(22, 63)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(82, 13)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "Fecha del Pago"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(24, 35)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(96, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Importe del Pagaré"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(19, 563)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(143, 13)
        Me.Label17.TabIndex = 112
        Me.Label17.Text = "Fecha de Firma del Contrato."
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(298, 559)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(88, 20)
        Me.DateTimePicker1.TabIndex = 113
        '
        'ckbCartamo
        '
        Me.ckbCartamo.AutoSize = True
        Me.ckbCartamo.Location = New System.Drawing.Point(269, 521)
        Me.ckbCartamo.Name = "ckbCartamo"
        Me.ckbCartamo.Size = New System.Drawing.Size(65, 17)
        Me.ckbCartamo.TabIndex = 114
        Me.ckbCartamo.Text = "Cártamo"
        Me.ckbCartamo.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(19, 616)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(118, 13)
        Me.Label12.TabIndex = 115
        Me.Label12.Text = "Porcentaje de Comision"
        Me.Label12.Visible = False
        '
        'txtPorcomi
        '
        Me.txtPorcomi.Location = New System.Drawing.Point(151, 610)
        Me.txtPorcomi.Name = "txtPorcomi"
        Me.txtPorcomi.Size = New System.Drawing.Size(40, 20)
        Me.txtPorcomi.TabIndex = 116
        Me.txtPorcomi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPorcomi.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(19, 591)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(277, 13)
        Me.Label15.TabIndex = 117
        Me.Label15.Text = "Fecha Limite para Disponer de la Totalidad del CRËDITO"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(298, 587)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(88, 20)
        Me.DateTimePicker2.TabIndex = 118
        '
        'txtGHipotecario
        '
        Me.txtGHipotecario.Location = New System.Drawing.Point(169, 242)
        Me.txtGHipotecario.Name = "txtGHipotecario"
        Me.txtGHipotecario.Size = New System.Drawing.Size(789, 20)
        Me.txtGHipotecario.TabIndex = 119
        Me.txtGHipotecario.TabStop = False
        '
        'txtGPrendario
        '
        Me.txtGPrendario.Location = New System.Drawing.Point(169, 267)
        Me.txtGPrendario.Name = "txtGPrendario"
        Me.txtGPrendario.Size = New System.Drawing.Size(789, 20)
        Me.txtGPrendario.TabIndex = 120
        Me.txtGPrendario.TabStop = False
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(24, 242)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(143, 19)
        Me.Label16.TabIndex = 121
        Me.Label16.Text = "Garante(s) Hipotecario(s)"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(24, 268)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(143, 19)
        Me.Label19.TabIndex = 122
        Me.Label19.Text = "Garante(s) Prendario(s)"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ckbAlgodon
        '
        Me.ckbAlgodon.AutoSize = True
        Me.ckbAlgodon.Location = New System.Drawing.Point(340, 521)
        Me.ckbAlgodon.Name = "ckbAlgodon"
        Me.ckbAlgodon.Size = New System.Drawing.Size(65, 17)
        Me.ckbAlgodon.TabIndex = 123
        Me.ckbAlgodon.Text = "Algodón"
        Me.ckbAlgodon.UseVisualStyleBackColor = True
        '
        'ckbGarbanzo
        '
        Me.ckbGarbanzo.AutoSize = True
        Me.ckbGarbanzo.Location = New System.Drawing.Point(409, 521)
        Me.ckbGarbanzo.Name = "ckbGarbanzo"
        Me.ckbGarbanzo.Size = New System.Drawing.Size(72, 17)
        Me.ckbGarbanzo.TabIndex = 124
        Me.ckbGarbanzo.Text = "Garbanzo"
        Me.ckbGarbanzo.UseVisualStyleBackColor = True
        '
        'frmImpCtoAvio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1024, 702)
        Me.Controls.Add(Me.ckbGarbanzo)
        Me.Controls.Add(Me.ckbAlgodon)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtGPrendario)
        Me.Controls.Add(Me.txtGHipotecario)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtPorcomi)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.ckbCartamo)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.gbPagare)
        Me.Controls.Add(Me.btnImpPagare)
        Me.Controls.Add(Me.ckbSorgo)
        Me.Controls.Add(Me.ckbMaiz)
        Me.Controls.Add(Me.ckbTrigo)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.lblNotarioRegistrador)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtToneladasHectarea)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtDiferencialFINAGIL)
        Me.Controls.Add(Me.txtHectareas)
        Me.Controls.Add(Me.lblHectareas)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblMontoCredito)
        Me.Controls.Add(Me.txtAnexo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblGarantiaUsufructo)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblGarantiaHipotecaria)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblGarantiaPrendaria)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblFechaFirma)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gbDatosFINAGIL)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnImprimir)
        Me.Name = "frmImpCtoAvio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Impresión de Contratos de Avío"
        Me.gbDatosFINAGIL.ResumeLayout(False)
        Me.gbDatosFINAGIL.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.gbPagare.ResumeLayout(False)
        Me.gbPagare.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents gbDatosFINAGIL As System.Windows.Forms.GroupBox
    Friend WithEvents txtAnexo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtNombreProductor As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblFechaFirma As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblGarantiaPrendaria As System.Windows.Forms.Label
    Friend WithEvents lblGarantiaHipotecaria As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblGarantiaUsufructo As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblMontoCredito As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbAvales As System.Windows.Forms.ListBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtNombreRepresentante As System.Windows.Forms.TextBox
    Friend WithEvents txtHectareas As System.Windows.Forms.TextBox
    Friend WithEvents lblHectareas As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtDiferencialFINAGIL As System.Windows.Forms.TextBox
    Friend WithEvents txtToneladasHectarea As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblNotarioRegistrador As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ckbTrigo As System.Windows.Forms.CheckBox
    Friend WithEvents ckbMaiz As System.Windows.Forms.CheckBox
    Friend WithEvents ckbSorgo As System.Windows.Forms.CheckBox
    Friend WithEvents btnImpPagare As System.Windows.Forms.Button
    Friend WithEvents gbPagare As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtImporte As System.Windows.Forms.TextBox
    Friend WithEvents dtpFFirma As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFPago As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents ckbCartamo As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtPorcomi As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtGHipotecario As System.Windows.Forms.TextBox
    Friend WithEvents txtGPrendario As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents ckbAlgodon As System.Windows.Forms.CheckBox
    Friend WithEvents ckbGarbanzo As System.Windows.Forms.CheckBox

End Class
