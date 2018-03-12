Option Explicit On

Imports System.Data.SqlClient
Imports System.Math

Public Class frmECTC

    Private Sub frmECTC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Llenar el ComboBox cbContratos

        cbContratos.Items.Add("TODOS")
        cbContratos.Items.Add("ACTIVOS")
        cbContratos.Items.Add("TERMINADOS")
        cbContratos.SelectedIndex = 0

    End Sub

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daAnexo As New SqlDataAdapter(cm1)

        Dim dsAgil As New DataSet()
        Dim dtEdoCtaAvio As New DataTable("EdoCtaAvio")
        Dim drAnexo As DataRow
        Dim drEdoCtaAvio As DataRow
        Dim myColArray(1) As DataColumn
        Dim myKeySearch(1) As String

        ' Declaración de variables de Crystal Reports

        Dim newrptECTC As New rptECTC()
        Dim cReportTitle As String = ""
        Dim cReportComments As String = ""

        ' Declaración de variables de datos

        Dim cAnexo As String = ""
        Dim cCiclo As String = ""
        Dim cDescCiclo As String = ""
        Dim cNombreSucursal As String = ""
        Dim cFecha As String = ""
        Dim cFechaTerminacion As String = ""
        Dim cProductor As String = ""
        Dim cUltimoCorte As String = ""
        Dim cUltimoPago As String = ""
        Dim nSaldoNeto As Decimal = 0
        Dim QueryEXTCont As String = ""

        cFecha = DTOC(dtpProceso.Value)

        ' Primero creo la tabla dtEdoCtaAvio la cual deberá contener una LLAVE PRIMARIA COMPUESTA para poder ir acumulando importes por productor

        dtEdoCtaAvio.Columns.Add("NombreSucursal", Type.GetType("System.String"))
        dtEdoCtaAvio.Columns.Add("Anexo", Type.GetType("System.String"))
        dtEdoCtaAvio.Columns.Add("Ciclo", Type.GetType("System.String"))
        dtEdoCtaAvio.Columns.Add("Productor", Type.GetType("System.String"))
        dtEdoCtaAvio.Columns.Add("DescCiclo", Type.GetType("System.String"))
        dtEdoCtaAvio.Columns.Add("FechaTerminacion", Type.GetType("System.String"))
        dtEdoCtaAvio.Columns.Add("UltimoCorte", Type.GetType("System.String"))
        dtEdoCtaAvio.Columns.Add("SaldoNeto", Type.GetType("System.Decimal"))

        myColArray(0) = dtEdoCtaAvio.Columns("Anexo")
        myColArray(1) = dtEdoCtaAvio.Columns("Ciclo")
        dtEdoCtaAvio.PrimaryKey = myColArray

        'Filtro Activos / Terminados

        Select Case Mid(cbContratos.Text, 1, 2)
            Case "AC"
                QueryEXTCont = " AND Avios.FechaTerminacion >= '" & cFecha & "' "
                cReportTitle = "CONTRATOS ACTIVOS DE CREDITO DE AVIO Y CUENTA CORRIENTE CON ADEUDO"
            Case "TO"
                QueryEXTCont = ""
                cReportTitle = "CONTRATOS ACTIVOS Y TERMINADOS DE CREDITO DE AVIO Y CUENTA CORRIENTE CON ADEUDO"
            Case "TE"
                QueryEXTCont = " AND Avios.FechaTerminacion < '" & cFecha & "' "
                cReportTitle = "CONTRATOS TERMINADOS DE CREDITO DE AVIO Y CUENTA CORRIENTE CON ADEUDO"
        End Select
        
        ' Tengo que procesar todos los contratos que tengan saldo en DetalleFINAGIL

        With cm1
            .CommandType = CommandType.Text
            .CommandText = "SELECT DetalleFINAGIL.Anexo, DetalleFINAGIL.Ciclo, isnull(descr,'No Identificado') AS Descr, ISNULL(dbo.Ciclos.DescCiclo, N'Pagare ' + dbo.DetalleFINAGIL.Ciclo) as DescCiclo, UltimoCorte, FechaTerminacion, Nombre_Sucursal, Tipar, SUM(Importe+FEGA+Intereses) AS SaldoNeto FROM DetalleFINAGIL " & _
                           "INNER JOIN Avios ON DetalleFINAGIL.Anexo = Avios.Anexo and DetalleFINAGIL.Ciclo = Avios.Ciclo " & QueryEXTCont & _
                           "INNER JOIN Clientes ON DetalleFINAGIL.Cliente = Clientes.Cliente " & _
                           "INNER JOIN Sucursales ON Clientes.Sucursal = Sucursales.ID_Sucursal " & _
                           "LEFT OUTER JOIN Ciclos ON DetalleFINAGIL.Ciclo = Ciclos.Ciclo " & _
                           "GROUP BY DetalleFINAGIL.Anexo, DetalleFINAGIL.Ciclo, Descr, DescCiclo, UltimoCorte, FechaTerminacion, Nombre_Sucursal, Tipar " & _
                           "HAVING SUM(Importe + FEGA + Intereses) > 0 " & _
                           "ORDER BY DetalleFINAGIL.Anexo, DetalleFINAGIL.Ciclo"
            .Connection = cnAgil
        End With

        ' Llenar el dataset lo cual abre y cierra la conexión

        daAnexo.Fill(dsAgil, "Anexos")

        For Each drAnexo In dsAgil.Tables("Anexos").Rows

            cAnexo = drAnexo("Anexo")
            cCiclo = drAnexo("Ciclo")
            cProductor = drAnexo("Descr")
            If drAnexo("Tipar") = "C" Then
                cDescCiclo = "PAGARE " & cCiclo
            Else
                cDescCiclo = drAnexo("DescCiclo")
            End If
            cUltimoCorte = RTrim(drAnexo("UltimoCorte"))
            If cUltimoCorte <> "" Then
                cUltimoCorte = Mid(cUltimoCorte, 7, 2) + "/" + Mid(cUltimoCorte, 5, 2) + "/" + Mid(cUltimoCorte, 1, 4)
            End If
            cFechaTerminacion = RTrim(drAnexo("FechaTerminacion"))
            If cFechaTerminacion <> "" Then
                cFechaTerminacion = Mid(cFechaTerminacion, 7, 2) + "/" + Mid(cFechaTerminacion, 5, 2) + "/" + Mid(cFechaTerminacion, 1, 4)
            End If
            cNombreSucursal = drAnexo("Nombre_Sucursal")
            nSaldoNeto = drAnexo("SaldoNeto")

            myKeySearch(0) = cAnexo
            myKeySearch(1) = cCiclo

            ' Aquí puedo ir guardando los registros en la tabla general

            drEdoCtaAvio = dtEdoCtaAvio.Rows.Find(myKeySearch)
            If drEdoCtaAvio Is Nothing Then
                drEdoCtaAvio = dtEdoCtaAvio.NewRow()
                drEdoCtaAvio("NombreSucursal") = cNombreSucursal
                drEdoCtaAvio("Anexo") = cAnexo
                drEdoCtaAvio("Ciclo") = cCiclo
                drEdoCtaAvio("Productor") = cProductor
                drEdoCtaAvio("DescCiclo") = cDescCiclo
                drEdoCtaAvio("UltimoCorte") = cUltimoCorte
                drEdoCtaAvio("FechaTerminacion") = cFechaTerminacion
                dtEdoCtaAvio.Rows.Add(drEdoCtaAvio)
                drEdoCtaAvio("SaldoNeto") = nSaldoNeto
            Else
                drEdoCtaAvio("SaldoNeto") += nSaldoNeto
            End If

        Next

        dsAgil.Tables.Remove("Anexos")
        dsAgil.Tables.Add(dtEdoCtaAvio)

        ' Descomentar la siguiente línea en caso de que desee modificarse el reporte rptECTC
        ' dsAgil.WriteXml("C:\xmlECTC.xml", XmlWriteMode.WriteSchema)

        newrptECTC.SummaryInfo.ReportTitle = cReportTitle

        If Val(Mid(cFecha, 7, 2)) < 10 Then
            cReportComments = "AL " + Mid(Mes(cFecha), 2, Len(Mes(cFecha)))
        Else
            cReportComments = "AL " + Mes(cFecha)
        End If
        newrptECTC.SummaryInfo.ReportComments = cReportComments

        newrptECTC.SetDataSource(dsAgil)
        CrystalReportViewer1.ReportSource = newrptECTC
        CrystalReportViewer1.Zoom(83)

        dsAgil.Dispose()

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class