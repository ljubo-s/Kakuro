Public Class Moje_Klase

End Class
' Klasa velicine sadrzi vrijednosi koje odredjuju velicine objekata, 
' npr. polje predstavlja velicinu objekata : 
' 1)klase P(panel) cije su instance polja u matrici koja sadrze sume za koje se traze sabirci 
'
' moguce je izmijeniti velicinu polja i to ce se odraziti na velicinu svih objekata
' treba obratiti paznju da li postoji slika odgovarajuce velicine
Public Class velicine

    Public polje As Integer = 55           ' Odredjuje velicinu polja
    Public brojcanik As Boolean = False    ' Detektuje aktivaciju brojcanika
    Public f1_aktivna As Boolean           ' Detektuju aktivaciju Form1, Form2... 
    Public f2_aktivna As Boolean = False
    Public f3_aktivna As Boolean
    Public f4_aktivna As Boolean

    Public tb_aktivan As Boolean           ' Detektuje aktiviranje tb(TextBoxa) 
    Public i_tb, j_tb As Integer           ' Indeks vrste i kolone aktivnog TextBoxa

    Public point_desnog_klika As Point     ' pozicija kursora prilikom desnog klika misem na labelu u objektu klase T

    Public boja_brojcanika_default As Color = Color.Blue 'New Form1.f4_resenje_default_color
    Public boja_brojcanika_onMouseOver As Color = Color.AliceBlue  'Form1.f4_kand_default_color

    '  Public boja_markiranog_polja As Color = Color.Blue
    Public boja_aktivne_labele As Color = Color.DarkRed
    Public colorShema As String            ' naziv foldera u kome se nalaze slike za odgovarajuci izgled

    Public sat As Boolean                  ' Detektuje aktivaciju sata
    Public panel_x As Integer
    Public panel_y As Integer

    Public font_tb_lb As Font
    Public f As FontFamily
    ' Public string_za_stampu As String
