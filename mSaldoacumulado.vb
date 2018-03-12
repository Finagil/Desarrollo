Option Explicit On

Imports System.Data.SqlClient
Imports System.Math

Module mSaldoacumulado

    Public Function SaldoAcumulado(ByVal cAnexo As String, ByVal cFecha As String) As Decimal

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim dsAgil As New DataSet()
        Dim daSaldos As New SqlDataAdapter(cm1)
        Dim drDato As DataRow

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DameAnexo1"
            .Connection = cnAgil
            .Parameters.Add("@cAnexo", SqlDbType.NVarChar)
            .Parameters.Add("@cFecha", SqlDbType.NVarChar)
            .Parameters(0).Value = cAnexo
            .Parameters(1).Value = cFecha
        End With

        daSaldos.Fill(dsAgil, "Anexo")
        If dsAgil.Tables("Anexo").Rows.Count > 0 Then
            drDato = dsAgil.Tables("Anexo").Rows(0)
            SaldoAcumulado += drDato("Saldo")
        End If
        dsAgil.Tables.Remove("Anexo")

        cnAgil = Nothing
        dsAgil = Nothing
        cm1 = Nothing

    End Function

    Public Function AcumulaSdo(ByVal cAnexo As String, ByVal cFecha As String) As Decimal

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daSaldos As New SqlDataAdapter(cm1)
        Dim dsAgil As New DataSet()
        Dim drDato As DataRow

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "RentasXvencer1"
            .Connection = cnAgil
            .Parameters.Add("@cAnexo", SqlDbType.NVarChar)
            .Parameters.Add("@cFecha", SqlDbType.NVarChar)
            .Parameters(0).Value = cAnexo
            .Parameters(1).Value = cFecha
        End With

        daSaldos.Fill(dsAgil, "Anexo")

        If dsAgil.Tables("Anexo").Rows.Count > 0 Then
            drDato = dsAgil.Tables("Anexo").Rows(0)
            AcumulaSdo += drDato("Saldo")
        End If

        dsAgil.Tables.Remove("Anexo")

        cnAgil.Dispose()
        cm1.Dispose()

    End Function

End Module
