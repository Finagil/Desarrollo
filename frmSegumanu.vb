Option Explicit On 

Imports System.Data.SqlClient
Imports System.Math

Public Class frmSegumanu

    Inherits System.Windows.Forms.Form

    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCheque As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox

    Dim nLetras As Integer
    Dim nVenciant As Integer
    Dim cCliente As String


#Region " Windows Form Designer generated code "

    Public Sub New(ByVal cAnexo As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Text = "Captura de Póliza de Seguro para el Contrato " & cAnexo
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
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents txtCusnam As System.Windows.Forms.TextBox
    Friend WithEvents txtVencimiento As System.Windows.Forms.TextBox
    Friend WithEvents txtMeses As System.Windows.Forms.TextBox
    Friend WithEvents txtPlazo As System.Windows.Forms.TextBox
    Friend WithEvents txtPrima As System.Windows.Forms.TextBox
    Friend WithEvents txtAnexo As System.Windows.Forms.TextBox
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents txtTasaAp As System.Windows.Forms.TextBox
    Friend WithEvents txtFeven As System.Windows.Forms.TextBox
    Friend WithEvents txtVenci As System.Windows.Forms.TextBox
    Friend WithEvents btnTabla As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents lblSumaseg As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblPlazorestante As System.Windows.Forms.Label
    Friend WithEvents rbPlazonvo As System.Windows.Forms.RadioButton
    Friend WithEvents rbPlazoant As System.Windows.Forms.RadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnContinuar As System.Windows.Forms.Button
    Friend WithEvents txtconPlazo As System.Windows.Forms.TextBox
    Friend WithEvents txtSaldoant As System.Windows.Forms.TextBox
    Friend WithEvents txtSumaseg As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtFecha = New System.Windows.Forms.TextBox
        Me.txtCusnam = New System.Windows.Forms.TextBox
        Me.txtVencimiento = New System.Windows.Forms.TextBox
        Me.txtMeses = New System.Windows.Forms.TextBox
        Me.txtPlazo = New System.Windows.Forms.TextBox
        Me.txtPrima = New System.Windows.Forms.TextBox
        Me.txtAnexo = New System.Windows.Forms.TextBox
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.btnExit = New System.Windows.Forms.Button
        Me.txtTasaAp = New System.Windows.Forms.TextBox
        Me.txtFeven = New System.Windows.Forms.TextBox
        Me.txtVenci = New System.Windows.Forms.TextBox
        Me.btnTabla = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.txtSumaseg = New System.Windows.Forms.TextBox
        Me.lblSumaseg = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnContinuar = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblPlazorestante = New System.Windows.Forms.Label
        Me.rbPlazonvo = New System.Windows.Forms.RadioButton
        Me.rbPlazoant = New System.Windows.Forms.RadioButton
        Me.txtconPlazo = New System.Windows.Forms.TextBox
        Me.txtSaldoant = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtCheque = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre del Cliente:"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 124)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "No. de Vencimiento:"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 148)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Meses por Transcurrir:"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 219)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Plazo del Seguro:"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 242)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(136, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Prima del Seguro:"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(336, 125)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(136, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Fecha de vencimiento:"
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(472, 124)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(176, 20)
        Me.txtFecha.TabIndex = 6
        Me.txtFecha.TabStop = False
        '
        'txtCusnam
        '
        Me.txtCusnam.Location = New System.Drawing.Point(144, 100)
        Me.txtCusnam.Name = "txtCusnam"
        Me.txtCusnam.ReadOnly = True
        Me.txtCusnam.Size = New System.Drawing.Size(504, 20)
        Me.txtCusnam.TabIndex = 7
        Me.txtCusnam.TabStop = False
        '
        'txtVencimiento
        '
        Me.txtVencimiento.Location = New System.Drawing.Point(144, 124)
        Me.txtVencimiento.Name = "txtVencimiento"
        Me.txtVencimiento.ReadOnly = True
        Me.txtVencimiento.Size = New System.Drawing.Size(32, 20)
        Me.txtVencimiento.TabIndex = 8
        Me.txtVencimiento.TabStop = False
        '
        'txtMeses
        '
        Me.txtMeses.Location = New System.Drawing.Point(144, 148)
        Me.txtMeses.Name = "txtMeses"
        Me.txtMeses.ReadOnly = True
        Me.txtMeses.Size = New System.Drawing.Size(32, 20)
        Me.txtMeses.TabIndex = 9
        Me.txtMeses.TabStop = False
        '
        'txtPlazo
        '
        Me.txtPlazo.Location = New System.Drawing.Point(144, 219)
        Me.txtPlazo.Name = "txtPlazo"
        Me.txtPlazo.Size = New System.Drawing.Size(32, 20)
        Me.txtPlazo.TabIndex = 32
        Me.txtPlazo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrima
        '
        Me.txtPrima.Location = New System.Drawing.Point(144, 242)
        Me.txtPrima.Name = "txtPrima"
        Me.txtPrima.Size = New System.Drawing.Size(112, 20)
        Me.txtPrima.TabIndex = 34
        Me.txtPrima.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAnexo
        '
        Me.txtAnexo.Location = New System.Drawing.Point(600, 72)
        Me.txtAnexo.Name = "txtAnexo"
        Me.txtAnexo.Size = New System.Drawing.Size(8, 20)
        Me.txtAnexo.TabIndex = 12
        Me.txtAnexo.Visible = False
        '
        'DataGrid1
        '
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(12, 316)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(636, 274)
        Me.DataGrid1.TabIndex = 13
        Me.DataGrid1.Visible = False
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(549, 286)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(96, 24)
        Me.btnExit.TabIndex = 16
        Me.btnExit.Text = "Salir"
        '
        'txtTasaAp
        '
        Me.txtTasaAp.Location = New System.Drawing.Point(488, 136)
        Me.txtTasaAp.Name = "txtTasaAp"
        Me.txtTasaAp.Size = New System.Drawing.Size(8, 20)
        Me.txtTasaAp.TabIndex = 17
        Me.txtTasaAp.Visible = False
        '
        'txtFeven
        '
        Me.txtFeven.Location = New System.Drawing.Point(504, 136)
        Me.txtFeven.Name = "txtFeven"
        Me.txtFeven.Size = New System.Drawing.Size(8, 20)
        Me.txtFeven.TabIndex = 18
        Me.txtFeven.Visible = False
        '
        'txtVenci
        '
        Me.txtVenci.Location = New System.Drawing.Point(520, 136)
        Me.txtVenci.Name = "txtVenci"
        Me.txtVenci.Size = New System.Drawing.Size(8, 20)
        Me.txtVenci.TabIndex = 19
        Me.txtVenci.Visible = False
        '
        'btnTabla
        '
        Me.btnTabla.Location = New System.Drawing.Point(284, 286)
        Me.btnTabla.Name = "btnTabla"
        Me.btnTabla.Size = New System.Drawing.Size(96, 24)
        Me.btnTabla.TabIndex = 21
        Me.btnTabla.Text = "Ver Tabla"
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(416, 286)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(96, 24)
        Me.btnSave.TabIndex = 22
        Me.btnSave.Text = "Grabar"
        '
        'txtSumaseg
        '
        Me.txtSumaseg.Location = New System.Drawing.Point(616, 72)
        Me.txtSumaseg.Name = "txtSumaseg"
        Me.txtSumaseg.Size = New System.Drawing.Size(8, 20)
        Me.txtSumaseg.TabIndex = 23
        Me.txtSumaseg.Visible = False
        '
        'lblSumaseg
        '
        Me.lblSumaseg.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSumaseg.Location = New System.Drawing.Point(274, 243)
        Me.lblSumaseg.Name = "lblSumaseg"
        Me.lblSumaseg.Size = New System.Drawing.Size(334, 18)
        Me.lblSumaseg.TabIndex = 20
        Me.lblSumaseg.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnContinuar)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.lblPlazorestante)
        Me.GroupBox1.Controls.Add(Me.rbPlazonvo)
        Me.GroupBox1.Controls.Add(Me.rbPlazoant)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(11, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(641, 69)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Contrato con Saldo en Seguro Financiado"
        '
        'btnContinuar
        '
        Me.btnContinuar.Location = New System.Drawing.Point(531, 38)
        Me.btnContinuar.Name = "btnContinuar"
        Me.btnContinuar.Size = New System.Drawing.Size(89, 22)
        Me.btnContinuar.TabIndex = 4
        Me.btnContinuar.Text = "Continuar"
        Me.btnContinuar.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 45)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(106, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Forma de Aplicación "
        '
        'lblPlazorestante
        '
        Me.lblPlazorestante.AutoSize = True
        Me.lblPlazorestante.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlazorestante.Location = New System.Drawing.Point(15, 20)
        Me.lblPlazorestante.Name = "lblPlazorestante"
        Me.lblPlazorestante.Size = New System.Drawing.Size(0, 15)
        Me.lblPlazorestante.TabIndex = 2
        '
        'rbPlazonvo
        '
        Me.rbPlazonvo.AutoSize = True
        Me.rbPlazonvo.Location = New System.Drawing.Point(315, 44)
        Me.rbPlazonvo.Name = "rbPlazonvo"
        Me.rbPlazonvo.Size = New System.Drawing.Size(194, 17)
        Me.rbPlazonvo.TabIndex = 1
        Me.rbPlazonvo.TabStop = True
        Me.rbPlazonvo.Text = "Cargar la póliza con un nuevo plazo"
        Me.rbPlazonvo.UseVisualStyleBackColor = True
        '
        'rbPlazoant
        '
        Me.rbPlazoant.AutoSize = True
        Me.rbPlazoant.Location = New System.Drawing.Point(132, 44)
        Me.rbPlazoant.Name = "rbPlazoant"
        Me.rbPlazoant.Size = New System.Drawing.Size(177, 17)
        Me.rbPlazoant.TabIndex = 0
        Me.rbPlazoant.TabStop = True
        Me.rbPlazoant.Text = "Cargar la póliza al plazo restante"
        Me.rbPlazoant.UseVisualStyleBackColor = True
        '
        'txtconPlazo
        '
        Me.txtconPlazo.Location = New System.Drawing.Point(328, 73)
        Me.txtconPlazo.Name = "txtconPlazo"
        Me.txtconPlazo.Size = New System.Drawing.Size(8, 20)
        Me.txtconPlazo.TabIndex = 25
        Me.txtconPlazo.Visible = False
        '
        'txtSaldoant
        '
        Me.txtSaldoant.Location = New System.Drawing.Point(339, 73)
        Me.txtSaldoant.Name = "txtSaldoant"
        Me.txtSaldoant.Size = New System.Drawing.Size(8, 20)
        Me.txtSaldoant.TabIndex = 26
        Me.txtSaldoant.Visible = False
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(7, 173)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(115, 16)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "Fecha del Pago"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(144, 172)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(96, 20)
        Me.DateTimePicker1.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(7, 196)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(115, 16)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "Número de Cheque"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCheque
        '
        Me.txtCheque.Location = New System.Drawing.Point(143, 195)
        Me.txtCheque.Name = "txtCheque"
        Me.txtCheque.Size = New System.Drawing.Size(165, 20)
        Me.txtCheque.TabIndex = 11
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(323, 197)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 15)
        Me.Label10.TabIndex = 33
        Me.Label10.Text = "Banco"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(368, 195)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(152, 21)
        Me.ComboBox1.TabIndex = 30
        '
        'frmSegumanu
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(664, 604)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtCheque)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtSaldoant)
        Me.Controls.Add(Me.txtconPlazo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtSumaseg)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnTabla)
        Me.Controls.Add(Me.lblSumaseg)
        Me.Controls.Add(Me.txtVenci)
        Me.Controls.Add(Me.txtFeven)
        Me.Controls.Add(Me.txtTasaAp)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.txtAnexo)
        Me.Controls.Add(Me.txtPrima)
        Me.Controls.Add(Me.txtPlazo)
        Me.Controls.Add(Me.txtMeses)
        Me.Controls.Add(Me.txtVencimiento)
        Me.Controls.Add(Me.txtCusnam)
        Me.Controls.Add(Me.txtFecha)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmSegumanu"
        Me.Text = "Carga de Seguros"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub frmSegumanu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim cm4 As New SqlCommand()
        Dim dsAgil As New DataSet()
        Dim dsBco As New DataSet()
        Dim daAnexos As New SqlDataAdapter(cm1)
        Dim daEdoctav As New SqlDataAdapter(cm2)
        Dim daEdoctas As New SqlDataAdapter(cm3)
        Dim daBancos As New SqlDataAdapter(cm4)
        Dim drEdoctav As DataRow()
        Dim drAnexo As DataRow
        Dim drDato As DataRow
        Dim drDatos As DataRowCollection
        Dim relAnexoEdoctav As DataRelation

        ' Declaración de variables de datos

        Dim cAnexo As String
        Dim cFecha As String
        Dim cFeven As String
        Dim lSaldoSeg As Boolean
        Dim i As Int16
        Dim nVencimiento As Int32
        Dim nMesesxtrans As Int32
        Dim nPlazo As Int32
        Dim nIntEquipo As Decimal
        Dim nCarEquipo As Decimal
        Dim nSaldoEquipo As Decimal
        Dim nTasaApli As Decimal

        cAnexo = Mid(txtAnexo.Text, 1, 5) & Mid(txtAnexo.Text, 7, 4)
        cFecha = DTOC(Today)

        ' El siguiente Stored Procedure trae todos los atributos de la tabla Anexos,
        ' para un anexo dado

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DatosCon1"
            .Connection = cnAgil
            .Parameters.Add("@Anexo", SqlDbType.NVarChar)
            .Parameters(0).Value = cAnexo
        End With

        ' Con este Stored Procedure obtengo la tabla de amortización del Equipo

        With cm2
            .CommandType = CommandType.StoredProcedure
            .CommandText = "TablaEquipo1"
            .Connection = cnAgil
            .Parameters.Add("@Anexo", SqlDbType.NVarChar)
            .Parameters(0).Value = cAnexo
        End With

        ' Con este Stored Procedure obtengo la tabla de amortización del Seguro

        With cm3
            .CommandType = CommandType.StoredProcedure
            .CommandText = "TablaSeguro1"
            .Connection = cnAgil
            .Parameters.Add("@Anexo", SqlDbType.NVarChar)
            .Parameters(0).Value = cAnexo
        End With

        ' Con este Stored Procedure obtengo la información de los Bancos

        With cm4
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Bancos1"
            .Connection = cnAgil
        End With

        ' Llenar el DataSet lo cual abre y cierra la conexión

        daAnexos.Fill(dsAgil, "Anexos")
        daEdoctav.Fill(dsAgil, "Edoctav")
        daEdoctas.Fill(dsAgil, "Edoctas")
        daBancos.Fill(dsBco, "Bancos")

        ' Establecer la relación entre Anexos y Edoctav

        relAnexoEdoctav = New DataRelation("AnexoEdoctav", dsAgil.Tables("Anexos").Columns("Anexo"), dsAgil.Tables("Edoctav").Columns("Anexo"))
        dsAgil.EnforceConstraints = False
        dsAgil.Relations.Add(relAnexoEdoctav)

        ' Validando que el contrato esté Activo

        drAnexo = dsAgil.Tables("Anexos").Rows(0)

        txtCusnam.Text = drAnexo("Descr")
        cCliente = drAnexo("Cliente")
        nPlazo = drAnexo("Plazo")
        nTasaApli = (drAnexo("Tasas") + drAnexo("Difer")) / 1200
        txtTasaAp.Text = nTasaApli

        If drAnexo("Flcan") <> "A" Then

            MsgBox("Contrato NO activo", MsgBoxStyle.OkOnly, "Mensaje")
            Me.Close()

        Else

            ' Validando que el Contrato tenga saldo insoluto 
            ' (que tenga por lo menos un mes por transcurrir) 

            drEdoctav = drAnexo.GetChildRows("AnexoEdoctav")

            nIntEquipo = 0
            nCarEquipo = 0
            nSaldoEquipo = 0

            TraeSald(drEdoctav, cFecha, nSaldoEquipo, nIntEquipo, nCarEquipo)

            If nSaldoEquipo = 0 Then

                MsgBox("Contrato SIN saldo insoluto", MsgBoxStyle.OkOnly, "Mensaje")
                Me.Close()

            Else

                ' Por último validamos que no exista saldo en seguro financiado

                lSaldoSeg = False
                nLetras = 0

                drDatos = dsAgil.Tables("Edoctas").Rows

                For Each drDato In drDatos
                    If drDato("Nufac") = 0 And drDato("Indrec") = "S" Then
                        nLetras += 1
                        lSaldoSeg = True
                        If nLetras = 1 Then
                            txtSaldoant.Text = drDato("Saldo")
                        End If
                    Else
                        nVenciant = Val(drDato("Letra"))
                    End If
                Next

                If lSaldoSeg = True Then
                    If nLetras = 1 Then
                        lblPlazorestante.Text = "Le queda " & nLetras.ToString & " mes de plazo de su póliza anterior y su salso es por  " & FormatNumber(txtSaldoant.Text, 2)
                    Else
                        lblPlazorestante.Text = "Le quedan " & nLetras.ToString & " meses de plazo de su póliza anterior y su saldo es por  " & FormatNumber(txtSaldoant.Text, 2)
                    End If
                    GroupBox1.Enabled = True
                    DateTimePicker1.Enabled = False
                    txtCheque.Enabled = False
                    ComboBox1.Enabled = False
                    txtPlazo.Enabled = False
                    txtPrima.Enabled = False
                End If

                ComboBox1.MaxDropDownItems = 6

                ComboBox1.DataSource = dsBco
                ComboBox1.DisplayMember = "Bancos.DescBanco"
                ComboBox1.ValueMember = "Bancos.Banco"

                ' Identificamos a partir de cuál vencimiento se comenzará a cargar el seguro

                nVencimiento = 0

                For Each drDato In drEdoctav
                    If drDato("Nufac") = 0 And drDato("Indrec") = "S" And nVencimiento = 0 Then
                        nVencimiento = Val(drDato("Letra"))
                        cFeven = drDato("Feven")
                    End If
                Next
                txtVenci.Text = nVencimiento
                txtFeven.Text = cFeven

                If nVencimiento = 0 Then
                    MsgBox("Existe algún ERROR en el contrato", MsgBoxStyle.OkOnly, "Mensaje")
                    Me.Close()
                Else
                    nMesesxtrans = nPlazo - nVencimiento + 1
                    txtVencimiento.Text = nVencimiento
                    txtMeses.Text = nMesesxtrans
                    txtPlazo.Text = 12
                    txtFecha.Text = Mes(cFeven)
                End If
            End If
        End If

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()

    End Sub

    Private Sub btnTabla_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTabla.Click

        Dim dtCargoseg As New DataTable("Seguro")
        Dim drDato As DataRow
        Dim cString As String
        Dim cFeven As String
        Dim cAnexo As String
        Dim i As Int32
        Dim nPlaseg As Int32
        Dim nVencimiento As Int32
        Dim nRtaseg As Decimal
        Dim nSdoseg As Decimal
        Dim nIntseg As Decimal
        Dim nCapseg As Decimal
        Dim nIvaseg As Decimal
        Dim nTasaApli As Decimal
        Dim nSumaseg As Decimal

        cAnexo = Mid(txtAnexo.Text, 1, 5) & Mid(txtAnexo.Text, 7, 4)
        btnSave.Enabled = True

        If Val(txtPlazo.Text) <= Val(txtMeses.Text) And Val(txtPlazo.Text) <= 12 Then
            If txtconPlazo.Text = "S" Then
                nSdoseg = Val(txtPrima.Text) + Val(txtSaldoant.Text)
            Else
                nSdoseg = txtPrima.Text
            End If
            nVencimiento = txtVenci.Text
            nPlaseg = txtPlazo.Text
            cFeven = txtFeven.Text
            nTasaApli = txtTasaAp.Text

            nRtaseg = Round((nSdoseg * nTasaApli) / (1 - Pow((1 + nTasaApli), -nPlaseg)), 2)

            If Val(txtPrima.Text) > 0 Then

                ' Defino una Tabla Temporal para cargar el seguro

                dtCargoseg.Columns.Add("Anexo", Type.GetType("System.String"))
                dtCargoseg.Columns.Add("Letra", Type.GetType("System.String"))
                dtCargoseg.Columns.Add("Feven", Type.GetType("System.String"))
                dtCargoseg.Columns.Add("Nufac", Type.GetType("System.Decimal"))
                dtCargoseg.Columns.Add("IndRec", Type.GetType("System.String"))
                dtCargoseg.Columns.Add("Sdoseg", Type.GetType("System.String"))
                dtCargoseg.Columns.Add("Capseg", Type.GetType("System.String"))
                dtCargoseg.Columns.Add("Intseg", Type.GetType("System.String"))
                dtCargoseg.Columns.Add("Ivaseg", Type.GetType("System.String"))
                nSumaseg = 0

                For i = 1 To nPlaseg
                    If txtconPlazo.Text = "S" And i = 1 Then
                        drDato = dtCargoseg.NewRow()
                        drDato("Anexo") = cAnexo
                        drDato("Letra") = Stuff(nVenciant.ToString, i, 0, 3)
                        drDato("Feven") = Mid(Today.ToString, 1, 10)
                        drDato("Nufac") = 7777777
                        drDato("IndRec") = "N"
                        drDato("Sdoseg") = txtSaldoant.Text
                        drDato("Capseg") = -txtPrima.Text
                        drDato("Intseg") = 0
                        drDato("Ivaseg") = 0
                        dtCargoseg.Rows.Add(drDato)
                    End If

                    cString = Stuff(nVencimiento.ToString, i, 0, 3)
                    If i > 1 Then
                        cFeven = DTOC(DateAdd(DateInterval.Month, 1, CTOD(cFeven)))
                    End If
                    nIntseg = Round(nSdoseg * nTasaApli, 2)
                    nCapseg = Round(nRtaseg - nIntseg, 2)
                    nIvaseg = Round(nIntseg * 0.15, 2)
                    drDato = dtCargoseg.NewRow()
                    drDato("Anexo") = cAnexo
                    drDato("Letra") = cString
                    drDato("Feven") = CTOD(cFeven).ToShortDateString
                    If Val(Mid(cFeven, 7, 2)) > 25 Then
                        drDato("Feven") = DayWeek(CTOD(cFeven).ToShortDateString)
                    End If
                    drDato("Nufac") = 0
                    drDato("IndRec") = "S"
                    drDato("Sdoseg") = nSdoseg
                    drDato("Capseg") = nCapseg
                    drDato("Intseg") = nIntseg
                    drDato("Ivaseg") = nIvaseg
                    dtCargoseg.Rows.Add(drDato)
                    nSdoseg = nSdoseg - nCapseg
                    nSumaseg = nSumaseg + nCapseg
                    nVencimiento += 1
                Next
                txtSumaseg.Text = nSumaseg
                DataGrid1.DataSource = dtCargoseg
                DataGrid1.Visible = True
                lblSumaseg.Text = "Suma cargada al seguro " & FormatNumber(nSumaseg.ToString, 2)
                lblSumaseg.Visible = True
                btnExit.Enabled = True
            Else
                txtPrima.Focus()
            End If
        Else
            MsgBox("Plazo No Correcto", MsgBoxStyle.Information, "Mensaje del Sistema")
            txtPlazo.Focus()
        End If

    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim cm4 As New SqlCommand()
        Dim strInsert As String
        Dim strUpdate As String

        ' Declaración de variables de datos

        Dim cAnexo As String
        Dim cFecha As String
        Dim nVencimiento As Int32
        Dim i As Int32

        cFecha = DTOC(Today)
        nVencimiento = Val(txtPlazo.Text)
        cAnexo = Mid(txtAnexo.Text, 1, 5) & Mid(txtAnexo.Text, 7, 4)

        Try

            cnAgil.Open()

            If Len(txtCheque.Text) <= 1 Then
                MsgBox("Necesito este Dato", MsgBoxStyle.Information, "Mensaje del Sistema")
                txtCheque.Focus()
            End If

            If txtconPlazo.Text = "S" Then

                With cm3
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "BorraPlazos"
                    .Connection = cnAgil
                    .Parameters.Add("@Anexo", SqlDbType.NVarChar)
                    .Parameters(0).Value = cAnexo
                End With
                cm3.ExecuteNonQuery()

                For i = 0 To nVencimiento
                    strInsert = "INSERT INTO Edoctas( Anexo, Letra, Feven, Nufac, Indrec, Saldo, Abcap, Inter, Iva )"
                    strInsert = strInsert & "VALUES('"
                    strInsert = strInsert & DataGrid1.Item(i, 0) & "', '"
                    strInsert = strInsert & DataGrid1.Item(i, 1) & "', '"
                    strInsert = strInsert & DTOC(DataGrid1.Item(i, 2)) & "', '"
                    strInsert = strInsert & DataGrid1.Item(i, 3) & "', '"
                    strInsert = strInsert & DataGrid1.Item(i, 4) & "', '"
                    strInsert = strInsert & DataGrid1.Item(i, 5) & "', '"
                    strInsert = strInsert & DataGrid1.Item(i, 6) & "', '"
                    strInsert = strInsert & DataGrid1.Item(i, 7) & "', '"
                    strInsert = strInsert & DataGrid1.Item(i, 8) & "')"
                    cm1 = New SqlCommand(strInsert, cnAgil)
                    cm1.ExecuteNonQuery()
                Next

            Else

                For i = 0 To nVencimiento - 1
                    strInsert = "INSERT INTO Edoctas( Anexo, Letra, Feven, Nufac, Indrec, Saldo, Abcap, Inter, Iva )"
                    strInsert = strInsert & "VALUES('"
                    strInsert = strInsert & DataGrid1.Item(i, 0) & "', '"
                    strInsert = strInsert & DataGrid1.Item(i, 1) & "', '"
                    strInsert = strInsert & DTOC(DataGrid1.Item(i, 2)) & "', '"
                    strInsert = strInsert & DataGrid1.Item(i, 3) & "', '"
                    strInsert = strInsert & DataGrid1.Item(i, 4) & "', '"
                    strInsert = strInsert & DataGrid1.Item(i, 5) & "', '"
                    strInsert = strInsert & DataGrid1.Item(i, 6) & "', '"
                    strInsert = strInsert & DataGrid1.Item(i, 7) & "', '"
                    strInsert = strInsert & DataGrid1.Item(i, 8) & "')"
                    cm1 = New SqlCommand(strInsert, cnAgil)
                    cm1.ExecuteNonQuery()
                Next

            End If

            strInsert = "INSERT INTO Seguros(Anexo, Cliente, Prima, Fechapag, Cheque, Banco, Vencimiento, Fechacap, Plazo)"
            strInsert = strInsert & "VALUES('"
            strInsert = strInsert & cAnexo & "', '"
            strInsert = strInsert & cCliente & "', '"
            strInsert = strInsert & txtPrima.Text & "', '"
            strInsert = strInsert & DTOC(DateTimePicker1.Value) & "', '"
            strInsert = strInsert & txtCheque.Text & "', '"
            strInsert = strInsert & ComboBox1.SelectedValue.ToString() & "', '"
            strInsert = strInsert & txtVencimiento.Text & "', '"
            strInsert = strInsert & cFecha & "', '"
            strInsert = strInsert & txtPlazo.Text & "')"
            cm4 = New SqlCommand(strInsert, cnAgil)
            cm4.ExecuteNonQuery()

            strUpdate = "UPDATE Anexos SET Finse = 'S'" & ","
            strUpdate = strUpdate & " Plaseg = " & nVencimiento & ","
            strUpdate = strUpdate & " SegEq = " & Val(txtSumaseg.Text) & ","
            strUpdate = strUpdate & " Ivase = " & "'" & 0 & "'"
            strUpdate = strUpdate & " WHERE Anexo = '" & cAnexo & "'"
            cm2 = New SqlCommand(strUpdate, cnAgil)
            cm2.ExecuteNonQuery()
            cnAgil.Close()

        Catch eException As Exception

            MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje")

        End Try

        MsgBox("Cargo dado de Alta", MsgBoxStyle.Information, "Mensaje del Sistema")

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()

        Me.Close()

    End Sub

    Private Sub txtPlazo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPlazo.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii, txtPlazo.Text))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtPrima_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrima.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii, txtPrima.Text))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnContinuar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnContinuar.Click
        If rbPlazoant.Checked = True Or rbPlazonvo.Checked = True Then
            txtPrima.Enabled = True
            txtconPlazo.Text = "S"
            DateTimePicker1.Enabled = True
            txtCheque.Enabled = True
            ComboBox1.Enabled = True
            If rbPlazoant.Checked = True Then
                txtPlazo.Text = nLetras
                txtPlazo.Enabled = False
            Else
                txtPlazo.Enabled = True
            End If
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

End Class
