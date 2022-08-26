Imports MySql.Data.MySqlClient
Module isiCombo
    Public connDB As New MySqlConnection
    Public comDB As New MySqlCommand
    Public combuilder As New MySqlCommandBuilder
    Public rdDB As MySqlDataReader
    Public dt As DataTable
    Public myerror As MySqlError
    Public item As ListViewItem

    Public Sub connectdb()
        Dim strserver As String = "localhost"
        Dim strdatabase As String = "hotel"
        Dim struser As String = "root"
        Dim strpass As String = ""
        If connDB.State <> ConnectionState.Open Then connDB.ConnectionString =
            "server=" & strserver.Trim & ";database=" &
            strdatabase.Trim & ";user id=" & struser.Trim & ";password=" & strpass
        If connDB.State <> ConnectionState.Open Then connDB.Open()
    End Sub

    'Public Sub closedb()
    '    If connDB.State <> ConnectionState.Closed Then connDB.Close()
    'End Sub

    Public Sub initCMD()
        With comDB
            .Connection = connDB
            .CommandType = CommandType.Text
            .CommandTimeout = 0
        End With
    End Sub
End Module

