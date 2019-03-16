<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmOptions
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
    Public WithEvents cmdDefaults As System.Windows.Forms.Button
    Public WithEvents cmdClose As System.Windows.Forms.Button
    Public WithEvents cmdCancel As System.Windows.Forms.Button
    Public WithEvents fraButtons As System.Windows.Forms.Panel
    Public WithEvents cboScoreAreaSize As System.Windows.Forms.ComboBox
    Public WithEvents cboDartBoardSize As System.Windows.Forms.ComboBox
    Public WithEvents txtMinimumScoreToPlaySound As System.Windows.Forms.TextBox
    Public WithEvents cboScoreFontSize As System.Windows.Forms.ComboBox
    Public WithEvents chkPlaySounds As System.Windows.Forms.CheckBox
    Public WithEvents lblScoreAreaSize As System.Windows.Forms.Label
    Public WithEvents lblDartBoardSize As System.Windows.Forms.Label
    Public WithEvents lblMinimumScoreToPlaySound As System.Windows.Forms.Label
    Public WithEvents lblScoreFontSize As System.Windows.Forms.Label
    Public WithEvents fraOtherOptions As System.Windows.Forms.GroupBox
    Public WithEvents txtDefault301StartScore As System.Windows.Forms.TextBox
    Public WithEvents lblDefault301StartScore As System.Windows.Forms.Label
    Public WithEvents frm301Options As System.Windows.Forms.GroupBox
    Public WithEvents optScoringModeHighScoreWins As System.Windows.Forms.RadioButton
    Public WithEvents optScoringModeLowScoreWins As System.Windows.Forms.RadioButton
    Public WithEvents chkCutThroatCricket As System.Windows.Forms.CheckBox
    Public WithEvents frmCricketOptions As System.Windows.Forms.GroupBox
    Public WithEvents chkRotateBoardClockwise As System.Windows.Forms.CheckBox
    Public WithEvents txtLastRotateHit As System.Windows.Forms.TextBox
    Public WithEvents txtCurrentWinmauNumber As System.Windows.Forms.TextBox
    Public WithEvents txtHitsBetweenRotate As System.Windows.Forms.TextBox
    Public WithEvents txtTotalHits As System.Windows.Forms.TextBox
    Public WithEvents lblLastRotateHit As System.Windows.Forms.Label
    Public WithEvents lblCurrentWinmauNumber As System.Windows.Forms.Label
    Public WithEvents lblHitsBetweenRotate As System.Windows.Forms.Label
    Public WithEvents lblTotalHits As System.Windows.Forms.Label
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOptions))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.chkRotateBoardClockwise = New System.Windows.Forms.CheckBox
        Me.txtLastRotateHit = New System.Windows.Forms.TextBox
        Me.txtCurrentWinmauNumber = New System.Windows.Forms.TextBox
        Me.txtHitsBetweenRotate = New System.Windows.Forms.TextBox
        Me.txtTotalHits = New System.Windows.Forms.TextBox
        Me.cmdDefaults = New System.Windows.Forms.Button
        Me.fraButtons = New System.Windows.Forms.Panel
        Me.cmdClose = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.fraOtherOptions = New System.Windows.Forms.GroupBox
        Me.cboScoreAreaSize = New System.Windows.Forms.ComboBox
        Me.cboDartBoardSize = New System.Windows.Forms.ComboBox
        Me.txtMinimumScoreToPlaySound = New System.Windows.Forms.TextBox
        Me.cboScoreFontSize = New System.Windows.Forms.ComboBox
        Me.chkPlaySounds = New System.Windows.Forms.CheckBox
        Me.lblScoreAreaSize = New System.Windows.Forms.Label
        Me.lblDartBoardSize = New System.Windows.Forms.Label
        Me.lblMinimumScoreToPlaySound = New System.Windows.Forms.Label
        Me.lblScoreFontSize = New System.Windows.Forms.Label
        Me.frm301Options = New System.Windows.Forms.GroupBox
        Me.txtDefault301StartScore = New System.Windows.Forms.TextBox
        Me.lblDefault301StartScore = New System.Windows.Forms.Label
        Me.frmCricketOptions = New System.Windows.Forms.GroupBox
        Me.optScoringModeHighScoreWins = New System.Windows.Forms.RadioButton
        Me.optScoringModeLowScoreWins = New System.Windows.Forms.RadioButton
        Me.chkCutThroatCricket = New System.Windows.Forms.CheckBox
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.lblLastRotateHit = New System.Windows.Forms.Label
        Me.lblCurrentWinmauNumber = New System.Windows.Forms.Label
        Me.lblHitsBetweenRotate = New System.Windows.Forms.Label
        Me.lblTotalHits = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.fraButtons.SuspendLayout()
        Me.fraOtherOptions.SuspendLayout()
        Me.frm301Options.SuspendLayout()
        Me.frmCricketOptions.SuspendLayout()
        Me.Frame1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkRotateBoardClockwise
        '
        Me.chkRotateBoardClockwise.BackColor = System.Drawing.SystemColors.Control
        Me.chkRotateBoardClockwise.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkRotateBoardClockwise.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRotateBoardClockwise.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkRotateBoardClockwise.Location = New System.Drawing.Point(224, 48)
        Me.chkRotateBoardClockwise.Name = "chkRotateBoardClockwise"
        Me.chkRotateBoardClockwise.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkRotateBoardClockwise.Size = New System.Drawing.Size(169, 25)
        Me.chkRotateBoardClockwise.TabIndex = 5
        Me.chkRotateBoardClockwise.Text = "Rotate Board Clockwise"
        Me.ToolTip1.SetToolTip(Me.chkRotateBoardClockwise, "The direction to rotate the dart board, every 'Hits between Rotations' hits.")
        Me.chkRotateBoardClockwise.UseVisualStyleBackColor = False
        '
        'txtLastRotateHit
        '
        Me.txtLastRotateHit.AcceptsReturn = True
        Me.txtLastRotateHit.BackColor = System.Drawing.SystemColors.Window
        Me.txtLastRotateHit.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLastRotateHit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastRotateHit.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLastRotateHit.Location = New System.Drawing.Point(160, 96)
        Me.txtLastRotateHit.MaxLength = 0
        Me.txtLastRotateHit.Name = "txtLastRotateHit"
        Me.txtLastRotateHit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLastRotateHit.Size = New System.Drawing.Size(57, 22)
        Me.txtLastRotateHit.TabIndex = 9
        Me.txtLastRotateHit.Text = "0"
        Me.ToolTip1.SetToolTip(Me.txtLastRotateHit, "The last value at which the board was rotated.")
        '
        'txtCurrentWinmauNumber
        '
        Me.txtCurrentWinmauNumber.AcceptsReturn = True
        Me.txtCurrentWinmauNumber.BackColor = System.Drawing.SystemColors.Window
        Me.txtCurrentWinmauNumber.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCurrentWinmauNumber.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCurrentWinmauNumber.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCurrentWinmauNumber.Location = New System.Drawing.Point(160, 72)
        Me.txtCurrentWinmauNumber.MaxLength = 0
        Me.txtCurrentWinmauNumber.Name = "txtCurrentWinmauNumber"
        Me.txtCurrentWinmauNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCurrentWinmauNumber.Size = New System.Drawing.Size(57, 22)
        Me.txtCurrentWinmauNumber.TabIndex = 7
        Me.txtCurrentWinmauNumber.Text = "8"
        Me.ToolTip1.SetToolTip(Me.txtCurrentWinmauNumber, "When rotating the board, the wire with the numbers must be adjusted.  Position th" & _
                "e brandname of the board (Winmau here) on the given number.")
        '
        'txtHitsBetweenRotate
        '
        Me.txtHitsBetweenRotate.AcceptsReturn = True
        Me.txtHitsBetweenRotate.BackColor = System.Drawing.SystemColors.Window
        Me.txtHitsBetweenRotate.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtHitsBetweenRotate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHitsBetweenRotate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtHitsBetweenRotate.Location = New System.Drawing.Point(160, 48)
        Me.txtHitsBetweenRotate.MaxLength = 0
        Me.txtHitsBetweenRotate.Name = "txtHitsBetweenRotate"
        Me.txtHitsBetweenRotate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtHitsBetweenRotate.Size = New System.Drawing.Size(57, 22)
        Me.txtHitsBetweenRotate.TabIndex = 4
        Me.txtHitsBetweenRotate.Text = "1000"
        Me.ToolTip1.SetToolTip(Me.txtHitsBetweenRotate, "Every 'Hits between Rotations' hits the program will remind you to rotate the dar" & _
                "t board to evenly 'wear out' the dart board.")
        '
        'txtTotalHits
        '
        Me.txtTotalHits.AcceptsReturn = True
        Me.txtTotalHits.BackColor = System.Drawing.SystemColors.Window
        Me.txtTotalHits.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalHits.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalHits.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTotalHits.Location = New System.Drawing.Point(160, 24)
        Me.txtTotalHits.MaxLength = 0
        Me.txtTotalHits.Name = "txtTotalHits"
        Me.txtTotalHits.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTotalHits.Size = New System.Drawing.Size(57, 22)
        Me.txtTotalHits.TabIndex = 2
        Me.txtTotalHits.Text = "0"
        Me.ToolTip1.SetToolTip(Me.txtTotalHits, "Total hits to the board recorded.  The program automatically adjusts this number " & _
                "with each hit.")
        '
        'cmdDefaults
        '
        Me.cmdDefaults.BackColor = System.Drawing.SystemColors.Control
        Me.cmdDefaults.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdDefaults.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDefaults.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdDefaults.Location = New System.Drawing.Point(312, 360)
        Me.cmdDefaults.Name = "cmdDefaults"
        Me.cmdDefaults.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdDefaults.Size = New System.Drawing.Size(73, 25)
        Me.cmdDefaults.TabIndex = 30
        Me.cmdDefaults.Text = "&Defaults"
        Me.cmdDefaults.UseVisualStyleBackColor = False
        '
        'fraButtons
        '
        Me.fraButtons.BackColor = System.Drawing.SystemColors.Control
        Me.fraButtons.Controls.Add(Me.cmdClose)
        Me.fraButtons.Controls.Add(Me.cmdCancel)
        Me.fraButtons.Cursor = System.Windows.Forms.Cursors.Default
        Me.fraButtons.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraButtons.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraButtons.Location = New System.Drawing.Point(320, 240)
        Me.fraButtons.Name = "fraButtons"
        Me.fraButtons.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraButtons.Size = New System.Drawing.Size(57, 57)
        Me.fraButtons.TabIndex = 23
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClose.Location = New System.Drawing.Point(0, 0)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClose.Size = New System.Drawing.Size(57, 25)
        Me.cmdClose.TabIndex = 24
        Me.cmdClose.Text = "&Ok"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(0, 32)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(57, 25)
        Me.cmdCancel.TabIndex = 25
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'fraOtherOptions
        '
        Me.fraOtherOptions.BackColor = System.Drawing.SystemColors.Control
        Me.fraOtherOptions.Controls.Add(Me.cboScoreAreaSize)
        Me.fraOtherOptions.Controls.Add(Me.cboDartBoardSize)
        Me.fraOtherOptions.Controls.Add(Me.txtMinimumScoreToPlaySound)
        Me.fraOtherOptions.Controls.Add(Me.cboScoreFontSize)
        Me.fraOtherOptions.Controls.Add(Me.chkPlaySounds)
        Me.fraOtherOptions.Controls.Add(Me.lblScoreAreaSize)
        Me.fraOtherOptions.Controls.Add(Me.lblDartBoardSize)
        Me.fraOtherOptions.Controls.Add(Me.lblMinimumScoreToPlaySound)
        Me.fraOtherOptions.Controls.Add(Me.lblScoreFontSize)
        Me.fraOtherOptions.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraOtherOptions.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraOtherOptions.Location = New System.Drawing.Point(8, 296)
        Me.fraOtherOptions.Name = "fraOtherOptions"
        Me.fraOtherOptions.Padding = New System.Windows.Forms.Padding(0)
        Me.fraOtherOptions.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraOtherOptions.Size = New System.Drawing.Size(265, 169)
        Me.fraOtherOptions.TabIndex = 17
        Me.fraOtherOptions.TabStop = False
        Me.fraOtherOptions.Text = "Other Options"
        '
        'cboScoreAreaSize
        '
        Me.cboScoreAreaSize.BackColor = System.Drawing.SystemColors.Window
        Me.cboScoreAreaSize.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboScoreAreaSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboScoreAreaSize.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboScoreAreaSize.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboScoreAreaSize.Location = New System.Drawing.Point(96, 112)
        Me.cboScoreAreaSize.Name = "cboScoreAreaSize"
        Me.cboScoreAreaSize.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboScoreAreaSize.Size = New System.Drawing.Size(89, 22)
        Me.cboScoreAreaSize.TabIndex = 28
        '
        'cboDartBoardSize
        '
        Me.cboDartBoardSize.BackColor = System.Drawing.SystemColors.Window
        Me.cboDartBoardSize.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboDartBoardSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDartBoardSize.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDartBoardSize.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboDartBoardSize.Location = New System.Drawing.Point(96, 139)
        Me.cboDartBoardSize.Name = "cboDartBoardSize"
        Me.cboDartBoardSize.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboDartBoardSize.Size = New System.Drawing.Size(89, 22)
        Me.cboDartBoardSize.TabIndex = 26
        '
        'txtMinimumScoreToPlaySound
        '
        Me.txtMinimumScoreToPlaySound.AcceptsReturn = True
        Me.txtMinimumScoreToPlaySound.BackColor = System.Drawing.SystemColors.Window
        Me.txtMinimumScoreToPlaySound.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMinimumScoreToPlaySound.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMinimumScoreToPlaySound.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMinimumScoreToPlaySound.Location = New System.Drawing.Point(192, 56)
        Me.txtMinimumScoreToPlaySound.MaxLength = 0
        Me.txtMinimumScoreToPlaySound.Name = "txtMinimumScoreToPlaySound"
        Me.txtMinimumScoreToPlaySound.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMinimumScoreToPlaySound.Size = New System.Drawing.Size(57, 22)
        Me.txtMinimumScoreToPlaySound.TabIndex = 20
        Me.txtMinimumScoreToPlaySound.Text = "60"
        '
        'cboScoreFontSize
        '
        Me.cboScoreFontSize.BackColor = System.Drawing.SystemColors.Window
        Me.cboScoreFontSize.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboScoreFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboScoreFontSize.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboScoreFontSize.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboScoreFontSize.Location = New System.Drawing.Point(96, 86)
        Me.cboScoreFontSize.Name = "cboScoreFontSize"
        Me.cboScoreFontSize.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboScoreFontSize.Size = New System.Drawing.Size(89, 22)
        Me.cboScoreFontSize.TabIndex = 22
        '
        'chkPlaySounds
        '
        Me.chkPlaySounds.BackColor = System.Drawing.SystemColors.Control
        Me.chkPlaySounds.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkPlaySounds.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPlaySounds.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkPlaySounds.Location = New System.Drawing.Point(16, 16)
        Me.chkPlaySounds.Name = "chkPlaySounds"
        Me.chkPlaySounds.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkPlaySounds.Size = New System.Drawing.Size(233, 37)
        Me.chkPlaySounds.TabIndex = 18
        Me.chkPlaySounds.Text = "Play wave file when advancing to next player"
        Me.chkPlaySounds.UseVisualStyleBackColor = False
        '
        'lblScoreAreaSize
        '
        Me.lblScoreAreaSize.BackColor = System.Drawing.SystemColors.Control
        Me.lblScoreAreaSize.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblScoreAreaSize.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScoreAreaSize.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblScoreAreaSize.Location = New System.Drawing.Point(8, 114)
        Me.lblScoreAreaSize.Name = "lblScoreAreaSize"
        Me.lblScoreAreaSize.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblScoreAreaSize.Size = New System.Drawing.Size(89, 17)
        Me.lblScoreAreaSize.TabIndex = 29
        Me.lblScoreAreaSize.Text = "Score Area Size"
        '
        'lblDartBoardSize
        '
        Me.lblDartBoardSize.BackColor = System.Drawing.SystemColors.Control
        Me.lblDartBoardSize.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDartBoardSize.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDartBoardSize.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDartBoardSize.Location = New System.Drawing.Point(8, 141)
        Me.lblDartBoardSize.Name = "lblDartBoardSize"
        Me.lblDartBoardSize.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDartBoardSize.Size = New System.Drawing.Size(89, 17)
        Me.lblDartBoardSize.TabIndex = 27
        Me.lblDartBoardSize.Text = "Dart Board Size"
        '
        'lblMinimumScoreToPlaySound
        '
        Me.lblMinimumScoreToPlaySound.BackColor = System.Drawing.SystemColors.Control
        Me.lblMinimumScoreToPlaySound.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblMinimumScoreToPlaySound.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMinimumScoreToPlaySound.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMinimumScoreToPlaySound.Location = New System.Drawing.Point(8, 56)
        Me.lblMinimumScoreToPlaySound.Name = "lblMinimumScoreToPlaySound"
        Me.lblMinimumScoreToPlaySound.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblMinimumScoreToPlaySound.Size = New System.Drawing.Size(185, 17)
        Me.lblMinimumScoreToPlaySound.TabIndex = 19
        Me.lblMinimumScoreToPlaySound.Text = "Minimum score to play sound"
        '
        'lblScoreFontSize
        '
        Me.lblScoreFontSize.BackColor = System.Drawing.SystemColors.Control
        Me.lblScoreFontSize.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblScoreFontSize.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScoreFontSize.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblScoreFontSize.Location = New System.Drawing.Point(8, 88)
        Me.lblScoreFontSize.Name = "lblScoreFontSize"
        Me.lblScoreFontSize.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblScoreFontSize.Size = New System.Drawing.Size(89, 17)
        Me.lblScoreFontSize.TabIndex = 21
        Me.lblScoreFontSize.Text = "Score Font Size"
        '
        'frm301Options
        '
        Me.frm301Options.BackColor = System.Drawing.SystemColors.Control
        Me.frm301Options.Controls.Add(Me.txtDefault301StartScore)
        Me.frm301Options.Controls.Add(Me.lblDefault301StartScore)
        Me.frm301Options.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frm301Options.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frm301Options.Location = New System.Drawing.Point(8, 232)
        Me.frm301Options.Name = "frm301Options"
        Me.frm301Options.Padding = New System.Windows.Forms.Padding(0)
        Me.frm301Options.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frm301Options.Size = New System.Drawing.Size(265, 57)
        Me.frm301Options.TabIndex = 14
        Me.frm301Options.TabStop = False
        Me.frm301Options.Text = "301 Options"
        '
        'txtDefault301StartScore
        '
        Me.txtDefault301StartScore.AcceptsReturn = True
        Me.txtDefault301StartScore.BackColor = System.Drawing.SystemColors.Window
        Me.txtDefault301StartScore.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDefault301StartScore.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDefault301StartScore.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDefault301StartScore.Location = New System.Drawing.Point(160, 24)
        Me.txtDefault301StartScore.MaxLength = 0
        Me.txtDefault301StartScore.Name = "txtDefault301StartScore"
        Me.txtDefault301StartScore.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDefault301StartScore.Size = New System.Drawing.Size(57, 22)
        Me.txtDefault301StartScore.TabIndex = 16
        Me.txtDefault301StartScore.Text = "301"
        '
        'lblDefault301StartScore
        '
        Me.lblDefault301StartScore.BackColor = System.Drawing.SystemColors.Control
        Me.lblDefault301StartScore.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDefault301StartScore.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDefault301StartScore.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDefault301StartScore.Location = New System.Drawing.Point(8, 24)
        Me.lblDefault301StartScore.Name = "lblDefault301StartScore"
        Me.lblDefault301StartScore.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDefault301StartScore.Size = New System.Drawing.Size(145, 17)
        Me.lblDefault301StartScore.TabIndex = 15
        Me.lblDefault301StartScore.Text = "Default starting score"
        Me.lblDefault301StartScore.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'frmCricketOptions
        '
        Me.frmCricketOptions.BackColor = System.Drawing.SystemColors.Control
        Me.frmCricketOptions.Controls.Add(Me.optScoringModeHighScoreWins)
        Me.frmCricketOptions.Controls.Add(Me.optScoringModeLowScoreWins)
        Me.frmCricketOptions.Controls.Add(Me.chkCutThroatCricket)
        Me.frmCricketOptions.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frmCricketOptions.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frmCricketOptions.Location = New System.Drawing.Point(8, 144)
        Me.frmCricketOptions.Name = "frmCricketOptions"
        Me.frmCricketOptions.Padding = New System.Windows.Forms.Padding(0)
        Me.frmCricketOptions.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frmCricketOptions.Size = New System.Drawing.Size(401, 81)
        Me.frmCricketOptions.TabIndex = 10
        Me.frmCricketOptions.TabStop = False
        Me.frmCricketOptions.Text = "Cricket Options"
        '
        'optScoringModeHighScoreWins
        '
        Me.optScoringModeHighScoreWins.BackColor = System.Drawing.SystemColors.Control
        Me.optScoringModeHighScoreWins.Cursor = System.Windows.Forms.Cursors.Default
        Me.optScoringModeHighScoreWins.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optScoringModeHighScoreWins.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optScoringModeHighScoreWins.Location = New System.Drawing.Point(48, 56)
        Me.optScoringModeHighScoreWins.Name = "optScoringModeHighScoreWins"
        Me.optScoringModeHighScoreWins.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optScoringModeHighScoreWins.Size = New System.Drawing.Size(329, 17)
        Me.optScoringModeHighScoreWins.TabIndex = 13
        Me.optScoringModeHighScoreWins.TabStop = True
        Me.optScoringModeHighScoreWins.Text = "Thrower receives points; high score wins"
        Me.optScoringModeHighScoreWins.UseVisualStyleBackColor = False
        '
        'optScoringModeLowScoreWins
        '
        Me.optScoringModeLowScoreWins.BackColor = System.Drawing.SystemColors.Control
        Me.optScoringModeLowScoreWins.Checked = True
        Me.optScoringModeLowScoreWins.Cursor = System.Windows.Forms.Cursors.Default
        Me.optScoringModeLowScoreWins.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optScoringModeLowScoreWins.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optScoringModeLowScoreWins.Location = New System.Drawing.Point(48, 40)
        Me.optScoringModeLowScoreWins.Name = "optScoringModeLowScoreWins"
        Me.optScoringModeLowScoreWins.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optScoringModeLowScoreWins.Size = New System.Drawing.Size(329, 17)
        Me.optScoringModeLowScoreWins.TabIndex = 12
        Me.optScoringModeLowScoreWins.TabStop = True
        Me.optScoringModeLowScoreWins.Text = "Points are scored upon opponents; low score wins"
        Me.optScoringModeLowScoreWins.UseVisualStyleBackColor = False
        '
        'chkCutThroatCricket
        '
        Me.chkCutThroatCricket.BackColor = System.Drawing.SystemColors.Control
        Me.chkCutThroatCricket.Checked = True
        Me.chkCutThroatCricket.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCutThroatCricket.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkCutThroatCricket.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCutThroatCricket.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkCutThroatCricket.Location = New System.Drawing.Point(24, 16)
        Me.chkCutThroatCricket.Name = "chkCutThroatCricket"
        Me.chkCutThroatCricket.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkCutThroatCricket.Size = New System.Drawing.Size(129, 25)
        Me.chkCutThroatCricket.TabIndex = 11
        Me.chkCutThroatCricket.Text = "Cutthroat Scoring"
        Me.chkCutThroatCricket.UseVisualStyleBackColor = False
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.chkRotateBoardClockwise)
        Me.Frame1.Controls.Add(Me.txtLastRotateHit)
        Me.Frame1.Controls.Add(Me.txtCurrentWinmauNumber)
        Me.Frame1.Controls.Add(Me.txtHitsBetweenRotate)
        Me.Frame1.Controls.Add(Me.txtTotalHits)
        Me.Frame1.Controls.Add(Me.lblLastRotateHit)
        Me.Frame1.Controls.Add(Me.lblCurrentWinmauNumber)
        Me.Frame1.Controls.Add(Me.lblHitsBetweenRotate)
        Me.Frame1.Controls.Add(Me.lblTotalHits)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(8, 8)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(401, 129)
        Me.Frame1.TabIndex = 0
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Hits and Board Rotation Parameters"
        '
        'lblLastRotateHit
        '
        Me.lblLastRotateHit.BackColor = System.Drawing.SystemColors.Control
        Me.lblLastRotateHit.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLastRotateHit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastRotateHit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLastRotateHit.Location = New System.Drawing.Point(16, 96)
        Me.lblLastRotateHit.Name = "lblLastRotateHit"
        Me.lblLastRotateHit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLastRotateHit.Size = New System.Drawing.Size(137, 17)
        Me.lblLastRotateHit.TabIndex = 8
        Me.lblLastRotateHit.Text = "Last Rotate Hit Value"
        Me.lblLastRotateHit.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblCurrentWinmauNumber
        '
        Me.lblCurrentWinmauNumber.BackColor = System.Drawing.SystemColors.Control
        Me.lblCurrentWinmauNumber.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCurrentWinmauNumber.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentWinmauNumber.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCurrentWinmauNumber.Location = New System.Drawing.Point(8, 72)
        Me.lblCurrentWinmauNumber.Name = "lblCurrentWinmauNumber"
        Me.lblCurrentWinmauNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCurrentWinmauNumber.Size = New System.Drawing.Size(145, 17)
        Me.lblCurrentWinmauNumber.TabIndex = 6
        Me.lblCurrentWinmauNumber.Text = "Current Winmau Number"
        Me.lblCurrentWinmauNumber.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblHitsBetweenRotate
        '
        Me.lblHitsBetweenRotate.BackColor = System.Drawing.SystemColors.Control
        Me.lblHitsBetweenRotate.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblHitsBetweenRotate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHitsBetweenRotate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblHitsBetweenRotate.Location = New System.Drawing.Point(8, 48)
        Me.lblHitsBetweenRotate.Name = "lblHitsBetweenRotate"
        Me.lblHitsBetweenRotate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblHitsBetweenRotate.Size = New System.Drawing.Size(145, 17)
        Me.lblHitsBetweenRotate.TabIndex = 3
        Me.lblHitsBetweenRotate.Text = "Hits between Rotations"
        Me.lblHitsBetweenRotate.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTotalHits
        '
        Me.lblTotalHits.BackColor = System.Drawing.SystemColors.Control
        Me.lblTotalHits.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTotalHits.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalHits.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTotalHits.Location = New System.Drawing.Point(8, 24)
        Me.lblTotalHits.Name = "lblTotalHits"
        Me.lblTotalHits.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTotalHits.Size = New System.Drawing.Size(145, 17)
        Me.lblTotalHits.TabIndex = 1
        Me.lblTotalHits.Text = "Total Hits"
        Me.lblTotalHits.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(285, 404)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(41, 33)
        Me.PictureBox1.TabIndex = 31
        Me.PictureBox1.TabStop = False
        '
        'frmOptions
        '
        Me.AcceptButton = Me.cmdClose
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(417, 476)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.cmdDefaults)
        Me.Controls.Add(Me.fraButtons)
        Me.Controls.Add(Me.fraOtherOptions)
        Me.Controls.Add(Me.frm301Options)
        Me.Controls.Add(Me.frmCricketOptions)
        Me.Controls.Add(Me.Frame1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(149, 132)
        Me.Name = "frmOptions"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Edit Options"
        Me.fraButtons.ResumeLayout(False)
        Me.fraOtherOptions.ResumeLayout(False)
        Me.fraOtherOptions.PerformLayout()
        Me.frm301Options.ResumeLayout(False)
        Me.frm301Options.PerformLayout()
        Me.frmCricketOptions.ResumeLayout(False)
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
#End Region
End Class
