Option Explicit On

Imports System.Math
Imports System.Data.SqlClient

Public Class frmImpAcuses

    Inherits System.Windows.Forms.Form

    Private Sub btnImpAcuses_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnImpAcuses.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daAcuses As New SqlDataAdapter(cm1)
        Dim dsAgil As New DataSet()
        Dim drAnexo As DataRow
        Dim drAcuses As DataRow
        Dim drAnexos As DataRowCollection
        Dim dtAcuses As New DataTable("Acuses")

        ' Declaración de variables de datos

        Dim cFecha As String
        Dim cFeven As String
        Dim nCounter As Integer
        Dim newrptAcuses As New rptAcuses()

        btnImpAcuses.Enabled = False
        cFecha = DTOC(dtpFecha.Value)

        ' Con este Stored Procedure obtengo el rango de avisos solicitado.

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Avisos4"
            .Connection = cnAgil
            .Parameters.Add("@Fecha", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        ' Llenar el DataSet lo cual abre y cierra la conexión

        daAcuses.Fill(dsAgil, "Acuses")

        nCounter = dsAgil.Tables("Acuses").Rows.Count
        If nCounter > 0 Then
            drAnexos = dsAgil.Tables("Acuses").Rows

            'Creo una tabla Temporal donde almaceno los datos que formarán parte del reporte final

            dtAcuses.Columns.Add("Fecha", Type.GetType("System.String"))
            dtAcuses.Columns.Add("Descr", Type.GetType("System.String"))
            dtAcuses.Columns.Add("Factu", Type.GetType("System.String"))

            For Each drAnexo In drAnexos
                cFeven = drAnexo("Feven")

                drAcuses = dtAcuses.NewRow()
                drAcuses("Fecha") = Mid(CTOD(cFeven).ToString, 1, 10)
                drAcuses("Descr") = drAnexo("Descr")
                drAcuses("Factu") = drAnexo("Factura")
                dtAcuses.Rows.Add(drAcuses)
            Next
            dsAgil.Tables.Remove("Acuses")
            dsAgil.Tables.Add(dtAcuses)
            'Descomentar la siguiente línea en caso de que se deseara modificar el reporte rptImpreFac
            'dsAgil.WriteXml("C:\Schema8.xml", XmlWriteMode.WriteSchema)
            newrptAcuses.SetDataSource(dsAgil)
            CrystalReportViewer1.ReportSource = newrptAcuses
            CrystalReportViewer1.Visible = True
            cnAgil.Dispose()
            cm1.Dispose()
        Else
            MsgBox("No hay Avisos por Retener", MsgBoxStyle.OkOnly, "Mensaje")
            cnAgil.Dispose()
            cm1.Dispose()
            Me.Close()
        End If

    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class