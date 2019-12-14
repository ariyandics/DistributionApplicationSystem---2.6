Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Data.OleDb
Public Class frmSumarynonrrak
    Dim sql As String
    Dim idstok As Int16
    Private Sub frmSumarynonrrak_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.RptAnggaranKas.Reset()
        Me.RptAnggaranKas.RefreshReport()
    End Sub
    Private Sub frmSumarynonrrak_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Parent = PictureBox1
        GroupBox1.Parent = PictureBox1
        GroupBox2.Parent = PictureBox1
        GroupBox4.Parent = PictureBox1
        GroupBox5.Parent = PictureBox1
        Label1.BackColor = Color.Transparent
        Me.BackColor = Color.SkyBlue
        ''Me.BackgroundImage = System.Drawing.Image.FromFile(bg)
        PictureBox1.BackgroundImage = System.Drawing.Image.FromFile(atas)
        Me.Text = NamaPT

        Me.Label1.Left = (Me.Width - Me.Label1.Width) / 2
        Me.Label1.Top = 9
        Tgl2.MaxDate = Now()
        Tgl1.MaxDate = Now()

        cbcategory.SelectedItem = "All"

        cbostatusnonrrak.SelectedItem = "Rekap"
        cbostatusrrak.SelectedItem = "Realisasi"

        RbRRAK.Checked = True
    End Sub

    Private Sub BtnProses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProses.Click
        '' RptAnggaranKas.Clear()
        If RbRRAK.Checked = False And RbNONRRAK.Checked = False Then
            MsgBox("Anda belum memilih Jenis Anggaran !!!", vbOKOnly + vbInformation, "Info")
            Exit Sub
        Else
            If cbcategory.Text = "By Toko" AndAlso TxtKodeToko.Text = "" Then
                MsgBox("Silahkan Pilih Toko terlebih Dahulu !!!", vbOKOnly + vbInformation, "Info")
                Exit Sub
            Else
                Call proses()
            End If
        End If
    End Sub
    Private Sub proses()
        If RbRRAK.Checked = True Then
            If cbostatusrrak.Text = "Realisasi" AndAlso cbostatusnonrrak.Text = "Rekap" Then
                Call cetakrrak()
            Else
                Call cetakrrakdetail()
            End If
        Else
            If cbostatusrrak.Text = "Realisasi" AndAlso cbostatusnonrrak.Text = "Rekap" Then
                Call cetaknonrrak()
            Else
                Call cetaknonrrakdetail()
            End If

        End If
    End Sub
    Private Sub cetakrrak()
        Call namadcAktif()

        If cbostatusrrak.Text = "Realisasi" Then
            If TxtKodeToko.Text = "" Then
                If cbostatusrrak.Text = "Realisasi" And cbcategory.Text = "OutStanding" Then
                    sql = "exec spPrintsumaryAnggaranKAS 'RRAKrekRealisasiOut','" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "',0"
                ElseIf cbostatusrrak.Text = "Realisasi" And cbcategory.Text = "Approved" Then
                    sql = "exec spPrintsumaryAnggaranKAS 'RRAKrekRealisasiApp','" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "',0"
                Else
                    sql = "exec spPrintsumaryAnggaranKAS 'RRAKRealisasi','" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "',0"
                End If
            Else
                If cbostatusrrak.Text = "Realisasi" And cbcategory.Text = "OutStanding" Then
                    sql = "exec spPrintsumaryAnggaranKAS 'RRAKrekRealisasiOutTKO','" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'," & TxtKodeToko.Text & ""
                ElseIf cbostatusrrak.Text = "Realisasi" And cbcategory.Text = "Approved" Then
                    sql = "exec spPrintsumaryAnggaranKAS 'RRAKrekRealisasiAppTKO','" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'," & TxtKodeToko.Text & ""
                Else
                    sql = "exec spPrintsumaryAnggaranKAS 'RRAKRealisasiTKO','" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'," & TxtKodeToko.Text & ""
                End If
            End If

        Else
            If TxtKodeToko.Text = "" Then
                If cbostatusrrak.Text = "Estimasi" And cbcategory.Text = "OutStanding" Then
                    sql = "exec spPrintsumaryAnggaranKAS 'RRAKrekEstimasiOut','" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "',0"
                ElseIf cbostatusrrak.Text = "Estimasi" And cbcategory.Text = "Approved" Then
                    sql = "exec spPrintsumaryAnggaranKAS 'RRAKrekEstimasiApp','" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "',0"
                Else
                    sql = "exec spPrintsumaryAnggaranKAS 'RRAKEstimasi','" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "',0"
                End If
            Else
                If cbostatusrrak.Text = "Estimasi" And cbcategory.Text = "OutStanding" Then
                    sql = "exec spPrintsumaryAnggaranKAS 'RRAKrekEstimasiOutTKO','" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'," & TxtKodeToko.Text & ""
                ElseIf cbostatusrrak.Text = "Estimasi" And cbcategory.Text = "Approved" Then
                    sql = "exec spPrintsumaryAnggaranKAS 'RRAKrekEstimasiAppTKO','" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'," & TxtKodeToko.Text & ""
                Else
                    sql = "exec spPrintsumaryAnggaranKAS 'RRAKEstimasiTKO','" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'," & TxtKodeToko.Text & ""
                End If
            End If
        End If
        Dim Conns As New SqlConnection(ConnSQLClient)
        Dim dt As New DataTable

        Dim da As New SqlDataAdapter(sql, Conns)
        da.Fill(dt)

        Dim DataSetName As String = "dtsrrakheader"
        Dim DataTableName As String = "dtRRAK"
        Dim rds As New ReportDataSource(DataSetName, dt)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
        If cbostatusrrak.Text = "Realisasi" Then
            paramList.Add(New ReportParameter("Judul", "Report Rekap Realisasi RRAK", True))
        Else
            paramList.Add(New ReportParameter("Judul", "Report Rekap Estimasi RRAK", True))
        End If
        paramList.Add(New ReportParameter("SubJudul", cbostatusrrak.Text & "-" & cbcategory.Text, True))
        paramList.Add(New ReportParameter("Tgl1", Format(Me.Tgl1.Value, "dd-MM-yyyy"), True))
        paramList.Add(New ReportParameter("Tgl2", Format(Me.Tgl2.Value, "dd-MM-yyyy"), True))
        paramList.Add(New ReportParameter("NamaDC", kodedc & "-" & namadc, True))

        Dim ReportViewerForm As New FrmReport
        RptAnggaranKas.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptSummaryRRAK.rdlc"
        RptAnggaranKas.LocalReport.SetParameters(paramList)
        RptAnggaranKas.LocalReport.DataSources.Clear()
        RptAnggaranKas.LocalReport.DataSources.Add(rds)
        RptAnggaranKas.RefreshReport()
        RptAnggaranKas.Show()
    End Sub

    Private Sub cetaknonrrak()
        Call namadcAktif()
        If TxtKodeToko.Text = "" Then
            If cbcategory.Text = "OutStanding" Then
                sql = "exec spPrintsumaryAnggaranKAS 'NonRRAKouthead','" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "',0"
            ElseIf cbcategory.Text = "Approved" Then
                sql = "exec spPrintsumaryAnggaranKAS 'NonRRAKapphead','" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "',0"
            Else
                sql = "exec spPrintsumaryAnggaranKAS 'NonRRAK','" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "',0"
            End If
        Else
            If cbcategory.Text = "OutStanding" Then
                sql = "exec spPrintsumaryAnggaranKAS 'NonRRAKoutheadTKO','" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'," & TxtKodeToko.Text & ""
            ElseIf cbcategory.Text = "Approved" Then
                sql = "exec spPrintsumaryAnggaranKAS 'NonRRAKappheadTKO','" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'," & TxtKodeToko.Text & ""
            Else
                sql = "exec spPrintsumaryAnggaranKAS 'NonRRAKTKO','" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'," & TxtKodeToko.Text & ""
            End If
        End If


        Dim Conns As New SqlConnection(ConnSQLClient)
        Dim dt As New DataTable

        Dim da As New SqlDataAdapter(sql, Conns)
        da.Fill(dt)

        Dim DataSetName As String = "dstnonrrakheader"
        Dim DataTableName As String = "dtnonrrakheader"
        Dim rds As New ReportDataSource(DataSetName, dt)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", "Report Rekap Non RRAK", True))
        paramList.Add(New ReportParameter("SubJudul", cbostatusnonrrak.Text & " - " & cbcategory.Text, True))
        paramList.Add(New ReportParameter("Tgl1", Format(Me.Tgl1.Value, "dd-MM-yyyy"), True))
        paramList.Add(New ReportParameter("Tgl2", Format(Me.Tgl2.Value, "dd-MM-yyyy"), True))
        paramList.Add(New ReportParameter("NamaDC", kodedc & "-" & namadc, True))

        Dim ReportViewerForm As New FrmReport
        RptAnggaranKas.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptSumaryNonRRAK.rdlc"
        RptAnggaranKas.LocalReport.SetParameters(paramList)
        RptAnggaranKas.LocalReport.DataSources.Clear()
        RptAnggaranKas.LocalReport.DataSources.Add(rds)
        RptAnggaranKas.RefreshReport()
        RptAnggaranKas.Show()
    End Sub
    Private Sub cetaknonrrakdetail()
        Call namadcAktif()
        If TxtKodeToko.Text = "" Then
            If cbcategory.Text = "OutStanding" Then
                sql = "exec spPrintsumaryAnggaranKAS 'NonRRAKoutdetail','" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "',0"
            ElseIf cbcategory.Text = "Approved" Then
                sql = "exec spPrintsumaryAnggaranKAS 'NonRRAKappvdetail','" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "',0"
            Else
                sql = "exec spPrintsumaryAnggaranKAS 'NonRRAKDetail','" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "',0"
            End If
        Else
            If cbcategory.Text = "OutStanding" Then
                sql = "exec spPrintsumaryAnggaranKAS 'NonRRAKoutdetailTKO','" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'," & TxtKodeToko.Text & ""
            ElseIf cbcategory.Text = "Approved" Then
                sql = "exec spPrintsumaryAnggaranKAS 'NonRRAKappvdetailTKO','" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'," & TxtKodeToko.Text & ""
            Else
                sql = "exec spPrintsumaryAnggaranKAS 'NonRRAKDetailTKO','" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'," & TxtKodeToko.Text & ""
            End If
        End If

        Dim Conns As New SqlConnection(ConnSQLClient)
        Dim dt As New DataTable

        Dim da As New SqlDataAdapter(sql, Conns)
        da.Fill(dt)

        Dim DataSetName As String = "DtsSumNonRRAKDetail"
        Dim DataTableName As String = "dtNonRrakDetail"
        Dim rds As New ReportDataSource(DataSetName, dt)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", "Report Detail Non RRAK", True))
        paramList.Add(New ReportParameter("SubJudul", cbostatusnonrrak.Text & "-" & cbcategory.Text, True))
        paramList.Add(New ReportParameter("Tgl1", Format(Me.Tgl1.Value, "dd-MM-yyyy"), True))
        paramList.Add(New ReportParameter("Tgl2", Format(Me.Tgl2.Value, "dd-MM-yyyy"), True))
        paramList.Add(New ReportParameter("NamaDC", kodedc & " - " & namadc, True))

        Dim ReportViewerForm As New FrmReport
        RptAnggaranKas.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptSumNonRRAKDetail.rdlc"
        RptAnggaranKas.LocalReport.SetParameters(paramList)
        RptAnggaranKas.LocalReport.DataSources.Clear()
        RptAnggaranKas.LocalReport.DataSources.Add(rds)
        RptAnggaranKas.RefreshReport()
        RptAnggaranKas.Show()
    End Sub

    Private Sub RbRRAK_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbRRAK.CheckedChanged
        If RbRRAK.Checked = True Then
            cbostatusrrak.Enabled = True
            cbostatusnonrrak.Enabled = True

        ElseIf RbRRAK.Checked = False Then
            cbostatusrrak.SelectedItem = "Realisasi"
            cbostatusrrak.Enabled = False
            cbostatusnonrrak.Enabled = True

        End If
    End Sub

    Private Sub RbNONRRAK_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbNONRRAK.CheckedChanged
        If RbNONRRAK.Checked = True Then
            cbostatusrrak.Enabled = False
            cbostatusnonrrak.Enabled = True
        ElseIf RbNONRRAK.Checked = False Then
            cbostatusrrak.Enabled = True
            cbostatusnonrrak.Enabled = False
        End If
       
    End Sub

    Private Sub cetakrrakdetail()
        Call namadcAktif()

        If cbostatusrrak.Text = "Realisasi" Then
            If TxtKodeToko.Text = "" Then
                If cbostatusnonrrak.Text = "Detail" AndAlso cbcategory.Text = "OutStanding" Then
                    sql = "exec spPrintsumaryAnggaranKAS 'RRAKRDetailSumaryOUT','" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "',0"
                ElseIf cbostatusnonrrak.Text = "Detail" AndAlso cbcategory.Text = "Approved" Then
                    sql = "exec spPrintsumaryAnggaranKAS 'RRAKRDetailSumaryAPP','" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "',0"
                Else
                    sql = "exec spPrintsumaryAnggaranKAS 'RRAKRDetailSumaryAll','" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "',0"
                End If
            Else
                If cbostatusnonrrak.Text = "Detail" AndAlso cbcategory.Text = "OutStanding" Then
                    sql = "exec spPrintsumaryAnggaranKAS 'RRAKRDetailSumaryOUTTKO','" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'," & TxtKodeToko.Text & ""
                ElseIf cbostatusnonrrak.Text = "Detail" AndAlso cbcategory.Text = "Approved" Then
                    sql = "exec spPrintsumaryAnggaranKAS 'RRAKRDetailSumaryAPPTKO','" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'," & TxtKodeToko.Text & ""
                Else
                    sql = "exec spPrintsumaryAnggaranKAS 'RRAKRDetailSumaryAllTKO','" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'," & TxtKodeToko.Text & ""
                End If
            End If

        Else
            If TxtKodeToko.Text = "" Then
                If cbostatusnonrrak.Text = "Detail" AndAlso cbcategory.Text = "OutStanding" Then
                    sql = "exec spPrintsumaryAnggaranKAS 'RRAKEDetailSumaryOUT','" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "',0"
                ElseIf cbostatusnonrrak.Text = "Detail" AndAlso cbcategory.Text = "Approved" Then
                    sql = "exec spPrintsumaryAnggaranKAS 'RRAKEDetailSumaryAPP','" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "',0"
                Else
                    sql = "exec spPrintsumaryAnggaranKAS 'RRAKEDetailSumaryALL','" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "',0"
                End If
            Else
                If cbostatusnonrrak.Text = "Detail" AndAlso cbcategory.Text = "OutStanding" Then
                    sql = "exec spPrintsumaryAnggaranKAS 'RRAKEDetailSumaryOUTTKO','" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'," & TxtKodeToko.Text & ""
                ElseIf cbostatusnonrrak.Text = "Detail" AndAlso cbcategory.Text = "Approved" Then
                    sql = "exec spPrintsumaryAnggaranKAS 'RRAKEDetailSumaryAPPTKO','" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'," & TxtKodeToko.Text & ""
                Else
                    sql = "exec spPrintsumaryAnggaranKAS 'RRAKEDetailSumaryALLTKO','" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'," & TxtKodeToko.Text & ""
                End If
            End If
        End If
        Dim Conns As New SqlConnection(ConnSQLClient)
        Dim dt As New DataTable

        Dim da As New SqlDataAdapter(sql, Conns)
        da.Fill(dt)

        Dim DataSetName As String = "dtsRRAKDetail"
        Dim DataTableName As String = "dtRRAKDetail"
        Dim rds As New ReportDataSource(DataSetName, dt)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
        If cbostatusrrak.Text = "Realisasi" Then
            paramList.Add(New ReportParameter("Judul", "Report Detail Realisasi RRAK", True))
        Else
            paramList.Add(New ReportParameter("Judul", "Report Detail Estimasi RRAK", True))
        End If
        paramList.Add(New ReportParameter("SubJudul", cbostatusrrak.Text & "-" & cbcategory.Text, True))
        paramList.Add(New ReportParameter("Tgl1", Format(Me.Tgl1.Value, "dd-MM-yyyy"), True))
        paramList.Add(New ReportParameter("Tgl2", Format(Me.Tgl2.Value, "dd-MM-yyyy"), True))
        paramList.Add(New ReportParameter("NamaDC", kodedc & "-" & namadc, True))

        Dim ReportViewerForm As New FrmReport
        RptAnggaranKas.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptSumDetailRRAK.rdlc"
        RptAnggaranKas.LocalReport.SetParameters(paramList)
        RptAnggaranKas.LocalReport.DataSources.Clear()
        RptAnggaranKas.LocalReport.DataSources.Add(rds)
        RptAnggaranKas.RefreshReport()
        RptAnggaranKas.Show()
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
            cbcategory.SelectedItem = "By Toko"
        End If
    End Sub

    Private Sub cbcategory_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbcategory.TextChanged
        If cbcategory.Text = "By Toko" Then
            BtnFindStore.Enabled = True
        Else
            BtnFindStore.Enabled = False
            TxtKodeToko.Text = ""
            TxtNamaToko.Text = ""
            TxtKodeToko.Clear()
            TxtNamaToko.Clear()
        End If
        '' Call proses()
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub GroupBox5_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox5.Enter

    End Sub
End Class