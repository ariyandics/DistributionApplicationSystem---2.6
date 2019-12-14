Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Data.OleDb
Public Class FrmLockSO
    Dim sql As String
    Dim conn As New ADODB.Connection
    Dim RsConn As New ADODB.Recordset
    Dim strplu, strnamabarang, strbarcode, strrak As String
    Dim nourut As Integer
    Dim z, x, jumlah, idjenisstok As Integer

    Private Sub FrmLockSO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Call kunci()
        Call bersih()
        BtnAdd.Enabled = True
        btnFind.Enabled = True
    End Sub
    Private Sub GbrTombol()
        Me.BtnAdd.Image = System.Drawing.Image.FromFile(icoadd)
        Me.BtnCancel.Image = System.Drawing.Image.FromFile(icocancel)
        Me.BtnProses.Image = System.Drawing.Image.FromFile(icoapprove)
        Me.BtnPrint.Image = System.Drawing.Image.FromFile(icoprint)
    End Sub
    Private Sub kunci()
        BtnAdd.Enabled = False
        BtnCancel.Enabled = False
        BtnProses.Enabled = False
        BtnPrint.Enabled = False
        'Panel1.Enabled = False
        cmbJenisSO.Enabled = False
        cmbTipeSO.Enabled = False
        CmbTipeStock.Enabled = False
        GroupBox1.Enabled = False
        BtnTambah.Enabled = False
        BtnHapus.Enabled = False
        btnFind.Enabled = False

    End Sub
    Private Sub bersih()
        txtNo.Clear()
        txtTanggal.Clear()
        TxtUser.Clear()
        cmbJenisSO.Text = ""
        cmbTipeSO.Text = ""
        CmbTipeStock.Text = ""
        txtcari.Clear()
        txtNo.ReadOnly = True
        txtcari.ReadOnly = True
    End Sub

    Private Sub isilist()
        jumlah = ListView1.Items.Count
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Call kunci()
        Call cmblist()
        txtTanggal.Text = Format(Now, "dd-MMMM-yyyy")
        TxtUser.Text = StrNamaUser
        BtnCancel.Enabled = True

        RsConfig = conn.Execute("select  dbo.fcGetNomorStockOpname() xx")
        txtNo.Text = RsConfig("xx").Value

        Panel1.Enabled = True
        CmbTipeStock.Enabled = True
        BtnProses.Enabled = True
    End Sub

    Private Sub cmblist()

        cmbTipeSO.Items.Clear()
        sql = "exec spMstTipeSO 'Get', 1,'namaTipeSO','idUser','2017-01-01','2017-01-01',1"
        RsConfig = conn.Execute(sql)
        If Not RsConfig.EOF Then
            RsConfig.MoveFirst()
            Do While Not RsConfig.EOF
                cmbTipeSO.Items.Add(RsConfig("namatipeso").Value)
                RsConfig.MoveNext()
            Loop
        End If


        cmbJenisSO.Items.Clear()
        sql = "exec spMstJenisSO 'Get',2,1,'namaJenisSo','idUser','2017-01-01','2017-01-01',1"
        RsConfig = conn.Execute(sql)
        If Not RsConfig.EOF Then
            RsConfig.MoveFirst()
            Do While Not RsConfig.EOF
                cmbJenisSO.Items.Add(RsConfig("namaJenisSo").Value)
                RsConfig.MoveNext()
            Loop
        End If

        CmbTipeStock.Items.Clear()
        sql = "exec spMstJenisStok 'Get',1,'namaJenisStok','2017-01-01','2017-01-01','idUser',1"
        RsConfig = conn.Execute(sql)
        If Not RsConfig.EOF Then
            RsConfig.MoveFirst()
            Do While Not RsConfig.EOF
                CmbTipeStock.Items.Add(RsConfig("namaJenisStok").Value)
                RsConfig.MoveNext()
            Loop
        End If
    End Sub

    Private Sub cmbTipeSO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipeSO.SelectedIndexChanged
        If cmbTipeSO.Text = "GRAND" Then
            cmbJenisSO.Enabled = False
            cmbJenisSO.Text = ""
            Call nonpilih()
            RbALlItem.Checked = True
            GroupBox1.Enabled = False
            cmbJenisSO.Text = "All"
        Else
            Call nonpilih()
            cmbJenisSO.Enabled = True
            cmbJenisSO.Focus()
            Listview2.Items.Clear()
            ListView1.Items.Clear()
        End If
    End Sub

    Private Sub nonpilih()
        RbALlItem.Checked = False
        RbAllRak.Checked = False
        rbItem.Checked = False
        RbRak.Checked = False
    End Sub

    Private Sub cmbJenisSO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbJenisSO.SelectedIndexChanged
        If cmbJenisSO.Text <> "" Then
            GroupBox1.Enabled = True
        Else
            GroupBox1.Enabled = False
        End If
    End Sub

    Private Sub CmbTipeStock_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbTipeStock.SelectedIndexChanged
        If CmbTipeStock.Text <> "" Then
            cmbTipeSO.Enabled = True
        Else
            cmbTipeSO.Enabled = False
        End If
    End Sub

    Private Sub RbALlItem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbALlItem.CheckedChanged
        If RbALlItem.Checked = True Then
            Call LoadData()
            Listview2.Enabled = False
            txtcari.ReadOnly = True
            Call LoadDataTmp()
        End If

    End Sub

    Private Sub LoadData()
        Dim strfind As String
        Listview2.Columns.Clear()
        Listview2.Items.Clear()
        Listview2.View = Windows.Forms.View.Details
        Listview2.GridLines = True
        Listview2.FullRowSelect = True

        Listview2.Columns.Add("Barcode", 80)
        Listview2.Columns.Add("SKU", 60)
        Listview2.Columns.Add("Description", 250)
        Listview2.Columns.Add("idproduk", 0)

        If txtcari.Text = "" Then
            strfind = "%"
        Else
            strfind = txtcari.Text
        End If

       ' sql = "select idproduk,barcode,kodeproduk,namapanjang from mstproduk where idjenisproduk=1 and kodetag not in ('E','K') and flagbkl=0 and namapanjang like '%" & strfind & "%'"
        sql = "exec spfind 'GetAllProduk','%" & strfind & "%','x'"
        RsConn = conn.Execute(sql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()

            Do While Not RsConn.EOF
                idProduk = RsConn("idproduk").Value
                strplu = RsConn("kodeproduk").Value
                strnamabarang = RsConn("namapanjang").Value
                strbarcode = RsConn("barcode").Value


                'qtykarton = strqtypo / strC2

                Dim arr(4) As String
                Dim itm As ListViewItem


                arr(0) = strbarcode
                arr(1) = strplu
                arr(2) = strnamabarang
                arr(3) = idProduk

                itm = New ListViewItem(arr)
                Listview2.Items.Add(itm)

                RsConn.MoveNext()

            Loop

        End If

        RsConn.Close()
    End Sub

    Private Sub LoadDataTmp()
        ListView1.Columns.Clear()
        ListView1.View = Windows.Forms.View.Details
        ListView1.GridLines = True
        ListView1.FullRowSelect = True

        If RbAllRak.Checked = True Or RbRak.Checked = True Then
            ListView1.Columns.Add("idrak", 0)
            ListView1.Columns.Add("Rak", 40)

        End If

        ListView1.Columns.Add("Barcode", 80)
        ListView1.Columns.Add("SKU", 60)
        ListView1.Columns.Add("Description", 200)
        ListView1.Columns.Add("idproduk", 0)




        If RbALlItem.Checked = True Then
            ListView1.Items.Clear()
            sql = "select idproduk,barcode,kodeproduk,namapanjang from mstproduk where idjenisproduk=1 and kodetag not in ('E','K') and flagbkl=0"
            RsConn = conn.Execute(sql)

            If Not RsConn.EOF Then
                RsConn.MoveFirst()

                Do While Not RsConn.EOF
                    idProduk = RsConn("idproduk").Value
                    strplu = RsConn("kodeproduk").Value
                    strnamabarang = RsConn("namapanjang").Value
                    strbarcode = RsConn("barcode").Value


                    'qtykarton = strqtypo / strC2

                    Dim arr(4) As String
                    Dim itm As ListViewItem


                    arr(0) = strbarcode
                    arr(1) = strplu
                    arr(2) = strnamabarang
                    arr(3) = idProduk

                    itm = New ListViewItem(arr)
                    ListView1.Items.Add(itm)

                    RsConn.MoveNext()

                Loop

            End If
            RsConn.Close()
        End If




        If rbItem.Checked = True Then
            Dim arr(4) As String
            Dim itm As ListViewItem


            arr(0) = strbarcode
            arr(1) = strplu
            arr(2) = strnamabarang
            arr(3) = idProduk

            itm = New ListViewItem(arr)
            ListView1.Items.Add(itm)

        End If


        If RbRak.Checked = True Then


            sql = "select a.barcode,a.kodeProduk  ,a.namaPanjang ,b.* from MstProduk a " & _
                  " inner join ( select a.idRak,b.namaRak ,a.idProduk   from  MstPlanoDc a inner join MstRakDc b on a.idRak =b.idRak ) b on a.idProduk =b.idProduk " & _
                  " where a.idJenisProduk =1 and flagbkl=0 and kodetag not in ('E','K') and b.idrak=" & idProduk
            RsConn = conn.Execute(sql)

            If Not RsConn.EOF Then
                RsConn.MoveFirst()

                Do While Not RsConn.EOF
                    idProduk = RsConn("idproduk").Value
                    strplu = RsConn("kodeproduk").Value
                    strnamabarang = RsConn("namapanjang").Value
                    strbarcode = RsConn("barcode").Value
                    strrak = RsConn("namarak").Value


                    'qtykarton = strqtypo / strC2

                    Dim arr(6) As String
                    Dim itm As ListViewItem

                    arr(0) = RsConn("idrak").Value
                    arr(1) = strrak
                    arr(2) = strbarcode
                    arr(3) = strplu
                    arr(4) = strnamabarang
                    arr(5) = idProduk



                    itm = New ListViewItem(arr)
                    ListView1.Items.Add(itm)

                    RsConn.MoveNext()

                Loop

            End If
            RsConn.Close()
        End If

        If RbAllRak.Checked = True Then
            ListView1.Items.Clear()
            sql = "select a.barcode,a.kodeProduk  ,a.namaPanjang ,b.* from MstProduk a " & _
                 " inner join ( select a.idRak,b.namaRak ,a.idProduk   from  MstPlanoDc a inner join MstRakDc b on a.idRak =b.idRak ) b on a.idProduk =b.idProduk " & _
                 " where a.idJenisProduk =1 and flagbkl=0 and kodetag not in ('E','K') "
            RsConn = conn.Execute(sql)

            If Not RsConn.EOF Then
                RsConn.MoveFirst()

                Do While Not RsConn.EOF
                    idProduk = RsConn("idproduk").Value
                    strplu = RsConn("kodeproduk").Value
                    strnamabarang = RsConn("namapanjang").Value
                    strbarcode = RsConn("barcode").Value
                    strrak = RsConn("namarak").Value


                    'qtykarton = strqtypo / strC2

                    Dim arr(6) As String
                    Dim itm As ListViewItem

                    arr(0) = RsConn("idrak").Value
                    arr(1) = strrak
                    arr(2) = strbarcode
                    arr(3) = strplu
                    arr(4) = strnamabarang
                    arr(5) = idProduk



                    itm = New ListViewItem(arr)
                    ListView1.Items.Add(itm)

                    RsConn.MoveNext()

                Loop

            End If
            RsConn.Close()

        End If

    End Sub

    Private Sub LoadRak()
        Dim strfind As String
        Listview2.Columns.Clear()
        Listview2.Items.Clear()
        Listview2.View = Windows.Forms.View.Details
        Listview2.GridLines = True
        Listview2.FullRowSelect = True

        Listview2.Columns.Add("id Rak", 0)
        Listview2.Columns.Add("Nama Rak", 330)


        If txtcari.Text = "" Then
            strfind = "%"
        Else
            strfind = txtcari.Text
        End If

        sql = "select idRak,namarak from MstRakDc where namarak like '%" & strfind & "%'"
        RsConn = conn.Execute(sql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()

            Do While Not RsConn.EOF
                strnamabarang = RsConn("namarak").Value
                idProduk = RsConn("idrak").Value

                'qtykarton = strqtypo / strC2

                Dim arr(2) As String
                Dim itm As ListViewItem

                arr(0) = idProduk
                arr(1) = strnamabarang


                itm = New ListViewItem(arr)
                Listview2.Items.Add(itm)

                RsConn.MoveNext()

            Loop

        End If

        RsConn.Close()
    End Sub

    Private Sub txtcari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcari.TextChanged
        If RbAllRak.Checked = True Or RbRak.Checked = True Then
            Call LoadRak()
        Else
            Call LoadData()
        End If

    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Call kunci()
        Call bersih()
        BtnAdd.Enabled = True
        ListView1.Items.Clear()
        Listview2.Items.Clear()
    End Sub

    Private Sub rbItem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbItem.CheckedChanged
        If rbItem.Checked = True Then
            Call LoadData()
            Listview2.Enabled = True
            txtcari.ReadOnly = False
            txtcari.Focus()
            BtnTambah.Enabled = True
            ListView1.Clear()
        Else
            ListView1.Clear()
            Listview2.Clear()
        End If
    End Sub


    Private Sub Listview2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Listview2.SelectedIndexChanged
        Dim z As Integer
        z = Listview2.SelectedItems.Count

        If z = 0 Then
            Exit Sub
        Else


            If RbALlItem.Checked = True Or rbItem.Checked = True Then
                strbarcode = Listview2.SelectedItems.Item(0).SubItems(0).Text
                strplu = Listview2.SelectedItems.Item(0).SubItems(1).Text
                strnamabarang = Listview2.SelectedItems.Item(0).SubItems(2).Text
                idProduk = Listview2.SelectedItems.Item(0).SubItems(3).Text
            End If

            If RbAllRak.Checked = True Or RbRak.Checked = True Then
                idProduk = Listview2.SelectedItems.Item(0).SubItems(0).Text
            End If
        End If
    End Sub

    Private Sub BtnTambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTambah.Click
        z = Listview2.SelectedItems.Count
        If z = 0 Then
            Exit Sub
        Else
            If RbALlItem.Checked = True Or rbItem.Checked = True Then
                For Each item As ListViewItem In ListView1.Items
                    If item.Text = strbarcode Then
                        MessageBox.Show("Produk ini Sudah di daftarkan ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                Next

                Call LoadDataTmp()
                BtnProses.Enabled = True
            End If
            If RbAllRak.Checked = True Or RbRak.Checked = True Then
                For Each item As ListViewItem In ListView1.Items
                    If item.Text = idProduk Then
                        MessageBox.Show("Rak ini sudah di daftarkan ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                Next
                Call LoadDataTmp()
                BtnProses.Enabled = True
            End If

        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

        x = ListView1.SelectedItems.Count

        If x = 0 Then
            Exit Sub
        Else
            BtnHapus.Enabled = True
        End If
    End Sub

    Private Sub BtnHapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnHapus.Click

        For Each lsvrow As ListViewItem In ListView1.SelectedItems
            ListView1.Items.Remove(lsvrow)
        Next

    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProses.Click
        Call isilist()
        If jumlah > 0 Then
            Dim result2 As DialogResult = MessageBox.Show("Proses Data Lock Stock Inventory?", _
                        "Warning !!", _
                        MessageBoxButtons.YesNo, _
                        MessageBoxIcon.Question)
            If result2 = DialogResult.Yes Then
                sql = "exec spsoFreezeHeader 'GetSoBig'," & IdDC & "," & txtNo.Text & ",'" & cmbJenisSO.Text & "'," & idjenisstok & ",'" & StrNamaUser & "'"
                RsConn = conn.Execute(sql)
                If Not RsConn.EOF Then
                    MsgBox("Masih ada SO Grand No :" & RsConn("nomorSoAdjusment").Value & " yang belum di adjust!!!", vbOKOnly + vbCritical, "Info")
                    Exit Sub
                End If

                If CmbTipeStock.Text = "GOOD STOCK" Then
                    idjenisstok = 1
                Else
                    idjenisstok = 2
                End If

                If cmbJenisSO.Text = "" Then
                    cmbJenisSO.Text = "X"
                End If

                conn.Execute(" exec spsoFreezeHeader 'Add'," & IdDC & "," & txtNo.Text & ",'" & cmbJenisSO.Text & "'," & idjenisstok & ",'" & StrNamaUser & "'")
                Dim item As ListViewItem
                For i As Integer = 0 To ListView1.Items.Count - 1
                    item = ListView1.Items(i)
                    If RbALlItem.Checked = True Or rbItem.Checked = True Then
                        idProduk = (item.SubItems(3).Text)
                    Else
                        idProduk = (item.SubItems(5).Text)
                    End If
                    conn.Execute("exec spsoFreezeDetail 'Add' , " & IdDC & "," & txtNo.Text & "," & idProduk & "," & idjenisstok)
                Next

                conn.Execute(" exec spsoFreezeHeader 'Add'," & IdDC & "," & txtNo.Text & ",'" & cmbJenisSO.Text & "'," & idjenisstok & ",'" & StrNamaUser & "'")

                Call pesan(3)
                Call kunci()
                BtnAdd.Enabled = True
                BtnPrint.Enabled = True

            Else
                Exit Sub
            End If
        Else
            MsgBox("Tidak ada data yang di simpan ", vbOKOnly, "Informasi")
            Exit Sub
        End If
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Call cetak()

    End Sub

    Private Sub cetak()
        GetStringKoneksi()
        Dim Conn As New SqlConnection(ConnSQLClient)
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter("exec spsoFreezeDetail 'Cetak' , " & IdDC & "," & txtNo.Text & "," & idProduk & "," & idjenisstok, Conn)
        da.Fill(dt)

        Dim DataSetName As String = "DataSetKKSO"
        Dim DataTableName As String = "TblKKSO"
        Dim rds As New ReportDataSource(DataSetName, dt)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPerusahaan", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", "Kertas Kerja Stock Opname ( KKSO )", True))
        paramList.Add(New ReportParameter("NoKKSO", txtNo.Text, True))

        Dim ReportViewerForm As New FrmReport
        ReportViewerForm.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptKKSO.rdlc"
        ReportViewerForm.ReportViewer1.LocalReport.SetParameters(paramList)
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewerForm.ReportViewer1.RefreshReport()
        ReportViewerForm.Show()
    End Sub

    Private Sub RbRak_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbRak.CheckedChanged
        If RbRak.Checked = True Then
            Call LoadRak()
            Listview2.Enabled = True
            txtcari.ReadOnly = False
            txtcari.Focus()
            BtnTambah.Enabled = True
            ListView1.Clear()
        Else
            ListView1.Clear()
            Listview2.Clear()
        End If
    End Sub

    Private Sub RbAllRak_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbAllRak.CheckedChanged
        If RbAllRak.Checked = True Then
            Call LoadRak()
            Listview2.Enabled = False
            txtcari.ReadOnly = True
            Call LoadDataTmp()
        End If

    End Sub

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click

        txtNo.Text = FrmFind.cari("NoLockSO")
        If txtNo.Text = "0" Then Exit Sub
        sql = ""

        BtnPrint.Enabled = True

    End Sub

    Private Sub txtNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNo.TextChanged

    End Sub
End Class