Option Explicit On

Imports System.Data.SqlClient
Imports System.Math

Public Class frmRepSalCli

    Private Sub frmRepSalCli_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daClientes As New SqlDataAdapter(cm1)
        Dim dsAgil As New DataSet()

        ' Este Stored Procedure trae TODOS los clientes que existan en la tabla Clientes sin
        ' importar si tienen o no solicitudes dadas de alta

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "ContClie1"
            .Connection = cnAgil
        End With

        ComboBox1.MaxDropDownItems = 25

        Try

            ' Llenar el DataSet lo cual abre y cierra la conexión

            daClientes.Fill(dsAgil, "Clientes")

            ' Ligar la tabla Clientes del dataset dsAgil al ComboBox

            ComboBox1.DataSource = dsAgil
            ComboBox1.DisplayMember = "Clientes.Descr"
            ComboBox1.ValueMember = "Clientes.Cliente"

        Catch eException As Exception

            MsgBox(eException.Source & " " & eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")

        End Try

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim daAnexos As New SqlDataAdapter(cm1)
        Dim daEdoctav As New SqlDataAdapter(cm2)
        Dim daEdoctas As New SqlDataAdapter(cm3)
        Dim dsAgil As New DataSet()
        Dim dsReporte As New DataSet()
        Dim dtReporte As New DataTable("Reporte")
        Dim dtFinal As New DataTable()
        Dim drEdoctav As DataRow()
        Dim drEdoctas As DataRow()
        Dim drRegistros As DataRow()
        Dim drAnexo As DataRow
        Dim drRegistro As DataRow
        Dim drReporte As DataRow
        Dim relAnexoEdoctav As DataRelation
        Dim relAnexoEdoctas As DataRelation

        ' Declaración de variables de datos

        Dim cAnexo As String
        Dim cCusnam As String
        Dim cCliente As String
        Dim cFecha As String
        Dim cFechacon As String
        Dim cFlcan As String
        Dim cFondeo As String
        Dim cForca As String
        Dim cFvenc As String
        Dim cTipar As String
        Dim cDescr As String
        Dim nAmorin As Decimal
        Dim nBonifica As Decimal
        Dim nCarteraEquipo As Decimal
        Dim nCarteraSeguro As Decimal
        Dim nDifer As Decimal
        Dim nImpEq As Decimal
        Dim nImpRD As Decimal
        Dim nInteresEquipo As Decimal
        Dim nInteresSeguro As Decimal
        Dim nIvaDiferido As Decimal
        Dim nIvaEq As Decimal
        Dim nIvaRD As Decimal
        Dim nPlazo As Byte
        Dim nPorieq As Decimal
        Dim nRtasD As Decimal
        Dim nSaldoEquipo As Decimal
        Dim nSaldoSeguro As Decimal
        Dim nTasas As Decimal

        ' Declaración de variables de Crystal Reports

        Dim newrptRepSalCli As New rptRepSalCli()

        cFecha = DTOC(dtpProcesar.Value)
        cCliente = ComboBox1.SelectedValue.ToString()
        cDescr = RTrim(ComboBox1.Text)

        ' Primero creo la tabla Reporte que será la base del reporte

        dtReporte.Columns.Add("Contrato", Type.GetType("System.String"))
        dtReporte.Columns.Add("Cliente", Type.GetType("System.String"))
        dtReporte.Columns.Add("SaldoEquipo", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("IvaDiferido", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("Deposito", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("SaldoSeguro", Type.GetType("System.Decimal"))
        dtReporte.Columns.Add("SaldoTotal", Type.GetType("System.Decimal"))

        ' Este Stored Procedure trae todos los contratos de un cliente dado sin importar su estatus

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "PideAnex2"
            .Connection = cnAgil
            .Parameters.Add("@Cliente", SqlDbType.NVarChar)
            .Parameters(0).Value = cCliente
        End With

        ' El siguiente Stored Procedure trae todos los atributos de la tabla Edoctav,
        ' para un anexo dado

        With cm2
            .CommandType = CommandType.StoredProcedure
            .CommandText = "TablaEquipo1"
            .Connection = cnAgil
            .Parameters.Add("@Anexo", SqlDbType.NVarChar)
        End With

        ' El siguiente Stored Procedure trae todos los atributos de la tabla Edoctas,
        ' para un anexo dado

        With cm3
            .CommandType = CommandType.StoredProcedure
            .CommandText = "TablaSeguro1"
            .Connection = cnAgil
            .Parameters.Add("@Anexo", SqlDbType.NVarChar)
        End With

        ' Llenar el DataSet lo cual abre y cierra la conexión

        daAnexos.Fill(dsAgil, "Anexos")

        For Each drAnexo In dsAgil.Tables("Anexos").Rows

            cAnexo = drAnexo("Anexo")
            cCusnam = cDescr
            cTipar = drAnexo("Tipar")
            nPlazo = drAnexo("Plazo")
            cFechacon = drAnexo("Fechacon")
            cFvenc = drAnexo("Fvenc")
            cFondeo = drAnexo("Fondeo")
            nTasas = drAnexo("Tasas")
            nDifer = drAnexo("Difer")
            cForca = drAnexo("Forca")
            nPorieq = drAnexo("Porieq")
            nImpEq = drAnexo("ImpEq")
            nAmorin = drAnexo("Amorin")
            nIvaEq = drAnexo("IvaEq")
            nImpRD = drAnexo("ImpRD")
            nIvaRD = drAnexo("IvaRD")
            nRtasD = drAnexo("RtasD")
            cFlcan = drAnexo("Flcan")

            If cFlcan = "A" Then

                cm2.Parameters(0).Value = cAnexo
                cm3.Parameters(0).Value = cAnexo

                ' Llenar el DataSet a través del DataAdapter, lo cual abre y cierra la conexión

                daEdoctav.Fill(dsAgil, "Edoctav")
                daEdoctas.Fill(dsAgil, "Edoctas")

                ' Establecer la relación entre Anexos y Edoctav

                relAnexoEdoctav = New DataRelation("AnexoEdoctav", dsAgil.Tables("Anexos").Columns("Anexo"), dsAgil.Tables("Edoctav").Columns("Anexo"))
                dsAgil.EnforceConstraints = False
                dsAgil.Relations.Add(relAnexoEdoctav)

                ' Establecer la relación entre Anexos y Edoctas

                relAnexoEdoctas = New DataRelation("AnexoEdoctas", dsAgil.Tables("Anexos").Columns("Anexo"), dsAgil.Tables("Edoctas").Columns("Anexo"))
                dsAgil.EnforceConstraints = False
                dsAgil.Relations.Add(relAnexoEdoctas)

                ' Se trata de un contrato que NO está vencido (no tiene rentas vencidas a más de 89 días)

                nSaldoEquipo = 0
                nInteresEquipo = 0
                nCarteraEquipo = 0

                ' Esta instrucción trae la tabla de amortización del Equipo única y exclusivamente del contrato
                ' que está siendo procesado

                drEdoctav = drAnexo.GetChildRows("AnexoEdoctav")
                TraeSald(drEdoctav, cFecha, nSaldoEquipo, nInteresEquipo, nCarteraEquipo)

                nSaldoSeguro = 0
                nInteresSeguro = 0
                nCarteraSeguro = 0

                ' Esta instrucción trae la tabla de amortización del Seguro única y exclusivamente del contrato
                ' que está siendo procesado

                drEdoctas = drAnexo.GetChildRows("AnexoEdoctas")
                TraeSald(drEdoctas, cFecha, nSaldoSeguro, nInteresSeguro, nCarteraSeguro)

                ' Debe determinar si es un contrato con IVA diferido

                nIvaDiferido = 0
                If cFechacon >= "20020301" And nIvaEq > 0 Then
                    nIvaDiferido = Round(nSaldoEquipo * nPorieq / 100, 2)
                End If

                ' Debe determinar si el cliente dejó un Depósito en Garantía

                nBonifica = 0
                If cFechacon >= "200020901" And nImpRD > 0 And nRtasD = 0 Then
                    nBonifica = Round(nSaldoEquipo * ((nImpRD + nIvaRD) / (nImpEq - nIvaEq - nAmorin)), 2)
                End If

                drReporte = dtReporte.NewRow()
                drReporte("Contrato") = Mid(cAnexo, 1, 5) & "/" & Mid(cAnexo, 6, 4)
                drReporte("Cliente") = cCusnam
                drReporte("SaldoEquipo") = nSaldoEquipo
                drReporte("IvaDiferido") = nIvaDiferido
                drReporte("Deposito") = nBonifica
                drReporte("SaldoSeguro") = nSaldoSeguro
                drReporte("SaldoTotal") = nSaldoEquipo + nIvaDiferido - nBonifica + nSaldoSeguro
                dtReporte.Rows.Add(drReporte)

                dsAgil.Relations.Clear()
                dsAgil.Tables("Edoctav").Constraints.Clear()
                dsAgil.Tables("Edoctas").Constraints.Clear()
                dsAgil.Tables.Remove("Edoctav")
                dsAgil.Tables.Remove("Edoctas")

            End If

        Next

        Try

            dtFinal = dtReporte.Clone()
            drRegistros = dtReporte.Select(True, "Contrato")

            For Each drRegistro In drRegistros
                dtFinal.ImportRow(drRegistro)
            Next

            dsReporte.Tables.Add(dtFinal)
            ' Descomentar la siguiente línea en caso de que se deseara modificar el reporte rptRepSaldo
            ' dsReporte.WriteXml("C:\Schema4.xml", XmlWriteMode.WriteSchema)
            newrptRepSalCli.SetDataSource(dsReporte)
            newrptRepSalCli.SummaryInfo.ReportTitle = cCusnam
            newrptRepSalCli.SummaryInfo.ReportComments = Mes(cFecha)
            CrystalReportViewer1.ReportSource = newrptRepSalCli

        Catch eException As Exception

            MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")

        End Try

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()
        cm3.Dispose()

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

   End Class
