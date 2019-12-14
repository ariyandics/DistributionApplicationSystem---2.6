Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Data.OleDb
Public Class FrmLPBReturSupplier
    Dim sql As String
    Dim conn As New ADODB.Connection
    Dim NomorReturTmp, IdJenisStok As Integer
    Dim RsConn As New ADODB.Recordset
    Dim barcode, plu, catatan, alamatsupplier, telpsupplier, dibuat As String
    Dim qty, harga, subtotal, qtyretur, rptotal As Double
    Dim pajak As Decimal
    Dim flagedit, flagsave As Boolean
    Dim NoRetur As Long
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand

    Private Sub BtnFindToko_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFindSupplier.Click
        TxtKodeSupplier.Text = FrmFind.cari("MasterSupplierRetur")
        If TxtKodeSupplier.Text = "0" Then TxtKodeSupplier.Text = ""
    End Sub


    Private Sub GbrTombol()
        Me.BtnAdd.Image = System.Drawing.Image.FromFile(icoadd)
        Me.BtnApproval.Image = System.Drawing.Image.FromFile(icoapprove)
        Me.BtnEdit.Image = System.Drawing.Image.FromFile(icoedit)
        Me.BtnCancel.Image = System.Drawing.Image.FromFile(icocancel)
        Me.BtnSave.Image = System.Drawing.Image.FromFile(icosave)
        Me.BtnPrint.Image = System.Drawing.Image.FromFile(icoprint)
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFindBrg.Click
        If Me.TxtKodeSupplier.Text = "" And TxtNamaSupplier.Text = "" Then
            MsgBox("Pilih dahulu nama supplier.", vbExclamation, "Perhatian")
            Exit Sub
        End If

        If Me.CmbTipeRetur.Text = "" Then
            MsgBox("Pilih dahulu Tipe Retur.", vbExclamation, "Perhatian")
            Exit Sub
        End If

        TxtKodeProduk.Text = FrmFind.cari("Masterprodukretur")
        If TxtKodeProduk.Text = "0" Then
            TxtKodeProduk.Text = ""
            Exit Sub
        End If

        getNamaProduk(TxtKodeProduk.Text, IdSupplier)
        TxtNamaBarang.Text = NamaProduk
        Me.TxtQty.Enabled = True
        Me.TxtQty.Focus()
    End Sub

    Private Sub TxtKodeSupplier_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtKodeSupplier.TextChanged
        If TxtKodeSupplier.Text = "" Then Exit Sub
        GetIdSupplier(Me.TxtKodeSupplier.Text)
        Me.TxtNamaSupplier.Text = NamaSupplier

        sql = "select * from mstsupplierperdc where iddc= " & IdDC & " and idsupplier=" & IdSupplier
        RsConfig = conn.Execute(sql)
        If Not RsConfig.EOF Then
            alamatsupplier = RsConfig("alamatsupplier").Value
            telpsupplier = RsConfig("noTelephone").Value
        End If
    End Sub

    Private Sub FrmLPBReturSupplier_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If TxtNoRetur.Text <> "" Then
            Call DeleteAll()
        End If
    End Sub

    Private Sub FrmLPBReturSupplier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Panel2.BackColor = Color.DeepSkyBlue

        Call bersih()
        Me.CmbTipeRetur.Items.Clear()
        Disable()
        Me.BtnAdd.Enabled = True
        Me.BtnFindNoRetur.Enabled = True
        Call GbrTombol()
    End Sub

    Private Sub cektable()

        sql = "Select TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='ReturDcKeSupplierTmp'"
        RsConn = conn.Execute(sql)
        If RsConn.EOF Then
            sql = "select top 0 * into ReturDcKeSupplierTmp from ReturDcDetailKeSupplier "
            conn.Execute(sql)
        End If

    End Sub
    Private Sub tambahedit()
        Call namadcAktif()
        Call GetIdSupplier(Me.TxtKodeSupplier.Text)
        Call GetIdProduk(Me.TxtKodeProduk.Text)
        Call GetIdJenisStok()

        If Me.Txtcatatan.Text = "" Then
            catatan = "*"
        Else
            catatan = Me.Txtcatatan.Text
        End If

        sql = "exec spReturDcHeaderDetailKeSupplier 'AddTmp'," & IdDC & ",'" & StrNamaUser & "'," & Me.TxtNoRetur.Text & "," & IdSupplier & "," & idProduk & "," & IdJenisStok & "," & qtyretur & ",'" & catatan & "'"
        conn.Execute(sql)
        LoadDataTmp()
        Call hitung()
        BtnSave.Enabled = True
        Me.BtnFindSupplier.Enabled = False
        CmbTipeRetur.Enabled = False
        Me.BtnFindBrg.Focus()
        Me.TxtQty.Clear()
        Me.TxtNamaBarang.Clear()
        Me.TxtKodeProduk.Clear()

   
    End Sub
    Private Sub hitung()
        sql = "exec spReturDcHeaderDetailKeSupplier 'Hitung'," & IdDC & ",'" & StrNamaUser & "'," & Me.TxtNoRetur.Text & "," & IdSupplier & ",0," & IdJenisStok & ",0,'catatan'"
        RsConn = conn.Execute(sql)
        If Not RsConn.EOF Then
            TxtTotalItem.Text = Format(RsConn("ttlitem").Value, "#,##0")
            TxtTotalQty.Text = Format(RsConn("ttlqty").Value, "#,##0")
            TxtTotalRetur.Text = Format(RsConn("ttlharga").Value, "#,##0.##")
            TxtPPN.Text = Format(RsConn("ttlppn").Value, "#,##0.##")
            TxtTotalIncPpn.Text = Format((RsConn("ttlharga").Value + RsConn("ttlppn").Value), "#,##0.##")
            rptotal = RsConn("ttlharga").Value + RsConn("ttlppn").Value
            Dim xx As String = rptotal.ToString
            nilaiterbilang = TerbilangDesimal(xx)

        End If
    End Sub

    Private Sub TxtQty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtQty.KeyDown
        If e.KeyCode = Keys.Enter Then
            GetIdJenisStok()
            If qtyretur <= 0 Then
                MsgBox("Masukan dahulu Qty Barang yang akan diretur", vbExclamation, "Perhatian")
                Exit Sub
            End If
            If Me.TxtKodeProduk.Text = "" Or Me.TxtNamaBarang.Text = "" Then
                MsgBox("Pilih dahulu barang yang akan diretur.", vbExclamation, "Perhatian")
                Exit Sub
            End If

            If IdJenisStok = 2 Then
                sql = "exec spMutasiSaldoHeaderDetail 'GetStockBS'," & IdDC & ",'" & StrNamaUser & "','xxx',0," & idProduk & "," & qtyretur & ",'ket','NoBA'"
            Else
                sql = "exec spMutasiSaldoHeaderDetail 'GetStockGS'," & IdDC & ",'" & StrNamaUser & "','xxx',0," & idProduk & "," & qtyretur & ",'ket','NoBA'"

            End If
            RsConn = conn.Execute(sql)
            If RsConn("qty").Value < qtyretur Then
                MsgBox("Stock hanya tersedia " & Format(RsConn("qty").Value, "#,##0") & " !!!", vbOKOnly + vbInformation, "Info")
                TxtQty.SelectAll()
                TxtQty.Focus()
                Exit Sub
            End If


            Call tambahedit()

        End If


    End Sub

    Private Sub TxtQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtQty.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(Keys.Back))
    End Sub

    Private Sub NomorReturTemp()
        sql = "select dbo.fcGetNomorReturSupplierTmp()NomorTmp"
        RsConn = conn.Execute(sql)
        If Not RsConn.EOF Then
            NomorReturTmp = RsConn("NomorTmp").Value
            Me.TxtNoRetur.Text = NomorReturTmp
        End If

        Call namadcAktif()
        GetIdJenisStok()
        sql = "exec spReturDcHeaderDetailKeSupplier 'InsTmp'," & IdDC & ",'" & StrNamaUser & "'," & NomorReturTmp & ", 0,0," & IdJenisStok & ",0,'catatan'"
        conn.Execute(sql)

    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        CmbTipeRetur.DropDownStyle = ComboBoxStyle.DropDownList
        Call cektable()
        Call bersih()
        Call LoadDataDokumen()
        Call NomorReturTemp()
        Call Disable()
        Call GetServerDate()
        Me.TxtTglRetur.Text = tglserver
        AddItemComboBox()
        Me.TxtUser.Text = StrNamaUser
        Me.BtnCancel.Enabled = True
        Me.BtnFindSupplier.Enabled = True
        Me.BtnFindSupplier.Focus()
        Me.CmbTipeRetur.Enabled = True
        Me.BtnFindBrg.Enabled = True
        Me.Txtcatatan.Enabled = True
    End Sub

    Private Sub AddItemComboBox()
        sql = "select*from MstJenisStok"
        RsConn = conn.Execute(sql)
        If Not RsConn.EOF Then
            RsConn.MoveFirst()
            Do While Not RsConn.EOF

                Me.CmbTipeRetur.Items.Add(RsConn("namajenisStok").Value)

                RsConn.MoveNext()
            Loop
        End If
    End Sub

    Private Sub GetIdJenisStok()
        sql = "select * from MstJenisStok where namaJenisStok = '" & CmbTipeRetur.Text & "'"
        RsConn = conn.Execute(sql)
        If Not RsConn.EOF Then
            IdJenisStok = RsConn("IdJenisStok").Value
        Else
            IdJenisStok = 0
        End If

    End Sub

    Private Sub Disable()
        Me.BtnFindSupplier.Enabled = False
        Me.BtnFindNoRetur.Enabled = False
        Me.BtnFindBrg.Enabled = False
        Me.BtnAdd.Enabled = False
        Me.BtnCancel.Enabled = False
        Me.BtnSave.Enabled = False
        Me.BtnApproval.Enabled = False
        Me.BtnEdit.Enabled = False
        Me.BtnPrint.Enabled = False
        Me.CmbTipeRetur.Enabled = False

    End Sub

    Private Sub bersih()
        Me.TxtKodeProduk.Clear()
        Me.TxtNamaBarang.Clear()
        Me.TxtKodeSupplier.Clear()
        Me.TxtNamaSupplier.Clear()
        Me.Txtcatatan.Clear()
        Me.TxtQty.Clear()
        Me.TxtNoRetur.Clear()
        Me.TxtQty.Enabled = False
        Me.TxtUser.Enabled = False
        Me.TxtTglApprove.Clear()
        Me.TxtTglApprove.Enabled = False
        Me.TxtTglRetur.Clear()
        Me.CmbTipeRetur.Items.Clear()
        Me.CmbTipeRetur.Text = ""
        Me.TxtUser.Clear()

        TxtTotalItem.Clear()
        TxtTotalIncPpn.Clear()
        TxtTotalQty.Clear()
        TxtTotalRetur.Clear()
        TxtPPN.Clear()


    End Sub
    Private Sub TxtQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtQty.TextChanged
        If TxtQty.Text = "" Then Exit Sub
        qtyretur = TxtQty.Text
        TxtQty.Text = Format(qtyretur, "#,##0")
        TxtQty.SelectionStart = Len(TxtQty.Text)
    End Sub

    Private Sub LoadDataTmp()

        ListView1.Columns.Clear()
        ListView1.Items.Clear()
        ListView1.View = Windows.Forms.View.Details
        ListView1.GridLines = True
        ListView1.FullRowSelect = True

        'If TxtFind.Text = "" Then
        '    strfind = "%"
        'Else
        '    strfind = TxtFind.Text
        'End If
        ListView1.Columns.Add("Nomor", 0)
        ListView1.Columns.Add("No.", 50, HorizontalAlignment.Right)
        ListView1.Columns.Add("Barcode", 90)
        ListView1.Columns.Add("SKU", 80)
        ListView1.Columns.Add("Description", 350)
        ListView1.Columns.Add("Qty", 80, HorizontalAlignment.Right)
        ListView1.Columns.Add("Cost", 100, HorizontalAlignment.Right)
        ListView1.Columns.Add("Ppn", 80, HorizontalAlignment.Right)
        ListView1.Columns.Add("Netto", 120, HorizontalAlignment.Right)


        sql = "exec spReturDcHeaderDetailKeSupplier 'GetTmp'," & IdDC & ",'" & StrNamaUser & "'," & Me.TxtNoRetur.Text & ", 0,0," & IdJenisStok & ",0,'catatan'"

        RsConn = conn.Execute(sql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()
            Dim nomor As Integer = 1
            Do While Not RsConn.EOF

                barcode = RsConn("barcode").Value
                plu = RsConn("kodeProduk").Value
                NamaProduk = RsConn("namaPanjang").Value
                qty = RsConn("qty").Value
                harga = RsConn("harga").Value
                pajak = RsConn("pajak").Value
                subtotal = RsConn("subTotal").Value


                Dim arr(9) As String
                Dim itm As ListViewItem
                arr(0) = Format(nomor, "#,##")
                arr(1) = Format(nomor, "#,##")
                arr(2) = barcode
                arr(3) = plu
                arr(4) = NamaProduk
                arr(5) = qty.ToString("N")
                arr(6) = harga.ToString("N")
                arr(7) = pajak.ToString("N")
                arr(8) = subtotal.ToString("N")
                itm = New ListViewItem(arr)
                ListView1.Items.Add(itm)
                nomor += 1
                RsConn.MoveNext()
            Loop

        End If
        RsConn.Close()


    End Sub
    Private Sub LoadData()

        ListView1.Columns.Clear()
        ListView1.Items.Clear()
        ListView1.View = Windows.Forms.View.Details
        ListView1.GridLines = True
        ListView1.FullRowSelect = True

        'If TxtFind.Text = "" Then
        '    strfind = "%"
        'Else
        '    strfind = TxtFind.Text
        'End If
        ListView1.Columns.Add("Nomor", 0)
        ListView1.Columns.Add("No.", 50, HorizontalAlignment.Right)
        ListView1.Columns.Add("Barcode", 90)
        ListView1.Columns.Add("SKU", 80)
        ListView1.Columns.Add("Description", 350)
        ListView1.Columns.Add("Qty", 80, HorizontalAlignment.Right)
        ListView1.Columns.Add("Cost", 100, HorizontalAlignment.Right)
        ListView1.Columns.Add("Ppn", 80, HorizontalAlignment.Right)
        ListView1.Columns.Add("Netto", 120, HorizontalAlignment.Right)


        sql = "exec spReturDcHeaderDetailKeSupplier 'LoadData'," & IdDC & ",'" & StrNamaUser & "'," & Me.TxtNoRetur.Text & ", 0,0," & IdJenisStok & ",0,'catatan'"

        RsConn = conn.Execute(sql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()
            Dim nomor As Integer = 1
            Do While Not RsConn.EOF

                barcode = RsConn("barcode").Value
                plu = RsConn("kodeProduk").Value
                NamaProduk = RsConn("namaPanjang").Value
                qty = RsConn("qty").Value
                harga = RsConn("harga").Value
                pajak = RsConn("pajak").Value
                subtotal = RsConn("subTotal").Value


                Dim arr(8) As String
                Dim itm As ListViewItem
                arr(0) = Format(nomor, "#,##")
                arr(1) = Format(nomor, "#,##")
                arr(2) = barcode
                arr(3) = plu
                arr(4) = NamaProduk
                arr(5) = qty.ToString("N")
                arr(6) = harga.ToString("N")
                arr(7) = pajak.ToString("N")
                arr(8) = subtotal.ToString("N")
                itm = New ListViewItem(arr)
                ListView1.Items.Add(itm)
                nomor += 1
                RsConn.MoveNext()
            Loop

        End If
        RsConn.Close()

    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        DeleteAll()
        Call bersih()
        Call Disable()
        Me.BtnAdd.Enabled = True
        Me.BtnFindNoRetur.Enabled = True
        LoadDataDokumen()
        Me.BtnAdd.Focus()
    End Sub

    Private Sub DeleteAll()
        sql = "exec spReturDcHeaderDetailKeSupplier 'DeleteTmp',0,0," & Me.TxtNoRetur.Text & ",0,0,0,0,'catatan'"
        conn.Execute(sql)

    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
     
        If flagedit = True Then

            GetStringKoneksi()
            GetKoneksiSQLClient()
            cmd = New SqlCommand("exec spReturDcHeaderDetailKeSupplier 'Add'," & IdDC & ",'" & StrNamaUser & "'," & Me.TxtNoRetur.Text & "," & IdSupplier & ",0," & IdJenisStok & ",0,'" & Me.Txtcatatan.Text & "'", SQLConn)
            cmd.CommandTimeout = 7200
            dr = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                If dr.Item("statusproses") = 0 Then
                    MsgBox(dr.Item("pesan"), vbOKOnly + vbInformation, "Simpan data Gagal")
                    Exit Sub
                Else
                    MsgBox(dr.Item("pesan"), vbOKOnly + vbInformation, "Simpan data Berhasil")
                    TxtNoRetur.Text = (dr.Item("NoTO"))
                End If
            End If
            dr.Close()
            flagedit = False

        Else
            flagsave = True
            namadcAktif()
            GetIdSupplier(Me.TxtKodeSupplier.Text)

            GetStringKoneksi()
            GetKoneksiSQLClient()
            sql = "exec spReturDcHeaderDetailKeSupplier 'Add'," & IdDC & ",'" & StrNamaUser & "'," & Me.TxtNoRetur.Text & "," & IdSupplier & ",0," & IdJenisStok & ",0,'" & Me.Txtcatatan.Text & "'"
            cmd = New SqlCommand(sql, SQLConn)
            cmd.CommandTimeout = 7200
            dr = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                If dr.Item("statusproses") = 0 Then
                    MsgBox(dr.Item("pesan"), vbOKOnly + vbInformation, "Simpan data Gagal")
                    Exit Sub
                Else
                    MsgBox(dr.Item("pesan"), vbOKOnly + vbInformation, "Simpan data Berhasil")
                    TxtNoRetur.Text = (dr.Item("NoTO"))
                End If
            End If
            dr.Close()
            flagedit = False

        End If
        DeleteAll()
        Call Disable()
        Me.Txtcatatan.Clear()
        Me.TxtQty.Clear()
        Me.TxtNamaBarang.Clear()
        Me.TxtKodeProduk.Clear()
        Me.Txtcatatan.Enabled = False
        Me.TxtQty.Enabled = False
        BtnEdit.Enabled = True
        BtnApproval.Enabled = True
        BtnAdd.Enabled = True
        BtnFindNoRetur.Enabled = True
        CmbTipeRetur.DropDownStyle = ComboBoxStyle.Simple
    End Sub



    Private Sub Approvedata()
        If conn.State = 0 Then
            Call GetStringKoneksi()
            conn.Open(StrKoneksi)
        End If
        'If flagedit = True Then
        If Me.TxtTglApprove.Text <> "" Then
            MsgBox("Dokumen ini sudah di approve", vbInformation, "Info")
            Exit Sub
        End If

        If MessageBox.Show("Apakah anda sudah yakin dengan data tersebut dan ingin di Approve ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            sql = "exec spReturDcHeaderDetailKeSupplier 'GetStok'," & IdDC & ",'" & StrNamaUser & "'," & Me.TxtNoRetur.Text & "," & IdSupplier & ",0," & IdJenisStok & ",0,'" & Me.Txtcatatan.Text & "'"
            RsConn = conn.Execute(sql)
            If Not RsConn.EOF Then
                RsConn.MoveFirst()
                MsgBox("Stock " & RsConn("namapanjang").Value & " tidak mencukupi!!!", vbOKOnly + vbCritical, "Gagal Approve")
                Exit Sub
            End If

            GetStringKoneksi()
            GetKoneksiSQLClient()
            cmd = New SqlCommand("exec spReturDcHeaderDetailKeSupplier 'ApproveData'," & IdDC & ",'" & StrNamaUser & "'," & Me.TxtNoRetur.Text & "," & IdSupplier & ",0," & IdJenisStok & ",0,'" & Me.Txtcatatan.Text & "'", SQLConn)
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
            flagedit = False
            'Disable()
            Me.BtnApproval.Enabled = False
            Me.BtnFindNoRetur.Enabled = True
            Call LoadDataDokumen()
        End If
        ' End If
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        flagedit = True
        copydata()
        Call Disable()
        BtnCancel.Enabled = True
        BtnSave.Enabled = True
        BtnFindBrg.Enabled = True
        BtnFindBrg.Focus()
    End Sub

    Private Sub copydata()
        sql = "exec spReturDcHeaderDetailKeSupplier 'CopyData'," & IdDC & ",'" & StrNamaUser & "'," & Me.TxtNoRetur.Text & "," & IdSupplier & ",0," & IdJenisStok & ",0,'catatan'"
        conn.Execute(sql)
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        Me.TxtQty.Focus()
        Dim z As Integer
        z = ListView1.SelectedItems.Count

        If z = 0 Then
            Exit Sub
        Else
            If flagedit = True Then
                Me.TxtKodeProduk.Text = ListView1.SelectedItems.Item(0).SubItems(3).Text
                Me.TxtNamaBarang.Text = ListView1.SelectedItems.Item(0).SubItems(4).Text
                Me.TxtQty.Enabled = True
                Me.TxtQty.Focus()
            End If
        End If

    End Sub

    Private Sub GetNomerRetur()
        sql = "Select dbo.fcGetNomorReturSupplier()NomorRetur"
        RsConn = conn.Execute(sql)
        If Not RsConn.EOF Then
            NoRetur = RsConn("NomorRetur").Value
        End If
    End Sub



    Private Sub BtnFindNoRetur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFindNoRetur.Click
        flagsave = False
        Me.TxtNoRetur.Text = FrmFind.cari("LoadDataRetur")
    End Sub

    Private Sub LoadDataDokumen()

        If Me.TxtNoRetur.Text = "" Then
            Me.TxtNoRetur.Text = 0
        End If
        ListView1.Columns.Clear()
        ListView1.Items.Clear()
        ListView1.View = Windows.Forms.View.Details
        ListView1.GridLines = True
        ListView1.FullRowSelect = True

        ListView1.Columns.Add("Nomor", 0)
        ListView1.Columns.Add("No.", 50, HorizontalAlignment.Right)
        ListView1.Columns.Add("Barcode", 90)
        ListView1.Columns.Add("SKU", 80)
        ListView1.Columns.Add("Description", 350)
        ListView1.Columns.Add("Qty", 80, HorizontalAlignment.Right)
        ListView1.Columns.Add("Cost", 100, HorizontalAlignment.Right)
        ListView1.Columns.Add("Ppn", 80, HorizontalAlignment.Right)
        ListView1.Columns.Add("Netto", 120, HorizontalAlignment.Right)



        sql = "exec spReturDcHeaderDetailKeSupplier 'LoadDokumen'," & IdDC & ",'" & StrNamaUser & "'," & Me.TxtNoRetur.Text & ", 0,0," & IdJenisStok & ",0,'catatan'"

        RsConn = conn.Execute(sql)

        If Not RsConn.EOF Then
            Me.TxtKodeSupplier.Text = RsConn("kodesupplier").Value
            Me.TxtTglRetur.Text = Microsoft.VisualBasic.Right(RsConn("TglRetur").Value, 2) & "-" & Microsoft.VisualBasic.Mid(RsConn("TglRetur").Value, 6, 2) & "-" & Microsoft.VisualBasic.Left(RsConn("TglRetur").Value, 4)
            Me.Txtcatatan.Text = RsConn("catatan").Value
            Me.TxtUser.Text = RsConn("iduser").Value
            Me.TxtTotalItem.Text = Format(RsConn("totalItem").Value, "#,##0")
            Me.TxtTotalQty.Text = Format(RsConn("totalQty").Value, "#,##0")
            Me.TxtTotalRetur.Text = Format(RsConn("totalRp").Value, "#,##0.##")
            Me.TxtPPN.Text = Format(RsConn("totalPajak").Value, "#,##0.##")
            Me.TxtTotalIncPpn.Text = Format(RsConn("totalRpRetur").Value, "#,##0.##")
            dibuat = RsConn("Namauser").Value
            rptotal = RsConn("totalRpRetur").Value
            Dim xx As String = rptotal.ToString
            nilaiterbilang = TerbilangDesimal(xx)


            If IsDBNull(RsConn("tglApprove").Value) Then
                Me.TxtTglApprove.Text = ""
                Me.BtnApproval.Enabled = True
                Me.BtnEdit.Enabled = True
                Me.Txtcatatan.Enabled = True
                Me.BtnPrint.Enabled = False
            Else
                Me.TxtTglApprove.Text = RsConn("tglApprove").Value
                Me.BtnApproval.Enabled = False
                Me.BtnEdit.Enabled = False
                Me.Txtcatatan.Enabled = False
                Me.BtnPrint.Enabled = True
            End If

            If RsConn("idjenisstok").Value = 1 Then
                CmbTipeRetur.Text = "GOOD STOCK"
            Else
                CmbTipeRetur.Text = "BAD STOCK"
            End If

            RsConn.MoveFirst()
            Dim nomor As Integer = 1
            Do While Not RsConn.EOF

                barcode = RsConn("barcode").Value
                plu = RsConn("kodeProduk").Value
                NamaProduk = RsConn("namaPanjang").Value
                qty = RsConn("qty").Value
                harga = RsConn("harga").Value
                pajak = RsConn("pajak").Value
                subtotal = RsConn("subTotal").Value


                Dim arr(9) As String
                Dim itm As ListViewItem
                arr(0) = nomor
                arr(1) = Format(nomor, "#,##0")
                arr(2) = barcode
                arr(3) = plu
                arr(4) = NamaProduk
                arr(5) = qty.ToString("N")
                arr(6) = harga.ToString("N")
                arr(7) = pajak.ToString("N")
                arr(8) = subtotal.ToString("N")
                itm = New ListViewItem(arr)
                ListView1.Items.Add(itm)
                nomor += 1
                RsConn.MoveNext()
            Loop

        End If



        RsConn.Close()



    End Sub

    Private Sub TxtNoRetur_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNoRetur.TextChanged
        If flagsave = False Then
            LoadDataDokumen()
        End If
    End Sub


    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
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

        strSQL = "exec spReturDcHeaderDetailKeSupplier 'LoadDokumen'," & IdDC & ",'" & StrNamaUser & "'," & Me.TxtNoRetur.Text & ", 0,0," & IdJenisStok & ",0,'catatan'"

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
        rds.Name = "DataSetNRBSupplier"
        rds.Value = objDataSet.Tables(0)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPerusahaan", NamaPT, True))
        paramList.Add(New ReportParameter("FormHeader", "NOTA RETUR BARANG SUPPLIER", True))
        paramList.Add(New ReportParameter("KodeSupplier", Me.TxtKodeSupplier.Text, True))
        paramList.Add(New ReportParameter("NamaSupplier", Me.TxtNamaSupplier.Text, True))
        paramList.Add(New ReportParameter("AlamatSupplier", Me.alamatsupplier, True))
        paramList.Add(New ReportParameter("TelpSupplier", telpsupplier, True))
        paramList.Add(New ReportParameter("NoFaktur", Me.TxtNoRetur.Text, True))
        paramList.Add(New ReportParameter("TglRetur", Me.TxtTglRetur.Text, True))
        paramList.Add(New ReportParameter("TglBuat", Me.TxtTglRetur.Text, True))
        paramList.Add(New ReportParameter("TtlItem", Me.TxtTotalItem.Text, True))
        paramList.Add(New ReportParameter("TtlQty", Me.TxtTotalQty.Text, True))
        paramList.Add(New ReportParameter("TtlRetur", Me.TxtTotalRetur.Text, True))
        paramList.Add(New ReportParameter("PpnIn", Me.TxtPPN.Text, True))
        paramList.Add(New ReportParameter("TtlIncPPN", Me.TxtTotalIncPpn.Text, True))
        paramList.Add(New ReportParameter("terbilang", nilaiterbilang, True))
        paramList.Add(New ReportParameter("KodeDC", kodedc, True))
        paramList.Add(New ReportParameter("NamaDC", namadc, True))
        paramList.Add(New ReportParameter("KotaDC", kotadc, True))
        paramList.Add(New ReportParameter("Catatan", Txtcatatan.Text, True))
        paramList.Add(New ReportParameter("DiBuat", dibuat, True))

        Dim ReportViewerForm As New FrmReport
        ReportViewerForm.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".rptNrbSupplier.rdlc"
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewerForm.ReportViewer1.LocalReport.SetParameters(paramList)
        ReportViewerForm.ReportViewer1.RefreshReport()
        ReportViewerForm.Show()

    End Sub

    Private Sub Txtcatatan_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtcatatan.KeyPress
        If (e.KeyChar Like "[',]") Then e.Handled() = True
    End Sub


    Private Sub BtnApproval_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnApproval.Click
        Call Approvedata()
    End Sub

End Class