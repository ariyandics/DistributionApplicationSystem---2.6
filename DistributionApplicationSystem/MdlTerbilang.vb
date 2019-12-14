Module MdlTerbilang
  
    Public Function TERBILANGG(ByVal x As Double) As String
        Dim tampung As Double
        Dim teks As String
        Dim bagian As String
        Dim i As Integer
        Dim tanda As Boolean

        Dim letak(5)
        letak(1) = "RIBU "
        letak(2) = "JUTA "
        letak(3) = "MILYAR "
        letak(4) = "TRILYUN "

        If (x < 0) Then
            TERBILANGG = ""
            Exit Function
        End If

        If (x = 0) Then
            TERBILANGG = "NOL"
            Exit Function
        End If

        If (x < 2000) Then
            tanda = True
        End If
        teks = ""

        If (x >= 1.0E+15) Then
            TERBILANGG = "NILAI TERLALU BESAR"
            Exit Function
        End If

        For i = 4 To 1 Step -1
            tampung = Int(x / (10 ^ (3 * i)))
            If (tampung > 0) Then
                bagian = ratusan(tampung, tanda)
                teks = teks & bagian & letak(i)
            End If
            x = x - tampung * (10 ^ (3 * i))
        Next

        teks = teks & ratusan(x, False)
        TERBILANGG = teks & "RUPIAH"
    End Function

    Function ratusan(ByVal y As Double, ByVal flag As Boolean) As String
        Dim tmp As Double
        Dim bilang As String
        Dim bag As String
        Dim j As Integer

        Dim angka(9)
        angka(1) = "SE"
        angka(2) = "DUA "
        angka(3) = "TIGA "
        angka(4) = "EMPAT "
        angka(5) = "LIMA "
        angka(6) = "ENAM "
        angka(7) = "TUJUH "
        angka(8) = "DELAPAN "
        angka(9) = "SEMBILAN "

        Dim posisi(2)
        posisi(1) = "PULUH "
        posisi(2) = "RATUS "

        bilang = ""
        For j = 2 To 1 Step -1
            tmp = Int(y / (10 ^ j))
            If (tmp > 0) Then
                bag = angka(tmp)
                If (j = 1 And tmp = 1) Then
                    y = y - tmp * 10 ^ j
                    If (y >= 1) Then
                        posisi(j) = "BELAS "
                    Else
                        angka(y) = "SE"
                    End If
                    bilang = bilang & angka(y) & posisi(j)
                    ratusan = bilang
                    Exit Function
                Else
                    bilang = bilang & bag & posisi(j)
                End If
            End If
            y = y - tmp * 10 ^ j
        Next

        If (flag = False) Then
            angka(1) = "SATU "
        End If
        bilang = bilang & angka(y)
        ratusan = bilang
    End Function

    Public Function AmbilSblmKoma(ByVal NilaiNya As Decimal) As Decimal
        Dim hSl As Decimal

        hSl = Right(NilaiNya, 2)
        Return hSl

    End Function

    Public Function TerbilangDesimal(ByVal InputCurrency As String, Optional ByVal MataUang As String = "Rupiah") As String
        Dim strInput As String
        Dim strBilangan As String
        Dim strPecahan As String
        On Error GoTo Pesan

        If InputCurrency = "" Then Exit Function
        'If Len(Trim(InputCurrency)) > 15 Then GoTo Pesan

        strInput = CStr(InputCurrency) 'Konversi ke string
        'Periksa apakah ada tanda "," jika ya berarti pecahan
        If InStr(1, strInput, ",", vbBinaryCompare) Then

            strBilangan = Left(strInput, InStr(1, strInput, _
                          ",", vbBinaryCompare) - 1)

            'strBilangan = Right(strInput, InStr(1, strInput, _
            '              ".", vbBinaryCompare) - 2)
            strPecahan = Trim(Right(strInput, Len(strInput) - Len(strBilangan) - 1))

            If MataUang <> "" Then

                If CLng(Trim(strPecahan)) > 99 Then
                    strInput = Format(Math.Round(CDbl(strInput), 2), "#0.00")
                    strPecahan = Format((Right(strInput, Len(strInput) - Len(strBilangan) - 1)), "00")
                End If

                If Len(Trim(strPecahan)) = 1 Then
                    strInput = Format(Math.Round(CDbl(strInput), 2), _
                               "#0.00")
                    strPecahan = Format((Right(strInput, _
                       Len(strInput) - Len(strBilangan) - 1)), "00")
                End If

                If CLng(Trim(strPecahan)) = 0 Then
                    TerbilangDesimal = (KonversiBilangan(strBilangan) & MataUang & " " & KonversiBilangan(strPecahan))
                Else
                    TerbilangDesimal = (KonversiBilangan(strBilangan) & MataUang & " koma " & KonversiBilangan(strPecahan))
                End If
            Else
                TerbilangDesimal = (KonversiBilangan(strBilangan) & "koma " & KonversiPecahan(strPecahan))
            End If

        ElseIf InStr(1, strInput, ".", vbBinaryCompare) Then

            strBilangan = Left(strInput, InStr(1, strInput, _
                          ".", vbBinaryCompare) - 1)
            'strBilangan = Right(strInput, InStr(1, strInput, _
            '              ".", vbBinaryCompare) - 2)
            strPecahan = Trim(Right(strInput, Len(strInput) - Len(strBilangan) - 1))

            If MataUang <> "" Then

                If CLng(Trim(strPecahan)) > 99 Then
                    strInput = Format(Math.Round(CDbl(strInput), 2), "#0.00")
                    strPecahan = Format((Right(strInput, Len(strInput) - Len(strBilangan) - 1)), "00")
                End If

                If Len(Trim(strPecahan)) = 1 Then
                    strInput = Format(Math.Round(CDbl(strInput), 2), _
                               "#0.00")
                    strPecahan = Format((Right(strInput, _
                       Len(strInput) - Len(strBilangan) - 1)), "00")
                End If

                If CLng(Trim(strPecahan)) = 0 Then
                    TerbilangDesimal = (KonversiBilangan(strBilangan) & MataUang & " " & KonversiBilangan(strPecahan))
                Else
                    TerbilangDesimal = (KonversiBilangan(strBilangan) & MataUang & " koma " & KonversiBilangan(strPecahan))
                End If
            Else
                TerbilangDesimal = (KonversiBilangan(strBilangan) & "koma " & KonversiPecahan(strPecahan))
            End If

        Else
            TerbilangDesimal = (KonversiBilangan(strInput))
        End If
        Exit Function
