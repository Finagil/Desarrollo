Option Explicit On 

Imports System.Data.SqlClient

Public Class frmModiGene

    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal cCliente As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        txtPassword.Text = cCliente

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblPass As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents lblMail As System.Windows.Forms.Label
    Friend WithEvents lblFax As System.Windows.Forms.Label
    Friend WithEvents txtFax As System.Windows.Forms.TextBox
    Friend WithEvents lblTelef As System.Windows.Forms.Label
    Friend WithEvents txtTelef1 As System.Windows.Forms.TextBox
    Friend WithEvents txtTelef2 As System.Windows.Forms.TextBox
    Friend WithEvents txtTelef3 As System.Windows.Forms.TextBox
    Friend WithEvents lblDeleg As System.Windows.Forms.Label
    Friend WithEvents txtDelegacion As System.Windows.Forms.TextBox
    Friend WithEvents lblPostal As System.Windows.Forms.Label
    Friend WithEvents txtEstado As System.Windows.Forms.TextBox
    Friend WithEvents lblColonia As System.Windows.Forms.Label
    Friend WithEvents lblCalle As System.Windows.Forms.Label
    Friend WithEvents txtCalle As System.Windows.Forms.TextBox
    Friend WithEvents txtDescTipo As System.Windows.Forms.TextBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents txtDescr As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents btnActualizar As System.Windows.Forms.Button
    Friend WithEvents rbCoacF As System.Windows.Forms.RadioButton
    Friend WithEvents rbCoacM As System.Windows.Forms.RadioButton
    Friend WithEvents chkObli As System.Windows.Forms.CheckBox
    Friend WithEvents chkAval1 As System.Windows.Forms.CheckBox
    Friend WithEvents chkAval2 As System.Windows.Forms.CheckBox
    Friend WithEvents rbObliM As System.Windows.Forms.RadioButton
    Friend WithEvents rbObliF As System.Windows.Forms.RadioButton
    Friend WithEvents rbAval1M As System.Windows.Forms.RadioButton
    Friend WithEvents rbAval1F As System.Windows.Forms.RadioButton
    Friend WithEvents rbAval2M As System.Windows.Forms.RadioButton
    Friend WithEvents rbAval2F As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents txtMail2 As System.Windows.Forms.TextBox
    Friend WithEvents lblMail2 As System.Windows.Forms.Label
    Friend WithEvents txtMail1 As System.Windows.Forms.TextBox
    Friend WithEvents lblGiro As System.Windows.Forms.Label
    Friend WithEvents cbGiros As System.Windows.Forms.ComboBox
    Friend WithEvents cbPromotores As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtRfc As System.Windows.Forms.TextBox
    Friend WithEvents lblFecha1 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents mtxtColonia As System.Windows.Forms.MaskedTextBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents chkCoac As System.Windows.Forms.CheckBox
    Friend WithEvents txtCopos As System.Windows.Forms.TextBox
    Friend WithEvents lblCopos As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents mtxtCURP As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbFormapag1 As System.Windows.Forms.ComboBox
    Friend WithEvents mtxtCuenta1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cbFormapag4 As System.Windows.Forms.ComboBox
    Friend WithEvents cbFormapag3 As System.Windows.Forms.ComboBox
    Friend WithEvents cbFormapag2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents mtxtCuenta4 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mtxtCuenta3 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mtxtCuenta2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha1 As System.Windows.Forms.DateTimePicker
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cbFormapag4 = New System.Windows.Forms.ComboBox
        Me.cbFormapag3 = New System.Windows.Forms.ComboBox
        Me.cbFormapag2 = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.mtxtCuenta4 = New System.Windows.Forms.MaskedTextBox
        Me.mtxtCuenta3 = New System.Windows.Forms.MaskedTextBox
        Me.mtxtCuenta2 = New System.Windows.Forms.MaskedTextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.mtxtCuenta1 = New System.Windows.Forms.MaskedTextBox
        Me.cbFormapag1 = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblCopos = New System.Windows.Forms.Label
        Me.txtCopos = New System.Windows.Forms.TextBox
        Me.mtxtColonia = New System.Windows.Forms.MaskedTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblGiro = New System.Windows.Forms.Label
        Me.cbGiros = New System.Windows.Forms.ComboBox
        Me.cbPromotores = New System.Windows.Forms.ComboBox
        Me.txtMail2 = New System.Windows.Forms.TextBox
        Me.lblMail2 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblMail = New System.Windows.Forms.Label
        Me.txtMail1 = New System.Windows.Forms.TextBox
        Me.lblFax = New System.Windows.Forms.Label
        Me.txtFax = New System.Windows.Forms.TextBox
        Me.lblTelef = New System.Windows.Forms.Label
        Me.txtTelef1 = New System.Windows.Forms.TextBox
        Me.txtTelef2 = New System.Windows.Forms.TextBox
        Me.txtTelef3 = New System.Windows.Forms.TextBox
        Me.lblDeleg = New System.Windows.Forms.Label
        Me.txtDelegacion = New System.Windows.Forms.TextBox
        Me.lblPostal = New System.Windows.Forms.Label
        Me.txtEstado = New System.Windows.Forms.TextBox
        Me.lblColonia = New System.Windows.Forms.Label
        Me.lblCalle = New System.Windows.Forms.Label
        Me.txtCalle = New System.Windows.Forms.TextBox
        Me.lblPass = New System.Windows.Forms.Label
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.txtDescTipo = New System.Windows.Forms.TextBox
        Me.lblTipo = New System.Windows.Forms.Label
        Me.txtDescr = New System.Windows.Forms.TextBox
        Me.lblName = New System.Windows.Forms.Label
        Me.btnActualizar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.rbCoacF = New System.Windows.Forms.RadioButton
        Me.rbCoacM = New System.Windows.Forms.RadioButton
        Me.chkObli = New System.Windows.Forms.CheckBox
        Me.chkAval1 = New System.Windows.Forms.CheckBox
        Me.chkAval2 = New System.Windows.Forms.CheckBox
        Me.rbObliM = New System.Windows.Forms.RadioButton
        Me.rbObliF = New System.Windows.Forms.RadioButton
        Me.rbAval1M = New System.Windows.Forms.RadioButton
        Me.rbAval1F = New System.Windows.Forms.RadioButton
        Me.rbAval2M = New System.Windows.Forms.RadioButton
        Me.rbAval2F = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.chkCoac = New System.Windows.Forms.CheckBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtRfc = New System.Windows.Forms.TextBox
        Me.lblFecha1 = New System.Windows.Forms.Label
        Me.dtpFecha1 = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.mtxtCURP = New System.Windows.Forms.MaskedTextBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbFormapag4)
        Me.GroupBox1.Controls.Add(Me.cbFormapag3)
        Me.GroupBox1.Controls.Add(Me.cbFormapag2)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.mtxtCuenta4)
        Me.GroupBox1.Controls.Add(Me.mtxtCuenta3)
        Me.GroupBox1.Controls.Add(Me.mtxtCuenta2)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.mtxtCuenta1)
        Me.GroupBox1.Controls.Add(Me.cbFormapag1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lblCopos)
        Me.GroupBox1.Controls.Add(Me.txtCopos)
        Me.GroupBox1.Controls.Add(Me.mtxtColonia)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblGiro)
        Me.GroupBox1.Controls.Add(Me.cbGiros)
        Me.GroupBox1.Controls.Add(Me.cbPromotores)
        Me.GroupBox1.Controls.Add(Me.txtMail2)
        Me.GroupBox1.Controls.Add(Me.lblMail2)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lblMail)
        Me.GroupBox1.Controls.Add(Me.txtMail1)
        Me.GroupBox1.Controls.Add(Me.lblFax)
        Me.GroupBox1.Controls.Add(Me.txtFax)
        Me.GroupBox1.Controls.Add(Me.lblTelef)
        Me.GroupBox1.Controls.Add(Me.txtTelef1)
        Me.GroupBox1.Controls.Add(Me.txtTelef2)
        Me.GroupBox1.Controls.Add(Me.txtTelef3)
        Me.GroupBox1.Controls.Add(Me.lblDeleg)
        Me.GroupBox1.Controls.Add(Me.txtDelegacion)
        Me.GroupBox1.Controls.Add(Me.lblPostal)
        Me.GroupBox1.Controls.Add(Me.txtEstado)
        Me.GroupBox1.Controls.Add(Me.lblColonia)
        Me.GroupBox1.Controls.Add(Me.lblCalle)
        Me.GroupBox1.Controls.Add(Me.txtCalle)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 124)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(592, 391)
        Me.GroupBox1.TabIndex = 35
        Me.GroupBox1.TabStop = False
        '
        'cbFormapag4
        '
        Me.cbFormapag4.FormattingEnabled = True
        Me.cbFormapag4.Items.AddRange(New Object() {"TRANSFERENCIA", "TARJETA", "EFECTIVO", "CHEQUE"})
        Me.cbFormapag4.Location = New System.Drawing.Point(389, 364)
        Me.cbFormapag4.Name = "cbFormapag4"
        Me.cbFormapag4.Size = New System.Drawing.Size(121, 21)
        Me.cbFormapag4.TabIndex = 55
        '
        'cbFormapag3
        '
        Me.cbFormapag3.FormattingEnabled = True
        Me.cbFormapag3.Items.AddRange(New Object() {"TRANSFERENCIA", "TARJETA", "EFECTIVO", "CHEQUE"})
        Me.cbFormapag3.Location = New System.Drawing.Point(389, 338)
        Me.cbFormapag3.Name = "cbFormapag3"
        Me.cbFormapag3.Size = New System.Drawing.Size(121, 21)
        Me.cbFormapag3.TabIndex = 54
        '
        'cbFormapag2
        '
        Me.cbFormapag2.FormattingEnabled = True
        Me.cbFormapag2.Items.AddRange(New Object() {"TRANSFERENCIA", "TARJETA", "EFECTIVO", "CHEQUE"})
        Me.cbFormapag2.Location = New System.Drawing.Point(389, 312)
        Me.cbFormapag2.Name = "cbFormapag2"
        Me.cbFormapag2.Size = New System.Drawing.Size(121, 21)
        Me.cbFormapag2.TabIndex = 53
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(294, 362)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(89, 16)
        Me.Label12.TabIndex = 52
        Me.Label12.Text = "Forma de Pago4"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(294, 340)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(89, 16)
        Me.Label11.TabIndex = 51
        Me.Label11.Text = "Forma de Pago3"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(294, 314)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(89, 16)
        Me.Label10.TabIndex = 50
        Me.Label10.Text = "Forma de Pago2"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mtxtCuenta4
        '
        Me.mtxtCuenta4.BeepOnError = True
        Me.mtxtCuenta4.Location = New System.Drawing.Point(199, 362)
        Me.mtxtCuenta4.Name = "mtxtCuenta4"
        Me.mtxtCuenta4.Size = New System.Drawing.Size(31, 20)
        Me.mtxtCuenta4.TabIndex = 49
        '
        'mtxtCuenta3
        '
        Me.mtxtCuenta3.BeepOnError = True
        Me.mtxtCuenta3.Location = New System.Drawing.Point(199, 336)
        Me.mtxtCuenta3.Name = "mtxtCuenta3"
        Me.mtxtCuenta3.Size = New System.Drawing.Size(31, 20)
        Me.mtxtCuenta3.TabIndex = 48
        '
        'mtxtCuenta2
        '
        Me.mtxtCuenta2.BeepOnError = True
        Me.mtxtCuenta2.Location = New System.Drawing.Point(199, 310)
        Me.mtxtCuenta2.Name = "mtxtCuenta2"
        Me.mtxtCuenta2.Size = New System.Drawing.Size(31, 20)
        Me.mtxtCuenta2.TabIndex = 47
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(6, 360)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(187, 20)
        Me.Label9.TabIndex = 46
        Me.Label9.Text = "Ulyimos 4 Digitos Cuenta de Pago4"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(5, 336)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(188, 20)
        Me.Label7.TabIndex = 45
        Me.Label7.Text = "Ultimos 4 Digitos Cuenta de Pago3"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(6, 312)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(187, 20)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "Ultimos 4 Digitos Cuenta de Pago2"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mtxtCuenta1
        '
        Me.mtxtCuenta1.BeepOnError = True
        Me.mtxtCuenta1.Location = New System.Drawing.Point(199, 287)
        Me.mtxtCuenta1.Name = "mtxtCuenta1"
        Me.mtxtCuenta1.Size = New System.Drawing.Size(31, 20)
        Me.mtxtCuenta1.TabIndex = 43
        '
        'cbFormapag1
        '
        Me.cbFormapag1.FormattingEnabled = True
        Me.cbFormapag1.Items.AddRange(New Object() {"TRANSFERENCIA", "TARJETA", "EFECTIVO", "CHEQUE"})
        Me.cbFormapag1.Location = New System.Drawing.Point(389, 286)
        Me.cbFormapag1.Name = "cbFormapag1"
        Me.cbFormapag1.Size = New System.Drawing.Size(121, 21)
        Me.cbFormapag1.TabIndex = 42
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(294, 291)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 16)
        Me.Label5.TabIndex = 41
        Me.Label5.Text = "Forma de Pago1"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(6, 287)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(187, 20)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "Ultimos 4 Digitos Cuenta de Pago1"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCopos
        '
        Me.lblCopos.AutoSize = True
        Me.lblCopos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCopos.ForeColor = System.Drawing.Color.Red
        Me.lblCopos.Location = New System.Drawing.Point(219, 48)
        Me.lblCopos.Name = "lblCopos"
        Me.lblCopos.Size = New System.Drawing.Size(0, 13)
        Me.lblCopos.TabIndex = 37
        Me.lblCopos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCopos
        '
        Me.txtCopos.Location = New System.Drawing.Point(144, 44)
        Me.txtCopos.MaxLength = 5
        Me.txtCopos.Name = "txtCopos"
        Me.txtCopos.Size = New System.Drawing.Size(71, 20)
        Me.txtCopos.TabIndex = 3
        '
        'mtxtColonia
        '
        Me.mtxtColonia.BeepOnError = True
        Me.mtxtColonia.Location = New System.Drawing.Point(144, 116)
        Me.mtxtColonia.Name = "mtxtColonia"
        Me.mtxtColonia.Size = New System.Drawing.Size(342, 20)
        Me.mtxtColonia.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(134, 16)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Estado"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGiro
        '
        Me.lblGiro.Location = New System.Drawing.Point(6, 190)
        Me.lblGiro.Name = "lblGiro"
        Me.lblGiro.Size = New System.Drawing.Size(134, 16)
        Me.lblGiro.TabIndex = 32
        Me.lblGiro.Text = "Giro del Negocio"
        Me.lblGiro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbGiros
        '
        Me.cbGiros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbGiros.Location = New System.Drawing.Point(144, 188)
        Me.cbGiros.Name = "cbGiros"
        Me.cbGiros.Size = New System.Drawing.Size(368, 21)
        Me.cbGiros.TabIndex = 9
        '
        'cbPromotores
        '
        Me.cbPromotores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPromotores.Location = New System.Drawing.Point(144, 260)
        Me.cbPromotores.Name = "cbPromotores"
        Me.cbPromotores.Size = New System.Drawing.Size(368, 21)
        Me.cbPromotores.TabIndex = 12
        '
        'txtMail2
        '
        Me.txtMail2.Location = New System.Drawing.Point(144, 236)
        Me.txtMail2.Name = "txtMail2"
        Me.txtMail2.Size = New System.Drawing.Size(368, 20)
        Me.txtMail2.TabIndex = 11
        '
        'lblMail2
        '
        Me.lblMail2.Location = New System.Drawing.Point(6, 238)
        Me.lblMail2.Name = "lblMail2"
        Me.lblMail2.Size = New System.Drawing.Size(134, 16)
        Me.lblMail2.TabIndex = 30
        Me.lblMail2.Text = "EMail Secundario"
        Me.lblMail2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(6, 262)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(134, 16)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Ejecutivo que lo atiende"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMail
        '
        Me.lblMail.Location = New System.Drawing.Point(6, 214)
        Me.lblMail.Name = "lblMail"
        Me.lblMail.Size = New System.Drawing.Size(134, 16)
        Me.lblMail.TabIndex = 24
        Me.lblMail.Text = "EMail Principal"
        Me.lblMail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMail1
        '
        Me.txtMail1.Location = New System.Drawing.Point(144, 212)
        Me.txtMail1.Name = "txtMail1"
        Me.txtMail1.Size = New System.Drawing.Size(368, 20)
        Me.txtMail1.TabIndex = 10
        '
        'lblFax
        '
        Me.lblFax.Location = New System.Drawing.Point(6, 166)
        Me.lblFax.Name = "lblFax"
        Me.lblFax.Size = New System.Drawing.Size(134, 16)
        Me.lblFax.TabIndex = 10
        Me.lblFax.Text = "Fax"
        Me.lblFax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFax
        '
        Me.txtFax.Location = New System.Drawing.Point(144, 164)
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Size = New System.Drawing.Size(104, 20)
        Me.txtFax.TabIndex = 8
        '
        'lblTelef
        '
        Me.lblTelef.Location = New System.Drawing.Point(6, 142)
        Me.lblTelef.Name = "lblTelef"
        Me.lblTelef.Size = New System.Drawing.Size(134, 16)
        Me.lblTelef.TabIndex = 8
        Me.lblTelef.Text = "Teléfonos"
        Me.lblTelef.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTelef1
        '
        Me.txtTelef1.Location = New System.Drawing.Point(144, 140)
        Me.txtTelef1.Name = "txtTelef1"
        Me.txtTelef1.Size = New System.Drawing.Size(104, 20)
        Me.txtTelef1.TabIndex = 5
        '
        'txtTelef2
        '
        Me.txtTelef2.Location = New System.Drawing.Point(249, 140)
        Me.txtTelef2.Name = "txtTelef2"
        Me.txtTelef2.Size = New System.Drawing.Size(104, 20)
        Me.txtTelef2.TabIndex = 6
        '
        'txtTelef3
        '
        Me.txtTelef3.Location = New System.Drawing.Point(353, 140)
        Me.txtTelef3.Name = "txtTelef3"
        Me.txtTelef3.Size = New System.Drawing.Size(104, 20)
        Me.txtTelef3.TabIndex = 7
        '
        'lblDeleg
        '
        Me.lblDeleg.Location = New System.Drawing.Point(6, 94)
        Me.lblDeleg.Name = "lblDeleg"
        Me.lblDeleg.Size = New System.Drawing.Size(134, 16)
        Me.lblDeleg.TabIndex = 7
        Me.lblDeleg.Text = "Delegación o Municipio"
        Me.lblDeleg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDelegacion
        '
        Me.txtDelegacion.Location = New System.Drawing.Point(144, 92)
        Me.txtDelegacion.MaxLength = 45
        Me.txtDelegacion.Name = "txtDelegacion"
        Me.txtDelegacion.ReadOnly = True
        Me.txtDelegacion.Size = New System.Drawing.Size(342, 20)
        Me.txtDelegacion.TabIndex = 4
        Me.txtDelegacion.TabStop = False
        '
        'lblPostal
        '
        Me.lblPostal.Location = New System.Drawing.Point(6, 46)
        Me.lblPostal.Name = "lblPostal"
        Me.lblPostal.Size = New System.Drawing.Size(134, 16)
        Me.lblPostal.TabIndex = 5
        Me.lblPostal.Text = "Código Postal"
        Me.lblPostal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEstado
        '
        Me.txtEstado.AcceptsReturn = True
        Me.txtEstado.Location = New System.Drawing.Point(144, 68)
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.ReadOnly = True
        Me.txtEstado.Size = New System.Drawing.Size(342, 20)
        Me.txtEstado.TabIndex = 3
        Me.txtEstado.TabStop = False
        '
        'lblColonia
        '
        Me.lblColonia.Location = New System.Drawing.Point(6, 118)
        Me.lblColonia.Name = "lblColonia"
        Me.lblColonia.Size = New System.Drawing.Size(134, 16)
        Me.lblColonia.TabIndex = 4
        Me.lblColonia.Text = "Colonia (solo el nombre)"
        Me.lblColonia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCalle
        '
        Me.lblCalle.Location = New System.Drawing.Point(6, 22)
        Me.lblCalle.Name = "lblCalle"
        Me.lblCalle.Size = New System.Drawing.Size(64, 16)
        Me.lblCalle.TabIndex = 3
        Me.lblCalle.Text = "Calle"
        Me.lblCalle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCalle
        '
        Me.txtCalle.Location = New System.Drawing.Point(80, 20)
        Me.txtCalle.MaxLength = 45
        Me.txtCalle.Name = "txtCalle"
        Me.txtCalle.Size = New System.Drawing.Size(504, 20)
        Me.txtCalle.TabIndex = 2
        '
        'lblPass
        '
        Me.lblPass.Location = New System.Drawing.Point(16, 60)
        Me.lblPass.Name = "lblPass"
        Me.lblPass.Size = New System.Drawing.Size(72, 16)
        Me.lblPass.TabIndex = 23
        Me.lblPass.Text = "Contraseña"
        Me.lblPass.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(88, 56)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.ReadOnly = True
        Me.txtPassword.Size = New System.Drawing.Size(41, 20)
        Me.txtPassword.TabIndex = 22
        Me.txtPassword.TabStop = False
        '
        'txtDescTipo
        '
        Me.txtDescTipo.Location = New System.Drawing.Point(88, 32)
        Me.txtDescTipo.Name = "txtDescTipo"
        Me.txtDescTipo.ReadOnly = True
        Me.txtDescTipo.Size = New System.Drawing.Size(504, 20)
        Me.txtDescTipo.TabIndex = 34
        Me.txtDescTipo.TabStop = False
        '
        'lblTipo
        '
        Me.lblTipo.Location = New System.Drawing.Point(16, 36)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(56, 16)
        Me.lblTipo.TabIndex = 33
        Me.lblTipo.Text = "Tipo"
        Me.lblTipo.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txtDescr
        '
        Me.txtDescr.Location = New System.Drawing.Point(88, 8)
        Me.txtDescr.Name = "txtDescr"
        Me.txtDescr.ReadOnly = True
        Me.txtDescr.Size = New System.Drawing.Size(504, 20)
        Me.txtDescr.TabIndex = 32
        Me.txtDescr.TabStop = False
        '
        'lblName
        '
        Me.lblName.Location = New System.Drawing.Point(16, 12)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(56, 16)
        Me.lblName.TabIndex = 31
        Me.lblName.Text = "Nombre"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'btnActualizar
        '
        Me.btnActualizar.Location = New System.Drawing.Point(176, 683)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(96, 32)
        Me.btnActualizar.TabIndex = 18
        Me.btnActualizar.Text = "Actualizar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(336, 682)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(96, 32)
        Me.btnCancelar.TabIndex = 19
        Me.btnCancelar.Text = "Cancelar"
        '
        'rbCoacF
        '
        Me.rbCoacF.Location = New System.Drawing.Point(13, 42)
        Me.rbCoacF.Name = "rbCoacF"
        Me.rbCoacF.Size = New System.Drawing.Size(112, 16)
        Me.rbCoacF.TabIndex = 38
        Me.rbCoacF.Text = "Persona Física"
        '
        'rbCoacM
        '
        Me.rbCoacM.Location = New System.Drawing.Point(136, 42)
        Me.rbCoacM.Name = "rbCoacM"
        Me.rbCoacM.Size = New System.Drawing.Size(112, 16)
        Me.rbCoacM.TabIndex = 39
        Me.rbCoacM.Text = "Persona Moral"
        '
        'chkObli
        '
        Me.chkObli.Location = New System.Drawing.Point(16, 14)
        Me.chkObli.Name = "chkObli"
        Me.chkObli.Size = New System.Drawing.Size(120, 22)
        Me.chkObli.TabIndex = 15
        Me.chkObli.Text = "Segundo Aval"
        '
        'chkAval1
        '
        Me.chkAval1.Location = New System.Drawing.Point(11, 16)
        Me.chkAval1.Name = "chkAval1"
        Me.chkAval1.Size = New System.Drawing.Size(120, 16)
        Me.chkAval1.TabIndex = 16
        Me.chkAval1.Text = "Tercer Aval"
        '
        'chkAval2
        '
        Me.chkAval2.Location = New System.Drawing.Point(16, 16)
        Me.chkAval2.Name = "chkAval2"
        Me.chkAval2.Size = New System.Drawing.Size(120, 16)
        Me.chkAval2.TabIndex = 17
        Me.chkAval2.Text = "Cuarto Aval"
        '
        'rbObliM
        '
        Me.rbObliM.Location = New System.Drawing.Point(144, 38)
        Me.rbObliM.Name = "rbObliM"
        Me.rbObliM.Size = New System.Drawing.Size(112, 16)
        Me.rbObliM.TabIndex = 45
        Me.rbObliM.Text = "Persona Moral"
        '
        'rbObliF
        '
        Me.rbObliF.Location = New System.Drawing.Point(16, 38)
        Me.rbObliF.Name = "rbObliF"
        Me.rbObliF.Size = New System.Drawing.Size(112, 16)
        Me.rbObliF.TabIndex = 44
        Me.rbObliF.Text = "Persona Física"
        '
        'rbAval1M
        '
        Me.rbAval1M.Location = New System.Drawing.Point(140, 39)
        Me.rbAval1M.Name = "rbAval1M"
        Me.rbAval1M.Size = New System.Drawing.Size(112, 16)
        Me.rbAval1M.TabIndex = 47
        Me.rbAval1M.Text = "Persona Moral"
        '
        'rbAval1F
        '
        Me.rbAval1F.Location = New System.Drawing.Point(12, 39)
        Me.rbAval1F.Name = "rbAval1F"
        Me.rbAval1F.Size = New System.Drawing.Size(112, 16)
        Me.rbAval1F.TabIndex = 46
        Me.rbAval1F.Text = "Persona Física"
        '
        'rbAval2M
        '
        Me.rbAval2M.Location = New System.Drawing.Point(144, 40)
        Me.rbAval2M.Name = "rbAval2M"
        Me.rbAval2M.Size = New System.Drawing.Size(112, 16)
        Me.rbAval2M.TabIndex = 49
        Me.rbAval2M.Text = "Persona Moral"
        '
        'rbAval2F
        '
        Me.rbAval2F.Location = New System.Drawing.Point(16, 40)
        Me.rbAval2F.Name = "rbAval2F"
        Me.rbAval2F.Size = New System.Drawing.Size(112, 16)
        Me.rbAval2F.TabIndex = 48
        Me.rbAval2F.Text = "Persona Física"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkCoac)
        Me.GroupBox2.Controls.Add(Me.CheckBox1)
        Me.GroupBox2.Controls.Add(Me.rbCoacF)
        Me.GroupBox2.Controls.Add(Me.rbCoacM)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 519)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(264, 72)
        Me.GroupBox2.TabIndex = 50
        Me.GroupBox2.TabStop = False
        '
        'chkCoac
        '
        Me.chkCoac.Location = New System.Drawing.Point(13, 17)
        Me.chkCoac.Name = "chkCoac"
        Me.chkCoac.Size = New System.Drawing.Size(108, 19)
        Me.chkCoac.TabIndex = 13
        Me.chkCoac.Text = "Coacreditado"
        '
        'CheckBox1
        '
        Me.CheckBox1.Location = New System.Drawing.Point(137, 18)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(106, 19)
        Me.CheckBox1.TabIndex = 14
        Me.CheckBox1.Text = "Primer Aval"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkObli)
        Me.GroupBox3.Controls.Add(Me.rbObliM)
        Me.GroupBox3.Controls.Add(Me.rbObliF)
        Me.GroupBox3.Location = New System.Drawing.Point(336, 521)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(264, 72)
        Me.GroupBox3.TabIndex = 51
        Me.GroupBox3.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chkAval1)
        Me.GroupBox4.Controls.Add(Me.rbAval1M)
        Me.GroupBox4.Controls.Add(Me.rbAval1F)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 599)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(264, 72)
        Me.GroupBox4.TabIndex = 52
        Me.GroupBox4.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.chkAval2)
        Me.GroupBox5.Controls.Add(Me.rbAval2M)
        Me.GroupBox5.Controls.Add(Me.rbAval2F)
        Me.GroupBox5.Location = New System.Drawing.Point(336, 598)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(264, 72)
        Me.GroupBox5.TabIndex = 53
        Me.GroupBox5.TabStop = False
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(144, 56)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 16)
        Me.Label8.TabIndex = 54
        Me.Label8.Text = "R.F.C."
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txtRfc
        '
        Me.txtRfc.Location = New System.Drawing.Point(184, 56)
        Me.txtRfc.Name = "txtRfc"
        Me.txtRfc.ReadOnly = True
        Me.txtRfc.Size = New System.Drawing.Size(111, 20)
        Me.txtRfc.TabIndex = 55
        '
        'lblFecha1
        '
        Me.lblFecha1.Location = New System.Drawing.Point(19, 87)
        Me.lblFecha1.Name = "lblFecha1"
        Me.lblFecha1.Size = New System.Drawing.Size(187, 16)
        Me.lblFecha1.TabIndex = 57
        Me.lblFecha1.Text = "Fecha de Nacimiento o Constitución"
        Me.lblFecha1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'dtpFecha1
        '
        Me.dtpFecha1.Enabled = False
        Me.dtpFecha1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha1.Location = New System.Drawing.Point(206, 87)
        Me.dtpFecha1.Name = "dtpFecha1"
        Me.dtpFecha1.Size = New System.Drawing.Size(88, 20)
        Me.dtpFecha1.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(318, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 16)
        Me.Label3.TabIndex = 58
        Me.Label3.Text = "CURP"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'mtxtCURP
        '
        Me.mtxtCURP.BeepOnError = True
        Me.mtxtCURP.Location = New System.Drawing.Point(361, 56)
        Me.mtxtCURP.Name = "mtxtCURP"
        Me.mtxtCURP.Size = New System.Drawing.Size(128, 20)
        Me.mtxtCURP.TabIndex = 68
        '
        'frmModiGene
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(613, 725)
        Me.Controls.Add(Me.mtxtCURP)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblFecha1)
        Me.Controls.Add(Me.dtpFecha1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtRfc)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnActualizar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtDescTipo)
        Me.Controls.Add(Me.lblTipo)
        Me.Controls.Add(Me.txtDescr)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.lblPass)
        Me.Controls.Add(Me.txtPassword)
        Me.Name = "frmModiGene"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar Generales"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    ' Esta función recibe como parámetro el número del cliente y lo guarda en txtPassword.Text

    ' Declaración de variables de alcance privado

    Dim cPlaza As String = ""
    Dim cCopos As String = "00000"

    Private Sub frmModiGene_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim dsAgil As New DataSet()
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim daClientes As New SqlDataAdapter(cm1)
        Dim daPromotores As New SqlDataAdapter(cm2)
        Dim daGiros As New SqlDataAdapter(cm3)
        Dim drCliente As DataRow

        ' Declaración de variables de datos

        Dim cCliente As String
        Dim cTipo As String

        cCliente = txtPassword.Text

        ' El siguiente Stored Procedure trae todos los atributos de la tabla Clientes, para un cliente dado

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DatosClie1"
            .Connection = cnAgil
            .Parameters.Add("@Cliente", SqlDbType.NVarChar)
            .Parameters(0).Value = cCliente
        End With

        ' El siguiente Stored Procedure trae todos los atributos de todos los Promotores

        With cm2
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Promotores1"
            .Connection = cnAgil
        End With

        ' El siguiente Stored Procedure trae todos los atributos de todos los Giros

        With cm3
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Giros1"
            .Connection = cnAgil
        End With

        ' Llenar el DataSet lo cual abre y cierra la conexión

        daClientes.Fill(dsAgil, "Clientes")
        daPromotores.Fill(dsAgil, "Promotores")
        daGiros.Fill(dsAgil, "Giros")

        Try

            ' Ligar la tabla Giros del dataset dsAgil al ComboBox Giros

            cbGiros.DataSource = dsAgil
            cbGiros.DisplayMember = "Giros.DescGiro"
            cbGiros.ValueMember = "Giros.Giro"

            ' Ligar la tabla Promotores del dataset dsAgil al ComboBox Promotores

            cbPromotores.DataSource = dsAgil
            cbPromotores.DisplayMember = "Promotores.DescPromotor"
            cbPromotores.ValueMember = "Promotores.Promotor"

            If dsAgil.Tables("Clientes").Rows.Count > 0 Then

                drCliente = dsAgil.Tables("Clientes").Rows(0)
                txtDescr.Text = drCliente("Descr")
                cTipo = drCliente("Tipo")
                If cTipo = "F" Then
                    txtDescTipo.Text = "PERSONA FISICA"
                ElseIf cTipo = "E" Then
                    txtDescTipo.Text = "PERSONA FISICA CON ACTIVIDAD EMPRESARIAL"
                ElseIf cTipo = "M" Then
                    txtDescTipo.Text = "PERSONA MORAL"
                End If
                txtRfc.Text = drCliente("RFC")
                mtxtCURP.Text = drCliente("CURP")
                dtpFecha1.Value = CTOD(drCliente("Fecha1"))
                txtCalle.Text = RTrim(drCliente("Calle"))
                cCopos = Trim(drCliente("Copos"))
                txtCopos.Text = cCopos
                If cCopos <> "" And cCopos <> "00000" Then
                    cPlaza = drCliente("Plaza")
                    txtEstado.Text = RTrim(drCliente("DescPlaza"))
                    txtDelegacion.Text = drCliente("Delegacion")
                    mtxtColonia.Text = drCliente("Colonia")
                Else
                    mtxtColonia.Clear()
                    mtxtColonia.TextAlign = HorizontalAlignment.Left
                    mtxtColonia.Mask = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA"
                End If
                txtTelef1.Text = drCliente("Telef1")
                txtTelef2.Text = drCliente("Telef2")
                txtTelef3.Text = drCliente("Telef3")
                txtFax.Text = drCliente("Fax")
                txtRfc.Text = drCliente("Rfc")
                If Val(drCliente("Fecha1")) > 0 Then
                    dtpFecha1.Value = CTOD(drCliente("Fecha1"))
                Else
                    dtpFecha1.Value = DateSerial(Now.Year, Now.Month, Now.Day)
                End If
                cbGiros.SelectedIndex = Val(drCliente("Giro")) - 1
                txtMail1.Text = drCliente("EMail1")
                txtMail2.Text = drCliente("EMail2")
                cbPromotores.SelectedIndex = Val(drCliente("Promo")) - 1
                mtxtCuenta1.Text = drCliente("CuentadePago1")
                mtxtCuenta2.Text = drCliente("CuentadePago2")
                mtxtCuenta3.Text = drCliente("CuentadePago3")
                mtxtCuenta4.Text = drCliente("CuentadePago4")

                If RTrim(drCliente("FormadePago1")) = "TRANSFERENCIA" Then
                    cbFormapag1.SelectedIndex = 0
                ElseIf RTrim(drCliente("FormadePago1")) = "TARJETA" Then
                    cbFormapag1.SelectedIndex = 1
                ElseIf RTrim(drCliente("FormadePago1")) = "EFECTIVO" Then
                    cbFormapag1.SelectedIndex = 2
                ElseIf RTrim(drCliente("FormadePago1")) = "CHEQUE" Then
                    cbFormapag1.SelectedIndex = 3
                End If

                If RTrim(drCliente("FormadePago2")) = "TRANSFERENCIA" Then
                    cbFormapag2.SelectedIndex = 0
                ElseIf RTrim(drCliente("FormadePago2")) = "TARJETA" Then
                    cbFormapag2.SelectedIndex = 1
                ElseIf RTrim(drCliente("FormadePago2")) = "EFECTIVO" Then
                    cbFormapag2.SelectedIndex = 2
                ElseIf RTrim(drCliente("FormadePago2")) = "CHEQUE" Then
                    cbFormapag2.SelectedIndex = 3
                End If

                If RTrim(drCliente("FormadePago3")) = "TRANSFERENCIA" Then
                    cbFormapag3.SelectedIndex = 0
                ElseIf RTrim(drCliente("FormadePago3")) = "TARJETA" Then
                    cbFormapag3.SelectedIndex = 1
                ElseIf RTrim(drCliente("FormadePago3")) = "EFECTIVO" Then
                    cbFormapag3.SelectedIndex = 2
                ElseIf RTrim(drCliente("FormadePago3")) = "CHEQUE" Then
                    cbFormapag3.SelectedIndex = 3
                End If

                If RTrim(drCliente("FormadePago4")) = "TRANSFERENCIA" Then
                    cbFormapag4.SelectedIndex = 0
                ElseIf RTrim(drCliente("FormadePago4")) = "TARJETA" Then
                    cbFormapag4.SelectedIndex = 1
                ElseIf RTrim(drCliente("FormadePago4")) = "EFECTIVO" Then
                    cbFormapag4.SelectedIndex = 2
                ElseIf RTrim(drCliente("FormadePago4")) = "CHEQUE" Then
                    cbFormapag4.SelectedIndex = 3
                End If

                ' Determina si existe Coacreditado

                If drCliente("Coac") = "S" Then
                    chkCoac.Checked = False
                    CheckBox1.Checked = True
                    If drCliente("TipCoac") = "F" Then
                        rbCoacF.Checked = True
                        rbCoacM.Checked = False
                    Else
                        rbCoacM.Checked = True
                        rbCoacF.Checked = False
                    End If
                ElseIf drCliente("Coac") = "C" Then
                    chkCoac.Checked = True
                    CheckBox1.Checked = False
                    If drCliente("TipCoac") = "F" Then
                        rbCoacF.Checked = True
                        rbCoacM.Checked = False
                    Else
                        rbCoacM.Checked = True
                        rbCoacF.Checked = False
                    End If
                Else
                    chkCoac.Checked = False
                    CheckBox1.Checked = False
                    rbCoacF.Checked = False
                    rbCoacM.Checked = False
                End If

                ' Determina si existe Obligado Solidario

                If drCliente("Obli") = "S" Then
                    chkObli.Checked = True
                    If drCliente("TipoObli") = "F" Then
                        rbObliF.Checked = True
                        rbObliM.Checked = False
                    Else
                        rbObliM.Checked = True
                        rbObliF.Checked = False
                    End If
                Else
                    chkObli.Checked = False
                    rbObliF.Checked = False
                    rbObliM.Checked = False
                End If

                ' Determina si existe Primer Aval

                If drCliente("Aval1") = "S" Then
                    chkAval1.Checked = True
                    If drCliente("Tipaval1") = "F" Then
                        rbAval1F.Checked = True
                        rbAval1M.Checked = False
                    Else
                        rbAval1M.Checked = True
                        rbAval1F.Checked = False
                    End If
                Else
                    chkAval1.Checked = False
                    rbAval1F.Checked = False
                    rbAval1M.Checked = False
                End If

                ' Determina si existe Segundo Aval

                If drCliente("Aval2") = "S" Then
                    chkAval2.Checked = True
                    If drCliente("Tipaval2") = "F" Then
                        rbAval2F.Checked = True
                        rbAval2M.Checked = False
                    Else
                        rbAval2M.Checked = True
                        rbAval2F.Checked = False
                    End If
                Else
                    chkAval2.Checked = False
                    rbAval2F.Checked = False
                    rbAval2M.Checked = False
                End If

            End If
        Catch eException As Exception
            MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")
        End Try

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()
        cm3.Dispose()

    End Sub

    Private Sub txtCopos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCopos.LostFocus

        ' En este momento es cuando debo hacer la consulta a la tabla Copos para traer los datos del Estado y de la Delegación o Municipio

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daCodigos As New SqlDataAdapter(cm1)

        Dim dsAgil As New DataSet()
        Dim drCodigo As DataRow

        ' El siguiente Stored Procedure trae todos los atributos de la tabla Clientes, para un cliente dado

        With cm1
            .CommandType = CommandType.Text
            .CommandText = "SELECT DISTINCT Copos, Estado, Delegacion, Plaza FROM Codigos INNER JOIN Plazas ON RTrim(Codigos.Estado) = RTrim(Plazas.DescPlaza) WHERE Copos = " & txtCopos.Text
            .Connection = cnAgil
        End With

        ' Llenar el Dataset lo cual abre y cierra la conexión

        daCodigos.Fill(dsAgil, "Codigos")

        If dsAgil.Tables("Codigos").Rows.Count > 0 Then

            lblCopos.Text = ""

            drCodigo = dsAgil.Tables("Codigos").Rows(0)
            txtEstado.Text = drCodigo("Estado")
            txtDelegacion.Text = drCodigo("Delegacion")
            cPlaza = drCodigo("Plaza")

        Else

            ' Código Postal inexistente

            lblCopos.Text = "Código Postal inexistente, favor de revisarlo"

            txtEstado.Text = ""
            txtDelegacion.Text = ""
            cPlaza = ""

        End If

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim strUpdate As String

        ' Declaración de variables de datos

        Dim cAval1 As String
        Dim cAval2 As String
        Dim cCoac As String
        Dim cFecha1 As String
        Dim cGiro As String
        Dim cObli As String
        Dim cPromotor As String
        Dim cTipAval1 As String
        Dim cTipAval2 As String
        Dim cTipCoac As String
        Dim cTipoObli As String
        Dim cCero As String = "0"
        Dim lCorrecto As Boolean

        cFecha1 = DTOC(dtpFecha1.Value)
        cGiro = Stuff((cbGiros.SelectedIndex + 1).ToString, "I", "0", 2)
        cPromotor = Stuff((cbPromotores.SelectedIndex + 1).ToString, "I", "0", 3)

        lCorrecto = True

        ' Falta realizar algunas validaciones.   Por ejemplo, que no se deje la dirección 
        ' en(blanco)

        If lblCopos.Text <> "" Then
            MsgBox("Debe introducirse un Código Postal existente", MsgBoxStyle.Critical, "Error de Validación")
            lCorrecto = False
        End If

        ' Si existe Coacreditado debe indicarse si se trata de persona física o moral

        If chkCoac.Checked = True Then
            cCoac = "C"
            If rbCoacF.Checked = False And rbCoacM.Checked = False Then
                MsgBox("Debe especificarse el tipo de coacreditado", MsgBoxStyle.Critical, "Error de Validación")
                lCorrecto = False
            Else
                If rbCoacF.Checked = True Then
                    cTipCoac = "F"
                ElseIf rbCoacM.Checked = True Then
                    cTipCoac = "M"
                End If
            End If
        ElseIf CheckBox1.Checked = True Then
            cCoac = "S"
            If rbCoacF.Checked = False And rbCoacM.Checked = False Then
                MsgBox("Debe especificarse el tipo de coacreditado", MsgBoxStyle.Critical, "Error de Validación")
                lCorrecto = False
            Else
                If rbCoacF.Checked = True Then
                    cTipCoac = "F"
                ElseIf rbCoacM.Checked = True Then
                    cTipCoac = "M"
                End If
            End If
        Else
            cCoac = "N"
            cTipCoac = " "
            rbCoacF.Checked = False
            rbCoacM.Checked = False
        End If

        ' Si existe Obligado Solidario, debe especificarse si se trata de persona física o moral

        If chkObli.Checked = True Then
            If rbObliF.Checked = False And rbObliM.Checked = False Then
                MsgBox("Debe especificarse el tipo de Obligado Solidario", MsgBoxStyle.Critical, "Error de Validación")
                lCorrecto = False
            Else
                cObli = "S"
                If rbObliF.Checked = True Then
                    cTipoObli = "F"
                ElseIf rbObliM.Checked = True Then
                    cTipoObli = "M"
                End If
            End If
        Else
            cObli = "N"
            cTipoObli = " "
            rbObliF.Checked = False
            rbObliM.Checked = False
        End If

        ' Si existe Primer Aval, debe especificarse si se trata de persona física o moral

        If chkAval1.Checked = True Then
            If rbAval1F.Checked = False And rbAval1M.Checked = False Then
                MsgBox("Debe especificarse el tipo de Primer Aval", MsgBoxStyle.Critical, "Error de Validación")
                lCorrecto = False
            Else
                cAval1 = "S"
                If rbAval1F.Checked = True Then
                    cTipAval1 = "F"
                ElseIf rbAval1M.Checked = True Then
                    cTipAval1 = "M"
                End If
            End If
        Else
            cAval1 = "N"
            cTipAval1 = " "
            rbAval1F.Checked = False
            rbAval1M.Checked = False
        End If

        ' Si existe Segundo Aval, debe especificarse si se trata de persona física o moral

        If chkAval2.Checked = True Then
            If rbAval2F.Checked = False And rbAval2M.Checked = False Then
                MsgBox("Debe especificarse el tipo de Segundo Aval", MsgBoxStyle.Critical, "Error de Validación")
                lCorrecto = False
            Else
                cAval2 = "S"
                If rbAval2F.Checked = True Then
                    cTipAval2 = "F"
                ElseIf rbAval2M.Checked = True Then
                    cTipAval2 = "M"
                End If
            End If
        Else
            cAval2 = "N"
            cTipAval2 = " "
            rbAval2F.Checked = False
            rbAval2M.Checked = False
        End If

        If lCorrecto = True Then
            strUpdate = "UPDATE Clientes SET Calle = '" & txtCalle.Text & "'"
            strUpdate = strUpdate & ", Colonia = '" & mtxtColonia.Text & "'"
            strUpdate = strUpdate & ", Copos = '" & txtCopos.Text & "'"
            strUpdate = strUpdate & ", Delegacion = '" & txtDelegacion.Text & "'"
            strUpdate = strUpdate & ", Plaza = '" & cPlaza & "'"
            strUpdate = strUpdate & ", Telef1 = '" & txtTelef1.Text & "'"
            strUpdate = strUpdate & ", Telef2 = '" & txtTelef2.Text & "'"
            strUpdate = strUpdate & ", Telef3 = '" & txtTelef3.Text & "'"
            strUpdate = strUpdate & ", Fax = '" & txtFax.Text & "'"
            strUpdate = strUpdate & ", Giro = '" & cGiro & "'"
            strUpdate = strUpdate & ", CURP = '" & mtxtCURP.Text & "'"
            strUpdate = strUpdate & ", EMail1 = '" & txtMail1.Text & "'"
            strUpdate = strUpdate & ", EMail2 = '" & txtMail2.Text & "'"
            strUpdate = strUpdate & ", Promo = '" & cPromotor & "'"
            strUpdate = strUpdate & ", Coac = '" & cCoac & "'"
            strUpdate = strUpdate & ", TipCoac = '" & cTipCoac & "'"
            strUpdate = strUpdate & ", Obli = '" & cObli & "'"
            strUpdate = strUpdate & ", TipoObli = '" & cTipoObli & "'"
            strUpdate = strUpdate & ", Aval1 = '" & cAval1 & "'"
            strUpdate = strUpdate & ", TipAval1 = '" & cTipAval1 & "'"
            strUpdate = strUpdate & ", Aval2 = '" & cAval2 & "'"
            strUpdate = strUpdate & ", TipAval2 = '" & cTipAval2 & "'"
            If cbFormapag1.SelectedItem = "FECTIVO" Then
                strUpdate = strUpdate & ", CuentadePago1 = '" & cCero & "'"
                strUpdate = strUpdate & ", FormadePago1 = '" & cbFormapag1.SelectedItem & "'"
            Else
                strUpdate = strUpdate & ", CuentadePago1 = '" & mtxtCuenta1.Text & "'"
                strUpdate = strUpdate & ", FormadePago1 = '" & cbFormapag1.SelectedItem & "'"
            End If
            If cbFormapag2.SelectedItem = "EFECTIVO" Then
                strUpdate = strUpdate & ", CuentadePago2 = '" & cCero & "'"
                strUpdate = strUpdate & ", FormadePago2 = '" & cbFormapag2.SelectedItem & "'"
            Else
                strUpdate = strUpdate & ", CuentadePago2 = '" & mtxtCuenta2.Text & "'"
                strUpdate = strUpdate & ", FormadePago2 = '" & cbFormapag2.SelectedItem & "'"
            End If
            If cbFormapag3.SelectedItem = "EFECTIVO" Then
                strUpdate = strUpdate & ", CuentadePago3 = '" & cCero & "'"
                strUpdate = strUpdate & ", FormadePago3 = '" & cbFormapag3.SelectedItem & "'"
            Else
                strUpdate = strUpdate & ", CuentadePago3 = '" & mtxtCuenta3.Text & "'"
                strUpdate = strUpdate & ", FormadePago3 = '" & cbFormapag3.SelectedItem & "'"
            End If
            If cbFormapag4.SelectedItem = "EFECTIVO" Then
                strUpdate = strUpdate & ", CuentadePago4 = '" & cCero & "'"
                strUpdate = strUpdate & ", FormadePago4 = '" & cbFormapag4.SelectedItem & "'"
            Else
                strUpdate = strUpdate & ", CuentadePago4 = '" & mtxtCuenta4.Text & "'"
                strUpdate = strUpdate & ", FormadePago4 = '" & cbFormapag4.SelectedItem & "'"
            End If
            strUpdate = strUpdate & " WHERE Cliente = '" & txtPassword.Text & "'"
            Try
                cnAgil.Open()
                cm1 = New SqlCommand(strUpdate, cnAgil)
                cm1.ExecuteNonQuery()
                cnAgil.Close()
                cnAgil.Dispose()
                cm1.Dispose()
                Me.Close()
            Catch eException As Exception
                MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje")
            End Try
        End If

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            chkCoac.Checked = False
        Else
            chkCoac.Checked = True
        End If
    End Sub

    Private Sub mtxtCURP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mtxtCURP.Click
        mtxtCURP.Clear()
        mtxtCURP.TextAlign = HorizontalAlignment.Left
        mtxtCURP.Mask = "????999999AAAAAAAA"
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

End Class
