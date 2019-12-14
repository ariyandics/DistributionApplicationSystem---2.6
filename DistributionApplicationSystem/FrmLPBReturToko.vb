﻿Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Data.OleDb
Public Class FrmLPBReturToko
    Dim Conn, ConnMDB As New ADODB.Connection
    Dim RsConn, RsMdb, rsconnx As New ADODB.Recordset
    Dim sql As String
    Dim barcode, plu, namaproduk As String
    Dim qty, hpp, pajak, subtotal, netto, qtybs, qtygs As Double
    Dim C1, C2 As Int16
    Dim NoLpb As Long
    Dim flagFindNoLpb As Boolean
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand
    Private Sub FrmLPBReturToko_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            MsgBox("Silahkan pilih toko terlebih dahulu", vbInformation, "Perhatian")
            Exit Sub
        End If
        TxtNoReturToko.Text = FrmFind.cari("LoadNomorReturToko")
        If TxtNoReturToko.Text = "0" Then
            TxtNoReturToko.Text = ""
            BtnSave.Enabled = False
            Exit Sub
        End If

    End Sub


    Private Sub BtnFindToko_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFindToko.Click
        TxtKodeToko.Text = FrmFind.cari("MasterToko")
        If TxtKodeToko.Text = "0" Then
            TxtKodeToko.Text = ""
            Exit Sub
        End If
        kodetoko = TxtKodeToko.Text
        Call gettoko(kodetoko)
        TxtNamaToko.Text = namatoko

    End Sub

    Private Sub LoadDataDokumenReturToko()

        'If Me.TxtNoReturToko.Text = "" Then
        '    Exit Sub
        'End If
        ListView1.Columns.Clear()
        ListView1.Items.Clear()
        ListView1.View = Windows.Forms.View.Details
        ListView1.GridLines = True
        ListView1.FullRowSelect = True


        ListView1.Columns.Add("Nomor", 50)
        ListView1.Columns.Add("Barcode", 0)
        ListView1.Columns.Add("SKU", 80)
        ListView1.Columns.Add("Description", 300)
        ListView1.Columns.Add("Qty", 80, HorizontalAlignment.Right)
        ListView1.Columns.Add("Cost", 100, HorizontalAlignment.Right)
        ListView1.Columns.Add("Netto", 100, HorizontalAlignment.Right)
        ListView1.Columns.Add("Qty BS", 80, HorizontalAlignment.Right)
        ListView1.Columns.Add("Qty GS", 80, HorizontalAlignment.Right)
        ListView1.Columns.Add("Keterangan", 200)

        If flagFindNoLpb = True Then
            sql = "exec spLpbDariTokoHeaderDetail 'LoadDataLpb',0," & Val(Me.TxtNoLPB.Text) & ",0,0,'" & StrNamaUser & "'"
        Else
            sql = "exec spLpbDariTokoHeaderDetail 'LoadDataReturToko',0,0," & Val(Me.TxtKodeToko.Text) & "," & Val(Me.TxtNoReturToko.Text) & ",'" & StrNamaUser & "'"

        End If

        RsConn = Conn.Execute(sql)

        If Not RsConn.EOF Then
            Dim tglretur As Date = (RsConn("tglRetur").Value)
            Me.TxtTglRetur.Text = Format(tglretur, "dd-MM-yyyy")
            Me.TxtTotalItem.Text = Format(RsConn("totalItem").Value, "#,##0")
            Me.TxtTotalQty.Text = Format(RsConn("totalQty").Value, "#,##0")
            Me.TxtTotalQtyBS.Text = Format(RsConn("totalQtyBs").Value, "#,##0")
            Me.TxtTotalQtyGS.Text = Format(RsConn("totalQtyGs").Value, "#,##0")
            If flagFindNoLpb = True Then
                Me.TxtTotalRetur.Text = Format(RsConn("totalRpLpb").Value, "#,##0.#")
                Me.TxtTglTerima.Text = Format(RsConn("TglLpb").Value, "dd-MM-yyyy HH:mm:ss")
                Me.TxtNoReturToko.Text = RsConn("nomorretur").Value
                Me.TxtUser.Text = RsConn("iduser").Value
                Me.TxtKodeToko.Text = RsConn("kodetoko").Value
                Me.TxtAvgCost.Text = Format(RsConn("hpp").Value, "#,##0.#")
                Me.TxtNetto.Text = Format(RsConn("netto").Value, "#,##0.#")
            Else
                Me.TxtTotalRetur.Text = Format(RsConn("totalRpRetur").Value, "#,##0.#")
                Me.TxtUser.Text = StrNamaUser
            End If


            RsConn.MoveFirst()
            Dim nomor As Integer = 1
            Do While Not RsConn.EOF


                Dim arr(11) As String
                Dim itm As ListViewItem
                arr(0) = nomor
                arr(1) = RsConn("barcode").Value
                arr(2) = RsConn("kodeProduk").Value
                arr(3) = RsConn("namaPanjang").Value
                arr(4) = Format(RsConn("qty").Value, "#,##0")
                arr(5) = Format(RsConn("hpp").Value, "#,##0.#")
                arr(6) = Format(RsConn("netto").Value, "#,##0.#")
                arr(7) = Format(RsConn("QtyBS").Value, "#,##0")
                arr(8) = Format(RsConn("QtyGs").Value, "#,##0")
                arr(9) = RsConn("namaretur").Value
                itm = New ListViewItem(arr)
                ListView1.Items.Add(itm)
                nomor += 1
                RsConn.MoveNext()
            Loop

        End If

        RsConn.Close()
        If TxtKodeToko.Text <> "" Then
            gettoko(TxtKodeToko.Text)
            TxtNamaToko.Text = namatoko
        End If

    End Sub

    Private Sub GetTotalAvgDanNetto()
        If Me.TxtNoReturToko.Text = "" Then
            Exit Sub
        End If
        sql = "exec spLpbDariTokoHeaderDetail 'GetAvgDanNetto',0,0," & TxtKodeToko.Text & "," & Me.TxtNoReturToko.Text & ",'" & StrNamaUser & "'"
        RsConn = Conn.Execute(sql)
        If Not RsConn.EOF Then
            If IsDBNull(RsConn("TotAvg").Value) Then
                Me.TxtAvgCost.Text = ""
            ElseIf IsDBNull(RsConn("TotNetto").Value) Then
                Me.TxtNetto.Text = 0
            Else
                Me.TxtAvgCost.Text = Format(RsConn("TotAvg").Value, "#,##0.#")
                Me.TxtNetto.Text = Format(RsConn("TotNetto").Value, "#,##0.#")
            End If

        End If
    End Sub


    Private Sub TxtNoReturToko_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNoReturToko.TextChanged
        If Me.TxtNoReturToko.Text = "" Then
            Exit Sub
        End If

        If flagFindNoLpb = False Then
            LoadDataDokumenReturToko()
            GetTotalAvgDanNetto()
            Me.BtnSave.Enabled = True
        End If
    End Sub

    Private Sub GetNoLpb()
        If Conn.State = 0 Then
            Call GetStringKoneksi()
            Conn.Open(StrKoneksi)
        End If

    
        Call namadcAktif()

        GetStringKoneksi()
        GetKoneksiSQLClient()
        sql = "exec spLpbDariTokoHeaderDetail 'Add'," & IdDC & "," & NoLpb & "," & Me.TxtKodeToko.Text & "," & Me.TxtNoReturToko.Text & ",'" & StrNamaUser & "'"
        cmd = New SqlCommand(sql, SQLConn)
        cmd.CommandTimeout = 7200
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            If dr.Item("statusproses") = 0 Then
                MsgBox(dr.Item("pesan"), vbOKOnly + vbInformation, "Simpan data Gagal")
                Exit Sub
            Else
                MsgBox(dr.Item("pesan"), vbOKOnly + vbInformation, "Simpan data Berhasil")
                Me.TxtNoLPB.Text = (dr.Item("NoTO"))
            End If
        End If
        dr.Close()

        Call disable()
        BtnFindNoLpb.Enabled = True
        BtnAdd.Enabled = True
        BtnPrint.Enabled = True
        Me.TxtTglTerima.Text = Format(Now, "dd-MM-yyyy")
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If MessageBox.Show("Apakah Retur dari toko akan di terima ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            GetNoLpb()

        End If
    End Sub

    Private Sub BtnFindNoLpb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFindNoLpb.Click
        Call bersih()
        TxtNoLPB.Text = FrmFind.cari("LoadNomerLpb")
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
        Me.TxtTotalQtyBS.Clear()
        Me.TxtTotalQtyGS.Clear()
        Me.TxtTotalItem.Clear()
        Me.TxtAvgCost.Clear()
        Me.TxtTotalRetur.Clear()
        Me.TxtNetto.Clear()
        Me.TxtNoReturToko.Clear()
        Me.TxtNoLPB.Clear()

    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        If BtnSave.Enabled = True Then
            Call cetakSJ()
        Else
            Call cetak()
        End If

    End Sub

    Private Sub cetak()
        Dim objConn As OleDbConnection
        Dim objCmd As OleDbCommand
        Dim objReader As OleDbDataReader
        Dim objDataSet As DataSet = New DataSetNRBtoko
        Dim strSQL, strCONN As String

        GetStringKoneksi() '---1
        strCONN = StrKoneksi '----2

        strSQL = "exec spLpbDariTokoHeaderDetail 'Print'," & IdDC & "," & Me.TxtNoLPB.Text & "," & Me.TxtKodeToko.Text & "," & Me.TxtNoReturToko.Text & ",'" & StrNamaUser & "'"
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
        rds.Name = "DataSetNRBToko"
        rds.Value = objDataSet.Tables(0)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", "LPB RETUR TOKO", True))
        paramList.Add(New ReportParameter("KodeToko", Me.TxtKodeToko.Text, True))
        paramList.Add(New ReportParameter("NamaToko", Me.TxtNamaToko.Text, True))
        paramList.Add(New ReportParameter("NoRetur", Me.TxtNoReturToko.Text, True))
        paramList.Add(New ReportParameter("TglRetur", Me.TxtTglRetur.Text, True))
        paramList.Add(New ReportParameter("NamaDC", namadc, True))
        paramList.Add(New ReportParameter("NoLPB", Me.TxtNoLPB.Text, True))
        paramList.Add(New ReportParameter("TglTerima", Me.TxtTglTerima.Text, True))
        paramList.Add(New ReportParameter("Penerima", Me.TxtUser.Text, True))
        paramList.Add(New ReportParameter("TtlItem", Me.TxtTotalItem.Text, True))
        paramList.Add(New ReportParameter("GS", Me.TxtTotalQtyGS.Text, True))
        paramList.Add(New ReportParameter("BS", Me.TxtTotalQtyBS.Text, True))
        ' paramList.Add(New ReportParameter("KodeDC", kodedc, True))
        paramList.Add(New ReportParameter("NamaDC", namadc, True))
       
        Dim ReportViewerForm As New FrmReport
        ReportViewerForm.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptLPBReturToko.rdlc"
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewerForm.ReportViewer1.LocalReport.SetParameters(paramList)
        ReportViewerForm.ReportViewer1.RefreshReport()
        ReportViewerForm.Show()

    End Sub


    Private Sub cetakSJ()
        Dim objConn As OleDbConnection
        Dim objCmd As OleDbCommand
        Dim objReader As OleDbDataReader
        Dim objDataSet As DataSet = New DataSetNRBtoko
        Dim strSQL, strCONN As String

        GetStringKoneksi() '---1
        strCONN = StrKoneksi '----2

        strSQL = "exec spLpbDariTokoHeaderDetail 'Print'," & IdDC & "," & Me.TxtNoReturToko.Text & "," & Me.TxtKodeToko.Text & "," & Me.TxtNoReturToko.Text & ",'" & StrNamaUser & "'"
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
        rds.Name = "DataSetNRBToko"
        rds.Value = objDataSet.Tables(0)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", "Surat Penarikan Barang di Toko", True))
        paramList.Add(New ReportParameter("KodeToko", Me.TxtKodeToko.Text, True))
        paramList.Add(New ReportParameter("NamaToko", Me.TxtNamaToko.Text, True))
        paramList.Add(New ReportParameter("NoRetur", Me.TxtNoReturToko.Text, True))
        paramList.Add(New ReportParameter("TglRetur", Me.TxtTglRetur.Text, True))
        paramList.Add(New ReportParameter("NamaDC", namadc, True))
        paramList.Add(New ReportParameter("NoLPB", Me.TxtNoLPB.Text, True))
        paramList.Add(New ReportParameter("TglTerima", Me.TxtTglTerima.Text, True))
        paramList.Add(New ReportParameter("Penerima", Me.TxtUser.Text, True))
        paramList.Add(New ReportParameter("TtlItem", Me.TxtTotalItem.Text, True))
        paramList.Add(New ReportParameter("GS", Me.TxtTotalQtyGS.Text, True))
        paramList.Add(New ReportParameter("BS", Me.TxtTotalQtyBS.Text, True))
        ' paramList.Add(New ReportParameter("KodeDC", kodedc, True))
        paramList.Add(New ReportParameter("NamaDC", namadc, True))

        Dim ReportViewerForm As New FrmReport
        ReportViewerForm.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptLPBReturToko.rdlc"
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewerForm.ReportViewer1.LocalReport.SetParameters(paramList)
        ReportViewerForm.ReportViewer1.RefreshReport()
        ReportViewerForm.Show()

    End Sub
End Class