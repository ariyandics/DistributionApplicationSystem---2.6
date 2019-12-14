Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Data.OleDb
Public Class FrmRekapUPO
    Dim Conn, ConnMDB As New ADODB.Connection
    Dim RsConn, RsMdb, rsconnx As New ADODB.Recordset
    Dim sql As String
    Dim kodesupplier, namasupplier, telpsupplier, faxsupplier As String
    Dim itemsupplier, itempo, total As Double
    Dim nomor As Int64

    Private Sub FrmRekapUPO_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Call bersih()
    End Sub

    Private Sub bersih()
        TxtNoUPO.Clear()
        nomorUPO = 0
    End Sub
    Private Sub FrmRekapUPO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        nomorUPO = 0
        Call LoadData()
        BtnPreview.Text = "Detail"
        Call GbrTombol()

    End Sub
    Private Sub GbrTombol()
        Me.BtnApprove.Image = System.Drawing.Image.FromFile(icoapprove)
        Me.BtnPrint.Image = System.Drawing.Image.FromFile(icoprint)
    End Sub
    Private Sub cek()
        If TxtNoUPO.Text = "" Then
            nomorUPO = 0
            BtnPrint.Enabled = False
            BtnApprove.Enabled = False
        Else
            BtnPrint.Enabled = True
            BtnApprove.Enabled = True
        End If
    End Sub


    Private Sub detail()
        Dim z As Integer
        z = ListView2.SelectedItems.Count

        If z = 0 Then
            MsgBox("Anda belum pilih data..!!", vbOKOnly, "Informasi")
            BtnPreview.Text = "Detail"
            Exit Sub
        Else
            kodesupplier = ListView2.SelectedItems.Item(0).SubItems(1).Text
            Call getSupplier(kodesupplier)
            Call loaddetail()

        End If
    End Sub
    Private Sub loaddetail()
        ListView2.Columns.Clear()
        ListView2.Items.Clear()
        ListView2.View = Windows.Forms.View.Details
        ListView2.GridLines = True
        ListView2.FullRowSelect = True


        ListView2.Columns.Add("idproduk", 0)
        ListView2.Columns.Add("SKU", 100)
        ListView2.Columns.Add("Description", 230)
        ListView2.Columns.Add("Class", 60)
        ListView2.Columns.Add("Tag", 50)
        ListView2.Columns.Add("MaxS", 80, HorizontalAlignment.Right)
        ListView2.Columns.Add("SOH", 80, HorizontalAlignment.Right)
        ListView2.Columns.Add("Out PO", 80, HorizontalAlignment.Right)
        ListView2.Columns.Add("MinOrder", 80, HorizontalAlignment.Right)
        ListView2.Columns.Add("Qty PO", 80, HorizontalAlignment.Right)
        ListView2.Columns.Add("Total PO", 80, HorizontalAlignment.Right)


        sql = "exec spUpoDcDetail 'GetEdit'," & IdDC & "," & nomorUPO & ",0," & IdSupplier & ",'x',0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,'%'"

        RsConn = Conn.Execute(sql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()
            Dim x As Integer = 0
            Do While Not RsConn.EOF

                Dim arr(11) As String
                Dim itm As ListViewItem

                arr(0) = RsConn("idproduk").Value.ToString
                arr(1) = RsConn("kodeproduk").Value.ToString
                arr(2) = RsConn("namapanjang").Value.ToString
                arr(3) = RsConn("class").Value.ToString
                arr(4) = RsConn("kodetag").Value.ToString
                arr(5) = Format(RsConn("maxstok").Value, "#,##")
                arr(6) = Format(RsConn("stokOH").Value, "#,##")
                arr(7) = Format(RsConn("outposupplier").Value, "#,##")
                arr(8) = Format(RsConn("minorder").Value, "#,##")
                arr(9) = Format(RsConn("qtyupo").Value, "#,##")
                arr(10) = Format(RsConn("subtotal").Value, "#,##")

                itm = New ListViewItem(arr)
                ListView2.Items.Add(itm)
                If x Mod 2 Then
                    ListView2.Items(x).BackColor = Color.LightBlue
                Else
                    ListView2.Items(x).BackColor = Color.White
                End If
                x = x + 1
                RsConn.MoveNext()
            Loop

        End If
        RsConn.Close()
    End Sub
    Private Sub BtnFindNoUPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFindNoUPO.Click
        TxtNoUPO.Clear()
        TxtNoUPO.Text = FrmFind.cari("NomorUPO")
        nomorUPO = Val(TxtNoUPO.Text)
        Call LoadData()
        Call cek()
    End Sub



    Private Sub LoadData()
        ListView2.Columns.Clear()
        ListView2.Items.Clear()
        ListView2.View = Windows.Forms.View.Details
        ListView2.GridLines = True
        ListView2.FullRowSelect = True

        ListView2.Columns.Add("No.", 50)
        ListView2.Columns.Add("Kode Supp", 80)
        ListView2.Columns.Add("Nama Supplier", 300)
        ListView2.Columns.Add("Telp", 90)
        ListView2.Columns.Add("Fax", 90)
        ListView2.Columns.Add("Jumlah Item", 85, HorizontalAlignment.Right)
        ListView2.Columns.Add("Item PO", 85, HorizontalAlignment.Right)
        ListView2.Columns.Add("Total", 150, HorizontalAlignment.Right)


        sql = "exec spRekapUPO 'get'," & IdDC & "," & nomorUPO & ",'" & StrNamaUser & "'"
        RsConn = Conn.Execute(sql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()

            Dim x As Integer = 0

            Do While Not RsConn.EOF

                nomor = RsConn("nomor").Value
                kodesupplier = RsConn("kodesupplier").Value
                namasupplier = RsConn("namasupplier").Value
                telpsupplier = RsConn("noTelephone").Value
                faxsupplier = RsConn("noFax").Value
                itemsupplier = RsConn("ttlitem").Value
                itempo = RsConn("itempo").Value
                total = RsConn("total").Value


                Dim arr(8) As String
                Dim itm As ListViewItem

                arr(0) = nomor
                arr(1) = kodesupplier
                arr(2) = namasupplier
                arr(3) = telpsupplier
                arr(4) = faxsupplier
                arr(5) = itemsupplier.ToString("N")
                arr(6) = itempo.ToString("N")
                arr(7) = total.ToString("N")


                itm = New ListViewItem(arr)
                ListView2.Items.Add(itm)
                If x Mod 2 Then
                    ListView2.Items(x).BackColor = Color.LightBlue
                Else
                    ListView2.Items(x).BackColor = Color.White
                End If
                x = x + 1
                RsConn.MoveNext()
            Loop

        End If
        RsConn.Close()

    End Sub

    Private Sub cetak()
        GetStringKoneksi()
        Dim Conn As New SqlConnection(ConnSQLClient)
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter("exec spRekapUPO 'get'," & IdDC & "," & nomorUPO & ",'" & StrNamaUser & "'", Conn)
        da.Fill(dt)

        Dim DataSetName As String = "DataSetRekapUPO"
        Dim DataTableName As String = "RekapUPO"
        Dim rds As New ReportDataSource(DataSetName, dt)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NoRekap", nomorUPO, True))
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))

        Dim ReportViewerForm As New FrmReport
        ReportViewerForm.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptRekapUPO.rdlc"
        ReportViewerForm.ReportViewer1.LocalReport.SetParameters(paramList)
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewerForm.ReportViewer1.RefreshReport()
        ReportViewerForm.Show()
    End Sub

    Private Sub BtnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnApprove.Click
        sql = "Select * from upodcheader where nomorupo=" & nomorUPO & " and iddc=" & IdDC & " and statusdata= 0"
        RsConfig = Conn.Execute(sql)
        If Not RsConfig.EOF Then
            Dim result2 As DialogResult = MessageBox.Show("Apakah data ingin di Simpan menjadi PO?", _
                 "Warning !!", _
                 MessageBoxButtons.YesNo, _
                 MessageBoxIcon.Question)
            If result2 = DialogResult.Yes Then
                sql = "exec [spAddUPO] 'cek'," & nomorUPO & ",'" & StrNamaUser & "'"
                RsConn = Conn.Execute(sql)
                If Not RsConn.EOF Then
                    MsgBox("Masih ada produk yang harga belinya masih 0 ( nol )!!!", vbOKOnly + vbCritical, "info")
                    Exit Sub
                End If


                Call jadiPO()
                MsgBox("Data berhasil di Simpan menjadi PO Persuplier", vbOKOnly + vbInformation, "Info")
                Call bersih()
                Call cek()
                LoadData()
            Else
                Exit Sub
            End If
        Else
            MsgBox("Nomor Usulan PO ini sudah menjadi PO persupplier..", vbOKOnly + vbInformation, "Info")
        End If


    End Sub

    Private Sub jadiPO()
        'isi PO header
        sql = "exec spRekapUPO 'add'," & IdDC & "," & nomorUPO & ",'" & StrNamaUser & "'"
        Conn.Execute(sql)

    End Sub


    Private Sub BtnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPreview.Click
        If TxtNoUPO.Text = "" Then
            MsgBox("Nomor UPO belum di pilih!!!", vbOKOnly + vbInformation, "Info")
            Exit Sub
        End If

        If BtnPreview.Text = "Rekap" Then
            BtnPreview.Text = "Detail"
            Call LoadData()
            BtnPrint.Enabled = True
            BtnApprove.Enabled = True

        Else
            BtnPreview.Text = "Rekap"
            Call detail()
            BtnPrint.Enabled = False
            BtnApprove.Enabled = False
        End If

    End Sub

    Private Sub ListView2_DrawColumnHeader(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawListViewColumnHeaderEventArgs) Handles ListView2.DrawColumnHeader
        Dim strFormat As New StringFormat()


        If e.Header.TextAlign = HorizontalAlignment.Center Then
            strFormat.Alignment = StringAlignment.Center
        ElseIf e.Header.TextAlign = HorizontalAlignment.Right Then
            strFormat.Alignment = StringAlignment.Far
        End If

        e.DrawBackground()
        e.Graphics.FillRectangle(Brushes.DarkBlue, e.Bounds)
        Dim headerFont As New Font("Arial", 10, FontStyle.Bold)

        e.Graphics.DrawString(e.Header.Text, headerFont, Brushes.White, e.Bounds, strFormat)


    End Sub

    Private Sub ListView2_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawListViewItemEventArgs) Handles ListView2.DrawItem
        e.DrawDefault = True
    End Sub

    Private Sub TxtNoUPO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNoUPO.KeyDown
        If e.KeyCode = Keys.Enter Then
            nomorUPO = TxtNoUPO.Text
            sql = "Select * from upodcheader where nomorupo=" & nomorUPO & " and iddc=" & IdDC & " and statusdata= 0"
            RsConfig = Conn.Execute(sql)
            If RsConfig.EOF Then
                MsgBox("No Usulan PO tidak di temukan...!!", vbOKOnly + vbInformation, "Info")
                Call LoadData()
                Exit Sub
            Else
                Call LoadData()
                Call cek()

            End If

        End If

    
    End Sub

    Private Sub TxtNoUPO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNoUPO.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(Keys.Back))
    End Sub

   
    Private Sub BtnPrint_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        If ListView2.Items.Count > 0 Then
            Call cetak()
        Else
            MsgBox("Tidak ada data untuk di cetak ..", vbOKOnly + vbInformation, "Info")
            Exit Sub
        End If
    End Sub
End Class