Option Strict Off
Option Explicit On

Friend Class frmAbout
    Inherits Form

    ' -------------------------------------------------------------------------------
    ' Dart Scorekeeper
    '
    ' Written by Matthew Monroe
    ' Started in July 1999
    ' Ported to .NET in 2011
    '
    ' E-mail: monroem@gmail.com or alchemistmatt@yahoo.com
    ' Repository: https://github.com/alchemistmatt
    '
    ' -------------------------------------------------------------------------------
    '
    ' Licensed under the Apache License, Version 2.0; you may not use this file except
    ' in compliance with the License.  You may obtain a copy of the License at
    ' http://www.apache.org/licenses/LICENSE-2.0

    Private Sub cmdExit_Click(eventSender As Object, eventArgs As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub frmAbout_Load(eventSender As Object, eventArgs As EventArgs) Handles MyBase.Load

        ' Position form in window
        Me.Left = (2 * Screen.PrimaryScreen.Bounds.Width - Me.Width) / 3
        Me.Top = (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 3

        lblVersion.Text = "Version " & PROGRAM_VERSION & " (Build " & My.Application.Info.Version.Revision & ")"
        lblDate.Text = PROGRAM_DATE

    End Sub
End Class