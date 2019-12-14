Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Data.OleDb
Public Class FrmPrintReturSupplier
    Dim rscon As New ADODB.Recordset
    Dim conn As New ADODB.Connection
    Dim sql As String
    Dim tglawal, tglakhir As Date
    Private Sub FrmPrintReturSupplier_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.RptRegisterTO.Reset()
        Me.RptRegisterTO.RefreshReport()
    End Sub

    Private Sub FrmPrintReturSupplier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Parent = PictureBox1
        GroupBox1.Parent = PictureBox1
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
        RbMonthly.Checked = True
        Call cmblist()


        Dim dt As Date = Now.AddDays(-1)
        Dim x As Integer = Microsoft.VisualBasic.DateAndTime.Day(dt)
        Tgl3.Value = Now.AddDays(-x)
    End Sub
    Private Sub cmblist()

        cmbFilter.Items.Clear()
        cmbFilter.Items.Add("All")
        cmbFilter.Items.Add("By Supplier")
        cmbFilter.Text = ""
        BtnFindSupplier.Enabled = False
     
    End Sub

    Private Sub BtnProses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProses.Click
        Me.RptRegisterTO.Reset()
        Call proses()
    End Sub
    Private Sub proses()
        tglawal = Tgl3.Value
        tglakhir = tglawal.AddMonths(1).AddDays(-1)


        If RbDaily.Checked = True Then
            If Tgl1.Value.Date > Tgl2.Value.Date Then
                MsgBox("Periode awal salah !!!", vbOKOnly + vbCritical, "Info")
                Exit Sub
            End If
            If RbRekap.Checked = False And RbDetail.Checked = False Then
                MsgBox("Anda belum memilih jenis report Rekap / Detail !!!", vbOKOnly + vbCritical, "Info")
                Exit Sub
            End If
        End If

        If RbMonthly.Checked = False And RbDaily.Checked = False Then
            MsgBox("Anda belum memilih periode Monthly / Daily !!!", vbOKOnly + vbCritical, "Info")
            Exit Sub
        End If

        If cmbFilter.Text = "" Then
            MsgBox("Silahkan Pilih Filter Report...!!", vbOKOnly + vbInformation, "Info")
            Exit Sub
        End If


        If cmbFilter.Text = "By Supplier" Then
            If TxtKodeSupplier.Text = "" Then
                MsgBox("Silahkan Pilih Toko terlebih dahulu...!!", vbOKOnly + vbInformation, "Info")
                BtnFindSupplier.Focus()
                Exit Sub
            End If
        End If



        If RbMonthly.Checked = True Then
            Call Monthly()
        ElseIf RbDaily.Checked = True Then
            If RbRekap.Checked = True Then
                Call rekap()
            ElseIf RbDetail.Checked = True Then
                Call Detail()

            End If
        End If
    End Sub
    Private Sub Monthly()
        If conn.State = 0 Then
            GetStringKoneksi()
            conn.Open(StrKoneksi)
        End If

        If cmbFilter.Text = "All" Then
            strsql = "exec spPrintReturSupplier 'MonthlyAll',0,'" & Format(tglawal, "yyyy-MM-dd") & "','" & Format(tglakhir, "yyyy-MM-dd") & "'"
        ElseIf cmbFilter.Text = "By Supplier" Then
            strsql = "exec spPrintReturSupplier 'MonthlyS'," & IdSupplier & ",'" & Format(tglawal, "yyyy-MM-dd") & "','" & Format(tglakhir, "yyyy-MM-dd") & "'"
        End If
        Dim Conns As New SqlConnection(ConnSQLClient)
        Dim dt As New DataTable

        Dim DataSetName As String = "DSReturSupplier"
        Dim DataTableName As String = "ReturBulanan"

        Dim da As New SqlDataAdapter(strsql, Conns)
        da.Fill(dt)
        Dim rds As New ReportDataSource(DataSetName, dt)


        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", "REGISTER RETUR SUPPLIER - MONTHLY", True))
        paramList.Add(New ReportParameter("Tgl3", Format(Me.Tgl3.Value, "MMMM-yyyy"), True))
        paramList.Add(New ReportParameter("SubJudul", Me.cmbFilter.Text, True))

        With Me
            .RptRegisterTO.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptReturSupplierMonth.rdlc"
            .RptRegisterTO.LocalReport.DataSources.Clear()
            .RptRegisterTO.LocalReport.DataSources.Add(rds)
            .RptRegisterTO.LocalReport.SetParameters(paramList)
            .RptRegisterTO.RefreshReport()
            .RptRegisterTO.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth
        End With

    End Sub
    Private Sub Detail()
        Dim objConn As OleDbConnection
        Dim objCmd As OleDbCommand
        Dim objReader As OleDbDataReader
        Dim objDataSet As DataSet = New DataSetNRBSupplier
        Dim strSQL, strCONN As String

        GetStringKoneksi() '---1
        strCONN = StrKoneksi '----2

        If cmbFilter.Text = "All" Then
            strSQL = "exec spPrintReturSupplier 'DailyDtlA',0,'" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'"
        ElseIf cmbFilter.Text = "By Supplier" Then
            strSQL = "exec spPrintReturSupplier 'DailyDtlS'," & IdSupplier & ",'" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'"
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
        rds.Name = "DataSetNRBSupplier"
        rds.Value = objDataSet.Tables(0)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", "REGISTER RETUR SUPPLIER DETAIL- DAILY", True))
        paramList.Add(New ReportParameter("Tgl1", Me.Tgl1.Text, True))
        paramList.Add(New ReportParameter("Tgl2", Me.Tgl2.Text.ToString, True))
        paramList.Add(New ReportParameter("SubJudul", Me.cmbFilter.Text, True))


        With Me
            .RptRegisterTO.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptNRBSupplierDetail.rdlc"
            .RptRegisterTO.LocalReport.DataSources.Clear()
            .RptRegisterTO.LocalReport.DataSources.Add(rds)
            .RptRegisterTO.LocalReport.SetParameters(paramList)
            .RptRegisterTO.RefreshReport()
            .RptRegisterTO.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth
        End With

    End Sub
    Private Sub rekap()
        Dim objConn As OleDbConnection
        Dim objCmd As OleDbCommand
        Dim objReader As OleDbDataReader
        Dim objDataSet As DataSet = New DataSetNRBSupplier
        Dim strSQL, strCONN As String

        GetStringKoneksi() '---1
        strCONN = StrKoneksi '----2

        If cmbFilter.Text = "All" Then
            strSQL = "exec spPrintReturSupplier 'DailyRkpA',0,'" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'"
        Else
            strSQL = "exec spPrintReturSupplier 'DailyRkpS'," & IdSupplier & ",'" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'"
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
        rds.Name = "DataSetNRBRekap"
        rds.Value = objDataSet.Tables(0)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", "REGISTER RETUR SUPPLIER REKAP- DAILY", True))
        paramList.Add(New ReportParameter("Tgl1", Me.Tgl1.Text.ToString, True))
        paramList.Add(New ReportParameter("Tgl2", Me.Tgl2.Text.ToString, True))
        paramList.Add(New ReportParameter("SubJudul", Me.cmbFilter.Text, True))


        With Me
            .RptRegisterTO.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptNRBSupplierRekap.rdlc"
            .RptRegisterTO.LocalReport.DataSources.Clear()
            .RptRegisterTO.LocalReport.DataSources.Add(rds)
            .RptRegisterTO.LocalReport.SetParameters(paramList)
            .RptRegisterTO.RefreshReport()
            .RptRegisterTO.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth
        End With

    End Sub

    Private Sub RbMonthly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbMonthly.CheckedChanged
        If RbMonthly.Checked = True Then
            GroupBox1.Enabled = False
            Tgl1.Visible = False
            Tgl2.Visible = False
            Label2.Visible = False
            Tgl3.Visible = True
            cmbFilter.Text = ""
        End If
    End Sub

    Private Sub RbDaily_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbDaily.CheckedChanged
        If RbDaily.Checked = True Then
            GroupBox1.Enabled = True
            Tgl1.Visible = True
            Tgl2.Visible = True
            Label2.Visible = True
            Tgl3.Visible = False
            cmbFilter.Text = ""
        End If
    End Sub

    Private Sub cmbFilter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFilter.SelectedIndexChanged

    End Sub

    Private Sub BtnFindSupplier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFindSupplier.Click
        TxtKodeSupplier.Text = FrmFind.cari("MasterSupplier")
        If TxtKodeSupplier.Text = "0" Then
            TxtKodeSupplier.Clear()
            TxtNamaSupplier.Clear()
            Exit Sub
        Else
            getSupplier(TxtKodeSupplier.Text)
            TxtNamaSupplier.Text = NamaSupplier
        End If
    End Sub

    Private Sub cmbFilter_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFilter.TextChanged

        If cmbFilter.Text = "" Then
            BtnFindSupplier.Enabled = False
            Exit Sub
        End If

        If cmbFilter.Text = "By Supplier" Then
            BtnFindSupplier.Enabled = True
        Else
            BtnFindSupplier.Enabled = False
            TxtKodeSupplier.Clear()
            TxtNamaSupplier.Clear()
        End If
    End Sub

    Private Sub Tgl3_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tgl3.ValueChanged
    End Sub
End Class