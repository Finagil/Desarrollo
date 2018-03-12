Option Explicit On

Imports System.Data.SqlClient
Imports Microsoft.Office.Interop

Public Class frmEFE

    Private Sub btnEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnviar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daFacturas As New SqlDataAdapter(cm1)
        Dim dsAgil As New DataSet()
        Dim drFactura As DataRow

        ' Declaración de variables necesarias para enviar correo electrónico a través de Microsoft Outlook

        Dim oApp As Outlook._Application
        Dim oMsg As Outlook._MailItem
        Dim sSourceXML As String = ""
        Dim sSourcePDF As String = ""
        Dim oAttachs As Outlook.Attachments
        Dim oAttach As Outlook.Attachment

        ' Declaración de variables de datos

        Dim cAnexo As String = 0
        Dim cEmail1 As String = ""
        Dim cEmail2 As String = ""
        Dim cFecha As String = ""
        Dim cSerie As String = ""
        Dim nFactura As Decimal = 0

        cFecha = DTOC(dtpFechaProceso.Value)

        ' Este Stored Procedure trae todas las facturas de una fecha determinada, de los
        ' clientes que tengan dirección de correo electrónico y que no les haya sido
        ' enviado su aviso de vencimiento de renta con anterioridad.

        With cm1
            .CommandType = CommandType.Text
            .CommandText = "SELECT DISTINCT Serie, Numero, Historia.Anexo, Clientes.Cliente, Descr, Email1, Email2 FROM Historia " & _
                           "INNER JOIN Anexos ON Historia.Anexo = Anexos.Anexo " & _
                           "INNER JOIN Clientes ON Anexos.Cliente = Clientes.Cliente " & _
                           "WHERE Serie = 'A' AND Fecha = '" & cFecha & "' AND Importe <> 0 AND Numero > 50000 AND ((Email1 <> '' AND Email1 <> '*') OR (Email2 <> '' AND Email2 <> '*')) " & _
                           "UNION ALL " & _
                           "SELECT DISTINCT Serie, Numero, Historia.Anexo, Clientes.Cliente, Descr, Email1, Email2 FROM Historia " & _
                           "INNER JOIN Avios ON Historia.Anexo = Avios.Anexo " & _
                           "INNER JOIN Clientes ON Avios.Cliente = Clientes.Cliente " & _
                           "WHERE Serie = 'A' AND Fecha = '" & cFecha & "' AND Importe <> 0 AND Numero > 50000 AND ((Email1 <> '' AND Email1 <> '*') OR (Email2 <> '' AND Email2 <> '*')) " & _
                           "UNION ALL " & _
                           "SELECT DISTINCT Serie, Numero, Historia.Anexo, Clientes.Cliente, Descr, Email1, Email2 FROM Historia " & _
                           "INNER JOIN Anexos ON Historia.Anexo = Anexos.Anexo " & _
                           "INNER JOIN Clientes ON Anexos.Cliente = Clientes.Cliente " & _
                           "WHERE Serie = 'MXL' AND Fecha = '" & cFecha & "' AND Importe <> 0 AND Numero > 300 AND ((Email1 <> '' AND Email1 <> '*') OR (Email2 <> '' AND Email2 <> '*')) " & _
                           "UNION ALL " & _
                           "SELECT DISTINCT Serie, Numero, Historia.Anexo, Clientes.Cliente, Descr, Email1, Email2 FROM Historia " & _
                           "INNER JOIN Avios ON Historia.Anexo = Avios.Anexo " & _
                           "INNER JOIN Clientes ON Avios.Cliente = Clientes.Cliente " & _
                           "WHERE Serie = 'MXL' AND Fecha = '" & cFecha & "' AND Importe <> 0 AND Numero > 300 AND ((Email1 <> '' AND Email1 <> '*') OR (Email2 <> '' AND Email2 <> '*')) " & _
                           "ORDER BY Serie, Numero"
            .Connection = cnAgil
        End With

        ' Llenar el DataSet a través del DataAdapter, lo cual abre y cierra la conexión

        daFacturas.Fill(dsAgil, "Facturas")

        oApp = New Outlook.Application()

        For Each drFactura In dsAgil.Tables("Facturas").Rows

            nFactura = drFactura("Numero")

            If nFactura <> 0 Then

                cAnexo = drFactura("Anexo")
                cSerie = Trim(drFactura("Serie"))
                cEmail1 = Trim(drFactura("Email1"))
                cEmail2 = Trim(drFactura("Email2"))

                oMsg = oApp.CreateItem(Outlook.OlItemType.olMailItem)

                oMsg.Subject = "Factura electrónica " & cSerie & CStr(nFactura) & " enviada por FINAGIL SA DE CV SOFOM ENR"

                'oMsg.Body = "Contrato : " & Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 6, 4) & vbCr & vbCr & _
                '"ESTIMADO CLIENTE : " & vbCr & vbCr & _
                '"Por este medio le estamos enviando su factura electrónica (archivo con extensión XML)" & vbCr & _
                '"así  como  la  representación  gráfica  de  la  misma  (archivo con  extensión  PDF)." & vbCr & vbCr & _
                '"Es importante recordarle que  el  documento  válido  para  la  autoridad fiscal es el" & vbCr & _
                '"archivo con extensión XML el cual deberá guardar y conservar para efectos fiscales." & vbCr

                oMsg.BodyFormat = Outlook.OlBodyFormat.olFormatHTML
                oMsg.HTMLBody = "<HTML><head></head><BODY><img src='C:\Imagen 1.png'></BODY></HTML>"

                oMsg.To = cEmail1

                If cEmail2 <> "*" And cEmail2 <> "" Then
                    oMsg.CC = cEmail2
                Else
                    oMsg.CC = ""
                End If
                If cSerie = "A" Then
                    sSourceXML = "C:\Facturas\FACTURA_A_" & CStr(nFactura) & ".XML"
                    sSourcePDF = "C:\Facturas\FACTURA_A_" & CStr(nFactura) & ".PDF"
                ElseIf cSerie = "MXL" Then
                    sSourceXML = "C:\Facturas\FACTURA_MXL_" & CStr(nFactura) & ".XML"
                    sSourcePDF = "C:\Facturas\FACTURA_MXL_" & CStr(nFactura) & ".PDF"
                End If
                oAttachs = oMsg.Attachments
                oAttach = oAttachs.Add(sSourceXML)
                oAttach = oAttachs.Add(sSourcePDF)
                oMsg.Send()

                oAttach = Nothing
                oAttachs = Nothing
                oMsg = Nothing

            End If

        Next

        oApp = Nothing

        cnAgil.Dispose()
        cm1.Dispose()

        MsgBox("Envío de facturas electrónicas terminado", MsgBoxStyle.Information, "Mensaje")

    End Sub

End Class