Option Explicit On 

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports System.Math
Imports Microsoft.Office.Interop

Public Class frmGenAviso

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
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnProcesar = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(288, 24)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(88, 20)
        Me.DateTimePicker1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(104, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(176, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Seleccione Fecha de Facturación"
        '
        'btnProcesar
        '
        Me.btnProcesar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProcesar.Location = New System.Drawing.Point(392, 24)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(75, 23)
        Me.btnProcesar.TabIndex = 2
        Me.btnProcesar.Text = "Procesar"
        '
        'frmGenAviso
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(584, 214)
        Me.Controls.Add(Me.btnProcesar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Name = "frmGenAviso"
        Me.Text = "Generación y Envío de Avisos PDF"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim daAvisos As New SqlDataAdapter(cm1)
        Dim daFacturas As New SqlDataAdapter(cm2)
        Dim daUdis As New SqlDataAdapter(cm3)
        Dim drAviso As DataRow
        Dim drAdeudo As DataRow
        Dim drAdeudos As DataRowCollection
        Dim drAnexo As DataRow
        Dim drFacturas As DataRowCollection
        Dim drUdis As DataRowCollection
        Dim dsAgil As New DataSet()
        Dim dsTemporal As New DataSet()
        Dim dtAdeudos As New DataTable("Adeudos")
        Dim dtAvisos As New DataTable("Avisos")
        Dim myColArray(1) As DataColumn
        Dim strUpdate As String

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

        ' Declaración de variables necesarias para generar archivos PDF

        Dim newrptImpreFac As rptImpreFac
        Dim crDiskFileDestinationOptions As New DiskFileDestinationOptions()

        ' Declaración de variables necesarias para enviar correo electrónico a través de Microsoft Outlook

        Dim oApp As Outlook._Application
        Dim oMsg As Outlook._MailItem
        Dim sSource1 As String = ""
        ' Dim sSource2 As String = ""
        Dim oAttachs As Outlook.Attachments
        Dim oAttach As Outlook.Attachment

        btnProcesar.Enabled = False
        DateTimePicker1.Enabled = False

        cFeven = DTOC(DateTimePicker1.Value)

        ' Este Stored Procedure trae todas las facturas de una fecha determinada, de los clientes que tengan dirección de correo electrónico
        ' y que no les haya sido enviado su aviso de vencimiento de renta con anterioridad.

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "GenAviso1"
            .Connection = cnAgil
            .Parameters.Add("@Feven", SqlDbType.NVarChar)
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

        ' Creo el DataRowCollection de las facturas para poder enviar a la funcion que busca adeudos anterioes

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

            oApp = New Outlook.Application()

            cnAgil.Open()

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

                newrptImpreFac = New rptImpreFac
                dsTemporal.Tables.Add(dtAvisos)
                newrptImpreFac.SetDataSource(dsTemporal)
                newrptImpreFac.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
                newrptImpreFac.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat
                crDiskFileDestinationOptions.DiskFileName = "C:\FILES\AVISO " & CStr(nFactura) & ".PDF"
                newrptImpreFac.ExportOptions.DestinationOptions = crDiskFileDestinationOptions
                newrptImpreFac.Export()

                '"FAVOR DE LEER Y ATENDER EL ARCHIVO ADJUNTO." & vbCr & vbCr & _
                '"SALUDOS CORDIALES." & vbCr & vbCr

                oMsg = oApp.CreateItem(Outlook.OlItemType.olMailItem)
                oMsg.Subject = "AVISO " & CStr(nFactura) & " FINAGIL, S.A. de C.V. SOFOM, E.N.R."
                oMsg.Body = "Contrato : " & Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 6, 4) & vbCr & vbCr & _
                "FECHA LIMITE DE PAGO : " & Mid(cFeven, 7, 2) & "/" & Mid(cFeven, 5, 2) & "/" & Mid(cFeven, 1, 4) & vbCr & vbCr & _
                "IMPORTE A PAGAR : " & Format(nImpFac, "C") & vbCr & vbCr & _
                "ESTIMADO CLIENTE : " & vbCr & vbCr & _
                "LE INFORMAMOS QUE PARA PODER ENTREGARLE SU FACTURA DE ACTIVO FIJO" & vbCr & vbCr & _
                "SERA NECESARIO QUE NOS PRESENTE AL TERMINO O CANCELACIÓN DE SU" & vbCr & vbCr & _
                "CONTRATO, LAS TENENCIAS PAGADAS DE LOS ULTIMOS TRES AÑOS" & vbCr & vbCr & _
                "SI NO CUMPLE CON ESTE REQUISITO NO SE LE PODRA ENTREGAR DICHA FACTURA" & vbCr & vbCr

                oMsg.To = RTrim(drAnexo("Email1"))
                If RTrim(drAnexo("Email2")) <> "*" Then
                    oMsg.CC = RTrim(drAnexo("Email2"))
                Else
                    oMsg.CC = ""
                End If
                sSource1 = "C:\FILES\AVISO " & CStr(nFactura) & ".PDF"
                ' sSource2 = "C:\FILES\BAJA DE CUENTA.PDF"
                oAttachs = oMsg.Attachments
                oAttach = oAttachs.Add(sSource1)
                ' oAttach = oAttachs.Add(sSource2)
                oMsg.Send()

                strUpdate = "UPDATE Facturas SET Enviado = 'S' WHERE Factura = " & nFactura

                cm1 = New SqlCommand(strUpdate, cnAgil)
                cm1.ExecuteNonQuery()

                Kill("C:\FILES\AVISO " & CStr(nFactura) & ".PDF")

                dtAvisos.Rows.Clear()
                dsTemporal.Tables.Clear()
                newrptImpreFac.Dispose()

                oAttach = Nothing
                oAttachs = Nothing
                oMsg = Nothing

            Next

            oApp = Nothing

            cnAgil.Close()

            cnAgil.Dispose()
            cm1.Dispose()
            cm2.Dispose()
            cm3.Dispose()

            MsgBox("Generación de Avisos PDF terminada", MsgBoxStyle.Information, "Mensaje")

        Else

            cnAgil.Dispose()
            cm1.Dispose()
            cm2.Dispose()
            cm3.Dispose()

            MsgBox("NO HAY AVISOS PARA ENVIAR", MsgBoxStyle.OkOnly, "Mensaje")
            Me.Close()

        End If

    End Sub

End Class
