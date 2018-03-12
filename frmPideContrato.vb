Option Explicit On

Imports System.Data.SqlClient

Public Class frmPideContrato

    Public Sub New(ByVal cMenu As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtMenu.Text = cMenu

    End Sub

    Private Sub frmPideContrato_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Select Case txtMenu.Text
            Case "mnuDatosCon"
                Me.Text = "Selección de Contrato para Consulta de Datos"
            Case "mnuAdelanto"
                Me.Text = "Selección de Contrato para Adelanto a Capital"
            Case "mnuCalcfini"
                Me.Text = "Selección de Contrato para Cálculo de Finiquito"
            Case "mnuFiniquito"
                Me.Text = "Selección de Contrato para Finiquito"
            Case "mnuRegenera"
                Me.Text = "Selección de Contrato para regenerar su Tabla"
            Case "mnuCartaRat"
                Me.Text = "Selección de Contrato para Carta de Ratificación"
            Case "mnuCapitalizacion"
                Me.Text = "Selección de Contrato para Capitalización"
            Case "mnuImprCert"
                Me.Text = "Selección de Contrato para Estado de Cuenta Certificado"
            Case "mnuMinistracionesPorContrato"
                Me.Text = "Selección de Contrato de Avío para Ministraciones"
            Case "mnuModCtoAvioPorContrato"
                Me.Text = "Selección de Contrato de Avío para Modificación"
            Case "mnuPagaresPorContrato"
                Me.Text = "Selección de Contrato de Avío para captura de Pagarés"
            Case "mnuCapturaPMIPorContrato"
                Me.Text = "Selección de Contrato de Avío para captura de Predios y Garantías"
            Case "mnuImpCtoAvioPorContrato"
                Me.Text = "Selección de Contrato de Avío para impresión"
        End Select

        mtxtContrato.Mask = "A0000/0000"

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daAvios As New SqlDataAdapter(cm1)

        Dim dsAgil As New DataSet()
        Dim drAnexo As DataRow

        ' Declaración de variables de datos

        Dim cAnexo As String

        If mtxtContrato.MaskFull = True Then

            cAnexo = Mid(mtxtContrato.Text, 1, 5) + Mid(mtxtContrato.Text, 7, 4)

            Select Case txtMenu.Text
                Case "mnuDatosCon"
                    Dim newfrmDatosCon As New frmDatosCon(mtxtContrato.Text)
                    newfrmDatosCon.Show()
                Case "mnuAdelanto"
                    Dim newfrmAdelanto As New frmAdelanto(mtxtContrato.Text)
                    newfrmAdelanto.Show()
                Case "mnuCalcfini"
                    Dim newfrmCalcfini As New frmCalcfini(mtxtContrato.Text)
                    newfrmCalcfini.Show()
                Case "mnuFiniquito"
                    Dim newfrmFiniquito As New frmFiniquito(mtxtContrato.Text)
                    newfrmFiniquito.Show()
                Case "mnuRegenera"
                    Regenera(mtxtContrato.Text)
                Case "mnuCartaRat"
                    Dim newfrmCartaRat As New frmCartaRat(mtxtContrato.Text)
                    newfrmCartaRat.Show()
                Case "mnuCapitalizacion"
                    Dim newfrmCapitalizacion As New frmCapitalizacion(mtxtContrato.Text)
                    newfrmCapitalizacion.Show()
                Case "mnuImprCert"
                    Dim newfrmImprCert As New frmImprCert(mtxtContrato.Text)
                    newfrmImprCert.Show()
                Case "mnuMinistracionesPorContrato"

                    ' El siguiente Command verifica que exista el Crédito de Avío

                    With cm1
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT Anexo FROM Avios WHERE Anexo = '" & cAnexo & "'"
                        .Connection = cnAgil
                        .Parameters.Add("@Anexo", SqlDbType.NVarChar)
                        .Parameters(0).Value = cAnexo
                    End With

                    ' Llenar el DataSet lo cual abre y cierra la conexión

                    daAvios.Fill(dsAgil, "Avios")

                    If dsAgil.Tables("Avios").Rows.Count = 0 Then

                        lblMensaje.Text = "¡Contrato inexistente o no es de Avío!"

                    Else

                        Dim newfrmAgricola As New frmAgricola(mtxtContrato.Text)
                        newfrmAgricola.Show()

                    End If

                Case "mnuModCtoAvioPorContrato"

                    ' El siguiente Command verifica que exista el Crédito de Avío

                    With cm1
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT Anexo FROM Avios WHERE Anexo = '" & cAnexo & "'"
                        .Connection = cnAgil
                        .Parameters.Add("@Anexo", SqlDbType.NVarChar)
                        .Parameters(0).Value = cAnexo
                    End With

                    ' Llenar el DataSet lo cual abre y cierra la conexión

                    daAvios.Fill(dsAgil, "Avios")

                    If dsAgil.Tables("Avios").Rows.Count = 0 Then

                        lblMensaje.Text = "¡Contrato inexistente o no es de Avío!"
                        lblMensaje.Visible = True

                    Else

                        lblMensaje.Visible = False
                        Dim newfrmModCtoAvio As New frmModCtoAvio(mtxtContrato.Text)
                        newfrmModCtoAvio.Show()

                    End If

                Case "mnuPagaresPorContrato"

                    ' El siguiente Command verifica que exista el Crédito de Avío

                    With cm1
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT Anexo FROM Avios WHERE Anexo = '" & cAnexo & "'"
                        .Connection = cnAgil
                        .Parameters.Add("@Anexo", SqlDbType.NVarChar)
                        .Parameters(0).Value = cAnexo
                    End With

                    ' Llenar el DataSet lo cual abre y cierra la conexión

                    daAvios.Fill(dsAgil, "Avios")

                    If dsAgil.Tables("Avios").Rows.Count = 0 Then

                        lblMensaje.Text = "¡Contrato inexistente o no es de Avío!"
                        lblMensaje.Visible = True

                    Else

                        lblMensaje.Visible = False
                        Dim newfrmPagares As New frmPagares(mtxtContrato.Text)
                        newfrmPagares.Show()

                    End If

                Case "mnuCapturaPMIPorContrato"

                    ' El siguiente Command verifica que exista el Crédito de Avío

                    With cm1
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT Anexo FROM Avios WHERE Anexo = '" & cAnexo & "'"
                        .Connection = cnAgil
                        .Parameters.Add("@Anexo", SqlDbType.NVarChar)
                        .Parameters(0).Value = cAnexo
                    End With

                    ' Llenar el DataSet lo cual abre y cierra la conexión

                    daAvios.Fill(dsAgil, "Avios")

                    If dsAgil.Tables("Avios").Rows.Count = 0 Then

                        lblMensaje.Text = "¡Contrato inexistente o no es de Avío!"
                        lblMensaje.Visible = True

                    Else

                        lblMensaje.Visible = False
                        Dim newfrmCapturaPMI As New frmCapturaPMI(mtxtContrato.Text)
                        newfrmCapturaPMI.Show()

                    End If

                Case "mnuImpCtoAvioPorContrato"

                    ' El siguiente Command verifica que exista el Crédito de Avío

                    With cm1
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT Anexo FROM Avios WHERE Anexo = '" & cAnexo & "'"
                        .Connection = cnAgil
                        .Parameters.Add("@Anexo", SqlDbType.NVarChar)
                        .Parameters(0).Value = cAnexo
                    End With

                    ' Llenar el DataSet lo cual abre y cierra la conexión

                    daAvios.Fill(dsAgil, "Avios")

                    If dsAgil.Tables("Avios").Rows.Count = 0 Then

                        lblMensaje.Text = "¡Contrato inexistente o no es de Avío!"
                        lblMensaje.Visible = True

                    Else

                        lblMensaje.Visible = False
                        Dim newfrmImpCtoAvio As New frmImpCtoAvio(mtxtContrato.Text)
                        newfrmImpCtoAvio.Show()

                    End If

            End Select

        End If

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub mtxtContrato_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles mtxtContrato.MaskInputRejected

    End Sub
End Class