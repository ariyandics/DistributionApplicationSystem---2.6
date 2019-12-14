Imports System.Threading
Imports System.Globalization
Public Class FrmEditUPO
    Dim Conn, ConnMDB As New ADODB.Connection
    Dim RsConn, RsMdb, rsconnx As New ADODB.Recordset
    Dim sql As String
    Dim idproduk As Integer
    Dim stridproduk, strplu, strnamabarang, strclass, strtag As String
    Dim stroutPO, strminor, strUsys, strUkor, strselisih As Int64
    Dim rpsystem, qtysystem, pajakkoreksi, totalkoreksi, strC2, strmax, strsoh, qtykoreksi As Decimal
    Dim flag As Boolean


    Private Sub FrmEditUPO_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        TxtNoUPO.Focus()
    End Sub
    Private Sub FrmEditUPO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
     
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
        Panel4.BackColor = Color.DeepSkyBlue
     
        Call bersih()
        Call LoadData()
        Call cektable()
        Call GbrTombol()
    End Sub
    Private Sub GbrTombol()
        Me.BtnEdit.Image = System.Drawing.Image.FromFile(icoedit)
        Me.BtnCancel.Image = System.Drawing.Image.FromFile(icocancel)
        Me.BtnSave.Image = System.Drawing.Image.FromFile(icosave)
    End Sub

    Private Sub bersih()

        TxtNoUPO.Clear()
        TxtKodeSupplier.Clear()
        TxtNamaSupplier.Clear()
        TxtTanggal.Clear()
        TxtNamaBarang.Clear()
        TxtUSystem.Clear()
        TxtUKoreksi.Clear()
        txtfind.Clear()

        TxtNamaBarang.ReadOnly = True
        TxtUSystem.ReadOnly = True
        TxtUKoreksi.ReadOnly = True
        TxtKodeSupplier.ReadOnly = True
        TxtNamaSupplier.ReadOnly = True
        TxtTanggal.ReadOnly = True
        txtfind.ReadOnly = True

        TxtKodeSupplier.BackColor = Color.White
        TxtNamaSupplier.BackColor = Color.White
        TxtTanggal.BackColor = Color.White
        TxtNoUPO.BackColor = Color.White
        TxtNamaBarang.BackColor = Color.White
        TxtUSystem.BackColor = Color.White

        BtnEdit.Enabled = False
        BtnSave.Enabled = False
        BtnCancel.Enabled = False
        ListView2.Enabled = True


        Me.TxtTanggal.Text = Format(Now, "dddd, dd-MMM-yyyy ,hh:mm:ss")
        flag = False

    End Sub

    Private Sub LoadData()
        ListView2.Columns.Clear()
        ListView2.Items.Clear()
        ListView2.View = Windows.Forms.View.Details
        ListView2.GridLines = True
        ListView2.FullRowSelect = True

        If TxtKodeSupplier.Text = "" Then
            IdSupplier = 0
        End If

        ListView2.Columns.Add("idproduk", 0)
        ListView2.Columns.Add("SKU", 100)
        ListView2.Columns.Add("Description", 230)
        '  ListView2.Columns.Add("Conv-2", 80, HorizontalAlignment.Right)
        ListView2.Columns.Add("Class", 80)
        ListView2.Columns.Add("Tag", 50)
        ListView2.Columns.Add("MaxS", 80, HorizontalAlignment.Right)
        ListView2.Columns.Add("SOH", 80, HorizontalAlignment.Right)
        ListView2.Columns.Add("Out PO", 80, HorizontalAlignment.Right)
        ListView2.Columns.Add("MinOrder", 80, HorizontalAlignment.Right)
        ListView2.Columns.Add("U. System", 80, HorizontalAlignment.Right)
        ListView2.Columns.Add("U. Koreksi", 80, HorizontalAlignment.Right)
        ListView2.Columns.Add("Selisih", 80, HorizontalAlignment.Right)


        If flag = False Then
            sql = "exec spUpoDcDetail 'GetEdit'," & IdDC & "," & nomorUPO & ",0," & IdSupplier & ",'x',0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,'%" & txtfind.Text & "%'"
        Else
            sql = "exec spUpoDcDetailTmp 'GetEdit'," & IdDC & "," & nomorUPO & ",0," & IdSupplier & ",'x',0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,'%" & txtfind.Text & "%'"
        End If
        RsConn = Conn.Execute(sql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()

            Do While Not RsConn.EOF

                stridproduk = RsConn("idproduk").Value
                strplu = RsConn("kodeproduk").Value
                strnamabarang = RsConn("namapanjang").Value
                strC2 = IsDBNull(RsConn("C2").Value)
                strclass = RsConn("class").Value
                strtag = RsConn("kodetag").Value
                strUsys = RsConn("qtyupo").Value

                If flag = False Then
                    strUkor = strUsys
                Else
                    strUkor = RsConn("qtykoreksi").Value
                End If
                strselisih = strUkor - strUsys
                Dim arr(13) As String
                Dim itm As ListViewItem

                arr(0) = stridproduk
                arr(1) = strplu
                arr(2) = strnamabarang
                arr(3) = strclass
                arr(4) = strtag
                arr(5) = Format(RsConn("maxstok").Value, "#,##0")
                arr(6) = Format(RsConn("stokOH").Value, "#,##0")
                arr(7) = Format(RsConn("outposupplier").Value, "#,##0")
                arr(8) = Format(RsConn("minorder").Value, "#,##0")
                arr(9) = Format(RsConn("qtyupo").Value, "#,##0")
                arr(10) = Format(strUkor, "#,##0")
                arr(11) = Format(strselisih, "#,##0")
                itm = New ListViewItem(arr)
                ListView2.Items.Add(itm)

                RsConn.MoveNext()
            Loop

        End If
        RsConn.Close()
    End Sub

    Private Sub BtCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        TxtNamaBarang.Clear()
        TxtUKoreksi.Clear()
        TxtUSystem.Clear()
        TxtUKoreksi.ReadOnly = True
        BtnSave.Enabled = False
        BtnCancel.Enabled = False
        BtnEdit.Enabled = False
        ListView2.Enabled = True

    End Sub

    Private Sub BtnFindNoUPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFindNoUPO.Click
        TxtNoUPO.Clear()
        TxtKodeSupplier.Clear()
        TxtNamaSupplier.Clear()
        TxtNoUPO.Text = FrmFind.cari("NomorUPO")
        If TxtNoUPO.Text = "0" Then
            TxtNoUPO.Text = ""
            Exit Sub
        End If


    End Sub

    Private Sub TxtNamaBarang_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNamaBarang.TextChanged
        If TxtNamaBarang.Text = "" Then
            Exit Sub
        Else
            BtnEdit.Enabled = True
        End If
    End Sub

    Private Sub TxtKodeSupplier_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtKodeSupplier.TextChanged
        Call getSupplier(TxtKodeSupplier.Text)
        TxtNamaSupplier.Text = NamaSupplier
        Call LoadData()
        txtfind.ReadOnly = False
    End Sub
    Private Sub cekdata()
        sql = "Select * from upodcdetail where nomorupo=" & nomorUPO & " and idsupplier=" & IdSupplier
        RsConfig = Conn.Execute(sql)
        If RsConfig("statusdata").Value = 1 Then
            BtnEdit.Enabled = False
        End If

    End Sub

    Private Sub TxtNoUPO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNoUPO.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(Keys.Back))
    End Sub

    Private Sub BtnFindSupplier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFindSupplier.Click
        If TxtNoUPO.Text = "" Then
            MsgBox("Anda belum memilih Nomor Draft PO !!!", vbOKOnly + vbCritical, "Info")
            Exit Sub
        End If

        TxtKodeSupplier.Text = FrmFind.cari("KoreksiUPO")
        If TxtKodeSupplier.Text = "0" Then TxtKodeSupplier.Text = ""
        Exit Sub
    End Sub

    Private Sub TxtNoUPO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNoUPO.TextChanged
        If TxtNoUPO.Text = "" Then
            nomorUPO = 0
            Exit Sub
        End If
        nomorUPO = TxtNoUPO.Text
    End Sub

    Private Sub ListView2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView2.SelectedIndexChanged
        Dim z As Integer
        z = ListView2.SelectedItems.Count

        If z = 0 Then
            Exit Sub
        Else
            TxtNamaBarang.Text = ListView2.SelectedItems.Item(0).SubItems(2).Text
            idproduk = ListView2.SelectedItems.Item(0).SubItems(0).Text
            TxtUSystem.Text = ListView2.SelectedItems.Item(0).SubItems(10).Text
            TxtUKoreksi.Text = ListView2.SelectedItems.Item(0).SubItems(11).Text
            BtnEdit.Enabled = True
            BtnCancel.Enabled = False
            BtnSave.Enabled = False
            rpsystem = TxtUSystem.Text
            TxtUSystem.Text = Format(rpsystem, "##,##0.##")

            Call cekdata()
        End If
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        flag = True
        ListView2.Enabled = False
        BtnCancel.Enabled = True
        BtnEdit.Enabled = False
        BtnSave.Enabled = True
        TxtUKoreksi.ReadOnly = False
        TxtUKoreksi.Focus()
        Call copydata()

    End Sub
    Private Sub cektable()
        sql = "Select TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='UpoDcDetailTmp'"
        RsConfig = Conn.Execute(sql)
        If RsConfig.EOF Then
            sql = "select top 0 * into UpoDcDetailTmp from UpoDcDetail "
            Conn.Execute(sql)
        End If

    End Sub

    Private Sub copydata()
        sql = "Select * from UpoDcDetailTmp where nomorupo= " & nomorUPO & " and idsupplier=" & IdSupplier
        RsConn = Conn.Execute(sql)

        If RsConn.EOF Then
            sql = "Insert into UpoDcDetailTmp select * from UpoDcDetail where nomorupo=" & nomorUPO & " and idsupplier=" & IdSupplier
            Conn.Execute(sql)
        End If

    End Sub

    Private Sub TxtUKoreksi_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtUKoreksi.KeyDown
        If e.KeyCode = Keys.Enter Then
            sql = "exec spUpoDcDetailtmp 'add'," & IdDC & "," & nomorUPO & "," & idproduk & "," & IdSupplier & ",'x',0,0,0,0,0,0,0,0," & qtykoreksi & ",0,0,0,0,0,0,'x'"
            Conn.Execute(sql)
            Call LoadData()
            TxtNamaBarang.Clear()
            TxtUKoreksi.Clear()
            TxtUSystem.Clear()
            BtnEdit.Enabled = False
            BtnCancel.Enabled = False
            ListView2.Enabled = True
            TxtUKoreksi.ReadOnly = True
        End If
    End Sub

    Private Sub TxtUKoreksi_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUKoreksi.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(Keys.Back))
    End Sub

    Private Sub TxtUKoreksi_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtUKoreksi.TextChanged
        If TxtUKoreksi.Text = "" Then TxtUKoreksi.Text = 0
        qtykoreksi = Replace(TxtUKoreksi.Text, ".", "")
        TxtUKoreksi.Text = Format(qtykoreksi, "##,##0.##")
        TxtUKoreksi.SelectionStart = Len(TxtUKoreksi.Text)
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click

        Dim result2 As DialogResult = MessageBox.Show("Simpan perubahan data ??", _
                 "Question !!", _
                 MessageBoxButtons.YesNo, _
                 MessageBoxIcon.Question)
        If result2 = DialogResult.Yes Then
            Conn.Execute("Delete from UpoDCDetail  where nomorupo=" & nomorUPO & " and idsupplier=" & IdSupplier)
            Conn.Execute("Insert into UpoDcDetail select * from UpoDcDetailTMP where nomorupo=" & nomorUPO & " and idsupplier=" & IdSupplier)
            Conn.Execute("Delete from UpoDCDetailTmp  where nomorupo=" & nomorUPO & " and idsupplier=" & IdSupplier)
            Conn.Execute("exec spUpoDcHeader 'add'," & IdDC & "," & nomorUPO & ",1,'2017-01-01',1,1,1,1,1,1,'" & StrNamaUser & "'")
            Call pesan(3)
            Call bersih()
            Call LoadData()
        Else
            Exit Sub
        End If

    End Sub

    Private Sub txtfind_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfind.KeyPress
        If (e.KeyChar Like "[',]") Then e.Handled() = True
    End Sub
    Private Sub txtfind_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtfind.TextChanged
        Call LoadData()
    End Sub

   
End Class