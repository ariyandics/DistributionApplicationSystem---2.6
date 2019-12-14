
Public Class FrmMasterUser
    Dim Conn, ConnMDB As New ADODB.Connection
    Dim RsConn, RsMdb As New ADODB.Recordset
    Dim strfind, sql, strnama, strnama2, strstatus, strpass As String
    Dim idx As Int64


    Private Sub FrmMasterUser_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        txtfind.Focus()
    End Sub
    Private Sub FrmMasterUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        Call kunci()
        Call bersih()
        txtfind.Focus()
        BtnAdd.Enabled = True
        Call listcmb()
        Call LoadData()

        ' tambahan hak akses
        Call hakases()


    End Sub


    Private Sub hakases()
       
        TreeView1.Nodes.Clear()
        For Each Cntrl As ToolStripMenuItem In FrmMenuUtama.MenuStrip1.Items
            Dim atas As TreeNode = TreeView1.Nodes.Add(Cntrl.Text)

            For Each Menu1 In Cntrl.DropDownItems.OfType(Of ToolStripMenuItem)()
                Dim tengah As TreeNode = atas.Nodes.Add(Menu1.Text)

                For Each Menu2 In Menu1.DropDownItems.OfType(Of ToolStripMenuItem)()
                    Dim bawah As TreeNode = tengah.Nodes.Add(Menu2.Text)

                    For Each Menu3 In Menu2.DropDownItems.OfType(Of ToolStripMenuItem)()
                        Dim bawahsekali As TreeNode = bawah.Nodes.Add(Menu3.Text)
                    Next
                Next
            Next


        Next

        TreeView1.ExpandAll()
        TreeView1.CheckBoxes = True
    End Sub

    Private Sub TreeView1_AfterCheck(ByVal sender As Object, ByVal e As TreeViewEventArgs) Handles TreeView1.AfterCheck
        RemoveHandler TreeView1.AfterCheck, AddressOf TreeView1_AfterCheck

        Call CheckAllChildNodes(e.Node)

        If e.Node.Checked Then
            If e.Node.Parent Is Nothing = False Then
                Dim allChecked As Boolean = True
                Call IsEveryChildChecked(e.Node.Parent, allChecked)
                If allChecked Then
                    e.Node.Parent.Checked = True
                    Call ShouldParentsBeChecked(e.Node.Parent)
                End If
            End If
        Else
            Dim parentNode As TreeNode = e.Node.Parent
            While parentNode Is Nothing = False
                parentNode.Checked = False
                parentNode = parentNode.Parent
            End While
        End If

        AddHandler TreeView1.AfterCheck, AddressOf TreeView1_AfterCheck
    End Sub

    Private Sub CheckAllChildNodes(ByVal parentNode As TreeNode)
        For Each childNode As TreeNode In parentNode.Nodes
            childNode.Checked = parentNode.Checked
            CheckAllChildNodes(childNode)
        Next
    End Sub

    Private Sub IsEveryChildChecked(ByVal parentNode As TreeNode, ByRef checkValue As Boolean)
        For Each node As TreeNode In parentNode.Nodes
            Call IsEveryChildChecked(node, checkValue)
            If Not node.Checked Then
                checkValue = False
            End If
        Next
    End Sub

    Private Sub ShouldParentsBeChecked(ByVal startNode As TreeNode)
        If startNode.Parent Is Nothing = False Then
            Dim allChecked As Boolean = True
            Call IsEveryChildChecked(startNode.Parent, allChecked)
            If allChecked Then
                startNode.Parent.Checked = True
                Call ShouldParentsBeChecked(startNode.Parent)
            End If
        End If
    End Sub



    Private Sub kunci()
        BtnAdd.Enabled = False
        BtEdit.Enabled = False
        BtSave.Enabled = False
        BtCancel.Enabled = False
        BtnFind.Enabled = False
        TreeView1.Enabled = False
        ListView2.Enabled = True
    End Sub

    Private Sub bersih()
        TxtNama.Clear()
        txtpassword.Clear()
        TxtUser.Clear()
        txtfind.Clear()
        cmbstatus.Enabled = False
        TxtNama.ReadOnly = True
        TxtUser.ReadOnly = True
        txtpassword.ReadOnly = True
    End Sub

    Private Sub listcmb()
        cmbstatus.Text = ""
        cmbstatus.Items.Clear()
        cmbstatus.Items.Add("Aktif")
        cmbstatus.Items.Add("Tidak Aktif")

        cmbdiv.Items.Clear()
        sql = "Select * from mstusergroup"
        RsConfig = Conn.Execute(sql)
        If Not RsConfig.EOF Then
            RsConfig.MoveFirst()
            Do While Not RsConfig.EOF
                cmbdiv.Items.Add(RsConfig("namagroupuser").Value)
                RsConfig.MoveNext()
            Loop
        End If
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click

        Call kunci()
        Call bersih()
        BtnFind.Enabled = True
        BtnFind.Focus()
        Panel2.Enabled = False
        Panel3.Enabled = False
        BtCancel.Enabled = True
        BtSave.Enabled = True
        TreeView1.Enabled = True
    End Sub

    Private Sub ceklist()

        sql = "exec spMstUserAkses 'Get','" & TxtUser.Text & "','x',0"
        RsConn = Conn.Execute(sql)
        If Not RsConn.EOF Then
            RsConn.MoveFirst()
            Do While Not RsConn.EOF

                For Each lvl1 As TreeNode In TreeView1.Nodes
                    If RsConn("submenu").Value = RsConn("NamaMenu").Value Then
                        If lvl1.Text = RsConn("submenu").Value Then
                            lvl1.Checked = True
                        End If
                    End If

                    For Each lvl2 As TreeNode In lvl1.Nodes
                        If lvl1.Text = RsConn("NamaMenu").Value Then
                            If lvl2.Text = RsConn("submenu").Value Then
                                lvl2.Checked = True
                            End If
                        End If


                        For Each lvl3 As TreeNode In lvl2.Nodes
                            If lvl2.Text = RsConn("NamaMenu").Value Then
                                If lvl3.Text = RsConn("submenu").Value Then
                                    lvl3.Checked = True
                                End If
                            End If

                            For Each lvl4 As TreeNode In lvl3.Nodes
                                If lvl3.Text = RsConn("NamaMenu").Value Then
                                    If lvl4.Text = RsConn("submenu").Value Then
                                        lvl4.Checked = True
                                    End If
                                End If
                            Next
                        Next

                    Next

                Next



                RsConn.MoveNext()
            Loop
        End If

     
    End Sub

    Private Sub simpanhakakses()
        sql = "exec spMstUserAkses 'Delete','" & TxtUser.Text & "','x',0"
        Conn.Execute(sql)

        For Each lvl1 As TreeNode In TreeView1.Nodes
            If lvl1.Checked Then
                sql = "exec spMstUserAkses 'Add','" & TxtUser.Text & "','" & lvl1.Text & "','" & lvl1.Text & "'"
            End If

            For Each lvl2 As TreeNode In lvl1.Nodes
                If lvl2.Checked Then
                    sql = "exec spMstUserAkses 'Add','" & TxtUser.Text & "','" & lvl1.Text & "','" & lvl2.Text & "'"
                    Conn.Execute(sql)
                End If

                For Each lvl3 As TreeNode In lvl2.Nodes
                    If lvl3.Checked Then
                        sql = "exec spMstUserAkses 'Add','" & TxtUser.Text & "','" & lvl2.Text & "','" & lvl3.Text & "'"
                        Conn.Execute(sql)
                    End If

                    For Each lvl4 As TreeNode In lvl3.Nodes
                        If lvl4.Checked Then
                            sql = "exec spMstUserAkses 'Add','" & TxtUser.Text & "','" & lvl3.Text & "','" & lvl4.Text & "'"
                            Conn.Execute(sql)
                        End If
                    Next

                Next

            Next
        Next


    End Sub

    Private Sub BtCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancel.Click
        Call kunci()
        Call bersih()
        Panel2.Enabled = True
        Panel3.Enabled = True
        BtnAdd.Enabled = True
        cmbstatus.Text = ""
        TreeView1.Nodes.Clear()
        Call hakases()

    End Sub

    Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
        TxtNama.Text = FrmFind.cari("Masteruser")
        If TxtNama.Text = "0" Then
            TxtNama.Text = ""
            Exit Sub
        End If
        TxtUser.ReadOnly = False
        txtpassword.ReadOnly = False
        cmbstatus.Enabled = True
        TxtUser.Focus()
    End Sub

    Private Sub TxtUser_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtUser.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtpassword.Focus()
            e.Handled = True
        End If

    End Sub

    Private Sub txtpassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtpassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtpassword.Focus()
            e.Handled = True
        End If

    End Sub
    Private Sub LoadData()
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

        ListView2.Columns.Add("Nama Karyawan", 190)
        ListView2.Columns.Add("User Id", 100)
        ListView2.Columns.Add("Status", 80)
        ListView2.Columns.Add("passuser", 0)
        ListView2.Columns.Add("Divisi", 0)


        sql = "exec spMstUser1022 'getnama','x','x','%" & strfind & "%',1,'2017-01-01','2017-01-01',1,1"
        RsConn = Conn.Execute(sql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()

            Do While Not RsConn.EOF

                strnama = RsConn("Namauser").Value
                strnama2 = RsConn("iduser").Value
                strstatus = RsConn("statususer").Value
                strpass = RsConn("passuser").Value

                If strstatus = "1" Then
                    strstatus = "Aktif"
                ElseIf strstatus = "2" Then
                    strstatus = "Online"
                Else
                    strstatus = "Tidak Aktif"
                End If

                Dim arr(5) As String
                Dim itm As ListViewItem

                arr(0) = strnama
                arr(1) = strnama2
                arr(2) = strstatus
                arr(3) = strpass
                arr(4) = RsConn("namaGroupUser").Value

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
        Call LoadData()
    End Sub

    Private Sub ListView2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView2.SelectedIndexChanged
        Dim z As Integer
        z = ListView2.SelectedItems.Count

        If z = 0 Then
            Exit Sub
        Else
            TxtNama.Text = ListView2.SelectedItems.Item(0).SubItems(0).Text
            TxtUser.Text = ListView2.SelectedItems.Item(0).SubItems(1).Text
            txtpassword.Text = ListView2.SelectedItems.Item(0).SubItems(3).Text
            txtpassword.Text = Decrypt(txtpassword.Text)
            cmbstatus.Text = ListView2.SelectedItems.Item(0).SubItems(2).Text
            cmbdiv.Text = ListView2.SelectedItems.Item(0).SubItems(4).Text

            BtEdit.Enabled = True
            TreeView1.Nodes.Clear()
            Call hakases()
            Call ceklist()

        End If
    End Sub

    Private Sub BtSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSave.Click
        If TxtNama.Text = "" Or TxtUser.Text = "" Or txtpassword.Text = "" Or cmbstatus.Text = "" Then
            MsgBox("Data Belum lengkap!!!!", vbOKOnly + vbCritical, "Info")
            Exit Sub
        End If


        If BtnFind.Enabled = True Then

            sql = "exec spMstUser1022  'GetUser','x','x','" & TxtNama.Text & "',1,'2017-01-01','2017-01-01',1,1"
            RsConn = Conn.Execute(sql)
            If RsConn.EOF Then

                sql = "exec spMstUser1022  'GetIdUs','" & TxtUser.Text & "','x','" & TxtNama.Text & "',1,'2017-01-01','2017-01-01',1,1"
                RsConn = Conn.Execute(sql)
                If Not RsConn.EOF Then
                    MsgBox("User id sudah ada yang menggunakan , Silahkan ganti user Id dengan yang lain !!", vbOKOnly + vbCritical, "Info")
                    Exit Sub
                End If

                Call simpan()
            Else
                MsgBox("Nama " & TxtNama.Text & " sudah terdaftar dengan user ID : " & RsConn("iduser").Value, vbOKOnly + vbCritical, "Info")
                Exit Sub
            End If

        Else
            Call simpan()
        End If

    End Sub

    Private Sub simpan()
        Dim result2 As DialogResult = MessageBox.Show("Simpan data ?", _
          "Question ?", _
          MessageBoxButtons.YesNo, _
          MessageBoxIcon.Question)
        If result2 = DialogResult.Yes Then

            Dim x As String
            x = Encrypt(txtpassword.Text)
            If cmbstatus.Text = "Aktif" Then
                strstatus = "1"
            Else
                strstatus = "0"
            End If

            sql = "exec spMstUser1022 'Add','" & TxtUser.Text & "','" & x & "','" & TxtNama.Text & "'," & idx & ",'" & Format(Now, "yyyy-MM-dd") & "','" & Format(Now, "yyyy-MM-dd") & "'," & Convert.ToInt16(strstatus) & ",1"
            Conn.Execute(sql)
            Call simpanhakakses()

            Call pesan(3)
            Call bersih()
            Call kunci()
            Call LoadData()
            BtnAdd.Enabled = True
            Panel2.Enabled = True
            Panel3.Enabled = True


        Else
            Exit Sub
        End If

    End Sub

    Private Sub BtEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtEdit.Click
        Call kunci()
        BtCancel.Enabled = True
        BtSave.Enabled = True
        txtpassword.ReadOnly = False
        cmbstatus.Enabled = True
        TreeView1.Enabled = True
        ListView2.Enabled = False
    End Sub


    Private Sub cmbdiv_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdiv.TextChanged
        sql = "exec spMstUserGroup 'GetId',0,'" & cmbdiv.Text & "','2017-01-01','2017-01-01',1"
        RsConn = Conn.Execute(sql)
        If Not RsConn.EOF Then
            idx = RsConn("idGroupUser").Value
        End If

    End Sub

    Private Sub TxtNama_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNama.KeyPress
        If (e.KeyChar Like "[',]") Then e.Handled() = True
    End Sub

    

    Private Sub TxtUser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUser.KeyPress
        If (e.KeyChar Like "[',]") Then e.Handled() = True
    End Sub

    Private Sub txtpassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpassword.KeyPress
        If (e.KeyChar Like "[',]") Then e.Handled() = True
    End Sub

    Private Sub txtpassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpassword.TextChanged

    End Sub
End Class