Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Data.OleDb
Imports System.Globalization

Public Class FrmSLSupplier

    Private Sub FrmSLSupplier_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.RptSLSupplier.Reset()
        Me.RptSLSupplier.RefreshReport()
    End Sub
    Private Sub FrmSLSupplier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Call jam()
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

    End Sub

    Private Sub BtnProses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProses.Click
        Call proses()
    End Sub

    Private Sub proses()
        If Tgl1.Value.Date > Tgl2.Value.Date Then
            MsgBox("Periode awal salah !!!", vbOKOnly + vbCritical, "Info")
            Exit Sub
        End If

        If cmbFilter.Text = "" Then
            MsgBox("Silahkan pilih filter report yang ingin di tampilkan !!", vbOKOnly + vbInformation, "Info")
            Exit Sub
        End If


        If cmbFilter.Text = "By Supplier" Then
            If TxtKodeSupplier.Text = "" Then
                MsgBox("Silahkan Pilih Supplier terlebih dahulu...!!", vbOKOnly + vbInformation, "Info")
                BtnFindSupplier.Focus()
                Exit Sub
            End If
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
        Dim objDataSet As DataSet = New DataSetPO
        Dim strSQL, strCONN As String

        GetStringKoneksi() '---1
        strCONN = StrKoneksi '----2

        If cmbFilter.Text = "All" Then
            strSQL = "exec spPrintSLSupplier 'Rekap',0,'" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'"
        ElseIf cmbFilter.Text = "Outstanding" Then
            strSQL = "exec spPrintSLSupplier 'RekapO',0,'" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'"
        ElseIf cmbFilter.Text = "Expired" Then
            strSQL = "exec spPrintSLSupplier 'RekapE',0,'" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'"
        Else
            strSQL = "exec spPrintSLSupplier 'RekapS'," & IdSupplier & ",'" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'"
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
        rds.Name = "DataSetSLSupplierRekap"
        rds.Value = objDataSet.Tables(0)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", "SERVICE LEVEL SUPPLIER - REKAP", True))
        paramList.Add(New ReportParameter("Tgl1", Format(Me.Tgl1.Value, "dd-MM-yyyy"), True))
        paramList.Add(New ReportParameter("Tgl2", Format(Me.Tgl2.Value, "dd-MM-yyyy"), True))

        With Me
            .RptSLSupplier.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptSLSupplierRekap.rdlc"
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
        Dim objDataSet As DataSet = New DataSetPO
        Dim strSQL, strCONN As String

        GetStringKoneksi() '---1
        strCONN = StrKoneksi '----2

        If cmbFilter.Text = "All" Then
            strSQL = "exec spPrintSLSupplier 'Detail',0,'" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'"
        Else
            strSQL = "exec spPrintSLSupplier 'DetailS'," & IdSupplier & ",'" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'"
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
        rds.Name = "DataSetSLSupplierDetail"
        rds.Value = objDataSet.Tables(0)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", "SERVICE LEVEL SUPPLIER - DETAIL", True))
        paramList.Add(New ReportParameter("Tgl1", Format(Me.Tgl1.Value, "dd-MM-yyyy"), True))
        paramList.Add(New ReportParameter("Tgl2", Format(Me.Tgl2.Value, "dd-MM-yyyy"), True))

        With Me
            .RptSLSupplier.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptSLSupplierDetail.rdlc"
            .RptSLSupplier.LocalReport.DataSources.Clear()
            .RptSLSupplier.LocalReport.DataSources.Add(rds)
            .RptSLSupplier.LocalReport.SetParameters(paramList)
            .RptSLSupplier.RefreshReport()
            .RptSLSupplier.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth
        End With

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

  
    Private Sub RbRekap_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbRekap.CheckedChanged
        If RbRekap.Checked = True Then
            cmbFilter.Items.Clear()
            cmbFilter.Items.Add("All")
            cmbFilter.Items.Add("By Supplier")
            cmbFilter.Items.Add("Outstanding")
            cmbFilter.Items.Add("Expired")
            cmbFilter.Text = ""

        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            cmbFilter.Items.Clear()
            cmbFilter.Items.Add("All")
            cmbFilter.Items.Add("By Supplier")
            cmbFilter.Text = ""

        End If
    End Sub

    Private Sub cmbFilter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFilter.SelectedIndexChanged

    End Sub
End Class