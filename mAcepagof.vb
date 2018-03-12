Option Explicit On 

Imports System.Data.SqlClient
Imports System.Math

Module mAcepagof

    Public Sub Acepagof(ByVal cAnexo As String, ByVal cLetra As String, ByVal nMontoPago As Decimal, ByVal cBanco As String, ByVal cCheque As String, ByRef dtMovimientos As DataTable, ByVal cFecha As String, ByVal nTasaIVACliente As Decimal)

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim drMovimiento As DataRow
        Dim strInsert As String
        Dim strUpdate As String

        ' Declaración de variables de datos

        Dim nIvaOpcion As Decimal
        Dim nNumero As Decimal
        Dim nOpcion As Decimal

        nNumero = 888888

        nOpcion = Round(nMontoPago / (1 + (nTasaIVACliente / 100)), 2)
        nIvaOpcion = Round(nMontoPago - nOpcion, 2)

        drMovimiento = dtMovimientos.NewRow()
        drMovimiento("Anexo") = cAnexo
        drMovimiento("Letra") = "888"
        drMovimiento("Tipos") = "3"
        drMovimiento("Fepag") = cFecha
        drMovimiento("Cve") = "36"
        drMovimiento("Imp") = nMontoPago
        drMovimiento("Tip") = "S"
        drMovimiento("Catal") = "F"
        drMovimiento("Esp") = 0
        drMovimiento("Coa") = "1"
        drMovimiento("Tipmon") = "01"
        drMovimiento("Banco") = cBanco
        dtMovimientos.Rows.Add(drMovimiento)

        drMovimiento = dtMovimientos.NewRow()
        drMovimiento("Anexo") = cAnexo
        drMovimiento("Letra") = "888"
        drMovimiento("Tipos") = "3"
        drMovimiento("Fepag") = cFecha
        drMovimiento("Cve") = "09"
        drMovimiento("Imp") = nIvaOpcion
        drMovimiento("Tip") = "S"
        drMovimiento("Catal") = "F"
        drMovimiento("Esp") = 0
        drMovimiento("Coa") = "0"
        drMovimiento("Tipmon") = "01"
        drMovimiento("Banco") = cBanco
        dtMovimientos.Rows.Add(drMovimiento)

        drMovimiento = dtMovimientos.NewRow()
        drMovimiento("Anexo") = cAnexo
        drMovimiento("Letra") = "888"
        drMovimiento("Tipos") = "3"
        drMovimiento("Fepag") = cFecha
        drMovimiento("Cve") = "18"
        drMovimiento("Imp") = nIvaOpcion
        drMovimiento("Tip") = "S"
        drMovimiento("Catal") = "F"
        drMovimiento("Esp") = 0
        drMovimiento("Coa") = "1"
        drMovimiento("Tipmon") = "01"
        drMovimiento("Banco") = cBanco
        dtMovimientos.Rows.Add(drMovimiento)

        Try

            cnAgil.Open()

            strInsert = "INSERT INTO Historia(Documento, Serie, Numero, Fecha, Anexo, Letra, Banco, Cheque, Balance, Importe, Observa1) "
            strInsert = strInsert & " VALUES ('"
            strInsert = strInsert & "7" & "', '"
            strInsert = strInsert & "B" & "', "
            strInsert = strInsert & nNumero & ", '"
            strInsert = strInsert & cFecha & "', '"
            strInsert = strInsert & cAnexo & "', '"
            strInsert = strInsert & "888" & "', '"
            strInsert = strInsert & cBanco & "', '"
            strInsert = strInsert & cCheque & "', '"
            strInsert = strInsert & "N" & "', '"
            strInsert = strInsert & nOpcion & "', '"
            strInsert = strInsert & "OPCION DE COMPRA"
            strInsert = strInsert & "')"
            cm1 = New SqlCommand(strInsert, cnAgil)
            cm1.ExecuteNonQuery()

            strInsert = "INSERT INTO Historia(Documento, Serie, Numero, Fecha, Anexo, Letra, Banco, Cheque, Balance, Importe, Observa1) "
            strInsert = strInsert & " VALUES ('"
            strInsert = strInsert & "7" & "', '"
            strInsert = strInsert & "B" & "', "
            strInsert = strInsert & nNumero & ", '"
            strInsert = strInsert & cFecha & "', '"
            strInsert = strInsert & cAnexo & "', '"
            strInsert = strInsert & "888" & "', '"
            strInsert = strInsert & cBanco & "', '"
            strInsert = strInsert & cCheque & "', '"
            strInsert = strInsert & "N" & "', '"
            strInsert = strInsert & nIvaOpcion & "', '"
            strInsert = strInsert & "IVA OPCION DE COMPRA"
            strInsert = strInsert & "')"
            cm1 = New SqlCommand(strInsert, cnAgil)
            cm1.ExecuteNonQuery()

            ' Debe marcar la Opción de Compra como pagada

            strUpdate = "UPDATE Opciones SET Pagado = '" & "S" & "' WHERE Anexo = '" & cAnexo & "'"
            cm1 = New SqlCommand(strUpdate, cnAgil)
            cm1.ExecuteNonQuery()

            cnAgil.Close()

            cnAgil.Dispose()
            cm1.Dispose()

        Catch eException As Exception

            MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")

        End Try

    End Sub

End Module
