<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmStatOptionsDialog
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
    Public WithEvents optStatsModeAllGames As System.Windows.Forms.RadioButton
    Public WithEvents optStatsModeGolf As System.Windows.Forms.RadioButton
    Public WithEvents optStatsModeCricket As System.Windows.Forms.RadioButton
    Public WithEvents optStatsMode301 As System.Windows.Forms.RadioButton
    Public WithEvents cmdOK As System.Windows.Forms.Button
    Public WithEvents lblNote As System.Windows.Forms.Label
    Public WithEvents lblDirections As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStatOptionsDialog))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.optStatsModeAllGames = New System.Windows.Forms.RadioButton
        Me.optStatsModeGolf = New System.Windows.Forms.RadioButton
        Me.optStatsModeCricket = New System.Windows.Forms.RadioButton
        Me.optStatsMode301 = New System.Windows.Forms.RadioButton
        Me.cmdOK = New System.Windows.Forms.Button
        Me.lblNote = New System.Windows.Forms.Label
        Me.lblDirections = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'optStatsModeAllGames
        '
        Me.optStatsModeAllGames.BackColor = System.Drawing.SystemColors.Control
        Me.optStatsModeAllGames.Cursor = System.Windows.Forms.Cursors.Default
        Me.optStatsModeAllGames.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optStatsModeAllGames.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optStatsModeAllGames.Location = New System.Drawing.Point(16, 112)
        Me.optStatsModeAllGames.Name = "optStatsModeAllGames"
        Me.optStatsModeAllGames.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optStatsModeAllGames.Size = New System.Drawing.Size(89, 17)
        Me.optStatsModeAllGames.TabIndex = 5
        Me.optStatsModeAllGames.TabStop = True
        Me.optStatsModeAllGames.Text = "&All Games"
        Me.optStatsModeAllGames.UseVisualStyleBackColor = False
        '
        'optStatsModeGolf
        '
        Me.optStatsModeGolf.BackColor = System.Drawing.SystemColors.Control
        Me.optStatsModeGolf.Cursor = System.Windows.Forms.Cursors.Default
        Me.optStatsModeGolf.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optStatsModeGolf.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optStatsModeGolf.Location = New System.Drawing.Point(16, 88)
        Me.optStatsModeGolf.Name = "optStatsModeGolf"
        Me.optStatsModeGolf.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optStatsModeGolf.Size = New System.Drawing.Size(81, 17)
        Me.optStatsModeGolf.TabIndex = 3
        Me.optStatsModeGolf.TabStop = True
        Me.optStatsModeGolf.Text = "&Golf"
        Me.optStatsModeGolf.UseVisualStyleBackColor = False
        '
        'optStatsModeCricket
        '
        Me.optStatsModeCricket.BackColor = System.Drawing.SystemColors.Control
        Me.optStatsModeCricket.Checked = True
        Me.optStatsModeCricket.Cursor = System.Windows.Forms.Cursors.Default
        Me.optStatsModeCricket.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optStatsModeCricket.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optStatsModeCricket.Location = New System.Drawing.Point(16, 40)
        Me.optStatsModeCricket.Name = "optStatsModeCricket"
        Me.optStatsModeCricket.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optStatsModeCricket.Size = New System.Drawing.Size(81, 17)
        Me.optStatsModeCricket.TabIndex = 1
        Me.optStatsModeCricket.TabStop = True
        Me.optStatsModeCricket.Text = "&Cricket"
        Me.optStatsModeCricket.UseVisualStyleBackColor = False
        '
        'optStatsMode301
        '
        Me.optStatsMode301.BackColor = System.Drawing.SystemColors.Control
        Me.optStatsMode301.Cursor = System.Windows.Forms.Cursors.Default
        Me.optStatsMode301.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optStatsMode301.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optStatsMode301.Location = New System.Drawing.Point(16, 64)
        Me.optStatsMode301.Name = "optStatsMode301"
        Me.optStatsMode301.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optStatsMode301.Size = New System.Drawing.Size(73, 17)
        Me.optStatsMode301.TabIndex = 2
        Me.optStatsMode301.TabStop = True
        Me.optStatsMode301.Text = "&301"
        Me.optStatsMode301.UseVisualStyleBackColor = False
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOK.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Location = New System.Drawing.Point(112, 72)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOK.Size = New System.Drawing.Size(57, 25)
        Me.cmdOK.TabIndex = 4
        Me.cmdOK.Text = "&Ok"
        Me.cmdOK.UseVisualStyleBackColor = False
        '
        'lblNote
        '
        Me.lblNote.BackColor = System.Drawing.SystemColors.Control
        Me.lblNote.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblNote.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNote.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblNote.Location = New System.Drawing.Point(13, 135)
        Me.lblNote.Name = "lblNote"
        Me.lblNote.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblNote.Size = New System.Drawing.Size(137, 54)
        Me.lblNote.TabIndex = 6
        Me.lblNote.Text = "When using All Games, Golf is excluded from the Rankings system."
        '
        'lblDirections
        '
        Me.lblDirections.BackColor = System.Drawing.SystemColors.Control
        Me.lblDirections.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDirections.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDirections.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDirections.Location = New System.Drawing.Point(24, 8)
        Me.lblDirections.Name = "lblDirections"
        Me.lblDirections.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDirections.Size = New System.Drawing.Size(137, 17)
        Me.lblDirections.TabIndex = 0
        Me.lblDirections.Text = "Compile statistics for:"
        '
        'frmStatOptionsDialog
        '
        Me.AcceptButton = Me.cmdOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(181, 196)
        Me.ControlBox = False
        Me.Controls.Add(Me.optStatsModeAllGames)
        Me.Controls.Add(Me.optStatsModeGolf)
        Me.Controls.Add(Me.optStatsModeCricket)
        Me.Controls.Add(Me.optStatsMode301)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.lblNote)
        Me.Controls.Add(Me.lblDirections)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(70, 140)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStatOptionsDialog"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Statistics Options"
        Me.ResumeLayout(False)

    End Sub
#End Region 
End Class
