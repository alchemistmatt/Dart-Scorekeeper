Option Strict Off
Option Explicit On

Friend Class frmEditPlayerDialog
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
        Set
            txtPlayerName.Text = Value
            mPlayerNameUpdated = False
        End Set
    End Property

    Private Sub cmdCancel_Click(eventSender As Object, eventArgs As EventArgs) Handles cmdCancel.Click
        mPlayerNameUpdated = False
        Me.Hide()
    End Sub

    Private Sub cmdOK_Click(eventSender As Object, eventArgs As EventArgs) Handles cmdOK.Click
        mPlayerNameUpdated = True
        Me.Hide()
    End Sub

    Private Sub frmEditPlayerDialog_Load(eventSender As Object, eventArgs As EventArgs) Handles MyBase.Load

        ' Position form in window
        Me.Left = (2 * Screen.PrimaryScreen.Bounds.Width - Me.Width) / 3
        Me.Top = (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 3

        txtPlayerName.Text = String.Empty
        mPlayerNameUpdated = False
    End Sub

End Class