End Class
' klasa P predstavlja polja sa dijagonalom u kojima se nalazi suma koja se trazi
' onMouseOver poziva funkciju koja racuna kombinacije
Public Class P : Inherits System.Windows.Forms.Panel
    ' g - labela koja se nalazi u gornjem desnom uglu panela sa brojem(sumom)
    ' koju treba da dobijemo od sabiraka koji se nalaze sa 
    ' desne strane u horizontalnoj ravni sa brojem(sumom)
    Public WithEvents g As System.Windows.Forms.Label
    Public WithEvents d As System.Windows.Forms.Label
    Public string_za_stampu() As Char = ""
    'indeksi vrste i kolone, pozicija koju je objekat zauzeo u matrici
    Public i_p, j_p As Integer
    Public v = New velicine
    Public i_broj_kombinacija As Integer = 0
    'Promjenljive u kojima se pamti koja vrijednos je veca, i na osnovu njih
    'registruje se promjena, tj. prelazak kursora  preko dijagonale, sto 
    'dovodi do potrebe za pozivom kombinacija() sa novim argumentom
    Public y_vece As Boolean = False
    Public x_vece As Boolean = False
    ' KONSTRUKTOR
    ' Public g As New Label()
    Public Sub New(ByVal slika As Integer, ByVal skin As Integer)
        Me.Location = New System.Drawing.Point(67, 89)
        g = New System.Windows.Forms.Label
        g.SendToBack()
        g.BackColor = Color.Transparent
        ' g.Image = Image.FromFile(Application.StartupPath & "/pictures/l.png")
        g.AutoSize = False
        g.Height = v.polje / 3.4
        g.Width = v.polje / 2.1
        ' g.Text = 
        g.TextAlign = ContentAlignment.MiddleLeft
        '  If Form2.skin = 2 Then
        g.ForeColor = Form1.f2_donja_gornja
        '   Else
        '  g.ForeColor = Color.Black
        ' End If
        g.Location = New System.Drawing.Point(v.polje * 0.48, v.polje * 0.11)
        '  g.Font = New Font(g.Font.FontFamily, 11)
        ' g.Font = New Font(g.Font, FontStyle.Bold)
        g.Font = Form1.f2_donja_gornja_font

        d = New System.Windows.Forms.Label
        d.BackColor = Color.Transparent
        d.AutoSize = False
        d.Height = v.polje / 3.6
        d.Width = v.polje / 2.1
        '  d.Text =
        '  If Form2.skin = 2 Then
        '   d.ForeColor = Color.White
        '   Else
        d.ForeColor = Form1.f2_donja_gornja
        '   End If
        d.Location = New System.Drawing.Point(v.polje * 0.1, v.polje * 0.54)
        d.Font = New Font(g.Font.FontFamily, 11)
        d.Font = Form1.f2_donja_gornja_font
        d.TextAlign = ContentAlignment.MiddleLeft
        ' d.BringToFront()

        Me.Height = v.polje
        Me.Width = v.polje
        Me.Controls.Add(g)
        Me.Controls.Add(d)

        If slika = 1 Then
            Me.BackgroundImage = Form1.f2_puno_polje
        Else
            Me.BackgroundImage = Form1.f2_dijagonala
        End If
        Me.BackgroundImageLayout = ImageLayout.Stretch
        Me.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
        Me.Show()
        '  g.Visible = True
    End Sub
    ' END OF KONSTRUKTOR
    ' ***********************       Funkcije koje se pozivaju na MouseOver, MouseIn, MouseOut iznad punih polja    ********************
    ' mouseOver labela g,d samih brojeva u poljima iznad i ispod dijagonala
    ' funkcije sakrij_labele i otkrij_labele skrivaju i otkrivaju labele
    ' argumenti op - integer, broj - integer
    ' op ako je 1 - sakriva broj labela od pocetka(npr. broj=5, sakrice 5 prvih labela), 
    '           2 - sakriva broj labela od kraja, 
    '           3 - sakriva labelu na poziciji broj
    '           4 - sakriva sve prikazane labele
    Public Sub sakrij_labele(ByVal op As Integer, ByVal broj As Integer)
        Dim i As Integer
               Select op
            Case 1
            Case 2
            Case 3
            Case 4
                For i = 0 To 11   ' 
                    If Form3.labela(i) Is Nothing Then
                    Else
                        '       If Form2.skin = 2 Then
                        Form3.labela(i).ForeColor = Form1.f3_labele_color
                        'Else
                        '             Form3.labela(i).ForeColor = Color.Black
                        '        End If
                        Form3.labela(i).Text = ""
                        Form3.labela(i).Font = Form1.f3_font
                        Form3.labela(i).Visible = False
                        Form3.labela_preostalih.Text = ""
                    End If
                Next
        End Select
    End Sub
    ' funkcija preostali_moguci  ulazni parametri veci - niz karaktera , manji - niz karaktera 
    ' vraca string koji se sastoji od cifara koje nisu zajednice za stringove veci i manji
    Public Function preostali_moguci(ByVal veci() As Char, ByVal manji As String) As String
        Dim brojevi As String = ""
        Dim br2 As Integer = 0
        While (br2 < veci.Length - 1)
            If manji.Contains(veci(br2)) Or veci(br2) = "+" Or veci(br2) = " " Or veci(br2) = "vbCrLf" Then
            Else
                brojevi = brojevi & veci(br2)
            End If
            br2 += 1
        End While
        Return brojevi
    End Function
    ' funkcija ukloni_iste_iz_stringa, argument: s - niz karaktera
    ' ukoliko postoje  isti karakteri uklanja ih, kreira string u kome ne postoje isti karakteri i vraca takav string 
    Public Function ukloni_iste_iz_stringa(ByVal s() As Char) As String
        Dim novi As String = ""
        Dim i As Integer
        For i = 0 To s.Length - 1
            If novi.Contains(s(i)) Then
            Else
                novi = novi & s(i)
            End If
        Next
        Return novi
    End Function
    ' funkcija sadrzi_li_string, ulazni parametri veci - niz karaktera , manji - niz karaktera 
    ' vraca false ako postoje makar dva ista elementa stringova veci i manji, 
    ' vraca true ako nemaju istih elemenata
    Public Function sadrzi_li_string(ByVal veci() As Char, ByVal manji As String) As Boolean
        Dim br2 As Integer = 0
        Dim br1 As Integer = 0
        Dim poklapanje As Boolean = False
        Dim temp As String = ""
        Dim tacni As Integer = 0
        ' ova petlja uklanja sve osim brojeva iz stringa
        While (br1 < veci.Length)
            If veci(br1) <> "+" And veci(br1) <> " " Then
                temp = temp & veci(br1)
            End If
            br1 += 1
        End While
        br1 = 0
        While (br2 < manji.Length) ' And poklapanje = False
            If veci.Contains(manji(br2)) Then
                poklapanje = True
            Else
                Return False
            End If
            br2 += 1
        End While
        If poklapanje Then
            Return True
        Else
            Return False
        End If
    End Function
    'prikazuje kombinacije u labelama, op ako je 1 - pozvana je funkcija iz donje labele, 2-pozvana je iz gornje labele
    'op - potrebno za nalazenje unijetih brojeva u matricu, odredjuje da li ce se traziti brojevi po vrsti ili po koloni
    Public Sub Stampaj_Kombinacije(ByVal op As Integer, ByVal klasa As Integer)
        sakrij_labele(4, 0)
        Dim poklapaju_se As Boolean = False
        Dim preostali As String = ""
        Form3.Show()
        Dim i As Integer
        If string_za_stampu = "" Then
        Else
            Dim br As Integer = 0  'ide do kraja stringa
            Dim red As Integer = 0 'ide do k * 2 -1, k-klasa kombinacija, k*2-1 ima elemenata u jednom redu stringa_za_stampu
            Dim temp As String = ""
            ' MsgBox("Klasa = " & klasa)
            For i = 0 To i_broj_kombinacija - 1
                If string_za_stampu.Length > 0 Then

                    ' while - iz stringa_za_stampu ciji format izgleda npr.
                    ' 1+2+...VbCrlf
                    ' 2+5+...VbCrlf
                    ' ...
                    ' 6+5+...VbCrlf
                    ' izdvaja redove i smjesta ih u string temp, tako da string temp u drugoj iteraciji for petlje izgleda:
                    ' 2 + 5 + ...
                    While ((br < string_za_stampu.Length - 1) And (red < klasa * 2)) ' dodaje po jedan blanko sa lijeve i desne strane plusa
                        If string_za_stampu(br) = "+" Then
                            temp = temp & " + "
                        Else
                            temp = temp & string_za_stampu(br)
                        End If
                        br += 1
                        red += 1
                    End While
                    red = 0
                    br += 1
                    '   Form3.labela(i).Visible = True  ' prikazivanje labele(i)
                    Form3.labela(i).ForeColor = Color.Gray
                    If op = 1 Then   ' op = 1 ako je funkcija pozvana sa donje dijagonale
                        If sadrzi_li_string(temp, Uneseni_Brojevi_Po_Koloni(Me.i_p, Me.j_p, Form2.m, Form2.n, Form2.int_maska)) Then
                            '      If Form2.skin = 2 Then
                            Form3.labela(i).ForeColor = Form1.f3_fore_color     ' promjena fonta, boje za stringove koji se poklapaju
                            '      Else
                            '     Form3.labela(i).ForeColor = Color.Black   ' promjena fonta, boje za stringove koji se poklapaju
                            '     End If
                            Form3.labela(i).Font = Form1.f3_font_markirani
                            poklapaju_se = True

                            preostali = preostali & preostali_moguci(temp, Uneseni_Brojevi_Po_Koloni(Me.i_p, Me.j_p, Form2.m, Form2.n, Form2.int_maska))
                            preostali = ukloni_iste_iz_stringa(preostali)
                        End If
                    End If
                    If op = 2 Then   ' op = 2 ako je funkcija pozvana sa gornje dijagonale
                        If sadrzi_li_string(temp, Uneseni_Brojevi_Po_Vrsti(Me.i_p, Me.j_p, Form2.m, Form2.n, Form2.int_maska)) Then
                            '   If Form2.skin = 2 Then
                            Form3.labela(i).ForeColor = Form1.f3_fore_color     ' promjena fonta, boje za stringove koji se poklapaju
                            '       Else
                            '          Form3.labela(i).ForeColor = Color.Black   ' promjena fonta, boje za stringove koji se poklapaju
                            '      End If
                            '
                            poklapaju_se = True
                            Form3.labela(i).Font = Form1.f3_font_markirani

                            preostali = preostali & preostali_moguci(temp, Uneseni_Brojevi_Po_Vrsti(Me.i_p, Me.j_p, Form2.m, Form2.n, Form2.int_maska))
                            preostali = ukloni_iste_iz_stringa(preostali)
                        End If
                    End If
                    Form3.labela(i).Text = temp  ' upis stringa temp u novoprikazanu label(i)
                    temp = ""
                End If
            Next
        End If
        For i = 0 To i_broj_kombinacija - 1
            If poklapaju_se = False Then

                '   If Form2.skin = 2 Then
                Form3.labela(i).ForeColor = Form1.f3_fore_color      ' promjena fonta, boje za stringove koji se poklapaju
                '     Else
                '         Form3.labela(i).ForeColor = Color.Black   ' promjena fonta, boje za stringove koji se poklapaju
                '     End If
                Form3.labela(i).Font = Form1.f3_font
            Else
                '  Form3.labela(i).Font = New System.Drawing.Font("Verdana", 12, FontStyle.Italic And FontStyle.Bold)
            End If
            Form3.labela(i).Visible = True
        Next
        Dim c() As Char
        c = preostali.ToArray
        Array.Sort(c)

        preostali = ""
        Dim ii As Integer = 1
        i = 1
        If c.Length > 0 Then
            preostali = c(0).ToString
            If c.Length > 1 Then
                While ii < c.Length
                    preostali = preostali & ", " & c(ii)
                    ii += 1
                End While
            Else
            End If
            Form3.labela_preostalih.Text = preostali
        End If
        Form3.Show()
        i_broj_kombinacija = 0
    End Sub
    Public Sub mis_iznad_d(ByVal sender As Object, ByVal e As System.EventArgs) Handles d.MouseEnter
        string_za_stampu = ""
        sakrij_labele(4, 0)
        If CInt(Me.d.Text) > 0 Then
            Dim y As Integer = Broj_Praznih_Polja_Po_Koloni(Me.i_p, Me.j_p, Form2.m, Form2.n, Form2.int_maska)
            Kombinacije(9, y, CInt(Me.d.Text))
            Stampaj_Kombinacije(1, y)
            '  Form3.Label1.Text = string_za_stampu 'CInt(g.Text)  Stampanje stringa koji su kombinacije kreirale
            '  Form3.Show()
        End If
    End Sub
    Public Sub mis_iznad_g(ByVal sender As Object, ByVal e As System.EventArgs) Handles g.MouseEnter
        string_za_stampu = ""
        sakrij_labele(4, 0)
        If CInt(Me.g.Text) > 0 Then
            Dim y As Integer = Broj_Praznih_Polja_Po_Vrsti(Me.i_p, Me.j_p, Form2.m, Form2.n, Form2.int_maska)
            Kombinacije(9, y, CInt(Me.g.Text))
            Stampaj_Kombinacije(2, y)
        End If
    End Sub
    Public Sub izlaz_misa_iz_polja(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave
        string_za_stampu = ""
        '  Form1.Label3.Text = string_za_stampu
        '  Form3.Label1.Text = string_za_stampu
        '   sakrij_labele(4, 0)
    End Sub
    Public Sub izlaz_misa_iz_g_d(ByVal sender As Object, ByVal e As System.EventArgs) Handles g.MouseLeave, d.MouseLeave
        string_za_stampu = ""
        '    Form3.Label1.Text = string_za_stampu
    End Sub
    Public Sub pokret_misa(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseMove, Me.MouseHover
        Dim p As Point
        p = Me.PointToClient(MousePosition)
        string_za_stampu = ""
        If (p.X > p.Y) And (x_vece = False) Then
            '    Form3.Label1.Text = ""
            '   sakrij_labele(4, 0)
            If (Me.g.Visible = True) Then

                Dim y As Integer = Broj_Praznih_Polja_Po_Vrsti(Me.i_p, Me.j_p, Form2.m, Form2.n, Form2.int_maska)
                Kombinacije(9, y, CInt(Me.g.Text))
                Stampaj_Kombinacije(2, y)
                '  Form3.Label1.Text = string_za_stampu    ' Stampanje stringa koji su kombinacije kreirale
                '  Form3.Show()
            End If
            x_vece = True
            y_vece = False
        Else
            If (p.X < p.Y) And (y_vece = False) Then

                '          sakrij_labele(4, 0)
                If (Me.d.Visible = True) Then

                    Dim y As Integer = Broj_Praznih_Polja_Po_Koloni(Me.i_p, Me.j_p, Form2.m, Form2.n, Form2.int_maska)
                    Kombinacije(9, y, CInt(Me.d.Text))
                    Stampaj_Kombinacije(1, y)
                    '   Form3.Label1.Text = string_za_stampu     ' Stampanje stringa koji su kombinacije kreirale
                    '   Form3.Show()
                End If
                y_vece = True
                x_vece = False
            Else
                '   Form3.Label1.Text = string_za_stampu
                '   Form3.Show()
            End If
        End If
    End Sub
    Public Sub iznad_mis(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter
        Dim p As Point
        p = Me.PointToClient(MousePosition)
        string_za_stampu = ""
        If (p.X >= p.Y) Then
            x_vece = True
            If (Me.g.Visible = True) Then
                string_za_stampu = ""
                ' sakrij_labele(4, 0)
                Dim y As Integer = Broj_Praznih_Polja_Po_Vrsti(Me.i_p, Me.j_p, Form2.m, Form2.n, Form2.int_maska)
                Kombinacije(9, y, CInt(Me.g.Text))
                Stampaj_Kombinacije(2, y)
                '    Form3.Label1.Text = string_za_stampu   ' Stampanje stringa koji su kombinacije kreirale
                '    Form3.Show()
            End If
        Else
            y_vece = True
            If (Me.d.Visible = True) Then
                string_za_stampu = ""
                '    sakrij_labele(4, 0)
                Dim y As Integer = Broj_Praznih_Polja_Po_Koloni(Me.i_p, Me.j_p, Form2.m, Form2.n, Form2.int_maska)
                Kombinacije(9, y, CInt(Me.d.Text))
                Stampaj_Kombinacije(1, y)
                '    Form3.Label1.Text = string_za_stampu    ' Stampanje stringa koji su kombinacije kreirale
                '    Form3.Show()
            End If
        End If
        Form3.Show()
    End Sub
    Function Uneseni_Brojevi_Po_Vrsti(ByVal i As Integer, ByVal j As Integer, ByVal m As Integer, ByVal n As Integer, ByVal mat(,) As Integer) As String
        Dim jj As Integer
        '   Dim br As Integer = 0
        Dim s As String = ""
        jj = j + 1
        While (jj < m) And (mat(i, jj) = 0)
            If Form2.d.tabela(i, jj).lb.Text.Length > 0 Then
                ' br = br * 10
                '  br = br + CInt(d.tabela(i, jj).lb.text)
                s = s + (Form2.d.tabela(i, jj).lb.text)
            End If
            jj = jj + 1
        End While

        Return s
    End Function
    Function Uneseni_Brojevi_Po_Koloni(ByVal i As Integer, ByVal j As Integer, ByVal m As Integer, ByVal n As Integer, ByVal mat(,) As Integer) As String
        Dim ii As Integer
        Dim br As Integer = 0
        Dim s As String = ""
        ii = i + 1
        While (ii < n) And (mat(ii, j) = 0)
            If Form2.d.tabela(ii, j).lb.Text.Length > 0 Then
                s = s + (Form2.d.tabela(ii, j).lb.text)
            End If
            ii = ii + 1
        End While
        Return s
    End Function
    Function Broj_Praznih_Polja_Po_Vrsti(ByVal i As Integer, ByVal j As Integer, ByVal m As Integer, ByVal n As Integer, ByVal mat(,) As Integer) As Integer
        Dim jj As Integer
        Dim br As Integer = 0
        jj = j + 1
        While (jj < m) And (mat(i, jj) = 0)
            br = br + 1
            jj = jj + 1
        End While
        Return br
    End Function
    Function Broj_Praznih_Polja_Po_Koloni(ByVal i As Integer, ByVal j As Integer, ByVal m As Integer, ByVal n As Integer, ByVal mat(,) As Integer) As Integer
        Dim ii As Integer
        Dim br As Integer = 0
        ii = i + 1
        While (ii < n) And (mat(ii, j) = 0)
            br = br + 1
            ii = ii + 1
        End While
        Return br
    End Function
    Function Suma_Vrste(ByVal i As Integer, ByVal j As Integer, ByVal m As Integer, ByVal mat(,) As Integer) As Integer
        ' MsgBox(" i= " & i & "j= " & j)
        Dim suma As Integer
        '   Dim jj As Integer
        While (j < m) And mat(i, j) > 0
            j += 1
            suma = suma + mat(i, j)
            '   MsgBox(" mat = " & mat(i, j))
        End While
        Return suma
    End Function
    '**********************************   Kraj Funkcija  sa pozivom na MouseOver, MouseIn, MouseOut  **********************************
    ' K O M B I N A C I J E   
    ' k - klasa kombinacija, suma - broj ciji se sabirci traze 
    Public Sub Stampaj_Niz(ByVal a() As Integer, ByVal k As Integer, ByVal sum As Integer)
        '   Dim vs = New velicine
        Dim i As Integer = 1
        Dim s As Integer = 0
        Dim sabirci As String = ""
        Dim za_stampu As String = a(i).ToString

        For i = 1 To k
            s = s + a(i)
            If (s > sum) Or ((s < sum) And (i = k)) Then
                Return
            Else
                If (i <= k) Then
                    sabirci = a(i) & "+" & sabirci
                    If (i < k) Then
                        If i Mod 2 = 1 Then
                            za_stampu = za_stampu & "+" & a(i + 1).ToString
                        Else
                            za_stampu = za_stampu & "+" & a(i + 1).ToString
                        End If
                    End If
                End If
            End If
        Next i
        If (s = sum) Then
            string_za_stampu = string_za_stampu & za_stampu & vbCrLf
            i_broj_kombinacija += 1
        End If
    End Sub
    Function Jednaki(ByVal a() As Integer, ByVal b() As Integer, ByVal k As Integer) As Integer
        Dim i As Integer = 0
        For i = 1 To k
            If (a(i) <> b(i)) Then
                Return 0
            End If
        Next
        Return 1
    End Function
    Private Sub Next_Kombinacija(ByRef a() As Integer, ByVal n As Integer, ByVal k As Integer, ByVal sum As Integer)
        Dim p As Integer = k
        Dim i As Integer = 0
        While (a(p) >= n - k + p)
            p = p - 1
        End While
        a(p) = a(p) + 1
        For i = p + 1 To k
            a(i) = a(i - 1) + 1
        Next i
    End Sub
    ' funkcija Kombinacije Ckn k-te klase od n elemenata,
    ' parametar n u ovom slucaju je uvijek 9, zbog 9 cirara koje su moguci sabirci 
    ' parametar k - klasa kombinacija, zavisi od broja raspolozivih polja za unos cifara koje se traze
    ' sum - suma koja se trazi, suma k cifara treba da bude sum
    Private Sub Kombinacije(ByVal n As Integer, ByVal k As Integer, ByVal sum As Integer)
        Dim a(9) As Integer
        Dim i As Integer = 1
        Dim last(44) As Integer
        ' Punjenje Niza a i last sa k elemenata
        ' a se sastoji od prvih k elemenata 1,2,3...k
        ' last se sastoji od k zadnjih elemenata ...k-3, k-2, k-1, k
        For i = 1 To k
            a(i) = i
            last(i) = n - k + i
        Next i
        While (Jednaki(a, last, k) = 0)
            Stampaj_Niz(a, k, sum)
            Next_Kombinacija(a, n, k, sum)
        End While
        Stampaj_Niz(last, k, sum)
    End Sub
    ' E N D    O F    K O M B I N A C I J E 
    '  Public Sub Sakrij_Lablu(ByVal koja As Integer)
    '      Select Case koja
    '     Case 2
    '          Me.d.Visible = False
    '          Case 3
    '         Me.g.Visible = False
    '         Case 4
    '        Me.d.Visible = False
    '       Me.g.Visible = False
    '    End Select
    '  End Sub
    Public Sub Otkrij_Lable(ByVal koja As Integer)
        Select Case koja
            Case 2
                Me.d.Visible = True
            Case 3
                Me.g.Visible = True
            Case 4
                Me.d.Visible = True
                Me.g.Visible = True
        End Select
    End Sub
End Class
' klasa T predsavlja polja u kojima se upisuju brojevi
Public Class T : Inherits System.Windows.Forms.Panel
    Public WithEvents tb As System.Windows.Forms.TextBox
    Public WithEvents lb As System.Windows.Forms.Label
    ' temp sluzi za detektovanje koliko je brojeva u jednom unosu upisano u objekat, na lostfokus postavlja se na 0
    Public temp As Integer = 0
    ' Public WithEvents bt As System.Windows.Forms.Button
    'l_i_int, l_j_int Indeksi Labela lb 
    Public l_i_int, l_j_int As Integer
    ' U Labelama l1,l2...l9 upisuju se cifre 1,2...9 i rasporedjuju se oko textboxa koji se nalazi u centralnom
    ' dijelu panela, izborom jedne ili vise labela mijenja se njihova velicina i postaju vidljivije, 
    ' omogucavaju igracu da "zapamti" na samom polju vrijednosti koje su moguce, a od kojih je jedna resenje
    ' nisam uspio pronaci nacin da realizujem Niz WithEvents Labela, sto je mozda i nemoguce
    Public WithEvents l1, l2, l3, l4, l5, l6, l7, l8, l9 As System.Windows.Forms.Label
    ' Detektuje da li su pomocni brojevi povecani ili nisu
    Public lc(9) As Boolean
    Public v_za_t As New velicine
    Public v As velicine = New velicine
    Public granice_vrsta As String
    Public granice_kolona As String
    'BEGIN  K O N S T R U K T O R    K L A S E       T
    Sub New(ByVal skin As Integer)
        tb = New TextBox
        lb = New Label
        lb.Text = ""

        Me.Height = v.polje
        Me.Width = v.polje
        Me.BackColor = Color.Azure
        '  Me.BackgroundImage = Image.FromFile(Application.StartupPath & "/pictures/ptp.png")
        Me.BackgroundImage = Form1.f2_prazno_polje
        Me.BackgroundImageLayout = ImageLayout.Stretch
        Me.BorderStyle = Windows.Forms.BorderStyle.FixedSingle

        lb.Height = v.polje * 0.52
        lb.Width = v.polje * 0.56
        lb.AutoSize = False
        lb.Location = New System.Drawing.Point(v.polje * 0.22, v.polje * 0.22)
        lb.BorderStyle = Windows.Forms.BorderStyle.None
        lb.BackColor = Color.Transparent
        lb.Visible = True
        lb.Font = Form1.f2_font_resenja
        lb.TextAlign = ContentAlignment.MiddleCenter
        Me.Controls.Add(lb)

        tb.Height = v.polje * 0.52
        tb.Width = v.polje * 0.56
        tb.Multiline = True
        tb.Location = New System.Drawing.Point(v.polje * 0.22, v.polje * 0.22)
        tb.BorderStyle = Windows.Forms.BorderStyle.None
        tb.Font = New Font(tb.Font.FontFamily, 18)  '??
        tb.Font = New Font(tb.Font, FontStyle.Bold)
        tb.TextAlign = HorizontalAlignment.Center
        tb.BackColor = Color.Gold
        tb.TextAlign = HorizontalAlignment.Right
        tb.Visible = False
        Me.Controls.Add(tb)

        l1 = New Label
        l2 = New Label
        l3 = New Label
        l4 = New Label
        l5 = New Label
        l6 = New Label
        l7 = New Label
        l8 = New Label
        l9 = New Label

        lc(1) = False
        l1.Location = New System.Drawing.Point(v.polje * 0.56, 0.3)
        l1.Height = v.polje * 0.22
        l1.Width = v.polje * 0.22
        l1.BackColor = Color.Transparent
        ' l1.BackColor = Color.Aquamarine
        l1.AutoSize = False
        l1.Text = 1
        l1.ForeColor = Color.Gray
        l1.Font = New Font(l1.Font.FontFamily, 6)
        l1.Font = New Font(l1.Font, FontStyle.Bold)
        l1.TextAlign = ContentAlignment.MiddleCenter

        l2.Location = New System.Drawing.Point(v.polje * 0.78, v.polje * 0.11)
        l2.Height = v.polje * 0.25
        l2.Width = v.polje * 0.2
        '   l2.BackColor = Color.Aqua
        l2.AutoSize = False
        l2.Text = 2
        l2.ForeColor = Color.Gray
        l2.Font = New Font(l2.Font.FontFamily, 6)
        l2.Font = New Font(l2.Font, FontStyle.Bold)
        l2.TextAlign = ContentAlignment.MiddleCenter
        l2.BackColor = Color.Transparent

        l3.Location = New System.Drawing.Point(v.polje * 0.78, v.polje * 0.37)
        l3.Height = v.polje * 0.25
        l3.Width = v.polje * 0.2
        l3.BackColor = Color.Transparent
        '  l3.BackColor = Color.Red
        l3.AutoSize = False
        l3.Text = 3
        l3.ForeColor = Color.Gray
        l3.Font = New Font(l3.Font.FontFamily, 6)
        l3.Font = New Font(l3.Font, FontStyle.Bold)
        l3.TextAlign = ContentAlignment.MiddleCenter

        l4.Location = New System.Drawing.Point(v.polje * 0.78, v.polje * 0.62)
        l4.Height = v.polje * 0.25
        l4.Width = v.polje * 0.2
        l4.BackColor = Color.Transparent
        ' l4.BackColor = Color.Blue
        l4.AutoSize = False
        l4.Text = 4
        l4.ForeColor = Color.Gray
        l4.Font = New Font(l4.Font.FontFamily, 6)
        l4.Font = New Font(l4.Font, FontStyle.Bold)
        l4.TextAlign = ContentAlignment.MiddleCenter

        l5.Location = New System.Drawing.Point(v.polje * 0.6, v.polje * 0.75)
        l5.Height = v.polje * 0.22
        l5.Width = v.polje * 0.18
        l5.BackColor = Color.Transparent
        '  l5.BackColor = Color.AliceBlue
        l5.AutoSize = False
        l5.Text = 5
        l5.ForeColor = Color.Gray
        l5.Font = New Font(l5.Font.FontFamily, 6)
        l5.Font = New Font(l5.Font, FontStyle.Bold)
        l5.TextAlign = ContentAlignment.MiddleCenter

        l6.Location = New System.Drawing.Point(v.polje * 0.41, v.polje * 0.75)
        l6.Height = v.polje * 0.22
        l6.Width = v.polje * 0.19
        l6.BackColor = Color.Transparent
        '  l6.BackColor = Color.Salmon
        l6.AutoSize = False
        l6.Text = 6
        l6.ForeColor = Color.Gray
        l6.Font = New Font(l6.Font.FontFamily, 6)
        l6.Font = New Font(l6.Font, FontStyle.Bold)
        l6.TextAlign = ContentAlignment.BottomCenter

        l7.Location = New System.Drawing.Point(v.polje * 0.21, v.polje * 0.75)
        l7.Height = v.polje * 0.22
        l7.Width = v.polje * 0.19
        l7.BackColor = Color.Transparent
        '   l7.BackColor = Color.Yellow
        l7.AutoSize = False
        l7.Text = 7
        l7.ForeColor = Color.Gray
        l7.Font = New Font(l7.Font.FontFamily, 6)
        l7.Font = New Font(l7.Font, FontStyle.Bold)
        l7.TextAlign = ContentAlignment.BottomCenter

        l8.Location = New System.Drawing.Point(v.polje * 0.01, v.polje * 0.62)
        l8.Height = v.polje * 0.25
        l8.Width = v.polje * 0.2
        l8.BackColor = Color.Transparent
        '  l8.BackColor = Color.Black
        l8.AutoSize = False
        l8.Text = 8
        l8.ForeColor = Color.Gray
        l8.Font = New Font(l8.Font.FontFamily, 6)
        l8.Font = New Font(l8.Font, FontStyle.Bold)
        l8.TextAlign = ContentAlignment.MiddleCenter

        l9.Location = New System.Drawing.Point(v.polje * 0.01, v.polje * 0.37)
        l9.Height = v.polje * 0.25
        l9.Width = v.polje * 0.2
        l9.BackColor = Color.Transparent
        '   l9.BackColor = Color.Turquoise
        l9.AutoSize = False
        l9.Text = 9
        l9.ForeColor = Color.Gray
        l9.Font = New Font(l9.Font.FontFamily, 6)
        l9.Font = New Font(l9.Font, FontStyle.Bold)
        l9.TextAlign = ContentAlignment.MiddleCenter

        Me.Controls.Add(l1)
        Me.Controls.Add(l2)
        Me.Controls.Add(l3)
        Me.Controls.Add(l4)
        Me.Controls.Add(l5)
        Me.Controls.Add(l6)
        Me.Controls.Add(l7)
        Me.Controls.Add(l8)
        Me.Controls.Add(l9)

        ' Texbox u koji sluzi da se rucno unose cifra, i zatim prepise u Labelu lb i nestane
        Show()
        'Labela vidljiva igracu 
    End Sub
    'END OF  K O N S T R U K T O R    K L A S E       T
    ' Detektovanje klika misem na labelu i pozivanje brojcanika ako je to moguce
    Public Sub reset(ByVal i As Integer, ByVal j As Integer, ByVal skin As Integer) ' bug

        '     If Form2.d.tabela(i, j) Is Me Then
        Form2.d.tabela(i, j).temp = 0
        Form2.d.tabela(i, j).backgroundimage = Form1.f2_prazno_polje
        '   End If

        Form2.aktivirano_dugme = False
    End Sub
    ' postavlja u promjenljive i_dugme i j_dugme na Form2 indeks polja koje je pozvalo funkciju
    Public Sub Markiraj(ByVal i As Integer, ByVal j As Integer)
        Form2.d.tabela(i, j).backgroundimage = Form1.f2_prazno_polje_markirano
        '   Form2.d.tabela(i, j).fokus()
        Form2.aktivirano_dugme = True
        '  Form2.i_dugme = i
        '  Form2.j_dugme = j
    End Sub
    ' funkcija koja upisuje kandidate
    Public Sub Dopuni(ByVal pozicija As Integer)
        ' MsgBox(pozicija)
        Select Case pozicija
            Case 0
            Case 1
                Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).promijeni_labelu(1)
            Case 2
                Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).promijeni_labelu(2)
            Case 3
                Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).promijeni_labelu(3)
            Case 4
                Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).promijeni_labelu(4)
            Case 5
                Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).promijeni_labelu(5)
            Case 6
                Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).promijeni_labelu(6)
            Case 7
                Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).promijeni_labelu(7)
            Case 8
                Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).promijeni_labelu(8)
            Case 9
                Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).promijeni_labelu(9)
        End Select
    End Sub

    '**********************   Dio sa funkcijama za provjeru da li ima istih elemenata u vrstama i kolonama *****************
    ' u koliko ih ima elementi se markiraju crvenom bojom
    ' Procedura koja poziva sve ostale potrebne da se markiraju isti brojevi u vrstama i kolonama
    Sub Provjera_FULL()
        Pocrni_Matricu()
        Provjera_Istih_Po_Vrstama()
        Provjera_Istih_Po_Kolonama()
    End Sub
    Sub Provjera_Istih_Niz_Vrstu_Od_Pozicije_Do_Pozicije(ByVal index_vrste As Integer, ByVal pocetak As Integer, ByVal kraj As Integer)
        Dim j As Integer
        Dim k As Integer
        If kraj - pocetak > 0 Then
            For j = pocetak To kraj - 1
                For k = j + 1 To kraj
                    If Form2.d.tabela(index_vrste, j).lb.text = Form2.d.tabela(index_vrste, k).lb.text Then
                        Pocrveni_Poziciju(index_vrste, j)
                        Pocrveni_Poziciju(index_vrste, k)
                    End If
                Next
            Next
        Else
            '!!!!!!
        End If
    End Sub
    Sub Provjera_Istih_Niz_Kolonu_Od_Pozicije_Do_Pozicije(ByVal index_kolone As Integer, ByVal pocetak As Integer, ByVal kraj As Integer)
        Dim i As Integer
        Dim k As Integer
        If kraj - pocetak > 0 Then
            For i = pocetak To kraj - 1
                For k = i + 1 To kraj
                    If Form2.d.tabela(i, index_kolone).lb.text = Form2.d.tabela(k, index_kolone).lb.text Then
                        Pocrveni_Poziciju(i, index_kolone)
                        Pocrveni_Poziciju(k, index_kolone)
                    End If
                Next
            Next
        Else
            '!!!!!!
        End If
    End Sub
    Sub Provjera_Istih_Po_Vrstama()
        Dim i, j As Integer
        Dim pocetak As Integer = 0
        Dim kraj As Integer = 0
        For i = 0 To Form2.n - 1
            For j = 0 To Form2.m - 1
                If Form2.int_maska(i, j) = 0 Then
                    pocetak = j
                    While Form2.int_maska(i, j) = 0 And j < Form2.m
                        j += 1
                    End While
                    kraj = j - 1
                    granice_vrsta = granice_vrsta & "(" & i & "," & pocetak & ")-(" & i & "," & kraj & ") ; "
                    Provjera_Istih_Niz_Vrstu_Od_Pozicije_Do_Pozicije(i, pocetak, kraj)
                End If
            Next
        Next
        Form5.TextBox23.Text = granice_vrsta
    End Sub
    Sub Provjera_Istih_Po_Kolonama()
        Dim i, j As Integer
        Dim pocetak As Integer = 0
        Dim kraj As Integer = 0
        For j = 0 To Form2.m - 1
            For i = 0 To Form2.n - 1
                If Form2.int_maska(i, j) = 0 Then
                    pocetak = i
                    While Form2.int_maska(i, j) = 0 And i < Form2.n
                        i += 1
                    End While
                    kraj = i - 1
                    granice_kolona = granice_kolona & "(" & pocetak & "," & j & ")-(" & kraj & "," & j & ") ; "
                    Provjera_Istih_Niz_Kolonu_Od_Pozicije_Do_Pozicije(j, pocetak, kraj)
                End If
            Next
        Next
        Form5.TextBox24.Text = granice_kolona
    End Sub
    Public Sub Pocrni_Matricu()
        Dim i, j As Integer
        For i = 0 To Form2.n - 1
            For j = 0 To Form2.m - 1
                If Form2.int_maska(i, j) = 0 Then
                    Form2.d.tabela(i, j).lb.ForeColor = Form1.f2_boja_resenja
                End If
            Next
        Next
    End Sub
    Public Sub Pocrveni_Poziciju(ByVal i As Integer, ByVal j As Integer)
        Form2.d.tabela(i, j).lb.ForeColor = Color.Red
    End Sub
    '**********************      kraj dijela sa provjerama identicnih elemenata **********************************************
    Public Sub Unos(ByVal i As Integer, ByVal j As Integer, ByVal broj As Integer)
        If Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).lb.Text = "" Then
            If Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).temp = 1 Then
                Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).lb.Text = broj
                Provjera_FULL()
            End If
            If Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).temp > 1 Then
                Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).promijeni_labelu(broj)
                Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).lb.Text = ""
            End If
        Else
            If broj > 0 Then
                '    MsgBox(CInt(Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).lb.text))
                Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).promijeni_labelu(CInt(Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).lb.text))
                Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).promijeni_labelu(broj)
                Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).lb.Text = ""
                '    Dopuni(broj)
            End If
        End If
    End Sub
    Public Sub iznad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseHover
        Form2.Focus()
    End Sub
    Public Sub klik(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If Form2.aktivirano_dugme = True Then
            '  MsgBox(e.KeyCode)
            If e.KeyValue = 18 Or e.KeyValue = 110 Then
                vrati_labele_na_default()
            Else
                If e.KeyCode = Keys.Space Then
                    vrati_labele_na_default()
                    Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).lb.Text = ""
                    Provjera_FULL()
                    ' FULL
                Else
                    If e.KeyCode = Keys.NumPad0 Or e.KeyCode = Keys.D0 Then
                        Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).lb.Text = ""
                        Provjera_FULL()
                    Else
                        If e.KeyCode = Keys.A Then
                            If Form2.int_maska(Form2.i_dugme, Form2.j_dugme - 1) = 0 And Form2.j_dugme - 1 > 0 Then ', Form2.j_dugme
                                reset(Form2.i_dugme, Form2.j_dugme, Form2.skin)
                                Markiraj(Form2.i_dugme, Form2.j_dugme - 1)
                                Form2.j_dugme = Form2.j_dugme - 1
                            End If
                        End If
                        If e.KeyCode = Keys.D Then
                            If Form2.int_maska(Form2.i_dugme, Form2.j_dugme + 1) = 0 And Form2.j_dugme + 1 < Form2.m Then ', Form2.j_dugme
                                reset(Form2.i_dugme, Form2.j_dugme, Form2.skin)
                                Markiraj(Form2.i_dugme, Form2.j_dugme + 1)
                                Form2.j_dugme = Form2.j_dugme + 1
                            End If
                        End If
                        If e.KeyCode = Keys.S Then
                            If Form2.int_maska(Form2.i_dugme + 1, Form2.j_dugme) = 0 And Form2.i_dugme + 1 < Form2.n Then ', Form2.j_dugme
                                reset(Form2.i_dugme, Form2.j_dugme, Form2.skin)
                                Markiraj(Form2.i_dugme + 1, Form2.j_dugme)
                                Form2.i_dugme = Form2.i_dugme + 1
                            End If
                        End If
                        If e.KeyCode = Keys.W Then
                            If Form2.int_maska(Form2.i_dugme - 1, Form2.j_dugme) = 0 And Form2.i_dugme - 1 > 0 Then ', Form2.j_dugme
                                reset(Form2.i_dugme, Form2.j_dugme, Form2.skin)
                                Markiraj(Form2.i_dugme - 1, Form2.j_dugme)
                                Form2.i_dugme = Form2.i_dugme - 1
                            End If
                        End If
                        If e.KeyCode = Keys.Escape Then
                            reset(Form2.i_dugme, Form2.j_dugme, Form2.skin)
                        End If
                        Dim broj_za_upis As Integer
                        If e.KeyValue >= 49 And e.KeyValue <= 58 Then
                            broj_za_upis = e.KeyValue - 48
                            Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).temp += 1
                        End If
                        If e.KeyValue >= 97 And e.KeyValue <= 106 Then
                            broj_za_upis = e.KeyValue - 96
                            Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).temp += 1
                        End If
                        Unos(1, 1, broj_za_upis)
                        If e.KeyCode = Keys.E Then
                            If Form1.v.brojcanik = False Then
                                If Form2.aktivirano_dugme = True Then
                                    reset(Form2.i_dugme, Form2.j_dugme, Form2.skin)
                                End If
                                Form4.i_klik = Form2.i_dugme ' predavanje indeksa labele nad kojom se desio klik formi Form4
                                Form4.j_klik = Form2.j_dugme
                                'Me.BackgroundImage = Image.FromFile(Application.StartupPath & "/pictures/ptp.png")
                                Dim relative_p As Point = Me.PointToClient(MousePosition)
                                Dim hh As Integer = relative_p.X
                                Dim p As New Point(MousePosition.X - 105 + (v_za_t.polje / 2 - relative_p.X), MousePosition.Y - 211 + (v_za_t.polje / 2 - relative_p.Y))

                                Form4.point_form4 = p 'Me.PointToScreen(MousePosition)
                                Form4.Show()
                                Form1.v.brojcanik = True
                                '  Markiraj(Form2.i_dugme, Form2.j_dugme)
                            Else
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    Public Sub lb_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lb.MouseClick
        Select Case e.Button
            Case MouseButtons.Left                   ' Lijevi Klik Misem otvara se TextBox
                If Form2.aktivirano_dugme = True Then
                    reset(Form2.i_dugme, Form2.j_dugme, Form2.skin)
                End If
                If Form2.v.f2_aktivna = True And Form2.aktivirano_dugme = False Then
                    If Form2.aktivirano_dugme = False Then
                        Form2.i_dugme = Me.l_i_int     ' predavanje indeksa labele nad kojom se desio klik formi Form4
                        Form2.j_dugme = Me.l_j_int
                        '    Form2.aktivirano_dugme = True   ' markiranje (ucitavanje crvene slike)
                        Markiraj(Me.l_i_int, Me.l_j_int)
                        '    Me.BackgroundImage = Image.FromFile(Application.StartupPath & "/pictures/ptp.png")
                        Me.Focus()
                    End If
                End If
            Case MouseButtons.Right                ' Desni Klik Misem
                If Form1.v.brojcanik = False Then
                    If Form2.aktivirano_dugme = True Then
                        reset(Form2.i_dugme, Form2.j_dugme, Form2.skin)
                    End If
                    Markiraj(Me.l_i_int, Me.l_j_int)
                    Form2.i_dugme = Me.l_i_int      ' predavanje indeksa labele nad kojom se desio klik formi Form4
                    Form2.j_dugme = Me.l_j_int
                    Form4.i_klik = Me.l_i_int      ' predavanje indeksa labele nad kojom se desio klik formi Form4
                    Form4.j_klik = Me.l_j_int
                    Dim relative_p As Point = Me.PointToClient(MousePosition)
                    Dim hh As Integer = relative_p.X
                    Dim p As New Point(MousePosition.X - 105 + (v_za_t.polje / 2 - relative_p.X), MousePosition.Y - 211 + (v_za_t.polje / 2 - relative_p.Y))
                    Form4.point_form4 = p 'Me.PointToScreen(MousePosition)
                    Form4.Show()
                    Form1.v.brojcanik = True
                Else
                End If
            Case MouseButtons.Middle
            Case Else
        End Select
    End Sub 'Form_MouseDown
    'promijeni_labelu(ByVal i As Integer) ulazni parametar intiger koji predstavlja 
    'redni broj(indeks) labele a ujedno i cifru koja ta labela prikazuje
    'Aktiviranje (povecavanje fonta i promjena boje) kandidata(cifre koje su moguce resenje 
    'a nalaze se oko centralne pozicije na labeli lb) 
    Public Sub vrati_labele_na_default()
        Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).l1.Font = New Font(l1.Font.FontFamily, 6)
        Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).l1.Font = New Font(l1.Font, FontStyle.Bold)
        Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).l1.ForeColor = Color.Gray
        Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).l1.TextAlign = ContentAlignment.MiddleCenter
        Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).lc(1) = False
        Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).l2.Font = New Font(l2.Font.FontFamily, 6)
        Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).l2.Font = New Font(l2.Font, FontStyle.Bold)
        Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).l2.ForeColor = Color.Gray
        Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).l2.TextAlign = ContentAlignment.MiddleCenter
        Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).lc(2) = False
        Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).l3.Font = New Font(l3.Font.FontFamily, 6)
        Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).l3.Font = New Font(l3.Font, FontStyle.Bold)
        Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).l3.ForeColor = Color.Gray
        Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).l3.TextAlign = ContentAlignment.MiddleCenter
        Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).lc(3) = False
        Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).l4.Font = New Font(l4.Font.FontFamily, 6)
        Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).l4.Font = New Font(l4.Font, FontStyle.Bold)
        Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).l4.ForeColor = Color.Gray
        Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).l4.TextAlign = ContentAlignment.MiddleCenter
        Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).lc(4) = False
        Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).l5.Font = New Font(l5.Font.FontFamily, 6)
        Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).l5.Font = New Font(l5.Font, FontStyle.Bold)
        Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).l5.ForeColor = Color.Gray
        Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).l5.TextAlign = ContentAlignment.MiddleCenter
        Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).lc(5) = False
        Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).l6.Font = New Font(l6.Font.FontFamily, 6)
        Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).l6.Font = New Font(l6.Font, FontStyle.Bold)
        Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).l6.ForeColor = Color.Gray
        Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).l6.TextAlign = ContentAlignment.BottomCenter
        Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).lc(6) = False
        Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).l7.Font = New Font(l7.Font.FontFamily, 6)
        Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).l7.Font = New Font(l7.Font, FontStyle.Bold)
        Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).l7.ForeColor = Color.Gray
        Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).lc(7) = False
        Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).l7.TextAlign = ContentAlignment.BottomCenter
        Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).l8.Font = New Font(l8.Font.FontFamily, 6)
        Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).l8.Font = New Font(l8.Font, FontStyle.Bold)
        Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).l8.ForeColor = Color.Gray
        Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).lc(8) = False
        Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).l8.TextAlign = ContentAlignment.MiddleCenter
        Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).l9.Font = New Font(l9.Font.FontFamily, 6)
        Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).l9.Font = New Font(l9.Font, FontStyle.Bold)
        Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).l9.ForeColor = Color.Gray
        Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).lc(9) = False

    End Sub
    Public Sub promijeni_labelu(ByVal i As Integer)
        Select Case i
            Case 1
                If lc(1) = False Then                            ' Aktiviranje labele
                    l1.Font = New Font(l1.Font.FontFamily, 8)
                    l1.Font = New Font(l1.Font, FontStyle.Bold)
                    l1.ForeColor = v_za_t.boja_aktivne_labele
                    lc(1) = True
                    l1.TextAlign = ContentAlignment.MiddleCenter
                Else
                    l1.Font = New Font(l1.Font.FontFamily, 6)
                    l1.Font = New Font(l1.Font, FontStyle.Bold)
                    l1.ForeColor = Color.Gray
                    l1.TextAlign = ContentAlignment.MiddleCenter
                    lc(1) = False
                End If
            Case 2
                If lc(2) = False Then
                    l2.Font = New Font(l2.Font.FontFamily, 8)
                    l2.Font = New Font(l2.Font, FontStyle.Bold)
                    l2.ForeColor = v_za_t.boja_aktivne_labele
                    l2.TextAlign = ContentAlignment.MiddleCenter
                    lc(2) = True
                Else
                    l2.Font = New Font(l2.Font.FontFamily, 6)
                    l2.Font = New Font(l2.Font, FontStyle.Bold)
                    l2.ForeColor = Color.Gray
                    l2.TextAlign = ContentAlignment.MiddleCenter
                    lc(2) = False
                End If
            Case 3
                If lc(3) = False Then
                    l3.Font = New Font(l3.Font.FontFamily, 8)
                    l3.Font = New Font(l3.Font, FontStyle.Bold)
                    l3.ForeColor = v_za_t.boja_aktivne_labele
                    lc(3) = True
                    l3.TextAlign = ContentAlignment.MiddleCenter
                Else
                    l3.Font = New Font(l3.Font.FontFamily, 6)
                    l3.Font = New Font(l3.Font, FontStyle.Bold)
                    l3.ForeColor = Color.Gray
                    l3.TextAlign = ContentAlignment.MiddleCenter
                    lc(3) = False
                End If
            Case 4
                If lc(4) = False Then
                    l4.Font = New Font(l4.Font.FontFamily, 8)
                    l4.Font = New Font(l4.Font, FontStyle.Bold)
                    l4.ForeColor = v_za_t.boja_aktivne_labele
                    lc(4) = True
                    l4.TextAlign = ContentAlignment.MiddleCenter
                Else
                    l4.Font = New Font(l4.Font.FontFamily, 6)
                    l4.Font = New Font(l4.Font, FontStyle.Bold)
                    l4.ForeColor = Color.Gray
                    l4.TextAlign = ContentAlignment.MiddleCenter
                    lc(4) = False
                End If
            Case 5
                If lc(5) = False Then
                    l5.Font = New Font(l5.Font.FontFamily, 8)
                    l5.Font = New Font(l5.Font, FontStyle.Bold)
                    l5.ForeColor = v_za_t.boja_aktivne_labele
                    l5.TextAlign = ContentAlignment.MiddleCenter
                    lc(5) = True
                Else
                    l5.Font = New Font(l5.Font.FontFamily, 6)
                    l5.Font = New Font(l5.Font, FontStyle.Bold)
                    l5.ForeColor = Color.Gray
                    l5.TextAlign = ContentAlignment.MiddleCenter
                    lc(5) = False
                End If
            Case 6
                If lc(6) = False Then
                    l6.Font = New Font(l6.Font.FontFamily, 8)
                    l6.Font = New Font(l6.Font, FontStyle.Bold)
                    l6.ForeColor = v_za_t.boja_aktivne_labele
                    l5.TextAlign = ContentAlignment.MiddleCenter
                    lc(6) = True
                Else
                    l6.Font = New Font(l6.Font.FontFamily, 6)
                    l6.Font = New Font(l6.Font, FontStyle.Bold)
                    l6.ForeColor = Color.Gray
                    l6.TextAlign = ContentAlignment.BottomCenter
                    lc(6) = False
                End If
            Case 7
                If lc(7) = False Then
                    l7.Font = New Font(l7.Font.FontFamily, 8)
                    l7.Font = New Font(l7.Font, FontStyle.Bold)
                    l7.ForeColor = v_za_t.boja_aktivne_labele
                    lc(7) = True
                    l7.TextAlign = ContentAlignment.MiddleCenter
                Else
                    l7.Font = New Font(l7.Font.FontFamily, 6)
                    l7.Font = New Font(l7.Font, FontStyle.Bold)
                    l7.ForeColor = Color.Gray
                    lc(7) = False
                    l7.TextAlign = ContentAlignment.BottomCenter
                End If
            Case 8
                If lc(8) = False Then
                    l8.Font = New Font(l8.Font.FontFamily, 8)
                    l8.Font = New Font(l8.Font, FontStyle.Bold)
                    l8.ForeColor = v_za_t.boja_aktivne_labele
                    lc(8) = True
                    l8.TextAlign = ContentAlignment.MiddleCenter
                Else
                    l8.Font = New Font(l8.Font.FontFamily, 6)
                    l8.Font = New Font(l8.Font, FontStyle.Bold)
                    l8.ForeColor = Color.Gray
                    lc(8) = False
                    l8.TextAlign = ContentAlignment.MiddleCenter
                End If
            Case 9
                If lc(9) = False Then
                    l9.Font = New Font(l9.Font.FontFamily, 8)
                    l9.Font = New Font(l9.Font, FontStyle.Bold)
                    l9.ForeColor = v_za_t.boja_aktivne_labele
                    lc(9) = True
                    l5.TextAlign = ContentAlignment.MiddleCenter
                Else
                    l9.Font = New Font(l9.Font.FontFamily, 6)
                    l9.Font = New Font(l9.Font, FontStyle.Bold)
                    l9.ForeColor = Color.Gray
                    lc(9) = False
                    l5.TextAlign = ContentAlignment.MiddleCenter
                End If
        End Select
    End Sub
    ' funkcija mis_iznad_labela poziva se na event MouseClick iznad l1,l2,l3...l9 Labela
    ' nisam mogao pronaci mogucnost da se odredi nad kojom labelom se desio click
    Public Sub click_tb(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb.KeyDown
        If Form2.v.f2_aktivna = True Then
            If (CInt(e.KeyCode) < 58) And (CInt(e.KeyCode) > 47) Then
                Dim uneseni As Integer = e.KeyCode - 48
                lb.Text = (e.KeyValue - 48).ToString
                tb.Visible = False
            Else
                If (CInt(e.KeyCode) < 106) And (CInt(e.KeyCode) > 95) Then
                    Dim uneseni As Integer = e.KeyCode - 96
                    lb.Text = (e.KeyValue - 96).ToString
                    tb.Visible = False
                Else
                    '                    MsgBox(e.KeyCode)
                    Me.tb.Text = ""
                    tb.Refresh()
                    tb.Visible = False
                End If
                Exit Sub
            End If
            '  MsgBox(uneseni)
        End If
    End Sub
    Public Sub click_l1(ByVal sender As Object, ByVal e As System.EventArgs) Handles l1.MouseClick
        promijeni_labelu(1)
    End Sub
    Public Sub click_l2(ByVal sender As Object, ByVal e As System.EventArgs) Handles l2.MouseClick
        promijeni_labelu(2)
    End Sub
    Public Sub click_l3(ByVal sender As Object, ByVal e As System.EventArgs) Handles l3.MouseClick
        promijeni_labelu(3)
    End Sub
    Public Sub click_l4(ByVal sender As Object, ByVal e As System.EventArgs) Handles l4.MouseClick
        promijeni_labelu(4)
    End Sub
    Public Sub click_l5(ByVal sender As Object, ByVal e As System.EventArgs) Handles l5.MouseClick
        promijeni_labelu(5)
    End Sub
    Public Sub click_l6(ByVal sender As Object, ByVal e As System.EventArgs) Handles l6.MouseClick
        promijeni_labelu(6)
    End Sub
    Public Sub click_l7(ByVal sender As Object, ByVal e As System.EventArgs) Handles l7.MouseClick
        promijeni_labelu(7)
    End Sub
    Public Sub click_l8(ByVal sender As Object, ByVal e As System.EventArgs) Handles l8.MouseClick
        promijeni_labelu(8)
    End Sub
    Public Sub click_l9(ByVal sender As Object, ByVal e As System.EventArgs) Handles l9.MouseClick
        promijeni_labelu(9)
    End Sub
    Private Sub lb_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lb.TextChanged
        Dim n As Integer = Form1.int_n
        Dim m As Integer = Form1.int_m
        Dim i As Integer = Form4.i_klik
        Dim j As Integer = Form4.j_klik
        Me.lb.ForeColor = Color.Black
    End Sub
    '  Function Broj_Praznih_Polja_Po_Vrsti(ByVal i As Integer, ByVal j As Integer, ByVal m As Integer, ByVal n As Integer, ByVal mat(,) As Integer) As Integer
    '    Dim jj As Integer
    '    Dim br As Integer = 0
    '        jj = j
    '        While (jj > 0) And (mat(i, jj) = 0)
    '            br = br + 1
    '            jj = jj - 1
    '        End While
    '        Return br
    '    End Function
    '  Function Broj_Praznih_Polja_Po_Koloni(ByVal i As Integer, ByVal j As Integer, ByVal m As Integer, ByVal n As Integer, ByVal mat(,) As Integer) As Integer
    '    Dim ii As Integer
    '    Dim br As Integer = 0
    '        ii = i
    '       While (ii > 0) And (mat(ii, j) = 0)
    '          br = br + 1
    '          ii = ii - 1
    '     End While
    '     Return br
    ' End Function
End Class
Public Class Matrica
    Public tabela(,) As Object
End Class
Public Class Maska
    Public mask(,) As Integer
    'n,m oznaka za velicinu maske, k redni broj maske 
    'raspored se cuva u formi stringa, 1 - puno prazno polje, 2 - puno polje sa brojem ispod dijagonale, 3 - puno polje sa brojem iznad dijagonale
    '4 - puno polje sa dva broa, ispod i iznad dijagonale
    'n, m -dimenzije matrice, k - slucajan broj, tezina 1-easy, 2-medium, 3-hard
    Public Function Vrati_Masku(ByVal n As Integer, ByVal m As Integer, ByVal k As Integer, ByVal tezina As Integer) As String
        ReDim mask(n, m)
        '  Dim dtr As String
        Select Case n * m
            Case 48                                '8 x 6
                Select Case tezina
                    Case 1                         ' easy
                        Select Case k
                            Case 1
                                Return "122122300400300000140002300400300000130001130001"
                            Case 2
                                Return "122122300300300400130000140001300002300300300300"
                            Case 3
                                Return "111222124000300000300001130002140000300000300011"
                            Case 4
                                Return "112221130001300002300300300400140002300000300300"
                            Case 5
                                Return "112221140002300000300400130001140002300300300300"
                            Case 6
                                Return "112211140022300000300000140002300000300000113001"
                            Case 7
                                Return "112211140022300000300000140002300000300000113001"
                            Case 8
                                Return "112221130001140002300300300400300000300000130001"
                            Case 9
                                Return "122122300400300000140002300400300000300000300300"
                            Case 10
                                Return "112221130001140003300300300400140002300000300300"
                        End Select

                    Case 2                          ' mediym  
                        Select Case k
                            Case 1
                                Return "122222300000300000300400130001140002300000300300"
                            Case 2
                                Return "112221140002300000300000140002300000300000130001"
                            Case 3
                                Return "122122300300300400300000130001140002300000300000"
                            Case 4
                                Return "122122300400300000300000130001140002300300300300"
                            Case 5
                                Return "112221140002300000300400140002300000300000130001"
                            Case 6
                                Return "122122300300300400300002300000140000300300300300"
                            Case 7
                                Return "122122300400300000130001140002300400300000300000"
                            Case 8
                                Return "112221140002300000300300300400140002300000300300"
                            Case 9
                                Return "112221140002300000300000300300300400300000130001"
                            Case 10
                                Return "122231300002300000124000300000300022300000130000"
                        End Select
                    Case 3                          ' hard   
                        Select Case k
                            Case 1
                                Return "122122300400300000300000140002300000300000300300"
                            Case 2
                                Return "122221300002300000140000300000300002300000130000"
                            Case 3
                                Return "122222300000300000140002300400300000300000300300"
                            Case 4
                                Return "122222300000300000300300300400140002300000300300"
                            Case 5
                                Return "122122300300300400300000300000140002300000300300"
                            Case 6
                                Return "112221140002300000300400300000140002300000300000"
                            Case 7
                                Return "122222300000300000130001140002300400300000300000"
                            Case 8
                                Return "112221140002300000300300300400300000300000300000"
                            Case 9
                                Return "122122300400300000140000300000300002300000300300"
                            Case 10
                                Return "112221140002300000300400140002300000300000300000"
                        End Select
                End Select
            Case 80                      ' 10 x 8 !!!!!!!!!!!!!!!!!!!!!!!!!!!
                Select Case tezina
                    Case 1
                        Select Case k    ' easy
                            Case 1
                                Return "12211221300240023000000014000400300400223000000012400400300400023000000013001300"
                            Case 2
                                Return "12211122300224003000000030000000300040001130001112400022300000003000300030011300"
                            Case 3
                                Return "12211122100113003002240013000001124000223000300030004000140000023000000030003000"
                            Case 4
                                Return "12222222300000003000000030021400130040011240002230000000300000001300300113003001"
                            Case 5
                                Return "12211222200130003002400030000022140004003000000030040002124000003000130030001300"
                            Case 6
                                Return "12221222300040003000000012400022300000003002140013004001124000223000000030003000"
                            Case 7
                                Return "12211221300140023004000030000400130000001240002130000002300400003000030013001300"
                            Case 8
                                Return "11122211114000221400000030002400300000001400000230000000300240003000000111300011"
                            Case 9
                                Return "12211122300224003000000012400022300030003000400012400022300000003000000030011300"
                            Case 10
                                Return "11221222140040003000000030040022124004003000000030040022124004003000000030003001"
                        End Select
                    Case 2
                        Select Case k   ' medium 
                            Case 1
                                Return "12211222300240003000000013000022140004003000000030040001124000023000000030001300"
                            Case 2
                                Return "12211122300214003000400012400022300000003000000014004002300000003000000030011300"
                            Case 3
                                Return "12222222300000003000000013004001124000223000000030003000300224003000000011300011"
                            Case 4
                                Return "12211222300240003000000013000022140004003000000030040001124000023000000030001300"
                            Case 5
                                Return "12221222300040003000000012400022300000003002240014000002300000003000300013003001"
                            Case 6
                                Return "11221122140024003000000030040000300004001240002230040000300004003000000030043001"
                            Case 7
                                Return "11221222140040003000000030040002124004003000000030040022140004003000000030003001"
                            Case 8
                                Return "12222122300003003000040013004002124000003000000030000021140040023003000030030000"
                            Case 9
                                Return "12222211200000223000000014002400300000223000000012400000300240023000000011300000"
                            Case 10
                                Return "12222222300000003000000030022400130000011240002230003000300224003000000013000001"
                        End Select
                    Case 3
                        Select Case k   ' hard
                            Case 1
                                Return "11222221140000023000000030022400140000023000000030004000124000223000000030003000"
                            Case 2
                                Return "12222211300000223000000030024000300000223000000012400000300024003000000011300000"
                            Case 3
                                Return "12222122300004003000000030024000124004003000000030040022300024003000000030030000"
                            Case 4
                                Return "12222222300004003000000030024002124000003000000030000022140024003000000030030000"
                            Case 5
                                Return "12222221300000023000000030014000300400223000000012400300300024003000000013000000"
                            Case 6
                                Return "11221222140040003000000030040000300004001240002230040000300004003000000030003001"
                            Case 7
                                Return "12221221300040023000000012400400300400003000000030000400300400223000000013003000"
                            Case 8
                                Return "12222222300000003000000013000001140030023002240030000000124000223000000030003000"
                            Case 9
                                Return "12212222300300003004000014004000300000223000000012400000300040023000030030000300"
                            Case 10
                                Return "12222222300000003000000030021400300040001240002230000000300040003000000011300011"
                        End Select
                End Select
            Case 120                   ' 12 x 10   easy
                'maska
                Select Case tezina
                    Case 1
                        Select Case k
                            Case 1
                                Return "122122212230030003003004000400300003000013002240011400000002300300030030040004001140030021140004000230030003003003000300"
                            Case 2
                                Return "122112212230014004003004000000300001400113002400021240000300300300040030040000211300014002140024000030000003003003001300"
                            Case 3
                                Return "112211122113002140011400040002300300030030040004001240030022300022400030040004001300000001140004000230030003003003000300"
                            Case 4
                                Return "122122212230030003003004000400130004000112400000223004000400300003000014002240023003000300300400040013000000011130030011"
                            Case 5
                                Return "122122112230030023003004000400300013000014002400213000004002300400040013004000001240013002300002400030030003003001300300"
                            Case 6
                                Return "122112212230013003003002400400300003000014000400213003004002300400030013004004001240030002300004000030030013003003001300"
                            Case 7
                                Return "112211221114002300223000040000300400240014003000003000400022300400040012400030003000004002300240040030000300001130013001"
                            Case 8
                                Return "122122212230030003003004000400130003000114000400023003000300300400040030002140001140040021140000000230030003003003000300"
                            Case 9
                                Return "111221122112400230023000004000300230040014002400003000000022300400040012400000003000023002300400240030003000001300130011"
                            Case 10
                                Return "122122212230030003003004000400130004000113000000023004000400300021400012400400223003000300300400040013000000011130030011"
                        End Select
                    Case 2                       ' 12 x 10 medium
                        Select Case k
                            Case 1
                                Return "111221222112400300023000040000300240000030004000221400000300300300040030040000021240003000300000240030000300001300030011"
                            Case 2
                                Return "122122112230030024003004000000140024000230000004003004004000124000002230004004003004000000140002400230000003003001300300"
                            Case 3
                                Return "112212212213004003001400000400300004000230040040003000400400124000002230040040003000400400140004000030030000013003003001"
                            Case 4
                                Return "122122212230030003003004000400300004000012400000223003000300300400040014000000023000224000300400040013000000011130030011"
                            Case 5
                                Return "122122122130040030023000004000130040040012400400023003000000300400030030000004001400040021300400400230003000001300300300"
                            Case 6
                                Return "122122212230030003003004000400140003000230000400003004000400124000002230002240003004000400140000000230001130003000113000"
                            Case 7
                                Return "122122112230030024003004000000140014000230004003003000000400124000002230030000003004003000140002400230000003003001300300"
                            Case 8
                                Return "112222222113000000011400000002300400040030002140001240040022300300030030040004001400030002300004000030030003003003000300"
                            Case 9
                                Return "122122202230030003003004000400300003000014002240023003000300300400040013000000011240030022300004000030030003003003000300"
                            Case 10
                                Return "122122122230030040003004000000300040040011400230021400004000300400040030003000011400240022300400400030000003003000300300"
                        End Select
                    Case 3          '               12 x 10 hard
                        Select Case k
                            Case 1
                                Return "122122212230030003003004000400300014000230004000003000000400124000002230040000003000003000140002400030030003003003000300"
                            Case 2
                                Return "122122212230030003003004000400130000000112400300223000224000300400040013000000011400000002300004000030030003003003000300"
                            Case 3
                                Return "112212212214004003003000000400300400000030002400221400004000300400040030004000021240024000300000040030030000003003003001"
                            Case 4
                                Return "122122212230030003003004000400130000000112400300223000224000300400040013000000011400000002300004000030030003003003000300"
                            Case 5
                                Return "122122122130040030023000004000140040040030000400003000000022300400040012400000003000040000300400400230003000001300300300"
                            Case 6
                                Return "122122222230030000003004000000300030040013002400021240000000300400040030000000211400023002300400400030000003003000000300"
                            Case 7
                                Return "122221222230000300003000040000300400040014000000023000040000300400040011400000211400214002300004000030030003003003000300"
                            Case 8
                                Return "112212212214004113003000000400300400000030002400213000004002300400040013004000001240024000300000040030030000003003003001"
                            Case 9
                                Return "112222222113000000011400000002300400040030002240001240000022300300030030040004001400030002300004000030030003003003000300"
                            Case 10
                                Return "112212212214004003003000000400300400000230002400001140004000140000000130004000223000024000140000040030030000003003003001"
                        End Select
                End Select
                
            Case 144                         ' 12 x 12   easy
                Select Case tezina
                    Case 1
                        Select Case k
                            Case 1
                                Return "122112221122300230001400300040004000114000300021140002240002300300000300300240002400113000300011124000400022300040004000300300000300300300300300"
                            Case 2
                                Return "112212211222130040014000140000040000300400000002300023001300130004002400124000400021300130030002300240024000140000000400300003000001300013003001"
                            Case 3
                                Return "111221112211124001130022300002240000300400000400140030003002300040004000300400400400114000000021140040004002300002240000300300000300300130001300"
                            Case 4
                                Return "122122122122300400300400300000400000140030003002300140002300300400000400124002140022300000400000300030003000140040004002300300300300300300300300"
                            Case 5
                                Return "122112221122300230001400300040004000124000000022300400300400300002240000140040004002300300000300300400400400300040004000113000000011113001130011"
                            Case 6
                                Return "122112221122300230001400300040004000140000300002300300400300300240002400113000000011124000000022300002140000300400400400130030003001130030003001"
                            Case 7
                                Return "122122122122300300300300300400400400130040030000124000040021300004003002300230002400130040040000124003000021300004004002300300300300300300300300"
                            Case 8
                                Return "122222112211300000230022300000040000130024002400124000400001300300040002300240002300130004000400140000400021300240024002300003000000113001300000"
                            Case 9
                                Return "112212221221130030003001140040004002300400300400300002240000140030003002300240002400300000400000124000000022300240002400300000300000113001130011"
                            Case 10
                                Return "122212211221300030024001300040000002114000400400140004004000300240040022300000400000124004002400300040040001300400400022130000003000130013003000"
                        End Select
                    Case 2
                        Select Case k             'medium
                            Case 1
                                Return "122122122211300400300022300000400000300040000400114003003002140004004000300400400400300030030001140040040022300400004000300000300000113000300300"
                            Case 2
                                Return "122212211221300040013002300000024000300400300400300002400002124000023000300030004000300024000022140000140000300400400400300013000000130013003000"
                            Case 3
                                Return "122211221122300023002300300004000400300400400000114000014002140040040000300400000400300003004001140024000022300000400400300300030000300130013000"
                            Case 4
                                Return "112212211222140040023000300000004000300400300400124000240000300014000002300240001400140000024000300002300022300400400400300030000000300013003001"
                            Case 5
                                Return "122100110001300400140001300000400002140040002400300400040000300004000021130040004002124000040000300004000400300240004002130000300000130001300300"
                            Case 6
                                Return "122212221222300030003000300040004000300400300400130002240001140030003002300240002400300000400000124000000022300240002400300000300000113000300011"
                            Case 7
                                Return "122122122122300400300400300000400000140030003002300140002300300400300400124002240022300030003000300040004000124000000022300000300000300300300300"
                            Case 8
                                Return "122112221122300140002300300400000400140000240002300040003000300004004000124000400022300030040000300040004000140002400002300300000300300130001300"
                            Case 9
                                Return "122221122122300002300300300000400400140030040000300024004001300300000022300400400300114000000400140040023000300004004002300300300000300300130000"
                            Case 10
                                Return "122112222122300130000400300240000000140004004000300000230001300230040022300040003000114003002400140002400000300040040002300000001300300300001300"
                        End Select
                    Case 3                      ' hard
                        Select Case k
                            Case 1
                                Return "122112221122300140002300300400000400140000400002300030003000300240002400124000300022300002240000300400000400140040004002300000300000300001130000"
                            Case 2
                                Return "122122122122300300300300300400400400130040004001124000000022300400300400300002240000140040004002300400000400300000400000300030003000300130001300"
                            Case 3
                                Return "122122122122300300400300300400000400140040004002300000400000300400000400124000000022300040004000300002140000140000400002300130001300300130001300"
                            Case 4
                                Return "112221122122140002300400300000400000300400000002300014000400130040040000124000400024300004003002300400024000140000000400300000300000300300130001"
                            Case 5
                                Return "122221112222300002140000300000400000130040004001124000000022300002140000300300400300300400000400114000000021140040004002300300000300300300300300"
                            Case 6
                                Return "122122122122300400300400300000400000140040004002300300000300300400000400300040004000113002240011124000000022300040004000300300000300300300300300"
                            Case 7
                                Return "111222112222124000230000300000040000300240000000124001400400300004003002300030004000140040030000300400240022300000002400300003000000300001300011"
                            Case 8
                                Return "111221122222124002300000300000400000300400004002124003000300300024000400300000400000300300014000300400040022140040000400300000300000300000130011"
                            Case 9
                                Return "122122122122300400300400300000400000140030003002300240002400300002240000124000000022300300000300300400300400140000400002300030003000300130001300"
                            Case 10
                                Return "122122122122300300300300300400400400300030003000140040004002300400300400300002240000113000000011124000000022300040004000300300000300300300000300"
                        End Select
                End Select
            Case 192                         ' 16 x 12   easy
                Select Case tezina
                    Case 1
                        Select Case k
                            Case 1
                                Return "112212212211221122111400300300130014002230004004002400400000300400300300300004001300014004004004002214001400400400400000300240040000040014003000004004004001400110400400300300140002300400004004004004003000003001300300300011300130013003003001"
                            Case 2
                                Return "122122211222112221223004000230001400040030000000400040000000140024000030000240023003002300400140030030040002300014000400300023004000400140001130023000000014001112400040021400400022300240040040040024003000000030003000000011300300300030030011"
                            Case 3
                                Return "112212212211222112211300300300130001300114004004002400024002300400000300240003003000040024000000040011300013000400004000124000240040013000113000400004000240002230030000000140040000300400024004000004001300130001300300300113001300013003003001"
                            Case 4
                                Return "122112211222112211223002400140002300240030000004000004000000114001400000002300211400240040004002400230000003004003000000300400240000024004001300400040004000400112400300021400030022300002400040002400003001300030003000130030013001300013001300"
                            Case 5
                                Return "112211221122112211221300230013002400230014000400240000000400300400400024002400013000400000002300002214000400240004002300300300400040004004003002400300024004000211400002400000004000140002400240004004003003000000013003000130013001300130013001"
                            Case 6
                                Return "111221122111221122111140013002140013002114000240004000240002300230014000230014003000400400000400400011300040004000400011124003003000300300223000040040004004000030040040021400400400140040000040000040023000000130001300000030030001300013000300"
                            Case 7
                                Return "112211221122112211221300230013002400230014000400240000000400300400400024002400013000400000002300002214000400240004002300300300400040004004003002400300024004000211400002400000004000140002400240004004003003000000013003000130013001300130013001"
                            Case 8
                                Return "111221122212211222111240023000400140002130000040000004000002300400000400400023001040040000230030040030003001300400240022300040024000130030001240023003002400400030030040024000040022300240004004000004001300000300000030000011300013003000130011"
                            Case 9
                                Return "112211221221221122111400230040030014002230000400000400400000300400230040000013001300400230004002400212400300240002300000300400300000004004003000002400023004002114001400400013004002300240000040024004003000003003000003000011300130030030013001"
                            Case 10
                                Return "111221122111221122111140013002240013002114000240000000240002300130004000400013003002400002140000240013000024004002400001124004003000300400223003000040004000030030040023003001400400140040040040040040023000000030003000000030000300300030030000"
                        End Select
                    Case 2
                        Select Case k          ' medium
                            Case 1
                                Return "112212221122122112211300300023004001300214004000040000024000300002400040030004003000000130000230000130013002400400240022300240000040000013001140023004001300240014000023000024000000300400040040002400003000130000030000300113001300300130003001"
                            Case 2
                                Return "112211222111222112211400140002140002300230004000004000004000300400023000140004001400030040004003000230000240021400240000300230040040040014001300400040004000400112400140000000230022300004000224000400003001300300000300130030013001300013001300"
                            Case 3
                                Return "122112212212212211223001400400300400230030040000004000000400130004003000300400011400300140002300300230014004004004002300300400400000004004001140030040004003002114002400021400024002300400240040024004003000000030003000000013001300300030013001"
                            Case 4
                                Return "122112221221122122113002300040014003002230004000000400040000114000400140014004001400000014001400400130024002400400030002300001400000002400001300040004001400240014004001400140000001300400140024004000223000030003000000300011300300130030001300"
                            Case 5
                                Return "122112221222122211223002300030003000140030004000400040004000124000140030013000223003004000400040030030023000300030001400130040024000240040011400023000000014000230030040021400400300300240000040000024001300030030003003000111300300300030030011"
                            Case 6
                                Return "112211221222122112211400140030003002300230004000400040004000300400300030003004001300024002240024000114000001400023000002300140040000040023003004004000400040040011300300300030030011124004004000400400223000000300300300000030013003003003001300"
                            Case 7
                                Return "112212211222112212211400300130001300300230004002400024004000300400000040000004001300024000000024000114003002400024003002300240000224000024003000014000000023000011300400400040040011124000000224000000223000300300000300300030013001300013001300"
                            Case 8
                                Return "122122112212211221223003002300400140030030040004000004000400130023004000400140011240024000300024002230040000022400000400300000023000140000001140030040004003002114002400003000024002300000400224004000003003000300000300030030013001300013001300"
                            Case 9
                                Return "122112211222112211223001400140002300230030040004000004000400130003000224000300011240024000000024002230004004000004004000300400000214000004001140024000400024002114003002300014003001300040004000400040003003003000300030030030030013003001300300"
                            Case 10
                                Return "122122112211221122003004001300230014001130000024000400400022140030000300400030003000240002400002400030000400400400300400124000140000024000223004004004004003000030001400002300023000300040004004000040021130003003000130000011300130013001300300"
                        End Select
                    Case 3
                        Select Case k                    ' hard 
                            Case 1
                                Return "122122112212211221223004001400400230040030000040000000400000300030003000300030003002400240002400240013000230003000140001124000400224004000223000400400000400400030040000300030000400124004004000400400223000300300300300300030013003003003001300"
                            Case 2
                                Return "122112221122212211223001300013000300230030023000230003000300140004000001400000003000001300240000400030040024000000030011113003004000400400221240040000000130040030004000014002400000300000002400000400023003000300013000130030013003000130001300"
                            Case 3
                                Return "122211221222122112223000140030003002300030004000400040004000124000240030024000223004000000400000040030000400400040040000124000140000023000223004004000000040040030002400021400024000124000040040040000223000000030003000000030001300300030013000"
                            Case 4
                                Return "122211221221221122113000230040030013002230000400000400240000300400400140030024001240000014001400000030004004000240040000300400400000004004003000040014000400400030000001400140000022300240040024004004003000013003000003000011300130030030013000"
                            Case 5
                                Return "122122211222112221223003000230001400030030040000400040000400130024000040000240011240001400000230002230000040000000400000300024000214000240001240000400400400002230040040000000400400300004004000400400001300300300300300300113003003003003003001"
                            Case 6
                                Return "122112211221221222113001400130040030002131140002400000400002300000400130030024001400130002400400000030002400400400000022300000400000004000001240000004004001300030000003001300024002300240040024004000001300003000001300030011300030030013001300"
                            Case 7
                                Return "111221222212222122111240030000300003002230000400004000040000300400014000230004001140000400000400002114001400022400023002300040004000400040003003002400000240030030040000003000000400124004000224000400223000300300000300300030013001300013001300"
                            Case 8
                                Return "122112221122211222223001400014000230000030040000300000400000300001400002300240011300240004002400000212400002400000300300300300300040004004003004004000002400002113000002300400014002140024002400002400003000003000003000030030000013000130001300"
                            Case 9
                                Return "111221221122221221221130030013000040030012400400240000000400300400400040040000013000400300004003002214000002400400024000300400400000004004003000230004002300000211400400400004004000140000040040004004003003000000013003001130030030000130030011"
                            Case 10
                                Return "112212211222112212211400300230001400300230004000400040004000300002400030002400001140000002240000002114004004000004004002300003003000300300003000040040004004000030024000021400002400124000240040024000223000000030003000000030001300300030013000"
                        End Select
                End Select
        End Select
        Return "122122300400300000140002300400300000130001130001"
    End Function
    ' funkciji se salj maska u string formatu a vraca masku u vidu matrice intiger-a
    Public Function Napravi_Integer_Masku(ByVal n As Integer, ByVal m As Integer, ByVal s() As Char) As Array
        Dim i, j, br As Integer
        Dim int_matrica(,) As Integer
        br = 0
        For i = 0 To n
            For j = 0 To m
                int_matrica(i, j) = Val(s(br))
                br += 1
            Next
        Next
        Return int_matrica
    End Function
End Class
Public Class Orginal_Matrica
    Public prava_matrica(,) As Integer
    Public brojevi() As Char
    Public za_stampu As String
    Public randomNum As New Random(Now.Millisecond)
    Public slucajan As Integer
    Public vracanje As Integer = 0
    Public i_staro As Integer = 0
    Public j_staro As Integer = 0

    Sub New(ByVal n As Integer, ByVal m As Integer, ByVal mas() As Char)
        ' matrica koju treba da napravi konstruktor
        ReDim prava_matrica(n, m)
        Dim i, j, i_za_mas As Integer
        '  Dim s As String
        i_za_mas = 0
        For i = 0 To n
            For j = 0 To m
                prava_matrica(i, j) = Val(mas(i_za_mas)) * -1
                '   br += 1
                i_za_mas += 1
                '   s = s & " " & br
            Next
            '       s = s & vbCrLf
        Next
        '       Form5.TextBox1.Text = s
    End Sub
    Public Function gotova_matrica_iz_file_a(ByVal n As Integer, ByVal m As Integer, ByVal resenje As String, ByVal mas() As Char) As Array
        Dim i, j As Integer
        ReDim prava_matrica(n, m)
        Dim br As Integer = 0
        For i = 0 To n - 1
            For j = 0 To m - 1
                If mas(br) = "0" Then
                    prava_matrica(i, j) = Val(resenje(br))
                End If
                br += 1
            Next
        Next

        Return prava_matrica
    End Function
    ' n, m, slucajan, tezina, maska
    Public Function gotova_matrica(ByVal n As Integer, ByVal m As Integer, ByVal k As Integer, ByVal tezina As Integer, ByVal mas() As Char) As Array
        ReDim prava_matrica(n, m)
        brojevi = "123"
        Dim nn(9) As Integer
        Dim r As New Random
        Dim s As String = ""
        Dim i, t As Integer
        Dim tr As Integer
        ' generisanje i mijesanje niza
        For i = 0 To 8
            nn(i) = i + 1
        Next
        For i = 0 To 8
            tr = r.Next(1, 9)
            t = nn(i)
            nn(i) = nn(tr)
            nn(tr) = t
        Next
        '   For i = 0 To 8
        ' s = s & " " & nn(i)
        ' Next
        ' end of generisanje niza 
        Dim br_mas As Integer = 0
        Dim br_br As Integer = 0
        '        Form5.TextBox17.Text = s
        Select Case n * m
            Case 48                                '8 x 6    ' easy, medium, hard
                brojevi = "123456567891234567678912345678789123456789891234"
                For i = 0 To n - 1
                    For j = 0 To m - 1
                        If mas(br_mas) = "0" Then
                            prava_matrica(i, j) = nn((Val(brojevi(br_br)) - 1))
                            '  prava_matrica(i, j) = Val(brojevi(br_br))
                        End If
                        br_br += 1
                        br_mas += 1
                    Next
                Next
                Return prava_matrica
            Case 80                      ' 10 x 8 
                Select Case tezina
                    Case 1
                        Select Case k    ' easy
                            Case 1
                                brojevi = "39941463725792181671287456996131659868317429131"
                            Case 2
                                brojevi = "89153541627276584918213812486963517422135139226"
                            Case 3
                                brojevi = "9515782967138421142689489213689742167534135421"
                            Case 4
                                brojevi = "54269783241756159239681296724859253174696318452"
                            Case 5
                                brojevi = "39931137122143649859358612412724694788943742112"
                            Case 6
                                brojevi = "29821413564283986918547181961129841267534698216"
                            Case 7
                                brojevi = "39961324132531298957366457586931378952153132821"
                            Case 8
                                brojevi = "37167958312931958674215432246351797869836795126"
                            Case 9
                                brojevi = "19933752461218896142124321142427869521365741321"
                            Case 10
                                brojevi = "48839412367592799691517246397593119972485672132"
                        End Select
                    Case 2
                        Select Case k   ' medium 
                            Case 1
                                brojevi = "3989117346528579612591526347933121823268957412612"
                            Case 2
                                brojevi = "9529712213698753641296485272173487695227516431371"
                            Case 3
                                brojevi = "826143593825671531976437215612329831722563184712"
                            Case 4
                                brojevi = "2981915246377589312314635872181241352274695815217"
                            Case 5
                                brojevi = "3973181386524921395724115133514248962571628397667"
                            Case 6
                                brojevi = "1839289654715312537121831291597875989152143861315"
                            Case 7
                                brojevi = "7126169274851861995411862573364998381572146394139"
                            Case 8
                                brojevi = "8123629387412919746891652473346121479137321359587"
                            Case 9
                                brojevi = "8241396528471219431256478952347211734297163893847"
                            Case 10
                                brojevi = "723615495472868191341279312164989271834165252318"
                        End Select
                    Case 3
                        Select Case k   ' hard
                            Case 1
                                brojevi = "48123469287512515697851283649348963966417523965986"
                            Case 2
                                brojevi = "237145792846125144132635649782173489519134582712346"
                            Case 3
                                brojevi = "621936943765881124161262381455193948297693548832316"
                            Case 4
                                brojevi = "641241813759492988946742561739768319199375648751827"
                            Case 5
                                brojevi = "427351659784213921211636947584223216199385746271935"
                            Case 6
                                brojevi = "912812864153875798152375863312531832112947862562114"
                            Case 7
                                brojevi = "912157248596136314673267529842514715918482561331921"
                            Case 8
                                brojevi = "15328643754986421532179937341893569752158436637213"
                            Case 9
                                brojevi = "965879531532484134126382796544823121512879548146217"
                            Case 10
                                brojevi = "35412762864597178369732119627465131824214957862391"
                        End Select
                End Select
            Case 120                   ' 12 x 10 

                Select Case tezina     ' easy
                    Case 1
                        Select Case k
                            Case 1
                                brojevi = "62179799729812859757483112489572686213592162431136969813292415812113293"
                            Case 2
                                brojevi = "971734613596788475315121439872167813571472153152995314258739671162784"
                            Case 3
                                brojevi = "17155984891251246849787947121427127371379279456869812685412352163497"
                            Case 4
                                brojevi = "818961292371578193925784697512513126589759131339462942818621465372171"
                            Case 5
                                brojevi = "399581132169325117321839124531364829518415342149732511839128996831562"
                            Case 6
                                brojevi = "483729131516241393781271232961496612695328574772123149785128121419232"
                            Case 7
                                brojevi = "929252144198671579512136498783916142519369866412326911279725191328379"
                            Case 8
                                brojevi = "29132411331479596598213142317963927423121423978151495672892329634121892"
                            Case 9
                                brojevi = "392774162689154191713154691785418492483614275321839519562934967844981"
                            Case 10
                                brojevi = "154123131986976984972763145137936168998676621842181499689562714351895"
                        End Select
                    Case 2
                        Select Case k      ' medium
                            Case 1
                                brojevi = "8152647951342966748962924141253929589621211725396898621534619875417298492"
                            Case 2
                                brojevi = "3721241657143991894345162121824389769812318227176718496214568537913291439"
                            Case 3
                                brojevi = "7993344623149428129859622148696121769484317678124816989272139447965311879"
                            Case 4
                                brojevi = "864123897231163215875997468968248321935312761354359968231421347256891315"
                            Case 5
                                brojevi = "2918141532486776911213412137953862881231576983522157814615369847986512514"
                            Case 6
                                brojevi = "369871416531598965982413324113896344712368593124938566351428698172374391"
                            Case 7
                                brojevi = "2927311239785651142986691316342549274691421354797138298953156234152299331"
                            Case 8
                                brojevi = "4836125592846793192813128949237153176979896312154125897531237968411362159"
                            Case 9
                                brojevi = "7131731971241285979587241224648461321451613254797127985314221416941313281"
                            Case 10
                                brojevi = "8216162945876932189271971413289861249851986413231211428973368597312516494"
                        End Select
                    Case 3
                        Select Case k   ' hard
                            Case 1
                                brojevi = "93712587296815645412412876498637953712435965768395241626789612495498163134148"
                            Case 2
                                brojevi = "29125391728915156349213318944891272812845679272415632513985714213687613641"
                            Case 3
                                brojevi = "1819725796389113125364821715978912241626976995785863972131261543121813"
                            Case 4
                                brojevi = "29125391728915156349213318944891272812845679272415632513985714213687613641"
                            Case 5
                                brojevi = "81927898674271511394132551322947685362396853162478794785963155391336124241318"
                            Case 6
                                brojevi = "39264135139853762519759746922689743974921651276343128112519683579862924583145"
                            Case 7
                                brojevi = "9785241323518957486892968215347914413215347693786951817859732127128591986937"
                            Case 8
                                brojevi = "181913589637271312534646981243614932938185721534618265893767926431257192116"
                            Case 9
                                brojevi = "27364155928647931988141289297681156172179321978956984321213597214798649368"
                            Case 10
                                brojevi = "211736953768598112534631957851262568497211268947893132371427115581794697968"
                        End Select
                End Select
            Case 144                         ' 12 x 12      easy
                Select Case tezina
                    Case 1
                        Select Case k
                            Case 1
                                brojevi = "7117995968298621298512214298398679412173212969823123141221849862182421538293956193"
                            Case 2
                                brojevi = "839519641263124316172534869848617311276935489946117221958696247359122531427134219124"
                            Case 3
                                brojevi = "39923214813216832148471986168967946981815217162895479261329251331424821439711629485"
                            Case 4
                                brojevi = "381693591263464132677213721968619438142971481684977948614221424173398371694616159319797"
                            Case 5
                                brojevi = "29214891428697318213569721479799684813231986389534125513116599764372116297834658293"
                            Case 6
                                brojevi = "72839619682142861624123495137872131239729645784851236231519584171941658398932627652"
                            Case 7
                                brojevi = "29179725157925191783936836422151237993852141224461624385879231449811972493148911223"
                            Case 8
                                brojevi = "35897961257344127191359721189694938163212514921493813689124195692143211725839224361"
                            Case 9
                                brojevi = "9361212219467925481241589759871213215135896196487412761327645274989258793342511791"
                            Case 10
                                brojevi = "124929424981435251498396897821492187161342514322128913212959895812373964875121221896"
                        End Select
                    Case 2
                        Select Case k                 ' medium
                            Case 1
                                brojevi = "6116261947684987682197581939211212413859967869353213186459796294958739843126651424899479"
                            Case 2
                                brojevi = "128191553986739831523761241714276987489694621142142398783795321971717932317396856492142"
                            Case 3
                                brojevi = "721172897584926986615124389671396247859122361512586986684195782534139121694768599721731"
                            Case 4
                                brojevi = "711214269285479631893532136259878624215312196599547821335218692429519317281734659862913"
                            Case 5
                                brojevi = "812583692648941258712122319378595987789564962482314213478392417615351159137386977212561"
                            Case 6
                                brojevi = "72181217498698631287931331912926322131575968811632469847947316592512974132653241148497"
                            Case 7
                                brojevi = "721412219685746978376121485968392118581313581356956122191829867126354418234879693741978"
                            Case 8
                                brojevi = "8161279929874662812512414298618259784739141298698612375921348941225428531383215438491521"
                            Case 9
                                brojevi = "3869925215243418191137298234291716721534476179915937863221499869738385613293245121139873"
                            Case 10
                                brojevi = "811923719326471538968159825314938123152642948689612697986921352171994647952865413136279"
                        End Select
                    Case 3                       ' hard
                        Select Case k
                            Case 1
                                brojevi = "9469894811254361697531241234891729735681231796314282979393124154883995521391452376589842"
                            Case 2
                                brojevi = "81959197533556232411847892531734423179824978212142114156796978964632412511289575636928"
                            Case 3
                                brojevi = "16152161684986786946143724318531429724731935679824983281398431241329278892731289596213614"
                            Case 4
                                brojevi = "928976854123519329818473628619824978584213986859795671492849814263281547934215974686736128"
                            Case 5
                                brojevi = "2789957812453641231782149649587258978359163979162913524284289567617811327257411719963549"
                            Case 6
                                brojevi = "81233737927485487979512712367849597926314216899787434829132467589231285918953172626213948"
                            Case 7
                                brojevi = "21828566783944987146273514358149584269121427128695183153269198736725411512838369578795213"
                            Case 8
                                brojevi = "245342148697869473682138697971321987625132416963872879821457283715632148694867381623621596"
                            Case 9
                                brojevi = "1619136198647467897151217498239223186231295687494531248442716941174238158696973755342197"
                            Case 10
                                brojevi = "62167968976854498517136316996831181295217985935794685725324681217198489848479613924362121"
                        End Select
                End Select
            Case 200                         ' 16 x 12            easy
                Select Case tezina
                    Case 1
                        Select Case k
                            Case 1
                                brojevi = ""
                            Case 2
                                brojevi = ""
                            Case 3
                                brojevi = ""
                            Case 4
                                brojevi = ""
                            Case 5
                                brojevi = ""
                            Case 6
                                brojevi = ""
                            Case 7
                                brojevi = ""
                            Case 8
                                brojevi = ""
                            Case 9
                                brojevi = ""
                            Case 10
                                brojevi = ""
                        End Select                        ' medium
                    Case 2
                        Select Case k
                            Case 1
                                brojevi = ""
                            Case 2
                                brojevi = ""
                            Case 3
                                brojevi = ""
                            Case 4
                                brojevi = ""
                            Case 5
                                brojevi = ""
                            Case 6
                                brojevi = ""
                            Case 7
                                brojevi = ""
                            Case 8
                                brojevi = ""
                            Case 9
                                brojevi = ""
                            Case 10
                                brojevi = ""
                        End Select
                    Case 3                      ' hard
                        Select Case k
                            Case 1
                                brojevi = ""
                            Case 2
                                brojevi = ""
                            Case 3
                                brojevi = ""
                            Case 4
                                brojevi = ""
                            Case 5
                                brojevi = ""
                            Case 6
                                brojevi = ""
                            Case 7
                                brojevi = ""
                            Case 8
                                brojevi = ""
                            Case 9
                                brojevi = ""
                            Case 10
                                brojevi = ""
                        End Select
                End Select
        End Select
        ' generisanje niza od 9 elemenata i rand mijesanje
        For i = 0 To n - 1
            For j = 0 To m - 1
                If mas(br_mas) = "0" Then
                    prava_matrica(i, j) = nn((Val(brojevi(br_br)) - 1))
                    '  prava_matrica(i, j) = Val(brojevi(br_br))
                    br_br += 1
                End If
                br_mas += 1
            Next
        Next
        Return prava_matrica
    End Function
    Public Function Generisi_matricu_slucajnih_brojeva(ByVal n As Integer, ByVal m As Integer, ByVal mas(,) As Integer) As Array
        ReDim prava_matrica(n, m)
        Dim i, j As Integer
        Dim s As String = ""
        Dim broj As Integer
        Dim randomNum As New Random
        broj = randomNum.Next(1, 9)
        '  For i = 0 To n - 1
        '   For j = 0 To m - 1
        '  mas(i, j) *= -1
        '   If mas(i, j) >= 0 Then
        '    s = s & "    " & mas(i, j)
        's = s & "  " & mas(i, j)  '??????????????????????
        '   '     Else
        '   s = s & " " & mas(i, j)
        '    End If
        '     Next
        's = s & vbCrLf
        '    Next
        '      Form5.TextBox6.Text = s
        '   MsgBox(n & " " & m)
        Iterativno(n, m, mas)                              ' odluka
        '  BackTracking(0, n, m, 0, 0, mas, 1)
        stampaj(n, m, mas)                                 ' stampa u F5.TB6 i provjerava 
        provjeri(n, m, mas)
        '  obidji(n, m, mas)
        For i = 0 To n - 1
            For j = 0 To m - 1

                '  prava_matrica(i, j) = mas(i, j)
                '  prava_matrica(i, j) = Val(brojevi(br_br))

            Next
        Next
        '      Return prava_matrica
        Return mas
    End Function
    Public Sub BackTracking(ByVal broj As Integer, ByVal n As Integer, ByVal m As Integer, ByVal i As Integer, ByVal j As Integer, ByRef mas(,) As Integer, ByVal slucajan As Integer)
        If n * m < broj Then
            Return
        Else
            If mas(i, j) >= 0 Then
                Dim pokusaj As Integer = 0
                Dim upisano As Boolean = False

                While pokusaj <= 35 And upisano = False
                    slucajan = randomNum.Next(1, 10)

                    If Isti_U_Vrsti(slucajan, i, j, mas) And Isti_U_Koloni(slucajan, i, j, mas) Then
                        mas(i, j) = slucajan
                        prava_matrica(i, j) = slucajan
                        upisano = True
                    End If
                    pokusaj += 1
                End While
                If upisano = False Then
                    '  BackTracking(n * i - 1, n, m, i, Prvi(i, j, mas), mas, slucajan)
                    '        BackTracking(broj - j, n, m, i, 0, mas, slucajan)  na pocetak reda
                    '  BackTracking(broj - (j - Prvi_Najblizi(i, j, mas)), n, m, i, Prvi_Najblizi(i, j, mas), mas)
                    Dim p As Integer = 0
                    j = 0
                    i = 0
                    While p < broj / 2
                        If j > m - 1 Then
                            j = 0
                            i += 1
                        End If
                        j += 1
                        p += 1
                    End While
                    broj = broj / 2
                    If (i_staro = i) And (j_staro = j) Then
                        BackTracking(0, n, m, 0, 0, mas, slucajan)
                    Else
                        i_staro = i
                        j_staro = j
                        BackTracking(broj, n, m, i, j, mas, slucajan)
                    End If
                End If
            End If
            j += 1
            If j > m - 1 Then
                j = 0
                i += 1
            End If
           
            BackTracking(broj + 1, n, m, i, j, mas, slucajan)
        End If
        '    MsgBox(" broj= " & broj & ", n= " & n & ", m= " & m & ", i= " & i & ", j= " & j)
    End Sub
    Public Sub Iterativno(ByVal n As Integer, ByVal m As Integer, ByRef mas(,) As Integer)
        Dim broj As Integer = 0
        Dim i, j As Integer

        While broj < n * m
            If j > m - 1 Then
                j = 0
                i += 1
            End If
            If mas(i, j) >= 0 Then
                Dim pokusaj As Integer = 0
                Dim upisano As Boolean = False

                While pokusaj <= 25 And upisano = False
                    slucajan = randomNum.Next(1, 10)
                    pokusaj += 1
                    If Isti_U_Vrsti(slucajan, i, j, mas) And Isti_U_Koloni(slucajan, i, j, mas) Then
                        mas(i, j) = slucajan
                        prava_matrica(i, j) = slucajan
                        upisano = True
                        broj += 1
                        j += 1
                    End If
                End While

                If upisano = False Then
                    broj = broj - j
                    j = 0
                    '               Dim p As Integer = 0
                    '               j = 0
                    '               i = 0
                    '              While p < broj / 2
                    ' If j > m - 1 Then
                    '             j = 0
                    '             i += 1
                    '         End If
                    ' j += 1
                    '         P += 1
                    '         End While
                    '     broj = broj / 2
                    '       broj = 0
                    '       i = 0
                    '       j = 0
                End If
            Else
                j += 1
                broj += 1
            End If
        End While
    End Sub

    ' nalazi "najblize" puno polje, vraca index polja od kojeg pocinje niz praznih polja
    Public Function Prvi_Najblizi(ByVal i As Integer, ByVal j As Integer, ByRef mas(,) As Integer) As Integer
        Dim jj As Integer = j
        While mas(i, jj) > 0
            jj -= 1
            If jj <= 0 Then
                Return 0
            End If
        End While
        Return jj + 1
    End Function
    '' nalazi "prvo" puno polje, vraca index polja od kojeg pocinje niz praznih polja
    Public Function Prvi(ByVal i As Integer, ByVal j As Integer, ByRef mas(,) As Integer) As Integer
        Dim jj As Integer = 0
        While mas(i, jj) < 0
            jj += 1
        End While
        Return jj
    End Function
    Public Sub obidji(ByVal n As Integer, ByVal m As Integer, ByRef mas(,) As Integer)
        Dim s As String = " Prvi_Najblizi " & vbCrLf
        Dim s1 As String = " Prvi " & vbCrLf

        For i = 0 To n - 1
            For j = 0 To m - 1

                If mas(i, j) >= 0 Then
                    s = s & i & ", " & Prvi_Najblizi(i, j, mas) & vbCrLf
                    '      s1 = s1 & i & ", " & Prvi(i, j, mas) & vbCrLf
                End If
            Next
        Next
        MsgBox(s)
        '   MsgBox(s1)
    End Sub
    Public Sub stampaj(ByVal n As Integer, ByVal m As Integer, ByVal mas(,) As Integer)
        Dim s As String = ""
        For i = 0 To n - 1
            For j = 0 To m - 1
                '  mas(i, j) *= -1
                If mas(i, j) >= 0 Then
                    '    s = s & "    " & mas(i, j)
                    s = s & "  " & mas(i, j)
                Else
                    s = s & " " & mas(i, j)
                End If
            Next
            s = s & vbCrLf
        Next
        Form5.TextBox6.Text = s
    End Sub
    ' provjerava da li matrica zadovoljava pravilo da nema istih elemenata u vrstama i kolonama
    ' u koliko ima prikazuje poziciju drugog pojavljivanja 
    Public Sub provjeri(ByVal n As Integer, ByVal m As Integer, ByRef mas(,) As Integer)
        Dim i As Integer
        Dim j As Integer
        Dim s As String = ""
        For i = 0 To n - 1
            For j = 0 To m - 1
                If mas(i, j) = 0 Then
                    s = s & vbCrLf & " Nula (" & i & "," & j & " )    " & mas(i, j)
                End If
                If Isti_U_Koloni(mas(i, j), i, j, mas) = False Then
                    s = s & vbCrLf & " isti u koloni (" & i & "," & j & " )    " & mas(i, j)
                End If
                If (Isti_U_Vrsti(mas(i, j), i, j, mas) = False) Then
                    s = s & vbCrLf & " isti u vrsti (" & i & "," & j & " )     " & mas(i, j)
                End If
            Next
        Next
        If s.Length > 1 Then
            MsgBox(s)
        End If
    End Sub
    ' n, m - dimenzije matrice
    ' ii, jj - pozicija za koju se ispituje
    'ako ne postoje isti elementi vraca true
    Public Function Isti_U_Vrsti(ByVal broj As Integer, ByVal ii As Integer, ByVal jj As Integer, ByRef mas(,) As Integer) As Boolean
        If jj <= 0 Then     '  Or (jj > 0 And (mas(ii, jj - 1) < 0))
            Return True
        End If
        jj -= 1

        While jj >= 0 'And 
            If mas(ii, jj) <= 0 Then
                Return True
            End If
            If broj = mas(ii, jj) Then
                Return False
            End If
            jj -= 1
        End While

        Return True
    End Function
    Public Function Isti_U_Koloni(ByVal broj As Integer, ByVal ii As Integer, ByVal jj As Integer, ByRef mas(,) As Integer) As Boolean
        If ii = 0 Then  '  Or (ii > 0 And (mas(ii - 1, jj) < 0))
            Return True
        End If
        ii -= 1

        While ii >= 0 ' And mas(ii, jj) > 0
            If mas(ii, jj) <= 0 Then
                Return True
            End If
            If broj = mas(ii, jj) Then
                Return False
            End If
            ii -= 1
        End While

        Return True
    End Function
   
End Class