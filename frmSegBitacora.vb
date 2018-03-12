Option Explicit On

Imports System.Data.SqlClient
Imports System.Math
Imports CrystalDecisions.Shared

Public Class frmSegBitacora

    Private Sub btnAdeudos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdeudos.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim daClientes As New SqlDataAdapter(cm1)
        Dim daBitacora As New SqlDataAdapter(cm2)
        Dim dsAgil As New DataSet()
        Dim drCliente As DataRow
        Dim drPromesa As DataRow
        Dim drAdeudo As DataRow
        Dim dtSinpago As DataTable = New DataTable("Pendientes")

        ' Declaración de variables de datos

        Dim cFecha As String
        Dim cCliente As String
        Dim nCount As Integer
        Dim cReportTitle As String
        Dim newrptBitacora As New rptBitacora()

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

        ' Este Store Procedure trae todos los registros que tengan una Fecha de Promesa de 
        ' pago menor o igual a la Fecha solicitada

        With cm2
            .CommandType = CommandType.StoredProcedure
            .CommandText = "SegBitacora"
            .Connection = cnAgil
            .Parameters.Add("@cFecha", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        Try

            ' Llenar el DataSet lo cual abre y cierra la conexión

            daClientes.Fill(dsAgil, "Clientes")
            daBitacora.Fill(dsAgil, "Nopago")

            ' Creo la tabla que almacenara los datos del reporte

            dtSinpago.Columns.Add("Nombre", Type.GetType("System.String"))
            dtSinpago.Columns.Add("Fecllamo", Type.GetType("System.String"))
            dtSinpago.Columns.Add("Quien", Type.GetType("System.String"))
            dtSinpago.Columns.Add("Respuesta", Type.GetType("System.String"))
            dtSinpago.Columns.Add("Fecppago", Type.GetType("System.String"))
            
            For Each drCliente In dsAgil.Tables("Clientes").Rows
                cCliente = drCliente("Cliente")
                For Each drPromesa In dsAgil.Tables("Nopago").Rows
                    If drPromesa("Cliente") = cCliente And drPromesa("Fpromesa") <= cFecha Then
                        drAdeudo = dtSinpago.NewRow()
                        drAdeudo("Nombre") = drCliente("Descr")
                        drAdeudo("Fecllamo") = Mid(drPromesa("Fecha"), 7, 2) & "/" & Mid(drPromesa("Fecha"), 5, 2) & "/" & Mid(drPromesa("Fecha"), 1, 4)
                        drAdeudo("Quien") = drPromesa("Hablo")
                        drAdeudo("Respuesta") = drPromesa("Resultado")
                        drAdeudo("Fecppago") = Mid(drPromesa("Fpromesa"), 7, 2) & "/" & Mid(drPromesa("Fpromesa"), 5, 2) & "/" & Mid(drPromesa("Fpromesa"), 1, 4)
                        dtSinpago.Rows.Add(drAdeudo)
                    End If
                Next
            Next

            dsAgil.Tables.Remove("Clientes")
            dsAgil.Tables.Remove("Nopago")
            dsAgil.Tables.Add(dtSinpago)

            nCount = dsAgil.Tables("Pendientes").Rows.Count

            If nCount > 0 Then

                ' Descomentar la siguiente línea en caso de que se deseara modificar el reporte rptBitacora
                ' dsAgil.WriteXml("C:\Schema38.xml", XmlWriteMode.WriteSchema)

                cReportTitle = "Clientes con adeudo que tienen fecha promesa de pago al " & Mes(cFecha)
                newrptBitacora.SetDataSource(dsAgil)
                newrptBitacora.SummaryInfo.ReportTitle = cReportTitle
                CrystalReportViewer1.ReportSource = newrptBitacora
            Else
                MsgBox("No se tiene información en bitácora para esta fecha", MsgBoxStyle.Information, "Mensaje del Sistema")
            End If

        Catch eException As Exception

            MsgBox(eException.Source & " " & eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")

        End Try

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class