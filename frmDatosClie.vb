Option Explicit On 

Imports System.Data.SqlClient

Public Class frmDatosclie
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal cCliente As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Text = "Datos del Cliente"
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
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents lblCalle As System.Windows.Forms.Label
    Friend WithEvents lblColonia As System.Windows.Forms.Label
    Friend WithEvents lblPostal As System.Windows.Forms.Label
    Friend WithEvents lblEdo As System.Windows.Forms.Label
    Friend WithEvents lblDeleg As System.Windows.Forms.Label
    Friend WithEvents lblTelef As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblFax As System.Windows.Forms.Label
    Friend WithEvents txtDescTipo As System.Windows.Forms.TextBox
    Friend WithEvents txtCalle As System.Windows.Forms.TextBox
    Friend WithEvents txtColonia As System.Windows.Forms.TextBox
    Friend WithEvents txtCopos As System.Windows.Forms.TextBox
    Friend WithEvents txtDelegacion As System.Windows.Forms.TextBox
    Friend WithEvents txtDescPlaza As System.Windows.Forms.TextBox
    Friend WithEvents txtTelef1 As System.Windows.Forms.TextBox
    Friend WithEvents txtTelef2 As System.Windows.Forms.TextBox
    Friend WithEvents txtTelef3 As System.Windows.Forms.TextBox
    Friend WithEvents txtFax As System.Windows.Forms.TextBox
    Friend WithEvents txtRfc As System.Windows.Forms.TextBox
    Friend WithEvents lblPass As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtDescr As System.Windows.Forms.TextBox
    Friend WithEvents rtbGeneClie As System.Windows.Forms.RichTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDescPromotor As System.Windows.Forms.TextBox
    Friend WithEvents lblMail1 As System.Windows.Forms.Label
    Friend WithEvents txtMail1 As System.Windows.Forms.TextBox
    Friend WithEvents lblMail2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtColonia2 As System.Windows.Forms.TextBox
    Friend WithEvents txtCalle2 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtObserva As System.Windows.Forms.TextBox
    Friend WithEvents txtEstado As System.Windows.Forms.TextBox
    Friend WithEvents txtDelegacion2 As System.Windows.Forms.TextBox
    Friend WithEvents txtCopos2 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtMail2 As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblName = New System.Windows.Forms.Label
        Me.txtDescr = New System.Windows.Forms.TextBox
        Me.lblTipo = New System.Windows.Forms.Label
        Me.lblCalle = New System.Windows.Forms.Label
        Me.lblColonia = New System.Windows.Forms.Label
        Me.lblPostal = New System.Windows.Forms.Label
        Me.lblEdo = New System.Windows.Forms.Label
        Me.lblDeleg = New System.Windows.Forms.Label
        Me.lblTelef = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.lblFax = New System.Windows.Forms.Label
        Me.txtDescTipo = New System.Windows.Forms.TextBox
        Me.txtCalle = New System.Windows.Forms.TextBox
        Me.txtColonia = New System.Windows.Forms.TextBox
        Me.txtCopos = New System.Windows.Forms.TextBox
        Me.txtDelegacion = New System.Windows.Forms.TextBox
        Me.txtDescPlaza = New System.Windows.Forms.TextBox
        Me.txtTelef1 = New System.Windows.Forms.TextBox
        Me.txtTelef2 = New System.Windows.Forms.TextBox
        Me.txtTelef3 = New System.Windows.Forms.TextBox
        Me.txtFax = New System.Windows.Forms.TextBox
        Me.txtRfc = New System.Windows.Forms.TextBox
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.lblPass = New System.Windows.Forms.Label
        Me.lblMail1 = New System.Windows.Forms.Label
        Me.txtMail1 = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtMail2 = New System.Windows.Forms.TextBox
        Me.lblMail2 = New System.Windows.Forms.Label
        Me.txtDescPromotor = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.rtbGeneClie = New System.Windows.Forms.RichTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtCalle2 = New System.Windows.Forms.TextBox
        Me.txtColonia2 = New System.Windows.Forms.TextBox
        Me.txtCopos2 = New System.Windows.Forms.TextBox
        Me.txtDelegacion2 = New System.Windows.Forms.TextBox
        Me.txtEstado = New System.Windows.Forms.TextBox
        Me.txtObserva = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblName
        '
        Me.lblName.Location = New System.Drawing.Point(16, 16)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(56, 16)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "Nombre"
        '
        'txtDescr
        '
        Me.txtDescr.Location = New System.Drawing.Point(96, 16)
        Me.txtDescr.Name = "txtDescr"
        Me.txtDescr.ReadOnly = True
        Me.txtDescr.Size = New System.Drawing.Size(496, 20)
        Me.txtDescr.TabIndex = 1
        Me.txtDescr.TabStop = False
        '
        'lblTipo
        '
        Me.lblTipo.Location = New System.Drawing.Point(16, 40)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(56, 16)
        Me.lblTipo.TabIndex = 2
        Me.lblTipo.Text = "Tipo"
        '
        'lblCalle
        '
        Me.lblCalle.Location = New System.Drawing.Point(8, 20)
        Me.lblCalle.Name = "lblCalle"
        Me.lblCalle.Size = New System.Drawing.Size(64, 16)
        Me.lblCalle.TabIndex = 3
        Me.lblCalle.Text = "Calle"
        '
        'lblColonia
        '
        Me.lblColonia.Location = New System.Drawing.Point(8, 44)
        Me.lblColonia.Name = "lblColonia"
        Me.lblColonia.Size = New System.Drawing.Size(64, 16)
        Me.lblColonia.TabIndex = 4
        Me.lblColonia.Text = "Colonia"
        '
        'lblPostal
        '
        Me.lblPostal.Location = New System.Drawing.Point(424, 44)
        Me.lblPostal.Name = "lblPostal"
        Me.lblPostal.Size = New System.Drawing.Size(80, 16)
        Me.lblPostal.TabIndex = 5
        Me.lblPostal.Text = "Código Postal"
        '
        'lblEdo
        '
        Me.lblEdo.Location = New System.Drawing.Point(392, 68)
        Me.lblEdo.Name = "lblEdo"
        Me.lblEdo.Size = New System.Drawing.Size(56, 16)
        Me.lblEdo.TabIndex = 6
        Me.lblEdo.Text = "Estado"
        '
        'lblDeleg
        '
        Me.lblDeleg.Location = New System.Drawing.Point(8, 68)
        Me.lblDeleg.Name = "lblDeleg"
        Me.lblDeleg.Size = New System.Drawing.Size(64, 16)
        Me.lblDeleg.TabIndex = 7
        Me.lblDeleg.Text = "Delegación"
        '
        'lblTelef
        '
        Me.lblTelef.Location = New System.Drawing.Point(8, 92)
        Me.lblTelef.Name = "lblTelef"
        Me.lblTelef.Size = New System.Drawing.Size(64, 16)
        Me.lblTelef.TabIndex = 8
        Me.lblTelef.Text = "Teléfonos"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(8, 140)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 16)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "R.F.C."
        '
        'lblFax
        '
        Me.lblFax.Location = New System.Drawing.Point(8, 116)
        Me.lblFax.Name = "lblFax"
        Me.lblFax.Size = New System.Drawing.Size(64, 16)
        Me.lblFax.TabIndex = 10
        Me.lblFax.Text = "Fax"
        '
        'txtDescTipo
        '
        Me.txtDescTipo.Location = New System.Drawing.Point(96, 40)
        Me.txtDescTipo.Name = "txtDescTipo"
        Me.txtDescTipo.ReadOnly = True
        Me.txtDescTipo.Size = New System.Drawing.Size(496, 20)
        Me.txtDescTipo.TabIndex = 11
        Me.txtDescTipo.TabStop = False
        '
        'txtCalle
        '
        Me.txtCalle.Location = New System.Drawing.Point(96, 16)
        Me.txtCalle.Name = "txtCalle"
        Me.txtCalle.ReadOnly = True
        Me.txtCalle.Size = New System.Drawing.Size(488, 20)
        Me.txtCalle.TabIndex = 12
        Me.txtCalle.TabStop = False
        '
        'txtColonia
        '
        Me.txtColonia.Location = New System.Drawing.Point(96, 40)
        Me.txtColonia.Name = "txtColonia"
        Me.txtColonia.ReadOnly = True
        Me.txtColonia.Size = New System.Drawing.Size(264, 20)
        Me.txtColonia.TabIndex = 13
        Me.txtColonia.TabStop = False
        '
        'txtCopos
        '
        Me.txtCopos.Location = New System.Drawing.Point(512, 40)
        Me.txtCopos.Name = "txtCopos"
        Me.txtCopos.ReadOnly = True
        Me.txtCopos.Size = New System.Drawing.Size(72, 20)
        Me.txtCopos.TabIndex = 14
        Me.txtCopos.TabStop = False
        '
        'txtDelegacion
        '
        Me.txtDelegacion.Location = New System.Drawing.Point(96, 64)
        Me.txtDelegacion.Name = "txtDelegacion"
        Me.txtDelegacion.ReadOnly = True
        Me.txtDelegacion.Size = New System.Drawing.Size(264, 20)
        Me.txtDelegacion.TabIndex = 15
        Me.txtDelegacion.TabStop = False
        '
        'txtDescPlaza
        '
        Me.txtDescPlaza.Location = New System.Drawing.Point(456, 64)
        Me.txtDescPlaza.Name = "txtDescPlaza"
        Me.txtDescPlaza.ReadOnly = True
        Me.txtDescPlaza.Size = New System.Drawing.Size(128, 20)
        Me.txtDescPlaza.TabIndex = 16
        Me.txtDescPlaza.TabStop = False
        '
        'txtTelef1
        '
        Me.txtTelef1.Location = New System.Drawing.Point(96, 88)
        Me.txtTelef1.Name = "txtTelef1"
        Me.txtTelef1.ReadOnly = True
        Me.txtTelef1.Size = New System.Drawing.Size(104, 20)
        Me.txtTelef1.TabIndex = 17
        Me.txtTelef1.TabStop = False
        '
        'txtTelef2
        '
        Me.txtTelef2.Location = New System.Drawing.Point(216, 88)
        Me.txtTelef2.Name = "txtTelef2"
        Me.txtTelef2.ReadOnly = True
        Me.txtTelef2.Size = New System.Drawing.Size(104, 20)
        Me.txtTelef2.TabIndex = 18
        Me.txtTelef2.TabStop = False
        '
        'txtTelef3
        '
        Me.txtTelef3.Location = New System.Drawing.Point(328, 88)
        Me.txtTelef3.Name = "txtTelef3"
        Me.txtTelef3.ReadOnly = True
        Me.txtTelef3.Size = New System.Drawing.Size(104, 20)
        Me.txtTelef3.TabIndex = 19
        Me.txtTelef3.TabStop = False
        '
        'txtFax
        '
        Me.txtFax.Location = New System.Drawing.Point(96, 112)
        Me.txtFax.Name = "txtFax"
        Me.txtFax.ReadOnly = True
        Me.txtFax.Size = New System.Drawing.Size(104, 20)
        Me.txtFax.TabIndex = 20
        Me.txtFax.TabStop = False
        '
        'txtRfc
        '
        Me.txtRfc.Location = New System.Drawing.Point(96, 136)
        Me.txtRfc.Name = "txtRfc"
        Me.txtRfc.ReadOnly = True
        Me.txtRfc.Size = New System.Drawing.Size(104, 20)
        Me.txtRfc.TabIndex = 21
        Me.txtRfc.TabStop = False
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(328, 136)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.ReadOnly = True
        Me.txtPassword.Size = New System.Drawing.Size(41, 20)
        Me.txtPassword.TabIndex = 22
        Me.txtPassword.TabStop = False
        '
        'lblPass
        '
        Me.lblPass.Location = New System.Drawing.Point(256, 140)
        Me.lblPass.Name = "lblPass"
        Me.lblPass.Size = New System.Drawing.Size(72, 16)
        Me.lblPass.TabIndex = 23
        Me.lblPass.Text = "Contraseña"
        '
        'lblMail1
        '
        Me.lblMail1.Location = New System.Drawing.Point(8, 180)
        Me.lblMail1.Name = "lblMail1"
        Me.lblMail1.Size = New System.Drawing.Size(128, 16)
        Me.lblMail1.TabIndex = 24
        Me.lblMail1.Text = "Email Principal"
        '
        'txtMail1
        '
        Me.txtMail1.Location = New System.Drawing.Point(152, 176)
        Me.txtMail1.Name = "txtMail1"
        Me.txtMail1.ReadOnly = True
        Me.txtMail1.Size = New System.Drawing.Size(368, 20)
        Me.txtMail1.TabIndex = 25
        Me.txtMail1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtMail2)
        Me.GroupBox1.Controls.Add(Me.lblMail2)
        Me.GroupBox1.Controls.Add(Me.txtDescPromotor)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtRfc)
        Me.GroupBox1.Controls.Add(Me.lblPass)
        Me.GroupBox1.Controls.Add(Me.txtPassword)
        Me.GroupBox1.Controls.Add(Me.lblMail1)
        Me.GroupBox1.Controls.Add(Me.txtMail1)
        Me.GroupBox1.Controls.Add(Me.lblFax)
        Me.GroupBox1.Controls.Add(Me.txtFax)
        Me.GroupBox1.Controls.Add(Me.lblTelef)
        Me.GroupBox1.Controls.Add(Me.txtTelef1)
        Me.GroupBox1.Controls.Add(Me.txtTelef2)
        Me.GroupBox1.Controls.Add(Me.txtTelef3)
        Me.GroupBox1.Controls.Add(Me.lblEdo)
        Me.GroupBox1.Controls.Add(Me.txtDescPlaza)
        Me.GroupBox1.Controls.Add(Me.lblDeleg)
        Me.GroupBox1.Controls.Add(Me.txtDelegacion)
        Me.GroupBox1.Controls.Add(Me.lblPostal)
        Me.GroupBox1.Controls.Add(Me.txtCopos)
        Me.GroupBox1.Controls.Add(Me.lblColonia)
        Me.GroupBox1.Controls.Add(Me.txtColonia)
        Me.GroupBox1.Controls.Add(Me.lblCalle)
        Me.GroupBox1.Controls.Add(Me.txtCalle)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 72)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(592, 256)
        Me.GroupBox1.TabIndex = 28
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Domicilio Fiscal"
        '
        'txtMail2
        '
        Me.txtMail2.Location = New System.Drawing.Point(152, 200)
        Me.txtMail2.Name = "txtMail2"
        Me.txtMail2.ReadOnly = True
        Me.txtMail2.Size = New System.Drawing.Size(368, 20)
        Me.txtMail2.TabIndex = 29
        Me.txtMail2.TabStop = False
        '
        'lblMail2
        '
        Me.lblMail2.Location = New System.Drawing.Point(8, 204)
        Me.lblMail2.Name = "lblMail2"
        Me.lblMail2.Size = New System.Drawing.Size(128, 16)
        Me.lblMail2.TabIndex = 28
        Me.lblMail2.Text = "Email Secundario"
        '
        'txtDescPromotor
        '
        Me.txtDescPromotor.Location = New System.Drawing.Point(152, 224)
        Me.txtDescPromotor.Name = "txtDescPromotor"
        Me.txtDescPromotor.ReadOnly = True
        Me.txtDescPromotor.Size = New System.Drawing.Size(368, 20)
        Me.txtDescPromotor.TabIndex = 27
        Me.txtDescPromotor.TabStop = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 228)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 16)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Ejecutivo que lo atiende"
        '
        'rtbGeneClie
        '
        Me.rtbGeneClie.Location = New System.Drawing.Point(8, 506)
        Me.rtbGeneClie.Name = "rtbGeneClie"
        Me.rtbGeneClie.ReadOnly = True
        Me.rtbGeneClie.Size = New System.Drawing.Size(584, 96)
        Me.rtbGeneClie.TabIndex = 29
        Me.rtbGeneClie.TabStop = False
        Me.rtbGeneClie.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(224, 482)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 16)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Datos Generales del Cliente"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtObserva)
        Me.GroupBox2.Controls.Add(Me.txtEstado)
        Me.GroupBox2.Controls.Add(Me.txtDelegacion2)
        Me.GroupBox2.Controls.Add(Me.txtCopos2)
        Me.GroupBox2.Controls.Add(Me.txtColonia2)
        Me.GroupBox2.Controls.Add(Me.txtCalle2)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 345)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(591, 123)
        Me.GroupBox2.TabIndex = 31
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Domicilio para Correspondencia"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(10, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Calle"
        '
        'txtCalle2
        '
        Me.txtCalle2.Location = New System.Drawing.Point(96, 18)
        Me.txtCalle2.Name = "txtCalle2"
        Me.txtCalle2.ReadOnly = True
        Me.txtCalle2.Size = New System.Drawing.Size(488, 20)
        Me.txtCalle2.TabIndex = 13
        Me.txtCalle2.TabStop = False
        '
        'txtColonia2
        '
        Me.txtColonia2.AcceptsReturn = True
        Me.txtColonia2.Location = New System.Drawing.Point(96, 42)
        Me.txtColonia2.Name = "txtColonia2"
        Me.txtColonia2.ReadOnly = True
        Me.txtColonia2.Size = New System.Drawing.Size(264, 20)
        Me.txtColonia2.TabIndex = 14
        Me.txtColonia2.TabStop = False
        '
        'txtCopos2
        '
        Me.txtCopos2.Location = New System.Drawing.Point(512, 42)
        Me.txtCopos2.Name = "txtCopos2"
        Me.txtCopos2.ReadOnly = True
        Me.txtCopos2.Size = New System.Drawing.Size(72, 20)
        Me.txtCopos2.TabIndex = 15
        Me.txtCopos2.TabStop = False
        '
        'txtDelegacion2
        '
        Me.txtDelegacion2.Location = New System.Drawing.Point(96, 66)
        Me.txtDelegacion2.Name = "txtDelegacion2"
        Me.txtDelegacion2.ReadOnly = True
        Me.txtDelegacion2.Size = New System.Drawing.Size(264, 20)
        Me.txtDelegacion2.TabIndex = 16
        Me.txtDelegacion2.TabStop = False
        '
        'txtEstado
        '
        Me.txtEstado.Location = New System.Drawing.Point(456, 65)
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.ReadOnly = True
        Me.txtEstado.Size = New System.Drawing.Size(128, 20)
        Me.txtEstado.TabIndex = 17
        Me.txtEstado.TabStop = False
        '
        'txtObserva
        '
        Me.txtObserva.Location = New System.Drawing.Point(96, 91)
        Me.txtObserva.Name = "txtObserva"
        Me.txtObserva.ReadOnly = True
        Me.txtObserva.Size = New System.Drawing.Size(488, 20)
        Me.txtObserva.TabIndex = 26
        Me.txtObserva.TabStop = False
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 16)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Colonia"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 68)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 16)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Delegación"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(424, 46)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 16)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Código Postal"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(392, 68)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 16)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Estado"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(8, 94)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(82, 17)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "Observaciones"
        '
        'frmDatosclie
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(608, 614)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.rtbGeneClie)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtDescTipo)
        Me.Controls.Add(Me.lblTipo)
        Me.Controls.Add(Me.txtDescr)
        Me.Controls.Add(Me.lblName)
        Me.Name = "frmDatosclie"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Datos del Cliente"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub frmDatosclie_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim dsAgil As New DataSet()
        Dim daClientes As New SqlDataAdapter(cm1)
        Dim daPostal As New SqlDataAdapter(cm2)
        Dim drCliente As DataRow
        Dim drPostal As DataRow

        ' Declaración de variables de datos

        Dim cCliente As String
        Dim cTipo As String
        Dim nCounter As Integer

        cCliente = txtPassword.Text

        ' El siguiente Stored Procedure trae todos los atributos de la tabla Clientes,
        ' para un cliente dado.

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DatosClie1"
            .Connection = cnAgil
            .Parameters.Add("@Cliente", SqlDbType.NVarChar)
            .Parameters(0).Value = cCliente
        End With

        ' El siguiente Sotred Procedure trae todos los atributos de la tabla Postal,
        ' para un cliente dado

        With cm2
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DatosClie2"
            .Connection = cnAgil
            .Parameters.Add("@Cliente", SqlDbType.NVarChar)
            .Parameters(0).Value = cCliente
        End With

        ' Llenar el DataSet lo cual abre y cierra la conexión

        Try
            daClientes.Fill(dsAgil, "Clientes")
            daPostal.Fill(dsAgil, "Postal")
            drCliente = dsAgil.Tables("Clientes").Rows(0)

            nCounter = dsAgil.Tables("Postal").Rows.Count

            txtDescr.Text = drCliente("Descr")
            cTipo = drCliente("Tipo")
            If cTipo = "F" Then
                txtDescTipo.Text = "PERSONA FISICA"
            ElseIf cTipo = "E" Then
                txtDescTipo.Text = "PERSONA FISICA CON ACTIVIDAD EMPRESARIAL"
            ElseIf cTipo = "M" Then
                txtDescTipo.Text = "PERSONA MORAL"
            End If

            txtCalle.Text = drCliente("Calle")
            txtColonia.Text = drCliente("Colonia")
            txtCopos.Text = drCliente("Copos")
            txtDelegacion.Text = drCliente("Delegacion")
            txtDescPlaza.Text = drCliente("DescPlaza")
            txtTelef1.Text = drCliente("Telef1")
            txtTelef2.Text = drCliente("Telef2")
            txtTelef3.Text = drCliente("Telef3")
            txtFax.Text = drCliente("Fax")
            txtRfc.Text = drCliente("Rfc")
            txtDescPromotor.Text = drCliente("DescPromotor")
            If Not drCliente("GeneClie") Is System.DBNull.Value Then
                rtbGeneClie.Text = drCliente("GeneClie")
            End If
            txtMail1.Text = drCliente("Email1")
            txtMail2.Text = drCliente("Email2")

            If nCounter > 0 Then
                drPostal = dsAgil.Tables("Postal").Rows(0)
                txtCalle2.Text = drPostal("Calle")
                txtColonia2.Text = drPostal("Colonia")
                txtCopos2.Text = drPostal("Copos")
                txtDelegacion2.Text = drPostal("Delegacion")
                txtEstado.Text = drPostal("DescPlaza")
                txtObserva.Text = drPostal("Observa")
            End If

        Catch eException As Exception
            MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje")
        End Try

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

End Class
