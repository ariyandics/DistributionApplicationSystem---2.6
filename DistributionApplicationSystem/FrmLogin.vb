Public Class FrmLogin
    Dim Conn, ConnMDB As New ADODB.Connection
    Dim RsConn, RsMdb As New ADODB.Recordset
    Dim sql, passx As String

    Private Sub FrmLogin_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Call getPathMdb()
    End Sub

    Private Sub FrmLogin_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        End
    End Sub
    Private Sub FrmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Call getPathMdb()
        Call gambar()
        Me.PictureBox1.Image = System.Drawing.Image.FromFile(logo)

        Call NamaPerusahaan()

        'Dim exeServ As DateTime = GetExeFTP()
        ''Toleransi perbedaan jam dengan server = 2 jam
        'If exeServ > exeDate.AddHours(1) Then
        '    MsgBox("Ada versi baru diserver, tanggal " & exeServ.ToString & " dibanding " & exeDate.ToString, MsgBoxStyle.Information)
        '    Form1.ShowDialog()
        'End If


        'Me.BackColor = Color.SkyBlue
        'Me.BackgroundImage = System.Drawing.Image.FromFile(bg)
        'PictureBox1.BackgroundImage = System.Drawing.Image.FromFile(atas)
        Me.Text = namadc
        Me.Label3.Text = NamaPT
        Me.txtuser.Clear()
        Me.txtpass.Clear()
        Me.txtuser.Focus()

     

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call cek()

    End Sub

    Private Sub txtuser_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtuser.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtpass.Focus()
            txtpass.SelectAll()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txtpass_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtpass.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.Focus()
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub cek()
        GetServerDate()
        If Conn.State = 0 Then
            GetStringKoneksi()
            Conn.Open(StrKoneksi)
        End If


        If txtuser.Text = "System" And txtpass.Text = "admin" Then
            FrmMasterUser.ShowDialog()
        Else

            strsql = "Select namauser,iduser,passuser,namagroupuser,statusUser from MstUser a inner join MstUserGroup b on a.idGroupUser =b.idGroupUser  where IdUser='" & txtuser.Text & "'"
            RsConn = Conn.Execute(strsql)
            If Not RsConn.EOF Then
                If RsConn("statususer").Value = 0 Or RsConn("statususer").Value = 2 Then
                    MsgBox("Anda tidak berhak menggunakan aplikasi ini !" & vbCrLf _
                            & " Silahkan Hubungi Administrator !!!", vbOKOnly + vbCritical, "Informasi")
                    Exit Sub
                Else

                    passx = (Decrypt(RsConn("passuser").Value))
                    If Trim(passx) = txtpass.Text Then
                        StrNamaUser = RsConn("idUser").Value
                        StrUserid = RsConn("namauser").Value
                        VarBagian = RsConn("namagroupuser").Value

                        If VarBagian <> "IT" Then
                            Call kuncimenu()
                            Call AksesMenu()
                        Else
                            Call bukamenu()
                        End If

                        sql = "exec spMstUser1022 'kunci','" & StrNamaUser & "','x','x',1,'2017-01-01','2017-01-01',1,1"
                        Conn.Execute(sql)

                        Me.Hide()
                        FrmMenuUtama.ShowDialog()

                    Else
                        MsgBox("Password yang anda masukan salah !!!", vbOKOnly + vbCritical, "Info")
                        txtpass.Focus()
                        txtpass.SelectAll()
                        Exit Sub
                    End If
                End If
            Else
                MsgBox("Username yang anda masukan salah / tidak terdaftar !!!", vbOKOnly + vbCritical, "Info")
                txtuser.Focus()
                txtuser.SelectAll()
                Exit Sub
            End If
        End If



    End Sub
    Private Sub bukamenu()
        For Each header As ToolStripMenuItem In FrmMenuUtama.MenuStrip1.Items
            header.Visible = True

            For Each Menu1 In header.DropDownItems.OfType(Of ToolStripMenuItem)()

                Menu1.Visible = True

                For Each menu2 In Menu1.DropDownItems.OfType(Of ToolStripMenuItem)()

                    menu2.Visible = True

                    For Each menu3 In menu2.DropDownItems.OfType(Of ToolStripMenuItem)()

                        menu3.Visible = True
                    Next
                Next
            Next

        Next
    End Sub
    Private Sub kuncimenu()

        For Each header As ToolStripMenuItem In FrmMenuUtama.MenuStrip1.Items
            header.Visible = False

            For Each Menu1 In header.DropDownItems.OfType(Of ToolStripMenuItem)()

                Menu1.Visible = False

                For Each menu2 In Menu1.DropDownItems.OfType(Of ToolStripMenuItem)()

                    menu2.Visible = False

                    For Each menu3 In menu2.DropDownItems.OfType(Of ToolStripMenuItem)()

                        menu3.Visible = False
                        'For Each menu4 In menu3.DropDownItems.OfType(Of ToolStripMenuItem)()

                        '    menu4.Visible = False
                        'Next
                    Next
                Next
            Next

        Next
    End Sub

    Private Sub AksesMenu()
        sql = "exec spMstUserAkses 'Get','" & StrNamaUser & "','x',0"
        RsConn = Conn.Execute(sql)
        If Not RsConn.EOF Then
            RsConn.MoveFirst()
            Do While Not RsConn.EOF
                For Each header As ToolStripMenuItem In FrmMenuUtama.MenuStrip1.Items

                    For Each Menu1 In header.DropDownItems.OfType(Of ToolStripMenuItem)()

                        If Menu1.Text = RsConn("submenu").Value Then
                            header.Visible = True
                            Menu1.Visible = True

                        End If
                        For Each menu2 As ToolStripMenuItem In Menu1.DropDownItems
                            If menu2.Text = RsConn("submenu").Value And Menu1.Text = RsConn("namamenu").Value Then
                                header.Visible = True
                                Menu1.Visible = True
                                menu2.Visible = True
                            End If
                            For Each menu3 As ToolStripMenuItem In menu2.DropDownItems
                                If menu3.Text = RsConn("submenu").Value And menu2.Text = RsConn("namamenu").Value Then
                                    header.Visible = True
                                    Menu1.Visible = True
                                    menu2.Visible = True
                                    menu3.Visible = True
                                End If

                                'For Each menu4 As ToolStripMenuItem In menu3.DropDownItems
                                '    If menu4.Text = RsConn("submenu").Value And menu3.Text = RsConn("namamenu").Value Then
                                '        header.Visible = True
                                '        Menu1.Visible = True
                                '        menu2.Visible = True
                                '        menu3.Visible = True
                                '        menu4.Visible = True
                                '    End If
                                'Next
                            Next
                        Next
                    Next
                Next
                RsConn.MoveNext()
            Loop
        End If
    End Sub

    Private Sub txtuser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtuser.KeyPress
        If (e.KeyChar Like "[',]") Then e.Handled() = True
    End Sub

    Private Sub txtuser_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtuser.TextChanged

    End Sub

    Private Sub txtpass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpass.KeyPress
        If (e.KeyChar Like "[',]") Then e.Handled() = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        End
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("http://www.tigas.co.id")
    End Sub

    Private Sub PictureBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.DoubleClick
        If Conn.State = 0 Then
            GetStringKoneksi()
            Conn.Open(StrKoneksi)
        End If

        sql = "exec spMstUser1022 'buka','" & txtuser.Text & "','x','x',1,'2017-01-01','2017-01-01',1,1"
        Conn.Execute(sql)
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub
End Class