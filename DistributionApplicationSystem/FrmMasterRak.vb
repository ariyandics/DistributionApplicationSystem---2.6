Public Class FrmMasterRak
    Dim Conn, ConnMDB As New ADODB.Connection
    Dim RsConn, RsMdb As New ADODB.Recordset
    Dim sql As String
    Dim flag As Boolean
    Dim idx As Integer

    Private Sub FrmMasterRak_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        txtfind.Focus()
    End Sub
    Private Sub FrmMasterRak_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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
        Panel2.BackColor = Color.DeepSkyBlue
        Panel3.BackColor = Color.DeepSkyBlue

        Call GbrTombol()
        Call bersih()
        Call kunci()
        Call loaddata()
        BtnAdd.Enabled = True
    End Sub

    Private Sub GbrTombol()
        Me.BtnAdd.Image = System.Drawing.Image.FromFile(icoadd)
        Me.BtnEdit.Image = System.Drawing.Image.FromFile(icoedit)
        Me.BtnCancel.Image = System.Drawing.Image.FromFile(icocancel)
        Me.BtnSave.Image = System.Drawing.Image.FromFile(icosave)
    End Sub

    Private Sub bersih()
        flag = False
        TxtNama.Clear()
        txtfind.Clear()
        TxtUser.Clear()
        DTtgl.Value = Now

        TxtNama.ReadOnly = True
        DTtgl.Enabled = False
        TxtUser.ReadOnly = True

        Panel2.Enabled = True
        Panel3.Enabled = True
        txtfind.Focus()

    End Sub

    Private Sub kunci()
        BtnAdd.Enabled = False
        BtnEdit.Enabled = False
        BtnSave.Enabled = False
        BtnCancel.Enabled = False
    End Sub

    Private Sub loaddata()
        Dim strsql, strnama, strfind As String
        Dim strTgl As Date
        ListView2.Columns.Clear()
        ListView2.Items.Clear()
        ListView2.View = Windows.Forms.View.Details
        ListView2.GridLines = True
        ListView2.FullRowSelect = True
        If txtfind.Text = "" Then
            strfind = "%"
        Else
            strfind = txtfind.Text
        End If

        ListView2.Columns.Add("Nama", 200)
        ListView2.Columns.Add("Tgl Update", 100)


        strsql = "exec spMstRakdc 'get','0','%" & strfind & "%','" & StrNamaUser & "'"
        RsConn = Conn.Execute(strsql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()

            Do While Not RsConn.EOF
                strnama = RsConn("NamaRak").Value
                strTgl = RsConn("TglUpdate").Value

                Dim arr(2) As String
                Dim itm As ListViewItem

                arr(0) = strnama
                arr(1) = strTgl.Date


                itm = New ListViewItem(arr)
                ListView2.Items.Add(itm)

                RsConn.MoveNext()

            Loop

        End If
        RsConn.Close()


    End Sub

    Private Sub txtfind_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfind.KeyPress
        If (e.KeyChar Like "[',]") Then e.Handled() = True
    End Sub


    Private Sub txtfind_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtfind.TextChanged
        Call loaddata()
    End Sub

    Private Sub TxtNama_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNama.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnSave.Focus()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub ListView2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView2.SelectedIndexChanged
        Dim z As Integer
        z = ListView2.SelectedItems.Count

        If z = 0 Then
            Exit Sub
        Else
            TxtNama.Text = ListView2.SelectedItems.Item(0).SubItems(0).Text
            BtnEdit.Enabled = True
            ' BtDelete.Enabled = True
            BtnCancel.Enabled = False
            flag = False

        End If
    End Sub

    Private Sub BtEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        flag = False
        Call kunci()
        BtnCancel.Enabled = True
        BtnSave.Enabled = True
        TxtNama.ReadOnly = False
        TxtNama.Focus()
        Panel2.Enabled = False
        Panel3.Enabled = False
        TxtUser.Text = StrNamaUser
    End Sub

    Private Sub BtSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If TxtNama.Text = "" Then
            Call pesan(0)
            Exit Sub
        End If


        sql = "exec spMstRakdc 'get','1','" & TxtNama.Text & "','" & StrNamaUser & "'"
        RsConn = Conn.Execute(sql)
        If Not RsConn.EOF Then
            Dim x As Integer = RsConn("statusdata").Value
            Call pesan(x)
            TxtNama.SelectAll()
            TxtNama.Focus()
            Exit Sub
        End If

        If flag = True Then
            sql = "exec spMstRakdc 'add'," & idx & ",'" & TxtNama.Text & "','" & StrNamaUser & "'"
        Else
            sql = "exec spMstRakdc 'edit'," & idx & ",'" & TxtNama.Text & "','" & StrNamaUser & "'"

        End If

        RsConn = Conn.Execute(sql)
        pesan(3)
        Call bersih()
        Call kunci()
        Call loaddata()
        BtnAdd.Enabled = True
    End Sub

    Private Sub TxtNama_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNama.KeyPress
        e.Handled = Not (Char.IsLetterOrDigit(e.KeyChar) Or e.KeyChar = Chr(Keys.Back))
    End Sub

    Private Sub TxtNama_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNama.TextChanged
        If TxtNama.Text = "" Then Exit Sub
        TxtNama.Text = UCase(TxtNama.Text)
        TxtNama.SelectionStart = Len(TxtNama.Text)


        sql = "exec spMstRakdc 'get',1,'" & TxtNama.Text & "','" & StrNamaUser & "'"
        RsConfig = Conn.Execute(sql)
        If Not RsConfig.EOF Then
            idx = RsConfig("idrak").Value
            TxtUser.Text = RsConfig("iduser").Value
            DTtgl.Value = RsConfig("tglupdate").Value
        End If

    End Sub

    Private Sub BtCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Call bersih()
        Call kunci()
        BtnAdd.Enabled = True
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Call bersih()
        Call kunci()
        BtnSave.Enabled = True
        BtnCancel.Enabled = True
        Panel2.Enabled = False
        Panel3.Enabled = False
        TxtNama.ReadOnly = False
        TxtNama.Focus()
        flag = True
    End Sub
End Class