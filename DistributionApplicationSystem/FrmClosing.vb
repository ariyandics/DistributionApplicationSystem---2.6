Imports System.ComponentModel
Public Class FrmClosing

    Private Sub FrmClosing_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        BackgroundWorker1.Dispose()
    End Sub

    Private Sub FrmClosing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        System.Windows.Forms.Form.CheckForIllegalCrossThreadCalls = False
        BackgroundWorker1.WorkerSupportsCancellation = True
        BackgroundWorker1.WorkerReportsProgress = True
        ProgressBar1.Visible = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If BackgroundWorker1.IsBusy <> True Then
            BackgroundWorker1.RunWorkerAsync()
            Timer1.Enabled = True
            Timer1.Start()
            ProgressBar1.Visible = True
        End If
     
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
        Application.DoEvents()
        Try

            Dim i As Integer = 0
            Do Until i = 100
                System.Threading.Thread.Sleep(100)
                i += 1
                Label1.Text = "Proses Belakang " & i
            Loop
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If ProgressBar1.Value < 100 Then
            ProgressBar1.Value += 1
        ElseIf ProgressBar1.Value = 100 Then
            ProgressBar1.Value = 0
            ProgressBar1.Value += 1
        End If
        If Label1.Text = "Proses Belakang 100" Then
            Timer1.Stop()
            ProgressBar1.Visible = False
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim b As Integer = 0
        Do Until b = 150
            Application.DoEvents()
            System.Threading.Thread.Sleep(100)
            b += 1
            Label2.Text = "Proses Depan " & b
        Loop
    End Sub
End Class