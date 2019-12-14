Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Data.OleDb
Public Class FrmJWKToko
    Dim Conn, ConnMDB As New ADODB.Connection
    Dim RsConn, RsMdb As New ADODB.Recordset
    Dim sql, namasup As String
    Dim flag, flagx As Boolean
    Dim idstatus, kdtoko, idctgr, idsup As Integer
    Dim senin, selasa, rabu, kamis, jumat, sabtu, minggu As Integer
    WithEvents bsData As New BindingSource

    Private Sub FrmJWKToko_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        BtAdd.Focus()
    End Sub

    Private Sub FrmJWKToko_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Close()
    End Sub
    Private Sub FrmJWKToko_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Call atass()
    End Sub
    Private Sub atass()
        TxtKdsupp.Text = kodedc
        TxtNamaSupp.Text = namadc
        RtAlamat.Text = alamatdc
        Call grid()
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

    Private Sub kunci()
        flag = False
        TxtKdsupp.Clear()
        TxtNamaSupp.Clear()
        RtAlamat.Text = ""
        
        TxtKdsupp.ReadOnly = True
        TxtKdsupp.BackColor = Color.White
        TxtNamaSupp.ReadOnly = True
        TxtNamaSupp.BackColor = Color.White
        RtAlamat.ReadOnly = True
        RtAlamat.BackColor = Color.White
    
        BtAdd.Enabled = True
        BtEdit.Enabled = True
        BtCancel.Enabled = False
        BtSave.Enabled = False
        BtPrint.Enabled = True
        Panel1.Enabled = True
        DgJWK.ReadOnly = True
        idsupjwk = 0
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

        If TxtKdsupp.Text = "" Then
            Exit Function
        Else
            sql = "exec spJwkTOkoKeDC 'get','%" & txtNamaToko.Text & "%','R',0,0,0,0,0,0,0,'" & StrNamaUser & "'"
            RsConn = Conn.Execute(sql)
            If Not RsConn.EOF Then
                RsConn.MoveFirst()
                Do While Not RsConn.EOF
                    dt.Rows.Add(New Object() {IdDC, RsConn("Kodetoko").Value, RsConn("namatoko").Value, RsConn("senin").Value, RsConn("selasa").Value, RsConn("rabu").Value, RsConn("kamis").Value, RsConn("jumat").Value, RsConn("sabtu").Value, RsConn("minggu").Value})
                    RsConn.MoveNext()
                Loop

            End If


            Return dt
        End If
       
    End Function

    Private Sub BtEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtEdit.Click
        DgJWK.ReadOnly = False
        BtEdit.Enabled = False
        BtCancel.Enabled = True
        BtAdd.Enabled = False
        BtSave.Enabled = True
        BtPrint.Enabled = False
        flag = False

    End Sub

    Private Sub cektable()
        sql = "Select TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='JwkTOkoKeDCTMP'"
        RsConfig = Conn.Execute(sql)
        If RsConfig.EOF Then
            sql = "select top 0 * into JwkTOkoKeDCTMP from JwkTOkoKeDC "
            Conn.Execute(sql)
        End If
    End Sub

    Private Sub BtAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAdd.Click
        flag = True
        BtAdd.Enabled = False
        BtPrint.Enabled = False
        BtCancel.Enabled = True
        BtEdit.Enabled = False
        BtSave.Enabled = True

        Dim x As Integer = DgJWK.RowCount

        DgJWK.AllowUserToAddRows = True
        DgJWK.Select()
        DgJWK.CurrentCell = DgJWK(0, x)
        DgJWK.ReadOnly = True

    End Sub

    Private Sub DgJWK_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DgJWK.KeyDown
        If e.KeyCode = Keys.Enter Then
            If DgJWK.CurrentCell.ColumnIndex = 0 And BtAdd.Enabled = False Then
                namasup = FrmFind.cari("JWKBklToko")
                If namasup = "0" Then
                    Call batal()
                    Exit Sub
                End If

                sql = "exec spJwkTOkoKeDC 'add','" & namasup & "','R',0,0,0,0,0,0,0,'" & StrNamaUser & "'"
                Conn.Execute(sql)

                Call grid()
                Dim x As Integer = DgJWK.RowCount

                DgJWK.AllowUserToAddRows = True
                DgJWK.Select()
                DgJWK.CurrentCell = DgJWK(0, x)


            End If
        End If
    End Sub

    Private Sub BtSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSave.Click
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


                sql = "exec spJwkTOkoKeDC 'add','" & namasup & "','R'," & senin & "," & selasa & "," & rabu & "," & kamis & "," & jumat & "," & sabtu & "," & minggu & ",'" & StrNamaUser & "'"
                Conn.Execute(sql)
            Next

            Call pesan(3)
            Call grid()
            BtEdit.Enabled = True
            BtPrint.Enabled = True
            BtAdd.Enabled = True
            BtSave.Enabled = False
            BtCancel.Enabled = False
            DgJWK.ReadOnly = True
        Else
            Exit Sub
        End If


    End Sub

    Private Sub BtCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancel.Click
        Call batal()
    End Sub
    Private Sub batal()
        BtEdit.Enabled = True
        BtCancel.Enabled = False
        BtAdd.Enabled = True
        BtSave.Enabled = False
        BtPrint.Enabled = True
        Call grid()
        DgJWK.ReadOnly = True
    End Sub

    Private Sub BtPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtPrint.Click
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
        Dim da As New SqlDataAdapter("exec spJwkTOkoKeDC 'get','%" & txtNamaToko.Text & "%','R',0,0,0,0,0,0,0,'" & StrNamaUser & "'", Conn)
        da.Fill(dt)

        Dim DataSetName As String = "DataSetJWKBKL"
        Dim DataTableName As String = "JWKBKL"
        Dim rds As New ReportDataSource(DataSetName, dt)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", "JWK PICKING DC", True))
        paramList.Add(New ReportParameter("Supplier", TxtKdsupp.Text & " - " & TxtNamaSupp.Text, True))

        Dim ReportViewerForm As New FrmReport
        ReportViewerForm.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptJWKBKL.rdlc"
        ReportViewerForm.ReportViewer1.LocalReport.SetParameters(paramList)
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewerForm.ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewerForm.ReportViewer1.RefreshReport()
        ReportViewerForm.Show()
    End Sub


    Private Sub txtNamaToko_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNamaToko.KeyPress
        If (e.KeyChar Like "[',]") Then e.Handled() = True
    End Sub

    Private Sub txtNamaToko_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNamaToko.TextChanged
        Call grid()
    End Sub

    Private Sub DgJWK_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgJWK.CellContentClick

    End Sub
End Class