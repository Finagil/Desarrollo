Option Explicit On 

Imports System.Math
Imports System.Data.SqlClient

Public Class frmAvisos

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
    Friend WithEvents btnAvisos As System.Windows.Forms.Button
    Friend WithEvents lblAvisos As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnAvisos = New System.Windows.Forms.Button
        Me.lblAvisos = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.btnSalir = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnAvisos
        '
        Me.btnAvisos.Location = New System.Drawing.Point(475, 33)
        Me.btnAvisos.Name = "btnAvisos"
        Me.btnAvisos.Size = New System.Drawing.Size(75, 23)
        Me.btnAvisos.TabIndex = 21
        Me.btnAvisos.Text = "Procesar"
        '
        'lblAvisos
        '
        Me.lblAvisos.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAvisos.Location = New System.Drawing.Point(16, 32)
        Me.lblAvisos.Name = "lblAvisos"
        Me.lblAvisos.Size = New System.Drawing.Size(328, 24)
        Me.lblAvisos.TabIndex = 20
        Me.lblAvisos.Text = "Selecciona a partir de qué fecha se subirán los Avisos"
        Me.lblAvisos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(352, 34)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(88, 20)
        Me.DateTimePicker1.TabIndex = 19
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(572, 33)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 22
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'frmAvisos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(725, 102)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnAvisos)
        Me.Controls.Add(Me.lblAvisos)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Name = "frmAvisos"
        Me.Text = "Subir avisos a la página Web"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnAvisos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAvisos.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daAvisos As New SqlDataAdapter(cm1)
        Dim dsAgil As New DataSet()
        Dim drAnexo As DataRow
        Dim drAvisos As DataRow
        Dim drAnexos As DataRowCollection
        Dim dtAvisos As New DataTable("Avisos")

        ' Declaración de variables de datos

        Dim cAnexo As String = ""
        Dim cCliente As String = ""
        Dim cFecha As String = ""
        Dim cLetras As String = ""
        Dim cTipar As String = ""
        Dim nBaseBonificacion As Decimal = 0
        Dim nBonifica As Decimal = 0
        Dim nCapeq As Decimal = 0
        Dim nCapse As Decimal = 0
        Dim nCapitalOtros As Decimal = 0
        Dim nImporteFac As Decimal = 0
        Dim nInteq As Decimal = 0
        Dim nIntse As Decimal = 0
        Dim nInteresOtros As Decimal = 0
        Dim nIvaBonificacion As Decimal = 0
        Dim nIvacapital As Decimal = 0
        Dim nIvaopc As Decimal = 0
        Dim nIvapr As Decimal = 0
        Dim nIvase As Decimal = 0
        Dim nIvaOtros As Decimal = 0
        Dim nOpcion As Decimal = 0
        Dim nPlazo As Byte = 0
        Dim nRense As Decimal = 0
        Dim nSaldo As Decimal = 0
        Dim nSalse As Decimal = 0
        Dim nSaldoOtros As Decimal = 0
        Dim nSeguroVida As Decimal = 0
        Dim nTasa As Decimal = 0
        Dim nTasaBonificacion As Decimal = 0
        Dim nTotaleq As Decimal = 0
        Dim nTotalse As Decimal = 0
        Dim nTotalOtros As Decimal = 0
        Dim nUdi1 As Decimal = 0
        Dim nUdi2 As Decimal = 0
        Dim nVarpr As Decimal = 0

        btnAvisos.Enabled = False
        DateTimePicker1.Enabled = False

        cFecha = DTOC(DateTimePicker1.Value)

        ' Con este Stored Procedure obtengo todas las facturas con fecha de vencimiento
        ' mayor o igual a la fecha que se está solicitando.

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Aviso1"
            .Connection = cnAgil
            .Parameters.Add("@Fecha", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        ' Llenar el dataset lo cual abre y cierra la conexión

        daAvisos.Fill(dsAgil, "Avisos")

        drAnexos = dsAgil.Tables("Avisos").Rows

        'Creo una tabla Temporal donde almaceno los datos que formarán parte del reporte final

        dtAvisos.Columns.Add("RFC", Type.GetType("System.String"))
        dtAvisos.Columns.Add("Clien", Type.GetType("System.String"))
        dtAvisos.Columns.Add("Factu", Type.GetType("System.String"))
        dtAvisos.Columns.Add("Feven", Type.GetType("System.String"))
        dtAvisos.Columns.Add("Anexo", Type.GetType("System.String"))
        dtAvisos.Columns.Add("Letra", Type.GetType("System.String"))
        dtAvisos.Columns.Add("Tasa", Type.GetType("System.String"))
        dtAvisos.Columns.Add("Dias", Type.GetType("System.String"))
        dtAvisos.Columns.Add("Saldo", Type.GetType("System.String"))
        dtAvisos.Columns.Add("Salse", Type.GetType("System.String"))
        dtAvisos.Columns.Add("SaldOt", Type.GetType("System.String"))
        dtAvisos.Columns.Add("Udi1", Type.GetType("System.String"))
        dtAvisos.Columns.Add("Udi2", Type.GetType("System.String"))
        dtAvisos.Columns.Add("Importe1", Type.GetType("System.String"))
        dtAvisos.Columns.Add("Importe2", Type.GetType("System.String"))
        dtAvisos.Columns.Add("Importe3", Type.GetType("System.String"))
        dtAvisos.Columns.Add("Importe4", Type.GetType("System.String"))
        dtAvisos.Columns.Add("Importe5", Type.GetType("System.String"))
        dtAvisos.Columns.Add("Importe6", Type.GetType("System.String"))
        dtAvisos.Columns.Add("Importe7", Type.GetType("System.String"))
        dtAvisos.Columns.Add("Importe8", Type.GetType("System.String"))
        dtAvisos.Columns.Add("Importe9", Type.GetType("System.String"))
        dtAvisos.Columns.Add("Importe10", Type.GetType("System.String"))
        dtAvisos.Columns.Add("Importe11", Type.GetType("System.String"))
        dtAvisos.Columns.Add("Importe12", Type.GetType("System.String"))
        dtAvisos.Columns.Add("Importe13", Type.GetType("System.String"))
        dtAvisos.Columns.Add("Importe14", Type.GetType("System.String"))
        dtAvisos.Columns.Add("Importe15", Type.GetType("System.String"))
        dtAvisos.Columns.Add("Importe16", Type.GetType("System.String"))
        dtAvisos.Columns.Add("Importe17", Type.GetType("System.String"))
        dtAvisos.Columns.Add("Importe18", Type.GetType("System.String"))
        dtAvisos.Columns.Add("Importe19", Type.GetType("System.String"))
        dtAvisos.Columns.Add("Importe20", Type.GetType("System.String"))
        dtAvisos.Columns.Add("Importe21", Type.GetType("System.String"))
        dtAvisos.Columns.Add("Importe22", Type.GetType("System.String"))
        dtAvisos.Columns.Add("Importe23", Type.GetType("System.String"))
        dtAvisos.Columns.Add("Importe24", Type.GetType("System.String"))
        dtAvisos.Columns.Add("Importe25", Type.GetType("System.String"))
        dtAvisos.Columns.Add("Importe26", Type.GetType("System.String"))
        dtAvisos.Columns.Add("Importe27", Type.GetType("System.String"))
        dtAvisos.Columns.Add("Importe28", Type.GetType("System.String"))
        dtAvisos.Columns.Add("Cusnam", Type.GetType("System.String"))
        dtAvisos.Columns.Add("Monto", Type.GetType("System.String"))

        For Each drAnexo In drAnexos

            cAnexo = drAnexo("Anexo")

            nOpcion = 0
            nIvaopc = 0

            ' Esta es una nueva forma de calcular el plazo que implementé a partir del 17 de octubre de 2011
            ' para determinar correctamente el plazo para frecuencias de pago diferentes a mensual

            nPlazo = 0
            CuentaPagos(cAnexo, nPlazo)

            If Val(drAnexo("Letra")) = nPlazo Then
                If IsDBNull(drAnexo("Opcion")) Then
                    MsgBox("No está generada la Opción de Compra", MsgBoxStyle.OkOnly, "Mensaje")
                Else
                    nOpcion = drAnexo("Opcion")
                    nIvaopc = drAnexo("IvaOpcion")
                End If
            End If

            nImporteFac = Round(drAnexo("ImporteFac") + Val(nOpcion) + Val(nIvaopc), 2)
            cLetras = Letras(nImporteFac.ToString)

            nSaldo = drAnexo("Saldo")
            nSalse = drAnexo("Salse")
            nSaldoOtros = drAnexo("SaldOt")

            nTasa = drAnexo("nTasa")
            nUdi1 = drAnexo("Udi1")
            nUdi2 = drAnexo("Udi2")
            nCapeq = drAnexo("Capeq")
            nRense = drAnexo("Rense")

            ' Esta es una nueva forma de determinar la descomposición de la Bonificación en Base e IVA a partir del 20 de octubre de 2011

            nBonifica = drAnexo("Bonifica")
            nTasaBonificacion = 0
            nBaseBonificacion = 0
            nIvaBonificacion = 0

            If nBonifica > 0 Then
                nTasaBonificacion = Round(nBonifica / nCapeq, 4)
                nBaseBonificacion = Round(nBonifica / (1 + nTasaBonificacion), 2)
                nIvaBonificacion = Round(nBonifica - nBaseBonificacion, 2)
                nBaseBonificacion = nBaseBonificacion * -1
                nIvaBonificacion = nIvaBonificacion * -1
            End If

            nIvacapital = drAnexo("Ivacapital")
            nInteq = drAnexo("Inteq")
            nIvapr = drAnexo("Ivapr")

            nCapse = drAnexo("Capse")
            nIntse = drAnexo("Intse")
            nIvase = drAnexo("Ivase")

            nCapitalOtros = drAnexo("CapitalOt")
            nInteresOtros = Round(drAnexo("InteresOt") + drAnexo("VarOt"), 2)
            nIvaOtros = drAnexo("IvaOt")

            nSeguroVida = drAnexo("SeguroVida")

            nTotaleq = Round(nCapeq - nBonifica + nIvacapital + nInteq + nIvapr + nOpcion + nIvaopc, 2)
            nTotalse = Round(nRense + nIntse + nIvase, 2)
            nTotalOtros = Round(nCapitalOtros + nInteresOtros + nIvaOtros + nSeguroVida, 2)

            cCliente = drAnexo("Cliente")
            cTipar = drAnexo("Tipar")
            nVarpr = drAnexo("Varpr")

            Select Case cCliente
                Case "00147", "00618", "00736", "00806", "00958", "01119", "01147", "01260", "01462", "01502", "01599", "01619"
                    cCliente = "01119"
                Case "01623", "01626", "01627", "01667", "01736", "01748", "01788", "01799", "01818", "01819", "01884", "01896"
                    cCliente = "01119"
                Case "01915", "01963", "01964", "02066", "02101", "02133", "02173", "02357", "02436"
                    cCliente = "01119"
            End Select

            drAvisos = dtAvisos.NewRow()
            drAvisos("RFC") = drAnexo("RFC")
            drAvisos("Clien") = cCliente
            drAvisos("Factu") = drAnexo("Factura")
            drAvisos("Feven") = drAnexo("Feven")
            drAvisos("Anexo") = Mid(drAnexo("Anexo"), 1, 5) & "/" & Mid(drAnexo("Anexo"), 6, 9)
            drAvisos("Letra") = (Val(drAnexo("Letra"))).ToString & " de " & nPlazo.ToString
            drAvisos("Tasa") = FormatNumber(nTasa.ToString, 4)
            drAvisos("Dias") = drAnexo("Dias")
            drAvisos("Saldo") = FormatNumber(nSaldo.ToString, 2)
            drAvisos("Salse") = FormatNumber(nSalse.ToString, 2)
            drAvisos("SaldOt") = FormatNumber(nSaldoOtros.ToString, 2)
            drAvisos("Udi1") = FormatNumber(nUdi1.ToString, 6)
            drAvisos("Udi2") = FormatNumber(nUdi2.ToString, 6)
            drAvisos("Importe1") = IIf(cTipar = "P", FormatNumber((nCapeq + nVarpr).ToString, 2), FormatNumber(nCapeq.ToString, 2))
            drAvisos("Importe2") = IIf(cTipar = "P", FormatNumber((nRense + nIntse).ToString, 2), FormatNumber(nRense.ToString, 2))
            drAvisos("Importe3") = FormatNumber(nCapitalOtros.ToString, 2)
            drAvisos("Importe4") = FormatNumber((nCapeq + nRense + nCapitalOtros).ToString, 2)
            drAvisos("Importe5") = FormatNumber(nBaseBonificacion.ToString, 2)
            drAvisos("Importe6") = FormatNumber(nBaseBonificacion.ToString, 2)
            drAvisos("Importe7") = FormatNumber(nIvacapital.ToString, 2)
            drAvisos("Importe8") = FormatNumber(nIvacapital.ToString, 2)
            drAvisos("Importe9") = FormatNumber(nIvaBonificacion.ToString, 2)
            drAvisos("Importe10") = FormatNumber(nIvaBonificacion.ToString, 2)
            drAvisos("Importe11") = FormatNumber(nInteq.ToString, 2)
            drAvisos("Importe12") = FormatNumber(nIntse.ToString, 2)
            drAvisos("Importe13") = FormatNumber(nInteresOtros.ToString, 2)
            drAvisos("Importe14") = FormatNumber((nInteq + nIntse + nInteresOtros).ToString, 2)
            drAvisos("Importe15") = FormatNumber(nIvapr.ToString, 2)
            drAvisos("Importe16") = FormatNumber(nIvase.ToString, 2)
            drAvisos("Importe17") = FormatNumber(nIvaOtros.ToString, 2)
            drAvisos("Importe18") = FormatNumber((nIvapr + nIvase + nIvaOtros).ToString, 2)
            drAvisos("Importe19") = FormatNumber(nOpcion.ToString, 2)
            drAvisos("Importe20") = FormatNumber(nOpcion.ToString, 2)
            drAvisos("Importe21") = FormatNumber(nIvaopc.ToString, 2)
            drAvisos("Importe22") = FormatNumber(nIvaopc.ToString, 2)
            drAvisos("Importe23") = FormatNumber(nSeguroVida.ToString, 2)
            drAvisos("Importe24") = FormatNumber(nSeguroVida.ToString, 2)
            drAvisos("Importe25") = FormatNumber(nTotaleq.ToString, 2)
            drAvisos("Importe26") = FormatNumber(nTotalse.ToString, 2)
            drAvisos("Importe27") = FormatNumber(nTotalOtros.ToString, 2)
            drAvisos("Importe28") = FormatNumber(nImporteFac.ToString, 2)
            drAvisos("Cusnam") = Trim(drAnexo("Descr"))
            drAvisos("Monto") = cLetras
            dtAvisos.Rows.Add(drAvisos)
        Next

        dsAgil.Tables.Remove("Avisos")
        dsAgil.Tables.Add(dtAvisos)
        dsAgil.WriteXml("R:SchemaX.xml", XmlWriteMode.WriteSchema)

        cnAgil.Dispose()
        cm1.Dispose()

        MsgBox("Avisos subidos a la página Web", MsgBoxStyle.Information, "Mensaje")

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class
