Public Class Form6
    Public n, m As Integer
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        '    Form1.int_n = 8
        '    Form1.int_m = 6
        '    n = 8
        '    m = 6
        Me.Close()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Location = New Point(0, 0)
        Me.SendToBack()
        Me.Visible = False
        '   If RadioButton5.Checked = True Then
        ' n = 16
        ' m = 12
        ' End If
        If RadioButton4.Checked = True Then
            n = 12
            m = 12
        End If
        If RadioButton1.Checked = True Then
            n = 8
            m = 6
        End If
        If RadioButton2.Checked = True Then
            n = 10
            m = 8
        End If
        If RadioButton3.Checked = True Then
            n = 12
            m = 10
        End If
        Form3.Close()
        Form1.int_n = n
        Form1.int_m = m
        Form1.fil = 1
        Dim temp As Integer = Form1.skin
        Form1.Resetuj(n, m)
        Form1.skin = temp
        Form1.Podesi_Boje()
        Me.Visible = False
        Me.Close()
    End Sub

    Private Sub Form6_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class