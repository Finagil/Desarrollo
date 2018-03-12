Option Explicit On

Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmRE

    ' Declaración de variables de datos de alcance privado

    Dim cAnexo As String

    Private Sub frmRE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mtxtContrato.Mask = "00000/0000"
    End Sub

    Private Sub btnCertificado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCertificado.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim daCertif As New SqlDataAdapter(cm1)
        Dim daPagares As New SqlDataAdapter(cm2)

        Dim dsAgil As New DataSet()
        Dim drCertificado As DataRow

        ' Declaración de variables de Crystal Reports

        Dim newrptCertificado As New rptCertificado()

        cAnexo = Mid(mtxtContrato.Text, 1, 5) + Mid(mtxtContrato.Text, 7, 4)

        With cm1
            .CommandType = CommandType.Text
            .CommandText = "SELECT Avios.*, Descr FROM Avios " & _
            "INNER JOIN Clientes ON Avios.Cliente = Clientes.Cliente " & _
            "WHERE Avios.Anexo = " & "'" & cAnexo & "'"
            .Connection = cnAgil
            .Parameters.Add("@Anexo", SqlDbType.NVarChar)
            .Parameters(0).Value = cAnexo
        End With

        With cm2
            .CommandType = CommandType.Text
            .CommandText = "SELECT * FROM PagaresAvio WHERE Anexo = " & "'" & cAnexo & "'"
            .Connection = cnAgil
        End With

        Try

            ' Llenar el DataSet lo cual abre y cierra la conexión

            daCertif.Fill(dsAgil, "Certificado")
            daPagares.Fill(dsAgil, "Pagares")

            drCertificado = dsAgil.Tables("Certificado").Rows(0)

            If drCertificado("FechaAutorizacion") = 0 Or drCertificado("LineaActual") = 0 Or drCertificado("HectareasActual") = 0 Then

                MsgBox("Falta fecha de autorización, Línea Autorizada o No. de Hectáreas a habilitar", MsgBoxStyle.Critical, "Mensaje del Sistema")

            Else

                ' Descomentar la siguiente línea en caso de que se deseara modificar el reporte rptCertificado
                ' dsAgil.WriteXml("C:\Schema20.xml", XmlWriteMode.WriteSchema)

                newrptCertificado.SetDataSource(dsAgil)
                CrystalReportViewer1.ReportSource = newrptCertificado

            End If

        Catch eException As Exception

            MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")

        End Try

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()

    End Sub

End Class