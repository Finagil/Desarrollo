Option Explicit On 

Imports System.Data.SqlClient
Imports System.Math
Imports Microsoft.VisualBasic

Public Class frmContSoli

    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal cCliente As String, ByVal cDescr As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        Me.Text = "Solicitudes de " & cDescr
        txtCliente.Text = cCliente

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
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents btnAltaSolicitud As System.Windows.Forms.Button
    Friend WithEvents btnAltaDisposicion As System.Windows.Forms.Button
    Friend WithEvents btnModiSoli As System.Windows.Forms.Button
    Friend WithEvents btnActuaDat As System.Windows.Forms.Button
    Friend WithEvents btnGeneCont As System.Windows.Forms.Button
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents lblSolicitudes As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtFesol As System.Windows.Forms.TextBox
    Friend WithEvents txtLinso As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents txtCusnam As System.Windows.Forms.TextBox
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnIgnorar As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnAplicar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtImpdisp As System.Windows.Forms.TextBox
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblSolicitudes = New System.Windows.Forms.Label
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.btnAltaSolicitud = New System.Windows.Forms.Button
        Me.btnAltaDisposicion = New System.Windows.Forms.Button
        Me.btnModiSoli = New System.Windows.Forms.Button
        Me.btnActuaDat = New System.Windows.Forms.Button
        Me.btnGeneCont = New System.Windows.Forms.Button
        Me.txtCliente = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnIgnorar = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtStatus = New System.Windows.Forms.TextBox
        Me.txtCusnam = New System.Windows.Forms.TextBox
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtLinso = New System.Windows.Forms.TextBox
        Me.txtFesol = New System.Windows.Forms.TextBox
        Me.btnSalir = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btnAplicar = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtImpdisp = New System.Windows.Forms.TextBox
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblSolicitudes
        '
        Me.lblSolicitudes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSolicitudes.Location = New System.Drawing.Point(32, 16)
        Me.lblSolicitudes.Name = "lblSolicitudes"
        Me.lblSolicitudes.Size = New System.Drawing.Size(171, 12)
        Me.lblSolicitudes.TabIndex = 7
        Me.lblSolicitudes.Text = "Solicitudes de este cliente"
        '
        'ListBox1
        '
        Me.ListBox1.Location = New System.Drawing.Point(32, 40)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(264, 212)
        Me.ListBox1.TabIndex = 8
        '
        'btnAltaSolicitud
        '
        Me.btnAltaSolicitud.Location = New System.Drawing.Point(336, 40)
        Me.btnAltaSolicitud.Name = "btnAltaSolicitud"
        Me.btnAltaSolicitud.Size = New System.Drawing.Size(128, 23)
        Me.btnAltaSolicitud.TabIndex = 9
        Me.btnAltaSolicitud.Text = "Alta de Solicitud"
        '
        'btnAltaDisposicion
        '
        Me.btnAltaDisposicion.Location = New System.Drawing.Point(336, 78)
        Me.btnAltaDisposicion.Name = "btnAltaDisposicion"
        Me.btnAltaDisposicion.Size = New System.Drawing.Size(128, 23)
        Me.btnAltaDisposicion.TabIndex = 10
        Me.btnAltaDisposicion.Text = "Alta de Disposición"
        '
        'btnModiSoli
        '
        Me.btnModiSoli.Enabled = False
        Me.btnModiSoli.Location = New System.Drawing.Point(336, 117)
        Me.btnModiSoli.Name = "btnModiSoli"
        Me.btnModiSoli.Size = New System.Drawing.Size(128, 23)
        Me.btnModiSoli.TabIndex = 11
        Me.btnModiSoli.Text = "Datos Solicitud"
        '
        'btnActuaDat
        '
        Me.btnActuaDat.Location = New System.Drawing.Point(336, 156)
        Me.btnActuaDat.Name = "btnActuaDat"
        Me.btnActuaDat.Size = New System.Drawing.Size(128, 23)
        Me.btnActuaDat.TabIndex = 12
        Me.btnActuaDat.Text = "Datos Financiamiento"
        '
        'btnGeneCont
        '
        Me.btnGeneCont.Location = New System.Drawing.Point(336, 195)
        Me.btnGeneCont.Name = "btnGeneCont"
        Me.btnGeneCont.Size = New System.Drawing.Size(128, 23)
        Me.btnGeneCont.TabIndex = 13
        Me.btnGeneCont.Text = "Generar Contrato"
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(376, 8)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(10, 20)
        Me.txtCliente.TabIndex = 14
        Me.txtCliente.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnIgnorar)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtStatus)
        Me.Panel1.Controls.Add(Me.txtCusnam)
        Me.Panel1.Controls.Add(Me.btnGuardar)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtLinso)
        Me.Panel1.Controls.Add(Me.txtFesol)
        Me.Panel1.Location = New System.Drawing.Point(8, 315)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(480, 136)
        Me.Panel1.TabIndex = 15
        '
        'btnIgnorar
        '
        Me.btnIgnorar.Location = New System.Drawing.Point(288, 88)
        Me.btnIgnorar.Name = "btnIgnorar"
        Me.btnIgnorar.Size = New System.Drawing.Size(120, 23)
        Me.btnIgnorar.TabIndex = 8
        Me.btnIgnorar.Text = "Ignorar cambios"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(24, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 16)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Status"
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(152, 46)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(100, 20)
        Me.txtStatus.TabIndex = 6
        Me.txtStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCusnam
        '
        Me.txtCusnam.Location = New System.Drawing.Point(24, 16)
        Me.txtCusnam.Name = "txtCusnam"
        Me.txtCusnam.ReadOnly = True
        Me.txtCusnam.Size = New System.Drawing.Size(384, 20)
        Me.txtCusnam.TabIndex = 5
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(288, 56)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(120, 23)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.Text = "Guardar cambios"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(24, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Línea Solicitada"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(24, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Fecha de la Solicitud"
        '
        'txtLinso
        '
        Me.txtLinso.Location = New System.Drawing.Point(152, 96)
        Me.txtLinso.Name = "txtLinso"
        Me.txtLinso.Size = New System.Drawing.Size(100, 20)
        Me.txtLinso.TabIndex = 1
        Me.txtLinso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFesol
        '
        Me.txtFesol.Location = New System.Drawing.Point(152, 72)
        Me.txtFesol.Name = "txtFesol"
        Me.txtFesol.Size = New System.Drawing.Size(100, 20)
        Me.txtFesol.TabIndex = 0
        Me.txtFesol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(336, 232)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(128, 23)
        Me.btnSalir.TabIndex = 16
        Me.btnSalir.Text = "Salir"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnAplicar)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.txtImpdisp)
        Me.Panel2.Location = New System.Drawing.Point(8, 271)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(479, 38)
        Me.Panel2.TabIndex = 17
        Me.Panel2.Visible = False
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(328, 7)
        Me.btnAplicar.Name = "btnAplicar"
        Me.btnAplicar.Size = New System.Drawing.Size(128, 23)
        Me.btnAplicar.TabIndex = 9
        Me.btnAplicar.Text = "Continuar"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(20, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 18)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Importe de la Disposición"
        '
        'txtImpdisp
        '
        Me.txtImpdisp.Location = New System.Drawing.Point(169, 9)
        Me.txtImpdisp.Name = "txtImpdisp"
        Me.txtImpdisp.Size = New System.Drawing.Size(100, 20)
        Me.txtImpdisp.TabIndex = 2
        Me.txtImpdisp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'frmContSoli
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(496, 463)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.btnGeneCont)
        Me.Controls.Add(Me.btnActuaDat)
        Me.Controls.Add(Me.btnModiSoli)
        Me.Controls.Add(Me.btnAltaDisposicion)
        Me.Controls.Add(Me.btnAltaSolicitud)
        Me.Controls.Add(Me.lblSolicitudes)
        Me.Controls.Add(Me.ListBox1)
        Me.Name = "frmContSoli"
        Me.Text = "Control de Solicitudes"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub frmContSoli_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daSolicitudes As New SqlDataAdapter(cm1)
        Dim dsAgil As New DataSet()
        Dim drSolicitud As DataRow
        Dim drSolicitudes As DataRowCollection

        ' Declaración de variables de datos

        Dim cAnexo As String
        Dim cCliente As String
        Dim cDisposicion As String
        Dim cSolicitud As String

        Panel1.Visible = False

        cCliente = txtCliente.Text

        ' Este Stored Procedure trae las solicitudes y disposiciones del cliente seleccionado

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "ContSoli1"
            .Connection = cnAgil
            .Parameters.Add("@Cliente", SqlDbType.NVarChar)
            .Parameters(0).Value = cCliente
        End With

        ' Buscar a dicho cliente en el DataSet y retornar sus datos en el DataRow

        daSolicitudes.Fill(dsAgil, "Solicitudes")
        drSolicitudes = dsAgil.Tables("Solicitudes").Rows

        ListBox1.Items.Clear()

        For Each drSolicitud In drSolicitudes
            cSolicitud = drSolicitud("Solicitud")
            cDisposicion = drSolicitud("Disposicion")
            cAnexo = drSolicitud("Contrato")
            ListBox1.Items.Add(cSolicitud & " " & cDisposicion & " " & cAnexo)
        Next

        If ListBox1.Items.Count > 0 Then
            btnAltaSolicitud.Enabled = False
            btnAltaDisposicion.Enabled = True
            btnModiSoli.Enabled = True
            btnActuaDat.Enabled = True
            btnGeneCont.Enabled = True
        Else
            btnAltaSolicitud.Enabled = True
            btnAltaDisposicion.Enabled = False
            btnModiSoli.Enabled = False
            btnActuaDat.Enabled = False
            btnGeneCont.Enabled = False
        End If

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub btnAltaSolicitud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAltaSolicitud.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim cm4 As New SqlCommand()
        Dim strInsert As String
        Dim strUpdate As String

        ' Declaración de variables de datos

        Dim cSolicitud As String
        Dim cDisposicion As String
        Dim nSolicitud As Integer

        ' Lo primero que tengo que hacer es consultar el número de la última solicitud para incrementarlo
        ' y asignárselo a la que estoy dando de alta.

        With cm1
            .CommandType = CommandType.Text
            .CommandText = "SELECT IDSolicitud FROM Llaves"
            .Connection = cnAgil
        End With

        Try

            cnAgil.Open()

            nSolicitud = CInt(cm1.ExecuteScalar()) + 1
            cSolicitud = Stuff(nSolicitud.ToString, "I", "0", 6)
            cDisposicion = "001"

            strInsert = "INSERT INTO Credit(Solicitud, Fesol, Statu)"
            strInsert = strInsert & " VALUES ('"
            strInsert = strInsert & cSolicitud & "', '"
            strInsert = strInsert & DTOC(Now()) & "', '"
            strInsert = strInsert & "1"
            strInsert = strInsert & "')"
            cm2 = New SqlCommand(strInsert, cnAgil)
            cm2.ExecuteNonQuery()

            strInsert = "INSERT INTO DetSol(Solicitud, Disposicion, Cliente)"
            strInsert = strInsert & " VALUES ('"
            strInsert = strInsert & cSolicitud & "', '"
            strInsert = strInsert & cDisposicion & "', '"
            strInsert = strInsert & txtCliente.Text
            strInsert = strInsert & "')"
            cm3 = New SqlCommand(strInsert, cnAgil)
            cm3.ExecuteNonQuery()

            strUpdate = "UPDATE Llaves SET IDSolicitud = " & nSolicitud
            cm4 = New SqlCommand(strUpdate, cnAgil)
            cm4.ExecuteNonQuery()

            cnAgil.Close()

            ListBox1.Items.Add(cSolicitud & " " & cDisposicion)
            btnAltaSolicitud.Enabled = False
            btnAltaDisposicion.Enabled = True
            btnModiSoli.Enabled = True
            btnActuaDat.Enabled = True
            btnGeneCont.Enabled = True
            MsgBox("Solicitud dada de Alta", MsgBoxStyle.Information, "Mensaje del Sistema")

        Catch eException As Exception

            MsgBox(eException.Message, MsgBoxStyle.Information, "Mensaje de error")

        End Try

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()
        cm3.Dispose()
        cm4.Dispose()

    End Sub

    Private Sub btnAltaDisposicion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAltaDisposicion.Click
        Panel2.Visible = True
        btnAltaDisposicion.Enabled = False
        btnModiSoli.Enabled = False
        btnActuaDat.Enabled = False
        btnGeneCont.Enabled = False
        txtImpdisp.Focus()
    End Sub

    Private Sub btnModiSoli_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModiSoli.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim dsAgil As New DataSet()
        Dim daCredit As New SqlDataAdapter(cm1)
        Dim drCredit As DataRow

        ' Declaración de variables de datos

        Dim cSolicitud As String

        Panel1.Visible = True
        btnAltaDisposicion.Enabled = False
        btnModiSoli.Enabled = False
        btnActuaDat.Enabled = False
        btnGeneCont.Enabled = False

        cSolicitud = Mid(ListBox1.Items(0), 1, 6)

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "ModiSoli1"
            .Connection = cnAgil
            .Parameters.Add("@Solicitud", SqlDbType.NVarChar)
            .Parameters(0).Value = cSolicitud
        End With

        daCredit.Fill(dsAgil, "Credit")

        drCredit = dsAgil.Tables("Credit").Rows(0)

        txtCusnam.Text = drCredit("Descr")
        txtStatus.Text = drCredit("DescSituacion")
        txtFesol.Text = CTOD(drCredit("Fesol"))
        txtLinso.Text = drCredit("Linso")

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim strUpdate As String

        ' Declaración de variables de datos

        Dim cSolicitud As String

        cSolicitud = Mid(ListBox1.SelectedItem, 1, 6)

        ' Actualización de la tabla Detsol

        strUpdate = "UPDATE Credit SET Linso = '" & txtLinso.Text & "' WHERE Solicitud = '" & cSolicitud & "'"
        cm1 = New SqlCommand(strUpdate, cnAgil)
        cnAgil.Open()
        cm1.ExecuteNonQuery()
        cnAgil.Close()

        Panel1.Visible = False
        btnAltaDisposicion.Enabled = True
        btnModiSoli.Enabled = True
        btnActuaDat.Enabled = True
        btnGeneCont.Enabled = True

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub btnIgnorar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIgnorar.Click
        Panel1.Visible = False
        btnAltaDisposicion.Enabled = True
        btnModiSoli.Enabled = True
        btnActuaDat.Enabled = True
        btnGeneCont.Enabled = True
    End Sub

    Private Sub btnActuaDat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActuaDat.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim daSolicitudes As New SqlDataAdapter(cm1)
        Dim daSoli2 As New SqlDataAdapter(cm2)
        Dim daAnexos As New SqlDataAdapter(cm3)
        Dim dsAgil As New DataSet()
        Dim drSolicitudes As DataRowCollection
        Dim drSolicitud As DataRow
        Dim drSoli2 As DataRow

        ' Declaración de variables de datos

        Dim cAnexo As String
        Dim cContrato As String
        Dim cDisposicion As String
        Dim cSolicitud As String
        Dim lActualizar As Boolean

        Dim newfrmActuaDat As frmActuaDat

        If ListBox1.SelectedItem = Nothing Then

            MsgBox("Selecciona una disposición para poder capturar datos", MsgBoxStyle.Information, "Mensaje")

        Else

            ' Si una disposición ya tiene generado un contrato, ya no pueden modificarse
            ' los Datos Financiamiento

            cSolicitud = Mid(ListBox1.SelectedItem, 1, 6)
            cDisposicion = Mid(ListBox1.SelectedItem, 8, 3)
            lActualizar = True

            If cDisposicion >= "001" Then

                ' Este Stored Procedure trae toda la información de una solicitud/disposición dada

                With cm1
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "GeneCont1"
                    .Connection = cnAgil
                    .Parameters.Add("@Solicitud", SqlDbType.NVarChar)
                    .Parameters(0).Value = cSolicitud
                    .Parameters.Add("@Disposicion", SqlDbType.NVarChar)
                    .Parameters(1).Value = cDisposicion
                End With

                ' Llenar el DataSet, lo cual abre y cierra la conexión

                daSolicitudes.Fill(dsAgil, "Solicitudes")

                ' Traer los datos de la solicitud/disposición

                drSolicitudes = dsAgil.Tables("Solicitudes").Rows

                cContrato = ""
                For Each drSolicitud In drSolicitudes
                    cContrato = Trim(drSolicitud("Contrato"))
                Next

                cAnexo = ""
                If Trim(cContrato) <> "" Then

                    cAnexo = cContrato & "0" & cDisposicion

                    ' El siguiente Stored Procedure trae todos los atributos de la tabla Anexos,
                    ' para un anexo dado

                    With cm3
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "DatosCon1"
                        .Connection = cnAgil
                        .Parameters.Add("@Anexo", SqlDbType.NVarChar)
                        .Parameters(0).Value = cAnexo
                    End With

                    ' Llenar el DataSet lo cual abre y cierra la conexión

                    daAnexos.Fill(dsAgil, "Anexos")

                    ' Si ya existe anexo, ya no pueden modificarse los Datos Financiamiento

                    If dsAgil.Tables("Anexos").Rows.Count() = 0 Then
                        lActualizar = True
                    Else
                        lActualizar = False
                    End If

                End If

                If lActualizar = True Then
                    newfrmActuaDat = New frmActuaDat(cSolicitud, cDisposicion)
                    newfrmActuaDat.Show()
                Else
                    MsgBox("Ya existe el contrato " & Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 6, 4) & " generado para esta disposición y no puede ser modificada", MsgBoxStyle.Critical, "Mensaje de Error")
                End If

                'ElseIf cDisposicion = "001" Then

                '    ' Obtengo información de la Solicitud a la que se le quiere agregar una disposición

                '    With cm2
                '        .CommandType = CommandType.StoredProcedure
                '        .CommandText = "ModiSoli1"
                '        .Connection = cnAgil
                '        .Parameters.Add("@Solicitud", SqlDbType.NVarChar)
                '        .Parameters(0).Value = cSolicitud
                '    End With

                '    daSoli2.Fill(dsAgil, "Soli")
                '    drSoli2 = dsAgil.Tables("Soli").Rows(0)


                '    If drSoli2("linau") <= 0 Then
                '        MsgBox("La disposición NO tiene Linea de Crédito Autorizada ", MsgBoxStyle.OkOnly, "Mensaje")
                '    Else
                '        newfrmActuaDat = New frmActuaDat(cSolicitud, cDisposicion)
                '        newfrmActuaDat.Show()
                '    End If

            End If
            cnAgil.Dispose()
            cm1.Dispose()
            cm2.Dispose()
            cm3.Dispose()

        End If
    End Sub

    Private Sub btnGeneCont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGeneCont.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim daSolicitudes As New SqlDataAdapter(cm1)
        Dim daAnexos As New SqlDataAdapter(cm3)
        Dim dsAgil As New DataSet()
        Dim drSolicitud As DataRow
        Dim strInsert As String
        Dim strUpdate As String

        ' Declaración de variables de datos

        Dim cAnexo As String
        Dim cContrato As String
        Dim cDisposicion As String
        Dim cFechacon As String
        Dim cFeven As String
        Dim cForca As String
        Dim cFrecuencia As String
        Dim cFvenc As String
        Dim cLetra As String
        Dim cSolicitud As String
        Dim cTipar As String
        Dim cValidado As String
        Dim cFondeo As String
        Dim cTipo As String
        Dim lGenerar As Boolean
        Dim nAmorin As Decimal
        Dim nCapitalEquipo As Decimal
        Dim nContrato As Decimal
        Dim nDifer As Decimal
        Dim nImpEq As Decimal
        Dim nInteresEquipo As Decimal
        Dim nIvaCapital As Decimal
        Dim nIvaEq As Decimal
        Dim nIvaIntEq As Decimal
        Dim nIvaOpcion As Decimal
        Dim nLetra As Integer
        Dim nMensu As Decimal
        Dim nOpcion As Decimal
        Dim nPlazo As Integer
        Dim nPorieq As Decimal
        Dim nPorop As Decimal
        Dim nRentaEquipo As Decimal
        Dim nSaldoEquipo As Decimal
        Dim nTasaAplicable As Decimal
        Dim nTasas As Decimal
        Dim nAbcap As Decimal
        Dim nImpDG As Decimal
        Dim nIvaDG As Decimal
        Dim nDerechos As Decimal
        Dim nIvaAmorin As Decimal
        Dim nPorcentajeIVA As Decimal = 0.16
        Dim nResidual As Decimal
        Dim nLeap As Integer
        Dim nRd As Integer
        Dim nDG As Integer
        Dim nCount As Integer
        Dim dFeven As Date

        If ListBox1.SelectedItem = Nothing Then

            MsgBox("Selecciona una disposición para poder generar su contrato", MsgBoxStyle.Information, "Mensaje")

        Else

            cSolicitud = Mid(ListBox1.SelectedItem, 1, 6)
            cDisposicion = Mid(ListBox1.SelectedItem, 8, 3)
            cContrato = Trim(Mid(ListBox1.SelectedItem, 12, 5))

            ' Este Stored Procedure trae toda la información de una solicitud/disposición dada

            With cm1
                .CommandType = CommandType.StoredProcedure
                .CommandText = "GeneCont1"
                .Connection = cnAgil
                .Parameters.Add("@Solicitud", SqlDbType.NVarChar)
                .Parameters(0).Value = cSolicitud
                .Parameters.Add("@Disposicion", SqlDbType.NVarChar)
                .Parameters(1).Value = cDisposicion
            End With

            ' Llenar el DataSet, lo cual abre y cierra la conexión

            daSolicitudes.Fill(dsAgil, "Solicitudes")

            ' Traer los datos de la solicitud/disposición (teóricamente regresa un solo registro)

            drSolicitud = dsAgil.Tables("Solicitudes").Rows(0)

            cContrato = Trim(drSolicitud("Contrato"))
            nImpEq = drSolicitud("ImpEq")
            nIvaEq = drSolicitud("IvaEq")
            nAmorin = drSolicitud("Amorin")
            cForca = drSolicitud("Forca")
            cFvenc = drSolicitud("Fvenc")
            cTipar = drSolicitud("Tipar")
            cFondeo = drSolicitud("Fondeo")
            cTipo = drSolicitud("Tipo")
            nPlazo = drSolicitud("Plazo")
            cFechacon = drSolicitud("Fechacon")
            nPorieq = drSolicitud("Porieq")
            cFrecuencia = drSolicitud("Tippe")
            nTasas = drSolicitud("Tasas")
            nDifer = drSolicitud("Difer")
            nPorop = drSolicitud("Porop")
            cValidado = drSolicitud("Validado")
            nRd = drSolicitud("Rd")
            nImpDG = drSolicitud("ImpDG")
            nIvaDG = drSolicitud("IvaDG")
            nDG = drSolicitud("DG")
            nDerechos = drSolicitud("Derechos")
            nIvaAmorin = drSolicitud("IvaAmorin")
            nSaldoEquipo = Round(nImpEq - nIvaEq - nAmorin, 2)
            nTasaAplicable = (nTasas + nDifer) / 1200

            If cTipar = "P" Then
                nResidual = Round(nImpEq * nPorop / 100, 2) / (1 + nPorcentajeIVA)
            Else
                nOpcion = Round(nImpEq * nPorop / 100, 2)
            End If

            If nSaldoEquipo > 0 Then
                If cTipar = "F" Or cTipar = "R" Or cTipar = "S" Then
                    nMensu = Round(Pmt(nTasaAplicable, nPlazo, -nSaldoEquipo, 0), 2)
                ElseIf cTipar = "P" Then
                    nMensu = Round(Pmt(nTasaAplicable, nPlazo, -nSaldoEquipo, nResidual), 2)
                End If
            Else
                nMensu = 0
            End If

            ' Lo primero que tengo que checar es que la disposición haya sido validada
            ' con la opción Calcular Datos de la forma frmActuaDat

            If cValidado = "N" Then

                MsgBox("La disposición NO ha sido validada. Ingresa a Datos Financiamiento y completa la información", MsgBoxStyle.Critical, "Mensaje de Error")

            Else

                If Trim(cContrato) = "" Then

                    ' La solicitud NO tiene generado contrato por lo que debo traer el número
                    ' consecutivo de contrato que le corresponde, lo cual se logra con el
                    ' siguiente comando

                    With cm2
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT IDContrato FROM Llaves"
                        .Connection = cnAgil
                    End With

                    cnAgil.Open()

                    nContrato = CInt(cm2.ExecuteScalar()) + 1

                    cAnexo = Stuff(nContrato.ToString, "I", "0", 5) & "0" & cDisposicion
                    cContrato = Stuff(nContrato.ToString, "I", "0", 5)

                    ' Actualización de la tabla Credit

                    strUpdate = "UPDATE Credit SET Contrato = '" & cContrato & "' WHERE Solicitud = '" & cSolicitud & "'"
                    cm2 = New SqlCommand(strUpdate, cnAgil)
                    cm2.ExecuteNonQuery()

                    ' Actualización de la tabla Llaves

                    strUpdate = "UPDATE Llaves SET IDContrato = " & nContrato
                    cm2 = New SqlCommand(strUpdate, cnAgil)
                    cm2.ExecuteNonQuery()

                    cnAgil.Close()

                    lGenerar = True

                Else

                    ' La solicitud ya tiene un número de contrato asignado por lo que al generar
                    ' su anexo debo verificar que éste no exista en la tabla Anexos

                    cAnexo = cContrato & "0" & cDisposicion

                    ' El siguiente Stored Procedure trae todos los atributos de la tabla Anexos,
                    ' para un anexo dado

                    With cm3
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "DatosCon1"
                        .Connection = cnAgil
                        .Parameters.Add("@Anexo", SqlDbType.NVarChar)
                        .Parameters(0).Value = cAnexo
                    End With

                    ' Llenar el DataSet lo cual abre y cierra la conexión

                    daAnexos.Fill(dsAgil, "Anexos")

                    ' Si no existe el anexo, lGenerar es verdadero

                    If dsAgil.Tables("Anexos").Rows.Count() = 0 Then
                        lGenerar = True
                    Else
                        lGenerar = False
                    End If

                End If

                If lGenerar = True Then

                    Try

                        cnAgil.Open()

                        ' Actualización de la tabla Anexos

                        strInsert = "INSERT INTO Anexos(Anexo, Flcan, Cliente, ImpEq, Plazo, IvaEq, Porieq, Amorin, IvaAmorin, Tippe, Tipta, Tasas, Difer, Tipar, Forca, RtasD, ImpRD, IvaRD, Porco, Comis, Porop, Fechacon, Fvenc, Fondeo, DepNafin, Critas, Tipeq, Gastos, IvaGastos, Mensu, RD, ImpDG, IvaDG,Derechos, Prenda,DG)"
                        strInsert = strInsert & " VALUES ('"
                        strInsert = strInsert & cAnexo & "', '"
                        strInsert = strInsert & "S" & "', '"
                        strInsert = strInsert & drSolicitud("Cliente") & "', '"
                        strInsert = strInsert & nImpEq & "', '"
                        strInsert = strInsert & nPlazo & "', '"
                        strInsert = strInsert & nIvaEq & "', '"
                        strInsert = strInsert & nPorieq & "', '"
                        strInsert = strInsert & nAmorin & "', '"
                        strInsert = strInsert & nIvaAmorin & "', '"
                        strInsert = strInsert & cFrecuencia & "', '"
                        strInsert = strInsert & drSolicitud("Tipta") & "', '"
                        strInsert = strInsert & drSolicitud("Tasas") & "', '"
                        strInsert = strInsert & drSolicitud("Difer") & "', '"
                        strInsert = strInsert & cTipar & "', '"
                        strInsert = strInsert & cForca & "', '"
                        strInsert = strInsert & drSolicitud("RtasD") & "', '"
                        strInsert = strInsert & drSolicitud("ImpRD") & "', '"
                        strInsert = strInsert & drSolicitud("IvaRD") & "', '"
                        strInsert = strInsert & drSolicitud("Porco") & "', '"
                        strInsert = strInsert & drSolicitud("Comis") & "', '"
                        strInsert = strInsert & nPorop & "', '"
                        strInsert = strInsert & cFechacon & "', '"
                        strInsert = strInsert & cFvenc & "', '"
                        strInsert = strInsert & drSolicitud("Fondeo") & "', '"
                        strInsert = strInsert & drSolicitud("DepNafin") & "', '"
                        strInsert = strInsert & drSolicitud("Critas") & "', '"
                        strInsert = strInsert & drSolicitud("Tipeq") & "', '"
                        strInsert = strInsert & drSolicitud("Gastos") & "', '"
                        strInsert = strInsert & drSolicitud("IvaGastos") & "', '"
                        strInsert = strInsert & nMensu & "', '"
                        strInsert = strInsert & nRd & "', '"
                        strInsert = strInsert & nImpDG & "', '"
                        strInsert = strInsert & nIvaDG & "', '"
                        strInsert = strInsert & nDerechos & "', '"
                        strInsert = strInsert & drSolicitud("Prenda") & "', '"
                        strInsert = strInsert & drSolicitud("DG")
                        strInsert = strInsert & "')"
                        cm1 = New SqlCommand(strInsert, cnAgil)
                        cm1.ExecuteNonQuery()

                        ' Actualización de la tabla Opciones

                        If cTipar = "F" Or cTipar = "R" Then
                            nOpcion = Round(nImpEq * nPorop / 100 / (1 + nPorcentajeIVA), 2)
                            nIvaOpcion = Round(nOpcion * nPorcentajeIVA, 2)
                        Else
                            nOpcion = 0
                            nIvaOpcion = 0
                        End If

                        strInsert = "INSERT INTO Opciones(Anexo, Opcion, IvaOpcion, Porcentaje, Exigible, Pagado)"
                        strInsert = strInsert & " VALUES ('"
                        strInsert = strInsert & cAnexo & "', "
                        strInsert = strInsert & nOpcion & ", "
                        strInsert = strInsert & nIvaOpcion & ", "
                        strInsert = strInsert & nPorcentajeIVA & ", '"
                        strInsert = strInsert & "N" & "', '"
                        strInsert = strInsert & "N"
                        strInsert = strInsert & "')"
                        cm1 = New SqlCommand(strInsert, cnAgil)
                        cm1.ExecuteNonQuery()

                        ' Determina el saldo insoluto del equipo

                        nSaldoEquipo = Round(nImpEq - nIvaEq - nAmorin, 2)

                        ' Toma la renta del equipo de la tabla DetSol

                        If cForca = "1" Or cForca = "4" Then
                            nRentaEquipo = Round(nMensu, 2)
                        ElseIf cForca = "2" Then
                            If cTipar = "F" Or cTipar = "R" Then
                                nAbcap = Round((nSaldoEquipo) / nPlazo, 2)
                            End If
                        End If

                        cFeven = cFvenc
                        nTasaAplicable = (nTasas + nDifer) / 1200
                        nCount = nPlazo - nRd

                        For nLetra = 1 To nPlazo

                            nInteresEquipo = Round(nSaldoEquipo * nTasaAplicable, 2)

                            If cForca = "1" Or cForca = "4" Then
                                nCapitalEquipo = nRentaEquipo - nInteresEquipo
                            ElseIf cForca = "2" Then
                                nCapitalEquipo = nAbcap
                            End If

                            If nLetra = nPlazo Then
                                nCapitalEquipo = nSaldoEquipo
                                nInteresEquipo = Round(nSaldoEquipo * nTasaAplicable, 2)
                            End If

                            If cTipar = "R" Or cTipar = "S" Then
                                If cTipo = "M" Or cTipo = "E" Then
                                    nIvaIntEq = 0
                                Else
                                    nIvaIntEq = Round(nInteresEquipo * nPorcentajeIVA, 2)
                                End If
                            ElseIf cTipar = "P" Then
                                nIvaIntEq = Round((nCapitalEquipo + nInteresEquipo) * nPorcentajeIVA, 2)
                            Else
                                nIvaIntEq = Round(nInteresEquipo * nPorcentajeIVA, 2)
                            End If

                            cLetra = GeneraLetra(nLetra, cFeven, cFondeo)

                            If cFondeo = "03" Or cFondeo = "04" Then
                                Select Case Mid(cFeven, 5, 2)
                                    Case "01", "03", "05", "07", "08", "10", "12"
                                        cFeven = Mid(cFeven, 1, 4) & Mid(cFeven, 5, 2) & "31"
                                    Case "02"
                                        nLeap = Leap(Year(CTOD(cFeven)))
                                        If nLeap = 1 Then
                                            cFeven = Mid(cFeven, 1, 4) & Mid(cFeven, 5, 2) & "29"
                                        Else
                                            cFeven = Mid(cFeven, 1, 4) & Mid(cFeven, 5, 2) & "28"
                                        End If
                                    Case "04", "06", "09", "11"
                                        cFeven = Mid(cFeven, 1, 4) & Mid(cFeven, 5, 2) & "30"
                                End Select
                                dFeven = CTOD(cFeven)
                                dFeven = DayWeek(dFeven)
                                cFeven = DTOC(dFeven)
                            End If

                            If cTipar = "R" Or cTipar = "P" Or cTipar = "S" Then
                                nIvaCapital = 0
                            Else
                                If cFechacon >= "20020301" And nPorieq > 0 Then
                                    nIvaCapital = Round(nCapitalEquipo * nPorieq / 100, 2)
                                Else
                                    nIvaCapital = 0
                                End If
                            End If

                            If nLetra = nPlazo And cTipar = "P" Then
                                nSaldoEquipo = nSaldoEquipo + nResidual
                                nCapitalEquipo = (nRentaEquipo - nInteresEquipo) + nResidual
                                nIvaIntEq = Round(nRentaEquipo * nPorcentajeIVA, 2) + Round(nResidual * nPorcentajeIVA, 2)
                            End If

                            ' Actualización de la tabla Edoctav

                            strInsert = "INSERT INTO Edoctav(Anexo, Letra, Feven, Nufac, IndRec, Saldo, Abcap, Inter, Iva, IvaCapital )"
                            strInsert = strInsert & " VALUES ('"
                            strInsert = strInsert & cAnexo & "', '"
                            strInsert = strInsert & cLetra & "', '"
                            strInsert = strInsert & cFeven & "', '"
                            strInsert = strInsert & 0 & "', '"
                            strInsert = strInsert & "S" & "', '"
                            strInsert = strInsert & nSaldoEquipo & "', '"
                            strInsert = strInsert & nCapitalEquipo & "', '"
                            strInsert = strInsert & nInteresEquipo & "', '"
                            strInsert = strInsert & nIvaIntEq & "', '"
                            strInsert = strInsert & nIvaCapital
                            strInsert = strInsert & "')"
                            cm1 = New SqlCommand(strInsert, cnAgil)
                            cm1.ExecuteNonQuery()

                            ' Si nRD > 0 quiere decir que hay rentas en depósito por lo que hay que guardar
                            ' información en la Base de Rentas en Depósito

                            If nLetra = nPlazo And cTipar = "P" Then
                                nSaldoEquipo = nSaldoEquipo - nResidual
                                nCapitalEquipo = nCapitalEquipo - nResidual
                                nIvaIntEq = nIvaIntEq - Round(nResidual * nPorcentajeIVA, 2)
                            End If

                            If nRd > 0 And nLetra > nCount Then
                                strInsert = "INSERT INTO Rentasdep(Anexo, Letra, Feven, Nufac, IndRec, Saldo, Abcap, Inter, Iva, IvaCapital, Aplicada )"
                                strInsert = strInsert & " VALUES ('"
                                strInsert = strInsert & cAnexo & "', '"
                                strInsert = strInsert & cLetra & "', '"
                                strInsert = strInsert & cFeven & "', '"
                                strInsert = strInsert & 0 & "', '"
                                strInsert = strInsert & "S" & "', '"
                                strInsert = strInsert & nSaldoEquipo & "', '"
                                strInsert = strInsert & nCapitalEquipo & "', '"
                                strInsert = strInsert & nInteresEquipo & "', '"
                                strInsert = strInsert & nIvaIntEq & "', '"
                                strInsert = strInsert & nIvaCapital & "', '"
                                strInsert = strInsert & "N"
                                strInsert = strInsert & "')"
                                cm1 = New SqlCommand(strInsert, cnAgil)
                                cm1.ExecuteNonQuery()
                            End If

                            nSaldoEquipo -= nCapitalEquipo

                        Next

                        cnAgil.Close()

                        MsgBox("Se generó el contrato " & Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 6, 4) & " para esta disposición", MsgBoxStyle.Information, "Mensaje del Sistema")

                    Catch eException As Exception

                        MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")

                    End Try

                Else

                    MsgBox("Ya existe el contrato " & Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 6, 4) & " generado para esta disposición", MsgBoxStyle.Critical, "Mensaje de Error")

                End If

            End If

        End If

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()
        cm3.Dispose()

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnAplicar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAplicar.Click

        Dim cnAgil As New SqlConnection(strConn)
        Dim dsAgil As New DataSet()
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim daSolicitud As New SqlDataAdapter(cm2)
        Dim daSdoInsoluto As New SqlDataAdapter(cm3)
        Dim drSoli As DataRow
        Dim drSaldo As DataRow
        Dim strInsert As String

        ' Declaración de variables de datos

        Dim cDisposicion As String
        Dim cSolicitud As String
        Dim cCliente As String
        Dim cDictamen As String
        Dim cFechavig As String
        Dim cFechahoy As String
        Dim cAnexo As String
        Dim nDisposicion As Integer
        Dim nLineaaut As Decimal
        Dim nSaldoins As Decimal

        cSolicitud = Mid(ListBox1.Items(0), 1, 6)

        ' Obtengo información de la Solicitud a la que se le quiere agregar una disposición

        With cm2
            .CommandType = CommandType.StoredProcedure
            .CommandText = "ModiSoli1"
            .Connection = cnAgil
            .Parameters.Add("@Solicitud", SqlDbType.NVarChar)
            .Parameters(0).Value = cSolicitud
        End With

        daSolicitud.Fill(dsAgil, "Soli")
        drSoli = dsAgil.Tables("Soli").Rows(0)

        cCliente = drSoli("Cliente")

        If drSoli("Dicta") <> "A" Then
            cDictamen = IIf(drSoli("Dicta") = "R", "RECHAZADO", "PENDIENTE")
        End If

        cFechavig = drSoli("Fevig")
        cFechahoy = DTOC(Today)
        nLineaaut = drSoli("linau")

        ' Obtengo todos los contratos asociados al Cliente sin importar su estatus

        With cm3
            .CommandType = CommandType.StoredProcedure
            .CommandText = "PideAnex2"
            .Connection = cnAgil
            .Parameters.Add("@Cliente", SqlDbType.NVarChar)
            .Parameters(0).Value = cCliente
        End With

        daSdoInsoluto.Fill(dsAgil, "Saldo")

        For Each drSaldo In dsAgil.Tables("Saldo").Rows
            cAnexo = drSaldo("Anexo")
            If drSaldo("Flcan") = "A" Then
                nSaldoins = SaldoAcumulado(cAnexo, cFechahoy) + nSaldoins
            End If
        Next

        If drSoli("Dicta") <> "A" Then

            MsgBox("El Dictamen de la Solicitud esta " & cDictamen, MsgBoxStyle.OkOnly, "Mensaje")

            Panel2.Visible = False
            btnAltaDisposicion.Enabled = True
            btnModiSoli.Enabled = True
            btnActuaDat.Enabled = True
            btnGeneCont.Enabled = True

        ElseIf cFechavig < cFechahoy Then

            MsgBox("La Vigencia de la Solicitud esta Caducada", MsgBoxStyle.OkOnly, "Mensaje")

            Panel2.Visible = False
            btnAltaDisposicion.Enabled = True
            btnModiSoli.Enabled = True
            btnActuaDat.Enabled = True
            btnGeneCont.Enabled = True

        ElseIf (nLineaaut - nSaldoins) < Val(txtImpdisp.Text) Then

            MsgBox("Línea de Crédito Insuficiente, actualmente dispone de " & FormatNumber(nLineaaut - nSaldoins).ToString, MsgBoxStyle.OkOnly, "Mensaje")

            Panel2.Visible = False
            btnAltaDisposicion.Enabled = True
            btnModiSoli.Enabled = True
            btnActuaDat.Enabled = True
            btnGeneCont.Enabled = True

        ElseIf MsgBox("Estás seguro de querer una nueva disposición", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Mensaje") = MsgBoxResult.Yes Then
            Panel2.Visible = False

            nDisposicion = ListBox1.Items.Count + 1
            cDisposicion = Stuff(nDisposicion.ToString, "I", "0", 3)

            strInsert = "INSERT INTO DetSol(Solicitud, Disposicion, Cliente)"
            strInsert = strInsert & " VALUES ('"
            strInsert = strInsert & cSolicitud & "', '"
            strInsert = strInsert & cDisposicion & "', '"
            strInsert = strInsert & txtCliente.Text
            strInsert = strInsert & "')"

            Try
                cm1 = New SqlCommand(strInsert, cnAgil)
                cnAgil.Open()
                cm1.ExecuteNonQuery()
                cnAgil.Close()
                ListBox1.Items.Add(cSolicitud & " " & cDisposicion)
            Catch eException As Exception
                MsgBox(eException.Message, MsgBoxStyle.Information, "Mensaje de error")
            End Try

        End If
        Panel2.Visible = False

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()
        cm3.Dispose()

    End Sub
End Class
