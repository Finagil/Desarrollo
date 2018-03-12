Option Explicit On 

Imports System.Data.SqlClient

Public Class frmPrepames

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
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents lblProceso As System.Windows.Forms.Label
    Friend WithEvents dtpProceso As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnProcesar = New System.Windows.Forms.Button
        Me.lblProceso = New System.Windows.Forms.Label
        Me.dtpProceso = New System.Windows.Forms.DateTimePicker
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.btnSalir = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnProcesar
        '
        Me.btnProcesar.Location = New System.Drawing.Point(249, 12)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(80, 24)
        Me.btnProcesar.TabIndex = 27
        Me.btnProcesar.Text = "Procesar"
        '
        'lblProceso
        '
        Me.lblProceso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProceso.Location = New System.Drawing.Point(12, 16)
        Me.lblProceso.Name = "lblProceso"
        Me.lblProceso.Size = New System.Drawing.Size(120, 16)
        Me.lblProceso.TabIndex = 26
        Me.lblProceso.Text = "Fecha de Proceso"
        Me.lblProceso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpProceso
        '
        Me.dtpProceso.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpProceso.Location = New System.Drawing.Point(136, 14)
        Me.dtpProceso.Name = "dtpProceso"
        Me.dtpProceso.Size = New System.Drawing.Size(88, 20)
        Me.dtpProceso.TabIndex = 25
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
        Me.CrystalReportViewer1.TabIndex = 28
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(352, 12)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(80, 24)
        Me.btnSalir.TabIndex = 29
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'frmPrepames
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1024, 702)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.btnProcesar)
        Me.Controls.Add(Me.lblProceso)
        Me.Controls.Add(Me.dtpProceso)
        Me.Name = "frmPrepames"
        Me.Text = "Reporte de Prepagos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daAnexos As New SqlDataAdapter(cm1)
        Dim dsAgil As New DataSet()
        Dim drAnexo As DataRow
        Dim drTemporal As DataRow
        Dim drAnexos() As DataRow
        Dim dtTemporal As New DataTable("Reporte")
        Dim dtReporte As New DataTable()
        Dim myColArray(2) As DataColumn
        Dim myKeySearch(1) As String

        ' Declaración de variables de datos

        Dim cAnexo As String
        Dim cCve As String
        Dim cDescr As String
        Dim cFecha As String
        Dim cFechacon As String
        Dim cFepag As String
        Dim cLetra As String
        Dim cMovimiento As String
        Dim cSujeto As String
        Dim nCapital As Decimal
        Dim nCartera As Decimal
        Dim nDias As Integer
        Dim nImp As Decimal
        Dim nIvaCapital As Decimal
        Dim nIvaEq As Decimal
        Dim nSeguro As Decimal

        ' Declaración de variables de Crystal Reports

        Dim newrptPrepames As New rptPrepames()

        btnProcesar.Enabled = False
        dtpProceso.Enabled = False

        cFecha = DTOC(dtpProceso.Value)

        ' Primero creo la tabla Temporal que será la base del reporte

        dtTemporal.Columns.Add("Sujeto", Type.GetType("System.String"))
        dtTemporal.Columns.Add("Anexo", Type.GetType("System.String"))
        dtTemporal.Columns.Add("Fecha", Type.GetType("System.String"))
        dtTemporal.Columns.Add("Cliente", Type.GetType("System.String"))
        dtTemporal.Columns.Add("Movimiento", Type.GetType("System.String"))
        dtTemporal.Columns.Add("Seguro", Type.GetType("System.Decimal"))
        dtTemporal.Columns.Add("Capital", Type.GetType("System.Decimal"))
        dtTemporal.Columns.Add("IvaCapital", Type.GetType("System.Decimal"))
        dtTemporal.Columns.Add("Cartera", Type.GetType("System.Decimal"))
        myColArray(0) = dtTemporal.Columns("Anexo")
        myColArray(1) = dtTemporal.Columns("Fecha")
        dtTemporal.PrimaryKey = myColArray

        ' Este Stored Procedure regresa todos los movimientos de adelantos o finiquitos que se encuentren
        ' en la tabla Hisgin y cuya clave sea de Seguro, Capital, Iva del Capital o Cartera y que además
        ' sean movimientos del mes que se está procesando

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Prepames1"
            .Connection = cnAgil
            .Parameters.Add("@Fecha", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        Try

            ' Llenar el DataSet a través del DataAdapter, lo cual abre y cierra la conexión

            daAnexos.Fill(dsAgil, "Anexos")

            For Each drAnexo In dsAgil.Tables(0).Rows
                cAnexo = drAnexo("Anexo")
                cFepag = drAnexo("Fepag")
                cDescr = drAnexo("Descr")
                cLetra = drAnexo("Letra")
                nDias = DateDiff(DateInterval.Day, CTOD(drAnexo("Fechacon")), CTOD(drAnexo("Fepag")))
                cCve = drAnexo("Cve")
                nImp = drAnexo("Imp")
                nIvaEq = drAnexo("IvaEq")
                If drAnexo("Fechacon") >= "20020301" And nIvaEq > 0 Then
                    cSujeto = "S"
                Else
                    cSujeto = "N"
                End If
                If cLetra = "888" Then
                    cMovimiento = "ADELANTO"
                ElseIf cLetra = "999" Then
                    If nDias <= 90 Then
                        cMovimiento = "FINIQUITO INUSUAL"
                    Else
                        cMovimiento = "FINIQUITO"
                    End If
                End If
                nSeguro = 0
                nCapital = 0
                nIvaCapital = 0
                nCartera = 0
                Select Case cCve
                    Case "28"
                        nSeguro = nImp
                    Case "85"
                        nCapital = nImp
                    Case "08"
                        nIvaCapital = nImp
                    Case "83"
                        nCartera = nImp
                End Select

                myKeySearch(0) = cAnexo
                myKeySearch(1) = cFepag

                drTemporal = dtTemporal.Rows.Find(myKeySearch)

                If drTemporal Is Nothing Then
                    drTemporal = dtTemporal.NewRow()
                    drTemporal("Sujeto") = cSujeto
                    drTemporal("Anexo") = cAnexo
                    drTemporal("Fecha") = cFepag
                    drTemporal("Cliente") = cDescr
                    drTemporal("Movimiento") = cMovimiento
                    drTemporal("Seguro") = nSeguro
                    drTemporal("Capital") = nCapital
                    drTemporal("IvaCapital") = nIvaCapital
                    drTemporal("Cartera") = nCartera
                    dtTemporal.Rows.Add(drTemporal)
                Else
                    drTemporal("Seguro") += nSeguro
                    drTemporal("Capital") += nCapital
                    drTemporal("IvaCapital") += nIvaCapital
                    drTemporal("Cartera") += nCartera
                End If
            Next

            dtReporte = dtTemporal.Clone()

            drAnexos = dtTemporal.Select(True, "Sujeto, Anexo, Fecha")

            For Each drAnexo In drAnexos
                dtReporte.ImportRow(drAnexo)
            Next

            dsAgil.Tables.Remove("Anexos")
            dsAgil.Tables.Add(dtReporte)
            ' Descomentar la siguiente línea en caso de que se deseara modificar el reporte rptPrepames
            ' dsAgil.WriteXml("C:\Schema11.xml", XmlWriteMode.WriteSchema)
            newrptPrepames.SetDataSource(dsAgil)

            CrystalReportViewer1.ReportSource = newrptPrepames

        Catch eException As Exception

            MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")

        End Try

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class
