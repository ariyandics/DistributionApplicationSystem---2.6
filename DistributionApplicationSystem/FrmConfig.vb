Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class FrmConfig
    Dim Conn, ConnMDB As New ADODB.Connection
    Dim RsConn, RsMdb As New ADODB.Recordset
    Dim strkonek As String
    Dim sql As String
    Dim pathMdb, getConnStringMdb As String

    Private Sub FrmConfig_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

    End Sub

    Private Sub FrmConfig_ContextMenuStripChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ContextMenuStripChanged
        End
    End Sub

    Private Sub FrmConfig_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Parent = PictureBox1
        Label1.BackColor = Color.Transparent
        Me.Text = Label1.Text
        Me.Label1.Left = (Me.Width - Me.Label1.Width) / 2
        Me.Label1.Top = (Me.PictureBox1.Height - Me.Label1.Height) / 2
        Label1.Font = New Font("Adobe Gothic Std B", 18, FontStyle.Bold)
        Me.Text = NamaPT
      
        BtnSave.Enabled = False
        txtDSN.Focus()

    End Sub

    Private Sub tes()

        StrSA = TxtUID.Text
        StrPwd = txtPass.Text
        StrDSN = txtDSN.Text
        StrDB = txtDB.Text

        StrKonek = "Provider=SQLOLEDB.1;Password=" & StrPwd & ";Persist Security Info=True;User ID=" & StrSA & ";Initial Catalog=" & StrDB & ";Data Source=" & StrDSN
        Try
            Conn.Open(strkonek)
            MsgBox("Koneksi berhasil..!!", vbOKOnly + vbInformation, "Sukses")
            txtDB.ReadOnly = True
            txtPass.ReadOnly = True
            TxtUID.ReadOnly = True
            txtDSN.ReadOnly = True
            BtnSave.Enabled = True
        Catch ex As MyCustomException
            MsgBox("Koneksi ke database gagal!! connection Error: " & ex.ToString())
            Exit Sub
        Finally
            Conn.Close()
        End Try

    End Sub

    Private Sub BtnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTest.Click

        If txtDB.Text = "" Or txtDSN.Text = "" Or txtPass.Text = "" Or TxtUID.Text = "" Then
            MsgBox("Data yang anda masukan belum lengkap ,Silahkan lengkapi data!!!", vbOKOnly + vbCritical, "Info")
            Exit Sub
        End If

        BtnTest.Enabled = False
        BtnSave.Enabled = False
        Call tes()

    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        pathMdb = New System.IO.FileInfo(Application.ExecutablePath).DirectoryName
        getConnStringMdb = "Driver={Microsoft Access Driver (*.mdb)};Dbq=" & pathMdb & "\posCfg.mdb;Uid=Admin;Pwd=mypos234"
        'Conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathMdb & "\posCfg.mdb;Jet OLEDB:Database Password=mypos234;"
        ConnMDB.Open(getConnStringMdb)

        If ConnMDB.State = 1 Then
            ConnMDB.Execute("delete from config")
            ConnMDB.Execute("insert into config (UID,PID,DSN,DB,LOC) values('" & TxtUID.Text & "','" & txtPass.Text & "','" & txtDSN.Text & "','" & txtDB.Text & "',1)")
            MsgBox("Server Berhasil di konfigurasi!!!", vbOKOnly + vbInformation, "Info")
            Me.Close()
            FrmLogin.Show()
        Else
            MsgBox("Server Gagal di konfigurasi!!!", vbOKOnly + vbInformation, "Info")
            Exit Sub
        End If

    End Sub

    Private Sub txtDSN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDSN.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtDB.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub txtDSN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDSN.KeyPress
        If (e.KeyChar Like "[',]") Then e.Handled() = True
    End Sub

    Private Sub txtDB_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDB.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtUID.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub txtDB_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDB.KeyPress
        If (e.KeyChar Like "[',]") Then e.Handled() = True
    End Sub

    Private Sub TxtUID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtUID.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPass.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub TxtUID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUID.KeyPress
        If (e.KeyChar Like "[',]") Then e.Handled() = True
    End Sub

    Private Sub txtPass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPass.KeyPress
        If (e.KeyChar Like "[',]") Then e.Handled() = True
    End Sub

    Private Sub txtDSN_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDSN.TextChanged

    End Sub

    Private Sub txtDB_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDB.TextChanged

    End Sub

    Private Sub TxtUID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtUID.TextChanged

    End Sub
End Class