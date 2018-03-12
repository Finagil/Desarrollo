Option Explicit On 

Imports System.Data.SqlClient

Public Class frmCaptFact

    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal cAnexo As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        txtAnexo.Text = cAnexo
        Me.Text = "Facturas Originales del Contrato " & cAnexo
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtFactura As System.Windows.Forms.TextBox
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents txtSerie As System.Windows.Forms.TextBox
    Friend WithEvents txtMotor As System.Windows.Forms.TextBox
    Friend WithEvents txtImporte As System.Windows.Forms.TextBox
    Friend WithEvents btnAltaFact As System.Windows.Forms.Button
    Friend WithEvents btnCambioFact As System.Windows.Forms.Button
    Friend WithEvents btnVerDet As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents txtAnexo As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtImpant As System.Windows.Forms.TextBox
    Friend WithEvents btnIgnorar As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents mtxtModelo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDetalle As System.Windows.Forms.RichTextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.mtxtModelo = New System.Windows.Forms.MaskedTextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtDetalle = New System.Windows.Forms.RichTextBox
        Me.btnIgnorar = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtImporte = New System.Windows.Forms.TextBox
        Me.txtMotor = New System.Windows.Forms.TextBox
        Me.txtSerie = New System.Windows.Forms.TextBox
        Me.txtProveedor = New System.Windows.Forms.TextBox
        Me.txtFactura = New System.Windows.Forms.TextBox
        Me.btnAltaFact = New System.Windows.Forms.Button
        Me.btnCambioFact = New System.Windows.Forms.Button
        Me.btnVerDet = New System.Windows.Forms.Button
        Me.btnSalir = New System.Windows.Forms.Button
        Me.txtAnexo = New System.Windows.Forms.TextBox
        Me.txtImpant = New System.Windows.Forms.TextBox
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.Panel1.SuspendLayout()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.mtxtModelo)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.txtDetalle)
        Me.Panel1.Controls.Add(Me.btnIgnorar)
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtImporte)
        Me.Panel1.Controls.Add(Me.txtMotor)
        Me.Panel1.Controls.Add(Me.txtSerie)
        Me.Panel1.Controls.Add(Me.txtProveedor)
        Me.Panel1.Controls.Add(Me.txtFactura)
        Me.Panel1.Location = New System.Drawing.Point(16, 264)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(696, 224)
        Me.Panel1.TabIndex = 0
        '
        'mtxtModelo
        '
        Me.mtxtModelo.BeepOnError = True
        Me.mtxtModelo.Location = New System.Drawing.Point(639, 88)
        Me.mtxtModelo.Name = "mtxtModelo"
        Me.mtxtModelo.Size = New System.Drawing.Size(31, 20)
        Me.mtxtModelo.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(17, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(656, 23)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "En el campo ""Importe"" debes capturar el valor total de cada una de las facturas"
        '
        'txtDetalle
        '
        Me.txtDetalle.Location = New System.Drawing.Point(136, 120)
        Me.txtDetalle.Name = "txtDetalle"
        Me.txtDetalle.Size = New System.Drawing.Size(536, 88)
        Me.txtDetalle.TabIndex = 6
        Me.txtDetalle.TabStop = False
        Me.txtDetalle.Text = ""
        '
        'btnIgnorar
        '
        Me.btnIgnorar.Location = New System.Drawing.Point(24, 184)
        Me.btnIgnorar.Name = "btnIgnorar"
        Me.btnIgnorar.Size = New System.Drawing.Size(75, 23)
        Me.btnIgnorar.TabIndex = 15
        Me.btnIgnorar.Text = "No Guardar"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(24, 144)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 14
        Me.btnSave.Text = "Guardar"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(520, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 20)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Importe"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(16, 112)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 20)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Descripción del Bien"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(588, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 20)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Modelo"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(323, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 20)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "No. de Motor"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "No. de Serie"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Proveedor"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Factura No."
        '
        'txtImporte
        '
        Me.txtImporte.Location = New System.Drawing.Point(573, 40)
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.Size = New System.Drawing.Size(100, 20)
        Me.txtImporte.TabIndex = 1
        '
        'txtMotor
        '
        Me.txtMotor.Location = New System.Drawing.Point(401, 88)
        Me.txtMotor.Name = "txtMotor"
        Me.txtMotor.Size = New System.Drawing.Size(145, 20)
        Me.txtMotor.TabIndex = 4
        '
        'txtSerie
        '
        Me.txtSerie.Location = New System.Drawing.Point(136, 88)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(151, 20)
        Me.txtSerie.TabIndex = 3
        '
        'txtProveedor
        '
        Me.txtProveedor.Location = New System.Drawing.Point(136, 64)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(536, 20)
        Me.txtProveedor.TabIndex = 2
        '
        'txtFactura
        '
        Me.txtFactura.Location = New System.Drawing.Point(136, 40)
        Me.txtFactura.Name = "txtFactura"
        Me.txtFactura.Size = New System.Drawing.Size(100, 20)
        Me.txtFactura.TabIndex = 0
        '
        'btnAltaFact
        '
        Me.btnAltaFact.Location = New System.Drawing.Point(24, 224)
        Me.btnAltaFact.Name = "btnAltaFact"
        Me.btnAltaFact.Size = New System.Drawing.Size(136, 23)
        Me.btnAltaFact.TabIndex = 12
        Me.btnAltaFact.Text = "Alta Factura"
        '
        'btnCambioFact
        '
        Me.btnCambioFact.Location = New System.Drawing.Point(176, 224)
        Me.btnCambioFact.Name = "btnCambioFact"
        Me.btnCambioFact.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnCambioFact.Size = New System.Drawing.Size(136, 23)
        Me.btnCambioFact.TabIndex = 13
        Me.btnCambioFact.Text = "Modificar Factura"
        '
        'btnVerDet
        '
        Me.btnVerDet.Location = New System.Drawing.Point(328, 224)
        Me.btnVerDet.Name = "btnVerDet"
        Me.btnVerDet.Size = New System.Drawing.Size(136, 23)
        Me.btnVerDet.TabIndex = 14
        Me.btnVerDet.Text = "Ver Detalle"
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(480, 224)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(136, 23)
        Me.btnSalir.TabIndex = 15
        Me.btnSalir.Text = "Salir"
        '
        'txtAnexo
        '
        Me.txtAnexo.Location = New System.Drawing.Point(696, 224)
        Me.txtAnexo.Name = "txtAnexo"
        Me.txtAnexo.Size = New System.Drawing.Size(8, 20)
        Me.txtAnexo.TabIndex = 16
        Me.txtAnexo.Visible = False
        '
        'txtImpant
        '
        Me.txtImpant.Location = New System.Drawing.Point(680, 224)
        Me.txtImpant.Name = "txtImpant"
        Me.txtImpant.Size = New System.Drawing.Size(8, 20)
        Me.txtImpant.TabIndex = 17
        Me.txtImpant.Visible = False
        '
        'DataGrid1
        '
        Me.DataGrid1.CaptionVisible = False
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(15, 28)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(696, 184)
        Me.DataGrid1.TabIndex = 18
        Me.DataGrid1.TabStop = False
        Me.DataGrid1.Visible = False
        '
        'frmCaptFact
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(728, 510)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.txtImpant)
        Me.Controls.Add(Me.txtAnexo)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnVerDet)
        Me.Controls.Add(Me.btnCambioFact)
        Me.Controls.Add(Me.btnAltaFact)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmCaptFact"
        Me.Text = "Facturas Originales"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Protected Const TABLE_NAME As String = "DatosFac"
    Dim cAnexo As String
    Dim dtAuxiliar As New DataTable("Actiaux")
    Dim lCambio As Boolean

    Private Sub frmCaptFact_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BindDataGrid()
    End Sub

    Private Sub BindDataGrid()

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim dsAgil As New DataSet()
        Dim myColArray(1) As DataColumn
        Dim drActifijo As DataRow
        Dim drAnexo As DataRow
        Dim drActi As DataRow
        Dim drDatoActifij As DataRowCollection
        Dim daDatosActi As New SqlDataAdapter(cm1)
        Dim dtMostrar As New DataTable("DatosFac")

        ' Declaración de variables de datos

        Dim cFactura As String
        Dim cProveed As String
        Dim cImporte As String
        Dim cFactact As String
        Dim nFactact As Decimal
        Dim nImpTotal As Decimal
        Dim nCount As Integer

        cAnexo = Mid(txtAnexo.Text, 1, 5) & Mid(txtAnexo.Text, 7, 10)

        ' Este Stored Procedure trae TODOS los datos de Actifijo de la tabla Actifijo

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DatosEquipo1"
            .Connection = cnAgil
            .Parameters.Add("@Anexo", SqlDbType.NVarChar)
            .Parameters(0).Value = cAnexo
        End With

        ' Buscar a dicho cliente en el DataSet y retornar sus datos en el DataRow

        daDatosActi.Fill(dsAgil, "ActiFijo")
        drDatoActifij = dsAgil.Tables("ActiFijo").Rows

        Panel1.Visible = False

        nImpTotal = 0

        ' Primero creo la tabla dtMostrar que desplegara la información de las
        ' facturas de Activo Fijo

        dtMostrar.Columns.Add("Factura", Type.GetType("System.String"))
        dtMostrar.Columns.Add("Proveedor", Type.GetType("System.String"))
        dtMostrar.Columns.Add("Importe", Type.GetType("System.Decimal"))
        dtMostrar.Columns.Add("Fac.Activo", Type.GetType("System.String"))

        For Each drActifijo In drDatoActifij
            cFactura = drActifijo("Factura")
            cProveed = drActifijo("Proveedor")
            cImporte = FormatNumber(drActifijo("Importe")).ToString
            nFactact = drActifijo("FactFij")
            cFactact = nFactact.ToString
            nImpTotal += drActifijo("Importe")

            drActi = dtMostrar.NewRow()
            drActi("Factura") = cFactura
            drActi("Proveedor") = cProveed
            drActi("Importe") = drActifijo("Importe")
            drActi("Fac.Activo") = cFactact
            dtMostrar.Rows.Add(drActi)

        Next
        dsAgil.Tables.Add(dtMostrar)

        nCount = dsAgil.Tables("DatosFac").Rows.Count

        If Not IsNothing(dsAgil.Tables(TABLE_NAME)) Then

            ' Limpia el existente estilo de la tabla.

            With DataGrid1
                .BackgroundColor = SystemColors.InactiveCaptionText
                .CaptionText = ""
                .CaptionBackColor = SystemColors.ActiveCaption
                .TableStyles.Clear()
                .ResetAlternatingBackColor()
                .ResetBackColor()
                .ResetForeColor()
                .ResetGridLineColor()
                .ResetHeaderBackColor()
                .ResetHeaderFont()
                .ResetHeaderForeColor()
                .ResetSelectionBackColor()
                .ResetSelectionForeColor()
                .ResetText()
            End With

        End If

        If nCount = 0 Then

            MsgBox("No se han capturado Facturas para este Contrato, inserte un renglón por favor", MsgBoxStyle.Information, "Mensaje del Sistema")

            DataGrid1.Visible = False

        Else

            DataGrid1.Visible = True
            DataGrid1.DataSource = dsAgil.Tables("DatosFac")
            DataGrid1.CurrentCell = New DataGridCell(nCount - 1, nCount - 1)
            FormatGridWithBothTableAndColumnStyles()

        End If

    End Sub

    Private Sub FormatGridWithBothTableAndColumnStyles()

        ' Contiene las propiedades del DataGrid pero seran modificadas
        ' en el propiedades del DataGridTableStyle.

        With DataGrid1
            .BackColor = Color.GhostWhite
            .BackgroundColor = Color.Lavender
            .BorderStyle = BorderStyle.None
            .CaptionBackColor = Color.RoyalBlue
            .CaptionFont = New Font("Tahoma", 10.0!, FontStyle.Bold)
            .CaptionForeColor = Color.Bisque
            .CaptionText = "Captura de Facturas Originales"
            .Font = New Font("Tahoma", 8.0!)
            .ParentRowsBackColor = Color.Lavender
            .ParentRowsForeColor = Color.MidnightBlue
            .SelectionBackColor = Color.Teal
            .SelectionForeColor = Color.PaleGreen
        End With

        ' Proporcionamos el formato que deseamos se muestre en el Grid para 
        ' cada una de sus celdas.

        Dim grdTableStyle1 As New DataGridTableStyle()

        With grdTableStyle1
            .AlternatingBackColor = Color.GhostWhite
            .BackColor = Color.GhostWhite
            .ForeColor = Color.MidnightBlue
            .GridLineColor = Color.RoyalBlue
            .HeaderBackColor = Color.MidnightBlue
            .HeaderFont = New Font("Tahoma", 8.0!, FontStyle.Bold)
            .HeaderForeColor = Color.Lavender
            .SelectionBackColor = Color.Teal
            .SelectionForeColor = Color.PaleGreen
            .MappingName = TABLE_NAME
            .PreferredColumnWidth = 125
            .PreferredRowHeight = 15
            .SelectionBackColor = Color.Teal
            .SelectionForeColor = Color.PaleGreen
        End With

        ' Formato asignado a cada una de las celdas del DataGrid.

        Dim grdColStyle1 As New DataGridTextBoxColumn()

        With grdColStyle1
            .HeaderText = "Factura   ."
            .MappingName = "Factura"
            .Width = 70
            .Alignment = HorizontalAlignment.Right
        End With

        Dim grdColStyle2 As New DataGridTextBoxColumn()

        With grdColStyle2
            .HeaderText = "Nombre del Proveedor"
            .MappingName = "Proveedor"
            .Width = 400
            .Alignment = HorizontalAlignment.Left
        End With

        Dim grdColStyle3 As New DataGridTextBoxColumn()

        With grdColStyle3
            .HeaderText = "Importe   ."
            .MappingName = "Importe"
            .Format = "C"
            .Width = 90
            .Alignment = HorizontalAlignment.Right
            .ReadOnly = True
        End With

        Dim grdColStyle4 As New DataGridTextBoxColumn()
        With grdColStyle4
            .HeaderText = "F. Activo   ."
            .MappingName = "Fac.Activo"
            .Width = 80
            .Alignment = HorizontalAlignment.Right
        End With

        ' Agregar el estilo de la columnas al DataGrid 

        grdTableStyle1.GridColumnStyles.AddRange _
            (New DataGridColumnStyle() _
            {grdColStyle1, grdColStyle2, grdColStyle3, grdColStyle4})
        DataGrid1.TableStyles.Add(grdTableStyle1)

    End Sub

    Private Sub btnAltaFact_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAltaFact.Click

        txtFactura.Text = " "
        txtProveedor.Text = " "
        txtImporte.Text = 0
        txtSerie.Text = " "
        txtMotor.Text = " "
        mtxtModelo.Clear()
        mtxtModelo.Mask = "0000"
        txtDetalle.Text = " "
        Panel1.Visible = True
        txtDetalle.Visible = True
        btnAltaFact.Enabled = False
        btnCambioFact.Enabled = False
        btnVerDet.Enabled = False
        btnSalir.Enabled = False

        If btnIgnorar.Text = "Regresar" Then
            btnSave.Visible = True
            btnIgnorar.Text = "Ignorar"
            txtFactura.ReadOnly = False
            txtImporte.ReadOnly = False
            txtProveedor.ReadOnly = False
            txtSerie.ReadOnly = False
            txtMotor.ReadOnly = False
            mtxtModelo.ReadOnly = False
            txtDetalle.ReadOnly = False
        End If
        lCambio = True

    End Sub

    Private Sub btnCambioFact_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCambioFact.Click

        ' Declaración de variables de conexión ADO .NET

        Dim strUpdate As String
        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim dsAgil As New DataSet()
        Dim daActiaux As New SqlDataAdapter(cm1)
        Dim drActiaux As DataRow
        Dim drActiauxs As DataRowCollection

        ' Declaración de variables de datos

        Dim cFactura As String
        Dim cFactsele As String
        Dim cProveed As String
        Dim cImporte As String
        Dim nFactact As String
        Dim cFactact As String
        Dim cCadena As String

        Panel1.Visible = True
        cFactsele = cAnexo & DataGrid1.Item(DataGrid1.CurrentRowIndex, 0)

        ' El siguiente Stored Procedure trae TODOS los datos del equipo financiado de la tabla ActiFijo

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DatosEquipo1"
            .Connection = cnAgil
            .Parameters.Add("@Anexo", SqlDbType.NVarChar)
            .Parameters(0).Value = cAnexo
        End With

        Try
            daActiaux.Fill(dsAgil, "ActiFijo")
            drActiauxs = dsAgil.Tables("ActiFijo").Rows
        Catch eException As Exception
            MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")
        End Try

        For Each drActiaux In drActiauxs
            cFactura = drActiaux("Factura")
            cProveed = drActiaux("Proveedor")
            cImporte = FormatNumber(drActiaux("Importe")).ToString
            nFactact = drActiaux("FactFij")
            cFactact = nFactact.ToString
            cCadena = cAnexo & cFactura

            If cCadena = cFactsele Then
                txtAnexo.Text = drActiaux("Factura")
                txtImpant.Text = drActiaux("Importe")
                txtFactura.Text = drActiaux("Factura")
                txtProveedor.Text = drActiaux("Proveedor")
                txtImporte.Text = drActiaux("Importe")
                txtSerie.Text = drActiaux("Serie")
                txtMotor.Text = drActiaux("Motor")
                mtxtModelo.Text = drActiaux("Modelo")
                txtDetalle.Text = drActiaux("Detalle")
                Exit For
            End If
        Next
        lCambio = False
        Panel1.Visible = True
        btnSave.Visible = False
        txtDetalle.Visible = True
        btnSave.Visible = True
        btnAltaFact.Enabled = False
        btnCambioFact.Enabled = False
        btnVerDet.Enabled = False
        btnSalir.Enabled = False

        If btnIgnorar.Text = "Regresar" Then
            btnIgnorar.Text = "Ignorar"
            txtFactura.ReadOnly = False
            txtImporte.ReadOnly = False
            txtProveedor.ReadOnly = False
            txtSerie.ReadOnly = False
            txtMotor.ReadOnly = False
            mtxtModelo.ReadOnly = False
            txtDetalle.ReadOnly = False
        End If

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub btnVerDet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVerDet.Click

        ' Declaración de variables de conexión ADO .NET

        Dim strUpdate As String
        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim dsAgil As New DataSet()
        Dim daActiaux As New SqlDataAdapter(cm1)
        Dim drActiaux As DataRow
        Dim drActiauxs As DataRowCollection

        ' Declaración de variables de datos

        Dim cFactura As String
        Dim cFactsele As String
        Dim cProveed As String
        Dim cImporte As String
        Dim nFactact As String
        Dim cFactact As String
        Dim cCadena As String

        cFactsele = cAnexo & DataGrid1.Item(DataGrid1.CurrentRowIndex, 0)

        ' El siguiente Stored Procedure trae TODOS los datos del equipo financiado de la tabla ActiFijo

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DatosEquipo1"
            .Connection = cnAgil
            .Parameters.Add("@Anexo", SqlDbType.NVarChar)
            .Parameters(0).Value = cAnexo
        End With

        Try
            daActiaux.Fill(dsAgil, "ActiFijo")
            drActiauxs = dsAgil.Tables("ActiFijo").Rows

            For Each drActiaux In drActiauxs
                cFactura = drActiaux("Factura")
                cProveed = drActiaux("Proveedor")
                cImporte = FormatNumber(drActiaux("Importe")).ToString
                nFactact = drActiaux("FactFij")
                cFactact = nFactact.ToString
                cCadena = cAnexo & cFactura

                If cCadena = cFactsele Then
                    txtAnexo.Text = drActiaux("Factura")
                    txtImpant.Text = drActiaux("Importe")
                    txtFactura.Text = drActiaux("Factura")
                    txtProveedor.Text = drActiaux("Proveedor")
                    txtImporte.Text = FormatNumber(drActiaux("Importe"))
                    txtSerie.Text = drActiaux("Serie")
                    txtMotor.Text = drActiaux("Motor")
                    mtxtModelo.Text = drActiaux("Modelo")
                    txtDetalle.Text = drActiaux("Detalle")
                    Exit For
                End If
            Next

            btnAltaFact.Enabled = False
            btnCambioFact.Enabled = False
            btnVerDet.Enabled = False
            btnSalir.Enabled = False

            Panel1.Visible = True
            txtDetalle.Visible = True
            btnSave.Visible = False
            btnIgnorar.Text = "Regresar"
            txtFactura.ReadOnly = True
            txtImporte.ReadOnly = True
            txtProveedor.ReadOnly = True
            txtSerie.ReadOnly = True
            txtMotor.ReadOnly = True
            mtxtModelo.ReadOnly = True
            txtDetalle.ReadOnly = True

        Catch eException As Exception
            MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")
        End Try

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim dsAgil As New DataSet()
        Dim strActualiza As String
        Dim strInsert As String
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim daTotal As New SqlDataAdapter(cm2)
        Dim drTotal As DataRow

        ' Declaración de variables de datos

        Dim nSuma As Decimal

        Try
            cnAgil.Open()
            If lCambio = False Then
                strActualiza = "UPDATE Actifijo SET Anexo = " & "'" & cAnexo & "',"
                strActualiza = strActualiza & " Factura = " & " '" & txtFactura.Text & "',"
                strActualiza = strActualiza & " Proveedor = " & "'" & txtProveedor.Text & "',"
                strActualiza = strActualiza & " Importe = " & "'" & Val(txtImporte.Text) & "',"
                strActualiza = strActualiza & " Detalle = " & "'" & txtDetalle.Text & "',"
                strActualiza = strActualiza & " Modelo = " & "'" & mtxtModelo.Text & "',"
                strActualiza = strActualiza & " Motor = " & "'" & txtMotor.Text & "',"
                strActualiza = strActualiza & " Serie = " & "'" & txtSerie.Text & "'"
                strActualiza = strActualiza & "WHERE Anexo = " & "'" & cAnexo & "'"
                strActualiza = strActualiza & "And Factura = " & "'" & txtAnexo.Text & "'"
                strActualiza = strActualiza & "And Importe = " & "'" & txtImpant.Text & "'"
                cm1 = New SqlCommand(strActualiza, cnAgil)
                cm1.ExecuteNonQuery()

                DataGrid1.Item(DataGrid1.CurrentRowIndex, 0) = txtFactura.Text
                DataGrid1.Item(DataGrid1.CurrentRowIndex, 1) = txtProveedor.Text
                DataGrid1.Item(DataGrid1.CurrentRowIndex, 2) = txtImporte.Text
                DataGrid1.Refresh()

            Else
                strInsert = "INSERT INTO Actifijo(Anexo, Factura, Proveedor, Importe, Detalle, Factfij, Modelo, Motor, Serie, Asegurador, Numpoliz, Inicioseg, Vigencseg, Endoso)"
                strInsert = strInsert & " VALUES ('"
                strInsert = strInsert & cAnexo & "', '"
                strInsert = strInsert & txtFactura.Text & "', '"
                strInsert = strInsert & txtProveedor.Text & "', '"
                strInsert = strInsert & Val(txtImporte.Text) & "', '"
                strInsert = strInsert & txtDetalle.Text & "', '"
                strInsert = strInsert & Val("0") & "', '"
                strInsert = strInsert & mtxtModelo.Text & "', '"
                strInsert = strInsert & txtMotor.Text & "', '"
                strInsert = strInsert & txtSerie.Text & "', '"
                strInsert = strInsert & " " & "', '"
                strInsert = strInsert & " " & "', '"
                strInsert = strInsert & " " & "', '"
                strInsert = strInsert & " " & "', '"
                strInsert = strInsert & " " & "')"
                cm1 = New SqlCommand(strInsert, cnAgil)
                cm1.ExecuteNonQuery()
                lCambio = False

                BindDataGrid()
                DataGrid1.Refresh()
            End If
            txtDetalle.Visible = False
            Panel1.Visible = False
            btnAltaFact.Enabled = True
            btnCambioFact.Enabled = True
            btnVerDet.Enabled = True
            btnSalir.Enabled = True

            ' Obtengo el total de las Fcaturas capturadas

            With cm2
                .CommandType = CommandType.Text
                .CommandText = "SELECT Sum(Importe) as Importe FROM Actifijo GROUP BY Anexo HAVING Actifijo.Anexo = " & "'" & cAnexo & "'"
                .Connection = cnAgil
            End With
            daTotal.Fill(dsAgil, "Total")
            drTotal = dsAgil.Tables("Total").Rows(0)
            nSuma = drTotal("Importe")

        Catch eException As Exception
            MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de error")
        End Try

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()

    End Sub

    Private Sub btnIgnorar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIgnorar.Click
        Panel1.Visible = False
        txtDetalle.Visible = False
        btnAltaFact.Enabled = True
        btnCambioFact.Enabled = True
        btnVerDet.Enabled = True
        btnSalir.Enabled = True
    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class
