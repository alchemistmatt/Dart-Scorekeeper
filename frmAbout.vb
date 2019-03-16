Option Strict Off
Option Explicit On

Friend Class frmAbout
	Inherits System.Windows.Forms.Form
	
	' -------------------------------------------------------------------------------
	' Dart Scorekeeper
	' Written by Matthew Monroe in Chapel Hill, NC
	'
	' Program started July 31, 1999
	'
	' E-mail: matt@alchemistmatt.com or alchemistmatt@yahoo.com
	' Websites: http://www.alchemistmatt.com/
	'           http://www.geocities.com/alchemistmatt/
	'           http://come.to/alchemistmatt/
	' -------------------------------------------------------------------------------
	'
	' Licensed under the Apache License, Version 2.0; you may not use this file except
	' in compliance with the License.  You may obtain a copy of the License at
	' http://www.apache.org/licenses/LICENSE-2.0
	
	Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
        Me.Close()
	End Sub
	
	Private Sub frmAbout_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
        ' Position form in window
        Me.Left = (2 * System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - Me.Width) / 3
        Me.Top = (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - Me.Height) / 3

        lblVersion.Text = "Version " & PROGRAM_VERSION & " (Build " & My.Application.Info.Version.Revision & ")"
        lblDate.Text = PROGRAM_DATE

	End Sub
End Class