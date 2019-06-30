Imports System.IO
'Imports System.IO
Public Class Form1
    ' GLOBALNE PROMJENLJIVE 
    ' string_niz_za_stampu - u ovaj string se smjestaju odgovarajuci sabirci
    ' u formatu "1 + 2 + 3 + 4..." koji odgovaraju sumi za koju su trazeni,
    ' i string se prikazuje u Label3 u Form1
    Dim string_niz_za_stampu As String = ""
    Public start As Integer = 0
    Public pokrenuto As Integer = 0
    ' int_stanje Globalna promjenljiva koja sluzi za registrovanje 
    ' da li je je igra "pause" ili "play" 
    Public int_stanje As Integer = 1
    ' int_n, int_m Globalne promjenljive u kojima se cuvaju dimenzije 
    ' matrice Kakuro
    Public v As New velicine
    Public tezina As Integer = 1
    Public putanja As String
    Public pauza As Boolean = False
    Public backtrack As Boolean = True
    Public za_file As String = ""
    Public skin = 1
    Public skin_s As String = "br"
    Public int_n As Integer = 8
    Public int_m As Integer = 6
    Public fil As Integer = 1 '1 generisanje igre, 0 startovanje iz file-a
    Public f1_raspored As String = ""
    Public f1_resenje As String = ""
    Public f1_uneseni As String = ""
    Public muzika As Integer = 0

    Public f1_backgorund As Color = Color.PeachPuff
    '  Public f1_buton_color As Color = Color.Brown
    Public f1_sat_color As Color = Color.Yellow
    Public f1_sat_fore_color As Color = Color.Black
    Public f1_buton_back_image As Image = My.Resources.butonbr
    Public f1_buton_play_image As Image = My.Resources.play
    Public f1_buton_pause_image As Image = My.Resources.pause
    Public f1_buton_mistakes_image As Image = My.Resources.Mistakes
    Public f1_buton_one_hint_image As Image = My.Resources.Hint
    Public f1_buton_solve_image As Image = My.Resources.Solve
    Public f1_buton_music_play As Image = Image.FromFile(Application.StartupPath & "/pictures/1/VNbrpl.png")
    Public f1_buton_music_pause As Image = Image.FromFile(Application.StartupPath & "/pictures/1/VNbrpa.png")

    Public f1_buton_sound_play_image As Image
    Public f1_buton_sound_stop_image As Image
    Public f1_labele_fore_color As Color = Color.Black
    Public f1_back_color As Color = Color.PeachPuff

    Public f2_panel1_color As Color = Color.PeachPuff
    Public f2_panel1_backcolor As Color = Color.PeachPuff
    Public f2_slika As Image = My.Resources.br48
    Public f2_puno_polje As Image = My.Resources.brpuno
    Public f2_dijagonala As Image = My.Resources.brdijagonala
    Public f2_prazno_polje As Image = My.Resources.brprazno
    Public f2_prazno_polje_markirano As Image = My.Resources.brmarkirano
    Public f2_donja_gornja As Color = Color.Black
    Public f2_donja_gornja_font As Font = New Font("VERDANA", 9, FontStyle.Bold) ' And FontStyle.Italic))
    
    Public f2_boja_resenja As Color = Color.Black
    Public f2_font_resenja As Font = New System.Drawing.Font("Verdana", 18, FontStyle.Italic)

    Public f3_labele_color As Color = Color.PeachPuff
    Public f3_backgroung_color As Color = Color.PeachPuff
    Public f3_fore_color As Color = Color.Black
    Public f3_font As Font = New System.Drawing.Font("Verdana", 10, FontStyle.Italic And FontStyle.Bold)
    Public f3_font_markirani As Font = New System.Drawing.Font("Verdana", 12, FontStyle.Bold)
 
    Public f4_resenje_default_color As Color = Color.AliceBlue
    Public f4_resenje_activ_color As Color = Color.Aqua

    Public f4_kand_default_color As Color = Color.Red
    Public f4_kand_activ_color As Color = Color.Yellow

    Public f4_resenje_fore_color As Color = Color.Black
    Public f4_kand_fore_color As Color = Color.Green

    Public meny_color As Color = Color.Azure

    ' END OF GLOBALNE PROMJENLJIVE
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        skin = 1
        backtrack = True
        backtrack = False        ' ??
        putanja = Application.StartupPath & "\Muzika.wav"
        Label1.BringToFront()
        Label2.BringToFront()
        Button1.BackgroundImageLayout = ImageLayout.Stretch
        Me.Location = New System.Drawing.Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width() * 0.35, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height() * 0.3)
        Dim Form2 As New Form2
        Dim Form3 As New Form3
        Oboji()
        If skin = 1 Then
            Button6.Image = Image.FromFile(Application.StartupPath & "/pictures/" & Form2.skin.ToString & "/VNbrpl.png")
        Else
            Button6.Image = Image.FromFile(Application.StartupPath & "/pictures/" & Form2.skin.ToString & "/VNblpl.png")
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        '  OptionToolStripMenuItem.Visible = False
        Pokreni()
        '   MsgBox(int_n & " " & int_m)
    End Sub
    Public Sub Resetuj(ByVal nn As Integer, ByVal mm As Integer)
        Form2.Close()
        start = 0
        pokrenuto = 1
        int_stanje = 1
        Timer1.Enabled = False
        Label1.Text = "00"
        Label2.Text = "00"
        Pokreni()
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim int_i As Integer = Label2.Text
        Dim int_j As Integer = Label1.Text
        int_i += 1
        If (int_i = 60) Then
            Label2.Text = "00"
            int_j += 1
            If (int_j < 10) Then
                Label1.Text = "0" & int_j
            Else
                Label1.Text = int_j
            End If
        Else
            If (int_i < 10) Then
                Label2.Text = "0" & int_i
            Else
                Label2.Text = int_i
            End If
        End If
    End Sub
    Private Sub Form1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter
        Me.Focus()
    End Sub
    Private Sub Form1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave
        '  Form2.Focus()
    End Sub
    Private Sub Form1_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseWheel

    End Sub
    Public Sub Form1_MinimumSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.RegionChanged
        '      Dim Form3 As New Form3
        MsgBox("smanji me ")
    End Sub
    Private Sub EasyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        tezina = 1
    End Sub
    Private Sub MedimToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        tezina = 2
    End Sub
    Private Sub HardToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        tezina = 3
    End Sub
  
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Form2.Markiraj_Pogresne()
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Form2.Rijesi()
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If Form2.i_dugme <> 0 And Form2.j_dugme <> 0 Then
            Form2.d.tabela(Form2.i_dugme, Form2.j_dugme).lb.text = Form2.got(Form2.i_dugme, Form2.j_dugme)
            Form2.Focus()
        End If
        ' MsgBox(Form2.i_dugme & " " & Form2.j_dugme)
        Form2.Focus()
    End Sub
    Declare Auto Function sndPlaySound Lib "WINMM.DLL" (ByVal Soundfile As String, ByVal Options As Int32) As Int32
    ' For Info
    ' API Call Flags for sndPlaySound
    Const SND_SYNC As Long = &H0 'synchronize playback
    Const SND_ASYNC As Long = &H1 ' played async
    Const SND_NODEFAULT As Long = &H2 ' No default
    Const SND_LOOP As Long = &H8 ' 'loop the wave
    Const SND_NOSTOP As Long = &H10 'don't stop current sound if one playing
    Const SND_NOWAIT As Long = &H2000 'Do not wait if the sound driver is busy.
    Const SND_ALIAS As Long = &H10000 ' Play a Windows sound (such as SystemStart, Asterisk, etc.).
    ' Various ways of playing sound
    ' 1. Play it one or more times - number of repetitions set in the code:
    Public Sub PlayAWave(ByVal Soundfile As String, Optional ByVal MaxLoops As Integer = 1)
        Dim i As Integer
        For i = 1 To MaxLoops
            ' Play Async - ie. Don't lock up the application
            sndPlaySound(Soundfile, SND_ASYNC)
        Next
    End Sub
    ' 2. Play the sound in a continual loop:
    Public Sub LoopWave(ByVal Soundfile As String)
        ' Play Async AND loop it.
        sndPlaySound(Soundfile, SND_ASYNC Or SND_LOOP)
    End Sub
    ' If you use the above, you might find this procedure handy at times :-}
    ' 3. Stop the loop.
    Public Sub StopLoopWave()
        sndPlaySound(" ", SND_ASYNC And SND_NODEFAULT)
    End Sub
    Private Sub LoadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadToolStripMenuItem.Click
        OpenFileDialog1.ShowDialog()
    End Sub
    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        Form6.Show()
        '  Me.Close()
    End Sub
    Public Function Napravi_Integer_Masku(ByVal n As Integer, ByVal m As Integer, ByVal s() As Char, ByVal res() As Char) As Array
        Dim i, j, br, br2 As Integer
        Dim int_matrica(,) As Integer
        ReDim int_matrica(n, m)
        br = 0
        br2 = 0
        For i = 0 To n - 1
            For j = 0 To m - 1
                int_matrica(i, j) = Val(s(br)) * -1
                br += 1
                '    If int_matrica(i, j) = 0 Then
                '     int_matrica(i, j) = Val(res(br2))
                '     End If
                '    br2 += 1
            Next
        Next
        Return int_matrica
    End Function
    Public Sub pokupi_brojeve_za_file()
        Dim i, j As Integer
        Dim upisano As String = ""
        Dim raspored As String = Form2.raspored
        Dim sec As String = Label2.Text
        Dim min As String = Label1.Text
        Dim resenje As String = Form2.resenje
        Dim i_za_string As Integer = 0
        Dim inti_m As String = ""

        For i = 0 To int_n - 1
            For j = 0 To int_m - 1
                '    raspored(i_za_string) = "1"
                If Val(Form2.raspored(i_za_string)) = 0 Then    ' za 0 je T
                    If Form2.d.tabela(i, j).lb.text <> "" Then
                        upisano = upisano & Form2.d.tabela(i, j).lb.text
                    Else
                        upisano = upisano & "0"
                    End If
                Else
                    upisano = upisano & "0"
                End If
                '     If Form2.int_maska(i, j) >= 0 Then
                '        inti_m = inti_m & Form2.int_maska(i, j)
                '        End If

                i_za_string += 1
            Next
        Next
        za_file = int_n.ToString & ";" & int_m.ToString & ";" & min & ";" & sec & ";" & raspored & ";" & resenje & ";" & upisano
        ' za_file = int_n.ToString & vbCrLf & int_m.ToString & vbCrLf & min & vbCrLf & sec & vbCrLf & raspored & vbCrLf & resenje & vbCrLf & upisano
        '  MsgBox(za_file)
        'Form5.TextBox9.Text = za_file
    End Sub
    Private Sub SaveCurrentPuzzleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveCurrentPuzzleToolStripMenuItem.Click
        Timer1.Enabled = False
        SaveFileDialog1.ShowDialog()
    End Sub
    Public Sub Pokreni()
        If Not Form6 Is Nothing Then
            '    int_n = Form6.n
            '   int_m = Form6.m
            '  MsgBox(int_n & " f1 " & int_m)
            Form6.Close()
        End If
        If start = 0 Then
            Form2.Enabled = True
            Form2.Show()
            Form2.upisi()
        End If
        pokrenuto += 1
        '   Form3.Show()  ovo odkomentarisi

        int_stanje += 1                    ' kad je igra puzirana
        If ((int_stanje Mod 2) > 0) Then
            Form3.smanji()
            Form4.boja_but = Color.DarkGreen
            Button1.Image = My.Resources.play
            Timer1.Enabled = False          ' sakrij matricu
            Form2.sakrij1(1)
            '    StopLoopWave()
            pauza = True
            '   Form3.smanji()
        Else                                ' kad je igra pokrenuta
            '   LoopWave(putanja)
            Button2.Visible = True
            Button1.Image = My.Resources.Pause
            Form2.WindowState = System.Windows.Forms.FormWindowState.Normal
            Form2.otkrij1(1)
            Timer1.Enabled = True
            pauza = False
            Form3.povecaj()
        End If
    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        pokupi_brojeve_za_file()
    End Sub
    Private Sub SaveFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk
        pokupi_brojeve_za_file()
        Dim FileName As String = SaveFileDialog1.FileName '"prvi.kak"
        'declaring filename that will be selected

        Dim sw As StreamWriter
        'streamreader is used to read text
        ' File.Create()
        sw = New StreamWriter(FileName)
        'using streamwriter to write text from richtextbox and saving it
        sw.Write(za_file)
        sw.Close()

    End Sub
    Public Sub Ucitaj_brojeve_iz_filea(ByVal s As String)
        Dim i As Integer = 0
        Dim p As Integer = 0
        Dim t As String = ""
        Dim upisano As String = ""
        Dim raspored As String = ""
        Dim sec As String = ""
        Dim min As String = ""
        Dim resenje As String = ""
        Dim n As String = ""
        Dim m As String = ""

        While i < s.Length
            '    i += 1
            If s(i) = ";" Then
                i += 1
                p += 1
            Else
                Select Case p
                    Case 0
                        n = n & s(i)
                    Case 1
                        m = m & s(i)
                    Case 2
                        min = min & s(i)
                    Case 3
                        sec = sec & s(i)
                    Case 4
                        raspored = raspored & s(i)
                    Case 5
                        resenje = resenje & s(i)
                    Case 6
                        upisano = upisano & s(i)
                End Select
                i += 1
            End If
        End While
        '   MsgBox("n " & n & vbCrLf & "m " & m & vbCrLf & "min " & min & vbCrLf & "sec " & sec & vbCrLf & "raspored " & raspored & vbCrLf & "resenje " & resenje & vbCrLf & "upisano " & upisano)
        '    MsgBox("n " & n & vbCrLf & "m " & m & vbCrLf & "min " & min & vbCrLf & "sec " & sec & vbCrLf & "raspore " & raspored & vbCrLf & "resenje " & resenje & vbCrLf & "upisano " & upisano)
        ' poziv za startovanje igre sa podacima iz fajla
        '     If Not Form2 Is Nothing Then
        Form2.Close()

        Me.fil = 0
        int_n = CInt(n)
        int_m = CInt(m)
        Me.Label1.Text = min
        Me.Label2.Text = sec

        f1_raspored = raspored
        f1_resenje = resenje
        f1_uneseni = upisano

        '  Form2.Show()
        pokrenuto = 1
        int_stanje = 1
        start = 0
        ' Pokreni()
        '  Form2.Startuj_Igru_Iz_Fajla(CInt(n), CInt(m), sec, min, raspored, resenje, upisano)
        '      End If
    End Sub
    Private Sub OpenFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Dim FileName As String = OpenFileDialog1.FileName
        Dim sr As StreamReader
        sr = New StreamReader(FileName)
        Dim s As String = sr.ReadToEnd()
        ' MsgBox(s)
        Ucitaj_brojeve_iz_filea(s)
        ' Close()
    End Sub
    Public Sub Oboji()
        Me.BackColor = f1_backgorund
        '  MenuStrip1.BackColor = Color.Coral
        Button1.BackgroundImage = f1_buton_back_image     ' play
        Button2.BackgroundImage = f1_buton_back_image
        Button3.BackgroundImage = f1_buton_back_image
        Button4.BackgroundImage = f1_buton_back_image
        Button5.BackgroundImage = f1_buton_back_image
        Button6.BackgroundImage = f1_buton_back_image
        Button1.Image = f1_buton_play_image
        Button2.Image = f1_buton_mistakes_image
        Button5.Image = f1_buton_one_hint_image
        Button4.Image = f1_buton_solve_image
        Button4.Image = f1_buton_solve_image
        If muzika = 0 Then
            Button6.Image = f1_buton_music_play
        Else
            If muzika Mod 2 = 1 Then
                Button6.Image = f1_buton_music_play
            Else
                Button6.Image = f1_buton_music_pause
            End If
        End If
    End Sub
    Public Sub Podesi_Boje()
   
        Select Case skin
            Case 1
                f1_backgorund = Color.PeachPuff
                f1_sat_color = Color.Yellow
                f1_sat_fore_color = Color.Black
                f1_buton_play_image = My.Resources.play
                f1_buton_back_image = My.Resources.butonbr
                f1_buton_pause_image = My.Resources.pause
                f1_buton_mistakes_image = My.Resources.Mistakes
                f1_buton_one_hint_image = My.Resources.Hint
                f1_buton_back_image = My.Resources.butonbr
                f1_buton_solve_image = My.Resources.Solve
                f1_buton_music_play = Image.FromFile(Application.StartupPath & "/pictures/1/VNbrpl.png")
                f1_buton_music_pause = Image.FromFile(Application.StartupPath & "/pictures/1/VNbrpa.png")

                f2_panel1_color = Color.PeachPuff
                f2_panel1_backcolor = Color.PeachPuff
                f2_donja_gornja = Color.Black
                f2_puno_polje = My.Resources.brpuno
                f2_dijagonala = My.Resources.brdijagonala
                f2_prazno_polje = My.Resources.brprazno
                f2_prazno_polje_markirano = My.Resources.brmarkirano
   
                f3_labele_color = Color.PeachPuff
                f3_backgroung_color = Color.PeachPuff
                f3_fore_color = Color.Black

                f4_resenje_default_color = Color.LightBlue
                f4_resenje_activ_color = Color.Aqua

                f4_kand_default_color = Color.Blue
                f4_kand_activ_color = Color.Blue

                f4_resenje_fore_color = Color.DeepSkyBlue
                f4_kand_fore_color = Color.DarkGreen

                meny_color = Color.Blue
                Select Case int_n * int_m
                    Case 48
                        f2_slika = My.Resources.br48
                    Case 80
                        f2_slika = My.Resources.br80
                    Case 120
                        f2_slika = My.Resources.br120
                    Case 144
                        f2_slika = My.Resources.br144
                    Case 192
                End Select
            Case 2
                f1_backgorund = Color.Black
                f1_sat_color = Color.Brown
                f1_sat_fore_color = Color.White
                f1_buton_back_image = Image.FromFile(Application.StartupPath & "/pictures/2/bl.png")
                f1_buton_pause_image = Image.FromFile(Application.StartupPath & "/pictures/2/pause.png")
                f1_buton_mistakes_image = Image.FromFile(Application.StartupPath & "/pictures/2/Mistakes.png")
                f1_buton_one_hint_image = Image.FromFile(Application.StartupPath & "/pictures/2/Hint.png")
                f1_buton_solve_image = Image.FromFile(Application.StartupPath & "/pictures/2/Solve.png")
                f1_buton_music_play = Image.FromFile(Application.StartupPath & "/pictures/2/VNblpl.png")
                f1_buton_music_pause = Image.FromFile(Application.StartupPath & "/pictures/2/VNblpa.png")


                f2_panel1_color = Color.Black
                f2_panel1_backcolor = Color.Black
                f2_donja_gornja = Color.White
                f2_puno_polje = My.Resources.blpuno
                f2_dijagonala = My.Resources.bldijagonala
                f2_prazno_polje = My.Resources.blprazno
                f2_prazno_polje_markirano = My.Resources.blmarkirano

                f3_labele_color = Color.Black
                f3_backgroung_color = Color.Black
                f3_fore_color = Color.White

                f4_resenje_default_color = Color.LightBlue
                f4_resenje_activ_color = Color.Aqua
                f4_kand_default_color = Color.Blue
                f4_kand_activ_color = Color.Blue
                f4_resenje_fore_color = Color.DeepSkyBlue
   
                meny_color = Color.Blue
                Select Case int_n * int_m
                    Case 48
                        f2_slika = My.Resources.bl48
                    Case 80
                        f2_slika = My.Resources.bl80
                    Case 120
                        f2_slika = My.Resources.bl120
                    Case 144
                        f2_slika = My.Resources.bl144
                    Case 192
                End Select
            Case 3
                Select Case int_n * int_m
                    Case 48
                    Case 80
                    Case 120
                    Case 144
                    Case 192
                End Select
        End Select
    End Sub
    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Select Case Me.WindowState
            Case FormWindowState.Maximized
                If Not Form2 Is Nothing Then
                    Form2.WindowState = FormWindowState.Normal
                End If
                If Not Form2 Is Nothing Then
                    Form3.WindowState = FormWindowState.Normal
                End If
            Case FormWindowState.Minimized
                If Not Form2 Is Nothing Then
                    Form2.WindowState = FormWindowState.Minimized
                End If
                If Not Form2 Is Nothing Then
                    Form3.WindowState = FormWindowState.Minimized
                End If
            Case FormWindowState.Normal
                If Not Form2 Is Nothing Then
                    Form2.WindowState = FormWindowState.Normal
                End If
                If Not Form2 Is Nothing Then
                    Form3.WindowState = FormWindowState.Normal
                End If
        End Select
    End Sub
    Private Sub Brown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Brown.Click
        skin = 1
        skin_s = "br"
        '   Me.BackColor = Color.PeachPuff
        Podesi_Boje()
        '   skin = 1
        If pokrenuto >= 1 And Form2.skin <> 1 And (pokrenuto Mod 2 = 1) Then
            Form2.skin = skin
            Form2.Smanji_Povecaj_Form2_i_Form3()
        Else
            '   Oboji()
        End If
        If pokrenuto = 0 Then
            Podesi_Boje()
            Oboji()
        End If
    End Sub
    Private Sub Black_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Black.Click
        'Black
        skin = 2
        skin_s = "bl"
        Podesi_Boje()
        '   Me.BackColor = Color.Black
        skin = 2
        If pokrenuto >= 1 And Form2.skin <> 2 And (pokrenuto Mod 2 = 1) Then
            Form2.skin = skin
            Form2.Smanji_Povecaj_Form2_i_Form3()
        Else
        End If
        If pokrenuto = 0 Then
            Podesi_Boje()
            Oboji()
        End If
    End Sub
    Private Sub Blue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Blue.Click
        skin = 3
        Form2.skin = 3
        Podesi_Boje()
        '    If pokrenuto >= 1 And Form2.skin <> 3 Then
        ' Form2.Promijeni_Skin(3)
        '   End If
        Form2.Smanji_Povecaj_Form2_i_Form3()
    End Sub
    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Form6.Show()
    End Sub
    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        OpenFileDialog1.ShowDialog()
    End Sub
    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        SaveFileDialog1.ShowDialog()
    End Sub
    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Form7.Show()
    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        muzika += 1
        If muzika Mod 2 = 1 Then
            StopLoopWave()
            Button6.Image = f1_buton_music_play
            If skin = 1 Then
                '         Button6.Image = Image.FromFile(Application.StartupPath & "/pictures/" & Form2.skin.ToString & "/VNbrpl.png")
            Else
                '         Button6.Image = Image.FromFile(Application.StartupPath & "/pictures/" & Form2.skin.ToString & "/VNblpl.png")
            End If
        Else
            LoopWave(putanja)
            Button6.Image = f1_buton_music_pause
            If skin = 1 Then
                '        Button6.Image = Image.FromFile(Application.StartupPath & "/pictures/" & Form2.skin.ToString & "/VNbrpa.png")
            Else
                '       Button6.Image = Image.FromFile(Application.StartupPath & "/pictures/" & Form2.skin.ToString & "/VNblpa.png")
            End If
        End If
    End Sub
End Class
