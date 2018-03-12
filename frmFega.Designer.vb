<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFega
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.btnmodificar = New System.Windows.Forms.Button
        Me.btneliminar = New System.Windows.Forms.Button
        Me.btnagregar = New System.Windows.Forms.Button
        Me.btnmodificar1 = New System.Windows.Forms.Button
        Me.btneliminar1 = New System.Windows.Forms.Button
        Me.btncancelar = New System.Windows.Forms.Button
        Me.btnimprimir = New System.Windows.Forms.Button
        Me.btnguardar = New System.Windows.Forms.Button
        Me.btnsalir = New System.Windows.Forms.Button
        Me.txtFega = New System.Windows.Forms.TextBox
        Me.lblFega = New System.Windows.Forms.Label
        Me.lblVigenciaFega = New System.Windows.Forms.Label
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.tsslMensaje = New System.Windows.Forms.ToolStripStatusLabel
        Me.dtpVigenciaFega = New System.Windows.Forms.DateTimePicker
        Me.dtgFega = New System.Windows.Forms.DataGridView
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fega = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusStrip1.SuspendLayout()
        CType(Me.dtgFega, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnmodificar
        '
        Me.btnmodificar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnmodificar.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnmodificar.Location = New System.Drawing.Point(12, 69)
        Me.btnmodificar.Name = "btnmodificar"
        Me.btnmodificar.Size = New System.Drawing.Size(103, 28)
        Me.btnmodificar.TabIndex = 188
        Me.btnmodificar.Text = "Modificar"
        Me.btnmodificar.UseVisualStyleBackColor = True
        '
        'btneliminar
        '
        Me.btneliminar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btneliminar.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btneliminar.Location = New System.Drawing.Point(12, 121)
        Me.btneliminar.Name = "btneliminar"
        Me.btneliminar.Size = New System.Drawing.Size(103, 28)
        Me.btneliminar.TabIndex = 187
        Me.btneliminar.Text = "Eliminar"
        Me.btneliminar.UseVisualStyleBackColor = True
        '
        'btnagregar
        '
        Me.btnagregar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnagregar.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnagregar.Location = New System.Drawing.Point(12, 18)
        Me.btnagregar.Name = "btnagregar"
        Me.btnagregar.Size = New System.Drawing.Size(103, 28)
        Me.btnagregar.TabIndex = 186
        Me.btnagregar.Text = "Agregar"
        Me.btnagregar.UseVisualStyleBackColor = True
        '
        'btnmodificar1
        '
        Me.btnmodificar1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnmodificar1.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnmodificar1.Location = New System.Drawing.Point(330, 18)
        Me.btnmodificar1.Name = "btnmodificar1"
        Me.btnmodificar1.Size = New System.Drawing.Size(103, 28)
        Me.btnmodificar1.TabIndex = 193
        Me.btnmodificar1.Text = "Modificar"
        Me.btnmodificar1.UseVisualStyleBackColor = True
        Me.btnmodificar1.Visible = False
        '
        'btneliminar1
        '
        Me.btneliminar1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btneliminar1.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btneliminar1.Location = New System.Drawing.Point(330, 18)
        Me.btneliminar1.Name = "btneliminar1"
        Me.btneliminar1.Size = New System.Drawing.Size(103, 28)
        Me.btneliminar1.TabIndex = 194
        Me.btneliminar1.Text = "Eliminar"
        Me.btneliminar1.UseVisualStyleBackColor = True
        Me.btneliminar1.Visible = False
        '
        'btncancelar
        '
        Me.btncancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btncancelar.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncancelar.Location = New System.Drawing.Point(188, 18)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(103, 28)
        Me.btncancelar.TabIndex = 189
        Me.btncancelar.Text = "Cancelar"
        Me.btncancelar.UseVisualStyleBackColor = True
        Me.btncancelar.Visible = False
        '
        'btnimprimir
        '
        Me.btnimprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnimprimir.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnimprimir.Location = New System.Drawing.Point(12, 176)
        Me.btnimprimir.Name = "btnimprimir"
        Me.btnimprimir.Size = New System.Drawing.Size(103, 28)
        Me.btnimprimir.TabIndex = 192
        Me.btnimprimir.Text = "Imprimir"
        Me.btnimprimir.UseVisualStyleBackColor = True
        '
        'btnguardar
        '
        Me.btnguardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnguardar.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnguardar.Location = New System.Drawing.Point(330, 18)
        Me.btnguardar.Name = "btnguardar"
        Me.btnguardar.Size = New System.Drawing.Size(103, 28)
        Me.btnguardar.TabIndex = 191
        Me.btnguardar.Text = "Guardar"
        Me.btnguardar.UseVisualStyleBackColor = True
        Me.btnguardar.Visible = False
        '
        'btnsalir
        '
        Me.btnsalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsalir.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsalir.Location = New System.Drawing.Point(12, 231)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(103, 28)
        Me.btnsalir.TabIndex = 190
        Me.btnsalir.Text = "Salir"
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'txtFega
        '
        Me.txtFega.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFega.Enabled = False
        Me.txtFega.Location = New System.Drawing.Point(298, 134)
        Me.txtFega.MaxLength = 30
        Me.txtFega.Name = "txtFega"
        Me.txtFega.Size = New System.Drawing.Size(100, 20)
        Me.txtFega.TabIndex = 182
        '
        'lblFega
        '
        Me.lblFega.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFega.Location = New System.Drawing.Point(185, 137)
        Me.lblFega.Name = "lblFega"
        Me.lblFega.Size = New System.Drawing.Size(96, 25)
        Me.lblFega.TabIndex = 180
        Me.lblFega.Text = "Fega"
        '
        'lblVigenciaFega
        '
        Me.lblVigenciaFega.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVigenciaFega.Location = New System.Drawing.Point(185, 88)
        Me.lblVigenciaFega.Name = "lblVigenciaFega"
        Me.lblVigenciaFega.Size = New System.Drawing.Size(96, 29)
        Me.lblVigenciaFega.TabIndex = 179
        Me.lblVigenciaFega.Text = "Vigencia:"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslMensaje})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 269)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(479, 22)
        Me.StatusStrip1.TabIndex = 198
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tsslMensaje
        '
        Me.tsslMensaje.Name = "tsslMensaje"
        Me.tsslMensaje.Size = New System.Drawing.Size(0, 17)
        '
        'dtpVigenciaFega
        '
        Me.dtpVigenciaFega.Enabled = False
        Me.dtpVigenciaFega.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpVigenciaFega.Location = New System.Drawing.Point(298, 87)
        Me.dtpVigenciaFega.Name = "dtpVigenciaFega"
        Me.dtpVigenciaFega.Size = New System.Drawing.Size(100, 20)
        Me.dtpVigenciaFega.TabIndex = 199
        '
        'dtgFega
        '
        Me.dtgFega.AllowUserToAddRows = False
        Me.dtgFega.AllowUserToDeleteRows = False
        Me.dtgFega.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.Format = "d"
        DataGridViewCellStyle1.NullValue = Nothing
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgFega.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgFega.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgFega.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Fecha, Me.Fega})
        Me.dtgFega.Location = New System.Drawing.Point(129, 12)
        Me.dtgFega.MultiSelect = False
        Me.dtgFega.Name = "dtgFega"
        Me.dtgFega.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.NullValue = Nothing
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgFega.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtgFega.RowHeadersWidth = 25
        Me.dtgFega.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgFega.Size = New System.Drawing.Size(340, 247)
        Me.dtgFega.TabIndex = 200
        '
        'Id
        '
        Me.Id.DataPropertyName = "IdFega"
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.ReadOnly = True
        Me.Id.Visible = False
        '
        'Fecha
        '
        Me.Fecha.DataPropertyName = "FechaVigencia"
        Me.Fecha.HeaderText = "Fecha de vigencia"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        '
        'Fega
        '
        Me.Fega.DataPropertyName = "Fega"
        Me.Fega.HeaderText = "Comisión FEGA"
        Me.Fega.Name = "Fega"
        Me.Fega.ReadOnly = True
        '
        'frmFega
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(479, 291)
        Me.Controls.Add(Me.dtgFega)
        Me.Controls.Add(Me.dtpVigenciaFega)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btnmodificar)
        Me.Controls.Add(Me.btneliminar)
        Me.Controls.Add(Me.btnagregar)
        Me.Controls.Add(Me.btnmodificar1)
        Me.Controls.Add(Me.btneliminar1)
        Me.Controls.Add(Me.btncancelar)
        Me.Controls.Add(Me.btnimprimir)
        Me.Controls.Add(Me.btnguardar)
        Me.Controls.Add(Me.btnsalir)
        Me.Controls.Add(Me.txtFega)
        Me.Controls.Add(Me.lblFega)
        Me.Controls.Add(Me.lblVigenciaFega)
        Me.Name = "frmFega"
        Me.Text = "frmFega"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.dtgFega, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnmodificar As System.Windows.Forms.Button
    Friend WithEvents btneliminar As System.Windows.Forms.Button
    Friend WithEvents btnagregar As System.Windows.Forms.Button
    Friend WithEvents btnmodificar1 As System.Windows.Forms.Button
    Friend WithEvents btneliminar1 As System.Windows.Forms.Button
    Friend WithEvents btncancelar As System.Windows.Forms.Button
    Friend WithEvents btnimprimir As System.Windows.Forms.Button
    Friend WithEvents btnguardar As System.Windows.Forms.Button
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents txtFega As System.Windows.Forms.TextBox
    Friend WithEvents lblFega As System.Windows.Forms.Label
    Friend WithEvents lblVigenciaFega As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tsslMensaje As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents dtpVigenciaFega As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtgFega As System.Windows.Forms.DataGridView
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fega As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
