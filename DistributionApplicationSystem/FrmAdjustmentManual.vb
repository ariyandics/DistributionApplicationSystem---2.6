Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Data.OleDb
Public Class FrmAdjustmentManual
    Dim Conn, ConnMDB As New ADODB.Connection
    Dim RsConn, RsMdb As New ADODB.Recordset
    Dim counter, nomor As Integer
    Dim flagadd, flagedit, baru, lama As Boolean
    Dim qtyso As Integer
    Dim sql As String
    Dim boleh As Boolean
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If MessageBox.Show("Apakah semua data sudah selesai di input dan akan di simpan ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
           
            If flagadd = True Then
                sql = "exec spSoAdjusmentDetailTmp 'Save'," & IdDC & "," & Val(TxtNoLock.Text) & ",'nama',0,0,0,'" & StrNamaUser & "'"
                If Conn.State = 0 Then
                    Call GetStringKoneksi()
                    Conn.Open(StrKoneksi)
                End If
                Conn.Execute(sql)
                TxtNoAdj.Text = TxtNoLock.Text

            End If

            If flagedit = True Then
                sql = "exec spSoAdjusmentDetailTmp 'SaveAdj'," & IdDC & "," & Val(TxtNoLock.Text) & ",'nama',0,0,0,'" & StrNamaUser & "'"
                If Conn.State = 0 Then
                    Call GetStringKoneksi()
                    Conn.Open(StrKoneksi)
                End If
                Conn.Execute(sql)
            End If

            Call hitung()
            Call pesan(3)
            Call kunci()

            BtnAdd.Enabled = True
            BtnApprove.Enabled = True
            BtnPrint.Enabled = True
            BtnEdit.Enabled = True

        End If
    End Sub
    Private Sub GbrTombol()
        Me.BtnAdd.Image = System.Drawing.Image.FromFile(icoadd)
        Me.BtnApprove.Image = System.Drawing.Image.FromFile(icoapprove)
        Me.BtnEdit.Image = System.Drawing.Image.FromFile(icoedit)
        Me.BtnCancel.Image = System.Drawing.Image.FromFile(icocancel)
        Me.BtnSave.Image = System.Drawing.Image.FromFile(icosave)
        Me.BtnPrint.Image = System.Drawing.Image.FromFile(icoprint)

    End Sub

    Private Sub FrmAdjustmentManual_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Call batal()
    End Sub

    Private Sub FrmAdjustmentManual_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        BtnAdd.Enabled = True
        BtnFindNoAdj.Enabled = True
        boleh = False
    End Sub
    Private Sub kunci()
        BtnAdd.Enabled = False
        BtnSave.Enabled = False
        BtnEdit.Enabled = False
        BtnPrint.Enabled = False
        BtnFindNo.Enabled = False
        BtnCancel.Enabled = False
        BtnApprove.Enabled = False
        BtnFindNoAdj.Enabled = False
        DgSO.ReadOnly = True
        flagadd = False
        flagedit = False

    End Sub

    Private Sub bersih()
        TxtNoLock.Clear()
        TxtNoAdj.Clear()
        TxtTglSo.Clear()
        TxtTglApprove.Clear()
        TxtUser.Clear()
        TxtNamaBarang.Clear()
        TxtSelQty.Clear()
        TxtSelRp.Clear()
        TxtTtlItem.Clear()
        TxtJenisStock.Clear()

        TxtTtlItem.ReadOnly = True
        TxtNoLock.ReadOnly = True
        TxtNoAdj.ReadOnly = True
        TxtTglSo.ReadOnly = True
        TxtUser.ReadOnly = True
        TxtTglApprove.ReadOnly = True
        TxtNamaBarang.ReadOnly = True
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Call cektable()
        Call batal()
        Call bersih()
        Call kunci()
        TxtNoLock.Text = 0
        Call LoadDataKeGrid()
        TxtNoLock.Clear()

        BtnCancel.Enabled = True
        BtnFindNo.Enabled = True
        flagadd = True
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Call bersih()
        Call kunci()
        TxtNoLock.Text = 0
        Call LoadDataKeGrid()
        TxtNoLock.Clear()
        BtnAdd.Enabled = True
        BtnFindNoAdj.Enabled = True
    End Sub

    Private Sub LoadDataKeGrid()
        Dim strfind As String
        If TxtNamaBarang.Text = "" Then
            strfind = "%"
        Else
            strfind = "%" & TxtNamaBarang.Text & "%"
        End If

        Dim aCol() As Integer = {8, 10, 45, 10, 10, 6}
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


        sqlstring = "exec spSoAdjusmentDetailTmp  'getnama'," & IdDC & "," & Val(TxtNoLock.Text) & ",'%" & TxtNamaBarang.Text & "%',0,0,0,'" & StrNamaUser & "'"
     

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

                    If flagadd = True Then
                        DgSO.Columns(icol).ReadOnly = True
                    ElseIf flagedit = True Then
                        DgSO.Columns(icol).ReadOnly = False
                    End If

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

    Private Sub BtnFindNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFindNo.Click

        TxtNoLock.Text = FrmFind.cari("NoAdjSOTmp")

        If TxtNoLock.Text = "0" Then
            TxtNoLock.Text = ""
            Call bersih()
            Call LoadDataKeGrid()
            Call kunci()
            BtnFindNoAdj.Enabled = True
            BtnAdd.Enabled = True
            Exit Sub
        Else
            sql = "spsoFreezeDetailTmp 'get','nama'," & IdDC & "," & TxtNoLock.Text & ",0,0,'" & StrNamaUser & "',0"
            RsConn = Conn.Execute(sql)
            If Not RsConn.EOF Then
                TxtTglSo.Text = Format(RsConn("tglSofreeze").Value, "dd-MM-yyyy")
                TxtJenisStock.Text = RsConn("namajenisstok").Value
            End If

            TxtUser.Text = StrNamaUser

            sql = "exec spSoAdjusmentDetailTmp 'add'," & IdDC & "," & Val(TxtNoLock.Text) & ",'nama',0,0,0,'" & StrNamaUser & "'"
            RsConn = Conn.Execute(sql)

            Call LoadDataKeGrid()
            Call hitung()
            BtnSave.Enabled = True
            BtnCancel.Enabled = True
            TxtNamaBarang.ReadOnly = False
        End If

      
    End Sub
    Private Sub hitung()
        sql = "exec spSoAdjusmentDetailTmp  'Hitung'," & IdDC & "," & Val(TxtNoLock.Text) & ",'%" & "%',0,0,0,'" & StrNamaUser & "'"
        RsConn = Conn.Execute(sql)
        If Not RsConn.EOF Then
            TxtTtlItem.Text = Format(RsConn("ttlitem").Value, "#,##0")
            TxtSelQty.Text = Format(RsConn("ttlqty").Value, "#,##0")
            TxtSelRp.Text = Format(RsConn("ttlrp").Value, "#,##0.##")
        End If

    End Sub

    Private Sub cektable()
        sql = "Select TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='SoAdjusmentDetailTmp'"
        RsConfig = Conn.Execute(sql)
        If RsConfig.EOF Then
            sql = "select top 0 * into SoAdjusmentDetailTmp from SoAdjusmentDetail "
            Conn.Execute(sql)

            sql = "alter table SoAdjusmentDetailTmp add statusdata int"
            Conn.Execute(sql)
        End If

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


        If flagedit = True And e.ColumnIndex = 4 Then
            idProduk = DgSO.Rows(y).Cells(5).Value
            If Not IsDBNull(DgSO.Rows(y).Cells(4).Value) Then
                qtyso = DgSO.Rows(y).Cells(4).Value
            Else
                qtyso = 0
            End If

            sql = "exec spSoAdjusmentDetailTmp 'Edit'," & IdDC & "," & Val(TxtNoLock.Text) & ",'nama'," & idProduk & "," & qtyso & ",0,'" & StrNamaUser & "'"
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

        strSQL = "exec spSoAdjusmentDetailTmp 'Print'," & IdDC & "," & Val(TxtNoAdj.Text) & ",'nama',0,0,0,'" & StrNamaUser & "'"

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
            statusSO = "NOT APPROVED"
        Else
            statusSO = "APPROVED"
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

    Private Sub TxtNamaBarang_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNamaBarang.KeyPress
        If (e.KeyChar Like "[',]") Then e.Handled() = True
    End Sub

    Private Sub TxtNamaBarang_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNamaBarang.TextChanged
        Call LoadDataKeGrid()
    End Sub

    Private Sub BtnFindNoAdj_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFindNoAdj.Click
        Call bersih()
        TxtNoAdj.Text = FrmFind.cari("NoAdjSO")

        If TxtNoAdj.Text = "0" Then
            TxtNoLock.Text = ""
            Call bersih()
            Call LoadDataKeGrid()
            Call kunci()
            BtnFindNoAdj.Enabled = True
            BtnAdd.Enabled = True
            Exit Sub
        Else
            TxtNoLock.Text = TxtNoAdj.Text

            sql = "exec spSoAdjusmentDetailTmp 'GetAdj'," & IdDC & "," & Val(TxtNoLock.Text) & ",'nama',0,0,0,'" & StrNamaUser & "'"
            RsConn = Conn.Execute(sql)
            If Not RsConn.EOF Then
                TxtTglSo.Text = Format(RsConn("tglSOfreeze").Value, "dd-MM-yyyy")
                TxtUser.Text = RsConn("iduser").Value
                TxtJenisStock.Text = RsConn("namajenisstok").Value
                If RsConn("statusdata").Value > 0 Then
                    Call kunci()
                    TxtTglApprove.Text = Format(RsConn("tglSOAdjusment").Value, "dd-MM-yyyy HH:mm:ss")
                    BtnAdd.Enabled = True
                    BtnPrint.Enabled = True
                    BtnFindNoAdj.Enabled = True
                Else
                    BtnEdit.Enabled = True
                    BtnPrint.Enabled = True
                    BtnApprove.Enabled = True
                End If

            End If

            TxtUser.Text = StrNamaUser
            Call batal()

            sql = "exec spSoAdjusmentDetailTmp 'AddAdj'," & IdDC & "," & Val(TxtNoLock.Text) & ",'nama',0,0,0,'" & StrNamaUser & "'"
            RsConn = Conn.Execute(sql)

            Call LoadDataKeGrid()
            Call hitung()
            TxtNamaBarang.ReadOnly = False
        End If



    End Sub

    Private Sub batal()
        sql = "exec spSoAdjusmentDetailTmp 'Delete'," & IdDC & "," & Val(TxtNoLock.Text) & ",'nama',0,0,0,'" & StrNamaUser & "'"
        RsConn = Conn.Execute(sql)
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click

        Boleh = FrmValidasi.cari("PO")
        If Boleh = True Then
            Call kunci()
            DgSO.ReadOnly = False
            flagedit = True

            BtnSave.Enabled = True
            BtnCancel.Enabled = True
            boleh = False
        Else
            MsgBox("Password yang anda masukan salah !!" & vbCrLf _
                  & "Anda tidak berhak merubah data..", vbOKOnly + vbCritical, "Warning !!")
            Exit Sub
        End If


    End Sub


    Private Sub BtnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnApprove.Click
        GetStringKoneksi()
        GetKoneksiSQLClient()
        sql = "exec spSoAdjusmentDetailTmp 'GetHpp'," & IdDC & "," & Val(TxtNoAdj.Text) & ",'nama',0,0,0,'" & StrNamaUser & "'"
        cmd = New SqlCommand(sql, SQLConn)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            MsgBox("Hpp " & dr.Item("kodeproduk") & "-" & dr.Item("namapanjang") & " masih nol (0) , silahkan info ke IT Administrator !!", vbOKOnly + vbCritical, "Info")
            Exit Sub
        Else
            Call ApproveData()
        End If

    End Sub
    Private Sub ApproveData()
        If MessageBox.Show("Apakah anda sudah yakin dengan data tersebut dan ingin di Approve ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            sql = "exec spSoAdjusmentDetailTmp 'Approve'," & IdDC & "," & Val(TxtNoAdj.Text) & ",'nama',0,0,0,'" & StrNamaUser & "'"
            RsConn = conn.Execute(sql)
            MsgBox("Data Berhasil di Approve", vbInformation, "Konfirmasi")

            Call kunci()
            BtnFindNoAdj.Enabled = True
            BtnAdd.Enabled = True
            BtnPrint.Enabled = True
            TxtTglApprove.Text = Format(Now, "dd-MM-yyyy")

        End If
    End Sub

  
End Class