Option Strict Off
Option Explicit On

Friend Class frmEditPlayerDialog
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

    Private mPlayerNameUpdated As Boolean

    Public ReadOnly Property PlayerNameUpdated() As Boolean
        Get
            Return mPlayerNameUpdated
        End Get
    End Property

    Public Property PlayerName() As String
        Get
            Return txtPlayerName.Text
        End Get
        Set(ByVal value As String)
            txtPlayerName.Text = value
            mPlayerNameUpdated = False
        End Set
    End Property

    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        mPlayerNameUpdated = False
        Me.Hide()
    End Sub

    Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
        mPlayerNameUpdated = True
        Me.Hide()
    End Sub

    Private Sub frmEditPlayerDialog_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        
        ' Position form in window
        Me.Left = (2 * System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - Me.Width) / 3
        Me.Top = (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - Me.Height) / 3

        txtPlayerName.Text = String.Empty
        mPlayerNameUpdated = False
    End Sub

End Class
