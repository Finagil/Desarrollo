<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFiniquito
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
        Me.txtImportePago = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtAnexo = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cbBancos = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtCheque = New System.Windows.Forms.TextBox
        Me.btnProcesar = New System.Windows.Forms.Button
        Me.lblFechaPago = New System.Windows.Forms.Label
        Me.dtpFechaPago = New System.Windows.Forms.DateTimePicker
        Me.btnSalir = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblNota = New System.Windows.Forms.Label
        Me.txtNota = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtIvaRD = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblIvaRD = New System.Windows.Forms.Label
        Me.txtImpRD = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblImpRD = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblIvaDG = New System.Windows.Forms.Label
        Me.txtIvaDG = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblSaldoOtros = New System.Windows.Forms.Label
        Me.txtSaldoOtros = New System.Windows.Forms.TextBox
        Me.txtPagoTotal = New System.Windows.Forms.TextBox
        Me.lblPagoTotal = New System.Windows.Forms.Label
        Me.lblIO = New System.Windows.Forms.Label
        Me.txtIvaOpcion = New System.Windows.Forms.TextBox
        Me.txtOpcion = New System.Windows.Forms.TextBox
        Me.lblOC = New System.Windows.Forms.Label
        Me.lblDocumentos = New System.Windows.Forms.Label
        Me.btnAplicar = New System.Windows.Forms.Button
        Me.btnRecalcular = New System.Windows.Forms.Button
        Me.txtIvaIntereses = New System.Windows.Forms.TextBox
        Me.lblIvaIntereses = New System.Windows.Forms.Label
        Me.txtUdiFinal = New System.Windows.Forms.TextBox
        Me.lblUdiFinal = New System.Windows.Forms.Label
        Me.txtUdiInicial = New System.Windows.Forms.TextBox
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
        Me.txtIvaCapital = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.lblIvaComision = New System.Windows.Forms.Label
        Me.lblIvaCapital = New System.Windows.Forms.Label
        Me.txtComision = New System.Windows.Forms.TextBox
        Me.lblComision = New System.Windows.Forms.Label
        Me.txtImpDG = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.lblImpDG = New System.Windows.Forms.Label
        Me.txtPenalizacion = New System.Windows.Forms.TextBox
        Me.lblPenalizacion = New System.Windows.Forms.Label
        Me.txtSaldoEquipo = New System.Windows.Forms.TextBox
        Me.lblSaldoEquipo = New System.Windows.Forms.Label
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.txtSerieMXL = New System.Windows.Forms.TextBox
        Me.lblIDSerieMXL = New System.Windows.Forms.Label
        Me.lblIDSerieA = New System.Windows.Forms.Label
        Me.txtSerieA = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtImportePago
        '
        Me.txtImportePago.Location = New System.Drawing.Point(15, 38)
        Me.txtImportePago.Name = "txtImportePago"
        Me.txtImportePago.Size = New System.Drawing.Size(88, 20)
        Me.txtImportePago.TabIndex = 114
        Me.txtImportePago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 124
        Me.Label1.Text = "Monto del Pago"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txtAnexo
        '
        Me.txtAnexo.Location = New System.Drawing.Point(652, 9)
        Me.txtAnexo.Name = "txtAnexo"
        Me.txtAnexo.Size = New System.Drawing.Size(17, 20)
        Me.txtAnexo.TabIndex = 121
        Me.txtAnexo.Visible = False
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(231, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(132, 23)
        Me.Label5.TabIndex = 122
        Me.Label5.Text = "Seleccione el Banco"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'cbBancos
        '
        Me.cbBancos.Location = New System.Drawing.Point(235, 38)
        Me.cbBancos.MaxDropDownItems = 10
        Me.cbBancos.Name = "cbBancos"
        Me.cbBancos.Size = New System.Drawing.Size(224, 21)
        Me.cbBancos.TabIndex = 116
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(109, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 23)
        Me.Label4.TabIndex = 123
        Me.Label4.Text = "No. de Cheque"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txtCheque
        '
        Me.txtCheque.Location = New System.Drawing.Point(109, 38)
        Me.txtCheque.MaxLength = 15
        Me.txtCheque.Name = "txtCheque"
        Me.txtCheque.Size = New System.Drawing.Size(120, 20)
        Me.txtCheque.TabIndex = 115
        '
        'btnProcesar
        '
        Me.btnProcesar.Location = New System.Drawing.Point(576, 36)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(80, 24)
        Me.btnProcesar.TabIndex = 118
        Me.btnProcesar.Text = "Procesar"
        '
        'lblFechaPago
        '
        Me.lblFechaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaPago.Location = New System.Drawing.Point(466, 16)
        Me.lblFechaPago.Name = "lblFechaPago"
        Me.lblFechaPago.Size = New System.Drawing.Size(110, 16)
        Me.lblFechaPago.TabIndex = 120
        Me.lblFechaPago.Text = "Fecha de Pago"
        Me.lblFechaPago.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'dtpFechaPago
        '
        Me.dtpFechaPago.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaPago.Location = New System.Drawing.Point(469, 39)
        Me.dtpFechaPago.Name = "dtpFechaPago"
        Me.dtpFechaPago.Size = New System.Drawing.Size(88, 20)
        Me.dtpFechaPago.TabIndex = 117
        '
        'btnSalir
        '
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.Location = New System.Drawing.Point(663, 36)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(80, 24)
        Me.btnSalir.TabIndex = 119
        Me.btnSalir.Text = "Salir"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtSerieMXL)
        Me.GroupBox1.Controls.Add(Me.lblIDSerieMXL)
        Me.GroupBox1.Controls.Add(Me.lblIDSerieA)
        Me.GroupBox1.Controls.Add(Me.txtSerieA)
        Me.GroupBox1.Controls.Add(Me.lblNota)
        Me.GroupBox1.Controls.Add(Me.txtNota)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtIvaRD)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.lblIvaRD)
        Me.GroupBox1.Controls.Add(Me.txtImpRD)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblImpRD)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.lblIvaDG)
        Me.GroupBox1.Controls.Add(Me.txtIvaDG)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lblSaldoOtros)
        Me.GroupBox1.Controls.Add(Me.txtSaldoOtros)
        Me.GroupBox1.Controls.Add(Me.txtPagoTotal)
        Me.GroupBox1.Controls.Add(Me.lblPagoTotal)
        Me.GroupBox1.Controls.Add(Me.lblIO)
        Me.GroupBox1.Controls.Add(Me.txtIvaOpcion)
        Me.GroupBox1.Controls.Add(Me.txtOpcion)
        Me.GroupBox1.Controls.Add(Me.lblOC)
        Me.GroupBox1.Controls.Add(Me.lblDocumentos)
        Me.GroupBox1.Controls.Add(Me.btnAplicar)
        Me.GroupBox1.Controls.Add(Me.btnRecalcular)
        Me.GroupBox1.Controls.Add(Me.txtIvaIntereses)
        Me.GroupBox1.Controls.Add(Me.lblIvaIntereses)
        Me.GroupBox1.Controls.Add(Me.txtUdiFinal)
        Me.GroupBox1.Controls.Add(Me.lblUdiFinal)
        Me.GroupBox1.Controls.Add(Me.txtUdiInicial)
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
        Me.GroupBox1.Controls.Add(Me.txtIvaCapital)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.lblIvaComision)
        Me.GroupBox1.Controls.Add(Me.lblIvaCapital)
        Me.GroupBox1.Controls.Add(Me.txtComision)
        Me.GroupBox1.Controls.Add(Me.lblComision)
        Me.GroupBox1.Controls.Add(Me.txtImpDG)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.lblImpDG)
        Me.GroupBox1.Controls.Add(Me.txtPenalizacion)
        Me.GroupBox1.Controls.Add(Me.lblPenalizacion)
        Me.GroupBox1.Controls.Add(Me.txtSaldoEquipo)
        Me.GroupBox1.Controls.Add(Me.lblSaldoEquipo)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 71)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(731, 460)
        Me.GroupBox1.TabIndex = 126
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Visible = False
        '
        'lblNota
        '
        Me.lblNota.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNota.Location = New System.Drawing.Point(32, 318)
        Me.lblNota.Name = "lblNota"
        Me.lblNota.Size = New System.Drawing.Size(108, 23)
        Me.lblNota.TabIndex = 150
        Me.lblNota.Text = "Nota de Crédito"
        Me.lblNota.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNota
        '
        Me.txtNota.Location = New System.Drawing.Point(182, 321)
        Me.txtNota.Name = "txtNota"
        Me.txtNota.Size = New System.Drawing.Size(85, 20)
        Me.txtNota.TabIndex = 148
        Me.txtNota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(365, 343)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(14, 17)
        Me.Label13.TabIndex = 147
        Me.Label13.Text = "+"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(365, 319)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(14, 17)
        Me.Label12.TabIndex = 146
        Me.Label12.Text = "+"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(365, 199)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(14, 17)
        Me.Label11.TabIndex = 145
        Me.Label11.Text = "+"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(365, 175)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(14, 17)
        Me.Label10.TabIndex = 144
        Me.Label10.Text = "+"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(365, 151)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(14, 17)
        Me.Label9.TabIndex = 143
        Me.Label9.Text = "+"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(365, 127)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(14, 17)
        Me.Label8.TabIndex = 142
        Me.Label8.Text = "+"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtIvaRD
        '
        Me.txtIvaRD.Location = New System.Drawing.Point(582, 296)
        Me.txtIvaRD.Name = "txtIvaRD"
        Me.txtIvaRD.ReadOnly = True
        Me.txtIvaRD.Size = New System.Drawing.Size(100, 20)
        Me.txtIvaRD.TabIndex = 141
        Me.txtIvaRD.TabStop = False
        Me.txtIvaRD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(365, 295)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(12, 16)
        Me.Label7.TabIndex = 140
        Me.Label7.Text = "-"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIvaRD
        '
        Me.lblIvaRD.CausesValidation = False
        Me.lblIvaRD.Location = New System.Drawing.Point(382, 296)
        Me.lblIvaRD.Name = "lblIvaRD"
        Me.lblIvaRD.Size = New System.Drawing.Size(199, 16)
        Me.lblIvaRD.TabIndex = 139
        Me.lblIvaRD.Text = "I.V.A. de las Rentas en Depósito"
        Me.lblIvaRD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtImpRD
        '
        Me.txtImpRD.Location = New System.Drawing.Point(582, 272)
        Me.txtImpRD.Name = "txtImpRD"
        Me.txtImpRD.ReadOnly = True
        Me.txtImpRD.Size = New System.Drawing.Size(100, 20)
        Me.txtImpRD.TabIndex = 138
        Me.txtImpRD.TabStop = False
        Me.txtImpRD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(365, 271)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 16)
        Me.Label3.TabIndex = 137
        Me.Label3.Text = "-"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblImpRD
        '
        Me.lblImpRD.CausesValidation = False
        Me.lblImpRD.Location = New System.Drawing.Point(382, 272)
        Me.lblImpRD.Name = "lblImpRD"
        Me.lblImpRD.Size = New System.Drawing.Size(199, 16)
        Me.lblImpRD.TabIndex = 136
        Me.lblImpRD.Text = "Rentas en Depósito"
        Me.lblImpRD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(365, 247)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(12, 16)
        Me.Label6.TabIndex = 135
        Me.Label6.Text = "-"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIvaDG
        '
        Me.lblIvaDG.Location = New System.Drawing.Point(382, 248)
        Me.lblIvaDG.Name = "lblIvaDG"
        Me.lblIvaDG.Size = New System.Drawing.Size(199, 16)
        Me.lblIvaDG.TabIndex = 134
        Me.lblIvaDG.Text = "I.V.A. del Depósito en Garantía"
        Me.lblIvaDG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtIvaDG
        '
        Me.txtIvaDG.Location = New System.Drawing.Point(582, 248)
        Me.txtIvaDG.Name = "txtIvaDG"
        Me.txtIvaDG.ReadOnly = True
        Me.txtIvaDG.Size = New System.Drawing.Size(100, 20)
        Me.txtIvaDG.TabIndex = 133
        Me.txtIvaDG.TabStop = False
        Me.txtIvaDG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(365, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(14, 17)
        Me.Label2.TabIndex = 130
        Me.Label2.Text = "+"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSaldoOtros
        '
        Me.lblSaldoOtros.Location = New System.Drawing.Point(382, 80)
        Me.lblSaldoOtros.Name = "lblSaldoOtros"
        Me.lblSaldoOtros.Size = New System.Drawing.Size(199, 16)
        Me.lblSaldoOtros.TabIndex = 129
        Me.lblSaldoOtros.Text = "Saldo Otros Adeudos"
        Me.lblSaldoOtros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSaldoOtros
        '
        Me.txtSaldoOtros.Location = New System.Drawing.Point(582, 80)
        Me.txtSaldoOtros.Name = "txtSaldoOtros"
        Me.txtSaldoOtros.ReadOnly = True
        Me.txtSaldoOtros.Size = New System.Drawing.Size(100, 20)
        Me.txtSaldoOtros.TabIndex = 128
        Me.txtSaldoOtros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPagoTotal
        '
        Me.txtPagoTotal.Location = New System.Drawing.Point(582, 367)
        Me.txtPagoTotal.Name = "txtPagoTotal"
        Me.txtPagoTotal.ReadOnly = True
        Me.txtPagoTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtPagoTotal.TabIndex = 119
        Me.txtPagoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPagoTotal
        '
        Me.lblPagoTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPagoTotal.Location = New System.Drawing.Point(382, 367)
        Me.lblPagoTotal.Name = "lblPagoTotal"
        Me.lblPagoTotal.Size = New System.Drawing.Size(199, 16)
        Me.lblPagoTotal.TabIndex = 118
        Me.lblPagoTotal.Text = "Pago total a realizar"
        Me.lblPagoTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIO
        '
        Me.lblIO.Location = New System.Drawing.Point(382, 343)
        Me.lblIO.Name = "lblIO"
        Me.lblIO.Size = New System.Drawing.Size(199, 16)
        Me.lblIO.TabIndex = 117
        Me.lblIO.Text = "IVA de la Opción de Compra"
        Me.lblIO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtIvaOpcion
        '
        Me.txtIvaOpcion.Location = New System.Drawing.Point(582, 343)
        Me.txtIvaOpcion.Name = "txtIvaOpcion"
        Me.txtIvaOpcion.ReadOnly = True
        Me.txtIvaOpcion.Size = New System.Drawing.Size(100, 20)
        Me.txtIvaOpcion.TabIndex = 115
        Me.txtIvaOpcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtOpcion
        '
        Me.txtOpcion.Location = New System.Drawing.Point(582, 319)
        Me.txtOpcion.Name = "txtOpcion"
        Me.txtOpcion.ReadOnly = True
        Me.txtOpcion.Size = New System.Drawing.Size(100, 20)
        Me.txtOpcion.TabIndex = 114
        Me.txtOpcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblOC
        '
        Me.lblOC.Location = New System.Drawing.Point(382, 319)
        Me.lblOC.Name = "lblOC"
        Me.lblOC.Size = New System.Drawing.Size(199, 16)
        Me.lblOC.TabIndex = 116
        Me.lblOC.Text = "Opción de Compra"
        Me.lblOC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDocumentos
        '
        Me.lblDocumentos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDocumentos.Location = New System.Drawing.Point(33, 244)
        Me.lblDocumentos.Name = "lblDocumentos"
        Me.lblDocumentos.Size = New System.Drawing.Size(163, 23)
        Me.lblDocumentos.TabIndex = 113
        Me.lblDocumentos.Text = "Documentos a imprimir"
        Me.lblDocumentos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnAplicar
        '
        Me.btnAplicar.Enabled = False
        Me.btnAplicar.Location = New System.Drawing.Point(196, 192)
        Me.btnAplicar.Name = "btnAplicar"
        Me.btnAplicar.Size = New System.Drawing.Size(70, 24)
        Me.btnAplicar.TabIndex = 9
        Me.btnAplicar.Text = "Aplicar"
        '
        'btnRecalcular
        '
        Me.btnRecalcular.Location = New System.Drawing.Point(85, 192)
        Me.btnRecalcular.Name = "btnRecalcular"
        Me.btnRecalcular.Size = New System.Drawing.Size(70, 24)
        Me.btnRecalcular.TabIndex = 8
        Me.btnRecalcular.Text = "Recalcular"
        '
        'txtIvaIntereses
        '
        Me.txtIvaIntereses.Location = New System.Drawing.Point(582, 152)
        Me.txtIvaIntereses.Name = "txtIvaIntereses"
        Me.txtIvaIntereses.ReadOnly = True
        Me.txtIvaIntereses.Size = New System.Drawing.Size(100, 20)
        Me.txtIvaIntereses.TabIndex = 92
        Me.txtIvaIntereses.TabStop = False
        Me.txtIvaIntereses.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblIvaIntereses
        '
        Me.lblIvaIntereses.Location = New System.Drawing.Point(382, 152)
        Me.lblIvaIntereses.Name = "lblIvaIntereses"
        Me.lblIvaIntereses.Size = New System.Drawing.Size(199, 16)
        Me.lblIvaIntereses.TabIndex = 90
        Me.lblIvaIntereses.Text = "IVA de los Intereses"
        Me.lblIvaIntereses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUdiFinal
        '
        Me.txtUdiFinal.Location = New System.Drawing.Point(199, 129)
        Me.txtUdiFinal.Name = "txtUdiFinal"
        Me.txtUdiFinal.ReadOnly = True
        Me.txtUdiFinal.Size = New System.Drawing.Size(100, 20)
        Me.txtUdiFinal.TabIndex = 89
        Me.txtUdiFinal.TabStop = False
        Me.txtUdiFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblUdiFinal
        '
        Me.lblUdiFinal.Location = New System.Drawing.Point(33, 129)
        Me.lblUdiFinal.Name = "lblUdiFinal"
        Me.lblUdiFinal.Size = New System.Drawing.Size(164, 16)
        Me.lblUdiFinal.TabIndex = 88
        Me.lblUdiFinal.Text = "UDI Final"
        Me.lblUdiFinal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUdiInicial
        '
        Me.txtUdiInicial.Location = New System.Drawing.Point(199, 104)
        Me.txtUdiInicial.Name = "txtUdiInicial"
        Me.txtUdiInicial.ReadOnly = True
        Me.txtUdiInicial.Size = New System.Drawing.Size(100, 20)
        Me.txtUdiInicial.TabIndex = 87
        Me.txtUdiInicial.TabStop = False
        Me.txtUdiInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblUdiInicial
        '
        Me.lblUdiInicial.Location = New System.Drawing.Point(33, 104)
        Me.lblUdiInicial.Name = "lblUdiInicial"
        Me.lblUdiInicial.Size = New System.Drawing.Size(164, 16)
        Me.lblUdiInicial.TabIndex = 86
        Me.lblUdiInicial.Text = "UDI Inicial"
        Me.lblUdiInicial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtIntereses
        '
        Me.txtIntereses.Location = New System.Drawing.Point(582, 128)
        Me.txtIntereses.Name = "txtIntereses"
        Me.txtIntereses.ReadOnly = True
        Me.txtIntereses.Size = New System.Drawing.Size(100, 20)
        Me.txtIntereses.TabIndex = 84
        Me.txtIntereses.TabStop = False
        Me.txtIntereses.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblIntereses
        '
        Me.lblIntereses.Location = New System.Drawing.Point(382, 128)
        Me.lblIntereses.Name = "lblIntereses"
        Me.lblIntereses.Size = New System.Drawing.Size(199, 16)
        Me.lblIntereses.TabIndex = 81
        Me.lblIntereses.Text = "Intereses"
        Me.lblIntereses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTasaAplicada
        '
        Me.txtTasaAplicada.Location = New System.Drawing.Point(199, 79)
        Me.txtTasaAplicada.Name = "txtTasaAplicada"
        Me.txtTasaAplicada.ReadOnly = True
        Me.txtTasaAplicada.Size = New System.Drawing.Size(100, 20)
        Me.txtTasaAplicada.TabIndex = 80
        Me.txtTasaAplicada.TabStop = False
        Me.txtTasaAplicada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTasaAplicada
        '
        Me.lblTasaAplicada.Location = New System.Drawing.Point(33, 79)
        Me.lblTasaAplicada.Name = "lblTasaAplicada"
        Me.lblTasaAplicada.Size = New System.Drawing.Size(164, 16)
        Me.lblTasaAplicada.TabIndex = 79
        Me.lblTasaAplicada.Text = "Tasa Aplicada (%)"
        Me.lblTasaAplicada.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDiasIntereses
        '
        Me.txtDiasIntereses.Location = New System.Drawing.Point(199, 55)
        Me.txtDiasIntereses.Name = "txtDiasIntereses"
        Me.txtDiasIntereses.Size = New System.Drawing.Size(100, 20)
        Me.txtDiasIntereses.TabIndex = 7
        Me.txtDiasIntereses.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDiasIntereses
        '
        Me.lblDiasIntereses.Location = New System.Drawing.Point(33, 55)
        Me.lblDiasIntereses.Name = "lblDiasIntereses"
        Me.lblDiasIntereses.Size = New System.Drawing.Size(164, 16)
        Me.lblDiasIntereses.TabIndex = 74
        Me.lblDiasIntereses.Text = "Días de Intereses"
        Me.lblDiasIntereses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSaldoSeguro
        '
        Me.txtSaldoSeguro.Location = New System.Drawing.Point(582, 56)
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
        Me.Label25.Location = New System.Drawing.Point(365, 55)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(14, 17)
        Me.Label25.TabIndex = 58
        Me.Label25.Text = "+"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSaldoSeguro
        '
        Me.lblSaldoSeguro.Location = New System.Drawing.Point(382, 56)
        Me.lblSaldoSeguro.Name = "lblSaldoSeguro"
        Me.lblSaldoSeguro.Size = New System.Drawing.Size(199, 16)
        Me.lblSaldoSeguro.TabIndex = 56
        Me.lblSaldoSeguro.Text = "Saldo Insoluto Seguro"
        Me.lblSaldoSeguro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtIvaComision
        '
        Me.txtIvaComision.Location = New System.Drawing.Point(582, 200)
        Me.txtIvaComision.Name = "txtIvaComision"
        Me.txtIvaComision.ReadOnly = True
        Me.txtIvaComision.Size = New System.Drawing.Size(100, 20)
        Me.txtIvaComision.TabIndex = 54
        Me.txtIvaComision.TabStop = False
        Me.txtIvaComision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIvaCapital
        '
        Me.txtIvaCapital.Location = New System.Drawing.Point(582, 104)
        Me.txtIvaCapital.Name = "txtIvaCapital"
        Me.txtIvaCapital.ReadOnly = True
        Me.txtIvaCapital.Size = New System.Drawing.Size(100, 20)
        Me.txtIvaCapital.TabIndex = 55
        Me.txtIvaCapital.TabStop = False
        Me.txtIvaCapital.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(365, 103)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(14, 17)
        Me.Label24.TabIndex = 52
        Me.Label24.Text = "+"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIvaComision
        '
        Me.lblIvaComision.Location = New System.Drawing.Point(382, 200)
        Me.lblIvaComision.Name = "lblIvaComision"
        Me.lblIvaComision.Size = New System.Drawing.Size(199, 16)
        Me.lblIvaComision.TabIndex = 51
        Me.lblIvaComision.Text = "IVA de la Comisión por Prepago"
        Me.lblIvaComision.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIvaCapital
        '
        Me.lblIvaCapital.Location = New System.Drawing.Point(382, 104)
        Me.lblIvaCapital.Name = "lblIvaCapital"
        Me.lblIvaCapital.Size = New System.Drawing.Size(199, 16)
        Me.lblIvaCapital.TabIndex = 50
        Me.lblIvaCapital.Text = "IVA del Capital"
        Me.lblIvaCapital.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComision
        '
        Me.txtComision.Location = New System.Drawing.Point(582, 176)
        Me.txtComision.Name = "txtComision"
        Me.txtComision.ReadOnly = True
        Me.txtComision.Size = New System.Drawing.Size(100, 20)
        Me.txtComision.TabIndex = 66
        Me.txtComision.TabStop = False
        Me.txtComision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblComision
        '
        Me.lblComision.Location = New System.Drawing.Point(382, 176)
        Me.lblComision.Name = "lblComision"
        Me.lblComision.Size = New System.Drawing.Size(199, 16)
        Me.lblComision.TabIndex = 47
        Me.lblComision.Text = "Comisión por Prepago"
        Me.lblComision.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtImpDG
        '
        Me.txtImpDG.Location = New System.Drawing.Point(582, 224)
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
        Me.Label21.Location = New System.Drawing.Point(365, 223)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(12, 16)
        Me.Label21.TabIndex = 44
        Me.Label21.Text = "-"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblImpDG
        '
        Me.lblImpDG.CausesValidation = False
        Me.lblImpDG.Location = New System.Drawing.Point(382, 224)
        Me.lblImpDG.Name = "lblImpDG"
        Me.lblImpDG.Size = New System.Drawing.Size(199, 16)
        Me.lblImpDG.TabIndex = 43
        Me.lblImpDG.Text = "Depósito en Garantía"
        Me.lblImpDG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPenalizacion
        '
        Me.txtPenalizacion.Location = New System.Drawing.Point(199, 31)
        Me.txtPenalizacion.Name = "txtPenalizacion"
        Me.txtPenalizacion.Size = New System.Drawing.Size(100, 20)
        Me.txtPenalizacion.TabIndex = 6
        Me.txtPenalizacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPenalizacion
        '
        Me.lblPenalizacion.Location = New System.Drawing.Point(33, 31)
        Me.lblPenalizacion.Name = "lblPenalizacion"
        Me.lblPenalizacion.Size = New System.Drawing.Size(164, 16)
        Me.lblPenalizacion.TabIndex = 41
        Me.lblPenalizacion.Text = "Penalización (%)"
        Me.lblPenalizacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSaldoEquipo
        '
        Me.txtSaldoEquipo.Location = New System.Drawing.Point(582, 32)
        Me.txtSaldoEquipo.Name = "txtSaldoEquipo"
        Me.txtSaldoEquipo.ReadOnly = True
        Me.txtSaldoEquipo.Size = New System.Drawing.Size(100, 20)
        Me.txtSaldoEquipo.TabIndex = 77
        Me.txtSaldoEquipo.TabStop = False
        Me.txtSaldoEquipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSaldoEquipo
        '
        Me.lblSaldoEquipo.Location = New System.Drawing.Point(382, 32)
        Me.lblSaldoEquipo.Name = "lblSaldoEquipo"
        Me.lblSaldoEquipo.Size = New System.Drawing.Size(199, 16)
        Me.lblSaldoEquipo.TabIndex = 1
        Me.lblSaldoEquipo.Text = "Saldo Insoluto Equipo"
        Me.lblSaldoEquipo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 547)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(755, 22)
        Me.StatusStrip1.TabIndex = 127
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(132, 17)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'txtSerieMXL
        '
        Me.txtSerieMXL.Location = New System.Drawing.Point(182, 296)
        Me.txtSerieMXL.Name = "txtSerieMXL"
        Me.txtSerieMXL.ReadOnly = True
        Me.txtSerieMXL.Size = New System.Drawing.Size(85, 20)
        Me.txtSerieMXL.TabIndex = 155
        Me.txtSerieMXL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSerieMXL.Visible = False
        '
        'lblIDSerieMXL
        '
        Me.lblIDSerieMXL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIDSerieMXL.Location = New System.Drawing.Point(33, 295)
        Me.lblIDSerieMXL.Name = "lblIDSerieMXL"
        Me.lblIDSerieMXL.Size = New System.Drawing.Size(144, 23)
        Me.lblIDSerieMXL.TabIndex = 154
        Me.lblIDSerieMXL.Text = "Consecutivo Serie MXL"
        Me.lblIDSerieMXL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblIDSerieMXL.Visible = False
        '
        'lblIDSerieA
        '
        Me.lblIDSerieA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIDSerieA.Location = New System.Drawing.Point(33, 272)
        Me.lblIDSerieA.Name = "lblIDSerieA"
        Me.lblIDSerieA.Size = New System.Drawing.Size(144, 23)
        Me.lblIDSerieA.TabIndex = 153
        Me.lblIDSerieA.Text = "Consecutivo Serie A"
        Me.lblIDSerieA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblIDSerieA.Visible = False
        '
        'txtSerieA
        '
        Me.txtSerieA.Location = New System.Drawing.Point(182, 273)
        Me.txtSerieA.Name = "txtSerieA"
        Me.txtSerieA.ReadOnly = True
        Me.txtSerieA.Size = New System.Drawing.Size(85, 20)
        Me.txtSerieA.TabIndex = 152
        Me.txtSerieA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSerieA.Visible = False
        '
        'frmFiniquito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(755, 569)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtImportePago)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtAnexo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cbBancos)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCheque)
        Me.Controls.Add(Me.btnProcesar)
        Me.Controls.Add(Me.lblFechaPago)
        Me.Controls.Add(Me.dtpFechaPago)
        Me.Controls.Add(Me.btnSalir)
        Me.Name = "frmFiniquito"
        Me.Text = "Finiquito de Contrato"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtImportePago As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAnexo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbBancos As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCheque As System.Windows.Forms.TextBox
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents lblFechaPago As System.Windows.Forms.Label
    Friend WithEvents dtpFechaPago As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblDocumentos As System.Windows.Forms.Label
    Friend WithEvents btnAplicar As System.Windows.Forms.Button
    Friend WithEvents btnRecalcular As System.Windows.Forms.Button
    Friend WithEvents txtIvaIntereses As System.Windows.Forms.TextBox
    Friend WithEvents lblIvaIntereses As System.Windows.Forms.Label
    Friend WithEvents txtUdiFinal As System.Windows.Forms.TextBox
    Friend WithEvents lblUdiFinal As System.Windows.Forms.Label
    Friend WithEvents txtUdiInicial As System.Windows.Forms.TextBox
    Friend WithEvents lblUdiInicial As System.Windows.Forms.Label
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
    Friend WithEvents txtIvaCapital As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents lblIvaComision As System.Windows.Forms.Label
    Friend WithEvents lblIvaCapital As System.Windows.Forms.Label
    Friend WithEvents txtComision As System.Windows.Forms.TextBox
    Friend WithEvents lblComision As System.Windows.Forms.Label
    Friend WithEvents txtImpDG As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lblImpDG As System.Windows.Forms.Label
    Friend WithEvents txtPenalizacion As System.Windows.Forms.TextBox
    Friend WithEvents lblPenalizacion As System.Windows.Forms.Label
    Friend WithEvents txtSaldoEquipo As System.Windows.Forms.TextBox
    Friend WithEvents lblSaldoEquipo As System.Windows.Forms.Label
    Friend WithEvents lblIO As System.Windows.Forms.Label
    Friend WithEvents txtIvaOpcion As System.Windows.Forms.TextBox
    Friend WithEvents txtOpcion As System.Windows.Forms.TextBox
    Friend WithEvents lblOC As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtPagoTotal As System.Windows.Forms.TextBox
    Friend WithEvents lblPagoTotal As System.Windows.Forms.Label
    Friend WithEvents lblSaldoOtros As System.Windows.Forms.Label
    Friend WithEvents txtSaldoOtros As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblIvaDG As System.Windows.Forms.Label
    Friend WithEvents txtIvaDG As System.Windows.Forms.TextBox
    Friend WithEvents txtIvaRD As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblIvaRD As System.Windows.Forms.Label
    Friend WithEvents txtImpRD As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblImpRD As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtNota As System.Windows.Forms.TextBox
    Friend WithEvents lblNota As System.Windows.Forms.Label
    Friend WithEvents txtSerieMXL As System.Windows.Forms.TextBox
    Friend WithEvents lblIDSerieMXL As System.Windows.Forms.Label
    Friend WithEvents lblIDSerieA As System.Windows.Forms.Label
    Friend WithEvents txtSerieA As System.Windows.Forms.TextBox
End Class
