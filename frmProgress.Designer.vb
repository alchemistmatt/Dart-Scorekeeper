<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmProgress
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
    Public WithEvents lblCurrentTask As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblCurrentTask = New System.Windows.Forms.Label
        Me.pbarProgress = New System.Windows.Forms.ProgressBar
        Me.SuspendLayout()
        '
        'lblCurrentTask
        '
        Me.lblCurrentTask.BackColor = System.Drawing.SystemColors.Control
        Me.lblCurrentTask.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCurrentTask.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentTask.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCurrentTask.Location = New System.Drawing.Point(8, 8)
        Me.lblCurrentTask.Name = "lblCurrentTask"
        Me.lblCurrentTask.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCurrentTask.Size = New System.Drawing.Size(177, 25)
        Me.lblCurrentTask.TabIndex = 0
        Me.lblCurrentTask.Text = "Current task"
        '
        'pbarProgress
        '
        Me.pbarProgress.Location = New System.Drawing.Point(7, 36)
        Me.pbarProgress.Name = "pbarProgress"
        Me.pbarProgress.Size = New System.Drawing.Size(178, 23)
        Me.pbarProgress.TabIndex = 2
        '
        'frmProgress
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(194, 70)
        Me.Controls.Add(Me.pbarProgress)
        Me.Controls.Add(Me.lblCurrentTask)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProgress"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False        
        Me.Text = "Progress"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbarProgress As System.Windows.Forms.ProgressBar
#End Region 
End Class
