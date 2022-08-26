'Imports MySql.Data.MySqlClient
'Public Class checkin
'    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
'        Dim out As New checkout
'        form_Utama.Panel6.Controls.Clear()
'        form_Utama.Panel6.Controls.Add(out)
'    End Sub

'    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

'    End Sub

'    Private Sub checkin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
'        connectdb()
'        initCMD()
'        isiDataCB1()
'        isiDataCB2()
'        isiDataCB3()
'    End Sub
'    Public Sub isiDataCB1()
'        Try
'            Dim isi = "select kd_kamar from tb_kamar"
'            With comDB
'                .CommandText = isi
'                .ExecuteNonQuery()
'            End With
'            rdDB = comDB.ExecuteReader
'            If rdDB.HasRows = True Then
'                While rdDB.Read
'                    ComboBox1.Items.Add(rdDB("kd_kamar"))
'                End While
'            End If
'            rdDB.Close()
'        Catch ex As Exception
'            MsgBox(ex.ToString)
'        End Try
'    End Sub
'    Public Sub isiDataCB2()
'        Try
'            Dim isi = "select id_tamu from tb_tamu"
'            With comDB
'                .CommandText = isi
'                .ExecuteNonQuery()
'            End With
'            rdDB = comDB.ExecuteReader
'            If rdDB.HasRows = True Then
'                While rdDB.Read
'                    ComboBox2.Items.Add(rdDB("id_tamu"))
'                End While
'            End If
'            rdDB.Close()
'        Catch ex As Exception
'            MsgBox(ex.ToString)
'        End Try
'    End Sub
'    Public Sub isiDataCB3()
'        Try
'            Dim isi = "select id_karyawan from tb_karyawan"
'            With comDB
'                .CommandText = isi
'                .ExecuteNonQuery()
'            End With
'            rdDB = comDB.ExecuteReader
'            If rdDB.HasRows = True Then
'                While rdDB.Read
'                    ComboBox3.Items.Add(rdDB("id_karyawan"))
'                End While
'            End If
'            rdDB.Close()
'        Catch ex As Exception
'            MsgBox(ex.ToString)
'        End Try
'    End Sub

'    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

'    End Sub
'End Class
Imports MySql.Data.MySqlClient

Public Class checkin


    Dim cek As New crudCheckin
    Dim cout As New checkout
    Public conn As MySqlConnection
    Public cmd As MySqlCommand
    Public rd As MySqlDataReader
    Public da As MySqlDataAdapter
    Public ds As DataSet
    Public str As String
    Private Sub DataGridView1_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        ComboBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        ComboBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        ComboBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
        DateTimePicker1.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
        TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value
        TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(6).Value
        ComboBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(7).Value
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        cout.TextBox3.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString
        form_Utama.Panel6.Controls.Clear()
        form_Utama.Panel6.Controls.Add(cout)
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim rpt As New rptTransaksi
        rpt.Show()
    End Sub

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


    Private Sub checkin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        refreshCheckin()
        connectdb()
        initCMD()
        isiDataCB1()
        isiDataCB2()
        isiDataCB3()
    End Sub

    Public Sub isiDataCB1()
        Try
            Dim isi = "select kd_kamar from tb_kamar where status = '" + "tersedia" + "'"
            With comDB
                .CommandText = isi
                .ExecuteNonQuery()
            End With
            rdDB = comDB.ExecuteReader
            If rdDB.HasRows = True Then
                While rdDB.Read
                    ComboBox1.Items.Add(rdDB("kd_kamar"))
                End While
            End If
            rdDB.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Sub isiDataCB2()
        Try
            Dim isi = "select id_tamu from tb_tamu"
            With comDB
                .CommandText = isi
                .ExecuteNonQuery()
            End With
            rdDB = comDB.ExecuteReader
            If rdDB.HasRows = True Then
                While rdDB.Read
                    ComboBox2.Items.Add(rdDB("id_tamu"))
                End While
            End If
            rdDB.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Sub isiDataCB3()
        Try
            Dim isi = "select id_karyawan from tb_karyawan"
            With comDB
                .CommandText = isi
                .ExecuteNonQuery()
            End With
            rdDB = comDB.ExecuteReader
            If rdDB.HasRows = True Then
                While rdDB.Read
                    ComboBox3.Items.Add(rdDB("id_karyawan"))
                End While
            End If
            rdDB.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Sub refreshCheckin()
        DataGridView1.DataSource = cek.lihatDataCheckin
        Dim x As DataTable = cek.lihatDataCheckin
        If x Is Nothing Then
            Button2.Enabled = False
        End If
    End Sub

    'Inser Data
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or ComboBox1.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Or DateTimePicker1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or ComboBox4.Text = "" Then
            MsgBox("Tidak Boleh Dikosongkan!", MsgBoxStyle.Information, "")
        Else
            Dim tgl = DateTimePicker1.Value.ToString("yyyy-MM-dd")
            cek.tambahCheckin(TextBox1.Text, ComboBox1.Text, ComboBox2.Text, ComboBox3.Text, tgl, TextBox2.Text, TextBox3.Text, ComboBox4.Text)
            refreshCheckin()
        End If
        Dim ganti As New checkin
        form_Utama.Panel6.Controls.Clear()
        form_Utama.Panel6.Controls.Add(ganti)
    End Sub

    'Hapus Data
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim ex As String = DataGridView1.CurrentRow.Cells(0).Value.ToString
        Dim ee As String = DataGridView1.CurrentRow.Cells(1).Value.ToString
        Dim dr As DialogResult = MsgBox("Apakah anda yakin ingin menghapus data ini?", MsgBoxStyle.YesNo, "")
        If dr = DialogResult.Yes Then
            If cek.hapusCheckin(ex, ee) Then
                MsgBox("Hapus data berhasil!", MsgBoxStyle.Information, "")
                refreshCheckin()
                reload()
            End If
        End If
    End Sub

    'Update Data
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If ComboBox1.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or ComboBox4.Text = "" Then
            MsgBox("Tidak Boleh Dikosongkan!", MsgBoxStyle.Information, "")
        Else
            Dim tgl = DateTimePicker1.Value.ToString("yyyy-MM-dd")
            cek.ubahCheckin(TextBox1.Text, ComboBox1.Text, ComboBox2.Text, ComboBox3.Text, tgl, TextBox2.Text, TextBox3.Text, ComboBox4.Text)
            refreshCheckin()
            Dim checkin As New checkin
            form_Utama.Panel6.Controls.Clear()
            form_Utama.Panel6.Controls.Add(checkin)
        End If

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        TextBox1.Clear()
        ComboBox1.Items.Clear()
        ComboBox2.Items.Clear()
        ComboBox3.Items.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        ComboBox4.Items.Clear()
        'Dim ganti As New checkin
        'form_Utama.Panel2.Controls.Clear()
        'form_Utama.Panel2.Controls.Add(ganti)
    End Sub

    Sub cari()
        Try
            Call koneksi()
            da = New MySqlDataAdapter("select * from tb_checkin where " + ComboBox5.Text + " like '%" + TextBox4.Text + "%'", conn)
            ds = New DataSet
            da.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
            tutup()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox4_TextChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        cari()
    End Sub

    Sub reload()
        Dim ganti As New checkin
        form_Utama.Panel6.Controls.Clear()
        form_Utama.Panel6.Controls.Add(ganti)
    End Sub

    'Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
    '    cout.TextBox3.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString
    '    form_Utama.Panel2.Controls.Clear()
    '    form_Utama.Panel2.Controls.Add(cout)
    'End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress, TextBox2.KeyPress
        'angka(e)
    End Sub

    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        'alamat(e)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class