Pesan:
        TerbilangDesimal = "(maksimal 15 digit)"
    End Function

    'Fungsi ini untuk mengkonversi nilai pecahan (setelah 'angka 0)
    Private Function KonversiPecahan(ByVal strAngka As String) As String
        Dim i%, strJmlHuruf$, Urai$, Kar$
        If strAngka = "" Then Exit Function
        strJmlHuruf = Trim(strAngka)
        Urai = ""
        Kar = ""
        For i = 1 To Len(strJmlHuruf)
            'Tampung setiap satu karakter ke Kar
            Kar = Mid(strAngka, i, 1)
            Urai = Urai & Kata(CInt(Kar))
        Next i
        KonversiPecahan = Urai
    End Function


    'Fungsi ini untuk menterjemahkan setiap satu angka ke 'kata
    Private Function Kata(ByVal angka As Byte) As String
        Select Case angka
            Case 1 : Kata = "satu "
            Case 2 : Kata = "dua "
            Case 3 : Kata = "tiga "
            Case 4 : Kata = "empat "
            Case 5 : Kata = "lima "
            Case 6 : Kata = "enam "
            Case 7 : Kata = "tujuh "
            Case 8 : Kata = "delapan "
            Case 9 : Kata = "sembilan "
            Case 0 : Kata = "nol "
        End Select
    End Function

    'Ini untuk mengkonversi nilai bilangan sebelum pecahan
    Private Function KonversiBilangan(ByVal strAngka As String) As String
        Dim strJmlHuruf, strPecahan, Urai, Bil1, strTot, Bil2 As String
        Dim intPecahan As Integer
        Dim X, Y, z As Integer

        If strAngka = "" Then Exit Function
        strJmlHuruf = Trim(strAngka)
        X = 0
        Y = 0
        Urai = ""
        While (X < Len(strJmlHuruf))
            X = X + 1
            strTot = Mid(strJmlHuruf, X, 1)
            Y = Y + Val(strTot)
            z = Len(strJmlHuruf) - X + 1
            Select Case Val(strTot)
                'Case 0
                '   Bil1 = "NOL "
                Case 1
                    If (z = 1 Or z = 7 Or z = 10 Or z = 13) Then
                        Bil1 = "satu "
                    ElseIf (z = 4) Then
                        If (X = 1) Then
                            Bil1 = "se"
                        Else
                            Bil1 = "satu "
                        End If
                    ElseIf (z = 2 Or z = 5 Or z = 8 Or z = 11 Or z = 14) Then
                        X = X + 1
                        strTot = Mid(strJmlHuruf, X, 1)
                        z = Len(strJmlHuruf) - X + 1
                        Bil2 = ""
                        Select Case Val(strTot)
                            Case 0
                                Bil1 = "sepuluh "
                            Case 1
                                Bil1 = "sebelas "
                            Case 2
                                Bil1 = "dua belas "
                            Case 3
                                Bil1 = "tiga belas "
                            Case 4
                                Bil1 = "empat belas "
                            Case 5
                                Bil1 = "lima belas "
                            Case 6
                                Bil1 = "enam belas "
                            Case 7
                                Bil1 = "tujuh belas "
                            Case 8
                                Bil1 = "delapan belas "
                            Case 9
                                Bil1 = "sembilan belas "
                        End Select
                    Else
                        Bil1 = "se"
                    End If

                Case 2
                    Bil1 = "dua "
                Case 3
                    Bil1 = "tiga "
                Case 4
                    Bil1 = "empat "
                Case 5
                    Bil1 = "lima "
                Case 6
                    Bil1 = "enam "
                Case 7
                    Bil1 = "tujuh "
                Case 8
                    Bil1 = "delapan "
                Case 9
                    Bil1 = "sembilan "
                Case Else
                    Bil1 = ""
            End Select

            If (Val(strTot) > 0) Then
                If (z = 2 Or z = 5 Or z = 8 Or z = 11 Or z = 14) Then
                    Bil2 = "puluh "
                ElseIf (z = 3 Or z = 6 Or z = 9 Or z = 12 Or z = 15) Then
                    Bil2 = "ratus "
                Else
                    Bil2 = ""
                End If
            Else
                Bil2 = ""
            End If
            If (Y > 0) Then
                Select Case z
                    Case 4
                        Bil2 = Bil2 + "ribu "
                        Y = 0
                    Case 7
                        Bil2 = Bil2 + "juta "
                        Y = 0
                    Case 10
                        Bil2 = Bil2 + "milyar "
                        Y = 0
                    Case 13
                        Bil2 = Bil2 + "trilyun "
                        Y = 0
                End Select
            End If
            Urai = Urai + Bil1 + Bil2
        End While
        KonversiBilangan = Urai
    End Function
End Module
