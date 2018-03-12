<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMensajeria
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMensajeria))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtPoliza1 = New System.Windows.Forms.TextBox
        Me.txtPoliza2 = New System.Windows.Forms.TextBox
        Me.txtContrato1 = New System.Windows.Forms.MaskedTextBox
        Me.txtPoliza3 = New System.Windows.Forms.TextBox
        Me.txtPoliza4 = New System.Windows.Forms.TextBox
        Me.txtPoliza5 = New System.Windows.Forms.TextBox
        Me.txtContrato2 = New System.Windows.Forms.MaskedTextBox
        Me.txtContrato3 = New System.Windows.Forms.MaskedTextBox
        Me.txtContrato4 = New System.Windows.Forms.MaskedTextBox
        Me.txtContrato5 = New System.Windows.Forms.MaskedTextBox
        Me.btnPrint = New System.Windows.Forms.Button
        Me.lblClientes = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.btnExit = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(25, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Numero de Póliza"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(172, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Contrato"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtPoliza1
        '
        Me.txtPoliza1.Enabled = False
        Me.txtPoliza1.Location = New System.Drawing.Point(23, 100)
        Me.txtPoliza1.Name = "txtPoliza1"
        Me.txtPoliza1.Size = New System.Drawing.Size(133, 20)
        Me.txtPoliza1.TabIndex = 2
        '
        'txtPoliza2
        '
        Me.txtPoliza2.Enabled = False
        Me.txtPoliza2.Location = New System.Drawing.Point(23, 124)
        Me.txtPoliza2.Name = "txtPoliza2"
        Me.txtPoliza2.Size = New System.Drawing.Size(133, 20)
        Me.txtPoliza2.TabIndex = 4
        '
        'txtContrato1
        '
        Me.txtContrato1.BeepOnError = True
        Me.txtContrato1.Enabled = False
        Me.txtContrato1.Location = New System.Drawing.Point(175, 99)
        Me.txtContrato1.Name = "txtContrato1"
        Me.txtContrato1.Size = New System.Drawing.Size(67, 20)
        Me.txtContrato1.TabIndex = 3
        '
        'txtPoliza3
        '
        Me.txtPoliza3.Enabled = False
        Me.txtPoliza3.Location = New System.Drawing.Point(23, 149)
        Me.txtPoliza3.Name = "txtPoliza3"
        Me.txtPoliza3.Size = New System.Drawing.Size(133, 20)
        Me.txtPoliza3.TabIndex = 6
        '
        'txtPoliza4
        '
        Me.txtPoliza4.Enabled = False
        Me.txtPoliza4.Location = New System.Drawing.Point(23, 173)
        Me.txtPoliza4.Name = "txtPoliza4"
        Me.txtPoliza4.Size = New System.Drawing.Size(133, 20)
        Me.txtPoliza4.TabIndex = 8
        '
        'txtPoliza5
        '
        Me.txtPoliza5.Enabled = False
        Me.txtPoliza5.Location = New System.Drawing.Point(23, 198)
        Me.txtPoliza5.Name = "txtPoliza5"
        Me.txtPoliza5.Size = New System.Drawing.Size(133, 20)
        Me.txtPoliza5.TabIndex = 10
        '
        'txtContrato2
        '
        Me.txtContrato2.BeepOnError = True
        Me.txtContrato2.Enabled = False
        Me.txtContrato2.Location = New System.Drawing.Point(175, 123)
        Me.txtContrato2.Name = "txtContrato2"
        Me.txtContrato2.Size = New System.Drawing.Size(67, 20)
        Me.txtContrato2.TabIndex = 5
        '
        'txtContrato3
        '
        Me.txtContrato3.BeepOnError = True
        Me.txtContrato3.Enabled = False
        Me.txtContrato3.Location = New System.Drawing.Point(175, 149)
        Me.txtContrato3.Name = "txtContrato3"
        Me.txtContrato3.Size = New System.Drawing.Size(67, 20)
        Me.txtContrato3.TabIndex = 7
        '
        'txtContrato4
        '
        Me.txtContrato4.BeepOnError = True
        Me.txtContrato4.Enabled = False
        Me.txtContrato4.Location = New System.Drawing.Point(175, 173)
        Me.txtContrato4.Name = "txtContrato4"
        Me.txtContrato4.Size = New System.Drawing.Size(67, 20)
        Me.txtContrato4.TabIndex = 9
        '
        'txtContrato5
        '
        Me.txtContrato5.BeepOnError = True
        Me.txtContrato5.Enabled = False
        Me.txtContrato5.Location = New System.Drawing.Point(175, 196)
        Me.txtContrato5.Name = "txtContrato5"
        Me.txtContrato5.Size = New System.Drawing.Size(67, 20)
        Me.txtContrato5.TabIndex = 11
        '
        'btnPrint
        '
        Me.btnPrint.Enabled = False
        Me.btnPrint.Location = New System.Drawing.Point(261, 191)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(93, 24)
        Me.btnPrint.TabIndex = 12
        Me.btnPrint.Text = "Imprimir"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'lblClientes
        '
        Me.lblClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClientes.Location = New System.Drawing.Point(18, 14)
        Me.lblClientes.Name = "lblClientes"
        Me.lblClientes.Size = New System.Drawing.Size(432, 16)
        Me.lblClientes.TabIndex = 13
        Me.lblClientes.Text = "Selecciona un Cliente de la siguiente Lista"
        '
        'ComboBox1
        '
        Me.ComboBox1.Location = New System.Drawing.Point(18, 38)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(424, 21)
        Me.ComboBox1.TabIndex = 14
        Me.ComboBox1.Text = "ComboBox1"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(364, 191)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(80, 24)
        Me.btnExit.TabIndex = 15
        Me.btnExit.Text = "Salir"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'frmMensajeria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(471, 237)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.lblClientes)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.txtContrato5)
        Me.Controls.Add(Me.txtContrato4)
        Me.Controls.Add(Me.txtContrato3)
        Me.Controls.Add(Me.txtContrato2)
        Me.Controls.Add(Me.txtPoliza5)
        Me.Controls.Add(Me.txtPoliza4)
        Me.Controls.Add(Me.txtPoliza3)
        Me.Controls.Add(Me.txtContrato1)
        Me.Controls.Add(Me.txtPoliza2)
        Me.Controls.Add(Me.txtPoliza1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMensajeria"
        Me.Text = "Envios para Mensajeria"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPoliza1 As System.Windows.Forms.TextBox
    Friend WithEvents txtPoliza2 As System.Windows.Forms.TextBox
    Friend WithEvents txtContrato1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtPoliza3 As System.Windows.Forms.TextBox
    Friend WithEvents txtPoliza4 As System.Windows.Forms.TextBox
    Friend WithEvents txtPoliza5 As System.Windows.Forms.TextBox
    Friend WithEvents txtContrato2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtContrato3 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtContrato4 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtContrato5 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents lblClientes As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
End Class
