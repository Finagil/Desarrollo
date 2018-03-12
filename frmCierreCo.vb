Option Explicit On

Imports System.Data.SqlClient
Imports System.Math

Public Class frmCierreCo

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
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnProcesar = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnProcesar
        '
        Me.btnProcesar.Location = New System.Drawing.Point(306, 14)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(80, 24)
        Me.btnProcesar.TabIndex = 17
        Me.btnProcesar.Text = "Procesar"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(90, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 16)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Fecha de Proceso:"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(200, 16)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(88, 20)
        Me.DateTimePicker1.TabIndex = 15
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ProgressBar1)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 64)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(488, 128)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Realizando Proceso de Cierre de Mes"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(16, 61)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(456, 16)
        Me.ProgressBar1.TabIndex = 19
        '
        'frmCierreCo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(504, 206)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnProcesar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Name = "frmCierreCo"
        Me.Text = "Proceso de Cierre de mes"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Structure Movimiento
        Public Cve As String
        Public Anexo As String
        Public Cliente As String
        Public Imp As Decimal
        Public Tipar As String
        Public Coa As String
        Public Fecha As String
        Public Tipmov As String
        Public Banco As String
        Public Concepto As String
        Public Segmento As String
    End Structure

    Private Structure Provinte
        Public Tipar As String
        Public Anexo As String
        Public Saldo As Decimal
        Public Tasa As Decimal
        Public Difer As Decimal
        Public DiasProv As Integer
        Public Importe As Decimal
        Public FechaIni As String
        Public FechaFin As String
    End Structure

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cn As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim cm4 As New SqlCommand()
        Dim cm5 As New SqlCommand()
        Dim cm6 As New SqlCommand()
        Dim cm7 As New SqlCommand()
        Dim cm8 As New SqlCommand()
        Dim cm9 As New SqlCommand()
        Dim dsAgil As New DataSet()
        Dim daFechaAltas As New SqlDataAdapter(cm1)
        Dim daFechaTraspasos As New SqlDataAdapter(cm2)
        Dim daFechaSeguros As New SqlDataAdapter(cm3)
        Dim daCatalogo As New SqlDataAdapter(cm4)
        Dim daFechaProgramada As New SqlDataAdapter(cm5)
        Dim daFechaEgresos As New SqlDataAdapter(cm6)
        Dim daClientes As New SqlDataAdapter(cm7)
        Dim daInterfase As New SqlDataAdapter(cm8)
        Dim drFecha As DataRow
        Dim drCatalogo As DataRow
        Dim aPKCatalogo(0) As DataColumn
        Dim aPKClientes(0) As DataColumn
        Dim aPKInterfase(1) As DataColumn
        Dim strInsert As String
        Dim strDelete As String

        ' Declaración de variables de datos

        Dim cConcepto As String
        Dim cFecha As String
        Dim cFechaEgreso As String = ""
        Dim dIngreso As Date
        Dim i As Byte
        Dim nPoliza As Integer = 0
        Dim nPolOrden As Integer = 0
        Dim sFecha As String = ""
        Dim sFechaAlta As String = ""
        Dim sFechaTraspaso As String = ""
        Dim sFechaSeguros As String = ""
        Dim sFechaProgramada As String = ""

        btnProcesar.Enabled = False
        DateTimePicker1.Enabled = False

        cFecha = DTOC(DateTimePicker1.Value)

        ' La diferencia entre el valor máximo y el valor mínimo del ProgressBar es el número de procesos
        ' que se realizan en el proceso de cierre de mes

        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = 7
        ProgressBar1.Step = 1
        ProgressBar1.PerformStep()
        ProgressBar1.Update()

        cn.Open()
        strDelete = "TRUNCATE TABLE Auxiliar"
        cm9 = New SqlClient.SqlCommand(strDelete, cn)
        cm9.ExecuteNonQuery()

        strDelete = "TRUNCATE TABLE Provinte"
        cm9 = New SqlClient.SqlCommand(strDelete, cn)
        cm9.ExecuteNonQuery()
        cn.Close()

        Aplicobr(cFecha)                ' Tipmov = 01 Genera las pólizas de cobranza PI
        ProgressBar1.PerformStep()
        ProgressBar1.Update()

        AltaOper(cFecha)                ' Tipmov = 12, 02, 03, 04, 05 y 06 Genera las pólizas PD3, PD4, PD5, PD6, PD7 y PD8
        ProgressBar1.PerformStep()
        ProgressBar1.Update()

        Cobrosxa(cFecha)                ' Tipmov = 07 Genera la póliza PD9
        ProgressBar1.PerformStep()
        ProgressBar1.Update()

        GeneProv(cFecha)                ' Tipmov = 08 Genera la póliza PD10
        ProgressBar1.PerformStep()
        ProgressBar1.Update()

        ProvAvio(cFecha, "FINAGIL")     ' Tipmov = 14 Genera la póliza PD12
        ProgressBar1.PerformStep()
        ProgressBar1.Update()

        Traspasos(cFecha)               ' Tipmov = 09 Genera de la póliza PD14 en adelante
        ProgressBar1.PerformStep()
        ProgressBar1.Update()

        Seguros(cFecha)                 ' Tipmov = 10 Genera de la póliza PD51 en adelante
        ProgressBar1.PerformStep()
        ProgressBar1.Update()

        '' Tipmov = 13 Genera la póliza PD198 Provisión de intereses pasivos con FIRA
        '' Tipmov = 16 Genera la póliza PD199 Financiamiento Adicional otorgado por FIRA
        '' Tipmov = 17 Genera la póliza PD200 Intereses Pasivos pagados a FIRA

        ''CierreFIRA(cFecha)

        ' Tipmov = 11 Genera de la póliza PD201 en adelante

        FondeoFIRA(cFecha)

        ' Tipmov = 18 Genera de la póliza PD301 en adelante

        EgresosFIRA(cFecha)

        ' Este Command trae los diferentes días que existen para Alta de Operaciones

        With cm1
            .CommandType = CommandType.Text
            .CommandText = "SELECT DISTINCT Fecha FROM Auxiliar " & _
                           "WHERE Tipmov IN ('02','03','04','05','06','12') AND LEFT(Fecha,6) = '" & Mid(cFecha, 1, 6) & "' " & _
                           "ORDER BY Fecha"
            .Connection = cn
        End With

        ' Este Stored Procedure trae los diferentes días que existen para Traspasos de Cartera (TipMov = 09)

        With cm2
            .CommandType = CommandType.StoredProcedure
            .CommandText = "CierreCo1"
            .Connection = cn
            .Parameters.Add("@Fecha", SqlDbType.NVarChar)
            .Parameters.Add("@TipMov", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
            .Parameters(1).Value = "09"
        End With

        ' Este Stored Procedure trae los diferentes días que existen para Seguros Financiados (TipMov = 10)

        With cm3
            .CommandType = CommandType.StoredProcedure
            .CommandText = "CierreCo2"
            .Connection = cn
            .Parameters.Add("@Fecha", SqlDbType.NVarChar)
            .Parameters.Add("@TipMov", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
            .Parameters(1).Value = "10"
        End With

        ' Este Stored Procedure trae todas las cuentas del Catálogo de Cuentas

        With cm4
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Catalogo1"
            .Connection = cn
        End With

        ' El siguiente comando trae los diferentes días que existen para ministraciones FIRA - FINAGIL (TipMov = 11)

        With cm5
            .CommandType = CommandType.Text
            .CommandText = "SELECT FechaFinal AS FechaMinistracion FROM DetalleFIRA " & _
                           "WHERE LEFT(FechaFinal,6) = '" & Mid(cFecha, 1, 6) & "' AND MinistracionBase > 0 " & _
                           "GROUP BY FechaFinal " & _
                           "ORDER BY FechaFinal"
            .Connection = cn
        End With

        ' El siguiente comando trae los diferentes días que existen para egresos FINAGIL - FIRA (TipMov = 18)

        With cm6
            .CommandType = CommandType.Text
            .CommandText = "SELECT DISTINCT FechaEgreso FROM Egresos " & _
                           "WHERE LEFT(FechaEgreso,6) = '" & Mid(cFecha, 1, 6) & "' " & _
                           "ORDER BY FechaEgreso"
            .Connection = cn
        End With

        ' Aunque sea una tabla muy grande voy a generarla una vez para sobre ésta buscar el contrato y traerme el nombre del cliente

        With cm7
            .CommandType = CommandType.Text
            .CommandText = "SELECT DISTINCT Anexo, Tipeq, Descr, Tipo, Segmento_Negocio FROM Anexos " & _
                           "INNER JOIN Clientes ON Anexos.Cliente = Clientes.Cliente " & _
                           "INNER JOIN Sucursales ON Clientes.Sucursal = Sucursales.ID_Sucursal " & _
                           "UNION ALL " & _
                           "SELECT DISTINCT Anexo, '9' AS Tipeq, Descr, Tipo, Segmento_Negocio FROM Avios " & _
                           "INNER JOIN Clientes ON Avios.Cliente = Clientes.Cliente " & _
                           "INNER JOIN Sucursales ON Clientes.Sucursal = Sucursales.ID_Sucursal " & _
                           "ORDER BY Anexo"
            .Connection = cn
        End With

        With cm8
            .CommandType = CommandType.Text
            .CommandText = "SELECT * FROM CataMovi"
            .Connection = cn
        End With

        ' Llenar el DataSet a través del DataAdapter, lo cual abre y cierra la conexión

        daFechaAltas.Fill(dsAgil, "FechaAltas")                 ' Alta de operaciones
        daFechaTraspasos.Fill(dsAgil, "FechaTraspasos")         ' Traspasos de Cartera
        daFechaSeguros.Fill(dsAgil, "FechaSeguros")             ' Seguros Financiados
        daFechaProgramada.Fill(dsAgil, "FechaProgramada")       ' Fondeo FIRA
        daFechaEgresos.Fill(dsAgil, "FechaEgresos")             ' Pagos a FIRA
        daCatalogo.Fill(dsAgil, "Catalogo")                     ' Catálogo de Cuentas Contables
        daClientes.Fill(dsAgil, "Clientes")                     ' Tabla de Clientes
        daInterfase.Fill(dsAgil, "Interfase")                   ' Tabla de Interfase Contable

        ' Ahora defino la llave primaria de la tabla Catalogo para poder buscar una cuenta en particular

        aPKCatalogo(0) = dsAgil.Tables("Catalogo").Columns("Acc")
        dsAgil.Tables("Catalogo").PrimaryKey = aPKCatalogo

        ' También tengo que definir la llave primaria de la tabla Clientes para poder buscar el Tipo y el Nombre del cliente de un contrato en particular

        aPKClientes(0) = dsAgil.Tables("Clientes").Columns("Anexo")
        dsAgil.Tables("Clientes").PrimaryKey = aPKClientes

        ' Definir una LLAVE PRIMARIA COMPUESTA para la tabla Interfase (Catalogo + Clave) para encontrar una Clave en particular y su correspondiente Cuenta Contable

        aPKInterfase(0) = dsAgil.Tables("Interfase").Columns("Catalogo")
        aPKInterfase(1) = dsAgil.Tables("Interfase").Columns("Clave")
        dsAgil.Tables("Interfase").PrimaryKey = aPKInterfase

        ' Aquí comienza la generación de las pólizas contables

        nPoliza = 401

        For Each drFecha In dsAgil.Tables("FechaAltas").Rows

            sFechaAlta = drFecha("Fecha")

            cConcepto = "ALTA DE OPERACIONES DE BIENES AL COMERCIO                                                           "
            GeneraPoliza("02", cConcepto, sFechaAlta, nPoliza, dsAgil)

            cConcepto = "ALTA DE OPERACIONES DE BIENES AL CONSUMO                                                            "
            GeneraPoliza("03", cConcepto, sFechaAlta, nPoliza, dsAgil)

            cConcepto = "ALTA DE OPERACIONES ARRENDAMIENTO PURO                                                              "
            GeneraPoliza("04", cConcepto, sFechaAlta, nPoliza, dsAgil)

            cConcepto = "ALTA DE CREDITOS REFACCIONARIOS                                                                     "
            GeneraPoliza("05", cConcepto, sFechaAlta, nPoliza, dsAgil)

            cConcepto = "ALTA DE CREDITOS SIMPLES                                                                            "
            GeneraPoliza("06", cConcepto, sFechaAlta, nPoliza, dsAgil)

            cConcepto = "ALTA DE CREDITOS DE AVIO Y CUENTA CORRIENTE                                                         "
            GeneraPoliza("12", cConcepto, sFechaAlta, nPoliza, dsAgil)

        Next

        nPoliza = 9
        cConcepto = "APLICACION DE SALDOS A FAVOR                                                                        "
        GeneraPoliza("07", cConcepto, cFecha, nPoliza, dsAgil)

        nPoliza = 10
        cConcepto = "PROVISION DE INTERESES ACTIVOS                                                                      "
        GeneraPoliza("08", cConcepto, cFecha, nPoliza, dsAgil)

        nPoliza = 14
        cConcepto = "TRASPASOS DE CARTERA                                                                                "
        For Each drFecha In dsAgil.Tables("FechaTraspasos").Rows
            sFechaTraspaso = drFecha("Fecha")
            GeneraPoliza("09", cConcepto, sFechaTraspaso, nPoliza, dsAgil)
        Next

        cConcepto = "SEGUROS FINANCIADOS                                                                                 "
        nPoliza = 51
        For Each drFecha In dsAgil.Tables("FechaSeguros").Rows
            sFechaSeguros = drFecha("Fecha")
            GeneraPoliza("10", cConcepto, sFechaSeguros, nPoliza, dsAgil)
        Next

        'cConcepto = "PROVISION DE INTERESES PASIVOS CON FIRA                                                             "
        'nPoliza = 198
        'GeneraPoliza("13", cConcepto, cFecha, nPoliza, nPolOrden, dsAgil)

        cConcepto = "PROVISION DE INTERESES ACTIVOS (AVIO)                                                               "
        nPoliza = 12
        GeneraPoliza("14", cConcepto, cFecha, nPoliza, dsAgil)

        ''cConcepto = "PROVISION DE INTERESES ACTIVOS (GARANTIA LIQUIDA AVIO)                                              "
        ''nPoliza = 13
        ''GeneraPoliza("15", cConcepto, cFecha, nPoliza, nPolOrden, dsAgil)

        ''cConcepto = "FINANCIAMIENTO ADICIONAL OTORGADO POR FIRA                                                          "
        ''nPoliza = 199
        ''GeneraPoliza("16", cConcepto, cFecha, nPoliza, nPolOrden, dsAgil)

        ''cConcepto = "INTERESES PASIVOS PAGADOS A FIRA                                                                    "
        ''nPoliza = 200
        ''GeneraPoliza("17", cConcepto, cFecha, nPoliza, nPolOrden, dsAgil)

        cConcepto = "FONDEO FIRA                                                                                         "
        nPoliza = 201
        For Each drFecha In dsAgil.Tables("FechaProgramada").Rows
            sFechaProgramada = drFecha("FechaMinistracion")
            GeneraPoliza("11", cConcepto, sFechaProgramada, nPoliza, dsAgil)
        Next

        cConcepto = "PAGOS A FIRA                                                                                        "
        nPoliza = 301
        For Each drFecha In dsAgil.Tables("FechaEgresos").Rows
            cFechaEgreso = drFecha("FechaEgreso")
            GeneraPoliza("18", cConcepto, cFechaEgreso, nPoliza, dsAgil)
        Next

        cConcepto = "INGRESOS                                                                                            "
        nPoliza = 1
        For i = 1 To 31
            dIngreso = DateSerial(Val(Mid(cFecha, 1, 4)), Val(Mid(cFecha, 5, 2)), i)
            sFecha = DTOC(dIngreso)
            GeneraPoliza("01", cConcepto, sFecha, nPoliza, dsAgil)
            nPoliza = nPoliza + 1
        Next

        ' Al llegar a este punto, ya debieron darse de alta todas las cuentas en la tabla Catalogo, por lo que
        ' lo único que resta es actualizar dicha tabla en la Base de Datos.

        cn.Open()
        For Each drCatalogo In dsAgil.Tables("Catalogo").Rows
            If drCatalogo.RowState = DataRowState.Added Then
                strInsert = "INSERT INTO Catalogo(Id, Acc, AccName, OtherName, AccAditive, AccType, AccStatus, ClaveFinan, AccFlow, StatusDate, AccSource, AccCoin, Agrupador, IdSegNeg, SegNegMovto, Alta)"
                strInsert = strInsert & " VALUES ('"
                strInsert = strInsert & "C  " & "', '"
                strInsert = strInsert & drCatalogo("Acc") & "', '"
                strInsert = strInsert & drCatalogo("AccName") & "', '"
                strInsert = strInsert & Space(51) & "', '"
                strInsert = strInsert & drCatalogo("AccAditive") & "', '"
                strInsert = strInsert & drCatalogo("AccType") & "', '"
                strInsert = strInsert & "0 " & "', '"
                strInsert = strInsert & "2 " & "', '"
                strInsert = strInsert & "0 " & "', '"
                strInsert = strInsert & drCatalogo("StatusDate") & "', '"
                strInsert = strInsert & "11 " & "', '"
                strInsert = strInsert & "   1 " & "', '"
                strInsert = strInsert & "   0 " & "', '"
                strInsert = strInsert & "0    " & "', '"
                strInsert = strInsert & "1 " & "', '"
                strInsert = strInsert & "N"
                strInsert = strInsert & "')"
                cm1 = New SqlCommand(strInsert, cn)
                cm1.ExecuteNonQuery()
            End If
        Next
        cn.Close()
        cn.Dispose()
        cm1.Dispose()
        cm2.Dispose()
        cm3.Dispose()
        cm4.Dispose()
        cm5.Dispose()
        cm6.Dispose()
        cm7.Dispose()
        cm8.Dispose()
        cm9.Dispose()

        MsgBox("Cierre de mes Terminado", MsgBoxStyle.OkOnly, "Mensaje")

    End Sub

    Private Sub Aplicobr(ByVal cFecha As String)

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daHisgin As New SqlDataAdapter(cm1)
        Dim dsAgil As New DataSet()
        Dim drRegistro As DataRow
        Dim strInsert As String

        ' Declaración de variables de datos

        Dim cTipmov As String = "01"

        ' Este Stored Procedure trae todos los registros de Hisgin que sean del mes
        ' del cual se está haciendo el cierre

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Aplicobr1"
            .Connection = cnAgil
            .Parameters.Add("@FechaFin", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        ' Llenar el DataSet a través del DataAdapter, lo cual abre y cierra la conexión

        daHisgin.Fill(dsAgil, "Hisgin")

        cnAgil.Open()
        For Each drRegistro In dsAgil.Tables("Hisgin").Rows
            If drRegistro("Imp") <> 0 Then
                strInsert = "INSERT INTO Auxiliar(Cve, Anexo, Imp, Tipar, Coa, Fecha, Tipmov, Banco, Concepto, Segmento)"
                strInsert = strInsert & " VALUES ('"
                strInsert = strInsert & drRegistro("Cve") & "', '"
                strInsert = strInsert & drRegistro("Anexo") & "', '"
                strInsert = strInsert & drRegistro("Imp") & "', '"
                strInsert = strInsert & drRegistro("Catal") & "', '"
                strInsert = strInsert & drRegistro("Coa") & "', '"
                strInsert = strInsert & drRegistro("Fepag") & "', '"
                strInsert = strInsert & cTipmov & "', '"
                strInsert = strInsert & drRegistro("Banco") & "', '"
                strInsert = strInsert & drRegistro("Concepto") & "', ''"
                strInsert = strInsert & ")"
                cm1 = New SqlCommand(strInsert, cnAgil)
                cm1.ExecuteNonQuery()
            End If
        Next
        cnAgil.Close()

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub AltaOper(ByVal cFecha As String)

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim daAnexos As New SqlDataAdapter(cm1)
        Dim daEdoctav As New SqlDataAdapter(cm2)
        Dim daFINAGIL As New SqlDataAdapter(cm3)
        Dim dsAgil As New DataSet()
        Dim drAnexo As DataRow
        Dim drDataRow As DataRow
        Dim drAnexos As DataRowCollection
        Dim drMinistracion As DataRow
        Dim drEdoctav As DataRow()
        Dim relAnexosEdoctav As DataRelation
        Dim strInsert As String

        ' Declaración de variables de datos

        Dim aImportes(23) As Decimal
        Dim aMovimiento As New Movimiento()
        Dim aMovimientos As New ArrayList()
        Dim cAnexo As String
        Dim cCliente As String
        Dim cConcepto As String = ""
        Dim cFechacon As String
        Dim cFecha_Pago As String = ""
        Dim cFinse As String
        Dim cFondeo As String
        Dim cForca As String
        Dim cLista1 As String = "060725262802061105191209291335"                    ' Para arrendamiento financiero
        Dim cLista2 As String = "011100111111011"
        Dim cLista3 As String = "38254011424409"                                    ' Para arrendamiento puro
        Dim cLista4 As String = "0101111"
        Dim cLista5 As String = "45462539454741434809"                              ' Para crédito refaccionario
        Dim cLista6 As String = "0110111111"
        Dim cLista7 As String = "55255958636409"                                    ' Para crédito simple
        Dim cLista8 As String = "0110111"
        Dim cLista9 As String = "657555676578777877"                                ' Para crédito de Avío
        Dim cLista10 As String = "010101111"
        Dim cSegmento As String = ""
        Dim cTipar As String = ""
        Dim cTipmov As String
        Dim cTipo As String
        Dim i As Byte
        Dim j As Byte
        Dim lAdelanto As Boolean
        Dim nAmorin As Decimal
        Dim nComision As Decimal
        Dim nDerechos As Decimal
        Dim nEnganche As Decimal
        Dim nGastos As Decimal
        Dim nImpDG As Decimal
        Dim nImpEq As Decimal
        Dim nImpRD As Decimal
        Dim nInteresEquipo As Decimal
        Dim nIva As Decimal
        Dim nIvaAmorin As Decimal
        Dim nIvaComision As Decimal
        Dim nIvaDG As Decimal
        Dim nIvaEq As Decimal
        Dim nIvaGastos As Decimal
        Dim nIvaRD As Decimal
        Dim nMensu As Decimal
        Dim nNafin As Decimal
        Dim nOpcion As Decimal
        Dim nPagosIniciales As Decimal
        Dim nPlazo As Integer
        Dim nPorcentajeIVA As Decimal = 0
        Dim nRD As Byte
        Dim nSaldoEquipo As Decimal = 0
        Dim nSaldoSeguro As Decimal = 0

        ' El siguiente Stored Procedure trae todos los datos de los contratos activos
        ' contratados en un rango de fechas dado.

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "AltaOper1"
            .Connection = cnAgil
            .Parameters.Add("@Fecha", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        ' El siguiente Stored Procedure trae la tabla de amortización de los contratos activos
        ' contratados en un rango de fechas dado; en este caso específico, la fecha inicial
        ' es el día primero del mes para el cual se está realizando el cierre.

        With cm2
            .CommandType = CommandType.StoredProcedure
            .CommandText = "AltaOper2"
            .Connection = cnAgil
            .Parameters.Add("@FechaInicio", SqlDbType.NVarChar)
            .Parameters(0).Value = Mid(cFecha, 1, 6) & "01"
            .Parameters.Add("@FechaFinal", SqlDbType.NVarChar)
            .Parameters(1).Value = cFecha
        End With

        ' El siguiente comando trae todas las ministraciones que cubrió FINAGIL a los productores durante el mes del reporte

        With cm3
            .CommandType = CommandType.Text
            .CommandText = "SELECT DetalleFINAGIL.Anexo, Avios.Cliente, Avios.Tipar, FechaFinal, Importe, Garantia, FEGA, Segmento_Negocio, Concepto FROM DetalleFINAGIL " & _
                           "INNER JOIN Avios ON DetalleFINAGIL.Anexo = Avios.Anexo AND DetalleFINAGIL.Ciclo = Avios.Ciclo " & _
                           "INNER JOIN Clientes ON Avios.Cliente = Clientes.Cliente " & _
                           "INNER JOIN Sucursales ON Clientes.Sucursal = Sucursales.ID_Sucursal " & _
                           "WHERE LEFT(FechaFinal, 6) = " & "'" & Mid(cFecha, 1, 6) & "' AND Concepto NOT IN ('PAGO','INTERESES') " & _
                           "ORDER BY DetalleFINAGIL.Anexo, DetalleFINAGIL.Consecutivo"
            .Connection = cnAgil
        End With

        'Llenar el DataSet a través del DataAdapter, lo cual abre y cierra la conexión

        daAnexos.Fill(dsAgil, "Anexos")
        daEdoctav.Fill(dsAgil, "Edoctav")
        daFINAGIL.Fill(dsAgil, "DetalleFINAGIL")
        Try
        Catch eException As Exception
            MsgBox(eException.Message, MsgBoxStyle.Critical, "AltaOper1.Fill")
        End Try

        relAnexosEdoctav = New DataRelation("AnexosEdoctav", dsAgil.Tables("Anexos").Columns("Anexo"), dsAgil.Tables("Edoctav").Columns("Anexo"))
        dsAgil.EnforceConstraints = False
        dsAgil.Relations.Add(relAnexosEdoctav)
        dsAgil.EnforceConstraints = True
        Try
        Catch eException As Exception
            MsgBox(eException.Message, MsgBoxStyle.Critical, "AltaOper1.Relation")
        End Try

        drAnexos = dsAgil.Tables("Anexos").Rows

        For Each drAnexo In drAnexos

            'Campos que vienen de la tabla Anexos

            nImpDG = 0
            nIvaDG = 0

            cAnexo = drAnexo("Anexo")
            cCliente = drAnexo("Cliente")
            cFinse = drAnexo("Finse")
            cFondeo = drAnexo("Fondeo")
            cTipar = drAnexo("Tipar")
            cFechacon = drAnexo("Fechacon")
            cFecha_Pago = drAnexo("Fecha_Pago")
            cForca = drAnexo("Forca")
            nMensu = drAnexo("Mensu")
            nPlazo = drAnexo("Plazo")
            nImpEq = drAnexo("Impeq")
            nIvaEq = drAnexo("Ivaeq")
            nAmorin = drAnexo("Amorin")
            nIvaAmorin = drAnexo("IvaAmorin")
            nImpRD = drAnexo("ImpRD")
            nIvaRD = drAnexo("IvaRD")
            nRD = drAnexo("RD")
            If nRD > 0 Then
                nImpDG = drAnexo("ImpDG")
                nIvaDG = drAnexo("IvaDG")
            End If
            nGastos = drAnexo("Gastos")
            nIvaGastos = drAnexo("IvaGastos")
            nEnganche = Round(drAnexo("Amorin") + drAnexo("IvaAmorin"), 2)
            nDerechos = drAnexo("Derechos")

            ' Campo que viene de la tabla Clientes

            cTipo = drAnexo("Tipo")

            ' Campo que viene de la tabla Opciones

            nOpcion = drAnexo("Opcion")

            cSegmento = drAnexo("Segmento_Negocio")

            ' Comienza el procesamiento de la información

            cTipmov = "  "
            If cTipar = "F" Then
                If cTipo = "M" Or cTipo = "E" Then
                    cTipmov = "02"          ' Arrendamiento Financiero de Bienes al Comercio
                ElseIf cTipo = "F" Then
                    cTipmov = "03"          ' Arrendamiento Financiero de Bienes al Consumo
                End If
            ElseIf cTipar = "P" Then
                cTipmov = "04"              ' Arrendamiento Puro
            ElseIf cTipar = "R" Then
                cTipmov = "05"              ' Crédito Refaccionario
            ElseIf cTipar = "S" Then
                cTipmov = "06"              ' Crédito Simple
            End If

            If cTipmov <> "  " Then

                nIva = TraeIVA(cFechacon)

                nComision = Round(drAnexo("Comis") / (1 + (nIva / 100)), 2)
                nIvaComision = drAnexo("Comis") - nComision

                nSaldoEquipo = Round(nImpEq - nIvaEq - nAmorin, 2)

                ' Para calcular el interés del equipo debe revisar que no se hayan
                ' realizado adelantos a capital antes del primer vencimiento.   Si
                ' este fuera el caso, entonces los intereses deben ser calculados
                ' en vez de sumarizados

                lAdelanto = False
                nInteresEquipo = 0

                drEdoctav = drAnexo.GetChildRows("AnexosEdoctav")

                For Each drDataRow In drEdoctav
                    nInteresEquipo = Round(nInteresEquipo + drDataRow("Inter"), 2)
                    If drDataRow("Nufac") = 9999999 Then
                        lAdelanto = True
                    End If
                Next

                If lAdelanto = True And (cForca = "1" Or cForca = "4") Then
                    nInteresEquipo = (nMensu * nPlazo) - (nImpEq - nIvaEq - nAmorin)
                End If

                ' El saldo del seguro será siempre cero ya que se tomó la determinación
                ' de que todos los seguros financiados se carguen posteriormente a 
                ' la activación.

                nSaldoSeguro = 0

                If cFondeo = "02" Then
                    nNafin = Round((nSaldoEquipo + nSaldoSeguro) * 5 / 100, 2)
                Else
                    nNafin = 0
                End If

                If cTipar = "F" Then

                    nPagosIniciales = Round(nAmorin + nIvaAmorin + nImpRD + nIvaRD + nComision + nIvaComision + nGastos + nIvaGastos + nNafin + nImpDG + nIvaDG, 2)

                    aImportes(0) = Round(nSaldoEquipo + nInteresEquipo + nAmorin, 2)
                    aImportes(1) = Round(nInteresEquipo, 2)
                    aImportes(2) = Round(nSaldoEquipo + nAmorin, 2)
                    aImportes(3) = Round(nSaldoSeguro, 2)
                    aImportes(4) = Round(nSaldoSeguro, 2)
                    aImportes(5) = Round(nPagosIniciales, 2)
                    aImportes(6) = Round(nAmorin, 2)
                    aImportes(7) = Round(nImpDG, 2)
                    aImportes(8) = Round(nImpRD, 2)
                    aImportes(9) = Round(nComision, 2)
                    aImportes(10) = Round(nGastos, 2)
                    aImportes(11) = Round(nIvaAmorin + nIvaRD + nIvaComision + nIvaGastos + nIvaDG, 2)
                    aImportes(12) = Round(nAmorin, 2)
                    aImportes(13) = Round(nAmorin, 2)
                    aImportes(14) = Round(nNafin, 2)

                    j = 1
                    For i = 0 To 14
                        If aImportes(i) <> 0 Then
                            With aMovimiento
                                .Anexo = cAnexo
                                .Imp = aImportes(i)
                                .Cve = Mid(cLista1, j, 2)
                                .Tipar = cTipar
                                .Coa = Mid(cLista2, i + 1, 1)
                                .Fecha = cFecha_Pago
                                .Tipmov = cTipmov
                                .Banco = ""
                                .Concepto = ""
                                .Segmento = cSegmento
                            End With
                            aMovimientos.Add(aMovimiento)
                        End If
                        j = j + 2
                    Next

                ElseIf cTipar = "P" Then

                    nPagosIniciales = Round(nImpDG + nIvaDG + nComision + nIvaComision + nGastos + nIvaGastos, 2)

                    aImportes(0) = Round(nImpEq - nIvaEq, 2)
                    aImportes(1) = Round(nImpEq - nIvaEq, 2)
                    aImportes(2) = Round(nPagosIniciales, 2)
                    aImportes(3) = Round(nImpDG, 2)
                    aImportes(4) = Round(nComision, 2)
                    aImportes(5) = Round(nGastos, 2)
                    aImportes(6) = Round(nIvaComision + nIvaGastos + nIvaDG, 2)

                    j = 1
                    For i = 0 To 6
                        If aImportes(i) <> 0 Then
                            With aMovimiento
                                .Anexo = cAnexo
                                .Imp = aImportes(i)
                                .Cve = Mid(cLista3, j, 2)
                                .Tipar = cTipar
                                .Coa = Mid(cLista4, i + 1, 1)
                                .Fecha = cFecha_Pago
                                .Tipmov = cTipmov
                                .Banco = ""
                                .Concepto = ""
                                .Segmento = cSegmento
                            End With
                            aMovimientos.Add(aMovimiento)
                        End If
                        j = j + 2
                    Next

                ElseIf cTipar = "R" Then

                    nPagosIniciales = Round(nEnganche + nImpRD + nIvaRD + nComision + nIvaComision + nGastos + nIvaGastos + nDerechos, 2)

                    aImportes(0) = Round(nSaldoEquipo + nInteresEquipo + nEnganche, 2)
                    aImportes(1) = Round(nInteresEquipo, 2)
                    aImportes(2) = Round(nSaldoEquipo + nEnganche, 2)
                    aImportes(3) = Round(nPagosIniciales, 2)
                    aImportes(4) = Round(nEnganche, 2)
                    aImportes(5) = Round(nImpRD, 2)
                    aImportes(6) = Round(nComision, 2)
                    aImportes(7) = Round(nGastos, 2)
                    aImportes(8) = Round(nDerechos, 2)
                    aImportes(9) = Round(nIvaRD + nIvaComision + nIvaGastos, 2)

                    j = 1
                    For i = 0 To 9
                        If aImportes(i) <> 0 Then
                            With aMovimiento
                                .Anexo = cAnexo
                                .Imp = aImportes(i)
                                .Cve = Mid(cLista5, j, 2)
                                .Tipar = cTipar
                                .Coa = Mid(cLista6, i + 1, 1)
                                .Fecha = cFecha_Pago
                                .Tipmov = cTipmov
                                .Banco = ""
                                .Concepto = ""
                                .Segmento = cSegmento
                            End With
                            aMovimientos.Add(aMovimiento)
                        End If
                        j = j + 2
                    Next

                ElseIf cTipar = "S" Then

                    nPagosIniciales = Round(nComision + nIvaComision + nGastos + nIvaGastos, 2)

                    aImportes(0) = Round(nSaldoEquipo + nInteresEquipo, 2)
                    aImportes(1) = Round(nSaldoEquipo, 2)
                    aImportes(2) = Round(nInteresEquipo, 2)
                    aImportes(3) = Round(nPagosIniciales, 2)
                    aImportes(4) = Round(nComision, 2)
                    aImportes(5) = Round(nGastos, 2)
                    aImportes(6) = Round(nIvaComision + nIvaGastos, 2)

                    j = 1
                    For i = 0 To 6
                        If aImportes(i) <> 0 Then
                            With aMovimiento
                                .Anexo = cAnexo
                                .Imp = aImportes(i)
                                .Cve = Mid(cLista7, j, 2)
                                .Tipar = cTipar
                                .Coa = Mid(cLista8, i + 1, 1)
                                .Fecha = cFecha_Pago
                                .Tipmov = cTipmov
                                .Banco = ""
                                .Concepto = ""
                                .Segmento = cSegmento
                            End With
                            aMovimientos.Add(aMovimiento)
                        End If
                        j = j + 2
                    Next

                End If

            End If

        Next

        ' Aquí se procesa la parte correspondiente a los créditos de Avío

        cTipmov = "12"          ' Registro de ministraciones FINAGIL - Productor

        For Each drMinistracion In dsAgil.Tables("DetalleFINAGIL").Rows

            cAnexo = drMinistracion("Anexo")
            cCliente = drMinistracion("Cliente")
            cSegmento = drMinistracion("Segmento_Negocio")
            cConcepto = RTrim(drMinistracion("Concepto"))
            cFecha = drMinistracion("FechaFinal")
            cTipar = drMinistracion("Tipar")

            If cTipar <> "C" Then                   ' Esta validación se hace para que los Anticipos se contabilicen como Habilitación y Avío
                cTipar = "H"
            End If

            If cSegmento = "400" Then
                nPorcentajeIVA = 0.11
            Else
                nPorcentajeIVA = 0.16
            End If

            If cConcepto = "NOTARIO" Or cConcepto = "RPP" Or cConcepto = "BURO" Or cConcepto = "GASTOS" Then
                aImportes(0) = drMinistracion("Importe")
                aImportes(1) = 0
                aImportes(2) = drMinistracion("Garantia")
                aImportes(3) = drMinistracion("Garantia")
                aImportes(4) = drMinistracion("FEGA")
                aImportes(5) = Round(drMinistracion("Importe") / (1 + nPorcentajeIVA), 2)
                aImportes(6) = Round(drMinistracion("Importe") / (1 + nPorcentajeIVA) * nPorcentajeIVA, 2)
                aImportes(7) = Round(drMinistracion("FEGA") / (1 + nPorcentajeIVA), 2)
                aImportes(8) = Round(drMinistracion("FEGA") / (1 + nPorcentajeIVA) * nPorcentajeIVA, 2)
            ElseIf cConcepto = "COMISION" Then
                aImportes(0) = drMinistracion("Importe")
                aImportes(1) = 0
                aImportes(2) = drMinistracion("Garantia")
                aImportes(3) = drMinistracion("Garantia")
                aImportes(4) = drMinistracion("FEGA")
                aImportes(5) = drMinistracion("Importe")
                aImportes(6) = 0
                aImportes(7) = Round(drMinistracion("FEGA") / (1 + nPorcentajeIVA), 2)
                aImportes(8) = Round(drMinistracion("FEGA") / (1 + nPorcentajeIVA) * nPorcentajeIVA, 2)
            ElseIf cConcepto = "IVA" Then
                aImportes(0) = drMinistracion("Importe")
                aImportes(1) = 0
                aImportes(2) = drMinistracion("Garantia")
                aImportes(3) = drMinistracion("Garantia")
                aImportes(4) = drMinistracion("FEGA")
                aImportes(5) = 0
                aImportes(6) = drMinistracion("Importe")
                aImportes(7) = Round(drMinistracion("FEGA") / (1 + nPorcentajeIVA), 2)
                aImportes(8) = Round(drMinistracion("FEGA") / (1 + nPorcentajeIVA) * nPorcentajeIVA, 2)
            Else
                aImportes(0) = drMinistracion("Importe")
                aImportes(1) = drMinistracion("Importe")
                aImportes(2) = drMinistracion("Garantia")
                aImportes(3) = drMinistracion("Garantia")
                aImportes(4) = drMinistracion("FEGA")
                aImportes(5) = 0
                aImportes(6) = 0
                aImportes(7) = Round(drMinistracion("FEGA") / (1 + nPorcentajeIVA), 2)
                aImportes(8) = Round(drMinistracion("FEGA") / (1 + nPorcentajeIVA) * nPorcentajeIVA, 2)
            End If

            j = 1
            For i = 0 To 8
                If aImportes(i) <> 0 Then
                    With aMovimiento
                        .Anexo = cAnexo
                        .Cliente = cCliente
                        .Imp = aImportes(i)
                        .Cve = Mid(cLista9, j, 2)
                        .Tipar = cTipar
                        .Coa = Mid(cLista10, i + 1, 1)
                        .Fecha = cFecha
                        .Tipmov = cTipmov
                        .Banco = ""
                        If i = 4 Or i = 7 Or i = 8 Then
                            .Concepto = "FEGA " & cConcepto
                        Else
                            .Concepto = cConcepto
                        End If
                        .Segmento = cSegmento
                    End With
                    aMovimientos.Add(aMovimiento)
                End If
                j = j + 2
            Next

        Next

        cnAgil.Open()

        For Each aMovimiento In aMovimientos
            strInsert = "INSERT INTO Auxiliar(Cve, Anexo, Cliente, Imp, Tipar, Coa, Fecha, Tipmov, Banco, Concepto, Segmento)"
            strInsert = strInsert & " VALUES ('"
            strInsert = strInsert & aMovimiento.Cve & "', '"
            strInsert = strInsert & aMovimiento.Anexo & "', '"
            strInsert = strInsert & aMovimiento.Cliente & "', '"
            strInsert = strInsert & aMovimiento.Imp & "', '"
            strInsert = strInsert & aMovimiento.Tipar & "', '"
            strInsert = strInsert & aMovimiento.Coa & "', '"
            strInsert = strInsert & aMovimiento.Fecha & "', '"
            strInsert = strInsert & aMovimiento.Tipmov & "', '"
            strInsert = strInsert & aMovimiento.Banco & "', '"
            strInsert = strInsert & aMovimiento.Concepto & "', '"
            strInsert = strInsert & aMovimiento.Segmento
            strInsert = strInsert & "')"
            cm1 = New SqlCommand(strInsert, cnAgil)
            cm1.ExecuteNonQuery()
        Next
        Try
        Catch eException As Exception
            MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")
        End Try

        cnAgil.Close()

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()
        cm3.Dispose()

    End Sub

    Private Sub Cobrosxa(ByVal cFecha As String)

        ' Declaración de variables de conexión ADO .NET

        Dim cn As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daCobrosxa As New SqlDataAdapter(cm1)
        Dim dsAgil As New DataSet()
        Dim drRegistro As DataRow
        Dim strInsert As String

        ' Declaración de variables de datos

        Dim aMovimiento As New Movimiento()
        Dim aMovimientos As New ArrayList()
        Dim cAnexo As String
        Dim cLetra As String
        Dim cSegmento As String = ""
        Dim cTipar As String
        Dim cTipmov As String = "07"
        Dim nImporte As Decimal

        ' El siguiente Stored Procedure trae todos los atributos de la tabla Cobrosxa

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Cobrosxa1"
            .Connection = cn
            .Parameters.Add("@FechaFin", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        ' Llenar el DataSet a través del DataAdapter, lo cual abre y cierra la conexión

        daCobrosxa.Fill(dsAgil, "Cobrosxa")

        For Each drRegistro In dsAgil.Tables("Cobrosxa").Rows

            cAnexo = drRegistro("Anexo")
            cLetra = drRegistro("Letra")
            nImporte = drRegistro("Importe")
            cTipar = drRegistro("Tipar")
            cSegmento = drRegistro("Segmento_Negocio")

            If nImporte <> 0 Then

                With aMovimiento
                    .Anexo = cAnexo
                    .Imp = nImporte
                    .Cve = "23"
                    .Tipar = cTipar
                    .Coa = "0"
                    .Fecha = cFecha
                    .Tipmov = cTipmov
                    .Banco = ""
                    .Concepto = ""
                    .Segmento = cSegmento
                End With
                aMovimientos.Add(aMovimiento)

                If cTipar = "F" Then
                    With aMovimiento
                        .Anexo = cAnexo
                        .Imp = nImporte
                        .Cve = "03"
                        .Tipar = cTipar
                        .Coa = "1"
                        .Fecha = cFecha
                        .Tipmov = cTipmov
                        .Banco = ""
                        .Concepto = ""
                        .Segmento = cSegmento
                    End With
                ElseIf cTipar = "P" Then
                    With aMovimiento
                        .Anexo = cAnexo
                        .Imp = nImporte
                        .Cve = "03"
                        .Tipar = cTipar
                        .Coa = "1"
                        .Fecha = cFecha
                        .Tipmov = cTipmov
                        .Banco = ""
                        .Concepto = ""
                        .Segmento = cSegmento
                    End With
                ElseIf cTipar = "R" Then
                    With aMovimiento
                        .Anexo = cAnexo
                        .Imp = nImporte
                        .Cve = "50"
                        .Tipar = cTipar
                        .Coa = "1"
                        .Fecha = cFecha
                        .Tipmov = cTipmov
                        .Banco = ""
                        .Concepto = ""
                        .Segmento = cSegmento
                    End With
                ElseIf cTipar = "S" Then
                    With aMovimiento
                        .Anexo = cAnexo
                        .Imp = nImporte
                        .Cve = "56"
                        .Tipar = cTipar
                        .Coa = "1"
                        .Fecha = cFecha
                        .Tipmov = cTipmov
                        .Banco = ""
                        .Concepto = ""
                        .Segmento = cSegmento
                    End With
                End If

                aMovimientos.Add(aMovimiento)

            End If

        Next

        cn.Open()

        For Each aMovimiento In aMovimientos
            strInsert = "INSERT INTO Auxiliar(Cve, Anexo, Imp, Tipar, Coa, Fecha, Tipmov, Banco, Concepto, Segmento)"
            strInsert = strInsert & " VALUES ('"
            strInsert = strInsert & aMovimiento.Cve & "', '"
            strInsert = strInsert & aMovimiento.Anexo & "', '"
            strInsert = strInsert & aMovimiento.Imp & "', '"
            strInsert = strInsert & aMovimiento.Tipar & "', '"
            strInsert = strInsert & aMovimiento.Coa & "', '"
            strInsert = strInsert & aMovimiento.Fecha & "', '"
            strInsert = strInsert & aMovimiento.Tipmov & "', '"
            strInsert = strInsert & aMovimiento.Banco & "', '"
            strInsert = strInsert & aMovimiento.Concepto & "', '"
            strInsert = strInsert & aMovimiento.Segmento
            strInsert = strInsert & "')"
            cm1 = New SqlCommand(strInsert, cn)
            cm1.ExecuteNonQuery()
        Next

        cn.Close()
        cn.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub GeneProv(ByVal cFecha As String)

        ' Este programa debe tomar los contratos activos de arrendamiento financiero, arrendamiento puro,
        ' crédito refaccionario, crédito simple cuya fecha de contratación sea menor o igual a la fecha de proceso.   
        ' También debe tomar la tabla de amortización del equipo, del seguro y de otros adeudos de todos los
        ' contratos obtenidos con el criterio anterior.   Aunque esto creará un dataset con muchísimos registros,
        ' por otra parte permitirá mantener abierta la conexión únicamente durante el tiempo que tarde en traer
        ' dicha información de la base de datos.

        ' Tratándose de arrendamiento puro, deberá provisionar dias de renta a diferencia de los demás tipos
        ' de crédito o arrendamiento en donde se provisiona dias de intereses.

        ' En el caso de otros adeudos, a partir del mes de julio de 2008

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim cm4 As New SqlCommand()
        Dim cm5 As New SqlCommand()
        Dim daAnexos As New SqlDataAdapter(cm1)
        Dim daEdoctaV As New SqlDataAdapter(cm2)
        Dim daEdoctaS As New SqlDataAdapter(cm3)
        Dim daEdoctaO As New SqlDataAdapter(cm4)
        Dim daHista As New SqlDataAdapter(cm5)
        Dim dsAgil As New DataSet()
        Dim relAnexoEdoctaV As DataRelation
        Dim relAnexoEdoctaS As DataRelation
        Dim relAnexoEdoctaO As DataRelation
        Dim drAnexo As DataRow
        Dim drTemporal As DataRow
        Dim drEdoctaV As DataRow()
        Dim drEdoctaS As DataRow()
        Dim drEdoctaO As DataRow()
        Dim drVencimiento As DataRow
        Dim strInsert As String
        Dim dtTIIE As New DataTable()

        ' Declaración de variables de datos

        Dim aProvinte As New Provinte()
        Dim aProvintes As New ArrayList()
        Dim aMovimiento As New Movimiento()
        Dim aMovimientos As New ArrayList()
        Dim cAcumulaIntereses As String = "NO"
        Dim cAnexo As String = ""
        Dim cCorte As String = ""
        Dim cFechaAnterior As String = ""
        Dim cFechacon As String = ""
        ' Dim cFechaLimite As String = ""
        Dim cFondeo As String = ""
        Dim cForca As String = ""
        Dim cFvenc As String = ""
        Dim cSegmento As String = ""
        Dim cTipar As String = ""
        Dim cTipMov As String = "08"
        Dim cTipta As String = ""
        Dim cVencida As String = ""
        Dim nCarteraEquipo As Decimal = 0
        Dim nCarteraOtros As Decimal = 0
        Dim nCarteraSeguro As Decimal = 0
        Dim nDiasProv As Integer = 0
        Dim nDifer As Decimal = 0
        Dim nImporte As Decimal = 0
        Dim nInteresEquipo As Decimal = 0
        Dim nInteresOtros As Decimal = 0
        Dim nInteresSeguro As Decimal = 0
        Dim nLetra As Byte = 0
        Dim nNufac As Decimal = 0
        Dim nPlazo As Byte = 0
        Dim nSaldoEquipo As Decimal = 0
        Dim nSaldoOtros As Decimal = 0
        Dim nSaldoSeguro As Decimal = 0
        Dim nTasaFact As Decimal = 0
        Dim nTasas As Decimal = 0

        ' La fecha de corte es el mes siguiente al de la fecha de proceso en el formato AAAAMM

        cCorte = Mid(DTOC(DateAdd(DateInterval.Month, 1, CTOD(cFecha))), 1, 6)

        ' Este Stored Procedure trae todos los contratos de arrendamiento financiero, arrendamiento puro,
        ' crédito refaccionario, crédito simple que estén activos y cuya fecha de contratación sea menor
        ' o igual a la de proceso

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "GeneProv1"
            .Connection = cnAgil
            .Parameters.Add("@FechaFin", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        ' Este Stored Procedure trae la tabla de amortización del equipo de todos los contratos de
        ' arrendamiento financiero, arrendamiento puro, crédito refaccionario, crédito simple que estén activos 
        ' y cuya fecha de contratación sea menor o igual a la de proceso

        With cm2
            .CommandType = CommandType.StoredProcedure
            .CommandText = "GeneProv2"
            .Connection = cnAgil
            .Parameters.Add("@FechaFin", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        ' Este Stored Procedure trae la tabla de amortización del seguro de todos los contratos 
        ' de arrendamiento financiero, arrendamiento puro, crédito refaccionario, crédito simple
        ' que estén activos y cuya fecha de contratación sea menor o igual a la de proceso

        With cm3
            .CommandType = CommandType.StoredProcedure
            .CommandText = "GeneProv3"
            .Connection = cnAgil
            .Parameters.Add("@FechaFin", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        ' Este Stored Procedure trae la tabla de amortización de otros adeudos de todos los contratos 
        ' de arrendamiento financiero, arrendamiento puro, crédito refaccionario, crédito simple
        ' que estén activos y cuya fecha de contratación sea menor o igual a la de proceso

        With cm4
            .CommandType = CommandType.StoredProcedure
            .CommandText = "GeneProv4"
            .Connection = cnAgil
            .Parameters.Add("@FechaFin", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        ' Este Stored Procedure trae el valor de todas las tasas, ordenadas por vigencia y por tasa

        With cm5
            .CommandType = CommandType.StoredProcedure
            .CommandText = "GeneProv5"
            .Connection = cnAgil
        End With

        ' Llenar el DataSet a través del DataAdapter, lo cual abre y cierra la conexión

        daAnexos.Fill(dsAgil, "Anexos")
        daEdoctaV.Fill(dsAgil, "EdoctaV")
        daEdoctaS.Fill(dsAgil, "EdoctaS")
        daEdoctaO.Fill(dsAgil, "EdoctaO")
        daHista.Fill(dsAgil, "Hista")

        ' Establecer la relación entre Anexos y Edoctav

        relAnexoEdoctaV = New DataRelation("AnexoEdoctaV", dsAgil.Tables("Anexos").Columns("Anexo"), dsAgil.Tables("EdoctaV").Columns("Anexo"))
        dsAgil.EnforceConstraints = False
        dsAgil.Relations.Add(relAnexoEdoctaV)

        ' Establecer la relación entre Anexos y Edoctas

        relAnexoEdoctaS = New DataRelation("AnexoEdoctaS", dsAgil.Tables("Anexos").Columns("Anexo"), dsAgil.Tables("EdoctaS").Columns("Anexo"))
        dsAgil.EnforceConstraints = False
        dsAgil.Relations.Add(relAnexoEdoctaS)

        ' Establecer la relación entre Anexos y Edoctao

        relAnexoEdoctaO = New DataRelation("AnexoEdoctaO", dsAgil.Tables("Anexos").Columns("Anexo"), dsAgil.Tables("EdoctaO").Columns("Anexo"))
        dsAgil.EnforceConstraints = False
        dsAgil.Relations.Add(relAnexoEdoctaO)

        ' Genero la tabla que contiene las TIIE promedio por mes 
        ' Para FINAGIL considera todos los días del mes y redondea a 4 decimales

        dtTIIE = TIIEavg("FINAGIL")

        For Each drAnexo In dsAgil.Tables("Anexos").Rows

            cAnexo = drAnexo("Anexo")
            cVencida = drAnexo("Vencida")

            If cVencida <> "C" Then

                ' Solamente provisionarán intereses los contratos activos que no estén Castigados

                cTipar = drAnexo("Tipar")
                nPlazo = drAnexo("Plazo")
                cFechacon = drAnexo("Fechacon")
                cFvenc = drAnexo("Fvenc")
                cFondeo = drAnexo("Fondeo")
                cAcumulaIntereses = drAnexo("AcumulaIntereses")
                cTipta = drAnexo("Tipta")
                nTasas = drAnexo("Tasas")
                nDifer = drAnexo("Difer")
                cForca = drAnexo("Forca")
                cSegmento = drAnexo("Segmento_Negocio")

                nSaldoEquipo = 0
                nInteresEquipo = 0
                nCarteraEquipo = 0

                ' Esta instrucción trae la tabla de amortización del Equipo única y exclusivamente del contrato
                ' que está siendo procesado

                drEdoctaV = drAnexo.GetChildRows("AnexoEdoctaV")
                TraeSald(drEdoctaV, cFecha, nSaldoEquipo, nInteresEquipo, nCarteraEquipo)

                nSaldoSeguro = 0
                nInteresSeguro = 0
                nCarteraSeguro = 0

                ' Esta instrucción trae la tabla de amortización del Seguro única y exclusivamente del contrato
                ' que está siendo procesado

                drEdoctaS = drAnexo.GetChildRows("AnexoEdoctaS")
                TraeSald(drEdoctaS, cFecha, nSaldoSeguro, nInteresSeguro, nCarteraSeguro)

                nSaldoOtros = 0
                nInteresOtros = 0
                nCarteraOtros = 0

                ' Esta instrucción trae la tabla de amortización de Otros Adeudos única y exclusivamente del contrato
                ' que está siendo procesado

                drEdoctaO = drAnexo.GetChildRows("AnexoEdoctaO")
                TraeSald(drEdoctaO, cFecha, nSaldoOtros, nInteresOtros, nCarteraOtros)

                nSaldoEquipo = Round(nSaldoEquipo + nSaldoSeguro, 2)

                ' A partir de este momento, la variable nSaldoEquipo incluye tanto el saldo del equipo como el saldo del seguro

                If nSaldoEquipo > 0 Then

                    ' Una vez calculado el saldo insoluto procedo a buscar la fecha del siguiente vencimiento,
                    ' ya que para llegar aquí, el contrato forzosamente debe tener saldo

                    For Each drVencimiento In drEdoctaV
                        If Mid(drVencimiento("Feven"), 1, 6) >= cCorte Then
                            nLetra = Val(drVencimiento("Letra"))
                            Exit For
                        End If
                    Next

                    If nLetra = 1 Then

                        cFechaAnterior = cFechacon

                    Else

                        ' Debo barrer la tabla de amortización del contrato para encontrar la fecha del vencimiento
                        ' anterior, a fin de determinar los días a provisionar

                        For Each drVencimiento In drEdoctaV
                            nNufac = drVencimiento("Nufac")
                            If Val(drVencimiento("Letra")) = (nLetra - 1) And nNufac <> 9999999 And nNufac <> 7777777 And nNufac >= 0 Then
                                cFechaAnterior = drVencimiento("Feven")
                            End If
                        Next

                    End If

                    ' Hasta el cierre de julio 2010, la fecha anterior NO podía ser menor al 1o. del mes que se estaba procesando,
                    ' lo que se traducía en que el número máximo de días que se provisionaba era 28, 29, 30 ó 31 días (los que tuviera
                    ' el mes para el cual se estaba realizando el proceso).

                    ' cFechaLimite = Mid(cFecha, 1, 6) & "01"

                    ' If cFechaAnterior < cFechaLimite Then
                    '     cFechaAnterior = cFechaLimite
                    ' End If

                    If cAcumulaIntereses = "SI" Then

                        nDiasProv = CInt(DateDiff(DateInterval.Day, CTOD(cFechaAnterior), CTOD(cFecha)))

                    Else

                        nDiasProv = CInt(DateDiff(DateInterval.Day, CTOD(cFechaAnterior), CTOD(cFecha))) + 1

                    End If


                    If nDiasProv > 0 Then

                        If cAcumulaIntereses = "SI" Then

                            nInteresEquipo = 0
                            For Each drTemporal In InteresAcumulado(cAnexo, cTipta, "FINAGIL", cFechaAnterior, nSaldoEquipo, nTasas, nDifer, cFecha, dtTIIE, cFecha).Rows
                                nInteresEquipo += drTemporal("Interes")
                            Next
                            nTasaFact = Round(nInteresEquipo / nSaldoEquipo * 36000 / nDiasProv, 4)
                            nInteresOtros = Round(nSaldoOtros * nTasaFact / 36000 * nDiasProv, 2)

                            If cTipta <> "7" Then
                                nTasaFact = nTasaFact - nDifer
                            Else
                                nDifer = 0
                            End If

                        Else

                            nTasaFact = nTasas + nDifer

                            ' Es importante recordar que solamente se calcula la tasa de interés para los vencimientos
                            ' posteriores al primero

                            If nLetra > 1 Then
                                If cTipta <> "7" Then
                                    nTasaFact = 0
                                    TraeTasa(dsAgil.Tables("Hista").Rows, cTipta, cFechaAnterior, nTasaFact, cFechacon)
                                    nTasaFact += nDifer
                                End If
                            End If

                            nInteresEquipo = Round(nSaldoEquipo * nTasaFact / 36000 * nDiasProv, 2)
                            nInteresOtros = Round(nSaldoOtros * nTasaFact / 36000 * nDiasProv, 2)

                            ' A efecto de poder guardar por separado el valor de la tasa y el diferencial, tengo que restarle
                            ' el diferencial a la tasa de facturación aplicada ya que hasta este punto la tasa incluye el diferencial 

                            nTasaFact -= nDifer

                        End If

                        With aProvinte
                            .Tipar = cTipar
                            .Anexo = cAnexo
                            .Saldo = nSaldoEquipo
                            .Tasa = nTasaFact
                            .Difer = nDifer
                            .DiasProv = nDiasProv
                            .Importe = nInteresEquipo
                            .FechaIni = cFechaAnterior
                            .FechaFin = cFecha
                        End With
                        aProvintes.Add(aProvinte)

                        If nInteresOtros > 0 Then
                            With aProvinte
                                .Tipar = "S"
                                .Anexo = cAnexo
                                .Saldo = nSaldoOtros
                                .Tasa = nTasaFact
                                .Difer = nDifer
                                .DiasProv = nDiasProv
                                .Importe = nInteresOtros
                                .FechaIni = cFechaAnterior
                                .FechaFin = cFecha
                            End With
                            aProvintes.Add(aProvinte)
                        End If

                        If cTipar = "F" Then

                            With aMovimiento
                                .Cve = "15"
                                .Anexo = cAnexo
                                .Imp = nInteresEquipo
                                .Tipar = cTipar
                                .Coa = "0"
                                .Fecha = cFecha
                                .Tipmov = cTipMov
                                .Banco = ""
                                .Concepto = ""
                                .Segmento = cSegmento
                            End With
                            aMovimientos.Add(aMovimiento)

                            With aMovimiento
                                .Cve = "14"
                                .Anexo = cAnexo
                                .Imp = nInteresEquipo
                                .Tipar = cTipar
                                .Coa = "1"
                                .Fecha = cFecha
                                .Tipmov = cTipMov
                                .Banco = ""
                                .Concepto = ""
                                .Segmento = cSegmento
                            End With
                            aMovimientos.Add(aMovimiento)

                        ElseIf cTipar = "R" Then

                            With aMovimiento
                                .Cve = "53"
                                .Anexo = cAnexo
                                .Imp = nInteresEquipo
                                .Tipar = cTipar
                                .Coa = "0"
                                .Fecha = cFecha
                                .Tipmov = cTipMov
                                .Banco = ""
                                .Concepto = ""
                                .Segmento = cSegmento
                            End With
                            aMovimientos.Add(aMovimiento)

                            With aMovimiento
                                .Cve = "54"
                                .Anexo = cAnexo
                                .Imp = nInteresEquipo
                                .Tipar = cTipar
                                .Coa = "1"
                                .Fecha = cFecha
                                .Tipmov = cTipMov
                                .Banco = ""
                                .Concepto = ""
                                .Segmento = cSegmento
                            End With
                            aMovimientos.Add(aMovimiento)

                        ElseIf cTipar = "S" Then

                            With aMovimiento
                                .Cve = "57"
                                .Anexo = cAnexo
                                .Imp = nInteresEquipo
                                .Tipar = cTipar
                                .Coa = "0"
                                .Fecha = cFecha
                                .Tipmov = cTipMov
                                .Banco = ""
                                .Concepto = ""
                                .Segmento = cSegmento
                            End With
                            aMovimientos.Add(aMovimiento)

                            With aMovimiento
                                .Cve = "62"
                                .Anexo = cAnexo
                                .Imp = nInteresEquipo
                                .Tipar = cTipar
                                .Coa = "1"
                                .Fecha = cFecha
                                .Tipmov = cTipMov
                                .Banco = ""
                                .Concepto = ""
                                .Segmento = cSegmento
                            End With
                            aMovimientos.Add(aMovimiento)

                        End If

                        ' Si existen otros adeudos, tengo que darle el mismo tratamiento que a un crédito simple

                        If nSaldoOtros > 0 Then

                            With aMovimiento
                                .Cve = "57"
                                .Anexo = cAnexo
                                .Imp = nInteresOtros
                                .Tipar = "S"
                                .Coa = "0"
                                .Fecha = cFecha
                                .Tipmov = cTipMov
                                .Banco = ""
                                .Concepto = ""
                                .Segmento = cSegmento
                            End With
                            aMovimientos.Add(aMovimiento)

                            With aMovimiento
                                .Cve = "62"
                                .Anexo = cAnexo
                                .Imp = nInteresOtros
                                .Tipar = "S"
                                .Coa = "1"
                                .Fecha = cFecha
                                .Tipmov = cTipMov
                                .Banco = ""
                                .Concepto = ""
                                .Segmento = cSegmento
                            End With
                            aMovimientos.Add(aMovimiento)

                        End If

                    End If

                End If

            End If

        Next

        cnAgil.Open()

        For Each aProvinte In aProvintes
            strInsert = "INSERT INTO Provinte(Tipar, Anexo, Saldo, Tasa, Difer, DiasProv, Importe, FechaIni, FechaFin)"
            strInsert = strInsert & " VALUES ('"
            strInsert = strInsert & aProvinte.Tipar & "', '"
            strInsert = strInsert & aProvinte.Anexo & "', '"
            strInsert = strInsert & aProvinte.Saldo & "', '"
            strInsert = strInsert & aProvinte.Tasa & "', '"
            strInsert = strInsert & aProvinte.Difer & "', '"
            strInsert = strInsert & aProvinte.DiasProv & "', '"
            strInsert = strInsert & aProvinte.Importe & "', '"
            strInsert = strInsert & aProvinte.FechaIni & "', '"
            strInsert = strInsert & aProvinte.FechaFin
            strInsert = strInsert & "')"
            cm1 = New SqlCommand(strInsert, cnAgil)
            cm1.ExecuteNonQuery()
        Next

        For Each aMovimiento In aMovimientos
            strInsert = "INSERT INTO Auxiliar(Cve, Anexo, Imp, Tipar, Coa, Fecha, Tipmov, Banco, Concepto, Segmento)"
            strInsert = strInsert & " VALUES ('"
            strInsert = strInsert & aMovimiento.Cve & "', '"
            strInsert = strInsert & aMovimiento.Anexo & "', '"
            strInsert = strInsert & aMovimiento.Imp & "', '"
            strInsert = strInsert & aMovimiento.Tipar & "', '"
            strInsert = strInsert & aMovimiento.Coa & "', '"
            strInsert = strInsert & aMovimiento.Fecha & "', '"
            strInsert = strInsert & aMovimiento.Tipmov & "', '"
            strInsert = strInsert & aMovimiento.Banco & "', '"
            strInsert = strInsert & aMovimiento.Concepto & "', '"
            strInsert = strInsert & aMovimiento.Segmento
            strInsert = strInsert & "')"
            cm1 = New SqlCommand(strInsert, cnAgil)
            cm1.ExecuteNonQuery()
        Next

        cnAgil.Close()

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()
        cm3.Dispose()
        cm4.Dispose()
        cm5.Dispose()

    End Sub

    Private Sub Traspasos(ByVal cFecha As String)

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daFacturas As New SqlDataAdapter(cm1)
        Dim dsAgil As New DataSet()
        Dim drFactura As DataRow
        Dim drFacturas As DataRowCollection
        Dim strInsert As String

        ' Declaración de variables de datos

        Dim aImportes(24) As Decimal
        Dim aMovimiento As New Movimiento()
        Dim aMovimientos As New ArrayList()
        Dim cAnexo As String
        Dim cFeven As String
        Dim cSegmento As String = ""
        Dim cTipar As String
        Dim cTipmov As String = "09"
        Dim i As Byte
        Dim j As Byte
        Dim nBaseFEGA As Decimal = 0
        Dim nBonifica As Decimal = 0
        Dim nCapitalOt As Decimal = 0
        Dim nIvaFEGA As Decimal = 0
        Dim nImporteFac As Decimal = 0
        Dim nImporteFEGA As Decimal = 0
        Dim nInteresOt As Decimal = 0
        Dim nIntPr As Decimal = 0
        Dim nIntSe As Decimal = 0
        Dim nIvaCapital As Decimal = 0
        Dim nIvaOpcion As Decimal = 0
        Dim nIvaOt As Decimal = 0
        Dim nIvaPr As Decimal = 0
        Dim nIvaSe As Decimal = 0
        Dim nLetra As Integer = 0
        Dim nOpcion As Decimal = 0
        Dim nPlazo As Integer = 0
        Dim nRenPr As Decimal = 0
        Dim nRenSe As Decimal = 0
        Dim nSeguroVida As Decimal = 0
        Dim nSumaOtrosAdeudos As Decimal = 0
        Dim nTasaIVA As Decimal = 0
        Dim nVarOt As Decimal = 0
        Dim nVarPr As Decimal = 0
        Dim nVarSe As Decimal = 0

        ' Para Arrendamiento Financiero

        Dim cLista1 As String = "010303050906130709092826293610096156556059097809"
        Dim cLista2 As String = "101001101111001110110111"
        Dim cLista3 As String = "001001101111001100110111"

        ' Para Arrendamiento Puro

        Dim cListaA As String = "037909286009265655780960597809"
        Dim cListaB As String = "01111110110111"

        ' Para Crédito Refaccionario

        Dim cLista4 As String = "49504551460928266156556059097809"
        Dim cLista5 As String = "1011011110110111"
        Dim cLista6 As String = "0011011100110111"

        ' Para Crédito Simple

        Dim cLista7 As String = "61565528266059096156556059097809"
        Dim cLista8 As String = "1011110110110111"
        Dim cLista9 As String = "0011110100110111"

        ' El siguiente Stored Procedure trae todas las facturas del mes para el cual se está haciendo el cierre

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Traspaso1"
            .Connection = cnAgil
            .Parameters.Add("@Fecha", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        'Llenar el DataSet a través del DataAdapter, lo cual abre y cierra la conexión

        daFacturas.Fill(dsAgil, "Facturas")

        drFacturas = dsAgil.Tables("Facturas").Rows

        For Each drFactura In drFacturas

            cAnexo = drFactura("Anexo")
            cTipar = drFactura("Tipar")
            nLetra = CInt(drFactura("Letra"))
            nPlazo = CInt(drFactura("Plazo"))
            cFeven = drFactura("Feven")
            nIntPr = drFactura("IntPr")
            nIntSe = drFactura("IntSe")
            nVarPr = drFactura("VarPr")
            nVarSe = drFactura("VarSe")
            nVarOt = drFactura("VarOt")
            nIvaOt = drFactura("IvaOt")
            nIvaPr = drFactura("IvaPr")
            nIvaSe = drFactura("IvaSe")
            nImporteFac = drFactura("ImporteFac")
            nBonifica = drFactura("Bonifica")
            nRenPr = drFactura("RenPr")
            nIvaCapital = drFactura("IvaCapital")
            nRenSe = drFactura("RenSe")
            nSeguroVida = drFactura("SeguroVida")
            nCapitalOt = drFactura("CapitalOt")
            nInteresOt = drFactura("InteresOt")
            nTasaIVA = drFactura("TasaIVA")
            nImporteFEGA = drFactura("ImporteFEGA")
            nBaseFEGA = Round(nImporteFEGA / (1 + (nTasaIVA / 100)), 2)
            nIvaFEGA = Round(nImporteFEGA - nBaseFEGA, 2)

            If nLetra = nPlazo Then
                nOpcion = drFactura("OC")
                nIvaOpcion = drFactura("IO")
            Else
                nOpcion = 0
                nIvaOpcion = 0
            End If
            cSegmento = drFactura("Segmento_Negocio")

            nSumaOtrosAdeudos = nCapitalOt + nInteresOt + nVarOt + nIvaOt

            If cTipar = "F" Then

                If nVarPr + nIntSe + nVarSe > 0 Then
                    aImportes(0) = nVarPr + nIntSe + nVarSe
                Else
                    aImportes(0) = -(nVarPr + nIntSe + nVarSe)
                End If
                aImportes(1) = nImporteFac + nBonifica - nSumaOtrosAdeudos
                aImportes(2) = nBonifica
                aImportes(3) = nBonifica / 1.15
                aImportes(4) = nBonifica / 1.15 * 0.15
                aImportes(5) = nRenPr
                aImportes(6) = nRenPr
                aImportes(7) = nIntPr
                aImportes(8) = nIvaCapital
                aImportes(9) = nIvaPr + nIvaSe
                aImportes(10) = nRenSe
                aImportes(11) = nSeguroVida
                aImportes(12) = nRenPr - nIntPr
                aImportes(13) = nOpcion + nIvaOpcion
                aImportes(14) = nOpcion
                aImportes(15) = nIvaOpcion
                If nVarOt > 0 Then
                    aImportes(16) = nVarOt
                Else
                    aImportes(16) = -(nVarOt)
                End If
                aImportes(17) = nSumaOtrosAdeudos
                aImportes(18) = nCapitalOt + nInteresOt
                aImportes(19) = nInteresOt
                aImportes(20) = nInteresOt
                aImportes(21) = nIvaOt
                aImportes(22) = nBaseFEGA
                aImportes(23) = nIvaFEGA

                j = 1
                For i = 0 To 23
                    If aImportes(i) <> 0 Then
                        With aMovimiento
                            .Anexo = cAnexo
                            .Imp = aImportes(i)
                            .Cve = Mid(cLista1, j, 2)
                            .Tipar = cTipar
                            If i = 0 Then
                                If nVarPr + nIntSe + nVarSe > 0 Then
                                    .Coa = Mid(cLista2, i + 1, 1)
                                Else
                                    .Coa = Mid(cLista3, i + 1, 1)
                                End If
                            ElseIf i = 24 Then
                                If nVarOt > 0 Then
                                    .Coa = Mid(cLista2, i + 1, 1)
                                Else
                                    .Coa = Mid(cLista3, i + 1, 1)
                                End If
                            Else
                                .Coa = Mid(cLista2, i + 1, 1)
                            End If
                            .Fecha = cFeven
                            .Tipmov = cTipmov
                            .Banco = ""
                            If i = 15 Then
                                .Concepto = "SEGURO DE VIDA"
                            Else
                                .Concepto = "              "
                            End If
                            .Segmento = cSegmento
                        End With
                        aMovimientos.Add(aMovimiento)
                    End If
                    j = j + 2
                Next

            ElseIf cTipar = "P" Then

                aImportes(0) = nImporteFac - nSumaOtrosAdeudos
                aImportes(1) = nRenPr + nVarPr
                aImportes(2) = nIvaCapital + nIvaPr
                aImportes(3) = nRenSe
                aImportes(4) = nIntSe + nVarSe
                aImportes(5) = nIvaSe
                aImportes(6) = nSeguroVida
                aImportes(7) = nSumaOtrosAdeudos
                aImportes(8) = nCapitalOt + nInteresOt
                aImportes(9) = nInteresOt + nVarOt
                aImportes(10) = nInteresOt
                aImportes(11) = nIvaOt
                aImportes(12) = nBaseFEGA
                aImportes(13) = nIvaFEGA

                j = 1
                For i = 0 To 13
                    If aImportes(i) <> 0 Then
                        With aMovimiento
                            .Anexo = cAnexo
                            .Imp = aImportes(i)
                            .Cve = Mid(cListaA, j, 2)
                            .Tipar = cTipar
                            .Coa = Mid(cListaB, i + 1, 1)
                            .Fecha = cFeven
                            .Tipmov = cTipmov
                            .Banco = ""
                            If i = 6 Then
                                .Concepto = "SEGURO DE VIDA"
                            Else
                                .Concepto = "              "
                            End If
                            .Segmento = cSegmento
                        End With
                        aMovimientos.Add(aMovimiento)
                    End If
                    j = j + 2
                Next

            ElseIf cTipar = "R" Then

                If nVarPr + nIntSe + nVarSe > 0 Then
                    aImportes(0) = nVarPr + nIntSe + nVarSe
                Else
                    aImportes(0) = -(nVarPr + nIntSe + nVarSe)
                End If
                aImportes(1) = nImporteFac - nSumaOtrosAdeudos
                aImportes(2) = nRenPr
                aImportes(3) = nIntPr
                aImportes(4) = nIntPr
                aImportes(5) = nIvaPr + nIvaSe
                aImportes(6) = nRenSe
                aImportes(7) = nSeguroVida
                If nVarOt > 0 Then
                    aImportes(8) = nVarOt
                Else
                    aImportes(8) = -(nVarOt)
                End If
                aImportes(9) = nSumaOtrosAdeudos
                aImportes(10) = nCapitalOt + nInteresOt
                aImportes(11) = nInteresOt
                aImportes(12) = nInteresOt
                aImportes(13) = nIvaOt
                aImportes(14) = nBaseFEGA
                aImportes(15) = nIvaFEGA

                j = 1
                For i = 0 To 15
                    If aImportes(i) <> 0 Then
                        With aMovimiento
                            .Anexo = cAnexo
                            .Imp = aImportes(i)
                            .Cve = Mid(cLista4, j, 2)
                            .Tipar = cTipar
                            If i = 0 Then
                                If nVarPr + nIntSe + nVarSe > 0 Then
                                    .Coa = Mid(cLista5, i + 1, 1)
                                Else
                                    .Coa = Mid(cLista6, i + 1, 1)
                                End If
                            ElseIf i = 8 Then
                                If nVarOt > 0 Then
                                    .Coa = Mid(cLista5, i + 1, 1)
                                Else
                                    .Coa = Mid(cLista6, i + 1, 1)
                                End If
                            Else
                                .Coa = Mid(cLista5, i + 1, 1)
                            End If
                            .Fecha = cFeven
                            .Tipmov = cTipmov
                            .Banco = ""
                            If i = 7 Then
                                .Concepto = "SEGURO DE VIDA"
                            Else
                                .Concepto = "              "
                            End If
                            .Segmento = cSegmento
                        End With
                        aMovimientos.Add(aMovimiento)
                    End If
                    j = j + 2
                Next

            ElseIf cTipar = "S" Then

                If nVarPr + nIntSe + nVarSe > 0 Then
                    aImportes(0) = nVarPr + nIntSe + nVarSe
                Else
                    aImportes(0) = -(nVarPr + nIntSe + nVarSe)
                End If
                aImportes(1) = nImporteFac - nSumaOtrosAdeudos
                aImportes(2) = nRenPr
                aImportes(3) = nRenSe
                aImportes(4) = nSeguroVida
                aImportes(5) = nIntPr
                aImportes(6) = nIntPr
                aImportes(7) = nIvaPr + nIvaSe
                If nVarOt > 0 Then
                    aImportes(8) = nVarOt
                Else
                    aImportes(8) = -(nVarOt)
                End If
                aImportes(9) = nSumaOtrosAdeudos
                aImportes(10) = nCapitalOt + nInteresOt
                aImportes(11) = nInteresOt
                aImportes(12) = nInteresOt
                aImportes(13) = nIvaOt
                aImportes(14) = nBaseFEGA
                aImportes(15) = nIvaFEGA

                j = 1
                For i = 0 To 15
                    If aImportes(i) <> 0 Then
                        With aMovimiento
                            .Anexo = cAnexo
                            .Imp = aImportes(i)
                            .Cve = Mid(cLista7, j, 2)
                            .Tipar = cTipar
                            If i = 0 Then
                                If nVarPr + nIntSe + nVarSe > 0 Then
                                    .Coa = Mid(cLista8, i + 1, 1)
                                Else
                                    .Coa = Mid(cLista9, i + 1, 1)
                                End If
                            ElseIf i = 8 Then
                                If nVarOt > 0 Then
                                    .Coa = Mid(cLista8, i + 1, 1)
                                Else
                                    .Coa = Mid(cLista9, i + 1, 1)
                                End If
                            Else
                                .Coa = Mid(cLista8, i + 1, 1)
                            End If
                            .Fecha = cFeven
                            .Tipmov = cTipmov
                            .Banco = ""
                            If i = 4 Then
                                .Concepto = "SEGURO DE VIDA"
                            Else
                                .Concepto = "              "
                            End If
                            .Segmento = cSegmento
                        End With
                        aMovimientos.Add(aMovimiento)
                    End If
                    j = j + 2
                Next

            End If

        Next

        cnAgil.Open()
        For Each aMovimiento In aMovimientos
            strInsert = "INSERT INTO Auxiliar(Cve, Anexo, Imp, Tipar, Coa, Fecha, Tipmov, Banco, Concepto, Segmento)"
            strInsert = strInsert & " VALUES ('"
            strInsert = strInsert & aMovimiento.Cve & "', '"
            strInsert = strInsert & aMovimiento.Anexo & "', '"
            strInsert = strInsert & aMovimiento.Imp & "', '"
            strInsert = strInsert & aMovimiento.Tipar & "', '"
            strInsert = strInsert & aMovimiento.Coa & "', '"
            strInsert = strInsert & aMovimiento.Fecha & "', '"
            strInsert = strInsert & aMovimiento.Tipmov & "', '"
            strInsert = strInsert & aMovimiento.Banco & "', '"
            strInsert = strInsert & aMovimiento.Concepto & "', '"
            strInsert = strInsert & aMovimiento.Segmento
            strInsert = strInsert & "')"
            cm1 = New SqlCommand(strInsert, cnAgil)
            cm1.ExecuteNonQuery()
        Next
        cnAgil.Close()

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub Seguros(ByVal cFecha As String)

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daSeguros As New SqlDataAdapter(cm1)

        Dim dsAgil As New DataSet()
        Dim drSeguro As DataRow

        Dim strInsert As String

        ' Declaración de variables de datos

        Dim cConcepto As String = ""
        Dim cSegmento As String = ""
        Dim cTipmov As String = "10"

        ' Este Stored Procedure trae todos los registros de Seguros que sean del mes
        ' para el cual se está haciendo el cierre

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Seguros1"
            .Connection = cnAgil
            .Parameters.Add("@FechaFin", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        'Llenar el DataSet a través del DataAdapter, lo cual abre y cierra la conexión

        daSeguros.Fill(dsAgil, "Seguros")

        cnAgil.Open()

        For Each drSeguro In dsAgil.Tables("Seguros").Rows

            If drSeguro("Prima") <> 0 Then

                cSegmento = drSeguro("Segmento_Negocio")
                strInsert = "INSERT INTO Auxiliar(Cve, Anexo, Imp, Tipar, Coa, Fecha, Tipmov, Banco, Concepto, Segmento)"
                strInsert = strInsert & " VALUES ('"
                strInsert = strInsert & "28" & "', '"
                strInsert = strInsert & drSeguro("Anexo") & "', '"
                strInsert = strInsert & drSeguro("Prima") & "', '"
                strInsert = strInsert & "F" & "', '"
                strInsert = strInsert & "0" & "', '"
                strInsert = strInsert & drSeguro("FechaPag") & "', '"
                strInsert = strInsert & cTipmov & "', '"
                strInsert = strInsert & drSeguro("Banco") & "', '"
                strInsert = strInsert & cConcepto & "', '"
                strInsert = strInsert & cSegmento & "'"
                strInsert = strInsert & ")"
                cm1 = New SqlCommand(strInsert, cnAgil)
                cm1.ExecuteNonQuery()

                strInsert = "INSERT INTO Auxiliar(Cve, Anexo, Imp, Tipar, Coa, Fecha, Tipmov, Banco, Concepto, Segmento)"
                strInsert = strInsert & " VALUES ('"
                strInsert = strInsert & "80" & "', '"
                strInsert = strInsert & drSeguro("Anexo") & "', '"
                strInsert = strInsert & drSeguro("Prima") & "', '"
                strInsert = strInsert & "F" & "', '"
                strInsert = strInsert & "1" & "', '"
                strInsert = strInsert & drSeguro("FechaPag") & "', '"
                strInsert = strInsert & cTipmov & "', '"
                strInsert = strInsert & drSeguro("Banco") & "', '"
                strInsert = strInsert & cConcepto & "', '"
                strInsert = strInsert & cSegmento
                strInsert = strInsert & "')"
                cm1 = New SqlCommand(strInsert, cnAgil)
                cm1.ExecuteNonQuery()

            End If

        Next

        cnAgil.Close()

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub CierreFIRA(ByVal cFecha As String)

        ' Este procedimiento registra la provisión de intereses pasivos, el Financiamiento Adicional y el pago de intereses pasivos

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim daCierreFIRA As New SqlDataAdapter(cm1)
        Dim daSegmentos As New SqlDataAdapter(cm2)

        Dim dsAgil As New DataSet()
        Dim drRegistro As DataRow

        Dim strInsert As String

        ' Declaración de variables de datos

        Dim aMovimiento As New Movimiento()
        Dim aMovimientos As New ArrayList()
        Dim cAnexo As String = ""
        Dim cCliente As String = ""
        Dim cSegmento As String = ""
        Dim cTipar As String = ""
        Dim cTipmov As String = ""
        Dim nFinanciamientoAdicional As Decimal = 0
        Dim nInteresesOrdinarios As Decimal = 0         ' Para la provisión de intereses pasivos
        Dim nIntereses As Decimal = 0                   ' Para el pago de intereses pasivos
        Dim nInteresesProvisionados As Decimal = 0
        Dim nInteresesFinanciados As Decimal = 0
        Dim nInteresesPagados As Decimal = 0


        With cm1
            .CommandType = CommandType.Text
            .CommandText = "SELECT DetalleFIRA.IDCredito, PasivoFIRA.Anexo, PasivoFIRA.Cliente, PasivoFIRA.TipoCredito, Segmento_Negocio AS Segmento, InteresesFinanciados, InteresesOrdinarios, Intereses FROM DetalleFIRA " & _
                           "INNER JOIN PasivoFIRA ON DetalleFIRA.IDCredito = PasivoFIRA.IDCredito " & _
                           "INNER JOIN Clientes ON PasivoFIRA.Cliente = Clientes.Cliente " & _
                           "INNER JOIN Sucursales ON Clientes.Sucursal = Sucursales.ID_Sucursal " & _
                           "WHERE FechaFinal = '" & cFecha & "' AND MinistracionBase = 0 AND Capital = 0" & _
                           "ORDER BY PasivoFIRA.Anexo, DetalleFIRA.IDCredito"
            .Connection = cnAgil
        End With

        With cm2
            .CommandType = CommandType.Text
            .CommandText = "SELECT Segmento_Negocio AS Segmento, SUM(InteresesFinanciados) AS InteresesFinanciados, SUM(InteresesOrdinarios) AS InteresesProvisionados, SUM(Intereses) AS InteresesPagados FROM DetalleFIRA " & _
                           "INNER JOIN PasivoFIRA ON DetalleFIRA.IDCredito = PasivoFIRA.IDCredito " & _
                           "INNER JOIN Clientes ON PasivoFIRA.Cliente = Clientes.Cliente " & _
                           "INNER JOIN Sucursales ON Clientes.Sucursal = Sucursales.ID_Sucursal " & _
                           "WHERE FechaFinal = '" & cFecha & "' AND MinistracionBase = 0 AND Capital = 0 " & _
                           "GROUP BY Segmento_Negocio " & _
                           "ORDER BY Segmento_Negocio"
            .Connection = cnAgil
        End With

        'Llenar el DataSet a través del DataAdapter, lo cual abre y cierra la conexión

        daCierreFIRA.Fill(dsAgil, "CierreFIRA")
        daSegmentos.Fill(dsAgil, "Segmentos")
        Try
        Catch eException As Exception
            MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
        End Try

        For Each drRegistro In dsAgil.Tables("Segmentos").Rows
            cSegmento = drRegistro("Segmento")
            nInteresesProvisionados = drRegistro("InteresesProvisionados")
            With aMovimiento
                .Anexo = ""
                .Cliente = ""
                .Imp = nInteresesProvisionados
                .Cve = "69"
                .Tipar = ""
                .Coa = "0"
                .Fecha = cFecha
                .Tipmov = "13"
                .Banco = ""
                .Concepto = ""
                .Segmento = cSegmento
            End With
            aMovimientos.Add(aMovimiento)

        Next

        For Each drRegistro In dsAgil.Tables("Segmentos").Rows
            cSegmento = drRegistro("Segmento")
            nInteresesFinanciados = drRegistro("InteresesFinanciados")
            With aMovimiento
                .Anexo = ""
                .Cliente = ""
                .Imp = nInteresesFinanciados
                .Cve = "99"
                .Tipar = ""
                .Coa = "0"
                .Fecha = cFecha
                .Tipmov = "16"
                .Banco = "11"
                .Concepto = ""
                .Segmento = cSegmento
            End With
            aMovimientos.Add(aMovimiento)

        Next

        For Each drRegistro In dsAgil.Tables("CierreFIRA").Rows
            cAnexo = drRegistro("Anexo")
            cCliente = drRegistro("Cliente")
            cTipar = drRegistro("TipoCredito")
            cSegmento = drRegistro("Segmento")
            nFinanciamientoAdicional = drRegistro("InteresesFinanciados")
            nInteresesOrdinarios = drRegistro("InteresesOrdinarios")            ' Para la provisión de intereses pasivos
            nIntereses = drRegistro("InteresesOrdinarios")                      ' Para el pago de intereses pasivos
            If nInteresesOrdinarios > 0 Then
                With aMovimiento
                    .Anexo = cAnexo
                    .Cliente = cCliente
                    .Imp = nInteresesOrdinarios
                    .Cve = "70"
                    .Tipar = cTipar
                    .Coa = "1"
                    .Fecha = cFecha
                    .Tipmov = "13"
                    .Banco = ""
                    .Concepto = ""
                    .Segmento = cSegmento
                End With
                aMovimientos.Add(aMovimiento)
            End If
            If nFinanciamientoAdicional > 0 Then
                With aMovimiento
                    .Anexo = cAnexo
                    .Cliente = cCliente
                    .Imp = nFinanciamientoAdicional
                    .Cve = "70"
                    .Tipar = cTipar
                    .Coa = "1"
                    .Fecha = cFecha
                    .Tipmov = "16"
                    .Banco = ""
                    .Concepto = ""
                    .Segmento = cSegmento
                End With
                aMovimientos.Add(aMovimiento)
            End If
            If nIntereses > 0 Then
                With aMovimiento
                    .Anexo = cAnexo
                    .Cliente = cCliente
                    .Imp = nIntereses
                    .Cve = "70"
                    .Tipar = cTipar
                    .Coa = "0"
                    .Fecha = cFecha
                    .Tipmov = "17"
                    .Banco = ""
                    .Concepto = ""
                    .Segmento = cSegmento
                End With
                aMovimientos.Add(aMovimiento)
            End If
        Next

        For Each drRegistro In dsAgil.Tables("Segmentos").Rows
            cSegmento = drRegistro("Segmento")
            nInteresesPagados = drRegistro("InteresesPagados")
            With aMovimiento
                .Anexo = ""
                .Cliente = ""
                .Imp = nInteresesPagados
                .Cve = "99"
                .Tipar = ""
                .Coa = "1"
                .Fecha = cFecha
                .Tipmov = "17"
                .Banco = "11"
                .Concepto = ""
                .Segmento = cSegmento
            End With
            aMovimientos.Add(aMovimiento)
        Next

        cnAgil.Open()

        For Each aMovimiento In aMovimientos
            strInsert = "INSERT INTO Auxiliar(Cve, Anexo, Cliente, Imp, Tipar, Coa, Fecha, Tipmov, Banco, Concepto, Segmento)"
            strInsert = strInsert & " VALUES ('"
            strInsert = strInsert & aMovimiento.Cve & "', '"
            strInsert = strInsert & aMovimiento.Anexo & "', '"
            strInsert = strInsert & aMovimiento.Cliente & "', "
            strInsert = strInsert & aMovimiento.Imp & ", '"
            strInsert = strInsert & aMovimiento.Tipar & "', '"
            strInsert = strInsert & aMovimiento.Coa & "', '"
            strInsert = strInsert & aMovimiento.Fecha & "', '"
            strInsert = strInsert & aMovimiento.Tipmov & "', '"
            strInsert = strInsert & aMovimiento.Banco & "', '"
            strInsert = strInsert & aMovimiento.Concepto & "', '"
            strInsert = strInsert & aMovimiento.Segmento
            strInsert = strInsert & "')"
            cm3 = New SqlCommand(strInsert, cnAgil)
            cm3.ExecuteNonQuery()
        Next
        Try
        Catch eException As Exception
            MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")
        End Try

        cnAgil.Close()

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()
        cm3.Dispose()

    End Sub

    Private Sub FondeoFIRA(ByVal cFecha As String)

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim daFechas As New SqlDataAdapter(cm1)
        Dim daFondeoFIRA As New SqlDataAdapter(cm2)

        Dim dsAgil As New DataSet()
        Dim drFecha As DataRow
        Dim drMinistracion As DataRow

        Dim strInsert As String

        ' Declaración de variables de datos

        Dim aMovimiento As New Movimiento()
        Dim aMovimientos As New ArrayList()
        Dim cAnexo As String = ""
        Dim cCliente As String = ""
        Dim cFechaMinistracion As String = ""
        Dim cSegmento As String = ""
        Dim cTipar As String = ""
        Dim cTipmov As String = "11"            ' Registro de ministraciones FIRA - FINAGIL
        Dim nImporte As Decimal = 0
        Dim nSumaBanco As Decimal = 0

        ' El siguiente comando trae los diferentes días que existen para ministraciones FIRA - FINAGIL, con la sumatoria de los importes ministrados por día

        With cm1
            .CommandType = CommandType.Text
            .CommandText = "SELECT FechaFinal AS FechaMinistracion, SUM(MinistracionBase) As ImporteMinistrado FROM DetalleFIRA " & _
                           "WHERE LEFT(FechaFinal, 6) = '" & Mid(cFecha, 1, 6) & "' AND MinistracionBase > 0 " & _
                           "GROUP BY FechaFinal HAVING SUM(MinistracionBase) > 0 " & _
                           "ORDER BY FechaFinal"
            .Connection = cnAgil
        End With

        ' El siguiente comando trae todas las ministraciones FIRA - FINAGIL durante el mes del reporte

        With cm2
            .CommandType = CommandType.Text
            .CommandText = "SELECT FechaFinal AS FechaMinistracion, Anexo, PasivoFIRA.Cliente, TipoCredito, Segmento_Negocio, SUM(MinistracionBase) AS ImporteMinistrado FROM DetalleFIRA " & _
                           "INNER JOIN PasivoFIRA ON DetalleFIRA.IDCredito = PasivoFIRA.IDCredito " & _
                           "INNER JOIN Clientes ON PasivoFIRA.Cliente = Clientes.Cliente " & _
                           "INNER JOIN Sucursales ON Clientes.Sucursal = Sucursales.ID_Sucursal " & _
                           "WHERE LEFT(FechaFinal, 6) = '" & Mid(cFecha, 1, 6) & "' AND MinistracionBase > 0 " & _
                           "GROUP BY FechaFinal, Anexo, PasivoFIRA.Cliente, TipoCredito, Segmento_Negocio " & _
                           "ORDER BY FechaFinal, Anexo"
            .Connection = cnAgil
        End With

        'Llenar el DataSet a través del DataAdapter, lo cual abre y cierra la conexión

        daFechas.Fill(dsAgil, "Fechas")
        daFondeoFIRA.Fill(dsAgil, "PasivoFIRA")

        ' Primero registro los cargos a Bancos

        For Each drFecha In dsAgil.Tables("Fechas").Rows

            With aMovimiento
                .Anexo = ""
                .Cliente = ""
                .Imp = drFecha("ImporteMinistrado")
                .Cve = "99"
                .Tipar = ""
                .Coa = "0"
                .Fecha = drFecha("FechaMinistracion")
                .Tipmov = cTipmov
                .Banco = "11"
                .Concepto = ""
                .Segmento = "100"
                aMovimientos.Add(aMovimiento)
            End With

        Next

        ' Luego registro los abonos al Pasivo

        For Each drMinistracion In dsAgil.Tables("PasivoFIRA").Rows
            cFechaMinistracion = drMinistracion("FechaMinistracion")
            cAnexo = drMinistracion("Anexo")
            cCliente = drMinistracion("Cliente")
            cTipar = drMinistracion("TipoCredito")
            nImporte = drMinistracion("ImporteMinistrado")
            cSegmento = drMinistracion("Segmento_Negocio")
            If nImporte <> 0 Then
                With aMovimiento
                    .Anexo = cAnexo
                    .Cliente = cCliente
                    .Imp = nImporte
                    If cTipar = "A" Then
                        .Cve = "68"     ' Crédito de Avío
                    Else
                        .Cve = "76"     ' Crédito Refaccionario
                    End If
                    .Tipar = cTipar
                    .Coa = "1"
                    .Fecha = cFechaMinistracion
                    .Tipmov = cTipmov
                    .Banco = ""
                    .Concepto = ""
                    .Segmento = "100"
                End With
                aMovimientos.Add(aMovimiento)
            End If
        Next

        cnAgil.Open()

        For Each aMovimiento In aMovimientos
            strInsert = "INSERT INTO Auxiliar(Cve, Anexo, Cliente, Imp, Tipar, Coa, Fecha, Tipmov, Banco, Concepto, Segmento)"
            strInsert = strInsert & " VALUES ('"
            strInsert = strInsert & aMovimiento.Cve & "', '"
            strInsert = strInsert & aMovimiento.Anexo & "', '"
            strInsert = strInsert & aMovimiento.Cliente & "', "
            strInsert = strInsert & aMovimiento.Imp & ", '"
            strInsert = strInsert & aMovimiento.Tipar & "', '"
            strInsert = strInsert & aMovimiento.Coa & "', '"
            strInsert = strInsert & aMovimiento.Fecha & "', '"
            strInsert = strInsert & aMovimiento.Tipmov & "', '"
            strInsert = strInsert & aMovimiento.Banco & "', '"
            strInsert = strInsert & aMovimiento.Concepto & "', '"
            strInsert = strInsert & aMovimiento.Segmento
            strInsert = strInsert & "')"
            cm3 = New SqlCommand(strInsert, cnAgil)
            cm3.ExecuteNonQuery()
        Next

        cnAgil.Close()

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()
        cm3.Dispose()

    End Sub

    Private Sub EgresosFIRA(ByVal cFecha As String)

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim daFechas As New SqlDataAdapter(cm1)
        Dim daEgresos As New SqlDataAdapter(cm2)

        Dim dsAgil As New DataSet()
        Dim drEgreso As DataRow
        Dim drFecha As DataRow
        Dim drRegistro As DataRow
        Dim myColArray(0) As DataColumn
        Dim myKeySearch(0) As String

        Dim strInsert As String

        ' Declaración de variables de datos

        Dim aMovimiento As New Movimiento()
        Dim aMovimientos As New ArrayList()
        Dim cAnexo As String = ""
        Dim cClaveEgreso As String = ""
        Dim cCliente As String = ""
        Dim cFechaEgreso As String = ""
        Dim cSegmento As String = ""
        Dim cTipar As String = ""
        Dim cTipmov As String = "18"            ' Registro de pagos FINAGIL - FIRA
        Dim nImporte As Decimal = 0

        ' El siguiente comando trae las diferentes fechas de pago que hizo FINAGIL a FIRA durante el mes del reporte a fin de ir acumulando saldos
        ' y, en caso de que los Abonos sean mayores a los Cargos, cambiar el signo del movimiento

        With cm1
            .CommandType = CommandType.Text
            .CommandText = "SELECT DISTINCT FechaEgreso, 0.00 AS Importe, '1' AS CargoAbono FROM Egresos " & _
                           "WHERE LEFT(FechaEgreso,6) = '" & Mid(cFecha, 1, 6) & "' " & _
                           "ORDER BY FechaEgreso"
            .Connection = cnAgil
        End With

        ' El siguiente comando trae todos los pagos que FINAGIL cubrió a FIRA durante el mes del reporte

        With cm2
            .CommandType = CommandType.Text
            .CommandText = "SELECT Egresos.*, Segmento_Negocio FROM Egresos " & _
                           "INNER JOIN Clientes ON Egresos.Cliente = Clientes.Cliente " & _
                           "INNER JOIN Sucursales ON Clientes.Sucursal = Sucursales.ID_Sucursal " & _
                           "WHERE LEFT(FechaEgreso,6) = '" & Mid(cFecha, 1, 6) & "' " & _
                           "ORDER BY FechaEgreso, Anexo"
            .Connection = cnAgil
        End With

        ' Llenar el DataSet a través del DataAdapter, lo cual abre y cierra la conexión

        daFechas.Fill(dsAgil, "Fechas")
        daEgresos.Fill(dsAgil, "Egresos")

        ' Definir una LLAVE PRIMARIA SIMPLE para la tabla Fechas (FechaEgreso) para ir acumulando el saldo de Bancos

        myColArray(0) = dsAgil.Tables("Fechas").Columns("FechaEgreso")
        dsAgil.Tables("Fechas").PrimaryKey = myColArray

        ' Primero registro los cargos al Pasivo

        For Each drEgreso In dsAgil.Tables("Egresos").Rows
            cAnexo = drEgreso("Anexo")
            cCliente = drEgreso("Cliente")
            cFechaEgreso = drEgreso("FechaEgreso")
            nImporte = drEgreso("ImporteEgreso")
            cClaveEgreso = drEgreso("ClaveEgreso")
            cTipar = drEgreso("TipoCredito")
            cSegmento = drEgreso("Segmento_Negocio")
            If nImporte > 0 Then
                With aMovimiento
                    .Anexo = cAnexo
                    .Cliente = cCliente
                    .Imp = nImporte
                    .Cve = cClaveEgreso
                    .Tipar = cTipar
                    .Coa = drEgreso("CargoAbono")
                    .Fecha = drEgreso("FechaEgreso")
                    .Tipmov = cTipmov
                    .Banco = ""
                    .Concepto = drEgreso("Concepto")
                    .Segmento = cSegmento
                End With
                aMovimientos.Add(aMovimiento)
                myKeySearch(0) = drEgreso("FechaEgreso")
                drFecha = dsAgil.Tables("Fechas").Rows.Find(myKeySearch)
                If drEgreso("CargoAbono") = "0" Then
                    drFecha("Importe") += nImporte
                Else
                    drFecha("Importe") -= nImporte
                End If
            End If
        Next

        ' Al finar proceso la tabla Bancos para que si el importe es negativo se cambie a positivo y que en lugar de abono a Bancos sea cargo

        For Each drRegistro In dsAgil.Tables("Fechas").Rows

            If drRegistro("Importe") < 0 Then
                drRegistro("Importe") = -drRegistro("Importe")
                drRegistro("CargoAbono") = "0"
            End If

            With aMovimiento
                .Anexo = ""
                .Cliente = ""
                .Imp = drRegistro("Importe")
                .Cve = "99"
                .Tipar = ""
                .Coa = drRegistro("CargoAbono")
                .Fecha = drRegistro("FechaEgreso")
                .Tipmov = cTipmov
                .Banco = "11"
                .Concepto = "Pago a FIRA "
                .Segmento = "100"
                aMovimientos.Add(aMovimiento)
            End With

        Next

        cnAgil.Open()

        For Each aMovimiento In aMovimientos
            strInsert = "INSERT INTO Auxiliar(Cve, Anexo, Cliente, Imp, Tipar, Coa, Fecha, Tipmov, Banco, Concepto, Segmento)"
            strInsert = strInsert & " VALUES ('"
            strInsert = strInsert & aMovimiento.Cve & "', '"
            strInsert = strInsert & aMovimiento.Anexo & "', '"
            strInsert = strInsert & aMovimiento.Cliente & "', "
            strInsert = strInsert & aMovimiento.Imp & ", '"
            strInsert = strInsert & aMovimiento.Tipar & "', '"
            strInsert = strInsert & aMovimiento.Coa & "', '"
            strInsert = strInsert & aMovimiento.Fecha & "', '"
            strInsert = strInsert & aMovimiento.Tipmov & "', '"
            strInsert = strInsert & aMovimiento.Banco & "', '"
            strInsert = strInsert & aMovimiento.Concepto & "', '"
            strInsert = strInsert & aMovimiento.Segmento
            strInsert = strInsert & "')"
            cm3 = New SqlCommand(strInsert, cnAgil)
            cm3.ExecuteNonQuery()
        Next

        cnAgil.Close()

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()
        cm3.Dispose()

    End Sub

End Class
