Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()> Partial Class frmEditPlayerDialog
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
    Public WithEvents cmdCancel As System.Windows.Forms.Button
    Public WithEvents txtPlayerName As System.Windows.Forms.TextBox
    Public WithEvents lblPlayerName As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEditPlayerDialog))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdOK = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.txtPlayerName = New System.Windows.Forms.TextBox
        Me.lblPlayerName = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOK.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Location = New System.Drawing.Point(24, 48)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOK.Size = New System.Drawing.Size(57, 25)
        Me.cmdOK.TabIndex = 2
        Me.cmdOK.Text = "&Ok"
        Me.cmdOK.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(96, 48)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(57, 25)
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'txtPlayerName
        '
        Me.txtPlayerName.AcceptsReturn = True
        Me.txtPlayerName.BackColor = System.Drawing.SystemColors.Window
        Me.txtPlayerName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPlayerName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.txtPlayerName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPlayerName.Location = New System.Drawing.Point(88, 16)
        Me.txtPlayerName.MaxLength = 0
        Me.txtPlayerName.Name = "txtPlayerName"
        Me.txtPlayerName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPlayerName.Size = New System.Drawing.Size(81, 20)
        Me.txtPlayerName.TabIndex = 1
        '
        'lblPlayerName
        '
        Me.lblPlayerName.BackColor = System.Drawing.SystemColors.Control
        Me.lblPlayerName.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPlayerName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.lblPlayerName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPlayerName.Location = New System.Drawing.Point(8, 16)
        Me.lblPlayerName.Name = "lblPlayerName"
        Me.lblPlayerName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPlayerName.Size = New System.Drawing.Size(81, 17)
        Me.lblPlayerName.TabIndex = 0
        Me.lblPlayerName.Text = "Player's Name:"
        '
        'frmEditPlayerDialog
        '
        Me.AcceptButton = Me.cmdOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(179, 80)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.txtPlayerName)
        Me.Controls.Add(Me.lblPlayerName)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(494, 141)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEditPlayerDialog"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Edit Player"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region
End Class