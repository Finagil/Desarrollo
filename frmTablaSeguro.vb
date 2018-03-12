Option Explicit On 

Imports System.Data.SqlClient

Public Class frmTablaSeguro

    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal cAnexo As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Text = "Tabla del Seguro Contrato " & cAnexo
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
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents txtAnexo As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.txtAnexo = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(8, 34)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1008, 662)
        Me.CrystalReportViewer1.TabIndex = 3
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'txtAnexo
        '
        Me.txtAnexo.Location = New System.Drawing.Point(32, 8)
        Me.txtAnexo.Name = "txtAnexo"
        Me.txtAnexo.Size = New System.Drawing.Size(24, 20)
        Me.txtAnexo.TabIndex = 4
        Me.txtAnexo.Visible = False
        '
        'frmTablaSeguro
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1024, 702)
        Me.Controls.Add(Me.txtAnexo)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Name = "frmTablaSeguro"
        Me.Text = "Tabla del Seguro"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub frmTablaSeguro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daTablaSeguro As New SqlDataAdapter(cm1)
        Dim dsAgil As New DataSet()
        Dim drRegistro As DataRow

        ' Declaración de variables de datos

        Dim cAnexo As String

        ' Declaración de variables de Crystal Reports

        Dim cReportComments As String
        Dim cReportTitle As String
        Dim newrptTablaSeguro As New rptTablaSeguro()

        cAnexo = Mid(txtAnexo.Text, 1, 5) & Mid(txtAnexo.Text, 7, 4)

        ' El siguiente Stored Procedure trae todos los atributos de la tabla Edoctas,
        ' para un anexo dado

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "TablaSeguro1"
            .Connection = cnAgil
            .Parameters.Add("@Anexo", SqlDbType.NVarChar)
            .Parameters(0).Value = cAnexo
        End With

        ' Llenar el DataSet lo cual abre y cierra la conexión

        daTablaSeguro.Fill(dsAgil, "Edoctas")
        drRegistro = dsAgil.Tables("Edoctas").Rows(0)
        cReportComments = Trim(drRegistro("Descr"))

        ' Descomentar la siguiente línea cuando necesitemos modificar el reporte rptTablaSeguro
        ' dsAgil.WriteXml("C:\Schema9.xml", XmlWriteMode.WriteSchema)

        cReportTitle = "CONTRATO " & txtAnexo.Text
        newrptTablaSeguro.SummaryInfo.ReportTitle = cReportTitle
        newrptTablaSeguro.SummaryInfo.ReportComments = cReportComments
        newrptTablaSeguro.SetDataSource(dsAgil)

        CrystalReportViewer1.ReportSource = newrptTablaSeguro

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

End Class
