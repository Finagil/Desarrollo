Option Explicit On

Imports System.Math
Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class frmCtrlPasivo

    Private Sub frmCtrlPasivo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strConn As String = "Server=SERVER-RAID; DataBase=Production; User ID=sa; pwd=faae6115"
        Dim cnAgil As New SqlConnection(strConn)
        Dim cm2 As New SqlCommand()
        Dim dsAgil As New DataSet()
        Dim daBancos As New SqlDataAdapter(cm2)

        ' Con este Stored Procedure obtengo la información de los Bancos

        With cm2
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Bancos1"
            .Connection = cnAgil
        End With

        ' Llenar el DataSet lo cual abre y cierra la conexión

        daBancos.Fill(dsAgil, "Bancos")

        ComboBox1.MaxDropDownItems = 6

        ComboBox1.DataSource = dsAgil
        ComboBox1.DisplayMember = "Bancos.DescBanco"
        ComboBox1.ValueMember = "Bancos.Banco"

    End Sub
    Private Sub btnInicio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInicio.Click
        Dim cm1 As New SqlCommand()
        Dim dtMostrar As New DataTable("Tablapag")
        Dim drDato As DataRow

        Dim n As Integer
        Dim i As Integer
        Dim d As Integer
        Dim nMes As Integer
        Dim nDias As Integer
        Dim nSaldo As Decimal
        Dim nInteres As Decimal
        Dim nCapital As Decimal
        Dim nTotal As Decimal
        Dim nTasa As Decimal
        Dim cFechai As String
        Dim cFechaf As String
        Dim cDiasem As String
        Dim dFechaf As Date
        Dim dFechaa As Date
        Dim bFins As Boolean

        ' Primero creo la tabla dtMostrar que desplegara la información de la Tabla del Pagaré

        dtMostrar.Columns.Add("NUM", Type.GetType("System.Decimal"))
        dtMostrar.Columns.Add("INICIAL", Type.GetType("System.String"))
        dtMostrar.Columns.Add("FINAL", Type.GetType("System.String"))
        dtMostrar.Columns.Add("DSEM", Type.GetType("System.String"))
        dtMostrar.Columns.Add("DIAS", Type.GetType("System.Decimal"))
        dtMostrar.Columns.Add("SALDO", Type.GetType("System.Decimal"))
        dtMostrar.Columns.Add("TASA", Type.GetType("System.Decimal"))
        dtMostrar.Columns.Add("INTERES", Type.GetType("System.Decimal"))
        dtMostrar.Columns.Add("CAPITAL", Type.GetType("System.Decimal"))
        dtMostrar.Columns.Add("TOTAL", Type.GetType("System.Decimal"))

        n = txtPlazo.Text
        nSaldo = txtImportepag.Text
        nCapital = txtCapital.Text
        nMes = Month(dtpFechafin.Value)
        bFins = False

        For i = 1 To n
            cFechai = IIf(i = 1, DTOC(dtpFechaini.Value), cFechaf)
            dFechaf = IIf(bFins = True, dFechaa, dFechaf)
            bFins = False
            dFechaf = IIf(i = 1, dtpFechafin.Value, DateAdd(DateInterval.Month, 1, dFechaf))

            If nMes = 2 And Day(dtpFechafin.Value) = 28 And i > 1 Then
                dFechaf = DateSerial(Year(dFechaf), Month(dFechaf) + 1, 1)
                dFechaf = DateAdd(DateInterval.Day, -1, dFechaf)
            ElseIf Day(dtpFechafin.Value) = 30 And (nMes = 4 Or nMes = 6 Or nMes = 9 Or nMes = 11) And i > 1 Then
                dFechaf = DateSerial(Year(dFechaf), Month(dFechaf) + 1, 1)
                dFechaf = DateAdd(DateInterval.Day, -1, dFechaf)
            End If

            d = Weekday(dFechaf)
            Select Case d
                Case 1
                    cDiasem = "DOM"
                Case 2
                    cDiasem = "LUN"
                Case 3
                    cDiasem = "MAR"
                Case 4
                    cDiasem = "MIE"
                Case 5
                    cDiasem = "JUE"
                Case 6
                    cDiasem = "VIE"
                Case 7
                    cDiasem = "SAB"
            End Select
            dFechaa = dFechaf
            If cDiasem = "DOM" And rbAnterior.Checked = True Then
                dFechaf = DateAdd(DateInterval.Day, -2, dFechaf)
                cDiasem = "VIE"
                bFins = True
            ElseIf cDiasem = "SAB" And rbAnterior.Checked = True Then
                dFechaf = DateAdd(DateInterval.Day, -1, dFechaf)
                cDiasem = "VIE"
                bFins = True
            ElseIf cDiasem = "SAB" And rbPosterior.Checked = True Then
                dFechaf = DateAdd(DateInterval.Day, 2, dFechaf)
                cDiasem = "LUN"
                bFins = True
            ElseIf cDiasem = "DOM" And rbPosterior.Checked = True Then
                dFechaf = DateAdd(DateInterval.Day, 1, dFechaf)
                cDiasem = "LUN"
                bFins = True
            End If
            cFechaf = DTOC(dFechaf)

            nSaldo = IIf(i = 1, txtImportepag.Text, nSaldo - nCapital)
            nTasa = txtTasa.Text
            nDias = DateDiff(DateInterval.Day, CTOD(cFechai), dFechaf)
            nInteres = Round((nSaldo * (nTasa / 36000)) * nDias, 2)
            If rbVariable.Checked = True And i > 1 = True Then
                nInteres = 0
            End If
            nCapital = IIf(i <= (n - 1), nCapital, (txtImportepag.Text - (nCapital * (n - 1))))
            nTotal = Round(nInteres + nCapital, 2)
            drDato = dtMostrar.NewRow()
            drDato("Num") = i
            drDato("Inicial") = CTOD(cFechai).ToShortDateString
            drDato("Final") = CTOD(cFechaf).ToShortDateString
            drDato("Dsem") = cDiasem
            drDato("Dias") = nDias
            drDato("Saldo") = nSaldo
            drDato("Tasa") = FormatNumber(nTasa.ToString, 4)
            drDato("Interes") = FormatNumber(nInteres.ToString, 2)
            drDato("Capital") = FormatNumber(nCapital.ToString, 2)
            drDato("Total") = FormatNumber(nTotal.ToString, 2)
            dtMostrar.Rows.Add(drDato)
        Next

        DataGridView1.DataSource = dtMostrar
        DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        btnSave.Enabled = True

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        ' Declaración de variables de conexión ADO .NET

        Dim strConn As String = "Server=SERVER-RAID; DataBase=Production; User ID=sa; pwd=faae6115"
        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim cm4 As New SqlCommand()
        Dim dsAgil As New DataSet()
        Dim daGarant As New SqlDataAdapter(cm4)
        Dim drPasivo As DataRow
        Dim aPrimaryKey(1) As DataColumn

        Dim strInsert As String
        Dim strUpdate As String
        Dim cTipotas As String
        Dim nGarantia As Integer
        Dim i As Integer
        Dim n As Integer

        With cm1
            .CommandType = CommandType.Text
            .CommandText = "SELECT IDPasivo FROM Llaves"
            .Connection = cnAgil
        End With

        With cm4
            .CommandType = CommandType.Text
            .CommandText = "SELECT * FROM Pasivos"
            .Connection = cnAgil
        End With
        daGarant.Fill(dsAgil, "Garantia")

        ' Ahora defino la llave primaria de la tabla Catalogo para poder buscar una cuenta en particular

        aPrimaryKey(0) = dsAgil.Tables("Garantia").Columns("Garantia")
        dsAgil.Tables("Garantia").PrimaryKey = aPrimaryKey

        cTipotas = IIf(rbFija.Checked = True, "F", "V")
        n = txtPlazo.Text

        cnAgil.Open()
        nGarantia = CInt(cm1.ExecuteScalar()) + 1

        ' Ahora revisamos si existe la garantia en la Tabla de Pasivos.
        ' En caso que no exista, debemos darla de alta.

        drPasivo = dsAgil.Tables("Garantia").Rows.Find(nGarantia.ToString)

        If drPasivo Is Nothing Then

            strInsert = "INSERT INTO Pasivos(Garantia, Banco, Importe, Tasap, Tptasa, Plazop)"
            strInsert = strInsert & "VALUES('"
            strInsert = strInsert & nGarantia & "', '"
            strInsert = strInsert & ComboBox1.SelectedValue.ToString() & "', '"
            strInsert = strInsert & txtImportepag.Text & "', '"
            strInsert = strInsert & txtTasa.Text & "', '"
            strInsert = strInsert & cTipotas & "', '"
            strInsert = strInsert & txtPlazo.Text & "')"
            cm2 = New SqlCommand(strInsert, cnAgil)
            cm2.ExecuteNonQuery()

            For i = 0 To (n - 1)
                strInsert = "INSERT INTO Tablapasivo( Garantia, Letrap, Fechai, Fechaf, Sdia, Dias, Saldop, Interesp, Capitalp)"
                strInsert = strInsert & "VALUES('"
                strInsert = strInsert & nGarantia & "', '"
                strInsert = strInsert & DataGridView1.Rows(i).Cells(0).Value & "', '"
                strInsert = strInsert & DTOC(DataGridView1.Rows(i).Cells(1).Value) & "', '"
                strInsert = strInsert & DTOC(DataGridView1.Rows(i).Cells(2).Value) & "', '"
                strInsert = strInsert & DataGridView1.Rows(i).Cells(3).Value & "', '"
                strInsert = strInsert & DataGridView1.Rows(i).Cells(4).Value & "', '"
                strInsert = strInsert & DataGridView1.Rows(i).Cells(5).Value & "', '"
                strInsert = strInsert & DataGridView1.Rows(i).Cells(7).Value & "', '"
                strInsert = strInsert & DataGridView1.Rows(i).Cells(8).Value & "')"
                cm3 = New SqlCommand(strInsert, cnAgil)
                cm3.ExecuteNonQuery()
            Next

            ' Debe actualizar el atributo IDPasivo de la tabla Llaves

            strUpdate = "UPDATE Llaves SET IDPasivo = " & nGarantia
            cm3 = New SqlCommand(strUpdate, cnAgil)
            cm3.ExecuteNonQuery()

            cnAgil.Close()

            MsgBox("Pagaré dado de Alta", MsgBoxStyle.Information, "Mensaje del Sistema")

        Else

            MsgBox("Ya Existe Pagaré", MsgBoxStyle.Information, "Mensaje del Sistema")

        End If

        btnSave.Enabled = False

    End Sub

End Class