Option Explicit On 

Imports System.Data.SqlClient
Imports System.Math

Public Class frmRepInter

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
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnProcesar = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.btnSalir = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnProcesar
        '
        Me.btnProcesar.Location = New System.Drawing.Point(246, 12)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(80, 24)
        Me.btnProcesar.TabIndex = 36
        Me.btnProcesar.Text = "Procesar"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(111, 16)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "Fecha de Proceso"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(136, 14)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(88, 20)
        Me.DateTimePicker1.TabIndex = 34
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(8, 56)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.ShowPrintButton = False
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1008, 640)
        Me.CrystalReportViewer1.TabIndex = 38
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(344, 12)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(80, 24)
        Me.btnSalir.TabIndex = 39
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'frmRepInter
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1024, 702)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.btnProcesar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Name = "frmRepInter"
        Me.Text = "Desglose de la Antigüedad de Saldos"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daFacturas As New SqlDataAdapter(cm1)
        Dim dsAgil As New DataSet()
        Dim drFactura As DataRow
        Dim dtAnexos As New DataTable()
        Dim dtReporte As New DataTable("Reporte")
        Dim drAnexo As DataRow
        Dim drReporte As DataRow

        ' Declaración de variables de datos

        Dim cAnexo As String
        Dim cFecha As String
        Dim cFeven As String
        Dim cNombre As String
        Dim cTipar As String
        Dim nCapitalEquipo As Decimal = 0
        Dim nCapitalSeguro As Decimal = 0
        Dim nInteres As Decimal
        Dim nIvaCapital As Decimal
        Dim nIvaInteres As Decimal
        Dim nOtrosAdeudos As Decimal
        Dim nPagado As Decimal
        Dim nPorieq As Decimal
        Dim nSaldoFac As Decimal
        Dim nSeguroVida As Decimal

        ' Declaración de variables de Crystal Reports

        Dim newrptRepInter As New rptRepInter()
        Dim cReportTitle As String

        cFecha = DTOC(DateTimePicker1.Value)


        ' Ahora creo la tabla Anexos que será la base del reporte

        dtAnexos.Columns.Add("Anexo", Type.GetType("System.String"))
        dtAnexos.Columns.Add("Tipar", Type.GetType("System.String"))
        dtAnexos.Columns.Add("Nombre", Type.GetType("System.String"))
        dtAnexos.Columns.Add("Feven", Type.GetType("System.String"))
        dtAnexos.Columns.Add("CapitalEquipo", Type.GetType("System.Decimal"))
        dtAnexos.Columns.Add("IvaCapital", Type.GetType("System.Decimal"))
        dtAnexos.Columns.Add("CapitalSeguro", Type.GetType("System.Decimal"))
        dtAnexos.Columns.Add("Interes", Type.GetType("System.Decimal"))
        dtAnexos.Columns.Add("IvaInteres", Type.GetType("System.Decimal"))
        dtAnexos.Columns.Add("OtrosAdeudos", Type.GetType("System.Decimal"))
        dtAnexos.Columns.Add("SeguroVida", Type.GetType("System.Decimal"))
        dtAnexos.Columns.Add("SaldoTotal", Type.GetType("System.Decimal"))

        ' Este Stored Procedure trae las facturas vencidas, el pago inicial (sin el 5% Nafin) 
        ' y la opción de compra exigible de los contratos activos o terminados con saldo en rentas

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Repantig1"
            .Connection = cnAgil
            .Parameters.Add("@Fecha", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        ' Llenar el DataSet a través del DataAdapter, lo cual abre y cierra la conexión

        Try
            daFacturas.Fill(dsAgil, "Facturas")
        Catch eException As Exception
            MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")
        End Try

        ' Ahora barro la tabla Facturas para determinar la antiguedad del saldo de cada factura
        ' y posicionarla en el lugar que le corresponda

        For Each drFactura In dsAgil.Tables("Facturas").Rows

            cAnexo = drFactura("Anexo")
            cTipar = drFactura("Tipar")
            cNombre = drFactura("Descr")
            cFeven = drFactura("Feven")
            nSaldoFac = drFactura("SaldoFac")
            nPorieq = drFactura("Porieq")
            nSeguroVida = drFactura("SeguroVida")
            nOtrosAdeudos = Round(drFactura("CapitalOt") + drFactura("InteresOt") + drFactura("VarOt") + drFactura("IvaOt"), 2)
            nIvaInteres = Round(drFactura("IvaPr") + drFactura("IvaSe"), 2)
            nInteres = Round(drFactura("IntPr") + drFactura("VarPr") + drFactura("IntSe") + drFactura("Varse"), 2)
            nCapitalEquipo = Round(drFactura("RenPr") - drFactura("IntPr") + drFactura("IvaCapital") - drFactura("Bonifica"), 2)
            nCapitalSeguro = drFactura("Rense")
            nPagado = drFactura("ImporteFac") - drFactura("SaldoFac")

            If nPagado >= nSeguroVida Then                  ' Alcanza a cubrir Seguro de Vida
                nPagado = nPagado - nSeguroVida
                nSeguroVida = 0
            Else                                            ' Cubre parcialmente el Seguro de Vida
                nSeguroVida = nSeguroVida - nPagado
                nPagado = 0
            End If

            If nPagado >= nOtrosAdeudos Then                ' Alcanza a cubrir Otros Adeudos
                nPagado = nPagado - nOtrosAdeudos
                nOtrosAdeudos = 0
            Else                                            ' Cubre parcialmente Otros Adeudos
                nOtrosAdeudos = nOtrosAdeudos - nPagado
                nPagado = 0
            End If

            If nPagado >= nIvaInteres Then                  ' Alcanza a cubrir el IVA de los intereses
                nPagado = nPagado - nIvaInteres
                nIvaInteres = 0
            Else                                            ' Cubre parcialmente el IVA de los intereses
                nIvaInteres = nIvaInteres - nPagado
                nPagado = 0
            End If

            If nPagado >= nInteres Then                     ' Alcanza a cubrir los intereses
                nPagado = nPagado - nInteres
                nInteres = 0
            Else
                nInteres = nInteres - nPagado               ' Cubre parcialmente los intereses
                nPagado = 0
            End If

            If nPagado >= nCapitalSeguro Then               ' Alcanza a cubrir el Seguro
                nPagado = nPagado - nCapitalSeguro
                nCapitalSeguro = 0
            Else
                nCapitalSeguro = nCapitalSeguro - nPagado   ' Cubre parcialmente el Seguro
                nPagado = 0
            End If

            If nPagado >= nCapitalEquipo Then               ' Alcanza a cubrir el Capital
                nPagado = nPagado - nCapitalEquipo
                nCapitalEquipo = 0
            Else
                nCapitalEquipo = nCapitalEquipo - nPagado   ' Cubre parcialmente el Capital
                nPagado = 0
            End If

            If nCapitalEquipo > 0 And drFactura("IvaCapital") > 0 Then
                nCapitalEquipo = Round(nCapitalEquipo / (1 + (nPorieq / 100)), 2)
                nIvaCapital = Round(nCapitalEquipo * nPorieq / 100, 2)
            Else
                nIvaCapital = 0
            End If

            nSaldoFac = drFactura("SaldoFac")

            ' Debe añadir el anexo en la tabla Anexos

            drAnexo = dtAnexos.NewRow()
            drAnexo("Anexo") = cAnexo
            drAnexo("Tipar") = cTipar
            drAnexo("Nombre") = cNombre
            drAnexo("Feven") = cFeven
            drAnexo("CapitalEquipo") = nCapitalEquipo
            drAnexo("IvaCapital") = nIvaCapital
            drAnexo("CapitalSeguro") = nCapitalSeguro
            drAnexo("Interes") = nInteres
            drAnexo("IvaInteres") = nIvaInteres
            drAnexo("OtrosAdeudos") = nOtrosAdeudos
            drAnexo("SeguroVida") = nSeguroVida
            drAnexo("SaldoTotal") = nSaldoFac
            dtAnexos.Rows.Add(drAnexo)

        Next

        dsAgil.Tables.Remove("Facturas")
        dsAgil.Tables.Add(dtAnexos)

        ' Descomentar la siguiente línea en caso de que se deseara modificar el reporte rptRepInter
        'dsAgil.WriteXml("C:\Schema24.xml", XmlWriteMode.WriteSchema)

        newrptRepInter.SetDataSource(dsAgil)

        cReportTitle = "DESGLOSE DE CARTERA EXIGIBLE AL " & Mes(cFecha)
        newrptRepInter.SummaryInfo.ReportTitle = cReportTitle

        CrystalReportViewer1.ReportSource = newrptRepInter

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class
