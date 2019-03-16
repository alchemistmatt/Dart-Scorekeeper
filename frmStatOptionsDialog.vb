Option Strict Off
Option Explicit On

Friend Class frmStatOptionsDialog
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
            End If

        End Get
    End Property

    Public Sub Reset()
        mOKClicked = False
    End Sub

    Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
        mOKClicked = True
        Me.Hide()

    End Sub

    Private Sub frmStatOptionsDialog_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        ' Position form in window
        Me.Left = (2 * System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - Me.Width) / 3
        Me.Top = (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2

        optStatsModeAllGames.Checked = True
        mOKClicked = False
    End Sub

End Class
