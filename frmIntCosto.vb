' Los archivos INGRESO.PRN y COSTO.PRN surgen de la contabilidad al emitir los movimientos auxiliares de todo el año
' Las cuentas 5201 01 02 y 5201 02 02 deben conformar el archivo INGRESO.PRN
' Las cuentas 5201 01 01 y 5201 02 01 deben conformar el archivo COSTO.PRN

Option Explicit On

Imports System.Data.SqlClient
Imports System.IO

Public Class frmIntCosto

    Private Sub frmIntCosto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '' Declaración de variables de conexión ADO .NET

        'Dim cnAgil As New SqlConnection(strConn)
        'Dim cm1 As New SqlCommand()
        'Dim daMovimientos As New SqlDataAdapter(cm1)

        'Dim dsAgil As New DataSet()
        'Dim dtCosto As New DataTable("Costo")
        'Dim drCosto As DataRow
        'Dim drMovimiento As DataRow
        'Dim myColArray(1) As DataColumn

        '' Declaración de variables de datos

        'Dim cAnexo As String = ""
        'Dim cFeven As String = ""
        'Dim i As Integer = 0
        'Dim myKeySearch(0) As String
        'Dim nImporte As Decimal = 0
        'Dim nColumna As Integer

        '' Primero creo la tabla dtDepoRefe que será la base del reporte

        'dtCosto.Columns.Add("Anexo", Type.GetType("System.String"))

        'For i = 1 To 70
        '    If i < 10 Then
        '        dtCosto.Columns.Add("0" + CStr(i), Type.GetType("System.Decimal"))
        '    Else
        '        dtCosto.Columns.Add(CStr(i), Type.GetType("System.Decimal"))
        '    End If
        'Next

        '' Tengo que definir una llave primaria para la tabla dtCosto a fin de buscar un anexo
        '' para acumular saldos

        'myColArray(0) = dtCosto.Columns("Anexo")
        'dtCosto.PrimaryKey = myColArray

        'With cm1
        '    .CommandType = CommandType.Text
        '    .CommandText = "SELECT Anexo, Feven, IvaOt AS Capital FROM Facturas WHERE Anexo IN ( " & _
        '    "SELECT Anexo FROM Anexos " & _
        '    "INNER JOIN Clientes ON Anexos.Cliente = Clientes.Cliente " & _
        '    "WHERE Promo IN ('004','006','008') AND Flcan <> 'B' AND Flcan <> 'S' AND Fechacon >= '20040831' AND Fechacon <= '20100731' " & _
        '    ") AND LEFT(Feven,6) <= '201007' " & _
        '    "ORDER BY Anexo, Feven"
        '    .Connection = cnAgil
        'End With

        '' Llenar el DataSet lo cual abre y cierra la conexión

        'daMovimientos.Fill(dsAgil, "Movimientos")

        'For Each drMovimiento In dsAgil.Tables("Movimientos").Rows

        '    cAnexo = drMovimiento("Anexo")
        '    cFeven = drMovimiento("Feven")
        '    nImporte = drMovimiento("Capital")

        '    myKeySearch(0) = cAnexo

        '    drCosto = dtCosto.Rows.Find(myKeySearch)

        '    nColumna = (Val(Mid(cFeven, 1, 4)) * 12) + Val(Mid(cFeven, 5, 2)) - 24057

        '    If drCosto Is Nothing Then
        '        drCosto = dtCosto.NewRow()
        '        For i = 1 To 70
        '            drCosto(i) = 0
        '        Next
        '        drCosto("Anexo") = cAnexo
        '        drCosto(nColumna) = nImporte
        '        dtCosto.Rows.Add(drCosto)
        '    Else
        '        drCosto(nColumna) = nImporte
        '    End If

        'Next

        'DataGridView1.DataSource = dtCosto

        'cnAgil.Dispose()
        'cm1.Dispose()

        ' Declaración de variables de conexión ADO .NET

        Dim dtCosto As New DataTable("Costo")
        Dim drCosto As DataRow
        Dim myColArray(1) As DataColumn

        ' Declaración de variables de datos

        Dim cAnexo As String
        Dim cConcepto As String
        Dim cRenglon As String
        Dim myKeySearch(0) As String
        Dim nImporte As Decimal

        Dim oArchivo As StreamReader

        ' Primero creo la tabla dtDepoRefe que será la base del reporte

        dtCosto.Columns.Add("Anexo", Type.GetType("System.String"))
        dtCosto.Columns.Add("Ingreso", Type.GetType("System.Decimal"))
        dtCosto.Columns.Add("Costo", Type.GetType("System.Decimal"))
        dtCosto.Columns.Add("Amortiza", Type.GetType("System.Decimal"))
        dtCosto.Columns.Add("Traspasos", Type.GetType("System.Decimal"))
        dtCosto.Columns.Add("Prepagos", Type.GetType("System.Decimal"))
        dtCosto.Columns.Add("Polizas", Type.GetType("System.Decimal"))

        ' Tengo que definir una llave primaria para la tabla dtCosto a fin de buscar un anexo
        ' para acumular saldos

        myColArray(0) = dtCosto.Columns("Anexo")
        dtCosto.PrimaryKey = myColArray

        If File.Exists("C:\FILES\INGRESO.PRN") Then

            oArchivo = New StreamReader("C:\FILES\INGRESO.PRN")

            While (oArchivo.Peek() > -1)

                cRenglon = oArchivo.ReadLine()

                cAnexo = Mid(cRenglon, 83, 10)

                If Mid(cAnexo, 6, 1) = "/" Then

                    cConcepto = Mid(cRenglon, 45, 20)

                    nImporte = 0

                    If Trim(Mid(cRenglon, 117, 20)) <> "" Then
                        nImporte = Mid(cRenglon, 117, 20)
                    ElseIf Trim(Mid(cRenglon, 97, 20)) <> "" Then
                        nImporte = Mid(cRenglon, 97, 20)
                        nImporte = nImporte * -1
                    End If

                    myKeySearch(0) = cAnexo

                    drCosto = dtCosto.Rows.Find(myKeySearch)

                    If drCosto Is Nothing Then
                        drCosto = dtCosto.NewRow()
                        drCosto("Anexo") = cAnexo
                        drCosto("Ingreso") = nImporte
                        drCosto("Costo") = 0
                        drCosto("Amortiza") = 0
                        drCosto("Traspasos") = 0
                        drCosto("Prepagos") = 0
                        drCosto("Polizas") = 0
                        dtCosto.Rows.Add(drCosto)
                    Else
                        drCosto("Ingreso") += nImporte
                    End If

                End If

            End While

            oArchivo.Close()

        End If

        ' Ahora procedo a leer el archivo del costo

        If File.Exists("C:\FILES\COSTO.PRN") Then

            oArchivo = New StreamReader("C:\FILES\COSTO.PRN")

            While (oArchivo.Peek() > -1)

                cRenglon = oArchivo.ReadLine()

                cAnexo = Mid(cRenglon, 83, 10)

                If Mid(cAnexo, 6, 1) = "/" Then

                    cConcepto = Trim(Mid(cRenglon, 45, 20))

                    nImporte = 0

                    If Trim(Mid(cRenglon, 97, 20)) <> "" Then
                        nImporte = Mid(cRenglon, 97, 20)
                    ElseIf Trim(Mid(cRenglon, 117, 20)) <> "" Then
                        nImporte = Mid(cRenglon, 117, 20)
                        nImporte = nImporte * -1
                    End If

                    myKeySearch(0) = cAnexo

                    drCosto = dtCosto.Rows.Find(myKeySearch)

                    If drCosto Is Nothing Then
                        drCosto = dtCosto.NewRow()
                        drCosto("Anexo") = cAnexo
                        drCosto("Ingreso") = 0
                        drCosto("Costo") = nImporte
                        If cConcepto = "ALTA DE OPERACIONES" Then
                            drCosto("Amortiza") = nImporte
                            drCosto("Traspasos") = 0
                            drCosto("Prepagos") = 0
                            drCosto("Polizas") = 0
                        ElseIf cConcepto = "TRASPASOS DE CARTERA" Then
                            drCosto("Amortiza") = 0
                            drCosto("Traspasos") = nImporte
                            drCosto("Prepagos") = 0
                            drCosto("Polizas") = 0
                        ElseIf cConcepto = "INGRESOS" Then
                            drCosto("Amortiza") = 0
                            drCosto("Traspasos") = 0
                            drCosto("Prepagos") = nImporte
                            drCosto("Polizas") = 0
                        Else
                            drCosto("Amortiza") = 0
                            drCosto("Traspasos") = 0
                            drCosto("Prepagos") = 0
                            drCosto("Polizas") = nImporte
                        End If
                        dtCosto.Rows.Add(drCosto)
                    Else
                        drCosto("Costo") += nImporte
                        If cConcepto = "ALTA DE OPERACIONES" Then
                            drCosto("Amortiza") += nImporte
                        ElseIf cConcepto = "TRASPASOS DE CARTERA" Then
                            drCosto("Traspasos") += nImporte
                        ElseIf cConcepto = "INGRESOS" Then
                            drCosto("Prepagos") += nImporte
                        Else
                            drCosto("Polizas") += nImporte
                        End If
                    End If

                End If

            End While

            oArchivo.Close()

        End If

        DataGridView1.DataSource = dtCosto

    End Sub

End Class