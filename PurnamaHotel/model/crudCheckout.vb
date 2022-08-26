Imports MySql.Data.MySqlClient

Public Class crudCheckout

    Public Function lihatDataCheckout()
        Dim cot As New DataTable
        Try
            Dim Query As String = "select * from tb_checkout"
            adp = New MySqlDataAdapter(Query, con)
            adp.Fill(cot)
        Catch ex As Exception
            MsgBox("Lihat data dari database ERROR!" + ex.Message, MsgBoxStyle.Information, "Informasi")
        End Try
        Return cot
    End Function

    Public Function tambahCheckout(ByVal kd_checkout As String, ByVal kd_checkin As String, ByVal tanggal_checkout As String) As Boolean
        Dim Query As String = "insert into tb_checkout values(@kd_checkout, @kd_checkin, @tanggal_checkout)"
        Dim Hasil = False
        Try
            cmd = New MySqlCommand(Query, openConnection())
            cmd.Parameters.Add("@kd_checkout", MySqlDbType.VarChar).Value = "COT" + kd_checkout
            cmd.Parameters.Add("@kd_checkin", MySqlDbType.VarChar).Value = kd_checkin
            cmd.Parameters.Add("@tanggal_checkout", MySqlDbType.VarChar).Value = tanggal_checkout
            cmd.ExecuteNonQuery()

            Dim update As String = "update tb_checkin set status_checkin = '" + "selesai" + "' where kd_checkin = '" + kd_checkin + "'"
            cmd = New MySqlCommand(update, openConnection())
            cmd.ExecuteNonQuery()

            Dim update2 As String = "update tb_kamar a join tb_checkin b join tb_checkout c on a.kd_kamar = b.kd_kamar and b.kd_checkin = c.kd_checkin set a.status = '" + "Tersedia" + "' where c.kd_checkin = '" + kd_checkin + "'"
            cmd = New MySqlCommand(update2, con)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("Tambah Data ERROR!" + ex.Message, MsgBoxStyle.Information, "")
        End Try
        Return Hasil
    End Function

    Public Function viewTransaksi()
        Dim co As New DataTable
        Try
            Dim Query As String = "select c.kd_checkout, a.nama_tamu, b.kd_checkin, a.id_tamu, b.kd_kamar, a.no_telepon, b.tgl_checkin, c.tanggal_checkout, b.lama_tinggal, d.harga from tb_tamu a, tb_checkin b, tb_checkout c, tb_kamar d where a.id_tamu = b.id_tamu and b.kd_checkin = c.kd_checkin and b.kd_kamar = d.kd_kamar and b.status_checkin = '" + "selesai" + "' order by kd_checkout desc"
            adp = New MySqlDataAdapter(Query, con)
            adp.Fill(co)
        Catch ex As Exception
            MsgBox("Lihat data dari database ERROR!" + ex.Message, MsgBoxStyle.Information, "Informasi")
        End Try
        Return co
    End Function
End Class


