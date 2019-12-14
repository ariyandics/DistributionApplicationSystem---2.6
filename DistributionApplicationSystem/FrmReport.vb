Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Data.OleDb
Public Class FrmReport

    Private Sub FrmReport_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.ReportViewer1.Reset()
        Me.ReportViewer1.RefreshReport()

    End Sub

    Private Sub FrmReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = NamaPT

        ' Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth
        ' Me.ReportViewer1.ZoomPercent = 25
        Me.ReportViewer1.RefreshReport()
    End Sub

End Class