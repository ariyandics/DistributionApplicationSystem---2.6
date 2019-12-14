Public Class FrmMasterShelving
    Dim Conn, ConnMDB As New ADODB.Connection
    Dim RsConn, RsMdb As New ADODB.Recordset
    Dim sql As String
    Dim flag, flagx As Boolean
    Dim idrak, idshelving, tipetoko As Integer

    Private Sub FrmMasterShelving_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        txtfind.Focus()
    End Sub
    Private Sub FrmMasterShelving_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call bersih()

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
        Call loaddata()
    End Sub
    Private Sub GbrTombol()
        Me.BtnEdit.Image = System.Drawing.Image.FromFile(icoedit)
        Me.BtnCancel.Image = System.Drawing.Image.FromFile(icocancel)
        Me.BtnSave.Image = System.Drawing.Image.FromFile(icosave)
    End Sub

    Private Sub bersih()
        flag = False
        flagx = False
        txtfind.Clear()
        txtTglUpd.Text = ""
        txtTglUpd.ReadOnly = True
        cmbrak.Text = ""
        txtShelving.Clear()
        txtlubang.Clear()

        BtnEdit.Enabled = True
        BtnSave.Enabled = False
        BtnCancel.Enabled = False
        Panel2.Enabled = True
        Panel3.Enabled = True
        Panel1.Enabled = False
        txtfind.Focus()
    End Sub

    Private Sub loaddata()
        Dim strsql, strnama, strfind, strshelving As String
        Dim lubang As Integer
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

        ListView2.Columns.Add("Rak", 80)
        ListView2.Columns.Add("Shelving", 80)
        ListView2.Columns.Add("No Lubang", 80)
        ListView2.Columns.Add("Tgl Update", 80)


        strsql = "exec spMstShelvingdc 'get',1,0,'%" & strfind & "%',0,'" & StrNamaUser & "'"
        RsConn = Conn.Execute(strsql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()

            Do While Not RsConn.EOF
                strnama = RsConn("NamaRak").Value
                strshelving = RsConn("namashelving").Value
                lubang = RsConn("nolubang").Value
                strTgl = RsConn("tglupdate").Value


                Dim arr(4) As String
                Dim itm As ListViewItem

                arr(0) = strnama
                arr(1) = strshelving
                arr(2) = lubang
                arr(3) = strTgl

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


    Private Sub ListView2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView2.SelectedIndexChanged
        Dim z As Integer
        z = ListView2.SelectedItems.Count

        If z = 0 Then
            Exit Sub
        Else
            flagx = True

            cmbrak.Text = ListView2.SelectedItems.Item(0).SubItems(0).Text
            txtlubang.Text = ListView2.SelectedItems.Item(0).SubItems(2).Text
            txtShelving.Text = ListView2.SelectedItems.Item(0).SubItems(1).Text
            txtTglUpd.Text = ListView2.SelectedItems.Item(0).SubItems(3).Text

            BtnEdit.Enabled = True
            ' BtDelete.Enabled = True
            BtnCancel.Enabled = False
            flag = False


        End If
    End Sub

    Private Sub BtEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        flag = False
        ' BtAdd.Enabled = False
        'BtDelete.Enabled = False
        BtnCancel.Enabled = True
        BtnSave.Enabled = True
        BtnEdit.Enabled = False

        Panel2.Enabled = False
        Panel3.Enabled = False
        Panel1.Enabled = True
        Call listcmb()

    End Sub
    Private Sub listcmb()
        cmbrak.Items.Clear()

        strsql = "exec spMstRakDC'get','0','%','" & StrNamaUser & "'"
        RsConn = Conn.Execute(strsql)
        If Not RsConn.EOF Then
            RsConn.MoveFirst()
            Do While Not RsConn.EOF()
                cmbrak.Items.Add(RsConn("namarak").Value)
                RsConn.MoveNext()

            Loop
        End If


    End Sub

    Private Sub BtCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Call bersih()
    End Sub

    Private Sub txtShelving_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtShelving.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtlubang.Focus()
            e.SuppressKeyPress = True
        End If
    End Sub



    Private Sub txtlubang_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtlubang.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnSave.Focus()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub cmbrak_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbrak.KeyPress
        If (e.KeyChar Like "[',]") Then e.Handled() = True
    End Sub


    Private Sub cmbrak_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbrak.TextChanged
        If cmbrak.Text = "" Then Exit Sub
        strsql = "exec spMstRakdc 'get','1','" & cmbrak.Text & "','" & StrNamaUser & "'"
        RsConfig = Conn.Execute(strsql)
        If Not RsConfig.EOF Then
            idrak = RsConfig("idrak").Value
        End If
    End Sub

    Private Sub txtlubang_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtlubang.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(Keys.Back))
    End Sub



    Private Sub txtShelving_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtShelving.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(Keys.Back))
    End Sub

    Private Sub txtShelving_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShelving.TextChanged
        If txtShelving.Text = "" Then Exit Sub
        txtShelving.Text = UCase(txtShelving.Text)
        txtShelving.SelectionStart = Len(txtShelving.Text)

        If flagx = True Then
            sql = "exec spMstShelvingdc 'get'," & idrak & ",1,'" & txtShelving.Text & "'," & txtlubang.Text & ",'" & StrNamaUser & "'"
            RsConfig = Conn.Execute(sql)
            If Not RsConfig.EOF Then
                idshelving = RsConfig("idshelving").Value
            End If
        End If
    End Sub

    Private Sub BtSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If cmbrak.Text = "" Or txtShelving.Text = "" Or txtlubang.Text = "" Then
            Call pesan(0)
            Exit Sub
        End If

        Dim index As Integer
        index = cmbrak.FindString(cmbrak.Text)
        If index > -1 Then
            cmbrak.SelectedIndex = index
        Else
            Call pesan(99)
            cmbrak.Text = ""
            Beep()
            cmbrak.Focus()
            Exit Sub
        End If

        If flag = False Then
            'sql = "exec spMstShelvingToko 'get','" & Microsoft.VisualBasic.Left(cmbtipetoko.Text, 1) & "'," & idrak & ",1,'" & txtShelving.Text & "'," & txtlubang.Text & ",'" & StrNamaUser & "'"
            'RsConn = Conn.Execute(sql)
            'If Not RsConn.EOF Then
            '    Dim x As Integer = RsConn("statusdata").Value
            '    Call pesan(x)
            '    Call bersih()
            '    Exit Sub
            'Else
            sql = "exec spMstShelvingdc 'edit'," & idrak & "," & idshelving & ",'" & txtShelving.Text & "'," & txtlubang.Text & ",'" & StrNamaUser & "'"
            'End If

        End If

        RsConn = Conn.Execute(sql)
        pesan(3)
        Call bersih()
        Call loaddata()
    End Sub

   
    Private Sub cmbrak_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbrak.SelectedIndexChanged

    End Sub

    Private Sub txtlubang_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtlubang.TextChanged

    End Sub
End Class