' En este reporte la ubicación de los objetos en la interfaz gráfica depende de la opción seleccionada

Option Explicit On

Imports System.Data.SqlClient

Public Class frmConsRef

    Public Sub New(ByVal cReporte As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtReporte.Text = cReporte

    End Sub

    Private Sub frmConsRef_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim dsAgil As New DataSet()
        Dim daClientes As New SqlDataAdapter(cm1)

        If txtReporte.Text = "F" Then

            Label1.Visible = True
            DateTimePicker1.Visible = True
            Label2.Visible = True
            DateTimePicker2.Visible = True
            btnProcesar.Visible = True

        ElseIf txtReporte.Text = "C" Then

            Me.lblClientes.Location = New System.Drawing.Point(12, 17)
            Me.ComboBox1.Location = New System.Drawing.Point(12, 38)
            Me.btnProcesar.Location = New System.Drawing.Point(468, 37)
            Me.btnSalir.Location = New System.Drawing.Point(563, 37)
            lblClientes.Visible = True
            ComboBox1.Visible = True
            btnProcesar.Visible = True

            ' Este Stored Procedure trae TODOS los clientes que existan en la tabla Clientes sin importar 
            ' si tienen o no contratos o solicitudes generadas

            With cm1
                .CommandType = CommandType.StoredProcedure
                .CommandText = "ContClie1"
                .Connection = cnAgil
            End With

            ComboBox1.MaxDropDownItems = 35

            Try

                ' Llenar el DataSet

                daClientes.Fill(dsAgil, "Clientes")

                ' Ligar la tabla Clientes del dataset dsAgil al ComboBox

                ComboBox1.DataSource = dsAgil
                ComboBox1.DisplayMember = "Clientes.Descr"
                ComboBox1.ValueMember = "Clientes.Descr"

            Catch eException As Exception

                MsgBox(eException.Source & " " & eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")

            End Try

        End If

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub btnProcesar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProcesar.Click

        If txtReporte.Text = "F" Then

            ' Declaración de variables de conexión ADO .NET

            Dim cnAgil As New SqlConnection(strConn)
            Dim cm1 As New SqlCommand()
            Dim dsAgil As New DataSet()
            Dim daReferen As New SqlDataAdapter(cm1)
            Dim dtReporte As New DataTable("Reporte")
            Dim drDeposito As DataRow
            Dim drReporte As DataRow

            ' Declaración de variables de datos

            Dim cFechaIni As String
            Dim cFechaFin As String
            Dim cReportTitle As String
            Dim dFecha As Date
            Dim nCount As Integer
            Dim newrptConsRefe As New rptConsRefe1()

            cFechaIni = DTOC(DateTimePicker1.Value)
            cFechaFin = DTOC(DateTimePicker2.Value)
            Me.Text = "Depósitos Referenciados del " & CTOD(cFechaIni) & " al " & CTOD(cFechaFin)

            ' Este Stored Procedure trae TODOS los movimientos registrados en 
            ' la Tabla Referenciado del cliente solicitado

            With cm1
                .CommandType = CommandType.StoredProcedure
                .CommandText = "DatosRef1"
                .Connection = cnAgil
                .Parameters.Add("@Fechai", SqlDbType.NVarChar)
                .Parameters.Add("@Fechaf", SqlDbType.NVarChar)
                .Parameters(0).Value = cFechaIni
                .Parameters(1).Value = cFechaFin
            End With

            daReferen.Fill(dsAgil, "Movimientos")
            nCount = dsAgil.Tables("Movimientos").Rows.Count

            If nCount > 0 Then

                ' Ahora creo la tabla Anexos que será la base del reporte

                dtReporte.Columns.Add("Fecha", Type.GetType("System.String"))
                dtReporte.Columns.Add("Nombre", Type.GetType("System.String"))
                dtReporte.Columns.Add("Banco", Type.GetType("System.String"))
                dtReporte.Columns.Add("Referencia", Type.GetType("System.String"))
                dtReporte.Columns.Add("Importe", Type.GetType("System.Decimal"))

                For Each drDeposito In dsAgil.Tables("Movimientos").Rows
                    dFecha = CTOD(drDeposito("Fecha"))
                    drReporte = dtReporte.NewRow()
                    drReporte("Fecha") = dFecha.ToShortDateString
                    drReporte("Nombre") = drDeposito("Nombre")
                    drReporte("Banco") = drDeposito("Banco")
                    drReporte("Referencia") = drDeposito("Referencia")
                    drReporte("Importe") = drDeposito("Importe")
                    dtReporte.Rows.Add(drReporte)
                Next
                dsAgil.Tables.Remove("Movimientos")
                dsAgil.Tables.Add(dtReporte)

                ' Descomentar la siguiente línea en caso de que se deseara modificar el reporte rptConsRefe
                ' dsAgil.WriteXml("C:\Schema33.xml", XmlWriteMode.WriteSchema)

                newrptConsRefe.SetDataSource(dsAgil)

                cReportTitle = "DEL " & CTOD(cFechaIni) & " AL " & CTOD(cFechaFin)

                newrptConsRefe.SummaryInfo.ReportTitle = cReportTitle

                CrystalReportViewer1.ReportSource = newrptConsRefe

            Else

                MsgBox("No hay depósitos referenciados en este rango de fechas", MsgBoxStyle.Information, "Mensaje")

            End If

            cnAgil.Dispose()
            cm1.Dispose()

        ElseIf txtReporte.Text = "C" Then

            ' Declaración de variables de conexión ADO .NET

            Dim cnAgil As New SqlConnection(strConn)
            Dim cm1 As New SqlCommand()
            Dim dsAgil As New DataSet()
            Dim daReferen As New SqlDataAdapter(cm1)
            Dim dtReporte As New DataTable("Reporte")
            Dim drDeposito As DataRow
            Dim drReporte As DataRow

            ' Declaración de variables de datos

            Dim cName As String
            Dim cReportTitle As String
            Dim dFecha As Date
            Dim nCount As Integer

            ' Declaración de variables de Crystal Reports

            Dim newrptConsRefe As New rptConsRefe()

            cName = RTrim(ComboBox1.SelectedValue.ToString())
            Me.Text = "Depósitos Referenciados de " & cName

            ' Este Stored Procedure trae TODOS los movimientos registrados en 
            ' la Tabla Referenciado del cliente solicitado

            With cm1
                .CommandType = CommandType.StoredProcedure
                .CommandText = "DatosRef"
                .Connection = cnAgil
                .Parameters.Add("@Name", SqlDbType.NVarChar)
                .Parameters(0).Value = cName
            End With

            daReferen.Fill(dsAgil, "Movimientos")
            nCount = dsAgil.Tables("Movimientos").Rows.Count

            If nCount > 0 Then

                ' Ahora creo la tabla Anexos que será la base del reporte

                dtReporte.Columns.Add("Fecha", Type.GetType("System.String"))
                dtReporte.Columns.Add("Fec", Type.GetType("System.String"))
                dtReporte.Columns.Add("Banco", Type.GetType("System.String"))
                dtReporte.Columns.Add("Referencia", Type.GetType("System.String"))
                dtReporte.Columns.Add("Importe", Type.GetType("System.Decimal"))

                For Each drDeposito In dsAgil.Tables("Movimientos").Rows
                    dFecha = CTOD(drDeposito("Fecha"))
                    drReporte = dtReporte.NewRow()
                    drReporte("Fecha") = dFecha.ToShortDateString
                    drReporte("Fec") = dFecha.ToOADate
                    drReporte("Banco") = drDeposito("Banco")
                    drReporte("Referencia") = drDeposito("Referencia")
                    drReporte("Importe") = drDeposito("Importe")
                    dtReporte.Rows.Add(drReporte)
                Next
                dsAgil.Tables.Remove("Movimientos")
                dsAgil.Tables.Add(dtReporte)

                ' Descomentar la siguiente línea en caso de que se deseara modificar el reporte rptConsRefe
                ' dsAgil.WriteXml("C:\Schema33.xml", XmlWriteMode.WriteSchema)

                newrptConsRefe.SetDataSource(dsAgil)

                cReportTitle = cName
                newrptConsRefe.SummaryInfo.ReportTitle = cReportTitle

                CrystalReportViewer1.ReportSource = newrptConsRefe

            Else

                MsgBox("El Cliente no tiene depósitos referenciados", MsgBoxStyle.Information, "Mensaje")

            End If

            cnAgil.Dispose()
            cm1.Dispose()

        End If

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class