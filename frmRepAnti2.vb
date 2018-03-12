' Este reporte debe considerar los avisos que tengan fecha de vencimiento igual a la fecha de proceso;
' sin embargo, para el reporte que se utiliza en el Comité de Cobranza no deben considerarse como exigibles 
' dichos avisos.

Option Explicit On

Imports System.Data.SqlClient
Imports System.Math
Imports CrystalDecisions.Shared

Public Class frmRepAnti2

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
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnProcesar = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.btnSalir = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnProcesar
        '
        Me.btnProcesar.Location = New System.Drawing.Point(250, 16)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(80, 24)
        Me.btnProcesar.TabIndex = 30
        Me.btnProcesar.Text = "Procesar"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 16)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Fecha de Proceso"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(136, 18)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(88, 20)
        Me.DateTimePicker1.TabIndex = 28
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(8, 56)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1008, 640)
        Me.CrystalReportViewer1.TabIndex = 32
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(356, 16)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(80, 24)
        Me.btnSalir.TabIndex = 33
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'frmRepAnti2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1024, 702)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.btnProcesar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Name = "frmRepAnti2"
        Me.Text = "Reporte de Antigüedad de Saldos en formato contable"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daFacturas As New SqlDataAdapter(cm1)
        Dim dsAgil As New DataSet()
        Dim drFactura As DataRow
        Dim drAnexo As DataRow
        Dim myColArray(1) As DataColumn
        Dim dtAnexos As New DataTable()
        Dim dtReporte As New DataTable("Reporte")
        Dim strInsert As String

        ' Declaración de variables de datos

        Dim cAnexo As String
        Dim cCliente As String
        Dim cFecha As String
        Dim cFeven As String
        Dim cLetra As String
        Dim cNombre As String
        Dim cTipar As String
        Dim cTipo As String
        Dim nAdeudoAnterior As Decimal
        Dim nDia As Byte
        Dim nDiasMoratorios As Decimal
        Dim nDiasVencido As Integer
        Dim nIvaMoratorios As Decimal
        Dim nMoratorios As Decimal
        Dim nPlazo As Byte
        Dim nSaldoFac As Decimal
        Dim nSaldoInsoluto As Decimal
        Dim nSaldoAdeudo As Decimal
        Dim nTasaMoratoria As Decimal

        ' Declaración de variables de Crystal Reports

        Dim cReportTitle As String
        Dim newrptRepAnti2 As New rptRepAnti2()

        cFecha = DTOC(DateTimePicker1.Value)

        ' Ahora creo la tabla Anexos que será la base del reporte

        dtAnexos.Columns.Add("Tipo", Type.GetType("System.String"))
        dtAnexos.Columns.Add("Anexo", Type.GetType("System.String"))
        dtAnexos.Columns.Add("Cliente", Type.GetType("System.String"))
        dtAnexos.Columns.Add("Nombre", Type.GetType("System.String"))
        dtAnexos.Columns.Add("Letra", Type.GetType("System.String"))
        dtAnexos.Columns.Add("Plazo", Type.GetType("System.Decimal"))
        dtAnexos.Columns.Add("Dia", Type.GetType("System.Decimal"))
        dtAnexos.Columns.Add("Saldo", Type.GetType("System.Decimal"))
        dtAnexos.Columns.Add("Col1a29", Type.GetType("System.Decimal"))
        dtAnexos.Columns.Add("Col30a59", Type.GetType("System.Decimal"))
        dtAnexos.Columns.Add("Col60a89", Type.GetType("System.Decimal"))
        dtAnexos.Columns.Add("Col90omas", Type.GetType("System.Decimal"))
        dtAnexos.Columns.Add("Total", Type.GetType("System.Decimal"))
        myColArray(0) = dtAnexos.Columns("Anexo")
        dtAnexos.PrimaryKey = myColArray

        ' Este Stored Procedure trae las facturas vencidas, el pago inicial (sin el 5% Nafin) 
        ' y la opción de compra exigible de los contratos activos o terminados con saldo en rentas

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Repantig1"
            .Connection = cnAgil
            .Parameters.Add("@Fecha", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        ' Llenar el DataSet a través del DataAdapter, lo cual abre y cierra la conexión

        Try
            daFacturas.Fill(dsAgil, "Facturas")
        Catch eException As Exception
            MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")
        End Try

        ' Ahora barro la tabla Facturas para determinar la antiguedad del saldo de cada factura
        ' y posicionarla en el lugar que le corresponda

        For Each drFactura In dsAgil.Tables("Facturas").Rows

            cTipar = drFactura("Tipar")
            If cTipar = "F" Or cTipar = "P" Then
                cTipo = drFactura("Tipo")
                If cTipo = "M" Or cTipo = "E" Then
                    cTipo = "COM"
                Else
                    cTipo = "CON"
                End If
            ElseIf cTipar = "R" Then
                cTipo = "REF"
            End If
            cAnexo = drFactura("Anexo")
            cCliente = drFactura("Cliente")
            cNombre = drFactura("Descr")
            cLetra = drFactura("Letra")
            cFeven = drFactura("Feven")
            nPlazo = drFactura("Plazo")
            nDia = Val(Mid(drFactura("Fvenc"), 7, 2))
            nSaldoInsoluto = drFactura("SaldoInsoluto")
            nSaldoAdeudo = drFactura("Saldot") - drFactura("Capitalot")
            nSaldoFac = drFactura("SaldoFac")
            nDiasVencido = DateDiff(DateInterval.Day, CTOD(cFeven), CTOD(cFecha)) + 1

            ' Debe buscar si ya existe el anexo en la tabla Anexos

            drAnexo = dtAnexos.Rows.Find(cAnexo)

            If drAnexo Is Nothing Then

                ' Si no existe, debe dar de alta un registro en la tabla Anexos

                drAnexo = dtAnexos.NewRow()
                drAnexo("Anexo") = cAnexo
                drAnexo("Cliente") = cCliente
                drAnexo("Nombre") = cNombre
                drAnexo("Letra") = cLetra
                drAnexo("Plazo") = nPlazo
                If nDia > 25 Then
                    nDia = 31
                End If
                drAnexo("Dia") = nDia
                drAnexo("Saldo") = nSaldoInsoluto + nSaldoAdeudo
                drAnexo("Col1a29") = 0
                drAnexo("Col30a59") = 0
                drAnexo("Col60a89") = 0
                drAnexo("Col90omas") = 0
                If nDiasVencido > 89 Then
                    If cTipo = "COM" Then
                        drAnexo("Tipo") = "COMVEN"
                    ElseIf cTipo = "CON" Then
                        drAnexo("Tipo") = "CONVEN"
                    ElseIf cTipo = "REF" Then
                        drAnexo("Tipo") = "REFVEN"
                    End If
                Else
                    drAnexo("Tipo") = cTipo
                End If
                If nDiasVencido > 89 Then
                    drAnexo("Col90omas") = nSaldoFac
                ElseIf nDiasVencido > 59 Then
                    drAnexo("Col60a89") = nSaldoFac
                ElseIf nDiasVencido > 29 Then
                    drAnexo("Col30a59") = nSaldoFac
                ElseIf nDiasVencido > 0 Then
                    drAnexo("Col1a29") = nSaldoFac
                End If
                drAnexo("Total") = nSaldoFac
                dtAnexos.Rows.Add(drAnexo)

            Else

                ' Estos dos campos se actualizan para que al final contengan el dato más reciente

                drAnexo("Letra") = cLetra
                drAnexo("Saldo") = nSaldoInsoluto + nSaldoAdeudo

                If nDiasVencido > 89 Then
                    drAnexo("Col90omas") += nSaldoFac
                    If cTipo = "COM" Then
                        drAnexo("Tipo") = "COMVEN"
                    ElseIf cTipo = "CON" Then
                        drAnexo("Tipo") = "CONVEN"
                    ElseIf cTipo = "REF" Then
                        drAnexo("Tipo") = "REFVEN"
                    End If
                ElseIf nDiasVencido > 59 Then
                    drAnexo("Col60a89") += nSaldoFac
                ElseIf nDiasVencido > 29 Then
                    drAnexo("Col30a59") += nSaldoFac
                ElseIf nDiasVencido > 0 Then
                    drAnexo("Col1a29") += nSaldoFac
                End If
                drAnexo("Total") += nSaldoFac

            End If

        Next

        dsAgil.Tables.Remove("Facturas")
        dsAgil.Tables.Add(dtAnexos)

        ' Descomentar la siguiente línea en caso de que se deseara modificar el reporte rptRepAnti2
        ' dsAgil.WriteXml("C:\Schema23.xml", XmlWriteMode.WriteSchema)
        newrptRepAnti2.SetDataSource(dsAgil)
        cReportTitle = "REPORTE DE ANTIGUEDAD DE SALDOS AL " & Mes(cFecha)
        newrptRepAnti2.SummaryInfo.ReportTitle = cReportTitle
        CrystalReportViewer1.ReportSource = newrptRepAnti2

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class
