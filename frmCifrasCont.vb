Option Explicit On

Imports System.Math
Imports System.Data.SqlClient

Public Class frmCifrasCont

    Private Sub btnProcesa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProcesa.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cn As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim daAvisos As New SqlDataAdapter(cm1)
        Dim daRetener As New SqlDataAdapter(cm2)
        Dim daDevolver As New SqlDataAdapter(cm3)
        Dim dsAgil As New DataSet()
        Dim drAviso As DataRow
        Dim drCliente As DataRow
        Dim myColArray(1) As DataColumn

        ' Declaración de variables de datos

        Dim cFecha As String
        Dim cCliente As String
        Dim nTotalAv As Integer
        Dim nAvisoi As Integer
        Dim nAvisof As Integer
        Dim nRetener As Integer
        Dim nTarjnvas As Integer
        Dim nTarjdev As Integer

        cFecha = DTOC(DateTimePicker1.Value)
        ListBox1.Items.Clear()

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Aviso5"
            .Connection = cn
            .Parameters.Add("@cFecha", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        With cm2
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Avisos4"
            .Connection = cn
            .Parameters.Add("@Fecha", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        With cm3
            .CommandType = CommandType.Text
            .CommandText = "SELECT Retener.* FROM Retener"
            .Connection = cn
        End With


        daAvisos.Fill(dsAgil, "Avisos")
        daRetener.Fill(dsAgil, "Retener")
        daDevolver.Fill(dsAgil, "Devolver")
        myColArray(0) = dsAgil.Tables("Devolver").Columns("Cliente")
        dsAgil.Tables("Devolver").PrimaryKey = myColArray

        nRetener = dsAgil.Tables("Retener").Rows.Count

        nTotalAv = 0
        nTarjnvas = 0
        nTarjdev = 0
        For Each drAviso In dsAgil.Tables("Avisos").Rows
            If nTotalAv = 0 Then
                nAvisoi = drAviso("Factura")
            End If
            nAvisof = drAviso("Factura")
            If drAviso("Letra") = "001" Then
                nTarjnvas += 1
                cCliente = drAviso("Cliente")

                'Buscar si el Cliente pertenece a la Tabla Retener

                drCliente = dsAgil.Tables("Devolver").Rows.Find(cCliente)

                If Not drCliente Is Nothing Then
                    nTarjdev += 1
                    ListBox1.Items.Add(Mid(drAviso("Anexo"), 1, 5) & "/" & Mid(drAviso("Anexo"), 6, 4))
                End If

            End If
            nTotalAv += 1
        Next

        GroupBox1.Visible = True
        GroupBox2.Visible = True
        GroupBox3.Visible = True

        txtAvisoi.Text = nAvisoi
        txtAvisof.Text = nAvisof
        txtTotalAv.Text = nTotalAv
        txtRetener.Text = nRetener
        txtEnviar.Text = nTotalAv - nRetener
        txtNuevas.Text = nTarjnvas
        txtDev.Text = nTarjdev

        If nTarjdev > 0 Then
            Label9.Visible = True
            ListBox1.Visible = True
        End If

        cn.Dispose()
        cm1.Dispose()
        cm2.Dispose()
        cm3.Dispose()

    End Sub

    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class