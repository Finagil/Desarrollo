Option Explicit On 

Imports System.Data.SqlClient

Public Class frmTablaEquipo

    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal cAnexo As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Text = "Tabla del Equipo Contrato " & cAnexo
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
        Me.txtAnexo.Location = New System.Drawing.Point(16, 8)
        Me.txtAnexo.Name = "txtAnexo"
        Me.txtAnexo.Size = New System.Drawing.Size(32, 20)
        Me.txtAnexo.TabIndex = 1
        Me.txtAnexo.Visible = False
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(8, 21)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1008, 675)
        Me.CrystalReportViewer1.TabIndex = 2
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'frmTablaEquipo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1022, 700)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.txtAnexo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "frmTablaEquipo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tabla del Equipo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub frmTablaEquipo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim dsAgil As New DataSet()
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim daTablaEquipo As New SqlDataAdapter(cm1)
        Dim daAnexo As New SqlDataAdapter(cm2)
        Dim drRegistro As DataRow
        Dim drAnexo As DataRow

        ' Declaración de variables de Crystal Reports

        Dim cReportTitle As String
        Dim cTipta As String
        Dim cTipar As String
        Dim cLeyenda As String
        Dim nRtasd As Integer
        Dim nImprd As Decimal
        Dim newrptTablaEquipo As New rptTablaEquipo()
        Dim newrptTablaEqdepo As New rptTablaEquipodep()
        Dim newrptTablaRefacc As New rptTablaRefacc()
        Dim newrptTablaPuro As New rptTablaPuro()

        ' Declaración de variables de datos

        Dim cAnexo As String

        cAnexo = Mid(txtAnexo.Text, 1, 5) & Mid(txtAnexo.Text, 7, 4)

        ' El siguiente Stored Procedure trae todos los atributos de la tabla Edoctav,
        ' para un anexo dado

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "TablaEquipo1"
            .Connection = cnAgil
            .Parameters.Add("@Anexo", SqlDbType.NVarChar)
            .Parameters(0).Value = cAnexo
        End With

        ' El siguiente Stored Procedure trae todos los atributos de la tabla Clientes,
        ' para un cliente dado.

        With cm2
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DatosCon1"
            .Connection = cnAgil
            .Parameters.Add("@Anexo", SqlDbType.NVarChar)
            .Parameters(0).Value = cAnexo
        End With

        ' Llenar el DataSet lo cual abre y cierra la conexión

        daTablaEquipo.Fill(dsAgil, "Edoctav")
        daAnexo.Fill(dsAgil, "Anexo")
        drRegistro = dsAgil.Tables("Edoctav").Rows(0)
        cTipta = drRegistro("Tipta")
        drAnexo = dsAgil.Tables("Anexo").Rows(0)
        nRtasd = drAnexo("Rtasd")
        nImprd = drAnexo("Imprd")
        cTipar = drAnexo("Tipar")

        ' Descomentar la siguiente línea cuando necesitemos modificar el reporte rptTablaEquipo
        ' dsAgil.WriteXml("C:\Schema5.xml", XmlWriteMode.WriteSchema)


        If cTipta = "7" Then
            cLeyenda = "Este documento no tiene ninguna validez legal ya que es sólo hipotética, "
            cLeyenda = cLeyenda & " ejemplificativa e ilustrativa, toda vez que para la elaboración de esta tabla"
            cLeyenda = cLeyenda & " se tomó como base los meses con 30 días, por lo que puede haber variación"
            cLeyenda = cLeyenda & " de acuerdo al número real de días que tenga cada mes."
        Else
            cLeyenda = "Este documento no tiene ninguna validez legal ya que es sólo hipotética, "
            cLeyenda = cLeyenda & "ejemplificativa e ilustrativa, por ser imposible conocer la variación de las "
            cLeyenda = cLeyenda & "tasas en el futuro, en consecuencia no implica obligación alguna para "
            cLeyenda = cLeyenda & "FINAGIL SA DE CV SOFOM ENR."
        End If

        If cTipar = "F" Then

            cReportTitle = Trim(drRegistro("Descr")) & Chr(13) & Chr(10) & "Arrendamiento Financiero No. " & txtAnexo.Text

            If nRtasd = 0 And nImprd > 0 Then

                ' Tabla de amortización con Bonificación por Depósito en Garantía

                newrptTablaEqdepo.SummaryInfo.ReportTitle = cReportTitle
                newrptTablaEqdepo.SummaryInfo.ReportComments = cLeyenda
                newrptTablaEqdepo.SetDataSource(dsAgil)
                CrystalReportViewer1.ReportSource = newrptTablaEqdepo

            Else

                ' Tabla de amortización sin Bonificación

                newrptTablaEquipo.SummaryInfo.ReportTitle = cReportTitle
                newrptTablaEquipo.SummaryInfo.ReportComments = cLeyenda
                newrptTablaEquipo.SetDataSource(dsAgil)
                CrystalReportViewer1.ReportSource = newrptTablaEquipo

            End If

        ElseIf cTipar = "P" Then
            cReportTitle = Trim(drRegistro("Descr")) & Chr(13) & Chr(10) & "Arrendamiento Puro No. " & txtAnexo.Text
            newrptTablaPuro.SummaryInfo.ReportTitle = cReportTitle
            newrptTablaPuro.SummaryInfo.ReportComments = cLeyenda
            newrptTablaPuro.SetDataSource(dsAgil)
            CrystalReportViewer1.ReportSource = newrptTablaPuro
        ElseIf cTipar = "R" Then
            cReportTitle = Trim(drRegistro("Descr")) & Chr(13) & Chr(10) & "Crédito Refaccionario No. " & txtAnexo.Text
            newrptTablaRefacc.SummaryInfo.ReportTitle = cReportTitle
            newrptTablaRefacc.SummaryInfo.ReportComments = cLeyenda
            newrptTablaRefacc.SetDataSource(dsAgil)
            CrystalReportViewer1.ReportSource = newrptTablaRefacc
        ElseIf cTipar = "S" Then
            cReportTitle = Trim(drRegistro("Descr")) & Chr(13) & Chr(10) & "Crédito Simple No. " & txtAnexo.Text
            newrptTablaRefacc.SummaryInfo.ReportTitle = cReportTitle
            newrptTablaRefacc.SummaryInfo.ReportComments = cLeyenda
            newrptTablaRefacc.SetDataSource(dsAgil)
            CrystalReportViewer1.ReportSource = newrptTablaRefacc
        End If

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()

    End Sub

End Class
