Public Class Inicio
    Dim mover As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Private Sub Form1_MouseDown(ByVal sender As Object,
                                ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        mover = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object,
                                ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If mover Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Form1_MouseUp(ByVal sender As Object,
                              ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        mover = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Ajedrez.Show()
    End Sub
End Class