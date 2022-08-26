Imports MySql.Data.MySqlClient

Public Class karyawan
    Dim con1 As MySqlConnection
    Dim cmd1 As MySqlCommand
    Dim adp1 As MySqlDataAdapter
    Dim dt_karyawan As New DataTable
    Sub cetaksemua()
        cmd1 = New MySqlCommand("select * from tb_karyawan", con1)
        adp1 = New MySqlDataAdapter(cmd1)
        adp1.Fill(dt_karyawan)

        con1.Close()
        con1.Dispose()
    End Sub
    Private Sub karyawan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ban As New karyawan
        Dim data As New DataTable
        Dim queri As String = "Select * From tb_karyawan"
        Try
            adp = New MySqlDataAdapter(queri, openConnection())
            adp.Fill(data)
            DataGridView1.DataSource = data
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call koneksi()
        Try
            Dim insertString As String = "insert into tb_karyawan values ('" & "KAR" + TextBox1.Text & "',' " & TextBox2.Text & "','" & TextBox3.Text & "','" & ComboBox1.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "')"
            cmd = New MySqlCommand(insertString, openConnection())
            cmd.ExecuteNonQuery()
            MsgBox("Sucses")
        Catch ex As Exception
            MsgBox("Gagal" + ex.Message)
        End Try
        Dim ban As New karyawan
        Dim data As New DataTable
        Dim queri As String = "Select * From tb_karyawan"
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
        TextBox5.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value
        TextBox6.Text = DataGridView1.Rows(e.RowIndex).Cells(6).Value

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim updateString As String = "update tb_karyawan set no_ktp='" & TextBox2.Text & "',nama_karyawan='" & TextBox3.Text & "',jenis_kelamin='" & ComboBox1.Text & "',alamat='" & TextBox4.Text & "',email='" & TextBox5.Text & "',no_telepon='" & TextBox6.Text & "' where id_karyawan='" & TextBox1.Text & "'"
            cmd = New MySqlCommand(updateString, openConnection())
            cmd.ExecuteNonQuery()
            MsgBox("Successfully added data!")
        Catch ex As Exception
            MsgBox("Msg Error :" + ex.Message)
        End Try

        Dim ban As New karyawan
        Dim data As New DataTable
        Dim queri As String = "Select * From tb_karyawan"
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
            Dim query As String = "delete from tb_karyawan where id_karyawan = '" & TextBox1.Text & "'"
            cmd = New MySqlCommand(query, openConnection())
            cmd.ExecuteNonQuery()
            MsgBox("succesful delete")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim ban As New karyawan
        Dim data As New DataTable
        Dim queri As String = "Select * From tb_karyawan"
        Try
            adp = New MySqlDataAdapter(queri, openConnection())
            adp.Fill(data)
            DataGridView1.DataSource = data
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            ComboBox1.Controls.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            TextBox6.Clear()
        Catch ex As Exception
            MsgBox("tidak di batalkan")
        End Try

    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim rpt As New rptKaryawan
        rpt.Show()
    End Sub
End Class
