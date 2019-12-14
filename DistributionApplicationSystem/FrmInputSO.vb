Imports System.Data.SqlClient
Public Class FrmInputSO
    Dim Conn, ConnMDB As New ADODB.Connection
    Dim RsConn, RsMdb As New ADODB.Recordset
    Dim counter, nomor As Integer
    Dim flagadd, flagedit, baru, lama As Boolean
    Dim qtyso As Integer
    Dim sql As String

    Private Sub FrmInputSO_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        BtnFindNo.Focus()
    End Sub

    Private Sub FrmInputSO_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Call ClearTempDB()
    End Sub
    Private Sub FrmInputSO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
       
        Call GbrTombol()
        Call bersih()
        Call kunci()
        BtnFindNo.Enabled = True

    End Sub

    Private Sub GbrTombol()
        Me.BtnEdit.Image = System.Drawing.Image.FromFile(icoedit)
        Me.BtnCancel.Image = System.Drawing.Image.FromFile(icocancel)
        Me.BtnSave.Image = System.Drawing.Image.FromFile(icosave)
    End Sub

    Private Sub kunci()
        BtnSave.Enabled = False
        BtnEdit.Enabled = False
        BtnFindNo.Enabled = False
        BtnCancel.Enabled = False
        DgSO.ReadOnly = True
    End Sub

    Private Sub bersih()
        flagadd = False
        flagedit = False
        TxtNoLock.Clear()
        TxtTglAdj.Clear()
        TxtUser.Clear()
        TxtNamaBarang.Clear()
        TxtNoLock.ReadOnly = True
        TxtTglAdj.ReadOnly = True
        TxtUser.ReadOnly = True
    End Sub

   
    Private Sub LoadDataKeGrid()
        Dim strfind As String
        If TxtNamaBarang.Text = "" Then
            strfind = "%"
        Else
            strfind = "%" & TxtNamaBarang.Text & "%"
        End If

        Dim aCol() As Integer = {8, 10, 55, 10, 10, 6}
        Dim icol As Integer
        Dim sqlstring As String

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

        ' If FlagAdd = True Or FlagEdit = True Then
        'DgSO.AllowUserToAddRows = True
        '  Else
        DgSO.AllowUserToAddRows = False
        '  End If

        If flagadd = True Then
            sqlstring = "spsoFreezeDetailTmp 'getnama','" & strfind & "'," & IdDC & "," & Val(TxtNoLock.Text) & ",0,0,'" & StrUserid & "',0"
        Else
            sqlstring = "spsoFreezeDetail 'getnama'," & IdDC & "," & Val(TxtNoLock.Text) & ",0,0"
        End If

        GetStringKoneksi()
        GetKoneksiSQLClient()
        da = New SqlDataAdapter(sqlstring, SQLConn)
        DS = New DataSet
        da.Fill(DS, (sqlstring))
        Me.DgSO.DataSource = DS.Tables(sqlstring)


        ' format kolom datagrid pcn
        For icol = 0 To 5
            DgSO.Columns(icol).Width = (DgSO.Width / 100) * aCol(icol)
            Select Case icol
                Case 0
                    DgSO.Columns(icol).HeaderText = "No.Urut"
                    DgSO.Columns(icol).ReadOnly = True
                    DgSO.Columns(icol).DefaultCellStyle.Format = "##,0"
                Case 1
                    DgSO.Columns(icol).HeaderText = "SKU"
                    DgSO.Columns(icol).ReadOnly = True

                Case 2
                    DgSO.Columns(icol).HeaderText = "Nama Produk"
                    DgSO.Columns(icol).ReadOnly = True
                Case 3
                    DgSO.Columns(icol).HeaderText = "Lokasi"
                    DgSO.Columns(icol).ReadOnly = True

                Case 4
                    DgSO.Columns(icol).HeaderText = "Qty SO"
                    DgSO.Columns(icol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DgSO.Columns(icol).DefaultCellStyle.Format = "##,0"
                    DgSO.Columns(icol).ReadOnly = False
              
                Case 5
                    DgSO.Columns(icol).HeaderText = "idproduk"
                    DgSO.Columns(icol).ReadOnly = True
                    DgSO.Columns(icol).Visible = False

            End Select

        Next

        For counter = 0 To (DgSO.Rows.Count - 1)

            nomor = counter + 1
            DgSO.Rows(counter).Cells(0).Value() = nomor

        Next

    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Call ClearTempDB()
        Call bersih()
        Call kunci()
        BtnFindNo.Enabled = True
        Call LoadDataKeGrid()
    End Sub

    Private Sub ClearTempDB()
        Dim sqlCleanTemp As String

        If Conn.State = 0 Then
            GetStringKoneksi()
            Conn.Open(StrKoneksi)
        End If

        sqlCleanTemp = "spsoFreezeDetailTmp 'Delete','nama'," & IdDC & "," & Val(TxtNoLock.Text) & ",0,0,'" & StrUserid & "',0"
        Conn.Execute(sqlCleanTemp)

    End Sub

    Private Sub BtnFindNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFindNo.Click
        Call ClearTempDB()
        TxtNoLock.Text = FrmFind.cari("NoLockSO")
        If TxtNoLock.Text = "0" Then Exit Sub

        sql = "spsoFreezeDetailTmp 'get','nama'," & IdDC & "," & TxtNoLock.Text & ",0,0,'" & StrUserid & "',0"
        RsConn = Conn.Execute(sql)
        If Not RsConn.EOF Then
            TxtTglAdj.Text = Format(RsConn("tglSofreeze").Value, "dd-MM-yyyy")
        End If

        Call LoadDataKeGrid()
        BtnEdit.Enabled = True
       

    End Sub


    Private Sub cektable()
        sql = "Select TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='soFreezeDetailTmp'"
        RsConfig = Conn.Execute(sql)
        If RsConfig.EOF Then
            sql = "select top 0 * into soFreezeDetailTmp from soFreezeDetail "
            Conn.Execute(sql)

            sql = "alter table soFreezeDetailtmp add PcEntry varchar(25),statusdata int"
            Conn.Execute(sql)
        End If

    End Sub

    Private Sub TxtNamaBarang_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNamaBarang.KeyPress
        If (e.KeyChar Like "[',]") Then e.Handled() = True
    End Sub
   
    Private Sub TxtNamaBarang_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNamaBarang.TextChanged
        Call LoadDataKeGrid()
    End Sub
    Private Sub DgSO_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DgSO.EditingControlShowing
        AddHandler CType(e.Control, TextBox).KeyPress, AddressOf TextBox_keyPress
    End Sub
    Private Sub TextBox_keyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If DgSO.CurrentCell.ColumnIndex > 3 Then
            If Char.IsDigit(CChar(CStr(e.KeyChar))) = False Then e.Handled = True
            If Not (Char.IsDigit(CChar(CStr(e.KeyChar))) Or e.KeyChar = ".") Then e.Handled = True
            If e.KeyChar = " "c Then e.Handled = False

        End If
    End Sub


    Private Sub DgSO_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgSO.CellEndEdit
        Dim x As Integer = DgSO.CurrentCellAddress.X
        Dim y As Integer = DgSO.CurrentCellAddress.Y


        If flagadd = True And e.ColumnIndex = 4 Then
            idProduk = DgSO.Rows(y).Cells(5).Value

            If Not IsDBNull(DgSO.Rows(y).Cells(4).Value) Then
                qtyso = Replace(DgSO.Rows(y).Cells(4).Value, ".", "")
            ElseIf Val(DgSO.Rows(y).Cells(4).Value) < 1 Or DgSO.Rows(y).Cells(4).Value = "" Then
                qtyso = 0
            Else
                qtyso = 0
            End If

            sql = "spsoFreezeDetailTmp 'Edit','nama'," & IdDC & "," & TxtNoLock.Text & "," & idProduk & "," & qtyso & ",'" & StrUserid & "',0"
            RsConfig = Conn.Execute(sql)

        End If




    End Sub

   
    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        Call cektable()
        Call kunci()
        ' Call namakomputer()
        TxtUser.Text = StrUserid
        flagadd = True
        TxtNamaBarang.ReadOnly = False
        BtnCancel.Enabled = True
        BtnSave.Enabled = True

        Call cekdata()
        DgSO.ReadOnly = False
        Call LoadDataKeGrid()


    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If Conn.State = 0 Then
            Call GetStringKoneksi()
            Conn.Open(StrKoneksi)
        End If
        Dim result2 As DialogResult = MessageBox.Show("Apakah data akan di simpan ?", _
             "Warning !!", _
             MessageBoxButtons.YesNo, _
             MessageBoxIcon.Question)
        If result2 = DialogResult.Yes Then
            sql = "spsoFreezeDetailTmp 'save','nama'," & IdDC & "," & TxtNoLock.Text & "," & idProduk & "," & qtyso & ",'" & StrUserid & "',1"
            RsConfig = Conn.Execute(sql)
            Call pesan(3)
            Call bersih()
            Call kunci()
            BtnFindNo.Enabled = True
            BtnFindNo.Focus()
            flagadd = False
            Call LoadDataKeGrid()
        End If
    End Sub

    Private Sub cekdata()
        sql = "spsoFreezeDetailTmp 'GetData','nama'," & IdDC & "," & TxtNoLock.Text & "," & idProduk & "," & qtyso & ",'" & StrUserid & "',0"
        RsConfig = Conn.Execute(sql)

        If RsConfig.EOF Then
            sql = "spsoFreezeDetailTmp 'add','nama'," & IdDC & "," & TxtNoLock.Text & ",0,0,'" & StrUserid & "',0"
            Conn.Execute(sql)
        End If

    End Sub

  
End Class