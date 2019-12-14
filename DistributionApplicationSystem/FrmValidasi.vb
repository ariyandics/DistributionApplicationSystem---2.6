Public Class FrmValidasi
    Dim Conn, ConnMDB As New ADODB.Connection
    Dim RsConn, RsMdb, rsconnx As New ADODB.Recordset
    Dim StrReturnValue, StrFrmPemanggil As String
    Dim passvalidasi As String
    Dim sql, TermOP As String
    Private Sub txtpassValidasi_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtpassValidasi.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call pass()
            If Trim(passvalidasi) = txtpassValidasi.Text Then
                StrReturnValue = 1
            Else
                StrReturnValue = 0
            End If
            Me.Close()
        End If
    End Sub

    Public Function cari(ByVal FrmPemanggil As String) As String
        StrReturnValue = 0
        Me.TopMost = True
        StrFrmPemanggil = FrmPemanggil
        Me.ShowDialog()
        cari = StrReturnValue
    End Function

    Private Sub FrmValidasi_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        txtpassValidasi.Focus()
    End Sub


    Private Sub FrmValidasi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackColor = Color.SkyBlue
        Me.BackgroundImage = System.Drawing.Image.FromFile(bg)

        txtpassValidasi.Clear()
        Call pass()
    End Sub

    Private Sub pass()
        If Conn.State = 0 Then
            GetStringKoneksi()
            Conn.Open(StrKoneksi)

        End If
        sql = "exec spfind 'password','" & StrNamaUser & "','x'"
        RsConn = Conn.Execute(sql)
        If Not RsConn.EOF Then
            passvalidasi = (Decrypt(RsConn("passuser").Value))
        Else
            passvalidasi = (Val(Format(Now, "dd")) * Hour(Now)) + Val(Format(Now, "MM"))
        End If

    End Sub

    Private Sub txtpassValidasi_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpassValidasi.TextChanged

    End Sub
End Class