Option Explicit On 

Imports System.Data.SqlClient
Imports System.Math
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmRepoActi

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
    Friend WithEvents lblFinal As System.Windows.Forms.Label
    Friend WithEvents lblInicial As System.Windows.Forms.Label
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents dtpFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents dtpFechaIni As System.Windows.Forms.DateTimePicker
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblFinal = New System.Windows.Forms.Label
        Me.lblInicial = New System.Windows.Forms.Label
        Me.btnProcesar = New System.Windows.Forms.Button
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker
        Me.dtpFechaIni = New System.Windows.Forms.DateTimePicker
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.btnSalir = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lblFinal
        '
        Me.lblFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFinal.Location = New System.Drawing.Point(216, 16)
        Me.lblFinal.Name = "lblFinal"
        Me.lblFinal.Size = New System.Drawing.Size(76, 16)
        Me.lblFinal.TabIndex = 12
        Me.lblFinal.Text = "Fecha Final"
        Me.lblFinal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblInicial
        '
        Me.lblInicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInicial.Location = New System.Drawing.Point(16, 16)
        Me.lblInicial.Name = "lblInicial"
        Me.lblInicial.Size = New System.Drawing.Size(82, 16)
        Me.lblInicial.TabIndex = 10
        Me.lblInicial.Text = "Fecha Inicial"
        Me.lblInicial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnProcesar
        '
        Me.btnProcesar.Location = New System.Drawing.Point(440, 16)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(75, 23)
        Me.btnProcesar.TabIndex = 15
        Me.btnProcesar.Text = "Procesar"
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(296, 16)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(88, 20)
        Me.dtpFechaFin.TabIndex = 13
        '
        'dtpFechaIni
        '
        Me.dtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaIni.Location = New System.Drawing.Point(104, 16)
        Me.dtpFechaIni.Name = "dtpFechaIni"
        Me.dtpFechaIni.Size = New System.Drawing.Size(88, 20)
        Me.dtpFechaIni.TabIndex = 11
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
        Me.CrystalReportViewer1.TabIndex = 16
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(561, 16)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 17
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'frmRepoActi
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1024, 702)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.lblFinal)
        Me.Controls.Add(Me.lblInicial)
        Me.Controls.Add(Me.btnProcesar)
        Me.Controls.Add(Me.dtpFechaFin)
        Me.Controls.Add(Me.dtpFechaIni)
        Me.Name = "frmRepoActi"
        Me.Text = "Reporte de Activaciones en formato contable"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim daAnexos As New SqlDataAdapter(cm1)
        Dim daVencimientos As New SqlDataAdapter(cm2)
        Dim dsAgil As New DataSet()
        Dim drAnexo As DataRow
        Dim drAnexos As DataRowCollection
        Dim drVencimientos As DataRow()
        Dim drVencimiento As DataRow
        Dim relAnexoEdoctav As DataRelation
        Dim dtReporte As New DataTable("Anexos")
        Dim drReporte As DataRow
        Dim myColArray(2) As DataColumn

        ' Declaración de variables de datos

        Dim cFechaInicio As String
        Dim cFechaFinal As String
        Dim nCarteraEquipo As Decimal
        Dim nInteresEquipo As Decimal

        ' Declaración de variables de Crystal Reports

        Dim cReportTitle As String
        Dim newrptRepoActi As New rptRepoActi()

        dtpFechaIni.Enabled = False
        dtpFechaFin.Enabled = False
        btnProcesar.Enabled = False

        ' Aquí creo la tabla Reporte que será la base del reporte

        dtReporte.Columns.Add("Tipo", Type.GetType("System.String"))
        dtReporte.Columns.Add("Anexo", Type.GetType("System.String"))
        dtReporte.Columns.Add("Descr", Type.GetType("System.String"))
        dtReporte.Columns.Add("Fechacon", Type.GetType("System.String"))
        dtReporte.Columns.Add("ImpEq", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("IvaEq", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("Amorin", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("IvaAmorin", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("ImpRD", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("IvaRD", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("Utilidad", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("Cartera", Type.GetType("System.Decimal"))
        myColArray(0) = dtReporte.Columns("Tipo")
        myColArray(1) = dtReporte.Columns("Anexo")
        dtReporte.PrimaryKey = myColArray

        cFechaInicio = DTOC(dtpFechaIni.Value)
        cFechaFinal = DTOC(dtpFechaFin.Value)

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "RepoActi1"
            .Connection = cnAgil
            .Parameters.Add("@FechaInicio", SqlDbType.NVarChar)
            .Parameters(0).Value = cFechaInicio
            .Parameters.Add("@FechaFinal", SqlDbType.NVarChar)
            .Parameters(1).Value = cFechaFinal
        End With

        With cm2
            .CommandType = CommandType.StoredProcedure
            .CommandText = "AltaOper2"
            .Connection = cnAgil
            .Parameters.Add("@FechaInicio", SqlDbType.NVarChar)
            .Parameters(0).Value = cFechaInicio
            .Parameters.Add("@FechaFinal", SqlDbType.NVarChar)
            .Parameters(1).Value = cFechaFinal
        End With

        Try

            'Llenar el DataSet a través del DataAdapter, lo cual abre y cierra la conexión

            daAnexos.Fill(dsAgil, "Anexos")
            daVencimientos.Fill(dsAgil, "Edoctav")

            ' Establecer la relación entre Anexos y Edoctav

            relAnexoEdoctav = New DataRelation("AnexoEdoctav", dsAgil.Tables("Anexos").Columns("Anexo"), dsAgil.Tables("Edoctav").Columns("Anexo"))
            dsAgil.EnforceConstraints = False
            dsAgil.Relations.Add(relAnexoEdoctav)

            For Each drAnexo In dsAgil.Tables("Anexos").Rows

                ' Esta instrucción trae la tabla de amortización del Equipo única y exclusivamente del contrato
                ' que está siendo procesado

                drVencimientos = drAnexo.GetChildRows("AnexoEdoctav")

                nInteresEquipo = 0
                nCarteraEquipo = 0

                For Each drVencimiento In drVencimientos
                    nInteresEquipo = nInteresEquipo + drVencimiento("Inter")
                    nCarteraEquipo = nCarteraEquipo + drVencimiento("Abcap") + drVencimiento("Inter")
                Next

                drReporte = dtReporte.NewRow()
                drReporte("Tipo") = drAnexo("Tipo")
                drReporte("Anexo") = drAnexo("Anexo")
                drReporte("Descr") = drAnexo("Descr")
                drReporte("Fechacon") = drAnexo("Fechacon")
                drReporte("ImpEq") = drAnexo("ImpEq")
                drReporte("IvaEq") = drAnexo("IvaEq")
                drReporte("Amorin") = drAnexo("Amorin")
                drReporte("IvaAmorin") = drAnexo("IvaAmorin")
                drReporte("ImpRD") = drAnexo("ImpRD")
                drReporte("IvaRD") = drAnexo("IvaRD")
                drReporte("Utilidad") = Round(nInteresEquipo, 2)
                drReporte("Cartera") = Round(nCarteraEquipo, 2)
                dtReporte.Rows.Add(drReporte)

            Next

            ' Antes de remover tablas del DataSet, es necesario eliminar antes las relaciones y las restricciones
            ' que existen entre estas tablas

            dsAgil.Relations.Clear()
            dsAgil.Tables("Anexos").Constraints.Clear()
            dsAgil.Tables("Edoctav").Constraints.Clear()
            dsAgil.Tables.Remove("Anexos")
            dsAgil.Tables.Remove("Edoctav")
            dsAgil.Tables.Add(dtReporte)

            ' Descomentar la siguiente línea en caso de que se deseara modificar el reporte rptRepoActi
            ' dsAgil.WriteXml("C:\Schema17.xml", XmlWriteMode.WriteSchema)
            newrptRepoActi.SetDataSource(dsAgil)
            cReportTitle = "REPORTE DE ACTIVACIONES DEL " & Mid(CTOD(cFechaInicio).ToString, 1, 10) & " AL " & Mid(CTOD(cFechaFinal).ToString, 1, 10)
            newrptRepoActi.SummaryInfo.ReportTitle = cReportTitle
            CrystalReportViewer1.ReportSource = newrptRepoActi

        Catch eException As Exception

            MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")

        End Try

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class
