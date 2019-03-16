Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()> Partial Class frmAbout
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
    Public WithEvents txtEMail As System.Windows.Forms.TextBox
    Public WithEvents txtHTTP As System.Windows.Forms.TextBox
    Public WithEvents cmdExit As System.Windows.Forms.Button
    Public WithEvents lblMicrosoft As System.Windows.Forms.Label
    Public WithEvents lblAuthor As System.Windows.Forms.Label
    Public WithEvents lblFreeware As System.Windows.Forms.Label
    Public WithEvents linLine1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Public WithEvents lblDate As System.Windows.Forms.Label
    Public WithEvents lblVersion As System.Windows.Forms.Label
    Public WithEvents lblTitle As System.Windows.Forms.Label
    Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbout))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.linLine1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.txtEMail = New System.Windows.Forms.TextBox()
        Me.txtHTTP = New System.Windows.Forms.TextBox()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.lblMicrosoft = New System.Windows.Forms.Label()
        Me.lblAuthor = New System.Windows.Forms.Label()
        Me.lblFreeware = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.linLine1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(442, 337)
        Me.ShapeContainer1.TabIndex = 9
        Me.ShapeContainer1.TabStop = False
        '
        'linLine1
        '
        Me.linLine1.BorderColor = System.Drawing.SystemColors.WindowText
        Me.linLine1.BorderWidth = 2
        Me.linLine1.Name = "linLine1"
        Me.linLine1.X1 = 24
        Me.linLine1.X2 = 296
        Me.linLine1.Y1 = 200
        Me.linLine1.Y2 = 200
        '
        'txtEMail
        '
        Me.txtEMail.AcceptsReturn = True
        Me.txtEMail.BackColor = System.Drawing.SystemColors.Control
        Me.txtEMail.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtEMail.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEMail.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEMail.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtEMail.Location = New System.Drawing.Point(20, 121)
        Me.txtEMail.MaxLength = 0
        Me.txtEMail.Multiline = True
        Me.txtEMail.Name = "txtEMail"
        Me.txtEMail.ReadOnly = True
        Me.txtEMail.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtEMail.Size = New System.Drawing.Size(201, 33)
        Me.txtEMail.TabIndex = 5
        Me.txtEMail.Text = "monroem@gmail.com" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "alchemistmatt@yahoo.com"
        '
        'txtHTTP
        '
        Me.txtHTTP.AcceptsReturn = True
        Me.txtHTTP.BackColor = System.Drawing.SystemColors.Control
        Me.txtHTTP.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtHTTP.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtHTTP.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHTTP.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtHTTP.Location = New System.Drawing.Point(20, 161)
        Me.txtHTTP.MaxLength = 0
        Me.txtHTTP.Multiline = True
        Me.txtHTTP.Name = "txtHTTP"
        Me.txtHTTP.ReadOnly = True
        Me.txtHTTP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtHTTP.Size = New System.Drawing.Size(241, 25)
        Me.txtHTTP.TabIndex = 4
        Me.txtHTTP.Text = "https://github.com/alchemistmatt"
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdExit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExit.Location = New System.Drawing.Point(116, 287)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExit.Size = New System.Drawing.Size(63, 38)
        Me.cmdExit.TabIndex = 2
        Me.cmdExit.Text = "&Ok"
        Me.cmdExit.UseVisualStyleBackColor = False
        '
        'lblMicrosoft
        '
        Me.lblMicrosoft.BackColor = System.Drawing.SystemColors.Control
        Me.lblMicrosoft.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblMicrosoft.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMicrosoft.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMicrosoft.Location = New System.Drawing.Point(20, 263)
        Me.lblMicrosoft.Name = "lblMicrosoft"
        Me.lblMicrosoft.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblMicrosoft.Size = New System.Drawing.Size(291, 16)
        Me.lblMicrosoft.TabIndex = 8
        Me.lblMicrosoft.Text = "written using Microsoft VB.NET"
        '
        'lblAuthor
        '
        Me.lblAuthor.BackColor = System.Drawing.SystemColors.Control
        Me.lblAuthor.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblAuthor.Font = New System.Drawing.Font("Arial", 13.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAuthor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAuthor.Location = New System.Drawing.Point(20, 51)
        Me.lblAuthor.Name = "lblAuthor"
        Me.lblAuthor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAuthor.Size = New System.Drawing.Size(294, 25)
        Me.lblAuthor.TabIndex = 7
        Me.lblAuthor.Text = "by Matthew Monroe"
        '
        'lblFreeware
        '
        Me.lblFreeware.BackColor = System.Drawing.SystemColors.Control
        Me.lblFreeware.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblFreeware.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFreeware.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFreeware.Location = New System.Drawing.Point(20, 229)
        Me.lblFreeware.Name = "lblFreeware"
        Me.lblFreeware.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblFreeware.Size = New System.Drawing.Size(299, 19)
        Me.lblFreeware.TabIndex = 6
        Me.lblFreeware.Text = "This program is Freeware; distribute freely."
        '
        'lblDate
        '
        Me.lblDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblDate.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDate.Location = New System.Drawing.Point(132, 85)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDate.Size = New System.Drawing.Size(183, 21)
        Me.lblDate.TabIndex = 3
        Me.lblDate.Text = "March 15, 2019"
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblVersion
        '
        Me.lblVersion.BackColor = System.Drawing.SystemColors.Control
        Me.lblVersion.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblVersion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblVersion.Location = New System.Drawing.Point(20, 85)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblVersion.Size = New System.Drawing.Size(192, 21)
        Me.lblVersion.TabIndex = 1
        Me.lblVersion.Text = "Version"
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.SystemColors.Control
        Me.lblTitle.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTitle.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTitle.Location = New System.Drawing.Point(20, 8)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitle.Size = New System.Drawing.Size(290, 34)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Dart Scorekeeper"
        '
        'frmAbout
        '
        Me.AcceptButton = Me.cmdExit
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.cmdExit
        Me.ClientSize = New System.Drawing.Size(442, 337)
        Me.Controls.Add(Me.txtEMail)
        Me.Controls.Add(Me.txtHTTP)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.lblMicrosoft)
        Me.Controls.Add(Me.lblAuthor)
        Me.Controls.Add(Me.lblFreeware)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(365, 158)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAbout"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Dart Scorekeeper"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region
End Class