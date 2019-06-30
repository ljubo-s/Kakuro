Public Class Form4
    Public wi, hi As Integer
    Public ii As Integer = 550
    Public point_form4 As Point
    Public i_klik, j_klik As Integer

    Public candidat As Integer = 0
    Public stanje As Integer = 0

    Public boja_but As Color = Color.LightBlue
    Public got_fokus_boja_but As Color = Color.Aqua

    Public boja_candidates As Color
    Public got_fokus_boja_candidates As Color

    Private Sub Form4_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Form2.v.f2_aktivna = True
        ' Form2.d.tabela(i_klik, j_klik).BackgroundImage = Image.FromFile(Application.StartupPath & "/pictures/ptp.png")
        Form2.d.tabela(i_klik, j_klik).Markiraj(i_klik, j_klik)
        Form1.v.brojcanik = False
        Form2.Focus()
    End Sub
    ' indeks polja nad kojim se desio klik misem 
    '  Public Form2 As New Form2
    Public Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Location = New System.Drawing.Point(point_form4)
        Me.Width = 1
        Me.Height = 1
        Timer1.Enabled = True
        Form3.v.brojcanik = True
        Form2.v.f2_aktivna = False
        Button1.Focus()
        If Button1.Focus = True Then
            Button1.BackColor = got_fokus_boja_but
        End If
        Izgled()
    End Sub
    Public Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ii -= 2
        '   FormBorderStyle = Windows.Forms.FormBorderStyle.Fixed3D
        '  Me.SetBounds(24, 24, ii, ii)
        If (Me.Height >= 160) And (Me.Width >= 210) Then
            Timer1.Enabled = False
            '    MessageBox.Show(Me, "zavrsio sa radom")
        End If

        If (Me.Height < 160) Then
            Me.Height += 16
            '  hi += 1
        End If

        If (Me.Width < 210) Then
            Me.Width += 15
            '  wi += 1
        End If
        Me.Refresh()
        '     Me.Opacity = Me.Opacity + 0.05
        '   Me.Location = New System.Drawing.Point(ii, ii)
    End Sub
    Private Sub Butto1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.MouseEnter
        Button1.Focus()
    End Sub
    Private Sub Butto2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.MouseEnter
        Button2.Focus()
    End Sub
    Private Sub Butto3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.MouseEnter
        Button3.Focus()
    End Sub
    Private Sub Butto4_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.MouseEnter
        Button4.Focus()
    End Sub
    Private Sub Butto5_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.MouseEnter
        Button5.Focus()
    End Sub
    Private Sub Butto6_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.MouseEnter
        Button6.Focus()
    End Sub
    Private Sub Butto7_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.MouseEnter
        Button7.Focus()
    End Sub
    Private Sub Butto8_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.MouseEnter
        Button8.Focus()
    End Sub
    Private Sub Butto9_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.MouseEnter
        Button9.Focus()
    End Sub
    Private Sub Butto10_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.MouseEnter
        Button10.Focus()
    End Sub
    Private Sub Butto11_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.MouseEnter
        Button11.Focus()
    End Sub
    Private Sub Button1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.GotFocus
        Button1.BackColor = got_fokus_boja_but
    End Sub
    Private Sub Button2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.GotFocus
        Button2.BackColor = got_fokus_boja_but
    End Sub
    Private Sub Button3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.GotFocus
        Button3.BackColor = got_fokus_boja_but
    End Sub
    Private Sub Button4_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.GotFocus
        Button4.BackColor = got_fokus_boja_but
    End Sub
    Private Sub Button5_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.GotFocus
        Button5.BackColor = got_fokus_boja_but
    End Sub
    Private Sub Button6_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button6.GotFocus
        Button6.BackColor = got_fokus_boja_but
    End Sub
    Private Sub Button7_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button7.GotFocus
        Button7.BackColor = got_fokus_boja_but
    End Sub
    Private Sub Button8_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button8.GotFocus
        Button8.BackColor = got_fokus_boja_but
    End Sub
    Private Sub Button9_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button9.GotFocus
        Button9.BackColor = got_fokus_boja_but
    End Sub
    Private Sub Button10_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button10.GotFocus
        Button10.BackColor = got_fokus_boja_but
    End Sub
    Private Sub Button11_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button11.GotFocus
        Button11.BackColor = got_fokus_boja_but
    End Sub
    Private Sub Button1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.LostFocus
        Button1.BackColor = boja_but
    End Sub
    Private Sub Button2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.LostFocus
        Button2.BackColor = boja_but
    End Sub
    Private Sub Button3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.LostFocus
        Button3.BackColor = boja_but
    End Sub
    Private Sub Button4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.LostFocus
        Button4.BackColor = boja_but
    End Sub
    Private Sub Button5_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.LostFocus
        Button5.BackColor = boja_but
    End Sub
    Private Sub Button6_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button6.LostFocus
        Button6.BackColor = boja_but
    End Sub
    Private Sub Button7_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button7.LostFocus
        Button7.BackColor = boja_but
    End Sub
    Private Sub Button8_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button8.LostFocus
        Button8.BackColor = boja_but
    End Sub
    Private Sub Button9_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button9.LostFocus
        Button9.BackColor = boja_but
    End Sub
    Private Sub Button10_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button10.LostFocus
        Button10.BackColor = boja_but
    End Sub
    Private Sub Button11_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button11.LostFocus
        Button11.BackColor = boja_but
    End Sub
    Public Sub refresuj()
        Button1.Focus()
        Button2.Focus()
        Button3.Focus()
        Button4.Focus()
        Button5.Focus()
        Button6.Focus()
        Button7.Focus()
        Button8.Focus()
        Button9.Focus()
        Button10.Focus()
        Button11.Focus()

    End Sub

    Private Sub Button1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Button1.KeyDown
        If e.KeyCode = Keys.D Then
            Button2.Focus()
        End If
        If e.KeyCode = Keys.S Then
            Button4.Focus()
        End If
        If e.KeyCode = Keys.E Then
            upisi(1)
        End If
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub Button2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Button2.KeyDown
        If e.KeyCode = Keys.A Then
            Button1.Focus()
        End If
        If e.KeyCode = Keys.D Then
            Button3.Focus()
        End If
        If e.KeyCode = Keys.S Then
            Button5.Focus()
        End If
        If e.KeyCode = Keys.E Then
            upisi(2)
        End If
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If

    End Sub
    Private Sub Button3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Button3.KeyDown
        If e.KeyCode = Keys.A Then
            Button2.Focus()
        End If
        If e.KeyCode = Keys.S Then
            Button6.Focus()
        End If
        If e.KeyCode = Keys.E Then
            upisi(3)
        End If
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub Button4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Button4.KeyDown
        If e.KeyCode = Keys.W Then
            Button1.Focus()
        End If
        If e.KeyCode = Keys.D Then
            Button5.Focus()
        End If
        If e.KeyCode = Keys.S Then
            Button7.Focus()
        End If
        If e.KeyCode = Keys.E Then
            upisi(4)
        End If
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub Button5_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Button5.KeyDown
        If e.KeyCode = Keys.A Then
            Button4.Focus()
        End If
        If e.KeyCode = Keys.W Then
            Button2.Focus()
        End If
        If e.KeyCode = Keys.D Then
            Button6.Focus()
        End If
        If e.KeyCode = Keys.S Then
            Button8.Focus()
        End If
        If e.KeyCode = Keys.E Then
            upisi(5)
        End If
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub Button6_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Button6.KeyDown
        If e.KeyCode = Keys.W Then
            Button3.Focus()
        End If
        If e.KeyCode = Keys.A Then
            Button5.Focus()
        End If
        If e.KeyCode = Keys.S Then
            Button9.Focus()
        End If
        If e.KeyCode = Keys.E Then
            upisi(6)
        End If
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub Button7_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Button7.KeyDown
        If e.KeyCode = Keys.W Then
            Button4.Focus()
        End If
        If e.KeyCode = Keys.D Then
            Button8.Focus()
        End If
        If e.KeyCode = Keys.S Then
            Button10.Focus()
        End If
        If e.KeyCode = Keys.E Then
            upisi(7)
        End If
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub Button8_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Button8.KeyDown
        If e.KeyCode = Keys.W Then
            Button5.Focus()
        End If
        If e.KeyCode = Keys.D Then
            Button9.Focus()
        End If
        If e.KeyCode = Keys.A Then
            Button7.Focus()
        End If
        If e.KeyCode = Keys.E Then
            upisi(8)
        End If
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub Button9_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Button9.KeyDown
        If e.KeyCode = Keys.W Then
            Button6.Focus()
        End If
        If e.KeyCode = Keys.S Then
            Button11.Focus()
        End If
        If e.KeyCode = Keys.A Then
            Button8.Focus()
        End If
        If e.KeyCode = Keys.E Then
            upisi(9)
        End If
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub Button10_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Button10.KeyDown
        If e.KeyCode = Keys.W Then
            Button7.Focus()
        End If
        If e.KeyCode = Keys.S Then
            Button1.Focus()
        End If
        If e.KeyCode = Keys.D Then
            Button11.Focus()
        End If
        If e.KeyCode = Keys.E Then
            Form2.d.tabela(i_klik, j_klik).lb.Text = ""
            Form2.d.tabela(i_klik, j_klik).Provjera_FULL()
            Me.Close()
        End If
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub Button11_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Button11.KeyDown
        If e.KeyCode = Keys.W Then
            Button9.Focus()
        End If
        If e.KeyCode = Keys.S Then
            Button3.Focus()
        End If
        If e.KeyCode = Keys.A Then
            Button10.Focus()
        End If
        If e.KeyCode = Keys.E Then
        End If
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    '    Private Sub Button1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.MouseLeave
    '       Button1.BackColor = Color.NavajoWhite
    '   End Sub
    '  Private Sub Button2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.MouseLeave
    '      Button2.BackColor = Color.NavajoWhite
    '  End Sub
    '  Private Sub Button3_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.MouseLeave
    '      Button3.BackColor = Color.NavajoWhite
    '  End Sub
    '   Private Sub Button4_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.MouseLeave
    '      Button4.BackColor = Color.NavajoWhite
    '   End Sub
    '   Private Sub Button5_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.MouseLeave
    '      Button5.BackColor = Color.NavajoWhite
    '  End Sub
    '  Private Sub Button6_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.MouseLeave
    '     Button6.BackColor = Color.NavajoWhite
    '  End Sub
    '  Private Sub Button7_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.MouseLeave
    '     Button7.BackColor = Color.NavajoWhite
    '  End Sub
    '   Private Sub Button8_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.MouseLeave
    '       Button8.BackColor = Color.NavajoWhite
    '   End Sub
    '  Private Sub Button9_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.MouseLeave
    '     Button9.BackColor = Color.NavajoWhite
    '  End Sub
    Private Sub Button1_MouseClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button1.MouseClick
        upisi(1)
    End Sub
    Private Sub Button2_MouseClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button2.MouseClick
        upisi(2)
    End Sub
    Private Sub Button3_MouseClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button3.MouseClick
        upisi(3)
    End Sub
    Private Sub Button4_MouseClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button4.MouseClick
        upisi(4)
    End Sub
    Private Sub Button5_MouseClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button5.MouseClick
        upisi(5)
    End Sub
    Private Sub Button6_MouseClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button6.MouseClick
        upisi(6)
    End Sub
    Private Sub Button7_MouseClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button7.MouseClick
        upisi(7)
    End Sub
    Private Sub Button8_MouseClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button8.MouseClick
        upisi(8)
    End Sub
    Private Sub Button9_MouseClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button9.MouseClick
        upisi(9)
    End Sub
    Public Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click

        Select Case candidat

            Case 0 ' kada je mod za upisivanje resenja
                Form2.d.tabela(i_klik, j_klik).lb.Text = ""
                Form2.d.tabela(i_klik, j_klik).Provjera_FULL()
                Form1.v.brojcanik = False
                Form2.d.tabela(i_klik, j_klik).lb.ForeColor = Color.Black
            Case 1 ' kada je mod za upisivanje kandidata POSIBLE
                '     Form2.d.tabela(i_klik, j_klik).vrati_labele_na_default()
                Form2.d.tabela(i_klik, j_klik).Provjera_FULL()
                Form1.v.brojcanik = False
        End Select
        '  Me.Close()
        '  Form2.Enabled = True

    End Sub
    Public Sub upisi(ByVal cifra As Integer)
        Select Case candidat
            Case 0
                Form2.d.tabela(i_klik, j_klik).lb.Text = cifra.ToString
                Form1.v.brojcanik = False
                Form2.d.tabela(i_klik, j_klik).lb.ForeColor = Color.Black
                Form2.d.tabela(i_klik, j_klik).Provjera_FULL()
            Case 1
                Form2.d.tabela(i_klik, j_klik).dopuni(cifra)
                Form1.v.brojcanik = False
        End Select
        '   Me.Close()
        '   Form2.Enabled = True
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        stanje += 1
        If stanje Mod 2 = 0 Then              ' stanje resenja
            candidat = 0
        Else                                  ' stanje kandidata  
            candidat = 1
        End If
        Izgled()
    End Sub
    Public Sub Izgled()
        '  MsgBox("CANDIDAT : " & candidat)
        Select Case candidat

            Case 0 ' kada je mod za upisivanje resenja
                Button11.Text = "Posible"
                Select Case Form2.skin
                    Case 1

                    Case 2

                    Case 3

                End Select

                boja_but = Color.LightBlue
                got_fokus_boja_but = Color.Aqua
            Case 1 ' kada je mod za upisivanje kandidata POSIBLE
                Button11.Text = "Answer"
                Select Case Form2.skin
                    Case 1   ' brown
                        boja_but = Color.Red
                        got_fokus_boja_but = Color.DeepSkyBlue
                    Case 2   ' black 
                        boja_but = Color.DarkGreen
                        got_fokus_boja_but = Color.Yellow
                    Case 3
                End Select
        End Select
        refresuj()
        '   Me.Refresh()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

    End Sub
End Class