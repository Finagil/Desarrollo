<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmECTC
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
        Me.btnSalir = New System.Windows.Forms.Button
        Me.lblInicial = New System.Windows.Forms.Label
        Me.dtpProceso = New System.Windows.Forms.DateTimePicker
        Me.btnProcesar = New System.Windows.Forms.Button
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.lblContratos = New System.Windows.Forms.Label
        Me.cbContratos = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(902, 32)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 15
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'lblInicial
        '
        Me.lblInicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInicial.Location = New System.Drawing.Point(279, 35)
        Me.lblInicial.Name = "lblInicial"
        Me.lblInicial.Size = New System.Drawing.Size(101, 16)
        Me.lblInicial.TabIndex = 13
        Me.lblInicial.Text = "Fecha de Proceso"
        Me.lblInicial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpProceso
        '
        Me.dtpProceso.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpProceso.Location = New System.Drawing.Point(383, 33)
        Me.dtpProceso.Name = "dtpProceso"
        Me.dtpProceso.Size = New System.Drawing.Size(88, 20)
        Me.dtpProceso.TabIndex = 14
        '
        'btnProcesar
        '
        Me.btnProcesar.Location = New System.Drawing.Point(804, 32)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(75, 23)
        Me.btnProcesar.TabIndex = 12
        Me.btnProcesar.Text = "Procesar"
        Me.btnProcesar.UseVisualStyleBackColor = True
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(40, 83)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(937, 586)
        Me.CrystalReportViewer1.TabIndex = 16
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'lblContratos
        '
        Me.lblContratos.Location = New System.Drawing.Point(36, 32)
        Me.lblContratos.Name = "lblContratos"
        Me.lblContratos.Size = New System.Drawing.Size(59, 23)
        Me.lblContratos.TabIndex = 18
        Me.lblContratos.Text = "Contratos"
        Me.lblContratos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbContratos
        '
        Me.cbContratos.FormattingEnabled = True
        Me.cbContratos.Location = New System.Drawing.Point(99, 33)
        Me.cbContratos.Name = "cbContratos"
        Me.cbContratos.Size = New System.Drawing.Size(117, 21)
        Me.cbContratos.TabIndex = 20
        '
        'frmECTC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1024, 702)
        Me.Controls.Add(Me.cbContratos)
        Me.Controls.Add(Me.lblContratos)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.lblInicial)
        Me.Controls.Add(Me.dtpProceso)
        Me.Controls.Add(Me.btnProcesar)
        Me.Name = "frmECTC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estado de Cuenta de todos los Productores"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents lblInicial As System.Windows.Forms.Label
    Friend WithEvents dtpProceso As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents lblContratos As System.Windows.Forms.Label
    Friend WithEvents cbContratos As System.Windows.Forms.ComboBox
End Class
