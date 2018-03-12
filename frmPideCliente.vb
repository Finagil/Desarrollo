Option Explicit On 

Imports System.Data.SqlClient

Public Class frmPideCliente
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal cMenu As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        txtMenu.Text = cMenu

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
    Friend WithEvents lblClientes As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents txtMenu As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblClientes = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.txtMenu = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'lblClientes
        '
        Me.lblClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClientes.Location = New System.Drawing.Point(32, 16)
        Me.lblClientes.Name = "lblClientes"
        Me.lblClientes.Size = New System.Drawing.Size(432, 16)
        Me.lblClientes.TabIndex = 7
        Me.lblClientes.Text = "Selecciona un Cliente de la siguiente Lista"
        '
        'ComboBox1
        '
        Me.ComboBox1.Location = New System.Drawing.Point(32, 40)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(424, 21)
        Me.ComboBox1.TabIndex = 8
        Me.ComboBox1.Text = "ComboBox1"
        '
        'txtMenu
        '
        Me.txtMenu.Location = New System.Drawing.Point(32, 128)
        Me.txtMenu.Name = "txtMenu"
        Me.txtMenu.ReadOnly = True
        Me.txtMenu.Size = New System.Drawing.Size(40, 20)
        Me.txtMenu.TabIndex = 9
        Me.txtMenu.Text = ""
        Me.txtMenu.Visible = False
        '
        'frmPideCliente
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(496, 422)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtMenu, Me.lblClientes, Me.ComboBox1})
        Me.Name = "frmPideCliente"
        Me.Text = "Selección de Cliente"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim lFirstTime As Boolean = True

    Private Sub frmPideCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim dsAgil As New DataSet()
        Dim daClientes As New SqlDataAdapter(cm1)

        ' Este Stored Procedure trae TODOS los clientes que existan en la tabla Clientes sin
        ' importar si tienen o no solicitudes dadas de alta

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "ContClie1"
            .Connection = cnAgil
        End With

        ComboBox1.MaxDropDownItems = 25

        Try

            ' Llenar el DataSet

            daClientes.Fill(dsAgil, "Clientes")

            ' Ligar la tabla Clientes del dataset dsAgil al ComboBox

            ComboBox1.DataSource = dsAgil
            ComboBox1.DisplayMember = "Clientes.Descr"
            ComboBox1.ValueMember = "Clientes.Cliente"
            lFirstTime = False

        Catch eException As Exception

            MsgBox(eException.Source & " " & eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")

        End Try

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        Dim cCliente As String
        Dim cDescr As String

        If Not ComboBox1.SelectedValue Is Nothing And lFirstTime = False Then

            cCliente = ComboBox1.SelectedValue.ToString()
            cDescr = RTrim(ComboBox1.Text)

            ' Ya que se escogió un cliente del listado, se llama a la forma frmContSoli
            ' mandándole como parámetro el número del cliente seleccionado


            Select Case txtMenu.Text
                Case "mnuContSoli"
                    Dim newfrmContSoli As New frmContSoli(cCliente, cDescr)
                    newfrmContSoli.Show()
                Case "mnuSeguiCre"
                    Dim newfrmSeguiCre As New frmSeguicre(cCliente)
                    newfrmSeguiCre.Show()
            End Select

        End If

    End Sub

End Class
