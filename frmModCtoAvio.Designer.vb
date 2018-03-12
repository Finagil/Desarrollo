<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModCtoAvio
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
        Me.dtpFechaAutorizacion = New System.Windows.Forms.DateTimePicker
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtHectareasActual = New System.Windows.Forms.TextBox
        Me.gbDatosFINAGIL = New System.Windows.Forms.GroupBox
        Me.txtSustraeActual = New System.Windows.Forms.TextBox
        Me.txtCostoHectarea = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtDiferencialFINAGIL = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbEstratoActual = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtLineaActual = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.gbDatosFIRA = New System.Windows.Forms.GroupBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtIDDTU = New System.Windows.Forms.TextBox
        Me.txtIDCredito = New System.Windows.Forms.TextBox
        Me.txtIDContrato = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtIDPersona = New System.Windows.Forms.TextBox
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.btnSalir = New System.Windows.Forms.Button
        Me.lblAnexo = New System.Windows.Forms.Label
        Me.gbDatosFINAGIL.SuspendLayout()
        Me.gbDatosFIRA.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtpFechaAutorizacion
        '
        Me.dtpFechaAutorizacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaAutorizacion.Location = New System.Drawing.Point(220, 30)
        Me.dtpFechaAutorizacion.Name = "dtpFechaAutorizacion"
        Me.dtpFechaAutorizacion.Size = New System.Drawing.Size(86, 20)
        Me.dtpFechaAutorizacion.TabIndex = 71
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(16, 82)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(179, 16)
        Me.Label10.TabIndex = 88
        Me.Label10.Text = "No. de Hectáreas"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtHectareasActual
        '
        Me.txtHectareasActual.Location = New System.Drawing.Point(206, 82)
        Me.txtHectareasActual.Name = "txtHectareasActual"
        Me.txtHectareasActual.Size = New System.Drawing.Size(100, 20)
        Me.txtHectareasActual.TabIndex = 86
        Me.txtHectareasActual.Text = "0"
        Me.txtHectareasActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gbDatosFINAGIL
        '
        Me.gbDatosFINAGIL.Controls.Add(Me.txtSustraeActual)
        Me.gbDatosFINAGIL.Controls.Add(Me.txtCostoHectarea)
        Me.gbDatosFINAGIL.Controls.Add(Me.Label18)
        Me.gbDatosFINAGIL.Controls.Add(Me.txtDiferencialFINAGIL)
        Me.gbDatosFINAGIL.Controls.Add(Me.Label25)
        Me.gbDatosFINAGIL.Controls.Add(Me.Label26)
        Me.gbDatosFINAGIL.Controls.Add(Me.Label27)
        Me.gbDatosFINAGIL.Controls.Add(Me.Label24)
        Me.gbDatosFINAGIL.Controls.Add(Me.Label2)
        Me.gbDatosFINAGIL.Controls.Add(Me.Label10)
        Me.gbDatosFINAGIL.Controls.Add(Me.txtHectareasActual)
        Me.gbDatosFINAGIL.Controls.Add(Me.dtpFechaAutorizacion)
        Me.gbDatosFINAGIL.Controls.Add(Me.cbEstratoActual)
        Me.gbDatosFINAGIL.Controls.Add(Me.Label15)
        Me.gbDatosFINAGIL.Controls.Add(Me.Label17)
        Me.gbDatosFINAGIL.Controls.Add(Me.txtLineaActual)
        Me.gbDatosFINAGIL.Controls.Add(Me.Label19)
        Me.gbDatosFINAGIL.Controls.Add(Me.Label20)
        Me.gbDatosFINAGIL.Location = New System.Drawing.Point(52, 71)
        Me.gbDatosFINAGIL.Name = "gbDatosFINAGIL"
        Me.gbDatosFINAGIL.Size = New System.Drawing.Size(395, 490)
        Me.gbDatosFINAGIL.TabIndex = 73
        Me.gbDatosFINAGIL.TabStop = False
        Me.gbDatosFINAGIL.Text = "Datos en FINAGIL"
        '
        'txtSustraeActual
        '
        Me.txtSustraeActual.Location = New System.Drawing.Point(98, 308)
        Me.txtSustraeActual.Name = "txtSustraeActual"
        Me.txtSustraeActual.ReadOnly = True
        Me.txtSustraeActual.Size = New System.Drawing.Size(32, 20)
        Me.txtSustraeActual.TabIndex = 102
        Me.txtSustraeActual.TabStop = False
        Me.txtSustraeActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCostoHectarea
        '
        Me.txtCostoHectarea.Location = New System.Drawing.Point(206, 108)
        Me.txtCostoHectarea.Name = "txtCostoHectarea"
        Me.txtCostoHectarea.Size = New System.Drawing.Size(100, 20)
        Me.txtCostoHectarea.TabIndex = 101
        Me.txtCostoHectarea.Text = "0.00"
        Me.txtCostoHectarea.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(16, 134)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(240, 17)
        Me.Label18.TabIndex = 100
        Me.Label18.Text = "Diferencial FINAGIL-Productor"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDiferencialFINAGIL
        '
        Me.txtDiferencialFINAGIL.Location = New System.Drawing.Point(263, 134)
        Me.txtDiferencialFINAGIL.Name = "txtDiferencialFINAGIL"
        Me.txtDiferencialFINAGIL.Size = New System.Drawing.Size(43, 20)
        Me.txtDiferencialFINAGIL.TabIndex = 99
        Me.txtDiferencialFINAGIL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(98, 420)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(271, 18)
        Me.Label25.TabIndex = 98
        Me.Label25.Text = "SI = Consultado y sí tiene Antecedentes negativos"
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(98, 385)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(271, 18)
        Me.Label26.TabIndex = 97
        Me.Label26.Text = "NO = Consultado y no tiene Antecedentes negativos"
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(98, 350)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(271, 18)
        Me.Label27.TabIndex = 96
        Me.Label27.Text = "NC = No Consultado"
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(98, 237)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(165, 18)
        Me.Label24.TabIndex = 93
        Me.Label24.Text = "Estrato NE = No Estratificado"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 108)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(179, 16)
        Me.Label2.TabIndex = 92
        Me.Label2.Text = "Costo por Hectárea"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbEstratoActual
        '
        Me.cbEstratoActual.FormattingEnabled = True
        Me.cbEstratoActual.Location = New System.Drawing.Point(98, 193)
        Me.cbEstratoActual.Name = "cbEstratoActual"
        Me.cbEstratoActual.Size = New System.Drawing.Size(59, 21)
        Me.cbEstratoActual.TabIndex = 76
        Me.cbEstratoActual.TabStop = False
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(16, 309)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(79, 19)
        Me.Label15.TabIndex = 74
        Me.Label15.Text = "SUSTRAE"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(16, 194)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(49, 19)
        Me.Label17.TabIndex = 73
        Me.Label17.Text = "Estrato"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLineaActual
        '
        Me.txtLineaActual.Location = New System.Drawing.Point(206, 56)
        Me.txtLineaActual.Name = "txtLineaActual"
        Me.txtLineaActual.Size = New System.Drawing.Size(100, 20)
        Me.txtLineaActual.TabIndex = 72
        Me.txtLineaActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(16, 56)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(91, 19)
        Me.Label19.TabIndex = 70
        Me.Label19.Text = "Línea autorizada"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(16, 30)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(118, 19)
        Me.Label20.TabIndex = 69
        Me.Label20.Text = "Fecha de Autorización"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gbDatosFIRA
        '
        Me.gbDatosFIRA.Controls.Add(Me.Label21)
        Me.gbDatosFIRA.Controls.Add(Me.txtIDDTU)
        Me.gbDatosFIRA.Controls.Add(Me.txtIDCredito)
        Me.gbDatosFIRA.Controls.Add(Me.txtIDContrato)
        Me.gbDatosFIRA.Controls.Add(Me.Label14)
        Me.gbDatosFIRA.Controls.Add(Me.Label11)
        Me.gbDatosFIRA.Controls.Add(Me.Label8)
        Me.gbDatosFIRA.Controls.Add(Me.txtIDPersona)
        Me.gbDatosFIRA.Location = New System.Drawing.Point(585, 71)
        Me.gbDatosFIRA.Name = "gbDatosFIRA"
        Me.gbDatosFIRA.Size = New System.Drawing.Size(394, 123)
        Me.gbDatosFIRA.TabIndex = 94
        Me.gbDatosFIRA.TabStop = False
        Me.gbDatosFIRA.Text = "Datos en FIRA"
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(123, 68)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(97, 19)
        Me.Label21.TabIndex = 81
        Me.Label21.Text = "ID DTU"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtIDDTU
        '
        Me.txtIDDTU.Location = New System.Drawing.Point(224, 67)
        Me.txtIDDTU.Name = "txtIDDTU"
        Me.txtIDDTU.Size = New System.Drawing.Size(82, 20)
        Me.txtIDDTU.TabIndex = 80
        Me.txtIDDTU.TabStop = False
        Me.txtIDDTU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIDCredito
        '
        Me.txtIDCredito.Location = New System.Drawing.Point(224, 93)
        Me.txtIDCredito.Name = "txtIDCredito"
        Me.txtIDCredito.Size = New System.Drawing.Size(82, 20)
        Me.txtIDCredito.TabIndex = 79
        Me.txtIDCredito.TabStop = False
        Me.txtIDCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIDContrato
        '
        Me.txtIDContrato.Location = New System.Drawing.Point(224, 41)
        Me.txtIDContrato.Name = "txtIDContrato"
        Me.txtIDContrato.Size = New System.Drawing.Size(82, 20)
        Me.txtIDContrato.TabIndex = 78
        Me.txtIDContrato.TabStop = False
        Me.txtIDContrato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(123, 94)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(97, 19)
        Me.Label14.TabIndex = 77
        Me.Label14.Text = "ID Crédito"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(123, 42)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(97, 19)
        Me.Label11.TabIndex = 76
        Me.Label11.Text = "ID Contrato"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(123, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(97, 19)
        Me.Label8.TabIndex = 72
        Me.Label8.Text = "ID Persona"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtIDPersona
        '
        Me.txtIDPersona.Location = New System.Drawing.Point(224, 16)
        Me.txtIDPersona.Name = "txtIDPersona"
        Me.txtIDPersona.Size = New System.Drawing.Size(82, 20)
        Me.txtIDPersona.TabIndex = 75
        Me.txtIDPersona.TabStop = False
        Me.txtIDPersona.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(789, 538)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 23)
        Me.btnGuardar.TabIndex = 95
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(904, 538)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 96
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'lblAnexo
        '
        Me.lblAnexo.AutoSize = True
        Me.lblAnexo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAnexo.Location = New System.Drawing.Point(54, 28)
        Me.lblAnexo.Name = "lblAnexo"
        Me.lblAnexo.Size = New System.Drawing.Size(45, 13)
        Me.lblAnexo.TabIndex = 97
        Me.lblAnexo.Text = "Label1"
        '
        'frmModCtoAvio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1024, 702)
        Me.Controls.Add(Me.lblAnexo)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.gbDatosFIRA)
        Me.Controls.Add(Me.gbDatosFINAGIL)
        Me.Name = "frmModCtoAvio"
        Me.Text = "Modificar Contrato de Avío"
        Me.gbDatosFINAGIL.ResumeLayout(False)
        Me.gbDatosFINAGIL.PerformLayout()
        Me.gbDatosFIRA.ResumeLayout(False)
        Me.gbDatosFIRA.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpFechaAutorizacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtHectareasActual As System.Windows.Forms.TextBox
    Friend WithEvents gbDatosFINAGIL As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbEstratoActual As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtLineaActual As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtDiferencialFINAGIL As System.Windows.Forms.TextBox
    Friend WithEvents txtCostoHectarea As System.Windows.Forms.TextBox
    Friend WithEvents txtSustraeActual As System.Windows.Forms.TextBox
    Friend WithEvents gbDatosFIRA As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtIDPersona As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtIDCredito As System.Windows.Forms.TextBox
    Friend WithEvents txtIDContrato As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtIDDTU As System.Windows.Forms.TextBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents lblAnexo As System.Windows.Forms.Label
End Class
