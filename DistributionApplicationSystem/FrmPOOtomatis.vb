Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Data.OleDb
Public Class FrmPOOtomatis
    Dim Conn, ConnMDB As New ADODB.Connection
    Dim RsConn, RsMdb, rsconnx As New ADODB.Recordset
    Dim sql, TermOP As String
    Dim idsupplier, idproduk, noUrut, strC2, qtykarton, Parsial As Integer
    Dim nomorpo As Int64
    Dim strqtypo, strharga, strdisc1, strdisc2, strnetto As Decimal
    Dim stridproduk, strplu, strnamabarang, strBarcode, alamatsupplier, telpsupplier As String
    Dim rpsystem, qtysystem, pajakkoreksi, totalkoreksi, qtykoreksi, rptotal As Decimal
    Dim tglbuat, dibuat, keterangan As String
    Dim flag, boleh As Boolean
    Dim tglpo, tglexp, tglkirim As Date


    Private Sub FrmPOOtomatis_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        nomorpo = 0
        nomorUPO = 0
    End Sub
    Private Sub FrmPOOtomatis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
       

        boleh = False
        Call bersih()
        Call LoadData()
        Call GbrTombol()
        Call getjenispo()

        If POok = False Then
            MsgBox("Ada data pendukung yang tidak lengkap !!, Silahkan hubungi IT Administrator", vbOKOnly + vbCritical, "Warning")
            Exit Sub
        End If

    End Sub
    Private Sub GbrTombol()
        Me.BtnApproval.Image = System.Drawing.Image.FromFile(icoapprove)
        Me.BtnEdit.Image = System.Drawing.Image.FromFile(icoedit)
        Me.BtnCancel.Image = System.Drawing.Image.FromFile(icocancel)
        Me.BtnSave.Image = System.Drawing.Image.FromFile(icosave)
        Me.BtnPrint.Image = System.Drawing.Image.FromFile(icoprint)
        Me.btnUpdHarga.Image = System.Drawing.Image.FromFile(icorefresh)
    End Sub

    Private Sub bersih()
        nomorpo = 0
        nomorUPO = 0
        TxtNoUPO.Clear()
        TxtKodeSupplier.Clear()
        TxtNamaSupplier.Clear()
        TxtNoFaktur.Clear()
        txtTglPO.Clear()
        txtTglProses.Clear()
        TxtExtTime.Clear()
        cbpartial.Checked = False

        txtharga.Clear()
        txtdiscount.Clear()
        txthargadiscount.Clear()
        txttotal.Clear()
        txtppn.Clear()
        txtIncPPN.Clear()
        cbpartial.Enabled = False


        TxtKodeSupplier.ReadOnly = True
        TxtNamaSupplier.ReadOnly = True
        TxtNoFaktur.ReadOnly = True
        txtTglPO.ReadOnly = True
        txtTglProses.ReadOnly = True
        txtharga.ReadOnly = True
        txtdiscount.ReadOnly = True
        txthargadiscount.ReadOnly = True
        txttotal.ReadOnly = True
        txtppn.ReadOnly = True
        txtIncPPN.ReadOnly = True
        TxtExtTime.ReadOnly = True

        TxtExtTime.BackColor = Color.White
        TxtKodeSupplier.BackColor = Color.White
        TxtNamaSupplier.BackColor = Color.White
        TxtNoFaktur.BackColor = Color.White
        txtTglPO.BackColor = Color.White
        txtTglProses.BackColor = Color.White
        txtharga.BackColor = Color.White
        txtdiscount.BackColor = Color.White
        txthargadiscount.BackColor = Color.White
        txttotal.BackColor = Color.White
        txtppn.BackColor = Color.White
        txtIncPPN.BackColor = Color.White


        btnedit.Enabled = False
        BtnSave.Enabled = False
        BtnApproval.Enabled = False
        BtnPrint.Enabled = False
        BtnCancel.Enabled = False
        btnUpdHarga.Enabled = False
        TglExpired.Enabled = False
        DtKirim.Enabled = False
    End Sub

    Private Sub BtnFindNoUPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFindNoUPO.Click
        Call bersih()
        TxtNoUPO.Text = FrmFind.cari("NomorUPOOto")
        If TxtNoUPO.Text = "0" Then
            TxtNoUPO.Text = ""
            Exit Sub
        End If

    End Sub

    Private Sub BtnFindSupplier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFindSupplier.Click
        TxtKodeSupplier.Clear()
        TxtNamaSupplier.Clear()
        TxtNoFaktur.Clear()
        TxtExtTime.Clear()
        txtharga.Clear()
        txthargadiscount.Clear()
        txtdiscount.Clear()
        txtppn.Clear()
        txtIncPPN.Clear()
        txttotal.Clear()
        txtTglPO.Clear()
        txtTglProses.Clear()


        If TxtNoUPO.Text = "" Then
            MsgBox("Nomor Draft PO belum di pilih !!!", vbOKOnly + vbCritical, "Info")
            Exit Sub
        End If

        TxtKodeSupplier.Text = FrmFind.cari("KoreksiUPO")
        If TxtKodeSupplier.Text = "0" Then
            TxtKodeSupplier.Text = ""
            nomorpo = 0
            Call LoadData()
            BtnPrint.Enabled = False
            btnUpdHarga.Enabled = False
            Exit Sub
        End If



        sql = "select a.*,b.idsupplier,b.namasupplier,c.alamatsupplier,c.noTelephone,b.termoffpayment,d.namauser  from podcheader a " & _
              "inner join mstsupplier b on a.idsupplier=b.idsupplier " & _
              "inner join MstSupplierPerDc c on a.idDc =c.idDc and a.idSupplier =c.idSupplier " & _
              "inner join MstUser d on a.idUser =d.idUser " & _
              "where a.nomorupo =" & nomorUPO & " and b.kodesupplier='" & TxtKodeSupplier.Text & "'"
        RsConn = Conn.Execute(sql)
        If Not RsConn.EOF Then
            TxtNamaSupplier.Text = RsConn("NamaSupplier").Value
            idsupplier = RsConn("idsupplier").Value
            TxtNoFaktur.Text = RsConn("nomorpo").Value
            alamatsupplier = RsConn("alamatsupplier").Value
            telpsupplier = RsConn("noTelephone").Value
            TxtExtTime.Text = RsConn("exttime").Value & ""
            keterangan = RsConn("keterangan").Value & ""
            TermOP = RsConn("termoffpayment").Value & ""
            dibuat = RsConn("namauser").Value

            If IsDBNull(RsConn("tglapprove").Value) Then
                txtTglProses.Text = ""

            Else
                txtTglProses.Text = Format(RsConn("tglapprove").Value, "dd-MM-yyyy ,HH:mm:ss")
            End If
            tglkirim = RsConn("Tglkirim").Value
            tglexp = RsConn("tglexpiredpo").Value
            tglpo = RsConn("tglPO").Value
            TglExpired.Value = tglexp
            txtTglPO.Text = Format(tglpo, "dd-MM-yyyy")
            DtKirim.Value = tglkirim
            cbpartial.Checked = RsConn("PartialPO").Value

            If RsConn("statusdata").Value = 0 Then
                If RsConn("tglexpiredpo").Value <= Format(Now, "yyyy-MM-dd") Then
                    btnedit.Enabled = False
                    BtnPrint.Enabled = False
                    btnUpdHarga.Enabled = True
                Else
                    btnedit.Enabled = True
                    BtnPrint.Enabled = True
                    btnUpdHarga.Enabled = False
                End If
            ElseIf RsConn("statusdata").Value >= 1 Then
                If RsConn("tglexpiredpo").Value <= Format(Now, "yyyy-MM-dd") Then
                    btnUpdHarga.Enabled = True
                End If
                btnedit.Enabled = False
                BtnPrint.Enabled = True
        
            End If
            nomorpo = TxtNoFaktur.Text
            tglbuat = Microsoft.VisualBasic.Left(txtTglProses.Text, 10)
            Call LoadData()
            Call jumlah()
        End If

    End Sub

    Private Sub TxtNoUPO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNoUPO.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(Keys.Back))
    End Sub

    Private Sub TxtNoUPO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNoUPO.TextChanged
        If TxtNoUPO.Text = "" Then
            nomorUPO = 0
            Exit Sub
        End If
        nomorUPO = TxtNoUPO.Text
    End Sub

  

    Private Sub LoadData()
        listview2.Columns.Clear()
        listview2.Items.Clear()
        listview2.View = Windows.Forms.View.Details
        listview2.GridLines = True
        listview2.FullRowSelect = True

        listview2.Columns.Add("No", 50)
        listview2.Columns.Add("Barcode", 100)
        listview2.Columns.Add("SKU", 120)
        listview2.Columns.Add("Description", 300)
        ' listview2.Columns.Add("Qty Carton", 90, HorizontalAlignment.Right)
        listview2.Columns.Add("Qty", 100, HorizontalAlignment.Right)
        listview2.Columns.Add("Harga", 120, HorizontalAlignment.Right)
        listview2.Columns.Add("Disc 1", 80, HorizontalAlignment.Right)
        listview2.Columns.Add("Disc 2", 80, HorizontalAlignment.Right)
        listview2.Columns.Add("Total Netto", 120, HorizontalAlignment.Right)


        sql = "exec spPoDcDetail 'Get'," & IdDC & "," & nomorUPO & "," & nomorpo & ",0,0,0,0,0,0,0,0,0,0,0,0"
        RsConn = Conn.Execute(sql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()
            noUrut = 1
            Do While Not RsConn.EOF
                strBarcode = RsConn("barcode").Value
                strplu = RsConn("kodeproduk").Value
                strnamabarang = RsConn("namapanjang").Value
                'qtykarton = RsConn("karton").Value
                strqtypo = RsConn("qtyPo").Value
                strharga = RsConn("hargaBeliTerakhir").Value
                strdisc1 = RsConn("disk1").Value
                strdisc2 = RsConn("disk2").Value
                strnetto = RsConn("rpPo").Value

                'qtykarton = strqtypo / strC2

                Dim arr(10) As String
                Dim itm As ListViewItem

                arr(0) = noUrut
                arr(1) = strBarcode
                arr(2) = strplu
                arr(3) = strnamabarang
                ' arr(4) = qtykarton.ToString("N")
                arr(4) = strqtypo.ToString("N")
                arr(5) = strharga.ToString("N")
                arr(6) = strdisc1.ToString("N")
                arr(7) = strdisc2.ToString("N")
                arr(8) = strnetto.ToString("N")

                itm = New ListViewItem(arr)
                listview2.Items.Add(itm)
                noUrut = noUrut + 1
                RsConn.MoveNext()

            Loop

        End If
        RsConn.Close()
    End Sub
    Private Sub jumlah()
        sql = "Select * from podcheader where idsupplier=" & idsupplier & " and nomorpo=" & nomorpo & " and nomorupo=" & nomorUPO
        RsConn = Conn.Execute(sql)
        If Not RsConn.EOF Then
            ' txtharga.Text = Format(RsConn("totalrp").Value + RsConn("totaldiskon").Value, "##,##0.##")
            txtharga.Text = Format(RsConn("totalrp").Value, "#,##0.#0")
            txtdiscount.Text = Format(RsConn("totaldiskon").Value, "#,##0.#0")
            txthargadiscount.Text = Format(RsConn("totalrp").Value - RsConn("totaldiskon").Value, "#,##0.#0")
            txtppn.Text = Format(RsConn("totalpajak").Value, "#,##0.#0")
            txtIncPPN.Text = Format(RsConn("totalrppo").Value, "#,##0.#0")
            txttotal.Text = Format(RsConn("totalrppo").Value, "#,##0.#0")
            rptotal = RsConn("totalrppo").Value
            Dim xx As String = rptotal.ToString
            nilaiterbilang = TerbilangDesimal(xx)

        End If

    End Sub

    Private Sub listview2_DrawColumnHeader(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawListViewColumnHeaderEventArgs) Handles listview2.DrawColumnHeader

        Dim strFormat As New StringFormat()


        If e.Header.TextAlign = HorizontalAlignment.Center Then
            strFormat.Alignment = StringAlignment.Center
        ElseIf e.Header.TextAlign = HorizontalAlignment.Right Then
            strFormat.Alignment = StringAlignment.Far
        End If

        e.DrawBackground()
        e.Graphics.FillRectangle(Brushes.SteelBlue, e.Bounds)
        Dim headerFont As New Font("Arial", 10, FontStyle.Bold)

        e.Graphics.DrawString(e.Header.Text, headerFont, Brushes.White, e.Bounds, strFormat)


    End Sub

    Private Sub btnedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnedit.Click
        'boleh = FrmValidasi.cari("PO")
        boleh = True
        If boleh = True Then
            btnedit.Enabled = False
            BtnSave.Enabled = True
            BtnApproval.Enabled = False
            BtnPrint.Enabled = False
            BtnCancel.Enabled = True

            TxtExtTime.ReadOnly = False
            TxtExtTime.SelectAll()
            TxtExtTime.Focus()
            TglExpired.Enabled = True
            DtKirim.Enabled = True
            cbpartial.Enabled = True
            boleh = False

        Else
            MsgBox("Password yang anda masukkan salah !!" & vbCrLf _
                 & "Anda tidak berhak merubah data..", vbOKOnly + vbCritical, "Warning !!")
            Exit Sub
        End If
    End Sub

    Private Sub BtnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click

        If TglExpired.Value.Date <= Now.Date Then
            MsgBox("Tanggal Expired Tidak boleh kurang " & vbCrLf _
                 & "atau sama dengan hari ini!!!", vbOKOnly + vbExclamation, "Warning")
            TglExpired.Focus()
            Exit Sub
        End If

        If DtKirim.Value.Date <= Now.Date Then
            MsgBox("tanggal Kirim Tidak boleh kurang " & vbCrLf _
                 & "atau sama dengan hari ini!!!", vbOKOnly + vbExclamation, "Warning")
            DtKirim.Focus()
            Exit Sub
        End If


        sql = "exec spPoDcDetail 'cekdata'," & IdDC & "," & nomorUPO & "," & nomorpo & ",0,0,0,0,0,0,0,0,0,0,0,0"
        RsConn = Conn.Execute(sql)
        If Not RsConn.EOF Then
            RsConn.MoveFirst()
            MsgBox("Harga beli produk " & RsConn("namaPanjang").Value & " masih Nol(0) !!", vbOKOnly + vbCritical, "Info")
            Exit Sub
        End If


        Dim result2 As DialogResult = MessageBox.Show("Tgl Expired PO =" & Format(TglExpired.Value, "dd-MM-yyyy"), _
                 "Informasi !!", _
                 MessageBoxButtons.YesNo, _
                 MessageBoxIcon.Question)
        If result2 = DialogResult.Yes Then
            keterangan = "PO Otomatis"
            sql = "exec  sppodcheader 'edit'," & IdDC & "," & nomorUPO & "," & nomorpo & "," & idsupplier & ",'2017-01-01','" & Format(DtKirim.Value, "yyyy-MM-dd") & "','" & Format(TglExpired.Value, "yyyy-MM-dd") & "',0,0,0,0,0,0,'" & StrNamaUser & "'," & Val(TxtExtTime.Text) & ",'" & keterangan & "'," & Parsial
            Conn.Execute(sql)
            MsgBox("PO berhasil di update , silahkan Approve PO", vbOKOnly + vbInformation, "Info")
            btnedit.Enabled = True
            BtnSave.Enabled = False
            BtnApproval.Enabled = True
            BtnCancel.Enabled = False
            BtnPrint.Enabled = False
            TglExpired.Enabled = False
            DtKirim.Enabled = False
            cbpartial.Enabled = False
        Else
            Exit Sub
        End If

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
            If boleh = True Then
                sql = "exec  sppodcheader 'approve'," & IdDC & "," & nomorUPO & "," & nomorpo & "," & idsupplier & ",'2017-01-01','2017-01-01','" & Format(TglExpired.Value, "yyyy-MM-dd") & "',0,0,0,0,0,0,'" & StrNamaUser & "',0,'ket',1"
                Conn.Execute(sql)
                MsgBox("PO berhasil di approval", vbOKOnly + vbInformation, "Info")
                txtTglProses.Text = Format(Now, "dd-MM-yyyy, HH:ss:mm")

                btnedit.Enabled = True
                BtnSave.Enabled = False
                BtnApproval.Enabled = True
                BtnPrint.Enabled = False
                TglExpired.Enabled = False
                BtnCancel.Enabled = False
            Else
                MsgBox("Password syang anda masukkan salah !!" & vbCrLf _
                      & "Anda tidak berhak merubah data..", vbOKOnly + vbCritical, "Warning !!")
                Exit Sub
            End If

        Else
            Exit Sub
        End If



        btnedit.Enabled = False
        BtnSave.Enabled = False
        BtnApproval.Enabled = False
        BtnPrint.Enabled = True
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

        strSQL = "exec spPoDcDetail 'Get'," & IdDC & "," & nomorUPO & "," & nomorpo & ",0,0,0,0,0,0,0,0,0,0,0,0"

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
        paramList.Add(New ReportParameter("FormHeader", "PURCHASE ORDER (Otomatis)", True))
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
        paramList.Add(New ReportParameter("TglPO", Me.txtTglPO.Text, True))
        paramList.Add(New ReportParameter("TglExpired", Format(Me.TglExpired.Value, "dd-MM-yyyy"), True))
        paramList.Add(New ReportParameter("TglProses", Me.txtTglProses.Text, True))
        paramList.Add(New ReportParameter("TglBuat", tglbuat, True))
        paramList.Add(New ReportParameter("TtlHargaPembelian", Me.txtharga.Text, True))
        paramList.Add(New ReportParameter("TtlDiscount", Me.txtdiscount.Text, True))
        paramList.Add(New ReportParameter("TtlSetelahDiscount", Me.txthargadiscount.Text, True))
        paramList.Add(New ReportParameter("PpnIn", Me.txtppn.Text, True))
        paramList.Add(New ReportParameter("TtlIncPPN", Me.txtIncPPN.Text, True))
        paramList.Add(New ReportParameter("TtlFaktur", Me.txttotal.Text, True))
        paramList.Add(New ReportParameter("terbilang", nilaiterbilang, True))
        paramList.Add(New ReportParameter("TglKirim", Format(DtKirim.Value, "dd-MM-yyyy"), True))
        paramList.Add(New ReportParameter("dibuat", dibuat, True))
        paramList.Add(New ReportParameter("keterangan", keterangan, True))
        paramList.Add(New ReportParameter("TOP", TermOP, True))

        Dim ReportViewerForm As New FrmReport
        ReportViewerForm.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptPO.rdlc"
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewerForm.ReportViewer1.LocalReport.SetParameters(paramList)
        ReportViewerForm.ReportViewer1.RefreshReport()
        ReportViewerForm.Show()

    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Call bersih()
        Call LoadData()
    End Sub

    Private Sub btnUpdHarga_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdHarga.Click
        strsql = "exec  sppodcheader 'CekData'," & IdDC & "," & nomorUPO & "," & nomorpo & "," & idsupplier & ",'2017-01-01','" & Format(DtKirim.Value, "yyyy-MM-dd") & "','" & Format(TglExpired.Value, "yyyy-MM-dd") & "'," & Val(TxtExtTime.Text) & ",0,0,0,0,0,'" & StrNamaUser & "'," & Val(TxtExtTime.Text) & ",'" & keterangan & "'," & Parsial
        RsConn = Conn.Execute(sql)
        If RsConn("totalqty").Value > 0 Then
            Call copyPO()
            boleh = False
        Else
            MsgBox("Item produk sudah terpenuhi semua!!" & vbCrLf _
                  & "silahkan cek No PO yang lain ", vbOKOnly + vbInformation, "Info")
            Exit Sub
        End If

    End Sub

    Private Sub copyPO()
        Dim objConn As OleDbConnection
        Dim objCmd As OleDbCommand
        Dim objReader As OleDbDataReader
        Dim objDataSet As DataSet = New DataSetPO
        Dim strSQL, strCONN As String
        Dim nox As Integer

        GetStringKoneksi() '---1
        strCONN = StrKoneksi '----2

        keterangan = "PO Copy dari :" & nomorpo
        strSQL = "exec  sppodcheader 'CopyPO'," & IdDC & "," & nomorUPO & "," & nomorpo & "," & idsupplier & ",'2017-01-01','" & Format(DtKirim.Value, "yyyy-MM-dd") & "','" & Format(TglExpired.Value, "yyyy-MM-dd") & "'," & Val(TxtExtTime.Text) & ",0,0,0,0,0,'" & StrNamaUser & "'," & Val(TxtExtTime.Text) & ",'" & keterangan & "'," & Parsial

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

    Private Sub TxtExtTime_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtExtTime.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(Keys.Back))
    End Sub

   
    Private Sub cbpartial_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbpartial.CheckedChanged
        If cbpartial.Checked = True And cbpartial.Enabled = True Then
            Parsial = 1
            TxtExtTime.ReadOnly = False
        ElseIf cbpartial.Checked = True And cbpartial.Enabled = False Then
            Parsial = 1
            TxtExtTime.ReadOnly = True
        Else
            Parsial = 0
            TxtExtTime.Text = 0
            TxtExtTime.ReadOnly = True
        End If
    End Sub
End Class