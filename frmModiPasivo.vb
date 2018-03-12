Imports System.Math
Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Public Class frmModiPasivo

    Private Sub frmModiPasivo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strConn As String = "Server=SERVER-RAID; DataBase=Production; User ID=sa; pwd=faae6115"
        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim dsAgil As New DataSet()
        Dim daPagare As New SqlDataAdapter(cm1)
       
        ' Con este Stored Procedure obtengo la información de los Bancos

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DatoPagare"
            .Connection = cnAgil
        End With

        ' Llenar el DataSet lo cual abre y cierra la conexión

        daPagare.Fill(dsAgil, "Pagare")

        cbPagare.MaxDropDownItems = 6

        cbPagare.DataSource = dsAgil
        cbPagare.DisplayMember = "Pagare.Descrip"
        cbPagare.ValueMember = "Pagare.Garantia"

    End Sub

    Private Sub btnMostrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMostrar.Click
        Dim strConn As String = "Server=SERVER-RAID; DataBase=Production; User ID=sa; pwd=faae6115"
        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim dsAgil As New DataSet()
        Dim daPagare As New SqlDataAdapter(cm1)

        Dim cGarantia As String

        cGarantia = cbPagare.SelectedValue.ToString()

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "TraePagare"
            .Connection = cnAgil
            .Parameters.Add("@Pagare", SqlDbType.NVarChar)
            .Parameters(0).Value = cGarantia
        End With

        ' Llenar el DataSet lo cual abre y cierra la conexión

        daPagare.Fill(dsAgil, "Pagare")

        DataGridView1.DataSource = dsAgil
        DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

    End Sub
End Class