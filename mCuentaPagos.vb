Option Explicit On

Imports System.Data.SqlClient
Imports System.Math

Module mCuentaPagos

    Public Sub CuentaPagos(ByVal cAnexo As String, ByRef nPagos As Byte)

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()

        nPagos = 0

        ' Tengo que tomar los vencimientos de capital o interés (o ambos) que no hayan sido prepagados.
        ' Esto incluye vencimientos facturados y no facturados.
        ' Es otra forma de calcular el plazo de un contrato.

        With cm1
            .CommandType = CommandType.Text
            .CommandText = "SELECT COUNT(*) FROM Edoctav WHERE Anexo = '" & cAnexo & "' AND IndRec = 'S' AND Nufac <> 9999999 AND Nufac <> 7777777"
            .Connection = cnAgil
        End With

        cnAgil.Open()
        nPagos = CInt(cm1.ExecuteScalar())
        cnAgil.Close()

        cm1.Dispose()
        cnAgil.Dispose()

    End Sub

End Module
