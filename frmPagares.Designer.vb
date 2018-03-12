<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPagares
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
        Me.gbDatosFINAGIL = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtLineaAutorizada = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtNombreProductor = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.gbPagares = New System.Windows.Forms.GroupBox
        Me.lblMinistradoFINAGIL = New System.Windows.Forms.Label
        Me.panelFINAGIL = New System.Windows.Forms.Panel
        Me.btnCancelarFINAGIL = New System.Windows.Forms.Button
        Me.btnGuardarFINAGIL = New System.Windows.Forms.Button
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtImporteFINAGIL = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.dtpFechaFINAGIL = New System.Windows.Forms.DateTimePicker
        Me.dgvFINAGIL = New System.Windows.Forms.DataGridView
        Me.btnModificarFINAGIL = New System.Windows.Forms.Button
        Me.btnInsertarFINAGIL = New System.Windows.Forms.Button
        Me.txtAnexo = New System.Windows.Forms.TextBox
        Me.gbDatosFINAGIL.SuspendLayout()
        Me.gbPagares.SuspendLayout()
        Me.panelFINAGIL.SuspendLayout()
        CType(Me.dgvFINAGIL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(442, 634)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 58
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'gbDatosFINAGIL
        '
        Me.gbDatosFINAGIL.Controls.Add(Me.txtAnexo)
        Me.gbDatosFINAGIL.Controls.Add(Me.Label6)
        Me.gbDatosFINAGIL.Controls.Add(Me.txtLineaAutorizada)
        Me.gbDatosFINAGIL.Controls.Add(Me.Label16)
        Me.gbDatosFINAGIL.Controls.Add(Me.txtNombreProductor)
        Me.gbDatosFINAGIL.Controls.Add(Me.Label2)
        Me.gbDatosFINAGIL.Location = New System.Drawing.Point(64, 17)
        Me.gbDatosFINAGIL.Name = "gbDatosFINAGIL"
        Me.gbDatosFINAGIL.Size = New System.Drawing.Size(885, 133)
        Me.gbDatosFINAGIL.TabIndex = 57
        Me.gbDatosFINAGIL.TabStop = False
        Me.gbDatosFINAGIL.Text = "Datos del Contrato"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(63, 30)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(116, 19)
        Me.Label6.TabIndex = 54
        Me.Label6.Text = "Nombre del Productor"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLineaAutorizada
        '
        Me.txtLineaAutorizada.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLineaAutorizada.Location = New System.Drawing.Point(182, 95)
        Me.txtLineaAutorizada.Name = "txtLineaAutorizada"
        Me.txtLineaAutorizada.ReadOnly = True
        Me.txtLineaAutorizada.Size = New System.Drawing.Size(100, 20)
        Me.txtLineaAutorizada.TabIndex = 53
        Me.txtLineaAutorizada.TabStop = False
        Me.txtLineaAutorizada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(63, 96)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(91, 19)
        Me.Label16.TabIndex = 52
        Me.Label16.Text = "Línea autorizada"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNombreProductor
        '
        Me.txtNombreProductor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreProductor.Location = New System.Drawing.Point(182, 30)
        Me.txtNombreProductor.Name = "txtNombreProductor"
        Me.txtNombreProductor.ReadOnly = True
        Me.txtNombreProductor.Size = New System.Drawing.Size(639, 20)
        Me.txtNombreProductor.TabIndex = 51
        Me.txtNombreProductor.TabStop = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(63, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 19)
        Me.Label2.TabIndex = 49
        Me.Label2.Text = "No. de Contrato"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gbPagares
        '
        Me.gbPagares.Controls.Add(Me.lblMinistradoFINAGIL)
        Me.gbPagares.Controls.Add(Me.panelFINAGIL)
        Me.gbPagares.Controls.Add(Me.dgvFINAGIL)
        Me.gbPagares.Controls.Add(Me.btnModificarFINAGIL)
        Me.gbPagares.Controls.Add(Me.btnInsertarFINAGIL)
        Me.gbPagares.Location = New System.Drawing.Point(230, 171)
        Me.gbPagares.Name = "gbPagares"
        Me.gbPagares.Size = New System.Drawing.Size(517, 431)
        Me.gbPagares.TabIndex = 51
        Me.gbPagares.TabStop = False
        Me.gbPagares.Text = "Pagarés Productor"
        '
        'lblMinistradoFINAGIL
        '
        Me.lblMinistradoFINAGIL.AutoSize = True
        Me.lblMinistradoFINAGIL.Location = New System.Drawing.Point(170, 242)
        Me.lblMinistradoFINAGIL.Name = "lblMinistradoFINAGIL"
        Me.lblMinistradoFINAGIL.Size = New System.Drawing.Size(171, 13)
        Me.lblMinistradoFINAGIL.TabIndex = 20
        Me.lblMinistradoFINAGIL.Text = "Suma de los pagarés capturados $"
        '
        'panelFINAGIL
        '
        Me.panelFINAGIL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelFINAGIL.Controls.Add(Me.btnCancelarFINAGIL)
        Me.panelFINAGIL.Controls.Add(Me.btnGuardarFINAGIL)
        Me.panelFINAGIL.Controls.Add(Me.Label22)
        Me.panelFINAGIL.Controls.Add(Me.txtImporteFINAGIL)
        Me.panelFINAGIL.Controls.Add(Me.Label21)
        Me.panelFINAGIL.Controls.Add(Me.dtpFechaFINAGIL)
        Me.panelFINAGIL.Location = New System.Drawing.Point(177, 287)
        Me.panelFINAGIL.Name = "panelFINAGIL"
        Me.panelFINAGIL.Size = New System.Drawing.Size(322, 123)
        Me.panelFINAGIL.TabIndex = 19
        '
        'btnCancelarFINAGIL
        '
        Me.btnCancelarFINAGIL.Location = New System.Drawing.Point(227, 80)
        Me.btnCancelarFINAGIL.Name = "btnCancelarFINAGIL"
        Me.btnCancelarFINAGIL.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelarFINAGIL.TabIndex = 27
        Me.btnCancelarFINAGIL.Text = "Cancelar"
        Me.btnCancelarFINAGIL.UseVisualStyleBackColor = True
        '
        'btnGuardarFINAGIL
        '
        Me.btnGuardarFINAGIL.Location = New System.Drawing.Point(26, 80)
        Me.btnGuardarFINAGIL.Name = "btnGuardarFINAGIL"
        Me.btnGuardarFINAGIL.Size = New System.Drawing.Size(75, 23)
        Me.btnGuardarFINAGIL.TabIndex = 26
        Me.btnGuardarFINAGIL.Text = "Guardar"
        Me.btnGuardarFINAGIL.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(23, 43)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(118, 19)
        Me.Label22.TabIndex = 21
        Me.Label22.Text = "Importe"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtImporteFINAGIL
        '
        Me.txtImporteFINAGIL.Location = New System.Drawing.Point(202, 42)
        Me.txtImporteFINAGIL.Name = "txtImporteFINAGIL"
        Me.txtImporteFINAGIL.Size = New System.Drawing.Size(100, 20)
        Me.txtImporteFINAGIL.TabIndex = 20
        Me.txtImporteFINAGIL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(23, 13)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(118, 19)
        Me.Label21.TabIndex = 19
        Me.Label21.Text = "Fecha del Documento"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFechaFINAGIL
        '
        Me.dtpFechaFINAGIL.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFINAGIL.Location = New System.Drawing.Point(216, 13)
        Me.dtpFechaFINAGIL.Name = "dtpFechaFINAGIL"
        Me.dtpFechaFINAGIL.Size = New System.Drawing.Size(86, 20)
        Me.dtpFechaFINAGIL.TabIndex = 18
        '
        'dgvFINAGIL
        '
        Me.dgvFINAGIL.AllowUserToDeleteRows = False
        Me.dgvFINAGIL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFINAGIL.Location = New System.Drawing.Point(10, 19)
        Me.dgvFINAGIL.Name = "dgvFINAGIL"
        Me.dgvFINAGIL.ReadOnly = True
        Me.dgvFINAGIL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvFINAGIL.Size = New System.Drawing.Size(489, 209)
        Me.dgvFINAGIL.TabIndex = 18
        '
        'btnModificarFINAGIL
        '
        Me.btnModificarFINAGIL.Location = New System.Drawing.Point(59, 325)
        Me.btnModificarFINAGIL.Name = "btnModificarFINAGIL"
        Me.btnModificarFINAGIL.Size = New System.Drawing.Size(75, 23)
        Me.btnModificarFINAGIL.TabIndex = 6
        Me.btnModificarFINAGIL.Text = "Modificar"
        Me.btnModificarFINAGIL.UseVisualStyleBackColor = True
        '
        'btnInsertarFINAGIL
        '
        Me.btnInsertarFINAGIL.Location = New System.Drawing.Point(59, 287)
        Me.btnInsertarFINAGIL.Name = "btnInsertarFINAGIL"
        Me.btnInsertarFINAGIL.Size = New System.Drawing.Size(75, 23)
        Me.btnInsertarFINAGIL.TabIndex = 5
        Me.btnInsertarFINAGIL.Text = "Insertar"
        Me.btnInsertarFINAGIL.UseVisualStyleBackColor = True
        '
        'txtAnexo
        '
        Me.txtAnexo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnexo.Location = New System.Drawing.Point(182, 65)
        Me.txtAnexo.Name = "txtAnexo"
        Me.txtAnexo.ReadOnly = True
        Me.txtAnexo.Size = New System.Drawing.Size(639, 20)
        Me.txtAnexo.TabIndex = 55
        '
        'frmPagares
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1024, 702)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.gbDatosFINAGIL)
        Me.Controls.Add(Me.gbPagares)
        Me.Name = "frmPagares"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registro de Pagarés"
        Me.gbDatosFINAGIL.ResumeLayout(False)
        Me.gbDatosFINAGIL.PerformLayout()
        Me.gbPagares.ResumeLayout(False)
        Me.gbPagares.PerformLayout()
        Me.panelFINAGIL.ResumeLayout(False)
        Me.panelFINAGIL.PerformLayout()
        CType(Me.dgvFINAGIL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents gbDatosFINAGIL As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtLineaAutorizada As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtNombreProductor As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents gbPagares As System.Windows.Forms.GroupBox
    Friend WithEvents lblMinistradoFINAGIL As System.Windows.Forms.Label
    Friend WithEvents panelFINAGIL As System.Windows.Forms.Panel
    Friend WithEvents btnCancelarFINAGIL As System.Windows.Forms.Button
    Friend WithEvents btnGuardarFINAGIL As System.Windows.Forms.Button
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtImporteFINAGIL As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaFINAGIL As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgvFINAGIL As System.Windows.Forms.DataGridView
    Friend WithEvents btnModificarFINAGIL As System.Windows.Forms.Button
    Friend WithEvents btnInsertarFINAGIL As System.Windows.Forms.Button
    Friend WithEvents txtAnexo As System.Windows.Forms.TextBox
End Class
