<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCapturaPMI
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
        Me.gbPredios = New System.Windows.Forms.GroupBox
        Me.txtPredios = New System.Windows.Forms.TextBox
        Me.gbMuebles = New System.Windows.Forms.GroupBox
        Me.txtMuebles = New System.Windows.Forms.TextBox
        Me.gbInmuebles = New System.Windows.Forms.GroupBox
        Me.txtInmuebles = New System.Windows.Forms.TextBox
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.btnSalir = New System.Windows.Forms.Button
        Me.chkPrendaria = New System.Windows.Forms.CheckBox
        Me.chkHipotecaria = New System.Windows.Forms.CheckBox
        Me.gbDatosFINAGIL = New System.Windows.Forms.GroupBox
        Me.txtHectareas = New System.Windows.Forms.TextBox
        Me.lblHectareas = New System.Windows.Forms.Label
        Me.txtAnexo = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtLineaAutorizada = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtNombreProductor = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.gbPredios.SuspendLayout()
        Me.gbMuebles.SuspendLayout()
        Me.gbInmuebles.SuspendLayout()
        Me.gbDatosFINAGIL.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbPredios
        '
        Me.gbPredios.Controls.Add(Me.txtPredios)
        Me.gbPredios.Location = New System.Drawing.Point(545, 145)
        Me.gbPredios.Name = "gbPredios"
        Me.gbPredios.Size = New System.Drawing.Size(458, 516)
        Me.gbPredios.TabIndex = 0
        Me.gbPredios.TabStop = False
        Me.gbPredios.Text = "Listado de Predios a Habilitar (superficie, medidas y colindancias)"
        '
        'txtPredios
        '
        Me.txtPredios.Location = New System.Drawing.Point(6, 20)
        Me.txtPredios.MaxLength = 82767
        Me.txtPredios.Multiline = True
        Me.txtPredios.Name = "txtPredios"
        Me.txtPredios.Size = New System.Drawing.Size(446, 488)
        Me.txtPredios.TabIndex = 1
        '
        'gbMuebles
        '
        Me.gbMuebles.Controls.Add(Me.txtMuebles)
        Me.gbMuebles.Location = New System.Drawing.Point(16, 144)
        Me.gbMuebles.Name = "gbMuebles"
        Me.gbMuebles.Size = New System.Drawing.Size(508, 228)
        Me.gbMuebles.TabIndex = 0
        Me.gbMuebles.TabStop = False
        Me.gbMuebles.Text = "Relación de Bienes Muebles (en caso de Garantía Prendaria)"
        '
        'txtMuebles
        '
        Me.txtMuebles.Location = New System.Drawing.Point(8, 19)
        Me.txtMuebles.Multiline = True
        Me.txtMuebles.Name = "txtMuebles"
        Me.txtMuebles.Size = New System.Drawing.Size(495, 203)
        Me.txtMuebles.TabIndex = 2
        '
        'gbInmuebles
        '
        Me.gbInmuebles.Controls.Add(Me.txtInmuebles)
        Me.gbInmuebles.Location = New System.Drawing.Point(16, 425)
        Me.gbInmuebles.Name = "gbInmuebles"
        Me.gbInmuebles.Size = New System.Drawing.Size(508, 235)
        Me.gbInmuebles.TabIndex = 0
        Me.gbInmuebles.TabStop = False
        Me.gbInmuebles.Text = "Relación de Bienes Inmuebles (en caso de Garantía Hipotecaria)"
        '
        'txtInmuebles
        '
        Me.txtInmuebles.Location = New System.Drawing.Point(8, 19)
        Me.txtInmuebles.Multiline = True
        Me.txtInmuebles.Name = "txtInmuebles"
        Me.txtInmuebles.Size = New System.Drawing.Size(495, 210)
        Me.txtInmuebles.TabIndex = 3
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(928, 26)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 23)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(928, 68)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 5
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'chkPrendaria
        '
        Me.chkPrendaria.AutoSize = True
        Me.chkPrendaria.Location = New System.Drawing.Point(16, 121)
        Me.chkPrendaria.Name = "chkPrendaria"
        Me.chkPrendaria.Size = New System.Drawing.Size(116, 17)
        Me.chkPrendaria.TabIndex = 77
        Me.chkPrendaria.Text = "Garantía Prendaria"
        Me.chkPrendaria.UseVisualStyleBackColor = True
        '
        'chkHipotecaria
        '
        Me.chkHipotecaria.AutoSize = True
        Me.chkHipotecaria.Location = New System.Drawing.Point(16, 402)
        Me.chkHipotecaria.Name = "chkHipotecaria"
        Me.chkHipotecaria.Size = New System.Drawing.Size(125, 17)
        Me.chkHipotecaria.TabIndex = 78
        Me.chkHipotecaria.Text = "Garantía Hipotecaria"
        Me.chkHipotecaria.UseVisualStyleBackColor = True
        '
        'gbDatosFINAGIL
        '
        Me.gbDatosFINAGIL.Controls.Add(Me.txtHectareas)
        Me.gbDatosFINAGIL.Controls.Add(Me.lblHectareas)
        Me.gbDatosFINAGIL.Controls.Add(Me.txtAnexo)
        Me.gbDatosFINAGIL.Controls.Add(Me.Label6)
        Me.gbDatosFINAGIL.Controls.Add(Me.txtLineaAutorizada)
        Me.gbDatosFINAGIL.Controls.Add(Me.Label16)
        Me.gbDatosFINAGIL.Controls.Add(Me.txtNombreProductor)
        Me.gbDatosFINAGIL.Controls.Add(Me.Label2)
        Me.gbDatosFINAGIL.Location = New System.Drawing.Point(18, 10)
        Me.gbDatosFINAGIL.Name = "gbDatosFINAGIL"
        Me.gbDatosFINAGIL.Size = New System.Drawing.Size(885, 93)
        Me.gbDatosFINAGIL.TabIndex = 79
        Me.gbDatosFINAGIL.TabStop = False
        Me.gbDatosFINAGIL.Text = "Datos del Contrato"
        '
        'txtHectareas
        '
        Me.txtHectareas.Location = New System.Drawing.Point(772, 63)
        Me.txtHectareas.Name = "txtHectareas"
        Me.txtHectareas.ReadOnly = True
        Me.txtHectareas.Size = New System.Drawing.Size(51, 20)
        Me.txtHectareas.TabIndex = 78
        Me.txtHectareas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblHectareas
        '
        Me.lblHectareas.AutoSize = True
        Me.lblHectareas.Location = New System.Drawing.Point(660, 68)
        Me.lblHectareas.Name = "lblHectareas"
        Me.lblHectareas.Size = New System.Drawing.Size(106, 13)
        Me.lblHectareas.TabIndex = 77
        Me.lblHectareas.Text = "Hectáreas a Habilitar"
        '
        'txtAnexo
        '
        Me.txtAnexo.Location = New System.Drawing.Point(182, 64)
        Me.txtAnexo.Name = "txtAnexo"
        Me.txtAnexo.ReadOnly = True
        Me.txtAnexo.Size = New System.Drawing.Size(69, 20)
        Me.txtAnexo.TabIndex = 55
        Me.txtAnexo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.txtLineaAutorizada.Location = New System.Drawing.Point(473, 63)
        Me.txtLineaAutorizada.Name = "txtLineaAutorizada"
        Me.txtLineaAutorizada.ReadOnly = True
        Me.txtLineaAutorizada.Size = New System.Drawing.Size(100, 20)
        Me.txtLineaAutorizada.TabIndex = 53
        Me.txtLineaAutorizada.TabStop = False
        Me.txtLineaAutorizada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(354, 64)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(91, 19)
        Me.Label16.TabIndex = 52
        Me.Label16.Text = "Línea autorizada"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNombreProductor
        '
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
        'frmCapturaPMI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1024, 702)
        Me.Controls.Add(Me.gbDatosFINAGIL)
        Me.Controls.Add(Me.chkHipotecaria)
        Me.Controls.Add(Me.chkPrendaria)
        Me.Controls.Add(Me.gbPredios)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.gbMuebles)
        Me.Controls.Add(Me.gbInmuebles)
        Me.Name = "frmCapturaPMI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Captura de Predios y Garantías del Contrato de Avío"
        Me.gbPredios.ResumeLayout(False)
        Me.gbPredios.PerformLayout()
        Me.gbMuebles.ResumeLayout(False)
        Me.gbMuebles.PerformLayout()
        Me.gbInmuebles.ResumeLayout(False)
        Me.gbInmuebles.PerformLayout()
        Me.gbDatosFINAGIL.ResumeLayout(False)
        Me.gbDatosFINAGIL.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbPredios As System.Windows.Forms.GroupBox
    Friend WithEvents gbMuebles As System.Windows.Forms.GroupBox
    Friend WithEvents gbInmuebles As System.Windows.Forms.GroupBox
    Friend WithEvents txtPredios As System.Windows.Forms.TextBox
    Friend WithEvents txtMuebles As System.Windows.Forms.TextBox
    Friend WithEvents txtInmuebles As System.Windows.Forms.TextBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents chkPrendaria As System.Windows.Forms.CheckBox
    Friend WithEvents chkHipotecaria As System.Windows.Forms.CheckBox
    Friend WithEvents gbDatosFINAGIL As System.Windows.Forms.GroupBox
    Friend WithEvents txtHectareas As System.Windows.Forms.TextBox
    Friend WithEvents lblHectareas As System.Windows.Forms.Label
    Friend WithEvents txtAnexo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtLineaAutorizada As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtNombreProductor As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
