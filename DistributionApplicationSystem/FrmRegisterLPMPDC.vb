Public Class FrmRegisterLPMPDC
    Dim conn As New ADODB.Connection
    Dim RsConn As New ADODB.Recordset
    Dim sql, TglAwal, TglAkhir, Bulan, JumlahHari As String
    Dim max, saldoawal, saldoakhir, Receipt, ReturDC, ReturSupplier, Adjustment, Sales As Double

    Private Sub BtnPriview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPriview.Click
        If Me.RBPlu.Checked = False And Me.RBRupiah.Checked = False Then
            MsgBox("Silahkan Pilih jenis view dahulu", vbInformation, "Perhatian")
            Exit Sub
        End If

        If Me.RBPlu.Checked = True Then
            ViewByPlu()
        Else
            ViewByRp()
        End If
    End Sub

    Private Sub FrmRegisterLPMPDC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        ListView1.Columns.Add("Bulan", 50)
        ListView1.Columns.Add("Jumlah Hari", 80)
        ListView1.Columns.Add("Max", 80)
        ListView1.Columns.Add("Saldo Awal", 100)
        ListView1.Columns.Add("Receipt", 80)
        ListView1.Columns.Add("Retur DC", 120)
        ListView1.Columns.Add("Retur Supplier", 120)
        ListView1.Columns.Add("Adjust", 120)
        ListView1.Columns.Add("Sales", 120)
        ListView1.Columns.Add("Saldo Akhir", 120)

        ListView1.Columns(1).TextAlign = HorizontalAlignment.Center
        ListView1.Columns(2).TextAlign = HorizontalAlignment.Right
        ListView1.Columns(3).TextAlign = HorizontalAlignment.Right
        ListView1.Columns(4).TextAlign = HorizontalAlignment.Right
        ListView1.Columns(5).TextAlign = HorizontalAlignment.Right
        ListView1.Columns(6).TextAlign = HorizontalAlignment.Right
        ListView1.Columns(7).TextAlign = HorizontalAlignment.Right
        ListView1.Columns(8).TextAlign = HorizontalAlignment.Right
        ListView1.Columns(9).TextAlign = HorizontalAlignment.Right


        sql = "exec spRegisterLPMPDC 'GetByPlu','" & TglAwal & "','" & TglAkhir & "'"

        RsConn = conn.Execute(sql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()
            Dim nomor As Integer = 1
            Do While Not RsConn.EOF

                Bulan = RsConn("Bulan").Value
                JumlahHari = RsConn("JumlahHari").Value
                max = RsConn("maxStok").Value
                saldoawal = RsConn("SaldoAwal").Value
                Receipt = RsConn("RcvSupplier").Value
                ReturDC = RsConn("RcvDariToko").Value
                ReturSupplier = RsConn("ReturSupplier").Value
                Adjustment = RsConn("Adjustment").Value
                Sales = RsConn("Sales").Value
                saldoakhir = RsConn("SaldoAkhir").Value


                Dim arr(10) As String
                Dim itm As ListViewItem
                arr(0) = Bulan
                arr(1) = JumlahHari
                arr(2) = max
                arr(3) = saldoawal
                arr(4) = Receipt
                arr(5) = ReturDC
                arr(6) = ReturSupplier
                arr(7) = Adjustment
                arr(8) = Sales
                arr(9) = saldoakhir



                itm = New ListViewItem(arr)
                ListView1.Items.Add(itm)
                nomor += 1
                RsConn.MoveNext()
            Loop

        End If
        RsConn.Close()

    End Sub

    Private Sub ViewByRp()
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
        ListView1.Columns.Add("Bulan", 50)
        ListView1.Columns.Add("Jumlah Hari", 80)
        ListView1.Columns.Add("Rp Max", 80)
        ListView1.Columns.Add("Rp Saldo Awal", 100)
        ListView1.Columns.Add("Rp Receipt", 80)
        ListView1.Columns.Add("Rp Retur DC", 120)
        ListView1.Columns.Add("Rp Retur Supplier", 120)
        ListView1.Columns.Add("Rp Adjust", 120)
        ListView1.Columns.Add("Rp Sales", 120)
        ListView1.Columns.Add(" Rp Saldo Akhir", 120)

        ListView1.Columns(1).TextAlign = HorizontalAlignment.Center
        ListView1.Columns(2).TextAlign = HorizontalAlignment.Right
        ListView1.Columns(3).TextAlign = HorizontalAlignment.Right
        ListView1.Columns(4).TextAlign = HorizontalAlignment.Right
        ListView1.Columns(5).TextAlign = HorizontalAlignment.Right
        ListView1.Columns(6).TextAlign = HorizontalAlignment.Right
        ListView1.Columns(7).TextAlign = HorizontalAlignment.Right
        ListView1.Columns(8).TextAlign = HorizontalAlignment.Right
        ListView1.Columns(9).TextAlign = HorizontalAlignment.Right

        sql = "exec spRegisterLPMPDC 'GetByRp','" & TglAwal & "','" & TglAkhir & "'"

        RsConn = conn.Execute(sql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()
            Dim nomor As Integer = 1
            Do While Not RsConn.EOF

                Bulan = RsConn("Bulan").Value
                JumlahHari = RsConn("JumlahHari").Value
                max = RsConn("RpmaxStok").Value
                saldoawal = RsConn("RpSaldoAwal").Value
                Receipt = RsConn("RpRcvSupplier").Value
                ReturDC = RsConn("RpRcvDariToko").Value
                ReturSupplier = RsConn("RpReturSupplier").Value
                Adjustment = RsConn("RpAdjustment").Value
                Sales = RsConn("RpSales").Value
                saldoakhir = RsConn("RpSaldoAkhir").Value


                Dim arr(10) As String
                Dim itm As ListViewItem
                arr(0) = Bulan
                arr(1) = JumlahHari
                arr(2) = max
                arr(3) = saldoawal
                arr(4) = Receipt
                arr(5) = ReturDC
                arr(6) = ReturSupplier
                arr(7) = Adjustment
                arr(8) = Sales
                arr(9) = saldoakhir


                itm = New ListViewItem(arr)
                ListView1.Items.Add(itm)
                nomor += 1
                RsConn.MoveNext()
            Loop

        End If
        RsConn.Close()

    End Sub
End Class