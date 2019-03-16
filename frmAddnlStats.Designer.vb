Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()> Partial Class frmAddnlStats
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
    Public WithEvents cmdOK As System.Windows.Forms.Button
    Public WithEvents cmdSelectDate As System.Windows.Forms.Button
    Public WithEvents txtDayOfMonth As System.Windows.Forms.TextBox
    Public WithEvents cboYear As System.Windows.Forms.ComboBox
    Public WithEvents cboMonth As System.Windows.Forms.ComboBox
    Public WithEvents cboGameDates As System.Windows.Forms.ComboBox
    Public WithEvents lblValidDateRange As System.Windows.Forms.Label
    Public WithEvents fraControls As System.Windows.Forms.Panel
    Public WithEvents objCalendar As System.Windows.Forms.DateTimePicker
    Public WithEvents lstMeanScorePerThrowPerDay As System.Windows.Forms.ListBox
    Public WithEvents lstMeanScorePerThrow As System.Windows.Forms.ListBox
    Public WithEvents lstHighestScoringFirstTurn As System.Windows.Forms.ListBox
    Public WithEvents lst301MostUntilDoubleIn As System.Windows.Forms.ListBox
    Public WithEvents lst301GamesLostWithoutDoublingIn As System.Windows.Forms.ListBox
    Public WithEvents lbl301MostUntilDoubleIn As System.Windows.Forms.Label
    Public WithEvents lbl301Stats As System.Windows.Forms.Label
    Public WithEvents lbl301GamesLostWithoutDoublingIn As System.Windows.Forms.Label
    Public WithEvents fra301Stats As System.Windows.Forms.Panel
    Public WithEvents lstGolfAverageGameScore As System.Windows.Forms.ListBox
    Public WithEvents lstGolfHighestGameScore As System.Windows.Forms.ListBox
    Public WithEvents lstGolfLowestGameScore As System.Windows.Forms.ListBox
    Public WithEvents lblGolfAverageGameScore As System.Windows.Forms.Label
    Public WithEvents lblGolfHighestGameScore As System.Windows.Forms.Label
    Public WithEvents lblGolfStats As System.Windows.Forms.Label
    Public WithEvents lblGolfLowestGameScore As System.Windows.Forms.Label
    Public WithEvents fraGolfStats As System.Windows.Forms.Panel
    Public WithEvents chkReverseSort As System.Windows.Forms.CheckBox
    Public WithEvents cboStatsToShow As System.Windows.Forms.ComboBox
    Public WithEvents lstLongestWinningGame As System.Windows.Forms.ListBox
    Public WithEvents lstLongestScoringDrought As System.Windows.Forms.ListBox
    Public WithEvents lstShortestWinningGame As System.Windows.Forms.ListBox
    Public WithEvents lstPlayers As System.Windows.Forms.ListBox
    Public WithEvents lstHighScoreTurn As System.Windows.Forms.ListBox
    Public WithEvents lblMeanScorePerThrowPerDay As System.Windows.Forms.Label
    Public WithEvents lblMeanScorePerThrow As System.Windows.Forms.Label
    Public WithEvents lblHighestScoringFirstTurn As System.Windows.Forms.Label
    Public WithEvents lblLongestWinningGameLength As System.Windows.Forms.Label
    Public WithEvents lblLongestScoringDrought As System.Windows.Forms.Label
    Public WithEvents lblShortestGameLength As System.Windows.Forms.Label
    Public WithEvents lblPlayer As System.Windows.Forms.Label
    Public WithEvents lblHighScoreTurn As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lbl301MostUntilDoubleIn = New System.Windows.Forms.Label()
        Me.lbl301GamesLostWithoutDoublingIn = New System.Windows.Forms.Label()
        Me.lblGolfAverageGameScore = New System.Windows.Forms.Label()
        Me.lblGolfHighestGameScore = New System.Windows.Forms.Label()
        Me.lblGolfLowestGameScore = New System.Windows.Forms.Label()
        Me.lblMeanScorePerThrowPerDay = New System.Windows.Forms.Label()
        Me.lblMeanScorePerThrow = New System.Windows.Forms.Label()
        Me.lblHighestScoringFirstTurn = New System.Windows.Forms.Label()
        Me.lblLongestWinningGameLength = New System.Windows.Forms.Label()
        Me.lblLongestScoringDrought = New System.Windows.Forms.Label()
        Me.lblShortestGameLength = New System.Windows.Forms.Label()
        Me.lblPlayer = New System.Windows.Forms.Label()
        Me.lblHighScoreTurn = New System.Windows.Forms.Label()
        Me.fraControls = New System.Windows.Forms.Panel()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.cmdSelectDate = New System.Windows.Forms.Button()
        Me.txtDayOfMonth = New System.Windows.Forms.TextBox()
        Me.cboYear = New System.Windows.Forms.ComboBox()
        Me.cboMonth = New System.Windows.Forms.ComboBox()
        Me.cboGameDates = New System.Windows.Forms.ComboBox()
        Me.lblValidDateRange = New System.Windows.Forms.Label()
        Me.objCalendar = New System.Windows.Forms.DateTimePicker()
        Me.lstMeanScorePerThrowPerDay = New System.Windows.Forms.ListBox()
        Me.lstMeanScorePerThrow = New System.Windows.Forms.ListBox()
        Me.lstHighestScoringFirstTurn = New System.Windows.Forms.ListBox()
        Me.fra301Stats = New System.Windows.Forms.Panel()
        Me.lst301MostUntilDoubleIn = New System.Windows.Forms.ListBox()
        Me.lst301GamesLostWithoutDoublingIn = New System.Windows.Forms.ListBox()
        Me.lbl301Stats = New System.Windows.Forms.Label()
        Me.fraGolfStats = New System.Windows.Forms.Panel()
        Me.lstGolfAverageGameScore = New System.Windows.Forms.ListBox()
        Me.lstGolfHighestGameScore = New System.Windows.Forms.ListBox()
        Me.lstGolfLowestGameScore = New System.Windows.Forms.ListBox()
        Me.lblGolfStats = New System.Windows.Forms.Label()
        Me.chkReverseSort = New System.Windows.Forms.CheckBox()
        Me.cboStatsToShow = New System.Windows.Forms.ComboBox()
        Me.lstLongestWinningGame = New System.Windows.Forms.ListBox()
        Me.lstLongestScoringDrought = New System.Windows.Forms.ListBox()
        Me.lstShortestWinningGame = New System.Windows.Forms.ListBox()
        Me.lstPlayers = New System.Windows.Forms.ListBox()
        Me.lstHighScoreTurn = New System.Windows.Forms.ListBox()
        Me.fraControls.SuspendLayout()
        Me.fra301Stats.SuspendLayout()
        Me.fraGolfStats.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl301MostUntilDoubleIn
        '
        Me.lbl301MostUntilDoubleIn.BackColor = System.Drawing.SystemColors.Control
        Me.lbl301MostUntilDoubleIn.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl301MostUntilDoubleIn.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.lbl301MostUntilDoubleIn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl301MostUntilDoubleIn.Location = New System.Drawing.Point(8, 24)
        Me.lbl301MostUntilDoubleIn.Name = "lbl301MostUntilDoubleIn"
        Me.lbl301MostUntilDoubleIn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl301MostUntilDoubleIn.Size = New System.Drawing.Size(57, 65)
        Me.lbl301MostUntilDoubleIn.TabIndex = 20
        Me.lbl301MostUntilDoubleIn.Text = "Most Darts Until Double In"
        Me.lbl301MostUntilDoubleIn.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.lbl301MostUntilDoubleIn, "Click here to resort")
        '
        'lbl301GamesLostWithoutDoublingIn
        '
        Me.lbl301GamesLostWithoutDoublingIn.BackColor = System.Drawing.SystemColors.Control
        Me.lbl301GamesLostWithoutDoublingIn.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl301GamesLostWithoutDoublingIn.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.lbl301GamesLostWithoutDoublingIn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl301GamesLostWithoutDoublingIn.Location = New System.Drawing.Point(64, 32)
        Me.lbl301GamesLostWithoutDoublingIn.Name = "lbl301GamesLostWithoutDoublingIn"
        Me.lbl301GamesLostWithoutDoublingIn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl301GamesLostWithoutDoublingIn.Size = New System.Drawing.Size(73, 49)
        Me.lbl301GamesLostWithoutDoublingIn.TabIndex = 22
        Me.lbl301GamesLostWithoutDoublingIn.Text = "Games Lost Without Doubling In"
        Me.lbl301GamesLostWithoutDoublingIn.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.lbl301GamesLostWithoutDoublingIn, "aka ""Linked"" Games")
        '
        'lblGolfAverageGameScore
        '
        Me.lblGolfAverageGameScore.BackColor = System.Drawing.SystemColors.Control
        Me.lblGolfAverageGameScore.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblGolfAverageGameScore.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.lblGolfAverageGameScore.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblGolfAverageGameScore.Location = New System.Drawing.Point(136, 32)
        Me.lblGolfAverageGameScore.Name = "lblGolfAverageGameScore"
        Me.lblGolfAverageGameScore.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblGolfAverageGameScore.Size = New System.Drawing.Size(57, 57)
        Me.lblGolfAverageGameScore.TabIndex = 30
        Me.lblGolfAverageGameScore.Text = "Average Game Score"
        Me.lblGolfAverageGameScore.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.lblGolfAverageGameScore, "Click here to resort")
        '
        'lblGolfHighestGameScore
        '
        Me.lblGolfHighestGameScore.BackColor = System.Drawing.SystemColors.Control
        Me.lblGolfHighestGameScore.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblGolfHighestGameScore.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.lblGolfHighestGameScore.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblGolfHighestGameScore.Location = New System.Drawing.Point(69, 32)
        Me.lblGolfHighestGameScore.Name = "lblGolfHighestGameScore"
        Me.lblGolfHighestGameScore.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblGolfHighestGameScore.Size = New System.Drawing.Size(58, 57)
        Me.lblGolfHighestGameScore.TabIndex = 28
        Me.lblGolfHighestGameScore.Text = "Highest Scoring Game"
        Me.lblGolfHighestGameScore.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.lblGolfHighestGameScore, "Click here to resort")
        '
        'lblGolfLowestGameScore
        '
        Me.lblGolfLowestGameScore.BackColor = System.Drawing.SystemColors.Control
        Me.lblGolfLowestGameScore.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblGolfLowestGameScore.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.lblGolfLowestGameScore.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblGolfLowestGameScore.Location = New System.Drawing.Point(8, 32)
        Me.lblGolfLowestGameScore.Name = "lblGolfLowestGameScore"
        Me.lblGolfLowestGameScore.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblGolfLowestGameScore.Size = New System.Drawing.Size(57, 57)
        Me.lblGolfLowestGameScore.TabIndex = 26
        Me.lblGolfLowestGameScore.Text = "Lowest Scoring Game"
        Me.lblGolfLowestGameScore.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.lblGolfLowestGameScore, "Click here to resort")
        '
        'lblMeanScorePerThrowPerDay
        '
        Me.lblMeanScorePerThrowPerDay.BackColor = System.Drawing.SystemColors.Control
        Me.lblMeanScorePerThrowPerDay.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblMeanScorePerThrowPerDay.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.lblMeanScorePerThrowPerDay.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMeanScorePerThrowPerDay.Location = New System.Drawing.Point(472, 16)
        Me.lblMeanScorePerThrowPerDay.Name = "lblMeanScorePerThrowPerDay"
        Me.lblMeanScorePerThrowPerDay.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblMeanScorePerThrowPerDay.Size = New System.Drawing.Size(65, 73)
        Me.lblMeanScorePerThrowPerDay.TabIndex = 16
        Me.lblMeanScorePerThrowPerDay.Text = "Mean Score Per Throw Per Day"
        Me.lblMeanScorePerThrowPerDay.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.lblMeanScorePerThrowPerDay, "Click here to resort")
        '
        'lblMeanScorePerThrow
        '
        Me.lblMeanScorePerThrow.BackColor = System.Drawing.SystemColors.Control
        Me.lblMeanScorePerThrow.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblMeanScorePerThrow.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.lblMeanScorePerThrow.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMeanScorePerThrow.Location = New System.Drawing.Point(224, 24)
        Me.lblMeanScorePerThrow.Name = "lblMeanScorePerThrow"
        Me.lblMeanScorePerThrow.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblMeanScorePerThrow.Size = New System.Drawing.Size(49, 65)
        Me.lblMeanScorePerThrow.TabIndex = 8
        Me.lblMeanScorePerThrow.Text = "Mean Score per Throw"
        Me.lblMeanScorePerThrow.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.lblMeanScorePerThrow, "Mean score per throw overall (click here to resort)")
        '
        'lblHighestScoringFirstTurn
        '
        Me.lblHighestScoringFirstTurn.BackColor = System.Drawing.SystemColors.Control
        Me.lblHighestScoringFirstTurn.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblHighestScoringFirstTurn.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.lblHighestScoringFirstTurn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblHighestScoringFirstTurn.Location = New System.Drawing.Point(165, 24)
        Me.lblHighestScoringFirstTurn.Name = "lblHighestScoringFirstTurn"
        Me.lblHighestScoringFirstTurn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblHighestScoringFirstTurn.Size = New System.Drawing.Size(60, 65)
        Me.lblHighestScoringFirstTurn.TabIndex = 6
        Me.lblHighestScoringFirstTurn.Text = "Highest Scoring First Turn"
        Me.lblHighestScoringFirstTurn.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.lblHighestScoringFirstTurn, "Click here to resort")
        '
        'lblLongestWinningGameLength
        '
        Me.lblLongestWinningGameLength.BackColor = System.Drawing.SystemColors.Control
        Me.lblLongestWinningGameLength.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLongestWinningGameLength.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.lblLongestWinningGameLength.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLongestWinningGameLength.Location = New System.Drawing.Point(408, 8)
        Me.lblLongestWinningGameLength.Name = "lblLongestWinningGameLength"
        Me.lblLongestWinningGameLength.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLongestWinningGameLength.Size = New System.Drawing.Size(57, 81)
        Me.lblLongestWinningGameLength.TabIndex = 14
        Me.lblLongestWinningGameLength.Text = "Longest Winning Game Length (throws)"
        Me.lblLongestWinningGameLength.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.lblLongestWinningGameLength, "Click here to resort")
        '
        'lblLongestScoringDrought
        '
        Me.lblLongestScoringDrought.BackColor = System.Drawing.SystemColors.Control
        Me.lblLongestScoringDrought.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLongestScoringDrought.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.lblLongestScoringDrought.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLongestScoringDrought.Location = New System.Drawing.Point(280, 24)
        Me.lblLongestScoringDrought.Name = "lblLongestScoringDrought"
        Me.lblLongestScoringDrought.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLongestScoringDrought.Size = New System.Drawing.Size(57, 65)
        Me.lblLongestScoringDrought.TabIndex = 10
        Me.lblLongestScoringDrought.Text = "Longest Scoring Drought (throws)"
        Me.lblLongestScoringDrought.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.lblLongestScoringDrought, "Longest number of throws without any score (click here to resort)")
        '
        'lblShortestGameLength
        '
        Me.lblShortestGameLength.BackColor = System.Drawing.SystemColors.Control
        Me.lblShortestGameLength.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblShortestGameLength.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.lblShortestGameLength.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblShortestGameLength.Location = New System.Drawing.Point(344, 8)
        Me.lblShortestGameLength.Name = "lblShortestGameLength"
        Me.lblShortestGameLength.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblShortestGameLength.Size = New System.Drawing.Size(57, 81)
        Me.lblShortestGameLength.TabIndex = 12
        Me.lblShortestGameLength.Text = "Shortest Winning Game Length (throws)"
        Me.lblShortestGameLength.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.lblShortestGameLength, "Click here to resort")
        '
        'lblPlayer
        '
        Me.lblPlayer.BackColor = System.Drawing.SystemColors.Control
        Me.lblPlayer.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPlayer.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.lblPlayer.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPlayer.Location = New System.Drawing.Point(24, 64)
        Me.lblPlayer.Name = "lblPlayer"
        Me.lblPlayer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPlayer.Size = New System.Drawing.Size(57, 17)
        Me.lblPlayer.TabIndex = 2
        Me.lblPlayer.Text = "Player"
        Me.lblPlayer.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.lblPlayer, "Click here to resort")
        '
        'lblHighScoreTurn
        '
        Me.lblHighScoreTurn.BackColor = System.Drawing.SystemColors.Control
        Me.lblHighScoreTurn.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblHighScoreTurn.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.lblHighScoreTurn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblHighScoreTurn.Location = New System.Drawing.Point(109, 30)
        Me.lblHighScoreTurn.Name = "lblHighScoreTurn"
        Me.lblHighScoreTurn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblHighScoreTurn.Size = New System.Drawing.Size(58, 57)
        Me.lblHighScoreTurn.TabIndex = 4
        Me.lblHighScoreTurn.Text = "Highest Scoring Turn"
        Me.lblHighScoreTurn.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.lblHighScoreTurn, "Click here to resort")
        '
        'fraControls
        '
        Me.fraControls.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fraControls.BackColor = System.Drawing.SystemColors.Control
        Me.fraControls.Controls.Add(Me.cmdOK)
        Me.fraControls.Controls.Add(Me.cmdSelectDate)
        Me.fraControls.Controls.Add(Me.txtDayOfMonth)
        Me.fraControls.Controls.Add(Me.cboYear)
        Me.fraControls.Controls.Add(Me.cboMonth)
        Me.fraControls.Controls.Add(Me.cboGameDates)
        Me.fraControls.Controls.Add(Me.lblValidDateRange)
        Me.fraControls.Cursor = System.Windows.Forms.Cursors.Default
        Me.fraControls.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.fraControls.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraControls.Location = New System.Drawing.Point(8, 392)
        Me.fraControls.Name = "fraControls"
        Me.fraControls.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraControls.Size = New System.Drawing.Size(601, 73)
        Me.fraControls.TabIndex = 33
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdOK.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Location = New System.Drawing.Point(8, 16)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOK.Size = New System.Drawing.Size(57, 25)
        Me.cmdOK.TabIndex = 39
        Me.cmdOK.Text = "&Close"
        Me.cmdOK.UseVisualStyleBackColor = False
        '
        'cmdSelectDate
        '
        Me.cmdSelectDate.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSelectDate.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSelectDate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.cmdSelectDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSelectDate.Location = New System.Drawing.Point(176, 16)
        Me.cmdSelectDate.Name = "cmdSelectDate"
        Me.cmdSelectDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSelectDate.Size = New System.Drawing.Size(105, 25)
        Me.cmdSelectDate.TabIndex = 38
        Me.cmdSelectDate.Text = "&Show Calendar"
        Me.cmdSelectDate.UseVisualStyleBackColor = False
        '
        'txtDayOfMonth
        '
        Me.txtDayOfMonth.AcceptsReturn = True
        Me.txtDayOfMonth.BackColor = System.Drawing.SystemColors.Window
        Me.txtDayOfMonth.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDayOfMonth.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.txtDayOfMonth.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDayOfMonth.Location = New System.Drawing.Point(488, 18)
        Me.txtDayOfMonth.MaxLength = 0
        Me.txtDayOfMonth.Name = "txtDayOfMonth"
        Me.txtDayOfMonth.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDayOfMonth.Size = New System.Drawing.Size(33, 20)
        Me.txtDayOfMonth.TabIndex = 37
        Me.txtDayOfMonth.Text = "1"
        '
        'cboYear
        '
        Me.cboYear.BackColor = System.Drawing.SystemColors.Window
        Me.cboYear.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboYear.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.cboYear.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboYear.Location = New System.Drawing.Point(320, 18)
        Me.cboYear.Name = "cboYear"
        Me.cboYear.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboYear.Size = New System.Drawing.Size(73, 22)
        Me.cboYear.TabIndex = 36
        '
        'cboMonth
        '
        Me.cboMonth.BackColor = System.Drawing.SystemColors.Window
        Me.cboMonth.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMonth.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.cboMonth.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboMonth.Location = New System.Drawing.Point(400, 18)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboMonth.Size = New System.Drawing.Size(81, 22)
        Me.cboMonth.TabIndex = 35
        '
        'cboGameDates
        '
        Me.cboGameDates.BackColor = System.Drawing.SystemColors.Window
        Me.cboGameDates.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboGameDates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGameDates.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.cboGameDates.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboGameDates.Location = New System.Drawing.Point(320, 50)
        Me.cboGameDates.Name = "cboGameDates"
        Me.cboGameDates.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboGameDates.Size = New System.Drawing.Size(137, 22)
        Me.cboGameDates.TabIndex = 34
        '
        'lblValidDateRange
        '
        Me.lblValidDateRange.BackColor = System.Drawing.SystemColors.Control
        Me.lblValidDateRange.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblValidDateRange.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.lblValidDateRange.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblValidDateRange.Location = New System.Drawing.Point(160, 53)
        Me.lblValidDateRange.Name = "lblValidDateRange"
        Me.lblValidDateRange.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblValidDateRange.Size = New System.Drawing.Size(153, 17)
        Me.lblValidDateRange.TabIndex = 40
        Me.lblValidDateRange.Text = "Jump to date (max 600 listed):"
        '
        'objCalendar
        '
        Me.objCalendar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.objCalendar.Location = New System.Drawing.Point(615, 399)
        Me.objCalendar.Name = "objCalendar"
        Me.objCalendar.Size = New System.Drawing.Size(225, 23)
        Me.objCalendar.TabIndex = 32
        Me.objCalendar.Visible = False
        '
        'lstMeanScorePerThrowPerDay
        '
        Me.lstMeanScorePerThrowPerDay.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstMeanScorePerThrowPerDay.BackColor = System.Drawing.SystemColors.Window
        Me.lstMeanScorePerThrowPerDay.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstMeanScorePerThrowPerDay.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.lstMeanScorePerThrowPerDay.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstMeanScorePerThrowPerDay.ItemHeight = 14
        Me.lstMeanScorePerThrowPerDay.Location = New System.Drawing.Point(475, 96)
        Me.lstMeanScorePerThrowPerDay.Name = "lstMeanScorePerThrowPerDay"
        Me.lstMeanScorePerThrowPerDay.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstMeanScorePerThrowPerDay.Size = New System.Drawing.Size(57, 284)
        Me.lstMeanScorePerThrowPerDay.TabIndex = 17
        '
        'lstMeanScorePerThrow
        '
        Me.lstMeanScorePerThrow.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstMeanScorePerThrow.BackColor = System.Drawing.SystemColors.Window
        Me.lstMeanScorePerThrow.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstMeanScorePerThrow.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.lstMeanScorePerThrow.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstMeanScorePerThrow.ItemHeight = 14
        Me.lstMeanScorePerThrow.Location = New System.Drawing.Point(224, 96)
        Me.lstMeanScorePerThrow.Name = "lstMeanScorePerThrow"
        Me.lstMeanScorePerThrow.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstMeanScorePerThrow.Size = New System.Drawing.Size(49, 284)
        Me.lstMeanScorePerThrow.TabIndex = 9
        '
        'lstHighestScoringFirstTurn
        '
        Me.lstHighestScoringFirstTurn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstHighestScoringFirstTurn.BackColor = System.Drawing.SystemColors.Window
        Me.lstHighestScoringFirstTurn.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstHighestScoringFirstTurn.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.lstHighestScoringFirstTurn.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstHighestScoringFirstTurn.ItemHeight = 14
        Me.lstHighestScoringFirstTurn.Location = New System.Drawing.Point(168, 96)
        Me.lstHighestScoringFirstTurn.Name = "lstHighestScoringFirstTurn"
        Me.lstHighestScoringFirstTurn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstHighestScoringFirstTurn.Size = New System.Drawing.Size(49, 284)
        Me.lstHighestScoringFirstTurn.TabIndex = 7
        '
        'fra301Stats
        '
        Me.fra301Stats.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fra301Stats.BackColor = System.Drawing.SystemColors.Control
        Me.fra301Stats.Controls.Add(Me.lst301MostUntilDoubleIn)
        Me.fra301Stats.Controls.Add(Me.lst301GamesLostWithoutDoublingIn)
        Me.fra301Stats.Controls.Add(Me.lbl301MostUntilDoubleIn)
        Me.fra301Stats.Controls.Add(Me.lbl301Stats)
        Me.fra301Stats.Controls.Add(Me.lbl301GamesLostWithoutDoublingIn)
        Me.fra301Stats.Cursor = System.Windows.Forms.Cursors.Default
        Me.fra301Stats.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.fra301Stats.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fra301Stats.Location = New System.Drawing.Point(544, 0)
        Me.fra301Stats.Name = "fra301Stats"
        Me.fra301Stats.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fra301Stats.Size = New System.Drawing.Size(137, 393)
        Me.fra301Stats.TabIndex = 18
        Me.fra301Stats.Text = "Golf Stats"
        '
        'lst301MostUntilDoubleIn
        '
        Me.lst301MostUntilDoubleIn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lst301MostUntilDoubleIn.BackColor = System.Drawing.SystemColors.Window
        Me.lst301MostUntilDoubleIn.Cursor = System.Windows.Forms.Cursors.Default
        Me.lst301MostUntilDoubleIn.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.lst301MostUntilDoubleIn.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lst301MostUntilDoubleIn.ItemHeight = 14
        Me.lst301MostUntilDoubleIn.Location = New System.Drawing.Point(8, 96)
        Me.lst301MostUntilDoubleIn.Name = "lst301MostUntilDoubleIn"
        Me.lst301MostUntilDoubleIn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lst301MostUntilDoubleIn.Size = New System.Drawing.Size(57, 284)
        Me.lst301MostUntilDoubleIn.TabIndex = 21
        '
        'lst301GamesLostWithoutDoublingIn
        '
        Me.lst301GamesLostWithoutDoublingIn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lst301GamesLostWithoutDoublingIn.BackColor = System.Drawing.SystemColors.Window
        Me.lst301GamesLostWithoutDoublingIn.Cursor = System.Windows.Forms.Cursors.Default
        Me.lst301GamesLostWithoutDoublingIn.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.lst301GamesLostWithoutDoublingIn.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lst301GamesLostWithoutDoublingIn.ItemHeight = 14
        Me.lst301GamesLostWithoutDoublingIn.Location = New System.Drawing.Point(72, 96)
        Me.lst301GamesLostWithoutDoublingIn.Name = "lst301GamesLostWithoutDoublingIn"
        Me.lst301GamesLostWithoutDoublingIn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lst301GamesLostWithoutDoublingIn.Size = New System.Drawing.Size(57, 284)
        Me.lst301GamesLostWithoutDoublingIn.TabIndex = 23
        '
        'lbl301Stats
        '
        Me.lbl301Stats.BackColor = System.Drawing.SystemColors.Control
        Me.lbl301Stats.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl301Stats.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.lbl301Stats.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl301Stats.Location = New System.Drawing.Point(8, 0)
        Me.lbl301Stats.Name = "lbl301Stats"
        Me.lbl301Stats.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl301Stats.Size = New System.Drawing.Size(121, 25)
        Me.lbl301Stats.TabIndex = 19
        Me.lbl301Stats.Text = "-- 301 Stats --"
        '
        'fraGolfStats
        '
        Me.fraGolfStats.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fraGolfStats.BackColor = System.Drawing.SystemColors.Control
        Me.fraGolfStats.Controls.Add(Me.lstGolfAverageGameScore)
        Me.fraGolfStats.Controls.Add(Me.lstGolfHighestGameScore)
        Me.fraGolfStats.Controls.Add(Me.lstGolfLowestGameScore)
        Me.fraGolfStats.Controls.Add(Me.lblGolfAverageGameScore)
        Me.fraGolfStats.Controls.Add(Me.lblGolfHighestGameScore)
        Me.fraGolfStats.Controls.Add(Me.lblGolfStats)
        Me.fraGolfStats.Controls.Add(Me.lblGolfLowestGameScore)
        Me.fraGolfStats.Cursor = System.Windows.Forms.Cursors.Default
        Me.fraGolfStats.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.fraGolfStats.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraGolfStats.Location = New System.Drawing.Point(680, 0)
        Me.fraGolfStats.Name = "fraGolfStats"
        Me.fraGolfStats.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraGolfStats.Size = New System.Drawing.Size(201, 393)
        Me.fraGolfStats.TabIndex = 24
        Me.fraGolfStats.Text = "Golf Stats"
        '
        'lstGolfAverageGameScore
        '
        Me.lstGolfAverageGameScore.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstGolfAverageGameScore.BackColor = System.Drawing.SystemColors.Window
        Me.lstGolfAverageGameScore.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstGolfAverageGameScore.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.lstGolfAverageGameScore.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstGolfAverageGameScore.ItemHeight = 14
        Me.lstGolfAverageGameScore.Location = New System.Drawing.Point(136, 96)
        Me.lstGolfAverageGameScore.Name = "lstGolfAverageGameScore"
        Me.lstGolfAverageGameScore.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstGolfAverageGameScore.Size = New System.Drawing.Size(57, 284)
        Me.lstGolfAverageGameScore.TabIndex = 31
        '
        'lstGolfHighestGameScore
        '
        Me.lstGolfHighestGameScore.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstGolfHighestGameScore.BackColor = System.Drawing.SystemColors.Window
        Me.lstGolfHighestGameScore.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstGolfHighestGameScore.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.lstGolfHighestGameScore.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstGolfHighestGameScore.ItemHeight = 14
        Me.lstGolfHighestGameScore.Location = New System.Drawing.Point(72, 96)
        Me.lstGolfHighestGameScore.Name = "lstGolfHighestGameScore"
        Me.lstGolfHighestGameScore.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstGolfHighestGameScore.Size = New System.Drawing.Size(57, 284)
        Me.lstGolfHighestGameScore.TabIndex = 29
        '
        'lstGolfLowestGameScore
        '
        Me.lstGolfLowestGameScore.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstGolfLowestGameScore.BackColor = System.Drawing.SystemColors.Window
        Me.lstGolfLowestGameScore.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstGolfLowestGameScore.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.lstGolfLowestGameScore.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstGolfLowestGameScore.ItemHeight = 14
        Me.lstGolfLowestGameScore.Location = New System.Drawing.Point(8, 96)
        Me.lstGolfLowestGameScore.Name = "lstGolfLowestGameScore"
        Me.lstGolfLowestGameScore.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstGolfLowestGameScore.Size = New System.Drawing.Size(57, 284)
        Me.lstGolfLowestGameScore.TabIndex = 27
        '
        'lblGolfStats
        '
        Me.lblGolfStats.BackColor = System.Drawing.SystemColors.Control
        Me.lblGolfStats.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblGolfStats.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.lblGolfStats.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblGolfStats.Location = New System.Drawing.Point(40, 0)
        Me.lblGolfStats.Name = "lblGolfStats"
        Me.lblGolfStats.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblGolfStats.Size = New System.Drawing.Size(137, 25)
        Me.lblGolfStats.TabIndex = 25
        Me.lblGolfStats.Text = "-- Golf Stats --"
        '
        'chkReverseSort
        '
        Me.chkReverseSort.BackColor = System.Drawing.SystemColors.Control
        Me.chkReverseSort.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkReverseSort.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.chkReverseSort.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkReverseSort.Location = New System.Drawing.Point(8, 32)
        Me.chkReverseSort.Name = "chkReverseSort"
        Me.chkReverseSort.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkReverseSort.Size = New System.Drawing.Size(89, 17)
        Me.chkReverseSort.TabIndex = 1
        Me.chkReverseSort.Text = "&Reverse Sort"
        Me.chkReverseSort.UseVisualStyleBackColor = False
        '
        'cboStatsToShow
        '
        Me.cboStatsToShow.BackColor = System.Drawing.SystemColors.Window
        Me.cboStatsToShow.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboStatsToShow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatsToShow.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.cboStatsToShow.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboStatsToShow.Location = New System.Drawing.Point(8, 8)
        Me.cboStatsToShow.Name = "cboStatsToShow"
        Me.cboStatsToShow.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboStatsToShow.Size = New System.Drawing.Size(89, 22)
        Me.cboStatsToShow.TabIndex = 0
        '
        'lstLongestWinningGame
        '
        Me.lstLongestWinningGame.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstLongestWinningGame.BackColor = System.Drawing.SystemColors.Window
        Me.lstLongestWinningGame.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstLongestWinningGame.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.lstLongestWinningGame.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstLongestWinningGame.ItemHeight = 14
        Me.lstLongestWinningGame.Location = New System.Drawing.Point(408, 96)
        Me.lstLongestWinningGame.Name = "lstLongestWinningGame"
        Me.lstLongestWinningGame.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstLongestWinningGame.Size = New System.Drawing.Size(57, 284)
        Me.lstLongestWinningGame.TabIndex = 15
        '
        'lstLongestScoringDrought
        '
        Me.lstLongestScoringDrought.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstLongestScoringDrought.BackColor = System.Drawing.SystemColors.Window
        Me.lstLongestScoringDrought.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstLongestScoringDrought.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.lstLongestScoringDrought.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstLongestScoringDrought.ItemHeight = 14
        Me.lstLongestScoringDrought.Location = New System.Drawing.Point(280, 96)
        Me.lstLongestScoringDrought.Name = "lstLongestScoringDrought"
        Me.lstLongestScoringDrought.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstLongestScoringDrought.Size = New System.Drawing.Size(57, 284)
        Me.lstLongestScoringDrought.TabIndex = 11
        '
        'lstShortestWinningGame
        '
        Me.lstShortestWinningGame.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstShortestWinningGame.BackColor = System.Drawing.SystemColors.Window
        Me.lstShortestWinningGame.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstShortestWinningGame.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.lstShortestWinningGame.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstShortestWinningGame.ItemHeight = 14
        Me.lstShortestWinningGame.Location = New System.Drawing.Point(344, 96)
        Me.lstShortestWinningGame.Name = "lstShortestWinningGame"
        Me.lstShortestWinningGame.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstShortestWinningGame.Size = New System.Drawing.Size(57, 284)
        Me.lstShortestWinningGame.TabIndex = 13
        '
        'lstPlayers
        '
        Me.lstPlayers.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstPlayers.BackColor = System.Drawing.SystemColors.Window
        Me.lstPlayers.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstPlayers.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.lstPlayers.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstPlayers.ItemHeight = 14
        Me.lstPlayers.Location = New System.Drawing.Point(8, 96)
        Me.lstPlayers.Name = "lstPlayers"
        Me.lstPlayers.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstPlayers.Size = New System.Drawing.Size(97, 284)
        Me.lstPlayers.TabIndex = 3
        '
        'lstHighScoreTurn
        '
        Me.lstHighScoreTurn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstHighScoreTurn.BackColor = System.Drawing.SystemColors.Window
        Me.lstHighScoreTurn.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstHighScoreTurn.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.lstHighScoreTurn.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstHighScoreTurn.ItemHeight = 14
        Me.lstHighScoreTurn.Location = New System.Drawing.Point(112, 96)
        Me.lstHighScoreTurn.Name = "lstHighScoreTurn"
        Me.lstHighScoreTurn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstHighScoreTurn.Size = New System.Drawing.Size(49, 284)
        Me.lstHighScoreTurn.TabIndex = 5
        '
        'frmAddnlStats
        '
        Me.AcceptButton = Me.cmdOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.cmdOK
        Me.ClientSize = New System.Drawing.Size(889, 475)
        Me.Controls.Add(Me.fraControls)
        Me.Controls.Add(Me.objCalendar)
        Me.Controls.Add(Me.lstMeanScorePerThrowPerDay)
        Me.Controls.Add(Me.lstMeanScorePerThrow)
        Me.Controls.Add(Me.lstHighestScoringFirstTurn)
        Me.Controls.Add(Me.fra301Stats)
        Me.Controls.Add(Me.fraGolfStats)
        Me.Controls.Add(Me.chkReverseSort)
        Me.Controls.Add(Me.cboStatsToShow)
        Me.Controls.Add(Me.lstLongestWinningGame)
        Me.Controls.Add(Me.lstLongestScoringDrought)
        Me.Controls.Add(Me.lstShortestWinningGame)
        Me.Controls.Add(Me.lstPlayers)
        Me.Controls.Add(Me.lstHighScoreTurn)
        Me.Controls.Add(Me.lblMeanScorePerThrowPerDay)
        Me.Controls.Add(Me.lblMeanScorePerThrow)
        Me.Controls.Add(Me.lblHighestScoringFirstTurn)
        Me.Controls.Add(Me.lblLongestWinningGameLength)
        Me.Controls.Add(Me.lblLongestScoringDrought)
        Me.Controls.Add(Me.lblShortestGameLength)
        Me.Controls.Add(Me.lblPlayer)
        Me.Controls.Add(Me.lblHighScoreTurn)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.Location = New System.Drawing.Point(4, 23)
        Me.MinimumSize = New System.Drawing.Size(0, 380)
        Me.Name = "frmAddnlStats"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Additional Statistics"
        Me.fraControls.ResumeLayout(False)
        Me.fraControls.PerformLayout()
        CType(Me.objCalendar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fra301Stats.ResumeLayout(False)
        Me.fraGolfStats.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region
End Class