Imports MySql.Data.MySqlClient
Public Class datakamar
    Public conn As MySqlConnection
    Public cmd As MySqlCommand
    Public rd As MySqlDataReader
    Public da As MySqlDataAdapter
    Public ds As DataSet
    Public str As String

    Sub koneksi()
        Try
            Dim str As String = "server=localhost;user id=root;database=hotel"
            conn = New MySqlConnection(str)
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub tutup()
        conn.Close()
        conn.Dispose()
    End Sub

    Private Sub datakamar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim grid1 As New DataTable
        Dim query As String = "select * from tb_kamar"
        Try
            adp = New MySqlDataAdapter(query, openConnection())
            adp.Fill(grid1)
            DataGridView1.DataSource = grid1
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim grid2 As New DataTable
        Dim query2 As String = "select * from tb_tipekamar"
        Try
            adp = New MySqlDataAdapter(query2, openConnection())
            adp.Fill(grid2)
            DataGridView2.DataSource = grid2
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim grid3 As New DataTable
        Dim query3 As String = "select * from tb_fasilitas"
        Try
            adp = New MySqlDataAdapter(query3, openConnection())
            adp.Fill(grid3)
            DataGridView3.DataSource = grid3
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        connectdb()
        initCMD()
        isiDataCB1()
        isiDataCB2()
    End Sub
    Public Sub isiDataCB1()
        Try
            Dim isi = "select kd_tipekamar from tb_tipekamar"
            With comDB
                .CommandText = isi
                .ExecuteNonQuery()
            End With
            rdDB = comDB.ExecuteReader
            If rdDB.HasRows = True Then
                While rdDB.Read
                    ComboBox1.Items.Add(rdDB("kd_tipekamar"))
                End While
            End If
            rdDB.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub isiDataCB2()
        Try
            Dim isi = "select kd_fasilitas from tb_fasilitas"
            With comDB
                .CommandText = isi
                .ExecuteNonQuery()
            End With
            rdDB = comDB.ExecuteReader
            If rdDB.HasRows = True Then
                While rdDB.Read
                    ComboBox2.Items.Add(rdDB("kd_fasilitas"))
                End While
            End If
            rdDB.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        ComboBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        ComboBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
        ComboBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
        ComboBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim insert As String = "insert into tb_kamar values ('" & "KAM" + TextBox1.Text & "','" & ComboBox1.Text & "','" & ComboBox2.Text & "'," & TextBox2.Text & ",'" & ComboBox3.Text & "','" & ComboBox4.Text & "')"
            cmd = New MySqlCommand(insert, openConnection())
            cmd.ExecuteNonQuery()
            MsgBox("succesful added Data")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Dim grid1 As New DataTable
        Dim query As String = "select * from tb_kamar"
        Try
            adp = New MySqlDataAdapter(query, openConnection())
            adp.Fill(grid1)
            DataGridView1.DataSource = grid1
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim grid2 As New DataTable
        Dim query2 As String = "select * from tb_tipekamar"
        Try
            adp = New MySqlDataAdapter(query2, openConnection())
            adp.Fill(grid2)
            DataGridView2.DataSource = grid2
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim grid3 As New DataTable
        Dim query3 As String = "select * from tb_fasilitas"
        Try
            adp = New MySqlDataAdapter(query3, openConnection())
            adp.Fill(grid3)
            DataGridView3.DataSource = grid3
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        connectdb()
        initCMD()
        isiDataCB1()
        isiDataCB2()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Call koneksi()
        Try
            Dim update As String = "update tb_kamar set kd_tipekamar = '" & ComboBox1.Text & "', kd_fasilitas = '" & ComboBox2.Text & "', harga = " & TextBox2.Text & ", kapasitas = '" & ComboBox3.Text & "', status = '" & ComboBox4.Text & "' where kd_kamar = '" & TextBox1.Text & "'"
            cmd = New MySqlCommand(update, openConnection())
            cmd.ExecuteNonQuery()
            MsgBox("succesful added Data")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Dim grid1 As New DataTable
        Dim query As String = "select * from tb_kamar"
            Try
            adp = New MySqlDataAdapter(query, openConnection())
            adp.Fill(grid1)
                DataGridView1.DataSource = grid1
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            Dim grid2 As New DataTable
            Dim query2 As String = "select * from tb_tipekamar"
            Try
            adp = New MySqlDataAdapter(query2, openConnection())
            adp.Fill(grid2)
                DataGridView2.DataSource = grid2
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            Dim grid3 As New DataTable
            Dim query3 As String = "select * from tb_fasilitas"
            Try
            adp = New MySqlDataAdapter(query3, openConnection())
            adp.Fill(grid3)
                DataGridView3.DataSource = grid3
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            connectdb()
            initCMD()
            isiDataCB1()
            isiDataCB2()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call koneksi()

        Try
            Dim quer As String = "delete from tb_kamar where kd_kamar = '" & TextBox1.Text & "'"
            cmd = New MySqlCommand(quer, openConnection())
            cmd.ExecuteNonQuery()
            MsgBox("succesful delete")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim grid1 As New DataTable
        Dim query As String = "select * from tb_kamar"
        Try
            adp = New MySqlDataAdapter(query, openConnection())
            adp.Fill(grid1)
            DataGridView1.DataSource = grid1
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim grid2 As New DataTable
        Dim query2 As String = "select * from tb_tipekamar"
        Try
            adp = New MySqlDataAdapter(query2, openConnection())
            adp.Fill(grid2)
            DataGridView2.DataSource = grid2
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim grid3 As New DataTable
        Dim query3 As String = "select * from tb_fasilitas"
        Try
            adp = New MySqlDataAdapter(query3, openConnection())
            adp.Fill(grid3)
            DataGridView3.DataSource = grid3
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        connectdb()
        initCMD()
        isiDataCB1()
        isiDataCB2()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox1.Clear()
        ComboBox1.Controls.Clear()
        ComboBox2.Controls.Clear()
        ComboBox3.Controls.Clear()
        ComboBox4.Controls.Clear()
        TextBox2.Clear()

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        Try
            Call koneksi()
            da = New MySqlDataAdapter("select * from tb_kamar where " + ComboBox5.Text + " like '%" + TextBox4.Text + "%'", conn)
            ds = New DataSet
            da.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
            tutup()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridView3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellContentClick

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class
