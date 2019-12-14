Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Data.OleDb
Public Class FrmJWKSupplierByDC
    Dim Conn, ConnMDB As New ADODB.Connection
    Dim RsConn, RsMdb As New ADODB.Recordset
    Dim sql, namasup As String
    Dim flag, flagx As Boolean
    Dim idstatus, idctgr, idsup As Integer
    Dim senin, selasa, rabu, kamis, jumat, sabtu, minggu As Integer
    WithEvents bsData As New BindingSource

    Private Sub FrmJWKSupplierByDC_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        '  BtnFindSupp.Focus()
    End Sub
    Private Sub FrmJWKSupplierByDC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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
        Call namadcAktif()
        iddcjwk = IdDC
        TxtKdDC.Text = kodedc
        RtAlamat.Text = alamatdc
        TxtNamaDC.Text = namadc

        Call GbrTombol()
        BtnAdd.Enabled = True
        BtnEdit.Enabled = True
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
        DgJWK.Columns("Supplier").Width = 150
        For x As Int32 = 1 To 7
            DgJWK.Columns(x).Width = 60
        Next x
        DgJWK.AllowUserToAddRows = False

        If flag = False Then
            DgJWK.ReadOnly = True
        Else
            DgJWK.ReadOnly = False
        End If


    End Sub
    Private Sub kunci()
        flag = False
        TxtKdDC.Clear()
        TxtNamaDC.Clear()
        RtAlamat.Text = ""
        'txtLT.Clear()

        TxtKdDC.ReadOnly = True
        TxtKdDC.BackColor = Color.White
        TxtNamaDC.ReadOnly = True
        TxtNamaDC.BackColor = Color.White
        RtAlamat.ReadOnly = True
        RtAlamat.BackColor = Color.White
        'txtLT.ReadOnly = True
        'txtLT.BackColor = Color.White

        BtnAdd.Enabled = False
        BtnEdit.Enabled = False
        BtnCancel.Enabled = False
        BtnSave.Enabled = False
        BtnPrint.Enabled = False

        DgJWK.ReadOnly = True
    End Sub


    Private Sub TxtNamaDC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNamaDC.TextChanged
        If TxtNamaDC.Text = "" Then Exit Sub

        Call grid()
        BtnPrint.Enabled = True

    End Sub

    Function dc()

        Dim dt As New DataTable

        dt.Columns.Add(New DataColumn With {.ColumnName = "Identifier", .DataType = GetType(Int32), .ColumnMapping = MappingType.Hidden})
        dt.Columns.Add(New DataColumn With {.ColumnName = "kode", .DataType = GetType(String), .ColumnMapping = MappingType.Hidden})
        dt.Columns.Add(New DataColumn With {.ColumnName = "Supplier", .DataType = GetType(String)})

        Dim hari As String() = {"Senin", "Selasa", "Rabu", "Kamis", "Jum'at", "Sabtu", "Minggu"}
        Dim data As Object = {hari}
        For Each data In hari
            dt.Columns.Add(New DataColumn With {.ColumnName = data, .DataType = GetType(Boolean)})
        Next data

        If iddcjwk = 0 Then
            Exit Function

        Else

            sql = "exec spMstSupplierJwk 'getjwk'," & iddcjwk & "," & idctgr & ",1,0,0,0,0,0,0,0,1,'2017-01-01','2017-01-01'"
            RsConn = Conn.Execute(sql)
            If Not RsConn.EOF Then
                RsConn.MoveFirst()
                Do While Not RsConn.EOF
                    dt.Rows.Add(New Object() {RsConn("iddc").Value, RsConn("idKategoriSupplier").Value, RsConn("namadc").Value, RsConn("senin").Value, RsConn("selasa").Value, RsConn("rabu").Value, RsConn("kamis").Value, RsConn("jumat").Value, RsConn("sabtu").Value, RsConn("minggu").Value})
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

    Private Sub BtCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        BtnEdit.Enabled = True
        BtnCancel.Enabled = False
        BtnAdd.Enabled = True
        BtnSave.Enabled = False
        BtnPrint.Enabled = True
        Call grid()
        DgJWK.ReadOnly = True
    End Sub

    Private Sub BtSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Dim dt As DataTable = bsData.DataTable

        For Each row As DataRow In dt.Rows
            idsup = row.ItemArray(0)
            idctgr = row.ItemArray(1)
            namasup = row.ItemArray(2)
            If row.ItemArray(3) = True Then senin = 1 Else senin = 0
            If row.ItemArray(4) = True Then selasa = 1 Else selasa = 0
            If row.ItemArray(5) = True Then rabu = 1 Else rabu = 0
            If row.ItemArray(6) = True Then kamis = 1 Else kamis = 0
            If row.ItemArray(7) = True Then jumat = 1 Else jumat = 0
            If row.ItemArray(8) = True Then sabtu = 1 Else sabtu = 0
            If row.ItemArray(9) = True Then minggu = 1 Else minggu = 0


            sql = "exec spMstSupplierJwk 'addNew'," & iddcjwk & "," & idctgr & "," & idsup & "," & senin & "," & selasa & "," & rabu & "," & kamis & "," & jumat & "," & sabtu & "," & minggu & ",1,'2017-01-01','2017-01-01'"
            Conn.Execute(sql)
        Next

        Call pesan(3)
        Call grid()
        BtnEdit.Enabled = True
        BtnPrint.Enabled = True
        BtnAdd.Enabled = True
        BtnSave.Enabled = False
        BtnCancel.Enabled = False

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
                namasup = FrmFind.cari("JWKSupplierByDC")
                If namasup = "0" Then Exit Sub
                sql = "exec spMstSupplier 'getSupp',1,'S','" & namasup & "','Sinit',1,1,'11-2.00','jlnpwp','Ir.X',1,1,'1.1',7,1,1,'Norek','namarek',15,'2017-01-01',1,1000,1000000,1,1,1,1,1,1,1,'" & StrUserid & "','2017-01-01','2017-01-01',0"
                RsConn = Conn.Execute(sql)
                If Not RsConn.EOF Then
                    idsup = RsConn("idsupplier").Value
                    idctgr = RsConn("idKategoriSupplier").Value
                End If

                sql = " exec spMstSupplierPerDc  'getsupp'," & iddcjwk & "," & idsup & ",'" & RtAlamat.Text & "',0,0,0,0,'kdpos'" & _
                       ",'tlp','fax','email','cp','nocp',0" '
                RsConn = Conn.Execute(sql)

                If RsConn.EOF Then

                    sql = " exec spMstSupplierPerDc  'add'," & iddcjwk & ",'" & namasup & "','" & RtAlamat.Text & "'," & RsConn("idPropinsi").Value & "," & RsConn("idKabKota").Value & "," & RsConn("idKecamatan").Value & "," & RsConn("idKelurahan").Value & ",'" & RsConn("kodePos").Value & "'" & _
                       ",'" & RsConn("noTelephone").Value & "','" & RsConn("noFax").Value & "','" & RsConn("email").Value & "','" & RsConn("kontakPerson").Value & "','" & RsConn("noHp").Value & "'," & RsConn("idJabatan").Value
                    Conn.Execute(sql)

                End If


                'sql = "exec spMstSupplierJwk 'get'," & IdDC & "," & idctgr & "," & idsup & ",0,0,0,0,0,0,0,0,'2017-01-01','2017-01-01'"
                'RsConn = Conn.Execute(sql)
                'If RsConn.EOF Then
                sql = "exec spMstSupplierJwk 'addNew'," & IdDC & "," & idctgr & "," & idsup & ",0,0,0,0,0,0,0,0,'2017-01-01','2017-01-01'"
                Conn.Execute(sql)
                '  End If


                Call grid()

            End If
        End If
    End Sub


    Private Sub BtPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Call cetak()
    End Sub

    Private Sub cetak()
        GetStringKoneksi()
       
        Dim SQL = "exec spMstSupplierJwk 'getjwk'," & iddcjwk & "," & idctgr & ",1,0,0,0,0,0,0,0,1,'2017-01-01','2017-01-01'"
        Dim Conn As New SqlConnection(ConnSQLClient)
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter(SQL, Conn)
        da.Fill(dt)

        Dim DataSetName As String = "DataSetJWKBySupplier"
        Dim DataTableName As String = "TableJWKBySupplier"
        Dim rds As New ReportDataSource(DataSetName, dt)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", "JADWAL PO SUPPLIER", True))
        paramList.Add(New ReportParameter("Supplier", TxtKdDC.Text & " - " & TxtNamaDC.Text, True))

        Dim ReportViewerForm As New FrmReport
        ReportViewerForm.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptJWKBySupplier.rdlc"
        ReportViewerForm.ReportViewer1.LocalReport.SetParameters(paramList)
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewerForm.ReportViewer1.RefreshReport()
        ReportViewerForm.Show()
    End Sub

   
    Private Sub DgJWK_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgJWK.CellContentClick

    End Sub
End Class