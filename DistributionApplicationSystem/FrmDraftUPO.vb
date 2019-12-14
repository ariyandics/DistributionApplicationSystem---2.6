Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Data.OleDb
Public Class FrmDraftUPO
    Dim Conn, ConnMDB As New ADODB.Connection
    Dim RsConn, RsMdb, rsconnx As New ADODB.Recordset
    Dim sql As String

    Private Sub FrmDraftUPO_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        BtnProses.Focus()
    End Sub

    Private Sub FrmDraftUPO_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.RptDraft.Reset()
        Me.RptDraft.RefreshReport()
    End Sub

    Private Sub FrmDraftUPO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '  Me.RptDraft.RefreshReport()
        If Conn.State = 0 Then
            Call GetStringKoneksi()
            Conn.Open(StrKoneksi)
        End If

        Label1.Parent = PictureBox1
        Label1.BackColor = Color.Transparent
        Me.Text = Label1.Text
        Me.Label1.Left = (Me.Width - Me.Label1.Width) / 2
        Me.Label1.Top = (Me.PictureBox1.Height - Me.Label1.Height) / 2
        Label1.Font = New Font("Calibri", 20, FontStyle.Bold)
        Me.Text = NamaPT
        Panel1.BackColor = Color.DeepSkyBlue
     
        Call bersih()
        TxtKodeDC.Text = kodedc
        TxtNamaDC.Text = namadc
    End Sub



    Private Sub bersih()
        TxtKodeDC.Clear()
        TxtNamaDC.Clear()
        TxtTanggal.Clear()

        TxtKodeDC.ReadOnly = True
        TxtNamaDC.ReadOnly = True
        TxtTanggal.ReadOnly = True

        TxtKodeDC.BackColor = Color.White
        TxtNamaDC.BackColor = Color.White
        TxtTanggal.BackColor = Color.White

        Me.TxtTanggal.Text = Format(Now, "dddd, dd-MMM-yyyy ,hh:mm:ss")

    End Sub

    Private Sub FrmDraftUPO_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.Label1.Left = (Me.Width - Me.Label1.Width) / 2
        Me.Label1.Top = 9

        TxtTanggal.Parent = Panel1
        TxtTanggal.Left = TxtTanggal.Parent.Width - 240

        LblTanggal.Parent = Panel1
        LblTanggal.Left = TxtTanggal.Parent.Width - 320
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProses.Click
      
        sql = ("exec spUpoDcHeader 'GetProses'," & IdDC & "," & nomorUPO & ",1,'" & Format(Now, "yyyy-MM-dd") & "',1,1,1,1,1,1,'" & StrNamaUser & "'")
        RsConfig = Conn.Execute(sql)
        If Not RsConfig.EOF Then
            Dim status As Integer = RsConfig("statusdata").Value
            nomorUPO = RsConfig("nomorupo").Value
            'idjenispo = RsConfig("idjenispo").Value
            If status = 0 Then
                Dim result2 As DialogResult = MessageBox.Show("UPO sudah di proses hari ini !!! Mau Proses Ulang?", _
                         "Warning !!", _
                         MessageBoxButtons.YesNo, _
                         MessageBoxIcon.Question)
                If result2 = DialogResult.Yes Then
                    BtnProses.Enabled = False
                    Conn.Execute("Delete from upodcdetail where nomorupo=" & nomorUPO)
                    Conn.Execute("Delete from upodcheader where nomorupo=" & nomorUPO)
                    Call proses(1)
                    BtnProses.Enabled = True
                Else
                    Call proses(0)
                    Exit Sub
                End If
            Else
                MsgBox("Usulan PO Hari ini sudah menjadi PO persupplier..", vbOKOnly + vbInformation, "Info")
                Exit Sub
            End If
        Else
            Call proses(1)
            BtnProses.Enabled = True
        End If
    End Sub
   

    Private Sub proses(ByVal x As Int16)
        Dim objConn As OleDbConnection
        Dim objCmd As OleDbCommand
        Dim objReader As OleDbDataReader
        Dim objDataSet As DataSet = New DataSetUPO
        Dim strSQL, strCONN As String

        GetStringKoneksi() '---1
        strCONN = StrKoneksi '----2

        If x = 1 Then
            strSQL = "spAddUPO 'Add'," & IdDC & ",'" & StrNamaUser & "'"
        Else
            strSQL = "spAddUPO 'Get'," & IdDC & ",'" & StrNamaUser & "'"
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
        rds.Name = "DataSetUPO"
        rds.Value = objDataSet.Tables(0)


        With Me
            .RptDraft.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptDraftUPO.rdlc"
            '.RptDraft.LocalReport.ReportPath = System.Environment.CurrentDirectory + "\RptDraftUPO.rdlc"
            .RptDraft.LocalReport.DataSources.Clear()
            .RptDraft.LocalReport.DataSources.Add(rds)
            '.ReportViewer1.LocalReport.SetParameters(paramList)
            .RptDraft.RefreshReport()
        End With

    End Sub


End Class