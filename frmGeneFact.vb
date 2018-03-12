Option Explicit On

Imports System.Math
Imports System.Data.SqlClient

Public Class frmGeneFact

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
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnProcesar = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.SuspendLayout()
        '
        'btnProcesar
        '
        Me.btnProcesar.Location = New System.Drawing.Point(224, 136)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(80, 24)
        Me.btnProcesar.TabIndex = 17
        Me.btnProcesar.Text = "Procesar"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(112, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 16)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Fecha de Proceso:"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(256, 56)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(88, 20)
        Me.DateTimePicker1.TabIndex = 15
        '
        'frmGeneFact
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(504, 206)
        Me.Controls.Add(Me.btnProcesar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Name = "frmGeneFact"
        Me.Text = "Generación de Avisos de Vencimiento"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Structure Factura

        Public Anexo As String
        Public Bonifica As Decimal
        Public CapitalO As Decimal
        Public Cliente As String
        Public Dias As Integer
        Public Difer As Decimal
        Public Enviado As String
        Public Fepag As String
        Public Feven As String
        Public ImporteFac As Decimal
        Public ImporteFega As Decimal
        Public IndPag As String
        Public InteresO As Decimal
        Public IntPr As Decimal
        Public IntSe As Decimal
        Public IvaCapital As Decimal
        Public IvaO As Decimal
        Public IvaOpcion As Decimal
        Public IvaPr As Decimal
        Public IvaSe As Decimal
        Public Letra As String
        Public Opcion As Decimal
        Public Plazo As Decimal
        Public RenPr As Decimal
        Public RenSe As Decimal
        Public Saldo As Decimal
        Public SaldoFac As Decimal
        Public SalOt As Decimal
        Public SalSe As Decimal
        Public SeguroVida As Decimal
        Public Tasa As Decimal
        Public TasaIVA As Decimal
        Public Tipmon As String
        Public Udi1 As Decimal
        Public Udi2 As Decimal
        Public VarO As Decimal
        Public VarPr As Decimal
        Public VarSe As Decimal

    End Structure

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click

        ' Declaración de variables de datos

        Dim cFeven As String = ""
        Dim cAcumulaIntereses As String = "NO"
        Dim cAdeudo As String = ""
        Dim cAnexo As String = ""
        Dim cCliente As String = ""
        Dim cFechacon As String = ""
        Dim cFechaDocumento As String = ""
        Dim cFechaFinal As String = ""
        Dim cFechaInicial As String = ""
        Dim cFecha_Pago As String = ""
        Dim cFinse As String = ""
        Dim cForca As String = ""
        Dim cLetra As String = ""
        Dim cSegVida As String = ""
        Dim cFondeo As String = ""
        Dim cTipta As String = ""
        Dim cTipar As String = ""
        Dim cTipo As String = ""
        Dim cTipoFrecuencia As String = ""
        Dim dAnterior As Date
        Dim dFechaInicial As Date
        Dim dFeven As Date
        Dim lProcesar As Boolean = True
        Dim nAbonoEquipo As Decimal = 0
        Dim nAbonoSeguro As Decimal = 0
        Dim nBonifica As Decimal = 0
        Dim nCapOtros As Decimal = 0
        Dim nCuotaMaximaMensual As Decimal = 3350
        Dim nDG As Byte = 0
        Dim nDiasFact As Integer = 0
        Dim nDiasFactOriginal As Integer = 0
        Dim nDifer As Decimal = 0
        Dim nFactura As Decimal = 0
        Dim nImpDG As Decimal = 0
        Dim nImporteFac As Decimal = 0
        Dim nImporteMaximoAsegurado As Decimal = 5000000
        Dim nIntEquipo As Decimal = 0
        Dim nIntOtros As Decimal = 0
        Dim nIntRealEq As Decimal = 0
        Dim nIntRealOt As Decimal = 0
        Dim nIntRealSe As Decimal = 0
        Dim nIntSeguro As Decimal = 0
        Dim nIntRealFega As Decimal = 0
        Dim nIvaCapital As Decimal = 0
        Dim nIvaInteresEquipo As Decimal = 0
        Dim nIvaInteresOtros As Decimal = 0
        Dim nIvaInteresSeguro As Decimal = 0
        Dim nLetra As Integer = 0
        Dim nPlazo As Byte = 0
        Dim nPrimaSeguro As Decimal = 0.67
        Dim nSaldoEquipo As Decimal = 0
        Dim nSaldoOtros As Decimal = 0
        Dim nSaldoSeguro As Decimal = 0
        Dim nSaldoTotal As Decimal = 0
        Dim nSaldoTotalCliente As Decimal = 0
        Dim nSaldoTotalContrato As Decimal = 0
        Dim nSeguroVida As Decimal = 0
        Dim nSeguroVidaFacturado As Decimal = 0
        Dim nSeguroVidaCalculado As Decimal = 0
        Dim nImporteFega As Decimal = 0
        Dim nSeguroVidaMaximo As Decimal = 0
        Dim nImpSeguroVidaMaximo As Decimal = 0
        Dim nTasaFact As Decimal = 0
        Dim nTasaFactOriginal As Decimal = 0
        Dim nTasaIVACliente As Decimal = 0
        Dim nTasas As Decimal = 0
        Dim nUdiFinal As Decimal = 0
        Dim nUdiInicial As Decimal = 0
        Dim nVarEquipo As Decimal = 0
        Dim nVarOtros As Decimal = 0
        Dim nVarSeguro As Decimal = 0
        Dim nValorFrecuencia As Integer = 0

        Dim aFactura As New Factura()
        Dim aFacturas As New ArrayList()

        DateTimePicker1.Enabled = False
        btnProcesar.Enabled = False

        cFeven = DTOC(DateTimePicker1.Value)

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
        Dim daHista As New SqlDataAdapter(cm1)
        Dim daUdis As New SqlDataAdapter(cm2)
        Dim daEdoctav As New SqlDataAdapter(cm3)
        Dim daFacturas As New SqlDataAdapter(cm4)
        Dim daEdoctas As New SqlDataAdapter(cm5)
        Dim daEdoctao As New SqlDataAdapter(cm7)
        Dim daSVF As New SqlDataAdapter(cm8)

        Dim dsAgil As New DataSet()
        Dim dtTIIE As New DataTable()
        Dim drUdis As DataRowCollection
        Dim drAnexo As DataRow
        Dim drFacturas As DataRowCollection
        Dim drFactura As DataRow
        Dim drSeguros As DataRowCollection
        Dim drSeguro As DataRow
        Dim drOtros As DataRow
        Dim drTemporal As DataRow
        Dim drSVF As DataRow
        Dim dtSVC As New DataTable("SVC")           ' Seguro de Vida Calculado
        Dim drSVC As DataRow
        Dim dtSVPC As New DataTable("SVPC")         ' Seguro de Vida Por Contrato
        Dim drSVPC As DataRow
        Dim myColArray(1) As DataColumn
        Dim myKeySearch(0) As String

        Dim strInsert As String
        Dim strUpdate As String

        dtSVC.Columns.Add("Cliente", Type.GetType("System.String"))
        dtSVC.Columns.Add("SaldoTotal", Type.GetType("System.Decimal"))     ' Saldo total del cliente (para esta facturación)
        dtSVC.Columns.Add("SVC", Type.GetType("System.Decimal"))            ' Seguro de Vida Calculado
        dtSVC.Columns.Add("SVM", Type.GetType("System.Decimal"))            ' Seguro de Vida Máximo
        myColArray(0) = dtSVC.Columns("Cliente")
        dtSVC.PrimaryKey = myColArray

        dtSVPC.Columns.Add("Cliente", Type.GetType("System.String"))
        dtSVPC.Columns.Add("Anexo", Type.GetType("System.String"))
        dtSVPC.Columns.Add("SaldoTotal", Type.GetType("System.Decimal"))    ' Saldo total del contrato (para esta facturación)
        dtSVPC.Columns.Add("SeguroVida", Type.GetType("System.Decimal"))
        dtSVPC.Columns.Add("Dias", Type.GetType("System.Decimal"))          ' Dias
        myColArray(0) = dtSVPC.Columns("Anexo")
        dtSVPC.PrimaryKey = myColArray

        ' Este Stored Procedure regresa todas las tasas

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "GeneProv5"
            .Connection = cnAgil
        End With

        ' Este Stored Procedure regresa todas las UDIS ordenadas por vigencia

        With cm2
            .CommandType = CommandType.StoredProcedure
            .CommandText = "TraeUdis1"
            .Connection = cnAgil
        End With

        ' Este Stored Procedure regresa todos los registros de Edoctav cuya fecha de vencimiento sea igual
        ' a la fecha de proceso, que no estén facturados y que el contrato esté activo.

        ' A partir de la facturación del 20 de febrero de 2012 excluiré la Cartera Castigada.   La modificación
        ' la hice a nivel de Stored Procedure

        With cm3
            .CommandType = CommandType.StoredProcedure
            .CommandText = "GeneFact1"
            .Connection = cnAgil
            .Parameters.Add("@Fecha", SqlDbType.NVarChar)
            .Parameters(0).Value = cFeven
        End With

        ' Este Stored Procedure regresa todas las facturas generadas de todos los contratos activos
        ' a fin de determinar la fecha de facturación anterior de cada uno de ellos.

        With cm4
            .CommandType = CommandType.StoredProcedure
            .CommandText = "GeneFact2"
            .Connection = cnAgil
        End With

        ' Este Stored Procedure regresa todos los registros de Edoctas cuya fecha de vencimiento sea igual
        ' a la fecha de proceso, que no estén facturados y que el contrato esté activo.

        With cm5
            .CommandType = CommandType.StoredProcedure
            .CommandText = "GeneFact3"
            .Connection = cnAgil
            .Parameters.Add("@Fecha", SqlDbType.NVarChar)
            .Parameters(0).Value = cFeven
        End With

        ' Este comando permite traer el consecutivo de facturación

        With cm6
            .CommandType = CommandType.Text
            .CommandText = "SELECT IDFactura FROM Llaves"
            .Connection = cnAgil
        End With

        ' Este Stored Procedure regresa todos los registros de Edoctao cuya fecha de vencimiento sea igual
        ' a la fecha de proceso, que no estén facturados y que el contrato esté activo.

        With cm7
            .CommandType = CommandType.StoredProcedure
            .CommandText = "TraeAdeudos2"
            .Connection = cnAgil
            .Parameters.Add("@Fecha", SqlDbType.NVarChar)
            .Parameters(0).Value = cFeven
        End With

        ' Este comando permite traer el importe facturado a cada cliente por concepto de seguro de vida

        With cm8
            .CommandType = CommandType.Text
            .CommandText = "SELECT Facturas.Cliente, SUM(SeguroVida) AS SVF FROM Facturas " & _
                           "INNER JOIN Anexos ON Facturas.Anexo = Anexos.Anexo " & _
                           "WHERE AcumulaIntereses <> 'SI' AND LEFT(Feven, 6) = '" & Mid(cFeven, 1, 6) & "' AND Facturas.Cliente <> '' " & _
                           "GROUP BY Facturas.Cliente HAVING SUM(SeguroVida) > 0 " & _
                           "ORDER BY Facturas.Cliente"
            .Connection = cnAgil
        End With

        cnAgil.Open()
        nFactura = CInt(cm6.ExecuteScalar())
        cnAgil.Close()

        ' Llenar el DataSet a través del DataAdapter, lo cual abre y cierra la conexión

        daFacturas.Fill(dsAgil, "Facturas")
        daEdoctav.Fill(dsAgil, "Edoctav")
        daEdoctas.Fill(dsAgil, "Edoctas")
        daEdoctao.Fill(dsAgil, "Edoctao")
        daHista.Fill(dsAgil, "Hista")
        daUdis.Fill(dsAgil, "Udis")
        daSVF.Fill(dsAgil, "SVF")
        myColArray(0) = dsAgil.Tables("SVF").Columns("Cliente")
        dsAgil.Tables("SVF").PrimaryKey = myColArray

        drUdis = dsAgil.Tables("Udis").Rows
        drFacturas = dsAgil.Tables("Facturas").Rows
        drSeguros = dsAgil.Tables("Edoctas").Rows

        ' Genero la tabla que contiene las TIIE promedio por mes 

        ' Para FINAGIL considera todos los días del mes y redondea a 4 decimales

        dtTIIE = TIIEavg("FINAGIL")

        ' Aquí ya tengo las tablas que son de solo lectura por lo que ya no tengo que accesar al server ya que los valores los tomaré de la memoria RAM

        For Each drAnexo In dsAgil.Tables("Edoctav").Rows

            lProcesar = True

            ' Campos de la tabla Clientes

            cTipo = drAnexo("Tipo")
            cSegVida = drAnexo("SegVida")
            nTasaIVACliente = drAnexo("TasaIVACliente")

            ' Campos de la Tabla Anexos

            cAnexo = drAnexo("Anexo")
            cFechacon = drAnexo("Fechacon")
            cFecha_Pago = drAnexo("Fecha_Pago")
            cFondeo = drAnexo("Fondeo")
            cTipoFrecuencia = drAnexo("TipoFrecuencia")
            nValorFrecuencia = drAnexo("ValorFrecuencia")

            ' A partir del 1o. de octubre de 2011 únicamente se facturarán los contratos efectivamente pagados

            If cFechacon >= "20111001" And Trim(cFecha_Pago) = "" Then
                lProcesar = False
            End If

            If cAnexo <> "" And lProcesar = True Then

                cAcumulaIntereses = drAnexo("AcumulaIntereses")
                cCliente = drAnexo("Cliente")
                cFinse = drAnexo("Finse")
                cForca = drAnexo("Forca")
                cTipta = drAnexo("Tipta")
                cTipar = drAnexo("Tipar")
                nTasas = drAnexo("Tasas")
                nDifer = drAnexo("Difer")
                nImpDG = drAnexo("ImpRD")
                nDG = drAnexo("DG")
                cAdeudo = drAnexo("Adeudo")

                ' Esta es una nueva forma de calcular el plazo que implementé a partir del 17 de octubre de 2011
                ' para determinar correctamente el plazo para frecuencias de pago diferentes a mensual

                nPlazo = 0
                CuentaPagos(cAnexo, nPlazo)

                ' Campos de la Tabla Edoctav

                cFeven = drAnexo("Feven")
                cLetra = drAnexo("Letra")
                nSaldoEquipo = drAnexo("Saldo")
                nAbonoEquipo = drAnexo("Abcap")
                nIntEquipo = drAnexo("Inter")

                nBonifica = 0
                nIvaCapital = 0

                ' Si existe Depósito en Garantía y el porcentaje de dicho depósito es cero, se trata entonces
                ' de un arrendamiento financiero al cual hay que irle bonificando mes con mes el importe
                ' equivalente al IVA del capital que hubiera dejado

                If cTipar = "F" Then
                    If cFechacon >= "20020901" And nImpDG > 0 And nDG = 0 Then
                        nBonifica = drAnexo("IvaCapital")
                    End If
                    If drAnexo("IvaCapital") > 0 Then
                        nIvaCapital = Round(nAbonoEquipo * (nTasaIVACliente / 100), 2)
                    Else
                        nIvaCapital = 0
                    End If
                End If

                ' Las siguientes 3 variables son modificadas en el módulo CalcInte

                nTasaFact = nTasas
                nDiasFact = 0
                nIntRealEq = 0

                If cAcumulaIntereses = "SI" Then

                    ' Los créditos con Esquema de acumulación de intereses entrarían a esta sección

                    nLetra = Val(cLetra)

                    If nLetra = 1 Then
                        If cFechacon <= "20110930" Then
                            cFechaDocumento = cFechacon
                        Else
                            cFechaDocumento = cFecha_Pago
                        End If
                        dAnterior = CTOD(cFechaDocumento)
                        dFeven = CTOD(cFeven)
                        nDiasFact = DateDiff(DateInterval.Day, dAnterior, dFeven)
                    Else
                        For Each drFactura In drFacturas
                            If cAnexo = drFactura("Anexo") And Val(drFactura("Letra")) = nLetra - 1 Then
                                cFechaDocumento = drFactura("Feven")
                                dFeven = CTOD(cFeven)
                                dAnterior = CTOD(cFechaDocumento)
                                nDiasFact = IIf(dAnterior < dFeven, DateDiff(DateInterval.Day, dAnterior, dFeven), 0)
                            End If
                        Next
                    End If

                    For Each drTemporal In InteresAcumulado(cAnexo, cTipta, "FINAGIL", cFechaDocumento, nSaldoEquipo, nTasas, nDifer, cFeven, dtTIIE, cFeven).Rows
                        nIntRealEq += drTemporal("Interes")
                    Next

                    ' Como en el esquema de acumulación de intereses la tasa se calcula mes con mes (principalmente cuando es tasa variable)
                    ' tengo que determinar la tasa de interés equivalente para grabar este valor en la factura y utilizarla al calcular
                    ' el IVA de los Intereses (para Arrendamiento Financiero).

                    nTasaFact = Round(nIntRealEq * 360 / nDiasFact / nSaldoEquipo * 100, 4)

                Else

                    If cFechacon <= "20110930" Then
                        cFechaDocumento = cFechacon
                    Else
                        cFechaDocumento = cFecha_Pago
                    End If

                    CalcInte(drFacturas, dsAgil.Tables("Hista").Rows, nTasaFact, nDiasFact, nIntRealEq, cFeven, cAnexo, cFechaDocumento, cLetra, nSaldoEquipo, cTipta, nDifer)

                End If

                ' Estas variables las voy a utilizar para guardar los valores iniciales de nDiasFact y nTasaFact ya que éstos cambian su valor posteriormente

                nDiasFactOriginal = nDiasFact
                nTasaFactOriginal = nTasaFact

                nSaldoSeguro = 0
                nAbonoSeguro = 0
                nIntSeguro = 0

                ' La siguiente variable es modificada en el módulo CalcInte

                nIntRealSe = 0

                If cFinse = "S" Then

                    nTasaFact = nTasas
                    nDiasFact = 0
                    For Each drSeguro In drSeguros
                        If cAnexo = drSeguro("Anexo") Then
                            nSaldoSeguro = drSeguro("Saldo")
                            nAbonoSeguro = drSeguro("Abcap")
                            nIntSeguro = drSeguro("Inter")
                            nIntRealSe = 0
                        End If
                    Next

                    If cAcumulaIntereses = "SI" Then

                        ' Los créditos con Esquema de acumulación de intereses entrarían a esta sección

                        For Each drTemporal In InteresAcumulado(cAnexo, cTipta, "FINAGIL", cFechaDocumento, nSaldoSeguro, nTasas, nDifer, cFeven, dtTIIE, cFeven).Rows
                            nIntRealSe += drTemporal("Interes")
                        Next

                    Else

                        CalcInte(drFacturas, dsAgil.Tables("Hista").Rows, nTasaFact, nDiasFact, nIntRealSe, cFeven, cAnexo, cFechacon, cLetra, nSaldoSeguro, cTipta, nDifer)

                    End If

                End If

                nVarEquipo = Round(nIntRealEq - nIntEquipo, 2)
                nVarSeguro = Round(nIntRealSe - nIntSeguro, 2)

                ' Los seguros se tratarán como si fueran un Crédito Simple en lo referente al IVA de los intereses
                ' por lo que sólo se calculará dicho IVA para personas físicas sin actividad empresarial
                ' y se calculará de acuerdo a la Tasa de IVA que corresponda al domicilio fiscal del Cliente

                nIvaInteresSeguro = 0
                If cFinse = "S" And cTipo = "F" Then
                    nIvaInteresSeguro = Round(nIntRealSe * (nTasaIVACliente / 100), 2)
                End If

                nUdiInicial = 0
                nUdiFinal = 0
                nIvaInteresEquipo = 0

                If cTipar = "F" Then

                    ' El IVA de los intereses del equipo en arrendamiento financiero siempre existe y se calcula en base a UDIS

                    ' A partir de la facturación del 16 de diciembre de 2005, se tomará el valor de las UDIS
                    ' de un mes atrás a efecto de poder facturar con mayor anticipación

                    dFechaInicial = CTOD(cFeven)
                    dFechaInicial = DateAdd(DateInterval.Day, -nDiasFactOriginal, dFechaInicial)
                    cFechaInicial = DTOC(dFechaInicial)

                    cFechaFinal = cFechaInicial
                    dFechaInicial = CTOD(cFechaInicial)
                    dFechaInicial = DateAdd(DateInterval.Day, -nDiasFactOriginal, dFechaInicial)
                    cFechaInicial = DTOC(dFechaInicial)

                    nIvaInteresEquipo = CalcIvaU(drUdis, nSaldoEquipo, nTasaFactOriginal, cFechaInicial, cFechaFinal, nUdiInicial, nUdiFinal, (nTasaIVACliente / 100))

                ElseIf cTipar = "P" Then

                    ' En el caso del Arrendamiento Puro calculamos el importe del IVA de la Renta (Capital + Interés Histórico +- Variación)

                    nIvaInteresEquipo = Round((nAbonoEquipo + nIntEquipo + nVarEquipo) * (nTasaIVACliente / 100), 2)

                ElseIf (cTipar = "R" Or cTipar = "S") And cTipo = "F" Then

                    ' Tratándose de crédito refaccionario o crédito simple, el IVA de los intereses existe
                    ' solamente que se trate de un cliente persona física sin actividad empresarial y se
                    ' calcula de acuerdo a la Tasa de IVA que corresponda al domicilio fiscal del Cliente

                    nIvaInteresEquipo = Round(nIntRealEq * (nTasaIVACliente / 100), 2)

                End If

                ' A partir de enero de 2007 ya no se manejará la capitalización de adeudos en la tabla del equipo;
                ' ahora se controla a través de una tabla de Otros Adeudos

                ' A partir de julio de 2008 no se manejará el concepto de Otros Adeudos y se sustituirá por el
                ' concepto de Crédito Simple

                nCapOtros = 0
                nIntOtros = 0
                nIntRealOt = 0
                nVarOtros = 0
                nIvaInteresOtros = 0
                nSaldoOtros = 0

                If cAdeudo = "S" Then

                    nTasaFact = nTasas
                    nDiasFact = 0

                    For Each drOtros In dsAgil.Tables("Edoctao").Rows
                        If cAnexo = drOtros("Anexo") Then
                            nSaldoOtros = drOtros("Saldo")
                            nCapOtros = drOtros("Abcap")
                            nIntOtros = drOtros("Inter")
                        End If
                    Next

                    CalcInte(drFacturas, dsAgil.Tables("Hista").Rows, nTasaFact, nDiasFact, nIntRealOt, cFeven, cAnexo, cFechacon, cLetra, nSaldoOtros, cTipta, nDifer)

                    nVarOtros = Round(nIntRealOt - nIntOtros, 2)

                    ' Otros adeudos se tratarán como si fueran un Crédito Simple en lo referente al IVA de los intereses
                    ' por lo que solo se calculará dicho IVA para personas físicas sin actividad empresarial
                    ' y se calculará al 11% o al 16% dependiendo del porcentaje de IVA al cliente

                    If cTipo = "F" Then
                        nIvaInteresOtros = Round(nIntRealOt * (nTasaIVACliente / 100), 2)
                    End If

                End If

                ' Aquí ya tengo determinado el Saldo del Equipo, el Saldo del Seguro y el Saldo de Otros Adeudos
                ' por lo que puedo ir sumarizando el saldo para aquellos clientes que tengan Seguro de Vida

                nSeguroVida = 0

                If cSegVida = "S" Then

                    nSaldoTotal = Round(nSaldoEquipo + nSaldoSeguro + nSaldoOtros, 2)

                    If cAcumulaIntereses = "SI" Then

                        If nSaldoTotal > nImporteMaximoAsegurado Then
                            nSeguroVida = Round(nImporteMaximoAsegurado / 1000 * nPrimaSeguro / 30.4 * nDiasFactOriginal, 2)
                        Else
                            nSeguroVida = Round(nSaldoTotal / 1000 * nPrimaSeguro / 30.4 * nDiasFactOriginal, 2)
                        End If

                    Else

                        ' Busca el número de cliente en la tabla dtSVC (Seguro de Vida Calculado)

                        myKeySearch(0) = cCliente
                        drSVC = dtSVC.Rows.Find(myKeySearch)
                        If drSVC Is Nothing Then
                            drSVC = dtSVC.NewRow()
                            drSVC("Cliente") = cCliente
                            drSVC("SaldoTotal") = nSaldoTotal
                            drSVC("SVC") = Round(nSaldoTotal / 1000 * nPrimaSeguro / 30.4 * nDiasFactOriginal, 2)
                            drSVC("SVM") = 0
                            dtSVC.Rows.Add(drSVC)
                        Else
                            drSVC("SaldoTotal") += nSaldoTotal
                            drSVC("SVC") += Round(nSaldoTotal / 1000 * nPrimaSeguro / 30.4 * nDiasFactOriginal, 2)
                        End If

                        ' Busca el número de contrato en la tabla SVPC (Seguro de Vida Por Contrato)

                        myKeySearch(0) = cAnexo
                        drSVPC = dtSVPC.Rows.Find(myKeySearch)
                        If drSVPC Is Nothing Then
                            drSVPC = dtSVPC.NewRow()
                            drSVPC("Cliente") = cCliente
                            drSVPC("Anexo") = cAnexo
                            drSVPC("SaldoTotal") = nSaldoTotal
                            drSVPC("SeguroVida") = Round(nSaldoTotal / 1000 * nPrimaSeguro / 30.4 * nDiasFactOriginal, 2)
                            drSVPC("Dias") = nDiasFactOriginal
                            dtSVPC.Rows.Add(drSVPC)
                        Else
                            drSVPC("SaldoTotal") += nSaldoTotal
                            drSVPC("SeguroVida") += Round(nSaldoTotal / 1000 * nPrimaSeguro / 30.4 * nDiasFactOriginal, 2)
                        End If

                    End If

                End If

                nImporteFega = 0
                nIntRealFega = 0

                ' A petición del C.P. Geraldo García ya no se calculará la Garantía FEGA (ni sus intereses) debido a que comentó que
                ' en la tasa de interés incluyen el costo de las Coberturas.

                'If cFondeo = "03" Then
                '    nTasaFact = nTasas
                '    nDiasFact = 0
                '    nImporteFega = nSaldoEquipo * 0.01 * (1 + (nTasaIVACliente / 100))
                '    nImporteFega = Round(nImporteFega / 360 * nDiasFactOriginal, 2)
                '    If cAcumulaIntereses = "SI" Then
                '        For Each drTemporal In InteresAcumulado(cAnexo, cTipta, "FINAGIL", cFechaDocumento, nImporteFega, nTasas, nDifer, cFeven, dtTIIE, cFeven).Rows
                '            nIntRealFega += drTemporal("Interes")
                '        Next
                '    Else
                '        CalcInte(drFacturas, dsAgil.Tables("Hista").Rows, nTasaFact, nDiasFact, nIntRealFega, cFeven, cAnexo, cFechacon, cLetra, nImporteFega, cTipta, nDifer)
                '    End If
                'End If

                nImporteFac = nAbonoEquipo + nIntEquipo + nVarEquipo + nIvaInteresEquipo + nIvaCapital - nBonifica
                nImporteFac += nAbonoSeguro + nIntSeguro + nVarSeguro + nIvaInteresSeguro
                nImporteFac += nCapOtros + nIntOtros + nVarOtros + nIvaInteresOtros
                nImporteFac += nSeguroVida
                nImporteFac += nImporteFega + nIntRealFega

                nImporteFac = Round(nImporteFac, 2)

                With aFactura
                    .Anexo = cAnexo
                    .Letra = cLetra
                    .Plazo = nPlazo
                    .Cliente = cCliente
                    .Feven = cFeven
                    .Fepag = ""
                    .Saldo = nSaldoEquipo
                    .SalSe = nSaldoSeguro
                    .SalOt = nSaldoOtros
                    .RenPr = Round(nAbonoEquipo + nIntEquipo, 2)
                    .IntPr = IIf(cTipar = "P", 0, nIntEquipo)
                    .Bonifica = nBonifica
                    .IvaCapital = nIvaCapital
                    .VarPr = nVarEquipo
                    .IvaPr = nIvaInteresEquipo
                    .RenSe = nAbonoSeguro
                    .IntSe = nIntSeguro
                    .VarSe = nVarSeguro
                    .IvaSe = nIvaInteresSeguro
                    .Opcion = 0
                    .IvaOpcion = 0
                    .CapitalO = nCapOtros
                    .InteresO = nIntOtros
                    .VarO = Round(nVarOtros + nIntRealFega, 2)
                    .IvaO = nIvaInteresOtros
                    .SeguroVida = nSeguroVida
                    .Tipmon = "01"
                    .Dias = nDiasFactOriginal
                    .Tasa = nTasaFactOriginal - nDifer
                    .Difer = nDifer
                    .Udi1 = nUdiInicial
                    .Udi2 = nUdiFinal
                    .TasaIVA = nTasaIVACliente
                    .ImporteFac = nImporteFac
                    .SaldoFac = nImporteFac
                    .ImporteFega = nImporteFega
                    .IndPag = ""
                    .Enviado = "N"
                End With

                aFacturas.Add(aFactura)

            End If

        Next

        ' Cuando llego a este punto, ya calculé y guardé el Seguro de Vida de los contratos con Acumulación de Intereses.

        ' Ahora tengo que revisar los clientes que se exceden en su Cuota Máxima Mensual del Seguro de Vida

        For Each drSVC In dtSVC.Rows

            nSeguroVidaCalculado = drSVC("SVC")

            ' Busco al cliente en la tabla de Seguro de Vida Facturado en facturaciones anteriores pero del mismo mes

            myKeySearch(0) = drSVC("Cliente")
            drSVF = dsAgil.Tables("SVF").Rows.Find(myKeySearch)

            If Not drSVF Is Nothing Then

                ' Si lo encuentra determina cuánto le ha facturado en facturaciones anteriores pero del mismo mes por concepto de Seguro de Vida

                nSeguroVidaFacturado = drSVF("SVF")

                If Round(nSeguroVidaCalculado + nSeguroVidaFacturado, 2) > nCuotaMaximaMensual Then
                    nSeguroVidaMaximo = nCuotaMaximaMensual - nSeguroVidaFacturado
                    If nSeguroVidaMaximo < 0 Then
                        nSeguroVidaMaximo = 0
                    End If
                    drSVC("SVM") = nSeguroVidaMaximo
                Else
                    drSVC("SVM") = nSeguroVidaCalculado
                End If

            Else

                ' Si no lo encuentra significa que son los primeros contratos que se facturan en el mes para este cliente

                If nSeguroVidaCalculado > nCuotaMaximaMensual Then
                    drSVC("SVM") = nCuotaMaximaMensual
                Else
                    drSVC("SVM") = nSeguroVidaCalculado
                End If

            End If

        Next

        For Each drSVC In dtSVC.Rows

            nSeguroVidaCalculado = drSVC("SVC")
            nSeguroVidaMaximo = drSVC("SVM")

            ' Si el Seguro de Vida Máximo es inferior al Seguro de Vida Calculado, significa que tengo que prorratear el Seguro de Vida Máximo
            ' entre los diferentes contratos de este cliente.   Preferentemente hacer una ponderación entre el Saldo y el número de días facturados.

            If nSeguroVidaMaximo < nSeguroVidaCalculado Then
                nSaldoTotalCliente = drSVC("SaldoTotal")
                For Each drSVPC In dtSVPC.Rows
                    If drSVPC("Cliente") = drSVC("Cliente") Then
                        nSaldoTotalContrato = drSVPC("SaldoTotal")
                        drSVPC("SeguroVida") = Round(nSeguroVidaMaximo * nSaldoTotalContrato / nSaldoTotalCliente, 2)
                    End If
                Next
            End If

        Next

        ' Actualización de las Tablas: Facturas, Edoctav, Edoctas, Edoctao y Opciones

        cnAgil.Open()

        For Each aFactura In aFacturas

            nFactura = nFactura + 1

            ' Por último tendría que grabar el importe del Seguro de Vida e incrementar ImporteFac y SaldoFac
            ' (solamente para los contratos que no tienen acumulación de intereses ya que para estos ya guardé el Seguro de Vida en aFactura.SeguroVida)

            If aFactura.SeguroVida = 0 Then

                myKeySearch(0) = aFactura.Anexo
                drSVPC = dtSVPC.Rows.Find(myKeySearch)

                nSeguroVida = 0
                If Not drSVPC Is Nothing Then
                    nSeguroVida = drSVPC("SeguroVida")
                End If

                nImporteFac = Round(aFactura.ImporteFac + nSeguroVida, 2)

            Else

                nSeguroVida = aFactura.SeguroVida
                nImporteFac = aFactura.ImporteFac

            End If

            Try

                strInsert = "INSERT INTO Facturas(Factura, Anexo, Letra, Cliente, Feven, Fepag, Saldo, Salse, "
                strInsert = strInsert & "Saldot, RenPr, IntPr, Bonifica, IvaCapital, VarPr, IvaPr, RenSe, IntSe, "
                strInsert = strInsert & "VarSe, IvaSe, Opcion, IvaOpcion, CapitalOt, InteresOt, VarOt, IvaOt, SeguroVida, ImporteFega, Tipmon, "
                strInsert = strInsert & "Dias, Tasa, Difer, Udi1, Udi2, TasaIVA, ImporteFac, SaldoFac, IndPag, Enviado)"
                strInsert = strInsert & " VALUES ('"
                strInsert = strInsert & nFactura & "', '"
                strInsert = strInsert & aFactura.Anexo & "', '"
                strInsert = strInsert & aFactura.Letra & "', '"
                strInsert = strInsert & aFactura.Cliente & "', '"
                strInsert = strInsert & aFactura.Feven & "', '"
                strInsert = strInsert & aFactura.Fepag & "', "
                strInsert = strInsert & aFactura.Saldo & ", "
                strInsert = strInsert & aFactura.SalSe & ", "
                strInsert = strInsert & aFactura.SalOt & ", "
                strInsert = strInsert & aFactura.RenPr & ", "
                strInsert = strInsert & aFactura.IntPr & ", "
                strInsert = strInsert & aFactura.Bonifica & ", "
                strInsert = strInsert & aFactura.IvaCapital & ", "
                strInsert = strInsert & aFactura.VarPr & ", "
                strInsert = strInsert & aFactura.IvaPr & ", "
                strInsert = strInsert & aFactura.RenSe & ", "
                strInsert = strInsert & aFactura.IntSe & ", "
                strInsert = strInsert & aFactura.VarSe & ", "
                strInsert = strInsert & aFactura.IvaSe & ", "
                strInsert = strInsert & aFactura.Opcion & ", "
                strInsert = strInsert & aFactura.IvaOpcion & ", "
                strInsert = strInsert & aFactura.CapitalO & ", "
                strInsert = strInsert & aFactura.InteresO & ", "
                strInsert = strInsert & aFactura.VarO & ", "
                strInsert = strInsert & aFactura.IvaO & ", "
                strInsert = strInsert & nSeguroVida & ", "
                strInsert = strInsert & aFactura.ImporteFega & ", '"
                strInsert = strInsert & aFactura.Tipmon & "', "
                strInsert = strInsert & aFactura.Dias & ", "
                strInsert = strInsert & aFactura.Tasa & ", "
                strInsert = strInsert & aFactura.Difer & ", "
                strInsert = strInsert & aFactura.Udi1 & ", "
                strInsert = strInsert & aFactura.Udi2 & ", "
                strInsert = strInsert & aFactura.TasaIVA & ", "
                strInsert = strInsert & nImporteFac & ", "
                strInsert = strInsert & nImporteFac & ", '"
                strInsert = strInsert & aFactura.IndPag & "', '"
                strInsert = strInsert & aFactura.Enviado
                strInsert = strInsert & "')"
                cm1 = New SqlCommand(strInsert, cnAgil)
                cm1.ExecuteNonQuery()

                strUpdate = "UPDATE Edoctav SET Nufac = " & nFactura
                strUpdate = strUpdate & " WHERE Anexo = " & aFactura.Anexo
                strUpdate = strUpdate & " AND Letra = " & aFactura.Letra
                strUpdate = strUpdate & " AND Feven = " & aFactura.Feven
                strUpdate = strUpdate & " AND Nufac = 0 "
                strUpdate = strUpdate & " AND IndRec = 'S'"
                cm1 = New SqlCommand(strUpdate, cnAgil)
                cm1.ExecuteNonQuery()

                strUpdate = "UPDATE Edoctas SET Nufac = " & nFactura
                strUpdate = strUpdate & " WHERE Anexo = " & aFactura.Anexo
                strUpdate = strUpdate & " AND Letra = " & aFactura.Letra
                strUpdate = strUpdate & " AND Feven = " & aFactura.Feven
                strUpdate = strUpdate & " AND Nufac = 0 "
                strUpdate = strUpdate & " AND IndRec = 'S'"
                cm1 = New SqlCommand(strUpdate, cnAgil)
                cm1.ExecuteNonQuery()

                strUpdate = "UPDATE Edoctao SET Nufac = " & nFactura
                strUpdate = strUpdate & " WHERE Anexo = " & aFactura.Anexo
                strUpdate = strUpdate & " AND Letra = " & aFactura.Letra
                strUpdate = strUpdate & " AND Feven = " & aFactura.Feven
                strUpdate = strUpdate & " AND Nufac = 0 "
                strUpdate = strUpdate & " AND IndRec = 'S'"
                cm1 = New SqlCommand(strUpdate, cnAgil)
                cm1.ExecuteNonQuery()

                ' Si es el último vencimiento del contrato, debe marcar la opción de compra como exigible

                If Val(aFactura.Letra) = Val(aFactura.Plazo) Then
                    strUpdate = "UPDATE Opciones SET Exigible = '" & "S'"
                    strUpdate = strUpdate & " WHERE Anexo = '" & aFactura.Anexo & "'"
                    cm1 = New SqlCommand(strUpdate, cnAgil)
                    cm1.ExecuteNonQuery()
                End If

            Catch eException As Exception

                MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")

            End Try

        Next

        ' Actualización de la tabla Llaves

        strUpdate = "UPDATE Llaves SET IDFactura = " & nFactura
        cm1 = New SqlCommand(strUpdate, cnAgil)
        cm1.ExecuteNonQuery()
        cnAgil.Close()

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()
        cm3.Dispose()
        cm4.Dispose()
        cm5.Dispose()
        cm6.Dispose()
        cm7.Dispose()
        cm8.Dispose()

        MsgBox("Generación de Avisos de Vencimiento de Renta concluido", MsgBoxStyle.OkOnly, "Mensaje del Sistema")

    End Sub

End Class
