Imports System.Math
Imports System.IO

Public Class frmComputo

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim dtComputo As New DataTable()
        Dim dtPromedio As New DataTable()
        Dim drComputo As DataRow
        Dim drPromedio As DataRow

        ' Declaración de variables de datos

        Dim aArreglo() As Decimal = {100, 200, 300, 400, 500, 600, 700, 800, 900, 1000, 1100, 1200, 1300, 1400, 1500, 1600, 1700, 1800, 1900, 2000, 2100, 2200, 2800, 3000, 3100, 3200, 3400, 3500, 3600, 3700, 3800, 3900, 4000, 4100, 4200, 4300, 4350, 4400, 4500, 4600, 4700, 4800, 5900, 6000, 8000, 8100, 8200, 8300}
        Dim cCuenta As String
        Dim cFecha As String
        Dim cRenglon As String
        Dim i As Byte
        Dim myColArray(1) As DataColumn
        Dim n1912vs2617 As Decimal
        Dim nProm1912vs2617 As Decimal
        Dim nSaldo As Decimal
        Dim nPromedio As Decimal
        Dim oArchivo As StreamReader

        cFecha = DTOC(dtpProceso.Value)

        ' Primero creo la tabla Computo

        dtComputo.Columns.Add("Inst", Type.GetType("System.String"))
        dtComputo.Columns.Add("Fecha", Type.GetType("System.String"))
        dtComputo.Columns.Add("Concepto", Type.GetType("System.Decimal"))
        dtComputo.Columns.Add("MN_SDU", Type.GetType("System.Decimal"))
        dtComputo.Columns.Add("MN_PDM", Type.GetType("System.Decimal"))
        dtComputo.Columns.Add("ME_SDU", Type.GetType("System.Decimal"))
        dtComputo.Columns.Add("ME_PDM", Type.GetType("System.Decimal"))
        dtComputo.Columns.Add("UD_SDU", Type.GetType("System.Decimal"))
        dtComputo.Columns.Add("UD_PDM", Type.GetType("System.Decimal"))

        For i = 0 To 47
            drComputo = dtComputo.NewRow()
            drComputo("Inst") = "010089"
            drComputo("Fecha") = Mid(cFecha, 7, 2) & "/" & Mid(cFecha, 5, 2) & "/" & Mid(cFecha, 1, 4)
            drComputo("Concepto") = aArreglo(i)
            drComputo("MN_SDU") = 0
            drComputo("MN_PDM") = 0
            drComputo("ME_SDU") = 0
            drComputo("ME_PDM") = 0
            drComputo("UD_SDU") = 0
            drComputo("UD_PDM") = 0
            dtComputo.Rows.Add(drComputo)
        Next

        ' Tengo que definir una llave primaria para la tabla Computo a fin de buscar un grupo
        ' y acumular saldos y promedios

        myColArray(0) = dtComputo.Columns("Concepto")
        dtComputo.PrimaryKey = myColArray

        ' Luego creo la tabla Promedio

        dtPromedio.Columns.Add("Cuenta", Type.GetType("System.String"))
        dtPromedio.Columns.Add("Saldo", Type.GetType("System.Decimal"))
        dtPromedio.Columns.Add("Promedio", Type.GetType("System.Decimal"))

        ' Tengo que definir una llave primaria para la tabla Promedio a fin de buscar una cuenta
        ' y registrar su saldo y su promedio

        myColArray(0) = dtPromedio.Columns("Cuenta")
        dtPromedio.PrimaryKey = myColArray

        Try

            oArchivo = New StreamReader("C:\PROMEDIO.TXT")

            While (oArchivo.Peek() > -1)
                cRenglon = oArchivo.ReadLine()
                If InStr(cRenglon, "Cuenta:", CompareMethod.Text) > 0 Then
                    cCuenta = Mid(cRenglon, 30, 10)
                    drPromedio = dtPromedio.NewRow()
                    drPromedio("Cuenta") = cCuenta
                    drPromedio("Saldo") = 0
                    drPromedio("Promedio") = 0
                    dtPromedio.Rows.Add(drPromedio)
                ElseIf InStr(cRenglon, "Saldo final", CompareMethod.Text) > 0 Then
                    nSaldo = Val(Mid(cRenglon, 12, 17))
                    drPromedio = dtPromedio.Rows.Find(cCuenta)
                    If Not drPromedio Is Nothing Then
                        drPromedio("Saldo") = nSaldo
                    End If
                ElseIf InStr(cRenglon, "Sal. prom. dia", CompareMethod.Text) > 0 Then
                    nPromedio = Val(Mid(cRenglon, 15, 14))
                    drPromedio = dtPromedio.Rows.Find(cCuenta)
                    If Not drPromedio Is Nothing Then
                        drPromedio("Promedio") = nPromedio
                    End If
                End If
            End While

            oArchivo.Close()
            oArchivo = Nothing

            ' Grupo 100 y 4400

            nSaldo = 0
            nPromedio = 0

            drPromedio = dtPromedio.Rows.Find("1101-00-00")
            If Not drPromedio Is Nothing Then
                nSaldo += drPromedio("Saldo")
                nPromedio += drPromedio("Promedio")
            End If
            drPromedio = dtPromedio.Rows.Find("1103-00-00")
            If Not drPromedio Is Nothing Then
                nSaldo += drPromedio("Saldo")
                nPromedio += drPromedio("Promedio")
            End If

            If nSaldo < 0 Then
                drComputo = dtComputo.Rows.Find(" 4400")
            Else
                drComputo = dtComputo.Rows.Find("  100")
            End If
            drComputo("MN_SDU") = Abs(nSaldo)

            If nPromedio < 0 Then
                drComputo = dtComputo.Rows.Find(" 4400")
            Else
                drComputo = dtComputo.Rows.Find("  100")
            End If
            drComputo("MN_PDM") = Abs(nPromedio)

            ' Grupo 500

            nSaldo = 0
            nPromedio = 0

            drPromedio = dtPromedio.Rows.Find("1201-01-00")
            If Not drPromedio Is Nothing Then
                nSaldo += drPromedio("Saldo")
                nPromedio += drPromedio("Promedio")
            End If
            drPromedio = dtPromedio.Rows.Find("1201-02-00")
            If Not drPromedio Is Nothing Then
                nSaldo += drPromedio("Saldo")
                nPromedio += drPromedio("Promedio")
            End If

            drComputo = dtComputo.Rows.Find("  500")
            drComputo("MN_SDU") = nSaldo
            drComputo("MN_PDM") = nPromedio

            ' Grupo 700

            nSaldo = 0
            nPromedio = 0

            drPromedio = dtPromedio.Rows.Find("1301-02-01")
            If Not drPromedio Is Nothing Then
                nSaldo += drPromedio("Saldo")
                nPromedio += drPromedio("Promedio")
            End If
            drPromedio = dtPromedio.Rows.Find("1301-02-02")
            If Not drPromedio Is Nothing Then
                nSaldo += drPromedio("Saldo")
                nPromedio += drPromedio("Promedio")
            End If
            drPromedio = dtPromedio.Rows.Find("1301-02-03")
            If Not drPromedio Is Nothing Then
                nSaldo += drPromedio("Saldo")
                nPromedio += drPromedio("Promedio")
            End If
            drPromedio = dtPromedio.Rows.Find("1302-02-01")
            If Not drPromedio Is Nothing Then
                nSaldo += drPromedio("Saldo")
                nPromedio += drPromedio("Promedio")
            End If
            drPromedio = dtPromedio.Rows.Find("1302-02-02")
            If Not drPromedio Is Nothing Then
                nSaldo += drPromedio("Saldo")
                nPromedio += drPromedio("Promedio")
            End If
            drPromedio = dtPromedio.Rows.Find("1302-02-03")
            If Not drPromedio Is Nothing Then
                nSaldo += drPromedio("Saldo")
                nPromedio += drPromedio("Promedio")
            End If
            drPromedio = dtPromedio.Rows.Find("2620-00-00")
            If Not drPromedio Is Nothing Then
                nSaldo -= drPromedio("Saldo")
                nPromedio -= drPromedio("Promedio")
            End If
            drPromedio = dtPromedio.Rows.Find("3102-00-00")
            If Not drPromedio Is Nothing Then
                nSaldo -= drPromedio("Saldo")
                nPromedio -= drPromedio("Promedio")
            End If
            drPromedio = dtPromedio.Rows.Find("3102-90-00")
            If Not drPromedio Is Nothing Then
                nSaldo += drPromedio("Saldo")
                nPromedio += drPromedio("Promedio")
            End If

            drComputo = dtComputo.Rows.Find("  700")
            drComputo("MN_SDU") = nSaldo
            drComputo("MN_PDM") = nPromedio

            ' Grupo 800

            nSaldo = 0
            nPromedio = 0

            drPromedio = dtPromedio.Rows.Find("1351-00-00")
            If Not drPromedio Is Nothing Then
                nSaldo += drPromedio("Saldo")
                nPromedio += drPromedio("Promedio")
            End If
            drPromedio = dtPromedio.Rows.Find("1352-00-00")
            If Not drPromedio Is Nothing Then
                nSaldo += drPromedio("Saldo")
                nPromedio += drPromedio("Promedio")
            End If
            drPromedio = dtPromedio.Rows.Find("1381-00-00")
            If Not drPromedio Is Nothing Then
                nSaldo += drPromedio("Saldo")
                nPromedio += drPromedio("Promedio")
            End If
            drPromedio = dtPromedio.Rows.Find("1386-00-00")
            If Not drPromedio Is Nothing Then
                nSaldo += drPromedio("Saldo")
                nPromedio += drPromedio("Promedio")
            End If

            drComputo = dtComputo.Rows.Find("  800")
            drComputo("MN_SDU") = nSaldo
            drComputo("MN_PDM") = nPromedio

            ' Grupo 1300

            nSaldo = 0
            nPromedio = 0

            drPromedio = dtPromedio.Rows.Find("1501-00-00")
            If Not drPromedio Is Nothing Then
                nSaldo += drPromedio("Saldo")
                nPromedio += drPromedio("Promedio")
            End If
            drPromedio = dtPromedio.Rows.Find("3102-90-00")
            If Not drPromedio Is Nothing Then
                nSaldo -= drPromedio("Saldo")
                nPromedio -= drPromedio("Promedio")
            End If

            drComputo = dtComputo.Rows.Find(" 1300")
            drComputo("MN_SDU") = nSaldo
            drComputo("MN_PDM") = nPromedio

            ' Grupo 1400

            nSaldo = 0
            nPromedio = 0

            drPromedio = dtPromedio.Rows.Find("1600-00-00")
            If Not drPromedio Is Nothing Then
                nSaldo += drPromedio("Saldo")
                nPromedio += drPromedio("Promedio")
            End If
            drPromedio = dtPromedio.Rows.Find("1800-00-00")
            If Not drPromedio Is Nothing Then
                nSaldo += drPromedio("Saldo")
                nPromedio += drPromedio("Promedio")
            End If
            drPromedio = dtPromedio.Rows.Find("3121-00-00")
            If Not drPromedio Is Nothing Then
                nSaldo -= drPromedio("Saldo")
                nPromedio -= drPromedio("Promedio")
            End If
            drPromedio = dtPromedio.Rows.Find("3122-00-00")
            If Not drPromedio Is Nothing Then
                nSaldo -= drPromedio("Saldo")
                nPromedio -= drPromedio("Promedio")
            End If

            drComputo = dtComputo.Rows.Find(" 1400")
            drComputo("MN_SDU") = nSaldo
            drComputo("MN_PDM") = nPromedio

            ' Grupo 1600

            drComputo = dtComputo.Rows.Find(" 1600")
            drComputo("MN_SDU") = nSaldo
            drComputo("MN_PDM") = nPromedio

            ' Grupo 1700

            nSaldo = 0
            nPromedio = 0

            drPromedio = dtPromedio.Rows.Find("1502-00-00")
            If Not drPromedio Is Nothing Then
                nSaldo += drPromedio("Saldo")
                nPromedio += drPromedio("Promedio")
            End If
            drPromedio = dtPromedio.Rows.Find("1901-00-00")
            If Not drPromedio Is Nothing Then
                nSaldo += drPromedio("Saldo")
                nPromedio += drPromedio("Promedio")
            End If
            drPromedio = dtPromedio.Rows.Find("1902-00-00")
            If Not drPromedio Is Nothing Then
                nSaldo += drPromedio("Saldo")
                nPromedio += drPromedio("Promedio")
            End If
            drPromedio = dtPromedio.Rows.Find("1903-00-00")
            If Not drPromedio Is Nothing Then
                nSaldo += drPromedio("Saldo")
                nPromedio += drPromedio("Promedio")
            End If
            drPromedio = dtPromedio.Rows.Find("1904-00-00")
            If Not drPromedio Is Nothing Then
                nSaldo += drPromedio("Saldo")
                nPromedio += drPromedio("Promedio")
            End If
            drPromedio = dtPromedio.Rows.Find("3108-00-00")
            If Not drPromedio Is Nothing Then
                nSaldo -= drPromedio("Saldo")
                nPromedio -= drPromedio("Promedio")
            End If
            drPromedio = dtPromedio.Rows.Find("3109-00-00")
            If Not drPromedio Is Nothing Then
                nSaldo -= drPromedio("Saldo")
                nPromedio -= drPromedio("Promedio")
            End If

            n1912vs2617 = 0
            nProm1912vs2617 = 0
            drPromedio = dtPromedio.Rows.Find("1912-00-00")
            If Not drPromedio Is Nothing Then
                n1912vs2617 += drPromedio("Saldo")
                nProm1912vs2617 += drPromedio("Promedio")
            End If
            drPromedio = dtPromedio.Rows.Find("2617-00-00")
            If Not drPromedio Is Nothing Then
                n1912vs2617 -= drPromedio("Saldo")
                nProm1912vs2617 -= drPromedio("Promedio")
            End If

            If n1912vs2617 > 0 Then
                nSaldo += n1912vs2617
                nPromedio += nProm1912vs2617
            End If

            drComputo = dtComputo.Rows.Find(" 1700")
            drComputo("MN_SDU") = nSaldo
            drComputo("MN_PDM") = nPromedio

            ' Grupo 3100

            nSaldo = 0
            nPromedio = 0

            drPromedio = dtPromedio.Rows.Find("2122-00-00")
            If Not drPromedio Is Nothing Then
                nSaldo += drPromedio("Saldo")
                nPromedio += drPromedio("Promedio")
            End If

            drComputo = dtComputo.Rows.Find(" 3100")
            drComputo("MN_SDU") = nSaldo
            drComputo("MN_PDM") = nPromedio

            ' Grupo 3600

            nSaldo = 0
            nPromedio = 0

            drPromedio = dtPromedio.Rows.Find("2202-00-00")
            If Not drPromedio Is Nothing Then
                nSaldo += drPromedio("Saldo")
                nPromedio += drPromedio("Promedio")
            End If

            drComputo = dtComputo.Rows.Find(" 3600")
            drComputo("MN_SDU") = nSaldo
            drComputo("MN_PDM") = nPromedio

            ' Grupo 3800

            nSaldo = 0
            nPromedio = 0

            drPromedio = dtPromedio.Rows.Find("2204-00-00")
            If Not drPromedio Is Nothing Then
                nSaldo += drPromedio("Saldo")
                nPromedio += drPromedio("Promedio")
            End If

            drComputo = dtComputo.Rows.Find(" 3800")
            drComputo("MN_SDU") = nSaldo
            drComputo("MN_PDM") = nPromedio

            ' Grupo 4100

            nSaldo = 0
            nPromedio = 0

            drPromedio = dtPromedio.Rows.Find("2301-00-00")
            If Not drPromedio Is Nothing Then
                nSaldo += drPromedio("Saldo")
                nPromedio += drPromedio("Promedio")
            End If
            drPromedio = dtPromedio.Rows.Find("2311-00-00")
            If Not drPromedio Is Nothing Then
                nSaldo += drPromedio("Saldo")
                nPromedio += drPromedio("Promedio")
            End If
            drPromedio = dtPromedio.Rows.Find("2312-00-00")
            If Not drPromedio Is Nothing Then
                nSaldo += drPromedio("Saldo")
                nPromedio += drPromedio("Promedio")
            End If

            drComputo = dtComputo.Rows.Find(" 4100")
            drComputo("MN_SDU") = nSaldo
            drComputo("MN_PDM") = nPromedio

            ' Grupo 4300

            nSaldo = 0
            nPromedio = 0

            drPromedio = dtPromedio.Rows.Find("2303-00-00")
            If Not drPromedio Is Nothing Then
                nSaldo += drPromedio("Saldo")
                nPromedio += drPromedio("Promedio")
            End If

            drComputo = dtComputo.Rows.Find(" 4300")
            drComputo("MN_SDU") = nSaldo
            drComputo("MN_PDM") = nPromedio

            ' Grupo 4350

            nSaldo = 0
            nPromedio = 0

            If n1912vs2617 < 0 Then
                nSaldo += -n1912vs2617
                nPromedio += -nProm1912vs2617
            End If

            drPromedio = dtPromedio.Rows.Find("2621-00-00")
            If Not drPromedio Is Nothing Then
                nSaldo += drPromedio("Saldo")
                nPromedio += drPromedio("Promedio")
            End If

            drComputo = dtComputo.Rows.Find(" 4350")
            drComputo("MN_SDU") = nSaldo
            drComputo("MN_PDM") = nPromedio

            ' Grupo 300

            nSaldo = 0
            nPromedio = 0

            drComputo = dtComputo.Rows.Find("  400")
            nSaldo = drComputo("MN_SDU")
            nPromedio = drComputo("MN_PDM")
            drComputo = dtComputo.Rows.Find("  500")
            nSaldo += drComputo("MN_SDU")
            nPromedio += drComputo("MN_PDM")
            drComputo = dtComputo.Rows.Find("  300")
            drComputo("MN_SDU") = nSaldo
            drComputo("MN_PDM") = nPromedio

            ' Grupo 600

            nSaldo = 0
            nPromedio = 0

            drComputo = dtComputo.Rows.Find("  700")
            nSaldo = drComputo("MN_SDU")
            nPromedio = drComputo("MN_PDM")
            drComputo = dtComputo.Rows.Find("  800")
            nSaldo += drComputo("MN_SDU")
            nPromedio += drComputo("MN_PDM")
            drComputo = dtComputo.Rows.Find("  600")
            drComputo("MN_SDU") = nSaldo
            drComputo("MN_PDM") = nPromedio

            ' Grupo 1000

            nSaldo = 0
            nPromedio = 0

            drComputo = dtComputo.Rows.Find(" 1100")
            nSaldo = drComputo("MN_SDU")
            nPromedio = drComputo("MN_PDM")
            drComputo = dtComputo.Rows.Find(" 1200")
            nSaldo += drComputo("MN_SDU")
            nPromedio += drComputo("MN_PDM")
            drComputo = dtComputo.Rows.Find(" 1000")
            drComputo("MN_SDU") = nSaldo
            drComputo("MN_PDM") = nPromedio

            ' Grupo 2200

            nSaldo = 0
            nPromedio = 0

            For Each drComputo In dtComputo.Rows
                If drComputo("Concepto") <> 400 And drComputo("Concepto") <> 500 And drComputo("Concepto") <> 700 And drComputo("Concepto") <> 800 And drComputo("Concepto") <> 1100 And drComputo("Concepto") <> 1200 And drComputo("Concepto") <> 1500 And drComputo("Concepto") <> 1600 And drComputo("Concepto") < 2200 Then
                    nSaldo += drComputo("MN_SDU")
                    nPromedio += drComputo("MN_PDM")
                End If
            Next

            drComputo = dtComputo.Rows.Find(" 2200")
            drComputo("MN_SDU") = nSaldo
            drComputo("MN_PDM") = nPromedio

            ' Grupo 3000

            nSaldo = 0
            nPromedio = 0

            drComputo = dtComputo.Rows.Find(" 3100")
            nSaldo = drComputo("MN_SDU")
            nPromedio = drComputo("MN_PDM")
            drComputo = dtComputo.Rows.Find(" 3200")
            nSaldo += drComputo("MN_SDU")
            nPromedio += drComputo("MN_PDM")
            drComputo = dtComputo.Rows.Find(" 3400")
            nSaldo += drComputo("MN_SDU")
            nPromedio += drComputo("MN_PDM")

            drComputo = dtComputo.Rows.Find(" 3000")
            drComputo("MN_SDU") = nSaldo
            drComputo("MN_PDM") = nPromedio

            ' Grupo 3500

            nSaldo = 0
            nPromedio = 0

            drComputo = dtComputo.Rows.Find(" 3600")
            nSaldo = drComputo("MN_SDU")
            nPromedio = drComputo("MN_PDM")
            drComputo = dtComputo.Rows.Find(" 3700")
            nSaldo += drComputo("MN_SDU")
            nPromedio += drComputo("MN_PDM")
            drComputo = dtComputo.Rows.Find(" 3800")
            nSaldo += drComputo("MN_SDU")
            nPromedio += drComputo("MN_PDM")
            drComputo = dtComputo.Rows.Find(" 3900")
            nSaldo += drComputo("MN_SDU")
            nPromedio += drComputo("MN_PDM")
            drComputo = dtComputo.Rows.Find(" 4000")
            nSaldo += drComputo("MN_SDU")
            nPromedio += drComputo("MN_PDM")

            drComputo = dtComputo.Rows.Find(" 3500")
            drComputo("MN_SDU") = nSaldo
            drComputo("MN_PDM") = nPromedio

            ' Grupo 5900

            nSaldo = 0
            nPromedio = 0

            For Each drComputo In dtComputo.Rows
                If drComputo("Concepto") = 3000 Or drComputo("Concepto") = 3500 Or (drComputo("Concepto") >= 4100 And drComputo("Concepto") <= 4800) Then
                    nSaldo += drComputo("MN_SDU")
                    nPromedio += drComputo("MN_PDM")
                End If
            Next

            drComputo = dtComputo.Rows.Find(" 5900")
            drComputo("MN_SDU") = nSaldo
            drComputo("MN_PDM") = nPromedio

            ' Grupo 8000

            nSaldo = 0
            nPromedio = 0

            drPromedio = dtPromedio.Rows.Find("4200-00-00")
            If Not drPromedio Is Nothing Then
                nSaldo = drPromedio("Saldo")
                nPromedio = drPromedio("Promedio")
            End If
            drPromedio = dtPromedio.Rows.Find("4300-00-00")
            If Not drPromedio Is Nothing Then
                nSaldo += drPromedio("Saldo")
                nPromedio += drPromedio("Promedio")
            End If
            drPromedio = dtPromedio.Rows.Find("4400-00-00")
            If Not drPromedio Is Nothing Then
                nSaldo += drPromedio("Saldo")
                nPromedio += drPromedio("Promedio")
            End If
            drPromedio = dtPromedio.Rows.Find("4508-00-00")
            If Not drPromedio Is Nothing Then
                nSaldo += drPromedio("Saldo")
                nPromedio += drPromedio("Promedio")
            End If
            drPromedio = dtPromedio.Rows.Find("4509-00-00")
            If Not drPromedio Is Nothing Then
                nSaldo += drPromedio("Saldo")
                nPromedio += drPromedio("Promedio")
            End If
            drPromedio = dtPromedio.Rows.Find("5200-00-00")
            If Not drPromedio Is Nothing Then
                nSaldo += drPromedio("Saldo")
                nPromedio += drPromedio("Promedio")
            End If
            drPromedio = dtPromedio.Rows.Find("5100-00-00")
            If Not drPromedio Is Nothing Then
                nSaldo -= drPromedio("Saldo")
                nPromedio -= drPromedio("Promedio")
            End If

            drComputo = dtComputo.Rows.Find(" 8000")
            drComputo("MN_SDU") = nSaldo
            drComputo("MN_PDM") = nPromedio

            ' Grupo 8200

            drComputo = dtComputo.Rows.Find(" 8200")
            drComputo("MN_SDU") = nSaldo
            drComputo("MN_PDM") = nPromedio

            ' Conversión a miles de pesos

            For Each drComputo In dtComputo.Rows
                drComputo("MN_SDU") = Round(drComputo("MN_SDU") / 1000, 0)
                drComputo("MN_PDM") = Round(drComputo("MN_PDM") / 1000, 0)
            Next

            DataGridView1.DataSource = dtComputo

        Catch eException As Exception

            MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")

        End Try

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class