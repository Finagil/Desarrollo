Option Explicit On 

Imports System.Data.SqlClient
Imports CrystalDecisions.Shared

Public Class frmRepoProm

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
    Friend WithEvents lblPromotores As System.Windows.Forms.Label
    Friend WithEvents cbPromotores As System.Windows.Forms.ComboBox
    Friend WithEvents lblInicial As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFinal As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.btnProcesar = New System.Windows.Forms.Button
        Me.lblInicial = New System.Windows.Forms.Label
        Me.lblFinal = New System.Windows.Forms.Label
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.cbPromotores = New System.Windows.Forms.ComboBox
        Me.lblPromotores = New System.Windows.Forms.Label
        Me.btnSalir = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(464, 15)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(88, 20)
        Me.DateTimePicker1.TabIndex = 3
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(646, 15)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(88, 20)
        Me.DateTimePicker2.TabIndex = 5
        '
        'btnProcesar
        '
        Me.btnProcesar.Location = New System.Drawing.Point(760, 13)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(75, 24)
        Me.btnProcesar.TabIndex = 9
        Me.btnProcesar.Text = "Procesar"
        '
        'lblInicial
        '
        Me.lblInicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInicial.Location = New System.Drawing.Point(381, 17)
        Me.lblInicial.Name = "lblInicial"
        Me.lblInicial.Size = New System.Drawing.Size(80, 16)
        Me.lblInicial.TabIndex = 2
        Me.lblInicial.Text = "Fecha Inicial"
        '
        'lblFinal
        '
        Me.lblFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFinal.Location = New System.Drawing.Point(570, 17)
        Me.lblFinal.Name = "lblFinal"
        Me.lblFinal.Size = New System.Drawing.Size(73, 16)
        Me.lblFinal.TabIndex = 4
        Me.lblFinal.Text = "Fecha Final"
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(8, 56)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1008, 640)
        Me.CrystalReportViewer1.TabIndex = 10
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'cbPromotores
        '
        Me.cbPromotores.Location = New System.Drawing.Point(112, 15)
        Me.cbPromotores.Name = "cbPromotores"
        Me.cbPromotores.Size = New System.Drawing.Size(232, 21)
        Me.cbPromotores.TabIndex = 1
        '
        'lblPromotores
        '
        Me.lblPromotores.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPromotores.Location = New System.Drawing.Point(8, 17)
        Me.lblPromotores.Name = "lblPromotores"
        Me.lblPromotores.Size = New System.Drawing.Size(100, 16)
        Me.lblPromotores.TabIndex = 0
        Me.lblPromotores.Text = "Activaciones de"
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(859, 13)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 24)
        Me.btnSalir.TabIndex = 11
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'frmRepoProm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1024, 702)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.lblPromotores)
        Me.Controls.Add(Me.cbPromotores)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.lblFinal)
        Me.Controls.Add(Me.lblInicial)
        Me.Controls.Add(Me.btnProcesar)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Name = "frmRepoProm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Activaciones"
        Me.ResumeLayout(False)

    End Sub

#End Region

    ' Declaración de variables de Crystal Reports de alcance privado

    Dim newrptRepoProm As rptRepoProm

    Private Sub frmRepoProm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daPromotores As New SqlDataAdapter(cm1)
        Dim dsAgil As New DataSet()
        Dim drPromotor As DataRow
        Dim drPromotores As DataRowCollection

        ' El siguiente Stored Procedure trae el nombre de todos los promotores

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Promotores1"
            .Connection = cnAgil
        End With

        daPromotores.Fill(dsAgil, "Promotores")
        drPromotores = dsAgil.Tables("Promotores").Rows
        cbPromotores.Items.Add("CONTRATACION EN GENERAL")
        For Each drPromotor In drPromotores
            cbPromotores.Items.Add(drPromotor("DescPromotor"))
        Next
        cbPromotores.SelectedIndex = 0

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daAnexos As New SqlDataAdapter(cm1)
        Dim dsAgil As New DataSet()

        ' Declaración de variables de datos

        Dim cFechaInicio As String
        Dim cFechaFinal As String
        Dim cReportTitle As String
        Dim cReportComments As String

        cFechaInicio = DTOC(DateTimePicker1.Value)
        cFechaFinal = DTOC(DateTimePicker2.Value)

        newrptRepoProm = New rptRepoProm()

        If cbPromotores.SelectedIndex = 0 Then
            With cm1
                .CommandType = CommandType.StoredProcedure
                .CommandText = "RepoProm1"
                .Connection = cnAgil
                .Parameters.Add("@FechaInicio", SqlDbType.NVarChar)
                .Parameters(0).Value = cFechaInicio
                .Parameters.Add("@FechaFinal", SqlDbType.NVarChar)
                .Parameters(1).Value = cFechaFinal
            End With
        Else
            With cm1
                .CommandType = CommandType.StoredProcedure
                .CommandText = "RepoProm2"
                .Connection = cnAgil
                .Parameters.Add("@FechaInicio", SqlDbType.NVarChar)
                .Parameters(0).Value = cFechaInicio
                .Parameters.Add("@FechaFinal", SqlDbType.NVarChar)
                .Parameters(1).Value = cFechaFinal
                .Parameters.Add("@Promotor", SqlDbType.TinyInt)
                .Parameters(2).Value = cbPromotores.SelectedIndex
            End With
        End If

        'Llenar el DataSet a través del DataAdapter, lo cual abre y cierra la conexión

        Try

            daAnexos.Fill(dsAgil, "Anexos")
            ' Descomentar la siguiente línea en caso de que deseara modificarse el reporte rptRepoProm
            ' dsAgil.WriteXml("C:\Schema3.xml", XmlWriteMode.WriteSchema)

            cReportTitle = "REPORTE DE ACTIVACIONES DEL " & Mid(CTOD(cFechaInicio).ToString, 1, 10) & " AL " & Mid(CTOD(cFechaFinal).ToString, 1, 10)
            If cbPromotores.SelectedIndex = 0 Then
                cReportComments = "COLOCACIÓN GENERAL"
            Else
                cReportComments = "COLOCACIÓN DEL " & RTrim(cbPromotores.SelectedItem)
            End If
            newrptRepoProm.SetDataSource(dsAgil)
            newrptRepoProm.SummaryInfo.ReportTitle = cReportTitle
            newrptRepoProm.SummaryInfo.ReportComments = cReportComments
            CrystalReportViewer1.ReportSource = newrptRepoProm
        Catch eException As Exception
            MsgBox(eException.Source, MsgBoxStyle.Critical, eException.Message)
        End Try

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class
