Public Class FrmRegisterLPMPToko
    Dim conn As New ADODB.Connection
    Dim RsConn As New ADODB.Recordset
    Dim sql, TglAwal, TglAkhir, kodetoko, namatoko As String
    Dim max, saldoawal, saldoakhir, Receipt, Retur, Adjustment, Sales As Double

    Private Sub FrmRegisterLPMPToko_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Parent = PictureBox1
        Label1.BackColor = Color.Transparent
        Me.BackColor = Color.SkyBlue
        Me.BackgroundImage = System.Drawing.Image.FromFile(bg)
        PictureBox1.BackgroundImage = System.Drawing.Image.FromFile(atas)
        Me.Text = NamaPT

        Me.Label1.Left = (Me.Width - Me.Label1.Width) / 2
        Me.Label1.Top = 9
        If conn.State = 0 Then
            GetStringKoneksi()
            conn.Open(StrKoneksi)
        End If
       
        namadcAktif()
        Me.TxtKodeDC.Text = kodedc
        Me.TxtNamaDC.Text = namadc
    End Sub

    Private Sub BtnPriview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPriview.Click
        If Me.RBPlu.Checked = False And Me.RBRupiah.Checked = False Then
            MsgBox("Silahkan Pilih jenis view dahulu", vbInformation, "Perhatian")
            Exit Sub
        End If

        If Me.RBPlu.Checked = True Then
            ViewByPlu()
        Else
            ViewByRupiah()
        End If
    End Sub

    Private Sub ViewByPlu()
        TglAwal = Year(Me.DTPTglAwal.Value) & "-" & Month(Me.DTPTglAwal.Value) & "-" & Microsoft.VisualBasic.DateAndTime.Day(Me.DTPTglAwal.Value)
        TglAkhir = Year(Me.DTPTglAkhir.Value) & "-" & Month(Me.DTPTglAkhir.Value) & "-" & Microsoft.VisualBasic.DateAndTime.Day(Me.DTPTglAkhir.Value)

        ListView1.Columns.Clear()
        ListView1.Items.Clear()
        ListView1.View = Windows.Forms.View.Details
        ListView1.GridLines = True
        ListView1.FullRowSelect = True

        'If TxtFind.Text = "" Then
        '    strfind = "%"
        'Else
        '    strfind = TxtFind.Text
        'End If
        ListView1.Columns.Add("Kode Toko", 50)
        ListView1.Columns.Add("Nama Toko", 60)
        ListView1.Columns.Add("Max", 300)
        ListView1.Columns.Add("Saldo Awal", 80)
        ListView1.Columns.Add("Receipt", 100)
        ListView1.Columns.Add("Retur", 80)
        ListView1.Columns.Add("Adjustment", 120)
        ListView1.Columns.Add("Sales", 120)
        ListView1.Columns.Add("Saldo Akhir", 120)

        sql = "exec spRegisterLPMPToko 'GetByPlu','" & TglAwal & "','" & TglAkhir & "'"

        RsConn = conn.Execute(sql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()
            Dim nomor As Integer = 1
            Do While Not RsConn.EOF

                kodetoko = RsConn("kodetoko").Value
                namatoko = RsConn("namatoko").Value
                max = RsConn("maxStok").Value
                saldoawal = RsConn("SaldoAwal").Value
                Receipt = RsConn("Receipt").Value
                Retur = RsConn("Retur").Value
                Adjustment = RsConn("Adjustment").Value
                Sales = RsConn("Sales").Value
                saldoakhir = RsConn("SaldoAkhir").Value


                Dim arr(9) As String
                Dim itm As ListViewItem
                arr(0) = kodetoko
                arr(1) = namatoko
                arr(2) = max
                arr(3) = saldoawal
                arr(4) = Receipt
                arr(5) = Retur
                arr(6) = Adjustment
                arr(7) = Sales
                arr(8) = saldoakhir


                itm = New ListViewItem(arr)
                ListView1.Items.Add(itm)
                nomor += 1
                RsConn.MoveNext()
            Loop

        End If
        RsConn.Close()

    End Sub

    Private Sub ViewByRupiah()
        TglAwal = Year(Me.DTPTglAwal.Value) & "-" & Month(Me.DTPTglAwal.Value) & "-" & Microsoft.VisualBasic.DateAndTime.Day(Me.DTPTglAwal.Value)
        TglAkhir = Year(Me.DTPTglAkhir.Value) & "-" & Month(Me.DTPTglAkhir.Value) & "-" & Microsoft.VisualBasic.DateAndTime.Day(Me.DTPTglAkhir.Value)

        ListView1.Columns.Clear()
        ListView1.Items.Clear()
        ListView1.View = Windows.Forms.View.Details
        ListView1.GridLines = True
        ListView1.FullRowSelect = True

        'If TxtFind.Text = "" Then
        '    strfind = "%"
        'Else
        '    strfind = TxtFind.Text
        'End If
        ListView1.Columns.Add("Kode Toko", 50)
        ListView1.Columns.Add("Nama Toko", 60)
        ListView1.Columns.Add("Rupiah Max", 300)
        ListView1.Columns.Add("Rupiah Saldo Awal", 80)
        ListView1.Columns.Add("Rupiah Receipt", 100)
        ListView1.Columns.Add("Rupiah Retur", 80)
        ListView1.Columns.Add("Rupiah Adjustment", 120)
        ListView1.Columns.Add("Rupiah Sales", 120)
        ListView1.Columns.Add("Rupiah Saldo Akhir", 120)

        sql = "exec spRegisterLPMPToko 'GetByRp','" & TglAwal & "','" & TglAkhir & "'"

        RsConn = conn.Execute(sql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()
            Dim nomor As Integer = 1
            Do While Not RsConn.EOF

                kodetoko = RsConn("kodetoko").Value
                namatoko = RsConn("namatoko").Value
                max = RsConn("RpMax").Value
                saldoawal = RsConn("RpSaldoAwal").Value
                Receipt = RsConn("RpReceipt").Value
                Retur = RsConn("RpRetur").Value
                Adjustment = RsConn("RpAdjustment").Value
                Sales = RsConn("RpSales").Value
                saldoakhir = RsConn("RpSaldoAkhir").Value


                Dim arr(9) As String
                Dim itm As ListViewItem
                arr(0) = kodetoko
                arr(1) = namatoko
                arr(2) = max
                arr(3) = saldoawal
                arr(4) = Receipt
                arr(5) = Retur
                arr(6) = Adjustment
                arr(7) = Sales
                arr(8) = saldoakhir


                itm = New ListViewItem(arr)
                ListView1.Items.Add(itm)
                nomor += 1
                RsConn.MoveNext()
            Loop

        End If
        RsConn.Close()

    End Sub
End Class