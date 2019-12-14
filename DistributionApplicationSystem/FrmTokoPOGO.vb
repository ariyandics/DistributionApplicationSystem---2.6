Public Class FrmTokoPOGO
    Dim sql As String
    Dim conn As New ADODB.Connection
    Dim RsConn As New ADODB.Recordset
    Dim flagedit As Boolean
    Dim noUrut As Integer

    Private Sub FrmPOGO_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        BtnAdd.Focus()
    End Sub
    Private Sub FrmPOGO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        cektable()
        Call bersih()
        Call loaddata()
        Call cek()


    End Sub
    Private Sub cek()
        If noUrut > 0 Then
            BtnAdd.Enabled = False
            BtnEdit.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
        TxtKodeToko.Text = FrmFind.cari("MasterToko")
        If TxtKodeToko.Text = "" Then Exit Sub
        gettoko(TxtKodeToko.Text)
        TxtNamaToko.Text = namatoko
    End Sub

    Private Sub bersih()
        txtJmlToko.Clear()
        txtkodetoko.Clear()
        TxtNamaToko.Clear()

        BtnEdit.Enabled = False
        BtnCancel.Enabled = False
        BtnDelete.Enabled = False
        BtnSave.Enabled = False
        BtnAdd.Enabled = True
        BtnFind.Enabled = False

        BtnAdd.Text = "&New"
    End Sub

    Private Sub loaddata()
        Dim strsql, strkode, strnama, struser As String

        Dim strTgl As Date
        ListView2.Columns.Clear()
        ListView2.Items.Clear()
        ListView2.View = Windows.Forms.View.Details
        ListView2.GridLines = True
        ListView2.FullRowSelect = True

        ListView2.Columns.Add("No.", 60)
        ListView2.Columns.Add("Kode Toko", 80)
        ListView2.Columns.Add("Nama Toko", 250)
        ListView2.Columns.Add("Tgl Update", 80)
        ListView2.Columns.Add("User Id", 80)

        strsql = "exec spTokoPOGOtmp 'get',0,'" & StrNamaUser & "'"
        RsConn = Conn.Execute(strsql)
        noUrut = 0
        If Not RsConn.EOF Then
            RsConn.MoveFirst()
            Do While Not RsConn.EOF
                noUrut += 1
                strkode = RsConn("kodetoko").Value
                strnama = RsConn("Namatoko").Value
                strTgl = RsConn("TglUpdate").Value
                struser = RsConn("iduser").Value

                Dim arr(5) As String
                Dim itm As ListViewItem

                arr(0) = noUrut
                arr(1) = strkode
                arr(2) = strnama
                arr(3) = strTgl.Date
                arr(4) = struser


                itm = New ListViewItem(arr)
                ListView2.Items.Add(itm)

                RsConn.MoveNext()

            Loop

        End If
        RsConn.Close()

        txtJmlToko.Text = noUrut

    End Sub

    Private Sub cektable()
        sql = "Select TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='TokoPOGOtmp'"
        RsConfig = Conn.Execute(sql)
        If RsConfig.EOF Then
            sql = "select top 0 kodetoko,namatoko,tglCreate ,tglupdate,iduser  into  TokoPOGOtmp from MstToko"
            Conn.Execute(sql)
        End If


        sql = "Select TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='UpoDcHeaderTokoGOTMP'"
        RsConfig = conn.Execute(sql)
        If RsConfig.EOF Then
            sql = "select top 0 *   into  UpoDcHeaderTokoGOTMP from UpoDcHeaderTokoGO"
            conn.Execute(sql)
        End If

    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        If BtnAdd.Text = "&New" Then
            Call cektable()
            BtnAdd.Text = "&Add"
            BtnFind.Enabled = True
            BtnFind.Focus()
            BtnCancel.Enabled = True
        Else
            sql = "exec spTokoPOGOtmp 'add'," & txtkodetoko.Text & ",'" & StrNamaUser & "'"
            conn.Execute(sql)
            Call loaddata()
            txtkodetoko.Clear()
            TxtNamaToko.Clear()
            txtJmlToko.Text = noUrut
            BtnCancel.Enabled = True
            BtnSave.Enabled = True
        End If
        BtnAdd.Enabled = False
    End Sub

    Private Sub txtJmlToko_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtJmlToko.TextChanged

        txtJmlToko.Text = Format(noUrut, "#,##0")

    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        sql = "exec spTokoPOGOtmp 'Cancel',0,'" & StrNamaUser & "'"
        conn.Execute(sql)
        Call bersih()
        Call loaddata()


    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        BtnFind.Enabled = True
        BtnFind.Focus()
        BtnEdit.Enabled = False
        BtnSave.Enabled = True
        BtnCancel.Enabled = True
        BtnAdd.Text = "&Add"
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If MessageBox.Show("Daftar Toko GO akan di simpan?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            sql = "exec spTokoPOGOtmp 'get',0,'" & StrNamaUser & "'"
            RsConn = conn.Execute(sql)
            If Not RsConn.EOF Then
                RsConn.MoveFirst()
                Do While Not RsConn.EOF
                    sql = "exec spUpoDcHeaderTokoGOTMP 'Add'," & IdDC & ",0," & RsConn("kodetoko").Value & ",3"
                    conn.Execute(sql)
                    RsConn.MoveNext()
                Loop
            End If

            sql = "exec spTokoPOGOtmp 'Cancel',0,'" & StrNamaUser & "'"
            conn.Execute(sql)
            Call loaddata()
            Call bersih()
        End If
    End Sub

    Private Sub ListView2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView2.SelectedIndexChanged
        Dim z As Integer
        z = ListView2.SelectedItems.Count

        If z = 0 Then
            Exit Sub
        Else
            'Me.txtkodetoko.Text = ListView2.SelectedItems.Item(0).SubItems(1).Text
            'Me.TxtNamaToko.Text = ListView2.SelectedItems.Item(0).SubItems(2).Text
            BtnDelete.Enabled = True
        End If

    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        If MessageBox.Show("Toko " & ListView2.SelectedItems.Item(0).SubItems(2).Text & " Akan di hapus?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            sql = "exec spTokoPOGOtmp 'delete'," & ListView2.SelectedItems.Item(0).SubItems(1).Text & ",'" & StrNamaUser & "'"
            conn.Execute(sql)
            Call loaddata()
        End If
        BtnDelete.Enabled = False
    End Sub

    Private Sub txtkodetoko_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtkodetoko.TextChanged
        If txtkodetoko.Text <> "" Then
            BtnAdd.Enabled = True
        End If
    End Sub
End Class