Option Explicit On 

Imports System.Data.SqlClient
Imports CrystalDecisions.Shared

Public Class frmRelaFact
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
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.btnProcesar = New System.Windows.Forms.Button
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(160, 16)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(88, 20)
        Me.DateTimePicker1.TabIndex = 20
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(32, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(122, 20)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Fecha de Proceso"
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(16, 56)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.ShowPrintButton = False
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(992, 640)
        Me.CrystalReportViewer1.TabIndex = 22
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'btnProcesar
        '
        Me.btnProcesar.Location = New System.Drawing.Point(296, 14)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(72, 24)
        Me.btnProcesar.TabIndex = 23
        Me.btnProcesar.Text = "Procesar"
        '
        'btnPrint
        '
        Me.btnPrint.Enabled = False
        Me.btnPrint.Location = New System.Drawing.Point(400, 14)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(72, 24)
        Me.btnPrint.TabIndex = 24
        Me.btnPrint.Text = "Imprimir"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(504, 14)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(72, 24)
        Me.btnExit.TabIndex = 25
        Me.btnExit.Text = "Salir"
        '
        'frmRelaFact
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1024, 702)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnProcesar)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Name = "frmRelaFact"
        Me.Text = "Relación de Facturación para Mensajería"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim newrptRelaFact As rptRelaFact

    Private Sub btnProcesar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProcesar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim dsAgil As New DataSet()
        Dim dsReporte As New DataSet()
        Dim daRelacion As New SqlDataAdapter(cm1)
        Dim daFacturas As New SqlDataAdapter(cm2)
        Dim relClienteFact As DataRelation
        Dim dtReporte As New DataTable("Facturas")
        Dim drDato As DataRow
        Dim drTemp As DataRow
        Dim drCliente As DataRow
        Dim drFactu As DataRow()
        Dim drDatos As DataRowCollection
   
        ' Declaración de variables de datos

        Dim cFecha As String
        Dim cReportTitle As String
        Dim i As Byte

        cFecha = DTOC(DateTimePicker1.Value)

        ' Este Stored Procedure trae toda la información de Facturas y Clientes para poder
        ' elaborar el reporte

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "RelaFact1"
            .Connection = cnAgil
            .Parameters.Add("@Fecha", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        With cm2
            .CommandType = CommandType.StoredProcedure
            .CommandText = "RelaFact"
            .Connection = cnAgil
            .Parameters.Add("@Fecha", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        daRelacion.Fill(dsAgil, "Clientes")
        daFacturas.Fill(dsAgil, "Avisos")

        ' Establecer la relación entre Anexos y Edoctav

        relClienteFact = New DataRelation("ClienteFact", dsAgil.Tables("Clientes").Columns("Cte"), dsAgil.Tables("Avisos").Columns("Cte"))
        dsAgil.EnforceConstraints = False
        dsAgil.Relations.Add(relClienteFact)

        If dsAgil.Tables("Clientes").Rows.Count > 0 Then

            ' Creamos la Tabla donde almaceno los datos que formarán parte del reporte final

            dtReporte.Columns.Add("Factura", Type.GetType("System.String"))
            dtReporte.Columns.Add("Descr", Type.GetType("System.String"))
            dtReporte.Columns.Add("Calle", Type.GetType("System.String"))
            dtReporte.Columns.Add("Colonia", Type.GetType("System.String"))
            dtReporte.Columns.Add("Delegacion", Type.GetType("System.String"))
            dtReporte.Columns.Add("Copos", Type.GetType("System.String"))
            dtReporte.Columns.Add("DescPlaza", Type.GetType("System.String"))
            dtReporte.Columns.Add("Telef1", Type.GetType("System.String"))
   
            drDatos = dsAgil.Tables("Clientes").Rows

            For Each drDato In drDatos
                drFactu = drDato.GetChildRows("ClienteFact")
                i = 0
                For Each drTemp In drFactu
                    If i = 0 Then
                        drCliente = dtReporte.NewRow()
                        drCliente("Factura") = drTemp("Factura")
                        drCliente("Descr") = drTemp("Descr")
                        drCliente("Calle") = drTemp("Calle")
                        drCliente("Colonia") = drTemp("Colonia")
                        drCliente("Delegacion") = drTemp("Delegacion")
                        drCliente("Copos") = drTemp("Copos")
                        drCliente("DescPlaza") = drTemp("DescPlaza")
                        drCliente("Telef1") = drTemp("Telef1")
                        dtReporte.Rows.Add(drCliente)
                        i = 1
                    End If
                Next
            Next
            dsAgil.Relations.Clear()
            dsAgil.Tables("Clientes").Constraints.Clear()
            dsAgil.Tables("Avisos").Constraints.Clear()
            dsAgil.Tables.Remove("Clientes")
            dsAgil.Tables.Remove("Avisos")
            dsAgil.Tables.Add(dtReporte)

            dsAgil.WriteXml("C:\Schema32.xml", XmlWriteMode.WriteSchema)

            cReportTitle = "RELACION DE FACTURACION PARA MENSAJERIA AL " & CTOD(cFecha)
            newrptRelaFact = New rptRelaFact()
            newrptRelaFact.SummaryInfo.ReportTitle = cReportTitle
            CrystalReportViewer1.ReportSource = newrptRelaFact
        Else
            MsgBox("NO existe información de la fecha solicitada", MsgBoxStyle.Information, "Mensaje")
        End If

        cnAgil = Nothing
        cm1 = Nothing
        cm2 = Nothing
        btnPrint.Enabled = True

    End Sub

    Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        newrptRelaFact.PrintOptions.PaperOrientation = PaperOrientation.Landscape
        newrptRelaFact.PrintToPrinter(1, False, 0, 0)
        MsgBox("Reporte Impreso", MsgBoxStyle.Information, "Mensaje")
    End Sub

    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

End Class
