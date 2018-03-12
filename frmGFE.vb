Option Explicit On

Imports System.Data.SqlClient
Imports System.Math
Imports System.IO

Public Class frmGFE
   
    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click

        '' Declaración de variables de conexión ADO .NET

        'Dim cnAgil As New SqlConnection(strConn)
        'Dim cm1 As New SqlCommand()
        'Dim daFacturas As New SqlDataAdapter(cm1)
        'Dim dsAgil As New DataSet()
        'Dim drFactura As DataRow

        '' Declaración de clases para generación de Certificado Fiscal Digital

        'Dim newCFD As clsComprobante
        'Dim newConcepto As clsConcepto

        'Dim oArchivo As StreamReader

        '' Debo traer las facturas de la Serie A y de la Serie MXL que se hubieran generado para el día de proceso

        'Dim i As Integer = 0
        'Dim j As Integer = 0

        'Dim cAnexo As String = ""
        'Dim cDigito As String = ""
        'Dim cFecha As String = ""
        'Dim cRenglon As String = ""
        'Dim cRenglonOriginal As String = ""
        'Dim cSerie As String = ""
        'Dim cFolio As String = ""
        'Dim nInicial As Integer = 0
        'Dim nFinal As Integer = 0
        'Dim cIdentificador As String = ""
        'Dim nSubTotal As Decimal = 0
        'Dim nIva As Decimal = 0
        'Dim nTotal As Decimal = 0
        'Dim cNombre As String = ""
        'Dim cCalle As String = ""
        'Dim cNumeroExterior As String = ""
        'Dim cNumeroInterior As String = ""
        'Dim cColonia As String = ""
        'Dim cDelegacion As String = ""
        'Dim cEstado As String = ""
        'Dim cCopos As String = ""
        'Dim cRfc As String = ""
        'Dim cDescripcion As String = ""
        'Dim nImporte As Decimal = 0
        'Dim cLeyenda As String = ""
        'Dim nEspacios As Integer = 0
        'Dim cCuentaPago As String = ""
        'Dim cFormaPago As String = ""
        'Dim cCheque As String = ""

        'cFecha = DTOC(dtpFechaProceso.Value)

        '' Este Stored Procedure trae todas las facturas de una fecha determinada a fin de generar su factura electrónica

        'With cm1
        '    .CommandType = CommandType.Text
        '    .CommandText = "SELECT DISTINCT Serie, Numero, Historia.Anexo, Clientes.Cliente, Descr FROM Historia " & _
        '                   "INNER JOIN Anexos ON Historia.Anexo = Anexos.Anexo " & _
        '                   "INNER JOIN Clientes ON Anexos.Cliente = Clientes.Cliente " & _
        '                   "WHERE Serie = 'A' AND Fecha = '" & cFecha & "' AND Importe <> 0 AND Numero > 50000 " & _
        '                   "UNION ALL " & _
        '                   "SELECT DISTINCT Serie, Numero, Historia.Anexo, Clientes.Cliente, Descr FROM Historia " & _
        '                   "INNER JOIN Avios ON Historia.Anexo = Avios.Anexo " & _
        '                   "INNER JOIN Clientes ON Avios.Cliente = Clientes.Cliente " & _
        '                   "WHERE Serie = 'A' AND Fecha = '" & cFecha & "' AND Importe <> 0 AND Numero > 50000 " & _
        '                   "UNION ALL " & _
        '                   "SELECT DISTINCT Serie, Numero, Historia.Anexo, Clientes.Cliente, Descr FROM Historia " & _
        '                   "INNER JOIN Anexos ON Historia.Anexo = Anexos.Anexo " & _
        '                   "INNER JOIN Clientes ON Anexos.Cliente = Clientes.Cliente " & _
        '                   "WHERE Serie = 'MXL' AND Fecha = '" & cFecha & "' AND Importe <> 0 AND Numero > 300 " & _
        '                   "UNION ALL " & _
        '                   "SELECT DISTINCT Serie, Numero, Historia.Anexo, Clientes.Cliente, Descr FROM Historia " & _
        '                   "INNER JOIN Avios ON Historia.Anexo = Avios.Anexo " & _
        '                   "INNER JOIN Clientes ON Avios.Cliente = Clientes.Cliente " & _
        '                   "WHERE Serie = 'MXL' AND Fecha = '" & cFecha & "' AND Importe <> 0 AND Numero > 300 " & _
        '                   "ORDER BY Serie, Numero"
        '    .Connection = cnAgil
        'End With

        '' Llenar el DataSet a través del DataAdapter, lo cual abre y cierra la conexión

        'daFacturas.Fill(dsAgil, "Facturas")

        'For Each drFactura In dsAgil.Tables("Facturas").Rows

        '    cSerie = Trim(drFactura("Serie"))
        '    i = drFactura("Numero")

        '    If cSerie = "A" Or cSerie = "MXL" Then

        '        newCFD = New clsComprobante

        '        If cSerie = "A" Then
        '            oArchivo = New StreamReader("C:\FACTURAS\FACTURA_A_" & i.ToString & ".TXT")
        '        ElseIf cSerie = "MXL" Then
        '            oArchivo = New StreamReader("C:\FACTURAS\FACTURA_MXL_" & i.ToString & ".TXT")
        '        End If

        '        While (oArchivo.Peek() > -1)

        '            cRenglonOriginal = RTrim(LTrim(oArchivo.ReadLine()))
        '            cIdentificador = Mid(cRenglonOriginal, 1, 2)
        '            If cIdentificador = "H3" Then
        '                cRenglonOriginal = cRenglonOriginal.ToUpper()
        '            End If
        '            cRenglon = ""
        '            cLeyenda = ""

        '            ' Tengo que quitar los espacios dobles intermedios

        '            nEspacios = 1
        '            For j = 1 To Len(cRenglonOriginal)
        '                cDigito = Mid(cRenglonOriginal, j, 1)
        '                Select Case Asc(cDigito)
        '                    Case 32             ' space
        '                    Case 35             ' #
        '                    Case 36             ' $
        '                    Case 38             ' &
        '                    Case 40 To 41       ' ()
        '                    Case 44             ' ,
        '                    Case 45             ' -
        '                    Case 46             ' .
        '                    Case 47             ' /
        '                    Case 48 To 57       ' 0 - 9
        '                    Case 63, 209        ' Ñ o sus variantes 
        '                    Case 65 To 90       ' A - Z
        '                    Case 97             ' a (por 2a. sección por ejemplo)
        '                    Case 111            ' o (cuando modifique la captura de los generales del cliente ya no lo voy a aceptar)
        '                    Case 118, 115       ' vs
        '                    Case 124            ' |
        '                    Case Else
        '                        cLeyenda = "ERROR"
        '                End Select
        '                If cDigito = " " Then
        '                    If nEspacios = 1 Then
        '                        cRenglon += cDigito
        '                        nEspacios += 1
        '                    End If
        '                Else
        '                    If Asc(cDigito) = 63 Or Asc(cDigito) = 209 Then
        '                        cDigito = Chr(38)
        '                    End If
        '                    cRenglon += cDigito
        '                    nEspacios = 1
        '                End If
        '            Next

        '            cAnexo = Mid(cRenglon, 10, 5) + Mid(cRenglon, 16, 4)

        '            If cSerie = "A" Then

        '                ' Para la serie A

        '                cFolio = Mid(cRenglon, 23, Len(i.ToString))
        '                cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - (23 + Len(i.ToString)))

        '            ElseIf cSerie = "MXL" Then

        '                ' Para la serie MXL

        '                cFolio = Mid(cRenglon, 25, Len(i.ToString))
        '                cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - (25 + Len(i.ToString)))

        '            End If

        '            Select Case cIdentificador

        '                Case "H3"

        '                    nInicial = 1
        '                    nFinal = cRenglon.IndexOf("|")
        '                    cNombre = Mid(cRenglon, nInicial, nFinal)

        '                    cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cNombre) - 1)
        '                    nInicial = 1
        '                    nFinal = cRenglon.IndexOf("|")
        '                    cCalle = Mid(cRenglon, nInicial, nFinal)

        '                    cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cCalle) - 1)
        '                    nInicial = 1
        '                    nFinal = cRenglon.IndexOf("|")
        '                    cNumeroExterior = Mid(cRenglon, nInicial, nFinal)

        '                    cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cNumeroExterior) - 1)
        '                    nInicial = 1
        '                    nFinal = cRenglon.IndexOf("|")
        '                    cNumeroInterior = Mid(cRenglon, nInicial, nFinal)

        '                    cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cNumeroInterior) - 1)
        '                    nInicial = 1
        '                    nFinal = cRenglon.IndexOf("|")
        '                    cColonia = Mid(cRenglon, nInicial, nFinal)

        '                    cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cColonia) - 1)
        '                    nInicial = 1
        '                    nFinal = cRenglon.IndexOf("|")
        '                    cDelegacion = Mid(cRenglon, nInicial, nFinal)

        '                    cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cDelegacion) - 1)
        '                    nInicial = 1
        '                    nFinal = cRenglon.IndexOf("|")
        '                    cEstado = Mid(cRenglon, nInicial, nFinal)

        '                    cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cEstado) - 1)
        '                    nInicial = 1
        '                    nFinal = cRenglon.IndexOf("|")
        '                    cCopos = Mid(cRenglon, nInicial, nFinal)

        '                    cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cCopos) - 1)
        '                    nInicial = 1
        '                    nFinal = cRenglon.IndexOf("|")
        '                    cCuentaPago = Mid(cRenglon, nInicial, nFinal)

        '                    cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cCuentaPago) - 1)
        '                    nInicial = 1
        '                    nFinal = cRenglon.IndexOf("|")
        '                    cFormaPago = Mid(cRenglon, nInicial, nFinal)

        '                Case "D1"

        '                    newConcepto = New clsConcepto
        '                    With newConcepto
        '                        .cantidad = 1
        '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - 4)
        '                        nInicial = 1
        '                        nFinal = cRenglon.IndexOf("|")
        '                        cDescripcion = Mid(cRenglon, nInicial, nFinal)
        '                        .descripcion = cDescripcion

        '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cDescripcion) - 2)
        '                        nImporte = Round(CDbl(cRenglon), 2)
        '                        .valorUnitario = nImporte
        '                        .importe = nImporte

        '                    End With
        '                    newCFD.lstConceptos.Add(newConcepto)

        '                Case "S1"

        '                    nInicial = 1
        '                    nFinal = cRenglon.IndexOf("|")
        '                    nSubTotal = Mid(cRenglon, nInicial, nFinal)

        '                    cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(nSubTotal.ToString) - 1)
        '                    nInicial = 1
        '                    nFinal = cRenglon.IndexOf("|")
        '                    nIva = Mid(cRenglon, nInicial, nFinal)

        '                    cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(nIva.ToString) - 1)
        '                    nInicial = 1
        '                    nFinal = cRenglon.IndexOf("|")
        '                    nTotal = Mid(cRenglon, nInicial, nFinal)

        '                    nSubTotal = Round(CDbl(nSubTotal), 2)
        '                    nIva = Round(CDbl(nIva), 2)
        '                    nTotal = Round(CDbl(nTotal), 2)

        '                Case "Z1"

        '                    nInicial = 1
        '                    nFinal = cRenglon.IndexOf("|")
        '                    cCheque = Mid(cRenglon, nInicial, nFinal)

        '                    cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cCheque) - 1)
        '                    nInicial = 1
        '                    nFinal = cRenglon.IndexOf("|")
        '                    cRfc = Mid(cRenglon, nInicial, nFinal)

        '                    cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cRfc) - 1)
        '                    cLeyenda = cRenglon

        '            End Select

        '        End While

        '        ' Una vez que cerré la conexión y que generé los asientos contables, podría generar el CFD (Certificado Fiscal Digital)

        '        cFecha = Mid(DTOC(dtpFechaProceso.Value), 1, 4) + "-" + Mid(DTOC(dtpFechaProceso.Value), 5, 2) + "-" + Mid(DTOC(dtpFechaProceso.Value), 7, 2) + "T" + Mid(Now.TimeOfDay.ToString, 1, 8)

        '        With newCFD
        '            .version = "2.2"                                ' La versión siempre es la 2.2
        '            .serie = cSerie
        '            .folio = cFolio
        '            .fecha = cFecha                                 ' Esta fecha es la de aplicación del pago (cFecha), no la de realización del pago
        '            If cSerie = "A" Then
        '                .noAprobacion = "194645"                    ' Para Toluca, Querétaro, Navojoa, Naucalpan
        '            ElseIf cSerie = "MXL" Then
        '                .noAprobacion = "202511"                    ' Para Mexicali
        '            End If
        '            .anoAprobacion = "2010"                         ' El año de aprobación dependerá de la sucursal que esté expidiendo el CFD
        '            .formaDePago = "PAGO EN UNA SOLA EXHIBICION"
        '            .subTotal = nSubTotal
        '            .total = nTotal
        '            .tipoDeComprobante = "ingreso"
        '            .anexo = cAnexo
        '            .importeLetra = Letras(nTotal.ToString)
        '            .leyenda = cLeyenda
        '            .monto = 0.0
        '            .iva = 0.0
        '            .metodoDePago = cFormaPago
        '            If cSerie = "A" Then
        '                .LugarExpedicion = "TOLUCA, ESTADO DE MEXICO"
        '            ElseIf cSerie = "MXL" Then
        '                .LugarExpedicion = "MEXICALI, B. C."
        '            End If
        '            .NumCtaPago = cCuentaPago
        '            .cadenaOriginal = ""
        '        End With

        '        ' Los datos de expedición dependerán de la sucursal que esté expidiendo el CFD

        '        With newCFD.emisor
        '            If cSerie = "A" Then
        '                .expedidoEn_calle = "LEANDRO VALLE 402"
        '                .expedidoEn_colonia = "REFORMA Y FFCCNN"
        '                .expedidoEn_municipio = "TOLUCA"
        '                .expedidoEn_estado = "ESTADO DE MEXICO"
        '                .expedidoEn_pais = "MEXICO"
        '                .expedidoEn_codigoPostal = "50070"
        '            ElseIf cSerie = "MXL" Then
        '                .expedidoEn_calle = "AV. RIO SAN ANGEL 48 LOCALES 7 Y 8"
        '                .expedidoEn_colonia = "COL. VALLE DE PUEBLA"
        '                .expedidoEn_municipio = "MEXICALI"
        '                .expedidoEn_estado = "B.C."
        '                .expedidoEn_pais = "MEXICO"
        '                .expedidoEn_codigoPostal = "21384"
        '            End If
        '        End With

        '        With newCFD.receptor
        '            .rfc = Trim(cRfc)
        '            .nombre = Trim(cNombre)
        '            .calle = Trim(cCalle)
        '            .colonia = Trim(cColonia)
        '            .municipio = Trim(cDelegacion)
        '            .estado = Trim(cEstado)
        '            .pais = "MEXICO"
        '            .codigoPostal = Trim(cCopos)
        '        End With

        '        With newCFD.impuestos
        '            .impuesto = "IVA"
        '            If cSerie = "A" Then
        '                .tasa = IIf(nIva > 0, "16.00", "0.00")          ' La tasa del impuesto dependerá del lugar de expedición
        '            ElseIf cSerie = "MXL" Then
        '                .tasa = IIf(nIva > 0, "11.00", "0.00")          ' La tasa del impuesto dependerá del lugar de expedición
        '            End If
        '            .importe = nIva
        '        End With

        '        CFD(newCFD)

        '        oArchivo.Close()
        '        oArchivo = Nothing

        '    End If

        'Next

        'MsgBox("Generación de facturas electrónicas terminado", MsgBoxStyle.Information, "Mensaje")

        'cm1.Dispose()
        'cnAgil.Dispose()

    End Sub

End Class