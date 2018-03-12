Option Explicit On

Imports System.Data.SqlClient

Public Class frmMinistraciones

    ' Declaración de variables de datos de alcance privado

    Dim cCiclo As String = ""
    Dim cDescCiclo As String = ""
    Dim lFirstTime As Boolean = True

    Private Sub frmMinistraciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daCiclos As New SqlDataAdapter(cm1)
        Dim dsAgil As New DataSet

        ' El siguiente Command trae los datos del ciclo vigente

        With cm1
            .CommandType = CommandType.Text
            .CommandText = "SELECT * FROM Ciclos ORDER BY Ciclo"
            .Connection = cnAgil
        End With

        ' Llenar el dataset lo cual abre y cierra la conexión

        daCiclos.Fill(dsAgil, "Ciclos")

        Dim roww As Data.DataRow = dsAgil.Tables("Ciclos").NewRow()
        roww("Ciclo") = "99"
        roww("DescCiclo") = "CUENTA CORRIENTE"
        roww("Estado") = "V"
        dsAgil.Tables("Ciclos").Rows.Add(roww)

        ' Ligar la tabla Ciclos del dataset dsAgil al ComboBox cbCiclos

        cbCiclos.DataSource = dsAgil
        cbCiclos.DisplayMember = "Ciclos.DescCiclo"
        cbCiclos.ValueMember = "Ciclos.Ciclo"
        cbCiclos.SelectedIndex = 5

        lFirstTime = False
        cCiclo = cbCiclos.SelectedValue
        cDescCiclo = cbCiclos.SelectedItem(1)

        Me.Text = "Reporte de ministraciones acumuladas"

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim cm4 As New SqlCommand()
        Dim cm5 As New SqlCommand()
        Dim daFIRA As New SqlDataAdapter(cm1)
        Dim daFINAGIL As New SqlDataAdapter(cm2)
        Dim daPagaresT As New SqlDataAdapter(cm3)
        Dim daPagaresA As New SqlDataAdapter(cm4)
        Dim daLineaFIRA As New SqlDataAdapter(cm5)

        Dim dsAgil As New DataSet
        Dim drMinistracion As DataRow
        Dim drTemporal As DataRow
        Dim drAnexo As DataRow
        Dim dtMinistraciones As New DataTable("Ministraciones")
        Dim myColArray(1) As DataColumn
        Dim myKeySearch(1) As String

        ' Declaración de variables de datos

        Dim cAnexo As String = ""
        Dim cFechaTerminacion As String = ""
        Dim cFecha As String = ""
        Dim cIDCredito As String = ""
        Dim cReportTitle As String = ""
        Dim nImporte As Decimal = 0
        Dim nLineaAutorizada As Decimal = 0
        Dim nLineaFIRA As Decimal = 0
        Dim nSumaPagaresT As Decimal = 0
        Dim nSumaPagaresA As Decimal = 0

        ' Declaración de variables de Crystal Reports

        Dim newrptRepMinistraciones As New rptRepMinistraciones()

        ' Primero creo la tabla dtMinistraciones

        dtMinistraciones.Columns.Add("Anexo", Type.GetType("System.String"))
        dtMinistraciones.Columns.Add("Ciclo", Type.GetType("System.String"))
        dtMinistraciones.Columns.Add("FechaTerminacion", Type.GetType("System.String"))
        dtMinistraciones.Columns.Add("Cliente", Type.GetType("System.String"))
        dtMinistraciones.Columns.Add("LineaAutorizada", Type.GetType("System.Decimal"))
        dtMinistraciones.Columns.Add("LineaFIRA", Type.GetType("System.Decimal"))
        dtMinistraciones.Columns.Add("IDCredito", Type.GetType("System.String"))
        dtMinistraciones.Columns.Add("SumaPagaresT", Type.GetType("System.Decimal"))
        dtMinistraciones.Columns.Add("SumaPagaresA", Type.GetType("System.Decimal"))
        dtMinistraciones.Columns.Add("MinistracionesFINAGIL", Type.GetType("System.Decimal"))
        dtMinistraciones.Columns.Add("MinistracionesFIRA", Type.GetType("System.Decimal"))

        ' Defino una LLAVE PRIMARIA COMPUESTA para la tabla dtMinistraciones (Anexo + Ciclo) para ir acumulando saldos

        myColArray(0) = dtMinistraciones.Columns("Anexo")
        myColArray(1) = dtMinistraciones.Columns("Ciclo")
        dtMinistraciones.PrimaryKey = myColArray

        cFecha = DTOC(dtpProceso.Value)

        ' El siguiente Command trae los datos de las ministraciones FIRA - FINAGIL

        If cCiclo = "99" Then
            With cm1
                .CommandType = CommandType.Text
                .CommandText = "SELECT mFIRA.*, Descr, IDCredito, Avios.FechaTerminacion FROM mFIRA " & _
                               "INNER JOIN Avios ON mFIRA.Anexo = Avios.Anexo AND mFIRA.Ciclo = Avios.Ciclo " & _
                               "INNER JOIN Clientes ON Avios.Cliente = Clientes.Cliente " & _
                               "WHERE FechaProgramada <= " & "'" & cFecha & "'" & " AND Estado = 'OTORGADO' AND Avios.Tipar = 'C' " & _
                               "ORDER BY Anexo"
                .Connection = cnAgil
            End With
        Else
            With cm1
                .CommandType = CommandType.Text
                .CommandText = "SELECT mFIRA.*, Descr, IDCredito, Avios.FechaTerminacion FROM mFIRA " & _
                               "INNER JOIN Avios ON mFIRA.Anexo = Avios.Anexo AND mFIRA.Ciclo = Avios.Ciclo " & _
                               "INNER JOIN Clientes ON Avios.Cliente = Clientes.Cliente " & _
                               "WHERE Avios.Ciclo = '" & cCiclo & "' AND FechaProgramada <= '" & cFecha & "' AND Estado = '" & "OTORGADO" & "'  AND Avios.Tipar <> 'C' " & _
                               "ORDER BY Anexo"
                .Connection = cnAgil
            End With
        End If

        ' El siguiente Command trae los datos de las ministraciones FINAGIL - Productor

        If cCiclo = "99" Then
            With cm2
                .CommandType = CommandType.Text
                .CommandText = "SELECT DetalleFINAGIL.*, Descr, LineaActual, Avios.FechaTerminacion FROM DetalleFINAGIL " & _
                               "INNER JOIN Avios ON DetalleFINAGIL.Anexo = Avios.Anexo AND DetalleFINAGIL.Ciclo = Avios.Ciclo " & _
                               "INNER JOIN Clientes ON Avios.Cliente = Clientes.Cliente " & _
                               "WHERE Concepto NOT IN ('PAGO', 'INTERESES') AND FechaFinal <= '" & cFecha & "' AND Avios.Tipar = 'C' " & _
                               "ORDER BY Anexo"
                .Connection = cnAgil
            End With
        Else
            With cm2
                .CommandType = CommandType.Text
                .CommandText = "SELECT DetalleFINAGIL.*, Descr, LineaActual, Avios.FechaTerminacion FROM DetalleFINAGIL " & _
                               "INNER JOIN Avios ON DetalleFINAGIL.Anexo = Avios.Anexo AND DetalleFINAGIL.Ciclo = Avios.Ciclo " & _
                               "INNER JOIN Clientes ON Avios.Cliente = Clientes.Cliente " & _
                               "WHERE Avios.Ciclo = '" & cCiclo & "' AND Concepto NOT IN ('PAGO', 'INTERESES') AND FechaFinal <= '" & cFecha & "' AND Avios.Tipar <> 'C' " & _
                               "ORDER BY Anexo"
                .Connection = cnAgil
            End With
        End If

        ' El siguiente Command calcula la sumatoria de todos los pagarés capturados

        If cCiclo = "99" Then
            With cm3
                .CommandType = CommandType.Text
                .CommandText = "SELECT Anexo, Ciclo, SUM(Importe) AS Sumatoria FROM PagaresAvio " & _
                               "GROUP BY Anexo, Ciclo " & _
                               "ORDER BY Anexo, Ciclo"
                .Connection = cnAgil
            End With
        Else
            With cm3
                .CommandType = CommandType.Text
                .CommandText = "SELECT Anexo, Ciclo, SUM(Importe) AS Sumatoria FROM PagaresAvio " & _
                               "WHERE Ciclo = '" & cCiclo & "' " & _
                               "GROUP BY Anexo, Ciclo " & _
                               "ORDER BY Anexo, Ciclo"
                .Connection = cnAgil
            End With
        End If

        ' El siguiente Command calcula la sumatoria de todos los pagarés capturados cuya fecha sea menor o igual a la de proceso

        If cCiclo = "99" Then
            With cm4
                .CommandType = CommandType.Text
                .CommandText = "SELECT Anexo, Ciclo, SUM(Importe) AS Sumatoria FROM PagaresAvio " & _
                               "WHERE FechaPagare <= " & "'" & cFecha & "' " & _
                               "GROUP BY Anexo, Ciclo " & _
                               "ORDER BY Anexo, Ciclo"
                .Connection = cnAgil
            End With
        Else
            With cm4
                .CommandType = CommandType.Text
                .CommandText = "SELECT Anexo, Ciclo, SUM(Importe) AS Sumatoria FROM PagaresAvio " & _
                               "WHERE Ciclo = '" & cCiclo & "' AND FechaPagare <= " & "'" & cFecha & "' " & _
                               "GROUP BY Anexo, Ciclo " & _
                               "ORDER BY Anexo, Ciclo"
                .Connection = cnAgil
            End With
        End If

        ' El siguiente Command trae los datos de las ministraciones FIRA - FINAGIL

        If cCiclo = "99" Then
            With cm5
                .CommandType = CommandType.Text
                .CommandText = "SELECT mFIRA.*, Descr FROM mFIRA " & _
                               "INNER JOIN Avios ON mFIRA.Anexo = Avios.Anexo AND mFIRA.Ciclo = Avios.Ciclo " & _
                               "INNER JOIN Clientes ON Avios.Cliente = Clientes.Cliente " & _
                               "WHERE Avios.Tipar = 'C' " & _
                               "ORDER BY Anexo"
                .Connection = cnAgil
            End With
        Else
            With cm5
                .CommandType = CommandType.Text
                .CommandText = "SELECT mFIRA.*, Descr FROM mFIRA " & _
                               "INNER JOIN Avios ON mFIRA.Anexo = Avios.Anexo AND mFIRA.Ciclo = Avios.Ciclo " & _
                               "INNER JOIN Clientes ON Avios.Cliente = Clientes.Cliente " & _
                               "WHERE Avios.Ciclo = '" & cCiclo & "' AND Avios.Tipar <> 'C' " & _
                               "ORDER BY Anexo"
                .Connection = cnAgil
            End With
        End If

        ' Llenar el dataset lo cual abre y cierra la conexión

        daFIRA.Fill(dsAgil, "FIRA")
        daFINAGIL.Fill(dsAgil, "FINAGIL")
        daPagaresT.Fill(dsAgil, "PagaresT")
        daPagaresA.Fill(dsAgil, "PagaresA")
        daLineaFIRA.Fill(dsAgil, "LineaFIRA")

        For Each drMinistracion In dsAgil.Tables("FINAGIL").Rows

            cAnexo = drMinistracion("Anexo")
            cCiclo = drMinistracion("Ciclo")
            nImporte = drMinistracion("Importe")
            nLineaAutorizada = drMinistracion("LineaActual")
            cFechaTerminacion = CTOD(drMinistracion("FechaTerminacion")).ToString("dd/MM/yyyy")

            myKeySearch(0) = cAnexo
            myKeySearch(1) = cCiclo
            drTemporal = dtMinistraciones.Rows.Find(myKeySearch)

            If drTemporal Is Nothing Then
                drTemporal = dtMinistraciones.NewRow()
                drTemporal("Anexo") = cAnexo
                drTemporal("Ciclo") = cCiclo
                drTemporal("FechaTerminacion") = cFechaTerminacion
                drTemporal("Cliente") = drMinistracion("Descr")
                drTemporal("LineaAutorizada") = nLineaAutorizada
                drTemporal("LineaFIRA") = 0
                drTemporal("IDCredito") = ""
                drTemporal("SumaPagaresT") = 0
                drTemporal("SumaPagaresA") = 0
                drTemporal("MinistracionesFIRA") = 0
                drTemporal("MinistracionesFINAGIL") = nImporte
                dtMinistraciones.Rows.Add(drTemporal)
            Else
                drTemporal("MinistracionesFINAGIL") += nImporte
            End If

        Next

        For Each drMinistracion In dsAgil.Tables("FIRA").Rows

            cAnexo = drMinistracion("Anexo")
            cCiclo = drMinistracion("Ciclo")
            cIDCredito = drMinistracion("IDCredito")
            nImporte = drMinistracion("Importe")
            cFechaTerminacion = CTOD(drMinistracion("FechaTerminacion")).ToString("dd/MM/yyyy")

            myKeySearch(0) = cAnexo
            myKeySearch(1) = cCiclo
            drTemporal = dtMinistraciones.Rows.Find(myKeySearch)

            If drTemporal Is Nothing Then
                drTemporal = dtMinistraciones.NewRow()
                drTemporal("Anexo") = cAnexo
                drTemporal("Ciclo") = cCiclo
                drTemporal("FechaTerminacion") = cFechaTerminacion
                drTemporal("Cliente") = drMinistracion("Descr")
                drTemporal("LineaFIRA") = nImporte
                drTemporal("IDCredito") = cIDCredito
                drTemporal("MinistracionesFIRA") = nImporte
                drTemporal("MinistracionesFINAGIL") = 0
                dtMinistraciones.Rows.Add(drTemporal)
            Else
                drTemporal("FechaTerminacion") = cFechaTerminacion
                drTemporal("IDCredito") = cIDCredito
                drTemporal("MinistracionesFIRA") += nImporte
            End If

        Next

        For Each drMinistracion In dsAgil.Tables("LineaFIRA").Rows

            cAnexo = drMinistracion("Anexo")
            cCiclo = drMinistracion("Ciclo")
            nImporte = drMinistracion("Importe")

            myKeySearch(0) = cAnexo
            myKeySearch(1) = cCiclo
            drTemporal = dtMinistraciones.Rows.Find(myKeySearch)

            If drTemporal Is Nothing Then
                drTemporal = dtMinistraciones.NewRow()
                drTemporal("Anexo") = cAnexo
                drTemporal("Ciclo") = cCiclo
                drTemporal("Cliente") = drMinistracion("Descr")
                drTemporal("MinistracionesFIRA") = 0
                drTemporal("MinistracionesFINAGIL") = 0
                drTemporal("LineaFIRA") = nImporte
                dtMinistraciones.Rows.Add(drTemporal)
            Else
                drTemporal("LineaFIRA") += nImporte
            End If

        Next

        ' Aquí tengo que barrer la tabla PagaresT e ir buscando en dtMinistraciones si existen el Anexo y el Ciclo
        ' para registrar el importe total de sus pagarés

        For Each drTemporal In dsAgil.Tables("PagaresT").Rows

            cAnexo = drTemporal("Anexo")
            cCiclo = drTemporal("Ciclo")
            nSumaPagaresT = drTemporal("Sumatoria")

            ' Debe buscar si ya existen el Anexo y el Ciclo en la tabla dtMinistraciones

            myKeySearch(0) = cAnexo
            myKeySearch(1) = cCiclo
            drAnexo = dtMinistraciones.Rows.Find(myKeySearch)

            If Not drAnexo Is Nothing Then
                drAnexo("SumaPagaresT") = nSumaPagaresT
            End If

        Next

        ' Aquí tengo que barrer la tabla PagaresA e ir buscando en dtMinistraciones si existen el Anexo y el Ciclo
        ' para registrar el importe total de sus pagarés acumulados a la fecha del reporte

        For Each drTemporal In dsAgil.Tables("PagaresA").Rows

            cAnexo = drTemporal("Anexo")
            cCiclo = drTemporal("Ciclo")
            nSumaPagaresA = drTemporal("Sumatoria")

            ' Debe buscar si ya existen el Anexo y el Ciclo en la tabla dtMinistraciones

            myKeySearch(0) = cAnexo
            myKeySearch(1) = cCiclo
            drAnexo = dtMinistraciones.Rows.Find(myKeySearch)

            If Not drAnexo Is Nothing Then
                drAnexo("SumaPagaresA") = nSumaPagaresA
            End If

        Next

        dsAgil.Tables.Remove("FINAGIL")
        dsAgil.Tables.Remove("FIRA")
        dsAgil.Tables.Remove("PagaresT")
        dsAgil.Tables.Remove("PagaresA")
        dsAgil.Tables.Remove("LineaFIRA")

        dsAgil.Tables.Add(dtMinistraciones)

        ' Descomentar la siguiente línea en caso de que se deseara modificar el reporte rptRepMinistraciones
        'dsAgil.WriteXml("C:\Schema30.xml", XmlWriteMode.WriteSchema)

        newrptRepMinistraciones.SetDataSource(dsAgil)
        cReportTitle = "REPORTE DE MINISTRACIONES ACUMULADAS AL " & Mes(cFecha) & " CICLO " & cDescCiclo

        If cCiclo = "99" Then
            cReportTitle = "REPORTE DE MINISTRACIONES ACUMULADAS AL " & Mes(cFecha) & " " & cDescCiclo
        End If

        newrptRepMinistraciones.SummaryInfo.ReportTitle = cReportTitle
        CrystalReportViewer1.ReportSource = newrptRepMinistraciones

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()
        cm3.Dispose()
        cm4.Dispose()
        cm5.Dispose()

    End Sub

    Private Sub cbCiclos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCiclos.SelectedIndexChanged
        If Not cbCiclos.SelectedValue Is Nothing And lFirstTime = False Then
            cCiclo = cbCiclos.SelectedValue
            cDescCiclo = cbCiclos.SelectedItem(1)
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class