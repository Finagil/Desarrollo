Option Explicit On

Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports System.Math
Imports System.IO

Public Class frmEnvios

    'Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click

    '    Dim i As Integer = 0
    '    Dim j As Integer = 0
    '    Dim cRenglon As String
    '    Dim cDigito As String
    '    Dim cRenglonOriginal As String
    '    Dim cFolio As String = ""
    '    Dim nInicial As Integer
    '    Dim nFinal As Integer
    '    Dim cIdentificador As String
    '    Dim cCliente As String
    '    Dim nSubTotal As Decimal = 0
    '    Dim nIva As Decimal = 0
    '    Dim nTotal As Decimal = 0
    '    Dim cAnexo As String
    '    Dim cNombre As String
    '    Dim cCalle As String
    '    Dim cNumeroExterior As String
    '    Dim cNumeroInterior As String
    '    Dim cColonia As String
    '    Dim cDelegacion As String
    '    Dim cEstado As String
    '    Dim cCopos As String
    '    Dim cCheque As String
    '    Dim cRfc As String
    '    Dim cDescripcion As String
    '    Dim nImporte As Decimal
    '    Dim cFecha As String = ""
    '    Dim cLeyenda As String = ""
    '    Dim nEspacios As Integer = 0
    '    Dim cCuentaPago As String = ""
    '    Dim cFormaPago As String = ""

    '    ' Declaración de clases para generación de Certificado Fiscal Digital

    '    Dim newCFD As clsComprobante
    '    Dim newConcepto As clsConcepto

    '    Dim oArchivo As StreamReader

    '    For i = 85521 To 85522

    '        If i <> 0 Then                  ' Por si quisiera omitir algún archivo en específico

    '            Select Case i
    '                Case 85521 To 85522
    '                    cFecha = "20131122"
    '            End Select

    '            cLeyenda = ""

    '            newCFD = New clsComprobante

    '            oArchivo = New StreamReader("C:\FACTURAS\2013\Serie A\FACTURA_A_" & i.ToString & ".TXT")

    '            While (oArchivo.Peek() > -1)

    '                cRenglonOriginal = RTrim(LTrim(oArchivo.ReadLine()))
    '                cIdentificador = Mid(cRenglonOriginal, 1, 2)
    '                If cIdentificador = "H3" Then
    '                    cRenglonOriginal = cRenglonOriginal.ToUpper()
    '                End If
    '                cRenglon = ""

    '                ' Tengo que quitar los espacios dobles intermedios

    '                nEspacios = 1
    '                For j = 1 To Len(cRenglonOriginal)
    '                    cDigito = Mid(cRenglonOriginal, j, 1)
    '                    Select Case Asc(cDigito)
    '                        Case 32             ' space
    '                        Case 35             ' #
    '                        Case 36             ' $
    '                        Case 38             ' &
    '                        Case 40 To 41       ' ()
    '                        Case 44             ' ,
    '                        Case 45             ' -
    '                        Case 46             ' .
    '                        Case 47             ' /
    '                        Case 48 To 57       ' 0 - 9
    '                        Case 63, 209        ' Ñ o sus variantes 
    '                        Case 65 To 90       ' A - Z
    '                        Case 97             ' a (por 2a. sección por ejemplo)
    '                        Case 111            ' o (cuando modifique la captura de los generales del cliente ya no lo voy a aceptar)
    '                        Case 118, 115       ' vs
    '                        Case 124            ' |
    '                        Case Else
    '                            cLeyenda = "ERROR"
    '                    End Select
    '                    If cDigito = " " Then
    '                        If nEspacios = 1 Then
    '                            cRenglon += cDigito
    '                            nEspacios += 1
    '                        End If
    '                    Else
    '                        If Asc(cDigito) = 63 Or Asc(cDigito) = 209 Then
    '                            cDigito = Chr(38)
    '                        End If
    '                        cRenglon += cDigito
    '                        nEspacios = 1
    '                    End If
    '                Next

    '                cAnexo = Mid(cRenglon, 10, 5) + Mid(cRenglon, 16, 4)

    '                ' Para la serie A

    '                cFolio = Mid(cRenglon, 23, Len(i.ToString))
    '                cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - (23 + Len(i.ToString)))

    '                Select Case cIdentificador

    '                    Case "H3"

    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cNombre = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cNombre) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cCalle = Mid(cRenglon, nInicial, nFinal)
    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cCalle) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cNumeroExterior = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cNumeroExterior) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cNumeroInterior = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cNumeroInterior) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cColonia = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cColonia) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cDelegacion = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cDelegacion) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cEstado = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cEstado) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cCopos = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cCopos) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cCuentaPago = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cCuentaPago) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cFormaPago = Mid(cRenglon, nInicial, nFinal)

    '                    Case "D1"

    '                        newConcepto = New clsConcepto
    '                        With newConcepto
    '                            .cantidad = 1
    '                            cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - 4)
    '                            nInicial = 1
    '                            nFinal = cRenglon.IndexOf("|")
    '                            cDescripcion = Mid(cRenglon, nInicial, nFinal)
    '                            .descripcion = cDescripcion

    '                            cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cDescripcion) - 2)
    '                            nImporte = Round(CDbl(cRenglon), 2)
    '                            .valorUnitario = nImporte
    '                            .importe = nImporte

    '                        End With
    '                        newCFD.lstConceptos.Add(newConcepto)

    '                    Case "S1"

    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        nSubTotal = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(nSubTotal.ToString) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        nIva = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(nIva.ToString) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        nTotal = Mid(cRenglon, nInicial, nFinal)

    '                        nSubTotal = Round(CDbl(nSubTotal), 2)
    '                        nIva = Round(CDbl(nIva), 2)
    '                        nTotal = Round(CDbl(nTotal), 2)

    '                    Case "Z1"

    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cCheque = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cCheque) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cRfc = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cRfc) - 1)
    '                        cLeyenda = cRenglon

    '                End Select

    '            End While

    '            ' Una vez que cerré la conexión y que generé los asientos contables, podría generar el CFD (Certificado Fiscal Digital)

    '            '               cFecha = Mid(cFecha, 1, 4) + "-" + Mid(cFecha, 5, 2) + "-" + Mid(cFecha, 7, 2) + "T" + Mid(Now.TimeOfDay.ToString, 1, 8)
    '            'cFecha = Mid(cFecha, 1, 4) + "-" + Mid(cFecha, 5, 2) + "-" + Mid(cFecha, 7, 2) + "T18:24:20mcn6"

    '            Select Case i
    '                Case 85521
    '                    cFecha = Mid(cFecha, 1, 4) + "-" + Mid(cFecha, 5, 2) + "-" + Mid(cFecha, 7, 2) + "T16:45:26"
    '                Case 85522
    '                    cFecha = Mid(cFecha, 1, 4) + "-" + Mid(cFecha, 5, 2) + "-" + Mid(cFecha, 7, 2) + "T16:45:28"
    '                    'Case 84228
    '                    '    cFecha = Mid(cFecha, 1, 4) + "-" + Mid(cFecha, 5, 2) + "-" + Mid(cFecha, 7, 2) + "T09:03:57"
    '                    'Case 84229
    '                    '    cFecha = Mid(cFecha, 1, 4) + "-" + Mid(cFecha, 5, 2) + "-" + Mid(cFecha, 7, 2) + "T09:04:07"
    '            End Select

    '            With newCFD
    '                .version = "2.2"                                ' La versión siempre es la 2.2
    '                .serie = "A"                                    ' La serie dependerá de la sucursal que esté expidiendo el CFD
    '                .folio = cFolio
    '                .fecha = cFecha                                 ' Esta fecha es la de aplicación del pago (cFecha), no la de realización del pago
    '                .noAprobacion = "194645"                        ' El número de aprobación dependerá de la sucursal que esté expidiendo el CFD"
    '                .anoAprobacion = "2010"                         ' El año de aprobación dependerá de la sucursal que esté expidiendo el CFD
    '                .formaDePago = "PAGO EN UNA SOLA EXHIBICION"
    '                .subTotal = nSubTotal
    '                .total = nTotal
    '                .tipoDeComprobante = "ingreso"
    '                .anexo = cAnexo
    '                .importeLetra = Letras(nTotal.ToString)
    '                .leyenda = cLeyenda
    '                .monto = 0.0
    '                .iva = 0.0
    '                .metodoDePago = cFormaPago
    '                .LugarExpedicion = "TOLUCA, ESTADO DE MEXICO"
    '                .NumCtaPago = cCuentaPago
    '                .cadenaOriginal = ""
    '            End With

    '            ' Los datos de expedición dependerán de la sucursal que esté expidiendo el CFD

    '            With newCFD.emisor
    '                .expedidoEn_calle = "LEANDRO VALLE 402"
    '                .expedidoEn_colonia = "REFORMA Y FFCCNN"
    '                .expedidoEn_municipio = "TOLUCA"
    '                .expedidoEn_estado = "ESTADO DE MEXICO"
    '                .expedidoEn_pais = "MEXICO"
    '                .expedidoEn_codigoPostal = "50070"
    '            End With

    '            With newCFD.receptor
    '                .rfc = Trim(cRfc)
    '                .nombre = Trim(cNombre)
    '                .calle = Trim(cCalle)
    '                .colonia = Trim(cColonia)
    '                .municipio = Trim(cDelegacion)
    '                .estado = Trim(cEstado)
    '                .pais = "MEXICO"
    '                .codigoPostal = Trim(cCopos)
    '            End With

    '            With newCFD.impuestos
    '                .impuesto = "IVA"
    '                .tasa = IIf(nIva > 0, "16.00", "0.00")          ' La tasa del impuesto dependerá del lugar de expedición
    '                .importe = nIva
    '            End With

    '            CFD(newCFD)

    '            oArchivo.Close()
    '            oArchivo = Nothing

    '        End If

    '    Next

    '    MsgBox("Generación de facturas electrónicas SERIE A terminado", MsgBoxStyle.Information, "Mensaje")

    'End Sub

    'Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click

    '    Dim i As Integer = 0
    '    Dim j As Integer = 0
    '    Dim cRenglon As String
    '    Dim cDigito As String
    '    Dim cRenglonOriginal As String
    '    Dim cFolio As String = ""
    '    Dim nInicial As Integer
    '    Dim nFinal As Integer
    '    Dim cIdentificador As String
    '    Dim cCliente As String
    '    Dim nSubTotal As Decimal = 0
    '    Dim nIva As Decimal = 0
    '    Dim nTotal As Decimal = 0
    '    Dim cAnexo As String
    '    Dim cNombre As String
    '    Dim cCalle As String
    '    Dim cNumeroExterior As String
    '    Dim cNumeroInterior As String
    '    Dim cColonia As String
    '    Dim cDelegacion As String
    '    Dim cEstado As String
    '    Dim cCopos As String
    '    Dim cCheque As String
    '    Dim cRfc As String
    '    Dim cDescripcion As String
    '    Dim nImporte As Decimal
    '    Dim cFecha As String = ""
    '    Dim cLeyenda As String = ""
    '    Dim nEspacios As Integer = 0
    '    Dim cCuentaPago As String = ""
    '    Dim cFormaPago As String = ""

    '    ' Declaración de clases para generación de Certificado Fiscal Digital

    '    Dim newCFD As clsComprobante
    '    Dim newConcepto As clsConcepto

    '    Dim oArchivo As StreamReader

    '    For i = 1328 To 1328

    '        If i <> 0 Then                  ' Por si quisiera omitir algún archivo en específico

    '            Select Case i
    '                Case 1328
    '                    cFecha = "20131119"
    '                    'Case 1314
    '                    '    cFecha = "20131101"
    '                    '    'Case 1284 To 1284
    '                    '    cFecha = "20131011"
    '            End Select

    '            cLeyenda = ""

    '            newCFD = New clsComprobante

    '            oArchivo = New StreamReader("C:\FACTURAS\2013\Serie B\FACTURA_B_" & i.ToString & ".TXT")

    '            While (oArchivo.Peek() > -1)

    '                cRenglonOriginal = RTrim(LTrim(oArchivo.ReadLine()))
    '                cIdentificador = Mid(cRenglonOriginal, 1, 2)
    '                If cIdentificador = "H3" Then
    '                    cRenglonOriginal = cRenglonOriginal.ToUpper()
    '                End If
    '                cRenglon = ""

    '                ' Tengo que quitar los espacios dobles intermedios

    '                nEspacios = 1
    '                For j = 1 To Len(cRenglonOriginal)
    '                    cDigito = Mid(cRenglonOriginal, j, 1)
    '                    Select Case Asc(cDigito)
    '                        Case 32             ' space
    '                        Case 35             ' #
    '                        Case 36             ' $
    '                        Case 38             ' &
    '                        Case 40 To 41       ' ()
    '                        Case 44             ' ,
    '                        Case 45             ' -
    '                        Case 46             ' .
    '                        Case 47             ' /
    '                        Case 48 To 57       ' 0 - 9
    '                        Case 63, 209        ' Ñ o sus variantes 
    '                        Case 65 To 90       ' A - Z
    '                        Case 97             ' a (por 2a. sección por ejemplo)
    '                        Case 111            ' o (cuando modifique la captura de los generales del cliente ya no lo voy a aceptar)
    '                        Case 118, 115       ' vs
    '                        Case 124            ' |
    '                        Case Else
    '                            cLeyenda = "ERROR"
    '                    End Select
    '                    If cDigito = " " Then
    '                        If nEspacios = 1 Then
    '                            cRenglon += cDigito
    '                            nEspacios += 1
    '                        End If
    '                    Else
    '                        If Asc(cDigito) = 63 Or Asc(cDigito) = 209 Then
    '                            cDigito = Chr(38)
    '                        End If
    '                        cRenglon += cDigito
    '                        nEspacios = 1
    '                    End If
    '                Next

    '                cAnexo = Mid(cRenglon, 10, 5) + Mid(cRenglon, 16, 4)

    '                ' Para la serie B

    '                cFolio = Mid(cRenglon, 23, Len(i.ToString))
    '                cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - (23 + Len(i.ToString)))

    '                Select Case cIdentificador

    '                    Case "H3"

    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cNombre = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cNombre) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cCalle = Mid(cRenglon, nInicial, nFinal)
    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cCalle) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cNumeroExterior = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cNumeroExterior) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cNumeroInterior = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cNumeroInterior) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cColonia = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cColonia) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cDelegacion = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cDelegacion) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cEstado = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cEstado) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cCopos = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cCopos) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cCuentaPago = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cCuentaPago) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cFormaPago = Mid(cRenglon, nInicial, nFinal)

    '                    Case "D1"

    '                        newConcepto = New clsConcepto
    '                        With newConcepto
    '                            .cantidad = 1
    '                            cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - 4)
    '                            nInicial = 1
    '                            nFinal = cRenglon.IndexOf("|")
    '                            cDescripcion = Mid(cRenglon, nInicial, nFinal)
    '                            .descripcion = cDescripcion

    '                            cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cDescripcion) - 2)
    '                            nImporte = Round(CDbl(cRenglon), 2)
    '                            .valorUnitario = nImporte
    '                            .importe = nImporte

    '                        End With
    '                        newCFD.lstConceptos.Add(newConcepto)

    '                    Case "S1"

    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        nSubTotal = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(nSubTotal.ToString) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        nIva = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(nIva.ToString) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        nTotal = Mid(cRenglon, nInicial, nFinal)

    '                        nSubTotal = Round(CDbl(nSubTotal), 2)
    '                        nIva = Round(CDbl(nIva), 2)
    '                        nTotal = Round(CDbl(nTotal), 2)

    '                    Case "Z1"

    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cCheque = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cCheque) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cRfc = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cRfc) - 1)
    '                        cLeyenda = cRenglon

    '                End Select

    '            End While

    '            ' Una vez que cerré la conexión y que generé los asientos contables, podría generar el CFD (Certificado Fiscal Digital)

    '            'cFecha = Mid(cFecha, 1, 4) + "-" + Mid(cFecha, 5, 2) + "-" + Mid(cFecha, 7, 2) + "T" + Mid(Now.TimeOfDay.ToString, 1, 8)
    '            'Dim y As Integer = 1
    '            'If y = 1 Then
    '            cFecha = Mid(cFecha, 1, 4) + "-" + Mid(cFecha, 5, 2) + "-" + Mid(cFecha, 7, 2) + "T09:08:35"
    '            'Else
    '            '    cFecha = Mid(cFecha, 1, 4) + "-" + Mid(cFecha, 5, 2) + "-" + Mid(cFecha, 7, 2) + "T09:16:27"
    '            'End If

    '            With newCFD
    '                .version = "2.2"
    '                .serie = "B"                                    ' La serie dependerá de la sucursal que esté expidiendo el CFD
    '                .folio = cFolio
    '                .fecha = cFecha                                 ' Esta fecha es la de aplicación del pago (cFecha), no la de realización del pago
    '                .noAprobacion = "194645"                        ' El número de aprobación dependerá de la sucursal que esté expidiendo el CFD
    '                .anoAprobacion = "2010"                         ' El año de aprobación dependerá de la sucursal que esté expidiendo el CFD
    '                .formaDePago = "PAGO EN UNA SOLA EXHIBICION"
    '                .subTotal = nSubTotal
    '                .total = nTotal
    '                .tipoDeComprobante = "ingreso"
    '                .anexo = cAnexo
    '                .importeLetra = Letras(nTotal.ToString)
    '                .leyenda = cLeyenda
    '                .monto = 0.0
    '                .iva = 0.0
    '                .metodoDePago = cFormaPago
    '                .LugarExpedicion = "TOLUCA, ESTADO DE MEXICO"
    '                .NumCtaPago = cCuentaPago
    '                .cadenaOriginal = ""
    '            End With

    '            ' Los datos de expedición dependerán de la sucursal que esté expidiendo el CFD

    '            With newCFD.emisor
    '                .expedidoEn_calle = "LEANDRO VALLE 402"
    '                .expedidoEn_colonia = "REFORMA Y FFCCNN"
    '                .expedidoEn_municipio = "TOLUCA"
    '                .expedidoEn_estado = "ESTADO DE MEXICO"
    '                .expedidoEn_pais = "MEXICO"
    '                .expedidoEn_codigoPostal = "50070"
    '            End With

    '            With newCFD.receptor
    '                .rfc = Trim(cRfc)
    '                .nombre = Trim(cNombre)
    '                .calle = Trim(cCalle)
    '                .colonia = Trim(cColonia)
    '                .municipio = Trim(cDelegacion)
    '                .estado = Trim(cEstado)
    '                .pais = "MEXICO"
    '                .codigoPostal = Trim(cCopos)
    '            End With

    '            With newCFD.impuestos
    '                .impuesto = "IVA"
    '                .tasa = IIf(nIva > 0, "16.00", "0.00")          ' La tasa del impuesto dependerá del lugar de expedición
    '                .importe = nIva
    '            End With

    '            CFD(newCFD)

    '            oArchivo.Close()
    '            oArchivo = Nothing

    '        End If

    '    Next

    '    MsgBox("Generación de FACTURAS DE ACTIVO FIJO electrónicas terminado", MsgBoxStyle.Information, "Mensaje")

    'End Sub


    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click

        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim cRenglon As String
        Dim cDigito As String
        Dim cRenglonOriginal As String
        Dim cFolio As String = ""
        Dim nInicial As Integer
        Dim nFinal As Integer
        Dim cIdentificador As String
        Dim cCliente As String
        Dim nSubTotal As Decimal = 0
        Dim nIva As Decimal = 0
        Dim nTotal As Decimal = 0
        Dim cAnexo As String
        Dim cNombre As String
        Dim cCalle As String
        Dim cNumeroExterior As String
        Dim cNumeroInterior As String
        Dim cColonia As String
        Dim cDelegacion As String
        Dim cEstado As String
        Dim cCopos As String
        Dim cCheque As String
        Dim cRfc As String
        Dim cDescripcion As String
        Dim nImporte As Decimal
        Dim cFecha As String = ""
        Dim cLeyenda As String = ""
        Dim nEspacios As Integer = 0
        Dim cCuentaPago As String = ""
        Dim cFormaPago As String = ""

        ' Declaración de clases para generación de Certificado Fiscal Digital

        Dim newCFD As clsComprobante
        Dim newConcepto As clsConcepto

        Dim oArchivo As StreamReader

        For i = 1046 To 1049

            If i <> 0 Then                  ' Por si quisiera omitir algún archivo en específico

                Select Case i
                    'Case 1042
                    '    cFecha = "20131001"
                    'Case 1043
                    '    cFecha = "20131007"
                    'Case 1044
                    '    cFecha = "20131009"
                    'Case 1045
                    '    cFecha = "20131011"
                    Case 1046
                        cFecha = "20131014"
                    Case 1047
                        cFecha = "20131027'"
                    Case 1048
                        cFecha = "20131030"
                    Case 1049
                        cFecha = "20131031"
                End Select

                cLeyenda = ""

                newCFD = New clsComprobante

                oArchivo = New StreamReader("C:\FACTURAS\2013\Serie C\Nota" & i.ToString & ".TXT")

                While (oArchivo.Peek() > -1)

                    cRenglonOriginal = RTrim(LTrim(oArchivo.ReadLine()))
                    cIdentificador = Mid(cRenglonOriginal, 1, 2)
                    If cIdentificador = "H3" Then
                        cRenglonOriginal = cRenglonOriginal.ToUpper()
                    End If
                    cRenglon = ""

                    ' Tengo que quitar los espacios dobles intermedios

                    nEspacios = 1
                    For j = 1 To Len(cRenglonOriginal)
                        cDigito = Mid(cRenglonOriginal, j, 1)
                        Select Case Asc(cDigito)
                            Case 32             ' space
                            Case 35             ' #
                            Case 36             ' $
                            Case 38             ' &
                            Case 40 To 41       ' ()
                            Case 44             ' ,
                            Case 45             ' -
                            Case 46             ' .
                            Case 47             ' /
                            Case 48 To 57       ' 0 - 9
                            Case 63, 209        ' Ñ o sus variantes 
                            Case 65 To 90       ' A - Z
                            Case 97             ' a (por 2a. sección por ejemplo)
                            Case 111            ' o (cuando modifique la captura de los generales del cliente ya no lo voy a aceptar)
                            Case 118, 115       ' vs
                            Case 124            ' |
                            Case Else
                                cLeyenda = "ERROR"
                        End Select
                        If cDigito = " " Then
                            If nEspacios = 1 Then
                                cRenglon += cDigito
                                nEspacios += 1
                            End If
                        Else
                            If Asc(cDigito) = 63 Or Asc(cDigito) = 209 Then
                                cDigito = Chr(38)
                            End If
                            cRenglon += cDigito
                            nEspacios = 1
                        End If
                    Next

                    cAnexo = Mid(cRenglon, 10, 5) + Mid(cRenglon, 16, 4)

                    ' Para la serie C

                    cFolio = Mid(cRenglon, 23, Len(i.ToString))
                    cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - (23 + Len(i.ToString)))

                    Select Case cIdentificador

                        Case "H3"

                            nInicial = 1
                            nFinal = cRenglon.IndexOf("|")
                            cNombre = Mid(cRenglon, nInicial, nFinal)

                            cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cNombre) - 1)
                            nInicial = 1
                            nFinal = cRenglon.IndexOf("|")
                            cCalle = Mid(cRenglon, nInicial, nFinal)
                            cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cCalle) - 1)
                            nInicial = 1
                            nFinal = cRenglon.IndexOf("|")
                            cNumeroExterior = Mid(cRenglon, nInicial, nFinal)

                            cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cNumeroExterior) - 1)
                            nInicial = 1
                            nFinal = cRenglon.IndexOf("|")
                            cNumeroInterior = Mid(cRenglon, nInicial, nFinal)

                            cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cNumeroInterior) - 1)
                            nInicial = 1
                            nFinal = cRenglon.IndexOf("|")
                            cColonia = Mid(cRenglon, nInicial, nFinal)

                            cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cColonia) - 1)
                            nInicial = 1
                            nFinal = cRenglon.IndexOf("|")
                            cDelegacion = Mid(cRenglon, nInicial, nFinal)

                            cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cDelegacion) - 1)
                            nInicial = 1
                            nFinal = cRenglon.IndexOf("|")
                            cEstado = Mid(cRenglon, nInicial, nFinal)

                            cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cEstado) - 1)
                            nInicial = 1
                            nFinal = cRenglon.IndexOf("|")
                            cCopos = Mid(cRenglon, nInicial, nFinal)

                            cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cCopos) - 1)
                            nInicial = 1
                            nFinal = cRenglon.IndexOf("|")
                            cCuentaPago = Mid(cRenglon, nInicial, nFinal)

                            cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cCuentaPago) - 1)
                            nInicial = 1
                            nFinal = cRenglon.IndexOf("|")
                            cFormaPago = Mid(cRenglon, nInicial, nFinal)

                        Case "D1"

                            newConcepto = New clsConcepto
                            With newConcepto
                                .cantidad = 1
                                cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - 4)
                                nInicial = 1
                                nFinal = cRenglon.IndexOf("|")
                                cDescripcion = Mid(cRenglon, nInicial, nFinal)
                                .descripcion = cDescripcion

                                cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cDescripcion) - 2)
                                nImporte = Round(CDbl(cRenglon), 2)
                                .valorUnitario = nImporte
                                .importe = nImporte

                            End With
                            newCFD.lstConceptos.Add(newConcepto)

                        Case "S1"

                            nInicial = 1
                            nFinal = cRenglon.IndexOf("|")
                            nSubTotal = Mid(cRenglon, nInicial, nFinal)

                            cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(nSubTotal.ToString) - 1)
                            nInicial = 1
                            nFinal = cRenglon.IndexOf("|")
                            nIva = Mid(cRenglon, nInicial, nFinal)

                            cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(nIva.ToString) - 1)
                            nInicial = 1
                            nFinal = cRenglon.IndexOf("|")
                            nTotal = Mid(cRenglon, nInicial, nFinal)

                            nSubTotal = Round(CDbl(nSubTotal), 2)
                            nIva = Round(CDbl(nIva), 2)
                            nTotal = Round(CDbl(nTotal), 2)

                        Case "Z1"

                            nInicial = 1
                            nFinal = cRenglon.IndexOf("|")
                            cCheque = Mid(cRenglon, nInicial, nFinal)

                            cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cCheque) - 1)
                            nInicial = 1
                            nFinal = cRenglon.IndexOf("|")
                            cRfc = Mid(cRenglon, nInicial, nFinal)

                            cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cRfc) - 1)
                            cLeyenda = cRenglon

                    End Select

                End While

                ' Una vez que cerré la conexión y que generé los asientos contables, podría generar el CFD (Certificado Fiscal Digital)

                If i = 1046 Then
                    cFecha = Mid(cFecha, 1, 4) + "-" + Mid(cFecha, 5, 2) + "-" + Mid(cFecha, 7, 2) + "T15:34:14"
                Else
                    cFecha = Mid(cFecha, 1, 4) + "-" + Mid(cFecha, 5, 2) + "-" + Mid(cFecha, 7, 2) + "T15:34:20"
                End If

                '               cFecha = Mid(cFecha, 1, 4) + "-" + Mid(cFecha, 5, 2) + "-" + Mid(cFecha, 7, 2) + "T" + Mid(Now.TimeOfDay.ToString, 1, 8)

                With newCFD
                    .version = "2.2"                                ' La versión siempre es la 2.0
                    .serie = "C"                                    ' La serie dependerá de la sucursal que esté expidiendo el CFD
                    .folio = cFolio
                    .fecha = cFecha                                 ' Esta fecha es la de aplicación del pago (cFecha), no la de realización del pago
                    .noAprobacion = "194645"                        ' El número de aprobación dependerá de la sucursal que esté expidiendo el CFD"
                    .anoAprobacion = "2010"                         ' El año de aprobación dependerá de la sucursal que esté expidiendo el CFD
                    .formaDePago = "PAGO EN UNA SOLA EXHIBICION"
                    .subTotal = nSubTotal
                    .total = nTotal
                    .tipoDeComprobante = "egreso"
                    .anexo = cAnexo
                    .importeLetra = Letras(nTotal.ToString)
                    .leyenda = cLeyenda
                    .monto = 0.0
                    .iva = 0.0
                    .metodoDePago = cFormaPago
                    .LugarExpedicion = "TOLUCA, ESTADO DE MEXICO"
                    .NumCtaPago = cCuentaPago
                    .cadenaOriginal = ""
                End With

                ' Los datos de expedición dependerán de la sucursal que esté expidiendo el CFD

                With newCFD.emisor
                    .expedidoEn_calle = "LEANDRO VALLE 402"
                    .expedidoEn_colonia = "REFORMA Y FFCCNN"
                    .expedidoEn_municipio = "TOLUCA"
                    .expedidoEn_estado = "ESTADO DE MEXICO"
                    .expedidoEn_pais = "MEXICO"
                    .expedidoEn_codigoPostal = "50070"
                End With

                With newCFD.receptor
                    .rfc = Trim(cRfc)
                    .nombre = Trim(cNombre)
                    .calle = Trim(cCalle)
                    .colonia = Trim(cColonia)
                    .municipio = Trim(cDelegacion)
                    .estado = Trim(cEstado)
                    .pais = "MEXICO"
                    .codigoPostal = Trim(cCopos)
                End With

                With newCFD.impuestos
                    .impuesto = "IVA"
                    .tasa = IIf(nIva > 0, "16.00", "0.00")          ' La tasa del impuesto dependerá del lugar de expedición
                    .importe = nIva
                End With

                CFD(newCFD)

                oArchivo.Close()
                oArchivo = Nothing

            End If

        Next

        MsgBox("Generación de NOTAS DE CRÉDITO terminada", MsgBoxStyle.Information, "Mensaje")

    End Sub

    'Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click

    '    Dim i As Integer = 0
    '    Dim j As Integer = 0
    '    Dim cRenglon As String
    '    Dim cDigito As String
    '    Dim cRenglonOriginal As String
    '    Dim cFolio As String = ""
    '    Dim nInicial As Integer
    '    Dim nFinal As Integer
    '    Dim cIdentificador As String
    '    Dim cCliente As String
    '    Dim nSubTotal As Decimal = 0
    '    Dim nIva As Decimal = 0
    '    Dim nTotal As Decimal = 0
    '    Dim cAnexo As String
    '    Dim cNombre As String
    '    Dim cCalle As String
    '    Dim cNumeroExterior As String
    '    Dim cNumeroInterior As String
    '    Dim cColonia As String
    '    Dim cDelegacion As String
    '    Dim cEstado As String
    '    Dim cCopos As String
    '    Dim cCheque As String
    '    Dim cRfc As String
    '    Dim cDescripcion As String
    '    Dim nImporte As Decimal
    '    Dim cFecha As String = ""
    '    Dim cLeyenda As String = ""
    '    Dim nEspacios As Integer = 0
    '    Dim cCuentaPago As String = ""
    '    Dim cFormaPago As String = ""

    '    ' Declaración de clases para generación de Certificado Fiscal Digital

    '    Dim newCFD As clsComprobante
    '    Dim newConcepto As clsConcepto

    '    Dim oArchivo As StreamReader

    '    For i = 145 To 145

    '        If i <> 0 Then                  ' Por si quisiera omitir algún archivo en específico

    '            Select Case i
    '                Case 145
    '                    cFecha = "20131101"
    '            End Select

    '            cLeyenda = ""

    '            newCFD = New clsComprobante

    '            oArchivo = New StreamReader("C:\FACTURAS\2013\Serie DV\FACTURA_DV_" & i.ToString & ".TXT")

    '            While (oArchivo.Peek() > -1)

    '                cRenglonOriginal = RTrim(LTrim(oArchivo.ReadLine()))
    '                cIdentificador = Mid(cRenglonOriginal, 1, 2)
    '                If cIdentificador = "H3" Then
    '                    cRenglonOriginal = cRenglonOriginal.ToUpper()
    '                End If
    '                cRenglon = ""

    '                ' Tengo que quitar los espacios dobles intermedios

    '                nEspacios = 1
    '                For j = 1 To Len(cRenglonOriginal)
    '                    cDigito = Mid(cRenglonOriginal, j, 1)
    '                    Select Case Asc(cDigito)
    '                        Case 32             ' space
    '                        Case 35             ' #
    '                        Case 36             ' $
    '                        Case 38             ' &
    '                        Case 40 To 41       ' ()
    '                        Case 44             ' ,
    '                        Case 45             ' -
    '                        Case 46             ' .
    '                        Case 47             ' /
    '                        Case 48 To 57       ' 0 - 9
    '                        Case 63, 209        ' Ñ o sus variantes 
    '                        Case 65 To 90       ' A - Z
    '                        Case 97             ' a (por 2a. sección por ejemplo)
    '                        Case 111            ' o (cuando modifique la captura de los generales del cliente ya no lo voy a aceptar)
    '                        Case 118, 115       ' vs
    '                        Case 124            ' |
    '                        Case Else
    '                            cLeyenda = "ERROR"
    '                    End Select
    '                    If cDigito = " " Then
    '                        If nEspacios = 1 Then
    '                            cRenglon += cDigito
    '                            nEspacios += 1
    '                        End If
    '                    Else
    '                        If Asc(cDigito) = 63 Or Asc(cDigito) = 209 Then
    '                            cDigito = Chr(38)
    '                        End If
    '                        cRenglon += cDigito
    '                        nEspacios = 1
    '                    End If
    '                Next

    '                cAnexo = Mid(cRenglon, 10, 5) + Mid(cRenglon, 16, 4)

    '                ' Para la serie DV

    '                cFolio = Mid(cRenglon, 24, Len(i.ToString))
    '                cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - (24 + Len(i.ToString)))

    '                Select Case cIdentificador

    '                    Case "H3"

    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cNombre = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cNombre) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cCalle = Mid(cRenglon, nInicial, nFinal)
    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cCalle) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cNumeroExterior = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cNumeroExterior) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cNumeroInterior = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cNumeroInterior) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cColonia = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cColonia) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cDelegacion = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cDelegacion) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cEstado = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cEstado) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cCopos = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cCopos) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cCuentaPago = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cCuentaPago) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cFormaPago = Mid(cRenglon, nInicial, nFinal)

    '                    Case "D1"

    '                        newConcepto = New clsConcepto
    '                        With newConcepto
    '                            .cantidad = 1
    '                            cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - 4)
    '                            nInicial = 1
    '                            nFinal = cRenglon.IndexOf("|")
    '                            cDescripcion = Mid(cRenglon, nInicial, nFinal)
    '                            .descripcion = cDescripcion

    '                            cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cDescripcion) - 2)
    '                            nImporte = Round(CDbl(cRenglon), 2)
    '                            .valorUnitario = nImporte
    '                            .importe = nImporte

    '                        End With
    '                        newCFD.lstConceptos.Add(newConcepto)

    '                    Case "S1"

    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        nSubTotal = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(nSubTotal.ToString) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        nIva = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(nIva.ToString) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        nTotal = Mid(cRenglon, nInicial, nFinal)

    '                        nSubTotal = Round(CDbl(nSubTotal), 2)
    '                        nIva = Round(CDbl(nIva), 2)
    '                        nTotal = Round(CDbl(nTotal), 2)

    '                    Case "Z1"

    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cCheque = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cCheque) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cRfc = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cRfc) - 1)
    '                        cLeyenda = cRenglon

    '                End Select

    '            End While

    '            ' Una vez que cerré la conexión y que generé los asientos contables, podría generar el CFD (Certificado Fiscal Digital)

    '            cFecha = Mid(cFecha, 1, 4) + "-" + Mid(cFecha, 5, 2) + "-" + Mid(cFecha, 7, 2) + "T" + Mid(Now.TimeOfDay.ToString, 1, 8)
    '            'cFecha = Mid(cFecha, 1, 4) + "-" + Mid(cFecha, 5, 2) + "-" + Mid(cFecha, 7, 2) + "T17:58:00"

    '            With newCFD
    '                .version = "2.2"
    '                .serie = "DV"                                   ' La serie dependerá de la sucursal que esté expidiendo el CFD
    '                .folio = cFolio
    '                .fecha = cFecha                                 ' Esta fecha es la de aplicación del pago (cFecha), no la de realización del pago
    '                .noAprobacion = "1320436"                       ' El número de aprobación dependerá de la sucursal que esté expidiendo el CFD
    '                .anoAprobacion = "2011"                         ' El año de aprobación dependerá de la sucursal que esté expidiendo el CFD
    '                .formaDePago = "PAGO EN UNA SOLA EXHIBICION"
    '                .subTotal = nSubTotal
    '                .total = nTotal
    '                .tipoDeComprobante = "ingreso"
    '                .anexo = cAnexo
    '                .importeLetra = Letras(nTotal.ToString)
    '                .leyenda = cLeyenda
    '                .monto = 0.0
    '                .iva = 0.0
    '                .metodoDePago = cFormaPago
    '                .LugarExpedicion = "TOLUCA, ESTADO DE MEXICO"
    '                .NumCtaPago = cCuentaPago
    '                .cadenaOriginal = ""
    '            End With

    '            ' Los datos de expedición dependerán de la sucursal que esté expidiendo el CFD

    '            With newCFD.emisor
    '                .expedidoEn_calle = "LEANDRO VALLE 402"
    '                .expedidoEn_colonia = "REFORMA Y FFCCNN"
    '                .expedidoEn_municipio = "TOLUCA"
    '                .expedidoEn_estado = "ESTADO DE MEXICO"
    '                .expedidoEn_pais = "MEXICO"
    '                .expedidoEn_codigoPostal = "50070"
    '            End With

    '            With newCFD.receptor
    '                .rfc = Trim(cRfc)
    '                .nombre = Trim(cNombre)
    '                .calle = Trim(cCalle)
    '                .colonia = Trim(cColonia)
    '                .municipio = Trim(cDelegacion)
    '                .estado = Trim(cEstado)
    '                .pais = "MEXICO"
    '                .codigoPostal = Trim(cCopos)
    '            End With

    '            With newCFD.impuestos
    '                .impuesto = "IVA"
    '                .tasa = IIf(nIva > 0, "16.00", "0.00")          ' La tasa del impuesto dependerá del lugar de expedición
    '                .importe = nIva
    '            End With

    '            CFD(newCFD)

    '            oArchivo.Close()
    '            oArchivo = Nothing

    '        End If

    '    Next

    '    MsgBox("Generación de facturas electrónicas SERIE DV terminado", MsgBoxStyle.Information, "Mensaje")

    'End Sub

    'Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click

    '    Dim i As Integer = 0
    '    Dim j As Integer = 0
    '    Dim cRenglon As String
    '    Dim cDigito As String
    '    Dim cRenglonOriginal As String
    '    Dim cFolio As String = ""
    '    Dim nInicial As Integer
    '    Dim nFinal As Integer
    '    Dim cIdentificador As String
    '    Dim cCliente As String
    '    Dim nSubTotal As Decimal = 0
    '    Dim nIva As Decimal = 0
    '    Dim nTotal As Decimal = 0
    '    Dim cAnexo As String
    '    Dim cNombre As String
    '    Dim cCalle As String
    '    Dim cNumeroExterior As String
    '    Dim cNumeroInterior As String
    '    Dim cColonia As String
    '    Dim cDelegacion As String
    '    Dim cEstado As String
    '    Dim cCopos As String
    '    Dim cCheque As String
    '    Dim cRfc As String
    '    Dim cDescripcion As String
    '    Dim nImporte As Decimal
    '    Dim cFecha As String = ""
    '    Dim cLeyenda As String = ""
    '    Dim nEspacios As Integer = 0
    '    Dim cCuentaPago As String = ""
    '    Dim cFormaPago As String = ""

    '    ' Declaración de clases para generación de Certificado Fiscal Digital

    '    Dim newCFD As clsComprobante
    '    Dim newConcepto As clsConcepto

    '    Dim oArchivo As StreamReader


    '    For i = 1382 To 1382

    '        If i <> 0 Then                  ' Por si quisiera omitir algún archivo en específico

    '            Select Case i
    '                Case 1382
    '                    cFecha = "20130923"
    '            End Select

    '            cLeyenda = ""

    '            newCFD = New clsComprobante

    '            oArchivo = New StreamReader("C:\FACTURAS\2013\Serie MXL\FACTURA_MXL_" & i.ToString & ".TXT")

    '            While (oArchivo.Peek() > -1)

    '                cRenglonOriginal = RTrim(LTrim(oArchivo.ReadLine()))
    '                cIdentificador = Mid(cRenglonOriginal, 1, 2)
    '                If cIdentificador = "H3" Then
    '                    cRenglonOriginal = cRenglonOriginal.ToUpper()
    '                End If
    '                cRenglon = ""

    '                ' Tengo que quitar los espacios dobles intermedios

    '                nEspacios = 1
    '                For j = 1 To Len(cRenglonOriginal)
    '                    cDigito = Mid(cRenglonOriginal, j, 1)
    '                    Select Case Asc(cDigito)
    '                        Case 32             ' space
    '                        Case 35             ' #
    '                        Case 36             ' $
    '                        Case 38             ' &
    '                        Case 40 To 41       ' ()
    '                        Case 44             ' ,
    '                        Case 45             ' -
    '                        Case 46             ' .
    '                        Case 47             ' /
    '                        Case 48 To 57       ' 0 - 9
    '                        Case 63, 209        ' Ñ o sus variantes 
    '                        Case 65 To 90       ' A - Z
    '                        Case 97             ' a (por 2a. sección por ejemplo)
    '                        Case 111            ' o (cuando modifique la captura de los generales del cliente ya no lo voy a aceptar)
    '                        Case 118, 115       ' vs
    '                        Case 124            ' |
    '                        Case Else
    '                            cLeyenda = "ERROR"
    '                    End Select
    '                    If cDigito = " " Then
    '                        If nEspacios = 1 Then
    '                            cRenglon += cDigito
    '                            nEspacios += 1
    '                        End If
    '                    Else
    '                        If Asc(cDigito) = 63 Or Asc(cDigito) = 209 Then
    '                            cDigito = Chr(38)
    '                        End If
    '                        cRenglon += cDigito
    '                        nEspacios = 1
    '                    End If
    '                Next

    '                cAnexo = Mid(cRenglon, 10, 5) + Mid(cRenglon, 16, 4)

    '                ' Para la serie MXL

    '                cFolio = Mid(cRenglon, 25, Len(i.ToString))
    '                cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - (25 + Len(i.ToString)))

    '                Select Case cIdentificador

    '                    Case "H3"

    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cNombre = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cNombre) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cCalle = Mid(cRenglon, nInicial, nFinal)
    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cCalle) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cNumeroExterior = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cNumeroExterior) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cNumeroInterior = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cNumeroInterior) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cColonia = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cColonia) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cDelegacion = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cDelegacion) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cEstado = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cEstado) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cCopos = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cCopos) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cCuentaPago = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cCuentaPago) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cFormaPago = Mid(cRenglon, nInicial, nFinal)

    '                    Case "D1"

    '                        newConcepto = New clsConcepto
    '                        With newConcepto
    '                            .cantidad = 1
    '                            cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - 4)
    '                            nInicial = 1
    '                            nFinal = cRenglon.IndexOf("|")
    '                            cDescripcion = Mid(cRenglon, nInicial, nFinal)
    '                            .descripcion = cDescripcion

    '                            cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cDescripcion) - 2)
    '                            nImporte = Round(CDbl(cRenglon), 2)
    '                            .valorUnitario = nImporte
    '                            .importe = nImporte

    '                        End With
    '                        newCFD.lstConceptos.Add(newConcepto)

    '                    Case "S1"

    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        nSubTotal = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(nSubTotal.ToString) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        nIva = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(nIva.ToString) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        nTotal = Mid(cRenglon, nInicial, nFinal)

    '                        nSubTotal = Round(CDbl(nSubTotal), 2)
    '                        nIva = Round(CDbl(nIva), 2)
    '                        nTotal = Round(CDbl(nTotal), 2)

    '                    Case "Z1"

    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cCheque = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cCheque) - 1)
    '                        nInicial = 1
    '                        nFinal = cRenglon.IndexOf("|")
    '                        cRfc = Mid(cRenglon, nInicial, nFinal)

    '                        cRenglon = Microsoft.VisualBasic.Right(cRenglon, Len(cRenglon) - Len(cRfc) - 1)
    '                        cLeyenda = cRenglon

    '                End Select

    '            End While

    '            ' Una vez que cerré la conexión y que generé los asientos contables, podría generar el CFD (Certificado Fiscal Digital)

    '            '              cFecha = Mid(cFecha, 1, 4) + "-" + Mid(cFecha, 5, 2) + "-" + Mid(cFecha, 7, 2) + "T" + Mid(Now.TimeOfDay.ToString, 1, 8)
    '            cFecha = Mid(cFecha, 1, 4) + "-" + Mid(cFecha, 5, 2) + "-" + Mid(cFecha, 7, 2) + "T15:20:12"

    '            With newCFD
    '                .version = "2.2"
    '                .serie = "MXL"                                  ' La serie dependerá de la sucursal que esté expidiendo el CFD
    '                .folio = cFolio
    '                .fecha = cFecha                                 ' Esta fecha es la de aplicación del pago (cFecha), no la de realización del pago
    '                .noAprobacion = "202511"                        ' El número de aprobación dependerá de la sucursal que esté expidiendo el CFD
    '                .anoAprobacion = "2010"                         ' El año de aprobación dependerá de la sucursal que esté expidiendo el CFD
    '                .formaDePago = "PAGO EN UNA SOLA EXHIBICION"
    '                .subTotal = nSubTotal
    '                .total = nTotal
    '                .tipoDeComprobante = "ingreso"
    '                .anexo = cAnexo
    '                .importeLetra = Letras(nTotal.ToString)
    '                .leyenda = cLeyenda
    '                .monto = 0.0
    '                .iva = 0.0
    '                .metodoDePago = cFormaPago
    '                .LugarExpedicion = "MEXICALI, B. C."
    '                .NumCtaPago = cCuentaPago
    '                .cadenaOriginal = ""
    '            End With

    '            ' Los datos de expedición dependerán de la sucursal que esté expidiendo el CFD

    '            With newCFD.emisor
    '                .expedidoEn_calle = "AV. RIO SAN ANGEL 48 LOCALES 7 Y 8"
    '                .expedidoEn_colonia = "COL. VALLE DE PUEBLA"
    '                .expedidoEn_municipio = "MEXICALI"
    '                .expedidoEn_estado = "B.C."
    '                .expedidoEn_pais = "MEXICO"
    '                .expedidoEn_codigoPostal = "21384"
    '            End With

    '            With newCFD.receptor
    '                .rfc = Trim(cRfc)
    '                .nombre = Trim(cNombre)
    '                .calle = Trim(cCalle)
    '                .colonia = Trim(cColonia)
    '                .municipio = Trim(cDelegacion)
    '                .estado = Trim(cEstado)
    '                .pais = "MEXICO"
    '                .codigoPostal = Trim(cCopos)
    '            End With

    '            With newCFD.impuestos
    '                .impuesto = "IVA"
    '                .tasa = IIf(nIva > 0, "11.00", "0.00")          ' La tasa del impuesto dependerá del lugar de expedición
    '                .importe = nIva
    '            End With

    '            CFD(newCFD)

    '            oArchivo.Close()
    '            oArchivo = Nothing

    '        End If

    '    Next

    '    MsgBox("Generación de facturas electrónicas SERIE MXL terminado", MsgBoxStyle.Information, "Mensaje")

    'End Sub


    Private Sub btnEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnviar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daFacturas As New SqlDataAdapter(cm1)
        Dim dsAgil As New DataSet()
        Dim drFactura As DataRow

        ' Declaración de variables necesarias para enviar correo electrónico a través de Microsoft Outlook

        Dim oApp As Outlook._Application
        Dim oMsg As Outlook._MailItem
        Dim sSourceXML As String = ""
        Dim sSourcePDF As String = ""
        Dim oAttachs As Outlook.Attachments
        Dim oAttach As Outlook.Attachment

        ' Declaración de variables de datos

        Dim cAnexo As String = 0
        Dim cEmail1 As String = ""
        Dim cEmail2 As String = ""
        Dim cSerie As String = ""
        Dim nFactura As Decimal = 0

        ' Este Stored Procedure trae todas las facturas de una fecha determinada, de los
        ' clientes que tengan dirección de correo electrónico y que no les haya sido
        ' enviado su aviso de vencimiento de renta con anterioridad.

        With cm1
            .CommandType = CommandType.Text
            .CommandText = "SELECT DISTINCT Serie, Numero, Historia.Anexo, Clientes.Cliente, Descr, Email1, Email2 FROM Historia " & _
                           "INNER JOIN Anexos ON Historia.Anexo = Anexos.Anexo " & _
                           "INNER JOIN Clientes ON Anexos.Cliente = Clientes.Cliente " & _
                           "WHERE Serie = 'A' AND Fecha >= '20120430' AND Fecha <= '20120430' AND Importe <> 0 AND Numero >= 60457 AND Numero <= 60565 AND ((Email1 <> '' AND Email1 <> '*') OR (Email2 <> '' AND Email2 <> '*')) " & _
                           "ORDER BY Numero"
            .Connection = cnAgil
        End With

        ' Llenar el DataSet a través del DataAdapter, lo cual abre y cierra la conexión

        daFacturas.Fill(dsAgil, "Facturas")

        oApp = New Outlook.Application()

        For Each drFactura In dsAgil.Tables("Facturas").Rows

            nFactura = drFactura("Numero")

            If nFactura <> 0 Then

                cAnexo = drFactura("Anexo")
                cSerie = Trim(drFactura("Serie"))
                cEmail1 = Trim(drFactura("Email1"))
                cEmail2 = Trim(drFactura("Email2"))

                oMsg = oApp.CreateItem(Outlook.OlItemType.olMailItem)

                oMsg.Subject = "Factura electrónica " & cSerie & CStr(nFactura) & " enviada por FINAGIL SA DE CV SOFOM ENR"

                'oMsg.Body = "Contrato : " & Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 6, 4) & vbCr & vbCr & _
                '"ESTIMADO CLIENTE : " & vbCr & vbCr & _
                '"Por este medio le estamos enviando su factura electrónica (archivo con extensión XML)" & vbCr & _
                '"así  como  la  representación  gráfica  de  la  misma  (archivo con  extensión  PDF)." & vbCr & vbCr & _
                '"Es importante recordarle que  el  documento  válido  para  la  autoridad fiscal es el" & vbCr & _
                '"archivo con extensión XML el cual deberá guardar y conservar para efectos fiscales." & vbCr

                oMsg.BodyFormat = Outlook.OlBodyFormat.olFormatHTML
                oMsg.HTMLBody = "<HTML><head></head><BODY><img src='C:\Imagen 1.png'></BODY></HTML>"

                oMsg.To = cEmail1

                If cEmail2 <> "*" And cEmail2 <> "" Then
                    oMsg.CC = cEmail2
                Else
                    oMsg.CC = ""
                End If
                If cSerie = "A" Then
                    sSourceXML = "C:\Facturas\FACTURA_A_" & CStr(nFactura) & ".XML"
                    sSourcePDF = "C:\Facturas\FACTURA_A_" & CStr(nFactura) & ".PDF"
                ElseIf cSerie = "MXL" Then
                    sSourceXML = "C:\Facturas\FACTURA_MXL_" & CStr(nFactura) & ".XML"
                    sSourcePDF = "C:\Facturas\FACTURA_MXL_" & CStr(nFactura) & ".PDF"
                End If
                oAttachs = oMsg.Attachments
                oAttach = oAttachs.Add(sSourceXML)
                oAttach = oAttachs.Add(sSourcePDF)
                oMsg.Send()

                oAttach = Nothing
                oAttachs = Nothing
                oMsg = Nothing

            End If

        Next

        oApp = Nothing

        cnAgil.Dispose()
        cm1.Dispose()

        MsgBox("Envío de facturas electrónicas terminado", MsgBoxStyle.Information, "Mensaje")

    End Sub

End Class