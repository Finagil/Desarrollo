Option Explicit On

Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmMensajeria

    Private Sub frmMensajeria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim dsAgil As New DataSet()
        Dim daClientes As New SqlDataAdapter(cm1)

        ' Este Stored Procedure trae TODOS los clientes que existan en la tabla Clientes sin
        ' importar si tienen o no solicitudes dadas de alta

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "ContClie1"
            .Connection = cnAgil
        End With

        ComboBox1.MaxDropDownItems = 25

        Try

            ' Llenar el DataSet

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

    Private Sub ComboBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.Click
        txtPoliza1.Enabled = True
        txtContrato1.Enabled = True
        txtPoliza2.Enabled = True
        txtContrato2.Enabled = True
        txtPoliza3.Enabled = True
        txtContrato3.Enabled = True
        txtPoliza4.Enabled = True
        txtContrato4.Enabled = True
        txtPoliza5.Enabled = True
        txtContrato5.Enabled = True
        btnPrint.Enabled = True
        txtContrato1.Mask = "00000/0000"
        txtContrato2.Mask = "00000/0000"
        txtContrato3.Mask = "00000/0000"
        txtContrato4.Mask = "00000/0000"
        txtContrato5.Mask = "00000/0000"
    End Sub

    Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim dsAgil As New DataSet()
        Dim daCliente As New SqlDataAdapter(cm1)
        Dim daPostal As New SqlDataAdapter(cm2)
        Dim daDetener As New SqlDataAdapter(cm3)
        Dim drCliente As DataRow
        Dim drReporte As DataRow
        Dim drPostal As DataRow
        Dim drDeten As DataRow
        Dim drPostales As DataRowCollection
        Dim drRetener As DataRowCollection
        Dim dtReporte As New DataTable("Reporte")
        Dim myColArray(1) As DataColumn
        Dim myColArray2(1) As DataColumn

        Dim cCliente As String
        Dim cCusnam As String
        Dim cCalle As String
        Dim cColonia As String
        Dim cDeleg As String
        Dim cCopos As String
        Dim cPlaza As String
        Dim cReportTitle As String
        Dim i As Integer

        ' Declaración de variables de Crystal Reports

        Dim newrptMensajeria As New rptMensajeria()

        cCliente = ComboBox1.SelectedValue.ToString()
        cCusnam = RTrim(ComboBox1.Text)

        txtPoliza1.Enabled = False
        txtContrato1.Enabled = False
        txtPoliza2.Enabled = False
        txtContrato2.Enabled = False
        txtPoliza3.Enabled = False
        txtContrato3.Enabled = False
        txtPoliza4.Enabled = False
        txtContrato4.Enabled = False
        txtPoliza5.Enabled = False
        txtContrato5.Enabled = False
        btnPrint.Enabled = False

        ' Este Stored Procedure trae los datos del clientes

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DatosClie1"
            .Connection = cnAgil
            .Parameters.Add("@Cliente", SqlDbType.NVarChar)
            .Parameters(0).Value = cCliente
        End With

        With cm2
            .CommandType = CommandType.Text
            .CommandText = "SELECT Postal.*, Plazas.descPlaza FROM Postal INNER JOIN Plazas On Postal.Plaza = Plazas.Plaza"
            .Connection = cnAgil
        End With

        With cm3
            .CommandType = CommandType.Text
            .CommandText = "SELECT Retener.* FROM Retener"
            .Connection = cnAgil
        End With

        daCliente.Fill(dsAgil, "Cliente")
        daPostal.Fill(dsAgil, "Postal")
        daDetener.Fill(dsAgil, "Detener")
        myColArray(0) = dsAgil.Tables("Postal").Columns("Cliente")
        dsAgil.Tables("Postal").PrimaryKey = myColArray
        myColArray2(0) = dsAgil.Tables("Detener").Columns("Cliente")
        dsAgil.Tables("Detener").PrimaryKey = myColArray2

        drPostales = dsAgil.Tables("Postal").Rows
        drRetener = dsAgil.Tables("Detener").Rows

        drDeten = drRetener.Find(cCliente)

        If drDeten Is Nothing Then
            ' Primero creo la tabla Reporte que será la base del reporte

            dtReporte.Columns.Add("Nombre", Type.GetType("System.String"))
            dtReporte.Columns.Add("Calle", Type.GetType("System.String"))
            dtReporte.Columns.Add("Colonia", Type.GetType("System.String"))
            dtReporte.Columns.Add("Copos", Type.GetType("System.String"))
            dtReporte.Columns.Add("Deleg", Type.GetType("System.String"))
            dtReporte.Columns.Add("Plaza", Type.GetType("System.String"))
            dtReporte.Columns.Add("Poliza", Type.GetType("System.String"))
            dtReporte.Columns.Add("Contrato", Type.GetType("System.String"))

            drCliente = dsAgil.Tables("Cliente").Rows(0)
            drPostal = drPostales.Find(cCliente)

            If drPostal Is Nothing Then
                cCalle = drCliente("Calle")
                cColonia = drCliente("Colonia")
                cCopos = drCliente("Copos")
                cDeleg = drCliente("Delegacion")
                cPlaza = drCliente("DescPlaza")
                cReportTitle = " "
            Else
                cCalle = drPostal("Calle")
                cColonia = drPostal("Colonia")
                cCopos = drPostal("Copos")
                cDeleg = drPostal("Delegacion")
                cPlaza = drPostal("DescPlaza")
                cReportTitle = drPostal("Observa")
            End If

            For i = 1 To 5
                drReporte = dtReporte.NewRow()
                drReporte("Nombre") = cCusnam
                drReporte("Calle") = cCalle
                drReporte("Colonia") = cColonia
                drReporte("Copos") = cCopos
                drReporte("Deleg") = cDeleg
                drReporte("Plaza") = cPlaza

                If i = 1 And RTrim(txtPoliza1.Text) <> "" And RTrim(txtContrato1.Text) <> "" Then
                    drReporte("Poliza") = txtPoliza1.Text
                    drReporte("Contrato") = txtContrato1.Text
                    dtReporte.Rows.Add(drReporte)
                End If
                If i = 2 And RTrim(txtPoliza2.Text) <> "" And RTrim(txtContrato2.Text) <> "" Then
                    drReporte("Poliza") = txtPoliza2.Text
                    drReporte("Contrato") = txtContrato2.Text
                    dtReporte.Rows.Add(drReporte)
                End If
                If i = 3 And RTrim(txtPoliza3.Text) <> "" And RTrim(txtContrato3.Text) <> "" Then
                    drReporte("Poliza") = txtPoliza3.Text
                    drReporte("Contrato") = txtContrato3.Text
                    dtReporte.Rows.Add(drReporte)
                End If
                If i = 4 And RTrim(txtPoliza4.Text) <> "" And RTrim(txtContrato4.Text) <> "" Then
                    drReporte("Poliza") = txtPoliza4.Text
                    drReporte("Contrato") = txtContrato4.Text
                    dtReporte.Rows.Add(drReporte)
                End If
                If i = 5 And RTrim(txtPoliza5.Text) <> "" And RTrim(txtContrato5.Text) <> "" Then
                    drReporte("Poliza") = txtPoliza5.Text
                    drReporte("Contrato") = txtContrato5.Text
                    dtReporte.Rows.Add(drReporte)
                End If
            Next

            dsAgil.Tables.Remove("Cliente")
            dsAgil.Tables.Add(dtReporte)

            ' Descomentar la siguiente línea en caso de que se deseara modificar el reporte rptMensajeria
            ' dsAgil.WriteXml("C:\Schema34.xml", XmlWriteMode.WriteSchema)

            newrptMensajeria.SetDataSource(dsAgil)
            newrptMensajeria.SummaryInfo.ReportTitle = cReportTitle
            newrptMensajeria.PrintOptions.PaperOrientation = PaperOrientation.Portrait
            newrptMensajeria.PrintToPrinter(1, False, 0, 0)

        Else

            MsgBox("La información del Cliente se Detiene", MsgBoxStyle.Information, "Mensaje")

        End If

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

End Class
