Option Explicit On

Imports System.Data.SqlClient

Public Class frmModCtoAvio

    ' Declaración de variables de datos de alcance privado

    Dim cAnexo As String = ""
    Dim cCiclo As String = ""

    Public Sub New(ByVal cLinea As String)

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        cAnexo = Mid(cLinea, 1, 10)
        cCiclo = Mid(cLinea, 14, 17)
        Me.Text = "Modificar Contrato de Avío " & cAnexo & " Ciclo " & cCiclo
        lblAnexo.Text = cAnexo & " Ciclo " & cCiclo

    End Sub

    Private Sub frmModCtoAvio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daAvio As New SqlDataAdapter(cm1)

        Dim dsAgil As New DataSet
        Dim drAvio As DataRow

        ' Declaración de variables de datos

        Dim cEstratoActual As String = ""
        Dim cFlcan As String = ""
        Dim cNombreProductor As String = ""

        cbEstratoActual.Items.Add("NE ")
        cbEstratoActual.Items.Add("PD1")
        cbEstratoActual.Items.Add("PD2")
        cbEstratoActual.Items.Add("PD3")

        ' Aquí tengo que validar si se trata de un Contrato Terminado en cuyo caso solo se podrá
        ' consultar la información de las ministraciones otorgadas sin opción a modificar nada

        cAnexo = Mid(cAnexo, 1, 5) & Mid(cAnexo, 7, 4)
        cCiclo = Mid(cCiclo, 1, 2)

        ' El siguiente Command trae los datos del contrato de Habilitación o Avío

        With cm1
            .CommandType = CommandType.Text
            .CommandText = "SELECT Avios.*, Descr FROM Avios " & _
                           "INNER JOIN Clientes ON Avios.Cliente = Clientes.Cliente " & _
                           "WHERE Anexo = " & "'" & cAnexo & "' AND Ciclo = '" & cCiclo & "'"
            .Connection = cnAgil
        End With

        ' Llenar el dataset lo cual abre y cierra la conexión

        daAvio.Fill(dsAgil, "Avios")

        drAvio = dsAgil.Tables("Avios").Rows(0)

        cFlcan = drAvio("Flcan")
        cNombreProductor = Trim(Mid(drAvio("Descr"), 1, 80))

        lblAnexo.Text = lblAnexo.Text & "   " & cNombreProductor

        If cFlcan <> "A" Then
            gbDatosFINAGIL.Enabled = False
            gbDatosFIRA.Enabled = False
            btnGuardar.Enabled = False
        End If

        If Trim(drAvio("FechaAutorizacion")) <> "" Then
            dtpFechaAutorizacion.Value = CTOD(drAvio("FechaAutorizacion"))
        Else
            dtpFechaAutorizacion.Value = Today()
        End If

        txtIDPersona.Text = Trim(drAvio("IDPersona"))
        txtIDContrato.Text = Trim(drAvio("IDContrato"))
        txtIDDTU.Text = Trim(drAvio("IDDTU"))
        txtIDCredito.Text = Trim(drAvio("IDCredito"))

        txtLineaActual.Text = Format(drAvio("LineaActual"), "##,##0.00")
        txtHectareasActual.Text = Format(drAvio("HectareasActual"), "##,##0.00")

        txtCostoHectarea.Text = Format(drAvio("CostoHectarea"), "##,##0.00")
        txtDiferencialFINAGIL.Text = Format(drAvio("DiferencialFINAGIL"), "##,##0.00")
        cEstratoActual = drAvio("EstratoActual")
        txtSustraeActual.Text = drAvio("SustraeActual")

        Select Case cEstratoActual
            Case "NE "
                cbEstratoActual.SelectedIndex = 0
            Case "PD1"
                cbEstratoActual.SelectedIndex = 1
            Case "PD2"
                cbEstratoActual.SelectedIndex = 2
            Case "PD3"
                cbEstratoActual.SelectedIndex = 3
        End Select

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim strUpdate As String

        ' Declaración de variables de datos

        Dim cEstratoActual As String = "NE "

        Select Case cbEstratoActual.SelectedIndex
            Case 0
                cEstratoActual = "NE "
            Case 1
                cEstratoActual = "PD1"
            Case 2
                cEstratoActual = "PD2"
            Case 3
                cEstratoActual = "PD3"
        End Select

        ' Debe actualizar los datos del contrato del productor seleccionado

        strUpdate = "UPDATE Avios SET"
        strUpdate = strUpdate & " FechaAutorizacion = '" & DTOC(dtpFechaAutorizacion.Value) & "',"
        strUpdate = strUpdate & " IDPersona = '" & txtIDPersona.Text & "',"
        strUpdate = strUpdate & " IDContrato = '" & txtIDContrato.Text & "',"
        strUpdate = strUpdate & " IDDTU = '" & txtIDDTU.Text & "',"
        strUpdate = strUpdate & " IDCredito = '" & txtIDCredito.Text & "',"
        strUpdate = strUpdate & " EstratoActual = '" & cEstratoActual & "',"
        strUpdate = strUpdate & " LineaActual = " & CDbl(txtLineaActual.Text) & ","
        strUpdate = strUpdate & " HectareasActual = " & CDbl(txtHectareasActual.Text) & ","
        strUpdate = strUpdate & " CostoHectarea = " & CDbl(txtCostoHectarea.Text) & ","
        strUpdate = strUpdate & " DiferencialFINAGIL = " & CDbl(txtDiferencialFINAGIL.Text)
        strUpdate = strUpdate & " WHERE Anexo = '" & cAnexo & "' AND Ciclo = '" & cCiclo & "'"

        cm1 = New SqlCommand(strUpdate, cnAgil)
        cnAgil.Open()
        cm1.ExecuteNonQuery()
        cnAgil.Close()

        cnAgil.Dispose()
        cm1.Dispose()

        gbDatosFINAGIL.Enabled = False
        gbDatosFIRA.Enabled = False
        btnGuardar.Enabled = False

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class