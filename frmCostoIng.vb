Option Explicit On 

Imports System.Data.SqlClient
Imports System.Math

Public Class frmCostoIng
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
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents lblFechaProceso As System.Windows.Forms.Label
    Friend WithEvents gbResultados As System.Windows.Forms.GroupBox
    Friend WithEvents lblCosto As System.Windows.Forms.Label
    Friend WithEvents lblIngreso As System.Windows.Forms.Label
    Friend WithEvents txtIntereses As System.Windows.Forms.TextBox
    Friend WithEvents txtIngreso As System.Windows.Forms.TextBox
    Friend WithEvents txtCosto As System.Windows.Forms.TextBox
    Friend WithEvents txtVariacion As System.Windows.Forms.TextBox
    Friend WithEvents dtpCostoIng As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblVariacion As System.Windows.Forms.Label
    Friend WithEvents lblIntereses As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnProcesar = New System.Windows.Forms.Button()
        Me.lblFechaProceso = New System.Windows.Forms.Label()
        Me.gbResultados = New System.Windows.Forms.GroupBox()
        Me.lblIntereses = New System.Windows.Forms.Label()
        Me.lblVariacion = New System.Windows.Forms.Label()
        Me.lblCosto = New System.Windows.Forms.Label()
        Me.lblIngreso = New System.Windows.Forms.Label()
        Me.txtIntereses = New System.Windows.Forms.TextBox()
        Me.txtIngreso = New System.Windows.Forms.TextBox()
        Me.txtCosto = New System.Windows.Forms.TextBox()
        Me.txtVariacion = New System.Windows.Forms.TextBox()
        Me.dtpCostoIng = New System.Windows.Forms.DateTimePicker()
        Me.gbResultados.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnProcesar
        '
        Me.btnProcesar.Location = New System.Drawing.Point(306, 14)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(80, 24)
        Me.btnProcesar.TabIndex = 18
        Me.btnProcesar.Text = "Procesar"
        '
        'lblFechaProceso
        '
        Me.lblFechaProceso.Location = New System.Drawing.Point(90, 19)
        Me.lblFechaProceso.Name = "lblFechaProceso"
        Me.lblFechaProceso.Size = New System.Drawing.Size(100, 16)
        Me.lblFechaProceso.TabIndex = 17
        Me.lblFechaProceso.Text = "Fecha de Proceso:"
        '
        'gbResultados
        '
        Me.gbResultados.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblIntereses, Me.lblVariacion, Me.lblCosto, Me.lblIngreso, Me.txtIntereses, Me.txtIngreso, Me.txtCosto, Me.txtVariacion})
        Me.gbResultados.Location = New System.Drawing.Point(8, 56)
        Me.gbResultados.Name = "gbResultados"
        Me.gbResultados.Size = New System.Drawing.Size(488, 136)
        Me.gbResultados.TabIndex = 15
        Me.gbResultados.TabStop = False
        Me.gbResultados.Text = "Determinación del Ingreso y el Costo"
        '
        'lblIntereses
        '
        Me.lblIntereses.Location = New System.Drawing.Point(136, 104)
        Me.lblIntereses.Name = "lblIntereses"
        Me.lblIntereses.Size = New System.Drawing.Size(100, 16)
        Me.lblIntereses.TabIndex = 13
        Me.lblIntereses.Text = "Intereses"
        Me.lblIntereses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblVariacion
        '
        Me.lblVariacion.Location = New System.Drawing.Point(136, 80)
        Me.lblVariacion.Name = "lblVariacion"
        Me.lblVariacion.Size = New System.Drawing.Size(100, 16)
        Me.lblVariacion.TabIndex = 12
        Me.lblVariacion.Text = "Variación"
        Me.lblVariacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCosto
        '
        Me.lblCosto.Location = New System.Drawing.Point(136, 56)
        Me.lblCosto.Name = "lblCosto"
        Me.lblCosto.Size = New System.Drawing.Size(100, 16)
        Me.lblCosto.TabIndex = 8
        Me.lblCosto.Text = "Costo"
        Me.lblCosto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIngreso
        '
        Me.lblIngreso.Location = New System.Drawing.Point(136, 32)
        Me.lblIngreso.Name = "lblIngreso"
        Me.lblIngreso.Size = New System.Drawing.Size(100, 16)
        Me.lblIngreso.TabIndex = 7
        Me.lblIngreso.Text = "Ingreso"
        Me.lblIngreso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtIntereses
        '
        Me.txtIntereses.BackColor = System.Drawing.SystemColors.Control
        Me.txtIntereses.Enabled = False
        Me.txtIntereses.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIntereses.Location = New System.Drawing.Point(240, 102)
        Me.txtIntereses.Name = "txtIntereses"
        Me.txtIntereses.ReadOnly = True
        Me.txtIntereses.Size = New System.Drawing.Size(96, 20)
        Me.txtIntereses.TabIndex = 6
        Me.txtIntereses.Text = ""
        Me.txtIntereses.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIngreso
        '
        Me.txtIngreso.BackColor = System.Drawing.SystemColors.Control
        Me.txtIngreso.Enabled = False
        Me.txtIngreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIngreso.Location = New System.Drawing.Point(240, 30)
        Me.txtIngreso.Name = "txtIngreso"
        Me.txtIngreso.ReadOnly = True
        Me.txtIngreso.Size = New System.Drawing.Size(96, 20)
        Me.txtIngreso.TabIndex = 1
        Me.txtIngreso.Text = ""
        Me.txtIngreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCosto
        '
        Me.txtCosto.BackColor = System.Drawing.SystemColors.Control
        Me.txtCosto.Enabled = False
        Me.txtCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCosto.Location = New System.Drawing.Point(240, 54)
        Me.txtCosto.Name = "txtCosto"
        Me.txtCosto.ReadOnly = True
        Me.txtCosto.Size = New System.Drawing.Size(96, 20)
        Me.txtCosto.TabIndex = 4
        Me.txtCosto.Text = ""
        Me.txtCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtVariacion
        '
        Me.txtVariacion.BackColor = System.Drawing.SystemColors.Control
        Me.txtVariacion.Enabled = False
        Me.txtVariacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVariacion.Location = New System.Drawing.Point(240, 78)
        Me.txtVariacion.Name = "txtVariacion"
        Me.txtVariacion.ReadOnly = True
        Me.txtVariacion.Size = New System.Drawing.Size(96, 20)
        Me.txtVariacion.TabIndex = 3
        Me.txtVariacion.Text = ""
        Me.txtVariacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpCostoIng
        '
        Me.dtpCostoIng.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpCostoIng.Location = New System.Drawing.Point(200, 16)
        Me.dtpCostoIng.Name = "dtpCostoIng"
        Me.dtpCostoIng.Size = New System.Drawing.Size(88, 20)
        Me.dtpCostoIng.TabIndex = 16
        '
        'frmCostoIng
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(504, 206)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnProcesar, Me.lblFechaProceso, Me.gbResultados, Me.dtpCostoIng})
        Me.Name = "frmCostoIng"
        Me.Text = "Ingreso y Costo"
        Me.gbResultados.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cn As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daCostoIng As New SqlDataAdapter(cm1)
        Dim dsAgil As New DataSet()
        Dim drCosto As DataRow
        Dim drCostos As DataRow()

        ' Declaración de variables de datos

        Dim cFecha As String
        Dim nIntereses As Decimal

        btnProcesar.Enabled = False
        dtpCostoIng.Enabled = False

        cFecha = DTOC(dtpCostoIng.Value)

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "CostoIng1"
            .Connection = cn
            .Parameters.Add("@cFeven", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        'Llenar el DataSet a través del DataAdapter, lo cual abre y cierra la conexión

        Try
            daCostoIng.Fill(dsAgil, "CostoIng")
        Catch eException As Exception
            MsgBox(eException.Message, MsgBoxStyle.Critical, eException.Source)
        End Try

        drCosto = dsAgil.Tables("CostoIng").Rows(0)

        'Una vez que tengo el registro necesario, procedo a desplegar los resultados

        txtIngreso.Text = Format(drCosto("Ingreso"), "C")
        txtCosto.Text = Format(drCosto("Costo"), "C")
        txtVariacion.Text = Format(drCosto("Variacion"), "C")
        nIntereses = Round(drCosto("Ingreso") - drCosto("Costo") + drCosto("Variacion"), 2)
        txtIntereses.Text = Format(nIntereses, "C")

        cm1 = Nothing
        cn = Nothing

    End Sub

End Class
