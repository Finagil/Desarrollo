<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEdoCtaFB
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
        Me.txtIDCredito = New System.Windows.Forms.TextBox
        Me.lblIDCredito = New System.Windows.Forms.Label
        Me.txtAcreditado = New System.Windows.Forms.TextBox
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.PanelProcesar = New System.Windows.Forms.Panel
        Me.btnProcesar = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpProceso = New System.Windows.Forms.DateTimePicker
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbPasivoTotal = New System.Windows.Forms.RadioButton
        Me.rbPorAcreditado = New System.Windows.Forms.RadioButton
        Me.rbPorCredito = New System.Windows.Forms.RadioButton
        Me.lblAcreditado = New System.Windows.Forms.Label
        Me.PanelProcesar.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtIDCredito
        '
        Me.txtIDCredito.Location = New System.Drawing.Point(275, 31)
        Me.txtIDCredito.Name = "txtIDCredito"
        Me.txtIDCredito.ReadOnly = True
        Me.txtIDCredito.Size = New System.Drawing.Size(76, 20)
        Me.txtIDCredito.TabIndex = 12
        Me.txtIDCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblIDCredito
        '
        Me.lblIDCredito.AutoSize = True
        Me.lblIDCredito.Location = New System.Drawing.Point(205, 35)
        Me.lblIDCredito.Name = "lblIDCredito"
        Me.lblIDCredito.Size = New System.Drawing.Size(54, 13)
        Me.lblIDCredito.TabIndex = 13
        Me.lblIDCredito.Text = "ID Crédito"
        Me.lblIDCredito.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAcreditado
        '
        Me.txtAcreditado.Location = New System.Drawing.Point(275, 66)
        Me.txtAcreditado.Name = "txtAcreditado"
        Me.txtAcreditado.ReadOnly = True
        Me.txtAcreditado.Size = New System.Drawing.Size(651, 20)
        Me.txtAcreditado.TabIndex = 14
        Me.txtAcreditado.Visible = False
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(19, 158)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(984, 527)
        Me.CrystalReportViewer1.TabIndex = 15
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'PanelProcesar
        '
        Me.PanelProcesar.Controls.Add(Me.btnProcesar)
        Me.PanelProcesar.Controls.Add(Me.Label2)
        Me.PanelProcesar.Controls.Add(Me.dtpProceso)
        Me.PanelProcesar.Location = New System.Drawing.Point(197, 100)
        Me.PanelProcesar.Name = "PanelProcesar"
        Me.PanelProcesar.Size = New System.Drawing.Size(424, 35)
        Me.PanelProcesar.TabIndex = 37
        Me.PanelProcesar.Visible = False
        '
        'btnProcesar
        '
        Me.btnProcesar.Location = New System.Drawing.Point(299, 6)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(75, 23)
        Me.btnProcesar.TabIndex = 27
        Me.btnProcesar.Text = "Procesar"
        Me.btnProcesar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(139, 13)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Fecha de corte de intereses"
        '
        'dtpProceso
        '
        Me.dtpProceso.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpProceso.Location = New System.Drawing.Point(152, 7)
        Me.dtpProceso.Name = "dtpProceso"
        Me.dtpProceso.Size = New System.Drawing.Size(93, 20)
        Me.dtpProceso.TabIndex = 25
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbPasivoTotal)
        Me.GroupBox1.Controls.Add(Me.rbPorAcreditado)
        Me.GroupBox1.Controls.Add(Me.rbPorCredito)
        Me.GroupBox1.Location = New System.Drawing.Point(19, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(168, 123)
        Me.GroupBox1.TabIndex = 28
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Selecciona el tipo de Reporte"
        '
        'rbPasivoTotal
        '
        Me.rbPasivoTotal.AutoSize = True
        Me.rbPasivoTotal.Location = New System.Drawing.Point(8, 93)
        Me.rbPasivoTotal.Name = "rbPasivoTotal"
        Me.rbPasivoTotal.Size = New System.Drawing.Size(84, 17)
        Me.rbPasivoTotal.TabIndex = 2
        Me.rbPasivoTotal.Text = "Pasivo Total"
        Me.rbPasivoTotal.UseVisualStyleBackColor = True
        '
        'rbPorAcreditado
        '
        Me.rbPorAcreditado.AutoSize = True
        Me.rbPorAcreditado.Location = New System.Drawing.Point(8, 57)
        Me.rbPorAcreditado.Name = "rbPorAcreditado"
        Me.rbPorAcreditado.Size = New System.Drawing.Size(95, 17)
        Me.rbPorAcreditado.TabIndex = 1
        Me.rbPorAcreditado.Text = "Por Acreditado"
        Me.rbPorAcreditado.UseVisualStyleBackColor = True
        '
        'rbPorCredito
        '
        Me.rbPorCredito.AutoSize = True
        Me.rbPorCredito.Location = New System.Drawing.Point(8, 22)
        Me.rbPorCredito.Name = "rbPorCredito"
        Me.rbPorCredito.Size = New System.Drawing.Size(77, 17)
        Me.rbPorCredito.TabIndex = 0
        Me.rbPorCredito.Text = "Por Crédito"
        Me.rbPorCredito.UseVisualStyleBackColor = True
        '
        'lblAcreditado
        '
        Me.lblAcreditado.AutoSize = True
        Me.lblAcreditado.Location = New System.Drawing.Point(205, 69)
        Me.lblAcreditado.Name = "lblAcreditado"
        Me.lblAcreditado.Size = New System.Drawing.Size(58, 13)
        Me.lblAcreditado.TabIndex = 38
        Me.lblAcreditado.Text = "Acreditado"
        Me.lblAcreditado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblAcreditado.Visible = False
        '
        'frmEdoCtaFB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1024, 702)
        Me.Controls.Add(Me.lblAcreditado)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PanelProcesar)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.txtAcreditado)
        Me.Controls.Add(Me.lblIDCredito)
        Me.Controls.Add(Me.txtIDCredito)
        Me.Name = "frmEdoCtaFB"
        Me.Text = "Estados de Cuenta del Pasivo con FIRA"
        Me.PanelProcesar.ResumeLayout(False)
        Me.PanelProcesar.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtIDCredito As System.Windows.Forms.TextBox
    Friend WithEvents lblIDCredito As System.Windows.Forms.Label
    Friend WithEvents txtAcreditado As System.Windows.Forms.TextBox
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents PanelProcesar As System.Windows.Forms.Panel
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpProceso As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbPasivoTotal As System.Windows.Forms.RadioButton
    Friend WithEvents rbPorAcreditado As System.Windows.Forms.RadioButton
    Friend WithEvents rbPorCredito As System.Windows.Forms.RadioButton
    Friend WithEvents lblAcreditado As System.Windows.Forms.Label
End Class
