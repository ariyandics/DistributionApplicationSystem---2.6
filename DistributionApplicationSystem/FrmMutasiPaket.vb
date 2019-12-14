Public Class FrmMutasiPaket
    Dim Conn, ConnMDB As New ADODB.Connection
    Dim RsConn, RsMdb As New ADODB.Recordset
    Dim sql As String
    Dim flagadd, flagedit As Boolean
    Dim qtyMutasi, NoMutasi, idpaket As Integer
    Private Sub FrmMutasiPaket_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Conn.State = 0 Then
            Call GetStringKoneksi()
            Conn.Open(StrKoneksi)
        End If

        Label1.Parent = PictureBox1
        Label1.BackColor = Color.Transparent
        Me.BackColor = Color.SkyBlue
        Me.BackgroundImage = System.Drawing.Image.FromFile(bg)
        PictureBox1.BackgroundImage = System.Drawing.Image.FromFile(atas)
        Me.Text = NamaPT
        Me.Label1.Left = (Me.Width - Me.Label1.Width) / 2
        Me.Label1.Top = 9
        Panel2.BackColor = Color.SkyBlue
        flagadd = False
        flagedit = False
        Call cektable()
        Call kunci()
        Call bersih()
        Call LoadData()
        Call GbrTombol()
        BtnAdd.Enabled = True
        BtnFindNo.Enabled = True

    End Sub

    Private Sub GbrTombol()
        Me.BtnAdd.Image = System.Drawing.Image.FromFile(icoadd)
        Me.BtnApproval.Image = System.Drawing.Image.FromFile(icoapprove)
        Me.BtnEdit.Image = System.Drawing.Image.FromFile(icoedit)
        Me.BtnCancel.Image = System.Drawing.Image.FromFile(icocancel)
        Me.BtnSimpan.Image = System.Drawing.Image.FromFile(icosave)
    End Sub
    Private Sub bersih()
        txtnoMutasi.Clear()
        txtKodeProduk.Clear()
        txtNamaProduk.Clear()
        txtHpp.Clear()
        txtqty.Clear()
        txtHppAll.Clear()
        txtnoMutasi.ReadOnly = True
        txtKodeProduk.ReadOnly = True
        txtNamaProduk.ReadOnly = True
        txtHpp.ReadOnly = True
        txtqty.ReadOnly = True
        txtHppAll.ReadOnly = True

    End Sub

    Private Sub kunci()
        BtnFindProduk.Enabled = False
        BtnFindNo.Enabled = False
        BtnAdd.Enabled = False
        BtnEdit.Enabled = False
        BtnCancel.Enabled = False
        BtnSimpan.Enabled = False
        BtnApproval.Enabled = False
        LblTglMutasi.Visible = False
    End Sub

    Private Sub BtnFindProduk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFindProduk.Click
        txtKodeProduk.Clear()
        txtNamaProduk.Clear()
        txtqty.Clear()
        txtKodeProduk.Text = FrmFind.cari("ProdukPaket")
        If txtKodeProduk.Text = "0" Then
            txtKodeProduk.Text = ""
            Exit Sub
        Else
            getNamaProduk(txtKodeProduk.Text, 0)
            txtNamaProduk.Text = NamaProduk
        End If
        txtqty.ReadOnly = False
        txtqty.Focus()

        idpaket = 0
        sql = "exec sptblProdukPaket 'getid',0," & idProduk & ",0,0,'x'"
        RsConfig = Conn.Execute(sql)
        If Not RsConfig.EOF Then
            idpaket = RsConfig("idpaket").Value
        End If

    End Sub
    Private Sub loaddata()
        Dim strsql As String


        ListView2.Columns.Clear()
        ListView2.Items.Clear()
        ListView2.View = Windows.Forms.View.Details
        ListView2.GridLines = True
        ListView2.FullRowSelect = True
        ListView2.Columns.Add("Kode", 70)
        ListView2.Columns.Add("Nama Produk", 270)
        ListView2.Columns.Add("Qty/Paket", 80, HorizontalAlignment.Right)
        ListView2.Columns.Add("Hpp", 80, HorizontalAlignment.Right)
        ListView2.Columns.Add("Total Qty", 100, HorizontalAlignment.Right)
        ListView2.Columns.Add("Total Hpp", 100, HorizontalAlignment.Right)

      
        If flagedit = True Or flagadd = True Then
            strsql = "exec sptblProdukPaket 'getTMP',0,0,0," & NoMutasi & ",'x'"
        Else
            strsql = "exec sptblProdukPaket 'GetDetail',0,0,0," & NoMutasi & ",'x'"
        End If

        RsConn = Conn.Execute(strsql)
        If Not RsConn.EOF Then
            RsConn.MoveFirst()

            Do While Not RsConn.EOF


                Dim arr(7) As String
                Dim itm As ListViewItem

                arr(0) = RsConn("kodeproduk").Value
                arr(1) = RsConn("NamaPanjang").Value
                arr(2) = Format(RsConn("Qty").Value, "#,##0")
                arr(3) = Format(RsConn("HppDC").Value, "#,##0.#")
                arr(4) = Format(RsConn("QtyPaket").Value, "#,##0")
                arr(5) = Format(RsConn("TotalHpp").Value, "#,##0.#")


                itm = New ListViewItem(arr)
                ListView2.Items.Add(itm)

                RsConn.MoveNext()

            Loop

        End If
        RsConn.Close()


    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Call bersih()
        Call kunci()

        BtnCancel.Enabled = True
        flagadd = True
        BtnFindProduk.Enabled = True
        BtnFindProduk.Focus()

        sql = "Select isnull(max(NoMutasi),0 )as nomor from TblMutasiPaketTMP"
        RsConfig = Conn.Execute(sql)
        If RsConfig("nomor").Value > 0 Then
            NoMutasi = RsConfig("nomor").Value + 1
        Else
            NoMutasi = 1
        End If
        txtnoMutasi.Text = NoMutasi
        Call loaddata()
    End Sub
    Private Sub cektable()
        sql = "Select TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='TblMutasiPaketTMP'"
        RsConfig = Conn.Execute(sql)
        If RsConfig.EOF Then
            sql = "select top 0 * into TblMutasiPaketTMP from TblMutasiPaketDetail "
            Conn.Execute(sql)
        End If

    End Sub
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Call hapustmp()
        Call kunci()
        Call bersih()
        flagadd = False
        flagedit = False
        BtnAdd.Enabled = True
        BtnFindNo.Enabled = True
        NoMutasi = 0
        Call loaddata()

    End Sub

    Private Sub txtqty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtqty.KeyDown
        If e.KeyCode = Keys.Enter Then
            If qtyMutasi > 0 Then
                Call isitmp()
                Call loaddata()
                Call hitungTMP()
                BtnSimpan.Enabled = True
                BtnSimpan.Focus()
            Else
                Exit Sub
            End If
        End If
    End Sub

    Private Sub hitungTMP()
        If flagadd = True Or flagedit = True Then
            sql = "exec sptblProdukPaket 'HitungTMP',0,0,0," & NoMutasi & ",'" & StrNamaUser & "'"
        Else
            sql = "exec sptblProdukPaket 'GetHeader',0,0,0," & NoMutasi & ",'" & StrNamaUser & "'"
        End If

        RsConfig = Conn.Execute(sql)
        If Not RsConfig.EOF() Then
            txtHpp.Text = Format(RsConfig("HppPaket").Value, "#,##0.##")
            txtHppAll.Text = Format(RsConfig("TotalHppPaket").Value, "#,##0.##")

            If flagadd = False And flagedit = False Then
                txtqty.Text = Format(RsConfig("TotalQtyPaket").Value, "#,##0.##")
                txtKodeProduk.Text = RsConfig("kodeproduk").Value
                txtNamaProduk.Text = RsConfig("namapanjang").Value
                idpaket = RsConfig("idpaket").Value

                If RsConfig("statusdata").Value = 0 Then
                    LblTglMutasi.Visible = False
                    BtnApproval.Enabled = True
                    BtnEdit.Enabled = True
                Else
                    BtnApproval.Enabled = False
                    BtnEdit.Enabled = False
                End If

                If RsConfig("statusdata").Value = 1 Then
                    LblTglMutasi.Visible = True
                    LblTglMutasi.Text = "TGL APPROVAL: " & Format(RsConfig("tglapproval").Value, "dd-MM-yyyy")
                End If

            End If

        End If


    End Sub

    Private Sub isitmp()
        sql = "exec sptblProdukPaket 'IsiTmp'," & idpaket & ",0," & qtyMutasi & "," & NoMutasi & ",'" & StrNamaUser & "'"
        Conn.Execute(sql)
    End Sub


    Private Sub hapustmp()
        sql = "exec sptblProdukPaket 'HapusTmp',0,0,0," & NoMutasi & ",'" & StrNamaUser & "'"
        Conn.Execute(sql)
    End Sub

    Private Sub txtqty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtqty.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or ".".Contains(e.KeyChar) Or e.KeyChar = Chr(Keys.Back))

    End Sub

    Private Sub txtqty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtqty.TextChanged
        If txtqty.Text = "" Then Exit Sub
        qtyMutasi = Replace(txtqty.Text, ".", "")
        txtqty.Text = Format(qtyMutasi, "#,##0.##")
        txtqty.SelectionStart = Len(txtqty.Text)

    End Sub

    Private Sub BtnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSimpan.Click
        Call simpan()
    End Sub

    Private Sub simpan()
        Dim result2 As DialogResult = MessageBox.Show("Simpan Data Mutasi Paket ??", _
              "Question !!", _
              MessageBoxButtons.YesNo, _
              MessageBoxIcon.Question)
        If result2 = DialogResult.Yes Then
            sql = "exec sptblProdukPaket 'cekstock',0,0,0," & NoMutasi & ",'" & StrNamaUser & "'"
            RsConfig = Conn.Execute(sql)


            If Not RsConfig.EOF() Then
                MsgBox("Stock " & RsConfig("NamaPanjang").Value & " hanya ada " & RsConfig("qty").Value, vbOKOnly + vbCritical, "Gagal Simpan")
                txtqty.Focus()
                txtqty.SelectAll()
                Exit Sub
            Else

                If flagadd = True Then
                    sql = "exec sptblProdukPaket 'add'," & idpaket & "," & idProduk & "," & qtyMutasi & "," & NoMutasi & ",'" & StrNamaUser & "'"
                    Conn.Execute(sql)
                    Call pesan(3)
                    Call kunci()
                    Call bersih()
                    flagadd = False
                    Call loaddata()
                    BtnAdd.Enabled = True
                    BtnFindNo.Enabled = True

                ElseIf flagedit = True Then
                    sql = "exec sptblProdukPaket 'Edit'," & idpaket & "," & idProduk & "," & qtyMutasi & "," & NoMutasi & ",'" & StrNamaUser & "'"
                    Conn.Execute(sql)
                    Call pesan(3)
                    Call kunci()
                    flagedit = False
                    BtnAdd.Enabled = True
                    BtnFindNo.Enabled = True
                    BtnEdit.Enabled = True
                    BtnApproval.Enabled = True

                End If

            End If
        End If
    End Sub

    Private Sub BtnFindNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFindNo.Click
        txtnoMutasi.Text = FrmFind.cari("NoMutasiPaket")
        NoMutasi = Val(txtnoMutasi.Text)
        If txtnoMutasi.Text = "" Then Exit Sub
        Call loaddata()
        Call hitungTMP()
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        flagedit = True
        Call isitmp()
        Call loaddata()
        Call hitungTMP()

        Call kunci()
        BtnCancel.Enabled = True
        BtnSimpan.Enabled = True
        txtqty.ReadOnly = False
        txtqty.Focus()
        txtqty.SelectAll()
     

    End Sub

    Private Sub BtnApproval_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnApproval.Click
        Call approve()

    End Sub

    Private Sub approve()
        Dim result2 As DialogResult = MessageBox.Show("Approval Data Mutasi Paket ??", _
            "Question !!", _
            MessageBoxButtons.YesNo, _
            MessageBoxIcon.Question)
        If result2 = DialogResult.Yes Then
            sql = "exec sptblProdukPaket 'cekstock',0,0,0," & NoMutasi & ",'" & StrNamaUser & "'"
            RsConfig = Conn.Execute(sql)

            If Not RsConfig.EOF() Then
                MsgBox("Stock " & RsConfig("NamaPanjang").Value & " hanya ada " & RsConfig("qty").Value, vbOKOnly + vbCritical, "Gagal Simpan")
                txtqty.Focus()
                txtqty.SelectAll()
                Exit Sub
            Else
                If Conn.State = 0 Then
                    GetStringKoneksi()
                    Conn.Open(StrKoneksi)
                End If
                Call kunci()
                sql = "exec sptblProdukPaket 'Approve',0,0,0," & NoMutasi & ",'" & StrNamaUser & "'"
                Conn.Execute(sql)
                LblTglMutasi.Visible = True
                LblTglMutasi.Text = "TGL APPROVAL: " & Format(Now, "dd-MM-yyyy")
                MsgBox("Approval berhasil!!", vbOKOnly + vbInformation, "Info")
               
                BtnAdd.Enabled = True
                BtnFindNo.Enabled = True
            End If
        End If
    End Sub
End Class