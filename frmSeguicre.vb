Option Explicit On

Imports System.Math
Imports System.Data.SqlClient
Imports System.IO
Imports System.Security
Imports System.Security.Principal.WindowsIdentity
Imports Microsoft.Office.Interop


Public Class frmSeguicre

    Inherits System.Windows.Forms.Form
    Dim myIdentity As Principal.WindowsIdentity
    Dim cUsuario As String

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal cCliente As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        txtCliente.Text = cCliente
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
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents btnSegui As System.Windows.Forms.Button
    Friend WithEvents btnGaran As System.Windows.Forms.Button
    Friend WithEvents btnAnalisis As System.Windows.Forms.Button
    Friend WithEvents btnAmplia As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents lblEncab As System.Windows.Forms.Label
    Friend WithEvents lblVig As System.Windows.Forms.Label
    Friend WithEvents lblLineau As System.Windows.Forms.Label
    Friend WithEvents lblFeaut As System.Windows.Forms.Label
    Friend WithEvents lblFecre As System.Windows.Forms.Label
    Friend WithEvents lblFecdi As System.Windows.Forms.Label
    Friend WithEvents lblDicta As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblCte As System.Windows.Forms.Label
    Friend WithEvents lblSoli As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtFecre As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtCte As System.Windows.Forms.TextBox
    Friend WithEvents txtSoli As System.Windows.Forms.TextBox
    Friend WithEvents cbDicta As System.Windows.Forms.ComboBox
    Friend WithEvents btnCambio As System.Windows.Forms.Button
    Friend WithEvents btnSalvar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker3 As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtLineau As System.Windows.Forms.TextBox
    Friend WithEvents txtGar1 As System.Windows.Forms.TextBox
    Friend WithEvents txtGar2 As System.Windows.Forms.TextBox
    Friend WithEvents btnModif As System.Windows.Forms.Button
    Friend WithEvents btnGuarda As System.Windows.Forms.Button
    Friend WithEvents btnRetorna As System.Windows.Forms.Button
    Friend WithEvents gbGarantias As System.Windows.Forms.GroupBox
    Friend WithEvents btnCaratula As System.Windows.Forms.Button
    Friend WithEvents cbStatu As System.Windows.Forms.ComboBox
    Friend WithEvents txtLinau As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox10 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.btnSegui = New System.Windows.Forms.Button
        Me.btnGaran = New System.Windows.Forms.Button
        Me.btnAnalisis = New System.Windows.Forms.Button
        Me.btnAmplia = New System.Windows.Forms.Button
        Me.txtCliente = New System.Windows.Forms.TextBox
        Me.lblEncab = New System.Windows.Forms.Label
        Me.btnSalir = New System.Windows.Forms.Button
        Me.txtLineau = New System.Windows.Forms.TextBox
        Me.txtFecre = New System.Windows.Forms.TextBox
        Me.txtName = New System.Windows.Forms.TextBox
        Me.txtCte = New System.Windows.Forms.TextBox
        Me.txtSoli = New System.Windows.Forms.TextBox
        Me.lblVig = New System.Windows.Forms.Label
        Me.lblLineau = New System.Windows.Forms.Label
        Me.lblFeaut = New System.Windows.Forms.Label
        Me.lblFecre = New System.Windows.Forms.Label
        Me.lblFecdi = New System.Windows.Forms.Label
        Me.lblDicta = New System.Windows.Forms.Label
        Me.lblStatus = New System.Windows.Forms.Label
        Me.lblName = New System.Windows.Forms.Label
        Me.lblCte = New System.Windows.Forms.Label
        Me.lblSoli = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnSave = New System.Windows.Forms.Button
        Me.cbStatu = New System.Windows.Forms.ComboBox
        Me.txtLinau = New System.Windows.Forms.TextBox
        Me.DateTimePicker3 = New System.Windows.Forms.DateTimePicker
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnSalvar = New System.Windows.Forms.Button
        Me.btnCambio = New System.Windows.Forms.Button
        Me.cbDicta = New System.Windows.Forms.ComboBox
        Me.gbGarantias = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBox10 = New System.Windows.Forms.TextBox
        Me.TextBox9 = New System.Windows.Forms.TextBox
        Me.TextBox8 = New System.Windows.Forms.TextBox
        Me.TextBox7 = New System.Windows.Forms.TextBox
        Me.TextBox6 = New System.Windows.Forms.TextBox
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.btnRetorna = New System.Windows.Forms.Button
        Me.btnGuarda = New System.Windows.Forms.Button
        Me.btnModif = New System.Windows.Forms.Button
        Me.txtGar2 = New System.Windows.Forms.TextBox
        Me.txtGar1 = New System.Windows.Forms.TextBox
        Me.btnCaratula = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.gbGarantias.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.Location = New System.Drawing.Point(16, 40)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(168, 199)
        Me.ListBox1.TabIndex = 12
        '
        'btnSegui
        '
        Me.btnSegui.Location = New System.Drawing.Point(208, 48)
        Me.btnSegui.Name = "btnSegui"
        Me.btnSegui.Size = New System.Drawing.Size(96, 23)
        Me.btnSegui.TabIndex = 13
        Me.btnSegui.Text = "Seguimiento"
        '
        'btnGaran
        '
        Me.btnGaran.Location = New System.Drawing.Point(208, 80)
        Me.btnGaran.Name = "btnGaran"
        Me.btnGaran.Size = New System.Drawing.Size(96, 23)
        Me.btnGaran.TabIndex = 14
        Me.btnGaran.Text = "Garantías"
        '
        'btnAnalisis
        '
        Me.btnAnalisis.Location = New System.Drawing.Point(208, 144)
        Me.btnAnalisis.Name = "btnAnalisis"
        Me.btnAnalisis.Size = New System.Drawing.Size(96, 23)
        Me.btnAnalisis.TabIndex = 15
        Me.btnAnalisis.Text = "Análisis"
        '
        'btnAmplia
        '
        Me.btnAmplia.Location = New System.Drawing.Point(537, 200)
        Me.btnAmplia.Name = "btnAmplia"
        Me.btnAmplia.Size = New System.Drawing.Size(80, 23)
        Me.btnAmplia.TabIndex = 17
        Me.btnAmplia.Text = "Ampliar Línea"
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(224, 16)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(8, 20)
        Me.txtCliente.TabIndex = 18
        Me.txtCliente.Text = "TextBox1"
        Me.txtCliente.Visible = False
        '
        'lblEncab
        '
        Me.lblEncab.Location = New System.Drawing.Point(16, 24)
        Me.lblEncab.Name = "lblEncab"
        Me.lblEncab.Size = New System.Drawing.Size(168, 16)
        Me.lblEncab.TabIndex = 19
        Me.lblEncab.Text = "Solicitud  Disposion  Contrato"
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(208, 216)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(96, 23)
        Me.btnSalir.TabIndex = 20
        Me.btnSalir.Text = "Salir"
        '
        'txtLineau
        '
        Me.txtLineau.Location = New System.Drawing.Point(104, 216)
        Me.txtLineau.Name = "txtLineau"
        Me.txtLineau.ReadOnly = True
        Me.txtLineau.Size = New System.Drawing.Size(88, 20)
        Me.txtLineau.TabIndex = 17
        Me.txtLineau.TabStop = False
        '
        'txtFecre
        '
        Me.txtFecre.Location = New System.Drawing.Point(104, 168)
        Me.txtFecre.Name = "txtFecre"
        Me.txtFecre.ReadOnly = True
        Me.txtFecre.Size = New System.Drawing.Size(88, 20)
        Me.txtFecre.TabIndex = 16
        Me.txtFecre.TabStop = False
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(104, 56)
        Me.txtName.Name = "txtName"
        Me.txtName.ReadOnly = True
        Me.txtName.Size = New System.Drawing.Size(512, 20)
        Me.txtName.TabIndex = 12
        Me.txtName.TabStop = False
        '
        'txtCte
        '
        Me.txtCte.Location = New System.Drawing.Point(104, 32)
        Me.txtCte.Name = "txtCte"
        Me.txtCte.ReadOnly = True
        Me.txtCte.Size = New System.Drawing.Size(88, 20)
        Me.txtCte.TabIndex = 11
        Me.txtCte.TabStop = False
        '
        'txtSoli
        '
        Me.txtSoli.Location = New System.Drawing.Point(104, 8)
        Me.txtSoli.Name = "txtSoli"
        Me.txtSoli.ReadOnly = True
        Me.txtSoli.Size = New System.Drawing.Size(88, 20)
        Me.txtSoli.TabIndex = 10
        Me.txtSoli.TabStop = False
        '
        'lblVig
        '
        Me.lblVig.Location = New System.Drawing.Point(24, 240)
        Me.lblVig.Name = "lblVig"
        Me.lblVig.Size = New System.Drawing.Size(80, 16)
        Me.lblVig.TabIndex = 9
        Me.lblVig.Text = "Vigencia"
        '
        'lblLineau
        '
        Me.lblLineau.Location = New System.Drawing.Point(24, 216)
        Me.lblLineau.Name = "lblLineau"
        Me.lblLineau.Size = New System.Drawing.Size(88, 16)
        Me.lblLineau.TabIndex = 8
        Me.lblLineau.Text = "Línea Autoriz."
        '
        'lblFeaut
        '
        Me.lblFeaut.Location = New System.Drawing.Point(24, 192)
        Me.lblFeaut.Name = "lblFeaut"
        Me.lblFeaut.Size = New System.Drawing.Size(80, 16)
        Me.lblFeaut.TabIndex = 7
        Me.lblFeaut.Text = "Fecha Autoriz."
        '
        'lblFecre
        '
        Me.lblFecre.Location = New System.Drawing.Point(24, 168)
        Me.lblFecre.Name = "lblFecre"
        Me.lblFecre.Size = New System.Drawing.Size(72, 16)
        Me.lblFecre.TabIndex = 6
        Me.lblFecre.Text = "Fecha Cre."
        '
        'lblFecdi
        '
        Me.lblFecdi.Location = New System.Drawing.Point(24, 144)
        Me.lblFecdi.Name = "lblFecdi"
        Me.lblFecdi.Size = New System.Drawing.Size(72, 16)
        Me.lblFecdi.TabIndex = 5
        Me.lblFecdi.Text = "Fecha Pre."
        '
        'lblDicta
        '
        Me.lblDicta.Location = New System.Drawing.Point(24, 120)
        Me.lblDicta.Name = "lblDicta"
        Me.lblDicta.Size = New System.Drawing.Size(72, 16)
        Me.lblDicta.TabIndex = 4
        Me.lblDicta.Text = "Dictamen"
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(24, 96)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(72, 16)
        Me.lblStatus.TabIndex = 3
        Me.lblStatus.Text = "Status"
        '
        'lblName
        '
        Me.lblName.Location = New System.Drawing.Point(24, 64)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(72, 16)
        Me.lblName.TabIndex = 2
        Me.lblName.Text = "Nombre"
        '
        'lblCte
        '
        Me.lblCte.Location = New System.Drawing.Point(24, 40)
        Me.lblCte.Name = "lblCte"
        Me.lblCte.Size = New System.Drawing.Size(72, 16)
        Me.lblCte.TabIndex = 1
        Me.lblCte.Text = "Cliente No."
        '
        'lblSoli
        '
        Me.lblSoli.Location = New System.Drawing.Point(24, 16)
        Me.lblSoli.Name = "lblSoli"
        Me.lblSoli.Size = New System.Drawing.Size(80, 16)
        Me.lblSoli.TabIndex = 0
        Me.lblSoli.Text = "Solicitud No."
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Controls.Add(Me.cbStatu)
        Me.Panel1.Controls.Add(Me.txtLinau)
        Me.Panel1.Controls.Add(Me.DateTimePicker3)
        Me.Panel1.Controls.Add(Me.DateTimePicker2)
        Me.Panel1.Controls.Add(Me.btnAmplia)
        Me.Panel1.Controls.Add(Me.DateTimePicker1)
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Controls.Add(Me.btnSalvar)
        Me.Panel1.Controls.Add(Me.btnCambio)
        Me.Panel1.Controls.Add(Me.cbDicta)
        Me.Panel1.Controls.Add(Me.txtLineau)
        Me.Panel1.Controls.Add(Me.txtFecre)
        Me.Panel1.Controls.Add(Me.txtName)
        Me.Panel1.Controls.Add(Me.txtCte)
        Me.Panel1.Controls.Add(Me.txtSoli)
        Me.Panel1.Controls.Add(Me.lblVig)
        Me.Panel1.Controls.Add(Me.lblLineau)
        Me.Panel1.Controls.Add(Me.lblFeaut)
        Me.Panel1.Controls.Add(Me.lblFecre)
        Me.Panel1.Controls.Add(Me.lblFecdi)
        Me.Panel1.Controls.Add(Me.lblDicta)
        Me.Panel1.Controls.Add(Me.lblStatus)
        Me.Panel1.Controls.Add(Me.lblName)
        Me.Panel1.Controls.Add(Me.lblCte)
        Me.Panel1.Controls.Add(Me.lblSoli)
        Me.Panel1.Location = New System.Drawing.Point(14, 267)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(632, 272)
        Me.Panel1.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(278, 182)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Linea Autorizada :"
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(409, 202)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(56, 24)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Salvar"
        '
        'cbStatu
        '
        Me.cbStatu.Enabled = False
        Me.cbStatu.Items.AddRange(New Object() {"1  EN PROMOCION", "2  EN CREDITO (ENTRADA)", "3  EN CREDITO (ANALISIS)", "4  EN CREDITO (DICTAMEN)", "5  AUTORIZADO", "6  CANCELADO"})
        Me.cbStatu.Location = New System.Drawing.Point(104, 88)
        Me.cbStatu.Name = "cbStatu"
        Me.cbStatu.Size = New System.Drawing.Size(184, 21)
        Me.cbStatu.TabIndex = 20
        '
        'txtLinau
        '
        Me.txtLinau.Enabled = False
        Me.txtLinau.Location = New System.Drawing.Point(281, 205)
        Me.txtLinau.Name = "txtLinau"
        Me.txtLinau.Size = New System.Drawing.Size(104, 20)
        Me.txtLinau.TabIndex = 1
        Me.txtLinau.TabStop = False
        '
        'DateTimePicker3
        '
        Me.DateTimePicker3.Enabled = False
        Me.DateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker3.Location = New System.Drawing.Point(104, 240)
        Me.DateTimePicker3.Name = "DateTimePicker3"
        Me.DateTimePicker3.Size = New System.Drawing.Size(88, 20)
        Me.DateTimePicker3.TabIndex = 27
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Enabled = False
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(104, 192)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(88, 20)
        Me.DateTimePicker2.TabIndex = 26
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Enabled = False
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(104, 144)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(88, 20)
        Me.DateTimePicker1.TabIndex = 25
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(536, 232)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 24)
        Me.btnCancelar.TabIndex = 23
        Me.btnCancelar.Text = "Regresar"
        '
        'btnSalvar
        '
        Me.btnSalvar.Location = New System.Drawing.Point(536, 168)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(80, 24)
        Me.btnSalvar.TabIndex = 22
        Me.btnSalvar.Text = "Guardar"
        '
        'btnCambio
        '
        Me.btnCambio.Location = New System.Drawing.Point(536, 136)
        Me.btnCambio.Name = "btnCambio"
        Me.btnCambio.Size = New System.Drawing.Size(80, 24)
        Me.btnCambio.TabIndex = 21
        Me.btnCambio.Text = "Modificar"
        '
        'cbDicta
        '
        Me.cbDicta.Enabled = False
        Me.cbDicta.Items.AddRange(New Object() {"AUTORIZADO", "RECHAZADO", "PENDIENTE"})
        Me.cbDicta.Location = New System.Drawing.Point(104, 120)
        Me.cbDicta.Name = "cbDicta"
        Me.cbDicta.Size = New System.Drawing.Size(104, 21)
        Me.cbDicta.TabIndex = 24
        '
        'gbGarantias
        '
        Me.gbGarantias.Controls.Add(Me.Label3)
        Me.gbGarantias.Controls.Add(Me.Label2)
        Me.gbGarantias.Controls.Add(Me.TextBox10)
        Me.gbGarantias.Controls.Add(Me.TextBox9)
        Me.gbGarantias.Controls.Add(Me.TextBox8)
        Me.gbGarantias.Controls.Add(Me.TextBox7)
        Me.gbGarantias.Controls.Add(Me.TextBox6)
        Me.gbGarantias.Controls.Add(Me.TextBox5)
        Me.gbGarantias.Controls.Add(Me.TextBox4)
        Me.gbGarantias.Controls.Add(Me.TextBox3)
        Me.gbGarantias.Controls.Add(Me.TextBox2)
        Me.gbGarantias.Controls.Add(Me.TextBox1)
        Me.gbGarantias.Controls.Add(Me.CheckBox2)
        Me.gbGarantias.Controls.Add(Me.CheckBox1)
        Me.gbGarantias.Controls.Add(Me.btnRetorna)
        Me.gbGarantias.Controls.Add(Me.btnGuarda)
        Me.gbGarantias.Controls.Add(Me.btnModif)
        Me.gbGarantias.Controls.Add(Me.txtGar2)
        Me.gbGarantias.Controls.Add(Me.txtGar1)
        Me.gbGarantias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbGarantias.Location = New System.Drawing.Point(16, 272)
        Me.gbGarantias.Name = "gbGarantias"
        Me.gbGarantias.Size = New System.Drawing.Size(632, 264)
        Me.gbGarantias.TabIndex = 22
        Me.gbGarantias.TabStop = False
        Me.gbGarantias.Visible = False
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(464, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 16)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "%"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(168, 16)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Principales Accionistas"
        '
        'TextBox10
        '
        Me.TextBox10.Location = New System.Drawing.Point(448, 224)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.ReadOnly = True
        Me.TextBox10.Size = New System.Drawing.Size(40, 20)
        Me.TextBox10.TabIndex = 16
        '
        'TextBox9
        '
        Me.TextBox9.Location = New System.Drawing.Point(448, 200)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.ReadOnly = True
        Me.TextBox9.Size = New System.Drawing.Size(40, 20)
        Me.TextBox9.TabIndex = 15
        '
        'TextBox8
        '
        Me.TextBox8.Location = New System.Drawing.Point(448, 176)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.ReadOnly = True
        Me.TextBox8.Size = New System.Drawing.Size(40, 20)
        Me.TextBox8.TabIndex = 14
        '
        'TextBox7
        '
        Me.TextBox7.Location = New System.Drawing.Point(448, 152)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.ReadOnly = True
        Me.TextBox7.Size = New System.Drawing.Size(40, 20)
        Me.TextBox7.TabIndex = 13
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(448, 128)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.ReadOnly = True
        Me.TextBox6.Size = New System.Drawing.Size(40, 20)
        Me.TextBox6.TabIndex = 12
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(16, 224)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(416, 20)
        Me.TextBox5.TabIndex = 11
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(16, 200)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(416, 20)
        Me.TextBox4.TabIndex = 10
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(16, 176)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(416, 20)
        Me.TextBox3.TabIndex = 9
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(16, 152)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(416, 20)
        Me.TextBox2.TabIndex = 8
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(16, 128)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(416, 20)
        Me.TextBox1.TabIndex = 7
        '
        'CheckBox2
        '
        Me.CheckBox2.Enabled = False
        Me.CheckBox2.Location = New System.Drawing.Point(480, 72)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(128, 24)
        Me.CheckBox2.TabIndex = 6
        Me.CheckBox2.Text = "Garantía Hipotecaría"
        '
        'CheckBox1
        '
        Me.CheckBox1.Enabled = False
        Me.CheckBox1.Location = New System.Drawing.Point(336, 72)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(128, 24)
        Me.CheckBox1.TabIndex = 5
        Me.CheckBox1.Text = "Garantía Prendaría"
        '
        'btnRetorna
        '
        Me.btnRetorna.Location = New System.Drawing.Point(544, 216)
        Me.btnRetorna.Name = "btnRetorna"
        Me.btnRetorna.Size = New System.Drawing.Size(72, 24)
        Me.btnRetorna.TabIndex = 4
        Me.btnRetorna.Text = "Regresar"
        '
        'btnGuarda
        '
        Me.btnGuarda.Location = New System.Drawing.Point(544, 184)
        Me.btnGuarda.Name = "btnGuarda"
        Me.btnGuarda.Size = New System.Drawing.Size(72, 24)
        Me.btnGuarda.TabIndex = 3
        Me.btnGuarda.Text = "Guardar"
        '
        'btnModif
        '
        Me.btnModif.Location = New System.Drawing.Point(544, 152)
        Me.btnModif.Name = "btnModif"
        Me.btnModif.Size = New System.Drawing.Size(72, 24)
        Me.btnModif.TabIndex = 2
        Me.btnModif.Text = "Modificar"
        '
        'txtGar2
        '
        Me.txtGar2.Location = New System.Drawing.Point(16, 48)
        Me.txtGar2.Name = "txtGar2"
        Me.txtGar2.ReadOnly = True
        Me.txtGar2.Size = New System.Drawing.Size(600, 20)
        Me.txtGar2.TabIndex = 1
        Me.txtGar2.TabStop = False
        '
        'txtGar1
        '
        Me.txtGar1.Location = New System.Drawing.Point(16, 24)
        Me.txtGar1.Name = "txtGar1"
        Me.txtGar1.ReadOnly = True
        Me.txtGar1.Size = New System.Drawing.Size(600, 20)
        Me.txtGar1.TabIndex = 0
        Me.txtGar1.TabStop = False
        '
        'btnCaratula
        '
        Me.btnCaratula.Location = New System.Drawing.Point(208, 112)
        Me.btnCaratula.Name = "btnCaratula"
        Me.btnCaratula.Size = New System.Drawing.Size(96, 23)
        Me.btnCaratula.TabIndex = 23
        Me.btnCaratula.Text = "Caratula"
        '
        'frmSeguicre
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(664, 550)
        Me.Controls.Add(Me.btnCaratula)
        Me.Controls.Add(Me.gbGarantias)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.lblEncab)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.btnAnalisis)
        Me.Controls.Add(Me.btnGaran)
        Me.Controls.Add(Me.btnSegui)
        Me.Controls.Add(Me.ListBox1)
        Me.Name = "frmSeguicre"
        Me.Text = "Seguimiento de Crédito"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.gbGarantias.ResumeLayout(False)
        Me.gbGarantias.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub frmSeguicre_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daSolic As New SqlDataAdapter(cm1)
        Dim dsAgil As New DataSet()
        Dim drSolic As DataRow
        Dim drSolics As DataRowCollection

        ' Declaración de variables de datos

        Dim cCliente As String
        Dim cSolicitud As String
        Dim cDisposicion As String
        Dim cContrato As String

        cCliente = txtCliente.Text
        myIdentity = GetCurrent()
        cUsuario = myIdentity.Name

        If cUsuario = "AGIL\geraldo-garcia" Or cUsuario = "AGIL\fermin-moctezuma" Or cUsuario = "AGIL\avelina-rojas" Or cUsuario = "AGIL\veronica-gomez" Then
            btnSegui.Enabled = True
        Else
            btnSegui.Enabled = False
        End If

        ' El siguiente Stored Procedure trae todos las solicitudes de la tabla Detsol,
        ' para un cliente dado.

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Contsoli1"
            .Connection = cnAgil
            .Parameters.Add("@Cliente", SqlDbType.NVarChar)
            .Parameters(0).Value = cCliente
        End With

        Try

            ' Llenar el DataSet lo cual abre y cierra la conexión

            daSolic.Fill(dsAgil, "Solicitud")

            drSolics = dsAgil.Tables("Solicitud").Rows

            Panel1.Visible = False

            If dsAgil.Tables("Solicitud").Rows.Count > 0 Then

                ListBox1.Items.Clear()
                For Each drSolic In drSolics
                    cSolicitud = drSolic("Solicitud")
                    cDisposicion = drSolic("Disposicion")
                    cContrato = drSolic("Contrato")
                    ListBox1.Items.Add(cSolicitud & "     " & cDisposicion & "             " & cContrato)
                Next
            Else
                MsgBox("No existen Solicitudes para este Cliente", MsgBoxStyle.Information, "Mensaje")
            End If

        Catch eException As Exception

            MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")

        End Try

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub btnSegui_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSegui.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daDatossol As New SqlDataAdapter(cm1)
        Dim dsAgil As New DataSet()
        Dim drDatosso As DataRow

        ' Declaración de variables de datos

        Dim cSoli As String
        Dim cDisp As String
        Dim cDicta As String

        If ListBox1.SelectedItem = Nothing Then
            MsgBox("Hay que seleccionar una Solicitud para ver sus datos", MsgBoxStyle.Information, "Mensaje")
        Else
            cSoli = Mid(ListBox1.Items(ListBox1.SelectedIndex), 1, 6)
            cDisp = Mid(ListBox1.Items(ListBox1.SelectedIndex), 12, 3)

            ' El siguiente Stored Procedure trae todos las solicitudes de la tabla Detsol,
            ' para un cliente dado.

            With cm1
                .CommandType = CommandType.StoredProcedure
                .CommandText = "Solicitudes1"
                .Connection = cnAgil
                .Parameters.Add("@Solicitud", SqlDbType.NVarChar)
                .Parameters(0).Value = cSoli
                .Parameters.Add("@Disposicion", SqlDbType.NVarChar)
                .Parameters(1).Value = cDisp
            End With

            Try

                daDatossol.Fill(dsAgil, "Datossol")
                drDatosso = dsAgil.Tables("Datossol").Rows(0)

                Panel1.Visible = True

                txtSoli.Text = drDatosso("Solicitud")
                txtCte.Text = drDatosso("Cliente")
                txtName.Text = drDatosso("Descr")
                cbStatu.SelectedText = drDatosso("Statu") & "   " & drDatosso("DescSituacion")
                Select Case drDatosso("Dicta")
                    Case "A"
                        cDicta = "AUTORIZADO"
                    Case "R"
                        cDicta = "RECHAZADO"
                    Case " "
                        cDicta = "PENDIENTE"
                End Select
                cbDicta.SelectedText = cDicta
                DateTimePicker1.Value = CTOD(drDatosso("Fecdi"))
                txtFecre.Text = CTOD(drDatosso("Fecre"))
                DateTimePicker2.Value = CTOD(drDatosso("Feaut"))
                txtLineau.Text = FormatNumber(drDatosso("Linau"))
                DateTimePicker3.Value = CTOD(drDatosso("Fevig"))

                If cUsuario = "AGIL\geraldo-garcia" Or cUsuario = "AGIL\fermin-moctezuma" Or cUsuario = "AGIL\avelina-rojas" Then
                    btnSegui.Enabled = False
                End If
                btnGaran.Enabled = False
                btnCaratula.Enabled = False
                btnAnalisis.Enabled = False
                btnSalir.Enabled = False
                btnCambio.Enabled = True
                btnSalvar.Enabled = True

            Catch eException As Exception

                MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")

            End Try

        End If

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub btnCambio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCambio.Click
        cbStatu.Enabled = True
        cbDicta.Enabled = True
        DateTimePicker1.Enabled = True
        DateTimePicker2.Enabled = True
        DateTimePicker3.Enabled = True
        btnCambio.Enabled = False
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If cUsuario = "AGIL\geraldo-garcia" Or cUsuario = "AGIL\fermin-moctezuma" Or cUsuario = "AGIL\avelina-rojas" Then
            btnSegui.Enabled = False
        End If
        btnGaran.Enabled = True
        btnCaratula.Enabled = True
        btnAnalisis.Enabled = True
        btnAmplia.Enabled = True
        btnSalir.Enabled = True
        cbStatu.Enabled = False
        cbDicta.Enabled = False
        DateTimePicker1.Enabled = False
        DateTimePicker2.Enabled = False
        DateTimePicker3.Enabled = False
        Panel1.Visible = False
    End Sub

    Private Sub btnSalvar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalvar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim strActualiza As String

        ' Declaración de variables de datos

        Dim cDicta As String
        Dim cStatu As String

        Select Case cbStatu.SelectedIndex.ToString
            Case "0"
                cStatu = "1"
            Case "1"
                cStatu = "2"
            Case "2"
                cStatu = "3"
            Case "3"
                cStatu = "4"
            Case "4"
                cStatu = "5"
            Case "5"
                cStatu = "6"
        End Select

        Select Case cbDicta.SelectedIndex.ToString
            Case "0"
                cDicta = "A"
            Case "1"
                cDicta = "R"
            Case "2"
                cDicta = " "
        End Select

        cbStatu.Enabled = False
        cbDicta.Enabled = False
        DateTimePicker1.Enabled = False
        DateTimePicker2.Enabled = False
        DateTimePicker3.Enabled = False

        Try

            strActualiza = "UPDATE Credit SET Dicta = " & "'" & cDicta & "'," & _
                                              " Statu = " & "'" & cStatu & "'," & _
                                              " Fecdi = " & "'" & DTOC(DateTimePicker1.Value) & "'," & _
                                              " Feaut = " & "'" & DTOC(DateTimePicker2.Value) & "'," & _
                                              " Fevig = " & "'" & DTOC(DateTimePicker3.Value) & "'" & _
                                              "WHERE Solicitud = " & "'" & txtSoli.Text & "'"
            cm1 = New SqlCommand(strActualiza, cnAgil)
            cnAgil.Open()
            cm1.ExecuteNonQuery()
            cnAgil.Close()

        Catch eException As Exception

            MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de error")

        End Try

        btnSalvar.Enabled = False

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub btnGaran_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGaran.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daDatossol As New SqlDataAdapter(cm1)
        Dim dsAgil As New DataSet()
        Dim drDatosso As DataRow

        ' Declaración de variables de datos

        Dim cSoli As String
        Dim cDisp As String
        Dim cDicta As String

        If ListBox1.SelectedItem = Nothing Then

            MsgBox("Hay que seleccionar una Solicitud para ver sus datos", MsgBoxStyle.Information, "Mensaje")

        Else

            cSoli = Mid(ListBox1.Items(ListBox1.SelectedIndex), 1, 6)
            cDisp = Mid(ListBox1.Items(ListBox1.SelectedIndex), 12, 3)

            ' El siguiente Stored Procedure trae todos las solicitudes de la tabla Detsol,
            ' para un cliente dado.

            With cm1
                .CommandType = CommandType.StoredProcedure
                .CommandText = "Solicitudes1"
                .Connection = cnAgil
                .Parameters.Add("@Solicitud", SqlDbType.NVarChar)
                .Parameters(0).Value = cSoli
                .Parameters.Add("@Disposicion", SqlDbType.NVarChar)
                .Parameters(1).Value = cDisp
            End With

            Try

                daDatossol.Fill(dsAgil, "Datossol")
                drDatosso = dsAgil.Tables("Datossol").Rows(0)

                gbGarantias.Visible = True
                gbGarantias.Text = "Garantías de la solicitud " & cSoli
                txtSoli.Text = drDatosso("Solicitud")
                txtGar1.Text = drDatosso("Gar01")
                txtGar2.Text = drDatosso("Gar02")

                If cUsuario = "AGIL\geraldo-garcia" Or cUsuario = "AGIL\fermin-moctezuma" Or cUsuario = "AGIL\avelina-rojas" Then
                    btnSegui.Enabled = False
                End If
                btnGaran.Enabled = False
                btnCaratula.Enabled = False
                btnAnalisis.Enabled = False
                btnAmplia.Enabled = False
                btnSalir.Enabled = False

                btnModif.Enabled = True
                btnGuarda.Enabled = True

            Catch eException As Exception

                MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")

            End Try

        End If

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub btnRetorna_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRetorna.Click
        If cUsuario = "AGIL\geraldo-garcia" Or cUsuario = "AGIL\fermin-moctezuma" Or cUsuario = "AGIL\avelina-rojas" Then
            btnSegui.Enabled = False
        End If
        btnGaran.Enabled = True
        btnCaratula.Enabled = True
        btnAnalisis.Enabled = True
        btnAmplia.Enabled = True
        btnSalir.Enabled = True
        txtGar1.ReadOnly = True
        txtGar2.ReadOnly = True
        gbGarantias.Visible = False
    End Sub

    Private Sub btnModif_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModif.Click
        txtGar1.ReadOnly = False
        txtGar2.ReadOnly = False
        btnModif.Enabled = False
    End Sub

    Private Sub btnGuarda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuarda.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim strActualiza As String

        txtGar1.ReadOnly = True
        txtGar2.ReadOnly = True

        Try

            strActualiza = "UPDATE Credit SET Gar01 = " & "'" & txtGar1.Text & "'," & _
                                                            " Gar02 = " & "'" & txtGar2.Text & "'" & _
                                                            "WHERE Solicitud = " & "'" & txtSoli.Text & "'"
            cm1 = New SqlCommand(strActualiza, cnAgil)
            cnAgil.Open()
            cm1.ExecuteNonQuery()
            cnAgil.Close()

        Catch eException As Exception

            MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de error")

        End Try

        btnGuarda.Enabled = False

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub btnAnalisis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnalisis.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daCliente As New SqlDataAdapter(cm1)
        Dim dsAgil As New DataSet()
        Dim drCliente As DataRow

        ' Declaración de variables de datos

        Dim cCusnam As String
        Dim cSolicitud As String
        Dim cDisposicion As String
        Dim cTipo As String
        Dim nPlazo As Integer
        Dim nSdoInsol As Decimal
        Dim nTasaApli As Decimal
        Dim nMensu As Decimal

        ' Declaración de variables de Excel

        Dim xlsApplication As Excel.Application
        Dim xlsWorkbook As Excel.Workbook
        Dim xlsWorksheet As Excel.Worksheet
        Dim xlsRange As Excel.Range

        If ListBox1.SelectedItem = Nothing Then

            MsgBox("Hay que seleccionar una Solicitud para modificar sus datos", MsgBoxStyle.Information, "Mensaje")

        Else

            cSolicitud = Mid(ListBox1.Items(ListBox1.SelectedIndex), 1, 6)
            cDisposicion = Mid(ListBox1.Items(ListBox1.SelectedIndex), 12, 3)

            With cm1
                .CommandType = CommandType.StoredProcedure
                .CommandText = "DatosCred1"
                .Connection = cnAgil
                .Parameters.Add("@Solicitud", SqlDbType.NVarChar)
                .Parameters(0).Value = cSolicitud
                .Parameters.Add("@Disposicion", SqlDbType.NVarChar)
                .Parameters(1).Value = cDisposicion
            End With
            daCliente.Fill(dsAgil, "Tipo")

            drCliente = dsAgil.Tables("Tipo").Rows(0)
            cTipo = drCliente("Tipo")
            cCusnam = drCliente("Descr")
            nPlazo = drCliente("Plazo")
            nTasaApli = Round((drCliente("Tasas") + drCliente("Difer")) / 1200, 2)
            nSdoInsol = drCliente("Impeq") - drCliente("Ivaeq")
            nMensu = drCliente("Mensu")

            Try
                If File.Exists("C:\Credito\" & cSolicitud & ".xls") = True Then
                    xlsApplication = New Excel.Application
                    xlsWorkbook = xlsApplication.Workbooks.Open("C:\Credito\" & cSolicitud & ".xls")
                Else
                    If cTipo = "F" Then
                        xlsApplication = New Excel.Application
                        xlsWorkbook = xlsApplication.Workbooks.Open("C:\Credito\AnaliFis.xls")
                        xlsWorksheet = xlsWorkbook.Worksheets(1)
                        xlsRange = xlsWorksheet.Range("A7", Type.Missing)
                        xlsRange.Value = "NOMBRE   :  " & cCusnam
                        xlsRange = xlsWorksheet.Range("A8", Type.Missing)
                        xlsRange.Value = "SOLICITUD:  " & cSolicitud
                        xlsRange = xlsWorksheet.Range("A3", Type.Missing)
                        xlsRange.Value = nMensu
                        xlsRange = xlsWorksheet.Range("B3", Type.Missing)
                        xlsRange.Value = nPlazo
                        xlsRange = xlsWorksheet.Range("D3", Type.Missing)
                        xlsRange.Value = nSdoInsol
                        xlsRange = xlsWorksheet.Range("E3", Type.Missing)
                        xlsRange.Value = nTasaApli
                    Else
                        xlsApplication = New Excel.Application
                        xlsWorkbook = xlsApplication.Workbooks.Open("C:\Credito\AnaliMor.xls")
                        xlsWorksheet = xlsWorkbook.Worksheets(1)
                        xlsRange = xlsWorksheet.Range("A7", Type.Missing)
                        xlsRange.Value = "NOMBRE   :  " & cCusnam
                        xlsRange = xlsWorksheet.Range("A8", Type.Missing)
                        xlsRange.Value = "SOLICITUD:  " & cSolicitud
                    End If
                    xlsWorkbook.SaveAs("C:\Credito\" & cSolicitud & ".xls")
                End If
                xlsApplication.Visible = True
            Catch eException As Exception
                MsgBox(eException.Message, MsgBoxStyle.Critical, eException.Source)
            End Try

        End If

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub btnCaratula_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCaratula.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim daDatoscar As New SqlDataAdapter(cm1)
        Dim daAnexos As New SqlDataAdapter(cm2)
        Dim daSaldos As New SqlDataAdapter(cm3)
        Dim dsAgil As New DataSet()
        Dim drAnexo As DataRow
        Dim drDato As DataRow
        Dim drAnexos As DataRowCollection
        Dim dtDatos As New DataTable("Datos")

        ' Declaración de variables de datos

        Dim cSoli As String
        Dim cDisp As String
        Dim cDicta As String
        Dim cCliente As String
        Dim cAnexo As String
        Dim cFecha As String
        Dim nTer As Int32
        Dim nAct As Int32
        Dim nCan As Int32
        Dim nSdoInsoluto As Decimal

        ' Declaración de variables de Crystal Reports

        Dim newfrmCaratula As frmCaratula

        If ListBox1.SelectedItem = Nothing Then

            MsgBox("Hay que seleccionar una Solicitud para ver sus datos", MsgBoxStyle.Information, "Mensaje")

        Else

            cSoli = Mid(ListBox1.Items(ListBox1.SelectedIndex), 1, 6)
            cDisp = Mid(ListBox1.Items(ListBox1.SelectedIndex), 12, 3)
            cCliente = txtCliente.Text
            cFecha = DTOC(Today)

            ' El siguiente Stored Procedure trae los datos para llenar la caratula de
            ' resolución de crédito

            With cm1
                .CommandType = CommandType.StoredProcedure
                .CommandText = "DatosCred1"
                .Connection = cnAgil
                .Parameters.Add("@Solicitud", SqlDbType.NVarChar)
                .Parameters.Add("@Disposicion", SqlDbType.NVarChar)
                .Parameters(0).Value = cSoli
                .Parameters(1).Value = cDisp
            End With

            With cm2
                .CommandType = CommandType.StoredProcedure
                .CommandText = "PideAnex2"
                .Connection = cnAgil
                .Parameters.Add("@Cliente", SqlDbType.NVarChar)
                .Parameters(0).Value = cCliente
            End With

            Try

                ' Buscar a dicho cliente en el DataSet y retornar sus datos en el DataRow

                daAnexos.Fill(dsAgil, "Anexos")
                drAnexos = dsAgil.Tables("Anexos").Rows

                nAct = 0
                nCan = 0
                nTer = 0
                nSdoInsoluto = 0

                'Crear tabla temporal para integrar los siguientes datso

                dtDatos.Columns.Add("Activos", Type.GetType("System.String"))
                dtDatos.Columns.Add("Cancelados", Type.GetType("System.String"))
                dtDatos.Columns.Add("Terminados", Type.GetType("System.String"))
                dtDatos.Columns.Add("SaldoInsol", Type.GetType("System.String"))

                For Each drAnexo In drAnexos
                    cAnexo = drAnexo("Anexo")
                    Select Case drAnexo("Flcan")
                        Case "A"
                            nAct = nAct + 1
                            nSdoInsoluto = AcumulaSdo(cAnexo, cFecha) + nSdoInsoluto
                        Case "T"
                            nTer = nTer + 1
                        Case "C"
                            nCan = nCan + 1
                    End Select
                Next
                drDato = dtDatos.NewRow()
                drDato("Activos") = FormatNumber(nAct.ToString, 0)
                drDato("Cancelados") = FormatNumber(nCan.ToString, 0)
                drDato("Terminados") = FormatNumber(nTer.ToString, 0)
                drDato("SaldoInsol") = FormatNumber(nSdoInsoluto.ToString, 2)
                dtDatos.Rows.Add(drDato)

                dsAgil.Tables.Remove("Anexos")
                daDatoscar.Fill(dsAgil, "Datcred")
                dsAgil.Tables.Add(dtDatos)
                dsAgil.WriteXml("C:\Schema12.xml", XmlWriteMode.WriteSchema)

                newfrmCaratula = New frmCaratula()
                newfrmCaratula.Show()

            Catch eException As Exception

                MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")

            End Try

        End If

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()
        cm3.Dispose()

    End Sub

    Private Sub btnAmplia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAmplia.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daDatossol As New SqlDataAdapter(cm1)
        Dim dsAgil As New DataSet()
        Dim drDatosso As DataRow

        ' Declaración de variables de datos

        Dim cSoli As String
        Dim nLinau As Decimal

        If ListBox1.SelectedItem = Nothing Then

            MsgBox("Hay que seleccionar una Solicitud para ver sus datos", MsgBoxStyle.Information, "Mensaje")

        Else

            cSoli = Mid(ListBox1.Items(ListBox1.SelectedIndex), 1, 6)

            ' Con esta indicación se trae el importe de la linea autorizada para la
            ' solicitud especificada.

            With cm1
                .CommandType = CommandType.Text
                .CommandText = "SELECT Linau FROM Credit WHERE Solicitud = " & "'" & cSoli & "'"
                .Connection = cnAgil
            End With

            Try

                daDatossol.Fill(dsAgil, "Linau")
                drDatosso = dsAgil.Tables("Linau").Rows(0)

                nLinau = drDatosso("Linau")

                txtLinau.Text = nLinau

                btnAmplia.Enabled = False
                btnCambio.Enabled = False
                btnSalvar.Enabled = False
                btnCancelar.Enabled = False
                btnSave.Enabled = True
                txtLinau.Enabled = True

            Catch eException As Exception

                MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")

            End Try

        End If

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim strActualiza As String

        ' Declaración de variables de datos

        Dim cSoli As String

        cSoli = Mid(ListBox1.Items(ListBox1.SelectedIndex), 1, 6)

        Try

            strActualiza = "UPDATE Credit SET Linau = " & "'" & txtLinau.Text & "'" & _
                           "WHERE Solicitud = " & "'" & cSoli & "'"
            cm1 = New SqlCommand(strActualiza, cnAgil)
            cnAgil.Open()
            cm1.ExecuteNonQuery()
            cnAgil.Close()

        Catch eException As Exception

            MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de error")

        End Try

        btnCambio.Enabled = True
        btnSalvar.Enabled = True
        btnAmplia.Enabled = True
        btnCancelar.Enabled = True
        btnSave.Enabled = False
        txtLinau.Enabled = False

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class
