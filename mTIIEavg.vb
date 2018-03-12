Option Explicit On

Imports System.Data.SqlClient
Imports System.Math

Module mTIIEavg

    Public Function TIIEavg(ByVal cReferencia As String) As DataTable

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daTIIE As New SqlDataAdapter(cm1)

        Dim dsAgil As New DataSet()
        Dim dtTIIEavg As New DataTable()
        Dim drTasa As DataRow
        Dim drTemporal As DataRow
        Dim myColArray(1) As DataColumn
        Dim myKeySearch(0) As String

        ' Declaración de variables de datos

        Dim cMes As String
        Dim nValor As Decimal = 0

        If cReferencia = "FINAGIL" Then

            With cm1
                .CommandType = CommandType.Text
                .CommandText = "SELECT SUBSTRING(Vigencia,1,6) AS Mes, ROUND(AVG(Valor),4) AS Promedio FROM Hista " & _
                               "WHERE Tasa = '4' " & _
                               "GROUP BY SUBSTRING(Vigencia,1,6) " & _
                               "ORDER BY SUBSTRING(Vigencia,1,6)"
                .Connection = cnAgil
            End With

            ' Llenar el dataset lo cual abre y cierra la conexión

            daTIIE.Fill(dsAgil, "TIIE")

            ' Tengo que definir una llave primaria para la tabla

            myColArray(0) = dsAgil.Tables("TIIE").Columns("Mes")
            dsAgil.Tables("TIIE").PrimaryKey = myColArray

        ElseIf cReferencia = "FIRA" Then

            ' Primero creo la tabla dtTIIEavg

            dtTIIEavg.Columns.Add("Mes", Type.GetType("System.String"))
            dtTIIEavg.Columns.Add("Promedio", Type.GetType("System.Decimal"))
            dtTIIEavg.Columns.Add("Suma", Type.GetType("System.Decimal"))
            dtTIIEavg.Columns.Add("DiasHabiles", Type.GetType("System.Decimal"))

            ' Tengo que definir una llave primaria para la tabla dtTIIEavg a fin de buscar un anexo
            ' para acumular ministraciones

            myColArray(0) = dtTIIEavg.Columns("Mes")
            dtTIIEavg.PrimaryKey = myColArray

            '  Para el promedio NO tengo que considerar la TIIE de sábados ni domingos, ni de días festivos oficiales

            With cm1
                .CommandType = CommandType.Text
                .CommandText = "SELECT * FROM Hista " & _
                               "WHERE Tasa = '4' " & _
                               "ORDER BY Vigencia"
                .Connection = cnAgil
            End With

            ' Llenar el dataset lo cual abre y cierra la conexión

            daTIIE.Fill(dsAgil, "TIIE")

            For Each drTasa In dsAgil.Tables("TIIE").Rows
                If drTasa("Festivo") <> "S" And Weekday(CTOD(drTasa("Vigencia"))) <> 1 And Weekday(CTOD(drTasa("Vigencia"))) <> 7 Then
                    cMes = Mid(drTasa("Vigencia"), 1, 6)
                    nValor = drTasa("Valor")
                    myKeySearch(0) = cMes
                    drTemporal = dtTIIEavg.Rows.Find(myKeySearch)
                    If drTemporal Is Nothing Then
                        drTemporal = dtTIIEavg.NewRow()
                        drTemporal("Mes") = cMes
                        drTemporal("Promedio") = 0
                        drTemporal("Suma") = nValor
                        drTemporal("DiasHabiles") = 1
                        dtTIIEavg.Rows.Add(drTemporal)
                    Else
                        drTemporal("Suma") += nValor
                        drTemporal("DiasHabiles") += 1
                    End If
                End If
            Next

            For Each drTasa In dtTIIEavg.Rows
                drTasa("Promedio") = Round(drTasa("Suma") / drTasa("DiasHabiles"), 4)
            Next

            dsAgil.Tables.Remove("TIIE")
            dsAgil.Tables.Add(dtTIIEavg)

        End If

        TIIEavg = dsAgil.Tables(0)

        cnAgil.Dispose()
        cm1.Dispose()

    End Function

End Module
