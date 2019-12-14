Imports System.Data.SqlClient
Public Class FrmKunci
    Dim rscon, RsServer As New ADODB.Recordset
    Dim conn, ConnServer As New ADODB.Connection
    Dim sql As String
    Dim jam, menit As Integer

    Private Sub FrmKunci_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If ConnServer.State = 0 Then
            GetStringKoneksi()
            ConnServer.Open(StrKoneksi)
        End If

        sql = "SELECT DATENAME(HOUR, GETDATE()) AS 'Hour',DATENAME(MINUTE, GETDATE()) AS 'Minute'"
        RsServer = ConnServer.Execute(sql)
        If Not RsServer.EOF Then
            jam = RsServer("Hour").Value
            menit = RsServer("Minute").Value

            Application.DoEvents()
            If jam = 13 And menit >= 37 Then
                Me.Label1.Text = "MAINTENANCE SELESAI"
                Me.Close()
            End If

        End If
    End Sub


End Class