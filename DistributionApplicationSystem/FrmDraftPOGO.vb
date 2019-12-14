Public Class FrmDraftPOGO
    Dim sql As String
    Dim conn As New ADODB.Connection
    Dim RsConn As New ADODB.Recordset
    Dim flagedit As Boolean
    Dim nomorpo, noUrut, qtykarton, strC1, strC2 As Integer
    Dim strqtypo, strharga, strdisc1, strdisc2, strnetto As Decimal
    Dim stridproduk, strplu, strnamabarang, strBarcode, alamatsupplier, telpsupplier As String
    Dim rpsystem, qtysystem, pajakkoreksi, totalkoreksi, rptotal, diskon1, qtykoreksi As Decimal
    Private Sub FrmDraftPOGO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Parent = PictureBox1
        Label1.BackColor = Color.Transparent
        Me.BackColor = Color.SkyBlue
        Me.BackgroundImage = System.Drawing.Image.FromFile(bg)
        PictureBox1.BackgroundImage = System.Drawing.Image.FromFile(atas)
        Me.Text = NamaPT

        Me.Label1.Left = (Me.Width - Me.Label1.Width) / 2
        Me.Label1.Top = 9
        If conn.State = 0 Then
            GetStringKoneksi()
            conn.Open(StrKoneksi)
        End If

        Call bersih()
        Call kunci()
        BtnAdd.Enabled = True
        flagedit = False
        Call loaddata()
    End Sub


    Private Sub bersih()
        TxtNoFaktur.Clear()
        TxtKodeSupplier.Clear()
        TxtNamaSupplier.Clear()
        txtTglPO.Clear()
        txtjmltoko.Clear()
        txtKodeProduk.Clear()
        txtNamaProduk.Clear()
        txtPrice.Clear()
        txtqty.Clear()

        txtqty.ReadOnly = True

    End Sub


    Private Sub kunci()
        BtnAdd.Enabled = False
        BtnApproval.Enabled = False
        BtnCancel.Enabled = False
        BtnEdit.Enabled = False
        BtnSimpan.Enabled = False
        BtnPrint.Enabled = False
        btnfindnopo.Enabled = False
        BtnFindSupplier.Enabled = False
        Panel2.Enabled = False
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        flagedit = True
        Call kunci()
        BtnCancel.Enabled = True

        Call loadtoko()
        txtTglPO.Text = Format(Now, "dd-MM-yyyy")

        sql = "Select isnull(max(nomorUpo),0 )as nomor from upodcdetailtmp"
        RsConfig = conn.Execute(sql)
        If RsConfig("nomor").Value > 0 Then
            nomorUPO = RsConfig("nomor").Value + 1
        Else
            nomorUPO = 1
        End If
        TxtNoFaktur.Text = nomorUPO
        sql = "exec spUpoDcDetailtmp 'add'," & IdDC & "," & nomorUPO & "," & idProduk & "," & IdSupplier & ",'x',0,0,0,0,0,0,0,0," & qtykoreksi & ",0,0,0,0,0,0,'x'"
        conn.Execute(sql)
        listview2.Enabled = False
        BtnFindSupplier.Enabled = True
        BtnFindSupplier.Focus()

    End Sub

    Private Sub loadtoko()
        Dim strsql, strkode, strnama As String

        ListView1.Columns.Clear()
        ListView1.Items.Clear()
        ListView1.View = Windows.Forms.View.Details
        ListView1.GridLines = True
        ListView1.FullRowSelect = True

        ListView1.Columns.Add("No.", 50)
        ListView1.Columns.Add("Kode Toko", 80)
        ListView1.Columns.Add("Nama Toko", 200)

        strsql = "exec spUpoDcHeaderTokoGOTMP 'get'," & IdDC & ",0,0,3"
        RsConn = conn.Execute(strsql)
        noUrut = 0
        If Not RsConn.EOF Then
            RsConn.MoveFirst()
            Do While Not RsConn.EOF
                noUrut += 1
                strkode = RsConn("kodetoko").Value
                strnama = RsConn("Namatoko").Value

                Dim arr(3) As String
                Dim itm As ListViewItem

                arr(0) = noUrut
                arr(1) = strkode
                arr(2) = strnama


                itm = New ListViewItem(arr)
                ListView1.Items.Add(itm)

                RsConn.MoveNext()

            Loop

        End If
        RsConn.Close()

        txtjmltoko.Text = noUrut

    End Sub

    Private Sub loaddata()
        listview2.Columns.Clear()
        listview2.Items.Clear()
        listview2.View = Windows.Forms.View.Details
        listview2.GridLines = True
        listview2.FullRowSelect = True

        listview2.Columns.Add("No", 50)
        listview2.Columns.Add("SKU", 80)
        listview2.Columns.Add("Description", 300)
        listview2.Columns.Add("Disc GO", 60, HorizontalAlignment.Right)
        listview2.Columns.Add("MaxS DC", 70, HorizontalAlignment.Right)
        listview2.Columns.Add("SOH DC", 70, HorizontalAlignment.Right)
        listview2.Columns.Add("MaxS Toko", 80, HorizontalAlignment.Right)
        listview2.Columns.Add("Conv 1", 70, HorizontalAlignment.Right)
        listview2.Columns.Add("Conv 2", 70, HorizontalAlignment.Right)
        listview2.Columns.Add("Total", 120, HorizontalAlignment.Right)

        If flagedit = True Then
            sql = "exec spUpoDcDetailtmp 'GetManual'," & IdDC & "," & nomorUPO & "," & idProduk & "," & IdSupplier & ",'" & Ptag & "',0,0,0,0,0,0,0,0," & qtykoreksi & "," & harga & "," & disk1 & "," & disk2 & "," & totalkoreksi & "," & pajakkoreksi & "," & rptotal & ",'x'"
        Else
            sql = "exec spPoDcDetailTmp 'Get'," & IdDC & "," & nomorpo & ",0,0,0,0,0,0,0,0"
        End If
        RsConn = conn.Execute(sql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()
            noUrut = 0
            Do While Not RsConn.EOF
                noUrut = +1
                strBarcode = RsConn("barcode").Value
                strplu = RsConn("kodeproduk").Value
                strnamabarang = RsConn("namapanjang").Value
                strC1 = RsConn("c1").Value
                strC2 = RsConn("c2").Value
                strharga = RsConn("hargaBeliTerakhir").Value
                strdisc1 = RsConn("disk6").Value

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
                listview2.Items.Add(itm)
                RsConn.MoveNext()

            Loop

        End If
        RsConn.Close()

    End Sub

    Private Sub BtnFindSupplier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFindSupplier.Click
        TxtKodeSupplier.Text = FrmFind.cari("MasterSupplier")
        If TxtKodeSupplier.Text = "0" Then
            TxtKodeSupplier.Text = ""
            Exit Sub
        Else
            getSupplier(TxtKodeSupplier.Text)
            TxtNamaSupplier.Text = NamaSupplier
            Panel2.Enabled = True
            BtnFindProduk.Focus()
        End If
    End Sub

    Private Sub BtnFindProduk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFindProduk.Click
        txtKodeProduk.Text = FrmFind.cari("DraftPOGO")
        If txtKodeProduk.Text = "0" Then
            txtKodeProduk.Text = ""
            Exit Sub
        Else
            getNamaProduk(txtKodeProduk.Text, IdSupplier)
            txtNamaProduk.Text = NamaProduk
            txtPrice.Text = Format(harga, "#,##0.##")
        End If
        txtqty.ReadOnly = False
        txtqty.Focus()
    End Sub

    Private Sub txtqty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtqty.KeyDown
        If e.KeyCode = Keys.Enter Then

            Call symbol()

            totalkoreksi = qtykoreksi * harga
            diskon1 = (totalkoreksi) * disk1 / 100
            totalkoreksi = totalkoreksi - diskon1
            pajakkoreksi = (totalkoreksi) * pajakpersen / 100
            rptotal = totalkoreksi + pajakkoreksi

            If flagedit = True Then
                sql = "exec spUpoDcDetailtmp 'AddPOGO'," & IdDC & "," & nomorUPO & "," & idProduk & "," & IdSupplier & ",'" & Ptag & "',0,0,0,0,0,0,0,0," & qtykoreksi & "," & harga & "," & disk1 & "," & disk2 & "," & totalkoreksi & "," & pajakkoreksi & "," & rptotal & ",'x'"
            Else
                sql = "exec spPoDcDetailTmp 'AddPOGO'," & IdDC & "," & nomorpo & "," & idProduk & "," & qtykoreksi & ",0,0,0,0,0,0"
            End If

            conn.Execute(sql)
            Call loaddata()

            txtKodeProduk.Clear()
            txtPrice.Clear()
            txtNamaProduk.Clear()
            txtqty.Clear()

            BtnEdit.Enabled = False
            BtnSimpan.Enabled = True
            ListView2.Enabled = True
            Panel1.Enabled = False
            BtnFindProduk.Focus()
            Call loaddata()
            ' Call hitung()
        End If
    End Sub

    Private Sub hitung()
        If flagedit = True Then
            sql = "exec spUpoDcDetailtmp 'Hitung'," & IdDC & "," & nomorUPO & "," & idProduk & "," & IdSupplier & ",'x',0,0,0,0,0,0,0,0," & qtykoreksi & ",0,0,0,0,0,0"
        Else
            sql = "exec spPoDcDetailTmp 'Hitung'," & IdDC & "," & nomorpo & "," & idProduk & ",0,0,0,0,0,0,0"
        End If
        RsConfig = Conn.Execute(sql)
        'If Not RsConfig.EOF Then
        '    txtharga.Text = Format(RsConfig("total").Value, "#,##0.##")
        '    txtdiscount.Text = Format(RsConfig("diskon").Value, "#,##0.##")
        '    txthargadiscount.Text = Format(RsConfig("ttldisk").Value, "#,##0.##")
        '    txtppn.Text = Format(RsConfig("pajak").Value, "#,##0.##")
        '    txttotal.Text = Format(RsConfig("subtotal").Value, "#,##0.##")
        '    txtIncPPN.Text = Format(RsConfig("subtotal").Value, "#,##0.##")
        'End If

    End Sub

    Private Sub txtqty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtqty.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(Keys.Back))
    End Sub

    Private Sub txtqty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtqty.TextChanged
        If txtqty.Text = "" Then txtqty.Text = 0
        qtykoreksi = txtqty.Text
        txtqty.Text = Format(qtykoreksi, "##,##0.##")
        txtqty.SelectionStart = Len(txtqty.Text)
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click

    End Sub
End Class