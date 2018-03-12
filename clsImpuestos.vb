Public Class clsImpuestos

    Public impuesto As String
    Public tasa As Decimal
    Public importe As Decimal

    Public Sub New()
        impuesto = ""
        tasa = 0.0
        importe = 0.0
    End Sub

    Public Function ValidarTraslado() As String
        Dim r As String = ""
        If (impuesto = "") Or (tasa = 0.0) Or (importe = 0.0) Then
            r = "Error en la informacion del impuesto de traslado|"
        End If
        Return r
    End Function

End Class
