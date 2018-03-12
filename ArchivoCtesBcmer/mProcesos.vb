Option Explicit On 

Module mProcesos

    Public Function CTOD(ByVal cFecha As String) As Date

        Dim nDia, nMes, nYear As Integer

        nDia = Val(Right(cFecha, 2))
        nMes = Val(Mid(cFecha, 5, 2))
        nYear = Val(Left(cFecha, 4))

        CTOD = DateSerial(nYear, nMes, nDia)

    End Function

    Public Function DTOC(ByVal dFecha As Date) As String

        Dim cDia, cMes, cYear, sFecha As String

        sFecha = dFecha.ToShortDateString

        cDia = Left(sFecha, 2)
        cMes = Mid(sFecha, 4, 2)
        cYear = Right(sFecha, 4)

        DTOC = cYear & cMes & cDia

    End Function

    Public Function TraeIVA(ByVal cFecha As String) As Decimal
        Dim nIva As Byte
        Dim cFecha1 As String = "19921111"
        Dim cFecha2 As String = "19950331"
        Dim cFecha3 As String = "19950401"

        If cFecha >= cFecha3 Then
            nIva = 15
        ElseIf cFecha > cFecha1 And cFecha <= cFecha2 Then
            nIva = 10
        ElseIf cFecha <= cFecha1 Then
            nIva = 15
        End If
        TraeIVA = nIva
    End Function

    Public Function Stuff(ByVal Cadena As String, ByVal Lado As String, ByVal Llenarcon As String, ByVal Tamaño As Integer) As String
        Dim cCadenaaux As String
        Dim nVeces As Integer
        Dim i As Integer

        nVeces = Tamaño - Val(Len(Cadena))
        For i = 1 To nVeces
            cCadenaaux = cCadenaaux & Llenarcon
        Next
        If Lado = "D" Then
            Stuff = Cadena & cCadenaaux
        Else
            Stuff = cCadenaaux & Cadena
        End If
    End Function

End Module
