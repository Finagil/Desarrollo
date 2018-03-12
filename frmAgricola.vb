Option Explicit On

Imports System.Data.SqlClient
Imports System.Math
Imports Microsoft.VisualBasic
Imports System.Security
Imports System.Security.Principal.WindowsIdentity

Public Class frmAgricola

    ' Declaración de variables de conexión ADO .NET de alcance privado

    Dim cnAgil As New SqlConnection(strConn)
    Dim dtPagares As New DataTable
    Dim dtFIRA As New DataTable
    Dim dtFINAGIL As New DataTable
    Dim myKeySearch(0) As String

    ' Declaración de variables de datos de alcance privado

    Dim cAnexo As String = ""
    Dim cCiclo As String = ""
    Dim lInsertFINAGIL As Boolean
    Dim lInsertFIRA As Boolean
    Dim lUpdateFINAGIL As Boolean
    Dim lUpdateFIRA As Boolean
    Dim nImporteAnterior As Decimal = 0
    Dim nMinistradoFIRA As Decimal = 0
    Dim nMinistradoFINAGIL As Decimal = 0
    Dim nRowsFINAGIL As Byte
    Dim nRowsFIRA As Byte
    Dim nRegistroFINAGIL As Byte
    Dim nRegistroFIRA As Byte

    Dim lFirstTime As Boolean = True
    Dim myIdentity As Principal.WindowsIdentity
    Dim cUsuario As String

    Public Sub New(ByVal cLinea As String)

        MyBase.New()

        'This call is required by the Windows Form Designer.

        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        cAnexo = Mid(cLinea, 1, 10)

        If Mid(cLinea, 12, 6) = "PAGARE" Then
            Me.Text = "Control de Ministraciones del Crédito en Cuenta Corriente " & cAnexo
        Else
            Me.Text = "Control de Ministraciones del Contrato de Avío " & cAnexo
        End If

        lblAnexo.Text = cAnexo
        txtCiclo.Text = Mid(cLinea, 12, 47)

        cAnexo = Mid(lblAnexo.Text, 1, 5) & Mid(lblAnexo.Text, 7, 4)
        If Mid(cLinea, 12, 6) = "PAGARE" Then
            cCiclo = Mid(cLinea, 19, 2)
        Else
            cCiclo = Mid(cLinea, 18, 2)
        End If

    End Sub

    Private Sub frmAgricola_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim cm4 As New SqlCommand()
        Dim daAvio As New SqlDataAdapter(cm1)
        Dim daFIRA As New SqlDataAdapter(cm2)
        Dim daFINAGIL As New SqlDataAdapter(cm3)
        Dim daPagares As New SqlDataAdapter(cm4)

        Dim dsAgil As New DataSet()
        Dim drAvio As DataRow
        Dim drPagare As DataRow
        Dim drMinistracion As DataRow
        Dim drAux As DataRow
        Dim myColArray(0) As DataColumn

        ' Declaración de variables de datos

        Dim cFlcan As String = ""
        Dim cNombreProductor As String = ""
        Dim i As Byte
        Dim nRendimiento As Decimal = 0
        Dim nVariacion As Decimal = 0
        Dim nSumaPagares As Decimal = 0

        myIdentity = GetCurrent()
        cUsuario = myIdentity.Name


        ' Aquí tengo que validar si se trata de un Contrato Terminado en cuyo caso solo se podrá
        ' consultar la información de las ministraciones otorgadas sin opción a modificar nada


        ' El siguiente Command trae los datos del contrato de Habilitación o Avío

        With cm1
            .CommandType = CommandType.Text
            .CommandText = "SELECT Avios.*, Descr, Banco, CuentaBancomer, CuentaCLABE FROM Avios " & _
                           "INNER JOIN Clientes ON Avios.Cliente = Clientes.Cliente " & _
                           "WHERE Anexo = " & "'" & cAnexo & "' AND Ciclo = '" & cCiclo & "'"
            .Connection = cnAgil
        End With

        ' El siguiente Command trae los datos de las ministraciones FIRA - FINAGIL

        With cm2
            .CommandType = CommandType.Text
            .CommandText = "SELECT * FROM mFIRA " & _
                           "WHERE Anexo = '" & cAnexo & "' AND Ciclo = '" & cCiclo & "' " & _
                           "ORDER BY Ministracion"
            .Connection = cnAgil
        End With

        ' El siguiente Command trae los datos de las ministraciones FINAGIL - Productor

        With cm3
            .CommandType = CommandType.Text
            .CommandText = "SELECT * FROM mFINAGIL " & _
                           "WHERE Anexo = '" & cAnexo & "' AND Ciclo = '" & cCiclo & "' " & _
                           "ORDER BY Ministracion"
            .Connection = cnAgil
        End With

        ' El siguiente Command trae los datos de los pagarés firmados por el Productor

        With cm4
            .CommandType = CommandType.Text
            .CommandText = "SELECT * FROM PagaresAvio " & _
                           "WHERE Anexo = '" & cAnexo & "' AND Ciclo = '" & cCiclo & "' " & _
                           "ORDER BY Numero"
            .Connection = cnAgil
        End With

        nMinistradoFIRA = 0
        nMinistradoFINAGIL = 0

        cbFEGA.Items.Add("NO")
        cbFEGA.Items.Add("SI")

        cbEstado.Items.Add("PENDIENTE")
        cbEstado.Items.Add("OTORGADO")

        btnModificarFIRA.Visible = False
        panelFIRA.Visible = False

        If cUsuario = "AGIL\marisol-gutierrez" Or cUsuario = "AGIL\abraham-torres" Then
            cbDocumento.Items.Add("EFECTIVO")
            GroupBox3.Visible = False
        ElseIf cUsuario = "AGIL\laura-mercado" Or cUsuario = "AGIL\avelina-rojas" Then
            cbDocumento.Items.Add("EFECTIVO")
            cbDocumento.Items.Add("VALE")
            cbDocumento.Items.Add("RECIBO")
            cbDocumento.Items.Add("BURO")
            cbDocumento.Items.Add("NOTARIO")
            cbDocumento.Items.Add("RPP")
            cbDocumento.Items.Add("GASTOS")
            cbDocumento.Items.Add("ASISTENCIA")
            cbDocumento.Items.Add("SEGURO")
            cbDocumento.Items.Add("REEMBOLSO")
            cbDocumento.Items.Add("INTEGRACION")
            cbDocumento.Items.Add("COMISION")
            cbDocumento.Items.Add("ANALISIS DE SUELOS")
            cbDocumento.Items.Add("IVA")
            cbDocumento.Items.Add("AVALUO")
            cbDocumento.Items.Add("COBERTURA")
        ElseIf cUsuario = "AGIL\yenni-hernandez" Or cUsuario = "AGIL\janeth-ibarra" Or cUsuario = "AGIL\iris-elizalde" Then
            GroupBox3.Visible = False
            cbDocumento.Items.Add("NOTARIO")
            cbDocumento.Items.Add("RPP")
        Else
            cbDocumento.Items.Add("VALE")
            cbDocumento.Items.Add("RECIBO")
            cbDocumento.Items.Add("BURO")
            cbDocumento.Items.Add("GASTOS")
            cbDocumento.Items.Add("ASISTENCIA")
            cbDocumento.Items.Add("SEGURO")
            cbDocumento.Items.Add("REEMBOLSO")
            cbDocumento.Items.Add("INTEGRACION")
            cbDocumento.Items.Add("COMISION")
            cbDocumento.Items.Add("ANALISIS DE SUELOS")
            cbDocumento.Items.Add("IVA")
            cbDocumento.Items.Add("AVALUO")
            cbDocumento.Items.Add("COBERTURA")
        End If

        btnModificarFINAGIL.Visible = False
        panelFINAGIL.Visible = False

        ' Llenar el dataset lo cual abre y cierra la conexión

        daAvio.Fill(dsAgil, "Avios")
        daFIRA.Fill(dsAgil, "FIRA")
        daFINAGIL.Fill(dsAgil, "FINAGIL")
        daPagares.Fill(dsAgil, "Pagares")

        ' Información del contrato de habilitación o avío

        drAvio = dsAgil.Tables("Avios").Rows(0)

        cFlcan = drAvio("Flcan")
        cNombreProductor = Trim(Mid(drAvio("Descr"), 1, 80))

        lblAnexo.Text = lblAnexo.Text & "   " & cNombreProductor

        txtLineaAutorizada.Text = Format(drAvio("LineaActual"), "##,##0.00")
        txtHectareasActual.Text = Format(drAvio("HectareasActual"), "##,##0.00")
        txtBanco.Text = Trim(drAvio("Banco"))
        txtCuentaBancomer.Text = drAvio("CuentaBancomer")
        txtCuentaCLABE.Text = drAvio("CuentaCLABE")

        If cFlcan <> "A" Then

            btnInsertarFIRA.Enabled = False
            btnModificarFIRA.Enabled = False
            panelFIRA.Enabled = False

            btnInsertarFINAGIL.Enabled = False
            btnModificarFINAGIL.Enabled = False
            panelFINAGIL.Enabled = False

        End If

        ' Crear la tabla que contendrá la información de las ministraciones FINAGIL - Productor

        dtFINAGIL.Columns.Add("No.", Type.GetType("System.Decimal"))
        dtFINAGIL.Columns.Add("Documento", Type.GetType("System.String"))
        dtFINAGIL.Columns.Add("Fecha de Pago", Type.GetType("System.String"))
        dtFINAGIL.Columns.Add("Importe", Type.GetType("System.String"))
        dtFINAGIL.Columns.Add("Garantia", Type.GetType("System.String"))

        ' Tengo que definir una llave primaria para la tabla dtFINAGIL a fin de buscar un registro cuando desee actualizarlo

        myColArray(0) = dtFINAGIL.Columns("No.")
        dtFINAGIL.PrimaryKey = myColArray

        ' Crear la tabla que contendrá la información de los pagarés firmados por el Productor

        dtPagares.Columns.Add("No.", Type.GetType("System.Decimal"))
        dtPagares.Columns.Add("Fecha Pagaré", Type.GetType("System.String"))
        dtPagares.Columns.Add("Importe", Type.GetType("System.String"))
        dtPagares.Columns.Add("Garantia", Type.GetType("System.String"))

        ' Crear la tabla que contendrá la información de las ministraciones FIRA - FINAGIL

        dtFIRA.Columns.Add("No.", Type.GetType("System.Decimal"))
        dtFIRA.Columns.Add("Fecha Programada", Type.GetType("System.String"))
        dtFIRA.Columns.Add("Importe", Type.GetType("System.String"))
        dtFIRA.Columns.Add("FEGA", Type.GetType("System.String"))
        dtFIRA.Columns.Add("Estado", Type.GetType("System.String"))

        ' Tengo que definir una llave primaria para la tabla dtFIRA a fin de buscar un registro cuando desee actualizarlo

        myColArray(0) = dtFIRA.Columns("No.")
        dtFIRA.PrimaryKey = myColArray


        ' Información de las ministraciones FINAGIL - Productor

        dtFINAGIL.Clear()
        nRowsFINAGIL = dsAgil.Tables("FINAGIL").Rows.Count()

        If nRowsFINAGIL > 0 Then
            btnModificarFINAGIL.Visible = True
        End If

        For Each drMinistracion In dsAgil.Tables("FINAGIL").Rows
            drAux = dtFINAGIL.NewRow()
            drAux("No.") = drMinistracion("Ministracion")
            drAux("Documento") = drMinistracion("Documento")
            If Trim(drMinistracion("FechaPago")) <> "" Then
                drAux("Fecha de Pago") = Mid(drMinistracion("FechaPago"), 7, 2) & "/" & Mid(drMinistracion("FechaPago"), 5, 2) & "/" & Mid(drMinistracion("FechaPago"), 1, 4)
            Else
                drAux("Fecha de Pago") = ""
            End If
            drAux("Importe") = Format(drMinistracion("Importe"), "##,##0.00")
            drAux("Garantia") = Format(drMinistracion("Garantia"), "##,##0.00")
            dtFINAGIL.Rows.Add(drAux)
            nMinistradoFINAGIL = nMinistradoFINAGIL + drMinistracion("Importe")
        Next

        If nMinistradoFINAGIL > 0 Then
            lblMinistradoFINAGIL.Text = "Total Ministrado por FINAGIL al Productor $" & Format(nMinistradoFINAGIL, "##,##0.00")
        Else
            lblMinistradoFINAGIL.Text = ""
        End If

        dgvFINAGIL.DataSource = dtFINAGIL
        dgvFINAGIL.Columns(0).Width = 25
        dgvFINAGIL.Columns(1).Width = 80
        dgvFINAGIL.Columns(2).Width = 120
        dgvFINAGIL.Columns(3).Width = 100
        dgvFINAGIL.Columns(4).Width = 100

        For i = 0 To dgvFINAGIL.Columns.Count - 1
            dgvFINAGIL.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            If i = 0 Or i = 2 Then
                dgvFINAGIL.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alinea el encabezado
                dgvFINAGIL.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alinea el contenido
            ElseIf i = 1 Then
                dgvFINAGIL.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft ' Alinea el encabezado
                dgvFINAGIL.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft ' Alinea el contenido
            ElseIf i = 3 Or i = 4 Then
                dgvFINAGIL.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight ' Alinea el encabezado
                dgvFINAGIL.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alinea el contenido
            End If
        Next

        With dgvFINAGIL
            .BackColor = Color.GhostWhite
            .BackgroundColor = Color.Lavender
            .BorderStyle = BorderStyle.None
            .Font = New Font("Tahoma", 8.0!)
            .ForeColor = Color.MidnightBlue
        End With


        ' Información de los pagarés firmados por el Productor

        dtPagares.Clear()

        For Each drPagare In dsAgil.Tables("Pagares").Rows
            drAux = dtPagares.NewRow()
            drAux("No.") = drPagare("Numero")
            If drPagare("FechaPagare") <> "" Then
                drAux("Fecha Pagaré") = Mid(drPagare("FechaPagare"), 7, 2) & "/" & Mid(drPagare("FechaPagare"), 5, 2) & "/" & Mid(drPagare("FechaPagare"), 1, 4)
            Else
                drAux("Fecha Pagaré") = ""
            End If
            drAux("Importe") = Format(drPagare("Importe"), "##,##0.00")
            drAux("Garantia") = Format(drPagare("Garantia"), "##,##0.00")
            dtPagares.Rows.Add(drAux)
            nSumaPagares = nSumaPagares + drPagare("Importe")
        Next

        If nSumaPagares > 0 Then
            lblSumaPagares.Text = "Suma de los pagarés capturados $" & Format(nSumaPagares, "##,##0.00")
        Else
            lblSumaPagares.Text = ""
        End If

        dgvPagares.DataSource = dtPagares
        dgvPagares.Columns(0).Width = 25
        dgvPagares.Columns(1).Width = 120
        dgvPagares.Columns(2).Width = 100
        dgvPagares.Columns(3).Width = 100

        For i = 0 To dgvPagares.Columns.Count - 1
            dgvPagares.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            If i = 0 Or i = 1 Then
                dgvPagares.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alinea el encabezado
                dgvPagares.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alinea el contenido
            ElseIf i = 2 Or i = 3 Then
                dgvPagares.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight ' Alinea el encabezado
                dgvPagares.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alinea el contenido
            End If
        Next

        With dgvPagares
            .BackColor = Color.GhostWhite
            .BackgroundColor = Color.Lavender
            .BorderStyle = BorderStyle.None
            .Font = New Font("Tahoma", 8.0!)
            .ForeColor = Color.MidnightBlue
        End With

        ' Información de las ministraciones FIRA - FINAGIL

        dtFIRA.Clear()
        nRowsFIRA = dsAgil.Tables("FIRA").Rows.Count()

        If nRowsFIRA > 0 Then
            btnModificarFIRA.Visible = True
        End If

        For Each drMinistracion In dsAgil.Tables("FIRA").Rows
            drAux = dtFIRA.NewRow()
            drAux("No.") = drMinistracion("Ministracion")
            If drMinistracion("FechaProgramada") <> "" Then
                drAux("Fecha Programada") = Mid(drMinistracion("FechaProgramada"), 7, 2) & "/" & Mid(drMinistracion("FechaProgramada"), 5, 2) & "/" & Mid(drMinistracion("FechaProgramada"), 1, 4)
            Else
                drAux("Fecha Programada") = ""
            End If
            drAux("Importe") = Format(drMinistracion("Importe"), "##,##0.00")
            drAux("FEGA") = drMinistracion("Fega")
            drAux("Estado") = drMinistracion("Estado")
            dtFIRA.Rows.Add(drAux)
            nMinistradoFIRA = nMinistradoFIRA + drMinistracion("Importe")
        Next

        If nMinistradoFIRA > 0 Then
            lblMinistradoFIRA.Text = "Total Ministrado por FIRA a FINAGIL $" & Format(nMinistradoFIRA, "##,##0.00")
        Else
            lblMinistradoFIRA.Text = ""
        End If

        dgvFIRA.DataSource = dtFIRA
        dgvFIRA.Columns(0).Width = 25
        dgvFIRA.Columns(1).Width = 120
        dgvFIRA.Columns(2).Width = 100
        dgvFIRA.Columns(3).Width = 50
        dgvFIRA.Columns(4).Width = 80

        For i = 0 To dgvFIRA.Columns.Count - 1
            dgvFIRA.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            If i = 0 Or i = 1 Or i = 3 Then
                dgvFIRA.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alinea el encabezado
                dgvFIRA.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alinea el contenido
            ElseIf i = 2 Then
                dgvFIRA.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight ' Alinea el encabezado
                dgvFIRA.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' Alinea el contenido
            End If
        Next

        With dgvFIRA
            .BackColor = Color.GhostWhite
            .BackgroundColor = Color.Lavender
            .BorderStyle = BorderStyle.None
            .Font = New Font("Tahoma", 8.0!)
            .ForeColor = Color.MidnightBlue
        End With

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()
        cm3.Dispose()
        cm4.Dispose()

    End Sub

    Private Sub btnInsertarFINAGIL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertarFINAGIL.Click

        panelFINAGIL.Visible = True
        btnInsertarFINAGIL.Enabled = False
        If btnModificarFINAGIL.Visible = True Then
            btnModificarFINAGIL.Enabled = False
        End If
        txtImporteFINAGIL.Text = ""
        cbDocumento.SelectedIndex = 0
        lInsertFINAGIL = True
        lUpdateFINAGIL = False

    End Sub

    Private Sub btnInsertarFIRA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertarFIRA.Click

        panelFIRA.Visible = True
        btnInsertarFIRA.Enabled = False
        If btnModificarFIRA.Visible = True Then
            btnModificarFIRA.Enabled = False
        End If
        txtImporteFIRA.Text = ""
        cbFEGA.SelectedIndex = 0
        cbEstado.SelectedIndex = 0
        lInsertFIRA = True
        lUpdateFIRA = False

    End Sub

    Private Sub btnModificarFINAGIL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificarFINAGIL.Click

        If Not IsDBNull(dgvFINAGIL.Item(2, dgvFINAGIL.CurrentRow.Index).Value) Then

            MsgBox("No se puede modificar una ministración pagada", MsgBoxStyle.Critical, "Mensaje del Sistema")

        Else

            panelFINAGIL.Visible = True
            btnInsertarFINAGIL.Enabled = False
            btnModificarFINAGIL.Enabled = False

            ' Tengo que leer la información del registro del Grid sobre el cual esté posicionado para mostrarla
            ' y poder corregirla

            nRegistroFINAGIL = dgvFINAGIL.Item(0, dgvFINAGIL.CurrentRow.Index).Value
            cbDocumento.SelectedItem = RTrim(dgvFINAGIL.Item(1, dgvFINAGIL.CurrentRow.Index).Value)
            txtImporteFINAGIL.Text = dgvFINAGIL.Item(3, dgvFINAGIL.CurrentRow.Index).Value

            lInsertFINAGIL = False
            lUpdateFINAGIL = True

        End If

    End Sub

    Private Sub btnModificarFIRA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificarFIRA.Click

        panelFIRA.Visible = True
        btnInsertarFIRA.Enabled = False
        btnModificarFIRA.Enabled = False

        ' Tengo que leer la información del registro del Grid sobre el cual esté posicionado para mostrarla y poder corregirla

        nRegistroFIRA = dgvFIRA.Item(0, dgvFIRA.CurrentRow.Index).Value
        dtpFechaFIRA.Value = dgvFIRA.Item(1, dgvFIRA.CurrentRow.Index).Value
        txtImporteFIRA.Text = dgvFIRA.Item(2, dgvFIRA.CurrentRow.Index).Value
        cbFEGA.SelectedItem = dgvFIRA.Item(3, dgvFIRA.CurrentRow.Index).Value
        cbEstado.SelectedItem = RTrim(dgvFIRA.Item(4, dgvFIRA.CurrentRow.Index).Value)

        lInsertFIRA = False
        lUpdateFIRA = True

    End Sub

    Private Sub btnGuardarFINAGIL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarFINAGIL.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cm1 As New SqlCommand()
        Dim drTemporal As DataRow
        Dim strInsert As String
        Dim strUpdate As String

        ' Declaración de variables de datos

        Dim cFechaAlta As String = DTOC(Now())
        Dim nGarantia As Decimal = 0

        If nMinistradoFINAGIL > txtLineaAutorizada.Text Then

            MsgBox("Con esta Ministración Excedería su Línea de Crédito", MsgBoxStyle.Critical, "Mensaje del Sistema")

        Else

            ' Falta validar que se haya capturado información

            nGarantia = Round(CDbl(txtImporteFINAGIL.Text) * 0.1, 2)

            If lInsertFINAGIL = True Then

                nRowsFINAGIL = nRowsFINAGIL + 1

                strInsert = "INSERT INTO mFINAGIL (Anexo, Ciclo, Ministracion, Importe, Garantia, Documento, FechaAlta, SaldoMinistracion, SaldoGarantia, UltimoPago)"
                strInsert = strInsert & " VALUES ('"
                strInsert = strInsert & cAnexo & "', '"
                strInsert = strInsert & cCiclo & "', '"
                strInsert = strInsert & nRowsFINAGIL & "', "
                strInsert = strInsert & txtImporteFINAGIL.Text & ", "
                strInsert = strInsert & nGarantia & ", '"
                strInsert = strInsert & cbDocumento.SelectedItem & "', '"
                strInsert = strInsert & cFechaAlta & "', "
                strInsert = strInsert & txtImporteFINAGIL.Text & ", "
                strInsert = strInsert & nGarantia & ", '')"
                Try
                    cm1 = New SqlCommand(strInsert, cnAgil)
                    cnAgil.Open()
                    cm1.ExecuteNonQuery()
                    cnAgil.Close()
                Catch eException As Exception
                    MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")
                End Try

                drTemporal = dtFINAGIL.NewRow()
                drTemporal("No.") = nRowsFINAGIL
                drTemporal("Importe") = Format(CDbl(txtImporteFINAGIL.Text), "##,##0.00")
                drTemporal("Garantia") = Format(nGarantia, "##,##0.00")
                drTemporal("Documento") = cbDocumento.SelectedItem
                dtFINAGIL.Rows.Add(drTemporal)

                nMinistradoFINAGIL = nMinistradoFINAGIL + CDbl(txtImporteFINAGIL.Text)
                lblMinistradoFINAGIL.Text = "Total Ministrado por FINAGIL al Productor $" & Format(nMinistradoFINAGIL, "##,##0.00")

            ElseIf lUpdateFINAGIL = True Then

                strUpdate = "UPDATE mFINAGIL SET Importe = " & CDbl(txtImporteFINAGIL.Text) & ", "
                strUpdate = strUpdate & "Garantia = " & nGarantia & ", "
                strUpdate = strUpdate & "SaldoMinistracion = " & CDbl(txtImporteFINAGIL.Text) & ", "
                strUpdate = strUpdate & "SaldoGarantia = " & nGarantia & ", "
                strUpdate = strUpdate & "Documento = '" & cbDocumento.SelectedItem & "' "
                strUpdate = strUpdate & "WHERE Anexo = '" & cAnexo & "' "
                strUpdate = strUpdate & "AND Ciclo = '" & cCiclo & "' "
                strUpdate = strUpdate & "AND Ministracion = " & nRegistroFINAGIL
                Try
                    cm1 = New SqlCommand(strUpdate, cnAgil)
                    cnAgil.Open()
                    cm1.ExecuteNonQuery()
                    cnAgil.Close()
                Catch eException As Exception
                    MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")
                End Try

                myKeySearch(0) = nRegistroFINAGIL
                drTemporal = dtFINAGIL.Rows.Find(myKeySearch)
                nImporteAnterior = drTemporal("Importe")
                drTemporal("Importe") = Format(CDbl(txtImporteFINAGIL.Text), "##,##0.00")
                drTemporal("Garantia") = Format(nGarantia, "##,##0.00")
                drTemporal("Documento") = cbDocumento.SelectedItem

                nMinistradoFINAGIL = nMinistradoFINAGIL - nImporteAnterior + CDbl(txtImporteFINAGIL.Text)
                lblMinistradoFINAGIL.Text = "Total Ministrado por FINAGIL al Productor $" & Format(nMinistradoFINAGIL, "##,##0.00")

            End If

            cm1.Dispose()

            panelFINAGIL.Visible = False
            btnInsertarFINAGIL.Enabled = True
            If btnModificarFINAGIL.Visible = False Then
                btnModificarFINAGIL.Visible = True
            End If
            If btnModificarFINAGIL.Visible = True Then
                btnModificarFINAGIL.Enabled = True
            End If

            dgvFINAGIL.Refresh()

        End If

    End Sub

    Private Sub btnGuardarFIRA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarFIRA.Click

        Dim cm1 As New SqlCommand()
        Dim drTemporal As DataRow
        Dim strInsert As String
        Dim strUpdate As String

        ' Falta validar que se haya capturado información

        ' Lo primero que tengo que revisar es si se trata de una inserción o una actualización

        If lInsertFIRA = True Then

            nRowsFIRA = nRowsFIRA + 1

            strInsert = "INSERT INTO mFIRA (Anexo, Ciclo, Ministracion, FechaProgramada, Importe, Fega, Estado)"
            strInsert = strInsert & " VALUES ('"
            strInsert = strInsert & cAnexo & "', '"
            strInsert = strInsert & cCiclo & "', '"
            strInsert = strInsert & nRowsFIRA & "', '"
            strInsert = strInsert & DTOC(dtpFechaFIRA.Value) & "', '"
            strInsert = strInsert & txtImporteFIRA.Text & "', '"
            strInsert = strInsert & cbFEGA.SelectedItem & "', '"
            strInsert = strInsert & cbEstado.SelectedItem
            strInsert = strInsert & "')"
            Try
                cm1 = New SqlCommand(strInsert, cnAgil)
                cnAgil.Open()
                cm1.ExecuteNonQuery()
                cnAgil.Close()
            Catch eException As Exception
                MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")
            End Try

            drTemporal = dtFIRA.NewRow()
            drTemporal("No.") = nRowsFIRA
            drTemporal("Fecha Programada") = Mid(DTOC(dtpFechaFIRA.Value), 7, 2) & "/" & Mid(DTOC(dtpFechaFIRA.Value), 5, 2) & "/" & Mid(DTOC(dtpFechaFIRA.Value), 1, 4)
            drTemporal("Importe") = Format(CDbl(txtImporteFIRA.Text), "##,##0.00")
            drTemporal("FEGA") = cbFEGA.SelectedItem
            drTemporal("Estado") = cbEstado.SelectedItem
            dtFIRA.Rows.Add(drTemporal)

            nMinistradoFIRA = nMinistradoFIRA + CDbl(txtImporteFIRA.Text)
            lblMinistradoFIRA.Text = "Total Ministrado por FIRA a FINAGIL $" & Format(nMinistradoFIRA, "##,##0.00")

        ElseIf lUpdateFIRA = True Then

            strUpdate = "UPDATE mFIRA SET FechaProgramada = '" & DTOC(dtpFechaFIRA.Value) & "', "
            strUpdate = strUpdate & "Importe = " & CDbl(txtImporteFIRA.Text) & ", "
            strUpdate = strUpdate & "Fega = '" & cbFEGA.SelectedItem & "', "
            strUpdate = strUpdate & "Estado = '" & cbEstado.SelectedItem & "' "
            strUpdate = strUpdate & "WHERE Anexo = '" & cAnexo & "' "
            strUpdate = strUpdate & "AND Ciclo = '" & cCiclo & "' "
            strUpdate = strUpdate & "AND Ministracion = " & nRegistroFIRA
            Try
                cm1 = New SqlCommand(strUpdate, cnAgil)
                cnAgil.Open()
                cm1.ExecuteNonQuery()
                cnAgil.Close()
            Catch eException As Exception
                MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")
            End Try

            myKeySearch(0) = nRegistroFIRA
            drTemporal = dtFIRA.Rows.Find(myKeySearch)
            nImporteAnterior = drTemporal("Importe")
            drTemporal("Fecha Programada") = Mid(DTOC(dtpFechaFIRA.Value), 7, 2) & "/" & Mid(DTOC(dtpFechaFIRA.Value), 5, 2) & "/" & Mid(DTOC(dtpFechaFIRA.Value), 1, 4)
            drTemporal("Importe") = Format(CDbl(txtImporteFIRA.Text), "##,##0.00")
            drTemporal("FEGA") = cbFEGA.SelectedItem
            drTemporal("Estado") = cbEstado.SelectedItem

            nMinistradoFIRA = nMinistradoFIRA - nImporteAnterior + CDbl(txtImporteFIRA.Text)
            lblMinistradoFIRA.Text = "Total Ministrado por FIRA a FINAGIL $" & Format(nMinistradoFIRA, "##,##0.00")

        End If

        cm1.Dispose()

        panelFIRA.Visible = False
        btnInsertarFIRA.Enabled = True
        If btnModificarFIRA.Visible = False Then
            btnModificarFIRA.Visible = True
        End If
        If btnModificarFIRA.Visible = True Then
            btnModificarFIRA.Enabled = True
        End If

        dgvFIRA.Refresh()

    End Sub

    Private Sub btnCancelarFINAGIL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelarFINAGIL.Click
        panelFINAGIL.Visible = False
        btnInsertarFINAGIL.Enabled = True
        If btnModificarFINAGIL.Visible = True Then
            btnModificarFINAGIL.Enabled = True
        End If
    End Sub

    Private Sub btnCancelarFIRA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelarFIRA.Click
        panelFIRA.Visible = False
        btnInsertarFIRA.Enabled = True
        If btnModificarFIRA.Visible = True Then
            btnModificarFIRA.Enabled = True
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class