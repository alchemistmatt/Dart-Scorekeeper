Option Strict Off
Option Explicit On
'Imports VB = Microsoft.VisualBasic

Friend Class frmPlayerStats
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

#Region "Constants"

    Private Const RequiredMinGamesPlayed As Short = 2

#End Region

#Region "Structures"

    Public Structure udtPlayerStatsGameInfoType
        Public GameDate As System.DateTime
        Public GameWon As Boolean               ' True if the game was won; false if lost
        Public GameOpponentsIndex As System.Collections.Generic.List(Of Short)
    End Structure


    Public Structure udtGameStatsType
        Public GameDateTime As System.DateTime
        Public PlayerName As String
        Public GameWon As Boolean
        Public PartnerName As String
        Public GamePoints As Short
    End Structure

    Public Structure udtExtendedStats
        Public GameDateTime As System.DateTime
        Public TeamNumber As Short
        Public PlayerName As String
        Public DartValue As Short
        Public Multiplier As Short
        Public ValidHits As Short
    End Structure

    Public Structure udtPlayerRankingStats
        Public OverallRanking As Single         ' Was index 0 in a 2D array
        Public WinPercent As Single             ' Was index 1 in a 2D array
        Public MostRecentRanking As Single      ' Was index 2 in a 2D array
        Public TotalGamesPlayed As Single       ' Was index 3 in a 2D array
    End Structure

    Public Structure udtPlayerStatsType
        Public GameDateTime As System.DateTime
        Public GameTimeElapsed As String
        Public PlayerName As String
        Public GameWon As Boolean
        Public Points As Short
        Public PartnerName As String
        Public GameName As String
    End Structure


    Public Structure usr301Stats
        Public HighestScoringFirstTurn As Short
        Public MostDartsUntilDoubleIn As Short
        Public GamesLostWithoutDoublingIn As Short
    End Structure

    Public Structure usrGolfStats
        Public LowestScoringGame As Short
        Public HighestScoringGame As Short
        Public TotalPointsAllGames As Short
        Public GameCount As Short
    End Structure

    Public Structure udtGeneralExtendedStats
        Public HighestScoringTurn As Short
        Public HighestScoringFirstTurn As Short
        Public ShortestGameLengthToWin As Short
        Public LongestGameLengthToWin As Short
        Public LongestScoringDrought As Short
        Public AllTimeDartsThrown As Integer
        Public AllTimeTotalScore As Integer
        Public GameInfo As System.Collections.Generic.List(Of udtExtendedStatGameInfoType)

        Public Sub Initialize()
            GameInfo = New System.Collections.Generic.List(Of udtExtendedStatGameInfoType)
        End Sub
    End Structure

    Public Structure udtPartnerGameStatsType
        Public GamesWon As Integer
        Public GamesPlayed As Integer
    End Structure

    Public Structure udtExtendedStatGameInfoType
        Public GameDate As System.DateTime
        Public GameMeanScorePerThrow As Single
        Public GameThrowCount As Short
    End Structure

    Public Structure udtPlayerStatsParsed
        Public PlayerNameIndex As Short
        Public GamesWonAlone As Integer
        Public GamesPlayedAlone As Integer
        Public GamesWonWithPartner As Integer
        Public GamesPlayedWithPartner As Integer
        Public FirstGameDate As System.DateTime
        Public LastGameDate As System.DateTime
        Public GamesPlayedPerMonth As Single

        Public PartnerNameCount As Short
        Public PartnerNameIndex() As Short
        Public GamesWonByPartner() As udtPartnerGameStatsType

        Public GameInfo As System.Collections.Generic.List(Of udtPlayerStatsGameInfoType)

        Public StatsFor301 As udtGeneralExtendedStats
        Public StatsForCricket As udtGeneralExtendedStats
        Public StatsForGolf As udtGeneralExtendedStats

        Public OverallGolfStats As usrGolfStats
        Public Overall301Stats As usr301Stats
    End Structure

#End Region

#Region "Module-wide Variables"
    Private mGameStats As System.Collections.Generic.List(Of udtGameStatsType)

    ' Note: mExtendedStats() is 1 based, not 0 based
    Private mExtendedStatsCount As Integer
    Private mExtendedStats() As udtExtendedStats

    Private mStatsMode As frmStatOptionsDialog.smStatsMode

    Private MasterPlayerListCount As Short
    Private MasterPlayerList() As String         ' 0-based (was previously 1-based)

    ' Likely parallel with MasterPlayerList()
    Private mPlayerRanking(MAX_PLAYER_COUNT) As udtPlayerRankingStats     ' 0-based (was previously 1-based)

    ' Likely parallel with MasterPlayerList()
    Private mPlayerStats() As udtPlayerStatsParsed

    Private mFormLoaded As Boolean
