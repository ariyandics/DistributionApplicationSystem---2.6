Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Data.OleDb
Public Class FrmJWKSupplierBySupp
    Dim Conn, ConnMDB As New ADODB.Connection
    Dim RsConn, RsMdb As New ADODB.Recordset
    Dim sql, namadc As String
    Dim flag, flagx As Boolean
    Dim idstatus, iddc, idctgr As Integer
    Dim senin, selasa, rabu, kamis, jumat, sabtu, minggu As Integer
    WithEvents bsData As New BindingSource


    Private Sub FrmJWKSupplier_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        BtnFindSupp.Focus()
    End Sub

    Private Sub FrmJWKSupplier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Conn.State = 0 Then
            Call GetStringKoneksi()
            Conn.Open(StrKoneksi)
        End If

        Label1.Parent = PictureBox1
        Label1.BackColor = Color.Transparent
        Me.BackColor = Color.SkyBlue
        Me.BackgroundImage = System.Drawing.Image.FromFile(bg)
        PictureBox1.BackgroundImage = System.Drawing.Image.FromFile(atas)
        Me.Text = Label1.Text
        Me.Label1.Left = (Me.Width - Me.Label1.Width) / 2
        Me.Label1.Top = 9
        Call kunci()
        Call GbrTombol()
    End Sub

    Private Sub GbrTombol()
        Me.BtAdd.Image = System.Drawing.Image.FromFile(icoadd)
        Me.BtEdit.Image = System.Drawing.Image.FromFile(icoedit)
        Me.BtCancel.Image = System.Drawing.Image.FromFile(icocancel)
        Me.BtSave.Image = System.Drawing.Image.FromFile(icosave)
        Me.BtPrint.Image = System.Drawing.Image.FromFile(icoprint)
        Me.Text = NamaPT
    End Sub
    Private Sub grid()
        If idsupjwk = 0 Then Exit Sub

        bsData.DataSource = dc()
        DgJWK.DataSource = bsData
        DgJWK.Columns("DC").Width = 150
        For x As Int32 = 1 To 7
            DgJWK.Columns(x).Width = 60
        Next x
        DgJWK.AllowUserToAddRows = False

        If flag = False Then
            DgJWK.ReadOnly = True
        Else
            DgJWK.ReadOnly = False
            DgJWK.Columns(0).ReadOnly = True
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

        BtAdd.Enabled = False
        BtEdit.Enabled = False
        BtCancel.Enabled = False
        BtSave.Enabled = False
        BtPrint.Enabled = False

        DgJWK.ReadOnly = True
    End Sub

    Private Sub BtnFindSupp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFindSupp.Click
        TxtKdsupp.Clear()
        TxtNamaSupp.Clear()
        txtLT.Clear()
        RtAlamat.Clear()
        TxtNamaSupp.Text = FrmFind.cari("JWKSupplierDC")
    End Sub

    Private Sub TxtNamaSupp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNamaSupp.TextChanged
        If TxtNamaSupp.Text = "0" Or TxtNamaSupp.Text = "" Then
            TxtNamaSupp.Clear()
            Exit Sub
        End If
      
        sql = "exec spMstSupplier 'get',1,'S','" & TxtNamaSupp.Text & "','Sinit',1,1,'11-2.00','jlnpwp','Ir.X',1,1,'1.1',7,1,1,'Norek','namarek',15,'2017-01-01',1,1000,1000000,1,1,1,1,1,1,1,'" & StrUserid & "','x','2017-01-01',0,0,0,'x','x','x'"
        RsConn = Conn.Execute(sql)
        If Not RsConn.EOF Then

            idsupjwk = RsConn("idsupplier").Value
            idctgr = RsConn("idKategoriSupplier").Value
            TxtKdsupp.Text = RsConn("KodeSupplier").Value
            txtLT.Text = RsConn("leadtime").Value
            RtAlamat.Text = RsConn("alamatsupplier").Value


            Call grid()
            BtEdit.Enabled = True
            BtPrint.Enabled = True
            BtAdd.Enabled = True
        Else
            Call grid()
            BtAdd.Enabled = True
        End If


    End Sub

    Function dc()

        Dim dt As New DataTable

        dt.Columns.Add(New DataColumn With {.ColumnName = "Identifier", .DataType = GetType(Int32), .ColumnMapping = MappingType.Hidden})
        dt.Columns.Add(New DataColumn With {.ColumnName = "kode", .DataType = GetType(String), .ColumnMapping = MappingType.Hidden})
        dt.Columns.Add(New DataColumn With {.ColumnName = "DC", .DataType = GetType(String)})

        Dim hari As String() = {"Senin", "Selasa", "Rabu", "Kamis", "Jum'at", "Sabtu", "Minggu"}
        Dim data As Object = {hari}
        For Each data In hari
            dt.Columns.Add(New DataColumn With {.ColumnName = data, .DataType = GetType(Boolean)})
        Next data
        sql = "exec spMstSupplierJwk 'get'," & iddc & "," & idctgr & ",'" & TxtNamaSupp.Text & "'," & senin & "," & selasa & "," & rabu & "," & kamis & "," & jumat & "," & sabtu & "," & minggu
        RsConn = Conn.Execute(sql)
            If Not RsConn.EOF Then
                RsConn.MoveFirst()
                Do While Not RsConn.EOF
                    dt.Rows.Add(New Object() {RsConn("iddc").Value, RsConn("kodedc").Value, RsConn("namadc").Value, RsConn("senin").Value, RsConn("selasa").Value, RsConn("rabu").Value, RsConn("kamis").Value, RsConn("jumat").Value, RsConn("sabtu").Value, RsConn("minggu").Value})
                    RsConn.MoveNext()
                Loop

            End If
      
        Return dt
    End Function

    Private Sub BtEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtEdit.Click
        DgJWK.ReadOnly = False
        BtEdit.Enabled = False
        BtCancel.Enabled = True
        BtAdd.Enabled = False
        BtSave.Enabled = True
        BtPrint.Enabled = False
        flag = False
        DgJWK.Columns(0).ReadOnly = True
    End Sub

    Private Sub BtCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancel.Click

        BtEdit.Enabled = True
        BtCancel.Enabled = False
        BtAdd.Enabled = True
        BtSave.Enabled = False
        BtPrint.Enabled = True
        Call grid()
        DgJWK.ReadOnly = True
    End Sub

    Private Sub BtSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSave.Click
        Dim result2 As DialogResult = MessageBox.Show("Apakah perubahan JWK akan di simpan ?", _
            "Question !!", _
            MessageBoxButtons.YesNo, _
            MessageBoxIcon.Question)
        If result2 = DialogResult.Yes Then

            Dim dt As DataTable = bsData.DataTable

            For Each row As DataRow In dt.Rows

                iddc = row.ItemArray(0)
                If row.ItemArray(3) = True Then senin = 1 Else senin = 0
                If row.ItemArray(4) = True Then selasa = 1 Else selasa = 0
                If row.ItemArray(5) = True Then rabu = 1 Else rabu = 0
                If row.ItemArray(6) = True Then kamis = 1 Else kamis = 0
                If row.ItemArray(7) = True Then jumat = 1 Else jumat = 0
                If row.ItemArray(8) = True Then sabtu = 1 Else sabtu = 0
                If row.ItemArray(9) = True Then minggu = 1 Else minggu = 0


                sql = "exec spMstSupplierJwk 'add'," & iddc & "," & idctgr & ",'" & TxtNamaSupp.Text & "'," & senin & "," & selasa & "," & rabu & "," & kamis & "," & jumat & "," & sabtu & "," & minggu
                Conn.Execute(sql)
            Next

            Call pesan(3)
            Call grid()
            BtEdit.Enabled = True
            BtPrint.Enabled = True
            BtAdd.Enabled = True
            BtSave.Enabled = False
            BtCancel.Enabled = False
        End If
    End Sub

    Private Sub BtAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAdd.Click
        flag = True
        BtAdd.Enabled = False
        BtPrint.Enabled = False
        BtCancel.Enabled = True
        BtEdit.Enabled = False
        BtSave.Enabled = True
        'iddc = FrmFind.cari("JWKSupplierBySupp")
        Dim x As Integer = DgJWK.RowCount

        DgJWK.AllowUserToAddRows = True
        DgJWK.Select()
        ' DgJWK.CurrentCell = DgJWK(0, DgJWK.CurrentCell.RowIndex + 1)
        DgJWK.CurrentCell = DgJWK(0, x)

        DgJWK.ReadOnly = True

    End Sub

    Private Sub DgJWK_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgJWK.CellEndEdit
        DgJWK.Columns(0).ReadOnly = True
    End Sub


    Private Sub DgJWK_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DgJWK.KeyDown
        If e.KeyCode = Keys.Enter Then

            If DgJWK.CurrentCell.ColumnIndex = 0 Then
                namadc = FrmFind.cari("JWKSupplierBySupp")
                If namadc = "0" Then Exit Sub
                sql = "exec spMstDC 'get',1,1,'x','" & namadc & "','alamat',0,0,0,0,'kdpos','tlp',0,0,'luas',0,'" & StrNamaUser & "'"
                RsConn = Conn.Execute(sql)
                If Not RsConn.EOF Then
                    iddc = RsConn("iddc").Value
                End If

                sql = " exec spMstSupplierPerDc  'get'," & iddc & ",'" & TxtNamaSupp.Text & "','" & RtAlamat.Text & "',0,0,0,0,'kdpos'" & _
                       ",'tlp','fax','email','cp','nocp',0" '
                RsConn = Conn.Execute(sql)
                If RsConn.EOF Then

                    sql = " exec spMstSupplierPerDc  'add'," & iddc & ",'" & TxtNamaSupp.Text & "','" & RtAlamat.Text & "'," & RsConn("idPropinsi").Value & "," & RsConn("idKabKota").Value & "," & RsConn("idKecamatan").Value & "," & RsConn("idKelurahan").Value & ",'" & RsConn("kodePos").Value & "'" & _
                       ",'" & RsConn("noTelephone").Value & "','" & RsConn("noFax").Value & "','" & RsConn("email").Value & "','" & RsConn("kontakPerson").Value & "','" & RsConn("noHp").Value & "'," & RsConn("idJabatan").Value
                    Conn.Execute(sql)

                End If


                sql = "exec spMstSupplierJwk 'get'," & iddc & "," & idctgr & ",'" & TxtNamaSupp.Text & "',0,0,0,0,0,0,0"
                RsConn = Conn.Execute(sql)
                If Not RsConn.EOF Then
                    sql = "exec spMstSupplierJwk 'add'," & iddc & "," & idctgr & ",'" & TxtNamaSupp.Text & "'," & RsConn("Senin").Value & "," & RsConn("selasa").Value & "," & RsConn("rabu").Value & "," & RsConn("kamis").Value & "," & RsConn("jumat").Value & "," & RsConn("sabtu").Value & "," & RsConn("minggu").Value
                Else
                    sql = "exec spMstSupplierJwk 'add'," & iddc & "," & idctgr & ",'" & TxtNamaSupp.Text & "',0,0,0,0,0,0,0"
                End If
                Conn.Execute(sql)

                Call grid()
                DgJWK.ReadOnly = True
            End If
        End If
    End Sub


    Private Sub BtPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtPrint.Click
        Call cetak()
    End Sub

    Private Sub cetak()
        GetStringKoneksi()

        sql = "exec spMstSupplierJwk 'get'," & iddc & "," & idctgr & ",'" & TxtNamaSupp.Text & "',0,0,0,0,0,0,0"
        Dim Conn As New SqlConnection(ConnSQLClient)
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter(sql, Conn)
        da.Fill(dt)

        Dim DataSetName As String = "DataSetJWKBySupplier"
        Dim DataTableName As String = "TableJWKBySupplier"
        Dim rds As New ReportDataSource(DataSetName, dt)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", "JWK SUPPLIER", True))
        paramList.Add(New ReportParameter("Supplier", TxtKdsupp.Text & " - " & TxtNamaSupp.Text, True))

        Dim ReportViewerForm As New FrmReport
        ReportViewerForm.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptJWKBySupplier.rdlc"
        ReportViewerForm.ReportViewer1.LocalReport.SetParameters(paramList)
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewerForm.ReportViewer1.RefreshReport()
        ReportViewerForm.Show()
    End Sub

  
End Class