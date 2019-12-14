Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Data.OleDb
Public Class FrmOOS
    Dim sql As String

    Private Sub FrmOOS_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.RptRegisterTO.Reset()
        Me.RptRegisterTO.RefreshReport()
    End Sub
    Private Sub FrmOOS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Parent = PictureBox1
        GroupBox2.Parent = PictureBox1
        Label1.BackColor = Color.Transparent
        Me.BackColor = Color.SkyBlue
        Me.BackgroundImage = System.Drawing.Image.FromFile(bg)
        PictureBox1.BackgroundImage = System.Drawing.Image.FromFile(atas)
        Me.Text = NamaPT

        Me.Label1.Left = (Me.Width - Me.Label1.Width) / 2
        Me.Label1.Top = 9


    End Sub

    Private Sub BtnProses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProses.Click
        Call proses()
    End Sub
    Private Sub proses()
        If Tgl1.Value.Date > Tgl2.Value.Date Then
            MsgBox("Periode awal yang anda masukan salah !!!", vbOKOnly + vbCritical, "Info")
            Exit Sub
        End If

     
        Call cetakoos()
     
    End Sub
    Private Sub cetakoos()
        Call namadcAktif()
        sql = "exec spPrintSLDCToStore 'cetakOOS',0,'" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'"

        Dim Conns As New SqlConnection(ConnSQLClient)
        Dim dt As New DataTable

        Dim da As New SqlDataAdapter(sql, Conns)
        da.Fill(dt)

        Dim DataSetName As String = "DataSetOOS"
        Dim DataTableName As String = "TblOOS"
        Dim rds As New ReportDataSource(DataSetName, dt)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", "OOS PRODUK DC", True))
        paramList.Add(New ReportParameter("NamaDC", kodedc & "-" & namadc, True))
        'paramList.Add(New ReportParameter("Jenis", "SOH Ready", True))

        RptRegisterTO.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptOOS.rdlc"
        RptRegisterTO.LocalReport.SetParameters(paramList)
        RptRegisterTO.LocalReport.DataSources.Clear()
        RptRegisterTO.LocalReport.DataSources.Add(rds)
        RptRegisterTO.RefreshReport()
        RptRegisterTO.Show()
    End Sub

End Class