#End Region

    Public ReadOnly Property PlayerStatsCount() As Integer
        Get
            Return MasterPlayerListCount
        End Get
    End Property

    Private Sub AddToGameStats(ByVal udtPlayerStatEntry As udtPlayerStatsType)

        Dim udtGameStatsEntry As udtGameStatsType

        With udtPlayerStatEntry
            udtGameStatsEntry.GameDateTime = .GameDateTime
            udtGameStatsEntry.PlayerName = .PlayerName
            udtGameStatsEntry.PartnerName = .PartnerName
            udtGameStatsEntry.GameWon = .GameWon
            udtGameStatsEntry.GamePoints = .Points
        End With

        mGameStats.Add(udtGameStatsEntry)

    End Sub

    Public Sub ParseGamePlayStats()
        Dim x, y As Short
        Dim GamesPlayedTotal, TotalPartnerGames As Short
        Dim BestWinIndex As Short
        Dim BestWinValue As Single
        Dim WorstWinIndex As Short
        Dim WorstWinValue, CompareValue As Single

        ' Compute stats and fill list boxes
        For x = 0 To MasterPlayerListCount - 1
            With mPlayerStats(x)
                lstPlayers.Items.Add(MasterPlayerList(.PlayerNameIndex))
                GamesPlayedTotal = .GamesPlayedAlone + .GamesPlayedWithPartner
                If GamesPlayedTotal > 0 Then
                    lstGamesWon.Items.Add((.GamesWonAlone + .GamesWonWithPartner).ToString & "/" & GamesPlayedTotal.ToString & " (" & ((.GamesWonAlone + .GamesWonWithPartner) / GamesPlayedTotal * 100).ToString("##0") & "%)")

                    mPlayerRanking(x).OverallRanking = 0.5
                    lstRank.Items.Add("0.5")
                Else
                    lstGamesWon.Items.Add("N/A")
                End If

                If .GamesPlayedWithPartner > 0 Then
                    lstGamesWonWithPartner.Items.Add(.GamesWonWithPartner.ToString & "/" & .GamesPlayedWithPartner.ToString & " (" & ((.GamesWonWithPartner) / .GamesPlayedWithPartner * 100).ToString("##0") & "%)")
                Else
                    lstGamesWonWithPartner.Items.Add("N/A")
                End If

                ' Compute Games played per Month
                ' Make sure at least 1 week of stats is defined
                If .LastGameDate.Subtract(.FirstGameDate).TotalDays >= 7 Then
                    ' ToDo: Check this math after converting from VB6
                    .GamesPlayedPerMonth = Math.Round((.GamesPlayedAlone + .GamesPlayedWithPartner) / (.LastGameDate.Subtract(.FirstGameDate).TotalDays * 12 / 365), 1)
                    lstGamesPlayedPerMonth.Items.Add(.GamesPlayedPerMonth.ToString("0.0"))
                Else
                    .GamesPlayedPerMonth = -1
                    lstGamesPlayedPerMonth.Items.Add("N/A")
                End If

                ' Find best and worst partner
                If .PartnerNameCount >= 0 Then
                    ' Count up total partner games played
                    TotalPartnerGames = 0
                    For y = 0 To .PartnerNameCount
                        TotalPartnerGames += .GamesWonByPartner(y).GamesPlayed
                    Next y

                    If TotalPartnerGames > 0 Then
                        BestWinIndex = 0
                        BestWinValue = .GamesWonByPartner(0).GamesWon / TotalPartnerGames

                        WorstWinIndex = 0
                        WorstWinValue = BestWinValue

                        ' Step through the partners and determine win percentage with that partner
                        For y = 0 To .PartnerNameCount
                            CompareValue = .GamesWonByPartner(y).GamesWon / TotalPartnerGames
                            If CompareValue > BestWinValue Then
                                BestWinValue = CompareValue
                                BestWinIndex = y
                            End If
                            If CompareValue < WorstWinValue Then
                                WorstWinValue = CompareValue
                                WorstWinIndex = y
                            End If
                        Next y

                        lstBestPartner.Items.Add(MasterPlayerList(.PartnerNameIndex(BestWinIndex)) & " - (" & .GamesWonByPartner(BestWinIndex).GamesWon.ToString() & "/" & .GamesWonByPartner(BestWinIndex).GamesPlayed.ToString() & ")")
                        lstWorstPartner.Items.Add(MasterPlayerList(.PartnerNameIndex(WorstWinIndex)) & " - (" & .GamesWonByPartner(WorstWinIndex).GamesWon.ToString() & "/" & .GamesWonByPartner(WorstWinIndex).GamesPlayed.ToString() & ")")
                    Else
                        lstBestPartner.Items.Add("N/A")
                        lstWorstPartner.Items.Add("N/A")
                    End If
                Else
                    lstBestPartner.Items.Add("N/A")
                    lstWorstPartner.Items.Add("N/A")
                End If
            End With
        Next x

    End Sub

    Private Sub DoRankings(ByVal StopDate As System.DateTime)
        Dim x As Short
        Dim StartingDate, EndingDate As System.DateTime
        Dim DateWeight As Single

        ' Erase values in PlayerRanking(x)
        For x = 0 To MasterPlayerListCount - 1
            mPlayerRanking(x).OverallRanking = 0
            mPlayerRanking(x).TotalGamesPlayed = 0
        Next x

        ' Compute ranking, lowering the weight over time
        ' Exit if StartingDate is before the StopDate
        For x = 1 To 4
            Select Case x
                Case 1 ' 1 month ago to today
                    StartingDate = System.DateTime.Now.AddDays(-30)
                    EndingDate = System.DateTime.Now
                    DateWeight = 0.6
                Case 2 ' 4 months ago to 1 month ago
                    StartingDate = System.DateTime.Now.AddDays(-120)
                    EndingDate = System.DateTime.Now.AddDays(-30)
                    DateWeight = 0.25
                Case 3 ' 8 months ago to 4 months ago
                    StartingDate = System.DateTime.Now.AddDays(-240)
                    EndingDate = System.DateTime.Now.AddDays(-120)
                    DateWeight = 0.1
                Case Else ' 12 months ago to 8 months ago
                    StartingDate = System.DateTime.Now.AddDays(-365)
                    EndingDate = System.DateTime.Now.AddDays(-240)
                    DateWeight = 0.05
            End Select

            If StartingDate < StopDate Then
                Exit For
            Else
                RankPlayers(StartingDate, EndingDate, DateWeight)
            End If
        Next x

    End Sub

    Private Sub FindBestWorstPlayer(ByVal StartingDate As System.DateTime)

        ' Finds the best and worst player simply by looking at the rankings list
        Dim x As Short
        Dim MaxRank, MinRank As Single
        Dim MaxRankIndex, MinRankIndex As Short
        Dim RecentGamesPlayed(1) As Short
        Dim RecentGamesWon(1) As Short
        Dim RecentGamesPlayedTemp, RecentGamesWonTemp As Short

        Dim intPlayerIndex As Integer
        Dim sngPlayerRank As Single

        Try

            MaxRank = -1
            MaxRankIndex = -1
            MinRank = 1.1
            MinRankIndex = -1

            ' Find player with highest and lowest ranking simply by looking at the ranking list
            For x = 0 To lstRank.Items.Count - 1

                If Single.TryParse(lstRank.Items(x), sngPlayerRank) Then

                    ' Make sure player has played Recently
                    intPlayerIndex = GetPlayerIndex(CStr(lstPlayers.Items(x)))

                    If intPlayerIndex >= 0 Then

                        ' Find the players' recent win record

                        RecentGamesPlayedTemp = 0
                        RecentGamesWonTemp = 0

                        For Each udtGameDetails As udtPlayerStatsGameInfoType In mPlayerStats(intPlayerIndex).GameInfo
                            If udtGameDetails.GameDate >= StartingDate AndAlso StartingDate <= System.DateTime.Now Then
                                RecentGamesPlayedTemp += 1
                                If udtGameDetails.GameWon Then
                                    RecentGamesWonTemp += 1
                                End If
                            End If
                        Next


                        If RecentGamesPlayedTemp > 0 Then
                            ' Only consider the player if they've played recently
                            If sngPlayerRank > MaxRank Then
                                MaxRank = sngPlayerRank
                                MaxRankIndex = x
                                RecentGamesPlayed(0) = RecentGamesPlayedTemp
                                RecentGamesWon(0) = RecentGamesWonTemp
                            End If

                            If sngPlayerRank < MinRank Then
                                MinRank = sngPlayerRank
                                MinRankIndex = x
                                RecentGamesPlayed(1) = RecentGamesPlayedTemp
                                RecentGamesWon(1) = RecentGamesWonTemp
                            End If
                        End If

                    End If

                End If
            Next x

            If MaxRankIndex >= 0 And RecentGamesPlayed(0) <> 0 Then
                lblBestPlayerName.Text = lstPlayers.Items(MaxRankIndex).ToString() & ": " & RecentGamesWon(0).ToString() & "/" & RecentGamesPlayed(0).ToString & " (" & (RecentGamesWon(0) / RecentGamesPlayed(0) * 100).ToString("##0") & "%)"
            Else
                lblBestPlayerName.Text = "N/A"
            End If

            If MinRankIndex >= 0 And RecentGamesPlayed(1) <> 0 Then
                lblWorstPlayerName.Text = lstPlayers.Items(MinRankIndex).ToString() & ": " & RecentGamesWon(1).ToString() & "/" & RecentGamesPlayed(1).ToString() & " (" & (RecentGamesWon(1) / RecentGamesPlayed(1) * 100).ToString("##0") & "%)"
            Else
                lblWorstPlayerName.Text = "N/A"
            End If


        Catch ex As Exception
            HandleException("FindBestWorstPlayer", ex)
        End Try

    End Sub

    Private Function FindMatchingFiles(ByVal strFilePathBase As String, ByRef strFileMatchList As System.Collections.Generic.SortedList(Of String, String)) As Integer
        Dim ioDirInfo As System.IO.DirectoryInfo
        Dim ioFileInfo As System.IO.FileInfo

        Dim strFileSpecToFind As String
        Dim strFileMatchCheck As String

        Dim strFileBaseCompare1 As String
        Dim strFileBaseCompare2 As String

        Try

            strFileMatchList.Clear()

            ioDirInfo = New System.IO.DirectoryInfo(System.IO.Path.GetDirectoryName(strFilePathBase))

            If Not ioDirInfo.Exists() Then
                ' Directory not found
                Return 0
            End If

            ' Step through all of the .Ini files in the folder
            strFileSpecToFind = System.IO.Path.GetFileNameWithoutExtension(strFilePathBase) & "*.ini"

            ' If the name matches the base exactly, or if it matches the base plus an underscore, then count this as a match
            strFileBaseCompare1 = (System.IO.Path.GetFileNameWithoutExtension(strFilePathBase) & ".ini").ToLower()
            strFileBaseCompare2 = (System.IO.Path.GetFileNameWithoutExtension(strFilePathBase) & "_").ToLower()

            For Each ioFileInfo In ioDirInfo.GetFiles(strFileSpecToFind)
                strFileMatchCheck = ioFileInfo.Name.ToLower()

                If strFileMatchCheck = strFileBaseCompare1 Or strFileMatchCheck.StartsWith(strFileBaseCompare2) Then
                    strFileMatchList.Add(ioFileInfo.FullName, "")
                End If
            Next

            Return strFileMatchList.Count

        Catch ex As Exception
            HandleException("FindMatchingFiles", ex)
        End Try

    End Function

    Public Function GetPlayerGameInfo(ByVal strPlayerName As String, ByRef udtGameInfo As System.Collections.Generic.List(Of udtPlayerStatsGameInfoType)) As Boolean
        Dim intPlayerIndex As Integer

        intPlayerIndex = GetPlayerIndex(strPlayerName)

        If intPlayerIndex >= 0 Then
            Return GetPlayerGameInfo(intPlayerIndex, udtGameInfo)
        Else
            Return False
        End If
    End Function

    Public Function GetPlayerGameInfo(ByVal intPlayerIndex As Integer, ByRef udtGameInfo As System.Collections.Generic.List(Of udtPlayerStatsGameInfoType)) As Boolean

        If intPlayerIndex >= 0 Then
            udtGameInfo = mPlayerStats(intPlayerIndex).GameInfo
            Return True
        Else
            Return False
        End If

    End Function

    ''' <summary>
    ''' Looks for PlayerName in MasterPlayerList()
    ''' </summary>
    ''' <param name="PlayerName"></param>
    ''' <returns>Index if found; -1 if not found</returns>
    ''' <remarks></remarks>
    Protected Function GetPlayerIndex(ByRef PlayerName As String) As Short
        Dim x As Short

        For x = 0 To MasterPlayerListCount - 1
            If MasterPlayerList(x) = PlayerName Then
                Return x
            End If
        Next x

        Return -1

    End Function

    Public Function GetPlayerNameByIndex(ByVal intPlayerIndex As Integer) As String
        If intPlayerIndex >= 0 And intPlayerIndex < MasterPlayerListCount Then
            Return MasterPlayerList(intPlayerIndex)
        Else
            Return String.Empty
        End If
    End Function

    Public Function GetPlayerStatsByIndex(ByVal intPlayerIndex As Integer) As udtPlayerStatsParsed
        If intPlayerIndex >= 0 And intPlayerIndex < MasterPlayerListCount Then
            Return mPlayerStats(intPlayerIndex)
        Else
            Return New udtPlayerStatsParsed
        End If
    End Function

    Protected Sub InitializePlayerStats()

        Dim intIndex As Short

        ReDim mPlayerRanking(MAX_PLAYER_COUNT)
        ReDim MasterPlayerList(MAX_PLAYER_COUNT)

        ReDim mPlayerStats(MAX_PLAYER_COUNT)
        For intIndex = 0 To MAX_PLAYER_COUNT - 1
            With mPlayerStats(intIndex)
                ReDim .PartnerNameIndex(MAX_PLAYER_COUNT)
                ReDim .GamesWonByPartner(MAX_PLAYER_COUNT)

                .GameInfo = New System.Collections.Generic.List(Of udtPlayerStatsGameInfoType)

                .StatsFor301.Initialize()
                .StatsForCricket.Initialize()
                .StatsForGolf.Initialize()

            End With
        Next intIndex

    End Sub

    Private Sub ParseExtendedGameStats(ByVal lngCurrentTurnStartIndex As Integer, _
                                       ByVal lngCurrentTurnStopIndex As Integer, _
                                       ByRef ThisPlayerStats As udtPlayerStatsParsed, _
                                       ByRef intDartsThrownThisGame As Short, _
                                       ByRef intDartsSinceLastScore As Short, _
                                       ByRef lngTotalScoreThisGame As Integer, _
                                       ByVal eGameType As gtGameTypeConstants, _
                                       ByVal blnRequireDoubleInFor301 As Boolean, _
                                       ByRef blnHasScoredThisGame As Boolean)

        ' This sub gets called for each recorded "turn", typically every 3 darts thrown (though not necessarily true for golf)

        Dim intTurnScoreValid As Short
        Dim intTurnScoreRaw, intThisThrowScoreRaw As Short
        Dim lngExtStatIndex As Integer
        Dim objThisPlayerExtStats As udtGeneralExtendedStats
        Dim intDartsThrownThisGameTemp As Short
        Dim boolFirstScoreOfGame As Boolean

        Select Case eGameType
            Case gtGameTypeConstants.gt301
                objThisPlayerExtStats = ThisPlayerStats.StatsFor301
            Case gtGameTypeConstants.gtCricket
                objThisPlayerExtStats = ThisPlayerStats.StatsForCricket
            Case gtGameTypeConstants.gtGolf
                objThisPlayerExtStats = ThisPlayerStats.StatsForGolf
            Case Else
                ' Unknown mode
                System.Windows.Forms.MessageBox.Show("Unknown game mode in ParseExtendedGameStats: " & LookupGameStringByType(eGameType), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                objThisPlayerExtStats = New udtGeneralExtendedStats
        End Select

        intTurnScoreValid = 0
        intTurnScoreRaw = 0
        For lngExtStatIndex = lngCurrentTurnStartIndex To lngCurrentTurnStopIndex
            With mExtendedStats(lngExtStatIndex)
                If .ValidHits = 0 Then
                    intDartsSinceLastScore = intDartsSinceLastScore + 1
                    If intDartsSinceLastScore > objThisPlayerExtStats.LongestScoringDrought Then
                        objThisPlayerExtStats.LongestScoringDrought = intDartsSinceLastScore
                    End If
                Else
                    If eGameType = gtGameTypeConstants.gt301 Then
                        ' Record # of darts until double in if not doubled in yet
                        If blnRequireDoubleInFor301 And Not blnHasScoredThisGame Then
                            If .ValidHits <> 2 Then
                                ' This spot should not be reached
                                System.Windows.Forms.MessageBox.Show(".ValidHits <> 2 in ParseExtendedGameStats; this is unexpected", "Code error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            End If

                            blnHasScoredThisGame = True
                            boolFirstScoreOfGame = True
                            intDartsThrownThisGameTemp = intDartsThrownThisGame + lngExtStatIndex - lngCurrentTurnStartIndex + 1
                            If intDartsThrownThisGameTemp > ThisPlayerStats.Overall301Stats.MostDartsUntilDoubleIn Then
                                ThisPlayerStats.Overall301Stats.MostDartsUntilDoubleIn = intDartsThrownThisGameTemp
                            End If
                        End If
                    Else
                        ' For all games, set boolFirstScoreOfGame to true for first scoring points
                        If Not blnHasScoredThisGame Then
                            blnHasScoredThisGame = True
                            boolFirstScoreOfGame = True
                        End If
                    End If

                    ' Find total turn score
                    intTurnScoreValid = intTurnScoreValid + .DartValue * .ValidHits
                    intDartsSinceLastScore = 0
                End If

                intThisThrowScoreRaw = .DartValue * .Multiplier
                intTurnScoreRaw = intTurnScoreRaw + intThisThrowScoreRaw

                objThisPlayerExtStats.AllTimeDartsThrown = objThisPlayerExtStats.AllTimeDartsThrown + 1
                objThisPlayerExtStats.AllTimeTotalScore = objThisPlayerExtStats.AllTimeTotalScore + intThisThrowScoreRaw
            End With
        Next lngExtStatIndex

        intDartsThrownThisGame = intDartsThrownThisGame + lngCurrentTurnStopIndex - lngCurrentTurnStartIndex + 1
        lngTotalScoreThisGame = lngTotalScoreThisGame + intTurnScoreRaw

        If intTurnScoreValid > objThisPlayerExtStats.HighestScoringTurn Then
            objThisPlayerExtStats.HighestScoringTurn = intTurnScoreValid
        End If

        If boolFirstScoreOfGame Then
            If eGameType = gtGameTypeConstants.gt301 Then
                ' Check for highest scoring first turn for 301
                If intTurnScoreValid > ThisPlayerStats.Overall301Stats.HighestScoringFirstTurn Then
                    ThisPlayerStats.Overall301Stats.HighestScoringFirstTurn = intTurnScoreValid
                End If
            End If

            ' Check for highest scoring first turn for all games
            If intTurnScoreValid > objThisPlayerExtStats.HighestScoringFirstTurn Then
                objThisPlayerExtStats.HighestScoringFirstTurn = intTurnScoreValid
            End If
        End If

        ' Copy the stats from objThisPlayerExtStats back to ThisPlayerStats
        Select Case eGameType
            Case gtGameTypeConstants.gt301
                ThisPlayerStats.StatsFor301 = objThisPlayerExtStats
            Case gtGameTypeConstants.gtCricket
                ThisPlayerStats.StatsForCricket = objThisPlayerExtStats
            Case gtGameTypeConstants.gtGolf
                ThisPlayerStats.StatsForGolf = objThisPlayerExtStats
        End Select

    End Sub

    Private Sub ParseGameStats(ByVal boolParseExtendedStatFile As Boolean, _
                               ByVal strGameTypeName As String, _
                               ByVal eStatsMode As frmStatOptionsDialog.smStatsMode)

        ' When eStatsMode is 0, just show Cricket stats
        ' When eStatsMode is 1, just show 301 stats
        ' When eStatsMode is 2, just show Golf stats
        ' When eStatsMode is 3, show cumulative stats for all games (excluding golf from the rankings)

        Dim x, playeri, z As Short
        Dim y As Integer
        Dim PartnerNameSwap As String
        Dim PlayerFound, PartnerFound As Boolean
        Dim PlayerNameWork As String
        Dim boolExcludeGolfGame As Boolean
        Dim PlayerIndexWork, PartnerIndexWork As Short
        Dim OpponentIndex1, OpponentIndex2 As Short
        Dim WinningTeamIndex As Short
        Dim lngExtStatStartIndex, lngExtStatStopIndex As Integer
        Dim intThisGamePoints As Short
        Dim lngCurrentTurnStartIndex As Integer
        Dim strPreviousTurnPlayerName As String
        Dim intDartsThrownThisGame, intDartsSinceLastScore As Short
        Dim lngTotalScoreThisGame As Integer

        Dim boolRequireDoubleIn, boolHasScoredThisGame As Boolean
        Dim strPlayersExaminedForDoubleIn As String

        Dim eGameType As gtGameTypeConstants

        Try

            eGameType = LookupGameTypeByString(strGameTypeName)

            ' First go through and register all Players
            ' Also, record which team/player won this game
            WinningTeamIndex = -1
            For Each udtGameStatEntry As udtGameStatsType In mGameStats

                If udtGameStatEntry.GameWon Then WinningTeamIndex = x
                For playeri = 1 To 2
                    If playeri = 1 Then
                        PlayerNameWork = udtGameStatEntry.PlayerName
                    Else
                        PlayerNameWork = udtGameStatEntry.PartnerName
                        If String.IsNullOrEmpty(PlayerNameWork) Then Exit For
                    End If

                    PlayerFound = False
                    For y = 0 To MasterPlayerListCount - 1
                        If MasterPlayerList(y) = PlayerNameWork Then
                            PlayerFound = True
                            Exit For
                        End If
                    Next y

                    ' Add Player if not found
                    If Not PlayerFound Then
                        MasterPlayerList(MasterPlayerListCount) = String.Copy(PlayerNameWork)

                        With mPlayerStats(MasterPlayerListCount)
                            .PlayerNameIndex = MasterPlayerListCount
                            .PartnerNameCount = -1
                            .FirstGameDate = udtGameStatEntry.GameDateTime
                            .OverallGolfStats.HighestScoringGame = Short.MinValue
                            .OverallGolfStats.LowestScoringGame = Short.MaxValue
                        End With

                        MasterPlayerListCount += 1

                    End If
                Next playeri
            Next

            ' Next determine the start and stop indices in the mExtendedStats() array for this game
            lngExtStatStartIndex = 0
            lngExtStatStopIndex = 0
            If boolParseExtendedStatFile AndAlso mGameStats.Count > 0 Then
                For y = 1 To mExtendedStatsCount

                    If mGameStats(0).GameDateTime = mExtendedStats(y).GameDateTime Then
                        ' Found the first record for this game in the extended stats file
                        ' Record the index
                        If lngExtStatStartIndex = 0 Then lngExtStatStartIndex = y
                    ElseIf lngExtStatStartIndex > 0 Then
                        ' If previously on the current game and now on a new game, record index
                        lngExtStatStopIndex = y - 1
                        Exit For
                    End If
                Next y
            End If

            If lngExtStatStartIndex > 0 And lngExtStatStopIndex = 0 Then
                ' Matched the current game in the extended stats file, but didn't find a game
                ' after it.  Thus, must be the last game in the Extended Stats file
                ' Record appropriate lngExtStatStopIndex
                lngExtStatStopIndex = mExtendedStatsCount
            End If

            ' Now go through the Players for this game and add their statistics
            For Each udtGameStatEntry As udtGameStatsType In mGameStats
                For playeri = 1 To 2
                    ' ParseStats
                    PlayerIndexWork = GetPlayerIndex(udtGameStatEntry.PlayerName)

                    If PlayerIndexWork >= 0 Then

                        ' Add Stats for player stored in mPlayerStats(PlayerIndexWork)
                        With mPlayerStats(PlayerIndexWork)
                            If eStatsMode = frmStatOptionsDialog.smStatsMode.AllGames AndAlso eGameType = gtGameTypeConstants.gtGolf Then
                                boolExcludeGolfGame = True
                            Else
                                boolExcludeGolfGame = False
                            End If

                            If Not boolExcludeGolfGame Then
                                ' Do not parse these stats if parsing all games and this game is golf
                                ' Increment GamesPlayed counters (separate alone & with partner; sum is total)
                                If String.IsNullOrEmpty(udtGameStatEntry.PartnerName) Then
                                    .GamesPlayedAlone += 1
                                Else
                                    .GamesPlayedWithPartner += 1
                                End If

                                If udtGameStatEntry.GameWon = True Then
                                    If String.IsNullOrEmpty(udtGameStatEntry.PartnerName) Then
                                        .GamesWonAlone += 1
                                    Else
                                        .GamesWonWithPartner += 1
                                    End If
                                End If

                                ' Create a new entry to add to .GamesPlayed for this player
                                Dim udtGameDetails As udtPlayerStatsGameInfoType

                                If udtGameStatEntry.GameWon = True Then
                                    ' Record Game Win Status
                                    udtGameDetails.GameWon = True
                                Else
                                    udtGameDetails.GameWon = False
                                End If

                                udtGameDetails.GameDate = udtGameStatEntry.GameDateTime

                                ' Record Opponents -- all if player won, or only the winner if player lost
                                udtGameDetails.GameOpponentsIndex = New System.Collections.Generic.List(Of Short)

                                For Each udtGameStatCompare As udtGameStatsType In mGameStats
                                    OpponentIndex1 = GetPlayerIndex(udtGameStatCompare.PlayerName)

                                    If String.IsNullOrEmpty(udtGameStatCompare.PartnerName) Then
                                        OpponentIndex2 = -1
                                    Else
                                        OpponentIndex2 = GetPlayerIndex(udtGameStatCompare.PartnerName)
                                    End If

                                    If PlayerIndexWork = OpponentIndex1 OrElse PlayerIndexWork = OpponentIndex2 Then
                                        ' Current team, don't count
                                    Else
                                        ' Again, if .GameWinStatus(CompareGameCount) = 1 then record all
                                        ' otherwise, when .GameWinStatus(CompareGameCount) = 0 only record winner
                                        If udtGameDetails.GameWon OrElse y = WinningTeamIndex Then

                                            If Not udtGameDetails.GameOpponentsIndex.Contains(OpponentIndex1) Then
                                                udtGameDetails.GameOpponentsIndex.Add(OpponentIndex1)
                                            End If

                                            If OpponentIndex2 >= 0 Then
                                                If Not udtGameDetails.GameOpponentsIndex.Contains(OpponentIndex2) Then
                                                    udtGameDetails.GameOpponentsIndex.Add(OpponentIndex2)
                                                End If
                                            End If
                                        End If
                                    End If
                                Next udtGameStatCompare

                                ' Add the new game details entry to .GamesPlayed
                                .GameInfo.Add(udtGameDetails)

                                If .LastGameDate < udtGameStatEntry.GameDateTime Then .LastGameDate = udtGameStatEntry.GameDateTime

                            End If

                            ' If Playing Golf, look for new stats
                            If eGameType = gtGameTypeConstants.gtGolf Then
                                intThisGamePoints = udtGameStatEntry.GamePoints
                                If intThisGamePoints < .OverallGolfStats.LowestScoringGame Then
                                    .OverallGolfStats.LowestScoringGame = intThisGamePoints
                                End If
                                If intThisGamePoints > .OverallGolfStats.HighestScoringGame Then
                                    .OverallGolfStats.HighestScoringGame = intThisGamePoints
                                End If
                                .OverallGolfStats.TotalPointsAllGames = .OverallGolfStats.TotalPointsAllGames + intThisGamePoints
                                .OverallGolfStats.GameCount = .OverallGolfStats.GameCount + 1
                            End If

                            ' Parse the extended stats for this game, assigning new statistics
                            '  for this player as necessary
                            If boolParseExtendedStatFile And lngExtStatStartIndex > 0 Then
                                lngCurrentTurnStartIndex = 0
                                strPreviousTurnPlayerName = String.Empty
                                intDartsSinceLastScore = 0
                                intDartsThrownThisGame = 0
                                lngTotalScoreThisGame = 0

                                strPlayersExaminedForDoubleIn = String.Empty
                                If eGameType = gtGameTypeConstants.gt301 Then
                                    ' First determine if doubling in was required for this game
                                    ' Do this by looking to see if any of the player's 1st dart that scored points was a double

                                    ' Assume we will require double in
                                    boolRequireDoubleIn = True
                                    For y = lngExtStatStartIndex To lngExtStatStopIndex

                                        If mExtendedStats(y).ValidHits > 0 Then
                                            ' See if player has been examined yet
                                            If Not strPlayersExaminedForDoubleIn.Contains(";" & mExtendedStats(y).PlayerName & ";") Then

                                                strPlayersExaminedForDoubleIn &= ";" & mExtendedStats(y).PlayerName & ";"
                                                If mExtendedStats(y).ValidHits <> 2 Then
                                                    boolRequireDoubleIn = False
                                                    Exit For
                                                End If
                                            End If
                                        End If
                                    Next y
                                Else
                                    boolRequireDoubleIn = False
                                End If

                                boolHasScoredThisGame = False
                                For y = lngExtStatStartIndex To lngExtStatStopIndex
                                    If mExtendedStats(y).PlayerName = udtGameStatEntry.PlayerName Then
                                        If strPreviousTurnPlayerName <> mExtendedStats(y).PlayerName Then
                                            ' Start of a new turn
                                            lngCurrentTurnStartIndex = y
                                        End If
                                    ElseIf strPreviousTurnPlayerName = udtGameStatEntry.PlayerName Then
                                        ' Completed previous turn, parse the previous turn
                                        ParseExtendedGameStats(lngCurrentTurnStartIndex, y - 1, mPlayerStats(PlayerIndexWork), intDartsThrownThisGame, intDartsSinceLastScore, lngTotalScoreThisGame, eGameType, boolRequireDoubleIn, boolHasScoredThisGame)
                                        lngCurrentTurnStartIndex = 0
                                    End If
                                    strPreviousTurnPlayerName = mExtendedStats(y).PlayerName
                                Next y
                                If lngCurrentTurnStartIndex > 0 Then
                                    ' Stats remaining to be parsed
                                    ParseExtendedGameStats(lngCurrentTurnStartIndex, y - 1, mPlayerStats(PlayerIndexWork), intDartsThrownThisGame, intDartsSinceLastScore, lngTotalScoreThisGame, eGameType, boolRequireDoubleIn, boolHasScoredThisGame)
                                End If

                                ' See if never doubled in
                                ' Make sure at least 6 darts have been thrown by this player
                                If boolRequireDoubleIn And Not boolHasScoredThisGame Then
                                    If intDartsThrownThisGame >= 6 Then
                                        mPlayerStats(PlayerIndexWork).Overall301Stats.GamesLostWithoutDoublingIn = mPlayerStats(PlayerIndexWork).Overall301Stats.GamesLostWithoutDoublingIn + 1
                                    End If
                                End If

                                ' Record game-wide stats for this player
                                If udtGameStatEntry.GameWon And intDartsThrownThisGame > 0 Then
                                    Select Case eGameType
                                        Case gtGameTypeConstants.gt301
                                            RecordExtendedGameStats(mPlayerStats(PlayerIndexWork).StatsFor301, intDartsThrownThisGame)
                                        Case gtGameTypeConstants.gtCricket
                                            RecordExtendedGameStats(mPlayerStats(PlayerIndexWork).StatsForCricket, intDartsThrownThisGame)
                                        Case gtGameTypeConstants.gtGolf
                                            RecordExtendedGameStats(mPlayerStats(PlayerIndexWork).StatsForGolf, intDartsThrownThisGame)
                                    End Select
                                End If

                                Select Case eGameType
                                    Case gtGameTypeConstants.gt301
                                        RecordMeanThrowGameStats(mPlayerStats(PlayerIndexWork).StatsFor301, udtGameStatEntry.GameDateTime, intDartsThrownThisGame, lngTotalScoreThisGame)
                                    Case gtGameTypeConstants.gtCricket
                                        RecordMeanThrowGameStats(mPlayerStats(PlayerIndexWork).StatsForCricket, udtGameStatEntry.GameDateTime, intDartsThrownThisGame, lngTotalScoreThisGame)
                                    Case gtGameTypeConstants.gtGolf
                                        RecordMeanThrowGameStats(mPlayerStats(PlayerIndexWork).StatsForGolf, udtGameStatEntry.GameDateTime, intDartsThrownThisGame, lngTotalScoreThisGame)
                                End Select

                            End If

                            If String.IsNullOrEmpty(udtGameStatEntry.PartnerName) Then
                                Exit For
                            Else
                                If Not boolExcludeGolfGame Then
                                    ' Record partner stats
                                    PartnerIndexWork = GetPlayerIndex(udtGameStatEntry.PartnerName)
                                    PartnerFound = False

                                    If PartnerIndexWork >= 0 Then
                                        For z = 0 To .PartnerNameCount
                                            If .PartnerNameIndex(z) = PartnerIndexWork Then
                                                PartnerFound = True
                                                Exit For
                                            End If
                                        Next z
                                    End If

                                    If Not PartnerFound Then
                                        ' Add Partner
                                        .PartnerNameCount = .PartnerNameCount + 1
                                        .PartnerNameIndex(.PartnerNameCount) = PartnerIndexWork
                                        z = .PartnerNameCount
                                    End If

                                    ' If game won, increment for this partner
                                    If udtGameStatEntry.GameWon Then .GamesWonByPartner(z).GamesWon += 1

                                    ' Increment total games played with this partner
                                    .GamesWonByPartner(z).GamesPlayed += 1

                                    ' Swap Player and Partner and add stats
                                    PartnerNameSwap = udtGameStatEntry.PlayerName
                                    udtGameStatEntry.PlayerName = udtGameStatEntry.PartnerName
                                    udtGameStatEntry.PartnerName = PartnerNameSwap
                                End If
                            End If

                        End With

                    End If
                Next playeri

            Next udtGameStatEntry


        Catch ex As Exception
            HandleException("ParseGameStats", ex)
        End Try

    End Sub

    ''' <summary>
    ''' Splits strLineToParse on commas
    ''' </summary>
    ''' <param name="strLineToParse"></param>
    ''' <param name="KeyString"></param>
    ''' <returns></returns>
    ''' <remarks>The number of items parsed out of strLineToParse</remarks>
    Private Function ParseLine(ByVal strLineToParse As String, ByRef KeyString() As String) As Integer
        Static chSepChars() As Char = New Char() {","c}

        Dim x As Short
        Dim strItems() As String
        Dim intKeyStringItemCount As Integer

        intKeyStringItemCount = 0
        x = strLineToParse.IndexOf("="c)

        ' ToDo: Check this code, ported from VB6

        If x > 0 AndAlso x < strLineToParse.Length - 1 Then

            strLineToParse = strLineToParse.Substring(x + 1).Trim()

            If strLineToParse.Length > 0 Then
                strItems = strLineToParse.Split(chSepChars, MAX_PARSELINE_COUNT)
                intKeyStringItemCount = strItems.Length

                Array.Copy(strItems, KeyString, intKeyStringItemCount)
            End If
        End If

        Return intKeyStringItemCount

    End Function

    Private Sub RankPlayers(ByVal StartingDate As System.DateTime, ByVal EndingDate As System.DateTime, ByVal DateWeight As Single)
        Dim x As Short
        Dim OpponentRankSum, OpponentRank As Single
        Dim RecentGamesWonRelative As Single
        Dim RecentGamesPlayed(MAX_PLAYER_COUNT) As Short
        Dim RecentGamesWon(MAX_PLAYER_COUNT) As Short
        Dim MaxRecentGamesWon As Short

        Try

            ' Recompute player win% based on StartingDate
            MaxRecentGamesWon = -1
            For x = 0 To MasterPlayerListCount - 1
                RecentGamesPlayed(x) = 0
                For Each udtGameInfo As udtPlayerStatsGameInfoType In mPlayerStats(x).GameInfo
                    If udtGameInfo.GameDate >= StartingDate AndAlso udtGameInfo.GameDate <= EndingDate Then
                        RecentGamesPlayed(x) += 1
                        If udtGameInfo.GameWon Then
                            RecentGamesWon(x) += 1
                        End If
                    End If
                Next udtGameInfo

                If RecentGamesWon(x) > MaxRecentGamesWon Then
                    MaxRecentGamesWon = RecentGamesWon(x)
                End If

                mPlayerRanking(x).TotalGamesPlayed += RecentGamesPlayed(x)

                If RecentGamesPlayed(x) Then
                    ' Store the player's Win% in .WinPercent
                    mPlayerRanking(x).WinPercent = RecentGamesWon(x) / RecentGamesPlayed(x)
                Else
                    mPlayerRanking(x).WinPercent = -1
                End If
            Next x

            For x = 0 To MasterPlayerListCount - 1
                ' For each player, step through games and determine rank

                If mPlayerRanking(x).WinPercent >= 0 Then
                    ' Player has played in time period between StartingDate & EndingDate


                    OpponentRank = 0
                    For Each udtGameInfo As udtPlayerStatsGameInfoType In mPlayerStats(x).GameInfo
                        If udtGameInfo.GameDate >= StartingDate AndAlso udtGameInfo.GameDate <= EndingDate Then
                            ' If person won game, then add up the win percents of all opponents
                            ' Store in OpponentRank and weight 30%

                            ' If person lost game, then only use the win percents of the winning team
                            ' Store in OpponentRank and weight 20%

                            ' The opponents list already contains the correct opponents depending on if the game was won or lost; this was done in sub ParseStats

                            OpponentRankSum = 0
                            If Not udtGameInfo.GameOpponentsIndex Is Nothing Then
                                For Each intOpponentIndex As Short In udtGameInfo.GameOpponentsIndex
                                    ' Add up the win percents of all opponents
                                    If mPlayerRanking(intOpponentIndex).WinPercent >= 0 Then
                                        OpponentRankSum += mPlayerRanking(intOpponentIndex).WinPercent
                                    End If
                                Next intOpponentIndex

                                ' Average the win percents for this game
                                If udtGameInfo.GameOpponentsIndex.Count > 0 Then
                                    ' Again, use 30% if player won game and 20% if lost
                                    If udtGameInfo.GameWon Then
                                        OpponentRank += 0.35 * OpponentRankSum / udtGameInfo.GameOpponentsIndex.Count
                                    Else
                                        OpponentRank += 0.15 * OpponentRankSum / udtGameInfo.GameOpponentsIndex.Count
                                    End If
                                Else
                                    ' No opponents, skip game
                                End If
                            End If

                        End If
                    Next udtGameInfo


                    If MaxRecentGamesWon > 0 Then
                        RecentGamesWonRelative = RecentGamesWon(x) / MaxRecentGamesWon
                    Else
                        RecentGamesWonRelative = 0
                    End If

                    If mPlayerStats(x).GameInfo.Count > 0 Then
                        ' Store Ranking in PlayerRanking(x).MostRecentRanking and add to PlayerRanking(x).OverallRanking based on weighting
                        mPlayerRanking(x).MostRecentRanking = 0.5 * mPlayerRanking(x).WinPercent + OpponentRank / mPlayerStats(x).GameInfo.Count + 0.1 * RecentGamesWonRelative
                        mPlayerRanking(x).OverallRanking += DateWeight * mPlayerRanking(x).MostRecentRanking

                    Else
                        ' No games, playerranking = 0
                        mPlayerRanking(x).OverallRanking += 0
                    End If
                Else
                    ' Player hasn't played recently
                    ' No games, playerranking = 0
                    mPlayerRanking(x).OverallRanking += 0
                End If
            Next x

        Catch ex As Exception
            HandleException("RankPlayers", ex)
        End Try

    End Sub

    Private Sub ReadStatsFile(ByVal eStatsMode As frmStatOptionsDialog.smStatsMode)
        ' When eStatsMode is 0, just show Cricket stats
        ' When eStatsMode is 1, just show 301 stats
        ' When eStatsMode is 2, just show Golf stats
        ' When eStatsMode is 3, show cumulative stats for all games (excluding golf from the rankings)

        Dim diFolderInfo As System.IO.DirectoryInfo
        Dim strStatsFileWildcard As String

        Dim srInFile As System.IO.StreamReader

        Dim intFileMatchCount As Integer
        Dim strFileMatchList As New System.Collections.Generic.SortedList(Of String, String)
        Dim strFilePath As System.Collections.Generic.KeyValuePair(Of String, String)

        Dim boolExtFileExist As Boolean
        Dim strLineIn As String

        Dim KeyString(MAX_PARSELINE_COUNT) As String
        Dim intKeyStringItemCount As Short

        Dim ValidGame As Boolean
        Dim PreviousGameDateTime As System.DateTime
        Dim LineWaiting As Boolean
        Dim strGameTypeName As String
        Dim PredictedGameCount, ActualGameCount As Integer

        Dim udtPlayerStatEntry As udtPlayerStatsType

        Dim eGameType As gtGameTypeConstants
        Dim objProgress As frmProgress

        ' Temp test variables
        Dim TotalScore As Integer
        Dim TotalCount As Integer
        TotalScore = 0
        TotalCount = 0

        Try

            InitializePlayerStats()
            ReDim MasterPlayerList(MAX_PLAYER_COUNT)

            MasterPlayerListCount = 0

            PreviousGameDateTime = System.DateTime.MinValue
            PredictedGameCount = 0

            If mGameStats Is Nothing Then
                mGameStats = New System.Collections.Generic.List(Of udtGameStatsType)
            Else
                mGameStats.Clear()
            End If

            strStatsFileWildcard = StatsFileNameBase & "*.ini"

            diFolderInfo = New System.IO.DirectoryInfo(System.IO.Path.GetDirectoryName(strStatsFileWildcard))

            If diFolderInfo.GetFiles(System.IO.Path.GetFileName(strStatsFileWildcard)).Length = 0 Then
                ' Stats file missing
                System.Windows.Forms.MessageBox.Show("The statistics file cannot be found: " & strStatsFileWildcard & ";  Process aborted.", "File not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            objProgress = New frmProgress
            objProgress.InitializeForm("Loading Extended Stats", 0, 2)
            objProgress.Show()
            System.Windows.Forms.Application.DoEvents()

            ' Find all of the StatsExtd_*.ini and StatsExtd.ini files
            intFileMatchCount = FindMatchingFiles(StatsExtendedFilenameBase, strFileMatchList)

            If intFileMatchCount > 0 Then
                boolExtFileExist = True

                ' Dynamically allocate memory for the array that holds the stats
                ' Note: mExtendedStats() is a 1 based array, not a 0 based array
                ReDim mExtendedStats(10000)
                mExtendedStatsCount = 0

                For Each strFilePath In strFileMatchList

                    srInFile = New System.IO.StreamReader(New System.IO.FileStream(strFilePath.Key, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read))

                    Do While srInFile.Peek() >= 0

                        strLineIn = srInFile.ReadLine
                        intKeyStringItemCount = ParseLine(strLineIn, KeyString)

                        If intKeyStringItemCount >= 6 Then
                            mExtendedStatsCount += 1
                            If mExtendedStatsCount >= mExtendedStats.Length Then
                                ReDim Preserve mExtendedStats(mExtendedStats.Length * 2 - 1)
                            End If

                            With mExtendedStats(mExtendedStatsCount)
                                .GameDateTime = CDate(KeyString(0))
                                If PreviousGameDateTime <> .GameDateTime Then
                                    PreviousGameDateTime = .GameDateTime
                                    PredictedGameCount += 1
                                End If

                                .TeamNumber = CShort(KeyString(1))
                                .PlayerName = KeyString(2)
                                .DartValue = CShort(KeyString(3))
                                .Multiplier = CShort(KeyString(4))
                                .ValidHits = CShort(KeyString(5))

                                If .PlayerName = "Arthur (T)" Then
                                    TotalCount += 1
                                    TotalScore += .DartValue * .Multiplier
                                End If

                            End With
                        End If
                    Loop
                    srInFile.Close()

                Next
            Else
                boolExtFileExist = False
            End If

            If PredictedGameCount > 0 Then
                objProgress.InitializeForm("Loading and Parsing Stats", 1, PredictedGameCount)
            End If

            PreviousGameDateTime = System.DateTime.MinValue
            ActualGameCount = 0
            strGameTypeName = String.Empty

            ' Find all of the Stats_*.ini files (excluding StatsExtd files)
            intFileMatchCount = FindMatchingFiles(StatsFileNameBase, strFileMatchList)

            For Each strFilePath In strFileMatchList
                srInFile = New System.IO.StreamReader(New System.IO.FileStream(strFilePath.Key, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read))

                Do While srInFile.Peek() >= 0 And MasterPlayerListCount < MAX_PLAYER_COUNT

                    ' Read Line
                    strLineIn = srInFile.ReadLine
                    intKeyStringItemCount = ParseLine(strLineIn, KeyString)

                    If intKeyStringItemCount >= 7 Then
                        With udtPlayerStatEntry
                            System.DateTime.TryParse(KeyString(0), .GameDateTime)
                            .GameTimeElapsed = KeyString(1)
                            .PlayerName = KeyString(2)
                            .PartnerName = KeyString(3)
                            Boolean.TryParse(KeyString(4), .GameWon)
                            Short.TryParse(KeyString(5), .Points)
                            .GameName = KeyString(6)
                            eGameType = LookupGameTypeByString(.GameName)
                        End With
                        LineWaiting = True

                        If eStatsMode = frmStatOptionsDialog.smStatsMode.AllGames Then
                            ValidGame = True
                        Else
                            ' Check gametype
                            If eStatsMode = frmStatOptionsDialog.smStatsMode.Cricket AndAlso eGameType = gtGameTypeConstants.gtCricket OrElse _
                               eStatsMode = frmStatOptionsDialog.smStatsMode.Three01 AndAlso eGameType = gtGameTypeConstants.gt301 OrElse _
                               eStatsMode = frmStatOptionsDialog.smStatsMode.Golf AndAlso eGameType = gtGameTypeConstants.gtGolf Then
                                ValidGame = True
                            Else
                                ValidGame = False
                            End If
                        End If

                        If ValidGame Then
                            ' See if this line is part of the current game
                            If udtPlayerStatEntry.GameDateTime = PreviousGameDateTime Then
                                ' Current game
                                AddToGameStats(udtPlayerStatEntry)
                            Else
                                If mGameStats.Count > 0 Then
                                    ' Process previous game
                                    ParseGameStats(boolExtFileExist, strGameTypeName, eStatsMode)
                                End If

                                ActualGameCount += 1
                                objProgress.UpdateProgressBar(ActualGameCount)

                                LineWaiting = False
                                mGameStats.Clear()
                                strGameTypeName = udtPlayerStatEntry.GameName

                                AddToGameStats(udtPlayerStatEntry)
                                PreviousGameDateTime = udtPlayerStatEntry.GameDateTime
                            End If

                        End If
                    End If
                Loop

                srInFile.Close()
            Next

            ' Process previous game
            If LineWaiting AndAlso mGameStats.Count > 0 Then
                ParseGameStats(boolExtFileExist, strGameTypeName, eStatsMode)
            End If

            If MasterPlayerListCount >= MAX_PLAYER_COUNT Then
                Dim strMessage As String
                strMessage = "Can only parse " & MAX_PLAYER_COUNT & " players in the stats file.  Please delete old games/players by archiving the old Stats and StatsExtd Ini files in the application folder (" & System.IO.Path.GetDirectoryName(StatsExtendedFilenameBase) & ")"

                System.Windows.Forms.MessageBox.Show(strMessage, "Too many players", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            objProgress.InitializeForm("Parsing Stats", 0, 2)

            ParseGamePlayStats()

            objProgress.Hide()

            If MasterPlayerListCount <= 0 Then
                System.Windows.Forms.MessageBox.Show("No valid statistics were found in the Statistics file.", "No Statistics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        Catch ex As Exception
            HandleException("ReadStatsFile", ex)
        End Try


    End Sub

    Private Sub RecordMeanThrowGameStats(ByRef ThisPlayerExtStats As udtGeneralExtendedStats, _
                                         ByVal dtGameDate As System.DateTime, _
                                         ByVal intDartsThrownThisGame As Short, _
                                         ByVal lngTotalScoreThisGame As Integer)

        Dim udtGameInfo As udtExtendedStatGameInfoType

        With udtGameInfo
            .GameDate = dtGameDate
            .GameThrowCount = intDartsThrownThisGame

            ' Compute the mean score per throw (for this game)
            If intDartsThrownThisGame > 0 Then
                .GameMeanScorePerThrow = lngTotalScoreThisGame / intDartsThrownThisGame
            Else
                .GameMeanScorePerThrow = 0
            End If
        End With

        ThisPlayerExtStats.GameInfo.Add(udtGameInfo)

    End Sub

    Private Sub RecordExtendedGameStats(ByRef ThisPlayerExtStats As udtGeneralExtendedStats, ByVal intDartsThrownThisGame As Short)
        ' Note: This sub only gets called if the player won the game

        With ThisPlayerExtStats
            ' Check for shortest game won
            If .ShortestGameLengthToWin <> 0 Then
                If intDartsThrownThisGame < .ShortestGameLengthToWin Then
                    .ShortestGameLengthToWin = intDartsThrownThisGame
                End If
            Else
                .ShortestGameLengthToWin = intDartsThrownThisGame
            End If

            If .ShortestGameLengthToWin < MIN_GAME_LENGTH_THROWS_TO_COUNT Then
                .ShortestGameLengthToWin = 0
            End If

            ' Check for longest game won
            If .LongestGameLengthToWin <> 0 Then
                If intDartsThrownThisGame > .LongestGameLengthToWin Then
                    .LongestGameLengthToWin = intDartsThrownThisGame
                End If
            Else
                .LongestGameLengthToWin = intDartsThrownThisGame
            End If

        End With

    End Sub

    ''' <summary>
    ''' Selects the next player in lstPlayers
    ''' </summary>
    ''' <returns>The Player Name</returns>
    ''' <remarks></remarks>
    Public Function SelectNextPlayer() As String
        With lstPlayers
            If .SelectedIndex < .Items.Count - 1 Then
                .SelectedIndex += 1
            Else
                .SelectedIndex = 0
            End If
        End With

        Return CStr(lstPlayers.SelectedItem)
    End Function

    ''' <summary>
    ''' Selects the previous player in lstPlayers
    ''' </summary>
    ''' <returns>The Player Name</returns>
    ''' <remarks></remarks>
    Public Function SelectPreviousPlayer() As String
        With lstPlayers
            If .SelectedIndex > 0 Then
                .SelectedIndex -= 1
            Else
                .SelectedIndex = .Items.Count - 1
            End If
        End With

        Return CStr(lstPlayers.SelectedItem)
    End Function


    Private Sub ShowAdditionalStats()

        Try            
            frmAddnlStats.InitForm(mStatsMode)

            frmAddnlStats.ShowDialog()

            frmAddnlStats.Close()

        Catch ex As Exception
            HandleException("ShowAdditionalStats", ex)
        End Try

    End Sub

    Private Sub ShowZoomStats()

        Dim strPlayerName As String
        Dim intPlayerIndex As Integer
        Dim udtGameInfo As New System.Collections.Generic.List(Of udtPlayerStatsGameInfoType)

        Try
            strPlayerName = CStr(lstPlayers.SelectedItem)

            If String.IsNullOrEmpty(strPlayerName) Then
                strPlayerName = "No Player Selected"
            End If

            intPlayerIndex = GetPlayerIndex(strPlayerName)

            If intPlayerIndex < 0 Then
                System.Windows.Forms.MessageBox.Show("Player '" + strPlayerName + "' not found in MasterPlayerList; unable to continue.", "Unknown Player", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                If GetPlayerGameInfo(intPlayerIndex, udtGameInfo) Then

                    frmPlayerStatsZoom.SetPlayerInfo(strPlayerName, udtGameInfo)

                    frmPlayerStatsZoom.ShowDialog()

                    frmPlayerStatsZoom.Close()

                End If

            End If

        Catch ex As Exception
            HandleException("ShowZoomStats for current player", ex)
        End Try
      

    End Sub

    Private Sub SortLists(ByRef ThisList As System.Windows.Forms.ListBox)
        Dim x, y As Short
        Dim PointerArray(MAX_PLAYER_COUNT) As Short
        Dim SwapThem, NumericCompare As Boolean
        Dim SaveListArray(MAX_PLAYER_COUNT) As String
        Dim SwapValue As Short

        Dim objThisControl As System.Windows.Forms.Control
        Dim objThisListBox As System.Windows.Forms.ListBox

        Dim blnSortReverse As Boolean
        blnSortReverse = chkReverseSort.Checked

        Try

            Select Case ThisList.Name
                Case "lstGamesWon", "lstGamesWonWithPartner", "lstGamesPlayedPerMonth", "lstRank"
                    NumericCompare = True
                Case Else
                    NumericCompare = False
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
                If TypeOf objThisControl Is System.Windows.Forms.ListBox Then
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
            HandleException("PlyrStat->SortLists", ex)
        End Try

    End Sub

    Private Sub SynchronizeLists(ByRef objListBox As System.Windows.Forms.ListBox)
        Dim objThisControl As System.Windows.Forms.Control
        Dim objThisListBox As System.Windows.Forms.ListBox

        For Each objThisControl In Me.Controls
            If TypeOf objThisControl Is System.Windows.Forms.ListBox Then

                objThisListBox = CType(objThisControl, ListControl)

                If objThisListBox.Name <> objListBox.Name Then
                    objThisListBox.TopIndex = objListBox.TopIndex
                End If
            End If
        Next objThisControl
    End Sub

    Private Sub cboDaysForStats_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboDaysForStats.SelectedIndexChanged
        Dim x, workx As Short
        Dim MaxRanking As Single

        If Not mFormLoaded Then
            Exit Sub
        End If

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        ' First find rankings for times up to value in cboDaysForStats
        Dim dtStopDate As System.DateTime
        dtStopDate = System.DateTime.Now.AddDays(-GetComboBoxItemText(cboDaysForStats))

        DoRankings(dtStopDate)

        Dim dtStartDate As System.DateTime

        ' ToDo: Validate this logic (carryover from VB6)
        dtStartDate = dtStopDate
        FindBestWorstPlayer(dtStartDate)

        ' Now find rankings for the last year
        DoRankings(System.DateTime.Now.AddYears(-1))

        ' Normalize scores to player with highest score
        MaxRanking = -1
        For x = 0 To MasterPlayerListCount - 1
            If mPlayerRanking(x).OverallRanking > MaxRanking AndAlso mPlayerRanking(x).TotalGamesPlayed > RequiredMinGamesPlayed Then
                MaxRanking = mPlayerRanking(x).OverallRanking
            End If

        Next x

        If MaxRanking > 0 Then
            ' Normalize the rankings to a scale of 0 to 1
            For x = 0 To MasterPlayerListCount - 1
                mPlayerRanking(x).OverallRanking = mPlayerRanking(x).OverallRanking / MaxRanking
            Next x
        End If

        ' Write results to list
        lstRank.Items.Clear()
        For x = 0 To MasterPlayerListCount - 1
            workx = GetPlayerIndex(CStr(lstPlayers.Items(x)))
            If workx >= 0 Then
                If mPlayerRanking(workx).OverallRanking >= 0 AndAlso mPlayerRanking(workx).TotalGamesPlayed > RequiredMinGamesPlayed Then
                    lstRank.Items.Add(mPlayerRanking(workx).OverallRanking.ToString("0.000"))
                Else
                    lstRank.Items.Add("N/A")
                End If
            Else
                lstRank.Items.Add("N/A")
            End If
        Next x

        dtStartDate = System.DateTime.Now.AddDays(-GetComboBoxItemText(cboDaysForStats))
        FindBestWorstPlayer(dtStartDate)

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        SortLists(lstRank)

    End Sub

    Private Sub cmdAddnlStats_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAddnlStats.Click
        ShowAdditionalStats()
    End Sub

    Private Sub cmdHelp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdHelp.Click
        Dim objHelp As New frmRankHelp
        objHelp.ShowDialog()
        If Not objHelp Is Nothing Then objHelp.Close()
    End Sub

    Private Sub cmdok_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
        Me.Close()
    End Sub

    Private Sub frmPlayerStats_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        Try

            ' Center form in window
            Me.Left = (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
            Me.Top = (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2

            ' Show the statistics options form
            frmStatOptionsDialog.ShowDialog()

            If Not frmStatOptionsDialog Is Nothing Then
                mStatsMode = frmStatOptionsDialog.StatsModeSelected()
                frmStatOptionsDialog.Close()
            Else
                mStatsMode = frmStatOptionsDialog.smStatsMode.AllGames
            End If

            ReadStatsFile(mStatsMode)

            ' Fill in cboDaysForStats
            cboDaysForStats.Items.Add("30")
            cboDaysForStats.Items.Add("60")
            cboDaysForStats.Items.Add("90")
            cboDaysForStats.Items.Add("120")
            cboDaysForStats.Items.Add("365")
            cboDaysForStats.SelectedIndex = 0 ' Automatically fills in BestPlayer and WorstPlayer boxes

            ' Uncomment to sort the lists
            '' SortLists lstRank

            mFormLoaded = True

        Catch ex As Exception
            HandleException("frmPlayerStats_Load", ex)
        End Try

    End Sub
	
	Private Sub Label1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Label1.Click
		SortLists(lstGamesWonWithPartner)
	End Sub
	
	Private Sub Label2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Label2.Click
		SortLists(lstGamesWon)
	End Sub
	
	Private Sub Label3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Label3.Click
		SortLists(lstGamesPlayedPerMonth)
	End Sub
	
	Private Sub Label4_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Label4.Click
		SortLists(lstBestPartner)
	End Sub
	
	Private Sub Label5_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Label5.Click
		SortLists(lstWorstPartner)
	End Sub
	
	Private Sub Label7_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Label7.Click
		SortLists(lstRank)
	End Sub
	
	Private Sub lblBestPlayer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lblBestPlayer.Click
		cboDaysForStats_SelectedIndexChanged(cboDaysForStats, New System.EventArgs())
	End Sub
	
	Private Sub lblBestPlayerName_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lblBestPlayerName.Click
		cboDaysForStats_SelectedIndexChanged(cboDaysForStats, New System.EventArgs())
	End Sub
	
	Private Sub lblPlayer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lblPlayer.Click
		SortLists(lstPlayers)
	End Sub
	
	Private Sub lblWorstPlayer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lblWorstPlayer.Click
		cboDaysForStats_SelectedIndexChanged(cboDaysForStats, New System.EventArgs())
	End Sub
	
	Private Sub lblWorstPlayerName_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lblWorstPlayerName.Click
		cboDaysForStats_SelectedIndexChanged(cboDaysForStats, New System.EventArgs())
	End Sub
	
	'UPGRADE_WARNING: Event lstBestPartner.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub lstBestPartner_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstBestPartner.SelectedIndexChanged
		lstPlayers.SelectedIndex = lstBestPartner.SelectedIndex
	End Sub
	
    Private Sub lstBestPartner_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstBestPartner.DoubleClick
        ShowZoomStats()
    End Sub
	
	'UPGRADE_ISSUE: ListBox event lstBestPartner.Scroll was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
	Private Sub lstBestPartner_Scroll()
		SynchronizeLists(lstBestPartner)
	End Sub
	
	'UPGRADE_WARNING: Event lstGamesPlayedPerMonth.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub lstGamesPlayedPerMonth_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstGamesPlayedPerMonth.SelectedIndexChanged
		lstPlayers.SelectedIndex = lstGamesPlayedPerMonth.SelectedIndex
	End Sub
	
	Private Sub lstGamesPlayedPerMonth_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstGamesPlayedPerMonth.DoubleClick
        ShowZoomStats()
	End Sub
	
	'UPGRADE_ISSUE: ListBox event lstGamesPlayedPerMonth.Scroll was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
	Private Sub lstGamesPlayedPerMonth_Scroll()
		SynchronizeLists(lstGamesPlayedPerMonth)
	End Sub
	
	'UPGRADE_WARNING: Event lstGamesWon.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub lstGamesWon_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstGamesWon.SelectedIndexChanged
		lstPlayers.SelectedIndex = lstGamesWon.SelectedIndex
	End Sub
	
    Private Sub lstGamesWon_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstGamesWon.DoubleClick
        ShowZoomStats()
    End Sub
	
	'UPGRADE_ISSUE: ListBox event lstGamesWon.Scroll was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
	Private Sub lstGamesWon_Scroll()
		SynchronizeLists(lstGamesWon)
	End Sub
	
	'UPGRADE_WARNING: Event lstGamesWonWithPartner.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub lstGamesWonWithPartner_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstGamesWonWithPartner.SelectedIndexChanged
		lstPlayers.SelectedIndex = lstGamesWonWithPartner.SelectedIndex
	End Sub
	
	Private Sub lstGamesWonWithPartner_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstGamesWonWithPartner.DoubleClick
        ShowZoomStats()
	End Sub
	
	'UPGRADE_ISSUE: ListBox event lstGamesWonWithPartner.Scroll was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
	Private Sub lstGamesWonWithPartner_Scroll()
		SynchronizeLists(lstGamesWonWithPartner)
	End Sub
	
	'UPGRADE_WARNING: Event lstPlayers.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub lstPlayers_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstPlayers.SelectedIndexChanged
		lstRank.SelectedIndex = lstPlayers.SelectedIndex
		lstGamesWon.SelectedIndex = lstPlayers.SelectedIndex
		lstGamesWonWithPartner.SelectedIndex = lstPlayers.SelectedIndex
		lstGamesPlayedPerMonth.SelectedIndex = lstPlayers.SelectedIndex
		lstBestPartner.SelectedIndex = lstPlayers.SelectedIndex
		lstWorstPartner.SelectedIndex = lstPlayers.SelectedIndex
	End Sub
	
	Private Sub lstPlayers_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstPlayers.DoubleClick
        ShowZoomStats()
	End Sub
	
	'UPGRADE_ISSUE: ListBox event lstPlayers.Scroll was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
	Private Sub lstPlayers_Scroll()
		SynchronizeLists(lstPlayers)
	End Sub
	
	'UPGRADE_WARNING: Event lstRank.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub lstRank_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstRank.SelectedIndexChanged
		lstPlayers.SelectedIndex = lstRank.SelectedIndex
	End Sub
	
	Private Sub lstRank_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstRank.DoubleClick
        ShowZoomStats()
	End Sub
	
	'UPGRADE_ISSUE: ListBox event lstRank.Scroll was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
	Private Sub lstRank_Scroll()
		SynchronizeLists(lstRank)
	End Sub
	
	'UPGRADE_WARNING: Event lstWorstPartner.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub lstWorstPartner_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstWorstPartner.SelectedIndexChanged
		lstPlayers.SelectedIndex = lstWorstPartner.SelectedIndex
	End Sub
	
	Private Sub lstWorstPartner_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstWorstPartner.DoubleClick
        ShowZoomStats()
	End Sub
	
	'UPGRADE_ISSUE: ListBox event lstWorstPartner.Scroll was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
	Private Sub lstWorstPartner_Scroll()
		SynchronizeLists(lstWorstPartner)
	End Sub
End Class