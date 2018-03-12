Option Explicit On

Imports System.Data.SqlClient
Imports System.Math

Module mEdoCtaFB

    Public Function EdoCtaFB(ByVal cFechaProceso As String) As DataTable

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim daCreditos As New SqlDataAdapter(cm1)
        Dim daMovimientos As New SqlDataAdapter(cm2)

        Dim dsAgil As New DataSet()
        Dim dtDetalle As New DataTable("Detalle")
        Dim dtTIIE As New DataTable()
        Dim drCredito As DataRow
        Dim drTIIE As DataRow
        Dim drMovimientos As DataRow()
        Dim drMovimiento As DataRow
        Dim relCreditosMovimientos As DataRelation
        Dim myKeySearch(0) As String
        Dim drTemporal As DataRow

        ' Declaración de variables de datos

        Dim cAcreditado As String = ""
        Dim cAnexo As String = ""
        Dim cFechaFinal As String = ""
        Dim cFechaInicial As String = ""
        Dim cIDCredito As String = ""
        Dim cTipoCredito As String = ""
        Dim cTipta As String = ""
        Dim cUltimoCorte As String = ""
        Dim dFechaFinal As Date
        Dim dFechaInicial As Date
        Dim nCapital As Decimal = 0
        Dim nDiasInteres As Integer = 0
        Dim nDiferencialBP As Decimal = 0
        Dim nDiferencialFB As Decimal = 0
        Dim nFIFAP As Decimal = 0
        Dim nFinanciados As Decimal = 0
        Dim nIntereses As Decimal = 0
        Dim nInteresesFinanciados As Decimal = 0
        Dim nInteresesOrdinarios As Decimal = 0
        Dim nMinistracionBase As Decimal = 0
        Dim nSaldoCapital As Decimal = 0
        Dim nSaldoFinal As Decimal = 0
        Dim nSaldoFinanciados As Decimal = 0
        Dim nSaldoInicial As Decimal = 0
        Dim nSaldoIntereses As Decimal = 0
        Dim nTasaBP As Decimal = 0
        Dim nTasaFB As Decimal = 0
        Dim nTIIE As Decimal = 0

        ' Primero creo la tabla dtDetalle para guardar la información resultante, recordando que el último registro
        ' es virtual (no debe afectar la tabla DetalleFIRA).

        dtDetalle.Columns.Add("Acreditado", Type.GetType("System.String"))
        dtDetalle.Columns.Add("IDCredito", Type.GetType("System.String"))
        dtDetalle.Columns.Add("Capital", Type.GetType("System.Decimal"))
        dtDetalle.Columns.Add("Financiados", Type.GetType("System.Decimal"))
        dtDetalle.Columns.Add("Intereses", Type.GetType("System.Decimal"))
        dtDetalle.Columns.Add("AdeudoTotal", Type.GetType("System.Decimal"))
        dtDetalle.Columns.Add("FechaInicial", Type.GetType("System.String"))    ' Este campo se utiliza en el registro de pagos Banca-FIRA
        dtDetalle.Columns.Add("SaldoInicial", Type.GetType("System.Decimal"))   ' Este campo se utiliza en el registro de pagos Banca-FIRA
        dtDetalle.Columns.Add("Anexo", Type.GetType("System.String"))           ' Este campo se utiliza en el registro de pagos Banca-FIRA
        dtDetalle.Columns.Add("TasaFB", Type.GetType("System.Decimal"))         ' Este campo se utiliza en el registro de pagos Banca-FIRA
        dtDetalle.Columns.Add("TasaBP", Type.GetType("System.Decimal"))         ' Este campo se utiliza en el registro de pagos Banca-FIRA
        dtDetalle.Columns.Add("TipoCredito", Type.GetType("System.String"))     ' Este campo se utiliza en el registro de pagos Banca-FIRA

        ' Tengo que tomar todos los créditos que a la fecha de proceso tengan saldo

        With cm1
            .CommandType = CommandType.Text
            .CommandText = "SELECT DetalleFIRA.IDCredito, Descr, Tipta, PasivoFIRA.TasaFB, DiferencialFB, PasivoFIRA.TasaBP, DiferencialBP, FIFAP, Anexo, TipoCredito, UltimoCorte FROM DetalleFIRA " & _
                           "INNER JOIN PasivoFIRA ON DetalleFIRA.IDCredito = PasivoFIRA.IDCredito " & _
                           "INNER JOIN Clientes ON PasivoFIRA.Cliente = Clientes.Cliente " & _
                           "GROUP BY DetalleFIRA.IDCredito, Descr, Tipta, PasivoFIRA.TasaFB, DiferencialFB, PasivoFIRA.TasaBP, DiferencialBP, FIFAP, Anexo, TipoCredito, UltimoCorte " & _
                           "HAVING(Round(SUM(MinistracionBase) - SUM(Capital), 2) > 0) " & _
                           "ORDER BY Descr, DetalleFIRA.IDCredito"
            .Connection = cnAgil
        End With

        ' Necesito traer todos los movimientos que existan en DetalleFIRA para cada uno de estos créditos

        With cm2
            .CommandType = CommandType.Text
            .CommandText = "SELECT * FROM DetalleFIRA WHERE IDCredito IN " & _
                           "(" & _
                           "SELECT DetalleFIRA.IDCredito FROM DetalleFIRA " & _
                           "INNER JOIN PasivoFIRA ON DetalleFIRA.IDCredito = PasivoFIRA.IDCredito " & _
                           "GROUP BY DetalleFIRA.IDCredito " & _
                           "HAVING(Round(SUM(MinistracionBase) - SUM(Capital), 2) > 0) " & _
                           ") " & _
                           "ORDER BY IDCredito, FechaFinal, SaldoFinal"
            .Connection = cnAgil
        End With

        ' Llenar el dataset lo cual abre y cierra la conexión

        daCreditos.Fill(dsAgil, "Creditos")
        daMovimientos.Fill(dsAgil, "Movimientos")

        ' Crear la relación entre Creditos y Movimientos

        relCreditosMovimientos = New DataRelation("CreditosMovimientos", dsAgil.Tables("Creditos").Columns("IDCredito"), dsAgil.Tables("Movimientos").Columns("IDCredito"))
        dsAgil.EnforceConstraints = False
        dsAgil.Relations.Add(relCreditosMovimientos)
        dsAgil.EnforceConstraints = True

        ' Genero la tabla que contiene las TIIE promedio por mes 
        ' Para FIRA considera los días en que BANXICO publica el valor de la TIIE y redondea a 4 decimales

        dtTIIE = TIIEavg("FIRA")

        ' Construyo una fecha que me permita buscar el promedio de la tasa TIIE del mes inmediato anterior al de la fecha de proceso

        myKeySearch(0) = Mid(DTOC(DateAdd(DateInterval.Month, -1, CTOD(cFechaProceso))), 1, 6)

        drTIIE = dtTIIE.Rows.Find(myKeySearch)

        If drTIIE Is Nothing Then
            nTIIE = 0
        Else
            nTIIE = drTIIE("Promedio")
        End If

        For Each drCredito In dsAgil.Tables("Creditos").Rows

            cIDCredito = drCredito("IDCredito")
            cAcreditado = drCredito("Descr")
            cAnexo = drCredito("Anexo")
            cTipta = drCredito("Tipta")
            cTipoCredito = drCredito("TipoCredito")
            cUltimoCorte = drCredito("UltimoCorte")

            drMovimientos = drCredito.GetChildRows("CreditosMovimientos")

            If cTipta = "6" Then
                nDiferencialFB = drCredito("DiferencialFB")
                nDiferencialBP = drCredito("DiferencialBP")
                nFIFAP = drCredito("FIFAP")
                nTasaFB = nTIIE + nDiferencialFB
                nTasaBP = nTIIE + nDiferencialBP
                If nTasaFB < 0 Then
                    nTasaFB = 0
                End If
                nTasaFB = nTasaFB + nFIFAP
                If nTasaBP < 0 Then
                    nTasaBP = 0
                End If
            Else
                nDiferencialFB = 0
                nDiferencialBP = 0
                nTasaFB = drCredito("TasaFB")
                nTasaBP = drCredito("TasaBP")
            End If

            nSaldoCapital = 0
            nSaldoFinanciados = 0
            nSaldoIntereses = 0

            For Each drMovimiento In drMovimientos

                cFechaInicial = drMovimiento("FechaInicial")
                cFechaFinal = drMovimiento("FechaFinal")

                ' Solamente procesaré los registros anteriores o iguales a la fecha de proceso. Esto con la finalidad
                ' de poder obtener un saldo a una fecha anterior a la de corte.

                If cFechaFinal <= cFechaProceso Then

                    nMinistracionBase = drMovimiento("MinistracionBase")
                    nInteresesFinanciados = drMovimiento("InteresesFinanciados")
                    nInteresesOrdinarios = drMovimiento("InteresesOrdinarios")

                    nCapital = drMovimiento("Capital")
                    nFinanciados = drMovimiento("Financiados")
                    nIntereses = drMovimiento("Intereses")

                    nSaldoCapital = nSaldoCapital + nMinistracionBase - nCapital
                    nSaldoFinanciados = nSaldoFinanciados + nInteresesFinanciados - nFinanciados
                    nSaldoIntereses = nSaldoIntereses + nInteresesOrdinarios - nIntereses

                    nSaldoInicial = drMovimiento("SaldoInicial")
                    nSaldoFinal = drMovimiento("SaldoFinal")

                End If

            Next

            ' Solamente realizo cálculos si la fecha de proceso es mayor a la fecha de ultimo corte.
            ' Necesito tener cuidado que la fecha de proceso no exceda 1 mes o algo así

            If cFechaProceso > cUltimoCorte Then

                cFechaInicial = cFechaFinal
                cFechaFinal = cFechaProceso

                dFechaInicial = CTOD(cFechaInicial)
                dFechaFinal = CTOD(cFechaFinal)
                nSaldoInicial = nSaldoFinal
                nDiasInteres = DateDiff(DateInterval.Day, dFechaInicial, dFechaFinal)

                nInteresesOrdinarios = nSaldoInicial * (nTasaFB) / 36000 * nDiasInteres
                nInteresesOrdinarios = Round(nInteresesOrdinarios, 2)

                If nInteresesOrdinarios > 0 Then

                    ' Esta validación se hace por si se emite el Estado de Cuenta el mismo día que se aplicó un pago,
                    ' no aparezca un renglón en el que la fecha inicial y la fecha final son iguales,
                    ' y el saldo inicial y final también son iguales.

                    nSaldoFinal = nSaldoFinal + nInteresesOrdinarios
                    nSaldoIntereses = nSaldoIntereses + nInteresesOrdinarios

                End If

            End If

            drTemporal = dtDetalle.NewRow()
            drTemporal("IDCredito") = cIDCredito
            drTemporal("Acreditado") = RTrim(cAcreditado)
            drTemporal("Capital") = nSaldoCapital
            drTemporal("Financiados") = nSaldoFinanciados
            drTemporal("Intereses") = nSaldoIntereses
            drTemporal("AdeudoTotal") = Round(nSaldoCapital + nSaldoFinanciados + nSaldoIntereses, 2)
            drTemporal("FechaInicial") = cFechaInicial
            drTemporal("SaldoInicial") = nSaldoFinal
            drTemporal("Anexo") = cAnexo
            drTemporal("TasaFB") = nTasaFB
            drTemporal("TasaBP") = nTasaBP
            drTemporal("TipoCredito") = cTipoCredito
            dtDetalle.Rows.Add(drTemporal)

        Next

        cm1.Dispose()
        cm2.Dispose()
        cnAgil.Dispose()

        EdoCtaFB = dtDetalle

    End Function

End Module
