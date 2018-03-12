<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEFE
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtpFechaProceso = New System.Windows.Forms.DateTimePicker
        Me.btnEnviar = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(140, 122)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(387, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Selecciona la fecha de las facturas a enviar por correo electrónico"
        '
        'dtpFechaProceso
        '
        Me.dtpFechaProceso.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaProceso.Location = New System.Drawing.Point(282, 151)
        Me.dtpFechaProceso.Name = "dtpFechaProceso"
        Me.dtpFechaProceso.Size = New System.Drawing.Size(95, 20)
        Me.dtpFechaProceso.TabIndex = 6
        '
        'btnEnviar
        '
        Me.btnEnviar.Location = New System.Drawing.Point(273, 286)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(112, 23)
        Me.btnEnviar.TabIndex = 5
        Me.btnEnviar.Text = "Envío de Facturas"
        Me.btnEnviar.UseVisualStyleBackColor = True
        '
        'frmEFE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(657, 493)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpFechaProceso)
        Me.Controls.Add(Me.btnEnviar)
        Me.Name = "frmEFE"
        Me.Text = "Envío de Facturas Electrónicas por eMail"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaProceso As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnEnviar As System.Windows.Forms.Button
End Class
