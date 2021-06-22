Public Class Form2
    ' v instanca klase velicine u kojoj se nalaze vrijednosti za velicine raznih objekata, u ovom slucaju koristice se velicina panela
    Public v As New velicine
    '  Dim p(Form1.int_n - 1, Form1.int_m - 1) As P
    '  Public t(Form1.int_n - 1, Form1.int_m - 1) As T
    Public d As Matrica = New Matrica
    Public s(,) As PictureBox
    Public ii, jj As Integer
    Public maskaa As Maska = New Maska
    Public int_maska(,) As Integer
    Public org As Orginal_Matrica
    Public aktivirano_dugme As Boolean = False
    Public i_dugme, j_dugme As Integer
    Public got(,) As Integer
    Public skin As Integer = Form1.skin
    Public slika As PictureBox
    Public desna_granica, gornja_granica As Integer
    Public smanjuj As Boolean = True
    Public povecavaj As Boolean
    Public visina As Integer = Me.Height
    Public duzina As Integer = Me.Width
    Public promijenjena As Boolean = False
    Public start As Boolean = False

    Public n As Integer = Form1.int_n
    Public m As Integer = Form1.int_m

    Public sec As String = ""
    Public min As String = ""

    Public raspored() As Char = Form1.f1_raspored
    Public resenje As String = Form1.f1_resenje
    Public uneseni As String = Form1.f1_uneseni
    Public fil As Integer = Form1.fil       ' 1 generisanje igre, 0 startovanje iz file-a
    Public Sub Markiraj_Pogresne()
        Dim i, j As Integer
        If Form1.int_stanje Mod 2 = 0 Then
            For i = 0 To n - 1
                For j = 0 To m - 1
                    If int_maska(i, j) = 0 Then
                        If d.tabela(i, j).lb.text <> "" Then
                            If org.prava_matrica(i, j) <> CInt(d.tabela(i, j).lb.text) Then
                                ' d.tabela(i, j).lb.Font = New System.Drawing.Font("Verdana", 18, FontStyle.Italic)
                                d.tabela(i, j).lb.ForeColor = Color.Red
                            End If
                        End If
                    End If
                Next
            Next

        End If
        Me.Focus()
    End Sub
    Public Sub Pocrni(ByVal ii As Integer, ByVal jj As Integer)
        Dim i, j As Integer
        If ii = 0 And jj = 0 Then
            For i = 0 To n - 1
                For j = 0 To m - 1
                    If int_maska(i, j) = 0 Then
                        If org.prava_matrica(i, j) <> CInt(d.tabela(i, j).lb.text) Then
                            d.tabela(i, j).lb.ForeColor = Color.Black
                        End If
                    End If
                Next
            Next
        Else

        End If
    End Sub
    Public Sub Rijesi()
        Dim i, j As Integer
        Dim br As Integer = 0
        If Form1.int_stanje Mod 2 = 0 Then
            For i = 0 To n - 1
                For j = 0 To m - 1
                    If int_maska(i, j) = 0 Then
                        d.tabela(i, j).lb.text = got(i, j)
                    End If
                Next
            Next

        End If
    End Sub
    Public Function Napravi_Integer_Masku(ByVal n As Integer, ByVal m As Integer, ByVal s() As Char) As Array
        Dim i, j, br As Integer
        Dim int_matrica(,) As Integer
        ReDim int_matrica(n, m)
        br = 0
        For i = 0 To n - 1
            For j = 0 To m - 1
                int_matrica(i, j) = Val(s(br))
                br += 1
            Next
        Next
        Return int_matrica
    End Function
    Public Function Napravi_String_Od_Intreger_Maske(ByVal n As Integer, ByVal m As Integer, ByVal int_maska(,) As Integer) As String
        Dim i, j As Integer
        Dim raspored As String
        For i = 0 To n - 1
            For j = 0 To m - 1
                raspored = raspored & int_maska(i, j).ToString
            Next
        Next
        Return raspored
    End Function
    ' Postavlja formu na odredjenu poziciju na ekranu, odredjuje skin i ostale parametre vezane za izgled
    Public Sub Pozicioniraj()
        slika = New PictureBox
        slika.Image = Form1.f2_slika
        slika.Location = New System.Drawing.Point(30, 30)
        slika.Size = New System.Drawing.Size((Form1.int_m * v.polje), (Form1.int_n * v.polje))
        Me.Controls.Add(slika)
        slika.BringToFront()
        AddHandler Me.MouseDown, AddressOf Me.Form2_Load
        v.f2_aktivna = True
        Dim sirina As Integer = Me.Width
        Dim sredina As String = " "
        Dim ii As Integer
        For ii = 0 To (Me.Width / 5)
            sredina += " "
        Next
        '    sredina = Me.Width / 2
        '  Me.Text = sredina & "K A K U R O"

        Dim pomjerajx, pomjerajy As Double
        Select Case n * m
            Case 48
                pomjerajx = 0.35
                pomjerajy = 0.1
            Case 80
                pomjerajx = 0.32
                pomjerajy = 0.1
            Case 120
                pomjerajx = 0.25
                pomjerajy = 0.05
            Case 144
                pomjerajx = 0.2
                pomjerajy = 0.05
        End Select
        Me.Location = New System.Drawing.Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width() * pomjerajx, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height() * pomjerajy)
        Dim granica As Integer = pomjerajx * 100
        desna_granica = (Form1.int_m + 2) * v.polje + System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width() * pomjerajx
        gornja_granica = pomjerajy + (Form1.int_n + 2) * v.polje / 3
        '   Form5.TextBox5.Text = desna_granica
        Form1.Location = New System.Drawing.Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width() * pomjerajx - 220, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height() * 0.2)

        Form3.Location = New System.Drawing.Point(900, 100)
        Me.MaximumSize = New System.Drawing.Size((Form1.int_m) * v.polje + 72, (Form1.int_n) * v.polje + 72)
        Me.Size = New System.Drawing.Size((Form1.int_m) * v.polje + 72, (Form1.int_n) * v.polje + 72)
        '        Panel1.Size = New System.Drawing.Size((Form1.int_m) * v.polje + 80, (Form1.int_n) * v.polje + 100)
        Panel1.Size = New System.Drawing.Size((Form1.int_m) * v.polje + 80, (Form1.int_n) * v.polje + 100)

        '   Select Case skin
        '       Case 1      ' brown 
        Form3.Label1.BackColor = Form1.f3_labele_color
        Panel1.BackColor = Form1.f3_backgroung_color
        '     Me.Refresh()
        '      Case 2      ' black
        '     Panel1.BackColor = Color.Silver  'silver
        '    Form3.Label1.BackColor = Color.Black
        If Not Form3.labela_preostalih Is Nothing Then
            Form3.labela_preostalih.BackColor = Form1.f3_labele_color
        End If

        Form3.Refresh()
        '   Me.Refresh()
        '        Case 3
        '  End Select
        ' Panel1.BringToFront()
        ' slika.BringToFront()
        ' Me.Refresh()
    End Sub
    Public Sub Kreiraj_Igru_Iz_Postojecih_Podataka(ByVal slucajan As Integer)
        ' org.generisi_matricu(Form1.int_n, Form1.int_m, int_maska)
        ' matrica sa rasporedom koji sam rucno unio
        got = org.gotova_matrica(Form1.int_n, Form1.int_m, slucajan, Form1.tezina, raspored)
    End Sub
    Public Sub Kreiraj_Igru_Iz_File_a()
        got = org.gotova_matrica_iz_file_a(Form1.int_n, Form1.int_m, resenje, raspored)
    End Sub
    Public Sub Kreiraj_Igru_Pomocu_Backtracka(ByVal n As Integer, ByVal m As Integer, ByVal int_maska(,) As Integer)
        '  org = New Orginal_Matrica(Form1.int_n - 1, Form1.int_m - 1, raspored)
        '     Dim stringic As String                                                    ' odje se radi
        got = org.Generisi_matricu_slucajnih_brojeva(Form1.int_n, Form1.int_m, int_maska)
    End Sub
    Public Sub Startuj_Igru_Od_Pocetka()
        Dim randomNum As New Random
        Dim slucajan As Integer
        slucajan = randomNum.Next(1, 10)
        'raspored je string dobijen iz funkcije Vrati_Masku iz klase Maska, predstavlja raspored punih i praznih polja 
        'zavisi od slucajnog broja, i tezine koja je izabrana na form1
        'raspored = maskaa.Vrati_Masku(Form1.int_m, Form1.int_n, 1, Form1.tezina)
        raspored = maskaa.Vrati_Masku(Form1.int_m, Form1.int_n, slucajan, Form1.tezina)

        ' raspored u formi matrice integer-a, raspored se cuva u formi stringa
        ' funkcija Napravi_Integer_Masku kreira matricu integer-a u koju se upisuju vrijednosti iz stringa u kome se cuva raspored
        int_maska = Napravi_Integer_Masku(n, m, raspored)

        ' objekat koji predstavlja orginalnu matricu sa inicijalnim vrijednostima
        ' ova matrica ima elemente koji su -1 * maska
        ' tj. negativne vrijednosti matrice maska 
        org = New Orginal_Matrica(Form1.int_n - 1, Form1.int_m - 1, raspored)

        '    postoje dva nacina za generisanje matrice sa slucajnim brojevima 
        '1.  Iz postojecih podataka
        '2.  Generisanje pomocu Backtrackinga
        If Form1.backtrack = False Then

            Kreiraj_Igru_Iz_Postojecih_Podataka(slucajan)

        Else
            Kreiraj_Igru_Pomocu_Backtracka(n, m, int_maska)
        End If
        '  Kreiraj_Igru_Pomocu_Backtracka(n, m, int_maska)
        '    Form1.Button6.PerformClick()
        n = Form1.int_n
        m = Form1.int_m
        '  Form5.TextBox4.Text = n & " x " & m
        Dim i, j As Integer
        Dim X, Y, xx, yy As Integer
        ReDim d.tabela(n, m)
        ReDim s(n, m)
        ReDim int_maska(n, m)

        X = 30 'v.polje
        Y = 30 'v.polje
        xx = X
        yy = Y
        ' i_za_string sluzi za kretanje po rasporedu
        Dim i_za_string As Integer = 0
        '    Form5.Show()

        '  Dim stringic As String = ""                                                   ' odje se radi
        '  stringic = org.Generisi_matricu_slucajnih_brojeva(n, m, int_maska)
        '   Form5.TextBox2.Text = Form5.TextBox2.Text & stringic

        Dim ff As String = ""
        Dim ww As String = ""
        Panel1.BringToFront()
        For i = 0 To n - 1
            For j = 0 To m - 1
                '    raspored(i_za_string) = "1"
                If Val(raspored(i_za_string)) = 0 Then
                    d.tabela(i, j) = New T(skin)
                    d.tabela(i, j).l_i_int = i
                    d.tabela(i, j).l_j_int = j
                    d.tabela(i, j).AutoSize = False
                    d.tabela(i, j).Location = New Point(X, Y)
                    int_maska(i, j) = Val(raspored(i_za_string))
                    ff = ff & " " & org.prava_matrica(i, j)
                    ww = ww & " " & raspored(i_za_string)
                    resenje = resenje & org.prava_matrica(i, j)
                Else
                    d.tabela(i, j) = New P(Val(raspored(i_za_string)), 1)
                    d.tabela(i, j).AutoSize = False
                    d.tabela(i, j).Location = New Point(X, Y)
                    d.tabela(i, j).i_p = i
                    d.tabela(i, j).j_p = j
                    int_maska(i, j) = Val(raspored(i_za_string))
                    ff = ff & " " & org.prava_matrica(i, j)
                    ww = ww & " " & raspored(i_za_string)
                    resenje = resenje & "0"
                    If Val(raspored(i_za_string)) = 1 Then
                        d.tabela(i, j).d.visible = False
                        d.tabela(i, j).g.visible = False
                    End If
                End If

                i_za_string += 1
                X = X + v.polje
            Next j
            X = 30 'v.polje
            Y = Y + v.polje
            ff = ff & vbCrLf
            ww = ww & vbCrLf

        Next i
        '   Form5.TextBox1.Text = ff
        '   Form5.TextBox3.Text = ww
        i_za_string = 0
        For i = 0 To n - 1
            For j = 0 To m - 1
                If Val(raspored(i_za_string)) = 2 Then
                    '  d.tabela(i, j).d.text = org.prava_matrica(i, j).ToString
                    d.tabela(i, j).d.text = Suma_K(i, j, n).ToString
                    d.tabela(i, j).g.visible = False
                End If
                If Val(raspored(i_za_string)) = 3 Then
                    d.tabela(i, j).g.text = Suma_V(i, j, m).ToString
                    d.tabela(i, j).d.visible = False
                End If
                If Val(raspored(i_za_string)) = 4 Then
                    d.tabela(i, j).g.text = Suma_V(i, j, m).ToString
                    d.tabela(i, j).d.text = Suma_K(i, j, n).ToString
                End If
                i_za_string += 1
                Me.Controls.Add(d.tabela(i, j))
            Next j
        Next i
        visina = Me.Height
        '   Form5.TextBox7.Text = "visina = " & Me.Height.ToString
        '    Form5.TextBox8.Text = "duzina = " & Me.Width.ToString
        ' System.Threading.Thread.Sleep(1200)
        '  upisi()

    End Sub
    Public Sub Startuj_Igru_Iz_Fajla() '(ByVal n_file As Integer, ByVal m_file As Integer, ByVal sec_file As String, ByVal min_file As String, ByVal raspored_file As String, ByVal resenje_file As String, ByVal upisano_file As String)
        n = Form1.int_n
        m = Form1.int_m
        Panel1.BringToFront()
        int_maska = Napravi_Integer_Masku(n, m, raspored)
        org = New Orginal_Matrica(Form1.int_n - 1, Form1.int_m - 1, raspored)
        Kreiraj_Igru_Iz_File_a()
        '   Form5.TextBox4.Text = n & " x " & m
        Dim i, j As Integer
        Dim X, Y, xx, yy As Integer
        ReDim d.tabela(n, m)
        ReDim s(n, m)
        ReDim int_maska(n, m)
        X = 30 'v.polje
        Y = 30 'v.polje
        xx = X
        yy = Y
        Dim i_za_string As Integer = 0
        '    Form5.Show()
        Dim ff As String = ""
        Dim ww As String = ""
        For i = 0 To n - 1
            For j = 0 To m - 1
                '    raspored(i_za_string) = "1"
                If Val(raspored(i_za_string)) = 0 Then
                    d.tabela(i, j) = New T(skin)
                    d.tabela(i, j).l_i_int = i
                    d.tabela(i, j).l_j_int = j
                    d.tabela(i, j).AutoSize = False
                    d.tabela(i, j).Location = New Point(X, Y)
                    int_maska(i, j) = Val(raspored(i_za_string))
                    ff = ff & " " & org.prava_matrica(i, j)
                    ww = ww & " " & raspored(i_za_string)
                    resenje = resenje & org.prava_matrica(i, j)
                Else
                    d.tabela(i, j) = New P(Val(raspored(i_za_string)), 1)
                    d.tabela(i, j).AutoSize = False
                    d.tabela(i, j).Location = New Point(X, Y)
                    d.tabela(i, j).i_p = i
                    d.tabela(i, j).j_p = j
                    int_maska(i, j) = Val(raspored(i_za_string))
                    ff = ff & " " & org.prava_matrica(i, j)
                    ww = ww & " " & raspored(i_za_string)
                    If Val(raspored(i_za_string)) = 1 Then
                        d.tabela(i, j).d.visible = False
                        d.tabela(i, j).g.visible = False
                    End If
                End If
                i_za_string += 1
                X = X + v.polje
            Next j
            X = 30 'v.polje
            Y = Y + v.polje
            ff = ff & vbCrLf
            ww = ww & vbCrLf
        Next i
        '   Form5.TextBox1.Text = ff
        '     Form5.TextBox3.Text = ww
        i_za_string = 0
        For i = 0 To n - 1
            For j = 0 To m - 1
                If Val(raspored(i_za_string)) = 2 Then
                    d.tabela(i, j).d.text = Suma_K(i, j, n).ToString
                    d.tabela(i, j).g.visible = False
                End If
                If Val(raspored(i_za_string)) = 3 Then
                    d.tabela(i, j).g.text = Suma_V(i, j, m).ToString
                    d.tabela(i, j).d.visible = False
                End If
                If Val(raspored(i_za_string)) = 4 Then
                    d.tabela(i, j).g.text = Suma_V(i, j, m).ToString
                    d.tabela(i, j).d.text = Suma_K(i, j, n).ToString
                End If
                i_za_string += 1
                Me.Controls.Add(d.tabela(i, j))
            Next j
        Next i
        visina = Me.Height
        '    Form5.TextBox7.Text = "visina = " & Me.Height.ToString
        '    Form5.TextBox8.Text = "duzina = " & Me.Width.ToString
        ' System.Threading.Thread.Sleep(1200)
        Dim bb As Integer = 0
        For i = 0 To n - 1
            For j = 0 To m - 1
                If (uneseni(bb)) <> "0" Then
                    d.tabela(i, j).lb.Text = uneseni(bb)
                End If
                bb += 1
            Next
        Next
        ' upisi()
    End Sub
    Public Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '     Me.Opacity = 60
        Form1.Podesi_Boje()
        Pozicioniraj()
        If fil = 1 Then
            Startuj_Igru_Od_Pocetka()
        Else
            Startuj_Igru_Iz_Fajla()
        End If
        ' MsgBox(n & " " & m)
    End Sub
    Function Suma_V(ByVal i As Integer, ByVal j As Integer, ByVal m As Integer) As Integer
        '    MsgBox(" i= " & i & "j= " & j)
        Dim suma As Integer = 0
        j += 1
        '   Dim jj As Integer
        While (j < m) And int_maska(i, j) = 0
            suma = suma + org.prava_matrica(i, j)
            '       MsgBox(" mat = " & org.prava_matrica(i, j))
            j += 1
        End While
        '   Form5.TextBox2.Text = suma.ToString
        Return suma
    End Function
    Function Suma_K(ByVal i As Integer, ByVal j As Integer, ByVal n As Integer) As Integer
        '    MsgBox(" i= " & i & "j= " & j)
        Dim suma As Integer = 0
        i += 1
        '   Dim jj As Integer
        While (i < n) And int_maska(i, j) = 0
            suma = suma + org.prava_matrica(i, j)
            '       MsgBox(" mat = " & org.prava_matrica(i, j))
            i += 1
        End While
        ' Form5.TextBox2.Text = suma.ToString
        Return suma
    End Function
    Public Sub upisi()
        '  If Form1.int_stanje = 1 Then
        '  slika.BringToFront()
        '    slika.Visible = True

        '  End If
        slika.BringToFront()
        Dim n As Integer = Form1.int_n
        Dim m As Integer = Form1.int_m
        Dim i, j As Integer
        Dim brz1 As Integer = 0
        Dim brz2 As Integer = 0
        Select Case n
            Case 8
                brz1 = 10
                brz2 = 20
            Case 10
                brz1 = 5
                brz2 = 7
            Case 12
                brz1 = 2
                brz2 = 2
        End Select
        For i = 0 To n - 1
            For j = 0 To m - 1
                System.Threading.Thread.Sleep(brz1)
                d.tabela(i, j).bringtofront()
                d.tabela(i, j).refresh()
                System.Threading.Thread.Sleep(brz2)
            Next j
        Next i
    End Sub
    Public Sub sakrij(ByRef d As Matrica, ByRef ii As Integer, ByRef jj As Integer, ByVal nacin As Integer)
        Select Case nacin
            Case 1
                d.tabela(ii, jj).visible = False
                Me.slika.Refresh()
            Case 2      ' praklapanje
                If int_maska(ii, jj) = 4 Or int_maska(ii, jj) = 3 Then
                End If
                d.tabela(ii, jj).backgroundimage = Form1.f2_puno_polje
        End Select

    End Sub
    Public Sub otkrijmat(ByRef d As Matrica, ByRef ii As Integer, ByRef jj As Integer, ByVal nacin As Integer)
        '   d.tabela(ii, jj).backgroundimage = Image.FromFile(Application.StartupPath & "/pictures/" & Me.skin.ToString & "/b1.png")
        Select Case nacin
            Case 1
                d.tabela(ii, jj).visible = True
                '     d.tabela(ii, jj).refresh()
                d.tabela(ii, jj).refresh()
            Case 2         ' praklapanje
                Select Case int_maska(ii, jj)
                    Case 0
                        d.tabela(ii, jj).backgroundimage = Form1.f2_prazno_polje
                    Case 1
                        d.tabela(ii, jj).backgroundimage = Form1.f2_puno_polje

                    Case 2, 3
                        d.tabela(ii, jj).backgroundimage = Form1.f2_dijagonala
                        d.tabela(ii, jj).d.forecolor = Form1.f2_donja_gornja
                        d.tabela(ii, jj).g.forecolor = Form1.f2_donja_gornja
                    Case 4
                        d.tabela(ii, jj).backgroundimage = Image.FromFile(Application.StartupPath & "/pictures/" & Me.skin.ToString & "/b.png")
                        d.tabela(ii, jj).g.forecolor = Color.Black
                        d.tabela(ii, jj).d.forecolor = Color.White
                End Select
                d.tabela(ii, jj).refresh()
        End Select

    End Sub
    Public Sub sakrij1(ByVal nacin As Integer)
        Dim n As Integer = Form1.int_n
        Dim m As Integer = Form1.int_m
        Dim i, j As Integer
        Dim pola As Integer = i / 2
        Dim brz1 As Integer = 0
        Dim brz2 As Integer = 0
        Select Case n
            Case 8
                brz1 = 10
                brz2 = 20
            Case 10
                brz1 = 5
                brz2 = 7
            Case 12, 16
                brz1 = 2
                brz2 = 2
        End Select

        For i = 0 To n - 1
            For j = 0 To m - 1
                Select Case nacin
                    Case 1
                        System.Threading.Thread.Sleep(brz1)
                        'System.threading.thread.currentthread.sleep( <time in milli or span> )
                        ' System.threading.thread.currentthread.spinwait( <process interations to skip>)
                        sakrij(d, i, j, nacin)
                        System.Threading.Thread.Sleep(brz2)
                    Case 2
                        System.Threading.Thread.Sleep(brz1)
                        sakrij(d, i, j, nacin)
                        System.Threading.Thread.Sleep(brz2)
                End Select
            Next j
        Next i
    End Sub
    Public Sub otkrij1(ByVal nacin As Integer)
        '    Dim n As Integer = Form1.int_n
        '   Dim m As Integer = Form1.int_m
        Dim i, j As Integer
        Dim brzina1 As Integer = 20
        Dim brzina2 As Integer = 10

        Dim brz1 As Integer = 0
        Dim brz2 As Integer = 0
        Select Case n
            Case 8
                brz1 = 10
                brz2 = 20
            Case 10
                brz1 = 4
                brz2 = 6
            Case 12
                brz1 = 2
                brz2 = 2
        End Select
        i = n - 1
        j = m - 1
        For i = n - 1 To 0 Step -1
            For j = m - 1 To 0 Step -1
                Select Case nacin
                    Case 1
                        System.Threading.Thread.Sleep(brz1)
                        '   System.Threading.Thread.Sleep(brzina1)
                        '  d.tabela(i, j).refresh()
                        '  Refresh()
                        otkrijmat(d, i, j, nacin)

                        ' Refresh()
                        '  d.tabela(i, j).refresh()
                        '  System.Threading.Thread.Sleep(brzina2)
                        System.Threading.Thread.Sleep(brz2)
                    Case 2
                        '  System.Threading.Thread.Sleep(20)
                        System.Threading.Thread.Sleep(brz1)
                        otkrijmat(d, i, j, nacin)
                        '  System.Threading.Thread.Sleep(10)
                        System.Threading.Thread.Sleep(brz2)
                End Select
            Next
        Next
        Me.Focus()
    End Sub
    Public Sub Promijeni_Skin(ByVal skin As Integer)

        slika.Image = Form1.f2_slika
        Form3.Refresh()

        For i = 0 To n - 1
            For j = 0 To m - 1
                If int_maska(i, j) = 0 Then
                    d.tabela(i, j).BackgroundImage = Form1.f2_prazno_polje
                ElseIf int_maska(i, j) = 1 Then
                    d.tabela(i, j).BackgroundImage = Form1.f2_puno_polje
                Else
                    d.tabela(i, j).BackgroundImage = Form1.f2_dijagonala
                    If d.tabela(i, j).d.visible = True Then
                        d.tabela(i, j).d.forecolor = Form1.f2_donja_gornja
                    End If
                    If d.tabela(i, j).g.visible = True Then
                        d.tabela(i, j).g.forecolor = Form1.f2_donja_gornja
                    End If
                End If
            Next
        Next
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If smanjuj = True Then
            If (Me.Height <= 40) Then                        ' ako je smanjena na minimum
                smanjuj = False
                povecavaj = True
            End If
            If (Me.Height > 0) And smanjuj = True Then

                If Me.Height <= Form3.Height And Me.Height <= Form1.Height Then
                    start = True
                End If
                If start = True Then
                    Form3.Height -= 20
                    Form1.Height -= 20
                End If
                Me.Height -= 20
                '  Me.Refresh()
            End If
        End If

        If promijenjena = False And povecavaj = True Then
            Promijeni_Skin(skin)
            Form3.Promijni_boju_labelama()
            promijenjena = True
            Form1.Oboji()
        End If

        If povecavaj = True And Form1.pauza = False Then
            If (Me.Height >= visina) Then 'And (Me.Width >= 300)
                Timer1.Enabled = False
                povecavaj = False
                smanjuj = True
                start = False
                promijenjena = False
            End If
            If (Me.Height < visina) And povecavaj Then
                If Form3.Height < 400 Then
                    ' odje smanjuj i formu3
                    Form3.Height += 20
                    Form1.Height += 20
                End If
                Me.Height += 20
            End If
            '   Me.Refresh()
        End If
    End Sub
    Public Sub Smanji_Povecaj_Form2_i_Form3()
        '     Form1.BackColor = Form1.f1_back_color
        Form1.MinimumSize = New Size(0, 0)
        Timer1.Enabled = True
        '  Form1.Oboji()

    End Sub
    Private Sub Form2_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter
        Me.Focus()
    End Sub
    Private Sub Form2_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseHover
        Me.Focus()
    End Sub
End Class


