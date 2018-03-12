Option Explicit On 

Imports System.Data.SqlClient

Public Class frmRecipago

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
    Friend WithEvents lblClientes As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents btnAdeudos As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblClientes = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.btnAdeudos = New System.Windows.Forms.Button
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblClientes
        '
        Me.lblClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClientes.Location = New System.Drawing.Point(16, 24)
        Me.lblClientes.Name = "lblClientes"
        Me.lblClientes.Size = New System.Drawing.Size(432, 16)
        Me.lblClientes.TabIndex = 6
        Me.lblClientes.Text = "Selecciona un Cliente de la siguiente Lista y después da Click en Adeudos"
        '
        'ComboBox1
        '
        Me.ComboBox1.Location = New System.Drawing.Point(16, 48)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ComboBox1.Size = New System.Drawing.Size(494, 21)
        Me.ComboBox1.TabIndex = 5
        '
        'btnAdeudos
        '
        Me.btnAdeudos.Location = New System.Drawing.Point(516, 48)
        Me.btnAdeudos.Name = "btnAdeudos"
        Me.btnAdeudos.Size = New System.Drawing.Size(75, 23)
        Me.btnAdeudos.TabIndex = 7
        Me.btnAdeudos.Text = "Adeudos"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 360)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(712, 22)
        Me.StatusStrip1.TabIndex = 10
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'frmRecipago
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(712, 382)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btnAdeudos)
        Me.Controls.Add(Me.lblClientes)
        Me.Controls.Add(Me.ComboBox1)
        Me.Name = "frmRecipago"
        Me.Text = "Clientes con Adeudo"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub frmRecipago_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daClientes As New SqlDataAdapter(cm1)
        Dim dsAgil As New DataSet()

        ' Declaración de variables de datos

        Dim cFecha As String

        cFecha = Now().ToShortDateString
        ToolStripStatusLabel1.Text = "Fecha de Aplicación " & cFecha
        cFecha = Mid(cFecha, 7, 4) & Mid(cFecha, 4, 2) & Mid(cFecha, 1, 2)

        ' Este Stored Procedure trae EXCLUSIVAMENTE los clientes que tengan adeudo
        ' ya sea por rentas (sean exigibles o no), por pagos iniciales 
        ' o por opciones de compra, a fin de no mostrar clientes que no tengan adeudo

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "ReciPago1"
            .Connection = cnAgil
            .Parameters.Add("@Fecha", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        ComboBox1.MaxDropDownItems = 35

        Try

            ' Llenar el DataSet lo cual abre y cierra la conexión

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

    Private Sub btnAdeudos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdeudos.Click

        ' Declaración de variables de datos

        Dim cCliente As String
        Dim newfrmAcepagoIVF As frmAcepagoIVF

        If Not ComboBox1.SelectedValue Is Nothing Then

            cCliente = ComboBox1.SelectedValue.ToString()

            If Len(cCliente) = 5 Then

                ' Ya que se escogió un cliente del listado, se llama a la Forma de 
                ' Recepción de Pagos frmRecipago, enviándole como parámetro el número 
                ' del cliente

                newfrmAcepagoIVF = New frmAcepagoIVF(cCliente)
                newfrmAcepagoIVF.Show()

            End If

        End If

    End Sub

End Class
