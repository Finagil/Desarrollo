Option Explicit On

Imports System.Data.SqlClient
Imports System.Math
Imports CrystalDecisions.Shared

Public Class frmCartaRat

    Public Sub New(ByVal cAnexo As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.Text = "Carta del contrato " & cAnexo & " ratificado "
        txtAnexo.Text = cAnexo

    End Sub

    Private Sub frmCartaRat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand()
        Dim cm2 As New SqlCommand()
        Dim dsAgil As New DataSet()
        Dim daCliente As New SqlDataAdapter(cm1)
        Dim daAnexo As New SqlDataAdapter(cm2)
        Dim drAnexo As DataRow
        Dim drCliente As DataRow
        Dim drReporte As DataRow
        Dim dtReporte As New DataTable("Reporte")

        'Declaración de variables de datos

        Dim cAnexo As String
        Dim cCliente As String
        Dim cCalle As String
        Dim cColonia As String
        Dim cDeleg As String
        Dim cCopos As String
        Dim cPlaza As String
        Dim cPromo As String
        Dim cCusnam As String
        Dim cTipar As String
        Dim newrptCartaRat As New rptCartaRat()

        cAnexo = Mid(txtAnexo.Text, 1, 5) & Mid(txtAnexo.Text, 7, 4)

        ' El siguiente Stored Procedure trae todos los atributos de la tabla Anexos,
        ' para un anexo dado

        With cm2
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DatosCon1"
            .Connection = cnAgil
            .Parameters.Add("@Anexo", SqlDbType.NVarChar)
            .Parameters(0).Value = cAnexo
        End With

        ' Llenar el DataSet lo cual abre y cierra la conexión

        daAnexo.Fill(dsAgil, "Anexos")
        drAnexo = dsAgil.Tables("Anexos").Rows(0)
        cCliente = drAnexo("Cliente")
        cTipar = drAnexo("Tipar")

        ' El siguiente Stored Procedure trae todos los atributos de la tabla Anexos,
        ' para un anexo dado

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DatosClie1"
            .Connection = cnAgil
            .Parameters.Add("@Cliente", SqlDbType.NVarChar)
            .Parameters(0).Value = cCliente
        End With

        daCliente.Fill(dsAgil, "Cliente")

        ' Primero creo la tabla Reporte que será la base del reporte

        dtReporte.Columns.Add("Nombre", Type.GetType("System.String"))
        dtReporte.Columns.Add("Contrato", Type.GetType("System.String"))
        dtReporte.Columns.Add("Calle", Type.GetType("System.String"))
        dtReporte.Columns.Add("Colonia", Type.GetType("System.String"))
        dtReporte.Columns.Add("Copos", Type.GetType("System.String"))
        dtReporte.Columns.Add("Deleg", Type.GetType("System.String"))
        dtReporte.Columns.Add("Plaza", Type.GetType("System.String"))
        dtReporte.Columns.Add("Promotor", Type.GetType("System.String"))
        dtReporte.Columns.Add("Tipar", Type.GetType("System.String"))

        drCliente = dsAgil.Tables("Cliente").Rows(0)
        cCusnam = drCliente("Descr")
        cAnexo = txtAnexo.Text
        cCalle = drCliente("Calle")
        cColonia = drCliente("Colonia")
        cCopos = drCliente("Copos")
        cDeleg = drCliente("Delegacion")
        cPlaza = drCliente("DescPlaza")
        cPromo = drCliente("DescPromotor")
        
        drReporte = dtReporte.NewRow()
        drReporte("Nombre") = cCusnam
        drReporte("Contrato") = cAnexo
        drReporte("Calle") = cCalle
        drReporte("Colonia") = cColonia
        drReporte("Copos") = cCopos
        drReporte("Deleg") = cDeleg
        drReporte("Plaza") = cPlaza
        drReporte("Promotor") = cPromo
        drReporte("Tipar") = cTipar
        dtReporte.Rows.Add(drReporte)

        dsAgil.Tables.Remove("Anexos")
        dsAgil.Tables.Remove("Cliente")
        dsAgil.Tables.Add(dtReporte)

        ' Comentar la siguiente línea en caso de que se deseara modificar el reporte rptCartaRat
        ' dsAgil.WriteXml("C:\Schema35.xml", XmlWriteMode.WriteSchema)

        newrptCartaRat.SetDataSource(dsAgil)
        CrystalReportViewer1.ReportSource = newrptCartaRat

        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()

    End Sub

End Class