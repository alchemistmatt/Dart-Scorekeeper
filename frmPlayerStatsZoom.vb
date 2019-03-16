Option Strict Off
Option Explicit On

Imports System.Collections.Generic 'Imports VB = Microsoft.VisualBasic
'Imports Microsoft.VisualBasic.PowerPacks

Friend Class frmPlayerStatsZoom
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

    Private Const BarBottom = 224          ' Pixels
    Private Const BarFullHeight = 200      ' Pixels

    Private mPlayerName As String = String.Empty
    Private mPlayerGameInfo As List(Of frmPlayerStats.udtPlayerStatsGameInfoType)

    Public Sub SetPlayerInfo(strPlayerName As String, ByRef udtGameInfo As List(Of frmPlayerStats.udtPlayerStatsGameInfoType))
        mPlayerName = String.Copy(strPlayerName)
        mPlayerGameInfo = udtGameInfo
    End Sub

    Private Sub UpdateControls()

        Dim dtStartMonth As DateTime

        Dim StartYear, StartMonth, StartYearCaption As Short
        Dim CompareDateStart, CompareDateEnd As DateTime
        Dim x, intSlashIndex As Short
        Dim GamesPlayed, GamesWon, NewHeight As Short
        Dim ValidDate As Boolean

        Try

            lblPlayer.Text = mPlayerName

            ' Fill in months
            If txtStartMonth.Text.IndexOf("/", StringComparison.Ordinal) > 0 Then
                dtStartMonth = CDate(txtStartMonth.Text)

                StartMonth = CShort(dtStartMonth.ToString("MM"))
                StartYearCaption = CShort(dtStartMonth.ToString("yy"))
                StartYear = CShort(dtStartMonth.ToString("yyyy"))
                ValidDate = True
            Else
                ValidDate = False
            End If

            If Not ValidDate Then
                MessageBox.Show("Invalid starting month.  Please enter a date in the format month/year, for example, 1/1999 or 1/2000", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            For x = 0 To 11
                lblMonth.Item(x).Text = StartMonth.ToString & "/" & StartYearCaption.ToString("00")
                lblMonth.Item(x).Tag = StartMonth.ToString & "/" & StartYear.ToString
                StartMonth += 1

                If StartMonth > 12 Then
                    StartMonth = 1
                    StartYear += 1
                    StartYearCaption += 1
                    If StartYearCaption > 99 Then StartYearCaption = 0
                End If
            Next x


            For x = 0 To 11
                CompareDateStart = CDate(lblMonth.Item(x).Tag)
                If x < 11 Then
                    CompareDateEnd = CDate(lblMonth.Item(x + 1).Tag)
                Else
                    intSlashIndex = CStr(lblMonth.Item(x).Tag).IndexOf("/", StringComparison.Ordinal)
                    If intSlashIndex > 0 Then
                        StartMonth = CStr(lblMonth.Item(x).Tag).Substring(0, intSlashIndex)
                        StartYear = CStr(lblMonth.Item(x).Tag).Substring(intSlashIndex + 1)
                        StartMonth += 1
                        If StartMonth = 13 Then
                            StartMonth = 1
                            StartYear += 1
                        End If
                        CompareDateEnd = CDate(StartMonth.ToString() & "/" & StartYear.ToString())
                    Else
                        CompareDateEnd = CDate(lblMonth.Item(x).Tag).AddDays(30)
                    End If
                End If

                GamesWon = 0
                GamesPlayed = 0

                For Each udtGameInfo As frmPlayerStats.udtPlayerStatsGameInfoType In mPlayerGameInfo
                    If udtGameInfo.GameDate >= CompareDateStart AndAlso udtGameInfo.GameDate <= CompareDateEnd Then
                        GamesPlayed += 1
                        If udtGameInfo.GameWon Then
                            GamesWon += 1
                        End If
                    End If
                Next udtGameInfo

                If GamesPlayed > 0 Then
                    NewHeight = Math.Floor(BarFullHeight * (GamesWon / GamesPlayed))

                    'shpWinPercent(x).Top = BarBottom - NewHeight
                    'shpWinPercent(x).Height = NewHeight

                    lblWinRatio.Item(x).Text = GamesWon.ToString & "/" & GamesPlayed.ToString

                    'lblWinRatio.Item(x).Top = shpWinPercent(x).Top - 12
                    lblWinRatio.Item(x).Top = BarBottom - NewHeight - 12

                    If lblWinRatio.Item(x).Top < BarBottom - BarFullHeight Then
                        lblWinRatio.Item(x).Top = (BarBottom - BarFullHeight) - 12
                    End If
                Else
                    'shpWinPercent(x).Height = 0
                    'shpWinPercent(x).Top = BarBottom

                    lblWinRatio.Item(x).Text = "N/A"
                    lblWinRatio.Item(x).Top = BarBottom - 16
                End If
            Next x

        Catch ex As Exception
            HandleException("frmPlayerStatsZoom.UpdateControls", ex)
        End Try

    End Sub

    Private Sub cmdNextPlayer_Click(eventSender As Object, eventArgs As EventArgs) Handles cmdNextPlayer.Click
        Dim strPlayerName As String
        Dim udtGameInfo As New List(Of frmPlayerStats.udtPlayerStatsGameInfoType)

        Try
            strPlayerName = frmPlayerStats.SelectNextPlayer()

            If frmPlayerStats.GetPlayerGameInfo(strPlayerName, udtGameInfo) Then
                SetPlayerInfo(strPlayerName, udtGameInfo)
                UpdateControls()
            End If

        Catch ex As Exception
            HandleException("frmPlayerStatsZoom.cmdNextPlayer_click", ex)
        End Try

    End Sub

    Private Sub cmdok_Click(eventSender As Object, eventArgs As EventArgs) Handles cmdOK.Click
        Me.Hide()
    End Sub

    Private Sub cmdPreviousPlayer_Click(eventSender As Object, eventArgs As EventArgs) Handles cmdPreviousPlayer.Click
        Dim strPlayerName As String
        Dim udtGameInfo As New List(Of frmPlayerStats.udtPlayerStatsGameInfoType)

        Try
            strPlayerName = frmPlayerStats.SelectPreviousPlayer()

            If frmPlayerStats.GetPlayerGameInfo(strPlayerName, udtGameInfo) Then
                SetPlayerInfo(strPlayerName, udtGameInfo)
                UpdateControls()
            End If

        Catch ex As Exception
            HandleException("frmPlayerStatsZoom.cmdPreviousPlayer_Click", ex)
        End Try

    End Sub

    'UPGRADE_WARNING: Form event frmPlayerStatsZoom.Activate has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
    Private Sub frmPlayerStatsZoom_Activated(eventSender As Object, eventArgs As EventArgs) Handles MyBase.Activated

        UpdateControls()
    End Sub

    Private Sub frmPlayerStatsZoom_Load(eventSender As Object, eventArgs As EventArgs) Handles MyBase.Load
        Dim ThisMonth, x, StartYear As Short

        Try

            ' Set height and width
            Me.Width = 560
            Me.Height = 313

            ' Position form in window
            Me.Left = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
            Me.Top = (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 3

            With lblMonth.Item(0)
                .TextAlign = ContentAlignment.TopCenter
                .Text = "12/99"
                .Size = New Size(33, 17)
                .Location = New Point(56, 232)
                .TabIndex = 8
                .Font = New Font("Arial", 8.0!, FontStyle.Regular, GraphicsUnit.Point, 0)
                .BackColor = SystemColors.Control
                .Enabled = True
                .ForeColor = SystemColors.ControlText
                .Cursor = Cursors.Default
                .RightToLeft = RightToLeft.No
                .UseMnemonic = True
                .Visible = True
                .AutoSize = False
                .BorderStyle = BorderStyle.None
            End With

            With lblWinRatio.Item(0)
                .TextAlign = ContentAlignment.TopCenter
                .Text = "0/0"
                .Size = New Size(33, 17)
                .Location = New Point(56, 200)
                .TabIndex = 10
                .Font = New Font("Arial", 8.0!, FontStyle.Regular, GraphicsUnit.Point, 0)
                .BackColor = Color.Transparent
                .Enabled = True
                .ForeColor = SystemColors.ControlText
                .Cursor = Cursors.Default
                .RightToLeft = RightToLeft.No
                .UseMnemonic = True
                .Visible = True
                .AutoSize = False
                .BorderStyle = BorderStyle.None
            End With

            ' Load the bars and set height to 0
            For x = 1 To 11
                lblMonth.AddNewLabel()
                lblWinRatio.AddNewLabel()

                With lblMonth.Item(0)
                    lblMonth.Item(x).Left = .Left + 40 * x
                    lblMonth.Item(x).Height = .Height
                    lblMonth.Item(x).Top = .Top
                    lblMonth.Item(x).Width = .Width
                    lblMonth.Item(x).Visible = True
                End With

                With lblWinRatio.Item(0)
                    lblWinRatio.Item(x).Left = .Left + 40 * x
                    lblWinRatio.Item(x).Height = .Height
                    lblWinRatio.Item(x).Top = .Top
                    lblWinRatio.Item(x).Width = .Width
                    lblWinRatio.Item(x).Visible = True
                    lblWinRatio.Item(x).BringToFront()
                End With

            Next x

            ThisMonth = DateTime.Now.ToString("MM")
            StartYear = DateTime.Now.ToString("yyyy")
            For x = 1 To 11
                ThisMonth -= 1
                If ThisMonth < 1 Then
                    ThisMonth = 12
                    StartYear -= 1
                End If
            Next x

            txtStartMonth.Text = ThisMonth.ToString() & "/" & StartYear.ToString()

        Catch ex As Exception
            HandleException("frmPlayerStatsZoom.Form_Load", ex)
        End Try

    End Sub
End Class