Option Explicit On 

Imports System.Data.SqlClient

Public Class frmCaptsegu

    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal cAnexo As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        txtAnexo.Text = cAnexo
        Me.Text = "Captura de Pólizas de Seguros"
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
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents txtAnexo As System.Windows.Forms.TextBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtPoliza As System.Windows.Forms.TextBox
    Friend WithEvents txtPrima As System.Windows.Forms.TextBox
    Friend WithEvents txtAseg As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnModif As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents txtfactura As System.Windows.Forms.TextBox
    Friend WithEvents cbTipoPoliz As System.Windows.Forms.ComboBox
    Friend WithEvents gbBeneficiario As System.Windows.Forms.GroupBox
    Friend WithEvents rbPagNo As System.Windows.Forms.RadioButton
    Friend WithEvents rbPagSi As System.Windows.Forms.RadioButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents rbBPFNo As System.Windows.Forms.RadioButton
    Friend WithEvents rbBPFSi As System.Windows.Forms.RadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbCobertura As System.Windows.Forms.ComboBox
    Friend WithEvents gbBPreferente As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCusnam As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cbCobertura = New System.Windows.Forms.ComboBox
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.txtAnexo = New System.Windows.Forms.TextBox
        Me.txtPoliza = New System.Windows.Forms.TextBox
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.txtPrima = New System.Windows.Forms.TextBox
        Me.txtAseg = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnModif = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.txtfactura = New System.Windows.Forms.TextBox
        Me.txtCusnam = New System.Windows.Forms.TextBox
        Me.cbTipoPoliz = New System.Windows.Forms.ComboBox
        Me.gbBeneficiario = New System.Windows.Forms.GroupBox
        Me.rbPagNo = New System.Windows.Forms.RadioButton
        Me.rbPagSi = New System.Windows.Forms.RadioButton
        Me.Label6 = New System.Windows.Forms.Label
        Me.gbBPreferente = New System.Windows.Forms.GroupBox
        Me.rbBPFNo = New System.Windows.Forms.RadioButton
        Me.rbBPFSi = New System.Windows.Forms.RadioButton
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbBeneficiario.SuspendLayout()
        Me.gbBPreferente.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbCobertura
        '
        Me.cbCobertura.Enabled = False
        Me.cbCobertura.FormattingEnabled = True
        Me.cbCobertura.Location = New System.Drawing.Point(127, 346)
        Me.cbCobertura.Name = "cbCobertura"
        Me.cbCobertura.Size = New System.Drawing.Size(121, 21)
        Me.cbCobertura.TabIndex = 36
        Me.cbCobertura.Visible = False
        '
        'DataGrid1
        '
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(16, 24)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.Size = New System.Drawing.Size(632, 184)
        Me.DataGrid1.TabIndex = 0
        '
        'txtAnexo
        '
        Me.txtAnexo.Location = New System.Drawing.Point(24, 0)
        Me.txtAnexo.Name = "txtAnexo"
        Me.txtAnexo.Size = New System.Drawing.Size(8, 20)
        Me.txtAnexo.TabIndex = 1
        Me.txtAnexo.Text = "TextBox1"
        Me.txtAnexo.Visible = False
        '
        'txtPoliza
        '
        Me.txtPoliza.Location = New System.Drawing.Point(128, 224)
        Me.txtPoliza.Name = "txtPoliza"
        Me.txtPoliza.ReadOnly = True
        Me.txtPoliza.Size = New System.Drawing.Size(120, 20)
        Me.txtPoliza.TabIndex = 2
        Me.txtPoliza.Visible = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Enabled = False
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(128, 248)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(88, 20)
        Me.DateTimePicker1.TabIndex = 22
        Me.DateTimePicker1.Visible = False
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Enabled = False
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(128, 272)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(88, 20)
        Me.DateTimePicker2.TabIndex = 23
        Me.DateTimePicker2.Visible = False
        '
        'txtPrima
        '
        Me.txtPrima.Location = New System.Drawing.Point(128, 320)
        Me.txtPrima.Name = "txtPrima"
        Me.txtPrima.ReadOnly = True
        Me.txtPrima.Size = New System.Drawing.Size(120, 20)
        Me.txtPrima.TabIndex = 24
        Me.txtPrima.Visible = False
        '
        'txtAseg
        '
        Me.txtAseg.Location = New System.Drawing.Point(128, 296)
        Me.txtAseg.Name = "txtAseg"
        Me.txtAseg.ReadOnly = True
        Me.txtAseg.Size = New System.Drawing.Size(120, 20)
        Me.txtAseg.TabIndex = 25
        Me.txtAseg.Visible = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 224)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "No. de Póliza"
        Me.Label1.Visible = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 248)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 16)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Inicio de la Vigencia"
        Me.Label2.Visible = False
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 272)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 16)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Final de la Vigencia"
        Me.Label3.Visible = False
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 296)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 16)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "Aseguradora"
        Me.Label4.Visible = False
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(16, 320)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 16)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Prima"
        Me.Label5.Visible = False
        '
        'btnModif
        '
        Me.btnModif.Enabled = False
        Me.btnModif.Location = New System.Drawing.Point(388, 456)
        Me.btnModif.Name = "btnModif"
        Me.btnModif.Size = New System.Drawing.Size(80, 24)
        Me.btnModif.TabIndex = 31
        Me.btnModif.Text = "Modificar"
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(485, 456)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(72, 24)
        Me.btnSave.TabIndex = 32
        Me.btnSave.Text = "Salvar"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(571, 456)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(72, 24)
        Me.btnExit.TabIndex = 33
        Me.btnExit.Text = "Regresar"
        '
        'txtfactura
        '
        Me.txtfactura.Location = New System.Drawing.Point(48, 0)
        Me.txtfactura.Name = "txtfactura"
        Me.txtfactura.Size = New System.Drawing.Size(8, 20)
        Me.txtfactura.TabIndex = 34
        Me.txtfactura.Text = "TextBox1"
        Me.txtfactura.Visible = False
        '
        'txtCusnam
        '
        Me.txtCusnam.Location = New System.Drawing.Point(72, 0)
        Me.txtCusnam.Name = "txtCusnam"
        Me.txtCusnam.Size = New System.Drawing.Size(8, 20)
        Me.txtCusnam.TabIndex = 35
        Me.txtCusnam.Text = "TextBox1"
        Me.txtCusnam.Visible = False
        '
        'cbTipoPoliz
        '
        Me.cbTipoPoliz.Enabled = False
        Me.cbTipoPoliz.FormattingEnabled = True
        Me.cbTipoPoliz.Location = New System.Drawing.Point(128, 373)
        Me.cbTipoPoliz.Name = "cbTipoPoliz"
        Me.cbTipoPoliz.Size = New System.Drawing.Size(121, 21)
        Me.cbTipoPoliz.TabIndex = 37
        Me.cbTipoPoliz.Visible = False
        '
        'gbBeneficiario
        '
        Me.gbBeneficiario.Controls.Add(Me.rbPagNo)
        Me.gbBeneficiario.Controls.Add(Me.rbPagSi)
        Me.gbBeneficiario.Controls.Add(Me.Label6)
        Me.gbBeneficiario.Enabled = False
        Me.gbBeneficiario.Location = New System.Drawing.Point(12, 402)
        Me.gbBeneficiario.Name = "gbBeneficiario"
        Me.gbBeneficiario.Size = New System.Drawing.Size(246, 38)
        Me.gbBeneficiario.TabIndex = 38
        Me.gbBeneficiario.TabStop = False
        Me.gbBeneficiario.Visible = False
        '
        'rbPagNo
        '
        Me.rbPagNo.AutoSize = True
        Me.rbPagNo.Location = New System.Drawing.Point(192, 15)
        Me.rbPagNo.Name = "rbPagNo"
        Me.rbPagNo.Size = New System.Drawing.Size(41, 17)
        Me.rbPagNo.TabIndex = 2
        Me.rbPagNo.TabStop = True
        Me.rbPagNo.Text = "NO"
        Me.rbPagNo.UseVisualStyleBackColor = True
        '
        'rbPagSi
        '
        Me.rbPagSi.AutoSize = True
        Me.rbPagSi.Location = New System.Drawing.Point(141, 15)
        Me.rbPagSi.Name = "rbPagSi"
        Me.rbPagSi.Size = New System.Drawing.Size(35, 17)
        Me.rbPagSi.TabIndex = 1
        Me.rbPagSi.TabStop = True
        Me.rbPagSi.Text = "SI"
        Me.rbPagSi.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(113, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "La Poliza esta Pagada"
        '
        'gbBPreferente
        '
        Me.gbBPreferente.Controls.Add(Me.rbBPFNo)
        Me.gbBPreferente.Controls.Add(Me.rbBPFSi)
        Me.gbBPreferente.Controls.Add(Me.Label7)
        Me.gbBPreferente.Enabled = False
        Me.gbBPreferente.Location = New System.Drawing.Point(12, 447)
        Me.gbBPreferente.Name = "gbBPreferente"
        Me.gbBPreferente.Size = New System.Drawing.Size(349, 38)
        Me.gbBPreferente.TabIndex = 39
        Me.gbBPreferente.TabStop = False
        Me.gbBPreferente.Visible = False
        '
        'rbBPFNo
        '
        Me.rbBPFNo.AutoSize = True
        Me.rbBPFNo.Location = New System.Drawing.Point(300, 15)
        Me.rbBPFNo.Name = "rbBPFNo"
        Me.rbBPFNo.Size = New System.Drawing.Size(41, 17)
        Me.rbBPFNo.TabIndex = 2
        Me.rbBPFNo.TabStop = True
        Me.rbBPFNo.Text = "NO"
        Me.rbBPFNo.UseVisualStyleBackColor = True
        '
        'rbBPFSi
        '
        Me.rbBPFSi.AutoSize = True
        Me.rbBPFSi.Location = New System.Drawing.Point(249, 15)
        Me.rbBPFSi.Name = "rbBPFSi"
        Me.rbBPFSi.Size = New System.Drawing.Size(35, 17)
        Me.rbBPFSi.TabIndex = 1
        Me.rbBPFSi.TabStop = True
        Me.rbBPFSi.Text = "SI"
        Me.rbBPFSi.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(5, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(226, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Tiene como Beneficiario Preferente a FINAGIL"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(17, 351)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 16)
        Me.Label8.TabIndex = 40
        Me.Label8.Text = "Cobertura"
        Me.Label8.Visible = False
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(17, 378)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 16)
        Me.Label9.TabIndex = 41
        Me.Label9.Text = "Tipo de Poliza"
        Me.Label9.Visible = False
        '
        'frmCaptsegu
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(664, 502)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.gbBPreferente)
        Me.Controls.Add(Me.gbBeneficiario)
        Me.Controls.Add(Me.cbTipoPoliz)
        Me.Controls.Add(Me.cbCobertura)
        Me.Controls.Add(Me.txtCusnam)
        Me.Controls.Add(Me.txtfactura)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnModif)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtAseg)
        Me.Controls.Add(Me.txtPrima)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.txtPoliza)
        Me.Controls.Add(Me.txtAnexo)
        Me.Controls.Add(Me.DataGrid1)
        Me.Name = "frmCaptsegu"
        Me.Text = "Captura de Datos del Seguro"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbBeneficiario.ResumeLayout(False)
        Me.gbBeneficiario.PerformLayout()
        Me.gbBPreferente.ResumeLayout(False)
        Me.gbBPreferente.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub frmCaptSegu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim dsAgil As New DataSet()
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim daAnexos As New SqlDataAdapter(cm1)
        Dim daEdoctav As New SqlDataAdapter(cm2)
        Dim daEdoctas As New SqlDataAdapter(cm3)
        Dim drEdoctav As DataRow()
        Dim drAnexo As DataRow
        Dim drDato As DataRow
        Dim drDatos As DataRowCollection
        Dim relAnexoEdoctav As DataRelation
        Dim dtCargopol As New DataTable("Seguro")

        'Declaración de variables de datos

        Dim cAnexo As String
        Dim cFecha As String
        Dim cFeven As String
        Dim lBienesFac As Boolean
        Dim nVencimiento As Int32
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
            .CommandType = CommandType.Text
            .CommandText = "SELECT Edoctav.* FROM Edoctav WHERE Anexo = " & "'" & cAnexo & "'"
            .Connection = cnAgil
        End With

        ' Con este Stored Procedure obtengo los datos de los bienes en un contrato dado

        With cm3
            .CommandType = CommandType.StoredProcedure
            .CommandText = "ActiFijo4"
            .Connection = cnAgil
            .Parameters.Add("@Anexo", SqlDbType.NVarChar)
            .Parameters(0).Value = cAnexo
        End With

        ' Llenar el DataSet lo cual abre y cierra la conexión

        daAnexos.Fill(dsAgil, "Anexos")
        daEdoctav.Fill(dsAgil, "Edoctav")
        daEdoctas.Fill(dsAgil, "ActiFijo")

        ' Establecer la relación entre Anexos y Edoctav

        relAnexoEdoctav = New DataRelation("AnexoEdoctav", dsAgil.Tables("Anexos").Columns("Anexo"), dsAgil.Tables("Edoctav").Columns("Anexo"))
        dsAgil.EnforceConstraints = False
        dsAgil.Relations.Add(relAnexoEdoctav)

        ' Validando que el Contrato este Activo

        drAnexo = dsAgil.Tables("Anexos").Rows(0)

        txtCusnam.Text = drAnexo("Descr")
        nPlazo = drAnexo("Plazo")
        nTasaApli = (drAnexo("Tasas") + drAnexo("Difer")) / 1200

        If drAnexo("Flcan") <> "A" Then
            MsgBox("Contrato NO activo", MsgBoxStyle.OkOnly, "Mensaje")
            Me.Close()
        End If

        If drAnexo("Flcan") = "A" Then

            ' Validando que el Contrato tenga saldo insoluto (que tenga por lo menos un mes
            ' por transcurrir)

            drEdoctav = drAnexo.GetChildRows("AnexoEdoctav")

            nIntEquipo = 0
            nCarEquipo = 0
            nSaldoEquipo = 0

            TraeSald(drEdoctav, cFecha, nSaldoEquipo, nIntEquipo, nCarEquipo)

            If nSaldoEquipo = 0 Then
                MsgBox("Contrato SIN saldo insoluto", MsgBoxStyle.OkOnly, "Mensaje")
                Me.Close()
            End If
        End If

        If drAnexo("Flcan") = "A" And nSaldoEquipo > 0 Then

            ' Por último validamos que no esten Facturados todos los bienes del contrato y
            ' lleno la Tabla Temporal para captura de las polizas

            dtCargopol.Columns.Add("Serie", Type.GetType("System.String"))
            dtCargopol.Columns.Add("Motor", Type.GetType("System.String"))
            dtCargopol.Columns.Add("Modelo", Type.GetType("System.String"))
            dtCargopol.Columns.Add("Poliza", Type.GetType("System.String"))
            dtCargopol.Columns.Add("Inicio", Type.GetType("System.String"))
            dtCargopol.Columns.Add("Final", Type.GetType("System.String"))
            dtCargopol.Columns.Add("Aseguradora", Type.GetType("System.String"))
            dtCargopol.Columns.Add("Prima", Type.GetType("System.Decimal"))
            dtCargopol.Columns.Add("Factura", Type.GetType("System.String"))
            dtCargopol.Columns.Add("Cobertura", Type.GetType("System.String"))
            dtCargopol.Columns.Add("Tipo Pol.", Type.GetType("System.String"))
            dtCargopol.Columns.Add("P.Pagada", Type.GetType("System.String"))
            dtCargopol.Columns.Add("B.P.F.", Type.GetType("System.String"))


            lBienesFac = False

            drDatos = dsAgil.Tables("ActiFijo").Rows

            For Each drDato In drDatos
                drAnexo = dtCargopol.NewRow()
                drAnexo("Serie") = drDato("Serie")
                drAnexo("Motor") = drDato("Motor")
                drAnexo("Modelo") = drDato("Modelo")
                drAnexo("Poliza") = drDato("NumPoliz")
                drAnexo("Inicio") = CTOD(drDato("Inicioseg")).ToShortDateString
                drAnexo("Final") = CTOD(drDato("Vigencseg")).ToShortDateString
                drAnexo("Aseguradora") = drDato("Asegurador")
                drAnexo("Prima") = drDato("Prima")
                drAnexo("Factura") = drDato("Factura")
                If drDato("Cobertura") = "A" Then
                    drAnexo("Cobertura") = "AMPLIA"
                ElseIf drDato("Cobertura") = "L" Then
                    drAnexo("Cobertura") = "LIMITADA"
                Else
                    drAnexo("Cobertura") = " "
                End If
                If drDato("TipoPol") = "E" Then
                    drAnexo("Tipo Pol.") = "EXTERNA"
                ElseIf drDato("TipoPol") = "F" Then
                    drAnexo("Tipo Pol.") = "FINAGIL"
                ElseIf drDato("TipoPol") = "M" Then
                    drAnexo("Tipo Pol.") = "SEG. MUTUALISTA"
                Else
                    drAnexo("Tipo Pol.") = " "
                End If
                If drDato("PolPago") = "S" Then
                    drAnexo("P.Pagada") = "SI"
                ElseIf drDato("PolPago") = "N" Then
                    drAnexo("P.Pagada") = "NO"
                End If
                If drDato("PolPago") = "S" Then
                    drAnexo("B.P.F.") = "SI"
                ElseIf drDato("PolPago") = "N" Then
                    drAnexo("B.P.F.") = "NO"
                End If
                dtCargopol.Rows.Add(drAnexo)
                If drDato("FactFij") = 0 Then
                    lBienesFac = True
                End If
            Next

            If lBienesFac = False Then
                MsgBox("Todos los bienes de este contrato están Facturados", MsgBoxStyle.Exclamation.OkOnly, "Mensaje")
                Me.Close()
            Else

                ' Identificamos a partir de que vencimiento se comenzará a cargar el seguro

                For Each drDato In drEdoctav
                    If drDato("Nufac") = 0 And drDato("Indrec") = "S" And nVencimiento = 0 Then
                        nVencimiento = Val(drDato("Letra"))
                        cFeven = drDato("Feven")
                    End If
                Next

            End If
        End If
        dsAgil.Relations.Clear()
        dsAgil.Tables("Anexos").Constraints.Clear()
        dsAgil.Tables("Edoctav").Constraints.Clear()
        dsAgil.Tables.Remove("Anexos")
        dsAgil.Tables.Remove("Edoctav")
        dsAgil.Tables.Remove("Actifijo")
        dsAgil.Tables.Add(dtCargopol)
        DataGrid1.DataSource = dtCargopol
        DataGrid1.CaptionText = txtAnexo.Text & "   " & txtCusnam.Text
        DataGrid1.Visible = True

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()
        cm3.Dispose()

    End Sub

    Private Sub DataGrid1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.Click
        Dim cCobertura As String
        Dim cTipoPol As String

        txtPoliza.Text = DataGrid1.Item(DataGrid1.CurrentRowIndex, 3)
        DateTimePicker1.Value = DataGrid1.Item(DataGrid1.CurrentRowIndex, 4)
        DateTimePicker2.Value = DataGrid1.Item(DataGrid1.CurrentRowIndex, 5)
        txtAseg.Text = DataGrid1.Item(DataGrid1.CurrentRowIndex, 6)
        txtPrima.Text = DataGrid1.Item(DataGrid1.CurrentRowIndex, 7)
        txtfactura.Text = DataGrid1.Item(DataGrid1.CurrentRowIndex, 8)
        cCobertura = DataGrid1.Item(DataGrid1.CurrentRowIndex, 9)
        cTipoPol = DataGrid1.Item(DataGrid1.CurrentRowIndex, 10)

        txtPoliza.ReadOnly = True
        DateTimePicker1.Enabled = False
        DateTimePicker2.Enabled = False
        txtAseg.ReadOnly = True
        txtPrima.ReadOnly = True
        btnSave.Enabled = False
        Label1.Visible = True
        Label2.Visible = True
        Label3.Visible = True
        Label4.Visible = True
        Label5.Visible = True
        txtPoliza.Visible = True
        DateTimePicker1.Visible = True
        DateTimePicker2.Visible = True
        txtAseg.Visible = True
        txtPrima.Visible = True

        Label8.Visible = True
        cbCobertura.MaxDropDownItems = 2
        cbCobertura.Items.Add("AMPLIA")
        cbCobertura.Items.Add("LIMITADA")
        If cCobertura = "AMPLIA" Then
            cbCobertura.SelectedIndex = 0
        Else
            cbCobertura.SelectedIndex = 1
        End If
        cbCobertura.Visible = True

        Label9.Visible = True
        cbTipoPoliz.MaxDropDownItems = 3
        cbTipoPoliz.Items.Add("EXTERNA")
        cbTipoPoliz.Items.Add("FINAGIL")
        cbTipoPoliz.Items.Add("SEG. MUTUALISTA")
        If cTipoPol = "EXTERNA" Then
            cbTipoPoliz.SelectedIndex = 0
        ElseIf cTipoPol = "FINAGIL" Then
            cbTipoPoliz.SelectedIndex = 1
        ElseIf cTipoPol = "SEG. MUTUALISTA" Then
            cbTipoPoliz.SelectedIndex = 2
        End If
        cbTipoPoliz.Visible = True

        If DataGrid1.Item(DataGrid1.CurrentRowIndex, 11) = "SI" Then
            rbPagSi.Checked = True
        Else
            rbPagNo.Checked = True
        End If
        If DataGrid1.Item(DataGrid1.CurrentRowIndex, 12) = "SI" Then
            rbBPFSi.Checked = True
        Else
            rbBPFNo.Checked = True
        End If

        cbTipoPoliz.Visible = True
        gbBeneficiario.Visible = True
        gbBPreferente.Visible = True
        btnModif.Enabled = True
    End Sub

    Private Sub btnModif_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModif.Click
        txtPoliza.ReadOnly = False
        DateTimePicker1.Enabled = True
        DateTimePicker2.Enabled = True
        txtAseg.ReadOnly = False
        txtPrima.ReadOnly = False
        cbCobertura.Enabled = True
        cbTipoPoliz.Enabled = True
        gbBeneficiario.Enabled = True
        gbBPreferente.Enabled = True
        btnSave.Enabled = True
        btnModif.Enabled = False
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()

        ' Declaración de variables de datos

        Dim strUpdate As String
        Dim cAnexo As String
        Dim cTipoPol As String
        Dim cPagada As String
        Dim cBPF As String
        Dim cCobert As String

        cAnexo = Mid(txtAnexo.Text, 1, 5) & Mid(txtAnexo.Text, 7, 4)

        Select Case cbTipoPoliz.SelectedIndex
            Case Is = 0
                cTipoPol = "E"
            Case Is = 1
                cTipoPol = "F"
            Case Is = 2
                cTipoPol = "M"
        End Select

        cBPF = "N"
        cPagada = "N"
        If rbPagSi.Checked = True Then
            cPagada = "S"
        End If

        If rbBPFSi.Checked = True Then
            cBPF = "S"
        End If

        If cbCobertura.SelectedItem = "AMPLIA" Then
            cCobert = "A"
        Else
            cCobert = "L"
        End If

        Try
            cnAgil.Open()
            strUpdate = "UPDATE Actifijo SET Numpoliz = '" & txtPoliza.Text & "'"
            strUpdate = strUpdate & ", Inicioseg = '" & DTOC(DateTimePicker1.Value) & "'"
            strUpdate = strUpdate & ", Vigencseg = '" & DTOC(DateTimePicker2.Value) & "'"
            strUpdate = strUpdate & ", Asegurador = '" & txtAseg.Text & "'"
            strUpdate = strUpdate & ", Prima = '" & txtPrima.Text & "'"
            strUpdate = strUpdate & ", Cobertura = '" & cCobert & "'"
            strUpdate = strUpdate & ", TipoPol = '" & cTipoPol & "'"
            strUpdate = strUpdate & ", PolPago = '" & cPagada & "'"
            strUpdate = strUpdate & ", BPreferente = '" & cBPF & "'"
            strUpdate = strUpdate & " WHERE Anexo = '" & cAnexo & "'"
            strUpdate = strUpdate & " AND Factura = " & "'" & txtfactura.Text & "'"
            cm1 = New SqlCommand(strUpdate, cnAgil)
            cm1.ExecuteNonQuery()
        Catch eException As Exception
            MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje")
        End Try

        Label1.Visible = False
        Label2.Visible = False
        Label3.Visible = False
        Label4.Visible = False
        Label5.Visible = False
        txtPoliza.Visible = False
        DateTimePicker1.Visible = False
        DateTimePicker2.Visible = False
        cbCobertura.Visible = False
        cbTipoPoliz.Visible = False
        Label8.Visible = False
        Label9.Visible = False
        gbBeneficiario.Visible = False
        gbBPreferente.Visible = False
        txtAseg.Visible = False
        txtPrima.Visible = False
        btnModif.Enabled = False
        btnSave.Enabled = False

        'Actualizo la información que muestra el DataGrid

        cCobert = IIf(cCobert = "A", "AMPLIA", "LIMITADA")
        cPagada = IIf(cPagada = "S", "SI", "NO")
        cBPF = IIf(cBPF = "S", "SI", "NO")
        If cTipoPol = "E" Then
            cTipoPol = "EXTERNA"
        ElseIf cTipoPol = "F" Then
            cTipoPol = "FINAGIL"
        ElseIf cTipoPol = "M" Then
            cTipoPol = "SEG. MUTUALISTA"
        End If

        DataGrid1.Item(DataGrid1.CurrentRowIndex, 3) = txtPoliza.Text
        DataGrid1.Item(DataGrid1.CurrentRowIndex, 4) = DateTimePicker1.Value.ToShortDateString
        DataGrid1.Item(DataGrid1.CurrentRowIndex, 5) = DateTimePicker2.Value.ToShortDateString
        DataGrid1.Item(DataGrid1.CurrentRowIndex, 6) = txtAseg.Text
        DataGrid1.Item(DataGrid1.CurrentRowIndex, 7) = txtPrima.Text
        DataGrid1.Item(DataGrid1.CurrentRowIndex, 8) = txtfactura.Text
        DataGrid1.Item(DataGrid1.CurrentRowIndex, 9) = cCobert
        DataGrid1.Item(DataGrid1.CurrentRowIndex, 10) = cTipoPol
        DataGrid1.Item(DataGrid1.CurrentRowIndex, 11) = cPagada
        DataGrid1.Item(DataGrid1.CurrentRowIndex, 12) = cBPF
        DataGrid1.Refresh()

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        DateTimePicker2.Value = DateAdd(DateInterval.Year, 1, DateTimePicker1.Value)
    End Sub
End Class
