Option Strict Off
Option Explicit On

Friend Class frmStatOptionsDialog
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

    Public Enum smStatsMode
        Cricket = 0
        Three01 = 1
        Golf = 2
        AllGames = 3
    End Enum

    Private mOKClicked As Boolean

    Public ReadOnly Property OKClicked() As Boolean
        Get
            Return mOKClicked
        End Get
    End Property

    Public ReadOnly Property StatsModeSelected() As smStatsMode
        Get

            If optStatsModeCricket.Checked Then
                Return smStatsMode.Cricket
            ElseIf optStatsMode301.Checked Then
                Return smStatsMode.Three01
            ElseIf optStatsModeGolf.Checked Then
                Return smStatsMode.Golf
            ElseIf optStatsModeAllGames.Checked Then
                Return smStatsMode.AllGames
            Else
                Return smStatsMode.Cricket
            End If

        End Get
    End Property

    Public Sub Reset()
        mOKClicked = False
    End Sub

    Private Sub cmdOK_Click(eventSender As Object, eventArgs As EventArgs) Handles cmdOK.Click
        mOKClicked = True
        Me.Hide()

    End Sub

    Private Sub frmStatOptionsDialog_Load(eventSender As Object, eventArgs As EventArgs) Handles MyBase.Load

        ' Position form in window
        Me.Left = (2 * Screen.PrimaryScreen.Bounds.Width - Me.Width) / 3
        Me.Top = (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2

        optStatsModeAllGames.Checked = True
        mOKClicked = False
    End Sub

End Class