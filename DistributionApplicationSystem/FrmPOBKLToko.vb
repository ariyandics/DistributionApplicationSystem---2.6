Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Data.OleDb
Public Class FrmPOBKLToko
    Dim sql As String
    Dim conn As New ADODB.Connection
    Dim RsConn As New ADODB.Recordset
    Dim kdtk, nmtoko As String
    Dim nomorupo, nopb, nopotoko As Int64
    Dim tglctk As Date
    Private Sub FrmPOBKLToko_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Call namadcAktif()


        Call kepalaProsesPB()
        Call kepalaAbsen()
        Call kepalacetak()
        Call loadProsesPB()
        Call loadabsen()
        Call loadCetakPL()
        Call GbrTombol()
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
        ListView1.Columns.Add("Nama Toko", 240)
        ListView1.Columns.Add("No.PO BKL", 100)

    End Sub

    Private Sub kepalacetak()

        ListView3.Columns.Add("Kode Toko", 100)
        ListView3.Columns.Add("Initial", 60)
        ListView3.Columns.Add("Nama Toko", 240)
        ListView3.Columns.Add("No.PO BKL", 100)
        ListView1.Columns.Add("No.PO DC", 0)
        ListView1.Columns.Add("No.UPO", 0)
    End Sub


    Private Sub kepalaAbsen()
        ListView2.Columns.Add("No.", 60)
        ListView2.Columns.Add("Kode Toko", 100)
        ListView2.Columns.Add("Initial", 80)
        ListView2.Columns.Add("Nama Toko", 260)
    End Sub

    Private Sub loadabsen()
        ListView2.Items.Clear()
        ListView2.View = Windows.Forms.View.Details
        ListView2.GridLines = True
        ListView2.FullRowSelect = True

        sql = "exec [spPBBKLToko] 'Absen',0,0,'2017-01-01'"
        RsConn = conn.Execute(sql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()
            Dim nomor As Integer
            nomor = 1
            Do While Not RsConn.EOF


                Dim arr(4) As String
                Dim itm As ListViewItem

                arr(0) = nomor
                arr(1) = RsConn("kodetoko").Value.ToString
                arr(2) = RsConn("singkatantoko").Value.ToString
                arr(3) = RsConn("namatoko").Value.ToString

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


        sql = "exec [spPBBKLToko] 'ProsesPB',0,0,'2017-01-01'"
        RsConn = conn.Execute(sql)

        If Not RsConn.EOF() Then

            RsConn.MoveFirst()
            Do While Not RsConn.EOF

                Dim arr(4) As String
                Dim itm As ListViewItem

                arr(0) = RsConn("kodetoko").Value.ToString
                arr(1) = RsConn("singkatantoko").Value.ToString
                arr(2) = RsConn("namatoko").Value.ToString
                arr(3) = RsConn("nomorpo").Value.ToString


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


        sql = "exec [spPBBKLToko] 'ListCtkPO',0,0,'" & Format(dtPicking.Value, "yyyy-MM-dd") & "'"
        RsConn = conn.Execute(sql)

        If Not RsConn.EOF() Then

            RsConn.MoveFirst()
            Do While Not RsConn.EOF

                Dim arr(6) As String
                Dim itm As ListViewItem

                arr(0) = RsConn("kodetoko").Value.ToString
                arr(1) = RsConn("singkatantoko").Value.ToString
                arr(2) = RsConn("namatoko").Value.ToString
                arr(3) = RsConn("nomorpo").Value.ToString
                arr(4) = RsConn("nomorpobkl").Value.ToString
                arr(5) = RsConn("nomorupo").Value.ToString

                itm = New ListViewItem(arr)
                ListView3.Items.Add(itm)

                RsConn.MoveNext()
            Loop

        End If

    End Sub

    Private Sub BtnRefreshProses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRefreshProses.Click
        ListView1.Enabled = True
        Call loadProsesPB()
    End Sub

    Private Sub BtnProsesPB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProsesPB.Click
        Dim item As ListViewItem
        Dim i As Integer
        Dim count As Integer

        count = ListView1.Items.Count

        If count > 0 Then

            For i = 0 To count - 1
                If i > count Then Exit For
                ' ListView1.Items(i).Checked = True
                item = ListView1.Items(i)
                If item.Checked = True Then
                    kdtk = item.SubItems(0).Text
                    nmtoko = item.SubItems(2).Text
                    nopb = item.SubItems(3).Text

                    sql = "exec spPBBKLToko 'LockPO'," & kdtk & "," & nopb & ",'2017-01-01'"
                    conn.Execute(sql)

                End If

            Next
            MsgBox("Proses Rekap PO Selesai")


            tglctk = DateAdd(DateInterval.Day, -1, Now.Date)

            sql = "exec spPBBKLToko 'GetSupp',0,0,'" & Format(tglctk, "yyyy-MM-dd") & "'"
            RsConn = conn.Execute(sql)
            If Not RsConn.EOF Then
                RsConn.MoveFirst()
                Do While Not RsConn.EOF
                    Call cetak(RsConn("idsupplier").Value)
                    RsConn.MoveNext()
                Loop
            End If

        End If
        Call loadProsesPB()
        Call loadCetakPL()
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
                nopotoko = item.SubItems(3).Text
                nopb = item.SubItems(4).Text
                nomorupo = item.SubItems(5).Text
                Call cetakpo()

            End If
        Next
        Call loadCetakPL()

    End Sub

    Private Sub cetak(ByVal x As Int16)
        Dim objConn As OleDbConnection
        Dim objCmd As OleDbCommand
        Dim objReader As OleDbDataReader
        Dim objDataSet As DataSet = New DataSetPO
        Dim strSQL, strCONN As String

        GetStringKoneksi() '---1
        strCONN = StrKoneksi '----2


        strSQL = "exec spPBBKLToko 'CtkRekap'," & x & ",0,'" & Format(tglctk, "yyyy-MM-dd") & "'"

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
        rds.Name = "DataSetBKLToko"
        rds.Value = objDataSet.Tables(0)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", "PO SUPPLIER BKL", True))
        paramList.Add(New ReportParameter("KodeDC", kodedc, True))
        paramList.Add(New ReportParameter("NamaDC", namadc, True))

        Dim ReportViewerForm As New FrmReport
        ReportViewerForm.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptRekapPOBKL.rdlc"
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewerForm.ReportViewer1.LocalReport.SetParameters(paramList)
        ReportViewerForm.ReportViewer1.RefreshReport()
        ReportViewerForm.Show()
    End Sub

    Private Sub BtnRefCetak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRefCetak.Click
        Call loadCetakPL()
    End Sub
    Private Sub cetakpo()

        Dim objConn As OleDbConnection
        Dim objCmd As OleDbCommand
        Dim objReader As OleDbDataReader
        Dim objDataSet As DataSet = New DataSetPO
        Dim strSQL, strCONN, sql, kdsupplier, nmsupplier, almtsupplier, telpsupp As String
        Dim namatoko, kodetoko, alamattoko, tlptoko, dibuat, keterangan As String
        Dim tglexp, tglproses As Date
        Dim rptotal, pajak, diskon, rpgross As Decimal

        sql = "exec spPoDcDetail 'Getbkl'," & IdDC & "," & nomorupo & "," & nopb & ",0,0,0,0,0,0,0,0,0,0,0,0"
        RsConn = conn.Execute(sql)

        If Not RsConn.EOF Then
            kdsupplier = RsConn("kodeSupplier").Value
            nmsupplier = RsConn("namaSupplier").Value
            almtsupplier = RsConn("kodeSupplier").Value
            telpsupp = RsConn("notelephone").Value
            termOP = RsConn("termOffPayment").Value
            dibuat = RsConn("namauser").Value
            keterangan = RsConn("keterangan").Value

            namatoko = RsConn("namatoko").Value
            kodetoko = RsConn("kodetoko").Value
            alamattoko = RsConn("alamattoko").Value
            tlptoko = RsConn("telepon").Value

            tglexp = RsConn("tglexpiredpo").Value
            tglproses = RsConn("tglapprove").Value

            rptotal = RsConn("totalRp").Value
            pajak = RsConn("totalpajak").Value
            diskon = RsConn("totaldiskon").Value
            rpgross = RsConn("totalRpPO").Value

            Dim xx As String = rpgross.ToString
            nilaiterbilang = TerbilangDesimal(xx)

        End If

        GetStringKoneksi() '---1
        strCONN = StrKoneksi '----2

        strSQL = "exec spPoDcDetail 'Get'," & IdDC & "," & nomorupo & "," & nopb & ",0,0,0,0,0,0,0,0,0,0,0,0"

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
        rds.Name = "DataSetPO"
        rds.Value = objDataSet.Tables(0)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPerusahaan", NamaPT, True))
        paramList.Add(New ReportParameter("FormHeader", "PURCHASE ORDER BKL", True))
        paramList.Add(New ReportParameter("KodeSupplier", kdsupplier, True))
        paramList.Add(New ReportParameter("NamaSupplier", nmsupplier, True))
        paramList.Add(New ReportParameter("AlamatSupplier", almtsupplier, True))
        paramList.Add(New ReportParameter("TelpSupplier", telpsupp, True))
        paramList.Add(New ReportParameter("KodeDC", kodetoko, True))
        paramList.Add(New ReportParameter("NamaDC", namatoko, True))
        paramList.Add(New ReportParameter("AlamatDC", alamattoko, True))
        paramList.Add(New ReportParameter("telpDC", tlptoko, True))
        paramList.Add(New ReportParameter("KotaDC", kotadc, True))
        paramList.Add(New ReportParameter("NoFaktur", nopotoko, True))
        paramList.Add(New ReportParameter("TglPO", Format(dtPicking.Value, "dd-MM-yyyy"), True))
        paramList.Add(New ReportParameter("TglExpired", tglexp, True))
        paramList.Add(New ReportParameter("TglProses", Format(tglproses, "dd-MM-yyyy"), True))
        paramList.Add(New ReportParameter("TglBuat", Format(dtPicking.Value, "dd-MM-yyyy"), True))
        paramList.Add(New ReportParameter("TtlHargaPembelian", Format(rptotal, "#,##0.##"), True))
        paramList.Add(New ReportParameter("TtlDiscount", Format(diskon, "#,##0.##"), True))
        paramList.Add(New ReportParameter("TtlSetelahDiscount", Format(rptotal - diskon, "#,##0.##"), True))
        paramList.Add(New ReportParameter("PpnIn", Format(pajak, "#,##0.##"), True))
        'paramList.Add(New ReportParameter("TtlIncPPN", Me.txtIncPPN.Text, True))
        paramList.Add(New ReportParameter("TtlFaktur", Format(rpgross, "#,##0.##"), True))
        paramList.Add(New ReportParameter("terbilang", nilaiterbilang, True))
        paramList.Add(New ReportParameter("TglKirim", Format(DateAdd(DateInterval.Day, 1, tglproses), "dd-MM-yyyy"), True))
        paramList.Add(New ReportParameter("dibuat", dibuat, True))
        paramList.Add(New ReportParameter("keterangan", keterangan, True))
        paramList.Add(New ReportParameter("TOP", termOP, True))

        Dim ReportViewerForm As New FrmReport
        ReportViewerForm.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptPOBKL.rdlc"
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewerForm.ReportViewer1.LocalReport.SetParameters(paramList)
        ReportViewerForm.ReportViewer1.RefreshReport()
        ReportViewerForm.Show()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        tglctk = DateAdd(DateInterval.Day, -1, dtPicking.Value)

        sql = "exec spPBBKLToko 'GetSupp',0,0,'" & Format(tglctk, "yyyy-MM-dd") & "'"
        RsConn = conn.Execute(sql)
        If Not RsConn.EOF Then
            RsConn.MoveFirst()
            Do While Not RsConn.EOF
                Call cetak(RsConn("idsupplier").Value)
                RsConn.MoveNext()
            Loop
        End If
    End Sub
End Class