Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()> Partial Class frmPlayerStatsZoom
#Region "Windows Form Designer generated code "
    <System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        Me.lblMonth = New clsLabelArray(Me, "Month")
        Me.lblPercentValue = New clsLabelArray(Me, "PercentValue")
        Me.lblWinRatio = New clsLabelArray(Me, "WinRatio")

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
    Public WithEvents txtStartMonth As System.Windows.Forms.TextBox
    Public WithEvents cmdPreviousPlayer As System.Windows.Forms.Button
    Public WithEvents cmdNextPlayer As System.Windows.Forms.Button
    Public WithEvents cmdOK As System.Windows.Forms.Button
    Public WithEvents lblStartMonth As System.Windows.Forms.Label
    Public WithEvents lblPlayer As System.Windows.Forms.Label
    Public WithEvents shpBorder As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Public WithEvents _lblPercentValue_4 As System.Windows.Forms.Label
    Public WithEvents _lblPercentValue_3 As System.Windows.Forms.Label
    Public WithEvents _lblPercentValue_2 As System.Windows.Forms.Label
    Public WithEvents _lblPercentValue_1 As System.Windows.Forms.Label
    Public WithEvents _lblPercentValue_0 As System.Windows.Forms.Label
    Public WithEvents lblMonth As clsLabelArray
    Public WithEvents lblPercentValue As clsLabelArray
    Public WithEvents lblWinRatio As clsLabelArray
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPlayerStatsZoom))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtStartMonth = New System.Windows.Forms.TextBox
        Me.cmdPreviousPlayer = New System.Windows.Forms.Button
        Me.cmdNextPlayer = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
        Me.lblStartMonth = New System.Windows.Forms.Label
        Me.lblPlayer = New System.Windows.Forms.Label
        Me.shpBorder = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        Me._lblPercentValue_4 = New System.Windows.Forms.Label
        Me._lblPercentValue_3 = New System.Windows.Forms.Label
        Me._lblPercentValue_2 = New System.Windows.Forms.Label
        Me._lblPercentValue_1 = New System.Windows.Forms.Label
        Me._lblPercentValue_0 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'txtStartMonth
        '
        Me.txtStartMonth.AcceptsReturn = True
        Me.txtStartMonth.BackColor = System.Drawing.SystemColors.Window
        Me.txtStartMonth.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStartMonth.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.txtStartMonth.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStartMonth.Location = New System.Drawing.Point(72, 256)
        Me.txtStartMonth.MaxLength = 0
        Me.txtStartMonth.Name = "txtStartMonth"
        Me.txtStartMonth.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStartMonth.Size = New System.Drawing.Size(57, 19)
        Me.txtStartMonth.TabIndex = 11
        Me.txtStartMonth.Text = "1/1999"
        '
        'cmdPreviousPlayer
        '
        Me.cmdPreviousPlayer.BackColor = System.Drawing.SystemColors.Control
        Me.cmdPreviousPlayer.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdPreviousPlayer.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.cmdPreviousPlayer.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdPreviousPlayer.Location = New System.Drawing.Point(144, 256)
        Me.cmdPreviousPlayer.Name = "cmdPreviousPlayer"
        Me.cmdPreviousPlayer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdPreviousPlayer.Size = New System.Drawing.Size(97, 25)
        Me.cmdPreviousPlayer.TabIndex = 0
        Me.cmdPreviousPlayer.Text = "&Previous Player"
        Me.cmdPreviousPlayer.UseVisualStyleBackColor = False
        '
        'cmdNextPlayer
        '
        Me.cmdNextPlayer.BackColor = System.Drawing.SystemColors.Control
        Me.cmdNextPlayer.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdNextPlayer.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.cmdNextPlayer.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdNextPlayer.Location = New System.Drawing.Point(248, 256)
        Me.cmdNextPlayer.Name = "cmdNextPlayer"
        Me.cmdNextPlayer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdNextPlayer.Size = New System.Drawing.Size(97, 25)
        Me.cmdNextPlayer.TabIndex = 1
        Me.cmdNextPlayer.Text = "&Next Player"
        Me.cmdNextPlayer.UseVisualStyleBackColor = False
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdOK.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Location = New System.Drawing.Point(408, 256)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOK.Size = New System.Drawing.Size(57, 25)
        Me.cmdOK.TabIndex = 2
        Me.cmdOK.Text = "&Close"
        Me.cmdOK.UseVisualStyleBackColor = False
        '
        'lblStartMonth
        '
        Me.lblStartMonth.BackColor = System.Drawing.SystemColors.Control
        Me.lblStartMonth.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblStartMonth.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.lblStartMonth.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblStartMonth.Location = New System.Drawing.Point(8, 258)
        Me.lblStartMonth.Name = "lblStartMonth"
        Me.lblStartMonth.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblStartMonth.Size = New System.Drawing.Size(65, 17)
        Me.lblStartMonth.TabIndex = 12
        Me.lblStartMonth.Text = "Start Month:"
        '
        'lblPlayer
        '
        Me.lblPlayer.BackColor = System.Drawing.SystemColors.Control
        Me.lblPlayer.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPlayer.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.lblPlayer.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPlayer.Location = New System.Drawing.Point(72, 0)
        Me.lblPlayer.Name = "lblPlayer"
        Me.lblPlayer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPlayer.Size = New System.Drawing.Size(385, 17)
        Me.lblPlayer.TabIndex = 9
        Me.lblPlayer.Text = "Player"
        Me.lblPlayer.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'shpBorder
        '
        Me.shpBorder.BackColor = System.Drawing.SystemColors.Window
        Me.shpBorder.BorderColor = System.Drawing.Color.Blue
        Me.shpBorder.FillColor = System.Drawing.Color.Black
        Me.shpBorder.Location = New System.Drawing.Point(48, 24)
        Me.shpBorder.Name = "shpBorder"
        Me.shpBorder.Size = New System.Drawing.Size(489, 201)
        '
        '_lblPercentValue_4
        '
        Me._lblPercentValue_4.BackColor = System.Drawing.SystemColors.Control
        Me._lblPercentValue_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblPercentValue_4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me._lblPercentValue_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblPercentValue_4.Location = New System.Drawing.Point(8, 16)
        Me._lblPercentValue_4.Name = "_lblPercentValue_4"
        Me._lblPercentValue_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblPercentValue_4.Size = New System.Drawing.Size(41, 17)
        Me._lblPercentValue_4.TabIndex = 7
        Me._lblPercentValue_4.Text = "100%"
        '
        '_lblPercentValue_3
        '
        Me._lblPercentValue_3.BackColor = System.Drawing.SystemColors.Control
        Me._lblPercentValue_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblPercentValue_3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me._lblPercentValue_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblPercentValue_3.Location = New System.Drawing.Point(8, 64)
        Me._lblPercentValue_3.Name = "_lblPercentValue_3"
        Me._lblPercentValue_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblPercentValue_3.Size = New System.Drawing.Size(41, 17)
        Me._lblPercentValue_3.TabIndex = 6
        Me._lblPercentValue_3.Text = "75%"
        '
        '_lblPercentValue_2
        '
        Me._lblPercentValue_2.BackColor = System.Drawing.SystemColors.Control
        Me._lblPercentValue_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblPercentValue_2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me._lblPercentValue_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblPercentValue_2.Location = New System.Drawing.Point(8, 112)
        Me._lblPercentValue_2.Name = "_lblPercentValue_2"
        Me._lblPercentValue_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblPercentValue_2.Size = New System.Drawing.Size(41, 17)
        Me._lblPercentValue_2.TabIndex = 5
        Me._lblPercentValue_2.Text = "50%"
        '
        '_lblPercentValue_1
        '
        Me._lblPercentValue_1.BackColor = System.Drawing.SystemColors.Control
        Me._lblPercentValue_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblPercentValue_1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me._lblPercentValue_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblPercentValue_1.Location = New System.Drawing.Point(8, 160)
        Me._lblPercentValue_1.Name = "_lblPercentValue_1"
        Me._lblPercentValue_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblPercentValue_1.Size = New System.Drawing.Size(33, 17)
        Me._lblPercentValue_1.TabIndex = 4
        Me._lblPercentValue_1.Text = "25%"
        '
        '_lblPercentValue_0
        '
        Me._lblPercentValue_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblPercentValue_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblPercentValue_0.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me._lblPercentValue_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblPercentValue_0.Location = New System.Drawing.Point(8, 208)
        Me._lblPercentValue_0.Name = "_lblPercentValue_0"
        Me._lblPercentValue_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblPercentValue_0.Size = New System.Drawing.Size(33, 17)
        Me._lblPercentValue_0.TabIndex = 3
        Me._lblPercentValue_0.Text = "0%"
        '
        'frmPlayerStatsZoom
        '
        Me.AcceptButton = Me.cmdNextPlayer
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.cmdOK
        Me.ClientSize = New System.Drawing.Size(551, 285)
        Me.Controls.Add(Me.txtStartMonth)
        Me.Controls.Add(Me.cmdPreviousPlayer)
        Me.Controls.Add(Me.cmdNextPlayer)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.lblStartMonth)
        Me.Controls.Add(Me.lblPlayer)
        Me.Controls.Add(Me._lblPercentValue_4)
        Me.Controls.Add(Me._lblPercentValue_3)
        Me.Controls.Add(Me._lblPercentValue_2)
        Me.Controls.Add(Me._lblPercentValue_1)
        Me.Controls.Add(Me._lblPercentValue_0)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(81, 111)
        Me.Name = "frmPlayerStatsZoom"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Win Percentage by Month"
        Me.ResumeLayout(False)

    End Sub
#End Region
End Class