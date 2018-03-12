Option Explicit On 

Imports System.Data.SqlClient

Public Class frmContClie

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
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents lblClientes As System.Windows.Forms.Label
    Friend WithEvents btnModiGene As System.Windows.Forms.Button
    Friend WithEvents btnModiPers As System.Windows.Forms.Button
    Friend WithEvents gbContClie As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.lblClientes = New System.Windows.Forms.Label
        Me.gbContClie = New System.Windows.Forms.GroupBox
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnModiPers = New System.Windows.Forms.Button
        Me.btnModiGene = New System.Windows.Forms.Button
        Me.gbContClie.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.Location = New System.Drawing.Point(64, 48)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(424, 21)
        Me.ComboBox1.TabIndex = 1
        Me.ComboBox1.Text = "ComboBox1"
        '
        'lblClientes
        '
        Me.lblClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClientes.Location = New System.Drawing.Point(64, 24)
        Me.lblClientes.Name = "lblClientes"
        Me.lblClientes.Size = New System.Drawing.Size(432, 16)
        Me.lblClientes.TabIndex = 2
        Me.lblClientes.Text = "Selecciona un Cliente de la siguiente Lista"
        '
        'gbContClie
        '
        Me.gbContClie.Controls.Add(Me.btnCancelar)
        Me.gbContClie.Controls.Add(Me.btnModiPers)
        Me.gbContClie.Controls.Add(Me.btnModiGene)
        Me.gbContClie.Controls.Add(Me.lblClientes)
        Me.gbContClie.Controls.Add(Me.ComboBox1)
        Me.gbContClie.Location = New System.Drawing.Point(32, 24)
        Me.gbContClie.Name = "gbContClie"
        Me.gbContClie.Size = New System.Drawing.Size(536, 184)
        Me.gbContClie.TabIndex = 3
        Me.gbContClie.TabStop = False
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(367, 120)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(133, 32)
        Me.btnCancelar.TabIndex = 57
        Me.btnCancelar.Text = "Salir"
        '
        'btnModiPers
        '
        Me.btnModiPers.Enabled = False
        Me.btnModiPers.Location = New System.Drawing.Point(207, 120)
        Me.btnModiPers.Name = "btnModiPers"
        Me.btnModiPers.Size = New System.Drawing.Size(133, 32)
        Me.btnModiPers.TabIndex = 2
        Me.btnModiPers.Text = "Modificar Personalidades"
        '
        'btnModiGene
        '
        Me.btnModiGene.Enabled = False
        Me.btnModiGene.Location = New System.Drawing.Point(46, 120)
        Me.btnModiGene.Name = "btnModiGene"
        Me.btnModiGene.Size = New System.Drawing.Size(133, 32)
        Me.btnModiGene.TabIndex = 1
        Me.btnModiGene.Text = "Modificar Generales"
        '
        'frmContClie
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(600, 238)
        Me.Controls.Add(Me.gbContClie)
        Me.Name = "frmContClie"
        Me.Text = "Control de Clientes"
        Me.gbContClie.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmContClie_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim dsAgil As New DataSet()
        Dim daClientes As New SqlDataAdapter(cm1)

        ' Este Stored Procedure trae el nombre de todos los clientes sin importar si tienen contratos o no

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

        Catch eException As Exception

            MsgBox(eException.Source & " " & eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")

        End Try

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        Dim cCliente As String

        If Not ComboBox1.SelectedValue Is Nothing Then

            cCliente = ComboBox1.SelectedValue.ToString()

            ' Ya que se escogió un cliente del listado, se activan los botones Modificar Generales y Modificar
            ' Personalidades del cliente

            btnModiGene.Enabled = True
            btnModiPers.Enabled = True

        End If

    End Sub

    Private Sub btnModiGene_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModiGene.Click
        Dim cCliente As String
        cCliente = ComboBox1.SelectedValue.ToString()
        Dim newfrmModiGene As New frmModiGene(cCliente)
        newfrmModiGene.Show()
    End Sub

    Private Sub btnModiPers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModiPers.Click
        Dim cCliente As String
        cCliente = ComboBox1.SelectedValue.ToString()
        Dim newfrmModiPers As New frmModiPers(cCliente)
        newfrmModiPers.Show()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

End Class
