Imports MySql.Data.MySqlClient
Public Class rptTamu
    Private connString As String = "Server=localhost;user id=root;password='';database=hotel"
    Private MyKoneksi As New MySqlConnection(connString)
    Private Sub rptTamu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MyKoneksi.Open()
        Dim rpt As New CrystalReport1() 'Report yang telah dibuat.
        Dim oDs As New DataSet() 'Dataaset yang telah dibuat.
        Try
            Dim oDa As New MySqlDataAdapter("select * From tb_karyawan", MyKoneksi)
            oDa.Fill(oDs, "belajar")
            rpt.SetDataSource(oDs)
            CrystalReportViewer1.ReportSource = rpt
        Catch Excep As Exception
            MessageBox.Show(Excep.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        MyKoneksi.Close()
    End Sub

End Class