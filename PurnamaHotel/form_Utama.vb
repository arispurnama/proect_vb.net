Public Class form_Utama

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pnmenu1.Visible = True
        pnmenu2.Visible = False
        pnmenu3.Visible = False
        pnmenu4.Visible = False
        pnmenu5.Visible = False
        Timer1.Start()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        pnmenu1.Visible = True
        pnmenu2.Visible = False
        pnmenu3.Visible = False
        pnmenu4.Visible = False
        pnmenu5.Visible = False

        Dim ganti As New tamu
        Panel6.Controls.Clear()
        Panel6.Controls.Add(ganti)

        koneksi()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        pnmenu1.Visible = False
        pnmenu2.Visible = True
        pnmenu3.Visible = False
        pnmenu4.Visible = False
        pnmenu5.Visible = False

        Dim ganti As New karyawan
        Panel6.Controls.Clear()
        Panel6.Controls.Add(ganti)

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        pnmenu1.Visible = False
        pnmenu2.Visible = False
        pnmenu3.Visible = True
        pnmenu4.Visible = False
        pnmenu5.Visible = False

        Dim kamar As New datakamar
        Panel6.Controls.Clear()
        Panel6.Controls.Add(kamar)
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        pnmenu1.Visible = False
        pnmenu2.Visible = False
        pnmenu3.Visible = False
        pnmenu4.Visible = True
        pnmenu5.Visible = False

        Dim cek As New checkin
        Panel6.Controls.Clear()
        Panel6.Controls.Add(cek)

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        pnmenu1.Visible = False
        pnmenu2.Visible = False
        pnmenu3.Visible = False
        pnmenu4.Visible = False
        pnmenu5.Visible = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label1.Text = DateAndTime.Now.ToString()
        Timer1.Start()
    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs) Handles Panel6.Paint

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub pnmenu5_Paint(sender As Object, e As PaintEventArgs) Handles pnmenu5.Paint

    End Sub

    Private Sub pnmenu4_Paint(sender As Object, e As PaintEventArgs) Handles pnmenu4.Paint

    End Sub

    Private Sub pnmenu3_Paint(sender As Object, e As PaintEventArgs) Handles pnmenu3.Paint

    End Sub

    Private Sub pnmenu2_Paint(sender As Object, e As PaintEventArgs) Handles pnmenu2.Paint

    End Sub

    Private Sub pnmenu1_Paint(sender As Object, e As PaintEventArgs) Handles pnmenu1.Paint

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub
End Class
