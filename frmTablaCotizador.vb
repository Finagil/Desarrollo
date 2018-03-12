Public Class frmTablaCotizador

    ' Declaración de variables de Crystal Reports de alcance privado

    Dim newrptTablaCotizador As New rptTablaCotizador

    Public Sub New(ByVal cReportTitle As String, ByVal cReportComments As String, ByVal cTitulo As String, ByVal dsImprimir As DataSet)

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Text = cTitulo
        newrptTablaCotizador.SetDataSource(dsImprimir)
        newrptTablaCotizador.SummaryInfo.ReportTitle = cReportTitle
        newrptTablaCotizador.SummaryInfo.ReportComments = cReportComments
        CrystalReportViewer1.ReportSource = newrptTablaCotizador

    End Sub

End Class