Imports GenSelloDigital.crypto100
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates
Imports System.IO
Imports CrystalDecisions.Shared

Module mCFD

    ' Esta subrutina recibe como parámetro el CFD con información para generar la cadena original,
    ' calcular el sello digital, crear el archivo XML y crear e imprimir el archivo PDF

    Public Sub CFD(ByRef newCFD As clsComprobante)

        ' Declaración de variables de conexión ADO .NET

        Dim dsAgil As New DataSet
        Dim dtComprobante As New DataTable("Comprobante")
        Dim dtEmisor As New DataTable("Emisor")
        Dim dtReceptor As New DataTable("Receptor")
        Dim dtConceptos As New DataTable("Conceptos")
        Dim dtImpuestos As New DataTable("Impuestos")
        Dim drComprobante As DataRow
        Dim drEmisor As DataRow
        Dim drReceptor As DataRow
        Dim drConcepto As DataRow
        Dim drImpuesto As DataRow
        Dim newConcepto As clsConcepto

        ' Declaración de variables de Crystal Reports

        Dim newrptCFD As New rptCFD()
        Dim crDiskFileDestinationOptions As New DiskFileDestinationOptions()

        ' El certificado es el mismo para todas las sucursales y para todos los productos

        Dim sCertificado As Byte()
        Dim x509 As New X509Certificate2
        'Dim rawData As Byte() = ReadFile("C:\CFD\00001000000102146193.cer")
        Dim rawData As Byte() = ReadFile("C:\CFD\00001000000202313825.cer")

        Dim newSelloDigital As New GenSelloDigital.crypto100
        Dim cCadenaOriginal As String

        ' Las siguientes tablas las ocupo para almacenar la información que viene de la clase newCFD y poder enviarlas a rtpCFD

        dtComprobante.Columns.Add("serie", Type.GetType("System.String"))
        dtComprobante.Columns.Add("folio", Type.GetType("System.String"))
        dtComprobante.Columns.Add("fecha", Type.GetType("System.String"))
        dtComprobante.Columns.Add("sello", Type.GetType("System.String"))
        dtComprobante.Columns.Add("noAprobacion", Type.GetType("System.String"))
        dtComprobante.Columns.Add("anoAprobacion", Type.GetType("System.String"))
        dtComprobante.Columns.Add("formaDePago", Type.GetType("System.String"))
        dtComprobante.Columns.Add("noCertificado", Type.GetType("System.String"))
        dtComprobante.Columns.Add("subTotal", Type.GetType("System.Decimal"))
        dtComprobante.Columns.Add("total", Type.GetType("System.Decimal"))
        dtComprobante.Columns.Add("tipoDeComprobante", Type.GetType("System.String"))
        dtComprobante.Columns.Add("anexo", Type.GetType("System.String"))               ' Este campo no aparece en el XML sólo en el PDF
        dtComprobante.Columns.Add("importeLetra", Type.GetType("System.String"))        ' Este campo no aparece en el XML sólo en el PDF
        dtComprobante.Columns.Add("leyenda", Type.GetType("System.String"))
        dtComprobante.Columns.Add("metodoDePago", Type.GetType("System.String"))
        dtComprobante.Columns.Add("cadenaOriginal", Type.GetType("System.String"))      ' Este campo no aparece en el XML sólo en el PDF

        dtEmisor.Columns.Add("expedidoEn_municipio", Type.GetType("System.String"))
        dtEmisor.Columns.Add("expedidoEn_estado", Type.GetType("System.String"))
        dtEmisor.Columns.Add("regimen", Type.GetType("System.String"))

        dtReceptor.Columns.Add("rfc", Type.GetType("System.String"))
        dtReceptor.Columns.Add("nombre", Type.GetType("System.String"))
        dtReceptor.Columns.Add("calle", Type.GetType("System.String"))
        dtReceptor.Columns.Add("colonia", Type.GetType("System.String"))
        dtReceptor.Columns.Add("municipio", Type.GetType("System.String"))
        dtReceptor.Columns.Add("estado", Type.GetType("System.String"))
        dtReceptor.Columns.Add("pais", Type.GetType("System.String"))
        dtReceptor.Columns.Add("codigoPostal", Type.GetType("System.String"))

        dtConceptos.Columns.Add("descripcion", Type.GetType("System.String"))
        dtConceptos.Columns.Add("importe", Type.GetType("System.Decimal"))

        dtImpuestos.Columns.Add("impuesto", Type.GetType("System.String"))
        dtImpuestos.Columns.Add("tasa", Type.GetType("System.Decimal"))
        dtImpuestos.Columns.Add("importe", Type.GetType("System.Decimal"))

        x509.Import(rawData)
        sCertificado = x509.PublicKey.EncodedKeyValue.RawData
        sCertificado = x509.RawData

        cCadenaOriginal = newCFD.GeneraCadenaOriginal()
        newCFD.cadenaOriginal = cCadenaOriginal
        'newCFD.sello = newSelloDigital.GeneraSelloDigital("C:\CFD\00001000000102146193.cer", "C:\CFD\fin940905ax7_1011031910s.key", "PEMM0966M", cCadenaOriginal, "SHA1")(0)
        newCFD.sello = newSelloDigital.GeneraSelloDigital("C:\CFD\00001000000202313825.cer", "C:\CFD\fin940905ax7_1211091142s.key", "FINAGIL01", cCadenaOriginal, "SHA1")(0)
        'newCFD.noCertificado = "00001000000102146193"
        newCFD.noCertificado = "00001000000202313825"
        newCFD.certificado = Convert.ToBase64String(sCertificado)
        newCFD.GeneraXML_Basico("C:\Facturas")

        ' Aquí imprimo la representación gráfica del CFD

        drComprobante = dtComprobante.NewRow
        drComprobante("serie") = newCFD.serie
        drComprobante("folio") = newCFD.folio
        drComprobante("fecha") = newCFD.fecha
        drComprobante("sello") = newCFD.sello
        drComprobante("noAprobacion") = newCFD.noAprobacion
        drComprobante("anoAprobacion") = newCFD.anoAprobacion
        drComprobante("formaDePago") = newCFD.formaDePago
        drComprobante("noCertificado") = newCFD.noCertificado
        drComprobante("subTotal") = newCFD.subTotal
        drComprobante("total") = newCFD.total
        drComprobante("tipoDeComprobante") = newCFD.tipoDeComprobante
        drComprobante("anexo") = newCFD.anexo
        drComprobante("importeLetra") = newCFD.importeLetra
        drComprobante("leyenda") = newCFD.leyenda
        drComprobante("metodoDePago") = newCFD.metodoDePago & " " & newCFD.NumCtaPago
        drComprobante("cadenaOriginal") = newCFD.cadenaOriginal
        dtComprobante.Rows.Add(drComprobante)

        drEmisor = dtEmisor.NewRow
        drEmisor("expedidoEn_municipio") = newCFD.emisor.expedidoEn_municipio
        drEmisor("expedidoEn_estado") = newCFD.emisor.expedidoEn_estado
        drEmisor("regimen") = newCFD.emisor.RegimenFiscal_Regimen
        dtEmisor.Rows.Add(drEmisor)

        drReceptor = dtReceptor.NewRow
        drReceptor("rfc") = newCFD.receptor.rfc
        drReceptor("nombre") = newCFD.receptor.nombre
        drReceptor("calle") = newCFD.receptor.calle
        drReceptor("colonia") = newCFD.receptor.colonia
        drReceptor("municipio") = newCFD.receptor.municipio
        drReceptor("estado") = newCFD.receptor.estado
        drReceptor("pais") = newCFD.receptor.pais
        drReceptor("codigoPostal") = newCFD.receptor.codigoPostal
        dtReceptor.Rows.Add(drReceptor)

        For Each newConcepto In newCFD.lstConceptos
            drConcepto = dtConceptos.NewRow
            drConcepto("descripcion") = newConcepto.descripcion
            drConcepto("importe") = newConcepto.importe
            dtConceptos.Rows.Add(drConcepto)
        Next

        drImpuesto = dtImpuestos.NewRow
        drImpuesto("impuesto") = newCFD.impuestos.impuesto
        drImpuesto("tasa") = newCFD.impuestos.tasa
        drImpuesto("importe") = newCFD.impuestos.importe
        dtImpuestos.Rows.Add(drImpuesto)

        dsAgil.Tables.Add(dtComprobante)
        dsAgil.Tables.Add(dtEmisor)
        dsAgil.Tables.Add(dtReceptor)
        dsAgil.Tables.Add(dtConceptos)
        dsAgil.Tables.Add(dtImpuestos)

        ' Descomentar esta línea si se deseara modificar el reporte rptCFD.rpt
        '  dsAgil.WriteXml("C:\xmlCFD.xml", XmlWriteMode.WriteSchema)
        newrptCFD.SetDataSource(dsAgil)

        newrptCFD.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
        newrptCFD.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat
        crDiskFileDestinationOptions.DiskFileName = "C:\Facturas\FACTURA_" & newCFD.serie & "_" & newCFD.folio & ".PDF"
        ' crDiskFileDestinationOptions.DiskFileName = "C:\Facturas\CREDITO_" & newCFD.serie & "_" & newCFD.folio & ".PDF"
        newrptCFD.ExportOptions.DestinationOptions = crDiskFileDestinationOptions
        newrptCFD.Export()

        ' newrptCFD.PrintToPrinter(1, False, 0, 0)
        newrptCFD.Dispose()

    End Sub

    Private Function ReadFile(ByVal fileName As String) As Byte()

        Dim f As New FileStream(fileName, FileMode.Open, FileAccess.Read)
        Dim size As Integer = Fix(f.Length)
        Dim data(size) As Byte
        size = f.Read(data, 0, size)
        f.Close()
        Return data

    End Function

End Module
