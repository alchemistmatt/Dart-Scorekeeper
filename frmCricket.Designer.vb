<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmCricket
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
	Public WithEvents cmdShowRealtimeStatistics As System.Windows.Forms.Button
	Public WithEvents _pctSourceSmall_0 As System.Windows.Forms.PictureBox
	Public WithEvents _pctSourceSmall_1 As System.Windows.Forms.PictureBox
	Public WithEvents _pctSourceSmall_2 As System.Windows.Forms.PictureBox
	Public WithEvents _pctSourceSmall_3 As System.Windows.Forms.PictureBox
	Public WithEvents _pctSourceSmall_4 As System.Windows.Forms.PictureBox
	Public WithEvents _pctSourceSmall_9 As System.Windows.Forms.PictureBox
	Public WithEvents _pctSourceSmall_8 As System.Windows.Forms.PictureBox
	Public WithEvents _pctSourceSmall_7 As System.Windows.Forms.PictureBox
	Public WithEvents _pctSourceSmall_6 As System.Windows.Forms.PictureBox
	Public WithEvents _pctSourceSmall_5 As System.Windows.Forms.PictureBox
	Public WithEvents cmdScoreMode As System.Windows.Forms.Button
	Public WithEvents chkDoubleIn As System.Windows.Forms.CheckBox
	Public WithEvents txtStartNumber As System.Windows.Forms.TextBox
	Public WithEvents chkDoubleOut As System.Windows.Forms.CheckBox
	Public WithEvents lstCurrentTeam As System.Windows.Forms.ListBox
	Public WithEvents cmdNextTeam As System.Windows.Forms.Button
	Public WithEvents cmdPreviousTeam As System.Windows.Forms.Button
	Public WithEvents cmdShowDartBoard As System.Windows.Forms.Button
	Public WithEvents cmdHelp As System.Windows.Forms.Button
	Public WithEvents _pctSource_5 As System.Windows.Forms.PictureBox
	Public WithEvents _pctSource_6 As System.Windows.Forms.PictureBox
	Public WithEvents _pctSource_7 As System.Windows.Forms.PictureBox
	Public WithEvents _pctSource_8 As System.Windows.Forms.PictureBox
	Public WithEvents _pctSource_9 As System.Windows.Forms.PictureBox
	Public WithEvents txtHitCount As System.Windows.Forms.TextBox
    Public WithEvents tmrTimer As System.Windows.Forms.Timer
	Public WithEvents cmdRedo As System.Windows.Forms.Button
	Public WithEvents _pctSource_4 As System.Windows.Forms.PictureBox
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents _cboPlayerList_1 As System.Windows.Forms.ComboBox
	Public WithEvents _pctSource_3 As System.Windows.Forms.PictureBox
	Public WithEvents _pctSource_2 As System.Windows.Forms.PictureBox
	Public WithEvents _pctSource_1 As System.Windows.Forms.PictureBox
	Public WithEvents cmdUndo As System.Windows.Forms.Button
	Public WithEvents cmdStartNewGame As System.Windows.Forms.Button
	Public WithEvents cboNumberOfTeams As System.Windows.Forms.ComboBox
	Public WithEvents _cboPlayerList_0 As System.Windows.Forms.ComboBox
	Public WithEvents _pctSource_0 As System.Windows.Forms.PictureBox
	Public WithEvents _pctScoreBox_0 As System.Windows.Forms.PictureBox
	Public WithEvents lblCurrentHoleLabel As System.Windows.Forms.Label
	Public WithEvents lblCurrentHole As System.Windows.Forms.Label
	Public WithEvents lblStartNumber As System.Windows.Forms.Label
	Public WithEvents lblCurrentTeam As System.Windows.Forms.Label
	Public WithEvents _lblWinStatus_0 As System.Windows.Forms.Label
	Public WithEvents lblScoreMode As System.Windows.Forms.Label
	Public WithEvents _lblAltScore_0 As System.Windows.Forms.Label
	Public WithEvents lblNumberOfTeams As System.Windows.Forms.Label
	Public WithEvents _lblScore_0 As System.Windows.Forms.Label
	Public WithEvents lblStatus As System.Windows.Forms.Label
	Public WithEvents _lblTeamName_0 As System.Windows.Forms.Label
	Public WithEvents _lblBoxName_0 As System.Windows.Forms.Label
	Public WithEvents cboPlayerList As Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray
	Public WithEvents lblAltScore As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents lblBoxName As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents lblScore As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents lblTeamName As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents lblWinStatus As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents pctScoreBox As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents pctSource As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	Public WithEvents pctSourceSmall As Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCricket))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtStartNumber = New System.Windows.Forms.TextBox
        Me.cmdShowRealtimeStatistics = New System.Windows.Forms.Button
        Me._pctSourceSmall_0 = New System.Windows.Forms.PictureBox
        Me._pctSourceSmall_1 = New System.Windows.Forms.PictureBox
        Me._pctSourceSmall_2 = New System.Windows.Forms.PictureBox
        Me._pctSourceSmall_3 = New System.Windows.Forms.PictureBox
        Me._pctSourceSmall_4 = New System.Windows.Forms.PictureBox
        Me._pctSourceSmall_9 = New System.Windows.Forms.PictureBox
        Me._pctSourceSmall_8 = New System.Windows.Forms.PictureBox
        Me._pctSourceSmall_7 = New System.Windows.Forms.PictureBox
        Me._pctSourceSmall_6 = New System.Windows.Forms.PictureBox
        Me._pctSourceSmall_5 = New System.Windows.Forms.PictureBox
        Me.cmdScoreMode = New System.Windows.Forms.Button
        Me.chkDoubleIn = New System.Windows.Forms.CheckBox
        Me.chkDoubleOut = New System.Windows.Forms.CheckBox
        Me.lstCurrentTeam = New System.Windows.Forms.ListBox
        Me.cmdNextTeam = New System.Windows.Forms.Button
        Me.cmdPreviousTeam = New System.Windows.Forms.Button
        Me.cmdShowDartBoard = New System.Windows.Forms.Button
        Me.cmdHelp = New System.Windows.Forms.Button
        Me._pctSource_5 = New System.Windows.Forms.PictureBox
        Me._pctSource_6 = New System.Windows.Forms.PictureBox
        Me._pctSource_7 = New System.Windows.Forms.PictureBox
        Me._pctSource_8 = New System.Windows.Forms.PictureBox
        Me._pctSource_9 = New System.Windows.Forms.PictureBox
        Me.txtHitCount = New System.Windows.Forms.TextBox
        Me.tmrTimer = New System.Windows.Forms.Timer(Me.components)
        Me.cmdRedo = New System.Windows.Forms.Button
        Me._pctSource_4 = New System.Windows.Forms.PictureBox
        Me.cmdClose = New System.Windows.Forms.Button
        Me._cboPlayerList_1 = New System.Windows.Forms.ComboBox
        Me._pctSource_3 = New System.Windows.Forms.PictureBox
        Me._pctSource_2 = New System.Windows.Forms.PictureBox
        Me._pctSource_1 = New System.Windows.Forms.PictureBox
        Me.cmdUndo = New System.Windows.Forms.Button
        Me.cmdStartNewGame = New System.Windows.Forms.Button
        Me.cboNumberOfTeams = New System.Windows.Forms.ComboBox
        Me._cboPlayerList_0 = New System.Windows.Forms.ComboBox
        Me._pctSource_0 = New System.Windows.Forms.PictureBox
        Me._pctScoreBox_0 = New System.Windows.Forms.PictureBox
        Me.lblCurrentHoleLabel = New System.Windows.Forms.Label
        Me.lblCurrentHole = New System.Windows.Forms.Label
        Me.lblStartNumber = New System.Windows.Forms.Label
        Me.lblCurrentTeam = New System.Windows.Forms.Label
        Me._lblWinStatus_0 = New System.Windows.Forms.Label
        Me.lblScoreMode = New System.Windows.Forms.Label
        Me._lblAltScore_0 = New System.Windows.Forms.Label
        Me.lblNumberOfTeams = New System.Windows.Forms.Label
        Me._lblScore_0 = New System.Windows.Forms.Label
        Me.lblStatus = New System.Windows.Forms.Label
        Me._lblTeamName_0 = New System.Windows.Forms.Label
        Me._lblBoxName_0 = New System.Windows.Forms.Label
        Me.cboPlayerList = New Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray(Me.components)
        Me.lblAltScore = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblBoxName = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblScore = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblTeamName = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblWinStatus = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.pctScoreBox = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.pctSource = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        Me.pctSourceSmall = New Microsoft.VisualBasic.Compatibility.VB6.PictureBoxArray(Me.components)
        CType(Me._pctSourceSmall_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._pctSourceSmall_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._pctSourceSmall_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._pctSourceSmall_3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._pctSourceSmall_4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._pctSourceSmall_9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._pctSourceSmall_8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._pctSourceSmall_7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._pctSourceSmall_6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._pctSourceSmall_5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._pctSource_5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._pctSource_6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._pctSource_7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._pctSource_8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._pctSource_9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._pctSource_4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._pctSource_3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._pctSource_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._pctSource_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._pctSource_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._pctScoreBox_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPlayerList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblAltScore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblBoxName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblScore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTeamName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblWinStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctScoreBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctSourceSmall, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtStartNumber
        '
        Me.txtStartNumber.AcceptsReturn = True
        Me.txtStartNumber.BackColor = System.Drawing.SystemColors.Window
        Me.txtStartNumber.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStartNumber.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStartNumber.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStartNumber.Location = New System.Drawing.Point(16, 112)
        Me.txtStartNumber.MaxLength = 0
        Me.txtStartNumber.Name = "txtStartNumber"
        Me.txtStartNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStartNumber.Size = New System.Drawing.Size(33, 22)
        Me.txtStartNumber.TabIndex = 4
        Me.txtStartNumber.Text = "301"
        Me.ToolTip1.SetToolTip(Me.txtStartNumber, "The starting number for 301-type games.")
        '
        'cmdShowRealtimeStatistics
        '
        Me.cmdShowRealtimeStatistics.BackColor = System.Drawing.SystemColors.Control
        Me.cmdShowRealtimeStatistics.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdShowRealtimeStatistics.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdShowRealtimeStatistics.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdShowRealtimeStatistics.Location = New System.Drawing.Point(8, 320)
        Me.cmdShowRealtimeStatistics.Name = "cmdShowRealtimeStatistics"
        Me.cmdShowRealtimeStatistics.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdShowRealtimeStatistics.Size = New System.Drawing.Size(121, 20)
        Me.cmdShowRealtimeStatistics.TabIndex = 14
        Me.cmdShowRealtimeStatistics.Text = "Real-time Statistics"
        Me.cmdShowRealtimeStatistics.UseVisualStyleBackColor = False
        '
        '_pctSourceSmall_0
        '
        Me._pctSourceSmall_0.BackColor = System.Drawing.SystemColors.Control
        Me._pctSourceSmall_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._pctSourceSmall_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._pctSourceSmall_0.Enabled = False
        Me._pctSourceSmall_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._pctSourceSmall_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._pctSourceSmall_0.Image = CType(resources.GetObject("_pctSourceSmall_0.Image"), System.Drawing.Image)
        Me.pctSourceSmall.SetIndex(Me._pctSourceSmall_0, CType(0, Short))
        Me._pctSourceSmall_0.Location = New System.Drawing.Point(368, 192)
        Me._pctSourceSmall_0.Name = "_pctSourceSmall_0"
        Me._pctSourceSmall_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._pctSourceSmall_0.Size = New System.Drawing.Size(25, 25)
        Me._pctSourceSmall_0.TabIndex = 50
        Me._pctSourceSmall_0.TabStop = False
        Me._pctSourceSmall_0.Visible = False
        '
        '_pctSourceSmall_1
        '
        Me._pctSourceSmall_1.BackColor = System.Drawing.SystemColors.Control
        Me._pctSourceSmall_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._pctSourceSmall_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._pctSourceSmall_1.Enabled = False
        Me._pctSourceSmall_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._pctSourceSmall_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._pctSourceSmall_1.Image = CType(resources.GetObject("_pctSourceSmall_1.Image"), System.Drawing.Image)
        Me.pctSourceSmall.SetIndex(Me._pctSourceSmall_1, CType(1, Short))
        Me._pctSourceSmall_1.Location = New System.Drawing.Point(368, 232)
        Me._pctSourceSmall_1.Name = "_pctSourceSmall_1"
        Me._pctSourceSmall_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._pctSourceSmall_1.Size = New System.Drawing.Size(25, 25)
        Me._pctSourceSmall_1.TabIndex = 49
        Me._pctSourceSmall_1.TabStop = False
        Me._pctSourceSmall_1.Visible = False
        '
        '_pctSourceSmall_2
        '
        Me._pctSourceSmall_2.BackColor = System.Drawing.SystemColors.Control
        Me._pctSourceSmall_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._pctSourceSmall_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._pctSourceSmall_2.Enabled = False
        Me._pctSourceSmall_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._pctSourceSmall_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._pctSourceSmall_2.Image = CType(resources.GetObject("_pctSourceSmall_2.Image"), System.Drawing.Image)
        Me.pctSourceSmall.SetIndex(Me._pctSourceSmall_2, CType(2, Short))
        Me._pctSourceSmall_2.Location = New System.Drawing.Point(368, 272)
        Me._pctSourceSmall_2.Name = "_pctSourceSmall_2"
        Me._pctSourceSmall_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._pctSourceSmall_2.Size = New System.Drawing.Size(25, 25)
        Me._pctSourceSmall_2.TabIndex = 48
        Me._pctSourceSmall_2.TabStop = False
        Me._pctSourceSmall_2.Visible = False
        '
        '_pctSourceSmall_3
        '
        Me._pctSourceSmall_3.BackColor = System.Drawing.SystemColors.Control
        Me._pctSourceSmall_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._pctSourceSmall_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._pctSourceSmall_3.Enabled = False
        Me._pctSourceSmall_3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._pctSourceSmall_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._pctSourceSmall_3.Image = CType(resources.GetObject("_pctSourceSmall_3.Image"), System.Drawing.Image)
        Me.pctSourceSmall.SetIndex(Me._pctSourceSmall_3, CType(3, Short))
        Me._pctSourceSmall_3.Location = New System.Drawing.Point(368, 312)
        Me._pctSourceSmall_3.Name = "_pctSourceSmall_3"
        Me._pctSourceSmall_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._pctSourceSmall_3.Size = New System.Drawing.Size(25, 25)
        Me._pctSourceSmall_3.TabIndex = 47
        Me._pctSourceSmall_3.TabStop = False
        Me._pctSourceSmall_3.Visible = False
        '
        '_pctSourceSmall_4
        '
        Me._pctSourceSmall_4.BackColor = System.Drawing.SystemColors.Control
        Me._pctSourceSmall_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._pctSourceSmall_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._pctSourceSmall_4.Enabled = False
        Me._pctSourceSmall_4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._pctSourceSmall_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._pctSourceSmall_4.Image = CType(resources.GetObject("_pctSourceSmall_4.Image"), System.Drawing.Image)
        Me.pctSourceSmall.SetIndex(Me._pctSourceSmall_4, CType(4, Short))
        Me._pctSourceSmall_4.Location = New System.Drawing.Point(368, 352)
        Me._pctSourceSmall_4.Name = "_pctSourceSmall_4"
        Me._pctSourceSmall_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._pctSourceSmall_4.Size = New System.Drawing.Size(25, 25)
        Me._pctSourceSmall_4.TabIndex = 46
        Me._pctSourceSmall_4.TabStop = False
        Me._pctSourceSmall_4.Visible = False
        '
        '_pctSourceSmall_9
        '
        Me._pctSourceSmall_9.BackColor = System.Drawing.SystemColors.Control
        Me._pctSourceSmall_9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._pctSourceSmall_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._pctSourceSmall_9.Enabled = False
        Me._pctSourceSmall_9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._pctSourceSmall_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me._pctSourceSmall_9.Image = CType(resources.GetObject("_pctSourceSmall_9.Image"), System.Drawing.Image)
        Me.pctSourceSmall.SetIndex(Me._pctSourceSmall_9, CType(9, Short))
        Me._pctSourceSmall_9.Location = New System.Drawing.Point(416, 352)
        Me._pctSourceSmall_9.Name = "_pctSourceSmall_9"
        Me._pctSourceSmall_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._pctSourceSmall_9.Size = New System.Drawing.Size(25, 25)
        Me._pctSourceSmall_9.TabIndex = 45
        Me._pctSourceSmall_9.TabStop = False
        Me._pctSourceSmall_9.Visible = False
        '
        '_pctSourceSmall_8
        '
        Me._pctSourceSmall_8.BackColor = System.Drawing.SystemColors.Control
        Me._pctSourceSmall_8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._pctSourceSmall_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._pctSourceSmall_8.Enabled = False
        Me._pctSourceSmall_8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._pctSourceSmall_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._pctSourceSmall_8.Image = CType(resources.GetObject("_pctSourceSmall_8.Image"), System.Drawing.Image)
        Me.pctSourceSmall.SetIndex(Me._pctSourceSmall_8, CType(8, Short))
        Me._pctSourceSmall_8.Location = New System.Drawing.Point(416, 312)
        Me._pctSourceSmall_8.Name = "_pctSourceSmall_8"
        Me._pctSourceSmall_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._pctSourceSmall_8.Size = New System.Drawing.Size(25, 25)
        Me._pctSourceSmall_8.TabIndex = 44
        Me._pctSourceSmall_8.TabStop = False
        Me._pctSourceSmall_8.Visible = False
        '
        '_pctSourceSmall_7
        '
        Me._pctSourceSmall_7.BackColor = System.Drawing.SystemColors.Control
        Me._pctSourceSmall_7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._pctSourceSmall_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._pctSourceSmall_7.Enabled = False
        Me._pctSourceSmall_7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._pctSourceSmall_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._pctSourceSmall_7.Image = CType(resources.GetObject("_pctSourceSmall_7.Image"), System.Drawing.Image)
        Me.pctSourceSmall.SetIndex(Me._pctSourceSmall_7, CType(7, Short))
        Me._pctSourceSmall_7.Location = New System.Drawing.Point(416, 272)
        Me._pctSourceSmall_7.Name = "_pctSourceSmall_7"
        Me._pctSourceSmall_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._pctSourceSmall_7.Size = New System.Drawing.Size(25, 25)
        Me._pctSourceSmall_7.TabIndex = 43
        Me._pctSourceSmall_7.TabStop = False
        Me._pctSourceSmall_7.Visible = False
        '
        '_pctSourceSmall_6
        '
        Me._pctSourceSmall_6.BackColor = System.Drawing.SystemColors.Control
        Me._pctSourceSmall_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._pctSourceSmall_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._pctSourceSmall_6.Enabled = False
        Me._pctSourceSmall_6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._pctSourceSmall_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._pctSourceSmall_6.Image = CType(resources.GetObject("_pctSourceSmall_6.Image"), System.Drawing.Image)
        Me.pctSourceSmall.SetIndex(Me._pctSourceSmall_6, CType(6, Short))
        Me._pctSourceSmall_6.Location = New System.Drawing.Point(416, 232)
        Me._pctSourceSmall_6.Name = "_pctSourceSmall_6"
        Me._pctSourceSmall_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._pctSourceSmall_6.Size = New System.Drawing.Size(25, 25)
        Me._pctSourceSmall_6.TabIndex = 42
        Me._pctSourceSmall_6.TabStop = False
        Me._pctSourceSmall_6.Visible = False
        '
        '_pctSourceSmall_5
        '
        Me._pctSourceSmall_5.BackColor = System.Drawing.SystemColors.Control
        Me._pctSourceSmall_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._pctSourceSmall_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._pctSourceSmall_5.Enabled = False
        Me._pctSourceSmall_5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._pctSourceSmall_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._pctSourceSmall_5.Image = CType(resources.GetObject("_pctSourceSmall_5.Image"), System.Drawing.Image)
        Me.pctSourceSmall.SetIndex(Me._pctSourceSmall_5, CType(5, Short))
        Me._pctSourceSmall_5.Location = New System.Drawing.Point(416, 192)
        Me._pctSourceSmall_5.Name = "_pctSourceSmall_5"
        Me._pctSourceSmall_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._pctSourceSmall_5.Size = New System.Drawing.Size(25, 25)
        Me._pctSourceSmall_5.TabIndex = 41
        Me._pctSourceSmall_5.TabStop = False
        Me._pctSourceSmall_5.Visible = False
        '
        'cmdScoreMode
        '
        Me.cmdScoreMode.BackColor = System.Drawing.SystemColors.Control
        Me.cmdScoreMode.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdScoreMode.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdScoreMode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdScoreMode.Location = New System.Drawing.Point(8, 272)
        Me.cmdScoreMode.Name = "cmdScoreMode"
        Me.cmdScoreMode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdScoreMode.Size = New System.Drawing.Size(121, 20)
        Me.cmdScoreMode.TabIndex = 11
        Me.cmdScoreMode.Text = "&Toggle Score mode"
        Me.cmdScoreMode.UseVisualStyleBackColor = False
        '
        'chkDoubleIn
        '
        Me.chkDoubleIn.BackColor = System.Drawing.SystemColors.Control
        Me.chkDoubleIn.Checked = True
        Me.chkDoubleIn.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDoubleIn.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkDoubleIn.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDoubleIn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkDoubleIn.Location = New System.Drawing.Point(8, 240)
        Me.chkDoubleIn.Name = "chkDoubleIn"
        Me.chkDoubleIn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkDoubleIn.Size = New System.Drawing.Size(57, 41)
        Me.chkDoubleIn.TabIndex = 9
        Me.chkDoubleIn.Text = "Require Double &In"
        Me.chkDoubleIn.UseVisualStyleBackColor = False
        '
        'chkDoubleOut
        '
        Me.chkDoubleOut.BackColor = System.Drawing.SystemColors.Control
        Me.chkDoubleOut.Checked = True
        Me.chkDoubleOut.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDoubleOut.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkDoubleOut.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDoubleOut.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkDoubleOut.Location = New System.Drawing.Point(72, 240)
        Me.chkDoubleOut.Name = "chkDoubleOut"
        Me.chkDoubleOut.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkDoubleOut.Size = New System.Drawing.Size(57, 41)
        Me.chkDoubleOut.TabIndex = 10
        Me.chkDoubleOut.Text = "Require Double &Out"
        Me.chkDoubleOut.UseVisualStyleBackColor = False
        '
        'lstCurrentTeam
        '
        Me.lstCurrentTeam.BackColor = System.Drawing.SystemColors.Window
        Me.lstCurrentTeam.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstCurrentTeam.Enabled = False
        Me.lstCurrentTeam.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstCurrentTeam.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstCurrentTeam.ItemHeight = 16
        Me.lstCurrentTeam.Location = New System.Drawing.Point(72, 128)
        Me.lstCurrentTeam.Name = "lstCurrentTeam"
        Me.lstCurrentTeam.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstCurrentTeam.Size = New System.Drawing.Size(41, 100)
        Me.lstCurrentTeam.TabIndex = 6
        '
        'cmdNextTeam
        '
        Me.cmdNextTeam.BackColor = System.Drawing.SystemColors.Control
        Me.cmdNextTeam.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdNextTeam.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNextTeam.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdNextTeam.Location = New System.Drawing.Point(8, 176)
        Me.cmdNextTeam.Name = "cmdNextTeam"
        Me.cmdNextTeam.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdNextTeam.Size = New System.Drawing.Size(57, 25)
        Me.cmdNextTeam.TabIndex = 8
        Me.cmdNextTeam.Text = "&Next"
        Me.cmdNextTeam.UseVisualStyleBackColor = False
        '
        'cmdPreviousTeam
        '
        Me.cmdPreviousTeam.BackColor = System.Drawing.SystemColors.Control
        Me.cmdPreviousTeam.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdPreviousTeam.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPreviousTeam.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdPreviousTeam.Location = New System.Drawing.Point(8, 144)
        Me.cmdPreviousTeam.Name = "cmdPreviousTeam"
        Me.cmdPreviousTeam.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdPreviousTeam.Size = New System.Drawing.Size(57, 25)
        Me.cmdPreviousTeam.TabIndex = 7
        Me.cmdPreviousTeam.Text = "&Previous"
        Me.cmdPreviousTeam.UseVisualStyleBackColor = False
        '
        'cmdShowDartBoard
        '
        Me.cmdShowDartBoard.BackColor = System.Drawing.SystemColors.Control
        Me.cmdShowDartBoard.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdShowDartBoard.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdShowDartBoard.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdShowDartBoard.Location = New System.Drawing.Point(8, 344)
        Me.cmdShowDartBoard.Name = "cmdShowDartBoard"
        Me.cmdShowDartBoard.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdShowDartBoard.Size = New System.Drawing.Size(121, 20)
        Me.cmdShowDartBoard.TabIndex = 15
        Me.cmdShowDartBoard.Text = "&Show Dart Board"
        Me.cmdShowDartBoard.UseVisualStyleBackColor = False
        '
        'cmdHelp
        '
        Me.cmdHelp.BackColor = System.Drawing.SystemColors.Control
        Me.cmdHelp.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdHelp.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdHelp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdHelp.Location = New System.Drawing.Point(72, 368)
        Me.cmdHelp.Name = "cmdHelp"
        Me.cmdHelp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdHelp.Size = New System.Drawing.Size(57, 25)
        Me.cmdHelp.TabIndex = 17
        Me.cmdHelp.Text = "&Help"
        Me.cmdHelp.UseVisualStyleBackColor = False
        '
        '_pctSource_5
        '
        Me._pctSource_5.BackColor = System.Drawing.SystemColors.Control
        Me._pctSource_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._pctSource_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._pctSource_5.Enabled = False
        Me._pctSource_5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._pctSource_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._pctSource_5.Image = CType(resources.GetObject("_pctSource_5.Image"), System.Drawing.Image)
        Me.pctSource.SetIndex(Me._pctSource_5, CType(5, Short))
        Me._pctSource_5.Location = New System.Drawing.Point(272, 192)
        Me._pctSource_5.Name = "_pctSource_5"
        Me._pctSource_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._pctSource_5.Size = New System.Drawing.Size(33, 33)
        Me._pctSource_5.TabIndex = 40
        Me._pctSource_5.TabStop = False
        Me._pctSource_5.Visible = False
        '
        '_pctSource_6
        '
        Me._pctSource_6.BackColor = System.Drawing.SystemColors.Control
        Me._pctSource_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._pctSource_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._pctSource_6.Enabled = False
        Me._pctSource_6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._pctSource_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._pctSource_6.Image = CType(resources.GetObject("_pctSource_6.Image"), System.Drawing.Image)
        Me.pctSource.SetIndex(Me._pctSource_6, CType(6, Short))
        Me._pctSource_6.Location = New System.Drawing.Point(272, 232)
        Me._pctSource_6.Name = "_pctSource_6"
        Me._pctSource_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._pctSource_6.Size = New System.Drawing.Size(33, 33)
        Me._pctSource_6.TabIndex = 39
        Me._pctSource_6.TabStop = False
        Me._pctSource_6.Visible = False
        '
        '_pctSource_7
        '
        Me._pctSource_7.BackColor = System.Drawing.SystemColors.Control
        Me._pctSource_7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._pctSource_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._pctSource_7.Enabled = False
        Me._pctSource_7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._pctSource_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._pctSource_7.Image = CType(resources.GetObject("_pctSource_7.Image"), System.Drawing.Image)
        Me.pctSource.SetIndex(Me._pctSource_7, CType(7, Short))
        Me._pctSource_7.Location = New System.Drawing.Point(272, 272)
        Me._pctSource_7.Name = "_pctSource_7"
        Me._pctSource_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._pctSource_7.Size = New System.Drawing.Size(33, 33)
        Me._pctSource_7.TabIndex = 38
        Me._pctSource_7.TabStop = False
        Me._pctSource_7.Visible = False
        '
        '_pctSource_8
        '
        Me._pctSource_8.BackColor = System.Drawing.SystemColors.Control
        Me._pctSource_8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._pctSource_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._pctSource_8.Enabled = False
        Me._pctSource_8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._pctSource_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._pctSource_8.Image = CType(resources.GetObject("_pctSource_8.Image"), System.Drawing.Image)
        Me.pctSource.SetIndex(Me._pctSource_8, CType(8, Short))
        Me._pctSource_8.Location = New System.Drawing.Point(272, 312)
        Me._pctSource_8.Name = "_pctSource_8"
        Me._pctSource_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._pctSource_8.Size = New System.Drawing.Size(33, 33)
        Me._pctSource_8.TabIndex = 37
        Me._pctSource_8.TabStop = False
        Me._pctSource_8.Visible = False
        '
        '_pctSource_9
        '
        Me._pctSource_9.BackColor = System.Drawing.SystemColors.Control
        Me._pctSource_9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._pctSource_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._pctSource_9.Enabled = False
        Me._pctSource_9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._pctSource_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me._pctSource_9.Image = CType(resources.GetObject("_pctSource_9.Image"), System.Drawing.Image)
        Me.pctSource.SetIndex(Me._pctSource_9, CType(9, Short))
        Me._pctSource_9.Location = New System.Drawing.Point(272, 352)
        Me._pctSource_9.Name = "_pctSource_9"
        Me._pctSource_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._pctSource_9.Size = New System.Drawing.Size(33, 33)
        Me._pctSource_9.TabIndex = 36
        Me._pctSource_9.TabStop = False
        Me._pctSource_9.Visible = False
        '
        'txtHitCount
        '
        Me.txtHitCount.AcceptsReturn = True
        Me.txtHitCount.BackColor = System.Drawing.Color.Blue
        Me.txtHitCount.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtHitCount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHitCount.ForeColor = System.Drawing.Color.White
        Me.txtHitCount.Location = New System.Drawing.Point(208, 112)
        Me.txtHitCount.MaxLength = 0
        Me.txtHitCount.Name = "txtHitCount"
        Me.txtHitCount.ReadOnly = True
        Me.txtHitCount.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtHitCount.Size = New System.Drawing.Size(27, 22)
        Me.txtHitCount.TabIndex = 25
        Me.txtHitCount.Text = "0"
        Me.txtHitCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtHitCount.Visible = False
        '
        'tmrTimer
        '
        Me.tmrTimer.Enabled = True
        Me.tmrTimer.Interval = 1000
        '
        'cmdRedo
        '
        Me.cmdRedo.BackColor = System.Drawing.SystemColors.Control
        Me.cmdRedo.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdRedo.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRedo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdRedo.Location = New System.Drawing.Point(72, 296)
        Me.cmdRedo.Name = "cmdRedo"
        Me.cmdRedo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdRedo.Size = New System.Drawing.Size(57, 20)
        Me.cmdRedo.TabIndex = 13
        Me.cmdRedo.Text = "&Redo"
        Me.cmdRedo.UseVisualStyleBackColor = False
        '
        '_pctSource_4
        '
        Me._pctSource_4.BackColor = System.Drawing.SystemColors.Control
        Me._pctSource_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._pctSource_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._pctSource_4.Enabled = False
        Me._pctSource_4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._pctSource_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._pctSource_4.Image = CType(resources.GetObject("_pctSource_4.Image"), System.Drawing.Image)
        Me.pctSource.SetIndex(Me._pctSource_4, CType(4, Short))
        Me._pctSource_4.Location = New System.Drawing.Point(224, 352)
        Me._pctSource_4.Name = "_pctSource_4"
        Me._pctSource_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._pctSource_4.Size = New System.Drawing.Size(33, 33)
        Me._pctSource_4.TabIndex = 34
        Me._pctSource_4.TabStop = False
        Me._pctSource_4.Visible = False
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClose.Location = New System.Drawing.Point(8, 368)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClose.Size = New System.Drawing.Size(57, 25)
        Me.cmdClose.TabIndex = 16
        Me.cmdClose.Text = "&Close"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        '_cboPlayerList_1
        '
        Me._cboPlayerList_1.BackColor = System.Drawing.SystemColors.Window
        Me._cboPlayerList_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._cboPlayerList_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cboPlayerList_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._cboPlayerList_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboPlayerList.SetIndex(Me._cboPlayerList_1, CType(1, Short))
        Me._cboPlayerList_1.Location = New System.Drawing.Point(152, 64)
        Me._cboPlayerList_1.Name = "_cboPlayerList_1"
        Me._cboPlayerList_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cboPlayerList_1.Size = New System.Drawing.Size(81, 22)
        Me._cboPlayerList_1.Sorted = True
        Me._cboPlayerList_1.TabIndex = 21
        '
        '_pctSource_3
        '
        Me._pctSource_3.BackColor = System.Drawing.SystemColors.Control
        Me._pctSource_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._pctSource_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._pctSource_3.Enabled = False
        Me._pctSource_3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._pctSource_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._pctSource_3.Image = CType(resources.GetObject("_pctSource_3.Image"), System.Drawing.Image)
        Me.pctSource.SetIndex(Me._pctSource_3, CType(3, Short))
        Me._pctSource_3.Location = New System.Drawing.Point(224, 312)
        Me._pctSource_3.Name = "_pctSource_3"
        Me._pctSource_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._pctSource_3.Size = New System.Drawing.Size(33, 33)
        Me._pctSource_3.TabIndex = 33
        Me._pctSource_3.TabStop = False
        Me._pctSource_3.Visible = False
        '
        '_pctSource_2
        '
        Me._pctSource_2.BackColor = System.Drawing.SystemColors.Control
        Me._pctSource_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._pctSource_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._pctSource_2.Enabled = False
        Me._pctSource_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._pctSource_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._pctSource_2.Image = CType(resources.GetObject("_pctSource_2.Image"), System.Drawing.Image)
        Me.pctSource.SetIndex(Me._pctSource_2, CType(2, Short))
        Me._pctSource_2.Location = New System.Drawing.Point(224, 272)
        Me._pctSource_2.Name = "_pctSource_2"
        Me._pctSource_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._pctSource_2.Size = New System.Drawing.Size(33, 33)
        Me._pctSource_2.TabIndex = 32
        Me._pctSource_2.TabStop = False
        Me._pctSource_2.Visible = False
        '
        '_pctSource_1
        '
        Me._pctSource_1.BackColor = System.Drawing.SystemColors.Control
        Me._pctSource_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._pctSource_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._pctSource_1.Enabled = False
        Me._pctSource_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._pctSource_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._pctSource_1.Image = CType(resources.GetObject("_pctSource_1.Image"), System.Drawing.Image)
        Me.pctSource.SetIndex(Me._pctSource_1, CType(1, Short))
        Me._pctSource_1.Location = New System.Drawing.Point(224, 232)
        Me._pctSource_1.Name = "_pctSource_1"
        Me._pctSource_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._pctSource_1.Size = New System.Drawing.Size(33, 33)
        Me._pctSource_1.TabIndex = 31
        Me._pctSource_1.TabStop = False
        Me._pctSource_1.Visible = False
        '
        'cmdUndo
        '
        Me.cmdUndo.BackColor = System.Drawing.SystemColors.Control
        Me.cmdUndo.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdUndo.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUndo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdUndo.Location = New System.Drawing.Point(8, 296)
        Me.cmdUndo.Name = "cmdUndo"
        Me.cmdUndo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdUndo.Size = New System.Drawing.Size(57, 20)
        Me.cmdUndo.TabIndex = 12
        Me.cmdUndo.Text = "&Undo"
        Me.cmdUndo.UseVisualStyleBackColor = False
        '
        'cmdStartNewGame
        '
        Me.cmdStartNewGame.BackColor = System.Drawing.SystemColors.Control
        Me.cmdStartNewGame.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdStartNewGame.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdStartNewGame.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdStartNewGame.Location = New System.Drawing.Point(24, 56)
        Me.cmdStartNewGame.Name = "cmdStartNewGame"
        Me.cmdStartNewGame.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdStartNewGame.Size = New System.Drawing.Size(89, 25)
        Me.cmdStartNewGame.TabIndex = 2
        Me.cmdStartNewGame.Text = "New &Game"
        Me.cmdStartNewGame.UseVisualStyleBackColor = False
        '
        'cboNumberOfTeams
        '
        Me.cboNumberOfTeams.BackColor = System.Drawing.SystemColors.Window
        Me.cboNumberOfTeams.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboNumberOfTeams.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboNumberOfTeams.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboNumberOfTeams.Location = New System.Drawing.Point(40, 32)
        Me.cboNumberOfTeams.Name = "cboNumberOfTeams"
        Me.cboNumberOfTeams.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboNumberOfTeams.Size = New System.Drawing.Size(57, 22)
        Me.cboNumberOfTeams.TabIndex = 1
        Me.cboNumberOfTeams.Text = "Combo2"
        '
        '_cboPlayerList_0
        '
        Me._cboPlayerList_0.BackColor = System.Drawing.SystemColors.Window
        Me._cboPlayerList_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cboPlayerList_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cboPlayerList_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._cboPlayerList_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboPlayerList.SetIndex(Me._cboPlayerList_0, CType(0, Short))
        Me._cboPlayerList_0.Location = New System.Drawing.Point(152, 40)
        Me._cboPlayerList_0.Name = "_cboPlayerList_0"
        Me._cboPlayerList_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cboPlayerList_0.Size = New System.Drawing.Size(81, 22)
        Me._cboPlayerList_0.Sorted = True
        Me._cboPlayerList_0.TabIndex = 20
        '
        '_pctSource_0
        '
        Me._pctSource_0.BackColor = System.Drawing.SystemColors.Control
        Me._pctSource_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._pctSource_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._pctSource_0.Enabled = False
        Me._pctSource_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._pctSource_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._pctSource_0.Image = CType(resources.GetObject("_pctSource_0.Image"), System.Drawing.Image)
        Me.pctSource.SetIndex(Me._pctSource_0, CType(0, Short))
        Me._pctSource_0.Location = New System.Drawing.Point(224, 192)
        Me._pctSource_0.Name = "_pctSource_0"
        Me._pctSource_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._pctSource_0.Size = New System.Drawing.Size(33, 33)
        Me._pctSource_0.TabIndex = 29
        Me._pctSource_0.TabStop = False
        Me._pctSource_0.Visible = False
        '
        '_pctScoreBox_0
        '
        Me._pctScoreBox_0.BackColor = System.Drawing.SystemColors.Control
        Me._pctScoreBox_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._pctScoreBox_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._pctScoreBox_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._pctScoreBox_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._pctScoreBox_0.Image = CType(resources.GetObject("_pctScoreBox_0.Image"), System.Drawing.Image)
        Me.pctScoreBox.SetIndex(Me._pctScoreBox_0, CType(0, Short))
        Me._pctScoreBox_0.Location = New System.Drawing.Point(176, 112)
        Me._pctScoreBox_0.Name = "_pctScoreBox_0"
        Me._pctScoreBox_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._pctScoreBox_0.Size = New System.Drawing.Size(33, 33)
        Me._pctScoreBox_0.TabIndex = 24
        Me._pctScoreBox_0.TabStop = False
        '
        'lblCurrentHoleLabel
        '
        Me.lblCurrentHoleLabel.BackColor = System.Drawing.SystemColors.Control
        Me.lblCurrentHoleLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCurrentHoleLabel.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentHoleLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCurrentHoleLabel.Location = New System.Drawing.Point(144, 160)
        Me.lblCurrentHoleLabel.Name = "lblCurrentHoleLabel"
        Me.lblCurrentHoleLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCurrentHoleLabel.Size = New System.Drawing.Size(113, 17)
        Me.lblCurrentHoleLabel.TabIndex = 26
        Me.lblCurrentHoleLabel.Text = "Current Hole:"
        '
        'lblCurrentHole
        '
        Me.lblCurrentHole.BackColor = System.Drawing.SystemColors.Control
        Me.lblCurrentHole.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCurrentHole.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentHole.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCurrentHole.Location = New System.Drawing.Point(264, 160)
        Me.lblCurrentHole.Name = "lblCurrentHole"
        Me.lblCurrentHole.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCurrentHole.Size = New System.Drawing.Size(33, 17)
        Me.lblCurrentHole.TabIndex = 27
        Me.lblCurrentHole.Text = "18"
        '
        'lblStartNumber
        '
        Me.lblStartNumber.BackColor = System.Drawing.SystemColors.Control
        Me.lblStartNumber.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblStartNumber.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStartNumber.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblStartNumber.Location = New System.Drawing.Point(16, 88)
        Me.lblStartNumber.Name = "lblStartNumber"
        Me.lblStartNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblStartNumber.Size = New System.Drawing.Size(41, 17)
        Me.lblStartNumber.TabIndex = 3
        Me.lblStartNumber.Text = "Start #"
        '
        'lblCurrentTeam
        '
        Me.lblCurrentTeam.BackColor = System.Drawing.SystemColors.Control
        Me.lblCurrentTeam.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCurrentTeam.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentTeam.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCurrentTeam.Location = New System.Drawing.Point(64, 88)
        Me.lblCurrentTeam.Name = "lblCurrentTeam"
        Me.lblCurrentTeam.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCurrentTeam.Size = New System.Drawing.Size(57, 33)
        Me.lblCurrentTeam.TabIndex = 5
        Me.lblCurrentTeam.Text = "Current Team"
        Me.lblCurrentTeam.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblWinStatus_0
        '
        Me._lblWinStatus_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblWinStatus_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblWinStatus_0.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblWinStatus_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblWinStatus.SetIndex(Me._lblWinStatus_0, CType(0, Short))
        Me._lblWinStatus_0.Location = New System.Drawing.Point(176, 90)
        Me._lblWinStatus_0.Name = "_lblWinStatus_0"
        Me._lblWinStatus_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblWinStatus_0.Size = New System.Drawing.Size(33, 17)
        Me._lblWinStatus_0.TabIndex = 22
        Me._lblWinStatus_0.Text = "Win"
        Me._lblWinStatus_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me._lblWinStatus_0.Visible = False
        '
        'lblScoreMode
        '
        Me.lblScoreMode.BackColor = System.Drawing.SystemColors.Control
        Me.lblScoreMode.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblScoreMode.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScoreMode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblScoreMode.Location = New System.Drawing.Point(288, 96)
        Me.lblScoreMode.Name = "lblScoreMode"
        Me.lblScoreMode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblScoreMode.Size = New System.Drawing.Size(105, 17)
        Me.lblScoreMode.TabIndex = 28
        Me.lblScoreMode.Text = "Relative Scoring"
        Me.lblScoreMode.Visible = False
        '
        '_lblAltScore_0
        '
        Me._lblAltScore_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblAltScore_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblAltScore_0.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblAltScore_0.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblAltScore.SetIndex(Me._lblAltScore_0, CType(0, Short))
        Me._lblAltScore_0.Location = New System.Drawing.Point(168, 400)
        Me._lblAltScore_0.Name = "_lblAltScore_0"
        Me._lblAltScore_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblAltScore_0.Size = New System.Drawing.Size(49, 17)
        Me._lblAltScore_0.TabIndex = 35
        Me._lblAltScore_0.Text = "0"
        Me._lblAltScore_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblNumberOfTeams
        '
        Me.lblNumberOfTeams.BackColor = System.Drawing.SystemColors.Control
        Me.lblNumberOfTeams.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblNumberOfTeams.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumberOfTeams.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblNumberOfTeams.Location = New System.Drawing.Point(16, 8)
        Me.lblNumberOfTeams.Name = "lblNumberOfTeams"
        Me.lblNumberOfTeams.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblNumberOfTeams.Size = New System.Drawing.Size(121, 17)
        Me.lblNumberOfTeams.TabIndex = 0
        Me.lblNumberOfTeams.Text = "Number of Teams"
        '
        '_lblScore_0
        '
        Me._lblScore_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblScore_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblScore_0.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblScore_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblScore.SetIndex(Me._lblScore_0, CType(0, Short))
        Me._lblScore_0.Location = New System.Drawing.Point(168, 368)
        Me._lblScore_0.Name = "_lblScore_0"
        Me._lblScore_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblScore_0.Size = New System.Drawing.Size(49, 17)
        Me._lblScore_0.TabIndex = 30
        Me._lblScore_0.Text = "0"
        Me._lblScore_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lblStatus.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblStatus.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblStatus.Location = New System.Drawing.Point(8, 400)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblStatus.Size = New System.Drawing.Size(121, 25)
        Me.lblStatus.TabIndex = 18
        Me.lblStatus.Text = "Ready"
        '
        '_lblTeamName_0
        '
        Me._lblTeamName_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblTeamName_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTeamName_0.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblTeamName_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTeamName.SetIndex(Me._lblTeamName_0, CType(0, Short))
        Me._lblTeamName_0.Location = New System.Drawing.Point(160, 8)
        Me._lblTeamName_0.Name = "_lblTeamName_0"
        Me._lblTeamName_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTeamName_0.Size = New System.Drawing.Size(65, 17)
        Me._lblTeamName_0.TabIndex = 19
        Me._lblTeamName_0.Text = "Team 1"
        Me._lblTeamName_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblBoxName_0
        '
        Me._lblBoxName_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblBoxName_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblBoxName_0.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblBoxName_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBoxName.SetIndex(Me._lblBoxName_0, CType(0, Short))
        Me._lblBoxName_0.Location = New System.Drawing.Point(144, 120)
        Me._lblBoxName_0.Name = "_lblBoxName_0"
        Me._lblBoxName_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblBoxName_0.Size = New System.Drawing.Size(32, 17)
        Me._lblBoxName_0.TabIndex = 23
        Me._lblBoxName_0.Text = "20"
        Me._lblBoxName_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cboPlayerList
        '
        '
        'frmCricket
        '
        Me.AcceptButton = Me.cmdNextTeam
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(451, 429)
        Me.Controls.Add(Me.cmdShowRealtimeStatistics)
        Me.Controls.Add(Me._pctSourceSmall_0)
        Me.Controls.Add(Me._pctSourceSmall_1)
        Me.Controls.Add(Me._pctSourceSmall_2)
        Me.Controls.Add(Me._pctSourceSmall_3)
        Me.Controls.Add(Me._pctSourceSmall_4)
        Me.Controls.Add(Me._pctSourceSmall_9)
        Me.Controls.Add(Me._pctSourceSmall_8)
        Me.Controls.Add(Me._pctSourceSmall_7)
        Me.Controls.Add(Me._pctSourceSmall_6)
        Me.Controls.Add(Me._pctSourceSmall_5)
        Me.Controls.Add(Me.cmdScoreMode)
        Me.Controls.Add(Me.chkDoubleIn)
        Me.Controls.Add(Me.txtStartNumber)
        Me.Controls.Add(Me.chkDoubleOut)
        Me.Controls.Add(Me.lstCurrentTeam)
        Me.Controls.Add(Me.cmdNextTeam)
        Me.Controls.Add(Me.cmdPreviousTeam)
        Me.Controls.Add(Me.cmdShowDartBoard)
        Me.Controls.Add(Me.cmdHelp)
        Me.Controls.Add(Me._pctSource_5)
        Me.Controls.Add(Me._pctSource_6)
        Me.Controls.Add(Me._pctSource_7)
        Me.Controls.Add(Me._pctSource_8)
        Me.Controls.Add(Me._pctSource_9)
        Me.Controls.Add(Me.txtHitCount)
        Me.Controls.Add(Me.cmdRedo)
        Me.Controls.Add(Me._pctSource_4)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me._cboPlayerList_1)
        Me.Controls.Add(Me._pctSource_3)
        Me.Controls.Add(Me._pctSource_2)
        Me.Controls.Add(Me._pctSource_1)
        Me.Controls.Add(Me.cmdUndo)
        Me.Controls.Add(Me.cmdStartNewGame)
        Me.Controls.Add(Me.cboNumberOfTeams)
        Me.Controls.Add(Me._cboPlayerList_0)
        Me.Controls.Add(Me._pctSource_0)
        Me.Controls.Add(Me._pctScoreBox_0)
        Me.Controls.Add(Me.lblCurrentHoleLabel)
        Me.Controls.Add(Me.lblCurrentHole)
        Me.Controls.Add(Me.lblStartNumber)
        Me.Controls.Add(Me.lblCurrentTeam)
        Me.Controls.Add(Me._lblWinStatus_0)
        Me.Controls.Add(Me.lblScoreMode)
        Me.Controls.Add(Me._lblAltScore_0)
        Me.Controls.Add(Me.lblNumberOfTeams)
        Me.Controls.Add(Me._lblScore_0)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me._lblTeamName_0)
        Me.Controls.Add(Me._lblBoxName_0)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(166, 133)
        Me.Name = "frmCricket"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Cricket"
        CType(Me._pctSourceSmall_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._pctSourceSmall_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._pctSourceSmall_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._pctSourceSmall_3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._pctSourceSmall_4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._pctSourceSmall_9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._pctSourceSmall_8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._pctSourceSmall_7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._pctSourceSmall_6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._pctSourceSmall_5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._pctSource_5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._pctSource_6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._pctSource_7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._pctSource_8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._pctSource_9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._pctSource_4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._pctSource_3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._pctSource_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._pctSource_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._pctSource_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._pctScoreBox_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPlayerList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblAltScore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblBoxName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblScore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTeamName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblWinStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctScoreBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctSourceSmall, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region 
End Class