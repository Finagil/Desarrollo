Option Explicit On

Imports System.Data.SqlClient

Public Class frmMinistracionFP

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim daFINAGIL As New SqlDataAdapter(cm1)
        Dim daProductores As New SqlDataAdapter(cm2)

        Dim dsAgil As New DataSet
        Dim drMinistracion As DataRow
        Dim drProductor As DataRow
        Dim drTemporal As DataRow
        Dim dtMinistraciones As New DataTable("Ministraciones")
        Dim myColArray(1) As DataColumn
        Dim myKeySearch(0) As String

        ' Declaración de variables de datos

        Dim cAnexo As String = ""
        Dim cProductor As String = ""
        Dim cDocumento As String = ""
        Dim cFecha As String
        Dim nHectareasActual As Decimal = 0
        Dim nImporte As Decimal = 0
        Dim nLineaAutorizada As Decimal = 0
        Dim cCiclo As String = "08"
        Dim cSucursal As String = "03"

        ' Primero creo la tabla dtMinistraciones

        dtMinistraciones.Columns.Add("Anexo", Type.GetType("System.String"))
        dtMinistraciones.Columns.Add("Productor", Type.GetType("System.String"))
        dtMinistraciones.Columns.Add("HectareasActual", Type.GetType("System.Decimal"))
        dtMinistraciones.Columns.Add("LineaAutorizada", Type.GetType("System.Decimal"))
        dtMinistraciones.Columns.Add("Asistencia", Type.GetType("System.Decimal"))
        dtMinistraciones.Columns.Add("Buro", Type.GetType("System.Decimal"))
        dtMinistraciones.Columns.Add("Efectivo", Type.GetType("System.Decimal"))
        dtMinistraciones.Columns.Add("Reembolso", Type.GetType("System.Decimal"))
        dtMinistraciones.Columns.Add("Gastos", Type.GetType("System.Decimal"))
        dtMinistraciones.Columns.Add("Notario", Type.GetType("System.Decimal"))
        dtMinistraciones.Columns.Add("RPP", Type.GetType("System.Decimal"))
        dtMinistraciones.Columns.Add("Seguro", Type.GetType("System.Decimal"))
        dtMinistraciones.Columns.Add("Vales", Type.GetType("System.Decimal"))
        dtMinistraciones.Columns.Add("Otros", Type.GetType("System.Decimal"))
        dtMinistraciones.Columns.Add("Total", Type.GetType("System.Decimal"))

        ' Tengo que definir una llave primaria para la tabla dtMinistraciones a fin de buscar un productor
        ' para acumular ministraciones

        myColArray(0) = dtMinistraciones.Columns("Anexo")
        dtMinistraciones.PrimaryKey = myColArray

        cFecha = DTOC(dtpProceso.Value)

        ' El siguiente Command trae los datos de las ministraciones FINAGIL - Productor

        With cm1
            .CommandType = CommandType.Text
            .CommandText = "SELECT mFINAGIL.*, LTRIM(RTRIM(Descr)) AS NombreProductor FROM mFINAGIL " & _
                           "INNER JOIN Avios ON mFINAGIL.Anexo = Avios.Anexo AND mFINAGIL.Ciclo = Avios.Ciclo " & _
                           "INNER JOIN Clientes ON Avios.Cliente = Clientes.Cliente " & _
                           "INNER JOIN Sucursales ON Clientes.Sucursal = Sucursales.ID_Sucursal " & _
                           "WHERE mFINAGIL.Ciclo = '" & cCiclo & "' AND Sucursal = '" & cSucursal & "' AND FechaAlta <= " & "'" & cFecha & "' " & _
                           "ORDER BY Anexo"
            .Connection = cnAgil
        End With

        With cm2
            .CommandType = CommandType.Text
            .CommandText = "SELECT Anexo, HectareasActual AS SumaHectareas, LineaActual AS SumaLinea FROM Avios " & _
                           "WHERE Anexo IN " & _
                           "(" & _
                           "SELECT DISTINCT mFINAGIL.Anexo FROM mFINAGIL " & _
                           "INNER JOIN Avios ON mFINAGIL.Anexo = Avios.Anexo AND mFINAGIL.Ciclo = Avios.Ciclo " & _
                           "INNER JOIN Clientes ON Avios.Cliente = Clientes.Cliente " & _
                           "INNER JOIN Sucursales ON Clientes.Sucursal = Sucursales.ID_Sucursal " & _
                           "WHERE mFINAGIL.Ciclo = '" & cCiclo & "' AND Sucursal = '" & cSucursal & "' AND FechaAlta <= " & "'" & cFecha & "' " & _
                           ") " & _
                           "AND Ciclo = '" & cCiclo & "' " & _
                           "ORDER BY Anexo"
            .Connection = cnAgil
        End With

        ' Llenar el dataset lo cual abre y cierra la conexión

        daFINAGIL.Fill(dsAgil, "FINAGIL")
        daProductores.Fill(dsAgil, "Productores")

        For Each drMinistracion In dsAgil.Tables("FINAGIL").Rows

            cAnexo = drMinistracion("Anexo")
            cProductor = drMinistracion("NombreProductor")
            nImporte = drMinistracion("Importe")
            cDocumento = Trim(drMinistracion("Documento"))

            myKeySearch(0) = cAnexo

            drTemporal = dtMinistraciones.Rows.Find(myKeySearch)

            If drTemporal Is Nothing Then

                drTemporal = dtMinistraciones.NewRow()
                drTemporal("Anexo") = cAnexo
                drTemporal("Productor") = cProductor
                drTemporal("HectareasActual") = 0
                drTemporal("LineaAutorizada") = 0
                drTemporal("Efectivo") = 0
                drTemporal("Reembolso") = 0
                drTemporal("Vales") = 0
                drTemporal("Buro") = 0
                drTemporal("Notario") = 0
                drTemporal("RPP") = 0
                drTemporal("Gastos") = 0
                drTemporal("Asistencia") = 0
                drTemporal("Seguro") = 0
                drTemporal("Otros") = 0
                drTemporal("Total") = 0

                Select Case cDocumento
                    Case "EFECTIVO"
                        drTemporal("Efectivo") += nImporte
                    Case "REEMBOLSO"
                        drTemporal("Reembolso") += nImporte
                    Case "VALE"
                        drTemporal("Vales") += nImporte
                    Case "BURO"
                        drTemporal("Buro") += nImporte
                    Case "NOTARIO"
                        drTemporal("Notario") += nImporte
                    Case "RPP"
                        drTemporal("RPP") += nImporte
                    Case "GASTOS"
                        drTemporal("Gastos") += nImporte
                    Case "ASISTENCIA"
                        drTemporal("Asistencia") += nImporte
                    Case "SEGURO"
                        drTemporal("Seguro") += nImporte
                    Case Else
                        drTemporal("Otros") += nImporte
                End Select
                drTemporal("Total") += nImporte

                dtMinistraciones.Rows.Add(drTemporal)

            Else

                Select Case cDocumento
                    Case "EFECTIVO"
                        drTemporal("Efectivo") += nImporte
                    Case "REEMBOLSO"
                        drTemporal("Reembolso") += nImporte
                    Case "VALE"
                        drTemporal("Vales") += nImporte
                    Case "BURO"
                        drTemporal("Buro") += nImporte
                    Case "NOTARIO"
                        drTemporal("Notario") += nImporte
                    Case "RPP"
                        drTemporal("RPP") += nImporte
                    Case "GASTOS"
                        drTemporal("Gastos") += nImporte
                    Case "ASISTENCIA"
                        drTemporal("Asistencia") += nImporte
                    Case "SEGURO"
                        drTemporal("Seguro") += nImporte
                    Case Else
                        drTemporal("Otros") += nImporte
                End Select
                drTemporal("Total") += nImporte

            End If

        Next

        For Each drProductor In dsAgil.Tables("Productores").Rows
            cAnexo = drProductor("Anexo")
            nHectareasActual = drProductor("SumaHectareas")
            nLineaAutorizada = drProductor("SumaLinea")
            myKeySearch(0) = cAnexo
            drTemporal = dtMinistraciones.Rows.Find(myKeySearch)
            If Not drTemporal Is Nothing Then
                drTemporal("HectareasActual") += nHectareasActual
                drTemporal("LineaAutorizada") += nLineaAutorizada
            End If
        Next

        dsAgil.Tables.Remove("FINAGIL")

        dsAgil.Tables.Add(dtMinistraciones)

        DataGridView1.DataSource = dtMinistraciones

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class