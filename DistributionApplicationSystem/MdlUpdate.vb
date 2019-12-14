Imports System.Net.Http
Imports System.Net
Imports System.Text
Imports System.IO
Module MdlUpdate
    Public exeServerUrl As String
    Public exeDate As DateTime = File.GetLastWriteTime(Application.ExecutablePath())
    Public exeTemp As String = AppDomain.CurrentDomain.BaseDirectory & "DistributionApplicationSystem.new"
    Public exeFTPUrl As String = "ftp://116.197.135.172/RMS_TIGAS/DC/DistributionApplicationSystem.exe"
    Public userFTP As String = "fikri"
    Public passFTP As String = "fikri"
    Public Function GetExeServer() As DateTime
        Dim lastMod As DateTimeOffset
        Try
            Dim exeServerUrl = "http://www.tigas.co.id/EXE/SMI/DC/DistributionApplicationSystem.exe"
            Dim client = New HttpClient()
            Dim msg = New HttpRequestMessage(HttpMethod.Head, exeServerUrl)
            Dim resp = client.SendAsync(msg).Result
            lastMod = resp.Content.Headers.LastModified

        Catch ex As Exception
            lastMod = New DateTime(1900, 1, 1, 12, 0, 0)
        End Try

        Dim exeServer As DateTime = lastMod.UtcDateTime

        Return exeServer
    End Function

    Public Sub DownloadExeServer()


        Dim exetemp As String = AppDomain.CurrentDomain.BaseDirectory & "DistributionApplicationSystem.new"
        If File.Exists(exetemp) Then File.Delete(exetemp)
        Try
            Dim webClient As New WebClient
            Dim exeServerUrl = "http://www.tigas.co.id/EXE/SMI/DC/DistributionApplicationSystem.exe"
            webClient.DownloadFile(exeServerUrl, exetemp)
        Catch ex As WebException
            MsgBox(ex.Message)

        End Try

        If Not File.Exists(exetemp) Then
            MsgBox("File server gagal didownload!", MsgBoxStyle.Critical)

        Else
            Try
                Dim exeOld As String = AppDomain.CurrentDomain.BaseDirectory & "DistributionApplicationSystem.old"
                If File.Exists(exeOld) Then File.Delete(exeOld)

                Rename(Application.ExecutablePath(), exeOld)
                Rename(exetemp, Application.ExecutablePath())

                MsgBox("Aplikasi akan dimatikan!", MsgBoxStyle.Information)
                Application.Exit()

            Catch ex As IO.IOException
                MsgBox(ex.Message)
            End Try

        End If


    End Sub
    Public Function GetExeFTP() As DateTime
        Dim lastMod As DateTime
        Try

            Dim ftp As FtpWebRequest = FtpWebRequest.Create(exeFTPUrl)
            ftp.UsePassive = False
            ftp.Credentials = New NetworkCredential(userFTP, passFTP)
            ftp.Method = WebRequestMethods.Ftp.GetDateTimestamp
            Using response = CType(ftp.GetResponse(), FtpWebResponse)
                lastMod = response.LastModified
            End Using
        Catch ex As WebException
            lastMod = New DateTime(1900, 1, 1, 12, 0, 0)
            MsgBox(ex.Message)

        End Try
        Return lastMod

    End Function

    Public Sub DownloadExeFTP()
        If File.Exists(exeTemp) Then File.Delete(exeTemp)
        Try
            Dim request As FtpWebRequest = WebRequest.Create(exeFTPUrl)
            request.UsePassive = True
            request.Credentials = New NetworkCredential(userFTP, passFTP)
            request.Method = WebRequestMethods.Ftp.DownloadFile

            Using ftpStream As Stream = request.GetResponse().GetResponseStream(), fileStream As Stream = File.Create(exeTemp)
                ftpStream.CopyTo(fileStream)
            End Using

            Call ExeTempToAktif()
        Catch ex As WebException
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ExeTempToAktif()
        If Not File.Exists(exeTemp) Then
            MsgBox("File server gagal didownload!", MsgBoxStyle.Critical)

        Else
            Try
                Dim exeOld As String = AppDomain.CurrentDomain.BaseDirectory & "DistributionApplicationSystem.old"
                If File.Exists(exeOld) Then File.Delete(exeOld)

                Rename(Application.ExecutablePath(), exeOld)
                Rename(exeTemp, Application.ExecutablePath())

                MsgBox("Aplikasi akan dimatikan , Silahkan panggil ulang aplikasi!", MsgBoxStyle.Information)
                Application.Exit()

            Catch ex As IOException
                MsgBox(ex.Message)
            End Try

        End If
    End Sub
End Module
