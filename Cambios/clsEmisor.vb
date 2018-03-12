Public Class clsEmisor

    Public rfc As String
    Public nombre As String

    Public calle As String
    Public colonia As String
    Public municipio As String
    Public estado As String
    Public pais As String
    Public codigoPostal As String

    Public expedidoEn_calle As String
    Public expedidoEn_colonia As String
    Public expedidoEn_municipio As String
    Public expedidoEn_estado As String
    Public expedidoEn_pais As String
    Public expedidoEn_codigoPostal As String

    Public Sub New()

        rfc = "FIN940905AX7"
        nombre = "FINAGIL S.A. DE C.V. SOFOM ENR"

        calle = "LEANDRO VALLE 402"
        colonia = "REFORMA Y FFCCNN"
        municipio = "TOLUCA"
        estado = "ESTADO DE MEXICO"
        pais = "MEXICO"
        codigoPostal = "50070"

        expedidoEn_calle = ""
        expedidoEn_colonia = ""
        expedidoEn_municipio = ""
        expedidoEn_estado = ""
        expedidoEn_pais = ""
        expedidoEn_codigoPostal = ""

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
        If (municipio = "") Or (municipio.Contains("|")) Then
            r &= "Error en el municipio|"
        End If
        If (estado = "") Or (estado.Contains("|")) Then
            r &= "Error en el estado|"
        End If
        If (pais = "") Or (pais.Contains("|")) Then
            r &= "Error en el país|"
        End If
        If (codigoPostal = "") Or (codigoPostal.Length <> 5) Then
            r &= "Error en el codigo postal|"
        End If
        Return r
    End Function

End Class
