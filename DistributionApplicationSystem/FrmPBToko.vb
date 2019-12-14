Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Data.OleDb
Public Class FrmPBToko
    Dim sql As String
    Dim conn As New ADODB.Connection
    Dim RsConn As New ADODB.Recordset
    Dim kdtk, nopb, nmtoko As String
    Private Sub FrmPBToko_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If conn.State = 0 Then
            Call GetStringKoneksi()
            conn.Open(StrKoneksi)
        End If

        Label1.Parent = PictureBox1
        Label1.BackColor = Color.Transparent
        Me.Text = Label1.Text
        Me.Label1.Left = (Me.Width - Me.Label1.Width) / 2
        Me.Label1.Top = (Me.PictureBox1.Height - Me.Label1.Height) / 2
        Label1.Font = New Font("Calibri", 20, FontStyle.Bold)
        Me.Text = NamaPT
      

        Call kepalaProsesPB()
        Call kepalaAbsen()
        Call kepalacetak()
        Call loadProsesPB()
        Call loadabsen()
        Call loadCetakPL()
        Call GbrTombol()
        Call loadPLUlang()
        Call namadcAktif()
    End Sub

    Private Sub GbrTombol()
        Me.Button1.Image = System.Drawing.Image.FromFile(icorefresh)
        Me.BtnRefreshProses.Image = System.Drawing.Image.FromFile(icorefresh)
        Me.BtnRefCetak.Image = System.Drawing.Image.FromFile(icorefresh)
        Me.BtnPrint.Image = System.Drawing.Image.FromFile(icoprint)
        Me.BtnProsesPB.Image = System.Drawing.Image.FromFile(icoapprove)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call loadabsen()
    End Sub

    Private Sub kepalaProsesPB()

        ListView1.Columns.Add("Kode Toko", 100)
        ListView1.Columns.Add("Initial", 60)
        ListView1.Columns.Add("Nama Toko", 390)
        ListView1.Columns.Add("No. PB", 100)
    End Sub

    Private Sub kepalacetak()

        ListView3.Columns.Add("Kode Toko", 100)
        ListView3.Columns.Add("Initial", 60)
        ListView3.Columns.Add("Nama Toko", 390)
        ListView3.Columns.Add("No. PL", 100)

        ListView4.Columns.Add("Kode Toko", 100)
        ListView4.Columns.Add("Initial", 60)
        ListView4.Columns.Add("Nama Toko", 390)
        ListView4.Columns.Add("No. PL", 100)
    End Sub


    Private Sub kepalaAbsen()
        ListView2.Columns.Add("No.", 50)
        ListView2.Columns.Add("Kode Toko", 90)
        ListView2.Columns.Add("Initial", 80)
        ListView2.Columns.Add("Nama Toko", 200)
        ListView2.Columns.Add("Keterangan", 200)
    End Sub

    Private Sub loadabsen()
        ListView2.Items.Clear()
        ListView2.View = Windows.Forms.View.Details
        ListView2.GridLines = True
        ListView2.FullRowSelect = True

        sql = "exec spPBTokoHeader1022 'Absen'"
        RsConn = conn.Execute(sql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()
            Dim nomor As Integer
            nomor = 1
            Do While Not RsConn.EOF

                'qtykarton = strqtypo / strC2

                Dim arr(5) As String
                Dim itm As ListViewItem

                arr(0) = nomor
                arr(1) = RsConn("kodetoko").Value.ToString
                arr(2) = RsConn("singkatantoko").Value.ToString
                arr(3) = RsConn("namatoko").Value.ToString
                arr(4) = RsConn("keterangan").Value.ToString

                itm = New ListViewItem(arr)
                ListView2.Items.Add(itm)

                RsConn.MoveNext()
                Label2.Text = nomor.ToString
                nomor = nomor + 1
            Loop

        End If

        RsConn.Close()
    End Sub

    Private Sub loadProsesPB()
        ListView1.Items.Clear()
        ListView1.View = View.Details
        ListView1.GridLines = True
        ListView1.FullRowSelect = True
        ListView1.CheckBoxes = True


        sql = "exec spPBTokoHeader1022 'ProsesPB'"
        RsConn = conn.Execute(sql)

        If Not RsConn.EOF() Then

            RsConn.MoveFirst()
            Do While Not RsConn.EOF

                Dim arr(4) As String
                Dim itm As ListViewItem

                arr(0) = RsConn("kodetoko").Value.ToString
                arr(1) = RsConn("singkatantoko").Value.ToString
                arr(2) = RsConn("namatoko").Value.ToString
                arr(3) = RsConn("nomorpb").Value.ToString


                itm = New ListViewItem(arr)
                ListView1.Items.Add(itm)

                RsConn.MoveNext()
            Loop

        End If

    End Sub

    Private Sub loadCetakPL()
        ListView3.Items.Clear()
        ListView3.View = View.Details
        ListView3.GridLines = True
        ListView3.FullRowSelect = True
        ListView3.CheckBoxes = True


        sql = "exec spPickingheader 'Get'," & IdDC & ",'" & Format(dtPicking.Value, "yyyy-MM-dd") & "'"
        RsConn = conn.Execute(sql)

        If Not RsConn.EOF() Then

            RsConn.MoveFirst()
            Do While Not RsConn.EOF

                Dim arr(4) As String
                Dim itm As ListViewItem

                arr(0) = RsConn("kodetoko").Value.ToString
                arr(1) = RsConn("singkatantoko").Value.ToString
                arr(2) = RsConn("namatoko").Value.ToString
                arr(3) = RsConn("nomorpicking").Value.ToString


                itm = New ListViewItem(arr)
                ListView3.Items.Add(itm)

                RsConn.MoveNext()
            Loop

        End If

    End Sub
    Private Sub loadPLUlang()
        ListView4.Items.Clear()
        ListView4.View = View.Details
        ListView4.GridLines = True
        ListView4.FullRowSelect = True


        sql = "exec spPickingheader 'Getpl'," & IdDC & ",'" & Format(dtPLCetak.Value, "yyyy-MM-dd") & "'"
        RsConn = conn.Execute(sql)

        If Not RsConn.EOF() Then

            RsConn.MoveFirst()
            Do While Not RsConn.EOF

                Dim arr(4) As String
                Dim itm As ListViewItem

                arr(0) = RsConn("kodetoko").Value.ToString
                arr(1) = RsConn("singkatantoko").Value.ToString
                arr(2) = RsConn("namatoko").Value.ToString
                arr(3) = RsConn("nomorpicking").Value.ToString


                itm = New ListViewItem(arr)
                ListView4.Items.Add(itm)

                RsConn.MoveNext()
            Loop

        End If

    End Sub


    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB.CheckedChanged

        Dim i As Integer
        Dim count As Integer
        Dim item As ListViewItem


        count = ListView1.Items.Count - 1
        If CB.Checked = True Then
            ListView1.Enabled = False
            For i = 0 To count
                ListView1.Items(i).Checked = True
                item = ListView1.Items(i)
            Next
        Else
            ListView1.Enabled = True
            For i = 0 To count
                ListView1.Items(i).Checked = False
            Next
        End If
    End Sub

    Private Sub proses()

        Dim item As ListViewItem
        Dim i As Integer
        Dim count As Integer

        Dim regdate As Date = Date.Now
        'Dim strDate As String = regdate.ToString("yyyy-mm-dd")
        Dim strdate As String = (Year(regdate) & "-" & Month(regdate) & "-" & Microsoft.VisualBasic.DateAndTime.Day(regdate))


        count = ListView1.Items.Count - 1

        If count >= 0 Then

            For i = 0 To count
                If i > count Then Exit For

                item = ListView1.Items(i)
                If item.Checked = True Then
                    kdtk = item.SubItems(0).Text
                    nopb = item.SubItems(3).Text

                    If conn.State = 0 Then
                        GetStringKoneksi()
                        conn.Open(StrKoneksi)
                    End If

                    sql = "exec spPickingDetail 'Add'," & IdDC & "," & kdtk & "," & nopb & ",'" & StrNamaUser & "'"
                    conn.Execute(sql)

                End If
            Next
            MessageBox.Show("Proses PB Toko menjadi Picking List selesai")
            CB.Checked = False
            Call loadProsesPB()
        End If
    End Sub

    Private Sub BtnRefreshProses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRefreshProses.Click
        CB.Checked = False
        ListView1.Enabled = True
        Call loadProsesPB()
    End Sub

    Private Sub BtnProsesPB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProsesPB.Click
        Call proses()
    End Sub

    Private Sub dtPicking_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtPicking.ValueChanged
        Call loadCetakPL()
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Dim item As ListViewItem
        Dim i As Integer
        Dim count As Integer

        Dim regdate As Date = Date.Now
        'Dim strDate As String = regdate.ToString("yyyy-mm-dd")
        Dim strdate As String = (Year(regdate) & "-" & Month(regdate) & "-" & Microsoft.VisualBasic.DateAndTime.Day(regdate))


        count = ListView3.Items.Count - 1

        For i = 0 To count
            If i > count Then Exit For

            item = ListView3.Items(i)
            If item.Checked = True Then
                kdtk = item.SubItems(0).Text
                nmtoko = item.SubItems(2).Text
                nopb = item.SubItems(3).Text

                Call cetak()
              
            End If
        Next
        Call loadCetakPL()
       
    End Sub

    Private Sub cetak()
        Dim objConn As OleDbConnection
        Dim objCmd As OleDbCommand
        Dim objReader As OleDbDataReader
        Dim objDataSet As DataSet = New DataSetPO
        Dim strSQL, strCONN As String

        GetStringKoneksi() '---1
        strCONN = StrKoneksi '----2


        strSQL = "exec spPickingDetail 'Cetak'," & IdDC & "," & kdtk & "," & nopb & ",'" & StrNamaUser & "'"

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
        rds.Name = "DataSetPL"
        rds.Value = objDataSet.Tables(0)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", "PICKING LIST", True))
        paramList.Add(New ReportParameter("KodeDC", kodedc, True))
        paramList.Add(New ReportParameter("NamaDC", namadc, True))
        paramList.Add(New ReportParameter("Kodetoko", kdtk, True))
        paramList.Add(New ReportParameter("NamaToko", nmtoko, True))
        paramList.Add(New ReportParameter("NoPicking", nopb, True))
        paramList.Add(New ReportParameter("TglPicking", dtPicking.Value, True))

        Dim ReportViewerForm As New FrmReport
        ReportViewerForm.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptPL.rdlc"
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewerForm.ReportViewer1.LocalReport.SetParameters(paramList)
        ReportViewerForm.ReportViewer1.RefreshReport()
        ReportViewerForm.Show()
    End Sub

    Private Sub cetakulang()
        Dim objConn As OleDbConnection
        Dim objCmd As OleDbCommand
        Dim objReader As OleDbDataReader
        Dim objDataSet As DataSet = New DataSetPL
        Dim strSQL, strCONN As String

        GetStringKoneksi() '---1
        strCONN = StrKoneksi '----2

        strSQL = "exec spPickingheader 'cetak'," & IdDC & ",'" & Format(dtPLCetak.Value, "yyyy-MM-dd") & "'"

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
        rds.Name = "DSPLulang"
        rds.Value = objDataSet.Tables(0)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", "PICKING LIST", True))
        paramList.Add(New ReportParameter("KodeDC", kodedc, True))
        paramList.Add(New ReportParameter("NamaDC", namadc, True))
        paramList.Add(New ReportParameter("TglPicking", dtPicking.Value, True))

        Dim ReportViewerForm As New FrmReport
        ReportViewerForm.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptCetakUlangPL.rdlc"
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewerForm.ReportViewer1.LocalReport.SetParameters(paramList)
        ReportViewerForm.ReportViewer1.RefreshReport()
        ReportViewerForm.Show()
    End Sub

    Private Sub BtnRefCetak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRefCetak.Click
        Call loadCetakPL()
    End Sub

    Private Sub BtnPLUlang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPLUlang.Click
        Call cetakulang()
    End Sub

  
    Private Sub dtPLCetak_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtPLCetak.ValueChanged
        Call loadPLUlang()
    End Sub
End Class