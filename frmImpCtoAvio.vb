Option Explicit On

Imports System.Data.SqlClient
Imports System.Math
Imports System.IO
Imports Word = Microsoft.Office.Interop.Word
Imports Microsoft.Office.Interop

Public Class frmImpCtoAvio

    ' Declaración de variables de datos de alcance privado

    Dim cAnexo As String = ""
    Dim cAval1 As String = ""
    Dim cAval2 As String = ""
    Dim cAval3 As String = ""
    Dim cAval4 As String = ""
    Dim cAvales As String = ""
    Dim cCiclo As String = ""
    Dim cCliente As String = ""
    Dim cTipo As String = ""
    Dim cRepresentante As String = ""
    Dim cRepresentante2 As String = ""
    Dim cRepresentante1 As String = ""
    Dim cParrafoRepres As String = ""
    Dim cEncabezado As String = ""
    Dim cEncabezado2 As String = ""
    Dim cFirmaAval1 As String = ""
    Dim cFirmaAval2 As String = ""
    Dim cFirmaAval3 As String = ""
    Dim cFirmaAval4 As String = ""
    Dim cFirmaTestigo1 As String = ""
    Dim cFirmaTestigo2 As String = ""
    Dim cFirmaFINAGIL As String = ""
    Dim cEmpcv As String = ""
    Dim cLugar As String = ""
    Dim cTestigos As String = ""
    Dim cSucursal As String = ""
    Dim cNuevoNombre As String
    Dim cDescr As String = ""
    Dim cRfc As String
    Dim cCalle As String
    Dim cColonia As String
    Dim cCopos As String
    Dim cDelegacion As String
    Dim cEstado As String
    Dim cComision As String = ""
    Dim cInmuebles As String = "NO APLICA"
    Dim cMuebles As String = "NO APLICA"
    Dim cUsufructo As String = "NO APLICA"
    Dim cGeneClie As String
    Dim cCantidad As String
    Dim cFirmaRegistrador As String = ""
    Dim cImporte As String
    Dim cDiferencialFINAGIL As String
    Dim cFechaAutorizacion As String
    Dim cFechaTermino As String
    Dim cFechaFirma As String = ""
    Dim cPredios As String
    Dim cParrafoHipoteca As String
    Dim cParrafoPrenda As String
    Dim cGravamen As String = ""
    Dim nHectareas As Decimal = 0
    Dim nToneladas As Decimal = 0
    Dim nRendimiento As Decimal = 0
    Dim cRendimiento As String = "0"
    Dim nImporte As Decimal = 0
    Dim nMontoInv As Decimal = 0
    Dim nAportInv As Decimal = 0
    Dim nLineaMax As Decimal = 0
    Dim nCostoMaxHa As Decimal = 0
    Dim nPorcomi As Decimal = 0
    Dim nCAT As Decimal = 0
    Dim cGarantiaHipotecaria As String = ""
    Dim cGarantiaPrendaria As String = ""
    Dim cGarantiaUsufructo As String = ""
    Dim cHectareas As String = "0"
    Dim cToneladas As String = "0"
    Dim cLeyendaRegistrador As String = ""
    Dim cLeyendaNotario As String = ""
    Dim cDatosAval As String = ""
    Dim cSemilla As String = ""
    Dim cUnidadEsp As String = ""
    Dim cFirman As String = ""
    Dim cOtros As String = ""
    Dim cAgroquimi As String = ""
    Dim cAgroquimi2 As String = ""
    Dim cGarPrend As String = ""
    Dim cGarHipot As String = ""
    Dim cGarantias As String = ""
    Dim cPirineos As String = ""
    Dim cC_Venta As String = ""
    Dim cC_Venta2 As String = ""
    Dim cCtoC_Venta As String = ""
    Dim cTrianual As String = ""
    Dim cPrimera As String = ""
    Dim cSegunda As String = ""
    Dim cDescCiclo As String = ""
    Dim cFechaSiembra As String = ""
    Dim cFechaCosecha As String = ""
    Dim cGenA1 As String = ""
    Dim cGenA2 As String = ""
    Dim cGenA3 As String = ""
    Dim cGenA4 As String = ""
    Dim cPodA1 As String = ""
    Dim cPodA2 As String = ""
    Dim cPodA3 As String = ""
    Dim cPodA4 As String = ""
    Dim cVenAño2 As String = ""
    Dim cVenAño3 As String = ""
    Dim cCiclo2 As String = ""
    Dim cCiclo3 As String = ""
    Dim cFSiembra2 As String = ""
    Dim cFSiembra3 As String = ""
    Dim cFCosecha2 As String = ""
    Dim cFCosecha3 As String = ""
    Dim cFLimite2 As String = ""
    Dim cFLimite3 As String = ""
    Dim cCURP As String = ""
    Dim cGaranteHip As String = ""
    Dim cGarantePre As String = ""
    Dim nPlazoCred As Integer
    Dim cNum As String
    Dim cNum1 As String
    Dim cNum2 As String
    Dim cParafin As String

    Dim oWord As Word.Application
    Dim oWordDoc As Microsoft.Office.Interop.Word.Document

    Public Sub New(ByVal cLinea As String)

        MyBase.New()

        'This call is required by the Windows Form Designer.

        InitializeComponent()

        cAnexo = Mid(cLinea, 1, 10)
        txtAnexo.Text = Mid(cLinea, 1, 10)

        If Mid(cLinea, 12, 6) = "PAGARE" Then
            Me.Text = "Impresión del Crédito en Cuenta Corriente " & Mid(cLinea, 1, 10)
        Else
            Me.Text = "Impresión del Contrato de Avío " & Mid(cLinea, 1, 10)
        End If

        cAnexo = Mid(cLinea, 1, 5) & Mid(cLinea, 7, 4)
        If Mid(cLinea, 12, 6) = "PAGARE" Then
            cCiclo = Mid(cLinea, 19, 2)
        Else
            cCiclo = Mid(cLinea, 18, 2)
        End If

    End Sub

    Private Sub frmImpCtoAvio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim daDatos As New SqlDataAdapter(cm1)
        Dim daTiie As New SqlDataAdapter(cm2)
        Dim daCiclos As New SqlDataAdapter(cm3)
      
        Dim dsAgil As New DataSet
        Dim drDato As DataRow
        Dim drTiie As DataRow
        Dim drCiclo As DataRow

        If Mid(Me.Text, 15, 16) = "Contrato de Avío" Then

            With cm1
                .CommandType = CommandType.Text
                .CommandText = "SELECT Avios.*, Clientes.*, DescPlaza FROM Avios " & _
                               "INNER JOIN Clientes ON Avios.Cliente = Clientes.Cliente " & _
                               "INNER JOIN Plazas ON Clientes.Plaza = Plazas.Plaza " & _
                               "WHERE Anexo = " & "'" & cAnexo & "'" & " AND Ciclo = " & "'" & cCiclo & "'"
                .Connection = cnAgil
            End With

            ' Llenar el dataset lo cual abre y cierra la conexión

            daDatos.Fill(dsAgil, "Datos")

            drDato = dsAgil.Tables("Datos").Rows(0)
            cCliente = drDato("Cliente")
            cDescr = Trim(drDato("Descr"))
            cGenA1 = Trim(drDato("Generepr"))
            cPodA1 = Trim(drDato("Poderepr"))
            cGenA2 = Trim(drDato("Generep2"))
            cPodA2 = Trim(drDato("Poderep2"))
            cGenA3 = Trim(drDato("Genercoa"))
            cPodA3 = Trim(drDato("Podercoa"))
            cGenA4 = Trim(drDato("GenerObl"))
            cPodA4 = Trim(drDato("PoderObl"))
            cVenAño2 = Trim(drDato("FechaTermino2"))
            cVenAño3 = Trim(drDato("FechaTermino3"))
            cCiclo2 = Trim(drDato("SegundoCiclo"))
            cCiclo3 = Trim(drDato("TercerCiclo"))
            cFSiembra2 = Trim(drDato("FechaSiembra2"))
            cFSiembra3 = Trim(drDato("FechaSiembra3"))
            cFCosecha2 = Trim(drDato("FechaCosecha2"))
            cFCosecha3 = Trim(drDato("FechaCosecha3"))
            cFLimite2 = Trim(drDato("FechaLimiteDTC2"))
            cFLimite3 = Trim(drDato("FechaLimiteDTC3"))
            cTipo = Trim(drDato("Tipo"))
            cRfc = drDato("Rfc")
            cCURP = drDato("CURP")
            cCalle = Trim(drDato("Calle"))
            cColonia = Trim(drDato("Colonia"))
            cCopos = drDato("Copos")
            cDelegacion = Trim(drDato("Delegacion"))
            cEstado = Trim(drDato("DescPlaza"))
            cGeneClie = Replace(drDato("GeneClie"), Chr(13) + Chr(10), "")
            nHectareas = drDato("HectareasActual")
            nImporte = drDato("LineaActual")
            nAportInv = (nImporte / 0.8) - nImporte
            nMontoInv = nImporte + nAportInv
            'nCostoMaxHa = drDato("CostoMaxHa")
            'nLineaMax = drDato("LineaMax")
            cImporte = FormatNumber(nImporte).ToString
            cCantidad = Letras(nImporte)
            cDiferencialFINAGIL = drDato("DiferencialFINAGIL").ToString
            cPredios = drDato("Predios").ToString
            cFechaAutorizacion = Trim(drDato("FechaAutorizacion"))
            cFechaTermino = Trim(drDato("FechaTerminacion"))
            cRepresentante1 = Trim(drDato("Nomrepr"))
            cRepresentante2 = Trim(drDato("Nomrepr2"))
            cSemilla = drDato("Semilla")
            cSucursal = drDato("Sucursal")
            cGarPrend = drDato("GarantiaPrendaria")
            cGarHipot = drDato("GarantiaHipotecaria")
            cParafin = drDato("Parafin")
            cCiclo = drDato("Ciclo")
            cGaranteHip = drDato("GaranteHip")
            cGarantePre = drDato("GarantePre")

            If Trim(cGaranteHip) = "" And Trim(cGarantePre) = "" Then
                txtGHipotecario.ReadOnly = False
                txtGPrendario.ReadOnly = False
            Else
                txtGHipotecario.Text = Trim(cGaranteHip)
                txtGHipotecario.ReadOnly = True
                txtGPrendario.Text = Trim(cGarantePre)
                txtGPrendario.ReadOnly = True
            End If

            cFechaSiembra = "DEL " & Mes(drDato("FechaSiembrai")) & " AL " & Mes(drDato("FechaSiembraf"))
            If cFSiembra2 <> "" Then
                cFechaSiembra = cFechaSiembra & ", " & cFSiembra2
            End If
            If cFSiembra3 <> "" Then
                cFechaSiembra = cFechaSiembra & ", " & cFSiembra3
            End If
            cFechaCosecha = "DEL " & Mes(drDato("FechaCosechai")) & " AL " & Mes(drDato("Fechacosechaf"))
            If cFCosecha2 <> "" Then
                cFechaCosecha = cFechaCosecha & ", " & cFCosecha2
            End If
            If cFCosecha3 <> "" Then
                cFechaCosecha = cFechaCosecha & ", " & cFCosecha3
            End If
            cComision = "0 "

            If cParafin = "S" Then
                Label12.Visible = True
                txtPorcomi.Visible = True
                txtPorcomi.Text = drDato("Porcomi")
            End If

            If Trim(drDato("FechaContrato")) <> "" Then
                cFechaFirma = drDato("FechaContrato")
                DateTimePicker1.Value = CTOD(drDato("FechaContrato"))
            Else
                cFechaFirma = DTOC(DateTimePicker1.Value)
            End If

            If Trim(drDato("FechaLimiteDTC")) <> "" Then
                DateTimePicker2.Value = CTOD(drDato("FechaLimiteDTC"))
            End If

            With cm3
                .CommandType = CommandType.Text
                .CommandText = "SELECT Ciclos.* FROM Ciclos WHERE Ciclo = " & "'" & cCiclo & "'"
                .Connection = cnAgil
            End With
            daCiclos.Fill(dsAgil, "Ciclos")

            drCiclo = dsAgil.Tables("Ciclos").Rows(0)
            If Mid(drCiclo("DescCiclo"), 1, 4) = "P.V." Then
                If cSemilla <> "A" Then
                    cDescCiclo = "Primavera-Verano " & Trim(Mid(drCiclo("DescCiclo"), 6, 4))
                Else
                    cDescCiclo = "Primavera-Verano " & Trim(Mid(drCiclo("DescCiclo"), 6, 4)) & "-" & Trim(Mid(drCiclo("DescCiclo"), 6, 4))
                End If
                If cCiclo2 <> "" Then
                    If cSemilla <> "A" Then
                        cDescCiclo = cDescCiclo & ", Primavera-Verano " & cCiclo2
                    Else
                        cDescCiclo = cDescCiclo & ", Primavera-Verano " & cCiclo2 & "-" & cCiclo2
                    End If
                End If
                If cCiclo3 <> "" Then
                    If cSemilla <> "A" Then
                        cDescCiclo = cDescCiclo & ", Primavera-Verano " & cCiclo3
                    Else
                        cDescCiclo = cDescCiclo & ", Primavera-Verano " & cCiclo3 & "-" & cCiclo3
                    End If
                End If
            Else
                cDescCiclo = "Otoño-Invierno " & Trim(Mid(drCiclo("DescCiclo"), 6, 9))
                If cCiclo2 <> "" Then
                    cDescCiclo = cDescCiclo & ", Otoño-Invierno " & cCiclo2
                End If
                If cCiclo3 <> "" Then
                    cDescCiclo = cDescCiclo & ", Otoño-Invierno " & cCiclo3
                End If
            End If

            Dim nMeses As Integer
            Dim n As Integer
            Dim nDiasInt As Integer
            Dim nBaseImp As Decimal
            Dim nTasas As Decimal
            Dim nInteres As Decimal
            Dim nTIR As Decimal
            Dim cFechai As String
            Dim cFechaf As String

            nMeses = DateDiff(DateInterval.Month, CTOD(cFechaAutorizacion), CTOD(cFechaTermino)) + 1
            nBaseImp = Round(nImporte / nMeses, 2)

            'Procedemos a llenar el arreglo para el cálculo de TIR
            Dim Valores(nMeses + 1) As Double
            Dim Guess As Double

            With cm2
                .CommandType = CommandType.Text
                .CommandText = "SELECT Valor FROM Hista WHERE Vigencia = " & "'" & cFechaAutorizacion & "'"
                .Connection = cnAgil
            End With
            daTiie.Fill(dsAgil, "Tiie")

            drTiie = dsAgil.Tables("Tiie").Rows(0)
            nTasas = drTiie("Valor") + Val(cDiferencialFINAGIL)

            Valores(0) = -nImporte
            For n = 1 To nMeses
                If n = 1 Then
                    cFechai = cFechaAutorizacion
                    cFechaf = DTOC(DateSerial(Year(CTOD(cFechai)), Month(CTOD(cFechai)) + 1, 0))
                    nDiasInt = DateDiff(DateInterval.Day, CTOD(cFechai), CTOD(cFechaf))
                    nInteres = Round(((nImporte * nTasas / 100) / 360) * nDiasInt, 2)
                    Valores(n) = nBaseImp + nInteres
                End If
                cFechai = cFechaf
                cFechaf = DTOC(DateAdd(DateInterval.Day, 1, CTOD(cFechaf)))
                cFechaf = DTOC(DateSerial(Year(CTOD(cFechaf)), Month(CTOD(cFechaf)) + 1, 0))
                nImporte = nImporte + nInteres
                nDiasInt = DateDiff(DateInterval.Day, CTOD(cFechai), CTOD(cFechaf))
                nInteres = Round(((nImporte * nTasas / 100) / 360) * nDiasInt, 2)
                Valores(n) = nBaseImp + nInteres
            Next
            Guess = 0.05
            nTIR = Round(IRR(Valores, Guess) * 100, 3)
            nCAT = Round((Round(Pow(1 + (nTIR / 100), 12), 8) - 1) * 100, 2)

            If Trim(cRepresentante1) <> "" Or Trim(cRepresentante2) <> "" Then
                cParrafoRepres = ", QUIENES MANIFIESTAN BAJO PROTESTA DE DECIR VERDAD QUE LAS FACULTADES  DE REPRESENTACION QUE LES FUERON OTORGADAS"
                cParrafoRepres = cParrafoRepres & ", NO LES HAN SIDO REVOCADAS NI LIMITADAS EN FORMA ALGUNA A LA FECHA DE CELEBRACION  DE ESTE ACTO."
                If LTrim(cRepresentante2) <> "" Then
                    cRepresentante = " REPRESENTADA EN ESTE ACTO POR " & LTrim(cRepresentante1) & " Y POR " & LTrim(cRepresentante2)
                    cFirman = cRepresentante1 & " Y " & cRepresentante2
                Else
                    cRepresentante = " REPRESENTADA EN ESTE ACTO POR " & LTrim(cRepresentante1)
                    cFirman = cRepresentante1
                End If
            End If

            If cGarPrend = "SI" And cGarHipot = "SI" Then
                cGarantias = "GARANTIA PRENDARIA Y GARANTIA HIPOTECARIA"
            ElseIf cGarPrend = "SI" And cGarHipot <> "SI" Then
                cGarantias = "GARANTIA PRENDARIA"
            ElseIf cGarPrend <> "SI" And cGarHipot = "SI" Then
                cGarantias = "GARANTIA HIPOTECARIA"
            End If

            If cSemilla = "" Then
                ckbTrigo.Enabled = False
                ckbMaiz.Enabled = False
                ckbSorgo.Enabled = False
                ckbCartamo.Enabled = False
                ckbAlgodon.Enabled = False
                ckbGarbanzo.Enabled = False
            ElseIf cSemilla = "T" Then
                ckbTrigo.Checked = True
                ckbTrigo.Enabled = False
                ckbAlgodon.Enabled = False
                ckbMaiz.Enabled = False
                ckbSorgo.Enabled = False
                ckbCartamo.Enabled = False
                ckbGarbanzo.Enabled = False
            ElseIf cSemilla = "M" Then
                ckbTrigo.Enabled = False
                ckbMaiz.Checked = True
                ckbMaiz.Enabled = False
                ckbAlgodon.Enabled = False
                ckbSorgo.Enabled = False
                ckbCartamo.Enabled = False
                ckbGarbanzo.Enabled = False
            ElseIf cSemilla = "S" Then
                ckbTrigo.Enabled = False
                ckbMaiz.Enabled = False
                ckbSorgo.Checked = True
                ckbSorgo.Enabled = False
                ckbAlgodon.Enabled = False
                ckbCartamo.Enabled = False
                ckbGarbanzo.Enabled = False
            ElseIf cSemilla = "C" Then
                ckbTrigo.Enabled = False
                ckbMaiz.Enabled = False
                ckbSorgo.Enabled = False
                ckbCartamo.Checked = True
                ckbCartamo.Enabled = False
                ckbAlgodon.Enabled = False
                ckbGarbanzo.Enabled = False
            ElseIf cSemilla = "A" Then
                ckbTrigo.Enabled = False
                ckbMaiz.Enabled = False
                ckbSorgo.Enabled = False
                ckbCartamo.Enabled = False
                ckbAlgodon.Checked = True
                ckbAlgodon.Enabled = False
                ckbGarbanzo.Enabled = False
            ElseIf cSemilla = "G" Then
                ckbTrigo.Enabled = False
                ckbMaiz.Enabled = False
                ckbSorgo.Enabled = False
                ckbCartamo.Enabled = False
                ckbAlgodon.Enabled = False
                ckbGarbanzo.Checked = True
                ckbGarbanzo.Enabled = False
            End If
            ' Proceso los nombres de los avales

            cAval1 = Trim(drDato("NomCoac"))
            cAval2 = Trim(drDato("NomObli"))
            cAval3 = Trim(drDato("NomAval1"))
            cAval4 = Trim(drDato("NomAval2"))

            If cAval1 <> "" Then
                lbAvales.Items.Add(cAval1)
                If drDato("TipCoac") = "M" Then
                    cDatosAval = Chr(10) & "Obligado Solidario y Aval " & cAval1 & " por conducto de su representante declara: " & Chr(10) & drDato("GeneCoac")
                    cDatosAval = cDatosAval & Chr(10) & " su representante " & drDato("NomrCoac") & Chr(10) & drDato("Genercoa") & Chr(10) & Chr(10) & drDato("PoderCoa")
                Else
                    cDatosAval = Chr(10) & "Obligado Solidario y Aval " & cAval1 & " declara: " & Chr(10) & drDato("GeneCoac")
                End If
            End If
            If cAval2 <> "" Then
                lbAvales.Items.Add(cAval2)
                If drDato("TipoObli") = "M" Then
                    cDatosAval = cDatosAval & Chr(10) & Chr(10) & "Obligado Solidario y Aval " & cAval2 & " por conducto de su representante declara: " & Chr(10) & drDato("GeneObli")
                    cDatosAval = cDatosAval & Chr(10) & " su representante " & drDato("NomrObl") & Chr(10) & drDato("GenerObl") & Chr(10) & Chr(10) & drDato("PoderObl")
                Else
                    cDatosAval = cDatosAval & Chr(10) & Chr(10) & "Obligado Solidario y Aval " & cAval2 & " declara: " & Chr(10) & drDato("GeneObli")
                End If
            End If
            If cAval3 <> "" Then
                lbAvales.Items.Add(cAval3)
                If drDato("TipAval1") = "M" Then
                    cDatosAval = cDatosAval & Chr(10) & Chr(10) & "Obligado Solidario y Aval " & cAval3 & " por conducto de su representante declara: " & drDato("Geneava1")
                    cDatosAval = cDatosAval & Chr(10) & " su representante " & drDato("NomrAva1") & Chr(10) & drDato("GenerAv1") & Chr(10) & Chr(10) & drDato("Poderav1")
                Else
                    cDatosAval = cDatosAval & Chr(10) & Chr(10) & "Obligado Solidario y Aval " & cAval3 & " declara: " & Chr(10) & drDato("GeneAva1")
                End If
            End If
            If cAval4 <> "" Then
                lbAvales.Items.Add(cAval4)
                If drDato("TipAval2") = "M" Then
                    cDatosAval = cDatosAval & Chr(10) & Chr(10) & "Obligado Solidario y Aval " & cAval4 & " por conducto de su representante declara: " & drDato("GeneAva2")
                    cDatosAval = cDatosAval & Chr(10) & " su representante " & drDato("NomrAva2") & Chr(10) & drDato("GenerAv2") & Chr(10) & Chr(10) & drDato("Poderav2")
                Else
                    cDatosAval = cDatosAval & Chr(10) & Chr(10) & "Obligado Solidario y Aval " & cAval4 & " declara: " & Chr(10) & drDato("GeneAva2")
                End If
            End If

            If cSucursal = "05" Then
                cNum = "III. " & "Declara(n) el(los) Obligado(s) y Aval(es):" & Chr(10) & Chr(10) & cDatosAval & Chr(10)
                cNum1 = "IV."
                cNum2 = "V. "
            Else
                cNum = ""
                cNum1 = "III." & "Declara(n) el(los) Obligado(s) y Aval(es):" & Chr(10) & Chr(10) & cDatosAval & Chr(10)
                cNum2 = "IV. "
            End If

            cGarantiaPrendaria = drDato("GarantiaPrendaria")
            cGarantiaHipotecaria = drDato("GarantiaHipotecaria")
            cGarantiaUsufructo = drDato("GarantiaUsufructo")
            nRendimiento = drDato("ToneladasHectarea")
            nToneladas = nHectareas * nRendimiento
            cHectareas = Format(nHectareas, "##,##0.00")
            cToneladas = Format(nToneladas, "##,##0.00")
            cRendimiento = Format(nRendimiento, "##,##0.00")
            nPlazoCred = DateDiff(DateInterval.Day, CTOD(cFechaFirma), CTOD(cFechaTermino))

            If cFechaAutorizacion = "" Or nRendimiento = 0 Or nHectareas = 0 Or nImporte = 0 Or Val(cDiferencialFINAGIL) = 0 Then
                btnImprimir.Enabled = False
                btnImpPagare.Enabled = False
                gbPagare.Visible = False
            End If

            If cSucursal = "03" Then
                cEmpcv = "TABLEX MILLER S DE RL DE CV"
                cLugar = "Navojoa, Sonora"
                cOtros = "JUPARE" & Chr(13) & "NACORI" & Chr(13) & "ALTAR" & Chr(13) & "BANAMICHI" & Chr(13) & "SAMAYOA" & Chr(13) & "CIRNO" & Chr(13) & "SAWALLI" & Chr(13) & "PATRONATO" & Chr(13) & "CHAPULTEPEC" & Chr(13) & "IMPERIAL" & Chr(13) & "MOVAS" & Chr(13) & "HUATABAMBO"
                If cSemilla = "M" Then
                    cOtros = "DAS2355" & Chr(13) & "DAS2303" & Chr(13) & "WX7314MAX" & Chr(13) & "MAX915" & Chr(13) & "AS-501" & Chr(13) & "TORNADO XR" & Chr(13) & "XR47" & Chr(13) & "BISONTE" & Chr(13) & "CEBU" & Chr(13) & "GARAÑON"
                    cOtros = cOtros & Chr(13) & "P30P49W" & Chr(13) & "30P45W" & Chr(13) & "NOROESTE 339" & Chr(13) & "NOROESTE 478" & Chr(13) & "NH5" & Chr(13) & "NV10" & Chr(13) & "NB17" & Chr(13) & "GENEX 766" & Chr(13) & "PANTERA"
                    cOtros = cOtros & Chr(13) & "PUMA" & Chr(13) & "DEKALB 2020" & Chr(13) & "PIONEER 31G66" & Chr(13) & "A7573" & Chr(13) & "ETC."
                End If
                cTestigos = "LLamarse ROSARIO LEON ARMENTA, de profesión Ingeniero Agrónomo Fitotecnista, originario de Pueblo Yaqui, Sonora lugar donde nació el "
                cTestigos = cTestigos & " 2 de febrero de 1966, con R.F.C. LEAR660202L82, de estado civil casado. "
                cTestigos = cTestigos & Chr(10) & "LLamarse MITZI LOPEZ BOJORQUEZ, de profesión Licenciada en Sistemas de información administrativa, originario de la Ciudad de México Distrito Federal lugar donde nació el "
                cTestigos = cTestigos & " 07 de noviembre de 1980, con R.F.C. LOBM8011071JA, de estado civil soltera. "
                cFirmaTestigo1 = "ING. ROSARIO LEON ARMENTA"
                cFirmaTestigo2 = "LIC. MITZI LOPEZ BOJORQUEZ"
                cUnidadEsp = "Avenida No Reelección número 712 sur, colonia Centro, entre las calles de Manuel Doblado y Nicolás Bravo, Navojoa Sonora México, CP 85800.   Los teléfonos de atención a usuarios serán: (642) 422 32 44, (642) 422 56 50  y 01 800 836 23 92,"
                If cSemilla = "T" Then
                    cTrianual = " ANUAL"
                    cPrimera = " Dicho monto se otorgara por cada ciclo o periodo productivo autorizado a favor del productor acreditado quien acepta el crédito."
                    cSegunda = Chr(10) & Chr(10) & "SEGUNDA.- PLAZO DEL CREDITO. El crédito mencionado en la clausula primera se otorgara por un plazo de tres años, contados a partir de la fecha de la primera disposición del primer ciclo del periodo productivo."
                End If
            ElseIf cSucursal = "04" Then
                cEmpcv = "MOLINOS DEL SUDESTE SA DE CV"
                cLugar = "Mexicali, Baja California"
                cTestigos = "LLamarse JESUS OSCAR CRUZ TERAN, de profesión Ingeniero Agrónomo, originario de Rayón, Estado de Sonora México, lugar donde nació el "
                cTestigos = cTestigos & " 11 de diciembre de 1958, con R.F.C. CUTJ581211JB1, de estado civil casado. "
                cTestigos = cTestigos & Chr(10) & "LLamarse SANDRA ISABEL DUARTE DIAZ, de profesión Técnica Agropecuaria, originaria de Mexicali, B.C. lugar donde nació el "
                cTestigos = cTestigos & " 23 de septiembre de 1978, con R.F.C. DUDS780923HK8, de estado civil casada. "
                cFirmaTestigo1 = "ING. JESUS OSCAR CRUZ TERAN"
                cFirmaTestigo2 = "TEC. SANDRA ISABEL DUARTE DIAZ"
                cUnidadEsp = "Rio San Angel No. 48 Locales 7 y 8, Centro Comercial Mar y Sal, Col. Valle de Puebla, C.P. 21384, Mexicali, BAJA CALIFORNIA.   Los teléfonos de atención a usuarios serán: (686) 577 80 55, (686) 577 80 60 y 01 800 626 02 07,"
                cOtros = "ATIL" & Chr(13) & "CEMEXI" & Chr(13) & "RARI" & Chr(13) & "RIO COLORADO" & Chr(13) & "ORITA"
            ElseIf cSucursal = "05" Then
                cEmpcv = "'AGROPRODUCTORES DE LA RIBERA DEL LERMA' SOCIEDAD DE PRODUCCION RURAL DE RESPONSABILIDAD LIMITADA a través de HARINERA LOS PIRINEOS SA DE CV"
                cPirineos = " a través de HARINERA LOS PIRINEOS S.A. DE C.V., "
                cC_Venta = "Lo anterior en base al "
                cC_Venta2 = "de conformidad con el "
                cCtoC_Venta = "contrato de compraventa del Ciclo Agrícola Primavera-Verano 2011 suscrito entre 'AGROPRODUCTORES DE LA RIBERA DEL LERMA' SOCIEDAD DE PRODUCCION RURAL DE RESPONSABILIDAD LIMITADA Y HARINERA LOS PIRINEOS S.A. DE C.V."
                If cSemilla = "S" Then
                    cOtros = "8133 PIONNER" & Chr(13) & "81T91 PIONNER" & Chr(13) & "81G47 PIONNER" & Chr(13) & "84G48 PIONNER" & Chr(13) & "GALIO ASGROW" & Chr(13) & "KILATE ASGROW" & Chr(13) & "NIQUEL ASGROW" & Chr(13) & "PINO AVANTE" & Chr(13) & "MEZQUITE AVANTE" & Chr(13) & "FRESNO AVANTE" & Chr(13) & "NOGAL AVANTE" & Chr(13) & "DKS43 DKALB" & Chr(13) & "DKS74 DKALB" & Chr(13) & "DKS46 DKALB"
                ElseIf cSemilla = "M" Then
                    cOtros = "P3368W PIONNER" & Chr(13) & "P2946W PIONNER" & Chr(13) & "32D06 PIONNER" & Chr(13) & "30P16 PIONNER" & Chr(13) & "RIO GRANDE AVANTE" & Chr(13) & "TRES RIOS AVANTE"
                End If
                cLugar = "Irapuato, Guanajuato"
                cTestigos = "LLamarse VIOLETA MARIA LUCIA TEZCUCANO CONTRERAS, de profesión Licenciada en Contaduría, originario de Irapuato, Guanajuato lugar donde nació el "
                cTestigos = cTestigos & " 17 de enero de 1984, con R.F.C. TECV8401179F0, de estado civil casada. "
                cTestigos = cTestigos & Chr(10) & "LLamarse RAUL ARMANDO VENEGAS MIRANDA, de profesión Ingeniero, originaria de Irapuato, Guanajuato lugar donde nació el "
                cTestigos = cTestigos & " 01 de enero de 1978, con R.F.C. VEMR780101183, de estado civil casado. "
                cFirmaTestigo1 = "LIC. VIOLETA MARIA LUCIA TEZCUCANO CONTRERAS"
                cFirmaTestigo2 = "ING. RAUL ARMANDO VENEGAS MIRANDA"
                cUnidadEsp = "Av. de los Insurgentes No. 2604 Local B-4, Col. Plaza Inn, Col. Los Fresnos, C.P. 36555, Irapuato, GUANAJUATO.   Los teléfonos de atención a usuarios serán: (462) 623 62 31, (462) 623 64 61 y 01 800 837 74 76,"
            ElseIf cSucursal = "06" Then
                cEmpcv = "MOLINOS DEL FENIX SA DE CV"
                cLugar = "Saltillo, Coahuila"
                cTestigos = "LLamarse MARIO RUIZ URBINA, de profesión Ing. Agrónomo, originario de Monterrey, Nuevo León, lugar donde nació el "
                cTestigos = cTestigos & " 19 de enero de 1961, con R.F.C. RUUM610119MG3, de estado civil casado. "
                cTestigos = cTestigos & Chr(10) & "LLamarse FRANCISCO JAVIER MARTINEZ GARCIA, de profesión Ing. Agrónomo, originario de Saltillo, Coahuila, lugar donde nació el "
                cTestigos = cTestigos & " 03 de septiembre de 1955, con R.F.C. MAGF550903, de estado civil casada. "
                cFirmaTestigo1 = "ING. MARIO RUIZ URBINA"
                cFirmaTestigo2 = "ING. FRANCISCO JAVIER MARTINEZ GARCIA"
            End If

            If cSemilla = "A" Then
                cOtros = "DELTA PINE 0912" & Chr(13) & "STONEVILLE 4498" & Chr(13) & "STONEVILLE 4554"
                cAgroquimi = "COLOSO" & Chr(13) & "FAENA FORTE" & Chr(13) & "GLIFOX MAX"
                cAgroquimi2 = "METAMIDOFOS" & Chr(13) & "TALSTAR" & Chr(13) & "THIODAN"
            Else
                cAgroquimi = "DIAMIME(400)" & Chr(13) & "PERFEKTION()" & Chr(13) & "DIAMINE(480)" & Chr(13) & "AMINA(4)" & Chr(13) & "SUTUI(XL)" & Chr(13) & "ETC."
                cAgroquimi2 = "NO APLICA"
            End If

            txtNombreProductor.Text = Trim(cDescr)
            txtNombreRepresentante.Text = Trim(cRepresentante)
            txtHectareas.Text = Format(nHectareas, "##,##0.00")
            txtToneladasHectarea.Text = Format(nRendimiento, "##,##0.00")
            txtDiferencialFINAGIL.Text = cDiferencialFINAGIL
            lblFechaFirma.Text = cFechaFirma
            lblGarantiaPrendaria.Text = cGarantiaPrendaria
            lblGarantiaHipotecaria.Text = cGarantiaHipotecaria
            lblMontoCredito.Text = "$" & cImporte & " " & cCantidad

            If Val(cCliente) < 8501 Or Val(cCliente) > 8600 Then
                If cGarantiaHipotecaria = "SI" Then
                    lblNotarioRegistrador.Text = "Enviar a firma con el Notario Público 67 de Navojoa, Sonora el Lic. Jorge de Jesús Martínez Almada"
                Else
                    lblNotarioRegistrador.Text = "Enviar a firma con el Registrador de Crédito Agrícola el Lic. Genaro Rojas Cañez"
                End If
            Else
                lblNotarioRegistrador.Text = "Contrato de GUANAJUATO"
            End If

            If cTipo = "M" Then
                cEncabezado = txtAnexo.Text & " QUE CELEBRAN POR UNA PARTE " & txtNombreProductor.Text & _
                                    " REPRESENTADA POR " & cRepresentante & " EN LO SUCESIVO EL " & _
                                      Chr(34) & "PRODUCTOR ACREDITADO" & Chr(34)
                cEncabezado2 = "LOS QUE SUSCRIBEN " & txtNombreProductor.Text & " REPRESENTADA POR " & cRepresentante
            Else
                cEncabezado = txtAnexo.Text & " QUE CELEBRAN POR UNA PARTE " & txtNombreProductor.Text & _
                                      " EN LO SUCESIVO EL " & _
                                      Chr(34) & "PRODUCTOR ACREDITADO" & Chr(34)
                cEncabezado2 = "LOS QUE SUSCRIBEN " & txtNombreProductor.Text
            End If

            If lbAvales.Items.Count > 0 Then
                If lbAvales.Items.Count = 1 Then
                    cEncabezado = cEncabezado & " Y COMO AVAL " & lbAvales.Items(0) & " EN LO SUCESIVO EL " & _
                                  Chr(34) & "AVAL" & Chr(34)
                    cEncabezado2 = cEncabezado2 & " Y COMO AVAL " & lbAvales.Items(0)
                ElseIf lbAvales.Items.Count = 2 Then
                    cEncabezado = cEncabezado & " Y COMO AVALES " & lbAvales.Items(0) & " Y " & lbAvales.Items(1)
                    cEncabezado2 = cEncabezado2 & " Y COMO AVALES " & lbAvales.Items(0) & " Y " & lbAvales.Items(1)
                ElseIf lbAvales.Items.Count = 3 Then
                    cEncabezado = cEncabezado & " Y COMO AVALES " & lbAvales.Items(0) & ", " & lbAvales.Items(1) & " Y " & lbAvales.Items(2)
                    cEncabezado2 = cEncabezado2 & " Y COMO AVALES " & lbAvales.Items(0) & ", " & lbAvales.Items(1) & " Y " & lbAvales.Items(2)
                ElseIf lbAvales.Items.Count = 4 Then
                    cEncabezado = cEncabezado & " Y COMO AVALES " & lbAvales.Items(0) & ", " & lbAvales.Items(1) & ", " & lbAvales.Items(2) & " Y " & lbAvales.Items(3)
                    cEncabezado2 = cEncabezado2 & " Y COMO AVALES " & lbAvales.Items(0) & ", " & lbAvales.Items(1) & ", " & lbAvales.Items(2) & " Y " & lbAvales.Items(3)
                End If
            End If

            cEncabezado = cEncabezado & " Y POR OTRA PARTE FINAGIL, S.A. DE C.V. SOFOM, E.N.R. EN LO SUCESIVO " & _
                          Chr(34) & "FINAGIL" & Chr(34) & _
                          " AL TENOR DE LAS SIGUIENTES DECLARACIONES Y CLÁUSULAS."

            If cGarantiaPrendaria = "SI" Then

                cMuebles = drDato("Muebles")

                cParrafoPrenda = Chr(13) & Chr(10) & "Adicionalmente, el PRODUCTOR ACREDITADO constituye prenda sobre el(los) bien(es) mueble(s) (cuyas características mencionadas en el inciso l) " & _
                                "de la Declaración I se  tienen por reproducidas íntegramente en la presente cláusula como si se insertasen a la letra) a favor de FINAGIL, " & _
                                "la cual acepta en este acto (en lo sucesivo, la PRENDA) quedando éste(os) en posesión del PRODUCTOR ACREDITADO, y constituyéndose en depositario judicial " & _
                                "de los mismos para efectos de responsabilidades civiles o penales, de conformidad con lo que establece el artículo 329 de la LGTOC, " & _
                                "dándose por recibido de los mismos y designando como lugar de depósito el ubicado en "
                cParrafoPrenda = cParrafoPrenda & cCalle & ", COL. " & cColonia & ", C.P. " & cCopos & ", " & cDelegacion & ", " & cEstado & "."

            End If

            ' If Val(cCliente) < 8501 Or Val(cCliente) > 8600 Then
            If cSucursal = "03" Then
                If cGarantiaHipotecaria = "SI" Then
                    cInmuebles = drDato("Inmuebles")

                    cGravamen = Chr(13) & Chr(10) & "m)  Que a la fecha del presente contrato dicho(s) inmueble(s) se encuentra(n) libre(s) de todo gravamen y limitación de dominio, según consta " & _
                                    "en el (los) certificado(s) de gravámenes de fecha _______ emitido(s) por el Registro Público de la Propiedad de _________."

                    cParrafoHipoteca = "Asimismo, en garantía del cumplimiento parcial o total de las Obligaciones Garantizadas, el PRODUCTOR ACREDITADO en este acto constituye hipoteca en primer lugar y grado sobre el(los) inmueble(s) (cuyas características mencionadas en el inciso l) de la Declaración I se  tienen por reproducidas íntegramente en la presente cláusula como si se insertasen a la letra) a favor de FINAGIL, la cual acepta en este acto (en lo sucesivo, la Hipoteca)." & Chr(13) & Chr(10) & _
                                        Chr(13) & Chr(10) & "a) Registro. La Hipoteca deberá ser registrada en términos del Capítulo correspondiente del Código Civil del Estado de Sonora." & Chr(13) & Chr(10) & _
                                        Chr(13) & Chr(10) & "b) Vigencia. La Hipoteca permanecerá vigente hasta la fecha en que se hayan cumplido todas y cada una de las Obligaciones Garantizadas, y subsistirá íntegra aunque éstas se reduzcan, independientemente de la causa de su reducción. Asimismo, subsistirá no obstante cualquier modificación a las Obligaciones Garantizadas, incluyendo de manera enunciativa pero no limitativa, quita, prórroga o espera." & Chr(13) & Chr(10) & _
                                        Chr(13) & Chr(10) & "c) Intereses. Las partes expresamente convienen en que la Hipoteca garantiza los intereses que devengue el Crédito aún en exceso del término de tres años, lo que deberá hacerse constar en la inscripción que de esta escritura se realice en el Registro Público, según lo dispuesto por el artículo 2915 del Código Civil Federal." & Chr(13) & Chr(10) & _
                                        Chr(13) & Chr(10) & "d) Impuestos y Gastos. Todos los impuestos y gastos que se deriven de la constitución de la Hipoteca serán por exclusiva cuenta del PRODUCTOR ACREDITADO, así como aquéllos que se deriven de su registro ante el Registro Público de la Propiedad del Estado de Sonora. Si FINAGIL efectuare cualquier pago por los conceptos que se señalan en esta cláusula podrá repercutir en contra del PRODUCTOR ACREDITADO el importe de dichos pagos más intereses a razón de la tasa de interés de carácter moratorio prevista en la Cláusula NOVENA del presente contrato, a partir de la fecha en que se efectúen dichos pagos y hasta la fecha en que se reembolse la totalidad de los mismos, quedando dicho reembolso garantizado con la Hipoteca." & Chr(13) & Chr(10)
                End If
            ElseIf cSucursal = "05" Then
                If cGarantiaHipotecaria = "SI" Then
                    cInmuebles = drDato("Inmuebles")

                    cParrafoHipoteca = "Asimismo, en garantía del cumplimiento parcial o total de las Obligaciones Garantizadas, el PRODUCTOR ACREDITADO en este acto constituye hipoteca en primer lugar y grado sobre el(los) inmueble(s) (cuyas características mencionadas en el inciso l) de la Declaración I se  tienen por reproducidas íntegramente en la presente cláusula como si se insertasen a la letra) a favor de FINAGIL, la cual acepta en este acto (en lo sucesivo, la Hipoteca)." & Chr(13) & Chr(10) & _
                                        Chr(13) & Chr(10) & "a) Registro. La Hipoteca deberá ser registrada en términos del Capítulo correspondiente del Código Civil del Estado de Guanajuato." & Chr(13) & Chr(10) & _
                                        Chr(13) & Chr(10) & "b) Vigencia. La Hipoteca permanecerá vigente hasta la fecha en que se hayan cumplido todas y cada una de las Obligaciones Garantizadas, y subsistirá íntegra aunque éstas se reduzcan, independientemente de la causa de su reducción. Asimismo, subsistirá no obstante cualquier modificación a las Obligaciones Garantizadas, incluyendo de manera enunciativa pero no limitativa, quita, prórroga o espera." & Chr(13) & Chr(10) & _
                                        Chr(13) & Chr(10) & "c) Intereses. Las partes expresamente convienen en que la Hipoteca garantiza los intereses que devengue el Crédito aún en exceso del término de tres años, lo que deberá hacerse constar en la inscripción que de esta escritura se realice en el Registro Público, según lo dispuesto por el artículo 2915 del Código Civil Federal." & Chr(13) & Chr(10) & _
                                        Chr(13) & Chr(10) & "d) Impuestos y Gastos. Todos los impuestos y gastos que se deriven de la constitución de la Hipoteca serán por exclusiva cuenta del PRODUCTOR ACREDITADO, así como aquéllos que se deriven de su registro ante el Registro Público de la Propiedad del Estado de Guanajuato. Si FINAGIL efectuare cualquier pago por los conceptos que se señalan en esta cláusula podrá repercutir en contra del PRODUCTOR ACREDITADO el importe de dichos pagos más intereses a razón de la tasa de interés de carácter moratorio prevista en la Cláusula NOVENA del presente contrato, a partir de la fecha en que se efectúen dichos pagos y hasta la fecha en que se reembolse la totalidad de los mismos, quedando dicho reembolso garantizado con la Hipoteca." & Chr(13) & Chr(10)
                End If
            End If

            If cSucursal = "04" Then
                If cGarantiaHipotecaria = "SI" Then
                    cInmuebles = drDato("Inmuebles")

                    cParrafoHipoteca = "Asimismo, en garantía del cumplimiento parcial o total de las Obligaciones Garantizadas, el PRODUCTOR ACREDITADO en este acto constituye hipoteca en primer lugar y grado sobre el(los) inmueble(s) (cuyas características mencionadas en el inciso l) de la Declaración I se  tienen por reproducidas íntegramente en la presente cláusula como si se insertasen a la letra) a favor de FINAGIL, la cual acepta en este acto (en lo sucesivo, la Hipoteca)." & Chr(13) & Chr(10) & _
                                        Chr(13) & Chr(10) & "a) Registro. La Hipoteca deberá ser registrada en términos del Capítulo correspondiente del Código Civil del Estado de Baja California." & Chr(13) & Chr(10) & _
                                        Chr(13) & Chr(10) & "b) Vigencia. La Hipoteca permanecerá vigente hasta la fecha en que se hayan cumplido todas y cada una de las Obligaciones Garantizadas, y subsistirá íntegra aunque éstas se reduzcan, independientemente de la causa de su reducción. Asimismo, subsistirá no obstante cualquier modificación a las Obligaciones Garantizadas, incluyendo de manera enunciativa pero no limitativa, quita, prórroga o espera." & Chr(13) & Chr(10) & _
                                        Chr(13) & Chr(10) & "c) Intereses. Las partes expresamente convienen en que la Hipoteca garantiza los intereses que devengue el Crédito aún en exceso del término de tres años, lo que deberá hacerse constar en la inscripción que de esta escritura se realice en el Registro Público, según lo dispuesto por el artículo 2915 del Código Civil Federal." & Chr(13) & Chr(10) & _
                                        Chr(13) & Chr(10) & "d) Impuestos y Gastos. Todos los impuestos y gastos que se deriven de la constitución de la Hipoteca serán por exclusiva cuenta del PRODUCTOR ACREDITADO, así como aquéllos que se deriven de su registro ante el Registro Público de la Propiedad del Estado de Baja California. Si FINAGIL efectuare cualquier pago por los conceptos que se señalan en esta cláusula podrá repercutir en contra del PRODUCTOR ACREDITADO el importe de dichos pagos más intereses a razón de la tasa de interés de carácter moratorio prevista en la Cláusula NOVENA del presente contrato, a partir de la fecha en que se efectúen dichos pagos y hasta la fecha en que se reembolse la totalidad de los mismos, quedando dicho reembolso garantizado con la Hipoteca." & Chr(13) & Chr(10)
                End If
            End If

            If cSucursal = "06" Then
                If cGarantiaHipotecaria = "SI" Then
                    cInmuebles = drDato("Inmuebles")

                    cParrafoHipoteca = "Asimismo, en garantía del cumplimiento parcial o total de las Obligaciones Garantizadas, el PRODUCTOR ACREDITADO en este acto constituye hipoteca en primer lugar y grado sobre el(los) inmueble(s) (cuyas características mencionadas en el inciso l) de la Declaración I se  tienen por reproducidas íntegramente en la presente cláusula como si se insertasen a la letra) a favor de FINAGIL, la cual acepta en este acto (en lo sucesivo, la Hipoteca)." & Chr(13) & Chr(10) & _
                                        Chr(13) & Chr(10) & "a) Registro. La Hipoteca deberá ser registrada en términos del Capítulo correspondiente del Código Civil del Estado de Coahuila." & Chr(13) & Chr(10) & _
                                        Chr(13) & Chr(10) & "b) Vigencia. La Hipoteca permanecerá vigente hasta la fecha en que se hayan cumplido todas y cada una de las Obligaciones Garantizadas, y subsistirá íntegra aunque éstas se reduzcan, independientemente de la causa de su reducción. Asimismo, subsistirá no obstante cualquier modificación a las Obligaciones Garantizadas, incluyendo de manera enunciativa pero no limitativa, quita, prórroga o espera." & Chr(13) & Chr(10) & _
                                        Chr(13) & Chr(10) & "c) Intereses. Las partes expresamente convienen en que la Hipoteca garantiza los intereses que devengue el Crédito aún en exceso del término de tres años, lo que deberá hacerse constar en la inscripción que de esta escritura se realice en el Registro Público, según lo dispuesto por el artículo 2915 del Código Civil Federal." & Chr(13) & Chr(10) & _
                                        Chr(13) & Chr(10) & "d) Impuestos y Gastos. Todos los impuestos y gastos que se deriven de la constitución de la Hipoteca serán por exclusiva cuenta del PRODUCTOR ACREDITADO, así como aquéllos que se deriven de su registro ante el Registro Público de la Propiedad del Estado de Coahuila. Si FINAGIL efectuare cualquier pago por los conceptos que se señalan en esta cláusula podrá repercutir en contra del PRODUCTOR ACREDITADO el importe de dichos pagos más intereses a razón de la tasa de interés de carácter moratorio prevista en la Cláusula NOVENA del presente contrato, a partir de la fecha en que se efectúen dichos pagos y hasta la fecha en que se reembolse la totalidad de los mismos, quedando dicho reembolso garantizado con la Hipoteca." & Chr(13) & Chr(10)
                End If
            End If

            If cGarantiaUsufructo = "SI" Then
                cUsufructo = drDato("Usufructo")
            End If

            If cAval1 = "" And cAval2 = "" And cAval3 = "" And cAval4 = "" Then
                cAvales = ""
            ElseIf cAval1 <> "" And cAval2 <> "" And cAval3 <> "" And cAval4 <> "" Then
                cAvales = cAval1 & ", " & cAval2 & ", " & cAval3 & " Y " & cAval4
            ElseIf cAval1 <> "" And cAval2 <> "" And cAval3 <> "" And cAval4 = "" Then
                cAvales = cAval1 & ", " & cAval2 & " Y " & cAval3
            ElseIf cAval1 <> "" And cAval2 <> "" And cAval3 = "" And cAval4 = "" Then
                cAvales = cAval1 & " Y " & cAval2
            ElseIf cAval1 <> "" And cAval2 = "" And cAval3 = "" And cAval4 = "" Then
                cAvales = cAval1
            ElseIf cAval1 <> "" And cAval2 <> "" And cAval3 = "" And cAval4 <> "" Then
                cAvales = cAval1 & ", " & cAval2 & " Y " & cAval4
            ElseIf cAval1 <> "" And cAval2 = "" And cAval3 <> "" And cAval4 <> "" Then
                cAvales = cAval1 & ", " & cAval3 & " Y " & cAval4
            ElseIf cAval1 <> "" And cAval2 = "" And cAval3 <> "" And cAval4 = "" Then
                cAvales = cAval1 & " Y " & cAval3
            ElseIf cAval1 <> "" And cAval2 = "" And cAval3 = "" And cAval4 <> "" Then
                cAvales = cAval1 & " Y " & cAval4
            ElseIf cAval1 = "" And cAval2 <> "" And cAval3 <> "" And cAval4 <> "" Then
                cAvales = cAval2 & ", " & cAval3 & " Y " & cAval4
            ElseIf cAval1 = "" And cAval2 <> "" And cAval3 <> "" And cAval4 = "" Then
                cAvales = cAval2 & " Y " & cAval3
            ElseIf cAval1 = "" And cAval2 <> "" And cAval3 = "" And cAval4 <> "" Then
                cAvales = cAval2 & " Y " & cAval4
            ElseIf cAval1 = "" And cAval2 <> "" And cAval3 = "" And cAval4 = "" Then
                cAvales = cAval2
            ElseIf cAval1 = "" And cAval2 = "" And cAval3 <> "" And cAval4 = "" Then
                cAvales = cAval3
            ElseIf cAval1 = "" And cAval2 = "" And cAval3 <> "" And cAval4 <> "" Then
                cAvales = cAval3 & " Y " & cAval4
            End If

            If cAval1 <> "" Then
                cFirmaAval1 = Chr(34) & "OBLIGADO SOLIDARIO Y AVAL" & Chr(34) & Chr(13) & Chr(10) & Chr(13) & Chr(10) & Chr(13) & Chr(10) & "_________________________________" & Chr(10) & cAval1
            End If
            If cAval2 <> "" Then
                cFirmaAval2 = Chr(10) & Chr(10) & Chr(34) & "OBLIGADO SOLIDARIO Y AVAL" & Chr(34) & Chr(13) & Chr(10) & Chr(13) & Chr(10) & Chr(13) & Chr(10) & "_________________________________" & Chr(10) & cAval2
            End If
            If cAval3 <> "" Then
                cFirmaAval3 = Chr(10) & Chr(10) & Chr(34) & "OBLIGADO SOLIDARIO Y AVAL" & Chr(34) & Chr(13) & Chr(10) & Chr(13) & Chr(10) & Chr(13) & Chr(10) & "_________________________________" & Chr(10) & cAval3
            End If
            If cAval4 <> "" Then
                cFirmaAval4 = Chr(10) & Chr(10) & Chr(34) & "OBLIGADO SOLIDARIO Y AVAL" & Chr(34) & Chr(13) & Chr(10) & Chr(13) & Chr(10) & Chr(13) & Chr(10) & "_________________________________" & Chr(10) & cAval4
            End If
            cFirmaFINAGIL = Chr(10) & Chr(10) & Chr(34) & "POR FINAGIL" & Chr(34) & Chr(13) & Chr(10) & Chr(13) & Chr(10) & Chr(13) & Chr(10) & "_________________________________" & Chr(10) & "FINAGIL, S.A. DE C.V. SOFOM E.N.R." & Chr(10) & "APODERADO LEGAL"
            If cFirmaTestigo1 <> "" And cFirmaTestigo2 <> "" Then
                cFirmaFINAGIL = cFirmaFINAGIL & Chr(10) & Chr(10) & Chr(10) & Chr(34) & "TESTIGOS" & Chr(10) & Chr(10) & Chr(10) & Chr(10) & "_________________________________" & Chr(10) & cFirmaTestigo1 & Chr(10) & Chr(10) & Chr(10) & Chr(10) & "_________________________________" & Chr(10) & cFirmaTestigo2
            End If

            If Val(cCliente) < 8501 Or Val(cCliente) > 8600 Then

                If cGarantiaHipotecaria = "SI" Then
                    If cSucursal = "03" Then
                        cLeyendaNotario = "En la Ciudad Obregón, Sonora comparecen ante mí Lic. Luis Carlos Aceves Gutiérrez, Notario Público No. 69 habilitado en todas las clases de " & _
                            "ejercicio, el REPRESENTANTE LEGAL de FINAGIL, S.A. DE C.V. SOFOM E.N.R., en su carácter de ACREDITANTE, y por otra parte " & _
                            txtNombreProductor.Text & " en su carácter de PRODUCTOR ACREDITADO para hacer constar lo siguiente :" & Chr(13) & Chr(10) & Chr(13) & Chr(10) & _
                            "En los términos de lo dispuesto en el artículo 408 de la Ley General de Títulos y Operaciones de Crédito, comparecen en este acto ante el suscrito fedatario " & _
                            "por ser la fiel expresión de sus voluntades, para ratificar el contenido del Contrato de Crédito de Habilitación o Avío No. " & txtAnexo.Text & " " & _
                            "y de los Anexos que forman parte integrante del contrato celebrado entre las partes anteriormente citadas con fecha " & cFechaFirma & " " & _
                            "y reconocer las firmas que lo calzan, por haber sido plasmadas de su puño y letra ante mí y ser las que usan en todos sus actos." & Chr(13) & Chr(10) & Chr(13) & Chr(10) & _
                            "Por lo antes expuesto, yo el fedatario que suscribe, doy fe" & Chr(13) & Chr(10) & Chr(13) & Chr(10) & _
                            "PRIMERO : Que conozco a los comparecientes, quienes tienen capacidad legal para contratar y obligarse." & Chr(13) & Chr(10) & Chr(13) & Chr(10) & _
                            "SEGUNDO : Que los generales y personalidades acreditadas por los comparecientes en las declaraciones del Contrato de Crédito de Habilitación o Avío No. " & txtAnexo.Text & " " & _
                            "fueron debidamente comprobadas por mí, dándolas por reproducidas en el presente instrumento, como si se insertasen a la letra." & Chr(13) & Chr(10) & Chr(13) & Chr(10) & _
                            "TERCERO : Que los comparecientes ratifican en este acto el contenido del Contrato de Crédito de Habilitación o Avío No. " & txtAnexo.Text & " " & _
                            "y de los Anexos adjuntos,  así como las firmas que lo calzan; y" & Chr(13) & Chr(10) & Chr(13) & Chr(10) & _
                            "CUARTO : Que leído que fue este instrumento a los comparecientes y explicado su valor y fuerza legal, determinaron firmarlo de conformidad con lo expresado, " & _
                            "en presencia y unión del suscrito NOTARIO el día " & cFechaFirma & ". DOY FE."
                    ElseIf cSucursal = "04" Then
                        cLeyendaNotario = "En la Ciudad de Mexicali, Baja California comparecen ante mí Lic. Francisco Javier Briseño Arce, Registrador Especial con funciones de Notario, " & _
                        "habilitado en todas las clases de ejercicio, el REPRESENTANTE LEGAL de FINAGIL, S.A. DE C.V. SOFOM E.N.R., en su carácter de ACREDITANTE, y por otra parte " & _
                        txtNombreProductor.Text & " en su carácter de PRODUCTOR ACREDITADO para hacer constar lo siguiente :" & Chr(13) & Chr(10) & Chr(13) & Chr(10) & _
                        "En los términos de lo dispuesto en el artículo 408 de la Ley General de Títulos y Operaciones de Crédito, comparecen en este acto ante el suscrito fedatario " & _
                        "por ser la fiel expresión de sus voluntades, para ratificar el contenido del Contrato de Crédito de Habilitación o Avío No. " & txtAnexo.Text & " " & _
                        "y de los Anexos que forman parte integrante del contrato celebrado entre las partes anteriormente citadas con fecha " & cFechaFirma & " " & _
                        "y reconocer las firmas que lo calzan, por haber sido plasmadas de su puño y letra ante mí y ser las que usan en todos sus actos." & Chr(13) & Chr(10) & Chr(13) & Chr(10) & _
                        "Por lo antes expuesto, yo el fedatario que suscribe, doy fe" & Chr(13) & Chr(10) & Chr(13) & Chr(10) & _
                        "PRIMERO : Que conozco a los comparecientes, quienes tienen capacidad legal para contratar y obligarse." & Chr(13) & Chr(10) & Chr(13) & Chr(10) & _
                        "SEGUNDO : Que los generales y personalidades acreditadas por los comparecientes en las declaraciones del Contrato de Crédito de Habilitación o Avío No. " & txtAnexo.Text & " " & _
                        "fueron debidamente comprobadas por mí, dándolas por reproducidas en el presente instrumento, como si se insertasen a la letra." & Chr(13) & Chr(10) & Chr(13) & Chr(10) & _
                        "TERCERO : Que los comparecientes ratifican en este acto el contenido del Contrato de Crédito de Habilitación o Avío No. " & txtAnexo.Text & " " & _
                        "y de los Anexos adjuntos,  así como las firmas que lo calzan; y" & Chr(13) & Chr(10) & Chr(13) & Chr(10) & _
                        "CUARTO : Que leído que fue este instrumento a los comparecientes y explicado su valor y fuerza legal, determinaron firmarlo de conformidad con lo expresado, " & _
                        "en presencia y unión del suscrito NOTARIO el día " & cFechaFirma & ". DOY FE."
                    End If
                Else
                    If cSucursal = "03" Then
                        cLeyendaRegistrador = "En Ciudad Obregón, Sonora, siendo las ____ horas del día ___________________________________________, yo Lic. GENARO ROJAS CAÑEZ, " & _
                                                      "Registrador Especial de Crédito Agrícola del Distrito Judicial de CAJEME, con residencia en esta ciudad, en funciones de Notario Público " & _
                                                      "de acuerdo a lo dispuesto por los artículos 112 y 115 de la Ley de Crédito Agrícola, en vigor de conformidad con el contenido del artículo " & _
                                                      "séptimo transitorio de la Ley Agraria, hago constar que me fue presentado para su inscripción el Contrato de apertura de Crédito de " & _
                                                      "Habilitación o Avío No. " & txtAnexo.Text & " POR UN MONTO DE " & lblMontoCredito.Text & _
                                                      "que celebran por una parte FINAGIL, S.A. DE C.V. SOFOM, E.N.R., a través de su REPRESENTANTE LEGAL " & _
                                                      "en su carácter de apoderado legal a quien para los efectos de este contrato se le designará como FINAGIL y de la otra parte " & _
                                                      cDescr & " a quien en lo sucesivo se le designará como el PRODUCTOR ACREDITADO." & Chr(13) & Chr(10) & _
                                                      "Hago constar que comparecieron ante mí el apoderado legal de FINAGIL, S.A. DE C.V. SOFOM, E.N.R., " & _
                                                      "quien acredita su personalidad mediante testimonio de escritura pública No. 40770, Volumen MCLX (MIL CIENTO SESENTA), " & _
                                                      "de fecha (18) dieciocho de octubre de 2007 (DOS MIL SIETE), otorgada ante la fe del Lic. Jorge Valdés Ramírez, Notario Público No. 24, " & _
                                                      "de la Ciudad de Toluca, Estado de México, en el cual se contiene Poder General para Pleitos y Cobranzas y Actos de Administración, " & _
                                                      "el cual doy fe de tenerlo a la vista, misma persona quien en este acto se identifica con Credencial de Elector con fotografía " & _
                                                      "con número de folio 5188007775044, así como la otra parte " & cDescr & ", quien manifestó " & cGeneClie & " con domicilio en " & _
                                                      cCalle & " y quien se identificó con Credencial de Elector con fotografía con número de folio ______________________." & Chr(13) & Chr(10) & _
                                                      "Y los TESTIGOS quienes manifiestan:" & Chr(13) & Chr(10) & _
                                                      "Llamarse ROSARIO LEON ARMENTA, de profesión Ingeniero Agrónomo Fitotecnista, originario de Pueblo Yaqui, " & _
                                                      "Sonora lugar donde nació el 2 de febrero de 1966, con R.F.C. LEAR660202L82, de estado civil casado y quien en este acto se identifica " & _
                                                      "con Credencial de Elector con fotografía con número de folio ______________." & Chr(13) & Chr(10) & _
                                                      "Llamarse ADOLFO PACHECO MENDEZ, de profesión Ingeniero Agrónomo Irrigador, originario de Cd. Obregón, Sonora lugar donde nació " & _
                                                      "el 1º. de marzo de 1964, con R.F.C. PAMA6403012V1, de estado civil casado y quien en este acto se identifica " & _
                                                      "con Credencial de Elector con fotografía con número de folio ______________." & Chr(13) & Chr(10) & _
                                                      "Y que cumplidos los requisitos de Ley procedo a inscribir el presente documento en los libros del Registro a mi cargo, habiéndose inscrito " & _
                                                      "bajo el NÚMERO _________, LIBRO _______, VOLUMEN _______, de este Oficio." & Chr(13) & Chr(10) & Chr(13) & Chr(10) & _
                                                      "------------------------------------------------------------------PERSONALIDAD-----------------------------------------------------------------" & Chr(13) & Chr(10) & _
                                                      "EL SEÑOR CONTADOR PUBLICO JOSE ANTONIO PADILLA AGUILAR PARA ACREDITAR SU CARÁCTER DE APODERADO DE FINAGIL, S.A. DE C.V. SOFOM, E.N.R., SUS FACULTADES, " & _
                                                      "ASI COMO LA EXISTENCIA LEGAL, DE LA CITADA FINANCIERA, ME EXHIBE EL SIGUIENTE DOCUMENTO: ESCRITURA PUBLICA NUMERO No. 40770, " & _
                                                      "VOLUMEN MCLX (MIL CIENTO SESENTA), DE FECHA (18) DIECIOCHO DE OCTUBRE DE (2007) DOS MIL SIETE, OTORGADA ANTE LA FE DEL LIC. JORGE VALDÉS RAMÍREZ, " & _
                                                      "NOTARIO PUBLICO No. 24, DE LA CIUDAD DE TOLUCA, ESTADO DE MÉXICO, E INSCRITO ANTE EL REGISTRO PÚBLICO DE LA PROPIEDAD DE ESA CIUDAD CON FECHA (26) " & _
                                                      "VEINTISÉIS DE OCTUBRE DEL AÑO (2007) DOS MIL SIETE BAJO FOLIO MERCANTIL ELECTRÓNICO NÚMERO (3829*17) TRES MIL OCHOCIENTOS VEINTINUEVE * DIECISIETE " & _
                                                      "Y CONTROL INTERNO (5) CINCO, ASÍ COMO PARTIDA NÚMERO (212) DOSCIENTOS DOCE DEL VOLUMEN (53) CINCUENTA Y TRES, LIBRO (I) PRIMERO Y SECCION " & _
                                                      "REGISTRO COMERCIO; MISMO QUE EN LA PARTE CONDUCENTE TRANSCRIBO: NUMERO CUARENTA MIL SETECIENTOS SETENTA… VOLUMEN MCLX…EN LA CIUDAD DE TOLUCA, " & _
                                                      "ESTADO DE MEXICO, A LOS DIECIOCHO DÍAS DEL MES DE DE OCTUBRE DE DOS MIL SIETE, ANTE MÍ, EL LICENCIADO JORGE VALDES RAMIREZ." & _
                                                      "QUE CON FUNDAMENTO EN LO DISPUESTO POR LOS ARTICULOS 112 Y 115 DE LA LEY DE CREDITO AGRICOLA EN VIGOR EL SUSCRITO REGISTRADOR " & _
                                                      "EN FUNCIONES DE NOTARIO PUBLICO ELEVA A ESCRITURA PUBLICA EL PRESENTE DOCUMENTO, PARA SURTIR SUS EFECTOS COMO PRIMER TESTIMONIO " & _
                                                      "DE ESCRITURA EN LOS TERMINOS DE LAS DISPOSICIONES ANTES MENCIONADAS, LO QUE AUTORIZO Y FIRMO, DOY FE."


                        cFirmaRegistrador = "C. REGISTRADOR ESPECIAL DE CRÉDITO AGRÍCOLA" & Chr(13) & Chr(10) & "EN FUNCIONES DE NOTARIO PÚBLICO" & Chr(13) & Chr(10) & Chr(13) & Chr(10) & Chr(13) & Chr(10) & "_________________________________" & Chr(10) & "LIC. GENARO ROJAS CAÑEZ"
                    ElseIf cSucursal = "04" Then
                        cLeyendaRegistrador = "EN LA CIUDAD DE MEXICALI, BAJA CALIFORNIA, A LOS ___ DÍAS DEL MES DE ________ DEL ____, ANTE EL SUSCRITO LICENCIADO FRANCISCO JAVIER BRISEÑO ARCE, " & _
                        "REGISTRADOR ESPECIAL DEL REGISTRO DE CRÉDITO AGRÍCOLA, ACTUALMENTE REGISTRO PUBLICO DE CRÉDITO RURAL, ATENTO A LO PREVISTO POR LOS ARTÍCULOS 99, 101, 108, 112  Y RELATIVOS " & _
                        "DE LA LEY DE CRÉDITO AGRÍCOLA EN RELACIÓN AL SÉPTIMO TRANSITORIO DE LA LEY AGRARIA, HAGO CONSTAR QUE COMPARECIERON ANTE MI LOS SEÑORES CONTADOR PUBLICO JOSE ANTONIO PADILLA AGUILAR, EN SU " & _
                        "CALIDAD DE APODERADO LEGAL DE FINAGIL, S.A. DE C.V. SOFOM E.N.R, QUIEN ACREDITA SU PERSONALIDAD MEDIANTE TESTIMONIO DE ESCRITURA PUBLICA NUMERO No. 40770, VOLUMEN MCLX, " & _
                        "DE FECHA 18 DE OCTUBRE DE 2007, OTORGADA ANTE LA FE DEL LIC. JORGE VALDES RAMIREZ, NOTARIO PUBLICO NUMERO 24, DE LA CIUDAD DE TOLUCA, ESTADO DE MEXICO, EN EL CUAL SE " & _
                        "CONTIENE PODER GENERAL PARA PLEITOS Y COBRANZAS Y ACTOS DE ADMINISTRACIÓN, EL CUAL DOY FE DE TENERLO A LA VISTA, MISMA PERSONA QUIEN EN ESTE ACTO SE IDENTIFICA CON CREDENCIAL " & _
                        "FEDERAL CON FOTOGRAFÍA CON FOLIO NUMERO 5188007775044 Y POR OTRA PARTE " & cDescr & cRepresentante & " EN LO SECESIVO EL 'ACREDITADO' Y COMO AVAL(ES) " & cAvales & ", EN LO SUCESIVO " & _
                        "EL(LOS) 'AVAL(ES)', LOS COMPARECIENTES MANIFIESTAN QUE SIN PRESIÓN NI COACCIÓN ALGUNA, RATIFICAN EN TODAS SUS PARTES EL CONTENIDO DEL CONTRATO DE CRÉDITO DE HABILITACIÓN O AVÍO NUMERO " & _
                        txtAnexo.Text & ", POR LA CANTIDAD DE $ " & lblMontoCredito.Text & "Y SABIENDO DE LAS CONSECUENCIAS LEGALES QUE SE DESPRENDEN DEL MISMO PARA TODOS Y CADA UNOS DE LOS EFECTOS LEGALES " & _
                        "A QUE HAYA LUGAR, FIRMANDO AL CALCE PARA CONSTANCIA DE LA PRESENTE, ASÍ COMO AL MARGEN DEL MENCIONADO CONTRATO. "

                        cFirmaRegistrador = Chr(10) & "POR EL ACREDITANTE" & Chr(10) & Chr(10) & "_______________________________" & Chr(13) & _
                        "FINAGIL, S.A. DE C.V. SOFOM E.N.R." & Chr(13) & "C.P. JOSE ANTONIO PADILLA AGUILAR" & Chr(13) & "APODERADO(LEGAL)" & Chr(10) & Chr(10) & Chr(10) & "POR EL ACREDITADO" & Chr(10) & Chr(10) & Chr(10) & _
                        "_______________________________" & Chr(13) & cDescr & Chr(10) & Chr(10) & Chr(10) & "EL NOTARIO Y REGISTRADOR PUBLICO" & Chr(13) & "DE CRÉDITO AGRÍCOLA" & Chr(10) & Chr(10) & _
                        "____________________________________" & Chr(13) & "LIC. FRANCISCO JAVIER BRISEÑO ARCE"
                    End If

                End If

            End If
            If cSucursal = "06" Then
                cLeyendaRegistrador = "Yo  Licenciado JUAN FERNANDO AGUIRRE VALDES, Notario Público Número Veinticuatro del Distrito de Saltillo y del Patrimonio Inmueble Federal con residencia en Irlanda 244 Col. Villa Olímpica en Saltillo Coahuila C E R T I F I C O: Que " & _
                "a solicitud del Contador Público JOSE ANTONIO PADILLA AGUILAR, en su carácter de Apoderado de la empresa denominada 'FINAGIL', SOCIEDAD ANONIMA DE CAPITAL VARIABLE, SOCIEDAD FINANCIERA " & _
                " DE OBJETO MULTIPLE ENTIDAD NO REGULADA, acreditando la legal existencia de su representada así como las facultades con las que comparece en el CONTRATO DE CREDITO DE HABILITACION O AVIO NUMERO " & _
                Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 6, 4)) & ", realizado con la sociedad denominada " & Trim(cDescr) & cRepresentante & " en lo sucesivo denominado el 'ACREDITADO', y los señores " & cAvales & _
                ", en su carácter de 'AVALES', sociedad denominada MOLINOS DEL FENIX SOCIEDAD ANONIMA DE CAPITAL VARIABLE, representada por el ingeniero LUIS MIGUEL MONROY CARRILLO, en lo sucesivo denominado el 'COMPRADOR,'" & _
                " señores MARIO RUIZ URBINA y FRANCISCO JAVIER MARTINEZ GARCIA  en su carácter de 'TESTIGOS'; personalidad que acredita con la escritura pública número 40770 cuarenta mil setecientos setenta, del Volumen " & _
                "MCLX mil ciento sesenta, con fecha dieciocho de octubre de dos mil siete, otorgada en esta propia notaria, e inscrita en el Registro Público de la Propiedad y del Comercio, bajo la partida número 212, Volumen " & _
                "53, Libro Primero, Sección Comercio de fecha veintinueve de octubre de dos mil siete, en Toluca, Estado de México; quienes por no ser de mi personal conocimiento se identifican en términos de ley, se reconocen " & _
                "mutuamente suficiente capacidad para contratar y obligarse en términos del presente contrato y del que se desprende que las firmas que lo calzan son las que utilizan en todos los negocios en que intervienen y al " & _
                "que me remito y a solicitud de los mismos lo RATIFICAN, levantando para constancia el Instrumento 44303, del Volumen MCCXXIII, en el cual consta la Ratificación de Firmas y Contenido. DOY FE.--------------------- " & _
                " Y A SOLICITUD DE LOS INTERESADOS, EXPIDO LA PRESENTE CERTIFICACION, EN LA CIUDAD DE TOLUCA, ESTADO DE MEXICO, A LOS QUINCE DIAS DEL MES DE DICIEMBRE DEL DOS MIL NUEVE.- DOY FE. ---------------------------- "
            End If

        Else

            ' Se trata de un Crédito en Cuenta Corriente para el cual no aplica este formato

            btnImprimir.Enabled = False
            btnImpPagare.Enabled = False

        End If

        cm1.Dispose()
        cm2.Dispose()
        cm3.Dispose()

    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm2 As New SqlCommand()
        Dim strUpdate As String
        Dim cFTermino As String

        cFTermino = Mes(cFechaTermino).ToLower
        'cFTermino = cFTermino & Mes(cVenAño2).ToLower & " Y EL " & Mes(cVenAño3).ToLower & " PREVIA AUTORIZACION DE FINAGIL."
        
        cFechaFirma = Mes(DTOC(DateTimePicker1.Value)).ToLower

        If ckbTrigo.Checked = False And ckbMaiz.Checked = False And ckbSorgo.Checked = False And ckbCartamo.Checked = False And ckbAlgodon.Checked = False Then
            MsgBox("Selecciona el Tipo de Semilla para el Contrato", MsgBoxStyle.Critical, "Mensaje")
        Else
            Dim oNulo As Object = System.Reflection.Missing.Value
            Dim oRuta As New Object
            Dim myMField As Microsoft.Office.Interop.Word.Field
            Dim rFieldCode As Microsoft.Office.Interop.Word.Range
            Dim cFieldText As String
            Dim finMerge As Integer
            Dim fieldNameLen As Integer
            Dim cfName As String
            Dim cTipoSemilla As String = ""
            Dim cVarSemilla As String = ""
            Dim cEnajenado As String = ""
            Dim cDatoFega As String = "0.84 %"
            Dim cDescSemilla As String = ""

            If ckbTrigo.Checked = True Then
                cSemilla = "T"
                cTipoSemilla = "Trigo"
            ElseIf ckbMaiz.Checked = True Then
                cSemilla = "M"
                cTipoSemilla = "Maiz"
            ElseIf ckbSorgo.Checked = True Then
                cSemilla = "S"
                cTipoSemilla = "Sorgo"
            ElseIf ckbAlgodon.Checked = True Then
                cSemilla = "A"
                cTipoSemilla = "Algodón"
            ElseIf ckbGarbanzo.Checked = True Then
                cSemilla = "G"
                cTipoSemilla = "Garbanzo"
            ElseIf ckbCartamo.Checked = True Then
                cSemilla = "C"
                cTipoSemilla = "Cártamo"
                cOtros = "S 518" & Chr(13) & "S 555" & Chr(13) & "ETC."
            End If
            cDescSemilla = ":"
            cVarSemilla = "señalada en el Contrato de Compraventa de " & cTipoSemilla
            cEnajenado = "FINAGIL"

            If cParafin = "S" Then
                cComision = txtPorcomi.Text & " % por comisión + IVA por cada Disposición"
            End If

            If cSemilla = "C" Then
                cVarSemilla = "seleccionada por el productor "
                cEnajenado = "SERVICIOS ARFIN, S.A. DE C.V."
                cDescSemilla = " CUALQUIER VARIEDAD AUTORIZADA POR EL INIFAP, TALES COMO:"
            End If

            strUpdate = "UPDATE Avios SET Semilla = '" & cSemilla & "'"
            strUpdate = strUpdate & ", FechaContrato = '" & DTOC(DateTimePicker1.Value) & "'"
            strUpdate = strUpdate & ", FechaLimiteDTC = '" & DTOC(DateTimePicker2.Value) & "'"
            strUpdate = strUpdate & ", Porcomi = '" & Val(txtPorcomi.Text) & "'"
            strUpdate = strUpdate & ", GaranteHip = '" & txtGHipotecario.Text & "'"
            strUpdate = strUpdate & ", GarantePre = '" & txtGPrendario.Text & "'"
            strUpdate = strUpdate & " WHERE Anexo = '" & cAnexo & "'"

            cm2 = New SqlCommand(strUpdate, cnAgil)
            cnAgil.Open()
            cm2.ExecuteNonQuery()
            cnAgil.Close()
            cnAgil.Dispose()

            If cSemilla <> "A" Then
                oRuta = "F:ContratoAVIO.doc"
            Else
                oRuta = "F:\ContratoAVIO_Algodon.doc"
            End If
          
            oWord = New Microsoft.Office.Interop.Word.Application()

            oWordDoc = New Microsoft.Office.Interop.Word.Document()

            ' Cargo la plantilla

            oWordDoc = oWord.Documents.Add(oRuta, oNulo, oNulo, oNulo)
            With oWordDoc.Sections(1)
                .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddPicture("F:\LOGO.JPG")
                .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InsertAfter(Chr(13) & "No. RECA 0073-136-003415/03-13607-0911  Contrato No. " & Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 6, 4))
            End With

            '        .Headers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.InlineShapes.AddHorizontalLineStandard()

            ' Abro el Contrato


            For Each myMField In oWordDoc.Fields

                rFieldCode = myMField.Code

                cFieldText = rFieldCode.Text

                ' Como los Campos de Word Comienzan por el nombre MERGEFIELD, solo tratamos estos campos

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
                            myMField.Result.Text = Trim(Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 6, 4))
                        Case "mEncabezado"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cEncabezado
                        Case "mEncabezado2"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cEncabezado2
                        Case "mDescr"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = Trim(cDescr) & Chr(10) & " DECLARA EL ACREDITADO QUE " & cGeneClie & ", CON CURP: " & cCURP
                        Case "mDescr2"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = Trim(cDescr)
                        Case "mRepresentante"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cRepresentante
                        Case "mParrafoRepres"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cRepresentante & cParrafoRepres
                        Case "mRfc"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = Trim(cRfc)
                        Case "mCalle"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = Trim(cCalle)
                        Case "mColonia"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = Trim(cColonia)
                        Case "mCopos"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = Trim(cCopos)
                        Case "mDelegacion"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = Trim(cDelegacion)
                        Case "mEstado"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = Trim(cEstado)
                        Case "mInmuebles"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cInmuebles.ToUpper
                        Case "mMuebles"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cMuebles.ToUpper
                        Case "mUsufructo"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cUsufructo.ToUpper
                        Case "mGeneClie"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cGeneClie.ToUpper
                        Case "mImporte"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cImporte.ToUpper
                        Case "mImporteLetra"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cCantidad.ToUpper
                        Case "mPlazoCred"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = "ANUAL, CON FECHA DE VENCIMIENTO EL " & cFTermino
                        Case "mDiferencialFINAGIL"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cDiferencialFINAGIL
                        Case "mAval1"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cAval1.ToUpper
                        Case "mHectareas"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cHectareas
                        Case "mToneladas"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cToneladas
                        Case "mRendimiento"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cRendimiento
                        Case "mPredios"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cPredios
                        Case "mParrafoHipoteca"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cParrafoHipoteca
                        Case "mParrafoPrenda"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cParrafoPrenda
                        Case "mGravamen"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cGravamen
                        Case "mFechaLimiteDTC"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            If cFLimite2 = "" And cFLimite3 = "" Then
                                myMField.Result.Text = Mes(DTOC(DateTimePicker2.Value)).ToLower
                            ElseIf cFLimite2 <> "" And cFLimite3 = "" Then
                                myMField.Result.Text = Mes(DTOC(DateTimePicker2.Value)).ToLower & ", " & Mes(cFLimite2).ToLower
                            ElseIf cFLimite2 <> "" And cFLimite3 <> "" Then
                                myMField.Result.Text = Mes(DTOC(DateTimePicker2.Value)).ToLower & ", " & Mes(cFLimite2).ToLower & ", " & Mes(cFLimite3).ToLower
                            End If
                        Case "mFechaFirma"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cFechaFirma
                        Case "mFirmaAval1"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cFirmaAval1
                        Case "mFirmaAval2"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cFirmaAval2
                        Case "mFirmaAval3"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cFirmaAval3
                        Case "mFirmaAval4"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cFirmaAval4
                        Case "mLeyendaNotario"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cLeyendaNotario
                        Case "mLeyendaRegistrador"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cLeyendaRegistrador
                        Case "mFirmaRegistrador"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cFirmaRegistrador
                        Case "mTipoSemilla"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cTipoSemilla
                        Case "mVarSemillas"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cVarSemilla
                        Case "mDescSemilla"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cDescSemilla
                        Case "mEnajenado"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cEnajenado
                        Case "mFechaSiembra"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cFechaSiembra
                        Case "mFechaCosecha"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cFechaCosecha
                        Case "mDatosAv"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cDatosAval
                        Case "mEmpcv"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cEmpcv
                        Case "mC_Venta"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cC_Venta
                        Case "mC_Venta2"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cC_Venta2
                        Case "mCtoC_Venta"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cCtoC_Venta
                        Case "mPirineos"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cPirineos
                        Case "mLugar"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cLugar
                        Case "mTestigos"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = Chr(13) & cTestigos
                        Case "mFirmaTestigo1"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cFirmaTestigo1
                        Case "mFirmaTestigo2"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cFirmaTestigo2
                        Case "mFirmaFINAGIL"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cFirmaFINAGIL
                        Case "mAvales"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cAvales & Chr(10) & cDatosAval
                        Case "mUnidadEsp"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cUnidadEsp
                        Case "mFirman"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            If Trim(cFirman) <> "" Then
                                myMField.Result.Text = Chr(13) & "PERSONAS QUE FIRMAN EN REPRESENTACION DE LA EMPRESA: " & cFirman & " " & cParrafoRepres
                            Else
                                myMField.Result.Text = ""
                            End If
                        Case "mGarantias"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cGarantias
                        Case "mAgroquimi"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cAgroquimi
                        Case "mAgroquimi2"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cAgroquimi2
                        Case "mOtros"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cOtros
                        Case "mAportInv"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = "$ " & FormatNumber(nAportInv).ToString
                        Case "mAportInvLetra"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = Letras(nAportInv)
                        Case "mMontoInv"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = "$ " & FormatNumber(nMontoInv).ToString
                        Case "mMtoInvLetra"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = Letras(nMontoInv)
                        Case "mHcAct"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = nHectareas
                        Case "mFechaTer"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = Mes(cFechaTermino).ToLower
                        Case "mNum"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cNum
                        Case "mNum1"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cNum1
                        Case "mNum2"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cNum2
                        Case "mDatoFega"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cDatoFega
                        Case "mTrianual"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cTrianual
                        Case "mPrimera"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cPrimera
                        Case "mSegunda"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cSegunda
                        Case "mCAT"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = nCAT.ToString & "%"
                        Case "mDesCiclo"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cDescCiclo
                        Case "mComision"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = cComision
                        Case "mDescFrec"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = Mes(cFechaTermino).ToLower
                        Case "mGHip"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = Trim(txtGHipotecario.Text)
                        Case "mGPre"
                            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                            myMField.Result.Text = Trim(txtGPrendario.Text)
                    End Select

                    oWord.Selection.Fields.Update()

                End If

            Next

            'Guardo el documento

            oWord.ActiveDocument.Select()

            oWord.ActiveDocument.SaveAs("C:\Contratos\" & Trim(cDescr) & ".DOC")

            oWord.ActiveDocument.Close()

            OpenFile("C:\Contratos\" & Trim(cDescr) & ".DOC")

        End If

    End Sub

    Public Sub OpenFile(ByVal Path As String)

        Try

            Dim InfoProceso As New System.Diagnostics.ProcessStartInfo

            Dim Proceso As New System.Diagnostics.Process

            With InfoProceso

                .FileName = Path

                .CreateNoWindow = True

                .ErrorDialog = True

                .UseShellExecute = True

                .WindowStyle = ProcessWindowStyle.Normal

            End With

            Proceso.StartInfo = InfoProceso

            Proceso.Start()

            Proceso.Dispose()

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error al abrir el documento")

        End Try

        Me.Close()

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub ckbMaiz_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbMaiz.Click
        ckbTrigo.Checked = False
        ckbSorgo.Checked = False
        ckbCartamo.Checked = False
        ckbAlgodon.Checked = False
        ckbGarbanzo.Checked = False
    End Sub

    Private Sub ckbSorgo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbSorgo.Click
        ckbMaiz.Checked = False
        ckbTrigo.Checked = False
        ckbCartamo.Checked = False
        ckbAlgodon.Checked = False
        ckbGarbanzo.Checked = False
    End Sub

    Private Sub ckbTrigo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbTrigo.Click
        ckbMaiz.Checked = False
        ckbSorgo.Checked = False
        ckbCartamo.Checked = False
        ckbAlgodon.Checked = False
        ckbGarbanzo.Checked = False
    End Sub

    Private Sub btnImpPagare_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnImpPagare.Click
        Dim oNulo As Object = System.Reflection.Missing.Value
        Dim oRuta As New Object
        Dim myMField As Microsoft.Office.Interop.Word.Field
        Dim rFieldCode As Microsoft.Office.Interop.Word.Range
        Dim cFieldText As String
        Dim finMerge As Integer
        Dim fieldNameLen As Integer
        Dim cfName As String

        Dim nImpPag2 As Decimal
        Dim cEmpOrden As String
        Dim cDomEmpOrd As String

        nImpPag2 = txtImporte.Text * 0.1

        'oRuta = "C:\Contratos\Pagares.doc"
        oRuta = "F:Pagares.doc"

        oWord = New Microsoft.Office.Interop.Word.Application()

        oWordDoc = New Microsoft.Office.Interop.Word.Document()

        ' Cargo la plantilla

        oWordDoc = oWord.Documents.Add(oRuta, oNulo, oNulo, oNulo)

        If cSucursal = "03" Then
            cEmpOrden = "TABLEX MILLER S. DE R.L. DE C.V."
            cDomEmpOrd = "Carr. Fed. Los Mochis Cd. Obregon Km. 173-175 S/N. Colonia Centro C.P. 85800, Navojoa Sonora"
        ElseIf cSucursal = "04" Then
            cEmpOrden = "MOLINOS DEL SUDESTE S.A. DE C.V."
            cDomEmpOrd = "Av. Industrial Puebla # 562, Colonia Parque Insdustrial Puebla C.P. 21620, Mexicali Baja California"
        ElseIf cSucursal = "05" Then
            cEmpOrden = "HARINERA LOS PIRINEOS S.A. DE C.V."
            cDomEmpOrd = "Blvd. Paseo Solidaridad # 10781, Colonia Esfuerzo Obrero C.P. 36580, Irapuato Guanajuato"
        End If

        For Each myMField In oWordDoc.Fields

            rFieldCode = myMField.Code

            cFieldText = rFieldCode.Text

            ' Como los Campos de Word Comienzan por el nombre MERGEFIELD, solo tratamos estos campos

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
                        myMField.Result.Text = Trim(cDescr)
                    Case "mRepresentante"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Trim(cRepresentante)
                    Case "mCalle"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Trim(cCalle)
                    Case "mColonia"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Trim(cColonia)
                    Case "mCopos"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Trim(cCopos)
                    Case "mDelegacion"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Trim(cDelegacion)
                    Case "mEstado"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Trim(cEstado)
                    Case "mEmpOrden"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cEmpOrden
                    Case "mDomEmpOrd"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cDomEmpOrd
                    Case "mImporte"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = FormatNumber(txtImporte.Text, 2)
                    Case "mImporte2"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = FormatNumber(nImpPag2, 2)
                    Case "mImporteLetra"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Letras(txtImporte.Text)
                    Case "mImporteLetra2"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Letras(Round(nImpPag2, 2))
                    Case "mDiferencialFINAGIL"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cDiferencialFINAGIL
                    Case "mFechaFirma"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Mes(DTOC(dtpFFirma.Value))
                    Case "mFechaPago"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = Mes(DTOC(dtpFPago.Value))
                    Case "mFirmaAval1"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cFirmaAval1
                    Case "mFirmaAval2"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cFirmaAval2
                    Case "mFirmaAval3"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cFirmaAval3
                    Case "mFirmaAval4"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cFirmaAval4
                    Case "mLugar"
                        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToField, Name:=cfName)
                        myMField.Result.Text = cLugar
                End Select

                oWord.Selection.Fields.Update()

            End If

        Next

        'Guardo el documento

        oWord.ActiveDocument.Select()

        oWord.ActiveDocument.SaveAs("C:\Contratos\" & "Pagaré de " & Trim(cDescr) & ".DOC")

        oWord.ActiveDocument.Close()

        OpenFile("C:\Contratos\" & "Pagaré de " & Trim(cDescr) & ".DOC")

    End Sub

    Private Sub ckbCartamo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbCartamo.CheckedChanged
        ckbMaiz.Checked = False
        ckbSorgo.Checked = False
        ckbTrigo.Checked = False
        ckbAlgodon.Checked = False
        ckbGarbanzo.Checked = False
    End Sub

    Private Sub ckbAlgodon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbAlgodon.CheckedChanged
        ckbMaiz.Checked = False
        ckbSorgo.Checked = False
        ckbCartamo.Checked = False
        ckbTrigo.Checked = False
        ckbGarbanzo.Checked = False
    End Sub

    Private Sub ckbGarbanzo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbGarbanzo.CheckedChanged
        ckbMaiz.Checked = False
        ckbSorgo.Checked = False
        ckbCartamo.Checked = False
        ckbAlgodon.Checked = False
        ckbTrigo.Checked = False
    End Sub
End Class
