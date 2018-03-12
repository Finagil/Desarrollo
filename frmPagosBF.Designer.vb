<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPagosBF
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
        Me.btnAplicar = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btnAumentar = New System.Windows.Forms.Button
        Me.txtPagoTotal = New System.Windows.Forms.TextBox
        Me.txtPagoParcial = New System.Windows.Forms.TextBox
        Me.rbParcial = New System.Windows.Forms.RadioButton
        Me.rbTotal = New System.Windows.Forms.RadioButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnProcesar = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpProceso = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtMontoTotal = New System.Windows.Forms.TextBox
        Me.dgvPagados = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgvDeudores = New System.Windows.Forms.DataGridView
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvPagados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDeudores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(925, 665)
        Me.btnAplicar.Name = "btnAplicar"
        Me.btnAplicar.Size = New System.Drawing.Size(75, 23)
        Me.btnAplicar.TabIndex = 39
        Me.btnAplicar.Text = "Aplicar pagos"
        Me.btnAplicar.UseVisualStyleBackColor = True
        Me.btnAplicar.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 451)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 13)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "Créditos a pagar"
        Me.Label3.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnAumentar)
        Me.Panel2.Controls.Add(Me.txtPagoTotal)
        Me.Panel2.Controls.Add(Me.txtPagoParcial)
        Me.Panel2.Controls.Add(Me.rbParcial)
        Me.Panel2.Controls.Add(Me.rbTotal)
        Me.Panel2.Location = New System.Drawing.Point(326, 369)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(390, 92)
        Me.Panel2.TabIndex = 37
        Me.Panel2.Visible = False
        '
        'btnAumentar
        '
        Me.btnAumentar.Enabled = False
        Me.btnAumentar.Location = New System.Drawing.Point(254, 33)
        Me.btnAumentar.Name = "btnAumentar"
        Me.btnAumentar.Size = New System.Drawing.Size(114, 23)
        Me.btnAumentar.TabIndex = 33
        Me.btnAumentar.Text = "Añadir a la lista"
        Me.btnAumentar.UseVisualStyleBackColor = True
        '
        'txtPagoTotal
        '
        Me.txtPagoTotal.Location = New System.Drawing.Point(126, 20)
        Me.txtPagoTotal.Name = "txtPagoTotal"
        Me.txtPagoTotal.ReadOnly = True
        Me.txtPagoTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtPagoTotal.TabIndex = 29
        Me.txtPagoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPagoParcial
        '
        Me.txtPagoParcial.Location = New System.Drawing.Point(126, 54)
        Me.txtPagoParcial.Name = "txtPagoParcial"
        Me.txtPagoParcial.Size = New System.Drawing.Size(100, 20)
        Me.txtPagoParcial.TabIndex = 32
        Me.txtPagoParcial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'rbParcial
        '
        Me.rbParcial.Location = New System.Drawing.Point(34, 56)
        Me.rbParcial.Name = "rbParcial"
        Me.rbParcial.Size = New System.Drawing.Size(88, 17)
        Me.rbParcial.TabIndex = 31
        Me.rbParcial.TabStop = True
        Me.rbParcial.Text = "Pago Parcial"
        Me.rbParcial.UseVisualStyleBackColor = True
        '
        'rbTotal
        '
        Me.rbTotal.Location = New System.Drawing.Point(34, 22)
        Me.rbTotal.Name = "rbTotal"
        Me.rbTotal.Size = New System.Drawing.Size(88, 17)
        Me.rbTotal.TabIndex = 30
        Me.rbTotal.TabStop = True
        Me.rbTotal.Text = "Pago Total"
        Me.rbTotal.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnProcesar)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.dtpProceso)
        Me.Panel1.Location = New System.Drawing.Point(292, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(424, 35)
        Me.Panel1.TabIndex = 36
        '
        'btnProcesar
        '
        Me.btnProcesar.Location = New System.Drawing.Point(291, 6)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(114, 23)
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(801, 636)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 13)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "Monto total a aplicar"
        Me.Label4.Visible = False
        '
        'txtMontoTotal
        '
        Me.txtMontoTotal.Location = New System.Drawing.Point(910, 633)
        Me.txtMontoTotal.Name = "txtMontoTotal"
        Me.txtMontoTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtMontoTotal.TabIndex = 34
        Me.txtMontoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMontoTotal.Visible = False
        '
        'dgvPagados
        '
        Me.dgvPagados.AllowUserToDeleteRows = False
        Me.dgvPagados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPagados.Location = New System.Drawing.Point(12, 470)
        Me.dgvPagados.Name = "dgvPagados"
        Me.dgvPagados.ReadOnly = True
        Me.dgvPagados.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvPagados.Size = New System.Drawing.Size(1000, 156)
        Me.dgvPagados.TabIndex = 33
        Me.dgvPagados.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 13)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Créditos con Adeudo"
        Me.Label1.Visible = False
        '
        'dgvDeudores
        '
        Me.dgvDeudores.AllowUserToDeleteRows = False
        Me.dgvDeudores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDeudores.Location = New System.Drawing.Point(12, 73)
        Me.dgvDeudores.Name = "dgvDeudores"
        Me.dgvDeudores.ReadOnly = True
        Me.dgvDeudores.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvDeudores.Size = New System.Drawing.Size(998, 285)
        Me.dgvDeudores.TabIndex = 31
        Me.dgvDeudores.Visible = False
        '
        'frmPagosBF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1024, 702)
        Me.Controls.Add(Me.btnAplicar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtMontoTotal)
        Me.Controls.Add(Me.dgvPagados)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvDeudores)
        Me.Name = "frmPagosBF"
        Me.Text = "Aplicación de pagos a FIRA"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvPagados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDeudores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAplicar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnAumentar As System.Windows.Forms.Button
    Friend WithEvents txtPagoTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtPagoParcial As System.Windows.Forms.TextBox
    Friend WithEvents rbParcial As System.Windows.Forms.RadioButton
    Friend WithEvents rbTotal As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpProceso As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMontoTotal As System.Windows.Forms.TextBox
    Friend WithEvents dgvPagados As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvDeudores As System.Windows.Forms.DataGridView
End Class
