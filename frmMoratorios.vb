Public Class frmMoratorios

    Private _moratorios As Decimal

    Public Property Moratorios() As Decimal
        Get
            Return _moratorios
        End Get
        Set(ByVal value As Decimal)
            _moratorios = value
        End Set
    End Property

    Dim nImporteOriginal As Decimal

    Public Sub New(ByVal nTotalMoratorios As Decimal)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtMoratorios.Text = nTotalMoratorios
        nImporteOriginal = nTotalMoratorios

    End Sub

    Private Sub txtMoratorios_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMoratorios.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii, txtMoratorios.Text))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If CDec(txtMoratorios.Text) <= nImporteOriginal Then
            Me.Moratorios = CDec(txtMoratorios.Text)
            Me.Close()
        End If
    End Sub

End Class