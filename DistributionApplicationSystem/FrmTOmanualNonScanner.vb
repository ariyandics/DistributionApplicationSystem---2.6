Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Data.OleDb
Public Class FrmTOmanualNonScanner
    Dim sql As String
    Dim conn As New ADODB.Connection
    Dim RsConn As New ADODB.Recordset
    Dim barcode, plu As String
    Dim qtyctn, harga, pajak, subtotal, disk1, disk2, netto As Double
    Dim flagadd, flagedit As Boolean
    Dim strBarcode, strplu, strnamabarang, kepala As String
    Dim noUrut, strqty, qty As Int64
    Dim strharga, strppn, strnetto As Double
    Dim ttlqty, ttlitem, ttlvalue, ttlpajak, ttlnett As Double
    Dim nomortox As Int64
    Dim tblname As String
    Dim statusdata As Int16
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand


    Private Sub FrmTOmanualNonScanner_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        BtnFindNoFaktur.Focus()
    End Sub

    Private Sub FrmTOmanualNonScanner_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If BtnSave.Enabled = True Then
            Dim result2 As DialogResult = MessageBox.Show("Masih Ada data yang belum disimpan ....!!" & vbCrLf _
                                                               & "Tetap mau keluar ?", "Question !!", _
             MessageBoxButtons.YesNo, _
             MessageBoxIcon.Question)
            If result2 = DialogResult.Yes Then

                sql = "exec spTblTOTmp 'GetTO',2,0,0,0,0,'" & StrNamaUser & "'"
                RsConn = conn.Execute(sql)
                If RsConn.EOF Then
                    Call deletetmp()
                    Call hapustmp()
                    nomorTO = 0
                End If
            Else
                e.Cancel = True
            End If
        ElseIf BtnAdd.Text = "Scan" Then
            nomorTO = Val(txtNoFaktur.Text)
            Call deletetmp()
            nomorTO = 0
        End If
    End Sub

   
    Private Sub FrmTOmanualNonScanner_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
      
        Call bersih()
        Call GbrTombol()
        Call cektemp()


    End Sub

    Private Sub cektemp()
        sql = "exec spTblTOTmp 'GetTO',2,0,0,0,0,'" & StrNamaUser & "'"
        RsConn = conn.Execute(sql)

        If Not RsConn.EOF Then
            Dim result2 As DialogResult = MessageBox.Show("Masih Ada data yang belum selesai ....!!" & vbCrLf _
                                                              & "Silahkan dilanjutkan ?", "Question !!", _
            MessageBoxButtons.OK, _
            MessageBoxIcon.Question)
            If result2 = DialogResult.OK Then
                kodetoko = 0

                Do While txtNoFaktur.Text = "" Or txtNoFaktur.Text = "0"
                    txtNoFaktur.Text = FrmFind.cari("NoTOManTMP")
                Loop
                nomorTO = txtNoFaktur.Text
                txtuser.Text = StrNamaUser

                sql = "exec spTblTOTmp 'GetTOdet',2," & kodetoko & ",0,0," & nomorTO & ",'" & StrNamaUser & "'"
                RsConfig = conn.Execute(sql)
                If Not RsConfig.EOF Then
                    statusdata = RsConfig("nomorpb").Value
                    TxtKodetoko.Text = RsConfig("kodetoko").Value
                    txtnamatoko.Text = RsConfig("namatoko").Value
                    txtTglBuat.Text = Format(Now, "dd-MM-yyyy")

                    BtnAdd.Enabled = False
                    BtnCancel.Enabled = True
                    BtnSave.Enabled = True
                    btnFindproduk.Enabled = True
                    Panel1.Enabled = False
                    txtBarcode.ReadOnly = False
                    txtBarcode.Focus()

                    flagedit = True

                    Call hitung()
                End If
            Else
                sql = "delete from TblTOTmp where jenisto=2 and iduser='" & StrNamaUser & "'"
                conn.Execute(sql)
            End If
        End If

        Call loaddata()

    End Sub
    Private Sub GbrTombol()
        Me.BtnAdd.Image = System.Drawing.Image.FromFile(icoadd)
        Me.BtnApproval.Image = System.Drawing.Image.FromFile(icoapprove)
        Me.BtnEdit.Image = System.Drawing.Image.FromFile(icoedit)
        Me.BtnCancel.Image = System.Drawing.Image.FromFile(icocancel)
        Me.BtnSave.Image = System.Drawing.Image.FromFile(icosave)
        Me.BtnPrint.Image = System.Drawing.Image.FromFile(icoprint)

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
        txtcatatan.Clear()
        txtTglApprove.Clear()

        txtNoFaktur.ReadOnly = True
        TxtKodetoko.ReadOnly = True
        txtnamatoko.ReadOnly = True
        txtuser.ReadOnly = True
        txtTglBuat.ReadOnly = True
        txtcatatan.ReadOnly = True
        txtTglApprove.ReadOnly = True
        txtNoFaktur.BackColor = Color.White
        TxtKodetoko.BackColor = Color.White
        txtnamatoko.BackColor = Color.White
        txtuser.BackColor = Color.White
        txtTglBuat.BackColor = Color.White
        txtcatatan.BackColor = Color.White
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

        btnFindproduk.Enabled = False
        BtnAdd.Enabled = True
        BtnApproval.Enabled = False
        BtnEdit.Enabled = False
        BtnCancel.Enabled = False
        BtnSave.Enabled = False
        BtnPrint.Enabled = False
        btnFindToko.Enabled = False
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
        Listview2.Columns.Add("SKU", 80)
        Listview2.Columns.Add("Description", 300)
        Listview2.Columns.Add("Qty", 80, HorizontalAlignment.Right)
        Listview2.Columns.Add("Price", 90, HorizontalAlignment.Right)
        Listview2.Columns.Add("PPN", 70, HorizontalAlignment.Right)
        Listview2.Columns.Add("Total", 110, HorizontalAlignment.Right)


        If flagadd = True Or flagedit = True Then
            sql = "exec spToKeTokoDetailManualTMP 'Get'," & IdDC & "," & kodetoko & "," & nomorTO & ",0,0,0,0,0,0,0,'" & StrNamaUser & "'"
        Else
            sql = "exec spToKeTokoDetailManual 'GetTMP'," & IdDC & "," & kodetoko & "," & nomorTO & ",0,0,0,0,0,0,0"
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
                strharga = RsConn("hpptoko").Value
                strppn = RsConn("pajaktoko").Value
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
            btnFindToko.Enabled = True
            Panel1.Enabled = True
            txtuser.Text = StrNamaUser
            txtTglBuat.Text = Format(Now, "dd-MM-yyyy")

            Call cektable()
            Call getnomor()
            Call loaddata()
            btnFindToko.Focus()

        Else
            If txtnamatoko.Text <> "" Then
                BtnAdd.Text = "&Add"
                txtBarcode.ReadOnly = False
                txtBarcode.Focus()
                Panel1.Enabled = False
                BtnAdd.Enabled = False
                btnFindproduk.Enabled = True
                statusdata = 0
                Call simpantbltmp()

            Else
                MsgBox("Anda belum memilih Toko !!!", vbOKOnly + vbInformation, "Info")
                Exit Sub
            End If
        End If

    End Sub

    Private Sub simpantbltmp()
        sql = "exec spTblTOTmp 'Add',2," & kodetoko & "," & statusdata & ",0," & nomorTO & ",'" & StrNamaUser & "'"
        conn.Execute(sql)

    End Sub
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        nomorTO = txtNoFaktur.Text
        nomortox = txtNoFaktur.Text
        Call deletetmp()
        Call hapustmp()
        Call tombol()

        If flagadd = True Then
            Call bersih()
            BtnAdd.Focus()
        ElseIf flagedit = True And statusdata = 1 Then
            Panel1.Enabled = True
            BtnEdit.Enabled = True
            BtnApproval.Enabled = True
            flagedit = False
            BtnAdd.Enabled = True
            BtnEdit.Enabled = True
        ElseIf flagedit = True And statusdata = 0 Then
            Call bersih()
            BtnAdd.Focus()
        End If
        statusdata = 0
        Call loaddata()
    End Sub
    Private Sub deletetmp()
        conn.Execute("delete from ToKeTokoDetailManualTMP where nomorTO=" & nomorTO & " and kodetoko=" & kodetoko & " and iduser='" & StrNamaUser & "'")
        conn.Execute("delete from ToKeTokoDetailManualTMP where nomorTO=" & nomorTO & " and iduser='" & StrNamaUser & "'")
    End Sub

    Private Sub getnomor()

        sql = "Select isnull(max(nomorTO),0 )as nomor from ToKeTokoDetailManualTMP where nomorto < 2000"
        RsConfig = conn.Execute(sql)
        If RsConfig("nomor").Value > 0 Then
            nomorTO = RsConfig("nomor").Value + 1
        Else
            nomorTO = 1
        End If
        sql = "exec spToKeTokoDetailManualTMP 'NewData'," & IdDC & "," & kodetoko & "," & nomorTO & ",0,0,0,0,0,0,0,'" & StrNamaUser & "'"
        conn.Execute(sql)


        txtNoFaktur.Text = nomorTO
    End Sub
    Private Sub cektable()
       
        sql = "Select TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='ToKeTokoDetailManualTMP'"
        RsConfig = conn.Execute(sql)
        If RsConfig.EOF Then
            sql = "select top 0 *,'' as iduser into ToKeTokoDetailManualTMP  from ToKeTokoDetailManual "
            conn.Execute(sql)
        End If

    End Sub

    Private Sub btnFindToko_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindToko.Click
        TxtKodetoko.Clear()
        txtnamatoko.Clear()
        txtcatatan.Clear()
        TxtKodetoko.Text = FrmFind.cari("MasterToko")

    End Sub

    Private Sub txtNoFaktur_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNoFaktur.TextChanged
        If txtNoFaktur.Text = "0" Then txtNoFaktur.Text = ""
        If txtNoFaktur.Text = "" Then Exit Sub
        nomorTO = Val(txtNoFaktur.Text)

    End Sub

    Private Sub txtBarcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBarcode.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtBarcode.Text <> "" Then
                Call manualx()
            End If
        End If
    End Sub

    Private Sub txtBarcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBarcode.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(Keys.Back))
    End Sub
    Private Sub manualx()
        scan(txtBarcode.Text)
        If idProduk > 0 Then
            txtnamabarang.Text = NamaProduk

                txtqty.ReadOnly = False
                txtqty.Text = ""
                txtqty.Focus()

        Else
            MsgBox("Produk tidak bisa di TO ke toko tujuan..!!", vbOKOnly + vbCritical, "Info")
            txtBarcode.Clear()
            txtnamabarang.Clear()
            txtBarcode.Focus()
            Exit Sub
        End If
    End Sub


    Private Sub simpanTmp()
        If qty > 0 Then

         
            sql = "exec spPrintSOHVirtual 'get'," & idProduk
            RsConn = conn.Execute(sql)
            If RsConn("qty").Value < qty Then
                MsgBox("Stock hanya tersedia " & Format(RsConn("qty").Value, "#,##0") & " !!!", vbOKOnly + vbInformation, "Info")

                If RsConn("qty").Value = 0 Then
                    txtBarcode.SelectAll()
                    txtBarcode.Focus()
                Else
                    txtqty.SelectAll()
                    txtqty.Focus()
                End If

                Exit Sub
            ElseIf RsConn("hpp").Value <= 0 Then
                MsgBox("Hpp anda masih 0(nol) !!!", vbOKOnly + vbInformation, "Info")
                txtBarcode.SelectAll()
                txtBarcode.Focus()
                Exit Sub
            End If

            If statusToko <> "R" Then
                sql = "Select harga from msthargabyjenislokasi where harga=0 and idproduk=" & idProduk & " and kodejenislokasi='" & kodejnslokasi & "'"
                RsConn = conn.Execute(sql)
                If Not RsConn.EOF Then
                    MsgBox("Harga Jual anda masih 0(nol) !!!", vbOKOnly + vbInformation, "Info")
                    txtBarcode.SelectAll()
                    txtBarcode.Focus()
                    Exit Sub
                End If
            End If
        End If


        sql = "exec spToKeTokoDetailManualTMP 'Add'," & IdDC & "," & kodetoko & "," & nomorTO & "," & idProduk & ",0,0,0," & IdPajak & "," & qty & ",0,'" & StrNamaUser & "'"
        conn.Execute(sql)
        BtnSave.Enabled = True
        Call hitung()
        Call loaddata()
        ' CBLock.Checked = True
        txtnamabarang.Clear()
        txtBarcode.Clear()
        txtBarcode.Focus()
        txtqty.Text = 1
    End Sub

    Private Sub txtqty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtqty.KeyDown
        If e.KeyCode = Keys.Back Then
            e.Handled = True
        End If

        If e.KeyCode = Keys.Enter Then

            If txtBarcode.Text = "" Then
                MsgBox("Anda belum memilih produk !!!", vbOKOnly + vbCritical, "Warning")
                txtBarcode.Focus()
                Exit Sub
            Else
                Call simpanTmp()
                txtqty.Clear()
            End If

        End If
    End Sub

    Private Sub txtqty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtqty.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or ".".Contains(e.KeyChar) Or e.KeyChar = Chr(Keys.Back))
    End Sub

    Private Sub txtqty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtqty.TextChanged
        If txtqty.Text = "" Then Exit Sub
        qty = Replace(txtqty.Text, ".", "")
        txtqty.Text = Format(qty, "#,##0.##")
        txtqty.SelectionStart = Len(txtqty.Text)
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click

        sql = "exec spToKeTokoDetailManualTMP 'get'," & IdDC & "," & kodetoko & "," & nomorTO & "," & idProduk & ",0,0,0,0," & qty & ",0,'" & StrNamaUser & "'"
        RsConfig = conn.Execute(sql)
        If Not RsConfig.EOF Then
            Call simpan()
        Else
            MsgBox("Tidak ada data yag di simpan!!", vbOKOnly + vbInformation, "Info")
            Exit Sub
        End If
    End Sub
    Private Sub hapustmp()

        sql = "exec spTblTOTmp 'Delete',2," & kodetoko & ",0,0," & nomortox & ",'" & StrNamaUser & "'"
        RsConn = conn.Execute(sql)

    End Sub

    Private Sub simpan()
        Dim result2 As DialogResult = MessageBox.Show("Simpan TO Manual ??", _
               "Question !!", _
               MessageBoxButtons.YesNo, _
               MessageBoxIcon.Question)
        If result2 = DialogResult.Yes Then
            nomorTO = txtNoFaktur.Text
            Call tombol()
            If flagadd = True Then

                GetStringKoneksi()
                GetKoneksiSQLClient()
                cmd = New SqlCommand("exec spToKeTokoHeaderManual 'add'," & IdDC & "," & kodetoko & "," & nomorTO & "," & ttlitem & "," & ttlqty & "," & Replace(ttlvalue, ",", ".") & "," & Replace(ttlpajak, ",", ".") & "," & Replace(ttlnett, ",", ".") & ",'" & txtcatatan.Text & "','" & txtuser.Text & "',null,0", SQLConn)
                cmd.CommandTimeout = 7200
                dr = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows Then
                    If dr.Item("statusproses") = 0 Then
                        MsgBox(dr.Item("pesan"), vbOKOnly + vbInformation, "Simpan data Gagal")
                        Exit Sub
                    Else
                        MsgBox(dr.Item("pesan"), vbOKOnly + vbInformation, "Simpan data Berhasil")
                        txtNoFaktur.Text = (dr.Item("NoTO"))
                    End If
                End If
                dr.Close()
            End If

            If flagedit = True Then

                If statusdata = 0 Then
                    GetStringKoneksi()
                    GetKoneksiSQLClient()
                    cmd = New SqlCommand("exec spToKeTokoHeaderManual 'add'," & IdDC & "," & kodetoko & "," & nomorTO & "," & ttlitem & "," & ttlqty & "," & Replace(ttlvalue, ",", ".") & "," & Replace(ttlpajak, ",", ".") & "," & Replace(ttlnett, ",", ".") & ",'" & txtcatatan.Text & "','" & txtuser.Text & "',null,0", SQLConn)
                    cmd.CommandTimeout = 7200
                    dr = cmd.ExecuteReader
                    dr.Read()
                    If dr.HasRows Then
                        If dr.Item("statusproses") = 0 Then
                            MsgBox(dr.Item("pesan"), vbOKOnly + vbInformation, "Smpan data Gagal")
                            Exit Sub
                        Else
                            MsgBox(dr.Item("pesan"), vbOKOnly + vbInformation, "Simpan data Berhasil")
                            txtNoFaktur.Text = dr.Item("nomorto")
                        End If

                    End If
                    dr.Close()
                Else
                    GetStringKoneksi()
                    GetKoneksiSQLClient()
                    cmd = New SqlCommand("exec spToKeTokoHeaderManual 'edit'," & IdDC & "," & kodetoko & "," & nomorTO & "," & ttlitem & "," & ttlqty & "," & Replace(ttlvalue, ",", ".") & "," & Replace(ttlpajak, ",", ".") & "," & Replace(ttlnett, ",", ".") & ",'" & txtcatatan.Text & "','" & txtuser.Text & "',null,0", SQLConn)
                    cmd.CommandTimeout = 7200
                    dr = cmd.ExecuteReader
                    dr.Read()
                    If dr.HasRows Then
                        If dr.Item("statusproses") = 0 Then
                            MsgBox(dr.Item("pesan"), vbOKOnly + vbInformation, "Smpan data Gagal")
                            Exit Sub
                        Else
                            MsgBox(dr.Item("pesan"), vbOKOnly + vbInformation, "Simpan data Berhasil")

                        End If

                    End If
                    dr.Close()



                End If



            End If
            flagadd = False
            flagedit = False
            Call loaddata()
            Panel1.Enabled = True
            BtnFindNoFaktur.Enabled = True
            btnFindToko.Enabled = False
            BtnAdd.Enabled = True
            BtnEdit.Enabled = True
            BtnApproval.Enabled = True
            BtnPrint.Enabled = True
            btnFindproduk.Enabled = False
            statusdata = 0
            Call deletetmp()
            Call hapustmp()

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
            sql = "exec spToKeTokoDetailManual 'GetStok'," & IdDC & "," & kodetoko & "," & nomorTO & "," & idProduk & ",0,0,0,0," & qty & ",0"
            RsConfig = conn.Execute(sql)
            If Not RsConfig.EOF Then
                RsConfig.MoveFirst()
                MsgBox("Stock " & RsConfig("namapanjang").Value & " tidak mencukupi!!!", vbOKOnly + vbCritical, "Gagal Approve")
                Exit Sub
            Else
                Call tombol()
                GetStringKoneksi()
                GetKoneksiSQLClient()

                sql = "exec spToKeTokoHeaderManual 'Approve'," & IdDC & "," & kodetoko & "," & nomorTO & ",0,0,0,0,0,'" & txtcatatan.Text & "','" & txtuser.Text & "',null,1"
                cmd = New SqlCommand(sql, SQLConn)
                cmd.CommandTimeout = 7200
                dr = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows Then
                    If dr.Item("statusproses") = 0 Then
                        MsgBox(dr.Item("pesan"), vbOKOnly + vbInformation, "Approve data Gagal")
                        Exit Sub
                    Else
                        MsgBox(dr.Item("pesan"), vbOKOnly + vbInformation, "Approve data Berhasil")
                    End If

                End If
                dr.Close()

                txtTglApprove.Text = Format(Now, "dd-MM-yyyy")

                BtnPrint.Enabled = True
                BtnAdd.Enabled = True
                Panel1.Enabled = True
                btnFindToko.Enabled = False
                BtnFindNoFaktur.Enabled = True
            End If
        End If
    End Sub


    Private Sub hitung()
        If flagadd = True Or flagedit = True Then
            sql = "exec spToKeTokoDetailManualTMP 'Hitung'," & IdDC & "," & kodetoko & "," & nomorTO & "," & idProduk & ",0,0,0,0," & qty & ",0,'" & StrNamaUser & "'"
        ElseIf flagadd = False And flagedit = False Then
            sql = "exec spToKeTokoDetailManual 'Hitung'," & IdDC & "," & kodetoko & "," & nomorTO & "," & idProduk & ",0,0,0,0," & qty & ",0"
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
        sql = "exec spToKeTokoDetailManualTMP 'EditData'," & IdDC & "," & kodetoko & "," & nomorTO & "," & idProduk & ",0,0,0,0," & qty & ",0,'" & StrNamaUser & "'"
        conn.Execute(sql)

        Call tombol()
        BtnCancel.Enabled = True
        BtnSave.Enabled = True
        btnFindproduk.Enabled = True
        Panel1.Enabled = False
        txtBarcode.ReadOnly = False
        ' CBLock.Enabled = True
        flagedit = True
        txtuser.Text = StrNamaUser
        Call loaddata()
        statusdata = 1
        Call simpantbltmp()
    End Sub

    Private Sub BtnFindNoFaktur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFindNoFaktur.Click
        Call bersih()
        txtNoFaktur.Text = FrmFind.cari("NoTOManual")
        If Val(txtNoFaktur.Text) > 0 Then
            nomorTO = txtNoFaktur.Text
            sql = "Select * from  ToKeTokoHeaderManual  where nomorto=" & nomorTO
            RsConfig = conn.Execute(sql)
            If Not RsConfig.EOF Then
                txtcatatan.Text = RsConfig("catatan").Value
                txtuser.Text = RsConfig("iduser").Value
                txtTglBuat.Text = Format(RsConfig("TglTO").Value, "dd-MM-yyyy")
                txtcatatan.Text = RsConfig("catatan").Value
                If RsConfig("statusdata").Value > 0 Then
                    Call tombol()
                    BtnPrint.Enabled = True
                    txtTglApprove.Text = Format(RsConfig("Tglapprove").Value, "dd-MM-yyyy")
                Else
                    Call tombol()
                    BtnApproval.Enabled = True
                    BtnEdit.Enabled = True
                    BtnFindNoFaktur.Enabled = True
                    BtnPrint.Enabled = True
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
        If TxtKodetoko.Text = "0" Then TxtKodetoko.Text = ""
        If TxtKodetoko.Text = "" Then Exit Sub
        kodetoko = TxtKodetoko.Text
        gettoko(kodetoko)
        txtnamatoko.Text = namatoko

        If flagadd = True Then
            txtcatatan.ReadOnly = False
            txtcatatan.Focus()
        End If
    End Sub

    Private Sub txtcatatan_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcatatan.KeyPress
        e.Handled = Not (Char.IsLetterOrDigit(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Or e.KeyChar = Chr(Keys.Back))
    End Sub

    Private Sub txtcatatan_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcatatan.TextChanged
        txtcatatan.Text = UCase(txtcatatan.Text)
        txtcatatan.SelectionStart = Len(txtcatatan.Text)
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
        btnFindproduk.Enabled = False
        'CBLock.Enabled = False

    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        If BtnApproval.Enabled = True Then
            Call cetak()
        Else
            If statusToko = "R" Then
                kepala = "SURAT JALAN"
                Call cetakSJ()
            Else
                kepala = "DELIVERY ORDER"
                ' Call cetak()
                Call cetakSJ()
            End If
        End If

    End Sub
    Private Sub cetakSJ()
        Dim objConn As OleDbConnection
        Dim objCmd As OleDbCommand
        Dim objReader As OleDbDataReader
        Dim objDataSet As DataSet = New DataSetPO
        Dim strSQL, strCONN As String

        GetStringKoneksi() '---1
        strCONN = StrKoneksi '----2

        strSQL = "exec spToKeTokoDetailManual 'GetTMP'," & IdDC & "," & kodetoko & "," & nomorTO & ",0,0,0,0,0,0,0"

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
        paramList.Add(New ReportParameter("catatan", Me.txtcatatan.Text, True))
        paramList.Add(New ReportParameter("TglApprove", Me.txtTglApprove.Text, True))
        paramList.Add(New ReportParameter("TglBuat", Me.txtTglBuat.Text, True))

        Dim ReportViewerForm As New FrmReport
        ReportViewerForm.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptBPB.rdlc"
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewerForm.ReportViewer1.LocalReport.SetParameters(paramList)
        ReportViewerForm.ReportViewer1.RefreshReport()
        ReportViewerForm.Show()
    End Sub

    Private Sub cetak()
        Dim objConn As OleDbConnection
        Dim objCmd As OleDbCommand
        Dim objReader As OleDbDataReader
        Dim objDataSet As DataSet = New DataSetPO
        Dim strSQL, strCONN As String

        GetStringKoneksi() '---1
        strCONN = StrKoneksi '----2


        strSQL = "exec spPickingDetail 'CetakMan'," & IdDC & "," & kodetoko & "," & Me.txtNoFaktur.Text & ",'" & StrNamaUser & "'"

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
        paramList.Add(New ReportParameter("Judul", "PICKING LIST MANUAL", True))
        paramList.Add(New ReportParameter("KodeDC", kodedc, True))
        paramList.Add(New ReportParameter("NamaDC", namadc, True))
        paramList.Add(New ReportParameter("Kodetoko", kodetoko, True))
        paramList.Add(New ReportParameter("NamaToko", namatoko, True))
        paramList.Add(New ReportParameter("NoPicking", Me.txtNoFaktur.Text, True))
        paramList.Add(New ReportParameter("TglPicking", Format(Now, "dd-MM-yyyy HH:mm:ss"), True))

        Dim ReportViewerForm As New FrmReport
        ReportViewerForm.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptPL.rdlc"
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewerForm.ReportViewer1.LocalReport.SetParameters(paramList)
        ReportViewerForm.ReportViewer1.RefreshReport()
        ReportViewerForm.Show()
    End Sub
    Private Sub btnFindproduk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindproduk.Click
        Try
            GetStringKoneksi()
            Using Con As New SqlConnection(ConnSQLClient)
                Con.Open()
                If Con.State = 0 Then
                    MsgBox("Koneksi ke server terputus..!", vbOKOnly + vbInformation, "Info")
                    Exit Sub
                Else
                    txtBarcode.Text = FrmFind.cari("MasterProduk")
                    If txtBarcode.Text = 0 Then
                        txtnamabarang.Clear()
                        Exit Sub
                    Else
                        Call manualx()
                    End If
                End If
                Con.Close()
            End Using

        Catch ex As SqlException
            MsgBox("Koneksi ke server terputus..!", vbOKOnly + vbInformation, "Info")
        End Try


    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class