<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAltaContratos
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
        Me.txtLineaAutorizada = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtProductor = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbProductores = New System.Windows.Forms.ComboBox
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.dtpFechaAutorizacion = New System.Windows.Forms.DateTimePicker
        Me.cbEstrato = New System.Windows.Forms.ComboBox
        Me.lblDiferencialFINAGIL = New System.Windows.Forms.Label
        Me.cbSustrae = New System.Windows.Forms.ComboBox
        Me.txtDiferencialFINAGIL = New System.Windows.Forms.TextBox
        Me.txtFinanciamientoActual = New System.Windows.Forms.TextBox
        Me.txtToneladasHectarea = New System.Windows.Forms.TextBox
        Me.txtPrecioTonelada = New System.Windows.Forms.TextBox
        Me.txtCostoHectarea = New System.Windows.Forms.TextBox
        Me.txtHectareasActual = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'txtLineaAutorizada
        '
        Me.txtLineaAutorizada.Location = New System.Drawing.Point(190, 101)
        Me.txtLineaAutorizada.Name = "txtLineaAutorizada"
        Me.txtLineaAutorizada.Size = New System.Drawing.Size(100, 20)
        Me.txtLineaAutorizada.TabIndex = 1
        Me.txtLineaAutorizada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(32, 101)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(151, 19)
        Me.Label16.TabIndex = 43
        Me.Label16.Text = "Línea autorizada"
        '
        'txtProductor
        '
        Me.txtProductor.Location = New System.Drawing.Point(635, 67)
        Me.txtProductor.Name = "txtProductor"
        Me.txtProductor.ReadOnly = True
        Me.txtProductor.Size = New System.Drawing.Size(43, 20)
        Me.txtProductor.TabIndex = 37
        Me.txtProductor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(32, 68)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(118, 19)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "Fecha de Autorización"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(513, 128)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 19)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "SUSTRAE"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(513, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 19)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Estrato"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(32, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 19)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Nombre del Productor"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(513, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 19)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "No. de Productor"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbProductores
        '
        Me.cbProductores.Location = New System.Drawing.Point(152, 18)
        Me.cbProductores.Name = "cbProductores"
        Me.cbProductores.Size = New System.Drawing.Size(538, 21)
        Me.cbProductores.TabIndex = 46
        Me.cbProductores.Text = "ComboBox1"
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(263, 323)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 23)
        Me.btnGuardar.TabIndex = 9
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(399, 323)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 10
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'dtpFechaAutorizacion
        '
        Me.dtpFechaAutorizacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaAutorizacion.Location = New System.Drawing.Point(197, 67)
        Me.dtpFechaAutorizacion.Name = "dtpFechaAutorizacion"
        Me.dtpFechaAutorizacion.Size = New System.Drawing.Size(86, 20)
        Me.dtpFechaAutorizacion.TabIndex = 49
        '
        'cbEstrato
        '
        Me.cbEstrato.FormattingEnabled = True
        Me.cbEstrato.Location = New System.Drawing.Point(620, 97)
        Me.cbEstrato.Name = "cbEstrato"
        Me.cbEstrato.Size = New System.Drawing.Size(59, 21)
        Me.cbEstrato.TabIndex = 50
        '
        'lblDiferencialFINAGIL
        '
        Me.lblDiferencialFINAGIL.Location = New System.Drawing.Point(513, 158)
        Me.lblDiferencialFINAGIL.Name = "lblDiferencialFINAGIL"
        Me.lblDiferencialFINAGIL.Size = New System.Drawing.Size(117, 13)
        Me.lblDiferencialFINAGIL.TabIndex = 51
        Me.lblDiferencialFINAGIL.Text = "Diferencial FINAGIL"
        '
        'cbSustrae
        '
        Me.cbSustrae.FormattingEnabled = True
        Me.cbSustrae.Location = New System.Drawing.Point(620, 127)
        Me.cbSustrae.Name = "cbSustrae"
        Me.cbSustrae.Size = New System.Drawing.Size(59, 21)
        Me.cbSustrae.TabIndex = 52
        '
        'txtDiferencialFINAGIL
        '
        Me.txtDiferencialFINAGIL.Location = New System.Drawing.Point(635, 154)
        Me.txtDiferencialFINAGIL.Name = "txtDiferencialFINAGIL"
        Me.txtDiferencialFINAGIL.Size = New System.Drawing.Size(43, 20)
        Me.txtDiferencialFINAGIL.TabIndex = 53
        Me.txtDiferencialFINAGIL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFinanciamientoActual
        '
        Me.txtFinanciamientoActual.Location = New System.Drawing.Point(190, 160)
        Me.txtFinanciamientoActual.Name = "txtFinanciamientoActual"
        Me.txtFinanciamientoActual.Size = New System.Drawing.Size(100, 20)
        Me.txtFinanciamientoActual.TabIndex = 55
        Me.txtFinanciamientoActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtToneladasHectarea
        '
        Me.txtToneladasHectarea.Location = New System.Drawing.Point(190, 250)
        Me.txtToneladasHectarea.Name = "txtToneladasHectarea"
        Me.txtToneladasHectarea.Size = New System.Drawing.Size(100, 20)
        Me.txtToneladasHectarea.TabIndex = 58
        Me.txtToneladasHectarea.Text = "5.7"
        Me.txtToneladasHectarea.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrecioTonelada
        '
        Me.txtPrecioTonelada.Location = New System.Drawing.Point(190, 220)
        Me.txtPrecioTonelada.Name = "txtPrecioTonelada"
        Me.txtPrecioTonelada.Size = New System.Drawing.Size(100, 20)
        Me.txtPrecioTonelada.TabIndex = 57
        Me.txtPrecioTonelada.Text = "3,400.00"
        Me.txtPrecioTonelada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCostoHectarea
        '
        Me.txtCostoHectarea.Location = New System.Drawing.Point(190, 190)
        Me.txtCostoHectarea.Name = "txtCostoHectarea"
        Me.txtCostoHectarea.Size = New System.Drawing.Size(100, 20)
        Me.txtCostoHectarea.TabIndex = 56
        Me.txtCostoHectarea.Text = "13,000.00"
        Me.txtCostoHectarea.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtHectareasActual
        '
        Me.txtHectareasActual.Location = New System.Drawing.Point(190, 128)
        Me.txtHectareasActual.Name = "txtHectareasActual"
        Me.txtHectareasActual.Size = New System.Drawing.Size(100, 20)
        Me.txtHectareasActual.TabIndex = 54
        Me.txtHectareasActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(32, 252)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(151, 16)
        Me.Label13.TabIndex = 63
        Me.Label13.Text = "Toneladas por Hectárea"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(32, 222)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(151, 16)
        Me.Label12.TabIndex = 62
        Me.Label12.Text = "Precio de Trigo por tonelada"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(32, 192)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(151, 16)
        Me.Label11.TabIndex = 61
        Me.Label11.Text = "Costo por Hectárea"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(32, 162)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(151, 16)
        Me.Label9.TabIndex = 60
        Me.Label9.Text = "Importe a financiar"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(32, 132)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(151, 16)
        Me.Label10.TabIndex = 59
        Me.Label10.Text = "No. de Hectáreas"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmAltaContratos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(729, 375)
        Me.Controls.Add(Me.txtFinanciamientoActual)
        Me.Controls.Add(Me.txtToneladasHectarea)
        Me.Controls.Add(Me.txtPrecioTonelada)
        Me.Controls.Add(Me.txtCostoHectarea)
        Me.Controls.Add(Me.txtHectareasActual)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtDiferencialFINAGIL)
        Me.Controls.Add(Me.cbSustrae)
        Me.Controls.Add(Me.lblDiferencialFINAGIL)
        Me.Controls.Add(Me.cbEstrato)
        Me.Controls.Add(Me.dtpFechaAutorizacion)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.cbProductores)
        Me.Controls.Add(Me.txtLineaAutorizada)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtProductor)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmAltaContratos"
        Me.Text = "Alta de Contratos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtLineaAutorizada As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtProductor As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbProductores As System.Windows.Forms.ComboBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents dtpFechaAutorizacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbEstrato As System.Windows.Forms.ComboBox
    Friend WithEvents lblDiferencialFINAGIL As System.Windows.Forms.Label
    Friend WithEvents cbSustrae As System.Windows.Forms.ComboBox
    Friend WithEvents txtDiferencialFINAGIL As System.Windows.Forms.TextBox
    Friend WithEvents txtFinanciamientoActual As System.Windows.Forms.TextBox
    Friend WithEvents txtToneladasHectarea As System.Windows.Forms.TextBox
    Friend WithEvents txtPrecioTonelada As System.Windows.Forms.TextBox
    Friend WithEvents txtCostoHectarea As System.Windows.Forms.TextBox
    Friend WithEvents txtHectareasActual As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
