Option Explicit On

Imports System.Data.SqlClient
Imports System.Math

Public Class frmEdoCtaAvio

    ' Declaración de variables de datos de alcance privado

    Dim cAnexo As String = ""
    Dim cCiclo As String = ""
    Dim cDescCiclo As String = ""
    Dim cFechaTerminacion As String = ""
    Dim cNombreProductor As String = ""
    Dim cNombreSucursal As String = ""

    Public Sub New(ByVal cLinea As String)

        MyBase.New()

        'This call is required by the Windows Form Designer.

        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        txtAnexo.Text = Mid(cLinea, 1, 10)
        lblCiclo.Text = Mid(cLinea, 12, 47)
        cDescCiclo = lblCiclo.Text

        If Mid(cDescCiclo, 1, 6) = "PAGARE" Then
            Me.Text = "Estado de Cuenta del Crédito en Cuenta Corriente " & Mid(cLinea, 1, 10)
        Else
            Me.Text = "Estado de Cuenta del Contrato de Avío " & Mid(cLinea, 1, 10)
        End If

    End Sub

    Private Sub frmEdoCtaAvio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()

        ' Declaración de variables de datos

        Dim cCliente_Sucursal As String = ""

        cAnexo = Mid(txtAnexo.Text, 1, 5) + Mid(txtAnexo.Text, 7, 4)

        If Mid(cDescCiclo, 1, 6) = "PAGARE" Then
            cCiclo = Mid(lblCiclo.Text, 8, 2)
        Else
            cCiclo = Mid(lblCiclo.Text, 7, 2)
        End If

        ' El siguiente Command trae el nombre del Productor y la Sucursal que lo atiende

        With cm1
            .CommandType = CommandType.Text
            .CommandText = "SELECT SUBSTRING(Descr, 1, 100) + SUBSTRING(Nombre_Sucursal,1,50) AS Cliente_Sucursal FROM Avios " & _
                           "INNER JOIN Clientes ON Avios.Cliente = Clientes.Cliente " & _
                           "INNER JOIN Sucursales ON Sucursales.ID_Sucursal = Clientes.Sucursal " & _
                           "WHERE Anexo = '" & cAnexo & "' AND Ciclo = '" & cCiclo & "'"
            .Connection = cnAgil
        End With

        cnAgil.Open()
        cCliente_Sucursal = cm1.ExecuteScalar
        cnAgil.Close()

        cNombreProductor = Mid(cCliente_Sucursal, 1, 100)
        cNombreSucursal = Mid(cCliente_Sucursal, 101, 50)
        txtNombreProductor.Text = cNombreProductor
        lblSucursal.Text = "Sucursal " & RTrim(cNombreSucursal)

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click

        If cCiclo >= "04" Or Mid(cDescCiclo, 1, 6) = "PAGARE" Then
            EdoCtaUno()
        Else
            EdoCtaDos()
        End If

    End Sub

    Private Sub EdoCtaUno()

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daDetalle As New SqlDataAdapter(cm1)

        Dim dsAgil As New DataSet()
        Dim drDetalle As DataRow
        Dim dtTIIE As New DataTable()
        Dim drTIIE As DataRow

        Dim myKeySearch(0) As String

        ' Declaración de variables de Crystal Reports

        Dim newrptEdoCtaNew As New rptEdoCtaNew()
        Dim cReportTitle As String = ""

        ' Declaración de variables de datos

        Dim cCliente As String = ""
        Dim cFecha As String = ""
        Dim cFechaFinal As String = ""
        Dim cFechaInicial As String = ""
        Dim cFechaTerminacion As String = ""
        Dim cTipta As String = ""
        Dim cUltimoCorte As String = ""
        Dim nConsecutivo As Integer = 0
        Dim nDias As Integer = 0
        Dim nDiferencial As Decimal = 0
        Dim nIntereses As Decimal = 0
        Dim nSaldoFinal As Decimal = 0
        Dim nSaldoInicial As Decimal = 0
        Dim nSumaIntereses As Decimal = 0
        Dim nTasa As Decimal = 0
        Dim nTasaBP As Decimal = 0

        ' Genero la tabla que contiene las TIIE promedio por mes 
        ' Para FINAGIL considera todos los días del mes y redondea a 4 decimales

        dtTIIE = TIIEavg("FINAGIL")

        ' El siguiente Command trae los movimientos que existan en DetalleFINAGIL del contrato seleccionado

        With cm1
            .CommandType = CommandType.Text
            .CommandText = "SELECT DetalleFINAGIL.*, Tipta, Tasas, DiferencialFINAGIL, UltimoCorte, FechaTerminacion, Nombre_Sucursal FROM DetalleFINAGIL " & _
                           "INNER JOIN Avios ON DetalleFINAGIL.Anexo = Avios.Anexo AND DetalleFINAGIL.Ciclo = Avios.Ciclo " & _
                           "INNER JOIN Clientes ON Avios.Cliente = Clientes.Cliente " & _
                           "INNER JOIN Sucursales ON Clientes.Sucursal = Sucursales.ID_Sucursal " & _
                           "WHERE DetalleFINAGIL.Anexo = '" & cAnexo & "' AND DetalleFINAGIL.Ciclo = '" & cCiclo & "' " & _
                           "ORDER BY Consecutivo"
            .Connection = cnAgil
        End With

        ' Tengo que copiar estos registros en una tabla temporal para poder calcular el registro de intereses ordinarios
        ' (si procedieran) sin necesidad de insertar un registro en la tabla física

        cFecha = DTOC(dtpProceso.Value)

        ' Llenar el DataSet lo cual abre y cierra la conexión

        daDetalle.Fill(dsAgil, "Detalle")

        For Each drDetalle In dsAgil.Tables("Detalle").Rows

            nTasa = drDetalle("Tasas")
            nDiferencial = drDetalle("DiferencialFINAGIL")
            cTipta = drDetalle("Tipta")
            cUltimoCorte = drDetalle("UltimoCorte")
            cFechaTerminacion = drDetalle("FechaTerminacion")

            cCliente = drDetalle("Cliente")
            nConsecutivo = drDetalle("Consecutivo")
            cFechaInicial = drDetalle("FechaFinal")
            nSaldoInicial = drDetalle("SaldoFinal")

        Next

        If cFecha < cFechaInicial Then

            ' Se desea obtener el Estado de Cuenta a una fecha anterior al último movimiento registrado
            ' lo cual no es posible.   Lo que hace el sistema es cambiar la fecha de cálculo a la fecha
            ' del último movimiento registrado

            cFecha = cFechaInicial

        End If

        nConsecutivo += 1

        If cTipta = "7" Then

            nTasaBP = Round(nTasa + nDiferencial, 4)

        Else

            ' Construyo una fecha que me permita buscar el promedio de la tasa TIIE del mes inmediato anterior

            myKeySearch(0) = Mid(DTOC(DateAdd(DateInterval.Month, -1, CTOD(cFecha))), 1, 6)

            drTIIE = dtTIIE.Rows.Find(myKeySearch)

            If drTIIE Is Nothing Then
                nTasaBP = 0
            Else
                nTasaBP = drTIIE("Promedio")
            End If

            nTasaBP = Round(nTasaBP + nDiferencial, 4)

        End If

        If cFecha > cFechaTerminacion Then
            nTasaBP = Round(nTasaBP * 3, 4)
        End If

        nDias = DateDiff(DateInterval.Day, CTOD(cFechaInicial), CTOD(cFecha))

        drDetalle = dsAgil.Tables("Detalle").NewRow
        drDetalle("Anexo") = cAnexo
        drDetalle("Cliente") = cCliente
        drDetalle("Consecutivo") = nConsecutivo
        drDetalle("FechaInicial") = cFechaInicial
        drDetalle("FechaFinal") = cFecha
        drDetalle("Dias") = nDias
        drDetalle("TasaBP") = nTasaBP
        drDetalle("SaldoInicial") = nSaldoInicial
        drDetalle("SaldoFinal") = nSaldoFinal
        drDetalle("Concepto") = "INTERESES"
        drDetalle("Importe") = 0
        drDetalle("FEGA") = 0
        drDetalle("Garantia") = 0
        drDetalle("Intereses") = 0
        dsAgil.Tables("Detalle").Rows.Add(drDetalle)

        nSumaIntereses = 0

        For Each drDetalle In dsAgil.Tables("Detalle").Rows

            cFechaFinal = drDetalle("FechaFinal")
            If Mid(cFechaFinal, 1, 6) = Mid(cFecha, 1, 6) And cFechaFinal > cUltimoCorte Then
                nSaldoInicial = drDetalle("SaldoInicial")
                nTasaBP = drDetalle("TasaBP")
                nDias = drDetalle("Dias")
                nIntereses = Round(nSaldoInicial * nTasaBP / 36000 * nDias, 2)
                nSumaIntereses = Round(nSumaIntereses + nIntereses, 2)
            End If

            nConsecutivo = drDetalle("Consecutivo")

        Next

        nSaldoFinal = nSaldoInicial + nSumaIntereses

        drDetalle("Intereses") = nSumaIntereses
        drDetalle("SaldoFinal") = nSaldoFinal

        If drDetalle("SaldoInicial") = 0 And drDetalle("SaldoFinal") = 0 Then
            dsAgil.Tables("Detalle").Rows(nConsecutivo - 1).Delete()
        ElseIf drDetalle("Importe") = 0 And drDetalle("FEGA") = 0 And drDetalle("Garantia") = 0 And drDetalle("Intereses") = 0 Then
            dsAgil.Tables("Detalle").Rows(nConsecutivo - 1).Delete()
        End If

        ' Descomentar la siguiente línea en caso de que desee modificarse el reporte rptEdoCtaNew
        ' dsAgil.WriteXml("C:\FILES\frmEdoCtaNew.xml", XmlWriteMode.WriteSchema)

        If Val(Mid(cFecha, 7, 2)) < 10 Then
            cReportTitle = "ESTADO DE CUENTA AL " + Mid(Mes(cFecha), 2, Len(Mes(cFecha)))
        Else
            cReportTitle = "ESTADO DE CUENTA AL " + Mes(cFecha)
        End If

        newrptEdoCtaNew.SummaryInfo.ReportTitle = cReportTitle
        newrptEdoCtaNew.SummaryInfo.ReportComments = "Cliente : " & cNombreProductor & Space(1) & cDescCiclo

        newrptEdoCtaNew.SetDataSource(dsAgil)
        CrystalReportViewer1.ReportSource = newrptEdoCtaNew
        CrystalReportViewer1.Zoom(89)

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub EdoCtaDos()

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim cm4 As New SqlCommand()
        Dim daEncabezado As New SqlDataAdapter(cm1)
        Dim daMinistracion As New SqlDataAdapter(cm2)

        Dim dsAgil As New DataSet()
        Dim dtEncabezado As New DataTable("Encabezado")
        Dim dtEdoDetAvio As New DataTable("EdoDetAvio")
        Dim dtTIIE As New DataTable()
        Dim drMinistracion As DataRow
        Dim drEdoDetAvio As DataRow
        Dim drTemporal As DataRow

        ' Declaración de variables de Crystal Reports

        Dim newrptEdoCtaAvio As New rptEdoCtaAvio()
        Dim newrptEdoDetAvio As New rptEdoDetAvio()
        Dim cReportComments As String

        ' Declaración de variables de datos

        Dim cDocumento As String = ""
        Dim cFecha As String = ""
        Dim cFechaDocumento As String = ""
        Dim cFechaInicioIntereses As String = ""
        Dim cFechaTerminacion As String = ""
        Dim cFechaTerminacionGarantia As String = ""
        Dim cReferencia As String = "FINAGIL"
        Dim cTipta As String = ""
        Dim cUltimoPago As String = ""
        Dim nImporte As Decimal = 0
        Dim nImporteAcumulado As Decimal = 0
        Dim nImporteMinistrado As Decimal = 0
        Dim nMinistracion As Decimal = 0
        Dim nGarantiaLiquida As Decimal = 0
        Dim nInteresGarantia As Decimal = 0
        Dim nDiferencialFINAGIL As Decimal = 0
        Dim nSaldoGarantia As Decimal = 0
        Dim nSaldoMinistracion As Decimal = 0
        Dim nSaldoTotal As Decimal = 0
        Dim nSumatoria As Decimal = 0
        Dim nSumatoriaGL As Decimal = 0
        Dim nTasas As Decimal = 0

        cFecha = DTOC(dtpProceso.Value)

        dsAgil.Tables.Add(EdoCtaAvio(cAnexo, cFecha))

        ' Descomentar la siguiente línea en caso de que desee modificarse el reporte rptEdoCtaAvio
        ' dsAgil.WriteXml("C:\frmEdoCtaAvio.xml", XmlWriteMode.WriteSchema)

        If Val(Mid(cFecha, 7, 2)) < 10 Then
            cReportComments = "AL " + Mid(Mes(cFecha), 2, Len(Mes(cFecha)))
        Else
            cReportComments = "AL " + Mes(cFecha)
        End If
        newrptEdoCtaAvio.SummaryInfo.ReportComments = cReportComments

        newrptEdoCtaAvio.SetDataSource(dsAgil)
        CrystalReportViewer1.ReportSource = newrptEdoCtaAvio

        'If rbResumido.Checked = True Then

        'ElseIf rbDetallado.Checked = True Then

        '    ' En primer lugar creo la tabla dtEdoCtaAvio

        '    dtEdoDetAvio.Columns.Add("Anexo", Type.GetType("System.String"))
        '    dtEdoDetAvio.Columns.Add("Ministracion", Type.GetType("System.Decimal"))
        '    dtEdoDetAvio.Columns.Add("ImporteMinistrado", Type.GetType("System.Decimal"))
        '    dtEdoDetAvio.Columns.Add("Documento", Type.GetType("System.String"))
        '    dtEdoDetAvio.Columns.Add("SaldoInicial", Type.GetType("System.Decimal"))
        '    dtEdoDetAvio.Columns.Add("FechaInicial", Type.GetType("System.String"))
        '    dtEdoDetAvio.Columns.Add("FechaFinal", Type.GetType("System.String"))
        '    dtEdoDetAvio.Columns.Add("TasaInteres", Type.GetType("System.Decimal"))
        '    dtEdoDetAvio.Columns.Add("Dias", Type.GetType("System.Decimal"))
        '    dtEdoDetAvio.Columns.Add("Interes", Type.GetType("System.Decimal"))
        '    dtEdoDetAvio.Columns.Add("InteresMoratorio", Type.GetType("System.Decimal"))
        '    dtEdoDetAvio.Columns.Add("Acumulado", Type.GetType("System.Decimal"))
        '    dtEdoDetAvio.Columns.Add("Sumatoria", Type.GetType("System.Decimal"))
        '    dtEdoDetAvio.Columns.Add("SumatoriaGL", Type.GetType("System.Decimal"))
        '    dtEdoDetAvio.Columns.Add("UltimoPago", Type.GetType("System.String"))
        '    dtEdoDetAvio.Columns.Add("SaldoMinistracion", Type.GetType("System.Decimal"))
        '    dtEdoDetAvio.Columns.Add("SaldoGarantia", Type.GetType("System.Decimal"))

        '    ' El siguiente Command trae los datos del contrato seleccionado

        '    With cm1
        '        .CommandType = CommandType.Text
        '        .CommandText = "SELECT DISTINCT mFINAGIL.Anexo, Descr, DiferencialFINAGIL, Revisa, Autoriza FROM mFINAGIL " & _
        '                       "INNER JOIN Avios ON mFINAGIL.Anexo = Avios.Anexo " & _
        '                       "INNER JOIN Clientes ON Avios.Cliente = Clientes.Cliente " & _
        '                       "INNER JOIN Sucursales ON Clientes.Sucursal = Sucursales.ID_Sucursal " & _
        '                       "WHERE mFINAGIL.Anexo = " & "'" & cAnexo & "'" & " AND FechaDocumento <= " & "'" & cFecha & "'"
        '        .Connection = cnAgil
        '    End With

        '    ' El siguiente Command trae las ministraciones que le haya hecho FINAGIL al contrato seleccionado

        '    With cm2
        '        .CommandType = CommandType.Text
        '        .CommandText = "SELECT mFINAGIL.*, FechaTerminacion, Tipta, Tasas, DiferencialFINAGIL FROM mFINAGIL " & _
        '                       "INNER JOIN Avios ON mFINAGIL.Anexo = Avios.Anexo " & _
        '                       "WHERE mFINAGIL.Anexo = " & "'" & cAnexo & "'" & " AND Pagado = 'N' AND SaldoMinistracion > 0 AND FechaDocumento <= " & "'" & cFecha & "' " & _
        '                       "ORDER BY FechaDocumento"
        '        .Connection = cnAgil
        '    End With

        '    With cm3
        '        .CommandType = CommandType.Text
        '        .CommandText = "SELECT SUM(SaldoMinistracion + SaldoGarantia) FROM mFINAGIL " & _
        '                       "WHERE SaldoMinistracion > 0 AND mFINAGIL.Anexo = " & "'" & cAnexo & "'" & " AND FechaDocumento <= " & "'" & cFecha & "'"
        '        .Connection = cnAgil
        '    End With

        '    With cm4
        '        .CommandType = CommandType.Text
        '        .CommandText = "SELECT SUM(SaldoGarantia) FROM mFINAGIL " & _
        '                       "WHERE SaldoMinistracion > 0 AND mFINAGIL.Anexo = " & "'" & cAnexo & "'" & " AND FechaDocumento <= " & "'" & cFecha & "'"
        '        .Connection = cnAgil
        '    End With

        '    ' Llenar el DataSet lo cual abre y cierra la conexión

        '    daEncabezado.Fill(dsAgil, "Encabezado")
        '    daMinistracion.Fill(dsAgil, "Ministraciones")

        '    If dsAgil.Tables("Ministraciones").Rows.Count > 0 Then
        '        cnAgil.Open()
        '        nSumatoria = cm3.ExecuteScalar()
        '        nSumatoriaGL = cm4.ExecuteScalar() * -1
        '        cnAgil.Close()
        '    End If

        '    ' Genero la tabla que contiene las TIIE promedio por mes 
        '    ' Para FINAGIL considera todos los días del mes y redondea a 4 decimales

        '    dtTIIE = TIIEavg("FINAGIL")

        '    For Each drMinistracion In dsAgil.Tables("Ministraciones").Rows

        '        cAnexo = drMinistracion("Anexo")
        '        cTipta = drMinistracion("Tipta")
        '        nTasas = drMinistracion("Tasas")
        '        cDocumento = drMinistracion("Documento")
        '        If Trim(cDocumento) = "EFECTIVO" Then
        '            cFechaDocumento = drMinistracion("FechaPago")
        '        Else
        '            cFechaDocumento = drMinistracion("FechaDocumento")
        '        End If
        '        cFechaTerminacion = drMinistracion("FechaTerminacion")

        '        ' La garantía líquida solo debe iterar hasta la fecha del reporte si ésta es anterior a la fecha de terminación del crédito
        '        ' Si la fecha del reporte es posterior a la fecha de terminación del crédito, la garantía líquida solo debe iterar hasta la fecha de terminación

        '        cFechaTerminacionGarantia = cFecha
        '        If cFecha > cFechaTerminacion Then
        '            cFechaTerminacionGarantia = cFechaTerminacion
        '        End If

        '        cUltimoPago = drMinistracion("UltimoPago")
        '        nImporteMinistrado = drMinistracion("Importe")
        '        nGarantiaLiquida = drMinistracion("Garantia")
        '        nSaldoMinistracion = drMinistracion("SaldoMinistracion")
        '        nSaldoGarantia = drMinistracion("SaldoGarantia")
        '        nDiferencialFINAGIL = drMinistracion("DiferencialFINAGIL")

        '        If Trim(cUltimoPago) = "" Then

        '            ' Se trata del primer pago a este contrato

        '            cFechaInicioIntereses = cFechaDocumento

        '        Else

        '            ' Existe un pago anterior a este contrato

        '            cFechaInicioIntereses = cUltimoPago

        '        End If

        '        ' En esta parte proceso el importe correspondiente a la ministración

        '        nMinistracion = nMinistracion + 1

        '        nImporte = nSaldoMinistracion
        '        nImporteAcumulado = nImporte

        '        For Each drTemporal In InteresAcumulado(cAnexo, cTipta, cReferencia, cFechaInicioIntereses, nImporte, nTasas, nDiferencialFINAGIL, cFecha, dtTIIE, cFechaTerminacion).Rows
        '            drEdoDetAvio = dtEdoDetAvio.NewRow()
        '            drEdoDetAvio("Anexo") = cAnexo
        '            drEdoDetAvio("Ministracion") = nMinistracion
        '            drEdoDetAvio("ImporteMinistrado") = nImporteMinistrado
        '            If Trim(cDocumento) = "REEMBOLSO" Then
        '                cDocumento = "EFECTIVO"
        '            End If
        '            drEdoDetAvio("Documento") = Trim(cDocumento)
        '            drEdoDetAvio("SaldoInicial") = nImporteAcumulado
        '            drEdoDetAvio("FechaInicial") = drTemporal("FechaInicial")
        '            drEdoDetAvio("FechaFinal") = drTemporal("FechaFinal")
        '            drEdoDetAvio("TasaInteres") = drTemporal("Tasa")
        '            drEdoDetAvio("Dias") = drTemporal("Dias")
        '            If drTemporal("FechaFinal") <= cFechaTerminacion Then
        '                drEdoDetAvio("Interes") = drTemporal("Interes")
        '                drEdoDetAvio("InteresMoratorio") = 0
        '            Else
        '                drEdoDetAvio("Interes") = 0
        '                drEdoDetAvio("InteresMoratorio") = drTemporal("Interes")
        '            End If
        '            drEdoDetAvio("Acumulado") = nImporteAcumulado + drTemporal("Interes")
        '            drEdoDetAvio("Sumatoria") = nSumatoria
        '            drEdoDetAvio("SumatoriaGL") = nSumatoriaGL
        '            drEdoDetAvio("UltimoPago") = cUltimoPago
        '            drEdoDetAvio("SaldoMinistracion") = nSaldoMinistracion
        '            drEdoDetAvio("SaldoGarantia") = nSaldoGarantia
        '            dtEdoDetAvio.Rows.Add(drEdoDetAvio)
        '            nImporteAcumulado += drTemporal("Interes")
        '        Next

        '        ' En esta parte proceso el importe correspondiente a la garantía líquida

        '        nImporte = nSaldoGarantia

        '        If nImporte > 0 Then

        '            nMinistracion = nMinistracion + 1
        '            nImporteAcumulado = nImporte

        '            For Each drTemporal In InteresAcumulado(cAnexo, cTipta, cReferencia, cFechaInicioIntereses, nImporte, nTasas, nDiferencialFINAGIL, cFechaTerminacionGarantia, dtTIIE, cFechaTerminacion).Rows
        '                drEdoDetAvio = dtEdoDetAvio.NewRow()
        '                drEdoDetAvio("Anexo") = cAnexo
        '                drEdoDetAvio("Ministracion") = nMinistracion
        '                drEdoDetAvio("ImporteMinistrado") = nGarantiaLiquida
        '                drEdoDetAvio("Documento") = "EFECTIVO 2"
        '                drEdoDetAvio("SaldoInicial") = nImporteAcumulado
        '                drEdoDetAvio("FechaInicial") = drTemporal("FechaInicial")
        '                drEdoDetAvio("FechaFinal") = drTemporal("FechaFinal")
        '                drEdoDetAvio("TasaInteres") = drTemporal("Tasa")
        '                drEdoDetAvio("Dias") = drTemporal("Dias")
        '                If drTemporal("FechaFinal") <= cFechaTerminacion Then
        '                    drEdoDetAvio("Interes") = drTemporal("Interes")
        '                    drEdoDetAvio("InteresMoratorio") = 0
        '                Else
        '                    drEdoDetAvio("Interes") = 0
        '                    drEdoDetAvio("InteresMoratorio") = drTemporal("Interes")
        '                End If
        '                drEdoDetAvio("InteresMoratorio") = 0
        '                drEdoDetAvio("Acumulado") = nImporteAcumulado + drTemporal("Interes")
        '                drEdoDetAvio("Sumatoria") = nSumatoria
        '                drEdoDetAvio("SumatoriaGL") = nSumatoriaGL
        '                drEdoDetAvio("UltimoPago") = cUltimoPago
        '                drEdoDetAvio("SaldoMinistracion") = nSaldoMinistracion
        '                drEdoDetAvio("SaldoGarantia") = nSaldoGarantia
        '                dtEdoDetAvio.Rows.Add(drEdoDetAvio)
        '                nImporteAcumulado += drTemporal("Interes")
        '            Next

        '        End If

        '    Next

        '    ' El dataset dsAgil contiene dos tablas: "Encabezado" y "Ministraciones", solamente dejaré "Encabezado" y aumentaré la tabla dtEdoDetAvio

        '    dsAgil.Tables.Remove("Ministraciones")
        '    dsAgil.Tables.Add(dtEdoDetAvio)

        '    ' Descomentar la siguiente línea en caso de que desee modificarse el reporte rptEdoDetAvio
        '    ' dsAgil.WriteXml("C:\frmEdoDetAvio.xml", XmlWriteMode.WriteSchema)

        '    If Val(Mid(cFecha, 7, 2)) < 10 Then
        '        cReportComments = "AL " + Mid(Mes(cFecha), 2, Len(Mes(cFecha)))
        '    Else
        '        cReportComments = "AL " + Mes(cFecha)
        '    End If
        '    newrptEdoDetAvio.SummaryInfo.ReportComments = cReportComments

        '    newrptEdoDetAvio.SetDataSource(dsAgil)
        '    CrystalReportViewer1.ReportSource = newrptEdoDetAvio

        'End If

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()
        cm3.Dispose()
        cm4.Dispose()

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class