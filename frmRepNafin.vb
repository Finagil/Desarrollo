Option Explicit On 

Imports System.Data.SqlClient
Imports System.Math
Imports CrystalDecisions.Shared

Public Class frmRepNafin
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
    Friend WithEvents btnProceso As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPagare As System.Windows.Forms.TextBox
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents CrystalReportViewer2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.txtPagare = New System.Windows.Forms.TextBox
        Me.btnProceso = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnImprimir = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.CrystalReportViewer2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.btnSalir = New System.Windows.Forms.Button
        Me.btnProcesar = New System.Windows.Forms.Button
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton3 = New System.Windows.Forms.RadioButton
        Me.SuspendLayout()
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(128, 16)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(88, 20)
        Me.DateTimePicker1.TabIndex = 27
        '
        'txtPagare
        '
        Me.txtPagare.Location = New System.Drawing.Point(352, 16)
        Me.txtPagare.MaxLength = 2
        Me.txtPagare.Name = "txtPagare"
        Me.txtPagare.Size = New System.Drawing.Size(24, 20)
        Me.txtPagare.TabIndex = 28
        '
        'btnProceso
        '
        Me.btnProceso.Location = New System.Drawing.Point(424, 16)
        Me.btnProceso.Name = "btnProceso"
        Me.btnProceso.Size = New System.Drawing.Size(80, 24)
        Me.btnProceso.TabIndex = 29
        Me.btnProceso.Text = "Procesar"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(24, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 16)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Fecha del proceso"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(264, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "No. de Pagaré"
        '
        'btnImprimir
        '
        Me.btnImprimir.Enabled = False
        Me.btnImprimir.Location = New System.Drawing.Point(536, 16)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(80, 24)
        Me.btnImprimir.TabIndex = 33
        Me.btnImprimir.Text = "Imprimir"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(648, 16)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(72, 24)
        Me.btnExit.TabIndex = 34
        Me.btnExit.Text = "Salir"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(24, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 16)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Fecha del proceso"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(128, 14)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(88, 20)
        Me.DateTimePicker2.TabIndex = 31
        '
        'CrystalReportViewer2
        '
        Me.CrystalReportViewer2.ActiveViewIndex = -1
        Me.CrystalReportViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer2.DisplayGroupTree = False
        Me.CrystalReportViewer2.Location = New System.Drawing.Point(16, 56)
        Me.CrystalReportViewer2.Name = "CrystalReportViewer2"
        Me.CrystalReportViewer2.SelectionFormula = ""
        Me.CrystalReportViewer2.ShowGroupTreeButton = False
        Me.CrystalReportViewer2.ShowPrintButton = False
        Me.CrystalReportViewer2.Size = New System.Drawing.Size(992, 632)
        Me.CrystalReportViewer2.TabIndex = 33
        Me.CrystalReportViewer2.ViewTimeSelectionFormula = ""
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(610, 12)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(72, 24)
        Me.btnSalir.TabIndex = 35
        Me.btnSalir.Text = "Salir"
        '
        'btnProcesar
        '
        Me.btnProcesar.Location = New System.Drawing.Point(524, 12)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(80, 24)
        Me.btnProcesar.TabIndex = 36
        Me.btnProcesar.Text = "Procesar"
        '
        'RadioButton1
        '
        Me.RadioButton1.Location = New System.Drawing.Point(241, 12)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(68, 24)
        Me.RadioButton1.TabIndex = 37
        Me.RadioButton1.Text = "NAFIN"
        '
        'RadioButton2
        '
        Me.RadioButton2.Location = New System.Drawing.Point(319, 12)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(65, 24)
        Me.RadioButton2.TabIndex = 38
        Me.RadioButton2.Text = "FIRA"
        '
        'RadioButton3
        '
        Me.RadioButton3.Location = New System.Drawing.Point(390, 12)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(135, 24)
        Me.RadioButton3.TabIndex = 39
        Me.RadioButton3.Text = "PARAFINANCIERA"
        '
        'frmRepNafin
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1024, 702)
        Me.Controls.Add(Me.RadioButton3)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.btnProcesar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.CrystalReportViewer2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Name = "frmRepNafin"
        Me.Text = "Reporte de Contratos Fondeados con NAFIN o FIRA"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim cReportTitle As String
    Dim cSubTitle As String
    Dim newrptRepNafin As rptRepNafin

    Private Sub btnProcesar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProcesar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim dsAgil As New DataSet()
        Dim dsReporte As New DataSet()
        Dim daAnexos As New SqlDataAdapter(cm1)
        Dim daEdoctav As New SqlDataAdapter(cm2)
        Dim dtReporte As New DataTable("Reporte")
        Dim drAnexo As DataRow
        Dim drEdoctav As DataRow()
        Dim drAmortiza As DataRow
        Dim drReporte As DataRow
        Dim relAnexoEdoctav As DataRelation

        ' Declaración de variables de datos

        Dim cAnexo As String
        Dim cCusnam As String
        Dim cFecha As String
        Dim cFeven As String
        Dim cFondeo As String
        Dim cTipoFondeo As String
        Dim nPlazo As Integer
        Dim nAmortizacion As Decimal
        Dim nSaldoEquipo As Decimal
        Dim nInteresEquipo As Decimal
        Dim nCarteraEquipo As Decimal

        cFecha = DTOC(DateTimePicker2.Value)

        ' Primero creo la tabla Reporte que será la base del reporte

        dtReporte.Columns.Add("Contrato", Type.GetType("System.String"))
        dtReporte.Columns.Add("Cliente", Type.GetType("System.String"))
        dtReporte.Columns.Add("Vencimiento", Type.GetType("System.String"))
        dtReporte.Columns.Add("SaldoEquipo", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("Amortizacion", Type.GetType("System.Decimal"))

        ' Este Stored Procedure trae todos los contratos activos con fecha de contratación menor o igual
        ' a la de proceso

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "GeneProv1"
            .Connection = cnAgil
            .Parameters.Add("@FechaFin", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        ' Este Stored Procedure trae la tabla de amortización del equipo de todos los contratos activos
        ' con fecha de contratación menor o igual a la de proceso

        With cm2
            .CommandType = CommandType.StoredProcedure
            .CommandText = "GeneProv2"
            .Connection = cnAgil
            .Parameters.Add("@FechaFin", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        ' Llenar el DataSet a través del DataAdapter, lo cual abre y cierra la conexión

        daAnexos.Fill(dsAgil, "Anexos")
        daEdoctav.Fill(dsAgil, "Edoctav")

        ' Establecer la relación entre Anexos y Edoctav

        relAnexoEdoctav = New DataRelation("AnexoEdoctav", dsAgil.Tables("Anexos").Columns("Anexo"), dsAgil.Tables("Edoctav").Columns("Anexo"))
        dsAgil.EnforceConstraints = False
        dsAgil.Relations.Add(relAnexoEdoctav)

        If dsAgil.Tables("Anexos").Rows.Count > 0 Then

            If RadioButton1.Checked = True Then
                cTipoFondeo = "02"
            ElseIf RadioButton2.Checked = True Then
                cTipoFondeo = "03"
            ElseIf RadioButton3.Checked = True Then
                cTipoFondeo = "04"
            End If


         
            For Each drAnexo In dsAgil.Tables("Anexos").Rows

                If drAnexo("Fondeo") = cTipoFondeo Then

                    cAnexo = drAnexo("Anexo")
                    cCusnam = Mid(drAnexo("Descr"), 1, 40)
                    nPlazo = drAnexo("Plazo")
                    cFondeo = drAnexo("Fondeo")

                    ' Se trata de un contrato que NO está vencido (no tiene rentas vencidas a más de 89 días)

                    nSaldoEquipo = 0
                    nInteresEquipo = 0
                    nCarteraEquipo = 0

                    ' Esta instrucción trae la tabla de amortización del Equipo única y exclusivamente del contrato
                    ' que está siendo procesado

                    drEdoctav = drAnexo.GetChildRows("AnexoEdoctav")
                    TraeSald(drEdoctav, cFecha, nSaldoEquipo, nInteresEquipo, nCarteraEquipo)

                    For Each drAmortiza In drEdoctav
                        If Mid(drAmortiza("Feven"), 1, 6) = Mid(cFecha, 1, 6) Then
                            cFeven = drAmortiza("Feven")
                            nAmortizacion = drAmortiza("Abcap")
                        End If
                    Next

                    ' En este reporte solo deben incluirse los contratos de Arrendamiento Financiero

                    If nSaldoEquipo > 0 Then
                        drReporte = dtReporte.NewRow()
                        drReporte("Contrato") = Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 6, 4)
                        drReporte("Cliente") = cCusnam
                        drReporte("Vencimiento") = cFeven
                        drReporte("SaldoEquipo") = nSaldoEquipo
                        drReporte("Amortizacion") = nAmortizacion
                        dtReporte.Rows.Add(drReporte)

                    End If

                End If

            Next

            dsAgil.Relations.Clear()
            dsAgil.Tables("Anexos").Constraints.Clear()
            dsAgil.Tables("Edoctav").Constraints.Clear()
            dsAgil.Tables.Remove("Anexos")
            dsAgil.Tables.Remove("Edoctav")
            dsAgil.Tables.Add(dtReporte)

            dsAgil.WriteXml("C:\Schema30.xml", XmlWriteMode.WriteSchema)

            If RadioButton1.Checked = True Then
                cReportTitle = "REPORTE DE SALDOS INSOLUTOS Y AMORTIZACION DE CONTRATOS FONDEADOS POR NAFIN AL " & CTOD(cFecha)
            ElseIf RadioButton2.Checked = True Then
                cReportTitle = "REPORTE DE SALDOS INSOLUTOS Y AMORTIZACION DE CONTRATOS FONDEADOS POR FIRA AL " & CTOD(cFecha)
            ElseIf RadioButton3.Checked = True Then
                cReportTitle = "REPORTE DE SALDOS INSOLUTOS Y AMORTIZACION DE CONTRATOS FONDEADOS POR PARAFINANCIERO AL " & CTOD(cFecha)
            End If
            newrptRepNafin = New rptRepNafin()
            newrptRepNafin.SummaryInfo.ReportTitle = cReportTitle
            CrystalReportViewer2.ReportSource = newrptRepNafin
        Else
            btnProceso.Enabled = False
            MsgBox("NO existe información", MsgBoxStyle.Information, "Mensaje")
        End If
        cnAgil = Nothing
        cm1 = Nothing
        cm2 = Nothing

    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class
