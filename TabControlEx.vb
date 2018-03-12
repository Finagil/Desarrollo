Option Strict On

    Public Class TabControlEx
        Inherits System.Windows.Forms.TabControl
        Private Const WM_LBUTTONDOWN As Integer = &H201

        Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
            If m.Msg = WM_LBUTTONDOWN Then
                Dim pt As New Point(m.LParam.ToInt32)
                Dim index As Integer
                For index = 0 To Me.TabPages.Count - 1
                    If GetTabRect(index).Contains(pt) Then
                        If TabPages(index).Enabled Then
                            MyBase.WndProc(m)
                        End If
                        Exit Sub
                    End If
                Next
            End If
            MyBase.WndProc(m)
        End Sub

    Public Sub DisablePage(ByRef pTabPage As TabPage)
        pTabPage.Enabled = False
    End Sub

    Private Sub TabControlEx_DrawItem _
        (ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) _
        Handles MyBase.DrawItem

        Try
            Dim intOffsetLeft As Int32
            Dim intOffsetTop As Int32
            Dim r As RectangleF = RectangleF.op_Implicit(e.Bounds)
            Dim r2 As RectangleF
            Dim ItemBrush As New SolidBrush(Me.BackColor)
            Dim b As Brush
            If Me.TabPages(e.Index).Enabled Then
                b = Brushes.Black
            Else
                b = Brushes.Gray
            End If

            Dim sf As New StringFormat()
            sf.Alignment = StringAlignment.Center
            sf.LineAlignment = StringAlignment.Center

            Dim im As Bitmap
            If Me.TabPages(e.Index).ImageIndex <> -1 Then
                im = CType(Me.ImageList.Images(Me.TabPages(e.Index).ImageIndex), Bitmap)
            End If

            If Me.TabPages(e.Index).ImageIndex <> -1 Then
                r2 = New RectangleF(r.X + (im.Width \ 2), r.Y, r.Width, r.Height)
            Else
                r2 = New RectangleF(r.X, r.Y, r.Width, r.Height)
            End If

            If CBool(e.State And DrawItemState.Selected) Then
                e.Graphics.FillRectangle(ItemBrush, e.Bounds)
                e.Graphics.DrawString(Me.TabPages(e.Index).Text, e.Font, b, r2, sf)

                intOffsetLeft = 5
                intOffsetTop = 5
            Else
                e.Graphics.DrawString(Me.TabPages(e.Index).Text, e.Font, b, r2, sf)
                intOffsetLeft = 2
                intOffsetTop = 2
            End If

            If Me.TabPages(e.Index).ImageIndex <> -1 Then
                Me.ImageList.Draw(e.Graphics, _
                             Convert.ToInt32(r.Left) + intOffsetLeft, _
                             Convert.ToInt32(r.Top) + intOffsetTop, _
                             Me.TabPages(e.Index).ImageIndex)
            End If
        Catch ex As Exception
            'The control is probably being disposed!!!
        End Try
    End Sub
End Class


