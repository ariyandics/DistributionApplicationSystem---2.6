Imports System.Data.SqlClient
Public Class FrmFind
    Dim Conn, ConnMDB As New ADODB.Connection
    Dim RsConn, RsMdb As New ADODB.Recordset
    Dim sql As String
    Dim StrReturnValue, StrFrmPemanggil As String
    Dim strkode, strnama, strfind, strNama2 As String
    Dim strtgl2, strtgl As Date
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand
    Public Function cari(ByVal FrmPemanggil As String) As String
        StrReturnValue = 0
        Me.TopMost = True
        StrFrmPemanggil = FrmPemanggil
        Me.ShowDialog()
        cari = StrReturnValue
    End Function
    Private Sub LoadNoMutasiDCOut()
        Label1.Text = "Nomor Mutasi"
        ListView2.Columns.Clear()
        ListView2.Items.Clear()
        ListView2.View = Windows.Forms.View.Details
        ListView2.GridLines = True
        ListView2.FullRowSelect = True

        If TxtFind.Text = "" Then
            strfind = "%"
        Else
            strfind = TxtFind.Text
        End If

        ListView2.Columns.Add("Nomor Mutasi", 160)
        ListView2.Columns.Add("Tgl Mutasi", 260)



        sql = "exec spfind 'NoMutasiDCOut'," & iddcpengirim & ",'%" & strfind & "%'"
        RsConn = Conn.Execute(sql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()

            Do While Not RsConn.EOF
                strnama = RsConn("nomutasi").Value
                strNama2 = Format(RsConn("tglapprove").Value, "dd-MM-yyyy")

                Dim arr(2) As String
                Dim itm As ListViewItem

                arr(0) = strnama
                arr(1) = strNama2

                itm = New ListViewItem(arr)
                ListView2.Items.Add(itm)

                RsConn.MoveNext()
            Loop

        End If
        RsConn.Close()
    End Sub

    Private Sub LoadataRetur()
        Label1.Text = "Nomor Retur"
        ListView2.Columns.Clear()
        ListView2.Items.Clear()
        ListView2.View = Windows.Forms.View.Details
        ListView2.GridLines = True
        ListView2.FullRowSelect = True

        If TxtFind.Text = "" Then
            strfind = "%"
        Else
            strfind = TxtFind.Text
        End If

        ListView2.Columns.Add("Nomor Retur", 90)
        ListView2.Columns.Add("Kode", 70)
        ListView2.Columns.Add("Nama Supplier", 200)
        ListView2.Columns.Add("Status", 90)



        sql = "exec spFind 'GetReturS','%" & strfind & "%','x'"
        RsConn = Conn.Execute(sql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()

            Do While Not RsConn.EOF
                

                Dim arr(4) As String
                Dim itm As ListViewItem

                arr(0) = RsConn("nomorRetur").Value
                arr(1) = RsConn("kodeSupplier").Value
                arr(2) = RsConn("namaSupplier").Value
                arr(3) = RsConn("keterangan").Value

                itm = New ListViewItem(arr)
                ListView2.Items.Add(itm)

                RsConn.MoveNext()
            Loop

        End If
        RsConn.Close()
    End Sub


    Private Sub LoadMutasiDCOut()
        Label1.Text = "Nomor Mutasi"
        ListView2.Columns.Clear()
        ListView2.Items.Clear()
        ListView2.View = Windows.Forms.View.Details
        ListView2.GridLines = True
        ListView2.FullRowSelect = True

        If TxtFind.Text = "" Then
            strfind = "%"
        Else
            strfind = TxtFind.Text
        End If

        ListView2.Columns.Add("Tgl Buat", 80)
        ListView2.Columns.Add("No.Mutasi", 80)
        ListView2.Columns.Add("DC Tujuan", 180)
        ListView2.Columns.Add("Status", 100)

        sql = "exec spFind 'NoMutasiOut','%" & strfind & "%',0"
        RsConn = Conn.Execute(sql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()

            Do While Not RsConn.EOF
              
                Dim arr(4) As String
                Dim itm As ListViewItem

                arr(0) = Format(RsConn("tglcreate").Value, "dd-MM-yyyy")
                arr(1) = RsConn("NoMutasi").Value
                arr(2) = RsConn("kodedc").Value & "-" & RsConn("namadc").Value
                arr(3) = RsConn("statusdata").Value

                itm = New ListViewItem(arr)
                ListView2.Items.Add(itm)

                RsConn.MoveNext()
            Loop

        End If
        RsConn.Close()
    End Sub


    Private Sub LoadSupplier()
        Label1.Text = "Nama Supplier"
        ListView2.Columns.Clear()
        ListView2.Items.Clear()
        ListView2.View = Windows.Forms.View.Details
        ListView2.GridLines = True
        ListView2.FullRowSelect = True

        If TxtFind.Text = "" Then
            strfind = "%"
        Else
            strfind = TxtFind.Text
        End If

        ListView2.Columns.Add("Kd Supp.", 60)
        ListView2.Columns.Add("Nama Supplier", 330)
        ListView2.Columns.Add("Nama Singkat", 90)

        If StrFrmPemanggil = "JWKSupplierByDC" Then
            sql = "select a.* from mstsupplier a inner join mstsupplierperdc b on a.idsupplier=b.idsupplier where statusdata=1 and a.idsupplier not in ( select idsupplier from mstsupplierjwk where iddc=" & iddcjwk & ") and namasupplier like '%" & strfind & "%'"
        ElseIf StrFrmPemanggil = "MasterSupplierHB" Then
            sql = "select KodeSupplier,NamaSupplier,namaSingkatSupplier from mstsupplier where idsupplier in ( select idsupplier from MstProdukSupplier where idproduk=" & idProduk & ") and namasupplier like '%" & strfind & "%'"
        ElseIf StrFrmPemanggil = "KoreksiUPO" Then
            sql = "select KodeSupplier,NamaSupplier,namaSingkatSupplier from mstsupplier where idsupplier in ( select idsupplier from UpoDcDetail where nomorupo=" & nomorUPO & ") and namasupplier like '%" & strfind & "%'"
        ElseIf StrFrmPemanggil = "MasterSupplierRetur" Then
            sql = "select KodeSupplier,NamaSupplier,namaSingkatSupplier from mstsupplier where idkategorisupplier <> 1 and bisaretur=1 and namasupplier like '%" & strfind & "%'"
        ElseIf StrFrmPemanggil = "MasterSupplierJWK" Then
            sql = "Exec spFind 'SuppBKL','%" & strfind & "%','x'"
        ElseIf StrFrmPemanggil = "POManual" Then
            sql = "Exec spFind 'POManual','%" & strfind & "%','x'"
        Else
            'sql = "exec spMstSupplier 'get',0,'S','" & strfind & "','Sinit',1,1,'11-2.00','jlnpwp','Ir.X',1,1,'1.1',7,1,1,'Norek','namarek',15,'2017-01-01',1,1000,1000000,1,1,1,1,1,1,1,'" & StrUserid & "','x','2017-01-01',0,0,0,'x','x','x'"
            sql = "select KodeSupplier,NamaSupplier,namaSingkatSupplier from mstsupplier where idkategorisupplier <> 1 and statusData =1 and  namasupplier like '%" & strfind & "%'"
        End If
        RsConn = Conn.Execute(sql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()

            Do While Not RsConn.EOF
                strkode = RsConn("KodeSupplier").Value
                strnama = RsConn("NamaSupplier").Value
                strNama2 = RsConn("namaSingkatSupplier").Value

                Dim arr(3) As String
                Dim itm As ListViewItem

                arr(0) = strkode
                arr(1) = strnama
                arr(2) = strNama2

                itm = New ListViewItem(arr)
                ListView2.Items.Add(itm)

                RsConn.MoveNext()
            Loop

        End If
        RsConn.Close()
    End Sub

    Private Sub LoadKaryawan()
        Label1.Text = "Nama Karyawan"
        ListView2.Columns.Clear()
        ListView2.Items.Clear()
        ListView2.View = Windows.Forms.View.Details
        ListView2.GridLines = True
        ListView2.FullRowSelect = True

        If TxtFind.Text = "" Then
            strfind = "%"
        Else
            strfind = TxtFind.Text
        End If

        ListView2.Columns.Add("No Induk", 80)
        ListView2.Columns.Add("Nama Karyawan", 250)
        ListView2.Columns.Add("jabatan", 140)

                                                                                                                                      
        sql = "exec spMstKaryawan 'getnama','0','%" & strfind & "%',0,0,'Almt','kdpos','ttgl','nohp','1900-01-01',0,0,0,0,'" & StrNamaUser & "','1900-01-01','1900-01-01',0"
        RsConn = Conn.Execute(sql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()

            Do While Not RsConn.EOF
                strkode = RsConn("NomorInduk").Value
                strnama = RsConn("Nama").Value
                strNama2 = RsConn("namaJabatan").Value

                Dim arr(3) As String
                Dim itm As ListViewItem

                arr(0) = strkode
                arr(1) = strnama
                arr(2) = strNama2

                itm = New ListViewItem(arr)
                ListView2.Items.Add(itm)

                RsConn.MoveNext()
            Loop

        End If
        RsConn.Close()
    End Sub

    Private Sub LoadProduk()
        Label1.Text = "Nama Produk"
        ListView2.Columns.Clear()
        ListView2.Items.Clear()
        ListView2.View = Windows.Forms.View.Details
        ListView2.GridLines = True
        ListView2.FullRowSelect = True

        If TxtFind.Text = "" Then
            strfind = "%"
        Else
            strfind = TxtFind.Text
        End If

        ListView2.Columns.Add("Kode Produk", 100)
        ListView2.Columns.Add("Nama Produk", 320)

        If StrFrmPemanggil = "ProdukPOManual" Then
            sql = "select kodeproduk,namaPanjang from mstproduk a inner join mstproduksupplier b on a.idProduk =b.idProduk and b.idSupplier =" & IdSupplier & " and b.statusdata=1 and b.statusaktif=1 inner join MstTagProduk c on a.kodeTag =c.kodeTag and c.flagDcPo =1 where a.statusdata= 1 and (kodeproduk like '" & strfind & "%' or  namapanjang like '%" & strfind & "%')"
        ElseIf StrFrmPemanggil = "DraftPOGO" Then
            sql = "select kodeproduk,namaPanjang from mstproduk where idproduk in (select idproduk from mstproduksupplier where idsupplier=" & IdSupplier & ")"
        ElseIf StrFrmPemanggil = "Masterprodukretur" Then
            sql = "select b.kodeProduk ,b.namaPanjang  from MstProdukSupplier a inner join ( select idproduk,namaPanjang ,kodeProduk  from MstProduk a inner join MstTagProduk b on a.kodeTag =b.kodeTag and b.flagDcRetur =1) b on a.idProduk =b.idProduk  where idSupplier= " & IdSupplier & " and ( namaPanjang like '%" & strfind & "%' or  kodeproduk like '" & strfind & "')"
        ElseIf StrFrmPemanggil = "ProdukPaket" Then
            sql = "exec sptblProdukPaket 'get',0,0,0,0,'x'"
        ElseIf StrFrmPemanggil = "ProdukMutasi" Then
            sql = "select kodeproduk,namapanjang from mstproduk where  idjenisproduk =1 and (namapanjang like '%" & strfind & "%' or kodeproduk like '" & strfind & "%')"
        Else
            sql = "select kodeproduk,namapanjang from mstproduk where namapanjang like '%" & strfind & "%' or kodeproduk like '" & strfind & "%'"

        End If

        Try
            GetStringKoneksi()
            Using Con As New SqlConnection(ConnSQLClient)
                Con.Open()
                Using Com As New SqlCommand(sql, Con)
                    Using RDR = Com.ExecuteReader()
                        If RDR.HasRows Then
                            Do While RDR.Read
                                strnama = RDR.Item("KodeProduk")
                                strNama2 = RDR.Item("namaPanjang")

                                Dim arr(2) As String
                                Dim itm As ListViewItem

                                arr(0) = strnama
                                arr(1) = strNama2

                                itm = New ListViewItem(arr)
                                ListView2.Items.Add(itm)

                            Loop
                        End If
                    End Using
                End Using
                Con.Close()
            End Using

        Catch ex As SqlException
            MsgBox("Koneksi ke server terputus..!", vbOKOnly + vbInformation, "Info")
        End Try
    End Sub

    Private Sub loadHBSupplier()
        Label1.Text = "Nama Supplier"
        ListView2.Columns.Clear()
        ListView2.Items.Clear()
        ListView2.View = Windows.Forms.View.Details
        ListView2.GridLines = True
        ListView2.FullRowSelect = True

        If TxtFind.Text = "" Then
            strfind = "%"
        Else
            strfind = TxtFind.Text
        End If

        ListView2.Columns.Add("No.Perubahan", 160)
        ListView2.Columns.Add("Kode Supplier", 80)
        ListView2.Columns.Add("Nama Supplier", 180)



        sql = "select distinct(nomorPerubahan ) , b.kodeSupplier ,b.namaSupplier  from PerubahanHargaBeliSupplierdetail  a " & _
              "inner join mstsupplier b on a.idsupplier=b.idsupplier where b.namasupplier like '%" & strfind & "%'"
        RsConn = Conn.Execute(sql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()

            Do While Not RsConn.EOF
                strkode = RsConn("NomorPerubahan").Value
                strnama = RsConn("kodeSupplier").Value
                strNama2 = RsConn("namaSupplier").Value

                Dim arr(3) As String
                Dim itm As ListViewItem

                arr(0) = strkode
                arr(1) = strnama
                arr(2) = strNama2

                itm = New ListViewItem(arr)
                ListView2.Items.Add(itm)

                RsConn.MoveNext()
            Loop

        End If
        RsConn.Close()
    End Sub


    Private Sub loadHargaJual()
        Label1.Text = "Nama Produk"
        ListView2.Columns.Clear()
        ListView2.Items.Clear()
        ListView2.View = Windows.Forms.View.Details
        ListView2.GridLines = True
        ListView2.FullRowSelect = True

        If TxtFind.Text = "" Then
            strfind = "%"
        Else
            strfind = TxtFind.Text
        End If

        ListView2.Columns.Add("No.Perubahan", 160)
        ListView2.Columns.Add("Kode Supplier", 80)
        ListView2.Columns.Add("Nama Supplier", 180)



        sql = "select distinct(nomorPerubahan ) , b.kodeSupplier ,b.namaSupplier  from PerubahanHargaBeliSupplierdetail  a " & _
              "inner join mstsupplier b on a.idsupplier=b.idsupplier where b.namasupplier like '%" & strfind & "%'"
        RsConn = Conn.Execute(sql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()

            Do While Not RsConn.EOF
                strkode = RsConn("NomorPerubahan").Value
                strnama = RsConn("kodeSupplier").Value
                strNama2 = RsConn("namaSupplier").Value

                Dim arr(3) As String
                Dim itm As ListViewItem

                arr(0) = strkode
                arr(1) = strnama
                arr(2) = strNama2

                itm = New ListViewItem(arr)
                ListView2.Items.Add(itm)

                RsConn.MoveNext()
            Loop

        End If
        RsConn.Close()
    End Sub
    Private Sub LoadPlanoToko()
        Label1.Text = "Nama Produk"
        ListView2.Columns.Clear()
        ListView2.Items.Clear()
        ListView2.View = Windows.Forms.View.Details
        ListView2.GridLines = True
        ListView2.FullRowSelect = True

        If TxtFind.Text = "" Then
            strfind = "%"
        Else
            strfind = TxtFind.Text
        End If

        ListView2.Columns.Add("Kode Produk", 160)
        ListView2.Columns.Add("Nama Produk", 260)

        sql = "select kodeproduk,namapanjang from mstproduk where idDivisi =" & iddiv & " and idDepartement =" & iddept & " and idSubDepartement =" & idsubdept
        RsConn = Conn.Execute(sql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()

            Do While Not RsConn.EOF
                strnama = RsConn("KodeProduk").Value
                strNama2 = RsConn("namaPanjang").Value

                Dim arr(2) As String
                Dim itm As ListViewItem

                arr(0) = strnama
                arr(1) = strNama2

                itm = New ListViewItem(arr)
                ListView2.Items.Add(itm)

                RsConn.MoveNext()
            Loop

        End If
        RsConn.Close()
    End Sub
    Private Sub LoadNomorUPO()
        Label1.Text = "No.UPO"
        ListView2.Columns.Clear()
        ListView2.Items.Clear()
        ListView2.View = Windows.Forms.View.Details
        ListView2.GridLines = True
        ListView2.FullRowSelect = True

        If TxtFind.Text = "" Then
            strfind = "%"
        Else
            strfind = TxtFind.Text
        End If

        ListView2.Columns.Add("No.UPO", 220)
        ListView2.Columns.Add("Tgl UPO", 220)

        If StrFrmPemanggil = "NomorUPOOto" Then
            sql = "select NomorUpo,tglUpo from upodcheader where  idjenispo=1  and statusdata=1  and nomorupo like '%" & strfind & "%' order by tglupo desc"

        Else
            sql = "select NomorUpo,tglUpo from upodcheader where  idjenispo=1  and nomorupo like '%" & strfind & "%' order by tglupo desc"

        End If

        RsConn = Conn.Execute(sql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()

            Do While Not RsConn.EOF
                strkode = RsConn("NomorUpo").Value
                strTgl = RsConn("tglUpo").Value

                Dim arr(2) As String
                Dim itm As ListViewItem

                arr(0) = strkode
                arr(1) = strTgl

                itm = New ListViewItem(arr)
                ListView2.Items.Add(itm)

                RsConn.MoveNext()
            Loop

        End If
        RsConn.Close()
    End Sub

    Private Sub LoadNomorPO()
        Label1.Text = "Nama Supplier"
        ListView2.Columns.Clear()
        ListView2.Items.Clear()
        ListView2.View = Windows.Forms.View.Details
        ListView2.GridLines = True
        ListView2.FullRowSelect = True

        If TxtFind.Text = "" Then
            strfind = "%"
        Else
            strfind = TxtFind.Text
        End If

        ListView2.Columns.Add("No.PO", 90)
        ListView2.Columns.Add("Nama Supplier", 220)
        ListView2.Columns.Add("Tgl PO", 90)

        If StrFrmPemanggil = "NomorPOManual" Then
            ListView2.Columns.Add("Status", 90)
        End If

        If StrFrmPemanggil = "NomorPOManual" Then
            'sql = "select nomorPo ,namaSupplier ,tglPo from podcheader a inner join upodcheader b on a.nomorUpo =b.nomorUpo and b.idJenisPo =2 inner join MstSupplier c on c.idSupplier =a.idSupplier where namasupplier like '%" & strfind & "%' order by nomorpo desc"
            sql = "exec  sppodcheader 'CariPOMan',0,0,0,0,'2017-01-01','2017-01-01','2017-01-01',0,0,0,0,0,0,'" & StrNamaUser & "',0,'%" & strfind & "%',1"
        ElseIf StrFrmPemanggil = "NomorPORCV" Then
            sql = "exec spFind  'NomorPORCV','%" & strfind & "%','x'"
        Else
            sql = "select nomorPo ,namaSupplier ,tglPo from podcheader a inner join upodcheader b on a.nomorUpo =b.nomorUpo inner join MstSupplier c on c.idSupplier =a.idSupplier where  namasupplier like '%" & strfind & "%' order by tglpo desc"
        End If
        RsConn = Conn.Execute(sql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()

            Do While Not RsConn.EOF
                strkode = RsConn("Nomorpo").Value
                strtgl = RsConn("tglpo").Value

                Dim arr(4) As String
                Dim itm As ListViewItem

                arr(0) = strkode
                arr(1) = RsConn("namasupplier").Value
                arr(2) = strtgl.Date
                If StrFrmPemanggil = "NomorPOManual" Then
                    arr(3) = RsConn("statusPO").Value
                End If



                itm = New ListViewItem(arr)
                ListView2.Items.Add(itm)

                RsConn.MoveNext()
            Loop

        End If
        RsConn.Close()
    End Sub

    Private Sub LoadNomorLPB()
        Label1.Text = "Nama Supplier"
        ListView2.Columns.Clear()
        ListView2.Items.Clear()
        ListView2.View = Windows.Forms.View.Details
        ListView2.GridLines = True
        ListView2.FullRowSelect = True

        If TxtFind.Text = "" Then
            strfind = "%"
        Else
            strfind = TxtFind.Text
        End If

        ListView2.Columns.Add("No.LPB", 90)
        ListView2.Columns.Add("Nama Supplier", 320)
        ListView2.Columns.Add("Tgl Terima", 90)


        sql = "exec spFind  'NomorLPB','%" & strfind & "%','x'"
        RsConn = Conn.Execute(sql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()

            Do While Not RsConn.EOF
                strkode = RsConn("Nomorlpb").Value
                strtgl = RsConn("tglterima").Value

                Dim arr(4) As String
                Dim itm As ListViewItem

                arr(0) = strkode
                arr(1) = RsConn("namasupplier").Value
                arr(2) = strtgl.Date

                itm = New ListViewItem(arr)
                ListView2.Items.Add(itm)

                RsConn.MoveNext()
            Loop

        End If
        RsConn.Close()
    End Sub

    Private Sub LoadNoMutasiIn()
        Label1.Text = "No LPB"
        ListView2.Columns.Clear()
        ListView2.Items.Clear()
        ListView2.View = Windows.Forms.View.Details
        ListView2.GridLines = True
        ListView2.FullRowSelect = True

        If TxtFind.Text = "" Then
            strfind = "%"
        Else
            strfind = TxtFind.Text
        End If

        ListView2.Columns.Add("No.LPB", 90)
        ListView2.Columns.Add("DC Pengirim", 260)
        ListView2.Columns.Add("Tgl Terima", 90)


        sql = "exec spFind  'NoMutasiIn','%" & strfind & "%','%" & strfind & "%'"
        RsConn = Conn.Execute(sql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()

            Do While Not RsConn.EOF
               

                Dim arr(4) As String
                Dim itm As ListViewItem

                arr(0) = RsConn("nomutasiin").Value
                arr(1) = RsConn("Namadc").Value
                arr(2) = RsConn("tglapprove").Value

                itm = New ListViewItem(arr)
                ListView2.Items.Add(itm)

                RsConn.MoveNext()
            Loop

        End If
        RsConn.Close()
    End Sub



    Private Sub LoadNomorTO()
        Label1.Text = "Nama Toko"
        ListView2.Columns.Clear()
        ListView2.Items.Clear()
        ListView2.View = Windows.Forms.View.Details
        ListView2.GridLines = True
        ListView2.FullRowSelect = True

        If TxtFind.Text = "" Then
            strfind = "%"
        Else
            strfind = TxtFind.Text
        End If

        ListView2.Columns.Add("No.TO", 70)
        ListView2.Columns.Add("Tgl TO", 80)
        ListView2.Columns.Add("Kode Toko", 80)
        ListView2.Columns.Add("Nama Toko", 210)

        If StrFrmPemanggil = "NoTObyPB" Or StrFrmPemanggil = "NoTOManual" Then
            ListView2.Columns.Add("Status", 90)
        End If

        If StrFrmPemanggil = "NoTOManual" Then
            sql = "exec spfind 'NoTOManual','%" & strfind & "%','x'"
        ElseIf StrFrmPemanggil = "NoTObyPB" Then
            sql = "exec spfind 'NoTObyPB','%" & strfind & "%','x'"
        ElseIf StrFrmPemanggil = "NoTOManTMP" Then
            sql = "exec spTblTOTmp 'GetTO',2,0,0,0,0,'" & StrNamaUser & "'"
        ElseIf StrFrmPemanggil = "NoTObyPBTMP" Then
            sql = "exec spTblTOTmp 'GetTO',1,0,0,0,0,'" & StrNamaUser & "'"
        End If
        RsConn = Conn.Execute(sql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()

            Do While Not RsConn.EOF
                strkode = RsConn("NomorTO").Value
                If StrFrmPemanggil = "NoTOManTMP" Or StrFrmPemanggil = "NoTObyPBTMP" Then
                    strtgl = Now.Date
                Else
                    strtgl = RsConn("tglTO").Value
                End If
                strnama = RsConn("kodetoko").Value
                strNama2 = RsConn("namatoko").Value


                Dim arr(5) As String
                Dim itm As ListViewItem

                arr(0) = strkode
                arr(1) = strtgl.Date
                arr(2) = strnama
                arr(3) = strNama2

                If StrFrmPemanggil = "NoTObyPB" Or StrFrmPemanggil = "NoTOManual" Then
                    arr(4) = RsConn("keterangan").Value
                End If

                itm = New ListViewItem(arr)
                ListView2.Items.Add(itm)

                RsConn.MoveNext()
            Loop

        End If
        RsConn.Close()
    End Sub
    Private Sub LoadNomorMutasi()
        Label1.Text = "No Mutasi"
        ListView2.Columns.Clear()
        ListView2.Items.Clear()
        ListView2.View = Windows.Forms.View.Details
        ListView2.GridLines = True
        ListView2.FullRowSelect = True

        If TxtFind.Text = "" Then
            strfind = "%"
        Else
            strfind = TxtFind.Text
        End If



        ListView2.Columns.Add("No. Mutasi", 100)
        ListView2.Columns.Add("Tgl Mutasi", 80)
        ListView2.Columns.Add("Jenis Mutasi", 210)


        sql = "select nomorMutasi ,tglMutasi ,b.namaMovment   from MutasiSaldoHeader a " & _
              "inner join  MstMovmentProduk b on a.kodeMovment =b.kodeMovment " & _
             " where nomormutasi like '%" & strfind & "%' order by tglMutasi desc"
      
        RsConn = Conn.Execute(sql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()

            Do While Not RsConn.EOF


                Dim arr(3) As String
                Dim itm As ListViewItem

                arr(0) = RsConn("nomorMutasi").Value
                arr(1) = RsConn("tglMutasi").Value
                arr(2) = RsConn("namaMovment").Value

                itm = New ListViewItem(arr)
                ListView2.Items.Add(itm)

                RsConn.MoveNext()
            Loop

        End If
        RsConn.Close()
    End Sub

    Private Sub LoadNoMutasiPaket()
        Label1.Text = "No Mutasi"
        ListView2.Columns.Clear()
        ListView2.Items.Clear()
        ListView2.View = Windows.Forms.View.Details
        ListView2.GridLines = True
        ListView2.FullRowSelect = True

        If TxtFind.Text = "" Then
            strfind = "%"
        Else
            strfind = TxtFind.Text
        End If



        ListView2.Columns.Add("No.Mutasi", 100)
        ListView2.Columns.Add("Nama Paket", 210)
        ListView2.Columns.Add("Tgl Mutasi", 110)

        If StrFrmPemanggil = "NoUnPaket" Then
            sql = "exec sptblProdukUnPaket 'GetNoMut',0,0,0,0,'" & StrNamaUser & "'"
        Else
            sql = "exec sptblProdukPaket 'GetNoMut',0,0,0,0,'" & StrNamaUser & "'"
        End If
        RsConn = Conn.Execute(sql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()

            Do While Not RsConn.EOF


                Dim arr(3) As String
                Dim itm As ListViewItem

                arr(0) = RsConn("noMutasi").Value
                arr(1) = RsConn("NamaPanjang").Value
                arr(2) = RsConn("TglCreate").Value

                itm = New ListViewItem(arr)
                ListView2.Items.Add(itm)

                RsConn.MoveNext()
            Loop

        End If
        RsConn.Close()
    End Sub


    Private Sub LoadNoLock()
        Label1.Text = "No Lock"
        ListView2.Columns.Clear()
        ListView2.Items.Clear()
        ListView2.View = Windows.Forms.View.Details
        ListView2.GridLines = True
        ListView2.FullRowSelect = True

        If TxtFind.Text = "" Then
            strfind = "%"
        Else
            strfind = TxtFind.Text
        End If



        ListView2.Columns.Add("No.Lock", 120)
        ListView2.Columns.Add("Tgl Lock", 120)
        ListView2.Columns.Add("Jenis Stock", 210)

        If StrFrmPemanggil = "NoLockSO" Then
            sql = " select nomorSoFreeze,tglSOfreeze ,b.namaJenisStok  from soFreezeHeader a " & _
                  " inner join MstJenisStok b on a.idJenisStok =b.idJenisStok " & _
                  " where a.statusData =1 and idDc =" & IdDC
        Else
            sql = "select a.nomorSoFreeze,tglSOfreeze ,b.namaJenisStok  from soFreezeHeader a " & _
                  "inner join MstJenisStok b on a.idJenisStok =b.idJenisStok " & _
                  "inner join (select distinct(nomorSoFreeze ) from soFreezeDetailTmp " & _
                  "where statusdata =1 ) c on a.nomorSoFreeze =c.nomorSoFreeze where a.statusData =1 and a.idDc =" & IdDC
        End If
        RsConn = Conn.Execute(sql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()

            Do While Not RsConn.EOF
                strkode = RsConn("nomorSoFreeze").Value
                strTgl = RsConn("tglSOfreeze").Value
                strnama = RsConn("namaJenisStok").Value


                Dim arr(3) As String
                Dim itm As ListViewItem

                arr(0) = strkode
                arr(1) = strTgl.Date
                arr(2) = strnama


                itm = New ListViewItem(arr)
                ListView2.Items.Add(itm)

                RsConn.MoveNext()
            Loop

        End If
        RsConn.Close()
    End Sub

    Private Sub LoadNoAdj()
        Label1.Text = "No Adj"
        ListView2.Columns.Clear()
        ListView2.Items.Clear()
        ListView2.View = Windows.Forms.View.Details
        ListView2.GridLines = True
        ListView2.FullRowSelect = True

        If TxtFind.Text = "" Then
            strfind = "%"
        Else
            strfind = TxtFind.Text
        End If

        ListView2.Columns.Add("No.Adj", 90)
        ListView2.Columns.Add("Tgl Adj", 80)
        ListView2.Columns.Add("Jenis Stock", 150)
        ListView2.Columns.Add("Status", 150)

        If StrFrmPemanggil = "NoAdjSO" Then
            sql = "exec spFind 'GetNoAdj','%" & strfind & "%'," & IdDC
        End If
        RsConn = Conn.Execute(sql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()

            Do While Not RsConn.EOF
                strkode = RsConn("nomorSoAdjusment").Value
                strTgl = RsConn("tglSOAdjusment").Value
                strnama = RsConn("namaJenisStok").Value


                Dim arr(4) As String
                Dim itm As ListViewItem

                arr(0) = strkode
                arr(1) = strTgl.Date
                arr(2) = strnama
                arr(3) = RsConn("Keterangan").Value



                itm = New ListViewItem(arr)
                ListView2.Items.Add(itm)

                RsConn.MoveNext()
            Loop

        End If
        RsConn.Close()
    End Sub


    Private Sub LoadNoPL()
        Label1.Text = "Nama Toko"
        ListView2.Columns.Clear()
        ListView2.Items.Clear()
        ListView2.View = Windows.Forms.View.Details
        ListView2.GridLines = True
        ListView2.FullRowSelect = True

        If TxtFind.Text = "" Then
            strfind = "%"
        Else
            strfind = TxtFind.Text
        End If



        ListView2.Columns.Add("No.PL", 70)
        ListView2.Columns.Add("Tgl PL", 80)
        ListView2.Columns.Add("Kode Toko", 80)
        ListView2.Columns.Add("Nama Toko", 300)
        ListView2.Columns.Add("nopb", 0)

        sql = "exec spfind 'NoPL','%" & strfind & "%','x'"
        RsConn = Conn.Execute(sql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()

            Do While Not RsConn.EOF
                strkode = RsConn("nomorPicking").Value
                strTgl = RsConn("tglPicking").Value
                strnama = RsConn("kodetoko").Value
                strNama2 = RsConn("namatoko").Value


                Dim arr(4) As String
                Dim itm As ListViewItem

                arr(0) = strkode
                arr(1) = strTgl.Date
                arr(2) = strnama
                arr(3) = strNama2
                arr(4) = RsConn("nomorpb").Value

                itm = New ListViewItem(arr)
                ListView2.Items.Add(itm)

                RsConn.MoveNext()
            Loop

        End If
        RsConn.Close()
    End Sub

    Private Sub LoadDC()
        Label1.Text = "Nama DC"
        ListView2.Columns.Clear()
        ListView2.Items.Clear()
        ListView2.View = Windows.Forms.View.Details
        ListView2.GridLines = True
        ListView2.FullRowSelect = True

        If TxtFind.Text = "" Then
            strfind = "%"
        Else
            strfind = TxtFind.Text
        End If

        ListView2.Columns.Add("Kode DC", 100)
        ListView2.Columns.Add("Nama DC", 300)

        If StrFrmPemanggil = "JWKSupplierBySupp" Then
            sql = "select * from mstdc where iddc not in ( select iddc from mstsupplierjwk where idsupplier=" & idsupjwk & ")"
        ElseIf StrFrmPemanggil = "MasterDCAll" Then
            sql = "exec spfind 'MasterDC','%" & strfind & "%','x'"
        Else
            sql = "exec spMstDC 'get',0,0,'kddc','%" & strfind & "%','alamatdc',0,0,0,0,'kdpos','tlp',0,0,'lg',0,'" & StrNamaUser & "'"
        End If
        RsConn = Conn.Execute(sql)
        If Not RsConn.EOF Then
            RsConn.MoveFirst()

            Do While Not RsConn.EOF
                strnama = RsConn("KodeDC").Value
                strNama2 = RsConn("namaDC").Value

                Dim arr(2) As String
                Dim itm As ListViewItem

                arr(0) = strnama
                arr(1) = strNama2

                itm = New ListViewItem(arr)
                ListView2.Items.Add(itm)

                RsConn.MoveNext()
            Loop

        End If
        RsConn.Close()
    End Sub

    Private Sub LoadToko()
        Label1.Text = "Nama Toko"
        ListView2.Columns.Clear()
        ListView2.Items.Clear()
        ListView2.View = Windows.Forms.View.Details
        ListView2.GridLines = True
        ListView2.FullRowSelect = True

        If TxtFind.Text = "" Then
            strfind = "%"
        Else
            strfind = TxtFind.Text
        End If

        ListView2.Columns.Add("Kode Toko", 100)
        ListView2.Columns.Add("Singkatan Toko", 100)
        ListView2.Columns.Add("Nama Toko", 300)


        If StrFrmPemanggil = "JWKBklToko" Then
            sql = "Select kodetoko,namatoko,singkatantoko from msttoko where kodetoko not in ( select kodetoko from JwkTOkoKeDC) and namatoko like '%" & TxtFind.Text & "%'"
        ElseIf StrFrmPemanggil = "JwkBkl" Then
            sql = "exec spfind 'JwkBkl'," & idsupjwk & ",'%" & strfind & "%'"
        ElseIf StrFrmPemanggil = "MasterToko" Then
            sql = "exec spfind 'MasterToko','%" & strfind & "%','x'"
        Else
            sql = "Select kodetoko,namatoko,singkatantoko from msttoko"
        End If

        RsConn = Conn.Execute(sql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()

            Do While Not RsConn.EOF
                strkode = RsConn("Kodetoko").Value
                strnama = RsConn("singkatanToko").Value
                strNama2 = RsConn("namaToko").Value

                Dim arr(3) As String
                Dim itm As ListViewItem

                arr(0) = strkode
                arr(1) = strnama
                arr(2) = strNama2

                itm = New ListViewItem(arr)
                ListView2.Items.Add(itm)

                RsConn.MoveNext()
            Loop

        End If
        RsConn.Close()
    End Sub

    Private Sub loaddept()
        Label1.Text = "Nama Dept."
        Dim strsql, strkode, strnama, strfind As String
        Dim strkodedept As String

        ListView2.Columns.Clear()
        ListView2.Items.Clear()
        ListView2.View = Windows.Forms.View.Details
        ListView2.GridLines = True
        ListView2.FullRowSelect = True

        If txtfind.Text = "" Then
            strfind = "%"
        Else
            strfind = txtfind.Text
        End If

        ListView2.Columns.Add("Kode Dept.", 80)
        ListView2.Columns.Add("Nama Departemen", 190)
        ListView2.Columns.Add("Nama Divisi", 160)


        strsql = "exec spMstDepartement 'get',0,0,'%" & strfind & "%','" & StrNamaUser & "'"
        RsConn = Conn.Execute(strsql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()

            Do While Not RsConn.EOF


                strkodedept = RsConn("IdDepartement").Value
                strnama = RsConn("NamaDepartement").Value
                strkode = RsConn("NamaDivisi").Value
               
                Dim arr(3) As String
                Dim itm As ListViewItem

                arr(0) = strkodedept
                arr(1) = strnama
                arr(2) = strkode

                itm = New ListViewItem(arr)
                ListView2.Items.Add(itm)

                RsConn.MoveNext()

            Loop

        End If
        RsConn.Close()


    End Sub
    Private Sub LoadNomerReturDariToko()
        Label1.Text = "Nomor Retur"
        ListView2.Columns.Clear()
        ListView2.Items.Clear()
        ListView2.View = Windows.Forms.View.Details
        ListView2.GridLines = True
        ListView2.FullRowSelect = True

        If TxtFind.Text = "" Then
            strfind = "%"
        Else
            strfind = TxtFind.Text
        End If

        ListView2.Columns.Add("Nomor Retur", 160)
        ListView2.Columns.Add("Tanggal Retur", 260)



        sql = "exec spLpbDariTokoHeaderDetail 'Get',0,0," & kodetoko & ",0,'" & StrNamaUser & "'"
        RsConn = Conn.Execute(sql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()

            Do While Not RsConn.EOF
                strnama = RsConn("nomorRetur").Value
                strNama2 = RsConn("tglRetur").Value

                Dim arr(2) As String
                Dim itm As ListViewItem

                arr(0) = strnama
                arr(1) = strNama2

                itm = New ListViewItem(arr)
                ListView2.Items.Add(itm)

                RsConn.MoveNext()
            Loop

        End If
        RsConn.Close()
    End Sub

    Private Sub LoadNomerLpb()
        Label1.Text = "Nomor Lpb"
        ListView2.Columns.Clear()
        ListView2.Items.Clear()
        ListView2.View = Windows.Forms.View.Details
        ListView2.GridLines = True
        ListView2.FullRowSelect = True

        If TxtFind.Text = "" Then
            strfind = "%"
        Else
            strfind = TxtFind.Text
        End If

        ListView2.Columns.Add("Nomor Lpb", 100)
        ListView2.Columns.Add("Tanggal Lpb", 100)
        ListView2.Columns.Add("Nama Toko", 270)


        sql = "exec spLpbDariTokoHeaderDetail 'GetNoLpb',0,0,0,0,'%" & strfind & "%'"
        RsConn = Conn.Execute(sql)

        If Not RsConn.EOF Then
            RsConn.MoveFirst()

            Do While Not RsConn.EOF
                strnama = RsConn("nomorLpb").Value
                strNama2 = RsConn("tglLpb").Value

                Dim arr(2) As String
                Dim itm As ListViewItem

                arr(0) = strnama
                arr(1) = strNama2
                arr(2) = RsConn("namatoko").Value

                itm = New ListViewItem(arr)
                ListView2.Items.Add(itm)

                RsConn.MoveNext()
            Loop

        End If
        RsConn.Close()
    End Sub

    Private Sub loadNoNonRRAK()
        Label1.Text = "Nomor NON RRAK"
        ListView2.Columns.Clear()
        ListView2.Items.Clear()
        ListView2.View = Windows.Forms.View.Details
        ListView2.GridLines = True
        ListView2.FullRowSelect = True

        If TxtFind.Text = "" Then
            strfind = "%"
        Else
            strfind = TxtFind.Text
        End If

        ListView2.Columns.Add("Nomor", 160)
        ListView2.Columns.Add("Tanggal Buat", 100)
        ListView2.Columns.Add("Status", 100)

        If StrFrmPemanggil = "NoNonRRAK" Then
            sql = "exec spfind 'NoNonRRAK','" & kodetoko & "','x'"
        End If

        RsConn = Conn.Execute(sql)
        If Not RsConn.EOF Then
            RsConn.MoveFirst()
            Do While Not RsConn.EOF

                Dim arr(3) As String
                Dim itm As ListViewItem

                If StrFrmPemanggil = "NoNonRRAK" Then

                    arr(0) = RsConn("NoAliasNR").Value
                    arr(1) = Format(RsConn("TglCreate").Value, "dd-MM-yyyy")
                    If RsConn("StatusRealisasi").Value = 3 Then
                        arr(2) = "Approved"
                    ElseIf RsConn("StatusRealisasi").Value = 4 Then
                        arr(2) = "Approved"
                    Else
                        arr(2) = "Draft"
                    End If
                End If

                itm = New ListViewItem(arr)
                ListView2.Items.Add(itm)

                RsConn.MoveNext()
            Loop

        End If
        RsConn.Close()
    End Sub
    Private Sub loadNoRRAK()
        Label1.Text = "Nomor RRAK/ Kas Bon"
        ListView2.Columns.Clear()
        ListView2.Items.Clear()
        ListView2.View = Windows.Forms.View.Details
        ListView2.GridLines = True
        ListView2.FullRowSelect = True

        If TxtFind.Text = "" Then
            strfind = "%"
        Else
            strfind = TxtFind.Text
        End If

        ListView2.Columns.Add("Nomor", 160)
        ListView2.Columns.Add("Tanggal", 100)
        ListView2.Columns.Add("Status", 100)

        If StrFrmPemanggil = "NoRRAKE" Then
            sql = "exec spfind 'NoRRAKE','" & kodetoko & "','x'"
        ElseIf StrFrmPemanggil = "NoRRAKR" Then
            sql = "exec spfind 'NoRRAKR','" & kodetoko & "','x'"
        ElseIf StrFrmPemanggil = "NoKasBonE" Then
            sql = "exec spfind 'NoKasBonE','" & kodetoko & "','x'"
        ElseIf StrFrmPemanggil = "NoKasBonR" Then
            sql = "exec spfind 'NoKasBonR','" & kodetoko & "','x'"
        End If


        RsConn = Conn.Execute(sql)
        If Not RsConn.EOF Then
            RsConn.MoveFirst()
            Do While Not RsConn.EOF

                Dim arr(3) As String
                Dim itm As ListViewItem

                If StrFrmPemanggil = "NoRRAKE" Then
                    If Not IsDBNull(RsConn("NoAliasRR").Value) Then
                        arr(0) = RsConn("NoAliasRR").Value
                        arr(1) = Format(RsConn("tglcreate").Value, "dd-MM-yyyy")
                        If RsConn("statusestimasi").Value = 1 Then
                            arr(2) = "Draft"
                        ElseIf RsConn("statusestimasi").Value = 4 Then
                            arr(2) = "Dibatalkan"
                        Else
                            arr(2) = "Approved"
                        End If
                    End If
                ElseIf StrFrmPemanggil = "NoRRAKR" Then
                    If Not IsDBNull(RsConn("NoAliasRR").Value) Then
                        arr(0) = RsConn("NoAliasRR").Value
                        arr(1) = Format(RsConn("tglcreate").Value, "dd-MM-yyyy")
                        If RsConn("statusrealisasi").Value >= 2 Then
                            arr(2) = "Approved"
                        Else
                            arr(2) = "Draft"
                        End If
                    End If
                ElseIf StrFrmPemanggil = "NoKasBonE" Then

                    arr(0) = RsConn("NomerDokumen").Value
                    arr(1) = Format(RsConn("tglcreate").Value, "dd-MM-yyyy")
                    If RsConn("statusEstimasiCashBond").Value = 2 Then
                        arr(2) = "Approved"
                    Else
                        arr(2) = "Draft"
                    End If
                    ElseIf StrFrmPemanggil = "NoKasBonR" Then
                        arr(0) = RsConn("NomerDokumen").Value
                        arr(1) = Format(RsConn("tglcreate").Value, "dd-MM-yyyy")
                        If RsConn("statusRealisasiCashBond").Value = 2 Then
                            arr(2) = "Approved"
                        Else
                            arr(2) = "Draft"
                        End If
                        '    ''Nambah disini
                        'ElseIf StrFrmPemanggil = "NoNonRRAK" Then
                        '    arr(0) = RsConn("NomerDokumen").Value
                        '    arr(1) = Format(RsConn("tglcreate").Value, "dd-MM-yyyy")
                        '    If RsConn("statusRealisasiCashBond").Value = 2 Then
                        '        arr(2) = "Approved"
                        '    Else
                        '        arr(2) = "Draft"
                        '    End If
                    End If



                    itm = New ListViewItem(arr)
                    ListView2.Items.Add(itm)

                    RsConn.MoveNext()
            Loop

        End If
        RsConn.Close()
    End Sub


    Private Sub ListView2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView2.SelectedIndexChanged
        Dim z As Integer
        z = ListView2.SelectedItems.Count

        If z = 0 Then
            Exit Sub
        Else
            If StrFrmPemanggil = "MasterSupplier" Then
                StrReturnValue = ListView2.SelectedItems.Item(0).SubItems(0).Text
                Me.Close()
            ElseIf StrFrmPemanggil = "MasterSupplierRetur" Then
                StrReturnValue = ListView2.SelectedItems.Item(0).SubItems(0).Text
                Me.Close()
            ElseIf StrFrmPemanggil = "MasterSupplierJWK" Then
                StrReturnValue = ListView2.SelectedItems.Item(0).SubItems(1).Text
                Me.Close()
            ElseIf StrFrmPemanggil = "MasterProduk" Then
                StrReturnValue = ListView2.SelectedItems.Item(0).SubItems(0).Text
                Me.Close()
            ElseIf StrFrmPemanggil = "MasterKaryawan" Then
                StrReturnValue = ListView2.SelectedItems.Item(0).SubItems(0).Text
                Me.Close()
            ElseIf StrFrmPemanggil = "MasterDC" Then
                StrReturnValue = ListView2.SelectedItems.Item(0).SubItems(1).Text
                Me.Close()
            ElseIf StrFrmPemanggil = "MasterToko" Then
                StrReturnValue = ListView2.SelectedItems.Item(0).SubItems(0).Text
                Me.Close()
            ElseIf StrFrmPemanggil = "MasterPlanoToko" Then
                StrReturnValue = ListView2.SelectedItems.Item(0).SubItems(0).Text
                Me.Close()
            ElseIf StrFrmPemanggil = "ProdukGroupMgr" Then
                StrReturnValue = ListView2.SelectedItems.Item(0).SubItems(1).Text
                Me.Close()
            ElseIf StrFrmPemanggil = "JWKSupplierBySupp" Then
                StrReturnValue = ListView2.SelectedItems.Item(0).SubItems(1).Text
                Me.Close()
            ElseIf StrFrmPemanggil = "JWKSupplierByDC" Then
                StrReturnValue = ListView2.SelectedItems.Item(0).SubItems(1).Text
                Me.Close()
            ElseIf StrFrmPemanggil = "HargaBeli" Then
                StrReturnValue = ListView2.SelectedItems.Item(0).SubItems(0).Text
                Me.Close()
            ElseIf StrFrmPemanggil = "MasterSupplierHB" Then
                StrReturnValue = ListView2.SelectedItems.Item(0).SubItems(1).Text
                Me.Close()
            ElseIf StrFrmPemanggil = "PromoMulti" Then
                StrReturnValue = ListView2.SelectedItems.Item(0).SubItems(0).Text
                Me.Close()
            ElseIf StrFrmPemanggil = "KoreksiUPO" Then
                StrReturnValue = ListView2.SelectedItems.Item(0).SubItems(0).Text
                Me.Close()
            ElseIf StrFrmPemanggil = "NomorUPO" Then
                StrReturnValue = ListView2.SelectedItems.Item(0).SubItems(0).Text
                Me.Close()
            ElseIf StrFrmPemanggil = "NomorPO" Then
                StrReturnValue = ListView2.SelectedItems.Item(0).SubItems(0).Text
                Me.Close()
            ElseIf StrFrmPemanggil = "NomorPORCV" Then
                StrReturnValue = ListView2.SelectedItems.Item(0).SubItems(0).Text
                Me.Close()
            ElseIf StrFrmPemanggil = "NomorLPB" Then
                StrReturnValue = ListView2.SelectedItems.Item(0).SubItems(0).Text
                Me.Close()
            ElseIf StrFrmPemanggil = "NomorPOManual" Then
                StrReturnValue = ListView2.SelectedItems.Item(0).SubItems(0).Text
                Me.Close()
            ElseIf StrFrmPemanggil = "NomorUPOOto" Then
                StrReturnValue = ListView2.SelectedItems.Item(0).SubItems(0).Text
                Me.Close()
            ElseIf StrFrmPemanggil = "ProdukPOManual" Then
                StrReturnValue = ListView2.SelectedItems.Item(0).SubItems(0).Text
                Me.Close()
            ElseIf StrFrmPemanggil = "ProdukPaket" Then
                StrReturnValue = ListView2.SelectedItems.Item(0).SubItems(0).Text
                Me.Close()
            ElseIf StrFrmPemanggil = "DraftPOGO" Then
                StrReturnValue = ListView2.SelectedItems.Item(0).SubItems(0).Text
                Me.Close()
            ElseIf StrFrmPemanggil = "JWKBklToko" Then
                StrReturnValue = ListView2.SelectedItems.Item(0).SubItems(2).Text
                Me.Close()
            ElseIf StrFrmPemanggil = "NoTOManual" Then
                StrReturnValue = ListView2.SelectedItems.Item(0).SubItems(0).Text
                Me.Close()
            ElseIf StrFrmPemanggil = "NoTOManTMP" Then
                StrReturnValue = ListView2.SelectedItems.Item(0).SubItems(0).Text
                Me.Close()
            ElseIf StrFrmPemanggil = "LoadNomorReturToko" Then
                StrReturnValue = ListView2.SelectedItems.Item(0).SubItems(0).Text
                Me.Close()
            ElseIf StrFrmPemanggil = "LoadNomorLpb" Then
                StrReturnValue = ListView2.SelectedItems.Item(0).SubItems(0).Text
                Me.Close()
            ElseIf StrFrmPemanggil = "Masteruser" Then
                StrReturnValue = ListView2.SelectedItems.Item(0).SubItems(1).Text
                Me.Close()
            ElseIf StrFrmPemanggil = "LoadDataRetur" Then
                StrReturnValue = ListView2.SelectedItems.Item(0).SubItems(0).Text
                Me.Close()
            ElseIf StrFrmPemanggil = "NoLockSO" Then
                StrReturnValue = ListView2.SelectedItems.Item(0).SubItems(0).Text
                Me.Close()
            ElseIf StrFrmPemanggil = "NoAdjSOTmp" Then
                StrReturnValue = ListView2.SelectedItems.Item(0).SubItems(0).Text
                Me.Close()
            ElseIf StrFrmPemanggil = "NoAdjSO" Then
                StrReturnValue = ListView2.SelectedItems.Item(0).SubItems(0).Text
                Me.Close()
            ElseIf StrFrmPemanggil = "NoTObyPB" Then
                kodetoko = ListView2.SelectedItems.Item(0).SubItems(2).Text
                StrReturnValue = ListView2.SelectedItems.Item(0).SubItems(0).Text
                Me.Close()
            ElseIf StrFrmPemanggil = "NoTObyPBTMP" Then
                kodetoko = ListView2.SelectedItems.Item(0).SubItems(2).Text
                StrReturnValue = ListView2.SelectedItems.Item(0).SubItems(0).Text
                Me.Close()
            ElseIf StrFrmPemanggil = "NomorMutasiStock" Then
                StrReturnValue = ListView2.SelectedItems.Item(0).SubItems(0).Text
                Me.Close()
            ElseIf StrFrmPemanggil = "Masterprodukretur" Then
                StrReturnValue = ListView2.SelectedItems.Item(0).SubItems(0).Text
                Me.Close()
            ElseIf StrFrmPemanggil = "NoMutasiPaket" Then
                StrReturnValue = ListView2.SelectedItems.Item(0).SubItems(0).Text
                Me.Close()
            ElseIf StrFrmPemanggil = "NoUnPaket" Then
                StrReturnValue = ListView2.SelectedItems.Item(0).SubItems(0).Text
                Me.Close()
            ElseIf StrFrmPemanggil = "NoPL" Then
                kodetoko = ListView2.SelectedItems.Item(0).SubItems(2).Text
                StrReturnValue = ListView2.SelectedItems.Item(0).SubItems(0).Text
                NomorPB = ListView2.SelectedItems.Item(0).SubItems(4).Text
                Me.Close()
            ElseIf StrFrmPemanggil = "NoMutasiDC" Then
                StrReturnValue = ListView2.SelectedItems.Item(0).SubItems(1).Text
                Me.Close()
            Else
                StrReturnValue = ListView2.SelectedItems.Item(0).SubItems(0).Text
                Me.Close()
            End If

        End If
    End Sub

    Private Sub TxtFind_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFind.KeyPress
        If (e.KeyChar Like "[',]") Then e.Handled() = True
    End Sub

    Private Sub TxtFind_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFind.TextChanged
        Call cek()
    End Sub

    Private Sub cek()

        If StrFrmPemanggil = "MasterSupplier" Then
            Call LoadSupplier()
        End If

        If StrFrmPemanggil = "POManual" Then
            Call LoadSupplier()
        End If


        If StrFrmPemanggil = "MasterKaryawan" Then
            Call LoadKaryawan()
        End If

        If StrFrmPemanggil = "Masteruser" Then
            Call LoadKaryawan()
        End If

        If StrFrmPemanggil = "MasterSupplierRetur" Then
            Call LoadSupplier()
        End If

        If StrFrmPemanggil = "ProdukMutasi" Then
            Call LoadProduk()
        End If


        If StrFrmPemanggil = "Masterprodukretur" Then
            Call LoadProduk()
        End If

        If StrFrmPemanggil = "MasterProduk" Then
            Call LoadProduk()
        End If

        If StrFrmPemanggil = "MasterDC" Then
            Call LoadDC()
        End If

        If StrFrmPemanggil = "JWKBklToko" Then
            Call LoadToko()
        End If

        If StrFrmPemanggil = "MasterDCAll" Then
            Call LoadDC()
        End If

        If StrFrmPemanggil = "MasterToko" Then
            Call LoadToko()
        End If

        If StrFrmPemanggil = "MasterPlanoToko" Then
            Call LoadPlanoToko()
        End If

        If StrFrmPemanggil = "ProdukGroupMgr" Then
            Call loaddept()
        End If

        If StrFrmPemanggil = "JWKSupplierBySupp" Then
            Call LoadDC()
        End If

        If StrFrmPemanggil = "JWKSupplierByDC" Then
            Call LoadSupplier()
        End If

        If StrFrmPemanggil = "HargaBeli" Then
            Call loadHBSupplier()
        End If

        If StrFrmPemanggil = "MasterSupplierHB" Then
            Call LoadSupplier()
        End If
        If StrFrmPemanggil = "HargaJual" Then
            Call loadHBSupplier()
        End If

        If StrFrmPemanggil = "MasterSupplierJWK" Then
            Call LoadSupplier()
        End If

        If StrFrmPemanggil = "KoreksiUPO" Then
            Call LoadSupplier()
        End If

        If StrFrmPemanggil = "NomorUPO" Then
            Call LoadNomorUPO()
        End If

        If StrFrmPemanggil = "NomorUPOOto" Then
            Call LoadNomorUPO()
        End If

        If StrFrmPemanggil = "NomorPO" Then
            Call LoadNomorPO()
        End If

        If StrFrmPemanggil = "NomorPORCV" Then
            Call LoadNomorPO()
        End If

        If StrFrmPemanggil = "NomorLPB" Then
            Call LoadNomorLPB()
        End If

        If StrFrmPemanggil = "NomorPOManual" Then
            Call LoadNomorPO()
        End If

        If StrFrmPemanggil = "ProdukPOManual" Then
            Call LoadProduk()
        End If

        If StrFrmPemanggil = "ProdukPaket" Then
            Call LoadProduk()
        End If

        If StrFrmPemanggil = "NoTOManual" Then
            Call LoadNomorTO()
        End If

        If StrFrmPemanggil = "NoTOManTMP" Then
            Call LoadNomorTO()
        End If

        If StrFrmPemanggil = "LoadNomorReturToko" Then
            Call LoadNomerReturDariToko()
        End If

        If StrFrmPemanggil = "DraftPOGO" Then
            Call LoadProduk()
        End If

        If StrFrmPemanggil = "LoadNomerLpb" Then
            Call LoadNomerLpb()
        End If
        If StrFrmPemanggil = "LoadDataRetur" Then
            Call LoadataRetur()
        End If
        If StrFrmPemanggil = "NoTObyPB" Then
            Call LoadNomorTO()
        End If

        If StrFrmPemanggil = "NoTObyPBTMP" Then
            Call LoadNomorTO()
        End If

        If StrFrmPemanggil = "NoPL" Then
            Call LoadNoPL()
        End If

        If StrFrmPemanggil = "NoLockSO" Then
            Call LoadNoLock()
        End If

        If StrFrmPemanggil = "NoAdjSOTmp" Then
            Call LoadNoLock()
        End If

        If StrFrmPemanggil = "NoAdjSO" Then
            Call LoadNoAdj()
        End If

        If StrFrmPemanggil = "NomorMutasiStock" Then
            Call LoadNomorMutasi()
        End If
        If StrFrmPemanggil = "NoUnPaket" Then
            Call LoadNoMutasiPaket()
        End If

        If StrFrmPemanggil = "NoMutasiPaket" Then
            Call LoadNoMutasiPaket()
        End If
        If StrFrmPemanggil = "NoNonRRAK" Then
            Call loadNoNonRRAK()
        End If
        If StrFrmPemanggil = "NoRRAKE" Then
            Call loadNoRRAK()
        End If

        If StrFrmPemanggil = "NoRRAKR" Then
            Call loadNoRRAK()
        End If

        If StrFrmPemanggil = "NoKasBonR" Or StrFrmPemanggil = "NoKasBonE" Then
            Call loadNoRRAK()
        End If

        If StrFrmPemanggil = "JwkBkl" Then
            Call LoadToko()
        End If

        If StrFrmPemanggil = "NoMutasiDC" Then
            Call LoadMutasiDCOut()
        End If
        If StrFrmPemanggil = "NoMutasiDCLain" Then
            Call LoadNoMutasiDCOut()
        End If
        If StrFrmPemanggil = "LoadLpbMutasi" Then
            Call LoadNoMutasiIn()
        End If


    End Sub

    Private Sub FrmFind_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TxtFind.Clear()
        If Conn.State = 0 Then
            Call GetStringKoneksi()
            Conn.Open(StrKoneksi)
        End If
        Me.Panel1.BackColor = Color.SkyBlue
        Me.BackgroundImage = System.Drawing.Image.FromFile(bg)

        Call cek()
    End Sub
End Class