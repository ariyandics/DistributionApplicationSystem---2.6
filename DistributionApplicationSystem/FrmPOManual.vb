Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Data.OleDb
Public Class FrmPOManual
    Dim Conn, ConnMDB As New ADODB.Connection
    Dim RsConn, RsMdb, rsconnx As New ADODB.Recordset
    Dim sql, keterangan As String
    Dim nomorpo, noUrut, qtykarton, strC1, strC2, parsial As Int64
    Dim strqtypo, strharga, strdisc1, strdisc2, strnetto As Decimal
    Dim stridproduk, strplu, strnamabarang, strBarcode, alamatsupplier, telpsupplier As String
    Dim rpsystem, qtysystem, pajakkoreksi, totalkoreksi, rptotal, diskon1, diskon2 As Decimal
    Dim qtykoreksi As Int64
    Dim nomorponew, nomorupo As Integer
    Dim tglbuat, dibuat As String
    Dim flagadd As Boolean
    Dim boleh As Boolean

    Private Sub FrmPOManual_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        BtnAdd.Focus()
    End Sub

    Private Sub FrmPOManual_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If Val(TxtNoFaktur.Text) > 0 Then
            Conn.Execute("Delete from UpoDCDetailTmp  where nomorupo=" & Val(TxtNoFaktur.Text))
            Conn.Execute("Delete from UpoDCDetailTmp  where nomorupo=" & nomorponew)
            Conn.Execute("Delete from poDCDetailTmp  where nomorpo=" & Val(TxtNoFaktur.Text))
        End If
    End Sub
    Private Sub FrmPOManual_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call jam()
        nomorpo = 0
        nomorupo = 0
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
        Panel2.BackColor = Color.DeepSkyBlue


        Call bersih()
        Call cektable()
        Call LoadData()
        Call GbrTombol()
        flagadd = False
        boleh = False


    End Sub

    Private Sub GbrTombol()
        Me.BtnAdd.Image = System.Drawing.Image.FromFile(icoadd)
        Me.BtnApproval.Image = System.Drawing.Image.FromFile(icoapprove)
        Me.BtnEdit.Image = System.Drawing.Image.FromFile(icoedit)
        Me.BtnCancel.Image = System.Drawing.Image.FromFile(icocancel)
        Me.BtnSimpan.Image = System.Drawing.Image.FromFile(icosave)
        Me.BtnPrint.Image = System.Drawing.Image.FromFile(icoprint)
        Me.btnUpdHarga.Image = System.Drawing.Image.FromFile(icorefresh)
    End Sub
    Private Sub cektable()
        sql = "Select TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='poDcDetailTmp'"
        RsConfig = Conn.Execute(sql)
        If RsConfig.EOF Then
            sql = "select top 0 * into poDcDetailTmp from poDcDetail "
            Conn.Execute(sql)
        End If

    End Sub
    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        'Call jam()
        Call proses()
    End Sub
    Private Sub proses()
        Dim objConn As OleDbConnection
        Dim objCmd As OleDbCommand
        Dim objReader As OleDbDataReader
        Dim objDataSet As DataSet = New DataSetPO
        Dim strSQL, strCONN As String

        GetStringKoneksi() '---1
        strCONN = StrKoneksi '----2

        strSQL = "exec spPoDcDetail 'Get'," & IdDC & "," & nomorponew & "," & nomorpo & ",0,0,0,0,0,0,0,0,0,0,0,0"

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
        paramList.Add(New ReportParameter("FormHeader", "PURCHASE ORDER (PO Manual)", True))
        paramList.Add(New ReportParameter("KodeSupplier", Me.TxtKodeSupplier.Text, True))
        paramList.Add(New ReportParameter("NamaSupplier", Me.TxtNamaSupplier.Text, True))
        paramList.Add(New ReportParameter("AlamatSupplier", Me.alamatsupplier, True))
        paramList.Add(New ReportParameter("TelpSupplier", telpsupplier, True))
        paramList.Add(New ReportParameter("KodeDC", kodedc, True))
        paramList.Add(New ReportParameter("NamaDC", namadc, True))
        paramList.Add(New ReportParameter("AlamatDC", alamatdc, True))
        paramList.Add(New ReportParameter("telpDC", telpdc, True))
        paramList.Add(New ReportParameter("KotaDC", kotadc, True))
        paramList.Add(New ReportParameter("NoFaktur", Me.TxtNoFaktur.Text, True))
        paramList.Add(New ReportParameter("TglPO", TglPO.Text, True))
        paramList.Add(New ReportParameter("TglExpired", Me.TglExpired.Text, True))
        paramList.Add(New ReportParameter("TglProses", Format(TglProses.Value, "dd-MM-yyyy HH:mm:ss"), True))
        paramList.Add(New ReportParameter("TglBuat", Format(TglProses.Value, "dd-MM-yyyy"), True))
        paramList.Add(New ReportParameter("TtlHargaPembelian", Me.txtharga.Text, True))
        paramList.Add(New ReportParameter("TtlDiscount", Me.txtdiscount.Text, True))
        paramList.Add(New ReportParameter("TtlSetelahDiscount", Me.txthargadiscount.Text, True))
        paramList.Add(New ReportParameter("PpnIn", Me.txtppn.Text, True))
        paramList.Add(New ReportParameter("TtlIncPPN", Me.txtIncPPN.Text, True))
        paramList.Add(New ReportParameter("TtlFaktur", Me.txttotal.Text, True))
        paramList.Add(New ReportParameter("terbilang", nilaiterbilang, True))
        paramList.Add(New ReportParameter("TglKirim", Format(DateAdd(DateInterval.Day, 1, TglPO.Value), "dd-MM-yyyy"), True))
        paramList.Add(New ReportParameter("dibuat", dibuat, True))
        paramList.Add(New ReportParameter("keterangan", txtketerangan.Text, True))
        paramList.Add(New ReportParameter("TOP", termOP, True))

        Dim ReportViewerForm As New FrmReport
        ReportViewerForm.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptPO.rdlc"
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewerForm.ReportViewer1.LocalReport.SetParameters(paramList)
        ReportViewerForm.ReportViewer1.RefreshReport()
        ReportViewerForm.Show()

    End Sub
    Private Sub bersih()
        nomorpo = 0
        nomorupo = 0
        flagadd = True
        TxtNoFaktur.Clear()
        ' TxtBuyer.Clear()
        TxtNamaSupplier.Clear()
        TxtKodeSupplier.Clear()
        TxtPKP.Clear()
        cbpartial.Checked = False

        txtKodeProduk.Clear()
        txtNamaProduk.Clear()
        txtPrice.Clear()
        txtqty.Clear()
        TxtExtTime.Clear()
        txtketerangan.Clear()

        txtharga.Clear()
        txtdiscount.Clear()
        txtIncPPN.Clear()
        txttotal.Clear()
        txthargadiscount.Clear()
        txtppn.Clear()

        TxtKodeSupplier.ReadOnly = True
        TxtNamaSupplier.ReadOnly = True
        TxtNoFaktur.ReadOnly = True
        ' TxtBuyer.ReadOnly = True
        txtharga.ReadOnly = True
        TxtPKP.ReadOnly = True
        txtdiscount.ReadOnly = True
        txthargadiscount.ReadOnly = True
        txttotal.ReadOnly = True
        txtppn.ReadOnly = True
        txtIncPPN.ReadOnly = True
        txtKodeProduk.ReadOnly = True
        txtNamaProduk.ReadOnly = True
        txtPrice.ReadOnly = True
        TxtExtTime.ReadOnly = True
        txtketerangan.ReadOnly = True


        TglPO.Enabled = False
        TglExpired.Enabled = False
        TglProses.Enabled = False


        TxtKodeSupplier.BackColor = Color.White
        TxtNamaSupplier.BackColor = Color.White
        TxtNoFaktur.BackColor = Color.White
        txtharga.BackColor = Color.White
        txtdiscount.BackColor = Color.White
        txthargadiscount.BackColor = Color.White
        txttotal.BackColor = Color.White
        txtppn.BackColor = Color.White
        txtIncPPN.BackColor = Color.White
        TxtPKP.BackColor = Color.White
        'TxtBuyer.BackColor = Color.White
        txtPrice.BackColor = Color.White
        txtNamaProduk.BackColor = Color.White
        txtKodeProduk.BackColor = Color.White
        TxtExtTime.BackColor = Color.White
        txtketerangan.BackColor = Color.White

        BtnEdit.Enabled = False
        BtnSimpan.Enabled = False
        BtnApproval.Enabled = False
        BtnPrint.Enabled = False
        BtnCancel.Enabled = False
        btnFindNoPO.Enabled = True
        BtnFindSupplier.Enabled = False
        btnUpdHarga.Enabled = False

        cbpartial.Enabled = False
        'Panel1.Enabled = False
        Panel2.Enabled = False

        TxtExtTime.Text = "0"
    End Sub


    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Call getjenispo()
        If POok = False Then
            MsgBox("Ada data pendukung yang tidak lengkap !!, Silahkan hubungi IT Administrator", vbOKOnly + vbCritical, "Warning")
            Exit Sub
        End If

        Call bersih()
        btnFindNoPO.Enabled = False
        BtnFindSupplier.Enabled = True
        flagadd = True
        Panel1.Enabled = True
        BtnCancel.Enabled = True
        BtnAdd.Enabled = False
        TglExpired.MinDate = Now
        cbpartial.Enabled = True

        sql = "Select isnull(max(nomorUpo),0 )as nomor from upodcdetailtmp where nomorupo< 2000"
        RsConfig = Conn.Execute(sql)
        If RsConfig("nomor").Value > 0 Then
            nomorupo = RsConfig("nomor").Value + 1
        Else
            nomorupo = 1
        End If
        sql = "exec spUpoDcDetailtmp 'add'," & IdDC & "," & nomorupo & "," & idProduk & "," & IdSupplier & ",'F',0,0,0,0,0,0,0,0," & qtykoreksi & ",0,0,0,0,0,0,'X'"
        Conn.Execute(sql)
        TxtNoFaktur.Text = nomorupo
        'TxtBuyer.Text = StrNamaUser
        BtnFindSupplier.Focus()
        TglExpired.Enabled = True
        TglExpired.MinDate = Now
        Call LoadData()
    End Sub
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Conn.Execute("Delete from UpoDCDetailTmp  where nomorupo=" & nomorUPO)
        Conn.Execute("Delete from poDCDetailTmp  where nomorpo=" & TxtNoFaktur.Text)
        Call bersih()
        Call LoadData()
        BtnAdd.Enabled = True
        TglExpired.MinDate = "2017-07-01"
        idProduk = 0
    End Sub

    Private Sub LoadData()

        ListView2.Columns.Clear()
        ListView2.Items.Clear()
        ListView2.View = Windows.Forms.View.Details
        ListView2.GridLines = True
        ListView2.FullRowSelect = True

        ListView2.Columns.Add("No", 50)
        ListView2.Columns.Add("Barcode", 100)
        ListView2.Columns.Add("SKU", 80)
        ListView2.Columns.Add("Description", 300)
        ListView2.Columns.Add("Qty PO", 80, HorizontalAlignment.Right)
        ListView2.Columns.Add("Conv 1", 70, HorizontalAlignment.Right)
        ListView2.Columns.Add("Conv 2", 70, HorizontalAlignment.Right)
        ListView2.Columns.Add("Cost", 80, HorizontalAlignment.Right)
        ListView2.Columns.Add("Disc 1", 60, HorizontalAlignment.Right)
        ListView2.Columns.Add("Disc 2", 60, HorizontalAlignment.Right)
        ListView2.Columns.Add("Netto", 120, HorizontalAlignment.Right)

        'If flagadd = True Then
        sql = "exec spUpoDcDetailtmp 'GetManual'," & IdDC & "," & nomorUPO & ",0,0,'x',0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,'x'"
        'Else
        '    sql = "exec spPoDcDetailTmp 'Get'," & IdDC & "," & nomorpo & ",0,0,0,0,0,0,0,0"
        ' End If
        RsConn = Conn.Execute(sql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()
            noUrut = 1
            Do While Not RsConn.EOF
                strBarcode = RsConn("barcode").Value
                strplu = RsConn("kodeproduk").Value
                strnamabarang = RsConn("namapanjang").Value
                strC1 = RsConn("c1").Value
                strC2 = RsConn("c2").Value
                strharga = RsConn("hargaBeliTerakhir").Value
                strdisc1 = RsConn("disk1").Value
                strdisc2 = RsConn("disk2").Value
                'If flagadd = True Then
                strqtypo = RsConn("qtyuPo").Value
                strnetto = RsConn("rpuPo").Value
                'Else
                'strqtypo = RsConn("qtyPo").Value
                'strnetto = RsConn("rpPo").Value
                'End If

                'qtykarton = strqtypo / strC2

                Dim arr(11) As String
                Dim itm As ListViewItem

                arr(0) = noUrut
                arr(1) = strBarcode
                arr(2) = strplu
                arr(3) = strnamabarang
                arr(4) = strqtypo.ToString("N")
                If strC1 > 0 Then
                    arr(5) = strC1.ToString("N")
                Else
                    arr(5) = ""
                End If
                If strC2 > 0 Then
                    arr(6) = strC2.ToString("N")
                Else
                    arr(6) = ""
                End If
                arr(7) = strharga.ToString("N")
                arr(8) = strdisc1.ToString("N")
                arr(9) = strdisc2.ToString("N")
                arr(10) = strnetto.ToString("N")

                itm = New ListViewItem(arr)
                ListView2.Items.Add(itm)
                noUrut = noUrut + 1
                RsConn.MoveNext()

            Loop

        End If
        RsConn.Close()
    End Sub

    Private Sub BtnFindSupplier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFindSupplier.Click

        TxtKodeSupplier.Text = FrmFind.cari("POManual")
        If TxtKodeSupplier.Text = "0" Then
            TxtKodeSupplier.Text = ""
            Exit Sub
        Else
            If LT = 0 Then
                LT = 1
            End If

            getSupplier(TxtKodeSupplier.Text)
            TxtNamaSupplier.Text = NamaSupplier
            TxtPKP.Text = PKP
            TglExpired.Value = DateAdd(DateInterval.Day, LT, Now)
            txtketerangan.ReadOnly = False
            txtketerangan.Focus()
            txtketerangan.SelectAll()

            Panel2.Enabled = True
            txtKodeProduk.ReadOnly = False
        End If

    End Sub


    Private Sub BtnFindProduk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFindProduk.Click
        txtKodeProduk.Text = FrmFind.cari("ProdukPOManual")
        If txtKodeProduk.Text = "0" Then
            txtKodeProduk.Text = ""
            Exit Sub
        Else
            getNamaProduk(txtKodeProduk.Text, IdSupplier)
            txtNamaProduk.Text = NamaProduk
            txtPrice.Text = Format(harga, "#,##0.##")
        End If
        txtqty.Focus()
    End Sub

    Private Sub txtqty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtqty.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call symbol()

            If Val(txtPrice.Text) <= 0 Then
                MsgBox("Produk ini belum di setting harga belinya !!", vbOKOnly + vbCritical, "Info")
                txtqty.Focus()
                txtqty.SelectAll()
                Exit Sub

            End If
            totalkoreksi = qtykoreksi * harga
            diskon1 = (totalkoreksi) * disk1 / 100
            diskon2 = (totalkoreksi - diskon1) * disk2 / 100
            totalkoreksi = totalkoreksi - diskon1 - diskon2
            If TxtPKP.Text = "PKP" Then
                pajakkoreksi = (totalkoreksi) * pajakpersen / 100
            Else
                pajakkoreksi = 0
            End If
            rptotal = totalkoreksi + pajakkoreksi

            'If flagadd = True Then
            sql = "exec spUpoDcDetailtmp 'add'," & IdDC & "," & nomorUPO & "," & idProduk & "," & IdSupplier & ",'" & Ptag & "',0,0,0,0,0,0,0,0," & qtykoreksi & "," & harga & "," & disk1 & "," & disk2 & "," & totalkoreksi & "," & pajakkoreksi & "," & rptotal & ",'x'"
            'Else
            '    sql = "exec spPoDcDetailTmp 'Add'," & IdDC & "," & nomorpo & "," & idProduk & "," & qtykoreksi & ",0,0,0,0,0,0"
            'End If

            Conn.Execute(sql)
            Call LoadData()
            txtNamaProduk.Clear()
            txtKodeProduk.Clear()
            txtPrice.Clear()
            txtNamaProduk.Clear()
            txtqty.Clear()

            BtnEdit.Enabled = False
            BtnSimpan.Enabled = True
            ListView2.Enabled = True
            BtnFindSupplier.Enabled = False
            BtnFindProduk.Focus()
            Call LoadData()
            Call hitung()
        End If
    End Sub
    Private Sub hitung()
        'If flagadd = True Then
        sql = "exec spUpoDcDetailtmp 'Hitung'," & IdDC & "," & nomorUPO & "," & idProduk & "," & IdSupplier & ",'x',0,0,0,0,0,0,0,0," & qtykoreksi & ",0,0,0,0,0,0,'x'"
        'Else
        'sql = "exec spPoDcDetailTmp 'Hitung'," & IdDC & "," & nomorpo & "," & idProduk & ",0,0,0,0,0,0,0"
        'End If
        RsConfig = Conn.Execute(sql)
        If Not RsConfig.EOF Then
            txtharga.Text = Format(RsConfig("total").Value, "#,##0.##")
            txtdiscount.Text = Format(RsConfig("diskon").Value, "#,##0.##")
            txthargadiscount.Text = Format(RsConfig("ttldisk").Value, "#,##0.##")
            txtppn.Text = Format(RsConfig("pajak").Value, "#,##0.##")
            txttotal.Text = Format(RsConfig("subtotal").Value, "#,##0.##")
            txtIncPPN.Text = Format(RsConfig("subtotal").Value, "#,##0.##")
            rptotal = RsConfig("subtotal").Value
            Dim xx As String = rptotal.ToString
            nilaiterbilang = TerbilangDesimal(xx)
        End If

    End Sub
    Private Sub txtqty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtqty.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(Keys.Back))
    End Sub
    Private Sub txtqty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtqty.TextChanged
        If txtqty.Text = "" Then txtqty.Text = 0
        qtykoreksi = Replace(txtqty.Text, ".", "")
        txtqty.Text = Format(qtykoreksi, "##,##0.##")
        txtqty.SelectionStart = Len(txtqty.Text)
    End Sub

    Private Sub BtnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSimpan.Click

        If TglExpired.Value.Date <= Now.Date Then
            MsgBox("Tanggal Expired Tidak boleh kurang " & vbCrLf _
                 & "atau sama dengan hari ini!!!", vbOKOnly + vbExclamation, "Warning")
            TglExpired.Enabled = True
            TglExpired.Focus()
            Exit Sub
        End If

        If cbpartial.Checked = True Then
            If Val(TxtExtTime.Text) <= 0 Then
                Dim result1 As DialogResult = MessageBox.Show("Extended Time PO Belum di isi !!!  , apakah yakin akan di lanjutkan ??", _
              "Question", _
              MessageBoxButtons.YesNo, _
              MessageBoxIcon.Question)
                If result1 = DialogResult.Yes Then
                    Panel2.Enabled = True
                    cbpartial.Focus()

                Else
                    TxtExtTime.Focus()
                    TxtExtTime.SelectAll()
                    Exit Sub
                End If

            End If
        End If

        Dim result2 As DialogResult = MessageBox.Show("Simpan PO Manual ??", _
               "Question !!", _
               MessageBoxButtons.YesNo, _
               MessageBoxIcon.Question)
        If result2 = DialogResult.Yes Then

            sql = "exec spUpoDcDetailtmp 'GetManual'," & IdDC & "," & nomorupo & ",0,0,'x',0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,'x'"
            RsConn = Conn.Execute(sql)

            If RsConn.EOF Then
                MsgBox("Tidak ada data yang di simpan!!", vbOKOnly + vbInformation, "Info")
                Exit Sub
            End If


            If flagadd = True Then
                ' Insrt ke UPO
                RsConfig = Conn.Execute("select  dbo.fcgetnomorupo(" & IdDC & ") xx")
                nomorponew = RsConfig("xx").Value
                Conn.Execute("exec spUpoDcHeader 'add'," & IdDC & "," & nomorponew & ",2,'2017-01-01',1,1,1,1,1,1,'" & StrNamaUser & "'")
                Conn.Execute("update UpoDCDetailTmp set statusdata=1, nomorupo=" & nomorponew & " where nomorupo=" & nomorupo & " and idsupplier=" & IdSupplier)
                Conn.Execute("Insert into UpoDcDetail select * from UpoDcDetailTMP where qtyupo > 0 and nomorupo=" & nomorponew & " and idsupplier=" & IdSupplier)
                Conn.Execute("exec spUpoDcHeader 'add'," & IdDC & "," & nomorponew & ",2,'2017-01-01',1,1,1,1,1,1,'" & StrNamaUser & "'")
                Conn.Execute("update upoDcheader set statusdata=1 where nomorUpo=" & nomorponew)

                ' Insert Ke PO
                RsConfig = Conn.Execute("select  dbo.fcgetnomorpo(" & IdDC & ") xx")
                nomorpo = RsConfig("xx").Value
                sql = "exec spUpoDcDetailtmp 'Hitung'," & IdDC & "," & nomorponew & "," & idProduk & "," & IdSupplier & ",'x',0,0,0,0,0,0,0,0," & qtykoreksi & ",0,0,0,0,0,0,'x'"
                RsConfig = Conn.Execute(sql)
                If Not RsConfig.EOF Then
                    sql = "exec spPoDcHeader 'AddManual', " & IdDC & "," & nomorponew & "," & nomorpo & "," & IdSupplier & ",'" & Format(TglPO.Value, "yyyy-MM-dd") & "','" & Format(TglExpired.Value, "yyyy-MM-dd") & "','" & Format(TglExpired.Value, "yyyy-MM-dd") & "'," & _
                          RsConfig("ttlitem").Value & "," & RsConfig("ttlqty").Value & "," & RsConfig("total").Value & "," & RsConfig("diskon").Value & "," & RsConfig("pajak").Value & "," & RsConfig("subtotal").Value & ",'" & StrNamaUser & "'," & Val(TxtExtTime.Text) & ",'" & txtketerangan.Text & "'," & parsial
                    Conn.Execute(sql)
                End If

                sql = "exec spUpoDcDetailtmp 'Get'," & IdDC & "," & nomorponew & "," & idProduk & "," & IdSupplier & ",'x',0,0,0,0,0,0,0,0," & qtykoreksi & ",0,0,0,0,0,0,'x'"
                RsConfig = Conn.Execute(sql)
                If Not RsConfig.EOF Then
                    RsConfig.MoveFirst()
                    Do While Not RsConfig.EOF
                        Conn.Execute("exec spPoDcDetail 'Add'," & IdDC & "," & nomorponew & "," & nomorpo & "," & _
                                      RsConfig("idproduk").Value & "," & RsConfig("qtyupo").Value & "," & RsConfig("hargaBeliTerakhir").Value & "," & _
                                      RsConfig("disk1").Value & "," & RsConfig("disk2").Value & ",0,0,0,0," & RsConfig("rpupo").Value & "," & RsConfig("pajak").Value & "," & RsConfig("subtotal").Value)
                        RsConfig.MoveNext()
                    Loop
                End If


            Else
                Conn.Execute("update UpoDCDetailTmp set statusdata=1, nomorupo=" & nomorponew & " where nomorupo=" & nomorupo & " and idsupplier=" & IdSupplier)
                Conn.Execute("Delete from poDCDetail  where nomorpo=" & nomorpo)
                Conn.Execute("Delete from podcheader  where nomorpo=" & nomorpo)
                Conn.Execute("Delete from upodcdetail where nomorupo=" & nomorponew)
                Conn.Execute("Insert into UpoDcDetail select * from UpoDcDetailTMP where qtyupo > 0 and nomorupo=" & nomorponew & " and idsupplier=" & IdSupplier)
                Conn.Execute("exec spUpoDcHeader 'add'," & IdDC & "," & nomorponew & ",2,'2017-01-01',1,1,1,1,1,1,'" & StrNamaUser & "'")


                sql = "exec spUpoDcDetailtmp 'Hitung'," & IdDC & "," & nomorponew & "," & idProduk & "," & IdSupplier & ",'x',0,0,0,0,0,0,0,0," & qtykoreksi & ",0,0,0,0,0,0,'x'"
                RsConfig = Conn.Execute(sql)
                If Not RsConfig.EOF Then
                    sql = "exec spPoDcHeader 'AddManual', " & IdDC & "," & nomorponew & "," & nomorpo & "," & IdSupplier & ",'" & Format(TglPO.Value, "yyyy-MM-dd") & "','" & Format(TglExpired.Value, "yyyy-MM-dd") & "','" & Format(TglExpired.Value, "yyyy-MM-dd") & "'," & _
                          RsConfig("ttlitem").Value & "," & RsConfig("ttlqty").Value & "," & RsConfig("total").Value & "," & RsConfig("diskon").Value & "," & RsConfig("pajak").Value & "," & RsConfig("subtotal").Value & ",'" & StrNamaUser & "'," & Val(TxtExtTime.Text) & ",'" & txtketerangan.Text & "'," & parsial
                    Conn.Execute(sql)
                End If

                sql = "exec spUpoDcDetailtmp 'Get'," & IdDC & "," & nomorponew & "," & idProduk & "," & IdSupplier & ",'x',0,0,0,0,0,0,0,0," & qtykoreksi & ",0,0,0,0,0,0,'x'"
                RsConfig = Conn.Execute(sql)
                If Not RsConfig.EOF Then
                    RsConfig.MoveFirst()
                    Do While Not RsConfig.EOF
                        Conn.Execute("exec spPoDcDetail 'Add'," & IdDC & "," & nomorponew & "," & nomorpo & "," & _
                                      RsConfig("idproduk").Value & "," & RsConfig("qtyupo").Value & "," & RsConfig("hargaBeliTerakhir").Value & "," & _
                                      RsConfig("disk1").Value & "," & RsConfig("disk2").Value & ",0,0,0,0," & RsConfig("rpupo").Value & "," & RsConfig("pajak").Value & "," & RsConfig("subtotal").Value)
                        RsConfig.MoveNext()
                    Loop
                End If


            End If

            Conn.Execute("Delete from UpoDCDetailTmp  where nomorupo=" & nomorponew & " and idsupplier=" & IdSupplier)
            Conn.Execute("Delete from UpoDCDetailtmp  where nomorupo=" & nomorupo)

            Call pesan(3)
            TxtNoFaktur.Text = nomorpo
            BtnApproval.Enabled = True
            BtnEdit.Enabled = True
            BtnSimpan.Enabled = False
            BtnCancel.Enabled = False
            BtnAdd.Enabled = True
            Panel1.Enabled = True
            Panel2.Enabled = False
            btnFindNoPO.Enabled = True
            BtnFindSupplier.Enabled = False
            TglExpired.Enabled = False
            btnUpdHarga.Enabled = False
            txtketerangan.ReadOnly = True
            cbpartial.Enabled = False
            TxtExtTime.ReadOnly = True
        Else
            Exit Sub
        End If
        flagadd = False
        TglExpired.MinDate = "2017-07-07"

    End Sub

    Private Sub BtnApproval_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnApproval.Click
        If Conn.State = 0 Then
            Call GetStringKoneksi()
            Conn.Open(StrKoneksi)
        End If
        Dim result2 As DialogResult = MessageBox.Show("Apakah PO mau di approve ??", _
                "Question", _
                MessageBoxButtons.YesNo, _
                MessageBoxIcon.Question)
        If result2 = DialogResult.Yes Then

            boleh = FrmValidasi.cari("PO")
            ' boleh = True
            If boleh = True Then
                sql = "exec  sppodcheader 'approve'," & IdDC & "," & nomorponew & "," & nomorpo & "," & IdSupplier & ",'" & Format(TglPO.Value, "yyyy-MM-dd") & "','" & Format(TglExpired.Value, "yyyy-MM-dd") & "','" & Format(TglExpired.Value, "yyyy-MM-dd") & "',0,0,0,0,0,0,'" & StrNamaUser & "',0,'ket',1"
                Conn.Execute(sql)
                MsgBox("PO berhasil di approval", vbOKOnly + vbInformation, "Info")

                BtnEdit.Enabled = False
                BtnSimpan.Enabled = False
                BtnApproval.Enabled = False
                btnUpdHarga.Enabled = False
                BtnPrint.Enabled = True
                TglExpired.Enabled = False
                BtnCancel.Enabled = False
            Else
                MsgBox("Password yang anda masukkan salah !!" & vbCrLf _
                      & "Anda tidak berhak merubah data..", vbOKOnly + vbCritical, "Warning !!")
                Exit Sub
            End If

        Else
            Exit Sub
        End If
    End Sub

    Private Sub btnFindNoPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindNoPO.Click
        Conn.Execute("delete from upoDcDetailTmp  where nomorupo=" & nomorponew)
        Call bersih()

        TxtNoFaktur.Text = FrmFind.cari("NomorPOManual")
        If TxtNoFaktur.Text = "0" Then
            TxtNoFaktur.Text = ""
            BtnPrint.Enabled = False
            Call LoadData()
            Exit Sub
        Else
            flagadd = False
            nomorpo = TxtNoFaktur.Text
            sql = "exec  sppodcheader 'get'," & IdDC & "," & nomorupo & "," & nomorpo & "," & IdSupplier & ",'2017-01-01','2017-01-01','2017-01-01',0,0,0,0,0,0,'" & StrNamaUser & "',0,'ket',1"
            RsConfig = Conn.Execute(sql)
            If Not RsConfig.EOF Then
                IdSupplier = RsConfig("idsupplier").Value
                nomorponew = RsConfig("nomorupo").Value
                'TxtBuyer.Text = RsConfig("iduser").Value
                TxtKodeSupplier.Text = RsConfig("kodesupplier").Value
                TxtNamaSupplier.Text = RsConfig("namasupplier").Value
                TglExpired.Value = RsConfig("tglexpiredpo").Value
                TglPO.Value = RsConfig("tglpo").Value
                txtketerangan.Text = RsConfig("keterangan").Value & ""
                TxtExtTime.Text = RsConfig("exttime").Value & ""
                dibuat = RsConfig("namauser").Value
                termOP = RsConfig("termoffpayment").Value
                cbpartial.Checked = RsConfig("partialPO").Value

                If IsDBNull(RsConfig("exttime").Value) Then
                    TxtExtTime.Text = "0"
                Else
                    TxtExtTime.Text = RsConfig("exttime").Value
                End If

                If IsDBNull(RsConfig("tglapprove").Value) Then
                    TglProses.Value = Now
                Else
                    TglProses.Value = Format(RsConfig("tglapprove").Value, "yyyy-MM-dd ,HH:mm:ss")
                End If

                If RsConfig("statusdata").Value = 0 Then

                    If RsConfig("tglexpiredpo").Value <= Format(Now, "yyyy-MM-dd") Then
                        BtnEdit.Enabled = False
                        BtnApproval.Enabled = False
                        BtnPrint.Enabled = False
                        btnUpdHarga.Enabled = True
                    Else
                        BtnEdit.Enabled = True
                        BtnApproval.Enabled = True
                        BtnPrint.Enabled = False
                        btnUpdHarga.Enabled = False
                    End If
                ElseIf RsConfig("statusdata").Value = 1 Or RsConfig("statusdata").Value = 2 Then
                    If RsConfig("tglexpiredpo").Value <= Format(Now, "yyyy-MM-dd") Then
                        BtnEdit.Enabled = False
                        BtnApproval.Enabled = False
                        BtnPrint.Enabled = True
                        btnUpdHarga.Enabled = True
                    Else
                        BtnEdit.Enabled = False
                        BtnApproval.Enabled = False
                        BtnPrint.Enabled = True
                        btnUpdHarga.Enabled = False
                    End If
                End If

                Call getSupplier(TxtKodeSupplier.Text)
                TxtPKP.Text = PKP

                sql = "Select a.idpajak,namapajak from mstproduk a " & _
                          " inner join mstpajak b on a.idpajak=b.idpajak  where idproduk in ( select idproduk from podcdetail where nomorpo=" & nomorpo & ")"
                RsConfig = Conn.Execute(sql)
                Call copytmp()

            End If
        End If
    End Sub
    Private Sub copytmp()

        Conn.Execute("delete from poDcDetailTmp  where nomorpo=" & nomorpo)
        Conn.Execute("delete from upoDcDetailTmp  where nomorupo=" & nomorponew)
        sql = "exec spUpoDcDetailtmp 'Edit'," & IdDC & "," & nomorponew & ",0,0,'x',0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,'x'"
        Conn.Execute(sql)
        RsConn = Conn.Execute("Select * from upoDcDetailTmp where nomorupo=" & nomorponew)
        If Not RsConn.EOF Then
            nomorUPO = RsConn("nomorupo").Value
            Call LoadData()
            Call hitung()
        Else
            MsgBox("Terdapat kesalahan pada data anda!! Silahkan Hubungi IT administrator..", vbOKOnly + vbInformation, "Info")
            Exit Sub
        End If

    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        BtnAdd.Enabled = False
        BtnEdit.Enabled = False
        BtnSimpan.Enabled = True
        BtnCancel.Enabled = True
        BtnApproval.Enabled = False
        TglExpired.Enabled = True
        btnFindNoPO.Enabled = False
        BtnFindSupplier.Enabled = False
        Panel2.Enabled = True
        btnUpdHarga.Enabled = False
        txtketerangan.ReadOnly = False
        cbpartial.Enabled = True
        copytmp()

    End Sub

    Private Sub TxtKodeSupplier_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtKodeSupplier.TextChanged
        sql = "select * from mstsupplierperdc where iddc= " & IdDC & " and idsupplier=" & IdSupplier
        RsConn = Conn.Execute(sql)
        If Not RsConn.EOF Then
            alamatsupplier = RsConn("alamatsupplier").Value
            telpsupplier = RsConn("noTelephone").Value
        End If

    End Sub

   
    Private Sub btnUpdHarga_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdHarga.Click
        If Conn.State = 0 Then
            Call GetStringKoneksi()
            Conn.Open(StrKoneksi)
        End If
        sql = "exec  sppodcheader 'cekdata'," & IdDC & "," & nomorponew & "," & nomorpo & "," & IdSupplier & ",'2017-01-01','2017-01-01','" & Format(TglExpired.Value, "yyyy-MM-dd") & "'," & Val(TxtExtTime.Text) & ",0,0,0,0,0,'" & StrNamaUser & "'," & Val(TxtExtTime.Text) & ",'" & keterangan & "',1"
        RsConn = Conn.Execute(sql)
        If RsConn("totalqty").Value > 0 Then
            Call copypo()
            boleh = False
        Else
            MsgBox("Item produk sudah terpenuhi semua!!" & vbCrLf _
                  & "silahkan cek No PO yang lain ", vbOKOnly + vbInformation, "Info")
            Exit Sub
        End If

    End Sub
    Private Sub copypo()
        Dim objConn As OleDbConnection
        Dim objCmd As OleDbCommand
        Dim objReader As OleDbDataReader
        Dim objDataSet As DataSet = New DataSetPO
        Dim strSQL, strCONN As String
        Dim nox As Int64

        GetStringKoneksi() '---1
        strCONN = StrKoneksi '----2

        keterangan = "PO Copy dari :" & nomorpo
        strSQL = "exec  sppodcheader 'CopyOUT'," & IdDC & "," & nomorponew & "," & nomorpo & "," & IdSupplier & ",'2017-01-01','2017-01-01','" & Format(TglExpired.Value, "yyyy-MM-dd") & "'," & Val(TxtExtTime.Text) & ",0,0,0,0,0,'" & StrNamaUser & "'," & Val(TxtExtTime.Text) & ",'" & keterangan & "',1"

        objConn = New OleDbConnection(strCONN)
        objCmd = New OleDbCommand(strSQL, objConn)
        objCmd.CommandType = CommandType.Text
        objCmd.Connection.Open()
        objCmd.CommandTimeout = 0
        objReader = objCmd.ExecuteReader

        Do While objReader.Read()
            nox = objReader(2)
            MsgBox("PO berhasil di copy dengan nomor PO Baru = " & nox & " , silahkan ke menu PO Manual", vbOKOnly + vbInformation, "Sukses Copy PO")
        Loop
        objReader.Close()
        objConn.Close()
    End Sub
    Private Sub updateharga()
        Conn.Execute("exec spPoDcDetailTmp 'UpdHarga'," & IdDC & "," & TxtNoFaktur.Text & ",0,0,0,0,0,0,0,0")
    End Sub

    Private Sub TxtExtTime_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtExtTime.KeyDown
        If e.KeyCode = Keys.Enter Then
            If cbpartial.Checked = True Then
                If Val(TxtExtTime.Text) <= 0 Then
                    Dim result2 As DialogResult = MessageBox.Show("Extended Time PO Belum di isi !!!  , apakah yakin akan di lanjutkan ??", _
                  "Question", _
                  MessageBoxButtons.YesNo, _
                  MessageBoxIcon.Question)
                    If result2 = DialogResult.Yes Then
                        Panel2.Enabled = True
                        cbpartial.Focus()

                    Else
                        TxtExtTime.Focus()
                        TxtExtTime.SelectAll()
                        Exit Sub
                    End If

                End If
            End If
        End If
    End Sub
    Private Sub TxtExtTime_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtExtTime.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(Keys.Back))
    End Sub

    Private Sub txtketerangan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtketerangan.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtketerangan.Text = "" Then
                Dim result2 As DialogResult = MessageBox.Show("Anda belum mengisi keterangan atas PO manual, Apakah ingin dilanjutkan ??", _
              "Question", _
              MessageBoxButtons.YesNo, _
              MessageBoxIcon.Question)
                If result2 = DialogResult.Yes Then
                    TxtExtTime.Focus()
                    TxtExtTime.SelectAll()

                Else
                    txtketerangan.Focus()
                    txtketerangan.SelectAll()
                    Exit Sub
                End If
            Else
                TxtExtTime.Focus()
                TxtExtTime.SelectAll()
            End If
        End If
    End Sub

    Private Sub txtketerangan_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtketerangan.KeyPress
        If (e.KeyChar Like "[',]") Then e.Handled() = True
    End Sub

    Private Sub txtKodeProduk_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtKodeProduk.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtKodeProduk.Text = "" Then Exit Sub
            getNamaProduk(txtKodeProduk.Text, IdSupplier)
            If idProduk > 0 Then
                txtNamaProduk.Text = NamaProduk
                txtPrice.Text = Format(harga, "#,##0.#0")
                txtqty.Focus()
            Else
                MsgBox("Kode produk tidak terdaftar !!", vbOKOnly + vbCritical, "Info")
                Exit Sub
                txtKodeProduk.SelectAll()
                txtKodeProduk.Focus()
            End If
        End If
    End Sub

    Private Sub txtKodeProduk_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKodeProduk.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(Keys.Back))
    End Sub


    Private Sub cbpartial_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbpartial.CheckedChanged
        If cbpartial.Checked = True And cbpartial.Enabled = True Then
            parsial = 1
            TxtExtTime.ReadOnly = False
            TxtExtTime.Focus()
        ElseIf cbpartial.Checked = True And cbpartial.Enabled = False Then
            parsial = 1
            TxtExtTime.ReadOnly = True
            TxtExtTime.Focus()
        Else
            parsial = 0
            TxtExtTime.ReadOnly = True
            TxtExtTime.Text = 0
        End If
    End Sub

    Private Sub TxtNoFaktur_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNoFaktur.TextChanged

    End Sub
End Class