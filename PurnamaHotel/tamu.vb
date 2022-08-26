Imports MySql.Data.MySqlClient
Public Class tamu
    Dim con1 As MySqlConnection
    Dim cmd1 As MySqlCommand
    Dim adp1 As MySqlDataAdapter
    Dim dt_tamu As New DataTable
    Sub cetaksemua()
        cmd1 = New MySqlCommand("select * from tb_tamu", con1)
        adp1 = New MySqlDataAdapter(cmd1)
        adp1.Fill(dt_tamu)

        con1.Close()
        con1.Dispose()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    End Sub

    Private Sub tamu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Data As New DataTable
        Dim tamp As String = "select * from tb_tamu"
        Try
            adp = New MySqlDataAdapter(tamp, openConnection())
            adp.Fill(Data)
            DataGridView1.DataSource = Data
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim rpt As New rptTamu
        rpt.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Call koneksi()

        Try
            Dim update As String = "update tb_tamu set no_ktp = '" & TextBox2.Text & "',nama_tamu = '" & TextBox3.Text & "',jenis_kelamin = '" & ComboBox1.Text & "', alamat = '" & TextBox4.Text & "',email = '" & TextBox6.Text & "',no_telepon = '" & TextBox7.Text & "' where id_tamu = '" & TextBox1.Text & "'"
            cmd = New MySqlCommand(update, openConnection())
            cmd.ExecuteNonQuery()
            MsgBox("succesfull upadte data!!")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim data As New DataTable
        Dim queri As String = "select * from tb_tamu"
        Try
            adp = New MySqlDataAdapter(queri, openConnection())
            adp.Fill(data)
            DataGridView1.DataSource = data
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call koneksi()

        Try
            Dim query As String = "delete from tb_tamu where id_tamu = '" & TextBox1.Text & "'"
            cmd = New MySqlCommand(query, openConnection())
            cmd.ExecuteNonQuery()
            MsgBox("succesful delete")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim ban As New karyawan
        Dim data As New DataTable
        Dim queri As String = "Select * From tb_tamu"
        Try
            adp = New MySqlDataAdapter(queri, openConnection())
            adp.Fill(data)
            DataGridView1.DataSource = data
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub DataGridView1_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        ComboBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
        TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
        TextBox6.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value
        TextBox7.Text = DataGridView1.Rows(e.RowIndex).Cells(6).Value

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class
