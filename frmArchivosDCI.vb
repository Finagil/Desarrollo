Option Explicit On 

Imports System.Math
Imports System.Data.SqlClient
Imports System.IO
Imports System.Text.ASCIIEncoding

Public Class frmArchivosDCI

    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents lblInicio As System.Windows.Forms.Label
    Friend WithEvents btnImpAvisos As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DateTimePicker3 As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnTarjeta As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmArchivosDCI))
        Me.lblInicio = New System.Windows.Forms.Label
        Me.btnImpAvisos = New System.Windows.Forms.Button
        Me.btnTarjeta = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.DateTimePicker3 = New System.Windows.Forms.DateTimePicker
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblInicio
        '
        Me.lblInicio.Location = New System.Drawing.Point(9, 18)
        Me.lblInicio.Name = "lblInicio"
        Me.lblInicio.Size = New System.Drawing.Size(101, 16)
        Me.lblInicio.TabIndex = 0
        Me.lblInicio.Text = "Fecha a Procesar"
        '
        'btnImpAvisos
        '
        Me.btnImpAvisos.Location = New System.Drawing.Point(130, 37)
        Me.btnImpAvisos.Name = "btnImpAvisos"
        Me.btnImpAvisos.Size = New System.Drawing.Size(104, 23)
        Me.btnImpAvisos.TabIndex = 4
        Me.btnImpAvisos.Text = "Imprime Avisos"
        '
        'btnTarjeta
        '
        Me.btnTarjeta.Location = New System.Drawing.Point(242, 37)
        Me.btnTarjeta.Name = "btnTarjeta"
        Me.btnTarjeta.Size = New System.Drawing.Size(104, 23)
        Me.btnTarjeta.TabIndex = 25
        Me.btnTarjeta.Text = "Imprime Tarjetas"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DateTimePicker3)
        Me.GroupBox1.Controls.Add(Me.btnTarjeta)
        Me.GroupBox1.Controls.Add(Me.btnImpAvisos)
        Me.GroupBox1.Controls.Add(Me.lblInicio)
        Me.GroupBox1.Location = New System.Drawing.Point(20, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(357, 75)
        Me.GroupBox1.TabIndex = 26
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Procesar Avisos"
        '
        'DateTimePicker3
        '
        Me.DateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker3.Location = New System.Drawing.Point(14, 40)
        Me.DateTimePicker3.Name = "DateTimePicker3"
        Me.DateTimePicker3.Size = New System.Drawing.Size(88, 20)
        Me.DateTimePicker3.TabIndex = 26
        '
        'frmArchivosDCI
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(397, 112)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmArchivosDCI"
        Me.Text = "Generar Archivos de texto para DCI"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnImpAvisos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnImpAvisos.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim cm3 As New SqlCommand()
        Dim cm4 As New SqlCommand()
        Dim cm5 As New SqlCommand()
        Dim cm6 As New SqlCommand()
        Dim daAvisos As New SqlDataAdapter(cm1)
        Dim daCambio As New SqlDataAdapter(cm2)
        Dim daRetener As New SqlDataAdapter(cm3)
        Dim daAgrupa As New SqlDataAdapter(cm4)
        Dim daUdis As New SqlDataAdapter(cm5)
        Dim daFacturas As New SqlDataAdapter(cm6)
        Dim dsAgil As New DataSet()
        Dim drAnexo As DataRow
        Dim drCambio As DataRow
        Dim drAdeudo As DataRow
        Dim drAgrupa As DataRow
        Dim drAnexos As DataRowCollection
        Dim drCambios As DataRowCollection
        Dim drRetener As DataRowCollection
        Dim drAdeudos As DataRowCollection
        Dim drFacturas As DataRowCollection
        Dim drUdis As DataRowCollection
        Dim myColArray(1) As DataColumn
        Dim myColArray1(1) As DataColumn
        Dim myColArray2(1) As DataColumn
        Dim myColArray3(1) As DataColumn
        Dim dtAdeudos As New DataTable("Adeudos")

        ' Declaración de variables de datos

        Dim cAdeudo1 As String
        Dim cAdeudo2 As String
        Dim cAgrupa As String
        Dim cAnexo As String = ""
        Dim cCalle As String = ""
        Dim cColonia As String = ""
        Dim cCopos As String = ""
        Dim cDeleg As String = ""
        Dim cFecha As String
        Dim cFechasol As String
        Dim cLetras As String
        Dim cObserv As String
        Dim cPlaza As String = ""
        Dim cRenglon As String
        Dim Cte As String
        Dim lCrea As Boolean
        Dim nAdeudo As Decimal = 0
        Dim nBaseBonificacion As Decimal = 0
        Dim nBonifica As Decimal = 0
        Dim nCapeq As Decimal = 0
        Dim nCapOtros As Decimal = 0
        Dim nCapse As Decimal = 0
        Dim nImpFac As Decimal = 0
        Dim nImpseg As Decimal = 0
        Dim nInteq As Decimal = 0
        Dim nIntOtros As Decimal = 0
        Dim nIntse As Decimal = 0
        Dim nIvaBonificacion As Decimal = 0
        Dim nIvacapital As Decimal = 0
        Dim nIvaopc As Decimal = 0
        Dim nIvaOtros As Decimal = 0
        Dim nIvapr As Decimal = 0
        Dim nIvase As Decimal = 0
        Dim nOpcion As Decimal = 0
        Dim nPlazo As Byte = 0
        Dim nRense As Decimal = 0
        Dim nSaldo As Decimal = 0
        Dim nSalse As Decimal = 0
        Dim nSdoOtros As Decimal = 0
        Dim nSuma As Decimal = 0
        Dim nTasa As Decimal = 0
        Dim nTasaBonificacion As Decimal = 0
        Dim nTotaleq As Decimal = 0
        Dim nTotalse As Decimal = 0
        Dim nTotOtros As Decimal = 0
        Dim nUdi1 As Decimal = 0
        Dim nUdi2 As Decimal = 0
        Dim nVarpr As Decimal = 0
        Dim stmAvisos As New FileStream("C:\FILES\AVISOS.txt", FileMode.Create, FileAccess.Write, FileShare.None)
        Dim stmWriter As New StreamWriter(stmAvisos, System.Text.Encoding.Default)

        btnImpAvisos.Enabled = False
        cFechasol = DTOC(DateTimePicker3.Value)

        ' Con este Stored Procedure obtengo el rango de avisos solicitado.

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Aviso6"
            .Connection = cnAgil
            .Parameters.Add("@Fecha", SqlDbType.NVarChar)
            .Parameters(0).Value = cFechasol
        End With

        With cm2
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Aviso3"
            .Connection = cnAgil
        End With

        With cm3
            .CommandType = CommandType.Text
            .CommandText = "SELECT * FROM Retener"
            .Connection = cnAgil
        End With

        With cm4
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Agrupan"
            .Connection = cnAgil
        End With

        With cm5
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Traeudis1"
            .Connection = cnAgil
        End With

        daAvisos.Fill(dsAgil, "Avisos")
        daCambio.Fill(dsAgil, "Cambios")
        daRetener.Fill(dsAgil, "Retener")
        daUdis.Fill(dsAgil, "Udis")
        daAgrupa.Fill(dsAgil, "Agrupan")

        drAnexo = dsAgil.Tables("Avisos").Rows(0)
        cFecha = drAnexo("Feven")

        With cm6
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Repantig1"
            .Connection = cnAgil
            .Parameters.Add("@Fecha", SqlDbType.NVarChar)
            .Parameters(0).Value = cFecha
        End With

        daFacturas.Fill(dsAgil, "Facturas")
        daAgrupa.Fill(dsAgil, "Agrupa")

        drAnexos = dsAgil.Tables("Avisos").Rows
        drCambios = dsAgil.Tables("Cambios").Rows
        drRetener = dsAgil.Tables("Retener").Rows
        myColArray(0) = dsAgil.Tables("Cambios").Columns("Cliente")
        dsAgil.Tables("Cambios").PrimaryKey = myColArray
        myColArray1(0) = dsAgil.Tables("Retener").Columns("Cliente")
        dsAgil.Tables("Retener").PrimaryKey = myColArray1


        'Crear el DataRowCollection de las Udis para poderlas enviar a la función 
        'que calcula los Moratorios

        drUdis = dsAgil.Tables("Udis").Rows

        ' Creo la tabla que almacenara los adeudos encontrados

        dtAdeudos.Columns.Add("Anexo", Type.GetType("System.String"))
        dtAdeudos.Columns.Add("Adeudoant", Type.GetType("System.Decimal"))
        myColArray3(0) = dtAdeudos.Columns("Anexo")
        dtAdeudos.PrimaryKey = myColArray3

        drFacturas = dsAgil.Tables("Facturas").Rows

        Adanterior(dtAdeudos, drUdis, drFacturas, cFecha)
        dsAgil.Tables.Add(dtAdeudos)
        drAdeudos = dsAgil.Tables("Adeudos").Rows

        lCrea = False

        For Each drAnexo In drAnexos

            cAnexo = drAnexo("Anexo")
            nOpcion = 0
            nIvaopc = 0
            nSdoOtros = drAnexo("SaldOt")
            nCapOtros = drAnexo("CapitalOt")
            nIntOtros = drAnexo("InteresOt") + drAnexo("VarOt")
            nIvaOtros = drAnexo("IvaOt")

            If drRetener.Find(drAnexo("Cliente")) Is Nothing Then

                ' Esta es una nueva forma de calcular el plazo que implementé a partir del 17 de octubre de 2011
                ' para determinar correctamente el plazo para frecuencias de pago diferentes a mensual

                nPlazo = 0
                CuentaPagos(cAnexo, nPlazo)

                If Val(drAnexo("Letra")) = nPlazo Then
                    If IsDBNull(drAnexo("Opcion")) Then
                        MsgBox("No está generada la Opción de Compra", MsgBoxStyle.OkOnly, "Mensaje")
                    Else
                        nOpcion = drAnexo("Opcion")
                        nIvaopc = drAnexo("IvaOpcion")
                    End If
                End If

                If drAnexo("Letra") = "001" Then
                    Cte = "N"
                Else
                    Cte = "R"
                End If

                cAgrupa = drAnexo("Agrupa")

                If Trim(cAgrupa) = "" Then
                    cAgrupa = drAnexo("Cliente")

                    If drCambios.Find(drAnexo("Cliente")) Is Nothing Then
                        cCalle = drAnexo("Calle")
                        cColonia = drAnexo("Colonia")
                        cCopos = drAnexo("Copos")
                        cDeleg = drAnexo("Delegacion")
                        cPlaza = drAnexo("DescPlaza")
                        cObserv = " "
                    Else
                        For Each drCambio In drCambios
                            If drCambio("Cliente") = drAnexo("Cliente") Then
                                cCalle = drCambio("Calle")
                                cColonia = drCambio("Colonia")
                                cCopos = drCambio("Copos")
                                cDeleg = drCambio("Delegacion")
                                cPlaza = drCambio("DescPlaza")
                                cObserv = drCambio("Observa")
                            End If
                        Next
                    End If

                Else

                    If drCambios.Find(cAgrupa) Is Nothing Then

                        For Each drAgrupa In dsAgil.Tables("Agrupa").Rows
                            If drAgrupa("Agrupa") = cAgrupa Then
                                cCalle = drAgrupa("Calle")
                                cColonia = drAgrupa("Colonia")
                                cCopos = drAgrupa("Copos")
                                cDeleg = drAgrupa("Delegacion")
                                cPlaza = drAgrupa("DescPlaza")
                                cObserv = " "
                            End If
                        Next

                    Else

                        For Each drCambio In drCambios
                            If drCambio("Cliente") = cAgrupa Then
                                cCalle = drCambio("Calle")
                                cColonia = drCambio("Colonia")
                                cCopos = drCambio("Copos")
                                cDeleg = drCambio("Delegacion")
                                cPlaza = drCambio("DescPlaza")
                                cObserv = drCambio("Observa")
                            End If
                        Next

                    End If

                End If

                nImpFac = Round(drAnexo("ImporteFac") + Val(nOpcion) + Val(nIvaopc), 2)
                nImpseg = drAnexo("SeguroVida")
                If drAnexo("Tipar") = "P" Then
                    nTotaleq = Round(drAnexo("Capeq") + drAnexo("Varpr") + drAnexo("Ivapr"), 2)
                    nTotalse = Round(drAnexo("Rense") + drAnexo("Intse") + drAnexo("Ivase"), 2)
                    nTotOtros = Round(nCapOtros + nIvaOtros + nImpseg, 2)
                Else
                    nTotaleq = Round(drAnexo("Capeq") - drAnexo("Bonifica") + drAnexo("Ivacapital") + drAnexo("Inteq") + drAnexo("Ivapr") + nOpcion + nIvaopc, 2)
                    nTotalse = Round(drAnexo("Rense") + drAnexo("Intse") + drAnexo("Ivase"), 2)
                    nTotOtros = Round(nCapOtros + nIntOtros + nIvaOtros + nImpseg, 2)
                End If

                nSuma = Round(nTotaleq + nTotalse + nTotOtros, 2)

                drAdeudo = drAdeudos.Find(cAnexo)

                cAdeudo1 = ""
                cAdeudo2 = ""
                If drAdeudo Is Nothing Then
                    nAdeudo = 0
                Else
                    nAdeudo = drAdeudo("AdeudoAnt")
                End If

                If nAdeudo > 0 Then
                    cAdeudo1 = "***** SU CUENTA PRESENTA UN ADEUDO ANTERIOR POR $ " & FormatNumber(nAdeudo.ToString, 2) & " *****"
                    cAdeudo2 = "***** IMPORTE TOTAL A PAGAR $ " & FormatNumber((nSuma + nAdeudo).ToString, 2) & " *****"
                End If

                If cAdeudo1 = "" And cAdeudo2 = "" Then
                    cAdeudo1 = "PARA ENTREGARLE SU FACTURA DE ACTIVO FIJO SERA NECESARIO QUE NOS PRESENTE AL TÉRMINO DE SU"
                    cAdeudo2 = "CONTRATO, LAS TENENCIAS PAGADAS DE LOS ÚLTIMOS TRES AÑOS."
                End If

                nSaldo = drAnexo("Saldo")
                nSalse = drAnexo("Salse")
                nTasa = drAnexo("nTasa")
                nUdi1 = drAnexo("Udi1")
                nUdi2 = drAnexo("Udi2")
                nCapeq = drAnexo("Capeq")
                nRense = drAnexo("Rense")
                nIvacapital = drAnexo("Ivacapital")
                nInteq = drAnexo("Inteq")
                nIntse = drAnexo("Intse")
                nIvapr = drAnexo("Ivapr")
                nIvase = drAnexo("Ivase")
                nCapse = drAnexo("Capse")
                nVarpr = drAnexo("Varpr")
                nImpseg = drAnexo("SeguroVida")
                cLetras = Letras((nTotaleq + nTotalse + nTotOtros).ToString)

                ' Esta es una nueva forma de determinar la descomposición de la Bonificación en Base e IVA a partir del 20 de octubre de 2011

                nBonifica = drAnexo("Bonifica")
                nTasaBonificacion = 0
                nBaseBonificacion = 0
                nIvaBonificacion = 0

                If nBonifica > 0 Then
                    nTasaBonificacion = Round(nBonifica / nCapeq, 4)
                    nBaseBonificacion = Round(nBonifica / (1 + nTasaBonificacion), 2)
                    nIvaBonificacion = Round(nBonifica - nBaseBonificacion, 2)
                    nBaseBonificacion = nBaseBonificacion * -1
                    nIvaBonificacion = nIvaBonificacion * -1
                End If

                If drAnexo("Tipar") = "P" Then
                    cRenglon = Trim(drAnexo("Descr")) & "|" & drAnexo("Factura") & _
                               "|" & Trim(cCalle) & "|" & "COL. " & Trim(cColonia) & _
                               " C.P. " & cCopos & "|" & Trim(cDeleg) & _
                               ", " & Trim(cPlaza) & "|" & "R.F.C. : " & drAnexo("RFC") & _
                               "|" & Mid(drAnexo("Anexo"), 1, 5) & "/" & Mid(drAnexo("Anexo"), 6, 9) & _
                               "|" & Mes(drAnexo("Feven")) & "||" & "|" & "|" & "|" & "|" & _
                               "|" & "SALDO INSOLUTO DEL SEGURO|" & _
                               FormatNumber(nSalse.ToString, 2) & "|" & "SALDO INSOLUTO DE OTROS ADEUDOS|" & _
                               FormatNumber(nSdoOtros.ToString, 2) & "|" & "|" & "|" & "|" & "|" & FormatNumber((nTotaleq + nTotalse + nTotOtros).ToString, 2) & _
                               "|" & (Val(drAnexo("Letra"))).ToString & " de " & nPlazo.ToString & "|" & _
                               "PAGO|" & FormatNumber((nCapeq + nVarpr).ToString, 2) & "|" & FormatNumber((nRense + nIntse).ToString, 2) & "|" & FormatNumber(nCapOtros.ToString, 2) & _
                               "|" & FormatNumber((nCapeq + nVarpr + nRense + nIntse + nCapOtros).ToString, 2) & "|" & "I.V.A. DEL PAGO|" & _
                               FormatNumber((nIvapr).ToString, 2) & "|" & FormatNumber((nIvase).ToString, 2) & "|" & _
                               FormatNumber((nIvaOtros).ToString, 2) & "|" & FormatNumber((nIvapr + nIvase + nIvaOtros).ToString, 2) & _
                               "|" & "|" & "|" & "|" & "|" & "|" & "|" & "|" & "|" & "|" & "|" & "|" & "|" & _
                               "|" & "|" & "|" & "|" & "|" & "|" & "|" & "|" & "|" & "|" & FormatNumber(nTotaleq.ToString, 2) & _
                               "|" & "SEGURO DE VIDA|" & FormatNumber(nImpseg.ToString, 2) & "|" & FormatNumber(nTotalse.ToString, 2) & "|" & _
                               FormatNumber(nTotOtros.ToString, 2) & "|" & FormatNumber((nTotaleq + nTotalse + nTotOtros).ToString, 2) & _
                               "|" & FormatNumber((nTotaleq + nTotalse + nTotOtros).ToString, 2) & " " & cLetras & "|" & cAdeudo1 & "|" & cAdeudo2 & "|" & drAnexo("Cliente") & "|" & _
                               drAnexo("Telef1") & "|" & cAgrupa & "|" & Cte & "|" & Trim(cObserv) & "|"
                Else
                    cRenglon = Trim(drAnexo("Descr")) & "|" & drAnexo("Factura") & _
                               "|" & Trim(cCalle) & "|" & "COL. " & Trim(cColonia) & _
                               " C.P. " & cCopos & "|" & Trim(cDeleg) & _
                               ", " & Trim(cPlaza) & "|" & "R.F.C. : " & drAnexo("RFC") & _
                               "|" & Mid(drAnexo("Anexo"), 1, 5) & "/" & Mid(drAnexo("Anexo"), 6, 9) & _
                               "|" & Mes(drAnexo("Feven")) & "|" & _
                               "TASA|" & FormatNumber(nTasa.ToString, 4) & "|" & _
                               "DIAS|" & drAnexo("Dias") & "|" & _
                               "SALDO INSOLUTO DEL EQUIPO|" & FormatNumber(nSaldo.ToString, 2) & "|" & _
                               "SALDO INSOLUTO DEL SEGURO|" & FormatNumber(nSalse.ToString, 2) & "|" & _
                               "SALDO INSOLUTO DE OTROS ADEUDOS|" & FormatNumber(nSdoOtros.ToString, 2) & "|" & _
                               "UDI INICIAL|" & FormatNumber(nUdi1.ToString, 6) & "|" & _
                               "UDI FINAL|" & FormatNumber(nUdi2.ToString, 6) & "|" & _
                               FormatNumber((nTotaleq + nTotalse + nTotOtros).ToString, 2) & "|" & _
                               (Val(drAnexo("Letra"))).ToString & " de " & nPlazo.ToString & "|" & _
                               "CAPITAL|" & FormatNumber(nCapeq.ToString, 2) & "|" & FormatNumber(nRense.ToString, 2) & "|" & FormatNumber(nCapOtros.ToString, 2) & "|" & FormatNumber((nCapeq + nRense + nCapOtros).ToString, 2) & "|" & _
                               "APLICACION DEPOSITO vs CAPITAL|" & FormatNumber(nBaseBonificacion.ToString, 2) & "|" & "|" & "|" & FormatNumber(nBaseBonificacion.ToString, 2) & "|" & _
                               "IVA DEL CAPITAL|" & FormatNumber(nIvacapital.ToString, 2) & "|" & FormatNumber(nIvacapital.ToString, 2) & "|" & _
                               "APLICACION DEPOSITO vs IVA CAPITAL|" & FormatNumber(nIvaBonificacion.ToString, 2) & "|" & FormatNumber(nIvaBonificacion.ToString, 2) & "|" & _
                               "INTERESES|" & FormatNumber(nInteq.ToString, 2) & "|" & FormatNumber(nIntse.ToString, 2) & "|" & FormatNumber(nIntOtros.ToString, 2) & "|" & FormatNumber((nInteq + nIntse + nIntOtros).ToString, 2) & "|" & _
                               "IVA DE LOS INTERESES|" & FormatNumber(nIvapr.ToString, 2) & "|" & FormatNumber(nIvase.ToString, 2) & "|" & FormatNumber(nIvaOtros.ToString, 2) & "|" & FormatNumber((nIvapr + nIvase + nIvaOtros).ToString, 2) & "|" & _
                               "OPCION DE COMPRA|" & FormatNumber(nOpcion.ToString, 2) & "|" & FormatNumber(nOpcion.ToString, 2) & "|" & _
                               "IVA DE LA OPCION DE COMPRA|" & FormatNumber(nIvaopc.ToString, 2) & "|" & FormatNumber(nIvaopc.ToString, 2) & "|" & FormatNumber(nTotaleq.ToString, 2) & "|" & _
                               "SEGURO DE VIDA|" & FormatNumber(nImpseg.ToString, 2) & "|" & _
                               FormatNumber(nTotalse.ToString, 2) & "|" & _
                               FormatNumber(nTotOtros.ToString, 2) & "|" & _
                               FormatNumber((nTotaleq + nTotalse + nTotOtros).ToString, 2) & "|" & _
                               FormatNumber((nTotaleq + nTotalse + nTotOtros).ToString, 2) & " " & cLetras & "|" & _
                               cAdeudo1 & "|" & cAdeudo2 & "|" & drAnexo("Cliente") & "|" & _
                               drAnexo("Telef1") & "|" & cAgrupa & "|" & Cte & "|" & Trim(cObserv) & "|"
                End If

                cRenglon = cRenglon.Replace("Ñ", Chr(165))
                cRenglon = cRenglon.Replace("ñ", Chr(164))
                cRenglon = cRenglon.Replace("á", Chr(160))
                cRenglon = cRenglon.Replace("é", Chr(130))
                cRenglon = cRenglon.Replace("í", Chr(161))
                cRenglon = cRenglon.Replace("ó", Chr(162))
                cRenglon = cRenglon.Replace("ú", Chr(163))
                cRenglon = cRenglon.Replace("Á", Chr(181))
                cRenglon = cRenglon.Replace("É", Chr(144))
                cRenglon = cRenglon.Replace("Ó", Chr(224))
                cRenglon = cRenglon.Replace("Ú", Chr(233))
                cRenglon = cRenglon.Replace("°", Chr(167))
                stmWriter.WriteLine(cRenglon)

            End If
        Next
        stmWriter.Flush()
        stmAvisos.Flush()
        stmAvisos.Close()

        MsgBox("Archivo AVISOS.txt generado correctamente", MsgBoxStyle.OkOnly, "Mensaje")
        dsAgil.Dispose()
        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()
        cm3.Dispose()
        cm4.Dispose()
        cm5.Dispose()
        cm6.Dispose()

    End Sub

    Private Sub btnTarjeta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTarjeta.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim daAvisos As New SqlDataAdapter(cm1)
        Dim dsAgil As New DataSet()
        Dim drAnexo As DataRow
        Dim drAnexos As DataRowCollection

        ' Declaración de variables de datos

        Dim cAnexo As String
        Dim cRenglon As String
        Dim cFechasol As String
        Dim Cte As String
        Dim cRefBanamex As String
        Dim cRefBancomer As String
        Dim cRefHSBC As String
        Dim cRefBanorte As String
        Dim nResultado As Decimal
        Dim nSumaBanamex As Decimal
        Dim nSumaBancomer As Decimal
        Dim nCounter As Integer
        Dim stmAvisos As New FileStream("C:\FILES\TARJETAS.txt", FileMode.Create, FileAccess.Write, FileShare.None)
        Dim stmWriter As New StreamWriter(stmAvisos, System.Text.Encoding.Default)
        Dim strUpdate As String = ""

        btnTarjeta.Enabled = False
        cFechasol = DTOC(DateTimePicker3.Value)

        ' Con este Stored Procedure obtengo el rango de avisos solicitado.

        With cm1
            .CommandType = CommandType.Text
            .CommandText = "SELECT * FROM Solicitudes"
            .Connection = cnAgil
        End With
        daAvisos.Fill(dsAgil, "Avisos")
        drAnexos = dsAgil.Tables("Avisos").Rows

        nCounter = 0

        For Each drAnexo In drAnexos

            cAnexo = Mid(drAnexo("Contrato"), 1, 5) + Mid(drAnexo("Contrato"), 7, 4)

            ' Obtenemos la referencia de cada uno de los contatos para cada Banco

            cRefBanamex = Mid(cAnexo, 1, 5) + Mid(cAnexo, 7, 3)
            cRefBancomer = Mid(cAnexo, 2, 4) + Mid(cAnexo, 7, 3)
            cRefHSBC = Mid(cAnexo, 2, 4) + Mid(cAnexo, 7, 3)

            nSumaBanamex = 1235
            nSumaBanamex += Val(Mid(cRefBanamex, 1, 1)) * 11
            nSumaBanamex += Val(Mid(cRefBanamex, 2, 1)) * 13
            nSumaBanamex += Val(Mid(cRefBanamex, 3, 1)) * 17
            nSumaBanamex += Val(Mid(cRefBanamex, 4, 1)) * 19
            nSumaBanamex += Val(Mid(cRefBanamex, 5, 1)) * 23
            nSumaBanamex += Val(Mid(cRefBanamex, 6, 1)) * 29
            nSumaBanamex += Val(Mid(cRefBanamex, 7, 1)) * 31
            nSumaBanamex += Val(Mid(cRefBanamex, 8, 1)) * 37

            nResultado = 99 - (nSumaBanamex Mod 97)
            If nResultado > 9 Then
                cRefBanamex += nResultado.ToString
            Else
                cRefBanamex += "0" + nResultado.ToString
            End If

            nSumaBancomer = 0
            nResultado = Val(Mid(cRefBancomer, 1, 1)) * 2
            If nResultado > 9 Then
                nSumaBancomer += Val(Mid(nResultado.ToString, 1, 1)) + Val(Mid(nResultado.ToString, 2, 1))
            Else
                nSumaBancomer += nResultado
            End If
            nResultado = Val(Mid(cRefBancomer, 2, 1)) * 1
            If nResultado > 9 Then
                nSumaBancomer += Val(Mid(nResultado.ToString, 1, 1)) + Val(Mid(nResultado.ToString, 2, 1))
            Else
                nSumaBancomer += nResultado
            End If
            nResultado = Val(Mid(cRefBancomer, 3, 1)) * 2
            If nResultado > 9 Then
                nSumaBancomer += Val(Mid(nResultado.ToString, 1, 1)) + Val(Mid(nResultado.ToString, 2, 1))
            Else
                nSumaBancomer += nResultado
            End If
            nResultado = Val(Mid(cRefBancomer, 4, 1)) * 1
            If nResultado > 9 Then
                nSumaBancomer += Val(Mid(nResultado.ToString, 1, 1)) + Val(Mid(nResultado.ToString, 2, 1))
            Else
                nSumaBancomer += nResultado
            End If
            nResultado = Val(Mid(cRefBancomer, 5, 1)) * 2
            If nResultado > 9 Then
                nSumaBancomer += Val(Mid(nResultado.ToString, 1, 1)) + Val(Mid(nResultado.ToString, 2, 1))
            Else
                nSumaBancomer += nResultado
            End If
            nResultado = Val(Mid(cRefBancomer, 6, 1)) * 1
            If nResultado > 9 Then
                nSumaBancomer += Val(Mid(nResultado.ToString, 1, 1)) + Val(Mid(nResultado.ToString, 2, 1))
            Else
                nSumaBancomer += nResultado
            End If
            nResultado = Val(Mid(cRefBancomer, 7, 1)) * 2
            If nResultado > 9 Then
                nSumaBancomer += Val(Mid(nResultado.ToString, 1, 1)) + Val(Mid(nResultado.ToString, 2, 1))
            Else
                nSumaBancomer += nResultado
            End If

            If nSumaBancomer > 60 Then
                nResultado = 70 - nSumaBancomer
            ElseIf nSumaBancomer > 50 Then
                nResultado = 60 - nSumaBancomer
            ElseIf nSumaBancomer > 40 Then
                nResultado = 50 - nSumaBancomer
            ElseIf nSumaBancomer > 30 Then
                nResultado = 40 - nSumaBancomer
            ElseIf nSumaBancomer > 20 Then
                nResultado = 30 - nSumaBancomer
            ElseIf nSumaBancomer > 10 Then
                nResultado = 20 - nSumaBancomer
            ElseIf nSumaBancomer > 0 Then
                nResultado = 10 - nSumaBancomer
            Else
                nResultado = 0
            End If

            cRefBancomer += nResultado.ToString
            cRefHSBC = cRefBancomer
            cRefBanorte = cRefBancomer

            strUpdate = "UPDATE Solicitudes SET RefBancomer = '" & cRefBancomer & "', "
            strUpdate = strUpdate & "RefHSBC = '" & cRefHSBC & "', "
            strUpdate = strUpdate & "RefBanorte = '" & cRefBanorte & "', "
            strUpdate = strUpdate & "RefBanamex = '" & cRefBanamex & "' "
            strUpdate = strUpdate & "WHERE Contrato = '" & Mid(cAnexo, 1, 5) + "/" + Mid(cAnexo, 6, 4) & "' "
            Try
                cm2 = New SqlCommand(strUpdate, cnAgil)
                cnAgil.Open()
                cm2.ExecuteNonQuery()
                cnAgil.Close()
            Catch eException As Exception
                MsgBox(eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")
            End Try

        Next

        dsAgil.Clear()
        dsAgil.Dispose()
        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()

    End Sub

End Class
