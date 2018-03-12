<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSustrae
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
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.cbSustraeActual = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbProductores = New System.Windows.Forms.ComboBox
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.btnSalir = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpFechaConsulta = New System.Windows.Forms.DateTimePicker
        Me.txtProductor = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.gbProductor = New System.Windows.Forms.GroupBox
        Me.gbProductor.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(12, 181)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(271, 18)
        Me.Label25.TabIndex = 103
        Me.Label25.Text = "SI = Consultado y sí tiene Antecedentes negativos"
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(12, 151)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(271, 18)
        Me.Label26.TabIndex = 102
        Me.Label26.Text = "NO = Consultado y no tiene Antecedentes negativos"
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(12, 121)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(271, 18)
        Me.Label27.TabIndex = 101
        Me.Label27.Text = "NC = No Consultado"
        '
        'cbSustraeActual
        '
        Me.cbSustraeActual.FormattingEnabled = True
        Me.cbSustraeActual.Location = New System.Drawing.Point(153, 81)
        Me.cbSustraeActual.Name = "cbSustraeActual"
        Me.cbSustraeActual.Size = New System.Drawing.Size(54, 21)
        Me.cbSustraeActual.TabIndex = 2
        Me.cbSustraeActual.TabStop = False
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(12, 81)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(135, 19)
        Me.Label15.TabIndex = 99
        Me.Label15.Text = "Resultado de la Consulta"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 13)
        Me.Label1.TabIndex = 105
        Me.Label1.Text = "Fecha de Consulta"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cbProductores
        '
        Me.cbProductores.FormattingEnabled = True
        Me.cbProductores.Location = New System.Drawing.Point(84, 25)
        Me.cbProductores.Name = "cbProductores"
        Me.cbProductores.Size = New System.Drawing.Size(423, 21)
        Me.cbProductores.TabIndex = 106
        Me.cbProductores.TabStop = False
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(15, 228)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 23)
        Me.btnGuardar.TabIndex = 3
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(208, 228)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 4
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 109
        Me.Label2.Text = "Productor"
        '
        'dtpFechaConsulta
        '
        Me.dtpFechaConsulta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaConsulta.Location = New System.Drawing.Point(122, 50)
        Me.dtpFechaConsulta.Name = "dtpFechaConsulta"
        Me.dtpFechaConsulta.Size = New System.Drawing.Size(86, 20)
        Me.dtpFechaConsulta.TabIndex = 1
        '
        'txtProductor
        '
        Me.txtProductor.Location = New System.Drawing.Point(163, 19)
        Me.txtProductor.Name = "txtProductor"
        Me.txtProductor.ReadOnly = True
        Me.txtProductor.Size = New System.Drawing.Size(45, 20)
        Me.txtProductor.TabIndex = 111
        Me.txtProductor.TabStop = False
        Me.txtProductor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 13)
        Me.Label3.TabIndex = 112
        Me.Label3.Text = "No. de Productor"
        '
        'gbProductor
        '
        Me.gbProductor.Controls.Add(Me.Label3)
        Me.gbProductor.Controls.Add(Me.dtpFechaConsulta)
        Me.gbProductor.Controls.Add(Me.txtProductor)
        Me.gbProductor.Controls.Add(Me.Label15)
        Me.gbProductor.Controls.Add(Me.btnSalir)
        Me.gbProductor.Controls.Add(Me.Label1)
        Me.gbProductor.Controls.Add(Me.cbSustraeActual)
        Me.gbProductor.Controls.Add(Me.btnGuardar)
        Me.gbProductor.Controls.Add(Me.Label27)
        Me.gbProductor.Controls.Add(Me.Label26)
        Me.gbProductor.Controls.Add(Me.Label25)
        Me.gbProductor.Location = New System.Drawing.Point(204, 66)
        Me.gbProductor.Name = "gbProductor"
        Me.gbProductor.Size = New System.Drawing.Size(303, 269)
        Me.gbProductor.TabIndex = 113
        Me.gbProductor.TabStop = False
        Me.gbProductor.Visible = False
        '
        'frmSustrae
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(539, 362)
        Me.Controls.Add(Me.gbProductor)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbProductores)
        Me.Name = "frmSustrae"
        Me.Text = "Registro de Consultas al SUSTRAE"
        Me.gbProductor.ResumeLayout(False)
        Me.gbProductor.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents cbSustraeActual As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbProductores As System.Windows.Forms.ComboBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaConsulta As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtProductor As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents gbProductor As System.Windows.Forms.GroupBox
End Class
