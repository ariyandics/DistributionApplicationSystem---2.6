Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Data.OleDb
Imports System.Globalization
Public Class FrmNonRRAK
    Dim sql, kodecoa, namacoa, ket As String
    Dim conn As New ADODB.Connection
    Dim RsConn As New ADODB.Recordset
    Dim flagadd As Boolean
    Dim flagadshow, flagadload, flagadgrid, FlagPesanUser As Boolean
    Dim rpbaru As Int64
    Dim rpbarutoko As Int64
    Dim status, nonr, nmtko, iduser As String
    Dim rpnilaiwads, rpselisih As Double
    Dim kdtk As Integer


    Private Sub FrmNonRRAK_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        Call loaddataawal()
        If conn.State = 0 Then
            Call GetStringKoneksi()
            conn.Open(StrKoneksi)
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
        btnFindToko.Enabled = True
        BtnNoRRAK.Enabled = True
        flagadd = False
    End Sub
    Private Sub GbrTombol()
        Me.BtnApproval.Image = System.Drawing.Image.FromFile(icoapprove)
        Me.BtnEdit.Image = System.Drawing.Image.FromFile(icoedit)
        Me.BtnCancel.Image = System.Drawing.Image.FromFile(icocancel)
        Me.BtnSave.Image = System.Drawing.Image.FromFile(icosave)
        Me.BtnPrint.Image = System.Drawing.Image.FromFile(icoprint)

    End Sub
    Private Sub bersih()
        txtnamatoko.Clear()
        TxtKodetoko.Clear()
        txtNoRRAK.Clear()
        txttotaltoko.Clear()
        txttotaltoko.ReadOnly = True
        txtnamatoko.ReadOnly = True
        TxtKodetoko.ReadOnly = True

        txtNoRRAK.ReadOnly = True

    End Sub
    Private Sub kunci()
        BtnApproval.Enabled = False
        BtnCancel.Enabled = False
        BtnEdit.Enabled = False
        btnFindToko.Enabled = False
        BtnNoRRAK.Enabled = False
        BtnSave.Enabled = False
        BtnTampil.Enabled = False
    End Sub

    Private Sub BtnNoRRAK_Click(sender As Object, e As EventArgs) Handles BtnNoRRAK.Click
        If TxtKodetoko.Text = "" Or TxtKodetoko.Text = "0" Then
            MsgBox("Anda belum memilih Toko !!", vbOKOnly + vbInformation, "Info")
            btnFindToko.Focus()
            Exit Sub
        End If
        kodetoko = TxtKodetoko.Text
        txtNoRRAK.Text = FrmFind.cari("NoNonRRAK")
        If txtNoRRAK.Text = "" Then Exit Sub
        BtnTampil.Enabled = True
        flagadload = True
    End Sub

    Private Sub btnFindToko_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFindToko.Click
        BtnPrint.Enabled = False

        DgSO.DataSource = Nothing
        DgSO.Rows.Clear()
        DgSO.Columns.Clear()
        txttotaltoko.Clear()
        txtNoRRAK.Clear()
        TxtKodetoko.Clear()
        txtnamatoko.Clear()
        TxtKodetoko.Text = FrmFind.cari("MasterToko")
        If TxtKodetoko.Text = "" Then Exit Sub
        kodetoko = TxtKodetoko.Text
        gettoko(kodetoko)
        txtnamatoko.Text = namatoko
        BtnNoRRAK.Enabled = True
        flagadload = True
    End Sub

    Private Sub cekperiodeaktif()
        sql = "exec spTblNonRRAK 'BulanAktif',0," & TxtKodetoko.Text & ",0,'x','x','" & txtNoRRAK.Text & "'"
        RsConn = conn.Execute(sql)

        Dim TanggalBuat As Integer = Microsoft.VisualBasic.DateAndTime.Day((RsConn("TglCreate").Value))
        Dim BulanBuat As Integer = Microsoft.VisualBasic.DateAndTime.Month((RsConn("TglCreate").Value))
        Dim TanggalIni As Integer = Microsoft.VisualBasic.DateAndTime.Day(tglserver)
        Dim BulanIni As Integer = Microsoft.VisualBasic.DateAndTime.Month(tglserver)




        If BulanBuat <> BulanIni Or BulanBuat = BulanIni Then
            If TanggalIni = 1 Or TanggalIni = 2 Or TanggalIni = 3 Then
                BtnEdit.Enabled = False
                BtnApproval.Enabled = False
                MsgBox("Periode Approve/Edit Hanya Bisa dilakukan Setelah Tanggal 1,2 dan 3", vbOKOnly + vbInformation, "Info")
                Exit Sub
            End If
        End If

    End Sub
    Private Sub BtnTampil_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnTampil.Click
        flagadload = True
        BtnEdit.Enabled = False
        BtnApproval.Enabled = False

        If TxtKodetoko.Text = "" Or txtNoRRAK.Text = "" Then
            Exit Sub
        ElseIf TxtKodetoko.Text = 0 Or txtNoRRAK.Text = "0" Then
            Exit Sub
        End If

        If TxtKodetoko.Text <> "" And txtNoRRAK.Text <> "" Then
            Call cekstatus()
            Call loaddata()
            Call hitung()
            Call hitungselisih()
            Call hitungwads()
            Label4.Visible = True
            Label6.Visible = True
            txttotalselisih.Visible = True
            txttotalwads.Visible = True
            flagadgrid = True
            '' cekperiodeaktif()
        End If

    End Sub

    Private Sub hitung()
        Dim totalrp As Double
        totalrp = 0
        For t As Integer = 0 To DgSO.Rows.Count - 1
            totalrp = totalrp + Val(DgSO.Rows(t).Cells(3).Value)
        Next
        txttotaltoko.Text = Format(totalrp, "#,##0")
    End Sub
    Private Sub hitungwads()
        Dim totalrp As Double
        totalrp = 0
        For t As Integer = 0 To DgSO.Rows.Count - 1
            totalrp = totalrp + Val(DgSO.Rows(t).Cells(4).Value)
        Next
        txttotalwads.Text = Format(totalrp, "#,##0")
    End Sub
    Private Sub hitungselisih()
        Dim totalrp As Double
        totalrp = 0
        For t As Integer = 0 To DgSO.Rows.Count - 1
            totalrp = totalrp + Val(DgSO.Rows(t).Cells(5).Value)
        Next
        txttotalselisih.Text = Format(totalrp, "#,##0")
    End Sub

    Private Sub cekstatus()
        sql = "exec spTblNonRRAK 'Getstatus',0," & TxtKodetoko.Text & ",0,'x','x','" & txtNoRRAK.Text & "'"
        RsConn = conn.Execute(sql)
        If Not RsConn.EOF Then
            If Not IsDBNull(RsConn("StatusRealisasi").Value) Then
                If RsConn("StatusRealisasi").Value = 2 Then
                    BtnEdit.Enabled = True
                    BtnApproval.Enabled = True
                Else
                    BtnEdit.Enabled = False
                    BtnApproval.Enabled = False
                End If
            End If
        End If
    End Sub

    Private Sub cekstatusprint()
        sql = "exec spTblNonRRAK 'Getstatus',0," & TxtKodetoko.Text & ",0,'x','x','" & txtNoRRAK.Text & "'"
        RsConn = conn.Execute(sql)
        If Not RsConn.EOF Then
            If Not IsDBNull(RsConn("StatusRealisasi").Value) Then
                If RsConn("StatusRealisasi").Value = 2 Then
                    status = "DRAFT"
                Else
                    status = "APPROVED"
                End If
            End If
        End If
    End Sub
    'Private Sub cekstatusbutenprint()
    '    sql = "exec spTblNonRRAK 'Getstatus',0," & TxtKodetoko.Text & ",0,'x','x','" & txtNoRRAK.Text & "'"
    '    RsConn = conn.Execute(sql)
    '    If Not RsConn.EOF Then
    '        If IsDBNull(RsConn("StatusData").Value) Then

    '        Else

    '        End If
    '    End If
    'End Sub

    Private Sub loaddata()
        DgSO.DataSource = Nothing
        DgSO.Rows.Clear()
        DgSO.Columns.Clear()


        Dim aCol() As Integer = {10, 30, 30, 15, 15, 15}
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
        DgSO.AllowUserToAddRows = False

        If flagadload = False Then
            flagadgrid = False

            TxtKodetoko.Text = kdtk
            txtNoRRAK.Text = nonr
            txtnamatoko.Text = nmtko
            sqlstring = "exec spTblNonRRAK 'GetRealisasi',0," & TxtKodetoko.Text & ",0,'x','x','" & txtNoRRAK.Text & "'"

            GetStringKoneksi()
            GetKoneksiSQLClient()
            da = New SqlDataAdapter(sqlstring, SQLConn)
            DS = New DataSet
            da.Fill(DS, (sqlstring))
            Me.DgSO.DataSource = DS.Tables(sqlstring)
            BtnPrint.Enabled = True
        Else
            flagadgrid = True

            sqlstring = "exec spTblNonRRAK 'GetRealisasi',0," & TxtKodetoko.Text & ",0,'x','x','" & txtNoRRAK.Text & "'"

            GetStringKoneksi()
            GetKoneksiSQLClient()
            da = New SqlDataAdapter(sqlstring, SQLConn)
            DS = New DataSet
            da.Fill(DS, (sqlstring))
            Me.DgSO.DataSource = DS.Tables(sqlstring)
            BtnPrint.Enabled = True

        End If

        For icol = 0 To 5
            DgSO.Columns(icol).Width = (DgSO.Width / 100) * aCol(icol)
            Select Case icol
                Case 0
                    DgSO.Columns(icol).HeaderText = "Kode COA"
                    DgSO.Columns(icol).ReadOnly = True

                Case 1
                    DgSO.Columns(icol).HeaderText = "Nama COA"
                    DgSO.Columns(icol).ReadOnly = True

                Case 2
                    DgSO.Columns(icol).HeaderText = "Keterangan"
                    DgSO.Columns(icol).ReadOnly = True

                Case 3
                    DgSO.Columns(icol).HeaderText = "Nilai Realisasi Toko"
                    DgSO.Columns(icol).ReadOnly = True
                    DgSO.Columns(icol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DgSO.Columns(icol).DefaultCellStyle.Format = "##,0"
                Case 4
                    DgSO.Columns(icol).HeaderText = "Nilai Realisasi Finance"
                    DgSO.Columns(icol).ReadOnly = True
                    DgSO.Columns(icol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DgSO.Columns(icol).DefaultCellStyle.Format = "##,0"
                Case 5
                    DgSO.Columns(icol).HeaderText = "Nilai Selisih Realisasi"
                    DgSO.Columns(icol).ReadOnly = True
                    DgSO.Columns(icol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DgSO.Columns(icol).DefaultCellStyle.Format = "##,0"

            End Select

        Next

        Call hitung()
        Call hitungwads()
        Call hitungselisih()
    End Sub

    Private Sub BtnApproval_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnApproval.Click
        flagadload = True
        Dim result2 As DialogResult = MessageBox.Show("Approve data Non RRAK ??", _
              "Question !!", _
              MessageBoxButtons.YesNo, _
              MessageBoxIcon.Question)
        If result2 = DialogResult.Yes Then
            For Each row As DataGridViewRow In Me.DgSO.Rows
                kodecoa = row.Cells.Item(0).Value
                '' namacoa = row.Cells.Item(1).Value

                sql = "exec spTblNonRRAK 'Approve',0," & TxtKodetoko.Text & ",0,'" & kodecoa & "','" & txtNoRRAK.Text & "','" & StrNamaUser & "'"
                conn.Execute(sql)
            Next

            MsgBox("Data RRAK berhasil di Approve", vbOKOnly + vbInformation, "info")
            Call kunci()
            btnFindToko.Enabled = True
            BtnNoRRAK.Enabled = True
            Call loaddata()
            Call hitung()
            Call hitungselisih()
            Call hitungwads()
            Label4.Visible = True
            Label6.Visible = True
            txttotalselisih.Visible = True
            txttotalwads.Visible = True
            BtnPrint.Enabled = True
            flagadgrid = True
        End If

    End Sub

    Private Sub BtnEdit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnEdit.Click
        flagadload = True
        Call loaddata()
        Call hitung()
        Call hitungselisih()
        Call hitungwads()
        Call kunci()
        Label4.Visible = True
        Label6.Visible = True
        txttotalwads.Visible = True
        txttotalselisih.Visible = True

        BtnCancel.Enabled = True
        BtnSave.Enabled = True

        DgSO.ReadOnly = False
        DgSO.Select()
        Me.DgSO.CurrentCell = Me.DgSO(4, Me.DgSO.CurrentCell.RowIndex)
        DgSO.Columns(4).ReadOnly = False
        ''  DgSO.Columns(3).Selected = True
        flagadgrid = True
    End Sub

    Private Sub DgSO_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgSO.CellEndEdit
        Dim x As Integer = DgSO.CurrentCellAddress.X
        Dim y As Integer = DgSO.CurrentCellAddress.Y

        kodecoa = DgSO.Rows(y).Cells.Item(0).Value
        namacoa = DgSO.Rows(y).Cells.Item(1).Value
        ket = DgSO.Rows(y).Cells.Item(2).Value
        rpbarutoko = DgSO.Rows(y).Cells.Item(3).Value
        rpbaru = DgSO.Rows(y).Cells.Item(4).Value


        If rpbaru > rpbarutoko Then
            MsgBox("Perubahan Nilai Tidak Boleh lebih besar dari nilai Real Toko", vbOKOnly + vbCritical, "Info")
            DgSO.Rows(y).Cells(4).Value = 0
            DgSO.Rows(y).Cells(5).Value = rpbarutoko - 0
            DgSO.Rows(y).Cells(4).Selected = True
            Call hitungwads()
            Call hitungselisih()
            SendKeys.Send("{up}")
           
            Exit Sub
        End If

        If Val(DgSO.Rows(y).Cells(4).Value) < 1 Then
            Dim result2 As DialogResult = MessageBox.Show("Apakah tidak ada Perubahan untuk nilai ini ?", _
          "Warning !!", _
          MessageBoxButtons.YesNo, _
          MessageBoxIcon.Question)
            If result2 = DialogResult.Yes Then
                kodecoa = DgSO.Rows(y).Cells.Item(0).Value
                namacoa = DgSO.Rows(y).Cells.Item(1).Value
                ket = DgSO.Rows(y).Cells.Item(2).Value
                rpbarutoko = DgSO.Rows(y).Cells.Item(3).Value
                DgSO.Rows(y).Cells(4).Value = 0

                rpselisih = rpbarutoko - 0
                DgSO.Rows(y).Cells(5).Value = rpselisih
                Call hitung()
                Call hitungwads()
                Call hitungselisih()
                ''  DgSO.Rows(y).Cells(3).Selected = True
                Exit Sub
            Else
                SendKeys.Send("{up}")
                Exit Sub
            End If
        End If

        rpselisih = rpbarutoko - rpbaru
        DgSO.Rows(y).Cells(5).Value = rpselisih
        Call hitung()
        Call hitungwads()
        Call hitungselisih()
    End Sub
    Private Sub DgSO_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DgSO.EditingControlShowing
        AddHandler CType(e.Control, TextBox).KeyPress, AddressOf TextBox_keyPress
    End Sub
    Private Sub TextBox_keyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If DgSO.CurrentCell.ColumnIndex = 4 Then
            If Char.IsDigit(CChar(CStr(e.KeyChar))) = False Then e.Handled = True
            If Not (Char.IsDigit(CChar(CStr(e.KeyChar))) Or e.KeyChar = ".") Then e.Handled = True
            If e.KeyChar = " "c Then e.Handled = False

        End If
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnCancel.Click
        Call batal()
    End Sub
    Private Sub batal()
        flagadload = True
        Call kunci()
        Call cekstatus()
        Call loaddata()
        Call hitung()
        Call hitungwads()
        Call hitungselisih()
        btnFindToko.Enabled = True
        BtnNoRRAK.Enabled = True
        flagadgrid = True
    End Sub
    Private Sub simpan()
        flagadload = True
        Dim result2 As DialogResult = MessageBox.Show("Apakah perubahan Non RRAK akan di simpan ?", _
           "Warning !!", _
           MessageBoxButtons.YesNo, _
           MessageBoxIcon.Question)
        If result2 = DialogResult.Yes Then

            For Each row As DataGridViewRow In Me.DgSO.Rows
                kodecoa = row.Cells.Item(0).Value
                namacoa = row.Cells.Item(1).Value
                ket = row.Cells.Item(2).Value
                rpbarutoko = row.Cells.Item(3).Value
                rpbaru = row.Cells.Item(4).Value


                If rpbaru > 0 Then
                    sql = "exec spTblNonRRAK 'EditData',0," & TxtKodetoko.Text & "," & rpbaru & ",'" & kodecoa & "','" & namacoa & "','" & txtNoRRAK.Text & "'"

                    conn.Execute(sql)

                ElseIf rpbaru = 0 Then
                    sql = "exec spTblNonRRAK 'nilaitidakedit',0," & TxtKodetoko.Text & "," & rpbaru & ",'" & kodecoa & "','" & namacoa & "','" & txtNoRRAK.Text & "'"

                    conn.Execute(sql)

                End If


            Next
            MsgBox("Data berhasil di simpan", vbOKOnly + vbInformation, "Info")
            Call kunci()
            Call loaddata()
            Call cekstatus()
            Call hitung()
            Call hitungwads()
            Call hitungselisih()
            flagadd = False
            btnFindToko.Enabled = True
            BtnNoRRAK.Enabled = True
            BtnPrint.Enabled = True
            flagadgrid = True
        End If
    End Sub
    Private Sub BtnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSave.Click
        Call simpan()
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnPrint.Click
        Call cekstatusprint()
        Call gettoko(TxtKodetoko.Text)
        flagadgrid = True
        flagadload = True

        Dim objConn As OleDbConnection
        Dim objCmd As OleDbCommand
        Dim objReader As OleDbDataReader
        Dim objDataSet As DataSet = New dtsNonRRAK
        Dim strSQL, strCONN As String

        GetStringKoneksi() '---1
        strCONN = StrKoneksi '----2
        strSQL = " exec spTblNonRRAK 'Print',0," & TxtKodetoko.Text & ",0,'x','x','" & txtNoRRAK.Text & "'"
        conn.Execute(strSQL)

        objConn = New OleDbConnection(strCONN)
        objCmd = New OleDbCommand(strSQL, objConn)
        objCmd.CommandType = CommandType.Text
        objCmd.Connection.Open()
        objCmd.CommandTimeout = 0
        objReader = objCmd.ExecuteReader
        objDataSet.Tables(1).Clear()
        objDataSet.Tables(1).Load(objReader)
        objReader.Close()
        objConn.Close()

        Dim rds As ReportDataSource = New ReportDataSource
        rds.Name = "dtsNonRRAKDetail"
        rds.Value = objDataSet.Tables(1)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", "LEMBAR DOKUMEN NON RRAK", True))
        paramList.Add(New ReportParameter("KodeToko", Me.TxtKodetoko.Text, True))
        paramList.Add(New ReportParameter("NamaToko", Me.txtnamatoko.Text, True))
        paramList.Add(New ReportParameter("KodeNonRRAK", Me.txtNoRRAK.Text, True))
        paramList.Add(New ReportParameter("namaDC", namadc, True))
        'paramList.Add(New ReportParameter("TglApprove", Now, True))
        paramList.Add(New ReportParameter("Status", status, True))
        paramList.Add(New ReportParameter("penanggungjawab", StrUserid, True))
        paramList.Add(New ReportParameter("tglCetak", Now, True))
        paramList.Add(New ReportParameter("TotalToko", Me.txttotaltoko.Text, True))
        paramList.Add(New ReportParameter("TotalWads", Me.txttotalwads.Text, True))
        paramList.Add(New ReportParameter("TotalSelisih", Me.txttotalselisih.Text, True))
        paramList.Add(New ReportParameter("alamat", alamattoko, True))
        Dim ReportViewerForm As New FrmReport
        ReportViewerForm.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".rptNonRRAK.rdlc"
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewerForm.ReportViewer1.LocalReport.SetParameters(paramList)
        ReportViewerForm.ReportViewer1.RefreshReport()
        ReportViewerForm.Show()

    End Sub

    Private Sub loaddataawal()
        flagadshow = True
        DgSO.DataSource = Nothing
        DgSO.Rows.Clear()
        DgSO.Columns.Clear()


        Dim aCol() As Integer = {10, 10, 10, 30, 15, 10}
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
        DgSO.AllowUserToAddRows = False

        sqlstring = "exec spTblNonRRAK 'StatusAwal',0,0,0,'x','x','x'"

        GetStringKoneksi()
        GetKoneksiSQLClient()
        da = New SqlDataAdapter(sqlstring, SQLConn)
        DS = New DataSet
        da.Fill(DS, (sqlstring))
        Me.DgSO.DataSource = DS.Tables(sqlstring)

        For icol = 0 To 5
            DgSO.Columns(icol).Width = (DgSO.Width / 100) * aCol(icol)
            Select Case icol
                Case 0
                    DgSO.Columns(icol).HeaderText = "Tanggal Pembuatan"
                    DgSO.Columns(icol).ReadOnly = True

                Case 1
                    DgSO.Columns(icol).HeaderText = "Nomor NON RRAK"
                    DgSO.Columns(icol).ReadOnly = True
                Case 2
                    DgSO.Columns(icol).HeaderText = "Kode Toko"
                    DgSO.Columns(icol).ReadOnly = True
                Case 3
                    DgSO.Columns(icol).HeaderText = "Nama Toko"
                    DgSO.Columns(icol).ReadOnly = True
                Case 4
                    DgSO.Columns(icol).HeaderText = "Status Realisasi"
                    DgSO.Columns(icol).ReadOnly = True
                Case 5
                    DgSO.Columns(icol).HeaderText = "Nama DC"
                    DgSO.Columns(icol).ReadOnly = True

            End Select

        Next

    End Sub

    Private Sub DgSO_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgSO.CellMouseClick
        flagadload = False
        '' flagadgrid = False
        If flagadgrid = True Then
            Exit Sub
        ElseIf flagadgrid = False Then
            nonr = DgSO.Rows(e.RowIndex).Cells(1).Value
            kdtk = DgSO.Rows(e.RowIndex).Cells(2).Value
            nmtko = DgSO.Rows(e.RowIndex).Cells(3).Value
            Call loaddata()
            BtnEdit.Enabled = True
            BtnApproval.Enabled = True
            flagadgrid = True
            '' Call cekperiodeaktif()
        End If
       
    End Sub

    Private Sub DgSO_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgSO.CellContentClick

    End Sub
End Class