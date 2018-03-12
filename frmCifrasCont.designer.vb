<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCifrasCont
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCifrasCont))
        Me.txtAvisoi = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.btnProcesa = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtAvisof = New System.Windows.Forms.TextBox
        Me.txtTotalAv = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtRetener = New System.Windows.Forms.TextBox
        Me.txtEnviar = New System.Windows.Forms.TextBox
        Me.txtDev = New System.Windows.Forms.TextBox
        Me.txtNuevas = New System.Windows.Forms.TextBox
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btnExit = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtAvisoi
        '
        Me.txtAvisoi.Location = New System.Drawing.Point(96, 25)
        Me.txtAvisoi.Name = "txtAvisoi"
        Me.txtAvisoi.ReadOnly = True
        Me.txtAvisoi.Size = New System.Drawing.Size(83, 20)
        Me.txtAvisoi.TabIndex = 0
        Me.txtAvisoi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(15, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(113, 16)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Fecha de Proceso"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(135, 13)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(88, 20)
        Me.DateTimePicker1.TabIndex = 21
        '
        'btnProcesa
        '
        Me.btnProcesa.Location = New System.Drawing.Point(247, 9)
        Me.btnProcesa.Name = "btnProcesa"
        Me.btnProcesa.Size = New System.Drawing.Size(74, 24)
        Me.btnProcesa.TabIndex = 23
        Me.btnProcesa.Text = "Procesar"
        Me.btnProcesa.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Aviso Inicial"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Aviso Final"
        '
        'txtAvisof
        '
        Me.txtAvisof.AcceptsReturn = True
        Me.txtAvisof.Location = New System.Drawing.Point(96, 56)
        Me.txtAvisof.Name = "txtAvisof"
        Me.txtAvisof.ReadOnly = True
        Me.txtAvisof.Size = New System.Drawing.Size(83, 20)
        Me.txtAvisof.TabIndex = 3
        Me.txtAvisof.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalAv
        '
        Me.txtTotalAv.Location = New System.Drawing.Point(282, 56)
        Me.txtTotalAv.Name = "txtTotalAv"
        Me.txtTotalAv.ReadOnly = True
        Me.txtTotalAv.Size = New System.Drawing.Size(61, 20)
        Me.txtTotalAv.TabIndex = 4
        Me.txtTotalAv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(196, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Total de Avisos"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(174, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Numero de Avisos que se Retienen"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(19, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(147, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Numero de Avisos por  Enviar"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 33)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Tarjetas Nuevas"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 59)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(109, 13)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Tarjetas por Devolver"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(191, 57)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 13)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "de los Contratos"
        Me.Label9.Visible = False
        '
        'txtRetener
        '
        Me.txtRetener.Location = New System.Drawing.Point(206, 27)
        Me.txtRetener.Name = "txtRetener"
        Me.txtRetener.ReadOnly = True
        Me.txtRetener.Size = New System.Drawing.Size(50, 20)
        Me.txtRetener.TabIndex = 11
        Me.txtRetener.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtEnviar
        '
        Me.txtEnviar.Location = New System.Drawing.Point(206, 53)
        Me.txtEnviar.Name = "txtEnviar"
        Me.txtEnviar.ReadOnly = True
        Me.txtEnviar.Size = New System.Drawing.Size(50, 20)
        Me.txtEnviar.TabIndex = 12
        Me.txtEnviar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDev
        '
        Me.txtDev.Location = New System.Drawing.Point(131, 54)
        Me.txtDev.Name = "txtDev"
        Me.txtDev.ReadOnly = True
        Me.txtDev.Size = New System.Drawing.Size(52, 20)
        Me.txtDev.TabIndex = 13
        Me.txtDev.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNuevas
        '
        Me.txtNuevas.Location = New System.Drawing.Point(131, 26)
        Me.txtNuevas.Name = "txtNuevas"
        Me.txtNuevas.ReadOnly = True
        Me.txtNuevas.Size = New System.Drawing.Size(52, 20)
        Me.txtNuevas.TabIndex = 14
        Me.txtNuevas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ListBox1
        '
        Me.ListBox1.Location = New System.Drawing.Point(278, 57)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(79, 82)
        Me.ListBox1.TabIndex = 15
        Me.ListBox1.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtAvisoi)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtAvisof)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtTotalAv)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 52)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(380, 97)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Avisos"
        Me.GroupBox1.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtRetener)
        Me.GroupBox2.Controls.Add(Me.txtEnviar)
        Me.GroupBox2.Location = New System.Drawing.Point(19, 166)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(379, 85)
        Me.GroupBox2.TabIndex = 26
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Retener"
        Me.GroupBox2.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.ListBox1)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.txtNuevas)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.txtDev)
        Me.GroupBox3.Location = New System.Drawing.Point(23, 269)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(375, 157)
        Me.GroupBox3.TabIndex = 27
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Tarjetas"
        Me.GroupBox3.Visible = False
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(331, 9)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(67, 24)
        Me.btnExit.TabIndex = 28
        Me.btnExit.Text = "Salir"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'frmCifrasCont
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(418, 445)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnProcesa)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCifrasCont"
        Me.Text = "Cifras de Control para envio  de Avisos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtAvisoi As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnProcesa As System.Windows.Forms.Button
    Friend WithEvents txtAvisof As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDev As System.Windows.Forms.TextBox
    Friend WithEvents txtEnviar As System.Windows.Forms.TextBox
    Friend WithEvents txtRetener As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTotalAv As System.Windows.Forms.TextBox
    Friend WithEvents txtNuevas As System.Windows.Forms.TextBox
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
End Class
