Option Explicit On 

Imports System.Data.SqlClient

Public Class frmPideAnexo

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
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents lblAnexos As System.Windows.Forms.Label
    Friend WithEvents lblClientes As System.Windows.Forms.Label
    Friend WithEvents txtMenu As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.lblClientes = New System.Windows.Forms.Label
        Me.lblAnexos = New System.Windows.Forms.Label
        Me.txtMenu = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.Location = New System.Drawing.Point(16, 40)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(424, 21)
        Me.ComboBox1.TabIndex = 2
        Me.ComboBox1.Text = "ComboBox1"
        '
        'ListBox1
        '
        Me.ListBox1.Location = New System.Drawing.Point(464, 40)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(152, 472)
        Me.ListBox1.TabIndex = 4
        Me.ListBox1.Visible = False
        '
        'lblClientes
        '
        Me.lblClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClientes.Location = New System.Drawing.Point(16, 16)
        Me.lblClientes.Name = "lblClientes"
        Me.lblClientes.Size = New System.Drawing.Size(432, 16)
        Me.lblClientes.TabIndex = 1
        Me.lblClientes.Text = "Selecciona un Cliente de la siguiente Lista"
        '
        'lblAnexos
        '
        Me.lblAnexos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAnexos.Location = New System.Drawing.Point(465, 16)
        Me.lblAnexos.Name = "lblAnexos"
        Me.lblAnexos.Size = New System.Drawing.Size(149, 16)
        Me.lblAnexos.TabIndex = 3
        Me.lblAnexos.Text = "Contratos de este cliente"
        Me.lblAnexos.Visible = False
        '
        'txtMenu
        '
        Me.txtMenu.Location = New System.Drawing.Point(16, 112)
        Me.txtMenu.Name = "txtMenu"
        Me.txtMenu.ReadOnly = True
        Me.txtMenu.Size = New System.Drawing.Size(40, 20)
        Me.txtMenu.TabIndex = 5
        Me.txtMenu.Visible = False
        '
        'frmPideAnexo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(633, 526)
        Me.Controls.Add(Me.txtMenu)
        Me.Controls.Add(Me.lblAnexos)
        Me.Controls.Add(Me.lblClientes)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Name = "frmPideAnexo"
        Me.Text = "Selección de Cliente y Contrato"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub frmPideAnexo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daClientes As New SqlDataAdapter(cm1)
        Dim dsAgil As New DataSet()

        Select Case txtMenu.Text
            Case "mnuDatosCon"
                Me.Text = "Selección de Cliente y Contrato para Consulta de Datos del Contrato"
            Case "mnuActiAnex"
                Me.Text = "Selección de Cliente y Contrato para Activación de Anexos"
            Case "mnuCaptFact"
                Me.Text = "Selección de Cliente y Contrato para Captura de Facturas Originales"
            Case "mnuPrendaria"
                Me.Text = "Selección de Cliente y Contrato para Captura de Garantía Prendaria"
            Case "mnuDesactiv"
                Me.Text = "Selección de Cliente y Contrato para Desactivación de Anexos"
            Case "mnuSegumanu"
                Me.Text = "Selección de Cliente y Contrato para Captura de Seguros Financiados"
            Case "mnuCalcfini"
                Me.Text = "Selección de Cliente y Contrato para Cálculo de Finiquito"
            Case "mnuAdelanto"
                Me.Text = "Selección de Cliente y Contrato para Adelanto a Capital"
            Case "mnuFiniquito"
                Me.Text = "Selección de Cliente y Contrato para Finiquito"
            Case "mnuImprActi"
                Me.Text = "Selección de Cliente y Contrato para Imprimir la Factura de Activo Fijo"
            Case "mnuCaptValo"
                Me.Text = "Selección de Cliente y Contrato para Captura de Valores"
            Case "mnuCaptSegu"
                Me.Text = "Selección de Cliente y Contrato para Captura de Seguros"
            Case "mnuCartaRat"
                Me.Text = "Selección de Cliente y Contrato para Carta de Ratificación"
            Case "mnuImprCert"
                Me.Text = "Selección de Cliente y Contrato para Estado de Cuenta Certificado"
        End Select

        ' Este Stored Procedure trae TODOS los clientes que tengan generado por lo menos 1 contrato, sin
        ' importar si se trata de contratos activos, cancelados, terminados, en suspenso, o dados de baja

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "PideAnex1"
            .Connection = cnAgil
        End With

        ComboBox1.MaxDropDownItems = 35

        Try

            ' Llenar el DataSet a través del DataAdapter lo cual abre y cierra la conexión

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

        ' Declaración de variables de conexíón ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daAnexos As New SqlDataAdapter(cm1)
        Dim dsAgil As New DataSet()

        ' Declaración de variables de datos

        Dim cAnexo As String
        Dim cCliente As String
        Dim cFlcan As String
        Dim cStatus As String

        ' Crear 2 DataRow (El primero mantiene 1 solo anexo y el segundo n anexos)

        Dim drAnexo As DataRow
        Dim drAnexos As DataRowCollection

        If Not ComboBox1.SelectedValue Is Nothing Then

            cCliente = ComboBox1.SelectedValue.ToString()

            ' Este Stored Procedure trae los contratos del cliente seleccionado en el ComboBox, por lo que es más
            ' óptimo que traer TODOS los contratos y a TODOS los clientes como lo había pensado originalmente

            With cm1
                .CommandType = CommandType.StoredProcedure
                .CommandText = "PideAnex2"
                .Connection = cnAgil
                .Parameters.Add("@Cliente", SqlDbType.NVarChar)
                .Parameters(0).Value = cCliente
            End With

            ' Buscar a dicho cliente en el DataSet y retornar sus datos en el DataRow

            daAnexos.Fill(dsAgil, "Anexos")
            drAnexos = dsAgil.Tables("Anexos").Rows

            lblAnexos.Visible = True
            ListBox1.Visible = True
            ListBox1.Items.Clear()

            For Each drAnexo In drAnexos
                cAnexo = Mid(drAnexo("Anexo"), 1, 5) & "/" & Mid(drAnexo("Anexo"), 6, 4)
                cFlcan = drAnexo("Flcan")
                cStatus = "**ERROR**"
                Select Case cFlcan
                    Case "S"
                        cStatus = "SUSPENSO "
                    Case "A"
                        cStatus = "ACTIVO   "
                    Case "T"
                        cStatus = "TERMINADO"
                    Case "C"
                        cStatus = "CANCELADO"
                    Case "B"
                        cStatus = "BAJA     "
                End Select
                ListBox1.Items.Add(cAnexo & " " & cStatus)
            Next

        End If

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        Select Case txtMenu.Text
            Case "mnuDatosCon"
                Dim newfrmDatosCon As New frmDatosCon(Mid(ListBox1.SelectedItem, 1, 10))
                newfrmDatosCon.Show()
            Case "mnuActiAnex"
                Dim newfrmActiAnex As New frmActiAnex(Mid(ListBox1.SelectedItem, 1, 10))
                newfrmActiAnex.Show()
            Case "mnuCaptFact"
                Dim newfrmCaptFact As New frmCaptFact(Mid(ListBox1.SelectedItem, 1, 10))
                newfrmCaptFact.Show()
            Case "mnuPrendaria"
                Dim newfrmPrendaria As New frmPrendaria(Mid(ListBox1.SelectedItem, 1, 10))
                newfrmPrendaria.Show()
            Case "mnuDesactiv"
                Dim newfrmDesactiv As New frmDesactiv(Mid(ListBox1.SelectedItem, 1, 10))
                newfrmDesactiv.Show()
            Case "mnuSegumanu"
                Dim newfrmSegumanu As New frmSegumanu(Mid(ListBox1.SelectedItem, 1, 10))
                newfrmSegumanu.Show()
            Case "mnuCalcfini"
                Dim newfrmCalcfini As New frmCalcfini(Mid(ListBox1.SelectedItem, 1, 10))
                newfrmCalcfini.Show()
            Case "mnuAdelanto"
                Dim newfrmAdelanto As New frmAdelanto(Mid(ListBox1.SelectedItem, 1, 10))
                newfrmAdelanto.Show()
            Case "mnuFiniquito"
                Dim newfrmFiniquito As New frmFiniquito(Mid(ListBox1.SelectedItem, 1, 10))
                newfrmFiniquito.Show()
            Case "mnuImprActi"
                Dim newfrmImprActi As New frmImpracti(Mid(ListBox1.SelectedItem, 1, 10))
                newfrmImprActi.Show()
            Case "mnuCaptValo"
                Dim newfrmCaptValo As New frmCaptValo(Mid(ListBox1.SelectedItem, 1, 10))
                newfrmCaptValo.Show()
            Case "mnuCaptSegu"
                Dim newfrmCaptSegu As New frmCaptsegu(Mid(ListBox1.SelectedItem, 1, 10))
                newfrmCaptSegu.Show()
            Case "mnuCartaRat"
                Dim newfrmCartaRat As New frmCartaRat(Mid(ListBox1.SelectedItem, 1, 10))
                newfrmCartaRat.Show()
            Case "mnuImprCert"
                Dim newfrmImprCert As New frmImprCert(Mid(ListBox1.SelectedItem, 1, 10))
                newfrmImprCert.Show()
        End Select

    End Sub

End Class
