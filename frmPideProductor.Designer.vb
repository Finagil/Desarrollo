<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPideProductor
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
        Me.txtMenu = New System.Windows.Forms.TextBox
        Me.lblProductores = New System.Windows.Forms.Label
        Me.cbProductores = New System.Windows.Forms.ComboBox
        Me.lblContratos = New System.Windows.Forms.Label
        Me.lbContratos = New System.Windows.Forms.ListBox
        Me.SuspendLayout()
        '
        'txtMenu
        '
        Me.txtMenu.Location = New System.Drawing.Point(16, 112)
        Me.txtMenu.Name = "txtMenu"
        Me.txtMenu.ReadOnly = True
        Me.txtMenu.Size = New System.Drawing.Size(40, 20)
        Me.txtMenu.TabIndex = 12
        Me.txtMenu.Visible = False
        '
        'lblProductores
        '
        Me.lblProductores.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProductores.Location = New System.Drawing.Point(16, 16)
        Me.lblProductores.Name = "lblProductores"
        Me.lblProductores.Size = New System.Drawing.Size(432, 16)
        Me.lblProductores.TabIndex = 10
        Me.lblProductores.Text = "Selecciona un Productor de la siguiente Lista"
        '
        'cbProductores
        '
        Me.cbProductores.Location = New System.Drawing.Point(16, 40)
        Me.cbProductores.Name = "cbProductores"
        Me.cbProductores.Size = New System.Drawing.Size(424, 21)
        Me.cbProductores.TabIndex = 11
        Me.cbProductores.Text = "ComboBox1"
        '
        'lblContratos
        '
        Me.lblContratos.AutoSize = True
        Me.lblContratos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContratos.Location = New System.Drawing.Point(454, 16)
        Me.lblContratos.Name = "lblContratos"
        Me.lblContratos.Size = New System.Drawing.Size(166, 13)
        Me.lblContratos.TabIndex = 13
        Me.lblContratos.Text = "Contratos de este Productor"
        Me.lblContratos.Visible = False
        '
        'lbContratos
        '
        Me.lbContratos.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbContratos.ItemHeight = 15
        Me.lbContratos.Location = New System.Drawing.Point(461, 40)
        Me.lbContratos.Name = "lbContratos"
        Me.lbContratos.Size = New System.Drawing.Size(419, 469)
        Me.lbContratos.TabIndex = 14
        Me.lbContratos.Visible = False
        '
        'frmPideProductor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(903, 526)
        Me.Controls.Add(Me.lblContratos)
        Me.Controls.Add(Me.lbContratos)
        Me.Controls.Add(Me.txtMenu)
        Me.Controls.Add(Me.lblProductores)
        Me.Controls.Add(Me.cbProductores)
        Me.Name = "frmPideProductor"
        Me.Text = "Selección de Productor y Contrato"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtMenu As System.Windows.Forms.TextBox
    Friend WithEvents lblProductores As System.Windows.Forms.Label
    Friend WithEvents cbProductores As System.Windows.Forms.ComboBox
    Friend WithEvents lblContratos As System.Windows.Forms.Label
    Friend WithEvents lbContratos As System.Windows.Forms.ListBox
End Class
