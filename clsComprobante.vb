Imports System.Collections.Generic

Public Class clsComprobante

    Public version As String
    Public serie As String
    Public folio As String
    Public fecha As String
    Public sello As String
    Public noAprobacion As String
    Public anoAprobacion As String
    Public formaDePago As String
    Public noCertificado As String
    Public certificado As String
    Public subTotal As Decimal
    Public total As Decimal
    Public tipoDeComprobante As String
    Public condicionesDePago As String
    Public LugarExpedicion As String
    Public NumCtaPago As String
    Public TipoCambio As String
    Public Moneda As String
   
    Public emisor As clsEmisor
    Public receptor As clsReceptor
    Public lstConceptos As List(Of clsConcepto)
    Public impuestos As clsImpuestos

    Public anexo As String
    Public importeLetra As String                       ' Este atributo de la clase no se utiliza en la generación del XML, sólo se utiliza en la generación del PDF
    Public leyenda As String
    Public monto As Decimal
    Public iva As Decimal
    Public metodoDePago As String
    Public cadenaOriginal As String                     ' Este atributo de la clase no se utiliza en la generación del XML, sólo se utiliza en la generación del PDF

    Public Sub New()

        version = ""
        serie = ""
        folio = ""
        fecha = ""
        sello = ""
        noAprobacion = ""
        anoAprobacion = ""
        formaDePago = ""
        noCertificado = ""
        certificado = ""
        subTotal = 0.0
        total = 0.0
        tipoDeComprobante = ""
        condicionesDePago = "CONTADO"
        LugarExpedicion = ""
        NumCtaPago = ""
        TipoCambio = "1.00"
        Moneda = "Peso Mexicano"
        emisor = New clsEmisor
        receptor = New clsReceptor
        lstConceptos = New List(Of clsConcepto)
        impuestos = New clsImpuestos

        anexo = ""
        importeLetra = ""
        leyenda = ""
        monto = 0.0
        iva = 0.0
        metodoDePago = ""
        cadenaOriginal = ""

    End Sub

    Public Function GeneraCadenaOriginal() As String

        Dim cCadenaOriginal As String = ""
        Dim clsElemento As clsConcepto
        Dim s As String = "|"

        cCadenaOriginal = s & s

        With Me
            cCadenaOriginal = cCadenaOriginal + .version + s
            If Not String.IsNullOrEmpty(.serie) Then
                cCadenaOriginal = cCadenaOriginal + .serie + s
            End If
            cCadenaOriginal = cCadenaOriginal + .folio + s
            cCadenaOriginal = cCadenaOriginal + .fecha + s
            cCadenaOriginal = cCadenaOriginal + .noAprobacion + s
            cCadenaOriginal = cCadenaOriginal + .anoAprobacion + s
            cCadenaOriginal = cCadenaOriginal + .tipoDeComprobante + s
            cCadenaOriginal = cCadenaOriginal + .formaDePago + s
            cCadenaOriginal = cCadenaOriginal + .condicionesDePago + s
            cCadenaOriginal = cCadenaOriginal + .subTotal.ToString + s
            cCadenaOriginal = cCadenaOriginal + .total.ToString + s
            cCadenaOriginal = cCadenaOriginal + .metodoDePago + s
            cCadenaOriginal = cCadenaOriginal + .LugarExpedicion + s
            cCadenaOriginal = cCadenaOriginal + .NumCtaPago + s
            cCadenaOriginal = cCadenaOriginal + .TipoCambio + s
            cCadenaOriginal = cCadenaOriginal + .Moneda + s
        End With

        With emisor
            cCadenaOriginal = cCadenaOriginal + .rfc + s
            cCadenaOriginal = cCadenaOriginal + .nombre + s
            cCadenaOriginal = cCadenaOriginal + .calle + s
            If Not String.IsNullOrEmpty(.colonia) Then
                cCadenaOriginal = cCadenaOriginal + .colonia + s
            End If
            If Not String.IsNullOrEmpty(.municipio) Then
                cCadenaOriginal = cCadenaOriginal + .municipio + s
            End If
            cCadenaOriginal = cCadenaOriginal + .estado + s
            cCadenaOriginal = cCadenaOriginal + .pais + s
            cCadenaOriginal = cCadenaOriginal + .codigoPostal + s
            If Not String.IsNullOrEmpty(.expedidoEn_calle) Then
                cCadenaOriginal = cCadenaOriginal + .expedidoEn_calle.ToString + s
            End If
            If Not String.IsNullOrEmpty(.expedidoEn_colonia) Then
                cCadenaOriginal = cCadenaOriginal + .expedidoEn_colonia + s
            End If
            If Not String.IsNullOrEmpty(.expedidoEn_municipio) Then
                cCadenaOriginal = cCadenaOriginal + .expedidoEn_municipio + s
            End If
            If Not String.IsNullOrEmpty(.expedidoEn_estado) Then
                cCadenaOriginal = cCadenaOriginal + .expedidoEn_estado + s
            End If
            cCadenaOriginal = cCadenaOriginal + .expedidoEn_pais + s
            If Not String.IsNullOrEmpty(.expedidoEn_codigoPostal) Then
                cCadenaOriginal = cCadenaOriginal + .expedidoEn_codigoPostal + s
            End If
            cCadenaOriginal = cCadenaOriginal + .RegimenFiscal_Regimen + s
        End With

        With receptor
            cCadenaOriginal = cCadenaOriginal + .rfc + s
            If Not String.IsNullOrEmpty(.nombre) Then
                cCadenaOriginal = cCadenaOriginal + .nombre + s
            End If
            If Not String.IsNullOrEmpty(.calle) Then
                cCadenaOriginal = cCadenaOriginal + .calle.ToString + s
            End If
            If Not String.IsNullOrEmpty(.colonia) Then
                cCadenaOriginal = cCadenaOriginal + .colonia + s
            End If
            If Not String.IsNullOrEmpty(.municipio) Then
                cCadenaOriginal = cCadenaOriginal + .municipio + s
            End If
            If Not String.IsNullOrEmpty(.estado) Then
                cCadenaOriginal = cCadenaOriginal + .estado + s
            End If
            cCadenaOriginal = cCadenaOriginal + .pais + s
            If Not String.IsNullOrEmpty(.codigoPostal) Then
                cCadenaOriginal = cCadenaOriginal + .codigoPostal + s
            End If
        End With

        For Each clsElemento In lstConceptos
            With clsElemento
                cCadenaOriginal = cCadenaOriginal + .cantidad.ToString + s
                cCadenaOriginal = cCadenaOriginal + .unidad + s
                cCadenaOriginal = cCadenaOriginal + .descripcion + s
                cCadenaOriginal = cCadenaOriginal + .valorUnitario.ToString + s
                cCadenaOriginal = cCadenaOriginal + .importe.ToString + s
            End With
        Next

        With impuestos
            cCadenaOriginal = cCadenaOriginal + .impuesto + s
            cCadenaOriginal = cCadenaOriginal + .tasa.ToString + s
            cCadenaOriginal = cCadenaOriginal + .importe.ToString + s
        End With

        Return cCadenaOriginal + s

    End Function

    Public Sub GeneraXML_Basico(ByVal PATH_salida As String)

        Dim mywriter As System.Xml.XmlTextWriter
        Dim rutaxml As String

        Dim newConcepto As clsConcepto

        'rutaxml = PATH_salida & "\FACTURA_" & Me.serie & "_" & Me.folio.ToString & ".XML"
        rutaxml = PATH_salida & "\CREDITO_" & Me.serie & "_" & Me.folio.ToString & ".XML"

        mywriter = New System.Xml.XmlTextWriter(rutaxml, System.Text.Encoding.UTF8)
        mywriter.Indentation = 4
        mywriter.IndentChar = " "
        mywriter.Formatting = System.Xml.Formatting.Indented

        With mywriter

            .WriteStartDocument()                                                           ' XML inicio

            .WriteStartElement("Comprobante")                                               ' COMPROBANTE inicio
            .WriteAttributeString("xmlns", "http://www.sat.gob.mx/cfd/2")
            .WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance")
            .WriteAttributeString("xsi:schemaLocation", "http://www.sat.gob.mx/cfd/2 http://www.sat.gob.mx/sitio_internet/cfd/2/cfdv22.xsd")
            .WriteAttributeString("version", "2.2")
            If Me.serie <> "" Then
                .WriteAttributeString("serie", Me.serie)
            End If
            .WriteAttributeString("folio", Me.folio)
            .WriteAttributeString("fecha", Me.fecha)
            .WriteAttributeString("sello", Me.sello)
            .WriteAttributeString("noAprobacion", Me.noAprobacion.ToString)
            .WriteAttributeString("anoAprobacion", Me.anoAprobacion.ToString)
            .WriteAttributeString("formaDePago", Me.formaDePago)
            .WriteAttributeString("noCertificado", Me.noCertificado)
            If Me.certificado <> "" Then
                .WriteAttributeString("certificado", Me.certificado)
            End If
            .WriteAttributeString("condicionesDePago", Me.condicionesDePago)
            .WriteAttributeString("subTotal", Me.subTotal.ToString)
            .WriteAttributeString("total", Me.total.ToString)
            .WriteAttributeString("metodoDePago", Me.metodoDePago)
            .WriteAttributeString("tipoDeComprobante", Me.tipoDeComprobante)
            .WriteAttributeString("LugarExpedicion", Me.LugarExpedicion)
            .WriteAttributeString("NumCtaPago", Me.NumCtaPago.ToString)
            .WriteAttributeString("TipoCambio", Me.TipoCambio.ToString)
            .WriteAttributeString("Moneda", Me.Moneda)

            .WriteStartElement("Emisor")                                                    ' EMISOR inicio
            .WriteAttributeString("rfc", Me.emisor.rfc)
            .WriteAttributeString("nombre", Me.emisor.nombre)
            
            .WriteStartElement("DomicilioFiscal")                                           ' Domicilio Fiscal inicio
            .WriteAttributeString("calle", Me.emisor.calle)
            If Me.emisor.colonia <> "" Then
                .WriteAttributeString("colonia", Me.emisor.colonia)
            End If
            .WriteAttributeString("municipio", Me.emisor.municipio)
            .WriteAttributeString("estado", Me.emisor.estado)
            .WriteAttributeString("pais", Me.emisor.pais)
            .WriteAttributeString("codigoPostal", Me.emisor.codigoPostal)
            .WriteEndElement()                                                              ' Domicilio Fiscal fin

            .WriteStartElement("ExpedidoEn")                                                ' ExpedidoEn inicio
            .WriteAttributeString("calle", Me.emisor.expedidoEn_calle)
            .WriteAttributeString("colonia", Me.emisor.expedidoEn_colonia)
            .WriteAttributeString("municipio", Me.emisor.expedidoEn_municipio)
            .WriteAttributeString("estado", Me.emisor.expedidoEn_estado)
            .WriteAttributeString("pais", Me.emisor.expedidoEn_pais)
            .WriteAttributeString("codigoPostal", Me.emisor.expedidoEn_codigoPostal)
            .WriteEndElement()                                                              ' ExpedidoEn fin

            .WriteStartElement("RegimenFiscal")                                             ' RegimenFiscal inicio
            .WriteAttributeString("Regimen", Me.emisor.regimenFiscal_Regimen)
            .WriteEndElement()                                                              ' RegimenFiscal fin

            .WriteEndElement()                                                              ' EMISOR fin

            .WriteStartElement("Receptor")                                                  ' RECEPTOR inicio
            .WriteAttributeString("rfc", Me.receptor.rfc)
            .WriteAttributeString("nombre", Me.receptor.nombre)

            .WriteStartElement("Domicilio")                                                 ' Domicilio inicio
            If Me.receptor.calle <> "" Then
                .WriteAttributeString("calle", Me.receptor.calle)
            End If
            If Me.receptor.colonia <> "" Then
                .WriteAttributeString("colonia", Me.receptor.colonia)
            End If
            If Me.receptor.municipio <> "" Then
                .WriteAttributeString("municipio", Me.receptor.municipio)
            End If
            If Me.receptor.estado <> "" Then
                .WriteAttributeString("estado", Me.receptor.estado)
            End If
            .WriteAttributeString("pais", Me.receptor.pais)
            If Me.receptor.codigoPostal <> "" Then
                .WriteAttributeString("codigoPostal", Me.receptor.codigoPostal)
            End If
            .WriteEndElement()                                                              ' Domicilio fin

            .WriteEndElement()                                                              ' RECEPTOR fin

            .WriteStartElement("Conceptos")                                                 ' CONCEPTOS inicio
            For Each newConcepto In Me.lstConceptos
                .WriteStartElement("Concepto")                                              ' Concepto inicio
                .WriteAttributeString("cantidad", newConcepto.cantidad.ToString)
                .WriteAttributeString("unidad", newConcepto.unidad)
                .WriteAttributeString("descripcion", newConcepto.descripcion)
                .WriteAttributeString("valorUnitario", newConcepto.valorUnitario.ToString)
                .WriteAttributeString("importe", newConcepto.importe.ToString)
                .WriteEndElement()                                                          ' Concepto fin
            Next
            .WriteEndElement()                                                              ' CONCEPTOS fin

            .WriteStartElement("Impuestos")                                                 ' IMPUESTOS inicio
            .WriteStartElement("Traslados")                                                 ' Traslados inicio
            .WriteStartElement("Traslado")                                                  ' Traslado inicio
            .WriteAttributeString("impuesto", Me.impuestos.impuesto)
            .WriteAttributeString("tasa", Me.impuestos.tasa.ToString)
            .WriteAttributeString("importe", Me.impuestos.importe.ToString)
            .WriteEndElement()                                                              ' Traslado fin
            .WriteEndElement()                                                              ' Traslados fin
            .WriteEndElement()                                                              ' IMPUESTOS fin

            .WriteEndElement()                                                              ' COMPROBANTE fin

            .WriteEndDocument()                                                             ' XML fin

        End With

        If Not mywriter Is Nothing Then
            mywriter.Flush()
            mywriter.Close()
        End If

    End Sub

End Class
