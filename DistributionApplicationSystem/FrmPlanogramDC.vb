Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Data.OleDb
Public Class FrmPlanogramDC
    Dim Conn, ConnMDB As New ADODB.Connection
    Dim RsConn, RsMdb, rsconnx As New ADODB.Recordset
    Dim flagedit As Boolean
    Dim idrak, plu, idshelving As Integer
    Dim counter, nomor As Integer
    Dim sql, strfind As String
    Dim kika, ab, db, kap, mindis, maxdis As Int64
    Dim strplu, strnamabarang, strline, strrak, strshelving As String
    Dim strkika, strab, strdb As String
    Dim strtgl As String


    Private Sub FrmPlanogramToko_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        flagedit = False
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
       
        Call bersih()
        Call cmblist()
        CmbFilter.Text = "All"
        Call GbrTombol()
        Call LoadDataKeGrid()
    End Sub
    Private Sub GbrTombol()
        Me.btnclear.Image = System.Drawing.Image.FromFile(icoclear)
        Me.BtnEdit.Image = System.Drawing.Image.FromFile(icoedit)
        Me.BtnCancel.Image = System.Drawing.Image.FromFile(icocancel)
        Me.BtnSave.Image = System.Drawing.Image.FromFile(icosave)
        Me.BtnPrint.Image = System.Drawing.Image.FromFile(icoprint)
    End Sub

    Private Sub LoadDataKeGrid()
        ListView2.Columns.Clear()
        ListView2.Items.Clear()
        ListView2.View = Windows.Forms.View.Details
        ListView2.GridLines = True
        ListView2.FullRowSelect = True

        If TXTFIND.Text = "" Then
            strfind = "%"
        Else
            strfind = TXTFIND.Text
        End If


        ListView2.Columns.Add("No", 50)
        ListView2.Columns.Add("SKU", 60)
        ListView2.Columns.Add("Description", 300)
        ListView2.Columns.Add("Rak", 60)
        ListView2.Columns.Add("Bay", 60)
        ListView2.Columns.Add("Shelving", 60)
        ListView2.Columns.Add("KI-KA", 60)
        ListView2.Columns.Add("A-B", 60)
        ListView2.Columns.Add("D-B", 60)
        ListView2.Columns.Add("Tgl Update", 70)

      
        If CmbFilter.Text = "Plano" Then
            sql = "exec spMstPlanoDc 'GetByRak','%" & strfind & "%',0,0,0,0,0,0,0,0,'" & StrNamaUser & "'"
        ElseIf CmbFilter.Text = "Non Plano" Then
            sql = "exec spMstPlanoDc 'GetNonRak','%" & strfind & "%',0,0,0,0,0,0,0,0,'" & StrNamaUser & "'"
        Else
            sql = "exec spMstPlanoDc 'get','%" & strfind & "%',0,0,0,0,0,0,0,0,'" & StrNamaUser & "'"
        End If
        RsConn = Conn.Execute(sql)


        If Not RsConn.EOF Then
            RsConn.MoveFirst()
            nomor = 1
            Do While Not RsConn.EOF

                strplu = RsConn("kodeproduk").Value
                strnamabarang = RsConn("namapanjang").Value
                strrak = RsConn("namarak").Value & ""
                strline = RsConn("line").Value & ""
                strshelving = RsConn("namashelving").Value & ""
                strkika = RsConn("tierKK").Value & ""
                strab = RsConn("tierAB").Value & ""
                strdb = RsConn("tierDB").Value & ""
                strtgl = RsConn("tglupdate").Value & ""

             
                Dim arr(10) As String
                Dim itm As ListViewItem

                arr(0) = nomor
                arr(1) = strplu
                arr(2) = strnamabarang
                arr(3) = strrak
                arr(4) = strline
                arr(5) = strshelving
                arr(6) = strkika
                arr(7) = strab
                arr(8) = strdb
                arr(9) = strtgl

                itm = New ListViewItem(arr)
                ListView2.Items.Add(itm)
                nomor = nomor + 1
                RsConn.MoveNext()

            Loop

        End If
        RsConn.Close()
    End Sub

    Private Sub BtnRak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRak.Click
        FrmMasterRak.ShowDialog()
        Call cmblist()
    End Sub

    Private Sub BtnShelv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShelv.Click
        FrmMasterShelving.ShowDialog()
        Call shelv()
    End Sub
    Private Sub bersih()
        txtkode.Clear()
        TxtNamabarang.Clear()
        txtKika.Clear()
        txtab.Clear()
        txtdb.Clear()
        txtLine.Clear()
        txtlubang.Clear()
        TXTFIND.Clear()
        cmbrak.Text = ""
        cmbshelving.Text = ""

        txtkode.ReadOnly = True
        txtkode.BackColor = Color.White
        TxtNamabarang.ReadOnly = True
        TxtNamabarang.BackColor = Color.White
        txtlubang.ReadOnly = True
        txtlubang.BackColor = Color.White
      
        Panel1.Enabled = False
        BtnSave.Enabled = False
        BtnEdit.Enabled = False
        BtnCancel.Enabled = False
        btnclear.Enabled = False

    End Sub

    Private Sub cmblist()
        cmbrak.Items.Clear()
        strsql = "exec spMstRakdc 'get','0','%','" & StrNamaUser & "'"
        RsConn = Conn.Execute(strsql)
        If Not RsConn.EOF Then
            RsConn.MoveFirst()
            Do While Not RsConn.EOF
                cmbrak.Items.Add(RsConn("Namarak").Value)
                RsConn.MoveNext()
            Loop
        End If
        RsConn.Close()

        CmbFilter.Items.Clear()
        CmbFilter.Items.Add("All")
        CmbFilter.Items.Add("Plano")
        CmbFilter.Items.Add("Non Plano")
    End Sub

    Private Sub cmbrak_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbrak.KeyPress
        If (e.KeyChar Like "[',]") Then e.Handled() = True
    End Sub

    Private Sub cmbrak_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbrak.TextChanged
        If cmbrak.Text = "" Then Exit Sub

        strsql = "exec spMstRakdc 'get','1','" & cmbrak.Text & "','" & StrNamaUser & "'"
        RsConfig = Conn.Execute(strsql)
        If Not RsConfig.EOF Then
            idrak = RsConfig("idrak").Value
        End If

        If flagedit = True Then
            cmbshelving.Items.Clear()
            txtlubang.Text = ""
            ' Sql = " select * from mstshelvingToko where kodetipetoko='" & Microsoft.VisualBasic.Left(cmbTipetoko.Text, 1) & "' and idrak=" & idrak
            RsConfig = Conn.Execute(sql)
            If Not RsConfig.EOF Then
                RsConfig.MoveFirst()
                Do While Not RsConfig.EOF
                    cmbshelving.Items.Add(RsConfig("namashelving").Value)
                    RsConfig.MoveNext()
                Loop
            End If
        End If
    End Sub

    Private Sub cmbshelving_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbshelving.KeyPress
        If (e.KeyChar Like "[',]") Then e.Handled() = True
    End Sub


    Private Sub cmbshelving_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbshelving.TextChanged
        sql = "exec spMstShelvingdc 'get'," & idrak & ",1,'" & cmbshelving.Text & "',0,'" & StrNamaUser & "'"
        RsConfig = Conn.Execute(sql)
        If Not RsConfig.EOF Then
            txtlubang.Text = RsConfig("nolubang").Value
            idshelving = RsConfig("idshelving").Value
        Else
            idshelving = 0
        End If


    End Sub

    Private Sub cmbrak_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbrak.SelectedIndexChanged
        If cmbrak.Text = "" Then Exit Sub
        If flagedit = True Then Call shelv()
    End Sub
    Private Sub shelv()
        cmbshelving.Text = ""
        cmbshelving.Items.Clear()
        strsql = "exec spMstShelvingdc 'get'," & idrak & ",-1,'%',0,'" & StrNamaUser & "'"
        RsConn = Conn.Execute(strsql)
        If Not RsConn.EOF Then
            RsConn.MoveFirst()
            Do While Not RsConn.EOF
                cmbshelving.Items.Add(RsConn("namashelving").Value)
                RsConn.MoveNext()
            Loop
        End If
    End Sub

    Private Sub TXTFIND_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTFIND.KeyPress
        If (e.KeyChar Like "[',]") Then e.Handled() = True
    End Sub

    Private Sub TXTFIND_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTFIND.TextChanged
        Call LoadDataKeGrid()
    End Sub

    Private Sub ListView2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView2.SelectedIndexChanged
        Dim z As Integer
        z = ListView2.SelectedItems.Count

        If z = 0 Then
            Exit Sub
        Else
            BtnEdit.Enabled = True
            btnclear.Enabled = True
            txtkode.Text = ListView2.SelectedItems.Item(0).SubItems(1).Text
            TxtNamabarang.Text = ListView2.SelectedItems.Item(0).SubItems(2).Text
            txtLine.Text = ListView2.SelectedItems.Item(0).SubItems(4).Text
            cmbrak.Text = ListView2.SelectedItems.Item(0).SubItems(3).Text
            cmbshelving.Text = ListView2.SelectedItems.Item(0).SubItems(5).Text
            txtKika.Text = ListView2.SelectedItems.Item(0).SubItems(6).Text
            txtab.Text = ListView2.SelectedItems.Item(0).SubItems(7).Text
            txtdb.Text = ListView2.SelectedItems.Item(0).SubItems(8).Text



        End If
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        flagedit = True
        Panel1.Enabled = True
        ListView2.Enabled = False
        BtnEdit.Enabled = False
        BtnSave.Enabled = True
        BtnPrint.Enabled = False
        BtnCancel.Enabled = True
    End Sub

    Private Sub BtnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click

        Dim result2 As DialogResult = MessageBox.Show("Simpan Perubahan Planogram ??", _
                "Question", _
                MessageBoxButtons.YesNo, _
                MessageBoxIcon.Question)
        If result2 = DialogResult.Yes Then

            If txtLine.Text = "" Or txtKika.Text = "" Or txtab.Text = "" Or txtdb.Text = "" Or cmbrak.Text = "" Or cmbshelving.Text = "" Then
                MsgBox("Data belum lengkap...!!", vbOKOnly + vbCritical, "Info")
                Exit Sub
            Else

                sql = "exec spMstPlanodc 'getPlano','" & TxtNamabarang.Text & "'," & idrak & "," & idshelving & "," & txtKika.Text & "," & txtdb.Text & "," & txtab.Text & ",'" & txtLine.Text & "',0,0,'" & StrNamaUser & "'"
                RsConfig = Conn.Execute(sql)
                If Not RsConfig.EOF Then
                    MsgBox("Plano sudah di pergunakan, silahkan cek kembali", vbOKOnly + vbCritical, "Info")
                    Exit Sub
                Else
                    sql = "exec spMstPlanodc 'add','" & TxtNamabarang.Text & "'," & idrak & "," & idshelving & "," & txtKika.Text & "," & txtdb.Text & "," & txtab.Text & ",'" & txtLine.Text & "',0,0,'" & StrNamaUser & "'"
                    Conn.Execute(sql)
                    Call LoadDataKeGrid()
                    ListView2.Enabled = True
                    Call pesan(3)
                    Call bersih()
                    BtnPrint.Enabled = True

                End If
            End If
        Else
            Exit Sub
        End If
    End Sub

    Private Sub CmbFilter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbFilter.SelectedIndexChanged
        Call LoadDataKeGrid()
    End Sub

    Private Sub cmbshelving_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbshelving.SelectedIndexChanged

    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Call bersih()
        Call LoadDataKeGrid()
        ListView2.Enabled = True
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Call cetak()
    End Sub

    Private Sub cetak()
        GetStringKoneksi()
        Dim Conn As New SqlConnection(ConnSQLClient)
        Dim dt As New DataTable


        If CmbFilter.Text = "Plano" Then
            sql = "exec spMstPlanoDc 'GetByRak','%" & strfind & "%',0,0,0,0,0,0,0,0,'" & StrNamaUser & "'"
        ElseIf CmbFilter.Text = "Non Plano" Then
            sql = "exec spMstPlanoDc 'GetNonRak','%" & strfind & "%',0,0,0,0,0,0,0,0,'" & StrNamaUser & "'"
        Else
            sql = "exec spMstPlanoDc 'get','%" & strfind & "%',0,0,0,0,0,0,0,0,'" & StrNamaUser & "'"
        End If

        Dim da As New SqlDataAdapter(sql, Conn)
        da.Fill(dt)

        Dim DataSetName As String = "DataSetPlanoDC"
        Dim DataTableName As String = "PlanoDC"
        Dim rds As New ReportDataSource(DataSetName, dt)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPerusahaan", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", "PLANOGRAM DC", True))
        paramList.Add(New ReportParameter("kodedc", kodedc, True))
        paramList.Add(New ReportParameter("NamaDC", namadc, True))

        Dim ReportViewerForm As New FrmReport
        ReportViewerForm.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptPlanoDC.rdlc"
        ReportViewerForm.ReportViewer1.LocalReport.SetParameters(paramList)
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewerForm.ReportViewer1.RefreshReport()
        ReportViewerForm.Show()
    End Sub

    Private Sub txtKika_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKika.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(Keys.Back))
    End Sub

    Private Sub txtab_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtab.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(Keys.Back))
    End Sub

    Private Sub txtdb_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdb.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(Keys.Back))
    End Sub

    

    Private Sub btnclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclear.Click
        Dim result2 As DialogResult = MessageBox.Show("Hapus lokasi planogram ??", _
              "Question", _
              MessageBoxButtons.YesNo, _
              MessageBoxIcon.Question)
        If result2 = DialogResult.Yes Then

            If cmbrak.Text = "" Or cmbshelving.Text = "" Or txtKika.Text = "" Or txtLine.Text = "" Then Exit Sub


            sql = "exec spMstPlanodc 'delete','" & TxtNamabarang.Text & "'," & idrak & "," & idshelving & "," & txtKika.Text & "," & txtdb.Text & "," & txtab.Text & ",'" & txtLine.Text & "',0,0,'" & StrNamaUser & "'"
            RsConfig = Conn.Execute(sql)
            Call LoadDataKeGrid()
            ListView2.Enabled = True
            Call pesan(3)
            Call bersih()
            BtnPrint.Enabled = True
        Else
            Exit Sub
        End If
    End Sub

    Private Sub txtLine_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLine.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(Keys.Back))
    End Sub


    Private Sub txtLine_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLine.TextChanged

    End Sub
End Class