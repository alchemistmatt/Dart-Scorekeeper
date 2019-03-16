Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()> Partial Class frmDartBoard
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
    Public WithEvents cmdClose As System.Windows.Forms.Button
    Public WithEvents pctDartBoardSourcePicLarge As System.Windows.Forms.PictureBox
    Public WithEvents pctDartBoardSourcePicMedium As System.Windows.Forms.PictureBox
    Public WithEvents pctDartBoardSourcePicSmall As System.Windows.Forms.PictureBox
    Public WithEvents pctDartBoardSourcePicTiny As System.Windows.Forms.PictureBox
    Public WithEvents tmrShowDart As System.Windows.Forms.Timer
    Public WithEvents lblDirections As System.Windows.Forms.Label
    Public WithEvents lblCurrentPlayer As System.Windows.Forms.Label
    Public WithEvents pctDartBoard As System.Windows.Forms.Panel
    Public WithEvents cmdRedo As System.Windows.Forms.Button
    Public WithEvents cmdUndo As System.Windows.Forms.Button
    Public WithEvents fraUndoRedo As System.Windows.Forms.Panel
    Public WithEvents cmdNextTeam As System.Windows.Forms.Button
    Public WithEvents cmdPreviousTeam As System.Windows.Forms.Button
    Public WithEvents fraPreviousNext As System.Windows.Forms.Panel
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDartBoard))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.pctDartBoardSourcePicLarge = New System.Windows.Forms.PictureBox()
        Me.pctDartBoardSourcePicMedium = New System.Windows.Forms.PictureBox()
        Me.pctDartBoardSourcePicSmall = New System.Windows.Forms.PictureBox()
        Me.pctDartBoardSourcePicTiny = New System.Windows.Forms.PictureBox()
        Me.tmrShowDart = New System.Windows.Forms.Timer(Me.components)
        Me.pctDartBoard = New System.Windows.Forms.Panel()
        Me.lblDartScore2 = New System.Windows.Forms.Label()
        Me.lblDartScore1 = New System.Windows.Forms.Label()
        Me.lblDartScore0 = New System.Windows.Forms.Label()
        Me.shpDart2 = New System.Windows.Forms.PictureBox()
        Me.shpDart1 = New System.Windows.Forms.PictureBox()
        Me.shpDart0 = New System.Windows.Forms.PictureBox()
        Me.lblDirections = New System.Windows.Forms.Label()
        Me.lblCurrentPlayer = New System.Windows.Forms.Label()
        Me.fraUndoRedo = New System.Windows.Forms.Panel()
        Me.cmdRedo = New System.Windows.Forms.Button()
        Me.cmdUndo = New System.Windows.Forms.Button()
        Me.fraPreviousNext = New System.Windows.Forms.Panel()
        Me.cmdNextTeam = New System.Windows.Forms.Button()
        Me.cmdPreviousTeam = New System.Windows.Forms.Button()
        Me.lblMouseCoord = New System.Windows.Forms.Label()
        Me.chkShowMousePos = New System.Windows.Forms.CheckBox()
        CType(Me.pctDartBoardSourcePicLarge, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctDartBoardSourcePicMedium, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctDartBoardSourcePicSmall, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctDartBoardSourcePicTiny, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pctDartBoard.SuspendLayout()
        CType(Me.shpDart2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.shpDart1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.shpDart0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraUndoRedo.SuspendLayout()
        Me.fraPreviousNext.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClose.Location = New System.Drawing.Point(520, 592)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClose.Size = New System.Drawing.Size(57, 25)
        Me.cmdClose.TabIndex = 7
        Me.cmdClose.Text = "&Close"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'pctDartBoardSourcePicLarge
        '
        Me.pctDartBoardSourcePicLarge.BackColor = System.Drawing.SystemColors.Control
        Me.pctDartBoardSourcePicLarge.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pctDartBoardSourcePicLarge.Cursor = System.Windows.Forms.Cursors.Default
        Me.pctDartBoardSourcePicLarge.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pctDartBoardSourcePicLarge.ForeColor = System.Drawing.SystemColors.ControlText
        Me.pctDartBoardSourcePicLarge.Image = CType(resources.GetObject("pctDartBoardSourcePicLarge.Image"), System.Drawing.Image)
        Me.pctDartBoardSourcePicLarge.Location = New System.Drawing.Point(352, 632)
        Me.pctDartBoardSourcePicLarge.Name = "pctDartBoardSourcePicLarge"
        Me.pctDartBoardSourcePicLarge.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.pctDartBoardSourcePicLarge.Size = New System.Drawing.Size(105, 65)
        Me.pctDartBoardSourcePicLarge.TabIndex = 16
        Me.pctDartBoardSourcePicLarge.TabStop = False
        Me.pctDartBoardSourcePicLarge.Visible = False
        '
        'pctDartBoardSourcePicMedium
        '
        Me.pctDartBoardSourcePicMedium.BackColor = System.Drawing.SystemColors.Control
        Me.pctDartBoardSourcePicMedium.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pctDartBoardSourcePicMedium.Cursor = System.Windows.Forms.Cursors.Default
        Me.pctDartBoardSourcePicMedium.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pctDartBoardSourcePicMedium.ForeColor = System.Drawing.SystemColors.ControlText
        Me.pctDartBoardSourcePicMedium.Image = CType(resources.GetObject("pctDartBoardSourcePicMedium.Image"), System.Drawing.Image)
        Me.pctDartBoardSourcePicMedium.Location = New System.Drawing.Point(240, 632)
        Me.pctDartBoardSourcePicMedium.Name = "pctDartBoardSourcePicMedium"
        Me.pctDartBoardSourcePicMedium.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.pctDartBoardSourcePicMedium.Size = New System.Drawing.Size(105, 65)
        Me.pctDartBoardSourcePicMedium.TabIndex = 15
        Me.pctDartBoardSourcePicMedium.TabStop = False
        Me.pctDartBoardSourcePicMedium.Visible = False
        '
        'pctDartBoardSourcePicSmall
        '
        Me.pctDartBoardSourcePicSmall.BackColor = System.Drawing.SystemColors.Control
        Me.pctDartBoardSourcePicSmall.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pctDartBoardSourcePicSmall.Cursor = System.Windows.Forms.Cursors.Default
        Me.pctDartBoardSourcePicSmall.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pctDartBoardSourcePicSmall.ForeColor = System.Drawing.SystemColors.ControlText
        Me.pctDartBoardSourcePicSmall.Image = CType(resources.GetObject("pctDartBoardSourcePicSmall.Image"), System.Drawing.Image)
        Me.pctDartBoardSourcePicSmall.Location = New System.Drawing.Point(128, 632)
        Me.pctDartBoardSourcePicSmall.Name = "pctDartBoardSourcePicSmall"
        Me.pctDartBoardSourcePicSmall.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.pctDartBoardSourcePicSmall.Size = New System.Drawing.Size(105, 65)
        Me.pctDartBoardSourcePicSmall.TabIndex = 14
        Me.pctDartBoardSourcePicSmall.TabStop = False
        Me.pctDartBoardSourcePicSmall.Visible = False
        '
        'pctDartBoardSourcePicTiny
        '
        Me.pctDartBoardSourcePicTiny.BackColor = System.Drawing.SystemColors.Control
        Me.pctDartBoardSourcePicTiny.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pctDartBoardSourcePicTiny.Cursor = System.Windows.Forms.Cursors.Default
        Me.pctDartBoardSourcePicTiny.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pctDartBoardSourcePicTiny.ForeColor = System.Drawing.SystemColors.ControlText
        Me.pctDartBoardSourcePicTiny.Image = CType(resources.GetObject("pctDartBoardSourcePicTiny.Image"), System.Drawing.Image)
        Me.pctDartBoardSourcePicTiny.Location = New System.Drawing.Point(16, 632)
        Me.pctDartBoardSourcePicTiny.Name = "pctDartBoardSourcePicTiny"
        Me.pctDartBoardSourcePicTiny.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.pctDartBoardSourcePicTiny.Size = New System.Drawing.Size(105, 65)
        Me.pctDartBoardSourcePicTiny.TabIndex = 13
        Me.pctDartBoardSourcePicTiny.TabStop = False
        Me.pctDartBoardSourcePicTiny.Visible = False
        '
        'tmrShowDart
        '
        Me.tmrShowDart.Enabled = True
        Me.tmrShowDart.Interval = 500
        '
        'pctDartBoard
        '
        Me.pctDartBoard.BackColor = System.Drawing.SystemColors.Control
        Me.pctDartBoard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pctDartBoard.Controls.Add(Me.lblDartScore2)
        Me.pctDartBoard.Controls.Add(Me.lblDartScore1)
        Me.pctDartBoard.Controls.Add(Me.lblDartScore0)
        Me.pctDartBoard.Controls.Add(Me.shpDart2)
        Me.pctDartBoard.Controls.Add(Me.shpDart1)
        Me.pctDartBoard.Controls.Add(Me.shpDart0)
        Me.pctDartBoard.Controls.Add(Me.lblDirections)
        Me.pctDartBoard.Controls.Add(Me.lblCurrentPlayer)
        Me.pctDartBoard.Cursor = System.Windows.Forms.Cursors.Default
        Me.pctDartBoard.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pctDartBoard.ForeColor = System.Drawing.SystemColors.ControlText
        Me.pctDartBoard.Location = New System.Drawing.Point(0, 0)
        Me.pctDartBoard.Name = "pctDartBoard"
        Me.pctDartBoard.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.pctDartBoard.Size = New System.Drawing.Size(585, 586)
        Me.pctDartBoard.TabIndex = 0
        Me.pctDartBoard.TabStop = True
        '
        'lblDartScore2
        '
        Me.lblDartScore2.AutoSize = True
        Me.lblDartScore2.BackColor = System.Drawing.SystemColors.Window
        Me.lblDartScore2.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDartScore2.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDartScore2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDartScore2.Location = New System.Drawing.Point(10, 541)
        Me.lblDartScore2.Name = "lblDartScore2"
        Me.lblDartScore2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDartScore2.Size = New System.Drawing.Size(150, 27)
        Me.lblDartScore2.TabIndex = 18
        Me.lblDartScore2.Text = "Dart Score"
        '
        'lblDartScore1
        '
        Me.lblDartScore1.AutoSize = True
        Me.lblDartScore1.BackColor = System.Drawing.SystemColors.Window
        Me.lblDartScore1.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDartScore1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDartScore1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDartScore1.Location = New System.Drawing.Point(10, 519)
        Me.lblDartScore1.Name = "lblDartScore1"
        Me.lblDartScore1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDartScore1.Size = New System.Drawing.Size(150, 27)
        Me.lblDartScore1.TabIndex = 17
        Me.lblDartScore1.Text = "Dart Score"
        '
        'lblDartScore0
        '
        Me.lblDartScore0.AutoSize = True
        Me.lblDartScore0.BackColor = System.Drawing.SystemColors.Window
        Me.lblDartScore0.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDartScore0.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDartScore0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDartScore0.Location = New System.Drawing.Point(10, 497)
        Me.lblDartScore0.Name = "lblDartScore0"
        Me.lblDartScore0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDartScore0.Size = New System.Drawing.Size(150, 27)
        Me.lblDartScore0.TabIndex = 16
        Me.lblDartScore0.Text = "Dart Score"
        '
        'shpDart2
        '
        Me.shpDart2.BackColor = System.Drawing.Color.Blue
        Me.shpDart2.InitialImage = CType(resources.GetObject("shpDart2.InitialImage"), System.Drawing.Image)
        Me.shpDart2.Location = New System.Drawing.Point(14, 367)
        Me.shpDart2.Name = "shpDart2"
        Me.shpDart2.Size = New System.Drawing.Size(13, 13)
        Me.shpDart2.TabIndex = 15
        Me.shpDart2.TabStop = False
        '
        'shpDart1
        '
        Me.shpDart1.BackColor = System.Drawing.Color.Blue
        Me.shpDart1.InitialImage = CType(resources.GetObject("shpDart1.InitialImage"), System.Drawing.Image)
        Me.shpDart1.Location = New System.Drawing.Point(14, 348)
        Me.shpDart1.Name = "shpDart1"
        Me.shpDart1.Size = New System.Drawing.Size(13, 13)
        Me.shpDart1.TabIndex = 14
        Me.shpDart1.TabStop = False
        '
        'shpDart0
        '
        Me.shpDart0.BackColor = System.Drawing.Color.Blue
        Me.shpDart0.InitialImage = CType(resources.GetObject("shpDart0.InitialImage"), System.Drawing.Image)
        Me.shpDart0.Location = New System.Drawing.Point(14, 329)
        Me.shpDart0.Name = "shpDart0"
        Me.shpDart0.Size = New System.Drawing.Size(13, 13)
        Me.shpDart0.TabIndex = 13
        Me.shpDart0.TabStop = False
        '
        'lblDirections
        '
        Me.lblDirections.BackColor = System.Drawing.SystemColors.Window
        Me.lblDirections.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDirections.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDirections.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDirections.Location = New System.Drawing.Point(464, 552)
        Me.lblDirections.Name = "lblDirections"
        Me.lblDirections.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDirections.Size = New System.Drawing.Size(115, 28)
        Me.lblDirections.TabIndex = 12
        Me.lblDirections.Text = "Left click to place dart. Right click to undo."
        '
        'lblCurrentPlayer
        '
        Me.lblCurrentPlayer.BackColor = System.Drawing.Color.Transparent
        Me.lblCurrentPlayer.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCurrentPlayer.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentPlayer.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCurrentPlayer.Location = New System.Drawing.Point(8, 0)
        Me.lblCurrentPlayer.Name = "lblCurrentPlayer"
        Me.lblCurrentPlayer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCurrentPlayer.Size = New System.Drawing.Size(185, 41)
        Me.lblCurrentPlayer.TabIndex = 8
        Me.lblCurrentPlayer.Text = "Player"
        '
        'fraUndoRedo
        '
        Me.fraUndoRedo.BackColor = System.Drawing.SystemColors.Control
        Me.fraUndoRedo.Controls.Add(Me.cmdRedo)
        Me.fraUndoRedo.Controls.Add(Me.cmdUndo)
        Me.fraUndoRedo.Cursor = System.Windows.Forms.Cursors.Default
        Me.fraUndoRedo.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraUndoRedo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraUndoRedo.Location = New System.Drawing.Point(224, 592)
        Me.fraUndoRedo.Name = "fraUndoRedo"
        Me.fraUndoRedo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraUndoRedo.Size = New System.Drawing.Size(129, 25)
        Me.fraUndoRedo.TabIndex = 4
        '
        'cmdRedo
        '
        Me.cmdRedo.BackColor = System.Drawing.SystemColors.Control
        Me.cmdRedo.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdRedo.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRedo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdRedo.Location = New System.Drawing.Point(72, 0)
        Me.cmdRedo.Name = "cmdRedo"
        Me.cmdRedo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdRedo.Size = New System.Drawing.Size(57, 25)
        Me.cmdRedo.TabIndex = 6
        Me.cmdRedo.Text = "&Redo"
        Me.cmdRedo.UseVisualStyleBackColor = False
        '
        'cmdUndo
        '
        Me.cmdUndo.BackColor = System.Drawing.SystemColors.Control
        Me.cmdUndo.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdUndo.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUndo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdUndo.Location = New System.Drawing.Point(0, 0)
        Me.cmdUndo.Name = "cmdUndo"
        Me.cmdUndo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdUndo.Size = New System.Drawing.Size(57, 25)
        Me.cmdUndo.TabIndex = 5
        Me.cmdUndo.Text = "&Undo"
        Me.cmdUndo.UseVisualStyleBackColor = False
        '
        'fraPreviousNext
        '
        Me.fraPreviousNext.BackColor = System.Drawing.SystemColors.Control
        Me.fraPreviousNext.Controls.Add(Me.cmdNextTeam)
        Me.fraPreviousNext.Controls.Add(Me.cmdPreviousTeam)
        Me.fraPreviousNext.Cursor = System.Windows.Forms.Cursors.Default
        Me.fraPreviousNext.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraPreviousNext.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraPreviousNext.Location = New System.Drawing.Point(8, 592)
        Me.fraPreviousNext.Name = "fraPreviousNext"
        Me.fraPreviousNext.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraPreviousNext.Size = New System.Drawing.Size(137, 25)
        Me.fraPreviousNext.TabIndex = 1
        '
        'cmdNextTeam
        '
        Me.cmdNextTeam.BackColor = System.Drawing.SystemColors.Control
        Me.cmdNextTeam.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdNextTeam.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNextTeam.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdNextTeam.Location = New System.Drawing.Point(72, 0)
        Me.cmdNextTeam.Name = "cmdNextTeam"
        Me.cmdNextTeam.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdNextTeam.Size = New System.Drawing.Size(65, 25)
        Me.cmdNextTeam.TabIndex = 3
        Me.cmdNextTeam.Text = "&Next"
        Me.cmdNextTeam.UseVisualStyleBackColor = False
        '
        'cmdPreviousTeam
        '
        Me.cmdPreviousTeam.BackColor = System.Drawing.SystemColors.Control
        Me.cmdPreviousTeam.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdPreviousTeam.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPreviousTeam.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdPreviousTeam.Location = New System.Drawing.Point(0, 0)
        Me.cmdPreviousTeam.Name = "cmdPreviousTeam"
        Me.cmdPreviousTeam.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdPreviousTeam.Size = New System.Drawing.Size(65, 25)
        Me.cmdPreviousTeam.TabIndex = 2
        Me.cmdPreviousTeam.Text = "&Previous"
        Me.cmdPreviousTeam.UseVisualStyleBackColor = False
        '
        'lblMouseCoord
        '
        Me.lblMouseCoord.AutoSize = True
        Me.lblMouseCoord.Location = New System.Drawing.Point(373, 615)
        Me.lblMouseCoord.Name = "lblMouseCoord"
        Me.lblMouseCoord.Size = New System.Drawing.Size(107, 16)
        Me.lblMouseCoord.TabIndex = 21
        Me.lblMouseCoord.Text = "Mouse Pos: x, y"
        Me.lblMouseCoord.Visible = False
        '
        'chkShowMousePos
        '
        Me.chkShowMousePos.AutoSize = True
        Me.chkShowMousePos.Location = New System.Drawing.Point(376, 592)
        Me.chkShowMousePos.Name = "chkShowMousePos"
        Me.chkShowMousePos.Size = New System.Drawing.Size(164, 20)
        Me.chkShowMousePos.TabIndex = 22
        Me.chkShowMousePos.Text = "Show Mouse Position"
        Me.chkShowMousePos.UseVisualStyleBackColor = True
        '
        'frmDartBoard
        '
        Me.AcceptButton = Me.cmdNextTeam
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(594, 703)
        Me.Controls.Add(Me.chkShowMousePos)
        Me.Controls.Add(Me.lblMouseCoord)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.pctDartBoardSourcePicLarge)
        Me.Controls.Add(Me.pctDartBoardSourcePicMedium)
        Me.Controls.Add(Me.pctDartBoardSourcePicSmall)
        Me.Controls.Add(Me.pctDartBoardSourcePicTiny)
        Me.Controls.Add(Me.pctDartBoard)
        Me.Controls.Add(Me.fraUndoRedo)
        Me.Controls.Add(Me.fraPreviousNext)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(4, 23)
        Me.MaximizeBox = False
        Me.Name = "frmDartBoard"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Dart Board"
        CType(Me.pctDartBoardSourcePicLarge, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctDartBoardSourcePicMedium, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctDartBoardSourcePicSmall, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctDartBoardSourcePicTiny, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pctDartBoard.ResumeLayout(False)
        Me.pctDartBoard.PerformLayout()
        CType(Me.shpDart2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.shpDart1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.shpDart0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraUndoRedo.ResumeLayout(False)
        Me.fraPreviousNext.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents shpDart2 As System.Windows.Forms.PictureBox
    Friend WithEvents shpDart1 As System.Windows.Forms.PictureBox
    Friend WithEvents shpDart0 As System.Windows.Forms.PictureBox
    Public WithEvents lblDartScore2 As System.Windows.Forms.Label
    Public WithEvents lblDartScore1 As System.Windows.Forms.Label
    Public WithEvents lblDartScore0 As System.Windows.Forms.Label
    Friend WithEvents lblMouseCoord As System.Windows.Forms.Label
    Friend WithEvents chkShowMousePos As System.Windows.Forms.CheckBox
#End Region
End Class