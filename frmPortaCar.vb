Option Explicit On 

Imports System.Data.SqlClient
Imports System.Math

Public Class frmPortacar

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
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents dtpProcesar As System.Windows.Forms.DateTimePicker
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.btnProcesar = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.dtpProcesar = New System.Windows.Forms.DateTimePicker
        Me.btnSalir = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(8, 52)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.ShowPrintButton = False
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1008, 641)
        Me.CrystalReportViewer1.TabIndex = 0
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'btnProcesar
        '
        Me.btnProcesar.Location = New System.Drawing.Point(244, 9)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(80, 24)
        Me.btnProcesar.TabIndex = 27
        Me.btnProcesar.Text = "Procesar"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(116, 16)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Fecha de Proceso"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpProcesar
        '
        Me.dtpProcesar.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpProcesar.Location = New System.Drawing.Point(128, 11)
        Me.dtpProcesar.Name = "dtpProcesar"
        Me.dtpProcesar.Size = New System.Drawing.Size(88, 20)
        Me.dtpProcesar.TabIndex = 25
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(350, 9)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(80, 24)
        Me.btnSalir.TabIndex = 28
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'frmPortacar
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1024, 702)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnProcesar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dtpProcesar)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Name = "frmPortacar"
        Me.Text = "Portafolio de Cartera para NAFIN"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm4 As New SqlCommand()
        Dim cm5 As New SqlCommand()
        Dim cm6 As New SqlCommand()
        Dim daAnexos As New SqlDataAdapter(cm1)
        Dim daEdoctav As New SqlDataAdapter(cm2)
        Dim daEdoctao As New SqlDataAdapter(cm4)
        Dim daFacturas As New SqlDataAdapter(cm5)
        Dim daProvinte As New SqlDataAdapter(cm6)
        Dim dsAgil As New DataSet()
        Dim dsReporte As New DataSet()
        Dim dtReporte As New DataTable("Reporte")
        Dim drEdoctav As DataRow()
        Dim drEdoctao As DataRow()
        Dim drProvinte As DataRow()
        Dim drAnexo As DataRow
        Dim drFactura As DataRow
        Dim drReporte As DataRow
        Dim relAnexoEdoctav As DataRelation
        Dim relAnexoEdoctao As DataRelation
        Dim relAnexoProvinte As DataRelation
        Dim myColArray(1) As DataColumn

        ' Declaración de variables de datos

        Dim cAnexo As String = ""
        Dim cCusnam As String = ""
        Dim cFecha As String = ""
        Dim cFechacon As String = ""
        Dim cFlcan As String = ""
        Dim cFondeo As String = ""
        Dim cFvenc As String = ""
        Dim cTermina As String = ""
        Dim cTipar As String = ""
        Dim cTipo As String = ""
        Dim cTipta As String = ""
        Dim nCapital As Decimal = 0
        Dim nCarteraEquipo As Decimal = 0
        Dim nCarteraOtros As Decimal = 0
        Dim nDifer As Decimal = 0
        Dim nInteres As Decimal = 0
        Dim nInteresEquipo As Decimal = 0
        Dim nInteresOtros As Decimal = 0
        Dim nIvaCapital As Decimal = 0
        Dim nIvaInteres As Decimal = 0
        Dim nMoi As Decimal = 0
        Dim nOtrosAdeudos As Decimal = 0
        Dim nPagado As Decimal = 0
        Dim nPlazo As Byte = 0
        Dim nPorieq As Decimal = 0
        Dim nRense As Decimal = 0
        Dim nSaldoEquipo As Decimal = 0
        Dim nSaldoFac As Decimal = 0
        Dim nSaldoOtros As Decimal = 0
        Dim nTasas As Decimal = 0

        ' Declaración de variables de Crystal Reports

        Dim newrptPortacar As New rptPortacar()

        cFecha = DTOC(dtpProcesar.Value)

        ' Primero creo la tabla Reporte que será la base del reporte

        dtReporte.Columns.Add("Anexo", Type.GetType("System.String"))
        dtReporte.Columns.Add("Nafin", Type.GetType("System.String"))
        dtReporte.Columns.Add("Acreditado", Type.GetType("System.String"))
        dtReporte.Columns.Add("Fechacon", Type.GetType("System.String"))
        dtReporte.Columns.Add("MOI", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("Plazo", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("Tasa", Type.GetType("System.String"))
        dtReporte.Columns.Add("Valor", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("CapitalVigente", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("InteresVigente", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("CapitalVencido", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("InteresVencido", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("OtrosVencido", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("MesesVencido", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("Flcan", Type.GetType("System.String"))
        dtReporte.Columns.Add("Termina", Type.GetType("System.String"))
        dtReporte.Columns.Add("Tipo", Type.GetType("System.String"))
        myColArray(0) = dtReporte.Columns("Anexo")
        dtReporte.PrimaryKey = myColArray

        ' Este Stored Procedure trae todos los contratos de arrendamiento financiero, arrendamiento puro,
        ' crédito refaccionario, crédito simple que estén activos y cuya fecha de contratación sea menor
        ' o igual a la de proceso

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "GeneProv1"
            .Connection = cnAgil
            .Parameters.Add("@FechaFin", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        ' Este Stored Procedure trae la tabla de amortización del equipo de todos los contratos de
        ' arrendamiento financiero, arrendamiento puro, crédito refaccionario, crédito simple
        ' que estén activos y cuya fecha de contratación sea menor o igual a la de proceso

        With cm2
            .CommandType = CommandType.StoredProcedure
            .CommandText = "GeneProv2"
            .Connection = cnAgil
            .Parameters.Add("@FechaFin", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        ' Este Stored Procedure trae la tabla de amortización de otros adeudos de todos los contratos 
        ' de arrendamiento financiero, arrendamiento puro, crédito refaccionario, crédito simple
        ' que estén activos y cuya fecha de contratación sea menor o igual a la de proceso

        With cm4
            .CommandType = CommandType.StoredProcedure
            .CommandText = "GeneProv4"
            .Connection = cnAgil
            .Parameters.Add("@FechaFin", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        ' Este Stored Procedure trae las facturas vencidas, el pago inicial (sin el 5% Nafin) 
        ' y la opción de compra exigible de los contratos activos o terminados con saldo en rentas

        With cm5
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Repantig1"
            .Connection = cnAgil
            .Parameters.Add("@Fecha", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        ' Este Stored Procedure trae la provisión de intereses al cierre de mes

        With cm6
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Provinte1"
            .Connection = cnAgil
        End With

        ' Llenar el DataSet a través del DataAdapter, lo cual abre y cierra la conexión

        daAnexos.Fill(dsAgil, "Anexos")
        daEdoctav.Fill(dsAgil, "Edoctav")
        daEdoctao.Fill(dsAgil, "Edoctao")
        daFacturas.Fill(dsAgil, "Facturas")
        daProvinte.Fill(dsAgil, "Provinte")

        ' Establecer la relación entre Anexos y Edoctav

        relAnexoEdoctav = New DataRelation("AnexoEdoctav", dsAgil.Tables("Anexos").Columns("Anexo"), dsAgil.Tables("Edoctav").Columns("Anexo"))
        dsAgil.EnforceConstraints = False
        dsAgil.Relations.Add(relAnexoEdoctav)

        ' Establecer la relación entre Anexos y Edoctao

        relAnexoEdoctaO = New DataRelation("AnexoEdoctaO", dsAgil.Tables("Anexos").Columns("Anexo"), dsAgil.Tables("EdoctaO").Columns("Anexo"))
        dsAgil.EnforceConstraints = False
        dsAgil.Relations.Add(relAnexoEdoctaO)

        ' Establecer la relación entre Anexos y Provinte

        relAnexoProvinte = New DataRelation("AnexoProvinte", dsAgil.Tables("Anexos").Columns("Anexo"), dsAgil.Tables("Provinte").Columns("Anexo"))
        dsAgil.EnforceConstraints = False
        dsAgil.Relations.Add(relAnexoProvinte)

        For Each drAnexo In dsAgil.Tables("Anexos").Rows

            cAnexo = drAnexo("Anexo")
            cTipar = drAnexo("Tipar")

            If cTipar = "F" Or cTipar = "R" Or cTipar = "S" Then

                cFlcan = drAnexo("Flcan")
                cFondeo = drAnexo("Fondeo")
                cCusnam = drAnexo("Descr")
                cFechacon = drAnexo("Fechacon")
                cFvenc = drAnexo("Fvenc")
                nPlazo = drAnexo("Plazo")
                cTermina = DTOC(Termina(CTOD(cFvenc), nPlazo))
                nMoi = Round(drAnexo("ImpEq") - drAnexo("IvaEq") - drAnexo("Amorin"), 2)
                cTipta = drAnexo("Tipta")
                nTasas = drAnexo("Tasas")
                nDifer = drAnexo("Difer")
                cTipo = drAnexo("Tipo")

                nSaldoEquipo = 0
                nInteresEquipo = 0
                nCarteraEquipo = 0

                nSaldoOtros = 0
                nInteresOtros = 0
                nCarteraOtros = 0

                ' Esta instrucción trae la tabla de amortización del Equipo única y exclusivamente del contrato
                ' que está siendo procesado a fin de calcular el saldo

                drEdoctav = drAnexo.GetChildRows("AnexoEdoctav")

                TraeSald(drEdoctav, cFecha, nSaldoEquipo, nInteresEquipo, nCarteraEquipo)

                ' Esta instrucción trae la tabla de amortización de Otros Adeudos única y exclusivamente del contrato
                ' que está siendo procesado a fin de calcular el saldo

                drEdoctao = drAnexo.GetChildRows("AnexoEdoctao")

                TraeSald(drEdoctao, cFecha, nSaldoOtros, nInteresOtros, nCarteraOtros)

                ' Esta instrucción trae el valor de la provisión de intereses al cierre de mes, exclusivamente
                ' del contrato que está siendo procesado

                drProvinte = drAnexo.GetChildRows("AnexoProvinte")

                If drProvinte.Length > 0 Then
                    nInteresEquipo = drProvinte(0)("Importe")
                Else
                    nInteresEquipo = 0
                End If

                drReporte = dtReporte.NewRow()
                drReporte("Anexo") = cAnexo
                drReporte("Nafin") = cFondeo
                drReporte("Acreditado") = cCusnam
                If cFvenc <= cFecha Then
                    drReporte("Fechacon") = cFvenc
                Else
                    drReporte("Fechacon") = cFechacon
                End If
                drReporte("Moi") = nMoi
                drReporte("Plazo") = nPlazo
                If cTipta = "7" Then
                    drReporte("Tasa") = "F"
                    drReporte("Valor") = Round(nTasas + nDifer, 2)
                Else
                    drReporte("Tasa") = "TIIE"
                    drReporte("Valor") = nDifer
                End If
                drReporte("CapitalVigente") = nSaldoEquipo + nSaldoOtros
                drReporte("InteresVigente") = nInteresEquipo
                drReporte("CapitalVencido") = 0
                drReporte("InteresVencido") = 0
                drReporte("OtrosVencido") = 0
                drReporte("MesesVencido") = 0
                drReporte("Flcan") = cFlcan
                drReporte("Termina") = cTermina
                drReporte("Tipo") = cTipo
                dtReporte.Rows.Add(drReporte)
            End If

        Next

        ' Este reporte no excluye los contratos terminados ya que podrían tener saldo en rentas
        ' y debe ser reportado como tal

        ' Ahora necesito determinar el desglose de la cartera exigible

        For Each drFactura In dsAgil.Tables("Facturas").Rows

            cAnexo = drFactura("Anexo")
            cTipar = drFactura("Tipar")

            If cTipar = "F" Or cTipar = "R" Or cTipar = "S" Then

                cFlcan = drFactura("Flcan")
                cFechacon = drFactura("Fechacon")
                cFvenc = drFactura("Fvenc")
                nPlazo = drFactura("Plazo")
                cTermina = DTOC(Termina(CTOD(cFvenc), nPlazo))
                cTipta = drFactura("Tipta")
                nTasas = drFactura("Tasas")
                nDifer = drFactura("Difer")
                nPorieq = drFactura("Porieq")
                nOtrosAdeudos = Round(drFactura("IvaOt") + drFactura("InteresOt") + drFactura("VarOt") + drFactura("CapitalOt"), 2)
                nIvaInteres = Round(drFactura("IvaPr") + drFactura("IvaSe"), 2)
                nInteres = Round(drFactura("IntPr") + drFactura("VarPr") + drFactura("IntSe") + drFactura("VarSe"), 2)
                nRense = drFactura("RenSe")
                nCapital = Round(drFactura("RenPr") - drFactura("IntPr") + drFactura("IvaCapital") - drFactura("Bonifica"), 2)
                nIvaCapital = drFactura("IvaCapital")
                nSaldoFac = drFactura("SaldoFac")
                nPagado = Round(drFactura("ImporteFac") - nSaldoFac, 2)

                If nPagado >= nOtrosAdeudos Then            ' Alcanza a cubrir Otros Adeudos
                    nPagado = nPagado - nOtrosAdeudos
                    nOtrosAdeudos = 0
                Else                                        ' Cubre parcialmente Otros Adeudos
                    nOtrosAdeudos = nOtrosAdeudos - nPagado
                    nPagado = 0
                End If
                If nPagado >= nIvaInteres Then              ' Alcanza a cubrir el IVA de los intereses
                    nPagado -= nIvaInteres
                    nIvaInteres = 0
                Else                                        ' Cubre parcialmente el IVA de los intereses
                    nIvaInteres -= nPagado
                    nPagado = 0
                End If
                If nPagado >= nInteres Then                 ' Alcanza a cubrir los intereses
                    nPagado -= nInteres
                    nInteres = 0
                Else                                        ' Cubre parcialmente los intereses
                    nInteres -= nPagado
                    nPagado = 0
                End If
                If nPagado >= nRense Then                   ' Alcanza a cubrir el seguro
                    nPagado -= nRense
                    nRense = 0
                Else                                        ' Cubre parcialmente el seguro
                    nRense -= nPagado
                    nPagado = 0
                End If
                If nPagado >= nCapital Then                 ' Alcanza a cubrir el Capital
                    nPagado -= nCapital
                    nCapital = 0
                Else                                        ' Cubre parcialmente el Capital
                    nCapital -= nPagado
                    nPagado = 0
                End If

                ' Si quedara algún saldo de capital, tengo que revisar si tiene IVA del capital
                ' para determinar el valor correspondiente de cada uno

                If nCapital > 0 And nIvaCapital > 0 Then
                    nCapital = Round(nCapital / (1 + (nPorieq / 100)), 2)
                    nIvaCapital = Round(nCapital * nPorieq / 100, 2)
                Else
                    nIvaCapital = 0
                End If

                drReporte = dtReporte.Rows.Find(cAnexo)

                If drReporte Is Nothing Then
                    drReporte = dtReporte.NewRow()
                    drReporte("Anexo") = cAnexo
                    drReporte("Nafin") = drFactura("Fondeo")
                    drReporte("Acreditado") = drFactura("Descr")
                    If cFvenc <= cFecha Then
                        drReporte("Fechacon") = cFvenc
                    Else
                        drReporte("Fechacon") = cFechacon
                    End If
                    drReporte("Fechacon") = drFactura("Fechacon")
                    drReporte("Moi") = Round(drFactura("ImpEq") - drFactura("IvaEq") - drFactura("Amorin"), 2)
                    drReporte("Plazo") = drFactura("Plazo")
                    If cTipta = "7" Then
                        drReporte("Tasa") = "F"
                        drReporte("Valor") = Round(nTasas + nDifer, 2)
                    Else
                        drReporte("Tasa") = "TIIE"
                        drReporte("Valor") = nDifer
                    End If
                    drReporte("CapitalVigente") = 0
                    drReporte("InteresVigente") = 0
                    drReporte("CapitalVencido") = nCapital
                    drReporte("InteresVencido") = nInteres
                    drReporte("OtrosVencido") = Round(nOtrosAdeudos + nIvaCapital + nRense + nIvaInteres, 2)
                    drReporte("MesesVencido") = 1
                    drReporte("Flcan") = cFlcan
                    drReporte("Termina") = cTermina
                    drReporte("Tipo") = cTipo
                    dtReporte.Rows.Add(drReporte)
                Else
                    drReporte("CapitalVencido") += nCapital
                    drReporte("InteresVencido") += nInteres
                    drReporte("OtrosVencido") += Round(nOtrosAdeudos + nIvaCapital + nRense + nIvaInteres, 2)
                    drReporte("MesesVencido") += 1
                End If
            End If
        Next

        Try
            dsReporte.Tables.Add(dtReporte)
            ' Descomentar la siguiente línea en caso de que se deseara modificar el reporte rptPortacar
            ' dsReporte.WriteXml("C:\Schema10.xml", XmlWriteMode.WriteSchema)
            newrptPortacar.SetDataSource(dsReporte)
            CrystalReportViewer1.ReportSource = newrptPortacar
        Catch eException As Exception
            MsgBox(eException.Source, MsgBoxStyle.Critical, eException.Message)
        End Try

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()
        cm4.Dispose()
        cm5.Dispose()
        cm6.Dispose()

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class
