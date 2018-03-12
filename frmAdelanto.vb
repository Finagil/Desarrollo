Option Explicit On

Imports System.Data.SqlClient
Imports System.Math
Imports System.IO

Public Class frmAdelanto

    Public Sub New(ByVal cAnexo As String)

        ' This call is required by the Windows Form Designer.

        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        txtAnexo.Text = cAnexo

    End Sub

    ' Declaración de variables de conexión ADO .NET de alcance Privado

    Dim dtMovimientos As DataTable
    Dim drMovimiento As DataRow
    Dim dtPagos As DataTable
    Dim drPago As DataRow

    ' Declaración de variables de datos de alcance Privado

    Dim cAnexo As String = ""
    Dim cBanco As String = ""
    Dim cCliente As String = ""
    Dim cFecha As String = ""
    Dim cLetra As String = ""
    Dim cSerie As String = ""
    Dim cSucursal As String = ""
    Dim cTipar As String = ""
    Dim nAbonoEquipo As Decimal = 0
    Dim nCargaNue As Decimal = 0
    Dim nCargaOri As Decimal = 0
    Dim nFactura As Decimal = 0
    Dim nIva As Decimal = 0
    Dim nLetra As Integer = 0
    Dim nPlazo As Integer = 0
    Dim nTasaIVACliente As Decimal = 0
    Dim nSubTotal As Decimal = 0
    Dim nTotal As Decimal = 0
    Dim nIDSerieA As Decimal = 0
    Dim nIDSerieMXL As Decimal = 0
    Dim nPorIeq As Decimal = 0.16

    Private Sub frmAdelanto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim daClientes As New SqlDataAdapter(cm1)
        Dim daBancos As New SqlDataAdapter(cm2)
        Dim dsAgil As New DataSet()
        Dim dsBcos As New DataSet()
        Dim drCliente As DataRow

        ' Declaración de variables de datos

        Dim cNombreCliente As String

        cAnexo = txtAnexo.Text

        cFecha = Now().ToShortDateString
        ToolStripStatusLabel1.Text = "Fecha de Aplicación " & cFecha
        cFecha = Mid(cFecha, 7, 4) & Mid(cFecha, 4, 2) & Mid(cFecha, 1, 2)
        lblAdeudaRentas.Text = ""

        ' Este Command trae todos los atributos de la tabla Clientes, para el cliente de un contrato dado.

        With cm1
            .CommandType = CommandType.Text
            .CommandText = "SELECT Clientes.* FROM Clientes " & _
                           "INNER JOIN Anexos ON Clientes.Cliente = Anexos.Cliente " & _
                           "WHERE Anexo = " & "'" & Mid(cAnexo, 1, 5) & Mid(cAnexo, 7, 4) & "'"
            .Connection = cnAgil
        End With

        ' Este Stored Procedure regresa los datos de los Bancos

        With cm2
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Bancos1"
            .Connection = cnAgil
        End With

        ' Llenar el DataSet lo cual abre y cierra la conexión

        daClientes.Fill(dsAgil, "Clientes")
        daBancos.Fill(dsBcos, "Bancos")

        drCliente = dsAgil.Tables("Clientes").Rows(0)

        cNombreCliente = drCliente("Descr")

        Me.Text = "Adelanto a Capital Contrato " & cAnexo & " " & cNombreCliente

        ' Traigo la Sucursal y la Tasa de IVA que aplica al cliente a efecto de poder determinar la Serie a utilizar

        cSucursal = drCliente("Sucursal")
        nTasaIVACliente = drCliente("TasaIVACliente")

        If cSucursal = "04" Or nTasaIVACliente = 11 Then
            cSerie = "MXL"
        Else
            cSerie = "A"
        End If

        ' Lleno cbBancos con el nombre de los Bancos

        cbBancos.DataSource = dsBcos
        cbBancos.DisplayMember = "Bancos.DescBanco"
        cbBancos.ValueMember = "Bancos.Banco"

        cbBancos.SelectedIndex = 0

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()

    End Sub

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click

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
        Dim daSeries As New SqlDataAdapter(cm7)
        Dim dsAgil As New DataSet()
        Dim drAnexo As DataRow
        Dim drDato As DataRow
        Dim drSerie As DataRow

        ' Declaración de variables de datos

        Dim cAdeudo As String = "N"
        Dim cBancoGarantia As String = ""
        Dim cFechacon As String
        Dim cFepag As String
        Dim cFinse As String = "N"
        Dim cFondeo As String
        Dim cIndpag As String
        Dim cTipta As String
        Dim lContinuar As Boolean
        Dim lSalir As Boolean
        Dim nAdeudoRentas As Decimal = 0
        Dim nAmorin As Decimal = 0
        Dim nDeposito As Decimal = 0
        Dim nDiasFact As Integer = 0
        Dim nDifer As Decimal = 0
        Dim nImpEq As Decimal = 0
        Dim nImpRD As Decimal = 0
        Dim nIntRealEq As Decimal = 0
        Dim nIvaDiferido As Decimal = 0
        Dim nIvaEq As Decimal = 0
        Dim nIvaRD As Decimal = 0
        Dim nOpcion As Decimal = 0
        Dim nPenalizacion As Decimal = 0
        Dim nRtasD As Decimal = 0
        Dim nSaldoEquipo As Decimal = 0
        Dim nSaldoFactura As Decimal = 0
        Dim nSaldoOtros As Decimal = 0
        Dim nSaldoSeguro As Decimal = 0
        Dim nTasaFact As Decimal = 0

        cAnexo = Mid(txtAnexo.Text, 1, 5) & Mid(txtAnexo.Text, 7, 4)
        cFepag = DTOC(DateTimePicker1.Value)

        ' El siguiente Stored Procedure trae todos los atributos de la tabla Anexos,
        ' para un anexo dado

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DatosCon1"
            .Connection = cnAgil
            .Parameters.Add("@Anexo", SqlDbType.NVarChar)
            .Parameters(0).Value = cAnexo
        End With

        ' Obtengo la tabla de amortización del Equipo

        With cm2
            .CommandType = CommandType.StoredProcedure
            .CommandText = "TablaEquipo1"
            .Connection = cnAgil
            .Parameters.Add("@Anexo", SqlDbType.NVarChar)
            .Parameters(0).Value = cAnexo
        End With

        ' Obtengo la tabla de amortización del Seguro

        With cm3
            .CommandType = CommandType.StoredProcedure
            .CommandText = "TablaSeguro1"
            .Connection = cnAgil
            .Parameters.Add("@Anexo", SqlDbType.NVarChar)
            .Parameters(0).Value = cAnexo
        End With

        ' Obtengo la tabla de amortización de Otros Adeudos

        With cm4
            .CommandType = CommandType.StoredProcedure
            .CommandText = "TraeAdeudos"
            .Connection = cnAgil
            .Parameters.Add("@Anexo", SqlDbType.NVarChar)
            .Parameters(0).Value = cAnexo
        End With

        ' El siguiente Command regresa todas las facturas generadas para el contrato dado

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

        ' El siguiente Command trae los consecutivos de cada Serie

        With cm7
            .CommandType = CommandType.Text
            .CommandText = "SELECT IDSerieA, IDSerieMXL FROM Llaves"
            .Connection = cnAgil
        End With

        ' El siguiente Command me indica si el crédito está dado en garantía.   Es importante saberlo porque los
        ' créditos que estén al amparo de la línea NAFIN no pueden recibir Adelantos a Capital si no es por
        ' autorización expresa del C.P. Abraham Torres

        With cm8
            .CommandType = CommandType.Text
            .CommandText = "SELECT Banco FROM Anexos " & _
                           "INNER JOIN CtrlAforos ON Anexos.Garantia = CtrlAforos.Garantia " & _
                           "WHERE Anexo = " & "'" & cAnexo & "'"
            .Connection = cnAgil
        End With

        ' Llenar el DataSet lo cual abre y cierra la conexión

        daAnexos.Fill(dsAgil, "Anexos")
        daEdoctav.Fill(dsAgil, "Edoctav")
        daEdoctas.Fill(dsAgil, "Edoctas")
        daEdoctao.Fill(dsAgil, "Edoctao")
        daFacturas.Fill(dsAgil, "Facturas")
        daHista.Fill(dsAgil, "Hista")
        daSeries.Fill(dsAgil, "Series")

        ' Toma el número consecutivo de facturas de pago -que depende de la Serie- y lo incrementa en uno

        drSerie = dsAgil.Tables("Series").Rows(0)
        nIDSerieA = drSerie("IDSerieA")
        nIDSerieMXL = drSerie("IDSerieMXL")

        If cSerie = "A" Then
            nFactura = nIDSerieA + 1
        ElseIf cSerie = "MXL" Then
            nFactura = nIDSerieMXL + 1
        End If

        txtSerie.Text = cSerie
        txtFactura.Text = nFactura.ToString

        ' Valida el Banco o Institución a la que pudiera estar garantizando este contrato con la finalidad
        ' de que si se trata de un Crédito que garantiza la LINEA NAFIN no acepte Adelantos a Capital. Este
        ' cambio lo solicitó el C.P. Abraham Torres y entrará en vigor a partir de la cobranza del 18/08/2010.

        cnAgil.Open()
        cBancoGarantia = cm8.ExecuteScalar()
        cnAgil.Close()

        If dsAgil.Tables("Anexos").Rows.Count > 0 Then
            lContinuar = True
        Else
            lContinuar = False
        End If

        If lContinuar = True Then

            drAnexo = dsAgil.Tables("Anexos").Rows(0)

            cCliente = drAnexo("Cliente")
            cTipar = drAnexo("Tipar")
            cFondeo = drAnexo("Fondeo")
            cFechacon = drAnexo("Fechacon")
            nPlazo = drAnexo("Plazo")
            cTipta = drAnexo("Tipta")
            nDifer = drAnexo("Difer")
            cFinse = drAnexo("Finse")
            cAdeudo = drAnexo("Adeudo")
            nRtasD = drAnexo("RtasD")
            nImpRD = drAnexo("ImpRD")
            nIvaRD = drAnexo("IvaRD")
            nImpEq = drAnexo("ImpEq")
            nIvaEq = drAnexo("Ivaeq")
            nAmorin = drAnexo("Amorin")
            nTasaFact = drAnexo("Tasas")
            nPenalizacion = drAnexo("Taspen")
            nOpcion = drAnexo("OC")

            If cFondeo = "02" Then
                lContinuar = False
                MsgBox("No existen prepagos en contratos descontados con NAFIN", MsgBoxStyle.Critical, "Mensaje del Sistema")
                Me.Close()
            ElseIf cFondeo = "03" Then
                lContinuar = False
                MsgBox("No existen prepagos en contratos descontados con FIRA", MsgBoxStyle.Critical, "Mensaje del Sistema")
                Me.Close()
            ElseIf cFondeo = "04" Then
                lContinuar = False
                MsgBox("No existen prepagos en contratos PARAFINANCIEROS", MsgBoxStyle.Critical, "Mensaje del Sistema")
                Me.Close()
            ElseIf drAnexo("Flcan") <> "A" Then
                lContinuar = False
                MsgBox("No se puede realizar el cálculo para un contrato NO ACTIVO", MsgBoxStyle.Critical, "Mensaje del Sistema")
                Me.Close()
            ElseIf dsAgil.Tables("Edoctav").Rows.Count = 0 Then
                lContinuar = False
                MsgBox("No existe la tabla de amortización de este contrato", MsgBoxStyle.Critical, "Mensaje del Sistema")
                Me.Close()
            ElseIf cTipar = "P" Then
                lContinuar = False
                MsgBox("No existen prepagos en contratos con ARRENDAMIENTO PURO", MsgBoxStyle.Critical, "Mensaje del Sistema")
                Me.Close()
            ElseIf cBancoGarantia = "11" Then
                lContinuar = False
                MsgBox("No existen Adelantos a Capital de Créditos LINEA NAFIN", MsgBoxStyle.Critical, "Mensaje del Sistema")
                Me.Close()
            End If

        End If

        If lContinuar = True Then

            ' Si existe seguro financiado se debe tomar el saldo insoluto del seguro
            ' que no haya sido facturado

            If cFinse = "S" Then
                nSaldoSeguro = 0
                lSalir = False
                For Each drDato In dsAgil.Tables("Edoctas").Rows
                    If drDato("Nufac") = 0 And drDato("Indrec") = "S" And lSalir = False Then
                        nSaldoSeguro = drDato("Saldo")
                        lSalir = True
                    End If
                Next
            End If

            ' Si existe saldo en otros adeudos debemos traer el saldo insoluto que no haya sido facturado;
            ' FALTA QUE CALCULE LA CARGA FINANCIERA ORIGINAL

            If cAdeudo = "S" Then
                nSaldoOtros = 0
                lSalir = False
                For Each drDato In dsAgil.Tables("Edoctao").Rows
                    If drDato("Nufac") = 0 And drDato("Indrec") = "S" And lSalir = False Then
                        nSaldoOtros = drDato("Saldo")
                        lSalir = True
                    End If
                Next
            End If

            ' Trae el saldo insoluto del equipo y (si procede) el IVA diferido del Capital;
            ' también puedo aprovechar para calcular la carga financiera original

            nDiasFact = 0
            nIntRealEq = 0
            nCargaOri = 0
            nLetra = 0
            For Each drDato In dsAgil.Tables("Edoctav").Rows
                If drDato("Nufac") = 0 And nLetra = 0 Then
                    nSaldoEquipo = drDato("Saldo")
                    nLetra = Val(drDato("Letra"))
                    cLetra = drDato("Letra")
                    CalcInte(dsAgil.Tables("Facturas").Rows, dsAgil.Tables("Hista").Rows, nTasaFact, nDiasFact, nIntRealEq, cFepag, cAnexo, cFechacon, cLetra, nSaldoEquipo, cTipta, nDifer)
                    If nDiasFact > 0 And nTasaFact = nDifer Then
                        lContinuar = False
                        MsgBox("Error en tasas de facturación; por lo que NO se puede calcular el finiquito", MsgBoxStyle.Exclamation, "Mensaje")
                        Me.Close()
                    End If
                End If
                If drDato("Nufac") = 0 Then
                    nIvaDiferido += drDato("IvaCapital")
                End If
                nCargaOri += drDato("Interes")
            Next

        End If

        If lContinuar = True Then

            ' Se debe checar el saldo de Facturas de Renta

            nAdeudoRentas = 0

            For Each drDato In dsAgil.Tables("Facturas").Rows
                cIndpag = drDato("IndPag")
                nSaldoFactura = 0
                If cIndpag <> "P" Then
                    nSaldoFactura = drDato("SaldoFac")
                    nAdeudoRentas = nAdeudoRentas + nSaldoFactura
                End If
            Next

            If nAdeudoRentas > 0 Then
                lblAdeudaRentas.Text = "AVISO : El contrato tiene adeudo por rentas"
            End If

            GroupBox1.Visible = True
            btnProcesar.Enabled = False

            nDeposito = 0
            If cFechacon >= "20020901" And nImpRD > 0 And nRtasD = 0 Then
                nDeposito = nIvaDiferido
            End If

            ' A partir del 1o. de enero de 2010, el IVA Diferido debe ser el 16% del Capital
            ' A partir del 18 de enero de 2012, el IVA Diferido depende del IVA que aplique al cliente de acuerdo a su domicilio fiscal

            If nIvaDiferido > 0 Then
                nIvaDiferido = Round(nSaldoEquipo * (nTasaIVACliente / 100), 2)
            End If

            txtSaldoEquipo.Text = FormatNumber(nSaldoEquipo, 2)
            txtImpDG.Text = FormatNumber(nDeposito, 2)
            txtIvaDiferido.Text = FormatNumber(nIvaDiferido, 2)
            txtSaldoSeguro.Text = FormatNumber(nSaldoSeguro, 2)
            txtSaldoOtros.Text = FormatNumber(nSaldoOtros, 2)
            txtTasaAplicada.Text = FormatNumber(nTasaFact, 4)

            txtPenalizacion.Text = FormatNumber(nPenalizacion, 2)
            txtDiasIntereses.Text = FormatNumber(nDiasFact, 0)

        End If

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

    Private Sub btnCalcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalcular.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daUdis As New SqlDataAdapter(cm1)
        Dim dsAgil As New DataSet()

        ' Declaración de variables de datos

        Dim cCatal As String
        Dim cCheque As String
        Dim cFepag As String
        Dim nAbonoSeguro As Decimal = 0
        Dim nAbonoOtros As Decimal = 0
        Dim nBonifica As Decimal = 0
        Dim nComision As Decimal = 0
        Dim nDeposito As Decimal = 0
        Dim nDG As Decimal = 0
        Dim nDiasIntereses As Integer = 0
        Dim nID As Decimal = 0
        Dim nImportePago As Decimal = 0
        Dim nIntereses As Decimal = 0
        Dim nInteresOtros As Decimal = 0
        Dim nIvaCapital As Decimal = 0
        Dim nIvaComision As Decimal = 0
        Dim nIvaDiferido As Decimal = 0
        Dim nIvaIntereses As Decimal = 0
        Dim nLimiteInferior As Decimal = 0
        Dim nLimiteSuperior As Decimal = 0
        Dim nPagoTotal As Decimal = 0
        Dim nPenalizacion As Decimal = 0
        Dim nPivote As Decimal = 0
        Dim nSaldoEquipo As Decimal = 0
        Dim nSaldoSeguro As Decimal = 0
        Dim nSaldoOtros As Decimal = 0
        Dim nTasaAplicada As Decimal = 0
        Dim nUdiInicial As Decimal = 0
        Dim nUdiFinal As Decimal = 0

        nSubTotal = 0
        nIva = 0
        nTotal = 0

        cFepag = DTOC(DateTimePicker1.Value)
        cBanco = cbBancos.SelectedValue.ToString()
        cCheque = txtCheque.Text

        ' Primero creo la tabla Movimientos que contendrá los registros contables de la cobranza

        dtMovimientos = New DataTable("Movimientos")
        dtMovimientos.Columns.Add("Anexo", Type.GetType("System.String"))
        dtMovimientos.Columns.Add("Letra", Type.GetType("System.String"))
        dtMovimientos.Columns.Add("Tipos", Type.GetType("System.String"))
        dtMovimientos.Columns.Add("Fepag", Type.GetType("System.String"))
        dtMovimientos.Columns.Add("Cve", Type.GetType("System.String"))
        dtMovimientos.Columns.Add("Imp", Type.GetType("System.Decimal"))
        dtMovimientos.Columns.Add("Tip", Type.GetType("System.String"))
        dtMovimientos.Columns.Add("Catal", Type.GetType("System.String"))
        dtMovimientos.Columns.Add("Esp", Type.GetType("System.Decimal"))
        dtMovimientos.Columns.Add("Coa", Type.GetType("System.String"))
        dtMovimientos.Columns.Add("Tipmon", Type.GetType("System.String"))
        dtMovimientos.Columns.Add("Banco", Type.GetType("System.String"))

        ' Luego creo la tabla dtPagos para guardar los conceptos que se cubrirán con el pago

        dtPagos = New DataTable("Pagos")
        dtPagos.Columns.Add("Anexo", Type.GetType("System.String"))
        dtPagos.Columns.Add("Fecha", Type.GetType("System.String"))
        dtPagos.Columns.Add("Concepto", Type.GetType("System.String"))
        dtPagos.Columns.Add("Importe", Type.GetType("System.Decimal"))
        dtPagos.Columns.Add("Banco", Type.GetType("System.String"))
        dtPagos.Clear()

        ' Este Stored Procedure regresa todas las UDIS ordenadas por vigencia

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "TraeUdis1"
            .Connection = cnAgil
        End With
        daUdis.Fill(dsAgil, "Udis")

        nDiasIntereses = CInt(txtDiasIntereses.Text)
        nTasaAplicada = CDec(txtTasaAplicada.Text)
        nPenalizacion = CDec(txtPenalizacion.Text)
        nSaldoEquipo = CDec(txtSaldoEquipo.Text)
        nSaldoSeguro = CDec(txtSaldoSeguro.Text)
        nSaldoOtros = CDec(txtSaldoOtros.Text)
        nDeposito = CDec(txtImpDG.Text)
        nIvaDiferido = CDec(txtIvaDiferido.Text)

        nImportePago = CDec(txtImportePago.Text)
        nLimiteSuperior = nImportePago
        nLimiteInferior = 0
        nPivote = 0
        nPagoTotal = 0

        Do While Abs(Round(nImportePago - nPagoTotal, 4)) > 0.0001

            nPivote = (nLimiteSuperior + nLimiteInferior) / 2

            nBonifica = 0
            nIvaCapital = 0

            If nPivote > nSaldoSeguro + nSaldoOtros Then

                If nDeposito > 0 Then

                    ' La bonificación solo aplica para el capital del equipo

                    nBonifica = (nPivote - nSaldoSeguro - nSaldoOtros) * nPorieq

                End If

                If nIvaDiferido > 0 Then
                    nIvaCapital = (nPivote - nSaldoSeguro - nSaldoOtros) * (nTasaIVACliente / 100)
                End If

            End If

            nIntereses = 0
            nInteresOtros = 0
            nIvaIntereses = 0
            nUdiInicial = 0
            nUdiFinal = 0

            If nDiasIntereses >= 0 Then

                If nPivote <= nSaldoSeguro Then
                    nAbonoSeguro = nPivote
                    nAbonoOtros = 0
                    nAbonoEquipo = 0
                Else
                    nAbonoSeguro = nSaldoSeguro
                    nPivote = nPivote - nAbonoSeguro
                    If nPivote <= nSaldoOtros Then
                        nAbonoOtros = nPivote
                        nAbonoEquipo = 0
                    Else
                        nAbonoOtros = nSaldoOtros
                        nAbonoEquipo = nPivote - nAbonoOtros
                    End If
                End If

                nIntereses = (nAbonoEquipo + nAbonoSeguro) * nTasaAplicada / 36000 * nDiasIntereses
                nIvaIntereses = CalcIvaU(dsAgil.Tables("Udis").Rows, (nAbonoEquipo + nAbonoSeguro), nTasaAplicada, DTOC(DateAdd(DateInterval.Day, -nDiasIntereses, CTOD(cFepag))), cFepag, nUdiInicial, nUdiFinal, (nTasaIVACliente / 100))
                If nIntereses > 0 And (nUdiInicial = 0 Or nUdiFinal = 0) Then
                    MsgBox("Error en los valores de las UDIS", MsgBoxStyle.Exclamation, "Mensaje")
                    Me.Close()
                End If

                nInteresOtros = nAbonoOtros * nTasaAplicada / 36000 * nDiasIntereses
                nIvaIntereses = nIvaIntereses + (nInteresOtros * (nTasaIVACliente / 100))
                nIntereses = nIntereses + nInteresOtros

                nPivote = nAbonoEquipo + nAbonoSeguro + nAbonoOtros

            End If

            txtUDIInicial.Text = FormatNumber(nUdiInicial, 6)
            txtUDIFinal.Text = FormatNumber(nUdiFinal, 6)

            nComision = 0
            nIvaComision = 0
            If nPenalizacion > 0 Then
                nComision = nPivote * nPenalizacion / 100
                nIvaComision = nComision * (nTasaIVACliente / 100)
            End If

            nPagoTotal = nPivote - nBonifica + nIvaCapital + nIntereses + nIvaIntereses + nComision + nIvaComision

            If nPagoTotal < nImportePago Then
                nLimiteInferior = nPivote
            ElseIf nPagoTotal > nImportePago Then
                nLimiteSuperior = nPivote
            End If
        Loop

        ' Cuando termina el ciclo, en nPivote tengo el Importe del Adelanto a Capital, aunque este
        ' debe aplicarse en el siguiente orden:

        ' Primero abona a Capital del Seguro
        ' Después abona a Capital de Otros Adeudos
        ' Al final abona a Capital del Equipo

        nID = 0
        nDG = 0
        If nBonifica > 0 Then
            nID = -nBonifica / (1 + nPorieq) * (nPorieq)
            nDG = -nBonifica / (1 + nPorieq)
        End If

        txtIntereses.Text = FormatNumber(nIntereses, 2)
        txtIvaIntereses.Text = FormatNumber(nIvaIntereses, 2)
        txtComision.Text = FormatNumber(nComision, 2)
        txtIvaComision.Text = FormatNumber(nIvaComision, 2)
        txtAbonoSeguro.Text = FormatNumber(nAbonoSeguro, 2)
        txtAbonoOtros.Text = FormatNumber(nAbonoOtros, 2)
        txtIvaCapital.Text = FormatNumber(nIvaCapital, 2)
        txtID.Text = FormatNumber(nID, 2)
        txtAbonoEquipo.Text = FormatNumber(nAbonoEquipo, 2)
        txtDG.Text = FormatNumber(nDG, 2)

        lblIntereses.Visible = True
        txtIntereses.Visible = True

        lblIvaIntereses.Visible = True
        txtIvaIntereses.Visible = True

        lblComision.Visible = True
        txtComision.Visible = True

        lblIvaComision.Visible = True
        txtIvaComision.Visible = True

        lblAbonoSeguro.Visible = True
        txtAbonoSeguro.Visible = True

        lblAbonoOtros.Visible = True
        txtAbonoOtros.Visible = True

        lblIvaCapital.Visible = True
        txtIvaCapital.Visible = True

        lblID.Visible = True
        txtID.Visible = True

        lblAbonoEquipo.Visible = True
        txtAbonoEquipo.Visible = True

        lblDG.Visible = True
        txtDG.Visible = True

        cCatal = "F"

        ' Aquí se generan los asientos contables (es importante recordar que el cargo a Bancos
        ' se hace en forma automática en el módulo Ingresos)

        If nIntereses > 0 Then

            drMovimiento = dtMovimientos.NewRow()
            drMovimiento("Anexo") = cAnexo
            drMovimiento("Letra") = "888"
            drMovimiento("Tipos") = "3"
            drMovimiento("Fepag") = cFecha
            drMovimiento("Cve") = "16"
            drMovimiento("Imp") = nIntereses
            drMovimiento("Tip") = "S"
            drMovimiento("Catal") = cCatal
            drMovimiento("Esp") = 0
            drMovimiento("Coa") = "1"
            drMovimiento("Tipmon") = "01"
            drMovimiento("Banco") = cBanco
            dtMovimientos.Rows.Add(drMovimiento)

            drPago = dtPagos.NewRow()
            drPago("Anexo") = cAnexo
            drPago("Fecha") = cFecha
            drPago("Concepto") = "INTERESES"
            drPago("Importe") = nIntereses
            drPago("Banco") = cBanco
            dtPagos.Rows.Add(drPago)

            nSubTotal = nSubTotal + nIntereses

        End If

        If nIvaIntereses > 0 Then

            drMovimiento = dtMovimientos.NewRow()
            drMovimiento("Anexo") = cAnexo
            drMovimiento("Letra") = "888"
            drMovimiento("Tipos") = "3"
            drMovimiento("Fepag") = cFecha
            drMovimiento("Cve") = "33"
            drMovimiento("Imp") = nIvaIntereses
            drMovimiento("Tip") = "S"
            drMovimiento("Catal") = cCatal
            drMovimiento("Esp") = 0
            drMovimiento("Coa") = "1"
            drMovimiento("Tipmon") = "01"
            drMovimiento("Banco") = cBanco
            dtMovimientos.Rows.Add(drMovimiento)

            drPago = dtPagos.NewRow()
            drPago("Anexo") = cAnexo
            drPago("Fecha") = cFecha
            drPago("Concepto") = "IVA INTERESES"
            drPago("Importe") = nIvaIntereses
            drPago("Banco") = cBanco
            dtPagos.Rows.Add(drPago)

            nIva = nIva + nIvaIntereses

        End If

        If nComision > 0 Then

            drMovimiento = dtMovimientos.NewRow()
            drMovimiento("Anexo") = cAnexo
            drMovimiento("Letra") = "888"
            drMovimiento("Tipos") = "3"
            drMovimiento("Fepag") = cFecha
            drMovimiento("Cve") = "24"
            drMovimiento("Imp") = nComision
            drMovimiento("Tip") = "S"
            drMovimiento("Catal") = cCatal
            drMovimiento("Esp") = 0
            drMovimiento("Coa") = "1"
            drMovimiento("Tipmon") = "01"
            drMovimiento("Banco") = cBanco
            dtMovimientos.Rows.Add(drMovimiento)

            drPago = dtPagos.NewRow()
            drPago("Anexo") = cAnexo
            drPago("Fecha") = cFecha
            drPago("Concepto") = "COMISION POR ADELANTO"
            drPago("Importe") = nComision
            drPago("Banco") = cBanco
            dtPagos.Rows.Add(drPago)

            nSubTotal = nSubTotal + nComision

        End If

        If nIvaComision > 0 Then

            drMovimiento = dtMovimientos.NewRow()
            drMovimiento("Anexo") = cAnexo
            drMovimiento("Letra") = "888"
            drMovimiento("Tipos") = "3"
            drMovimiento("Fepag") = cFecha
            drMovimiento("Cve") = "32"
            drMovimiento("Imp") = nIvaComision
            drMovimiento("Tip") = "S"
            drMovimiento("Catal") = cCatal
            drMovimiento("Esp") = 0
            drMovimiento("Coa") = "1"
            drMovimiento("Tipmon") = "01"
            drMovimiento("Banco") = cBanco
            dtMovimientos.Rows.Add(drMovimiento)

            drPago = dtPagos.NewRow()
            drPago("Anexo") = cAnexo
            drPago("Fecha") = cFecha
            drPago("Concepto") = "IVA COMISION POR ADELANTO"
            drPago("Importe") = nIvaComision
            drPago("Banco") = cBanco
            dtPagos.Rows.Add(drPago)

            nIva = nIva + nIvaComision

        End If

        If nAbonoSeguro > 0 Then

            drMovimiento = dtMovimientos.NewRow()
            drMovimiento("Anexo") = cAnexo
            drMovimiento("Letra") = "888"
            drMovimiento("Tipos") = "3"
            drMovimiento("Fepag") = cFecha
            drMovimiento("Cve") = "28"
            drMovimiento("Imp") = nAbonoSeguro
            drMovimiento("Tip") = "S"
            drMovimiento("Catal") = cCatal
            drMovimiento("Esp") = 0
            drMovimiento("Coa") = "1"
            drMovimiento("Tipmon") = "01"
            drMovimiento("Banco") = cBanco
            dtMovimientos.Rows.Add(drMovimiento)

            drPago = dtPagos.NewRow()
            drPago("Anexo") = cAnexo
            drPago("Fecha") = cFecha
            drPago("Concepto") = "ADELANTO CAPITAL SEGURO"
            drPago("Importe") = nAbonoSeguro
            drPago("Banco") = cBanco
            dtPagos.Rows.Add(drPago)

            nSubTotal = nSubTotal + nAbonoSeguro

        End If

        If nAbonoOtros > 0 Then

            drMovimiento = dtMovimientos.NewRow()
            drMovimiento("Anexo") = cAnexo
            drMovimiento("Letra") = "888"
            drMovimiento("Tipos") = "3"
            drMovimiento("Fepag") = cFecha
            drMovimiento("Cve") = "55"
            drMovimiento("Imp") = nAbonoOtros
            drMovimiento("Tip") = "S"
            drMovimiento("Catal") = cCatal
            drMovimiento("Esp") = 0
            drMovimiento("Coa") = "1"
            drMovimiento("Tipmon") = "01"
            drMovimiento("Banco") = cBanco
            dtMovimientos.Rows.Add(drMovimiento)

            drPago = dtPagos.NewRow()
            drPago("Anexo") = cAnexo
            drPago("Fecha") = cFecha
            drPago("Concepto") = "ADELANTO CAPITAL OTROS ADEUDOS"
            drPago("Importe") = nAbonoOtros
            drPago("Banco") = cBanco
            dtPagos.Rows.Add(drPago)

            nSubTotal = nSubTotal + nAbonoOtros

        End If

        If Round(nIvaCapital, 2) > 0 Then

            drMovimiento = dtMovimientos.NewRow()
            drMovimiento("Anexo") = cAnexo
            drMovimiento("Letra") = "888"
            drMovimiento("Tipos") = "3"
            drMovimiento("Fepag") = cFecha
            drMovimiento("Cve") = "08"
            drMovimiento("Imp") = nIvaCapital
            drMovimiento("Tip") = "S"
            drMovimiento("Catal") = cCatal
            drMovimiento("Esp") = 0
            drMovimiento("Coa") = "1"
            drMovimiento("Tipmon") = "01"
            drMovimiento("Banco") = cBanco
            dtMovimientos.Rows.Add(drMovimiento)

            If cTipar = "F" Then

                drMovimiento = dtMovimientos.NewRow()
                drMovimiento("Anexo") = cAnexo
                drMovimiento("Letra") = "888"
                drMovimiento("Tipos") = "3"
                drMovimiento("Fepag") = cFecha
                drMovimiento("Cve") = "88"
                drMovimiento("Imp") = nIvaCapital
                drMovimiento("Tip") = "S"
                drMovimiento("Catal") = cCatal
                drMovimiento("Esp") = 0
                drMovimiento("Coa") = "0"
                drMovimiento("Tipmon") = "01"
                drMovimiento("Banco") = cBanco
                dtMovimientos.Rows.Add(drMovimiento)

                drMovimiento = dtMovimientos.NewRow()
                drMovimiento("Anexo") = cAnexo
                drMovimiento("Letra") = "888"
                drMovimiento("Tipos") = "3"
                drMovimiento("Fepag") = cFecha
                drMovimiento("Cve") = "87"
                drMovimiento("Imp") = nIvaCapital
                drMovimiento("Tip") = "S"
                drMovimiento("Catal") = cCatal
                drMovimiento("Esp") = 0
                drMovimiento("Coa") = "1"
                drMovimiento("Tipmon") = "01"
                drMovimiento("Banco") = cBanco
                dtMovimientos.Rows.Add(drMovimiento)

            End If

            drPago = dtPagos.NewRow()
            drPago("Anexo") = cAnexo
            drPago("Fecha") = cFecha
            drPago("Concepto") = "IVA DEL CAPITAL EQUIPO"
            drPago("Importe") = nIvaCapital
            drPago("Banco") = cBanco
            dtPagos.Rows.Add(drPago)

            nIva = nIva + nIvaCapital

        End If

        If nID < 0 Then

            ' Solo existe esta bonificación en contratos de arrendamiento financiero que hubieran dejado
            ' depósito en garantía.   El depósito en garantía de los créditos refaccionarios se bonifica
            ' en una sola exhibición al final del plazo o si se finiquita en contrato anticipadamente.

            drMovimiento = dtMovimientos.NewRow()
            drMovimiento("Anexo") = cAnexo
            drMovimiento("Letra") = "888"
            drMovimiento("Tipos") = "3"
            drMovimiento("Fepag") = cFecha
            drMovimiento("Cve") = "20"
            drMovimiento("Imp") = -nID
            drMovimiento("Tip") = "S"
            drMovimiento("Catal") = cCatal
            drMovimiento("Esp") = 0
            drMovimiento("Coa") = "0"
            drMovimiento("Tipmon") = "01"
            drMovimiento("Banco") = cBanco
            dtMovimientos.Rows.Add(drMovimiento)

            drPago = dtPagos.NewRow()
            drPago("Anexo") = cAnexo
            drPago("Fecha") = cFecha
            drPago("Concepto") = "APLICACION DEPOSITO vs IVA CAPITAL"
            drPago("Importe") = nID
            drPago("Banco") = cBanco
            dtPagos.Rows.Add(drPago)

            nIva = nIva + nID

        End If

        If Round(nAbonoEquipo, 2) > 0 Then

            drMovimiento = dtMovimientos.NewRow()
            drMovimiento("Anexo") = cAnexo
            drMovimiento("Letra") = "888"
            drMovimiento("Tipos") = "3"
            drMovimiento("Fepag") = cFecha
            Select Case cTipar
                Case "F"
                    drMovimiento("Cve") = "06"
                Case "P"
                    drMovimiento("Cve") = "06"
                Case "R"
                    drMovimiento("Cve") = "45"
                Case "S"
                    drMovimiento("Cve") = "55"
            End Select
            drMovimiento("Imp") = nAbonoEquipo
            drMovimiento("Tip") = "S"
            drMovimiento("Catal") = cCatal
            drMovimiento("Esp") = 0
            drMovimiento("Coa") = "1"
            drMovimiento("Tipmon") = "01"
            drMovimiento("Banco") = cBanco
            dtMovimientos.Rows.Add(drMovimiento)

            ' Recordar que solo existe reconocimiento del COSTO y del INGRESO para resultados,
            ' cuando se trate de arrendamiento financiero

            If cTipar = "F" Then

                drMovimiento = dtMovimientos.NewRow()
                drMovimiento("Anexo") = cAnexo
                drMovimiento("Letra") = "888"
                drMovimiento("Tipos") = "3"
                drMovimiento("Fepag") = cFecha
                drMovimiento("Cve") = "29"
                drMovimiento("Imp") = nAbonoEquipo
                drMovimiento("Tip") = "S"
                drMovimiento("Catal") = cCatal
                drMovimiento("Esp") = 0
                drMovimiento("Coa") = "0"
                drMovimiento("Tipmon") = "01"
                drMovimiento("Banco") = cBanco
                dtMovimientos.Rows.Add(drMovimiento)

                drMovimiento = dtMovimientos.NewRow()
                drMovimiento("Anexo") = cAnexo
                drMovimiento("Letra") = "888"
                drMovimiento("Tipos") = "3"
                drMovimiento("Fepag") = cFecha
                drMovimiento("Cve") = "13"
                drMovimiento("Imp") = nAbonoEquipo
                drMovimiento("Tip") = "S"
                drMovimiento("Catal") = cCatal
                drMovimiento("Esp") = 0
                drMovimiento("Coa") = "1"
                drMovimiento("Tipmon") = "01"
                drMovimiento("Banco") = cBanco
                dtMovimientos.Rows.Add(drMovimiento)

            End If

            If cTipar = "F" Then

                drMovimiento = dtMovimientos.NewRow()
                drMovimiento("Anexo") = cAnexo
                drMovimiento("Letra") = "888"
                drMovimiento("Tipos") = "3"
                drMovimiento("Fepag") = cFecha
                drMovimiento("Cve") = "86"
                drMovimiento("Imp") = nAbonoEquipo
                drMovimiento("Tip") = "S"
                drMovimiento("Catal") = cCatal
                drMovimiento("Esp") = 0
                drMovimiento("Coa") = "0"
                drMovimiento("Tipmon") = "01"
                drMovimiento("Banco") = cBanco
                dtMovimientos.Rows.Add(drMovimiento)

                drMovimiento = dtMovimientos.NewRow()
                drMovimiento("Anexo") = cAnexo
                drMovimiento("Letra") = "888"
                drMovimiento("Tipos") = "3"
                drMovimiento("Fepag") = cFecha
                drMovimiento("Cve") = "85"
                drMovimiento("Imp") = nAbonoEquipo
                drMovimiento("Tip") = "S"
                drMovimiento("Catal") = cCatal
                drMovimiento("Esp") = 0
                drMovimiento("Coa") = "1"
                drMovimiento("Tipmon") = "01"
                drMovimiento("Banco") = cBanco
                dtMovimientos.Rows.Add(drMovimiento)

            End If

            drPago = dtPagos.NewRow()
            drPago("Anexo") = cAnexo
            drPago("Fecha") = cFecha
            drPago("Concepto") = "ADELANTO CAPITAL EQUIPO"
            drPago("Importe") = nAbonoEquipo
            drPago("Banco") = cBanco
            dtPagos.Rows.Add(drPago)

            nSubTotal = nSubTotal + nAbonoEquipo

        End If

        If nDG < 0 Then

            ' Solo existe esta bonificación en contratos de arrendamiento financiero que hubieran dejado
            ' depósito en garantía.   El depósito en garantía de los créditos refaccionarios se bonifica
            ' en una sola exhibición al final del plazo o si se finiquita en contrato anticipadamente.

            drMovimiento = dtMovimientos.NewRow()
            drMovimiento("Anexo") = cAnexo
            drMovimiento("Letra") = "888"
            drMovimiento("Tipos") = "3"
            drMovimiento("Fepag") = cFecha
            drMovimiento("Cve") = "05"
            drMovimiento("Imp") = -nDG
            drMovimiento("Tip") = "S"
            drMovimiento("Catal") = cCatal
            drMovimiento("Esp") = 0
            drMovimiento("Coa") = "0"
            drMovimiento("Tipmon") = "01"
            drMovimiento("Banco") = cBanco
            dtMovimientos.Rows.Add(drMovimiento)

            drPago = dtPagos.NewRow()
            drPago("Anexo") = cAnexo
            drPago("Fecha") = cFecha
            drPago("Concepto") = "APLICACION DEPOSITO vs CAPITAL"
            drPago("Importe") = nDG
            drPago("Banco") = cBanco
            dtPagos.Rows.Add(drPago)

            nSubTotal = nSubTotal + nDG

        End If

        nTotal = nSubTotal + nIva

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub btnAplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAplicar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim cm4 As New SqlCommand()
        Dim cm5 As New SqlCommand()
        Dim cm6 As New SqlCommand()
        Dim cm7 As New SqlCommand()
        Dim dsAgil As New DataSet()
        Dim daEdoctav As New SqlDataAdapter(cm3)
        Dim daEdoctas As New SqlDataAdapter(cm4)
        Dim daEdoctao As New SqlDataAdapter(cm5)
        Dim daClientes As New SqlDataAdapter(cm6)
        Dim drEdoctav As DataRow
        Dim drEdoctas As DataRow
        Dim drEdoctao As DataRow
        Dim drCliente As DataRow
        Dim strUpdate As String
        Dim strInsert As String
        Dim strDelete As String

        ' Declaración de variables de datos

        Dim cCalle As String
        Dim cCheque As String
        Dim cColonia As String
        Dim cCopos As String
        Dim cDelegacion As String
        Dim cEstado As String
        Dim cNombre As String
        Dim cObserva As String
        Dim cRfc As String
        Dim cRenglon As String = ""
        Dim cCuentaPago As String
        Dim cFormaPago As String
        Dim nImporte As Decimal = 0
        Dim nLetraSeguro As Decimal = 0
        Dim nPlazoRestante As Integer = 0
        Dim nPlazoSeguro As Decimal = 0
        Dim nSaldoSeguro As Decimal = 0
        Dim nSaldoOtros As Decimal = 0
        Dim nPlazoOtros As Decimal = 0
        Dim nLetraOtros As Decimal = 0
        Dim i As Integer

        cCheque = txtCheque.Text
        nFactura = CInt(txtFactura.Text)

        cnAgil.Open()
        For Each drPago In dtPagos.Rows()
            cObserva = drPago("Concepto")
            nImporte = drPago("Importe")
            If nImporte <> 0 Then
                strInsert = "INSERT INTO Historia(Documento, Serie, Numero, Fecha, Anexo, Letra, Banco, Cheque, Balance, Importe, Observa1)"
                strInsert = strInsert & " VALUES ('"
                strInsert = strInsert & "6" & "', '"
                strInsert = strInsert & cSerie & "', "
                strInsert = strInsert & nFactura & ", '"
                strInsert = strInsert & cFecha & "', '"
                strInsert = strInsert & cAnexo & "', '"
                strInsert = strInsert & "888" & "', '"
                strInsert = strInsert & cBanco & "', '"
                strInsert = strInsert & cCheque & "', '"
                strInsert = strInsert & "N" & "', '"
                strInsert = strInsert & nImporte & "', '"
                strInsert = strInsert & cObserva
                strInsert = strInsert & "')"
                cm1 = New SqlCommand(strInsert, cnAgil)
                cm1.ExecuteNonQuery()
            End If
        Next
        cnAgil.Close()

        If CDec(txtAbonoSeguro.Text) > 0 Then

            nSaldoSeguro = CDec(txtSaldoSeguro.Text)
            nPlazoSeguro = 0
            nLetraSeguro = 0

            ' El siguiente Stored Procedure trae los movimientos de la tabla de amortización del seguro

            With cm4
                .CommandType = CommandType.StoredProcedure
                .CommandText = "TablaSeguro1"
                .Connection = cnAgil
                .Parameters.Add("@Anexo", SqlDbType.NVarChar)
                .Parameters(0).Value = cAnexo
            End With

            ' Llenar el dataset lo cual abre y cierra la conexión

            daEdoctas.Fill(dsAgil, "Edoctas")

            For Each drEdoctas In dsAgil.Tables("Edoctas").Rows
                If drEdoctas("Nufac") = 0 And nLetraSeguro = 0 Then
                    nLetraSeguro = Val(drEdoctas("Letra"))
                End If
                nPlazoSeguro = Val(drEdoctas("Letra"))
            Next

            dsAgil.Tables.Remove("Edoctas")

            If CDec(txtAbonoSeguro.Text) = CDec(txtSaldoSeguro.Text) Then

                ' El pago cubre completamente el saldo del seguro, por lo que debe eliminar 
                ' los vencimientos no facturados del seguro

                strDelete = "DELETE FROM Edoctas WHERE Nufac = 0 AND Anexo = '" & cAnexo & "'"
                cm2 = New SqlCommand(strDelete, cnAgil)
                cnAgil.Open()
                cm2.ExecuteNonQuery()
                cnAgil.Close()

            Else

                ' El pago a cuenta de capital no cubre totalmente el saldo del seguro, 
                ' por lo que debe aplicarse como adelanto a capital del seguro y reconstruir la
                ' tabla del seguro

                RegTabla(cAnexo, CDec(txtSaldoSeguro.Text) - CDec(txtAbonoSeguro.Text), nPlazoSeguro - nLetraSeguro + 1, "S")

            End If

            ' Independientemente de si se trató de un pago parcial o total del seguro, debe insertar
            ' un registro a la tabla de amortización del seguro por este concepto y en número de factura
            ' tendrá 9999999

            strInsert = "INSERT INTO Edoctas(Anexo, Letra, Feven, Nufac, IndRec, Saldo, Abcap, Inter, Iva)"
            strInsert = strInsert & " VALUES ('"
            strInsert = strInsert & cAnexo & "', '"
            strInsert = strInsert & Stuff(CStr(nLetraSeguro - 1), "I", "0", 3) & "', '"
            strInsert = strInsert & cFecha & "', '"
            strInsert = strInsert & 9999999 & "', '"
            strInsert = strInsert & "N" & "', '"
            strInsert = strInsert & CDec(txtSaldoSeguro.Text) & "', '"
            strInsert = strInsert & CDec(txtAbonoSeguro.Text) & "', '"
            strInsert = strInsert & 0 & "', '"
            strInsert = strInsert & 0
            strInsert = strInsert & "')"
            cm1 = New SqlCommand(strInsert, cnAgil)
            cnAgil.Open()
            cm1.ExecuteNonQuery()
            cnAgil.Close()

        End If

        If CDec(txtAbonoOtros.Text) > 0 Then

            nSaldoOtros = CDec(txtSaldoOtros.Text)
            nPlazoOtros = 0
            nLetraOtros = 0

            ' El siguiente Stored Procedure trae los movimientos de la tabla de amortización de Otros Adeudos

            With cm5
                .CommandType = CommandType.StoredProcedure
                .CommandText = "TraeAdeudos"
                .Connection = cnAgil
                .Parameters.Add("@Anexo", SqlDbType.NVarChar)
                .Parameters(0).Value = cAnexo
            End With

            ' Llenar el dataset lo cual abre y cierra la conexión

            daEdoctao.Fill(dsAgil, "Edoctao")

            For Each drEdoctao In dsAgil.Tables("Edoctao").Rows
                If drEdoctao("Nufac") = 0 And nLetraOtros = 0 Then
                    nLetraOtros = Val(drEdoctao("Letra"))
                End If
                nPlazoOtros = Val(drEdoctao("Letra"))
            Next

            dsAgil.Tables.Remove("Edoctao")

            If CDec(txtAbonoOtros.Text) = CDec(txtSaldoOtros.Text) Then

                ' El pago cubre completamente el Saldo de Otros Adeudos, por lo que debe eliminar 
                ' los vencimientos no facturados

                strDelete = "DELETE FROM Edoctao WHERE Nufac = 0 AND Anexo = '" & cAnexo & "'"
                cm2 = New SqlCommand(strDelete, cnAgil)
                cnAgil.Open()
                cm2.ExecuteNonQuery()
                cnAgil.Close()

            Else

                ' El pago no cubre totalmente el Saldo de Otros Adeudos, por lo que debe
                ' aplicarse como adelanto a capital de Otros Adeudos y reconstruir su tabla

                RegTabla(cAnexo, CDec(txtSaldoOtros.Text) - CDec(txtAbonoOtros.Text), nPlazoOtros - nLetraOtros + 1, "O")

            End If

            ' Independientemente de si se trató de un pago parcial o total de Otros Adeudos, debe insertar
            ' un registro a la tabla de amortización por este concepto y en número de factura tendrá 9999999

            strInsert = "INSERT INTO Edoctao(Anexo, Letra, Feven, Nufac, IndRec, Saldo, Abcap, Inter, Iva)"
            strInsert = strInsert & " VALUES ('"
            strInsert = strInsert & cAnexo & "', '"
            strInsert = strInsert & Stuff(CStr(nLetraOtros - 1), "I", "0", 3) & "', '"
            strInsert = strInsert & cFecha & "', '"
            strInsert = strInsert & 9999999 & "', '"
            strInsert = strInsert & "N" & "', '"
            strInsert = strInsert & CDec(txtSaldoOtros.Text) & "', '"
            strInsert = strInsert & CDec(txtAbonoOtros.Text) & "', '"
            strInsert = strInsert & 0 & "', '"
            strInsert = strInsert & 0
            strInsert = strInsert & "')"
            cm1 = New SqlCommand(strInsert, cnAgil)
            cnAgil.Open()
            cm1.ExecuteNonQuery()
            cnAgil.Close()

        End If

        If CDec(txtAbonoEquipo.Text) > 0 Then

            ' Reconstruyo la Tabla de Amortización y luego inserto un registro por el adelanto a capital

            nPlazoRestante = nPlazo - nLetra + 1

            RegTabla(cAnexo, CDec(txtSaldoEquipo.Text) - CDec(txtAbonoEquipo.Text), nPlazoRestante, "E")

            strInsert = "INSERT INTO Edoctav(Anexo, Letra, Feven, Nufac, IndRec, Saldo, Abcap, Inter, Iva, IvaCapital )"
            strInsert = strInsert & " VALUES ('"
            strInsert = strInsert & cAnexo & "', '"
            strInsert = strInsert & Stuff(CStr(nLetra - 1), "I", "0", 3) & "', '"
            strInsert = strInsert & cFecha & "', '"
            strInsert = strInsert & 9999999 & "', '"
            strInsert = strInsert & "N" & "', '"
            strInsert = strInsert & CDec(txtSaldoEquipo.Text) & "', '"
            strInsert = strInsert & CDec(txtAbonoEquipo.Text) & "', '"
            strInsert = strInsert & 0 & "', '"
            strInsert = strInsert & 0 & "', '"
            strInsert = strInsert & CDec(txtIvaCapital.Text)
            strInsert = strInsert & "')"
            cm1 = New SqlCommand(strInsert, cnAgil)
            cnAgil.Open()
            cm1.ExecuteNonQuery()
            cnAgil.Close()

            ' El siguiente Stored Procedure trae los movimientos de la tabla de amortización del equipo

            With cm3
                .CommandType = CommandType.StoredProcedure
                .CommandText = "TablaEquipo1"
                .Connection = cnAgil
                .Parameters.Add("@Anexo", SqlDbType.NVarChar)
                .Parameters(0).Value = cAnexo
            End With

            ' Llenar el dataset lo cual abre y cierra la conexión

            daEdoctav.Fill(dsAgil, "Edoctav")

            ' Los siguientes movimientos deben ir después de reconstruir la tabla ya que es hasta
            ' este momento que puedo determinar la nueva carga financiera por devengar

            nCargaNue = 0
            For Each drEdoctav In dsAgil.Tables("Edoctav").Rows
                nCargaNue += drEdoctav("Interes")
            Next

            dsAgil.Tables.Remove("Edoctav")

            If nCargaOri - nCargaNue > 0 Then

                drMovimiento = dtMovimientos.NewRow()
                drMovimiento("Anexo") = cAnexo
                drMovimiento("Letra") = "888"
                drMovimiento("Tipos") = "3"
                drMovimiento("Fepag") = cFecha
                Select Case cTipar
                    Case "F"
                        drMovimiento("Cve") = "07"
                    Case "P"
                        drMovimiento("Cve") = "07"
                    Case "R"
                        drMovimiento("Cve") = "46"
                    Case "S"
                        drMovimiento("Cve") = "59"
                End Select
                drMovimiento("Imp") = nCargaOri - nCargaNue
                drMovimiento("Tip") = "S"
                drMovimiento("Catal") = "F"
                drMovimiento("Esp") = 0
                drMovimiento("Coa") = "0"
                drMovimiento("Tipmon") = "01"
                drMovimiento("Banco") = cBanco
                dtMovimientos.Rows.Add(drMovimiento)

                drMovimiento = dtMovimientos.NewRow()
                drMovimiento("Anexo") = cAnexo
                drMovimiento("Letra") = "888"
                drMovimiento("Tipos") = "3"
                drMovimiento("Fepag") = cFecha
                Select Case cTipar
                    Case "F"
                        drMovimiento("Cve") = "06"
                    Case "P"
                        drMovimiento("Cve") = "06"
                    Case "R"
                        drMovimiento("Cve") = "45"
                    Case "S"
                        drMovimiento("Cve") = "55"
                End Select
                drMovimiento("Imp") = nCargaOri - nCargaNue
                drMovimiento("Tip") = "S"
                drMovimiento("Catal") = "F"
                drMovimiento("Esp") = 0
                drMovimiento("Coa") = "1"
                drMovimiento("Tipmon") = "01"
                drMovimiento("Banco") = cBanco
                dtMovimientos.Rows.Add(drMovimiento)

            End If

            If nAbonoEquipo + (nCargaOri - nCargaNue) > 0 Then

                If cTipar = "F" Then

                    drMovimiento = dtMovimientos.NewRow()
                    drMovimiento("Anexo") = cAnexo
                    drMovimiento("Letra") = "888"
                    drMovimiento("Tipos") = "3"
                    drMovimiento("Fepag") = cFecha
                    drMovimiento("Cve") = "84"
                    drMovimiento("Imp") = nAbonoEquipo + (nCargaOri - nCargaNue)
                    drMovimiento("Tip") = "S"
                    drMovimiento("Catal") = "F"
                    drMovimiento("Esp") = 0
                    drMovimiento("Coa") = "0"
                    drMovimiento("Tipmon") = "01"
                    drMovimiento("Banco") = cBanco
                    dtMovimientos.Rows.Add(drMovimiento)

                    drMovimiento = dtMovimientos.NewRow()
                    drMovimiento("Anexo") = cAnexo
                    drMovimiento("Letra") = "888"
                    drMovimiento("Tipos") = "3"
                    drMovimiento("Fepag") = cFecha
                    drMovimiento("Cve") = "83"
                    drMovimiento("Imp") = nAbonoEquipo + (nCargaOri - nCargaNue)
                    drMovimiento("Tip") = "S"
                    drMovimiento("Catal") = "F"
                    drMovimiento("Esp") = 0
                    drMovimiento("Coa") = "1"
                    drMovimiento("Tipmon") = "01"
                    drMovimiento("Banco") = cBanco
                    dtMovimientos.Rows.Add(drMovimiento)

                End If

            End If

        End If

        ' Debe actualizar el atributo IDSerieA ó el atributo IDSerieMXL de la tabla Llaves

        If cSerie = "A" Then
            strUpdate = "UPDATE Llaves SET IDSerieA = " & nFactura
        ElseIf cSerie = "MXL" Then
            strUpdate = "UPDATE Llaves SET IDSerieMXL = " & nFactura
        End If

        cm7 = New SqlCommand(strUpdate, cnAgil)
        cnAgil.Open()
        cm7.ExecuteNonQuery()
        cnAgil.Close()

        ' En este punto llamo a la función Ingresos para afectar la tabla Hisgin

        Ingresos(dtMovimientos)

        ' El siguiente Stored Procedure trae los datos del cliente del cual se está aplicando el adelanto

        With cm6
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DatosClie1"
            .Connection = cnAgil
            .Parameters.Add("@Cliente", SqlDbType.NVarChar)
            .Parameters(0).Value = cCliente
        End With

        daClientes.Fill(dsAgil, "Clientes")

        drCliente = dsAgil.Tables("Clientes").Rows(0)

        cNombre = drCliente("Descr")
        cRfc = drCliente("Rfc")
        cCalle = drCliente("Calle")
        cColonia = drCliente("Colonia")
        cDelegacion = drCliente("Delegacion")
        cEstado = drCliente("DescPlaza")
        cCopos = drCliente("Copos")

        For i = 1 To 5
            Select Case i
                Case 1
                    If RTrim(drCliente("CuentadePago1")) <> "0" And RTrim(drCliente("FormadePago1")) <> "EFECTIVO" Then
                        cCuentaPago = drCliente("CuentadePago1")
                        cFormaPago = RTrim(drCliente("FormadePago1"))
                    ElseIf RTrim(drCliente("CuentadePago1")) = "0" And RTrim(drCliente("FormadePago1")) = "EFECTIVO" Then
                        cCuentaPago = "NO IDENTIFICABLE"
                        cFormaPago = RTrim(drCliente("FormadePago1"))
                    End If
                Case 2
                    If RTrim(drCliente("CuentadePago2")) <> "0" And RTrim(drCliente("FormadePago2")) <> "EFECTIVO" Then
                        cCuentaPago = cCuentaPago & "," & drCliente("CuentadePago2")
                        cFormaPago = cFormaPago & "," & RTrim(drCliente("FormadePago2"))
                    ElseIf RTrim(drCliente("CuentadePago2")) = "0" And RTrim(drCliente("FormadePago2")) = "EFECTIVO" Then
                        cCuentaPago = cCuentaPago & "," & "NO IDENTIFICABLE"
                        cFormaPago = cFormaPago & "," & RTrim(drCliente("FormadePago2"))
                    End If
                Case 3
                    If RTrim(drCliente("CuentadePago3")) <> "0" And RTrim(drCliente("FormadePago3")) <> "EFECTIVO" Then
                        cCuentaPago = cCuentaPago & "," & drCliente("CuentadePago3")
                        cFormaPago = cFormaPago & "," & RTrim(drCliente("FormadePago3"))
                    ElseIf RTrim(drCliente("CuentadePago3")) = "0" And RTrim(drCliente("FormadePago3")) = "EFECTIVO" Then
                        cCuentaPago = cCuentaPago & "," & "NO IDENTIFICABLE"
                        cFormaPago = cFormaPago & "," & RTrim(drCliente("FormadePago3"))
                    End If
                Case 4
                    If RTrim(drCliente("CuentadePago4")) <> "0" And RTrim(drCliente("FormadePago4")) <> "EFECTIVO" Then
                        cCuentaPago = cCuentaPago & "," & drCliente("CuentadePago4")
                        cFormaPago = cFormaPago & "," & RTrim(drCliente("FormadePago4"))
                    ElseIf RTrim(drCliente("CuentadePago4")) = "0" And RTrim(drCliente("FormadePago4")) = "EFECTIVO" Then
                        cCuentaPago = cCuentaPago & "," & "NO IDENTIFICABLE"
                        cFormaPago = cFormaPago & "," & RTrim(drCliente("FormadePago4"))
                    End If
                Case 5
                    If cCuentaPago = "" And cFormaPago = "" Then
                        cCuentaPago = "NO IDENTIFICABLE"
                        cFormaPago = "NO IDENTIFICABLE"
                    End If
            End Select
        Next

        nTotal = Round(nTotal, 2)

        ' Una vez que cerré la conexión y que generé los asientos contables, procedo a generar el archivo de texto para la factura electrónica de pago

        dsAgil.Tables.Remove("Clientes")

        Dim stmFactura As New FileStream("C:\Facturas\FACTURA_" & cSerie & "_" & nFactura & ".txt", FileMode.Create, FileAccess.Write, FileShare.None)
        Dim stmWriter As New StreamWriter(stmFactura, System.Text.Encoding.Default)

        cRenglon = "H3|" & cCliente & "|" & Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 6, 4) & "|" & cSerie & "|" & nFactura & "|" & Trim(cNombre) & "|" & _
        Trim(cCalle) & "|||" & Trim(cColonia) & "|" & Trim(cDelegacion) & "|" & Trim(cEstado) & "|" & cCopos & "|" & cCuentaPago & "|" & cFormaPago & "|MEXICO|" & Trim(cRfc) & "|M.N.|" & _
        "|FACTURA|" & cCliente & "|LEANDRO VALLE 402||REFORMA Y FFCCNN|TOLUCA|ESTADO DE MEXICO|50070|MEXICO"
        cRenglon = cRenglon.Replace("Ñ", Chr(165))
        cRenglon = cRenglon.Replace("ñ", Chr(164))
        cRenglon = cRenglon.Replace("á", Chr(160))
        cRenglon = cRenglon.Replace("é", Chr(130))
        cRenglon = cRenglon.Replace("í", Chr(161))
        cRenglon = cRenglon.Replace("ó", Chr(162))
        cRenglon = cRenglon.Replace("ú", Chr(163))
        cRenglon = cRenglon.Replace("Á", Chr(181))
        cRenglon = cRenglon.Replace("É", Chr(144))
        cRenglon = cRenglon.Replace("Ó", Chr(224))
        cRenglon = cRenglon.Replace("Ú", Chr(233))
        cRenglon = cRenglon.Replace("°", Chr(167))
        stmWriter.WriteLine(cRenglon)

        For Each drPago In dtPagos.Rows
            cRenglon = "D1|" & cCliente & "|" & Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 6, 4) & "|" & cSerie & "|" & nFactura & "|1|||" & Trim(drPago("Concepto")) & "||" & drPago("Importe")
            cRenglon = cRenglon.Replace("Ñ", Chr(165))
            cRenglon = cRenglon.Replace("ñ", Chr(164))
            cRenglon = cRenglon.Replace("á", Chr(160))
            cRenglon = cRenglon.Replace("é", Chr(130))
            cRenglon = cRenglon.Replace("í", Chr(161))
            cRenglon = cRenglon.Replace("ó", Chr(162))
            cRenglon = cRenglon.Replace("ú", Chr(163))
            cRenglon = cRenglon.Replace("Á", Chr(181))
            cRenglon = cRenglon.Replace("É", Chr(144))
            cRenglon = cRenglon.Replace("Ó", Chr(224))
            cRenglon = cRenglon.Replace("Ú", Chr(233))
            cRenglon = cRenglon.Replace("°", Chr(167))
            stmWriter.WriteLine(cRenglon)
        Next

        If nIva = 0 Then
            cRenglon = "S1|" & cCliente & "|" & Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 6, 4) & "|" & cSerie & "|" & nFactura & "|" & nSubTotal & "|" & nIva & "|" & nTotal & "|" & Letras(nTotal.ToString) & "|||0"
        Else
            cRenglon = "S1|" & cCliente & "|" & Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 6, 4) & "|" & cSerie & "|" & nFactura & "|" & nSubTotal & "|" & nIva & "|" & nTotal & "|" & Letras(nTotal.ToString) & "|||16"
        End If
        stmWriter.WriteLine(cRenglon)
        cRenglon = "Z1|" & cCliente & "|" & Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 6, 4) & "|" & cSerie & "|" & nFactura & "|" & cCheque & "|" & Trim(cRfc) & "|"
        stmWriter.WriteLine(cRenglon)

        stmWriter.Flush()
        stmFactura.Flush()
        stmFactura.Close()

        btnCalcular.Enabled = False
        btnAplicar.Enabled = False
        GroupBox1.Enabled = False

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()
        cm3.Dispose()
        cm4.Dispose()
        cm5.Dispose()
        cm6.Dispose()
        cm7.Dispose()

        Me.Close()

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class
