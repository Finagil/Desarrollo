' Esta forma recibe como parámetro el número del contrato para el cual se desea aplicar el finiquito.
' El formato del parámetro es 99999/9999.

Option Explicit On

Imports System.Data.SqlClient
Imports System.Math
Imports CrystalDecisions.Shared
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Text.ASCIIEncoding

Public Class frmFiniquito

    Public Sub New(ByVal cAnexo As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.Text = "Finiquito del Contrato " & cAnexo
        txtAnexo.Text = cAnexo

    End Sub

    ' Declaración de variables de datos de alcance privado

    Dim cSerie As String = ""
    Dim cSucursal As String = ""
    Dim nFactura As Decimal = 0
    Dim nIDSerieA As Decimal = 0
    Dim nIDSerieMXL As Decimal = 0
    Dim nPorcentajeIVA As Decimal = 0       ' Se refiere al porcentaje de IVA al momento de la contratación y se usa para determinar el IVA de la bonificación
    Dim nTasaIvaCliente As Decimal = 0

    ' Declaración de variables de conexión ADO .NET de alcance Privado

    Dim dsAgil As New DataSet()
    Dim dtMovimientos As DataTable
    Dim drMovimiento As DataRow
    Dim dtTemporal As DataTable
    Dim drTemporal As DataRow

    ' Declaración de variables de datos de alcance Privado

    Dim cAdeudo As String = ""
    Dim cAnexo As String = ""
    Dim cBanco As String = ""
    Dim cCalle As String = ""
    Dim cCheque As String = ""
    Dim cCliente As String = ""
    Dim cColonia As String = ""
    Dim cCopos As String = ""
    Dim cTipo As String = ""
    Dim cDelegacion As String = ""
    Dim cDescr As String = ""
    Dim cEstado As String = ""
    Dim cFechaAplicacion As String = ""
    Dim cFechacon As String = ""
    Dim cFepag As String = ""
    Dim cFinse As String = ""
    Dim cFlcan As String = ""
    Dim cFondeo As String = ""
    Dim cIndpag As String = ""
    Dim cLetra As String = ""
    Dim cRfc As String = ""
    Dim cTipar As String = ""
    Dim cTipta As String = ""
    Dim cCuentaPago As String = ""
    Dim cFormaPago As String = ""
    Dim dFechaFinal As Date
    Dim dFechaInicial As Date
    Dim lContinuar As Boolean = True
    Dim lSalir As Boolean
    Dim nAdeudoRentas As Decimal = 0
    Dim nAmorin As Decimal = 0
    Dim nAplicacionNota As Decimal = 0
    Dim nCargaFinancieraEquipo As Decimal = 0
    Dim nCargaFinancieraOtros As Decimal = 0
    Dim nComision As Decimal = 0
    Dim nDG As Byte = 0
    Dim nDiasFact As Integer = 0
    Dim nDifer As Decimal = 0
    Dim nImpDG As Decimal = 0
    Dim nImpEq As Decimal = 0
    Dim nImportePago As Decimal = 0
    Dim nImpRD As Decimal = 0
    Dim nInteres As Decimal = 0
    Dim nInteresEquipo As Decimal = 0   ' Intereses financieros
    Dim nInteresOtros As Decimal = 0    ' Intereses financieros
    Dim nInteresSeguro As Decimal = 0   ' Intereses financieros
    Dim nIvaCapital As Decimal = 0
    Dim nIvaComision As Decimal = 0
    Dim nIvaDG As Decimal = 0
    Dim nIvaEq As Decimal = 0
    Dim nIvaFactura As Decimal = 0
    Dim nIvaInteres As Decimal = 0
    Dim nIvaNota As Decimal = 0
    Dim nIvaOpcion As Decimal = 0
    Dim nIvaRD As Decimal = 0
    Dim nNota As Decimal = 0
    Dim nOpcion As Decimal = 0
    Dim nPagoTotal As Decimal = 0
    Dim nPlazo As Integer = 0
    Dim nPorieq As Decimal = 0
    Dim nRD As Byte = 0
    Dim nSaldoBonifica As Decimal = 0
    Dim nSaldoEquipo As Decimal = 0
    Dim nSaldofac As Decimal = 0
    Dim nSaldoOtros As Decimal = 0
    Dim nSaldoSeguro As Decimal = 0
    Dim nSubTotalFactura As Decimal = 0
    Dim nSubTotalNota As Decimal = 0
    Dim nTasaFact As Decimal = 0
    Dim nTasaPen As Decimal = 0
    Dim nTasas As Decimal = 0
    Dim nTotalFactura As Decimal = 0
    Dim nTotalNota As Decimal = 0
    Dim nUdiFinal As Decimal = 0
    Dim nUdiInicial As Decimal = 0

    Private Sub frmFiniquito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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
        Dim cm9 As New SqlCommand()
        Dim cm10 As New SqlCommand()
        Dim daAnexos As New SqlDataAdapter(cm1)
        Dim daEdoctav As New SqlDataAdapter(cm2)
        Dim daEdoctas As New SqlDataAdapter(cm3)
        Dim daEdoctao As New SqlDataAdapter(cm4)
        Dim daFacturas As New SqlDataAdapter(cm5)
        Dim daHista As New SqlDataAdapter(cm6)
        Dim daUdis As New SqlDataAdapter(cm7)
        Dim daBancos As New SqlDataAdapter(cm8)
        Dim daClientes As New SqlDataAdapter(cm9)
        Dim daSeries As New SqlDataAdapter(cm10)
        Dim drAnexo As DataRow
        Dim drCliente As DataRow
        Dim drFactura As DataRow
        Dim drSerie As DataRow

        Dim i As Integer

        cAnexo = Mid(txtAnexo.Text, 1, 5) & Mid(txtAnexo.Text, 7, 4)

        ' El siguiente Stored Procedure trae todos los atributos de la tabla Anexos para un anexo dado

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

        ' Este Command regresa todas las facturas generadas para el contrato dado

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

        ' Este Stored Procedure regresa los datos de los Bancos

        With cm8
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Bancos1"
            .Connection = cnAgil
        End With

        lContinuar = True

        ' Comenzar a llenar el DataSet lo cual abre y cierra la conexión.   Este paso es necesario realizarlo
        ' aquí para poder obtener el número de cliente y utilizarlo para ejecutar el Stored Procedure que trae
        ' los datos del cliente.

        daAnexos.Fill(dsAgil, "Anexos")

        If dsAgil.Tables("Anexos").Rows.Count = 0 Then

            ' Validando que el Contrato exista

            lContinuar = False
            MsgBox("Anexo inexistente", MsgBoxStyle.Critical, "Mensaje del Sistema")

        Else

            drAnexo = dsAgil.Tables("Anexos").Rows(0)

            cCliente = drAnexo("Cliente")
            cFlcan = drAnexo("Flcan")
            cTipar = drAnexo("Tipar")
            cFondeo = drAnexo("Fondeo")
            cFechacon = drAnexo("Fechacon")
            nPlazo = drAnexo("Plazo")
            cTipta = drAnexo("Tipta")
            nDifer = drAnexo("Difer")
            cFinse = drAnexo("Finse")
            cAdeudo = drAnexo("Adeudo")
            nImpEq = drAnexo("ImpEq")
            nIvaEq = drAnexo("Ivaeq")
            nAmorin = drAnexo("Amorin")
            nTasas = drAnexo("Tasas")
            nTasaFact = drAnexo("Tasas")
            nTasaPen = drAnexo("Taspen")
            nPorieq = drAnexo("Porieq") / 100
            nRD = drAnexo("RD")                     ' No. de Rentas en Depósito
            nImpRD = drAnexo("ImpDG")               ' Importe de las Rentas en Depósito
            nIvaRD = drAnexo("IvaDG")               ' Importe del IVA de las Rentas en Depósito
            nDG = drAnexo("DG")
            nImpDG = drAnexo("ImpRD")               ' Importe del Depósito en Garantía
            nIvaDG = drAnexo("IvaRD")               ' Importe del IVA del Depósito en Garantía
            nOpcion = drAnexo("Opcion")
            nIvaOpcion = drAnexo("IvaOpcion")

            ' El siguiente Stored Procedure trae todos los datos del cliente del cual se está aplicando el finiquito

            With cm9
                .CommandType = CommandType.StoredProcedure
                .CommandText = "DatosClie1"
                .Connection = cnAgil
                .Parameters.Add("@Cliente", SqlDbType.NVarChar)
                .Parameters(0).Value = cCliente
            End With

            daClientes.Fill(dsAgil, "Clientes")

            If dsAgil.Tables("Clientes").Rows.Count = 0 Then

                ' Validando que el Cliente exista

                lContinuar = False
                MsgBox("Cliente inexistente", MsgBoxStyle.Critical, "Mensaje del Sistema")

            Else

                drCliente = dsAgil.Tables("Clientes").Rows(0)

                cDescr = drCliente("Descr")
                cRfc = drCliente("Rfc")
                cTipo = drCliente("Tipo")
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

                ' Traigo la Sucursal y la Tasa de IVA que aplica al cliente a efecto de poder determinar la Serie a utilizar

                cSucursal = drCliente("Sucursal")
                nTasaIvaCliente = drCliente("TasaIVACliente")

                If cSucursal = "04" Or nTasaIvaCliente = 11 Then
                    cSerie = "MXL"
                Else
                    cSerie = "A"
                End If

            End If

        End If

        If lContinuar = True Then

            ' El siguiente Command trae los consecutivos de cada Serie

            With cm10
                .CommandType = CommandType.Text
                .CommandText = "SELECT IDSerieA, IDSerieMXL FROM Llaves"
                .Connection = cnAgil
            End With

            daEdoctav.Fill(dsAgil, "Edoctav")
            daEdoctas.Fill(dsAgil, "Edoctas")
            daEdoctao.Fill(dsAgil, "Edoctao")
            daFacturas.Fill(dsAgil, "Facturas")
            daHista.Fill(dsAgil, "Hista")
            daUdis.Fill(dsAgil, "Udis")
            daBancos.Fill(dsAgil, "Bancos")
            daSeries.Fill(dsAgil, "Series")

            ' Lleno cbBancos con el nombre de los Bancos

            cbBancos.DataSource = dsAgil
            cbBancos.DisplayMember = "Bancos.DescBanco"
            cbBancos.ValueMember = "Bancos.Banco"
            cbBancos.SelectedIndex = 0

            cFechaAplicacion = Now().ToShortDateString
            ToolStripStatusLabel1.Text = "Fecha de Aplicación " & cFechaAplicacion
            cFechaAplicacion = Mid(cFechaAplicacion, 7, 4) & Mid(cFechaAplicacion, 4, 2) & Mid(cFechaAplicacion, 1, 2)

            ' Toma el número consecutivo de facturas de pago -que depende de la Serie- y lo incrementa en uno

            drSerie = dsAgil.Tables("Series").Rows(0)
            nIDSerieA = drSerie("IDSerieA")
            nIDSerieMXL = drSerie("IDSerieMXL")

            If cSerie = "A" Then
                nIDSerieA = nIDSerieA + 1
                txtSerieA.Text = nIDSerieA.ToString
                lblIDSerieA.Visible = True
                txtSerieA.Visible = True
            ElseIf cSerie = "MXL" Then
                nIDSerieMXL = nIDSerieMXL + 1
                txtSerieMXL.Text = nIDSerieMXL.ToString
                lblIDSerieMXL.Visible = True
                txtSerieMXL.Visible = True
            End If

        End If

        If lContinuar = True Then

            If cTipar = "P" Then
                lContinuar = False
                MsgBox("No existen finiquitos para Arrendamiento Puro", MsgBoxStyle.Critical, "Mensaje del Sistema")
            ElseIf cFondeo = "02" Then
                lContinuar = False
                MsgBox("No existen finiquitos en contratos descontados con NAFIN", MsgBoxStyle.Critical, "Mensaje del Sistema")
            ElseIf cFondeo = "03" Then
                lContinuar = False
                MsgBox("No existen finiquitos en contratos descontados con FIRA", MsgBoxStyle.Critical, "Mensaje del Sistema")
            ElseIf cFondeo = "04" Then
                lContinuar = False
                MsgBox("No existen finiquitos en contratos PARAFINANCIEROS", MsgBoxStyle.Critical, "Mensaje del Sistema")
            ElseIf cFlcan <> "A" Then
                lContinuar = False
                MsgBox("No se puede finiquitar un contrato que no está activo", MsgBoxStyle.Critical, "Mensaje del Sistema")
            ElseIf dsAgil.Tables("Edoctav").Rows.Count = 0 Then

                ' Validando que el Contrato esté en cartera 

                lContinuar = False
                MsgBox("No existe la tabla de amortización de este contrato", MsgBoxStyle.Critical, "Mensaje del Sistema")

            Else

                ' Se debe checar el saldo de Facturas de Renta

                nAdeudoRentas = 0

                For Each drFactura In dsAgil.Tables("Facturas").Rows
                    cIndpag = drFactura("IndPag")
                    nSaldofac = 0
                    If cIndpag <> "P" Then
                        nSaldofac = drFactura("SaldoFac")
                        nAdeudoRentas = nAdeudoRentas + nSaldofac
                    End If
                Next

                If nAdeudoRentas > 0 Then
                    lContinuar = False
                    MsgBox("El contrato tiene adeudo de rentas por lo que no se puede finiquitar", MsgBoxStyle.Critical, "Mensaje del Sistema")
                End If

            End If

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
        cm9.Dispose()
        cm10.Dispose()

        If lContinuar = False Then
            Me.Close()
        End If

    End Sub

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim drEdoctav As DataRow
        Dim drEdoctas As DataRow
        Dim drEdoctao As DataRow

        txtImportePago.Enabled = False
        txtCheque.Enabled = False
        cbBancos.Enabled = False
        dtpFechaPago.Enabled = False
        btnProcesar.Enabled = False

        cBanco = cbBancos.SelectedValue.ToString()
        cFepag = DTOC(dtpFechaPago.Value)

        ' Este Command trae el número de la última nota de crédito impresa

        With cm1
            .CommandType = CommandType.Text
            .CommandText = "SELECT ConNot FROM Llaves"
            .Connection = cnAgil
        End With

        ' Toma el número consecutivo de facturas de pago y de notas de crédito y los incrementa en uno

        cnAgil.Open()
        nNota = CInt(cm1.ExecuteScalar()) + 1
        cnAgil.Close()

        txtNota.Text = nNota.ToString

        ' El número de nota de crédito solamente se habilita si existen conceptos de bonificación
        ' tales como rentas en depósito o depósito en garantía

        If nImpRD > 0 Or nImpDG > 0 Then
            txtNota.Enabled = True
        Else
            txtNota.Enabled = False
        End If

        ' Si existe seguro financiado se debe tomar el saldo insoluto del seguro que no haya sido facturado

        If cFinse = "S" Then

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

            lSalir = False

            For Each drEdoctao In dsAgil.Tables("Edoctao").Rows

                ' Se busca el saldo insoluto de otros adeudos que no haya sido facturado;
                ' también puedo aprovechar para calcular la carga financiera por devengar de otros adeudos

                If drEdoctao("Nufac") = 0 And drEdoctao("Indrec") = "S" Then
                    nCargaFinancieraOtros += drEdoctao("Inter")
                    If lSalir = False Then
                        nSaldoOtros = drEdoctao("Saldo")
                        lSalir = True
                    End If
                End If

            Next

        End If

        ' Trae el saldo insoluto del equipo y (si procede) el IVA diferido del Capital;
        ' también puedo aprovechar para calcular la carga financiera por devengar del equipo

        lSalir = False

        For Each drEdoctav In dsAgil.Tables("Edoctav").Rows
            If drEdoctav("Nufac") = 0 Then
                If drEdoctav("IvaCapital") > 0 Then
                    nIvaCapital = Round(nIvaCapital + (drEdoctav("Abcap") * nTasaIvaCliente / 100), 2)
                End If
                nCargaFinancieraEquipo += drEdoctav("Interes")
                If lSalir = False Then
                    cLetra = drEdoctav("Letra")
                    nSaldoEquipo = drEdoctav("Saldo")
                    CalcInte(dsAgil.Tables("Facturas").Rows, dsAgil.Tables("Hista").Rows, nTasaFact, nDiasFact, nInteresEquipo, cFepag, cAnexo, cFechacon, cLetra, nSaldoEquipo, cTipta, nDifer)
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

        GroupBox1.Text = "Cliente : " & cDescr
        GroupBox1.Visible = True

        If nDG = 0 And nImpDG > 0 Then

            ' Existe Depósito en Garantía de Arrendamiento Financiero el cual se fue bonificando
            ' mensualmente por lo que debe determinarse el saldo restante

            nSaldoBonifica = Round(nSaldoEquipo * ((nImpDG + nIvaDG) / (nImpEq - nIvaEq - nAmorin)), 2)

            ' También tengo que determinar la proporción original del IVA del Depósito respecto al Depósito en Garantía

            nPorcentajeIVA = Round((nImpDG + nIvaDG) / (nImpEq - nIvaEq - nAmorin), 2)

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
        nIvaInteres = 0
        dFechaInicial = DateAdd(DateInterval.Day, -nDiasFact, CTOD(cFepag)).ToShortDateString
        dFechaFinal = CTOD(cFepag)

        If cTipar = "F" Then

            ' En Arrendamiento Financiero siempre existe IVA de los intereses;

            nIvaInteres = CalcIvaU(dsAgil.Tables("Udis").Rows, nSaldoEquipo, nTasaFact, DTOC(dFechaInicial), DTOC(dFechaFinal), nUdiInicial, nUdiFinal, nTasaIvaCliente / 100)

            If nDiasFact > 0 And (nUdiInicial = 0 Or nUdiFinal = 0) Then
                MsgBox("Error en los valores de las UDIS", MsgBoxStyle.Exclamation, "Mensaje")
                Me.Close()
            End If

            ' El IVA del interés del Seguro y el IVA del interés de Otros Adeudos -aún en arrendamiento financiero- solamente existen si se trata de un cliente persona física sin actividad empresarial

            If cTipo = "F" Then
                nIvaInteres = Round(nIvaInteres + (nInteresSeguro * nTasaIvaCliente / 100), 2)
                nIvaInteres = Round(nIvaInteres + (nInteresOtros * nTasaIvaCliente / 100), 2)
            End If

        Else

            ' En Crédito Refaccionario y en Crédito Simple solo existe IVA de los intereses cuando se trate de un cliente persona física sin actividad empresarial

            If cTipo = "F" Then
                nIvaInteres = Round(nInteres * nTasaIvaCliente / 100, 2)
            End If

        End If

        nComision = Round((nSaldoEquipo + nSaldoSeguro + nSaldoOtros) * nTasaPen / 100, 2)
        nIvaComision = Round(nComision * nTasaIvaCliente / 100, 2)

        nPagoTotal = Round(nSaldoEquipo + nSaldoSeguro + nSaldoOtros + nIvaCapital - nImpDG - nIvaDG - nImpRD - nIvaRD + nInteres + nIvaInteres + nComision + nIvaComision + nOpcion + nIvaOpcion, 2)

        txtSaldoEquipo.Text = FormatNumber(nSaldoEquipo, 2)
        txtSaldoSeguro.Text = FormatNumber(nSaldoSeguro, 2)
        txtSaldoOtros.Text = FormatNumber(nSaldoOtros, 2)
        txtIvaCapital.Text = FormatNumber(nIvaCapital, 2)
        txtIntereses.Text = FormatNumber(nInteres, 2)
        txtIvaIntereses.Text = FormatNumber(nIvaInteres, 2)
        txtComision.Text = FormatNumber(nComision, 2)
        txtIvaComision.Text = FormatNumber(nIvaComision, 2)
        txtUdiInicial.Text = FormatNumber(nUdiInicial, 6)
        txtUdiFinal.Text = FormatNumber(nUdiFinal, 6)
        txtImpDG.Text = FormatNumber(nImpDG, 2)
        txtIvaDG.Text = FormatNumber(nIvaDG, 2)
        txtImpRD.Text = FormatNumber(nImpRD, 2)
        txtIvaRD.Text = FormatNumber(nIvaRD, 2)
        txtTasaAplicada.Text = FormatNumber(nTasaFact, 4)
        txtPenalizacion.Text = FormatNumber(nTasaPen, 2)
        txtDiasIntereses.Text = FormatNumber(nDiasFact, 0)
        txtOpcion.Text = FormatNumber(nOpcion, 2)
        txtIvaOpcion.Text = FormatNumber(nIvaOpcion, 2)
        txtPagoTotal.Text = FormatNumber(nPagoTotal, 2)

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub btnRecalcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecalcular.Click

        ' Declaración de variables de datos

        Dim cCatal As String
        Dim nDiasIntereses As Decimal = 0
        Dim nOC As Decimal = 0
        Dim nPenalizacion As Decimal = 0

        ' Los únicos datos que se pueden actualizar son la tasa de penalización, los días de intereses
        ' y la opción de compra

        nImportePago = CDbl(txtImportePago.Text)
        nPenalizacion = CDbl(txtPenalizacion.Text)
        nDiasIntereses = CDbl(txtDiasIntereses.Text)
        nOC = CDbl(txtOpcion.Text)

        ' Se recalcula el IVA de la Opción de Compra

        nIvaOpcion = Round(nOC * nTasaIvaCliente / 100, 2)

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
        dtMovimientos.Clear()

        ' Luego creo la tabla Temporal

        dtTemporal = New DataTable("Temporal")
        dtTemporal.Columns.Add("Anexo", Type.GetType("System.String"))
        dtTemporal.Columns.Add("Fecha", Type.GetType("System.String"))
        dtTemporal.Columns.Add("Concepto", Type.GetType("System.String"))
        dtTemporal.Columns.Add("Importe", Type.GetType("System.Decimal"))
        dtTemporal.Columns.Add("Banco", Type.GetType("System.String"))
        dtTemporal.Clear()

        ' Se recalcula la Comisión y el IVA de la Comisión

        nComision = Round((nSaldoEquipo + nSaldoSeguro + nSaldoOtros) * nPenalizacion / 100, 2)
        nIvaComision = Round(nComision * nTasaIvaCliente / 100, 2)

        txtComision.Text = FormatNumber(nComision, 2)
        txtIvaComision.Text = FormatNumber(nIvaComision, 2)

        ' El valor de nTasaFact debe ser regresado al valor de nTasas porque en el procedimiento CalcInte
        ' le añade el diferencial

        nTasaFact = nTasas

        nUdiInicial = 0
        nUdiFinal = 0
        nInteres = txtIntereses.Text
        nIvaInteres = txtIvaIntereses.Text

        ' Se recalculan los intereses así como el IVA de los intereses

        If nDiasIntereses > 0 Then

            nInteresEquipo = 0
            nInteresSeguro = 0
            nInteresOtros = 0
            CalcInte(dsAgil.Tables("Facturas").Rows, dsAgil.Tables("Hista").Rows, nTasaFact, nDiasFact, nInteresEquipo, cFepag, cAnexo, cFechacon, cLetra, nSaldoEquipo, cTipta, nDifer)

            ' Al regresar de la función CalcInte, en nInteresEquipo tenemos el interés COMPLETO del equipo
            ' por lo que debemos obtener la proporción que le corresponde a nDiasIntereses

            nInteresEquipo = Round(nDiasIntereses * nInteresEquipo / nDiasFact, 2)

            dFechaInicial = DateAdd(DateInterval.Day, -nDiasFact, CTOD(cFepag))
            dFechaFinal = DateAdd(DateInterval.Day, nDiasIntereses, dFechaInicial)

            If cTipar = "F" Or (cTipar = "R" And cTipo = "F") Or (cTipar = "S" And cTipo = "F") Then

                nIvaInteres = CalcIvaU(dsAgil.Tables("Udis").Rows, nSaldoEquipo + nSaldoSeguro, nTasaFact, DTOC(dFechaInicial), DTOC(dFechaFinal), nUdiInicial, nUdiFinal, nTasaIvaCliente / 100)
                If nDiasFact > 0 And (nUdiInicial = 0 Or nUdiFinal = 0) Then
                    MsgBox("Error en los valores de las UDIS", MsgBoxStyle.Exclamation, "Mensaje")
                    Me.Close()
                End If

            End If

            ' Si se trata de un cliente persona física sin actividad empresarial, es a este tipo de persona
            ' a la única que aplica el IVA de Otros Adeudos recordando que a partir de julio 2008 a este saldo
            ' se le da tratamiento como si fuera un crédito simple

            If cTipo = "F" Then
                nIvaInteres = Round(nIvaInteres + (nInteresOtros * nTasaIvaCliente / 100), 2)
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

        ' Inicializo subtotal, iva y total tanto para la factura de pago como para la nota de crédito

        nSubTotalFactura = 0
        nIvaFactura = 0
        nTotalFactura = 0

        nSubTotalNota = 0
        nIvaNota = 0
        nTotalNota = 0

        ' No debo contemplar el importe de la opción de compra y de su IVA ya que estos dos conceptos, aunque se pagan aquí, no forman parte de la factura de pago
        ' porque se imprimen en la factura de activo fijo

        If cTipar = "F" Then

            ' Si se tratara de un arrendamiento financiero, el saldo del depósito en garantía debería 
            ' aplicarse al capital del equipo y el iva del depósito en garantía debería aplicarse
            ' al iva del capital

            nSubTotalFactura = Round(nSaldoEquipo - nImpDG - nImpRD - nIvaRD + nSaldoSeguro + nSaldoOtros + nInteres + nComision, 2)
            nIvaFactura = Round(nIvaCapital - nIvaDG + nIvaInteres + nIvaComision, 2)
            nTotalFactura = Round(nSubTotalFactura + nIvaFactura, 2)

            nSubTotalNota = Round(nImpDG + nImpRD, 2)
            nIvaNota = Round(nIvaDG + nIvaRD, 2)
            nTotalNota = Round(nSubTotalNota + nIvaNota, 2)

        ElseIf cTipar = "R" Then

            ' Si se tratara de un Crédito Refaccionario, el saldo del depósito en garantía más su iva debería aplicarse íntegramente al capital del equipo ya que no existe iva del capital

            nSubTotalFactura = Round(nSaldoEquipo - nImpDG - nIvaDG - nImpRD - nIvaRD + nSaldoSeguro + nSaldoOtros + nInteres + nComision, 2)
            nIvaFactura = Round(nIvaCapital + nIvaInteres + nIvaComision, 2)
            nTotalFactura = Round(nSubTotalFactura + nIvaFactura, 2)

            nSubTotalNota = Round(nImpDG + nImpRD, 2)
            nIvaNota = Round(nIvaDG + nIvaRD, 2)
            nTotalNota = Round(nSubTotalNota + nIvaNota, 2)

            ' Recordar que para los Créditos Simples no existe el concepto de Depósito en Garantía ni de Rentas en Depósito

        End If

        nPagoTotal = Round(nSaldoEquipo + nSaldoSeguro + nSaldoOtros + nIvaCapital - nImpDG - nIvaDG - nImpRD - nIvaRD + nInteres + nIvaInteres + nComision + nIvaComision + nOpcion + nIvaOpcion, 2)

        txtUdiInicial.Text = FormatNumber(nUdiInicial, 6)
        txtUdiFinal.Text = FormatNumber(nUdiFinal, 6)
        txtIntereses.Text = FormatNumber(nInteres, 2)
        txtIvaIntereses.Text = FormatNumber(nIvaInteres, 2)
        txtIvaOpcion.Text = FormatNumber(nIvaOpcion, 2)
        txtComision.Text = FormatNumber(nComision, 2)
        txtIvaComision.Text = FormatNumber(nIvaComision, 2)
        txtPagoTotal.Text = FormatNumber(nPagoTotal, 2)

        cCatal = "F"

        ' Es importante recordar que el cargo a Bancos se hace en forma automática en el módulo Ingresos

        If nSaldoEquipo > 0 Then

            drMovimiento = dtMovimientos.NewRow()
            drMovimiento("Anexo") = cAnexo
            drMovimiento("Letra") = "999"
            drMovimiento("Tipos") = "3"
            drMovimiento("Fepag") = cFechaAplicacion
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
            drMovimiento("Imp") = nSaldoEquipo
            drMovimiento("Tip") = "S"
            drMovimiento("Catal") = cCatal
            drMovimiento("Esp") = 0
            drMovimiento("Coa") = "1"
            drMovimiento("Tipmon") = "01"
            drMovimiento("Banco") = cBanco
            dtMovimientos.Rows.Add(drMovimiento)

            If cTipar = "F" Then

                ' Recordar que solo existe reconocimiento del COSTO y del INGRESO para resultados,
                ' cuando se trate de arrendamiento financiero

                drMovimiento = dtMovimientos.NewRow()
                drMovimiento("Anexo") = cAnexo
                drMovimiento("Letra") = "999"
                drMovimiento("Tipos") = "3"
                drMovimiento("Fepag") = cFechaAplicacion
                drMovimiento("Cve") = "29"
                drMovimiento("Imp") = nSaldoEquipo
                drMovimiento("Tip") = "S"
                drMovimiento("Catal") = cCatal
                drMovimiento("Esp") = 0
                drMovimiento("Coa") = "0"
                drMovimiento("Tipmon") = "01"
                drMovimiento("Banco") = cBanco
                dtMovimientos.Rows.Add(drMovimiento)

                drMovimiento = dtMovimientos.NewRow()
                drMovimiento("Anexo") = cAnexo
                drMovimiento("Letra") = "999"
                drMovimiento("Tipos") = "3"
                drMovimiento("Fepag") = cFechaAplicacion
                drMovimiento("Cve") = "13"
                drMovimiento("Imp") = nSaldoEquipo
                drMovimiento("Tip") = "S"
                drMovimiento("Catal") = cCatal
                drMovimiento("Esp") = 0
                drMovimiento("Coa") = "1"
                drMovimiento("Tipmon") = "01"
                drMovimiento("Banco") = cBanco
                dtMovimientos.Rows.Add(drMovimiento)

                drMovimiento = dtMovimientos.NewRow()
                drMovimiento("Anexo") = cAnexo
                drMovimiento("Letra") = "999"
                drMovimiento("Tipos") = "3"
                drMovimiento("Fepag") = cFechaAplicacion
                drMovimiento("Cve") = "86"
                drMovimiento("Imp") = nSaldoEquipo
                drMovimiento("Tip") = "S"
                drMovimiento("Catal") = cCatal
                drMovimiento("Esp") = 0
                drMovimiento("Coa") = "0"
                drMovimiento("Tipmon") = "01"
                drMovimiento("Banco") = cBanco
                dtMovimientos.Rows.Add(drMovimiento)

                drMovimiento = dtMovimientos.NewRow()
                drMovimiento("Anexo") = cAnexo
                drMovimiento("Letra") = "999"
                drMovimiento("Tipos") = "3"
                drMovimiento("Fepag") = cFechaAplicacion
                drMovimiento("Cve") = "85"
                drMovimiento("Imp") = nSaldoEquipo
                drMovimiento("Tip") = "S"
                drMovimiento("Catal") = cCatal
                drMovimiento("Esp") = 0
                drMovimiento("Coa") = "1"
                drMovimiento("Tipmon") = "01"
                drMovimiento("Banco") = cBanco
                dtMovimientos.Rows.Add(drMovimiento)

            End If

            drMovimiento = dtMovimientos.NewRow()
            drMovimiento("Anexo") = cAnexo
            drMovimiento("Letra") = "999"
            drMovimiento("Tipos") = "3"
            drMovimiento("Fepag") = cFechaAplicacion
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
            drMovimiento("Imp") = nCargaFinancieraEquipo
            drMovimiento("Tip") = "S"
            drMovimiento("Catal") = "F"
            drMovimiento("Esp") = 0
            drMovimiento("Coa") = "0"
            drMovimiento("Tipmon") = "01"
            drMovimiento("Banco") = cBanco
            dtMovimientos.Rows.Add(drMovimiento)

            drMovimiento = dtMovimientos.NewRow()
            drMovimiento("Anexo") = cAnexo
            drMovimiento("Letra") = "999"
            drMovimiento("Tipos") = "3"
            drMovimiento("Fepag") = cFechaAplicacion
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
            drMovimiento("Imp") = nCargaFinancieraEquipo
            drMovimiento("Tip") = "S"
            drMovimiento("Catal") = "F"
            drMovimiento("Esp") = 0
            drMovimiento("Coa") = "1"
            drMovimiento("Tipmon") = "01"
            drMovimiento("Banco") = cBanco
            dtMovimientos.Rows.Add(drMovimiento)

            drTemporal = dtTemporal.NewRow()
            drTemporal("Anexo") = cAnexo
            drTemporal("Fecha") = cFechaAplicacion
            drTemporal("Concepto") = "SALDO INSOLUTO DEL EQUIPO"
            drTemporal("Importe") = nSaldoEquipo
            drTemporal("Banco") = cBanco
            dtTemporal.Rows.Add(drTemporal)

        End If

        If nSaldoSeguro > 0 Then

            drMovimiento = dtMovimientos.NewRow()
            drMovimiento("Anexo") = cAnexo
            drMovimiento("Letra") = "999"
            drMovimiento("Tipos") = "3"
            drMovimiento("Fepag") = cFechaAplicacion
            drMovimiento("Cve") = "28"
            drMovimiento("Imp") = nSaldoSeguro
            drMovimiento("Tip") = "S"
            drMovimiento("Catal") = cCatal
            drMovimiento("Esp") = 0
            drMovimiento("Coa") = "1"
            drMovimiento("Tipmon") = "01"
            drMovimiento("Banco") = cBanco
            dtMovimientos.Rows.Add(drMovimiento)

            drTemporal = dtTemporal.NewRow()
            drTemporal("Anexo") = cAnexo
            drTemporal("Fecha") = cFechaAplicacion
            drTemporal("Concepto") = "SALDO INSOLUTO DEL SEGURO"
            drTemporal("Importe") = nSaldoSeguro
            drTemporal("Banco") = cBanco
            dtTemporal.Rows.Add(drTemporal)

        End If

        If nSaldoOtros > 0 Then

            drMovimiento = dtMovimientos.NewRow()
            drMovimiento("Anexo") = cAnexo
            drMovimiento("Letra") = "999"
            drMovimiento("Tipos") = "3"
            drMovimiento("Fepag") = cFechaAplicacion
            drMovimiento("Cve") = "55"
            drMovimiento("Imp") = nSaldoOtros
            drMovimiento("Tip") = "S"
            drMovimiento("Catal") = cCatal
            drMovimiento("Esp") = 0
            drMovimiento("Coa") = "1"
            drMovimiento("Tipmon") = "01"
            drMovimiento("Banco") = cBanco
            dtMovimientos.Rows.Add(drMovimiento)

            drMovimiento = dtMovimientos.NewRow()
            drMovimiento("Anexo") = cAnexo
            drMovimiento("Letra") = "999"
            drMovimiento("Tipos") = "3"
            drMovimiento("Fepag") = cFechaAplicacion
            drMovimiento("Cve") = "59"
            drMovimiento("Imp") = nCargaFinancieraOtros
            drMovimiento("Tip") = "S"
            drMovimiento("Catal") = "F"
            drMovimiento("Esp") = 0
            drMovimiento("Coa") = "0"
            drMovimiento("Tipmon") = "01"
            drMovimiento("Banco") = cBanco
            dtMovimientos.Rows.Add(drMovimiento)

            drMovimiento = dtMovimientos.NewRow()
            drMovimiento("Anexo") = cAnexo
            drMovimiento("Letra") = "999"
            drMovimiento("Tipos") = "3"
            drMovimiento("Fepag") = cFechaAplicacion
            drMovimiento("Cve") = "55"
            drMovimiento("Imp") = nCargaFinancieraOtros
            drMovimiento("Tip") = "S"
            drMovimiento("Catal") = "F"
            drMovimiento("Esp") = 0
            drMovimiento("Coa") = "1"
            drMovimiento("Tipmon") = "01"
            drMovimiento("Banco") = cBanco
            dtMovimientos.Rows.Add(drMovimiento)

            drTemporal = dtTemporal.NewRow()
            drTemporal("Anexo") = cAnexo
            drTemporal("Fecha") = cFechaAplicacion
            drTemporal("Concepto") = "SALDO INSOLUTO OTROS ADEUDOS"
            drTemporal("Importe") = nSaldoOtros
            drTemporal("Banco") = cBanco
            dtTemporal.Rows.Add(drTemporal)

        End If

        If nIvaCapital > 0 Then

            drMovimiento = dtMovimientos.NewRow()
            drMovimiento("Anexo") = cAnexo
            drMovimiento("Letra") = "999"
            drMovimiento("Tipos") = "3"
            drMovimiento("Fepag") = cFechaAplicacion
            drMovimiento("Cve") = "08"
            drMovimiento("Imp") = nIvaCapital
            drMovimiento("Tip") = "S"
            drMovimiento("Catal") = cCatal
            drMovimiento("Esp") = 0
            drMovimiento("Coa") = "1"
            drMovimiento("Tipmon") = "01"
            drMovimiento("Banco") = cBanco
            dtMovimientos.Rows.Add(drMovimiento)

            drMovimiento = dtMovimientos.NewRow()
            drMovimiento("Anexo") = cAnexo
            drMovimiento("Letra") = "999"
            drMovimiento("Tipos") = "3"
            drMovimiento("Fepag") = cFechaAplicacion
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
            drMovimiento("Letra") = "999"
            drMovimiento("Tipos") = "3"
            drMovimiento("Fepag") = cFechaAplicacion
            drMovimiento("Cve") = "87"
            drMovimiento("Imp") = nIvaCapital
            drMovimiento("Tip") = "S"
            drMovimiento("Catal") = cCatal
            drMovimiento("Esp") = 0
            drMovimiento("Coa") = "1"
            drMovimiento("Tipmon") = "01"
            drMovimiento("Banco") = cBanco
            dtMovimientos.Rows.Add(drMovimiento)

            drTemporal = dtTemporal.NewRow()
            drTemporal("Anexo") = cAnexo
            drTemporal("Fecha") = cFechaAplicacion
            drTemporal("Concepto") = "IVA DEL SALDO INSOLUTO"
            drTemporal("Importe") = nIvaCapital
            drTemporal("Banco") = cBanco
            dtTemporal.Rows.Add(drTemporal)

        End If

        If nImpRD > 0 Then

            drMovimiento = dtMovimientos.NewRow()
            drMovimiento("Anexo") = cAnexo
            drMovimiento("Letra") = "999"
            drMovimiento("Tipos") = "3"
            drMovimiento("Fepag") = cFechaAplicacion
            drMovimiento("Cve") = "11"
            drMovimiento("Imp") = nImpRD
            drMovimiento("Tip") = "S"
            drMovimiento("Catal") = cCatal
            drMovimiento("Esp") = 0
            drMovimiento("Coa") = "0"
            drMovimiento("Tipmon") = "01"
            drMovimiento("Banco") = cBanco
            dtMovimientos.Rows.Add(drMovimiento)

            drTemporal = dtTemporal.NewRow()
            drTemporal("Anexo") = cAnexo
            drTemporal("Fecha") = cFechaAplicacion
            drTemporal("Concepto") = "APLICACION RENTAS EN DEPOSITO"
            drTemporal("Importe") = -nImpRD
            drTemporal("Banco") = cBanco
            dtTemporal.Rows.Add(drTemporal)

        End If

        If nIvaRD > 0 Then

            drMovimiento = dtMovimientos.NewRow()
            drMovimiento("Anexo") = cAnexo
            drMovimiento("Letra") = "999"
            drMovimiento("Tipos") = "3"
            drMovimiento("Fepag") = cFechaAplicacion
            drMovimiento("Cve") = "30"
            drMovimiento("Imp") = nIvaRD
            drMovimiento("Tip") = "S"
            drMovimiento("Catal") = cCatal
            drMovimiento("Esp") = 0
            drMovimiento("Coa") = "0"
            drMovimiento("Tipmon") = "01"
            drMovimiento("Banco") = cBanco
            dtMovimientos.Rows.Add(drMovimiento)

            drTemporal = dtTemporal.NewRow()
            drTemporal("Anexo") = cAnexo
            drTemporal("Fecha") = cFechaAplicacion
            drTemporal("Concepto") = "APLICACION IVA RENTAS EN DEPOSITO"
            drTemporal("Importe") = -nIvaRD
            drTemporal("Banco") = cBanco
            dtTemporal.Rows.Add(drTemporal)

        End If

        If nImpDG > 0 Then

            drMovimiento = dtMovimientos.NewRow()
            drMovimiento("Anexo") = cAnexo
            drMovimiento("Letra") = "999"
            drMovimiento("Tipos") = "3"
            drMovimiento("Fepag") = cFechaAplicacion
            If nDG = 0 Then
                drMovimiento("Cve") = "05"      ' Depósito en garantía de arrendamiento financiero
            ElseIf nDG > 0 Then
                drMovimiento("Cve") = "47"      ' Depósito en garantía de créditos refaccionarios
            End If
            drMovimiento("Imp") = nImpDG
            drMovimiento("Tip") = "S"
            drMovimiento("Catal") = cCatal
            drMovimiento("Esp") = 0
            drMovimiento("Coa") = "0"
            drMovimiento("Tipmon") = "01"
            drMovimiento("Banco") = cBanco
            dtMovimientos.Rows.Add(drMovimiento)

            drTemporal = dtTemporal.NewRow()
            drTemporal("Anexo") = cAnexo
            drTemporal("Fecha") = cFechaAplicacion
            drTemporal("Concepto") = "APLICACION DEPOSITO EN GARANTIA"
            drTemporal("Importe") = -nImpDG
            drTemporal("Banco") = cBanco
            dtTemporal.Rows.Add(drTemporal)

        End If

        ' IVA del depósito en garantía de arrendamiento financiero ó IVA del depósito en garantía de créditos refaccionarios

        If nIvaDG > 0 Then

            drMovimiento = dtMovimientos.NewRow()
            drMovimiento("Anexo") = cAnexo
            drMovimiento("Letra") = "999"
            drMovimiento("Tipos") = "3"
            drMovimiento("Fepag") = cFechaAplicacion
            drMovimiento("Cve") = "20"
            drMovimiento("Imp") = nIvaDG
            drMovimiento("Tip") = "S"
            drMovimiento("Catal") = cCatal
            drMovimiento("Esp") = 0
            drMovimiento("Coa") = "0"
            drMovimiento("Tipmon") = "01"
            drMovimiento("Banco") = cBanco
            dtMovimientos.Rows.Add(drMovimiento)

            drTemporal = dtTemporal.NewRow()
            drTemporal("Anexo") = cAnexo
            drTemporal("Fecha") = cFechaAplicacion
            drTemporal("Concepto") = "APLICACION IVA DEPOSITO EN GARANTIA"
            drTemporal("Importe") = -nIvaDG
            drTemporal("Banco") = cBanco
            dtTemporal.Rows.Add(drTemporal)

        End If

        If nInteres > 0 Then

            drMovimiento = dtMovimientos.NewRow()
            drMovimiento("Anexo") = cAnexo
            drMovimiento("Letra") = "999"
            drMovimiento("Tipos") = "3"
            drMovimiento("Fepag") = cFechaAplicacion
            drMovimiento("Cve") = "16"
            drMovimiento("Imp") = nInteres
            drMovimiento("Tip") = "S"
            drMovimiento("Catal") = cCatal
            drMovimiento("Esp") = 0
            drMovimiento("Coa") = "1"
            drMovimiento("Tipmon") = "01"
            drMovimiento("Banco") = cBanco
            dtMovimientos.Rows.Add(drMovimiento)

            drTemporal = dtTemporal.NewRow()
            drTemporal("Anexo") = cAnexo
            drTemporal("Fecha") = cFechaAplicacion
            drTemporal("Concepto") = "INTERESES POR PREPAGO"
            drTemporal("Importe") = nInteres
            drTemporal("Banco") = cBanco
            dtTemporal.Rows.Add(drTemporal)

        End If

        If nIvaInteres > 0 Then

            drMovimiento = dtMovimientos.NewRow()
            drMovimiento("Anexo") = cAnexo
            drMovimiento("Letra") = "999"
            drMovimiento("Tipos") = "3"
            drMovimiento("Fepag") = cFechaAplicacion
            drMovimiento("Cve") = "33"
            drMovimiento("Imp") = nIvaInteres
            drMovimiento("Tip") = "S"
            drMovimiento("Catal") = cCatal
            drMovimiento("Esp") = 0
            drMovimiento("Coa") = "1"
            drMovimiento("Tipmon") = "01"
            drMovimiento("Banco") = cBanco
            dtMovimientos.Rows.Add(drMovimiento)

            drTemporal = dtTemporal.NewRow()
            drTemporal("Anexo") = cAnexo
            drTemporal("Fecha") = cFechaAplicacion
            drTemporal("Concepto") = "IVA DE INTERESES POR PREPAGO"
            drTemporal("Importe") = nIvaInteres
            drTemporal("Banco") = cBanco
            dtTemporal.Rows.Add(drTemporal)

        End If

        If nComision > 0 Then

            drMovimiento = dtMovimientos.NewRow()
            drMovimiento("Anexo") = cAnexo
            drMovimiento("Letra") = "999"
            drMovimiento("Tipos") = "3"
            drMovimiento("Fepag") = cFechaAplicacion
            drMovimiento("Cve") = "24"
            drMovimiento("Imp") = nComision
            drMovimiento("Tip") = "S"
            drMovimiento("Catal") = cCatal
            drMovimiento("Esp") = 0
            drMovimiento("Coa") = "1"
            drMovimiento("Tipmon") = "01"
            drMovimiento("Banco") = cBanco
            dtMovimientos.Rows.Add(drMovimiento)

            drTemporal = dtTemporal.NewRow()
            drTemporal("Anexo") = cAnexo
            drTemporal("Fecha") = cFechaAplicacion
            drTemporal("Concepto") = "COMISION POR PREPAGO"
            drTemporal("Importe") = nComision
            drTemporal("Banco") = cBanco
            dtTemporal.Rows.Add(drTemporal)

        End If

        If nIvaComision > 0 Then

            drMovimiento = dtMovimientos.NewRow()
            drMovimiento("Anexo") = cAnexo
            drMovimiento("Letra") = "999"
            drMovimiento("Tipos") = "3"
            drMovimiento("Fepag") = cFechaAplicacion
            drMovimiento("Cve") = "32"
            drMovimiento("Imp") = nIvaComision
            drMovimiento("Tip") = "S"
            drMovimiento("Catal") = cCatal
            drMovimiento("Esp") = 0
            drMovimiento("Coa") = "1"
            drMovimiento("Tipmon") = "01"
            drMovimiento("Banco") = cBanco
            dtMovimientos.Rows.Add(drMovimiento)

            drTemporal = dtTemporal.NewRow()
            drTemporal("Anexo") = cAnexo
            drTemporal("Fecha") = cFechaAplicacion
            drTemporal("Concepto") = "IVA DE COMISION POR PREPAGO"
            drTemporal("Importe") = nIvaComision
            drTemporal("Banco") = cBanco
            dtTemporal.Rows.Add(drTemporal)

        End If

        If nOpcion > 0 Then

            drMovimiento = dtMovimientos.NewRow()
            drMovimiento("Anexo") = cAnexo
            drMovimiento("Letra") = "999"
            drMovimiento("Tipos") = "3"
            drMovimiento("Fepag") = cFechaAplicacion
            drMovimiento("Cve") = "10"
            drMovimiento("Imp") = nOpcion
            drMovimiento("Tip") = "S"
            drMovimiento("Catal") = cCatal
            drMovimiento("Esp") = 0
            drMovimiento("Coa") = "1"
            drMovimiento("Tipmon") = "01"
            drMovimiento("Banco") = cBanco
            dtMovimientos.Rows.Add(drMovimiento)

            drMovimiento = dtMovimientos.NewRow()
            drMovimiento("Anexo") = cAnexo
            drMovimiento("Letra") = "999"
            drMovimiento("Tipos") = "3"
            drMovimiento("Fepag") = cFechaAplicacion
            drMovimiento("Cve") = "82"
            drMovimiento("Imp") = nOpcion
            drMovimiento("Tip") = "S"
            drMovimiento("Catal") = cCatal
            drMovimiento("Esp") = 0
            drMovimiento("Coa") = "0"
            drMovimiento("Tipmon") = "01"
            drMovimiento("Banco") = cBanco
            dtMovimientos.Rows.Add(drMovimiento)

            drMovimiento = dtMovimientos.NewRow()
            drMovimiento("Anexo") = cAnexo
            drMovimiento("Letra") = "999"
            drMovimiento("Tipos") = "3"
            drMovimiento("Fepag") = cFechaAplicacion
            drMovimiento("Cve") = "81"
            drMovimiento("Imp") = nOpcion
            drMovimiento("Tip") = "S"
            drMovimiento("Catal") = cCatal
            drMovimiento("Esp") = 0
            drMovimiento("Coa") = "1"
            drMovimiento("Tipmon") = "01"
            drMovimiento("Banco") = cBanco
            dtMovimientos.Rows.Add(drMovimiento)

            drTemporal = dtTemporal.NewRow()
            drTemporal("Anexo") = cAnexo
            drTemporal("Fecha") = cFechaAplicacion
            drTemporal("Concepto") = "OPCION DE COMPRA"
            drTemporal("Importe") = nOpcion
            drTemporal("Banco") = cBanco
            dtTemporal.Rows.Add(drTemporal)

        End If

        If nIvaOpcion > 0 Then

            drMovimiento = dtMovimientos.NewRow()
            drMovimiento("Anexo") = cAnexo
            drMovimiento("Letra") = "999"
            drMovimiento("Tipos") = "3"
            drMovimiento("Fepag") = cFechaAplicacion
            drMovimiento("Cve") = "18"
            drMovimiento("Imp") = nIvaOpcion
            drMovimiento("Tip") = "S"
            drMovimiento("Catal") = cCatal
            drMovimiento("Esp") = 0
            drMovimiento("Coa") = "1"
            drMovimiento("Tipmon") = "01"
            drMovimiento("Banco") = cBanco
            dtMovimientos.Rows.Add(drMovimiento)

            drTemporal = dtTemporal.NewRow()
            drTemporal("Anexo") = cAnexo
            drTemporal("Fecha") = cFechaAplicacion
            drTemporal("Concepto") = "IVA OPCION DE COMPRA"
            drTemporal("Importe") = nIvaOpcion
            drTemporal("Banco") = cBanco
            dtTemporal.Rows.Add(drTemporal)

        End If

        If cTipar = "F" And nSaldoEquipo + nCargaFinancieraEquipo > 0 Then

            drMovimiento = dtMovimientos.NewRow()
            drMovimiento("Anexo") = cAnexo
            drMovimiento("Letra") = "999"
            drMovimiento("Tipos") = "3"
            drMovimiento("Fepag") = cFechaAplicacion
            drMovimiento("Cve") = "84"
            drMovimiento("Imp") = nSaldoEquipo + nCargaFinancieraEquipo
            drMovimiento("Tip") = "S"
            drMovimiento("Catal") = "F"
            drMovimiento("Esp") = 0
            drMovimiento("Coa") = "0"
            drMovimiento("Tipmon") = "01"
            drMovimiento("Banco") = cBanco
            dtMovimientos.Rows.Add(drMovimiento)

            drMovimiento = dtMovimientos.NewRow()
            drMovimiento("Anexo") = cAnexo
            drMovimiento("Letra") = "999"
            drMovimiento("Tipos") = "3"
            drMovimiento("Fepag") = cFechaAplicacion
            drMovimiento("Cve") = "83"
            drMovimiento("Imp") = nSaldoEquipo + nCargaFinancieraEquipo
            drMovimiento("Tip") = "S"
            drMovimiento("Catal") = "F"
            drMovimiento("Esp") = 0
            drMovimiento("Coa") = "1"
            drMovimiento("Tipmon") = "01"
            drMovimiento("Banco") = cBanco
            dtMovimientos.Rows.Add(drMovimiento)

        End If

        If Round(nImportePago, 2) < Round(nPagoTotal, 2) Then

            MsgBox("El pago no alcanza a cubrir el finiquito", MsgBoxStyle.Critical, "Mensaje de Error")

        Else

            btnAplicar.Enabled = True

        End If

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
        Dim dsImprimir As New DataSet()
        Dim dtPagos As New DataTable("Pagos")
        Dim dtNota As New DataTable("Nota")
        Dim drPago As DataRow
        Dim strUpdate As String
        Dim strInsert As String

        ' Declaración de variables de datos

        Dim cObserva As String
        Dim cRenglon As String
        Dim cRenglon2 As String
        Dim nImporte As Decimal
        Dim nImpresion As Byte = 1
        Dim numero As Integer
        Dim lCrea As Boolean
        Dim oFactura As StreamWriter
        Dim oCredito As StreamWriter

        ' Aquí creo la tabla dtPagos que servirá como base para la impresión de la factura de pago

        dtPagos.Columns.Add("Recibo", Type.GetType("System.String"))
        dtPagos.Columns.Add("Fecha", Type.GetType("System.String"))
        dtPagos.Columns.Add("Nombre", Type.GetType("System.String"))
        dtPagos.Columns.Add("Rfc", Type.GetType("System.String"))
        dtPagos.Columns.Add("Anexo", Type.GetType("System.String"))
        dtPagos.Columns.Add("Calle", Type.GetType("System.String"))
        dtPagos.Columns.Add("Colonia", Type.GetType("System.String"))
        dtPagos.Columns.Add("Delegacion", Type.GetType("System.String"))
        dtPagos.Columns.Add("Estado", Type.GetType("System.String"))
        dtPagos.Columns.Add("Copos", Type.GetType("System.String"))
        dtPagos.Columns.Add("Concepto", Type.GetType("System.String"))
        dtPagos.Columns.Add("Importe", Type.GetType("System.Decimal"))
        dtPagos.Columns.Add("FormaPago", Type.GetType("System.String"))
        dtPagos.Columns.Add("SubTotal", Type.GetType("System.Decimal"))
        dtPagos.Columns.Add("Iva", Type.GetType("System.Decimal"))
        dtPagos.Columns.Add("Total", Type.GetType("System.Decimal"))
        dtPagos.Columns.Add("ImporteLetra", Type.GetType("System.String"))
        dtPagos.Columns.Add("Leyenda", Type.GetType("System.String"))
        dtPagos.Columns.Add("Numero", Type.GetType("System.String"))
        dtPagos.Clear()

        ' Aquí creo la tabla dtNota que servirá como base para la impresión de la nota de crédito

        dtNota.Columns.Add("Nota", Type.GetType("System.String"))
        dtNota.Columns.Add("Fecha", Type.GetType("System.String"))
        dtNota.Columns.Add("Nombre", Type.GetType("System.String"))
        dtNota.Columns.Add("Rfc", Type.GetType("System.String"))
        dtNota.Columns.Add("Anexo", Type.GetType("System.String"))
        dtNota.Columns.Add("Calle", Type.GetType("System.String"))
        dtNota.Columns.Add("Colonia", Type.GetType("System.String"))
        dtNota.Columns.Add("Delegacion", Type.GetType("System.String"))
        dtNota.Columns.Add("Estado", Type.GetType("System.String"))
        dtNota.Columns.Add("Copos", Type.GetType("System.String"))
        dtNota.Columns.Add("Concepto", Type.GetType("System.String"))
        dtNota.Columns.Add("Importe", Type.GetType("System.Decimal"))
        dtNota.Columns.Add("FormaPago", Type.GetType("System.String"))
        dtNota.Columns.Add("SubTotal", Type.GetType("System.Decimal"))
        dtNota.Columns.Add("Iva", Type.GetType("System.Decimal"))
        dtNota.Columns.Add("Total", Type.GetType("System.Decimal"))
        dtNota.Columns.Add("ImporteLetra", Type.GetType("System.String"))
        dtNota.Columns.Add("Leyenda", Type.GetType("System.String"))
        dtNota.Columns.Add("Numero", Type.GetType("System.String"))
        dtNota.Clear()

        cCheque = txtCheque.Text
        If cSerie = "A" Then
            nIDSerieA = CInt(txtSerieA.Text)
            nFactura = nIDSerieA
        ElseIf cSerie = "MXL" Then
            nIDSerieMXL = CInt(txtSerieMXL.Text)
            nFactura = nIDSerieMXL
        End If

        nNota = CDec(txtNota.Text)

        ' Afectación de la Historia de Pagos

        cnAgil.Open()
        For Each drTemporal In dtTemporal.Rows()
            cObserva = drTemporal("Concepto")
            nImporte = drTemporal("Importe")
            If nImporte <> 0 Then
                If cObserva = "OPCION DE COMPRA" Or cObserva = "IVA OPCION DE COMPRA" Then
                    strInsert = "INSERT INTO Historia(Documento, Serie, Numero, Fecha, Anexo, Letra, Banco, Cheque, Balance, Importe, Observa1)"
                    strInsert = strInsert & " VALUES ('"
                    strInsert = strInsert & "7" & "', '"
                    strInsert = strInsert & "B" & "', "
                    strInsert = strInsert & 999999 & ", '"
                    strInsert = strInsert & cFechaAplicacion & "', '"
                    strInsert = strInsert & cAnexo & "', '"
                    strInsert = strInsert & "999" & "', '"
                    strInsert = strInsert & cBanco & "', '"
                    strInsert = strInsert & cCheque & "', '"
                    strInsert = strInsert & "N" & "', "
                    strInsert = strInsert & nImporte & ", '"
                    strInsert = strInsert & cObserva
                    strInsert = strInsert & "')"
                Else
                    If nImporte > 0 Then
                        strInsert = "INSERT INTO Historia(Documento, Serie, Numero, Fecha, Anexo, Letra, Banco, Cheque, Balance, Importe, Observa1)"
                        strInsert = strInsert & " VALUES ('"
                        strInsert = strInsert & "6" & "', '"
                        strInsert = strInsert & cSerie & "', "
                        strInsert = strInsert & nFactura & ", '"
                        strInsert = strInsert & cFechaAplicacion & "', '"
                        strInsert = strInsert & cAnexo & "', '"
                        strInsert = strInsert & "999" & "', '"
                        strInsert = strInsert & cBanco & "', '"
                        strInsert = strInsert & cCheque & "', '"
                        strInsert = strInsert & "N" & "', "
                        strInsert = strInsert & nImporte & ", '"
                        strInsert = strInsert & cObserva
                        strInsert = strInsert & "')"
                    Else
                        strInsert = "INSERT INTO Historia(Documento, Serie, Numero, Fecha, Anexo, Letra, Banco, Cheque, Balance, Importe, Observa1)"
                        strInsert = strInsert & " VALUES ('"
                        strInsert = strInsert & "5" & "', '"
                        strInsert = strInsert & "C" & "', "
                        strInsert = strInsert & nNota & ", '"
                        strInsert = strInsert & cFechaAplicacion & "', '"
                        strInsert = strInsert & cAnexo & "', '"
                        strInsert = strInsert & "999" & "', '"
                        strInsert = strInsert & cBanco & "', '"
                        strInsert = strInsert & cCheque & "', '"
                        strInsert = strInsert & "N" & "', "
                        strInsert = strInsert & nImporte & ", '"
                        strInsert = strInsert & cObserva
                        strInsert = strInsert & "')"
                    End If
                End If
                cm1 = New SqlCommand(strInsert, cnAgil)
                cm1.ExecuteNonQuery()
            End If
        Next
        cnAgil.Close()

        ' Afectación de la tabla del Seguro

        If CDec(txtSaldoSeguro.Text) > 0 Then

            ' El pago cubre completamente el saldo del seguro, por lo que debe cancelar
            ' los vencimientos no facturados

            strUpdate = "UPDATE Edoctas SET Nufac = 9999999, IndRec = 'N', Inter = 0, Iva = 0 WHERE Nufac = 0 AND Anexo = '" & cAnexo & "'"
            cm2 = New SqlCommand(strUpdate, cnAgil)
            cnAgil.Open()
            cm2.ExecuteNonQuery()
            cnAgil.Close()

        End If

        ' Afectación de la tabla de Otros Adeudos

        If CDec(txtSaldoOtros.Text) > 0 Then

            ' El pago cubre completamente el saldo de Otros Adeudos, por lo que debe cancelar
            ' los vencimientos no facturados

            strUpdate = "UPDATE Edoctao SET Nufac = 9999999, IndRec = 'N', Inter = 0, Iva = 0 WHERE Nufac = 0 AND Anexo = '" & cAnexo & "'"
            cm3 = New SqlCommand(strUpdate, cnAgil)
            cnAgil.Open()
            cm3.ExecuteNonQuery()
            cnAgil.Close()

        End If

        ' Afectación de la tabla del Equipo

        If CDec(txtSaldoEquipo.Text) > 0 Then

            ' El pago cubre completamente el saldo del equipo, por lo que debe cancelar
            ' los vencimientos no facturados

            strUpdate = "UPDATE Edoctav SET Nufac = 9999999, IndRec = 'N', Inter = 0, Iva = 0 WHERE Nufac = 0 AND Anexo = '" & cAnexo & "'"
            cm4 = New SqlCommand(strUpdate, cnAgil)
            cnAgil.Open()
            cm4.ExecuteNonQuery()
            cnAgil.Close()

        End If

        ' Actualización de la tabla Anexos

        strUpdate = "UPDATE Anexos SET Flcan = 'C', FechaFin = '" & cFechaAplicacion & "' WHERE Anexo = '" & cAnexo & "'"
        cm5 = New SqlCommand(strUpdate, cnAgil)
        cnAgil.Open()
        cm5.ExecuteNonQuery()
        cnAgil.Close()

        ' Actualización de la tabla Opciones

        strUpdate = "UPDATE Opciones SET Pagado = 'S' WHERE Anexo = '" & cAnexo & "'"
        cm6 = New SqlCommand(strUpdate, cnAgil)
        cnAgil.Open()
        cm6.ExecuteNonQuery()
        cnAgil.Close()

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

        ' Si existió nota de crédito debo actualizar el atributo ConNot de la tabla Llaves

        If nTotalNota > 0 Then

            strUpdate = "UPDATE Llaves SET ConNot = " & nNota
            cm7 = New SqlCommand(strUpdate, cnAgil)
            cnAgil.Open()
            cm7.ExecuteNonQuery()
            cnAgil.Close()

        End If

        ' En este punto llamo a la función Ingresos para afectar la tabla Hisgin

        Ingresos(dtMovimientos)

        ' Aquí tengo que recorrer la tabla dtTemporal buscando determinar cuáles conceptos se cancelan con
        ' los posibles importes a favor que tenga el cliente tales como depósito en garantía, IVA del depósito
        ' en garantía, rentas en depósito e IVA de rentas en depósito (el cual tengo guardado en nTotalNota)

        nAplicacionNota = nTotalNota
        If nTotalNota > 0 Then
            For Each drTemporal In dtTemporal.Rows()
                If drTemporal("Concepto") <> "OPCION DE COMPRA" And drTemporal("Concepto") <> "IVA OPCION DE COMPRA" Then
                    nImporte = drTemporal("Importe")
                    If nImporte > 0 Then
                        If nAplicacionNota >= nImporte Then

                            ' La bonificación cubre el importe total del concepto

                            drTemporal("Importe") = 0
                            nAplicacionNota -= nImporte

                        Else

                            ' La bonificación cubre parcialmente el importe del concepto

                            If nAplicacionNota > 0 Then
                                drTemporal("Importe") = Round(nImporte - nAplicacionNota, 2)
                                nAplicacionNota = 0
                            End If

                        End If
                    End If
                End If
            Next
        End If

        For Each drTemporal In dtTemporal.Rows()
            If drTemporal("Concepto") <> "OPCION DE COMPRA" And drTemporal("Concepto") <> "IVA OPCION DE COMPRA" Then
                nImporte = drTemporal("Importe")
                If nImporte > 0 Then
                    drPago = dtPagos.NewRow()
                    drPago("Recibo") = nFactura
                    drPago("Fecha") = "TOLUCA, ESTADO DE MEXICO A " & Mes(cFechaAplicacion)
                    drPago("Nombre") = cDescr
                    drPago("Rfc") = cRfc
                    drPago("Anexo") = drTemporal("Anexo")
                    drPago("Calle") = cCalle
                    drPago("Colonia") = cColonia
                    drPago("Delegacion") = cDelegacion
                    drPago("Estado") = cEstado
                    drPago("Copos") = cCopos
                    drPago("Concepto") = drTemporal("Concepto")
                    drPago("Importe") = nImporte
                    drPago("FormaPago") = cCheque
                    drPago("SubTotal") = nSubTotalFactura
                    drPago("Iva") = nIvaFactura
                    drPago("Total") = nTotalFactura
                    drPago("ImporteLetra") = Letras(nTotalFactura.ToString)
                    drPago("Leyenda") = ""
                    drPago("Numero") = nImpresion
                    dtPagos.Rows.Add(drPago)
                Else
                    drPago = dtNota.NewRow()
                    drPago("Nota") = nNota
                    drPago("Fecha") = Mes(cFechaAplicacion)
                    drPago("Nombre") = cDescr
                    drPago("Rfc") = cRfc
                    drPago("Anexo") = drTemporal("Anexo")
                    drPago("Calle") = cCalle
                    drPago("Colonia") = cColonia
                    drPago("Delegacion") = cDelegacion
                    drPago("Estado") = cEstado
                    drPago("Copos") = cCopos
                    drPago("Concepto") = drTemporal("Concepto")
                    drPago("Importe") = Abs(nImporte)
                    drPago("FormaPago") = cCheque
                    drPago("SubTotal") = nSubTotalNota
                    drPago("Iva") = nIvaNota
                    drPago("Total") = nTotalNota
                    drPago("ImporteLetra") = Letras(nTotalNota.ToString)
                    drPago("Leyenda") = ""
                    drPago("Numero") = nImpresion
                    dtNota.Rows.Add(drPago)
                End If
            End If
        Next

        ' Una vez que cerré la conexión y que generé los asientos contables, imprimo la factura de pago

        dsImprimir.Tables.Add(dtPagos)
        dsImprimir.Tables.Add(dtNota)

        Dim stmFactura As New FileStream("C:\Facturas\FACTURA_" & cSerie & "_" & nFactura & ".txt", FileMode.Create, FileAccess.Write, FileShare.None)
        Dim stmWriter As New StreamWriter(stmFactura, System.Text.Encoding.Default)

        cRenglon = "H3|" & cCliente & "|" & Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 6, 4) & "|" & cSerie & "|" & nFactura & "|" & Trim(cDescr) & "|" & _
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

        If nIvaFactura = 0 Then
            cRenglon = "S1|" & cCliente & "|" & Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 6, 4) & "|" & cSerie & "|" & nFactura & "|" & nSubTotalFactura & "|" & nIvaFactura & "|" & nTotalFactura & "|" & Letras(nTotalFactura.ToString) & "|||0"
        Else
            cRenglon = "S1|" & cCliente & "|" & Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 6, 4) & "|" & cSerie & "|" & nFactura & "|" & nSubTotalFactura & "|" & nIvaFactura & "|" & nTotalFactura & "|" & Letras(nTotalFactura.ToString) & "|||16"
        End If

        stmWriter.WriteLine(cRenglon)
        cRenglon = "Z1|" & cCliente & "|" & Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 6, 4) & "|" & cSerie & "|" & nFactura & "|" & cCheque & "|" & Trim(cRfc) & "|"
        stmWriter.WriteLine(cRenglon)

        stmWriter.Flush()
        stmFactura.Flush()
        stmFactura.Close()

        If nTotalNota > 0 Then

            Dim stmNota As New FileStream("C:\Facturas\CREDITO_C_" & nNota & ".txt", FileMode.Create, FileAccess.Write, FileShare.None)
            Dim stmWriter2 As New StreamWriter(stmNota, System.Text.Encoding.Default)

            ' Imprime la Nota de Crédito

            cRenglon2 = "H3|" & cCliente & "|" & Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 6, 4) & "|C|" & nNota & "|" & Trim(cDescr) & "|" & _
                Trim(cCalle) & "|||" & Trim(cColonia) & "|" & Trim(cDelegacion) & "|" & Trim(cEstado) & "|" & cCopos & "|" & cCuentaPago & "|" & cFormaPago & "|MEXICO|" & Trim(cRfc) & "|M.N.|" & _
                "|NOTA DE CREDITO|" & cCliente & "|LEANDRO VALLE 402||REFORMA Y FFCCNN|TOLUCA|ESTADO DE MEXICO|50070|MEXICO"

            cRenglon2 = cRenglon2.Replace("Ñ", Chr(165))
            cRenglon2 = cRenglon2.Replace("ñ", Chr(164))
            cRenglon2 = cRenglon2.Replace("á", Chr(160))
            cRenglon2 = cRenglon2.Replace("é", Chr(130))
            cRenglon2 = cRenglon2.Replace("í", Chr(161))
            cRenglon2 = cRenglon2.Replace("ó", Chr(162))
            cRenglon2 = cRenglon2.Replace("ú", Chr(163))
            cRenglon2 = cRenglon2.Replace("Á", Chr(181))
            cRenglon2 = cRenglon2.Replace("É", Chr(144))
            cRenglon2 = cRenglon2.Replace("Ó", Chr(224))
            cRenglon2 = cRenglon2.Replace("Ú", Chr(233))
            cRenglon2 = cRenglon2.Replace("°", Chr(167))
            stmWriter2.WriteLine(cRenglon2)

            For Each drPago In dtNota.Rows

                cRenglon2 = "D1|" & cCliente & "|" & Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 6, 4) & "|C|" & nNota & "|1|||" & Trim(drPago("Concepto")) & "||" & drPago("Importe")
                cRenglon2 = cRenglon2.Replace("Ñ", Chr(165))
                cRenglon2 = cRenglon2.Replace("ñ", Chr(164))
                cRenglon2 = cRenglon2.Replace("á", Chr(160))
                cRenglon2 = cRenglon2.Replace("é", Chr(130))
                cRenglon2 = cRenglon2.Replace("í", Chr(161))
                cRenglon2 = cRenglon2.Replace("ó", Chr(162))
                cRenglon2 = cRenglon2.Replace("ú", Chr(163))
                cRenglon2 = cRenglon2.Replace("Á", Chr(181))
                cRenglon2 = cRenglon2.Replace("É", Chr(144))
                cRenglon2 = cRenglon2.Replace("Ó", Chr(224))
                cRenglon2 = cRenglon2.Replace("Ú", Chr(233))
                cRenglon2 = cRenglon2.Replace("°", Chr(167))
                stmWriter2.WriteLine(cRenglon2)

            Next

            If nIvaNota = 0 Then
                cRenglon2 = "S1|" & cCliente & "|" & Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 6, 4) & "|C|" & nNota & "|" & nSubTotalNota & "|" & nIvaNota & "|" & nTotalNota & "|" & Letras(nTotalNota.ToString) & "|||0"
            Else
                cRenglon2 = "S1|" & cCliente & "|" & Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 6, 4) & "|C|" & nNota & "|" & nSubTotalNota & "|" & nIvaNota & "|" & nTotalNota & "|" & Letras(nTotalNota.ToString) & "|||16"
            End If
            stmWriter2.WriteLine(cRenglon)
            cRenglon2 = "Z1|" & cCliente & "|" & Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 6, 4) & "|C|" & nNota & "|" & cCheque & "|" & Trim(cRfc) & "|"
            stmWriter2.WriteLine(cRenglon2)

            stmWriter2.Flush()
            stmNota.Flush()
            stmNota.Close()

        End If

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