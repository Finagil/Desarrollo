Option Explicit On 

Imports System.Data.SqlClient
Imports System.Math
Imports System.DateTime
Imports CrystalDecisions.Shared

Public Class frmRepoSegu

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
    Friend WithEvents dtpFechaReporte As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents cbReportes As System.Windows.Forms.ComboBox
    Friend WithEvents lblReportes As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.dtpFechaReporte = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.btnProcesar = New System.Windows.Forms.Button
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.btnSalir = New System.Windows.Forms.Button
        Me.cbReportes = New System.Windows.Forms.ComboBox
        Me.lblReportes = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'dtpFechaReporte
        '
        Me.dtpFechaReporte.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaReporte.Location = New System.Drawing.Point(128, 14)
        Me.dtpFechaReporte.Name = "dtpFechaReporte"
        Me.dtpFechaReporte.Size = New System.Drawing.Size(88, 20)
        Me.dtpFechaReporte.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(24, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 16)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "Fecha del reporte"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnProcesar
        '
        Me.btnProcesar.Location = New System.Drawing.Point(641, 13)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(75, 23)
        Me.btnProcesar.TabIndex = 36
        Me.btnProcesar.Text = "Procesar"
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(8, 62)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.ShowGroupTreeButton = False
        Me.CrystalReportViewer1.ShowRefreshButton = False
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1008, 626)
        Me.CrystalReportViewer1.TabIndex = 3
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'btnSalir
        '
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.Location = New System.Drawing.Point(745, 13)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 4
        Me.btnSalir.Text = "Salir"
        '
        'cbReportes
        '
        Me.cbReportes.FormattingEnabled = True
        Me.cbReportes.Location = New System.Drawing.Point(321, 14)
        Me.cbReportes.Name = "cbReportes"
        Me.cbReportes.Size = New System.Drawing.Size(275, 21)
        Me.cbReportes.TabIndex = 37
        '
        'lblReportes
        '
        Me.lblReportes.Location = New System.Drawing.Point(255, 16)
        Me.lblReportes.Name = "lblReportes"
        Me.lblReportes.Size = New System.Drawing.Size(62, 16)
        Me.lblReportes.TabIndex = 38
        Me.lblReportes.Text = "Reporte de"
        Me.lblReportes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmRepoSegu
        '
        Me.AcceptButton = Me.btnProcesar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnSalir
        Me.ClientSize = New System.Drawing.Size(1024, 702)
        Me.Controls.Add(Me.lblReportes)
        Me.Controls.Add(Me.cbReportes)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.btnProcesar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dtpFechaReporte)
        Me.Name = "frmRepoSegu"
        Me.Text = "Reportes de Seguros"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmRepoSegu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbReportes.Items.Add("Bienes SIN POLIZA")
        cbReportes.Items.Add("Bienes CON POLIZA VENCIDA")
        cbReportes.Items.Add("Bienes CON POLIZA VIGENTE")
        cbReportes.Items.Add("Bienes CON POLIZA POR VENCER el mes siguiente")
        cbReportes.SelectedIndex = 0
    End Sub

    Private Sub btnProcesar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProcesar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim dsAgil As New DataSet()
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim cm4 As New SqlCommand()
        Dim daAnexos As New SqlDataAdapter(cm1)
        Dim daActiFij As New SqlDataAdapter(cm2)
        Dim daSdoEq As New SqlDataAdapter(cm3)
        Dim daTablas As New SqlDataAdapter(cm4)
        Dim drAnexos As DataRow()
        Dim drEdoctav As DataRow()
        Dim drImportes As DataRow()
        Dim drAnexo As DataRow
        Dim drDato As DataRow
        Dim drSegu As DataRow
        Dim drTot As DataRow
        Dim drImporte As DataRow
        Dim relAnexoActiFij As DataRelation
        Dim relAnexoSaldoEq As DataRelation
        Dim relAnexoTabla As DataRelation
        Dim dtRepoSegu As New DataTable("RepSeguros")

        ' Declaración de variables de datos

        Dim cAnexo As String
        Dim cBien As String
        Dim cFecha As String
        Dim cGrupo As String
        Dim cMesSiguiente As String
        Dim cTermina As String
        Dim i As Integer
        Dim j As Integer
        Dim l As Integer
        Dim lProcesar As Boolean
        Dim n As Integer
        Dim nAño As Integer
        Dim nImporte As Decimal
        Dim nMes As Integer
        Dim nMpt As Integer
        Dim nMptseg As Integer
        Dim nPlazo As Integer
        Dim nSaldoEquipo As Decimal

        ' Declaración de variables de Crystal Reports

        Dim newrptRepoSegu As New rptRepoSegu()
        Dim cReportTitle As String

        cFecha = DTOC(dtpFechaReporte.Value)

        Select Case cbReportes.SelectedIndex
            Case 0
                cReportTitle = "REPORTE DE BIENES SIN POLIZA DE SEGURO AL " & Mid(cFecha, 7, 2) & "/" & Mid(cFecha, 5, 2) & "/" & Mid(cFecha, 1, 4)
            Case 1
                cReportTitle = "REPORTE DE BIENES CON POLIZA DE SEGURO VENCIDA AL " & Mid(cFecha, 7, 2) & "/" & Mid(cFecha, 5, 2) & "/" & Mid(cFecha, 1, 4)
            Case 2
                cReportTitle = "REPORTE DE BIENES CON POLIZA DE SEGURO VIGENTE AL " & Mid(cFecha, 7, 2) & "/" & Mid(cFecha, 5, 2) & "/" & Mid(cFecha, 1, 4)
            Case 3
                cReportTitle = "REPORTE DE BIENES CON POLIZA POR VENCER EL MES SIGUIENTE AL " & Mid(cFecha, 7, 2) & "/" & Mid(cFecha, 5, 2) & "/" & Mid(cFecha, 1, 4)
        End Select

        ' Creamos una Tabla temporal para guardar cada uno de los registros que formarán parte
        ' del reporte final de seguros

        dtRepoSegu.Columns.Add("Num", Type.GetType("System.Decimal"))
        dtRepoSegu.Columns.Add("Anexo", Type.GetType("System.String"))
        dtRepoSegu.Columns.Add("Name", Type.GetType("System.String"))
        dtRepoSegu.Columns.Add("Bien", Type.GetType("System.String"))
        dtRepoSegu.Columns.Add("Serie", Type.GetType("System.String"))
        dtRepoSegu.Columns.Add("Mpt", Type.GetType("System.Decimal"))
        dtRepoSegu.Columns.Add("Term", Type.GetType("System.String"))
        dtRepoSegu.Columns.Add("Saldo", Type.GetType("System.Decimal"))
        dtRepoSegu.Columns.Add("Numpoliz", Type.GetType("System.String"))
        dtRepoSegu.Columns.Add("Asegu", Type.GetType("System.String"))
        dtRepoSegu.Columns.Add("Inicio", Type.GetType("System.String"))
        dtRepoSegu.Columns.Add("Final", Type.GetType("System.String"))
        dtRepoSegu.Columns.Add("Mptseg", Type.GetType("System.Decimal"))
        dtRepoSegu.Columns.Add("Endoso", Type.GetType("System.String"))
        dtRepoSegu.Columns.Add("Grupo", Type.GetType("System.String"))
        dtRepoSegu.Clear()

        ' El siguiente Stored Procedure trae todos los contratos activos a la fecha solicitada

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "GeneProv1"
            .Connection = cnAgil
            .Parameters.Add("@Fechafin", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        ' Con este Stored Procedure obtengo todos los bienes no facturados

        With cm2
            .CommandType = CommandType.StoredProcedure
            .CommandText = "ActiFijo1"
            .Connection = cnAgil
        End With

        ' El siguiente Stored Procedure trae el monto original de cada contrato
        ' a partir del Activo Fijo

        With cm3
            .CommandType = CommandType.StoredProcedure
            .CommandText = "ActiFijo2"
            .Connection = cnAgil
        End With

        ' El siguiente Stored Procedure trae la tabla de amortización de todos los contratos 
        ' activos cuya fecha de contratación sea menor o igual a la de proceso

        With cm4
            .CommandType = CommandType.StoredProcedure
            .CommandText = "GeneProv2"
            .Connection = cnAgil
            .Parameters.Add("@Fechafin", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        ' Llenar el DataSet lo cual abre y cierra la conexión

        daAnexos.Fill(dsAgil, "Anexos")
        daActiFij.Fill(dsAgil, "ActiFijo")
        daSdoEq.Fill(dsAgil, "SaldoEq")
        daTablas.Fill(dsAgil, "Tablas")

        ' Establecer la relación entre Anexos y Edoctav

        relAnexoActiFij = New DataRelation("AnexoActiFij", dsAgil.Tables("Anexos").Columns("Anexo"), dsAgil.Tables("Actifijo").Columns("Anexo"))
        dsAgil.EnforceConstraints = False
        dsAgil.Relations.Add(relAnexoActiFij)

        relAnexoSaldoEq = New DataRelation("AnexoSaldoEq", dsAgil.Tables("Anexos").Columns("Anexo"), dsAgil.Tables("SaldoEq").Columns("Anexo"))
        dsAgil.EnforceConstraints = False
        dsAgil.Relations.Add(relAnexoSaldoEq)

        relAnexoTabla = New DataRelation("AnexoTablaEq", dsAgil.Tables("Anexos").Columns("Anexo"), dsAgil.Tables("Tablas").Columns("Anexo"))
        dsAgil.EnforceConstraints = False
        dsAgil.Relations.Add(relAnexoTabla)

        i = 0
        j = 0
        l = 0
        n = 0

        For Each drDato In dsAgil.Tables("Anexos").Rows

            lProcesar = True

            nPlazo = drDato("Plazo")
            cTermina = DTOC(Termina(CTOD(drDato("Fvenc")), nPlazo))

            ' Solo procesa contratos que terminen con posterioridad a la fecha de proceso

            If cTermina <= cFecha Then
                lProcesar = False
            End If

            cAnexo = drDato("Anexo")
            nMpt = Mpt(CTOD(cTermina), CTOD(cFecha))

            ' Obtiene la tabla de amortización de un contrato en particular a fin de calcular el saldo insoluto

            nSaldoEquipo = 0
            drEdoctav = drDato.GetChildRows("AnexoTablaEq")
            TraeSald(drEdoctav, cFecha, nSaldoEquipo, 0, 0)

            ' Solo procesa contratos que tengan saldo insoluto ya que pudieran existir contratos
            ' que no estén marcados como terminados pero que ya no tienen saldo insoluto

            If nSaldoEquipo <= 0 Then
                lProcesar = False
            End If

            If lProcesar = True Then

                ' Obtiene el MOI del contrato

                drImportes = drDato.GetChildRows("AnexoSaldoEq")
                For Each drImporte In drImportes
                    nImporte = drImporte("nSaldoEq")
                Next

                ' Obtiene los bienes no facturados de un contrato en particular

                drAnexos = drDato.GetChildRows("AnexoActiFij")

                For Each drAnexo In drAnexos

                    If Len(Trim(drAnexo("Vigencseg"))) > 0 Then
                        nMptseg = Mpt(CTOD(cFecha), CTOD(drAnexo("Vigencseg")))
                        IIf(nMptseg < 0, 0, nMptseg)
                    Else
                        nMptseg = 0
                    End If

                    If cbReportes.SelectedIndex = 0 Then
                        If Len(Trim(drAnexo("Numpoliz"))) = 0 Or Len(Trim(drAnexo("Inicioseg"))) = 0 Or Len(Trim(drAnexo("Vigencseg"))) = 0 Then
                            drSegu = dtRepoSegu.NewRow()
                            i += 1
                            drSegu("Num") = i
                            drSegu("Anexo") = cAnexo
                            If Not IsDBNull(drAnexo("Detalle")) Then
                                drSegu("Bien") = Mid(drAnexo("Detalle"), 1, 45)
                            End If
                            drSegu("Name") = drDato("Descr")
                            drSegu("Serie") = drAnexo("Serie")
                            drSegu("Term") = CTOD(cTermina).ToShortDateString
                            drSegu("Mpt") = nMpt
                            drSegu("Saldo") = nSaldoEquipo
                            drSegu("Numpoliz") = drAnexo("Numpoliz")
                            drSegu("Asegu") = drAnexo("Asegurador")
                            drSegu("Inicio") = IIf(Len(Trim(drAnexo("Inicioseg"))) > 0, CTOD(drAnexo("Inicioseg")).ToShortDateString, "")
                            drSegu("Final") = IIf(Len(Trim(drAnexo("Vigencseg"))) > 0, CTOD(drAnexo("Vigencseg")).ToShortDateString, "")
                            drSegu("Mptseg") = nMptseg
                            drSegu("Endoso") = drAnexo("Endoso")
                            drSegu("Grupo") = "1"
                            dtRepoSegu.Rows.Add(drSegu)
                        End If
                    End If
                    If cbReportes.SelectedIndex = 1 Then
                        If drAnexo("Vigencseg") < cFecha And Len(Trim(drAnexo("Vigencseg"))) > 0 Then
                            drSegu = dtRepoSegu.NewRow()
                            j += 1
                            drSegu("Num") = j
                            drSegu("Anexo") = drAnexo("Anexo")
                            If Not IsDBNull(drAnexo("Detalle")) Then
                                drSegu("Bien") = Mid(drAnexo("Detalle"), 1, 45)
                            End If
                            drSegu("Name") = drDato("Descr")
                            drSegu("Serie") = drAnexo("Serie")
                            drSegu("term") = CTOD(cTermina).ToShortDateString
                            drSegu("Mpt") = nMpt
                            drSegu("Saldo") = nSaldoEquipo
                            drSegu("Numpoliz") = drAnexo("Numpoliz")
                            drSegu("Asegu") = drAnexo("Asegurador")
                            drSegu("Inicio") = IIf(Len(Trim(drAnexo("Inicioseg"))) > 0, CTOD(drAnexo("Inicioseg")).ToShortDateString, "")
                            drSegu("Final") = IIf(Len(Trim(drAnexo("Vigencseg"))) > 0, CTOD(drAnexo("Vigencseg")).ToShortDateString, "")
                            drSegu("Mptseg") = nMptseg
                            drSegu("Endoso") = drAnexo("Endoso")
                            drSegu("Grupo") = "2"
                            dtRepoSegu.Rows.Add(drSegu)
                        End If
                    End If
                    If cbReportes.SelectedIndex = 2 Then
                        If drAnexo("Vigencseg") >= cFecha Then
                            drSegu = dtRepoSegu.NewRow()
                            l += 1
                            drSegu("Num") = l
                            drSegu("Anexo") = drAnexo("Anexo")
                            If Not IsDBNull(drAnexo("Detalle")) Then
                                drSegu("Bien") = Mid(drAnexo("Detalle"), 1, 45)
                            End If
                            drSegu("Name") = drDato("Descr")
                            drSegu("Serie") = drAnexo("Serie")
                            drSegu("Term") = CTOD(cTermina).ToShortDateString
                            drSegu("Mpt") = nMpt
                            drSegu("Saldo") = nSaldoEquipo
                            drSegu("Numpoliz") = drAnexo("Numpoliz")
                            drSegu("Asegu") = drAnexo("Asegurador")
                            drSegu("Inicio") = IIf(Len(Trim(drAnexo("Inicioseg"))) > 0, CTOD(drAnexo("Inicioseg")).ToShortDateString, "")
                            drSegu("Final") = IIf(Len(Trim(drAnexo("Vigencseg"))) > 0, CTOD(drAnexo("Vigencseg")).ToShortDateString, "")
                            drSegu("Mptseg") = nMptseg
                            drSegu("Endoso") = drAnexo("Endoso")
                            drSegu("Grupo") = "4"
                            dtRepoSegu.Rows.Add(drSegu)
                        End If
                    End If
                    If cbReportes.SelectedIndex = 3 Then
                        nAño = Val(Mid(cFecha, 1, 4))
                        nMes = Val(Mid(cFecha, 5, 2)) + 1
                        If nMes > 12 Then
                            nMes = 1
                            nAño += 1
                        End If
                        If nMes < 10 Then
                            cMesSiguiente = nAño.ToString & "0" & nMes.ToString
                        Else
                            cMesSiguiente = nAño.ToString & nMes.ToString
                        End If
                        If Mid(drAnexo("Vigencseg"), 1, 6) = cMesSiguiente Then
                            drSegu = dtRepoSegu.NewRow()
                            n += 1
                            drSegu("Num") = n
                            drSegu("Anexo") = drAnexo("Anexo")
                            If Not IsDBNull(drAnexo("Detalle")) Then
                                drSegu("Bien") = Mid(drAnexo("Detalle"), 1, 45)
                            End If
                            drSegu("Name") = drDato("Descr")
                            drSegu("Serie") = drAnexo("Serie")
                            drSegu("Term") = CTOD(cTermina).ToShortDateString
                            drSegu("Mpt") = nMpt
                            drSegu("Saldo") = nSaldoEquipo
                            drSegu("Numpoliz") = drAnexo("Numpoliz")
                            drSegu("Asegu") = drAnexo("Asegurador")
                            drSegu("Inicio") = IIf(Len(Trim(drAnexo("Inicioseg"))) > 0, CTOD(drAnexo("Inicioseg")).ToShortDateString, "")
                            drSegu("Final") = IIf(Len(Trim(drAnexo("Vigencseg"))) > 0, CTOD(drAnexo("Vigencseg")).ToShortDateString, "")
                            drSegu("Mptseg") = nMptseg
                            drSegu("Endoso") = drAnexo("Endoso")
                            drSegu("Grupo") = "3"
                            dtRepoSegu.Rows.Add(drSegu)
                        End If
                    End If
                Next
            End If
        Next

        dsAgil.Relations.Clear()
        dsAgil.Tables("Anexos").Constraints.Clear()
        dsAgil.Tables("ActiFijo").Constraints.Clear()
        dsAgil.Tables("SaldoEq").Constraints.Clear()
        dsAgil.Tables("Tablas").Constraints.Clear()
        dsAgil.Tables.Remove("Anexos")
        dsAgil.Tables.Remove("Actifijo")
        dsAgil.Tables.Remove("SaldoEq")
        dsAgil.Tables.Remove("tablas")
        dsAgil.Tables.Add(dtRepoSegu)

        ' Descomentar esta linea cuando se desee modificar rptRepoSegu
        dsAgil.WriteXml("C:\Schema22.xml", XmlWriteMode.WriteSchema)

        newrptRepoSegu.SetDataSource(dsAgil)
        newrptRepoSegu.SummaryInfo.ReportTitle = cReportTitle
        CrystalReportViewer1.ReportSource = newrptRepoSegu
        CrystalReportViewer1.Visible = True

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()
        cm3.Dispose()
        cm4.Dispose()

    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class
