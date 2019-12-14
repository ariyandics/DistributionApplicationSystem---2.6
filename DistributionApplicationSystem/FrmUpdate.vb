Imports System.Net
Public Class FrmUpdate
    Dim wc As New WebClient
    Private Sub FrmUpdate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim xfile As String = "DistributionApplicationSystem.new"
        Dim exeFTPUrl As String = "ftp://fikri:fikri@116.197.135.172/RMS_TIGAS/DC/DistributionApplicationSystem.exe"
        AddHandler wc.DownloadDataCompleted, AddressOf DownloadCompleted
        AddHandler wc.DownloadProgressChanged, AddressOf DownloadProgressChanged
        wc.DownloadFileAsync(New Uri(exeFTPUrl), exeTemp.Substring(xfile.LastIndexOf("/") + 1))

    End Sub
    Private Sub DownloadProgressChanged(ByVal sender As Object, ByVal e As Net.DownloadProgressChangedEventArgs)
        ProgressBar1.Value = e.ProgressPercentage
    End Sub
    Private Sub DownloadCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        MsgBox("Download berhasil !!", vbOKOnly, "Info")
        Me.Close()
    End Sub
End Class