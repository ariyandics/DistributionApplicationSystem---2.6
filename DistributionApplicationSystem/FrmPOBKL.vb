Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Data.OleDb
Public Class FrmPOBKL
    Dim Conn, ConnMDB As New ADODB.Connection
    Dim RsConn, RsMdb, rsconnx As New ADODB.Recordset
    Dim sql As String
    Private Sub FrmPOBKL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Me.BackColor = Color.DeepSkyBlue


        Call GbrTombol()
        Call kunci()
        Call LoadData()

    End Sub
    Private Sub GbrTombol()
        Me.BtnAdd.Image = System.Drawing.Image.FromFile(icoproses)
        Me.BtnSimpan.Image = System.Drawing.Image.FromFile(icosave)
        Me.BtnPrint.Image = System.Drawing.Image.FromFile(icoprint)
        Me.BtnAbsen.Image = System.Drawing.Image.FromFile(icorefresh)

    End Sub

    Private Sub LoadData()
        Dim nourut As Integer
        ListView2.Columns.Clear()
        ListView2.Items.Clear()
        ListView2.View = Windows.Forms.View.Details
        ListView2.GridLines = True
        ListView2.FullRowSelect = True

        ListView2.Columns.Add("No", 50)
        ListView2.Columns.Add("Kode Toko", 70)
        ListView2.Columns.Add("Nama Toko", 200)
        ListView2.Columns.Add("No. PO BKL", 80)
        ListView2.Columns.Add("Total Item", 80)
        ListView2.Columns.Add("Total Qty", 80)
       

        sql = "exec spPBBKLToko 'Absen'"
        RsConn = Conn.Execute(Sql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()
            nourut = 1
            BtnAdd.Enabled = True
            Do While Not RsConn.EOF
                Dim arr(11) As String
                Dim itm As ListViewItem

                arr(0) = noUrut
                arr(1) = RsConn("kodetoko").Value
                arr(2) = RsConn("namatoko").Value
                arr(3) = RsConn("Nomorpo").Value
                arr(4) = RsConn("totalitem").Value
                arr(5) = RsConn("totalqty").Value

             
                itm = New ListViewItem(arr)
                ListView2.Items.Add(itm)
                noUrut = noUrut + 1
                RsConn.MoveNext()

            Loop

        End If
        RsConn.Close()
    End Sub
    Private Sub kunci()
        BtnAdd.Enabled = False
        BtnPrint.Enabled = False
        BtnSimpan.Enabled = False
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        sql = "exec spPBBKLToko 'Absen'"
        RsConn = Conn.Execute(sql)
        If Not RsConn.EOF Then
            Call proses()
        Else
            MsgBox("Tidak ada data yang akan di proses !!", vbOKOnly + vbInformation, "Info")
            Exit Sub
        End If
    End Sub

    Private Sub proses()


    End Sub
End Class