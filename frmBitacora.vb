Option Explicit On 

Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Security
Imports System.Security.Principal.WindowsIdentity


Public Class frmBitacora

    Inherits System.Windows.Forms.Form

    Protected Const TABLE_NAME As String = "Bitacora"

    Dim cQuien As String
    Dim myIdentity As Principal.WindowsIdentity
    Dim cUsuario As String


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
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnInsert As System.Windows.Forms.Button
    Friend WithEvents btnModif As System.Windows.Forms.Button
    Friend WithEvents gbDatos As System.Windows.Forms.GroupBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtResp As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents lblClientes As System.Windows.Forms.Label
    Friend WithEvents btnConsulta As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtComo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnInsert = New System.Windows.Forms.Button
        Me.btnModif = New System.Windows.Forms.Button
        Me.gbDatos = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtResp = New System.Windows.Forms.TextBox
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.btnSave = New System.Windows.Forms.Button
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.lblClientes = New System.Windows.Forms.Label
        Me.btnConsulta = New System.Windows.Forms.Button
        Me.txtComo = New System.Windows.Forms.TextBox
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGrid1
        '
        Me.DataGrid1.CaptionVisible = False
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(24, 74)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(838, 296)
        Me.DataGrid1.TabIndex = 0
        Me.DataGrid1.TabStop = False
        Me.DataGrid1.Visible = False
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(24, 381)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(80, 24)
        Me.btnExit.TabIndex = 1
        Me.btnExit.Text = "Salir"
        '
        'btnInsert
        '
        Me.btnInsert.Location = New System.Drawing.Point(119, 381)
        Me.btnInsert.Name = "btnInsert"
        Me.btnInsert.Size = New System.Drawing.Size(80, 24)
        Me.btnInsert.TabIndex = 2
        Me.btnInsert.Text = "Insertar"
        '
        'btnModif
        '
        Me.btnModif.Location = New System.Drawing.Point(215, 381)
        Me.btnModif.Name = "btnModif"
        Me.btnModif.Size = New System.Drawing.Size(80, 24)
        Me.btnModif.TabIndex = 3
        Me.btnModif.Text = "Modificar"
        '
        'gbDatos
        '
        Me.gbDatos.Controls.Add(Me.Label3)
        Me.gbDatos.Controls.Add(Me.DateTimePicker2)
        Me.gbDatos.Controls.Add(Me.Label2)
        Me.gbDatos.Controls.Add(Me.Label1)
        Me.gbDatos.Controls.Add(Me.txtResp)
        Me.gbDatos.Controls.Add(Me.DateTimePicker1)
        Me.gbDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatos.Location = New System.Drawing.Point(24, 427)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(795, 100)
        Me.gbDatos.TabIndex = 4
        Me.gbDatos.TabStop = False
        Me.gbDatos.Text = "Captura de Datos"
        Me.gbDatos.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(668, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Promesa de pago"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Enabled = False
        Me.DateTimePicker2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(668, 56)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(96, 20)
        Me.DateTimePicker2.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(119, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Respuesta"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Día llamada"
        '
        'txtResp
        '
        Me.txtResp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtResp.Location = New System.Drawing.Point(121, 56)
        Me.txtResp.MaxLength = 100
        Me.txtResp.Name = "txtResp"
        Me.txtResp.Size = New System.Drawing.Size(520, 20)
        Me.txtResp.TabIndex = 1
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Enabled = False
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(6, 56)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(96, 20)
        Me.DateTimePicker1.TabIndex = 0
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(310, 381)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(80, 24)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "Salvar"
        '
        'ComboBox1
        '
        Me.ComboBox1.Location = New System.Drawing.Point(26, 39)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(424, 21)
        Me.ComboBox1.TabIndex = 7
        Me.ComboBox1.Text = "ComboBox1"
        '
        'lblClientes
        '
        Me.lblClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClientes.Location = New System.Drawing.Point(23, 18)
        Me.lblClientes.Name = "lblClientes"
        Me.lblClientes.Size = New System.Drawing.Size(432, 16)
        Me.lblClientes.TabIndex = 8
        Me.lblClientes.Text = "Selecciona un Cliente de la siguiente Lista"
        '
        'btnConsulta
        '
        Me.btnConsulta.Location = New System.Drawing.Point(471, 36)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(80, 24)
        Me.btnConsulta.TabIndex = 9
        Me.btnConsulta.Text = "Consultar"
        '
        'txtComo
        '
        Me.txtComo.Location = New System.Drawing.Point(444, 386)
        Me.txtComo.Name = "txtComo"
        Me.txtComo.Size = New System.Drawing.Size(8, 20)
        Me.txtComo.TabIndex = 10
        Me.txtComo.Visible = False
        '
        'frmBitacora
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(880, 544)
        Me.Controls.Add(Me.txtComo)
        Me.Controls.Add(Me.btnConsulta)
        Me.Controls.Add(Me.lblClientes)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.gbDatos)
        Me.Controls.Add(Me.btnModif)
        Me.Controls.Add(Me.btnInsert)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.DataGrid1)
        Me.Name = "frmBitacora"
        Me.Text = "Seguimiento de Cobranza"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub frmBitacora_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daClientes As New SqlDataAdapter(cm1)
        Dim dsAgil As New DataSet()

        myIdentity = GetCurrent()
        cUsuario = myIdentity.Name
        cQuien = ""

        Select Case cUsuario
            Case "AGIL\rafael-diaz"
                cQuien = "RAFAEL DIAZ"
            Case "AGIL\jonathan-hernandez"
                cQuien = "JONATHAN SAUL"
            Case "AGIL\miguel-leal"
                cQuien = "MIGUEL LEAL"
            Case "AGIL\luis-manuel"
                cQuien = "LUIS MANUEL"
            Case "AGIL\miguel-ramirez"
                cQuien = "MIGUEL RAMIREZ"
            Case "AGIL\renato-manuel"
                cQuien = "RENATO MANUEL"
            Case "AGIL\gisela-vazquez"
                cQuien = "GISELA VAZQUEZ"
            Case "AGIL\geraldo-garcia"
                cQuien = "GERALDO GARCIA"
            Case "AGIL\juan-carlos"
                cQuien = "JUAN CARLOS"
            Case "AGIL\erick-bedolla"
                cQuien = "ERICK BEDOLLA"
            Case "AGIL\laura-hernandez"
                cQuien = "LAURA HERNANDEZ"
            Case "AGIL\yenni-hernandez"
                cQuien = "YENNI HERNANDEZ"
            Case "AGIL\eduwijes-trujillo"
                cQuien = "EDUWIJES TRUJILLO"
            Case "AGIL\julio-lugo"
                cQuien = "JULIO ALBERTO LUGO"
        End Select

        ' Este Stored Procedure trae TODOS los clientes que existan en la tabla Clientes sin importar 
        ' si tienen o no contratos o solicitudes generadas

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "ContClie1"
            .Connection = cnAgil
        End With

        ComboBox1.MaxDropDownItems = 35

        Try

            ' Llenar el DataSet a través del DataAdapter lo cual abre y cierra la conexión

            daClientes.Fill(dsAgil, "Clientes")

            ' Ligar la tabla Clientes del dataset dsAgil al ComboBox

            ComboBox1.DataSource = dsAgil
            ComboBox1.DisplayMember = Trim("Clientes.Descr")
            ComboBox1.ValueMember = "Clientes.Cliente"

            btnInsert.Enabled = False
            btnModif.Enabled = False

        Catch eException As Exception

            MsgBox(eException.Source & " " & eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")

        End Try

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        Dim cCliente As String

        If Not ComboBox1.SelectedValue Is Nothing Then

            cCliente = ComboBox1.SelectedValue.ToString()

        End If

    End Sub

    Private Sub BindDataGrid()

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daBitac As New SqlDataAdapter(cm1)
        Dim da2 As New SqlDataAdapter
        Dim dsAgil As New DataSet()

        ' Declaración de variables de datos

        Dim cCliente As String
        Dim nCount As Integer

        cCliente = ComboBox1.SelectedValue.ToString()

        ' Con este Stored Procedure obtengo los renglones insertados en la bitacora
        ' para este cliente

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "TraeBitacora"
            .Connection = cnAgil
            .Parameters.Add("@Cliente", SqlDbType.NVarChar)
            .Parameters(0).Value = cCliente
        End With
        daBitac.Fill(dsAgil, "Bitacora")
        nCount = dsAgil.Tables("Bitacora").Rows.Count

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

            MsgBox("No se tiene bitácora de este Cliente, inserte un renglón por favor", MsgBoxStyle.Information, "Mensaje del Sistema")

            DataGrid1.Visible = False

        Else

            DataGrid1.Visible = True
            DataGrid1.DataSource = dsAgil.Tables("Bitacora")
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
            .CaptionText = "Seguimiento de Cobranza"
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
            .HeaderText = "Persona que llamó"
            .MappingName = "Hablo"
            .Width = 150
        End With

        Dim grdColStyle2 As New DataGridTextBoxColumn()

        With grdColStyle2
            .HeaderText = "Día llamada"
            .MappingName = "Fhablo"
            .Width = 100
            .Alignment = HorizontalAlignment.Center
        End With

        Dim grdColStyle3 As New DataGridTextBoxColumn()

        With grdColStyle3
            .HeaderText = "Respuesta que se obtuvo con la llamada"
            .MappingName = "Resultado"
            .Width = 450
            .ReadOnly = True
        End With

        Dim grdColStyle4 As New DataGridTextBoxColumn()
        With grdColStyle4
            .HeaderText = "Promesa de pago"
            .MappingName = "Fpago"
            .Width = 100
            .Alignment = HorizontalAlignment.Center
        End With

        ' Agregar el estilo de la columnas al DataGrid 

        grdTableStyle1.GridColumnStyles.AddRange _
            (New DataGridColumnStyle() _
            {grdColStyle1, grdColStyle2, grdColStyle3, grdColStyle4})
        DataGrid1.TableStyles.Add(grdTableStyle1)

    End Sub

    Private Sub btnInsert_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInsert.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim strInsert As String

        Dim cFecha As String
        Dim cCliente As String

        cCliente = ComboBox1.SelectedValue.ToString()
        cFecha = DTOC(Today)

        txtComo.Text = "I"

        cnAgil.Open()
        strInsert = "INSERT INTO Bitacora(Cliente, Hablo, Fecha, Resultado, Fpromesa)"
        strInsert = strInsert & " VALUES ('" & cCliente & "', '" & cQuien & "', '"
        strInsert = strInsert & cFecha & "', '"
        strInsert = strInsert & Space(0) & "', '"
        strInsert = strInsert & Space(0) & "')"
        cm1 = New SqlCommand(strInsert, cnAgil)
        cm1.ExecuteNonQuery()
        cnAgil.Close()

        BindDataGrid()
        DataGrid1.Refresh()
        DateTimePicker1.Value = DataGrid1.Item(DataGrid1.CurrentRowIndex, 1)
        If DataGrid1.Item(DataGrid1.CurrentRowIndex, 3) <> "  /  /    " Then
            DateTimePicker2.Value = DataGrid1.Item(DataGrid1.CurrentRowIndex, 3)
            txtResp.Text = DataGrid1.Item(DataGrid1.CurrentRowIndex, 2)
        Else
            DateTimePicker2.Value = Today
            txtResp.Text = ""
        End If
        DateTimePicker1.Enabled = True
        DateTimePicker2.Enabled = True
        gbDatos.Visible = True
        btnInsert.Enabled = False
        btnModif.Enabled = False
        btnSave.Enabled = True
        txtResp.Focus()

    End Sub

    Private Sub btnModif_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModif.Click
        gbDatos.Visible = True
        btnInsert.Enabled = False
        btnModif.Enabled = False
        btnSave.Enabled = True
        txtComo.Text = "M"

        DateTimePicker1.Value = DataGrid1.Item(DataGrid1.CurrentRowIndex, 1)
        If DataGrid1.Item(DataGrid1.CurrentRowIndex, 3) <> "  /  /    " Then
            DateTimePicker2.Value = DataGrid1.Item(DataGrid1.CurrentRowIndex, 3)
            txtResp.Text = DataGrid1.Item(DataGrid1.CurrentRowIndex, 2)
        Else
            DateTimePicker2.Value = Today
            txtResp.Text = ""
        End If
        DateTimePicker2.Enabled = True
        txtResp.Focus()
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim strUpdate As String

        ' Declaración de variables de datos

        Dim cFecha As String
        Dim cCliente As String

        cCliente = ComboBox1.SelectedValue.ToString()
        cFecha = Mid(DataGrid1.Item(DataGrid1.CurrentRowIndex, 1), 7, 4) & Mid(DataGrid1.Item(DataGrid1.CurrentRowIndex, 1), 4, 2) & Mid(DataGrid1.Item(DataGrid1.CurrentRowIndex, 1), 1, 2)

        If txtComo.Text = "M" Then
            strUpdate = "UPDATE Bitacora SET Resultado = '" & txtResp.Text & "'"
            strUpdate = strUpdate & ", Fpromesa = '" & DTOC(DateTimePicker2.Value) & "'"
            strUpdate = strUpdate & " WHERE Fecha = '" & DTOC(DateTimePicker1.Value) & "'"
            strUpdate = strUpdate & " AND Cliente = " & "'" & cCliente & "'"
        Else
            strUpdate = "UPDATE Bitacora SET Fecha = '" & DTOC(DateTimePicker1.Value) & "'"
            strUpdate = strUpdate & ", Resultado = '" & txtResp.Text & "'"
            strUpdate = strUpdate & ", Fpromesa = '" & DTOC(DateTimePicker2.Value) & "'"
            strUpdate = strUpdate & " WHERE Fecha = '" & cFecha & "'"
            strUpdate = strUpdate & " AND Cliente = " & "'" & cCliente & "'"
        End If

        Try
            cnAgil.Open()
            cm1 = New SqlCommand(strUpdate, cnAgil)
            cm1.ExecuteNonQuery()
            BindDataGrid()
            DataGrid1.Refresh()
            cnAgil.Close()
            cnAgil = Nothing
            btnSave.Enabled = False
        Catch eException As Exception
            MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje")
        End Try
        btnInsert.Enabled = True
        btnModif.Enabled = True
        gbDatos.Visible = False
    End Sub

    Private Sub btnConsulta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsulta.Click
        DataGrid1.Visible = False
        BindDataGrid()
        If cQuien <> "" Then
            btnInsert.Enabled = True
            btnModif.Enabled = True
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

End Class
