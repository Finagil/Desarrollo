Option Explicit On

Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class frmDatosEq

    Dim cAnexo As String
    Dim dtAuxiliar As New DataTable("Actiaux")
    Dim lCambio As Boolean

    Private Sub frmDatosEq_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As SqlConnection = New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim dsAgil As DataSet = New DataSet()
        Dim myColArray(1) As DataColumn
        Dim drActifijo As DataRow
        Dim drAnexo As DataRow
        Dim drActi As DataRow
        Dim drDatoActifij As DataRowCollection
        Dim daDatosActi As New SqlDataAdapter(cm1)
        Dim daImporte As New SqlDataAdapter(cm2)
        Dim dtMostrar As New DataTable("DatosFac")

        ' Declaración de variables de datos

        Dim cFactura As String
        Dim cProveed As String
        Dim cImporte As String
        Dim cFactact As String
        Dim nFactact As Decimal
        Dim nImpTotal As Decimal
        Dim nImpAnexo As Decimal
        Dim nIvaAnexo As Decimal

        cAnexo = Mid(txtAnexo.Text, 1, 5) & Mid(txtAnexo.Text, 7, 10)

        ' Este Stored Procedure trae TODOS los datos de Actifijo de la tabla Actifijo

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DatosEquipo1"
            .Connection = cnAgil
            .Parameters.Add("@Anexo", SqlDbType.NVarChar)
            .Parameters(0).Value = cAnexo
        End With

        ' Obtengo el monto total e Iva del contrato

        With cm2
            .CommandType = CommandType.Text
            .CommandText = "SELECT Impeq, Ivaeq FROM Anexos WHERE Anexos.Anexo = " & "'" & cAnexo & "'"
            .Connection = cnAgil
        End With

        Try

            ' Buscar a dicho cliente en el DataSet y retornar sus datos en el DataRow

            daDatosActi.Fill(dsAgil, "ActiFijo")
            daImporte.Fill(dsAgil, "Importes")
            drDatoActifij = dsAgil.Tables("ActiFijo").Rows
            drAnexo = dsAgil.Tables("Importes").Rows(0)

            ' Primero creo la tabla dtMostrar que desplegara la información de las
            ' facturas de Activo Fijo

            dtMostrar.Columns.Add("FACTURA", Type.GetType("System.String"))
            dtMostrar.Columns.Add("PROVEEDOR", Type.GetType("System.String"))
            dtMostrar.Columns.Add("IMPORTE", Type.GetType("System.Decimal"))
            dtMostrar.Columns.Add("ACTIVO", Type.GetType("System.String"))

            Panel1.Visible = False

            nImpTotal = 0
            For Each drActifijo In drDatoActifij
                cFactura = drActifijo("Factura")
                cProveed = drActifijo("Proveedor")
                cImporte = FormatNumber(drActifijo("Importe")).ToString
                nFactact = drActifijo("FactFij")
                cFactact = nFactact.ToString
                nImpTotal = drActifijo("Importe")

                drActi = dtMostrar.NewRow()
                drActi("FACTURA") = cFactura
                drActi("PROVEEDOR") = cProveed
                drActi("IMPORTE") = drActifijo("Importe")
                drActi("ACTIVO") = cFactact
                dtMostrar.Rows.Add(drActi)

            Next
            dsAgil.Tables.Add(dtMostrar)
            lCambio = False
            nImpAnexo = drAnexo("Impeq")
            nIvaAnexo = drAnexo("Ivaeq")

            txtAnexoIva.Text = FormatNumber(nIvaAnexo).ToString
            txtAnexototal.Text = FormatNumber(nImpAnexo - nIvaAnexo).ToString
            txtTotalfact.Text = cImporte

            DataGridView1.DataSource = dtMostrar
            DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Catch eException As Exception

            MsgBox(eException.Source & " " & eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")

        End Try

    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As SqlConnection = New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim dsAgil As DataSet = New DataSet()
        Dim daActiaux As New SqlDataAdapter(cm1)
        Dim drActiaux As DataRow
        Dim drActiauxs As DataRowCollection

        ' Declaración de variables de datos

        Dim cFactura As String
        Dim cFactsele As String
        Dim cProveed As String
        Dim cImporte As String
        Dim nFactact As String
        Dim cFactact As String
        Dim cCadena As String

        cFactsele = cAnexo & Trim(DataGridView1.Rows(e.RowIndex).Cells(0).Value) & Trim(DataGridView1.Rows(e.RowIndex).Cells(1).Value) & Trim(DataGridView1.Rows(e.RowIndex).Cells(2).Value) & Trim(DataGridView1.Rows(e.RowIndex).Cells(3).Value)

        ' El siguiente Stored Procedure trae TODOS los datos del equipo financiado de la tabla ActiFijo

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DatosEquipo1"
            .Connection = cnAgil
            .Parameters.Add("@Anexo", SqlDbType.NVarChar)
            .Parameters(0).Value = cAnexo
        End With

        Try
            daActiaux.Fill(dsAgil, "ActiFijo")
            drActiauxs = dsAgil.Tables("ActiFijo").Rows
            For Each drActiaux In drActiauxs
                cFactura = drActiaux("Factura")
                cProveed = drActiaux("Proveedor")
                cImporte = FormatNumber(drActiaux("Importe")).ToString
                nFactact = drActiaux("FactFij")
                cFactact = nFactact.ToString
                cCadena = cAnexo & Trim(cFactura) & Trim(cProveed) & Trim(drActiaux("Importe")) & Trim(cFactact)

                If cCadena = cFactsele Then
                    txtTotalfact.Text = FormatNumber(drActiaux("Importe")).ToString
                    txtAnexo.Text = drActiaux("Factura")
                    txtImpant.Text = drActiaux("Importe")
                    txtFactura.Text = drActiaux("Factura")
                    txtProveedor.Text = drActiaux("Proveedor")
                    txtSerie.Text = drActiaux("Serie")
                    txtMotor.Text = drActiaux("Motor")
                    txtModelo.Text = drActiaux("Modelo")
                    txtDetalle.Text = drActiaux("Detalle")
                    Exit For
                End If
            Next

            btnSalir.Enabled = False
            DataGridView1.Enabled = False

            Panel1.Visible = True
            txtDetalle.Visible = True
            btnIgnorar.Text = "Regresar"
            txtFactura.ReadOnly = True
            txtProveedor.ReadOnly = True
            txtSerie.ReadOnly = True
            txtMotor.ReadOnly = True
            txtModelo.ReadOnly = True
            txtDetalle.ReadOnly = True

        Catch eException As Exception
            MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")
        End Try

    End Sub

    Private Sub btnIgnorar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIgnorar.Click
        Panel1.Visible = False
        txtDetalle.Visible = False
        btnSalir.Enabled = True
        DataGridView1.Enabled = True
    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class