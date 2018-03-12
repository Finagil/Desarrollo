Option Explicit On 

Imports System.Data.SqlClient
Imports System.Math
Imports System.IO
Imports CrystalDecisions.Shared

Public Class frmImprePol

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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbIngresos As System.Windows.Forms.RadioButton
    Friend WithEvents rbDiario As System.Windows.Forms.RadioButton
    Friend WithEvents rbOrden As System.Windows.Forms.RadioButton
    Friend WithEvents txtNumPoliza As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnVisualizar As System.Windows.Forms.Button
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents lblMensaje As System.Windows.Forms.Label
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbOrden = New System.Windows.Forms.RadioButton
        Me.rbDiario = New System.Windows.Forms.RadioButton
        Me.rbIngresos = New System.Windows.Forms.RadioButton
        Me.txtNumPoliza = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnVisualizar = New System.Windows.Forms.Button
        Me.btnSalir = New System.Windows.Forms.Button
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.lblMensaje = New System.Windows.Forms.Label
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbOrden)
        Me.GroupBox1.Controls.Add(Me.rbDiario)
        Me.GroupBox1.Controls.Add(Me.rbIngresos)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(151, 128)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo de póliza a imprimir"
        '
        'rbOrden
        '
        Me.rbOrden.Location = New System.Drawing.Point(13, 88)
        Me.rbOrden.Name = "rbOrden"
        Me.rbOrden.Size = New System.Drawing.Size(126, 24)
        Me.rbOrden.TabIndex = 2
        Me.rbOrden.Text = "Póliza de Orden"
        '
        'rbDiario
        '
        Me.rbDiario.Location = New System.Drawing.Point(13, 56)
        Me.rbDiario.Name = "rbDiario"
        Me.rbDiario.Size = New System.Drawing.Size(126, 24)
        Me.rbDiario.TabIndex = 1
        Me.rbDiario.Text = "Póliza de Diario"
        '
        'rbIngresos
        '
        Me.rbIngresos.Location = New System.Drawing.Point(13, 24)
        Me.rbIngresos.Name = "rbIngresos"
        Me.rbIngresos.Size = New System.Drawing.Size(126, 24)
        Me.rbIngresos.TabIndex = 0
        Me.rbIngresos.Text = "Póliza de Ingresos"
        '
        'txtNumPoliza
        '
        Me.txtNumPoliza.Location = New System.Drawing.Point(101, 156)
        Me.txtNumPoliza.Name = "txtNumPoliza"
        Me.txtNumPoliza.Size = New System.Drawing.Size(32, 20)
        Me.txtNumPoliza.TabIndex = 1
        Me.txtNumPoliza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(21, 156)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "No. de póliza"
        '
        'btnVisualizar
        '
        Me.btnVisualizar.Location = New System.Drawing.Point(27, 236)
        Me.btnVisualizar.Name = "btnVisualizar"
        Me.btnVisualizar.Size = New System.Drawing.Size(120, 24)
        Me.btnVisualizar.TabIndex = 3
        Me.btnVisualizar.Text = "Visualizar"
        '
        'btnSalir
        '
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.Location = New System.Drawing.Point(27, 277)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(120, 24)
        Me.btnSalir.TabIndex = 5
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(172, 18)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(840, 538)
        Me.CrystalReportViewer1.TabIndex = 6
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'lblMensaje
        '
        Me.lblMensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensaje.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblMensaje.Location = New System.Drawing.Point(12, 199)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(151, 23)
        Me.lblMensaje.TabIndex = 7
        Me.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataGrid1
        '
        Me.DataGrid1.CaptionText = "Póliza descuadrada"
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(442, 565)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.RowHeaderWidth = 20
        Me.DataGrid1.Size = New System.Drawing.Size(325, 128)
        Me.DataGrid1.TabIndex = 9
        Me.DataGrid1.Visible = False
        '
        'frmImprePol
        '
        Me.AcceptButton = Me.btnVisualizar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnSalir
        Me.ClientSize = New System.Drawing.Size(1024, 734)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.lblMensaje)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnVisualizar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNumPoliza)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmImprePol"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Impresión de Pólizas"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub frmImprePol_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        rbIngresos.Checked = True
        CrystalReportViewer1.Size = New System.Drawing.Size(840, 672)

    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daCatalogo As New SqlDataAdapter(cm1)
        Dim dsCatalogo As New DataSet()
        Dim drCatalogo As DataRow
        Dim drMovimiento As DataRow
        Dim dsMovimientos As New DataSet()
        Dim dtMovimientos As New DataTable()
        Dim dvMovimientos As DataView
        Dim dtErrores As New DataTable()
        Dim myColArray(1) As DataColumn

        ' Declaración de variables de datos

        Dim cAnexo As String
        Dim cConcepto As String
        Dim cFecha As String
        Dim cNumPoliza As String
        Dim cPoliza As String
        Dim cRenglon As String
        Dim cReportTitle As String
        Dim i As Integer
        Dim nMovimientos As Integer
        Dim nSumaAbonos As Decimal
        Dim nSumaCargos As Decimal
        Dim oPoliza As StreamReader

        ' Declaración de variables de Crystal Reports

        Dim newrptImprePol As New rptImprePol()

        ' Al iniciar maximizo el Report Viewer y oculto el DataGrid

        CrystalReportViewer1.Size = New System.Drawing.Size(840, 672)
        DataGrid1.Visible = False

        lblMensaje.Text = ""

        ' Este Stored Procedure trae todas las cuentas del Catálogo de Cuentas

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Catalogo1"
            .Connection = cnAgil
        End With

        ' Llenar el DataSet a través del DataAdapter, lo cual abre y cierra la conexión

        Try
            daCatalogo.Fill(dsCatalogo, "Catalogo")
        Catch eException As Exception
            MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")
        End Try

        ' Tengo que definir una llave primaria para la tabla Catalogo a fin de buscar una cuenta y traer su nombre

        myColArray(0) = dsCatalogo.Tables("Catalogo").Columns("Acc")
        dsCatalogo.Tables("Catalogo").PrimaryKey = myColArray

        ' Primero creo la tabla Movimientos que contendrá las columnas de la póliza

        dtMovimientos.Columns.Add("Cuenta", Type.GetType("System.String"))
        dtMovimientos.Columns.Add("Anexo", Type.GetType("System.String"))
        dtMovimientos.Columns.Add("NombreCuenta", Type.GetType("System.String"))
        dtMovimientos.Columns.Add("Cargos", Type.GetType("System.Decimal"))
        dtMovimientos.Columns.Add("Abonos", Type.GetType("System.Decimal"))

        ' Luego creo la tabla Errores que contendrá los contratos que no cuadren

        dtErrores.Columns.Add("Anexo", Type.GetType("System.String"))
        dtErrores.Columns.Add("Cargos", Type.GetType("System.Decimal"))
        dtErrores.Columns.Add("Abonos", Type.GetType("System.Decimal"))
        dtErrores.Columns.Add("Diferencia", Type.GetType("System.Decimal"))

        If rbIngresos.Checked = True Then
            cPoliza = "C:\FILES\PI" & txtNumPoliza.Text & ".TXT"
        ElseIf rbDiario.Checked = True Then
            cPoliza = "C:\FILES\PD" & txtNumPoliza.Text & ".TXT"
        ElseIf rbOrden.Checked = True Then
            cPoliza = "C:\FILES\PO" & txtNumPoliza.Text & ".TXT"
        End If

        Try

            oPoliza = New StreamReader(cPoliza)

            While (oPoliza.Peek() > -1)
                cRenglon = oPoliza.ReadLine()
                If Mid(cRenglon, 1, 1) = "P" Then
                    cFecha = Mid(cRenglon, 10, 2) & "/" & Mid(cRenglon, 8, 2) & "/" & Mid(cRenglon, 4, 4)
                    cNumPoliza = Trim(Mid(cRenglon, 17, 10))
                    cConcepto = Mid(cRenglon, 41, 50)
                    If rbIngresos.Checked = True Then
                        cReportTitle = "POLIZA DE INGRESOS No. "
                    ElseIf rbDiario.Checked = True Then
                        cReportTitle = "POLIZA DE DIARIO No. "
                    ElseIf rbOrden.Checked = True Then
                        cReportTitle = "POLIZA DE ORDEN No. "
                    End If
                    cReportTitle = cReportTitle & cNumPoliza & " DE FECHA " & cFecha & " " & cConcepto
                    newrptImprePol.SummaryInfo.ReportTitle = cReportTitle
                ElseIf Mid(cRenglon, 1, 1) = "M" Then
                    drMovimiento = dtMovimientos.NewRow()
                    drMovimiento("Cuenta") = Mid(cRenglon, 4, 4) & " " & Mid(cRenglon, 8, 2) & " " & Mid(cRenglon, 10, 2) & " " & Mid(cRenglon, 12, 4) & " " & Mid(cRenglon, 16, 4)
                    drMovimiento("Anexo") = Mid(cRenglon, 35, 10)
                    drCatalogo = dsCatalogo.Tables("Catalogo").Rows.Find(Mid(cRenglon, 4, 16))
                    If Not drCatalogo Is Nothing Then
                        drMovimiento("NombreCuenta") = drCatalogo("AccName")
                    Else
                        drMovimiento("NombreCuenta") = "***** CUENTA INEXISTENTE *****"
                    End If
                    If Mid(cRenglon, 46, 1) = "0" Then
                        drMovimiento("Cargos") = Val(Mid(cRenglon, 48, 20))
                        nSumaCargos = nSumaCargos + Val(Mid(cRenglon, 48, 20))
                        drMovimiento("Abonos") = 0
                    ElseIf Mid(cRenglon, 46, 1) = "1" Then
                        drMovimiento("Cargos") = 0
                        drMovimiento("Abonos") = Val(Mid(cRenglon, 48, 20))
                        nSumaAbonos = nSumaAbonos + Val(Mid(cRenglon, 48, 20))
                    End If
                    dtMovimientos.Rows.Add(drMovimiento)
                End If
            End While

            ' Aquí ya tengo todos los movimientos de la póliza en la tabla dtMovimientos

            oPoliza.Close()
            oPoliza = Nothing

            If nSumaCargos <> nSumaAbonos Then

                ' Si la póliza no cuadra, deberá mostrar los contratos que estén descuadrados

                CrystalReportViewer1.Size = New System.Drawing.Size(840, 538)

                dvMovimientos = New DataView(dtMovimientos)
                dvMovimientos = dtMovimientos.DefaultView
                dvMovimientos.Sort = "Anexo"
                DataGrid1.DataSource = dtMovimientos
                DataGrid1.Visible = True

                nMovimientos = dtMovimientos.Rows.Count()
                i = 0
                Do While i <= nMovimientos - 1
                    cAnexo = Mid(DataGrid1.Item(i, 1), 1, 5)
                    nSumaCargos = 0
                    nSumaAbonos = 0
                    Do While Mid(DataGrid1.Item(i, 1), 1, 5) = cAnexo
                        nSumaCargos = nSumaCargos + DataGrid1.Item(i, 3)
                        nSumaAbonos = nSumaAbonos + DataGrid1.Item(i, 4)
                        i = i + 1
                        If i > nMovimientos - 1 Then
                            Exit Do
                        End If
                    Loop
                    If nSumaCargos <> nSumaAbonos Then
                        drMovimiento = dtErrores.NewRow()
                        drMovimiento("Anexo") = cAnexo
                        drMovimiento("Cargos") = nSumaCargos
                        drMovimiento("Abonos") = nSumaAbonos
                        drMovimiento("Diferencia") = nSumaCargos - nSumaAbonos
                        dtErrores.Rows.Add(drMovimiento)
                    End If
                Loop

                DataGrid1.DataSource = dtErrores

            End If

            dsMovimientos.Tables.Add(dtMovimientos)
            ' Descomentar la siguiente línea en caso de que se deseara modificar el reporte rptImprePol
            ' dsMovimientos.WriteXml("C:\FILES\Schema6.xml", XmlWriteMode.WriteSchema)
            newrptImprePol.SetDataSource(dsMovimientos)
            CrystalReportViewer1.ReportSource = newrptImprePol
            CrystalReportViewer1.Zoom(95)

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
