Option Explicit On

Imports System.Data.SqlClient
Imports System.Math
Imports Microsoft.VisualBasic.Financial
Imports System.IO
Imports Word = Microsoft.Office.Interop.Word
Imports Microsoft.Office.Interop

' Esta forma recibe como parámetro el número de contrato y lo primero que tiene
' que revisar es el estatus del contrato

Public Class frmActiAnex

    Inherits System.Windows.Forms.Form

    ' Declaración de variables de alcance privado
   
    Dim cAbcapt As String
    Dim cAval As String = ""
    Dim cAval1 As String = ""
    Dim cAnexo As String
    Dim cAval2 As String = ""
    Dim cAval3 As String = ""
    Dim cAval4 As String = ""
    Dim cAvales As String = ""
    Dim cAvalg1 As String = ""
    Dim cAvalg2 As String = ""
    Dim cAvalg3 As String = ""
    Dim cAvalg4 As String = ""
    Dim cBienes As String = ""
    Dim cBienes2 As String = ""
    Dim cCalle As String
    Dim cCliente As String = ""
    Dim cCoac As String = ""
    Dim cCoac2 As String = ""
    Dim cColonia As String
    Dim cCopos As String
    Dim cContrato As String = ""
    Dim cCusnam As String = ""
    Dim cDato10 As String = ""
    Dim cDato7 As String = ""
    Dim cDato8 As String = ""
    Dim cDato9 As String = ""
    Dim cDelegacion As String
    Dim cDescDepGar As String = ""
    Dim cDescFrecuencia As String = ""
    Dim cDescPI As String = ""
    Dim cDescPrenda As String = ""
    Dim cDescPromotor As String = ""
    Dim cDescr As String = ""
    Dim cDescRecurso As String = ""
    Dim cDescTasa As String = ""
    Dim cDescTipta As String = ""
    Dim cDetalle As String = ""
    Dim cDiaPago As String = ""
    Dim cEncabezado As String = ""
    Dim cEstado As String
    Dim cFactura As String = ""
    Dim cFax As String = ""
    Dim cFeaut As String = ""
    Dim cFechacon As String = ""
    Dim cFecre As String = ""
    Dim cFevent As String
    Dim cFevig As String = ""
    Dim cFirmaAval1 As String = ""
    Dim cFirmaAval2 As String = ""
    Dim cFirmaAval3 As String = ""
    Dim cFirmaAval4 As String = ""
    Dim cFirmaTestigo1 As String = ""
    Dim cFirmaTestigo2 As String = ""
    Dim cFirmaCte As String = ""
    Dim cFlcan As String = ""
    Dim cFondeo As String
    Dim cForca As String = ""
    Dim cFvenc As String = ""
    Dim cGeneAva1 As String = ""
    Dim cGeneAva2 As String = ""
    Dim cGeneClie As String
    Dim cGenecoac As String = ""
    Dim cGeneObli As String = ""
    Dim cGenerav1 As String = ""
    Dim cGenerav2 As String = ""
    Dim cGenercoa As String = ""
    Dim cGenerep2 As String
    Dim cGenerepr As String
    Dim cGenerObl As String = ""
    Dim cImporte As String
    Dim cImpPI As String = ""
    Dim cImpProv As String = ""
    Dim cIntert As String
    Dim cIvaCapt As String
    Dim cIvat As String
    Dim cLetra As String = ""
    Dim cLetrat As String
    Dim cLugar As String = ""
    Dim cModelo As String = ""
    Dim cMotor As String = ""
    Dim cNomAval1 As String = ""
    Dim cNomAval2 As String = ""
    Dim cNomcoac As String = ""
    Dim cNomObli As String = ""
    Dim cNomrava1 As String = ""
    Dim cNomrava2 As String = ""
    Dim cNomrcoac As String = ""
    Dim cNomrObli As String = ""
    Dim cNotario As String = ""
    Dim cObi As String = ""
    Dim cObSol As String = ""
    Dim cObSol1 As String = ""
    Dim cPagomen As String = ""
    Dim cBonifica As String = ""
    Dim cPersonaAut As String = ""
    Dim cPodercoa As String = ""
    Dim cPoderep2 As String
    Dim cPoderepr As String
    Dim cPoderObl As String = ""
    Dim cPrenda As String = ""
    Dim cProducto As String = ""
    Dim cPromo As String = ""
    Dim cProveedor As String = ""
    Dim cProveedos As String = ""
    Dim cRefCliente As String = ""
    Dim cRefProdgral As String = ""
    Dim cRefProducto As String = ""
    Dim cRenta As String
    Dim cRepresentante As String = ""
    Dim cRepresentante2 As String = ""
    Dim cRfc As String
    Dim cSaldot As String
    Dim cSerie As String = ""
    Dim cSucursal As String
    Dim cTelefono As String = ""
    Dim cTitulo1 As String = ""
    Dim cTermino As String = ""
    Dim cTexto As String = ""
    Dim cTipar As String = ""
    Dim cTipAval1 As String = ""
    Dim cTipAval2 As String = ""
    Dim cTipcoac As String = ""
    Dim cTipo As String = ""
    Dim cTipoObli As String = ""
    Dim cTippe As String = ""
    Dim cTipta As String
    Dim cUnidadEsp As String = ""
    Dim cVence As String = ""
    Dim cFecha1 As String
    Dim cCobert As String
    Dim cTotg As String
    Dim cEjecu As String = ""
    Dim cParrafoInteres As String = ""
    Dim cAplicaCobertura As String = ""
    Dim cPersFirman
    Dim dTermino As Date

    Dim IvaRD As Decimal
    Dim nAbono As Decimal
    Dim nAmorin As Decimal
    Dim nComis As Decimal
    Dim nIvaComis As Decimal
    Dim nDepg As Decimal
    Dim nDepNafin As Decimal
    Dim nDifer As Decimal
    Dim nFactor As Decimal
    Dim nGastos As Decimal
    Dim nImpEq As Decimal
    Dim nImporte As Decimal
    Dim nImpRD As Decimal
    Dim nInteres As Decimal
    Dim nIVA As Decimal
    Dim nRtas As Decimal
    Dim nIvaAmorin As Decimal
    Dim nIvaCapital As Decimal
    Dim nIvaDepg As Decimal
    Dim nIvaEq As Decimal
    Dim nIvaGastos As Decimal
    Dim nIvard As Decimal
    Dim nIvaRtaD As Decimal
    Dim nIvaTabla As Decimal
    Dim nLinau As Decimal
    Dim nMensu As Decimal
    Dim nMtoFin As Decimal
    Dim nNafin As Decimal
    Dim nOpcion As Decimal
    Dim nPagosi As Decimal
    Dim nPiso As Decimal
    Dim nPlazo As Integer
    Dim nPorop As Decimal
    Dim nRenta As Decimal
    Dim nRentasD As Decimal
    Dim nRta As Decimal
    Dim nSaldo As Decimal
    Dim nSaldoAct As Decimal
    Dim nSaldoRiesgo As Decimal
    Dim nTaspen As Decimal
    Dim nTasas As Decimal
    Dim nTasmor As Decimal
    Dim nTecho As Decimal
    Dim nTotal As Decimal
    Dim nTotal2 As Decimal
    Dim nDerechos As Decimal
    Dim nCAT As Decimal
    Dim nCobertura As Decimal
    Dim nTotalCobert As Decimal
    Dim nPorco As Decimal
    Dim nPorInt As Decimal
    Dim nServicio As Decimal
    Dim nIVAServicio As Decimal
    Dim nAmort As Integer


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
    Friend WithEvents txtAnexo As System.Windows.Forms.TextBox
    Friend WithEvents txtCusnam As System.Windows.Forms.TextBox
    Friend WithEvents btnContrato As System.Windows.Forms.Button
    Friend WithEvents txtPrenda As System.Windows.Forms.TextBox
    Friend WithEvents btnPagare As System.Windows.Forms.Button
    Friend WithEvents btnHoja As System.Windows.Forms.Button
    Friend WithEvents btnActivar As System.Windows.Forms.Button
    Friend WithEvents btnValida As System.Windows.Forms.Button
    Friend WithEvents cReportTitle As System.Windows.Forms.TextBox
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnAnexoA As System.Windows.Forms.Button
    Friend WithEvents btnAnexoB As System.Windows.Forms.Button
    Friend WithEvents btnAnexoC As System.Windows.Forms.Button
    Friend WithEvents btnRatif As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtAnexo = New System.Windows.Forms.TextBox
        Me.txtCusnam = New System.Windows.Forms.TextBox
        Me.btnContrato = New System.Windows.Forms.Button
        Me.btnAnexoA = New System.Windows.Forms.Button
        Me.btnPagare = New System.Windows.Forms.Button
        Me.txtPrenda = New System.Windows.Forms.TextBox
        Me.btnHoja = New System.Windows.Forms.Button
        Me.btnActivar = New System.Windows.Forms.Button
        Me.btnValida = New System.Windows.Forms.Button
        Me.cReportTitle = New System.Windows.Forms.TextBox
        Me.btnSalir = New System.Windows.Forms.Button
        Me.btnAnexoB = New System.Windows.Forms.Button
        Me.btnAnexoC = New System.Windows.Forms.Button
        Me.btnRatif = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txtAnexo
        '
        Me.txtAnexo.Enabled = False
        Me.txtAnexo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnexo.Location = New System.Drawing.Point(32, 24)
        Me.txtAnexo.Name = "txtAnexo"
        Me.txtAnexo.Size = New System.Drawing.Size(72, 21)
        Me.txtAnexo.TabIndex = 0
        '
        'txtCusnam
        '
        Me.txtCusnam.Enabled = False
        Me.txtCusnam.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCusnam.Location = New System.Drawing.Point(120, 24)
        Me.txtCusnam.Name = "txtCusnam"
        Me.txtCusnam.Size = New System.Drawing.Size(504, 21)
        Me.txtCusnam.TabIndex = 1
        '
        'btnContrato
        '
        Me.btnContrato.Location = New System.Drawing.Point(376, 72)
        Me.btnContrato.Name = "btnContrato"
        Me.btnContrato.Size = New System.Drawing.Size(70, 32)
        Me.btnContrato.TabIndex = 2
        Me.btnContrato.Text = "Contrato"
        '
        'btnAnexoA
        '
        Me.btnAnexoA.Location = New System.Drawing.Point(464, 72)
        Me.btnAnexoA.Name = "btnAnexoA"
        Me.btnAnexoA.Size = New System.Drawing.Size(70, 32)
        Me.btnAnexoA.TabIndex = 3
        Me.btnAnexoA.Text = "Anexo A"
        '
        'btnPagare
        '
        Me.btnPagare.Location = New System.Drawing.Point(288, 72)
        Me.btnPagare.Name = "btnPagare"
        Me.btnPagare.Size = New System.Drawing.Size(70, 32)
        Me.btnPagare.TabIndex = 4
        Me.btnPagare.Text = "Pagaré"
        '
        'txtPrenda
        '
        Me.txtPrenda.Location = New System.Drawing.Point(672, 24)
        Me.txtPrenda.Name = "txtPrenda"
        Me.txtPrenda.Size = New System.Drawing.Size(16, 20)
        Me.txtPrenda.TabIndex = 6
        Me.txtPrenda.Visible = False
        '
        'btnHoja
        '
        Me.btnHoja.Location = New System.Drawing.Point(200, 72)
        Me.btnHoja.Name = "btnHoja"
        Me.btnHoja.Size = New System.Drawing.Size(70, 32)
        Me.btnHoja.TabIndex = 7
        Me.btnHoja.Text = "Hoja"
        '
        'btnActivar
        '
        Me.btnActivar.Location = New System.Drawing.Point(24, 72)
        Me.btnActivar.Name = "btnActivar"
        Me.btnActivar.Size = New System.Drawing.Size(70, 32)
        Me.btnActivar.TabIndex = 8
        Me.btnActivar.Text = "Activar"
        '
        'btnValida
        '
        Me.btnValida.Location = New System.Drawing.Point(112, 72)
        Me.btnValida.Name = "btnValida"
        Me.btnValida.Size = New System.Drawing.Size(70, 32)
        Me.btnValida.TabIndex = 9
        Me.btnValida.Text = "Valida"
        '
        'cReportTitle
        '
        Me.cReportTitle.Location = New System.Drawing.Point(696, 24)
        Me.cReportTitle.Name = "cReportTitle"
        Me.cReportTitle.Size = New System.Drawing.Size(16, 20)
        Me.cReportTitle.TabIndex = 11
        Me.cReportTitle.Visible = False
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(815, 72)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(70, 32)
        Me.btnSalir.TabIndex = 12
        Me.btnSalir.Text = "Salir"
        '
        'btnAnexoB
        '
        Me.btnAnexoB.Location = New System.Drawing.Point(552, 72)
        Me.btnAnexoB.Name = "btnAnexoB"
        Me.btnAnexoB.Size = New System.Drawing.Size(70, 32)
        Me.btnAnexoB.TabIndex = 13
        Me.btnAnexoB.Text = "Anexo B"
        '
        'btnAnexoC
        '
        Me.btnAnexoC.Location = New System.Drawing.Point(640, 72)
        Me.btnAnexoC.Name = "btnAnexoC"
        Me.btnAnexoC.Size = New System.Drawing.Size(70, 32)
        Me.btnAnexoC.TabIndex = 14
        Me.btnAnexoC.Text = "Anexo C"
        '
        'btnRatif
        '
        Me.btnRatif.Location = New System.Drawing.Point(728, 72)
        Me.btnRatif.Name = "btnRatif"
        Me.btnRatif.Size = New System.Drawing.Size(72, 32)
        Me.btnRatif.TabIndex = 15
        Me.btnRatif.Text = "Ratificación"
        '
        'frmActiAnex
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(893, 686)
        Me.Controls.Add(Me.btnRatif)
        Me.Controls.Add(Me.btnAnexoC)
        Me.Controls.Add(Me.btnAnexoB)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.cReportTitle)
        Me.Controls.Add(Me.btnValida)
        Me.Controls.Add(Me.btnActivar)
        Me.Controls.Add(Me.btnHoja)
        Me.Controls.Add(Me.txtPrenda)
        Me.Controls.Add(Me.btnPagare)
        Me.Controls.Add(Me.btnAnexoA)
        Me.Controls.Add(Me.btnContrato)
        Me.Controls.Add(Me.txtCusnam)
        Me.Controls.Add(Me.txtAnexo)
        Me.Name = "frmActiAnex"
        Me.Text = "Activación de Anexos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub frmActiAnex_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TraeDatos()
    End Sub

    Private Sub btnActivar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActivar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim daBienes As New SqlDataAdapter(cm1)
        Dim daPrendas As New SqlDataAdapter(cm2)
        Dim dsAgil As New DataSet()
        Dim strUpdate As String

        ' Declaración de variables de datos

        Dim lActivar As Boolean
        Dim lActivo As Boolean
        Dim lPrenda As Boolean
        Dim nSuma As Decimal

        cContrato = Mid(txtAnexo.Text, 1, 5) & Mid(txtAnexo.Text, 7, 4)

        lActivar = False
        lActivo = False
        lPrenda = False

        ' Este Stored Procedure trae los datos del equipo financiado

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DatosEquipo1"
            .Connection = cnAgil
            .Parameters.Add("@Anexo", SqlDbType.NVarChar)
            .Parameters(0).Value = cContrato
        End With

        ' Este Stored Procedure trae los datos de la garantía prendaria

        With cm2
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DamePrenda1"
            .Connection = cnAgil
            .Parameters.Add("@Anexo", SqlDbType.NVarChar)
            .Parameters(0).Value = cContrato
        End With

        Try

            daBienes.Fill(dsAgil, "ActiFijo")
            daPrendas.Fill(dsAgil, "Prendas")

            nSuma = 0

            If dsAgil.Tables("ActiFijo").Rows.Count > 0 Then
                'If nImpAnexo + nIvaAnexo = nSuma Then
                '    lActivar = True
                '    lActivo = True
                'End If
            End If
            If cPrenda = "S" Then
                If dsAgil.Tables("Prendas").Rows.Count > 0 Then
                    lActivar = True
                    lPrenda = True
                End If
            Else
                lActivar = True
                lPrenda = True
            End If

            If lActivar = True Then

                ' Actualización de la tabla Anexos para marcar el contrato como Activo

                cnAgil.Open()
                strUpdate = "UPDATE Anexos SET Flcan = 'A'" & " WHERE Anexo = '" & cContrato & "'"
                cm1 = New SqlCommand(strUpdate, cnAgil)
                cm1.ExecuteNonQuery()
                cnAgil.Close()

                MsgBox("El contrato está Activado", MsgBoxStyle.Information, "Mensaje")

            Else

                ' Revisar porqué razón no se puede activar

                If lActivo = False And lPrenda = True Then

                    ' Falta capturar los datos del bien y de la garantía prendaria

                    MsgBox("Falta capturar los datos del bien y de la garantía prendaria", MsgBoxStyle.Critical, "Mensaje de Error")

                ElseIf lActivo = False Then

                    MsgBox("Falta capturar los datos del bien o el importe de los bienes es incorrecto", MsgBoxStyle.Critical, "Mensaje de Error")

                ElseIf lPrenda = False Then

                    MsgBox("Falta capturar los datos de la garantía prendaria", MsgBoxStyle.Critical, "Mensaje de Error")

                End If

            End If

        Catch eException As Exception
            MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")
        End Try
        btnActivar.Enabled = False
        btnValida.Enabled = True
        btnHoja.Enabled = True
        btnPagare.Enabled = True
        btnContrato.Enabled = True

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()

        TraeDatos()

    End Sub

    Private Sub btnValida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValida.Click

        Dim oWord As New Word.Application
        Dim oWordDoc As Microsoft.Office.Interop.Word.Document
        Dim dsTemporal As New DataSet()
        Dim oNulo As Object = System.Reflection.Missing.Value
        Dim oRuta As New Object
        Dim myMField As Microsoft.Office.Interop.Word.Field
        Dim rFieldCode As Microsoft.Office.Interop.Word.Range
        Dim cFieldText As String
        Dim finMerge As Integer
        Dim fieldNameLen As Integer
        Dim cfName As String
        Dim drAnexo As DataRow
        Dim drTotal As DataRow
      
        dsTemporal.ReadXml("C:\Archivos de Programa\Agil\Schema2.xml")

        drAnexo = dsTemporal.Tables("Contrato").Rows(0)

        oRuta = "F:\Hoja Val.doc"

        oWord = New Microsoft.Office.Interop.Word.Application()

        oWordDoc = New Microsoft.Office.Interop.Word.Document()

        ' Cargo la plantilla

        oWordDoc = oWord.Documents.Add(oRuta, oNulo, oNulo, oNulo)

        If drAnexo("Coac") = "C" And drAnexo("Tipcoac") = "M" And Trim(drAnexo("Nomrcoac")) <> "" Then
            If drAnexo("Tipar") = "F" Or drAnexo("Tipar") = "P" Then
                cCoac2 = Chr(10) & Chr(10) & "Declara  el COARRENDATARIO por conducto de su representante que:" & Chr(10) & Chr(10) & drAnexo("GeneCoac")
            ElseIf drAnexo("Tipar") = "R" Or drAnexo("Tipar") = "S" Then
                cCoac2 = Chr(10) & Chr(10) & "Declara  el COACREDITADO por conducto de su representante que:" & Chr(10) & Chr(10) & drAnexo("GeneCoac")
            End If
            cCoac2 = cCoac2 & Chr(10) & Chr(10) & drAnexo("Podercoa")
        ElseIf drAnexo("Coac") = "C" And drAnexo("Tipcoac") <> "M" And Trim(drAnexo("Nomrcoac")) <> "" Then
            If drAnexo("Tipar") = "F" Or drAnexo("Tipar") = "P" Then
                cCoac2 = Chr(10) & Chr(10) & "Declara  el COARRENDATARIO por su propio derecho:" & Chr(10) & Chr(10) & drAnexo("GeneCoac")
            ElseIf drAnexo("Tipar") = "R" Or drAnexo("Tipar") = "S" Then
                cCoac2 = Chr(10) & Chr(10) & "Declara  el COACREDITADO por su propio derecho:" & Chr(10) & Chr(10) & drAnexo("GeneCoac")
            End If
        ElseIf drAnexo("Coac") = "S" And drAnexo("Tipcoac") = "M" And Trim(drAnexo("Nomrcoac")) <> "" Then
            cCoac2 = Chr(10) & Chr(10) & "Declara  el OBLIGADO SOLIDARIO Y AVAL por conducto de su representante que:" & Chr(10) & Chr(10) & drAnexo("GeneCoac")
            cCoac2 = cCoac2 & Chr(10) & Chr(10) & "Su representante declara: " & Chr(10) & drAnexo("Genercoa") & Chr(10) & Chr(10) & drAnexo("Podercoa")
        ElseIf drAnexo("Coac") = "S" And drAnexo("Tipcoac") <> "M" And Trim(drAnexo("Nomrcoac")) = "" Then
            cCoac2 = Chr(10) & Chr(10) & "Declara  el OBLIGADO SOLIDARIO Y AVAL por su propio derecho:" & Chr(10) & Chr(10) & drAnexo("GeneCoac")
        End If

        If drAnexo("Obli") = "S" And drAnexo("TipoObli") = "M" And Trim(drAnexo("NomrObl")) <> "" Then
            cDato8 = Chr(10) & Chr(10) & "Declara  el OBLIGADO SOLIDARIO Y AVAL por conducto de su representante que:" & Chr(10) & Chr(10) & drAnexo("GeneObli")
            cDato8 = cDato8 & Chr(10) & Chr(10) & "Su representante declara: " & Chr(10) & drAnexo("GenerObl") & Chr(10) & Chr(10) & drAnexo("PoderObl")
        ElseIf drAnexo("Obli") = "S" And drAnexo("TipoObli") <> "M" And Trim(drAnexo("NomObli")) <> "" Then
            cDato8 = Chr(10) & Chr(10) & "Declara  el OBLIGADO SOLIDARIO Y AVAL por su propio derecho:" & Chr(10) & Chr(10) & drAnexo("GeneObli")
        End If

        If drAnexo("Aval1") = "S" And drAnexo("TipAval1") = "M" And Trim(drAnexo("NomAval1")) <> "" Then
            cDato9 = Chr(10) & Chr(10) & "Declara  el OBLIGADO SOLIDARIO Y AVAL por conducto de su representante que:" & Chr(10) & Chr(10) & drAnexo("GeneAva1")
            cDato9 = cDato9 & Chr(10) & Chr(10) & "Su representante declara: " & Chr(10) & drAnexo("Generav1") & Chr(10) & Chr(10) & drAnexo("PoderAv1")
        ElseIf drAnexo("Aval1") = "S" And drAnexo("TipAval1") <> "M" And Trim(drAnexo("NomAval1")) <> "" Then
            cDato9 = Chr(10) & Chr(10) & "Declara  el OBLIGADO SOLIDARIO Y AVAL por su propio derecho:" & Chr(10) & Chr(10) & drAnexo("GeneAva1")
        End If

        If drAnexo("Aval2") = "S" And drAnexo("TipAval2") = "M" And Trim(drAnexo("NomrAva2")) <> "" Then
            cDato10 = Chr(10) & Chr(10) & "Declara  el OBLIGADO SOLIDARIO Y AVAL por conducto de su representante que:" & Chr(10) & Chr(10) & drAnexo("GeneAva2")
            cDato10 = cDato10 & Chr(10) & Chr(10) & "Su representante declara: " & Chr(10) & drAnexo("Generav2") & Chr(10) & Chr(10) & drAnexo("PoderAv2")
        ElseIf drAnexo("Aval2") = "S" And drAnexo("TipAval2") <> "M" And Trim(drAnexo("NomrAva2")) = "" Then
            cDato10 = Chr(10) & Chr(10) & "Declara  el OBLIGADO SOLIDARIO Y AVAL por su propio derecho:" & Chr(10) & Chr(10) & drAnexo("GeneAva2")
        End If

        If cForca = "1" Then
            cLetra = cForca & " PAGOS NIVELADOS"
        ElseIf cForca = "2" Then
            cLetra = cForca & " PAGOS DECRECIENTES"
        Else
            cLetra = cForca & " SPREAD PISO/TECHO"
        End If

        With oWordDoc.Sections(1)
            .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "HOJA DE VALIDACION DE DATOS DEL CONTRATO No. " & Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4))
        End With

        ' Abro el Contrato

        For Each myMField In oWordDoc.Fields

            rFieldCode = myMField.Code

            cFieldText = rFieldCode.Text

            If cFieldText.StartsWith(" MERGEFIELD") Then

                ' Los campos tienen el formato MERGEFIELD NombreCampo \* MERGETYPE, por lo que con estas sentencias extraemos la parte NombreCampo únicamente

                finMerge = cFieldText.IndexOf("\")

                fieldNameLen = cFieldText.Length - finMerge

                cfName = cFieldText.Substring(11, finMerge - 11)

                ' Guardamos el nombre del campo en la variable, quitándole los espacios en blanco

                cfName = cfName.Trim()

                ' Ahora comprobamos si el nombre del campo coincide con el que nosotros queremos,
                ' y si es asi le aplicamos el valor de la variable

                Select Case cfName

                    Case "mDescr"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Trim(cCusnam)
                    Case "mCoac2"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cCoac2
                    Case "mDato7"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Trim(cDato7)
                    Case "mDato8"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cDato8
                    Case "mDato9"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cDato9
                    Case "mCalle"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cCalle
                    Case "mColonia"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cColonia
                    Case "mCopos"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Trim(cCopos)
                    Case "mDelegacion"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Trim(cDelegacion)
                    Case "mEstado"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Trim(cEstado)
                    Case "mRFC"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cRfc.ToUpper
                    Case "mTelefono"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cTelefono.ToUpper
                    Case "mPersona"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cTipo.ToUpper
                    Case "mGeneClie"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cGeneClie.ToUpper
                    Case "mFax"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cFax.ToUpper
                    Case "mDato10"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cDato10
                    Case "mPlazo"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = nAmort.ToString & " Pagos con la periodicidad que se indica en la Tabla de Amortización"
                    Case "mBienes"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cBienes
                    Case "mPromo"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cPromo
                    Case "mTasas"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = nTasas.ToString & Cant_Letras(nTasas, "")
                    Case "mDifer"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = nDifer.ToString & Cant_Letras(nDifer, "")
                    Case "mMensu"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = FormatNumber(nMensu).ToString & Letras(nMensu)
                    Case "mFechacon"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Mes(cFechacon)
                    Case "mFeven"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cFvenc
                    Case "mFechaTer"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Mes(cFecha1)
                    Case "mTasmor"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = "LA RESULTANTE DE MULTIPLICAR POR " & nTasmor.ToString & " EL VALOR DE LA TASA DE INTERES ORDINARIO"
                    Case "mOpcion"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = FormatNumber(nOpcion) & Letras(nOpcion)
                    Case "mComis"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = FormatNumber(nComis / (1 + nPorInt)) & Letras(Round(nComis / (1 + nPorInt), 2))
                    Case "mIvaComis"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = FormatNumber((nComis / (1 + nPorInt)) * nPorInt) & Letras(Round((nComis / (1 + nPorInt)) * nPorInt, 2))
                    Case "mIvaeq"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = FormatNumber(nIvaEq) & Letras(nIvaEq)
                    Case "mImpRD"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = FormatNumber(nImpRD) & Letras(nImpRD)
                    Case "mRentasd"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = FormatNumber(nRentasD) & Letras(nRentasD)
                    Case "mIvard"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = FormatNumber(nIvard) & Letras(nIvard)
                    Case "mTotal"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = FormatNumber(nTotal) & Letras(nTotal)
                    Case "mIvaDGar"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = FormatNumber(nIvaDepg) & Letras(nIvaDepg)
                    Case "mTipta"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cTipta & " " & cDescTasa
                    Case "mForca"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cLetra
                    Case "mRefCliente"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cRefCliente
                    Case "mRefProducto"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cRefProducto
                    Case "mTexto"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cTexto
                    Case "mEjecu"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cEjecu
                End Select

                oWord.Selection.Fields.Update()

            End If

        Next

        'Guardo el documento

        Dim Format As Object = Word.WdSaveFormat.wdFormatDocumentDefault
        Dim oMissing = System.Reflection.Missing.Value

        oWord.ActiveDocument.Select()
        oWord.WordBasic.ToString()
        oWord.Visible = True

        Dim oSaveAsFile = "C:\contratos\" & cCusnam & "_HV_" & cContrato & ".doc"

        oWordDoc.SaveAs(oSaveAsFile, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing)


    End Sub

    Private Sub btnHoja_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHoja.Click
        Dim dsTemporal As New DataSet()
        Dim oNulo As Object = System.Reflection.Missing.Value
        Dim oRuta As New Object
        Dim myMField As Microsoft.Office.Interop.Word.Field
        Dim rFieldCode As Microsoft.Office.Interop.Word.Range
        Dim cFieldText As String
        Dim finMerge As Integer
        Dim fieldNameLen As Integer
        Dim cfName As String
        Dim drAnexo As DataRow
        Dim drTotal As DataRow
        Dim oWord As New Word.Application
        Dim oWordDoc As Microsoft.Office.Interop.Word.Document

        oRuta = "F:\Hoja Disp.doc"

        oWord = New Microsoft.Office.Interop.Word.Application()
        oWordDoc = New Microsoft.Office.Interop.Word.Document()

        ' Cargo la plantilla

        oWordDoc = oWord.Documents.Add(oRuta, oNulo, oNulo, oNulo)

        dsTemporal.ReadXml("C:\Archivos de Programa\Agil\Schema2.xml")

        drAnexo = dsTemporal.Tables("Contrato").Rows(0)

        If cTipar = "F" Then
            If cFondeo = "03" Then
                With oWordDoc.Sections(1)
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddPicture("F:\Logo.JPG")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "No. RECA 0073-426-002824")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "HOJA DE DISPOSICION DE ARRENDAMIENTO FINANCIERO CON RECURSOS FIRA Contrato No. " & Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4)))
                End With
            Else
                With oWordDoc.Sections(1)
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddPicture("F:\Logo.JPG")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "No. RECA 0073-426-002824")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "HOJA DE DISPOSICION DE ARRENDAMIENTO FINANCIERO Contrato No. " & Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4)))
                End With
            End If
        ElseIf cTipar = "R" Then
            If cFondeo = "03" Then
                With oWordDoc.Sections(1)
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddPicture("F:\Logo.JPG")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "No. RECA 0073-137-002825")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "HOJA DE DISPOSICION DE CREDITO REFACCIONARIO CON RECURSOS FIRA Contrato No. " & Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4)))
                End With
            Else
                With oWordDoc.Sections(1)
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddPicture("F:\Logo.JPG")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "No. RECA 0073-137-002825")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "HOJA DE DISPOSICION DE CREDITO REFACCIONARIO Contrato No. " & Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4)))
                End With
            End If
        ElseIf cTipar = "P" Then
            If cFondeo = "03" Then
                With oWordDoc.Sections(1)
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddPicture("F:\Logo.JPG")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "No. RECA 0073-443-007413")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "HOJA DE DISPOSICION DE ARRENDAMIENTO PURO CON RECURSOS FIRA Contrato No. " & Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4)))
                End With
            Else
                With oWordDoc.Sections(1)
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddPicture("F:\Logo.JPG")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "No. RECA 0073-443-007413")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "HOJA DE DISPOSICION DE ARRENDAMIENTO PURO Contrato No. " & Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4)))
                End With
            End If
        ElseIf cTipar = "S" Then
            If cFondeo = "03" Then
                With oWordDoc.Sections(1)
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddPicture("F:\Logo.JPG")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "No. RECA 0073-439-006281")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "HOJA DE DISPOSICION DE CREDITO SIMPLE Contrato No. " & Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4)))
                End With
            Else
                With oWordDoc.Sections(1)
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddPicture("F:\Logo.JPG")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "No. RECA 0073-439-006281")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "HOJA DE DISPOSICION DE CREDITO SIMPLE Contrato No. " & Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4)))
                End With
            End If
        End If

        ' Abro el Contrato

        For Each myMField In oWordDoc.Fields

            rFieldCode = myMField.Code

            cFieldText = rFieldCode.Text

            If cFieldText.StartsWith(" MERGEFIELD") Then

                ' Los campos tienen el formato MERGEFIELD NombreCampo \* MERGETYPE, por lo que con estas sentencias extraemos la parte NombreCampo únicamente

                finMerge = cFieldText.IndexOf("\")

                fieldNameLen = cFieldText.Length - finMerge

                cfName = cFieldText.Substring(11, finMerge - 11)

                ' Guardamos el nombre del campo en la variable, quitándole los espacios en blanco

                cfName = cfName.Trim()

                ' Ahora comprobamos si el nombre del campo coincide con el que nosotros queremos,
                ' y si es asi le aplicamos el valor de la variable

                Select Case cfName

                    Case "mDescr"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Trim(cCusnam)
                    Case "mContrato"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4))
                    Case "mSaldoAct"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = FormatNumber(nSaldoAct)
                    Case "mLinau"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = FormatNumber(nLinau)
                    Case "mFevig"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Mes(cFevig)
                    Case "mProveedor"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cProveedor
                    Case "mImpProv"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cImpProv
                    Case "mImpeq"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = FormatNumber(nImpEq)
                    Case "mMtoFin"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = FormatNumber(nMtoFin)
                    Case "mPlazo"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = nAmort.ToString & " Pagos especificados en la Tabla de Amortización correspondiente"
                    Case "mPromo"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cPromo
                    Case "mTasas"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = nTasas.ToString
                    Case "mDifer"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = nDifer.ToString
                    Case "mMensu"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = FormatNumber(nMensu).ToString
                    Case "mFechacon"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Mes(cFechacon)
                    Case "mFeven"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cFvenc
                    Case "mFecre"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Mes(cFecre)
                    Case "mFeaut"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Mes(cFeaut)
                    Case "mSaldoRiesgo"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = FormatNumber(nSaldoRiesgo).ToString
                    Case "mSaldo"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = FormatNumber(nSaldo).ToString
                    Case "mIvaeq"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = FormatNumber(nIvaEq).ToString
                    Case "mDescFrecuencia"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cDescFrecuencia
                    Case "mDescRecurso"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cDescRecurso
                    Case "mOpcion"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = nPorop
                    Case "mTipta"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cDescTasa
                    Case "mDescPI"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cDescPI
                    Case "mImpPI"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cImpPI
                    Case "mEjecu"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cEjecu
                End Select

                oWord.Selection.Fields.Update()

            End If

        Next

        'Guardo el documento

        Dim Format As Object = Word.WdSaveFormat.wdFormatDocumentDefault
        Dim oMissing = System.Reflection.Missing.Value

        oWord.ActiveDocument.Select()
        oWord.WordBasic.ToString()
        oWord.Visible = True

        Dim oSaveAsFile = "C:\contratos\" & cCusnam & "_HD_" & cContrato & ".doc"

        oWordDoc.SaveAs(oSaveAsFile, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing)

    End Sub

    Private Sub btnPagare_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPagare.Click

        Dim dsTemporal As New DataSet()
        Dim oNulo As Object = System.Reflection.Missing.Value
        Dim oRuta As New Object
        Dim myMField As Microsoft.Office.Interop.Word.Field
        Dim rFieldCode As Microsoft.Office.Interop.Word.Range
        Dim cFieldText As String
        Dim finMerge As Integer
        Dim fieldNameLen As Integer
        Dim cfName As String
        Dim drAnexo As DataRow
        Dim drTotal As DataRow
        Dim oWord As New Word.Application
        Dim oWordDoc As Microsoft.Office.Interop.Word.Document
        Dim cArticulo As String = ""

        oRuta = "F:\PAGARE1.doc"

        oWord = New Microsoft.Office.Interop.Word.Application()

        oWordDoc = New Microsoft.Office.Interop.Word.Document()

        ' Cargo la plantilla

        oWordDoc = oWord.Documents.Add(oRuta, oNulo, oNulo, oNulo)

        dsTemporal.ReadXml("C:\Archivos de Programa\Agil\Schema2.xml")

        drAnexo = dsTemporal.Tables("Contrato").Rows(0)

        If Mid(drAnexo("Geneclie"), 1, 2) = "A)" Then
            cGeneClie = drAnexo("GeneClie") & Chr(10)
        ElseIf Mid(drAnexo("Geneclie"), 1, 2) = "a)" Then
            cGeneClie = drAnexo("GeneClie") & Chr(10)
        Else
            cGeneClie = "A) " & drAnexo("GeneClie") & Chr(10)
        End If

        If cTipar = "R" Then
            cArticulo = "325"
        Else
            cArticulo = "409"
        End If

        If drAnexo("Tipo") = "M" Then
            cDato7 = Chr(10) & Chr(10) & "B) Su representante cuenta con facultades suficientes y declara que: "
            cDato7 = cDato7 & Chr(10) + Chr(10) & drAnexo("Generepr")
            cDato7 = cDato7 & Chr(10) & Chr(10) & drAnexo("Poderepr")
            If drAnexo("Nomrepr2") <> "" Then
                cDato7 = Chr(10) & Chr(10) & "Su segundo representante " & drAnexo("Nomrepr2") & " quien manifiesta"
                cDato7 = cDato7 & Chr(10) & Chr(10) & drAnexo("Poderep2")
            End If
        End If

        If drAnexo("Coac") = "C" And drAnexo("Tipcoac") = "M" And Trim(drAnexo("Nomrcoac")) <> "" Then
            If drAnexo("Tipar") = "F" Or drAnexo("Tipar") = "P" Then
                cCoac2 = Chr(10) & Chr(10) & "Declara  el COARRENDATARIO por conducto de su representante que:" & Chr(10) & Chr(10) & drAnexo("GeneCoac")
            ElseIf drAnexo("Tipar") = "R" Or drAnexo("Tipar") = "S" Then
                cCoac2 = Chr(10) & Chr(10) & "Declara  el COACREDITADO por conducto de su representante que:" & Chr(10) & Chr(10) & drAnexo("GeneCoac")
            End If
            cCoac2 = cCoac2 & Chr(10) & Chr(10) & drAnexo("Podercoa")
        ElseIf drAnexo("Coac") = "C" And drAnexo("Tipcoac") <> "M" And Trim(drAnexo("Nomrcoac")) = "" Then
            If drAnexo("Tipar") = "F" Or drAnexo("Tipar") = "P" Then
                cCoac2 = Chr(10) & Chr(10) & "Declara  el COARRENDATARIO por su propio derecho:" & Chr(10) & Chr(10) & drAnexo("GeneCoac")
            ElseIf drAnexo("Tipar") = "R" Or drAnexo("Tipar") = "S" Then
                cCoac2 = Chr(10) & Chr(10) & "Declara  el COACREDITADO por su propio derecho:" & Chr(10) & Chr(10) & drAnexo("GeneCoac")
            End If
        ElseIf drAnexo("Coac") = "S" And drAnexo("Tipcoac") = "M" And Trim(drAnexo("Nomrcoac")) <> "" Then
            cCoac2 = Chr(10) & Chr(10) & "Declara  el OBLIGADO SOLIDARIO Y AVAL por conducto de su representante que:" & Chr(10) & Chr(10) & drAnexo("GeneCoac")
            cCoac2 = cCoac2 & Chr(10) & Chr(10) & drAnexo("Podercoa")
        ElseIf drAnexo("Coac") = "S" And drAnexo("Tipcoac") <> "M" And Trim(drAnexo("Nomrcoac")) = "" Then
            cCoac2 = Chr(10) & Chr(10) & "Declara  el OBLIGADO SOLIDARIO Y AVAL por su propio derecho:" & Chr(10) & Chr(10) & drAnexo("GeneCoac")
        End If

        If drAnexo("Obli") = "S" And drAnexo("TipoObli") = "M" And Trim(drAnexo("NomrObl")) = "" Then
            cDato8 = Chr(10) & Chr(10) & "Declara  el OBLIGADO SOLIDARIO Y AVAL por conducto de su representante que:" & Chr(10) & Chr(10) & drAnexo("GeneObli")
            cDato8 = cDato8 & Chr(10) & Chr(10) & drAnexo("PoderObl")
        ElseIf drAnexo("Obli") = "S" And drAnexo("TipoObli") <> "M" And Trim(drAnexo("NomObli")) <> "" Then
            cDato8 = Chr(10) & Chr(10) & "Declara  el OBLIGADO SOLIDARIO Y AVAL por su propio derecho:" & Chr(10) & Chr(10) & drAnexo("GeneObli")
        End If

        If drAnexo("Aval1") = "S" And drAnexo("TipAval1") = "M" And Trim(drAnexo("NomAval1")) = "" Then
            cDato9 = Chr(10) & Chr(10) & "Declara  el OBLIGADO SOLIDARIO Y AVAL por conducto de su representante que:" & Chr(10) & Chr(10) & drAnexo("GenAva1")
            cDato9 = cDato9 & Chr(10) & Chr(10) & drAnexo("PoderAv1")
        ElseIf drAnexo("Aval1") = "S" And drAnexo("TipAval1") <> "M" And Trim(drAnexo("NomAval1")) <> "" Then
            cDato9 = Chr(10) & Chr(10) & "Declara  el OBLIGADO SOLIDARIO Y AVAL por su propio derecho:" & Chr(10) & Chr(10) & drAnexo("GeneAva1")
        End If

        If drAnexo("Aval2") = "S" And drAnexo("TipAval2") = "M" And Trim(drAnexo("NomrAva2")) <> "" Then
            cDato10 = Chr(10) & Chr(10) & "Declara  el OBLIGADO SOLIDARIO Y AVAL por conducto de su representante que:" & Chr(10) & Chr(10) & drAnexo("GeneAva2")
            cDato10 = cDato10 & Chr(10) & Chr(10) & drAnexo("PoderAv2")
        ElseIf drAnexo("Aval2") = "S" And drAnexo("TipAval2") <> "M" And Trim(drAnexo("NomrAva2")) = "" Then
            cDato10 = Chr(10) & Chr(10) & "Declara  el OBLIGADO SOLIDARIO Y AVAL por su propio derecho:" & Chr(10) & Chr(10) & drAnexo("GeneAva2")
        End If

        If cTipta = "1" Then
            cLetra = cTipta & " PAGOS NIVELADOS"
        ElseIf cTipta = "2" Then
            cLetra = cTipta & " PAGOS DECRECIENTES"
        Else
            cLetra = cTipta & " SPREAD PISO/TECHO"
        End If

        If cTipta < "7" Then
            cDescTipta = "Tasa Promedio Máxima, equivalente a la que resulte mayor de comparar:"

            If cTipta = "3" Or cTipta = "4" Then
                cDescTipta = cDescTipta & Chr(10) & Chr(10) & "La tasa CETES (rendimiento de los Certificados de la "
                cDescTipta = cDescTipta & "Tesorería de la Federación) por emisiones a plazo de 28 "
                cDescTipta = cDescTipta & "días, determinada en la primera semana de cada periodo."
            End If
            If cTipta = "2" Or cTipta = "3" Or cTipta = "4" Then
                cDescTipta = cDescTipta & Chr(10) & Chr(10) & "La tasa C.P.P. (Costo Porcentual Promedio de Captación)"
                cDescTipta = cDescTipta & "publicada por el Banco de Máxico en el Diario Oficial de "
                cDescTipta = cDescTipta & "la Federación, aplicando la tasa vigente al inicio de "
                cDescTipta = cDescTipta & "cada periodo."
            End If
            If cTipta = "1" Or cTipta = "2" Or cTipta = "3" Then
                cDescTipta = cDescTipta & Chr(10) & Chr(10) & "La tasa TIIP (Tasa de interés Interbancaria Promedio) "
                cDescTipta = cDescTipta & "tasa de rendimiento anual, equivalente a 28 días, que sea "
                cDescTipta = cDescTipta & "o sean publicadas por el Banco de Máxico en el Diario "
                cDescTipta = cDescTipta & "Oficial de la Federaci¢n vigentes al inicio de cada "
                cDescTipta = cDescTipta & "periodo."
            End If
            If cTipta = "1" Or cTipta = "2" Or cTipta = "4" Or cTipta = "6" Then
                cDescTipta = cDescTipta & Chr(10) & Chr(10) & "La tasa TIIE (Tasa Anual de Interés Interbancaria de "
                cDescTipta = cDescTipta & "Equilibrio) que publica semanalmente Banco de México "
                cDescTipta = cDescTipta & "determinada en el periodo anterior a cada pago."
            End If

            cDescTipta = cDescTipta & Chr(10) & Chr(10) & "A dicha Tasa Promedio Máxima se adicionarán "
            cDescTipta = cDescTipta & Round(nDifer, 2).ToString & Cant_Letras(nDifer, "") & " puntos porcentuales."

            cDescTipta = cDescTipta & Chr(10) & Chr(10) & "Tanto la Tasa Promedio Máxima as¡ como su diferencial de "
            cDescTipta = cDescTipta & "puntos se revisar n con la misma periodicidad que las "
            cDescTipta = cDescTipta & "parcialidades a efecto de adecuarlos a las condiciones del "
            cDescTipta = cDescTipta & "mercado en ese momento."

            cDescTipta = cDescTipta & Chr(10) & Chr(10) & "Este pagar‚ incluye intereses sobre saldos insolutos, que en "
            cDescTipta = cDescTipta & "su caso serán ajustables con la misma periodicidad que las "
            cDescTipta = cDescTipta & "parcialidades, desde la fecha de su expedición hasta la de "
            cDescTipta = cDescTipta & "su vencimiento de acuerdo al movimiento de la Tasa Promedio "
            cDescTipta = cDescTipta & "Máxima vigente durante el periodo en que se devenguen dichos "
            cDescTipta = cDescTipta & "intereses, aumentando "
            cDescTipta = cDescTipta & Round(nDifer, 2).ToString & Cant_Letras(nDifer, "") & " puntos porcentuales."

        ElseIf cTipta = "7" Then
            cDescTipta = "TASA FIJA con un valor de " & Round(nTasas, 2).ToString & Cant_Letras(nTasas, "") & " anual."
        ElseIf cTipta = "8" Then
            cDescTipta = "TASA PROTEGIDA con un valor de TIIE + '" & Round(nDifer, 2).ToString
            cDescTipta = cDescTipta & " porciento anual, estableciendo una TIIE m xima del 13.00 porciento anual."
        End If

        If cTipar = "F" Then
            If cFondeo = "03" Then
                With oWordDoc.Sections(1)
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddPicture("F:\Logo.JPG")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "No. RECA 0073-426-002824")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "PAGARE DE ARRENDAMIENTO FINANCIERO CON RECURSOS FIRA Contrato No. " & Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4)))
                End With
            Else
                With oWordDoc.Sections(1)
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddPicture("F:\Logo.JPG")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter("No. RECA 0073-426-002824")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "PAGARE DE ARRENDAMIENTO FINANCIERO Contrato No. " & Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4)))
                End With
            End If
        ElseIf cTipar = "P" Then
            If cFondeo = "03" Then
                With oWordDoc.Sections(1)
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddPicture("F:\Logo.JPG")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "No. RECA 0073-443-007413")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "PAGARE DE ARRENDAMIENTO PURO CON RECURSOS FIRA Contrato No. " & Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4)))
                End With
            Else
                With oWordDoc.Sections(1)
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddPicture("F:\Logo.JPG")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "No. RECA 0073-443-007413")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "PAGARE DE ARRENDAMIENTO PURO Contrato No. " & Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4)))
                End With
            End If
        ElseIf cTipar = "R" Then
            If cFondeo = "03" Then
                With oWordDoc.Sections(1)
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddPicture("F:\Logo.JPG")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "No. RECA 0073-137-002825")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "PAGARE DE CREDITO REFACCIONARIO CON RECURSOS FIRA Contrato No. " & Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4)))
                End With
            Else
                With oWordDoc.Sections(1)
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddPicture("F:\Logo.JPG")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "No. RECA 0073-137-002825")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "PAGARE DE CREDITO REFACCIONARIO Contrato No. " & Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4)))
                End With
            End If
        ElseIf cTipar = "S" Then
            If cFondeo = "03" Then
                With oWordDoc.Sections(1)
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddPicture("F:\Logo.JPG")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "No. RECA 0073-439-006281")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "PAGARE DE CREDITO SIMPLE Contrato No. " & Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4)))
                End With
            Else
                With oWordDoc.Sections(1)
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddPicture("F:\Logo.JPG")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "No. RECA 0073-439-006281")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "PAGARE DE CREDITO SIMPLE Contrato No. " & Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4)))
                End With
            End If
        End If

        ' Abro el Contrato

        For Each myMField In oWordDoc.Fields

            rFieldCode = myMField.Code

            cFieldText = rFieldCode.Text

            If cFieldText.StartsWith(" MERGEFIELD") Then

                ' Los campos tienen el formato MERGEFIELD NombreCampo \* MERGETYPE, por lo que con estas sentencias extraemos la parte NombreCampo únicamente

                finMerge = cFieldText.IndexOf("\")

                fieldNameLen = cFieldText.Length - finMerge

                cfName = cFieldText.Substring(11, finMerge - 11)

                ' Guardamos el nombre del campo en la variable, quitándole los espacios en blanco

                cfName = cfName.Trim()

                ' Ahora comprobamos si el nombre del campo coincide con el que nosotros queremos,
                ' y si es asi le aplicamos el valor de la variable

                Select Case cfName

                    Case "mContrato"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4))
                    Case "mDescr"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Trim(cCusnam)
                    Case "mCalle"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cCalle
                    Case "mColonia"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cColonia
                    Case "mCopos"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Trim(cCopos)
                    Case "mDelegacion"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Trim(cDelegacion)
                    Case "mEstado"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Trim(cEstado)
                    Case "mFechacon"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Mes(cFechacon)
                    Case "mTasmor"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = nTasmor
                    Case "mTotal"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = FormatNumber(nTotal) & Letras(nTotal)
                        If cFondeo = "03" Then
                            myMField.Result.Text = FormatNumber(nTotal + nTotalCobert) & Letras(nTotal + nTotalCobert)
                        End If
                    Case "mLetrat"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cLetrat
                    Case "mFevent"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cFevent
                    Case "mRenta"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cRenta
                        If cFondeo = "03" Then
                            myMField.Result.Text = cTotg
                        End If
                    Case "mFirmaCte"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cFirmaCte.ToUpper
                    Case "mFirmaAval1"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cFirmaAval1.ToUpper
                    Case "mFirmaAval2"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cFirmaAval2.ToUpper
                    Case "mFirmaAval3"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cFirmaAval3.ToUpper
                    Case "mFirmaAval4"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cFirmaAval4.ToUpper
                    Case "mDescTipta"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cDescTipta
                    Case "mLugar"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cLugar
                    Case "mProducto"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cProducto
                    Case "mArticulo"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cArticulo
                    Case "mRefCliente"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cRefCliente
                    Case "mParrafoInteres"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cParrafoInteres
                End Select

                oWord.Selection.Fields.Update()

            End If

        Next

        'Guardo el documento

        Dim Format As Object = Word.WdSaveFormat.wdFormatDocumentDefault
        Dim oMissing = System.Reflection.Missing.Value

        oWord.ActiveDocument.Select()
        oWord.WordBasic.ToString()
        oWord.Visible = True

        Dim oSaveAsFile = "C:\contratos\" & cCusnam & "_PAG_" & cContrato & ".doc"

        oWordDoc.SaveAs(oSaveAsFile, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing)

    End Sub

    Private Sub btnContrato_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnContrato.Click

        Dim dsTemporal As New DataSet()
        Dim oNulo As Object = System.Reflection.Missing.Value
        Dim oRuta As New Object
        Dim myMField As Microsoft.Office.Interop.Word.Field
        Dim rFieldCode As Microsoft.Office.Interop.Word.Range
        Dim cFieldText As String
        Dim finMerge As Integer
        Dim fieldNameLen As Integer
        Dim cfName As String
        Dim drAnexo As DataRow
        Dim drTotal As DataRow
        Dim oWord As New Word.Application
        Dim oWordDoc As Microsoft.Office.Interop.Word.Document

        ' Declaración de variables de datos

        Dim cFecha As String
        Dim cFeven As String
        Dim cDato1 As String = ""
        Dim cNota As String = ""
        Dim cDato12 As String = ""
        Dim cDato12A As String = ""
        Dim cDato12B As String = ""
        Dim cDato12C As String = ""
        Dim cGenerep As String = ""
        Dim cDato15 As String = ""
        Dim cLetraImp As String = ""
        Dim cGeneEmp As String = ""
        Dim cTestigo1 As String = ""
        Dim cTestigo2 As String = ""
        Dim cLeyenda As String = ""
        Dim cAporInv As String = ""
        Dim cCobertura As String = ""
        Dim cCoberDet1 As String = ""
        Dim cCoberDet2 As String = ""
        Dim cRecur As String
        Dim nCount As Integer
        Dim nTIR As Decimal
        Dim nSaldo As Decimal
        Dim nMensu As Decimal
        Dim nDato2 As Decimal
        Dim nDepg As Decimal
        Dim i As Integer

        dsTemporal.ReadXml("C:\Archivos de Programa\Agil\Schema2.xml")

        drAnexo = dsTemporal.Tables("Contrato").Rows(0)
        cLetraImp = Letras(nTotal)

        cNota = Chr(10) & Chr(10) & Chr(10) & Chr(10) & "NOTA: A través de la(s) firma(s) que de su puño y letra estampa(n) en el presente contrato el(los) OBLIGADO(S) SOLIDARIO(S) Y AVAL(ES) "
        cNota = cNota & "manifiesta(n) su conformidad y se da(n) por enterado(s) y advertido(s), que esta(n) obligado(s) a efectuar el "
        cNota = cNota & "pago en caso de que el obligado principal (ARRENDATARIA) incumpla con el mismo por cualquier causa."


        If drAnexo("Tipo") = "M" And Trim(drAnexo("Nomrepr")) <> "" Then
            cDato1 = "por conducto de su representante que:"
            cGeneEmp = Chr(10) & Chr(10) & "De la sociedad denominada " & cCusnam & " su representante de nombre " & cRepresentante & " manifiesta que " & cGeneClie & "Manifestando los comparecientes bajo protesta de decir verdad, que las facultades a ellos otorgadas, no les han sido revocadas, ni en forma alguna limitadas."
        Else
            cDato1 = "por su propio derecho:"
        End If

        cDato15 = Mid(drAnexo("Geneclie"), 1, 2)
        If cDato15 = "A)" Then
            cGeneClie = drAnexo("GeneClie") & Chr(10)
        ElseIf cDato15 = "a)" Then
            cGeneClie = drAnexo("GeneClie") & Chr(10)
        Else
            cGeneClie = "A) " & drAnexo("GeneClie") & Chr(10)
        End If

        If drAnexo("Tipo") = "M" Then
            cDato7 = Chr(10) & Chr(10) & "B) Su representante cuenta con facultades suficientes y declara que: "
            cDato7 = cDato7 & Chr(10) + Chr(10) & drAnexo("Generepr")
            cDato7 = cDato7 & Chr(10) & Chr(10) & drAnexo("Poderepr")
            If drAnexo("Nomrepr2") <> "" Then
                cDato7 = Chr(10) & Chr(10) & "Su segundo representante " & drAnexo("Nomrepr2") & " quien manifiesta"
                cDato7 = cDato7 & Chr(10) & Chr(10) & drAnexo("Poderep2")
            End If
        End If

        cDato12 = "III.- "

        If drAnexo("Coac") = "C" And drAnexo("Tipcoac") = "M" And Trim(drAnexo("Nomrcoac")) <> "" Then
            If drAnexo("Tipar") = "F" Or drAnexo("Tipar") = "P" Then
                cCoac2 = Chr(10) & Chr(10) & cDato12 & "Declara  el COARRENDATARIO por conducto de su representante que:" & Chr(10) & Chr(10) & drAnexo("GeneCoac")
            ElseIf drAnexo("Tipar") = "R" Or drAnexo("Tipar") = "S" Then
                cCoac2 = Chr(10) & Chr(10) & cDato12 & "Declara  el COACREDITADO por conducto de su representante que:" & Chr(10) & Chr(10) & drAnexo("GeneCoac")
            End If
            cCoac2 = cCoac2 & Chr(10) & Chr(10) & drAnexo("Podercoa")
        ElseIf drAnexo("Coac") = "C" And drAnexo("Tipcoac") <> "M" And Trim(drAnexo("Nomrcoac")) = "" Then
            If drAnexo("Tipar") = "F" Or drAnexo("Tipar") = "P" Then
                cCoac2 = Chr(10) & Chr(10) & cDato12 & "Declara  el COARRENDATARIO por su propio derecho:" & Chr(10) & Chr(10) & drAnexo("GeneCoac")
            ElseIf drAnexo("Tipar") = "R" Or drAnexo("Tipar") = "S" Then
                cCoac2 = Chr(10) & Chr(10) & cDato12 & "Declara  el COACREDITADO por su propio derecho:" & Chr(10) & Chr(10) & drAnexo("GeneCoac")
            End If
        ElseIf drAnexo("Coac") = "S" And drAnexo("Tipcoac") = "M" And Trim(drAnexo("Nomrcoac")) <> "" Then
            cCoac2 = Chr(10) & Chr(10) & cDato12 & "Declara  el OBLIGADO SOLIDARIO Y AVAL por conducto de su representante que:" & Chr(10) & Chr(10) & drAnexo("GeneCoac")
            cCoac2 = cCoac2 & Chr(10) & Chr(10) & drAnexo("Podercoa")
        ElseIf drAnexo("Coac") = "S" And drAnexo("Tipcoac") <> "M" And Trim(drAnexo("Nomrcoac")) = "" Then
            cCoac2 = Chr(10) & Chr(10) & cDato12 & "Declara  el OBLIGADO SOLIDARIO Y AVAL por su propio derecho:" & Chr(10) & Chr(10) & drAnexo("GeneCoac")
        End If

        If cCoac2 <> "" Then
            cDato12 = "IV.- "
            cDato12A = "V.- "
            cDato12B = "VI.- "
            cDato12C = "VII.- "
        End If

        If drAnexo("Obli") = "S" And drAnexo("TipoObli") = "M" And Trim(drAnexo("NomrObl")) <> "" Then
            cDato8 = Chr(10) & Chr(10) & cDato12 & "Declara  el OBLIGADO SOLIDARIO Y AVAL " & "'" & drAnexo("NomObli") & "'" & " por conducto de su representante " & Trim(drAnexo("NomrObl")) & " que:" & Chr(10) & Chr(10) & drAnexo("GeneObli")
            cDato8 = cDato8 & Chr(10) & Chr(10) & drAnexo("PoderObl")
        ElseIf drAnexo("Obli") = "S" And drAnexo("TipoObli") <> "M" And Trim(drAnexo("NomrObl")) = "" Then
            cDato8 = Chr(10) & Chr(10) & cDato12 & "Declara  el OBLIGADO SOLIDARIO Y AVAL por su propio derecho:" & Chr(10) & Chr(10) & drAnexo("GeneObli")
        End If

        If cDato8 <> "" And cDato12 = "IV.- " Then
            cDato12 = "V.- "
            cDato12A = "VI.- "
            cDato12B = "VII.- "
            cDato12C = "VIII.- "
        ElseIf cDato8 <> "" And cDato12 = "III.- " Then
            cDato12 = "IV.- "
            cDato12A = "V.- "
            cDato12B = "VI.- "
            cDato12C = "VII.- "
        End If

        If drAnexo("Aval1") = "S" And drAnexo("TipAval1") = "M" And Trim(drAnexo("NomAval1")) = "" Then
            cDato9 = Chr(10) & Chr(10) & cDato12 & "Declara  el OBLIGADO SOLIDARIO Y AVAL por conducto de su representante que:" & Chr(10) & Chr(10) & drAnexo("GenAva1")
            cDato9 = cDato9 & Chr(10) & Chr(10) & drAnexo("PoderAv1")
        ElseIf drAnexo("Aval1") = "S" And drAnexo("TipAval1") <> "M" And Trim(drAnexo("NomAval1")) <> "" Then
            cDato9 = Chr(10) & Chr(10) & cDato12 & "Declara  el OBLIGADO SOLIDARIO Y AVAL por su propio derecho:" & Chr(10) & Chr(10) & drAnexo("GeneAva1")
        End If
        If cDato9 <> "" And cDato12 = "V.- " Then
            cDato12 = "VI.- "
            cDato12A = "VII.- "
            cDato12B = "VIII.- "
            cDato12C = "IX.- "
        ElseIf cDato9 <> "" And cDato12 = "IV.- " Then
            cDato12 = "V.- "
            cDato12A = "VI.- "
            cDato12B = "VII.- "
            cDato12C = "VIII.- "
        ElseIf cDato9 <> "" And cDato12 = "III.- " Then
            cDato12 = "IV.- "
            cDato12A = "V.- "
            cDato12B = "VI.- "
            cDato12C = "VII.- "
        ElseIf cDato9 <> "" And cDato12 = "VI.- " Then
            cDato12 = "VII.- "
            cDato12A = "VIII.- "
            cDato12B = "IX.- "
            cDato12C = "X.- "
        End If

        If drAnexo("Aval2") = "S" And drAnexo("TipAval2") = "M" And Trim(drAnexo("NomrAva2")) <> "" Then
            cDato10 = Chr(10) & Chr(10) & cDato12 & "Declara  el OBLIGADO SOLIDARIO Y AVAL por conducto de su representante que:" & Chr(10) & Chr(10) & drAnexo("GeneAva2")
            cDato10 = cDato10 & Chr(10) & Chr(10) & drAnexo("PoderAv2")
        ElseIf drAnexo("Aval2") = "S" And drAnexo("TipAval2") <> "M" And Trim(drAnexo("NomrAva2")) = "" Then
            cDato10 = Chr(10) & Chr(10) & cDato12 & "Declara  el OBLIGADO SOLIDARIO Y AVAL por su propio derecho:" & Chr(10) & Chr(10) & drAnexo("GeneAva2")
        End If

        If drAnexo("Sucursal") = "01" Or drAnexo("Sucursal") = "02" Then
            If Trim(drAnexo("DescPromotor")) = "C.P. GERALDO GARCIA VELEZ" Then
                cTestigo1 = "Llamarse Luis Manuel González Miranda, manifiesta por sus generales ser de nacionalidad mexicana, originario de la ciudad de Toluca, Estado de México, lugar donde nació el día 06 de enero de 1975, de profesión Contador Público, con domicilio en Leandro Valle No. 402, colonia Reforma y FFCCNN, C.P. 50070, Toluca, Estado de México, y con R.F.C. GOML750106SM8"
                cFirmaTestigo1 = "C.P. LUIS MANUEL GONZALEZ MIRANDA"
            ElseIf Trim(drAnexo("DescPromotor")) = "ING. MIGUEL ANGEL LEAL RUIZ" Then
                cTestigo1 = "Llamarse Miguel Angel Leal Ruiz, manifiesta por sus generales ser de nacionalidad mexicana, originario de la ciudad de México, D.F., lugar donde nació el día 12 de diciembre de 1961, de profesión Ingeniero Agronomo, con domicilio en Leandro Valle No. 402, colonia Reforma y FFCCNN, C.P. 50070, Toluca, Estado de México, y con R.F.C. LERM611212KS7"
                cFirmaTestigo1 = "ING. MIGUEL ANGEL LEAL RUIZ"
            ElseIf Trim(drAnexo("DescPromotor")) = "C.P. JONATHAN HERNANDEZ ARIAS" Then
                cTestigo1 = "Llamarse Jonathan Hernández Arias, manifiesta por sus generales ser de nacionalidad mexicana, originario de la ciudad de Toluca, Estado de México, lugar donde nació el día 09 de julio de 1975, de profesión Contador Público, con domicilio en Leandro Valle No. 402, colonia Reforma y FFCCNN, C.P. 50070, Toluca, Estado de México, y con R.F.C. HEAJ7507096H2"
                cFirmaTestigo1 = "C.P. JONATHAN HERNANDEZ ARIAS"
            ElseIf Trim(drAnexo("DescPromotor")) = "C.P. ENRIQUE YONG BETANCOURT" Then
                cTestigo1 = "Llamarse Enrique Yong Betancourt, manifiesta por sus generales ser de nacionalidad mexicana, originario de la ciudad de Querétaro, Querétaro, lugar donde nació el día 28 de abril de 1965, de profesión Contador Público, con domicilio en Leandro Valle No. 402, colonia Reforma y FFCCNN, C.P. 50070, Toluca, Estado de México, y con R.F.C. YOBE650428Q67"
                cFirmaTestigo1 = "C.P. ENRIQUE YONG BETANCOURT"
            ElseIf Trim(drAnexo("DescPromotor")) = "C.P. LUIS MANUEL GONZALEZ MIRANDA" Then
                cTestigo1 = "Llamarse Luis Manuel González Miranda, manifiesta por sus generales ser de nacionalidad mexicana, originario de la ciudad de Toluca, Estado de México, lugar donde nació el día 06 de enero de 1975, de profesión Contador Público, con domicilio en Leandro Valle No. 402, colonia Reforma y FFCCNN, C.P. 50070, Toluca, Estado de México, y con R.F.C. GOML750106SM8"
                cFirmaTestigo1 = "C.P. LUIS MANUEL GONZALEZ MIRANDA"
            ElseIf Trim(drAnexo("DescPromotor")) = "LAE RAFAEL DIAZ ORTIZ" Then
                cTestigo1 = "Llamarse Rafael Díaz Ortiz, manifiesta por sus generales ser de nacionalidad mexicana, originario de la ciudad de Toluca, Estado de México, lugar donde nació el día 03 de febrero de 1980, de profesión Lic. en Administración de Empresas, con domicilio en Leandro Valle No. 402, colonia Reforma y FFCCNN, C.P. 50070, Toluca, Estado de México, y con R.F.C. DIOR800203AG2"
                cFirmaTestigo1 = "LAE. RAFAEL DIAZ ORTIZ"
            ElseIf Trim(drAnexo("DescPromotor")) = "LAE. MAURO SANCHEZ DE LA BARQUERA" Then
                cTestigo1 = "Llamarse Mauro Sánchez de la Barquera Miranda, manifiesta por sus generales ser de nacionalidad mexicana, originario de la ciudad de México, D.F., lugar donde nació el día 25 de agosto de 1971, de profesión Licenciado en Administración de Empresas, con domicilio en Leandro Valle No. 402, colonia Reforma y FFCCNN, C.P. 50070, Toluca, Estado de México, y con R.F.C. SAMM710825BW3"
                cFirmaTestigo1 = "LAE. MAURO SANCHEZ DE LA BARQUERA"
            ElseIf Trim(drAnexo("DescPromotor")) = "PEDRO SOLIS FRANCO" Then
                cTestigo1 = "Llamarse Pedro Solis Franco, manifiesta por sus generales ser de nacionalidad mexicana, originario de la ciudad de México, D.F., lugar donde nació el día 18 de marzo de 1978, con domicilio en Leandro Valle No. 402, colonia Reforma y FFCCNN, C.P. 50070, Toluca, Estado de México, y con R.F.C. SOFP7803186G8"
                cFirmaTestigo1 = "PEDRO SOLIS FRANCO"
            ElseIf Trim(drAnexo("DescPromotor")) = "GUILLERMO RAMIREZ GUZMAN" Then
                cTestigo1 = "Llamarse Guillermo Ramirez Guzman, manifiesta por sus generales ser de nacionalidad mexicana, originario de la ciudad de Toluca, Estado de México, lugar donde nació el día 20 de junio de 1961, de profesión Licenciado en Administración de Empresas, con domicilio en Leandro Valle No. 402, colonia Reforma y FFCCNN, C.P. 50070, Toluca, Estado de México, y con R.F.C. RAGG610620AF2"
                cFirmaTestigo1 = "LAE. GUILLERMO RAMIREZ GUZMAN"
            End If

            If Trim(drAnexo("DescPromotor")) = "C.P. LUIS MANUEL GONZALEZ MIRANDA" Then
                cTestigo2 = "Llamarse Jonathan Hernández Arias, manifiesta por sus generales ser de nacionalidad mexicana, originario de la ciudad de Toluca, Estado de México, lugar donde nació el día 09 de julio de 1975, de profesión Contador Público, con domicilio en Leandro Valle No. 402, colonia Reforma y FFCCNN, C.P. 50070, Toluca, Estado de México, y con R.F.C. HEAJ7507096H2"
                cFirmaTestigo2 = "C.P. JONATHAN HERNANDEZ ARIAS"
            Else
                cTestigo2 = "Llamarse Luis Manuel González Miranda, manifiesta por sus generales ser de nacionalidad mexicana, originario de la ciudad de Toluca, Estado de México, lugar donde nació el día 06 de enero de 1975, de profesión Contador Público, con domicilio en Leandro Valle No. 402, colonia Reforma y FFCCNN, C.P. 50070, Toluca, Estado de México, y con R.F.C. GOML750106SM8"
                cFirmaTestigo2 = "C.P. LUIS MANUEL GONZALEZ MIRANDA"
            End If

        ElseIf drAnexo("Sucursal") = "03" Then
            cTestigo1 = "Llamarse Adolfo Pacheco Méndez, manifiesta por sus generales ser de nacionalidad mexicana, originario de la ciudad Obregón, Sonora, lugar donde nació el día 01 de marzo de 1964, de profesión Ingeniero Agrónomo Irrigador, con domicilio en Quintana Roo No. 111 Edif. Guadalajara Locales 8,9 y 10, colonia Juárez C.P. 85870, Navojoa, Sonora, y con R.F.C. PAMA6403012V1"
            cTestigo2 = "Llamarse Rosario León Armenta, manifiesta por sus generales ser de nacionalidad mexicana, originario de Pueblo Yaqui, Sonora, lugar donde nació el día 02 de febrero de 1966, de profesión Ingeniero Agrónomo Fitotecnista, con domicilio en Quintana Roo No. 111 Edif. Guadalajara Locales 8,9, y 10, colonia Juárez, C.P. 85870, Navojoa, Sonora, y con R.F.C. LEAR660202L82"
            cFirmaTestigo1 = "ING. ADOLFO PACHECO MENDEZ"
            cFirmaTestigo2 = "ING. ROSARIO LEON ARMENTA"
        ElseIf drAnexo("Sucursal") = "04" Then
            cTestigo1 = "Llamarse Francisco Kozo Wakida Suzuki, manifiesta por sus generales ser de nacionalidad mexicana, originario de la ciudad San Luis Río Colorado, Sonora, lugar donde nació el día 13 de agosto de 1958, de profesión Ingeniero Agrónomo Fitotecnista, con domicilio en Av. Río San Ángel 48 Locales 7 y 8, colonia Valle de Puebla C.P. 21384, Mexicali, Baja California, y con R.F.C. WASF5808131R3"
            cTestigo2 = "Llamarse Sandra Isabel Duarte Díaz, manifiesta por sus generales ser de nacionalidad mexicana, originaria de Mexicali, Baja California, lugar donde nació el día 23 de septiembre de 1978, de profesión Técnica Agropecuaria, con domicilio en Av. Río San Ángel 48 Locales 7 y 8, colonia Valle de Puebla C.P. 21384, Mexicali, Baja California, y con R.F.C. DUDS780923HK8"
            cFirmaTestigo1 = "ING. FRANCISCO KOZO WAKIDA SUZUKI"
            cFirmaTestigo2 = "T.A. SANDRA ISABEL DUARTE DIAZ"
        ElseIf drAnexo("Sucursal") = "05" Then
            cTestigo1 = "Llamarse Albino Rosendo Ramirez Aguilar, manifiesta por sus generales ser de nacionalidad mexicana, originario de la ciudad de Irapuato, Guanajuato, lugar donde nació el día 03 de enero de 1981, de profesión Ingeniero Agrónomo, con domicilio en Av. de los Insurgentes 2604 Local B-4, colonia Los Fresnos C.P. 36555, Irapuato, Guanajuato, y con R.F.C. RAAA810103HH3"
            cTestigo2 = "Llamarse Raúl Armando Venegas Miranda, manifiesta por sus generales ser de nacionalidad mexicana, originaria de Irapuato, Guanajuato, lugar donde nació el día 01 uno de enero de 1978, de profesión Ingeniero, con domicilio en Av. de los Insurgentes 2604 Local B-4, colonia Los Fresnos C.P. 36555, Irapuato, Guanajuato, y con R.F.C. VEMR780101183"
            cFirmaTestigo1 = "ING. ALBINO ROSENDO RAMIREZ AGUILAR"
            cFirmaTestigo2 = "ING. RAUL ARMANDO VENEGAS MIRANDA"
        ElseIf drAnexo("Sucursal") = "07" Then
            cTestigo1 = "Llamarse Carlos Mejía González, manifiesta por sus generales ser de nacionalidad mexicana, originario de la ciudad de México D.F., Distrito Federal, lugar donde nació el día 11 de febrero de 1970, de profesión Licenciado en Administración de Empresas, con domicilio en Boulevard Manuel Ávila Camacho # 99 2do. Piso, colonia Alce Blanco C.P. 53370, Naucalpan, Estado de México, y con R.F.C. MEGC700211MU9"
            cTestigo2 = "Llamarse Geraldo García Velez, manifiesta por sus generales ser de nacionalidad mexicana, originario de la ciudad de Toluca, Estado de México, lugar donde nació el día 13 de marzo de 1970, de profesión Contador Público, con domicilio en Leandro Valle No. 402, colonia Reforma y FFCCNN, C.P. 50070, Toluca, Estado de México, y con R.F.C. GAVG700313"
            cFirmaTestigo1 = "LAE. CARLOS MEJIA GONZALEZ"
            cFirmaTestigo2 = "C.P. GERALDO GARCIA VELEZ"

        End If

        cFirmaTestigo1 = Chr(10) & Chr(10) & Chr(10) & Chr(10) & "PRIMER TESTIGO" & Chr(10) & Chr(10) & Chr(10) & ReplicateString("_", Len(cFirmaTestigo1) + 6) & Chr(10) & cFirmaTestigo1
        cFirmaTestigo2 = Chr(10) & Chr(10) & Chr(10) & Chr(10) & "SEGUNDO TESTIGO" & Chr(10) & Chr(10) & Chr(10) & ReplicateString("_", Len(cFirmaTestigo2) + 6) & Chr(10) & cFirmaTestigo2

        If cTipta = "7" Then
            cLeyenda = "Este documento no tiene ninguna validez legal ya que es solo hipotética, "
            cLeyenda = cLeyenda & " ejemplificativa e ilustrativa, toda vez que para la elboración de esta tabla"
            cLeyenda = cLeyenda & " se tomó como base los meses con 30 días, por lo que puede haber variación"
            cLeyenda = cLeyenda & " de acuerdo al número real de días que tenga cada mes."
        Else
            cLeyenda = "Este documento no tiene ninguna validez legal ya que es solo hipotética, "
            cLeyenda = cLeyenda & " ejemplificativa e ilustrativa, por ser imposible conocer la variación de las"
            cLeyenda = cLeyenda & " tasas en el futuro, en consecuencia no implica obligación alguna para la"
            cLeyenda = cLeyenda & " SOFOM."
        End If

        If drAnexo("Tipo") = "M" Then
            cPersFirman = "PERSONAS QUE FIRMAN EN REPRESENTACIÓN DE LA EMPRESA: " & Trim(cCusnam) & " " & cRepresentante
        Else
            If drAnexo("Coac") = "C" And drAnexo("Tipcoac") <> "M" And Trim(drAnexo("Nomcoac")) <> "" Then
                cPersFirman = "COACREDITADO: " & Trim(drAnexo("Nomcoac"))
            ElseIf drAnexo("Coac") = "C" And drAnexo("Tipcoac") = "M" And Trim(drAnexo("Nomrcoac")) <> "" Then
                cPersFirman = "COACREDITADO: " & Trim(drAnexo("Nomcoac")) & " REPRESENTADO EN ESTE ACTO POR " & Trim(drAnexo("Nomrcoac"))
            End If
        End If

        If cTipar = "F" Then
            oRuta = "F:\Contrato AF.doc"
            'oRuta = "C:\Contrato AF.doc"
        ElseIf cTipar = "P" Then
            oRuta = "F:\Contrato AP.doc"
        ElseIf cTipar = "R" Then
            oRuta = "F:\Contrato CR.doc"
            'oRuta = "C:\Contratos\Contratos\Contrato CR.doc"
        ElseIf cTipar = "S" Then
            oRuta = "F:\Contrato CS.doc"
        End If

        oWord = New Microsoft.Office.Interop.Word.Application()

        oWordDoc = New Microsoft.Office.Interop.Word.Document()

        ' Cargo la plantilla  

        oWordDoc = oWord.Documents.Add(oRuta, oNulo, oNulo, oNulo)

        cCoberDet2 = "En caso de que el recurso provenga de FIRA, contratar las coberturas para la administración del riesgo de acuerdo a las demandas del proyecto, a la disponibilidad de dichas "
        cCoberDet2 = cCoberDet2 & "coberturas, así como las políticas de riesgo de la SOFOM, tales como seguros, coberturas de precio y de tasas de interés y agricultura por contrato."

        If cTipar = "F" Then
            If cFondeo = "03" Then
                With oWordDoc.Sections(1)
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddPicture("F:\Logo.JPG")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "No. RECA 0073-426-002824/05-14173-1111")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "CONTRATO DE ARRENDAMIENTO FINANCIERO CON RECURSOS FIRA  No. " & Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4)))
                End With
            Else
                With oWordDoc.Sections(1)
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddPicture("F:\Logo.JPG")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "No. RECA 0073-426-002824/05-14173-1111")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "CONTRATO DE ARRENDAMIENTO FINANCIERO No. " & Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4)))
                End With
            End If
        ElseIf cTipar = "R" Then
            If cFondeo = "03" Then
                With oWordDoc.Sections(1)
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddPicture("F:\Logo.JPG")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "No. RECA 0073-137-002825/02-11770-0211")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "CONTRATO DE CREDITO REFACCIONARIO CON RECURSOS FIRA  No. " & Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4)))
                End With
                cCobertura = "COBERTURA(FONAGA, FEGA, FIFAP MUTUAL, ETC.): 1% SOBRE SALDOS INSOLUTOS CONFORME A LA FECHA DE VENCIMIENTO."
                cCoberDet1 = "LAS COBERTURAS ANTERIORES, SE FINANCIARAN, LOS INTERESES SE COMPUTARAN MENSUALMENTE Y SE REFINANCIARAN SUMANDOSE AL SALDO INSOLUTO, PASANDO A FORMAR PARTE DEL CAPITAL "
                cCoberDet1 = cCoberDet1 & "COMO NUEVA BASE DE COMPUTO DE INTERESES DEL MES SIGUIENTE Y ASI SUCESIVAMENTE HASTA QUE SE LLEVE A CABO LA AMORTIZACION PRINCIPAL."
                cCoberDet2 = "En caso de que el recurso provenga de FIRA, contratar las coberturas para la administración del riesgo o las podrá contratar la SOFOM a costa del acreditado de acuerdo a las "
                cCoberDet2 = cCoberDet2 & "demandas del proyecto(FONAGA, FEGA, FIFAP MUTUAL, ETC.), a la disponibilidad de dichas coberturas, así como las políticas de riesgo de la SOFOM, tales como seguros, "
                cCoberDet2 = cCoberDet2 & "coberturas de precio y de tasas de interés y agricultura por contrato."
            Else
                With oWordDoc.Sections(1)
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddPicture("F:\Logo.JPG")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "No. RECA 0073-137-002825/02-11770-0211")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "CONTRATO DE CREDITO REFACCIONARIO  No. " & Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4)))
                End With
            End If
        ElseIf cTipar = "P" Then
            If cFondeo = "03" Then
                With oWordDoc.Sections(1)
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddPicture("F:\Logo.JPG")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "No. RECA 0073-443-007413/01-11768-0211")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "CONTRATO DE ARRENDAMIENTO PURO CON RECURSOS FIRA No. " & Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4)))
                End With
            Else
                With oWordDoc.Sections(1)
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddPicture("F:\Logo.JPG")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "No. RECA 0073-443-007413/01-11768-0211")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "CONTRATO DE ARRENDAMIENTO PURO No. " & Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4)))
                End With
            End If
        ElseIf cTipar = "S" Then
            If cFondeo = "03" Then
                With oWordDoc.Sections(1)
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddPicture("F:\Logo.JPG")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "No. RECA 0073-439-006281/02-11768-0211")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "CONTRATO DE CREDITO SIMPLE CON RECURSOS FIRA No. " & Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4)))
                End With
            Else
                With oWordDoc.Sections(1)
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddPicture("F:\Logo.JPG")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "No. RECA 0073-439-006281/02-11768-0211")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "CONTRATO DE CREDITO SIMPLE No. " & Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4)))
                End With
            End If
        End If

        If cFondeo = "03" Then
            cRecur = " FIRA (X)        NAFIN ( )        PROPIOS ( )"
        ElseIf cFondeo = "02" Then
            cRecur = " FIRA ( )        NAFIN (X)        PROPIOS ( )"
        ElseIf cFondeo = "01" Then
            cRecur = " FIRA ( )        NAFIN ( )        PROPIOS (X)"
        End If

        If cFondeo = "03" Then
            cAporInv = "APORTACION A LA INVERSION: " & FormatNumber((nMtoFin / 0.8) - nMtoFin).ToString & " " & Letras((nMtoFin / 0.8) - nMtoFin) & Chr(10)
        End If

        ' Abro el Contrato

        For Each myMField In oWordDoc.Fields

            rFieldCode = myMField.Code

            cFieldText = rFieldCode.Text

            If cFieldText.StartsWith(" MERGEFIELD") Then

                ' Los campos tienen el formato MERGEFIELD NombreCampo \* MERGETYPE, por lo que con estas sentencias extraemos la parte NombreCampo únicamente

                finMerge = cFieldText.IndexOf("\")

                fieldNameLen = cFieldText.Length - finMerge

                cfName = cFieldText.Substring(11, finMerge - 11)

                ' Guardamos el nombre del campo en la variable, quitándole los espacios en blanco

                cfName = cfName.Trim()

                ' Ahora comprobamos si el nombre del campo coincide con el que nosotros queremos,
                ' y si es asi le aplicamos el valor de la variable

                Select Case cfName

                    Case "mDescr"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Trim(cCusnam)
                    Case "mRepresentante"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Trim(cRepresentante)
                    Case "mCoac"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cCoac
                    Case "mCoac2"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cCoac2
                    Case "mPersFirman"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cPersFirman & Chr(13)
                    Case "mDato1"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Trim(cDato1)
                    Case "mDato7"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Trim(cDato7)
                    Case "mDato8"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cDato8
                    Case "mDato9"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cDato9
                    Case "mCalle"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cCalle
                    Case "mColonia"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cColonia
                    Case "mCopos"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Trim(cCopos)
                    Case "mDelegacion"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Trim(cDelegacion)
                    Case "mEstado"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Trim(cEstado)
                    Case "mFirmaCte"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cFirmaCte.ToUpper
                    Case "mFirmaAval1"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cFirmaAval1.ToUpper
                    Case "mFirmaAval2"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cFirmaAval2.ToUpper
                    Case "mGeneClie"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cGeneClie.ToUpper
                    Case "mFirmaAval3"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cFirmaAval3.ToUpper
                    Case "mFirmaAval4"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cFirmaAval4.ToUpper
                    Case "mFirmaTest1"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cFirmaTestigo1.ToUpper
                    Case "mFirmaTest2"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cFirmaTestigo2.ToUpper
                    Case "mDato10"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cDato10
                    Case "mDato12"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cDato12
                    Case "mDato12A"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cDato12A
                    Case "mDato12B"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cDato12B
                    Case "mDato12C"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cDato12C
                    Case "mAval"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cAval.ToUpper
                    Case "mNota"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cNota
                    Case "mObSol"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cObSol
                    Case "mObSol1"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cObSol1
                    Case "mTasas"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Round(nTasas, 2).ToString & " %"
                    Case "mTasmor"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = nTasmor
                    Case "mFecha"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = MesJuridico(cFechacon)
                    Case "mTotal"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = FormatNumber(nTotal).ToString & " " & Letras(nTotal)
                    Case "mLetraImp"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cLetraImp
                    Case "mPlazo"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = nAmort.ToString & " Pagos distribuidos como se muestra en su Tabla de Amortización"
                    Case "mFeven"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cFvenc
                    Case "mGeneEmp"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cGeneEmp
                    Case "mGenerepr"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cGenerepr
                    Case "mAvales"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cAvales
                    Case "mTestigo1"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cTestigo1
                    Case "mTestigo2"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cTestigo2
                    Case "mLetrast"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cLetrat
                    Case "mFevent"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cFevent
                    Case "mSaldot"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cSaldot
                    Case "mAbcapt"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cAbcapt
                    Case "mIntert"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cIntert
                    Case "mIvat"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cIvat
                    Case "mIvacapt"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cIvaCapt
                    Case "mMtoFin"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = FormatNumber(nMtoFin).ToString & " " & Letras(nMtoFin)
                    Case "mRenta"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cRenta
                    Case "mPagosi"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = FormatNumber(nPagosi).ToString & " " & Letras(nPagosi)
                    Case "mRecur"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cRecur
                    Case "mTaspen"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Round(nTaspen, 2)
                    Case "mBonifica"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cBonifica
                    Case "mPagomen"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cPagomen
                    Case "mAporInv"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cAporInv
                    Case "mCAT"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Round(nCAT, 2).ToString & "%"
                    Case "mLeyenda"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cLeyenda
                    Case "mParrafoInteres"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cParrafoInteres
                    Case "mDetalle"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cDetalle
                    Case "mCobertura"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Chr(10) & cCobertura & Chr(10)
                    Case "mCoberDet1"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Chr(10) & cCoberDet1 & Chr(10)
                    Case "mCoberDet2"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cCoberDet2 & Chr(10)
                    Case "mCobertt2"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cCobert
                    Case "mTotg"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cTotg
                    Case "mPorco"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Round(nPorco, 2).ToString & "%"
                    Case "mDescPI"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cDescPI
                    Case "mImpPI"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cImpPI
                    Case "mTotal2"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        If cFondeo = "03" Then
                            myMField.Result.Text = FormatNumber(nTotal2 + nTotalCobert, 2).ToString & Letras(nTotal2 + nTotalCobert) & " compuestos por Monto Financiado " & FormatNumber(nMtoFin, 2).ToString & " más su Interés por " & FormatNumber(nTotal2 - nMtoFin, 2).ToString & " más su Cobertura por " & FormatNumber(nTotalCobert, 2).ToString
                        Else
                            myMField.Result.Text = FormatNumber(nTotal2 + nCobertura, 2).ToString & Letras(nTotal2 + nCobertura) & " compuestos por Monto Financiado " & FormatNumber(nMtoFin, 2).ToString & " más su Interés por " & FormatNumber(nTotal2 - nMtoFin, 2).ToString
                        End If
                End Select

                oWord.Selection.Fields.Update()

            End If

        Next

        'Guardo el documento

        Dim Format As Object = Word.WdSaveFormat.wdFormatDocumentDefault
        Dim oMissing = System.Reflection.Missing.Value

        oWord.ActiveDocument.Select()
        oWord.WordBasic.ToString()
        oWord.Visible = True

        Dim oSaveAsFile = "C:\Contratos\" & Trim(cCusnam) & "_CTO_" & cContrato & ".doc"

        oWordDoc.SaveAs(oSaveAsFile, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing)

    End Sub

    Private Sub btnAnexoA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnexoA.Click
        If cTipar <> "S" Then

            Dim dsTemporal As New DataSet()
            Dim oNulo As Object = System.Reflection.Missing.Value
            Dim oRuta As New Object
            Dim myMField As Microsoft.Office.Interop.Word.Field
            Dim rFieldCode As Microsoft.Office.Interop.Word.Range
            Dim cFieldText As String
            Dim finMerge As Integer
            Dim fieldNameLen As Integer
            Dim cfName As String
            Dim oWord As New Word.Application
            Dim oWordDoc As Microsoft.Office.Interop.Word.Document

            If cTipta <= "6" Then
                cDescTipta = "TASA PROMEDIO MAXIMA determinada en los términos establecidos en esta cláusula,  del "
            ElseIf cTipta = "7" Then
                cDescTipta = cDescTipta & "TASA FIJA del "
            ElseIf cTipta = "8" Then
                cDescTipta = cDescTipta & "TASA del "
            End If
            cDescTipta = cDescTipta & FormatNumber(Round(nTasas - nDifer, 2), 2).ToString & Cant_Letras(nTasas - nDifer, "")
            If cTipta <= "6" Or cTipta = "8" Then
                cDescTipta = cDescTipta & " más " & FormatNumber(Round(nDifer, 2), 2).ToString & Cant_Letras(nDifer, "") & " puntos "
                cDescTipta = cDescTipta & " porcentuales adicionales."
            ElseIf cTipta = "7" Then
                cDescTipta = cDescTipta & " por ciento anual."
            End If
            If cTipta <= "6" Then
                cDescTipta = cDescTipta & Chr(10) & Chr(10) & "Las rentas estipuladas en este anexo podrán aumentar o disminuir "
                cDescTipta = cDescTipta & "de acuerdo a lo establecido en la cláusula cuarta del Contrato "
                cDescTipta = cDescTipta & "de Arrendamiento Financiero celebrado entre las partes, en el "
                cDescTipta = cDescTipta & "entendido de que para el cálculo de la primera renta se toma "
                cDescTipta = cDescTipta & "como base la tasa de rendimiento neto que resulte de adicionar "
                cDescTipta = cDescTipta & FormatNumber(Round(nDifer, 2), 2) & Cant_Letras(nDifer, "") & " puntos"
                cDescTipta = cDescTipta & "porcentuales sobre la tasa que resulte mayor entre "
                Select Case cTipta
                    Case "1"
                        cDescTipta = cDescTipta & "la tasa TIIP y la tasa TIIE, '"
                    Case "2"
                        cDescTipta = cDescTipta & "la tasa C.P.P., la tasa TIIP y la tasa TIIE, "
                    Case "3"
                        cDescTipta = cDescTipta & "la tasa CETES, la tasa C.P.P. y la tasa TIIP, "
                    Case "4"
                        cDescTipta = cDescTipta & "la tasa CETES, la tasa C.P.P. y la tasa TIIE, "
                    Case "6"
                        cDescTipta = cDescTipta & "la tasa TIIE, "
                End Select
                cDescTipta = cDescTipta & "tal y como las mismas se definen:"
                If cTipta = "3" Or cTipta = "4" Then
                    cDescTipta = cDescTipta & Chr(10) & Chr(10) & "Para los efectos de la presente cláusula se entenderá por tasa CETES la tasa de rendimiento de los Certificados de la "
                    cDescTipta = cDescTipta & "Tesorería de la Federación por emisiones a plazo de 28 (veintiocho) días, determinada en la primera semana de cada "
                    cDescTipta = cDescTipta & "periodo de intereses."
                End If
                If cTipta >= "2" And cTipta <= "4" Then
                    cDescTipta = cDescTipta & Chr(10) & Chr(10) & "Igualmente se entenderá por tasa C.P.P. (Costo Porcentual Promedio), aplicando la tasa vigente al inicio de cada "
                    cDescTipta = cDescTipta & "periodo de intereses.   Dicha tasa significa (i) el Costo Porcentual Promedio de Captación "
                    cDescTipta = cDescTipta & "por concepto de tasa, y en su caso sobretasa de interés, de los pasivos en moneda nacional a cargo de las "
                    cDescTipta = cDescTipta & "Instituciones de Banca Múltiple del país, correspondientes exclusivamente a préstamos a empresas, particulares y a "
                    cDescTipta = cDescTipta & "depósitos a plazo, excepto ahorro, respecto a un mes determinado que el propio Banco de México da a conocer "
                    cDescTipta = cDescTipta & "mensualmente a través del Diario Oficial de la Federación, según resoluciones del mismo, publicadas en ese Diario con "
                    cDescTipta = cDescTipta & "fechas 20 de octubre de 1981 y 17 de noviembre de 1988, o en su defecto, (ii) el Costo Porcentual Promedio que en su "
                    cDescTipta = cDescTipta & "caso sustituya al anterior por determinación de las autoridades competentes."
                End If
                If cTipta <= "3" Then
                    cDescTipta = cDescTipta & Chr(10) & Chr(10) & "Se entenderá por tasa TIIP (Tasa de Interés Interbancaria Promedio) la tasa de rendimiento anual, equivalente a 28 días, que sea o sean "
                    cDescTipta = cDescTipta & "publicadas por el Banco de México en el Diario Oficial de la Federación, vigente al inicio de cada periodo de intereses."
                End If
                If cTipta = "1" Or cTipta = "2" Or cTipta = "4" Or cTipta = "6" Then
                    cDescTipta = cDescTipta & Chr(10) & Chr(10) & "Se entenderá por tasa TIIE (Tasa de Interés Interbancaria de Equilibrio) la tasa de rendimiento anual, equivalente a 28 días, "
                    cDescTipta = cDescTipta & "que sea o sean publicadas por el Banco de México en el Diario Oficial de la Federación, vigente al inicio de cada periodo "
                    cDescTipta = cDescTipta & "de intereses."
                End If
                If cTipta <= "6" Then
                    cDescTipta = cDescTipta & Chr(10) & Chr(10) & "Los intereses siempre se computarán sobre la base de un año de 360 (trescientos sesenta) días por el número de días "
                    cDescTipta = cDescTipta & "efectivamente transcurridos."
                End If
                If cForca = "4" Then
                    cDescTipta = cDescTipta & Chr(10) & Chr(10) & "Para la determinaci¢n mensual del DIFERENCIAL aplicable a partir del segundo vencimiento, se multiplicar  la Tasa "
                    cDescTipta = cDescTipta & "Promedio M xima vigente en ese mes, por el factor de " & FormatNumber(nFactor, 2).ToString & Cant_Letras(nFactor, "")
                    cDescTipta = cDescTipta & "El resultado de la operaci¢n anterior ser  el DIFERENCIAL aplicable mismo que no podr  ser menor a "
                    cDescTipta = cDescTipta & FormatNumber(nPiso, 2).ToString & Cant_Letras(nPiso, "") & " puntos porcentuales ni mayor a "
                    cDescTipta = cDescTipta & FormatNumber(nTecho, 2) & Cant_Letras(nTecho, "") & "puntos porcentuales. A lo dispuesto en este p rrafo le "
                    cDescTipta = cDescTipta & "ser  aplicable lo establecido en la cláusula cuarta del Contrato de Arrendamiento Financiero No. "
                    cDescTipta = cDescTipta & Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4)
                End If
            End If
            If cTipta = "8" Then
                cDescTipta = cDescTipta & Chr(10) & Chr(10) & "Las rentas estipuladas en este anexo podrán aumentar o disminuir de acuerdo a lo establecido en la cláusula cuarta del Contrato "
                cDescTipta = cDescTipta & "de Arrendamiento Financiero celebrado entre las partes, en el entendido de que para el cálculo de la primera renta se toma "
                cDescTipta = cDescTipta & "como base la tasa de rendimiento neto que resulte de adicionar " & FormatNumber(nDifer, 2).ToString & Cant_Letras(nDifer, "") & " puntos"
                cDescTipta = cDescTipta & "porcentuales al valor de la tasa TIIE la cual tendrá un valor máximo de " & FormatNumber(12, 2).ToString & " porciento anual.  Se entender  por tasa TIIE (Tasa de Interés Interbancaria de "
                cDescTipta = cDescTipta & "Equilibrio) la tasa de rendimiento anual, equivalente a 28 días, que sea o sean publicadas por el Banco de M‚xico en el Diario "
                cDescTipta = cDescTipta & "Oficial de la Federación, vigente al inicio de cada periodo de intereses."
            End If

            If nImpRD > 0 Then
                cDescDepGar = "VI.- DEPOSITO EN GARANTIA :"
                cDescDepGar = cDescDepGar & Chr(10) & Chr(10) & "Conforme a la cláusula decima primera del Contrato de Arrendamiento Financiero, la ARRENDATARIA entrega en el acto de firma del presente anexo, la cantidad de " & FormatNumber(nImpRD) & Letras(nImpRD)
                cDescDepGar = cDescDepGar & Chr(10) & Chr(10) & "En caso de que la ARRENDADORA tuviera que aplicar dicha cantidad de acuerdo a lo establecido en la cláusula antes citada, la ARRENDATARIA deberá resarcirla con la cantidad equivalente a la última parcialidad que debió haber pagado."
            End If

            If cFondeo = "03" Then
                oRuta = "F:\Anexo_ACR.doc"
                'oRuta = "C:\Contratos\Anexo_ACR.doc"
            Else
                oRuta = "F:\Anexo_A.doc"
            End If

            oWord = New Microsoft.Office.Interop.Word.Application()
            oWordDoc = New Microsoft.Office.Interop.Word.Document()

            ' Cargo la plantilla

            oWordDoc = oWord.Documents.Add(oRuta, oNulo, oNulo, oNulo)

            If cTipar = "F" Then
                With oWordDoc.Sections(1)
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddPicture("F:\Logo.JPG")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "No. RECA 0073-426-002824")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "ANEXO A del Contrato No. " & Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4)))
                End With
            ElseIf cTipar = "R" Then
                With oWordDoc.Sections(1)
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddPicture("F:\Logo.JPG")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "No. RECA 0073-137-002825")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "ANEXO A del Contrato No. " & Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4)))
                End With
            ElseIf cTipar = "P" Then
                With oWordDoc.Sections(1)
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddPicture("F:\Logo.JPG")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "No. RECA 0073-443-007413")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "ANEXO A del Contrato No. " & Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4)))
                End With
            ElseIf cTipar = "S" Then
                With oWordDoc.Sections(1)
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddPicture("F:\Logo.JPG")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "No. RECA 0073-439-006281")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "ANEXO A del Contrato No. " & Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4)))
                End With
            End If

            For Each myMField In oWordDoc.Fields

                rFieldCode = myMField.Code

                cFieldText = rFieldCode.Text

                If cFieldText.StartsWith(" MERGEFIELD") Then

                    ' Los campos tienen el formato MERGEFIELD NombreCampo \* MERGETYPE, por lo que con estas sentencias extraemos la parte NombreCampo únicamente

                    finMerge = cFieldText.IndexOf("\")

                    fieldNameLen = cFieldText.Length - finMerge

                    cfName = cFieldText.Substring(11, finMerge - 11)

                    ' Guardamos el nombre del campo en la variable, quitándole los espacios en blanco

                    cfName = cfName.Trim()

                    ' Ahora comprobamos si el nombre del campo coincide con el que nosotros queremos,
                    ' y si es asi le aplicamos el valor de la variable

                    Select Case cfName

                        Case "mContrato"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4))
                        Case "mDescr"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = Trim(cCusnam)
                        Case "mRepresentante"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = Trim(cRepresentante)
                        Case "mCoac"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cCoac
                        Case "mAval"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cAval.ToUpper
                        Case "mFirmaCte"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cFirmaCte.ToUpper
                        Case "mFirmaAval1"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cFirmaAval1.ToUpper
                        Case "mFirmaAval2"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cFirmaAval2.ToUpper
                        Case "mFirmaAval3"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cFirmaAval3.ToUpper
                        Case "mFirmaAval4"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cFirmaAval4.ToUpper
                        Case "mObSol"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cObSol
                        Case "mObSol1"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cObSol1
                        Case "mFecha"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = Mes(cFechacon)
                        Case "mDescTipta"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cDescTipta
                        Case "mLugar"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cLugar
                        Case "mBienes"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cBienes
                        Case "mBienes2"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cBienes2
                        Case "mRefCliente"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cRefCliente
                        Case "mLetrast"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cLetrat
                        Case "mFevent"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cFevent
                        Case "mSaldot"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cSaldot
                        Case "mAbcapt"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cAbcapt
                        Case "mIntert"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cIntert
                        Case "mIvat"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cIvat
                        Case "mIvacapt"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cIvaCapt
                        Case "mPagomen"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cPagomen
                        Case "mCobertt2"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cCobert
                        Case "mTotg"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cTotg
                        Case "mTotal"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = FormatNumber(nTotal, 2).ToString
                        Case "mImpEq"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = FormatNumber(nImpEq).ToString & " " & Letras(nImpEq)
                        Case "mSaldo"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = FormatNumber(nSaldo).ToString & " " & Letras(nSaldo)
                        Case "mProducto"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cProducto
                        Case "mProduc"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            If cFondeo = "03" Then
                                myMField.Result.Text = Mid(cProducto, 1, cProducto.Length - 18)
                            Else
                                myMField.Result.Text = cProducto
                            End If
                        Case "mImpDG"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = FormatNumber(nDepg, 2).ToString
                        Case "mIvaEq"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = FormatNumber(nIvaEq, 2).ToString & " " & Letras(nIvaEq)
                        Case "mComis"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = FormatNumber(nComis / (1 + nPorInt), 2).ToString
                        Case "mIvaComis"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = FormatNumber((nComis / (1 + nPorInt)) * nPorInt)
                        Case "mOpcion"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = FormatNumber(nOpcion) & Letras(nOpcion)
                        Case "mTotal2"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            If cFondeo = "03" Then
                                myMField.Result.Text = FormatNumber(nTotal2 + nTotalCobert, 2).ToString & Letras(nTotal2 + nTotalCobert) & " compuestos por Monto Financiado " & FormatNumber(nMtoFin, 2).ToString & " más su Interés por " & FormatNumber(nTotal2 - nMtoFin, 2).ToString & " más su Cobertura por " & FormatNumber(nTotalCobert, 2).ToString
                            Else
                                myMField.Result.Text = FormatNumber(nTotal2 + nCobertura, 2).ToString & Letras(nTotal2 + nCobertura) & " compuestos por Monto Financiado " & FormatNumber(nMtoFin, 2).ToString & " más su Interés por " & FormatNumber(nTotal2 - nMtoFin, 2).ToString
                            End If
                        Case "mFeven"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cFvenc
                        Case "mFevig"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = Mes(cFevig)
                        Case "mTermino"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = Mes(cFecha1)
                        Case "mTipar"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cProducto
                        Case "mTasas"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = Round(nTasas, 2)
                        Case "mTasmor"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = Round(nTasas * nTasmor, 2)
                        Case "mTaspen"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = Round(nTaspen, 2)
                        Case "mDescPI"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cDescPI
                        Case "mImpPI"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cImpPI
                        Case "mDiaPago"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cDiaPago
                        Case "mDescFrecuencia"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cDescFrecuencia
                        Case "mDescDepGar"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cDescDepGar
                        Case "mUnidadEsp"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cUnidadEsp
                        Case "mCAT"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = Round(nCAT, 2).ToString & "%"
                    End Select

                    oWord.Selection.Fields.Update()

                End If

            Next

            'Guardo el documento

            Dim Format As Object = Word.WdSaveFormat.wdFormatDocumentDefault
            Dim oMissing = System.Reflection.Missing.Value

            oWord.ActiveDocument.Select()
            oWord.WordBasic.ToString()
            oWord.Visible = True

            Dim oSaveAsFile = "C:\contratos\" & cCusnam & "_A_" & cContrato & ".doc"

            oWordDoc.SaveAs(oSaveAsFile, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing)

        Else
            MsgBox("El Anexo A no Aplica en Crédito Simple", MsgBoxStyle.Information)
        End If

    End Sub

    Private Sub btnAnexoB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnexoB.Click

        If cTipar <> "S" Then

            Dim oNulo As Object = System.Reflection.Missing.Value
            Dim oRuta As New Object
            Dim myMField As Microsoft.Office.Interop.Word.Field
            Dim rFieldCode As Microsoft.Office.Interop.Word.Range
            Dim cFieldText As String
            Dim finMerge As Integer
            Dim fieldNameLen As Integer
            Dim cfName As String
            Dim oWord As New Word.Application
            Dim oWordDoc As Microsoft.Office.Interop.Word.Document

            oRuta = "F:\Anexo_B.doc"

            oWord = New Microsoft.Office.Interop.Word.Application()

            oWordDoc = New Microsoft.Office.Interop.Word.Document()

            ' Cargo la plantilla

            oWordDoc = oWord.Documents.Add(oRuta, oNulo, oNulo, oNulo)

            If cTipar = "F" Then
                With oWordDoc.Sections(1)
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddPicture("F:\Logo.JPG")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "No. RECA 0073-426-002824")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "ANEXO B del Contrato No. " & Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4)))
                End With
            ElseIf cTipar = "R" Then
                With oWordDoc.Sections(1)
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddPicture("F:\Logo.JPG")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "No. RECA 0073-137-002825")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "ANEXO B del Contrato No. " & Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4)))
                End With
            ElseIf cTipar = "P" Then
                With oWordDoc.Sections(1)
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddPicture("F:\Logo.JPG")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "No. RECA 0073-443-007413")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "ANEXO B del Contrato No. " & Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4)))
                End With
            ElseIf cTipar = "S" Then
                With oWordDoc.Sections(1)
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddPicture("F:\Logo.JPG")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "No. RECA 0073-439-006281")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "ANEXO B del Contrato No. " & Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4)))
                End With
            End If

            ' Abro el Contrato

            For Each myMField In oWordDoc.Fields

                rFieldCode = myMField.Code

                cFieldText = rFieldCode.Text

                If cFieldText.StartsWith(" MERGEFIELD") Then

                    ' Los campos tienen el formato MERGEFIELD NombreCampo \* MERGETYPE, por lo que con estas sentencias extraemos la parte NombreCampo únicamente

                    finMerge = cFieldText.IndexOf("\")

                    fieldNameLen = cFieldText.Length - finMerge

                    cfName = cFieldText.Substring(11, finMerge - 11)

                    ' Guardamos el nombre del campo en la variable, quitándole los espacios en blanco

                    cfName = cfName.Trim()

                    ' Ahora comprobamos si el nombre del campo coincide con el que nosotros queremos,
                    ' y si es asi le aplicamos el valor de la variable

                    Select Case cfName

                        Case "mDescr"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = Trim(cCusnam)
                        Case "mRepresentante"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = Trim(cRepresentante)
                        Case "mCoac"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cCoac
                        Case "mFirmaCte"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cFirmaCte.ToUpper
                        Case "mFirmaAval1"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cFirmaAval1.ToUpper
                        Case "mFirmaAval2"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cFirmaAval2.ToUpper
                        Case "mFirmaAval3"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cFirmaAval3.ToUpper
                        Case "mFirmaAval4"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cFirmaAval4.ToUpper
                        Case "mObSol"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cObSol
                        Case "mObSol1"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cObSol1
                        Case "mFecha"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = Mes(cFechacon)
                        Case "mRefProdgral"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cRefProdgral
                        Case "mRefProducto"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cRefProducto
                        Case "mRefCliente"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cRefCliente
                        Case "mAval"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cAval
                        Case "mProducto"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cProducto
                        Case "mBienes"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cBienes
                        Case "mPersonaAut"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cPersonaAut
                    End Select

                    oWord.Selection.Fields.Update()

                End If

            Next

            'Guardo el documento

            Dim Format As Object = Word.WdSaveFormat.wdFormatDocumentDefault
            Dim oMissing = System.Reflection.Missing.Value

            oWord.ActiveDocument.Select()
            oWord.WordBasic.ToString()
            oWord.Visible = True

            Dim oSaveAsFile = "C:\contratos\" & cCusnam & "_B_" & cContrato & ".doc"

            oWordDoc.SaveAs(oSaveAsFile, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing)
        Else
            MsgBox("El Anexo B no Aplica en Crédito Simple", MsgBoxStyle.Information)
        End If

    End Sub

    Private Sub btnAnexoC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnexoC.Click

        If cPrenda = "S" Then

            Dim oNulo As Object = System.Reflection.Missing.Value
            Dim oRuta As New Object
            Dim myMField As Microsoft.Office.Interop.Word.Field
            Dim rFieldCode As Microsoft.Office.Interop.Word.Range
            Dim cFieldText As String
            Dim finMerge As Integer
            Dim fieldNameLen As Integer
            Dim cfName As String
            Dim oWord As New Word.Application
            Dim oWordDoc As Microsoft.Office.Interop.Word.Document

            oRuta = "F:\Anexo_C.doc"

            oWord = New Microsoft.Office.Interop.Word.Application()

            oWordDoc = New Microsoft.Office.Interop.Word.Document()

            ' Cargo la plantilla

            oWordDoc = oWord.Documents.Add(oRuta, oNulo, oNulo, oNulo)

            If cTipar = "F" Then
                With oWordDoc.Sections(1)
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddPicture("F:\Logo.JPG")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "No. RECA 0073-426-002824")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "ANEXO C del Contrato No. " & Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4)))
                End With
            ElseIf cTipar = "R" Then
                With oWordDoc.Sections(1)
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddPicture("F:\Logo.JPG")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "No. RECA 0073-137-002825")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "ANEXO C del Contrato No. " & Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4)))
                End With
            ElseIf cTipar = "P" Then
                With oWordDoc.Sections(1)
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddPicture("F:\Logo.JPG")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "No. RECA 0073-443-007413")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "ANEXO C del Contrato No. " & Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4)))
                End With
            ElseIf cTipar = "S" Then
                With oWordDoc.Sections(1)
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddPicture("F:\Logo.JPG")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "No. RECA 0073-439-006281")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "ANEXO C del Contrato No. " & Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4)))
                End With
            End If

            ' Abro el Contrato

            For Each myMField In oWordDoc.Fields

                rFieldCode = myMField.Code

                cFieldText = rFieldCode.Text

                If cFieldText.StartsWith(" MERGEFIELD") Then

                    ' Los campos tienen el formato MERGEFIELD NombreCampo \* MERGETYPE, por lo que con estas sentencias extraemos la parte NombreCampo únicamente

                    finMerge = cFieldText.IndexOf("\")

                    fieldNameLen = cFieldText.Length - finMerge

                    cfName = cFieldText.Substring(11, finMerge - 11)

                    ' Guardamos el nombre del campo en la variable, quitándole los espacios en blanco

                    cfName = cfName.Trim()

                    ' Ahora comprobamos si el nombre del campo coincide con el que nosotros queremos,
                    ' y si es asi le aplicamos el valor de la variable

                    Select Case cfName

                        Case "mDescr"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = Trim(cCusnam)
                        Case "mRepresentante"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = Trim(cRepresentante)
                        Case "mCoac"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cCoac
                        Case "mFirmaCte"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cFirmaCte.ToUpper
                        Case "mFirmaAval1"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cFirmaAval1.ToUpper
                        Case "mFirmaAval2"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cFirmaAval2.ToUpper
                        Case "mFirmaAval3"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cFirmaAval3.ToUpper
                        Case "mFirmaAval4"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cFirmaAval4.ToUpper
                        Case "mObSol"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cObSol
                        Case "mTitulo1"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cTitulo1
                        Case "mGeneClie"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cGeneClie.ToUpper
                        Case "mRefProdgral"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cRefProdgral
                        Case "mRefCliente"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cRefCliente
                        Case "mAval"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cAval
                        Case "mProducto"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cProducto
                        Case "mDato7"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cDato7
                        Case "mCoac2"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cCoac2
                        Case "mDato8"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cDato8
                        Case "mDato9"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cDato9
                        Case "mDato10"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cDato10
                        Case "mCalle"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cCalle
                        Case "mColonia"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cColonia
                        Case "mCopos"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = Trim(cCopos)
                        Case "mDelegacion"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = Trim(cDelegacion)
                        Case "mEstado"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = Trim(cEstado)
                        Case "mDescPrenda"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cDescPrenda
                    End Select

                    oWord.Selection.Fields.Update()

                End If

            Next

            'Guardo el documento

            Dim Format As Object = Word.WdSaveFormat.wdFormatDocumentDefault
            Dim oMissing = System.Reflection.Missing.Value

            oWord.ActiveDocument.Select()
            oWord.WordBasic.ToString()
            oWord.Visible = True

            Dim oSaveAsFile = "C:\contratos\" & cCusnam & "_C_" & cContrato & ".doc"

            oWordDoc.SaveAs(oSaveAsFile, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing)

        Else
            MsgBox("Este contrato No tiene Garantía prendaria", MsgBoxStyle.Information)
        End If

    End Sub

    Private Sub btnRatif_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRatif.Click

        Dim dsTemporal As New DataSet()
        Dim oNulo As Object = System.Reflection.Missing.Value
        Dim oRuta As New Object
        Dim myMField As Microsoft.Office.Interop.Word.Field
        Dim rFieldCode As Microsoft.Office.Interop.Word.Range
        Dim cFieldText As String
        Dim finMerge As Integer
        Dim fieldNameLen As Integer
        Dim cfName As String
        Dim drAnexo As DataRow
        Dim drTotal As DataRow
        Dim oWord As New Word.Application
        Dim oWordDoc As Microsoft.Office.Interop.Word.Document

        ' Declaración de variables de datos

        Dim cFeven As String
        Dim nCount As Integer

        dsTemporal.ReadXml("C:\Archivos de Programa\Agil\Schema2.xml")

        drAnexo = dsTemporal.Tables("Contrato").Rows(0)

        If Trim(drAnexo("Nomrepr")) <> "" Or Trim(drAnexo("Nomrepr2")) <> "" Then
            If LTrim(drAnexo("Nomrepr2")) <> "" Then
                cRepresentante = "REPRESENTADA EN ESTE ACTO POR " & LTrim(drAnexo("Nomrepr")) & " Y POR " & LTrim(drAnexo("Nomrepr2"))
            Else
                cRepresentante = "REPRESENTADA EN ESTE ACTO POR " & LTrim(drAnexo("Nomrepr"))
            End If
        End If

        If drAnexo("Coac") = "C" Then
            If Trim(drAnexo("Nomrcoac")) <> "" And (drAnexo("Tipar") = "F" Or drAnexo("Tipar") = "P") Then
                cCoac = " Y " & drAnexo("Nomcoac") & " COMO COARRENDATARIO REPRESENTADA POR " & drAnexo("Nomrcoac")
            ElseIf Trim(drAnexo("Nomcoac")) <> "" And (drAnexo("Tipar") = "F" Or drAnexo("Tipar") = "P") Then
                cCoac = " Y " & drAnexo("Nomcoac") & " COMO COARRENDATARIO "
            ElseIf Trim(drAnexo("Nomrcoac")) <> "" And (drAnexo("Tipar") = "R" Or drAnexo("Tipar") = "S") Then
                cCoac = " Y " & drAnexo("Nomcoac") & " COMO COACREDITADO REPRESENTADA POR " & drAnexo("Nomrcoac")
            ElseIf Trim(drAnexo("Nomcoac")) <> "" And (drAnexo("Tipar") = "R" Or drAnexo("Tipar") = "S") Then
                cCoac = " Y " & drAnexo("Nomcoac") & " COMO COACREDITADO "
            End If
        End If

        oRuta = "F:\RATIFICACION.doc"

        oWord = New Microsoft.Office.Interop.Word.Application()

        oWordDoc = New Microsoft.Office.Interop.Word.Document()

        ' Cargo la plantillatR

        oWordDoc = oWord.Documents.Add(oRuta, oNulo, oNulo, oNulo)

        If cTipar = "F" Then
            If cFondeo = "03" Then
                With oWordDoc.Sections(1)
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddPicture("F:\Logo.JPG")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "No. RECA 0073-426-002824")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "RATIFICACION DEL CONTRATO DE ARRENDAMIENTO FINANCIERO CON RECURSOS FIRA No. " & Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4)))
                End With
            Else
                With oWordDoc.Sections(1)
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddPicture("F:\Logo.JPG")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "No. RECA 0073-426-002824")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "RATIFICACION DEL CONTRATO DE ARRENDAMIENTO FINANCIERO No. " & Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4)))
                End With
            End If
        ElseIf cTipar = "P" Then
            With oWordDoc.Sections(1)
                .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddPicture("F:\Logo.JPG")
                .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "No. RECA 0073-443-007413")
                .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "RATIFICACION DEL CONTRATO DE ARRENDAMIENTO PURO No. " & Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4)))
            End With
        ElseIf cTipar = "R" Then
            If cFondeo = "03" Then
                With oWordDoc.Sections(1)
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddPicture("F:\Logo.JPG")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "No. RECA 0073-137-002825")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "RATIFICACION DEL CONTRATO DE CREDITO REFACCIONARIO CON RECURSOS FIRA No. " & Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4)))
                End With
            Else
                With oWordDoc.Sections(1)
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddPicture("F:\Logo.JPG")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "No. RECA 0073-137-002825")
                    .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "RATIFICACION DEL CONTRATO DE CREDITO REFACCIONARIO No. " & Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4)))
                End With

            End If
        ElseIf cTipar = "S" Then
            With oWordDoc.Sections(1)
                .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddPicture("F:\Logo.JPG")
                .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "No. RECA 0073-439-006281")
                .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "RATIFICACION DEL CONTRATO DE CREDITO SIMPLE No. " & Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4)))
            End With
        End If

        ' Abro el Contrato

        For Each myMField In oWordDoc.Fields

            rFieldCode = myMField.Code

            cFieldText = rFieldCode.Text

            If cFieldText.StartsWith(" MERGEFIELD") Then

                ' Los campos tienen el formato MERGEFIELD NombreCampo \* MERGETYPE, por lo que con estas sentencias extraemos la parte NombreCampo únicamente

                finMerge = cFieldText.IndexOf("\")

                fieldNameLen = cFieldText.Length - finMerge

                cfName = cFieldText.Substring(11, finMerge - 11)

                ' Guardamos el nombre del campo en la variable, quitándole los espacios en blanco

                cfName = cfName.Trim()

                ' Ahora comprobamos si el nombre del campo coincide con el que nosotros queremos,
                ' y si es asi le aplicamos el valor de la variable

                Select Case cfName

                    Case "mContrato"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 7, 4))
                    Case "mDescr"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Trim(cCusnam)
                    Case "mRepresentante"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Trim(cRepresentante)
                    Case "mCoac"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cCoac
                    Case "mFirmaCte"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cFirmaCte.ToUpper
                    Case "mFirmaAval1"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cFirmaAval1.ToUpper
                    Case "mFirmaAval2"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cFirmaAval2.ToUpper
                    Case "mFirmaAval3"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cFirmaAval3.ToUpper
                    Case "mFirmaAval4"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cFirmaAval4.ToUpper
                    Case "mObSol"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cObSol
                    Case "mObSol1"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cObSol1
                    Case "mFecha"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Mes(cFechacon)
                    Case "mLugar"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cLugar
                    Case "mNotario"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cNotario
                    Case "mRefProdgral"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cRefProdgral
                    Case "mRefCliente"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cRefCliente
                    Case "mAval"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cAval
                    Case "mProducto"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cProducto
                End Select

                oWord.Selection.Fields.Update()

            End If

        Next

        'Guardo el documento

        Dim Format As Object = Word.WdSaveFormat.wdFormatDocumentDefault
        Dim oMissing = System.Reflection.Missing.Value

        oWord.ActiveDocument.Select()
        oWord.WordBasic.ToString()
        oWord.Visible = True

        Dim oSaveAsFile = "C:\contratos\" & cCusnam & "_RAT_" & cContrato & ".doc"

        oWordDoc.SaveAs(oSaveAsFile, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing)

    End Sub

    Private Function AcumulaSdo(ByVal cAnexo As String, ByVal cFecha As String) As Decimal

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim dsAgil As New DataSet()
        Dim daSaldos As New SqlDataAdapter(cm1)
        Dim drDato As DataRow

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DameAnexo1"
            .Connection = cnAgil
            .Parameters.Add("@cAnexo", SqlDbType.NVarChar)
            .Parameters.Add("@cFecha", SqlDbType.NVarChar)
            .Parameters(0).Value = cAnexo
            .Parameters(1).Value = cFecha
        End With

        daSaldos.Fill(dsAgil, "Anexo")
        If dsAgil.Tables("Anexo").Rows.Count > 0 Then
            drDato = dsAgil.Tables("Anexo").Rows(0)
            AcumulaSdo += drDato("Saldo")
        End If
        dsAgil.Tables.Remove("Anexo")

        dsAgil = Nothing
        cnAgil.Dispose()
        cm1.Dispose()

    End Function

    Private Sub TraeDatos()

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim cm4 As New SqlCommand()
        Dim cm5 As New SqlCommand()
        Dim cm6 As New SqlCommand()
        Dim dsAgil As New DataSet()
        Dim daDatoscon As New SqlDataAdapter(cm1)
        Dim daAnexo As New SqlDataAdapter(cm2)
        Dim daEdoctav As New SqlDataAdapter(cm3)
        Dim daTabla As New SqlDataAdapter(cm4)
        Dim daSaldo As New SqlDataAdapter(cm5)
        Dim daRentas As New SqlDataAdapter(cm6)
        Dim drAnexo As DataRow
        Dim drRiesgo As DataRow
        Dim drRentas As DataRow
        Dim drTabla As DataRow
        Dim drEquipo As DataRow
        Dim drEdoctav As DataRow
        Dim drAnexos As DataRowCollection
        Dim drRiesgos As DataRowCollection
        Dim dtRiesgo As New DataTable("Riesgo")

        ' Declaración de variables de datos

        Dim cFecha As String
        Dim cFeven As String
        Dim cFven1 As String
        Dim cPlaza As String
        Dim nCount As Integer
        Dim nDiasp As Integer
        Dim nPanual As Integer
        Dim nTIR As Decimal
        Dim nDato2 As Decimal
        Dim i As Integer
        Dim P As Integer

        cContrato = Mid(txtAnexo.Text, 1, 5) & Mid(txtAnexo.Text, 7, 4)
        cFecha = DTOC(Today)

        ' Obtengo los Datos Generales del Contrato

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DatosCon2"
            .Connection = cnAgil
            .Parameters.Add("@Anexo", SqlDbType.NVarChar)
            .Parameters(0).Value = cContrato
        End With

        daDatoscon.Fill(dsAgil, "Contrato")
        drAnexos = dsAgil.Tables("Contrato").Rows

        For Each drAnexo In drAnexos
            cAnexo = drAnexo("Anexo")
            cFondeo = drAnexo("Fondeo")
            cFlcan = drAnexo("Flcan")
            cCusnam = drAnexo("Cusnam")
            cCliente = drAnexo("Cliente")
            cFechacon = drAnexo("Fechacon")
            cPrenda = drAnexo("Prenda")
            cTipar = drAnexo("Tipar")
            cTipta = drAnexo("Tipta")
            cForca = drAnexo("Forca")
            cPlaza = drAnexo("Plaza")
            cDescTasa = drAnexo("DescTasa")
            cCalle = drAnexo("Calle")
            cColonia = drAnexo("Colonia")
            cCopos = drAnexo("Copos")
            cDelegacion = drAnexo("Delegacion")
            cDescFrecuencia = "como se indica en la Tabla de Amortización"
            cDescRecurso = drAnexo("DescRecurso")
            cEstado = drAnexo("DescPlaza")
            cTelefono = drAnexo("Telef1")
            cFax = drAnexo("Fax")
            cRfc = drAnexo("RFC")
            cSucursal = drAnexo("Sucursal")
            cPromo = drAnexo("DescPromotor")
            dTermino = Termina(CTOD(drAnexo("Fvenc")), drAnexo("Plazo"))
            cTermino = DTOC(dTermino)
            nPlazo = drAnexo("Plazo")
            nAmorin = drAnexo("Amorin")
            nIvaAmorin = drAnexo("IvaAmorin")
            nMensu = drAnexo("Mensu")
            nComis = drAnexo("Comis")
            nDepg = drAnexo("ImpDG")
            nMtoFin = drAnexo("Impeq") - (drAnexo("Ivaeq") + drAnexo("Amorin"))
            nSaldo = drAnexo("Impeq") - drAnexo("Ivaeq") - drAnexo("Amorin")
            nDepNafin = drAnexo("DepNafin")
            cFvenc = Mes(drAnexo("Fvenc"))
            nTasas = drAnexo("Tasas") + drAnexo("Difer")
            nDifer = drAnexo("Difer")
            nImpRD = drAnexo("Imprd")
            nTasmor = drAnexo("Tasmor")
            nTaspen = drAnexo("Taspen")
            nOpcion = drAnexo("Opcion")
            nImpRD = drAnexo("ImpRD")
            nIvaDepg = drAnexo("IvaRD")
            nIvaEq = drAnexo("Ivaeq")
            nIvaRtaD = drAnexo("IvaDG")
            nDerechos = drAnexo("Derechos")
            nNafin = drAnexo("DepNafin")
            nGastos = drAnexo("Gastos")
            nIvaGastos = drAnexo("Ivagastos")
            nLinau = drAnexo("Linau")
            nImpEq = drAnexo("Impeq")
            nPorop = drAnexo("Porop")
            nPorco = drAnexo("Porco")
            nPorInt = drAnexo("PorInt")
            nRtas = drAnexo("Rtasd")
            cFecre = drAnexo("Fecre")
            cFeaut = drAnexo("Feaut")
            cFevig = drAnexo("Fevig")
            nServicio = drAnexo("Servicio")
            nIVAServicio = drAnexo("IVAServicio")
            cAplicaCobertura = drAnexo("Cobertura")
            cDescPrenda = IIf(IsDBNull(drAnexo("DescPrenda")), "", drAnexo("DescPrenda"))
        Next
        nPorInt = nPorInt / 100

        If Trim(cPromo) = "ING. FRANCISCO KOSO WAKIDA SUZUKI" Then
            cEjecu = "SUBGERENTE DE AGRONEGOCIOS"
        Else
            cEjecu = "EJECUTIVO DE CUENTA"
        End If

        If cTipo = "M" Then
            cPersonaAut = drAnexo("Nomrepr")
        Else
            cPersonaAut = cCusnam
        End If

        If drAnexo("Tipo") = "M" And Trim(drAnexo("Nomrepr")) <> "" Then
            cTitulo1 = "por conducto de su representante que:"
        Else
            cTitulo1 = "por su propio derecho:"
        End If

        If Mid(drAnexo("Geneclie"), 1, 2) = "A)" Then
            cGeneClie = drAnexo("GeneClie") & Chr(10)
        ElseIf Mid(drAnexo("Geneclie"), 1, 2) = "a)" Then
            cGeneClie = drAnexo("GeneClie") & Chr(10)
        Else
            cGeneClie = "A) " & drAnexo("GeneClie") & Chr(10)
        End If

        If drAnexo("Tipo") = "M" Then
            cDato7 = Chr(10) & Chr(10) & "B) Su representante cuenta con facultades suficientes y declara que: "
            cDato7 = cDato7 & Chr(10) + Chr(10) & drAnexo("Generepr")
            cDato7 = cDato7 & Chr(10) & Chr(10) & drAnexo("Poderepr")
            If drAnexo("Nomrepr2") <> "" Then
                cDato7 = Chr(10) & Chr(10) & "Su segundo representante " & drAnexo("Nomrepr2") & " quien manifiesta"
                cDato7 = cDato7 & Chr(10) & Chr(10) & drAnexo("Poderep2")
            End If
        End If

        If Trim(drAnexo("Nomrepr")) <> "" Or Trim(drAnexo("Nomrepr2")) <> "" Then
            If LTrim(drAnexo("Nomrepr2")) <> "" Then
                cRepresentante = "REPRESENTADA EN ESTE ACTO POR " & LTrim(drAnexo("Nomrepr")) & " Y POR " & LTrim(drAnexo("Nomrepr2"))
                cGenerepr = " como representante legal " & LTrim(drAnexo("Nomrepr")) & " quien manifiesta " & drAnexo("Generepr") & " y por " & LTrim(drAnexo("Nomrepr2")) & " quien manifiesta " & drAnexo("Generep2")
            Else
                cRepresentante = "REPRESENTADA EN ESTE ACTO POR " & LTrim(drAnexo("Nomrepr"))
                cGenerepr = " como representante legal " & LTrim(drAnexo("Nomrepr")) & " quien manifiesta " & drAnexo("Generepr")
            End If
        End If

        If drAnexo("Coac") = "C" Then
            If Trim(drAnexo("Nomrcoac")) <> "" And (drAnexo("Tipar") = "F" Or drAnexo("Tipar") = "P") Then
                cCoac = " Y " & drAnexo("Nomcoac") & " COMO COARRENDATARIO REPRESENTADA POR " & drAnexo("Nomrcoac")
            ElseIf Trim(drAnexo("Nomcoac")) <> "" And (drAnexo("Tipar") = "F" Or drAnexo("Tipar") = "P") Then
                cCoac = " Y " & drAnexo("Nomcoac") & " COMO COARRENDATARIO "
            ElseIf Trim(drAnexo("Nomrcoac")) <> "" And (drAnexo("Tipar") = "R" Or drAnexo("Tipar") = "S") Then
                cCoac = " Y " & drAnexo("Nomcoac") & " COMO COACREDITADO REPRESENTADA POR " & drAnexo("Nomrcoac")
            ElseIf Trim(drAnexo("Nomcoac")) <> "" And (drAnexo("Tipar") = "R" Or drAnexo("Tipar") = "S") Then
                cCoac = " Y " & drAnexo("Nomcoac") & " COMO COACREDITADO "
            End If
        End If
  
        If drAnexo("Coac") = "S" Or drAnexo("obli") = "S" Or drAnexo("Aval1") = "S" Or drAnexo("Aval2") = "S" Then
            If drAnexo("Coac") = "S" Then
                If LTrim(drAnexo("Nomrcoac")) <> "" Then
                    cAval1 = drAnexo("Nomcoac") & " REPRESENTADA POR " & drAnexo("Nomrcoac")
                    cAvalg1 = drAnexo("Nomcoac") & " REPRESENTADA POR " & drAnexo("Nomrcoac") & " quien manifiesta " & drAnexo("Genercoa")
                Else
                    cAval1 = drAnexo("Nomcoac")
                    cAvalg1 = drAnexo("Nomcoac") & " quien manifiesta " & drAnexo("Genecoac")
                End If
            End If

            If drAnexo("Obli") = "S" Then
                If LTrim(drAnexo("Nomrobl")) <> "" Then
                    cAval2 = drAnexo("Nomobli") & " REPRESENTADA POR " & drAnexo("Nomrobl")
                    cAvalg2 = drAnexo("Nomobli") & " REPRESENTADA POR " & drAnexo("Nomrobl") & " quien manifiesta " & drAnexo("Generobl")
                Else
                    cAval2 = drAnexo("Nomobli")
                    cAvalg2 = drAnexo("Nomobli") & " quien manifiesta " & drAnexo("GeneObli")
                End If
            End If

            If drAnexo("Aval1") = "S" Then
                If drAnexo("Tipaval1") = "M" And Trim(drAnexo("Nomrava1")) <> "" Then
                    cAval3 = drAnexo("Nomaval1") & " REPRESENTADA POR " & drAnexo("Nomrava1")
                    cAvalg3 = drAnexo("Nomaval1") & " REPRESENTADA POR " & drAnexo("Nomrava1") & " quien manifiesta " & drAnexo("Generav1")
                Else
                    cAval3 = drAnexo("Nomaval1")
                    cAvalg3 = drAnexo("Nomaval1") & " quien manifiesta " & drAnexo("Geneava1")
                End If
            End If

            If drAnexo("Aval2") = "S" Then
                If drAnexo("Tipaval2") = "M" And Trim(drAnexo("Nomrava2")) <> "" Then
                    cAval4 = drAnexo("Nomaval2") & " REPRESENTADA POR " & drAnexo("Nomrava2")
                    cAvalg4 = drAnexo("Nomaval2") & " REPRESENTADA POR " & drAnexo("Nomrava2") & " quien manifiesta " & drAnexo("Generav2")
                Else
                    cAval4 = drAnexo("Nomaval2")
                    cAvalg4 = drAnexo("Nomaval2") & " quien manifiesta " & drAnexo("Geneava2")
                End If
            End If
        End If

        If cAval1 = "" And cAval2 = "" And cAval3 = "" And cAval4 = "" Then
            cAval = ""
            cAvales = ""
        ElseIf cAval1 <> "" And cAval2 <> "" And cAval3 <> "" And cAval4 <> "" Then
            cAval = cAval1 & ", " & cAval2 & ", " & cAval3 & " Y " & cAval4
            cAvales = Chr(10) & Chr(10) & " sus avales " & Chr(10) & Chr(10) & cAvalg1 & Chr(10) & Chr(10) & cAvalg2 & Chr(10) & Chr(10) & cAvalg3 & " Y " & Chr(10) & Chr(10) & cAvalg4
        ElseIf cAval1 <> "" And cAval2 <> "" And cAval3 <> "" And cAval4 = "" Then
            cAval = cAval1 & ", " & cAval2 & " Y " & cAval3
            cAvales = Chr(10) & Chr(10) & " sus avales " & Chr(10) & Chr(10) & cAvalg1 & Chr(10) & Chr(10) & cAvalg2 & " Y " & Chr(10) & Chr(10) & cAvalg3
        ElseIf cAval1 <> "" And cAval2 <> "" And cAval3 = "" And cAval4 = "" Then
            cAval = cAval1 & " Y " & cAval2
            cAvales = Chr(10) & Chr(10) & " sus avales " & Chr(10) & Chr(10) & cAvalg1 & " Y " & Chr(10) & Chr(10) & cAvalg2
        ElseIf cAval1 <> "" And cAval2 = "" And cAval3 = "" And cAval4 = "" Then
            cAval = cAval1
            cAvales = Chr(10) & Chr(10) & " su aval " & Chr(10) & Chr(10) & cAvalg1
        ElseIf cAval1 <> "" And cAval2 <> "" And cAval3 = "" And cAval4 <> "" Then
            cAval = cAval1 & ", " & cAval2 & " Y " & cAval4
            cAvales = Chr(10) & Chr(10) & " sus avales " & Chr(10) & Chr(10) & cAvalg1 & Chr(10) & Chr(10) & cAvalg2 & " Y " & Chr(10) & Chr(10) & cAvalg4
        ElseIf cAval1 <> "" And cAval2 = "" And cAval3 <> "" And cAval4 <> "" Then
            cAval = cAval1 & ", " & cAval3 & " Y " & cAval4
            cAvales = Chr(10) & Chr(10) & " sus avales " & Chr(10) & Chr(10) & cAvalg1 & Chr(10) & Chr(10) & cAvalg3 & " Y " & Chr(10) & Chr(10) & cAvalg4
        ElseIf cAval1 <> "" And cAval2 = "" And cAval3 <> "" And cAval4 = "" Then
            cAval = cAval1 & " Y " & cAval3
            cAvales = Chr(10) & Chr(10) & " sus avales " & Chr(10) & Chr(10) & cAvalg1 & " Y " & Chr(10) & Chr(10) & cAvalg3
        ElseIf cAval1 <> "" And cAval2 = "" And cAval3 = "" And cAval4 <> "" Then
            cAval = cAval1 & " Y " & cAval4
            cAvales = Chr(10) & Chr(10) & " sus avales " & Chr(10) & Chr(10) & cAvalg1 & " Y " & Chr(10) & Chr(10) & cAvalg4
        ElseIf cAval1 = "" And cAval2 <> "" And cAval3 <> "" And cAval4 <> "" Then
            cAval = cAval2 & ", " & cAval3 & " Y " & cAval4
            cAvales = Chr(10) & Chr(10) & " sus avales " & Chr(10) & Chr(10) & cAvalg2 & Chr(10) & Chr(10) & cAvalg3 & " Y " & Chr(10) & Chr(10) & cAvalg4
        ElseIf cAval1 = "" And cAval2 <> "" And cAval3 <> "" And cAval4 = "" Then
            cAval = cAval2 & " Y " & cAval3
            cAvales = Chr(10) & Chr(10) & " sus avales " & Chr(10) & Chr(10) & cAvalg2 & " Y " & Chr(10) & Chr(10) & cAvalg3
        ElseIf cAval1 = "" And cAval2 <> "" And cAval3 = "" And cAval4 <> "" Then
            cAval = cAval2 & " Y " & cAval4
            cAvales = Chr(10) & Chr(10) & " sus avales " & Chr(10) & Chr(10) & cAvalg2 & " Y " & Chr(10) & Chr(10) & cAvalg4
        ElseIf cAval1 = "" And cAval2 <> "" And cAval3 = "" And cAval4 = "" Then
            cAval = cAval2
            cAvales = Chr(10) & Chr(10) & " su aval " & Chr(10) & Chr(10) & cAvalg2
        ElseIf cAval1 = "" And cAval2 = "" And cAval3 <> "" And cAval4 = "" Then
            cAval = cAval3
            cAvales = Chr(10) & Chr(10) & " su aval " & Chr(10) & Chr(10) & cAvalg3
        ElseIf cAval1 = "" And cAval2 = "" And cAval3 <> "" And cAval4 <> "" Then
            cAval = cAval3 & " Y " & cAval4
            cAvales = Chr(10) & Chr(10) & " sus avales " & Chr(10) & Chr(10) & cAvalg3 & " Y " & Chr(10) & Chr(10) & cAvalg4
        End If

        If cAval <> "" Then
            cObSol = " Y EN SU CARÁCTER DE OBLIGADO(S) SOLIDARIO(S) Y AVAL(ES) "
            cObSol1 = " A QUIEN(ES) EN LO SUCESIVO SE LE(S) DENOMINARA 'EL OBLIGADO SOLIDARIO Y AVAL' "
        End If

        If drAnexo("Tipo") = "F" Then
            cTipo = "PERSONA FISICA"
        ElseIf drAnexo("Tipo") = "E" Then
            cTipo = "PERSONA FISICA CON ACTIVIDAD EMPRESARIAL"
        ElseIf drAnexo("Tipo") = "M" Then
            cTipo = "PERSONA MORAL"
        End If

        If cTipar = "F" Then
            If cFondeo = "03" Then
                cProducto = "ARRENDAMIENTO FINANCIERO CON RECURSOS FIRA "
            Else
                cProducto = "ARRENDAMIENTO FINANCIERO "
            End If
        ElseIf cTipar = "P" Then
            If cFondeo = "03" Then
                cProducto = "ARRENDAMIENTO PURO CON RECURSOS FIRA "
            Else
                cProducto = "ARRENDAMIENTO PURO "
            End If
        ElseIf cTipar = "R" Then
            If cFondeo = "03" Then
                cProducto = "CREDITO REFACCIONARIO CON RECURSOS FIRA "
            Else
                cProducto = "CREDITO REFACCIONARIO "
            End If
        ElseIf cTipar = "S" Then
            If cFondeo = "03" Then
                cProducto = "CREDITO SIMPLE CON RECURSOS FIRA "
            Else
                cProducto = "CREDITO SIMPLE "
            End If
        End If

        If cTipar = "F" Or cTipar = "P" Then
            cRefCliente = "ARRENDATARIA"
            cRefProducto = "ARRENDAMIENTO"
            cRefProdgral = "ARRENDADORA"
        ElseIf cTipar = "R" Or cTipar = "S" Then
            cRefCliente = "ACREDITADA"
            cRefProducto = "CREDITO"
            cRefProdgral = "ACREDITANTE"
        End If

        If cTipar = "R" Then
            cTexto = "PAGO"
        Else
            cTexto = "RENTA"
        End If

        If drAnexo("Tipo") = "M" And Trim(drAnexo("Nomrepr")) <> "" Then
            cFirmaCte = cCusnam & Chr(10) & Chr(10) & ReplicateString("_", Len(drAnexo("Nomrepr")) + 6) & Chr(10) & drAnexo("Nomrepr") & Chr(10) & "APODERADO"
        Else
            cFirmaCte = Chr(10) & Chr(10) & ReplicateString("_", Len(cCusnam) + 6) & Chr(10) & cCusnam
        End If

        If drAnexo("TipCoac") = "M" And Trim(drAnexo("Nomrcoac")) <> "" Then
            If drAnexo("Coac") = "C" Then
                If drAnexo("Tipar") = "F" Or drAnexo("Tipar") = "P" Then
                    cFirmaAval1 = Chr(10) & Chr(10) & Chr(10) & Chr(10) & "COARRENDATARIO" & Chr(10) & drAnexo("Nomcoac") & Chr(10) & Chr(10) & Chr(10) & ReplicateString("_", Len(drAnexo("Nomrcoac")) + 6) & Chr(10) & drAnexo("Nomrcoac") & Chr(10) & "APODERADO"
                ElseIf drAnexo("Tipar") = "R" Or drAnexo("Tipar") = "S" Then
                    cFirmaAval1 = Chr(10) & Chr(10) & Chr(10) & Chr(10) & "COACREDITADO" & Chr(10) & drAnexo("Nomcoac") & Chr(10) & Chr(10) & Chr(10) & ReplicateString("_", Len(drAnexo("Nomrcoac")) + 6) & Chr(10) & drAnexo("Nomrcoac") & Chr(10) & "APODERADO"
                End If
            Else
                cFirmaAval1 = Chr(10) & Chr(10) & Chr(10) & Chr(10) & "OBLIGADO SOLIDARIO Y AVAL" & Chr(10) & drAnexo("Nomcoac") & Chr(10) & Chr(10) & Chr(10) & ReplicateString("_", Len(drAnexo("Nomrcoac")) + 6) & Chr(10) & drAnexo("Nomrcoac") & Chr(10) & "APODERADO"
            End If
        ElseIf drAnexo("Coac") <> "N" Then
            If drAnexo("Coac") = "C" Then
                If drAnexo("Tipar") = "F" Or drAnexo("Tipar") = "P" Then
                    cFirmaAval1 = Chr(10) & Chr(10) & Chr(10) & Chr(10) & "COARRENDATARIO" & Chr(10) & Chr(10) & Chr(10) & ReplicateString("_", Len(drAnexo("Nomcoac")) + 6) & Chr(10) & drAnexo("Nomcoac")
                ElseIf drAnexo("Tipar") = "R" Or drAnexo("Tipar") = "S" Then
                    cFirmaAval1 = Chr(10) & Chr(10) & Chr(10) & Chr(10) & "COACREDITADO" & Chr(10) & Chr(10) & Chr(10) & ReplicateString("_", Len(drAnexo("Nomcoac")) + 6) & Chr(10) & drAnexo("Nomcoac")
                End If
            Else
                cFirmaAval1 = Chr(10) & Chr(10) & Chr(10) & Chr(10) & "OBLIGADO SOLIDARIO Y AVAL" & Chr(10) & Chr(10) & Chr(10) & ReplicateString("_", Len(drAnexo("Nomcoac")) + 6) & Chr(10) & drAnexo("Nomcoac")
            End If
        End If

        If drAnexo("TipoObli") = "M" And Trim(drAnexo("NomrObl")) <> "" Then
            cFirmaAval2 = Chr(10) & Chr(10) & Chr(10) & Chr(10) & "OBLIGADO SOLIDARIO Y AVAL" & Chr(10) & drAnexo("NomObli") & Chr(10) & Chr(10) & Chr(10) & ReplicateString("_", Len(drAnexo("NomrObl")) + 6) & Chr(10) & drAnexo("NomrObl") & Chr(10) & "APODERADO"
        ElseIf drAnexo("Obli") = "S" Then
            cFirmaAval2 = Chr(10) & Chr(10) & Chr(10) & Chr(10) & "OBLIGADO SOLIDARIO Y AVAL" & Chr(10) & Chr(10) & Chr(10) & ReplicateString("_", Len(drAnexo("NomObli")) + 6) & Chr(10) & drAnexo("NomObli")
        End If

        If drAnexo("TipAval1") = "M" And Trim(drAnexo("NomrAva1")) <> "" Then
            cFirmaAval3 = Chr(10) & Chr(10) & Chr(10) & Chr(10) & "OBLIGADO SOLIDARIO Y AVAL" & Chr(10) & drAnexo("NomAval1") & Chr(10) & Chr(10) & Chr(10) & ReplicateString("_", Len(drAnexo("Nomrava1")) + 6) & Chr(10) & drAnexo("Nomrava1") & Chr(10) & "APODERADO"
        ElseIf drAnexo("Aval1") = "S" Then
            cFirmaAval3 = Chr(10) & Chr(10) & Chr(10) & Chr(10) & "OBLIGADO SOLIDARIO Y AVAL" & Chr(10) & Chr(10) & Chr(10) & ReplicateString("_", Len(drAnexo("NomAval1")) + 6) & Chr(10) & drAnexo("NomAval1")
        End If

        If drAnexo("TipAval2") = "M" And Trim(drAnexo("NomrAva2")) <> "" Then
            cFirmaAval4 = Chr(10) & Chr(10) & Chr(10) & Chr(10) & "OBLIGADO SOLIDARIO Y AVAL" & Chr(10) & drAnexo("NomAval2") & Chr(10) & Chr(10) & Chr(10) & ReplicateString("_", Len(drAnexo("Nomrava2")) + 6) & Chr(10) & drAnexo("Nomrava2") & Chr(10) & "APODERADO"
        ElseIf drAnexo("Aval2") = "S" Then
            cFirmaAval4 = Chr(10) & Chr(10) & Chr(10) & Chr(10) & "OBLIGADO SOLIDARIO Y AVAL" & Chr(10) & Chr(10) & Chr(10) & ReplicateString("_", Len(drAnexo("NomAval2")) + 6) & Chr(10) & drAnexo("NomAval2")
        End If

        ' Se crea el arreglo para los valores de la Tabla que se usará en el cálculo de la TIR
        ' lo hago en esta parte, dado que depende del numero de letras que contenga el contrato

        txtCusnam.Text = cCusnam

        If cFlcan = "S" Then
            btnActivar.Enabled = True
            btnValida.Enabled = False
            btnHoja.Enabled = False
            btnPagare.Enabled = False
            btnContrato.Enabled = False
            btnAnexoA.Enabled = False
            btnAnexoB.Enabled = False
            btnAnexoC.Enabled = False
            btnRatif.Enabled = False
        Else
            btnActivar.Enabled = False
            btnValida.Enabled = True
            btnHoja.Enabled = True
            btnPagare.Enabled = True
            btnContrato.Enabled = True
            btnAnexoA.Enabled = True
            btnAnexoB.Enabled = True
            btnAnexoC.Enabled = True
            btnRatif.Enabled = True
        End If

        If cFlcan <> "S" Then

            cFeven = DTOC(Today)

            ' El siguiente Stored Procedure trae los Datos del equipo financiado

            With cm2
                .CommandType = CommandType.StoredProcedure
                .CommandText = "DatosEquipo1"
                .Connection = cnAgil
                .Parameters.Add("@Anexo", SqlDbType.NVarChar)
                .Parameters(0).Value = cContrato
            End With

            ' Obtengo el total del contrato

            With cm3
                .CommandType = CommandType.Text
                .CommandText = "SELECT Round(Sum(Convert(Decimal(14,2), Abcap + Inter)),2) as Total From Edoctav Where Edoctav.Anexo = " & "'" & cContrato & "'"
                .Connection = cnAgil
            End With

            ' Este Stored Procedure trae la tabla de amortización del equipo para el contrato seleccionado

            With cm4
                .CommandType = CommandType.StoredProcedure
                .CommandText = "TablaEquipo1"
                .Connection = cnAgil
                .Parameters.Add("@Anexo", SqlDbType.NVarChar)
                .Parameters(0).Value = cContrato
            End With

            ' Obtengo todos los contratos asociados al Cliente sin importar su estatus

            With cm5
                .CommandType = CommandType.StoredProcedure
                .CommandText = "PideAnex2"
                .Connection = cnAgil
                .Parameters.Add("@Cliente", SqlDbType.NVarChar)
                .Parameters(0).Value = cCliente
            End With

            'Obtengo las rentas en depósito que tenga este contrato

            With cm6
                .CommandType = CommandType.StoredProcedure
                .CommandText = "DameRentas"
                .Connection = cnAgil
                .Parameters.Add("@cAnexo", SqlDbType.Char)
                .Parameters(0).Value = cContrato
            End With

            daSaldo.Fill(dsAgil, "Saldo")
            daRentas.Fill(dsAgil, "Rentasdep")

            drRiesgos = dsAgil.Tables("Saldo").Rows
            nCount = dsAgil.Tables("Rentasdep").Rows.Count

            nRentasD = 0
            nIvard = 0
            nSaldoRiesgo = 0

            If nCount > 0 Then
                drRentas = dsAgil.Tables("Rentasdep").Rows(0)
                If Not IsDBNull(drRentas("Rta")) Then
                    nRentasD = drRentas("Rta")
                    nIvard = drRentas("iva")
                End If
            End If

            nPagosi = nImpRD + nIvaDepg + nComis + nAmorin + nIvaAmorin + nDepNafin + nGastos + nIvaGastos
            nPagosi = nPagosi + nRentasD + nIvaRtaD + nDerechos + nServicio + nIVAServicio

            If nIvaEq > 0 And cFechacon < "20020301" Then
                cDescPI = "IVA DE LA OPERACION"
                cImpPI = FormatNumber(nIvaEq, 2).ToString
            End If
            If nImpRD > 0 Then
                If cTipar = "R" Then
                    cDescPI = cDescPI & Chr(13) & "DEPOSITO FINAGIL"
                    cImpPI = cImpPI & Chr(13) & FormatNumber(nImpRD, 2).ToString
                Else
                    cDescPI = cDescPI & Chr(13) & "DEPOSITO EN GARANTIA"
                    cImpPI = cImpPI & Chr(13) & FormatNumber(nImpRD, 2).ToString
                End If
            End If
            If nIvaDepg > 0 Then
                If cTipar = "R" Then
                    cDescPI = cDescPI & Chr(13) & "IVA DEPOSITO FINAGIL"
                    cImpPI = cImpPI & Chr(13) & FormatNumber(nIvaDepg, 2).ToString
                Else
                    cDescPI = cDescPI & Chr(13) & "IVA DEL DEPOSITO"
                    cImpPI = cImpPI & Chr(13) & FormatNumber(nIvaDepg, 2).ToString
                End If
            End If
            If nComis > 0 Then
                cDescPI = cDescPI & Chr(13) & "COMISION + IVA"
                cImpPI = cImpPI & Chr(13) & FormatNumber(nComis, 2).ToString
            End If
            If nDepNafin > 0 Then
                cDescPI = cDescPI & Chr(13) & "5 % NAFIN"
                cImpPI = cImpPI & Chr(13) & FormatNumber(nDepNafin, 2).ToString
            End If
            If nAmorin > 0 Then
                If cTipar = "R" Then
                    cDescPI = cDescPI & Chr(13) & "ENGANCHE"
                    cImpPI = cImpPI & Chr(13) & FormatNumber(nAmorin, 2).ToString
                Else
                    cDescPI = cDescPI & Chr(13) & "AMORTIZACION INICIAL"
                    cImpPI = cImpPI & Chr(13) & FormatNumber(nAmorin, 2).ToString
                End If
            End If
            If nIvaAmorin > 0 Then
                cDescPI = cDescPI & Chr(13) & "IVA AMORTIZACION"
                cImpPI = cImpPI & Chr(13) & FormatNumber(nIvaAmorin, 2).ToString
            End If
            If cTipar = "R" And nDerechos > 0 Then
                cDescPI = cDescPI & Chr(13) & "DERECHOS DE REGISTRO"
                cImpPI = cImpPI & Chr(13) & FormatNumber(nDerechos, 2).ToString
            End If
            If nGastos > 0 Then
                cDescPI = cDescPI & Chr(13) & "GASTOS DE RATIFICACION"
                cImpPI = cImpPI & Chr(13) & FormatNumber(nGastos, 2).ToString
            End If
            If nIvaGastos > 0 Then
                cDescPI = cDescPI & Chr(13) & "IVA GASTOS DE RATIFICACION"
                cImpPI = cImpPI & Chr(13) & FormatNumber(nIvaGastos, 2).ToString
            End If
            If nRentasD > 0 Then
                cDescPI = cDescPI & Chr(13) & "RENTAS EN DEPOSITO"
                cImpPI = cImpPI & Chr(13) & FormatNumber(nRentasD, 2).ToString
            End If
            If nIvaRtaD > 0 Then
                cDescPI = cDescPI & Chr(13) & "IVA RENTAS EN DEPOSITO"
                cImpPI = cImpPI & Chr(13) & FormatNumber(nIvaRtaD, 2).ToString
            End If
            If nServicio > 0 Then
                cDescPI = cDescPI & Chr(13) & "SERVICIO DE GARANTIA"
                cImpPI = cImpPI & Chr(13) & FormatNumber(nServicio, 2).ToString
            End If
            If nIVAServicio > 0 Then
                cDescPI = cDescPI & Chr(13) & "IVA SERVICIO DE GARANTIA"
                cImpPI = cImpPI & Chr(13) & FormatNumber(nIVAServicio, 2).ToString
            End If
            cImpPI = cImpPI & Chr(13) & "_________________"
            cImpPI = cImpPI & Chr(13) & FormatNumber(nPagosi, 2).ToString

            ' Crear tabla temporal para integrar el dato de saldo insoluto de contratos anteriores y Rentas
            ' en Depósito si existen

            dtRiesgo.Columns.Add("SaldoRiesgo", Type.GetType("System.String"))
            dtRiesgo.Columns.Add("Rentasd", Type.GetType("System.String"))
            dtRiesgo.Columns.Add("Ivartad", Type.GetType("System.String"))
            dtRiesgo.Columns.Add("CAT", Type.GetType("System.String"))

            nSaldoRiesgo = 0
            For Each drRiesgo In drRiesgos
                If drRiesgo("Flcan") = "A" And drRiesgo("Anexo") < cContrato Then
                    nSaldoRiesgo = AcumulaSdo(drRiesgo("Anexo"), cFecha) + nSaldoRiesgo
                End If
            Next
            nSaldoAct = nSaldo + nSaldoRiesgo

            daAnexo.Fill(dsAgil, "Actifijo")
            daEdoctav.Fill(dsAgil, "Edoctav")   'Contiene la sumatoria de las rentas
            daTabla.Fill(dsAgil, "Tabla")       'Contiene la tabla de amortización del contrato

            drEdoctav = dsAgil.Tables("Edoctav").Rows(0)
            nTotal2 = drEdoctav("Total")

            For Each drEquipo In dsAgil.Tables("Actifijo").Rows
                cBienes = cBienes & "FACTURA____ " & drEquipo("Factura") & Chr(10) & "PROVEEDOR_ " & drEquipo("Proveedor") & Chr(10) & "MODELO_____ " & drEquipo("Modelo") & Chr(10)
                cBienes = cBienes & "MOTOR______ " & drEquipo("Motor") & Chr(10) & "SERIE_______ " & drEquipo("Serie") & Chr(10) & "IMPORTE____ " & FormatNumber(drEquipo("Importe")).ToString & " " & Letras(drEquipo("Importe")) & Chr(10)
                cBienes = cBienes & Trim(drEquipo("Detalle")) & Chr(10) & Chr(10)
                cProveedor = cProveedor & drEquipo("Proveedor") & Chr(10)
                cImpProv = cImpProv & FormatNumber(drEquipo("Importe")).ToString & Chr(10)
                cDetalle = cDetalle & Trim(drEquipo("Detalle")) & Chr(10)
            Next

            For Each drEquipo In dsAgil.Tables("Actifijo").Rows
                cBienes2 = cBienes2 & "FACTURA____ " & drEquipo("Factura") & Chr(10) & "PROVEEDOR_ " & drEquipo("Proveedor") & Chr(10) & "MODELO_____ " & drEquipo("Modelo") & Chr(10)
                cBienes2 = cBienes2 & "MOTOR______ " & drEquipo("Motor") & Chr(10) & "SERIE_______ " & drEquipo("Serie") & Chr(10) & "IMPORTE____ " & drEquipo("Importe") & " " & Letras(drEquipo("Importe")) & Chr(10)
                cBienes2 = cBienes2 & "COBERTURA SEG. " & Chr(10) & "VIGENCIA SEG. " & Chr(10) & "BENEFICIARIO" & "BENEFICIARIO PREFERENTE  FINAGIL, S.A. DE C.V. SOFOM ENR" & Chr(10)
                cBienes2 = cBienes2 & Chr(10) & Trim(drEquipo("Detalle")) & Chr(10) & Chr(10)
            Next

            cDiaPago = " con las fechas estipuladas en su Tabla de Amortización correspondiente a partir del"


            i = 0
            For Each drTabla In dsAgil.Tables("Tabla").Rows
                If i = 0 Then
                    cFven1 = drTabla("Feven")
                End If
                cFevent = drTabla("Feven")
                i = i + 1
            Next
            If i = 1 Then
                nDiasp = DateDiff(DateInterval.Day, CTOD(cFechacon), CTOD(cFevent))
                nDiasp = nDiasp / (i)
            Else
                nDiasp = DateDiff(DateInterval.Day, CTOD(cFven1), CTOD(cFevent))
                nDiasp = nDiasp / (i - 1)
            End If
            
            i = 1
            nCobertura = 0
            nTotalCobert = 0
            For Each drTabla In dsAgil.Tables("Tabla").Rows
                If i = 1 Then
                    cLetrat = drTabla("Letra")
                    cFevent = CTOD(drTabla("Feven"))
                    cSaldot = FormatNumber(drTabla("Saldo")).ToString
                    cAbcapt = FormatNumber(drTabla("Abcap")).ToString
                    cIntert = FormatNumber(drTabla("Inter")).ToString
                    cIvat = FormatNumber(drTabla("Iva")).ToString
                    cIvaCapt = FormatNumber(drTabla("IvaCapital")).ToString
                    cRenta = FormatNumber(drTabla("Abcap") + drTabla("Inter")).ToString
                    If nRtas = 0 And nImpRD > 0 Then
                        cBonifica = FormatNumber(drTabla("IvaCapital")).ToString
                        If cFondeo = "03" And cAplicaCobertura = "S" Then
                            Select Case nDiasp
                                Case Is <= 31
                                    cCobert = FormatNumber(Round(drTabla("Saldo") * (0.01 / 12), 2)).ToString
                                    nCobertura = Round(drTabla("Saldo") * (0.01 / 12), 2)
                                Case 58 To 80
                                    cCobert = FormatNumber(Round(drTabla("Saldo") * (0.01 / 6), 2)).ToString
                                    nCobertura = Round(drTabla("Saldo") * (0.01 / 6), 2)
                                Case 88 To 100
                                    cCobert = FormatNumber(Round(drTabla("Saldo") * (0.01 / 4), 2)).ToString
                                    nCobertura = Round(drTabla("Saldo") * (0.01 / 4), 2)
                                Case 175 To 200
                                    cCobert = FormatNumber(Round(drTabla("Saldo") * (0.01 / 2), 2)).ToString
                                    nCobertura = Round(drTabla("Saldo") * (0.01 / 2), 2)
                                Case Is > 250
                                    cCobert = FormatNumber(Round(drTabla("Saldo") * 0.01, 2)).ToString
                                    nCobertura = Round(drTabla("Saldo") * 0.01, 2)
                            End Select
                            cTotg = FormatNumber(drTabla("Abcap") + drTabla("Inter") + drTabla("Iva") + nCobertura).ToString
                            cPagomen = FormatNumber(drTabla("Abcap") + drTabla("Inter") + drTabla("Iva")).ToString
                            nTotalCobert = nTotalCobert + nCobertura
                        Else
                            cCobert = "0.00"
                            cPagomen = FormatNumber(drTabla("Abcap") + drTabla("Inter") + drTabla("Iva")).ToString
                            cTotg = FormatNumber(drTabla("Abcap") + drTabla("Inter") + drTabla("Iva")).ToString
                        End If
                    Else
                        cBonifica = "0.00"
                        If cFondeo = "03" And cAplicaCobertura = "S" Then
                            Select Case nDiasp
                                Case Is <= 31
                                    cCobert = FormatNumber(Round(drTabla("Saldo") * (0.01 / 12), 2)).ToString
                                    nCobertura = Round(drTabla("Saldo") * (0.01 / 12), 2)
                                Case 58 To 80
                                    cCobert = FormatNumber(Round(drTabla("Saldo") * (0.01 / 6), 2)).ToString
                                    nCobertura = Round(drTabla("Saldo") * (0.01 / 6), 2)
                                Case 88 To 100
                                    cCobert = FormatNumber(Round(drTabla("Saldo") * (0.01 / 4), 2)).ToString
                                    nCobertura = Round(drTabla("Saldo") * (0.01 / 4), 2)
                                Case 175 To 200
                                    cCobert = FormatNumber(Round(drTabla("Saldo") * (0.01 / 2), 2)).ToString
                                    nCobertura = Round(drTabla("Saldo") * (0.01 / 2), 2)
                                Case Is > 250
                                    cCobert = FormatNumber(Round(drTabla("Saldo") * 0.01, 2)).ToString
                                    nCobertura = Round(drTabla("Saldo") * 0.01, 2)
                            End Select
                            cTotg = FormatNumber(drTabla("Abcap") + drTabla("Inter") + drTabla("Iva") + drTabla("IvaCapital") + nCobertura).ToString
                            cPagomen = FormatNumber(drTabla("Abcap") + drTabla("Inter") + drTabla("Iva") + drTabla("IvaCapital")).ToString
                            nTotalCobert = nTotalCobert + nCobertura
                        Else
                            cPagomen = FormatNumber(drTabla("Abcap") + drTabla("Inter") + drTabla("Iva") + drTabla("IvaCapital")).ToString
                            cTotg = FormatNumber(drTabla("Abcap") + drTabla("Inter") + drTabla("Iva") + drTabla("IvaCapital")).ToString
                            cCobert = "0.00"
                        End If
                    End If
                Else
                    cLetrat = cLetrat & Chr(10) & drTabla("Letra")
                    cFevent = cFevent & Chr(10) & CTOD(drTabla("Feven"))
                    cSaldot = cSaldot & Chr(10) & FormatNumber(drTabla("Saldo")).ToString
                    cAbcapt = cAbcapt & Chr(10) & FormatNumber(drTabla("Abcap")).ToString
                    cIntert = cIntert & Chr(10) & FormatNumber(drTabla("Inter")).ToString
                    cIvat = cIvat & Chr(10) & FormatNumber(drTabla("Iva")).ToString
                    cIvaCapt = cIvaCapt & Chr(10) & FormatNumber(drTabla("IvaCapital")).ToString
                    cRenta = cRenta & Chr(10) & FormatNumber(drTabla("Abcap") + drTabla("Inter")).ToString
                    If nRtas = 0 And nImpRD > 0 Then
                        cBonifica = cBonifica & Chr(10) & FormatNumber(drTabla("IvaCapital")).ToString
                        If cFondeo = "03" And cAplicaCobertura = "S" Then
                            cPagomen = cPagomen & Chr(10) & FormatNumber(drTabla("Abcap") + drTabla("Inter") + drTabla("Iva")).ToString
                            Select Case nDiasp
                                Case Is <= 31
                                    cCobert = cCobert & Chr(10) & FormatNumber(Round(drTabla("Saldo") * (0.01 / 12), 2)).ToString
                                    nCobertura = Round(drTabla("Saldo") * (0.01 / 12), 2)
                                Case 58 To 80
                                    cCobert = cCobert & Chr(10) & FormatNumber(Round(drTabla("Saldo") * (0.01 / 6), 2)).ToString
                                    nCobertura = Round(drTabla("Saldo") * (0.01 / 6), 2)
                                Case 88 To 100
                                    cCobert = cCobert & Chr(10) & FormatNumber(Round(drTabla("Saldo") * (0.01 / 4), 2)).ToString
                                    nCobertura = Round(drTabla("Saldo") * (0.01 / 4), 2)
                                Case 175 To 200
                                    cCobert = cCobert & Chr(10) & FormatNumber(Round(drTabla("Saldo") * (0.01 / 2), 2)).ToString
                                    nCobertura = Round(drTabla("Saldo") * (0.01 / 2), 2)
                                Case Is > 250
                                    cCobert = cCobert & Chr(10) & FormatNumber(Round(drTabla("Saldo") * 0.01, 2)).ToString
                                    nCobertura = Round(drTabla("Saldo") * 0.01, 2)
                            End Select
                            cTotg = cTotg & Chr(10) & FormatNumber(drTabla("Abcap") + drTabla("Inter") + drTabla("Iva") + nCobertura).ToString
                            nTotalCobert = nTotalCobert + nCobertura
                        Else
                            cCobert = cCobert & Chr(10) & "0.00"
                            cPagomen = cPagomen & Chr(10) & FormatNumber(drTabla("Abcap") + drTabla("Inter") + drTabla("Iva")).ToString
                            cTotg = cTotg & Chr(10) & FormatNumber(drTabla("Abcap") + drTabla("Inter") + drTabla("Iva")).ToString
                        End If
                    Else
                        cBonifica = cBonifica & Chr(10) & "0.00"
                        If cFondeo = "03" And cAplicaCobertura = "S" Then
                            Select Case nDiasp
                                Case Is <= 31
                                    cCobert = cCobert & Chr(10) & FormatNumber(Round(drTabla("Saldo") * (0.01 / 12), 2)).ToString
                                    nCobertura = Round(drTabla("Saldo") * (0.01 / 12), 2)
                                Case 58 To 80
                                    cCobert = cCobert & Chr(10) & FormatNumber(Round(drTabla("Saldo") * (0.01 / 6), 2)).ToString
                                    nCobertura = Round(drTabla("Saldo") * (0.01 / 6), 2)
                                Case 88 To 100
                                    cCobert = cCobert & Chr(10) & FormatNumber(Round(drTabla("Saldo") * (0.01 / 4), 2)).ToString
                                    nCobertura = Round(drTabla("Saldo") * (0.01 / 4), 2)
                                Case 175 To 200
                                    cCobert = cCobert & Chr(10) & FormatNumber(Round(drTabla("Saldo") * (0.01 / 2), 2)).ToString
                                    nCobertura = Round(drTabla("Saldo") * (0.01 / 2), 2)
                                Case Is > 250
                                    cCobert = cCobert & Chr(10) & FormatNumber(Round(drTabla("Saldo") * 0.01, 2)).ToString
                                    nCobertura = Round(drTabla("Saldo") * 0.01, 2)
                            End Select
                            cPagomen = cPagomen & Chr(10) & FormatNumber(drTabla("Abcap") + drTabla("Inter") + drTabla("Iva") + drTabla("IvaCapital")).ToString
                            cTotg = cTotg & Chr(10) & FormatNumber(drTabla("Abcap") + drTabla("Inter") + drTabla("Iva") + drTabla("IvaCapital") + nCobertura).ToString
                            nTotalCobert = nTotalCobert + nCobertura
                        Else
                            cCobert = cCobert & Chr(10) & "0.00"
                            cPagomen = cPagomen & Chr(10) & FormatNumber(drTabla("Abcap") + drTabla("Inter") + drTabla("Iva") + drTabla("IvaCapital")).ToString
                            cTotg = cTotg & Chr(10) & FormatNumber(drTabla("Abcap") + drTabla("Inter") + drTabla("Iva") + drTabla("IvaCapital")).ToString
                        End If
                    End If
                End If
                nAmort = i
                i += 1
            Next

            If cSucursal = "03" Then
                cLugar = "Navojoa, Sonora"
                cNotario = "Lic. René Balderrama Sánchez, Notario Público No. 7 de la Ciudad de Navojoa, Sonora,"
                cUnidadEsp = "Quintana Roo No. 111 Local 10 Altos, Edificio Guadalajara, Col. Juárez, C.P. 85800, Navojoa, SONORA.   Los teléfonos de atención a usuarios serán: (642) 422 32 44, (642) 422 56 50  y 01 800 836 23 92,"
            ElseIf cSucursal = "04" Then
                cLugar = "Mexicali, Baja California"
                cNotario = "Lic. Francisco Javier Briseño Arce, Registrador Agricola de la Ciudad de Mexicali, Baja California,"
                cUnidadEsp = "Rio San Angel No. 48 Locales 7 y 8, Centro Comercial Mar y Sal, Col. Valle de Puebla, C.P. 21384, Mexicali, BAJA CALIFORNIA.   Los teléfonos de atención a usuarios serán: (686) 577 80 55, (686) 577 80 60 y 01 800 626 02 07,"
            ElseIf cSucursal = "01" Or cSucursal = "02" Then
                cLugar = "Toluca, Estado de México"
                cNotario = "Lic. Jorge Valdés Ramírez, Notario Público No. 24 de la Ciudad de Toluca, Estado de México."
                cUnidadEsp = "Leandro Valle No. 402 Col. Reforma y FFCCNN, C.P. 50070 en Toluca, Estado de México. Los teléfonos de atención a usuarios serán: (722) 214 55 33 y 01 800 72 77 100,"
            ElseIf cSucursal = "05" Then
                cLugar = "Irapuato, Guanajuato"
                cNotario = ""
                cUnidadEsp = "Leandro Valle No. 402 Col. Reforma y FFCCNN, C.P. 50070 en Toluca, Estado de México. Los teléfonos de atención a usuarios serán: (722) 214 55 33 y 01 800 72 77 100,"
            End If

            'Procedemos a llenar el arreglo para el cálculo de TIR
            Dim Valores(nAmort) As Double
            Dim Guess As Double

            Valores(0) = -nMtoFin + (nComis + nDepg)
            For Each drRiesgo In dsAgil.Tables("Tabla").Rows
                If drRiesgo("Nufac") < 7777777 And drRiesgo("Indrec") = "S" Then
                    i = Val(drRiesgo("Letra"))
                    nDato2 = drRiesgo("Renta")
                    cFecha1 = drRiesgo("Feven")
                    Valores(i) = drRiesgo("Renta")
                    cFecha1 = drRiesgo("Feven")
                End If
                nTotal += (drRiesgo("Abcap") + drRiesgo("Inter"))
            Next
            nDiasp = DateDiff(DateInterval.Day, CTOD(cFechacon), CTOD(cFecha1))
            nPanual = Round(nDiasp / i, 0)
            cTermino = Mes(cFecha1)

            Select Case nPanual
                Case Is > 360
                    P = 1
                Case Is >= 179
                    P = 2
                Case Is >= 119
                    P = 3
                Case Is >= 89
                    P = 4
                Case Is >= 59
                    P = 6
                Case Is >= 29
                    P = 12
                Case Is = 28
                    P = 13
                Case Is >= 15, Is = 16, Is = 17
                    P = 24
                Case Is = 14
                    P = 26
                Case Is = 7
                    P = 52
            End Select

            If nPanual > 59 Then
                cParrafoInteres = "Los intereses se computaran mensualmente y se refinanciaran sumándose al saldo insoluto, pasando a formar parte del capital como nueva base de cómputo de intereses del mes siguiente y así sucesivamente hasta que se lleve a cabo la amortización principal."
            Else
                cParrafoInteres = "Los intereses pactados en este pagaré se calculan por el número de días naturales realmente transcurridos, sobre la base de un año de 360 días."
            End If

            Guess = 0.01
            nTIR = Round(IRR(Valores, Guess) * 100, 3)
            nCAT = (Round(Pow(1 + (nTIR / 100), P), 8) - 1) * 100


            drRiesgo = dtRiesgo.NewRow()
            drRiesgo("SaldoRiesgo") = FormatNumber(nSaldoRiesgo.ToString, 2)
            drRiesgo("Rentasd") = FormatNumber(nRentasD.ToString, 2)
            drRiesgo("Ivartad") = FormatNumber(nIvard.ToString, 2)
            drRiesgo("CAT") = FormatNumber(nCAT, 2).ToString & "%"
            dtRiesgo.Rows.Add(drRiesgo)
            dsAgil.Tables.Add(dtRiesgo)

            dsAgil.WriteXml("C:\Archivos de Programa\Agil\Schema2.xml", XmlWriteMode.WriteSchema)

        End If

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()
        cm3.Dispose()
        cm4.Dispose()
        cm5.Dispose()
        cm6.Dispose()

    End Sub

    Function ReplicateString(ByVal Source As String, ByVal Times As Long) As String
        Dim length As Long, index As Long
        ' Crea la línea
        length = Len(Source)
        ReplicateString = Space$(length * Times)
        ' Realiza multiples copias del valor Source 
        For index = 1 To Times
            Mid$(ReplicateString, (index - 1) * length + 1, length) = Source
        Next
    End Function

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class
