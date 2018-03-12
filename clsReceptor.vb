Public Class clsReceptor

    Public rfc As String
    Public nombre As String
    Public calle As String
    Public colonia As String
    Public municipio As String
    Public estado As String
    Public pais As String
    Public codigoPostal As String

    Public Sub New()
        nombre = ""
        rfc = ""
        calle = ""
        colonia = ""
        municipio = ""
        estado = ""
        pais = "MEXICO"
        codigoPostal = ""
    End Sub

    Public Function validarEmisor() As String
        Dim r As String = ""
        If nombre = "" Then
            r &= "Error en el nombre|"
        End If
        If (rfc.Length > 13) Or (rfc.Length < 12) Then
            r &= "Error en el rfc|"
        End If
        If calle = "" Or calle.Contains("|") Then
            r &= "Error en la calle|"
        End If
        If colonia.Contains("|") Then
            r &= "Error en la colonia|"
        End If
        If municipio.Contains("|") Then
            r &= "Error en el municipio|"
        End If
        If estado.Contains("|") Then
            r &= "Error en el estado|"
        End If
        If pais = "" Or pais.Contains("|") Then
            r &= "Error en el país|"
        End If
        If codigoPostal.Length <> 5 Then
            r &= "Error en el codigo postal|"
        End If
        Return r
    End Function

End Class
