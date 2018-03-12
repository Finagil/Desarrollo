' Este proceso recibe como parámetro el número del anexo para el cual se desea calcular el finiquito

Option Explicit On

Imports System.Data.SqlClient
Imports System.Math
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmCalcfini

    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal cAnexo As String)

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() 
        Me.Text = "Calculo de Finiquito"
        txtAnexo.Text = cAnexo

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
    Friend WithEvents txtAnexo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lblImpDG As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblTasaAplicada As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents lblImportePago As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtIvaIntereses As System.Windows.Forms.TextBox
    Friend WithEvents txtUDIFinal As System.Windows.Forms.TextBox
    Friend WithEvents txtUDIInicial As System.Windows.Forms.TextBox
    Friend WithEvents txtImportePago As System.Windows.Forms.TextBox
    Friend WithEvents txtIntereses As System.Windows.Forms.TextBox
    Friend WithEvents txtTasaAplicada As System.Windows.Forms.TextBox
    Friend WithEvents txtIvaMoratorios As System.Windows.Forms.TextBox
    Friend WithEvents txtDiasIntereses As System.Windows.Forms.TextBox
    Friend WithEvents txtMoratorios As System.Windows.Forms.TextBox
    Friend WithEvents txtIvaRD As System.Windows.Forms.TextBox
    Friend WithEvents txtImpRD As System.Windows.Forms.TextBox
    Friend WithEvents txtOpcion As System.Windows.Forms.TextBox
    Friend WithEvents txtSaldoSeguro As System.Windows.Forms.TextBox
    Friend WithEvents txtIvaComision As System.Windows.Forms.TextBox
    Friend WithEvents txtIvaDiferido As System.Windows.Forms.TextBox
    Friend WithEvents txtComision As System.Windows.Forms.TextBox
    Friend WithEvents txtImpDG As System.Windows.Forms.TextBox
    Friend WithEvents txtPenalizacion As System.Windows.Forms.TextBox
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnCalcular As System.Windows.Forms.Button
    Friend WithEvents txtRentasVencidas As System.Windows.Forms.TextBox
    Friend WithEvents txtSaldoEquipo As System.Windows.Forms.TextBox
    Friend WithEvents txtSaldoOtros As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents txtIvaDG As System.Windows.Forms.TextBox
    Friend WithEvents lblIvaDG As System.Windows.Forms.Label
    Friend WithEvents txtSaldoafavor As System.Windows.Forms.TextBox
    Friend WithEvents lblSaldoafavor As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtAnexo = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtSaldoafavor = New System.Windows.Forms.TextBox
        Me.lblSaldoafavor = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblIvaDG = New System.Windows.Forms.Label
        Me.txtIvaDG = New System.Windows.Forms.TextBox
        Me.Label38 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.txtSaldoOtros = New System.Windows.Forms.TextBox
        Me.txtRentasVencidas = New System.Windows.Forms.TextBox
        Me.btnSalir = New System.Windows.Forms.Button
        Me.btnImprimir = New System.Windows.Forms.Button
        Me.btnCalcular = New System.Windows.Forms.Button
        Me.txtIvaIntereses = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtUDIFinal = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtUDIInicial = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtImportePago = New System.Windows.Forms.TextBox
        Me.txtIntereses = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.lblImportePago = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtTasaAplicada = New System.Windows.Forms.TextBox
        Me.lblTasaAplicada = New System.Windows.Forms.Label
        Me.txtIvaMoratorios = New System.Windows.Forms.TextBox
        Me.txtDiasIntereses = New System.Windows.Forms.TextBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtMoratorios = New System.Windows.Forms.TextBox
        Me.txtIvaRD = New System.Windows.Forms.TextBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtImpRD = New System.Windows.Forms.TextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtOpcion = New System.Windows.Forms.TextBox
        Me.txtSaldoSeguro = New System.Windows.Forms.TextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtIvaComision = New System.Windows.Forms.TextBox
        Me.txtIvaDiferido = New System.Windows.Forms.TextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtComision = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtImpDG = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.lblImpDG = New System.Windows.Forms.Label
        Me.txtPenalizacion = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtSaldoEquipo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnProcesar = New System.Windows.Forms.Button
        Me.Label34 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtAnexo
        '
        Me.txtAnexo.Location = New System.Drawing.Point(437, 18)
        Me.txtAnexo.Name = "txtAnexo"
        Me.txtAnexo.Size = New System.Drawing.Size(8, 20)
        Me.txtAnexo.TabIndex = 56
        Me.txtAnexo.Text = "TextBox21"
        Me.txtAnexo.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtSaldoafavor)
        Me.GroupBox1.Controls.Add(Me.lblSaldoafavor)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lblIvaDG)
        Me.GroupBox1.Controls.Add(Me.txtIvaDG)
        Me.GroupBox1.Controls.Add(Me.Label38)
        Me.GroupBox1.Controls.Add(Me.Label37)
        Me.GroupBox1.Controls.Add(Me.txtSaldoOtros)
        Me.GroupBox1.Controls.Add(Me.txtRentasVencidas)
        Me.GroupBox1.Controls.Add(Me.btnSalir)
        Me.GroupBox1.Controls.Add(Me.btnImprimir)
        Me.GroupBox1.Controls.Add(Me.btnCalcular)
        Me.GroupBox1.Controls.Add(Me.txtIvaIntereses)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtUDIFinal)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtUDIInicial)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtImportePago)
        Me.GroupBox1.Controls.Add(Me.txtIntereses)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.lblImportePago)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtTasaAplicada)
        Me.GroupBox1.Controls.Add(Me.lblTasaAplicada)
        Me.GroupBox1.Controls.Add(Me.txtIvaMoratorios)
        Me.GroupBox1.Controls.Add(Me.txtDiasIntereses)
        Me.GroupBox1.Controls.Add(Me.Label33)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtMoratorios)
        Me.GroupBox1.Controls.Add(Me.txtIvaRD)
        Me.GroupBox1.Controls.Add(Me.Label32)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtImpRD)
        Me.GroupBox1.Controls.Add(Me.Label31)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtOpcion)
        Me.GroupBox1.Controls.Add(Me.txtSaldoSeguro)
        Me.GroupBox1.Controls.Add(Me.Label30)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtIvaComision)
        Me.GroupBox1.Controls.Add(Me.txtIvaDiferido)
        Me.GroupBox1.Controls.Add(Me.Label29)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtComision)
        Me.GroupBox1.Controls.Add(Me.Label28)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtImpDG)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.lblImpDG)
        Me.GroupBox1.Controls.Add(Me.txtPenalizacion)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtSaldoEquipo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(21, 54)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(671, 386)
        Me.GroupBox1.TabIndex = 58
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        Me.GroupBox1.Visible = False
        '
        'txtSaldoafavor
        '
        Me.txtSaldoafavor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSaldoafavor.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSaldoafavor.Location = New System.Drawing.Point(520, 250)
        Me.txtSaldoafavor.Name = "txtSaldoafavor"
        Me.txtSaldoafavor.ReadOnly = True
        Me.txtSaldoafavor.Size = New System.Drawing.Size(100, 20)
        Me.txtSaldoafavor.TabIndex = 106
        Me.txtSaldoafavor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSaldoafavor.Visible = False
        '
        'lblSaldoafavor
        '
        Me.lblSaldoafavor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldoafavor.ForeColor = System.Drawing.Color.Red
        Me.lblSaldoafavor.Location = New System.Drawing.Point(360, 250)
        Me.lblSaldoafavor.Name = "lblSaldoafavor"
        Me.lblSaldoafavor.Size = New System.Drawing.Size(158, 16)
        Me.lblSaldoafavor.TabIndex = 105
        Me.lblSaldoafavor.Text = "SALDO A FAVOR"
        Me.lblSaldoafavor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblSaldoafavor.Visible = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 16)
        Me.Label2.TabIndex = 104
        Me.Label2.Text = "-"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIvaDG
        '
        Me.lblIvaDG.Location = New System.Drawing.Point(24, 69)
        Me.lblIvaDG.Name = "lblIvaDG"
        Me.lblIvaDG.Size = New System.Drawing.Size(178, 16)
        Me.lblIvaDG.TabIndex = 103
        Me.lblIvaDG.Text = "I.V.A. del Depósito en Garantía"
        '
        'txtIvaDG
        '
        Me.txtIvaDG.Location = New System.Drawing.Point(208, 69)
        Me.txtIvaDG.Name = "txtIvaDG"
        Me.txtIvaDG.ReadOnly = True
        Me.txtIvaDG.Size = New System.Drawing.Size(100, 20)
        Me.txtIvaDG.TabIndex = 102
        Me.txtIvaDG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label38
        '
        Me.Label38.Location = New System.Drawing.Point(24, 141)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(178, 12)
        Me.Label38.TabIndex = 101
        Me.Label38.Text = "Saldo Insoluto Otros"
        '
        'Label37
        '
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(9, 139)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(14, 17)
        Me.Label37.TabIndex = 100
        Me.Label37.Text = "+"
        '
        'txtSaldoOtros
        '
        Me.txtSaldoOtros.Location = New System.Drawing.Point(208, 141)
        Me.txtSaldoOtros.Name = "txtSaldoOtros"
        Me.txtSaldoOtros.ReadOnly = True
        Me.txtSaldoOtros.Size = New System.Drawing.Size(100, 20)
        Me.txtSaldoOtros.TabIndex = 99
        Me.txtSaldoOtros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRentasVencidas
        '
        Me.txtRentasVencidas.Location = New System.Drawing.Point(520, 112)
        Me.txtRentasVencidas.Name = "txtRentasVencidas"
        Me.txtRentasVencidas.ReadOnly = True
        Me.txtRentasVencidas.Size = New System.Drawing.Size(100, 20)
        Me.txtRentasVencidas.TabIndex = 96
        Me.txtRentasVencidas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(548, 329)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(64, 24)
        Me.btnSalir.TabIndex = 95
        Me.btnSalir.Text = "Salir"
        '
        'btnImprimir
        '
        Me.btnImprimir.Location = New System.Drawing.Point(460, 329)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(64, 24)
        Me.btnImprimir.TabIndex = 94
        Me.btnImprimir.Text = "Imprimir"
        '
        'btnCalcular
        '
        Me.btnCalcular.Location = New System.Drawing.Point(372, 329)
        Me.btnCalcular.Name = "btnCalcular"
        Me.btnCalcular.Size = New System.Drawing.Size(64, 24)
        Me.btnCalcular.TabIndex = 93
        Me.btnCalcular.Text = "Calcular"
        '
        'txtIvaIntereses
        '
        Me.txtIvaIntereses.Location = New System.Drawing.Point(208, 333)
        Me.txtIvaIntereses.Name = "txtIvaIntereses"
        Me.txtIvaIntereses.ReadOnly = True
        Me.txtIvaIntereses.Size = New System.Drawing.Size(100, 20)
        Me.txtIvaIntereses.TabIndex = 92
        Me.txtIvaIntereses.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(8, 337)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(14, 17)
        Me.Label27.TabIndex = 91
        Me.Label27.Text = "+"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(24, 339)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(178, 16)
        Me.Label11.TabIndex = 90
        Me.Label11.Text = "IVA de los Intereses"
        '
        'txtUDIFinal
        '
        Me.txtUDIFinal.Location = New System.Drawing.Point(208, 309)
        Me.txtUDIFinal.Name = "txtUDIFinal"
        Me.txtUDIFinal.ReadOnly = True
        Me.txtUDIFinal.Size = New System.Drawing.Size(100, 20)
        Me.txtUDIFinal.TabIndex = 89
        Me.txtUDIFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(24, 315)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(178, 16)
        Me.Label10.TabIndex = 88
        Me.Label10.Text = "UDI Final"
        '
        'txtUDIInicial
        '
        Me.txtUDIInicial.Location = New System.Drawing.Point(208, 285)
        Me.txtUDIInicial.Name = "txtUDIInicial"
        Me.txtUDIInicial.ReadOnly = True
        Me.txtUDIInicial.Size = New System.Drawing.Size(100, 20)
        Me.txtUDIInicial.TabIndex = 87
        Me.txtUDIInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(24, 291)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(178, 16)
        Me.Label9.TabIndex = 86
        Me.Label9.Text = "UDI Inicial"
        '
        'txtImportePago
        '
        Me.txtImportePago.Location = New System.Drawing.Point(520, 226)
        Me.txtImportePago.Name = "txtImportePago"
        Me.txtImportePago.ReadOnly = True
        Me.txtImportePago.Size = New System.Drawing.Size(100, 20)
        Me.txtImportePago.TabIndex = 85
        Me.txtImportePago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIntereses
        '
        Me.txtIntereses.Location = New System.Drawing.Point(208, 261)
        Me.txtIntereses.Name = "txtIntereses"
        Me.txtIntereses.ReadOnly = True
        Me.txtIntereses.Size = New System.Drawing.Size(100, 20)
        Me.txtIntereses.TabIndex = 84
        Me.txtIntereses.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label26
        '
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(8, 265)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(14, 17)
        Me.Label26.TabIndex = 83
        Me.Label26.Text = "+"
        '
        'lblImportePago
        '
        Me.lblImportePago.Location = New System.Drawing.Point(360, 226)
        Me.lblImportePago.Name = "lblImportePago"
        Me.lblImportePago.Size = New System.Drawing.Size(158, 16)
        Me.lblImportePago.TabIndex = 82
        Me.lblImportePago.Text = "Importe del Pago"
        Me.lblImportePago.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(24, 267)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(178, 16)
        Me.Label8.TabIndex = 81
        Me.Label8.Text = "Intereses"
        '
        'txtTasaAplicada
        '
        Me.txtTasaAplicada.Location = New System.Drawing.Point(208, 237)
        Me.txtTasaAplicada.Name = "txtTasaAplicada"
        Me.txtTasaAplicada.ReadOnly = True
        Me.txtTasaAplicada.Size = New System.Drawing.Size(100, 20)
        Me.txtTasaAplicada.TabIndex = 80
        Me.txtTasaAplicada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTasaAplicada
        '
        Me.lblTasaAplicada.Location = New System.Drawing.Point(24, 243)
        Me.lblTasaAplicada.Name = "lblTasaAplicada"
        Me.lblTasaAplicada.Size = New System.Drawing.Size(178, 16)
        Me.lblTasaAplicada.TabIndex = 79
        Me.lblTasaAplicada.Text = "Tasa Aplicada (%)"
        '
        'txtIvaMoratorios
        '
        Me.txtIvaMoratorios.Location = New System.Drawing.Point(520, 160)
        Me.txtIvaMoratorios.Name = "txtIvaMoratorios"
        Me.txtIvaMoratorios.ReadOnly = True
        Me.txtIvaMoratorios.Size = New System.Drawing.Size(100, 20)
        Me.txtIvaMoratorios.TabIndex = 78
        Me.txtIvaMoratorios.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDiasIntereses
        '
        Me.txtDiasIntereses.Location = New System.Drawing.Point(208, 213)
        Me.txtDiasIntereses.Name = "txtDiasIntereses"
        Me.txtDiasIntereses.Size = New System.Drawing.Size(100, 20)
        Me.txtDiasIntereses.TabIndex = 40
        Me.txtDiasIntereses.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label33
        '
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(344, 158)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(14, 17)
        Me.Label33.TabIndex = 76
        Me.Label33.Text = "+"
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(360, 160)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(158, 16)
        Me.Label19.TabIndex = 75
        Me.Label19.Text = "IVA Moratorios"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(24, 219)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(178, 16)
        Me.Label7.TabIndex = 74
        Me.Label7.Text = "Días de Interes"
        '
        'txtMoratorios
        '
        Me.txtMoratorios.Location = New System.Drawing.Point(520, 136)
        Me.txtMoratorios.Name = "txtMoratorios"
        Me.txtMoratorios.ReadOnly = True
        Me.txtMoratorios.Size = New System.Drawing.Size(100, 20)
        Me.txtMoratorios.TabIndex = 73
        Me.txtMoratorios.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIvaRD
        '
        Me.txtIvaRD.Location = New System.Drawing.Point(208, 189)
        Me.txtIvaRD.Name = "txtIvaRD"
        Me.txtIvaRD.ReadOnly = True
        Me.txtIvaRD.Size = New System.Drawing.Size(100, 20)
        Me.txtIvaRD.TabIndex = 72
        Me.txtIvaRD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label32
        '
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(344, 134)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(14, 17)
        Me.Label32.TabIndex = 71
        Me.Label32.Text = "+"
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(8, 187)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(12, 16)
        Me.Label23.TabIndex = 70
        Me.Label23.Text = "-"
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(360, 136)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(158, 16)
        Me.Label18.TabIndex = 69
        Me.Label18.Text = "Moratorios"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(24, 195)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(178, 16)
        Me.Label6.TabIndex = 68
        Me.Label6.Text = "IVA Renta en Depósito"
        '
        'txtImpRD
        '
        Me.txtImpRD.Location = New System.Drawing.Point(208, 165)
        Me.txtImpRD.Name = "txtImpRD"
        Me.txtImpRD.ReadOnly = True
        Me.txtImpRD.Size = New System.Drawing.Size(100, 20)
        Me.txtImpRD.TabIndex = 67
        Me.txtImpRD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label31
        '
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(344, 111)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(14, 17)
        Me.Label31.TabIndex = 65
        Me.Label31.Text = "+"
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(8, 163)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(12, 16)
        Me.Label22.TabIndex = 64
        Me.Label22.Text = "-"
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(360, 112)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(158, 16)
        Me.Label16.TabIndex = 63
        Me.Label16.Text = "Rentas Vencidas"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(24, 171)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(178, 16)
        Me.Label5.TabIndex = 62
        Me.Label5.Text = "Renta en Depósito"
        '
        'txtOpcion
        '
        Me.txtOpcion.Location = New System.Drawing.Point(520, 88)
        Me.txtOpcion.Name = "txtOpcion"
        Me.txtOpcion.Size = New System.Drawing.Size(100, 20)
        Me.txtOpcion.TabIndex = 46
        Me.txtOpcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSaldoSeguro
        '
        Me.txtSaldoSeguro.Location = New System.Drawing.Point(208, 117)
        Me.txtSaldoSeguro.Name = "txtSaldoSeguro"
        Me.txtSaldoSeguro.ReadOnly = True
        Me.txtSaldoSeguro.Size = New System.Drawing.Size(100, 20)
        Me.txtSaldoSeguro.TabIndex = 61
        Me.txtSaldoSeguro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label30
        '
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(344, 87)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(14, 17)
        Me.Label30.TabIndex = 59
        Me.Label30.Text = "+"
        '
        'Label25
        '
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(8, 115)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(14, 17)
        Me.Label25.TabIndex = 58
        Me.Label25.Text = "+"
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(360, 88)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(158, 16)
        Me.Label15.TabIndex = 57
        Me.Label15.Text = "Opción de Compra con IVA"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(24, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(178, 16)
        Me.Label4.TabIndex = 56
        Me.Label4.Text = "Saldo Insoluto Seguro"
        '
        'txtIvaComision
        '
        Me.txtIvaComision.Location = New System.Drawing.Point(520, 64)
        Me.txtIvaComision.Name = "txtIvaComision"
        Me.txtIvaComision.ReadOnly = True
        Me.txtIvaComision.Size = New System.Drawing.Size(100, 20)
        Me.txtIvaComision.TabIndex = 54
        Me.txtIvaComision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIvaDiferido
        '
        Me.txtIvaDiferido.Location = New System.Drawing.Point(208, 93)
        Me.txtIvaDiferido.Name = "txtIvaDiferido"
        Me.txtIvaDiferido.ReadOnly = True
        Me.txtIvaDiferido.Size = New System.Drawing.Size(100, 20)
        Me.txtIvaDiferido.TabIndex = 55
        Me.txtIvaDiferido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label29
        '
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(344, 62)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(14, 17)
        Me.Label29.TabIndex = 53
        Me.Label29.Text = "+"
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(8, 90)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(14, 17)
        Me.Label24.TabIndex = 52
        Me.Label24.Text = "+"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(360, 64)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(158, 16)
        Me.Label14.TabIndex = 51
        Me.Label14.Text = "IVA Comisión"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(24, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(178, 16)
        Me.Label3.TabIndex = 50
        Me.Label3.Text = "IVA Diferido"
        '
        'txtComision
        '
        Me.txtComision.Location = New System.Drawing.Point(520, 40)
        Me.txtComision.Name = "txtComision"
        Me.txtComision.ReadOnly = True
        Me.txtComision.Size = New System.Drawing.Size(100, 20)
        Me.txtComision.TabIndex = 66
        Me.txtComision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label28
        '
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(344, 37)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(14, 17)
        Me.Label28.TabIndex = 48
        Me.Label28.Text = "+"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(360, 40)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(158, 16)
        Me.Label13.TabIndex = 47
        Me.Label13.Text = "Comisión por Prepago"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtImpDG
        '
        Me.txtImpDG.Location = New System.Drawing.Point(208, 45)
        Me.txtImpDG.Name = "txtImpDG"
        Me.txtImpDG.ReadOnly = True
        Me.txtImpDG.Size = New System.Drawing.Size(100, 20)
        Me.txtImpDG.TabIndex = 60
        Me.txtImpDG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(8, 37)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(12, 16)
        Me.Label21.TabIndex = 44
        Me.Label21.Text = "-"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblImpDG
        '
        Me.lblImpDG.Location = New System.Drawing.Point(24, 45)
        Me.lblImpDG.Name = "lblImpDG"
        Me.lblImpDG.Size = New System.Drawing.Size(178, 16)
        Me.lblImpDG.TabIndex = 43
        Me.lblImpDG.Text = "Depósito en Garantía"
        '
        'txtPenalizacion
        '
        Me.txtPenalizacion.Location = New System.Drawing.Point(520, 16)
        Me.txtPenalizacion.Name = "txtPenalizacion"
        Me.txtPenalizacion.Size = New System.Drawing.Size(100, 20)
        Me.txtPenalizacion.TabIndex = 42
        Me.txtPenalizacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(360, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(158, 16)
        Me.Label12.TabIndex = 41
        Me.Label12.Text = "Penalización (%)"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSaldoEquipo
        '
        Me.txtSaldoEquipo.Location = New System.Drawing.Point(208, 21)
        Me.txtSaldoEquipo.Name = "txtSaldoEquipo"
        Me.txtSaldoEquipo.ReadOnly = True
        Me.txtSaldoEquipo.Size = New System.Drawing.Size(100, 20)
        Me.txtSaldoEquipo.TabIndex = 77
        Me.txtSaldoEquipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(24, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(178, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Saldo Insoluto Equipo"
        '
        'btnProcesar
        '
        Me.btnProcesar.Location = New System.Drawing.Point(256, 16)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(80, 24)
        Me.btnProcesar.TabIndex = 61
        Me.btnProcesar.Text = "Procesar"
        '
        'Label34
        '
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(24, 16)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(110, 16)
        Me.Label34.TabIndex = 60
        Me.Label34.Text = "Fecha de Proceso"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(144, 16)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(88, 20)
        Me.DateTimePicker1.TabIndex = 59
        '
        'frmCalcfini
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(715, 463)
        Me.Controls.Add(Me.btnProcesar)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtAnexo)
        Me.Name = "frmCalcfini"
        Me.Text = "Cálculo de Finiquito"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    ' Declaración de variables de conexión ADO .NET de alcance privado

    Dim dsAgil As New DataSet()
    Dim dtFiniquito As New DataTable("Finiquito")
    Dim drUdis As DataRowCollection

    ' Declaración de variables de datos de alcance privado

    Dim cAdeudo As String = ""
    Dim cAnexo As String = ""
    Dim cCliente As String = ""
    Dim cDescr As String = ""
    Dim cFecha As String = ""
    Dim cFechacon As String = ""
    Dim cFinse As String = ""
    Dim cFondeo As String = ""
    Dim cIndpag As String = ""
    Dim cLetra As String = ""
    Dim cTipar As String = ""
    Dim cTipo As String = ""
    Dim cTipta As String = ""
    Dim dFechaFinal As Date
    Dim dFechaInicial As Date
    Dim lSalir As Boolean
    Dim nAdeudo1 As Decimal = 0
    Dim nAdeudo2 As Decimal = 0
    Dim nAdeudo3 As Decimal = 0
    Dim nAmorin As Decimal = 0
    Dim nComision As Decimal = 0
    Dim nDias As Integer = 0
    Dim nDiasFact As Integer = 0
    Dim nDiasMora As Integer = 0
    Dim nDG As Byte = 0
    Dim nDifer As Decimal = 0
    Dim nInteres As Decimal = 0
    Dim nInteresEquipo As Decimal = 0
    Dim nInteresSeguro As Decimal = 0
    Dim nInteresOtros As Decimal = 0
    Dim nIva As Decimal = 0
    Dim nIvaComision As Decimal = 0
    Dim nIvaDG As Decimal = 0
    Dim nIvaDiferido As Decimal = 0
    Dim nIvaeq As Decimal = 0
    Dim nIvaInteres As Decimal = 0
    Dim nIvaMora As Decimal = 0
    Dim nIvaRD As Decimal = 0
    Dim nFactura As Integer = 0
    Dim nImpDG As Decimal = 0
    Dim nImpEq As Decimal = 0
    Dim nImportePago As Decimal = 0
    Dim nImpRD As Decimal = 0
    Dim nMora As Decimal = 0
    Dim nOpcion As Decimal = 0
    Dim nRD As Byte = 0
    Dim nPorcentajeIVA As Decimal = 0.16
    Dim nSaldoafavor As Decimal = 0
    Dim nSaldoBonifica As Decimal = 0
    Dim nSaldoEquipo As Decimal = 0
    Dim nSaldofac As Decimal = 0
    Dim nSaldoOtros As Decimal = 0
    Dim nSaldoSeguro As Decimal = 0
    Dim nTasa As Decimal = 0
    Dim nTasaIVACliente As Decimal = 0
    Dim nTasaFact As Decimal = 0
    Dim nTasaPen As Decimal = 0
    Dim nTasas As Decimal = 0
    Dim nUdiFinal As Decimal = 0
    Dim nUdiInicial As Decimal = 0

    Private Sub frmCalcfini_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daUdis As New SqlDataAdapter(cm1)

        ' Este Stored Procedure regresa todas las UDIS ordenadas por vigencia

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "TraeUdis1"
            .Connection = cnAgil
        End With

        ' Lleno el dataset lo cual abre y cierra la conexión

        daUdis.Fill(dsAgil, "Udis")

        ' Creo una tabla Temporal donde almaceno los datos que formarán parte del reporte final

        dtFiniquito.Columns.Add("Nombre", Type.GetType("System.String"))
        dtFiniquito.Columns.Add("Contrato", Type.GetType("System.String"))
        dtFiniquito.Columns.Add("SaldoEquipo", Type.GetType("System.String"))
        dtFiniquito.Columns.Add("SaldoOtros", Type.GetType("System.String"))
        dtFiniquito.Columns.Add("ImpDG", Type.GetType("System.String"))
        dtFiniquito.Columns.Add("IvaDG", Type.GetType("System.String"))
        dtFiniquito.Columns.Add("IvaDiferido", Type.GetType("System.String"))
        dtFiniquito.Columns.Add("SaldoSeguro", Type.GetType("System.String"))
        dtFiniquito.Columns.Add("ImpRD", Type.GetType("System.String"))
        dtFiniquito.Columns.Add("IvaRD", Type.GetType("System.String"))
        dtFiniquito.Columns.Add("Interes", Type.GetType("System.String"))
        dtFiniquito.Columns.Add("IvaInteres", Type.GetType("System.String"))
        dtFiniquito.Columns.Add("Comision", Type.GetType("System.String"))
        dtFiniquito.Columns.Add("IvaComision", Type.GetType("System.String"))
        dtFiniquito.Columns.Add("Opcion", Type.GetType("System.String"))
        dtFiniquito.Columns.Add("RentasVencidas", Type.GetType("System.String"))
        dtFiniquito.Columns.Add("Moratorios", Type.GetType("System.String"))
        dtFiniquito.Columns.Add("IvaMoratorios", Type.GetType("System.String"))
        dtFiniquito.Columns.Add("DiasIntereses", Type.GetType("System.String"))
        dtFiniquito.Columns.Add("Tasa", Type.GetType("System.String"))
        dtFiniquito.Columns.Add("Penalizacion", Type.GetType("System.String"))
        dtFiniquito.Columns.Add("UDIInicial", Type.GetType("System.String"))
        dtFiniquito.Columns.Add("UDIFinal", Type.GetType("System.String"))
        dtFiniquito.Columns.Add("GranTotal", Type.GetType("System.String"))
        dtFiniquito.Clear()

        ' También genero el DataRowCollection drUdis ya que necesito enviarlo como
        ' argumento a la función CalcMora que calcula los moratorios ya que esta lo
        ' envía a su vez a la función CalcIvaU.

        drUdis = dsAgil.Tables("Udis").Rows

    End Sub

    Private Sub btnProcesar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProcesar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim cm4 As New SqlCommand()
        Dim cm5 As New SqlCommand()
        Dim cm6 As New SqlCommand()
        Dim cm7 As New SqlCommand()
        Dim cm8 As New SqlCommand()
        Dim daAnexos As New SqlDataAdapter(cm1)
        Dim daEdoctav As New SqlDataAdapter(cm2)
        Dim daEdoctas As New SqlDataAdapter(cm3)
        Dim daEdoctao As New SqlDataAdapter(cm4)
        Dim daFacturas As New SqlDataAdapter(cm5)
        Dim daHista As New SqlDataAdapter(cm6)
        Dim daUdis As New SqlDataAdapter(cm7)
        Dim daClientes As New SqlDataAdapter(cm8)
        Dim drAnexo As DataRow
        Dim drEdoctav As DataRow
        Dim drEdoctas As DataRow
        Dim drEdoctao As DataRow
        Dim drFactura As DataRow
        Dim drCliente As DataRow

        ' Declaración de variables de datos

        cAnexo = Mid(txtAnexo.Text, 1, 5) & Mid(txtAnexo.Text, 7, 4)
        cFecha = DTOC(DateTimePicker1.Value)

        ' El siguiente Stored Procedure trae todos los atributos de la tabla Anexos para un anexo dado

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DatosCon1"
            .Connection = cnAgil
            .Parameters.Add("@Anexo", SqlDbType.NVarChar)
            .Parameters(0).Value = cAnexo
        End With

        ' Comenzar a llenar el DataSet lo cual abre y cierra la conexión.   Este paso es necesario realizarlo
        ' aquí para poder obtener el número de cliente y utilizarlo para ejecutar el Stored Procedure que trae
        ' los datos del cliente.

        daAnexos.Fill(dsAgil, "Anexos")
        drAnexo = dsAgil.Tables("Anexos").Rows(0)
        cCliente = drAnexo("Cliente")

        ' Obtengo la tabla de amortización del Equipo para un anexo dado

        With cm2
            .CommandType = CommandType.StoredProcedure
            .CommandText = "TablaEquipo1"
            .Connection = cnAgil
            .Parameters.Add("@Anexo", SqlDbType.NVarChar)
            .Parameters(0).Value = cAnexo
        End With

        ' Obtengo la tabla de amortización del Seguro para un anexo dado

        With cm3
            .CommandType = CommandType.StoredProcedure
            .CommandText = "TablaSeguro1"
            .Connection = cnAgil
            .Parameters.Add("@Anexo", SqlDbType.NVarChar)
            .Parameters(0).Value = cAnexo
        End With

        ' Obtengo la tabla de amortización de Otros Adeudos para un anexo dado

        With cm4
            .CommandType = CommandType.StoredProcedure
            .CommandText = "TraeAdeudos"
            .Connection = cnAgil
            .Parameters.Add("@Anexo", SqlDbType.NVarChar)
            .Parameters(0).Value = cAnexo
        End With

        ' Este Command regresa todas las facturas generadas para un contrato dado

        With cm5
            .CommandType = CommandType.Text
            .CommandText = "SELECT * FROM Facturas WHERE Anexo = " & "'" & cAnexo & "'"
            .Connection = cnAgil
        End With

        ' Este Stored Procedure regresa todas las tasas

        With cm6
            .CommandType = CommandType.StoredProcedure
            .CommandText = "GeneProv5"
            .Connection = cnAgil
        End With

        ' Este Stored Procedure regresa todas las UDIS ordenadas por vigencia

        With cm7
            .CommandType = CommandType.StoredProcedure
            .CommandText = "TraeUdis1"
            .Connection = cnAgil
        End With

        ' El siguiente Stored Procedure trae los datos del cliente del cual se está calculando el finiquito

        With cm8
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DatosClie1"
            .Connection = cnAgil
            .Parameters.Add("@Cliente", SqlDbType.NVarChar)
            .Parameters(0).Value = cCliente
        End With

        ' Llenar el DataSet lo cual abre y cierra la conexión

        daEdoctav.Fill(dsAgil, "Edoctav")
        daEdoctas.Fill(dsAgil, "Edoctas")
        daEdoctao.Fill(dsAgil, "Edoctao")
        daFacturas.Fill(dsAgil, "Facturas")
        daHista.Fill(dsAgil, "Hista")
        daUdis.Fill(dsAgil, "Udis")
        daClientes.Fill(dsAgil, "Clientes")

        drCliente = dsAgil.Tables("Clientes").Rows(0)

        cTipo = drCliente("Tipo")
        cDescr = drCliente("Descr")
        nTasaIVACliente = drCliente("TasaIVACliente")

        GroupBox1.Text = "Contrato : " & txtAnexo.Text & " " & cDescr

        cFondeo = drAnexo("Fondeo")
        If cTipar = "P" Then
            MsgBox("No existen finiquitos para Arrendamiento Puro", MsgBoxStyle.Critical, "Mensaje del Sistema")
            Me.Close()
        ElseIf cTipar = "S" Then
            MsgBox("No existen finiquitos para Crédito Simple", MsgBoxStyle.Critical, "Mensaje del Sistema")
            Me.Close()
        ElseIf cFondeo = "02" Then
            MsgBox("No existen prepagos en contratos descontados con NAFIN", MsgBoxStyle.Critical, "Mensaje del Sistema")
            Me.Close()
        ElseIf cFondeo = "03" Then
            MsgBox("No existen prepagos en contratos descontados con FIRA", MsgBoxStyle.Critical, "Mensaje del Sistema")
            Me.Close()
        ElseIf cFondeo = "04" Then
            MsgBox("No existen prepagos en contratos PARAFINANCIEROS", MsgBoxStyle.Critical, "Mensaje del Sistema")
            Me.Close()
        ElseIf drAnexo("Flcan") <> "A" Then
            MsgBox("No se puede realizar el cálculo para un contrato NO ACTIVO", MsgBoxStyle.Critical, "Mensaje del Sistema")
            Me.Close()
        ElseIf dsAgil.Tables("Anexos").Rows.Count() = 0 Then

            ' Validando que el Contrato esté en cartera 

            MsgBox("No existe la tabla de amortización de este contrato", MsgBoxStyle.Critical, "Mensaje del Sistema")
            Me.Close()

        End If

        GroupBox1.Visible = True
        btnProcesar.Enabled = False

        cTipar = drAnexo("Tipar")
        cFechacon = drAnexo("Fechacon")
        cTipta = drAnexo("Tipta")
        nDifer = drAnexo("Difer")
        nTasas = drAnexo("Tasas")
        nTasaFact = drAnexo("Tasas")
        nTasaPen = drAnexo("Taspen")
        cFinse = drAnexo("Finse")
        cAdeudo = drAnexo("Adeudo")
        nImpEq = drAnexo("ImpEq")
        nIvaeq = drAnexo("Ivaeq")
        nAmorin = drAnexo("Amorin")

        ' Trae la Opción de Compra y el IVA de la Opción de Compra; para este último si la fecha de contratación es anterior
        ' al 1o. de enero de 2010 debe calcular el IVA al 16% ya que los contratos activados a partir del 1o. de enero
        ' de 2010 ya contendrán el 16% de IVA en el campo IvaOpcion

        nOpcion = drAnexo("Opcion")
        If cFechacon < "20100101" Then
            nOpcion = Round(nOpcion * (1 + nPorcentajeIVA), 2)
        Else
            nOpcion = nOpcion + drAnexo("IvaOpcion")
        End If

        ' Determina saldo de Rentas en Depósito

        nRD = drAnexo("RD")
        nImpRD = drAnexo("ImpDG")
        nIvaRD = drAnexo("IvaDG")

        ' Determina monto original de Depósito en Garantía

        nDG = drAnexo("DG")
        nImpDG = drAnexo("ImpRD")
        nIvaDG = drAnexo("IvaRD")

        If cFinse = "S" Then

            nSaldoSeguro = 0
            lSalir = False

            For Each drEdoctas In dsAgil.Tables("Edoctas").Rows

                ' Se debe tomar el saldo insoluto del seguro que no haya sido facturado

                If drEdoctas("Nufac") = 0 And drEdoctas("Indrec") = "S" And lSalir = False Then
                    nSaldoSeguro = drEdoctas("Saldo")
                    lSalir = True
                End If

            Next

        End If

        If cAdeudo = "S" Then

            nSaldoOtros = 0
            lSalir = False

            For Each drEdoctao In dsAgil.Tables("Edoctao").Rows

                ' Se busca el saldo insoluto de otros adeudos que no haya sido facturado

                If drEdoctao("Nufac") = 0 And drEdoctao("Indrec") = "S" And lSalir = False Then
                    nSaldoOtros = drEdoctao("Saldo")
                    lSalir = True
                End If

            Next

        End If

        ' Trae el saldo insoluto del equipo y (si procede) el IVA diferido del Capital

        lSalir = False
        For Each drEdoctav In dsAgil.Tables("Edoctav").Rows
            If drEdoctav("Nufac") = 0 Then
                nIvaDiferido += drEdoctav("IvaCapital")
                If lSalir = False Then
                    cLetra = drEdoctav("Letra")
                    nSaldoEquipo = drEdoctav("Saldo")
                    CalcInte(dsAgil.Tables("Facturas").Rows, dsAgil.Tables("Hista").Rows, nTasaFact, nDiasFact, nInteresEquipo, cFecha, cAnexo, cFechacon, cLetra, nSaldoEquipo, cTipta, nDifer)
                    If nDiasFact > 0 And nTasaFact = nDifer Then
                        MsgBox("Error en tasas de facturación; por lo que NO se puede calcular el finiquito", MsgBoxStyle.Exclamation, "Mensaje")
                        Me.Close()
                    End If
                    If cFinse = "S" Then
                        nInteresSeguro = Round(nSaldoSeguro * nTasaFact / 36000 * nDiasFact, 2)
                    End If
                    If nSaldoOtros > 0 Then
                        nInteresOtros = Round(nSaldoOtros * nTasaFact / 36000 * nDiasFact, 2)
                    End If
                    lSalir = True
                End If
            End If
        Next

        ' Si existe IVA diferido del Capital y la fecha de contratación es anterior al 1o. de enero de 2010 debe calcular el IVA
        ' al 16% ya que los contratos activados a partir del 1o. de enero de 2010 ya contendrán el 16% de IVA en el campo IvaCapital

        If nIvaDiferido > 0 Then
            If cFechacon < "20100101" Then
                nIvaDiferido = Round(nSaldoEquipo * nPorcentajeIVA, 2)
            End If
        End If

        ' Se debe checar el saldo de Facturas de Renta

        For Each drFactura In dsAgil.Tables("Facturas").Rows
            cIndpag = drFactura("IndPag")
            nFactura = drFactura("Factura")
            nSaldofac = 0
            If cIndpag <> "P" Then
                nSaldofac = drFactura("SaldoFac")
                nDiasMora = 0
                nMora = 0
                nIvaMora = 0
                nTasa = drFactura("Tasa") + drFactura("Difer")
                nIva = drFactura("Ivapr") + drFactura("Ivase")
                nDias = drFactura("Dias")

                If Trim(drFactura("FePag")) = "" Then
                    nDiasMora = DateDiff(DateInterval.Day, CTOD(drFactura("Feven")), CTOD(cFecha))
                Else
                    If drFactura("Feven") >= drFactura("Fepag") Then
                        nDiasMora = DateDiff(DateInterval.Day, CTOD(drFactura("Feven")), CTOD(cFecha))
                    Else
                        nDiasMora = DateDiff(DateInterval.Day, CTOD(drFactura("Fepag")), CTOD(cFecha))
                    End If
                End If
                If nDiasMora < 0 Then
                    nDiasMora = 0
                End If

                If nDiasMora > 0 Then
                    CalcMora(cTipar, cTipo, cFecha, drUdis, nSaldofac, nTasa * 2, nDiasMora, nMora, nIvaMora, nTasaIVACliente)
                Else
                    nDiasMora = 0
                End If
                nAdeudo1 += nSaldofac
                nAdeudo2 += Round(nMora, 2)
                nAdeudo3 += Round(nIvaMora, 2)
            End If
        Next

        If nDG = 0 And nImpDG > 0 Then

            ' Existe Depósito en Garantía de Arrendamiento Financiero el cual se fue bonificando
            ' mensualmente por lo que debe determinarse el saldo restante

            nSaldoBonifica = Round(nSaldoEquipo * ((nImpDG + nIvaDG) / (nImpEq - nIvaeq - nAmorin)), 2)

            If cFechacon < "20100101" Then
                nImpDG = Round(nSaldoBonifica / 1.15, 2)
                nIvaDG = Round(nImpDG * 0.15, 2)
            Else
                nImpDG = Round(nSaldoBonifica / (1 + nPorcentajeIVA), 2)
                nIvaDG = Round(nImpDG * nPorcentajeIVA, 2)
            End If

        End If

        If nDG > 0 And nImpDG > 0 Then

            ' Existe Depósito en Garantía de Crédito Refaccionario el cual se reembolsa al final
            ' del plazo o al momento del finiquito por lo que no se modifica el valor que trae
            ' nImpDG ni el valor de nIvaDG

        End If

        nInteres = Round(nInteresEquipo + nInteresSeguro + nInteresOtros, 2)
        dFechaInicial = DateAdd(DateInterval.Day, -nDiasFact, CTOD(cFecha)).ToShortDateString
        dFechaFinal = CTOD(cFecha)

        ' En Arrendamiento Financiero siempre existe IVA de los intereses;
        ' en Crédito Refaccionario y en Crédito Simple solo existe IVA de los intereses cuando se trate de un cliente
        ' persona física sin actividad empresarial

        If cTipar = "F" Or (cTipar = "R" And cTipo = "F") Then
            nIvaInteres = CalcIvaU(dsAgil.Tables("Udis").Rows, nSaldoEquipo, nTasaFact, DTOC(dFechaInicial), DTOC(dFechaFinal), nUdiInicial, nUdiFinal, nPorcentajeIVA)
            If nDiasFact > 0 And (nUdiInicial = 0 Or nUdiFinal = 0) Then
                MsgBox("Error en los valores de las UDIS", MsgBoxStyle.Exclamation, "Mensaje")
                Me.Close()
            End If
            If cTipo = "F" Then
                nIvaInteres = Round(nIvaInteres + (nInteresSeguro * nPorcentajeIVA), 2)
                nIvaInteres = Round(nIvaInteres + (nInteresOtros * nPorcentajeIVA), 2)
            End If
        Else
            If cTipo = "F" Then
                nIvaInteres = Round(nInteres * nPorcentajeIVA, 2)
            End If
        End If

        nComision = Round((nSaldoEquipo + nSaldoSeguro + nSaldoOtros) * nTasaPen / 100, 2)
        nIvaComision = Round(nComision * nPorcentajeIVA, 2)

        nImportePago = nSaldoEquipo - nImpDG - nIvaDG + nIvaDiferido + nSaldoSeguro + nSaldoOtros
        nImportePago += nInteres + nIvaInteres + nComision + nIvaComision
        nImportePago += nOpcion + nAdeudo1 + nAdeudo2 + nAdeudo3 - nImpRD - nIvaRD

        If nImportePago < 0 Then
            nSaldoafavor = Abs(nImportePago)
            nImportePago = 0
            txtSaldoafavor.Text = FormatNumber(nSaldoafavor, 2)
            lblSaldoafavor.Visible = True
            txtSaldoafavor.Visible = True
        End If

        txtSaldoEquipo.Text = FormatNumber(nSaldoEquipo, 2)
        txtImpDG.Text = FormatNumber(nImpDG, 2)
        txtIvaDG.Text = FormatNumber(nIvaDG, 2)
        txtIvaDiferido.Text = FormatNumber(nIvaDiferido, 2)
        txtSaldoSeguro.Text = FormatNumber(nSaldoSeguro, 2)
        txtSaldoOtros.Text = FormatNumber(nSaldoOtros, 2)
        txtImpRD.Text = FormatNumber(nImpRD, 2)
        txtIvaRD.Text = FormatNumber(nIvaRD, 2)
        txtDiasIntereses.Text = FormatNumber(nDiasFact, 0)
        txtTasaAplicada.Text = FormatNumber(nTasaFact, 4)
        txtIntereses.Text = FormatNumber(nInteres, 2)
        txtUDIInicial.Text = FormatNumber(nUdiInicial, 6)
        txtUDIFinal.Text = FormatNumber(nUdiFinal, 6)
        txtIvaIntereses.Text = FormatNumber(nIvaInteres, 2)
        txtPenalizacion.Text = FormatNumber(nTasaPen, 2)
        txtComision.Text = FormatNumber(nComision, 2)
        txtIvaComision.Text = FormatNumber(nIvaComision, 2)
        txtOpcion.Text = FormatNumber(nOpcion, 2)
        txtRentasVencidas.Text = FormatNumber(nAdeudo1, 2)
        txtMoratorios.Text = FormatNumber(nAdeudo2, 2)
        txtIvaMoratorios.Text = FormatNumber(nAdeudo3, 2)
        txtImportePago.Text = FormatNumber(nImportePago, 2)

        cm1.Dispose()
        cm2.Dispose()
        cm3.Dispose()
        cm4.Dispose()
        cm5.Dispose()
        cm6.Dispose()
        cm7.Dispose()
        cm8.Dispose()

    End Sub

    Private Sub btnCalcular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCalcular.Click

        Dim nDiasIntereses As Decimal = 0
        Dim nOC As Decimal = 0
        Dim nPenalizacion As Decimal = 0

        ' Los únicos datos que se pueden actualizar son la tasa de penalización, los días de intereses
        ' y la opción de compra

        nPenalizacion = CDbl(txtPenalizacion.Text)
        nDiasIntereses = CDbl(txtDiasIntereses.Text)
        nOC = CDbl(txtOpcion.Text)

        ' El valor de nTasaFact debe ser regresado al valor de nTasas porque en el procedimiento CalcInte
        ' le añade el diferencial

        nTasaFact = nTasas

        nUdiInicial = 0
        nUdiFinal = 0
        nInteres = txtIntereses.Text
        nIvaInteres = txtIvaIntereses.Text

        cFecha = DTOC(DateTimePicker1.Value)

        ' Se recalcula la Comisión y el IVA de la Comisión

        nComision = Round((nSaldoEquipo + nSaldoSeguro + nSaldoOtros) * nPenalizacion / 100, 2)
        nIvaComision = Round(nComision * nPorcentajeIVA, 2)
        txtComision.Text = FormatNumber(nComision, 2)
        txtIvaComision.Text = FormatNumber(nIvaComision, 2)

        ' Se recalculan los intereses así como el IVA de los intereses

        If nDiasIntereses > 0 Then

            nInteresEquipo = 0
            nInteresSeguro = 0
            nInteresOtros = 0
            CalcInte(dsAgil.Tables("Facturas").Rows, dsAgil.Tables("Hista").Rows, nTasaFact, nDiasFact, nInteresEquipo, cFecha, cAnexo, cFechacon, cLetra, nSaldoEquipo, cTipta, nDifer)

            ' Al regresar de la función CalcInte, en nInteresEquipo tenemos el interés COMPLETO del equipo
            ' por lo que debemos obtener la proporción que le corresponde a nDiasIntereses

            nInteresEquipo = Round(nDiasIntereses * nInteresEquipo / nDiasFact, 2)

            dFechaInicial = DateAdd(DateInterval.Day, -nDiasFact, CTOD(cFecha))
            dFechaFinal = DateAdd(DateInterval.Day, nDiasIntereses, dFechaInicial)

            ' En arrendamiento financiero siempre existe IVA de los intereses;
            ' en crédito refaccionario solo existe IVA de los intereses cuando se trate de un cliente
            ' persona física sin empresarial

            If cTipar = "F" Or (cTipar = "R" And cTipo = "F") Then

                nIvaInteres = CalcIvaU(dsAgil.Tables("Udis").Rows, nSaldoEquipo + nSaldoSeguro, nTasaFact, DTOC(dFechaInicial), DTOC(dFechaFinal), nUdiInicial, nUdiFinal, nPorcentajeIVA)
                If nDiasFact > 0 And (nUdiInicial = 0 Or nUdiFinal = 0) Then
                    MsgBox("Error en los valores de las UDIS", MsgBoxStyle.Exclamation, "Mensaje")
                    Me.Close()
                End If

            End If

            ' Si se trata de un cliente persona física sin actividad empresarial, es a este tipo de persona
            ' a la única que aplica el IVA de Otros Adeudos recordando que a partir de julio 2008 a este saldo
            ' se le da tratamiento como si fuera un crédito simple

            If cTipo = "F" Then
                nIvaInteres = Round(nIvaInteres + (nInteresOtros * nPorcentajeIVA), 2)
            End If

            nInteresSeguro = Round(nSaldoSeguro * nTasaFact / 36000 * nDiasIntereses, 2)
            nInteresOtros = Round(nSaldoOtros * nTasaFact / 36000 * nDiasIntereses, 2)

            nInteres = Round(nInteresEquipo + nInteresSeguro + nInteresOtros, 2)

        Else

            nDiasIntereses = 0
            nInteres = 0
            nIvaInteres = 0
            nUdiInicial = 0
            nUdiFinal = 0

        End If

        nImportePago = nSaldoEquipo - nImpDG - nIvaDG + nIvaDiferido + nSaldoSeguro + nSaldoOtros
        nImportePago += nInteres + nIvaInteres + nComision + Round(nComision * nPorcentajeIVA, 2)
        nImportePago += nOC + nAdeudo1 + nAdeudo2 + nAdeudo3 - nImpRD - nIvaRD

        If nImportePago < 0 Then
            nSaldoafavor = Abs(nImportePago)
            nImportePago = 0
            txtSaldoafavor.Text = FormatNumber(nSaldoafavor, 2)
            lblSaldoafavor.Visible = True
            txtSaldoafavor.Visible = True
        Else
            nSaldoafavor = 0
            lblSaldoafavor.Visible = False
            txtSaldoafavor.Visible = False
        End If

        txtUDIInicial.Text = FormatNumber(nUdiInicial, 6)
        txtUDIFinal.Text = FormatNumber(nUdiFinal, 6)
        txtIntereses.Text = FormatNumber(nInteres, 2)
        txtIvaIntereses.Text = FormatNumber(nIvaInteres, 2)
        txtImportePago.Text = FormatNumber(nImportePago, 2)

    End Sub

    Private Sub btnImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnImprimir.Click

        ' Declaración de variables de conexión ADO .NET

        Dim dsImprimir As New DataSet()
        Dim daFiniquito As New SqlDataAdapter()
        Dim drFiniquito As DataRow
        Dim newrptFiniquito As New rptFiniquito()
        Dim cReportTitle As String
        Dim cFecha As String

        btnCalcular.Enabled = False
        cFecha = DTOC(DateTimePicker1.Value)

        dtFiniquito.Clear()
        drFiniquito = dtFiniquito.NewRow()
        drFiniquito("Nombre") = cDescr
        drFiniquito("Contrato") = txtAnexo.Text
        drFiniquito("SaldoEquipo") = txtSaldoEquipo.Text
        drFiniquito("SaldoOtros") = txtSaldoOtros.Text
        drFiniquito("ImpDG") = txtImpDG.Text
        drFiniquito("IvaDG") = txtIvaDG.Text
        drFiniquito("IvaDiferido") = txtIvaDiferido.Text
        drFiniquito("SaldoSeguro") = txtSaldoSeguro.Text
        drFiniquito("ImpRD") = txtImpRD.Text
        drFiniquito("IvaRD") = txtIvaRD.Text
        drFiniquito("Interes") = txtIntereses.Text
        drFiniquito("IvaInteres") = txtIvaIntereses.Text
        drFiniquito("Comision") = txtComision.Text
        drFiniquito("IvaComision") = txtIvaComision.Text
        drFiniquito("Opcion") = txtOpcion.Text
        drFiniquito("RentasVencidas") = txtRentasVencidas.Text
        drFiniquito("Moratorios") = txtMoratorios.Text
        drFiniquito("IvaMoratorios") = txtIvaMoratorios.Text
        drFiniquito("DiasIntereses") = txtDiasIntereses.Text
        drFiniquito("Tasa") = txtTasaAplicada.Text
        drFiniquito("Penalizacion") = txtPenalizacion.Text
        drFiniquito("UDIInicial") = txtUDIInicial.Text
        drFiniquito("UDIFinal") = txtUDIFinal.Text
        drFiniquito("GranTotal") = txtImportePago.Text
        dtFiniquito.Rows.Add(drFiniquito)

        dsImprimir.Tables.Add(dtFiniquito)

        ' Descomentar la siguiente línea en caso de que se deseara modificar el reporte rptFiniquito
        ' dsImprimir.WriteXml("C:\Schema25.xml", XmlWriteMode.WriteSchema)

        newrptFiniquito.SetDataSource(dsImprimir)

        cReportTitle = "TOLUCA, ESTADO DE MEXICO A " & Mes(cFecha)
        newrptFiniquito.PrintOptions.PaperOrientation = PaperOrientation.Portrait
        newrptFiniquito.SummaryInfo.ReportTitle = cReportTitle
        newrptFiniquito.PrintToPrinter(1, False, 0, 0)

        dsImprimir.Dispose()

        MsgBox("Reporte Impreso", MsgBoxStyle.Information, "Mensaje del Sistema")

    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class
