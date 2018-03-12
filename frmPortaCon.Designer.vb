<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPortaCon
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
        Me.btnProcesar = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.dtpProcesar = New System.Windows.Forms.DateTimePicker
        Me.dgvVencida = New System.Windows.Forms.DataGridView
        Me.dgvAF = New System.Windows.Forms.DataGridView
        Me.dgvCR = New System.Windows.Forms.DataGridView
        Me.dgvCS = New System.Windows.Forms.DataGridView
        Me.dgvCHA = New System.Windows.Forms.DataGridView
        Me.dgvSeguros = New System.Windows.Forms.DataGridView
        Me.dgvExigible = New System.Windows.Forms.DataGridView
        Me.dgvCC = New System.Windows.Forms.DataGridView
        Me.dgvTodo = New System.Windows.Forms.DataGridView
        CType(Me.dgvVencida, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCHA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSeguros, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvExigible, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTodo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(368, 19)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(80, 24)
        Me.btnSalir.TabIndex = 33
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnProcesar
        '
        Me.btnProcesar.Location = New System.Drawing.Point(262, 19)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(80, 24)
        Me.btnProcesar.TabIndex = 32
        Me.btnProcesar.Text = "Procesar"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(26, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(116, 16)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "Fecha de Proceso"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpProcesar
        '
        Me.dtpProcesar.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpProcesar.Location = New System.Drawing.Point(146, 21)
        Me.dtpProcesar.Name = "dtpProcesar"
        Me.dtpProcesar.Size = New System.Drawing.Size(88, 20)
        Me.dtpProcesar.TabIndex = 30
        '
        'dgvVencida
        '
        Me.dgvVencida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVencida.Location = New System.Drawing.Point(29, 90)
        Me.dgvVencida.Name = "dgvVencida"
        Me.dgvVencida.Size = New System.Drawing.Size(316, 185)
        Me.dgvVencida.TabIndex = 34
        '
        'dgvAF
        '
        Me.dgvAF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAF.Location = New System.Drawing.Point(351, 90)
        Me.dgvAF.Name = "dgvAF"
        Me.dgvAF.Size = New System.Drawing.Size(316, 185)
        Me.dgvAF.TabIndex = 35
        '
        'dgvCR
        '
        Me.dgvCR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCR.Location = New System.Drawing.Point(673, 90)
        Me.dgvCR.Name = "dgvCR"
        Me.dgvCR.Size = New System.Drawing.Size(316, 185)
        Me.dgvCR.TabIndex = 36
        '
        'dgvCS
        '
        Me.dgvCS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCS.Location = New System.Drawing.Point(29, 281)
        Me.dgvCS.Name = "dgvCS"
        Me.dgvCS.Size = New System.Drawing.Size(316, 185)
        Me.dgvCS.TabIndex = 37
        '
        'dgvCHA
        '
        Me.dgvCHA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCHA.Location = New System.Drawing.Point(351, 281)
        Me.dgvCHA.Name = "dgvCHA"
        Me.dgvCHA.Size = New System.Drawing.Size(316, 185)
        Me.dgvCHA.TabIndex = 38
        '
        'dgvSeguros
        '
        Me.dgvSeguros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSeguros.Location = New System.Drawing.Point(29, 472)
        Me.dgvSeguros.Name = "dgvSeguros"
        Me.dgvSeguros.Size = New System.Drawing.Size(316, 185)
        Me.dgvSeguros.TabIndex = 39
        '
        'dgvExigible
        '
        Me.dgvExigible.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvExigible.Location = New System.Drawing.Point(351, 472)
        Me.dgvExigible.Name = "dgvExigible"
        Me.dgvExigible.Size = New System.Drawing.Size(316, 185)
        Me.dgvExigible.TabIndex = 40
        '
        'dgvCC
        '
        Me.dgvCC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCC.Location = New System.Drawing.Point(673, 281)
        Me.dgvCC.Name = "dgvCC"
        Me.dgvCC.Size = New System.Drawing.Size(316, 185)
        Me.dgvCC.TabIndex = 41
        '
        'dgvTodo
        '
        Me.dgvTodo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTodo.Location = New System.Drawing.Point(673, 472)
        Me.dgvTodo.Name = "dgvTodo"
        Me.dgvTodo.Size = New System.Drawing.Size(316, 185)
        Me.dgvTodo.TabIndex = 42
        '
        'frmPortaCon
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1024, 702)
        Me.Controls.Add(Me.dgvTodo)
        Me.Controls.Add(Me.dgvCC)
        Me.Controls.Add(Me.dgvExigible)
        Me.Controls.Add(Me.dgvSeguros)
        Me.Controls.Add(Me.dgvCHA)
        Me.Controls.Add(Me.dgvCS)
        Me.Controls.Add(Me.dgvCR)
        Me.Controls.Add(Me.dgvAF)
        Me.Controls.Add(Me.dgvVencida)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnProcesar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dtpProcesar)
        Me.Name = "frmPortaCon"
        Me.Text = "Portafolio de Cartera Contable"
        CType(Me.dgvVencida, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCHA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSeguros, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvExigible, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTodo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpProcesar As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgvVencida As System.Windows.Forms.DataGridView
    Friend WithEvents dgvAF As System.Windows.Forms.DataGridView
    Friend WithEvents dgvCR As System.Windows.Forms.DataGridView
    Friend WithEvents dgvCS As System.Windows.Forms.DataGridView
    Friend WithEvents dgvCHA As System.Windows.Forms.DataGridView
    Friend WithEvents dgvSeguros As System.Windows.Forms.DataGridView
    Friend WithEvents dgvExigible As System.Windows.Forms.DataGridView
    Friend WithEvents dgvCC As System.Windows.Forms.DataGridView
    Friend WithEvents dgvTodo As System.Windows.Forms.DataGridView
End Class
