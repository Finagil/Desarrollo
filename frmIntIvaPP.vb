Option Explicit On 

Imports System.Data.SqlClient

Public Class frmIntIvaPP

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
    Friend WithEvents dtpProceso As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnProcesar = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.dtpProceso = New System.Windows.Forms.DateTimePicker
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.btnSalir = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnProcesar
        '
        Me.btnProcesar.Location = New System.Drawing.Point(257, 12)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(80, 24)
        Me.btnProcesar.TabIndex = 30
        Me.btnProcesar.Text = "Procesar"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(24, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(113, 16)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Fecha de Proceso"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpProceso
        '
        Me.dtpProceso.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpProceso.Location = New System.Drawing.Point(144, 14)
        Me.dtpProceso.Name = "dtpProceso"
        Me.dtpProceso.Size = New System.Drawing.Size(88, 20)
        Me.dtpProceso.TabIndex = 28
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
        Me.CrystalReportViewer1.TabIndex = 31
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(361, 12)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(80, 24)
        Me.btnSalir.TabIndex = 32
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'frmIntIvaPP
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1024, 702)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.btnProcesar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dtpProceso)
        Me.Name = "frmIntIvaPP"
        Me.Text = "Integración de IVA por pagar"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daHistoria As New SqlDataAdapter(cm1)
        Dim dsAgil As New DataSet()
        Dim drHistoria As DataRow
        Dim dtReporte As New DataTable("Reporte")
        Dim drReporte As DataRow

        ' Declaración de variables de datos

        Dim cConcepto As String
        Dim cFecha As String = ""
        Dim cFechaFactura As String = ""
        Dim cLetra As String = ""
        Dim cSerie As String = ""
        Dim cTipar As String = ""
        Dim cTipoFinanciamiento As String = ""
        Dim nImp0001 As Decimal = 0
        Dim nImp0003 As Decimal = 0
        Dim nImp0004 As Decimal = 0
        Dim nImp0005 As Decimal = 0
        Dim nImp0006 As Decimal = 0
        Dim nImp0007 As Decimal = 0
        Dim nImp0008 As Decimal = 0
        Dim nImp0010 As Decimal = 0
        Dim nImp0014 As Decimal = 0
        Dim nImp0090 As Decimal = 0
        Dim nImporte As Decimal = 0

        ' Declaración de variables de Crystal Reports

        Dim newrptIntIvaPP As New rptIntIvaPP()

        cFecha = DTOC(dtpProceso.Value)

        ' Lo primero que hago es crear la tabla Reporte que será la base del reporte

        dtReporte.Columns.Add("Serie", Type.GetType("System.String"))
        dtReporte.Columns.Add("Factura", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("Fecha", Type.GetType("System.String"))
        dtReporte.Columns.Add("Anexo", Type.GetType("System.String"))
        dtReporte.Columns.Add("Letra", Type.GetType("System.String"))
        dtReporte.Columns.Add("Concepto", Type.GetType("System.String"))
        dtReporte.Columns.Add("c0001", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("c0003", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("c0004", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("c0005", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("c0006", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("c0007", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("c0008", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("c0010", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("c0014", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("c0090", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("TipoFinanciamiento", Type.GetType("System.String"))

        ' El siguiente Stored Procedure me trae todos los conceptos de IVA
        ' que aparezcan el la historia de pagos para un mes en específico

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "IntIvaPP1"
            .Connection = cnAgil
            .Parameters.Add("@Fecha", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        Try

            ' Llenar el DataSet lo cual abre y cierra la conexión

            daHistoria.Fill(dsAgil, "Historia")

            For Each drHistoria In dsAgil.Tables("Historia").Rows

                nImp0001 = 0
                nImp0003 = 0
                nImp0004 = 0
                nImp0005 = 0
                nImp0006 = 0
                nImp0007 = 0
                nImp0008 = 0
                nImp0010 = 0
                nImp0014 = 0
                nImp0090 = 0

                If cFecha <= "20110630" Then
                    cSerie = "A"
                Else
                    cSerie = drHistoria("Serie")
                End If

                cFechaFactura = drHistoria("Fecha")
                cLetra = drHistoria("Letra")
                cConcepto = Trim(drHistoria("Observa1"))
                nImporte = drHistoria("Importe")
                cTipar = drHistoria("Tipar")

                Select Case cTipar
                    Case "F"
                        cTipoFinanciamiento = "ARRENDAMIENTO FINANCIERO"
                    Case "P"
                        cTipoFinanciamiento = "ARRENDAMIENTO PURO"
                    Case "R"
                        cTipoFinanciamiento = "CREDITO REFACCIONARIO"
                    Case "S"
                        cTipoFinanciamiento = "CREDITO SIMPLE"
                    Case "H"
                        cTipoFinanciamiento = "CREDITO DE AVIO"
                    Case Else
                        cTipoFinanciamiento = "*** INDETERMINADO ***"
                End Select

                drReporte = dtReporte.NewRow

                drReporte("Serie") = cSerie
                drReporte("Factura") = drHistoria("Numero")
                drReporte("Fecha") = cFechaFactura
                drReporte("Anexo") = drHistoria("Anexo")
                drReporte("Letra") = cLetra
                drReporte("Concepto") = cConcepto
                If cTipar = "H" Then
                    nImp0014 = nImporte
                Else
                    Select Case cConcepto
                        Case "IVA CAPITAL", "IVA DE LA AMORTIZACION", "IVA DEL CAPITAL EQUIPO", "IVA DEL SALDO INSOLUTO"
                            nImp0001 = nImporte
                        Case "IVA INTERESES"
                            If cLetra <> "888" Then
                                nImp0003 = nImporte
                            Else
                                nImp0090 = nImporte
                            End If
                        Case "IVA RENTA EN DEPOSITO", "IVA EN DEPOSITO", "APLICACION IVA RENTAS EN DEPOSITO"
                            nImp0004 = nImporte
                        Case "IVA DE LA COMISION", "IVA DE COMISION POR PREPAGO", "IVA COMISION POR ADELANTO"
                            nImp0005 = nImporte
                        Case "IVA GASTOS RATIFICACION"
                            nImp0006 = nImporte
                        Case "IVA MORATORIOS"
                            nImp0007 = nImporte
                        Case "IVA OPCION DE COMPRA"
                            nImp0008 = nImporte
                        Case "IVA DEL DEPOSITO", "APLICACION DEPOSITO vs IVA CAPITAL", "APLICACION IVA DEPOSITO EN GARANTIA"
                            nImp0010 = nImporte
                        Case "IVA DE INTERESES POR PREPAGO", "IVA INTERES OTROS ADEUDOS"
                            nImp0090 = nImporte
                    End Select
                End If
                drReporte("c0001") = nImp0001
                drReporte("c0003") = nImp0003
                drReporte("c0004") = nImp0004
                drReporte("c0005") = nImp0005
                drReporte("c0006") = nImp0006
                drReporte("c0007") = nImp0007
                drReporte("c0008") = nImp0008
                drReporte("c0010") = nImp0010
                drReporte("c0014") = nImp0014
                drReporte("c0090") = nImp0090
                drReporte("TipoFinanciamiento") = cTipoFinanciamiento
                dtReporte.Rows.Add(drReporte)
            Next

            dsAgil.Tables.Remove("Historia")
            dsAgil.Tables.Add(dtReporte)

            ' Descomentar la siguiente línea en caso de que se deseara modificar el reporte rptIntIvaPP
            ' dsAgil.WriteXml("C:\Schema18.xml", XmlWriteMode.WriteSchema)
            newrptIntIvaPP.SetDataSource(dsAgil)
            CrystalReportViewer1.ReportSource = newrptIntIvaPP

        Catch eException As Exception

            MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")

        End Try

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class
