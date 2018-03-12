Option Explicit On 

Imports System.Data.SqlClient

Public Class frmDomicilio

    Inherits System.Windows.Forms.Form

    Dim dtTemporal As New DataTable("Copos")
    Dim drCopos As DataRowCollection

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
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents btnPostal As System.Windows.Forms.Button
    Friend WithEvents btnRetener As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCalle As System.Windows.Forms.TextBox
    Friend WithEvents txtColonia As System.Windows.Forms.TextBox
    Friend WithEvents txtEstado As System.Windows.Forms.TextBox
    Friend WithEvents txtDeleg As System.Windows.Forms.TextBox
    Friend WithEvents cbPlaza As System.Windows.Forms.ComboBox
    Friend WithEvents txtObserv As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtTipo As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDomicilio))
        Me.txtCliente = New System.Windows.Forms.TextBox
        Me.btnPostal = New System.Windows.Forms.Button
        Me.btnRetener = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnSave = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtObserv = New System.Windows.Forms.TextBox
        Me.cbPlaza = New System.Windows.Forms.ComboBox
        Me.txtDeleg = New System.Windows.Forms.TextBox
        Me.txtEstado = New System.Windows.Forms.TextBox
        Me.txtColonia = New System.Windows.Forms.TextBox
        Me.txtCalle = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtTipo = New System.Windows.Forms.TextBox
        Me.btnExit = New System.Windows.Forms.Button
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtCliente
        '
        Me.txtCliente.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtCliente.Location = New System.Drawing.Point(139, 47)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(10, 20)
        Me.txtCliente.TabIndex = 0
        Me.txtCliente.Visible = False
        '
        'btnPostal
        '
        Me.btnPostal.Location = New System.Drawing.Point(434, 302)
        Me.btnPostal.Name = "btnPostal"
        Me.btnPostal.Size = New System.Drawing.Size(72, 24)
        Me.btnPostal.TabIndex = 1
        Me.btnPostal.Text = "Postal"
        '
        'btnRetener
        '
        Me.btnRetener.Location = New System.Drawing.Point(531, 302)
        Me.btnRetener.Name = "btnRetener"
        Me.btnRetener.Size = New System.Drawing.Size(72, 24)
        Me.btnRetener.TabIndex = 2
        Me.btnRetener.Text = "Retener"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtObserv)
        Me.GroupBox1.Controls.Add(Me.cbPlaza)
        Me.GroupBox1.Controls.Add(Me.txtDeleg)
        Me.GroupBox1.Controls.Add(Me.txtEstado)
        Me.GroupBox1.Controls.Add(Me.txtColonia)
        Me.GroupBox1.Controls.Add(Me.txtCalle)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 79)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(688, 208)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos para Domicilio de Entrega"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(15, 132)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 16)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Observaciones"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(202, 82)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(127, 12)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Delegación o Municipio"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(600, 169)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(72, 24)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "Salvar"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(203, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 16)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Estado"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 16)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Codigo Postal"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Calle"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(202, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(127, 19)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Colonia (solo el nombre)"
        '
        'txtObserv
        '
        Me.txtObserv.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtObserv.Location = New System.Drawing.Point(104, 127)
        Me.txtObserv.Name = "txtObserv"
        Me.txtObserv.Size = New System.Drawing.Size(568, 20)
        Me.txtObserv.TabIndex = 5
        '
        'cbPlaza
        '
        Me.cbPlaza.Location = New System.Drawing.Point(102, 49)
        Me.cbPlaza.Name = "cbPlaza"
        Me.cbPlaza.Size = New System.Drawing.Size(62, 21)
        Me.cbPlaza.TabIndex = 4
        '
        'txtDeleg
        '
        Me.txtDeleg.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtDeleg.Location = New System.Drawing.Point(332, 76)
        Me.txtDeleg.Name = "txtDeleg"
        Me.txtDeleg.ReadOnly = True
        Me.txtDeleg.Size = New System.Drawing.Size(340, 20)
        Me.txtDeleg.TabIndex = 3
        '
        'txtEstado
        '
        Me.txtEstado.AcceptsReturn = True
        Me.txtEstado.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtEstado.Location = New System.Drawing.Point(332, 49)
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.ReadOnly = True
        Me.txtEstado.Size = New System.Drawing.Size(340, 20)
        Me.txtEstado.TabIndex = 2
        '
        'txtColonia
        '
        Me.txtColonia.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtColonia.Location = New System.Drawing.Point(332, 101)
        Me.txtColonia.Margin = New System.Windows.Forms.Padding(0)
        Me.txtColonia.Name = "txtColonia"
        Me.txtColonia.Size = New System.Drawing.Size(339, 20)
        Me.txtColonia.TabIndex = 1
        '
        'txtCalle
        '
        Me.txtCalle.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.txtCalle.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtCalle.Location = New System.Drawing.Point(104, 24)
        Me.txtCalle.Margin = New System.Windows.Forms.Padding(0)
        Me.txtCalle.Name = "txtCalle"
        Me.txtCalle.Size = New System.Drawing.Size(568, 20)
        Me.txtCalle.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(15, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(256, 21)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Seleccione un Cliente de la siguiente Lista"
        '
        'txtTipo
        '
        Me.txtTipo.Location = New System.Drawing.Point(608, 34)
        Me.txtTipo.Name = "txtTipo"
        Me.txtTipo.Size = New System.Drawing.Size(8, 20)
        Me.txtTipo.TabIndex = 7
        Me.txtTipo.Text = "TextBox1"
        Me.txtTipo.Visible = False
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(632, 302)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(72, 24)
        Me.btnExit.TabIndex = 8
        Me.btnExit.Text = "Salir"
        '
        'ComboBox1
        '
        Me.ComboBox1.Location = New System.Drawing.Point(281, 19)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(424, 21)
        Me.ComboBox1.TabIndex = 9
        Me.ComboBox1.Text = "ComboBox1"
        '
        'frmDomicilio
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(720, 356)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.txtTipo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnRetener)
        Me.Controls.Add(Me.btnPostal)
        Me.Controls.Add(Me.txtCliente)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDomicilio"
        Me.Text = "Actualización de domicilios para mensajería"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub frmDomicilio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim dsAgil As New DataSet()
        Dim daClientes As New SqlDataAdapter(cm1)
        Dim daCopos As New SqlDataAdapter(cm2)
        Dim drTemporal As DataRow
        Dim drCop As DataRow
        Dim dtTemporal As New DataTable("Copos")
        Dim myColArray(1) As DataColumn

        Dim i As Integer

        ' Este Stored Procedure trae TODOS los clientes que existan en la tabla Clientes sin importar 
        ' si tienen o no contratos o solicitudes generadas

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "ContClie1"
            .Connection = cnAgil
        End With

        ' El siguiente Stored Procedure trae todos los atributos de todas las Plazas

        With cm2
            .CommandType = CommandType.StoredProcedure
            .CommandText = "PideCopos1"
            .Connection = cnAgil
        End With

        Try

            ' Llenar el DataSet

            daClientes.Fill(dsAgil, "Clientes")
            daCopos.Fill(dsAgil, "Codig")

            btnSave.Enabled = False
            GroupBox1.Enabled = False

            ' Ligar la tabla Clientes del dataset dsAgil al ComboBox

            ComboBox1.DataSource = dsAgil
            ComboBox1.DisplayMember = "Clientes.Descr"
            ComboBox1.ValueMember = "Clientes.Cliente"

            ' Creo la tabla Temporal que servira para llenar el combobox de codigos postales

            dtTemporal.Columns.Add("Numero", Type.GetType("System.Decimal"))
            dtTemporal.Columns.Add("Copos", Type.GetType("System.String"))
            dtTemporal.Columns.Add("Dato", Type.GetType("System.String"))
            dtTemporal.Columns.Add("Plaza", Type.GetType("System.String"))

            i = 1
            For Each drCop In dsAgil.Tables("Codig").Rows
                drTemporal = dtTemporal.NewRow()
                drTemporal("Numero") = i
                drTemporal("Copos") = drCop("Copos")
                drTemporal("Dato") = drCop("Dato")
                drTemporal("Plaza") = drCop("Plaza")
                dtTemporal.Rows.Add(drTemporal)
                i += 1
            Next
            dsAgil.Tables.Add(dtTemporal)
            myColArray(0) = dsAgil.Tables("Copos").Columns("Copos")
            dsAgil.Tables("Copos").PrimaryKey = myColArray

            drCopos = dsAgil.Tables("Copos").Rows

            ' Ligar la tabla Plazas del dataset dsAgil al ComboBox Plazas

            cbPlaza.DataSource = dsAgil
            cbPlaza.DisplayMember = "Copos.Copos"
            cbPlaza.ValueMember = "Copos.Dato"
            cbPlaza.SelectedIndex = 12854

        Catch eException As Exception

            MsgBox(eException.Source & " " & eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")

        End Try

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub btnPostal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPostal.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As SqlConnection = New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim cm4 As New SqlCommand()
        Dim dsAgil As New DataSet()
        Dim daPostal As New SqlDataAdapter(cm1)
        Dim daCliente As New SqlDataAdapter(cm2)
        Dim daReten As New SqlDataAdapter(cm3)
        Dim drDato As DataRow
        Dim drCliente As DataRow
        Dim drDatos As DataRowCollection
        Dim drDatos1 As DataRowCollection
        Dim myColArray(1) As DataColumn
        Dim myColArray1(1) As DataColumn

        'Declaración de variables de datos

        Dim cCalle As String
        Dim cCol As String
        Dim cCopos As String
        Dim cDeleg As String
        Dim cPlaza As String
        Dim cObserv As String
        Dim strBorra As String
        Dim cAgrupa As String
        Dim nCount As Integer
        Dim Num As Integer

        txtCliente.Text = ComboBox1.SelectedValue.ToString()
        ComboBox1.MaxDropDownItems = 30

        ' Obtengo la información de la tabla Postal

        With cm1
            .CommandType = CommandType.Text
            .CommandText = "SELECT Postal.*, Plazas.descPlaza FROM Postal INNER JOIN Plazas On Postal.Plaza = Plazas.Plaza"
            .Connection = cnAgil
        End With

        ' Obtengo información del Cliente seleccionado 

        With cm2
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DatosClie1"
            .Connection = cnAgil
            .Parameters.Add("@Cliente", SqlDbType.NVarChar)
            .Parameters(0).Value = txtCliente.Text
        End With

        ' Obtengo la información de la tabla Retener

        With cm3
            .CommandType = CommandType.Text
            .CommandText = "SELECT Retener.* FROM Retener"
            .Connection = cnAgil
        End With

        daPostal.Fill(dsAgil, "Postal")
        daCliente.Fill(dsAgil, "Cliente")
        daReten.Fill(dsAgil, "Reten")
        drDatos1 = dsAgil.Tables("Reten").Rows
        myColArray1(0) = dsAgil.Tables("Reten").Columns("Cliente")
        dsAgil.Tables("Reten").PrimaryKey = myColArray1
        drDatos = dsAgil.Tables("Postal").Rows
        myColArray(0) = dsAgil.Tables("Postal").Columns("Cliente")
        dsAgil.Tables("Postal").PrimaryKey = myColArray

        drCliente = dsAgil.Tables("Cliente").Rows(0)
        cAgrupa = drCliente.Item("Agrupa")

        If Trim(cAgrupa) <> "" Then

            MsgBox("Este Cliente se Agrupa no se puede cambiar Domicilio", MsgBoxStyle.Information, "Mensaje del Sistema")

        Else

            nCount = 1

            If drDatos1.Find(txtCliente.Text) Is Nothing Then
                nCount = 0
            Else
                If MsgBox("La información de este Cliente se RETIENE desea eliminarlo de esta Base", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Mensaje") = MsgBoxResult.Yes Then
                    cnAgil.Open()
                    strBorra = "DELETE FROM Retener WHERE Cliente = '" & txtCliente.Text & "'"
                    cm4 = New SqlCommand(strBorra, cnAgil)
                    cm4.ExecuteNonQuery()
                    cnAgil.Close()
                    MsgBox("El Cliente se Borro de la base Retener")
                    nCount = 0
                End If
            End If

            If nCount = 0 Then
                btnRetener.Enabled = False
                btnSave.Enabled = True
                GroupBox1.Enabled = True

                If drDatos.Find(txtCliente.Text) Is Nothing Then
                    cCalle = "  "
                    cCol = "   "
                    cCopos = "   "
                    cDeleg = "   "
                    cPlaza = "  "
                    cObserv = "    "
                    txtTipo.Text = "N"
                Else
                    For Each drDato In drDatos
                        If drDato("Cliente") = txtCliente.Text Then
                            cCalle = drDato("Calle")
                            cCol = drDato("Colonia")
                            cCopos = drDato("Copos")
                            cObserv = drDato("Observa")
                            txtTipo.Text = "E"
                        End If
                    Next
                End If

                If RTrim(cCopos) <> "" Then
                    Num = drCopos.Find(cCopos).Item("Numero")
                    cbPlaza.SelectedIndex = Num - 1
                End If
                txtCalle.Text = cCalle
                txtColonia.Text = cCol
                txtObserv.Text = cObserv

            End If

            cnAgil.Close()
            cnAgil.Dispose()
            cm1.Dispose()
            cm3.Dispose()
            cm4.Dispose()
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim strInsert As String
        Dim strUpdate As String

        ' Declaración de variables de datos

        Dim cPlaza As String
        Dim cFecha As String

        cPlaza = cbPlaza.SelectedItem("Plaza").ToString
        cFecha = DTOC(Today)

        Try
            If txtTipo.Text = "N" Then
                cnAgil.Open()
                strInsert = "INSERT INTO Postal(Cliente,Calle,Colonia,Copos,Delegacion,Plaza,Fecha,Observa)"
                strInsert = strInsert & " VALUES ('"
                strInsert = strInsert & txtCliente.Text & "', '"
                strInsert = strInsert & txtCalle.Text & "', '"
                strInsert = strInsert & txtColonia.Text & "', '"
                strInsert = strInsert & cbPlaza.SelectedItem("Copos").ToString & "', '"
                strInsert = strInsert & txtDeleg.Text & "', '"
                strInsert = strInsert & cPlaza & "', '"
                strInsert = strInsert & cFecha & "', '"
                strInsert = strInsert & txtObserv.Text & "')"
                cm1 = New SqlCommand(strInsert, cnAgil)
                cm1.ExecuteNonQuery()
                cnAgil.Close()
            Else
                cnAgil.Open()
                strUpdate = "UPDATE Postal SET Calle = '" & txtCalle.Text & "'"
                strUpdate = strUpdate & ", Colonia = '" & txtColonia.Text & "'"
                strUpdate = strUpdate & ", Copos = '" & cbPlaza.SelectedItem("Copos").ToString & "'"
                strUpdate = strUpdate & ", Delegacion = '" & txtDeleg.Text & "'"
                strUpdate = strUpdate & ", Plaza = '" & cPlaza & "'"
                strUpdate = strUpdate & ", Fecha = '" & cFecha & "'"
                strUpdate = strUpdate & ", Observa = '" & txtObserv.Text & "'"
                strUpdate = strUpdate & " WHERE Cliente = '" & txtCliente.Text & "'"
                cm1 = New SqlCommand(strUpdate, cnAgil)
                cm1.ExecuteNonQuery()
                cnAgil.Close()
            End If
            btnSave.Enabled = False
            MsgBox("Datos Actualizadas", MsgBoxStyle.Information, "Mensaje del Sistema")
        Catch eException As Exception
            MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de error")
        End Try
        btnPostal.Enabled = True
        btnRetener.Enabled = True
        GroupBox1.Enabled = False

        cnAgil.Close()
        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub btnRetener_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRetener.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim cm4 As New SqlCommand()
        Dim cm5 As New SqlCommand()
        Dim dsAgil As DataSet = New DataSet()
        Dim daRetener As New SqlDataAdapter(cm1)
        Dim daPostal As New SqlDataAdapter(cm3)
        Dim daCliente As New SqlDataAdapter(cm5)
        Dim drDatos As DataRowCollection
        Dim drDatos1 As DataRowCollection
        Dim drCliente As DataRow
        Dim myColArray(1) As DataColumn
        Dim myColArray1(1) As DataColumn
        Dim strInsert As String
        Dim strBorra As String

        ' Declaración de variables de datos

        Dim cAgrupa As String
        Dim nCount As Integer

        txtCliente.Text = ComboBox1.SelectedValue.ToString()

        ' Obtengo la información de la tabla Retener

        With cm1
            .CommandType = CommandType.Text
            .CommandText = "SELECT Retener.* FROM Retener"
            .Connection = cnAgil
        End With

        ' Obtengo la información de la tabla Postal

        With cm3
            .CommandType = CommandType.Text
            .CommandText = "SELECT Postal.* FROM Postal"
            .Connection = cnAgil
        End With

        ' Obtengo información del Cliente seleccionado 

        With cm5
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DatosClie1"
            .Connection = cnAgil
            .Parameters.Add("@Cliente", SqlDbType.NVarChar)
            .Parameters(0).Value = txtCliente.Text
        End With

        daRetener.Fill(dsAgil, "Retener")
        daPostal.Fill(dsAgil, "Postal")
        daCliente.Fill(dsAgil, "Cliente")

        drDatos = dsAgil.Tables("Retener").Rows
        myColArray(0) = dsAgil.Tables("Retener").Columns("Cliente")
        dsAgil.Tables("Retener").PrimaryKey = myColArray

        drDatos1 = dsAgil.Tables("Postal").Rows
        myColArray1(0) = dsAgil.Tables("Postal").Columns("Cliente")
        dsAgil.Tables("Postal").PrimaryKey = myColArray1

        drCliente = dsAgil.Tables("Cliente").Rows(0)
        cAgrupa = drCliente.Item("Agrupa")

        If Trim(cAgrupa) <> "" Then

            MsgBox("Este Cliente se Agrupa no se puede Retener", MsgBoxStyle.Information, "Mensaje del Sistema")

        Else

            nCount = 1
            If drDatos1.Find(txtCliente.Text) Is Nothing Then
                nCount = 0
            Else
                If MsgBox("Este Cliente tiene cambio de DOMICILIO desea eliminarlo de esta Base", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Mensaje") = MsgBoxResult.Yes Then
                    cnAgil.Open()
                    strBorra = "DELETE FROM Postal WHERE Cliente = '" & txtCliente.Text & "'"
                    cm4 = New SqlCommand(strBorra, cnAgil)
                    cm4.ExecuteNonQuery()
                    cnAgil.Close()
                    MsgBox("El Cliente se Borro de la base Postal")
                    nCount = 0
                End If
            End If

            If nCount = 0 Then
                If drDatos.Find(txtCliente.Text) Is Nothing Then
                    cnAgil.Open()
                    strInsert = "INSERT INTO Retener(Cliente) VALUES ('" & txtCliente.Text & "')"
                    cm2 = New SqlCommand(strInsert, cnAgil)
                    cm2.ExecuteNonQuery()
                    cnAgil.Close()
                    MsgBox("Alta Exitosa", MsgBoxStyle.Information, "Mensaje del Sistema")
                Else
                    MsgBox("Ya Existe el Cliente", MsgBoxStyle.Information, "Mensaje del Sistema")
                End If

            End If

        End If
        cnAgil.Close()
        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()
        cm3.Dispose()
        cm4.Dispose()
    End Sub

    Private Sub cbPlaza_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbPlaza.SelectedIndexChanged

        txtEstado.Text = RTrim(Mid(cbPlaza.SelectedValue.ToString, 1, 60))
        txtDeleg.Text = RTrim(Mid(cbPlaza.SelectedValue.ToString, 61, 60))

    End Sub

    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

End Class
