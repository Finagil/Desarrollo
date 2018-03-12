Option Explicit On

Imports System.Data.SqlClient
Imports System.Math

Public Class frmReferencia

    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal cAnexo As String, ByVal cCliente As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Text = "Referencia del Contrato " & cAnexo
        txtAnexo.Text = Mid(cAnexo, 1, 5) & Mid(cAnexo, 7, 4)
        txtReferencia.Text = cCliente

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
    Friend WithEvents txtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents txtAnexo As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtReferencia = New System.Windows.Forms.TextBox
        Me.txtAnexo = New System.Windows.Forms.TextBox
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'txtReferencia
        '
        Me.txtReferencia.Location = New System.Drawing.Point(426, 22)
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.Size = New System.Drawing.Size(12, 20)
        Me.txtReferencia.TabIndex = 3
        Me.txtReferencia.Visible = False
        '
        'txtAnexo
        '
        Me.txtAnexo.Location = New System.Drawing.Point(392, 22)
        Me.txtAnexo.Name = "txtAnexo"
        Me.txtAnexo.Size = New System.Drawing.Size(12, 20)
        Me.txtAnexo.TabIndex = 4
        Me.txtAnexo.Visible = False
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(8, 19)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.ShowCloseButton = False
        Me.CrystalReportViewer1.ShowGotoPageButton = False
        Me.CrystalReportViewer1.ShowGroupTreeButton = False
        Me.CrystalReportViewer1.ShowRefreshButton = False
        Me.CrystalReportViewer1.ShowTextSearchButton = False
        Me.CrystalReportViewer1.ShowZoomButton = False
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1008, 675)
        Me.CrystalReportViewer1.TabIndex = 5
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'frmReferencia
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1024, 702)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.txtAnexo)
        Me.Controls.Add(Me.txtReferencia)
        Me.Name = "frmReferencia"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub frmReferencia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim daAnexos As New SqlDataAdapter(cm1)
        Dim daCliente As New SqlDataAdapter(cm2)
        Dim dsAgil As New DataSet()
        Dim drAnexo As DataRow
        Dim drCliente As DataRow
        Dim drRepor As DataRow
        Dim dtReporte As New DataTable("Referencias")

        ' Declaración de variables de datos

        Dim nResultado As Decimal
        Dim nSumaBanamex As Decimal
        Dim nSumaBancomer As Decimal

        Dim cRefBanamex As String
        Dim cRefBanorte As String
        Dim cRefBancomer As String
        Dim cRefHSBC As String
        Dim cAnexo As String
        Dim cCliente As String
        Dim cCusnam As String
        Dim cReportTitle As String
        Dim cStatus As String
        Dim cFlcan As String
        Dim cTipo As String
        Dim newrptReferencia As New rptReferencia

        ' Las siguientes dos variables se inicializan a partir de dos campos de texto que están ocultos en la forma

       cCliente = txtReferencia.Text

        ' El siguiente Stored Procedure trae todos los Contratos del Cliente incluyendo los de AVIO seleccionado
        
        With cm1
            .CommandType = CommandType.Text
            .CommandText = "SELECT Anexo, Flcan, Tipar FROM Anexos WHERE Cliente = '" & cCliente & "' " & _
                           "UNION ALL " & _
                           "SELECT Anexo, Flcan, Tipar FROM Avios WHERE Cliente = '" & cCliente & "' " & _
                           "ORDER BY Anexo"
            .Connection = cnAgil
        End With
      
        With cm2
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DatosClie1"
            .Connection = cnAgil
            .Parameters.Add("@Cliente", SqlDbType.NVarChar)
            .Parameters(0).Value = cCliente
        End With

        ' Llenar el DataSet lo cual abre y cierra la conexión

        daAnexos.Fill(dsAgil, "Anexos")
        daCliente.Fill(dsAgil, "Cliente")

        drCliente = dsAgil.Tables("Cliente").Rows(0)
        cCusnam = Trim(drCliente("Descr"))

        ' Ahora creo la tabla que guardará las referencias de cada uno de los contratos
        ' activos que se tengan de este cliente.

        dtReporte.Columns.Add("Anexo", Type.GetType("System.String"))
        dtReporte.Columns.Add("Banamex", Type.GetType("System.String"))
        dtReporte.Columns.Add("Bancomer", Type.GetType("System.String"))
        dtReporte.Columns.Add("Banorte", Type.GetType("System.String"))

        For Each drAnexo In dsAgil.Tables("Anexos").Rows

            cAnexo = drAnexo("Anexo")
            cFlcan = drAnexo("Flcan")
            cTipo = drAnexo("Tipar")

            Select Case cFlcan
                Case "A"
                    cStatus = "ACTIVO"
                Case "B"
                    cStatus = "BAJA"
                Case "C"
                    cStatus = "CANCELADO"
                Case "S"
                    cStatus = "SUSPENSO"
                Case "T"
                    cStatus = "TERMINADO"
            End Select

            If cTipo = "H" Then
                cStatus = cStatus & "_AVIO"
            End If

            cRefBanamex = Mid(cAnexo, 1, 5) + Mid(cAnexo, 7, 3)
            cRefBancomer = Mid(cAnexo, 2, 4) + Mid(cAnexo, 7, 3)
            cRefBanorte = Mid(cAnexo, 2, 4) + Mid(cAnexo, 7, 3)

            nSumaBanamex = 1235
            nSumaBanamex += Val(Mid(cRefBanamex, 1, 1)) * 11
            nSumaBanamex += Val(Mid(cRefBanamex, 2, 1)) * 13
            nSumaBanamex += Val(Mid(cRefBanamex, 3, 1)) * 17
            nSumaBanamex += Val(Mid(cRefBanamex, 4, 1)) * 19
            nSumaBanamex += Val(Mid(cRefBanamex, 5, 1)) * 23
            nSumaBanamex += Val(Mid(cRefBanamex, 6, 1)) * 29
            nSumaBanamex += Val(Mid(cRefBanamex, 7, 1)) * 31
            nSumaBanamex += Val(Mid(cRefBanamex, 8, 1)) * 37

            nResultado = 99 - (nSumaBanamex Mod 97)
            If nResultado > 9 Then
                cRefBanamex += "-" + nResultado.ToString
            Else
                cRefBanamex += "-" + "0" + nResultado.ToString
            End If

            nSumaBancomer = 0
            nResultado = Val(Mid(cRefBancomer, 1, 1)) * 2
            If nResultado > 9 Then
                nSumaBancomer += Val(Mid(nResultado.ToString, 1, 1)) + Val(Mid(nResultado.ToString, 2, 1))
            Else
                nSumaBancomer += nResultado
            End If
            nResultado = Val(Mid(cRefBancomer, 2, 1)) * 1
            If nResultado > 9 Then
                nSumaBancomer += Val(Mid(nResultado.ToString, 1, 1)) + Val(Mid(nResultado.ToString, 2, 1))
            Else
                nSumaBancomer += nResultado
            End If
            nResultado = Val(Mid(cRefBancomer, 3, 1)) * 2
            If nResultado > 9 Then
                nSumaBancomer += Val(Mid(nResultado.ToString, 1, 1)) + Val(Mid(nResultado.ToString, 2, 1))
            Else
                nSumaBancomer += nResultado
            End If
            nResultado = Val(Mid(cRefBancomer, 4, 1)) * 1
            If nResultado > 9 Then
                nSumaBancomer += Val(Mid(nResultado.ToString, 1, 1)) + Val(Mid(nResultado.ToString, 2, 1))
            Else
                nSumaBancomer += nResultado
            End If
            nResultado = Val(Mid(cRefBancomer, 5, 1)) * 2
            If nResultado > 9 Then
                nSumaBancomer += Val(Mid(nResultado.ToString, 1, 1)) + Val(Mid(nResultado.ToString, 2, 1))
            Else
                nSumaBancomer += nResultado
            End If
            nResultado = Val(Mid(cRefBancomer, 6, 1)) * 1
            If nResultado > 9 Then
                nSumaBancomer += Val(Mid(nResultado.ToString, 1, 1)) + Val(Mid(nResultado.ToString, 2, 1))
            Else
                nSumaBancomer += nResultado
            End If
            nResultado = Val(Mid(cRefBancomer, 7, 1)) * 2
            If nResultado > 9 Then
                nSumaBancomer += Val(Mid(nResultado.ToString, 1, 1)) + Val(Mid(nResultado.ToString, 2, 1))
            Else
                nSumaBancomer += nResultado
            End If

            If nSumaBancomer > 60 Then
                nResultado = 70 - nSumaBancomer
            ElseIf nSumaBancomer > 50 Then
                nResultado = 60 - nSumaBancomer
            ElseIf nSumaBancomer > 40 Then
                nResultado = 50 - nSumaBancomer
            ElseIf nSumaBancomer > 30 Then
                nResultado = 40 - nSumaBancomer
            ElseIf nSumaBancomer > 20 Then
                nResultado = 30 - nSumaBancomer
            ElseIf nSumaBancomer > 10 Then
                nResultado = 20 - nSumaBancomer
            ElseIf nSumaBancomer > 0 Then
                nResultado = 10 - nSumaBancomer
            Else
                nResultado = 0
            End If

            cRefBancomer += "-" + nResultado.ToString
            cRefBanorte = cRefBancomer

            drRepor = dtReporte.NewRow()
            drRepor("Anexo") = drAnexo("Anexo") & cStatus
            drRepor("Banamex") = cRefBanamex
            drRepor("Bancomer") = cRefBancomer
            drRepor("Banorte") = cRefBanorte
            dtReporte.Rows.Add(drRepor)

        Next

        dsAgil.Tables.Remove("Anexos")
        dsAgil.Tables.Add(dtReporte)

        ' Descomentar la siguiente línea en caso de que se deseara modificar el reporte rptReferencia
        ' dsAgil.WriteXml("C:\Schema40.xml", XmlWriteMode.WriteSchema)

        newrptReferencia.SetDataSource(dsAgil)

        cReportTitle = "CLIENTE : " & Trim(cCusnam)
        newrptReferencia.SummaryInfo.ReportTitle = cReportTitle
        CrystalReportViewer1.ReportSource = newrptReferencia

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()

    End Sub

End Class
