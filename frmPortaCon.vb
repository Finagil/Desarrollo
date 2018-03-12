Option Explicit On

Imports System.Data.SqlClient
Imports System.Math
Imports System.IO

Public Class frmPortaCon

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim daReporte As New SqlDataAdapter(cm1)
        Dim daCartera As New SqlDataAdapter(cm2)

        Dim dsAgil As New DataSet()
        Dim dtVencida As New DataTable("Vencida")
        Dim dtAF As New DataTable("AF")
        Dim dtCR As New DataTable("CR")
        Dim dtCS As New DataTable("CS")
        Dim dtCHA As New DataTable("CHA")
        Dim dtCC As New DataTable("CC")
        Dim dtSeguros As New DataTable("Seguros")
        Dim dtExigible As New DataTable("Exigible")

        Dim drCartera As DataRow
        Dim drReporte As DataRow
        Dim drGeneral As DataRow
        Dim myColArray(0) As DataColumn
        Dim myKeySearch(0) As String

        ' Declaración de variables de datos

        Dim cAnexo As String = ""
        Dim cFecha As String = ""
        Dim cRenglon As String = ""
        Dim cTabla As String = ""
        Dim nCapitalExigibleVencido As Decimal = 0
        Dim nCarteraExigible As Decimal = 0
        Dim nCarteraVigente As Decimal = 0
        Dim nInteresVencido As Decimal = 0
        Dim nOtrosVencido As Decimal = 0
        Dim nProvision As Decimal = 0
        Dim nSaldoInsolutoVencido As Decimal = 0
        Dim nSeguroFinanciado As Decimal = 0
        Dim nSeguroVencido As Decimal = 0
        Dim nUxR As Decimal = 0
        Dim oArchivo As StreamReader

        Dim cCopos As String = ""
        Dim cDescPromotor As String = ""
        Dim cDescPlaza As String = ""
        Dim cProducto As String = ""
        Dim nTasa As Decimal = 0
        Dim nDiferencial As Decimal = 0
        Dim cTipoTasa As String = ""
        Dim cNombreCliente As String = ""
        Dim cFechaTerminacion As String = ""

        cFecha = DTOC(dtpProcesar.Value)

        ' Primero creo las 7 tablas que serán la base del reporte

        dtVencida.Columns.Add("Anexo", Type.GetType("System.String"))
        dtVencida.Columns.Add("Nombre", Type.GetType("System.String"))
        dtVencida.Columns.Add("CapitalExigible", Type.GetType("System.Decimal"))
        dtVencida.Columns.Add("SaldoInsoluto", Type.GetType("System.Decimal"))
        dtVencida.Columns.Add("Intereses", Type.GetType("System.Decimal"))
        dtVencida.Columns.Add("OtrosAdeudos", Type.GetType("System.Decimal"))
        dtVencida.Columns.Add("Seguros", Type.GetType("System.Decimal"))
        dtVencida.Columns.Add("Total", Type.GetType("System.Decimal"))
        dtVencida.Columns.Add("TipoTasa", Type.GetType("System.String"))
        dtVencida.Columns.Add("Tasa", Type.GetType("System.Decimal"))
        dtVencida.Columns.Add("Diferencial", Type.GetType("System.Decimal"))
        dtVencida.Columns.Add("Producto", Type.GetType("System.String"))
        dtVencida.Columns.Add("Plaza", Type.GetType("System.String"))
        dtVencida.Columns.Add("Código Postal", Type.GetType("System.String"))
        dtVencida.Columns.Add("Promotor", Type.GetType("System.String"))
        dtVencida.Columns.Add("FechaTerminacion", Type.GetType("System.String"))
        myColArray(0) = dtVencida.Columns("Anexo")
        dtVencida.PrimaryKey = myColArray

        dtAF.Columns.Add("Anexo", Type.GetType("System.String"))
        dtAF.Columns.Add("Nombre", Type.GetType("System.String"))
        dtAF.Columns.Add("CarteraVigente", Type.GetType("System.Decimal"))
        dtAF.Columns.Add("Provision", Type.GetType("System.Decimal"))
        dtAF.Columns.Add("UxR", Type.GetType("System.Decimal"))
        dtAF.Columns.Add("Total", Type.GetType("System.Decimal"))
        dtAF.Columns.Add("TipoTasa", Type.GetType("System.String"))
        dtAF.Columns.Add("Tasa", Type.GetType("System.Decimal"))
        dtAF.Columns.Add("Diferencial", Type.GetType("System.Decimal"))
        dtAF.Columns.Add("Producto", Type.GetType("System.String"))
        dtAF.Columns.Add("Plaza", Type.GetType("System.String"))
        dtAF.Columns.Add("Código Postal", Type.GetType("System.String"))
        dtAF.Columns.Add("Promotor", Type.GetType("System.String"))
        dtAF.Columns.Add("FechaTerminacion", Type.GetType("System.String"))
        myColArray(0) = dtAF.Columns("Anexo")
        dtAF.PrimaryKey = myColArray

        dtCR.Columns.Add("Anexo", Type.GetType("System.String"))
        dtCR.Columns.Add("Nombre", Type.GetType("System.String"))
        dtCR.Columns.Add("CarteraVigente", Type.GetType("System.Decimal"))
        dtCR.Columns.Add("Provision", Type.GetType("System.Decimal"))
        dtCR.Columns.Add("UxR", Type.GetType("System.Decimal"))
        dtCR.Columns.Add("Total", Type.GetType("System.Decimal"))
        dtCR.Columns.Add("TipoTasa", Type.GetType("System.String"))
        dtCR.Columns.Add("Tasa", Type.GetType("System.Decimal"))
        dtCR.Columns.Add("Diferencial", Type.GetType("System.Decimal"))
        dtCR.Columns.Add("Producto", Type.GetType("System.String"))
        dtCR.Columns.Add("Plaza", Type.GetType("System.String"))
        dtCR.Columns.Add("Código Postal", Type.GetType("System.String"))
        dtCR.Columns.Add("Promotor", Type.GetType("System.String"))
        dtCR.Columns.Add("FechaTerminacion", Type.GetType("System.String"))
        myColArray(0) = dtCR.Columns("Anexo")
        dtCR.PrimaryKey = myColArray

        dtCS.Columns.Add("Anexo", Type.GetType("System.String"))
        dtCS.Columns.Add("Nombre", Type.GetType("System.String"))
        dtCS.Columns.Add("CarteraVigente", Type.GetType("System.Decimal"))
        dtCS.Columns.Add("Provision", Type.GetType("System.Decimal"))
        dtCS.Columns.Add("UxR", Type.GetType("System.Decimal"))
        dtCS.Columns.Add("Total", Type.GetType("System.Decimal"))
        dtCS.Columns.Add("TipoTasa", Type.GetType("System.String"))
        dtCS.Columns.Add("Tasa", Type.GetType("System.Decimal"))
        dtCS.Columns.Add("Diferencial", Type.GetType("System.Decimal"))
        dtCS.Columns.Add("Producto", Type.GetType("System.String"))
        dtCS.Columns.Add("Plaza", Type.GetType("System.String"))
        dtCS.Columns.Add("Código Postal", Type.GetType("System.String"))
        dtCS.Columns.Add("Promotor", Type.GetType("System.String"))
        dtCS.Columns.Add("FechaTerminacion", Type.GetType("System.String"))
        myColArray(0) = dtCS.Columns("Anexo")
        dtCS.PrimaryKey = myColArray

        dtCHA.Columns.Add("Anexo", Type.GetType("System.String"))
        dtCHA.Columns.Add("Nombre", Type.GetType("System.String"))
        dtCHA.Columns.Add("CarteraVigente", Type.GetType("System.Decimal"))
        dtCHA.Columns.Add("Provision", Type.GetType("System.Decimal"))
        dtCHA.Columns.Add("Total", Type.GetType("System.Decimal"))
        dtCHA.Columns.Add("TipoTasa", Type.GetType("System.String"))
        dtCHA.Columns.Add("Tasa", Type.GetType("System.Decimal"))
        dtCHA.Columns.Add("Diferencial", Type.GetType("System.Decimal"))
        dtCHA.Columns.Add("Producto", Type.GetType("System.String"))
        dtCHA.Columns.Add("Plaza", Type.GetType("System.String"))
        dtCHA.Columns.Add("Código Postal", Type.GetType("System.String"))
        dtCHA.Columns.Add("Promotor", Type.GetType("System.String"))
        dtCHA.Columns.Add("FechaTerminacion", Type.GetType("System.String"))
        myColArray(0) = dtCHA.Columns("Anexo")
        dtCHA.PrimaryKey = myColArray

        dtCC.Columns.Add("Anexo", Type.GetType("System.String"))
        dtCC.Columns.Add("Nombre", Type.GetType("System.String"))
        dtCC.Columns.Add("CarteraVigente", Type.GetType("System.Decimal"))
        dtCC.Columns.Add("Provision", Type.GetType("System.Decimal"))
        dtCC.Columns.Add("Total", Type.GetType("System.Decimal"))
        dtCC.Columns.Add("TipoTasa", Type.GetType("System.String"))
        dtCC.Columns.Add("Tasa", Type.GetType("System.Decimal"))
        dtCC.Columns.Add("Diferencial", Type.GetType("System.Decimal"))
        dtCC.Columns.Add("Producto", Type.GetType("System.String"))
        dtCC.Columns.Add("Plaza", Type.GetType("System.String"))
        dtCC.Columns.Add("Código Postal", Type.GetType("System.String"))
        dtCC.Columns.Add("Promotor", Type.GetType("System.String"))
        dtCC.Columns.Add("FechaTerminacion", Type.GetType("System.String"))
        myColArray(0) = dtCC.Columns("Anexo")
        dtCC.PrimaryKey = myColArray

        dtSeguros.Columns.Add("Anexo", Type.GetType("System.String"))
        dtSeguros.Columns.Add("Nombre", Type.GetType("System.String"))
        dtSeguros.Columns.Add("SeguroFinanciado", Type.GetType("System.Decimal"))
        dtSeguros.Columns.Add("TipoTasa", Type.GetType("System.String"))
        dtSeguros.Columns.Add("Tasa", Type.GetType("System.Decimal"))
        dtSeguros.Columns.Add("Diferencial", Type.GetType("System.Decimal"))
        dtSeguros.Columns.Add("Producto", Type.GetType("System.String"))
        dtSeguros.Columns.Add("Plaza", Type.GetType("System.String"))
        dtSeguros.Columns.Add("Código Postal", Type.GetType("System.String"))
        dtSeguros.Columns.Add("Promotor", Type.GetType("System.String"))
        dtSeguros.Columns.Add("FechaTerminacion", Type.GetType("System.String"))
        myColArray(0) = dtSeguros.Columns("Anexo")
        dtSeguros.PrimaryKey = myColArray

        dtExigible.Columns.Add("Anexo", Type.GetType("System.String"))
        dtExigible.Columns.Add("Nombre", Type.GetType("System.String"))
        dtExigible.Columns.Add("CarteraExigible", Type.GetType("System.Decimal"))
        dtExigible.Columns.Add("TipoTasa", Type.GetType("System.String"))
        dtExigible.Columns.Add("Tasa", Type.GetType("System.Decimal"))
        dtExigible.Columns.Add("Diferencial", Type.GetType("System.Decimal"))
        dtExigible.Columns.Add("Producto", Type.GetType("System.String"))
        dtExigible.Columns.Add("Plaza", Type.GetType("System.String"))
        dtExigible.Columns.Add("Código Postal", Type.GetType("System.String"))
        dtExigible.Columns.Add("Promotor", Type.GetType("System.String"))
        dtExigible.Columns.Add("FechaTerminacion", Type.GetType("System.String"))
        myColArray(0) = dtExigible.Columns("Anexo")
        dtExigible.PrimaryKey = myColArray

        

        Dim tot As Double

        ' El siguiente Command trae el número de todos los contratos (Tradicionales, Avío y Cuenta Corriente)

        With cm1
            .CommandType = CommandType.Text
            .CommandText = "SELECT DISTINCT SUBSTRING(Anexo,1,5)+'/'+SUBSTRING(Anexo,6,4) AS Contrato, '' AS NombreCliente, '' As Tipta, 0 As Tasas, 0 As Diferencial, '' AS Tipar, '' AS DescPlaza, '' AS Copos, '' AS DescPromotor, '' as FechaTerminacion FROM Anexos " & _
                           "UNION " & _
                           "SELECT DISTINCT SUBSTRING(Anexo,1,5)+'/'+SUBSTRING(Anexo,6,4) AS Contrato, '' AS NombreCliente, '' As Tipta, 0 As Tasas, 0 As Diferencial, '' AS Tipar, '' AS DescPlaza, '' AS Copos, '' AS DescPromotor, '' as FechaTerminacion FROM Avios " & _
                           "ORDER BY SUBSTRING(Anexo,1,5)+'/'+SUBSTRING(Anexo,6,4)"
            .Connection = cnAgil
        End With

        ' El siguiente Command trae los datos de todos los contratos (Tradicionales, Avío y Cuenta Corriente)

        With cm2
            .CommandType = CommandType.Text
            .CommandText = "SELECT SUBSTRING(Anexo,1,5)+'/'+SUBSTRING(Anexo,6,4) AS Contrato, RTRIM(Descr) AS NombreCliente, Tipta, Tasas, Difer AS Diferencial, Tipar, DescPlaza, Copos, DescPromotor,FechaTerminacion FROM Anexos " & _
                           "INNER JOIN Clientes ON Anexos.Cliente = Clientes.Cliente " & _
                           "INNER JOIN Plazas ON Clientes.Plaza = Plazas.Plaza " & _
                           "INNER JOIN Promotores ON Clientes.Promo = Promotores.Promotor " & _
                           "INNER JOIN Vw_FechaTerminacion ON Anexos.Anexo = Vw_FechaTerminacion.AnexoX " & _
                           "UNION " & _
                           "SELECT SUBSTRING(Anexo,1,5)+'/'+SUBSTRING(Anexo,6,4) AS Contrato, RTRIM(Descr) AS NombreCliente, Tipta, Tasas, DiferencialFINAGIL AS Diferencial, Tipar, DescPlaza, Copos, DescPromotor, FechaTerminacion FROM Avios " & _
                           "INNER JOIN Clientes ON Avios.Cliente = Clientes.Cliente " & _
                           "INNER JOIN Plazas ON Clientes.Plaza = Plazas.Plaza " & _
                           "INNER JOIN Promotores ON Clientes.Promo = Promotores.Promotor " & _
                           "ORDER BY SUBSTRING(Anexo,1,5)+'/'+SUBSTRING(Anexo,6,4)"
            .Connection = cnAgil
        End With

        ' Llenar el dataset lo cual abre y cierra la conexión

        daReporte.Fill(dsAgil, "General")       ' Solamente tiene el número de contrato
        daCartera.Fill(dsAgil, "Cartera")

        ' Tengo que definir una llave primaria para la tabla General a fin de buscar un registro cuando desee consultarlo

        myColArray(0) = dsAgil.Tables("General").Columns("Contrato")
        dsAgil.Tables("General").PrimaryKey = myColArray

        For Each drCartera In dsAgil.Tables("Cartera").Rows

            cTipoTasa = drCartera("Tipta")
            nTasa = drCartera("Tasas")
            nDiferencial = drCartera("Diferencial")
            cProducto = drCartera("Tipar")

            If cTipoTasa = "7" Then
                drCartera("Tipta") = "FIJA"
                drCartera("Tasas") = nTasa + nDiferencial
                drCartera("Diferencial") = 0
            Else
                drCartera("Tipta") = "VARIABLE"
                drCartera("Tasas") = 0
                drCartera("Diferencial") = nDiferencial
            End If

            Select Case cProducto
                Case "F"
                    drCartera("Tipar") = "ARRENDAMIENTO FINANCIERO"
                Case "P"
                    drCartera("Tipar") = "ARRENDAMIENTO PURO"
                Case "R"
                    drCartera("Tipar") = "CREDITO REFACCIONARIO"
                Case "S"
                    drCartera("Tipar") = "CREDITO SIMPLE"
                Case "H", "A"
                    drCartera("Tipar") = "CREDITO DE AVIO"
                Case "C"
                    drCartera("Tipar") = "CUENTA CORRIENTE"
            End Select

            cAnexo = drCartera("Contrato")
            myKeySearch(0) = cAnexo

            drGeneral = dsAgil.Tables("General").Rows.Find(myKeySearch)

            drGeneral("Tipta") = drCartera("Tipta")
            drGeneral("Tasas") = drCartera("Tasas")
            drGeneral("Diferencial") = drCartera("Diferencial")
            drGeneral("Tipar") = drCartera("Tipar")
            drGeneral("NombreCliente") = drCartera("NombreCliente")
            drGeneral("Tipta") = drCartera("Tipta")
            drGeneral("Diferencial") = drCartera("Diferencial")
            drGeneral("Tasas") = drCartera("Tasas")
            drGeneral("Tipar") = drCartera("Tipar")
            drGeneral("DescPlaza") = drCartera("DescPlaza")
            drGeneral("Copos") = drCartera("Copos")
            drGeneral("DescPromotor") = drCartera("DescPromotor")
            drGeneral("FechaTerminacion") = drCartera("FechaTerminacion")

        Next

        ' Después leo el archivo ANEXOS.TXT el cual contiene los saldos contables

        Try



            oArchivo = New StreamReader("C:\FILES\ANEXOS.TXT")

            While (oArchivo.Peek() > -1)

                cRenglon = oArchivo.ReadLine()

                cTabla = ""
                If IsNumeric(Trim(Mid(cRenglon, 190, 24))) Then tot = CDbl(Mid(cRenglon, 190, 24)) Else tot = 0
                If (Mid(cRenglon, 21, 4) <> "0000" And tot > 0) Or (Mid(cRenglon, 5, 10) = "1351-17-01" And Mid(cRenglon, 16, 9) <> "0000-0000") Then

                    cAnexo = "0" & Mid(cRenglon, 16, 4) & "/" & Mid(cRenglon, 21, 4)
                    myKeySearch(0) = cAnexo

                    nCapitalExigibleVencido = 0
                    nSaldoInsolutoVencido = 0
                    nInteresVencido = 0
                    nOtrosVencido = 0
                    nSeguroVencido = 0

                    nCarteraVigente = 0
                    nProvision = 0
                    nUxR = 0

                    nSeguroFinanciado = 0

                    nCarteraExigible = 0

                    Select Case Mid(cRenglon, 5, 10)
                        Case "1351-01-01"               ' Capital Exigible Vencido de Bienes al Comercio
                            cTabla = "Vencida"
                            nCapitalExigibleVencido = CDbl(Mid(cRenglon, 190, 24))
                        Case "1351-01-02"               ' Saldo Insoluto Vencido de Bienes al Comercio
                            cTabla = "Vencida"
                            nSaldoInsolutoVencido = CDbl(Mid(cRenglon, 190, 24))
                        Case "1352-01-01"               ' Capital Exigible Vencido de Bienes al Consumo
                            cTabla = "Vencida"
                            nCapitalExigibleVencido = CDbl(Mid(cRenglon, 190, 24))
                        Case "1352-01-02"               ' Saldo Insoluto Vencido de Bienes al Consumo
                            cTabla = "Vencida"
                            nSaldoInsolutoVencido = CDbl(Mid(cRenglon, 190, 24))
                        Case "1381-01-01"               ' Intereses Vencidos de Bienes al Comercio
                            cTabla = "Vencida"
                            nInteresVencido = CDbl(Mid(cRenglon, 190, 24))
                        Case "1381-01-02"               ' Intereses Vencidos de Bienes al Consumo
                            cTabla = "Vencida"
                            nInteresVencido = CDbl(Mid(cRenglon, 190, 24))
                        Case "1386-01-01"               ' Otros Adeudos Vencidos de Bienes al Comercio
                            cTabla = "Vencida"
                            nOtrosVencido = CDbl(Mid(cRenglon, 190, 24))
                        Case "1386-01-02"               ' Otros Adeudos Vencidos de Bienes al Consumo
                            cTabla = "Vencida"
                            nOtrosVencido = CDbl(Mid(cRenglon, 190, 24))
                        Case "1386-03-01"               ' Seguros Vencidos
                            cTabla = "Vencida"
                            nSeguroVencido = CDbl(Mid(cRenglon, 190, 24))
                        Case "1351-17-01"               ' Factoraje
                            cTabla = "Vencida"
                            nCapitalExigibleVencido = CDbl(Mid(cRenglon, 190, 24))


                        Case "1301-02-01"               ' Cartera Vigente de Bienes al Comercio
                            cTabla = "AF"
                            nCarteraVigente = CDbl(Mid(cRenglon, 190, 24))
                        Case "2620-01-01"               ' Utilidades por realizar Bienes al Comercio
                            cTabla = "AF"
                            nUxR = CDbl(Mid(cRenglon, 190, 24))
                        Case "1302-02-01"               ' Cartera Vigente de Bienes al Consumo
                            cTabla = "AF"
                            nCarteraVigente = CDbl(Mid(cRenglon, 190, 24))
                        Case "2620-06-01"               ' Utilidades por realizar Bienes al Consumo
                            cTabla = "AF"
                            nUxR = CDbl(Mid(cRenglon, 190, 24))

                        Case "1401-02-01"               ' Cartera Vigente Crédito Refaccionario
                            cTabla = "CR"
                            nCarteraVigente = CDbl(Mid(cRenglon, 190, 24))
                        Case "2614-01-01"               ' Utilidades por realizar Créditos Refaccionarios
                            cTabla = "CR"
                            nUxR = CDbl(Mid(cRenglon, 190, 24))
                        Case "1401-08-01"               ' Cartera Vigente Crédito Refaccionario Agrícola
                            cTabla = "CR"
                            nCarteraVigente = CDbl(Mid(cRenglon, 190, 24))
                        Case "1401-08-03"               ' Intereses devengados no exigibles Crédito Refaccionario Agrícola
                            cTabla = "CR"
                            nProvision = CDbl(Mid(cRenglon, 190, 24))

                        Case "1403-02-01"               ' Cartera Vigente Crédito Simple
                            cTabla = "CS"
                            nCarteraVigente = CDbl(Mid(cRenglon, 190, 24))
                        Case "1403-02-04"               ' Interes Vigente Crédito Avío (Garantía Líquida)
                            cTabla = "CS"
                            nProvision = CDbl(Mid(cRenglon, 190, 24))
                        Case "2614-03-01"               ' Utilidades por realizar Crédito Simple
                            cTabla = "CS"
                            nUxR = CDbl(Mid(cRenglon, 190, 24))

                        Case "1402-02-01"               ' Cartera Vigente Credito Avío
                            cTabla = "CHA"
                            nCarteraVigente = CDbl(Mid(cRenglon, 190, 24))
                        Case "1402-02-03"               ' Provisión de Intereses Crédito Avío
                            cTabla = "CHA"
                            nProvision = CDbl(Mid(cRenglon, 190, 24))

                        Case "1404-02-01"               ' Cartera Vigente Cuenta Corriente
                            cTabla = "CC"
                            nCarteraVigente = CDbl(Mid(cRenglon, 190, 24))
                        Case "1404-02-03"               ' Provisión de Intereses Cuenta Corriente
                            cTabla = "CC"
                            nProvision = CDbl(Mid(cRenglon, 190, 24))

                        Case "1501-03-01"               ' Seguros Financiados
                            cTabla = "Seguros"
                            nSeguroFinanciado = CDbl(Mid(cRenglon, 190, 24))

                        Case "1301-02-02"               ' Cartera Exigible de Bienes al Comercio
                            cTabla = "Exigible"
                            nCarteraExigible = CDbl(Mid(cRenglon, 190, 24))
                        Case "1302-02-02"               ' Cartera Exigible de Bienes al Consumo
                            cTabla = "Exigible"
                            nCarteraExigible = CDbl(Mid(cRenglon, 190, 24))
                        Case "1401-02-02"               ' Cartera Exigible Crédito Refaccionario
                            cTabla = "Exigible"
                            nCarteraExigible = CDbl(Mid(cRenglon, 190, 24))
                        Case "1402-02-02"               ' Cartera Exigible Crédito de Avío
                            cTabla = "Exigible"
                            nCarteraExigible = CDbl(Mid(cRenglon, 190, 24))
                        Case "1403-02-02"               ' Cartera Exigible Crédito Simple
                            cTabla = "Exigible"
                            nCarteraExigible = CDbl(Mid(cRenglon, 190, 24))
                        Case "1404-02-02"               ' Cartera Exigible Ceunta Corriente
                            cTabla = "Exigible"
                            nCarteraExigible = CDbl(Mid(cRenglon, 190, 24))
                        Case "1317-02-03"               ' Cartera Exigible Ceunta Corriente
                            cTabla = "Exigible"
                            nCarteraExigible = CDbl(Mid(cRenglon, 190, 24))

                    End Select

                    drGeneral = dsAgil.Tables("General").Rows.Find(myKeySearch)
                    If drGeneral Is Nothing Then
                        cNombreCliente = ""
                        cTipoTasa = ""
                        nDiferencial = 0
                        nTasa = 0
                        cProducto = ""
                        cDescPlaza = ""
                        cCopos = ""
                        cDescPromotor = ""
                        cFechaTerminacion = ""
                    Else
                        cNombreCliente = drGeneral("NombreCliente")
                        cTipoTasa = drGeneral("Tipta")
                        nDiferencial = drGeneral("Diferencial")
                        nTasa = drGeneral("Tasas")
                        cProducto = drGeneral("Tipar")
                        cDescPlaza = drGeneral("DescPlaza")
                        cCopos = drGeneral("Copos")
                        cDescPromotor = drGeneral("DescPromotor")
                        cFechaTerminacion = drGeneral("FechaTerminacion")
                    End If

                    Select Case cTabla
                        Case "Vencida"
                            drReporte = dtVencida.Rows.Find(myKeySearch)
                            If drReporte Is Nothing Then
                                drReporte = dtVencida.NewRow()
                                drReporte("Anexo") = cAnexo
                                drReporte("Nombre") = cNombreCliente
                                drReporte("CapitalExigible") = nCapitalExigibleVencido
                                drReporte("SaldoInsoluto") = nSaldoInsolutoVencido
                                drReporte("Intereses") = nInteresVencido
                                drReporte("OtrosAdeudos") = nOtrosVencido
                                drReporte("Seguros") = nSeguroVencido
                                drReporte("Total") = nCapitalExigibleVencido + nSaldoInsolutoVencido + nInteresVencido + nOtrosVencido + nSeguroVencido
                                drReporte("TipoTasa") = cTipoTasa
                                drReporte("Tasa") = nTasa
                                drReporte("Diferencial") = nDiferencial
                                drReporte("Producto") = cProducto
                                drReporte("Plaza") = cDescPlaza
                                drReporte("Código Postal") = cCopos
                                drReporte("Promotor") = cDescPromotor
                                drReporte("FechaTerminacion") = cFechaTerminacion
                                dtVencida.Rows.Add(drReporte)
                            Else
                                drReporte("CapitalExigible") += nCapitalExigibleVencido
                                drReporte("SaldoInsoluto") += nSaldoInsolutoVencido
                                drReporte("Intereses") += nInteresVencido
                                drReporte("OtrosAdeudos") += nOtrosVencido
                                drReporte("Seguros") += nSeguroVencido
                                drReporte("Total") += nCapitalExigibleVencido + nSaldoInsolutoVencido + nInteresVencido + nOtrosVencido + nSeguroVencido

                            End If
                        Case "AF"
                            drReporte = dtAF.Rows.Find(myKeySearch)
                            If drReporte Is Nothing Then
                                drReporte = dtAF.NewRow()
                                drReporte("Anexo") = cAnexo
                                drReporte("Nombre") = cNombreCliente
                                drReporte("CarteraVigente") = nCarteraVigente
                                drReporte("Provision") = nProvision
                                drReporte("UxR") = nUxR
                                drReporte("Total") = nCarteraVigente + nProvision - nUxR
                                drReporte("TipoTasa") = cTipoTasa
                                drReporte("Tasa") = nTasa
                                drReporte("Diferencial") = nDiferencial
                                drReporte("Producto") = cProducto
                                drReporte("Plaza") = cDescPlaza
                                drReporte("Código Postal") = cCopos
                                drReporte("Promotor") = cDescPromotor
                                drReporte("FechaTerminacion") = cFechaTerminacion
                                dtAF.Rows.Add(drReporte)
                            Else
                                drReporte("CarteraVigente") += nCarteraVigente
                                drReporte("Provision") += nProvision
                                drReporte("UxR") += nUxR
                                drReporte("Total") += nCarteraVigente + nProvision - nUxR
                            End If
                        Case "CR"
                            drReporte = dtCR.Rows.Find(myKeySearch)
                            If drReporte Is Nothing Then
                                drReporte = dtCR.NewRow()
                                drReporte("Anexo") = cAnexo
                                drReporte("Nombre") = cNombreCliente
                                drReporte("CarteraVigente") = nCarteraVigente
                                drReporte("Provision") = nProvision
                                drReporte("UxR") = nUxR
                                drReporte("Total") = nCarteraVigente + nProvision - nUxR
                                drReporte("TipoTasa") = cTipoTasa
                                drReporte("Tasa") = nTasa
                                drReporte("Diferencial") = nDiferencial
                                drReporte("Producto") = cProducto
                                drReporte("Plaza") = cDescPlaza
                                drReporte("Código Postal") = cCopos
                                drReporte("Promotor") = cDescPromotor
                                drReporte("FechaTerminacion") = cFechaTerminacion
                                dtCR.Rows.Add(drReporte)
                            Else
                                drReporte("CarteraVigente") += nCarteraVigente
                                drReporte("Provision") += nProvision
                                drReporte("UxR") += nUxR
                                drReporte("Total") += nCarteraVigente + nProvision - nUxR
                            End If
                        Case "CS"
                            drReporte = dtCS.Rows.Find(myKeySearch)
                            If drReporte Is Nothing Then
                                drReporte = dtCS.NewRow()
                                drReporte("Anexo") = cAnexo
                                drReporte("Nombre") = cNombreCliente
                                drReporte("CarteraVigente") = nCarteraVigente
                                drReporte("Provision") = nProvision
                                drReporte("UxR") = nUxR
                                drReporte("Total") = nCarteraVigente + nProvision - nUxR
                                drReporte("TipoTasa") = cTipoTasa
                                drReporte("Tasa") = nTasa
                                drReporte("Diferencial") = nDiferencial
                                drReporte("Producto") = cProducto
                                drReporte("Plaza") = cDescPlaza
                                drReporte("Código Postal") = cCopos
                                drReporte("Promotor") = cDescPromotor
                                drReporte("FechaTerminacion") = cFechaTerminacion
                                dtCS.Rows.Add(drReporte)
                            Else
                                drReporte("CarteraVigente") += nCarteraVigente
                                drReporte("Provision") += nProvision
                                drReporte("UxR") += nUxR
                                drReporte("Total") += nCarteraVigente + nProvision - nUxR
                            End If
                        Case "CHA"
                            drReporte = dtCHA.Rows.Find(myKeySearch)
                            If drReporte Is Nothing Then
                                drReporte = dtCHA.NewRow()
                                drReporte("Anexo") = cAnexo
                                drReporte("Nombre") = cNombreCliente
                                drReporte("CarteraVigente") = nCarteraVigente
                                drReporte("Provision") = nProvision
                                drReporte("Total") = nCarteraVigente + nProvision
                                drReporte("TipoTasa") = cTipoTasa
                                drReporte("Tasa") = nTasa
                                drReporte("Diferencial") = nDiferencial
                                drReporte("Producto") = cProducto
                                drReporte("Plaza") = cDescPlaza
                                drReporte("Código Postal") = cCopos
                                drReporte("Promotor") = cDescPromotor
                                drReporte("FechaTerminacion") = cFechaTerminacion
                                dtCHA.Rows.Add(drReporte)
                            Else
                                drReporte("CarteraVigente") += nCarteraVigente
                                drReporte("Provision") += nProvision
                                drReporte("Total") += nCarteraVigente + nProvision
                            End If
                        Case "CC"
                            drReporte = dtCC.Rows.Find(myKeySearch)
                            If drReporte Is Nothing Then
                                drReporte = dtCC.NewRow()
                                drReporte("Anexo") = cAnexo
                                drReporte("Nombre") = cNombreCliente
                                drReporte("CarteraVigente") = nCarteraVigente
                                drReporte("Provision") = nProvision
                                drReporte("Total") = nCarteraVigente + nProvision
                                drReporte("TipoTasa") = cTipoTasa
                                drReporte("Tasa") = nTasa
                                drReporte("Diferencial") = nDiferencial
                                drReporte("Producto") = cProducto
                                drReporte("Plaza") = cDescPlaza
                                drReporte("Código Postal") = cCopos
                                drReporte("Promotor") = cDescPromotor
                                drReporte("FechaTerminacion") = cFechaTerminacion
                                dtCC.Rows.Add(drReporte)
                            Else
                                drReporte("CarteraVigente") += nCarteraVigente
                                drReporte("Provision") += nProvision
                                drReporte("Total") += nCarteraVigente + nProvision
                            End If
                        Case "Seguros"
                            drReporte = dtSeguros.Rows.Find(myKeySearch)
                            If drReporte Is Nothing Then
                                drReporte = dtSeguros.NewRow()
                                drReporte("Anexo") = cAnexo
                                drReporte("Nombre") = cNombreCliente
                                drReporte("SeguroFinanciado") = nSeguroFinanciado
                                drReporte("TipoTasa") = cTipoTasa
                                drReporte("Tasa") = nTasa
                                drReporte("Diferencial") = nDiferencial
                                drReporte("Producto") = cProducto
                                drReporte("Plaza") = cDescPlaza
                                drReporte("Código Postal") = cCopos
                                drReporte("Promotor") = cDescPromotor
                                drReporte("FechaTerminacion") = cFechaTerminacion
                                dtSeguros.Rows.Add(drReporte)
                            Else
                                drReporte("SeguroFinanciado") += nSeguroFinanciado
                            End If
                        Case "Exigible"
                            drReporte = dtExigible.Rows.Find(myKeySearch)
                            If drReporte Is Nothing Then
                                drReporte = dtExigible.NewRow()
                                drReporte("Anexo") = cAnexo
                                drReporte("Nombre") = cNombreCliente
                                drReporte("CarteraExigible") = nCarteraExigible
                                drReporte("TipoTasa") = cTipoTasa
                                drReporte("Tasa") = nTasa
                                drReporte("Diferencial") = nDiferencial
                                drReporte("Producto") = cProducto
                                drReporte("Plaza") = cDescPlaza
                                drReporte("Código Postal") = cCopos
                                drReporte("Promotor") = cDescPromotor
                                drReporte("FechaTerminacion") = cFechaTerminacion
                                dtExigible.Rows.Add(drReporte)
                            Else
                                drReporte("CarteraExigible") += nCarteraExigible
                            End If
                    End Select

                End If

            End While

            oArchivo.Close()
            oArchivo = Nothing

        Catch eException As Exception

            MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")

        End Try

        ' Después leo el archivo 13010203.TXT

        oArchivo = New StreamReader("C:\FILES\13010203.TXT")

        While (oArchivo.Peek() > -1)

            cRenglon = oArchivo.ReadLine()

            'If Mid(cRenglon, 45, 30) = "PROVISION DE INTERESES ACTIVOS" Then
            If Mid(cRenglon, 60, 30) = "PROVISION DE INTERESES ACTIVOS" Then

                'cAnexo = Mid(cRenglon, 83, 10)
                cAnexo = Mid(cRenglon, 113, 10)
                myKeySearch(0) = cAnexo

                drGeneral = dsAgil.Tables("General").Rows.Find(myKeySearch)
                If drGeneral Is Nothing Then
                    cNombreCliente = ""
                    cTipoTasa = ""
                    nDiferencial = 0
                    nTasa = 0
                    cProducto = ""
                    cDescPlaza = ""
                    cCopos = ""
                    cDescPromotor = ""
                    cFechaTerminacion = ""
                Else
                    cNombreCliente = drGeneral("NombreCliente")
                    cTipoTasa = drGeneral("Tipta")
                    nDiferencial = drGeneral("Diferencial")
                    nTasa = drGeneral("Tasas")
                    cProducto = drGeneral("Tipar")
                    cDescPlaza = drGeneral("DescPlaza")
                    cCopos = drGeneral("Copos")
                    cDescPromotor = drGeneral("DescPromotor")
                    cFechaTerminacion = drGeneral("FechaTerminacion")
                End If

                'nProvision = CDbl(Mid(cRenglon, 93, 24))
                nProvision = CDbl(Mid(cRenglon, 143, 24))

                drReporte = dtAF.Rows.Find(myKeySearch)
                If drReporte Is Nothing Then
                    drReporte = dtAF.NewRow()
                    drReporte("Anexo") = cAnexo
                    drReporte("Nombre") = cNombreCliente
                    drReporte("CarteraVigente") = 0
                    drReporte("Provision") = nProvision
                    drReporte("UxR") = 0
                    drReporte("Total") = nProvision
                    drReporte("TipoTasa") = cTipoTasa
                    drReporte("Tasa") = nTasa
                    drReporte("Diferencial") = nDiferencial
                    drReporte("Producto") = cProducto
                    drReporte("Plaza") = cDescPlaza
                    drReporte("Código Postal") = cCopos
                    drReporte("Promotor") = cDescPromotor
                    drReporte("FechaTerminacion") = cFechaTerminacion
                    dtAF.Rows.Add(drReporte)
                Else
                    drReporte("Provision") += nProvision
                    drReporte("Total") += nProvision
                End If

            End If

        End While

        oArchivo.Close()
        oArchivo = Nothing

        ' Después leo el archivo 13020203.TXT

        Try

            oArchivo = New StreamReader("C:\FILES\13020203.TXT")

            While (oArchivo.Peek() > -1)

                cRenglon = oArchivo.ReadLine()

                If Mid(cRenglon, 60, 30) = "PROVISION DE INTERESES ACTIVOS" Then

                    'cAnexo = Mid(cRenglon, 83, 10)
                    cAnexo = Mid(cRenglon, 113, 10)
                    myKeySearch(0) = cAnexo

                    drGeneral = dsAgil.Tables("General").Rows.Find(myKeySearch)
                    If drGeneral Is Nothing Then
                        cNombreCliente = ""
                        cTipoTasa = ""
                        nDiferencial = 0
                        nTasa = 0
                        cProducto = ""
                        cDescPlaza = ""
                        cCopos = ""
                        cDescPromotor = ""
                        cFechaTerminacion = ""
                        
                    Else
                        cNombreCliente = drGeneral("NombreCliente")
                        cTipoTasa = drGeneral("Tipta")
                        nDiferencial = drGeneral("Diferencial")
                        nTasa = drGeneral("Tasas")
                        cProducto = drGeneral("Tipar")
                        cDescPlaza = drGeneral("DescPlaza")
                        cCopos = drGeneral("Copos")
                        cDescPromotor = drGeneral("DescPromotor")
                        cFechaTerminacion = drGeneral("FechaTerminacion")
                    End If

                    nProvision = CDbl(Mid(cRenglon, 143, 24))

                    drReporte = dtAF.Rows.Find(myKeySearch)
                    If drReporte Is Nothing Then
                        drReporte = dtAF.NewRow()
                        drReporte("Anexo") = cAnexo
                        drReporte("Nombre") = cNombreCliente
                        drReporte("CarteraVigente") = 0
                        drReporte("Provision") = nProvision
                        drReporte("UxR") = 0
                        drReporte("Total") = nProvision
                        drReporte("TipoTasa") = cTipoTasa
                        drReporte("Tasa") = nTasa
                        drReporte("Diferencial") = nDiferencial
                        drReporte("Producto") = cProducto
                        drReporte("Plaza") = cDescPlaza
                        drReporte("Código Postal") = cCopos
                        drReporte("Promotor") = cDescPromotor
                        drReporte("FechaTerminacion") = cFechaTerminacion
                        dtAF.Rows.Add(drReporte)
                    Else
                        drReporte("Provision") += nProvision
                        drReporte("Total") += nProvision
                    End If

                End If

            End While

            oArchivo.Close()
            oArchivo = Nothing

        Catch eException As Exception

            MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")

        End Try

        ' Después leo el archivo 14010203.TXT

        Try

            oArchivo = New StreamReader("C:\FILES\14010203.TXT")

            While (oArchivo.Peek() > -1)

                cRenglon = oArchivo.ReadLine()

                If Mid(cRenglon, 60, 30) = "PROVISION DE INTERESES ACTIVOS" Then

                    'cAnexo = Mid(cRenglon, 83, 10)
                    cAnexo = Mid(cRenglon, 113, 10)
                    myKeySearch(0) = cAnexo

                    drGeneral = dsAgil.Tables("General").Rows.Find(myKeySearch)
                    If drGeneral Is Nothing Then
                        cNombreCliente = ""
                        cTipoTasa = ""
                        nDiferencial = 0
                        nTasa = 0
                        cProducto = ""
                        cDescPlaza = ""
                        cCopos = ""
                        cDescPromotor = ""
                        cFechaTerminacion = ""
                    Else
                        cNombreCliente = drGeneral("NombreCliente")
                        cTipoTasa = drGeneral("Tipta")
                        nDiferencial = drGeneral("Diferencial")
                        nTasa = drGeneral("Tasas")
                        cProducto = drGeneral("Tipar")
                        cDescPlaza = drGeneral("DescPlaza")
                        cCopos = drGeneral("Copos")
                        cDescPromotor = drGeneral("DescPromotor")
                        cFechaTerminacion = drGeneral("FechaTerminacion")
                    End If

                    nProvision = CDbl(Mid(cRenglon, 143, 24))

                    drReporte = dtCR.Rows.Find(myKeySearch)
                    If drReporte Is Nothing Then
                        drReporte = dtCR.NewRow()
                        drReporte("Anexo") = cAnexo
                        drReporte("Nombre") = cNombreCliente
                        drReporte("CarteraVigente") = 0
                        drReporte("Provision") = nProvision
                        drReporte("UxR") = 0
                        drReporte("Total") = nProvision
                        drReporte("TipoTasa") = cTipoTasa
                        drReporte("Tasa") = nTasa
                        drReporte("Diferencial") = nDiferencial
                        drReporte("Producto") = cProducto
                        drReporte("Plaza") = cDescPlaza
                        drReporte("Código Postal") = cCopos
                        drReporte("Promotor") = cDescPromotor
                        drReporte("FechaTerminacion") = cFechaTerminacion
                        dtCR.Rows.Add(drReporte)
                    Else
                        drReporte("Provision") += nProvision
                        drReporte("Total") += nProvision
                    End If

                End If

            End While

            oArchivo.Close()
            oArchivo = Nothing

        Catch eException As Exception

            MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")

        End Try

        ' Después leo el archivo 14030203.TXT

        Try

            oArchivo = New StreamReader("C:\FILES\14030203.TXT")

            While (oArchivo.Peek() > -1)

                cRenglon = oArchivo.ReadLine()

                If Mid(cRenglon, 60, 30) = "PROVISION DE INTERESES ACTIVOS" Then

                    'cAnexo = Mid(cRenglon, 83, 10)
                    cAnexo = Mid(cRenglon, 113, 10)
                    myKeySearch(0) = cAnexo

                    drGeneral = dsAgil.Tables("General").Rows.Find(myKeySearch)
                    If drGeneral Is Nothing Then
                        cNombreCliente = ""
                        cTipoTasa = ""
                        nDiferencial = 0
                        nTasa = 0
                        cProducto = ""
                        cDescPlaza = ""
                        cCopos = ""
                        cDescPromotor = ""
                        cFechaTerminacion = ""
                    Else
                        cNombreCliente = drGeneral("NombreCliente")
                        cTipoTasa = drGeneral("Tipta")
                        nDiferencial = drGeneral("Diferencial")
                        nTasa = drGeneral("Tasas")
                        cProducto = drGeneral("Tipar")
                        cDescPlaza = drGeneral("DescPlaza")
                        cCopos = drGeneral("Copos")
                        cDescPromotor = drGeneral("DescPromotor")
                        cFechaTerminacion = drGeneral("FechaTerminacion")
                    End If

                    nProvision = CDbl(Mid(cRenglon, 143, 24))

                    drReporte = dtCS.Rows.Find(myKeySearch)
                    If drReporte Is Nothing Then
                        drReporte = dtCS.NewRow()
                        drReporte("Anexo") = cAnexo
                        drReporte("Nombre") = cNombreCliente
                        drReporte("CarteraVigente") = 0
                        drReporte("Provision") = nProvision
                        drReporte("UxR") = 0
                        drReporte("Total") = nProvision
                        drReporte("TipoTasa") = cTipoTasa
                        drReporte("Tasa") = nTasa
                        drReporte("Diferencial") = nDiferencial
                        drReporte("Producto") = cProducto
                        drReporte("Plaza") = cDescPlaza
                        drReporte("Código Postal") = cCopos
                        drReporte("Promotor") = cDescPromotor
                        drReporte("FechaTerminacion") = cFechaTerminacion
                        
                    Else
                        drReporte("Provision") += nProvision
                        drReporte("Total") += nProvision
                    End If

                End If

            End While

            oArchivo.Close()
            oArchivo = Nothing

        Catch eException As Exception

            MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")

        End Try

        'Try
        dtVencida.Select("total > 0")

        CargaDatos(dtVencida, "VENCIDA")
        CargaDatos(dtAF, "ARRENDAMIENTO FINANCIERO")
        CargaDatos(dtCR, "CRÉDITO REFACCIONARIO")
        CargaDatos(dtCS, "CRÉDITO SIMPLE")
        CargaDatos(dtCHA, "CRÉDITO DE AVÍO")
        CargaDatos(dtCC, "CUENTA CORRIENTE")
        CargaDatos(dtSeguros, "SEGUROS")
        CargaDatos(dtExigible, "EXIGIBLE")
        CargaDatos(dtExigible, "FACTORAJE FINANCIERO")
        CargaDatos(dtExigible, "CESIÓN DE DERECHOS")


        dgvVencida.DataSource = dtVencida
        dgvAF.DataSource = dtAF
        dgvCR.DataSource = dtCR
        dgvCS.DataSource = dtCS
        dgvCHA.DataSource = dtCHA
        dgvCC.DataSource = dtCC
        dgvSeguros.DataSource = dtSeguros
        dgvExigible.DataSource = dtExigible
        'Catch eException As Exception
        'MsgBox(eException.Source, MsgBoxStyle.Critical, eException.Message)
        'End Try

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Sub CargaDatos(ByRef T As DataTable, ByVal TipoCartera As String)
        Dim cnAgil As New SqlConnection(strConnPRO)
        Dim cm1 As New SqlCommand()
        cm1.CommandType = CommandType.Text
        cm1.Connection = cnAgil
        cnAgil.Open()
        Dim fecha As Date

        cm1.CommandText = "DELETE FROM CONT_mezcla where Mes ='" & dtpProcesar.Value.ToString("MMM yyyy").ToUpper & "' and TipoCartera = '" & TipoCartera.ToUpper & "'"
        cm1.ExecuteNonQuery()
        Select Case TipoCartera.ToUpper
            Case "VENCIDA"
                For Each r As DataRow In T.Rows()
                    If Trim(r("FechaTerminacion")) = "" Then
                        fecha = dtpProcesar.Value
                    Else
                        fecha = CDate(Mid(r("FechaTerminacion"), 7, 2) & "/" & Mid(r("FechaTerminacion"), 5, 2) & "/" & Mid(r("FechaTerminacion"), 1, 4))
                    End If
                    If Mid(r("Anexo"), 6, 5) = "/0000" Then
                        r("Nombre") = "FACTORAJE FINANCIERO"
                    End If

                    cm1.CommandText = "INSERT INTO CONT_Mezcla ([Anexo],[Nombre],[CapitalCartera],[Provision],[UxR],[SaldoInsoluto],[Interes],[OtrosAdeudos]," _
                    & "[Seguros],[Total],[TipoTasa],[Tasa],[Diferencial],[Producto],[Plaza],[CP],[Promotor],[FechaTerminacion],[TipoCartera]," _
                    & "[Mes])" _
                    & "VALUES ('" & r("Anexo") & "','" & r("Nombre") & "'," & r("CapitalExigible") & ",0" _
                    & ",0," & r("SaldoInsoluto") & "," & r("Intereses") & "," & r("OtrosAdeudos") & "" _
                    & "," & r("Seguros") & "," & r("Total") & ",'" & r("TipoTasa") & "'," & r("Tasa") & "" _
                    & "," & r("Diferencial") & ",'" & r("Producto") & "','" & Trim(r("Plaza")) & "','" & r("Código Postal") & "'" _
                    & ",'" & Trim(r("Promotor")) & "','" & fecha.ToString("MM/dd/yyyy") & "','" & TipoCartera.ToUpper & "','" & dtpProcesar.Value.ToString("MMM yyyy").ToUpper & "')"
                    cm1.ExecuteNonQuery()
                Next
            Case "ARRENDAMIENTO FINANCIERO", "CRÉDITO REFACCIONARIO", "CRÉDITO SIMPLE"
                For Each r As DataRow In T.Rows()
                    If Trim(r("FechaTerminacion")) = "" Then
                        fecha = dtpProcesar.Value
                    Else
                        fecha = CDate(Mid(r("FechaTerminacion"), 7, 2) & "/" & Mid(r("FechaTerminacion"), 5, 2) & "/" & Mid(r("FechaTerminacion"), 1, 4))
                    End If

                    cm1.CommandText = "INSERT INTO CONT_Mezcla ([Anexo],[Nombre],[CapitalCartera],[Provision],[UxR],[SaldoInsoluto],[Interes],[OtrosAdeudos]," _
                    & "[Seguros],[Total],[TipoTasa],[Tasa],[Diferencial],[Producto],[Plaza],[CP],[Promotor],[FechaTerminacion],[TipoCartera]," _
                    & "[Mes])" _
                    & "VALUES ('" & r("Anexo") & "','" & r("Nombre") & "'," & r("CarteraVigente") & "," & r("Provision") & "" _
                    & "," & r("UxR") & ",0,0,0" _
                    & ",0," & r("Total") & ",'" & r("TipoTasa") & "'," & r("Tasa") & "" _
                    & "," & r("Diferencial") & ",'" & r("Producto") & "','" & Trim(r("Plaza")) & "','" & r("Código Postal") & "'" _
                    & ",'" & Trim(r("Promotor")) & "','" & fecha.ToString("MM/dd/yyyy") & "','" & TipoCartera.ToUpper & "','" & dtpProcesar.Value.ToString("MMM yyyy").ToUpper & "')"
                    cm1.ExecuteNonQuery()
                Next
            Case "CRÉDITO DE AVÍO", "CUENTA CORRIENTE"
                For Each r As DataRow In T.Rows()
                    If Trim(r("FechaTerminacion")) = "" Then
                        fecha = dtpProcesar.Value
                    Else
                        fecha = CDate(Mid(r("FechaTerminacion"), 7, 2) & "/" & Mid(r("FechaTerminacion"), 5, 2) & "/" & Mid(r("FechaTerminacion"), 1, 4))
                    End If

                    cm1.CommandText = "INSERT INTO CONT_Mezcla ([Anexo],[Nombre],[CapitalCartera],[Provision],[UxR],[SaldoInsoluto],[Interes],[OtrosAdeudos]," _
                    & "[Seguros],[Total],[TipoTasa],[Tasa],[Diferencial],[Producto],[Plaza],[CP],[Promotor],[FechaTerminacion],[TipoCartera]," _
                    & "[Mes])" _
                    & "VALUES ('" & r("Anexo") & "','" & r("Nombre") & "'," & r("CarteraVigente") & "," & r("Provision") & "" _
                    & ",0,0,0,0" _
                    & ",0," & r("Total") & ",'" & r("TipoTasa") & "'," & r("Tasa") & "" _
                    & "," & r("Diferencial") & ",'" & r("Producto") & "','" & Trim(r("Plaza")) & "','" & r("Código Postal") & "'" _
                    & ",'" & Trim(r("Promotor")) & "','" & fecha.ToString("MM/dd/yyyy") & "','" & TipoCartera.ToUpper & "','" & dtpProcesar.Value.ToString("MMM yyyy").ToUpper & "')"
                    cm1.ExecuteNonQuery()
                Next
            Case "SEGUROS"
                For Each r As DataRow In T.Rows()
                    If Trim(r("FechaTerminacion")) = "" Then
                        fecha = dtpProcesar.Value
                    Else
                        fecha = CDate(Mid(r("FechaTerminacion"), 7, 2) & "/" & Mid(r("FechaTerminacion"), 5, 2) & "/" & Mid(r("FechaTerminacion"), 1, 4))
                    End If

                    cm1.CommandText = "INSERT INTO CONT_Mezcla ([Anexo],[Nombre],[CapitalCartera],[Provision],[UxR],[SaldoInsoluto],[Interes],[OtrosAdeudos]," _
                    & "[Seguros],[Total],[TipoTasa],[Tasa],[Diferencial],[Producto],[Plaza],[CP],[Promotor],[FechaTerminacion],[TipoCartera]," _
                    & "[Mes])" _
                    & "VALUES ('" & r("Anexo") & "','" & r("Nombre") & "'," & r("SeguroFinanciado") & ",0" _
                    & ",0,0,0,0" _
                    & ",0," & r("SeguroFinanciado") & ",'" & r("TipoTasa") & "'," & r("Tasa") & "" _
                    & "," & r("Diferencial") & ",'" & r("Producto") & "','" & Trim(r("Plaza")) & "','" & r("Código Postal") & "'" _
                    & ",'" & Trim(r("Promotor")) & "','" & fecha.ToString("MM/dd/yyyy") & "','" & TipoCartera.ToUpper & "','" & dtpProcesar.Value.ToString("MMM yyyy").ToUpper & "')"
                    cm1.ExecuteNonQuery()
                Next
            Case "EXIGIBLE"
                For Each r As DataRow In T.Rows()
                    If Trim(r("FechaTerminacion")) = "" Then
                        fecha = dtpProcesar.Value
                    Else
                        fecha = CDate(Mid(r("FechaTerminacion"), 7, 2) & "/" & Mid(r("FechaTerminacion"), 5, 2) & "/" & Mid(r("FechaTerminacion"), 1, 4))
                    End If

                    cm1.CommandText = "INSERT INTO CONT_Mezcla ([Anexo],[Nombre],[CapitalCartera],[Provision],[UxR],[SaldoInsoluto],[Interes],[OtrosAdeudos]," _
                    & "[Seguros],[Total],[TipoTasa],[Tasa],[Diferencial],[Producto],[Plaza],[CP],[Promotor],[FechaTerminacion],[TipoCartera]," _
                    & "[Mes])" _
                    & "VALUES ('" & r("Anexo") & "','" & r("Nombre") & "'," & r("CarteraExigible") & ",0" _
                    & ",0,0,0,0" _
                    & ",0," & r("CarteraExigible") & ",'" & r("TipoTasa") & "'," & r("Tasa") & "" _
                    & "," & r("Diferencial") & ",'" & r("Producto") & "','" & Trim(r("Plaza")) & "','" & r("Código Postal") & "'" _
                    & ",'" & Trim(r("Promotor")) & "','" & fecha.ToString("MM/dd/yyyy") & "','" & TipoCartera.ToUpper & "','" & dtpProcesar.Value.ToString("MMM yyyy").ToUpper & "')"
                    cm1.ExecuteNonQuery()
                Next
            Case "FACTORAJE FINANCIERO"
                Dim R As String = InputBox("FACTORAJE")
                fecha = dtpProcesar.Value
                cm1.CommandText = "INSERT INTO CONT_Mezcla ([Anexo],[Nombre],[CapitalCartera],[Provision],[UxR],[SaldoInsoluto],[Interes],[OtrosAdeudos]," _
                & "[Seguros],[Total],[TipoTasa],[Tasa],[Diferencial],[Producto],[Plaza],[CP],[Promotor],[FechaTerminacion],[TipoCartera]," _
                & "[Mes])" _
                & "VALUES ('88888/8888','" & TipoCartera.ToUpper & "'," & R & ",0" _
                & ",0,0,0,0" _
                & ",0," & R & ",'FIJA',0" _
                & ",0,'" & TipoCartera.ToUpper & "','ESTADO DE MEXICO','50070'" _
                & ",'" & TipoCartera.ToUpper & "','" & fecha.ToString("MM/dd/yyyy") & "','" & TipoCartera.ToUpper & "','" & dtpProcesar.Value.ToString("MMM yyyy").ToUpper & "')"
                cm1.ExecuteNonQuery()
            Case "CESIÓN DE DERECHOS"
                Dim R As String = InputBox("CESIONES")
                fecha = dtpProcesar.Value
                cm1.CommandText = "INSERT INTO CONT_Mezcla ([Anexo],[Nombre],[CapitalCartera],[Provision],[UxR],[SaldoInsoluto],[Interes],[OtrosAdeudos]," _
                & "[Seguros],[Total],[TipoTasa],[Tasa],[Diferencial],[Producto],[Plaza],[CP],[Promotor],[FechaTerminacion],[TipoCartera]," _
                & "[Mes])" _
                & "VALUES ('99999/9999','" & TipoCartera.ToUpper & "'," & R & ",0" _
                & ",0,0,0,0" _
                & ",0," & R & ",'FIJA',0" _
                & ",0,'" & TipoCartera.ToUpper & "','ESTADO DE MEXICO','50070'" _
                & ",'" & TipoCartera.ToUpper & "','" & fecha.ToString("MM/dd/yyyy") & "','" & TipoCartera.ToUpper & "','" & dtpProcesar.Value.ToString("MMM yyyy").ToUpper & "')"
                cm1.ExecuteNonQuery()
        End Select
        cm1.CommandType = CommandType.StoredProcedure
        cm1.CommandText = "CorrijeMezcla"
        cm1.ExecuteScalar()
        cnAgil.Close()
    End Sub

End Class