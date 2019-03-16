<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmEditPlayers
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
	Public WithEvents cmdEdit As System.Windows.Forms.Button
	Public WithEvents cmdRemove As System.Windows.Forms.Button
	Public WithEvents cmdAddPlayer As System.Windows.Forms.Button
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents lstPlayers As System.Windows.Forms.ListBox
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmEditPlayers))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdEdit = New System.Windows.Forms.Button
		Me.cmdRemove = New System.Windows.Forms.Button
		Me.cmdAddPlayer = New System.Windows.Forms.Button
		Me.cmdCancel = New System.Windows.Forms.Button
		Me.cmdClose = New System.Windows.Forms.Button
		Me.lstPlayers = New System.Windows.Forms.ListBox
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.Text = "Edit Players"
		Me.ClientSize = New System.Drawing.Size(211, 346)
		Me.Location = New System.Drawing.Point(170, 108)
		Me.Icon = CType(resources.GetObject("frmEditPlayers.Icon"), System.Drawing.Icon)
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
		Me.Name = "frmEditPlayers"
		Me.cmdEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdEdit.Text = "&Edit"
		Me.cmdEdit.Size = New System.Drawing.Size(57, 25)
		Me.cmdEdit.Location = New System.Drawing.Point(144, 88)
		Me.cmdEdit.TabIndex = 5
		Me.cmdEdit.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdEdit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdEdit.CausesValidation = True
		Me.cmdEdit.Enabled = True
		Me.cmdEdit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdEdit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdEdit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdEdit.TabStop = True
		Me.cmdEdit.Name = "cmdEdit"
		Me.cmdRemove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRemove.Text = "&Remove"
		Me.cmdRemove.Size = New System.Drawing.Size(57, 25)
		Me.cmdRemove.Location = New System.Drawing.Point(144, 152)
		Me.cmdRemove.TabIndex = 4
		Me.cmdRemove.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdRemove.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRemove.CausesValidation = True
		Me.cmdRemove.Enabled = True
		Me.cmdRemove.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRemove.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRemove.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRemove.TabStop = True
		Me.cmdRemove.Name = "cmdRemove"
		Me.cmdAddPlayer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAddPlayer.Text = "&Add New"
		Me.cmdAddPlayer.Size = New System.Drawing.Size(57, 25)
		Me.cmdAddPlayer.Location = New System.Drawing.Point(144, 120)
		Me.cmdAddPlayer.TabIndex = 3
		Me.cmdAddPlayer.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdAddPlayer.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAddPlayer.CausesValidation = True
		Me.cmdAddPlayer.Enabled = True
		Me.cmdAddPlayer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAddPlayer.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAddPlayer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAddPlayer.TabStop = True
		Me.cmdAddPlayer.Name = "cmdAddPlayer"
		Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CancelButton = Me.cmdCancel
		Me.cmdCancel.Text = "&Cancel"
		Me.cmdCancel.Size = New System.Drawing.Size(57, 25)
		Me.cmdCancel.Location = New System.Drawing.Point(80, 312)
		Me.cmdCancel.TabIndex = 2
		Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCancel.CausesValidation = True
		Me.cmdCancel.Enabled = True
		Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCancel.TabStop = True
		Me.cmdCancel.Name = "cmdCancel"
		Me.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdClose.Text = "&Ok"
		Me.AcceptButton = Me.cmdClose
		Me.cmdClose.Size = New System.Drawing.Size(57, 25)
		Me.cmdClose.Location = New System.Drawing.Point(8, 312)
		Me.cmdClose.TabIndex = 1
		Me.cmdClose.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
		Me.cmdClose.CausesValidation = True
		Me.cmdClose.Enabled = True
		Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdClose.TabStop = True
		Me.cmdClose.Name = "cmdClose"
		Me.lstPlayers.Size = New System.Drawing.Size(121, 293)
		Me.lstPlayers.Location = New System.Drawing.Point(16, 16)
		Me.lstPlayers.Sorted = True
		Me.lstPlayers.TabIndex = 0
		Me.lstPlayers.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lstPlayers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lstPlayers.BackColor = System.Drawing.SystemColors.Window
		Me.lstPlayers.CausesValidation = True
		Me.lstPlayers.Enabled = True
		Me.lstPlayers.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lstPlayers.IntegralHeight = True
		Me.lstPlayers.Cursor = System.Windows.Forms.Cursors.Default
		Me.lstPlayers.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.lstPlayers.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lstPlayers.TabStop = True
		Me.lstPlayers.Visible = True
		Me.lstPlayers.MultiColumn = True
		Me.lstPlayers.ColumnWidth = 121
		Me.lstPlayers.Name = "lstPlayers"
		Me.Controls.Add(cmdEdit)
		Me.Controls.Add(cmdRemove)
		Me.Controls.Add(cmdAddPlayer)
		Me.Controls.Add(cmdCancel)
		Me.Controls.Add(cmdClose)
		Me.Controls.Add(lstPlayers)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class