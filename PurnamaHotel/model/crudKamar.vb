Imports MySql.Data.MySqlClient

Public Class crudKamar


    'TAMPILKAN DATA DI DATAGRIDVIEW ================================================

    Public Function lihatFasilitasKamar()
        Dim fasilitas As New DataTable
        Try
            Dim Query As String = "select * from tb_fasilitas"
            adp = New MySqlDataAdapter(Query, con)
            adp.Fill(fasilitas)
        Catch ex As Exception
            MsgBox("Lihat data dari database ERROR!", MsgBoxStyle.Information, "Informasi")
        End Try
        Return fasilitas
    End Function

    Public Function lihatTipeKamar()
        Dim tipe As New DataTable
        Try
            Dim Query As String = "select * from tb_tipekamar"
            adp = New MySqlDataAdapter(Query, con)
            adp.Fill(tipe)
        Catch ex As Exception
            MsgBox("Lihat data dari database ERROR!", MsgBoxStyle.Information, "Informasi")
        End Try
        Return tipe
    End Function

    Public Function lihatDataKamar()
        Dim kamar As New DataTable
        Try
            Dim Query As String = "select * from tb_kamar"
            adp = New MySqlDataAdapter(Query, con)
            adp.Fill(kamar)
        Catch ex As Exception
            MsgBox("Lihat data dari database ERROR!", MsgBoxStyle.Information, "Informasi")
        End Try
        Return kamar
    End Function

    'TAMBAH DATA ===================================================================

    Public Function tambahFasilitasKamar(ByVal kode_fasilitas As String, ByVal nama_fasilitas As String) As Boolean
        Dim Query As String = "insert into tb_fasilitas values(@kd_fasilitas, @nama_fasilitas)"
        Dim Hasil = False
        Try
            cmd = New MySqlCommand(Query, con)
            cmd.Parameters.Add("@kd_fasilitas", MySqlDbType.VarChar).Value = "FAS" + kode_fasilitas
            cmd.Parameters.Add("@nama_fasilitas", MySqlDbType.VarChar).Value = nama_fasilitas
            cmd.ExecuteNonQuery()
            Hasil = True
        Catch ex As Exception
            MsgBox("Tambah Data ERROR!", MsgBoxStyle.Information, "")
        End Try
        Return Hasil
    End Function

    Public Function tambahTipeKamar(ByVal kd_tipekamar As String, ByVal nama_tipe As String) As Boolean
        Dim Query As String = "insert into tb_tipekamar values(@kd_tipekamar, @nama_tipe)"
        Dim Hasil = False
        Try
            cmd = New MySqlCommand(Query, con)
            cmd.Parameters.Add("@kd_tipekamar", MySqlDbType.VarChar).Value = "TIK" + kd_tipekamar
            cmd.Parameters.Add("@nama_tipe", MySqlDbType.VarChar).Value = nama_tipe
            cmd.ExecuteNonQuery()
            Hasil = True
        Catch ex As Exception
            MsgBox("Tambah Data ERROR!", MsgBoxStyle.Information, "")
        End Try
        Return Hasil
    End Function

    'Public Function tambahDataKamar(ByVal kd_kamar As String, ByVal kd_tipekamar As String, ByVal kd_fasilitas As String, ByVal harga As String, ByVal kapasitas As String, ByVal status As String) As Boolean
    '    Dim Query As String = "insert into tb_kamar values(@kd_kamar, @kd_tipekamar, @kd_fasilitas, @harga, @kapasitas, @status)"
    '    Dim Hasil = False
    '    Try
    '        cmd = New MySqlCommand(Query, con)
    '        cmd.Parameters.Add("@kd_kamar", MySqlDbType.VarChar).Value = "KAM" + kd_kamar
    '        cmd.Parameters.Add("@kd_tipekamar", MySqlDbType.VarChar).Value = kd_tipekamar
    '        cmd.Parameters.Add("@kd_fasilitas", MySqlDbType.VarChar).Value = kd_fasilitas
    '        cmd.Parameters.Add("@harga", MySqlDbType.VarChar).Value = harga
    '        cmd.Parameters.Add("@kapasitas", MySqlDbType.VarChar).Value = kapasitas
    '        cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = status
    '        cmd.ExecuteNonQuery()
    '        Hasil = True
    '    Catch ex As Exception
    '        MsgBox("Tambah Data ERROR!", MsgBoxStyle.Information, "")
    '    End Try
    '    Return Hasil
    'End Function

    'HAPUS DATA ====================================================================

    Public Function hapusFasilitasKamar(ByVal kd_fasilitas As String) As Boolean
        Dim Query As String = "delete from tb_fasilitas where kd_fasilitas ='" + kd_fasilitas + "'"
        Dim Hasil = False
        Try
            cmd = New MySqlCommand(Query, con)
            cmd.Parameters.Add("kd_fasilitas", MySqlDbType.VarChar).Value = kd_fasilitas
            cmd.ExecuteNonQuery()
            Hasil = True
        Catch ex As Exception
            MsgBox("Hapus Data ERROR!", MsgBoxStyle.Information, "")
        End Try
        Return Hasil
    End Function

    Public Function hapusTipeKamar(ByVal kd_tipekamar As String) As Boolean
        Dim Query As String = "delete from tb_tipekamar where kd_tipekamar ='" + kd_tipekamar + "'"
        Dim Hasil = False
        Try
            cmd = New MySqlCommand(Query, con)
            cmd.Parameters.Add("kd_tipekamar", MySqlDbType.VarChar).Value = kd_tipekamar
            cmd.ExecuteNonQuery()
            Hasil = True
        Catch ex As Exception
            MsgBox("Hapus Data ERROR!", MsgBoxStyle.Information, "")
        End Try
        Return Hasil
    End Function

    Public Function hapusDataKamar(ByVal kd_kamar As String) As Boolean
        Dim Query As String = "delete from tb_kamar where kd_kamar ='" + kd_kamar + "'"
        Dim Hasil = False
        Try
            cmd = New MySqlCommand(Query, con)
            cmd.Parameters.Add("kd_kamar", MySqlDbType.VarChar).Value = kd_kamar
            cmd.ExecuteNonQuery()
            Hasil = True
        Catch ex As Exception
            MsgBox("Hapus Data ERROR!", MsgBoxStyle.Information, "")
        End Try
        Return Hasil
    End Function

    'UBAH DATA =====================================================================

    Public Function ubahFasilitasKamar(ByVal kd_fasilitas As String, ByVal nama_fasilitas As String) As Boolean
        Dim Query As String = "update tb_fasilitas set nama_fasilitas=@nama_fasilitas where kd_fasilitas='" + kd_fasilitas + "'"
        Dim Hasil = False
        Try
            cmd = New MySqlCommand(Query, con)
            cmd.Parameters.Add("kd_fasilitas", MySqlDbType.VarChar).Value = kd_fasilitas
            cmd.Parameters.Add("nama_fasilitas", MySqlDbType.VarChar).Value = nama_fasilitas
            cmd.ExecuteNonQuery()
            Hasil = True
        Catch ex As Exception
            MsgBox("Ubah Data ERROR!", MsgBoxStyle.Information, "")
        End Try
        Return Hasil
    End Function

    Public Function ubahTipeKamar(ByVal kd_tipekamar As String, ByVal nama_tipe As String) As Boolean
        Dim Query As String = "update tb_tipekamar set nama_tipe=@nama_tipe where kd_tipekamar='" + kd_tipekamar + "'"
        Dim Hasil = False
        Try
            cmd = New MySqlCommand(Query, con)
            cmd.Parameters.Add("kd_tipekamar", MySqlDbType.VarChar).Value = kd_tipekamar
            cmd.Parameters.Add("nama_tipe", MySqlDbType.VarChar).Value = nama_tipe
            cmd.ExecuteNonQuery()
            Hasil = True
        Catch ex As Exception
            MsgBox("Ubah Data ERROR!", MsgBoxStyle.Information, "")
        End Try
        Return Hasil
    End Function

    Public Function ubahDataKamar(ByVal kd_kamar As String, ByVal kd_tipekamar As String, ByVal kd_fasilitas As String, ByVal harga As String, ByVal kapasitas As String, ByVal status As String) As Boolean
        Dim Query As String = "update tb_kamar set kd_tipekamar=@kd_tipekamar, kd_fasilitas=@kd_fasilitas, harga=@harga, kapasitas=@kapasitas, status=@status where kd_kamar='" + kd_kamar + "'"
        Dim Hasil = False
        Try
            cmd = New MySqlCommand(Query, con)
            cmd.Parameters.Add("@kd_kamar", MySqlDbType.VarChar).Value = kd_kamar
            cmd.Parameters.Add("@kd_tipekamar", MySqlDbType.VarChar).Value = kd_tipekamar
            cmd.Parameters.Add("@kd_fasilitas", MySqlDbType.VarChar).Value = kd_fasilitas
            cmd.Parameters.Add("@harga", MySqlDbType.VarChar).Value = harga
            cmd.Parameters.Add("@kapasitas", MySqlDbType.VarChar).Value = kapasitas
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = status
            cmd.ExecuteNonQuery()
            Hasil = True
        Catch ex As Exception
            MsgBox("Tambah Data ERROR!", MsgBoxStyle.Information, "")
        End Try
        Return Hasil
    End Function
End Class
