Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Data.OleDb
Public Class FrmRptSoToko
    Private Sub FrmSLDCToStore_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.RptSOToko.Reset()
        Me.RptSOToko.RefreshReport()
    End Sub
    Private Sub FrmRptSoToko_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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


        cmbFilter.Items.Clear()
        cmbFilter.Items.Add("All")
        cmbFilter.Items.Add("Store")
        BtnFindStore.Enabled = False
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
            If TxtKodeToko.Text = "" Then
                MsgBox("Silahkan Pilih Toko terlebih dahulu...!!", vbOKOnly + vbInformation, "Info")
                BtnFindStore.Focus()
                Exit Sub
            End If
        End If

        If rbdetail.Checked = True Then
            If cmbFilter.Text = "All" Then
                Call Detail()
            Else
                Call DetailToko()
            End If
            'Call Rekap()
            'Else

        End If
    End Sub


    'Private Sub Rekap()
    '    Dim objConn As OleDbConnection
    '    Dim objCmd As OleDbCommand
    '    Dim objReader As OleDbDataReader
    '    Dim objDataSet As DataSet = New DataSetPO
    '    Dim strSQL, strCONN As String

    '    GetStringKoneksi() '---1
    '    strCONN = StrKoneksi '----2

    '    If cmbFilter.Text = "All" Then
    '        strSQL = "exec spPrintSLDCToStore 'Rekap',0,'" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'"
    '    Else
    '        strSQL = "exec spPrintSLDCToStore 'RekapS'," & (TxtKodeSupplier.Text) & ",'" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'"
    '    End If

    '    objConn = New OleDbConnection(strCONN)
    '    objCmd = New OleDbCommand(strSQL, objConn)
    '    objCmd.CommandType = CommandType.Text
    '    objCmd.Connection.Open()
    '    objCmd.CommandTimeout = 0
    '    objReader = objCmd.ExecuteReader
    '    objDataSet.Tables(0).Clear()
    '    objDataSet.Tables(0).Load(objReader)
    '    objReader.Close()
    '    objConn.Close()

    '    Dim rds As ReportDataSource = New ReportDataSource
    '    rds.Name = "DataSetSLDCToStore"
    '    rds.Value = objDataSet.Tables(0)

    '    Dim paramList As New Generic.List(Of ReportParameter)
    '    paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
    '    paramList.Add(New ReportParameter("Judul", "SERVICE LEVEL DC TO STORE - REKAP", True))
    '    paramList.Add(New ReportParameter("Tgl1", Format(Me.Tgl1.Value, "dd-MM-yyyy"), True))
    '    paramList.Add(New ReportParameter("Tgl2", Format(Me.Tgl2.Value, "dd-MM-yyyy"), True))

    '    With Me
    '        .RptSLSupplier.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptSLDCToStoreRekap.rdlc"
    '        .RptSLSupplier.LocalReport.DataSources.Clear()
    '        .RptSLSupplier.LocalReport.DataSources.Add(rds)
    '        .RptSLSupplier.LocalReport.SetParameters(paramList)
    '        .RptSLSupplier.RefreshReport()
    '        .RptSLSupplier.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth
    '    End With

    'End Sub
    Private Sub Detail()
        Dim objConn As OleDbConnection
        Dim objCmd As OleDbCommand
        Dim objReader As OleDbDataReader
        Dim objDataSet As DataSet = New DataSetPO
        Dim strSQL, strCONN As String

        GetStringKoneksi() '---1
        strCONN = StrKoneksi '----2

        strSQL = "exec spAdjustmenStokToko 'ALLToko',0,'" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'"
       
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
        rds.Name = "dtsRptSoToko"
        rds.Value = objDataSet.Tables(0)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", "STOCK OPNAME TOKO - " & cmbFilter.Text & "", True))
        paramList.Add(New ReportParameter("Tgl1", Format(Me.Tgl1.Value, "dd-MM-yyyy"), True))
        paramList.Add(New ReportParameter("Tgl2", Format(Me.Tgl2.Value, "dd-MM-yyyy"), True))

        With Me
            .RptSOToko.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptSOTokoDetail.rdlc"
            .RptSOToko.LocalReport.DataSources.Clear()
            .RptSOToko.LocalReport.DataSources.Add(rds)
            .RptSOToko.LocalReport.SetParameters(paramList)
            .RptSOToko.RefreshReport()
            .RptSOToko.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth
        End With

    End Sub
    Private Sub DetailToko()
        Dim objConn As OleDbConnection
        Dim objCmd As OleDbCommand
        Dim objReader As OleDbDataReader
        Dim objDataSet As DataSet = New DataSetPO
        Dim strSQL, strCONN As String

        GetStringKoneksi() '---1
        strCONN = StrKoneksi '----2

        strSQL = "exec spAdjustmenStokToko 'PerToko'," & (TxtKodeToko.Text) & ",'" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'"

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
        rds.Name = "dtsRptSoToko"
        rds.Value = objDataSet.Tables(0)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", "STOCK OPNAME TOKO - " & cmbFilter.Text & "", True))
        paramList.Add(New ReportParameter("Tgl1", Format(Me.Tgl1.Value, "dd-MM-yyyy"), True))
        paramList.Add(New ReportParameter("Tgl2", Format(Me.Tgl2.Value, "dd-MM-yyyy"), True))
        paramList.Add(New ReportParameter("Toko", namatoko, True))
        paramList.Add(New ReportParameter("Alamat", alamattoko, True))

        With Me
            .RptSOToko.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptSOTokoDetailByToko.rdlc"
            .RptSOToko.LocalReport.DataSources.Clear()
            .RptSOToko.LocalReport.DataSources.Add(rds)
            .RptSOToko.LocalReport.SetParameters(paramList)
            .RptSOToko.RefreshReport()
            .RptSOToko.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth
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