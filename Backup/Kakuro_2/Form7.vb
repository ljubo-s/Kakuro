Public Class Form7
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form1.Enabled = True

        '        If Not Form2 Is Nothing Then
        '        Form2.Enabled = True
        '       End If
        '      If Not Form2 Is Nothing Then
        'Form3.Enabled = True
        '     End If
        If Not Form2 Is Nothing Then
            Form2.Enabled = True
        End If
        If Not Form2 Is Nothing Then
            Form3.Enabled = True
        End If

        Me.Close()
    End Sub
    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("mailto:" & "ljubos@cg.yu")
    End Sub

    Private Sub Form7_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Form1.Enabled = False

        '        If Not Form2 Is Nothing Then
        'Form2.Enabled = False
        '       End If
        '       If Not Form2 Is Nothing Then
        ' Form3.Enabled = False
        '      End If
        If Not Form2 Is Nothing Then
            Form2.Enabled = False
        End If
        If Not Form2 Is Nothing Then
            Form3.Enabled = False
        End If
    End Sub
End Class