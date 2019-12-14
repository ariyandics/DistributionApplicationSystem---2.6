Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Data.OleDb
Public Class FrmMutasiDcOut
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
    Dim DcTujuan As Integer
    Dim tblname, alamatdctujuan, telpdctujuan As String
    Dim statusdata As Int16
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand

    Private Sub FrmMutasiDcOut_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        BtnFindNoFaktur.Focus()
    End Sub

    Private Sub FrmMutasiDcOut_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If BtnSave.Enabled = True Then
            Dim result2 As DialogResult = MessageBox.Show("Masih Ada data yang belum disimpan ....!!" & vbCrLf _
                                                               & "Tetap mau keluar ?", "Question !!", _
             MessageBoxButtons.YesNo, _
             MessageBoxIcon.Question)
            If result2 = DialogResult.Yes Then

                'sql = "exec spTblTOTmp 'GetTO',2,0,0,0,0,'" & StrNamaUser & "'"
                'RsConn = conn.Execute(sql)
                'If RsConn.EOF Then
                Call deletetmp()
                'Call hapustmp()
                nomorTO = 0
            Else
                e.Cancel = True
                ' End If
            End If
        Else
            Call deletetmp()
        End If
    End Sub
    Private Sub FrmMutasiDcOut_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        DcTujuan = 0

      
        TxtTotalItem.ReadOnly = True
        TxtTotalQty.ReadOnly = True
        TxtTotalValue.ReadOnly = True
        TxtTotalItem.BackColor = Color.White
        TxtTotalQty.BackColor = Color.White
        TxtTotalValue.BackColor = Color.White

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
            sql = "exec spMutasiDCDetailOut 'gettmp'," & IdDC & "," & DcTujuan & "," & nomorTO & "," & idProduk & ",0,0," & IdPajak & "," & qty & ",0,'" & StrNamaUser & "'"

        Else
            sql = "exec spMutasiDCDetailOut 'get'," & IdDC & "," & DcTujuan & "," & nomorTO & "," & idProduk & ",0,0," & IdPajak & "," & qty & ",0,'" & StrNamaUser & "'"

        End If
        RsConn = conn.Execute(sql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()
            noUrut = 1
            Do While Not RsConn.EOF

                Dim arr(8) As String
                Dim itm As ListViewItem

                arr(0) = noUrut
                arr(1) = RsConn("barcode").Value
                arr(2) = RsConn("kodeproduk").Value
                arr(3) = RsConn("namapanjang").Value
                arr(4) = Format(RsConn("qty").Value, "#,##0")
                arr(5) = Format(RsConn("hppdc").Value, "#,##.#0")
                arr(6) = Format(RsConn("pajak").Value, "#,##.#0")
                arr(7) = Format(RsConn("subtotal").Value, "#,##.#0")



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

        Call bersih()
        flagadd = True
        BtnAdd.Enabled = False
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


    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Call deletetmp()
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
        sql = "exec spMutasiDCDetailOut 'Delete'," & IdDC & ",0," & Val(txtNoFaktur.Text) & ",0,0,0,0,0,0,'" & StrNamaUser & "'"
        conn.Execute(sql)
    End Sub
    Private Sub getnomor()

        Call namadcAktif()
        GetStringKoneksi()
        GetKoneksiSQLClient()
        sql = "exec spMutasiDCDetailOut 'NewData'," & IdDC & ",0,0,0,0,0,0,0,0,'" & StrNamaUser & "'"
        cmd = New SqlCommand(sql, SQLConn)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            txtNoFaktur.Text = dr.Item("NoMutasi")
        End If

    End Sub
    Private Sub cektable()

        sql = "Select TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='MutasiDCDetailOutTMP'"
        RsConfig = conn.Execute(sql)
        If RsConfig.EOF Then
            sql = "select top 0 * into MutasiDCDetailOutTMP  from MutasiDCDetailOut "
            conn.Execute(sql)
        End If
    End Sub

    Private Sub btnFindToko_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindToko.Click
        TxtKodetoko.Text = ""
        txtnamatoko.Text = ""
        TxtKodetoko.Text = FrmFind.cari("MasterDCAll")
        If TxtKodetoko.Text = "0" Then TxtKodetoko.Text = ""
        If TxtKodetoko.Text = "" Then
            MsgBox("Anda belum memilih DC Tujuan !!!", vbOKOnly + vbInformation, "Info")
            Exit Sub
        Else

            kodetoko = TxtKodetoko.Text
            sql = "Exec spfind 'GetDC','" & kodetoko & "','x'"
            RsConn = conn.Execute(sql)
            If Not RsConn.EOF Then
                txtnamatoko.Text = RsConn("namadc").Value
                DcTujuan = RsConn("iddc").Value

                If flagadd = True Then
                    btnFindproduk.Enabled = True
                    txtcatatan.ReadOnly = False
                    txtcatatan.Focus()
                End If

            Else
                DcTujuan = 0
            End If
        End If


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
        sql = "exec spfind 'GetProduk','" & txtBarcode.Text & "','x'"
        RsConn = conn.Execute(sql)
        If Not RsConn.EOF Then
            idProduk = RsConn("idproduk").Value
            txtnamabarang.Text = RsConn("namapanjang").Value

            txtqty.ReadOnly = False
            txtqty.Text = ""
            txtqty.Focus()

        Else
            MsgBox("Produk tidak ditemukan..!!", vbOKOnly + vbCritical, "Info")
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

        End If

        sql = "exec spMutasiDCDetailOut 'AddTmp'," & IdDC & "," & DcTujuan & "," & nomorTO & "," & idProduk & ",0,0," & IdPajak & "," & qty & ",0,'" & StrNamaUser & "'"
        conn.Execute(sql)
        BtnSave.Enabled = True
        Call hitung()
        Call loaddata()
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
        sql = "exec spMutasiDCDetailOut 'gettmp'," & IdDC & "," & DcTujuan & "," & nomorTO & "," & idProduk & ",0,0," & IdPajak & "," & qty & ",0,'" & StrNamaUser & "'"
        conn.Execute(sql)
        If Not RsConfig.EOF Then
            Call simpan()
        Else
            MsgBox("Tidak ada data yang di simpan!!", vbOKOnly + vbInformation, "Info")
            Exit Sub
        End If
    End Sub
    Private Sub hapustmp()

        sql = "exec spTblTOTmp 'Delete',3," & kodetoko & ",0,0," & nomortox & ",'" & StrNamaUser & "'"
        RsConn = conn.Execute(sql)

    End Sub

    Private Sub simpan()
        Dim result2 As DialogResult = MessageBox.Show("Simpan data Mutasi DC ??", _
               "Question !!", _
               MessageBoxButtons.YesNo, _
               MessageBoxIcon.Question)
        If result2 = DialogResult.Yes Then
            nomorTO = txtNoFaktur.Text
            Call tombol()
            If flagadd = True Then

                GetStringKoneksi()
                GetKoneksiSQLClient()

                cmd = New SqlCommand("exec spMutasiDCHeaderOut 'add'," & IdDC & "," & DcTujuan & "," & nomorTO & "," & ttlitem & "," & ttlqty & "," & Replace(ttlvalue, ",", ".") & "," & Replace(ttlpajak, ",", ".") & "," & Replace(ttlnett, ",", ".") & ",'" & txtcatatan.Text & "','" & txtuser.Text & "',0", SQLConn)
                dr = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows Then
                    txtNoFaktur.Text = dr.Item("nomutasi")
                End If

            End If

            If flagedit = True Then
                sql = ("exec spMutasiDCHeaderOut 'add'," & IdDC & "," & DcTujuan & "," & nomorTO & "," & ttlitem & "," & ttlqty & "," & Replace(ttlvalue, ",", ".") & "," & Replace(ttlpajak, ",", ".") & "," & Replace(ttlnett, ",", ".") & ",'" & txtcatatan.Text & "','" & txtuser.Text & "',0")
                conn.Execute(sql)
            End If


            Call pesan(3)
            flagadd = False
            flagedit = False
            Call loaddata()
            Panel1.Enabled = True
            BtnFindNoFaktur.Enabled = True
            btnFindToko.Enabled = False
            BtnAdd.Enabled = True
            BtnEdit.Enabled = True
            BtnApproval.Enabled = True
            btnFindproduk.Enabled = False
            statusdata = 0
        Else
            Exit Sub
        End If
    End Sub

    Private Sub BtnApproval_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnApproval.Click
        Dim result2 As DialogResult = MessageBox.Show("Approve data Mutasi Antar DC ??", _
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

                If conn.State = 0 Then
                    GetStringKoneksi()
                    conn.Open(StrKoneksi)
                End If

                sql = ("exec spMutasiDCHeaderOut 'Approve'," & IdDC & "," & DcTujuan & "," & nomorTO & "," & ttlitem & "," & ttlqty & "," & Replace(ttlvalue, ",", ".") & "," & Replace(ttlpajak, ",", ".") & "," & Replace(ttlnett, ",", ".") & ",'" & txtcatatan.Text & "','" & txtuser.Text & "',0")
                conn.Execute(sql)
                MsgBox("Approval berhasil!!", vbOKOnly + vbInformation, "Info")
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
            sql = "exec spMutasiDCDetailOut 'HitungTmp'," & IdDC & "," & DcTujuan & "," & nomorTO & "," & idProduk & ",0,0," & IdPajak & "," & qty & ",0,'" & StrNamaUser & "'"
        ElseIf flagadd = False And flagedit = False Then
            sql = "exec spMutasiDCDetailOut 'Hitung'," & IdDC & "," & DcTujuan & "," & nomorTO & "," & idProduk & ",0,0," & IdPajak & "," & qty & ",0,'" & StrNamaUser & "'"
        End If
        RsConfig = conn.Execute(sql)
        If Not RsConfig.EOF Then
            TxtTotalItem.Text = Format(RsConfig("ttlitem").Value, "#,##0.##")
            TxtTotalQty.Text = Format(RsConfig("ttlqty").Value, "#,##0.##")
            TxtTotalValue.Text = Format(RsConfig("ttlvalue").Value, "#,##0.##")

            ttlitem = RsConfig("ttlitem").Value
            ttlpajak = RsConfig("ttlpajak").Value
            ttlqty = RsConfig("ttlqty").Value
            ttlvalue = RsConfig("ttlvalue").Value
            ' ttlnett = ttlvalue + ttlpajak

        End If
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        sql = "exec spMutasiDCDetailOut 'EditTmp'," & IdDC & "," & DcTujuan & "," & nomorTO & "," & idProduk & ",0,0," & IdPajak & "," & qty & ",0,'" & StrNamaUser & "'"
        conn.Execute(sql)

        Call tombol()
        BtnCancel.Enabled = True
        BtnSave.Enabled = True
        btnFindproduk.Enabled = True
        Panel1.Enabled = False
        txtBarcode.ReadOnly = False
        flagedit = True
        txtuser.Text = StrNamaUser
        Call loaddata()
        statusdata = 1
    End Sub

    Private Sub BtnFindNoFaktur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFindNoFaktur.Click
        Call bersih()
        txtNoFaktur.Text = FrmFind.cari("NoMutasiDC")
        If Val(txtNoFaktur.Text) > 0 Then
            nomorTO = txtNoFaktur.Text
            sql = "exec spMutasiDCHeaderOut 'get'," & IdDC & "," & DcTujuan & "," & nomorTO & "," & ttlitem & "," & ttlqty & "," & Replace(ttlvalue, ",", ".") & "," & Replace(ttlpajak, ",", ".") & "," & Replace(ttlnett, ",", ".") & ",'" & txtcatatan.Text & "','" & txtuser.Text & "',0"
            RsConfig = conn.Execute(sql)
            If Not RsConfig.EOF Then
                txtuser.Text = RsConfig("iduser").Value
                txtTglBuat.Text = Format(RsConfig("TglMutasi").Value, "dd-MM-yyyy")
                txtcatatan.Text = RsConfig("catatan").Value
                DcTujuan = RsConfig("idDcPenerima").Value
                txtnamatoko.Text = RsConfig("namadc").Value
                alamatdctujuan = RsConfig("alamatdc").Value
                telpdctujuan = RsConfig("telepon").Value

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
                TxtKodetoko.Text = RsConfig("kodedc").Value
                Call loaddata()
                Call hitung()
            End If
        Else
            Call bersih()
            Call loaddata()
        End If
    End Sub


    Private Sub txtcatatan_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcatatan.KeyPress
        e.Handled = Not (Char.IsLetterOrDigit(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Or e.KeyChar = Chr(Keys.Back))
        e.KeyChar = UCase(e.KeyChar)
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
        Call cetakSJ()
    End Sub
    Private Sub cetakSJ()
        Dim objConn As OleDbConnection
        Dim objCmd As OleDbCommand
        Dim objReader As OleDbDataReader
        Dim objDataSet As DataSet = New DataSetMutasi
        Dim strSQL, strCONN As String

        GetStringKoneksi() '---1
        strCONN = StrKoneksi '----2

        strSQL = "exec spMutasiDCDetailOut 'get'," & IdDC & "," & DcTujuan & "," & nomorTO & "," & idProduk & ",0,0," & IdPajak & "," & qty & ",0,'" & StrNamaUser & "'"

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
        rds.Name = "DataSetMutasiOut"
        rds.Value = objDataSet.Tables(0)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", "MUTASI ANTAR DC - OUT", True))
        paramList.Add(New ReportParameter("KodeDC", kodedc, True))
        paramList.Add(New ReportParameter("NamaDC", namadc, True))
        paramList.Add(New ReportParameter("AlamatDC", alamatdc, True))
        paramList.Add(New ReportParameter("telpDC", telpdc, True))
        paramList.Add(New ReportParameter("DCTujuan", TxtKodetoko.Text, True))
        paramList.Add(New ReportParameter("NamaDCTujuan", txtnamatoko.Text, True))
        paramList.Add(New ReportParameter("AlamatDCTujuan", alamatdctujuan, True))
        paramList.Add(New ReportParameter("TelpDCTujuan", telpdctujuan, True))
        paramList.Add(New ReportParameter("NoFaktur", Me.txtNoFaktur.Text, True))
        paramList.Add(New ReportParameter("TtlItem", Me.TxtTotalItem.Text, True))
        paramList.Add(New ReportParameter("TtlQty", Me.TxtTotalQty.Text, True))
        paramList.Add(New ReportParameter("TtlValue", Me.TxtTotalValue.Text, True))
        paramList.Add(New ReportParameter("catatan", Me.txtcatatan.Text, True))
        paramList.Add(New ReportParameter("TglApprove", Me.txtTglApprove.Text, True))
        paramList.Add(New ReportParameter("TglBuat", Me.txtTglBuat.Text, True))

        Dim ReportViewerForm As New FrmReport
        ReportViewerForm.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptMutasiDCOut.rdlc"
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewerForm.ReportViewer1.LocalReport.SetParameters(paramList)
        ReportViewerForm.ReportViewer1.RefreshReport()
        ReportViewerForm.Show()
    End Sub

    Private Sub btnFindproduk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindproduk.Click
        txtBarcode.Text = FrmFind.cari("MasterProduk")
        Call manualx()
    End Sub

    
End Class