' Esta función regresa una Tabla que contiene n registros con la siguiente estructura:
' 
' Anexo, SaldoInicial, Fecha Inicial, Fecha Final, Tasa, Días, Interés
'
' Esta tabla se genera por cada ministración otorgada

Option Explicit On

Imports System.Math

Module mInteresAcumulado

    Public Function InteresAcumulado(ByVal cAnexo As String, ByVal cTipta As String, ByVal cReferencia As String, ByVal cFechaDocumento As String, ByVal nImporte As Decimal, ByVal nTasa As Decimal, ByVal nDiferencial As Decimal, ByVal cFechaCorte As String, ByVal dtTIIE As DataTable, ByVal cFechaTerminacion As String) As DataTable

        ' Declaración de variables de conexión ADO .NET

        Dim dtIntereses As New DataTable()
        Dim drTIIE As DataRow
        Dim drTemporal As DataRow
        Dim myKeySearch(0) As String

        ' Declaración de variables de datos

        Dim cFechaFinal As String
        Dim cFechaInicial As String
        Dim i As Byte
        Dim nDias As Byte = 0
        Dim nInteres As Decimal = 0
        Dim nIteraciones As Byte
        Dim nSaldoInicial As Decimal = 0
        Dim nTasaAplicable As Decimal = 0
        Dim nTIIE As Decimal = 0

        ' Lo primero que tengo que hacer es determinar cuántas veces va a iterar.
        ' En el caso de una ministración va a iterar desde la fecha del documento hasta la fecha del reporte (cFechaCorte);
        ' En el caso de la Garantía Líquida va a iterar desde la fecha del documento hasta la fecha en que termina el ciclo (cFechaTerminacion) o hasta la fecha del reporte (cFechaCorte) -lo que ocurra primero-

        nIteraciones = 0
        If Mid(cFechaCorte, 1, 6) >= Mid(cFechaDocumento, 1, 6) Then
            nIteraciones = Mpt(CTOD(cFechaCorte), CTOD(cFechaDocumento)) + 1
        End If

        ' Luego creo la tabla dtIntereses

        dtIntereses.Columns.Add("Anexo", Type.GetType("System.String"))
        dtIntereses.Columns.Add("SaldoInicial", Type.GetType("System.Decimal"))
        dtIntereses.Columns.Add("FechaInicial", Type.GetType("System.String"))
        dtIntereses.Columns.Add("FechaFinal", Type.GetType("System.String"))
        dtIntereses.Columns.Add("Tasa", Type.GetType("System.Decimal"))
        dtIntereses.Columns.Add("Dias", Type.GetType("System.Decimal"))
        dtIntereses.Columns.Add("Interes", Type.GetType("System.Decimal"))


        If cReferencia = "FINAGIL" Then

            cFechaInicial = cFechaDocumento
            nSaldoInicial = nImporte

            For i = 1 To nIteraciones

                ' Si el crédito es a Tasa FIJA tomo su valor en vez de determinarlo

                If cTipta = "7" Then

                    nTasaAplicable = Round(nTasa + nDiferencial, 4)

                Else

                    ' Construyo una fecha que me permita buscar el promedio de la tasa TIIE del mes inmediato anterior

                    myKeySearch(0) = Mid(DTOC(DateAdd(DateInterval.Month, -1, CTOD(cFechaInicial))), 1, 6)

                    drTIIE = dtTIIE.Rows.Find(myKeySearch)

                    If drTIIE Is Nothing Then
                        nTIIE = 0
                    Else
                        nTIIE = drTIIE("Promedio")
                    End If

                End If

                ' Construir el cierre de mes 

                cFechaFinal = DTOC(DateAdd(DateInterval.Day, -1, CTOD(Mid(DTOC(DateAdd(DateInterval.Month, 1, CTOD(cFechaInicial))), 1, 6) & "01")))

                If cFechaFinal > cFechaCorte Then
                    cFechaFinal = cFechaCorte
                End If

                If i = 1 Then
                    nDias = DateDiff(DateInterval.Day, CTOD(cFechaInicial), CTOD(cFechaFinal))
                Else
                    nDias = DateDiff(DateInterval.Day, CTOD(cFechaInicial), CTOD(cFechaFinal)) + 1
                End If

                If cTipta <> "7" Then
                    nTasaAplicable = Round(nTIIE + nDiferencial, 4)
                End If

                If cFechaFinal > cFechaTerminacion Then
                    nTasaAplicable = Round(nTasaAplicable * 3, 4)
                End If
                nInteres = Round(nSaldoInicial * nTasaAplicable / 36000 * nDias, 2)

                drTemporal = dtIntereses.NewRow()
                drTemporal("Anexo") = cAnexo
                drTemporal("SaldoInicial") = nImporte
                drTemporal("FechaInicial") = cFechaInicial
                drTemporal("FechaFinal") = cFechaFinal
                drTemporal("Dias") = nDias
                drTemporal("Tasa") = nTasaAplicable
                drTemporal("Interes") = nInteres
                dtIntereses.Rows.Add(drTemporal)

                cFechaInicial = DTOC(DateAdd(DateInterval.Day, 1, CTOD(cFechaFinal)))

                ' Por instrucción del Director General, los interereses moratorios pasarán a formar parte del cálculo del interés del mes siguiente

                nSaldoInicial = nSaldoInicial + nInteres

            Next

        ElseIf cReferencia = "FIRA" Then

        End If

        InteresAcumulado = dtIntereses

    End Function

End Module
