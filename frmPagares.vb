Option Explicit On

Imports System.Data.SqlClient
Imports System.Math

Public Class frmPagares

    ' Declaración de variables de conexión ADO .NET de alcance privado

    Dim cnAgil As New SqlConnection(strConn)
    Dim dtPagares As New DataTable
    Dim myKeySearch(0) As String

    ' Declaración de variables de datos de alcance privado

    Dim cAnexo As String = ""
    Dim cCiclo As String = ""
    Dim lInsertFINAGIL As Boolean
    Dim lUpdateFINAGIL As Boolean
    Dim nImporteAnterior As Decimal = 0
    Dim nImporteFINAGIL As Decimal = 0
    Dim nGarantia As Decimal = 0
    Dim nMinistradoFINAGIL As Decimal = 0
    Dim nRowsFINAGIL As Byte
    Dim nRegistroFINAGIL As Byte

    Public Sub New(ByVal cLinea As String)

        MyBase.New()

        'This call is required by the Windows Form Designer.

        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        cAnexo = Mid(cLinea, 1, 10)
        If Mid(cLinea, 12, 6) = "PAGARE" Then
            Me.Text = "Registro de Pagarés del Crédito en Cuenta Corriente " & Mid(cLinea, 1, 10)
        Else
            Me.Text = "Registro de Pagarés del Contrato de Avío " & Mid(cLinea, 1, 10)
        End If

        cAnexo = Mid(cLinea, 1, 5) & Mid(cLinea, 7, 4)
        If Mid(cLinea, 12, 6) = "PAGARE" Then
            cCiclo = Mid(cLinea, 19, 2)
        Else
            cCiclo = Mid(cLinea, 18, 2)
        End If

        txtAnexo.Text = cLinea

    End Sub

    Private Sub frmPagares_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim daAvio As New SqlDataAdapter(cm1)
        Dim daPagares As New SqlDataAdapter(cm2)

        Dim dsAgil As New DataSet()
        Dim drAvio As DataRow
        Dim drPagare As DataRow
        Dim drAux As DataRow
        Dim myColArray(1) As DataColumn

        ' Declaración de variables de datos

        Dim cFlcan As String = ""
        Dim cNombreProductor As String = ""
        Dim i As Byte

        ' Aquí tengo que validar si se trata de un Contrato Terminado en cuyo caso solo se podrá
        ' consultar la información de las ministraciones otorgadas sin opción a modificar nada

        ' El siguiente Command trae los datos del contrato de Habilitación o Avío

        With cm1
            .CommandType = CommandType.Text
            .CommandText = "SELECT Avios.*, Descr FROM Avios " & _
                           "INNER JOIN Clientes ON Avios.Cliente = Clientes.Cliente " & _
                           "WHERE Anexo = " & "'" & cAnexo & "' AND Ciclo = '" & cCiclo & "'"
            .Connection = cnAgil
        End With

        ' El siguiente Command trae los datos de los pagarés firmados por el Productor para un contrato en particular

        With cm2
            .CommandType = CommandType.Text
            .CommandText = "SELECT * FROM PagaresAvio " & _
                           "WHERE Anexo = '" & cAnexo & "' AND Ciclo = '" & cCiclo & "' " & _
                           "ORDER BY Numero"
            .Connection = cnAgil
        End With

        ' Llenar el dataset lo cual abre y cierra la conexión

        daAvio.Fill(dsAgil, "Avios")
        daPagares.Fill(dsAgil, "Pagares")

        ' Información del contrato de habilitación o avío

        drAvio = dsAgil.Tables("Avios").Rows(0)

        cFlcan = drAvio("Flcan")
        cNombreProductor = Trim(Mid(drAvio("Descr"), 1, 80))
        txtNombreProductor.Text = cNombreProductor
        txtLineaAutorizada.Text = Format(drAvio("LineaActual"), "##,##0.00")

        If cFlcan <> "A" Then
            gbPagares.Enabled = False
        End If

        ' Crear la tabla que contendrá la información de los pagarés firmados por el Productor

        dtPagares.Columns.Add("No.", Type.GetType("System.Decimal"))
        dtPagares.Columns.Add("Fecha Pagaré", Type.GetType("System.String"))
        dtPagares.Columns.Add("Importe", Type.GetType("System.String"))
        dtPagares.Columns.Add("Garantia", Type.GetType("System.String"))

        ' Tengo que definir una llave primaria para la tabla dtPagares a fin de buscar un registro cuando desee actualizarlo

        myColArray(0) = dtPagares.Columns("No.")
        dtPagares.PrimaryKey = myColArray

        nMinistradoFINAGIL = 0

        btnModificarFINAGIL.Visible = False
        panelFINAGIL.Visible = False

        ' Información de los pagarés firmados por el Productor

        dtPagares.Clear()
        nRowsFINAGIL = dsAgil.Tables("Pagares").Rows.Count()

        If nRowsFINAGIL > 0 Then
            btnModificarFINAGIL.Visible = True
        End If

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
            nMinistradoFINAGIL = nMinistradoFINAGIL + drPagare("Importe")
        Next

        If nMinistradoFINAGIL > 0 Then
            lblMinistradoFINAGIL.Text = "Suma de los pagarés capturados $" & Format(nMinistradoFINAGIL, "##,##0.00")
        Else
            lblMinistradoFINAGIL.Text = ""
        End If

        dgvFINAGIL.DataSource = dtPagares
        dgvFINAGIL.Columns(0).Width = 25
        dgvFINAGIL.Columns(1).Width = 120
        dgvFINAGIL.Columns(2).Width = 100
        dgvFINAGIL.Columns(3).Width = 100

        For i = 0 To dgvFINAGIL.Columns.Count - 1
            dgvFINAGIL.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            If i = 0 Or i = 1 Then
                dgvFINAGIL.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alinea el encabezado
                dgvFINAGIL.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Alinea el contenido
            ElseIf i = 2 Or i = 3 Then
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

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()

    End Sub

    Private Sub btnInsertarFINAGIL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertarFINAGIL.Click

        panelFINAGIL.Visible = True
        btnInsertarFINAGIL.Enabled = False
        If btnModificarFINAGIL.Visible = True Then
            btnModificarFINAGIL.Enabled = False
        End If

        nImporteFINAGIL = 0
        nGarantia = 0

        txtImporteFINAGIL.Text = ""
        lInsertFINAGIL = True
        lUpdateFINAGIL = False

    End Sub

    Private Sub btnGuardarFINAGIL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarFINAGIL.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cm1 As New SqlCommand()

        Dim drTemporal As DataRow
        Dim strInsert As String
        Dim strUpdate As String

        ' Declaración de variables de datos

        Dim cFechaAlta As String = DTOC(Now())

        ' Falta validar que se haya capturado información

        nImporteFINAGIL = CDbl(txtImporteFINAGIL.Text)
        nGarantia = Round(nImporteFINAGIL * 0.1, 2)

        If lInsertFINAGIL = True Then

            nRowsFINAGIL = nRowsFINAGIL + 1

            strInsert = "INSERT INTO PagaresAvio (Anexo, Ciclo, Numero, FechaPagare, Importe, Garantia)"
            strInsert = strInsert & " VALUES ('"
            strInsert = strInsert & cAnexo & "', '"
            strInsert = strInsert & cCiclo & "', '"
            strInsert = strInsert & nRowsFINAGIL & "', '"
            strInsert = strInsert & DTOC(dtpFechaFINAGIL.Value) & "', "
            strInsert = strInsert & nImporteFINAGIL & ", "
            strInsert = strInsert & nGarantia & ")"
            Try
                cm1 = New SqlCommand(strInsert, cnAgil)
                cnAgil.Open()
                cm1.ExecuteNonQuery()
                cnAgil.Close()
            Catch eException As Exception
                MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")
            End Try

            drTemporal = dtPagares.NewRow()
            drTemporal("No.") = nRowsFINAGIL
            drTemporal("Fecha Pagaré") = Mid(DTOC(dtpFechaFINAGIL.Value), 7, 2) & "/" & Mid(DTOC(dtpFechaFINAGIL.Value), 5, 2) & "/" & Mid(DTOC(dtpFechaFINAGIL.Value), 1, 4)
            drTemporal("Importe") = Format(nImporteFINAGIL, "##,##0.00")
            drTemporal("Garantia") = Format(nGarantia, "##,##0.00")
            dtPagares.Rows.Add(drTemporal)

            nMinistradoFINAGIL = nMinistradoFINAGIL + CDbl(txtImporteFINAGIL.Text)
            lblMinistradoFINAGIL.Text = "Suma de los pagarés capturados $" & Format(nMinistradoFINAGIL, "##,##0.00")

        ElseIf lUpdateFINAGIL = True Then

            strUpdate = "UPDATE PagaresAvio SET FechaPagare = '" & DTOC(dtpFechaFINAGIL.Value) & "', "
            strUpdate = strUpdate & "Importe = " & nImporteFINAGIL & ", "
            strUpdate = strUpdate & "Garantia = " & nGarantia & " "
            strUpdate = strUpdate & "WHERE Anexo = '" & cAnexo & "'"
            strUpdate = strUpdate & "AND Ciclo = '" & cCiclo & "'"
            strUpdate = strUpdate & "AND Numero = " & nRegistroFINAGIL
            Try
                cm1 = New SqlCommand(strUpdate, cnAgil)
                cnAgil.Open()
                cm1.ExecuteNonQuery()
                cnAgil.Close()
            Catch eException As Exception
                MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")
            End Try

            myKeySearch(0) = nRegistroFINAGIL
            drTemporal = dtPagares.Rows.Find(myKeySearch)
            nImporteAnterior = drTemporal("Importe")
            drTemporal("Fecha Pagaré") = Mid(DTOC(dtpFechaFINAGIL.Value), 7, 2) & "/" & Mid(DTOC(dtpFechaFINAGIL.Value), 5, 2) & "/" & Mid(DTOC(dtpFechaFINAGIL.Value), 1, 4)
            drTemporal("Importe") = Format(nImporteFINAGIL, "##,##0.00")
            drTemporal("Garantia") = Format(nGarantia, "##,##0.00")

            nMinistradoFINAGIL = nMinistradoFINAGIL - nImporteAnterior + nImporteFINAGIL
            lblMinistradoFINAGIL.Text = "Suma de los pagarés capturados $" & Format(nMinistradoFINAGIL, "##,##0.00")

        End If

        panelFINAGIL.Visible = False
        btnInsertarFINAGIL.Enabled = True
        If btnModificarFINAGIL.Visible = False Then
            btnModificarFINAGIL.Visible = True
        End If
        If btnModificarFINAGIL.Visible = True Then
            btnModificarFINAGIL.Enabled = True
        End If

        dgvFINAGIL.Refresh()

        cm1.Dispose()

    End Sub

    Private Sub btnModificarFINAGIL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificarFINAGIL.Click

        panelFINAGIL.Visible = True
        btnInsertarFINAGIL.Enabled = False
        btnModificarFINAGIL.Enabled = False

        ' Tengo que leer la información del registro del Grid sobre el cual esté posicionado para mostrarla y poder corregirla

        nRegistroFINAGIL = dgvFINAGIL.Item(0, dgvFINAGIL.CurrentRow.Index).Value
        dtpFechaFINAGIL.Value = dgvFINAGIL.Item(1, dgvFINAGIL.CurrentRow.Index).Value
        txtImporteFINAGIL.Text = dgvFINAGIL.Item(2, dgvFINAGIL.CurrentRow.Index).Value
        nImporteFINAGIL = CDbl(txtImporteFINAGIL.Text)
        lInsertFINAGIL = False
        lUpdateFINAGIL = True

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class
