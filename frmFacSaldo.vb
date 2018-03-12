Option Explicit On 

Imports System.Data.SqlClient
Imports System.Math
Imports CrystalDecisions.Shared

Public Class frmFacSaldo

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
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents lblClientes As System.Windows.Forms.Label
    Friend WithEvents btnAdeudos As System.Windows.Forms.Button
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.lblClientes = New System.Windows.Forms.Label
        Me.btnAdeudos = New System.Windows.Forms.Button
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnSalir = New System.Windows.Forms.Button
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(72, 16)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(88, 20)
        Me.dtpFecha.TabIndex = 9
        '
        'ComboBox1
        '
        Me.ComboBox1.Location = New System.Drawing.Point(240, 17)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(424, 21)
        Me.ComboBox1.TabIndex = 12
        '
        'lblClientes
        '
        Me.lblClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClientes.Location = New System.Drawing.Point(184, 19)
        Me.lblClientes.Name = "lblClientes"
        Me.lblClientes.Size = New System.Drawing.Size(56, 16)
        Me.lblClientes.TabIndex = 13
        Me.lblClientes.Text = "Cliente"
        '
        'btnAdeudos
        '
        Me.btnAdeudos.Location = New System.Drawing.Point(691, 16)
        Me.btnAdeudos.Name = "btnAdeudos"
        Me.btnAdeudos.Size = New System.Drawing.Size(75, 23)
        Me.btnAdeudos.TabIndex = 14
        Me.btnAdeudos.Text = "Adeudos"
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(8, 56)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1008, 640)
        Me.CrystalReportViewer1.TabIndex = 15
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Fecha"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(789, 16)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 28
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'DataGrid1
        '
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(893, 12)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(37, 34)
        Me.DataGrid1.TabIndex = 29
        Me.DataGrid1.Visible = False
        '
        'frmFacSaldo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1024, 702)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.btnAdeudos)
        Me.Controls.Add(Me.lblClientes)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.dtpFecha)
        Me.Name = "frmFacSaldo"
        Me.Text = "Estados de Cuenta"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmFacSaldo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daClientes As New SqlDataAdapter(cm1)
        Dim dsAgil As New DataSet()

        ' Declaración de variables de datos

        Dim cFecha As String

        cFecha = DTOC(dtpFecha.Value)

        ' Este Stored Procedure trae EXCLUSIVAMENTE los clientes que tengan adeudo
        ' ya sea por rentas, por pagos iniciales o por opciones de compra, a fin
        ' de no mostrar clientes que no tengan adeudo a la fecha dada

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "ReciPago1"
            .Connection = cnAgil
            .Parameters.Add("@Fecha", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        ComboBox1.MaxDropDownItems = 35

        Try

            ' Llenar el DataSet lo cual abre y cierra la conexión

            daClientes.Fill(dsAgil, "Clientes")

            ' Ligar la tabla Clientes del dataset dsAgil al ComboBox

            ComboBox1.DataSource = dsAgil
            ComboBox1.DisplayMember = "Clientes.Descr"
            ComboBox1.ValueMember = "Clientes.Cliente"

        Catch eException As Exception

            MsgBox(eException.Source & " " & eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")

        End Try

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub btnAdeudos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdeudos.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim cm4 As New SqlCommand()
        Dim cm5 As New SqlCommand()
        Dim cm6 As New SqlCommand()
        Dim daFacturas As New SqlDataAdapter(cm1)
        Dim daAnexos As New SqlDataAdapter(cm2)
        Dim daPagosIniciales As New SqlDataAdapter(cm3)
        Dim daUdis As New SqlDataAdapter(cm4)
        Dim daOpciones As New SqlDataAdapter(cm5)
        Dim daClientes As New SqlDataAdapter(cm6)
        Dim dsAgil As New DataSet()
        Dim drCliente As DataRow
        Dim drAnexos As DataRowCollection
        Dim drAnexo As DataRow
        Dim drFactura As DataRow
        Dim drUdis As DataRowCollection
        Dim drOpciones As DataRowCollection
        Dim drOpcion As DataRow
        Dim myColArray(1) As DataColumn
        Dim dtTemporal As New DataTable("Temporal")
        Dim dtAdeudos As New DataTable("Adeudos")
        Dim dvTemporal As DataView
        Dim drTemporal As DataRow

        ' Declaración de variables de datos

        Dim cAnexo As String
        Dim cCliente As String
        Dim cFecha As String
        Dim cFechacon As String
        Dim cFepag As String
        Dim cFeven As String
        Dim cFlcan As String
        Dim cFondeo As String
        Dim cNombreCliente As String
        Dim cTermina As String
        Dim cTipar As String
        Dim cTipo As String
        Dim dTermina As Date
        Dim i As Integer
        Dim nAmorin As Decimal
        Dim nCounter As Integer
        Dim nDiasMoratorios As Decimal
        Dim nFactura As Decimal
        Dim nImpEq As Decimal
        Dim nIvaEq As Decimal
        Dim nIvaMoratorios As Decimal
        Dim nMoratorios As Decimal
        Dim nPagosIniciales As Decimal
        Dim nSaldo As Decimal
        Dim nSaldoTotal As Decimal
        Dim nTasaIVACliente As Decimal = 0
        Dim nTasaMoratoria As Decimal

        ' Declaración de variables de Crystal Reports

        Dim newrptFacSaldo As New rptFacSaldo()
        Dim cReportTitle As String
        Dim cReportComments As String

        dtTemporal.Columns.Add("Concepto", Type.GetType("System.String"))
        dtTemporal.Columns.Add("Contrato", Type.GetType("System.String"))
        dtTemporal.Columns.Add("Letra", Type.GetType("System.String"))
        dtTemporal.Columns.Add("Aviso", Type.GetType("System.Decimal"))
        dtTemporal.Columns.Add("Vencimiento", Type.GetType("System.String"))
        dtTemporal.Columns.Add("UltimoPago", Type.GetType("System.String"))
        dtTemporal.Columns.Add("DiasMoratorios", Type.GetType("System.Decimal"))
        dtTemporal.Columns.Add("Saldo", Type.GetType("System.Decimal"))
        dtTemporal.Columns.Add("Moratorios", Type.GetType("System.Decimal"))
        dtTemporal.Columns.Add("IvaMoratorios", Type.GetType("System.Decimal"))
        dtTemporal.Columns.Add("SaldoTotal", Type.GetType("System.Decimal"))
        dtTemporal.Clear()

        dtAdeudos.Columns.Add("Concepto", Type.GetType("System.String"))
        dtAdeudos.Columns.Add("Contrato", Type.GetType("System.String"))
        dtAdeudos.Columns.Add("Letra", Type.GetType("System.String"))
        dtAdeudos.Columns.Add("Aviso", Type.GetType("System.Decimal"))
        dtAdeudos.Columns.Add("Vencimiento", Type.GetType("System.String"))
        dtAdeudos.Columns.Add("UltimoPago", Type.GetType("System.String"))
        dtAdeudos.Columns.Add("DiasMoratorios", Type.GetType("System.Decimal"))
        dtAdeudos.Columns.Add("Saldo", Type.GetType("System.Decimal"))
        dtAdeudos.Columns.Add("Moratorios", Type.GetType("System.Decimal"))
        dtAdeudos.Columns.Add("IvaMoratorios", Type.GetType("System.Decimal"))
        dtAdeudos.Columns.Add("SaldoTotal", Type.GetType("System.Decimal"))
        dtAdeudos.Clear()

        If Not ComboBox1.SelectedValue Is Nothing Then

            cCliente = ComboBox1.SelectedValue.ToString()

            If Len(cCliente) = 5 Then

                ' Ya que se escogió un cliente del listado, por lo que hay que traer los
                ' adeudos por concepto de pagos iniciales, rentas y opciones de compra

                cFecha = DTOC(dtpFecha.Value)

                ' El siguiente Stored Procedure trae todos los contratos con saldo en facturas 
                ' correspondientes al cliente dado aun cuando la factura no sea exigible todavía

                With cm1
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "TraeAV1"
                    .Connection = cnAgil
                    .Parameters.Add("@Cliente", SqlDbType.NVarChar)
                    .Parameters(0).Value = cCliente
                End With

                ' El siguiente Stored Procedure trae todos los contratos del cliente seleccionado
                ' sin importar su estatus a fin de determinar si cubrió o no sus pagos iniciales

                With cm2
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "PideAnex2"
                    .Connection = cnAgil
                    .Parameters.Add("@Cliente", SqlDbType.NVarChar)
                    .Parameters(0).Value = cCliente
                End With

                ' Este Stored Procedure trae el número de anexo de los contratos que ya realizaron
                ' sus pagos iniciales, para un cliente determinado

                With cm3
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "PagosIni2"
                    .Connection = cnAgil
                    .Parameters.Add("@Cliente", SqlDbType.NVarChar)
                    .Parameters(0).Value = cCliente
                End With

                ' Este Stored Procedure regresa todas las UDIS ordenadas por vigencia

                With cm4
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "TraeUdis1"
                    .Connection = cnAgil
                End With

                ' Este Stored Procedure trae las opciones de compra exigibles y no pagadas
                ' de un cliente determinado

                With cm5
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "TraeOC1"
                    .Connection = cnAgil
                    .Parameters.Add("@Cliente", SqlDbType.NVarChar)
                    .Parameters(0).Value = cCliente
                End With

                ' El siguiente command trae el nombre del cliente, la Sucursal que lo atiende y la Tasa de IVA que le aplica

                With cm6
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT Descr, TasaIVACliente FROM Clientes WHERE Cliente = " & "'" & cCliente & "'"
                    .Connection = cnAgil
                End With

                Try

                    ' Llenar el DataSet lo cual abre y cierra la conexión

                    daFacturas.Fill(dsAgil, "Facturas")
                    daAnexos.Fill(dsAgil, "Anexos")
                    daPagosIniciales.Fill(dsAgil, "PagosIniciales")
                    daUdis.Fill(dsAgil, "Udis")
                    daOpciones.Fill(dsAgil, "Opciones")
                    daClientes.Fill(dsAgil, "Clientes")

                    drCliente = dsAgil.Tables("Clientes").Rows(0)
                    cNombreCliente = drCliente("Descr")

                    ' Traigo la Tasa de IVA que aplica al cliente a efecto de poder determinar correctamente el IVA de los Moratorios

                    nTasaIVACliente = drCliente("TasaIVACliente")

                    ' Tengo que definir una llave primaria para la tabla de Pagos Iniciales
                    ' para que se acelere la búsqueda cuando revise si existe el pago inicial
                    ' de un contrato

                    myColArray(0) = dsAgil.Tables("PagosIniciales").Columns("Anexo")
                    dsAgil.Tables("PagosIniciales").PrimaryKey = myColArray

                Catch eException As Exception

                    MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")

                End Try

                ' Tengo que determinar cuáles contratos del cliente seleccionado
                ' NO han cubierto sus pagos iniciales, ignorando los contratos dados de BAJA,
                ' CANCELADOS o en SUSPENSO

                drAnexos = dsAgil.Tables("Anexos").Rows

                For Each drAnexo In drAnexos

                    cAnexo = drAnexo("Anexo")

                    If dsAgil.Tables("PagosIniciales").Rows.Find(cAnexo) Is Nothing Then

                        ' Significa que NO se ha realizado el pago inicial de este contrato 

                        cFlcan = drAnexo("Flcan")
                        cFondeo = drAnexo("Fondeo")
                        nImpEq = drAnexo("ImpEq")
                        nIvaEq = drAnexo("IvaEq")
                        nAmorin = drAnexo("Amorin")
                        cFechacon = drAnexo("Fechacon")

                        nPagosIniciales = Round(drAnexo("ImpRD") + drAnexo("IvaRD") + drAnexo("Comis") + nAmorin + drAnexo("IvaAmorin") + drAnexo("Gastos") + drAnexo("IvaGastos") + drAnexo("ImpDG") + drAnexo("IvaDG"), 2)
                        If drAnexo("Tipar") = "R" Then
                            nPagosIniciales = Round(drAnexo("ImpRD") + drAnexo("IvaRD") + drAnexo("Comis") + nAmorin + drAnexo("IvaAmorin") + drAnexo("Gastos") + drAnexo("IvaGastos") + drAnexo("Derechos") + drAnexo("ImpDG") + drAnexo("IvaDG"), 2)
                        End If
                        If cFondeo = "02" Then
                            nPagosIniciales = nPagosIniciales + Round((nImpEq - nIvaEq - nAmorin) * 5 / 100, 2)
                        End If

                        ' Insertar un registro en la tabla Temporal siempre y cuando no sea
                        ' un contrato dado de BAJA, CANCELADO o en SUSPENSO

                        If cFlcan <> "B" And cFlcan <> "S" And cFlcan <> "C" Then
                            drTemporal = dtTemporal.NewRow()
                            drTemporal("Concepto") = "Pago Inicial"
                            drTemporal("Contrato") = Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 6, 4)
                            drTemporal("Letra") = "000"
                            drTemporal("Aviso") = 0
                            drTemporal("Vencimiento") = cFechacon
                            drTemporal("UltimoPago") = "        "
                            drTemporal("DiasMoratorios") = DateDiff(DateInterval.Day, CTOD(cFechacon), CTOD(cFecha))
                            drTemporal("Saldo") = nPagosIniciales
                            drTemporal("Moratorios") = 0
                            drTemporal("IvaMoratorios") = 0
                            drTemporal("SaldoTotal") = nPagosIniciales
                            dtTemporal.Rows.Add(drTemporal)
                        End If

                    End If

                Next

                ' Genero el DataRowCollection drUdis ya que necesito enviarlo como argumento a la función CalcMora que calcula los moratorios
                ' ya que ésta lo envía a su vez a la función CalcIvaU

                drUdis = dsAgil.Tables("Udis").Rows

                For Each drFactura In dsAgil.Tables("Facturas").Rows

                    cTipar = drFactura("Tipar")
                    cTipo = drFactura("Tipo")
                    nFactura = drFactura("Factura")
                    nSaldo = drFactura("Saldo")
                    nDiasMoratorios = 0
                    nTasaMoratoria = drFactura("TasaMoratoria")
                    nMoratorios = 0
                    nIvaMoratorios = 0
                    cFeven = drFactura("Feven")
                    cFepag = drFactura("Fepag")

                    If Trim(cFepag) = "" Then
                        nDiasMoratorios = DateDiff(DateInterval.Day, CTOD(cFeven), CTOD(cFecha))
                    Else
                        If cFeven >= cFepag Then
                            nDiasMoratorios = DateDiff(DateInterval.Day, CTOD(cFeven), CTOD(cFecha))
                        Else
                            nDiasMoratorios = DateDiff(DateInterval.Day, CTOD(cFepag), CTOD(cFecha))
                        End If
                    End If
                    If nDiasMoratorios < 0 Then
                        nDiasMoratorios = 0
                    End If

                    If nDiasMoratorios > 0 Then
                        CalcMora(cTipar, cTipo, cFecha, drUdis, nSaldo, nTasaMoratoria, nDiasMoratorios, nMoratorios, nIvaMoratorios, nTasaIVACliente)
                    End If

                    nSaldoTotal = Round(nSaldo + nMoratorios + nIvaMoratorios, 2)

                    ' Insertar un registro en la tabla dtTemporal

                    drTemporal = dtTemporal.NewRow()
                    drTemporal("Concepto") = "Renta"
                    drTemporal("Contrato") = Mid(drFactura("Anexo"), 1, 5) & "/" & Mid(drFactura("Anexo"), 6, 4)
                    drTemporal("Letra") = drFactura("Letra")
                    drTemporal("Aviso") = nFactura
                    If Trim(drFactura("Feven")) <> "" Then
                        drTemporal("Vencimiento") = drFactura("Feven")
                    Else
                        drTemporal("Vencimiento") = "        "
                    End If
                    If Trim(drFactura("Fepag")) <> "" Then
                        drTemporal("UltimoPago") = drFactura("Fepag")
                    Else
                        drTemporal("UltimoPago") = "        "
                    End If
                    drTemporal("DiasMoratorios") = nDiasMoratorios
                    drTemporal("Saldo") = nSaldo
                    drTemporal("Moratorios") = nMoratorios
                    drTemporal("IvaMoratorios") = nIvaMoratorios
                    drTemporal("SaldoTotal") = nSaldoTotal
                    dtTemporal.Rows.Add(drTemporal)

                Next

                ' Por último, tengo que determinar cuáles contratos del cliente seleccionado tienen
                ' adeudo de la Opción de Compra

                drOpciones = dsAgil.Tables("Opciones").Rows

                For Each drOpcion In drOpciones

                    dTermina = Termina(CTOD(drOpcion("Fvenc")), drOpcion("Plazo"))
                    cTermina = DTOC(dTermina)

                    If cTermina > cFecha Then
                        nDiasMoratorios = 0
                    Else
                        nDiasMoratorios = DateDiff(DateInterval.Day, dTermina, CTOD(cFecha))
                    End If

                    ' Insertar un registro en la tabla dtTemporal

                    drTemporal = dtTemporal.NewRow()
                    drTemporal("Concepto") = "Opción de Compra"
                    drTemporal("Contrato") = Mid(drOpcion("Anexo"), 1, 5) & "/" & Mid(drOpcion("Anexo"), 6, 4)
                    drTemporal("Letra") = Stuff(drOpcion("Letra"), "I", "0", 3)
                    drTemporal("Aviso") = 0
                    drTemporal("Vencimiento") = cTermina
                    drTemporal("UltimoPago") = "        "
                    drTemporal("DiasMoratorios") = nDiasMoratorios
                    drTemporal("Saldo") = drOpcion("Saldo")
                    drTemporal("Moratorios") = 0
                    drTemporal("IvaMoratorios") = 0
                    drTemporal("SaldoTotal") = drOpcion("Saldo")
                    dtTemporal.Rows.Add(drTemporal)

                Next

            End If

            ' Aquí ya tengo todos los adeudos del cliente en la tabla dtTemporal por lo que procedo
            ' a ordenarla

            dvTemporal = New DataView(dtTemporal)
            dvTemporal = dtTemporal.DefaultView
            dvTemporal.Sort = "Vencimiento, Contrato, Aviso DESC"
            DataGrid1.DataSource = dtTemporal

            nCounter = dtTemporal.Rows.Count()

            For i = 0 To nCounter - 1
                drTemporal = dtAdeudos.NewRow()
                drTemporal("Concepto") = DataGrid1.Item(i, 0)
                drTemporal("Contrato") = DataGrid1.Item(i, 1)
                drTemporal("Letra") = DataGrid1.Item(i, 2)
                drTemporal("Aviso") = DataGrid1.Item(i, 3)
                drTemporal("Vencimiento") = DataGrid1.Item(i, 4)
                drTemporal("UltimoPago") = DataGrid1.Item(i, 5)
                drTemporal("DiasMoratorios") = DataGrid1.Item(i, 6)
                drTemporal("Saldo") = DataGrid1.Item(i, 7)
                drTemporal("Moratorios") = DataGrid1.Item(i, 8)
                drTemporal("IvaMoratorios") = DataGrid1.Item(i, 9)
                drTemporal("SaldoTotal") = DataGrid1.Item(i, 10)
                dtAdeudos.Rows.Add(drTemporal)
            Next


            dsAgil.Tables.Remove("Facturas")
            dsAgil.Tables.Remove("Anexos")
            dsAgil.Tables.Remove("PagosIniciales")
            dsAgil.Tables.Remove("Udis")
            dsAgil.Tables.Remove("Opciones")

            dsAgil.Tables.Add(dtAdeudos)

            ' Descomentar la siguiente línea en caso de que deseara modificarse el reporte rptFacSaldo
            ' dsAgil.WriteXml("C:\Schema7.xml", XmlWriteMode.WriteSchema)

            cReportTitle = Trim(cNombreCliente)
            cReportComments = "ESTADO DE CUENTA AL " & Mes(cFecha)
            newrptFacSaldo.SetDataSource(dsAgil)
            newrptFacSaldo.SummaryInfo.ReportTitle = cReportTitle
            newrptFacSaldo.SummaryInfo.ReportComments = cReportComments
            CrystalReportViewer1.ReportSource = newrptFacSaldo

        End If

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()
        cm3.Dispose()
        cm4.Dispose()
        cm5.Dispose()
        cm6.Dispose()

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class
