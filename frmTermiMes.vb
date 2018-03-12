Option Explicit On 

Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmTermimes

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
    Friend WithEvents btnTermina As System.Windows.Forms.Button
    Friend WithEvents lblReporte As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnTermina = New System.Windows.Forms.Button
        Me.lblReporte = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.btnSalir = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnTermina
        '
        Me.btnTermina.Location = New System.Drawing.Point(351, 16)
        Me.btnTermina.Name = "btnTermina"
        Me.btnTermina.Size = New System.Drawing.Size(80, 24)
        Me.btnTermina.TabIndex = 28
        Me.btnTermina.Text = "Procesar"
        '
        'lblReporte
        '
        Me.lblReporte.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReporte.Location = New System.Drawing.Point(8, 16)
        Me.lblReporte.Name = "lblReporte"
        Me.lblReporte.Size = New System.Drawing.Size(192, 24)
        Me.lblReporte.TabIndex = 27
        Me.lblReporte.Text = "Selecciona la fecha del Reporte"
        Me.lblReporte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(224, 18)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(88, 20)
        Me.DateTimePicker1.TabIndex = 26
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(8, 56)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.ShowGroupTreeButton = False
        Me.CrystalReportViewer1.ShowRefreshButton = False
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1008, 640)
        Me.CrystalReportViewer1.TabIndex = 29
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        Me.CrystalReportViewer1.Visible = False
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(468, 16)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(80, 24)
        Me.btnSalir.TabIndex = 30
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'frmTermimes
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1024, 702)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.btnTermina)
        Me.Controls.Add(Me.lblReporte)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Name = "frmTermimes"
        Me.Text = "Terminaciones del Mes"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnTermina_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTermina.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daTermina As New SqlDataAdapter(cm1)
        Dim dsAgil As New DataSet()
        Dim drAnexo As DataRow
        Dim drTermino As DataRow
        Dim drAnexos As DataRowCollection
        Dim dtTermina As New DataTable("Termina")

        ' Declaración de variables de datos

        Dim cFecha As String
        Dim cFecTerm As String
        Dim cFlcan As String

        ' Declaración de variables de Crystal Reports

        Dim newrptTermiMes As New rptTermiMes()

        btnTermina.Enabled = False
        DateTimePicker1.Enabled = False
        CrystalReportViewer1.Visible = False

        cFecha = DTOC(DateTimePicker1.Value)

        'Creo una tabla Temporal donde almaceno los datos que formarán parte del reporte final

        dtTermina.Columns.Add("Contrato", Type.GetType("System.String"))
        dtTermina.Columns.Add("Status", Type.GetType("System.String"))
        dtTermina.Columns.Add("Fecha", Type.GetType("System.String"))
        dtTermina.Columns.Add("Nombre", Type.GetType("System.String"))
        dtTermina.Columns.Add("Opcompra", Type.GetType("System.Decimal"))
        dtTermina.Columns.Add("Ivaop", Type.GetType("System.Decimal"))

        ' Con este Stored Procedure obtengo todos los contratos Activos y Terminados
        ' para revisar su Status.

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Termimes1"
            .Connection = cnAgil
        End With

        ' Llenar el DataSet lo cual abre y cierra la conexión

        daTermina.Fill(dsAgil, "Termina")

        drAnexos = dsAgil.Tables("Termina").Rows

        If dsAgil.Tables("Termina").Rows.Count = 0 Then

            MsgBox("No existen contratos con Terminación en este mes ", MsgBoxStyle.Information, "Mensaje")

        Else

            For Each drAnexo In drAnexos

                cFecTerm = DTOC(Termina(CTOD(drAnexo("Fvenc")), drAnexo("Plazo")))

                If Mid(cFecTerm, 1, 6) = Mid(cFecha, 1, 6) Then
                    drTermino = dtTermina.NewRow()
                    drTermino("Contrato") = Mid(drAnexo("Anexo"), 1, 5) & "/" & Mid(drAnexo("Anexo"), 6, 4)
                    cFlcan = drAnexo("Flcan")
                    Select Case cFlcan
                        Case "A"
                            drTermino("Status") = "ACTIVO"
                        Case "T"
                            drTermino("Status") = "TERMINADO"
                    End Select
                    drTermino("Fecha") = CTOD(cFecTerm).ToShortDateString
                    drTermino("Nombre") = drAnexo("Descr")
                    drTermino("Opcompra") = drAnexo("Opcion")
                    drTermino("Ivaop") = drAnexo("Ivaopcion")
                    dtTermina.Rows.Add(drTermino)
                End If

            Next

            dsAgil.Tables.Remove("Termina")
            dsAgil.Tables.Add(dtTermina)

            ' Descomentar la siguiente línea cuando necesitemos modificar el reporte rptTermimes
            ' dsAgil.WriteXml("C:\Schema14.xml", XmlWriteMode.WriteSchema)

            newrptTermiMes.SummaryInfo.ReportComments = "REPORTE DE CONTRATOS QUE TERMINARON DURANTE EL MES " & Mid(Mes(cFecha), 4, 21)
            newrptTermiMes.SetDataSource(dsAgil)
            CrystalReportViewer1.ReportSource = newrptTermiMes
            CrystalReportViewer1.Visible = True

        End If

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class
