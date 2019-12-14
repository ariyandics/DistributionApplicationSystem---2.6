Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Data.OleDb
Public Class FrmMasterMaxDC

    Dim sql As String
    Dim conn As New ADODB.Connection
    Dim RsConn As New ADODB.Recordset
    Dim tglrubah As Date
    Dim plu, namaproduk, KodeTag As String
    Dim MaxQtyAwal, MaxRpAwal, MaxQtyRevisi, MaxRpRevisi, AvgCost, lastcost, MinDisplay, kelas, SalesQty1, SalesQty2, SalesQty3 As Double
    Dim FlagEdit As Boolean
    Dim IdKtegori, IdSubdepartement, IdDepartement, QtyMaxNew As Int64


    Private Sub bersih()
        Me.TxtQty.Clear()
        Me.TxtKodeProduk.Clear()
        Me.TxtNamaBarang.Clear()

        Me.cmbfilterby.Text = ""
        Me.cmbfilterby.Items.Clear()

        Me.TxtQty.Enabled = False
        Me.BtnSave.Enabled = False
        Me.BtnEdit.Enabled = False
        Me.BtnCancel.Enabled = False
        Me.btnPrint.Enabled = False
    End Sub

    Private Sub ByKtegori()

        ListView1.Columns.Clear()
        ListView1.Items.Clear()
        ListView1.View = Windows.Forms.View.Details
        ListView1.GridLines = True
        ListView1.FullRowSelect = True
        ListView1.Columns.Add("No.", 40)
        ListView1.Columns.Add("SKU", 60)
        ListView1.Columns.Add("Description", 250)
        ListView1.Columns.Add("Tag", 100)
        ListView1.Columns.Add("Class", 40)
        ListView1.Columns.Add("Last Cost", 90, HorizontalAlignment.Right)
        ListView1.Columns.Add("Avg Cost", 90, HorizontalAlignment.Right)
        ListView1.Columns.Add("Sales Qty -3 Month", 100, HorizontalAlignment.Right)
        ListView1.Columns.Add("Sales Qty -2 Month", 100, HorizontalAlignment.Right)
        ListView1.Columns.Add("Sales Qty -1 Month", 100, HorizontalAlignment.Right)

        ListView1.Columns.Add("Min Display", 80, HorizontalAlignment.Right)
        ListView1.Columns.Add("Qty Max Awal", 80, HorizontalAlignment.Right)
        ListView1.Columns.Add("Rp Max Awal", 90, HorizontalAlignment.Right)

        If FlagEdit = True Then
            ListView1.Columns.Add("Qty Max Revisi", 60, HorizontalAlignment.Right)
            ListView1.Columns.Add("Rp Max Revisi", 80, HorizontalAlignment.Right)
        Else
            ListView1.Columns.Add("Qty Max Revisi", 0)
            ListView1.Columns.Add("Rp Max Revisi", 0)
        End If
        ListView1.Columns.Add("Tgl Rubah", 90)

        If RBDept.Checked = True And cmbfilterby.Text <> "" Then
            IdDC = Microsoft.VisualBasic.Left((cmbfilterby.Text.ToString), 1)
            IdDepartement = Val(Microsoft.VisualBasic.Mid((cmbfilterby.Text.ToString), 2, 2))
            sql = "exec spMstMaxDc 'GetbyDept'," & IdDC & "," & IdDepartement & ",0,0,0,'" & StrNamaUser & "','2017-10-01 01:01:01','2017-10-01 01:01:01',1,'%" & txtfind.Text & "%'"
        Else
            sql = "exec spMstMaxDc 'GetAll',0," & IdDepartement & ",0,0,0,'" & StrNamaUser & "','2017-10-01 01:01:01','2017-10-01 01:01:01',1,'%" & txtfind.Text & "%'"
        End If
        RsConn = conn.Execute(sql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()
            Dim nomor As Integer = 1
            Do While Not RsConn.EOF


                plu = RsConn("kodeProduk").Value
                namaproduk = RsConn("namaPanjang").Value
                KodeTag = RsConn("namaTag").Value
                kelas = RsConn("kelasproduk").Value
                lastcost = RsConn("LastCost").Value
                AvgCost = RsConn("AvgCost").Value
                SalesQty3 = RsConn("SalesQty3").Value
                SalesQty2 = RsConn("SalesQty2").Value
                SalesQty1 = RsConn("SalesQty1").Value
                MinDisplay = RsConn("mindis").Value
                MaxQtyAwal = RsConn("maxStok").Value
                MaxRpAwal = RsConn("maxStok").Value * RsConn("AvgCost").Value
                MaxQtyRevisi = RsConn("QtyRevisi").Value
                MaxRpRevisi = RsConn("QtyRevisi").Value * RsConn("AvgCost").Value
                tglrubah = RsConn("tglUpdate").Value

                Dim arr(16) As String
                Dim itm As ListViewItem
                arr(0) = nomor
                arr(1) = plu
                arr(2) = namaproduk
                arr(3) = KodeTag
                arr(4) = kelas
                arr(5) = lastcost.ToString("N")
                arr(6) = AvgCost.ToString("N")
                arr(7) = SalesQty3.ToString("N")
                arr(8) = SalesQty2.ToString("N")
                arr(9) = SalesQty1.ToString("N")
                arr(10) = MinDisplay.ToString("N")
                arr(11) = MaxQtyAwal.ToString("N")
                arr(12) = MaxRpAwal.ToString("N")
                arr(13) = MaxQtyRevisi.ToString("N")
                arr(14) = MaxRpRevisi.ToString("N")
                arr(15) = tglrubah

                itm = New ListViewItem(arr)
                ListView1.Items.Add(itm)
                nomor += 1
                RsConn.MoveNext()
            Loop

        End If
        RsConn.Close()
        Me.BtnEdit.Enabled = True
    End Sub

    Private Sub FrmMasterMaxDC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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


        Me.RBDept.Checked = False
        Me.RBAll.Checked = False
        Me.cmbfilterby.Enabled = False
        namadcAktif()
        Me.TxtKodeDC.Text = kodedc
        Me.TxtNamaDC.Text = namadc
        Me.TxtAlamatDC.Text = alamatdc
        btnPrint.Enabled = True
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        If Me.TxtKodeProduk.Text = "" And Me.TxtNamaBarang.Text = "" Then
            MsgBox("Silahkan pilih terlebih dahulu Item produk yang akan di ubah", vbInformation, "Perhatian")
            Exit Sub
        End If
        FlagEdit = True
        'ByKtegori()
        Me.TxtQty.Enabled = True
        Me.cmbfilterby.Enabled = False
        Me.TxtQty.Focus()
        BtnCancel.Enabled = True
        BtnEdit.Enabled = False
        BtnSave.Enabled = False
    End Sub

    Private Sub TxtQty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtQty.KeyDown
        If e.KeyCode = Keys.Delete Then
            ' Exit Sub
            e.Handled = True
        End If
        If e.KeyCode = Keys.Enter Then
            FlagEdit = True
            If Me.TxtKodeProduk.Text = "" Or Me.TxtNamaBarang.Text = "" Then
                MsgBox("Silahkan pilih item produk yang akan di edit", vbInformation, "Perhatian")
                Exit Sub
            ElseIf Me.TxtQty.Text = "" Then
                MsgBox("Masukan nilai Qty !!", vbInformation, "Perhatian")
                Exit Sub
            Else
                InsTmp()
                TxtQty.Clear()
                TxtKodeProduk.Clear()
                TxtNamaBarang.Clear()
                QtyMaxNew = 0
                BtnSave.Enabled = True
            End If

        End If
    End Sub

    Private Sub TxtQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtQty.KeyPress

        e.Handled = Not (Char.IsDigit(e.KeyChar) Or ".".Contains(e.KeyChar) Or e.KeyChar = Chr(Keys.Back))

    End Sub

    Private Sub TxtQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtQty.TextChanged
        If TxtQty.Text = "" Then Exit Sub
        QtyMaxNew = Replace(TxtQty.Text, ",.", "")
        TxtQty.Text = Format(QtyMaxNew, "#,##0")
        TxtQty.SelectionStart = Len(TxtQty.Text)

    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        Dim z As Integer
        z = ListView1.SelectedItems.Count

        If z = 0 Then
            Exit Sub
        Else
            Me.TxtKodeProduk.Text = ListView1.SelectedItems.Item(0).SubItems(1).Text
            Me.TxtNamaBarang.Text = ListView1.SelectedItems.Item(0).SubItems(2).Text

            Me.TxtQty.Focus()
        End If

    End Sub

    Private Sub InsTmp()

        GetIdProduk(Me.TxtKodeProduk.Text)
        sql = "exec spMstMaxDc 'InsTmp',0,0," & idProduk & ",0," & QtyMaxNew & ",'" & StrNamaUser & "','2017-10-01 01:01:01','2017-10-01 01:01:01',1,'x'"
        RsConn = conn.Execute(sql)

        LoadKriteria()
        Me.BtnSave.Enabled = True
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        FlagEdit = False
        Simpan()
    End Sub

    Private Sub Simpan()
        If MessageBox.Show("Apakah sudah yakin dengan data Revisi tersebut dan akan di simpan ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            sql = "exec spMstMaxDc 'UpdateMax',0,0,0,0,0,'" & StrNamaUser & "','2017-10-01 01:01:01','2017-10-01 01:01:01',1,'x'"
            RsConn = conn.Execute(sql)
            MsgBox("Data Berhasil di edit", vbInformation, "")

            LoadKriteria()
            Me.TxtQty.Clear()
            Me.BtnSave.Enabled = False
            Me.TxtQty.Enabled = False
            Me.TxtKodeProduk.Clear()
            Me.TxtNamaBarang.Clear()

        End If
    End Sub

    Private Sub LoadKriteria()
        ByKtegori()
    End Sub

    Private Sub IsiCmboByKategori()
        sql = "select idkategori,NamaKategori from MstKategori order by idkategori asc"
        RsConn = conn.Execute(sql)

        If Not RsConn.EOF Then
            Do
                cmbfilterby.Items.Add(RsConn("IdKategori").Value & "-" & RsConn("NamaKategori").Value)
                RsConn.MoveNext()
            Loop Until RsConn.EOF = True
        End If

    End Sub
    Private Sub IsiCmboBySubDepartement()
        sql = "select Iddepartement,IdSubdepartement,NamaSubdepartement from MstSubDepartement order by IdSubdepartement asc"
        RsConn = conn.Execute(sql)

        If Not RsConn.EOF Then
            Do
                cmbfilterby.Items.Add(RsConn("IdSubdepartement").Value & "-" & RsConn("NamaSubdepartement").Value)
                RsConn.MoveNext()
            Loop Until RsConn.EOF = True
        End If

    End Sub
    Private Sub IsiCmboByDepartement()
        sql = "select iddivisi,Iddepartement,Namadepartement from MstDepartement where Iddepartement > 0 order by iddivisi,Iddepartement asc"
        RsConn = conn.Execute(sql)

        If Not RsConn.EOF Then

            Do
                cmbfilterby.Items.Add(RsConn("iddivisi").Value & "" & RsConn("Iddepartement").Value & "-" & RsConn("Namadepartement").Value)
                RsConn.MoveNext()
            Loop Until RsConn.EOF = True
        End If

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbfilterby.SelectedIndexChanged
        If Me.cmbfilterby.Text = "" Then
            Exit Sub
        Else
            LoadBerdasarkanIsiCombo()
        End If

    End Sub

    Private Sub LoadBerdasarkanIsiCombo()
        If RBDept.Checked = True Or RBAll.Checked = True Then
            ByKtegori()
        End If

    End Sub


    Private Sub RBDept_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBDept.CheckedChanged
        If Me.RBDept.Checked = True Then
            FlagEdit = False
            Delete()
            Me.cmbfilterby.Enabled = True
            Me.cmbfilterby.Text = ""
            Me.cmbfilterby.Items.Clear()
            Me.ListView1.Items.Clear()
            Me.TxtQty.Enabled = False
            Me.TxtQty.Clear()
            Me.TxtKodeProduk.Clear()
            Me.TxtNamaBarang.Clear()
            IsiCmboByDepartement()
        End If
    End Sub

    Private Sub RBAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBAll.CheckedChanged
        If Me.RBAll.Checked = True Then
            FlagEdit = False
            Delete()
            Me.cmbfilterby.Text = "ALL"
            Me.cmbfilterby.Items.Clear()
            Me.ListView1.Items.Clear()
            Me.cmbfilterby.Enabled = False
            Me.TxtQty.Enabled = False
            Me.TxtQty.Clear()
            Me.TxtKodeProduk.Clear()
            Me.TxtNamaBarang.Clear()
            ByKtegori()
        End If
    End Sub
    Private Sub Delete()
        '  sql = "exec spMstMaxDc 'Delete',0,0,0,0,0,'" & StrNamaUser & "','2017-10-01 01:01:01','2017-10-01 01:01:01',1"
        '  sql = "exec spMstMaxDc 'Delete',0,0,0,0,0,'" & StrNamaUser & "','2017-10-01 01:01:01','2017-10-01 01:01:01',1"
        '  RsConn = conn.Execute(sql)

    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Call bersih()
        BtnEdit.Enabled = True
        btnPrint.Enabled = True
        Call Delete()
        FlagEdit = False
        Call ByKtegori()
    End Sub

    Private Sub txtfind_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfind.KeyPress
        If (e.KeyChar Like "[',]") Then e.Handled() = True
    End Sub

    Private Sub txtfind_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtfind.TextChanged
        If RBAll.Checked = True Or RBDept.Checked = True Then
            Call ByKtegori()
        End If
    End Sub


    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim count As Integer
        count = ListView1.Items.Count - 1
        If count > 0 Then
            Call cetak()
        Else
            MsgBox("Tidak ada data yang di cetak", vbOKOnly + vbInformation, "Info")
            Exit Sub
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

        If RBDept.Checked = True And CmbFilterBy.Text <> "" Then
            sql = "exec spMstMaxDc 'GetbyDept'," & IdDC & "," & IdDepartement & ",0,0,0,'" & StrNamaUser & "','2017-10-01 01:01:01','2017-10-01 01:01:01',1,'%" & txtfind.Text & "%'"
        Else
            sql = "exec spMstMaxDc 'GetAll',0," & IdDepartement & ",0,0,0,'" & StrNamaUser & "','2017-10-01 01:01:01','2017-10-01 01:01:01',1,'%" & txtfind.Text & "%'"
        End If

        objConn = New OleDbConnection(strCONN)
        objCmd = New OleDbCommand(sql, objConn)
        objCmd.CommandType = CommandType.Text
        objCmd.Connection.Open()
        objCmd.CommandTimeout = 0
        objReader = objCmd.ExecuteReader
        objDataSet.Tables(0).Clear()
        objDataSet.Tables(0).Load(objReader)
        objReader.Close()
        objConn.Close()

        Dim rds As ReportDataSource = New ReportDataSource
        rds.Name = "DataSetMaxToko"
        rds.Value = objDataSet.Tables(0)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", "Master Max DC", True))
        paramList.Add(New ReportParameter("Kodetoko", TxtKodeDC.Text, True))
        paramList.Add(New ReportParameter("NamaToko", TxtNamaDC.Text, True))


        Dim ReportViewerForm As New FrmReport
        ReportViewerForm.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptMaxToko.rdlc"
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewerForm.ReportViewer1.LocalReport.SetParameters(paramList)
        ReportViewerForm.ReportViewer1.RefreshReport()
        ReportViewerForm.Show()
    End Sub

    
End Class