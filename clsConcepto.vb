Public Class clsConcepto

    Public cantidad As Decimal
    Public unidad As String
    Public descripcion As String
    Public valorUnitario As Decimal
    Public importe As Decimal

    Public Sub New()
        cantidad = 0.0
        unidad = "NO APLICA"
        descripcion = ""
        valorUnitario = 0.0
        importe = 0.0
    End Sub

    Public Function ValidaConceptos() As String
        Dim r As String = ""
        If cantidad = 0.0 Or unidad = "" Or descripcion = "" Or valorUnitario = 0.0 Or importe = 0.0 Then
            r = "Verifique los valores para la Cantidad, Unidad, Descripción, Valor unitario e Importe|"
        End If
        Return r
    End Function

End Class
