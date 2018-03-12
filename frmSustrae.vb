Option Explicit On

Imports System.Data.SqlClient
Imports System.Math

Public Class frmSustrae

    ' Declaración de variables de alcance privado

    Dim lFirstTime As Boolean = True

    Private Sub frmSustrae_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daClientes As New SqlDataAdapter(cm1)

        Dim dsAgil As New DataSet()

        cbSustraeActual.Items.Add("NC")
        cbSustraeActual.Items.Add("NO")
        cbSustraeActual.Items.Add("SI")

        ' Este Stored Procedure trae los clientes que tengan numeración correspondiente a Mexicali, Navojoa o Nuevo León

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "ContClie2"
            .Connection = cnAgil
        End With

        cbProductores.MaxDropDownItems = 25

        Try

            ' Llenar el DataSet

            daClientes.Fill(dsAgil, "Clientes")

            ' Ligar la tabla Clientes del dataset dsAgil al ComboBox

            cbProductores.DataSource = dsAgil
            cbProductores.DisplayMember = "Clientes.Descr"
            cbProductores.ValueMember = "Clientes.Cliente"
            lFirstTime = False

        Catch eException As Exception

            MsgBox(eException.Source & " " & eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")

        End Try

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub cbProductores_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbProductores.SelectedIndexChanged

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daAvio As New SqlDataAdapter(cm1)
        Dim dsAgil As New DataSet
        Dim drAvio As DataRow

        ' Declaración de variables de datos

        Dim cProductor As String = ""
        Dim cSustraeActual As String = ""

        If Not cbProductores.SelectedValue Is Nothing And lFirstTime = False Then

            gbProductor.Visible = True

            cProductor = cbProductores.SelectedValue.ToString()

            txtProductor.Text = cProductor

            ' El siguiente Command trae los datos del contrato de Avío

            With cm1
                .CommandType = CommandType.Text
                .CommandText = "SELECT Avios.*, Descr FROM Avios INNER JOIN Clientes ON Avios.Cliente = Clientes.Cliente WHERE Avios.Cliente = " & "'" & cProductor & "'"
                .Connection = cnAgil
            End With

            ' Llenar el dataset lo cual abre y cierra la conexión

            daAvio.Fill(dsAgil, "Avios")

            drAvio = dsAgil.Tables("Avios").Rows(0)

            If Trim(drAvio("FechaConsulta")) <> "" Then
                dtpFechaConsulta.Value = CTOD(drAvio("FechaConsulta"))
            Else
                dtpFechaConsulta.Value = Today()
            End If

            cSustraeActual = drAvio("SustraeActual")

            Select Case cSustraeActual
                Case "NC"
                    cbSustraeActual.SelectedIndex = 0
                Case "NO"
                    cbSustraeActual.SelectedIndex = 1
                Case "SI"
                    cbSustraeActual.SelectedIndex = 2
            End Select

        End If

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim strUpdate As String

        ' Declaración de variables de datos

        Dim cProductor As String = ""
        Dim cSustraeActual As String = ""

        cProductor = cbProductores.SelectedValue.ToString()

        Select Case cbSustraeActual.SelectedIndex
            Case 0
                cSustraeActual = "NC"
            Case 1
                cSustraeActual = "NO"
            Case 2
                cSustraeActual = "SI"
        End Select

        ' Debe actualizar los datos del contrato del productor seleccionado

        strUpdate = "UPDATE Avios SET"
        strUpdate = strUpdate & " FechaConsulta = '" & DTOC(dtpFechaConsulta.Value) & "',"
        strUpdate = strUpdate & " SustraeActual = '" & cSustraeActual & "'"
        strUpdate = strUpdate & " WHERE Cliente = '" & cProductor & "'"

        cm1 = New SqlCommand(strUpdate, cnAgil)
        cnAgil.Open()
        cm1.ExecuteNonQuery()
        cnAgil.Close()

        cnAgil.Dispose()
        cm1.Dispose()

        gbProductor.Visible = False

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class