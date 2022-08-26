Imports MySql.Data.MySqlClient
Module conection
    Public konek As String = "server = localhost;user id = root; database = hotel"
    Public con As New MySqlConnection(konek)
    Public adp As MySqlDataAdapter
    Public cmd As MySqlCommand

    Sub koneksi()
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
        Catch ex As Exception
            MsgBox("Koneksi Gagal", MsgBoxStyle.Information)
        End Try
    End Sub

    Public Function openConnection() As MySqlConnection
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
        Catch ex As Exception
            MsgBox("Koneksi ke Database Gagal!!", MsgBoxStyle.Information, "")
        End Try
        Return con
    End Function

End Module
