<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmDarts
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDarts))
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
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
        Me.ToolTip1.Active = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Dart Scorekeeper"
        Me.ClientSize = New System.Drawing.Size(276, 223)
        Me.Location = New System.Drawing.Point(173, 157)
        Me.Icon = CType(resources.GetObject("frmMain.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
        Me.ControlBox = True
        Me.Enabled = True
        Me.KeyPreview = False
        Me.MinimizeBox = True
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = True
        Me.HelpButton = False
        Me.WindowState = System.Windows.Forms.FormWindowState.Normal
        Me.Name = "frmMain"
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Text = "&File"
        Me.mnuFile.Checked = False
        Me.mnuFile.Enabled = True
        Me.mnuFile.Visible = True
        Me.mnuStats.Name = "mnuStats"
        Me.mnuStats.Text = "&Stats"
        Me.mnuStats.Checked = False
        Me.mnuStats.Enabled = True
        Me.mnuStats.Visible = True
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Text = "E&xit"
        Me.mnuExit.Checked = False
        Me.mnuExit.Enabled = True
        Me.mnuExit.Visible = True
        Me.mnuOptions.Name = "mnuOptions"
        Me.mnuOptions.Text = "&Edit"
        Me.mnuOptions.Checked = False
        Me.mnuOptions.Enabled = True
        Me.mnuOptions.Visible = True
        Me.mnuEditPlayers.Name = "mnuEditPlayers"
        Me.mnuEditPlayers.Text = "&Player Names"
        Me.mnuEditPlayers.Checked = False
        Me.mnuEditPlayers.Enabled = True
        Me.mnuEditPlayers.Visible = True
        Me.mnuProgramOptions.Name = "mnuProgramOptions"
        Me.mnuProgramOptions.Text = "&Program Options"
        Me.mnuProgramOptions.Checked = False
        Me.mnuProgramOptions.Enabled = True
        Me.mnuProgramOptions.Visible = True
        Me.mnuPlay.Name = "mnuPlay"
        Me.mnuPlay.Text = "&Play"
        Me.mnuPlay.Checked = False
        Me.mnuPlay.Enabled = True
        Me.mnuPlay.Visible = True
        Me.mnu301.Name = "mnu301"
        Me.mnu301.Text = "&301"
        Me.mnu301.Checked = False
        Me.mnu301.Enabled = True
        Me.mnu301.Visible = True
        Me.mnuCricket.Name = "mnuCricket"
        Me.mnuCricket.Text = "&Cricket"
        Me.mnuCricket.Checked = False
        Me.mnuCricket.Enabled = True
        Me.mnuCricket.Visible = True
        Me.mnuGolf.Name = "mnuGolf"
        Me.mnuGolf.Text = "&Golf"
        Me.mnuGolf.Checked = False
        Me.mnuGolf.Enabled = True
        Me.mnuGolf.Visible = True
        Me.mnuAbout.Name = "mnuAbout"
        Me.mnuAbout.Text = "&About"
        Me.mnuAbout.Checked = False
        Me.mnuAbout.Enabled = True
        Me.mnuAbout.Visible = True
        Me.cmdGolf.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdGolf.Text = "Play &Golf"
        Me.cmdGolf.Size = New System.Drawing.Size(121, 25)
        Me.cmdGolf.Location = New System.Drawing.Point(8, 128)
        Me.cmdGolf.TabIndex = 7
        Me.cmdGolf.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGolf.BackColor = System.Drawing.SystemColors.Control
        Me.cmdGolf.CausesValidation = True
        Me.cmdGolf.Enabled = True
        Me.cmdGolf.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdGolf.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdGolf.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdGolf.TabStop = True
        Me.cmdGolf.Name = "cmdGolf"
        Me.cmdShowStats.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdShowStats.Text = "&Stats"
        Me.cmdShowStats.Size = New System.Drawing.Size(81, 25)
        Me.cmdShowStats.Location = New System.Drawing.Point(160, 80)
        Me.cmdShowStats.TabIndex = 5
        Me.cmdShowStats.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdShowStats.BackColor = System.Drawing.SystemColors.Control
        Me.cmdShowStats.CausesValidation = True
        Me.cmdShowStats.Enabled = True
        Me.cmdShowStats.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdShowStats.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdShowStats.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdShowStats.TabStop = True
        Me.cmdShowStats.Name = "cmdShowStats"
        Me.cmdPlay301.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdPlay301.Text = "Play &301"
        Me.cmdPlay301.Size = New System.Drawing.Size(121, 25)
        Me.cmdPlay301.Location = New System.Drawing.Point(8, 64)
        Me.cmdPlay301.TabIndex = 2
        Me.cmdPlay301.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPlay301.BackColor = System.Drawing.SystemColors.Control
        Me.cmdPlay301.CausesValidation = True
        Me.cmdPlay301.Enabled = True
        Me.cmdPlay301.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdPlay301.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdPlay301.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdPlay301.TabStop = True
        Me.cmdPlay301.Name = "cmdPlay301"
        Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdExit.Text = "E&xit Program"
        Me.cmdExit.Size = New System.Drawing.Size(81, 25)
        Me.cmdExit.Location = New System.Drawing.Point(160, 112)
        Me.cmdExit.TabIndex = 3
        Me.cmdExit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExit.CausesValidation = True
        Me.cmdExit.Enabled = True
        Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExit.TabStop = True
        Me.cmdExit.Name = "cmdExit"
        Me.cmdPlayCricket.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdPlayCricket.Text = "Play &Cricket"
        Me.cmdPlayCricket.Size = New System.Drawing.Size(121, 25)
        Me.cmdPlayCricket.Location = New System.Drawing.Point(8, 96)
        Me.cmdPlayCricket.TabIndex = 1
        Me.cmdPlayCricket.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPlayCricket.BackColor = System.Drawing.SystemColors.Control
        Me.cmdPlayCricket.CausesValidation = True
        Me.cmdPlayCricket.Enabled = True
        Me.cmdPlayCricket.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdPlayCricket.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdPlayCricket.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdPlayCricket.TabStop = True
        Me.cmdPlayCricket.Name = "cmdPlayCricket"
        Me.lblWinmau.Text = "Winmau:"
        Me.lblWinmau.Size = New System.Drawing.Size(105, 17)
        Me.lblWinmau.Location = New System.Drawing.Point(8, 168)
        Me.lblWinmau.TabIndex = 4
        Me.lblWinmau.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWinmau.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.lblWinmau.BackColor = System.Drawing.SystemColors.Control
        Me.lblWinmau.Enabled = True
        Me.lblWinmau.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblWinmau.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblWinmau.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblWinmau.UseMnemonic = True
        Me.lblWinmau.Visible = True
        Me.lblWinmau.AutoSize = False
        Me.lblWinmau.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblWinmau.Name = "lblWinmau"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTitle.Text = "Dart Scorekeeper"
        Me.lblTitle.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Size = New System.Drawing.Size(161, 25)
        Me.lblTitle.Location = New System.Drawing.Point(56, 32)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.BackColor = System.Drawing.SystemColors.Control
        Me.lblTitle.Enabled = True
        Me.lblTitle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTitle.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTitle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitle.UseMnemonic = True
        Me.lblTitle.Visible = True
        Me.lblTitle.AutoSize = False
        Me.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblTitle.Name = "lblTitle"
        Me.lblDatePhrase.Size = New System.Drawing.Size(257, 17)
        Me.lblDatePhrase.Location = New System.Drawing.Point(8, 192)
        Me.lblDatePhrase.TabIndex = 6
        Me.lblDatePhrase.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatePhrase.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.lblDatePhrase.BackColor = System.Drawing.SystemColors.Control
        Me.lblDatePhrase.Enabled = True
        Me.lblDatePhrase.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDatePhrase.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDatePhrase.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDatePhrase.UseMnemonic = True
        Me.lblDatePhrase.Visible = True
        Me.lblDatePhrase.AutoSize = False
        Me.lblDatePhrase.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblDatePhrase.Name = "lblDatePhrase"
        Me.Controls.Add(cmdGolf)
        Me.Controls.Add(cmdShowStats)
        Me.Controls.Add(cmdPlay301)
        Me.Controls.Add(cmdExit)
        Me.Controls.Add(cmdPlayCricket)
        Me.Controls.Add(lblWinmau)
        Me.Controls.Add(lblTitle)
        Me.Controls.Add(lblDatePhrase)
        MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuOptions, Me.mnuPlay, Me.mnuAbout})
        mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuStats, Me.mnuExit})
        mnuOptions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEditPlayers, Me.mnuProgramOptions})
        mnuPlay.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnu301, Me.mnuCricket, Me.mnuGolf})
        Me.Controls.Add(MainMenu1)
        Me.MainMenu1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
#End Region
End Class