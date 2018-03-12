Option Explicit On

Imports System.Data.SqlClient

Module mProvAvio

    Private Structure Movimiento
        Public Cve As String
        Public Anexo As String
        Public Imp As Decimal
        Public Tipar As String
        Public Coa As String
        Public Fecha As String
        Public Tipmov As String
        Public Banco As String
        Public Concepto As String
        Public Segmento As String
    End Structure

    Public Sub ProvAvio(ByVal cFecha As String, ByVal cReferencia As String)

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daAnexos As New SqlDataAdapter(cm1)
        Dim dsAgil As New DataSet()
        Dim dtTIIE As New DataTable()
        Dim dtSegmentos As New DataTable()
        Dim drSegmento As DataRow
        Dim drAnexo As DataRow
        Dim aPrimaryKey(1) As DataColumn
        Dim drTemporal As DataRow
        Dim strInsert As String

        ' Declaración de variables de datos

        Dim aMovimiento As New Movimiento()
        Dim aMovimientos As New ArrayList()
        Dim cAnexo As String = ""
        Dim cCiclo As String = ""
        Dim cSegmentoNegocio As String = ""
        Dim cTipar As String = ""
        Dim cTipMov As String = ""
        Dim myKeySearch(1) As String
        Dim nInteres As Decimal = 0

        ' Lo primero que tengo que hacer es crear la tabla dtSegmentos en donde acumularé los intereses por Tipo de Producto y por Segmento de Negocio

        dtSegmentos.Columns.Add("Tipar", Type.GetType("System.String"))
        dtSegmentos.Columns.Add("Segmento", Type.GetType("System.String"))
        dtSegmentos.Columns.Add("Imp", Type.GetType("System.Decimal"))

        ' Ahora defino una LLAVE PRIMARIA COMPUESTA en la tabla dtSegmentos para poder buscar un Tipo de Producto y Segmento de Negocio en particular

        aPrimaryKey(0) = dtSegmentos.Columns("Tipar")
        aPrimaryKey(1) = dtSegmentos.Columns("Segmento")

        dtSegmentos.PrimaryKey = aPrimaryKey

        If cReferencia = "FINAGIL" Then

            cTipMov = "14"

            ' El siguiente Command trae los contratos ACTIVOS a los que se les haya ministrado recursos FINAGIL-Productor que tengan saldo

            With cm1
                .CommandType = CommandType.Text
                .CommandText = "SELECT Avios.Tipar, DetalleFINAGIL.Anexo, DetalleFINAGIL.Ciclo, Segmento_Negocio, SUM(Intereses) AS Provision FROM DetalleFINAGIL " & _
                               "INNER JOIN Avios ON DetalleFINAGIL.Anexo = Avios.Anexo AND DetalleFINAGIL.Ciclo = Avios.Ciclo " & _
                               "INNER JOIN Clientes ON Avios.Cliente = Clientes.Cliente " & _
                               "INNER JOIN Sucursales ON Clientes.Sucursal = Sucursales.ID_Sucursal " & _
                               "WHERE Avios.FechaTerminacion > '" & cFecha & "' AND DetalleFINAGIL.FechaFinal <= '" & cFecha & "' " & _
                               "GROUP BY Avios.Tipar, DetalleFINAGIL.Anexo, DetalleFINAGIL.Ciclo, Segmento_Negocio " & _
                               "HAVING SUM(Intereses) > 0 " & _
                               "ORDER BY Anexo"
                .Connection = cnAgil
            End With

            daAnexos.Fill(dsAgil, "Anexos")

            For Each drAnexo In dsAgil.Tables("Anexos").Rows

                cTipar = drAnexo("Tipar")
                cAnexo = drAnexo("Anexo")
                cCiclo = drAnexo("Ciclo")
                cSegmentoNegocio = drAnexo("Segmento_Negocio")
                nInteres = drAnexo("Provision")

                With aMovimiento
                    .Cve = "71"
                    .Anexo = cAnexo
                    .Imp = nInteres
                    .Tipar = cTipar
                    .Coa = "0"
                    .Fecha = cFecha
                    .Tipmov = cTipMov
                    .Banco = ""
                    .Concepto = ""
                    .Segmento = cSegmentoNegocio
                End With
                aMovimientos.Add(aMovimiento)

            Next

            For Each aMovimiento In aMovimientos

                ' Sumarizo los importes por Segmento de Negocio

                myKeySearch(0) = aMovimiento.Tipar
                myKeySearch(1) = aMovimiento.Segmento

                drTemporal = dtSegmentos.Rows.Find(myKeySearch)

                If drTemporal Is Nothing Then
                    drSegmento = dtSegmentos.NewRow()
                    drSegmento("Tipar") = aMovimiento.Tipar
                    drSegmento("Segmento") = aMovimiento.Segmento
                    drSegmento("Imp") = aMovimiento.Imp
                    dtSegmentos.Rows.Add(drSegmento)
                Else
                    drTemporal("Imp") += aMovimiento.Imp
                End If

            Next

            For Each drTemporal In dtSegmentos.Rows
                With aMovimiento
                    .Cve = "74"
                    .Anexo = ""
                    .Imp = drTemporal("Imp")
                    .Tipar = drTemporal("Tipar")
                    .Coa = "1"
                    .Fecha = cFecha
                    .Tipmov = cTipMov
                    .Banco = ""
                    .Concepto = ""
                    .Segmento = drTemporal("Segmento")
                End With
                aMovimientos.Add(aMovimiento)
            Next

        ElseIf cReferencia = "FIRA" Then

            'cTipMov = "13"

            '' Tengo que traer todas las ministraciones que nos ha hecho FIRA a la fecha y por cada una tengo que
            '' determinar el interés pasivo desde la fecha en que se ministró y hasta la fecha del reporte. Este es
            '' el importe que debo cargar aunque aparentemente se duplique la provisión ya que FIRA cada mes nos
            '' cobra los intereses aunque al mismo tiempo nos reembolsa una cantidad mayor (llamado FINANCIAMIENTO
            '' ADICIONAL).

            '' Entonces, cuando FIRA nos haga el cargo por intereses debemos cancelar la provisión y 
            '' cuando FIRA nos haga el abono por FINANCIAMIENTO ADICIONAL debemos registrarlo en la cuenta de
            '' la provisión y así sucesivamente hasta el final del plazo.

            '' Los intereses NO son capitalizables y NO nos cobran intereses sobre el FINANCIAMIENTO ADICIONAL

            '' El siguiente Command trae los contratos de los cuales FIRA nos haya ministrado recursos

            'With cm1
            '    .CommandType = CommandType.Text
            '    .CommandText = "SELECT DISTINCT Anexo FROM mFIRA WHERE Estado <> 'LIQUIDADO' AND FechaProgramada <= " & "'" & cFecha & "'" & " ORDER BY Anexo"
            '    .Connection = cnAgil
            'End With

            '' El siguiente Command trae los datos de todas las ministraciones FIRA - FINAGIL

            'With cm2
            '    .CommandType = CommandType.Text
            '    .CommandText = "SELECT mFIRA.Anexo, FechaProgramada, Importe, DiferencialFINAGIL, DiferencialFIRA FROM mFIRA INNER JOIN Avios ON mFIRA.Anexo = Avios.Anexo WHERE Estado <> 'LIQUIDADO' AND FechaProgramada <= " & "'" & cFecha & "'" & " ORDER BY Anexo"
            '    .Connection = cnAgil
            'End With

            '' Llenar el DataSet a través del DataAdapter, lo cual abre y cierra la conexión

            'daAnexos.Fill(dsAgil, "Anexos")
            'daMinistracion.Fill(dsAgil, "Ministraciones")

            'relAnexosMinistraciones = New DataRelation("AnexosMinistraciones", dsAgil.Tables("Anexos").Columns("Anexo"), dsAgil.Tables("Ministraciones").Columns("Anexo"))
            'dsAgil.EnforceConstraints = False
            'dsAgil.Relations.Add(relAnexosMinistraciones)
            'dsAgil.EnforceConstraints = True

            '' Genero la tabla que contiene las TIIE promedio por mes 
            '' Para FIRA no considera días festivos ni sábados ni domingos y redondea a 4 decimales

            'dtTIIE = TIIEavg("FIRA")

            'For Each drAnexo In dsAgil.Tables("Anexos").Rows

            '    drMinistraciones = drAnexo.GetChildRows("AnexosMinistraciones")

            '    nInteres = 0

            '    For Each drMinistracion In drMinistraciones

            '        cAnexo = drMinistracion("Anexo")

            '        cFechaDocumento = drMinistracion("FechaProgramada")
            '        nDiferencialFINAGIL = drMinistracion("DiferencialFINAGIL")
            '        nDiferencialFIRA = drMinistracion("DiferencialFIRA")
            '        nImporte = drMinistracion("Importe")

            '        ' En esta parte proceso el importe correspondiente a la ministración

            '        For Each drTemporal In InteresAcumulado(cAnexo, cTipta, cReferencia, cFechaDocumento, nImporte, nTasas, nDiferencialFINAGIL, cFecha, dtTIIE, cFechaTerminacion).Rows
            '            If Mid(drTemporal("FechaFinal"), 1, 6) = Mid(cFecha, 1, 6) Then
            '                nInteres += drTemporal("InteresPasivo")
            '            End If
            '        Next

            '    Next

            '    nSumaInteres += nInteres

            '    With aMovimiento
            '        .Cve = "70"
            '        .Anexo = cAnexo
            '        .Imp = nInteres
            '        .Tipar = "H"
            '        .Coa = "2"
            '        .Fecha = cFecha
            '        .Tipmov = cTipMov
            '        .Banco = "  "
            '    End With
            '    aMovimientos.Add(aMovimiento)

            'Next

            'If nSumaInteres > 0 Then
            '    With aMovimiento
            '        .Cve = "69"
            '        .Anexo = cAnexo
            '        .Imp = nSumaInteres
            '        .Tipar = "H"
            '        .Coa = "1"
            '        .Fecha = cFecha
            '        .Tipmov = cTipMov
            '        .Banco = "  "
            '    End With
            '    aMovimientos.Add(aMovimiento)
            'End If

        End If

        cnAgil.Open()
        For Each aMovimiento In aMovimientos
            strInsert = "INSERT INTO Auxiliar(Cve, Anexo, Imp, Tipar, Coa, Fecha, Tipmov, Banco, Concepto, Segmento)"
            strInsert = strInsert & " VALUES ('"
            strInsert = strInsert & aMovimiento.Cve & "', '"
            strInsert = strInsert & aMovimiento.Anexo & "', '"
            strInsert = strInsert & aMovimiento.Imp & "', '"
            strInsert = strInsert & aMovimiento.Tipar & "', '"
            strInsert = strInsert & aMovimiento.Coa & "', '"
            strInsert = strInsert & aMovimiento.Fecha & "', '"
            strInsert = strInsert & aMovimiento.Tipmov & "', '"
            strInsert = strInsert & aMovimiento.Banco & "', '"
            strInsert = strInsert & aMovimiento.Concepto & "', '"
            strInsert = strInsert & aMovimiento.Segmento
            strInsert = strInsert & "')"
            cm1 = New SqlCommand(strInsert, cnAgil)
            cm1.ExecuteNonQuery()
        Next
        cnAgil.Close()

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

End Module
