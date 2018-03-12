Option Explicit On 

Imports System.Data.SqlClient
Imports System.Math
Imports System.Security
Imports System.Security.Principal.WindowsIdentity

Public Class frmDatosCon

    Inherits System.Windows.Forms.Form
    Dim myIdentity As Principal.WindowsIdentity
    Dim cUsuario As String

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal cAnexo As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Text = "Datos del Contrato " & cAnexo
        lblAnexo.Text = cAnexo
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
    Friend WithEvents lblNumc As System.Windows.Forms.Label
    Friend WithEvents lblFechac As System.Windows.Forms.Label
    Friend WithEvents lblFechaven1 As System.Windows.Forms.Label
    Friend WithEvents txtFechacon As System.Windows.Forms.TextBox
    Friend WithEvents txtFvenc As System.Windows.Forms.TextBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents lblFechafin As System.Windows.Forms.Label
    Friend WithEvents lblIva As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTasai As System.Windows.Forms.Label
    Friend WithEvents lblDifer As System.Windows.Forms.Label
    Friend WithEvents lblCriteriotasa As System.Windows.Forms.Label
    Friend WithEvents lblFrecpag As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblRecursos As System.Windows.Forms.Label
    Friend WithEvents txtFondeo As System.Windows.Forms.TextBox
    Friend WithEvents lblEqmap As System.Windows.Forms.Label
    Friend WithEvents lblTipotasa As System.Windows.Forms.Label
    Friend WithEvents gpoPagos As System.Windows.Forms.GroupBox
    Friend WithEvents gpoPagosi As System.Windows.Forms.GroupBox
    Friend WithEvents lblComis As System.Windows.Forms.Label
    Friend WithEvents lblImpDG As System.Windows.Forms.Label
    Friend WithEvents lblIvag As System.Windows.Forms.Label
    Friend WithEvents lblRatific As System.Windows.Forms.Label
    Friend WithEvents lblNafin As System.Windows.Forms.Label
    Friend WithEvents lblTotalpagos As System.Windows.Forms.Label
    Friend WithEvents txtComis As System.Windows.Forms.TextBox
    Friend WithEvents txtNafin As System.Windows.Forms.TextBox
    Friend WithEvents lblSeg As System.Windows.Forms.Label
    Friend WithEvents lblPlazos As System.Windows.Forms.Label
    Friend WithEvents lblMontos As System.Windows.Forms.Label
    Friend WithEvents lblMontof As System.Windows.Forms.Label
    Friend WithEvents lblOpcom As System.Windows.Forms.Label
    Friend WithEvents lblIvaeq As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents lblPlazo As System.Windows.Forms.Label
    Friend WithEvents txtPlazo As System.Windows.Forms.TextBox
    Friend WithEvents txtIvaeq As System.Windows.Forms.TextBox
    Friend WithEvents lblGaran As System.Windows.Forms.Label
    Friend WithEvents btnDatoseq As System.Windows.Forms.Button
    Friend WithEvents btnReferencia As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents txtTermina As System.Windows.Forms.TextBox
    Friend WithEvents txtDescTipar As System.Windows.Forms.TextBox
    Friend WithEvents txtPorieq As System.Windows.Forms.TextBox
    Friend WithEvents txtPorco As System.Windows.Forms.TextBox
    Friend WithEvents txtPorop As System.Windows.Forms.TextBox
    Friend WithEvents txtTasas As System.Windows.Forms.TextBox
    Friend WithEvents txtDifer As System.Windows.Forms.TextBox
    Friend WithEvents txtCritas As System.Windows.Forms.TextBox
    Friend WithEvents txtFrecuencia As System.Windows.Forms.TextBox
    Friend WithEvents txtForca As System.Windows.Forms.TextBox
    Friend WithEvents txtPrenda As System.Windows.Forms.TextBox
    Friend WithEvents txtImpDG As System.Windows.Forms.TextBox
    Friend WithEvents txtIvaDG As System.Windows.Forms.TextBox
    Friend WithEvents txtGastos As System.Windows.Forms.TextBox
    Friend WithEvents txtImpEq As System.Windows.Forms.TextBox
    Friend WithEvents txtFinse As System.Windows.Forms.TextBox
    Friend WithEvents txtPlaseg As System.Windows.Forms.TextBox
    Friend WithEvents txtSaldoSeguro As System.Windows.Forms.TextBox
    Friend WithEvents txtOpcion As System.Windows.Forms.TextBox
    Friend WithEvents txtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents btnDatosCliente As System.Windows.Forms.Button
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents btnTablaEquipo As System.Windows.Forms.Button
    Friend WithEvents btnTablaSeguro As System.Windows.Forms.Button
    Friend WithEvents btnHistoria As System.Windows.Forms.Button
    Friend WithEvents txtMontoFinanciado As System.Windows.Forms.TextBox
    Friend WithEvents txtDescTasa As System.Windows.Forms.TextBox
    Friend WithEvents txtPagosIniciales As System.Windows.Forms.TextBox
    Friend WithEvents txtIvaAmorin As System.Windows.Forms.TextBox
    Friend WithEvents txtAmorin As System.Windows.Forms.TextBox
    Friend WithEvents lblIvaamortiza As System.Windows.Forms.Label
    Friend WithEvents lblAmortiza As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblAnexo As System.Windows.Forms.Label
    Friend WithEvents txtImpRD As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnTablaOtros As System.Windows.Forms.Button
    Friend WithEvents txtIvaRD As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblDescr As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtPrenda = New System.Windows.Forms.TextBox
        Me.lblGaran = New System.Windows.Forms.Label
        Me.gpoPagosi = New System.Windows.Forms.GroupBox
        Me.txtIvaRD = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtImpRD = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtIvaAmorin = New System.Windows.Forms.TextBox
        Me.txtAmorin = New System.Windows.Forms.TextBox
        Me.lblIvaamortiza = New System.Windows.Forms.Label
        Me.lblAmortiza = New System.Windows.Forms.Label
        Me.txtPagosIniciales = New System.Windows.Forms.TextBox
        Me.txtNafin = New System.Windows.Forms.TextBox
        Me.txtGastos = New System.Windows.Forms.TextBox
        Me.txtIvaDG = New System.Windows.Forms.TextBox
        Me.txtImpDG = New System.Windows.Forms.TextBox
        Me.txtComis = New System.Windows.Forms.TextBox
        Me.lblTotalpagos = New System.Windows.Forms.Label
        Me.lblNafin = New System.Windows.Forms.Label
        Me.lblRatific = New System.Windows.Forms.Label
        Me.lblIvag = New System.Windows.Forms.Label
        Me.lblImpDG = New System.Windows.Forms.Label
        Me.lblComis = New System.Windows.Forms.Label
        Me.gpoPagos = New System.Windows.Forms.GroupBox
        Me.txtMontoFinanciado = New System.Windows.Forms.TextBox
        Me.txtOpcion = New System.Windows.Forms.TextBox
        Me.txtSaldoSeguro = New System.Windows.Forms.TextBox
        Me.txtPlaseg = New System.Windows.Forms.TextBox
        Me.txtFinse = New System.Windows.Forms.TextBox
        Me.txtIvaeq = New System.Windows.Forms.TextBox
        Me.txtImpEq = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.lblIvaeq = New System.Windows.Forms.Label
        Me.lblOpcom = New System.Windows.Forms.Label
        Me.lblMontof = New System.Windows.Forms.Label
        Me.lblMontos = New System.Windows.Forms.Label
        Me.lblPlazos = New System.Windows.Forms.Label
        Me.lblSeg = New System.Windows.Forms.Label
        Me.txtPlazo = New System.Windows.Forms.TextBox
        Me.lblPlazo = New System.Windows.Forms.Label
        Me.txtDescTasa = New System.Windows.Forms.TextBox
        Me.lblTipotasa = New System.Windows.Forms.Label
        Me.txtForca = New System.Windows.Forms.TextBox
        Me.lblEqmap = New System.Windows.Forms.Label
        Me.txtFondeo = New System.Windows.Forms.TextBox
        Me.lblRecursos = New System.Windows.Forms.Label
        Me.txtFrecuencia = New System.Windows.Forms.TextBox
        Me.txtCritas = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtDifer = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtTasas = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtPorop = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtPorco = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtPorieq = New System.Windows.Forms.TextBox
        Me.txtDescTipar = New System.Windows.Forms.TextBox
        Me.txtTermina = New System.Windows.Forms.TextBox
        Me.lblFrecpag = New System.Windows.Forms.Label
        Me.lblCriteriotasa = New System.Windows.Forms.Label
        Me.lblDifer = New System.Windows.Forms.Label
        Me.lblTasai = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblIva = New System.Windows.Forms.Label
        Me.lblFechafin = New System.Windows.Forms.Label
        Me.txtFvenc = New System.Windows.Forms.TextBox
        Me.txtFechacon = New System.Windows.Forms.TextBox
        Me.lblFechaven1 = New System.Windows.Forms.Label
        Me.lblFechac = New System.Windows.Forms.Label
        Me.lblTipo = New System.Windows.Forms.Label
        Me.lblNumc = New System.Windows.Forms.Label
        Me.btnDatosCliente = New System.Windows.Forms.Button
        Me.btnDatoseq = New System.Windows.Forms.Button
        Me.btnReferencia = New System.Windows.Forms.Button
        Me.btnSalir = New System.Windows.Forms.Button
        Me.txtReferencia = New System.Windows.Forms.TextBox
        Me.txtCliente = New System.Windows.Forms.TextBox
        Me.btnTablaEquipo = New System.Windows.Forms.Button
        Me.btnTablaSeguro = New System.Windows.Forms.Button
        Me.btnHistoria = New System.Windows.Forms.Button
        Me.lblStatus = New System.Windows.Forms.Label
        Me.lblAnexo = New System.Windows.Forms.Label
        Me.lblDescr = New System.Windows.Forms.Label
        Me.btnTablaOtros = New System.Windows.Forms.Button
        Me.gpoPagosi.SuspendLayout()
        Me.gpoPagos.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtPrenda
        '
        Me.txtPrenda.Location = New System.Drawing.Point(144, 416)
        Me.txtPrenda.Name = "txtPrenda"
        Me.txtPrenda.ReadOnly = True
        Me.txtPrenda.Size = New System.Drawing.Size(16, 20)
        Me.txtPrenda.TabIndex = 51
        Me.txtPrenda.TabStop = False
        '
        'lblGaran
        '
        Me.lblGaran.Location = New System.Drawing.Point(16, 416)
        Me.lblGaran.Name = "lblGaran"
        Me.lblGaran.Size = New System.Drawing.Size(120, 16)
        Me.lblGaran.TabIndex = 50
        Me.lblGaran.Text = "Garantía Prendaria ?"
        Me.lblGaran.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpoPagosi
        '
        Me.gpoPagosi.Controls.Add(Me.txtIvaRD)
        Me.gpoPagosi.Controls.Add(Me.Label8)
        Me.gpoPagosi.Controls.Add(Me.txtImpRD)
        Me.gpoPagosi.Controls.Add(Me.Label7)
        Me.gpoPagosi.Controls.Add(Me.txtIvaAmorin)
        Me.gpoPagosi.Controls.Add(Me.txtAmorin)
        Me.gpoPagosi.Controls.Add(Me.lblIvaamortiza)
        Me.gpoPagosi.Controls.Add(Me.lblAmortiza)
        Me.gpoPagosi.Controls.Add(Me.txtPagosIniciales)
        Me.gpoPagosi.Controls.Add(Me.txtNafin)
        Me.gpoPagosi.Controls.Add(Me.txtGastos)
        Me.gpoPagosi.Controls.Add(Me.txtIvaDG)
        Me.gpoPagosi.Controls.Add(Me.txtImpDG)
        Me.gpoPagosi.Controls.Add(Me.txtComis)
        Me.gpoPagosi.Controls.Add(Me.lblTotalpagos)
        Me.gpoPagosi.Controls.Add(Me.lblNafin)
        Me.gpoPagosi.Controls.Add(Me.lblRatific)
        Me.gpoPagosi.Controls.Add(Me.lblIvag)
        Me.gpoPagosi.Controls.Add(Me.lblImpDG)
        Me.gpoPagosi.Controls.Add(Me.lblComis)
        Me.gpoPagosi.Location = New System.Drawing.Point(384, 239)
        Me.gpoPagosi.Name = "gpoPagosi"
        Me.gpoPagosi.Size = New System.Drawing.Size(264, 273)
        Me.gpoPagosi.TabIndex = 49
        Me.gpoPagosi.TabStop = False
        Me.gpoPagosi.Text = "Pagos Iniciales"
        '
        'txtIvaRD
        '
        Me.txtIvaRD.Location = New System.Drawing.Point(168, 216)
        Me.txtIvaRD.Name = "txtIvaRD"
        Me.txtIvaRD.ReadOnly = True
        Me.txtIvaRD.Size = New System.Drawing.Size(88, 20)
        Me.txtIvaRD.TabIndex = 85
        Me.txtIvaRD.TabStop = False
        Me.txtIvaRD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(8, 216)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(156, 16)
        Me.Label8.TabIndex = 84
        Me.Label8.Text = "I.V.A. Rentas en Depósito"
        '
        'txtImpRD
        '
        Me.txtImpRD.Location = New System.Drawing.Point(168, 192)
        Me.txtImpRD.Name = "txtImpRD"
        Me.txtImpRD.ReadOnly = True
        Me.txtImpRD.Size = New System.Drawing.Size(88, 20)
        Me.txtImpRD.TabIndex = 83
        Me.txtImpRD.TabStop = False
        Me.txtImpRD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(8, 192)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(156, 16)
        Me.Label7.TabIndex = 82
        Me.Label7.Text = "Rentas en Depósito"
        '
        'txtIvaAmorin
        '
        Me.txtIvaAmorin.Location = New System.Drawing.Point(168, 48)
        Me.txtIvaAmorin.Name = "txtIvaAmorin"
        Me.txtIvaAmorin.ReadOnly = True
        Me.txtIvaAmorin.Size = New System.Drawing.Size(88, 20)
        Me.txtIvaAmorin.TabIndex = 81
        Me.txtIvaAmorin.TabStop = False
        Me.txtIvaAmorin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAmorin
        '
        Me.txtAmorin.Location = New System.Drawing.Point(168, 24)
        Me.txtAmorin.Name = "txtAmorin"
        Me.txtAmorin.ReadOnly = True
        Me.txtAmorin.Size = New System.Drawing.Size(88, 20)
        Me.txtAmorin.TabIndex = 80
        Me.txtAmorin.TabStop = False
        Me.txtAmorin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblIvaamortiza
        '
        Me.lblIvaamortiza.Location = New System.Drawing.Point(8, 48)
        Me.lblIvaamortiza.Name = "lblIvaamortiza"
        Me.lblIvaamortiza.Size = New System.Drawing.Size(156, 16)
        Me.lblIvaamortiza.TabIndex = 79
        Me.lblIvaamortiza.Text = "I.V.A. de la Amortización"
        '
        'lblAmortiza
        '
        Me.lblAmortiza.Location = New System.Drawing.Point(8, 24)
        Me.lblAmortiza.Name = "lblAmortiza"
        Me.lblAmortiza.Size = New System.Drawing.Size(156, 16)
        Me.lblAmortiza.TabIndex = 78
        Me.lblAmortiza.Text = "Amortización Inicial"
        '
        'txtPagosIniciales
        '
        Me.txtPagosIniciales.Location = New System.Drawing.Point(168, 240)
        Me.txtPagosIniciales.Name = "txtPagosIniciales"
        Me.txtPagosIniciales.ReadOnly = True
        Me.txtPagosIniciales.Size = New System.Drawing.Size(88, 20)
        Me.txtPagosIniciales.TabIndex = 64
        Me.txtPagosIniciales.TabStop = False
        Me.txtPagosIniciales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNafin
        '
        Me.txtNafin.Location = New System.Drawing.Point(168, 168)
        Me.txtNafin.Name = "txtNafin"
        Me.txtNafin.ReadOnly = True
        Me.txtNafin.Size = New System.Drawing.Size(88, 20)
        Me.txtNafin.TabIndex = 62
        Me.txtNafin.TabStop = False
        Me.txtNafin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGastos
        '
        Me.txtGastos.Location = New System.Drawing.Point(168, 144)
        Me.txtGastos.Name = "txtGastos"
        Me.txtGastos.ReadOnly = True
        Me.txtGastos.Size = New System.Drawing.Size(88, 20)
        Me.txtGastos.TabIndex = 60
        Me.txtGastos.TabStop = False
        Me.txtGastos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIvaDG
        '
        Me.txtIvaDG.Location = New System.Drawing.Point(168, 120)
        Me.txtIvaDG.Name = "txtIvaDG"
        Me.txtIvaDG.ReadOnly = True
        Me.txtIvaDG.Size = New System.Drawing.Size(88, 20)
        Me.txtIvaDG.TabIndex = 58
        Me.txtIvaDG.TabStop = False
        Me.txtIvaDG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtImpDG
        '
        Me.txtImpDG.Location = New System.Drawing.Point(168, 96)
        Me.txtImpDG.Name = "txtImpDG"
        Me.txtImpDG.ReadOnly = True
        Me.txtImpDG.Size = New System.Drawing.Size(88, 20)
        Me.txtImpDG.TabIndex = 56
        Me.txtImpDG.TabStop = False
        Me.txtImpDG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtComis
        '
        Me.txtComis.Location = New System.Drawing.Point(168, 72)
        Me.txtComis.Name = "txtComis"
        Me.txtComis.ReadOnly = True
        Me.txtComis.Size = New System.Drawing.Size(88, 20)
        Me.txtComis.TabIndex = 54
        Me.txtComis.TabStop = False
        Me.txtComis.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalpagos
        '
        Me.lblTotalpagos.Location = New System.Drawing.Point(8, 240)
        Me.lblTotalpagos.Name = "lblTotalpagos"
        Me.lblTotalpagos.Size = New System.Drawing.Size(156, 16)
        Me.lblTotalpagos.TabIndex = 52
        Me.lblTotalpagos.Text = "Total de Pagos Iniciales"
        '
        'lblNafin
        '
        Me.lblNafin.Location = New System.Drawing.Point(8, 168)
        Me.lblNafin.Name = "lblNafin"
        Me.lblNafin.Size = New System.Drawing.Size(156, 16)
        Me.lblNafin.TabIndex = 51
        Me.lblNafin.Text = "5 % NAFIN"
        '
        'lblRatific
        '
        Me.lblRatific.Location = New System.Drawing.Point(8, 144)
        Me.lblRatific.Name = "lblRatific"
        Me.lblRatific.Size = New System.Drawing.Size(156, 16)
        Me.lblRatific.TabIndex = 50
        Me.lblRatific.Text = "Ratificación con I.V.A."
        '
        'lblIvag
        '
        Me.lblIvag.Location = New System.Drawing.Point(8, 120)
        Me.lblIvag.Name = "lblIvag"
        Me.lblIvag.Size = New System.Drawing.Size(156, 16)
        Me.lblIvag.TabIndex = 49
        Me.lblIvag.Text = "I.V.A. del Depósito"
        '
        'lblImpDG
        '
        Me.lblImpDG.Location = New System.Drawing.Point(8, 96)
        Me.lblImpDG.Name = "lblImpDG"
        Me.lblImpDG.Size = New System.Drawing.Size(156, 16)
        Me.lblImpDG.TabIndex = 48
        Me.lblImpDG.Text = "Depósito en Garantía"
        '
        'lblComis
        '
        Me.lblComis.Location = New System.Drawing.Point(8, 72)
        Me.lblComis.Name = "lblComis"
        Me.lblComis.Size = New System.Drawing.Size(156, 16)
        Me.lblComis.TabIndex = 47
        Me.lblComis.Text = "Comisión con I.V.A."
        '
        'gpoPagos
        '
        Me.gpoPagos.Controls.Add(Me.txtMontoFinanciado)
        Me.gpoPagos.Controls.Add(Me.txtOpcion)
        Me.gpoPagos.Controls.Add(Me.txtSaldoSeguro)
        Me.gpoPagos.Controls.Add(Me.txtPlaseg)
        Me.gpoPagos.Controls.Add(Me.txtFinse)
        Me.gpoPagos.Controls.Add(Me.txtIvaeq)
        Me.gpoPagos.Controls.Add(Me.txtImpEq)
        Me.gpoPagos.Controls.Add(Me.Label27)
        Me.gpoPagos.Controls.Add(Me.lblIvaeq)
        Me.gpoPagos.Controls.Add(Me.lblOpcom)
        Me.gpoPagos.Controls.Add(Me.lblMontof)
        Me.gpoPagos.Controls.Add(Me.lblMontos)
        Me.gpoPagos.Controls.Add(Me.lblPlazos)
        Me.gpoPagos.Controls.Add(Me.lblSeg)
        Me.gpoPagos.Location = New System.Drawing.Point(384, 32)
        Me.gpoPagos.Name = "gpoPagos"
        Me.gpoPagos.Size = New System.Drawing.Size(264, 192)
        Me.gpoPagos.TabIndex = 48
        Me.gpoPagos.TabStop = False
        '
        'txtMontoFinanciado
        '
        Me.txtMontoFinanciado.Location = New System.Drawing.Point(168, 160)
        Me.txtMontoFinanciado.Name = "txtMontoFinanciado"
        Me.txtMontoFinanciado.ReadOnly = True
        Me.txtMontoFinanciado.Size = New System.Drawing.Size(88, 20)
        Me.txtMontoFinanciado.TabIndex = 76
        Me.txtMontoFinanciado.TabStop = False
        Me.txtMontoFinanciado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtOpcion
        '
        Me.txtOpcion.Location = New System.Drawing.Point(168, 136)
        Me.txtOpcion.Name = "txtOpcion"
        Me.txtOpcion.ReadOnly = True
        Me.txtOpcion.Size = New System.Drawing.Size(88, 20)
        Me.txtOpcion.TabIndex = 74
        Me.txtOpcion.TabStop = False
        Me.txtOpcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSaldoSeguro
        '
        Me.txtSaldoSeguro.Location = New System.Drawing.Point(168, 112)
        Me.txtSaldoSeguro.Name = "txtSaldoSeguro"
        Me.txtSaldoSeguro.ReadOnly = True
        Me.txtSaldoSeguro.Size = New System.Drawing.Size(88, 20)
        Me.txtSaldoSeguro.TabIndex = 72
        Me.txtSaldoSeguro.TabStop = False
        Me.txtSaldoSeguro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPlaseg
        '
        Me.txtPlaseg.Location = New System.Drawing.Point(232, 88)
        Me.txtPlaseg.Name = "txtPlaseg"
        Me.txtPlaseg.ReadOnly = True
        Me.txtPlaseg.Size = New System.Drawing.Size(24, 20)
        Me.txtPlaseg.TabIndex = 71
        Me.txtPlaseg.TabStop = False
        Me.txtPlaseg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFinse
        '
        Me.txtFinse.Location = New System.Drawing.Point(232, 64)
        Me.txtFinse.Name = "txtFinse"
        Me.txtFinse.ReadOnly = True
        Me.txtFinse.Size = New System.Drawing.Size(24, 20)
        Me.txtFinse.TabIndex = 70
        Me.txtFinse.TabStop = False
        Me.txtFinse.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIvaeq
        '
        Me.txtIvaeq.Location = New System.Drawing.Point(168, 40)
        Me.txtIvaeq.Name = "txtIvaeq"
        Me.txtIvaeq.ReadOnly = True
        Me.txtIvaeq.Size = New System.Drawing.Size(88, 20)
        Me.txtIvaeq.TabIndex = 65
        Me.txtIvaeq.TabStop = False
        Me.txtIvaeq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtImpEq
        '
        Me.txtImpEq.Location = New System.Drawing.Point(168, 16)
        Me.txtImpEq.Name = "txtImpEq"
        Me.txtImpEq.ReadOnly = True
        Me.txtImpEq.Size = New System.Drawing.Size(88, 20)
        Me.txtImpEq.TabIndex = 63
        Me.txtImpEq.TabStop = False
        Me.txtImpEq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(8, 16)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(144, 16)
        Me.Label27.TabIndex = 58
        Me.Label27.Text = "Equipo con I.V.A."
        '
        'lblIvaeq
        '
        Me.lblIvaeq.Location = New System.Drawing.Point(8, 40)
        Me.lblIvaeq.Name = "lblIvaeq"
        Me.lblIvaeq.Size = New System.Drawing.Size(144, 16)
        Me.lblIvaeq.TabIndex = 57
        Me.lblIvaeq.Text = "I.V.A. del Equipo"
        '
        'lblOpcom
        '
        Me.lblOpcom.Location = New System.Drawing.Point(8, 136)
        Me.lblOpcom.Name = "lblOpcom"
        Me.lblOpcom.Size = New System.Drawing.Size(144, 16)
        Me.lblOpcom.TabIndex = 55
        Me.lblOpcom.Text = "Opción a compra con I.V.A."
        '
        'lblMontof
        '
        Me.lblMontof.Location = New System.Drawing.Point(8, 160)
        Me.lblMontof.Name = "lblMontof"
        Me.lblMontof.Size = New System.Drawing.Size(144, 16)
        Me.lblMontof.TabIndex = 54
        Me.lblMontof.Text = "Monto Financiado"
        '
        'lblMontos
        '
        Me.lblMontos.Location = New System.Drawing.Point(8, 112)
        Me.lblMontos.Name = "lblMontos"
        Me.lblMontos.Size = New System.Drawing.Size(144, 16)
        Me.lblMontos.TabIndex = 53
        Me.lblMontos.Text = "Monto del Seguro"
        '
        'lblPlazos
        '
        Me.lblPlazos.Location = New System.Drawing.Point(8, 88)
        Me.lblPlazos.Name = "lblPlazos"
        Me.lblPlazos.Size = New System.Drawing.Size(144, 16)
        Me.lblPlazos.TabIndex = 52
        Me.lblPlazos.Text = "Plazo del Seguro en meses"
        '
        'lblSeg
        '
        Me.lblSeg.Location = New System.Drawing.Point(8, 64)
        Me.lblSeg.Name = "lblSeg"
        Me.lblSeg.Size = New System.Drawing.Size(144, 16)
        Me.lblSeg.TabIndex = 50
        Me.lblSeg.Text = "Seguro Financiado (S/N)"
        '
        'txtPlazo
        '
        Me.txtPlazo.Location = New System.Drawing.Point(240, 120)
        Me.txtPlazo.Name = "txtPlazo"
        Me.txtPlazo.ReadOnly = True
        Me.txtPlazo.Size = New System.Drawing.Size(24, 20)
        Me.txtPlazo.TabIndex = 61
        Me.txtPlazo.TabStop = False
        Me.txtPlazo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPlazo
        '
        Me.lblPlazo.Location = New System.Drawing.Point(16, 124)
        Me.lblPlazo.Name = "lblPlazo"
        Me.lblPlazo.Size = New System.Drawing.Size(136, 16)
        Me.lblPlazo.TabIndex = 59
        Me.lblPlazo.Text = "Plazo en meses"
        Me.lblPlazo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDescTasa
        '
        Me.txtDescTasa.Location = New System.Drawing.Point(144, 392)
        Me.txtDescTasa.Name = "txtDescTasa"
        Me.txtDescTasa.ReadOnly = True
        Me.txtDescTasa.Size = New System.Drawing.Size(224, 20)
        Me.txtDescTasa.TabIndex = 47
        Me.txtDescTasa.TabStop = False
        '
        'lblTipotasa
        '
        Me.lblTipotasa.Location = New System.Drawing.Point(16, 392)
        Me.lblTipotasa.Name = "lblTipotasa"
        Me.lblTipotasa.Size = New System.Drawing.Size(120, 16)
        Me.lblTipotasa.TabIndex = 46
        Me.lblTipotasa.Text = "Tipo de Tasa"
        Me.lblTipotasa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtForca
        '
        Me.txtForca.Location = New System.Drawing.Point(144, 368)
        Me.txtForca.Name = "txtForca"
        Me.txtForca.ReadOnly = True
        Me.txtForca.Size = New System.Drawing.Size(136, 20)
        Me.txtForca.TabIndex = 39
        Me.txtForca.TabStop = False
        '
        'lblEqmap
        '
        Me.lblEqmap.Location = New System.Drawing.Point(16, 368)
        Me.lblEqmap.Name = "lblEqmap"
        Me.lblEqmap.Size = New System.Drawing.Size(120, 16)
        Me.lblEqmap.TabIndex = 38
        Me.lblEqmap.Text = "Esquema de Pagos"
        Me.lblEqmap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFondeo
        '
        Me.txtFondeo.Location = New System.Drawing.Point(144, 344)
        Me.txtFondeo.Name = "txtFondeo"
        Me.txtFondeo.ReadOnly = True
        Me.txtFondeo.Size = New System.Drawing.Size(136, 20)
        Me.txtFondeo.TabIndex = 37
        Me.txtFondeo.TabStop = False
        '
        'lblRecursos
        '
        Me.lblRecursos.Location = New System.Drawing.Point(16, 344)
        Me.lblRecursos.Name = "lblRecursos"
        Me.lblRecursos.Size = New System.Drawing.Size(120, 16)
        Me.lblRecursos.TabIndex = 36
        Me.lblRecursos.Text = "Recursos"
        Me.lblRecursos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFrecuencia
        '
        Me.txtFrecuencia.Location = New System.Drawing.Point(144, 320)
        Me.txtFrecuencia.Name = "txtFrecuencia"
        Me.txtFrecuencia.ReadOnly = True
        Me.txtFrecuencia.Size = New System.Drawing.Size(136, 20)
        Me.txtFrecuencia.TabIndex = 35
        Me.txtFrecuencia.TabStop = False
        '
        'txtCritas
        '
        Me.txtCritas.Location = New System.Drawing.Point(144, 296)
        Me.txtCritas.Name = "txtCritas"
        Me.txtCritas.ReadOnly = True
        Me.txtCritas.Size = New System.Drawing.Size(136, 20)
        Me.txtCritas.TabIndex = 34
        Me.txtCritas.TabStop = False
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(200, 272)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(16, 16)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "%"
        '
        'txtDifer
        '
        Me.txtDifer.Location = New System.Drawing.Point(144, 272)
        Me.txtDifer.Name = "txtDifer"
        Me.txtDifer.ReadOnly = True
        Me.txtDifer.Size = New System.Drawing.Size(56, 20)
        Me.txtDifer.TabIndex = 26
        Me.txtDifer.TabStop = False
        Me.txtDifer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(200, 248)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(16, 16)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "%"
        '
        'txtTasas
        '
        Me.txtTasas.Location = New System.Drawing.Point(144, 248)
        Me.txtTasas.Name = "txtTasas"
        Me.txtTasas.ReadOnly = True
        Me.txtTasas.Size = New System.Drawing.Size(56, 20)
        Me.txtTasas.TabIndex = 24
        Me.txtTasas.TabStop = False
        Me.txtTasas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(200, 224)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(16, 16)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "%"
        '
        'txtPorop
        '
        Me.txtPorop.Location = New System.Drawing.Point(144, 224)
        Me.txtPorop.Name = "txtPorop"
        Me.txtPorop.ReadOnly = True
        Me.txtPorop.Size = New System.Drawing.Size(56, 20)
        Me.txtPorop.TabIndex = 22
        Me.txtPorop.TabStop = False
        Me.txtPorop.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(200, 200)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(16, 16)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "%"
        '
        'txtPorco
        '
        Me.txtPorco.Location = New System.Drawing.Point(144, 200)
        Me.txtPorco.Name = "txtPorco"
        Me.txtPorco.ReadOnly = True
        Me.txtPorco.Size = New System.Drawing.Size(56, 20)
        Me.txtPorco.TabIndex = 20
        Me.txtPorco.TabStop = False
        Me.txtPorco.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(200, 176)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 16)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "%"
        '
        'txtPorieq
        '
        Me.txtPorieq.Location = New System.Drawing.Point(144, 176)
        Me.txtPorieq.Name = "txtPorieq"
        Me.txtPorieq.ReadOnly = True
        Me.txtPorieq.Size = New System.Drawing.Size(56, 20)
        Me.txtPorieq.TabIndex = 18
        Me.txtPorieq.TabStop = False
        Me.txtPorieq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDescTipar
        '
        Me.txtDescTipar.Location = New System.Drawing.Point(144, 48)
        Me.txtDescTipar.Name = "txtDescTipar"
        Me.txtDescTipar.ReadOnly = True
        Me.txtDescTipar.Size = New System.Drawing.Size(224, 20)
        Me.txtDescTipar.TabIndex = 17
        Me.txtDescTipar.TabStop = False
        '
        'txtTermina
        '
        Me.txtTermina.Location = New System.Drawing.Point(200, 144)
        Me.txtTermina.Name = "txtTermina"
        Me.txtTermina.ReadOnly = True
        Me.txtTermina.Size = New System.Drawing.Size(64, 20)
        Me.txtTermina.TabIndex = 16
        Me.txtTermina.TabStop = False
        Me.txtTermina.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblFrecpag
        '
        Me.lblFrecpag.Location = New System.Drawing.Point(16, 320)
        Me.lblFrecpag.Name = "lblFrecpag"
        Me.lblFrecpag.Size = New System.Drawing.Size(120, 16)
        Me.lblFrecpag.TabIndex = 15
        Me.lblFrecpag.Text = "Frecuencia de pago"
        Me.lblFrecpag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCriteriotasa
        '
        Me.lblCriteriotasa.Location = New System.Drawing.Point(16, 296)
        Me.lblCriteriotasa.Name = "lblCriteriotasa"
        Me.lblCriteriotasa.Size = New System.Drawing.Size(120, 16)
        Me.lblCriteriotasa.TabIndex = 14
        Me.lblCriteriotasa.Text = "Criterio de Tasa"
        Me.lblCriteriotasa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDifer
        '
        Me.lblDifer.Location = New System.Drawing.Point(16, 272)
        Me.lblDifer.Name = "lblDifer"
        Me.lblDifer.Size = New System.Drawing.Size(120, 16)
        Me.lblDifer.TabIndex = 13
        Me.lblDifer.Text = "Diferencial"
        Me.lblDifer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTasai
        '
        Me.lblTasai.Location = New System.Drawing.Point(16, 248)
        Me.lblTasai.Name = "lblTasai"
        Me.lblTasai.Size = New System.Drawing.Size(120, 16)
        Me.lblTasai.TabIndex = 12
        Me.lblTasai.Text = "Tasa de Interés"
        Me.lblTasai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 224)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 16)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Opción de Compra"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 200)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 16)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Comisión"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIva
        '
        Me.lblIva.Location = New System.Drawing.Point(16, 176)
        Me.lblIva.Name = "lblIva"
        Me.lblIva.Size = New System.Drawing.Size(120, 16)
        Me.lblIva.TabIndex = 9
        Me.lblIva.Text = "I.V.A."
        Me.lblIva.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFechafin
        '
        Me.lblFechafin.Location = New System.Drawing.Point(16, 148)
        Me.lblFechafin.Name = "lblFechafin"
        Me.lblFechafin.Size = New System.Drawing.Size(136, 16)
        Me.lblFechafin.TabIndex = 8
        Me.lblFechafin.Text = "Fecha de Terminación"
        Me.lblFechafin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFvenc
        '
        Me.txtFvenc.Location = New System.Drawing.Point(200, 96)
        Me.txtFvenc.Name = "txtFvenc"
        Me.txtFvenc.ReadOnly = True
        Me.txtFvenc.Size = New System.Drawing.Size(64, 20)
        Me.txtFvenc.TabIndex = 7
        Me.txtFvenc.TabStop = False
        Me.txtFvenc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFechacon
        '
        Me.txtFechacon.Location = New System.Drawing.Point(200, 72)
        Me.txtFechacon.Name = "txtFechacon"
        Me.txtFechacon.ReadOnly = True
        Me.txtFechacon.Size = New System.Drawing.Size(64, 20)
        Me.txtFechacon.TabIndex = 6
        Me.txtFechacon.TabStop = False
        Me.txtFechacon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblFechaven1
        '
        Me.lblFechaven1.Location = New System.Drawing.Point(16, 100)
        Me.lblFechaven1.Name = "lblFechaven1"
        Me.lblFechaven1.Size = New System.Drawing.Size(136, 16)
        Me.lblFechaven1.TabIndex = 3
        Me.lblFechaven1.Text = "Fecha 1er. Vencimiento"
        Me.lblFechaven1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFechac
        '
        Me.lblFechac.Location = New System.Drawing.Point(16, 76)
        Me.lblFechac.Name = "lblFechac"
        Me.lblFechac.Size = New System.Drawing.Size(136, 16)
        Me.lblFechac.TabIndex = 2
        Me.lblFechac.Text = "Fecha de Contratación"
        Me.lblFechac.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTipo
        '
        Me.lblTipo.Location = New System.Drawing.Point(16, 48)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(103, 20)
        Me.lblTipo.TabIndex = 1
        Me.lblTipo.Text = "Producto"
        Me.lblTipo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNumc
        '
        Me.lblNumc.Location = New System.Drawing.Point(16, 12)
        Me.lblNumc.Name = "lblNumc"
        Me.lblNumc.Size = New System.Drawing.Size(88, 20)
        Me.lblNumc.TabIndex = 0
        Me.lblNumc.Text = "No. de Contrato"
        Me.lblNumc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnDatosCliente
        '
        Me.btnDatosCliente.Enabled = False
        Me.btnDatosCliente.Location = New System.Drawing.Point(664, 56)
        Me.btnDatosCliente.Name = "btnDatosCliente"
        Me.btnDatosCliente.Size = New System.Drawing.Size(104, 24)
        Me.btnDatosCliente.TabIndex = 0
        Me.btnDatosCliente.Text = "Datos del Cliente"
        '
        'btnDatoseq
        '
        Me.btnDatoseq.Enabled = False
        Me.btnDatoseq.Location = New System.Drawing.Point(664, 96)
        Me.btnDatoseq.Name = "btnDatoseq"
        Me.btnDatoseq.Size = New System.Drawing.Size(104, 24)
        Me.btnDatoseq.TabIndex = 1
        Me.btnDatoseq.Text = "Datos del Equipo"
        '
        'btnReferencia
        '
        Me.btnReferencia.Enabled = False
        Me.btnReferencia.Location = New System.Drawing.Point(664, 136)
        Me.btnReferencia.Name = "btnReferencia"
        Me.btnReferencia.Size = New System.Drawing.Size(104, 24)
        Me.btnReferencia.TabIndex = 2
        Me.btnReferencia.Text = "Referencia"
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(664, 334)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(104, 24)
        Me.btnSalir.TabIndex = 6
        Me.btnSalir.Text = "Salir"
        '
        'txtReferencia
        '
        Me.txtReferencia.Location = New System.Drawing.Point(112, 466)
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.Size = New System.Drawing.Size(24, 20)
        Me.txtReferencia.TabIndex = 62
        Me.txtReferencia.Visible = False
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(144, 466)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(24, 20)
        Me.txtCliente.TabIndex = 63
        Me.txtCliente.Visible = False
        '
        'btnTablaEquipo
        '
        Me.btnTablaEquipo.Enabled = False
        Me.btnTablaEquipo.Location = New System.Drawing.Point(664, 176)
        Me.btnTablaEquipo.Name = "btnTablaEquipo"
        Me.btnTablaEquipo.Size = New System.Drawing.Size(104, 24)
        Me.btnTablaEquipo.TabIndex = 3
        Me.btnTablaEquipo.Text = "Tabla Equipo"
        '
        'btnTablaSeguro
        '
        Me.btnTablaSeguro.Enabled = False
        Me.btnTablaSeguro.Location = New System.Drawing.Point(664, 216)
        Me.btnTablaSeguro.Name = "btnTablaSeguro"
        Me.btnTablaSeguro.Size = New System.Drawing.Size(104, 24)
        Me.btnTablaSeguro.TabIndex = 4
        Me.btnTablaSeguro.Text = "Tabla Seguro"
        '
        'btnHistoria
        '
        Me.btnHistoria.Enabled = False
        Me.btnHistoria.Location = New System.Drawing.Point(664, 294)
        Me.btnHistoria.Name = "btnHistoria"
        Me.btnHistoria.Size = New System.Drawing.Size(104, 24)
        Me.btnHistoria.TabIndex = 5
        Me.btnHistoria.Text = "Historia de Pagos"
        '
        'lblStatus
        '
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(192, 12)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(80, 20)
        Me.lblStatus.TabIndex = 69
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAnexo
        '
        Me.lblAnexo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAnexo.Location = New System.Drawing.Point(112, 12)
        Me.lblAnexo.Name = "lblAnexo"
        Me.lblAnexo.Size = New System.Drawing.Size(72, 20)
        Me.lblAnexo.TabIndex = 70
        Me.lblAnexo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDescr
        '
        Me.lblDescr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescr.Location = New System.Drawing.Point(280, 12)
        Me.lblDescr.Name = "lblDescr"
        Me.lblDescr.Size = New System.Drawing.Size(480, 20)
        Me.lblDescr.TabIndex = 71
        Me.lblDescr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnTablaOtros
        '
        Me.btnTablaOtros.Enabled = False
        Me.btnTablaOtros.Location = New System.Drawing.Point(664, 256)
        Me.btnTablaOtros.Name = "btnTablaOtros"
        Me.btnTablaOtros.Size = New System.Drawing.Size(104, 24)
        Me.btnTablaOtros.TabIndex = 84
        Me.btnTablaOtros.Text = "Tabla Otros"
        '
        'frmDatosCon
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(792, 541)
        Me.Controls.Add(Me.btnTablaOtros)
        Me.Controls.Add(Me.lblDescr)
        Me.Controls.Add(Me.lblAnexo)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.btnHistoria)
        Me.Controls.Add(Me.btnTablaSeguro)
        Me.Controls.Add(Me.btnTablaEquipo)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.txtReferencia)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnReferencia)
        Me.Controls.Add(Me.btnDatoseq)
        Me.Controls.Add(Me.btnDatosCliente)
        Me.Controls.Add(Me.lblNumc)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblFechac)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblFechaven1)
        Me.Controls.Add(Me.txtTermina)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblFechafin)
        Me.Controls.Add(Me.lblTipo)
        Me.Controls.Add(Me.txtDifer)
        Me.Controls.Add(Me.lblDifer)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblTasai)
        Me.Controls.Add(Me.txtTasas)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lblIva)
        Me.Controls.Add(Me.txtPorop)
        Me.Controls.Add(Me.txtPorieq)
        Me.Controls.Add(Me.txtFvenc)
        Me.Controls.Add(Me.txtPorco)
        Me.Controls.Add(Me.txtDescTipar)
        Me.Controls.Add(Me.txtFechacon)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gpoPagos)
        Me.Controls.Add(Me.txtDescTasa)
        Me.Controls.Add(Me.lblCriteriotasa)
        Me.Controls.Add(Me.lblTipotasa)
        Me.Controls.Add(Me.lblRecursos)
        Me.Controls.Add(Me.lblGaran)
        Me.Controls.Add(Me.txtFrecuencia)
        Me.Controls.Add(Me.lblFrecpag)
        Me.Controls.Add(Me.txtPrenda)
        Me.Controls.Add(Me.txtCritas)
        Me.Controls.Add(Me.txtFondeo)
        Me.Controls.Add(Me.txtForca)
        Me.Controls.Add(Me.lblEqmap)
        Me.Controls.Add(Me.gpoPagosi)
        Me.Controls.Add(Me.lblPlazo)
        Me.Controls.Add(Me.txtPlazo)
        Me.Name = "frmDatosCon"
        Me.Text = "Datos del Contrato"
        Me.gpoPagosi.ResumeLayout(False)
        Me.gpoPagosi.PerformLayout()
        Me.gpoPagos.ResumeLayout(False)
        Me.gpoPagos.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub frmDatosCon_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daAnexos As New SqlDataAdapter(cm1)
        Dim dsAgil As New DataSet()
        Dim drAnexo As DataRow

        ' Declaración de variables de datos

        Dim cAnexo As String = ""
        Dim cFlcan As String = ""
        Dim cTipar As String = ""
        Dim nDG As Byte = 0
        Dim nImpDG As Decimal = 0
        Dim nImpEq As Decimal = 0
        Dim nImpRD As Decimal = 0
        Dim nIvaDG As Decimal = 0
        Dim nIvaRD As Decimal = 0
        Dim nPorop As Decimal = 0
        Dim nRD As Byte = 0
        Dim nResidual As Decimal = 0
        Dim nSaldoEquipo As Decimal = 0

        cAnexo = Mid(lblAnexo.Text, 1, 5) & Mid(lblAnexo.Text, 7, 4)

        myIdentity = GetCurrent()
        cUsuario = myIdentity.Name

        ' El siguiente Stored Procedure trae todos los atributos de la tabla Anexos,
        ' para un anexo dado

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DatosCon1"
            .Connection = cnAgil
            .Parameters.Add("@Anexo", SqlDbType.NVarChar)
            .Parameters(0).Value = cAnexo
        End With

        ' Llenar el DataSet lo cual abre y cierra la conexión

        daAnexos.Fill(dsAgil, "Anexos")

        If dsAgil.Tables("Anexos").Rows.Count = 0 Then

            lblDescr.Text = "CONTRATO INEXISTENTE"

        Else

            btnDatosCliente.Enabled = True
            btnDatoseq.Enabled = True

            If cUsuario = "AGIL\seguros" Or cUsuario = "AGIL\seguros2" Then
                btnReferencia.Enabled = False
                btnTablaEquipo.Enabled = False
                btnHistoria.Enabled = False
            Else
                btnReferencia.Enabled = True
                btnTablaEquipo.Enabled = True
                btnHistoria.Enabled = True
            End If

            drAnexo = dsAgil.Tables("Anexos").Rows(0)
            cFlcan = drAnexo("Flcan")
            Select Case cFlcan
                Case "A"
                    lblStatus.Text = "ACTIVO"
                Case "S"
                    lblStatus.Text = "SUSPENSO"
                Case "T"
                    lblStatus.Text = "TERMINADO"
                Case "C"
                    lblStatus.Text = "CANCELADO"
                Case "B"
                    lblStatus.Text = "BAJA"
            End Select

            lblDescr.Text = drAnexo("Descr")
            cTipar = drAnexo("Tipar")
            If cTipar = "F" Then
                txtDescTipar.Text = "ARRENDAMIENTO FINANCIERO"
            ElseIf cTipar = "P" Then
                txtDescTipar.Text = "ARRENDAMIENTO PURO"
            ElseIf cTipar = "R" Then
                txtDescTipar.Text = "CREDITO REFACCIONARIO"
            ElseIf cTipar = "S" Then
                txtDescTipar.Text = "CREDITO SIMPLE"
            End If
            txtFechacon.Text = CTOD(drAnexo("Fechacon"))
            txtFvenc.Text = CTOD(drAnexo("Fvenc"))
            txtPlazo.Text = drAnexo("Plazo")
            txtTermina.Text = Termina(CTOD(drAnexo("Fvenc")), drAnexo("Plazo"))
            txtPorieq.Text = Format(drAnexo("Porieq"), "##,##0.0000")
            txtPorco.Text = Format(drAnexo("Porco"), "F")
            txtPorop.Text = Format(drAnexo("Porop"), "F")
            txtTasas.Text = Format(drAnexo("Tasas"), "##,##0.0000")
            txtDifer.Text = Format(drAnexo("Difer"), "##,##0.0000")

            txtCritas.Text = drAnexo("DescCriterio")
            txtFrecuencia.Text = drAnexo("DescFrecuencia")
            txtFondeo.Text = drAnexo("DescRecurso")
            txtForca.Text = drAnexo("DescEsquema")
            txtDescTasa.Text = drAnexo("DescTasa")
            nImpEq = drAnexo("ImpEq")
            nPorop = drAnexo("Porop")

            If cTipar = "R" Then
                Label27.Text = "Monto del Equipo"
                lblAmortiza.Text = "Enganche"
                lblIvaamortiza.Text = "Derechos de Registro"
            Else
                Label27.Text = "Equipo con I.V.A."
                lblAmortiza.Text = "Amortización inicial"
                lblIvaamortiza.Text = "I.V.A. de la Amortización"
            End If

            txtImpEq.Text = Format(drAnexo("ImpEq"), "##,##0.00")
            txtIvaeq.Text = Format(drAnexo("IvaEq"), "##,##0.00")
            txtAmorin.Text = Format(drAnexo("Amorin"), "##,##0.00")
            txtIvaAmorin.Text = Format(drAnexo("Ivaamorin"), "##,##0.00")
            If cTipar = "R" Then
                txtIvaAmorin.Text = Format(drAnexo("Derechos"), "##,##0.00")
                lblAmortiza.Text = "Enganche"
                lblIvaamortiza.Text = "Derechos de Registro"
            ElseIf cTipar = "P" Then
                txtIvaAmorin.Text = Format(drAnexo("IvaAmorin"), "##,##0.00")
                Label4.Text = "Valor Residual"
                lblOpcom.Text = "Amortización Final"
            End If
            txtFinse.Text = drAnexo("Finse")
            txtPlaseg.Text = drAnexo("Plaseg")
            txtSaldoSeguro.Text = Format(drAnexo("SegEq"), "##,##0.00")
            If cTipar = "P" Then
                nResidual = Round((nImpEq * nPorop / 100), 2)
                txtOpcion.Text = Format(nResidual, "##,##0.00")
            Else
                txtOpcion.Text = Format(drAnexo("OC"), "##,##0.00")
            End If
            txtMontoFinanciado.Text = Format(drAnexo("ImpEq") - drAnexo("IvaEq") - drAnexo("Amorin"), "##,##0.00")

            txtComis.Text = Format(drAnexo("Comis"), "##,##0.00")

            nDG = drAnexo("DG")
            If nDG > 0 Then
                lblImpDG.Text = "Depósito en Garantía " & Str(nDG) & "%"
            End If
            nImpDG = drAnexo("ImpRD")
            nIvaDG = drAnexo("IvaRD")

            nRD = drAnexo("RD")
            If nRD > 0 Then
                nImpRD = drAnexo("ImpDG")
                nIvaRD = drAnexo("IvaDG")
            End If

            txtImpDG.Text = Format(nImpDG, "##,##0.00")
            txtIvaDG.Text = Format(nIvaDG, "##,##0.00")

            txtImpRD.Text = Format(nImpRD, "##,##0.00")
            txtIvaRD.Text = Format(nIvaRD, "##,##0.00")

            txtGastos.Text = Format(drAnexo("Gastos") + drAnexo("IvaGastos"), "##,##0.00")
            nSaldoEquipo = Round(drAnexo("ImpEq") - drAnexo("IvaEq") - drAnexo("Amorin"), 2)
            txtNafin.Text = Format(drAnexo("DepNafin"), "##,##0.00")

            txtPagosIniciales.Text = Format(drAnexo("Amorin") + drAnexo("IvaAmorin") + drAnexo("Derechos") + drAnexo("Comis") + drAnexo("Gastos") + drAnexo("IvaGastos") + drAnexo("DepNafin") + nImpDG + nIvaDG + nImpRD + nIvaRD, "##,##0.00")

            txtPrenda.Text = "N"
            If drAnexo("Prenda") = "S" Then
                txtPrenda.Text = "S"
            End If

            txtCliente.Text = drAnexo("Cliente")
            txtReferencia.Text = drAnexo("Referencia")

            If txtFinse.Text = "S" And cUsuario <> "AGIL\seguros" And cUsuario <> "AGIL\seguros2" Then
                btnTablaSeguro.Enabled = True
            Else
                btnTablaSeguro.Enabled = False
            End If

            If drAnexo("Adeudo") = "S" And cUsuario <> "AGIL\seguros" And cUsuario <> "AGIL\seguros2" Then
                btnTablaOtros.Enabled = True
            Else
                btnTablaOtros.Enabled = False
            End If
        End If

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub btnDatosCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDatosCliente.Click
        Dim newfrmDatosClie As New frmDatosclie(txtCliente.Text)
        newfrmDatosClie.Show()
    End Sub

    Private Sub btnDatoseq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDatoseq.Click
        Dim newfrmDatosEq As New frmDatosEq(lblAnexo.Text)
        newfrmDatosEq.Show()
    End Sub

    Private Sub btnReferencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReferencia.Click
        Dim newfrmReferencia As New frmReferencia(lblAnexo.Text, txtCliente.Text)
        newfrmReferencia.Show()
    End Sub

    Private Sub btnTablaEquipo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTablaEquipo.Click
        Dim newfrmTablaEquipo As New frmTablaEquipo(lblAnexo.Text)
        newfrmTablaEquipo.Show()
    End Sub

    Private Sub btnTablaSeguro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTablaSeguro.Click
        Dim newfrmTablaSeguro As New frmTablaSeguro(lblAnexo.Text)
        newfrmTablaSeguro.Show()
    End Sub

    Private Sub btnHistoria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHistoria.Click
        Dim newfrmHistoria As New frmHistoria(lblAnexo.Text)
        newfrmHistoria.Show()
    End Sub

    Private Sub btnTablaOtros_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTablaOtros.Click
        Dim newfrmTablaOtros As New frmTablaOtros(lblAnexo.Text)
        newfrmTablaOtros.Show()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class
