Option Explicit On

Imports System.Data.SqlClient

Public Class frmTablaOtros

    Public Sub New(ByVal cAnexo As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Text = "Tabla de Otros Adeudos Contrato " & cAnexo
        txtAnexo.Text = cAnexo
    End Sub

    Private Sub frmTablaOtros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim dsAgil As New DataSet()
        Dim cm1 As New SqlCommand()
        Dim daTablaOtros As New SqlDataAdapter(cm1)
        Dim drRegistro As DataRow
        
        ' Declaración de variables de datos

        Dim cAnexo As String

        ' Declaración de variables de Crystal Reports

        Dim cReportComments As String
        Dim cReportTitle As String
        Dim newrptTablaOtros As New rptTablaOtros()
       
        cAnexo = Mid(txtAnexo.Text, 1, 5) & Mid(txtAnexo.Text, 7, 4)

        ' El siguiente Stored Procedure trae todos los atributos de la tabla Edoctao,
        ' para un anexo dado

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "TraeAdeudos"
            .Connection = cnAgil
            .Parameters.Add("@Anexo", SqlDbType.NVarChar)
            .Parameters(0).Value = cAnexo
        End With

        ' Llenar el DataSet lo cual abre y cierra la conexión

        daTablaOtros.Fill(dsAgil, "Edoctao")
        drRegistro = dsAgil.Tables("Edoctao").Rows(0)
        cReportComments = Trim(drRegistro("Descr"))

        ' Descomentar la siguiente línea cuando necesitemos modificar el reporte rptTablaEquipo
        'dsAgil.WriteXml("C:\Schema44.xml", XmlWriteMode.WriteSchema)

        cReportTitle = "CONTRATO " & txtAnexo.Text

        newrptTablaOtros.SummaryInfo.ReportTitle = cReportTitle
        newrptTablaOtros.SummaryInfo.ReportComments = cReportComments
        newrptTablaOtros.SetDataSource(dsAgil)

        CrystalReportViewer1.ReportSource = newrptTablaOtros

        cnAgil = Nothing
        cm1 = Nothing

    End Sub
End Class