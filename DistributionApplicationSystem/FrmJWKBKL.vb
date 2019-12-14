Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Data.OleDb
Public Class FrmJWKBKL
    Dim Conn, ConnMDB As New ADODB.Connection
    Dim RsConn, RsMdb As New ADODB.Recordset
    Dim sql, namasup As String
    Dim flag, flagx As Boolean
    Dim idstatus, kdtoko, idctgr, idsup As Integer
    Dim senin, selasa, rabu, kamis, jumat, sabtu, minggu As Integer
    WithEvents bsData As New BindingSource

    Private Sub FrmJWKBKL_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        BtnFindSupp.Focus()
    End Sub
    Private Sub FrmJWKBKL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        Call kunci()
        Call GbrTombol()
    End Sub
    Private Sub GbrTombol()
        Me.BtnAdd.Image = System.Drawing.Image.FromFile(icoadd)
        Me.BtnEdit.Image = System.Drawing.Image.FromFile(icoedit)
        Me.BtnCancel.Image = System.Drawing.Image.FromFile(icocancel)
        Me.BtnSave.Image = System.Drawing.Image.FromFile(icosave)
        Me.BtnPrint.Image = System.Drawing.Image.FromFile(icoprint)
    End Sub
    Private Sub grid()
        bsData.DataSource = dc()
        DgJWK.DataSource = bsData
        DgJWK.Columns("Kode").Width = 80
        DgJWK.Columns("Nama").Width = 150
        For x As Int32 = 2 To 8
            DgJWK.Columns(x).Width = 60
        Next x
        DgJWK.AllowUserToAddRows = False

        If flag = False Then
            DgJWK.ReadOnly = True
        Else
            DgJWK.ReadOnly = False
        End If


    End Sub

    Private Sub BtnFindSupp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFindSupp.Click
        TxtNamaSupp.Text = FrmFind.cari("MasterSupplierJWK")
        If TxtNamaSupp.Text = "0" Or TxtNamaSupp.Text = "" Then
            TxtNamaSupp.Clear()
            Exit Sub
        End If
    End Sub
    Private Sub kunci()
        flag = False
        TxtKdsupp.Clear()
        TxtNamaSupp.Clear()
        RtAlamat.Text = ""
        txtLT.Clear()

        TxtKdsupp.ReadOnly = True
        TxtKdsupp.BackColor = Color.White
        TxtNamaSupp.ReadOnly = True
        TxtNamaSupp.BackColor = Color.White
        RtAlamat.ReadOnly = True
        RtAlamat.BackColor = Color.White
        txtLT.ReadOnly = True
        txtLT.BackColor = Color.White

        BtnAdd.Enabled = False
        BtnEdit.Enabled = False
        BtnCancel.Enabled = False
        BtnSave.Enabled = False
        BtnPrint.Enabled = False
        Panel1.Enabled = True
        DgJWK.ReadOnly = True
        idsupjwk = 0
    End Sub

    Private Sub TxtNamaSupp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNamaSupp.TextChanged
        If TxtNamaSupp.Text = "" Then Exit Sub

        sql = "exec spMstSupplier 'GetSupp',1,'S','" & TxtNamaSupp.Text & "','Sinit',1,1,'11-2.00','jlnpwp','Ir.X',1,1,'1.1',7,1,1,'Norek','namarek',15,'2017-01-01',1,1000,1000000,1,1,1,1,1,1,1,'" & StrUserid & "','2017-01-01','2017-01-01',1"
        RsConn = Conn.Execute(sql)
        If Not RsConn.EOF Then

            idsupjwk = RsConn("idsupplier").Value
            idctgr = RsConn("idKategoriSupplier").Value
            TxtKdsupp.Text = RsConn("KodeSupplier").Value
            txtLT.Text = RsConn("leadtime").Value
            RtAlamat.Text = RsConn("alamatsupplier").Value
            BtnPrint.Enabled = True
            Call grid()
            BtnAdd.Enabled = True
            BtnEdit.Enabled = True
        End If
    End Sub

    Function dc()

        Dim dt As New DataTable

        dt.Columns.Add(New DataColumn With {.ColumnName = "Identifier", .DataType = GetType(Int32), .ColumnMapping = MappingType.Hidden})
        dt.Columns.Add(New DataColumn With {.ColumnName = "Kode", .DataType = GetType(String)})
        dt.Columns.Add(New DataColumn With {.ColumnName = "Nama", .DataType = GetType(String)})

        Dim hari As String() = {"Senin", "Selasa", "Rabu", "Kamis", "Jum'at", "Sabtu", "Minggu"}
        Dim data As Object = {hari}
        For Each data In hari
            dt.Columns.Add(New DataColumn With {.ColumnName = data, .DataType = GetType(Boolean)})
        Next data

        If idsupjwk = 0 Then
            Exit Function

        Else
            sql = "exec  spJwkTOkoKeSupplier 'getJWK',0,'B'," & idsupjwk & ",0,0,0,0,0,0,0,'" & StrNamaUser & "','2017-01-01','2017-01-01',1"
            RsConn = Conn.Execute(sql)
            If Not RsConn.EOF Then
                RsConn.MoveFirst()
                Do While Not RsConn.EOF
                    dt.Rows.Add(New Object() {RsConn("idsupplier").Value, RsConn("Kodetoko").Value, RsConn("namatoko").Value, RsConn("senin").Value, RsConn("selasa").Value, RsConn("rabu").Value, RsConn("kamis").Value, RsConn("jumat").Value, RsConn("sabtu").Value, RsConn("minggu").Value})
                    RsConn.MoveNext()
                Loop

            End If
        End If

        Return dt
    End Function

    Private Sub BtEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click

        DgJWK.ReadOnly = False
        BtnEdit.Enabled = False
        BtnCancel.Enabled = True
        BtnAdd.Enabled = False
        BtnSave.Enabled = True
        BtnPrint.Enabled = False
        flag = False

    End Sub

    Private Sub cektable()
        sql = "Select TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='JwkTOkoKeSupplierTmp'"
        RsConfig = Conn.Execute(sql)
        If RsConfig.EOF Then
            sql = "select top 0 * into JwkTOkoKeSupplierTmp from JwkTOkoKeSupplier "
            Conn.Execute(sql)
        End If
    End Sub


    Private Sub BtAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        flag = True
        BtnAdd.Enabled = False
        BtnPrint.Enabled = False
        BtnCancel.Enabled = True
        BtnEdit.Enabled = False
        BtnSave.Enabled = True
        'iddc = FrmFind.cari("JWKSupplierBySupp")
        Dim x As Integer = DgJWK.RowCount

        DgJWK.AllowUserToAddRows = True
        DgJWK.Select()
        ' DgJWK.CurrentCell = DgJWK(0, DgJWK.CurrentCell.RowIndex + 1)
        DgJWK.CurrentCell = DgJWK(0, x)

        DgJWK.ReadOnly = True

    End Sub

    Private Sub DgJWK_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DgJWK.KeyDown
        If e.KeyCode = Keys.Enter Then
            If DgJWK.CurrentCell.ColumnIndex = 0 Then
                kdtoko = FrmFind.cari("JwkBkl")
                If kdtoko = "0" Then
                    Call batal()
                    Exit Sub
                End If

                sql = "exec spJwkTOkoKeSupplier 'add'," & kdtoko & ",'B'," & idsupjwk & ",0,0,0,0,0,0,0,'" & StrNamaUser & "','2017-01-01','2017-01-01',1"
                Conn.Execute(sql)
                Call grid()
                Dim x As Integer = DgJWK.RowCount

                DgJWK.AllowUserToAddRows = True
                DgJWK.Select()
                DgJWK.CurrentCell = DgJWK(0, x)

            End If
        End If
    End Sub

    Private Sub BtSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Dim result2 As DialogResult = MessageBox.Show("Apakah perubahan JWK akan di simpan ?", _
             "Warning !!", _
             MessageBoxButtons.YesNo, _
             MessageBoxIcon.Question)
        If result2 = DialogResult.Yes Then
            Dim dt As DataTable = bsData.DataTable

            For Each row As DataRow In dt.Rows
                kdtoko = row.ItemArray(1)
                namasup = row.ItemArray(2)
                If row.ItemArray(3) = True Then senin = 1 Else senin = 0
                If row.ItemArray(4) = True Then selasa = 1 Else selasa = 0
                If row.ItemArray(5) = True Then rabu = 1 Else rabu = 0
                If row.ItemArray(6) = True Then kamis = 1 Else kamis = 0
                If row.ItemArray(7) = True Then jumat = 1 Else jumat = 0
                If row.ItemArray(8) = True Then sabtu = 1 Else sabtu = 0
                If row.ItemArray(9) = True Then minggu = 1 Else minggu = 0


                sql = "exec spJwkTOkoKeSupplier 'add'," & kdtoko & ",'B'," & idsupjwk & "," & senin & "," & selasa & "," & rabu & "," & kamis & "," & jumat & "," & sabtu & "," & minggu & ",'" & StrNamaUser & "','2017-01-01','2017-01-01',1"
                Conn.Execute(sql)
            Next

            Call pesan(3)
            Call grid()
            BtnEdit.Enabled = True
            BtnPrint.Enabled = True
            BtnAdd.Enabled = True
            BtnSave.Enabled = False
            BtnCancel.Enabled = False
            DgJWK.ReadOnly = True
        Else
            Exit Sub
        End If


    End Sub

    Private Sub BtCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Call batal()
    End Sub

    Private Sub batal()
        BtnEdit.Enabled = True
        BtnCancel.Enabled = False
        BtnAdd.Enabled = True
        BtnSave.Enabled = False
        BtnPrint.Enabled = True
        Call grid()
        DgJWK.ReadOnly = True
    End Sub


    Private Sub BtPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        If DgJWK.RowCount > 0 Then
            Call cetak()
        Else
            MsgBox("Tidak ada data untuk di cetak ..", vbOKOnly + vbInformation, "Info")
            Exit Sub
        End If

    End Sub


    Private Sub cetak()
        GetStringKoneksi()
        Dim Conn As New SqlConnection(ConnSQLClient)
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter("exec spJwkTOkoKeSupplier 'getJWK'," & kdtoko & ",'B'," & idsupjwk & "," & senin & "," & selasa & "," & rabu & "," & kamis & "," & jumat & "," & sabtu & "," & minggu & ",'" & StrNamaUser & "','2017-01-01','2017-01-01',1", Conn)
        da.Fill(dt)

        Dim DataSetName As String = "DataSetJWKBKL"
        Dim DataTableName As String = "JWKBKL"
        Dim rds As New ReportDataSource(DataSetName, dt)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", "JADWAL PO BKL SUPPLIER", True))
        paramList.Add(New ReportParameter("Supplier", TxtKdsupp.Text & " - " & TxtNamaSupp.Text, True))

        Dim ReportViewerForm As New FrmReport
        ReportViewerForm.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptJWKBKL.rdlc"
        ReportViewerForm.ReportViewer1.LocalReport.SetParameters(paramList)
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewerForm.ReportViewer1.RefreshReport()
        ReportViewerForm.Show()
    End Sub

   
    Private Sub TxtKdsupp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtKdsupp.TextChanged

    End Sub

    Private Sub DgJWK_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgJWK.CellContentClick

    End Sub
End Class