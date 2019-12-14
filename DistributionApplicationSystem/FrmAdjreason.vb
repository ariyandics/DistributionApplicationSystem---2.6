Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Data.OleDb
Public Class FrmAdjreason
    Dim Conn, ConnMDB As New ADODB.Connection
    Dim RsConn, RsMdb As New ADODB.Recordset
    Dim counter, nomor As Integer
    Dim flagedit, baru, lama As Boolean
    Dim qtyso, idalasan As Integer
    Dim sql As String
    Dim boleh As Boolean
    Private Sub BtnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnApprove.Click
        Call ApproveData()
    End Sub
    Private Sub ApproveData()
        If MessageBox.Show("Apakah anda sudah yakin dengan data tersebut dan ingin di Approve ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            sql = "exec spSoAdjusmentDetailTmp 'cekalasan'," & IdDC & "," & Val(TxtNoAdj.Text) & ",'nama',0,0,0,'" & StrNamaUser & "'"
            RsConn = Conn.Execute(sql)
            If Not RsConn.EOF Then
                MsgBox("Masih ada Keterangan Selisih yang belum di isi !!!", vbOKOnly + vbCritical, "info")
                Exit Sub
            Else
                If Conn.State = 0 Then
                    Call GetStringKoneksi()
                    Conn.Open(StrKoneksi)
                End If
                sql = "exec spSoAdjusmentDetailTmp 'Posting'," & IdDC & "," & Val(TxtNoAdj.Text) & ",'nama',0,0,0,'" & StrNamaUser & "'"
                Conn.Execute(sql)
                MsgBox("Data Berhasil di Posting", vbInformation, "Konfirmasi")

                Call kunci()
                BtnFindNoAdj.Enabled = True
                BtnPrint.Enabled = True
                TxtTglApprove.Text = Format(Now, "dd-MM-yyyy")
            End If
        End If
    End Sub
    Private Sub kunci()
        BtnSave.Enabled = False
        BtnEdit.Enabled = False
        BtnPrint.Enabled = False
        BtnApprove.Enabled = False
        BtnFindNoAdj.Enabled = False
        BtnCancel.Enabled = False
        ' DgSO.ReadOnly = True
        flagedit = False

    End Sub
    Private Sub GbrTombol()

        Me.BtnApprove.Image = System.Drawing.Image.FromFile(icoapprove)
        Me.BtnEdit.Image = System.Drawing.Image.FromFile(icoedit)
        Me.BtnSave.Image = System.Drawing.Image.FromFile(icosave)
        Me.BtnPrint.Image = System.Drawing.Image.FromFile(icoprint)
        Me.BtnCancel.Image = System.Drawing.Image.FromFile(icocancel)
    End Sub
    Private Sub FrmAdjreason_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        BtnFindNoAdj.Enabled = True
        boleh = False
    End Sub

    Private Sub bersih()
        TxtNoAdj.Clear()
        TxtTglApprove.Clear()
        TxtUser.Clear()
        TxtNoAdj.ReadOnly = True
        TxtUser.ReadOnly = True
        TxtTglApprove.ReadOnly = True
    End Sub

    Private Sub BtnFindNoAdj_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFindNoAdj.Click
        TxtNoAdj.Text = FrmFind.cari("NoAdjSO")

        If TxtNoAdj.Text = "0" Then
            Call bersih()
            Call LoadDataKeGrid()
            Call kunci()
            BtnFindNoAdj.Enabled = True
            Exit Sub
        Else
            sql = "exec spSoAdjusmentDetailTmp 'GetAdj'," & IdDC & "," & Val(TxtNoAdj.Text) & ",'nama',0,0,0,'" & StrNamaUser & "'"
            RsConn = Conn.Execute(sql)
            If Not RsConn.EOF Then
                TxtUser.Text = RsConn("iduser").Value
                TxtJenisStock.Text = RsConn("namajenisstok").Value
                Call kunci()
                BtnFindNoAdj.Enabled = True
                If RsConn("statusdata").Value = 2 Then

                    TxtTglApprove.Text = Format(RsConn("tglSOAdjusment").Value, "dd-MM-yyyy HH:mm:ss")
                    BtnPrint.Enabled = True
                Else

                    BtnEdit.Enabled = True
                    ' BtnPrint.Enabled = True
                    BtnApprove.Enabled = True
                End If

            End If

            TxtUser.Text = StrNamaUser
            sql = "exec spSoAdjusmentDetailTmp 'AddAdj'," & IdDC & "," & Val(TxtNoAdj.Text) & ",'nama',0,0,0,'" & StrNamaUser & "'"
            RsConn = Conn.Execute(sql)

            Call LoadDataKeGrid()

        End If



    End Sub

    Private Sub LoadDataKeGrid()

        DgSO.DataSource = Nothing
        DgSO.Columns.Clear()
        Dim strfind As String
        'If TxtNamaBarang.Text = "" Then
        strfind = "%"
        'Else
        '    strfind = "%" & TxtNamaBarang.Text & "%"
        'End If



        Dim aCol() As Integer = {8, 10, 45, 10, 10, 0, 0, 20}
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


        sqlstring = "exec spSoAdjusmentDetailTmp  'GetGrid'," & IdDC & "," & Val(TxtNoAdj.Text) & ",'%" & strfind & "%',0,0,0,'" & StrNamaUser & "'"


        GetStringKoneksi()
        GetKoneksiSQLClient()
        da = New SqlDataAdapter(sqlstring, SQLConn)
        DS = New DataSet
        da.Fill(DS, (sqlstring))
        Me.DgSO.DataSource = DS.Tables(sqlstring)


        ' format kolom datagrid pcn
        For icol = 0 To 7
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
                    DgSO.Columns(icol).HeaderText = "Planogram"
                    DgSO.Columns(icol).ReadOnly = True
                Case 4
                    DgSO.Columns(icol).HeaderText = "Qty Selisih"
                    DgSO.Columns(icol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DgSO.Columns(icol).DefaultCellStyle.Format = "##,0"

                Case 5
                    DgSO.Columns(icol).HeaderText = "idadjust"
                    DgSO.Columns(icol).ReadOnly = True
                    DgSO.Columns(icol).Visible = False
                Case 6
                    DgSO.Columns(icol).HeaderText = "idproduk"
                    DgSO.Columns(icol).ReadOnly = True
                    DgSO.Columns(icol).Visible = False
                Case 7
                    DgSO.Columns(icol).HeaderText = "Keterangan Selisih"
                    DgSO.Columns(icol).ReadOnly = True


            End Select

        Next

        For counter = 0 To (DgSO.Rows.Count - 1)

            nomor = counter + 1
            DgSO.Rows(counter).Cells(0).Value() = nomor

        Next

    End Sub
    Private Sub LoadDataKeGridTMP()

        DgSO.DataSource = Nothing
        DgSO.Columns.Clear()

        Dim strfind As String
        'If TxtNamaBarang.Text = "" Then
        strfind = "%"
        'Else
        '    strfind = "%" & TxtNamaBarang.Text & "%"
        'End If



        Dim aCol() As Integer = {8, 10, 45, 10, 10, 0, 0, 20}
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


        sqlstring = "exec spSoAdjusmentDetailTmp  'GetGridTMP'," & IdDC & "," & Val(TxtNoAdj.Text) & ",'%" & strfind & "%',0,0,0,'" & StrNamaUser & "'"


        GetStringKoneksi()
        GetKoneksiSQLClient()
        da = New SqlDataAdapter(sqlstring, SQLConn)
        DS = New DataSet
        da.Fill(DS, (sqlstring))
        Me.DgSO.DataSource = DS.Tables(sqlstring)


        ' format kolom datagrid pcn
        For icol = 0 To 6
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
                    DgSO.Columns(icol).HeaderText = "Planogram"
                    DgSO.Columns(icol).ReadOnly = True
                Case 4
                    DgSO.Columns(icol).HeaderText = "Qty Selisih"
                    DgSO.Columns(icol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DgSO.Columns(icol).DefaultCellStyle.Format = "##,0"
                    DgSO.Columns(icol).ReadOnly = True

                Case 5
                    DgSO.Columns(icol).HeaderText = "idadjust"
                    DgSO.Columns(icol).ReadOnly = True
                    DgSO.Columns(icol).Visible = False
                Case 6
                    DgSO.Columns(icol).HeaderText = "idproduk"
                    DgSO.Columns(icol).ReadOnly = True
                    DgSO.Columns(icol).Visible = False

                    Getalasan()

            End Select

        Next

        For counter = 0 To (DgSO.Rows.Count - 1)

            nomor = counter + 1
            DgSO.Rows(counter).Cells(0).Value() = nomor
            idalasan = DgSO.Rows(counter).Cells(5).Value
            sql = "Select * from MstAdjustReason where idadjust =" & idalasan
            RsConn = Conn.Execute(sql)
            If Not RsConn.EOF Then
                DgSO.Rows(counter).Cells(7).Value() = RsConn("alasan").Value
            End If

        Next

    End Sub
    Private Sub Getalasan()

        If Conn.State = 0 Then
            Call GetStringKoneksi()
            Conn.Open(StrKoneksi)
        End If

        sql = "exec spMstAdjustReason'Get','0','0','2018-01-01','2018-01-01','0','0','Coa'"
        RsConn = Conn.Execute(sql)
        If Not RsConn.EOF Then

            Dim cmb As New DataGridViewComboBoxColumn()

            cmb.HeaderText = "Keterangan Selisih"
            cmb.Name = "cmb"
            cmb.MaxDropDownItems = 5
            DgSO.Columns.Add(cmb)
            cmb.Width = 180
            'DgSO.AllowUserToAddRows = True
            DgSO.ReadOnly = False
            RsConn.MoveFirst()
            Do While Not RsConn.EOF
                cmb.Items.Add(RsConn("alasan").Value)
                RsConn.MoveNext()
            Loop

        End If


    End Sub


    Private Sub ComboBox_SelectionchangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim x As Integer = DgSO.CurrentCellAddress.X
        Dim y As Integer = DgSO.CurrentCellAddress.Y

        Dim combo As ComboBox = CType(sender, ComboBox)
        Dim Pilih As String
        Pilih = combo.SelectedItem.ToString

        sql = "Select * from MstAdjustReason where alasan='" & Pilih & "'"
        RsConn = Conn.Execute(sql)
        If Not RsConn.EOF Then
            idalasan = RsConn("idadjust").Value
        End If
        idProduk = DgSO.Rows(y).Cells(6).Value

        sql = "exec spSoAdjusmentDetailTmp 'EditReas'," & IdDC & "," & Val(TxtNoAdj.Text) & ",'nama'," & idProduk & "," & qtyso & "," & idalasan & ",'" & StrNamaUser & "'"
        Conn.Execute(sql)

    End Sub


    Private Sub DgSO_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DgSO.EditingControlShowing
        'AddHandler CType(e.Control, TextBox).KeyPress, AddressOf TextBox_keyPress
        If Me.DgSO.CurrentCell.ColumnIndex = 7 Then

            Dim combo As ComboBox = CType(e.Control, ComboBox)

            If combo IsNot Nothing Then

                ' Remove an existing event-handler, if present, to avoid adding multiple handlers when the editing control is reused.

                RemoveHandler combo.SelectionChangeCommitted, New EventHandler(AddressOf ComboBox_SelectionchangeCommitted)

                ' Add the event handler.

                AddHandler combo.SelectionChangeCommitted, New EventHandler(AddressOf ComboBox_SelectionchangeCommitted)


            End If


        End If
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


        If flagedit = True And e.ColumnIndex = 4 Then
            idProduk = DgSO.Rows(y).Cells(5).Value
            If Not IsDBNull(DgSO.Rows(y).Cells(4).Value) Then
                qtyso = DgSO.Rows(y).Cells(4).Value
            Else
                qtyso = 0
            End If

            sql = "exec spSoAdjusmentDetailTmp 'Edit'," & IdDC & "," & Val(TxtNoAdj.Text) & ",'nama'," & idProduk & "," & qtyso & ",0,'" & StrNamaUser & "'"
            RsConn = Conn.Execute(sql)

        End If

    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Call cetak()
    End Sub

    Private Sub cetak()
        Dim objConn As OleDbConnection
        Dim objCmd As OleDbCommand
        Dim objReader As OleDbDataReader
        Dim objDataSet As DataSet = New DataSetSO
        Dim strSQL, strCONN As String

        GetStringKoneksi() '---1
        strCONN = StrKoneksi '----2

        strSQL = "exec spSoAdjusmentDetailTmp 'PrintRes'," & IdDC & "," & Val(TxtNoAdj.Text) & ",'nama',0,0,0,'" & StrNamaUser & "'"

        objConn = New OleDbConnection(strCONN)
        objCmd = New OleDbCommand(strSQL, objConn)
        objCmd.CommandType = CommandType.Text
        objCmd.Connection.Open()
        objCmd.CommandTimeout = 0
        objReader = objCmd.ExecuteReader
        objDataSet.Tables(0).Clear()
        objDataSet.Tables(0).Load(objReader)
        objReader.Close()
        objConn.Close()

        Dim rds As ReportDataSource = New ReportDataSource
        rds.Name = "DataSetSO"
        rds.Value = objDataSet.Tables(0)

        Dim statusSO As String
        If TxtTglApprove.Text = "" Then
            statusSO = "APROVED"
        Else
            statusSO = "POSTING"
        End If

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaDC", namadc, True))
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", "ADJUSTMENT STOCK OPNAME", True))
        paramList.Add(New ReportParameter("NoAdj", Me.TxtNoAdj.Text, True))
        paramList.Add(New ReportParameter("TglAdj", Me.TxtTglApprove.Text, True))
        paramList.Add(New ReportParameter("Status", statusSO, True))
        paramList.Add(New ReportParameter("JenisStock", Me.TxtJenisStock.Text, True))

        Dim ReportViewerForm As New FrmReport
        ReportViewerForm.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptSOAdj.rdlc"
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewerForm.ReportViewer1.LocalReport.SetParameters(paramList)
        ReportViewerForm.ReportViewer1.RefreshReport()
        ReportViewerForm.Show()

    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        boleh = FrmValidasi.cari("PO")
        boleh = True
        If boleh = True Then
            Call kunci()
            flagedit = True
            BtnSave.Enabled = True
            BtnCancel.Enabled = True
            boleh = False
            Call LoadDataKeGridTMP()
            DgSO.ReadOnly = False

        Else
            MsgBox("Password yang anda masukan salah !!" & vbCrLf _
                  & "Anda tidak berhak merubah data..", vbOKOnly + vbCritical, "Warning !!")
            Exit Sub
        End If
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Call bersih()
        Call kunci()
        Call LoadDataKeGrid()
        TxtNoAdj.Clear()
        BtnFindNoAdj.Enabled = True
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Call LoadDataKeGrid()
        Call kunci()
        BtnEdit.Enabled = True
        BtnFindNoAdj.Enabled = True
        BtnApprove.Enabled = True
    End Sub
End Class