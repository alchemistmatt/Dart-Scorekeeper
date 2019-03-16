<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmRankHelp
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
    Public WithEvents lblHelp2 As System.Windows.Forms.Label
    Public WithEvents lblHelp1 As System.Windows.Forms.Label
    Public WithEvents lblHelp0 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRankHelp))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdOK = New System.Windows.Forms.Button
        Me.lblHelp2 = New System.Windows.Forms.Label
        Me.lblHelp1 = New System.Windows.Forms.Label
        Me.lblHelp0 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdOK.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Location = New System.Drawing.Point(272, 232)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOK.Size = New System.Drawing.Size(57, 25)
        Me.cmdOK.TabIndex = 0
        Me.cmdOK.Text = "&Ok"
        Me.cmdOK.UseVisualStyleBackColor = False
        '
        'lblHelp2
        '
        Me.lblHelp2.BackColor = System.Drawing.SystemColors.Control
        Me.lblHelp2.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblHelp2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHelp2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblHelp2.Location = New System.Drawing.Point(8, 152)
        Me.lblHelp2.Name = "lblHelp2"
        Me.lblHelp2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblHelp2.Size = New System.Drawing.Size(609, 73)
        Me.lblHelp2.TabIndex = 3
        Me.lblHelp2.Text = "Help"
        '
        'lblHelp1
        '
        Me.lblHelp1.BackColor = System.Drawing.SystemColors.Control
        Me.lblHelp1.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblHelp1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHelp1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblHelp1.Location = New System.Drawing.Point(8, 72)
        Me.lblHelp1.Name = "lblHelp1"
        Me.lblHelp1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblHelp1.Size = New System.Drawing.Size(609, 73)
        Me.lblHelp1.TabIndex = 2
        Me.lblHelp1.Text = "Help"
        '
        'lblHelp0
        '
        Me.lblHelp0.BackColor = System.Drawing.SystemColors.Control
        Me.lblHelp0.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblHelp0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHelp0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblHelp0.Location = New System.Drawing.Point(8, 8)
        Me.lblHelp0.Name = "lblHelp0"
        Me.lblHelp0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblHelp0.Size = New System.Drawing.Size(609, 57)
        Me.lblHelp0.TabIndex = 1
        Me.lblHelp0.Text = "Help"
        '
        'frmRankHelp
        '
        Me.AcceptButton = Me.cmdOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.cmdOK
        Me.ClientSize = New System.Drawing.Size(625, 271)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.lblHelp2)
        Me.Controls.Add(Me.lblHelp1)
        Me.Controls.Add(Me.lblHelp0)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(60, 116)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRankHelp"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Ranking System Explanation"
        Me.ResumeLayout(False)

    End Sub
#End Region 
End Class