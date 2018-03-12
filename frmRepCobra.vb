Option Explicit On 

Imports System.Data.SqlClient

Public Class frmRepcobra

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
    Friend WithEvents btnCobranza As System.Windows.Forms.Button
    Friend WithEvents lblReporte As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnCobranza = New System.Windows.Forms.Button
        Me.lblReporte = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.btnSalir = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnCobranza
        '
        Me.btnCobranza.Location = New System.Drawing.Point(360, 14)
        Me.btnCobranza.Name = "btnCobranza"
        Me.btnCobranza.Size = New System.Drawing.Size(80, 24)
        Me.btnCobranza.TabIndex = 25
        Me.btnCobranza.Text = "Procesar"
        '
        'lblReporte
        '
        Me.lblReporte.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReporte.Location = New System.Drawing.Point(24, 14)
        Me.lblReporte.Name = "lblReporte"
        Me.lblReporte.Size = New System.Drawing.Size(192, 24)
        Me.lblReporte.TabIndex = 24
        Me.lblReporte.Text = "Selecciona la fecha del Reporte"
        Me.lblReporte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(240, 16)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(88, 20)
        Me.DateTimePicker1.TabIndex = 23
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(16, 56)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(976, 624)
        Me.CrystalReportViewer1.TabIndex = 26
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(471, 14)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(80, 24)
        Me.btnSalir.TabIndex = 27
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'frmRepcobra
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1008, 702)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.btnCobranza)
        Me.Controls.Add(Me.lblReporte)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Name = "frmRepcobra"
        Me.Text = "Reporte de Cobranza"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnCobranza_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCobranza.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim daCobranza As New SqlDataAdapter(cm1)
        Dim daImportes As New SqlDataAdapter(cm2)
        Dim dsAgil As New DataSet()
        Dim drAnexo As DataRow
        Dim drTemporal As DataRow
        Dim drImporteDocumento As DataRow
        Dim dtCobranza As New DataTable("Cobranza")
        Dim dtBancos As New DataTable("Bancos")
        Dim myColArray(1) As DataColumn
        Dim myKeySearch(1) As String

        ' Declaración de variables de datos

        Dim cAnexo As String = ""
        Dim cBanco As String = ""
        Dim cDocumento As String = ""
        Dim cFecha As String = ""
        Dim cSerie As String = ""
        Dim nGrupo As Integer
        Dim nImporte As Decimal = 0
        Dim nImporteDocumento As Decimal = 0
        Dim nNumero As Decimal = 0
        Dim Suma01 As Decimal = 0
        Dim Suma02 As Decimal = 0
        Dim Suma03 As Decimal = 0
        Dim Suma04 As Decimal = 0
        Dim Suma05 As Decimal = 0
        Dim Suma06 As Decimal = 0
        Dim Suma07 As Decimal = 0
        Dim Suma08 As Decimal = 0
        Dim Suma09 As Decimal = 0
        Dim Suma10 As Decimal = 0
        Dim SumaTotal As Decimal = 0

        ' Declaración de variables de Crystal Reports

        Dim newrptRepCobra As New rptRepCobra()

        cFecha = DTOC(DateTimePicker1.Value)

        ' Creo una tabla dtCobranza donde almaceno los datos que formarán parte del reporte final

        dtCobranza.Columns.Add("Nombre", Type.GetType("System.String"))
        dtCobranza.Columns.Add("Documento", Type.GetType("System.String"))
        dtCobranza.Columns.Add("Anexo", Type.GetType("System.String"))
        dtCobranza.Columns.Add("Ven", Type.GetType("System.String"))
        dtCobranza.Columns.Add("Concepto", Type.GetType("System.String"))
        dtCobranza.Columns.Add("Cheque", Type.GetType("System.String"))
        dtCobranza.Columns.Add("Depositado en", Type.GetType("System.String"))
        dtCobranza.Columns.Add("Importe", Type.GetType("System.Decimal"))
        dtCobranza.Columns.Add("Orden", Type.GetType("System.Decimal"))

        'Creo una Tabla dtBancos para almacenar los datos acumulados de Bancos

        dtBancos.Columns.Add("Banco01", Type.GetType("System.String"))
        dtBancos.Columns.Add("Suma01", Type.GetType("System.Decimal"))
        dtBancos.Columns.Add("Banco02", Type.GetType("System.String"))
        dtBancos.Columns.Add("Suma02", Type.GetType("System.Decimal"))
        dtBancos.Columns.Add("Banco03", Type.GetType("System.String"))
        dtBancos.Columns.Add("Suma03", Type.GetType("System.Decimal"))
        dtBancos.Columns.Add("Banco04", Type.GetType("System.String"))
        dtBancos.Columns.Add("Suma04", Type.GetType("System.Decimal"))
        dtBancos.Columns.Add("Banco05", Type.GetType("System.String"))
        dtBancos.Columns.Add("Suma05", Type.GetType("System.Decimal"))
        dtBancos.Columns.Add("Banco06", Type.GetType("System.String"))
        dtBancos.Columns.Add("Suma06", Type.GetType("System.Decimal"))
        dtBancos.Columns.Add("Banco07", Type.GetType("System.String"))
        dtBancos.Columns.Add("Suma07", Type.GetType("System.Decimal"))
        dtBancos.Columns.Add("Banco08", Type.GetType("System.String"))
        dtBancos.Columns.Add("Suma08", Type.GetType("System.Decimal"))
        dtBancos.Columns.Add("Banco09", Type.GetType("System.String"))
        dtBancos.Columns.Add("Suma09", Type.GetType("System.Decimal"))
        dtBancos.Columns.Add("Banco10", Type.GetType("System.String"))
        dtBancos.Columns.Add("Suma10", Type.GetType("System.Decimal"))
        dtBancos.Columns.Add("GranTotal", Type.GetType("System.Decimal"))

        ' Con este Stored Procedure obtengo todos los movimientos de la cobranza del 
        ' dia que se está solicitando.

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Historia3"
            .Connection = cnAgil
            .Parameters.Add("@Fecha", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        With cm2
            .CommandType = CommandType.Text
            .CommandText = "SELECT Numero, Anexo, SUM(Importe) AS ImporteDocumento FROM Historia " & _
                           "WHERE Fecha = '" & cFecha & "' " & _
                           "GROUP BY Numero, Anexo " & _
                           "ORDER BY Numero, Anexo"
            .Connection = cnAgil
        End With

        ' Llenar el DataSet lo cual abre y cierra la conexión

        daCobranza.Fill(dsAgil, "Cobranza")
        daImportes.Fill(dsAgil, "Importes")

        ' Tengo que definir una LLAVE PRIMARIA COMPUESTA para la tabla Importes para poder buscar el importe de un documento en específico

        myColArray(0) = dsAgil.Tables("Importes").Columns("Numero")
        myColArray(1) = dsAgil.Tables("Importes").Columns("Anexo")

        dsAgil.Tables("Importes").PrimaryKey = myColArray

        nGrupo = 0
        Suma01 = 0
        Suma02 = 0
        Suma03 = 0
        Suma04 = 0
        Suma05 = 0
        Suma06 = 0
        Suma07 = 0
        Suma08 = 0
        Suma09 = 0
        Suma10 = 0
        SumaTotal = 0

        For Each drAnexo In dsAgil.Tables("Cobranza").Rows

            drTemporal = dtCobranza.NewRow()

            cDocumento = drAnexo("Documento")
            cSerie = Trim(drAnexo("Serie"))
            nNumero = drAnexo("Numero")
            nImporte = drAnexo("Importe")
            cBanco = drAnexo("Banco")

            If nGrupo = 0 Then
                nGrupo = 1
            ElseIf Mid(drAnexo("Anexo"), 1, 5) <> Mid(cAnexo, 1, 5) Then
                nGrupo += 1
            End If

            drTemporal("Nombre") = drAnexo("Descr")
            drTemporal("Anexo") = Mid(drAnexo("Anexo"), 1, 5) & "/" & Mid(drAnexo("Anexo"), 6, 4)
            drTemporal("Ven") = drAnexo("Letra")
            drTemporal("Concepto") = drAnexo("Observa1")
            drTemporal("Cheque") = drAnexo("Cheque")
            drTemporal("Depositado en") = drAnexo("DescBanco")
            drTemporal("Importe") = nImporte
            drTemporal("Orden") = nGrupo

            Select Case cBanco
                Case "01"
                    Suma01 = Suma01 + nImporte
                Case "02"
                    Suma02 = Suma02 + nImporte
                Case "03"
                    Suma03 = Suma03 + nImporte
                Case "04"
                    Suma04 = Suma04 + nImporte
                Case "05"
                    Suma05 = Suma05 + nImporte
                Case "06"
                    Suma06 = Suma06 + nImporte
                Case "07"
                    Suma07 = Suma07 + nImporte
                Case "08"
                    Suma08 = Suma08 + nImporte
                Case "09"
                    Suma09 = Suma09 + nImporte
                Case "10"
                    Suma10 = Suma10 + nImporte
            End Select

            myKeySearch(0) = nNumero
            myKeySearch(1) = drAnexo("Anexo")
            drImporteDocumento = dsAgil.Tables("Importes").Rows.Find(myKeySearch)

            nImporteDocumento = drImporteDocumento("ImporteDocumento")

            Select Case cDocumento
                Case 1
                    drTemporal("Documento") = "Nota de Cargo " & Str(nNumero) & " por $" & Format(nImporteDocumento, "##,##0.00")
                Case 2
                    drTemporal("Documento") = "Recibo " & Str(nNumero) & " por $" & Format(nImporteDocumento, "##,##0.00")
                Case 4
                    drTemporal("Documento") = "Cargo Interno " & Str(nNumero) & " por $" & Format(nImporteDocumento, "##,##0.00")
                Case 5
                    drTemporal("Documento") = "Abono Interno " & Str(nNumero) & " por $" & Format(nImporteDocumento, "##,##0.00")
                Case 6
                    drTemporal("Documento") = "Factura " & cSerie & Trim(Str(nNumero)) & " por $" & Format(nImporteDocumento, "##,##0.00")
                Case 7
                    drTemporal("Documento") = "Activo Fijo " & Str(nNumero) & " por $" & Format(nImporteDocumento, "##,##0.00")
            End Select

            dtCobranza.Rows.Add(drTemporal)

            cAnexo = drAnexo("Anexo")

        Next

        ' Tengo que barrer la tabla dtCobranza e ir grabando el importe de cada documento

        drAnexo = dtBancos.NewRow()
        drAnexo("Banco01") = "BANCO BILBAO VIZCAYA"
        drAnexo("Suma01") = Suma01
        drAnexo("Banco02") = "BANCOMER"
        drAnexo("Suma02") = Suma02
        drAnexo("Banco03") = "HSBC"
        drAnexo("Suma03") = Suma03
        drAnexo("Banco04") = "BANAMEX"
        drAnexo("Suma04") = Suma04
        drAnexo("Banco05") = "BANCOMER-NAFINSA"
        drAnexo("Suma05") = Suma05
        drAnexo("Banco06") = "SANTANDER"
        drAnexo("Suma06") = Suma06
        drAnexo("Banco07") = "BAJIO"
        drAnexo("Suma07") = Suma07
        drAnexo("Banco08") = "INVEX"
        drAnexo("Suma08") = Suma08
        drAnexo("Banco09") = "TRASPASOS"
        drAnexo("Suma09") = Suma09
        drAnexo("Banco10") = "BANORTE"
        drAnexo("Suma10") = Suma10
        drAnexo("GranTotal") = Suma01 + Suma02 + Suma03 + Suma04 + Suma05 + Suma06 + Suma07 + Suma08 + Suma09 + Suma10
        dtBancos.Rows.Add(drAnexo)

        dsAgil.Tables.Remove("Cobranza")
        dsAgil.Tables.Add(dtCobranza)
        dsAgil.Tables.Add(dtBancos)

        ' Descomentar la siguiente línea en caso de que deseara modificarse el reporte rptRepCobra
        ' dsAgil.WriteXml("C:\Schema16.xml", XmlWriteMode.WriteSchema)

        newrptRepCobra.SetDataSource(dsAgil)
        newrptRepCobra.SummaryInfo.ReportComments = "REPORTE DE COBRANZA DEL  " & (DateTimePicker1.Value).ToShortDateString
        newrptRepCobra.SummaryInfo.ReportTitle = "RESUMEN DE COBRANZA DEL  " & (DateTimePicker1.Value).ToShortDateString
        CrystalReportViewer1.ReportSource = newrptRepCobra

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class
