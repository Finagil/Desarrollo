Option Explicit On 

Imports System.Data.SqlClient
Imports System.Math

Public Class frmImpreFac

    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents lblInicio As System.Windows.Forms.Label
    Friend WithEvents btnImpAvisos As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblInicio = New System.Windows.Forms.Label
        Me.btnImpAvisos = New System.Windows.Forms.Button
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.btnSalir = New System.Windows.Forms.Button
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker
        Me.SuspendLayout()
        '
        'lblInicio
        '
        Me.lblInicio.Location = New System.Drawing.Point(16, 16)
        Me.lblInicio.Name = "lblInicio"
        Me.lblInicio.Size = New System.Drawing.Size(105, 20)
        Me.lblInicio.TabIndex = 0
        Me.lblInicio.Text = "Fecha del Proceso"
        Me.lblInicio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnImpAvisos
        '
        Me.btnImpAvisos.Location = New System.Drawing.Point(238, 16)
        Me.btnImpAvisos.Name = "btnImpAvisos"
        Me.btnImpAvisos.Size = New System.Drawing.Size(104, 23)
        Me.btnImpAvisos.TabIndex = 4
        Me.btnImpAvisos.Text = "Desplegar Avisos"
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(8, 56)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.ShowCloseButton = False
        Me.CrystalReportViewer1.ShowGroupTreeButton = False
        Me.CrystalReportViewer1.ShowRefreshButton = False
        Me.CrystalReportViewer1.ShowZoomButton = False
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1008, 640)
        Me.CrystalReportViewer1.TabIndex = 5
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(373, 16)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(104, 23)
        Me.btnSalir.TabIndex = 6
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(124, 17)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(88, 20)
        Me.dtpFecha.TabIndex = 7
        '
        'frmImpreFac
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1024, 702)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.btnImpAvisos)
        Me.Controls.Add(Me.lblInicio)
        Me.Name = "frmImpreFac"
        Me.Text = "Impresión de Avisos que se retienen"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnImpAvisos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnImpAvisos.Click

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

        Dim newrptImpreFac As New rptImpreFac()

        btnImpAvisos.Enabled = False

        cFeven = DTOC(dtpFecha.Value)
        
        ' Con este Stored Procedure obtengo el rango de avisos solicitado.

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Avisos4"
            .Connection = cnAgil
            .Parameters.Add("@Fecha", SqlDbType.NVarChar)
            .Parameters(0).Value = cFeven
        End With

        ' Traigo las facturas que muestren adeudo a la fecha de la generación de los avisos

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

        ' Llenar el DataSet lo cual abre y cierra la conexión

        daAvisos.Fill(dsAgil, "Avisos")
        daFacturas.Fill(dsAgil, "Facturas")
        daUdis.Fill(dsAgil, "Udis")

        ' Creo la estructura de la tabla que almacenará los adeudos encontrados

        dtAdeudos.Columns.Add("Anexo", Type.GetType("System.String"))
        dtAdeudos.Columns.Add("Adeudoant", Type.GetType("System.Decimal"))
        myColArray(0) = dtAdeudos.Columns("Anexo")
        dtAdeudos.PrimaryKey = myColArray

        ' Creo el DataRowCollection de las Udis para poderlas enviar a la función que calcula los Moratorios

        drUdis = dsAgil.Tables("Udis").Rows

        ' Creo el DataRowCollection de las facturas para poder enviar a la función que busca adeudos anteriores

        drFacturas = dsAgil.Tables("Facturas").Rows

        ' Creo la tabla con adeudos anteriores

        Adanterior(dtAdeudos, drUdis, drFacturas, cFeven)
        dsAgil.Tables.Add(dtAdeudos)
        drAdeudos = dsAgil.Tables("Adeudos").Rows

        nCounter = dsAgil.Tables("Avisos").Rows.Count

        If nCounter > 0 Then

            'Creo una tabla Temporal donde almaceno los datos que formarán parte del reporte final

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
            dtAvisos.Columns.Add("Importe1A", Type.GetType("System.String"))
            dtAvisos.Columns.Add("Adeudoant", Type.GetType("System.String"))
            dtAvisos.Columns.Add("GranTotal", Type.GetType("System.String"))
            dtAvisos.Columns.Add("Cusnam", Type.GetType("System.String"))
            dtAvisos.Columns.Add("Monto", Type.GetType("System.String"))
            dtAvisos.Columns.Add("ImporteFega", Type.GetType("System.String"))

            For Each drAnexo In dsAgil.Tables("Avisos").Rows

                cAnexo = drAnexo("Anexo")
                cCliente = drAnexo("Cliente")
                cTipar = drAnexo("Tipar")
                nFactura = drAnexo("Factura")

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

            Next

            dsAgil.Tables.Remove("Avisos")
            dsAgil.Tables.Add(dtAvisos)
            'Descomentar la siguiente línea en caso de que se deseara modificar el reporte rptImpreFac
            'dsAgil.WriteXml("C:\Schema8.xml", XmlWriteMode.WriteSchema)
            newrptImpreFac.SetDataSource(dsAgil)
            CrystalReportViewer1.ReportSource = newrptImpreFac
            CrystalReportViewer1.Visible = True

            cnAgil.Dispose()
            cm1.Dispose()

        Else

            MsgBox("No hay Avisos por Retener", MsgBoxStyle.OkOnly, "Mensaje")
            cnAgil.Dispose()
            cm1.Dispose()
            Me.Close()

        End If
        
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class
