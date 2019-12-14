Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Data.OleDb
Public Class FrmRptTIToko
    Private Sub FrmRptTIToko_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.RptTiToko.Reset()
        Me.RptTiToko.RefreshReport()
    End Sub
    Private Sub FrmRptTIToko_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Parent = PictureBox1
        GroupBox2.Parent = PictureBox1
        GroupBox3.Parent = PictureBox1
        GroupBox4.Parent = PictureBox1
        Label1.BackColor = Color.Transparent
        Me.BackColor = Color.SkyBlue
        Me.BackgroundImage = System.Drawing.Image.FromFile(bg)
        PictureBox1.BackgroundImage = System.Drawing.Image.FromFile(atas)
        Me.Text = NamaPT

        Me.Label1.Left = (Me.Width - Me.Label1.Width) / 2
        Me.Label1.Top = 9

        Tgl1.MaxDate = DateAdd(DateInterval.Day, -1, Now)
        cmbFilter.Items.Clear()
        cmbFilter.Items.Add("All")
        cmbFilter.Items.Add("Store")
        BtnFindStore.Enabled = False
    End Sub

    Private Sub BtnProses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProses.Click
        Call proses()
    End Sub

    Private Sub proses()

        If cmbFilter.Text = "" Then
            MsgBox("Silahkan Pilih Filter Report...!!", vbOKOnly + vbInformation, "Info")
            Exit Sub
        End If

        If cmbFilter.Text = "Store" Then
            If TxtKodeToko.Text = "" Then
                MsgBox("Silahkan Pilih Toko terlebih dahulu...!!", vbOKOnly + vbInformation, "Info")
                BtnFindStore.Focus()
                Exit Sub
            End If
        End If

        Call Rekap()
    End Sub

    Private Sub Rekap()
        Dim objConn As OleDbConnection
        Dim objCmd As OleDbCommand
        Dim objReader As OleDbDataReader
        Dim objDataSet As DataSet = New DataSetMoveCabang
        Dim strSQL, strCONN As String

        GetStringKoneksi() '---1
        strCONN = StrKoneksi '----2

        If cmbFilter.Text = "All" Then
            strSQL = "exec spPrintTransferInToko 'ALLToko',0,'" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'"
        Else
            strSQL = "exec spPrintTransferInToko 'Toko'," & (TxtKodeToko.Text) & ",'" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'"
        End If

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
        rds.Name = "dtsTiToko"
        rds.Value = objDataSet.Tables(0)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
        'paramList.Add(New ReportParameter("NamaDC", namadc, True))
        paramList.Add(New ReportParameter("Judul", "LAPORAN TRANSFER IN TOKO", True))
        paramList.Add(New ReportParameter("Tgl1", Format(Me.Tgl1.Value, "dd-MM-yyyy"), True))
        paramList.Add(New ReportParameter("Tgl2", Format(Me.tgl2.Value, "dd-MM-yyyy"), True))
        paramList.Add(New ReportParameter("sub", cmbFilter.Text, True))

        With Me
            .RptTiToko.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptTIToko.rdlc"
            .RptTiToko.LocalReport.DataSources.Clear()
            .RptTiToko.LocalReport.DataSources.Add(rds)
            .RptTiToko.LocalReport.SetParameters(paramList)
            .RptTiToko.LocalReport.ListRenderingExtensions()
            .RptTiToko.RefreshReport()
            .RptTiToko.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth
        End With

    End Sub


    Private Sub BtnFindStore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFindStore.Click
        TxtKodeToko.Text = FrmFind.cari("MasterToko")
        If TxtKodeToko.Text = "0" Then
            TxtKodeToko.Clear()
            TxtNamaToko.Clear()
            Exit Sub
        Else
            gettoko(TxtKodeToko.Text)
            TxtNamaToko.Text = namatoko
        End If
    End Sub

    Private Sub cmbFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFilter.TextChanged
        If cmbFilter.Text = "" Then
            BtnFindStore.Enabled = False
            Exit Sub
        End If

        If cmbFilter.Text = "Store" Then
            BtnFindStore.Enabled = True
        Else
            BtnFindStore.Enabled = False
            TxtKodeToko.Clear()
            TxtNamaToko.Clear()
        End If
    End Sub
End Class