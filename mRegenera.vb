Option Explicit On

Imports System.Data.SqlClient
Imports System.Math

Module mRegenera

    Public Sub Regenera(ByVal cAnexo As String)

        cAnexo = Mid(cAnexo, 1, 5) & Mid(cAnexo, 7, 4)

        ' Declaración de variables de conexión ADO .NET

        Dim cnAgil As New SqlConnection(strConn)
        Dim cm1 As New SqlCommand
        Dim cm2 As New SqlCommand()
        Dim daAnexos As New SqlDataAdapter(cm1)
        Dim daEdoctav As New SqlDataAdapter(cm2)
        Dim dsAgil As New DataSet()
        Dim drAnexo As DataRow
        Dim drEdoctav As DataRow

        ' Declaración de variables de datos

        Dim nLetra As Integer
        Dim nPlazo As Integer
        Dim nPlazoRestante As Integer
        Dim nSaldoEquipo As Decimal

        ' El siguiente Stored Procedure trae todos los atributos de la tabla Anexos,
        ' para un anexo dado

        With cm1
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DatosCon1"
            .Connection = cnAgil
            .Parameters.Add("@Anexo", SqlDbType.NVarChar)
            .Parameters(0).Value = cAnexo
        End With

        ' Obtengo la tabla de amortización del Equipo

        With cm2
            .CommandType = CommandType.StoredProcedure
            .CommandText = "TablaEquipo1"
            .Connection = cnAgil
            .Parameters.Add("@Anexo", SqlDbType.NVarChar)
            .Parameters(0).Value = cAnexo
        End With

        ' Llenar el DataSet lo cual abre y cierra la conexión y después destruyo la conexión y los comandos
        ' ya que no los utilizo más

        daAnexos.Fill(dsAgil, "Anexos")
        daEdoctav.Fill(dsAgil, "Edoctav")
        cnAgil.Dispose()
        cm1.Dispose()
        cm2.Dispose()

        drAnexo = dsAgil.Tables("Anexos").Rows(0)
        nPlazo = drAnexo("Plazo")

        nSaldoEquipo = 0
        nLetra = 0

        For Each drEdoctav In dsAgil.Tables("Edoctav").Rows
            If drEdoctav("Nufac") = 0 And nLetra = 0 Then
                nLetra = Val(drEdoctav("Letra"))
                nSaldoEquipo = drEdoctav("Saldo")
            End If
        Next

        nPlazoRestante = nPlazo - nLetra + 1

        RegTabla(cAnexo, nSaldoEquipo, nPlazoRestante, "E")

        MsgBox("Regeneración Terminada", MsgBoxStyle.Information, "Mensaje del Sistema")

    End Sub

End Module
