Imports System.Data.SqlClient
Public Class FrmNotifToko
    Dim Conn, ConnMDB As New ADODB.Connection
    Dim RsConn, RsMdb As New ADODB.Recordset
    Dim sql, usr As String
    Dim idpsn As Integer
    Dim flagE As Boolean
    
    Private Sub FrmNotifToko_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        txtcari.Focus()
    End Sub
    Private Sub FrmNotifToko_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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
        Panel2.BackColor = Color.DeepSkyBlue
        '' Panel3.BackColor = Color.DeepSkyBlue
        Panel4.BackColor = Color.DeepSkyBlue
        Panel5.BackColor = Color.DeepSkyBlue
        Call GbrTombol()
        Call bersih()
        Call kunci()
        Call loaddata()
        BtAdd.Enabled = True
    End Sub
    Private Sub GbrTombol()
        Me.BtAdd.Image = System.Drawing.Image.FromFile(icoadd)
        ''  Me.BtEdit.Image = System.Drawing.Image.FromFile(icoedit)
        Me.BtCancel.Image = System.Drawing.Image.FromFile(icocancel)
        Me.BtSave.Image = System.Drawing.Image.FromFile(icosave)
    End Sub
    Private Sub bersih()

        txtdari.Clear()
        cbuntuk.Text = ""
        txtjudul.Clear()
        txtpesan.Clear()
        Dtaktif.Value = Now

        cbuntuk.Enabled = False
        txtdari.ReadOnly = True
        Dtaktif.Enabled = False
        txtjudul.ReadOnly = True
        txtpesan.ReadOnly = True

        Panel2.Enabled = True
        Panel3.Enabled = True
        txtcari.Focus()
    End Sub
    Private Sub kunci()
        BtAdd.Enabled = False
        '' BtEdit.Enabled = False
        BtSave.Enabled = False
        BtCancel.Enabled = False
    End Sub
    Private Sub loaddata()
       
        DgSO.DataSource = Nothing
        DgSO.Rows.Clear()
        DgSO.Columns.Clear()


        Dim aCol() As Integer = {5, 50, 12, 32}
        Dim icol As Integer

        With DgSO.ColumnHeadersDefaultCellStyle
            .BackColor = Color.DeepPink  'navy
            .ForeColor = Color.Navy
            .Font = New Font("Arial", 9, FontStyle.Bold)
        End With


        With DgSO
            '.EditMode = DataGridViewEditMode.EditOnKeystroke
            .AutoSizeRowsMode = _
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
            .ColumnHeadersBorderStyle = _
                DataGridViewHeaderBorderStyle.Raised
            .CellBorderStyle = _
                DataGridViewCellBorderStyle.Single
            .GridColor = SystemColors.ActiveBorder
            .RowHeadersVisible = False
            .SelectionMode = _
                DataGridViewSelectionMode.CellSelect
            .MultiSelect = False
            .BackgroundColor = Color.Honeydew
            .AllowUserToResizeColumns = False
        End With

        Dim da As SqlClient.SqlDataAdapter
        DgSO.AllowUserToAddRows = False

        sql = "exec spPesanToko 'dgv','" & StrNamaUser & "',0,'Subject','pesan','2019-10-01',1,'x'"

        GetStringKoneksi()
        GetKoneksiSQLClient()
        da = New SqlDataAdapter(sql, SQLConn)
        DS = New DataSet
        da.Fill(DS, (sql))
        Me.DgSO.DataSource = DS.Tables(sql)

        For icol = 0 To 3
            DgSO.Columns(icol).Width = (DgSO.Width / 100) * aCol(icol)
            Select Case icol
                Case 0
                    DgSO.Columns(icol).HeaderText = "NO."
                    DgSO.Columns(icol).ReadOnly = True

                Case 1
                    DgSO.Columns(icol).HeaderText = "Judul dan Pengirim"
                    DgSO.Columns(icol).ReadOnly = True
                Case 2
                    DgSO.Columns(icol).HeaderText = "Tanggal Aktif"
                    DgSO.Columns(icol).ReadOnly = True

                Case 3
                    DgSO.Columns(icol).HeaderText = "Toko Penerima"
                    DgSO.Columns(icol).ReadOnly = True

            End Select

        Next

    End Sub
    Private Sub txtcari_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcari.KeyPress
        If (e.KeyChar Like "[',]") Then e.Handled() = True
    End Sub


    Private Sub txtcari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcari.TextChanged
        Call loaddata()
    End Sub
  


    Private Sub BtCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancel.Click
        Call bersih()
        Call kunci()
        BtAdd.Enabled = True
    End Sub

    Private Sub BtAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAdd.Click
        flagE = False

        Call bersih()
        Call kunci()

        BtSave.Enabled = True
        BtCancel.Enabled = True

        cbuntuk.Enabled = True

        Dtaktif.Enabled = True
        txtjudul.ReadOnly = False
        txtpesan.ReadOnly = False
        cbuntuk.Focus()

        sql = "exec spPesanToko 'div','" & StrNamaUser & "',0,'Subject','pesan','2019-10-01',1,x"
        RsConn = Conn.Execute(sql)
        If Not RsConn.EOF Then
            txtdari.Text = RsConn("namaJabatan").Value & " - " & RsConn("namaUser").Value
        End If
    End Sub

    Private Sub DgSO_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgSO.CellContentClick
      
    End Sub

    Private Sub DgSO_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgSO.CellClick
        Call bersih()

        idpsn = DgSO.Rows(e.RowIndex).Cells(0).Value
        txtjudul.Text = DgSO.Rows(e.RowIndex).Cells(1).Value
        Dtaktif.Text = DgSO.Rows(e.RowIndex).Cells(2).Value
        cbuntuk.Text = DgSO.Rows(e.RowIndex).Cells(3).Value

        sql = "select pesan,iduser from TblPesanTokoTmp where idPesan=" & idpsn & ""
        RsConn = Conn.Execute(sql)
        If Not RsConn.EOF Then
            txtpesan.Text = RsConn("Pesan").Value
            usr = RsConn("idUser").Value
        End If

        sql = "exec spPesanToko 'div','" & usr & "',0,'Subject','pesan','2019-10-01',1,'x'"
        RsConn = Conn.Execute(sql)
        If Not RsConn.EOF Then
            txtdari.Text = RsConn("namaJabatan").Value & " - " & usr
        End If

        txtdari.Enabled = False

        Dim result2 As DialogResult = MessageBox.Show("[YES] Delet [NO] Edit ?", _
         "Warning !!", _
         MessageBoxButtons.YesNo, _
         MessageBoxIcon.Question)
        If result2 = DialogResult.Yes Then
            Dim result3 As DialogResult = MessageBox.Show("Lanjutkan Delet ?", _
         "Warning !!", _
         MessageBoxButtons.YesNo, _
         MessageBoxIcon.Question)
            If result3 = DialogResult.Yes Then
                sql = "exec spPesanToko 'del','" & StrNamaUser & "'," & idpsn & ",'Subject','pesan','2019-10-01',1,'x'"
                RsConn = Conn.Execute(sql)
                MsgBox("Pesan Berhasil di Delet", MsgBoxStyle.Information)
                loaddata()
                bersih()
            Else
                bersih()
                Exit Sub
            End If
        Else
            txtjudul.ReadOnly = False
            txtpesan.ReadOnly = False
            BtAdd.Enabled = False
            BtSave.Enabled = True
            BtCancel.Enabled = True
            flagE = True
            sql = "exec spPesanToko 'div','" & StrNamaUser & "',0,'Subject','pesan','2019-10-01',1,'x'"
            RsConn = Conn.Execute(sql)
            If Not RsConn.EOF Then
                txtdari.Text = RsConn("namaJabatan").Value & " - " & RsConn("namaUser").Value
            End If
        End If
    End Sub

    Private Sub BtSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSave.Click
        If flagE = True Then
            Dim result3 As DialogResult = MessageBox.Show("Re-Post Pesan ?", _
       "Warning !!", _
       MessageBoxButtons.YesNo, _
       MessageBoxIcon.Question)
            If result3 = DialogResult.Yes Then
                sql = "exec spPesanToko 'edit','" & StrNamaUser & "'," & idpsn & ",'" & "Re-Post" & txtjudul.Text & "','" & txtpesan.Text & "','" & Format(Dtaktif.Value, "yyyy-MM-dd") & "',1,'" & cbuntuk.Text & "'"
                RsConn = Conn.Execute(sql)
                MsgBox("Pesan Berhasil di Repost", MsgBoxStyle.Information)
            End If
        Else
            If cbuntuk.Text = "ALL TOKO" Then
                Dim result3 As DialogResult = MessageBox.Show("Posting Pesan ?", _
        "Warning !!", _
        MessageBoxButtons.YesNo, _
        MessageBoxIcon.Question)
                If result3 = DialogResult.Yes Then
                    sql = "exec spPesanToko 'PostAllTko','" & StrNamaUser & "'," & idpsn & ",'" & txtjudul.Text & "','" & txtpesan.Text & "','" & Format(Dtaktif.Value, "yyyy-MM-dd") & "',1,'" & cbuntuk.Text & "'"
                    RsConn = Conn.Execute(sql)
                    MsgBox("Pesan Berhasil di Posting", MsgBoxStyle.Information)
                End If
            Else
                Dim result3 As DialogResult = MessageBox.Show("Posting Pesan ?", _
       "Warning !!", _
       MessageBoxButtons.YesNo, _
       MessageBoxIcon.Question)
                If result3 = DialogResult.Yes Then
                    sql = "exec spPesanToko 'PostByTko','" & StrNamaUser & "'," & idpsn & ",'" & txtjudul.Text & "','" & txtpesan.Text & "','" & Format(Dtaktif.Value, "yyyy-MM-dd") & "',1,'" & cbuntuk.Text & "'"
                    RsConn = Conn.Execute(sql)
                    MsgBox("Pesan Berhasil di Posting", MsgBoxStyle.Information)
                End If
            End If
        End If
        bersih()
        loaddata()
    End Sub

  
    Private Sub btFindtoko_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFindtoko.Click
        cbuntuk.Text = FrmFind.cari("MasterToko")
        If cbuntuk.Text = "" Then Exit Sub
        kodetoko = cbuntuk.Text
        gettoko(kodetoko)
    End Sub
End Class