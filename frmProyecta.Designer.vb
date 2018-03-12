<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmProyecta
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProyecta))
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.btnProceso = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RBav = New System.Windows.Forms.RadioButton()
        Me.RBcc = New System.Windows.Forms.RadioButton()
        Me.RBPuro = New System.Windows.Forms.RadioButton()
        Me.RbOtros = New System.Windows.Forms.RadioButton()
        Me.rbSimple = New System.Windows.Forms.RadioButton()
        Me.rbRefaccionario = New System.Windows.Forms.RadioButton()
        Me.rbArrendamiento = New System.Windows.Forms.RadioButton()
        Me.rbTotalCartera = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbInteres = New System.Windows.Forms.RadioButton()
        Me.rbCapital = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rbPRSi = New System.Windows.Forms.RadioButton()
        Me.rbPRNo = New System.Windows.Forms.RadioButton()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(15, 41)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(88, 20)
        Me.DateTimePicker1.TabIndex = 22
        '
        'btnProceso
        '
        Me.btnProceso.Location = New System.Drawing.Point(664, 37)
        Me.btnProceso.Name = "btnProceso"
        Me.btnProceso.Size = New System.Drawing.Size(93, 23)
        Me.btnProceso.TabIndex = 23
        Me.btnProceso.Text = "Procesar"
        Me.btnProceso.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(17, 213)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(743, 188)
        Me.DataGridView1.TabIndex = 24
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Fecha de Proceso"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(664, 80)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(93, 23)
        Me.btnSalir.TabIndex = 26
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RBav)
        Me.GroupBox1.Controls.Add(Me.RBcc)
        Me.GroupBox1.Controls.Add(Me.RBPuro)
        Me.GroupBox1.Controls.Add(Me.RbOtros)
        Me.GroupBox1.Controls.Add(Me.rbSimple)
        Me.GroupBox1.Controls.Add(Me.rbRefaccionario)
        Me.GroupBox1.Controls.Add(Me.rbArrendamiento)
        Me.GroupBox1.Controls.Add(Me.rbTotalCartera)
        Me.GroupBox1.Location = New System.Drawing.Point(155, 15)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(262, 187)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Muestra del Reporte"
        '
        'RBav
        '
        Me.RBav.AutoSize = True
        Me.RBav.Location = New System.Drawing.Point(97, 136)
        Me.RBav.Name = "RBav"
        Me.RBav.Size = New System.Drawing.Size(39, 17)
        Me.RBav.TabIndex = 10
        Me.RBav.TabStop = True
        Me.RBav.Text = "AV"
        Me.RBav.UseVisualStyleBackColor = True
        '
        'RBcc
        '
        Me.RBcc.AutoSize = True
        Me.RBcc.Location = New System.Drawing.Point(52, 136)
        Me.RBcc.Name = "RBcc"
        Me.RBcc.Size = New System.Drawing.Size(39, 17)
        Me.RBcc.TabIndex = 9
        Me.RBcc.TabStop = True
        Me.RBcc.Text = "CC"
        Me.RBcc.UseVisualStyleBackColor = True
        '
        'RBPuro
        '
        Me.RBPuro.AutoSize = True
        Me.RBPuro.Location = New System.Drawing.Point(7, 136)
        Me.RBPuro.Name = "RBPuro"
        Me.RBPuro.Size = New System.Drawing.Size(39, 17)
        Me.RBPuro.TabIndex = 8
        Me.RBPuro.TabStop = True
        Me.RBPuro.Text = "AP"
        Me.RBPuro.UseVisualStyleBackColor = True
        '
        'RbOtros
        '
        Me.RbOtros.AutoSize = True
        Me.RbOtros.Location = New System.Drawing.Point(7, 113)
        Me.RbOtros.Name = "RbOtros"
        Me.RbOtros.Size = New System.Drawing.Size(125, 17)
        Me.RbOtros.TabIndex = 7
        Me.RbOtros.TabStop = True
        Me.RbOtros.Text = "Otros (Reestructuras)"
        Me.RbOtros.UseVisualStyleBackColor = True
        '
        'rbSimple
        '
        Me.rbSimple.AutoSize = True
        Me.rbSimple.Location = New System.Drawing.Point(7, 90)
        Me.rbSimple.Name = "rbSimple"
        Me.rbSimple.Size = New System.Drawing.Size(92, 17)
        Me.rbSimple.TabIndex = 6
        Me.rbSimple.TabStop = True
        Me.rbSimple.Text = "Crédito Simple"
        Me.rbSimple.UseVisualStyleBackColor = True
        '
        'rbRefaccionario
        '
        Me.rbRefaccionario.AutoSize = True
        Me.rbRefaccionario.Location = New System.Drawing.Point(7, 67)
        Me.rbRefaccionario.Name = "rbRefaccionario"
        Me.rbRefaccionario.Size = New System.Drawing.Size(127, 17)
        Me.rbRefaccionario.TabIndex = 2
        Me.rbRefaccionario.TabStop = True
        Me.rbRefaccionario.Text = "Crédito Refaccionario"
        Me.rbRefaccionario.UseVisualStyleBackColor = True
        '
        'rbArrendamiento
        '
        Me.rbArrendamiento.AutoSize = True
        Me.rbArrendamiento.Location = New System.Drawing.Point(7, 44)
        Me.rbArrendamiento.Name = "rbArrendamiento"
        Me.rbArrendamiento.Size = New System.Drawing.Size(145, 17)
        Me.rbArrendamiento.TabIndex = 1
        Me.rbArrendamiento.TabStop = True
        Me.rbArrendamiento.Text = "Arrendamiento Financiero"
        Me.rbArrendamiento.UseVisualStyleBackColor = True
        '
        'rbTotalCartera
        '
        Me.rbTotalCartera.AutoSize = True
        Me.rbTotalCartera.Location = New System.Drawing.Point(7, 21)
        Me.rbTotalCartera.Name = "rbTotalCartera"
        Me.rbTotalCartera.Size = New System.Drawing.Size(112, 17)
        Me.rbTotalCartera.TabIndex = 0
        Me.rbTotalCartera.TabStop = True
        Me.rbTotalCartera.Text = "Total de la Cartera"
        Me.rbTotalCartera.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbInteres)
        Me.GroupBox2.Controls.Add(Me.rbCapital)
        Me.GroupBox2.Location = New System.Drawing.Point(453, 17)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(125, 86)
        Me.GroupBox2.TabIndex = 28
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Proyectar"
        '
        'rbInteres
        '
        Me.rbInteres.AutoSize = True
        Me.rbInteres.Location = New System.Drawing.Point(7, 44)
        Me.rbInteres.Name = "rbInteres"
        Me.rbInteres.Size = New System.Drawing.Size(57, 17)
        Me.rbInteres.TabIndex = 1
        Me.rbInteres.TabStop = True
        Me.rbInteres.Text = "Interés"
        Me.rbInteres.UseVisualStyleBackColor = True
        '
        'rbCapital
        '
        Me.rbCapital.AutoSize = True
        Me.rbCapital.Location = New System.Drawing.Point(7, 21)
        Me.rbCapital.Name = "rbCapital"
        Me.rbCapital.Size = New System.Drawing.Size(57, 17)
        Me.rbCapital.TabIndex = 0
        Me.rbCapital.TabStop = True
        Me.rbCapital.Text = "Capital"
        Me.rbCapital.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbPRSi)
        Me.GroupBox3.Controls.Add(Me.rbPRNo)
        Me.GroupBox3.Location = New System.Drawing.Point(453, 115)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(125, 87)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Partes Relacionadas"
        '
        'rbPRSi
        '
        Me.rbPRSi.AutoSize = True
        Me.rbPRSi.Location = New System.Drawing.Point(7, 28)
        Me.rbPRSi.Name = "rbPRSi"
        Me.rbPRSi.Size = New System.Drawing.Size(36, 17)
        Me.rbPRSi.TabIndex = 29
        Me.rbPRSi.TabStop = True
        Me.rbPRSi.Text = "Sí"
        Me.rbPRSi.UseVisualStyleBackColor = True
        '
        'rbPRNo
        '
        Me.rbPRNo.AutoSize = True
        Me.rbPRNo.Location = New System.Drawing.Point(7, 51)
        Me.rbPRNo.Name = "rbPRNo"
        Me.rbPRNo.Size = New System.Drawing.Size(39, 17)
        Me.rbPRNo.TabIndex = 30
        Me.rbPRNo.TabStop = True
        Me.rbPRNo.Text = "No"
        Me.rbPRNo.UseVisualStyleBackColor = True
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(12, 425)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(743, 211)
        Me.DataGridView2.TabIndex = 29
        '
        'frmProyecta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(772, 648)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnProceso)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmProyecta"
        Me.Text = "Proyección de Capital e Interés"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnProceso As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbRefaccionario As System.Windows.Forms.RadioButton
    Friend WithEvents rbArrendamiento As System.Windows.Forms.RadioButton
    Friend WithEvents rbTotalCartera As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbInteres As System.Windows.Forms.RadioButton
    Friend WithEvents rbCapital As System.Windows.Forms.RadioButton
    Friend WithEvents rbSimple As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbPRSi As System.Windows.Forms.RadioButton
    Friend WithEvents rbPRNo As System.Windows.Forms.RadioButton
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents RbOtros As System.Windows.Forms.RadioButton
    Friend WithEvents RBPuro As System.Windows.Forms.RadioButton
    Friend WithEvents RBav As RadioButton
    Friend WithEvents RBcc As RadioButton
End Class
