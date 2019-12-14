Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Data.OleDb
Imports System.Globalization
Public Class FrmDSI
    Dim tglawal, tglakhir As Date
    Private Sub FrmDSI_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.RptSLSupplier.Reset()
        Me.RptSLSupplier.RefreshReport()
    End Sub

    Private Sub FrmDSI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Parent = PictureBox1
        GroupBox1.Parent = PictureBox1
        GroupBox2.Parent = PictureBox1
        Label1.BackColor = Color.Transparent
        Me.BackColor = Color.SkyBlue
        Me.BackgroundImage = System.Drawing.Image.FromFile(bg)
        PictureBox1.BackgroundImage = System.Drawing.Image.FromFile(atas)
        Me.Text = NamaPT

        Me.Label1.Left = (Me.Width - Me.Label1.Width) / 2
        Me.Label1.Top = 9


        Tgl1.ShowUpDown = True
        Tgl1.Format = DateTimePickerFormat.Custom
        Tgl1.CustomFormat = "MMMM-yyyy"
        Tgl1.MinDate = "2019-02-01"
        Dim dt As Date = Now.AddDays(-1)
        Dim x As Integer = Microsoft.VisualBasic.DateAndTime.Day(dt)
        Tgl1.Value = Now.AddDays(-x)


    End Sub


    Private Sub proses()
        tglawal = Tgl1.Value
        tglakhir = tglawal.AddMonths(1).AddDays(-1)

        If tglakhir > Now Then
            tglakhir = Now.AddDays(-1)
        End If


        If RbRekap.Checked = True Then
            Call Rekap()
        Else
            Call Detail()
        End If
    End Sub

    Private Sub Rekap()
         Dim objConn As OleDbConnection
        Dim objCmd As OleDbCommand
        Dim objReader As OleDbDataReader
        Dim objDataSet As DataSet = New DataSetDSI
        Dim strSQL, strCONN As String

        GetStringKoneksi() '---1
        strCONN = StrKoneksi '----2

        strSQL = "exec spLapDSI 'Detail','" & Format(tglawal, "yyyy-MM-dd") & "','" & Format(tglakhir, "yyyy-MM-dd") & "'"


        objConn = New OleDbConnection(strCONN)
        objCmd = New OleDbCommand(strSQL, objConn)
        objCmd.CommandType = CommandType.Text
        objCmd.Connection.Open()
        objCmd.CommandTimeout = 0
        objReader = objCmd.ExecuteReader
        objDataSet.Tables(0).Clear()
        objDataSet.Tables(0).Load(objReader)
        objReader.Close()
        objConn.Close()

        Dim rds As ReportDataSource = New ReportDataSource
        rds.Name = "DataSetDSI"
        rds.Value = objDataSet.Tables(0)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", "DAY SALES INVENTORY", True))
        paramList.Add(New ReportParameter("Tgl1", Tgl1.Text, True))
        paramList.Add(New ReportParameter("SubJudul", "Detail", True))

        With Me
            .RptSLSupplier.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptDSIDetail.rdlc"
            .RptSLSupplier.LocalReport.DataSources.Clear()
            .RptSLSupplier.LocalReport.DataSources.Add(rds)
            .RptSLSupplier.LocalReport.SetParameters(paramList)
            .RptSLSupplier.RefreshReport()
            .RptSLSupplier.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth
        End With

    End Sub
    Private Sub Detail()
        Dim objConn As OleDbConnection
        Dim objCmd As OleDbCommand
        Dim objReader As OleDbDataReader
        Dim objDataSet As DataSet = New DataSetDSI
        Dim strSQL, strCONN As String

        GetStringKoneksi() '---1
        strCONN = StrKoneksi '----2

        strSQL = "exec spLapDSI 'Detail','" & Format(tglawal, "yyyy-MM-dd") & "','" & Format(tglakhir, "yyyy-MM-dd") & "'"


        objConn = New OleDbConnection(strCONN)
        objCmd = New OleDbCommand(strSQL, objConn)
        objCmd.CommandType = CommandType.Text
        objCmd.Connection.Open()
        objCmd.CommandTimeout = 0
        objReader = objCmd.ExecuteReader
        objDataSet.Tables(0).Clear()
        objDataSet.Tables(0).Load(objReader)
        objReader.Close()
        objConn.Close()

        Dim rds As ReportDataSource = New ReportDataSource
        rds.Name = "DataSetDSI"
        rds.Value = objDataSet.Tables(0)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", "DAY SALES INVENTORY", True))
        paramList.Add(New ReportParameter("Tgl1", Tgl1.Text, True))
        paramList.Add(New ReportParameter("SubJudul", "Detail", True))

        With Me
            .RptSLSupplier.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptDSIDetail.rdlc"
            .RptSLSupplier.LocalReport.DataSources.Clear()
            .RptSLSupplier.LocalReport.DataSources.Add(rds)
            .RptSLSupplier.LocalReport.SetParameters(paramList)
            .RptSLSupplier.RefreshReport()
            .RptSLSupplier.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth
        End With

    End Sub

    Private Sub BtnProses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProses.Click
        Call proses()
    End Sub
End Class