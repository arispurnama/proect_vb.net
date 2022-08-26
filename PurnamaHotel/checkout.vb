Imports MySql.Data.MySqlClient


Public Class checkout

    Dim cek As New crudCheckout
    Dim angka1 As Integer
    Dim angka2 As Integer
    Dim jumlah As Integer
    Dim bayar As Integer

    Private Sub checkout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Panel1.Visible = False
        DataGridView1.DataSource = cek.viewTransaksi
    End Sub



    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If TextBox1.Text = "" Then
            MsgBox("Tidak Boleh Dikosongkan!", MsgBoxStyle.Information, "")
        Else
            Dim tgl = DateTimePicker1.Value.ToString("yyyy-MM-dd")
            cek.tambahCheckout(TextBox1.Text, TextBox3.Text, tgl)

        End If

        DataGridView1.DataSource = cek.viewTransaksi

    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pilih.Click
        Panel1.Visible = True
        TextBox4.Text = DataGridView1.CurrentRow.Cells(3).Value.ToString
        TextBox5.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
        TextBox6.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString
        TextBox7.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString
        TextBox8.Text = DataGridView1.CurrentRow.Cells(4).Value.ToString
        TextBox9.Text = DataGridView1.CurrentRow.Cells(5).Value.ToString
        TextBox10.Text = DataGridView1.CurrentRow.Cells(6).Value.ToString
        TextBox11.Text = DataGridView1.CurrentRow.Cells(7).Value.ToString
        TextBox12.Text = DataGridView1.CurrentRow.Cells(8).Value.ToString
        TextBox13.Text = DataGridView1.CurrentRow.Cells(9).Value.ToString

        angka1 = TextBox12.Text
        angka2 = TextBox13.Text

        jumlah = angka1 * angka2
        TextBox14.Text = jumlah
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If Val(TextBox14.Text) <= Val(TextBox15.Text) Then
            MsgBox("Transaksi Berhasil", MsgBoxStyle.OkOnly, "")
            Call koneksi()
            Try
                Dim insert As String = "insert into tb_history values ('" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "','" & TextBox9.Text & "','" & TextBox10.Text & "','" & TextBox11.Text & "','" & TextBox12.Text & "','" & TextBox13.Text & "','" & TextBox14.Text & "','" & TextBox15.Text & "')"
                cmd = New MySqlCommand(insert, openConnection())
                cmd.ExecuteNonQuery()
                MsgBox("Succsesfull Added Data!!")
            Catch ex As Exception
                MsgBox("added Error : " + ex.Message)
            End Try
            Dim ganti As New checkin
            form_Utama.Panel6.Controls.Clear()
            form_Utama.Panel6.Controls.Add(ganti)
        Else
            MsgBox("Uang anda tidak cukup!", MsgBoxStyle.OkOnly, "")
            TextBox15.Clear()
            TextBox15.Focus()
        End If
    End Sub
End Class
