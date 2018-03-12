Option Explicit On

Imports System.Data.SqlClient
Imports System.Math
Imports CrystalDecisions.Shared

Public Class frmCambioFact

    Private Sub btnImprime_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnImprime.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daFactura As New SqlDataAdapter(cm1)
        Dim dsAgil As New DataSet()
        Dim drDatos As DataRow
        Dim drPago As DataRow
        Dim dtPagos As New DataTable("Pagos")

        ' Declaración de variables de datos

        Dim numero As Integer
        Dim nIva As Decimal
        Dim nSubtotal As Decimal
        Dim nTotal As Decimal
        Dim cLetras As String
        Dim cLeyenda As String
        Dim cObserva As String

        ' Declaración de variables de Crystal Reports

        Dim newrptFactura As rptFactura

        numero = txtFactura.Text

        ' Con este Stored Procedure obtengo los datos de la factura que se va reimprimir

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "ImprimeFac"
            .Connection = cnAgil
            .Parameters.Add("@Numero", SqlDbType.Int)
            .Parameters(0).Value = numero
        End With

        ' Llenar el dataset lo cual abre y cierra la conexión

        daFactura.Fill(dsAgil, "Datos")

        nIva = 0
        nSubtotal = 0
        nTotal = 0
        For Each drDatos In dsAgil.Tables("Datos").Rows
            If InStr(drDatos("Observa1"), "IVA", CompareMethod.Text) > 0 Then
                nIva = nIva + drDatos("Importe")
            Else
                nSubtotal = nSubtotal + drDatos("Importe")
            End If
            nTotal = nTotal + drDatos("Importe")
        Next
        cLetras = Letras(nTotal.ToString)

        ' Primero creo la tabla Pagos que servirá como base para la impresión de la factura de pago

        dtPagos.Columns.Add("Recibo", Type.GetType("System.String"))
        dtPagos.Columns.Add("Fecha", Type.GetType("System.String"))
        dtPagos.Columns.Add("Nombre", Type.GetType("System.String"))
        dtPagos.Columns.Add("Rfc", Type.GetType("System.String"))
        dtPagos.Columns.Add("Anexo", Type.GetType("System.String"))
        dtPagos.Columns.Add("Calle", Type.GetType("System.String"))
        dtPagos.Columns.Add("Colonia", Type.GetType("System.String"))
        dtPagos.Columns.Add("Delegacion", Type.GetType("System.String"))
        dtPagos.Columns.Add("Estado", Type.GetType("System.String"))
        dtPagos.Columns.Add("Copos", Type.GetType("System.String"))
        dtPagos.Columns.Add("Concepto", Type.GetType("System.String"))
        dtPagos.Columns.Add("Importe", Type.GetType("System.Decimal"))
        dtPagos.Columns.Add("FormaPago", Type.GetType("System.String"))
        dtPagos.Columns.Add("SubTotal", Type.GetType("System.Decimal"))
        dtPagos.Columns.Add("Iva", Type.GetType("System.Decimal"))
        dtPagos.Columns.Add("Total", Type.GetType("System.Decimal"))
        dtPagos.Columns.Add("ImporteLetra", Type.GetType("System.String"))
        dtPagos.Columns.Add("Leyenda", Type.GetType("System.String"))
        dtPagos.Columns.Add("Numero", Type.GetType("System.String"))
        dtPagos.Clear()

        numero = 0

        For numero = 1 To 3
            For Each drDatos In dsAgil.Tables("Datos").Rows
                cObserva = drDatos("observa1")
                cLeyenda = ""
                If drDatos("Letra") = "000" Then
                    cLeyenda = "El monto de esta operación es " & Format(drDatos("ImpEq") - drDatos("IvaEq"), "C")

                    If drDatos("IvaEq") > 0 Then
                        cLeyenda = cLeyenda & " y su IVA es " & Format(drDatos("IvaEq"), "C") & " los cuales serán pagados en parcialidades."
                    Else
                        cLeyenda = cLeyenda & " el cual será pagado en parcialidades."
                    End If

                ElseIf drDatos("Letra") <> "888" And drDatos("Letra") <> "999" Then
                    cObserva = Trim(cObserva) & " " & drDatos("Letra") & "/0" & CStr(drDatos("Plazo"))
                End If

                drPago = dtPagos.NewRow()
                drPago("Recibo") = Val(txtFactura.Text)
                drPago("Fecha") = "TOLUCA, ESTADO DE MEXICO A " & Mes(drDatos("Fecha"))
                drPago("Nombre") = drDatos("Descr")
                drPago("Rfc") = drDatos("RFC")
                drPago("Anexo") = drDatos("Anexo")
                drPago("Calle") = drDatos("Calle")
                drPago("Colonia") = drDatos("Colonia")
                drPago("Delegacion") = drDatos("Delegacion")
                drPago("Estado") = drDatos("descplaza")
                drPago("Copos") = drDatos("Copos")
                drPago("Concepto") = cObserva
                drPago("Importe") = drDatos("Importe")
                drPago("FormaPago") = drDatos("Cheque")
                drPago("SubTotal") = nSubtotal
                drPago("Iva") = nIva
                drPago("Total") = nTotal
                drPago("ImporteLetra") = cLetras
                drPago("Leyenda") = cLeyenda
                drPago("Numero") = numero
                dtPagos.Rows.Add(drPago)
            Next
        Next

        dsAgil.Tables.Remove("Datos")
        dsAgil.Tables.Add(dtPagos)

        ' Descomentar la siguiente línea en caso de que se deseara modificar el reporte rptFactura
        ' dsAgil.WriteXml("C:\Schema26.xml", XmlWriteMode.WriteSchema)
        newrptFactura = New rptFactura()
        newrptFactura.SetDataSource(dsAgil)
        CrystalReportViewer1.ReportSource = newrptFactura


    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class