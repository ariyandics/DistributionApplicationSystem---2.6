Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Data.OleDb
Public Class FrmTOfromPB
    Dim sql As String
    Dim conn As New ADODB.Connection
    Dim RsConn As New ADODB.Recordset
    Dim barcode, plu As String
    Dim qty, qtyctn, harga, pajak, subtotal, disk1, disk2, netto As Double
    Dim flagadd, flagedit As Boolean
    Dim strBarcode, strplu, strnamabarang, kepala As String
    Dim noUrut, strqty, noPB, noPL, qtypl As Int64
    Dim strharga, strppn, strnetto As Double
    Dim ttlqty, ttlitem, ttlvalue, ttlpajak, ttlnett As Double
    Dim flaghasil As Boolean
    Dim nomortox As Int64


    Private Sub FrmTOfromPB_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        BtnFindNoFaktur.Focus()
    End Sub

    Private Sub FrmTOfromPB_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Call deletetmp()
        Call hapustmp()
        nomorTO = 0
    End Sub
    Private Sub hapustmp()

        sql = "exec spTblTOTmp 'Delete',1," & kodetoko & ",0,0," & nomortox & ",'" & StrNamaUser & "'"
        RsConn = conn.Execute(sql)

    End Sub
    Private Sub FrmTOfromPB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Panel1.BackColor = Color.DeepSkyBlue
       
        Call GbrTombol()
        Call bersih()
        Call kuncix()
        Call cektemp()
        Call loaddata()
    End Sub

    Private Sub cektemp()
        sql = "exec spTblTOTmp 'GetTO',1,0,0,0,0,'" & StrNamaUser & "'"
        RsConn = conn.Execute(sql)

        If Not RsConn.EOF Then
            Dim result2 As DialogResult = MessageBox.Show("Masih Ada data yang belum selesai ....!!" & vbCrLf _
                                                              & "Mau dilanjutkan ?", "Question !!", _
            MessageBoxButtons.YesNo, _
            MessageBoxIcon.Question)
            If result2 = DialogResult.Yes Then
                txtNoFaktur.Text = FrmFind.cari("NoTObyPBTMP")
                nomorTO = txtNoFaktur.Text
                txtuser.Text = StrNamaUser

                sql = "exec spTblTOTmp 'GetTO',1,0,0,0," & nomorTO & ",'" & StrNamaUser & "'"
                RsConfig = conn.Execute(sql)
                If Not RsConfig.EOF Then
                    txtNoPL.Text = RsConfig("nomorpicking").Value
                    NomorPB = RsConfig("nomorpb").Value
                    txtuser.Text = RsConfig("iduser").Value
                    TxtKodetoko.Text = RsConfig("kodetoko").Value
                    txtnamatoko.Text = RsConfig("namatoko").Value
                    txtTglBuat.Text = Format(Now, "dd-MM-yyyy")

                    'sql = "Select * from  ToKeTokoHeader  where nomorto=" & nomorTO & " and kodetoko=" & kodetoko
                    'RsConfig = conn.Execute(sql)
                    'If Not RsConfig.EOF Then
                    '    txtNoPL.Text = RsConfig("nomorpicking").Value
                    '    NomorPB = RsConfig("nomorpb").Value
                    '    txtuser.Text = RsConfig("iduser").Value
                    '    txtTglBuat.Text = Format(RsConfig("TglTO").Value, "dd-MM-yyyy")
                    Call tombol()
                    txtBarcode.ReadOnly = False
                    txtBarcode.Enabled = True
                    txtnamabarang.Enabled = True
                    txtBarcode.Focus()
                    BtnCancel.Enabled = True
                    BtnSave.Enabled = True

                    If Val(nomorTO) < 2000000 Then
                        flagadd = True
                        flagedit = False
                    Else
                        flagedit = True
                        flagadd = False
                    End If
                    Call loaddata()
                    Call hitung()
                End If

            End If
        End If


    End Sub

    Private Sub GbrTombol()
        Me.BtnAdd.Image = System.Drawing.Image.FromFile(icoadd)
        Me.BtnApproval.Image = System.Drawing.Image.FromFile(icoapprove)
        Me.BtnEdit.Image = System.Drawing.Image.FromFile(icoedit)
        Me.BtnCancel.Image = System.Drawing.Image.FromFile(icocancel)
        Me.BtnSave.Image = System.Drawing.Image.FromFile(icosave)
        Me.BtnPrint.Image = System.Drawing.Image.FromFile(icoprint)

    End Sub

    Private Sub kuncix()
        txtBarcode.Enabled = False
        txtnamabarang.Enabled = False
        txtqty.Enabled = False
    End Sub
    Private Sub bersih()
        flagadd = False
        flagedit = False
        nomorTO = 0
        BtnAdd.Text = "&Add"
        txtNoFaktur.Clear()
        TxtKodetoko.Clear()
        txtnamatoko.Clear()
        txtuser.Clear()
        txtTglBuat.Clear()
        txtNoPL.Clear()
        txtTglApprove.Clear()

        txtNoFaktur.ReadOnly = True
        TxtKodetoko.ReadOnly = True
        txtnamatoko.ReadOnly = True
        txtuser.ReadOnly = True
        txtTglBuat.ReadOnly = True
        txtNoPL.ReadOnly = True
        txtTglApprove.ReadOnly = True
        txtNoFaktur.BackColor = Color.White
        TxtKodetoko.BackColor = Color.White
        txtnamatoko.BackColor = Color.White
        txtuser.BackColor = Color.White
        txtTglBuat.BackColor = Color.White
        txtNoPL.BackColor = Color.White
        txtTglApprove.BackColor = Color.White

        txtnamabarang.Clear()
        txtBarcode.Clear()
        txtqty.Clear()

        txtnamabarang.ReadOnly = True
        txtBarcode.ReadOnly = True
        txtqty.ReadOnly = True
        txtBarcode.BackColor = Color.White
        txtnamabarang.BackColor = Color.White
        txtqty.BackColor = Color.White

        TxtTotalItem.Clear()
        TxtTotalQty.Clear()
        TxtTotalValue.Clear()
        TxtTotalPPN.Clear()

        TxtTotalItem.ReadOnly = True
        TxtTotalQty.ReadOnly = True
        TxtTotalValue.ReadOnly = True
        TxtTotalPPN.ReadOnly = True
        TxtTotalItem.BackColor = Color.White
        TxtTotalQty.BackColor = Color.White
        TxtTotalValue.BackColor = Color.White
        TxtTotalPPN.BackColor = Color.White

        BtnAdd.Enabled = True
        BtnApproval.Enabled = False
        BtnEdit.Enabled = False
        BtnCancel.Enabled = False
        BtnSave.Enabled = False
        BtnPrint.Enabled = False
        CBLock.Checked = True
        CBLock.Enabled = False
        BtnFindNoPL.Enabled = False
        BtnFindNoFaktur.Enabled = True
        Panel1.Enabled = True
    End Sub

    Private Sub loaddata()
        Listview2.Columns.Clear()
        Listview2.Items.Clear()
        Listview2.View = Windows.Forms.View.Details
        Listview2.GridLines = True
        Listview2.FullRowSelect = True


        Listview2.Columns.Add("No", 50)
        Listview2.Columns.Add("Barcode", 100)
        Listview2.Columns.Add("SKU", 70)
        Listview2.Columns.Add("Description", 270)
        Listview2.Columns.Add("Qty", 80, HorizontalAlignment.Right)
        Listview2.Columns.Add("Price", 90, HorizontalAlignment.Right)
        Listview2.Columns.Add("PPN", 70, HorizontalAlignment.Right)
        Listview2.Columns.Add("Total", 110, HorizontalAlignment.Right)


        If flagadd = True Or flagedit = True Then
            sql = "exec spToKeTokoDetailTMP 'get'," & IdDC & "," & kodetoko & ",0,0," & nomorTO & ",0,0,0,0,0,0,0"
        Else
            sql = "exec spToKeTokoDetail 'GetTmp'," & IdDC & "," & kodetoko & ",0,0," & nomorTO & ",0,0,0,0,0,0,0"
        End If
        RsConn = conn.Execute(sql)



        If Not RsConn.EOF Then
            RsConn.MoveFirst()
            noUrut = 1
            Do While Not RsConn.EOF
                strBarcode = RsConn("barcode").Value
                strplu = RsConn("kodeproduk").Value
                strnamabarang = RsConn("namapanjang").Value
                strqty = RsConn("qtyTO").Value
                strharga = RsConn("hpptoko").Value - RsConn("pajak").Value
                strppn = RsConn("pajak").Value
                strnetto = RsConn("subtotal").Value

                Dim arr(8) As String
                Dim itm As ListViewItem

                arr(0) = noUrut
                arr(1) = strBarcode
                arr(2) = strplu
                arr(3) = strnamabarang
                arr(4) = strqty.ToString("N")
                arr(5) = strharga.ToString("N")
                arr(6) = strppn.ToString("N")
                arr(7) = strnetto.ToString("N")



                itm = New ListViewItem(arr)
                Listview2.Items.Add(itm)
                noUrut = noUrut + 1
                RsConn.MoveNext()

            Loop

        End If

        ' Listview2.OwnerDraw = True

        RsConn.Close()
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click

        If BtnAdd.Text = "&Add" Then
            Call bersih()
            BtnAdd.Text = "Scan"
            flagadd = True
            BtnCancel.Enabled = True
            BtnFindNoFaktur.Enabled = False
            BtnFindNoPL.Enabled = True
            Panel1.Enabled = True
            txtuser.Text = StrNamaUser
            txtTglBuat.Text = Format(Now, "dd-MM-yyyy")

            Call cektable()
            Call getnomor()
            Call loaddata()
            BtnFindNoPL.Focus()

        Else
            If txtnamatoko.Text <> "" Then
                BtnAdd.Text = "&Add"
                txtBarcode.ReadOnly = False
                txtBarcode.Enabled = True
                txtnamabarang.Enabled = True
                txtBarcode.Focus()
                Panel1.Enabled = False
                BtnAdd.Enabled = False
                CBLock.Checked = False
                CBLock.Enabled = True
                Call simpantbltmp()

            Else
                MsgBox("Anda belum memilih Toko !!!", vbOKOnly + vbInformation, "Info")
                Exit Sub
            End If
        End If
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        nomortox = txtNoFaktur.Text
        Call hapustmp()
        Call deletetmp()
        Call tombol()

        If flagadd = True Then
            Call bersih()
            BtnAdd.Focus()
        ElseIf flagedit = True Then
            BtnAdd.Enabled = True
            Panel1.Enabled = True
            BtnEdit.Enabled = True
            BtnApproval.Enabled = True
            flagedit = False
        Else
            BtnAdd.Enabled = True
        End If
        Call loaddata()
    End Sub
    Private Sub deletetmp()
        conn.Execute("delete from ToKeTokoDetailTMP where nomorTO=" & nomorTO)
    End Sub

    Private Sub getnomor()

        sql = "Select isnull(max(nomorTO),0 )as nomor from ToKeTokoDetailTMP"
        RsConfig = conn.Execute(sql)
        If RsConfig("nomor").Value > 0 Then
            nomorTO = RsConfig("nomor").Value + 1
        Else
            nomorTO = 1
        End If

        sql = "exec spToKeTokoDetailTMP 'add'," & IdDC & "," & kodetoko & ",0,0," & nomorTO & ",0,0,0,0,0,0,0"
        conn.Execute(sql)
        txtNoFaktur.Text = nomorTO
    End Sub
    Private Sub cektable()
        sql = "Select TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='ToKeTokoDetailTMP'"
        RsConfig = conn.Execute(sql)
        If RsConfig.EOF Then
            sql = "select top 0 * into ToKeTokoDetailTMP from ToKeTokoDetail "
            conn.Execute(sql)
        End If

    End Sub

    Private Sub BtnFindNoPL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFindNoPL.Click
        TxtKodetoko.Text = ""
        txtnamatoko.Text = ""
        txtNoPL.Text = ""
        Call loaddata()

        txtNoPL.Text = FrmFind.cari("NoPL")


        If txtNoPL.Text = "0" Then
            txtNoPL.Text = ""
            Exit Sub
        End If

        noPL = txtNoPL.Text
        TxtKodetoko.Text = kodetoko
    End Sub

    Private Sub txtNoFaktur_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNoFaktur.TextChanged
        If txtNoFaktur.Text = "0" Then txtNoFaktur.Text = ""
        If txtNoFaktur.Text = "" Then Exit Sub
        nomorTO = Val(txtNoFaktur.Text)
    End Sub

    Private Sub txtBarcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBarcode.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtBarcode.Text = "" Then
                MsgBox("Anda belum Input Barcode produk !!!", vbOKOnly + vbInformation, "Info")
                txtBarcode.SelectAll()
                txtBarcode.Focus()
                Exit Sub
            Else
                scan(txtBarcode.Text)
                If idProduk > 0 Then
                    txtnamabarang.Text = NamaProduk

                    Call cekpl()
                    If flaghasil = False Then
                        MsgBox("Produk ini tidak dipesan oleh Toko..!!", vbOKOnly + vbInformation)
                        txtBarcode.Clear()
                        txtnamabarang.Clear()
                        txtBarcode.Focus()
                        Exit Sub

                    End If


                    If CBLock.Checked = True Then
                        txtqty.Text = 1
                        Call simpanTmp()
                        Call loaddata()
                        txtBarcode.Clear()
                        txtnamabarang.Clear()
                        BtnSave.Enabled = True
                    Else
                        txtqty.Enabled = True
                        txtqty.ReadOnly = False
                        txtqty.Text = ""
                        txtqty.Focus()
                    End If

                Else
                    MsgBox("Produk tidak bisa di TO ke toko tujuan..!!", vbOKOnly + vbCritical, "Info")
                    txtBarcode.Clear()
                    txtnamabarang.Clear()
                    txtBarcode.Focus()
                    Exit Sub
                End If


            End If

           

        End If

    End Sub

    Private Sub txtBarcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBarcode.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(Keys.Back))
    End Sub

    Private Sub cekpl()
        sql = "exec spToKeTokoDetailTMP 'getPL'," & IdDC & "," & kodetoko & "," & NomorPB & "," & txtNoPL.Text & "," & nomorTO & "," & idProduk & ",0,0,0,0," & qty & ",0"
        RsConfig = conn.Execute(sql)
        If Not RsConfig.EOF Then
            flaghasil = True
            qtypl = RsConfig("qtypicking").Value
        Else
            flaghasil = False
        End If
    End Sub
    Private Sub simpanTmp()
        sql = "exec spToKeTokoDetailTMP 'getid'," & IdDC & "," & kodetoko & "," & NomorPB & "," & txtNoPL.Text & "," & nomorTO & "," & idProduk & ",0,0,0,0," & qty & ",0"
        RsConfig = conn.Execute(sql)

        If CBLock.Checked = True Then
            If Not RsConfig.EOF Then
                qty = RsConfig("qtyto").Value + 1
            Else
                qty = 1
            End If
        End If

        If qty > qtypl Then
            ' MsgBox("Qty TO tidak boleh melebihi Qty PB !!!", vbOKCancel + vbCritical, "Peringatan")
            FrmError.ShowDialog()
            Exit Sub
        End If


        sql = "exec spMutasiSaldoHeaderDetail 'GetStockGS'," & IdDC & ",'" & StrNamaUser & "','xxx',1," & idProduk & "," & qty & ",'ket','BA'"
        RsConn = conn.Execute(sql)

        If RsConn("hpp").Value <= 0 Then
            MsgBox("Hpp masih 0(nol) !!!", vbOKOnly + vbInformation, "Info")
            txtqty.SelectAll()
            txtqty.Focus()
            Exit Sub
        ElseIf RsConn("qty").Value < qty Then
            MsgBox("Stock hanya tersedia " & Format(RsConn("qty").Value, "#,##0") & " !!!", vbOKOnly + vbInformation, "Info")
            txtqty.SelectAll()
            txtqty.Focus()
            Exit Sub
        End If

        sql = "Select harga from msthargabyjenislokasi where harga=0 and idproduk=" & idProduk & " and kodejenislokasi='" & kodejnslokasi & "'"
        RsConn = conn.Execute(sql)
        If Not RsConn.EOF Then
            MsgBox("Harga Jual anda masih 0(nol) !!!", vbOKOnly + vbInformation, "Info")
            txtBarcode.SelectAll()
            txtBarcode.Focus()
            Exit Sub
        End If




        sql = "exec spToKeTokoDetailTMP 'add'," & IdDC & "," & kodetoko & "," & NomorPB & "," & txtNoPL.Text & "," & nomorTO & "," & idProduk & ",0,0,0," & IdPajak & "," & qty & ",0"
        conn.Execute(sql)
        Call hitung()

    End Sub

    Private Sub txtqty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtqty.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtBarcode.Text = "" Then
                MsgBox("Anda belum Input Barcode produk !!!", vbOKOnly + vbInformation, "Info")
                txtBarcode.SelectAll()
                txtBarcode.Focus()
                Exit Sub
            End If
            BtnSave.Enabled = True
            Call simpanTmp()
            Call loaddata()
            CBLock.Checked = False
            txtnamabarang.Clear()
            txtBarcode.Clear()
            txtBarcode.Focus()
            txtqty.Text = 1
        End If
    End Sub

    Private Sub txtqty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtqty.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or ".".Contains(e.KeyChar) Or e.KeyChar = Chr(Keys.Back))
    End Sub

    Private Sub txtqty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtqty.TextChanged
        If txtqty.Text = "" Then Exit Sub
        qty = txtqty.Text
        txtqty.Text = Format(qty, "#,##0.##")
        txtqty.SelectionStart = Len(txtqty.Text)
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Call simpan()
    End Sub
    Private Sub simpan()
        Dim result2 As DialogResult = MessageBox.Show("Simpan data TO  ??", _
               "Question !!", _
               MessageBoxButtons.YesNo, _
               MessageBoxIcon.Question)
        If result2 = DialogResult.Yes Then
            nomortox = txtNoFaktur.Text
            Call tombol()
            If flagadd = True Then
                RsConfig = conn.Execute("select  dbo.fcGetNomorTObyPB(" & IdDC & ") xx")
                nomorTO = RsConfig("xx").Value

                conn.Execute("update ToKeTokoDetailTMP set nomorto=" & nomorTO & " where nomorto=" & txtNoFaktur.Text)

                sql = "exec spToKeTokoHeader 'add'," & IdDC & "," & kodetoko & "," & NomorPB & "," & noPL & "," & nomorTO & "," & ttlitem & "," & ttlqty & "," & Replace(ttlvalue, ",", ".") & "," & Replace(ttlpajak, ",", ".") & "," & Replace(ttlnett, ",", ".") & ",0,'" & StrNamaUser & "'"
                conn.Execute(sql)

                txtNoFaktur.Text = nomorTO
            ElseIf flagedit = True Then
                conn.Execute("exec spToKeTokoHeader 'edit'," & IdDC & "," & kodetoko & "," & NomorPB & "," & txtNoPL.Text & "," & nomorTO & "," & ttlitem & "," & ttlqty & "," & Replace(ttlvalue, ",", ".") & "," & Replace(ttlpajak, ",", ".") & "," & Replace(ttlnett, ",", ".") & ",0,'" & txtuser.Text & "'")
            End If
            Call hapustmp()
            Call pesan(3)
            txtBarcode.Clear()
            txtnamabarang.Clear()
            flagadd = False
            flagedit = False
            Panel1.Enabled = True
            BtnFindNoFaktur.Enabled = True
            BtnFindNoPL.Enabled = False
            BtnAdd.Enabled = True
            BtnEdit.Enabled = True
            BtnApproval.Enabled = True
        Else
            Exit Sub
        End If
    End Sub

    Private Sub BtnApproval_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnApproval.Click
        Dim result2 As DialogResult = MessageBox.Show("Approve data TO ??", _
             "Question !!", _
             MessageBoxButtons.YesNo, _
             MessageBoxIcon.Question)
        If result2 = DialogResult.Yes Then

            'cek stok 
            sql = "exec spToKeTokoDetail 'GetStok'," & IdDC & "," & kodetoko & "," & NomorPB & "," & txtNoPL.Text & "," & nomorTO & "," & idProduk & ",0,0,0,0," & qty & ",0"
            RsConfig = conn.Execute(sql)
            If Not RsConfig.EOF Then
                RsConfig.MoveFirst()
                MsgBox("Stock " & RsConfig("namapanjang").Value & " tidak mencukupi!!!", vbOKOnly + vbCritical, "Gagal Approve")
                Exit Sub
            Else
                Call tombol()

                If conn.State = 0 Then
                    GetStringKoneksi()
                    conn.Open(StrKoneksi)
                End If

                sql = "exec spToKeTokoHeader 'Approve'," & IdDC & "," & kodetoko & "," & NomorPB & "," & txtNoPL.Text & "," & nomorTO & ",0,0,0,0,0,1,'" & txtuser.Text & "'"
                conn.Execute(sql)
                MsgBox("Approval berhasil!!", vbOKOnly + vbInformation, "Info")
                txtTglApprove.Text = Format(Now, "dd-MM-yyyy")

                BtnPrint.Enabled = True
                BtnAdd.Enabled = True
                Panel1.Enabled = True
                BtnFindNoPL.Enabled = False
                BtnFindNoFaktur.Enabled = True
            End If
        End If
    End Sub
    Private Sub hitung()
        If flagadd = True Or flagedit = True Then
            sql = "exec spToKeTokoDetailTMP 'Hitung'," & IdDC & "," & kodetoko & "," & NomorPB & "," & txtNoPL.Text & "," & nomorTO & "," & idProduk & ",0,0,0," & IdPajak & "," & qty & ",0"
        ElseIf flagadd = False And flagedit = False Then
            sql = "exec spToKeTokoDetail 'Hitung'," & IdDC & "," & kodetoko & "," & NomorPB & "," & txtNoPL.Text & "," & nomorTO & "," & idProduk & ",0,0,0," & IdPajak & "," & qty & ",0"
        End If
        RsConfig = conn.Execute(sql)
        If Not RsConfig.EOF Then
            TxtTotalItem.Text = Format(RsConfig("ttlitem").Value, "#,##0.##")
            TxtTotalQty.Text = Format(RsConfig("ttlqty").Value, "#,##0.##")
            TxtTotalValue.Text = Format(RsConfig("ttlvalue").Value, "#,##0.##")
            TxtTotalPPN.Text = Format(RsConfig("ttlpajak").Value, "#,##0.##")

            ttlitem = RsConfig("ttlitem").Value
            ttlpajak = RsConfig("ttlpajak").Value
            ttlqty = RsConfig("ttlqty").Value
            ttlvalue = RsConfig("ttlvalue").Value
            ttlnett = ttlvalue - ttlpajak

        End If
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click

        sql = "exec spToKeTokoDetailTMP 'EditData'," & IdDC & "," & kodetoko & ",0,0," & nomorTO & ",0,0,0,0,0,0,0"
        conn.Execute(sql)
        Call tombol()
        BtnCancel.Enabled = True
        BtnSave.Enabled = True

        Panel1.Enabled = False
        txtBarcode.ReadOnly = False
        CBLock.Enabled = True
        flagedit = True
        txtBarcode.Enabled = True
        txtnamabarang.Enabled = True
        txtqty.Text = "1"
        Call simpantbltmp()

        txtBarcode.Focus()
    End Sub

    Private Sub simpantbltmp()
        sql = "exec spTblTOTmp 'Add',1," & kodetoko & "," & NomorPB & "," & txtNoPL.Text & "," & nomorTO & ",'" & StrNamaUser & "'"
        conn.Execute(sql)

    End Sub

    Private Sub BtnFindNoFaktur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFindNoFaktur.Click
        Call bersih()
        txtNoFaktur.Text = FrmFind.cari("NoTObyPB")
        Call tampildata()
    End Sub
    Private Sub tampildata()
        If Val(txtNoFaktur.Text) > 0 Then
            nomorTO = txtNoFaktur.Text
            sql = "Select * from  ToKeTokoHeader  where nomorto=" & nomorTO & " and kodetoko=" & kodetoko
            RsConfig = conn.Execute(sql)
            If Not RsConfig.EOF Then
                txtNoPL.Text = RsConfig("nomorpicking").Value
                NomorPB = RsConfig("nomorpb").Value
                txtuser.Text = RsConfig("iduser").Value
                txtTglBuat.Text = Format(RsConfig("TglTO").Value, "dd-MM-yyyy")
                If RsConfig("statusdata").Value > 0 Then
                    Call tombol()
                    BtnPrint.Enabled = True
                    txtTglApprove.Text = Format(RsConfig("Tglapprove").Value, "dd-MM-yyyy")
                Else
                    Call tombol()
                    BtnApproval.Enabled = True
                    BtnEdit.Enabled = True
                    BtnFindNoFaktur.Enabled = True
                End If
                BtnAdd.Enabled = True
                TxtKodetoko.Text = RsConfig("kodetoko").Value
                Call loaddata()
                Call hitung()
            End If
        Else
            Call bersih()
            Call loaddata()
        End If
    End Sub

    Private Sub TxtKodetoko_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtKodetoko.TextChanged
        If TxtKodetoko.Text = "" Then Exit Sub
        kodetoko = TxtKodetoko.Text
        gettoko(kodetoko)
        txtnamatoko.Text = namatoko
    End Sub

    Private Sub tombol()

        BtnAdd.Enabled = False
        BtnApproval.Enabled = False
        BtnEdit.Enabled = False
        BtnCancel.Enabled = False
        BtnSave.Enabled = False
        BtnPrint.Enabled = False

        txtBarcode.ReadOnly = True
        txtqty.ReadOnly = True
        CBLock.Enabled = False

    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        If statusToko = "R" Then
            kepala = "SURAT JALAN"
            Call cetakSJ()
        Else
            kepala = "DELIVERY ORDER"
            Call cetak()
            Call cetakSJ()
        End If
    End Sub

    Private Sub cetak()
        Dim objConn As OleDbConnection
        Dim objCmd As OleDbCommand
        Dim objReader As OleDbDataReader
        Dim objDataSet As DataSet = New DataSetPO
        Dim strSQL, strCONN As String

        GetStringKoneksi() '---1
        strCONN = StrKoneksi '----2

        strSQL = "exec spToKeTokoDetail 'GetTmp'," & IdDC & "," & kodetoko & ",0,0," & nomorTO & ",0,0,0,0,0,0,0"

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
        rds.Name = "DataSetTO"
        rds.Value = objDataSet.Tables(0)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPerusahaan", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", "BUKTI PENGIRIMAN BARANG", True))
        paramList.Add(New ReportParameter("KodeDC", kodedc, True))
        paramList.Add(New ReportParameter("NamaDC", namadc, True))
        paramList.Add(New ReportParameter("AlamatDC", alamatdc, True))
        paramList.Add(New ReportParameter("telpDC", telpdc, True))
        paramList.Add(New ReportParameter("Kodetoko", kodetoko, True))
        paramList.Add(New ReportParameter("NamaToko", namatoko, True))
        paramList.Add(New ReportParameter("AlamatToko", alamattoko, True))
        paramList.Add(New ReportParameter("TelpToko", telptoko, True))
        paramList.Add(New ReportParameter("NoFaktur", Me.txtNoFaktur.Text, True))
        paramList.Add(New ReportParameter("TtlItem", Me.TxtTotalItem.Text, True))
        paramList.Add(New ReportParameter("TtlQty", Me.TxtTotalQty.Text, True))
        paramList.Add(New ReportParameter("TtlPajak", Me.TxtTotalPPN.Text, True))
        paramList.Add(New ReportParameter("TtlValue", Me.TxtTotalValue.Text, True))


        Dim ReportViewerForm As New FrmReport
        ReportViewerForm.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptBPB.rdlc"
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewerForm.ReportViewer1.LocalReport.SetParameters(paramList)
        ReportViewerForm.ReportViewer1.RefreshReport()
        ReportViewerForm.Show()
    End Sub

    Private Sub cetakSJ()
        Dim objConn As OleDbConnection
        Dim objCmd As OleDbCommand
        Dim objReader As OleDbDataReader
        Dim objDataSet As DataSet = New DataSetPO
        Dim strSQL, strCONN As String

        GetStringKoneksi() '---1
        strCONN = StrKoneksi '----2

        strSQL = "exec spToKeTokoDetail 'GetTmp'," & IdDC & "," & kodetoko & ",0,0," & nomorTO & ",0,0,0,0,0,0,0"

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
        rds.Name = "DataSetTO"
        rds.Value = objDataSet.Tables(0)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPerusahaan", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", kepala, True))
        paramList.Add(New ReportParameter("KodeDC", kodedc, True))
        paramList.Add(New ReportParameter("NamaDC", namadc, True))
        paramList.Add(New ReportParameter("AlamatDC", alamatdc, True))
        paramList.Add(New ReportParameter("telpDC", telpdc, True))
        paramList.Add(New ReportParameter("Kodetoko", kodetoko, True))
        paramList.Add(New ReportParameter("NamaToko", namatoko, True))
        paramList.Add(New ReportParameter("AlamatToko", alamattoko, True))
        paramList.Add(New ReportParameter("TelpToko", telptoko, True))
        paramList.Add(New ReportParameter("NoFaktur", Me.txtNoFaktur.Text, True))
        paramList.Add(New ReportParameter("TtlItem", Me.TxtTotalItem.Text, True))
        paramList.Add(New ReportParameter("TtlQty", Me.TxtTotalQty.Text, True))
        paramList.Add(New ReportParameter("TtlPajak", Me.TxtTotalPPN.Text, True))
        paramList.Add(New ReportParameter("TtlValue", Me.TxtTotalValue.Text, True))


        Dim ReportViewerForm As New FrmReport
        ReportViewerForm.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptBPB.rdlc"
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewerForm.ReportViewer1.LocalReport.SetParameters(paramList)
        ReportViewerForm.ReportViewer1.RefreshReport()
        ReportViewerForm.Show()
    End Sub


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Listview2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Listview2.SelectedIndexChanged

    End Sub
End Class