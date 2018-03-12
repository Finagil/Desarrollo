Option Explicit On

Imports System.Data.SqlClient
Imports System.Math
Imports CrystalDecisions.Shared

Public Class frmImprCert

    Public Sub New(ByVal cAnexo As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.Text = "Certificación de Adeudos del contrato " & cAnexo
        txtAnexo.Text = cAnexo

    End Sub

    Private Sub frmImprCert_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = False
        Button6.Enabled = False
    End Sub

    Private Sub btnBegin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBegin.Click

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
        Dim dsAgil As New DataSet()
        Dim daAnexo As New SqlDataAdapter(cm1)
        Dim daFacturas As New SqlDataAdapter(cm2)
        Dim daHistoria As New SqlDataAdapter(cm3)
        Dim daUdis As New SqlDataAdapter(cm4)
        Dim daRtasxven As New SqlDataAdapter(cm5)
        Dim daCliente As New SqlDataAdapter(cm6)
        Dim daTasas As New SqlDataAdapter(cm7)
        Dim daTabse As New SqlDataAdapter(cm8)
        Dim drUdis As DataRowCollection
        Dim drAnexo As DataRow
        Dim drFactura As DataRow
        Dim drFactur As DataRow
        Dim drRtaven As DataRow
        Dim drMovim As DataRow
        Dim drHisto As DataRow
        Dim drDato As DataRow
        Dim drRenta As DataRow
        Dim drPorv As DataRow
        Dim drTabse As DataRow
        Dim dtDatos As New DataTable("Datos")
        Dim dtFacturas As New DataTable("Facturas")
        Dim dtRtasven As New DataTable("Rentasven")
        Dim dtHistory As New DataTable("Historia1")
        Dim dtRentas As New DataTable("Rentaxv")
        Dim dtMoratorios As New DataTable("IntMora")

        'Declaración de variables de datos

        Dim cAnexo As String
        Dim cFecha As String
        Dim cCliente As String
        Dim cFechacon As String
        Dim cPrimerPago As String
        Dim cUltimoPago As String
        Dim cUltimaMora As String
        Dim cDocumento As String
        Dim cPagosIni As String
        Dim cProvision As String
        Dim cFvenc As String
        Dim cFinse As String
        Dim cForca As String
        Dim cFVI As String
        Dim cFVF As String
        Dim cRVI As String
        Dim cRVF As String
        Dim cRPI As String
        Dim cRPF As String
        Dim cDoc As String
        Dim cYear As String
        Dim cMes As String
        Dim cDia As String
        Dim cTermina As String
        Dim cTipar As String
        Dim cTipo As String
        Dim cTipta As String
        Dim nPlazo As Integer
        Dim nDiasMora As Integer
        Dim nOcurre As Integer
        Dim nDifer As Decimal
        Dim nFactor As Decimal
        Dim nPiso As Decimal
        Dim nTecho As Decimal
        Dim nRtasD As Decimal
        Dim nImpRD As Decimal
        Dim nMora As Decimal
        Dim nTasa As Decimal
        Dim nIvaMora As Decimal
        Dim nProvision As Decimal
        Dim nIvaprov As Decimal
        Dim nSaldoFac As Decimal
        Dim nSaldoseg As Decimal
        Dim nCapital As Decimal
        Dim nIva As Decimal
        Dim nOpcion As Decimal
        Dim nIvaOpc As Decimal
        Dim nRV As Decimal
        Dim nAbono As Decimal
        Dim nPorcentajeIVA As Decimal = 0.16
        Dim nRentaspag As Decimal
        Dim nSumaIniciales As Decimal
        Dim nSumaMoratorios As Decimal
        Dim nTotalMora As Decimal
        Dim nTotalIvaMora As Decimal
        Dim nIvacapital As Decimal
        Dim nPagosi As Decimal
        Dim nRP As Decimal
        Dim nIP As Decimal
        Dim nID As Decimal
        Dim nUdiini As Decimal
        Dim nUdifin As Decimal
        Dim nTasaf As Decimal
        Dim nAdelantos As Decimal
        Dim nMes As Integer
        Dim nAño As Integer
        Dim dTermina As Date

        cAnexo = Mid(txtAnexo.Text, 1, 5) & Mid(txtAnexo.Text, 7, 4)
        cFecha = DTOC(dtpFechaProceso.Value)

        ' El siguiente Stored Procedure trae todos los atributos de la tabla Anexos,
        ' para un anexo dado

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DatosCon1"
            .Connection = cnAgil
            .Parameters.Add("@Anexo", SqlDbType.NVarChar)
            .Parameters(0).Value = cAnexo
        End With

        With cm2
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Historia2"
            .Connection = cnAgil
            .Parameters.Add("@Anexo", SqlDbType.NVarChar)
            .Parameters(0).Value = cAnexo
            .Parameters.Add("@Fecha", SqlDbType.NChar)
            .Parameters(1).Value = cFecha
        End With

        With cm3
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Historia1"
            .Connection = cnAgil
            .Parameters.Add("@Anexo", SqlDbType.NVarChar)
            .Parameters(0).Value = cAnexo
        End With

        ' Este Stored Procedure regresa todas las UDIS ordenadas por vigencia

        With cm4
            .CommandType = CommandType.StoredProcedure
            .CommandText = "TraeUdis1"
            .Connection = cnAgil
        End With

        ' Este Soted Procedure trae la Rentas por vencer del anexo solicitado a una
        ' determinada fecha

        With cm5
            .CommandType = CommandType.StoredProcedure
            .CommandText = "RentasXvencer1"
            .Connection = cnAgil
            .Parameters.Add("@cAnexo", SqlDbType.NVarChar)
            .Parameters(0).Value = cAnexo
            .Parameters.Add("@cFecha", SqlDbType.NChar)
            .Parameters(1).Value = cFecha
        End With

        ' Este Stored Procedure trae el valor de todas las tasas, ordenadas por vigencia y por tasa

        With cm7
            .CommandType = CommandType.StoredProcedure
            .CommandText = "GeneProv5"
            .Connection = cnAgil
        End With

        ' Este Stored Procedure trae la Tabla de amortización del seguro

        With cm8
            .CommandType = CommandType.StoredProcedure
            .CommandText = "TablaSeguro1"
            .Connection = cnAgil
            .Parameters.Add("@Anexo", SqlDbType.NVarChar)
            .Parameters(0).Value = cAnexo
        End With

        ' Llenar el DataSet lo cual abre y cierra la conexión

        daAnexo.Fill(dsAgil, "Anexos")
        daFacturas.Fill(dsAgil, "Factura")
        daHistoria.Fill(dsAgil, "Historia")
        daUdis.Fill(dsAgil, "Udis")
        daRtasxven.Fill(dsAgil, "Porvencer")
        daTasas.Fill(dsAgil, "Hista")
        daTabse.Fill(dsAgil, "Tabseg")

        drAnexo = dsAgil.Tables("Anexos").Rows(0)

        cFechacon = drAnexo("Fechacon")
        cFvenc = drAnexo("Fvenc")
        nPlazo = drAnexo("Plazo")
        cTipta = drAnexo("Tipta")
        nDifer = drAnexo("Difer")
        cFinse = drAnexo("Finse")
        cForca = drAnexo("Forca")
        nFactor = drAnexo("Factor")
        nPiso = drAnexo("Piso")
        nTecho = drAnexo("Techo")
        nRtasD = drAnexo("RtasD")
        nImpRD = drAnexo("ImpRD")
        dTermina = Termina(CTOD(cFvenc), nPlazo)
        cCliente = drAnexo("Cliente")

        With cm6
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DatosClie1"
            .Connection = cnAgil
            .Parameters.Add("@Cliente", SqlDbType.NVarChar)
            .Parameters(0).Value = cCliente
        End With
        daCliente.Fill(dsAgil, "Cliente")

        ' Creo la tabla Facturas que contendra todas las Rentas de este contrato

        dtFacturas.Columns.Add("Fecve", Type.GetType("System.String"))
        dtFacturas.Columns.Add("Importe", Type.GetType("System.Decimal"))
        dtFacturas.Columns.Add("SdoFactu", Type.GetType("System.Decimal"))
        dtFacturas.Columns.Add("Tasint", Type.GetType("System.Decimal"))
        dtFacturas.Columns.Add("Capital", Type.GetType("System.Decimal"))
        dtFacturas.Columns.Add("Interes", Type.GetType("System.Decimal"))
        dtFacturas.Columns.Add("Iva", Type.GetType("System.Decimal"))
        dtFacturas.Columns.Add("Days", Type.GetType("System.Decimal"))
        dtFacturas.Columns.Add("SaldoTotal", Type.GetType("System.Decimal"))
        dtFacturas.Columns.Add("Variacion", Type.GetType("System.Decimal"))

        ' Tenemos una copia de la Tabla Facturas para Guardar las rentas vencidas

        dtRtasven.Columns.Add("Fech1", Type.GetType("System.String"))
        dtRtasven.Columns.Add("Fecve", Type.GetType("System.String"))
        dtRtasven.Columns.Add("Fech2", Type.GetType("System.String"))
        dtRtasven.Columns.Add("Importe", Type.GetType("System.Decimal"))
        dtRtasven.Columns.Add("SdoFactu", Type.GetType("System.Decimal"))
        dtRtasven.Columns.Add("Tasint", Type.GetType("System.Decimal"))
        dtRtasven.Columns.Add("Capital", Type.GetType("System.Decimal"))
        dtRtasven.Columns.Add("Interes", Type.GetType("System.Decimal"))
        dtRtasven.Columns.Add("Iva", Type.GetType("System.Decimal"))
        dtRtasven.Columns.Add("Days", Type.GetType("System.Decimal"))
        dtRtasven.Columns.Add("SaldoTotal", Type.GetType("System.Decimal"))
        dtRtasven.Columns.Add("DiasMora", Type.GetType("System.Decimal"))
        dtRtasven.Columns.Add("Mora", Type.GetType("System.Decimal"))
        dtRtasven.Columns.Add("IvaMora", Type.GetType("System.Decimal"))
        dtRtasven.Columns.Add("Udiini", Type.GetType("System.String"))
        dtRtasven.Columns.Add("Udifin", Type.GetType("System.String"))
        dtRtasven.Columns.Add("Variacion", Type.GetType("System.Decimal"))

        ' Creo la tabla Datos que contendra los datos adicionales que necesito en este
        ' estado de cuenta

        dtDatos.Columns.Add("FVI", Type.GetType("System.String"))
        dtDatos.Columns.Add("FVF", Type.GetType("System.String"))
        dtDatos.Columns.Add("RVI", Type.GetType("System.String"))
        dtDatos.Columns.Add("RVF", Type.GetType("System.String"))
        dtDatos.Columns.Add("PPAGO", Type.GetType("System.String"))
        dtDatos.Columns.Add("UPAGO", Type.GetType("System.String"))
        dtDatos.Columns.Add("RPI", Type.GetType("System.String"))
        dtDatos.Columns.Add("RPF", Type.GetType("System.String"))
        dtDatos.Columns.Add("PROV", Type.GetType("System.String"))
        dtDatos.Columns.Add("Rentaspag", Type.GetType("System.Decimal"))
        dtDatos.Columns.Add("RV", Type.GetType("System.Decimal"))
        dtDatos.Columns.Add("SumaMora", Type.GetType("System.Decimal"))
        dtDatos.Columns.Add("Termina", Type.GetType("System.String"))
        dtDatos.Columns.Add("Fechapro", Type.GetType("System.String"))
        dtDatos.Columns.Add("Mora", Type.GetType("System.Decimal"))
        dtDatos.Columns.Add("IvaMora", Type.GetType("System.Decimal"))
        dtDatos.Columns.Add("RP", Type.GetType("System.Decimal"))
        dtDatos.Columns.Add("IP", Type.GetType("System.Decimal"))
        dtDatos.Columns.Add("SdoSeguro", Type.GetType("System.Decimal"))
        dtDatos.Columns.Add("ID", Type.GetType("System.Decimal"))
        dtDatos.Columns.Add("Provision", Type.GetType("System.Decimal"))
        dtDatos.Columns.Add("IvaProv", Type.GetType("System.Decimal"))
        dtDatos.Columns.Add("SumaIni", Type.GetType("System.Decimal"))
        dtDatos.Columns.Add("Opcompra", Type.GetType("System.Decimal"))
        dtDatos.Columns.Add("IvaOpcom", Type.GetType("System.Decimal"))
        dtDatos.Columns.Add("Pagosini", Type.GetType("System.Decimal"))
        dtDatos.Columns.Add("UltMora", Type.GetType("System.String"))
        dtDatos.Columns.Add("FPagosi", Type.GetType("System.String"))
        dtDatos.Columns.Add("Adelantos", Type.GetType("System.Decimal"))

        drUdis = dsAgil.Tables("Udis").Rows

        If dsAgil.Tables("Factura").Rows.Count > 0 Then
            cFVI = ""
            cRVI = ""
            cTermina = "N"
            For Each drFactura In dsAgil.Tables("Factura").Rows
                cTipar = drFactura("Tipar")
                cTipo = drFactura("Tipo")
                nDiasMora = 0
                nMora = 0
                nIvaMora = 0
                nSaldoFac = IIf(drFactura("IndPag") = "P", 0, drFactura("SaldoFac"))
                nTasa = drFactura("Tasa") + drFactura("Difer")
                nCapital = drFactura("Renpr") - drFactura("Intpr")
                nIva = Round(drFactura("Ivapr") + drFactura("Ivacapital") - drFactura("Bonifica"), 2)
                nUdiini = drFactura("Udi1")
                nUdifin = drFactura("Udi2")

                If Len(Trim(drFactura("Fepag"))) = 0 Then
                    cFvenc = drFactura("Feven")
                    nDiasMora = DateDiff(DateInterval.Day, CTOD(cFvenc), CTOD(cFecha))
                ElseIf drFactura("Feven") >= drFactura("Fepag") Then
                    cFvenc = drFactura("Feven")
                    nDiasMora = DateDiff(DateInterval.Day, CTOD(cFvenc), CTOD(cFecha))
                Else
                    cFvenc = drFactura("Fepag")
                    nDiasMora = DateDiff(DateInterval.Day, CTOD(cFvenc), CTOD(cFecha))
                End If

                If drFactura("Indpag") = "P" Then
                    nDiasMora = 0
                End If

                If nDiasMora < 0 Then
                    nDiasMora = 0
                End If

                If nDiasMora > 0 Then
                    nUdiini = 0
                    nUdifin = 0
                    CalcMora(cTipar, cTipo, cFecha, drUdis, nSaldoFac, nTasa * 2, nDiasMora, nMora, nIvaMora, 16)
                    DameUdi(drUdis, cFecha, cFvenc, nUdiini, nUdifin)
                End If

                nOpcion = drFactura("Opcion")
                nIvaOpc = drFactura("IvaOpcion")

                If nOpcion > 0 And nIvaOpc > 0 Then
                    cTermina = "S"
                Else
                    nOpcion = drAnexo("Opcion")
                    nIvaOpc = drAnexo("IvaOpcion")
                End If

                ' Busca la factura pagada más antigua así como la factura pagada más
                ' reciente aunque solo sea parcialmente.

                If Len(Trim(drFactura("Fepag"))) > 0 Then
                    If cFVI = "" Then
                        cFVI = Mes(drFactura("Feven"))
                    End If
                    cFVF = Mes(drFactura("Feven"))
                    nRentaspag += drFactura("ImporteFac") - nSaldoFac

                    drFactur = dtFacturas.NewRow()
                    drFactur("Fecve") = CTOD(drFactura("Feven")).ToShortDateString
                    drFactur("Importe") = drFactura("ImporteFac")
                    drFactur("SdoFactu") = nSaldoFac
                    drFactur("TasInt") = nTasa
                    drFactur("Capital") = nCapital
                    drFactur("Interes") = drFactura("Intpr")
                    drFactur("Iva") = Round(drFactura("Ivapr") + drFactura("Ivacapital") - drFactura("Bonifica"), 2)
                    drFactur("Days") = drFactura("Dias")
                    drFactur("SaldoTotal") = drFactura("Saldo") + drFactura("Salse")
                    drFactur("Variacion") = drFactura("Varpr")
                    dtFacturas.Rows.Add(drFactur)

                End If

                'Buscar la fecha de vencimiento de la factura no pagada más antigua
                'y la fecha de vencimiento de la factura no pagada más reciente.

                If nSaldoFac > 0 Then
                    If cRVI = "" Then
                        cRVI = drFactura("Feven")
                    End If
                    cRVF = drFactura("Feven")
                    nRV += nSaldoFac
                    nTotalMora += nMora
                    nTotalIvaMora += nIvaMora

                    drRtaven = dtRtasven.NewRow()
                    drRtaven("Fech1") = CTOD(cFvenc).ToShortDateString
                    drRtaven("Fecve") = CTOD(drFactura("Feven")).ToShortDateString
                    drRtaven("Fech2") = CTOD(cFecha).ToShortDateString
                    drRtaven("Importe") = drFactura("ImporteFac")
                    drRtaven("SdoFactu") = nSaldoFac
                    drRtaven("TasInt") = nTasa
                    drRtaven("Capital") = nCapital
                    drRtaven("Interes") = drFactura("Intpr")
                    drRtaven("Iva") = Round(drFactura("Ivapr") + drFactura("Ivacapital") - drFactura("Bonifica"), 2)
                    drRtaven("Days") = drFactura("Dias")
                    drRtaven("SaldoTotal") = drFactura("Saldo") + drFactura("Salse")
                    drRtaven("DiasMora") = nDiasMora
                    drRtaven("Mora") = nMora
                    drRtaven("IvaMora") = nIvaMora
                    drRtaven("Udiini") = FormatNumber(nUdiini, 6)
                    drRtaven("Udifin") = FormatNumber(nUdifin, 6)
                    drRtaven("Variacion") = drFactura("Varpr")
                    dtRtasven.Rows.Add(drRtaven)

                End If

            Next

            'Creo la Tabla auxiliar que guaradara los pagos qye se hayan hecho

            dtHistory.Columns.Add("Fecha", Type.GetType("System.String"))
            dtHistory.Columns.Add("Obser", Type.GetType("System.String"))
            dtHistory.Columns.Add("Abono", Type.GetType("System.Decimal"))
            dtHistory.Columns.Add("Documen", Type.GetType("System.String"))

            nSumaIniciales = 0
            nSumaMoratorios = 0
            nPagosi = 0
            nAdelantos = 0
            cPrimerPago = ""
            For Each drMovim In dsAgil.Tables("Historia").Rows
                If cPrimerPago = "" Then
                    cPrimerPago = drMovim("Fecha")
                End If
                cUltimoPago = drMovim("Fecha")
                cDoc = drMovim("Documento")
                nAbono = 0
                nOcurre = 0
                Select Case cDoc
                    Case Is = "1"
                        nAbono = IIf(drMovim("Balance") = "S", 0, drMovim("Importe"))
                        If drMovim("Letra") = "000" Then
                            nSumaIniciales += drMovim("Importe")
                            cPagosIni = drMovim("Fecha")
                        End If
                        cDocumento = "Nota de Cargo No. " & drMovim("Numero").ToString
                    Case Is = "2"
                        nAbono = drMovim("Importe")
                        cDocumento = "Recibo de Caja No. " & drMovim("Numero").ToString
                    Case Is = "4"
                        nAbono = 0
                        cDocumento = "Cargo Interno"
                    Case Is = "5"
                        nAbono = drMovim("Importe")
                        cDocumento = "Abono Interno"
                    Case Is = "6"
                        nAbono = drMovim("Importe")
                        cDocumento = "Factura de Pago " & drMovim("Numero").ToString
                        If drMovim("Letra") = "000" Then
                            nPagosi += drMovim("Importe")
                        End If
                End Select

                If Not IsDBNull(drMovim("Observa1")) Then
                    nOcurre = InStr(1, drMovim("Observa1"), "Moratorios", CompareMethod.Text)
                    nOcurre = IIf(nOcurre = 0, InStr(1, drMovim("Observa1"), "MORATORIOS", CompareMethod.Text), nOcurre)
                End If

                If nOcurre > 0 Then
                    cUltimaMora = drMovim("Fecha")
                    nSumaMoratorios += drMovim("Importe")
                End If

                If drMovim("Letra") = "888" Then
                    nAdelantos += drMovim("Importe")
                End If

                drHisto = dtHistory.NewRow()
                drHisto("Fecha") = CTOD(drMovim("Fecha"))
                drHisto("Obser") = Mid(drMovim("Observa1"), 1, 36)
                drHisto("Abono") = nAbono
                drHisto("Documen") = cDocumento
                dtHistory.Rows.Add(drHisto)

            Next

            'Creo la Tabla auxiliar que guaradara los rentas por vencer del contrato

            dtRentas.Columns.Add("Feven", Type.GetType("System.String"))
            dtRentas.Columns.Add("Saldo", Type.GetType("System.Decimal"))
            dtRentas.Columns.Add("Abcap", Type.GetType("System.Decimal"))
            dtRentas.Columns.Add("Inter", Type.GetType("System.Decimal"))
            dtRentas.Columns.Add("Renta", Type.GetType("System.Decimal"))
            dtRentas.Columns.Add("Ivacap", Type.GetType("System.Decimal"))
            nSaldoseg = 0

            cRPI = ""
            If cFecha < DTOC(dTermina) Then
                For Each drRenta In dsAgil.Tables("Porvencer").Rows
                    If drRenta("Indrec") = "S" Then
                        If cRPI = "" Then
                            cRPI = drRenta("Feven")
                        End If

                        cRPF = drRenta("Feven")
                        nIvacapital = drRenta("IvaCapital")

                        If cFechacon >= "20020301" And nRtasD = 0 And nImpRD > 0 Then
                            ' Existe Deposito en garantía
                            nIvacapital = 0
                        End If

                        nRP += Round(drRenta("Abcap") + drRenta("Inter"), 2)
                        nIP += drRenta("Inter")
                        nID += nIvacapital

                        drPorv = dtRentas.NewRow()
                        drPorv("Feven") = CTOD(drRenta("Feven")).ToShortDateString
                        drPorv("Saldo") = drRenta("Saldo")
                        drPorv("Abcap") = drRenta("Abcap")
                        drPorv("Inter") = drRenta("Inter")
                        drPorv("Renta") = Round(drRenta("Abcap") + drRenta("Inter"), 2)
                        drPorv("Ivacap") = nIvacapital
                        dtRentas.Rows.Add(drPorv)
                    End If
                Next

                If cFinse = "S" Then
                    For Each drTabse In dsAgil.Tables("Tabseg").Rows
                        If drTabse("Feven") > cFecha And drTabse("Indrec") = "S" Then
                            nSaldoseg += drTabse("Abcap")
                        End If
                    Next
                End If

                If Mid(cFecha, 7, 2) <> Mid(cFvenc, 7, 2) Then
                    cYear = Mid(cFecha, 1, 4)
                    cDia = Mid(cFvenc, 7, 2)
                    If Val(Mid(cFecha, 7, 2)) > Val(Mid(cFvenc, 7, 2)) Then
                        cMes = Mid(cFecha, 5, 2)
                    Else
                        nMes = Val(Mid(cFecha, 5, 2)) - 1
                        nMes = IIf(nMes = 0, 12, nMes)
                        nAño = IIf(nMes = 0, Val(cYear) - 1, Val(cYear))
                        cMes = IIf(nMes > 9, nMes.ToString, "0" & nMes.ToString)
                        cYear = nAño.ToString
                    End If
                    cProvision = cYear & cMes & cDia
                    nTasaf = 0
                    TraeTasa(dsAgil.Tables("Hista").Rows, cTipta, cProvision, nTasaf, cFechacon)
                    If cForca = "4" Then
                        nDifer = Round((nTasaf * nFactor) - nTasaf, 2)
                        If nDifer < nPiso Then
                            nDifer = nPiso
                        ElseIf nDifer > nTecho Then
                            nDifer = nTecho
                        End If
                    End If
                    nTasaf += nDifer
                End If
                nUdiini = 0
                nUdifin = 0
                nProvision = ((nRP - nIP + nSaldoseg) * (nTasaf / 100)) / 360 * DateDiff(DateInterval.Day, CTOD(cProvision), CTOD(cFecha))
                nIvaprov = CalcIvaU(drUdis, (nRP - nIP + nSaldoseg), nTasaf, cProvision, cFecha, nUdiini, nUdifin, nPorcentajeIVA)

            End If

            drDato = dtDatos.NewRow()
            drDato("FVI") = cFVI
            drDato("FVF") = cFVF
            drDato("RVI") = Mes(cRVI)
            drDato("RVF") = Mes(cRVF)
            drDato("PPAGO") = Mes(cPrimerPago)
            drDato("UPAGO") = Mes(cUltimoPago)
            drDato("RPI") = Mes(cRPI)
            drDato("RPF") = Mes(cRPF)
            drDato("PROV") = Mes(cProvision)
            drDato("Rentaspag") = nRentaspag
            drDato("RV") = nRV
            drDato("SumaMora") = nSumaMoratorios
            drDato("Termina") = cTermina
            drDato("Fechapro") = Mes(cFecha)
            drDato("Mora") = nTotalMora
            drDato("IvaMora") = nTotalIvaMora
            drDato("RP") = nRP
            drDato("IP") = nIP
            drDato("SdoSeguro") = nSaldoseg
            drDato("ID") = nID
            drDato("Provision") = Round(nProvision, 2)
            drDato("Ivaprov") = nIvaprov
            drDato("SumaIni") = nSumaIniciales
            drDato("Opcompra") = nOpcion
            drDato("IvaOpcom") = nIvaOpc
            drDato("Pagosini") = nPagosi
            drDato("UltMora") = Mes(cUltimaMora)
            drDato("Fpagosi") = Mes(cPagosIni)
            drDato("Adelantos") = nAdelantos
            dtDatos.Rows.Add(drDato)

            dsAgil.Tables.Remove("Factura")
            dsAgil.Tables.Remove("Historia")
            dsAgil.Tables.Remove("Udis")
            dsAgil.Tables.Remove("Porvencer")

            dsAgil.Tables.Add(dtDatos)
            dsAgil.Tables.Add(dtFacturas)
            dsAgil.Tables.Add(dtHistory)
            dsAgil.Tables.Add(dtRentas)
            dsAgil.Tables.Add(dtRtasven)
            dsAgil.Tables.Add(dtMoratorios)

            dsAgil.WriteXml("C:\Schema37.xml", XmlWriteMode.WriteSchema)

        Else
            MsgBox("Cliente sin facturas", MsgBoxStyle.Critical, "Mensaje del Sistema")
            Me.Close()
        End If

        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = True
        Button6.Enabled = True
        btnBegin.Enabled = False

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()
        cm3.Dispose()
        cm4.Dispose()
        cm5.Dispose()
        cm6.Dispose()
        cm7.Dispose()
        cm8.Dispose()

    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        ' Declaración de variables de conexión ADO .NET

        Dim dsTemporal As New DataSet()
        Dim newrptCertific As New rptCertific()

        dsTemporal.ReadXml("C:\Schema37.xml")
        newrptCertific.SetDataSource(dsTemporal)
        CrystalReportViewer1.ReportSource = newrptCertific

    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click

        ' Declaración de variables de conexión ADO .NET

        Dim dsTemporal As New DataSet()
        Dim newrptCertific1 As New rptCertific1()

        dsTemporal.ReadXml("C:\Schema37.xml")
        newrptCertific1.SetDataSource(dsTemporal)
        CrystalReportViewer1.ReportSource = newrptCertific1

    End Sub

    Private Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click

        ' Declaración de variables de conexión ADO .NET

        Dim dsTemporal As New DataSet()
        Dim newrptCertific2 As New rptCertific2()

        dsTemporal.ReadXml("C:\Schema37.xml")
        newrptCertific2.SetDataSource(dsTemporal)
        CrystalReportViewer1.ReportSource = newrptCertific2

    End Sub

    Private Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click

        ' Declaración de variables de conexión ADO .NET

        Dim dsTemporal As New DataSet()
        Dim newrptCertific3 As New rptCertific3()

        dsTemporal.ReadXml("C:\Schema37.xml")
        newrptCertific3.SetDataSource(dsTemporal)
        CrystalReportViewer1.ReportSource = newrptCertific3

    End Sub

    Private Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click

        ' Declaración de variables de conexión ADO .NET

        Dim dsTemporal As New DataSet()
        Dim newrptCertific4 As New rptCertific4()

        dsTemporal.ReadXml("C:\Schema37.xml")
        newrptCertific4.SetDataSource(dsTemporal)
        CrystalReportViewer1.ReportSource = newrptCertific4

    End Sub

    Private Sub Button6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button6.Click

        ' Declaración de variables de conexión ADO .NET

        Dim dsTemporal As New DataSet()
        Dim newrptCertific5 As New rptCertific5()

        dsTemporal.ReadXml("C:\Schema37.xml")
        newrptCertific5.SetDataSource(dsTemporal)
        CrystalReportViewer1.ReportSource = newrptCertific5

    End Sub

    Private Sub Button7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button7.Click
        Me.Close()
    End Sub

End Class
