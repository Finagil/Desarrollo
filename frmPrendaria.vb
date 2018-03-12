Option Explicit On 

Imports System.Data.SqlClient

Public Class frmPrendaria
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal cAnexo As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        txtAnexo.Text = cAnexo
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
    Friend WithEvents txtCusnam As System.Windows.Forms.TextBox
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents lblContrato As System.Windows.Forms.Label
    Friend WithEvents lblGarantia As System.Windows.Forms.Label
    Friend WithEvents btnAlta As System.Windows.Forms.Button
    Friend WithEvents btnCambios As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents txtAnexo As System.Windows.Forms.TextBox
    Friend WithEvents txtGarantia As System.Windows.Forms.RichTextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtCusnam = New System.Windows.Forms.TextBox
        Me.lblCliente = New System.Windows.Forms.Label
        Me.lblContrato = New System.Windows.Forms.Label
        Me.lblGarantia = New System.Windows.Forms.Label
        Me.btnAlta = New System.Windows.Forms.Button
        Me.btnCambios = New System.Windows.Forms.Button
        Me.btnSalir = New System.Windows.Forms.Button
        Me.txtAnexo = New System.Windows.Forms.TextBox
        Me.txtGarantia = New System.Windows.Forms.RichTextBox
        Me.SuspendLayout()
        '
        'txtCusnam
        '
        Me.txtCusnam.Location = New System.Drawing.Point(80, 8)
        Me.txtCusnam.Name = "txtCusnam"
        Me.txtCusnam.ReadOnly = True
        Me.txtCusnam.Size = New System.Drawing.Size(536, 20)
        Me.txtCusnam.TabIndex = 0
        Me.txtCusnam.TabStop = False
        '
        'lblCliente
        '
        Me.lblCliente.Location = New System.Drawing.Point(16, 16)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(56, 16)
        Me.lblCliente.TabIndex = 7
        Me.lblCliente.Text = "Cliente"
        '
        'lblContrato
        '
        Me.lblContrato.Location = New System.Drawing.Point(16, 48)
        Me.lblContrato.Name = "lblContrato"
        Me.lblContrato.Size = New System.Drawing.Size(48, 16)
        Me.lblContrato.TabIndex = 8
        Me.lblContrato.Text = "Contrato"
        '
        'lblGarantia
        '
        Me.lblGarantia.Location = New System.Drawing.Point(16, 80)
        Me.lblGarantia.Name = "lblGarantia"
        Me.lblGarantia.Size = New System.Drawing.Size(152, 16)
        Me.lblGarantia.TabIndex = 9
        Me.lblGarantia.Text = "Descripción la(s) Garantía(s)"
        '
        'btnAlta
        '
        Me.btnAlta.Location = New System.Drawing.Point(24, 248)
        Me.btnAlta.Name = "btnAlta"
        Me.btnAlta.Size = New System.Drawing.Size(80, 24)
        Me.btnAlta.TabIndex = 10
        Me.btnAlta.Text = "Salvar"
        '
        'btnCambios
        '
        Me.btnCambios.Location = New System.Drawing.Point(141, 248)
        Me.btnCambios.Name = "btnCambios"
        Me.btnCambios.Size = New System.Drawing.Size(80, 24)
        Me.btnCambios.TabIndex = 11
        Me.btnCambios.Text = "Modificar"
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(263, 248)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(80, 24)
        Me.btnSalir.TabIndex = 12
        Me.btnSalir.Text = "Salir"
        '
        'txtAnexo
        '
        Me.txtAnexo.Location = New System.Drawing.Point(80, 40)
        Me.txtAnexo.Name = "txtAnexo"
        Me.txtAnexo.ReadOnly = True
        Me.txtAnexo.Size = New System.Drawing.Size(80, 20)
        Me.txtAnexo.TabIndex = 13
        Me.txtAnexo.TabStop = False
        '
        'txtGarantia
        '
        Me.txtGarantia.AcceptsTab = True
        Me.txtGarantia.Location = New System.Drawing.Point(16, 104)
        Me.txtGarantia.Name = "txtGarantia"
        Me.txtGarantia.Size = New System.Drawing.Size(600, 129)
        Me.txtGarantia.TabIndex = 1
        Me.txtGarantia.TabStop = False
        Me.txtGarantia.Text = ""
        '
        'frmPrendaria
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(632, 286)
        Me.Controls.Add(Me.txtGarantia)
        Me.Controls.Add(Me.txtAnexo)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnCambios)
        Me.Controls.Add(Me.btnAlta)
        Me.Controls.Add(Me.lblGarantia)
        Me.Controls.Add(Me.lblContrato)
        Me.Controls.Add(Me.lblCliente)
        Me.Controls.Add(Me.txtCusnam)
        Me.Name = "frmPrendaria"
        Me.Text = "frmPrendaria"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Dim cAnexo As String

    Private Sub frmPrendaria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As SqlConnection = New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim dsAgil As DataSet = New DataSet()
        Dim daAnexos As New SqlDataAdapter(cm1)
        Dim daPrenda As New SqlDataAdapter(cm2)
        Dim drPrenda As DataRow
        Dim drPrendas As DataRowCollection
        Dim drAnexo As DataRow
        Dim drAnexos As DataRowCollection

        ' Declaración de variables de datos

        Dim cPrenda As String

        cAnexo = Mid(txtAnexo.Text, 1, 5) & Mid(txtAnexo.Text, 7, 10)

        ' Este Stored Procedure trae los datos del contrato seleccionado

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Datoscon1"
            .Connection = cnAgil
            .Parameters.Add("@Anexo", SqlDbType.NVarChar)
            .Parameters(0).Value = cAnexo
        End With

        ' Lo primero que hay que validar es que el contrato tenga garantía prendaria

        daAnexos.Fill(dsAgil, "Anexos")
        drAnexos = dsAgil.Tables("Anexos").Rows

        For Each drAnexo In drAnexos
            cPrenda = drAnexo("Prenda")
            txtCusnam.Text = drAnexo("Descr")
        Next

        If cPrenda = "S" Then

            ' Este Stored Procedure trae los datos de la garantía prendaria (si procede)

            With cm2
                .CommandType = CommandType.StoredProcedure
                .CommandText = "DamePrenda1"
                .Connection = cnAgil
                .Parameters.Add("@Anexo", SqlDbType.NVarChar)
                .Parameters(0).Value = cAnexo
            End With

            ' Buscar a dicho cliente en el DataSet y retornar sus datos en el DataRow

            daPrenda.Fill(dsAgil, "Prenda")
            drPrendas = dsAgil.Tables("Prenda").Rows

            For Each drPrenda In drPrendas
                txtGarantia.Text = drPrenda("DescPrenda")
            Next
            If Trim(txtGarantia.Text) <> "" Then
                btnAlta.Enabled = False
            Else
                btnCambios.Enabled = False
            End If
        Else
            MsgBox("El contrato dice que no hay garantía prendaria", MsgBoxStyle.Information, "Mensaje")
            Me.Close()
        End If

    End Sub

    Private Sub btnAlta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAlta.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As SqlConnection = New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim strActualiza As String

        Try
            cnAgil.Open()
            strActualiza = "INSERT INTO Prenda(Anexo, Prenda) VALUES('" & cAnexo & "', '" & txtGarantia.Text & "') "
            cm1 = New SqlCommand(strActualiza, cnAgil)
            cm1.ExecuteNonQuery()

        Catch eException As Exception
            MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de error")
        End Try
        btnAlta.Enabled = False
    End Sub

    Private Sub btnCambios_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCambios.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As SqlConnection = New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim strActualiza As String

        Try
            cnAgil.Open()
            strActualiza = "UPDATE Prenda SET Anexo = " & "'" & cAnexo & "'," & _
                                                            " Prenda = " & " '" & txtGarantia.Text & "'" & _
                                                            "WHERE Anexo = " & "'" & cAnexo & "'"
            cm1 = New SqlCommand(strActualiza, cnAgil)
            cm1.ExecuteNonQuery()

        Catch eException As Exception
            MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de error")
        End Try
        btnCambios.Enabled = False
    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class
