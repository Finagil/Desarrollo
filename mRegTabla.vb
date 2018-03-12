Option Explicit On 

Imports System.Data.SqlClient
Imports System.Math

Module mRegTabla

    Public Sub RegTabla(ByVal cAnexo As String, ByVal nSaldoInsoluto As Decimal, ByVal nPlazoRestante As Integer, ByVal cTabla As String)

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim daTabla As New SqlDataAdapter(cm1)
        Dim daAnexo As New SqlDataAdapter(cm2)
        Dim dsAgil As New DataSet()
        Dim drCambios As DataRow
        Dim drDatos As DataRow
        Dim dtCambios As New DataTable("Cambios")
        Dim strUpdate As String

        ' Declaración de variables de datos

        Dim cFechacon As String
        Dim cForca As String
        Dim cTipar As String
        Dim cTipo As String
        Dim nAbcap As Decimal
        Dim nDifer As Decimal
        Dim nInter As Decimal
        Dim nIva As Decimal
        Dim nIvacapital As Decimal
        Dim nIvaEq As Decimal
        Dim nLetra As Integer
        Dim nNuevoSaldo As Decimal
        Dim nPlazo As Integer
        Dim nPorcentajeIVA As Decimal = 0.16
        Dim nPorieq As Decimal
        Dim nRenta As Decimal
        Dim nSaldo As Decimal
        Dim nTasa As Decimal
        Dim nTasas As Decimal

        Select Case cTabla
            Case "E"
                With cm1
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "TablaEquipo1"
                    .Connection = cnAgil
                    .Parameters.Add("@Anexo", SqlDbType.NVarChar)
                    .Parameters(0).Value = cAnexo
                End With
            Case "S"
                With cm1
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "TablaSeguro1"
                    .Connection = cnAgil
                    .Parameters.Add("@Anexo", SqlDbType.NVarChar)
                    .Parameters(0).Value = cAnexo
                End With
            Case "O"
                With cm1
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "TraeAdeudos"
                    .Connection = cnAgil
                    .Parameters.Add("@Anexo", SqlDbType.NVarChar)
                    .Parameters(0).Value = cAnexo
                End With
        End Select

        With cm2
            .CommandType = CommandType.Text
            .CommandText = "SELECT Fechacon, Forca, Plazo, Tasas, Difer, IvaEq, Porieq, Plaseg, Tipo, Tipar FROM Anexos " & _
                           "INNER JOIN Clientes ON Anexos.Cliente = Clientes.Cliente " & _
                           "WHERE Anexo = '" & cAnexo & "'"
            .Connection = cnAgil
        End With

        ' Llenar el DataSet a través del DataAdapter, lo cual abre y cierra la conexión

        daAnexo.Fill(dsAgil, "Anexo")
        daTabla.Fill(dsAgil, "Tabla")

        drDatos = dsAgil.Tables("Anexo").Rows(0)

        cFechacon = drDatos("Fechacon")
        nIvaEq = drDatos("IvaEq")
        nPorieq = drDatos("Porieq")
        nNuevoSaldo = nSaldoInsoluto
        nTasas = drDatos("Tasas")
        nDifer = drDatos("Difer")
        cForca = drDatos("Forca")
        cTipo = drDatos("Tipo")
        cTipar = drDatos("Tipar")
        nTasa = (nTasas + nDifer) / 1200
        nPlazo = drDatos("Plazo")               ' Trae el plazo del equipo
        nLetra = nPlazo - nPlazoRestante + 1    ' Calcula la letra desde la cual se va a reconstruir la tabla

        If cTabla = "S" Or cTabla = "O" Then
            For Each drDatos In dsAgil.Tables("Tabla").Rows
                If drDatos("Nufac") = 0 Then
                    nLetra = Val(drDatos("Letra"))
                    Exit For
                End If
            Next
        End If

        ' Creo la estructura de la tabla temporal que guardará los cambios a la Tabla

        dtCambios.Columns.Add("Letra", Type.GetType("System.String"))
        dtCambios.Columns.Add("Saldo", Type.GetType("System.String"))
        dtCambios.Columns.Add("Inter", Type.GetType("System.String"))
        dtCambios.Columns.Add("Abcap", Type.GetType("System.String"))
        dtCambios.Columns.Add("Iva", Type.GetType("System.String"))
        dtCambios.Columns.Add("Ivacap", Type.GetType("System.String"))

        nIvacapital = 0

        Dim nResidual As Decimal = 120000

        If cForca = "1" Or cForca = "4" Then

            If cTipar = "P" Then
                '                nResidual = Round(nImpEq * nPorOp / 100, 2) / (1 + nPorcentajeIVA)

            End If

            If nNuevoSaldo > 0 Then
                If cTipar = "F" Or cTipar = "R" Or cTipar = "S" Then
                    nRenta = Round(Pmt(nTasa, nPlazoRestante, -nNuevoSaldo, 0), 2)
                ElseIf cTipar = "P" Then
                    nRenta = Round(Pmt(nTasa, nPlazoRestante, -nNuevoSaldo, nResidual), 2)
                End If
            Else
                nRenta = 0
            End If

            'nRenta = Round(nNuevoSaldo * nTasa / (1 - Pow((1 + nTasa), -nPlazoRestante)), 2)

            For Each drCambios In dsAgil.Tables("Tabla").Rows
                If drCambios("Nufac") = 0 And Val(drCambios("Letra")) >= nLetra Then
                    nInter = Round(nNuevoSaldo * nTasa, 2)
                    nSaldo = nNuevoSaldo
                    nAbcap = IIf(Val(drCambios("Letra")) = nPlazo, nSaldo, Round(nRenta - nInter, 2))
                    If cTipar = "R" Then
                        If cTipo = "M" Or cTipo = "E" Then
                            nIva = 0
                        Else
                            nIva = Round(nInter * nPorcentajeIVA, 2)
                        End If
                    ElseIf cTipar = "P" Then
                        nIva = Round((nAbcap + nInter) * nPorcentajeIVA, 2)
                    Else
                        nIva = Round(nInter * nPorcentajeIVA, 2)
                    End If
                    If cFechacon >= "20020301" And nIvaEq > 0 And cTabla = "E" Then
                        nIvacapital = Round(nAbcap * nPorieq / 100, 2)
                    End If
                    drDatos = dtCambios.NewRow()
                    drDatos("Letra") = drCambios("Letra")
                    drDatos("Saldo") = nSaldo
                    drDatos("Inter") = nInter
                    drDatos("Abcap") = nAbcap
                    drDatos("Iva") = nIva
                    drDatos("Ivacap") = nIvacapital
                    dtCambios.Rows.Add(drDatos)
                    nNuevoSaldo = Round(nSaldo - nAbcap, 2)
                End If
            Next
        ElseIf cForca = "2" Then
            nAbcap = Round(nSaldoInsoluto / nPlazoRestante, 2)
            For Each drCambios In dsAgil.Tables("Tabla").Rows
                If drCambios("Nufac") = 0 And drCambios("Letra") >= nLetra Then
                    nInter = Round(nNuevoSaldo * nTasa, 2)
                    nSaldo = nNuevoSaldo
                    nAbcap = IIf(drCambios("Letra") = nPlazo, nSaldo, nAbcap)
                    If cTipar = "R" Then
                        If cTipo = "M" Or cTipo = "E" Then
                            nIva = 0
                        Else
                            nIva = Round(nInter * nPorcentajeIVA, 2)
                        End If
                    ElseIf cTipar = "P" Then
                        nIva = Round((nAbcap + nInter) * nPorcentajeIVA, 2)
                    Else
                        nIva = Round(nInter * nPorcentajeIVA, 2)
                    End If
                    If cFechacon >= "20020301" And nIvaEq > 0 And cTabla = "E" Then
                        nIvacapital = Round(nAbcap * nPorieq / 100, 2)
                    End If
                    drDatos = dtCambios.NewRow()
                    drDatos("Letra") = drCambios("Letra")
                    drDatos("Saldo") = nSaldo
                    drDatos("Inter") = nInter
                    drDatos("Abcap") = nAbcap
                    drDatos("Iva") = nIva
                    drDatos("Ivacap") = nIvacapital
                    dtCambios.Rows.Add(drDatos)
                    nNuevoSaldo = Round(nSaldo - nAbcap, 2)
                End If
            Next
        End If
        dsAgil.Tables.Add(dtCambios)

        cnAgil.Open()

        For Each drCambios In dsAgil.Tables("Cambios").Rows
            Select Case cTabla
                Case "E"
                    strUpdate = "UPDATE Edoctav SET Saldo = " & "'" & drCambios("Saldo") & "',"
                    strUpdate = strUpdate & " Abcap = " & " '" & drCambios("Abcap") & "',"
                    strUpdate = strUpdate & " Inter = " & "'" & drCambios("Inter") & "',"
                    strUpdate = strUpdate & " Iva = " & "'" & drCambios("Iva") & "',"
                    strUpdate = strUpdate & " IvaCapital = " & "'" & drCambios("Ivacap") & "'"
                    strUpdate = strUpdate & "WHERE Anexo = " & "'" & cAnexo & "'"
                    strUpdate = strUpdate & "And Letra = " & "'" & drCambios("Letra") & "'"
                Case "S"
                    strUpdate = "UPDATE Edoctas SET Saldo = " & "'" & drCambios("Saldo") & "',"
                    strUpdate = strUpdate & " Abcap = " & " '" & drCambios("Abcap") & "',"
                    strUpdate = strUpdate & " Inter = " & "'" & drCambios("Inter") & "',"
                    strUpdate = strUpdate & " Iva = " & "'" & drCambios("Iva") & "'"
                    strUpdate = strUpdate & "WHERE Anexo = " & "'" & cAnexo & "'"
                    strUpdate = strUpdate & "And Letra = " & "'" & drCambios("Letra") & "'"
                Case "O"
                    strUpdate = "UPDATE Edoctao SET Saldo = " & "'" & drCambios("Saldo") & "',"
                    strUpdate = strUpdate & " Abcap = " & " '" & drCambios("Abcap") & "',"
                    strUpdate = strUpdate & " Inter = " & "'" & drCambios("Inter") & "',"
                    strUpdate = strUpdate & " Iva = " & "'" & drCambios("Iva") & "'"
                    strUpdate = strUpdate & "WHERE Anexo = " & "'" & cAnexo & "'"
                    strUpdate = strUpdate & "And Letra = " & "'" & drCambios("Letra") & "'"
            End Select

            Try
                cm2 = New SqlCommand(strUpdate, cnAgil)
                cm2.ExecuteNonQuery()
            Catch eException As Exception
                MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje")
            End Try

        Next

        cnAgil.Close()

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()

    End Sub

End Module
