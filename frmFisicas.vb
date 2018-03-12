Option Explicit On 

Imports System.Data.SqlClient
Imports System.Math
Imports System.IO
Imports System.Text

Public Class frmFisicas

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
    Friend WithEvents lblProceso As System.Windows.Forms.Label
    Friend WithEvents dtpProceso As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnGeneraF As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnProcesar = New System.Windows.Forms.Button
        Me.lblProceso = New System.Windows.Forms.Label
        Me.dtpProceso = New System.Windows.Forms.DateTimePicker
        Me.btnGeneraF = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnProcesar
        '
        Me.btnProcesar.Location = New System.Drawing.Point(247, 17)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(104, 23)
        Me.btnProcesar.TabIndex = 24
        Me.btnProcesar.Text = "Procesar"
        '
        'lblProceso
        '
        Me.lblProceso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProceso.Location = New System.Drawing.Point(26, 20)
        Me.lblProceso.Name = "lblProceso"
        Me.lblProceso.Size = New System.Drawing.Size(110, 16)
        Me.lblProceso.TabIndex = 23
        Me.lblProceso.Text = "Fecha de Proceso"
        '
        'dtpProceso
        '
        Me.dtpProceso.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpProceso.Location = New System.Drawing.Point(143, 18)
        Me.dtpProceso.Name = "dtpProceso"
        Me.dtpProceso.Size = New System.Drawing.Size(88, 20)
        Me.dtpProceso.TabIndex = 22
        '
        'btnGeneraF
        '
        Me.btnGeneraF.Location = New System.Drawing.Point(383, 17)
        Me.btnGeneraF.Name = "btnGeneraF"
        Me.btnGeneraF.Size = New System.Drawing.Size(104, 23)
        Me.btnGeneraF.TabIndex = 29
        Me.btnGeneraF.Text = "Generar Archivo"
        '
        'frmFisicas
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(504, 75)
        Me.Controls.Add(Me.btnGeneraF)
        Me.Controls.Add(Me.btnProcesar)
        Me.Controls.Add(Me.lblProceso)
        Me.Controls.Add(Me.dtpProceso)
        Me.Name = "frmFisicas"
        Me.Text = "Buró de Crédito Personas Físicas"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim cm4 As New SqlCommand()
        Dim cm5 As New SqlCommand()
        Dim cm6 As SqlCommand
        Dim dsAgil As New DataSet()
        Dim daAnexos As New SqlDataAdapter(cm1)
        Dim daEdoctav As New SqlDataAdapter(cm2)
        Dim daEdoctas As New SqlDataAdapter(cm3)
        Dim daEdoctao As New SqlDataAdapter(cm4)
        Dim daFacturas As New SqlDataAdapter(cm5)
        Dim drAnexo As DataRow
        Dim drEdoctav As DataRow()
        Dim drEdoctas As DataRow()
        Dim drEdoctao As DataRow()
        Dim drFactura As DataRow
        Dim drFacturas As DataRow()
        Dim relAnexoEdoctav As DataRelation
        Dim relAnexoEdoctas As DataRelation
        Dim relAnexoEdoctao As DataRelation
        Dim relAnexoFacturas As DataRelation
        Dim strDelete As String
        Dim strInsert As String

        ' Declaración de variables de datos

        Dim cAnexo As String
        Dim cApertura As String
        Dim cCalle As String
        Dim cCiudad As String
        Dim cCliente As String
        Dim cColonia As String
        Dim cCP As String
        Dim cCusnam As String
        Dim cDelega As String
        Dim cEstado As String
        Dim cFecha As String
        Dim cFechaFin As String
        Dim cFepag As String
        Dim cFeven As String
        Dim cFlcan As String
        Dim cIndPag As String
        Dim cMaterno As String
        Dim cPaterno As String
        Dim cTerConSaldo As String
        Dim cTermina As String
        Dim cMop As String
        Dim cNombre As String
        Dim cRFC As String
        Dim cUltPago As String
        Dim i As Integer
        Dim lReportar As Boolean
        Dim nCarteraEquipo As Decimal = 0
        Dim nCarteraSeguro As Decimal = 0
        Dim nCarteraOtros As Decimal = 0
        Dim nDias As Integer
        Dim nEspacios As Byte
        Dim nInteresEquipo As Decimal = 0
        Dim nInteresSeguro As Decimal = 0
        Dim nInteresOtros As Decimal = 0
        Dim nMoi As Decimal
        Dim nMop As Integer
        Dim nPlazo As Integer
        Dim nRenta As Decimal
        Dim nSaldoEquipo As Decimal = 0
        Dim nSaldoSeguro As Decimal = 0
        Dim nSaldoOtros As Decimal = 0
        Dim nSaldoFac As Decimal
        Dim nSaldPag As Decimal
        Dim nSaldVen As Decimal

        Dim newfrmPideNombre As frmPideNombre

        btnProcesar.Enabled = False
        dtpProceso.Enabled = False

        cFecha = DTOC(dtpProceso.Value)

        ' Este Stored Procedure regresa todos los contratos que no estén dados de baja,
        ' ni en suspenso y que hayan sido contratados hasta la fecha de proceso.  Trae
        ' exclusivamente los contratos de los clientes que sean Personas Físicas sin
        ' actividad empresarial.

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Fisicas1"
            .Connection = cnAgil
            .Parameters.Add("@Fecha", SqlDbType.NVarChar)
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

        ' Este Stored Procedure trae las facturas de los contratos activos o terminados
        ' con fecha de terminación mayor o igual al 1o. de enero de 2005, sin importar
        ' si están pagadas o no.

        With cm5
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Fisicas2"
            .Connection = cnAgil
        End With

        Try

            ' Llenar el DataSet a través del DataAdapter, lo cual abre y cierra la conexión

            daAnexos.Fill(dsAgil, "Anexos")
            daEdoctav.Fill(dsAgil, "Edoctav")
            daEdoctas.Fill(dsAgil, "Edoctas")
            daEdoctao.Fill(dsAgil, "Edoctao")
            daFacturas.Fill(dsAgil, "Facturas")

            ' Establecer la relación entre Anexos y Edoctav

            relAnexoEdoctav = New DataRelation("AnexoEdoctav", dsAgil.Tables("Anexos").Columns("Anexo"), dsAgil.Tables("Edoctav").Columns("Anexo"))

            ' Establecer la relación entre Anexos y Edoctas

            relAnexoEdoctas = New DataRelation("AnexoEdoctas", dsAgil.Tables("Anexos").Columns("Anexo"), dsAgil.Tables("Edoctas").Columns("Anexo"))

            ' Establecer la relación entre Anexos y Edoctao

            relAnexoEdoctao = New DataRelation("AnexoEdoctao", dsAgil.Tables("Anexos").Columns("Anexo"), dsAgil.Tables("Edoctao").Columns("Anexo"))

            ' Establecer la relación entre Anexos y Facturas

            relAnexoFacturas = New DataRelation("AnexoFacturas", dsAgil.Tables("Anexos").Columns("Anexo"), dsAgil.Tables("Facturas").Columns("Anexo"))

            dsAgil.EnforceConstraints = False
            dsAgil.Relations.Add(relAnexoEdoctav)
            dsAgil.Relations.Add(relAnexoEdoctas)
            dsAgil.Relations.Add(relAnexoEdoctao)
            dsAgil.Relations.Add(relAnexoFacturas)

            ' Ahora elimino todos los registros de la tabla Fisicas

            cnAgil.Open()
            strDelete = "DELETE FROM Fisicas"
            cm6 = New SqlClient.SqlCommand(strDelete, cnAgil)
            cm6.ExecuteNonQuery()
            cnAgil.Close()

            For Each drAnexo In dsAgil.Tables("Anexos").Rows

                cCusnam = Trim(drAnexo("Descr"))
                cCliente = Trim(drAnexo("Cli"))
                cNombre = Space(26)
                cPaterno = Space(26)
                cMaterno = Space(26)
                nEspacios = 0

                For i = 1 To Len(cCusnam)
                    If Mid(cCusnam, i, 1) = " " Then
                        nEspacios += 1
                    End If
                Next

                If nEspacios > 3 Then
                    newfrmPideNombre = New frmPideNombre("F", cCusnam, cCliente)
                    newfrmPideNombre.ShowDialog()
                    cNombre = newfrmPideNombre.Nombre
                    cPaterno = newfrmPideNombre.Paterno
                    cMaterno = newfrmPideNombre.Materno
                End If

                If nEspacios = 3 Then

                    cNombre = ""
                    i = 1
                    While Mid(cCusnam, i, 1) <> " "
                        cNombre += Mid(cCusnam, i, 1)
                        i += 1
                    End While
                    i += 1
                    cNombre += " "

                    While Mid(cCusnam, i, 1) <> " "
                        cNombre += Mid(cCusnam, i, 1)
                        i += 1
                    End While
                    i += 1

                    cPaterno = ""
                    While Mid(cCusnam, i, 1) <> " "
                        cPaterno += Mid(cCusnam, i, 1)
                        i += 1
                    End While
                    i += 1

                    cMaterno = ""
                    While i <= Len(cCusnam)
                        cMaterno += Mid(cCusnam, i, 1)
                        i += 1
                    End While

                    If Len(cPaterno) < 4 Then
                        nEspacios = 2
                    End If

                End If

                If nEspacios = 2 Then

                    cNombre = ""
                    i = 1
                    While Mid(cCusnam, i, 1) <> " "
                        cNombre += Mid(cCusnam, i, 1)
                        i += 1
                    End While
                    i += 1

                    cPaterno = ""
                    While Mid(cCusnam, i, 1) <> " "
                        cPaterno += Mid(cCusnam, i, 1)
                        i += 1
                    End While
                    i += 1

                    cMaterno = ""
                    While i <= Len(cCusnam)
                        cMaterno += Mid(cCusnam, i, 1)
                        i += 1
                    End While

                End If

                cAnexo = drAnexo("Anexo")
                cRFC = drAnexo("Rfc")
                cCalle = Mid(drAnexo("Calle"), 1, 40)
                cColonia = drAnexo("Colonia")
                cDelega = Mid(drAnexo("Delegacion"), 1, 40)
                cCiudad = drAnexo("DescPlaza")
                cEstado = drAnexo("Abreviado")
                cCP = drAnexo("Copos")
                nPlazo = drAnexo("Plazo")
                cFlcan = drAnexo("Flcan")
                cApertura = drAnexo("Fechacon")
                cTermina = DTOC(Termina(CTOD(drAnexo("Fvenc")), nPlazo))
                cFechaFin = drAnexo("Fechafin")
                If cFlcan = "A" Or cFlcan = "T" Then
                    If cTermina <= cFecha Then
                        cFechaFin = cTermina
                    End If
                    cUltPago = drAnexo("Fechacon")
                ElseIf cFlcan = "C" Then
                    cUltPago = cFechaFin
                End If
                nMoi = drAnexo("ImpEq") - drAnexo("IvaEq") - drAnexo("Amorin")
                nRenta = drAnexo("Mensu")
                If nRenta = 0 Then
                    nRenta = nMoi / nPlazo
                End If
                If cFlcan = "C" Then
                    nRenta = 0
                End If

                ' Cálculo del Saldo Insoluto del equipo, del Seguro y de Otros Adeudos

                nSaldoEquipo = 0
                nInteresEquipo = 0
                nCarteraEquipo = 0

                nSaldoSeguro = 0
                nInteresSeguro = 0
                nCarteraSeguro = 0

                nSaldoOtros = 0
                nInteresOtros = 0
                nCarteraOtros = 0

                ' Los contratos TER o CAN ya no tienen saldo insoluto ni de Equipo, ni de Seguro,
                ' ni de Otros Adeudos

                If cFlcan = "A" Then

                    ' Esta instrucción trae la tabla de amortización del Equipo única y exclusivamente del contrato
                    ' que está siendo procesado

                    drEdoctav = drAnexo.GetChildRows("AnexoEdoctav")
                    TraeSald(drEdoctav, cFecha, nSaldoEquipo, nInteresEquipo, nCarteraEquipo)

                    drEdoctas = drAnexo.GetChildRows("AnexoEdoctas")
                    TraeSald(drEdoctas, cFecha, nSaldoSeguro, nInteresSeguro, nCarteraSeguro)

                    drEdoctao = drAnexo.GetChildRows("AnexoEdoctao")
                    TraeSald(drEdoctao, cFecha, nSaldoOtros, nInteresOtros, nCarteraOtros)

                    nSaldoEquipo = Round(nSaldoEquipo + nSaldoSeguro + nSaldoOtros, 2)

                End If

                ' Ahora determino el saldo vencido de los contratos ACT o TER

                nSaldVen = 0
                nSaldPag = 0
                nMop = 0

                If cFlcan = "A" Or cFlcan = "T" Then

                    ' Esta instrucción trae las facturas única y exclusivamente del contrato
                    ' que está siendo procesado

                    drFacturas = drAnexo.GetChildRows("AnexoFacturas")

                    For Each drFactura In drFacturas

                        cFeven = drFactura("Feven")
                        cFepag = drFactura("Fepag")
                        cIndPag = drFactura("IndPag")
                        nSaldoFac = drFactura("SaldoFac")
                        nDias = 0

                        ' Solo considero facturas exigibles

                        If cFeven <= cFecha Then

                            ' Determino la fecha de último pago

                            If cFepag > cUltPago Then
                                cUltPago = cFepag
                            End If

                            ' Solo proceso facturas no pagadas (que tienen saldo)

                            If cIndPag <> "P" And nSaldoFac > 0 Then
                                nDias = DateDiff(DateInterval.Day, CTOD(cFeven), CTOD(cFecha))
                                If nDias > 0 Then
                                    If nMop = 0 Then
                                        nMop = nDias
                                    End If
                                    nSaldVen += nSaldoFac
                                    nSaldPag += 1
                                End If
                            End If

                        End If

                    Next

                End If

                If nSaldVen > nSaldoEquipo Then
                    nSaldoEquipo = nSaldVen
                End If

                cTerConSaldo = "N"
                lReportar = True

                If cFlcan = "T" Then

                    If nSaldVen > 0 Then

                        cTerConSaldo = "S"

                        ' Lo reporto NORMAL con saldo pero sin fechafin e igualo el pago mínimo,
                        ' el saldo actual, y el saldo vencido

                        cFechaFin = Space(8)

                        nSaldoEquipo = nSaldVen

                        If nSaldoEquipo > nMoi Then
                            nMoi = nSaldoEquipo
                        End If

                        nRenta = nSaldVen

                    ElseIf nSaldVen = 0 Then

                        ' Terminó y no tiene saldo vencido aunque pudo haber terminado con saldo
                        ' en algún mes anterior al actual

                        If cTermina <= cUltPago Then

                            ' Terminó con saldo pero ya no lo debe, por lo que ahora debo checar
                            ' cuándo pagó dicho adeudo ya que si lo pagó en el mes que se está
                            ' reportando, tengo que reportarlo como CERRADO en ceros; pero si lo
                            ' pagó en un mes anterior, lo más seguro es que ya lo haya reportado
                            ' anteriormente.

                            If Mid(cUltPago, 1, 6) = Mid(cFecha, 1, 6) Then

                                nSaldoEquipo = 0
                                nSaldVen = 0
                                nSaldPag = 0
                                nRenta = 0

                            Else

                                ' Significa que lo reporté anteriormente

                                lReportar = False

                            End If

                        Else

                            ' Significa que terminó sin saldo

                            lReportar = False

                        End If

                    End If

                End If

                If cFechaFin <> Space(8) And cUltPago > cFechaFin Then
                    cFechaFin = cUltPago
                End If

                If nMop <= 0 Then
                    cMop = "01"
                    nSaldVen = 0
                    nSaldPag = 0
                ElseIf nMop >= 1 And nMop < 30 Then
                    cMop = "02"
                ElseIf nMop >= 30 And nMop < 60 Then
                    cMop = "03"
                ElseIf nMop >= 60 And nMop < 90 Then
                    cMop = "04"
                ElseIf nMop >= 90 And nMop < 120 Then
                    cMop = "05"
                ElseIf nMop >= 120 And nMop < 150 Then
                    cMop = "06"
                ElseIf nMop >= 150 And nMop < 366 Then
                    cMop = "07"
                ElseIf nMop >= 366 Then
                    cMop = "96"
                End If

                If lReportar = True Then
                    strInsert = "INSERT INTO Fisicas(PNPaterno, PNMaterno, PNNombre, PNRfc, PACalle, PAColonia, PADelega, PACiudad, PAEstado, PACP, TLCuenCli, TLPlazo, TLRenta, TLApertura, TLUltPago, TLFechaFin, TLMoi, TLSaldAct, TLSaldVen, TLSaldPag, TLMop, Flcan, TerConSaldo)"
                    strInsert = strInsert & " VALUES ('"
                    strInsert = strInsert & cPaterno & "', '"
                    strInsert = strInsert & cMaterno & "', '"
                    strInsert = strInsert & cNombre & "', '"
                    strInsert = strInsert & cRFC & "', '"
                    strInsert = strInsert & cCalle & "', '"
                    strInsert = strInsert & cColonia & "', '"
                    strInsert = strInsert & cDelega & "', '"
                    strInsert = strInsert & cCiudad & "', '"
                    strInsert = strInsert & cEstado & "', '"
                    strInsert = strInsert & cCP & "', '"
                    strInsert = strInsert & Mid(cAnexo, 1, 5) & "-" & Mid(cAnexo, 6, 4) & "', '"
                    strInsert = strInsert & nPlazo.ToString & "', '"
                    strInsert = strInsert & Round(nRenta, 0).ToString & "', '"
                    strInsert = strInsert & Mid(cApertura, 7, 2) & Mid(cApertura, 5, 2) & Mid(cApertura, 1, 4) & "', '"
                    strInsert = strInsert & Mid(cUltPago, 7, 2) & Mid(cUltPago, 5, 2) & Mid(cUltPago, 1, 4) & "', '"
                    strInsert = strInsert & Mid(cFechaFin, 7, 2) & Mid(cFechaFin, 5, 2) & Mid(cFechaFin, 1, 4) & "', '"
                    strInsert = strInsert & Round(nMoi, 0).ToString & "', '"
                    strInsert = strInsert & Round(nSaldoEquipo, 0).ToString & "', '"
                    strInsert = strInsert & Round(nSaldVen, 0).ToString & "', '"
                    strInsert = strInsert & Round(nSaldPag, 0).ToString & "', '"
                    strInsert = strInsert & cMop & "', '"
                    strInsert = strInsert & cFlcan & "', '"
                    strInsert = strInsert & cTerConSaldo
                    strInsert = strInsert & "')"
                    cnAgil.Open()
                    cm1 = New SqlCommand(strInsert, cnAgil)
                    cm1.ExecuteNonQuery()
                    cnAgil.Close()
                End If

            Next

            ' Por último, inserto el registro correspondiente al Fraude de José Luis Cruz Medina

            strInsert = "INSERT INTO Fisicas(PNPaterno, PNMaterno, PNNombre, PNRfc, PACalle, PAColonia, PADelega, PACiudad, PAEstado, PACP, TLCuenCli, TLPlazo, TLRenta, TLApertura, TLUltPago, TLFechaFin, TLMoi, TLSaldAct, TLSaldVen, TLSaldPag, TLMop, Flcan, TerConSaldo)"
            strInsert = strInsert & " VALUES ('"
            strInsert = strInsert & "CRUZ" & "', '"
            strInsert = strInsert & "MEDINA" & "', '"
            strInsert = strInsert & "JOSE LUIS" & "', '"
            strInsert = strInsert & "CUML670427163" & "', '"
            strInsert = strInsert & "NARANJA # 47" & "', '"
            strInsert = strInsert & "IZCALLI TOLUCA" & "', '"
            strInsert = strInsert & "TOLUCA" & "', '"
            strInsert = strInsert & "ESTADO DE MEXICO" & "', '"
            strInsert = strInsert & "EM" & "', '"
            strInsert = strInsert & "50150" & "', '"
            strInsert = strInsert & "00896-0001" & "', '"
            strInsert = strInsert & "36" & "', '"
            strInsert = strInsert & "163718" & "', '"
            strInsert = strInsert & "11062001" & "', '"
            strInsert = strInsert & "30042002" & "', '"
            strInsert = strInsert & "        " & "', '"
            strInsert = strInsert & "163718" & "', '"
            strInsert = strInsert & "163718" & "', '"
            strInsert = strInsert & "163718" & "', '"
            strInsert = strInsert & "27" & "', '"
            strInsert = strInsert & "99" & "', '"
            strInsert = strInsert & "T" & "', '"
            strInsert = strInsert & "S"
            strInsert = strInsert & "')"
            cnAgil.Open()
            cm1 = New SqlCommand(strInsert, cnAgil)
            cm1.ExecuteNonQuery()
            cnAgil.Close()

        Catch eException As Exception

            MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")

        End Try

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()
        cm3.Dispose()
        cm4.Dispose()
        cm5.Dispose()
        cm6.Dispose()

        MsgBox("Proceso Terminado", MsgBoxStyle.Information, "Mensaje del Sistema")

    End Sub

    Private Sub btnGeneraF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGeneraF.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim dsAgil As New DataSet()
        Dim daFisicas As New SqlDataAdapter(cm1)
        Dim drFisica As DataRow

        ' Declaración de variables de datos

        Dim cCicloNumero As String = Space(2)
        Dim cClaveOtorgante As String = "LS16090001"
        Dim cFecha As String
        Dim cFechaReporte As String
        Dim cInformacionAdic As String = Space(98)
        Dim cLongitud As String
        Dim cNombreOtorgante As String = "FINAGIL         "
        Dim cString As String
        Dim cUsoFuturo As String = "0000000000"
        Dim nLongitud As Decimal
        Dim nRegistros As Decimal = 0
        Dim nSumaTLSaldAct As Decimal = 0
        Dim nSumaTLSaldVen As Decimal = 0
        Dim oReporte As StreamWriter

        cFecha = DTOC(dtpProceso.Value)

        cFechaReporte = Mid(cFecha, 7, 2) & Mid(cFecha, 5, 2) & Mid(cFecha, 1, 4)

        ' Este Stored Procedure regresa todos los registros que aparecen en la tabla Fisicas

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "GeneraF1"
            .Connection = cnAgil
        End With

        ' Llenar el DataSet a través del DataAdapter, lo cual abre y cierra la conexión

        daFisicas.Fill(dsAgil, "Fisicas")

        ' SEGMENTO DE ENCABEZADO

        cString = "INTF10" & cClaveOtorgante & cNombreOtorgante & cCicloNumero & cFechaReporte & cUsoFuturo & cInformacionAdic

        For Each drFisica In dsAgil.Tables("Fisicas").Rows

            ' SEGMENTO DE NOMBRE (PN)

            nLongitud = Len(Trim(drFisica("PNPaterno")))
            If nLongitud < 10 Then
                cLongitud = "0" + Trim(Str(nLongitud))
            Else
                cLongitud = Trim(Str(nLongitud))
            End If
            cString = cString & "PN" & cLongitud & Trim(drFisica("PNPaterno"))

            nLongitud = Len(Trim(drFisica("PNMaterno")))
            If nLongitud < 10 Then
                cLongitud = "0" + Trim(Str(nLongitud))
            Else
                cLongitud = Trim(Str(nLongitud))
            End If
            cString = cString & "00" & cLongitud & Trim(drFisica("PNMaterno"))

            nLongitud = Len(Trim(drFisica("PNNombre")))
            If nLongitud < 10 Then
                cLongitud = "0" + Trim(Str(nLongitud))
            Else
                cLongitud = Trim(Str(nLongitud))
            End If
            cString = cString & "02" & cLongitud & Trim(drFisica("PNNombre"))

            nLongitud = Len(Trim(drFisica("PNRfc")))
            If nLongitud < 10 Then
                cLongitud = "0" + Trim(Str(nLongitud))
            Else
                cLongitud = Trim(Str(nLongitud))
            End If
            cString = cString & "05" & cLongitud & Trim(drFisica("PNRfc"))

            ' SEGMENTO DE DIRECCION (PA)

            nLongitud = Len(Trim(drFisica("PACalle")))
            If nLongitud < 10 Then
                cLongitud = "0" + Trim(Str(nLongitud))
            Else
                cLongitud = Trim(Str(nLongitud))
            End If
            cString = cString & "PA" & cLongitud & Trim(drFisica("PACalle"))

            nLongitud = Len(Trim(drFisica("PAColonia")))
            If nLongitud < 10 Then
                cLongitud = "0" + Trim(Str(nLongitud))
            Else
                cLongitud = Trim(Str(nLongitud))
            End If
            cString = cString & "01" & cLongitud & Trim(drFisica("PAColonia"))

            nLongitud = Len(Trim(drFisica("PADelega")))
            If nLongitud < 10 Then
                cLongitud = "0" + Trim(Str(nLongitud))
            Else
                cLongitud = Trim(Str(nLongitud))
            End If
            cString = cString & "02" & cLongitud & Trim(drFisica("PADelega"))

            nLongitud = Len(Trim(drFisica("PACiudad")))
            If nLongitud < 10 Then
                cLongitud = "0" + Trim(Str(nLongitud))
            Else
                cLongitud = Trim(Str(nLongitud))
            End If
            cString = cString & "03" & cLongitud & Trim(drFisica("PACiudad"))

            nLongitud = Len(Trim(drFisica("PAEstado")))
            If nLongitud < 10 Then
                cLongitud = "0" + Trim(Str(nLongitud))
            Else
                cLongitud = Trim(Str(nLongitud))
            End If
            cString = cString & "04" & cLongitud & Trim(drFisica("PAEstado"))

            cString = cString & "0505" + Trim(drFisica("PACp"))

            ' SEGMENTO DE CUENTAS (TL)

            cString = cString & "TL" & "02" & "TL" & "01" & "10" & cClaveOtorgante

            nLongitud = Len(Trim(cNombreOtorgante))
            If nLongitud < 10 Then
                cLongitud = "0" + Trim(Str(nLongitud))
            Else
                cLongitud = Trim(Str(nLongitud))
            End If
            cString = cString & "02" & cLongitud & Trim(cNombreOtorgante)

            cString = cString & "04" & "10" & drFisica("TLCuenCli")
            cString = cString & "05" & "01" & "I"
            cString = cString & "06" & "01" & "I"
            cString = cString & "07" & "02" & "LS"
            cString = cString & "08" & "02" & "MX"

            nLongitud = Len(Trim(drFisica("TLPlazo")))
            If nLongitud < 10 Then
                cLongitud = "0" + Trim(Str(nLongitud))
            Else
                cLongitud = Trim(Str(nLongitud))
            End If
            cString = cString & "10" & cLongitud & Trim(drFisica("TLPlazo"))

            cString = cString & "11" & "01" & "M"

            nLongitud = Len(Trim(drFisica("TLRenta")))
            If nLongitud < 10 Then
                cLongitud = "0" + Trim(Str(nLongitud))
            Else
                cLongitud = Trim(Str(nLongitud))
            End If
            cString = cString & "12" & cLongitud & Trim(drFisica("TLRenta"))

            cString = cString & "13" & "08" & drFisica("TLApertura")

            cString = cString & "14" & "08" & drFisica("TLUltpago")

            If drFisica("TLFechaFin") <> Space(8) Then
                cString = cString & "16" & "08" & drFisica("TLFechaFin")
            End If

            nLongitud = Len(Trim(drFisica("TLMoi")))
            If nLongitud < 10 Then
                cLongitud = "0" + Trim(Str(nLongitud))
            Else
                cLongitud = Trim(Str(nLongitud))
            End If
            cString = cString & "21" & cLongitud & Trim(drFisica("TLMoi"))

            nLongitud = Len(Trim(drFisica("TLSaldAct")))
            If nLongitud < 10 Then
                cLongitud = "0" + Trim(Str(nLongitud))
            Else
                cLongitud = Trim(Str(nLongitud))
            End If
            cString = cString & "22" & cLongitud & Trim(drFisica("TLSaldAct"))

            nSumaTLSaldAct += CDbl(Trim(drFisica("TLSaldAct")))

            ' El número de pagos vencidos así como su monto solo se especifican para las cuentas con atraso

            If drFisica("TLMop") <> "01" Then

                nLongitud = Len(Trim(drFisica("TLSaldVen")))
                If nLongitud < 10 Then
                    cLongitud = "0" + Trim(Str(nLongitud))
                Else
                    cLongitud = Trim(Str(nLongitud))
                End If
                cString = cString & "24" & cLongitud & Trim(drFisica("TLSaldVen"))

                nSumaTLSaldVen += CDbl(Trim(drFisica("TLSaldVen")))

                nLongitud = Len(Trim(drFisica("TLSaldPag")))
                If nLongitud < 10 Then
                    cLongitud = "0" + Trim(Str(nLongitud))
                Else
                    cLongitud = Trim(Str(nLongitud))
                End If
                cString = cString & "25" & cLongitud & Trim(drFisica("TLSaldPag"))

            End If

            cString = cString & "26" & "02" & Trim(drFisica("TLMop"))

            If Trim(drFisica("TLObservacion")) <> "" Then
                cString = cString & "30" & "02" & Trim(drFisica("TLObservacion"))
            End If

            cString = cString & "99" & "03" & "END"

        Next

        nRegistros = dsAgil.Tables("Fisicas").Rows.Count

        ' SEGMENTO DE CIFRAS DE CONTROL (TR)

        cString = cString & "TRLR"
        cString = cString & Stuff(nSumaTLSaldAct.ToString, "I", "0", 14)
        cString = cString & Stuff(nSumaTLSaldVen.ToString, "I", "0", 14)
        cString = cString & "001"
        cString = cString & Stuff(nRegistros.ToString, "I", "0", 9)
        cString = cString & Stuff(nRegistros.ToString, "I", "0", 9)
        cString = cString & "000000000"
        cString = cString & Stuff(nRegistros.ToString, "I", "0", 9)
        cString = cString & "000000"
        cString = cString & Stuff("AGIL", "D", " ", 16)
        cString = cString & Stuff("LEANDRO VALLE 402 1er. PISO, COL. REFORMA Y FFCCNN, C.P. 50070, TOLUCA, ESTADO DE MEXICO", "D", " ", 160)

        oReporte = New StreamWriter("C:\FISICAS.TXT")
        Dim textAscii As New ASCIIEncoding()
        Dim encodedBytes As Byte() = textAscii.GetBytes(cString)
        Dim decodedString As String = textAscii.GetString(encodedBytes)
        oReporte.WriteLine(decodedString)
        oReporte.Close()

        cnAgil.Dispose()
        cm1.Dispose()

        MsgBox("Recuerda cambiar ? por Ñ", MsgBoxStyle.Information, "Mensaje del Sistema")

    End Sub

End Class
