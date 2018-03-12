Option Explicit On 

Imports System.Data.SqlClient
Imports System.IO

Module mGenCatal

    Public Sub GenCatal()

        ' Declaración de variables de conexión ADO .NET

        Dim cn As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daCatalogo As New SqlDataAdapter(cm1)
        Dim dsCatalogo As New DataSet()
        Dim drCuenta As DataRow
        Dim strUpdate As String

        ' Declaración de variables de datos

        Dim cCuenta As String
        Dim fs As FileStream
        Dim oCatalogo As StreamWriter

        ' Este Stored Procedure trae del Catálogo de Cuentas las cuentas que no han sido dadas de alta en ContPaq

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Catalogo2"
            .Connection = cn
        End With

        ' Llenar el DataSet a través del DataAdapter, lo cual abre y cierra la conexión

        daCatalogo.Fill(dsCatalogo, "Catalogo")

        fs = New FileStream("C:\Files\CATALOGO.TXT", FileMode.Create)
        oCatalogo = New StreamWriter(fs, System.Text.Encoding.ASCII)
        oCatalogo.WriteLine("F  1103000000000000               ")

        For Each drCuenta In dsCatalogo.Tables("Catalogo").Rows()
            cCuenta = drCuenta("Id")
            cCuenta = cCuenta & drCuenta("Acc")
            cCuenta = cCuenta & drCuenta("AccName")
            cCuenta = cCuenta & drCuenta("OtherName")
            cCuenta = cCuenta & drCuenta("AccAditive")
            cCuenta = cCuenta & drCuenta("AccType")
            cCuenta = cCuenta & drCuenta("AccStatus")
            cCuenta = cCuenta & drCuenta("ClaveFinan")
            cCuenta = cCuenta & drCuenta("AccFlow")
            cCuenta = cCuenta & drCuenta("StatusDate")
            cCuenta = cCuenta & drCuenta("AccSource")
            cCuenta = cCuenta & drCuenta("AccCoin")
            cCuenta = cCuenta & drCuenta("Agrupador")
            cCuenta = cCuenta & drCuenta("IdSegNeg")
            cCuenta = cCuenta & drCuenta("SegNegMovto")
            oCatalogo.WriteLine(cCuenta)
        Next
        oCatalogo.Close()
        oCatalogo = Nothing

        cn.Open()
        strUpdate = "UPDATE Catalogo SET Alta = 'S' WHERE Alta = 'N'"
        cm1 = New SqlCommand(strUpdate, cn)
        cm1.ExecuteNonQuery()
        cn.Close()
        cn = Nothing

    End Sub

End Module
