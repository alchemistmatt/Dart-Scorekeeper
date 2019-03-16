<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmPlayerStats
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
	Public WithEvents cboDaysForStats As System.Windows.Forms.ComboBox
	Public WithEvents cmdHelp As System.Windows.Forms.Button
	Public WithEvents lblBestPlayer As System.Windows.Forms.Label
	Public WithEvents lblWorstPlayer As System.Windows.Forms.Label
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Label9 As System.Windows.Forms.Label
	Public WithEvents lblBestPlayerName As System.Windows.Forms.Label
	Public WithEvents lblWorstPlayerName As System.Windows.Forms.Label
	Public WithEvents fraControls As System.Windows.Forms.Panel
	Public WithEvents cmdAddnlStats As System.Windows.Forms.Button
	Public WithEvents lstRank As System.Windows.Forms.ListBox
	Public WithEvents lstGamesWon As System.Windows.Forms.ListBox
	Public WithEvents chkReverseSort As System.Windows.Forms.CheckBox
	Public WithEvents lstWorstPartner As System.Windows.Forms.ListBox
	Public WithEvents lstBestPartner As System.Windows.Forms.ListBox
	Public WithEvents lstGamesPlayedPerMonth As System.Windows.Forms.ListBox
	Public WithEvents lstGamesWonWithPartner As System.Windows.Forms.ListBox
	Public WithEvents lstPlayers As System.Windows.Forms.ListBox
	Public WithEvents lblDirections As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents lblPlayer As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPlayerStats))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblDirections = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblPlayer = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.fraControls = New System.Windows.Forms.Panel
        Me.cmdOK = New System.Windows.Forms.Button
        Me.cboDaysForStats = New System.Windows.Forms.ComboBox
        Me.cmdHelp = New System.Windows.Forms.Button
        Me.lblBestPlayer = New System.Windows.Forms.Label
        Me.lblWorstPlayer = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.lblBestPlayerName = New System.Windows.Forms.Label
        Me.lblWorstPlayerName = New System.Windows.Forms.Label
        Me.cmdAddnlStats = New System.Windows.Forms.Button
        Me.lstRank = New System.Windows.Forms.ListBox
        Me.lstGamesWon = New System.Windows.Forms.ListBox
        Me.chkReverseSort = New System.Windows.Forms.CheckBox
        Me.lstWorstPartner = New System.Windows.Forms.ListBox
        Me.lstBestPartner = New System.Windows.Forms.ListBox
        Me.lstGamesPlayedPerMonth = New System.Windows.Forms.ListBox
        Me.lstGamesWonWithPartner = New System.Windows.Forms.ListBox
        Me.lstPlayers = New System.Windows.Forms.ListBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.fraControls.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblDirections
        '
        Me.lblDirections.BackColor = System.Drawing.SystemColors.Control
        Me.lblDirections.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDirections.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDirections.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDirections.Location = New System.Drawing.Point(8, 0)
        Me.lblDirections.Name = "lblDirections"
        Me.lblDirections.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDirections.Size = New System.Drawing.Size(409, 17)
        Me.lblDirections.TabIndex = 16
        Me.lblDirections.Text = "Double-click a player's name for a graph of performance by month."
        Me.ToolTip1.SetToolTip(Me.lblDirections, "Click here to resort")
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(104, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(65, 17)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Rank"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.Label7, "Click here to resort")
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(353, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(65, 65)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Games Played Per Month"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.Label3, "Click here to resort")
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(175, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(73, 49)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Games Won Overall"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.Label2, "Click here to resort")
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(274, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(65, 49)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Partner Games Won"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.Label1, "Click here to resort")
        '
        'lblPlayer
        '
        Me.lblPlayer.BackColor = System.Drawing.SystemColors.Control
        Me.lblPlayer.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPlayer.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlayer.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPlayer.Location = New System.Drawing.Point(24, 72)
        Me.lblPlayer.Name = "lblPlayer"
        Me.lblPlayer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPlayer.Size = New System.Drawing.Size(57, 17)
        Me.lblPlayer.TabIndex = 7
        Me.lblPlayer.Text = "Player"
        Me.lblPlayer.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.lblPlayer, "Click here to resort")
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(424, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(89, 17)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Best Partner"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.Label4, "Click here to resort")
        '
        'fraControls
        '
        Me.fraControls.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fraControls.BackColor = System.Drawing.SystemColors.Control
        Me.fraControls.Controls.Add(Me.cmdOK)
        Me.fraControls.Controls.Add(Me.cboDaysForStats)
        Me.fraControls.Controls.Add(Me.cmdHelp)
        Me.fraControls.Controls.Add(Me.lblBestPlayer)
        Me.fraControls.Controls.Add(Me.lblWorstPlayer)
        Me.fraControls.Controls.Add(Me.Label8)
        Me.fraControls.Controls.Add(Me.Label9)
        Me.fraControls.Controls.Add(Me.lblBestPlayerName)
        Me.fraControls.Controls.Add(Me.lblWorstPlayerName)
        Me.fraControls.Cursor = System.Windows.Forms.Cursors.Default
        Me.fraControls.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraControls.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraControls.Location = New System.Drawing.Point(8, 359)
        Me.fraControls.Name = "fraControls"
        Me.fraControls.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraControls.Size = New System.Drawing.Size(641, 41)
        Me.fraControls.TabIndex = 17
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdOK.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Location = New System.Drawing.Point(496, 8)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOK.Size = New System.Drawing.Size(57, 25)
        Me.cmdOK.TabIndex = 20
        Me.cmdOK.Text = "&Close"
        Me.cmdOK.UseVisualStyleBackColor = False
        '
        'cboDaysForStats
        '
        Me.cboDaysForStats.BackColor = System.Drawing.SystemColors.Window
        Me.cboDaysForStats.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboDaysForStats.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDaysForStats.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDaysForStats.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboDaysForStats.Location = New System.Drawing.Point(32, 7)
        Me.cboDaysForStats.Name = "cboDaysForStats"
        Me.cboDaysForStats.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboDaysForStats.Size = New System.Drawing.Size(49, 22)
        Me.cboDaysForStats.TabIndex = 19
        '
        'cmdHelp
        '
        Me.cmdHelp.BackColor = System.Drawing.SystemColors.Control
        Me.cmdHelp.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdHelp.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdHelp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdHelp.Location = New System.Drawing.Point(568, 8)
        Me.cmdHelp.Name = "cmdHelp"
        Me.cmdHelp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdHelp.Size = New System.Drawing.Size(57, 25)
        Me.cmdHelp.TabIndex = 18
        Me.cmdHelp.Text = "&Help"
        Me.cmdHelp.UseVisualStyleBackColor = False
        '
        'lblBestPlayer
        '
        Me.lblBestPlayer.BackColor = System.Drawing.SystemColors.Control
        Me.lblBestPlayer.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblBestPlayer.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBestPlayer.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBestPlayer.Location = New System.Drawing.Point(128, 0)
        Me.lblBestPlayer.Name = "lblBestPlayer"
        Me.lblBestPlayer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblBestPlayer.Size = New System.Drawing.Size(89, 17)
        Me.lblBestPlayer.TabIndex = 26
        Me.lblBestPlayer.Text = "Best Player:"
        '
        'lblWorstPlayer
        '
        Me.lblWorstPlayer.BackColor = System.Drawing.SystemColors.Control
        Me.lblWorstPlayer.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblWorstPlayer.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWorstPlayer.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblWorstPlayer.Location = New System.Drawing.Point(128, 20)
        Me.lblWorstPlayer.Name = "lblWorstPlayer"
        Me.lblWorstPlayer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblWorstPlayer.Size = New System.Drawing.Size(97, 17)
        Me.lblWorstPlayer.TabIndex = 25
        Me.lblWorstPlayer.Text = "Worst Player:"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(0, 7)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(41, 17)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Last"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(85, 7)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(41, 17)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "days:"
        '
        'lblBestPlayerName
        '
        Me.lblBestPlayerName.BackColor = System.Drawing.SystemColors.Control
        Me.lblBestPlayerName.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblBestPlayerName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBestPlayerName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBestPlayerName.Location = New System.Drawing.Point(224, 0)
        Me.lblBestPlayerName.Name = "lblBestPlayerName"
        Me.lblBestPlayerName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblBestPlayerName.Size = New System.Drawing.Size(193, 17)
        Me.lblBestPlayerName.TabIndex = 22
        '
        'lblWorstPlayerName
        '
        Me.lblWorstPlayerName.BackColor = System.Drawing.SystemColors.Control
        Me.lblWorstPlayerName.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblWorstPlayerName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWorstPlayerName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblWorstPlayerName.Location = New System.Drawing.Point(224, 20)
        Me.lblWorstPlayerName.Name = "lblWorstPlayerName"
        Me.lblWorstPlayerName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblWorstPlayerName.Size = New System.Drawing.Size(201, 17)
        Me.lblWorstPlayerName.TabIndex = 21
        '
        'cmdAddnlStats
        '
        Me.cmdAddnlStats.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAddnlStats.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAddnlStats.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAddnlStats.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAddnlStats.Location = New System.Drawing.Point(8, 24)
        Me.cmdAddnlStats.Name = "cmdAddnlStats"
        Me.cmdAddnlStats.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAddnlStats.Size = New System.Drawing.Size(105, 25)
        Me.cmdAddnlStats.TabIndex = 15
        Me.cmdAddnlStats.Text = "&Additional  Stats"
        Me.cmdAddnlStats.UseVisualStyleBackColor = False
        '
        'lstRank
        '
        Me.lstRank.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstRank.BackColor = System.Drawing.SystemColors.Window
        Me.lstRank.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstRank.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstRank.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstRank.ItemHeight = 14
        Me.lstRank.Location = New System.Drawing.Point(112, 96)
        Me.lstRank.Name = "lstRank"
        Me.lstRank.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstRank.Size = New System.Drawing.Size(49, 242)
        Me.lstRank.TabIndex = 13
        '
        'lstGamesWon
        '
        Me.lstGamesWon.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstGamesWon.BackColor = System.Drawing.SystemColors.Window
        Me.lstGamesWon.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstGamesWon.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstGamesWon.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstGamesWon.ItemHeight = 14
        Me.lstGamesWon.Location = New System.Drawing.Point(168, 96)
        Me.lstGamesWon.Name = "lstGamesWon"
        Me.lstGamesWon.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstGamesWon.Size = New System.Drawing.Size(89, 242)
        Me.lstGamesWon.TabIndex = 2
        '
        'chkReverseSort
        '
        Me.chkReverseSort.BackColor = System.Drawing.SystemColors.Control
        Me.chkReverseSort.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkReverseSort.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkReverseSort.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkReverseSort.Location = New System.Drawing.Point(536, 24)
        Me.chkReverseSort.Name = "chkReverseSort"
        Me.chkReverseSort.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkReverseSort.Size = New System.Drawing.Size(89, 17)
        Me.chkReverseSort.TabIndex = 0
        Me.chkReverseSort.Text = "&Reverse Sort"
        Me.chkReverseSort.UseVisualStyleBackColor = False
        '
        'lstWorstPartner
        '
        Me.lstWorstPartner.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstWorstPartner.BackColor = System.Drawing.SystemColors.Window
        Me.lstWorstPartner.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstWorstPartner.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstWorstPartner.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstWorstPartner.ItemHeight = 14
        Me.lstWorstPartner.Location = New System.Drawing.Point(528, 96)
        Me.lstWorstPartner.Name = "lstWorstPartner"
        Me.lstWorstPartner.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstWorstPartner.Size = New System.Drawing.Size(113, 242)
        Me.lstWorstPartner.TabIndex = 6
        '
        'lstBestPartner
        '
        Me.lstBestPartner.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstBestPartner.BackColor = System.Drawing.SystemColors.Window
        Me.lstBestPartner.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstBestPartner.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstBestPartner.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstBestPartner.ItemHeight = 14
        Me.lstBestPartner.Location = New System.Drawing.Point(416, 96)
        Me.lstBestPartner.Name = "lstBestPartner"
        Me.lstBestPartner.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstBestPartner.Size = New System.Drawing.Size(105, 242)
        Me.lstBestPartner.TabIndex = 5
        '
        'lstGamesPlayedPerMonth
        '
        Me.lstGamesPlayedPerMonth.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstGamesPlayedPerMonth.BackColor = System.Drawing.SystemColors.Window
        Me.lstGamesPlayedPerMonth.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstGamesPlayedPerMonth.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstGamesPlayedPerMonth.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstGamesPlayedPerMonth.ItemHeight = 14
        Me.lstGamesPlayedPerMonth.Location = New System.Drawing.Point(360, 96)
        Me.lstGamesPlayedPerMonth.Name = "lstGamesPlayedPerMonth"
        Me.lstGamesPlayedPerMonth.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstGamesPlayedPerMonth.Size = New System.Drawing.Size(49, 242)
        Me.lstGamesPlayedPerMonth.TabIndex = 4
        '
        'lstGamesWonWithPartner
        '
        Me.lstGamesWonWithPartner.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstGamesWonWithPartner.BackColor = System.Drawing.SystemColors.Window
        Me.lstGamesWonWithPartner.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstGamesWonWithPartner.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstGamesWonWithPartner.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstGamesWonWithPartner.ItemHeight = 14
        Me.lstGamesWonWithPartner.Location = New System.Drawing.Point(264, 96)
        Me.lstGamesWonWithPartner.Name = "lstGamesWonWithPartner"
        Me.lstGamesWonWithPartner.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstGamesWonWithPartner.Size = New System.Drawing.Size(89, 242)
        Me.lstGamesWonWithPartner.TabIndex = 3
        '
        'lstPlayers
        '
        Me.lstPlayers.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstPlayers.BackColor = System.Drawing.SystemColors.Window
        Me.lstPlayers.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstPlayers.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstPlayers.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstPlayers.ItemHeight = 14
        Me.lstPlayers.Location = New System.Drawing.Point(8, 96)
        Me.lstPlayers.Name = "lstPlayers"
        Me.lstPlayers.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstPlayers.Size = New System.Drawing.Size(97, 242)
        Me.lstPlayers.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(536, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(97, 25)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Worst Partner"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmPlayerStats
        '
        Me.AcceptButton = Me.cmdOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.cmdOK
        Me.ClientSize = New System.Drawing.Size(662, 415)
        Me.Controls.Add(Me.fraControls)
        Me.Controls.Add(Me.cmdAddnlStats)
        Me.Controls.Add(Me.lstRank)
        Me.Controls.Add(Me.lstGamesWon)
        Me.Controls.Add(Me.chkReverseSort)
        Me.Controls.Add(Me.lstWorstPartner)
        Me.Controls.Add(Me.lstBestPartner)
        Me.Controls.Add(Me.lstGamesPlayedPerMonth)
        Me.Controls.Add(Me.lstGamesWonWithPartner)
        Me.Controls.Add(Me.lstPlayers)
        Me.Controls.Add(Me.lblDirections)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblPlayer)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(55, 111)
        Me.MinimumSize = New System.Drawing.Size(16, 270)
        Me.Name = "frmPlayerStats"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Player Statistics"
        Me.fraControls.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region 
End Class