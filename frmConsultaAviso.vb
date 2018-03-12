Option Explicit On

Imports System.Data.SqlClient
Imports System.Math

Public Class frmConsultaAviso

    Private Sub btnVerAviso_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVerAviso.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim daAvisos As New SqlDataAdapter(cm1)
        Dim daFacturas As New SqlDataAdapter(cm2)
        Dim daUdis As New SqlDataAdapter(cm3)
        Dim dsAgil As New DataSet()
        Dim drAnexo As DataRow
        Dim drAviso As DataRow
        Dim drAdeudo As DataRow
        Dim drAdeudos As DataRowCollection
        Dim drUdis As DataRowCollection
        Dim drFacturas As DataRowCollection
        Dim dtAvisos As New DataTable("Avisos")
        Dim dtAdeudos As New DataTable("Adeudos")
        Dim myColArray(1) As DataColumn

        ' Declaración de variables de datos

        Dim cAnexo As String = ""
        Dim cCliente As String = ""
        Dim cFeven As String = ""
        Dim cLetras As String = ""
        Dim cTipar As String = ""
        Dim nAdeudo As Decimal = 0
        Dim nBaseBonificacion As Decimal = 0
        Dim nBonifica As Decimal = 0
        Dim nCapeq As Decimal = 0
        Dim nCapot As Decimal = 0
        Dim nCounter As Integer = 0
        Dim nFactura As Decimal = 0
        Dim nGranTotal As Decimal = 0
        Dim nImpFac As Decimal = 0
        Dim nImporteFega As Decimal = 0
        Dim nIntEq As Decimal = 0
        Dim nIntOt As Decimal = 0
        Dim nIntSe As Decimal = 0
        Dim nIvaBonificacion As Decimal = 0
        Dim nIvacapital As Decimal = 0
        Dim nIvaEq As Decimal = 0
        Dim nIvaopc As Decimal = 0
        Dim nIvaOt As Decimal = 0
        Dim nIvaSe As Decimal = 0
        Dim nOpcion As Decimal = 0
        Dim nPlazo As Integer = 0
        Dim nRense As Decimal = 0
        Dim nSaldo As Decimal = 0
        Dim nSaldot As Decimal = 0
        Dim nSalse As Decimal = 0
        Dim nSegVida As Decimal = 0
        Dim nTasa As Decimal = 0
        Dim nTasaBonificacion As Decimal = 0
        Dim nTotaleq As Decimal = 0
        Dim nTotalot As Decimal = 0
        Dim nTotalse As Decimal = 0
        Dim nUdi1 As Decimal = 0
        Dim nUdi2 As Decimal = 0

        ' Declaración de variables de Crystal Reports

        Dim newrptImpreFac As New rptImpreFac()

        nFactura = Val(txtAviso.Text)

        ' Con este Stored Procedure obtengo los datos del Aviso solicitado

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Aviso2"
            .Connection = cnAgil
            .Parameters.Add("@Aviso", SqlDbType.NVarChar)
            .Parameters(0).Value = nFactura
        End With

        ' Llenar el dataset lo cual abre y cierra la conexión

        daAvisos.Fill(dsAgil, "Avisos")

        ' Creo la tabla que almacenara los adeudos encontrados

        dtAdeudos.Columns.Add("Anexo", Type.GetType("System.String"))
        dtAdeudos.Columns.Add("Adeudoant", Type.GetType("System.Decimal"))
        myColArray(0) = dtAdeudos.Columns("Anexo")
        dtAdeudos.PrimaryKey = myColArray

        If dsAgil.Tables("Avisos").Rows.Count = 0 Then

            MsgBox("Aviso inexistente", MsgBoxStyle.Exclamation, "Mensaje del Sistema")

        Else

            ' Creo una tabla Temporal donde almaceno los datos que formarán parte del reporte final

            dtAvisos.Columns.Add("RFC", Type.GetType("System.String"))
            dtAvisos.Columns.Add("Calle", Type.GetType("System.String"))
            dtAvisos.Columns.Add("Colonia", Type.GetType("System.String"))
            dtAvisos.Columns.Add("Copos", Type.GetType("System.String"))
            dtAvisos.Columns.Add("Deleg", Type.GetType("System.String"))
            dtAvisos.Columns.Add("Descp", Type.GetType("System.String"))
            dtAvisos.Columns.Add("Clien", Type.GetType("System.String"))
            dtAvisos.Columns.Add("Factu", Type.GetType("System.String"))
            dtAvisos.Columns.Add("Feven", Type.GetType("System.String"))
            dtAvisos.Columns.Add("Anexo", Type.GetType("System.String"))
            dtAvisos.Columns.Add("Letra", Type.GetType("System.String"))
            dtAvisos.Columns.Add("Tasa", Type.GetType("System.String"))
            dtAvisos.Columns.Add("Dias", Type.GetType("System.String"))
            dtAvisos.Columns.Add("Saldo", Type.GetType("System.String"))
            dtAvisos.Columns.Add("Salse", Type.GetType("System.String"))
            dtAvisos.Columns.Add("Saldot", Type.GetType("System.String"))
            dtAvisos.Columns.Add("Udi1", Type.GetType("System.String"))
            dtAvisos.Columns.Add("Udi2", Type.GetType("System.String"))
            dtAvisos.Columns.Add("Tipar", Type.GetType("System.String"))
            dtAvisos.Columns.Add("ImporteA", Type.GetType("System.String"))
            dtAvisos.Columns.Add("ImporteB", Type.GetType("System.String"))
            dtAvisos.Columns.Add("ImporteC", Type.GetType("System.String"))
            dtAvisos.Columns.Add("ImporteD", Type.GetType("System.String"))
            dtAvisos.Columns.Add("ImporteE", Type.GetType("System.String"))
            dtAvisos.Columns.Add("ImporteF", Type.GetType("System.String"))
            dtAvisos.Columns.Add("ImporteG", Type.GetType("System.String"))
            dtAvisos.Columns.Add("ImporteH", Type.GetType("System.String"))
            dtAvisos.Columns.Add("ImporteI", Type.GetType("System.String"))
            dtAvisos.Columns.Add("ImporteJ", Type.GetType("System.String"))
            dtAvisos.Columns.Add("ImporteK", Type.GetType("System.String"))
            dtAvisos.Columns.Add("ImporteL", Type.GetType("System.String"))
            dtAvisos.Columns.Add("ImporteM", Type.GetType("System.String"))
            dtAvisos.Columns.Add("ImporteN", Type.GetType("System.String"))
            dtAvisos.Columns.Add("ImporteO", Type.GetType("System.String"))
            dtAvisos.Columns.Add("ImporteP", Type.GetType("System.String"))
            dtAvisos.Columns.Add("ImporteQ", Type.GetType("System.String"))
            dtAvisos.Columns.Add("ImporteR", Type.GetType("System.String"))
            dtAvisos.Columns.Add("ImporteS", Type.GetType("System.String"))
            dtAvisos.Columns.Add("ImporteT", Type.GetType("System.String"))
            dtAvisos.Columns.Add("ImporteU", Type.GetType("System.String"))
            dtAvisos.Columns.Add("ImporteV", Type.GetType("System.String"))
            dtAvisos.Columns.Add("ImporteW", Type.GetType("System.String"))
            dtAvisos.Columns.Add("ImporteX", Type.GetType("System.String"))
            dtAvisos.Columns.Add("ImporteY", Type.GetType("System.String"))
            dtAvisos.Columns.Add("ImporteZ", Type.GetType("System.String"))
            dtAvisos.Columns.Add("ImporteFega", Type.GetType("System.String"))
            dtAvisos.Columns.Add("Importe1A", Type.GetType("System.String"))
            dtAvisos.Columns.Add("Adeudoant", Type.GetType("System.String"))
            dtAvisos.Columns.Add("GranTotal", Type.GetType("System.String"))
            dtAvisos.Columns.Add("Cusnam", Type.GetType("System.String"))
            dtAvisos.Columns.Add("Monto", Type.GetType("System.String"))

            drAnexo = dsAgil.Tables("Avisos").Rows(0)

            cAnexo = drAnexo("Anexo")
            cCliente = drAnexo("Cliente")
            cTipar = drAnexo("Tipar")
            cFeven = drAnexo("Feven")

            ' Traigo las facturas que muestren adeudo a la fecha del aviso seleccionado

            With cm2
                .CommandType = CommandType.StoredProcedure
                .CommandText = "Repantig1"
                .Connection = cnAgil
                .Parameters.Add("@Fecha", SqlDbType.NVarChar)
                .Parameters(0).Value = cFeven
            End With

            ' Traigo todas las Udis

            With cm3
                .CommandType = CommandType.StoredProcedure
                .CommandText = "Traeudis1"
                .Connection = cnAgil
            End With

            ' Llenar el dataset lo cual abre y cierra la conexión

            daFacturas.Fill(dsAgil, "Facturas")
            daUdis.Fill(dsAgil, "Udis")

            ' Creo el DataRowCollection de las Udis para poderlas enviar a la función que calcula los Moratorios

            drUdis = dsAgil.Tables("Udis").Rows

            ' Creo el DataRowCollection de las facturas para poder enviar a la funcion que busca adeudos anterioes

            drFacturas = dsAgil.Tables("Facturas").Rows

            ' Esta es una nueva forma de calcular el plazo que implementé a partir del 17 de octubre de 2011
            ' para determinar correctamente el plazo para frecuencias de pago diferentes a mensual

            nPlazo = 0
            CuentaPagos(cAnexo, nPlazo)

            nSaldo = drAnexo("Saldo")
            nSalse = drAnexo("Salse")
            nSaldot = drAnexo("Saldot")

            nTasa = drAnexo("nTasa")
            nUdi1 = drAnexo("Udi1")
            nUdi2 = drAnexo("Udi2")

            nBonifica = 0
            nTasaBonificacion = 0
            nBaseBonificacion = 0
            nIvaBonificacion = 0

            If cTipar = "P" Then

                nCapeq = drAnexo("CapEq") + drAnexo("IntPr") + drAnexo("VarPr")
                nIvacapital = 0
                nIntEq = 0
                nIvaEq = drAnexo("IvaCapital") + drAnexo("Ivapr")

            Else

                nCapeq = drAnexo("Capeq")
                nIvacapital = drAnexo("Ivacapital")
                nIntEq = drAnexo("IntPr") + drAnexo("VarPr")
                nIvaEq = drAnexo("Ivapr")

                ' Esta es una nueva forma de determinar la descomposición de la Bonificación en Base e IVA a partir del 20 de octubre de 2011

                nBonifica = drAnexo("Bonifica")
                If nBonifica > 0 Then
                    nTasaBonificacion = Round(nBonifica / nCapeq, 4)
                    nBaseBonificacion = Round(nBonifica / (1 + nTasaBonificacion), 2)
                    nIvaBonificacion = Round(nBonifica - nBaseBonificacion, 2)
                    nBaseBonificacion = nBaseBonificacion * -1
                    nIvaBonificacion = nIvaBonificacion * -1
                End If

            End If

            nRense = drAnexo("Rense")
            nIntSe = drAnexo("Intse") + drAnexo("VarSe")
            nIvaSe = drAnexo("Ivase")

            nCapot = drAnexo("Capitalot")
            nIntOt = drAnexo("Interesot") + drAnexo("VarOt")
            nIvaOt = drAnexo("Ivaot")

            nSegVida = drAnexo("SeguroVida")
            nImporteFega = drAnexo("ImporteFega")

            nOpcion = 0
            nIvaopc = 0

            If Val(drAnexo("Letra")) = nPlazo Then
                If Not IsDBNull(drAnexo("Opcion")) Then
                    nOpcion = drAnexo("Opcion")
                    nIvaopc = drAnexo("IvaOpcion")
                End If
            End If

            nTotaleq = Round(nCapeq + nIvacapital - nBonifica + nIntEq + nIvaEq + nOpcion + nIvaopc, 2)
            nTotalse = Round(nRense + nIntSe + nIvaSe, 2)
            nTotalot = Round(nCapot + nIntOt + nIvaOt + nSegVida + nImporteFega, 2)
            nImpFac = Round(drAnexo("ImporteFac") + Val(nOpcion) + Val(nIvaopc), 2)

            cLetras = Letras(nImpFac.ToString)

            ' Creo la tabla con adeudos anteriores

            Adanterior(dtAdeudos, drUdis, drFacturas, cFeven)
            dsAgil.Tables.Add(dtAdeudos)
            drAdeudos = dsAgil.Tables("Adeudos").Rows

            ' Busco adeudos anteriores

            drAdeudo = drAdeudos.Find(cAnexo)
            nAdeudo = 0
            nGranTotal = 0

            If Not drAdeudo Is Nothing Then
                nAdeudo = drAdeudo("AdeudoAnt")
                nGranTotal = nImpFac + nAdeudo
            End If

            drAviso = dtAvisos.NewRow()
            drAviso("RFC") = drAnexo("RFC")
            drAviso("Calle") = drAnexo("Calle")
            drAviso("Colonia") = drAnexo("Colonia")
            drAviso("Copos") = drAnexo("Copos")
            drAviso("Deleg") = drAnexo("Delegacion")
            drAviso("Descp") = drAnexo("DescPlaza")
            drAviso("Clien") = cCliente
            drAviso("Factu") = nFactura
            drAviso("Feven") = drAnexo("Feven")
            drAviso("Anexo") = Mid(drAnexo("Anexo"), 1, 5) & "/" & Mid(drAnexo("Anexo"), 6, 9)
            drAviso("Letra") = (Val(drAnexo("Letra"))).ToString & " de " & nPlazo.ToString
            drAviso("Tasa") = FormatNumber(nTasa.ToString, 4)
            drAviso("Dias") = drAnexo("Dias")
            drAviso("Saldo") = FormatNumber(nSaldo.ToString, 2)
            drAviso("Salse") = FormatNumber(nSalse.ToString, 2)
            drAviso("Saldot") = FormatNumber(nSaldot.ToString, 2)
            drAviso("Udi1") = FormatNumber(nUdi1.ToString, 6)
            drAviso("Udi2") = FormatNumber(nUdi2.ToString, 6)
            drAviso("Tipar") = drAnexo("Tipar")
            drAviso("ImporteA") = FormatNumber(nCapeq.ToString, 2)
            drAviso("ImporteB") = FormatNumber(nRense.ToString, 2)
            drAviso("ImporteW") = FormatNumber(nCapot.ToString, 2)
            drAviso("ImporteC") = FormatNumber((nCapeq + nRense + nCapot).ToString, 2)
            If cTipar = "P" Then
                drAviso("ImporteD") = FormatNumber(nIvaEq.ToString, 2)
                drAviso("ImporteM") = FormatNumber(0.ToString, 2)
                drAviso("ImporteO") = FormatNumber((nIvaSe + nIvaOt).ToString, 2)
            Else
                drAviso("ImporteD") = FormatNumber(-nBaseBonificacion.ToString, 2)
                drAviso("ImporteM") = FormatNumber(nIvaEq.ToString, 2)
                drAviso("ImporteO") = FormatNumber((nIvaEq + nIvaSe + nIvaOt).ToString, 2)
            End If
            drAviso("ImporteF") = FormatNumber(nIvacapital.ToString, 2)
            drAviso("ImporteH") = FormatNumber(-nIvaBonificacion.ToString, 2)
            drAviso("ImporteJ") = FormatNumber(nIntEq.ToString, 2)
            drAviso("ImporteK") = FormatNumber(nIntSe.ToString, 2)
            drAviso("ImporteL") = FormatNumber((nIntEq + nIntSe + nIntOt).ToString, 2)
            drAviso("ImporteN") = FormatNumber(nIvaSe.ToString, 2)
            drAviso("ImporteP") = FormatNumber(nOpcion.ToString, 2)
            drAviso("ImporteR") = FormatNumber(nIvaopc.ToString, 2)
            drAviso("ImporteT") = FormatNumber(nTotaleq.ToString, 2)
            drAviso("ImporteU") = FormatNumber(nTotalse.ToString, 2)
            drAviso("ImporteV") = FormatNumber((nTotaleq + nTotalse + nTotalot).ToString, 2)
            drAviso("ImporteX") = FormatNumber(nIntOt.ToString, 2)
            drAviso("ImporteY") = FormatNumber(nIvaOt.ToString, 2)
            drAviso("ImporteZ") = FormatNumber(nTotalot.ToString, 2)
            drAviso("Importe1A") = FormatNumber(nSegVida.ToString, 2)
            drAviso("AdeudoAnt") = FormatNumber(nAdeudo.ToString, 2)
            drAviso("GranTotal") = FormatNumber(nGranTotal.ToString, 2)
            drAviso("ImporteFega") = FormatNumber(nImporteFega.ToString, 2)
            drAviso("Cusnam") = drAnexo("Descr")
            drAviso("Monto") = cLetras
            dtAvisos.Rows.Add(drAviso)

            dsAgil.Tables.Remove("Avisos")
            dsAgil.Tables.Add(dtAvisos)
            'Descomentar la siguiente línea en caso de que se deseara modificar el reporte rptImpreFac
            'dsAgil.WriteXml("C:\Schema8.xml", XmlWriteMode.WriteSchema)
            newrptImpreFac.SetDataSource(dsAgil)
            CrystalReportViewer1.ReportSource = newrptImpreFac
            CrystalReportViewer1.Visible = True

        End If

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()
        cm3.Dispose()

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class
