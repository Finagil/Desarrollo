Option Explicit On 

Imports System.Data.SqlClient
Imports System.Math

Public Class frmActuatas

    Inherits System.Windows.Forms.Form

    Dim cFecha As String

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
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTIIE As System.Windows.Forms.TextBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents txtPromedioTIIE As System.Windows.Forms.TextBox
    Friend WithEvents btnPromedio As System.Windows.Forms.Button
    Friend WithEvents txtCrea As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtTIIE = New System.Windows.Forms.TextBox
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.btnProcesar = New System.Windows.Forms.Button
        Me.txtCrea = New System.Windows.Forms.TextBox
        Me.txtPromedioTIIE = New System.Windows.Forms.TextBox
        Me.btnPromedio = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(56, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "TIIE"
        '
        'txtTIIE
        '
        Me.txtTIIE.Enabled = False
        Me.txtTIIE.Location = New System.Drawing.Point(136, 107)
        Me.txtTIIE.Name = "txtTIIE"
        Me.txtTIIE.Size = New System.Drawing.Size(100, 20)
        Me.txtTIIE.TabIndex = 5
        Me.txtTIIE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(242, 171)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 8
        Me.btnExit.Text = "Salir"
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(56, 171)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "Guardar"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(56, 32)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(88, 20)
        Me.DateTimePicker1.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(72, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 16)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "FECHA"
        '
        'btnProcesar
        '
        Me.btnProcesar.Location = New System.Drawing.Point(160, 31)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(80, 23)
        Me.btnProcesar.TabIndex = 1
        Me.btnProcesar.Text = "Procesar"
        '
        'txtCrea
        '
        Me.txtCrea.Location = New System.Drawing.Point(256, 32)
        Me.txtCrea.Name = "txtCrea"
        Me.txtCrea.Size = New System.Drawing.Size(8, 20)
        Me.txtCrea.TabIndex = 24
        Me.txtCrea.Text = "TextBox1"
        Me.txtCrea.Visible = False
        '
        'txtPromedioTIIE
        '
        Me.txtPromedioTIIE.Location = New System.Drawing.Point(242, 107)
        Me.txtPromedioTIIE.Name = "txtPromedioTIIE"
        Me.txtPromedioTIIE.ReadOnly = True
        Me.txtPromedioTIIE.Size = New System.Drawing.Size(100, 20)
        Me.txtPromedioTIIE.TabIndex = 25
        Me.txtPromedioTIIE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnPromedio
        '
        Me.btnPromedio.Enabled = False
        Me.btnPromedio.Location = New System.Drawing.Point(143, 171)
        Me.btnPromedio.Name = "btnPromedio"
        Me.btnPromedio.Size = New System.Drawing.Size(86, 23)
        Me.btnPromedio.TabIndex = 26
        Me.btnPromedio.Text = "Promedio TIIE"
        '
        'frmActuatas
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(394, 238)
        Me.Controls.Add(Me.btnPromedio)
        Me.Controls.Add(Me.txtPromedioTIIE)
        Me.Controls.Add(Me.txtCrea)
        Me.Controls.Add(Me.btnProcesar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.txtTIIE)
        Me.Controls.Add(Me.Label4)
        Me.Name = "frmActuatas"
        Me.Text = "Captura diaria de la tasa TIIE"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub btnProcesar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProcesar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daTasas As New SqlDataAdapter(cm1)
        Dim drTasa As DataRow
        Dim drTasas As DataRowCollection
        Dim dsAgil As New DataSet()

        cFecha = DTOC(DateTimePicker1.Value)
        txtCrea.Text = False

        ' Con este Stored Procedure obtengo los valores de las tasas solicitadas
        ' de acuerdo a la fecha indicada

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "ActuaTas1"
            .Connection = cnAgil
            .Parameters.Add("@Fecha", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With
        daTasas.Fill(dsAgil, "Tasas")

        drTasas = dsAgil.Tables("Tasas").Rows

        If dsAgil.Tables("Tasas").Rows.Count > 0 Then
            For Each drTasa In drTasas
                If drTasa("Tasa") = "4" Then
                    txtTIIE.Text = FormatNumber(drTasa("Valor"), 4)
                End If
            Next
        Else
            txtTIIE.Text = FormatNumber(0, 4)
            txtCrea.Text = True
        End If

        txtTIIE.Enabled = True
        btnSave.Enabled = True
        btnPromedio.Enabled = True

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim strInsert As String
        Dim strUpdate As String

        Try
            If txtCrea.Text = True Then
                cnAgil.Open()
                strInsert = "INSERT INTO Hista(Tasa, Vigencia, Valor) VALUES ('4', '"
                strInsert = strInsert & cFecha & "', '"
                strInsert = strInsert & txtTIIE.Text & "')"
                cm1 = New SqlCommand(strInsert, cnAgil)
                cm1.ExecuteNonQuery()
                cnAgil.Close()
            Else
                cnAgil.Open()
                strUpdate = "UPDATE Hista SET Valor = " & "'" & txtTIIE.Text & "'"
                strUpdate = strUpdate & " WHERE Vigencia = " & "'" & cFecha & "'"
                strUpdate = strUpdate & " AND Tasa = '4'"
                cm1 = New SqlCommand(strUpdate, cnAgil)
                cm1.ExecuteNonQuery()
                cnAgil.Close()
            End If
            txtTIIE.Enabled = False
            btnSave.Enabled = False
        Catch eException As Exception
            MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de error")
        End Try

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub btnPromedio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPromedio.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim dsAgil As New DataSet()
        Dim daTasas As New SqlDataAdapter(cm1)
        Dim drTasa As DataRow

        ' Declaración de variables de datos

        Dim nYear As Integer
        Dim nMes As Integer
        Dim nDiasmes As Integer
        Dim nPromedio As Decimal
        Dim cFecha As String

        cFecha = Mid(DTOC(DateTimePicker1.Value), 1, 6)
        nYear = Year(DateTimePicker1.Value)
        nMes = Month(DateTimePicker1.Value)
        nDiasmes = DateTime.DaysInMonth(nYear, nMes)

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Sumatiie"
            .Connection = cnAgil
            .Parameters.Add("@Fecha", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With
        daTasas.Fill(dsAgil, "Valor")
        drTasa = dsAgil.Tables("Valor").Rows(0)
        nPromedio = Round(drTasa("Monto") / nDiasmes, 4)
        txtPromedioTIIE.Text = nPromedio

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

End Class
