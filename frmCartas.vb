Option Explicit On

Imports System.Data.SqlClient
Imports Microsoft.Office.Interop

Public Class frmCartas

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daClientes As New SqlDataAdapter(cm1)
        Dim dsAgil As New DataSet()
        Dim drCliente As DataRow

        ' Declaración de variables necesarias para enviar correo electrónico a través de Microsoft Outlook

        Dim oApp As Outlook._Application
        Dim oMsg As Outlook._MailItem
        Dim sSource As String
        Dim oAttachs As Outlook.Attachments
        Dim oAttach As Outlook.Attachment

        ' Este Stored Procedure trae todos los clientes que tengan cuenta de correo electrónico

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Cartas1"
            .Connection = cnAgil
        End With

        ' Llenar el DataSet a través del DataAdapter, lo cual abre y cierra la conexión

        daClientes.Fill(dsAgil, "Clientes")

        oApp = New Outlook.Application()

        Try

            For Each drCliente In dsAgil.Tables("Clientes").Rows

                oMsg = oApp.CreateItem(Outlook.OlItemType.olMailItem)
                oMsg.Subject = "Arrendadora Ágil se transformó en FINAGIL, S.A. DE C.V. SOFOM, E.N.R."
                oMsg.Body = "Bienvenido a FINAGIL, S.A. de C.V. SOFOM, E.N.R." & vbCr
                oMsg.To = RTrim(drCliente("Email1"))
                If RTrim(drCliente("Email2")) <> "*" Then
                    oMsg.CC = RTrim(drCliente("Email2"))
                Else
                    oMsg.CC = ""
                End If
                sSource = "C:\CARTA.PDF"
                oAttachs = oMsg.Attachments
                oAttach = oAttachs.Add(sSource)
                oMsg.Send()

                oAttach = Nothing
                oAttachs = Nothing
                oMsg = Nothing

            Next

        Catch eException As Exception
            MsgBox(eException.Message, MsgBoxStyle.Critical, eException.Source)
        End Try

        oApp = Nothing

        cnAgil.Dispose()
        cm1.Dispose()

        MsgBox("Envío de Cartas terminado", MsgBoxStyle.Information, "Mensaje")

    End Sub

End Class
