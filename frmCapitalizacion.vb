Option Explicit On

Imports System.Data.SqlClient
Imports System.Math

Public Class frmCapitalizacion

    Public Sub New(ByVal cAnexo As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.Text = "Capitalización de Adeudo del Contrato " & cAnexo
        txtAnexo.Text = cAnexo

    End Sub

    Private Sub frmCapitalizacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim dsAgil As New DataSet()
        Dim daAnexos As New SqlDataAdapter(cm1)
        Dim daEdoctav As New SqlDataAdapter(cm2)
        Dim daEdoctao As New SqlDataAdapter(cm3)
        Dim drEdoctav As DataRow()
        Dim drAnexo As DataRow
        Dim drDato As DataRow
        Dim relAnexoEdoctav As DataRelation

        ' Declaración de variables de datos

        Dim cAnexo As String
        Dim cFecha As String
        Dim cFeven As String
        Dim nVencimiento As Int32
        Dim nPlazo As Int32
        Dim nIntEquipo As Decimal
        Dim nCarEquipo As Decimal
        Dim nSaldoEquipo As Decimal
        Dim nSaldoAnt As Decimal
        Dim nTasaApli As Decimal
        Dim nCount As Integer

        cAnexo = Mid(txtAnexo.Text, 1, 5) & Mid(txtAnexo.Text, 7, 4)
        cFecha = DTOC(Today)

        ' El siguiente Stored Procedure trae todos los atributos de la tabla Anexos,
        ' para un anexo dado

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DatosCon1"
            .Connection = cnAgil
            .Parameters.Add("@Anexo", SqlDbType.NVarChar)
            .Parameters(0).Value = cAnexo
        End With

        ' Con este Stored Procedure obtengo la tabla de amortización del Equipo

        With cm2
            .CommandType = CommandType.StoredProcedure
            .CommandText = "TablaEquipo1"
            .Connection = cnAgil
            .Parameters.Add("@Anexo", SqlDbType.NVarChar)
            .Parameters(0).Value = cAnexo
        End With

        ' Con este Stored Procedure obtengo la información de adeudos 
        ' capitalizados anteriormente para un contrato dado

        With cm3
            .CommandType = CommandType.StoredProcedure
            .CommandText = "TraeAdeudos"
            .Connection = cnAgil
            .Parameters.Add("@Anexo", SqlDbType.NVarChar)
            .Parameters(0).Value = cAnexo
        End With

        ' Llenar el DataSet lo cual abre y cierra la conexión

        daAnexos.Fill(dsAgil, "Anexos")
        daEdoctav.Fill(dsAgil, "Edoctav")
        daEdoctao.Fill(dsAgil, "Edoctao")

        ' Establecer la relación entre Anexos y Edoctav

        relAnexoEdoctav = New DataRelation("AnexoEdoctav", dsAgil.Tables("Anexos").Columns("Anexo"), dsAgil.Tables("Edoctav").Columns("Anexo"))
        dsAgil.EnforceConstraints = False
        dsAgil.Relations.Add(relAnexoEdoctav)

        ' Validando que el contrato esté Activo

        drAnexo = dsAgil.Tables("Anexos").Rows(0)
        nCount = dsAgil.Tables("Edoctao").Rows.Count
        nTasaApli = (drAnexo("Tasas") + drAnexo("Difer")) / 1200

        If drAnexo("Flcan") <> "A" Then

            MsgBox("El contrato NO esta activo", MsgBoxStyle.OkOnly, "Mensaje")
            Me.Close()

        Else

            ' Validando que el Contrato tenga saldo insoluto 
            ' (que tenga por lo menos un mes por transcurrir) 

            drEdoctav = drAnexo.GetChildRows("AnexoEdoctav")

            nIntEquipo = 0
            nCarEquipo = 0
            nSaldoEquipo = 0

            TraeSald(drEdoctav, cFecha, nSaldoEquipo, nIntEquipo, nCarEquipo)

            If nSaldoEquipo = 0 Then

                MsgBox("Contrato SIN saldo insoluto", MsgBoxStyle.OkOnly, "Mensaje")
                Me.Close()

            Else

                ' Identificamos a partir de cuál vencimiento inicia la reestructura

                nVencimiento = 0
                nPlazo = 0
                For Each drDato In drEdoctav
                    If drDato("Nufac") = 0 And drDato("Indrec") = "S" Then
                        nPlazo += 1
                        If nVencimiento = 0 Then
                            nVencimiento = Val(drDato("Letra"))
                            cFeven = drDato("Feven")
                            txtFven.Text = cFeven
                        End If
                    End If
                Next
                txtTap.Text = nTasaApli
                txtVen.Text = nVencimiento
                txtPzo.Text = nPlazo

                If nPlazo = 1 Then
                    lblPlazomax.Text = "Le queda " & nPlazo.ToString & " mes de plazo para poder capitalizar su Adeudo"
                Else
                    lblPlazomax.Text = "Le quedan " & nPlazo.ToString & " meses de plazo para poder capitalizar su Adeudo"
                End If

                If nCount > 0 Then
                    lblAdeudoant.Visible = True
                    lblAdeudoant.Text = "El Contrato ya cuenta con una capitalización de adeudo anterior"
                    txtAde.Text = "S"
                    nSaldoAnt = 0
                    For Each drDato In dsAgil.Tables("Edoctao").Rows
                        If drDato("Nufac") = 0 And drDato("Indrec") = "S" Then
                            If nSaldoAnt = 0 Then
                                nSaldoAnt = drDato("Saldo")
                            End If
                        End If
                    Next
                End If
                txtSant.Text = nSaldoAnt

                If nVencimiento = 0 Then
                    MsgBox("Existe algún ERROR en el contrato", MsgBoxStyle.OkOnly, "Mensaje")
                    Me.Close()
                End If
            End If
        End If

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()

    End Sub

    Private Sub btnIniciar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIniciar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim drDato As DataRow
        Dim dtCreaTabla As New DataTable("Adeudos")

        ' Declaración de variables de datos

        Dim cAnexo As String
        Dim cFecha As String
        Dim cFeven As String
        Dim cString As String
        Dim nVencimiento As Int32
        Dim nVenciAnt As Int32
        Dim i As Integer
        Dim nPlazo As Integer
        Dim nSaldo As Decimal
        Dim nInteres As Decimal
        Dim nCapital As Decimal
        Dim nIva As Decimal
        Dim nTasaApli As Decimal
        Dim nRenta As Decimal
        Dim nSdoAnt As Decimal

        cAnexo = Mid(txtAnexo.Text, 1, 5) & Mid(txtAnexo.Text, 7, 4)
        cFecha = DTOC(Today)
        nVencimiento = txtVen.Text
        nPlazo = txtPzo.Text
        nSdoAnt = txtSant.Text
        nTasaApli = txtTap.Text
        cFeven = txtFven.Text
        txtRow.Text = 1

        If Val(txtPlazo.Text) > Val(txtPzo.Text) Then
            MsgBox("El plazo máximo es de " & txtPzo.Text, MsgBoxStyle.OkOnly, "Mensaje")
        End If

        If Val(txtMonto.Text) > 0 And txtPlazo.Text <= nPlazo Then

            nSaldo = txtMonto.Text + nSdoAnt
            nRenta = Round((nSaldo * nTasaApli) / (1 - Pow((1 + nTasaApli), -txtPlazo.Text)), 2)

            ' Defino una Tabla Temporal para cargar la capitalización

            dtCreaTabla.Columns.Add("Anexo", Type.GetType("System.String"))
            dtCreaTabla.Columns.Add("Letra", Type.GetType("System.String"))
            dtCreaTabla.Columns.Add("Feven", Type.GetType("System.String"))
            dtCreaTabla.Columns.Add("Nufac", Type.GetType("System.Decimal"))
            dtCreaTabla.Columns.Add("Saldo", Type.GetType("System.String"))
            dtCreaTabla.Columns.Add("Capital", Type.GetType("System.String"))
            dtCreaTabla.Columns.Add("Interes", Type.GetType("System.String"))
            dtCreaTabla.Columns.Add("Iva", Type.GetType("System.String"))

            For i = 1 To txtPlazo.Text
                If i = 1 And nSdoAnt > 0 Then
                    nVenciAnt = txtVen.Text - 1
                    drDato = dtCreaTabla.NewRow()
                    drDato("Anexo") = cAnexo
                    drDato("Letra") = Stuff(nVenciAnt.ToString, i, 0, 3)
                    drDato("Feven") = Mid(Today.ToString, 1, 10)
                    drDato("Nufac") = 7777777
                    drDato("Saldo") = nSdoAnt
                    drDato("Capital") = -txtMonto.Text
                    drDato("Interes") = 0
                    drDato("Iva") = 0
                    dtCreaTabla.Rows.Add(drDato)
                    txtRow.Text = 0
                End If

                cString = Stuff(nVencimiento.ToString, i, 0, 3)
                If i > 1 Then
                    cFeven = DTOC(DateAdd(DateInterval.Month, 1, CTOD(cFeven)))
                End If
                nInteres = Round(nSaldo * txtTap.Text, 2)
                nCapital = Round(nRenta - nInteres, 2)
                nIva = Round(nInteres * 0.15, 2)
                drDato = dtCreaTabla.NewRow()
                drDato("Anexo") = cAnexo
                drDato("Letra") = cString
                drDato("Feven") = CTOD(cFeven).ToShortDateString
                If Val(Mid(cFeven, 7, 2)) > 25 Then
                    drDato("Feven") = DayWeek(CTOD(cFeven).ToShortDateString)
                End If
                drDato("Nufac") = 0
                drDato("Saldo") = nSaldo
                drDato("Capital") = nCapital
                drDato("Interes") = nInteres
                drDato("Iva") = nIva
                dtCreaTabla.Rows.Add(drDato)
                nSaldo = nSaldo - nCapital
                nVencimiento += 1
            Next
            DataGrid1.DataSource = dtCreaTabla
            DataGrid1.Visible = True
            btnSave.Enabled = True
            btnIniciar.Enabled = False
        End If

    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim cm4 As New SqlCommand()
        Dim strInsert As String
        Dim strUpdate As String

        ' Declaración de variables de datos

        Dim cAnexo As String
        Dim cFecha As String
        Dim nVencimiento As Int32
        Dim i As Int32

        cFecha = DTOC(Today)
        nVencimiento = Val(txtPlazo.Text) - Val(txtRow.Text)
        cAnexo = Mid(txtAnexo.Text, 1, 5) & Mid(txtAnexo.Text, 7, 4)

        Try

            cnAgil.Open()

            If txtAde.Text = "S" Then

                With cm3
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "BorraAdeudo"
                    .Connection = cnAgil
                    .Parameters.Add("@Anexo", SqlDbType.NVarChar)
                    .Parameters(0).Value = cAnexo
                End With
                cm3.ExecuteNonQuery()

            End If

            For i = 0 To nVencimiento
                strInsert = "INSERT INTO Edoctao( Anexo, Letra, Feven, Nufac, Indrec, Saldo, Abcap, Inter, Iva )"
                strInsert = strInsert & "VALUES('"
                strInsert = strInsert & DataGrid1.Item(i, 0) & "', '"
                strInsert = strInsert & DataGrid1.Item(i, 1) & "', '"
                strInsert = strInsert & DTOC(DataGrid1.Item(i, 2)) & "', '"
                strInsert = strInsert & DataGrid1.Item(i, 3) & "', '"
                strInsert = strInsert & "S" & "', '"
                strInsert = strInsert & DataGrid1.Item(i, 4) & "', '"
                strInsert = strInsert & DataGrid1.Item(i, 5) & "', '"
                strInsert = strInsert & DataGrid1.Item(i, 6) & "', '"
                strInsert = strInsert & DataGrid1.Item(i, 7) & "')"
                cm1 = New SqlCommand(strInsert, cnAgil)
                cm1.ExecuteNonQuery()
            Next

            strUpdate = "UPDATE Anexos SET  Adeudo = 'S'" & ""
            strUpdate = strUpdate & " WHERE Anexo = '" & cAnexo & "'"
            cm2 = New SqlCommand(strUpdate, cnAgil)
            cm2.ExecuteNonQuery()
            cnAgil.Close()

        Catch eException As Exception

            MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje")

        End Try

        MsgBox("Datos actualizados", MsgBoxStyle.Information, "Mensaje del Sistema")

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()
        btnSave.Enabled = False
    End Sub

    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class