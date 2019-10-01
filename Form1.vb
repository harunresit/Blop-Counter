Public Class Form1

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim bmp As New Bitmap(PictureBox1.Width, PictureBox1.Height) '211 239
        bmp = PictureBox1.Image
        For i = 0 To PictureBox1.Height - 1
            For j = 0 To PictureBox1.Width - 1
                If ((CInt(bmp.GetPixel(j, i).R) + CInt(bmp.GetPixel(j, i).G) + CInt(bmp.GetPixel(j, i).B)) / 3) > 240 Then
                    bmp.SetPixel(j, i, Color.White)
                Else
                    bmp.SetPixel(j, i, Color.Black)
                End If
            Next
        Next
        PictureBox1.Image = bmp
        Dim save = New SaveFileDialog()
        save.Filter = "Bitmap files (*.bmp)|*.bmp|JPG files (*.jpg)|*.jpg|GIF files (*.gif)|*.gif|All files (*.*)|*.*"
        save.FilterIndex = 4
        save.RestoreDirectory = True

        If (save.ShowDialog() = DialogResult.OK) Then
            PictureBox1.Image.Save(save.FileName)
        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim bmp As New Bitmap(PictureBox1.Width, PictureBox1.Height) '211 239
        Dim bmp1 As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        bmp = PictureBox1.Image
        Dim original(PictureBox1.Width - 1, PictureBox1.Height - 1) As Byte
        Dim newbmp(PictureBox1.Width - 1, PictureBox1.Height - 1) As Byte
        Dim renk As Color
        For i = 0 To PictureBox1.Height - 1
            For j = 0 To PictureBox1.Width - 1
                original(j, i) = bmp.GetPixel(j, i).R
            Next
        Next
        For x = 0 To 9
            For i = 0 To PictureBox1.Height - 1
                For j = 0 To PictureBox1.Width - 1
                    newbmp(j, i) = 255
                Next
            Next
            For i = 1 To PictureBox1.Height - 2
                For j = 1 To PictureBox1.Width - 2
                    If bmp.GetPixel(j - 1, i - 1).R = 0 And bmp.GetPixel(j, i - 1).R = 0 And bmp.GetPixel(j + 1, i - 1).R = 0 And bmp.GetPixel(j - 1, i).R = 0 And bmp.GetPixel(j, i).R = 0 And bmp.GetPixel(j + 1, i).R = 0 And bmp.GetPixel(j - 1, i + 1).R = 0 And bmp.GetPixel(j, i + 1).R = 0 And bmp.GetPixel(j + 1, i + 1).R = 0 Then
                        newbmp(j, i) = 0
                    End If
                Next
            Next
            For i = 0 To PictureBox1.Height - 1
                For j = 0 To PictureBox1.Width - 1
                    renk = Color.FromArgb(newbmp(j, i), newbmp(j, i), newbmp(j, i))
                    bmp.SetPixel(j, i, renk)
                Next
            Next
        Next
        For i = 0 To PictureBox1.Height - 1
            For j = 0 To PictureBox1.Width - 1
                newbmp(j, i) = 255
            Next
        Next
        For i = 0 To PictureBox1.Height - 1
            For j = 0 To PictureBox1.Width - 1
                If original(j, i) = 0 And bmp.GetPixel(j, i).R = 255 Then
                    newbmp(j, i) = 0
                End If
            Next
        Next
        For i = 0 To PictureBox1.Height - 1
            For j = 0 To PictureBox1.Width - 1
                renk = Color.FromArgb(newbmp(j, i), newbmp(j, i), newbmp(j, i))
                bmp.SetPixel(j, i, renk)
            Next
        Next
        PictureBox2.Image = bmp
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim bmp As New Bitmap(PictureBox2.Width, PictureBox2.Height)
        bmp = PictureBox2.Image
        Dim newbmp(PictureBox2.Width - 1, PictureBox2.Height - 1) As Byte
        Dim renk As Color
        For x = 0 To 4
            For i = 0 To PictureBox2.Height - 1
                For j = 0 To PictureBox2.Width - 1
                    newbmp(j, i) = 255
                Next
            Next
            For i = 1 To PictureBox2.Height - 2
                For j = 1 To PictureBox2.Width - 2
                    If bmp.GetPixel(j - 1, i - 1).R = 0 And bmp.GetPixel(j, i - 1).R = 0 And bmp.GetPixel(j + 1, i - 1).R = 0 And bmp.GetPixel(j - 1, i).R = 0 And bmp.GetPixel(j, i).R = 0 And bmp.GetPixel(j + 1, i).R = 0 And bmp.GetPixel(j - 1, i + 1).R = 0 And bmp.GetPixel(j, i + 1).R = 0 And bmp.GetPixel(j + 1, i + 1).R = 0 Then
                        newbmp(j, i) = 0
                    End If
                Next
            Next
            For i = 0 To PictureBox1.Height - 1
                For j = 0 To PictureBox1.Width - 1
                    renk = Color.FromArgb(newbmp(j, i), newbmp(j, i), newbmp(j, i))
                    bmp.SetPixel(j, i, renk)
                Next
            Next
        Next
        PictureBox2.Image = bmp
        Dim save = New SaveFileDialog()
        save.Filter = "Bitmap files (*.bmp)|*.bmp|JPG files (*.jpg)|*.jpg|GIF files (*.gif)|*.gif|All files (*.*)|*.*"
        save.FilterIndex = 4
        save.RestoreDirectory = True

        If (save.ShowDialog() = DialogResult.OK) Then
            PictureBox2.Image.Save(save.FileName)
        End If
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Dim bmp As New Bitmap(211, 239) '211, 239
        bmp = PictureBox2.Image
        Dim renk As Color
        'yatay için
        For i = 0 To 238 '238  'yani diyorum ki (pixelin kendi beyaz ve sağındaki piksel siyahsa) veya (kendi beyaz solundaki piksel siyahsa)
            For j = 1 To 209 '209
                If (bmp.GetPixel(j, i).R = 255 And bmp.GetPixel(j, i).G = 255 And bmp.GetPixel(j, i).B = 255 And bmp.GetPixel(j + 1, i).R = 0 And bmp.GetPixel(j + 1, i).G = 0 And bmp.GetPixel(j + 1, i).B = 0) Or (bmp.GetPixel(j, i).R = 255 And bmp.GetPixel(j, i).G = 255 And bmp.GetPixel(j, i).B = 255 And bmp.GetPixel(j - 1, i).R = 0 And bmp.GetPixel(j - 1, i).G = 0 And bmp.GetPixel(j - 1, i).B = 0) Then
                    renk = Color.FromArgb(255, 0, 0)
                    bmp.SetPixel(j, i, renk) 'o pikseli kırmızı yap
                End If
            Next
        Next
        'dikey için 
        For j = 0 To 210 '210  'yani diyorum ki (pikselin kendi beyaz üstündeki piksel siyahsa) veya (kendi beyaz altındaki piksel siyahsa)
            For i = 1 To 237 '237
                If (bmp.GetPixel(j, i).R = 255 And bmp.GetPixel(j, i).G = 255 And bmp.GetPixel(j, i).B = 255 And bmp.GetPixel(j, i - 1).R = 0 And bmp.GetPixel(j, i - 1).G = 0 And bmp.GetPixel(j, i - 1).B = 0) Or (bmp.GetPixel(j, i).R = 255 And bmp.GetPixel(j, i).G = 255 And bmp.GetPixel(j, i).B = 255 And bmp.GetPixel(j, i + 1).R = 0 And bmp.GetPixel(j, i + 1).G = 0 And bmp.GetPixel(j, i + 1).B = 0) Then
                    renk = Color.FromArgb(255, 0, 0)
                    bmp.SetPixel(j, i, renk) 'o pikseli kırmızı yap
                End If
            Next
        Next
        'siyah pixelleri yok etmek için
        For i = 0 To 238 '238
            For j = 0 To 210 '210
                If bmp.GetPixel(j, i).R = 0 Then
                    bmp.SetPixel(j, i, Color.White)
                End If
            Next
        Next
        PictureBox2.Image = bmp
        Dim save = New SaveFileDialog()
        save.Filter = "Bitmap files (*.bmp)|*.bmp|JPG files (*.jpg)|*.jpg|GIF files (*.gif)|*.gif|All files (*.*)|*.*"
        save.FilterIndex = 4
        save.RestoreDirectory = True

        If (save.ShowDialog() = DialogResult.OK) Then
            PictureBox2.Image.Save(save.FileName)
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim bmp As New Bitmap(211, 239) '211, 239
        bmp = PictureBox2.Image
        Dim toplamparmak As Integer = 0
        Dim parmakji(210, 238) As Integer '238 , 210
        Dim ilkparmakj As Integer
        Dim ilkparmaki As Integer
        For i = 0 To 238  '238
            For j = 0 To 210 '210
                If bmp.GetPixel(j, i).R = 255 And bmp.GetPixel(j, i).G = 0 And bmp.GetPixel(j, i).B = 0 Then 'burada kırmızı bir piksele geliyoruz
                    'bu piksele daha önce geldik mi diye bakıyoruz 
                    If parmakji(j, i) = 1 Then
                        GoTo cikis
                    End If
                    ilkparmakj = j
                    ilkparmaki = i
                    While (1) 'gelmediysek kod buraya gelecek
                        parmakji(j, i) = 1
                        If bmp.GetPixel(j - 1, i).G = 0 And Not parmakji(j - 1, i) = 1 Then 'sol
                            j -= 1
                        ElseIf bmp.GetPixel(j - 1, i - 1).G = 0 And Not parmakji(j - 1, i - 1) = 1 Then 'sol üst çapraz
                            i -= 1
                            j -= 1
                        ElseIf bmp.GetPixel(j, i - 1).G = 0 And Not parmakji(j, i - 1) = 1 Then  'üst
                            i -= 1
                        ElseIf bmp.GetPixel(j + 1, i - 1).G = 0 And Not parmakji(j + 1, i - 1) = 1 Then 'sağ üst çapraz
                            j += 1
                            i -= 1
                        ElseIf bmp.GetPixel(j + 1, i).G = 0 And Not parmakji(j + 1, i) = 1 Then 'sağ
                            j += 1
                        ElseIf bmp.GetPixel(j + 1, i + 1).G = 0 And Not parmakji(j + 1, i + 1) = 1 Then 'sağ alt çapraz
                            j += 1
                            i += 1
                        ElseIf bmp.GetPixel(j, i + 1).G = 0 And Not parmakji(j, i + 1) = 1 Then 'alt
                            i += 1
                        ElseIf bmp.GetPixel(j - 1, i + 1).G = 0 And Not parmakji(j - 1, i + 1) = 1 Then 'sol alt çapraz
                            j -= 1
                            i += 1
                        Else
                            toplamparmak += 1
                            j = ilkparmakj
                            i = ilkparmaki
                            Exit While
                        End If
                    End While
cikis:
                End If
            Next
        Next
        toplamparmak = (toplamparmak) / 2 'toplam nesne sayısı olması gerekenin 2 katı çıkıyor (nedenini bilmiyorum) o yüzden 2 ye böldük
        MsgBox(toplamparmak)
    End Sub
End Class
