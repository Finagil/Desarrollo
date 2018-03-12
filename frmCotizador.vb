Option Explicit On

Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Math

Public Class frmCotizador

    ' Declaración de variables de conexión ADO .NET de alcance privado

    Dim dtCotiza As New DataTable("Datos")
    Dim dtTabla As New DataTable("TabEquipo")

    ' Declaración de variables de datos de alcance privado

    Dim cCritas As String = "01"                        ' La vigente
    Dim cForca As String = "1"                          ' Pagos Nivelados
    Dim cTippe As String = "01"                         ' Frecuencia Mensual
    Dim cTipta As String = "7"                          ' Tasa Fija
    Dim cFechacon As String
    Dim cFondeo As String = "01"
    Dim cTipar As String = "F"
    Dim cTipo As String = ""
    Dim lFijarPagoInicial As Boolean = False
    Dim nAmorin As Decimal = 0
    Dim nAmorinConIva As Decimal = 0
    Dim nComision As Decimal = 23000.0
    Dim nDerechos As Decimal = 0
    Dim nDG As Decimal = 0
    Dim nDifer As Decimal = 0
    Dim nEnganche As Decimal = 0
    Dim nGastos As Decimal = 2000
    Dim nImpDG As Decimal = 0
    Dim nImpEq As Decimal = 1150000.0
    Dim nImpRD As Decimal = 0
    Dim nIvaAmorin As Decimal = 0
    Dim nIvaDG As Decimal = 0
    Dim nIvaEq As Decimal = 150000.0
    Dim nIvaRD As Decimal = 0
    Dim nIvaRtasDep As Decimal = 0
    Dim nMensu As Decimal = 35528.43
    Dim nMontoFinanciado As Decimal = 1000000
    Dim nNafin As Decimal = 0
    Dim nOpcion As Decimal = 11500.0
    Dim nPagosIniciales As Decimal = 0
    Dim nPlazo As Decimal = 36
    Dim nPorCo As Decimal = 2.0
    Dim nPorieq As Decimal = 16
    Dim nPorOp As Decimal = 1.0
    Dim nRD As Decimal = 0
    Dim nSubtotal As Decimal = 1000000
    Dim nTasas As Decimal = 16.75
    Dim nPeriodo As Integer
    Dim cm7 As New SqlCommand()
    Dim drPeriodo As DataRow
    Dim cFechaInip As String
    Dim cFechaFinp As String
    Dim cFechaInip1 As String
    Dim cFechaFinp1 As String

    Private Sub frmCotizador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim cm4 As New SqlCommand()
        Dim cm5 As New SqlCommand()
        Dim cm6 As New SqlCommand()
        
        Dim dsAgil As New DataSet()
        Dim daTasasAplicables As New SqlDataAdapter(cm1)
        Dim daFrecuencias As New SqlDataAdapter(cm2)
        Dim daTasas As New SqlDataAdapter(cm3)
        Dim daEsquemas As New SqlDataAdapter(cm4)
        Dim daRecursos As New SqlDataAdapter(cm5)
        Dim daCriterios As New SqlDataAdapter(cm6)
        Dim daPeriodos As New SqlDataAdapter(cm7)

        ' Declaración de variables de datos

        Dim i As Byte
   
        ' Con este Stored Procedure obtengo la información del periodo vigente

        With cm7
            .CommandType = CommandType.Text
            .CommandText = "SELECT Periodo, FechaInip, FechaFinp, Vigente FROM PeriodoTasas Order by Periodo"
            .Connection = cnAgil
        End With

        daPeriodos.Fill(dsAgil, "Periodos")

        For Each drPeriodo In dsAgil.Tables("Periodos").Rows
            If drPeriodo("Vigente") = "S" Then
                cFechaInip = drPeriodo("FechaInip")
                cFechaFinp = drPeriodo("FechaFinp")
            ElseIf drPeriodo("Vigente") = "N" Then
                cFechaInip1 = drPeriodo("FechaInip")
                cFechaFinp1 = drPeriodo("FechaFinp")
            End If
            nPeriodo = drPeriodo("Periodo")
        Next

        ' El siguiente Stored Procedure trae todas las tasas aplicables para el tipo de crédito especificado

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "TasasAplicables1"
            .Connection = cnAgil
            .Parameters.Add("@TipoCredito", SqlDbType.NVarChar)
            .Parameters(0).Value = "AFsinIVA"
            .Parameters.Add("@Periodo", SqlDbType.NVarChar)
            .Parameters(1).Value = nPeriodo
        End With

        ' Llenar el DataSet lo cual abre y cierra la conexión

        daTasasAplicables.Fill(dsAgil, "AFsinIVA")

        ' Ahora defino el segundo tipo de crédito

        cm1.Parameters(0).Value = "AFconIVA"
        daTasasAplicables.Fill(dsAgil, "AFconIVA")

        ' Ahora defino el tercer tipo de crédito

        cm1.Parameters(0).Value = "CR"
        daTasasAplicables.Fill(dsAgil, "CR")

        ' Ahora defino el cuarto tipo de crédito

        cm1.Parameters(0).Value = "AP"
        daTasasAplicables.Fill(dsAgil, "AP")

        ' Ahora defino el quinto tipo de crédito

        cm1.Parameters(0).Value = "TVAFsinIVA"
        daTasasAplicables.Fill(dsAgil, "TVAFsinIVA")

        ' Ahora defino el sexto tipo de crédito

        cm1.Parameters(0).Value = "TVAFconIVA"
        daTasasAplicables.Fill(dsAgil, "TVAFconIVA")

        ' Ahora defino el séptimo tipo de crédito

        cm1.Parameters(0).Value = "TVCR"
        daTasasAplicables.Fill(dsAgil, "TVCR")

        ' Ahora defino el octavo tipo de crédito

        cm1.Parameters(0).Value = "TVAP"
        daTasasAplicables.Fill(dsAgil, "TVAP")

        ' Asigno cada tabla a su correspondiente DataGridView

        dgvAFsinIVA.DataSource = dsAgil.Tables("AFsinIVA")
        dgvAFconIVA.DataSource = dsAgil.Tables("AFconIVA")
        dgvCR.DataSource = dsAgil.Tables("CR")
        dgvAP.DataSource = dsAgil.Tables("AP")
        dgvTVAFsinIVA.DataSource = dsAgil.Tables("TVAFsinIVA")
        dgvTVAFconIVA.DataSource = dsAgil.Tables("TVAFconIVA")
        dgvTVCR.DataSource = dsAgil.Tables("TVCR")
        dgvTVAP.DataSource = dsAgil.Tables("TVAP")

        For i = 0 To dgvAFsinIVA.Columns.Count - 1
            If i <= 2 Then
                dgvAFsinIVA.Columns(i).Width = 90
            Else
                dgvAFsinIVA.Columns(i).Width = 65
            End If
            dgvAFsinIVA.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            dgvAFsinIVA.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight ' Alinea el encabezado
            dgvAFsinIVA.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alinea el contenido
        Next

        For i = 0 To dgvAFconIVA.Columns.Count - 1
            If i <= 2 Then
                dgvAFconIVA.Columns(i).Width = 90
            Else
                dgvAFconIVA.Columns(i).Width = 65
            End If
            dgvAFconIVA.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            dgvAFconIVA.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight ' Alinea el encabezado
            dgvAFconIVA.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alinea el contenido
        Next

        For i = 0 To dgvCR.Columns.Count - 1
            If i <= 2 Then
                dgvCR.Columns(i).Width = 90
            Else
                dgvCR.Columns(i).Width = 65
            End If
            dgvCR.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            dgvCR.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight ' Alinea el encabezado
            dgvCR.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alinea el contenido
        Next

        For i = 0 To dgvAP.Columns.Count - 1
            If i <= 2 Then
                dgvAP.Columns(i).Width = 90
            Else
                dgvAP.Columns(i).Width = 65
            End If
            dgvAP.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            dgvAP.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight ' Alinea el encabezado
            dgvAP.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alinea el contenido
        Next

        ' TabPage Tasa Variable

        For i = 0 To dgvTVAFsinIVA.Columns.Count - 1
            If i < 2 Then
                dgvTVAFsinIVA.Columns(i).Width = 90
            ElseIf i = 2 Then
                dgvTVAFsinIVA.Columns(i).Width = 110
            Else
                dgvTVAFsinIVA.Columns(i).Width = 65
            End If
            dgvTVAFsinIVA.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            dgvTVAFsinIVA.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight ' Alinea el encabezado
            dgvTVAFsinIVA.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alinea el contenido
        Next

        For i = 0 To dgvTVAFconIVA.Columns.Count - 1
            If i < 2 Then
                dgvTVAFconIVA.Columns(i).Width = 90
            ElseIf i = 2 Then
                dgvTVAFconIVA.Columns(i).Width = 110
            Else
                dgvTVAFconIVA.Columns(i).Width = 65
            End If
            dgvTVAFconIVA.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            dgvTVAFconIVA.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight ' Alinea el encabezado
            dgvTVAFconIVA.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alinea el contenido
        Next

        For i = 0 To dgvTVCR.Columns.Count - 1
            If i < 2 Then
                dgvTVCR.Columns(i).Width = 90
            ElseIf i = 2 Then
                dgvTVCR.Columns(i).Width = 110
            Else
                dgvTVCR.Columns(i).Width = 65
            End If
            dgvTVCR.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            dgvTVCR.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight ' Alinea el encabezado
            dgvTVCR.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alinea el contenido
        Next

        For i = 0 To dgvTVAP.Columns.Count - 1
            If i < 2 Then
                dgvTVAP.Columns(i).Width = 90
            ElseIf i = 2 Then
                dgvTVAP.Columns(i).Width = 110
            Else
                dgvTVAP.Columns(i).Width = 65
            End If
            dgvTVAP.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            dgvTVAP.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight ' Alinea el encabezado
            dgvTVAP.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alinea el contenido
        Next

        ' El siguiente Stored Procedure trae todos los atributos de todas las Frecuencias

        With cm2
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Frecuencias1"
            .Connection = cnAgil
        End With

        ' El siguiente Stored Procedure trae todos los atributos de todas las Tasas VIGENTES

        With cm3
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Tasas2"
            .Connection = cnAgil
        End With

        ' El siguiente Stored Procedure trae todos los atributos de todos los Esquemas

        With cm4
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Esquemas2"
            .Connection = cnAgil
        End With

        ' El siguiente Stored Procedure trae todos los atributos de todos los Recursos

        With cm5
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Recursos2"
            .Connection = cnAgil
        End With

        ' El siguiente Stored Procedure trae todos los atributos de todos los Criterios

        With cm6
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Criterios1"
            .Connection = cnAgil
        End With

        ' Llenar el DataSet lo cual abre y cierra la conexión

        daFrecuencias.Fill(dsAgil, "Frecuencias")
        daTasas.Fill(dsAgil, "Tasas")
        daEsquemas.Fill(dsAgil, "Esquemas")
        daRecursos.Fill(dsAgil, "Recursos")
        daCriterios.Fill(dsAgil, "Criterios")

        ' Llenar el comboBox para mostrar los porcentajes de depósito FINAGIL (solo para crédito refaccionario)

        cbDG.Items.Add(" 0")
        cbDG.Items.Add(" 5")
        cbDG.Items.Add("10")
        cbDG.Items.Add("15")

        ' Llenar el comboBox para mostrar el número de rentas en depósito (solo arrendamiento financiero o puro)

        cbRD.Items.Add("0")
        cbRD.Items.Add("1")
        cbRD.Items.Add("2")
        cbRD.Items.Add("3")

        ' Llenar el comboBox para mostrar los productos.

        cbProducto.Items.Add("ARRENDAMIENTO FINANCIERO")
        cbProducto.Items.Add("ARRENDAMIENTO PURO")
        cbProducto.Items.Add("CREDITO REFACCIONARIO")
        cbProducto.Items.Add("CREDITO SIMPLE")
        cbProducto.Items.Add("CREDITO DE NOMINA")
        cbProducto.SelectedIndex = 0

        ' El IVA unicamente podra tener el valor de 0 ó 16 % ó bien 11 para la zona fronteriza 

        cbPorieq.Items.Add(" 0")
        cbPorieq.Items.Add("11")
        cbPorieq.Items.Add("16")
        cbPorieq.SelectedIndex = 2

        ' Establecer los valores que puede asumir la variable Plazo

        cbPlazo.Items.Add(" 6")
        cbPlazo.Items.Add("12")
        cbPlazo.Items.Add("24")
        cbPlazo.Items.Add("36")
        cbPlazo.Items.Add("48")
        cbPlazo.SelectedIndex = 3

        ' Ligar la tabla Frecuencias del dataset dsAgil al ComboBox Frecuencias

        cbFrecuencias.DataSource = dsAgil
        cbFrecuencias.DisplayMember = "Frecuencias.DescFrecuencia"
        cbFrecuencias.ValueMember = "Frecuencias.Frecuencia"
        cbFrecuencias.SelectedIndex = Val(cTippe) - 1

        ' Ligar la tabla Tasas del dataset dsAgil al ComboBox Tasas

        cbTasas.DataSource = dsAgil
        cbTasas.DisplayMember = "Tasas.DescTasa"
        cbTasas.ValueMember = "Tasas.Tasa"
        cbTasas.SelectedValue = Val(cTipta)

        ' Ligar la tabla Esquemas del dataset dsAgil al ComboBox Esquemas

        cbEsquemas.DataSource = dsAgil
        cbEsquemas.DisplayMember = "Esquemas.DescEsquema"
        cbEsquemas.ValueMember = "Esquemas.Esquema"
        cbEsquemas.SelectedValue = Val(cForca)

        ' Ligar la tabla Recursos del dataset dsAgil al ComboBox Recursos

        cbRecursos.DataSource = dsAgil
        cbRecursos.DisplayMember = "Recursos.DescRecurso"
        cbRecursos.ValueMember = "Recursos.Recurso"
        cbRecursos.SelectedValue = cFondeo

        ' Ligar la tabla Criterios del dataset dsAgil al ComboBox Criterios

        cbCriterios.DataSource = dsAgil
        cbCriterios.DisplayMember = "Criterios.DescCriterio"
        cbCriterios.ValueMember = "Criterios.Criterio"
        cbCriterios.SelectedIndex = Val(cCritas) - 1

        txtImpEq.Text = Format(nImpEq, "##,##0.00")
        txtAmorinConIva.Text = Format(nAmorinConIva, "##,##0.00")
        txtEnganche.Text = Format(nEnganche, "##,##0.00")
        txtGastos.Text = Format(nGastos, "##,##0.00")
        txtPorco.Text = Format(nPorCo, "##,##0.00")
        txtPorop.Text = Format(nPorOp, "##,##0.00")
        txtOpcion.Text = Format(nOpcion, "##,##0.00")
        txtMensu.Text = Format(nMensu, "##,##0.00")
        txtMontoFinanciado.Text = Format(nMontoFinanciado, "##,##0.00")

        txtTasas.Text = Format(nTasas, "##,##0.0000")
        txtDifer.Text = Format(nDifer, "##,##0.0000")

        txtSubtotal.Text = Format(nImpEq - nIvaEq, "##,##0.00")
        txtIvaEq.Text = Format(nIvaEq, "##,##0.00")

        ' Despliego los pagos iniciales

        txtPIAmorin.Text = Format(nAmorin, "##,##0.00")
        txtPIIvaAmorin.Text = Format(nIvaAmorin, "##,##0.00")
        txtPIEnganche.Text = Format(nEnganche, "##,##0.00")
        txtPIDerechos.Text = Format(nDerechos, "##,##0.00")
        txtComision.Text = Format(nComision, "##,##0.00")
        txtImpDG.Text = Format(nImpDG, "##,##0.00")
        txtIvaDG.Text = Format(nIvaDG, "##,##0.00")
        txtPIGastos.Text = Format(nGastos, "##,##0.00")
        txtNafin.Text = Format(nNafin, "##,##0.00")
        txtImpRD.Text = Format(nImpRD, "##,##0.00")
        txtIvaRD.Text = Format(nIvaRD, "##,##0.00")

        nPagosIniciales = Round(nAmorinConIva + nEnganche + nDerechos + nComision + nImpDG + nIvaDG + nGastos + nNafin + nImpRD + nIvaRD, 2)

        txtPagosIniciales.Text = Format(nPagosIniciales, "##,##0.00")

        ' Creo la tabla dtCotiza que almacenará los datos generales de la cotización para su impresión

        dtCotiza.Columns.Add("Letras", Type.GetType("System.String"))
        dtCotiza.Columns.Add("Valfac", Type.GetType("System.Decimal"))
        dtCotiza.Columns.Add("Ivafac", Type.GetType("System.Decimal"))
        dtCotiza.Columns.Add("Facsiniva", Type.GetType("System.Decimal"))
        dtCotiza.Columns.Add("Seguro", Type.GetType("System.Decimal"))
        dtCotiza.Columns.Add("Montofin", Type.GetType("System.Decimal"))
        dtCotiza.Columns.Add("Porcom", Type.GetType("System.Decimal"))
        dtCotiza.Columns.Add("Tasa", Type.GetType("System.Decimal"))
        dtCotiza.Columns.Add("Opcomp", Type.GetType("System.Decimal"))
        dtCotiza.Columns.Add("Comision", Type.GetType("System.Decimal"))
        dtCotiza.Columns.Add("Gastos", Type.GetType("System.Decimal"))
        dtCotiza.Columns.Add("Amortizacion", Type.GetType("System.Decimal"))
        dtCotiza.Columns.Add("Enganche", Type.GetType("System.Decimal"))
        dtCotiza.Columns.Add("Derechos", Type.GetType("System.Decimal"))
        dtCotiza.Columns.Add("Depgar", Type.GetType("System.Decimal"))
        dtCotiza.Columns.Add("Rentad", Type.GetType("System.Decimal"))
        dtCotiza.Columns.Add("Nafin", Type.GetType("System.Decimal"))
        dtCotiza.Columns.Add("Pagosi", Type.GetType("System.Decimal"))
        dtCotiza.Columns.Add("Tipar", Type.GetType("System.String"))
        dtCotiza.Clear()

        ' Creo la tabla dtTabla que me permitirá almacenar la información de la Tabla del Equipo

        dtTabla.Columns.Add("Plazo", Type.GetType("System.String"))
        dtTabla.Columns.Add("Saldoi", Type.GetType("System.Decimal"))
        dtTabla.Columns.Add("Capital", Type.GetType("System.Decimal"))
        dtTabla.Columns.Add("Interes", Type.GetType("System.Decimal"))
        dtTabla.Columns.Add("Renta", Type.GetType("System.Decimal"))
        dtTabla.Columns.Add("Ivacapi", Type.GetType("System.Decimal"))
        dtTabla.Columns.Add("Bonifica", Type.GetType("System.Decimal"))
        dtTabla.Columns.Add("Ivaint", Type.GetType("System.Decimal"))
        dtTabla.Columns.Add("Pagomen", Type.GetType("System.Decimal"))
        dtTabla.Clear()

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()
        cm3.Dispose()
        cm4.Dispose()
        cm5.Dispose()
        cm6.Dispose()

    End Sub

    Private Sub btnCalcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalcular.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim daTasasAplicables As New SqlDataAdapter(cm1)
        Dim daDerechos As New SqlDataAdapter(cm2)
        Dim dsAgil As New DataSet()
        Dim drTabla As DataRow
        Dim drDato As DataRow

        ' Declaración de variables de datos

        Dim lRD As Boolean = False
        Dim lDG As Boolean = False
        Dim lCorrecto As Boolean = True
        Dim nBonifica As Decimal = 0
        Dim nIvaCapital As Decimal = 0
        Dim nIvaInteres As Decimal = 0
        Dim nTasaAplicable As Decimal = 0

        Dim nAbCap As Decimal
        Dim nCapitalEquipo As Decimal
        Dim nInteresEquipo As Decimal
        Dim nLetra As Integer
        Dim nRentaEquipo As Decimal
        Dim nResidual As Decimal
        Dim nSaldoEquipo As Decimal
        Dim nSuma As Integer

        ' Este procedimiento debe determinar los campos calculados y si la validación
        ' es correcta, habilitará el botón Guardar Cambios; en caso contrario, enviará
        ' mensajes de error de validación

        cTipta = cbTasas.SelectedValue
        cFondeo = cbRecursos.SelectedValue
        nRD = cbRD.SelectedIndex
        nDG = cbDG.SelectedIndex

        nAmorinConIva = CDbl(txtAmorinConIva.Text)
        nEnganche = CDbl(txtEnganche.Text)

        If rbFisica.Checked = False And rbEmpresarial.Checked = False And rbMoral.Checked = False Then
            lCorrecto = False
            MsgBox("Selecciona el tipo de cliente al que estás cotizando", MsgBoxStyle.Critical, "Error de Validación")
        End If

        If cFondeo = "03" Then
            If cTipta <> "7" Then
                lCorrecto = False
                MsgBox("Un contrato descontado con FIRA debe tener TASA FIJA", MsgBoxStyle.Critical, "Error de Validación")
            End If
        End If

        If (Val(cbPlazo.SelectedItem) < 24 Or Val(cbPlazo.SelectedItem) > 36) And cFondeo = "02" Then
            lCorrecto = False
            MsgBox("Un contrato descontado con NAFIN solo tiene plazos de 24 a 36 meses", MsgBoxStyle.Critical, "Error de Validación")
        End If

        If (Val(cbPlazo.SelectedItem) < 24 Or Val(cbPlazo.SelectedItem) > 36) And cFondeo >= "03" Then
            lCorrecto = False
            MsgBox("Un contrato descontado con FIRA solo tiene plazos de 24 a 36 meses", MsgBoxStyle.Critical, "Error de Validación")
        End If

        If cFondeo <> "02" And rbDNTrue.Checked = True Then
            lCorrecto = False
            MsgBox("Solo los contratos descontados con NAFIN pueden tener 5% Depósito NAFIN", MsgBoxStyle.Critical, "Error de Validación")
        End If

        If cFondeo = "03" And rbDGTrue.Checked = True Then
            lCorrecto = False
            MsgBox("Un contrato descontado con FIRA no puede tener Depósito en Garantía", MsgBoxStyle.Critical, "Error de Validación")
        End If

        If Val(txtPorop.Text) < 0 Then
            lCorrecto = False
            MsgBox("El porcentaje de Opción de Compra no puede ser negativo", MsgBoxStyle.Critical, "Error de Validación")
        End If

        ' Validaciones para Arrendamiento Financiero

        If cTipar = "F" Then

            If cbPorieq.SelectedIndex() = 0 And rbDGTrue.Checked = True Then
                lCorrecto = False
                MsgBox("Arrendamiento Financiero sin IVA no puede tener Depósito en Garantía", MsgBoxStyle.Critical, "Error de Validación")
            End If

            If nAmorinConIva < 0 Then
                lCorrecto = False
                MsgBox("El valor de la amortización inicial no puede ser negativo", MsgBoxStyle.Critical, "Error de Validación")
            End If

            ' Si elegimos que la operación tenga Rentas en Depósito, tenemos que indicar el número de éstas

            If rbRDTrue.Checked = True And nRD = 0 Then
                lCorrecto = False
                MsgBox("Selecciona el número de rentas en depósito", MsgBoxStyle.Critical, "Error de Validación")
            End If

        End If

        ' Validaciones para Arrendamiento Puro

        If cTipar = "P" Then

            If cFondeo <> "01" Then
                lCorrecto = False
                MsgBox("Arrendamiento Puro solo con Recursos Propios", MsgBoxStyle.Critical, "Error de Validación")
            End If

            If Val(cbPlazo.SelectedItem) < 24 Then
                lCorrecto = False
                MsgBox("El plazo mínimo de un Arrendamiento Puro es de 24 meses", MsgBoxStyle.Critical, "Error de Validación")
            End If

            ' Si elegimos que la operación tenga Rentas en Depósito, tenemos que indicar el número de éstas

            If rbRDTrue.Checked = True And nRD = 0 Then
                lCorrecto = False
                MsgBox("Selecciona el número de rentas en depósito", MsgBoxStyle.Critical, "Error de Validación")
            End If

        End If

        ' Validaciones para Crédito Refaccionario

        If cTipar = "R" Then

            If cFondeo <> "01" Then
                lCorrecto = False
                MsgBox("Crédito Refaccionario solo con Recursos Propios", MsgBoxStyle.Critical, "Error de Validación")
            End If

            If nEnganche = 0 Then
                lCorrecto = False
                MsgBox("El valor del enganche no puede ser cero", MsgBoxStyle.Critical, "Error de Validación")
            End If

            If nEnganche < 0 Then
                lCorrecto = False
                MsgBox("El valor del enganche no puede ser negativo", MsgBoxStyle.Critical, "Error de Validación")
            End If

            ' Si elegimos que tenga Depósito en Garantía, el porcentaje no puede ser cero

            If rbDGTrue.Checked = True And nDG = 0 Then
                lCorrecto = False
                MsgBox("Selecciona el porcentaje del depósito", MsgBoxStyle.Critical, "Error de Validación")
            End If

        End If

        ' Validaciones generales aplicables a todo tipo de arrendamiento o crédito

        If CDbl(txtGastos.Text) < 0 Then
            lCorrecto = False
            MsgBox("Los Gastos de Ratificación con IVA no pueden ser negativos", MsgBoxStyle.Critical, "Error de Validación")
        End If

        If Val(txtPorco.Text) < 0 Then
            lCorrecto = False
            MsgBox("El porcentaje de Comisión no puede ser negativo", MsgBoxStyle.Critical, "Error de Validación")
        End If

        If CDbl(txtImpEq.Text) < 2000 Then
            lCorrecto = False
            MsgBox("El valor mínimo del Equipo con IVA es de $2,000.00", MsgBoxStyle.Critical, "Error de Validación")
        End If

        If lCorrecto = True Then

            btnCalcular.Visible = False
            gbPagos.Visible = True
            gbTasaAplicable.Visible = True
            gbPagosIniciales.Visible = True

            cFechacon = DTOC(dtpFechacon.Value)

            If rbFisica.Checked = True Then
                cTipo = "F"
            ElseIf rbEmpresarial.Checked = True Then
                cTipo = "E"
            ElseIf rbMoral.Checked = True Then
                cTipo = "M"
            End If

            ' El siguiente Stored Procedure trae todas las tasas aplicables para el tipo de crédito especificado

            With cm1
                .CommandType = CommandType.StoredProcedure
                .CommandText = "TasasAplicables1"
                .Connection = cnAgil
                .Parameters.Add("@TipoCredito", SqlDbType.NVarChar)
                .Parameters(0).Value = "AFsinIVA"
                .Parameters.Add("@Periodo", SqlDbType.NVarChar)
                .Parameters(1).Value = nPeriodo
            End With

            ' Llenar el DataSet lo cual abre y cierra la conexión

            daTasasAplicables.Fill(dsAgil, "AFsinIVA")

            ' Ahora defino el segundo tipo de crédito

            cm1.Parameters(0).Value = "AFconIVA"
            daTasasAplicables.Fill(dsAgil, "AFconIVA")

            ' Ahora defino el tercer tipo de crédito

            cm1.Parameters(0).Value = "AP"
            daTasasAplicables.Fill(dsAgil, "AP")

            ' Ahora defino el cuarto tipo de crédito

            cm1.Parameters(0).Value = "CR"
            daTasasAplicables.Fill(dsAgil, "CR")

            cm1.Parameters(0).Value = "TVCR"
            daTasasAplicables.Fill(dsAgil, "TVCR")

            ' Ahora defino el quinto tipo de crédito

            cm1.Parameters(0).Value = "TVAFsinIVA"
            daTasasAplicables.Fill(dsAgil, "TVAFsinIVA")

            ' Ahora defino el sexto tipo de crédito

            cm1.Parameters(0).Value = "TVAFconIVA"
            daTasasAplicables.Fill(dsAgil, "TVAFconIVA")

            cm1.Parameters(0).Value = "CS"
            daTasasAplicables.Fill(dsAgil, "CS")

            cm1.Parameters(0).Value = "TVCS"
            daTasasAplicables.Fill(dsAgil, "TVCS")


            ' El siguiente Stored Procedure trae todos los atributos de la Tabla Derechos

            With cm2
                .CommandType = CommandType.StoredProcedure
                .CommandText = "TraeDerechos"
                .Connection = cnAgil
            End With

            ' Este comando regresa el valor de la tasa TIIE para la vigencia dada o si la fecha de contratación
            ' es a futuro, regresa el valor más reciente de la tasa TIIE

            With cm3
                .CommandType = CommandType.Text
                .CommandText = "SELECT Valor FROM Hista WHERE Tasa = " & "'4'" & " AND Vigencia = '" & cFechacon & "'"
                .Connection = cnAgil
            End With

            ' Llenar el DataSet lo cual abre y cierra la conexión

            daDerechos.Fill(dsAgil, "Derechos")

            ' Ahora procedo a calcular los datos derivados

            nImpEq = CDbl(txtImpEq.Text)
            nIvaEq = 0
            nPorieq = 0

            If cbPorieq.SelectedIndex = 2 Then
                nPorieq = 16 / 100
                nIvaEq = Round(nImpEq / 1.16 * nPorieq, 2)
            End If
            nSubtotal = nImpEq - nIvaEq

            nAmorinConIva = CDbl(txtAmorinConIva.Text)

            ' Solo puede tratarse de arrendamiento financiero ya que
            ' el arrendamiento puro no lleva amortización inicial de capital ni enganche
            ' y los créditos refaccionarios tampoco llevan amortización inicial de capital
            ' solo enganche

            If nPorieq > 0 Then

                ' Existe IVA MOI por lo que tengo que desglosar el IVA de la amortización inicial de capital

                nAmorin = Round(nAmorinConIva / (1 + nPorieq), 2)
                nIvaAmorin = Round(nAmorin * nPorieq, 2)

            Else

                ' No existe IVA MOI por lo que la amortización inicial de capital tampoco lleva IVA

                nAmorin = nAmorinConIva
                nIvaAmorin = 0

            End If

            nSaldoEquipo = Round(nImpEq - nIvaEq - nAmorin - nEnganche, 2)
            nPlazo = Val(cbPlazo.SelectedItem)

            ' En esta parte se determina la tasa a partir de los datos del financiamiento o del crédito
            ' y en el caso de Arrendamiento Puro se determina el porcentaje de valor residual

            If rbRDTrue.Checked = True Then
                lRD = True
            ElseIf rbRDFalse.Checked = True Then
                lRD = False
            End If

            If rbDGTrue.Checked = True Then
                lDG = True
            ElseIf rbDGFalse.Checked = True Then
                lDG = False
            End If

            cnAgil.Open()
            nTasas = cm3.ExecuteScalar()
            cnAgil.Close()
            If nTasas = 0 Then

                ' Significa que no encontró la fecha dada por lo que debe traer el registro más reciente

                cm3.CommandText = "SELECT TOP 1 Valor FROM Hista WHERE Tasa = " & "'4'" & " ORDER BY Vigencia DESC"
                cnAgil.Open()
                nTasas = cm3.ExecuteScalar()
                cnAgil.Close()

            End If

            nDifer = 0
            nPorOp = 0

            ' Esta función determina la tasa aplicable a un contrato (si es tasa fija),
            ' el diferencial (si es un contrato con tasa variable) y 
            ' el porcentaje de valor residual (si se trata de un arrendamiento puro)

            TasaAplicable(cTipar, cTipta, nPlazo, nIvaEq, lRD, nRD, lDG, nDG, dsAgil, nTasas, nDifer, nPorOp)

            nTasaAplicable = (nTasas + nDifer) / 1200

            ' Aquí tengo que calcular el Valor Residual de los contratos de Arrendamiento Puro
            ' ya que el porcentaje se determinó algunas líneas arriba por lo que
            ' NO debemos mover esta sección de código.

            ' Para los contratos de Arrendamiento Financiero, se determina el porcentaje de la Opción de Compra
            ' y se calcula el monto de la misma 

            nPorCo = Val(txtPorco.Text) / 100

            nOpcion = 0
            nResidual = 0

            If cTipar = "F" Then

                nPorOp = 1
                nOpcion = Round(nImpEq * nPorOp / 100, 2)
                txtOpcion.Text = Format(nOpcion, "##,##0.00")

            ElseIf cTipar = "P" Then

                ' Recordar que el porcentaje del valor residual se calcula algunas líneas arriba por lo que
                ' NO debemos mover esta sección de código

                nResidual = Round((nImpEq - nIvaEq) * nPorOp / 100, 2)
                txtOpcion.Text = Format(nResidual, "##,##0.00")

            ElseIf cTipar = "R" Or cTipar = "S" Or cTipar = "N" Then

                ' Los Créditos Refaccionarios y los Créditos Simples no llevan Opción de Compra ni Valor Residual

                txtOpcion.Text = Format(0, "##,##0.00")

            End If

            txtSubtotal.Text = Format(nSubtotal, "##,##0.00")
            txtAmorinConIva.Text = Format(nAmorinConIva, "##,##0.00")
            txtEnganche.Text = Format(nEnganche, "##,##0.00")

            txtPIAmorin.Text = Format(nAmorin, "##,##0.00")
            txtPIIvaAmorin.Text = Format(nIvaAmorin, "##,##0.00")
            txtTasas.Text = Format(nTasas, "##,##0.0000")
            txtDifer.Text = Format(nDifer, "##,##0.0000")

            txtPorop.Text = Format(nPorOp, "F")

            If cTipar = "F" Or cTipar = "R" Or cTipar = "S" Or cTipar = "N" Then

                ' Arrendamiento Financiero o Crédito Refaccionario

                nMensu = Round(Pmt(nTasaAplicable, nPlazo, -nSaldoEquipo, 0), 2)

            ElseIf cTipar = "P" Then

                ' Arrendamiento Puro

                nMensu = Round(Pmt(nTasaAplicable, nPlazo, -nSaldoEquipo, nResidual), 2)

            End If

            nMontoFinanciado = Round(nImpEq - nIvaEq - nAmorin - nEnganche, 2)

            nDerechos = 0
            If cTipar = "R" Then
                For Each drDato In dsAgil.Tables("Derechos").Rows
                    If nMontoFinanciado >= drDato("Limite1") Then
                        nDerechos = drDato("Cobro")
                        If nMontoFinanciado >= drDato("Limite2") Then
                            nDerechos = drDato("Cobro")
                        End If
                    End If
                Next
            End If

            ' Aunque es lo mismo el monto financiado que el saldo del equipo, voy a dejar esta
            ' validación por claridad en los cálculos

            If cTipar = "R" Then
                nComision = Round(nMontoFinanciado * nPorCo * 1.16, 2)
            Else
                nComision = Round(nSaldoEquipo * nPorCo * 1.16, 2)
            End If

            nGastos = CDbl(txtGastos.Text)
            txtGastos.Text = Format(nGastos, "##,##0.00")
            txtPIGastos.Text = Format(nGastos, "##,##0.00")

            ' Aquí SIEMPRE debo calcular la tabla de amortización ya que si se elige imprimir la cotización
            ' debo enviar la tabla al reporte.   Al mismo tiempo puedo determinar el importe de las rentas
            ' en depósito de Arrendamiento Financiero o Arrendamiento Puro ya que si el cliente elige pagos
            ' decrecientes la renta no es igual para todos los periodos.

            nImpRD = 0
            nIvaRD = 0

            cForca = Trim(Str(cbEsquemas.SelectedIndex + 1))

            ' Toma la renta del equipo

            If cForca = "1" Then
                nRentaEquipo = Round(nMensu, 2)
            ElseIf cForca = "2" Then
                If cTipar = "F" Or cTipar = "R" Then
                    nAbCap = Round((nSaldoEquipo) / nPlazo, 2)
                ElseIf cTipar = "P" Then
                    nAbCap = Round((nSaldoEquipo - nResidual) / nPlazo, 2)
                End If
            End If

            nSuma = nPlazo - Val(cbRD.SelectedItem)

            dtTabla.Clear()

            For nLetra = 1 To nPlazo

                nInteresEquipo = Round(nSaldoEquipo * nTasaAplicable, 2)

                If cForca = "1" Then
                    nCapitalEquipo = Round(nRentaEquipo - nInteresEquipo, 2)
                ElseIf cForca = "2" Then
                    nCapitalEquipo = nAbCap
                End If

                If (cTipar = "F" Or cTipar = "R") And nLetra = nPlazo Then
                    nCapitalEquipo = nSaldoEquipo
                    nInteresEquipo = Round(nSaldoEquipo * nTasaAplicable, 2)
                End If

                nIvaCapital = 0
                nBonifica = 0

                If nPorieq > 0 Then

                    ' Se trata de una operación con IVA MOI por lo que debe calcular el IVA del Capital

                    nIvaCapital = Round(nCapitalEquipo * nPorieq, 2)

                    If rbDGTrue.Checked = True Then

                        ' Existe además Depósito en Garantía el cual siempre será equivalente al IVA MOI

                        nBonifica = nIvaCapital

                    End If

                End If

                ' El IVA de los intereses existe siempre para Arrendamiento Financiero,
                ' para Arrendamiento Puro no existe (en este caso se calcula el IVA de la renta),
                ' para Crédito Refaccionario y para Crédito Simple existe siempre y cuando
                ' el cliente sea persona física sin actividad empresarial

                nIvaInteres = 0

                If cTipar = "F" Then
                    nIvaInteres = Round(nInteresEquipo * 0.16, 2)
                ElseIf (cTipar = "R" Or cTipar = "S" Or cTipar = "N") And cTipo = "F" Then
                    nIvaInteres = Round(nInteresEquipo * 0.16, 2)
                End If

                ' Sumo las rentas en depósito que se integran a los Pagos Iniciales

                If nLetra > nSuma Then

                    nImpRD += nCapitalEquipo + nInteresEquipo

                    If cTipar = "F" Then

                        ' Tomamos el IVA de los intereses para considerarlo IVA de la Renta en Depósito

                        nIvaRD += nIvaInteres

                        ' Si la operación tiene IVA MOI, debemos aumentar el IVA del Capital,
                        ' no importando si deja Depósito en Garantía

                        If nIvaEq > 0 Then
                            nIvaRD += Round(nCapitalEquipo * 0.16, 2)
                        End If

                    ElseIf cTipar = "P" Then

                        nIvaRD += Round((nCapitalEquipo + nInteresEquipo) * 0.16, 2)

                    End If

                End If

                drTabla = dtTabla.NewRow()
                drTabla("Plazo") = nLetra
                drTabla("Saldoi") = nSaldoEquipo
                drTabla("Capital") = nCapitalEquipo
                drTabla("Interes") = nInteresEquipo
                drTabla("Renta") = Round(nCapitalEquipo + nInteresEquipo, 2)
                drTabla("Bonifica") = nBonifica
                If cTipar = "F" Or cTipar = "R" Or cTipar = "S" Or cTipar = "N" Then
                    drTabla("IvaInt") = nIvaInteres
                    drTabla("Ivacapi") = nIvaCapital
                    drTabla("Pagomen") = Round(nCapitalEquipo + nInteresEquipo + nIvaInteres + nIvaCapital - nBonifica, 2)
                ElseIf cTipar = "P" Then
                    drTabla("IvaInt") = Round((nCapitalEquipo + nInteresEquipo) * 0.16, 2)
                    drTabla("Ivacapi") = 0
                    drTabla("Pagomen") = Round((nCapitalEquipo + nInteresEquipo) * 1.16, 2)
                End If
                dtTabla.Rows.Add(drTabla)

                nSaldoEquipo -= nCapitalEquipo

            Next

            If rbRDTrue.Checked = False Then
                nImpRD = 0
                nIvaRD = 0
            End If

            If rbDNTrue.Checked = True And cFondeo = "02" Then
                nNafin = Round(nSaldoEquipo * 5 / 100, 2)
            Else
                nNafin = 0
            End If

            If rbDGTrue.Checked = True And cTipar = "R" Then

                ' Se trata del depósito en garantía de un crédito refaccionario

                Select Case cbDG.SelectedIndex
                    Case 0
                        nDG = 0
                    Case 1
                        nDG = 5
                    Case 2
                        nDG = 10
                    Case 3
                        nDG = 15
                End Select

                nImpDG = Round(nMontoFinanciado * nDG / 100, 2)
                nIvaDG = Round(nImpDG * 0.16, 2)

            End If

            If rbDGTrue.Checked = True And DTOC(dtpFechacon.Value) > "20020912" And nPorieq > 0 Then

                ' Se trata del depósito en garantía de un arrendamiento financiero

                nImpDG = Round((nIvaEq - nIvaAmorin) / 1.16, 2)
                nIvaDG = Round(nImpDG * 0.16, 2)

            End If

            txtImpEq.Text = Format(nImpEq, "##,##0.00")
            txtIvaEq.Text = Format(nIvaEq, "##,##0.00")
            txtPorop.Text = Format(nPorOp, "##,##0.00")
            If cForca = "1" Then
                txtMensu.Text = Format(nMensu, "##,##0.00")
            ElseIf cForca = "2" Then
                txtMensu.Text = "DECRECIENTE"
            End If
            txtMontoFinanciado.Text = Format(nMontoFinanciado, "##,##0.00")

            txtPIIvaAmorin.Text = Format(nIvaAmorin, "##,##0.00")
            txtPIEnganche.Text = Format(nEnganche, "##,##0.00")
            txtPIDerechos.Text = Format(nDerechos, "##,##0.00")
            txtComision.Text = Format(nComision, "##,##0.00")
            txtImpDG.Text = Format(nImpDG, "##,##0.00")
            txtIvaDG.Text = Format(nIvaDG, "##,##0.00")
            txtNafin.Text = Format(nNafin, "##,##0.00")
            txtImpRD.Text = Format(nImpRD, "##,##0.00")
            txtIvaRD.Text = Format(nIvaRD, "##,##0.00")

            ' Este valor es importante calcularlo porque en caso de que se elija fijar el pago inicial,
            ' el valor que se introduzca no podrá ser menor a éste.   En caso de ser mayor se ajustará
            ' en la amortización inicial de capital siempre y cuando no se trate de arrendamiento puro

            If lFijarPagoInicial = True Then

                ' Si el cliente decide fijar el pago inicial, entonces debo hacer una rutina de iteración
                ' utilizando como pivote el valor de la amortización inicial (o enganche) hasta que me
                ' dé el valor del pago inicial deseado

            Else

                nPagosIniciales = Round(nAmorin + nIvaAmorin + nEnganche + nDerechos + nComision + nImpDG + nIvaDG + nGastos + nNafin + nImpRD + nIvaRD, 2)

            End If

            txtPagosIniciales.Text = Format(nPagosIniciales, "##,##0.00")

            dtCotiza.Clear()

            drDato = dtCotiza.NewRow()
            drDato("Letras") = nPlazo.ToString
            drDato("Valfac") = nImpEq
            drDato("Ivafac") = nIvaEq
            drDato("Facsiniva") = nSubtotal
            drDato("Seguro") = 0
            drDato("Montofin") = nMontoFinanciado
            drDato("Porcom") = Round(nPorCo * 100, 2)
            drDato("Tasa") = Round(nTasas + nDifer, 2)
            If cTipar = "F" Then
                drDato("Opcomp") = nOpcion
            ElseIf cTipar = "P" Then
                drDato("Opcomp") = nResidual
            Else
                drDato("Opcomp") = 0
            End If
            drDato("Comision") = nComision
            drDato("Gastos") = nGastos
            drDato("Amortizacion") = Round(nAmorin + nIvaAmorin, 2)
            drDato("Enganche") = nEnganche
            drDato("Derechos") = nDerechos
            drDato("Depgar") = Round(nImpDG + nIvaDG, 2)
            drDato("Rentad") = Round(nImpRD + nIvaRD, 2)
            drDato("Nafin") = nNafin
            drDato("Pagosi") = nPagosIniciales
            drDato("Tipar") = cTipar
            dtCotiza.Rows.Add(drDato)

            btnCotizar.Location = New System.Drawing.Point(443, 241)
            btnCotizar.Visible = True
            gbCondiciones.Enabled = False
            gbTipoCliente.Enabled = False

        End If

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()
        cm3.Dispose()

    End Sub

    Private Sub cbProducto_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbProducto.SelectedIndexChanged

        If cbProducto.SelectedIndex = 0 Then


            ' Arrendamiento Financiero

            cTipar = "F"

            cbPorieq.Enabled = True

            txtPorop.ReadOnly = True
            txtPorco.Text = Format(2, "F")
            txtGastos.Text = Format(2000, "F")

            nEnganche = 0
            txtEnganche.Text = Format(nEnganche, "##,##0.00")
            txtAmorinConIva.Enabled = True
            txtEnganche.Enabled = False

            ' Habilita la opción de decidir si habrá o no rentas en depósito,
            ' por default selecciona que no habrá rentas en depósito y 
            ' marca cero rentas en depósito

            rbRDTrue.Enabled = True
            rbRDFalse.Enabled = True
            rbRDFalse.Checked = True
            cbRD.SelectedIndex = 0

            ' Habilita la opción de decidir si habrá o no depósito en garantía,
            ' por default selecciona que no habrá depósito en garantía y
            ' deshabilita la opción de capturar el porcentaje del depósito en garantía
            ' marcando cero por ciento de depósito en garantía

            rbDGTrue.Enabled = True
            rbDGFalse.Enabled = True
            rbDGFalse.Checked = True
            cbDG.SelectedIndex = 0
            cbDG.Enabled = False

            ' Habilita la opción de decidir si habrá o no depósito nafin,
            ' por default selecciona que no habrá depósito nafin

            rbDNTrue.Enabled = True
            rbDNFalse.Enabled = True
            rbDNFalse.Checked = True

            Label4.Text = "Opción de Compra"
            lblSubtotal.Text = "SubTotal del Equipo"
            lblOpcom.Text = "Opción a compra con I.V.A."
            lblRtaeq.Text = "Renta del Equipo"
            lblImpDGTF.Text = "Depósito en Garantía"
            lblImpDG.Text = "Depósito en Garantía"

        ElseIf cbProducto.SelectedIndex = 1 Then

            ' Arrendamiento Puro

            cTipar = "P"

            cbPorieq.Enabled = True

            txtPorop.Text = Format(1, "F")
            txtPorop.ReadOnly = True
            txtPorco.Text = Format(2, "F")
            txtGastos.Text = Format(2000, "F")

            nAmorinConIva = 0
            nAmorin = 0
            nIvaAmorin = 0
            txtAmorinConIva.Text = Format(nAmorinConIva, "##,##0.00")
            txtAmorinConIva.Enabled = False

            nEnganche = 0
            txtEnganche.Text = Format(nEnganche, "##,##0.00")
            txtEnganche.Enabled = False

            ' Habilita la opción de decidir si habrá o no rentas en depósito,
            ' por default selecciona que no habrá rentas en depósito y 
            ' marca cero rentas en depósito

            rbRDTrue.Enabled = True
            rbRDFalse.Enabled = True
            rbRDFalse.Checked = True
            cbRD.SelectedIndex = 0

            ' Deshabilita la opción de decidir si habrá o no depósito en garantía,
            ' por default selecciona que no habrá depósito en garantía y
            ' deshabilita la opción de capturar el porcentaje del depósito en garantía
            ' marcando cero por ciento de depósito en garantía

            rbDGTrue.Enabled = False
            rbDGFalse.Enabled = False
            rbDGFalse.Checked = True
            cbDG.SelectedIndex = 0
            cbDG.Enabled = False

            ' Deshabilita la opción de decidir si habrá o no depósito nafin,
            ' por default selecciona que no habrá depósito nafin

            rbDNTrue.Enabled = False
            rbDNFalse.Enabled = False
            rbDNFalse.Checked = True

            Label4.Text = "Valor Residual"
            lblSubtotal.Text = "SubTotal del Equipo"
            lblOpcom.Text = "Amortización Final"
            lblRtaeq.Text = "Pago Mensual sin IVA"
            lblImpDGTF.Text = "Depósito en Garantía"
            lblImpDG.Text = "Depósito en Garantía"

        ElseIf cbProducto.SelectedIndex = 2 Then

            ' Crédito Refaccionario

            cTipar = "R"

            cbPorieq.SelectedIndex = 0
            cbPorieq.Enabled = False
            txtPorop.Text = Format(0, "F")
            txtPorop.ReadOnly = True
            txtPorco.Text = Format(2, "F")
            txtGastos.Text = Format(2000, "F")

            nAmorinConIva = 0
            nAmorin = 0
            nIvaAmorin = 0
            txtAmorinConIva.Text = Format(nAmorinConIva, "##,##0.00")
            txtPIAmorin.Text = Format(nAmorin, "##,##0.00")
            txtPIIvaAmorin.Text = Format(nIvaAmorin, "##,##0.00")
            txtAmorinConIva.Enabled = False
            txtEnganche.Enabled = True

            nSubtotal = 0
            nIvaEq = 0
            txtSubtotal.Text = Format(nSubtotal, "##,##0.00")
            txtIvaEq.Text = Format(nIvaEq, "##,##0.00")

            ' Deshabilita la opción de decidir si habrá o no rentas en depósito,
            ' por default selecciona que no habrá rentas en depósito y 
            ' marca cero rentas en depósito

            rbRDTrue.Enabled = False
            rbRDFalse.Enabled = False
            rbRDFalse.Checked = True
            cbRD.SelectedIndex = 0

            ' Habilita la opción de decidir si habrá o no depósito en garantía,
            ' por default selecciona que no habrá depósito en garantía y
            ' por default selecciona cero por ciento de depósito en garantía

            rbDGTrue.Enabled = True
            rbDGFalse.Enabled = True
            rbDGFalse.Checked = True
            cbDG.SelectedIndex = 0

            ' Deshabilita la opción de decidir si habrá o no depósito nafin,
            ' por default selecciona que no habrá depósito nafin

            rbDNTrue.Enabled = False
            rbDNFalse.Enabled = False
            rbDNFalse.Checked = True

            Label4.Text = "Opción de Compra"
            lblOpcom.Text = "Opción a compra con I.V.A."
            lblRtaeq.Text = "Renta del Equipo"
            lblImpDGTF.Text = "Depósito FINAGIL"
            lblImpDG.Text = "Depósito FINAGIL"

        ElseIf cbProducto.SelectedIndex = 3 Then

            ' Crédito Simple

            cTipar = "S"

            cbPorieq.SelectedIndex = 0
            cbPorieq.Enabled = False
            txtPorop.Text = Format(0, "F")
            txtPorop.ReadOnly = True
            txtPorco.Text = Format(2, "F")
            txtGastos.Text = Format(2000, "F")

            nAmorinConIva = 0
            nAmorin = 0
            nIvaAmorin = 0
            txtAmorinConIva.Text = Format(nAmorinConIva, "##,##0.00")
            txtPIAmorin.Text = Format(nAmorin, "##,##0.00")
            txtPIIvaAmorin.Text = Format(nIvaAmorin, "##,##0.00")
            txtAmorinConIva.Enabled = False
            txtEnganche.Enabled = True

            nSubtotal = 0
            nIvaEq = 0
            txtSubtotal.Text = Format(nSubtotal, "##,##0.00")
            txtIvaEq.Text = Format(nIvaEq, "##,##0.00")

            ' Deshabilita la opción de decidir si habrá o no rentas en depósito,
            ' por default selecciona que no habrá rentas en depósito y 
            ' marca cero rentas en depósito

            rbRDTrue.Enabled = False
            rbRDFalse.Enabled = False
            rbRDFalse.Checked = True
            cbRD.SelectedIndex = 0

            ' Habilita la opción de decidir si habrá o no depósito en garantía,
            ' por default selecciona que no habrá depósito en garantía y
            ' por default selecciona cero por ciento de depósito en garantía

            rbDGTrue.Enabled = True
            rbDGFalse.Enabled = True
            rbDGFalse.Checked = True
            cbDG.SelectedIndex = 0

            ' Deshabilita la opción de decidir si habrá o no depósito nafin,
            ' por default selecciona que no habrá depósito nafin

            rbDNTrue.Enabled = False
            rbDNFalse.Enabled = False
            rbDNFalse.Checked = True

            Label4.Text = "Opción de Compra"
            lblOpcom.Text = "Opción a compra con I.V.A."
            lblRtaeq.Text = "Renta del Equipo"
            lblImpDGTF.Text = "Depósito FINAGIL"
            lblImpDG.Text = "Depósito FINAGIL"

        ElseIf cbProducto.SelectedIndex = 4 Then

            ' Crédito de Nómina

            cTipar = "N"

            cbPorieq.SelectedIndex = 0
            cbPorieq.Enabled = False
            txtPorop.Text = Format(0, "F")
            txtPorop.ReadOnly = True
            txtPorco.Text = Format(0, "F")
            txtGastos.Text = Format(0, "F")

            nAmorinConIva = 0
            nAmorin = 0
            nIvaAmorin = 0
            txtAmorinConIva.Text = Format(nAmorinConIva, "##,##0.00")
            txtPIAmorin.Text = Format(nAmorin, "##,##0.00")
            txtPIIvaAmorin.Text = Format(nIvaAmorin, "##,##0.00")
            txtAmorinConIva.Enabled = False
            txtEnganche.Enabled = True

            nSubtotal = 0
            nIvaEq = 0
            txtSubtotal.Text = Format(nSubtotal, "##,##0.00")
            txtIvaEq.Text = Format(nIvaEq, "##,##0.00")

            ' Deshabilita la opción de decidir si habrá o no rentas en depósito,
            ' por default selecciona que no habrá rentas en depósito y 
            ' marca cero rentas en depósito

            rbRDTrue.Enabled = False
            rbRDFalse.Enabled = False
            rbRDFalse.Checked = True
            cbRD.SelectedIndex = 0

            ' Habilita la opción de decidir si habrá o no depósito en garantía,
            ' por default selecciona que no habrá depósito en garantía y
            ' por default selecciona cero por ciento de depósito en garantía

            rbDGTrue.Enabled = True
            rbDGFalse.Enabled = True
            rbDGFalse.Checked = True
            cbDG.SelectedIndex = 0

            ' Deshabilita la opción de decidir si habrá o no depósito nafin,
            ' por default selecciona que no habrá depósito nafin

            rbDNTrue.Enabled = False
            rbDNFalse.Enabled = False
            rbDNFalse.Checked = True

            Label4.Text = "Opción de Compra"
            lblOpcom.Text = "Opción a compra con I.V.A."
            lblRtaeq.Text = "Renta del Equipo"
            lblImpDGTF.Text = "Depósito FINAGIL"
            lblImpDG.Text = "Depósito FINAGIL"

        End If

    End Sub

    Private Sub cbRecursos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbRecursos.SelectedIndexChanged

        If cbRecursos.SelectedIndex = 0 Then

            ' Recursos Propios

            rbRDTrue.Enabled = True
            rbRDFalse.Enabled = True

            rbDGTrue.Enabled = True
            rbDGFalse.Enabled = True

            rbDNTrue.Enabled = False
            rbDNFalse.Enabled = False

        ElseIf cbRecursos.SelectedIndex = 1 Then

            ' Recursos NAFIN

            rbRDTrue.Enabled = False
            rbRDFalse.Enabled = False

            rbDGTrue.Enabled = True
            rbDGFalse.Enabled = True

            rbDNTrue.Enabled = True
            rbDNFalse.Enabled = True

        ElseIf cbRecursos.SelectedIndex = 2 Then

            ' Recursos FIRA

            rbRDTrue.Enabled = False
            rbRDFalse.Enabled = False

            rbDGTrue.Enabled = False
            rbDGFalse.Enabled = False

            rbDNTrue.Enabled = False
            rbDNFalse.Enabled = False

        End If

    End Sub

    Private Sub cbPorieq_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbPorieq.SelectedIndexChanged

        If cbPorieq.SelectedIndex = 0 Then

            ' Operación sin IVA

            lblAmortiza.Text = "Amortización Inicial"

        ElseIf cbPorieq.SelectedIndex = 1 Then

            ' Operación con IVA

            lblAmortiza.Text = "Amortización Inicial con I.V.A."

        End If

    End Sub

    Private Sub rbRDTrue_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbRDTrue.CheckedChanged

        If rbRDTrue.Checked = True Then

            cbRD.Enabled = True

        End If

    End Sub

    Private Sub rbRDFalse_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbRDFalse.CheckedChanged

        If rbRDFalse.Checked = True Then

            cbRD.Enabled = False
            cbRD.SelectedIndex = 0

        End If

    End Sub

    Private Sub rbDGTrue_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbDGTrue.CheckedChanged

        If rbDGTrue.Checked = True Then

            If cTipar = "R" Then

                ' Crédito Refaccionario

                cbDG.Enabled = True
                cbDG.SelectedIndex = 1

            Else

                ' Arrendamiento Financiero ó Arrendamiento Puro

                cbDG.Enabled = False
                cbDG.SelectedIndex = 0

            End If

        End If

    End Sub

    Private Sub rbDGFalse_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbDGFalse.CheckedChanged

        If rbDGFalse.Checked = True Then

            nImpDG = 0
            nIvaDG = 0

            txtImpDG.Text = Format(nImpDG, "##,##0.00")
            txtIvaDG.Text = Format(nIvaDG, "##,##0.00")

            If cTipar = "R" Then
                cbDG.Enabled = False
                cbDG.SelectedIndex = 0
            End If

        End If

    End Sub

    Private Sub chkFijarPagoInicial_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFijarPagoInicial.CheckedChanged

        If chkFijarPagoInicial.Checked = True Then
            lFijarPagoInicial = True
            txtPagosIniciales.ReadOnly = False
        Else
            lFijarPagoInicial = False
            txtPagosIniciales.ReadOnly = True
        End If

    End Sub

    Private Sub btnCotizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCotizar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim dsImprimir As New DataSet()

        ' Declaración de variables de Crystal Reports

        Dim cReportComments As String = ""
        Dim cReportTitle As String = ""
        Dim newfrmTablaCotizador As frmTablaCotizador

        ' Declaración de variables de datos

        Dim cMostrar As String = ""

        btnCotizar.Visible = False
        btnNuevaCotizacion.Location = New System.Drawing.Point(443, 241)
        btnNuevaCotizacion.Visible = True

        If cTipar = "F" Then
            cReportTitle = "COTIZACIÓN DE ARRENDAMIENTO FINANCIERO A "
        ElseIf cTipar = "P" Then
            cReportTitle = "COTIZACIÓN DE ARRENDAMIENTO PURO A "
        ElseIf cTipar = "R" Then
            cReportTitle = "COTIZACIÓN DE CRÉDITO REFACCIONARIO A "
        ElseIf cTipar = "S" Then
            cReportTitle = "COTIZACIÓN DE CRÉDITO SIMPLE A "
        ElseIf cTipar = "N" Then
            cReportTitle = "COTIZACIÓN DE CRÉDITO DE NÓMINA A "
        End If

        If rbFisica.Checked = True Then
            cReportTitle += "PERSONA FÍSICA"
        ElseIf rbEmpresarial.Checked = True Then
            cReportTitle += "PERSONA FÍSICA CON ACTIVIDAD EMPRESARIAL"
        ElseIf rbMoral.Checked = True Then
            cReportTitle += "PERSONA MORAL"
        End If

        dsImprimir.Tables.Add(dtTabla)
        dsImprimir.Tables.Add(dtCotiza)

        ' Descomentar la siguiente línea en caso de que se deseara modificar el reporte rptImpreFac
        ' dsImprimir.WriteXml("C:\Schema43.xml", XmlWriteMode.WriteSchema)
        cReportComments = "ATENCIÓN : " & txtDescr.Text
        cMostrar = "Tabla de Amortización a " & nPlazo.ToString & " meses"

        newfrmTablaCotizador = New frmTablaCotizador(cReportTitle, cReportComments, cMostrar, dsImprimir)
        newfrmTablaCotizador.Show()

        dsImprimir.Tables.Remove("Datos")
        dsImprimir.Tables.Remove("TabEquipo")
        dsImprimir.Dispose()

    End Sub

    Private Sub btnNuevaCotizacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevaCotizacion.Click

        btnCotizar.Visible = False
        btnNuevaCotizacion.Visible = False
        btnCalcular.Visible = True

        gbCondiciones.Enabled = True
        gbTipoCliente.Enabled = True

        gbTasaAplicable.Visible = False
        gbPagos.Visible = False
        gbPagosIniciales.Visible = False

    End Sub

End Class