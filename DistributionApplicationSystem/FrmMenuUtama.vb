Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Data.OleDb
' tes buat jalan belakang layar
Imports System.ComponentModel
Public Class FrmMenuUtama
    Dim rscon, RsServer As New ADODB.Recordset
    Dim conn, ConnServer As New ADODB.Connection
    Dim sql As String
    Dim jam, menit, detik As Int64
    Dim frm As New Form
    Dim mulai As Boolean

    Private Sub FrmMenuUtama_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        'Application.DoEvents()

        '    If BackgroundWorker1.IsBusy <> True Then
        '        BackgroundWorker1.RunWorkerAsync()
        '    End If

        'If mulai = True Then
        '    Dim frmCollection = System.Windows.Forms.Application.OpenForms
        '    For i As Int16 = 0 To frmCollection.Count - 1
        '        If Not frmCollection.Item(i).Name = "frmMenuUtama" And Not frmCollection.Item(i).Name = "FrmKunci" Then
        '            frmCollection.Item(i).Close()
        '        End If
        '    Next i

        '    Dim frm As FrmKunci
        '    frm = New FrmKunci()
        '    frm.ShowDialog()
        '    frm.Select()
        '    frm.BringToFront()
        '    mulai = False

        'End If

    End Sub

    Private Sub FrmMenuUtama_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        sql = "exec spMstUser1022 'buka','" & StrNamaUser & "','x','x',1,'2017-01-01','2017-01-01',1,1"
        conn.Execute(sql)
        MsgBox("Terima Kasih", vbOKOnly + vbInformation, "Tigas")
        End
    End Sub

    Private Sub FrmMenuUtama_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mulai = False
        If conn.State = 0 Then
            GetStringKoneksi()
            conn.Open(StrKoneksi)
        End If

        GetServerDate()
        Call namadcAktif()
        Call NamaPerusahaan()
        Me.Text = "Warehouse and Distribution System ( WADS ) " & " - " & kodedc & " - " & namadc

        Me.BackgroundImage = System.Drawing.Image.FromFile(wp)

        strsql = "Select namauser,namagroupuser from MstUser a inner join MstUserGroup b on a.idGroupUser =b.idGroupUser  where IdUser='" & StrNamaUser & "'"
        rscon = conn.Execute(strsql)
        VarBagian = rscon("namagroupuser").Value

        Dim MyFileDate As String = IO.File.GetLastWriteTime(Application.ExecutablePath).ToShortDateString

        SSUtama.Items.Clear()
        SSUtama.Items.Add("User Name : " & StrUserid & "    ")
        SSUtama.Items.Add("Divisi : " & VarBagian & "    ")
        SSUtama.Items.Add("Tanggal Server: " & Format(tglserver, "dd-MMM-yyyy"))
        SSUtama.Items.Add("    Versi : " & System.Windows.Forms.Application.ProductVersion)
        SSUtama.Items.Add("   Server : " & StrDB)


    

    End Sub



    Private Sub ProsesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProsesToolStripMenuItem.Click
        Dim frm As FrmDraftUPO
        frm = New FrmDraftUPO()
        frm.ShowDialog()

    End Sub

    Private Sub EditDraftUPOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditDraftUPOToolStripMenuItem.Click
        Dim frm As FrmEditUPO
        frm = New FrmEditUPO()
        frm.ShowDialog()
    End Sub

    Private Sub RekapUPOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RekapUPOToolStripMenuItem.Click
        Dim frm As FrmRekapUPO
        frm = New FrmRekapUPO()
        frm.ShowDialog()
    End Sub

    Private Sub POOtomatisToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POOtomatisToolStripMenuItem.Click
        Dim frm As FrmPOOtomatis
        frm = New FrmPOOtomatis()
        frm.ShowDialog()
    End Sub

    Private Sub POManualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POManualToolStripMenuItem.Click
        Dim frm As FrmPOManual
        frm = New FrmPOManual()
        frm.ShowDialog()
    End Sub

    Private Sub PenerimaanBarangReturTokoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PenerimaanBarangReturTokoToolStripMenuItem.Click
        Dim frm As FrmLPBReturToko
        frm = New FrmLPBReturToko()
        frm.ShowDialog()
    End Sub
    Private Sub PenerimaanBarangSupplierLPBSuuplierToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PenerimaanBarangSupplierLPBSuuplierToolStripMenuItem.Click
        Dim frm As FrmLpbSupplier
        frm = New FrmLpbSupplier()
        frm.ShowDialog()

    End Sub

    Private Sub MaxDCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaxDCToolStripMenuItem.Click
        Dim frm As FrmMasterMaxDC
        frm = New FrmMasterMaxDC()
        frm.ShowDialog()
    End Sub

    Private Sub JWKBKLTokoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JWKBKLTokoToolStripMenuItem.Click

        Dim frm As FrmJWKBKL
        frm = New FrmJWKBKL()
        frm.ShowDialog()

    End Sub

    Private Sub JWKTokoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JWKTokoToolStripMenuItem1.Click
        Dim frm As FrmJWKToko
        frm = New FrmJWKToko()
        frm.ShowDialog()
    End Sub


    Private Sub MaxTokoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaxTokoToolStripMenuItem.Click
        Dim frm As FrmMstMaxToko
        frm = New FrmMstMaxToko()
        frm.ShowDialog()
    End Sub

    Private Sub MutasiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MutasiToolStripMenuItem.Click
        Dim frm As FrmMutasiStock
        frm = New FrmMutasiStock()
        frm.ShowDialog()
    End Sub

    Private Sub NRBSupplierToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NRBSupplierToolStripMenuItem.Click
        Dim frm As FrmLPBReturSupplier
        frm = New FrmLPBReturSupplier()
        frm.ShowDialog()
    End Sub


    Private Sub MasterTokoPOGOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As FrmTokoPOGO
        frm = New FrmTokoPOGO()
        frm.ShowDialog()
    End Sub


    Private Sub DraftPOGOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As FrmDraftPOGO
        frm = New FrmDraftPOGO()
        frm.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Dim frm As FrmMasterUser
        frm = New FrmMasterUser()
        frm.ShowDialog()
    End Sub


    Private Sub PlanogramDCToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlanogramDCToolStripMenuItem1.Click
        Dim frm As FrmPlanogramDC
        frm = New FrmPlanogramDC()
        frm.ShowDialog()
    End Sub

    Private Sub TransferAlokasiManualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransferAlokasiManualToolStripMenuItem.Click
        'Dim frm As FrmTOManual
        'frm = New FrmTOManual()
        Dim frm As FrmTOmanualNonScanner
        frm = New FrmTOmanualNonScanner
        frm.ShowDialog()
    End Sub

    Private Sub TransferOutToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As FrmTOfromPB
        frm = New FrmTOfromPB()
        frm.ShowDialog()
    End Sub

    Private Sub PDTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox("Under Construction", vbOKOnly + vbInformation, "Info")
    End Sub

    Private Sub PTLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox("Under Construction", vbOKOnly + vbInformation, "Info")
    End Sub

    Private Sub InputDataStockOpnameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InputDataStockOpnameToolStripMenuItem.Click
        Dim frm As FrmInputSO
        frm = New FrmInputSO()
        frm.ShowDialog()
    End Sub

    Private Sub LoackDataInventoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoackDataInventoryToolStripMenuItem.Click
        Dim frm As FrmLockSO
        frm = New FrmLockSO()
        frm.ShowDialog()
    End Sub

    Private Sub LPMPTokkToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As FrmRegisterLPMPToko
        frm = New FrmRegisterLPMPToko()
        frm.ShowDialog()
    End Sub
    Private Sub ProsesPBTokoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProsesPBTokoToolStripMenuItem.Click
        Dim frm As FrmPBToko
        frm = New FrmPBToko()
        frm.ShowDialog()
    End Sub

    Private Sub EntryShippingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EntryShippingToolStripMenuItem.Click
        'Dim frm As FrmTOfromPB
        'frm = New FrmTOfromPB()
        Dim frm As FrmTransferOut
        frm = New FrmTransferOut()
        frm.ShowDialog()
    End Sub

    Private Sub AdjustmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdjustmentToolStripMenuItem.Click
        Dim frm As FrmAdjustmentManual
        frm = New FrmAdjustmentManual()
        frm.ShowDialog()
    End Sub

    Private Sub GoodStockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GoodStockToolStripMenuItem.Click
        Call printStock("GOOD STOCK")
    End Sub

    Private Sub printStock(ByVal x As String)
        If conn.State = 0 Then
            GetStringKoneksi()
            conn.Open(StrKoneksi)
        End If

        Dim idstock As Integer
        sql = "exec spMstJenisStok 'GetID',0,'" & x & "','2017-01-01','2017-01-01','user',0"
        rscon = conn.Execute(sql)
        If Not rscon.EOF Then
            idstock = rscon("idJenisStok").Value
        End If

        sql = "exec spStokProdukDc 'Print'," & IdDC & ",0," & idstock & ",0,0,'2017-01-01','2017-01-01','x',1,1"
        Dim Conns As New SqlConnection(ConnSQLClient)
        Dim dt As New DataTable

        Dim da As New SqlDataAdapter(sql, Conns)
        da.Fill(dt)

        Dim DataSetName As String = "DataSetSOH"
        Dim DataTableName As String = "DataTableSOH"
        Dim rds As New ReportDataSource(DataSetName, dt)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", "Inventory DC", True))
        paramList.Add(New ReportParameter("DC", kodedc & "-" & namadc, True))
        paramList.Add(New ReportParameter("Jenis", x, True))

        Dim ReportViewerForm As New FrmReport
        ReportViewerForm.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptSOH.rdlc"
        ReportViewerForm.ReportViewer1.LocalReport.SetParameters(paramList)
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewerForm.ReportViewer1.RefreshReport()
        ReportViewerForm.Show()



    End Sub

    Private Sub BadStockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BadStockToolStripMenuItem.Click
        Call printStock("BAD STOCK")
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogOutToolStripMenuItem.Click
        sql = "exec spMstUser1022 'buka','" & StrNamaUser & "','x','x',1,'2017-01-01','2017-01-01',1,1"
        conn.Execute(sql)
        Me.Hide()
        FrmLogin.Show()
        FrmLogin.txtuser.Clear()
        FrmLogin.txtpass.Clear()
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Dim frm As FrmRegisterCode
        frm = New FrmRegisterCode()
        frm.ShowDialog()
    End Sub

    Private Sub TotalInventoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TotalInventoryToolStripMenuItem.Click
        sql = "exec spStokProdukDc 'PrintAll'," & IdDC & ",0,0,0,0,'2017-01-01','2017-01-01','x',1,1"

        Dim Conns As New SqlConnection(ConnSQLClient)
        Dim dt As New DataTable

        Dim da As New SqlDataAdapter(sql, Conns)
        da.Fill(dt)

        Dim DataSetName As String = "DataSetSOHAll"
        Dim DataTableName As String = "DataTableSOHAll"
        Dim rds As New ReportDataSource(DataSetName, dt)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", "Inventory DC", True))
        paramList.Add(New ReportParameter("DC", kodedc & "-" & namadc, True))
        paramList.Add(New ReportParameter("Jenis", "All SOH", True))

        Dim ReportViewerForm As New FrmReport
        ReportViewerForm.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptSOHAll.rdlc"
        ReportViewerForm.ReportViewer1.LocalReport.SetParameters(paramList)
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewerForm.ReportViewer1.RefreshReport()
        ReportViewerForm.Show()
    End Sub

    Private Sub LPMPDCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As FrmRegisterLPMPDC
        frm = New FrmRegisterLPMPDC()
        frm.ShowDialog()
    End Sub


    Private Sub JWKSupplierRegulerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JWKSupplierRegulerToolStripMenuItem.Click
        Dim frm As FrmJWKSupplierByDC
        frm = New FrmJWKSupplierByDC()
        frm.ShowDialog()
    End Sub

    Private Sub MasterRakToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MasterRakToolStripMenuItem.Click
        Dim frm As FrmMasterRak
        frm = New FrmMasterRak()
        frm.ShowDialog()
    End Sub

    Private Sub MasterShelvingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MasterShelvingToolStripMenuItem.Click
        Dim frm As FrmMasterShelving
        frm = New FrmMasterShelving()
        frm.ShowDialog()
    End Sub
    Private Sub ServiceLevelSupplierToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ServiceLevelSupplierToolStripMenuItem.Click
        Dim frm As FrmSLSupplier
        frm = New FrmSLSupplier()
        frm.ShowDialog()
    End Sub

    Private Sub ServiceLevelDCToStoreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ServiceLevelDCToStoreToolStripMenuItem.Click
        Dim frm As FrmSLDCToStore
        frm = New FrmSLDCToStore()
        frm.ShowDialog()
    End Sub

    Private Sub CreatePaketToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As FrmMutasiPaket
        frm = New FrmMutasiPaket()
        frm.ShowDialog()
    End Sub

    Private Sub UnPaketToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As FrmUnPaket
        frm = New FrmUnPaket()
        frm.ShowDialog()
    End Sub

    Private Sub TransferOutDCToStoreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransferOutDCToStoreToolStripMenuItem.Click
        Dim frm As FrmRegisterTOtoStore
        frm = New FrmRegisterTOtoStore()
        frm.ShowDialog()
    End Sub

   
    Private Sub StockReadyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockReadyToolStripMenuItem.Click
        sql = "exec spPrintSOHVirtual 'Cetak' ,'1'"

        Dim Conns As New SqlConnection(ConnSQLClient)
        Dim dt As New DataTable

        Dim da As New SqlDataAdapter(sql, Conns)
        da.Fill(dt)

        Dim DataSetName As String = "DataSetSOHReady"
        Dim DataTableName As String = "DataTableSOHReady"
        Dim rds As New ReportDataSource(DataSetName, dt)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", "Inventory DC", True))
        paramList.Add(New ReportParameter("DC", kodedc & "-" & namadc, True))
        paramList.Add(New ReportParameter("Jenis", "SOH Ready", True))

        Dim ReportViewerForm As New FrmReport
        ReportViewerForm.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptSOHReady.rdlc"
        ReportViewerForm.ReportViewer1.LocalReport.SetParameters(paramList)
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewerForm.ReportViewer1.RefreshReport()
        ReportViewerForm.Show()
    End Sub

    

    Private Sub AdjustmentReasonToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdjustmentReasonToolStripMenuItem.Click
        Dim frm As FrmAdjreason
        frm = New FrmAdjreason()
        frm.ShowDialog()
    End Sub

  
    Private Sub RRAKToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RRAKToolStripMenuItem1.Click
        Dim frm As FrmRRAK
        frm = New FrmRRAK()
        frm.txtjenis.Text = "RRAK"
        frm.ShowDialog()
    End Sub

    Private Sub KasBonToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As FrmRRAK
        frm = New FrmRRAK()
        frm.txtjenis.Text = "KAS"
        frm.ShowDialog()
    End Sub

    Private Sub DaySalesInventoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DaySalesInventoryToolStripMenuItem.Click
        Dim frm As FrmDSI
        frm = New FrmDSI()
        frm.ShowDialog()
    End Sub

    
    Private Sub TransferInDCFromStoreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransferInDCFromStoreToolStripMenuItem.Click
        Dim frm As FrmRegisterTOtoStore
        frm = New FrmRegisterTOtoStore()
        frm.Label1.Text = "TRANSFER IN DC FROM STORE"
        frm.ShowDialog()
    End Sub


    Private Sub StockOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockOutToolStripMenuItem.Click
        Dim frm As FrmOOS
        frm = New FrmOOS()
        frm.ShowDialog()
    End Sub

    Private Sub ReturSupplierToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReturSupplierToolStripMenuItem.Click
        Dim frm As FrmPrintReturSupplier
        frm = New FrmPrintReturSupplier()
        frm.ShowDialog()
    End Sub

    Private Sub POBKLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As FrmPOBKL
        frm = New FrmPOBKL()
        frm.ShowDialog()
    End Sub

    Private Sub InventoryMovementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InventoryMovementToolStripMenuItem.Click
        Dim frm As FrmStockMovement
        frm = New FrmStockMovement()
        frm.ShowDialog()
    End Sub

    Private Sub POBKLToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POBKLToolStripMenuItem.Click
        Dim frm As FrmPOBKLToko
        frm = New FrmPOBKLToko()
        frm.ShowDialog()
    End Sub

 
    Private Sub StockOpnameToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockOpnameToolStripMenuItem2.Click
        Dim frm As FrmRptSODC
        frm = New FrmRptSODC()
        frm.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        Dim frm As FrmRegisterTOtoStore
        frm = New FrmRegisterTOtoStore()
        frm.Label1.Text = "RETUR TOKO"
        frm.ShowDialog()
    End Sub

    Private Sub SalesTokoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesTokoToolStripMenuItem.Click
        Dim frm As FrmRPTSales
        frm = New FrmRPTSales()
        frm.ShowDialog()
    End Sub

    Private Sub InventoryDCDanTokoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InventoryDCDanTokoToolStripMenuItem.Click
        Dim frm As FrmRPTStockDCToko
        frm = New FrmRPTStockDCToko()
        frm.ShowDialog()

    End Sub

    Private Sub TransferKeDCLainToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransferKeDCLainToolStripMenuItem.Click
        Dim frm As FrmMutasiDcOut
        frm = New FrmMutasiDcOut()
        frm.ShowDialog()

    End Sub

    Private Sub MutasiInToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MutasiInToolStripMenuItem.Click
        Dim frm As FrmMutasiDCIn
        frm = New FrmMutasiDCIn()
        frm.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        Dim frm As FrmRptLogPatch
        frm = New FrmRptLogPatch()
        frm.ShowDialog()
    End Sub

   
    Private Sub SJTarikDataReturTokoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SJTarikDataReturTokoToolStripMenuItem.Click
        Dim frm As FrmSJReturToko
        frm = New FrmSJReturToko()
        frm.ShowDialog()
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        If ConnServer.State = 0 Then
            GetStringKoneksi()
            ConnServer.Open(StrKoneksi)
        End If

        sql = "SELECT DATENAME(HOUR, GETDATE()) AS 'Hour',DATENAME(MINUTE, GETDATE()) AS 'Minute',DATENAME(SECOND, GETDATE()) AS 'detik'"
        RsServer = ConnServer.Execute(sql)
        If Not RsServer.EOF Then
            jam = RsServer("Hour").Value
            menit = RsServer("Minute").Value
            detik = RsServer("detik").Value
        End If

    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If jam = 14 And menit = 2 And detik = 0 Then
            mulai = True

        End If

    End Sub

    Private Sub NonRRAKToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NonRRAKToolStripMenuItem.Click
        Dim frm As FrmNonRRAK
        frm = New FrmNonRRAK()
        frm.ShowDialog()
    End Sub


    Private Sub AnggaranKasTokoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnggaranKasTokoToolStripMenuItem.Click
        Dim frm As frmSumarynonrrak
        frm = New frmSumarynonrrak()
        frm.ShowDialog()
    End Sub


    Private Sub StockOpnameTokoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockOpnameTokoToolStripMenuItem.Click
        Dim frm As FrmRptSoToko
        frm = New FrmRptSoToko()
        frm.ShowDialog()
    End Sub

    Private Sub NotifikasiTokoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotifikasiTokoToolStripMenuItem.Click
        Dim frm As FrmNotifToko
        frm = New FrmNotifToko()
        frm.ShowDialog()
    End Sub

    Private Sub InventoryMovementCabangToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InventoryMovementCabangToolStripMenuItem.Click
        Dim frm As FrmInventoryMovementCabang
        frm = New FrmInventoryMovementCabang()
        frm.ShowDialog()
    End Sub

    Private Sub TransferInTokoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransferInTokoToolStripMenuItem.Click

        Dim frm As FrmRptTIToko
        frm = New FrmRptTIToko()
        frm.ShowDialog()
    End Sub

    Private Sub KartuStokTokoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KartuStokTokoToolStripMenuItem.Click
        Dim frm As FrmPrintKartuStok
        frm = New FrmPrintKartuStok()
        frm.ShowDialog()

    End Sub
End Class
