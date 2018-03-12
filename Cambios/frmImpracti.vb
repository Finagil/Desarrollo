Option Explicit On 

Imports System.Data.SqlClient
Imports System.Math
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmImpracti

    Inherits System.Windows.Forms.Form

    ' Declaración de variables de datos de alcance privado

    Dim cAnexo As String
    Friend WithEvents txtTipo As System.Windows.Forms.TextBox
    Friend WithEvents txtNamerep As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Dim nNumero As Decimal
    Dim nPorInt As Decimal
    Dim dsAgil1 As New DataSet()

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
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents txtAnexo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtRfc As System.Windows.Forms.TextBox
    Friend WithEvents txtCalle As System.Windows.Forms.TextBox
    Friend WithEvents txtCol As System.Windows.Forms.TextBox
    Friend WithEvents txtCp As System.Windows.Forms.TextBox
    Friend WithEvents txtDeleg As System.Windows.Forms.TextBox
    Friend WithEvents txtEdo As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtImporte As System.Windows.Forms.TextBox
    Friend WithEvents txtFacturaActivo As System.Windows.Forms.TextBox
    Friend WithEvents lblFacturaActivo As System.Windows.Forms.Label
    Friend WithEvents txtOpcion As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.btnSalir = New System.Windows.Forms.Button
        Me.btnImprimir = New System.Windows.Forms.Button
        Me.btnModificar = New System.Windows.Forms.Button
        Me.txtAnexo = New System.Windows.Forms.TextBox
        Me.txtName = New System.Windows.Forms.TextBox
        Me.txtRfc = New System.Windows.Forms.TextBox
        Me.txtCalle = New System.Windows.Forms.TextBox
        Me.txtCol = New System.Windows.Forms.TextBox
        Me.txtCp = New System.Windows.Forms.TextBox
        Me.txtDeleg = New System.Windows.Forms.TextBox
        Me.txtEdo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtImporte = New System.Windows.Forms.TextBox
        Me.txtOpcion = New System.Windows.Forms.TextBox
        Me.txtFacturaActivo = New System.Windows.Forms.TextBox
        Me.lblFacturaActivo = New System.Windows.Forms.Label
        Me.txtTipo = New System.Windows.Forms.TextBox
        Me.txtNamerep = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.Location = New System.Drawing.Point(24, 16)
        Me.ListBox1.MultiColumn = True
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(472, 160)
        Me.ListBox1.TabIndex = 12
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(520, 64)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(136, 23)
        Me.btnSalir.TabIndex = 16
        Me.btnSalir.Text = "Salir"
        '
        'btnImprimir
        '
        Me.btnImprimir.Location = New System.Drawing.Point(520, 392)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(136, 23)
        Me.btnImprimir.TabIndex = 17
        Me.btnImprimir.Text = "Imprimir Factura"
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(520, 24)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(136, 23)
        Me.btnModificar.TabIndex = 18
        Me.btnModificar.Text = "Modificar Datos"
        '
        'txtAnexo
        '
        Me.txtAnexo.Location = New System.Drawing.Point(632, 184)
        Me.txtAnexo.Name = "txtAnexo"
        Me.txtAnexo.Size = New System.Drawing.Size(8, 21)
        Me.txtAnexo.TabIndex = 19
        Me.txtAnexo.Visible = False
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(128, 224)
        Me.txtName.Name = "txtName"
        Me.txtName.ReadOnly = True
        Me.txtName.Size = New System.Drawing.Size(520, 21)
        Me.txtName.TabIndex = 20
        '
        'txtRfc
        '
        Me.txtRfc.Location = New System.Drawing.Point(128, 248)
        Me.txtRfc.Name = "txtRfc"
        Me.txtRfc.ReadOnly = True
        Me.txtRfc.Size = New System.Drawing.Size(144, 21)
        Me.txtRfc.TabIndex = 21
        '
        'txtCalle
        '
        Me.txtCalle.Location = New System.Drawing.Point(128, 272)
        Me.txtCalle.Name = "txtCalle"
        Me.txtCalle.ReadOnly = True
        Me.txtCalle.Size = New System.Drawing.Size(520, 21)
        Me.txtCalle.TabIndex = 22
        '
        'txtCol
        '
        Me.txtCol.Location = New System.Drawing.Point(128, 296)
        Me.txtCol.Name = "txtCol"
        Me.txtCol.ReadOnly = True
        Me.txtCol.Size = New System.Drawing.Size(296, 21)
        Me.txtCol.TabIndex = 23
        '
        'txtCp
        '
        Me.txtCp.Location = New System.Drawing.Point(536, 296)
        Me.txtCp.Name = "txtCp"
        Me.txtCp.ReadOnly = True
        Me.txtCp.Size = New System.Drawing.Size(112, 21)
        Me.txtCp.TabIndex = 24
        '
        'txtDeleg
        '
        Me.txtDeleg.Location = New System.Drawing.Point(128, 320)
        Me.txtDeleg.Name = "txtDeleg"
        Me.txtDeleg.ReadOnly = True
        Me.txtDeleg.Size = New System.Drawing.Size(352, 21)
        Me.txtDeleg.TabIndex = 25
        '
        'txtEdo
        '
        Me.txtEdo.Location = New System.Drawing.Point(128, 344)
        Me.txtEdo.Name = "txtEdo"
        Me.txtEdo.ReadOnly = True
        Me.txtEdo.Size = New System.Drawing.Size(352, 21)
        Me.txtEdo.TabIndex = 26
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(24, 232)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Nombre"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(24, 256)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "R.F.C."
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(24, 280)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Calle"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(24, 304)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Colonia"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(496, 304)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 16)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "C.P."
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(24, 328)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 16)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "Delegación"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(24, 352)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 16)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "Estado"
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(24, 192)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(161, 16)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "Datos para facturar"
        '
        'txtImporte
        '
        Me.txtImporte.Location = New System.Drawing.Point(616, 184)
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.Size = New System.Drawing.Size(8, 21)
        Me.txtImporte.TabIndex = 35
        Me.txtImporte.Visible = False
        '
        'txtOpcion
        '
        Me.txtOpcion.Location = New System.Drawing.Point(600, 184)
        Me.txtOpcion.Name = "txtOpcion"
        Me.txtOpcion.Size = New System.Drawing.Size(8, 21)
        Me.txtOpcion.TabIndex = 36
        Me.txtOpcion.Visible = False
        '
        'txtFacturaActivo
        '
        Me.txtFacturaActivo.Location = New System.Drawing.Point(279, 394)
        Me.txtFacturaActivo.Name = "txtFacturaActivo"
        Me.txtFacturaActivo.Size = New System.Drawing.Size(100, 21)
        Me.txtFacturaActivo.TabIndex = 37
        Me.txtFacturaActivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblFacturaActivo
        '
        Me.lblFacturaActivo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFacturaActivo.Location = New System.Drawing.Point(25, 398)
        Me.lblFacturaActivo.Name = "lblFacturaActivo"
        Me.lblFacturaActivo.Size = New System.Drawing.Size(233, 13)
        Me.lblFacturaActivo.TabIndex = 38
        Me.lblFacturaActivo.Text = "Factura de Activo Fijo a Imprimir"
        '
        'txtTipo
        '
        Me.txtTipo.Location = New System.Drawing.Point(572, 184)
        Me.txtTipo.Name = "txtTipo"
        Me.txtTipo.Size = New System.Drawing.Size(8, 21)
        Me.txtTipo.TabIndex = 39
        Me.txtTipo.Visible = False
        '
        'txtNamerep
        '
        Me.txtNamerep.Location = New System.Drawing.Point(586, 184)
        Me.txtNamerep.Name = "txtNamerep"
        Me.txtNamerep.Size = New System.Drawing.Size(8, 21)
        Me.txtNamerep.TabIndex = 40
        Me.txtNamerep.Visible = False
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Location = New System.Drawing.Point(520, 361)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(136, 23)
        Me.Button1.TabIndex = 41
        Me.Button1.TabStop = False
        Me.Button1.Text = "Carta Responsiva"
        '
        'frmImpracti
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(680, 439)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtNamerep)
        Me.Controls.Add(Me.txtTipo)
        Me.Controls.Add(Me.lblFacturaActivo)
        Me.Controls.Add(Me.txtFacturaActivo)
        Me.Controls.Add(Me.txtOpcion)
        Me.Controls.Add(Me.txtImporte)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtEdo)
        Me.Controls.Add(Me.txtDeleg)
        Me.Controls.Add(Me.txtCp)
        Me.Controls.Add(Me.txtCol)
        Me.Controls.Add(Me.txtCalle)
        Me.Controls.Add(Me.txtRfc)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.txtAnexo)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.ListBox1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmImpracti"
        Me.Text = "Impresión de la Factura de Activo Fijo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub frmImpracti_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim dsAgil As New DataSet()
        Dim drActifijo As DataRow
        Dim drCliente As DataRow
        Dim drDatoActifij As DataRowCollection
        Dim daActifijo As New SqlDataAdapter(cm1)
        Dim daCliente As New SqlDataAdapter(cm2)

        ' Declaración de variables de datos

        Dim cFactura As String
        Dim cProveed As String
        Dim cImporte As String
        Dim cFactact As String
        Dim cIndice As String
        Dim nFactact As Decimal
        Dim nImporte As Decimal
        Dim nProximo As Integer
        Dim nCounter As Integer

        cAnexo = Mid(txtAnexo.Text, 1, 5) & Mid(txtAnexo.Text, 7, 10)

        ' Este Stored Procedure trae los datos de TODOS los bienes de un contrato dado del archivo Actifijo

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DatosEquipo1"
            .Connection = cnAgil
            .Parameters.Add("@Anexo", SqlDbType.NVarChar)
            .Parameters(0).Value = cAnexo
        End With

        ' Trae los datos del cliente para el contrato que se va a imprimir su factura de activo fijo

        With cm2
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Actifijo3"
            .Connection = cnAgil
            .Parameters.Add("@Anexo", SqlDbType.NVarChar)
            .Parameters(0).Value = cAnexo
        End With

        ' Trae el número consecutivo de facturas de activo fijo

        With cm3
            .CommandType = CommandType.Text
            .CommandText = "SELECT ConInv FROM Llaves"
            .Connection = cnAgil
        End With

        ' Incrementa en uno el número de factura de activo fijo

        cnAgil.Open()
        nNumero = CInt(cm3.ExecuteScalar()) + 1
        cnAgil.Close()

        txtFacturaActivo.Text = nNumero.ToString

        Try

            'Llenar el DataSet a través del DataAdapter, lo cual abre y cierra la conexión

            daActifijo.Fill(dsAgil, "ActiFijo")
            daCliente.Fill(dsAgil, "Cliente")

            drDatoActifij = dsAgil.Tables("ActiFijo").Rows      ' Contiene n bienes
            drCliente = dsAgil.Tables("Cliente").Rows(0)          ' Contiene 1 registro con los datos del cliente

            nCounter = dsAgil.Tables("Actifijo").Rows.Count

            If nCounter = 0 Then
                MsgBox("Contrato sin Activo Fijo capturado", MsgBoxStyle.Critical, "Mensaje del Sistema")
                Me.Close()
            End If

            If Not drCliente("Opcion") Is System.DBNull.Value Then

                If drCliente("Pagado") = "N" Then
                    MsgBox("Opción de Compra NO pagada", MsgBoxStyle.OkOnly, "Mensaje")
                    Me.Close()
                End If

                ListBox1.Items.Clear()

                nProximo = 0
                nImporte = 0
                For Each drActifijo In drDatoActifij
                    cIndice = nProximo.ToString
                    cFactura = drActifijo("Factura")
                    cProveed = Mid(drActifijo("Proveedor"), 1, 35)
                    cImporte = FormatNumber(drActifijo("Importe")).ToString
                    nFactact = drActifijo("FactFij")
                    cFactact = nFactact.ToString
                    nImporte += drActifijo("Importe")
                    ListBox1.Items.Add(cIndice & " " & cFactura & " " & cProveed & " " & cImporte & "   " & cFactact)
                    nProximo += 1
                Next

                txtName.Text = drCliente("Descr")
                txtRfc.Text = drCliente("RFC")
                txtCalle.Text = drCliente("Calle")
                txtCol.Text = drCliente("Colonia")
                txtCp.Text = drCliente("Copos")
                txtDeleg.Text = drCliente("Delegacion")
                txtEdo.Text = drCliente("Descplaza")
                txtImporte.Text = nImporte
                txtOpcion.Text = drCliente("Opcion")
                txtTipo.Text = drCliente("Tipo")
                txtNamerep.Text = drCliente("Nomrepr")
                nPorInt = drCliente("PorInt")
            Else
                MsgBox("Contrato sin Opción de Compra capturada", MsgBoxStyle.OkOnly, "Mensaje")
                Me.Close()
            End If

        Catch eException As Exception
            MsgBox(eException.Source & " " & eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")
        End Try

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()
        cm3.Dispose()

    End Sub

    Private Sub btnModificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        If ListBox1.SelectedItem = Nothing Then
            MsgBox("Hay que seleccionar una Factura", MsgBoxStyle.Information, "Mensaje")
        Else
            txtName.ReadOnly = False
            txtRfc.ReadOnly = False
            txtCalle.ReadOnly = False
            txtCol.ReadOnly = False
            txtCp.ReadOnly = False
            txtDeleg.ReadOnly = False
            txtEdo.ReadOnly = False
            txtName.Focus()
        End If
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnImprimir.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim drActifijo As DataRow
        Dim drDatos As DataRow
        Dim daActiFijo As New SqlDataAdapter(cm1)
        Dim dtReporte As New DataTable("Reporte")

        ' Declaración de variables de datos

        Dim cFactsele As String
        Dim cFactura As String
        Dim cProveed As String
        Dim cImporte As String
        Dim cFactact As String
        Dim cIndice As String
        Dim ccadena As String
        Dim cSerie As String
        Dim cFecha As String
        Dim strUpdate As String
        Dim nFactact As Decimal
        Dim nPorcen As Decimal
        Dim nSubtot As Decimal
        Dim nTotal As Decimal
        Dim nIva As Decimal
        Dim nProximo As Integer
        Dim nNumero As Integer
        Dim i As Integer

        ' Declaración de Clases para generación de los Certificados Fiscales Digitales 

        Dim newCFD As New clsComprobante
        Dim newConcepto As clsConcepto

        ' Declaración de variables de Crystal Reports

        Dim newrptImpracti As New rptImpracti()

        ' Defino las columnas de la Tabla Reporte

        dtReporte.Columns.Add("Nombre", Type.GetType("System.String"))
        dtReporte.Columns.Add("RFC", Type.GetType("System.String"))
        dtReporte.Columns.Add("Calle", Type.GetType("System.String"))
        dtReporte.Columns.Add("Colonia", Type.GetType("System.String"))
        dtReporte.Columns.Add("Del", Type.GetType("System.String"))
        dtReporte.Columns.Add("Copos", Type.GetType("System.String"))
        dtReporte.Columns.Add("Plaza", Type.GetType("System.String"))
        dtReporte.Columns.Add("Fecha", Type.GetType("System.String"))
        dtReporte.Columns.Add("Detalle", Type.GetType("System.String"))
        dtReporte.Columns.Add("Modelo", Type.GetType("System.String"))
        dtReporte.Columns.Add("Motor", Type.GetType("System.String"))
        dtReporte.Columns.Add("Serie", Type.GetType("System.String"))
        dtReporte.Columns.Add("SubTot", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("Iva", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("Total", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("Letra", Type.GetType("System.String"))
        dtReporte.Columns.Add("Contrato", Type.GetType("System.String"))
        dtReporte.Columns.Add("Numero", Type.GetType("System.String"))
        dtReporte.Columns.Add("Namerep", Type.GetType("System.String"))
        dtReporte.Columns.Add("Tipo", Type.GetType("System.String"))

        If ListBox1.SelectedItem = Nothing Then

            MsgBox("Hay que seleccionar una Factura para Imprimir", MsgBoxStyle.Information, "Mensaje")

        Else

            cFactsele = ListBox1.Items(ListBox1.SelectedIndex)

            ' Este Stored Procedure trae los datos de TODOS los bienes de un contrato dado del archivo Actifijo

            With cm1
                .CommandType = CommandType.StoredProcedure
                .CommandText = "DatosEquipo1"
                .Connection = cnAgil
                .Parameters.Add("@Anexo", SqlDbType.NVarChar)
                .Parameters(0).Value = cAnexo
            End With

            Try
                daActiFijo.Fill(dsAgil1, "ActiFijo")

            Catch eException As Exception

                MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")

            End Try

            nProximo = 0

            For Each drActifijo In dsAgil1.Tables("ActiFijo").Rows

                cIndice = nProximo.ToString
                cFactura = drActifijo("Factura")
                cProveed = Mid(drActifijo("Proveedor"), 1, 35)
                cImporte = FormatNumber(drActifijo("Importe")).ToString
                nFactact = drActifijo("FactFij")
                cFactact = nFactact.ToString
                nPorcen = Round((drActifijo("Importe") * 100) / Val(txtImporte.Text), 2)
                nSubtot = Round(Val(txtOpcion.Text) * (nPorcen / 100), 2)
                nIva = Round(nSubtot * 0.16, 2)
                nTotal = nSubtot + nIva
                ccadena = cIndice & " " & cFactura & " " & cProveed & " " & cImporte & "   " & cFactact

                If ccadena = cFactsele Then

                    If Val(cFactact) <> 0 Then

                        MsgBox("Este bien ya está Facturado", MsgBoxStyle.Information, "Mensaje")

                    Else

                        nNumero = CDbl(txtFacturaActivo.Text)
                        drDatos = dtReporte.NewRow()
                        drDatos("Nombre") = txtName.Text
                        drDatos("RFC") = txtRfc.Text
                        drDatos("Calle") = txtCalle.Text
                        drDatos("Colonia") = txtCol.Text
                        drDatos("Del") = txtDeleg.Text
                        drDatos("Copos") = txtCp.Text
                        drDatos("Plaza") = txtEdo.Text
                        drDatos("Fecha") = Mes(DTOC(Today))
                        drDatos("Detalle") = drActifijo("Detalle")
                        drDatos("Modelo") = drActifijo("Modelo")
                        drDatos("Motor") = drActifijo("Motor")
                        drDatos("Serie") = drActifijo("Serie")
                        cSerie = drActifijo("Serie")
                        drDatos("SubTot") = nSubtot
                        drDatos("Iva") = nIva
                        drDatos("Total") = nTotal
                        drDatos("Letra") = Letras(nTotal.ToString)
                        drDatos("Contrato") = txtAnexo.Text
                        drDatos("Numero") = nNumero.ToString
                        drDatos("Namerep") = txtNamerep.Text
                        drDatos("Tipo") = txtTipo.Text
                        dtReporte.Rows.Add(drDatos)

                        dsAgil1.Tables.Add(dtReporte)


                        ' Generar el CFD (Certificado Fiscal Digital)

                        cFecha = DTOC(Today)
                        cFecha = Mid(cFecha, 1, 4) + "-" + Mid(cFecha, 5, 2) + "-" + Mid(cFecha, 7, 2) + "T" + Mid(Now.TimeOfDay.ToString, 1, 8)

                        With newCFD
                            .version = "2.0"                                ' La versión siempre es la 2.0
                            .serie = "B"                                    ' La serie dependerá de la sucursal que esté expidiendo el CFD
                            .folio = nNumero.ToString                       ' El folio dependerá de la sucursal que esté expidiendo el CFD
                            .fecha = cFecha                                 ' Esta fecha es la de aplicación del pago (cFecha), no la de realización del pago
                            .noAprobacion = "194645"                        ' El número de aprobación dependerá de la sucursal que esté expidiendo el CFD"
                            .anoAprobacion = "2010"                         ' El año de aprobación dependerá de la sucursal que esté expidiendo el CFD
                            .formaDePago = ""
                            .subTotal = nSubtot
                            .total = nTotal
                            .tipoDeComprobante = "ingreso"
                            .anexo = cAnexo
                            .importeLetra = Letras(nTotal.ToString)
                            .leyenda = ""
                            .monto = 0
                            .iva = 0
                            .metodoDePago = ""
                            .cadenaOriginal = ""
                        End With

                        ' Los datos de expedición dependerán de la sucursal que esté expidiendo el CFD

                        With newCFD.emisor
                            .expedidoEn_calle = "LEANDRO VALLE 402"
                            .expedidoEn_colonia = "REFORMA Y FFCCNN"
                            .expedidoEn_municipio = "TOLUCA"
                            .expedidoEn_estado = "ESTADO DE MEXICO"
                            .expedidoEn_pais = "MEXICO"
                            .expedidoEn_codigoPostal = "50070"
                        End With

                        With newCFD.receptor
                            .rfc = Trim(txtRfc.Text)
                            .nombre = Trim(txtName.Text)
                            .calle = Trim(txtCalle.Text)
                            .colonia = Trim(txtCol.Text)
                            .municipio = Trim(txtDeleg.Text)
                            .estado = Trim(txtEdo.Text)
                            .pais = "MEXICO"
                            .codigoPostal = Trim(txtCp.Text)
                        End With

                        ' Aqui no tenemos conceptos de pago unicamente la descripción del BIEN

                        For i = 1 To 5
                            newConcepto = New clsConcepto
                            Select Case i
                                Case 1
                                    With newConcepto
                                        .cantidad = 1
                                        .descripcion = Replace(Replace(drActifijo("Detalle"), Chr(10), " "), Chr(13), " ")
                                        .valorUnitario = 0
                                        .importe = 0
                                    End With
                                Case 2
                                    With newConcepto
                                        .cantidad = 1
                                        .descripcion = "USADO EN EL ESTADO EN QUE SE ENCUENTRA"
                                        .valorUnitario = 0
                                        .importe = 0
                                    End With
                                Case 3
                                    With newConcepto
                                        .cantidad = 1
                                        .descripcion = "MODELO: " & Trim(drActifijo("Modelo"))
                                        .valorUnitario = 0
                                        .importe = 0
                                    End With
                                Case 4
                                    With newConcepto
                                        .cantidad = 1
                                        .descripcion = "MOTOR: " & Trim(drActifijo("Motor"))
                                        .valorUnitario = 0
                                        .importe = 0
                                    End With
                                Case 5
                                    With newConcepto
                                        .cantidad = 1
                                        .descripcion = "NO. DE SERIE: " & Trim(drActifijo("Serie"))
                                        .valorUnitario = 0
                                        .importe = 0
                                    End With
                            End Select
                            newCFD.lstConceptos.Add(newConcepto)
                        Next

                        With newCFD.impuestos
                            .impuesto = "IVA"
                            .tasa = IIf(nIva > 0, nPorInt.ToString, "0.00")          ' La tasa del impuesto dependerá del lugar de expedición
                            .importe = nIva
                        End With

                        CFD(newCFD)

                        Exit For

                    End If

                End If

                nProximo += 1

            Next

            ' Actualización de la tabla Llaves 

            strUpdate = "UPDATE Llaves SET ConInv = " & nNumero
            cm2 = New SqlCommand(strUpdate, cnAgil)
            cnAgil.Open()
            cm2.ExecuteNonQuery()
            cnAgil.Close()

            ' Actualización de la tabla Actifijo para marcar la Factura de Activo

            strUpdate = "UPDATE Actifijo SET FactFij = " & nNumero
            strUpdate = strUpdate & " WHERE Anexo = '" & cAnexo & "'"
            strUpdate = strUpdate & " AND Factura = '" & cFactura & "'"
            strUpdate = strUpdate & " AND Serie = '" & cSerie & "'"
            cm2 = New SqlCommand(strUpdate, cnAgil)
            cnAgil.Open()
            cm2.ExecuteNonQuery()
            cnAgil.Close()

        End If
        Button1.Enabled = True
        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()

    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim newrptImpracti As New rptCartaResponsiva()

        newrptImpracti.SetDataSource(dsAgil1)
        newrptImpracti.PrintOptions.PaperOrientation = PaperOrientation.Portrait
        newrptImpracti.PrintToPrinter(2, False, 0, 0)

    End Sub
End Class
