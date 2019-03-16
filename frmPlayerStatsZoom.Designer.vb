<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmPlayerStatsZoom
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
    Public WithEvents txtStartMonth As System.Windows.Forms.TextBox
    Public WithEvents cmdPreviousPlayer As System.Windows.Forms.Button
    Public WithEvents cmdNextPlayer As System.Windows.Forms.Button
    Public WithEvents cmdOK As System.Windows.Forms.Button
    Public WithEvents lblStartMonth As System.Windows.Forms.Label
    Public WithEvents _lblWinRatio_0 As System.Windows.Forms.Label
    Public WithEvents lblPlayer As System.Windows.Forms.Label
    Public WithEvents _lblMonth_0 As System.Windows.Forms.Label
    Public WithEvents shpBorder As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Public WithEvents _shpWinPercent_0 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Public WithEvents _lblPercentValue_4 As System.Windows.Forms.Label
    Public WithEvents _lblPercentValue_3 As System.Windows.Forms.Label
    Public WithEvents _lblPercentValue_2 As System.Windows.Forms.Label
    Public WithEvents _lblPercentValue_1 As System.Windows.Forms.Label
    Public WithEvents _lblPercentValue_0 As System.Windows.Forms.Label
    Public WithEvents lblMonth As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblPercentValue As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblWinRatio As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPlayerStatsZoom))
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
        Me.txtStartMonth = New System.Windows.Forms.TextBox
        Me.cmdPreviousPlayer = New System.Windows.Forms.Button
        Me.cmdNextPlayer = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
        Me.lblStartMonth = New System.Windows.Forms.Label
        Me._lblWinRatio_0 = New System.Windows.Forms.Label
        Me.lblPlayer = New System.Windows.Forms.Label
        Me._lblMonth_0 = New System.Windows.Forms.Label
        Me.shpBorder = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        Me._shpWinPercent_0 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        Me._lblPercentValue_4 = New System.Windows.Forms.Label
        Me._lblPercentValue_3 = New System.Windows.Forms.Label
        Me._lblPercentValue_2 = New System.Windows.Forms.Label
        Me._lblPercentValue_1 = New System.Windows.Forms.Label
        Me._lblPercentValue_0 = New System.Windows.Forms.Label
        Me.lblMonth = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        Me.lblPercentValue = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        Me.lblWinRatio = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
        Me.SuspendLayout()
        Me.ToolTip1.Active = True
        CType(Me.lblMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPercentValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblWinRatio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Win Percentage by Month"
        Me.ClientSize = New System.Drawing.Size(551, 285)
        Me.Location = New System.Drawing.Point(81, 111)
        Me.Icon = CType(resources.GetObject("frmPlayerStatsZoom.Icon"), System.Drawing.Icon)
        Me.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
        Me.ControlBox = True
        Me.Enabled = True
        Me.KeyPreview = False
        Me.MaximizeBox = True
        Me.MinimizeBox = True
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = True
        Me.HelpButton = False
        Me.WindowState = System.Windows.Forms.FormWindowState.Normal
        Me.Name = "frmPlayerStatsZoom"
        Me.txtStartMonth.AutoSize = False
        Me.txtStartMonth.Size = New System.Drawing.Size(57, 19)
        Me.txtStartMonth.Location = New System.Drawing.Point(72, 256)
        Me.txtStartMonth.TabIndex = 11
        Me.txtStartMonth.Text = "1/1999"
        Me.txtStartMonth.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStartMonth.AcceptsReturn = True
        Me.txtStartMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtStartMonth.BackColor = System.Drawing.SystemColors.Window
        Me.txtStartMonth.CausesValidation = True
        Me.txtStartMonth.Enabled = True
        Me.txtStartMonth.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStartMonth.HideSelection = True
        Me.txtStartMonth.ReadOnly = False
        Me.txtStartMonth.Maxlength = 0
        Me.txtStartMonth.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStartMonth.MultiLine = False
        Me.txtStartMonth.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStartMonth.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtStartMonth.TabStop = True
        Me.txtStartMonth.Visible = True
        Me.txtStartMonth.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtStartMonth.Name = "txtStartMonth"
        Me.cmdPreviousPlayer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdPreviousPlayer.Text = "&Previous Player"
        Me.cmdPreviousPlayer.Size = New System.Drawing.Size(97, 25)
        Me.cmdPreviousPlayer.Location = New System.Drawing.Point(144, 256)
        Me.cmdPreviousPlayer.TabIndex = 0
        Me.cmdPreviousPlayer.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPreviousPlayer.BackColor = System.Drawing.SystemColors.Control
        Me.cmdPreviousPlayer.CausesValidation = True
        Me.cmdPreviousPlayer.Enabled = True
        Me.cmdPreviousPlayer.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdPreviousPlayer.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdPreviousPlayer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdPreviousPlayer.TabStop = True
        Me.cmdPreviousPlayer.Name = "cmdPreviousPlayer"
        Me.cmdNextPlayer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdNextPlayer.Text = "&Next Player"
        Me.AcceptButton = Me.cmdNextPlayer
        Me.cmdNextPlayer.Size = New System.Drawing.Size(97, 25)
        Me.cmdNextPlayer.Location = New System.Drawing.Point(248, 256)
        Me.cmdNextPlayer.TabIndex = 1
        Me.cmdNextPlayer.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNextPlayer.BackColor = System.Drawing.SystemColors.Control
        Me.cmdNextPlayer.CausesValidation = True
        Me.cmdNextPlayer.Enabled = True
        Me.cmdNextPlayer.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdNextPlayer.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdNextPlayer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdNextPlayer.TabStop = True
        Me.cmdNextPlayer.Name = "cmdNextPlayer"
        Me.cmdOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CancelButton = Me.cmdOK
        Me.cmdOK.Text = "&Close"
        Me.cmdOK.Size = New System.Drawing.Size(57, 25)
        Me.cmdOK.Location = New System.Drawing.Point(408, 256)
        Me.cmdOK.TabIndex = 2
        Me.cmdOK.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOK.CausesValidation = True
        Me.cmdOK.Enabled = True
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOK.TabStop = True
        Me.cmdOK.Name = "cmdOK"
        Me.lblStartMonth.Text = "Start Month:"
        Me.lblStartMonth.Size = New System.Drawing.Size(65, 17)
        Me.lblStartMonth.Location = New System.Drawing.Point(8, 258)
        Me.lblStartMonth.TabIndex = 12
        Me.lblStartMonth.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStartMonth.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.lblStartMonth.BackColor = System.Drawing.SystemColors.Control
        Me.lblStartMonth.Enabled = True
        Me.lblStartMonth.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblStartMonth.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblStartMonth.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblStartMonth.UseMnemonic = True
        Me.lblStartMonth.Visible = True
        Me.lblStartMonth.AutoSize = False
        Me.lblStartMonth.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblStartMonth.Name = "lblStartMonth"
        Me._lblWinRatio_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me._lblWinRatio_0.Text = "0/0"
        Me._lblWinRatio_0.Size = New System.Drawing.Size(33, 17)
        Me._lblWinRatio_0.Location = New System.Drawing.Point(56, 200)
        Me._lblWinRatio_0.TabIndex = 10
        Me._lblWinRatio_0.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblWinRatio_0.BackColor = System.Drawing.Color.Transparent
        Me._lblWinRatio_0.Enabled = True
        Me._lblWinRatio_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblWinRatio_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblWinRatio_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblWinRatio_0.UseMnemonic = True
        Me._lblWinRatio_0.Visible = True
        Me._lblWinRatio_0.AutoSize = False
        Me._lblWinRatio_0.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._lblWinRatio_0.Name = "_lblWinRatio_0"
        Me.lblPlayer.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblPlayer.Text = "Player"
        Me.lblPlayer.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlayer.Size = New System.Drawing.Size(385, 17)
        Me.lblPlayer.Location = New System.Drawing.Point(72, 0)
        Me.lblPlayer.TabIndex = 9
        Me.lblPlayer.BackColor = System.Drawing.SystemColors.Control
        Me.lblPlayer.Enabled = True
        Me.lblPlayer.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPlayer.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPlayer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPlayer.UseMnemonic = True
        Me.lblPlayer.Visible = True
        Me.lblPlayer.AutoSize = False
        Me.lblPlayer.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblPlayer.Name = "lblPlayer"
        Me._lblMonth_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me._lblMonth_0.Text = "12/99"
        Me._lblMonth_0.Size = New System.Drawing.Size(33, 17)
        Me._lblMonth_0.Location = New System.Drawing.Point(56, 232)
        Me._lblMonth_0.TabIndex = 8
        Me._lblMonth_0.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblMonth_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblMonth_0.Enabled = True
        Me._lblMonth_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblMonth_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblMonth_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblMonth_0.UseMnemonic = True
        Me._lblMonth_0.Visible = True
        Me._lblMonth_0.AutoSize = False
        Me._lblMonth_0.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._lblMonth_0.Name = "_lblMonth_0"
        Me.shpBorder.BorderColor = System.Drawing.Color.Blue
        Me.shpBorder.Size = New System.Drawing.Size(489, 201)
        Me.shpBorder.Location = New System.Drawing.Point(48, 24)
        Me.shpBorder.BackColor = System.Drawing.SystemColors.Window
        Me.shpBorder.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent
        Me.shpBorder.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
        Me.shpBorder.BorderWidth = 1
        Me.shpBorder.FillColor = System.Drawing.Color.Black
        Me.shpBorder.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Transparent
        Me.shpBorder.Visible = True
        Me.shpBorder.Name = "shpBorder"
        Me._shpWinPercent_0.FillColor = System.Drawing.Color.Blue
        Me._shpWinPercent_0.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me._shpWinPercent_0.Size = New System.Drawing.Size(33, 1)
        Me._shpWinPercent_0.Location = New System.Drawing.Point(56, 224)
        Me._shpWinPercent_0.BackColor = System.Drawing.SystemColors.Window
        Me._shpWinPercent_0.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Transparent
        Me._shpWinPercent_0.BorderColor = System.Drawing.SystemColors.WindowText
        Me._shpWinPercent_0.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid
        Me._shpWinPercent_0.BorderWidth = 1
        Me._shpWinPercent_0.Visible = True
        Me._shpWinPercent_0.Name = "_shpWinPercent_0"
        Me._lblPercentValue_4.Text = "100%"
        Me._lblPercentValue_4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblPercentValue_4.Size = New System.Drawing.Size(41, 17)
        Me._lblPercentValue_4.Location = New System.Drawing.Point(8, 16)
        Me._lblPercentValue_4.TabIndex = 7
        Me._lblPercentValue_4.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me._lblPercentValue_4.BackColor = System.Drawing.SystemColors.Control
        Me._lblPercentValue_4.Enabled = True
        Me._lblPercentValue_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblPercentValue_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblPercentValue_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblPercentValue_4.UseMnemonic = True
        Me._lblPercentValue_4.Visible = True
        Me._lblPercentValue_4.AutoSize = False
        Me._lblPercentValue_4.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._lblPercentValue_4.Name = "_lblPercentValue_4"
        Me._lblPercentValue_3.Text = "75%"
        Me._lblPercentValue_3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblPercentValue_3.Size = New System.Drawing.Size(41, 17)
        Me._lblPercentValue_3.Location = New System.Drawing.Point(8, 64)
        Me._lblPercentValue_3.TabIndex = 6
        Me._lblPercentValue_3.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me._lblPercentValue_3.BackColor = System.Drawing.SystemColors.Control
        Me._lblPercentValue_3.Enabled = True
        Me._lblPercentValue_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblPercentValue_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblPercentValue_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblPercentValue_3.UseMnemonic = True
        Me._lblPercentValue_3.Visible = True
        Me._lblPercentValue_3.AutoSize = False
        Me._lblPercentValue_3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._lblPercentValue_3.Name = "_lblPercentValue_3"
        Me._lblPercentValue_2.Text = "50%"
        Me._lblPercentValue_2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblPercentValue_2.Size = New System.Drawing.Size(41, 17)
        Me._lblPercentValue_2.Location = New System.Drawing.Point(8, 112)
        Me._lblPercentValue_2.TabIndex = 5
        Me._lblPercentValue_2.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me._lblPercentValue_2.BackColor = System.Drawing.SystemColors.Control
        Me._lblPercentValue_2.Enabled = True
        Me._lblPercentValue_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblPercentValue_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblPercentValue_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblPercentValue_2.UseMnemonic = True
        Me._lblPercentValue_2.Visible = True
        Me._lblPercentValue_2.AutoSize = False
        Me._lblPercentValue_2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._lblPercentValue_2.Name = "_lblPercentValue_2"
        Me._lblPercentValue_1.Text = "25%"
        Me._lblPercentValue_1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblPercentValue_1.Size = New System.Drawing.Size(33, 17)
        Me._lblPercentValue_1.Location = New System.Drawing.Point(8, 160)
        Me._lblPercentValue_1.TabIndex = 4
        Me._lblPercentValue_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me._lblPercentValue_1.BackColor = System.Drawing.SystemColors.Control
        Me._lblPercentValue_1.Enabled = True
        Me._lblPercentValue_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblPercentValue_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblPercentValue_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblPercentValue_1.UseMnemonic = True
        Me._lblPercentValue_1.Visible = True
        Me._lblPercentValue_1.AutoSize = False
        Me._lblPercentValue_1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._lblPercentValue_1.Name = "_lblPercentValue_1"
        Me._lblPercentValue_0.Text = "0%"
        Me._lblPercentValue_0.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblPercentValue_0.Size = New System.Drawing.Size(33, 17)
        Me._lblPercentValue_0.Location = New System.Drawing.Point(8, 208)
        Me._lblPercentValue_0.TabIndex = 3
        Me._lblPercentValue_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me._lblPercentValue_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblPercentValue_0.Enabled = True
        Me._lblPercentValue_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblPercentValue_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblPercentValue_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblPercentValue_0.UseMnemonic = True
        Me._lblPercentValue_0.Visible = True
        Me._lblPercentValue_0.AutoSize = False
        Me._lblPercentValue_0.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._lblPercentValue_0.Name = "_lblPercentValue_0"
        Me.Controls.Add(txtStartMonth)
        Me.Controls.Add(cmdPreviousPlayer)
        Me.Controls.Add(cmdNextPlayer)
        Me.Controls.Add(cmdOK)
        Me.Controls.Add(lblStartMonth)
        Me.Controls.Add(_lblWinRatio_0)
        Me.Controls.Add(lblPlayer)
        Me.Controls.Add(_lblMonth_0)
        Me.Controls.Add(_lblPercentValue_4)
        Me.Controls.Add(_lblPercentValue_3)
        Me.Controls.Add(_lblPercentValue_2)
        Me.Controls.Add(_lblPercentValue_1)
        Me.Controls.Add(_lblPercentValue_0)
        Me.lblMonth.SetIndex(_lblMonth_0, CType(0, Short))
        Me.lblPercentValue.SetIndex(_lblPercentValue_4, CType(4, Short))
        Me.lblPercentValue.SetIndex(_lblPercentValue_3, CType(3, Short))
        Me.lblPercentValue.SetIndex(_lblPercentValue_2, CType(2, Short))
        Me.lblPercentValue.SetIndex(_lblPercentValue_1, CType(1, Short))
        Me.lblPercentValue.SetIndex(_lblPercentValue_0, CType(0, Short))
        Me.lblWinRatio.SetIndex(_lblWinRatio_0, CType(0, Short))
        CType(Me.lblWinRatio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPercentValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMonth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
#End Region 
End Class
