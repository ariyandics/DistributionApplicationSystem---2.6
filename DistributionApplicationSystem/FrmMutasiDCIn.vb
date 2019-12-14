Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Data.OleDb
Public Class FrmMutasiDCIn
    Dim Conn, ConnMDB As New ADODB.Connection
    Dim RsConn, RsMdb, rsconnx As New ADODB.Recordset
    Dim sql As String
    Dim barcode, plu, namaproduk As String
    Dim qty, hpp, pajak, subtotal, netto, ttlitem, ttlqty As Double
    Dim NoLpb As Long
    Dim flagFindNoLpb As Boolean
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand

    Private Sub FrmMutasiDCIn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        disable()
        Me.BtnAdd.Enabled = True
        Me.BtnFindNoLpb.Enabled = True
        Call GbrTombol()
    End Sub


    Private Sub GbrTombol()
        Me.BtnAdd.Image = System.Drawing.Image.FromFile(icoadd)
        Me.BtnCancel.Image = System.Drawing.Image.FromFile(icocancel)
        Me.BtnSave.Image = System.Drawing.Image.FromFile(icosave)
        Me.BtnPrint.Image = System.Drawing.Image.FromFile(icoprint)
    End Sub

    Private Sub BtnFindNoRetur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFindNoRetur.Click
        flagFindNoLpb = False
        If Me.TxtKodeToko.Text = "" And Me.TxtNamaToko.Text = "" Then
            MsgBox("Silahkan pilih DC Pengirim terlebih dahulu", vbInformation, "Perhatian")
            Exit Sub
        End If
        TxtNoReturToko.Text = FrmFind.cari("NoMutasiDCLain")
        If TxtNoReturToko.Text = "0" Then
            TxtNoReturToko.Text = ""
            BtnSave.Enabled = False
            Exit Sub
        End If
    End Sub

    Private Sub BtnFindToko_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFindToko.Click
        TxtNoReturToko.Text = ""
        TxtKodeToko.Text = FrmFind.cari("MasterDCAll")
        If TxtKodeToko.Text = "0" Then
            TxtKodeToko.Text = ""
            TxtNamaToko.Text = ""
            TxtNoReturToko.Text = ""
            Exit Sub
        End If
        sql = "exec spfind 'GetDC','" & TxtKodeToko.Text & "','x'"
        RsConn = Conn.Execute(sql)
        If Not RsConn.EOF Then
            TxtNamaToko.Text = RsConn("namadc").Value
            iddcpengirim = RsConn("iddc").Value
        End If

    End Sub

    Private Sub LoadDataDokumenReturToko()

        ListView1.Columns.Clear()
        ListView1.Items.Clear()
        ListView1.View = Windows.Forms.View.Details
        ListView1.GridLines = True
        ListView1.FullRowSelect = True


        ListView1.Columns.Add("Nomor", 50)
        ListView1.Columns.Add("SKU", 80)
        ListView1.Columns.Add("Description", 360)
        ListView1.Columns.Add("Qty", 80, HorizontalAlignment.Right)
        ListView1.Columns.Add("Cost", 100, HorizontalAlignment.Right)
        ListView1.Columns.Add("Total Rp.", 100, HorizontalAlignment.Right)
        ListView1.Columns.Add("Pajak", 100, HorizontalAlignment.Right)
        ListView1.Columns.Add("Netto", 100, HorizontalAlignment.Right)

        If flagFindNoLpb = True Then
            sql = "exec spMutasiDCHeaderin 'get'," & iddcpengirim & "," & IdDC & "," & Val(TxtNoReturToko.Text) & "," & Val(TxtNoLPB.Text) & ",0,0,0,0,0,'x','x',0"
        Else
            sql = "exec spMutasiDCHeaderin 'NoMutasi'," & iddcpengirim & "," & IdDC & "," & Val(TxtNoReturToko.Text) & ",0,0,0,0,0,0,'x','x',0"
        End If

        RsConn = Conn.Execute(sql)

        If Not RsConn.EOF Then
            Dim tglretur As Date = (RsConn("tglapprove").Value)
            Me.TxtTglRetur.Text = Format(tglretur, "dd-MM-yyyy")
            Me.TxtTotalItem.Text = Format(RsConn("ttlitem").Value, "#,##0")
            Me.TxtTotalQty.Text = Format(RsConn("ttlqty").Value, "#,##0")

            If flagFindNoLpb = True Then
                Me.TxtTotalRetur.Text = Format(RsConn("totalrpnet").Value, "#,##0.#")
                Me.TxtTglTerima.Text = Format(RsConn("TglLpb").Value, "dd-MM-yyyy HH:mm:ss")
                Me.TxtNoReturToko.Text = RsConn("nomutasi").Value
                Me.TxtUser.Text = RsConn("iduser").Value
                Me.TxtKodeToko.Text = RsConn("kodedc").Value
                Me.TxtNamaToko.Text = RsConn("namadc").Value
            Else
                Me.TxtTotalRetur.Text = Format(RsConn("totalRpNet").Value, "#,##0.#")
                Me.TxtUser.Text = StrNamaUser
            End If
            ttlitem = RsConn("ttlitem").Value
            ttlqty = RsConn("ttlqty").Value
            subtotal = RsConn("totalRpNet").Value

            RsConn.MoveFirst()
            Dim nomor As Integer = 1
            Do While Not RsConn.EOF


                Dim arr(11) As String
                Dim itm As ListViewItem
                arr(0) = nomor
                arr(1) = RsConn("kodeProduk").Value
                arr(2) = RsConn("namaPanjang").Value
                arr(3) = Format(RsConn("qty").Value, "#,##0")
                arr(4) = Format(RsConn("hppdc").Value, "#,##0.#")
                arr(5) = Format(RsConn("totalrp").Value, "#,##0.#")
                arr(6) = Format(RsConn("pajak").Value, "#,##0.#")
                arr(7) = Format(RsConn("subtotal").Value, "#,##0.#")
                itm = New ListViewItem(arr)
                ListView1.Items.Add(itm)
                nomor += 1
                RsConn.MoveNext()
            Loop

        End If

        RsConn.Close()
     
    End Sub
    Private Sub TxtNoReturToko_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNoReturToko.TextChanged
        If Me.TxtNoReturToko.Text = "" Then
            Exit Sub
        End If

        If flagFindNoLpb = False Then
            LoadDataDokumenReturToko()
            'GetTotalAvgDanNetto()
            Me.BtnSave.Enabled = True
        End If
    End Sub
    Private Sub GetNoLpb()

        sql = "exec spMutasiDCHeaderin 'cek'," & iddcpengirim & "," & IdDC & "," & TxtNoReturToko.Text & ",0," & ttlitem & "," & ttlqty & "," & subtotal & ",0," & subtotal & ",'x','" & StrNamaUser & "',1"
        RsConn = Conn.Execute(sql)
        If Not RsConn.EOF Then
            If RsConn("xx").Value > 0 Then

                MsgBox("Data belum selesai di download !!, silahkan tunggu hingga data sesuai", vbOKOnly + vbInformation, "Info")
                Exit Sub

            Else

                GetStringKoneksi()
                GetKoneksiSQLClient()
                sql = "exec spMutasiDCHeaderin 'Add'," & iddcpengirim & "," & IdDC & "," & TxtNoReturToko.Text & ",0," & ttlitem & "," & ttlqty & "," & subtotal & ",0," & subtotal & ",'x','" & StrNamaUser & "',1"
                cmd = New SqlCommand(sql, SQLConn)
                dr = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows Then
                    TxtNoLPB.Text = dr.Item("nomutasi")
                End If

                MsgBox("Data berhasil di terima dan menambah stok", vbInformation, "Sukses")
                Call disable()
                BtnFindNoLpb.Enabled = True
                BtnAdd.Enabled = True
                BtnPrint.Enabled = True
                Me.TxtTglTerima.Text = Format(Now, "dd-MM-yyyy")
            End If
        End If
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If MessageBox.Show("Apakah Mutasi dari DC lain akan di terima ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            GetNoLpb()
        End If
    End Sub

    Private Sub BtnFindNoLpb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFindNoLpb.Click
        Call bersih()
        TxtNoLPB.Text = FrmFind.cari("LoadLpbMutasi")
        If TxtNoLPB.Text = "0" Then
            TxtNoLPB.Text = ""
            BtnPrint.Enabled = False
            Call LoadDataDokumenReturToko()
            Exit Sub
        Else
            flagFindNoLpb = True
            LoadDataDokumenReturToko()
            BtnPrint.Enabled = True

        End If
    End Sub
    Private Sub disable()
        Me.BtnFindToko.Enabled = False
        Me.BtnFindNoRetur.Enabled = False
        Me.BtnFindNoLpb.Enabled = False
        Me.BtnCancel.Enabled = False
        Me.BtnSave.Enabled = False
        Me.BtnPrint.Enabled = False
        Me.BtnAdd.Enabled = False
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Call bersih()
        Call disable()
        Me.BtnCancel.Enabled = True
        Me.BtnFindToko.Enabled = True
        Me.BtnFindNoRetur.Enabled = True
        Me.BtnFindToko.Focus()
        flagFindNoLpb = False
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Call bersih()
        Call disable()
        LoadDataDokumenReturToko()
        Me.BtnAdd.Enabled = True
        Me.BtnFindNoLpb.Enabled = True
        Me.BtnFindNoLpb.Focus()
        flagFindNoLpb = False
    End Sub
    Private Sub bersih()
        Me.TxtKodeToko.Clear()
        Me.TxtNamaToko.Clear()
        Me.TxtNoReturToko.Clear()
        Me.TxtNoLPB.Clear()
        Me.TxtUser.Clear()
        Me.TxtTglRetur.Clear()
        Me.TxtTglTerima.Clear()
        Me.TxtTotalQty.Clear()
        Me.TxtTotalItem.Clear()
        Me.TxtTotalRetur.Clear()
        Me.TxtNoReturToko.Clear()
        Me.TxtNoLPB.Clear()

    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Call cetak()
    End Sub
    Private Sub cetak()
        Dim objConn As OleDbConnection
        Dim objCmd As OleDbCommand
        Dim objReader As OleDbDataReader
        Dim objDataSet As DataSet = New DataSetMutasi
        Dim strSQL, strCONN As String

        GetStringKoneksi() '---1
        strCONN = StrKoneksi '----2

        strSQL = "exec spMutasiDCHeaderin 'get'," & iddcpengirim & "," & IdDC & "," & Val(TxtNoReturToko.Text) & "," & Val(TxtNoLPB.Text) & ",0,0,0,0,0,'x','x',0"
        Conn.Execute(strSQL)

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
        rds.Name = "DataSetMutasi"
        rds.Value = objDataSet.Tables(0)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", "MUTASI ANTAR DC -IN", True))
        paramList.Add(New ReportParameter("NoFaktur", Me.TxtNoLPB.Text, True))
        paramList.Add(New ReportParameter("TglApprove", Me.TxtTglTerima.Text, True))
        paramList.Add(New ReportParameter("TtlItem", Me.TxtTotalItem.Text, True))
        paramList.Add(New ReportParameter("TtlQty", Me.TxtTotalQty.Text, True))
        paramList.Add(New ReportParameter("KodeDC", TxtKodeToko.Text, True))
        paramList.Add(New ReportParameter("NamaDC", TxtNamaToko.Text, True))

        Dim ReportViewerForm As New FrmReport
        ReportViewerForm.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptMutasiIN.rdlc"
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewerForm.ReportViewer1.LocalReport.SetParameters(paramList)
        ReportViewerForm.ReportViewer1.RefreshReport()
        ReportViewerForm.Show()

    End Sub

    Private Sub TxtKodeToko_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtKodeToko.TextChanged

    End Sub
End Class