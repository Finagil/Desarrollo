Option Explicit On 

Imports System.Data.SqlClient
Imports System.Math
Imports CrystalDecisions.Shared

Public Class frmHistoria

    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal cAnexo As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Text = "Historia de pagos del Contrato " & cAnexo
        txtAnexo.Text = cAnexo
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
    Friend WithEvents txtAnexo As System.Windows.Forms.TextBox
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtAnexo = New System.Windows.Forms.TextBox
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'txtAnexo
        '
        Me.txtAnexo.Location = New System.Drawing.Point(12, 6)
        Me.txtAnexo.Name = "txtAnexo"
        Me.txtAnexo.Size = New System.Drawing.Size(62, 20)
        Me.txtAnexo.TabIndex = 25
        Me.txtAnexo.Visible = False
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(8, 12)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1008, 684)
        Me.CrystalReportViewer1.TabIndex = 29
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'frmHistoria
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1024, 702)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.txtAnexo)
        Me.Name = "frmHistoria"
        Me.Text = "Historia de Pagos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub frmHistoria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim daHistoria As New SqlDataAdapter(cm1)
        Dim daFacturas As New SqlDataAdapter(cm2)
        Dim dsAgil As New DataSet()
        Dim drHistoria As DataRow
        Dim drFactura As DataRow
        Dim drPago As DataRow
        Dim drPagos As DataRow()
        Dim dtHistoria As New DataTable("Historia")
        Dim dtTemporal As New DataTable()

        'Declaración de variables de datos

        Dim cAnexo As String
        Dim cCusnam As String
        Dim cFecha As String
        Dim cTempFec As String
        Dim i As Integer
        Dim nBalance As Decimal
        Dim nDocumento As Byte
        Dim nPlazo As Byte

        ' Declaración de variables de Crystal Reports

        Dim newrptHistoria As New rptHistoria()
        Dim cReportTitle As String
        Dim cReportComments As String

        cAnexo = Mid(txtAnexo.Text, 1, 5) & Mid(txtAnexo.Text, 7, 4)
        cFecha = DTOC(Now())

        ' Defino Tabla dtHistoria para guardar datos de Historia de pagos

        dtHistoria.Columns.Add("Fecha", Type.GetType("System.String"))
        dtHistoria.Columns.Add("Concepto", Type.GetType("System.String"))
        dtHistoria.Columns.Add("Cargo", Type.GetType("System.Decimal"))
        dtHistoria.Columns.Add("Abono", Type.GetType("System.Decimal"))
        dtHistoria.Columns.Add("Balance", Type.GetType("System.Decimal"))
        dtHistoria.Columns.Add("Documento", Type.GetType("System.String"))
        dtHistoria.Columns.Add("Cheque", Type.GetType("System.String"))
        dtHistoria.Columns.Add("Depositado", Type.GetType("System.String"))
        dtHistoria.Columns.Add("Ven", Type.GetType("System.String"))

        ' Defino Tabla dtTemporal para guardar datos de Historia de pagos

        dtTemporal.Columns.Add("Fecha", Type.GetType("System.String"))
        dtTemporal.Columns.Add("Concepto", Type.GetType("System.String"))
        dtTemporal.Columns.Add("Cargo", Type.GetType("System.Decimal"))
        dtTemporal.Columns.Add("Abono", Type.GetType("System.Decimal"))
        dtTemporal.Columns.Add("Balance", Type.GetType("System.Decimal"))
        dtTemporal.Columns.Add("Documento", Type.GetType("System.String"))
        dtTemporal.Columns.Add("Cheque", Type.GetType("System.String"))
        dtTemporal.Columns.Add("Depositado", Type.GetType("System.String"))
        dtTemporal.Columns.Add("Ven", Type.GetType("System.String"))

        ' Este Stored Procedure obtiene todos los pagos realizados a un anexo

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Historia1"
            .Connection = cnAgil
            .Parameters.Add("@Anexo", SqlDbType.NVarChar)
            .Parameters(0).Value = cAnexo
        End With

        ' El siguiente Stored Procedure trae todas las Facturas generadas para un anexo

        With cm2
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Historia2"
            .Connection = cnAgil
            .Parameters.Add("@Anexo", SqlDbType.NVarChar)
            .Parameters(0).Value = cAnexo
            .Parameters.Add("@Fecha", SqlDbType.NVarChar)
            .Parameters(1).Value = cFecha
        End With

        ' El siguiente comando me regresa el nombre del cliente

        With cm3
            .CommandType = CommandType.Text
            .CommandText = "SELECT Descr FROM Clientes INNER JOIN Anexos ON Clientes.Cliente = Anexos.Cliente WHERE Anexo = '" & cAnexo & "'"
            .Connection = cnAgil
        End With

        ' Llenar el dataset lo cual abre y cierra la conexión

        daHistoria.Fill(dsAgil, "Historia")
        daFacturas.Fill(dsAgil, "Facturas")

        cnAgil.Open()
        cCusnam = cm3.ExecuteScalar()
        cnAgil.Close()

        For Each drFactura In dsAgil.Tables("Facturas").Rows
            drHistoria = dtHistoria.NewRow()
            drHistoria("Fecha") = drFactura("Feven")
            drHistoria("Concepto") = "Aviso de vencimiento No. " & drFactura("Factura")
            drHistoria("Cargo") = drFactura("Importefac")
            drHistoria("Abono") = 0
            drHistoria("Balance") = 0
            drHistoria("Documento") = "Aviso No. " & drFactura("Factura")
            drHistoria("Cheque") = " "
            drHistoria("Depositado") = " "
            drHistoria("Ven") = drFactura("Letra")
            dtHistoria.Rows.Add(drHistoria)
        Next

        For Each drPago In dsAgil.Tables("Historia").Rows
            drHistoria = dtHistoria.NewRow()
            drHistoria("Fecha") = drPago("Fecha")
            drHistoria("Concepto") = drPago("Observa1")
            If drPago("Balance") = "N" Then
                drHistoria("Cargo") = drPago("Importe")
                drHistoria("Abono") = drPago("Importe")
            Else
                drHistoria("Cargo") = 0
                drHistoria("Abono") = drPago("Importe")
            End If
            drHistoria("Balance") = 0
            nDocumento = drPago("Documento")
            Select Case nDocumento
                Case 1
                    drHistoria("Documento") = "Nota de Cargo No. " & drPago("Numero")
                Case 2
                    drHistoria("Documento") = "Recibo de caja No. " & drPago("Numero")
                Case 4
                    drHistoria("Documento") = "Cargo Interno "
                Case 5
                    drHistoria("Documento") = "Abono Interno "
                Case 6
                    drHistoria("Documento") = "Factura de pago No. " & drPago("Numero")
                Case 7
                    drHistoria("Documento") = "Factura de Activo Fijo"
            End Select
            drHistoria("Cheque") = drPago("Cheque")
            drHistoria("Depositado") = drPago("DescBanco")
            drHistoria("Ven") = drPago("Letra")
            dtHistoria.Rows.Add(drHistoria)
        Next

        ' Aquí tengo que ordenar la tabla dtHistoria de acuerdo a la fecha del movimiento
        ' dejándola en la tabla dtTemporal

        drPagos = dtHistoria.Select(True, "Fecha, Documento")

        For Each drPago In drPagos
            dtTemporal.ImportRow(drPago)
        Next

        ' Enseguida copio la tabla dtTemporal en dtHistoria y elimino los registros de dtTemporal,
        ' al mismo tiempo que modifico su estructura para que no sea idéntica a la de dtHistoria

        dtHistoria = dtTemporal.Copy()
        dtTemporal.Clear()
        dtTemporal.Columns.Remove("Ven")
        dtTemporal.Columns.Add("Vencimiento", Type.GetType("System.String"))

        ' Ahora barro la tabla dtHistoria para determinar el balance después de cada movimiento

        nBalance = 0

        For Each drPago In dtHistoria.Rows

            nBalance = nBalance + drPago("Cargo")
            nBalance = nBalance - drPago("Abono")

            drHistoria = dtTemporal.NewRow()
            drHistoria("Fecha") = drPago("Fecha")
            drHistoria("Concepto") = drPago("Concepto")
            drHistoria("Cargo") = drPago("Cargo")
            drHistoria("Abono") = drPago("Abono")
            drHistoria("Balance") = Round(nBalance, 2)
            drHistoria("Documento") = drPago("Documento")
            drHistoria("Cheque") = drPago("Cheque")
            drHistoria("Depositado") = drPago("Depositado")
            drHistoria("Vencimiento") = drPago("Ven")
            dtTemporal.Rows.Add(drHistoria)

        Next

        dtHistoria = dtTemporal.Copy()

        dsAgil.Relations.Clear()
        dsAgil.Tables("Historia").Constraints.Clear()
        dsAgil.Tables("Facturas").Constraints.Clear()
        dsAgil.Tables.Remove("Historia")
        dsAgil.Tables.Remove("Facturas")
        dsAgil.Tables.Add(dtHistoria)

        ' Descomentar la siguiente línea en caso de que desee modificarse el reporte rptHistoria
        ' dsAgil.WriteXml("C:\Schema13.xml", XmlWriteMode.WriteSchema)

        cReportTitle = "HISTORIA DE PAGOS DEL CONTRATO " & txtAnexo.Text & " AL " & Mes(cFecha)
        cReportComments = Trim(cCusnam)

        newrptHistoria.SummaryInfo.ReportTitle = cReportTitle
        newrptHistoria.SummaryInfo.ReportComments = cReportComments

        newrptHistoria.SetDataSource(dsAgil)

        CrystalReportViewer1.ReportSource = newrptHistoria

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()
        cm3.Dispose()

    End Sub

End Class
