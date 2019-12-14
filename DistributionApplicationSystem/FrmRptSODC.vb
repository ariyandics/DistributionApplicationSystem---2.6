Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Data.OleDb
Public Class FrmRptSODC
    Dim Conn, ConnMDB As New ADODB.Connection
    Dim RsConn, RsMdb As New ADODB.Recordset
    Dim idjensistok As Int16

    Private Sub FrmRptSODC_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.RptRegisterTO.Reset()
        Me.RptRegisterTO.RefreshReport()
    End Sub
    Private Sub FrmRptSODC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Parent = PictureBox1
        GroupBox1.Parent = PictureBox1
        GroupBox2.Parent = PictureBox1
        GroupBox3.Parent = PictureBox1
        Label1.BackColor = Color.Transparent
        Me.BackColor = Color.SkyBlue
        Me.BackgroundImage = System.Drawing.Image.FromFile(bg)
        PictureBox1.BackgroundImage = System.Drawing.Image.FromFile(atas)
        Me.Text = NamaPT

        Me.Label1.Left = (Me.Width - Me.Label1.Width) / 2
        Me.Label1.Top = 9
        Call cmblist()
    End Sub

    Private Sub BtnProses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProses.Click
        Call proses()
    End Sub
    Private Sub cmblist()

        cmbFilter.Items.Clear()
        cmbFilter.Items.Add("Good Stock")
        cmbFilter.Items.Add("Bad Stock")
        cmbFilter.Text = ""

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
        Dim objDataSet As DataSet = New DataSetSO
        Dim strSQL, strCONN As String

        GetStringKoneksi() '---1
        strCONN = StrKoneksi '----2

        strSQL = "exec spPrintSODC 'Rekap'," & idjensistok & ",'" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'"

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
        rds.Name = "DataSetSO"
        rds.Value = objDataSet.Tables(0)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", "REGISTER STOCK OPNAME DC - REKAP", True))
        paramList.Add(New ReportParameter("KodeDC", kodedc, True))
        paramList.Add(New ReportParameter("NamaDC", namadc, True))
        paramList.Add(New ReportParameter("Tgl1", Format(Me.Tgl1.Value, "dd-MM-yyyy"), True))
        paramList.Add(New ReportParameter("Tgl2", Format(Me.Tgl2.Value, "dd-MM-yyyy"), True))
        paramList.Add(New ReportParameter("Jenis", Me.cmbFilter.Text, True))

        With Me
            .RptRegisterTO.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptSODCRekap.rdlc"
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
        Dim objDataSet As DataSet = New DataSetSO
        Dim strSQL, strCONN As String

        GetStringKoneksi() '---1
        strCONN = StrKoneksi '----2


        strSQL = "exec spPrintSODC 'Detail'," & idjensistok & ",'" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'"

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
        rds.Name = "DataSetSO"
        rds.Value = objDataSet.Tables(0)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", "REGISTER STOCK OPNAME DC - Detail", True))
        paramList.Add(New ReportParameter("KodeDC", kodedc, True))
        paramList.Add(New ReportParameter("NamaDC", namadc, True))
        paramList.Add(New ReportParameter("Tgl1", Format(Me.Tgl1.Value, "dd-MM-yyyy"), True))
        paramList.Add(New ReportParameter("Tgl2", Format(Me.Tgl2.Value, "dd-MM-yyyy"), True))
        paramList.Add(New ReportParameter("Jenis", Me.cmbFilter.Text, True))



        With Me
            .RptRegisterTO.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptSODCDetail.rdlc"
            .RptRegisterTO.LocalReport.DataSources.Clear()
            .RptRegisterTO.LocalReport.DataSources.Add(rds)
            .RptRegisterTO.LocalReport.SetParameters(paramList)
            .RptRegisterTO.RefreshReport()
            .RptRegisterTO.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth
        End With

    End Sub

    Private Sub cmbFilter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFilter.SelectedIndexChanged
       
        If cmbFilter.Text = "Good Stock" Then
            idjensistok = 1
        Else
            idjensistok = 2
        End If
    End Sub

End Class