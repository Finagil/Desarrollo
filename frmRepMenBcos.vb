Option Explicit On

Imports System.Data.SqlClient
Imports System.Math
Imports System.IO

Public Class frmRepMenBancos

    Private Sub frmRepMenBancos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As SqlCommand
        Dim dsAgil As New DataSet()
        Dim dtRepBancos As New DataTable("RepBancos")
        Dim drBancos As DataRow

        ' Declaración de variables de datos

        Dim cBanco As String
        Dim cCusnam As String
        Dim cFecha As String
        Dim cReferencia As String
        Dim cRenglon As String
        Dim cMontosincomas As String
        Dim cMonto As String
        Dim nMonto As Decimal
        Dim i As Byte
        Dim oArchivo As StreamReader

        ' Declaración de variables de Crystal Reports

        Dim newrptRepBcos As New rptRepMenBcos()
        Dim cReportTitle As String

        ' Primero creo la tabla dtDepoRefe que será la base del reporte

        dtRepBancos.Columns.Add("Fecha", Type.GetType("System.String"))
        dtRepBancos.Columns.Add("Banco", Type.GetType("System.String"))
        dtRepBancos.Columns.Add("Referencia", Type.GetType("System.String"))
        dtRepBancos.Columns.Add("Nombre", Type.GetType("System.String"))
        dtRepBancos.Columns.Add("Cargo", Type.GetType("System.Decimal"))
        dtRepBancos.Columns.Add("Abono", Type.GetType("System.Decimal"))

        ' Abro la conexión aquí para no tener que abrirla y cerrarla n veces

        cnAgil.Open()

        cFecha = " "

        If File.Exists("C:\BBVA.TXT") Then

            cBanco = "BMER"

            oArchivo = New StreamReader("C:\BBVA.TXT")

            While (oArchivo.Peek() > -1)

                cRenglon = oArchivo.ReadLine()
                cFecha = Mid(cRenglon, 131, 4) & Mid(cRenglon, 136, 2) & Mid(cRenglon, 139, 2)
                cCusnam = " "

                If Mid(cRenglon, 37, 6) = "581034" Then
                    cReferencia = Mid(cRenglon, 54, 8)
                    cReferencia = Mid(cReferencia, 1, 5) + "0" + Mid(cReferencia, 6, 3)

                    ' El siguiente comando me regresa el nombre del cliente

                    cm1 = New SqlCommand()
                    With cm1
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "DepoRefe1"
                        .Connection = cnAgil
                        .Parameters.Add("@Anexo", SqlDbType.NVarChar)
                        .Parameters(0).Value = cReferencia
                    End With
                    cCusnam = cm1.ExecuteScalar()
                    cReferencia = Mid(cReferencia, 1, 5) + "/" + Mid(cReferencia, 6, 4)

                End If

                If cCusnam = " " Then

                    cCusnam = Mid(cRenglon, 35, 30)
                    cReferencia = " "

                End If

                nMonto = Val(Mid(cRenglon, 69, 13))
                drBancos = dtRepBancos.NewRow()
                drBancos("Fecha") = CTOD(cFecha).ToShortDateString
                drBancos("Banco") = cBanco
                drBancos("Referencia") = cReferencia
                drBancos("Nombre") = cCusnam
                drBancos("Cargo") = IIf(Mid(cRenglon, 65, 1) = "1", nMonto, 0)
                drBancos("Abono") = IIf(Mid(cRenglon, 65, 1) = "0", nMonto, 0)
                dtRepBancos.Rows.Add(drBancos)

            End While

            oArchivo.Close()

        End If

        If File.Exists("C:\HSBC.TXT") Then

            cBanco = "HSBC"

            oArchivo = New StreamReader("C:\HSBC.TXT")

            While (oArchivo.Peek() > -1)

                cRenglon = oArchivo.ReadLine()

                If cFecha = " " Then
                    cFecha = Mid(cRenglon, 11, 8)
                End If

                If Mid(cRenglon, 43, 1) = "C" Then
                    cReferencia = Mid(cRenglon, 71, 7)
                    cReferencia = "0" + Mid(cReferencia, 1, 4) + "0" + Mid(cReferencia, 5, 3)
               
                    ' El siguiente comando me regresa el nombre del cliente

                    cm1 = New SqlCommand()
                    With cm1
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "DepoRefe1"
                        .Connection = cnAgil
                        .Parameters.Add("@Anexo", SqlDbType.NVarChar)
                        .Parameters(0).Value = cReferencia
                    End With
                    cCusnam = cm1.ExecuteScalar()
                    cReferencia = Mid(cReferencia, 1, 5) + "/" + Mid(cReferencia, 6, 4)
                
                    nMonto = Round(Val(Mid(cRenglon, 30, 13)) / 100, 2)
                    drBancos = dtRepBancos.NewRow()
                    drBancos("Fecha") = CTOD(cFecha).ToShortDateString
                    drBancos("Banco") = cBanco
                    drBancos("Referencia") = cReferencia
                    drBancos("Nombre") = cCusnam
                    drBancos("Cargo") = IIf(Mid(cRenglon, 65, 1) = "1", nMonto, 0)
                    drBancos("Abono") = IIf(Mid(cRenglon, 65, 1) = "0", nMonto, 0)
                    dtRepBancos.Rows.Add(drBancos)
                End If

            End While

            oArchivo.Close()

        End If

        If File.Exists("C:\BANAMEX.TXT") Then

            cBanco = "BMEX"

            oArchivo = New StreamReader("C:\BANAMEX.TXT")

            While (oArchivo.Peek() > -1)

                cRenglon = oArchivo.ReadLine()

                If cFecha = " " Then
                    cFecha = "20" & Mid(cRenglon, 5, 2) & Mid(cRenglon, 3, 2) & Mid(cRenglon, 1, 2)
                End If

                If (Mid(cRenglon, 1, 3) = "A13" Or Mid(cRenglon, 1, 3) = "A15" Or Mid(cRenglon, 1, 3) = "A17") And Mid(cRenglon, 8, 8) <> "00000000" Then
                    cReferencia = Mid(cRenglon, 8, 8)
                    cReferencia = Mid(cReferencia, 1, 5) + "0" + Mid(cReferencia, 6, 3)
                
                    ' El siguiente comando me regresa el nombre del cliente

                    cm1 = New SqlCommand()
                    With cm1
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "DepoRefe1"
                        .Connection = cnAgil
                        .Parameters.Add("@Anexo", SqlDbType.NVarChar)
                        .Parameters(0).Value = cReferencia
                    End With
                    cCusnam = cm1.ExecuteScalar()

                    cReferencia = Mid(cReferencia, 1, 5) + "/" + Mid(cReferencia, 6, 4)
                
                    nMonto = Round(Val(Mid(cRenglon, 42, 13)) / 100, 2)
       
                    drBancos = dtRepBancos.NewRow()
                    drBancos("Fecha") = CTOD(cFecha).ToShortDateString
                    drBancos("Banco") = cBanco
                    drBancos("Referencia") = cReferencia
                    drBancos("Nombre") = cCusnam
                    drBancos("Cargo") = IIf(Mid(cRenglon, 65, 1) = "1", nMonto, 0)
                    drBancos("Abono") = IIf(Mid(cRenglon, 65, 1) = "0", nMonto, 0)
                    dtRepBancos.Rows.Add(drBancos)
       
                End If

            End While

            oArchivo.Close()

        End If

        If File.Exists("C:\BANORTE.TXT") Then

            cBanco = "BNTE"

            oArchivo = New StreamReader("C:\BANORTE.TXT")

            While (oArchivo.Peek() > -1)

                cRenglon = oArchivo.ReadLine()

                If Mid(cRenglon, 34, 22) = "CONCENTRACION DE PAGOS" Then

                    If cFecha = " " Then
                        cFecha = Mid(cRenglon, 18, 4) & Mid(cRenglon, 15, 2) & Mid(cRenglon, 12, 2)
                    End If

                    cReferencia = Microsoft.VisualBasic.Right(cRenglon, 8)
                    cReferencia = "0" + Mid(cReferencia, 1, 4) + "0" + Mid(cReferencia, 5, 3)

                    ' El siguiente comando me regresa el nombre del cliente

                    cm1 = New SqlCommand()
                    With cm1
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "DepoRefe1"
                        .Connection = cnAgil
                        .Parameters.Add("@Anexo", SqlDbType.NVarChar)
                        .Parameters(0).Value = cReferencia
                    End With
                    cCusnam = cm1.ExecuteScalar()

                    cReferencia = Mid(cReferencia, 1, 5) + "/" + Mid(cReferencia, 6, 4)

                    cMonto = Mid(cRenglon, 70, 30)
                    cMonto = Mid(cRenglon, 70, InStr(cMonto, "|", CompareMethod.Text) - 1)

                    cMontoSinComas = ""
                    For i = 1 To Len(cMonto)
                        If Mid(cMonto, i, 1) <> "," Then
                            cMontoSinComas += Mid(cMonto, i, 1)
                        End If
                    Next

                    nMonto = Val(cMontoSinComas)

                    drBancos = dtRepBancos.NewRow()
                    drBancos("Fecha") = CTOD(cFecha).ToShortDateString
                    drBancos("Banco") = cBanco
                    drBancos("Referencia") = cReferencia
                    drBancos("Nombre") = cCusnam
                    drBancos("Cargo") = IIf(Mid(cRenglon, 65, 1) = "1", nMonto, 0)
                    drBancos("Abono") = IIf(Mid(cRenglon, 65, 1) = "0", nMonto, 0)
                    dtRepBancos.Rows.Add(drBancos)
                End If

            End While

            oArchivo.Close()

        End If


        oArchivo = Nothing

        ' Aquí cierro y destruyo la conexión

        cnAgil.Close()
        cnAgil = Nothing
        cm1 = Nothing

        cReportTitle = "REPORTE MENSUAL DE DEPOSITOS A BANCOS AL " & Mes(cFecha)
        dsAgil.Tables.Add(dtRepBancos)
        '  dsAgil.WriteXml("C:\Schema19.xml", XmlWriteMode.WriteSchema)
        newrptRepBcos.SetDataSource(dsAgil)
        newrptRepBcos.SummaryInfo.ReportTitle = cReportTitle
        CrystalReportViewer1.ReportSource = newrptRepBcos

    End Sub
End Class