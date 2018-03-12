<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDatosEq
    Inherits System.Windows.Forms.Form
    Public Sub New(ByVal cAnexo As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        txtAnexo.Text = cAnexo
    End Sub

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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtTotalfact = New System.Windows.Forms.TextBox
        Me.txtAnexoIva = New System.Windows.Forms.TextBox
        Me.txtAnexototal = New System.Windows.Forms.TextBox
        Me.txtDetalle = New System.Windows.Forms.RichTextBox
        Me.btnIgnorar = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtModelo = New System.Windows.Forms.TextBox
        Me.txtMotor = New System.Windows.Forms.TextBox
        Me.txtSerie = New System.Windows.Forms.TextBox
        Me.txtProveedor = New System.Windows.Forms.TextBox
        Me.txtFactura = New System.Windows.Forms.TextBox
        Me.btnSalir = New System.Windows.Forms.Button
        Me.txtImpant = New System.Windows.Forms.TextBox
        Me.txtAnexo = New System.Windows.Forms.TextBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.txtTotalfact)
        Me.Panel1.Controls.Add(Me.txtAnexoIva)
        Me.Panel1.Controls.Add(Me.txtAnexototal)
        Me.Panel1.Controls.Add(Me.txtDetalle)
        Me.Panel1.Controls.Add(Me.btnIgnorar)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtModelo)
        Me.Panel1.Controls.Add(Me.txtMotor)
        Me.Panel1.Controls.Add(Me.txtSerie)
        Me.Panel1.Controls.Add(Me.txtProveedor)
        Me.Panel1.Controls.Add(Me.txtFactura)
        Me.Panel1.Location = New System.Drawing.Point(16, 256)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(696, 224)
        Me.Panel1.TabIndex = 16
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(471, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(98, 23)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Importe capturado"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(256, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 23)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "I.V.A."
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(17, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 23)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Importe del Equipo"
        '
        'txtTotalfact
        '
        Me.txtTotalfact.Location = New System.Drawing.Point(572, 15)
        Me.txtTotalfact.Name = "txtTotalfact"
        Me.txtTotalfact.ReadOnly = True
        Me.txtTotalfact.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalfact.TabIndex = 18
        Me.txtTotalfact.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAnexoIva
        '
        Me.txtAnexoIva.Location = New System.Drawing.Point(299, 15)
        Me.txtAnexoIva.Name = "txtAnexoIva"
        Me.txtAnexoIva.ReadOnly = True
        Me.txtAnexoIva.Size = New System.Drawing.Size(100, 20)
        Me.txtAnexoIva.TabIndex = 17
        Me.txtAnexoIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAnexototal
        '
        Me.txtAnexototal.Location = New System.Drawing.Point(136, 15)
        Me.txtAnexototal.Name = "txtAnexototal"
        Me.txtAnexototal.ReadOnly = True
        Me.txtAnexototal.Size = New System.Drawing.Size(100, 20)
        Me.txtAnexototal.TabIndex = 16
        Me.txtAnexototal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDetalle
        '
        Me.txtDetalle.Location = New System.Drawing.Point(136, 120)
        Me.txtDetalle.Name = "txtDetalle"
        Me.txtDetalle.ReadOnly = True
        Me.txtDetalle.Size = New System.Drawing.Size(536, 88)
        Me.txtDetalle.TabIndex = 6
        Me.txtDetalle.TabStop = False
        Me.txtDetalle.Text = ""
        '
        'btnIgnorar
        '
        Me.btnIgnorar.Location = New System.Drawing.Point(24, 184)
        Me.btnIgnorar.Name = "btnIgnorar"
        Me.btnIgnorar.Size = New System.Drawing.Size(75, 23)
        Me.btnIgnorar.TabIndex = 15
        Me.btnIgnorar.Text = "Regresar"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(16, 112)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 20)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Descripción del Bien"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(512, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 20)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Modelo"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(264, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 20)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "No. de Motor"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "No. de Serie"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Proveedor"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Factura No."
        '
        'txtModelo
        '
        Me.txtModelo.Location = New System.Drawing.Point(584, 88)
        Me.txtModelo.MaxLength = 4
        Me.txtModelo.Name = "txtModelo"
        Me.txtModelo.ReadOnly = True
        Me.txtModelo.Size = New System.Drawing.Size(88, 20)
        Me.txtModelo.TabIndex = 5
        '
        'txtMotor
        '
        Me.txtMotor.Location = New System.Drawing.Point(352, 88)
        Me.txtMotor.Name = "txtMotor"
        Me.txtMotor.ReadOnly = True
        Me.txtMotor.Size = New System.Drawing.Size(128, 20)
        Me.txtMotor.TabIndex = 4
        '
        'txtSerie
        '
        Me.txtSerie.Location = New System.Drawing.Point(136, 88)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.ReadOnly = True
        Me.txtSerie.Size = New System.Drawing.Size(100, 20)
        Me.txtSerie.TabIndex = 3
        '
        'txtProveedor
        '
        Me.txtProveedor.Location = New System.Drawing.Point(136, 64)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.ReadOnly = True
        Me.txtProveedor.Size = New System.Drawing.Size(536, 20)
        Me.txtProveedor.TabIndex = 2
        '
        'txtFactura
        '
        Me.txtFactura.Location = New System.Drawing.Point(136, 40)
        Me.txtFactura.Name = "txtFactura"
        Me.txtFactura.ReadOnly = True
        Me.txtFactura.Size = New System.Drawing.Size(100, 20)
        Me.txtFactura.TabIndex = 0
        Me.txtFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(578, 25)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(136, 23)
        Me.btnSalir.TabIndex = 17
        Me.btnSalir.Text = "Salir"
        '
        'txtImpant
        '
        Me.txtImpant.Location = New System.Drawing.Point(443, 226)
        Me.txtImpant.Name = "txtImpant"
        Me.txtImpant.Size = New System.Drawing.Size(8, 20)
        Me.txtImpant.TabIndex = 19
        Me.txtImpant.Visible = False
        '
        'txtAnexo
        '
        Me.txtAnexo.Location = New System.Drawing.Point(415, 226)
        Me.txtAnexo.Name = "txtAnexo"
        Me.txtAnexo.Size = New System.Drawing.Size(8, 20)
        Me.txtAnexo.TabIndex = 18
        Me.txtAnexo.Visible = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.HotTrack
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4})
        Me.DataGridView1.GridColor = System.Drawing.SystemColors.Highlight
        Me.DataGridView1.Location = New System.Drawing.Point(16, 24)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 61
        Me.DataGridView1.Size = New System.Drawing.Size(545, 184)
        Me.DataGridView1.TabIndex = 20
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "Factura"
        Me.Column1.FillWeight = 58.40519!
        Me.Column1.HeaderText = "Factura"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "Proveedor"
        Me.Column2.FillWeight = 233.5025!
        Me.Column2.HeaderText = "Nombre del Proveedor"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "Importe"
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle8
        Me.Column3.FillWeight = 63.01928!
        Me.Column3.HeaderText = "Importe"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "Activo"
        Me.Column4.FillWeight = 45.07299!
        Me.Column4.HeaderText = "F.Activo"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'frmDatosEq
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(728, 510)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.txtImpant)
        Me.Controls.Add(Me.txtAnexo)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmDatosEq"
        Me.Text = "Consulta de datos del Equipo"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTotalfact As System.Windows.Forms.TextBox
    Friend WithEvents txtAnexoIva As System.Windows.Forms.TextBox
    Friend WithEvents txtAnexototal As System.Windows.Forms.TextBox
    Friend WithEvents txtDetalle As System.Windows.Forms.RichTextBox
    Friend WithEvents btnIgnorar As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtModelo As System.Windows.Forms.TextBox
    Friend WithEvents txtMotor As System.Windows.Forms.TextBox
    Friend WithEvents txtSerie As System.Windows.Forms.TextBox
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents txtFactura As System.Windows.Forms.TextBox
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents txtImpant As System.Windows.Forms.TextBox
    Friend WithEvents txtAnexo As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
