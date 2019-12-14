Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Data.OleDb
Public Class FrmPrintKartuStok
    Dim nmTko As String
    Dim idPrd As Integer
    Private Sub FrmPrintKartuStok_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.RptKSToko.Reset()
        Me.RptKSToko.RefreshReport()
    End Sub
    Private Sub FrmPrintKartuStok_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Parent = PictureBox1
        'GroupBox1.Parent = PictureBox1
        GroupBox2.Parent = PictureBox1
        'GroupBox3.Parent = PictureBox1
        GroupBox4.Parent = PictureBox1
        Label1.BackColor = Color.Transparent
        Me.BackColor = Color.SkyBlue
        Me.BackgroundImage = System.Drawing.Image.FromFile(bg)
        PictureBox1.BackgroundImage = System.Drawing.Image.FromFile(atas)
        Me.Text = NamaPT

        Me.Label1.Left = (Me.Width - Me.Label1.Width) / 2
        Me.Label1.Top = 9


        'cmbFilter.Items.Clear()
        'cmbFilter.Items.Add("All")
        'cmbFilter.Items.Add("Store")
        'BtnFindStore.Enabled = False
        'btFindProduk.Enabled = False
    End Sub


    Private Sub BtnProses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProses.Click
        Call proses()
    End Sub

    Private Sub proses()
        If Tgl1.Value.Date > Tgl2.Value.Date Then
            MsgBox("Periode awal salah !!!", vbOKOnly + vbCritical, "Info")
            Exit Sub
        End If

        If TxtKodeToko.Text = "" Then
            MsgBox("Silahkan Pilih Toko terlebih dahulu...!!", vbOKOnly + vbInformation, "Info")
            BtnFindStore.Focus()
            Exit Sub
        End If

        If txtkdProduk.Text = "" Then
            MsgBox("Silahkan Pilih Toko terlebih dahulu...!!", vbOKOnly + vbInformation, "Info")
            btFindProduk.Focus()
            Exit Sub
        End If

        Call InsertKartuStok()

    End Sub
    Private Sub InsertKartuStok()
        Dim x1 As DateTime
        Dim y, thn, bln, tgl, jam, menit, detik, TglAktifitas As String

        Dim x As New ADODB.Recordset
        If x.State = 1 Then x.Close()
        x.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Dim xStr As String = "exec spKartuStok 'GetData','2019-01-01','','',0,0,0,'" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'," & TxtKodeToko.Text & "," & idPrd & ""
        x.Open(xStr, connDc, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        With x
            If Not .EOF Then
                Do Until .EOF

                    x1 = .Fields!tanggal.Value
                    y = FormatDateTime(x1, DateFormat.ShortDate)

                    thn = DatePart(DateInterval.Year, .Fields!tanggal.Value)
                    bln = DatePart(DateInterval.Month, .Fields!tanggal.Value)
                    tgl = DatePart(DateInterval.Day, .Fields!tanggal.Value)

                    jam = DatePart(DateInterval.Hour, .Fields!tanggal.Value)
                    menit = DatePart(DateInterval.Minute, .Fields!tanggal.Value)
                    detik = DatePart(DateInterval.Second, .Fields!tanggal.Value)

                    TglAktifitas = thn & "/" & bln & "/" & tgl & " " & jam & ":" & menit & ":" & detik


                    Application.DoEvents()
                    Dim xx As String = "exec spKartuStok 'InsertDataTemp','" & TglAktifitas & "','" & .Fields!NomorTransaksi.Value & "','" & .Fields!Keterangan.Value & "'," & Replace(.Fields!Masuk.Value, ",", ".") & "," & Replace(.Fields!Keluar.Value, ",", ".") & "," & Replace(.Fields!Saldo.Value, ",", ".") & ",'" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'," & TxtKodeToko.Text & "," & idPrd & ""
                    connDc.Execute(xx)

                    .MoveNext()
                Loop

                'Tinggal select table aja peb udah ada di SP, setelah select di delete table Temp
                Call Print()

            Else
                MsgBox("Data movment item tersebut tidak ditemukan", vbExclamation, "PERHATIAN")
            End If

        End With
    End Sub
    Private Sub Print()

        Dim objConn As OleDbConnection
        Dim objCmd As OleDbCommand
        Dim objReader As OleDbDataReader
        Dim objDataSet As DataSet = New DataSetPO
        Dim strSQL, strCONN As String

        GetStringKoneksi() '---1
        strCONN = StrKoneksi '----2

        strSQL = "exec spKartuStok 'SelectTemp','2019-01-01','','',0,0,0,'" & Format(Tgl1.Value, "yyyy-MM-dd") & "','" & Format(Tgl2.Value, "yyyy-MM-dd") & "'," & TxtKodeToko.Text & "," & idPrd & ""

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
        rds.Name = "dtsKartuStok"
        rds.Value = objDataSet.Tables(0)

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NamaPT", NamaPT, True))
        paramList.Add(New ReportParameter("Judul", "LAPORAN KARTU STOK TOKO", True))
        paramList.Add(New ReportParameter("Tgl1", Format(Me.Tgl1.Value, "dd-MM-yyyy"), True))
        paramList.Add(New ReportParameter("Tgl2", Format(Me.Tgl2.Value, "dd-MM-yyyy"), True))
        paramList.Add(New ReportParameter("Toko", namatoko, True))
        paramList.Add(New ReportParameter("Alamat", alamattoko, True))
        paramList.Add(New ReportParameter("Barang", txtkdProduk.Text & " - " & NamaProduk, True))
        With Me
            .RptKSToko.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptKartuStok.rdlc"
            .RptKSToko.LocalReport.DataSources.Clear()
            .RptKSToko.LocalReport.DataSources.Add(rds)
            .RptKSToko.LocalReport.SetParameters(paramList)
            .RptKSToko.RefreshReport()
            .RptKSToko.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth
        End With

    End Sub


    Private Sub BtnFindStore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFindStore.Click
        TxtKodeToko.Text = FrmFind.cari("MasterToko")
        If TxtKodeToko.Text = "0" Then
            TxtKodeToko.Clear()
            Exit Sub
        Else
            gettoko(TxtKodeToko.Text)
            nmTko = namatoko
            txtnamaToko.Text = nmTko
        End If
    End Sub

    Private Sub btFindProduk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFindProduk.Click
        txtkdProduk.Text = FrmFind.cari("MasterProduk")
        If txtkdProduk.Text = "0" Then
            txtkdProduk.Clear()
            Exit Sub
        Else
            GetIdProduk(txtkdProduk.Text)
            idPrd = idProduk
            getNamaProduk(txtkdProduk.Text, 0)
            txtnamaproduk.Text = NamaProduk
        End If
    End Sub

    
End Class