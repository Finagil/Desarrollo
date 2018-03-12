Option Explicit On

Imports System.Data.SqlClient

Public Class frmPideProductor

    Public Sub New(ByVal cMenu As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        txtMenu.Text = cMenu

    End Sub

    ' Declaración de variables de alcance privado

    Dim cProductor As String = ""
    Dim lFirstTime As Boolean = True

    Private Sub frmPideProductor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daClientes As New SqlDataAdapter(cm1)

        Dim dsAgil As New DataSet()

        Select Case txtMenu.Text
            Case "mnuECPP"
                Me.Text = "Selección de Cliente de Avío para Estado de Cuenta"
            Case "mnuPorProductor"
                Me.Text = "Selección de Cliente de Avío para Captura de Ministraciones"
            Case "mnuModCtoAvioPorProductor"
                Me.Text = "Selección de Cliente de Avío para modificación"
            Case "mnuPagaresPorProductor"
                Me.Text = "Selección de Cliente de Avío para captura de Pagarés"
            Case "mnuCapturaPMIPorProductor"
                Me.Text = "Selección de Cliente de Avío para captura de Predios y Garantías"
            Case "mnuImpCtoAvioPorProductor"
                Me.Text = "Selección de Cliente de Avío para impresión de Contrato"
        End Select

        ' Este Stored Procedure trae los clientes que pertenezcan a la Sucursal de NAVOJOA, MEXICALI e IRAPUATO

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "ContClie2"
            .Connection = cnAgil
        End With

        cbProductores.MaxDropDownItems = 25

        Try

            ' Llenar el DataSet

            daClientes.Fill(dsAgil, "Clientes")

            ' Ligar la tabla Clientes del dataset dsAgil al ComboBox

            cbProductores.DataSource = dsAgil
            cbProductores.DisplayMember = "Clientes.Descr"
            cbProductores.ValueMember = "Clientes.Cliente"
            lFirstTime = False

        Catch eException As Exception

            MsgBox(eException.Source & " " & eException.Message, MsgBoxStyle.Critical, "Mensaje de Error")

        End Try

        cnAgil.Dispose()
        cm1.Dispose()

    End Sub

    Private Sub cbProductores_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbProductores.SelectedIndexChanged

        ' Declaración de variables de conexíón ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim daContratos As New SqlDataAdapter(cm1)

        Dim dsAgil As New DataSet()
        Dim drContrato As DataRow

        ' Declaración de variables de datos

        Dim cAnexo As String = ""
        Dim cCiclo As String = ""
        Dim cCliente As String = ""
        Dim cDescCiclo As String = ""

        If Not cbProductores.SelectedValue Is Nothing And lFirstTime = False Then

            cProductor = cbProductores.SelectedValue.ToString()

            ' El siguiente Command trae los contratos del Productor seleccionado

            With cm1
                .CommandType = CommandType.Text
                .CommandText = "SELECT Anexo, Avios.Ciclo, 'Ciclo ' + Avios.Ciclo + SPACE(1) + DescCiclo + SPACE(1) + 'Vencimiento: ' + SUBSTRING(FechaTerminacion,7,2)+'/'+SUBSTRING(FechaTerminacion,5,2)+'/'+SUBSTRING(FechaTerminacion,1,4) AS CicloPagare FROM Avios " & _
                               "INNER JOIN Ciclos ON Avios.Ciclo = Ciclos.Ciclo " & _
                               "WHERE Tipar IN ('H','A') AND Cliente = '" & cProductor & "' " & _
                               "UNION ALL " & _
                               "SELECT Anexo, Ciclo, 'PAGARE ' + Ciclo + SPACE(15) + 'Vencimiento: ' + SUBSTRING(FechaTerminacion,7,2)+'/'+SUBSTRING(FechaTerminacion,5,2)+'/'+SUBSTRING(FechaTerminacion,1,4) AS CicloPagare FROM Avios " & _
                               "WHERE Tipar = 'C' AND Cliente = '" & cProductor & "' " & _
                               "ORDER BY Anexo, Avios.Ciclo"
                .Connection = cnAgil
            End With

            ' Llenar el DataSet lo cual abre y cierra la conexión

            daContratos.Fill(dsAgil, "Contratos")

            ' Ya que se escogió un productor del listado, se llama a la forma frmAgricola mandándole
            ' como parámetro el número del productor seleccionado el cual coincide con el del contrato

            lblContratos.Visible = True
            lbContratos.Visible = True
            lbContratos.Items.Clear()

            For Each drContrato In dsAgil.Tables("Contratos").Rows
                cAnexo = Mid(drContrato("Anexo"), 1, 5) & "/" & Mid(drContrato("Anexo"), 6, 4)
                cCiclo = drContrato("Ciclo")
                cDescCiclo = RTrim(drContrato("CicloPagare"))
                lbContratos.Items.Add(cAnexo & " " & cDescCiclo)
            Next

        End If

    End Sub

    Private Sub lbContratos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbContratos.SelectedIndexChanged

        Select Case txtMenu.Text
            Case "mnuECPP"
                Dim newfrmEdoCtaAvio As New frmEdoCtaAvio(Mid(lbContratos.SelectedItem, 1, 58))
                newfrmEdoCtaAvio.Show()
            Case "mnuPorProductor"
                Dim newfrmAgricola As New frmAgricola(Mid(lbContratos.SelectedItem, 1, 58))
                newfrmAgricola.Show()
            Case "mnuModCtoAvioPorProductor"
                Dim newfrmModCtoAvio As New frmModCtoAvio(Mid(lbContratos.SelectedItem, 1, 58))
                newfrmModCtoAvio.Show()
            Case "mnuPagaresPorProductor"
                Dim newfrmPagares As New frmPagares(Mid(lbContratos.SelectedItem, 1, 58))
                newfrmPagares.Show()
            Case "mnuCapturaPMIPorProductor"
                Dim newfrmCapturaPMI As New frmCapturaPMI(Mid(lbContratos.SelectedItem, 1, 58))
                newfrmCapturaPMI.Show()
            Case "mnuImpCtoAvioPorProductor"
                Dim newfrmImpCtoAvio As New frmImpCtoAvio(Mid(lbContratos.SelectedItem, 1, 58))
                newfrmImpCtoAvio.Show()
        End Select

    End Sub

End Class