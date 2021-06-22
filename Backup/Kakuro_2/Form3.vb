Public Class Form3
    Public v As velicine = New velicine
    Public labela(12) As Label
    Public labela_preostalih As Label
    Dim povecavaj As Boolean = False
    Dim smanjuj As Boolean = True
    Public zavrsena_zamjana As Boolean = False

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Location = New System.Drawing.Point(Form2.desna_granica, Form2.gornja_granica)
        Me.Width = 300
        Me.Height = 3
        '  System.Threading.Thread.Sleep(1000)
        Timer1.Enabled = True
        Dim broj_labela As Integer = 5
        Dim x As Integer = 7
        Dim y As Integer = 8
        Label1.ForeColor = Form1.f3_fore_color
        For i = 0 To 12
            labela(i) = New Label()
            labela(i).Location = New Point(x, y)
            labela(i).Width = 253
            Me.Controls.Add(labela(i))

            If Form1.pokrenuto >= 1 Then
                Label1.BackColor = Form1.f3_backgroung_color
                labela(i).BackColor = Form1.f3_labele_color
                labela(i).Font = New System.Drawing.Font("Verdana", 18, FontStyle.Bold)
                labela(i).ForeColor = Form1.f3_fore_color
                labela(i).TextAlign = ContentAlignment.BottomCenter
            End If
            labela(i).BringToFront()
            y += 24
        Next
        labela_preostalih = New Label()
        labela_preostalih.Location = New Point(0, 340)
        Me.Controls.Add(labela_preostalih)
        labela_preostalih.BringToFront()
        labela_preostalih.Visible = True
        labela_preostalih.BackColor = Form1.f3_labele_color
        labela_preostalih.Font = New System.Drawing.Font("Verdana", 18, FontStyle.Italic And FontStyle.Bold)
        labela_preostalih.TextAlign = ContentAlignment.MiddleCenter
        labela_preostalih.Width = 285
        labela_preostalih.Height = 50
    End Sub

    Public Sub smanji()
        Timer2.Enabled = True
        Timer1.Enabled = False
        '  Promijni_boju_labelama()
    End Sub
    Public Sub povecaj()
        Timer2.Enabled = False
        Timer1.Enabled = True
        '   Promijni_boju_labelama()
    End Sub
    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If (Me.Height <= 0) Then 'And (Me.Width >= 300)
            Timer2.Enabled = False
        End If
        If (Me.Height > 0) Then
            Me.Height -= 10
        End If
        Me.Refresh()
    End Sub
    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        If smanjuj = True Then
            If (Me.Height <= 0) Then
                smanjuj = False
                povecavaj = True
            End If
            If (Me.Height > 0) And smanjuj = True Then
                Me.Height -= 10
            End If
            Me.Refresh()
        End If
        If povecavaj = True And Form1.pauza = False Then
            If (Me.Height >= 400) Then
                Timer3.Enabled = False
                povecavaj = False
                smanjuj = True
            End If
            If (Me.Height < 400) And povecavaj Then
                Me.Height += 10
            End If
            Me.Refresh()
        End If
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If (Me.Height >= 400) Then 'And (Me.Width >= 300)
            Timer1.Enabled = False
        End If
        If (Me.Height < 400) Then
            Me.Height += 10
            '  hi += 1
        End If
        Me.Refresh()
    End Sub
    Public Sub Promijni_boju_labelama()
        For i = 0 To 12   ' 
            If Me.labela(i) Is Nothing Then
            Else
                Me.labela(i).ForeColor = Form1.f3_fore_color
                Me.labela(i).BackColor = Form1.f3_labele_color
            End If
        Next
        If Not Me.labela_preostalih Is Nothing Then
            labela_preostalih.ForeColor = Form1.f3_fore_color
            labela_preostalih.BackColor = Form1.f3_labele_color
        End If
        Me.Label1.BackColor = Form1.f3_backgroung_color
        Form2.Panel1.BackColor = Form1.f2_panel1_backcolor    'zavrsi boje
    End Sub
    Private Sub Form3_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave
        Form2.Focus()
    End Sub
End Class