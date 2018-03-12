Option Explicit On

Imports System.Data.SqlClient
Imports System.IO

Module mSubirCE

    Public Sub SubirCE()

        ' Declaración de variables de conexión ADO .NET

        Dim cn As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim strInsert As String

        ' Declaración de variables de datos

        Dim cAcc As String
        Dim cAccAditive As String
        Dim cAccCoin As String
        Dim cAccFlow As String
        Dim cAccName As String
        Dim cAccSource As String
        Dim cAccStatus As String
        Dim cAccType As String
        Dim cAgrupador As String
        Dim cClaveFinan As String
        Dim cId As String
        Dim cIdSegNeg As String
        Dim cOtherName As String
        Dim cRenglon As String
        Dim cSegNegMovto As String
        Dim cStatusDate As String
        Dim oCatalogo As StreamReader

        cn.Open()

        oCatalogo = New StreamReader("C:\CATALOGOi.TXT")

        While (oCatalogo.Peek() > -1)

            cRenglon = oCatalogo.ReadLine()
            cId = Mid(cRenglon, 1, 3)
            cAcc = Mid(cRenglon, 4, 31)
            cAccName = Mid(cRenglon, 35, 51)
            cOtherName = Mid(cRenglon, 86, 51)
            cAccAditive = Mid(cRenglon, 137, 31)
            cAccType = Mid(cRenglon, 168, 2)
            cAccStatus = Mid(cRenglon, 170, 2)
            cClaveFinan = Mid(cRenglon, 172, 2)
            cAccFlow = Mid(cRenglon, 174, 2)
            cStatusDate = Mid(cRenglon, 176, 9)
            cAccSource = Mid(cRenglon, 185, 3)
            cAccCoin = Mid(cRenglon, 188, 5)
            cAgrupador = Mid(cRenglon, 193, 5)
            cIdSegNeg = Mid(cRenglon, 198, 5)
            cSegNegMovto = Mid(cRenglon, 203, 2)

            strInsert = "INSERT INTO Catalogo(Id, Acc, AccName, OtherName, AccAditive, AccType, AccStatus, ClaveFinan, AccFlow, StatusDate, AccSource, AccCoin, Agrupador, IdSegNeg, SegNegMovto, Alta)"
            strInsert = strInsert & " VALUES ('"
            strInsert = strInsert & cId & "', '"
            strInsert = strInsert & cAcc & "', '"
            strInsert = strInsert & cAccName & "', '"
            strInsert = strInsert & cOtherName & "', '"
            strInsert = strInsert & cAccAditive & "', '"
            strInsert = strInsert & cAccType & "', '"
            strInsert = strInsert & cAccStatus & "', '"
            strInsert = strInsert & cClaveFinan & "', '"
            strInsert = strInsert & cAccFlow & "', '"
            strInsert = strInsert & cStatusDate & "', '"
            strInsert = strInsert & cAccSource & "', '"
            strInsert = strInsert & cAccCoin & "', '"
            strInsert = strInsert & cAgrupador & "', '"
            strInsert = strInsert & cIdSegNeg & "', '"
            strInsert = strInsert & cSegNegMovto & "', '"
            strInsert = strInsert & "S"
            strInsert = strInsert & "')"
            cm1 = New SqlCommand(strInsert, cn)
            cm1.ExecuteNonQuery()

        End While

        oCatalogo.Close()
        oCatalogo = Nothing

        cn.Close()
        cn.Dispose()
        cm1.Dispose()

    End Sub

End Module
