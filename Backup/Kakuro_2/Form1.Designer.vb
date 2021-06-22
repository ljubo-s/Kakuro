<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LoadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveCurrentPuzzleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OptionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SkinToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BrownToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BlackToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BlueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Button5 = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem
        Me.Brown = New System.Windows.Forms.ToolStripMenuItem
        Me.Black = New System.Windows.Forms.ToolStripMenuItem
        Me.Blue = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LearnToPlayKakuroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Button6 = New System.Windows.Forms.Button
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.DarkRed
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button1.Location = New System.Drawing.Point(34, 38)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(122, 34)
        Me.Button1.TabIndex = 0
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Font = New System.Drawing.Font("Verdana", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 316)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 50)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "00"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label2.Font = New System.Drawing.Font("Verdana", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label2.Location = New System.Drawing.Point(110, 316)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 50)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "00"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem, Me.LoadToolStripMenuItem, Me.SaveCurrentPuzzleToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.AutoSize = False
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(220, 22)
        Me.SaveToolStripMenuItem.Text = "New puzzle"
        '
        'LoadToolStripMenuItem
        '
        Me.LoadToolStripMenuItem.AutoSize = False
        Me.LoadToolStripMenuItem.Name = "LoadToolStripMenuItem"
        Me.LoadToolStripMenuItem.Size = New System.Drawing.Size(220, 22)
        Me.LoadToolStripMenuItem.Text = "&Open a saved puzzle..."
        '
        'SaveCurrentPuzzleToolStripMenuItem
        '
        Me.SaveCurrentPuzzleToolStripMenuItem.Name = "SaveCurrentPuzzleToolStripMenuItem"
        Me.SaveCurrentPuzzleToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.SaveCurrentPuzzleToolStripMenuItem.Text = " Save current puzzle... "
        '
        'OptionToolStripMenuItem
        '
        Me.OptionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SkinToolStripMenuItem})
        Me.OptionToolStripMenuItem.Name = "OptionToolStripMenuItem"
        Me.OptionToolStripMenuItem.Size = New System.Drawing.Size(51, 20)
        Me.OptionToolStripMenuItem.Text = "Option"
        '
        'SkinToolStripMenuItem
        '
        Me.SkinToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BrownToolStripMenuItem, Me.BlackToolStripMenuItem, Me.BlueToolStripMenuItem})
        Me.SkinToolStripMenuItem.Name = "SkinToolStripMenuItem"
        Me.SkinToolStripMenuItem.Size = New System.Drawing.Size(96, 22)
        Me.SkinToolStripMenuItem.Text = "Skin"
        '
        'BrownToolStripMenuItem
        '
        Me.BrownToolStripMenuItem.Name = "BrownToolStripMenuItem"
        Me.BrownToolStripMenuItem.Size = New System.Drawing.Size(108, 22)
        Me.BrownToolStripMenuItem.Text = "Brown"
        '
        'BlackToolStripMenuItem
        '
        Me.BlackToolStripMenuItem.Name = "BlackToolStripMenuItem"
        Me.BlackToolStripMenuItem.Size = New System.Drawing.Size(108, 22)
        Me.BlackToolStripMenuItem.Text = "Black"
        '
        'BlueToolStripMenuItem
        '
        Me.BlueToolStripMenuItem.Name = "BlueToolStripMenuItem"
        Me.BlueToolStripMenuItem.Size = New System.Drawing.Size(108, 22)
        Me.BlueToolStripMenuItem.Text = "Blue"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.DarkRed
        Me.Button2.Location = New System.Drawing.Point(48, 94)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(92, 34)
        Me.Button2.TabIndex = 6
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(1242, 166)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(80, 42)
        Me.Button3.TabIndex = 7
        Me.Button3.Text = "Solve"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.DarkRed
        Me.Button4.Location = New System.Drawing.Point(48, 194)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(90, 34)
        Me.Button4.TabIndex = 8
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.SaddleBrown
        Me.Label3.Location = New System.Drawing.Point(68, 130)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 14)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Mistakes"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.SaddleBrown
        Me.Label4.Location = New System.Drawing.Point(74, 232)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 14)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Solve"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.SaddleBrown
        Me.Label5.Location = New System.Drawing.Point(66, 180)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 14)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "One Hint"
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.Maroon
        Me.Button5.Location = New System.Drawing.Point(56, 144)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(72, 34)
        Me.Button5.TabIndex = 13
        Me.Button5.UseVisualStyleBackColor = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "*.kak"
        Me.OpenFileDialog1.Filter = "Kakuro files (*.kak)|*.kak"
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = "Kakuro files (*.kak)|*.kak"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem5, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(194, 24)
        Me.MenuStrip1.TabIndex = 18
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2, Me.ToolStripMenuItem3, Me.ToolStripMenuItem4})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(37, 20)
        Me.ToolStripMenuItem1.Text = "File"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.AutoSize = False
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(220, 22)
        Me.ToolStripMenuItem2.Text = "New puzzle"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.AutoSize = False
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(220, 22)
        Me.ToolStripMenuItem3.Text = "&Open a saved puzzle..."
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(190, 22)
        Me.ToolStripMenuItem4.Text = " Save current puzzle... "
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem6})
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(56, 20)
        Me.ToolStripMenuItem5.Text = "Option"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Brown, Me.Black, Me.Blue})
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(96, 22)
        Me.ToolStripMenuItem6.Text = "Skin"
        '
        'Brown
        '
        Me.Brown.Name = "Brown"
        Me.Brown.Size = New System.Drawing.Size(108, 22)
        Me.Brown.Text = "Brown"
        '
        'Black
        '
        Me.Black.Name = "Black"
        Me.Black.Size = New System.Drawing.Size(108, 22)
        Me.Black.Text = "Black"
        '
        'Blue
        '
        Me.Blue.Name = "Blue"
        Me.Blue.Size = New System.Drawing.Size(108, 22)
        Me.Blue.Text = "Blue"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem, Me.LearnToPlayKakuroToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.AboutToolStripMenuItem.Text = "About Kakuro..."
        '
        'LearnToPlayKakuroToolStripMenuItem
        '
        Me.LearnToPlayKakuroToolStripMenuItem.Name = "LearnToPlayKakuroToolStripMenuItem"
        Me.LearnToPlayKakuroToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.LearnToPlayKakuroToolStripMenuItem.Text = "Learn To Play Kakuro"
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(32, 248)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(122, 34)
        Me.Button6.TabIndex = 19
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkKhaki
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(194, 364)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(210, 400)
        Me.MinimumSize = New System.Drawing.Size(110, 400)
        Me.Name = "Form1"
        Me.Text = "Kakuro"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents SkinToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BrownToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BlackToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BlueToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveCurrentPuzzleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Brown As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Black As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Blue As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LearnToPlayKakuroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button6 As System.Windows.Forms.Button

End Class
