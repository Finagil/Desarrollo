Option Explicit On 

Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Public Class frmActuaUdis

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
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnInsert As System.Windows.Forms.Button
    Friend WithEvents btnModif As System.Windows.Forms.Button
    Friend WithEvents gbDatos As System.Windows.Forms.GroupBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtUdi As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtModo As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnInsert = New System.Windows.Forms.Button
        Me.btnModif = New System.Windows.Forms.Button
        Me.gbDatos = New System.Windows.Forms.GroupBox
        Me.txtUdi = New System.Windows.Forms.TextBox
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.btnSave = New System.Windows.Forms.Button
        Me.txtModo = New System.Windows.Forms.TextBox
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGrid1
        '
        Me.DataGrid1.CaptionVisible = False
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(24, 16)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.Size = New System.Drawing.Size(208, 296)
        Me.DataGrid1.TabIndex = 0
        Me.DataGrid1.TabStop = False
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(277, 286)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(80, 24)
        Me.btnExit.TabIndex = 1
        Me.btnExit.Text = "Salir"
        '
        'btnInsert
        '
        Me.btnInsert.Location = New System.Drawing.Point(277, 154)
        Me.btnInsert.Name = "btnInsert"
        Me.btnInsert.Size = New System.Drawing.Size(80, 24)
        Me.btnInsert.TabIndex = 2
        Me.btnInsert.Text = "Insertar"
        '
        'btnModif
        '
        Me.btnModif.Location = New System.Drawing.Point(277, 198)
        Me.btnModif.Name = "btnModif"
        Me.btnModif.Size = New System.Drawing.Size(80, 24)
        Me.btnModif.TabIndex = 3
        Me.btnModif.Text = "Modificar"
        '
        'gbDatos
        '
        Me.gbDatos.Controls.Add(Me.txtUdi)
        Me.gbDatos.Controls.Add(Me.DateTimePicker1)
        Me.gbDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatos.Location = New System.Drawing.Point(256, 40)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(123, 96)
        Me.gbDatos.TabIndex = 4
        Me.gbDatos.TabStop = False
        Me.gbDatos.Text = "Captura de Datos"
        Me.gbDatos.Visible = False
        '
        'txtUdi
        '
        Me.txtUdi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUdi.Location = New System.Drawing.Point(16, 64)
        Me.txtUdi.Name = "txtUdi"
        Me.txtUdi.Size = New System.Drawing.Size(88, 20)
        Me.txtUdi.TabIndex = 1
        Me.txtUdi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Enabled = False
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(16, 24)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(96, 20)
        Me.DateTimePicker1.TabIndex = 0
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(277, 242)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(80, 24)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "Salvar"
        '
        'txtModo
        '
        Me.txtModo.Location = New System.Drawing.Point(396, 289)
        Me.txtModo.Name = "txtModo"
        Me.txtModo.Size = New System.Drawing.Size(8, 20)
        Me.txtModo.TabIndex = 6
        Me.txtModo.Text = "TextBox1"
        Me.txtModo.Visible = False
        '
        'frmActuaUdis
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(416, 326)
        Me.Controls.Add(Me.txtModo)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.gbDatos)
        Me.Controls.Add(Me.btnModif)
        Me.Controls.Add(Me.btnInsert)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.DataGrid1)
        Me.Name = "frmActuaUdis"
        Me.Text = "Actualización de Udis"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Dim dFecha As Date

    Private Sub Datos()

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As SqlConnection = New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daUdis As New SqlDataAdapter(cm1)
        Dim drUdi As DataRow
        Dim drAux As DataRow
        Dim drUdis As DataRowCollection
        Dim dsAgil As DataSet = New DataSet()
        Dim dtUdi As New DataTable("Valores")
        Dim nRows As Integer

        ' Con este Stored Procedure obtengo los valores de las udis capturadas

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "TraeUdis1"
            .Connection = cnAgil
        End With
        daUdis.Fill(dsAgil, "Udis")
        drUdis = dsAgil.Tables("Udis").Rows
        nRows = dsAgil.Tables("Udis").Rows.Count()

        dtUdi.Columns.Add("Fecha", Type.GetType("System.String"))
        dtUdi.Columns.Add("Valor", Type.GetType("System.String"))

        For Each drUdi In drUdis
            drAux = dtUdi.NewRow()
            drAux("Fecha") = CTOD(drUdi("Vigencia")).ToShortDateString
            drAux("Valor") = FormatNumber(drUdi("Udi"), 6)
            dtUdi.Rows.Add(drAux)
            dFecha = DateAdd("D", 1, CTOD(drUdi("Vigencia")).ToShortDateString)
        Next

        DataGrid1.DataSource = dtUdi
        DataGrid1.CurrentCell = New DataGridCell(nRows, nRows - 1)

        With DataGrid1
            .AlternatingBackColor = Color.GhostWhite
            .BackColor = Color.GhostWhite
            .BackgroundColor = Color.Lavender
            .BorderStyle = BorderStyle.None
            .CaptionBackColor = Color.RoyalBlue
            .CaptionFont = New Font("Tahoma", 10.0!, FontStyle.Bold)
            .CaptionForeColor = Color.Bisque
            .Font = New Font("Tahoma", 8.0!)
            .ForeColor = Color.MidnightBlue
            .GridLineColor = Color.RoyalBlue
            .HeaderBackColor = Color.MidnightBlue
            .HeaderFont = New Font("Tahoma", 8.0!, FontStyle.Bold)
            .HeaderForeColor = Color.Lavender
            .ParentRowsBackColor = Color.Lavender
            .ParentRowsForeColor = Color.MidnightBlue
            .SelectionBackColor = Color.Teal
            .SelectionForeColor = Color.PaleGreen
        End With

    End Sub

    Private Sub frmActuaUdis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Datos()
    End Sub

    Private Sub btnInsert_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInsert.Click
        gbDatos.Visible = True
        DateTimePicker1.Enabled = True
        DateTimePicker1.Value = dFecha
        btnInsert.Enabled = False
        btnModif.Enabled = False
        btnSave.Enabled = True
        txtModo.Text = "I"
        txtUdi.Text = 0
        txtUdi.Focus()
    End Sub

    Private Sub btnModif_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModif.Click
        gbDatos.Visible = True
        btnInsert.Enabled = False
        btnModif.Enabled = False
        btnSave.Enabled = True
        txtModo.Text = "M"
        DateTimePicker1.Value = DataGrid1.Item(DataGrid1.CurrentRowIndex, 0)
        txtUdi.Text = DataGrid1.Item(DataGrid1.CurrentRowIndex, 1)
        txtUdi.Focus()
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As SqlConnection = New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()

        Dim strUpdate As String
        Dim strInsert As String
        Dim cAnexo As String

        If txtModo.Text = "M" Then

            strUpdate = "UPDATE Udis SET Udi = '" & txtUdi.Text & "'"
            strUpdate = strUpdate & " WHERE Vigencia = '" & DTOC(DateTimePicker1.Value) & "'"

            'Actualizo la información que muestra el DataGrid

            DataGrid1.Item(DataGrid1.CurrentRowIndex, 1) = txtUdi.Text
            DataGrid1.Refresh()

        Else
            strInsert = "INSERT INTO Udis(Vigencia, Udi) VALUES ('" & DTOC(DateTimePicker1.Value) & _
                        "','" & txtUdi.Text & "')"
        End If

        Try
            cnAgil.Open()
            If txtModo.Text = "M" Then
                cm1 = New SqlCommand(strUpdate, cnAgil)
            Else
                cm1 = New SqlCommand(strInsert, cnAgil)
            End If
            cm1.ExecuteNonQuery()
            If txtModo.Text = "I" Then
                Datos()
                DataGrid1.Refresh()
            End If
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

    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

End Class
