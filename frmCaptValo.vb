Option Explicit On 

Imports System.Data.SqlClient

Public Class frmCaptValo

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnModifica As System.Windows.Forms.Button
    Friend WithEvents btnSalvar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents rbFsi As System.Windows.Forms.RadioButton
    Friend WithEvents rbGsi As System.Windows.Forms.RadioButton
    Friend WithEvents rbPsi As System.Windows.Forms.RadioButton
    Friend WithEvents rbCsi As System.Windows.Forms.RadioButton
    Friend WithEvents txtObser As System.Windows.Forms.TextBox
    Friend WithEvents txtAnexo As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents rbFno As System.Windows.Forms.RadioButton
    Friend WithEvents rbCno As System.Windows.Forms.RadioButton
    Friend WithEvents rbPno As System.Windows.Forms.RadioButton
    Friend WithEvents rbGno As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCaptValo))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnModifica = New System.Windows.Forms.Button()
        Me.btnSalvar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.rbFsi = New System.Windows.Forms.RadioButton()
        Me.rbGsi = New System.Windows.Forms.RadioButton()
        Me.rbPsi = New System.Windows.Forms.RadioButton()
        Me.rbCsi = New System.Windows.Forms.RadioButton()
        Me.txtObser = New System.Windows.Forms.TextBox()
        Me.txtAnexo = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rbFno = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rbCno = New System.Windows.Forms.RadioButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.rbGno = New System.Windows.Forms.RadioButton()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.rbPno = New System.Windows.Forms.RadioButton()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Facturas Originales "
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Contrato Ratificado "
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Pagaré"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Garantía Prendaria"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 128)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "OBSERVACIONES"
        '
        'btnModifica
        '
        Me.btnModifica.Location = New System.Drawing.Point(248, 168)
        Me.btnModifica.Name = "btnModifica"
        Me.btnModifica.Size = New System.Drawing.Size(96, 24)
        Me.btnModifica.TabIndex = 9
        Me.btnModifica.Text = "Modificar"
        '
        'btnSalvar
        '
        Me.btnSalvar.Enabled = False
        Me.btnSalvar.Location = New System.Drawing.Point(384, 168)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(96, 24)
        Me.btnSalvar.TabIndex = 10
        Me.btnSalvar.Text = "Guardar"
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(512, 168)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(96, 24)
        Me.btnSalir.TabIndex = 11
        Me.btnSalir.Text = "Regresar"
        '
        'rbFsi
        '
        Me.rbFsi.Enabled = False
        Me.rbFsi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbFsi.Location = New System.Drawing.Point(136, 8)
        Me.rbFsi.Name = "rbFsi"
        Me.rbFsi.Size = New System.Drawing.Size(40, 16)
        Me.rbFsi.TabIndex = 13
        Me.rbFsi.Text = "Sí"
        '
        'rbGsi
        '
        Me.rbGsi.Enabled = False
        Me.rbGsi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbGsi.Location = New System.Drawing.Point(136, 8)
        Me.rbGsi.Name = "rbGsi"
        Me.rbGsi.Size = New System.Drawing.Size(40, 16)
        Me.rbGsi.TabIndex = 14
        Me.rbGsi.Text = "Sí"
        '
        'rbPsi
        '
        Me.rbPsi.Enabled = False
        Me.rbPsi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPsi.Location = New System.Drawing.Point(136, 8)
        Me.rbPsi.Name = "rbPsi"
        Me.rbPsi.Size = New System.Drawing.Size(40, 16)
        Me.rbPsi.TabIndex = 15
        Me.rbPsi.Text = "Sí"
        '
        'rbCsi
        '
        Me.rbCsi.Enabled = False
        Me.rbCsi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCsi.Location = New System.Drawing.Point(136, 8)
        Me.rbCsi.Name = "rbCsi"
        Me.rbCsi.Size = New System.Drawing.Size(40, 16)
        Me.rbCsi.TabIndex = 16
        Me.rbCsi.Text = "Sí"
        '
        'txtObser
        '
        Me.txtObser.Location = New System.Drawing.Point(136, 128)
        Me.txtObser.Name = "txtObser"
        Me.txtObser.ReadOnly = True
        Me.txtObser.Size = New System.Drawing.Size(472, 20)
        Me.txtObser.TabIndex = 21
        Me.txtObser.Text = ""
        '
        'txtAnexo
        '
        Me.txtAnexo.Location = New System.Drawing.Point(472, 16)
        Me.txtAnexo.Name = "txtAnexo"
        Me.txtAnexo.Size = New System.Drawing.Size(8, 20)
        Me.txtAnexo.TabIndex = 22
        Me.txtAnexo.Text = "TextBox1"
        Me.txtAnexo.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbFno, Me.rbFsi, Me.Label1})
        Me.Panel1.Location = New System.Drawing.Point(16, 8)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(248, 32)
        Me.Panel1.TabIndex = 23
        '
        'rbFno
        '
        Me.rbFno.Enabled = False
        Me.rbFno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbFno.Location = New System.Drawing.Point(184, 8)
        Me.rbFno.Name = "rbFno"
        Me.rbFno.Size = New System.Drawing.Size(48, 16)
        Me.rbFno.TabIndex = 14
        Me.rbFno.Text = "No"
        '
        'Panel2
        '
        Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbCno, Me.Label2, Me.rbCsi})
        Me.Panel2.Location = New System.Drawing.Point(16, 32)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(248, 32)
        Me.Panel2.TabIndex = 24
        '
        'rbCno
        '
        Me.rbCno.Enabled = False
        Me.rbCno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCno.Location = New System.Drawing.Point(184, 8)
        Me.rbCno.Name = "rbCno"
        Me.rbCno.Size = New System.Drawing.Size(48, 16)
        Me.rbCno.TabIndex = 17
        Me.rbCno.Text = "No"
        '
        'Panel3
        '
        Me.Panel3.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbGno, Me.rbGsi, Me.Label4})
        Me.Panel3.Location = New System.Drawing.Point(16, 80)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(248, 32)
        Me.Panel3.TabIndex = 25
        '
        'rbGno
        '
        Me.rbGno.Enabled = False
        Me.rbGno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbGno.Location = New System.Drawing.Point(184, 8)
        Me.rbGno.Name = "rbGno"
        Me.rbGno.Size = New System.Drawing.Size(48, 16)
        Me.rbGno.TabIndex = 15
        Me.rbGno.Text = "No"
        '
        'Panel4
        '
        Me.Panel4.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbPno, Me.rbPsi, Me.Label3})
        Me.Panel4.Location = New System.Drawing.Point(16, 56)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(248, 32)
        Me.Panel4.TabIndex = 26
        '
        'rbPno
        '
        Me.rbPno.Enabled = False
        Me.rbPno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPno.Location = New System.Drawing.Point(184, 8)
        Me.rbPno.Name = "rbPno"
        Me.rbPno.Size = New System.Drawing.Size(48, 16)
        Me.rbPno.TabIndex = 16
        Me.rbPno.Text = "No"
        '
        'frmCaptValo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(624, 214)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel4, Me.Panel3, Me.Panel2, Me.Panel1, Me.txtAnexo, Me.txtObser, Me.btnSalir, Me.btnSalvar, Me.btnModifica, Me.Label5})
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCaptValo"
        Me.Text = "Captura de Valores"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmCaptValo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim dsAgil As New DataSet()
        Dim cm1 As New SqlCommand()
        Dim daAnexos As New SqlDataAdapter(cm1)
        Dim drAnexo As DataRow

        'Declaración de variables de datos

        Dim cAnexo As String
        Dim cDoc1 As String
        Dim cDoc2 As String
        Dim cDoc3 As String
        Dim cCusnam As String
        Dim cGarantia As String

        cAnexo = Mid(txtAnexo.Text, 1, 5) & Mid(txtAnexo.Text, 7, 4)

        ' El siguiente Stored Procedure trae todos los atributos de la tabla Anexos,
        ' para un anexo dado

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DatosCon1"
            .Connection = cnAgil
            .Parameters.Add("@Anexo", SqlDbType.NVarChar)
            .Parameters(0).Value = cAnexo
        End With

        ' Llenar el DataSet lo cual abre y cierra la conexión

        daAnexos.Fill(dsAgil, "Anexos")

        ' Validando que el Contrato esté Activo

        drAnexo = dsAgil.Tables("Anexos").Rows(0)

        cCusnam = drAnexo("Descr")
        cDoc1 = drAnexo("Doc1")
        cDoc2 = drAnexo("Doc2")
        cDoc3 = drAnexo("Doc3")
        cGarantia = drAnexo("Prendaria")

        Me.Text = txtAnexo.Text & "   " & cCusnam
        If cDoc1 = "S" Then
            rbFsi.Checked = True
            rbFno.Checked = False
        Else
            rbFsi.Checked = False
            rbFno.Checked = True
        End If
        If cDoc2 = "S" Then
            rbCsi.Checked = True
            rbCno.Checked = False
        Else
            rbCsi.Checked = False
            rbCno.Checked = True
        End If
        If cDoc3 = "S" Then
            rbPsi.Checked = True
            rbPno.Checked = False
        Else
            rbPsi.Checked = False
            rbPno.Checked = True
        End If
        If cGarantia = "S" Then
            rbGsi.Checked = True
            rbGno.Checked = False
        Else
            rbGsi.Checked = False
            rbGno.Checked = True
        End If
        txtObser.Text = drAnexo("Observa")

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub btnModifica_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModifica.Click
        btnSalvar.Enabled = True
        rbFsi.Enabled = True
        rbCsi.Enabled = True
        rbPsi.Enabled = True
        rbGsi.Enabled = True
        rbFno.Enabled = True
        rbCno.Enabled = True
        rbPno.Enabled = True
        rbGno.Enabled = True
        txtObser.ReadOnly = False
    End Sub

    Private Sub btnSalvar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalvar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim dsAgil As New DataSet()
        Dim cm1 As New SqlCommand()
        Dim strUpdate As String

        ' Declaración de variables de datos

        Dim cDoc1 As String
        Dim cDoc2 As String
        Dim cDoc3 As String
        Dim cAnexo As String
        Dim cGarantia As String
        Dim cObserva As String

        cDoc1 = "N"
        cDoc2 = "N"
        cDoc3 = "N"
        cGarantia = "N"
        cAnexo = Mid(txtAnexo.Text, 1, 5) & Mid(txtAnexo.Text, 7, 4)

        btnModifica.Enabled = False
        rbFsi.Enabled = False
        rbCsi.Enabled = False
        rbPsi.Enabled = False
        rbGsi.Enabled = False
        rbFno.Enabled = False
        rbCno.Enabled = False
        rbPno.Enabled = False
        rbGno.Enabled = False
        txtObser.ReadOnly = True
        btnSalvar.Enabled = False

        If rbFsi.Checked = True Then
            cDoc1 = "S"
        End If

        If rbCsi.Checked = True Then
            cDoc2 = "S"
        End If

        If rbPsi.Checked = True Then
            cDoc3 = "S"
        End If

        If rbGsi.Checked = True Then
            cGarantia = "S"
        End If

        cObserva = txtObser.Text

        strUpdate = "UPDATE Anexos SET Doc1 = " & "'" & cDoc1 & "',"
        strUpdate = strUpdate & " Doc2 = " & "'" & cDoc2 & "',"
        strUpdate = strUpdate & " Doc3 = " & "'" & cDoc3 & "',"
        strUpdate = strUpdate & " Prendaria = " & "'" & cGarantia & "',"
        strUpdate = strUpdate & " Observa = " & "'" & cObserva & "' "
        strUpdate = strUpdate & " WHERE Anexo = " & "'" & cAnexo & "'"

        Try
            cm1 = New SqlCommand(strUpdate, cnAgil)
            cnAgil.Open()
            cm1.ExecuteNonQuery()
            cnAgil.Close()
        Catch eException As Exception
            MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")
        End Try

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class
