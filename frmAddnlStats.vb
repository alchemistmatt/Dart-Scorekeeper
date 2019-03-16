Option Strict Off
Option Explicit On

Imports System.Collections.Generic 'Imports VB = Microsoft.VisualBasic

Friend Class frmAddnlStats
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

    Private Const UNDEFINED_DATE As DateTime = #1/1/1901#

#Region "Module-wide variables"
    Private mStatsModeSaved As Short ' Nominally of type frmStatOptionsDialog.smStatsMode, but initially - 1
    Private mUpdatingLists As Boolean
    Private mSettingDate As Boolean

    Private mDateStart As DateTime
    Private mDateEnd As DateTime

    Private mGameDatesCount As Integer
    Private mGameDatesUnique() As DateTime ' 0-based array

    Private mStatsMode As frmStatOptionsDialog.smStatsMode

    Private mFormLoaded As Boolean
#End Region

    Private Sub FindMatchingGames(ByRef objStats As frmPlayerStats.udtGeneralExtendedStats,
                                  dtMatchDate As DateTime,
                                  ByRef lngTotalScore As Integer,
                                  ByRef lngTotalThrowCount As Integer,
                                  ByRef dtGameDates As SortedList(Of DateTime, Boolean),
                                  Optional ByVal blnFindDateRange As Boolean = True)


        For Each udtGameInfo As frmPlayerStats.udtExtendedStatGameInfoType In objStats.GameInfo
            If blnFindDateRange Then

                If udtGameInfo.GameDate < mDateStart OrElse mDateStart = UNDEFINED_DATE Then
                    mDateStart = udtGameInfo.GameDate
                End If

                If udtGameInfo.GameDate > mDateEnd OrElse mDateEnd = UNDEFINED_DATE Then
                    mDateEnd = udtGameInfo.GameDate
                End If

                ' Record that a game is present on this date
                If Not dtGameDates.ContainsKey(udtGameInfo.GameDate) Then
                    dtGameDates.Add(udtGameInfo.GameDate, True)
                End If
            End If

            ' If this game's date matches dtMatchDate, then update the statistics
            If udtGameInfo.GameDate = dtMatchDate Then
                lngTotalScore += udtGameInfo.GameMeanScorePerThrow * udtGameInfo.GameThrowCount
                lngTotalThrowCount += udtGameInfo.GameThrowCount
            End If

        Next udtGameInfo

    End Sub

    Private Function GetCurrentMatchDate() As DateTime
        Dim dtMatchDate As DateTime
        Dim intDayOfMonth As Short

        dtMatchDate = DateTime.Now

        If cboYear.SelectedIndex >= 0 And cboMonth.SelectedIndex >= 0 Then
            If Not Short.TryParse(txtDayOfMonth.Text, intDayOfMonth) Then
                intDayOfMonth = 1
            End If
            dtMatchDate = New DateTime(cboYear.Text, MonthAbbrevToNum(cboMonth.Text), intDayOfMonth)
        End If

        Return dtMatchDate

    End Function

    Public Sub InitForm(eStatsMode As frmStatOptionsDialog.smStatsMode)

        mStatsMode = eStatsMode

        Try
            If cboStatsToShow.Items.Count = 0 Then
                PopulateStatsToShowComboBox()
            End If

            cboStatsToShow.SelectedIndex = mStatsMode

            ' Disable cboStatsToShow if not using all games
            If mStatsMode = frmStatOptionsDialog.smStatsMode.AllGames Then
                cboStatsToShow.Enabled = True
            Else
                cboStatsToShow.Enabled = False
            End If

        Catch ex As Exception
            HandleException("frmAddnlStats.AssociateForms", ex)
        End Try

        UpdateLists()

    End Sub

    Private Function MonthAbbrevToNum(strMonthAbbreviation As String) As Integer

        Dim dtDate As DateTime

        ' strMonthAbbreviation should be the 3-letter abbreviation for a month
        ' Use TryParse to populate dtDate, then extract out the integer of the month

        If DateTime.TryParse(strMonthAbbreviation & " 2010", dtDate) Then
            Return dtDate.Month
        Else
            Return 1
        End If

    End Function

    Private Sub PopulateComboBoxes()
        Dim intIndex As Short
        Dim dtStart As DateTime

        Dim dtCurrentMatchDate As DateTime

        Static blnUpdatingDate As Boolean

        If blnUpdatingDate Then Exit Sub

        dtCurrentMatchDate = GetCurrentMatchDate()
        blnUpdatingDate = True

        If mDateStart <= UNDEFINED_DATE Then
            mDateStart = DateTime.Now
            mDateEnd = DateTime.Now

            cboGameDates.Items.Clear()
            cboGameDates.Items.Add(mDateStart.ToString("yyyy-MMM-dd"))
        End If

        With cboYear
            .Items.Clear()
            intIndex = Year(mDateStart)
            Do
                .Items.Add(Trim(CStr(intIndex)))
                If intIndex = Year(dtCurrentMatchDate) Then
                    .SelectedIndex = .Items.Count - 1
                End If

                intIndex = intIndex + 1
            Loop While intIndex <= Year(mDateEnd)
            If .SelectedIndex < 0 Then .SelectedIndex = 0
        End With

        With cboMonth
            .Items.Clear()
            dtStart = #1/1/2004#
            For intIndex = 1 To 12
                .Items.Add(dtStart.ToString("MMM"))
                If intIndex = Month(dtCurrentMatchDate) Then
                    .SelectedIndex = .Items.Count - 1
                End If

                dtStart = DateAdd(DateInterval.Month, 1, dtStart)
            Next intIndex
            If .SelectedIndex < 0 Then .SelectedIndex = 0
        End With

        txtDayOfMonth.Text = dtCurrentMatchDate.Day

        blnUpdatingDate = False
    End Sub

    Private Sub PopulateStatsToShowComboBox()
        cboStatsToShow.Items.Clear()
        cboStatsToShow.Items.Add(LookupGameStringByType(gtGameTypeConstants.gtCricket)) ' 0
        cboStatsToShow.Items.Add(LookupGameStringByType(gtGameTypeConstants.gt301)) ' 1
        cboStatsToShow.Items.Add(LookupGameStringByType(gtGameTypeConstants.gtGolf)) ' 2
        cboStatsToShow.Items.Add("All Games") ' 3
    End Sub

    Private Sub SetGameStatsDate(strDate As String)

        Dim dtNewDate As DateTime

        Try
            If DateTime.TryParse(strDate, dtNewDate) Then

                mSettingDate = True

                cboYear.Text = dtNewDate.Year
                cboMonth.SelectedIndex = dtNewDate.Month - 1
                txtDayOfMonth.Text = dtNewDate.Day

                mSettingDate = False

                ValidateSelectedDate()

            End If

        Catch ex As Exception
            HandleException("SetGameStatsDate", ex)
        End Try

    End Sub

    Private Sub ShowHideFrames()
        Dim boolShowGolfStats, boolShow301Stats As Boolean
        Dim lng301FrameLeft, lngGolfFrameLeft, lngFormWidth As Integer

        Const FirstFrameLeft As Short = 544
        Const SecondFrameLeft As Short = 680

        lng301FrameLeft = FirstFrameLeft
        lngGolfFrameLeft = SecondFrameLeft

        Select Case cboStatsToShow.SelectedIndex
            Case 0
                boolShowGolfStats = False
                boolShow301Stats = False
                lngFormWidth = 553
            Case 1
                boolShowGolfStats = False
                boolShow301Stats = True
                lngFormWidth = 693
            Case 2
                boolShowGolfStats = True
                boolShow301Stats = False
                lngFormWidth = 760
                ' Slide Golf frame over on top of 301 frame
                lngGolfFrameLeft = FirstFrameLeft
            Case Else ' Includes case 3 - show all games
                boolShowGolfStats = True
                boolShow301Stats = True
                lngFormWidth = 897
        End Select

        With fra301Stats
            .Visible = boolShow301Stats
            .Left = lng301FrameLeft
        End With

        With fraGolfStats
            .Visible = boolShowGolfStats
            .Left = lngGolfFrameLeft
        End With

        Me.Width = lngFormWidth
    End Sub

    Private Sub SortLists(ByRef ThisList As ListBox)
        Dim x, y As Short
        Dim PointerArray(MAX_PLAYER_COUNT) As Short
        Dim SwapThem, NumericCompare As Boolean
        Dim SaveListArray(MAX_PLAYER_COUNT) As String
        Dim SwapValue As Short


        Dim objThisControl As Control
        Dim objThisListBox As ListBox

        Dim blnSortReverse As Boolean
        blnSortReverse = chkReverseSort.Checked

        Try

            Select Case ThisList.Name
                Case "lstPlayers"
                    NumericCompare = False
                Case Else
                    NumericCompare = True
            End Select

            ' Build a pointer array containing pointers to the items in the listbox
            For x = 0 To ThisList.Items.Count - 1
                PointerArray(x) = x
            Next x

            For x = 0 To ThisList.Items.Count - 2
                For y = x + 1 To ThisList.Items.Count - 1
                    SwapThem = SortCompare(blnSortReverse, ThisList.Items(PointerArray(x)), ThisList.Items(PointerArray(y)), NumericCompare)

                    If SwapThem Then
                        SwapValue = PointerArray(x)
                        PointerArray(x) = PointerArray(y)
                        PointerArray(y) = SwapValue
                    End If
                Next y
            Next x

            For Each objThisControl In Me.Controls
                If TypeOf objThisControl Is ListBox Then
                    ' After sort completes, Actually rearrange the lists
                    objThisListBox = CType(objThisControl, ListControl)

                    With objThisListBox
                        SwapValue = .Items.Count - 1

                        For y = 0 To SwapValue
                            SaveListArray(y) = CStr(.Items(y))
                        Next y

                        .Items.Clear()
                        For y = 0 To SwapValue
                            .Items.Add(SaveListArray(PointerArray(y)))
                        Next y
                    End With
                End If
            Next objThisControl

        Catch ex As Exception
            HandleException("frmAddnl301Stats->SortLists", ex)
        End Try

    End Sub

    Private Sub SynchronizeLists(ByRef objListBox As ListBox)
        Dim objThisControl As Control

        For Each objThisControl In Me.Controls
            Dim thisControl = TryCast(objThisControl, ListBox)
            If (thisControl IsNot Nothing) Then

                If objThisControl.Name <> objListBox.Name Then
                    thisControl.TopIndex = objListBox.TopIndex
                End If
            End If
        Next objThisControl
    End Sub

    Private Sub UpdateLists()
        ' Reload lists with latest data

        Dim x As Short
        Dim objThesePlayerStats As New frmPlayerStats.udtGeneralExtendedStats
        Dim lngDateIndex As Integer
        Dim intPopulateStep As Short

        Dim AllTimeAverageScore As Single

        Dim blnFindDateRange As Boolean

        Dim lngTotalScore As Integer
        Dim lngTotalThrowCount As Integer

        Dim eStatsMode As frmStatOptionsDialog.smStatsMode

        Dim dtGameDates As New SortedList(Of DateTime, Boolean)

        Dim intRowIndexSaved As Short
        Dim lngAllTimeDartsThrownWithoutGolf As Integer
        Dim lngAllTimeTotalScoreWithoutGolf As Integer

        Dim dtMatchDate As DateTime
        Dim objThisControl As Control

        Dim udtCurrentPlayerStats As frmPlayerStats.udtPlayerStatsParsed

        If mUpdatingLists Then Exit Sub
        mUpdatingLists = True

        Try

            intRowIndexSaved = lstPlayers.SelectedIndex

            For Each objThisControl In Me.Controls
                Dim thisControl = TryCast(objThisControl, ListBox)
                If (thisControl IsNot Nothing) Then
                    thisControl.Items.Clear()
                End If
            Next objThisControl

            eStatsMode = cboStatsToShow.SelectedIndex

            dtMatchDate = GetCurrentMatchDate()

            If eStatsMode <> mStatsModeSaved Then
                mStatsModeSaved = eStatsMode

                mDateStart = UNDEFINED_DATE
                mDateEnd = UNDEFINED_DATE

                blnFindDateRange = True
            Else
                blnFindDateRange = False
            End If

            For x = 0 To frmPlayerStats.PlayerStatsCount - 1

                udtCurrentPlayerStats = frmPlayerStats.GetPlayerStatsByIndex(x)

                With udtCurrentPlayerStats
                    lstPlayers.Items.Add(frmPlayerStats.GetPlayerNameByIndex(x))

                    Select Case eStatsMode
                        Case frmStatOptionsDialog.smStatsMode.Cricket
                            ' Playing Cricket
                            objThesePlayerStats = .StatsForCricket

                        Case frmStatOptionsDialog.smStatsMode.Three01
                            ' Playing 301
                            objThesePlayerStats = .StatsFor301
                        Case frmStatOptionsDialog.smStatsMode.Golf

                            ' Playing Golf
                            objThesePlayerStats = .StatsForGolf

                        Case Else
                            ' Statistics for all games
                            ' Need to sum up sub stats for each game type
                            objThesePlayerStats.HighestScoringTurn = MaxVal(.StatsFor301.HighestScoringTurn, .StatsForCricket.HighestScoringTurn, 0)
                            objThesePlayerStats.HighestScoringFirstTurn = MaxVal(.StatsFor301.HighestScoringFirstTurn, .StatsForCricket.HighestScoringFirstTurn, 0)
                            objThesePlayerStats.LongestGameLengthToWin = MaxVal(.StatsFor301.LongestGameLengthToWin, .StatsForCricket.LongestGameLengthToWin, 0)
                            objThesePlayerStats.LongestScoringDrought = MaxVal(.StatsFor301.LongestScoringDrought, .StatsForCricket.LongestScoringDrought, 0)
                            objThesePlayerStats.ShortestGameLengthToWin = MinVal(.StatsFor301.ShortestGameLengthToWin, .StatsForCricket.ShortestGameLengthToWin, 0, False)
                            objThesePlayerStats.AllTimeDartsThrown = .StatsFor301.AllTimeDartsThrown + .StatsForCricket.AllTimeDartsThrown + .StatsForGolf.AllTimeDartsThrown
                            objThesePlayerStats.AllTimeTotalScore = .StatsFor301.AllTimeTotalScore + .StatsForCricket.AllTimeTotalScore + .StatsForGolf.AllTimeTotalScore

                            lngAllTimeDartsThrownWithoutGolf = .StatsFor301.AllTimeDartsThrown + .StatsForCricket.AllTimeDartsThrown
                            lngAllTimeTotalScoreWithoutGolf = .StatsFor301.AllTimeTotalScore + .StatsForCricket.AllTimeTotalScore
                    End Select

                End With

                With objThesePlayerStats
                    lstHighScoreTurn.Items.Add(CheckForZero(.HighestScoringTurn))
                    lstHighestScoringFirstTurn.Items.Add(CheckForZero(.HighestScoringFirstTurn))
                    lstLongestScoringDrought.Items.Add(CheckForZero(.LongestScoringDrought))
                    lstShortestWinningGame.Items.Add(CheckForZero(.ShortestGameLengthToWin))
                    lstLongestWinningGame.Items.Add(CheckForZero(.LongestGameLengthToWin))

                    If lngAllTimeDartsThrownWithoutGolf > 0 And eStatsMode <> frmStatOptionsDialog.smStatsMode.Golf Then
                        AllTimeAverageScore = lngAllTimeTotalScoreWithoutGolf / lngAllTimeDartsThrownWithoutGolf
                        lstMeanScorePerThrow.Items.Add(CStr(Math.Round(AllTimeAverageScore, 1)))
                    Else
                        lstMeanScorePerThrow.Items.Add("")
                    End If
                End With

                ' Compute the mean score per throw for the selected date
                ' If no games were played on the selected date, then display 0
                '
                ' Simultaneously, if blnFindDateRange is True, then determine the valid date range now also

                lngTotalScore = 0
                lngTotalThrowCount = 0

                If eStatsMode = frmStatOptionsDialog.smStatsMode.Cricket OrElse eStatsMode = frmStatOptionsDialog.smStatsMode.Three01 Then
                    FindMatchingGames(objThesePlayerStats, dtMatchDate, lngTotalScore, lngTotalThrowCount, dtGameDates, blnFindDateRange)

                ElseIf eStatsMode = frmStatOptionsDialog.smStatsMode.Golf Then
                    lngTotalThrowCount = 0

                Else
                    FindMatchingGames(udtCurrentPlayerStats.StatsForCricket, dtMatchDate, lngTotalScore, lngTotalThrowCount, dtGameDates, blnFindDateRange)
                    FindMatchingGames(udtCurrentPlayerStats.StatsFor301, dtMatchDate, lngTotalScore, lngTotalThrowCount, dtGameDates, blnFindDateRange)
                End If

                If lngTotalThrowCount > 0 Then
                    lstMeanScorePerThrowPerDay.Items.Add(CheckForZeroSng(Math.Round(lngTotalScore / CSng(lngTotalThrowCount), 1)))
                Else
                    lstMeanScorePerThrowPerDay.Items.Add("")
                End If

                With udtCurrentPlayerStats.Overall301Stats
                    ' 301 stats
                    lst301GamesLostWithoutDoublingIn.Items.Add(CheckForZero(.GamesLostWithoutDoublingIn))
                    lst301MostUntilDoubleIn.Items.Add(CheckForZero(.MostDartsUntilDoubleIn))
                End With

                With udtCurrentPlayerStats.OverallGolfStats
                    ' Golf stats
                    lstGolfLowestGameScore.Items.Add(CheckForInfinity(.LowestScoringGame))
                    lstGolfHighestGameScore.Items.Add(CheckForInfinity(.HighestScoringGame))
                    If .GameCount > 0 Then
                        lstGolfAverageGameScore.Items.Add(CStr(Math.Round(.TotalPointsAllGames / .GameCount, 1)))
                    Else
                        lstGolfAverageGameScore.Items.Add("")
                    End If
                End With

            Next x

            If blnFindDateRange Then

                mGameDatesCount = 0
                If dtGameDates.Count = 0 Then
                    ReDim mGameDatesUnique(0)
                Else
                    ReDim mGameDatesUnique(dtGameDates.Count - 1)

                    ' Populate GameDatesUnique
                    For Each objDate As DateTime In dtGameDates.Keys
                        mGameDatesUnique(mGameDatesCount) = objDate
                        mGameDatesCount += 1
                    Next
                End If


                With cboGameDates
                    .Items.Clear()
                    intPopulateStep = mGameDatesCount \ 300
                    If intPopulateStep < 1 Then intPopulateStep = 1

                    For lngDateIndex = 0 To mGameDatesCount - 1 Step intPopulateStep
                        .Items.Add(mGameDatesUnique(lngDateIndex).ToString("yyyy-MM-dd"))
                    Next lngDateIndex
                    If .Items.Count > 0 Then .SelectedIndex = 0

                End With
            End If

        Catch ex As Exception
            HandleException("frmAddnlStats.PopulateComboBoxes", ex)
        End Try

        Try
            PopulateComboBoxes()

            If blnFindDateRange Then
                SetGameStatsDate(cboGameDates.Text)
            End If
        Catch ex As Exception
            HandleException("frmAddnlStats.PopulateComboBoxes, at ShowHideFrames", ex)
        End Try

        Try
            ShowHideFrames()

            SortLists(lstPlayers)

            If intRowIndexSaved < lstPlayers.Items.Count Then
                lstPlayers.SelectedIndex = intRowIndexSaved
            End If
        Catch ex As Exception
            HandleException("frmAddnlStats.UpdateLists, at ShowHideFrames", ex)
        End Try

        mUpdatingLists = False
        Exit Sub

    End Sub

    Private Sub ValidateSelectedDate()
        Static blnValidatingDate As Boolean

        Dim strYearToMatch As String

        If blnValidatingDate Or mSettingDate Then Exit Sub

        Try

            blnValidatingDate = True

            Dim selectedDate = objCalendar.Value

            If selectedDate.Year < mDateStart.Year Then selectedDate = New Date(mDateStart.Year, selectedDate.month, selectedDate.day)
            If selectedDate.Year > mDateEnd.Year Then selectedDate = New Date(mDateEnd.Year, selectedDate.month, selectedDate.day)

            If selectedDate.Month < mDateStart.Month Then selectedDate = New Date(selectedDate.Year, mDateStart.Month, selectedDate.day)
            If selectedDate.Month > mDateEnd.Month Then selectedDate = New Date(selectedDate.Year, mDateStart.Month, selectedDate.day)

            objCalendar.Value = selectedDate

            strYearToMatch = CStr(objCalendar.Value.Year)
            For intIndex As Integer = 0 To cboYear.Items.Count - 1
                If CStr(cboYear.Items(intIndex)) = strYearToMatch Then
                    cboYear.SelectedIndex = intIndex
                    Exit For
                End If
            Next

            If cboMonth.Items.Count >= objCalendar.Value.Month Then cboMonth.SelectedIndex = objCalendar.Value.Month - 1

            txtDayOfMonth.Text = CStr(objCalendar.Value.Day)

        Catch ex As Exception
            HandleException("ValidateSelectedDate", ex)
        End Try

        blnValidatingDate = False

        UpdateLists()

    End Sub

    Private Sub cboGameDates_SelectedIndexChanged(eventSender As Object, eventArgs As EventArgs) Handles cboGameDates.SelectedIndexChanged
        If mFormLoaded Then
            SetGameStatsDate(cboGameDates.Text)
        End If
    End Sub

    Private Sub cboMonth_SelectedIndexChanged(eventSender As Object, eventArgs As EventArgs) Handles cboMonth.SelectedIndexChanged
        If mFormLoaded Then
            Try
                Dim selectedDate = objCalendar.Value
                selectedDate = New Date(selectedDate.year, cboMonth.SelectedIndex + 1, selectedDate.day)
                objCalendar.Value = selectedDate
            Catch ex As Exception
                ' Ignore errors here
            End Try

            ValidateSelectedDate()
        End If
    End Sub

    Private Sub cboStatsToShow_SelectedIndexChanged(eventSender As Object, eventArgs As EventArgs) Handles cboStatsToShow.SelectedIndexChanged
        If mFormLoaded Then
            ' Allow choosing of any game type
            UpdateLists()
        End If
    End Sub

    Private Sub cboYear_SelectedIndexChanged(eventSender As Object, eventArgs As EventArgs) Handles cboYear.SelectedIndexChanged
        If mFormLoaded Then
            Try
                Dim selectedDate = objCalendar.Value
                selectedDate = New Date(cboYear.Text, selectedDate.month, selectedDate.day)
                objCalendar.Value = selectedDate
            Catch ex As Exception
                ' Ignore errors here
            End Try

            ValidateSelectedDate()
        End If
    End Sub

    Private Sub cmdok_Click(eventSender As Object, eventArgs As EventArgs) Handles cmdOK.Click
        Me.Close()
    End Sub

    Private Sub cmdSelectDate_Click(eventSender As Object, eventArgs As EventArgs) Handles cmdSelectDate.Click
        objCalendar.Visible = Not objCalendar.Visible
        If objCalendar.Visible Then
            cmdSelectDate.Text = "&Hide Calendar"
        Else
            cmdSelectDate.Text = "&Show Calendar"
        End If
    End Sub


    'UPGRADE_ISSUE: ListBox event lst301GamesLostWithoutDoublingIn.Scroll was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
    Private Sub lst301GamesLostWithoutDoublingIn_Scroll()
        SynchronizeLists(lst301GamesLostWithoutDoublingIn)
    End Sub

    'UPGRADE_ISSUE: ListBox event lst301MostUntilDoubleIn.Scroll was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
    Private Sub lst301MostUntilDoubleIn_Scroll()
        SynchronizeLists(lst301MostUntilDoubleIn)
    End Sub

    'UPGRADE_ISSUE: ListBox event lstGolfAverageGameScore.Scroll was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
    Private Sub lstGolfAverageGameScore_Scroll()
        SynchronizeLists(lstGolfAverageGameScore)
    End Sub

    'UPGRADE_ISSUE: ListBox event lstGolfHighestGameScore.Scroll was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
    Private Sub lstGolfHighestGameScore_Scroll()
        SynchronizeLists(lstGolfHighestGameScore)
    End Sub

    'UPGRADE_ISSUE: ListBox event lstGolfLowestGameScore.Scroll was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
    Private Sub lstGolfLowestGameScore_Scroll()
        SynchronizeLists(lstGolfLowestGameScore)
    End Sub

    'UPGRADE_ISSUE: ListBox event lstHighestScoringFirstTurn.Scroll was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
    Private Sub lstHighestScoringFirstTurn_Scroll()
        SynchronizeLists(lstHighestScoringFirstTurn)
    End Sub

    'UPGRADE_ISSUE: ListBox event lstHighScoreTurn.Scroll was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
    Private Sub lstHighScoreTurn_Scroll()
        SynchronizeLists(lstHighScoreTurn)
    End Sub

    'UPGRADE_ISSUE: ListBox event lstLongestScoringDrought.Scroll was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
    Private Sub lstLongestScoringDrought_Scroll()
        SynchronizeLists(lstLongestScoringDrought)
    End Sub

    'UPGRADE_ISSUE: ListBox event lstLongestWinningGame.Scroll was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
    Private Sub lstLongestWinningGame_Scroll()
        SynchronizeLists(lstLongestWinningGame)
    End Sub

    'UPGRADE_ISSUE: ListBox event lstMeanScorePerThrow.Scroll was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
    Private Sub lstMeanScorePerThrow_Scroll()
        SynchronizeLists(lstMeanScorePerThrow)
    End Sub

    'UPGRADE_ISSUE: ListBox event lstMeanScorePerThrowPerDay.Scroll was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
    Private Sub lstMeanScorePerThrowPerDay_Scroll()
        SynchronizeLists(lstMeanScorePerThrowPerDay)
    End Sub

    'UPGRADE_ISSUE: ListBox event lstPlayers.Scroll was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
    Private Sub lstPlayers_Scroll()
        SynchronizeLists(lstPlayers)
    End Sub

    'UPGRADE_ISSUE: ListBox event lstShortestWinningGame.Scroll was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
    Private Sub lstShortestWinningGame_Scroll()
        SynchronizeLists(lstShortestWinningGame)
    End Sub

    Private Sub objCalendar_ClickEvent(eventSender As Object, eventArgs As EventArgs) Handles objCalendar.ValueChanged
        ValidateSelectedDate()
    End Sub

    Private Sub frmAddnlStats_Load(eventSender As Object, eventArgs As EventArgs) Handles MyBase.Load
        mStatsModeSaved = -1

        If cboStatsToShow.Items.Count = 0 Then
            PopulateStatsToShowComboBox()
        End If

        ' Position form in window
        Me.Left = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 3
        Me.Top = (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 3

        mFormLoaded = True
    End Sub

    Private Sub lbl301GamesLostWithoutDoublingIn_Click(eventSender As Object, eventArgs As EventArgs) Handles lbl301GamesLostWithoutDoublingIn.Click
        SortLists(lst301GamesLostWithoutDoublingIn)
    End Sub

    Private Sub lbl301MostUntilDoubleIn_Click(eventSender As Object, eventArgs As EventArgs) Handles lbl301MostUntilDoubleIn.Click
        SortLists(lst301MostUntilDoubleIn)
    End Sub

    Private Sub lblGolfAverageGameScore_Click(eventSender As Object, eventArgs As EventArgs) Handles lblGolfAverageGameScore.Click
        SortLists(lstGolfAverageGameScore)
    End Sub

    Private Sub lblGolfHighestGameScore_Click(eventSender As Object, eventArgs As EventArgs) Handles lblGolfHighestGameScore.Click
        SortLists(lstGolfHighestGameScore)
    End Sub

    Private Sub lblGolfLowestGameScore_Click(eventSender As Object, eventArgs As EventArgs) Handles lblGolfLowestGameScore.Click
        SortLists(lstGolfLowestGameScore)
    End Sub

    Private Sub lblHighestScoringFirstTurn_Click(eventSender As Object, eventArgs As EventArgs) Handles lblHighestScoringFirstTurn.Click
        SortLists(lstHighestScoringFirstTurn)
    End Sub

    Private Sub lblHighScoreTurn_Click(eventSender As Object, eventArgs As EventArgs) Handles lblHighScoreTurn.Click
        SortLists(lstHighScoreTurn)
    End Sub

    Private Sub lblLongestScoringDrought_Click(eventSender As Object, eventArgs As EventArgs) Handles lblLongestScoringDrought.Click
        SortLists(lstLongestScoringDrought)
    End Sub

    Private Sub lblLongestWinningGameLength_Click(eventSender As Object, eventArgs As EventArgs) Handles lblLongestWinningGameLength.Click
        SortLists(lstLongestWinningGame)
    End Sub

    Private Sub lblMeanScorePerThrow_Click(eventSender As Object, eventArgs As EventArgs) Handles lblMeanScorePerThrow.Click
        SortLists(lstMeanScorePerThrow)
    End Sub

    Private Sub lblMeanScorePerThrowPerDay_Click(eventSender As Object, eventArgs As EventArgs) Handles lblMeanScorePerThrowPerDay.Click
        SortLists(lstMeanScorePerThrowPerDay)
    End Sub

    Private Sub lblPlayer_Click(eventSender As Object, eventArgs As EventArgs) Handles lblPlayer.Click
        SortLists(lstPlayers)
    End Sub

    Private Sub lblShortestGameLength_Click(eventSender As Object, eventArgs As EventArgs) Handles lblShortestGameLength.Click
        SortLists(lstShortestWinningGame)
    End Sub

    Private Sub lst301GamesLostWithoutDoublingIn_SelectedIndexChanged(eventSender As Object, eventArgs As EventArgs) Handles lst301GamesLostWithoutDoublingIn.SelectedIndexChanged
        If mFormLoaded Then
            lstPlayers.SelectedIndex = lst301GamesLostWithoutDoublingIn.SelectedIndex
        End If
    End Sub

    Private Sub lst301MostUntilDoubleIn_SelectedIndexChanged(eventSender As Object, eventArgs As EventArgs) Handles lst301MostUntilDoubleIn.SelectedIndexChanged
        If mFormLoaded Then
            lstPlayers.SelectedIndex = lst301MostUntilDoubleIn.SelectedIndex
        End If
    End Sub

    Private Sub lstGolfAverageGameScore_SelectedIndexChanged(eventSender As Object, eventArgs As EventArgs) Handles lstGolfAverageGameScore.SelectedIndexChanged
        If mFormLoaded Then
            lstPlayers.SelectedIndex = lstGolfAverageGameScore.SelectedIndex
        End If
    End Sub

    Private Sub lstGolfHighestGameScore_SelectedIndexChanged(eventSender As Object, eventArgs As EventArgs) Handles lstGolfHighestGameScore.SelectedIndexChanged
        If mFormLoaded Then
            lstPlayers.SelectedIndex = lstGolfHighestGameScore.SelectedIndex
        End If
    End Sub

    Private Sub lstGolfLowestGameScore_SelectedIndexChanged(eventSender As Object, eventArgs As EventArgs) Handles lstGolfLowestGameScore.SelectedIndexChanged
        If mFormLoaded Then
            lstPlayers.SelectedIndex = lstGolfLowestGameScore.SelectedIndex
        End If
    End Sub

    Private Sub lstHighestScoringFirstTurn_SelectedIndexChanged(eventSender As Object, eventArgs As EventArgs) Handles lstHighestScoringFirstTurn.SelectedIndexChanged
        If mFormLoaded Then
            lstPlayers.SelectedIndex = lstHighestScoringFirstTurn.SelectedIndex
        End If
    End Sub

    Private Sub lstHighScoreTurn_SelectedIndexChanged(eventSender As Object, eventArgs As EventArgs) Handles lstHighScoreTurn.SelectedIndexChanged
        If mFormLoaded Then
            lstPlayers.SelectedIndex = lstHighScoreTurn.SelectedIndex
        End If
    End Sub

    Private Sub lstLongestScoringDrought_SelectedIndexChanged(eventSender As Object, eventArgs As EventArgs) Handles lstLongestScoringDrought.SelectedIndexChanged
        If mFormLoaded Then
            lstPlayers.SelectedIndex = lstLongestScoringDrought.SelectedIndex
        End If
    End Sub

    Private Sub lstLongestWinningGame_SelectedIndexChanged(eventSender As Object, eventArgs As EventArgs) Handles lstLongestWinningGame.SelectedIndexChanged
        If mFormLoaded Then
            lstPlayers.SelectedIndex = lstLongestWinningGame.SelectedIndex
        End If
    End Sub

    Private Sub lstMeanScorePerThrow_SelectedIndexChanged(eventSender As Object, eventArgs As EventArgs) Handles lstMeanScorePerThrow.SelectedIndexChanged
        If mFormLoaded Then
            lstPlayers.SelectedIndex = lstMeanScorePerThrow.SelectedIndex
        End If
    End Sub

    Private Sub lstMeanScorePerThrowPerDay_SelectedIndexChanged(eventSender As Object, eventArgs As EventArgs) Handles lstMeanScorePerThrowPerDay.SelectedIndexChanged
        If mFormLoaded Then
            lstPlayers.SelectedIndex = lstMeanScorePerThrowPerDay.SelectedIndex
        End If
    End Sub

    Private Sub lstPlayers_SelectedIndexChanged(eventSender As Object, eventArgs As EventArgs) Handles lstPlayers.SelectedIndexChanged

        Dim objThisControl As Control

        If mFormLoaded Then

            For Each objThisControl In Me.Controls
                Dim thisControl = TryCast(objThisControl, ListBox)
                If (thisControl IsNot Nothing) Then

                    If objThisControl.Name <> "lstPlayers" Then
                        thisControl.SelectedIndex = lstPlayers.SelectedIndex
                    End If
                End If
            Next objThisControl
        End If

    End Sub

    Private Sub lstShortestWinningGame_SelectedIndexChanged(eventSender As Object, eventArgs As EventArgs) Handles lstShortestWinningGame.SelectedIndexChanged
        If mFormLoaded Then
            lstPlayers.SelectedIndex = lstShortestWinningGame.SelectedIndex
        End If
    End Sub

    Private Sub txtDayOfMonth_TextChanged(eventSender As Object, eventArgs As EventArgs) Handles txtDayOfMonth.TextChanged

        Dim intDayOfMonth As Short

        If mFormLoaded Then
            If Short.TryParse(txtDayOfMonth.Text, intDayOfMonth) Then
                If intDayOfMonth < 1 Then
                    intDayOfMonth = 1
                    txtDayOfMonth.Text = intDayOfMonth.ToString
                ElseIf intDayOfMonth > 31 Then
                    intDayOfMonth = 31
                    txtDayOfMonth.Text = intDayOfMonth.ToString
                End If

                Try
                    Dim selectedDate = objCalendar.Value

                    selectedDate = New Date(selectedDate.Year, selectedDate.month, intDayOfMonth)

                    objCalendar.Value = selectedDate

                Catch ex As Exception
                    ' Ignore errors (could occur if intDay is larger than the number of days in this month)
                End Try

                ValidateSelectedDate()

            End If
        End If

    End Sub

    Private Sub txtDayOfMonth_KeyPress(eventSender As Object, eventArgs As KeyPressEventArgs) Handles txtDayOfMonth.KeyPress
        TextBoxKeyPressHandler(txtDayOfMonth, eventArgs, True, False)
    End Sub
End Class