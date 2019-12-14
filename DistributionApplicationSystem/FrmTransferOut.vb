Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Data.OleDb
Public Class FrmTransferOut
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
    Dim counter, nomor As Integer
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand


    Private Sub FrmTransferOut_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        BtnFindNoFaktur.Focus()
    End Sub

    Private Sub hapustmp()

        sql = "exec spTblTOTmp 'Delete',1," & kodetoko & ",0,0," & nomortox & ",'" & StrNamaUser & "'"
        RsConn = conn.Execute(sql)

    End Sub

    Private Sub FrmTransferOut_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If BtnSave.Enabled = True Then
            Dim result2 As DialogResult = MessageBox.Show("Masih Ada data yang belum disimpan ....!!" & vbCrLf _
                                                               & "Tetap mau keluar ?", "Question !!", _
             MessageBoxButtons.YesNo, _
             MessageBoxIcon.Question)
            If result2 = DialogResult.Yes Then

                sql = "exec spTblTOTmp 'GetTO',1,0,0,0,0,'" & StrNamaUser & "'"
                RsConn = conn.Execute(sql)
                If RsConn.EOF Then
                    Call deletetmp()
                    Call hapustmp()
                    nomorTO = 0
                End If
            Else
                e.Cancel = True
            End If
        ElseIf BtnAdd.Text = "START" Then
            nomorTO = txtNoFaktur.Text
            Call deletetmp()
            nomorTO = 0
        End If
    End Sub
    Private Sub FrmTransferOut_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        'Call loaddata()
    End Sub
    Private Sub cektemp()
        sql = "exec spTblTOTmp 'GetTO',1,0,0,0,0,'" & StrNamaUser & "'"
        RsConn = conn.Execute(sql)

        If Not RsConn.EOF Then
            Dim result2 As DialogResult = MessageBox.Show("Masih Ada data yang belum selesai ....!!" & vbCrLf _
                                                              & "silahkan dilanjutkan ?", "Question !!", _
            MessageBoxButtons.OK, _
            MessageBoxIcon.Question)
            If result2 = DialogResult.OK Then
                kodetoko = 0
                Do While txtNoFaktur.Text = "" Or txtNoFaktur.Text = "0"
                    txtNoFaktur.Text = FrmFind.cari("NoTObyPBTMP")
                Loop

                nomorTO = txtNoFaktur.Text
                txtuser.Text = StrNamaUser

                sql = "exec spTblTOTmp 'GetTOdet',1," & kodetoko & ",0,0," & nomorTO & ",'" & StrNamaUser & "'"
                RsConfig = conn.Execute(sql)
                If Not RsConfig.EOF Then
                    txtNoPL.Text = RsConfig("nomorpicking").Value
                    NomorPB = RsConfig("nomorpb").Value
                    txtuser.Text = RsConfig("iduser").Value
                    TxtKodetoko.Text = RsConfig("kodetoko").Value
                    txtnamatoko.Text = RsConfig("namatoko").Value
                    txtTglBuat.Text = Format(Now, "dd-MM-yyyy")

                    Call tombol()

                    BtnCancel.Enabled = True
                    BtnSave.Enabled = True

                    If Val(nomorTO) < 2000000 Then
                        flagadd = True
                        flagedit = False
                    Else
                        flagedit = True
                        flagadd = False
                    End If
                    Call loaddataTmp()
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
        'txtBarcode.Enabled = False
        'txtnamabarang.Enabled = False
        'txtqty.Enabled = False
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
        kodetoko = 0

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
        BtnFindNoPL.Enabled = False
        BtnFindNoFaktur.Enabled = True
        Panel1.Enabled = True
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        If BtnAdd.Text = "&Add" Then
            Call bersih()
            BtnAdd.Text = "START"
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
            DgSO.ReadOnly = True
            BtnFindNoPL.Focus()

        Else
            If txtnamatoko.Text <> "" Then

                sql = "exec spfind 'NoPLStart','" & TxtKodetoko.Text & "','" & txtNoPL.Text & "'"
                RsConn = conn.Execute(sql)
                If Not RsConn.EOF Then
                    MsgBox("No Picking sudah di transaksikan oleh user " & RsConn("iduser").Value, vbOKOnly + vbCritical, "Info")
                    Exit Sub
                End If

                BtnAdd.Text = "&Add"
                Panel1.Enabled = False
                BtnAdd.Enabled = False
                Call simpantbltmp()
                DgSO.ReadOnly = False
                Call loaddataTmp()
                DgSO.Select()
                Me.DgSO.CurrentCell = Me.DgSO(5, 0)
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
            Call loaddata()
        ElseIf flagedit = True Then
            BtnAdd.Enabled = True
            Panel1.Enabled = True
            BtnEdit.Enabled = True
            BtnApproval.Enabled = True
            flagedit = False
            DgSO.ReadOnly = True
            Call loaddata()
        Else
            BtnAdd.Enabled = True
        End If
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
        Call loaddata()
    End Sub

    Private Sub txtNoFaktur_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNoFaktur.TextChanged
        If txtNoFaktur.Text = "0" Then txtNoFaktur.Text = ""
        If txtNoFaktur.Text = "" Then Exit Sub
        nomorTO = Val(txtNoFaktur.Text)
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
    Private Sub simpanTmp(ByVal y As Integer)
        sql = "exec spToKeTokoDetailTMP 'getid'," & IdDC & "," & kodetoko & "," & NomorPB & "," & txtNoPL.Text & "," & nomorTO & "," & idProduk & ",0,0,0,0," & qty & ",0"
        RsConfig = conn.Execute(sql)
        If Not RsConfig.EOF Then
            qtyctn = RsConfig("qtyto").Value
        End If

        If qty > qtypl Then
            MsgBox("Qty TO tidak boleh melebihi Qty PB !!!", vbOKOnly + vbCritical, "Peringatan")
            DgSO.Rows(y).Cells(5).Selected = True
            If flagadd = True Then

                DgSO.Rows(y).Cells(5).Value = 0
            Else
                DgSO.Rows(y).Cells(5).Value = qtyctn
            End If

            If y + 1 <> nomor Then
                SendKeys.Send("{up}")
            End If
            Exit Sub
        End If


            sql = "exec spMutasiSaldoHeaderDetail 'GetStockGS'," & IdDC & ",'" & StrNamaUser & "','xxx',1," & idProduk & "," & qty & ",'ket','BA'"
            RsConn = conn.Execute(sql)

            If RsConn("hpp").Value <= 0 Then
            MsgBox("Hpp masih 0(nol) !!!", vbOKOnly + vbInformation, "Info")
            DgSO.Rows(y).Cells(5).Selected = True
            If flagadd = True Then

                DgSO.Rows(y).Cells(5).Value = 0
            Else
                DgSO.Rows(y).Cells(5).Value = qtyctn
            End If

            If y + 1 <> nomor Then
                SendKeys.Send("{up}")
            End If
            Exit Sub
            ElseIf RsConn("qty").Value < qty Then
            MsgBox("Stock hanya tersedia " & Format(RsConn("qty").Value, "#,##0") & " !!!", vbOKOnly + vbInformation, "Info")
            DgSO.Rows(y).Cells(5).Selected = True
            If flagadd = True Then

                DgSO.Rows(y).Cells(5).Value = 0
            Else
                DgSO.Rows(y).Cells(5).Value = qtyctn
            End If

            If y + 1 <> nomor Then
                SendKeys.Send("{up}")
            End If
            Exit Sub
            End If

            sql = "Select harga from msthargabyjenislokasi where harga=0 and idproduk=" & idProduk & " and kodejenislokasi='" & kodejnslokasi & "'"
            RsConn = conn.Execute(sql)
            If Not RsConn.EOF Then
            MsgBox("Harga Jual masih ada yang 0(nol) !!!", vbOKOnly + vbInformation, "Info")
            DgSO.Rows(y).Cells(5).Selected = True
            If flagadd = True Then

                DgSO.Rows(y).Cells(5).Value = 0
            Else
                DgSO.Rows(y).Cells(5).Value = qtyctn
            End If

            If y + 1 <> nomor Then
                SendKeys.Send("{up}")
            End If
            Exit Sub
            End If

            sql = "exec spToKeTokoDetailTMP 'add'," & IdDC & "," & kodetoko & "," & NomorPB & "," & txtNoPL.Text & "," & nomorTO & "," & idProduk & ",0,0,0," & IdPajak & "," & qty & ",0"
            conn.Execute(sql)
            Call hitung()

    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Call simpan()
    End Sub

    Private Sub simpan()
        If conn.State = 0 Then
            Call GetStringKoneksi()
            conn.Open(StrKoneksi)
        End If
        Dim result2 As DialogResult = MessageBox.Show("Simpan data TO  ??", _
               "Question !!", _
               MessageBoxButtons.YesNo, _
               MessageBoxIcon.Question)
        If result2 = DialogResult.Yes Then
            nomortox = txtNoFaktur.Text
            Call tombol()
            If flagadd = True Then
                GetStringKoneksi()
                GetKoneksiSQLClient()
                cmd = New SqlCommand("exec spToKeTokoHeader 'add'," & IdDC & "," & kodetoko & "," & NomorPB & "," & noPL & "," & txtNoFaktur.Text & "," & ttlitem & "," & ttlqty & "," & Replace(ttlvalue, ",", ".") & "," & Replace(ttlpajak, ",", ".") & "," & Replace(ttlnett, ",", ".") & ",0,'" & StrNamaUser & "'", SQLConn)
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

                Call hapustmp()

            ElseIf flagedit = True Then

                GetStringKoneksi()
                GetKoneksiSQLClient()
                cmd = New SqlCommand("exec spToKeTokoHeader 'edit'," & IdDC & "," & kodetoko & "," & NomorPB & "," & txtNoPL.Text & "," & nomorTO & "," & ttlitem & "," & ttlqty & "," & Replace(ttlvalue, ",", ".") & "," & Replace(ttlpajak, ",", ".") & "," & Replace(ttlnett, ",", ".") & ",0,'" & txtuser.Text & "'", SQLConn)
                cmd.CommandTimeout = 7200
                dr = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows Then
                    If dr.Item("statusproses") = 0 Then
                        MsgBox(dr.Item("pesan"), vbOKOnly + vbInformation, "Simpan data Gagal")
                        Exit Sub
                    Else
                        MsgBox(dr.Item("pesan"), vbOKOnly + vbInformation, "Simpan data Berhasil")
                    End If
                End If
                dr.Close()
                Call hapustmp()
            End If
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

                GetStringKoneksi()
                GetKoneksiSQLClient()
                cmd = New SqlCommand("exec spToKeTokoHeader 'Approve'," & IdDC & "," & kodetoko & "," & NomorPB & "," & txtNoPL.Text & "," & nomorTO & ",0,0,0,0,0,1,'" & txtuser.Text & "'", SQLConn)
                cmd.CommandTimeout = 7200
                dr = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows Then
                    If dr.Item("statusproses") = 0 Then
                        MsgBox(dr.Item("pesan"), vbOKOnly + vbInformation, "Approve data")
                        Exit Sub
                    Else
                        MsgBox(dr.Item("pesan"), vbOKOnly + vbInformation, "Approve data")
                    End If
                End If
                dr.Close()

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
        nomorTO = txtNoFaktur.Text
        sql = "exec spToKeTokoDetailTMP 'EditData'," & IdDC & "," & kodetoko & ",0,0," & nomorTO & ",0,0,0,0,0,0,0"
        conn.Execute(sql)
        Call tombol()
        BtnCancel.Enabled = True
        BtnSave.Enabled = True

        Panel1.Enabled = False
        flagedit = True
        Call simpantbltmp()
        Call loaddataTmp()
        DgSO.ReadOnly = False
        DgSO.Select()
        Me.DgSO.CurrentCell = Me.DgSO(5, Me.DgSO.CurrentCell.RowIndex)
        qtyctn = DgSO.Rows(0).Cells(5).Value
    End Sub

    Private Sub simpantbltmp()
        sql = "exec spTblTOTmp 'Add',1," & kodetoko & "," & NomorPB & "," & txtNoPL.Text & "," & nomorTO & ",'" & StrNamaUser & "'"
        conn.Execute(sql)

    End Sub

    Private Sub BtnFindNoFaktur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFindNoFaktur.Click
        Call bersih()
        txtNoFaktur.Text = FrmFind.cari("NoTObyPB")
        If txtNoFaktur.Text = "" Then
            DgSO.DataSource = Nothing
            DgSO.Rows.Clear()
            Exit Sub
        Else
            Call tampildata()
        End If

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
                DgSO.ReadOnly = True
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

        'txtBarcode.ReadOnly = True
        'txtqty.ReadOnly = True
        'CBLock.Enabled = False

    End Sub


    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        If statusToko = "R" Then
            kepala = "SURAT JALAN"
            Call cetakSJ()
        Else
            kepala = "DELIVERY ORDER"
            'Call cetak()
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

    Private Sub loaddata()

        noPL = Val(txtNoPL.Text)

        DgSO.DataSource = Nothing
        DgSO.Rows.Clear()
        DgSO.Columns.Clear()


        Dim aCol() As Integer = {8, 10, 55, 10, 10, 6}
        Dim icol As Integer
        Dim sqlstring As String

        With DgSO.ColumnHeadersDefaultCellStyle
            .BackColor = Color.DeepPink  'navy
            .ForeColor = Color.Navy
            .Font = New Font("Arial", 9, FontStyle.Bold)
        End With


        With DgSO
            '.EditMode = DataGridViewEditMode.EditOnKeystroke
            .AutoSizeRowsMode = _
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
            .ColumnHeadersBorderStyle = _
                DataGridViewHeaderBorderStyle.Raised
            .CellBorderStyle = _
                DataGridViewCellBorderStyle.Single
            .GridColor = SystemColors.ActiveBorder
            .RowHeadersVisible = False
            .SelectionMode = _
                DataGridViewSelectionMode.CellSelect
            .MultiSelect = False
            .BackgroundColor = Color.Honeydew
            .AllowUserToResizeColumns = False
        End With

        Dim da As SqlClient.SqlDataAdapter
        DgSO.AllowUserToAddRows = False

        If flagadd = True Then
            sqlstring = "exec spPickingDetail 'LoadTO'," & IdDC & "," & Val(TxtKodetoko.Text) & "," & noPL & ",'" & StrNamaUser & "'"

        Else
            sqlstring = "exec spPickingDetail 'Loadata'," & IdDC & "," & Val(TxtKodetoko.Text) & "," & noPL & ",'" & StrNamaUser & "'"
        End If

        GetStringKoneksi()
        GetKoneksiSQLClient()
        da = New SqlDataAdapter(sqlstring, SQLConn)
        DS = New DataSet
        da.Fill(DS, (sqlstring))
        Me.DgSO.DataSource = DS.Tables(sqlstring)


        ' format kolom datagrid pcn
        For icol = 0 To 5
            DgSO.Columns(icol).Width = (DgSO.Width / 100) * aCol(icol)
            Select Case icol
                Case 0
                    DgSO.Columns(icol).HeaderText = "No.Urut"
                    DgSO.Columns(icol).ReadOnly = True
                    DgSO.Columns(icol).DefaultCellStyle.Format = "##,0"
                Case 1
                    DgSO.Columns(icol).HeaderText = "SKU"
                    DgSO.Columns(icol).ReadOnly = True

                Case 2
                    DgSO.Columns(icol).HeaderText = "Nama Produk"
                    DgSO.Columns(icol).ReadOnly = True
                Case 3
                    DgSO.Columns(icol).HeaderText = "Lokasi"
                    DgSO.Columns(icol).ReadOnly = True

                Case 4
                    DgSO.Columns(icol).HeaderText = "Qty"
                    DgSO.Columns(icol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DgSO.Columns(icol).DefaultCellStyle.Format = "##,0"
                    DgSO.Columns(icol).ReadOnly = False

                Case 5
                    DgSO.Columns(icol).HeaderText = "idproduk"
                    DgSO.Columns(icol).ReadOnly = True
                    DgSO.Columns(icol).Visible = False

            End Select

        Next

        For counter = 0 To (DgSO.Rows.Count - 1)

            nomor = counter + 1
            DgSO.Rows(counter).Cells(0).Value() = nomor

        Next

    End Sub

    Private Sub loaddataTmp()

        noPL = Val(txtNoPL.Text)
       
        DgSO.DataSource = Nothing
        DgSO.Rows.Clear()
        DgSO.Columns.Clear()

        Dim aCol() As Integer = {8, 10, 50, 10, 10, 10, 15}
        Dim icol As Integer
        Dim sqlstring As String

        With DgSO.ColumnHeadersDefaultCellStyle
            .BackColor = Color.DeepPink  'navy
            .ForeColor = Color.Navy
            .Font = New Font("Arial", 9, FontStyle.Bold)
        End With


        With DgSO
            '.EditMode = DataGridViewEditMode.EditOnKeystroke
            .AutoSizeRowsMode = _
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
            .ColumnHeadersBorderStyle = _
                DataGridViewHeaderBorderStyle.Raised
            .CellBorderStyle = _
                DataGridViewCellBorderStyle.Single
            .GridColor = SystemColors.ActiveBorder
            .RowHeadersVisible = False
            .SelectionMode = _
                DataGridViewSelectionMode.CellSelect
            .MultiSelect = False
            .BackgroundColor = Color.Honeydew
            .AllowUserToResizeColumns = False
        End With

        Dim da As SqlClient.SqlDataAdapter
        DgSO.AllowUserToAddRows = False

        If flagadd = True Then
            sqlstring = "exec spPickingDetail 'LoadTOTmp'," & IdDC & "," & Val(TxtKodetoko.Text) & "," & noPL & ",'" & StrNamaUser & "'"

        Else
            sqlstring = "exec spPickingDetail 'LoaddtTmp'," & IdDC & "," & Val(TxtKodetoko.Text) & "," & noPL & ",'" & StrNamaUser & "'"
        End If

        GetStringKoneksi()
        GetKoneksiSQLClient()
        da = New SqlDataAdapter(sqlstring, SQLConn)
        DS = New DataSet
        da.Fill(DS, (sqlstring))
        Me.DgSO.DataSource = DS.Tables(sqlstring)


        ' format kolom datagrid pcn
        For icol = 0 To 6
            DgSO.Columns(icol).Width = (DgSO.Width / 100) * aCol(icol)
            Select Case icol
                Case 0
                    DgSO.Columns(icol).HeaderText = "No.Urut"
                    DgSO.Columns(icol).ReadOnly = True
                    DgSO.Columns(icol).DefaultCellStyle.Format = "##,0"
                Case 1
                    DgSO.Columns(icol).HeaderText = "SKU"
                    DgSO.Columns(icol).ReadOnly = True

                Case 2
                    DgSO.Columns(icol).HeaderText = "Nama Produk"
                    DgSO.Columns(icol).ReadOnly = True
                Case 3
                    DgSO.Columns(icol).HeaderText = "Lokasi"
                    DgSO.Columns(icol).ReadOnly = True

                Case 4
                    DgSO.Columns(icol).HeaderText = "Qty Picking"
                    DgSO.Columns(icol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DgSO.Columns(icol).DefaultCellStyle.Format = "##,0"
                    DgSO.Columns(icol).ReadOnly = True

                Case 5
                    DgSO.Columns(icol).HeaderText = "Qty TO"
                    DgSO.Columns(icol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DgSO.Columns(icol).DefaultCellStyle.Format = "##,0"
                    DgSO.Columns(icol).ReadOnly = False

                Case 6
                    DgSO.Columns(icol).HeaderText = "idproduk"
                    DgSO.Columns(icol).ReadOnly = True
                    DgSO.Columns(icol).Visible = False

            End Select

        Next

        For counter = 0 To (DgSO.Rows.Count - 1)

            nomor = counter + 1
            DgSO.Rows(counter).Cells(0).Value() = nomor

        Next

    End Sub

    Private Sub DgSO_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DgSO.EditingControlShowing
        AddHandler CType(e.Control, TextBox).KeyPress, AddressOf TextBox_keyPress
    End Sub
    Private Sub TextBox_keyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If DgSO.CurrentCell.ColumnIndex > 4 Then
            If Char.IsDigit(CChar(CStr(e.KeyChar))) = False Then e.Handled = True
            If Not (Char.IsDigit(CChar(CStr(e.KeyChar))) Or e.KeyChar = ".") Then e.Handled = True
            If e.KeyChar = " "c Then e.Handled = False

        End If
    End Sub


    Private Sub DgSO_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgSO.CellEndEdit
        Dim x As Integer = DgSO.CurrentCellAddress.X
        Dim y As Integer = DgSO.CurrentCellAddress.Y


        If e.ColumnIndex = 5 Then
            idProduk = DgSO.Rows(y).Cells(6).Value
            scan(DgSO.Rows(y).Cells(1).Value)

            If Not IsDBNull(DgSO.Rows(y).Cells(5).Value) Then
                qty = Replace(DgSO.Rows(y).Cells(5).Value, ".", "")
            ElseIf Val(DgSO.Rows(y).Cells(5).Value) < 1 Or DgSO.Rows(y).Cells(5).Value = "" Then
                qty = 0
            Else
                qty = Val(DgSO.Rows(y).Cells(5).Value)

            End If
            Call cekpl()
            Call simpanTmp(y)
            BtnSave.Enabled = True

        End If




    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class