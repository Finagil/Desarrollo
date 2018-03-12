Option Explicit On 
Imports System.Data.SqlClient
Imports System.IO

Public Class Form1
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
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents inicio As System.Windows.Forms.Button
    Friend WithEvents Cadena As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DataGrid1 = New System.Windows.Forms.DataGrid()
        Me.inicio = New System.Windows.Forms.Button()
        Me.Cadena = New System.Windows.Forms.Label()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGrid1
        '
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(24, 48)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(616, 296)
        Me.DataGrid1.TabIndex = 0
        '
        'inicio
        '
        Me.inicio.Location = New System.Drawing.Point(32, 8)
        Me.inicio.Name = "inicio"
        Me.inicio.Size = New System.Drawing.Size(64, 24)
        Me.inicio.TabIndex = 1
        Me.inicio.Text = "Ejecuta"
        '
        'Cadena
        '
        Me.Cadena.Location = New System.Drawing.Point(144, 8)
        Me.Cadena.Name = "Cadena"
        Me.Cadena.Size = New System.Drawing.Size(424, 32)
        Me.Cadena.TabIndex = 2
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(776, 350)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Cadena, Me.inicio, Me.DataGrid1})
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Declaracion de variables ADO.Net

        Dim strConn As String = "Server=SERVER-RAID; DataBase=Production; User ID=sa; pwd=faae6115"
        Dim scnnAgil As New SqlConnection(strConn)
        Dim scmd As New SqlCommand()
        Dim dsBcmer As DataSet = New DataSet()
        Dim drDatos As DataRow
        Dim drGenPol As DataRowCollection
        Dim daCome As SqlDataAdapter = New SqlDataAdapter(scmd)

        Dim sFecha, sCons, cCatal, cAnexo1 As String
        Dim Arreglo As New ArrayList()
        Dim nTotal, nImp, nIva, nEsp As Double
        Dim cAnexo, cAnexoven, cApl, cBanco, cCoa, cCuenta, cCuenta1, cTipeq, cName As String
        Dim cCve, cDataText, cFechaPoliza, cIni, cIva, cNiv, cPoliza, cTipo, cTipo1 As String
        Dim i As Byte

        Dim cPoliz As String
        Dim nDato As Int64
        Dim oArchivo As StreamWriter

        With scmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "TraeClientes"
            .Connection = scnnAgil
        End With

        'Llenar el DataSet
        daCome.Fill(dsBcmer, "Clientes")

        'DataGrid1.DataSource = dsGenPoliz
        drGenPol = dsBcmer.Tables("Clientes").Rows

        nDato = 0
        cFechaPoliza = "agil"
        For Each drDatos In drGenPol
            cAnexo = "agil" + drDatos("Cliente")
            '     cAnexo1 = "agil" + drDatos("Clave")
            If cFechaPoliza <> "agil" + drDatos("Cliente") Then
                'cAnexo = Stuff(cAnexo, "D", " ", 20)
                cCve = Trim(drDatos("RFC"))
                cCatal = Trim(drDatos("Descr"))
                sFecha = Trim(drDatos("Calle"))
                If IsDBNull(drDatos("Nomrepr")) Then
                    sCons = Trim(drDatos("Descr"))
                Else
                    sCons = Trim(drDatos("Nomrepr"))
                End If
                cCoa = Trim(Mid(drDatos("Telef1"), 1, 15))
                cCuenta = "agil" + drDatos("Cliente")
                cBanco = Trim(drDatos("RFC"))
                cCuenta = "Mi RFC es"
                cCuenta1 = Trim(drDatos("RFC"))
                cPoliz = cAnexo & ";" + cCve & ";" + cCatal + ";" + sFecha + ";" + sCons + ";" + cCoa + ";" + cAnexo + ";" + cAnexo + ";" + cCuenta + ";" + cBanco + ";"
                If nDato = 0 Then
                    oArchivo = New StreamWriter("C:\ALTASOCIOSB.txt")
                End If
                oArchivo.WriteLine(cPoliz)
            End If
            nDato += 1
            cFechaPoliza = "agil" + drDatos("Cliente")
        Next

        oArchivo.Close()
        Me.Close()
    
    End Sub

End Class
