Public Class FrmRegisterCode
    Dim Conn, ConnMDB As New ADODB.Connection
    Dim RsConn, RsMdb As New ADODB.Recordset
    Dim sql As String

    Private Sub FrmRegisterCode_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        txtfind.Focus()
    End Sub
    Private Sub FrmRegisterCode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Panel3.BackColor = Color.DeepSkyBlue
        Panel2.BackColor = Color.DeepSkyBlue
        Call loaddata()
    End Sub
    Private Sub loaddata()
        Dim strsql, strfind As String

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

        ListView2.Columns.Add("Kode Toko", 100)
        ListView2.Columns.Add("Nama Toko", 300)
        ListView2.Columns.Add("Tanggal GO", 80)
        ListView2.Columns.Add("Kode Registrasi", 120)

        strsql = "select * from MstToko where tglBuka >= convert(date,GETDATE()) and namatoko like '%" & strfind & "%'"
        RsConn = Conn.Execute(strsql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()

            Do While Not RsConn.EOF

                Dim arr(4) As String
                Dim itm As ListViewItem

                arr(0) = RsConn("kodetoko").Value
                arr(1) = RsConn("namatoko").Value
                arr(2) = RsConn("tglBuka").Value
                arr(3) = RsConn("singkatantoko").Value & "-" & RsConn("kodetoko").Value

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
End Class