Option Explicit On

Imports System.Data.SqlClient

Public Class frmRecuperacion

    ' Declaración de variables de alcance privado

    Dim nLeft As Integer
    Dim nTop As Integer

    Private Sub btnProcesar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProcesar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daRecuper As New SqlDataAdapter(cm1)
        Dim dsAgil As New DataSet()
        Dim drRegistro As DataRow
        Dim drRegistros As DataRowCollection

        ' Declaración de variables de datos

        Dim cFecha As String

        btnProcesar.Enabled = False
        DateTimePicker1.Enabled = False

        cFecha = DTOC(DateTimePicker1.Value)

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Recupera1"
            .Connection = cnAgil
            .Parameters.Add("@Fecha", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        ' Llenar el DataSet a través del DataAdapter, lo cual abre y cierra la conexión

        Try
            daRecuper.Fill(dsAgil, "Recupera")
        Catch eException As Exception
            MsgBox(eException.Message, MsgBoxStyle.Critical, eException.Source)
        End Try
        drRegistros = dsAgil.Tables("Recupera").Rows

        ' Una vez que tengo los registros, procedo a asignar los valores a cada uno
        ' de los elementos de la Forma, para mostrar los datos.

        nTop = 65
        For Each drRegistro In drRegistros
            NuevoRenglon(CTOD(drRegistro("Feven")).ToShortDateString, Format(drRegistro("Facturado"), "Currency"), Format(drRegistro("Recuperado"), "Currency"), FormatNumber(drRegistro("Porcentaje"), 0), Format(drRegistro("Saldo"), "Currency"))
        Next

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub NuevoRenglon(ByVal cVencimiento As String, ByVal cFacturado As String, ByVal cRecuperado As String, ByVal cPorcentaje As String, ByVal cSaldo As String)

        ' Creo las nuevas cajas de texto

        Dim txtVencimiento As New TextBox
        Dim txtFacturado As New TextBox
        Dim txtRecuperado As New TextBox
        Dim txtPorcentaje As New TextBox
        Dim txtSaldo As New TextBox

        ' Les asigno propiedades

        nLeft = 28
        txtVencimiento.Text = cVencimiento
        txtVencimiento.ReadOnly = True
        txtVencimiento.Width = 77
        txtVencimiento.Height = 20
        txtVencimiento.Top = nTop
        txtVencimiento.Left = nLeft
        txtVencimiento.TextAlign = HorizontalAlignment.Center
        GroupBox1.Controls.Add(txtVencimiento)

        nLeft = 116
        txtFacturado.Text = cFacturado
        txtFacturado.ReadOnly = True
        txtFacturado.Width = 120
        txtFacturado.Height = 20
        txtFacturado.Top = nTop
        txtFacturado.Left = nLeft
        txtFacturado.TextAlign = HorizontalAlignment.Right
        GroupBox1.Controls.Add(txtFacturado)

        nLeft = 247
        txtRecuperado.Text = cRecuperado
        txtRecuperado.ReadOnly = True
        txtRecuperado.Width = 120
        txtRecuperado.Height = 20
        txtRecuperado.Top = nTop
        txtRecuperado.Left = nLeft
        txtRecuperado.TextAlign = HorizontalAlignment.Right
        GroupBox1.Controls.Add(txtRecuperado)

        nLeft = 377
        txtPorcentaje.Text = cPorcentaje
        txtPorcentaje.ReadOnly = True
        txtPorcentaje.Width = 50
        txtPorcentaje.Height = 20
        txtPorcentaje.Top = nTop
        txtPorcentaje.Left = nLeft
        txtPorcentaje.TextAlign = HorizontalAlignment.Right
        GroupBox1.Controls.Add(txtPorcentaje)

        nLeft = 437
        txtSaldo.Text = cSaldo
        txtSaldo.ReadOnly = True
        txtSaldo.Width = 120
        txtSaldo.Height = 20
        txtSaldo.Top = nTop
        txtSaldo.Left = nLeft
        txtSaldo.TextAlign = HorizontalAlignment.Right
        GroupBox1.Controls.Add(txtSaldo)

        nTop = nTop + 25

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class
