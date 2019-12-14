Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Public Class FrmMutasiStock
    Dim conn As New ADODB.Connection
    Dim RsConn As New ADODB.Recordset
    Dim barcode, plu, sql, KodeMovement As String
    Dim qty, Hpp, Netto, subtotal, C1, C2, SohGS, SohBS, QtyMutasi As Double
    Dim flag As Boolean
    Dim NoFakturTmp, NoMutasi As Long

    Private Sub FrmMutasiStock_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        BtnFindNoFaktur.Focus()
    End Sub

    Private Sub FrmMutasiStock_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Call CancelData()
        Call nilaiawal()
    End Sub

    Private Sub FrmMutasiStock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      
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


        Call namadcAktif()
        Call nilaiawal()
        flag = False
        Call GbrTombol()
        Call bersih()
        Call kunci()
        Me.BtnAdd.Enabled = True
        Me.BtnFindNoFaktur.Enabled = True
        Me.BtnAdd.Enabled = True
    End Sub
    Private Sub GbrTombol()
        Me.BtnAdd.Image = System.Drawing.Image.FromFile(icoadd)
        Me.BtnApproval.Image = System.Drawing.Image.FromFile(icoapprove)
        Me.BtnEdit.Image = System.Drawing.Image.FromFile(icoedit)
        Me.BtnCancel.Image = System.Drawing.Image.FromFile(icocancel)
        Me.BtnSave.Image = System.Drawing.Image.FromFile(icosave)
        Me.BtnPrint.Image = System.Drawing.Image.FromFile(icoprint)

    End Sub
    Private Sub nilaiawal()
        qty = 0
        Hpp = 0
        Netto = 0
        subtotal = 0
        C1 = 0
        C2 = 0
        SohGS = 0
        SohBS = 0
        QtyMutasi = 0
    End Sub

    Private Sub bersih()
        Me.TxtNoFaktur.Clear()
        Me.TxtKodeProduk.Clear()
        Me.TxtNamaBarang.Clear()
        Me.TxtKeterangan.Clear()
        Me.TxtQty.Clear()
        Me.ListView1.Items.Clear()
        Me.TxtUser.Clear()
        Me.TxtTglApprove.Clear()
        Me.TxtKodeDC.Clear()
        Me.TxtNamaDC.Clear()
        Me.TxtTanggal.Clear()
        Me.TxtQty.ReadOnly = True
        Me.TxtKeterangan.ReadOnly = True
        Me.txtNoBA.Clear()
        txtNoBA.ReadOnly = True

    End Sub

    Private Sub kunci()
        Me.BtnAdd.Enabled = False
        Me.RbBsTOGs.Enabled = False
        Me.RBGsTOBs.Enabled = False
        Me.BtnCancel.Enabled = False
        Me.BtnEdit.Enabled = False
        Me.BtnSave.Enabled = False
        Me.BtnFindBrg.Enabled = False
        Me.BtnApproval.Enabled = False
        Me.BtnFindNoFaktur.Enabled = False
        Me.BtnPrint.Enabled = False
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click

        Call kunci()
        Call bersih()
        flag = True
        BtnCancel.Enabled = True

        Me.TxtKodeDC.Text = kodedc
        Me.TxtNamaDC.Text = namadc
        GetServerDate()
        Me.TxtTanggal.Text = tglserver

        Me.RbBsTOGs.Enabled = True
        Me.RBGsTOBs.Enabled = True
        Me.RbBsTOGs.Checked = False
        Me.RBGsTOBs.Checked = False
        TxtKeterangan.ReadOnly = False
        txtNoBA.ReadOnly = False
        BtnFindBrg.Enabled = True
        BtnFindBrg.Focus()
        Me.TxtUser.Text = StrNamaUser
        Call NomorMutasiTemp()
    End Sub

    Private Sub NomorMutasiTemp()
        sql = "select dbo.fcGetNomorMutasiTmp()NomorMutasiTmp"
        RsConn = conn.Execute(sql)
        If Not RsConn.EOF Then
            NoFakturTmp = RsConn("NomorMutasiTmp").Value
            Me.TxtNoFaktur.Text = NoFakturTmp
        End If

        sql = "exec spMutasiSaldoHeaderDetail 'InsTmp'," & IdDC & ",'" & StrNamaUser & "','xxx',0,0,0,'ket','NoBA'"
        conn.Execute(sql)

    End Sub

    Private Sub CancelData()
        If Me.TxtNoFaktur.Text = "" Then
            Me.TxtNoFaktur.Text = 0
        End If
        sql = "exec spMutasiSaldoHeaderDetail 'CancelData'," & IdDC & ",'" & StrNamaUser & "','xxx'," & Me.TxtNoFaktur.Text & ",0,0,'ket','NoBA'"
        RsConn = conn.Execute(sql)

    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Call CancelData()
        Call bersih()
        Call kunci()
        Call nilaiawal()
        Me.BtnAdd.Enabled = True
        Me.BtnFindNoFaktur.Enabled = True
        Me.BtnAdd.Enabled = True


    End Sub

    Private Sub TxtQty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtQty.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Me.TxtQty.Text = "" Then
                MsgBox("Masukan dahulu Qty Barang yang akan dimutasi", vbExclamation, "Perhatian")
                Exit Sub
            End If
            If Me.TxtKodeProduk.Text = "" Or Me.TxtNamaBarang.Text = "" Then
                MsgBox("Pilih dahulu barang yang akan dimutasi.", vbExclamation, "Perhatian")
                Exit Sub
            Else
                InsertTmp()
            End If
        End If
    End Sub
    Private Sub InsertTmp()
        If RbBsTOGs.Checked = True Then
            sql = "exec spMutasiSaldoHeaderDetail 'GetStockBS'," & IdDC & ",'" & StrNamaUser & "','xxx'," & Me.TxtNoFaktur.Text & "," & idProduk & "," & qty & ",'ket','NoBA'"
        Else
            sql = "exec spMutasiSaldoHeaderDetail 'GetStockGS'," & IdDC & ",'" & StrNamaUser & "','xxx'," & Me.TxtNoFaktur.Text & "," & idProduk & "," & qty & ",'ket','NoBA'"

        End If
        RsConn = conn.Execute(sql)

        If RsConn("qty").Value < qty Then
            MsgBox("Stock yang tersedia hanya " & Format(RsConn("qty").Value, "#,##0") & " !!!", vbOKOnly + vbInformation, "Info")
            TxtQty.SelectAll()
            TxtQty.Focus()
            Exit Sub
        End If

        BtnSave.Enabled = True
        RbBsTOGs.Enabled = False
        RBGsTOBs.Enabled = False
        If flag = False Then
            UpdateAfterEdit()
        End If

        If Me.TxtNoFaktur.Text = "" Then
            Me.TxtNoFaktur.Text = 0
        End If
        GetIdProduk(Me.TxtKodeProduk.Text)

        sql = "exec spMutasiSaldoHeaderDetail 'InsTmp'," & IdDC & ",'" & StrNamaUser & "','xxx'," & Me.TxtNoFaktur.Text & "," & idProduk & "," & qty & ",'ket','NoBA'"
        RsConn = conn.Execute(sql)
        LoadDataTmp()


    End Sub

    Private Sub TxtQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtQty.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(Keys.Back))
    End Sub

    Private Sub TxtQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtQty.TextChanged
        If TxtQty.Text = "" Then Exit Sub
        qty = Replace(TxtQty.Text, ".", "")
        TxtQty.Text = Format(qty, "#,##0")
        TxtQty.SelectionStart = Len(TxtQty.Text)

    End Sub

    Private Sub TxtKeterangan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtKeterangan.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNoBA.Focus()
        End If
    End Sub

    Private Sub TxtKeterangan_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtKeterangan.KeyPress
        If (e.KeyChar Like "[',]") Then e.Handled() = True
    End Sub


    Private Sub BtnFindBrg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFindBrg.Click
        If Me.RbBsTOGs.Checked = False And Me.RBGsTOBs.Checked = False Then
            MsgBox("silahkan pilih dulu Jenis Mutasi", vbInformation, "Perhatian")
            Exit Sub
        End If
        TxtKodeProduk.Text = FrmFind.cari("ProdukMutasi")

        If TxtKodeProduk.Text = "0" Then
            TxtKodeProduk.Text = ""
            Exit Sub
        Else
            getNamaProduk(TxtKodeProduk.Text, 0)
            TxtNamaBarang.Text = NamaProduk
        End If
        TxtQty.ReadOnly = False
        TxtQty.Focus()
    End Sub

    Private Sub BtnFindNoFaktur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFindNoFaktur.Click
        Call bersih()
        Call kunci()
        BtnAdd.Enabled = True
        BtnFindNoFaktur.Enabled = True
        TxtNoFaktur.Text = FrmFind.cari("NomorMutasiStock")
        If TxtNoFaktur.Text = "0" Then
            TxtNoFaktur.Text = ""
            Exit Sub
        End If

        LoadData()
    End Sub

    Private Sub LoadData()

        ListView1.Columns.Clear()
        ListView1.Items.Clear()
        ListView1.View = Windows.Forms.View.Details
        ListView1.GridLines = True
        ListView1.FullRowSelect = True


        ListView1.Columns.Add("Nomor", 60)
        ListView1.Columns.Add("SKU", 100)
        If flag = True Then
            ListView1.Columns.Add("Description", 300)
            ListView1.Columns.Add("Avg Cost", 80, HorizontalAlignment.Right)
            ListView1.Columns.Add("SOH GS", 120, HorizontalAlignment.Right)
            ListView1.Columns.Add("SOH BS", 120, HorizontalAlignment.Right)
        Else
            ListView1.Columns.Add("Description", 580)
            ListView1.Columns.Add("Avg Cost", 100, HorizontalAlignment.Right)
            ListView1.Columns.Add("SOH GS", 0, HorizontalAlignment.Right)
            ListView1.Columns.Add("SOH BS", 0, HorizontalAlignment.Right)
        End If
        ListView1.Columns.Add("Qty Mutasi", 100, HorizontalAlignment.Right)
        ListView1.Columns.Add("Netto", 120, HorizontalAlignment.Right)


        sql = "exec spMutasiSaldoHeaderDetail 'LoadData'," & IdDC & ",'" & StrNamaUser & "','xxx'," & Me.TxtNoFaktur.Text & ",0,0,'ket','NoBA'"

        RsConn = conn.Execute(sql)

        If Not RsConn.EOF Then
            namadcAktif()
            Me.TxtNamaDC.Text = namadc
            Me.TxtKodeDC.Text = kodedc
            Me.TxtTanggal.Text = Format(RsConn("tglMutasi").Value, "dd-MM-yyyy")
            Me.TxtUser.Text = RsConn("userid").Value
            If RsConn("kodeMovment").Value = "MBG" Then
                RbBsTOGs.Checked = True
            Else
                RBGsTOBs.Checked = True
            End If

            If RsConn("statusproses").Value = 1 Then
                Me.BtnEdit.Enabled = False
                Me.BtnApproval.Enabled = False
                Me.BtnPrint.Enabled = True
                Me.TxtTglApprove.Text = Format(RsConn("tglapprove").Value, "dd-MM-yyyy")

            Else
                BtnPrint.Enabled = False
                If Me.BtnSave.Enabled = True Then
                    Me.BtnEdit.Enabled = False
                    Me.BtnApproval.Enabled = False
                Else
                    Me.BtnEdit.Enabled = True
                    Me.BtnApproval.Enabled = True
                End If


            End If

            If IsDBNull(RsConn("keterangan").Value) Then
                Me.TxtKeterangan.Text = ""
            Else
                Me.TxtKeterangan.Text = RsConn("keterangan").Value
            End If

            If IsDBNull(RsConn("NoBA").Value) Then
                Me.txtNoBA.Text = ""
            Else
                Me.txtNoBA.Text = RsConn("NoBA").Value
            End If

            RsConn.MoveFirst()
            Dim nomor As Integer = 1
            Do While Not RsConn.EOF

                Dim arr(10) As String
                Dim itm As ListViewItem
                arr(0) = nomor
                arr(1) = RsConn("kodeProduk").Value
                arr(2) = RsConn("namaPanjang").Value
                arr(3) = Format(RsConn("AvgCost").Value, "#,##0.#")
                arr(4) = Format(RsConn("SOHGS").Value, "#,##0")
                arr(5) = Format(RsConn("SOHBS").Value, "#,##0")
                arr(6) = Format(RsConn("QtyMutasi").Value, "#,##0")
                arr(7) = Format(RsConn("Netto").Value, "#,##0.##")


                itm = New ListViewItem(arr)
                ListView1.Items.Add(itm)
                nomor += 1
                RsConn.MoveNext()
            Loop

        End If
        RsConn.Close()

    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        flag = False
        Call symbol()
        Call kunci()
        BtnSave.Enabled = True
        BtnCancel.Enabled = True
        BtnFindBrg.Enabled = True
        BtnFindBrg.Focus()
        TxtKeterangan.ReadOnly = False

        sql = " select * from MutasiSaldoDetail where NomorMutasi=" & TxtNoFaktur.Text
        RsConn = conn.Execute(sql)
        If Not RsConn.EOF Then
            RsConn.MoveFirst()
            Do While Not RsConn.EOF
                sql = "exec spMutasiSaldoHeaderDetail 'InsTmp'," & IdDC & ",'" & StrNamaUser & "','xxx'," & TxtNoFaktur.Text & "," & RsConn("idproduk").Value & "," & RsConn("qty").Value & ",'ket','NoBA'"
                conn.Execute(sql)
                RsConn.MoveNext()
            Loop

        End If
        LoadDataTmp()

    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If txtNoBA.Text = "" Then
            MsgBox("No Berita Acara belum di isi !!!", vbOKOnly + vbExclamation, "Info")
            txtNoBA.Focus()
            Exit Sub
        End If

        If Me.RbBsTOGs.Checked = True Then
            KodeMovement = "MBG"
        Else
            KodeMovement = "MGB"
        End If

        If flag = True Then
            GetNomerMutasi()

            sql = "Update MutasiStockTmp set NomorMutasi=" & NoMutasi & " where NomorMutasi=" & Me.TxtNoFaktur.Text & " and IdUser='" & StrNamaUser & "'"
            RsConn = conn.Execute(sql)
            TxtNoFaktur.Text = NoMutasi

            sql = "exec spMutasiSaldoHeaderDetail 'Add'," & IdDC & ",'" & StrNamaUser & "','" & KodeMovement & "'," & NoMutasi & ",0,0,'" & Me.TxtKeterangan.Text & "','" & Me.txtNoBA.Text & "'"
            RsConn = conn.Execute(sql)
        Else
            sql = "exec spMutasiSaldoHeaderDetail 'UpdData'," & IdDC & ",'" & StrNamaUser & "','" & KodeMovement & "'," & Me.TxtNoFaktur.Text & ",0,0,'" & Me.TxtKeterangan.Text & "','" & Me.txtNoBA.Text & "'"
            RsConn = conn.Execute(sql)

        End If

        MsgBox("Data Berhasil di Edit dan disimpan", vbInformation, "Konfirmasi")
        Call kunci()
        Me.BtnFindNoFaktur.Enabled = True
        Me.TxtQty.ReadOnly = True
        Me.BtnEdit.Enabled = True
        Me.BtnApproval.Enabled = True
        Me.BtnAdd.Enabled = True
        Call CancelData()
        Call nilaiawal()
    End Sub

    Private Sub BtnApproval_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnApproval.Click
        If MessageBox.Show("Apakah anda sudah yakin dengan data tersebut dan ingin di Approve ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            If Me.RbBsTOGs.Checked = True Then
                KodeMovement = "MBG"
            Else
                KodeMovement = "MGB"
            End If

            sql = "exec spMutasiSaldoHeaderDetail 'GetStock'," & IdDC & ",'" & StrNamaUser & "','" & KodeMovement & "'," & Me.TxtNoFaktur.Text & ",0,0,'ket','NoBA'"
            RsConfig = conn.Execute(sql)
            If Not RsConfig.EOF Then
                RsConfig.MoveFirst()
                MsgBox("Stock " & RsConfig("namapanjang").Value & " tidak mencukupi!!!", vbOKOnly + vbCritical, "Gagal Approve")
                Exit Sub

            Else

                sql = "exec spMutasiSaldoHeaderDetail 'ApproveData'," & IdDC & ",'" & StrNamaUser & "','" & KodeMovement & "'," & Me.TxtNoFaktur.Text & ",0,0,'ket','NoBA'"
                RsConn = conn.Execute(sql)
                MsgBox("Data Berhasil di Approve", vbInformation, "Konfirmasi")
                Me.BtnApproval.Enabled = False
                Call kunci()
                Call LoadData()
                Me.BtnAdd.Enabled = True
                Me.BtnFindNoFaktur.Enabled = True

            End If
        End If
    End Sub


    Private Sub GetNomerMutasi()
        sql = "Select dbo.fcGetNomorMutasiStock()NomorMutasi"
        RsConn = conn.Execute(sql)
        If Not RsConn.EOF Then
            NoMutasi = RsConn("NomorMutasi").Value
        End If
    End Sub

    Private Sub UpdateAfterEdit()
        Call GetIdProduk(Me.TxtKodeProduk.Text)
        sql = "exec spMutasiSaldoHeaderDetail 'UpdateData'," & IdDC & ",'" & StrNamaUser & "','xxx'," & Me.TxtNoFaktur.Text & "," & idProduk & "," & Me.TxtQty.Text & ",'" & Me.TxtKeterangan.Text & "','" & Me.txtNoBA.Text & "'"
        RsConn = conn.Execute(sql)
        LoadData()

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
        ListView1.Columns.Add("Nomor", 60)
        ListView1.Columns.Add("SKU", 100)
        ListView1.Columns.Add("Description", 340)
        ListView1.Columns.Add("Avg Cost", 80, HorizontalAlignment.Right)
        ListView1.Columns.Add("SOH GS", 120, HorizontalAlignment.Right)
        ListView1.Columns.Add("SOH BS", 120, HorizontalAlignment.Right)
        ListView1.Columns.Add("Qty Mutasi", 100, HorizontalAlignment.Right)
        ListView1.Columns.Add("Netto", 120, HorizontalAlignment.Right)


        'GetIdProduk(Me.TxtKodeProduk.Text)
        sql = "exec spMutasiSaldoHeaderDetail 'LoadTmp'," & IdDC & ",'" & StrNamaUser & "','xxx'," & TxtNoFaktur.Text & "," & idProduk & ",0,'ket','NoBA'"

        RsConn = conn.Execute(sql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()
            Dim nomor As Integer = 1
            Do While Not RsConn.EOF

                Dim arr(10) As String
                Dim itm As ListViewItem
                arr(0) = nomor
                arr(1) = RsConn("kodeProduk").Value
                arr(2) = RsConn("namaPanjang").Value
                arr(3) = Format(RsConn("AvgCost").Value, "#,##0.#")
                arr(4) = Format(RsConn("SOHGS").Value, "#,##0")
                arr(5) = Format(RsConn("SOHBS").Value, "#,##0")
                arr(6) = Format(RsConn("QtyMutasi").Value, "#,##0")
                arr(7) = Format(RsConn("Netto").Value, "#,##0.##")


                itm = New ListViewItem(arr)
                ListView1.Items.Add(itm)
                nomor += 1
                RsConn.MoveNext()
            Loop

        End If
        RsConn.Close()

        Me.TxtKodeProduk.Clear()
        Me.TxtNamaBarang.Clear()
        Me.TxtQty.Clear()
        Me.BtnSave.Enabled = True
    End Sub


    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Call cetak()
    End Sub

    Private Sub cetak()
        Dim jenis As String
        If RbBsTOGs.Checked = True Then
            jenis = "Bad Stock To Good Stock"
        Else
            jenis = "Good Stock To Bad Stock"
        End If
        GetStringKoneksi()
        Dim Conn As New SqlConnection(ConnSQLClient)
        Dim dt As New DataTable


        sql = "exec spMutasiSaldoHeaderDetail 'Print'," & IdDC & ",'" & StrNamaUser & "','xxx'," & Me.TxtNoFaktur.Text & ",0,0,'ket','noBA'"

        Dim da As New SqlDataAdapter(sql, Conn)
        da.Fill(dt)

        Dim DataSetName As String = "DataSetMutasi"
        Dim DataTableName As String = "DataTableMutasi"
        Dim rds As New ReportDataSource(DataSetName, dt)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", "MUTASI STOCK DC", True))
        paramList.Add(New ReportParameter("kodeDC", kodedc, True))
        paramList.Add(New ReportParameter("NamaDC", namadc, True))
        paramList.Add(New ReportParameter("Jenis", jenis, True))
        paramList.Add(New ReportParameter("TglMutasi", TxtTglApprove.Text, True))
        paramList.Add(New ReportParameter("NoMutasi", TxtNoFaktur.Text, True))
        paramList.Add(New ReportParameter("Keterangan", TxtKeterangan.Text, True))
        paramList.Add(New ReportParameter("NoBA", txtNoBA.Text, True))
        paramList.Add(New ReportParameter("User", TxtUser.Text, True))


        Dim ReportViewerForm As New FrmReport
        ReportViewerForm.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptMutasiStock.rdlc"
        ReportViewerForm.ReportViewer1.LocalReport.SetParameters(paramList)
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewerForm.ReportViewer1.RefreshReport()
        ReportViewerForm.Show()
    End Sub

    Private Sub txtNoBA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNoBA.KeyPress
        If (e.KeyChar Like "[',]") Then e.Handled() = True
    End Sub

   
    Private Sub TxtNoFaktur_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNoFaktur.TextChanged

    End Sub
End Class