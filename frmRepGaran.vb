Option Explicit On

Imports System.Data.SqlClient
Imports System.Math
Imports CrystalDecisions.Shared

Public Class frmRepGaran

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnExit As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.btnExit = New System.Windows.Forms.Button
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(122, 16)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(88, 20)
        Me.DateTimePicker1.TabIndex = 27
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(21, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 16)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Fecha del proceso"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(244, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 20)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Selecciona Pagaré"
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(7, 137)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1008, 553)
        Me.CrystalReportViewer1.TabIndex = 32
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        Me.CrystalReportViewer1.Visible = False
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(804, 11)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(80, 24)
        Me.btnExit.TabIndex = 34
        Me.btnExit.Text = "Salir"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.HotTrack
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView1.GridColor = System.Drawing.SystemColors.Highlight
        Me.DataGridView1.Location = New System.Drawing.Point(346, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridView1.RowHeadersWidth = 30
        Me.DataGridView1.RowTemplate.Height = 20
        Me.DataGridView1.Size = New System.Drawing.Size(447, 119)
        Me.DataGridView1.TabIndex = 36
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Garantia"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn1.FillWeight = 53.93702!
        Me.DataGridViewTextBoxColumn1.HeaderText = "GAR."
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Fecha"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.NullValue = Nothing
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn2.FillWeight = 89.37983!
        Me.DataGridViewTextBoxColumn2.HeaderText = "FECHA"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Importe"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn3.FillWeight = 91.37055!
        Me.DataGridViewTextBoxColumn3.HeaderText = "IMPORTE"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Banco"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn4.FillWeight = 165.3126!
        Me.DataGridViewTextBoxColumn4.HeaderText = "BANCO"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'frmRepGaran
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1024, 702)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Name = "frmRepGaran"
        Me.Text = "Reporte de Aforos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmRepGaran_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strInsert As String
        Dim cnAgil As New SqlConnection(strConn)
        Dim cm4 As New SqlCommand()
        Dim daAforo As New SqlDataAdapter(cm4)
        Dim dsAforo As New DataSet()
        Dim drAforo As DataRow
        Dim drAdd As DataRow
        Dim dtMostrar As New DataTable("Garantias")

        Dim cBanco As String

        ' Primero creo la tabla dtMostrar que desplegara la información de las
        ' aforos dados de alta hasta el momento

        dtMostrar.Columns.Add("Garantia", Type.GetType("System.String"))
        dtMostrar.Columns.Add("Fecha", Type.GetType("System.String"))
        dtMostrar.Columns.Add("Importe", Type.GetType("System.Decimal"))
        dtMostrar.Columns.Add("Banco", Type.GetType("System.String"))

        With cm4
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DameAforos"
            .Connection = cnAgil
        End With
        daAforo.Fill(dsAforo, "Aforos")

        For Each drAforo In dsAforo.Tables("Aforos").Rows()
            cBanco = IIf(Trim(drAforo("Fecha")) <> "", CTOD(drAforo("Fecha")).ToShortDateString, "")
            drAdd = dtMostrar.NewRow()
            drAdd("Garantia") = Trim(drAforo("Garantia"))
            drAdd("Fecha") = cBanco
            drAdd("Importe") = drAforo("Importe")
            drAdd("Banco") = drAforo("descBanco")
            dtMostrar.Rows.Add(drAdd)
        Next
        dsAforo.Tables.Add(dtMostrar)

        DataGridView1.DataSource = dtMostrar

    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim cm4 As New SqlCommand()
        Dim daAnexos As New SqlDataAdapter(cm1)
        Dim daEdoctav As New SqlDataAdapter(cm2)
        Dim daFacturas As New SqlDataAdapter(cm3)
        Dim daActifijo As New SqlDataAdapter(cm4)
        Dim dsAgil As New DataSet()
        Dim dsReporte As New DataSet()
        Dim dtReporte As New DataTable("Reporte")
        Dim dtFinal As New DataTable()
        Dim drEdoctav As DataRow()
        Dim drFacturas As DataRow()
        Dim drRegistros As DataRow()
        Dim drAnexo As DataRow
        Dim drRegistro As DataRow
        Dim drVencimiento As DataRow
        Dim drReporte As DataRow
        Dim relAnexoEdoctav As DataRelation
        Dim relAnexoFacturas As DataRelation
        Dim relAnexoOriginal As DataRelation
        Dim strInsert As String

        ' Declaración de variables de datos

        Dim cAnexo As String
        Dim cCusnam As String
        Dim cFecha As String
        Dim cFechacon As String
        Dim cFeven As String
        Dim cFondeo As String
        Dim cTermina As String
        Dim cFvenc As String
        Dim cTipeq As String
        Dim cDescTipo As String
        Dim cAval As String
        Dim cPagare As String
        Dim nCarteraEquipo As Decimal
        Dim nInteresEquipo As Decimal
        Dim nImporte As Decimal
        Dim nMOI As Decimal
        Dim nCounter As Integer
        Dim nMaxCounter As Integer = 100
        Dim nPlazo As Byte
        Dim nSaldoEquipo As Decimal
        Dim nSaldo As Decimal

        ' Declaración de variables de Crystal Reports

        Dim cReportTitle As String
        Dim cSubTitle As String
        Dim newrptRepGaran As New rptRepGaran()

        cFecha = DTOC(DateTimePicker1.Value)
        cPagare = Trim(DataGridView1.Rows(e.RowIndex).Cells(0).Value)

        If Trim(DataGridView1.Rows(e.RowIndex).Cells(3).Value) = "BANCOMER" And Val(cPagare) >= 76 Then

            Dim newrptRepGaran1 As New rptRepGarBmer()

            ' Primero creo la tabla Reporte que será la base del reporte

            dtReporte.Columns.Add("Num", Type.GetType("System.Decimal"))
            dtReporte.Columns.Add("Contrato", Type.GetType("System.String"))
            dtReporte.Columns.Add("Cliente", Type.GetType("System.String"))
            dtReporte.Columns.Add("Fechacon", Type.GetType("System.String"))
            dtReporte.Columns.Add("Termina", Type.GetType("System.String"))
            dtReporte.Columns.Add("Factura", Type.GetType("System.String"))
            dtReporte.Columns.Add("Importe", Type.GetType("System.Decimal"))
            dtReporte.Columns.Add("Aval", Type.GetType("System.String"))
            dtReporte.Columns.Add("DescrEquipo", Type.GetType("System.String"))
            dtReporte.Columns.Add("Tipar", Type.GetType("System.String"))

            ' Este Stored Procedure trae todos los contratos activos con fecha de contratación menor o igual
            ' a la de proceso

            With cm1
                .CommandType = CommandType.StoredProcedure
                .CommandText = "TraeAforo"
                .Connection = cnAgil
                .Parameters.Add("@Aforo", SqlDbType.NVarChar)
                .Parameters(0).Value = cPagare
            End With

            With cm2
                .CommandType = CommandType.Text
                .CommandText = "SELECT anexo, Sum(Abcap) as saldo FROM Edoctav WHERE Nufac = " & (0).ToString & " Group By Anexo Order by Anexo"
                .Connection = cnAgil
            End With

            With cm3
                .CommandType = CommandType.Text
                .CommandText = "SELECT * FROM CtrlAforos WHERE Garantia = " & cPagare
                .Connection = cnAgil
            End With

            With cm4
                .CommandType = CommandType.StoredProcedure
                .CommandText = "Actifijo2"
                .Connection = cnAgil
            End With

            ' Llenar el DataSet a través del DataAdapter, lo cual abre y cierra la conexión

            daAnexos.Fill(dsAgil, "Anexos")
            daEdoctav.Fill(dsAgil, "Saldos")
            daActifijo.Fill(dsAgil, "Totales")
            daFacturas.Fill(dsAgil, "Aforo")

            ' Establecer la relación entre Anexos y Saldos

            relAnexoEdoctav = New DataRelation("AnexoEdoctav", dsAgil.Tables("Anexos").Columns("Anexo"), dsAgil.Tables("Saldos").Columns("Anexo"))
            dsAgil.EnforceConstraints = False
            dsAgil.Relations.Add(relAnexoEdoctav)

            ' Establecer la relación entre Anexos y Totales

            relAnexoOriginal = New DataRelation("AnexoOriginal", dsAgil.Tables("Anexos").Columns("Anexo"), dsAgil.Tables("Totales").Columns("Anexo"))
            dsAgil.EnforceConstraints = False
            dsAgil.Relations.Add(relAnexoOriginal)

            cFecha = DataGridView1.Rows(e.RowIndex).Cells(1).Value
            nCounter = 0
            For Each drAnexo In dsAgil.Tables("Anexos").Rows
                nCounter += 1
                cAnexo = drAnexo("Anexo")
                cCusnam = Mid(drAnexo("Descr"), 1, 40)
                cFechacon = drAnexo("Fechacon")
                cTipeq = drAnexo("Factura")
                nPlazo = drAnexo("Plazo")
                cTermina = DTOC(Termina(CTOD(drAnexo("Fvenc")), nPlazo))
                nMOI = drAnexo("Importe")

                drEdoctav = drAnexo.GetChildRows("AnexoEdoctav")
                For Each drRegistro In drEdoctav
                    nSaldoEquipo = drRegistro("Saldo")
                Next

                drEdoctav = drAnexo.GetChildRows("AnexoOriginal")
                For Each drRegistro In drEdoctav
                    nSaldo = drRegistro("nSaldoEq")
                Next
                nInteresEquipo = ((nSaldoEquipo * 100) / nSaldo) / 100
                nImporte = Round(nMOI * nInteresEquipo, 2)

                cAval = ""
                If Trim(drAnexo("nomCoac")) <> "" And cAval = "" Then
                    cAval = drAnexo("nomCoac")
                ElseIf Trim(drAnexo("nomObli")) <> "" And cAval = "" Then
                    cAval = drAnexo("nomObli")
                ElseIf Trim(drAnexo("nomAval1")) <> "" And cAval = "" Then
                    cAval = drAnexo("nomAval1")
                ElseIf Trim(drAnexo("nomAval2")) <> "" And cAval = "" Then
                    cAval = drAnexo("nomAval2")
                End If

                drReporte = dtReporte.NewRow()
                drReporte("Num") = nCounter
                drReporte("Contrato") = Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 6, 4)
                drReporte("Cliente") = cCusnam
                drReporte("Fechacon") = CTOD(cFechacon).ToShortDateString
                drReporte("Termina") = CTOD(cTermina).ToShortDateString
                drReporte("Factura") = cTipeq
                drReporte("Importe") = nImporte
                drReporte("Aval") = cAval
                drReporte("DescrEquipo") = drAnexo("Det")
                drReporte("Tipar") = drAnexo("Tipar")
                dtReporte.Rows.Add(drReporte)

            Next

            ' Llenar el DataSet lo cual abre y cierra la conexión

            dsAgil.Relations.Clear()
            dsAgil.Tables("Anexos").Constraints.Clear()
            dsAgil.Tables("Saldos").Constraints.Clear()
            dsAgil.Tables("Totales").Constraints.Clear()
            dsAgil.Tables.Remove("Anexos")
            dsAgil.Tables.Remove("Saldos")
            dsAgil.Tables.Remove("Totales")
            dsAgil.Tables.Add(dtReporte)

            'dsAgil.WriteXml("C:\Schema29.xml", XmlWriteMode.WriteSchema)

            CrystalReportViewer1.Visible = True
            newrptRepGaran1.SetDataSource(dsAgil)
            cReportTitle = "PAGARE " & cPagare & " DEL " & cFecha & "  POR " & FormatNumber(DataGridView1.Rows(e.RowIndex).Cells(2).Value).ToString & " CON BANCOMER"

            newrptRepGaran1.SummaryInfo.ReportTitle = cReportTitle
            newrptRepGaran1.SummaryInfo.ReportComments = cSubTitle
            CrystalReportViewer1.ReportSource = newrptRepGaran1

        Else
            ' Primero creo la tabla Reporte que será la base del reporte

            dtReporte.Columns.Add("Contrato", Type.GetType("System.String"))
            dtReporte.Columns.Add("Cliente", Type.GetType("System.String"))
            dtReporte.Columns.Add("MOI", Type.GetType("System.Decimal"))
            dtReporte.Columns.Add("SaldoEquipo", Type.GetType("System.Decimal"))
            dtReporte.Columns.Add("Fechacon", Type.GetType("System.String"))
            dtReporte.Columns.Add("Termina", Type.GetType("System.String"))
            dtReporte.Columns.Add("TipoEquipo", Type.GetType("System.String"))
            dtReporte.Columns.Add("Tipar", Type.GetType("System.String"))

            ' Este Stored Procedure trae todos los contratos activos con fecha de contratación menor o igual
            ' a la de proceso

            With cm1
                .CommandType = CommandType.StoredProcedure
                .CommandText = "RepGaran1"
                .Connection = cnAgil
                .Parameters.Add("@FechaFin", SqlDbType.NVarChar)
                .Parameters.Add("@Garantia", SqlDbType.NVarChar)
                .Parameters(0).Value = cFecha
                .Parameters(1).Value = cPagare
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

            ' Este Stored Procedure trae todas las facturas no pagadas de todos los contratos activos con fecha de
            ' contratación menor o igual a la de proceso

            With cm3
                .CommandType = CommandType.StoredProcedure
                .CommandText = "CalcAnti1"
                .Connection = cnAgil
                .Parameters.Add("@Fecha", SqlDbType.NVarChar)
                .Parameters(0).Value = cFecha
            End With

            ' Llenar el DataSet a través del DataAdapter, lo cual abre y cierra la conexión

            daAnexos.Fill(dsAgil, "Anexos")
            daEdoctav.Fill(dsAgil, "Edoctav")
            daFacturas.Fill(dsAgil, "Facturas")

            ' Establecer la relación entre Anexos y Edoctav

            relAnexoEdoctav = New DataRelation("AnexoEdoctav", dsAgil.Tables("Anexos").Columns("Anexo"), dsAgil.Tables("Edoctav").Columns("Anexo"))
            dsAgil.EnforceConstraints = False
            dsAgil.Relations.Add(relAnexoEdoctav)

            ' Establecer la relación entre Anexos y Facturas

            relAnexoFacturas = New DataRelation("AnexoFacturas", dsAgil.Tables("Anexos").Columns("Anexo"), dsAgil.Tables("Facturas").Columns("Anexo"))
            dsAgil.EnforceConstraints = False
            dsAgil.Relations.Add(relAnexoFacturas)

            cSubTitle = " "

            cSubTitle = "PAGARE " & cPagare & " DEL " & DataGridView1.Rows(e.RowIndex).Cells(1).Value
            cSubTitle = cSubTitle & "  POR " & FormatNumber(DataGridView1.Rows(e.RowIndex).Cells(2).Value).ToString
            cSubTitle = cSubTitle & " CON " & DataGridView1.Rows(e.RowIndex).Cells(3).Value

            If dsAgil.Tables("Anexos").Rows.Count > 0 Then

                For Each drAnexo In dsAgil.Tables("Anexos").Rows

                    cAnexo = drAnexo("Anexo")
                    cCusnam = Mid(drAnexo("Descr"), 1, 40)
                    cTipeq = drAnexo("Tipeq")
                    nPlazo = drAnexo("Plazo")
                    cFechacon = drAnexo("Fechacon")
                    cFvenc = drAnexo("Fvenc")
                    cFondeo = drAnexo("Fondeo")
                    nMOI = Round(drAnexo("Impeq") - drAnexo("Ivaeq") - drAnexo("Amorin"), 2)

                    Select Case cTipeq
                        Case "1"
                            cDescTipo = "EQUIPO COMERCIAL Y DE OFICINA"
                        Case "2"
                            cDescTipo = "EQUIPO INDUSTRIAL"
                        Case "3"
                            cDescTipo = "EQUIPO DE TRANSPORTE"
                        Case "4"
                            cDescTipo = "EQUIPO DE COMPUTO"
                        Case "5"
                            cDescTipo = "EQUIPO DE CONSTRUCCION"
                        Case "6"
                            cDescTipo = "INMUEBLES DE USO INDUSTRIAL"
                        Case "9"
                            cDescTipo = "OTROS EQUIPOS"
                    End Select

                    cTermina = DTOC(Termina(CTOD(cFvenc), nPlazo))
                    drFacturas = drAnexo.GetChildRows("AnexoFacturas")

                    CalcAnti(cAnexo, cFecha, nMaxCounter, nCounter, drFacturas)

                    If nCounter <= nMaxCounter Then

                        ' Se trata de un contrato que NO está vencido (con rentas a más de 89 días)

                        nSaldoEquipo = 0
                        nInteresEquipo = 0
                        nCarteraEquipo = 0

                        ' Esta instrucción trae la tabla de amortización del Equipo única y exclusivamente del contrato
                        ' que está siendo procesado

                        drEdoctav = drAnexo.GetChildRows("AnexoEdoctav")
                        TraeSald(drEdoctav, cFecha, nSaldoEquipo, nInteresEquipo, nCarteraEquipo)

                        ' En este reporte solo deben incluirse los contratos de Arrendamiento Financiero

                        If nSaldoEquipo > 0 Then
                            drReporte = dtReporte.NewRow()
                            drReporte("Contrato") = Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 6, 4)
                            drReporte("Cliente") = cCusnam
                            drReporte("MOI") = nMOI
                            drReporte("SaldoEquipo") = nSaldoEquipo
                            drReporte("Fechacon") = CTOD(cFechacon).ToShortDateString
                            drReporte("Termina") = CTOD(cTermina).ToShortDateString
                            drReporte("TipoEquipo") = cDescTipo
                            drReporte("Tipar") = drAnexo("Tipar")
                            dtReporte.Rows.Add(drReporte)
                        End If
                    End If
                Next

                ' Llenar el DataSet lo cual abre y cierra la conexión

                dsAgil.Relations.Clear()
                dsAgil.Tables("Anexos").Constraints.Clear()
                dsAgil.Tables("Edoctav").Constraints.Clear()
                dsAgil.Tables("Facturas").Constraints.Clear()
                dsAgil.Tables.Remove("Anexos")
                dsAgil.Tables.Remove("Edoctav")
                dsAgil.Tables.Remove("Facturas")
                dsAgil.Tables.Add(dtReporte)

                ' Descomentar la siguiente línea en caso de que se deseara modificar el reporte rptRepGaran
                dsAgil.WriteXml("C:\Schema29.xml", XmlWriteMode.WriteSchema)

                If dtReporte.Rows.Count > 0 Then

                    CrystalReportViewer1.Visible = True
                    newrptRepGaran.SetDataSource(dsAgil)
                    cReportTitle = "REPORTE DE SALDOS INSOLUTOS DADOS EN GARANTIA AL " & Mes(cFecha)
                    newrptRepGaran.SummaryInfo.ReportTitle = cReportTitle
                    newrptRepGaran.SummaryInfo.ReportComments = cSubTitle
                    CrystalReportViewer1.ReportSource = newrptRepGaran

                Else

                    MsgBox("Los contratos de este pagaré ya no tienen Saldo Insoluto", MsgBoxStyle.Critical, "Mensaje")

                End If

            Else

                MsgBox("No existe información para ese Pagaré", MsgBoxStyle.Critical, "Mensaje")

            End If

            cnAgil.Dispose()
            cm1.Dispose()
            cm2.Dispose()
            cm3.Dispose()

        End If

    End Sub

    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

End Class
