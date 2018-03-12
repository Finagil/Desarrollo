Option Explicit On

Imports System.Data.SqlClient
Imports System.IO

Public Class frmAgil

    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents mnuConcAjus As System.Windows.Forms.MenuItem
    Friend WithEvents mnuProm As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCred As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCob As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCont As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSist As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCons As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRep As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCierre As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAdelanto As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRegenera As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDatosCon As System.Windows.Forms.MenuItem
    Friend WithEvents mnuActiAnex As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAltaClie As System.Windows.Forms.MenuItem
    Friend WithEvents mnuContClie As System.Windows.Forms.MenuItem
    Friend WithEvents mnuContSoli As System.Windows.Forms.MenuItem
    Friend WithEvents mnuReciPago As System.Windows.Forms.MenuItem
    Friend WithEvents mnuPondera As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCierreCo As System.Windows.Forms.MenuItem
    Friend WithEvents mnuImprePol As System.Windows.Forms.MenuItem
    Friend WithEvents mnuGenCatal As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRepoProm As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRepAntig As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSalir As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCaptFact As System.Windows.Forms.MenuItem
    Friend WithEvents mnuPrendaria As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCostoIng As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFisicas As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFacSaldo As System.Windows.Forms.MenuItem
    Friend WithEvents mnuPortacar As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDesactiv As System.Windows.Forms.MenuItem
    Friend WithEvents mnuPrepames As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRepCierre As System.Windows.Forms.MenuItem
    Friend WithEvents mnuBuroCred As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRepoActi As System.Windows.Forms.MenuItem
    Friend WithEvents mnuTermimes As System.Windows.Forms.MenuItem
    Friend WithEvents mnuReproInt As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRepCobra As System.Windows.Forms.MenuItem
    Friend WithEvents mnuIntIvaPP As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSeguiCre As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRepoDisp As System.Windows.Forms.MenuItem
    Friend WithEvents mnuTesoreria As System.Windows.Forms.MenuItem
    Friend WithEvents mnuMorales As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRepAnti2 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRepInter As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRepDiezP As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCalcfini As System.Windows.Forms.MenuItem
    Friend WithEvents mnuImprActi As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRepGaran As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDCPorAnexo As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDCPorNombre As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFiniquito As System.Windows.Forms.MenuItem
    Friend WithEvents mnuACPorAnexo As System.Windows.Forms.MenuItem
    Friend WithEvents mnuACPorNombre As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCFPorAnexo As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCFPorNombre As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRTPorAnexo As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFCPorAnexo As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFCPorNombre As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSeguros As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCaptValo As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCaptSegu As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRepSaldo As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFormMens As System.Windows.Forms.MenuItem
    Friend WithEvents mnuConsRefe As System.Windows.Forms.MenuItem
    Friend WithEvents mnuActuaTas As System.Windows.Forms.MenuItem
    Friend WithEvents mnuActuaUdis As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDRPorFecha As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDRPorCliente As System.Windows.Forms.MenuItem
    Friend WithEvents mnuProyecta As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRepSald2 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuComputo As System.Windows.Forms.MenuItem
    Friend WithEvents mnuConsAviso As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRepSalCli As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRecupera As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCosto As System.Windows.Forms.MenuItem
    Friend WithEvents mnuBitacora As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSegBitacora As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSeguManu As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFacturar As System.Windows.Forms.MenuItem
    Friend WithEvents mnuGeneFac As System.Windows.Forms.MenuItem
    Friend WithEvents mnuImpreFac As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRelaFact As System.Windows.Forms.MenuItem
    Friend WithEvents mnuArchivosDCI As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCifrasDCI As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAvisos As System.Windows.Forms.MenuItem
    Friend WithEvents mnuGenAviso As System.Windows.Forms.MenuItem
    Friend WithEvents mnuImpAcuses As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRelaResp As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCapitalizacion As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCAPorAnexo As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDomicilio As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCotizar As System.Windows.Forms.MenuItem
    Friend WithEvents mnuIntCosto As System.Windows.Forms.MenuItem
    Friend WithEvents mnuImprCert As System.Windows.Forms.MenuItem
    Friend WithEvents mnuECPorAnexo As System.Windows.Forms.MenuItem
    Friend WithEvents mnuECPorNombre As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCartas As System.Windows.Forms.MenuItem
    Friend WithEvents mnuReimprimir As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRiesgos As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCCartera As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCartaRat As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCRPorAnexo As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCRPorNombre As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRepoSegu As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRepoValo As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDepoRefe As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFega As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRepMenBancos As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSubirCE As System.Windows.Forms.MenuItem
    Friend WithEvents mnuPortaCon As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAvio As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAltaContratos As System.Windows.Forms.MenuItem
    Friend WithEvents mnuMinistraciones As System.Windows.Forms.MenuItem
    Friend WithEvents mnuReportes As System.Windows.Forms.MenuItem
    Friend WithEvents mnuModCtoAvio As System.Windows.Forms.MenuItem
    Friend WithEvents mnuImpCtoAvio As System.Windows.Forms.MenuItem
    Friend WithEvents mnuEdoCtaAvio As System.Windows.Forms.MenuItem
    Friend WithEvents mnuECTC As System.Windows.Forms.MenuItem
    Friend WithEvents mnuECPP As System.Windows.Forms.MenuItem
    Friend WithEvents mnuPagosPF As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAplicaDR As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSustrae As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRCS As System.Windows.Forms.MenuItem
    Friend WithEvents mnuPSC As System.Windows.Forms.MenuItem
    Friend WithEvents mnuEstratificacion As System.Windows.Forms.MenuItem
    Friend WithEvents mnuMemoria As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRE As System.Windows.Forms.MenuItem
    Friend WithEvents mnuPagares As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCapturaPMI As System.Windows.Forms.MenuItem
    Friend WithEvents mnuMinistracionesPorProductor As System.Windows.Forms.MenuItem
    Friend WithEvents mnuMinistracionesPorContrato As System.Windows.Forms.MenuItem
    Friend WithEvents mnuModCtoAvioPorProductor As System.Windows.Forms.MenuItem
    Friend WithEvents mnuModCtoAvioPorContrato As System.Windows.Forms.MenuItem
    Friend WithEvents mnuPagaresPorProductor As System.Windows.Forms.MenuItem
    Friend WithEvents mnuPagaresPorContrato As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCapturaPMIPorProductor As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCapturaPMIPorContrato As System.Windows.Forms.MenuItem
    Friend WithEvents mnuImpCtoAvioPorProductor As System.Windows.Forms.MenuItem
    Friend WithEvents mnuImpCtoAvioPorContrato As System.Windows.Forms.MenuItem
    Friend WithEvents mnuMinistracionFFP As System.Windows.Forms.MenuItem
    Friend WithEvents mnuMinistracionFP As System.Windows.Forms.MenuItem
    Friend WithEvents mnuLayOutAvio As System.Windows.Forms.MenuItem
    Friend WithEvents mnuControlPasivos As System.Windows.Forms.MenuItem
    Friend WithEvents mnuEdoCtaFB As System.Windows.Forms.MenuItem
    Friend WithEvents mnuPagosBF As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSaldosContingentes As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuGFE As System.Windows.Forms.MenuItem
    Friend WithEvents mnuEFE As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRepNafin As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAgil))
        Me.MainMenu1 = New System.Windows.Forms.MainMenu(Me.components)
        Me.mnuProm = New System.Windows.Forms.MenuItem
        Me.mnuCotizar = New System.Windows.Forms.MenuItem
        Me.mnuAltaClie = New System.Windows.Forms.MenuItem
        Me.mnuContClie = New System.Windows.Forms.MenuItem
        Me.mnuContSoli = New System.Windows.Forms.MenuItem
        Me.mnuCaptFact = New System.Windows.Forms.MenuItem
        Me.mnuPrendaria = New System.Windows.Forms.MenuItem
        Me.mnuActiAnex = New System.Windows.Forms.MenuItem
        Me.mnuDesactiv = New System.Windows.Forms.MenuItem
        Me.mnuCred = New System.Windows.Forms.MenuItem
        Me.mnuSeguiCre = New System.Windows.Forms.MenuItem
        Me.mnuCob = New System.Windows.Forms.MenuItem
        Me.mnuReciPago = New System.Windows.Forms.MenuItem
        Me.mnuAdelanto = New System.Windows.Forms.MenuItem
        Me.mnuACPorAnexo = New System.Windows.Forms.MenuItem
        Me.mnuACPorNombre = New System.Windows.Forms.MenuItem
        Me.mnuFiniquito = New System.Windows.Forms.MenuItem
        Me.mnuFCPorAnexo = New System.Windows.Forms.MenuItem
        Me.mnuFCPorNombre = New System.Windows.Forms.MenuItem
        Me.mnuDomicilio = New System.Windows.Forms.MenuItem
        Me.mnuImprActi = New System.Windows.Forms.MenuItem
        Me.mnuRepCobra = New System.Windows.Forms.MenuItem
        Me.mnuBitacora = New System.Windows.Forms.MenuItem
        Me.mnuSegBitacora = New System.Windows.Forms.MenuItem
        Me.mnuAplicaDR = New System.Windows.Forms.MenuItem
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.mnuGFE = New System.Windows.Forms.MenuItem
        Me.mnuEFE = New System.Windows.Forms.MenuItem
        Me.mnuTesoreria = New System.Windows.Forms.MenuItem
        Me.mnuRecupera = New System.Windows.Forms.MenuItem
        Me.mnuRepGaran = New System.Windows.Forms.MenuItem
        Me.mnuRepoDisp = New System.Windows.Forms.MenuItem
        Me.mnuRepNafin = New System.Windows.Forms.MenuItem
        Me.mnuActuaTas = New System.Windows.Forms.MenuItem
        Me.mnuActuaUdis = New System.Windows.Forms.MenuItem
        Me.mnuSeguManu = New System.Windows.Forms.MenuItem
        Me.mnuFacturar = New System.Windows.Forms.MenuItem
        Me.mnuGeneFac = New System.Windows.Forms.MenuItem
        Me.mnuImpreFac = New System.Windows.Forms.MenuItem
        Me.mnuImpAcuses = New System.Windows.Forms.MenuItem
        Me.mnuRelaFact = New System.Windows.Forms.MenuItem
        Me.mnuArchivosDCI = New System.Windows.Forms.MenuItem
        Me.mnuCifrasDCI = New System.Windows.Forms.MenuItem
        Me.mnuAvisos = New System.Windows.Forms.MenuItem
        Me.mnuGenAviso = New System.Windows.Forms.MenuItem
        Me.mnuDepoRefe = New System.Windows.Forms.MenuItem
        Me.mnuLayOutAvio = New System.Windows.Forms.MenuItem
        Me.mnuSeguros = New System.Windows.Forms.MenuItem
        Me.mnuCaptValo = New System.Windows.Forms.MenuItem
        Me.mnuCaptSegu = New System.Windows.Forms.MenuItem
        Me.mnuFormMens = New System.Windows.Forms.MenuItem
        Me.mnuCont = New System.Windows.Forms.MenuItem
        Me.mnuImprCert = New System.Windows.Forms.MenuItem
        Me.mnuECPorAnexo = New System.Windows.Forms.MenuItem
        Me.mnuECPorNombre = New System.Windows.Forms.MenuItem
        Me.mnuComputo = New System.Windows.Forms.MenuItem
        Me.mnuPondera = New System.Windows.Forms.MenuItem
        Me.mnuProyecta = New System.Windows.Forms.MenuItem
        Me.mnuRelaResp = New System.Windows.Forms.MenuItem
        Me.mnuIntCosto = New System.Windows.Forms.MenuItem
        Me.mnuCosto = New System.Windows.Forms.MenuItem
        Me.mnuCierre = New System.Windows.Forms.MenuItem
        Me.mnuCierreCo = New System.Windows.Forms.MenuItem
        Me.mnuTermimes = New System.Windows.Forms.MenuItem
        Me.mnuImprePol = New System.Windows.Forms.MenuItem
        Me.mnuConcAjus = New System.Windows.Forms.MenuItem
        Me.mnuGenCatal = New System.Windows.Forms.MenuItem
        Me.mnuSubirCE = New System.Windows.Forms.MenuItem
        Me.mnuRepCierre = New System.Windows.Forms.MenuItem
        Me.mnuRepSaldo = New System.Windows.Forms.MenuItem
        Me.mnuRepoActi = New System.Windows.Forms.MenuItem
        Me.mnuPrepames = New System.Windows.Forms.MenuItem
        Me.mnuRepDiezP = New System.Windows.Forms.MenuItem
        Me.mnuRepAnti2 = New System.Windows.Forms.MenuItem
        Me.mnuRepInter = New System.Windows.Forms.MenuItem
        Me.mnuIntIvaPP = New System.Windows.Forms.MenuItem
        Me.mnuReproInt = New System.Windows.Forms.MenuItem
        Me.mnuRepMenBancos = New System.Windows.Forms.MenuItem
        Me.mnuRepSald2 = New System.Windows.Forms.MenuItem
        Me.mnuSist = New System.Windows.Forms.MenuItem
        Me.mnuRegenera = New System.Windows.Forms.MenuItem
        Me.mnuRTPorAnexo = New System.Windows.Forms.MenuItem
        Me.mnuBuroCred = New System.Windows.Forms.MenuItem
        Me.mnuMorales = New System.Windows.Forms.MenuItem
        Me.mnuFisicas = New System.Windows.Forms.MenuItem
        Me.mnuCostoIng = New System.Windows.Forms.MenuItem
        Me.mnuPortacar = New System.Windows.Forms.MenuItem
        Me.mnuCapitalizacion = New System.Windows.Forms.MenuItem
        Me.mnuCAPorAnexo = New System.Windows.Forms.MenuItem
        Me.mnuCartas = New System.Windows.Forms.MenuItem
        Me.mnuReimprimir = New System.Windows.Forms.MenuItem
        Me.mnuCons = New System.Windows.Forms.MenuItem
        Me.mnuDatosCon = New System.Windows.Forms.MenuItem
        Me.mnuDCPorAnexo = New System.Windows.Forms.MenuItem
        Me.mnuDCPorNombre = New System.Windows.Forms.MenuItem
        Me.mnuFacSaldo = New System.Windows.Forms.MenuItem
        Me.mnuCalcfini = New System.Windows.Forms.MenuItem
        Me.mnuCFPorAnexo = New System.Windows.Forms.MenuItem
        Me.mnuCFPorNombre = New System.Windows.Forms.MenuItem
        Me.mnuConsRefe = New System.Windows.Forms.MenuItem
        Me.mnuDRPorFecha = New System.Windows.Forms.MenuItem
        Me.mnuDRPorCliente = New System.Windows.Forms.MenuItem
        Me.mnuConsAviso = New System.Windows.Forms.MenuItem
        Me.mnuRepSalCli = New System.Windows.Forms.MenuItem
        Me.mnuRep = New System.Windows.Forms.MenuItem
        Me.mnuRepoProm = New System.Windows.Forms.MenuItem
        Me.mnuRepAntig = New System.Windows.Forms.MenuItem
        Me.mnuRepoSegu = New System.Windows.Forms.MenuItem
        Me.mnuRepoValo = New System.Windows.Forms.MenuItem
        Me.mnuRiesgos = New System.Windows.Forms.MenuItem
        Me.mnuCCartera = New System.Windows.Forms.MenuItem
        Me.mnuCartaRat = New System.Windows.Forms.MenuItem
        Me.mnuCRPorAnexo = New System.Windows.Forms.MenuItem
        Me.mnuCRPorNombre = New System.Windows.Forms.MenuItem
        Me.mnuFega = New System.Windows.Forms.MenuItem
        Me.mnuPortaCon = New System.Windows.Forms.MenuItem
        Me.mnuAvio = New System.Windows.Forms.MenuItem
        Me.mnuAltaContratos = New System.Windows.Forms.MenuItem
        Me.mnuModCtoAvio = New System.Windows.Forms.MenuItem
        Me.mnuModCtoAvioPorProductor = New System.Windows.Forms.MenuItem
        Me.mnuModCtoAvioPorContrato = New System.Windows.Forms.MenuItem
        Me.mnuImpCtoAvio = New System.Windows.Forms.MenuItem
        Me.mnuImpCtoAvioPorProductor = New System.Windows.Forms.MenuItem
        Me.mnuImpCtoAvioPorContrato = New System.Windows.Forms.MenuItem
        Me.mnuSustrae = New System.Windows.Forms.MenuItem
        Me.mnuRCS = New System.Windows.Forms.MenuItem
        Me.mnuPSC = New System.Windows.Forms.MenuItem
        Me.mnuEstratificacion = New System.Windows.Forms.MenuItem
        Me.mnuMemoria = New System.Windows.Forms.MenuItem
        Me.mnuRE = New System.Windows.Forms.MenuItem
        Me.mnuMinistraciones = New System.Windows.Forms.MenuItem
        Me.mnuMinistracionesPorProductor = New System.Windows.Forms.MenuItem
        Me.mnuMinistracionesPorContrato = New System.Windows.Forms.MenuItem
        Me.mnuReportes = New System.Windows.Forms.MenuItem
        Me.mnuMinistracionFFP = New System.Windows.Forms.MenuItem
        Me.mnuMinistracionFP = New System.Windows.Forms.MenuItem
        Me.mnuEdoCtaAvio = New System.Windows.Forms.MenuItem
        Me.mnuECPP = New System.Windows.Forms.MenuItem
        Me.mnuECTC = New System.Windows.Forms.MenuItem
        Me.mnuPagosPF = New System.Windows.Forms.MenuItem
        Me.mnuPagares = New System.Windows.Forms.MenuItem
        Me.mnuPagaresPorProductor = New System.Windows.Forms.MenuItem
        Me.mnuPagaresPorContrato = New System.Windows.Forms.MenuItem
        Me.mnuCapturaPMI = New System.Windows.Forms.MenuItem
        Me.mnuCapturaPMIPorProductor = New System.Windows.Forms.MenuItem
        Me.mnuCapturaPMIPorContrato = New System.Windows.Forms.MenuItem
        Me.mnuControlPasivos = New System.Windows.Forms.MenuItem
        Me.mnuEdoCtaFB = New System.Windows.Forms.MenuItem
        Me.mnuPagosBF = New System.Windows.Forms.MenuItem
        Me.mnuSaldosContingentes = New System.Windows.Forms.MenuItem
        Me.MenuItem5 = New System.Windows.Forms.MenuItem
        Me.mnuSalir = New System.Windows.Forms.MenuItem
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuProm, Me.mnuCred, Me.mnuCob, Me.mnuTesoreria, Me.mnuSeguros, Me.mnuCont, Me.mnuSist, Me.mnuCons, Me.mnuRep, Me.mnuRiesgos, Me.mnuAvio, Me.mnuSalir})
        '
        'mnuProm
        '
        Me.mnuProm.Index = 0
        Me.mnuProm.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuCotizar, Me.mnuAltaClie, Me.mnuContClie, Me.mnuContSoli, Me.mnuCaptFact, Me.mnuPrendaria, Me.mnuActiAnex, Me.mnuDesactiv})
        Me.mnuProm.Text = "&Promoción"
        '
        'mnuCotizar
        '
        Me.mnuCotizar.Enabled = False
        Me.mnuCotizar.Index = 0
        Me.mnuCotizar.Text = "Cotizaciones"
        '
        'mnuAltaClie
        '
        Me.mnuAltaClie.Enabled = False
        Me.mnuAltaClie.Index = 1
        Me.mnuAltaClie.Text = "Alta de Clientes"
        '
        'mnuContClie
        '
        Me.mnuContClie.Index = 2
        Me.mnuContClie.Text = "Control de Clientes"
        '
        'mnuContSoli
        '
        Me.mnuContSoli.Enabled = False
        Me.mnuContSoli.Index = 3
        Me.mnuContSoli.Text = "Control de Solicitudes"
        '
        'mnuCaptFact
        '
        Me.mnuCaptFact.Index = 4
        Me.mnuCaptFact.Text = "Facturas Originales"
        '
        'mnuPrendaria
        '
        Me.mnuPrendaria.Enabled = False
        Me.mnuPrendaria.Index = 5
        Me.mnuPrendaria.Text = "Garantía Prendaria"
        '
        'mnuActiAnex
        '
        Me.mnuActiAnex.Index = 6
        Me.mnuActiAnex.Text = "Activación de Anexos"
        '
        'mnuDesactiv
        '
        Me.mnuDesactiv.Enabled = False
        Me.mnuDesactiv.Index = 7
        Me.mnuDesactiv.Text = "Desactivar un Anexo"
        '
        'mnuCred
        '
        Me.mnuCred.Index = 1
        Me.mnuCred.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuSeguiCre})
        Me.mnuCred.Text = "&Crédito"
        '
        'mnuSeguiCre
        '
        Me.mnuSeguiCre.Enabled = False
        Me.mnuSeguiCre.Index = 0
        Me.mnuSeguiCre.Text = "Seguimiento de Crédito"
        '
        'mnuCob
        '
        Me.mnuCob.Enabled = False
        Me.mnuCob.Index = 2
        Me.mnuCob.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuReciPago, Me.mnuAdelanto, Me.mnuFiniquito, Me.mnuDomicilio, Me.mnuImprActi, Me.mnuRepCobra, Me.mnuBitacora, Me.mnuSegBitacora, Me.mnuAplicaDR, Me.MenuItem1, Me.MenuItem2, Me.mnuGFE, Me.mnuEFE})
        Me.mnuCob.Text = "C&obranza"
        '
        'mnuReciPago
        '
        Me.mnuReciPago.Enabled = False
        Me.mnuReciPago.Index = 0
        Me.mnuReciPago.Text = "Recepción de Pagos"
        '
        'mnuAdelanto
        '
        Me.mnuAdelanto.Enabled = False
        Me.mnuAdelanto.Index = 1
        Me.mnuAdelanto.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuACPorAnexo, Me.mnuACPorNombre})
        Me.mnuAdelanto.Text = "Adelantos a Capital"
        '
        'mnuACPorAnexo
        '
        Me.mnuACPorAnexo.Enabled = False
        Me.mnuACPorAnexo.Index = 0
        Me.mnuACPorAnexo.Text = "Por Anexo"
        '
        'mnuACPorNombre
        '
        Me.mnuACPorNombre.Enabled = False
        Me.mnuACPorNombre.Index = 1
        Me.mnuACPorNombre.Text = "Por Nombre"
        '
        'mnuFiniquito
        '
        Me.mnuFiniquito.Enabled = False
        Me.mnuFiniquito.Index = 2
        Me.mnuFiniquito.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFCPorAnexo, Me.mnuFCPorNombre})
        Me.mnuFiniquito.Text = "Finiquito de Contratos"
        '
        'mnuFCPorAnexo
        '
        Me.mnuFCPorAnexo.Enabled = False
        Me.mnuFCPorAnexo.Index = 0
        Me.mnuFCPorAnexo.Text = "Por Anexo"
        '
        'mnuFCPorNombre
        '
        Me.mnuFCPorNombre.Enabled = False
        Me.mnuFCPorNombre.Index = 1
        Me.mnuFCPorNombre.Text = "Por Nombre"
        '
        'mnuDomicilio
        '
        Me.mnuDomicilio.Enabled = False
        Me.mnuDomicilio.Index = 3
        Me.mnuDomicilio.Text = "Cambios de Domicilio y Retención"
        '
        'mnuImprActi
        '
        Me.mnuImprActi.Enabled = False
        Me.mnuImprActi.Index = 4
        Me.mnuImprActi.Text = "Imprimir Facturas de Activo Fijo"
        '
        'mnuRepCobra
        '
        Me.mnuRepCobra.Enabled = False
        Me.mnuRepCobra.Index = 5
        Me.mnuRepCobra.Text = "Reporte de Cobranza por día"
        '
        'mnuBitacora
        '
        Me.mnuBitacora.Enabled = False
        Me.mnuBitacora.Index = 6
        Me.mnuBitacora.Text = "Seguimiento de Cobranza"
        '
        'mnuSegBitacora
        '
        Me.mnuSegBitacora.Enabled = False
        Me.mnuSegBitacora.Index = 7
        Me.mnuSegBitacora.Text = "Reporte de Seguimiento"
        '
        'mnuAplicaDR
        '
        Me.mnuAplicaDR.Index = 8
        Me.mnuAplicaDR.Text = "Aplicación automatizada de pagos"
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 9
        Me.MenuItem1.Text = "Opción 10"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 10
        Me.MenuItem2.Text = "Opción 11"
        '
        'mnuGFE
        '
        Me.mnuGFE.Index = 11
        Me.mnuGFE.Text = "Generar Facturas Electrónicas"
        '
        'mnuEFE
        '
        Me.mnuEFE.Index = 12
        Me.mnuEFE.Text = "Enviar Facturas Electrónicas"
        '
        'mnuTesoreria
        '
        Me.mnuTesoreria.Index = 3
        Me.mnuTesoreria.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuRecupera, Me.mnuRepGaran, Me.mnuRepoDisp, Me.mnuRepNafin, Me.mnuActuaTas, Me.mnuActuaUdis, Me.mnuSeguManu, Me.mnuFacturar, Me.mnuDepoRefe, Me.mnuLayOutAvio})
        Me.mnuTesoreria.Text = "Tesorería"
        '
        'mnuRecupera
        '
        Me.mnuRecupera.Enabled = False
        Me.mnuRecupera.Index = 0
        Me.mnuRecupera.Text = "Recuperación de Cuentas por Cobrar"
        '
        'mnuRepGaran
        '
        Me.mnuRepGaran.Enabled = False
        Me.mnuRepGaran.Index = 1
        Me.mnuRepGaran.Text = "Reporte de Aforos"
        '
        'mnuRepoDisp
        '
        Me.mnuRepoDisp.Enabled = False
        Me.mnuRepoDisp.Index = 2
        Me.mnuRepoDisp.Text = "Contratos disponibles para dar en Garantía"
        '
        'mnuRepNafin
        '
        Me.mnuRepNafin.Enabled = False
        Me.mnuRepNafin.Index = 3
        Me.mnuRepNafin.Text = "Reporte de Contratos Fondeados con NAFIN o FIRA"
        '
        'mnuActuaTas
        '
        Me.mnuActuaTas.Enabled = False
        Me.mnuActuaTas.Index = 4
        Me.mnuActuaTas.Text = "Actualización de Tasas"
        '
        'mnuActuaUdis
        '
        Me.mnuActuaUdis.Enabled = False
        Me.mnuActuaUdis.Index = 5
        Me.mnuActuaUdis.Text = "Actualización de UDIs"
        '
        'mnuSeguManu
        '
        Me.mnuSeguManu.Enabled = False
        Me.mnuSeguManu.Index = 6
        Me.mnuSeguManu.Text = "Capturar Seguros Financiados"
        '
        'mnuFacturar
        '
        Me.mnuFacturar.Enabled = False
        Me.mnuFacturar.Index = 7
        Me.mnuFacturar.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuGeneFac, Me.mnuImpreFac, Me.mnuImpAcuses, Me.mnuRelaFact, Me.mnuArchivosDCI, Me.mnuCifrasDCI, Me.mnuAvisos, Me.mnuGenAviso})
        Me.mnuFacturar.Text = "Avisos de vencimiento de Renta"
        '
        'mnuGeneFac
        '
        Me.mnuGeneFac.Enabled = False
        Me.mnuGeneFac.Index = 0
        Me.mnuGeneFac.Text = "Generación de Avisos de Vencimiento"
        '
        'mnuImpreFac
        '
        Me.mnuImpreFac.Enabled = False
        Me.mnuImpreFac.Index = 1
        Me.mnuImpreFac.Text = "Impresión de Avisos de Vencimiento"
        '
        'mnuImpAcuses
        '
        Me.mnuImpAcuses.Enabled = False
        Me.mnuImpAcuses.Index = 2
        Me.mnuImpAcuses.Text = "Impresión de Acuses de Recibido"
        '
        'mnuRelaFact
        '
        Me.mnuRelaFact.Enabled = False
        Me.mnuRelaFact.Index = 3
        Me.mnuRelaFact.Text = "Relación de Facturación para Mensajería"
        '
        'mnuArchivosDCI
        '
        Me.mnuArchivosDCI.Enabled = False
        Me.mnuArchivosDCI.Index = 4
        Me.mnuArchivosDCI.Text = "Generación de Archivos para DCI"
        '
        'mnuCifrasDCI
        '
        Me.mnuCifrasDCI.Enabled = False
        Me.mnuCifrasDCI.Index = 5
        Me.mnuCifrasDCI.Text = "Cifras de Control para DCI"
        '
        'mnuAvisos
        '
        Me.mnuAvisos.Enabled = False
        Me.mnuAvisos.Index = 6
        Me.mnuAvisos.Text = "Subir avisos a la página Web"
        '
        'mnuGenAviso
        '
        Me.mnuGenAviso.Enabled = False
        Me.mnuGenAviso.Index = 7
        Me.mnuGenAviso.Text = "Envío de Avisos por eMail"
        '
        'mnuDepoRefe
        '
        Me.mnuDepoRefe.Enabled = False
        Me.mnuDepoRefe.Index = 8
        Me.mnuDepoRefe.Text = "Depósitos Referenciados"
        '
        'mnuLayOutAvio
        '
        Me.mnuLayOutAvio.Index = 9
        Me.mnuLayOutAvio.Text = "Genera Layout de Avío"
        '
        'mnuSeguros
        '
        Me.mnuSeguros.Enabled = False
        Me.mnuSeguros.Index = 4
        Me.mnuSeguros.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuCaptValo, Me.mnuCaptSegu, Me.mnuFormMens})
        Me.mnuSeguros.Text = "Seguros y Guarda Valores"
        '
        'mnuCaptValo
        '
        Me.mnuCaptValo.Enabled = False
        Me.mnuCaptValo.Index = 0
        Me.mnuCaptValo.Text = "Captura de Valores"
        '
        'mnuCaptSegu
        '
        Me.mnuCaptSegu.Enabled = False
        Me.mnuCaptSegu.Index = 1
        Me.mnuCaptSegu.Text = "Captura de Seguros"
        '
        'mnuFormMens
        '
        Me.mnuFormMens.Enabled = False
        Me.mnuFormMens.Index = 2
        Me.mnuFormMens.Text = "Forma Mensajería"
        '
        'mnuCont
        '
        Me.mnuCont.Enabled = False
        Me.mnuCont.Index = 5
        Me.mnuCont.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuImprCert, Me.mnuComputo, Me.mnuPondera, Me.mnuProyecta, Me.mnuRelaResp, Me.mnuIntCosto, Me.mnuCosto, Me.mnuCierre, Me.mnuRepCierre, Me.mnuRepSald2})
        Me.mnuCont.Text = "Co&ntabilidad"
        '
        'mnuImprCert
        '
        Me.mnuImprCert.Enabled = False
        Me.mnuImprCert.Index = 0
        Me.mnuImprCert.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuECPorAnexo, Me.mnuECPorNombre})
        Me.mnuImprCert.Text = "Estados de Cuenta Certificados"
        '
        'mnuECPorAnexo
        '
        Me.mnuECPorAnexo.Enabled = False
        Me.mnuECPorAnexo.Index = 0
        Me.mnuECPorAnexo.Text = "Por Anexo"
        '
        'mnuECPorNombre
        '
        Me.mnuECPorNombre.Enabled = False
        Me.mnuECPorNombre.Index = 1
        Me.mnuECPorNombre.Text = "Por Nombre"
        '
        'mnuComputo
        '
        Me.mnuComputo.Enabled = False
        Me.mnuComputo.Index = 1
        Me.mnuComputo.Text = "Cómputo de Capitalización"
        '
        'mnuPondera
        '
        Me.mnuPondera.Enabled = False
        Me.mnuPondera.Index = 2
        Me.mnuPondera.Text = "Ponderación de la Cartera"
        '
        'mnuProyecta
        '
        Me.mnuProyecta.Enabled = False
        Me.mnuProyecta.Index = 3
        Me.mnuProyecta.Text = "Amortizaciones Proyectadas"
        '
        'mnuRelaResp
        '
        Me.mnuRelaResp.Enabled = False
        Me.mnuRelaResp.Index = 4
        Me.mnuRelaResp.Text = "Relación de Responsabilidades"
        '
        'mnuIntCosto
        '
        Me.mnuIntCosto.Enabled = False
        Me.mnuIntCosto.Index = 5
        Me.mnuIntCosto.Text = "Integración del Costo"
        '
        'mnuCosto
        '
        Me.mnuCosto.Enabled = False
        Me.mnuCosto.Index = 6
        Me.mnuCosto.Text = "Determinación del Costo"
        '
        'mnuCierre
        '
        Me.mnuCierre.Enabled = False
        Me.mnuCierre.Index = 7
        Me.mnuCierre.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuCierreCo, Me.mnuTermimes, Me.mnuImprePol, Me.mnuConcAjus, Me.mnuGenCatal, Me.mnuSubirCE})
        Me.mnuCierre.Text = "Cierre de Mes"
        '
        'mnuCierreCo
        '
        Me.mnuCierreCo.Enabled = False
        Me.mnuCierreCo.Index = 0
        Me.mnuCierreCo.Text = "Correr procesos de cierre de mes"
        '
        'mnuTermimes
        '
        Me.mnuTermimes.Enabled = False
        Me.mnuTermimes.Index = 1
        Me.mnuTermimes.Text = "Terminaciones del mes"
        '
        'mnuImprePol
        '
        Me.mnuImprePol.Enabled = False
        Me.mnuImprePol.Index = 2
        Me.mnuImprePol.Text = "Imprimir pólizas contables"
        '
        'mnuConcAjus
        '
        Me.mnuConcAjus.Enabled = False
        Me.mnuConcAjus.Index = 3
        Me.mnuConcAjus.Text = "Conciliación de cuentas"
        '
        'mnuGenCatal
        '
        Me.mnuGenCatal.Enabled = False
        Me.mnuGenCatal.Index = 4
        Me.mnuGenCatal.Text = "Bajar catálogo de cuentas"
        '
        'mnuSubirCE
        '
        Me.mnuSubirCE.Enabled = False
        Me.mnuSubirCE.Index = 5
        Me.mnuSubirCE.Text = "Subir catálogo externo"
        '
        'mnuRepCierre
        '
        Me.mnuRepCierre.Enabled = False
        Me.mnuRepCierre.Index = 8
        Me.mnuRepCierre.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuRepSaldo, Me.mnuRepoActi, Me.mnuPrepames, Me.mnuRepDiezP, Me.mnuRepAnti2, Me.mnuRepInter, Me.mnuIntIvaPP, Me.mnuReproInt, Me.mnuRepMenBancos})
        Me.mnuRepCierre.Text = "Reportes de Cierre de Mes"
        '
        'mnuRepSaldo
        '
        Me.mnuRepSaldo.Enabled = False
        Me.mnuRepSaldo.Index = 0
        Me.mnuRepSaldo.Text = "Saldos Insolutos"
        '
        'mnuRepoActi
        '
        Me.mnuRepoActi.Enabled = False
        Me.mnuRepoActi.Index = 1
        Me.mnuRepoActi.Text = "Activaciones en formato Contable"
        '
        'mnuPrepames
        '
        Me.mnuPrepames.Enabled = False
        Me.mnuPrepames.Index = 2
        Me.mnuPrepames.Text = "Adelantos y Finiquitos del Mes"
        '
        'mnuRepDiezP
        '
        Me.mnuRepDiezP.Enabled = False
        Me.mnuRepDiezP.Index = 3
        Me.mnuRepDiezP.Text = "Principales Clientes"
        '
        'mnuRepAnti2
        '
        Me.mnuRepAnti2.Enabled = False
        Me.mnuRepAnti2.Index = 4
        Me.mnuRepAnti2.Text = "Antigüedad de Saldos"
        '
        'mnuRepInter
        '
        Me.mnuRepInter.Enabled = False
        Me.mnuRepInter.Index = 5
        Me.mnuRepInter.Text = "Desglose de la Antigüedad de Saldos"
        '
        'mnuIntIvaPP
        '
        Me.mnuIntIvaPP.Enabled = False
        Me.mnuIntIvaPP.Index = 6
        Me.mnuIntIvaPP.Text = "Integración de IVA por pagar"
        '
        'mnuReproInt
        '
        Me.mnuReproInt.Enabled = False
        Me.mnuReproInt.Index = 7
        Me.mnuReproInt.Text = "Reporte de Provisión de Intereses"
        '
        'mnuRepMenBancos
        '
        Me.mnuRepMenBancos.Enabled = False
        Me.mnuRepMenBancos.Index = 8
        Me.mnuRepMenBancos.Text = "Reporte Mensual de Bancos"
        '
        'mnuRepSald2
        '
        Me.mnuRepSald2.Enabled = False
        Me.mnuRepSald2.Index = 9
        Me.mnuRepSald2.Text = "Saldos Insolutos por Plaza"
        '
        'mnuSist
        '
        Me.mnuSist.Enabled = False
        Me.mnuSist.Index = 6
        Me.mnuSist.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuRegenera, Me.mnuBuroCred, Me.mnuCostoIng, Me.mnuPortacar, Me.mnuCapitalizacion, Me.mnuCartas, Me.mnuReimprimir})
        Me.mnuSist.Text = "S&istemas"
        '
        'mnuRegenera
        '
        Me.mnuRegenera.Enabled = False
        Me.mnuRegenera.Index = 0
        Me.mnuRegenera.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuRTPorAnexo})
        Me.mnuRegenera.Text = "Regenerar Tablas de Amortización"
        '
        'mnuRTPorAnexo
        '
        Me.mnuRTPorAnexo.Enabled = False
        Me.mnuRTPorAnexo.Index = 0
        Me.mnuRTPorAnexo.Text = "Por Anexo"
        '
        'mnuBuroCred
        '
        Me.mnuBuroCred.Enabled = False
        Me.mnuBuroCred.Index = 1
        Me.mnuBuroCred.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuMorales, Me.mnuFisicas})
        Me.mnuBuroCred.Text = "Buró de Crédito"
        '
        'mnuMorales
        '
        Me.mnuMorales.Enabled = False
        Me.mnuMorales.Index = 0
        Me.mnuMorales.Text = "BNC Personas Morales"
        '
        'mnuFisicas
        '
        Me.mnuFisicas.Enabled = False
        Me.mnuFisicas.Index = 1
        Me.mnuFisicas.Text = "BNC Personas Físicas"
        '
        'mnuCostoIng
        '
        Me.mnuCostoIng.Enabled = False
        Me.mnuCostoIng.Index = 2
        Me.mnuCostoIng.Text = "Conciliar Costo vs Ingreso"
        '
        'mnuPortacar
        '
        Me.mnuPortacar.Enabled = False
        Me.mnuPortacar.Index = 3
        Me.mnuPortacar.Text = "Portafolio de Cartera para NAFIN"
        '
        'mnuCapitalizacion
        '
        Me.mnuCapitalizacion.Enabled = False
        Me.mnuCapitalizacion.Index = 4
        Me.mnuCapitalizacion.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuCAPorAnexo})
        Me.mnuCapitalizacion.Text = "Capitalización de Adeudos"
        '
        'mnuCAPorAnexo
        '
        Me.mnuCAPorAnexo.Enabled = False
        Me.mnuCAPorAnexo.Index = 0
        Me.mnuCAPorAnexo.Text = "Por Anexo"
        '
        'mnuCartas
        '
        Me.mnuCartas.Enabled = False
        Me.mnuCartas.Index = 5
        Me.mnuCartas.Text = "Cartas a Clientes con EMail"
        '
        'mnuReimprimir
        '
        Me.mnuReimprimir.Enabled = False
        Me.mnuReimprimir.Index = 6
        Me.mnuReimprimir.Text = "Reimprimir facturas de pago"
        '
        'mnuCons
        '
        Me.mnuCons.Index = 7
        Me.mnuCons.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuDatosCon, Me.mnuFacSaldo, Me.mnuCalcfini, Me.mnuConsRefe, Me.mnuConsAviso, Me.mnuRepSalCli})
        Me.mnuCons.Text = "Cons&ultas"
        '
        'mnuDatosCon
        '
        Me.mnuDatosCon.Index = 0
        Me.mnuDatosCon.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuDCPorAnexo, Me.mnuDCPorNombre})
        Me.mnuDatosCon.Text = "Datos del Contrato"
        '
        'mnuDCPorAnexo
        '
        Me.mnuDCPorAnexo.Index = 0
        Me.mnuDCPorAnexo.Text = "Por Anexo"
        '
        'mnuDCPorNombre
        '
        Me.mnuDCPorNombre.Index = 1
        Me.mnuDCPorNombre.Text = "Por Nombre"
        '
        'mnuFacSaldo
        '
        Me.mnuFacSaldo.Enabled = False
        Me.mnuFacSaldo.Index = 1
        Me.mnuFacSaldo.Text = "Estados de Cuenta"
        '
        'mnuCalcfini
        '
        Me.mnuCalcfini.Enabled = False
        Me.mnuCalcfini.Index = 2
        Me.mnuCalcfini.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuCFPorAnexo, Me.mnuCFPorNombre})
        Me.mnuCalcfini.Text = "Cálculo de Finiquitos"
        '
        'mnuCFPorAnexo
        '
        Me.mnuCFPorAnexo.Enabled = False
        Me.mnuCFPorAnexo.Index = 0
        Me.mnuCFPorAnexo.Text = "Por Anexo"
        '
        'mnuCFPorNombre
        '
        Me.mnuCFPorNombre.Enabled = False
        Me.mnuCFPorNombre.Index = 1
        Me.mnuCFPorNombre.Text = "Por Nombre"
        '
        'mnuConsRefe
        '
        Me.mnuConsRefe.Enabled = False
        Me.mnuConsRefe.Index = 3
        Me.mnuConsRefe.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuDRPorFecha, Me.mnuDRPorCliente})
        Me.mnuConsRefe.Text = "Depósitos Referenciados"
        '
        'mnuDRPorFecha
        '
        Me.mnuDRPorFecha.Enabled = False
        Me.mnuDRPorFecha.Index = 0
        Me.mnuDRPorFecha.Text = "Por Fecha"
        '
        'mnuDRPorCliente
        '
        Me.mnuDRPorCliente.Enabled = False
        Me.mnuDRPorCliente.Index = 1
        Me.mnuDRPorCliente.Text = "Por Cliente"
        '
        'mnuConsAviso
        '
        Me.mnuConsAviso.Enabled = False
        Me.mnuConsAviso.Index = 4
        Me.mnuConsAviso.Text = "Consulta de Avisos de Vencimiento"
        '
        'mnuRepSalCli
        '
        Me.mnuRepSalCli.Enabled = False
        Me.mnuRepSalCli.Index = 5
        Me.mnuRepSalCli.Text = "Saldos Insolutos por Cliente"
        '
        'mnuRep
        '
        Me.mnuRep.Enabled = False
        Me.mnuRep.Index = 8
        Me.mnuRep.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuRepoProm, Me.mnuRepAntig, Me.mnuRepoSegu, Me.mnuRepoValo})
        Me.mnuRep.Text = "&Reportes"
        '
        'mnuRepoProm
        '
        Me.mnuRepoProm.Enabled = False
        Me.mnuRepoProm.Index = 0
        Me.mnuRepoProm.Text = "Reporte de Activaciones"
        '
        'mnuRepAntig
        '
        Me.mnuRepAntig.Enabled = False
        Me.mnuRepAntig.Index = 1
        Me.mnuRepAntig.Text = "Antigüedad de Saldos"
        '
        'mnuRepoSegu
        '
        Me.mnuRepoSegu.Enabled = False
        Me.mnuRepoSegu.Index = 2
        Me.mnuRepoSegu.Text = "Reporte de Seguros"
        '
        'mnuRepoValo
        '
        Me.mnuRepoValo.Enabled = False
        Me.mnuRepoValo.Index = 3
        Me.mnuRepoValo.Text = "Reporte de Guardavalores"
        '
        'mnuRiesgos
        '
        Me.mnuRiesgos.Enabled = False
        Me.mnuRiesgos.Index = 9
        Me.mnuRiesgos.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuCCartera, Me.mnuCartaRat, Me.mnuFega, Me.mnuPortaCon})
        Me.mnuRiesgos.Text = "Riesgos"
        '
        'mnuCCartera
        '
        Me.mnuCCartera.Enabled = False
        Me.mnuCCartera.Index = 0
        Me.mnuCCartera.Text = "Calificación de la Cartera"
        '
        'mnuCartaRat
        '
        Me.mnuCartaRat.Enabled = False
        Me.mnuCartaRat.Index = 1
        Me.mnuCartaRat.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuCRPorAnexo, Me.mnuCRPorNombre})
        Me.mnuCartaRat.Text = "Carta de Ratificación"
        '
        'mnuCRPorAnexo
        '
        Me.mnuCRPorAnexo.Enabled = False
        Me.mnuCRPorAnexo.Index = 0
        Me.mnuCRPorAnexo.Text = "Por Anexo"
        '
        'mnuCRPorNombre
        '
        Me.mnuCRPorNombre.Enabled = False
        Me.mnuCRPorNombre.Index = 1
        Me.mnuCRPorNombre.Text = "Por Nombre"
        '
        'mnuFega
        '
        Me.mnuFega.Enabled = False
        Me.mnuFega.Index = 2
        Me.mnuFega.Text = "Captura comisión FEGA"
        '
        'mnuPortaCon
        '
        Me.mnuPortaCon.Index = 3
        Me.mnuPortaCon.Text = "Portafolio Contable"
        '
        'mnuAvio
        '
        Me.mnuAvio.Index = 10
        Me.mnuAvio.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAltaContratos, Me.mnuModCtoAvio, Me.mnuImpCtoAvio, Me.mnuSustrae, Me.mnuEstratificacion, Me.mnuMinistraciones, Me.mnuReportes, Me.mnuEdoCtaAvio, Me.mnuPagosPF, Me.mnuPagares, Me.mnuCapturaPMI, Me.mnuControlPasivos})
        Me.mnuAvio.Text = "Avío"
        '
        'mnuAltaContratos
        '
        Me.mnuAltaContratos.Enabled = False
        Me.mnuAltaContratos.Index = 0
        Me.mnuAltaContratos.Text = "Alta de Contratos"
        '
        'mnuModCtoAvio
        '
        Me.mnuModCtoAvio.Index = 1
        Me.mnuModCtoAvio.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuModCtoAvioPorProductor, Me.mnuModCtoAvioPorContrato})
        Me.mnuModCtoAvio.Text = "Modificación de Contratos"
        '
        'mnuModCtoAvioPorProductor
        '
        Me.mnuModCtoAvioPorProductor.Index = 0
        Me.mnuModCtoAvioPorProductor.Text = "Por Productor"
        '
        'mnuModCtoAvioPorContrato
        '
        Me.mnuModCtoAvioPorContrato.Index = 1
        Me.mnuModCtoAvioPorContrato.Text = "Por Contrato"
        '
        'mnuImpCtoAvio
        '
        Me.mnuImpCtoAvio.Index = 2
        Me.mnuImpCtoAvio.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuImpCtoAvioPorProductor, Me.mnuImpCtoAvioPorContrato})
        Me.mnuImpCtoAvio.Text = "Impresión de Contratos"
        '
        'mnuImpCtoAvioPorProductor
        '
        Me.mnuImpCtoAvioPorProductor.Index = 0
        Me.mnuImpCtoAvioPorProductor.Text = "Por Productor"
        '
        'mnuImpCtoAvioPorContrato
        '
        Me.mnuImpCtoAvioPorContrato.Index = 1
        Me.mnuImpCtoAvioPorContrato.Text = "Por Contrato"
        '
        'mnuSustrae
        '
        Me.mnuSustrae.Enabled = False
        Me.mnuSustrae.Index = 3
        Me.mnuSustrae.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuRCS, Me.mnuPSC})
        Me.mnuSustrae.Text = "SUSTRAE"
        '
        'mnuRCS
        '
        Me.mnuRCS.Index = 0
        Me.mnuRCS.Text = "Registro de Consultas"
        '
        'mnuPSC
        '
        Me.mnuPSC.Index = 1
        Me.mnuPSC.Text = "Productores sin Consultar"
        '
        'mnuEstratificacion
        '
        Me.mnuEstratificacion.Enabled = False
        Me.mnuEstratificacion.Index = 4
        Me.mnuEstratificacion.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuMemoria, Me.mnuRE})
        Me.mnuEstratificacion.Text = "Estratificación"
        '
        'mnuMemoria
        '
        Me.mnuMemoria.Index = 0
        Me.mnuMemoria.Text = "Determinación"
        '
        'mnuRE
        '
        Me.mnuRE.Index = 1
        Me.mnuRE.Text = "Reporte"
        '
        'mnuMinistraciones
        '
        Me.mnuMinistraciones.Index = 5
        Me.mnuMinistraciones.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuMinistracionesPorProductor, Me.mnuMinistracionesPorContrato})
        Me.mnuMinistraciones.Text = "Ministraciones"
        '
        'mnuMinistracionesPorProductor
        '
        Me.mnuMinistracionesPorProductor.Index = 0
        Me.mnuMinistracionesPorProductor.Text = "Por Productor"
        '
        'mnuMinistracionesPorContrato
        '
        Me.mnuMinistracionesPorContrato.Index = 1
        Me.mnuMinistracionesPorContrato.Text = "Por Contrato"
        '
        'mnuReportes
        '
        Me.mnuReportes.Enabled = False
        Me.mnuReportes.Index = 6
        Me.mnuReportes.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuMinistracionFFP, Me.mnuMinistracionFP})
        Me.mnuReportes.Text = "Reporte de Ministraciones"
        '
        'mnuMinistracionFFP
        '
        Me.mnuMinistracionFFP.Index = 0
        Me.mnuMinistracionFFP.Text = "FIRA-FINAGIL-Productor"
        '
        'mnuMinistracionFP
        '
        Me.mnuMinistracionFP.Index = 1
        Me.mnuMinistracionFP.Text = "FINAGIL-Productor"
        '
        'mnuEdoCtaAvio
        '
        Me.mnuEdoCtaAvio.Index = 7
        Me.mnuEdoCtaAvio.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuECPP, Me.mnuECTC})
        Me.mnuEdoCtaAvio.Text = "Estado de Cuenta"
        '
        'mnuECPP
        '
        Me.mnuECPP.Index = 0
        Me.mnuECPP.Text = "Por Productor"
        '
        'mnuECTC
        '
        Me.mnuECTC.Enabled = False
        Me.mnuECTC.Index = 1
        Me.mnuECTC.Text = "Global"
        '
        'mnuPagosPF
        '
        Me.mnuPagosPF.Enabled = False
        Me.mnuPagosPF.Index = 8
        Me.mnuPagosPF.Text = "Pagos Productor-FINAGIL"
        '
        'mnuPagares
        '
        Me.mnuPagares.Enabled = False
        Me.mnuPagares.Index = 9
        Me.mnuPagares.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuPagaresPorProductor, Me.mnuPagaresPorContrato})
        Me.mnuPagares.Text = "Registro de Pagarés"
        '
        'mnuPagaresPorProductor
        '
        Me.mnuPagaresPorProductor.Index = 0
        Me.mnuPagaresPorProductor.Text = "Por Productor"
        '
        'mnuPagaresPorContrato
        '
        Me.mnuPagaresPorContrato.Index = 1
        Me.mnuPagaresPorContrato.Text = "Por Contrato"
        '
        'mnuCapturaPMI
        '
        Me.mnuCapturaPMI.Index = 10
        Me.mnuCapturaPMI.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuCapturaPMIPorProductor, Me.mnuCapturaPMIPorContrato})
        Me.mnuCapturaPMI.Text = "Captura de Predios y Bienes"
        '
        'mnuCapturaPMIPorProductor
        '
        Me.mnuCapturaPMIPorProductor.Index = 0
        Me.mnuCapturaPMIPorProductor.Text = "Por Productor"
        '
        'mnuCapturaPMIPorContrato
        '
        Me.mnuCapturaPMIPorContrato.Index = 1
        Me.mnuCapturaPMIPorContrato.Text = "Por Contrato"
        '
        'mnuControlPasivos
        '
        Me.mnuControlPasivos.Index = 11
        Me.mnuControlPasivos.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuEdoCtaFB, Me.mnuPagosBF, Me.mnuSaldosContingentes, Me.MenuItem5})
        Me.mnuControlPasivos.Text = "Control de Pasivos"
        '
        'mnuEdoCtaFB
        '
        Me.mnuEdoCtaFB.Index = 0
        Me.mnuEdoCtaFB.Text = "Estados de Cuenta"
        '
        'mnuPagosBF
        '
        Me.mnuPagosBF.Index = 1
        Me.mnuPagosBF.Text = "Registro de pagos a FIRA"
        '
        'mnuSaldosContingentes
        '
        Me.mnuSaldosContingentes.Index = 2
        Me.mnuSaldosContingentes.Text = "Saldos Contingentes"
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 3
        Me.MenuItem5.Text = "Determinación del FIFAP"
        '
        'mnuSalir
        '
        Me.mnuSalir.Index = 11
        Me.mnuSalir.Text = "&Salir"
        '
        'frmAgil
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 15)
        Me.ClientSize = New System.Drawing.Size(1024, 681)
        Me.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Menu = Me.MainMenu1
        Me.Name = "frmAgil"
        Me.Text = "FINAGIL, S.A. de C.V. SOFOM, E.N.R."
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmAgil_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración de variables de conexión ADO .NET

        Dim cn As New SqlConnection()
        Dim cm As New SqlCommand()
        Dim dsAgil As New DataSet()
        Dim daMenus As New SqlDataAdapter(cm)
        Dim drMenu As DataRow
        Dim strConnectionSecurity As String
        Dim strSelect As String

        ' Declaración de variables de datos

        Dim aVariables() As String
        Dim CadenaClaves As String
        Dim Usuario As String
        Dim Password As String
        Dim i As Integer
        Dim j As Integer
        Dim k As Integer

        Try
            Using sr As StreamReader = New StreamReader("C:\Archivos de programa\Agil\Pasadatos.txt")
                CadenaClaves = sr.ReadLine()
                sr.Close()
            End Using
            aVariables = Split(CadenaClaves, ";")
        Catch eException As Exception
            Console.WriteLine("The file could not be read:")
            Console.WriteLine(eException.Message)
        End Try

        Usuario = "desarrollo"
        Password = "4ec12c8a4f2942c1043dfbe774b284a4"

        ' Esta consulta trae las opciones definidas para el usuario que está ingresando al sistema

        'strSelect = "SELECT cve_menu, cve_submenu, cve_ssubmenu, cve_sssubmenu FROM SEG_MAESTRA " & _
        '"WHERE cve_perfil IN (SELECT PERFILES.cve_perfil FROM PERFILES " & _
        '                      "INNER JOIN USUARIOS_PERFILES ON PERFILES.cve_perfil = USUARIOS_PERFILES.cve_perfil " & _
        '                      "INNER JOIN USUARIO ON USUARIOS_PERFILES.cve_empleado = USUARIO.cve_empleado " & _
        '                      "WHERE nom_sistema = 'FINANCIERA' AND (USUARIO.id_usuario = '" & Usuario & "' ))" & _
        '"ORDER BY cve_menu, cve_submenu, cve_ssubmenu, cve_sssubmenu"

        ' Aquí se crea la cadena de conexión a la base de datos SEGURIDAD

        'strConnectionSecurity = My.Settings.CadSeguridad & " User ID=" & Usuario & "; pwd=" & Password

        'cn.ConnectionString = strConnectionSecurity

        'With cm
        '    .Connection = cn
        '    .CommandText = strSelect
        'End With

        ' Llenar el DataSet lo cual abre y cierra la conexión

        'daMenus.Fill(dsAgil, "Menus")

        ' La primera vez que corre esta rutina es para deshabilitar todas las opciones del menú y submenús.
        ' Si tenemos cuidado de deshabilitar los menús desde el diseño, entonces podemos omitir esta sección.

        For i = 0 To Menu.MenuItems.Count - 1
            For j = 0 To Menu.MenuItems(i).MenuItems.Count - 1
                For k = 0 To Menu.MenuItems(i).MenuItems(j).MenuItems.Count - 1
                    Menu.MenuItems(i).MenuItems(j).MenuItems(k).Enabled = True
                Next
                Menu.MenuItems(i).MenuItems(j).Enabled = True
            Next
            Menu.MenuItems(i).Enabled = True
        Next

        ' La segunda vez que corre esta rutina es para habilitar las opciones de menú que se hayan definido
        ' para el usuario que está ingresando al sistema.

        'For Each drMenu In dsAgil.Tables("Menus").Rows
        '    i = drMenu(0) - 1
        '    j = drMenu(1) - 1
        '    k = drMenu(2) - 1
        '    If i >= 0 Then
        '        If j >= 0 Then
        '            If k >= 0 Then
        '                Menu.MenuItems(i).MenuItems(j).MenuItems(k).Enabled = True
        '            Else
        '                Menu.MenuItems(i).MenuItems(j).Enabled = True
        '            End If
        '        Else
        '            Menu.MenuItems(i).Enabled = True
        '        End If
        '    End If
        'Next

        ' En esta rutina se crea la cadena de conexión a la base de datos especificada en mConexion.vb que es el módulo donde está
        ' contenida la variable pública StrConn y la rutina pública CreaCadenaConexion.

        CreaCadenaConexion(Usuario, Password)

    End Sub

    Private Sub mnuCotizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCotizar.Click
        Dim newfrmCotizador As New frmCotizador()
        newfrmCotizador.Show()
    End Sub

    Private Sub mnuAltaClie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAltaClie.Click
        Dim newfrmAltaClie As New frmAltaClie()
        newfrmAltaClie.Show()
    End Sub

    Private Sub mnuContClie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuContClie.Click
        Dim newfrmContClie As New frmContClie()
        newfrmContClie.Show()
    End Sub

    Private Sub mnuContSoli_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuContSoli.Click
        Dim newfrmPideCliente As New frmPideCliente("mnuContSoli")
        newfrmPideCliente.Show()
    End Sub

    Private Sub mnuCaptFact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCaptFact.Click
        Dim newfrmPideAnexo As New frmPideAnexo("mnuCaptFact")
        newfrmPideAnexo.Show()
    End Sub

    Private Sub mnuPrendaria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrendaria.Click
        Dim newfrmPideAnexo As New frmPideAnexo("mnuPrendaria")
        newfrmPideAnexo.Show()
    End Sub

    Private Sub mnuActiAnex_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuActiAnex.Click
        Dim newfrmPideAnexo As New frmPideAnexo("mnuActiAnex")
        newfrmPideAnexo.Show()
    End Sub

    Private Sub mnuDesactiv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDesactiv.Click
        Dim newfrmPideAnexo As New frmPideAnexo("mnuDesactiv")
        newfrmPideAnexo.Show()
    End Sub

    Private Sub mnuSeguiCre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSeguiCre.Click
        Dim newfrmPideCliente As New frmPideCliente("mnuSeguiCre")
        newfrmPideCliente.Show()
    End Sub

    Private Sub mnuReciPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReciPago.Click
        Dim newfrmRecipago As New frmRecipago()
        newfrmRecipago.Show()
    End Sub

    Private Sub mnuACPorAnexo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuACPorAnexo.Click
        Dim newfrmPideContrato As New frmPideContrato("mnuAdelanto")
        newfrmPideContrato.Show()
    End Sub

    Private Sub mnuACPorNombre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuACPorNombre.Click
        Dim newfrmPideAnexo As New frmPideAnexo("mnuAdelanto")
        newfrmPideAnexo.Show()
    End Sub

    Private Sub mnuFCPorAnexo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFCPorAnexo.Click
        Dim newfrmPideContrato As New frmPideContrato("mnuFiniquito")
        newfrmPideContrato.Show()
    End Sub

    Private Sub mnuFCPorNombre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFCPorNombre.Click
        Dim newfrmPideAnexo As New frmPideAnexo("mnuFiniquito")
        newfrmPideAnexo.Show()
    End Sub

    Private Sub mnuImprActi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuImprActi.Click
        Dim newfrmPideAnexo As New frmPideAnexo("mnuImprActi")
        newfrmPideAnexo.Show()
    End Sub

    Private Sub mnuDomicilio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDomicilio.Click
        Dim newfrmDomicilio As New frmDomicilio()
        newfrmDomicilio.Show()
    End Sub

    Private Sub mnuRepCobra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRepCobra.Click
        Dim newfrmRepCobra As New frmRepcobra()
        newfrmRepCobra.Show()
    End Sub

    Private Sub mnuBitacora_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBitacora.Click
        Dim newfrmBitacora As New frmBitacora()
        newfrmBitacora.Show()
    End Sub

    Private Sub mnuSegBitacora_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSegBitacora.Click
        Dim newfrmSegBitacora As New frmSegBitacora()
        newfrmSegBitacora.Show()
    End Sub

    Private Sub mnuRecupera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRecupera.Click
        Dim newfrmRecuperacion As New frmRecuperacion()
        newfrmRecuperacion.Show()
    End Sub

    Private Sub mnuRepGaran_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRepGaran.Click
        Dim newfrmRepGaran As New frmRepGaran()
        newfrmRepGaran.Show()
    End Sub

    Private Sub mnuRepoDisp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRepoDisp.Click
        Dim newfrmRepoDisp As New frmRepoDisp()
        newfrmRepoDisp.Show()
    End Sub

    Private Sub mnuRepNafin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRepNafin.Click
        Dim newfrmRepNafin As New frmRepNafin()
        newfrmRepNafin.Show()
    End Sub

    Private Sub mnuActuatas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuActuaTas.Click
        Dim newfrmActuatas As New frmActuatas()
        newfrmActuatas.Show()
    End Sub

    Private Sub mnuActuaUdis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuActuaUdis.Click
        Dim newfrmActuaUdis As New frmActuaUdis()
        newfrmActuaUdis.Show()
    End Sub

    Private Sub mnuSegumanu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSeguManu.Click
        Dim newfrmPideAnexo As New frmPideAnexo("mnuSegumanu")
        newfrmPideAnexo.Show()
    End Sub

    Private Sub mnuGeneFac_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuGeneFac.Click
        Dim newfrmGeneFact As New frmGeneFact()
        newfrmGeneFact.Show()
    End Sub

    Private Sub mnuImpreFac_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuImpreFac.Click
        Dim newfrmImpreFac As New frmImpreFac()
        newfrmImpreFac.Show()
    End Sub

    Private Sub mnuImpAcuses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuImpAcuses.Click
        Dim newfrmImpAcuses As New frmImpAcuses()
        newfrmImpAcuses.Show()
    End Sub

    Private Sub mnuRelaFact_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuRelaFact.Click
        Dim newfrmRelaFact As New frmRelaFact()
        newfrmRelaFact.Show()
    End Sub

    Private Sub mnuArchivosDCI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuArchivosDCI.Click
        Dim newfrmArchivosDCI As New frmArchivosDCI()
        newfrmArchivosDCI.Show()
    End Sub

    Private Sub mnuCifrasDCI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuCifrasDCI.Click
        Dim newCifrascon As New frmCifrasCont()
        newCifrascon.Show()
    End Sub

    Private Sub mnuAvisos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAvisos.Click
        Dim newfrmAvisos As New frmAvisos()
        newfrmAvisos.Show()
    End Sub

    Private Sub mnuGenAviso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuGenAviso.Click
        Dim newfrmEnvios As New frmEnvios()
        newfrmEnvios.Show()
    End Sub

    Private Sub mnuCaptValo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCaptValo.Click
        Dim newfrmPideAnexo As New frmPideAnexo("mnuCaptValo")
        newfrmPideAnexo.Show()
    End Sub

    Private Sub mnuCaptSegu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCaptSegu.Click
        Dim newfrmPideAnexo As New frmPideAnexo("mnuCaptSegu")
        newfrmPideAnexo.Show()
    End Sub

    Private Sub mnuFormMens_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFormMens.Click
        Dim newfrmMensajeria As New frmMensajeria()
        newfrmMensajeria.Show()
    End Sub

    Private Sub mnuECPorAnexo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuECPorAnexo.Click
        Dim newfrmPideContrato As New frmPideContrato("mnuImprCert")
        newfrmPideContrato.Show()
    End Sub

    Private Sub mnuECPorNombre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuECPorNombre.Click
        Dim newfrmPideAnexo As New frmPideAnexo("mnuImprCert")
        newfrmPideAnexo.Show()
    End Sub

    Private Sub mnuComputo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuComputo.Click
        Dim newfrmComputo As New frmComputo
        newfrmComputo.Show()
    End Sub

    Private Sub mnuPondera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPondera.Click
        Dim newfrmPondera As New frmPondera()
        newfrmPondera.Show()
    End Sub

    Private Sub mnuProyecta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuProyecta.Click
        Dim newfrmProyecta As New frmProyecta()
        newfrmProyecta.Show()
    End Sub

    Private Sub mnuRelaResp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelaResp.Click
        Dim newfrmRelaResp As New frmRelaResp()
        newfrmRelaResp.Show()
    End Sub

    Private Sub mnuIntCosto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuIntCosto.Click
        Dim newfrmIntCosto As New frmIntCosto()
        newfrmIntCosto.Show()
    End Sub

    Private Sub mnuCosto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCosto.Click
        Dim newfrmCosto As New frmCosto()
        newfrmCosto.Show()
    End Sub

    Private Sub mnuCierreCo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCierreCo.Click
        Dim newfrmCierreCo As New frmCierreCo()
        newfrmCierreCo.Show()
    End Sub

    Private Sub mnuTermimes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTermimes.Click
        Dim newfrmTermimes As New frmTermimes()
        newfrmTermimes.Show()
    End Sub

    Private Sub mnuImprePol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuImprePol.Click
        Dim newfrmImprePol As New frmImprePol()
        newfrmImprePol.Show()
    End Sub

    Private Sub mnuConcAjus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConcAjus.Click
        Dim newfrmConcAjus As New frmConcAjus()
        newfrmConcAjus.Show()
    End Sub

    Private Sub mnuGenCatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuGenCatal.Click
        GenCatal()
        MsgBox("Catálogo de Cuentas creado", MsgBoxStyle.Information, "Mensaje")
    End Sub

    Private Sub mnuSubirCE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSubirCE.Click
        SubirCE()
        MsgBox("Catálogo de Cuentas subido al sistema", MsgBoxStyle.Information, "Mensaje")
    End Sub

    Private Sub mnuRepoActi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRepoActi.Click
        Dim newfrmRepoActi As New frmRepoActi()
        newfrmRepoActi.Show()
    End Sub

    Private Sub mnuPrepames_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrepames.Click
        Dim newfrmPrepames As New frmPrepames()
        newfrmPrepames.Show()
    End Sub

    Private Sub mnuRepDiezP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRepDiezP.Click
        Dim newfrmRepDiezP As New frmRepDiezp()
        newfrmRepDiezP.Show()
    End Sub

    Private Sub mnuRepAnti2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRepAnti2.Click
        Dim newfrmRepAnti2 As New frmRepAnti2()
        newfrmRepAnti2.Show()
    End Sub

    Private Sub mnuRepInter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRepInter.Click
        Dim newfrmRepInter As New frmRepInter()
        newfrmRepInter.Show()
    End Sub

    Private Sub mnuIntIvaPP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuIntIvaPP.Click
        Dim newfrmIntIvaPP As New frmIntIvaPP()
        newfrmIntIvaPP.Show()
    End Sub

    Private Sub mnuReproInt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReproInt.Click
        Dim newfrmReproInt As New frmReproint()
        newfrmReproInt.Show()
    End Sub

    Private Sub mnuRepMenBancos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRepMenBancos.Click
        Dim newfrmRepMenBancos As New frmRepMenBancos()
        newfrmRepMenBancos.Show()
    End Sub

    Private Sub mnuRTPorAnexo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRTPorAnexo.Click
        Dim newfrmPideContrato As New frmPideContrato("mnuRegenera")
        newfrmPideContrato.Show()
    End Sub

    Private Sub mnuMorales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMorales.Click
        Dim newfrmMorales As New frmMorales()
        newfrmMorales.Show()
    End Sub

    Private Sub mnuFisicas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFisicas.Click
        Dim newfrmFisicas As New frmFisicas()
        newfrmFisicas.Show()
    End Sub

    Private Sub mnuCostoIng_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCostoIng.Click
        Dim newfrmCostoIng As New frmCostoIng()
        newfrmCostoIng.Show()
    End Sub

    Private Sub mnuPortacar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPortacar.Click
        Dim newfrmPortacar As New frmPortacar()
        newfrmPortacar.Show()
    End Sub

    Private Sub mnuCAPorAnexo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCAPorAnexo.Click
        Dim newfrmPideContrato As New frmPideContrato("mnuCapitalizacion")
        newfrmPideContrato.Show()
    End Sub

    Private Sub mnuCartas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCartas.Click
        Dim newfrmCartas As New frmCartas()
        newfrmCartas.Show()
    End Sub

    Private Sub mnuReimprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReimprimir.Click
        Dim newfrmCambioFact As New frmCambioFact()
        newfrmCambioFact.Show()
    End Sub

    Private Sub mnuDCPorAnexo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDCPorAnexo.Click
        Dim newfrmPideContrato As New frmPideContrato("mnuDatosCon")
        newfrmPideContrato.Show()
    End Sub

    Private Sub mnuDCPorNombre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDCPorNombre.Click
        Dim newfrmPideAnexo As New frmPideAnexo("mnuDatosCon")
        newfrmPideAnexo.Show()
    End Sub

    Private Sub mnuFacSaldo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFacSaldo.Click
        Dim newfrmFacSaldo As New frmFacSaldo()
        newfrmFacSaldo.Show()
    End Sub

    Private Sub mnuCFPorAnexo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCFPorAnexo.Click
        Dim newfrmPideContrato As New frmPideContrato("mnuCalcfini")
        newfrmPideContrato.Show()
    End Sub

    Private Sub mnuCFPorNombre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCFPorNombre.Click
        Dim newfrmPideAnexo As New frmPideAnexo("mnuCalcfini")
        newfrmPideAnexo.Show()
    End Sub

    Private Sub mnuDRPorFecha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDRPorFecha.Click
        Dim newfrmConsRef As New frmConsRef("F")
        newfrmConsRef.Show()
    End Sub

    Private Sub mnuDRPorCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDRPorCliente.Click
        Dim newfrmConsRef As New frmConsRef("C")
        newfrmConsRef.Show()
    End Sub

    Private Sub mnuConsAviso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConsAviso.Click
        Dim newfrmConsultaAviso As New frmConsultaAviso()
        newfrmConsultaAviso.Show()
    End Sub

    Private Sub mnuRepSalCli_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRepSalCli.Click
        Dim newfrmRepSalCli As New frmRepSalCli()
        newfrmRepSalCli.Show()
    End Sub

    Private Sub mnuRepSaldo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRepSaldo.Click
        Dim newfrmRepSaldo As New frmRepSaldo()
        newfrmRepSaldo.Show()
    End Sub

    Private Sub mnuRepoProm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRepoProm.Click
        Dim newfrmRepoProm As New frmRepoProm()
        newfrmRepoProm.Show()
    End Sub

    Private Sub mnuRepAntig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRepAntig.Click
        Dim newfrmRepAntig As New frmRepAntig()
        newfrmRepAntig.Show()
    End Sub

    Private Sub mnuSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSalir.Click
        End
    End Sub

    Private Sub mnuRepSald2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRepSald2.Click
        Dim newfrmRepSald2 As New frmRepSald2()
        newfrmRepSald2.Show()
    End Sub

    Private Sub mnuRepoSegu_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRepoSegu.Click
        Dim newfrmRepoSegu As New frmRepoSegu()
        newfrmRepoSegu.Show()
    End Sub

    Private Sub mnuRepoValo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuRepoValo.Click
        Dim newfrmRepoValo As New frmRepoValo()
        newfrmRepoValo.Show()
    End Sub

    Private Sub mnuCRPorAnexo_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuCRPorAnexo.Click
        Dim newfrmPideContrato As New frmPideContrato("mnuCartaRat")
        newfrmPideContrato.Show()
    End Sub

    Private Sub mnuCRPorNombre_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuCRPorNombre.Click
        Dim newfrmPideAnexo As New frmPideAnexo("mnuCartaRat")
        newfrmPideAnexo.Show()
    End Sub

    Private Sub mnuCCartera_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuCCartera.Click
        Dim newfrmCalifica As New frmCalifica()
        newfrmCalifica.Show()
    End Sub

    Private Sub mnuDepoRefe_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuDepoRefe.Click
        Dim newfrmDepoRefe As New frmDepoRefe()
        newfrmDepoRefe.Show()
    End Sub

    Private Sub mnuFega_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFega.Click
        Dim newfrmFega As New frmFega()
        newfrmFega.Show()
    End Sub

    Private Sub mnuPortaCon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPortaCon.Click
        Dim newfrmPortaCon As New frmPortaCon
        newfrmPortaCon.Show()
    End Sub

    Private Sub mnuAltaContratos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAltaContratos.Click
        Dim newfrmAltaContratos As New frmAltaContratos
        newfrmAltaContratos.Show()
    End Sub

    Private Sub mnuRE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRE.Click
        Dim newfrmRE As New frmRE()
        newfrmRE.Show()
    End Sub

    Private Sub mnuMinistracionFFP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMinistracionFFP.Click
        Dim newfrmMinistraciones As New frmMinistraciones()
        newfrmMinistraciones.Show()
    End Sub

    Private Sub mnuMinistracionFP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMinistracionFP.Click
        Dim newfrmMinistracionFP As New frmMinistracionFP()
        newfrmMinistracionFP.Show()
    End Sub

    Private Sub mnuECPP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuECPP.Click
        Dim newfrmPideProductor As New frmPideProductor("mnuECPP")
        newfrmPideProductor.Show()
    End Sub

    Private Sub mnuECTC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuECTC.Click
        Dim newfrmECTC As New frmECTC()
        newfrmECTC.Show()
    End Sub

    Private Sub mnuPagosPF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPagosPF.Click
        Dim newfrmAplicacion As New frmAplicacion()
        newfrmAplicacion.Show()
    End Sub

    Private Sub mnuAplicaDR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAplicaDR.Click
        Dim newfrmAplicaDR As New frmAplicaDR()
        newfrmAplicaDR.Show()
    End Sub

    Private Sub mnuMemoria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMemoria.Click
        Dim newfrmMemoria As New frmMemoria()
        newfrmMemoria.Show()
    End Sub

    Private Sub mnuRCS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRCS.Click
        Dim newfrmSustrae As New frmSustrae()
        newfrmSustrae.Show()
    End Sub

    Private Sub mnuModCtoAvioPorProductor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuModCtoAvioPorProductor.Click
        Dim newfrmPideProductor As New frmPideProductor("mnuModCtoAvioPorProductor")
        newfrmPideProductor.Show()
    End Sub

    Private Sub mnuModCtoAvioPorContrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuModCtoAvioPorContrato.Click
        'Dim newfrmPideContrato As New frmPideContrato("mnuModCtoAvioPorContrato")
        'newfrmPideContrato.Show()
    End Sub

    Private Sub mnuMinistracionesPorProductor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMinistracionesPorProductor.Click
        Dim newfrmPideProductor As New frmPideProductor("mnuPorProductor")
        newfrmPideProductor.Show()
    End Sub

    Private Sub mnuMinistracionesPorContrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMinistracionesPorContrato.Click
        'Dim newfrmPideContrato As New frmPideContrato("mnuMinistracionesPorContrato")
        'newfrmPideContrato.Show()
    End Sub

    Private Sub mnuPagaresPorProductor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPagaresPorProductor.Click
        Dim newfrmPideProductor As New frmPideProductor("mnuPagaresPorProductor")
        newfrmPideProductor.Show()
    End Sub

    Private Sub mnuPagaresPorContrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPagaresPorContrato.Click
        'Dim newfrmPideContrato As New frmPideContrato("mnuPagaresPorContrato")
        'newfrmPideContrato.Show()
    End Sub

    Private Sub mnuCapturaPMIPorProductor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCapturaPMIPorProductor.Click
        Dim newfrmPideProductor As New frmPideProductor("mnuCapturaPMIPorProductor")
        newfrmPideProductor.Show()
    End Sub

    Private Sub mnuCapturaPMIPorContrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCapturaPMIPorContrato.Click
        'Dim newfrmPideContrato As New frmPideContrato("mnuCapturaPMIPorContrato")
        'newfrmPideContrato.Show()
    End Sub

    Private Sub mnuImpCtoAvioPorProductor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuImpCtoAvioPorProductor.Click
        Dim newfrmPideProductor As New frmPideProductor("mnuImpCtoAvioPorProductor")
        newfrmPideProductor.Show()
    End Sub

    Private Sub mnuImpCtoAvioPorContrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuImpCtoAvioPorContrato.Click
        'Dim newfrmPideContrato As New frmPideContrato("mnuImpCtoAvioPorContrato")
        'newfrmPideContrato.Show()
    End Sub

    Private Sub mnuLayOutAvio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLayOutAvio.Click
        Dim newfrmLayOutAvio As New frmLayOut()
        newfrmLayOutAvio.Show()
    End Sub

    Private Sub mnuEdoCtaFB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEdoCtaFB.Click
        Dim newfrmEdoCtaFB As New frmEdoCtaFB
        newfrmEdoCtaFB.Show()
    End Sub

    Private Sub mnuPagosBF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPagosBF.Click
        Dim newfrmPagosBF As New frmPagosBF
        newfrmPagosBF.Show()
    End Sub

    Private Sub mnuGFE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuGFE.Click
        Dim newfrmGFE As New frmGFE
        newfrmGFE.Show()
    End Sub

End Class
