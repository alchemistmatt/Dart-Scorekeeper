Option Strict Off
Option Explicit On
'Imports VB = Microsoft.VisualBasic
'Imports Microsoft.VisualBasic.PowerPacks

Friend Class frmPlayerStatsZoom
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

    Private Const BarBottom As Short = 224          ' Pixels
    Private Const BarFullHeight As Short = 200      ' Pixels

    Private mPlayerName As String = String.Empty
    Private mPlayerGameInfo As System.Collections.Generic.List(Of frmPlayerStats.udtPlayerStatsGameInfoType)

    Public Sub SetPlayerInfo(ByVal strPlayerName As String, ByRef udtGameInfo As System.Collections.Generic.List(Of frmPlayerStats.udtPlayerStatsGameInfoType))
        mPlayerName = String.Copy(strPlayerName)
        mPlayerGameInfo = udtGameInfo
    End Sub

    Private Sub UpdateControls()

        Dim dtStartMonth As System.DateTime

        Dim StartYear, StartMonth, StartYearCaption As Short
        Dim CompareDateStart, CompareDateEnd As System.DateTime
        Dim x, intSlashIndex As Short
        Dim GamesPlayed, GamesWon, NewHeight As Short
        Dim ValidDate As Boolean

        Try

            lblPlayer.Text = mPlayerName

            ' Fill in months
            If txtStartMonth.Text.IndexOf("/") > 0 Then
                dtStartMonth = CDate(txtStartMonth.Text)

                StartMonth = CShort(dtStartMonth.ToString("MM"))
                StartYearCaption = CShort(dtStartMonth.ToString("yy"))
                StartYear = CShort(dtStartMonth.ToString("yyyy"))
                ValidDate = True
            Else
                ValidDate = False
            End If

            If Not ValidDate Then
                System.Windows.Forms.MessageBox.Show("Invalid starting month.  Please enter a date in the format month/year, for example, 1/1999 or 1/2000", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            For x = 0 To 11
                lblMonth(x).Text = StartMonth.ToString & "/" & StartYearCaption.ToString("00")
                lblMonth(x).Tag = StartMonth.ToString & "/" & StartYear.ToString
                StartMonth += 1

                If StartMonth > 12 Then
                    StartMonth = 1
                    StartYear += 1
                    StartYearCaption += 1
                    If StartYearCaption > 99 Then StartYearCaption = 0
                End If
            Next x


            For x = 0 To 11
                CompareDateStart = CDate(lblMonth(x).Tag)
                If x < 11 Then
                    CompareDateEnd = CDate(lblMonth(x + 1).Tag)
                Else
                    intSlashIndex = CStr(lblMonth(x).Tag).IndexOf("/")
                    If intSlashIndex > 0 Then
                        StartMonth = CStr(lblMonth(x).Tag).Substring(0, intSlashIndex)
                        StartYear = CStr(lblMonth(x).Tag).Substring(intSlashIndex + 1)
                        StartMonth += 1
                        If StartMonth = 13 Then
                            StartMonth = 1
                            StartYear += 1
                        End If
                        CompareDateEnd = CDate(StartMonth.ToString() & "/" & StartYear.ToString())
                    Else
                        CompareDateEnd = CDate(lblMonth(x).Tag).AddDays(30)
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

                    lblWinRatio(x).Text = GamesWon.ToString & "/" & GamesPlayed.ToString

                    'lblWinRatio(x).Top = shpWinPercent(x).Top - 12
                    lblWinRatio(x).Top = BarBottom - NewHeight - 12

                    If lblWinRatio(x).Top < BarBottom - BarFullHeight Then
                        lblWinRatio(x).Top = (BarBottom - BarFullHeight) - 12
                    End If
                Else
                    'shpWinPercent(x).Height = 0
                    'shpWinPercent(x).Top = BarBottom

                    lblWinRatio(x).Text = "N/A"
                    lblWinRatio(x).Top = BarBottom - 16
                End If
            Next x

        Catch ex As Exception
            HandleException("frmPlayerStatsZoom.UpdateControls", ex)
        End Try

    End Sub

    Private Sub cmdNextPlayer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNextPlayer.Click
        Dim strPlayerName As String
        Dim udtGameInfo As New System.Collections.Generic.List(Of frmPlayerStats.udtPlayerStatsGameInfoType)

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

    Private Sub cmdok_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
        Me.Hide()
    End Sub

    Private Sub cmdPreviousPlayer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPreviousPlayer.Click
        Dim strPlayerName As String
        Dim udtGameInfo As New System.Collections.Generic.List(Of frmPlayerStats.udtPlayerStatsGameInfoType)

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
    Private Sub frmPlayerStatsZoom_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated

        UpdateControls()
    End Sub

    Private Sub frmPlayerStatsZoom_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim ThisMonth, x, StartYear As Short

        Try

            ' Set height and width
            Me.Width = 560
            Me.Height = 313

            ' Position form in window
            Me.Left = (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
            Me.Top = (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - Me.Height) / 3

            ' Load the bars and set height to 0
            For x = 1 To 11
                'With shpWinPercent(0)
                '    _shpWinPercent_0
                '    shpWinPercent.Load(x)
                '    shpWinPercent(x).Left = .Left + 40 * x
                '    shpWinPercent(x).Height = .Height
                '    shpWinPercent(x).Top = .Top
                '    shpWinPercent(x).Width = .Width
                '    shpWinPercent(x).Visible = True
                'End With

                With lblMonth(0)
                    lblMonth.Load(x)
                    lblMonth(x).Left = .Left + 40 * x
                    lblMonth(x).Height = .Height
                    lblMonth(x).Top = .Top
                    lblMonth(x).Width = .Width
                    lblMonth(x).Visible = True
                End With

                With lblWinRatio(0)
                    lblWinRatio.Load(x)
                    lblWinRatio(x).Left = .Left + 40 * x
                    lblWinRatio(x).Height = .Height
                    lblWinRatio(x).Top = .Top
                    lblWinRatio(x).Width = .Width
                    lblWinRatio(x).Visible = True
                    lblWinRatio(x).BringToFront()
                End With

            Next x

            ThisMonth = System.DateTime.Now.ToString("MM")
            StartYear = System.DateTime.Now.ToString("yyyy")
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