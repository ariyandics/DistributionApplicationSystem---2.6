Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Data.OleDb
Public Class FrmRRAK
    Dim sql, kodecoa, namacoa As String
    Dim conn As New ADODB.Connection
    Dim RsConn As New ADODB.Recordset
    Dim flagadd, flagedit As Boolean
    Dim rpbaru, rprealisasi, totestimasi As Int64
    Dim status, ket, idusr, userpng As String
    Dim FlagPesanBulan, FlagPesanUserAPP, FlagPesanUserBATAL As Boolean

    Private Sub FrmRRAK_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Call kunci()
        btnFindToko.Enabled = True
        BtnNoRRAK.Enabled = True
        flagadd = False

        CbJenis.Items.Clear()
        CbJenis.Items.Add("Estimasi")
        CbJenis.Items.Add("Realisasi")
      
    End Sub

    Private Sub GbrTombol()
        Me.BtnApproval.Image = System.Drawing.Image.FromFile(icoapprove)
        Me.BtnEdit.Image = System.Drawing.Image.FromFile(icoedit)
        Me.BtnCancel.Image = System.Drawing.Image.FromFile(icocancel)
        Me.BtnSave.Image = System.Drawing.Image.FromFile(icosave)
        'Me.BtnPrint.Image = System.Drawing.Image.FromFile(icoprint)

    End Sub
    Private Sub bersih()
        txtnamatoko.Clear()
        TxtKodetoko.Clear()
        txtNoRRAK.Clear()
        txttotal.Clear()
        txttotselisih.Clear()
        txtkesalahanrrak.Clear()
        txtpengembalian.Clear()
        txttotal.ReadOnly = True
        txtnamatoko.ReadOnly = True
        TxtKodetoko.ReadOnly = True
        txtpengembalian.Enabled = False
        txtvia.Enabled = False
        txtNoRRAK.ReadOnly = True
        txttotselisih.ReadOnly = True
        txtkesalahanrrak.ReadOnly = True
        txtkesalahanrrak.Enabled = False
        txtket.Enabled = False

    End Sub

    Private Sub kunci()
        BtnApproval.Enabled = False
        BtnCancel.Enabled = False
        BtnEdit.Enabled = False
        btnFindToko.Enabled = False
        BtnNoRRAK.Enabled = False
        BtnSave.Enabled = False
        BtnTampil.Enabled = False
        Button1.Enabled = False
    End Sub

    Private Sub BtnNoRRAK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNoRRAK.Click
        If TxtKodetoko.Text = "" Then
            MsgBox("Anda belum memilih Toko !!", vbOKOnly + vbInformation, "Info")
            btnFindToko.Focus()
            Exit Sub
        End If
        If CbJenis.Text = "" Then
            MsgBox("Anda belum memilih Jenis Approval !!", vbOKOnly + vbInformation, "Info")
            CbJenis.Focus()
            Exit Sub
        End If

        If txtjenis.Text = "RRAK" Then
            kodetoko = TxtKodetoko.Text

            If CbJenis.Text = "Realisasi" Then
                txtNoRRAK.Text = FrmFind.cari("NoRRAKR")
            Else
                txtNoRRAK.Text = FrmFind.cari("NoRRAKE")
            End If
            If txtNoRRAK.Text = "" Then Exit Sub
            BtnTampil.Enabled = True
        Else
            kodetoko = TxtKodetoko.Text
            If CbJenis.Text = "Realisasi" Then
                txtNoRRAK.Text = FrmFind.cari("NoKasBonR")
            Else
                txtNoRRAK.Text = FrmFind.cari("NoKasBonE")
            End If
            If txtNoRRAK.Text = "" Then Exit Sub
            BtnTampil.Enabled = True
        End If


    End Sub

    Private Sub btnFindToko_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindToko.Click
        DgSO.DataSource = Nothing
        DgSO.Rows.Clear()
        DgSO.Columns.Clear()
        txttotal.Clear()
        txtNoRRAK.Clear()
        TxtKodetoko.Clear()
        txtnamatoko.Clear()
        TxtKodetoko.Text = FrmFind.cari("MasterToko")
        If TxtKodetoko.Text = "" Then Exit Sub
        kodetoko = TxtKodetoko.Text
        gettoko(kodetoko)
        txtnamatoko.Text = namatoko

    End Sub

    Private Sub BtnTampil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTampil.Click
        flagedit = False

        txtpengembalian.Enabled = False
        txtvia.Enabled = False
        txtket.Enabled = False

        BtnEdit.Enabled = False
        BtnApproval.Enabled = False
        Button1.Enabled = False
        If TxtKodetoko.Text = "" Or txtNoRRAK.Text = "" Then
            Exit Sub
        End If
        If TxtKodetoko.Text <> "" And txtNoRRAK.Text <> "" Then
            '' CariAkses()
            txttotselisih.Text = 0
            txtpengembalian.Text = 0
            txtkesalahanrrak.Text = 0
            Call cekstatus()


            If txtjenis.Text = "RRAK" Then
                If CbJenis.Text = "Realisasi" Then
                    Call loaddataRealisasi()
                Else
                    Call loaddata()
                End If
            End If

            Call hitung()

            BtnPrint.Enabled = True
            If CbJenis.Text = "Realisasi" Then
                txttotselisih.Visible = True
                Label4.Visible = True
                GroupBox1.Visible = True
                Call carinilai()
                Call hitungselisi()
                Call hitungselisikesalahan()
                '' Button1.Enabled = False
                ''  txtket.Text = ket
            ElseIf CbJenis.Text = "Estimasi" Then
                txttotselisih.Visible = False
                Label4.Visible = False
                GroupBox1.Visible = False


            End If
        End If
    End Sub
    Private Sub hitung()
        Dim totalrp As Double
        totalrp = 0
        If txtjenis.Text = "RRAK" Then
            If CbJenis.Text = "Realisasi" Then
                For t As Integer = 0 To DgSO.Rows.Count - 1
                    totalrp = totalrp + Val(DgSO.Rows(t).Cells(4).Value)
                Next
            Else
                For t As Integer = 0 To DgSO.Rows.Count - 1
                    totalrp = totalrp + Val(DgSO.Rows(t).Cells(2).Value)
                Next
            End If
        End If
        txttotal.Text = Format(totalrp, "#,##0")
    End Sub
    Private Sub hitungselisi()
        If CbJenis.Text = "Realisasi" Then
            Dim totalrp As Double
            totalrp = 0
            totalrp = totestimasi - txttotal.Text
            txttotselisih.Text = Format(totalrp, "###0")
        Else
            Exit Sub
        End If

    End Sub

    Private Sub hitungselisikesalahan()
        If CbJenis.Text = "Realisasi" Then
            Dim totalrp As Double
            totalrp = 0
            If txtpengembalian.Text = "" Then
                txtpengembalian.Text = 0
                totalrp = txttotselisih.Text - txtpengembalian.Text
            Else
                totalrp = txttotselisih.Text - txtpengembalian.Text
            End If

            txtkesalahanrrak.Text = Format(totalrp, "###0")
        Else
            Exit Sub
        End If

    End Sub

    Private Sub carinilai()
        sql = "exec spTblRRAK 'AmbilNilai',0,'RRAK'," & TxtKodetoko.Text & ",0,'x','x',0,0,'x','" & txtNoRRAK.Text & "','x','x'"
        conn.Execute(sql)
        If IsDBNull(RsConn("StatusData").Value) Then
            If IsDBNull(RsConn("TotEstimasi").Value) Then
                txttotselisih.Text = 0
            ElseIf (RsConn("TotEstimasi").Value) = 0 Then
                txttotselisih.Text = 0
            Else
                totestimasi = (RsConn("TotEstimasi").Value)
            End If
        ElseIf RsConn("StatusData").Value = 1 Then
            If IsDBNull(RsConn("TotEstimasi").Value) Then
                txttotselisih.Text = 0
            ElseIf (RsConn("TotEstimasi").Value) = 0 Then
                txttotselisih.Text = 0
            Else
                totestimasi = (RsConn("TotEstimasi").Value)
            End If

            txtpengembalian.Text = Format((RsConn("PengembalianRRAK").Value), "###0")

            txtkesalahanrrak.Text = (RsConn("KesalahanRRAK").Value)
            txtket.Text = (RsConn("Catatan").Value)
            txtvia.Text = (RsConn("CaraBayar").Value)
        End If

        

    End Sub
    Private Sub cekstatus()

        If txtjenis.Text = "RRAK" Then

            sql = "exec spTblRRAK 'getstatus',0,'" & txtjenis.Text & "'," & TxtKodetoko.Text & ",0,'x','x',0,0,'x','" & txtNoRRAK.Text & "','x','x'"
            RsConn = conn.Execute(sql)
            If Not RsConn.EOF Then
                If CbJenis.Text = "Estimasi" Then
                    If Not IsDBNull(RsConn("statusestimasi").Value) Then
                        If RsConn("statusestimasi").Value = 1 Then
                            BtnEdit.Enabled = True
                            BtnApproval.Enabled = True
                            txtpengembalian.Enabled = False
                            txtvia.Enabled = False
                            txtket.Enabled = False
                            Button1.Visible = True
                            Button1.Enabled = True
                        ElseIf RsConn("statusestimasi").Value = 4 Then
                            Button1.Enabled = False
                            BtnEdit.Enabled = False
                            BtnApproval.Enabled = False
                            txtpengembalian.Enabled = False
                            txtvia.Enabled = False
                            txtket.Enabled = False
                        End If
                    End If
                Else
                    If Not IsDBNull(RsConn("statusrealisasi").Value) Then
                        If RsConn("statusrealisasi").Value = 1 Then
                            BtnEdit.Enabled = True
                            BtnApproval.Enabled = True
                            txtpengembalian.Enabled = False
                            txtvia.Enabled = False
                            txtket.Enabled = False
                            Button1.Visible = False
                        End If
                    End If
                End If
            Else
                sql = "exec spTblRRAK 'GetstatKas'," & txtNoRRAK.Text & ",'" & txtjenis.Text & "'," & TxtKodetoko.Text & ",0,'x','x',0,0,'x','x','x','x'"
                RsConn = conn.Execute(sql)
                If Not RsConn.EOF Then
                    If CbJenis.Text = "Estimasi" Then
                        If Not IsDBNull(RsConn("statusEstimasiCashBond").Value) Then
                            If RsConn("statusEstimasiCashBond").Value = 1 Then
                                BtnEdit.Enabled = True
                                BtnApproval.Enabled = True

                            End If
                        End If
                    Else
                        If Not IsDBNull(RsConn("statusRealisasiCashBond").Value) Then
                            If RsConn("statusRealisasiCashBond").Value = 1 Then
                                BtnEdit.Enabled = True
                                BtnApproval.Enabled = True

                            End If

                        End If
                    End If
                End If

            End If
        End If
    End Sub
    Private Sub loaddata()

        DgSO.DataSource = Nothing
        DgSO.Rows.Clear()
        DgSO.Columns.Clear()


        Dim aCol() As Integer = {10, 30, 15}
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

        If txtjenis.Text = "RRAK" Then
            If CbJenis.Text = "Realisasi" Then
                sqlstring = "exec spTblRRAK 'getRR',0,'RRAK'," & TxtKodetoko.Text & ",0,'x','x',0,0,'x','" & txtNoRRAK.Text & "','x','x'"
            Else
                sqlstring = "exec spTblRRAK 'getRE',0,'RRAK'," & TxtKodetoko.Text & ",0,'x','x',0,0,'x','" & txtNoRRAK.Text & "','x','x'"
            End If
        Else
            If CbJenis.Text = "Realisasi" Then
                sqlstring = "exec spTblRRAK 'GetKasBonR',0,'KASBON'," & TxtKodetoko.Text & ",0,'x','x',0,0,'x','" & txtNoRRAK.Text & "','x','x'"
            Else
                sqlstring = "exec spTblRRAK 'GetKasBonE',0,'KASBON'," & TxtKodetoko.Text & ",0,'x','x',0,0,'x','" & txtNoRRAK.Text & "','x','x'"
            End If


        End If

            GetStringKoneksi()
            GetKoneksiSQLClient()
            da = New SqlDataAdapter(sqlstring, SQLConn)
            DS = New DataSet
            da.Fill(DS, (sqlstring))
            Me.DgSO.DataSource = DS.Tables(sqlstring)


            ' format kolom datagrid pcn
            For icol = 0 To 2
                DgSO.Columns(icol).Width = (DgSO.Width / 100) * aCol(icol)
                Select Case icol
                    Case 0
                        DgSO.Columns(icol).HeaderText = "Kode COA"
                        DgSO.Columns(icol).ReadOnly = True

                    Case 1
                        DgSO.Columns(icol).HeaderText = "Deskripsi"
                        DgSO.Columns(icol).ReadOnly = True

                    Case 2
                        DgSO.Columns(icol).HeaderText = "Nilai"
                        DgSO.Columns(icol).ReadOnly = True
                        DgSO.Columns(icol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        DgSO.Columns(icol).DefaultCellStyle.Format = "##,0"
                End Select

            Next


    End Sub

    Private Sub BtnApproval_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnApproval.Click
        Call CariAkses()
        If txtjenis.Text = "RRAK" Then
            If CbJenis.Text = "Realisasi" Then
                If FlagPesanUserAPP = True Then
                    MsgBox("Approval Realisasi Hanya Bisa dilakukan Oleh Divisi Financial", vbOKOnly + vbInformation, "Info")
                    btnFindToko.Enabled = True
                    BtnNoRRAK.Enabled = True
                    Exit Sub

                End If
                If Val(txtpengembalian.Text) = 0 AndAlso txttotselisih.Text > 0 Or Val(txtpengembalian.Text) = 0 AndAlso Val(txttotselisih.Text) < 0 Then
                    MessageBox.Show(" Silahkan Isi terlebih dulu Nilai pengembalian untuk informasi toko", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtpengembalian.Enabled = True
                    txtvia.Enabled = True
                    txtket.Enabled = True
                    BtnSave.Enabled = True
                    txtpengembalian.Focus()
                    Exit Sub
                End If
            Else
                If FlagPesanUserAPP = False Then
                    MsgBox("Approval Estimasi Hanya Bisa dilakukan Oleh Area Coordinator", vbOKOnly + vbInformation, "Info")
                    btnFindToko.Enabled = True
                    BtnNoRRAK.Enabled = True
                    BtnNoRRAK.Enabled = True
                    Exit Sub
                Else
                    Call cekaktifestimasi()
                End If
                
            End If
           
            Dim result2 As DialogResult = MessageBox.Show("Approve data RRAK ??", _
                  "Question !!", _
                  MessageBoxButtons.YesNo, _
                  MessageBoxIcon.Question)
            If result2 = DialogResult.Yes Then
                If CbJenis.Text = "Estimasi" Then
                    sql = "exec spTblRRAK 'ApproveE',0,'RRAK'," & TxtKodetoko.Text & ",0,'x','x',0,0,'x','" & txtNoRRAK.Text & "','" & StrNamaUser & "','" & txtket.Text & "'"
                Else
                    sql = "exec spTblRRAK 'ApproveR',0,'RRAK'," & TxtKodetoko.Text & ",0,'x','x'," & txtpengembalian.Text & "," & txtkesalahanrrak.Text & ",'" & txtvia.Text & "','" & txtNoRRAK.Text & "','" & StrNamaUser & "','" & txtket.Text & "'"
                End If
                conn.Execute(sql)
                MsgBox("Data RRAK berhasil di Approve", vbOKOnly + vbInformation, "info")
                Call kunci()
                btnFindToko.Enabled = True
                BtnNoRRAK.Enabled = True
                txtpengembalian.Enabled = False
                txtvia.Enabled = False
                txtket.Enabled = False
            End If
        Else
            Dim result2 As DialogResult = MessageBox.Show("Approve data Kas Bon ??", _
                 "Question !!", _
                 MessageBoxButtons.YesNo, _
                 MessageBoxIcon.Question)
            If result2 = DialogResult.Yes Then
                If CbJenis.Text = "Estimasi" Then
                    sql = "exec spTblRRAK 'ApproveKasE',0,'RRAK'," & TxtKodetoko.Text & ",0,'x','x',0,0,'x','" & txtNoRRAK.Text & "','x','x'"
                Else
                    sql = "exec spTblRRAK 'ApproveKasR',0,'RRAK'," & TxtKodetoko.Text & ",0,'x','x',0,0,'x','" & txtNoRRAK.Text & "','x','x'"

                End If

                conn.Execute(sql)
                MsgBox("Data Kas bon berhasil di Approve", vbOKOnly + vbInformation, "info")
                Call kunci()
                btnFindToko.Enabled = True
                BtnNoRRAK.Enabled = True
                txtpengembalian.Enabled = True
                txtpengembalian.ReadOnly = False
                txtpengembalian.Clear()
                txtpengembalian.Focus()
                txtvia.Enabled = True
            End If
        End If
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        flagedit = True
        Call kunci()
        Call CariAkses()

        If txtjenis.Text = "RRAK" Then
            If CbJenis.Text = "Realisasi" Then
                If FlagPesanUserAPP = True Then
                    MsgBox("Edit Realisasi Hanya Bisa dilakukan Oleh Divisi Financial", vbOKOnly + vbInformation, "Info")
                    btnFindToko.Enabled = True
                    BtnNoRRAK.Enabled = True
                    BtnNoRRAK.Enabled = True
                    Exit Sub
                End If
                DgSO.ReadOnly = False
                DgSO.Select()
                Me.DgSO.CurrentCell = Me.DgSO(4, Me.DgSO.CurrentCell.RowIndex)
                DgSO.Columns(4).ReadOnly = False
            Else
                If FlagPesanUserAPP = False Then
                    MsgBox("Edit Estimasi Hanya Bisa dilakukan Oleh Area Coordinator", vbOKOnly + vbInformation, "Info")
                    btnFindToko.Enabled = True
                    BtnNoRRAK.Enabled = True
                    BtnNoRRAK.Enabled = True
                    Exit Sub
                Else
                    cekaktifestimasi()
                    DgSO.ReadOnly = False
                    DgSO.Select()
                    Me.DgSO.CurrentCell = Me.DgSO(2, Me.DgSO.CurrentCell.RowIndex)
                    DgSO.Columns(2).ReadOnly = False
                    Exit Sub
                End If
            End If
        End If

     
        'qtyctn = DgSO.Rows(0).Cells(5).Value'
        BtnCancel.Enabled = True
        BtnSave.Enabled = True
        txtpengembalian.Enabled = True
        txtket.Enabled = True
        txtvia.Enabled = True
    End Sub

    Private Sub DgSO_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgSO.CellEndEdit
        Dim x As Integer = DgSO.CurrentCellAddress.X
        Dim y As Integer = DgSO.CurrentCellAddress.Y
        Call hitung()
        Call hitungselisi()
        Call hitungselisikesalahan()
        If CbJenis.Text = "Realisasi" Then
            DgSO.Rows(y).Cells(5).Value = DgSO.Rows(y).Cells(3).Value - DgSO.Rows(y).Cells(4).Value
            'If DgSO.Rows(y).Cells(5).Value < 0 Then
            '    MsgBox("Nilai Realisasi Tidak boleh Lebih besar dari pada Nilai Estimasi")
            '    DgSO.Rows(y).Cells(4).Value = 0
            Call hitung()
            Call hitungselisi()
            Call hitungselisikesalahan()
            DgSO.Rows(y).Cells(5).Value = DgSO.Rows(y).Cells(3).Value - DgSO.Rows(y).Cells(4).Value
            '    SendKeys.Send("{up}")
            '    Exit Sub
            'End If
        End If
    End Sub

    Private Sub DgSO_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DgSO.EditingControlShowing
        AddHandler CType(e.Control, TextBox).KeyPress, AddressOf TextBox_keyPress
    End Sub
    Private Sub TextBox_keyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If DgSO.CurrentCell.ColumnIndex > 1 Then
            If Char.IsDigit(CChar(CStr(e.KeyChar))) = False Then e.Handled = True
            If Not (Char.IsDigit(CChar(CStr(e.KeyChar))) Or e.KeyChar = ".") Then e.Handled = True
            If e.KeyChar = " "c Then e.Handled = False

        End If
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Call batal()
    End Sub

    Private Sub batal()
        Call kunci()
        Call cekstatus()
        If CbJenis.Text = "Realisasi" Then
            Call loaddataRealisasi()
        Else
            Call loaddata()
        End If
        Call hitung()

    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If CbJenis.Text = "Realisasi" Then
            Dim nilairealbaru As Int64
            Dim nilaiestbaru As Int64
            For Each row As DataGridViewRow In Me.DgSO.Rows
                nilaiestbaru += row.Cells.Item(3).Value
                nilairealbaru += row.Cells.Item(4).Value
            Next
            If nilairealbaru > nilaiestbaru Then
                MsgBox("Nilai Realisasi Tidak boleh Lebih besar dari pada Nilai Estimasi")
                Exit Sub
            End If
        End If
        If txtjenis.Text = "RRAK" Then
            Dim result2 As DialogResult = MessageBox.Show("Apakah perubahan RRAK akan di simpan ?", _
               "Warning !!", _
               MessageBoxButtons.YesNo, _
               MessageBoxIcon.Question)
            If result2 = DialogResult.Yes Then
                For Each row As DataGridViewRow In Me.DgSO.Rows
                    kodecoa = row.Cells.Item(0).Value
                    namacoa = row.Cells.Item(1).Value

                    If CbJenis.Text = "Estimasi" Then
                        rpbaru = row.Cells.Item(2).Value
                        sql = "exec spTblRRAK 'editdataE',0,'RRAK'," & TxtKodetoko.Text & "," & rpbaru & ",'" & kodecoa & "','" & namacoa & "',0,0,'x','" & txtNoRRAK.Text & "','" & StrNamaUser & "','x'"
                    Else
                        rpbaru = row.Cells.Item(4).Value
                        sql = "exec spTblRRAK 'editdataR',0,'RRAK'," & TxtKodetoko.Text & "," & rpbaru & ",'" & kodecoa & "','" & namacoa & "'," & txtpengembalian.Text & "," & txtkesalahanrrak.Text & ",'" & txtvia.Text & "','" & txtNoRRAK.Text & "','" & StrNamaUser & "','" & txtket.Text & "'"
                    End If
                    conn.Execute(sql)
                Next

                MsgBox("Data berhasil di simpan", vbOKOnly + vbInformation, "Info")
                Call kunci()
                If CbJenis.Text = "Realisasi" Then
                    Call loaddataRealisasi()
                Else
                    Call loaddata()
                End If
                Call cekstatus()
                btnFindToko.Enabled = True
                BtnNoRRAK.Enabled = True
                txtpengembalian.Enabled = False
                txtvia.Enabled = False
                txtket.Enabled = False
            End If
        Else
            Dim result1 As DialogResult = MessageBox.Show("Apakah perubahan Kas Bon akan di simpan ?", _
              "Warning !!", _
              MessageBoxButtons.YesNo, _
              MessageBoxIcon.Question)
            If result1 = DialogResult.Yes Then
                For Each row As DataGridViewRow In Me.DgSO.Rows
                    kodecoa = row.Cells.Item(0).Value
                    namacoa = row.Cells.Item(1).Value
                    If txtjenis.Text = "RRAK" Then
                        If CbJenis.Text = "Realisasi" Then
                            rpbaru = row.Cells.Item(4).Value
                        Else
                            rpbaru = row.Cells.Item(2).Value
                        End If
                    End If
                    If CbJenis.Text = "Estimasi" Then
                        sql = "exec spTblRRAK 'editkasE',0,'RRAK'," & TxtKodetoko.Text & "," & rpbaru & ",'" & kodecoa & "','" & namacoa & "',0,0,'x','" & txtNoRRAK.Text & "','x','x'"
                    Else
                        sql = "exec spTblRRAK 'editkasR',0,'RRAK'," & TxtKodetoko.Text & "," & rpbaru & ",'" & kodecoa & "','" & namacoa & "',0,0,'x','" & txtNoRRAK.Text & "','x','x'"

                    End If
                    conn.Execute(sql)
                Next

                MsgBox("Data berhasil di simpan", vbOKOnly + vbInformation, "Info")
                Call kunci()
                If CbJenis.Text = "Realisasi" Then
                    Call loaddataRealisasi()
                Else
                    Call loaddata()
                End If
                Call cekstatus()
                btnFindToko.Enabled = True
                BtnNoRRAK.Enabled = True
            End If
        End If
    End Sub

    Private Sub cekstatusprint()
        sql = "exec spTblRRAK 'getstatus',0,'" & txtjenis.Text & "'," & TxtKodetoko.Text & ",0,'x','x',0,0,'x','" & txtNoRRAK.Text & "','x','x'"
        RsConn = conn.Execute(sql)
        If Not RsConn.EOF Then
            If CbJenis.Text = "Estimasi" Then
                If Not IsDBNull(RsConn("statusestimasi").Value) Then
                    If RsConn("statusestimasi").Value = 1 Then
                        status = "Draft"
                    ElseIf RsConn("statusestimasi").Value = 4 Then
                        status = "Dibatalkan"
                    Else
                        status = "Approved"
                    End If
                End If
            Else
                If Not IsDBNull(RsConn("statusrealisasi").Value) Then
                    If RsConn("statusrealisasi").Value = 1 Then
                        status = "Draft"
                    Else
                        status = "Approved"
                    End If
                End If
            End If

        End If
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Call cekstatusprint()
        Call cekuserPrint()
        Dim objConn As OleDbConnection
        Dim objCmd As OleDbCommand
        Dim objReader As OleDbDataReader
        Dim objDataSet As DataSet = New dtsNonRRAK
        Dim strSQL, strCONN As String

        GetStringKoneksi() '---1
        strCONN = StrKoneksi '----2
        strSQL = " exec spTblRRAK 'Print',0,'" & txtjenis.Text & "'," & TxtKodetoko.Text & ",0,'x','x',0,0,'x','" & txtNoRRAK.Text & "','x','x'"
        conn.Execute(strSQL)

        objConn = New OleDbConnection(strCONN)
        objCmd = New OleDbCommand(strSQL, objConn)
        objCmd.CommandType = CommandType.Text
        objCmd.Connection.Open()
        objCmd.CommandTimeout = 0
        objReader = objCmd.ExecuteReader
        objDataSet.Tables(3).Clear()
        objDataSet.Tables(3).Load(objReader)
        objReader.Close()
        objConn.Close()

        Dim rds As ReportDataSource = New ReportDataSource
        rds.Name = "DtsRRAKDetail"
        rds.Value = objDataSet.Tables(3)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", "LEMBAR DOKUMEN RRAK", True))
        paramList.Add(New ReportParameter("KodeToko", Me.TxtKodetoko.Text, True))
        paramList.Add(New ReportParameter("NamaToko", Me.txtnamatoko.Text, True))
        paramList.Add(New ReportParameter("KodeRRAK", Me.txtNoRRAK.Text, True))
        paramList.Add(New ReportParameter("namaDC", namadc, True))
        paramList.Add(New ReportParameter("status", status, True))
        paramList.Add(New ReportParameter("penanggungjwb", userpng, True))
        paramList.Add(New ReportParameter("tglcetak", Now, True))
        paramList.Add(New ReportParameter("jenis", CbJenis.Text, True))
        paramList.Add(New ReportParameter("alamat", alamattoko, True))
        If CbJenis.Text = "Realisasi" Then
            paramList.Add(New ReportParameter("pengembalian", txtpengembalian.Text, True))
            paramList.Add(New ReportParameter("via", txtvia.Text, True))
            paramList.Add(New ReportParameter("kesalahan", txtkesalahanrrak.Text, True))
            If txtket.Text = "" Then
                paramList.Add(New ReportParameter("note", "-", True))
            Else
                paramList.Add(New ReportParameter("note", txtket.Text, True))
            End If
        Else

            paramList.Add(New ReportParameter("pengembalian", "0", True))
            paramList.Add(New ReportParameter("via", "x", True))
            paramList.Add(New ReportParameter("kesalahan", "0", True))
            paramList.Add(New ReportParameter("note", "x", True))
        End If

            Dim ReportViewerForm As New FrmReport
            ReportViewerForm.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptRRAK.rdlc"
            ReportViewerForm.ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewerForm.ReportViewer1.LocalReport.DataSources.Add(rds)
            ReportViewerForm.ReportViewer1.LocalReport.SetParameters(paramList)
            ReportViewerForm.ReportViewer1.RefreshReport()
            ReportViewerForm.Show()
    End Sub

    'Private Sub txtpengembalian_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpengembalian.TextChanged
    '    Call hitungselisikesalahan()
    'End Sub

    Private Sub txtpengembalian_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpengembalian.TextChanged
        If flagedit = False Then
            Exit Sub
        Else
            Call hitungselisikesalahan()
        End If
    End Sub

    Private Sub txtpengembalian_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpengembalian.KeyPress
        If DgSO.CurrentCell.ColumnIndex > 1 Then
            If Char.IsDigit(CChar(CStr(e.KeyChar))) = False Then e.Handled = True
            If Not (Char.IsDigit(CChar(CStr(e.KeyChar))) Or e.KeyChar = ".") Then e.Handled = True
            If e.KeyChar = " "c Then e.Handled = False

        End If
    End Sub

    Private Sub DgSO_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgSO.CellContentClick

    End Sub

    Private Sub CbJenis_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbJenis.SelectedIndexChanged

    End Sub

    Private Sub txtkesalahanrrak_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtkesalahanrrak.TextChanged
        If CbJenis.Text = "Realisasi" Then
            If Val(txtkesalahanrrak.Text) < 0 Then
                'MsgBox("Nilai pengembalian Tidak boleh lebih besar dari pada selisih Realisasi")
                txtpengembalian.Text = 0
                txtpengembalian.Focus()
                Exit Sub
            End If
        End If

    End Sub

    Private Sub loaddataRealisasi()

        DgSO.DataSource = Nothing
        DgSO.Rows.Clear()
        DgSO.Columns.Clear()


        Dim aCol() As Integer = {10, 30, 30, 15, 15, 15}
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

            sqlstring = "exec spTblRRAK 'getRR',0,'RRAK'," & TxtKodetoko.Text & ",0,'x','x',0,0,'x','" & txtNoRRAK.Text & "','x','x'"


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
                    DgSO.Columns(icol).HeaderText = "Kode COA"
                    DgSO.Columns(icol).ReadOnly = True

                Case 1
                    DgSO.Columns(icol).HeaderText = "Deskripsi"
                    DgSO.Columns(icol).ReadOnly = True
                Case 2
                    DgSO.Columns(icol).HeaderText = "Keterangan"
                    DgSO.Columns(icol).ReadOnly = True

                Case 3
                    DgSO.Columns(icol).HeaderText = "Nilai Estimasi"
                    DgSO.Columns(icol).ReadOnly = True
                    DgSO.Columns(icol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DgSO.Columns(icol).DefaultCellStyle.Format = "##,0"

                Case 4
                    DgSO.Columns(icol).HeaderText = "Nilai Realisasi"
                    DgSO.Columns(icol).ReadOnly = True
                    DgSO.Columns(icol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DgSO.Columns(icol).DefaultCellStyle.Format = "##,0"

                Case 5
                    DgSO.Columns(icol).HeaderText = "Selisih Realisasi"
                    DgSO.Columns(icol).ReadOnly = True
                    DgSO.Columns(icol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DgSO.Columns(icol).DefaultCellStyle.Format = "##,0"
            End Select

        Next


    End Sub

    Private Sub cekperiodeaktif()

        sql = "exec spTblRRAK'BulanAktif',0,'x'," & TxtKodetoko.Text & ",0,'x','x',0,0,'x','" & txtNoRRAK.Text & "','x','x'"
        RsConn = conn.Execute(sql)

        Dim TanggalBuat As Integer = Microsoft.VisualBasic.DateAndTime.Day((RsConn("TglCreate").Value))
        Dim BulanBuat As Integer = Microsoft.VisualBasic.DateAndTime.Month((RsConn("TglCreate").Value))
        Dim TanggalIni As Integer = Microsoft.VisualBasic.DateAndTime.Day(tglserver)
        Dim BulanIni As Integer = Microsoft.VisualBasic.DateAndTime.Month(tglserver)

        If BulanBuat <> BulanIni Then
            FlagPesanBulan = True
        End If

    End Sub
    Private Sub CariAkses()

        FlagPesanUserAPP = True
        sql = "exec spTblRRAK 'Cariakses',0,'x',0,0,'x','x',0,0,'x','x','" & StrNamaUser & "','x'"
        RsConn = conn.Execute(sql)
        If Not IsDBNull(RsConn("div").Value) Then
            idusr = (RsConn("div").Value)
            If idusr = "FA" Then
                FlagPesanUserAPP = False

            Else
                FlagPesanUserAPP = True
                '' RsConn.Close()
            End If
        End If

    End Sub

    Private Sub CariAksesPembatalan()

        sql = "exec spTblRRAK 'Cariakses',0,'x',0,0,'x','x',0,0,'x','x','" & StrNamaUser & "','x'"
        RsConn = conn.Execute(sql)
        idusr = (RsConn("div").Value)
        If idusr = "FA" Then
            FlagPesanUserBATAL = True
        Else
            FlagPesanUserBATAL = False
            '' RsConn.Close()
        End If

    End Sub
    Private Sub cekaktifestimasi()
        Call cekperiodeaktif()
        Call CariAksesPembatalan()
        If FlagPesanBulan = True Then
            MsgBox("Periode Estimasi hanya dapat dilakukan di bulan yang sama", vbOKOnly + vbInformation, "Info")
            Call kunci()
            btnFindToko.Enabled = True
            BtnNoRRAK.Enabled = True
            BtnApproval.Enabled = False
            Button1.Enabled = False
            BtnEdit.Enabled = False
            BtnSave.Enabled = False
            Exit Sub
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call cekperiodeaktif()
        Call CariAksesPembatalan()

        If FlagPesanBulan = True AndAlso FlagPesanUserBATAL = True Then
            MsgBox("Maaf Pembatalan hanya dapat dilakukan oleh Area Coordinator dan Periode pembatalan hanya dapat dilakukan di bulan yang sama", vbOKOnly + vbInformation, "Info")
            Exit Sub
        ElseIf FlagPesanBulan = True Then
            MsgBox("Periode pembatalan hanya dapat dilakukan di bulan yang sama", vbOKOnly + vbInformation, "Info")
            Exit Sub
        ElseIf FlagPesanUserBATAL = True Then
            MsgBox("Maaf Pembatalan hanya dapat dilakukan oleh Area Coordinator", vbOKOnly + vbInformation, "Info")
            Exit Sub
        Else
            MsgBox("Apakah Anda yakin Akan Membatalkan RRAK?", vbOKOnly + vbInformation, "Info")
            ''SP CANCLE

            sql = "exec spTblRRAK'Pembatalan',0,'x'," & TxtKodetoko.Text & ",0,'x','x',0,0,'x','" & txtNoRRAK.Text & "','" & StrNamaUser & "','x'"
            RsConn = conn.Execute(sql)
            MsgBox("Estimasi RRAK Dibatalkan", vbOKOnly + vbInformation, "Info")
            Call kunci()
            btnFindToko.Enabled = True
            BtnNoRRAK.Enabled = True
            txtpengembalian.Enabled = False
            txtvia.Enabled = False
            txtket.Enabled = False


        End If
    End Sub
    Private Sub cekuserPrint()
        Try
            sql = "exec spTblRRAK 'AmbilUser',0,'" & txtjenis.Text & "'," & TxtKodetoko.Text & ",0,'x','x',0,0,'x','" & txtNoRRAK.Text & "','x','x'"
            RsConn = conn.Execute(sql)
            If Not RsConn.EOF Then
                userpng = RsConn("PenanggungJawab").Value
            End If
        Catch ex As Exception
            userpng = "-"
        End Try
        
    End Sub

End Class