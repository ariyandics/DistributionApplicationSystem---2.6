Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Data.OleDb
Public Class FrmTOManual
    Dim sql As String
    Dim conn As New ADODB.Connection
    Dim RsConn As New ADODB.Recordset
    Dim barcode, plu As String
    Dim qty, qtyctn, harga, pajak, subtotal, disk1, disk2, netto As Double
    Dim flagadd, flagedit As Boolean
    Dim strBarcode, strplu, strnamabarang As String
    Dim noUrut, strqty As Int64
    Dim strharga, strppn, strnetto As Double
    Dim ttlqty, ttlitem, ttlvalue, ttlpajak, ttlnett As Double

    Private Sub FrmTOManual_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        BtnFindNoFaktur.Focus()
    End Sub

    Private Sub FrmTOManual_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Call deletetmp()
        nomorTO = 0
    End Sub
    Private Sub FrmTOManual_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Call loaddata()

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

        BtnAdd.Enabled = True
        BtnApproval.Enabled = False
        BtnEdit.Enabled = False
        BtnCancel.Enabled = False
        BtnSave.Enabled = False
        BtnPrint.Enabled = False
        CBLock.Checked = True
        CBLock.Enabled = False
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
            sql = "exec spToKeTokoDetailManualTMP 'Get'," & IdDC & "," & kodetoko & "," & nomorTO & ",0,0,0,0,0,0,0"
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
                CBLock.Enabled = True
            Else
                MsgBox("Anda belum memilih Toko !!!", vbOKOnly + vbInformation, "Info")
                Exit Sub
            End If
        End If


    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Call deletetmp()
        Call tombol()

        If flagadd = True Then
            Call bersih()
            BtnAdd.Focus()
        ElseIf flagedit = True Then
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
        conn.Execute("delete from ToKeTokoDetailManualTMP where nomorTO=" & nomorTO)
    End Sub

    Private Sub getnomor()

        sql = "Select isnull(max(nomorTO),0 )as nomor from ToKeTokoDetailManualTMP"
        RsConfig = conn.Execute(sql)
        If RsConfig("nomor").Value > 0 Then
            nomorTO = RsConfig("nomor").Value + 1
        Else
            nomorTO = 1
        End If
        sql = "exec spToKeTokoDetailManualTMP 'add'," & IdDC & "," & kodetoko & "," & nomorTO & ",0,0,0,0,0,0,0"
        conn.Execute(sql)
        txtNoFaktur.Text = nomorTO
    End Sub
    Private Sub cektable()
        sql = "Select TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='ToKeTokoDetailManualTMP'"
        RsConfig = conn.Execute(sql)
        If RsConfig.EOF Then
            sql = "select top 0 * into ToKeTokoDetailManualTMP from ToKeTokoDetailManual "
            conn.Execute(sql)
        End If

    End Sub

    Private Sub btnFindToko_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindToko.Click
        TxtKodetoko.Text = FrmFind.cari("MasterToko")
    End Sub

    Private Sub txtNoFaktur_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNoFaktur.TextChanged
        If txtNoFaktur.Text = "0" Then txtNoFaktur.Text = ""
        If txtNoFaktur.Text = "" Then Exit Sub
        nomorTO = Val(txtNoFaktur.Text)

    End Sub


    Private Sub txtBarcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBarcode.KeyDown

        If e.KeyCode = Keys.Enter Then
            scan(txtBarcode.Text)
            If idProduk > 0 Then
                txtnamabarang.Text = NamaProduk

                If CBLock.Checked = True Then
                    txtqty.Text = 1
                    Call simpanTmp()
                    Call loaddata()
                    txtBarcode.Clear()
                    txtnamabarang.Clear()
                    BtnSave.Enabled = True
                Else
                    txtqty.ReadOnly = False
                    txtqty.Text = ""
                    txtqty.Focus()
                End If

            Else
                MsgBox("Produk tidak bisa di TO ke toko tujuan..!!", vbOKOnly + vbCritical, "Info")
                txtBarcode.Clear()
                txtnamabarang.Clear()
                Exit Sub
            End If
        End If

    End Sub

    Private Sub txtBarcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBarcode.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(Keys.Back))
    End Sub

    Private Sub simpanTmp()
        If CBLock.Checked = True Then
            sql = "exec spToKeTokoDetailManualTMP 'getid'," & IdDC & "," & kodetoko & "," & nomorTO & "," & idProduk & ",0,0,0,0," & qty & ",0"
            RsConfig = conn.Execute(sql)
            If Not RsConfig.EOF Then
                qty = RsConfig("qtyto").Value + 1
            Else
                qty = 1
            End If
        End If

        sql = "exec spToKeTokoDetailManualTMP 'Add'," & IdDC & "," & kodetoko & "," & nomorTO & "," & idProduk & ",0,0,0," & IdPajak & "," & qty & ",0"
        conn.Execute(sql)

        Call hitung()

    End Sub

    Private Sub txtqty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtqty.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(txtqty.Text) = 0 Then
                Exit Sub
            End If

            BtnSave.Enabled = True
            Call simpanTmp()
            Call loaddata()
            CBLock.Checked = True
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

    Private Sub CBLock_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBLock.CheckedChanged
        If CBLock.Checked = True Then
            txtqty.ReadOnly = True
        Else
            txtqty.ReadOnly = False
        End If
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Call simpan()
    End Sub

    Private Sub simpan()
        Dim result2 As DialogResult = MessageBox.Show("Simpan TO Manual ??", _
               "Question !!", _
               MessageBoxButtons.YesNo, _
               MessageBoxIcon.Question)
        If result2 = DialogResult.Yes Then
            Call tombol()
           If flagadd = True Then
                RsConfig = conn.Execute("select  dbo.fcGetNomorTOManual(" & IdDC & ") xx")
                nomorTO = RsConfig("xx").Value

                conn.Execute("update ToKeTokoDetailManualTMP set nomorto=" & nomorTO & " where kodetoko=" & kodetoko & " and nomorto=" & txtNoFaktur.Text)
                conn.Execute("exec spToKeTokoHeaderManual 'add'," & IdDC & "," & kodetoko & "," & nomorTO & "," & ttlitem & "," & ttlqty & "," & ttlvalue & "," & ttlpajak & "," & ttlnett & ",'" & txtcatatan.Text & "','" & txtuser.Text & "',null,0")
                txtNoFaktur.Text = nomorTO
            End If
            If flagedit = True Then

                conn.Execute("exec spToKeTokoHeaderManual 'edit'," & IdDC & "," & kodetoko & "," & nomorTO & "," & ttlitem & "," & ttlqty & "," & ttlvalue & "," & ttlpajak & "," & ttlnett & ",'" & txtcatatan.Text & "','" & txtuser.Text & "',null,0")

            End If

            Call pesan(3)
            flagadd = False
            flagedit = False
            Panel1.Enabled = True
            BtnFindNoFaktur.Enabled = True
            btnFindToko.Enabled = False
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
            sql = "exec spToKeTokoDetailManual 'GetStok'," & IdDC & "," & kodetoko & "," & nomorTO & "," & idProduk & ",0,0,0,0," & qty & ",0"
            RsConfig = conn.Execute(sql)
            If Not RsConfig.EOF Then
                MsgBox("Stock " & RsConfig("namapanjang").Value & " tidak mencukupi!!!", vbOKOnly + vbCritical, "Gagal Approve")
                Exit Sub
            Else
                Call tombol()

                If conn.State = 0 Then
                    GetStringKoneksi()
                    conn.Open(StrKoneksi)
                End If

                conn.Execute("exec spToKeTokoHeaderManual 'Approve'," & IdDC & "," & kodetoko & "," & nomorTO & "," & ttlitem & "," & ttlqty & "," & ttlvalue & "," & ttlpajak & "," & ttlnett & ",'" & txtcatatan.Text & "','" & txtuser.Text & "',null,1")
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
            sql = "exec spToKeTokoDetailManualTMP 'Hitung'," & IdDC & "," & kodetoko & "," & nomorTO & "," & idProduk & ",0,0,0,0," & qty & ",0"
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

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click

        conn.Execute("Insert into ToKeTokoDetailManualTMP select * from ToKeTokoDetailManual where nomorto=" & nomorTO & " and kodetoko=" & kodetoko)
        Call tombol()
        BtnCancel.Enabled = True
        BtnSave.Enabled = True

        Panel1.Enabled = False
        txtBarcode.ReadOnly = False
        CBLock.Enabled = True
        flagedit = True
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
        CBLock.Enabled = False

    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Call cetak()
    End Sub

    Private Sub cetak()
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
        paramList.Add(New ReportParameter("Judul", "BUKTI PENGIRIMAN BARANG - MANUAL", True))
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


        Dim ReportViewerForm As New FrmReport
        ReportViewerForm.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptBPB.rdlc"
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewerForm.ReportViewer1.LocalReport.SetParameters(paramList)
        ReportViewerForm.ReportViewer1.RefreshReport()
        ReportViewerForm.Show()
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub txtBarcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBarcode.TextChanged

    End Sub
End Class