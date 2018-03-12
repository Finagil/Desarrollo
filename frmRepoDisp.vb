Option Explicit On 

Imports System.Data.SqlClient
Imports System.Math

Public Class frmRepoDisp

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
    Friend WithEvents dtpProceso As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtValorAforo As System.Windows.Forms.TextBox
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dtpProceso = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnProcesar = New System.Windows.Forms.Button
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtValorAforo = New System.Windows.Forms.TextBox
        Me.Column1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtpProceso
        '
        Me.dtpProceso.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpProceso.Location = New System.Drawing.Point(136, 16)
        Me.dtpProceso.Name = "dtpProceso"
        Me.dtpProceso.Size = New System.Drawing.Size(96, 20)
        Me.dtpProceso.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Fecha de Proceso"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnProcesar
        '
        Me.btnProcesar.Location = New System.Drawing.Point(256, 16)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(75, 23)
        Me.btnProcesar.TabIndex = 3
        Me.btnProcesar.Text = "Procesar"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(865, 91)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(147, 21)
        Me.ComboBox1.TabIndex = 4
        '
        'DataGridView1
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Peru
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.HotTrack
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Desktop
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.HotTrack
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView1.Location = New System.Drawing.Point(13, 66)
        Me.DataGridView1.Name = "DataGridView1"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.DataGridView1.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridView1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.DataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.RoyalBlue
        Me.DataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.DataGridView1.Size = New System.Drawing.Size(844, 584)
        Me.DataGridView1.TabIndex = 5
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.Navy
        Me.TextBox1.Location = New System.Drawing.Point(713, 663)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(143, 24)
        Me.TextBox1.TabIndex = 6
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(863, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Seleccionar Banco"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(866, 211)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(60, 27)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Asignar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(862, 144)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Valor del Aforo"
        '
        'txtValorAforo
        '
        Me.txtValorAforo.Location = New System.Drawing.Point(866, 166)
        Me.txtValorAforo.Name = "txtValorAforo"
        Me.txtValorAforo.Size = New System.Drawing.Size(99, 20)
        Me.txtValorAforo.TabIndex = 10
        '
        'Column1
        '
        Me.Column1.FalseValue = "False"
        Me.Column1.HeaderText = "Selec"
        Me.Column1.Name = "Column1"
        Me.Column1.TrueValue = "True"
        Me.Column1.Width = 35
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "Anexo"
        Me.Column2.HeaderText = "Contrato"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 70
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "Cliente"
        Me.Column3.HeaderText = "Nombre del Cliente o Razón Social"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 260
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "SaldoEquipo"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column4.HeaderText = "Saldo Equipo"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 90
        '
        'Column5
        '
        Me.Column5.DataPropertyName = "Fechacon"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column5.HeaderText = "Fecha Cont."
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 80
        '
        'Column6
        '
        Me.Column6.DataPropertyName = "Termina"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column6.HeaderText = "Fecha Ter."
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 80
        '
        'Column7
        '
        Me.Column7.DataPropertyName = "Equipo"
        Me.Column7.HeaderText = "Tipo de Equipo"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 130
        '
        'Column8
        '
        Me.Column8.DataPropertyName = "Asignado"
        Me.Column8.HeaderText = "Asignado"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Visible = False
        '
        'Column9
        '
        Me.Column9.DataPropertyName = "Tipar"
        Me.Column9.HeaderText = "Tipo"
        Me.Column9.Name = "Column9"
        Me.Column9.Width = 50
        '
        'frmRepoDisp
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1024, 702)
        Me.Controls.Add(Me.txtValorAforo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.btnProcesar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpProceso)
        Me.Name = "frmRepoDisp"
        Me.Text = "Contratos disponibles para dar en garantía"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Dim nCounter As Decimal

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm4 As New SqlCommand()
        Dim dsBco As New DataSet()
        Dim daBancos As New SqlDataAdapter(cm4)

        ' Con este Stored Procedure obtengo la información de los Bancos

        With cm4
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Bancos1"
            .Connection = cnAgil
        End With

        LlenaGrid()

        daBancos.Fill(dsBco, "Bancos")

        DataGridView1.Refresh()

        ComboBox1.MaxDropDownItems = 6

        ComboBox1.DataSource = dsBco
        ComboBox1.DisplayMember = "Bancos.DescBanco"
        ComboBox1.ValueMember = "Bancos.Banco"

        cnAgil.Dispose()

    End Sub

    Private Sub dataGridView1_CellContentClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        Dim nImporte As Decimal
        Dim i As Integer

        DataGridView1.Rows(e.RowIndex).Cells(7).Value = IIf(DataGridView1.Rows(e.RowIndex).Cells(7).Value = "N", "S", "N")
        DataGridView1.Refresh()
        nImporte = 0
        For i = 0 To nCounter - 1
            If DataGridView1.Rows(i).Cells(7).Value = "S" Then
                nImporte += DataGridView1.Rows(i).Cells(3).Value
            End If
        Next
        TextBox1.Text = FormatNumber(nImporte).ToString

    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()

        Dim nAforo As Integer
        Dim i As Integer
        Dim strUpdate As String
        Dim strInsert As String
        Dim cAforo As String
        Dim cAnexo As String

        ' Este comando permite traer el consecutivo del Aforo

        With cm1
            .CommandType = CommandType.Text
            .CommandText = "SELECT ConAforo FROM Llaves"
            .Connection = cnAgil
        End With

        cnAgil.Open()
        nAforo = CInt(cm1.ExecuteScalar())
        cnAgil.Close()
        cAforo = (nAforo + 1).ToString

        cnAgil.Open()
        For i = 0 To nCounter - 1
            If DataGridView1.Rows(i).Cells(7).Value = "S" Then
                cAnexo = Mid(DataGridView1.Rows(i).Cells(1).Value, 1, 5) & Mid(DataGridView1.Rows(i).Cells(1).Value, 7, 4)
                strUpdate = "UPDATE Anexos SET Garantia = " & cAforo
                strUpdate = strUpdate & " WHERE Anexo = " & cAnexo
                cm1 = New SqlCommand(strUpdate, cnAgil)
                cm1.ExecuteNonQuery()
            End If
        Next

        strInsert = "INSERT INTO CtrlAforos(Garantia, Fecha, Importe, Banco)"
        strInsert = strInsert & " VALUES ('"
        strInsert = strInsert & cAforo & "', '"
        strInsert = strInsert & DTOC(dtpProceso.Value) & "', '"
        strInsert = strInsert & txtValorAforo.Text & "', '"
        strInsert = strInsert & ComboBox1.SelectedValue.ToString()
        strInsert = strInsert & "')"
        cm1 = New SqlCommand(strInsert, cnAgil)
        cm1.ExecuteNonQuery()

        strUpdate = "UPDATE Llaves SET ConAforo = " & nAforo + 1
        cm1 = New SqlCommand(strUpdate, cnAgil)
        cm1.ExecuteNonQuery()
        cnAgil.Close()

        LlenaGrid()
        DataGridView1.Refresh()
        txtValorAforo.Text = 0
        TextBox1.Text = 0

        MsgBox("Se aplicó el Pagaré " & cAforo, MsgBoxStyle.Critical, "Mensaje")

    End Sub

    Private Sub LlenaGrid()

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim dsAgil As New DataSet()
        Dim dsReporte As New DataSet()
        Dim daAnexos As New SqlDataAdapter(cm1)
        Dim daEdoctav As New SqlDataAdapter(cm2)
        Dim dafacturas As New SqlDataAdapter(cm3)
        Dim dtReporte As New DataTable("Reporte")
        Dim dtMasde90 As New DataTable("Cartera")
        Dim drEdoctav As DataRow()
        Dim drAnexo As DataRow
        Dim drReporte As DataRow
        Dim drMas90 As DataRow
        Dim drRevisa As DataRow
        Dim relAnexoEdoctav As DataRelation
        Dim myColArray(1) As DataColumn
       
        ' Declaración de variables de datos

        Dim cAnexo As String
        Dim cCliente As String
        Dim cEquipo As String
        Dim cFecha As String
        Dim cFechacon As String
        Dim cTermina As String
        Dim nCarteraEquipo As Decimal
        Dim nInteresEquipo As Decimal
        Dim nSaldoEquipo As Decimal
        Dim nDiasvencido As Integer

        ' Declaración de variables de Crystal Reports

        Dim newrptRepoDisp As New rptRepoDisp()

        cFecha = DTOC(dtpProceso.Value)

        ' Primero creo la tabla Reporte que será la base del reporte

        dtReporte.Columns.Add("Anexo", Type.GetType("System.String"))
        dtReporte.Columns.Add("Cliente", Type.GetType("System.String"))
        dtReporte.Columns.Add("SaldoEquipo", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("Fechacon", Type.GetType("System.String"))
        dtReporte.Columns.Add("Termina", Type.GetType("System.String"))
        dtReporte.Columns.Add("Equipo", Type.GetType("System.String"))
        dtReporte.Columns.Add("Asignado", Type.GetType("System.String"))
        dtReporte.Columns.Add("Tipar", Type.GetType("System.String"))
       
        ' Este Stored Procedure trae todos los contratos activos que hayan sido financiados con recursos
        ' propios y que no estén cedidos en garantía

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "RepoDisp1"
            .Connection = cnAgil
            .Parameters.Add("@Fecha", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        ' Este Stored Procedure trae la tabla de amortización del equipo de todos los contratos activos
        ' que hayan sido financiados con recursos propios y que no estén cedidos en garantía

        With cm2
            .CommandType = CommandType.StoredProcedure
            .CommandText = "RepoDisp2"
            .Connection = cnAgil
            .Parameters.Add("@Fecha", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        ' Este Stored Procedure trae las facturas vencidas, el pago inicial (sin el 5% Nafin) 
        ' y la opción de compra exigible de los contratos activos o terminados con saldo en rentas

        With cm3
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Repantig1"
            .Connection = cnAgil
            .Parameters.Add("@Fecha", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With


        ' Llenar el DataSet a través del DataAdapter, lo cual abre y cierra la conexión

        daAnexos.Fill(dsAgil, "Anexos")
        daEdoctav.Fill(dsAgil, "Edoctav")
        dafacturas.Fill(dsAgil, "Facturas")

        ' Establecer la relación entre Anexos y Edoctav

        relAnexoEdoctav = New DataRelation("AnexoEdoctav", dsAgil.Tables("Anexos").Columns("Anexo"), dsAgil.Tables("Edoctav").Columns("Anexo"))
        dsAgil.EnforceConstraints = False
        dsAgil.Relations.Add(relAnexoEdoctav)

        ' Primero creo la tabla Clientes que me dirá que contratos estan en Cartera vencida por más de 90 días

        dtMasde90.Columns.Add("Anexo", Type.GetType("System.String"))
        dtMasde90.Columns.Add("Colmas90", Type.GetType("System.Decimal"))
        myColArray(0) = dtMasde90.Columns("Anexo")
        dtMasde90.PrimaryKey = myColArray

        For Each drAnexo In dsAgil.Tables("Facturas").Rows

            nDiasvencido = DateDiff(DateInterval.Day, CTOD(drAnexo("Feven")), CTOD(cFecha))

            If nDiasvencido > 89 Then
                drRevisa = dtMasde90.Rows.Find(drAnexo("Anexo"))
                If drRevisa Is Nothing Then
                    drMas90 = dtMasde90.NewRow()
                    drMas90("Anexo") = drAnexo("Anexo")
                    drMas90("Colmas90") = nDiasvencido
                    dtMasde90.Rows.Add(drMas90)
                End If
            End If

        Next

        For Each drAnexo In dsAgil.Tables("Anexos").Rows

            cAnexo = drAnexo("Anexo")
            cCliente = drAnexo("Descr")

            drMas90 = dtMasde90.Rows.Find(cAnexo)

            If drMas90 Is Nothing Then

                nSaldoEquipo = 0
                nInteresEquipo = 0
                nCarteraEquipo = 0

                ' Esta instrucción trae la tabla de amortización del Equipo única y exclusivamente del contrato
                ' que está siendo procesado

                drEdoctav = drAnexo.GetChildRows("AnexoEdoctav")
                TraeSald(drEdoctav, cFecha, nSaldoEquipo, nInteresEquipo, nCarteraEquipo)

                cFechacon = drAnexo("Fechacon")
                cTermina = DTOC(Termina(CTOD(drAnexo("Fvenc")), drAnexo("Plazo")))
                cEquipo = drAnexo("DescEquipo")

                If nSaldoEquipo > 0 Then
                    drReporte = dtReporte.NewRow()
                    drReporte("Anexo") = Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 6, 4)
                    drReporte("Cliente") = cCliente
                    drReporte("SaldoEquipo") = nSaldoEquipo
                    drReporte("Fechacon") = Mid(cFechacon, 7, 2) & "/" & Mid(cFechacon, 5, 2) & "/" & Mid(cFechacon, 1, 4)
                    drReporte("Termina") = Mid(cTermina, 7, 2) & "/" & Mid(cTermina, 5, 2) & "/" & Mid(cTermina, 1, 4)
                    drReporte("Equipo") = cEquipo
                    drReporte("Asignado") = "N"
                    drReporte("Tipar") = drAnexo("Tipar")
                    dtReporte.Rows.Add(drReporte)
                End If

            End If

        Next

        ' Antes de remover tablas del DataSet, es necesario eliminar antes las relaciones y las restricciones
        ' que existen entre estas tablas

        dsAgil.Relations.Clear()
        dsAgil.Tables("Anexos").Constraints.Clear()
        dsAgil.Tables("Edoctav").Constraints.Clear()
        dsAgil.Tables.Remove("Anexos")
        dsAgil.Tables.Remove("Edoctav")

        dsAgil.Tables.Add(dtReporte)

        ' Descomentar la siguiente línea en caso de que se deseara modificar el reporte rptRepoDisp
        ' dsAgil.WriteXml("C:\Schema21.xml", XmlWriteMode.WriteSchema)

        DataGridView1.DataSource = dtReporte
        nCounter = dtReporte.Rows.Count()

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()

    End Sub

End Class
