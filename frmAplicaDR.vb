Option Explicit On

Imports System.Data.SqlClient
Imports System.Math

Public Class frmAplicaDR

    ' Declaración de variables de conexión ADO .NET de alcance privado

    Dim drUdis As DataRowCollection

    ' Declaración de variables de datos de alcance privado

    Dim nElementos As Integer = 0
    Dim nIDSerieA As Decimal = 0
    Dim nIDSerieMXL As Decimal = 0
    Dim cSerie As String = ""
    Dim cSucursal As String = ""
    Dim nTasaIVACliente As Decimal = 0

    Private Sub frmAplicaDR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.Visible = False
    End Sub

    Private Sub btnContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinuar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim daReferenciados As New SqlDataAdapter(cm1)
        Dim daUdis As New SqlDataAdapter(cm2)
        Dim daFacturas As New SqlDataAdapter(cm3)

        Dim dsAgil As New DataSet()
        Dim drReferenciado As DataRow
        Dim drSaldo As DataRow

        ' Declaración de variables de datos

        Dim cAnexo As String = ""
        Dim cTipar As String = ""
        Dim cTipo As String = ""
        Dim nSaldo As Decimal = 0
        Dim nDiasMoratorios As Decimal = 0
        Dim nTasaMoratoria As Decimal = 0
        Dim nMoratorios As Decimal = 0
        Dim nIvaMoratorios As Decimal = 0
        Dim nSaldoTotal As Decimal = 0
        Dim cFeven As String = ""
        Dim cFepag As String = ""
        Dim cFechaPago As String = ""
        Dim i As Integer = 0

        Me.Size = New Size(1032, 768)
        cFechaPago = DTOC(dtpFechaReferenciado.Value)

        ' El siguiente Command trae los depósitos referenciados que no hayan sido aplicados

        With cm1
            .CommandType = CommandType.Text
            .CommandText = "SELECT SUBSTRING(Fecha, 7, 2) + '/' + SUBSTRING(Fecha, 5, 2) + '/' + SUBSTRING(Fecha, 1, 4) AS Fecha, Banco, Referencia AS Contrato, Nombre, Importe, 0.00 As Adeudo, 0.00 As Diferencia, RefBanco FROM Referenciado " & _
                           "WHERE Fecha = '" & cFechaPago & "' AND Aplicado = 'N' " & _
                           "ORDER BY Fecha, Banco, Referencia"
            .Connection = cnAgil
        End With

        daReferenciados.Fill(dsAgil, "Referenciados")
        nElementos = dsAgil.Tables("Referenciados").Rows.Count - 1

        ' Este Stored Procedure regresa todas las UDIS ordenadas por vigencia

        With cm2
            .CommandType = CommandType.StoredProcedure
            .CommandText = "TraeUdis1"
            .Connection = cnAgil
        End With

        daUdis.Fill(dsAgil, "Udis")

        ' También genero el DataRowCollection drUdis ya que necesito enviarlo como
        ' argumento a la función CalcMora que calcula los moratorios ya que esta lo
        ' envía a su vez a la función CalcIvaU.

        drUdis = dsAgil.Tables("Udis").Rows

        For Each drReferenciado In dsAgil.Tables("Referenciados").Rows

            cAnexo = Mid(drReferenciado("Contrato"), 1, 5) + Mid(drReferenciado("Contrato"), 7, 4)
            cFechaPago = Mid(drReferenciado("Fecha"), 7, 4) + Mid(drReferenciado("Fecha"), 4, 2) + Mid(drReferenciado("Fecha"), 1, 2)
            nSaldoTotal = 0

            ' El siguiente Command trae los datos de las facturas no pagadas de un anexo determinado

            With cm3
                .CommandType = CommandType.Text
                .CommandText = "SELECT Facturas.Anexo, Letra, Factura, Feven, Fepag, SaldoFac AS Saldo, 0 AS MontoPago, ((Facturas.Tasa + Facturas.Difer) * 2.0) AS TasaMoratoria, Anexos.Tipar, Clientes.Tipo, Clientes.Sucursal, Clientes.TasaIVACliente FROM Facturas " & _
                               "INNER JOIN Anexos ON Facturas.Anexo = Anexos.Anexo " & _
                               "INNER JOIN Clientes ON Anexos.Cliente = Clientes.Cliente " & _
                               "WHERE Facturas.Anexo = '" & cAnexo & "' AND IndPag <> 'P' AND SaldoFac > 0 " & _
                               "ORDER BY Facturas.Anexo, Letra"
                .Connection = cnAgil
            End With

            daFacturas.Fill(dsAgil, "Facturas")

            For Each drSaldo In dsAgil.Tables("Facturas").Rows

                cTipar = drSaldo("Tipar")
                cTipo = drSaldo("Tipo")
                nSaldo = drSaldo("Saldo")
                nDiasMoratorios = 0
                nTasaMoratoria = drSaldo("TasaMoratoria")
                nMoratorios = 0
                nIvaMoratorios = 0
                cFeven = drSaldo("Feven")
                cFepag = drSaldo("Fepag")

                ' Traigo la Tasa de IVA que aplica al cliente a efecto de poder determinar correctamente el IVA de los Moratorios

                nTasaIVACliente = drSaldo("TasaIVACliente")

                If Trim(cFepag) = "" Then
                    nDiasMoratorios = DateDiff(DateInterval.Day, CTOD(cFeven), CTOD(cFechaPago))
                Else
                    If cFeven >= cFepag Then
                        nDiasMoratorios = DateDiff(DateInterval.Day, CTOD(cFeven), CTOD(cFechaPago))
                    Else
                        nDiasMoratorios = DateDiff(DateInterval.Day, CTOD(cFepag), CTOD(cFechaPago))
                    End If
                End If
                If nDiasMoratorios < 0 Then
                    nDiasMoratorios = 0
                End If

                If nDiasMoratorios > 0 Then
                    CalcMora(cTipar, cTipo, cFechaPago, drUdis, nSaldo, nTasaMoratoria, nDiasMoratorios, nMoratorios, nIvaMoratorios, nTasaIVACliente)
                End If

                nSaldoTotal += nSaldo + nMoratorios + nIvaMoratorios

            Next

            drReferenciado("Adeudo") = nSaldoTotal
            drReferenciado("Diferencia") = nSaldoTotal - drReferenciado("Importe")

            dsAgil.Tables.Remove("Facturas")

        Next

        DataGridView1.DataSource = dsAgil.Tables("Referenciados")
        DataGridView1.Columns(8).Visible = False

        For i = 0 To DataGridView1.Columns.Count - 1
            DataGridView1.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            If i = 0 Or i = 1 Or i = 3 Then
                DataGridView1.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alinea el encabezado
            ElseIf i >= 5 Then
                DataGridView1.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight  ' Alinea el encabezado
            End If
        Next

        For i = 0 To dsAgil.Tables("Referenciados").Rows.Count - 1
            If DataGridView1.Rows(i).Cells(7).Value = 0 Then
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Aquamarine
                ' DataGridView1.Rows(i).Cells(0).Value = True
            ElseIf Abs(DataGridView1.Rows(i).Cells(7).Value) <= 30 Then
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Aquamarine
                ' DataGridView1.Rows(i).Cells(0).Value = True
            End If
        Next

        DataGridView1.Visible = True

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()
        cm3.Dispose()

    End Sub

    Private Sub btnAplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAplicar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim cm4 As New SqlCommand()
        Dim daSeries As New SqlDataAdapter(cm1)
        Dim daFacturas As New SqlDataAdapter(cm2)

        Dim dsAgil As New DataSet()
        Dim dtMovimientos As New DataTable("Movimientos")
        Dim drMovimiento As DataRow
        Dim drSaldo As DataRow
        Dim drSerie As DataRow
        Dim strUpdate As String = ""
        Dim strInsert As String = ""

        ' Declaración de variables de datos

        Dim cBanco As String = ""
        Dim cCheque As String = ""
        Dim cAnexo As String = ""
        Dim cReferencia As String = ""
        Dim cLetra As String = ""
        Dim cTipar As String = ""
        Dim cTipo As String = ""
        Dim nImporte As Decimal = 0
        Dim nSaldo As Decimal = 0
        Dim nDiasMoratorios As Decimal = 0
        Dim nTasaMoratoria As Decimal = 0
        Dim nMoratorios As Decimal = 0
        Dim nIvaMoratorios As Decimal = 0
        Dim nMontoPago As Decimal = 0
        Dim cFeven As String = ""
        Dim cFepag As String = ""
        Dim cFechaPago As String = ""
        Dim cFechaAplicacion As String = ""
        Dim i As Integer = 0
        Dim nRecibo As Decimal = 0

        cFechaAplicacion = DTOC(dtpFechaAplicacion.Value)

        ' Primero creo la tabla Movimientos que contendrá los registros contables de la cobranza

        dtMovimientos.Columns.Add("Anexo", Type.GetType("System.String"))
        dtMovimientos.Columns.Add("Letra", Type.GetType("System.String"))
        dtMovimientos.Columns.Add("Tipos", Type.GetType("System.String"))
        dtMovimientos.Columns.Add("Fepag", Type.GetType("System.String"))
        dtMovimientos.Columns.Add("Cve", Type.GetType("System.String"))
        dtMovimientos.Columns.Add("Imp", Type.GetType("System.Decimal"))
        dtMovimientos.Columns.Add("Tip", Type.GetType("System.String"))
        dtMovimientos.Columns.Add("Catal", Type.GetType("System.String"))
        dtMovimientos.Columns.Add("Esp", Type.GetType("System.Decimal"))
        dtMovimientos.Columns.Add("Coa", Type.GetType("System.String"))
        dtMovimientos.Columns.Add("Tipmon", Type.GetType("System.String"))
        dtMovimientos.Columns.Add("Banco", Type.GetType("System.String"))

        ' El siguiente Command trae los consecutivos de cada Serie

        With cm1
            .CommandType = CommandType.Text
            .CommandText = "SELECT IDSerieA, IDSerieMXL FROM Llaves"
            .Connection = cnAgil
        End With

        ' Llenar el DataSet lo cual abre y cierra la conexión

        daSeries.Fill(dsAgil, "Series")

        ' Toma el número consecutivo de facturas de pago -que depende de la Serie- y lo incrementa en uno

        drSerie = dsAgil.Tables("Series").Rows(0)
        nIDSerieA = drSerie("IDSerieA")
        nIDSerieMXL = drSerie("IDSerieMXL")

        ' Solo necesito saber el número de elementos que tiene el DataGridView1

        For i = 0 To nElementos

            If DataGridView1.Rows(i).Cells(0).Value = True Then

                ' Se trata de un depósito seleccionado para su aplicación aunque pudiera tratarse de un 
                ' contrato que adeude más de una letra por lo que debe aplicar el pago en forma
                ' individualizada

                cFechaPago = Mid(DataGridView1.Rows(i).Cells(1).Value, 7, 4) + Mid(DataGridView1.Rows(i).Cells(1).Value, 4, 2) + Mid(DataGridView1.Rows(i).Cells(1).Value, 1, 2)
                cBanco = DataGridView1.Rows(i).Cells(2).Value
                cReferencia = DataGridView1.Rows(i).Cells(3).Value
                nImporte = DataGridView1.Rows(i).Cells(5).Value         ' Monto total pagado vía depósito referenciado
                cCheque = Trim(DataGridView1.Rows(i).Cells(8).Value)
                If cCheque = "" Then
                    cCheque = "DR " + cFechaPago
                Else
                    cCheque = Mid(cFechaPago, 7, 2) + Mid(cFechaPago, 5, 2) + " " + cCheque
                End If

                cAnexo = Mid(cReferencia, 1, 5) + Mid(cReferencia, 7, 4)

                With cm2
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT Facturas.Anexo, Letra, Factura, Feven, Fepag, SaldoFac AS Saldo, 0 AS MontoPago, ((Facturas.Tasa + Facturas.Difer) * 2.0) AS TasaMoratoria, Anexos.Tipar, Clientes.Tipo, Clientes.Sucursal, Clientes.TasaIVACliente FROM Facturas " & _
                                   "INNER JOIN Anexos ON Facturas.Anexo = Anexos.Anexo " & _
                                   "INNER JOIN Clientes ON Anexos.Cliente = Clientes.Cliente " & _
                                   "WHERE Facturas.Anexo = '" & cAnexo & "' AND IndPag <> 'P' AND SaldoFac > 0 " & _
                                   "ORDER BY Facturas.Anexo, Letra"
                    .Connection = cnAgil
                End With

                daFacturas.Fill(dsAgil, "Facturas")

                strUpdate = "UPDATE Referenciado SET Aplicado = 'S' "
                strUpdate = strUpdate & "WHERE Referencia = '" & cReferencia & "' AND Fecha = '" & cFechaPago & "' AND Banco = '" & cBanco & "' AND Importe = " & nImporte

                cnAgil.Open()
                cm3 = New SqlCommand(strUpdate, cnAgil)
                cm3.ExecuteNonQuery()
                cnAgil.Close()

                cBanco = Trim(cBanco)

                Select Case cBanco
                    Case "BANAMEX"
                        cBanco = "04"
                    Case "BANCOMER"
                        cBanco = "02"
                    Case "BANORTE"
                        cBanco = "10"
                    Case "HSBC"
                        cBanco = "03"
                End Select

                For Each drSaldo In dsAgil.Tables("Facturas").Rows

                    cTipar = drSaldo("Tipar")
                    cTipo = drSaldo("Tipo")
                    nSaldo = drSaldo("Saldo")
                    nDiasMoratorios = 0
                    nTasaMoratoria = drSaldo("TasaMoratoria")
                    nMoratorios = 0
                    nIvaMoratorios = 0
                    cFeven = drSaldo("Feven")
                    cFepag = drSaldo("Fepag")

                    ' Traigo la Sucursal y la Tasa de IVA que aplica al cliente a efecto de poder determinar la Serie a utilizar

                    cSucursal = drSaldo("Sucursal")
                    nTasaIVACliente = drSaldo("TasaIVACliente")

                    If cSucursal = "04" Or nTasaIVACliente = 11 Then
                        cSerie = "MXL"
                    Else
                        cSerie = "A"
                    End If

                    If Trim(cFepag) = "" Then
                        nDiasMoratorios = DateDiff(DateInterval.Day, CTOD(cFeven), CTOD(cFechaPago))
                    Else
                        If cFeven >= cFepag Then
                            nDiasMoratorios = DateDiff(DateInterval.Day, CTOD(cFeven), CTOD(cFechaPago))
                        Else
                            nDiasMoratorios = DateDiff(DateInterval.Day, CTOD(cFepag), CTOD(cFechaPago))
                        End If
                    End If
                    If nDiasMoratorios < 0 Then
                        nDiasMoratorios = 0
                    End If

                    If nDiasMoratorios > 0 Then
                        CalcMora(cTipar, cTipo, cFechaPago, drUdis, nSaldo, nTasaMoratoria, nDiasMoratorios, nMoratorios, nIvaMoratorios, nTasaIVACliente)
                    End If

                    nMontoPago = 0
                    If nImporte > 0 And nImporte >= (nMoratorios + nIvaMoratorios) Then
                        nImporte = nImporte - (nMoratorios + nIvaMoratorios)
                        If nImporte >= nSaldo Then
                            nMontoPago = nSaldo + nMoratorios + nIvaMoratorios
                            nImporte = nImporte - nSaldo
                        Else
                            nMontoPago = nImporte + nMoratorios + nIvaMoratorios
                            nImporte = 0
                        End If
                    End If

                    ' La siguiente condición es para evitar que se generen facturas de pago por pagos menores
                    ' o iguales a 30 pesos.

                    If nMontoPago > 30 Then

                        If cSerie = "A" Then
                            nIDSerieA = nIDSerieA + 1
                            nRecibo = nIDSerieA
                        ElseIf cSerie = "MXL" Then
                            nIDSerieMXL = nIDSerieMXL + 1
                            nRecibo = nIDSerieMXL
                        End If

                        cLetra = drSaldo("Letra")
                        Acepagov(cAnexo, cLetra, nMontoPago, nMoratorios, nIvaMoratorios, cBanco, cCheque, dtMovimientos, cFechaAplicacion, cFechaPago, cSerie, nRecibo)

                    End If

                Next

                ' Si al terminar el ciclo anterior nImporte fuera mayor que 0, se trata de un saldo a favor del cliente con dos posibilidades:

                ' 1a) Que sea un saldo menor o igual a 30 pesos en cuyo caso se llevará a Otros Productos como abono

                If nImporte = 0 And nMontoPago > 0 And nMontoPago <= 30 Then

                    strInsert = "INSERT INTO Historia(Documento, Serie, Numero, Fecha, Anexo, Letra, Banco, Cheque, Balance, Importe, Observa1)"
                    strInsert = strInsert & " VALUES ('"
                    strInsert = strInsert & "6" & "', '"
                    strInsert = strInsert & cSerie & "', "
                    strInsert = strInsert & nRecibo & ", '"
                    strInsert = strInsert & cFechaAplicacion & "', '"
                    strInsert = strInsert & cAnexo & "', '"
                    strInsert = strInsert & cLetra & "', '"
                    strInsert = strInsert & cBanco & "', '"
                    strInsert = strInsert & cCheque & "', '"
                    strInsert = strInsert & "N" & "', '"
                    strInsert = strInsert & nMontoPago & "', '"
                    strInsert = strInsert & "OTROS CARGOS"
                    strInsert = strInsert & "')"
                    cm4 = New SqlCommand(strInsert, cnAgil)
                    cnAgil.Open()
                    cm4.ExecuteNonQuery()
                    cnAgil.Close()

                    drMovimiento = dtMovimientos.NewRow()
                    drMovimiento("Anexo") = cAnexo
                    drMovimiento("Letra") = cLetra
                    drMovimiento("Tipos") = "2"
                    drMovimiento("Fepag") = cFechaAplicacion
                    drMovimiento("Cve") = "34"
                    drMovimiento("Imp") = nMontoPago
                    drMovimiento("Tip") = "S"
                    drMovimiento("Catal") = "F"
                    drMovimiento("Esp") = 0
                    drMovimiento("Coa") = "1"
                    drMovimiento("Tipmon") = "01"
                    drMovimiento("Banco") = cBanco
                    dtMovimientos.Rows.Add(drMovimiento)

                End If

                ' 2a. Que sea un saldo mayor a 30 pesos el cual el sistema ya no aplicaría porque tendría que hacerse una aplicación manual

                dsAgil.Tables.Remove("Facturas")

                ' Debe actualizar el atributo IDSerieA ó el atributo IDSerieMXL de la tabla Llaves

                If cSerie = "A" Then
                    strUpdate = "UPDATE Llaves SET IDSerieA = " & nRecibo
                ElseIf cSerie = "MXL" Then
                    strUpdate = "UPDATE Llaves SET IDSerieMXL = " & nRecibo
                End If

                cm1 = New SqlCommand(strUpdate, cnAgil)
                cnAgil.Open()
                cm1.ExecuteNonQuery()
                cnAgil.Close()

                ' En este punto llamo a la función Ingresos para afectar la tabla Hisgin

                Ingresos(dtMovimientos)
                dtMovimientos.Clear()
                
            End If

        Next

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()
        cm3.Dispose()
        cm4.Dispose()

        MsgBox("Proceso terminado", MsgBoxStyle.Information, "Mensaje del Sistema")

        Me.Close()

    End Sub

End Class