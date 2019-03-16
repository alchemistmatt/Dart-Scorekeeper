Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()> Partial Class frmDarts
#Region "Windows Form Designer generated code "
    <System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
        If Disposing Then
            If Not components Is Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents mnuStats As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuExit As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuEditPlayers As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuProgramOptions As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuOptions As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnu301 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuCricket As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuGolf As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuPlay As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuAbout As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MainMenu1 As System.Windows.Forms.MenuStrip
    Public WithEvents cmdGolf As System.Windows.Forms.Button
    Public WithEvents cmdShowStats As System.Windows.Forms.Button
    Public WithEvents cmdPlay301 As System.Windows.Forms.Button
    Public WithEvents cmdExit As System.Windows.Forms.Button
    Public WithEvents cmdPlayCricket As System.Windows.Forms.Button
    Public WithEvents lblWinmau As System.Windows.Forms.Label
    Public WithEvents lblTitle As System.Windows.Forms.Label
    Public WithEvents lblDatePhrase As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDarts))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.MainMenu1 = New System.Windows.Forms.MenuStrip
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuStats = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuOptions = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuEditPlayers = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuProgramOptions = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPlay = New System.Windows.Forms.ToolStripMenuItem
        Me.mnu301 = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuCricket = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuGolf = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuAbout = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdGolf = New System.Windows.Forms.Button
        Me.cmdShowStats = New System.Windows.Forms.Button
        Me.cmdPlay301 = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdPlayCricket = New System.Windows.Forms.Button
        Me.lblWinmau = New System.Windows.Forms.Label
        Me.lblTitle = New System.Windows.Forms.Label
        Me.lblDatePhrase = New System.Windows.Forms.Label
        Me.MainMenu1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuOptions, Me.mnuPlay, Me.mnuAbout})
        Me.MainMenu1.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu1.Name = "MainMenu1"
        Me.MainMenu1.Size = New System.Drawing.Size(276, 27)
        Me.MainMenu1.TabIndex = 8
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuStats, Me.mnuExit})
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(41, 23)
        Me.mnuFile.Text = "&File"
        '
        'mnuStats
        '
        Me.mnuStats.Name = "mnuStats"
        Me.mnuStats.Size = New System.Drawing.Size(108, 24)
        Me.mnuStats.Text = "&Stats"
        '
        'mnuExit
        '
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Size = New System.Drawing.Size(108, 24)
        Me.mnuExit.Text = "E&xit"
        '
        'mnuOptions
        '
        Me.mnuOptions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEditPlayers, Me.mnuProgramOptions})
        Me.mnuOptions.Name = "mnuOptions"
        Me.mnuOptions.Size = New System.Drawing.Size(44, 23)
        Me.mnuOptions.Text = "&Edit"
        '
        'mnuEditPlayers
        '
        Me.mnuEditPlayers.Name = "mnuEditPlayers"
        Me.mnuEditPlayers.Size = New System.Drawing.Size(184, 24)
        Me.mnuEditPlayers.Text = "&Player Names"
        '
        'mnuProgramOptions
        '
        Me.mnuProgramOptions.Name = "mnuProgramOptions"
        Me.mnuProgramOptions.Size = New System.Drawing.Size(184, 24)
        Me.mnuProgramOptions.Text = "&Program Options"
        '
        'mnuPlay
        '
        Me.mnuPlay.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnu301, Me.mnuCricket, Me.mnuGolf})
        Me.mnuPlay.Name = "mnuPlay"
        Me.mnuPlay.Size = New System.Drawing.Size(46, 23)
        Me.mnuPlay.Text = "&Play"
        '
        'mnu301
        '
        Me.mnu301.Name = "mnu301"
        Me.mnu301.Size = New System.Drawing.Size(120, 24)
        Me.mnu301.Text = "&301"
        '
        'mnuCricket
        '
        Me.mnuCricket.Name = "mnuCricket"
        Me.mnuCricket.Size = New System.Drawing.Size(120, 24)
        Me.mnuCricket.Text = "&Cricket"
        '
        'mnuGolf
        '
        Me.mnuGolf.Name = "mnuGolf"
        Me.mnuGolf.Size = New System.Drawing.Size(120, 24)
        Me.mnuGolf.Text = "&Golf"
        '
        'mnuAbout
        '
        Me.mnuAbout.Name = "mnuAbout"
        Me.mnuAbout.Size = New System.Drawing.Size(59, 23)
        Me.mnuAbout.Text = "&About"
        '
        'cmdGolf
        '
        Me.cmdGolf.BackColor = System.Drawing.SystemColors.Control
        Me.cmdGolf.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdGolf.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.cmdGolf.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdGolf.Location = New System.Drawing.Point(8, 128)
        Me.cmdGolf.Name = "cmdGolf"
        Me.cmdGolf.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdGolf.Size = New System.Drawing.Size(136, 25)
        Me.cmdGolf.TabIndex = 7
        Me.cmdGolf.Text = "Play &Golf"
        Me.cmdGolf.UseVisualStyleBackColor = False
        '
        'cmdShowStats
        '
        Me.cmdShowStats.BackColor = System.Drawing.SystemColors.Control
        Me.cmdShowStats.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdShowStats.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.cmdShowStats.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdShowStats.Location = New System.Drawing.Point(160, 80)
        Me.cmdShowStats.Name = "cmdShowStats"
        Me.cmdShowStats.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdShowStats.Size = New System.Drawing.Size(104, 25)
        Me.cmdShowStats.TabIndex = 5
        Me.cmdShowStats.Text = "&Stats"
        Me.cmdShowStats.UseVisualStyleBackColor = False
        '
        'cmdPlay301
        '
        Me.cmdPlay301.BackColor = System.Drawing.SystemColors.Control
        Me.cmdPlay301.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdPlay301.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.cmdPlay301.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdPlay301.Location = New System.Drawing.Point(8, 64)
        Me.cmdPlay301.Name = "cmdPlay301"
        Me.cmdPlay301.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdPlay301.Size = New System.Drawing.Size(136, 25)
        Me.cmdPlay301.TabIndex = 2
        Me.cmdPlay301.Text = "Play &301"
        Me.cmdPlay301.UseVisualStyleBackColor = False
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExit.Location = New System.Drawing.Point(160, 112)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExit.Size = New System.Drawing.Size(104, 25)
        Me.cmdExit.TabIndex = 3
        Me.cmdExit.Text = "E&xit Program"
        Me.cmdExit.UseVisualStyleBackColor = False
        '
        'cmdPlayCricket
        '
        Me.cmdPlayCricket.BackColor = System.Drawing.SystemColors.Control
        Me.cmdPlayCricket.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdPlayCricket.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.cmdPlayCricket.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdPlayCricket.Location = New System.Drawing.Point(8, 96)
        Me.cmdPlayCricket.Name = "cmdPlayCricket"
        Me.cmdPlayCricket.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdPlayCricket.Size = New System.Drawing.Size(136, 25)
        Me.cmdPlayCricket.TabIndex = 1
        Me.cmdPlayCricket.Text = "Play &Cricket"
        Me.cmdPlayCricket.UseVisualStyleBackColor = False
        '
        'lblWinmau
        '
        Me.lblWinmau.BackColor = System.Drawing.SystemColors.Control
        Me.lblWinmau.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblWinmau.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.lblWinmau.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblWinmau.Location = New System.Drawing.Point(8, 168)
        Me.lblWinmau.Name = "lblWinmau"
        Me.lblWinmau.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblWinmau.Size = New System.Drawing.Size(105, 17)
        Me.lblWinmau.TabIndex = 4
        Me.lblWinmau.Text = "Winmau:"
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.SystemColors.Control
        Me.lblTitle.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTitle.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0)
        Me.lblTitle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTitle.Location = New System.Drawing.Point(56, 32)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitle.Size = New System.Drawing.Size(161, 25)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Dart Scorekeeper"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblDatePhrase
        '
        Me.lblDatePhrase.BackColor = System.Drawing.SystemColors.Control
        Me.lblDatePhrase.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDatePhrase.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.lblDatePhrase.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDatePhrase.Location = New System.Drawing.Point(8, 192)
        Me.lblDatePhrase.Name = "lblDatePhrase"
        Me.lblDatePhrase.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDatePhrase.Size = New System.Drawing.Size(257, 17)
        Me.lblDatePhrase.TabIndex = 6
        '
        'frmDarts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(276, 223)
        Me.Controls.Add(Me.cmdGolf)
        Me.Controls.Add(Me.cmdShowStats)
        Me.Controls.Add(Me.cmdPlay301)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdPlayCricket)
        Me.Controls.Add(Me.lblWinmau)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblDatePhrase)
        Me.Controls.Add(Me.MainMenu1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(173, 157)
        Me.MaximizeBox = False
        Me.Name = "frmDarts"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Dart Scorekeeper"
        Me.MainMenu1.ResumeLayout(False)
        Me.MainMenu1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region
End Class