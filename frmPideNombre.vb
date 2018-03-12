Imports System.Data.SqlClient

Public Class frmPideNombre

    Private _nombre As String
    Private _paterno As String
    Private _materno As String
    Private _cliente As String

    Dim strConnX As String = "Server=SERVER-RAID; DataBase=desarrollo; User ID=sa; pwd=faae6115"
    Dim cnn As New SqlConnection(strConnX)
    Dim cm1 As New SqlCommand()
    Dim daClientes As New SqlDataAdapter(cm1)
    Dim dsCli As New DataTable

    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Public Property Paterno() As String
        Get
            Return _paterno
        End Get
        Set(ByVal value As String)
            _paterno = value
        End Set
    End Property

    Public Property Materno() As String
        Get
            Return _materno
        End Get
        Set(ByVal value As String)
            _materno = value
        End Set
    End Property

    Public Property Cliente() As String
        Get
            Return _cliente
        End Get
        Set(ByVal value As String)
            _cliente = value
        End Set
    End Property

    Public Sub New(ByVal cTipo As String, ByVal cNombre As String, ByVal cCliente As String)

        ' This call is required by the Windows Form Designer.

        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.Text = cNombre
        Me.Cliente = cCliente

        If cTipo = "F" Then
            txtNombre.MaxLength = 26
            txtPaterno.MaxLength = 26
            txtMaterno.MaxLength = 26
        Else
            txtNombre.MaxLength = 75
            txtPaterno.MaxLength = 25
            txtMaterno.MaxLength = 25
        End If

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.Nombre = UCase(txtNombre.Text)
        Me.Paterno = UCase(txtPaterno.Text)
        Me.Materno = UCase(txtMaterno.Text)
        With cm1
            .CommandType = CommandType.Text
            .CommandText = "UPDATE Clientes SET NombreCliente = '" & Nombre & "', ApellidoPaterno = '" & Paterno & "', ApellidoMaterno = '" & Materno & "' WHERE Cliente = '" & Cliente & "'"
            .Connection = cnn
        End With
        If cnn.State <> ConnectionState.Open Then cnn.Open()
        cm1.ExecuteNonQuery()
        Me.Close()
    End Sub

    Private Sub frmPideNombre_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        With cm1
            .CommandType = CommandType.Text
            .CommandText = "SELECT * FROM Clientes WHERE Cliente = '" & Cliente & "'"
            .Connection = cnn
        End With

        ' Llenar el dataset lo cual abre y cierra la conexión

        daClientes.Fill(dsCli)

        For Each r As DataRow In dsCli.Rows
            If Trim(r("NombreCliente")) <> "" Then
                Me.Nombre = Trim(r("NombreCliente"))
                Me.Paterno = Trim(r("ApellidoPaterno"))
                Me.Materno = Trim(r("ApellidoMaterno"))
                Me.Close()
                Exit For
            End If
        Next

    End Sub

End Class