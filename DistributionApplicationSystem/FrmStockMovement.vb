Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Data.OleDb
Public Class FrmStockMovement
    Dim sql As String
    Dim idstok As Int16

    Private Sub FrmStockMovement_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.RptRegisterTO.Reset()
        Me.RptRegisterTO.RefreshReport()
    End Sub
    Private Sub FrmStockMovement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Parent = PictureBox1
        GroupBox2.Parent = PictureBox1
        Label1.BackColor = Color.Transparent
        Me.BackColor = Color.SkyBlue
        Me.BackgroundImage = System.Drawing.Image.FromFile(bg)
        PictureBox1.BackgroundImage = System.Drawing.Image.FromFile(atas)
        Me.Text = NamaPT

        Me.Label1.Left = (Me.Width - Me.Label1.Width) / 2
        Me.Label1.Top = 9
        Tgl2.MaxDate = Now()

    End Sub

    Private Sub BtnProses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProses.Click
        If RbGS.Checked = False And RbBS.Checked = False Then
            MsgBox("Anda belum memilih Jenis Stock !!!", vbOKOnly + vbInformation, "Info")
            Exit Sub
        Else
            Call proses()
        End If


    End Sub
    Private Sub proses()
        If Tgl1.Value.Date > Tgl2.Value.Date Then
            MsgBox("Periode awal salah !!!", vbOKOnly + vbCritical, "Info")
            Exit Sub
        End If
        If RbGS.Checked = True Then
            Call cetakGS()
        Else
            Call cetakBS()
        End If


    End Sub
    Private Sub cetakGS()
        Call namadcAktif()
        If Format(Tgl2.Value, "yyyy-MM-dd") = Format(Now, "yyyy-MM-dd") Then
            sql = "exec spPrintMovementDC 'GoodNow','" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'"
        Else
            sql = "exec spPrintMovementDC 'Good','" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'"
        End If
        Dim Conns As New SqlConnection(ConnSQLClient)
        Dim dt As New DataTable

        Dim da As New SqlDataAdapter(sql, Conns)
        da.Fill(dt)

        Dim DataSetName As String = "DatasetMovementGS"
        Dim DataTableName As String = "DataStockMove"
        Dim rds As New ReportDataSource(DataSetName, dt)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", "Inventory Movement", True))
        paramList.Add(New ReportParameter("SubJudul", "Good Stock", True))
        paramList.Add(New ReportParameter("Tgl1", Format(Me.Tgl1.Value, "dd-MM-yyyy"), True))
        paramList.Add(New ReportParameter("Tgl2", Format(Me.Tgl2.Value, "dd-MM-yyyy"), True))
        paramList.Add(New ReportParameter("NamaDC", kodedc & "-" & namadc, True))

        Dim ReportViewerForm As New FrmReport
        RptRegisterTO.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptStockMoveGS.rdlc"
        RptRegisterTO.LocalReport.SetParameters(paramList)
        RptRegisterTO.LocalReport.DataSources.Clear()
        RptRegisterTO.LocalReport.DataSources.Add(rds)
        RptRegisterTO.RefreshReport()
        RptRegisterTO.Show()
    End Sub
    Private Sub cetakBS()
        Call namadcAktif()
        If Format(Tgl2.Value, "yyyy-MM-dd") = Format(Now, "yyyy-MM-dd") Then
            sql = "exec spPrintMovementDC 'BadNow','" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'"
        Else
            sql = "exec spPrintMovementDC 'Bad','" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'"
        End If
        Dim Conns As New SqlConnection(ConnSQLClient)
        Dim dt As New DataTable

        Dim da As New SqlDataAdapter(sql, Conns)
        da.Fill(dt)

        Dim DataSetName As String = "DatasetMovementGS"
        Dim DataTableName As String = "DataStockMove"
        Dim rds As New ReportDataSource(DataSetName, dt)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", "Inventory Movement", True))
        paramList.Add(New ReportParameter("SubJudul", "Good Stock", True))
        paramList.Add(New ReportParameter("Tgl1", Format(Me.Tgl1.Value, "dd-MM-yyyy"), True))
        paramList.Add(New ReportParameter("Tgl2", Format(Me.Tgl2.Value, "dd-MM-yyyy"), True))
        paramList.Add(New ReportParameter("NamaDC", kodedc & "-" & namadc, True))

        Dim ReportViewerForm As New FrmReport
        RptRegisterTO.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptStockMoveBS.rdlc"
        RptRegisterTO.LocalReport.SetParameters(paramList)
        RptRegisterTO.LocalReport.DataSources.Clear()
        RptRegisterTO.LocalReport.DataSources.Add(rds)
        RptRegisterTO.RefreshReport()
        RptRegisterTO.Show()
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub
End Class