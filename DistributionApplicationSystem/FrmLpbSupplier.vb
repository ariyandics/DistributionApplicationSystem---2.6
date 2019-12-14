Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Data.OleDb
Public Class FrmLpbSupplier

    Dim sql As String
    Dim conn As New ADODB.Connection
    Dim RsConn As New ADODB.Recordset
    Dim barcode, plu, namaproduk, alamatsupplier, telpsupplier, dibuat As String
    Dim qty, harga, pajak, subtotal, disk1, disk2, netto As Double
    Dim qtyctn, qtypo, qtyrcv, idsupp As Int64
    Dim flag As Boolean
    Dim rptotal As Decimal
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand


    Private Sub FrmLpbSupplier_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        BtnAdd.Focus()
    End Sub

    Private Sub FrmLpbSupplier_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        cancel()
        ClearData()
    End Sub
    Private Sub FrmLpbSupplier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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


        ClearData()
        Disable()
        DTPTglTiba.MaxDate = Now
        flag = False
        Me.BtnAdd.Enabled = True
        Call LoadDataTmp()
        Call GbrTombol()
        BtnFindLpb.Enabled = True
    End Sub

    Private Sub GbrTombol()
        Me.BtnAdd.Image = System.Drawing.Image.FromFile(icoadd)
        Me.BtnEdit.Image = System.Drawing.Image.FromFile(icoedit)
        Me.BtnCancel.Image = System.Drawing.Image.FromFile(icocancel)
        Me.BtnSave.Image = System.Drawing.Image.FromFile(icosave)
        Me.BtnPrint.Image = System.Drawing.Image.FromFile(icoprint)
    End Sub

    Private Sub BtnFindNoRetur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
        Call ClearData()

        If flag = True Then
            TxtNoPo.Text = FrmFind.cari("NomorPORCV")
            If TxtNoPo.Text = "0" Then
                TxtNoPo.Text = ""
                Exit Sub
            End If
            Call lihatPO()
            InsertTmp()
            ' Call LoadDataTmp()
        End If


    End Sub
    Private Sub lihatPO()
        sql = "exec spPoDcHeader 'get'," & IdDC & ",0," & TxtNoPo.Text & ",0,'2017-01-01','2017-01-01','2017-01-01',0,0,0,0,0,0,'" & StrNamaUser & "',0,'ket',1"
        RsConfig = conn.Execute(sql)
        If Not RsConfig.EOF Then
            TxtKodeSupplier.Text = RsConfig("kodesupplier").Value
            TxtNamaSupplier.Text = RsConfig("namasupplier").Value
            idsupp = RsConfig("idsupplier").Value

            TxtTglPO.Text = Microsoft.VisualBasic.Right(RsConfig("tglpo").Value, 2) & "-" & Microsoft.VisualBasic.Mid(RsConfig("tglpo").Value, 6, 2) & "-" & Microsoft.VisualBasic.Left(RsConfig("tglpo").Value, 4)
            TxtUser.Text = StrNamaUser
            LblPartial.Visible = True
            If RsConfig("partialpo").Value = 1 Then
                LblPartial.Text = "PARTIAL PO"
            Else
                LblPartial.Text = "NON PARTIAL PO"
            End If
        End If
        Call namasupp()
    End Sub
    Private Sub lihatLPB()


        sql = "exec spLpbSupplierHeaderDetail 'LPBHeader',0,0," & Me.txtNoLPB.Text & ",0,0,'2017-10-01','" & StrNamaUser & "','x','nopol','drv'"
        RsConfig = conn.Execute(sql)
        If Not RsConfig.EOF Then
            TxtNoPo.Text = RsConfig("nomorpo").Value
            txtsj.Text = RsConfig("nomorsj").Value
            TxtKodeSupplier.Text = RsConfig("kodesupplier").Value
            TxtNamaSupplier.Text = RsConfig("namasupplier").Value
            TxtTglPO.Text = Microsoft.VisualBasic.Right(RsConfig("tglpo").Value, 2) & "-" & Microsoft.VisualBasic.Mid(RsConfig("tglpo").Value, 6, 2) & "-" & Microsoft.VisualBasic.Left(RsConfig("tglpo").Value, 4)
            DTPTglTiba.Value = RsConfig("tgltiba").Value
            txtNoLPB.Text = RsConfig("nomorlpb").Value
            TxtUser.Text = RsConfig("idusercreate").Value
            TxtTglApprove.Text = Format(RsConfig("tglapprove").Value, "dd-MM-yyyy")
            TxtTglBayar.Text = Microsoft.VisualBasic.Right(RsConfig("tglbayar").Value, 2) & "-" & Microsoft.VisualBasic.Mid(RsConfig("tglbayar").Value, 6, 2) & "-" & Microsoft.VisualBasic.Left(RsConfig("tglbayar").Value, 4)
            dibuat = RsConfig("namauser").Value
            TxtNamaDriver.Text = RsConfig("Namadriver").Value & ""
            TxtNoPol.Text = RsConfig("Nopol").Value & ""

            Me.TxtTothargaPembelian.Text = Format(RsConfig("totalrp").Value, "#,##0.##")
            Me.TxtTotDisc.Text = Format(RsConfig("totaldiskon").Value, "#,##0.##")
            Me.TxtIncDisc.Text = Format(RsConfig("totalrp").Value - RsConfig("totaldiskon").Value, "#,##0.##")
            Me.TxtPPN.Text = Format(RsConfig("totalpajak").Value, "#,##0.##")
            Me.TxtTotalIncPpn.Text = Format((RsConfig("totalrp").Value - RsConfig("totaldiskon").Value) + (RsConfig("totalpajak").Value), "#,##0.##")
            Me.TxtTotBayar.Text = Me.TxtTotalIncPpn.Text
            rptotal = (RsConfig("totalrp").Value - RsConfig("totaldiskon").Value) + (RsConfig("totalpajak").Value)
            Dim xx As String = rptotal
            nilaiterbilang = TerbilangDesimal(xx)


        End If
        Call namasupp()
    End Sub

    Private Sub InsertTmp()

        Me.lv2.Enabled = True
        If flag = True Then
            sql = "exec spLpbSupplierHeaderDetail 'InsTmp',0,0," & Me.TxtNoPo.Text & ",0,0,'2017-10-01','" & StrNamaUser & "','x','nopol','drv'"
        Else
            sql = "exec spLpbSupplierHeaderDetail 'InsTmpLPB',0,0," & Me.txtNoLPB.Text & ",0,0,'2017-10-01','" & StrNamaUser & "','x','nopol','drv'"
        End If
        conn.Execute(sql)

        sql = "exec spLpbSupplierHeaderDetail 'getTmpx',0,0," & Me.TxtNoPo.Text & ",0,0,'2017-10-01','" & StrNamaUser & "','x','nopol','drv'"
        RsConn = conn.Execute(sql)

        If flag = True Then
            If RsConn.EOF Then
                MsgBox("Nomor PO ini sudah terpenuhi semua...!!", vbOKOnly + vbInformation, "Info")
                cancel()
                ClearData()
                Exit Sub
            Else
                LoadDataTmp()
                LoadSumPo()
                Call Disable()
                BtnCancel.Enabled = True
                BtnSave.Enabled = True
                BtnEdit.Enabled = True
                txtsj.ReadOnly = False
                TxtNoPol.ReadOnly = False
                TxtNamaDriver.ReadOnly = False
                TxtNoPol.Focus()
                DTPTglTiba.Enabled = True
            End If
        Else
            LoadDataTmp()
            ' LoadSumPo()
        End If

    End Sub

    Private Sub LoadDataTmp()
        Dim strfind As Int64
        lv2.Columns.Clear()
        lv2.Items.Clear()
        lv2.View = Windows.Forms.View.Details
        lv2.GridLines = True
        lv2.FullRowSelect = True

        strfind = "0"
      
        If flag = True Then
            strfind = Val(TxtNoPo.Text)
        Else
            strfind = Val(txtNoLPB.Text)
        End If



        lv2.Columns.Add("Nomor", 50)
        lv2.Columns.Add("Barcode", 0)
        lv2.Columns.Add("SKU", 100)
        lv2.Columns.Add("Description", 320)
        lv2.Columns.Add("Qty", 80, HorizontalAlignment.Right)
        lv2.Columns.Add("Qty Ctn", 80, HorizontalAlignment.Right)
        lv2.Columns.Add("Cost", 80, HorizontalAlignment.Right)
        lv2.Columns.Add("Disc1", 80, HorizontalAlignment.Right)
        lv2.Columns.Add("Disc2", 80, HorizontalAlignment.Right)
        lv2.Columns.Add("Netto", 100, HorizontalAlignment.Right)

        If flag = True Then
            sql = "exec spLpbSupplierHeaderDetail 'LoadDataPO',0,0,'" & strfind & "',0,0,'2017-10-01','" & StrNamaUser & "','X','nopol','DRV'"
        Else
            sql = "exec spLpbSupplierHeaderDetail 'LoadDataLPB',0,0,'" & strfind & "',0,0,'2017-10-01','" & StrNamaUser & "','X','nopol','DRV'"
        End If

        RsConn = conn.Execute(sql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()
            Dim nomor As Integer = 1
            Do While Not RsConn.EOF

                barcode = RsConn("barcode").Value
                plu = RsConn("kodeProduk").Value
                namaproduk = RsConn("namaPanjang").Value
                qty = RsConn("QtyPO").Value
                qtyctn = RsConn("Karton").Value
                harga = RsConn("hargabeliterakhir").Value
                disk1 = RsConn("disk1").Value
                disk2 = RsConn("disk2").Value
                netto = RsConn("rppo").Value


                Dim arr(10) As String
                Dim itm As ListViewItem
                arr(0) = nomor
                arr(1) = barcode
                arr(2) = plu
                arr(3) = namaproduk
                arr(4) = qty.ToString("N")
                arr(5) = qtyctn.ToString("N")
                arr(6) = harga.ToString("N")
                arr(7) = disk1.ToString("N")
                arr(8) = disk2.ToString("N")
                arr(9) = netto.ToString("N")
                itm = New ListViewItem(arr)
                lv2.Items.Add(itm)
                nomor += 1
                RsConn.MoveNext()
            Loop

        End If
        RsConn.Close()

    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If conn.State = 0 Then
            Call GetStringKoneksi()
            conn.Open(StrKoneksi)
        End If

        If TxtNoPol.Text = "" Then
            MsgBox("No Pol Kendaraan belum di isi !!!", vbOKOnly + vbCritical, "Info")
            TxtNoPol.Focus()
            Exit Sub
        End If

        If TxtNamaDriver.Text = "" Then
            MsgBox("Nama Driver belum di isi !!!", vbOKOnly + vbCritical, "Info")
            TxtNamaDriver.Focus()
            Exit Sub
        End If

        If txtsj.Text = "" Then
            MsgBox("No Surat jalan belum di isi !!!", vbOKOnly + vbCritical, "Info")
            txtsj.Focus()
            Exit Sub
        End If
        InsertData()
    End Sub

    Private Sub InsertData()
        Dim vTglTiba As Date
        vTglTiba = Year(Me.DTPTglTiba.Value) & "-" & Month(Me.DTPTglTiba.Value) & "-" & Microsoft.VisualBasic.DateAndTime.Day(Me.DTPTglTiba.Value)

        If MessageBox.Show("Apakah sudah yakin dengan data Po tersebut dan akan diterima ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            GetIdSupplier(Me.TxtKodeSupplier.Text)
            namadcAktif()

            GetStringKoneksi()
            GetKoneksiSQLClient()
            sql = "exec spLpbSupplierHeaderDetail 'Add'," & IdDC & "," & IdSupplier & "," & Me.TxtNoPo.Text & ",0,0,'" & Format(vTglTiba, "yyyy-MM-dd") & "','" & StrNamaUser & "','" & Trim(txtsj.Text) & "','" & Trim(TxtNoPol.Text) & "','" & Trim(TxtNamaDriver.Text) & "'"
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
                    Me.txtNoLPB.Text = (dr.Item("NoTO"))
                End If
            End If
            dr.Close()
            GetTgl()
            Call Disable()
            Me.BtnAdd.Enabled = True
            Me.BtnFindLpb.Enabled = True
            Me.BtnPrint.Enabled = True
            flag = False
        End If
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Call ClearData()
        Call Disable()
        BtnCancel.Enabled = True
        flag = True
        Call LoadDataTmp()
        txtsj.ReadOnly = False
        BtnFind.Enabled = True
        BtnFind.Focus()
    End Sub

    Private Sub LoadSumPo()
        If Me.TxtNoPo.Text = "" Then
            Me.TxtNoPo.Text = 0
        End If
        sql = "exec spLpbSupplierHeaderDetail 'LoadDataSumPO',0,0," & Me.TxtNoPo.Text & ",0,0,'2017-10-01','" & StrNamaUser & "','x','nopol','drv'"
        RsConn = conn.Execute(sql)

        If Not RsConn.EOF Then
            If IsDBNull(RsConn("totPembelian").Value) Then
                Me.TxtTothargaPembelian.Text = 0
            ElseIf IsDBNull(RsConn("totdiskon").Value) Then
                Me.TxtTotDisc.Text = 0
            ElseIf IsDBNull(RsConn("TotIncDisc").Value) Then
                Me.TxtIncDisc.Text = 0
            ElseIf IsDBNull(RsConn("totpajak").Value) Then
                Me.TxtPPN.Text = 0
            ElseIf IsDBNull(RsConn("TotIncPPn").Value) Then
                Me.TxtTotalIncPpn.Text = 0
            ElseIf IsDBNull(RsConn("TotIncPPn").Value) Then
                Me.TxtTotBayar.Text = 0

            Else

                Me.TxtTothargaPembelian.Text = Format(RsConn("totPembelian").Value, "#,##0.##")
                Me.TxtTotDisc.Text = Format(RsConn("totdiskon").Value, "#,##0.##")
                Me.TxtIncDisc.Text = Format(RsConn("TotIncDisc").Value, "#,##0.##")
                Me.TxtPPN.Text = Format(RsConn("totpajak").Value, "#,##0.##")
                Me.TxtTotalIncPpn.Text = Format(RsConn("TotIncPPn").Value, "#,##0.##")
                Me.TxtTotBayar.Text = Format(RsConn("TotIncPPn").Value, "#,##0.##")
                rptotal = RsConn("TotIncPPn").Value
                Dim xx As String = rptotal.ToString
                nilaiterbilang = TerbilangDesimal(xx)
            End If

        End If
    End Sub

    Private Sub Disable()
        Me.BtnAdd.Enabled = False
        Me.BtnCancel.Enabled = False
        Me.BtnEdit.Enabled = False
        Me.BtnSave.Enabled = False
        Me.BtnPrint.Enabled = False
        Me.BtnFind.Enabled = False
        Me.TxtQty.Enabled = False
        Me.DTPTglTiba.Enabled = False
        BtnFindLpb.Enabled = False
    End Sub

    Private Sub cancel()
        flag = False
        CancelData()
        Call Disable()
        BtnAdd.Enabled = True
        BtnFindLpb.Enabled = True
        Call LoadDataTmp()
    End Sub

    Private Sub edit()
        If Me.TxtKodeProduk.Text = "" And TxtNamaBarang.Text = "" Then
            MsgBox("Silahkan pilih dahulu Item produk yang akan di ubah", vbInformation, "Perhatian")
            Exit Sub
        End If
        Me.BtnEdit.Enabled = False
        Me.BtnCancel.Enabled = True
        Me.BtnSave.Enabled = True
        Me.TxtQty.Enabled = True
        TxtQty.Focus()

    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        cancel()
        ClearData()
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        edit()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lv2.SelectedIndexChanged
        If flag = True Then
            Dim z As Integer
            z = lv2.SelectedItems.Count

            If z = 0 Then
                Exit Sub
            Else
                Me.TxtKodeProduk.Text = lv2.SelectedItems.Item(0).SubItems(2).Text
                Me.TxtNamaBarang.Text = lv2.SelectedItems.Item(0).SubItems(3).Text
            End If
            Me.TxtQty.Focus()
        End If
    End Sub

    Private Sub TxtQty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtQty.KeyDown
        If e.KeyCode = Keys.Enter Then

            If flag = True Then
                UpdateAfterEdit()
                BtnEdit.Enabled = True
            End If
        End If
    End Sub

    Private Sub TxtQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtQty.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(Keys.Back))
    End Sub

    Private Sub UpdateAfterEdit()
        Call GetIdProduk(Me.TxtKodeProduk.Text)

        sql = "exec spLpbSupplierHeaderDetail 'getTmp',0,0," & Me.TxtNoPo.Text & "," & idProduk & "," & qtyrcv & ",'2017-10-01','" & StrNamaUser & "','x','nopol','drv'"
        RsConn = conn.Execute(sql)
        qtypo = RsConn("qty").Value

        If qtyrcv > qtypo Then
            MsgBox("Qty Receive tidak boleh melebihi Qty PO !!", vbOKOnly + vbCritical, "Info")
            TxtQty.SelectAll()
            Exit Sub
        End If


        sql = "exec spLpbSupplierHeaderDetail 'UpdateData',0," & idsupp & "," & Me.TxtNoPo.Text & "," & idProduk & "," & qtyrcv & ",'2017-10-01','" & StrNamaUser & "','x','nopol','drv'"
        RsConn = conn.Execute(sql)
        LoadDataTmp()
        LoadSumPo()
        TxtNamaBarang.Clear()
        TxtKodeProduk.Clear()
        TxtQty.Clear()
        TxtQty.Enabled = False
    End Sub

    Private Sub TxtQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtQty.TextChanged
        If TxtQty.Text = "" Then
            TxtQty.Text = "0"
            Exit Sub
        End If
        qtyrcv = TxtQty.Text
        TxtQty.Text = Format(qtyrcv, "#,##0")
        TxtQty.SelectionStart = Len(TxtQty.Text)

    End Sub

    Private Sub CancelData()
        If Me.TxtNoPo.Text = "" Then
            Me.TxtNoPo.Text = 0
        End If
        sql = "exec spLpbSupplierHeaderDetail 'CancelData',0,0," & Me.TxtNoPo.Text & ",0,0,'2017-10-01','" & StrNamaUser & "','x','nopol','drv'"
        RsConn = conn.Execute(sql)

    End Sub

    Private Sub ClearData()
        Me.txtsj.Clear()
        Me.TxtNoPo.Clear()
        Me.TxtKodeSupplier.Clear()
        Me.TxtNamaSupplier.Clear()
        Me.TxtKodeProduk.Clear()
        Me.TxtNamaBarang.Clear()
        Me.TxtTglPO.Clear()
        Me.TxtTglBayar.Clear()
        Me.TxtTothargaPembelian.Clear()
        Me.TxtTotalIncPpn.Clear()
        Me.TxtPPN.Clear()
        Me.TxtQty.Clear()
        Me.TxtIncDisc.Clear()
        Me.TxtTotDisc.Clear()
        Me.TxtTotBayar.Clear()
        Me.txtNoLPB.Clear()
        Me.TxtUser.Clear()
        Me.TxtTglApprove.Clear()
        TxtNoPol.Clear()
        TxtNamaDriver.Clear()
        TxtNoPol.ReadOnly = True
        TxtNamaDriver.ReadOnly = True
        txtsj.ReadOnly = True
        LblPartial.Visible = False
    End Sub

    Private Sub GetTgl()
        sql = "exec spLpbSupplierHeaderDetail 'GetTgl',0,0," & Me.TxtNoPo.Text & ",0,0,'2017-10-01','" & StrNamaUser & "','x','nopol','drv'"
        RsConn = conn.Execute(sql)
        If Not RsConn.EOF Then
            Me.TxtTglPO.Text = Format(RsConn("TglPO").Value, "dd-MM-yyyy")
            Me.TxtTglApprove.Text = Format(RsConn("tglApprove").Value, "dd-MM-yyyy")
            Me.TxtTglBayar.Text = Format(CDate(RsConn("tglBayar").Value), "dd-MM-yyyy")

        Else
            Me.TxtTglApprove.Clear()
            Me.TxtTglBayar.Clear()
            Me.TxtTglPO.Clear()
            Me.txtNoLPB.Clear()
        End If
    End Sub



    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        sql = "exec spLpbSupplierHeaderDetail 'InsTmpLPB',0,0," & Me.txtNoLPB.Text & ",0,0,'2017-10-01','" & StrNamaUser & "','x','nopol','drv'"
        conn.Execute(sql)
        Call proses()
        Call CancelData()

    End Sub

    Private Sub proses()
        Dim objConn As OleDbConnection
        Dim objCmd As OleDbCommand
        Dim objReader As OleDbDataReader
        Dim objDataSet As DataSet = New DataSetPO
        Dim strSQL, strCONN As String

        GetStringKoneksi() '---1
        strCONN = StrKoneksi '----2

        strSQL = "exec spLpbSupplierHeaderDetail 'Print',0,0," & txtNoLPB.Text & ",0,0,'2017-10-01','" & StrNamaUser & "','x','nopol','drv'"

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
        paramList.Add(New ReportParameter("FormHeader", "RECEIPT SUPPLIER", True))
        paramList.Add(New ReportParameter("NoLPB", Me.txtNoLPB.Text, True))
        paramList.Add(New ReportParameter("KodeSupplier", Me.TxtKodeSupplier.Text, True))
        paramList.Add(New ReportParameter("NamaSupplier", Me.TxtNamaSupplier.Text, True))
        paramList.Add(New ReportParameter("AlamatSupplier", Me.alamatsupplier, True))
        paramList.Add(New ReportParameter("TelpSupplier", telpsupplier, True))
        paramList.Add(New ReportParameter("NoFaktur", Me.TxtNoPo.Text, True))
        paramList.Add(New ReportParameter("TglPO", Me.TxtTglPO.Text, True))
        paramList.Add(New ReportParameter("TglTiba", Format(Me.DTPTglTiba.Value, "dd-MM-yyyy"), True))
        paramList.Add(New ReportParameter("TglBayar", Me.TxtTglBayar.Text, True))
        paramList.Add(New ReportParameter("TglBuat", Me.TxtTglApprove.Text, True))
        paramList.Add(New ReportParameter("TtlHargaPembelian", Me.TxtTothargaPembelian.Text, True))
        paramList.Add(New ReportParameter("TtlDiscount", Me.TxtTotDisc.Text, True))
        paramList.Add(New ReportParameter("TtlSetelahDiscount", Me.TxtIncDisc.Text, True))
        paramList.Add(New ReportParameter("PpnIn", Me.TxtPPN.Text, True))
        paramList.Add(New ReportParameter("TtlIncPPN", Me.TxtTotalIncPpn.Text, True))
        paramList.Add(New ReportParameter("TtlFaktur", Me.TxtTotBayar.Text, True))
        paramList.Add(New ReportParameter("terbilang", nilaiterbilang, True))
        paramList.Add(New ReportParameter("KodeDC", kodedc, True))
        paramList.Add(New ReportParameter("NamaDC", namadc, True))
        paramList.Add(New ReportParameter("KotaDC", kotadc, True))
        paramList.Add(New ReportParameter("NoSJ", Me.txtsj.Text, True))
        paramList.Add(New ReportParameter("NoPol", Me.TxtNoPol.Text, True))
        paramList.Add(New ReportParameter("NamaDriver", Me.TxtNamaDriver.Text, True))
        paramList.Add(New ReportParameter("DiBuat", dibuat, True))
        Dim ReportViewerForm As New FrmReport
        ReportViewerForm.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptLPBSupplier.rdlc"
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewerForm.ReportViewer1.LocalReport.SetParameters(paramList)
        ReportViewerForm.ReportViewer1.RefreshReport()
        ReportViewerForm.Show()

    End Sub

    Private Sub namasupp()

        GetIdSupplier(TxtKodeSupplier.Text)
        sql = "select * from mstsupplierperdc where iddc= " & IdDC & " and idsupplier=" & IdSupplier
        RsConn = conn.Execute(sql)
        If Not RsConn.EOF Then
            alamatsupplier = RsConn("alamatsupplier").Value
            telpsupplier = RsConn("noTelephone").Value
        End If
    End Sub

    Private Sub txtsj_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsj.KeyPress
        If (e.KeyChar Like "[',]") Then e.Handled() = True
    End Sub

    Private Sub TxtNoPol_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNoPol.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtNamaDriver.Focus()

        End If

    End Sub

    Private Sub TxtNoPol_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNoPol.KeyPress

        e.Handled = Not (Char.IsLetterOrDigit(e.KeyChar) Or ".".Contains(e.KeyChar) Or e.KeyChar = Chr(Keys.Back))
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub TxtNamaDriver_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNamaDriver.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtsj.Focus()
        End If

    End Sub

    Private Sub TxtNamaDriver_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNamaDriver.KeyPress

        If (e.KeyChar Like "[',]") Then e.Handled() = True
        e.KeyChar = UCase(e.KeyChar)
    End Sub


    Private Sub BtnFindLpb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFindLpb.Click
        Call ClearData()
        Call LoadDataTmp()
        DTPTglTiba.Enabled = False
        txtNoLPB.Text = FrmFind.cari("NomorLPB")
        If txtNoLPB.Text = "" Or txtNoLPB.Text = "0" Then
            txtNoLPB.Text = ""
            BtnPrint.Enabled = False
            Exit Sub
        End If
        Call lihatLPB()
        InsertTmp()
        Call Disable()
        BtnPrint.Enabled = True
        BtnAdd.Enabled = True
        BtnFindLpb.Enabled = True
    End Sub

  
End Class