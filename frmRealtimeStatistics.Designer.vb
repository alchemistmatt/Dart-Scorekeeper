<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmRealtimeStatistics
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
	Public WithEvents chkReverseSort As System.Windows.Forms.CheckBox
	Public WithEvents cmdOK As System.Windows.Forms.Button
	Public WithEvents lstPlayers As System.Windows.Forms.ListBox
	Public WithEvents lstMeanScorePerThrow As System.Windows.Forms.ListBox
	Public WithEvents lblPlayer As System.Windows.Forms.Label
	Public WithEvents lblMeanScorePerThrow As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRealtimeStatistics))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblPlayer = New System.Windows.Forms.Label
        Me.lblMeanScorePerThrow = New System.Windows.Forms.Label
        Me.chkReverseSort = New System.Windows.Forms.CheckBox
        Me.cmdOK = New System.Windows.Forms.Button
        Me.lstPlayers = New System.Windows.Forms.ListBox
        Me.lstMeanScorePerThrow = New System.Windows.Forms.ListBox
        Me.SuspendLayout()
        '
        'lblPlayer
        '
        Me.lblPlayer.BackColor = System.Drawing.SystemColors.Control
        Me.lblPlayer.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPlayer.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlayer.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPlayer.Location = New System.Drawing.Point(24, 24)
        Me.lblPlayer.Name = "lblPlayer"
        Me.lblPlayer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPlayer.Size = New System.Drawing.Size(57, 17)
        Me.lblPlayer.TabIndex = 3
        Me.lblPlayer.Text = "Player"
        Me.lblPlayer.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.lblPlayer, "Click here to resort")
        '
        'lblMeanScorePerThrow
        '
        Me.lblMeanScorePerThrow.BackColor = System.Drawing.SystemColors.Control
        Me.lblMeanScorePerThrow.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblMeanScorePerThrow.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMeanScorePerThrow.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMeanScorePerThrow.Location = New System.Drawing.Point(120, 0)
        Me.lblMeanScorePerThrow.Name = "lblMeanScorePerThrow"
        Me.lblMeanScorePerThrow.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblMeanScorePerThrow.Size = New System.Drawing.Size(65, 49)
        Me.lblMeanScorePerThrow.TabIndex = 2
        Me.lblMeanScorePerThrow.Text = "Mean Score Per Throw"
        Me.lblMeanScorePerThrow.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.lblMeanScorePerThrow, "Click here to resort")
        '
        'chkReverseSort
        '
        Me.chkReverseSort.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkReverseSort.BackColor = System.Drawing.SystemColors.Control
        Me.chkReverseSort.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkReverseSort.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkReverseSort.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkReverseSort.Location = New System.Drawing.Point(104, 188)
        Me.chkReverseSort.Name = "chkReverseSort"
        Me.chkReverseSort.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkReverseSort.Size = New System.Drawing.Size(89, 17)
        Me.chkReverseSort.TabIndex = 5
        Me.chkReverseSort.Text = "&Reverse Sort"
        Me.chkReverseSort.UseVisualStyleBackColor = False
        '
        'cmdOK
        '
        Me.cmdOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOK.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Location = New System.Drawing.Point(24, 184)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOK.Size = New System.Drawing.Size(57, 25)
        Me.cmdOK.TabIndex = 4
        Me.cmdOK.Text = "&Close"
        Me.cmdOK.UseVisualStyleBackColor = False
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
        Me.lstPlayers.Location = New System.Drawing.Point(8, 56)
        Me.lstPlayers.Name = "lstPlayers"
        Me.lstPlayers.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstPlayers.Size = New System.Drawing.Size(97, 116)
        Me.lstPlayers.TabIndex = 1
        '
        'lstMeanScorePerThrow
        '
        Me.lstMeanScorePerThrow.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstMeanScorePerThrow.BackColor = System.Drawing.SystemColors.Window
        Me.lstMeanScorePerThrow.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstMeanScorePerThrow.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstMeanScorePerThrow.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstMeanScorePerThrow.ItemHeight = 14
        Me.lstMeanScorePerThrow.Location = New System.Drawing.Point(120, 56)
        Me.lstMeanScorePerThrow.Name = "lstMeanScorePerThrow"
        Me.lstMeanScorePerThrow.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstMeanScorePerThrow.Size = New System.Drawing.Size(57, 116)
        Me.lstMeanScorePerThrow.TabIndex = 0
        '
        'frmRealtimeStatistics
        '
        Me.AcceptButton = Me.cmdOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(197, 217)
        Me.ControlBox = False
        Me.Controls.Add(Me.chkReverseSort)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.lstPlayers)
        Me.Controls.Add(Me.lstMeanScorePerThrow)
        Me.Controls.Add(Me.lblPlayer)
        Me.Controls.Add(Me.lblMeanScorePerThrow)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(3, 21)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(6, 133)
        Me.Name = "frmRealtimeStatistics"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.Text = "Real-time Statistics"
        Me.ResumeLayout(False)

    End Sub
#End Region 
End Class