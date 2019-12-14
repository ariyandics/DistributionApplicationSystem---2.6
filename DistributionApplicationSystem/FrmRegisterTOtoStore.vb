Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Data.OleDb
Public Class FrmRegisterTOtoStore
    Dim Conn, ConnMDB As New ADODB.Connection
    Dim RsConn, RsMdb As New ADODB.Recordset
    Private Sub FrmRegisterTOtoStore_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.RptRegisterTO.Reset()
        Me.RptRegisterTO.RefreshReport()
    End Sub

    Private Sub FrmRegisterTOtoStore_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
    Private Sub cmblist()

        If Label1.Text = "TRANSFER OUT DC TO STORE" Then
            If RbRekap.Checked = True Then
                cmbFilter.Items.Clear()
                cmbFilter.Items.Add("All")
                cmbFilter.Items.Add("Store")
                cmbFilter.Items.Add("Outstanding")
                BtnFindStore.Enabled = False
                cmbFilter.Text = ""
            Else
                cmbFilter.Items.Clear()
                cmbFilter.Items.Add("All")
                cmbFilter.Items.Add("Store")
                BtnFindStore.Enabled = False
                cmbFilter.Text = ""
            End If
        ElseIf Label1.Text = "RETUR TOKO" Then
            cmbFilter.Items.Clear()
            cmbFilter.Items.Add("All")
            cmbFilter.Items.Add("Store")
            cmbFilter.Items.Add("Outstanding")
            BtnFindStore.Enabled = False
            cmbFilter.Text = ""
        Else
            cmbFilter.Items.Clear()
            cmbFilter.Items.Add("All")
            cmbFilter.Items.Add("Store")
            BtnFindStore.Enabled = False
            cmbFilter.Text = ""
        End If


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
            MsgBox("Silahkan Pilih Filter Report...!!", vbOKOnly + vbInformation, "Info")
            Exit Sub
        End If


        If cmbFilter.Text = "Store" Then
            If TxtKodeSupplier.Text = "" Then
                MsgBox("Silahkan Pilih Toko terlebih dahulu...!!", vbOKOnly + vbInformation, "Info")
                BtnFindStore.Focus()
                Exit Sub
            End If
        End If


        If Label1.Text = "TRANSFER OUT DC TO STORE" Then
            If RbRekap.Checked = True Then
                Call Rekap()
            Else
                Call Detail()
            End If
        ElseIf Label1.Text = "TRANSFER IN DC FROM STORE" Then

            If RbRekap.Checked = True Then
                Call RekapTI()
            Else
                Call DetailTI()
            End If
        Else
            If RbRekap.Checked = True Then
                Call RekapRetur()
            Else
                Call DetailRetur()
            End If
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
            strSQL = "exec spPrintTODcKeToko 'Rekap',0,'" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'"
        ElseIf cmbFilter.Text = "Store" Then
            strSQL = "exec spPrintTODcKeToko 'RekapS'," & (TxtKodeSupplier.Text) & ",'" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'"
        Else
            strSQL = "exec spPrintTODcKeToko 'RekapO',0,'" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'"
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
        rds.Name = "DataSetRekapTO"
        rds.Value = objDataSet.Tables(0)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", "REGISTER TRANSFER OUT DC TO STORE - REKAP", True))
        paramList.Add(New ReportParameter("Tgl1", Format(Me.Tgl1.Value, "dd-MM-yyyy"), True))
        paramList.Add(New ReportParameter("Tgl2", Format(Me.Tgl2.Value, "dd-MM-yyyy"), True))
        paramList.Add(New ReportParameter("SubJudul", Me.cmbFilter.Text, True))

        With Me
            .RptRegisterTO.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptRegisterTORekap.rdlc"
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
        Dim objDataSet As DataSet = New DataSetPO
        Dim strSQL, strCONN As String

        GetStringKoneksi() '---1
        strCONN = StrKoneksi '----2

        If cmbFilter.Text = "All" Then

            strSQL = "exec spPrintTODcKeToko 'Detail',0,'" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'"
        ElseIf cmbFilter.Text = "Store" Then
            strSQL = "exec spPrintTODcKeToko 'DetailS'," & (TxtKodeSupplier.Text) & ",'" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'"
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
        rds.Name = "DataSetDetailTO"
        rds.Value = objDataSet.Tables(0)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", "REGISTER TRANSFER OUT DC TO STORE - DETAIL", True))
        paramList.Add(New ReportParameter("Tgl1", Me.Tgl1.Text, True))
        paramList.Add(New ReportParameter("Tgl2", Me.Tgl2.Text.ToString, True))
        paramList.Add(New ReportParameter("SubJudul", Me.cmbFilter.Text, True))


        With Me
            .RptRegisterTO.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptRegisterTODetail.rdlc"
            .RptRegisterTO.LocalReport.DataSources.Clear()
            .RptRegisterTO.LocalReport.DataSources.Add(rds)
            .RptRegisterTO.LocalReport.SetParameters(paramList)
            .RptRegisterTO.RefreshReport()
            .RptRegisterTO.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth
        End With

    End Sub
    Private Sub RekapTI()
        If conn.State = 0 Then
            GetStringKoneksi()
            conn.Open(StrKoneksi)
        End If


        If cmbFilter.Text = "All" Then
            strsql = "exec spPrintTODcKeToko 'LPBReturTokoAll',0,'" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'"
        ElseIf cmbFilter.Text = "Store" Then
            strsql = "exec spPrintTODcKeToko 'LPBReturTokoS'," & (TxtKodeSupplier.Text) & ",'" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'"
        End If

        Dim Conns As New SqlConnection(ConnSQLClient)
        Dim dt As New DataTable

        Dim da As New SqlDataAdapter(strsql, Conns)
        da.Fill(dt)

        Dim DataSetName As String = "DataSetLPBRekap"
        Dim DataTableName As String = "LPBRekap"
        Dim rds As New ReportDataSource(DataSetName, dt)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", "REGISTER TRANSFER IN DC FROM STORE - REKAP", True))
        paramList.Add(New ReportParameter("Tgl1", Format(Me.Tgl1.Value, "dd-MM-yyyy"), True))
        paramList.Add(New ReportParameter("Tgl2", Format(Me.Tgl2.Value, "dd-MM-yyyy"), True))
        paramList.Add(New ReportParameter("SubJudul", Me.cmbFilter.Text, True))

        With Me
            .RptRegisterTO.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptLPBRekap.rdlc"
            .RptRegisterTO.LocalReport.DataSources.Clear()
            .RptRegisterTO.LocalReport.DataSources.Add(rds)
            .RptRegisterTO.LocalReport.SetParameters(paramList)
            .RptRegisterTO.RefreshReport()
            .RptRegisterTO.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth
        End With


    End Sub
    Private Sub DetailTI()
        If Conn.State = 0 Then
            GetStringKoneksi()
            Conn.Open(StrKoneksi)
        End If

      
        If cmbFilter.Text = "All" Then
            strsql = "exec spPrintTODcKeToko 'LPBReturTokoD',0,'" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'"
        ElseIf cmbFilter.Text = "Store" Then
            strsql = "exec spPrintTODcKeToko 'LPBReturTokoDS'," & (TxtKodeSupplier.Text) & ",'" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'"
        End If

        Dim Conns As New SqlConnection(ConnSQLClient)
        Dim dt As New DataTable

        Dim da As New SqlDataAdapter(strSQL, Conns)
        da.Fill(dt)

        Dim DataSetName As String = "DataSetLPBDetail"
        Dim DataTableName As String = "LpbDetail"
        Dim rds As New ReportDataSource(DataSetName, dt)

      

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", "REGISTER TRANSFER IN DC FROM STORE - DETAIL", True))
        paramList.Add(New ReportParameter("Tgl1", Me.Tgl1.Text, True))
        paramList.Add(New ReportParameter("Tgl2", Me.Tgl2.Text.ToString, True))
        paramList.Add(New ReportParameter("SubJudul", Me.cmbFilter.Text, True))


        With Me
            .RptRegisterTO.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptLPBDetail.rdlc"
            .RptRegisterTO.LocalReport.DataSources.Clear()
            .RptRegisterTO.LocalReport.DataSources.Add(rds)
            .RptRegisterTO.LocalReport.SetParameters(paramList)
            .RptRegisterTO.RefreshReport()
            .RptRegisterTO.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth
        End With

    End Sub

    Private Sub RekapRetur()
        If Conn.State = 0 Then
            GetStringKoneksi()
            Conn.Open(StrKoneksi)
        End If


        If cmbFilter.Text = "All" Then
            strsql = "exec spPrintTODcKeToko 'RekapReturTokoAll',0,'" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'"
        ElseIf cmbFilter.Text = "Store" Then
            strsql = "exec spPrintTODcKeToko 'RekapReturTokoS'," & (TxtKodeSupplier.Text) & ",'" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'"
        Else

            strsql = "exec spPrintTODcKeToko 'RekapReturTokoO',0,'" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'"
        End If

        Dim Conns As New SqlConnection(ConnSQLClient)
        Dim dt As New DataTable

        Dim da As New SqlDataAdapter(strsql, Conns)
        da.Fill(dt)

        Dim DataSetName As String = "DataSetRekapReturToko"
        Dim DataTableName As String = "ReturRekap"
        Dim rds As New ReportDataSource(DataSetName, dt)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", "REGISTER RETUR TOKO - REKAP", True))
        paramList.Add(New ReportParameter("Tgl1", Format(Me.Tgl1.Value, "dd-MM-yyyy"), True))
        paramList.Add(New ReportParameter("Tgl2", Format(Me.Tgl2.Value, "dd-MM-yyyy"), True))
        paramList.Add(New ReportParameter("SubJudul", Me.cmbFilter.Text, True))

        With Me
            .RptRegisterTO.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptRegisterRekapReturToko.rdlc"
            .RptRegisterTO.LocalReport.DataSources.Clear()
            .RptRegisterTO.LocalReport.DataSources.Add(rds)
            .RptRegisterTO.LocalReport.SetParameters(paramList)
            .RptRegisterTO.RefreshReport()
            .RptRegisterTO.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth
        End With


    End Sub
    Private Sub DetailRetur()
        If Conn.State = 0 Then
            GetStringKoneksi()
            Conn.Open(StrKoneksi)
        End If


        If cmbFilter.Text = "All" Then
            strsql = "exec spPrintTODcKeToko 'DetailReturTokoAll',0,'" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'"
        ElseIf cmbFilter.Text = "Store" Then
            strsql = "exec spPrintTODcKeToko 'DetailReturTokoS'," & (TxtKodeSupplier.Text) & ",'" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'"
        Else

            strsql = "exec spPrintTODcKeToko 'DetailReturTokoO',0,'" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'"
        End If

        Dim Conns As New SqlConnection(ConnSQLClient)
        Dim dt As New DataTable

        Dim da As New SqlDataAdapter(strsql, Conns)
        da.Fill(dt)

        Dim DataSetName As String = "DataSetReturDetailToko"
        Dim DataTableName As String = "ReturDetail"
        Dim rds As New ReportDataSource(DataSetName, dt)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", "REGISTER RETUR TOKO - DETAIL", True))
        paramList.Add(New ReportParameter("Tgl1", Format(Me.Tgl1.Value, "dd-MM-yyyy"), True))
        paramList.Add(New ReportParameter("Tgl2", Format(Me.Tgl2.Value, "dd-MM-yyyy"), True))
        paramList.Add(New ReportParameter("SubJudul", Me.cmbFilter.Text, True))

        With Me
            .RptRegisterTO.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptRegisterDetailReturToko.rdlc"
            .RptRegisterTO.LocalReport.DataSources.Clear()
            .RptRegisterTO.LocalReport.DataSources.Add(rds)
            .RptRegisterTO.LocalReport.SetParameters(paramList)
            .RptRegisterTO.RefreshReport()
            .RptRegisterTO.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth
        End With
    End Sub

    Private Sub BtnFindStore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFindStore.Click
        TxtKodeSupplier.Text = FrmFind.cari("MasterToko")
        If TxtKodeSupplier.Text = "0" Then
            TxtKodeSupplier.Clear()
            TxtNamaSupplier.Clear()
            Exit Sub
        Else
            gettoko(TxtKodeSupplier.Text)
            TxtNamaSupplier.Text = namatoko
        End If
    End Sub


    Private Sub cmbFilter_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFilter.TextChanged
        If cmbFilter.Text = "" Then
            BtnFindStore.Enabled = False
            Exit Sub
        End If

        If cmbFilter.Text = "Store" Then
            BtnFindStore.Enabled = True
        Else
            BtnFindStore.Enabled = False
            TxtKodeSupplier.Clear()
            TxtNamaSupplier.Clear()
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        Call cmblist()
    End Sub

    Private Sub RbRekap_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbRekap.CheckedChanged
        Call cmblist()
    End Sub
End Class