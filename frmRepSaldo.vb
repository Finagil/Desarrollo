' Este reporte excluye los contratos con rentas vencidas a mas de 89 días y los contratos que no hayan sido efectivamente pagados a partir del 1o. de octubre de 2011

Option Explicit On 

Imports System.Data.SqlClient
Imports System.Math
Imports CrystalDecisions.Shared

Public Class frmRepSaldo

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
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(8, 56)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1008, 640)
        Me.CrystalReportViewer1.TabIndex = 0
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'btnProcesar
        '
        Me.btnProcesar.Location = New System.Drawing.Point(252, 13)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(75, 23)
        Me.btnProcesar.TabIndex = 24
        Me.btnProcesar.Text = "Procesar"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 16)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Fecha de Proceso"
        '
        'dtpProcesar
        '
        Me.dtpProcesar.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpProcesar.Location = New System.Drawing.Point(134, 14)
        Me.dtpProcesar.Name = "dtpProcesar"
        Me.dtpProcesar.Size = New System.Drawing.Size(88, 20)
        Me.dtpProcesar.TabIndex = 22
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(354, 13)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 25
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'frmRepSaldo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1024, 702)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnProcesar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dtpProcesar)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Name = "frmRepSaldo"
        Me.Text = "Reporte de Saldos Insolutos"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click

        ' Este programa debe tomar todos los contratos activos con fecha de contratación menor o igual a la
        ' fecha de proceso.   También debe tomar la tabla de amortización de todos los contratos obtenidos 
        ' con el criterio anterior, tanto la del equipo como la del seguro.   Aunque esto creará un dataset con
        ' muchos registros, por otra parte permitirá mantener abierta la conexión únicamente durante el
        ' tiempo que tarde en traer dicha información de la base de datos.

        ' Adicionalmente deberá traer todas las facturas no pagadas de los contratos activos con fecha de
        ' contratación menor o igual a la fecha de proceso.   Esto con el fin de determinar y excluir aquellos
        ' contratos con rentas vencidas a más de 89 días.

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim cm4 As New SqlCommand()
        Dim cm5 As New SqlCommand()
        Dim dsAgil As New DataSet()
        Dim dsReporte As New DataSet()
        Dim daAnexos As New SqlDataAdapter(cm1)
        Dim daEdoctav As New SqlDataAdapter(cm2)
        Dim daEdoctas As New SqlDataAdapter(cm3)
        Dim daEdoctao As New SqlDataAdapter(cm4)
        Dim daFacturas As New SqlDataAdapter(cm5)
        Dim dtReporte As New DataTable("Reporte")
        Dim dtFinal As New DataTable()
        Dim drEdoctav As DataRow()
        Dim drEdoctas As DataRow()
        Dim drEdoctao As DataRow()
        Dim drFacturas As DataRow()
        Dim drRegistros As DataRow()
        Dim drAnexo As DataRow
        Dim drRegistro As DataRow
        Dim drReporte As DataRow
        Dim relAnexoEdoctav As DataRelation
        Dim relAnexoEdoctas As DataRelation
        Dim relAnexoEdoctao As DataRelation
        Dim relAnexoFacturas As DataRelation

        ' Declaración de variables de datos

        Dim cAnexo As String = ""
        Dim cCusnam As String = ""
        Dim cFecha As String = ""
        Dim cFechacon As String = ""
        Dim cFondeo As String = ""
        Dim cForca As String = ""
        Dim cFvenc As String = ""
        Dim cTipar As String = ""
        Dim cTipo As String = ""
        Dim cTipta As String = ""
        Dim nAmorin As Decimal = 0
        Dim nBonifica As Decimal = 0
        Dim nCarteraEquipo As Decimal = 0
        Dim nCarteraSeguro As Decimal = 0
        Dim nCarteraOtros As Decimal = 0
        Dim nCounter As Integer = 0
        Dim nMaxCounter As Integer = 100
        Dim nDifer As Decimal = 0
        Dim nImpDG As Decimal = 0
        Dim nImpEq As Decimal = 0
        Dim nImpRD As Decimal = 0
        Dim nInteresEquipo As Decimal = 0
        Dim nInteresSeguro As Decimal = 0
        Dim nInteresOtros As Decimal = 0
        Dim nIvaBonifica As Decimal = 0
        Dim nIvaDG As Decimal = 0
        Dim nIvaDiferido As Decimal = 0
        Dim nIvaEq As Decimal = 0
        Dim nIvaRD As Decimal = 0
        Dim nPlazo As Byte = 0
        Dim nPorieq As Decimal = 0
        Dim nRtasD As Decimal = 0
        Dim nSaldoEquipo As Decimal = 0
        Dim nSaldoSeguro As Decimal = 0
        Dim nSaldoOtros As Decimal = 0
        Dim nTasas As Decimal = 0

        ' Declaración de variables de Crystal Reports

        Dim newrptRepsaldo As New rptRepsaldo()

        btnProcesar.Enabled = False

        cFecha = DTOC(dtpProcesar.Value)

        ' Primero creo la tabla Reporte que será la base del reporte

        dtReporte.Columns.Add("Tipo", Type.GetType("System.String"))
        dtReporte.Columns.Add("Contrato", Type.GetType("System.String"))
        dtReporte.Columns.Add("Cliente", Type.GetType("System.String"))
        dtReporte.Columns.Add("SaldoEquipo", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("IvaDiferido", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("Deposito", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("IvaDeposito", Type.GetType("System.Decimal"))        ' Antes decía Termina y era de tipo string
        dtReporte.Columns.Add("Mpt", Type.GetType("System.String"))                 ' Antes decía MPT
        dtReporte.Columns.Add("SaldoSeguro", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("SaldoOtros", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("SaldoTotal", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("InteresEquipo", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("CarteraEquipo", Type.GetType("System.Decimal"))

        ' Este Stored Procedure trae todos los contratos activos con fecha de contratación menor o igual a la de proceso

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "GeneProv1"
            .Connection = cnAgil
            .Parameters.Add("@FechaFin", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        ' Este Stored Procedure trae la tabla de amortización del equipo de todos los contratos activos
        ' con fecha de contratación menor o igual a la de proceso

        With cm2
            .CommandType = CommandType.StoredProcedure
            .CommandText = "GeneProv2"
            .Connection = cnAgil
            .Parameters.Add("@FechaFin", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        ' Este Stored Procedure trae la tabla de amortización del seguro de todos los contratos activos
        ' con fecha de contratación menor o igual a la de proceso

        With cm3
            .CommandType = CommandType.StoredProcedure
            .CommandText = "GeneProv3"
            .Connection = cnAgil
            .Parameters.Add("@FechaFin", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        ' Este Stored Procedure trae la tabla de amortización de otros adeudos de todos los contratos activos
        ' con fecha de contratación menor o igual a la de proceso

        With cm4
            .CommandType = CommandType.StoredProcedure
            .CommandText = "GeneProv4"
            .Connection = cnAgil
            .Parameters.Add("@FechaFin", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        ' Este Stored Procedure trae todas las facturas no pagadas de todos los contratos activos con fecha de
        ' contratación menor o igual a la de proceso

        With cm5
            .CommandType = CommandType.StoredProcedure
            .CommandText = "CalcAnti1"
            .Connection = cnAgil
            .Parameters.Add("@Fecha", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        ' Llenar el DataSet a través del DataAdapter, lo cual abre y cierra la conexión

        daAnexos.Fill(dsAgil, "Anexos")
        daEdoctav.Fill(dsAgil, "Edoctav")
        daEdoctas.Fill(dsAgil, "Edoctas")
        daEdoctao.Fill(dsAgil, "Edoctao")
        daFacturas.Fill(dsAgil, "Facturas")

        ' Establecer la relación entre Anexos y Edoctav

        relAnexoEdoctav = New DataRelation("AnexoEdoctav", dsAgil.Tables("Anexos").Columns("Anexo"), dsAgil.Tables("Edoctav").Columns("Anexo"))
        dsAgil.EnforceConstraints = False
        dsAgil.Relations.Add(relAnexoEdoctav)

        ' Establecer la relación entre Anexos y Edoctas

        relAnexoEdoctas = New DataRelation("AnexoEdoctas", dsAgil.Tables("Anexos").Columns("Anexo"), dsAgil.Tables("Edoctas").Columns("Anexo"))
        dsAgil.EnforceConstraints = False
        dsAgil.Relations.Add(relAnexoEdoctas)

        ' Establecer la relación entre Anexos y Edoctao

        relAnexoEdoctao = New DataRelation("AnexoEdoctao", dsAgil.Tables("Anexos").Columns("Anexo"), dsAgil.Tables("Edoctao").Columns("Anexo"))
        dsAgil.EnforceConstraints = False
        dsAgil.Relations.Add(relAnexoEdoctao)

        ' Establecer la relación entre Anexos y Facturas

        relAnexoFacturas = New DataRelation("AnexoFacturas", dsAgil.Tables("Anexos").Columns("Anexo"), dsAgil.Tables("Facturas").Columns("Anexo"))
        dsAgil.EnforceConstraints = False
        dsAgil.Relations.Add(relAnexoFacturas)

        For Each drAnexo In dsAgil.Tables("Anexos").Rows

            cAnexo = drAnexo("Anexo")
            cCusnam = drAnexo("Descr")
            cTipar = drAnexo("Tipar")
            cTipo = drAnexo("Tipar")
            nPlazo = drAnexo("Plazo")
            cFechacon = drAnexo("Fechacon")
            cFvenc = drAnexo("Fvenc")
            cFondeo = drAnexo("Fondeo")
            cTipta = drAnexo("Tipta")
            nTasas = drAnexo("Tasas")
            nDifer = drAnexo("Difer")
            cForca = drAnexo("Forca")
            nPorieq = drAnexo("Porieq")
            nImpEq = drAnexo("ImpEq")
            nAmorin = drAnexo("Amorin")
            nIvaEq = drAnexo("IvaEq")
            nRtasD = drAnexo("RtasD")
            nImpRD = drAnexo("ImpRD")   ' Depósito en Garantía
            nIvaRD = drAnexo("IvaRD")
            nImpDG = drAnexo("ImpDG")   ' Rentas en Depósito
            nIvaDG = drAnexo("IvaDG")

            drFacturas = drAnexo.GetChildRows("AnexoFacturas")

            CalcAnti(cAnexo, cFecha, nMaxCounter, nCounter, drFacturas)

            If nCounter > nMaxCounter Then
                cTipo = "V"
            End If

            ' Esta instrucción trae la tabla de amortización del Equipo única y exclusivamente del contrato
            ' que está siendo procesado

            nSaldoEquipo = 0
            nInteresEquipo = 0
            nCarteraEquipo = 0

            drEdoctav = drAnexo.GetChildRows("AnexoEdoctav")
            TraeSald(drEdoctav, cFecha, nSaldoEquipo, nInteresEquipo, nCarteraEquipo)

            ' Esta instrucción trae la tabla de amortización del Seguro única y exclusivamente del contrato
            ' que está siendo procesado

            nSaldoSeguro = 0
            nInteresSeguro = 0
            nCarteraSeguro = 0

            drEdoctas = drAnexo.GetChildRows("AnexoEdoctas")
            TraeSald(drEdoctas, cFecha, nSaldoSeguro, nInteresSeguro, nCarteraSeguro)

            ' Esta instrucción trae la tabla de amortización de otros adeudos única y exclusivamente del contrato
            ' que está siendo procesado

            nSaldoOtros = 0
            nInteresOtros = 0
            nCarteraOtros = 0

            drEdoctao = drAnexo.GetChildRows("AnexoEdoctao")
            TraeSald(drEdoctao, cFecha, nSaldoOtros, nInteresOtros, nCarteraOtros)

            ' Debe determinar si es un contrato con IVA diferido

            nIvaDiferido = 0
            If cFechacon >= "20020301" And nIvaEq > 0 Then
                nIvaDiferido = Round(nSaldoEquipo * nPorieq / 100, 2)
            End If

            ' Debe determinar si el cliente dejó un Depósito en Garantía

            nBonifica = 0
            nIvaBonifica = 0
            If cFechacon >= "20020901" And nImpRD > 0 And nRtasD = 0 Then
                If cTipar = "F" Then
                    nBonifica = Round(nSaldoEquipo * ((nImpRD) / (nImpEq - nIvaEq - nAmorin)), 2)
                    nIvaBonifica = Round(nBonifica * (nIvaRD / nImpRD), 2)
                ElseIf cTipar = "R" Then
                    nBonifica = nImpRD
                    nIvaBonifica = nIvaRD
                End If
            End If

            'If cTipar = "F" Then
            '    nIvaDiferido = Round(nIvaDiferido - nBonifica, 2)
            '    nBonifica = 0
            'End If

            ' También tengo que determinar si el cliente dejó Rentas en Depósito

            'If nImpDG > 0 Then
            '    nBonifica = Round(nBonifica + nImpDG + nIvaDG, 2)
            'End If

            drReporte = dtReporte.NewRow()
            drReporte("Tipo") = cTipo
            drReporte("Contrato") = Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 6, 4)
            drReporte("Cliente") = cCusnam
            drReporte("SaldoEquipo") = nSaldoEquipo
            drReporte("IvaDiferido") = nIvaDiferido
            drReporte("Deposito") = nBonifica
            drReporte("IvaDeposito") = nIvaBonifica
            drReporte("Mpt") = Mpt(Termina(CTOD(cFvenc), nPlazo), dtpProcesar.Value)
            drReporte("SaldoSeguro") = nSaldoSeguro
            drReporte("SaldoOtros") = nSaldoOtros
            drReporte("SaldoTotal") = nSaldoEquipo + nIvaDiferido - nBonifica + nSaldoSeguro + nSaldoOtros
            drReporte("InteresEquipo") = nInteresEquipo
            drReporte("CarteraEquipo") = nCarteraEquipo
            dtReporte.Rows.Add(drReporte)

        Next

        Try

            dtFinal = dtReporte.Clone()
            drRegistros = dtReporte.Select(True, "Tipo, Contrato")

            For Each drRegistro In drRegistros
                dtFinal.ImportRow(drRegistro)
            Next

            dsReporte.Tables.Add(dtFinal)
            ' Descomentar la siguiente línea en caso de que se deseara modificar el reporte rptRepSaldo
            ' dsReporte.WriteXml("C:\Schema4.xml", XmlWriteMode.WriteSchema)
            newrptRepsaldo.SetDataSource(dsReporte)
            newrptRepsaldo.SummaryInfo.ReportComments = Mes(cFecha)
            CrystalReportViewer1.ReportSource = newrptRepsaldo

        Catch eException As Exception

            MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")

        End Try

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()
        cm3.Dispose()
        cm4.Dispose()
        cm5.Dispose()

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class
