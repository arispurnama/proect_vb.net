Imports MySql.Data.MySqlClient

Public Class crudCheckin


    Public Function lihatDataCheckin()
        Dim ci As New DataTable
        Try
            Dim Query As String = "select * from tb_checkin where status_checkin = '" + "dipesan" + "'"
            adp = New MySqlDataAdapter(Query, con)
            adp.Fill(ci)
        Catch ex As Exception
            MsgBox("Lihat data dari database ERROR!" + ex.Message, MsgBoxStyle.Information, "Informasi")
        End Try
        Return ci
    End Function

    Public Function tambahCheckin(ByVal kd_checkin As String, ByVal kd_kamar As String, ByVal id_tamu As String, ByVal id_karyawan As String, ByVal tgl_checkin As String, ByVal lama_tinggal As String, ByVal keterangan As String, ByVal status_checkin As String) As Boolean
        Dim Query As String = "insert into tb_checkin values(@kd_checkin, @kd_kamar, @id_tamu, @id_karyawan, @tgl_checkin, @lama_tinggal, @keterangan, @status_checkin)"
        'Dim tgl = DateTime.ParseExact(tgl_checkin, "#")
        Dim Hasil = False
        Try
            cmd = New MySqlCommand(Query, openConnection())
            cmd.Parameters.Add("@kd_checkin", MySqlDbType.VarChar).Value = "CIN" + kd_checkin
            cmd.Parameters.Add("@kd_kamar", MySqlDbType.VarChar).Value = kd_kamar
            cmd.Parameters.Add("@id_tamu", MySqlDbType.VarChar).Value = id_tamu
            cmd.Parameters.Add("@id_karyawan", MySqlDbType.VarChar).Value = id_karyawan
            cmd.Parameters.Add("@tgl_checkin", MySqlDbType.VarChar).Value = tgl_checkin
            cmd.Parameters.Add("@lama_tinggal", MySqlDbType.VarChar).Value = lama_tinggal
            cmd.Parameters.Add("@keterangan", MySqlDbType.VarChar).Value = keterangan
            cmd.Parameters.Add("@status_checkin", MySqlDbType.VarChar).Value = status_checkin
            cmd.ExecuteNonQuery()
            Dim update As String = "update tb_kamar set status='" + "Terisi" + "' where kd_kamar='" + kd_kamar + "'"
            cmd = New MySqlCommand(update, openConnection())
            cmd.ExecuteNonQuery()
            Hasil = True
        Catch ex As Exception
            MsgBox("Tambah Data ERROR!" + ex.Message, MsgBoxStyle.Information, "")
        End Try
        Return Hasil
    End Function

    Public Function hapusCheckin(ByVal kd_checkin As String, ByVal kd_kamar As String)
        Dim Query As String = "delete from tb_checkin where kd_checkin ='" + kd_checkin + "'"
        Dim Hasil = False
        Try
            cmd = New MySqlCommand(Query, openConnection())
            cmd.Parameters.Add("kd_checkin", MySqlDbType.VarChar).Value = kd_checkin
            cmd.ExecuteNonQuery()
            Dim update As String = "update tb_kamar set status='" + "Tersedia" + "' where kd_kamar='" + kd_kamar + "'"
            cmd = New MySqlCommand(update, openConnection())
            cmd.ExecuteNonQuery()
            Hasil = True

        Catch ex As Exception
            MsgBox("Hapus Data ERROR!" + ex.Message)
        End Try
        Return Hasil
    End Function

    Public Function ubahCheckin(ByVal kd_checkin As String, ByVal kd_kamar As String, ByVal id_tamu As String, ByVal id_karyawan As String, ByVal tgl_checkin As String, ByVal lama_tinggal As String, ByVal keterangan As String, ByVal status_checkin As String) As Boolean
        Dim Query As String = "update tb_checkin set kd_kamar=@kd_kamar, id_tamu=@id_tamu, id_karyawan=@id_karyawan, tgl_checkin=@tgl_checkin, lama_tinggal=@lama_tinggal, keterangan=@keterangan, status_checkin=@status_checkin where kd_checkin='" + kd_checkin + "'"
        Dim Hasil = False
        Try
            cmd = New MySqlCommand(Query, openConnection())
            cmd.Parameters.Add("@kd_checkin", MySqlDbType.VarChar).Value = kd_checkin
            cmd.Parameters.Add("@kd_kamar", MySqlDbType.VarChar).Value = kd_kamar
            cmd.Parameters.Add("@id_tamu", MySqlDbType.VarChar).Value = id_tamu
            cmd.Parameters.Add("@id_karyawan", MySqlDbType.VarChar).Value = id_karyawan
            cmd.Parameters.Add("@tgl_checkin", MySqlDbType.VarChar).Value = tgl_checkin
            cmd.Parameters.Add("@lama_tinggal", MySqlDbType.VarChar).Value = lama_tinggal
            cmd.Parameters.Add("@keterangan", MySqlDbType.VarChar).Value = keterangan
            cmd.Parameters.Add("@status_checkin", MySqlDbType.VarChar).Value = status_checkin
            cmd.ExecuteNonQuery()
            Hasil = True
        Catch ex As Exception
            MsgBox("Ubah Data ERROR!" + ex.Message, MsgBoxStyle.Information, "")
        End Try
        Return Hasil
    End Function
End Class
