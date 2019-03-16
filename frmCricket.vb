Option Strict Off
Option Explicit On
'Imports VB = Microsoft.VisualBasic

Friend Class frmCricket
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

#Region "Constants and Enums"
    Private Const MaxUndoHistory As Short = 5000
	Private Const MaxBoxIndex As Short = 41
	Private Const BoxesPerCol As Short = 7
	
    Private Const SCOREBOX_SIZE_NORMAL As Short = 33        ' Pixels
    Private Const SCOREBOX_SIZE_SMALL As Short = 25         ' Pixels
	
	Private Const SCOREBOX_DIM_ADDON As Short = 5
	
	Private Enum spScorePictureConstants
		spZero = 0
		spOne = 1
		spTwo = 2
		spThree = 3
		spClosed = 4
		spZeroDimmed = 5
		spOneDimmed = 6
		spTwoDimmed = 7
		spThreeDimmed = 8
		spClosedDimmed = 9
	End Enum
#End Region

#Region "Structures"
    Public Structure udtRealTimeStatsType
        Public PlayerName As String
        Public ThrowCount As Short
        Public ScoreTotal As Integer
    End Structure

    Public Structure usrUndoHistory
        Public TeamIndex As Short
        Public DartValue As Short
        Public Multiplier As Short
        Public DistanceFromCenter As Short
        Public ValidHits As Short
        ' Note: ValidHits is a count of how many of the subhits for this throw counted
        '    i.e. If a player has two 20's, and hits a double 20, but the other
        '         teams have already closed out 20's, then only the first of the two parts
        '         of the double 20 actually counts
        Public PlayerName As String
    End Structure
#End Region

#Region "Module-wide variables"
    Private UndoHistory(MaxUndoHistory) As usrUndoHistory ' 1-based array
	Private boolDoubledIn() As Boolean
	Private intCurrentHole() As Short
	Private intMostRecentGolfScore As Short
	
	Private UndoHistoryCount, MaxUndoHistoryCount As Short
	Private HistoryIndexOfMostRecentTurn As Short
	
	Private MaxTeamIndexInGame, MaxBoxIndexInGame As Short
    Private mStartTime, mLastClickTime As System.DateTime
    Private mLastClickTeam As Short
    Private mPauseDelay As Integer
    Private PlayerRow, PlayerColumn As Short ' Both are 0-based

    ' The following variables are used to prevent the history buffer from getting scrambled
    Private mUndoRedoInProgress As Boolean
    Private mNewGameButtonClicked As Boolean

    Private mRelativeScoringEnabled As Boolean
    Private mScoreAreaSize As modDarts.sasScoreAreaSizeConstants

    Private mGameType As modDarts.gtGameTypeConstants = modDarts.gtGameTypeConstants.gtCricket

#End Region

    Public Sub AdvanceToNextTeam(ByVal boolSkipEliminatedTeams As Boolean)

        Try

            Do
                If lstCurrentTeam.SelectedIndex < MaxTeamIndexInGame Then
                    lstCurrentTeam.SelectedIndex = lstCurrentTeam.SelectedIndex + 1
                    PlayerColumn = PlayerColumn + 1
                Else
                    lstCurrentTeam.SelectedIndex = 0
                    PlayerColumn = 0
                    If PlayerRow = 1 Then PlayerRow = 0 Else PlayerRow = 1
                End If
            Loop While boolSkipEliminatedTeams And lblWinStatus(lstCurrentTeam.SelectedIndex).Visible And lblWinStatus(lstCurrentTeam.SelectedIndex).Text = "Out"

            HighlightCurrentPlayer(PlayerRow, True)

            frmDartBoard.ClearDartBoard()

            If UndoHistoryCount = MaxUndoHistoryCount Then
                HistoryIndexOfMostRecentTurn = UndoHistoryCount
            End If

            ' Update real-time statistics
            UpdateRealTimeStats()

            lblCurrentHole.Text = CStr(intCurrentHole(lstCurrentTeam.SelectedIndex))

        Catch ex As Exception
            HandleException("AdvanceToNextTeam", ex)
        End Try

    End Sub

    Private Sub AddScore(ByVal ScoreAmt As Short, ByVal ScoreBoxIndex As Short, ByVal ScoringTeamIndex As Short)
        Dim x As Short

        Try

            If glbBoolCutThroatCricket Then
                If glbCutThroatMode = 0 Then
                    ' Other teams receive points; low score wins
                    For x = 0 To MaxTeamIndexInGame
                        If Not IsClosed(x, ScoreBoxIndex) Then
                            UpdateTeamScore(x, GetTeamScore(x) + ScoreAmt)
                        End If
                    Next x
                Else
                    ' Current team receives points; high score wins
                    UpdateTeamScore(ScoringTeamIndex, GetTeamScore(ScoringTeamIndex) + ScoreAmt)
                End If
            End If

        Catch ex As Exception
            HandleException("AddScore", ex)
        End Try


    End Sub

    Private Sub ChangePicAndTag(ByVal BoxIndex As Short, ByVal increment As Short)
        Dim CurrentVal As Short

        Try
            CurrentVal = GetScoreBoxHitCount(BoxIndex)
            CurrentVal += increment

            If CurrentVal >= 0 Then
                pctScoreBox(BoxIndex).Tag = CurrentVal.ToString
            End If

            ' Update and position HitCount box
            txtHitCount.Text = pctScoreBox(BoxIndex).Tag
            txtHitCount.Top = pctScoreBox(BoxIndex).Top
            txtHitCount.Left = pctScoreBox(BoxIndex).Left - pctScoreBox(BoxIndex).Width
            txtHitCount.Visible = True

            If CurrentVal >= spScorePictureConstants.spZero And CurrentVal <= spScorePictureConstants.spThree Then
                SetPicture(pctScoreBox(BoxIndex), CShort(CurrentVal))
            End If

            If CurrentVal = spScorePictureConstants.spThree Then
                ' Player just closed the number; play a sound
                PlayWaveFileForPlayer("DartClose", False, True)
            End If

            mLastClickTime = System.DateTime.Now

        Catch ex As Exception
            HandleException("ChangePicAndTag", ex)
        End Try

    End Sub

    Public Function CheckForGameOver(ByVal SuppressNotify As Boolean) As Boolean
        Dim I, y, x, z, intScoreBoxHitCount As Short
        Dim intLowestScore As Short
        Dim boolPlayingGolf As Boolean
        Dim boolBestScore, boolGameIsOver As Boolean
        Dim boolAlreadyKnowGameIsOver As Boolean

        Try

            ' If lblWinStatus(0) is visible and does not contain the word Out, then
            '   it either contains the word Lose or Win
            ' In this case, the game _must_ be over
            If lblWinStatus(0).Visible = True And lblWinStatus(0).Text <> "Out" Then
                boolAlreadyKnowGameIsOver = True
            End If

            ' Check for Game Over
            ' if a team is all closed _and_ has lower score than others, then game over
            ' If playing 301 I don't check for game over until past the first "If boolGameIsOver Then" statement
            For x = 0 To MaxTeamIndexInGame
                boolGameIsOver = True ' Assume game over (set false later if not)
                boolPlayingGolf = False
                Select Case mGameType
                    Case modDarts.gtGameTypeConstants.gtCricket
                        For y = 0 To BoxesPerCol - 1
                            If Not IsClosed(x, y) Then
                                ' Not all boxes are closed, game not over yet
                                boolGameIsOver = False
                                Exit For
                            End If
                        Next y
                    Case modDarts.gtGameTypeConstants.gtGolf
                        ' Game is over if all teams are done with hole 18 (and on hole 19)
                        If intCurrentHole(MaxTeamIndexInGame) <= 18 Then
                            boolGameIsOver = False
                        End If
                        boolPlayingGolf = True
                    Case Else ' Includes 301
                        boolGameIsOver = True
                End Select

                If boolGameIsOver Then
                    ' Assume best score (set false later if not)
                    boolBestScore = True
                    Select Case mGameType
                        Case modDarts.gtGameTypeConstants.gtCricket
                            ' Playing Cricket
                            For z = 0 To MaxTeamIndexInGame
                                If z <> x AndAlso glbCutThroatMode = 0 AndAlso GetTeamScore(z) < GetTeamScore(x) OrElse _
                                  z <> x AndAlso glbCutThroatMode = 1 AndAlso GetTeamScore(z) > GetTeamScore(x) Then
                                    boolBestScore = False
                                    Exit For
                                End If
                            Next z
                            boolGameIsOver = boolBestScore

                        Case modDarts.gtGameTypeConstants.gtGolf
                            ' Teams(s) with lowest score have won
                            intLowestScore = GetTeamScore(x)
                            For z = 0 To MaxTeamIndexInGame
                                If z <> x Then
                                    If GetTeamScore(z) < intLowestScore Then
                                        intLowestScore = GetTeamScore(z)
                                    End If
                                End If
                            Next z
                            boolGameIsOver = True

                        Case Else ' Includes 301
                            ' If Score is not zero, then you haven't won
                            If GetTeamScore(x) <> 0 Then
                                boolGameIsOver = False
                            Else
                                boolGameIsOver = True
                            End If
                    End Select

                    If boolGameIsOver Then
                        ' Game over
                        lblStatus.Text = "Game Over."
                        For z = 0 To MaxTeamIndexInGame
                            If (boolPlayingGolf AndAlso GetTeamScore(z) = intLowestScore) OrElse _
                               (Not boolPlayingGolf AndAlso z = x) Then
                                lblWinStatus(z).Text = "Win"
                                lblWinStatus(z).Font = UpdateFontBold(lblWinStatus(z).Font, True)
                            Else
                                lblWinStatus(z).Text = "Lose"
                                lblWinStatus(z).Font = UpdateFontBold(lblWinStatus(z).Font, False)
                            End If
                        Next z

                        ' Update real-time statistics
                        UpdateRealTimeStats()

                        If Not SuppressNotify And Not boolAlreadyKnowGameIsOver Then
                            ' Only write the Stats file when user is first notified of game over
                            ' If user hits undo, then wins again, file WILL be written to again
                            ' However, if user clicks chart more after game is won, file will NOT be written
                            WriteStatsFile(mGameType, MaxTeamIndexInGame, mStartTime, UndoHistory, UndoHistoryCount)
                        End If

                        For z = 0 To MaxTeamIndexInGame
                            lblWinStatus(z).Visible = True
                        Next z

                        mPauseDelay = LONG_TIME_DELAY

                        Exit For
                    Else
                        If mGameType = modDarts.gtGameTypeConstants.gtCricket Then
                            ' Find teams with scores higher/lower than this team and mark as Out of Play
                            For z = 0 To MaxTeamIndexInGame
                                If (glbCutThroatMode = 0 AndAlso GetTeamScore(z) > GetTeamScore(x)) OrElse _
                                   (glbCutThroatMode = 1 AndAlso GetTeamScore(z) < GetTeamScore(x)) Then
                                    lblWinStatus(z).Text = "Out"
                                    lblWinStatus(z).Font = UpdateFontBold(lblWinStatus(z).Font, True)
                                    lblWinStatus(z).Visible = True
                                    ' Dim this team's boxes
                                    For I = z * BoxesPerCol To (z + 1) * BoxesPerCol - 1

                                        intScoreBoxHitCount = GetScoreBoxHitCount(I)
                                        If intScoreBoxHitCount >= spScorePictureConstants.spZero And intScoreBoxHitCount <= spScorePictureConstants.spThree Then
                                            SetPicture(pctScoreBox(I), intScoreBoxHitCount + SCOREBOX_DIM_ADDON)
                                        End If

                                    Next I
                                End If
                            Next z

                        End If
                    End If
                End If
            Next x

        Catch ex As Exception
            HandleException("CheckForGameOver", ex)
        End Try


        Return boolGameIsOver

    End Function

    Private Sub ClearAllBoxes()
        Dim x As Short

        Try

            For x = 0 To MaxBoxIndex
                SetPicture(pctScoreBox(x), spScorePictureConstants.spZero)
                pctScoreBox(x).Tag = spScorePictureConstants.spZero.ToString().Trim
            Next x

        Catch ex As Exception
            HandleException("ClearAllBoxes", ex)
        End Try

    End Sub

    Private Sub DisableOrEnableRow(ByVal ScoreIndex As Short, ByVal Disable As Boolean)
        ' If disable = true then Disable if all closed
        ' if disable = false then Enable if not all closed

        Dim intScoreBoxHitCount As Short

        Try

            Dim x As Short
            Dim RowClosed As Boolean

            ' Check row for all closed
            RowClosed = True
            For x = 0 To MaxTeamIndexInGame
                If Not IsClosed(x, ScoreIndex) Then
                    RowClosed = False
                    Exit For
                End If
            Next x

            If Disable And RowClosed Then
                ' Disable these boxes
                x = BaseIndexValue(ScoreIndex, BoxesPerCol)
                Do While x <= MaxBoxIndexInGame
                    SetPicture(pctScoreBox(x), spScorePictureConstants.spClosed)

                    pctScoreBox(x).Enabled = False
                    x = x + BoxesPerCol
                Loop
            ElseIf Not Disable Then
                ' Enable these boxes and make sure Correct Picture is Showing
                x = BaseIndexValue(ScoreIndex, BoxesPerCol)
                Do While x <= MaxBoxIndexInGame
                    intScoreBoxHitCount = GetScoreBoxHitCount(x)

                    If intScoreBoxHitCount >= 3 Then
                        SetPicture(pctScoreBox(x), spScorePictureConstants.spThree)
                    End If
                    pctScoreBox(x).Enabled = True
                    x += BoxesPerCol
                Loop
            End If

        Catch ex As Exception
            HandleException("DisableOrEnableRow", ex)
        End Try

    End Sub

    Private Sub EnableColumn(ByVal intThisTeamIndex As Short)
        Dim intThisBoxIndex As Short
        Dim eScorePictureIndex As spScorePictureConstants
        Dim intScoreBoxHitCount As Short

        For intThisBoxIndex = intThisTeamIndex * 7 To intThisTeamIndex * 7 + 6

            intScoreBoxHitCount = GetScoreBoxHitCount(intThisBoxIndex)

            If intScoreBoxHitCount <= 3 Then
                eScorePictureIndex = intScoreBoxHitCount
            Else
                eScorePictureIndex = spScorePictureConstants.spThree
            End If

            SetPicture(pctScoreBox(intThisBoxIndex), eScorePictureIndex)

        Next intThisBoxIndex

    End Sub

    Public Sub CompleteGolfTurn()
        Dim intCurrentTeamIndex As Short

        intCurrentTeamIndex = lstCurrentTeam.SelectedIndex

        UpdateTeamScore(intCurrentTeamIndex, GetTeamScore(intCurrentTeamIndex) + intMostRecentGolfScore)
        intCurrentHole(intCurrentTeamIndex) += 1

        ' Check for game over - necessary to save stats
        CheckForGameOver(False)
    End Sub

    Public Sub FillPlayerBoxes()

        Dim x, y As Short
        Dim SavePlayer As String

        Try
            For x = 0 To MAX_TEAM_INDEX * 2 + 1
                With cboPlayerList(x)

                    ' Save current player
                    SavePlayer = CStr(.SelectedItem)
                    If String.IsNullOrEmpty(SavePlayer) Then SavePlayer = String.Empty

                    .Items.Clear()

                    For y = 0 To glbPlayerCount
                        If String.IsNullOrEmpty(glbPlayers(y)) Then
                            If y = 0 Then
                                .Items.Add(String.Empty)
                            End If
                        Else
                            .Items.Add(glbPlayers(y))
                        End If
                    Next y

                    ' Search list for current player and select
                    For y = 0 To .Items.Count - 1
                        If CStr(.Items(y)) = SavePlayer Then
                            .SelectedIndex = y
                            Exit For
                        End If
                    Next y

                    If y = .Items.Count Then .SelectedIndex = 0
                End With
            Next x

        Catch ex As Exception
            HandleException("FillPlayerBoxes", ex)
        End Try

    End Sub

    Public Function GameInProgress() As Boolean
        ' Returns true if game in progress, and false otherwise

        If UndoHistoryCount > 0 Then
            GameInProgress = True
        Else
            GameInProgress = False
        End If
    End Function

    Private Function GetBoxIndex(ByVal intDartValue As Short, ByVal intTeamIndex As Short) As Short

        If intDartValue <= 20 And intDartValue >= 15 Then
            Return 20 - intDartValue + 7 * intTeamIndex
        ElseIf intDartValue = 25 Then
            Return 6 + 7 * intTeamIndex
        Else
            Return -1
        End If

    End Function

    Protected Function GetScoreBoxHitCount(ByVal intScoreBoxIndex As Short) As Short

        Dim intScoreBoxHitCount As Short

        If Short.TryParse(pctScoreBox(intScoreBoxIndex).Tag, intScoreBoxHitCount) Then
            Return intScoreBoxHitCount
        Else
            Return 0
        End If

    End Function

    Public Function GetGameType() As modDarts.gtGameTypeConstants
        Return mGameType
    End Function

    Protected Function GetTeamScore(ByVal intTeamIndex As Integer) As Short
        Return CShort(lblScore(intTeamIndex).Text)
    End Function

    Private Sub HideGameForms(ByVal blnCallFormCloseMethod As Boolean)

        frmDartBoard.Hide()
        HideRealTimeStatistics()

        If blnCallFormCloseMethod Then
            Me.Close()
        End If

        Me.Hide()
    End Sub

    Public Sub HideRealTimeStatistics()
        frmRealtimeStatistics.Hide()
    End Sub

    Public Sub HighlightCurrentPlayer(ByVal PlayerRow As Short, Optional ByVal boolPlayWaveFile As Boolean = False)
        Dim intPlayerListIndex, intPlayerListWorkingIndex As Short

        Try
            ' First color all of the players white
            For intPlayerListIndex = 0 To MAX_TEAM_INDEX
                Me.cboPlayerList(intPlayerListIndex * 2).BackColor = System.Drawing.Color.White
                Me.cboPlayerList(intPlayerListIndex * 2 + 1).BackColor = System.Drawing.Color.White
            Next intPlayerListIndex

            ' Determine the index to highlight
            If Me.lstCurrentTeam.SelectedIndex >= 0 Then
                If PlayerRow = 1 AndAlso Me.cboPlayerList(Me.lstCurrentTeam.SelectedIndex * 2 + 1).SelectedIndex <> 0 Then
                    intPlayerListWorkingIndex = Me.lstCurrentTeam.SelectedIndex * 2 + 1
                Else
                    intPlayerListWorkingIndex = Me.lstCurrentTeam.SelectedIndex * 2
                End If
            End If

            ' Highlight the player
            With Me.cboPlayerList(intPlayerListWorkingIndex)
                .BackColor = System.Drawing.Color.Yellow

                Dim strPlayerName As String
                strPlayerName = CStr(.SelectedItem)

                frmDartBoard.lblCurrentPlayer.Text = strPlayerName

                If glbBoolPlayWaveFileForPlayer And boolPlayWaveFile Then
                    PlayWaveFileForPlayer(strPlayerName, True, False)
                End If
            End With

        Catch ex As Exception
            HandleException("HighlightCurrentPlayer", ex)
        End Try

    End Sub


    Private Function IsClosed(ByVal TeamIndex As Short, ByVal ScoreBoxIndex As Short) As Boolean
        Dim CheckIndex As Short
        Dim intScoreBoxHitCount As Short

        Try
            CheckIndex = BaseIndexValue(ScoreBoxIndex, BoxesPerCol) + BoxesPerCol * TeamIndex

            intScoreBoxHitCount = GetScoreBoxHitCount(CheckIndex)
            If intScoreBoxHitCount >= 3 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            HandleException("IsClosed", ex)
        End Try

    End Function

    Public Function LastThreeDartsTotal() As Integer
        ' Returns the total score of the last three darts thrown
        '  Checks to make sure all thrown by same player
        ' If not, only returns total for the same player
        ' Uses UndoHistory() to do this

        Dim lngIndex, lngTotalScore As Integer
        Dim strPlayerName As String

        Try
            lngTotalScore = 0
            If UndoHistoryCount >= 1 Then
                strPlayerName = UndoHistory(UndoHistoryCount).PlayerName
                For lngIndex = UndoHistoryCount To UndoHistoryCount - 2 Step -1
                    If lngIndex < 0 Then Exit For
                    If UndoHistory(lngIndex).PlayerName = strPlayerName Then
                        lngTotalScore = lngTotalScore + UndoHistory(lngIndex).DartValue * UndoHistory(lngIndex).Multiplier
                    End If
                Next lngIndex
            End If

        Catch ex As Exception
            HandleException("LastThreeDartsTotal", ex)
        End Try

        Return lngTotalScore

    End Function

    Private Sub LoadScoreBoxes(ByVal MaxBoxIndex As Short, ByVal MaxBoxNameIndex As Short)
        Dim x As Short

        Try

            For x = 1 To MaxBoxIndex
                pctScoreBox.Load(x)
            Next x

            For x = 1 To MaxBoxNameIndex * 2 + 1
                lblBoxName.Load(x)
            Next x

        Catch ex As Exception
            HandleException("LoadScoreBoxes", ex)
        End Try

    End Sub

    Private Sub LoadScoreLabels()
        Dim x As Short

        Try

            For x = 1 To MAX_TEAM_INDEX
                lblWinStatus.Load(x)
                lblScore.Load(x)
                lblAltScore.Load(x)
            Next x

        Catch ex As Exception
            HandleException("LoadScoreLabels", ex)
        End Try

    End Sub

    Private Sub LoadTeamControls()
        Dim x As Short

        Try

            For x = 1 To MAX_TEAM_INDEX
                lblTeamName.Load(x)
                cboPlayerList.Load(x * 2)
                cboPlayerList.Load(x * 2 + 1)
            Next x

        Catch ex As Exception
            HandleException("LoadTeamControls", ex)
        End Try


    End Sub

    Private Sub PositionTeamControls(ByVal MaxTeamIndexInGame As Short, ByVal blnPlayingCricket As Boolean)
        Dim intPosTop, x, intPosLeft As Short
        Dim intTopRowFinalIndex As Short

        Try

            Select Case MaxTeamIndexInGame
                Case 2 To 3
                    intTopRowFinalIndex = 1
                Case Else
                    ' Includes 0, 1, 4, 5
                    intTopRowFinalIndex = 2
            End Select

            If mScoreAreaSize = modDarts.sasScoreAreaSizeConstants.sasNormal Then
                lblTeamName(0).Top = 3
            Else
                lblTeamName(0).Top = 3
            End If

            cboPlayerList(0).Top = lblTeamName(0).Top + 20
            cboPlayerList(1).Top = cboPlayerList(0).Top + 23

            For x = 0 To MAX_TEAM_INDEX
                If x <= intTopRowFinalIndex Then
                    intPosTop = lblTeamName(0).Top
                    intPosLeft = lblTeamName(0).Left + x * DISTANCE_BETWEEN_COLUMNS
                Else
                    If blnPlayingCricket Then
                        If mScoreAreaSize = modDarts.sasScoreAreaSizeConstants.sasNormal Then
                            intPosTop = lblTeamName(0).Top + 360
                        Else
                            intPosTop = lblTeamName(0).Top + 267
                        End If
                    Else
                        intPosTop = lblTeamName(0).Top + 167
                    End If

                    If x - (intTopRowFinalIndex + 1) < lblTeamName.Count Then
                        intPosLeft = lblTeamName(x - (intTopRowFinalIndex + 1)).Left
                    Else
                        intPosLeft = lblTeamName(0).Left + x * DISTANCE_BETWEEN_COLUMNS
                    End If

                End If

                If x < lblTeamName.Count Then
                    lblTeamName(x).Top = intPosTop
                    lblTeamName(x).Left = intPosLeft
                    lblTeamName(x).Text = "Team " & x.ToString

                    If x <= MaxTeamIndexInGame Then
                        lblTeamName(x).Visible = True
                    Else
                        lblTeamName(x).Visible = False
                    End If
                End If
                
                If x * 2 < cboPlayerList.Count Then
                    cboPlayerList(x * 2).Top = lblTeamName(x).Top + 20
                    cboPlayerList(x * 2).Left = intPosLeft
                    cboPlayerList(x * 2).Visible = lblTeamName(x).Visible
                End If
              
                If x * 2 + 1 < cboPlayerList.Count Then
                    cboPlayerList(x * 2 + 1).Top = cboPlayerList(x * 2).Top + 23
                    cboPlayerList(x * 2 + 1).Left = intPosLeft
                    cboPlayerList(x * 2 + 1).Visible = lblTeamName(x).Visible
                End If
            Next x

        Catch ex As Exception
            HandleException("Cricket->PositionTeamControls", ex)
        End Try

    End Sub

    Private Sub PositionAllControls(Optional ByVal blnClearPictures As Boolean = True)
        Dim blnPlayingCricket As Boolean
        Dim lngHeightDiff As Integer

        If mGameType = modDarts.gtGameTypeConstants.gtCricket Then
            blnPlayingCricket = True
        Else
            blnPlayingCricket = False
        End If

        PositionTeamControls(MaxTeamIndexInGame, blnPlayingCricket)
        PositionScoreBoxes(MaxBoxIndex, BoxesPerCol, MaxTeamIndexInGame, blnPlayingCricket, blnClearPictures)
        PositionScoreLabels(MaxTeamIndexInGame, blnPlayingCricket)

        ' Position Current Hole labels
        lblCurrentHoleLabel.Top = lblBoxName(0).Top + 33

        lngHeightDiff = System.Math.Abs((lblCurrentHole.Height - lblCurrentHoleLabel.Height) / 2)

        If lblCurrentHole.Height <= lblCurrentHoleLabel.Height Then
            lblCurrentHole.Top = lblCurrentHoleLabel.Top + lngHeightDiff + 2
        Else
            lblCurrentHole.Top = lblCurrentHoleLabel.Top - lngHeightDiff + 2
        End If

        Me.Refresh()

    End Sub

    Private Sub PositionScoreBoxes(ByVal MaxBoxIndex As Short, ByVal BoxesPerCol As Short, ByVal MaxTeamIndexInGame As Short, ByVal blnPlayingCricket As Boolean, Optional ByVal blnClearPictures As Boolean = True)
        Dim intPosTop, x, intPosLeft As Short
        Dim intDistanceBetweenScoreBoxes As Short
        Dim intLabelOffset As Short

        Dim intTargetArrayIndex As Short

        Try

            If mScoreAreaSize = modDarts.sasScoreAreaSizeConstants.sasNormal Then
                intDistanceBetweenScoreBoxes = 33
                intLabelOffset = 8
            Else
                intDistanceBetweenScoreBoxes = 25
                intLabelOffset = 4
            End If

            For x = 0 To MaxBoxIndex
                If x < pctScoreBox.Count Then
                    If Not blnPlayingCricket Then
                        pctScoreBox(x).Visible = False
                    Else
                        If Math.Floor(x / 7) <= MaxTeamIndexInGame Then
                            pctScoreBox(x).Visible = True
                        Else
                            pctScoreBox(x).Visible = False
                        End If

                        If x Mod 7 = 0 Then
                            ' First box in column, position based on Team Player Names position
                            intPosTop = cboPlayerList(Math.Floor(x / 7) * 2 + 1).Top + intDistanceBetweenScoreBoxes
                            If mScoreAreaSize = modDarts.sasScoreAreaSizeConstants.sasNormal Then
                                intPosTop += 200
                            End If

                            intTargetArrayIndex = Math.Floor(x / 7) * 2
                            If intTargetArrayIndex >= cboPlayerList.Count Then
                                intTargetArrayIndex = 0
                            End If

                            With cboPlayerList(intTargetArrayIndex)
                                intPosLeft = .Left + .Width / 2 - pctScoreBox(x).Width / 2
                            End With
                        Else
                            ' Remaining boxes in column, position based on first box in column
                            intTargetArrayIndex = Math.Floor(x / 7) * 7
                            If intTargetArrayIndex >= pctScoreBox.Count Then
                                intTargetArrayIndex = 0
                            End If

                            intPosTop = pctScoreBox(intTargetArrayIndex).Top + intDistanceBetweenScoreBoxes * BaseIndexValue(x, BoxesPerCol)
                            intPosLeft = pctScoreBox(intTargetArrayIndex).Left
                        End If

                        pctScoreBox(x).Left = intPosLeft
                        pctScoreBox(x).Top = intPosTop
                        pctScoreBox(x).Width = pctScoreBox(0).Width
                        pctScoreBox(x).Height = pctScoreBox(0).Height
                        If blnClearPictures Then pctScoreBox(x).Image = pctScoreBox(0).Image

                    End If
                End If
            Next x

            If blnPlayingCricket Then
                For x = 0 To 6
                    If x < lblBoxName.Count Then
                        lblBoxName(x).Left = pctScoreBox(x).Left - lblBoxName(0).Width + 2
                        lblBoxName(x).Top = pctScoreBox(x).Top + intLabelOffset
                        lblBoxName(x).Width = lblBoxName(0).Width
                        lblBoxName(x).Height = lblBoxName(0).Height
                        lblBoxName(x).Text = (20 - x).ToString()

                        lblBoxName(x).Visible = True

                        If x = 6 Then
                            lblBoxName(x).Text = "Bull"
                            lblBoxName(x).Left = lblBoxName(x).Left - 12
                            lblBoxName(x).Width = lblBoxName(x).Width + intLabelOffset
                        End If
                    End If
                    
                Next x

                For x = 7 To 13
                    If x < lblBoxName.Count Then
                        If MaxTeamIndexInGame > 1 Then
                            lblBoxName(x).Left = lblBoxName(x - 7).Left
                            lblBoxName(x).Top = pctScoreBox((x - 7) + Math.Floor(MaxBoxIndex / 2) + 1).Top + intLabelOffset
                            lblBoxName(x).Width = lblBoxName(x - 7).Width
                            lblBoxName(x).Height = lblBoxName(x - 7).Height
                            lblBoxName(x).Text = lblBoxName(x - 7).Text
                            lblBoxName(x).Visible = True
                        Else
                            lblBoxName(x).Visible = False
                        End If
                    End If                  
                Next x
            Else
                For x = 0 To 12
                    If x < lblBoxName.Count Then
                        lblBoxName(x).Visible = False
                    End If
                Next x
            End If

        Catch ex As Exception
            HandleException("PositionScoreBoxes", ex)
        End Try

    End Sub

    Private Sub PositionScoreLabels(ByVal MaxTeamIndexInGame As Short, ByVal blnPlayingCricket As Boolean)
        Dim x, intFirstBoxIndex As Short
        Dim intLabelTopOffset As Short

        Try

            If mScoreAreaSize = modDarts.sasScoreAreaSizeConstants.sasNormal Then
                intLabelTopOffset = 3
            Else
                intLabelTopOffset = 1
            End If

            For x = 0 To MAX_TEAM_INDEX

                intFirstBoxIndex = x * 7

                If x < lblWinStatus.Count Then

                    With cboPlayerList(x * 2 + 1)
                        lblWinStatus(x).Top = .Top + .Height + intLabelTopOffset
                        If mScoreAreaSize = modDarts.sasScoreAreaSizeConstants.sasNormal Or Not blnPlayingCricket Then
                            lblWinStatus(x).Left = .Left + .Width / 2 - lblWinStatus(x).Width / 2
                        Else
                            lblWinStatus(x).Left = pctScoreBox(intFirstBoxIndex).Left + pctScoreBox(intFirstBoxIndex).Width + 2
                        End If

                    End With
                    lblWinStatus(x).Text = "Win"
                    lblWinStatus(x).Visible = False
                End If

                If x < lblScore.Count Then
                    If blnPlayingCricket Then
                        If intFirstBoxIndex + 6 < pctScoreBox.Count Then
                            With pctScoreBox(intFirstBoxIndex + 6)
                                lblScore(x).Top = .Top + .Height + intLabelTopOffset
                                lblScore(x).Left = .Left + .Width / 2 - lblScore(x).Width / 2
                            End With
                        End If

                    Else
                        If x < lblWinStatus.Count Then
                            With lblWinStatus(x)
                                lblScore(x).Top = .Top + .Height + intLabelTopOffset
                                lblScore(x).Left = .Left + .Width / 2 - lblScore(x).Width / 2
                            End With
                        End If
                    End If

                    If x <= MaxTeamIndexInGame Then
                        lblScore(x).Visible = True
                    Else
                        lblScore(x).Visible = False
                    End If

                    lblAltScore(x).Top = lblScore(x).Top
                    lblAltScore(x).Left = lblScore(x).Left
                    lblAltScore(x).Visible = mRelativeScoringEnabled
                    lblAltScore(x).BringToFront() ' Bring to front

                End If

            Next x

        Catch ex As Exception
            HandleException("PositionScoreLabels", ex)
        End Try

    End Sub

    ' Note: the intDistanceFromCenter variable is only used during the game of Golf
    Public Sub RecordHit(ByVal intDartValue As Short, ByVal intMultiplier As Short, ByVal intDistanceFromCenter As Short, Optional ByVal boolRedoHit As Boolean = False)
        Dim intCurrentTeamIndex, BoxIndex As Short
        Dim intMultiplierIndex As Short
        Dim boolValidMove, AlreadyClosed, boolDoubledInAlready As Boolean
        Dim intRollBackIndex, intRollBackCount As Short

        Try

            intCurrentTeamIndex = lstCurrentTeam.SelectedIndex

            If Not boolRedoHit Then
                ' Add to Undo History (if not re-doing)
                UndoHistoryCount = UndoHistoryCount + 1
                With UndoHistory(UndoHistoryCount)
                    If cboPlayerList(PlayerColumn * 2 + PlayerRow).SelectedIndex > 0 Then
                        .PlayerName = GetComboBoxItemText(cboPlayerList(PlayerColumn * 2 + PlayerRow))
                    Else
                        .PlayerName = GetComboBoxItemText(cboPlayerList(PlayerColumn * 2))
                    End If
                    .TeamIndex = intCurrentTeamIndex
                    .DartValue = intDartValue
                    .DistanceFromCenter = intDistanceFromCenter
                    .Multiplier = intMultiplier
                    .ValidHits = 0 ' Assume, for now, that dart doesn't count (i.e. is a miss)
                End With
                If MaxUndoHistoryCount < UndoHistoryCount Then MaxUndoHistoryCount = UndoHistoryCount
            End If

            ' Play sound if a bull
            If intDartValue = 25 Then
                If intMultiplier = 2 Then
                    PlayWaveFileForPlayer("DartDoubleBull", False, False)
                Else
                    PlayWaveFileForPlayer("DartBull", False, False)
                End If
            End If

            Select Case mGameType
                Case modDarts.gtGameTypeConstants.gt301
                    ' Playing 301
                    If intMultiplier > 0 Then
                        ' If Double In is required, see if player has doubled in yet

                        If CChkBox(chkDoubleIn) And Not boolDoubledIn(intCurrentTeamIndex) Then
                            ' Player has not doubled in yet
                            If intMultiplier = 2 Then
                                ' Yes, play is a double, count it
                                boolValidMove = True
                                boolDoubledInAlready = True
                                boolDoubledIn(intCurrentTeamIndex) = True
                            Else
                                ' Not a double, play does not count
                                boolValidMove = False
                                boolDoubledInAlready = False
                            End If
                        Else
                            boolDoubledInAlready = True
                            boolValidMove = True
                        End If
                        If boolValidMove Then
                            ' Determine if valid move.  If so, update score
                            boolValidMove = Subtract301Score(intDartValue, intMultiplier, intCurrentTeamIndex)
                        End If
                        If boolValidMove Then
                            If Not boolRedoHit Then
                                ' Increment .ValidHits in UndoHistory() (if not re-doing)
                                UndoHistory(UndoHistoryCount).ValidHits = UndoHistory(UndoHistoryCount).ValidHits + intMultiplier
                            End If

                            CheckForGameOver(False)
                        Else
                            If boolDoubledInAlready Then
                                ' Invalid move -- player forfeits entire turn
                                ' Must add back any score already subtracted for this turn and
                                '   change .ValidHits to 0 for those darts
                                intRollBackCount = frmDartBoard.DartThrowCount
                                For intRollBackIndex = 1 To intRollBackCount
                                    UndoThrow()
                                Next intRollBackIndex
                                frmDartBoard.SmartAdvanceToNextTeam()
                            End If
                        End If
                    End If
                Case modDarts.gtGameTypeConstants.gtGolf
                    ' Hit only counts if for the current "Hole"
                    ' Score -2 for the Triple ring
                    '       -1 for the Double ring
                    '        0 for the inner triangle (between Bull and Triple ring)
                    '        1 for the outer rectangle (between Triple ring and Double ring)
                    '        2 for anything else
                    intMostRecentGolfScore = ComputeGolfDartScore(intCurrentHole(intCurrentTeamIndex), intDartValue, intMultiplier, intDistanceFromCenter)

                Case Else ' Cricket
                    ' Playing cricket
                    BoxIndex = GetBoxIndex(intDartValue, intCurrentTeamIndex)
                    For intMultiplierIndex = 1 To intMultiplier
                        If BoxIndex >= 0 Then
                            ' Only record hit if ScoreBox is enabled
                            If pctScoreBox(BoxIndex).Enabled = True Then
                                ' Update picture, count tag, and score
                                AlreadyClosed = IsClosed(intCurrentTeamIndex, BoxIndex)
                                ChangePicAndTag(BoxIndex, 1)
                                If AlreadyClosed Then
                                    ' Box already closed for this team; scoring on other teams
                                    ' Play sound
                                    PlayWaveFileForPlayer("DartPoints", False, True)
                                    AddScore(intDartValue, BoxIndex, intCurrentTeamIndex)
                                End If

                                If Not boolRedoHit Then
                                    ' Increment .ValidHits in UndoHistory() (if not re-doing)
                                    UndoHistory(UndoHistoryCount).ValidHits = UndoHistory(UndoHistoryCount).ValidHits + 1
                                End If

                                ' See if all teams have closed this number
                                DisableOrEnableRow(BoxIndex, True)

                                ' See if game is over
                                If CheckForGameOver(False) Then Exit For

                            End If
                        End If
                    Next intMultiplierIndex
            End Select

            ' Update TotalHits (if not re-doing)
            If Not boolRedoHit Then
                glbHitAndRotateStats.TotalHits = glbHitAndRotateStats.TotalHits + 1
                If glbHitAndRotateStats.TotalHits > MAX_TOTAL_HITS Then
                    glbHitAndRotateStats.TotalHits = 1
                End If
            End If
            mLastClickTeam = intCurrentTeamIndex

        Catch ex As Exception
            HandleException("RecordHit", ex)
        End Try

    End Sub

    Public Sub RedoThrow()
        ' Redo the last dart throw

        Try
            If mUndoRedoInProgress Then Exit Sub
            mUndoRedoInProgress = True

            If UndoHistoryCount < MaxUndoHistoryCount Then

                UndoHistoryCount = UndoHistoryCount + 1
                With UndoHistory(UndoHistoryCount)
                    ' Increment team list (if necessary)
                    If lstCurrentTeam.SelectedIndex <> .TeamIndex Then
                        ' If playing golf, need to use SmartAdvanceTeam
                        If Me.GetGameType() = modDarts.gtGameTypeConstants.gtGolf Then
                            frmDartBoard.SmartAdvanceToNextTeam()
                        Else
                            AdvanceToNextTeam(False)
                        End If
                    End If

                    RecordHit(.DartValue, .Multiplier, .DistanceFromCenter, True)

                    ' Put the dart dot back on the dart board (if one of the most recent darts)
                    If UndoHistoryCount > HistoryIndexOfMostRecentTurn Then
                        frmDartBoard.PlaceDart(.DartValue, .Multiplier)
                    End If
                End With

                lblStatus.Text = "Turn redone"
                mPauseDelay = SHORT_TIME_DELAY
            End If

        Catch ex As Exception
            HandleException("RedoThrow", ex)
        End Try

        mUndoRedoInProgress = False
    End Sub

    Private Sub ResizeFormToDefaults()

        Const WIDTH_BASE As Integer = 167       ' Pixels
        Const WIDTH_ADDER As Integer = 88       ' Pixels
        Const HEIGHT_BASE As Integer = 457      ' Pixels

        If mGameType = modDarts.gtGameTypeConstants.gt301 Or mGameType = modDarts.gtGameTypeConstants.gtGolf Then
            ' Playing 301
            If MaxTeamIndexInGame < 3 Then
                If MaxTeamIndexInGame <= 1 Then
                    Me.Width = WIDTH_BASE + WIDTH_ADDER * 2
                Else
                    Me.Width = WIDTH_BASE + WIDTH_ADDER * (MaxTeamIndexInGame + 1)
                End If
            Else
                Me.Width = WIDTH_BASE + WIDTH_ADDER * 3
            End If
            Me.Height = HEIGHT_BASE
        Else
            If mGameType <> modDarts.gtGameTypeConstants.gtCricket Then
                System.Windows.Forms.MessageBox.Show("mGameType has an unknown value in ResizeFormToDefaults: " & mGameType.ToString(), "Unexpected value", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            ' Playing Cricket
            Select Case MaxTeamIndexInGame
                Case 0 To 3 : Me.Width = WIDTH_BASE + WIDTH_ADDER * 2
                Case 4 To 5 : Me.Width = WIDTH_BASE + WIDTH_ADDER * 3
            End Select

            Select Case MaxTeamIndexInGame
                Case 0 To 1 : Me.Height = HEIGHT_BASE
                Case Else
                    If mScoreAreaSize = modDarts.sasScoreAreaSizeConstants.sasNormal Then
                        Me.Height = HEIGHT_BASE + 290
                    Else
                        Me.Height = HEIGHT_BASE + 130
                    End If
            End Select

        End If

    End Sub

    Public Sub SelectPreviousTeam()
        Try

            'If CheckForGameOver(True) Then Exit Sub

            If lstCurrentTeam.SelectedIndex > 0 Then
                lstCurrentTeam.SelectedIndex = lstCurrentTeam.SelectedIndex - 1
                PlayerColumn = PlayerColumn - 1
            Else
                lstCurrentTeam.SelectedIndex = MaxTeamIndexInGame
                PlayerColumn = MaxTeamIndexInGame
                If PlayerRow = 1 Then PlayerRow = 0 Else PlayerRow = 1
            End If

            HighlightCurrentPlayer(PlayerRow, True)

            frmDartBoard.ClearDartBoard()

            lblCurrentHole.Text = CStr(intCurrentHole(lstCurrentTeam.SelectedIndex))

        Catch ex As Exception
            HandleException("SelectPreviousTeam", ex)
        End Try
    End Sub

    Public Sub SetScoreAreaSize(ByVal eScoreAreaSize As modDarts.sasScoreAreaSizeConstants)
        Dim intIndex As Short
        Dim lngScoreBoxSize As Integer
        Dim CurrentVal As Short
        Dim intAddOn As Short

        mScoreAreaSize = eScoreAreaSize

        If mScoreAreaSize = modDarts.sasScoreAreaSizeConstants.sasNormal Then
            lngScoreBoxSize = SCOREBOX_SIZE_NORMAL
        Else
            lngScoreBoxSize = SCOREBOX_SIZE_SMALL
        End If

        For intIndex = 0 To MaxBoxIndex
            If intIndex < pctScoreBox.Count Then

                pctScoreBox(intIndex).Width = lngScoreBoxSize
                pctScoreBox(intIndex).Height = lngScoreBoxSize

                CurrentVal = GetScoreBoxHitCount(intIndex)

                '        If pctScoreBox(intIndex).Enabled Then
                '            intAddOn = 0
                '        Else
                '            intAddOn = SCOREBOX_DIM_ADDON
                '        End If

                If CurrentVal >= spScorePictureConstants.spThree Then
                    SetPicture(pctScoreBox(intIndex), spScorePictureConstants.spThree + intAddOn)
                ElseIf CurrentVal >= spScorePictureConstants.spZero And CurrentVal <= spScorePictureConstants.spTwo Then
                    SetPicture(pctScoreBox(intIndex), CurrentVal + intAddOn)
                End If

            End If

        Next intIndex

        PositionAllControls(False)

        ResizeFormToDefaults()

    End Sub

    Public Sub SetScoreFontSizes(Optional ByVal blnClearPictures As Boolean = False)
        Dim sngHeightScalar As Single
        Dim sngWidthScalar As Single

        Dim intBoxIndex As Short

        sngHeightScalar = 1.467    ' Pixels
        sngWidthScalar = 2.667     ' Pixels

        lblCurrentHole.Font = New System.Drawing.Font("Arial", glbScoreFontSize, System.Drawing.FontStyle.Regular)
        lblCurrentHole.Height = glbScoreFontSize * sngHeightScalar
        lblCurrentHole.Width = glbScoreFontSize * sngWidthScalar

        For intBoxIndex = 0 To lblScore.Count - 1
            lblScore(intBoxIndex).Font = lblCurrentHole.Font.Clone
            lblScore(intBoxIndex).Height = glbScoreFontSize * sngHeightScalar
            lblScore(intBoxIndex).Width = glbScoreFontSize * sngWidthScalar

            lblAltScore(intBoxIndex).Font = lblCurrentHole.Font.Clone
            lblAltScore(intBoxIndex).Height = glbScoreFontSize * sngHeightScalar
            lblAltScore(intBoxIndex).Width = glbScoreFontSize * sngWidthScalar
        Next intBoxIndex

        PositionAllControls(blnClearPictures)

    End Sub

    Private Sub SetPicture(ByRef pctThisPicture As System.Windows.Forms.PictureBox, ByVal ePictureToShow As spScorePictureConstants)
        If mScoreAreaSize = modDarts.sasScoreAreaSizeConstants.sasNormal Then
            pctThisPicture.Image = pctSource(ePictureToShow).Image
        Else
            pctThisPicture.Image = pctSourceSmall(ePictureToShow).Image
        End If
    End Sub

    Private Sub ShowHelp()
        Dim strMessage As String
        Dim strTitle As String

        Select Case mGameType
            Case modDarts.gtGameTypeConstants.gt301
                strMessage = "The object of 301 is to be the first player to reach exactly zero by subtracting each region's point value from the initial score of 301.  " & _
                             "Hitting in the small outer ring of a number counts as a 'double', and the small middle ring counts as a 'triple'.  " & _
                             "Further, the center bullseye counts as a 'double bull'.  " & _
                             "If the player goes below zero, then that player 'busts', and his score is set back to what it was prior to throwing the dart; further, his turn is forfeited.  " & _
                             "You can change the initial score to a value besides 301 if desired.  " & _
                             "A variation on 301 is to require Double In or Double Out.  " & _
                             "Double In means that the player must score a hit in the double ring before he can begin subtracting hits from his score.  " & _
                             "In Double Out, the player has to go out on a double.  " & _
                             "For example, if you have 10 points, you can close on a double 5."

                strTitle = "How to play 301"

            Case modDarts.gtGameTypeConstants.gtCricket
                strMessage = "The object of Cricket is to 'close' regions fifteen through twenty and the bullseye before your opponent(s).  " & _
                             "In order to close an area, you must hit it three times.  " & _
                             "Hitting in the small outer ring of a number counts as a 'double', and the small middle ring counts as a 'triple'.  " & _
                             "Further, the center bullseye counts as a 'double bull'.  " & _
                             "On the scoreboard, a single slash represents one hit, an X represents two, and a circled X indicates that the region has been closed.  " & _
                             "In Cutthroat Cricket, if you close a region before your opponent, any additional hits on that region will cause points to be scored on any opponents who have not closed that region.  " & _
                             "The game is over when a player/team closes the numbers 15 through 20, closes the bull, and has the same or fewer points as any other player/team."

                strTitle = "How to play Cricket"

            Case gtGameTypeConstants.gtGolf
                strMessage = "The object of Golf is to hit the corresponding region for the current hole.  " & _
                             "You start with hole 1, then, 2, etc.  You can throw one, two, or three darts on each hole, but only the last dart thrown counts.  " & _
                             "Hitting the triple ring gives you two under par (-2) for the current hole; " & _
                             "hitting the double ring gives you one under par (-1) for the current hole; " & _
                             "hitting the inner triangle (between the Bull and the Triple ring) is par for the hole (0); " & _
                             "hitting the outeger triangle (between the Triple ring and the Double ring) is one over par (+1); " & _
                             "any other location is two over par (+2). Your score at the end of the game is the sum of your score value for each hole (holes 1 through 18)."
                strTitle = "How to play Golf"
            Case Else
                strMessage = "Unknown game type; help not available."
                strTitle = "How to Play"

        End Select

        System.Windows.Forms.MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Public Sub ShowRealTimeStatistics()

        If mGameType <> modDarts.gtGameTypeConstants.gtGolf Then
            frmRealtimeStatistics.Show()

            With frmRealtimeStatistics
                .Top = Me.Top + 400
                If MaxTeamIndexInGame <= 1 Then
                    .Left = Me.Left + 187
                ElseIf MaxTeamIndexInGame <= 2 Then
                    .Left = Me.Left + 300
                ElseIf MaxTeamIndexInGame <= 4 Then
                    .Left = Me.Left + 347
                Else
                    .Left = Me.Left + 437
                End If

                .TopMost = True
            End With

        End If

    End Sub

    Public Sub StartNewGameWrapper(ByVal eGameType As modDarts.gtGameTypeConstants)
        Select Case eGameType
            Case modDarts.gtGameTypeConstants.gt301
                StartNewGame(True, modDarts.gtGameTypeConstants.gt301)
            Case modDarts.gtGameTypeConstants.gtGolf
                StartNewGame(True, modDarts.gtGameTypeConstants.gtGolf)
            Case Else
                StartNewGame(True, modDarts.gtGameTypeConstants.gtCricket)
        End Select
    End Sub

    Public Sub StartNewGame(ByVal boolNotifyGameInProgress As Boolean, ByVal eGameTypeNewGame As modDarts.gtGameTypeConstants)
        Dim x, y As Short
        Dim eResponse As System.Windows.Forms.DialogResult
        Dim boolValue As Boolean
        Dim boolPlayingGolf, blnPlayingCricket, boolPlaying301 As Boolean
        Dim boolSoundPlayed As Boolean
        Dim strMessage As String

        Dim blnSuccess As Boolean
        Dim intStartNumber301 As Short = 301

        Try

            If boolNotifyGameInProgress Then
                If GameInProgress() = True And CheckForGameOver(True) = False Then
                    strMessage = "Game in Progress, are you sure you want to end it and start a new one?"

                    eResponse = System.Windows.Forms.MessageBox.Show(strMessage, "Game in Progress", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

                    If eResponse <> Windows.Forms.DialogResult.Yes Then
                        Exit Sub
                    End If

                End If
            End If

            ' Determine game type
            Select Case eGameTypeNewGame
                Case modDarts.gtGameTypeConstants.gt301
                    blnSuccess = Short.TryParse(txtStartNumber.Text, intStartNumber301)

                    If Not blnSuccess Then
                        strMessage = "The start number box must contain a numeric value.  Changing to 301."
                        System.Windows.Forms.MessageBox.Show(strMessage, "Invalid Start Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                        intStartNumber301 = 301
                        txtStartNumber.Text = intStartNumber301.ToString

                    ElseIf intStartNumber301 < 2 Or intStartNumber301 >= 50000 Then
                        strMessage = "Invalid starting number; typical values are 101, 301, or 501.  Cannot start new game."
                        System.Windows.Forms.MessageBox.Show(strMessage, "Invalid Start Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub

                    End If
                    boolPlaying301 = True

                    glbDefault301StartScore = intStartNumber301

                Case modDarts.gtGameTypeConstants.gtGolf
                    boolPlayingGolf = True
                Case Else
                    ' Includes type gtCricket
                    blnPlayingCricket = True
            End Select

            mGameType = eGameTypeNewGame
            Me.Text = LookupGameStringByType(eGameTypeNewGame)

            ' Show/hide controls as needed based on game type
            txtStartNumber.Visible = boolPlaying301
            lblStartNumber.Visible = boolPlaying301
            chkDoubleOut.Visible = boolPlaying301
            chkDoubleIn.Visible = boolPlaying301
            cmdScoreMode.Visible = blnPlayingCricket

            ' Clear all boxes
            ClearAllBoxes()

            ' Clear Dart Board
            frmDartBoard.ClearDartBoard()

            ' Reset HistoryCount
            UndoHistoryCount = 0
            MaxUndoHistoryCount = 0
            HistoryIndexOfMostRecentTurn = 0
            mUndoRedoInProgress = False

            mStartTime = System.DateTime.Now
            mLastClickTime = System.DateTime.Now.AddSeconds(-CLICK_KEEP_TIME * 2)

            txtHitCount.Visible = False

            ' Set Max Team Index
            Dim strTeamCount As String
            strTeamCount = GetComboBoxItemText(cboNumberOfTeams)

            If strTeamCount.Length > 0 Then
                MaxTeamIndexInGame = CInt(strTeamCount) - 1
            Else
                MaxTeamIndexInGame = 1
            End If

            ' Set MaxBoxIndexInGame (used in cricket only)
            MaxBoxIndexInGame = (MaxTeamIndexInGame + 1) * BoxesPerCol - 1

            ' Re-initialize the boolDoubledIn array (used in 301 only)
            ReDim boolDoubledIn(MaxTeamIndexInGame)

            ' Re-initialize Golf data (used in Golf only)
            lblCurrentHole.Text = CStr(1)
            ReDim intCurrentHole(MAX_TEAM_INDEX)

            For x = 0 To MAX_TEAM_INDEX
                If x <= MaxTeamIndexInGame Then
                    boolValue = True
                Else
                    boolValue = False
                End If

                For y = x * 7 To (x + 1) * 7 - 1
                    If blnPlayingCricket Then
                        pctScoreBox(y).Enabled = boolValue
                        pctScoreBox(y).Visible = boolValue
                    Else
                        pctScoreBox(y).Visible = False
                    End If
                Next y

                lblTeamName(x).Visible = boolValue
                cboPlayerList(x * 2).Visible = boolValue
                cboPlayerList(x * 2 + 1).Visible = boolValue
                cboPlayerList(x * 2).BackColor = System.Drawing.Color.White
                cboPlayerList(x * 2 + 1).BackColor = System.Drawing.Color.White

                lblScore(x).Visible = boolValue
                If boolPlaying301 Then
                    ' Playing 301
                    UpdateTeamScore(x, intStartNumber301)
                Else
                    UpdateTeamScore(x, 0)
                End If
                lblAltScore(x).Visible = False
                lblWinStatus(x).Visible = False

                intCurrentHole(x) = 1
            Next x

            ' Initialize the team list
            lstCurrentTeam.Items.Clear()
            For x = 1 To MaxTeamIndexInGame + 1
                lstCurrentTeam.Items.Add(x.ToString)
            Next x
            lstCurrentTeam.SelectedIndex = 0

            ' Show/Hide and position objects depending on current game type
            PositionAllControls(True)

            ' Show/Hide Current Hole objects
            lblCurrentHoleLabel.Visible = boolPlayingGolf
            lblCurrentHole.Visible = boolPlayingGolf

            ' Automatically enable relative scoring if playing cricket
            ' Otherwise, disable for now
            If blnPlayingCricket Then
                ToggleRelativeScoring(False, True)
            Else
                ToggleRelativeScoring(False, False)
            End If

            ' Play the Start Game sound if mNewGameButtonClicked = True
            ' boolSoundPlayed will be True if the DartGameStart file is found and played
            If mNewGameButtonClicked Then
                boolSoundPlayed = PlayWaveFileForPlayer("DartGameStart", False, False)
            Else
                boolSoundPlayed = False
            End If

            ' Reset current player variables and highlight the first player
            ' If the DartGameStart file was not found, then play the .Wav file for the player
            PlayerRow = 0
            PlayerColumn = 0
            HighlightCurrentPlayer(PlayerRow, Not boolSoundPlayed)

            ' Resize form as needed
            ResizeFormToDefaults()

            ' Make sure dart board is shown
            'frmDartboard.Show

        Catch ex As Exception
            HandleException("StartNewGame", ex)
        End Try

    End Sub

    Private Function Subtract301Score(ByVal ScoreAmt As Short, ByVal intMultiplier As Short, ByVal intCurrentTeamIndex As Short) As Boolean
        Dim intNewScore As Short
        Dim boolValidNewScore As Boolean

        Try

            intNewScore = GetTeamScore(intCurrentTeamIndex) - ScoreAmt * intMultiplier

            If CChkBox(chkDoubleOut) Then
                ' Score cannot go below 2 and must hit a double to get to 0
                If intNewScore >= 2 Or (intNewScore = 0 And intMultiplier = 2) Then
                    boolValidNewScore = True
                Else
                    If intNewScore > 0 Then
                        lblStatus.Text = "Invalid hit:  Score cannot go below 2."
                    Else
                        lblStatus.Text = "Invalid hit:  Score cannot go below zero."
                    End If
                End If
            Else
                ' Score cannot go negative
                If intNewScore >= 0 Then
                    boolValidNewScore = True
                Else
                    lblStatus.Text = "Invalid hit:  Score cannot go below zero."
                End If
            End If

            If boolValidNewScore Then
                UpdateTeamScore(intCurrentTeamIndex, intNewScore)
                Return True
            Else
                mPauseDelay = SHORT_TIME_DELAY
                Return False
            End If

        Catch ex As Exception
            HandleException("Subtract301Score", ex)
        End Try

    End Function

    Private Sub ToggleRelativeScoring(Optional ByVal blnToggle As Boolean = True, Optional ByVal blnModeForceState As Boolean = False)
        ' If blnToggle is True, then simply toggles the mode
        ' Otherwise, forces mode based on blnModeForceState

        Dim x As Short

        Try

            ' Make sure Relative Mode label is positioned correctly
            lblScoreMode.Left = 16
            lblScoreMode.Top = 240

            If blnToggle Then
                mRelativeScoringEnabled = Not mRelativeScoringEnabled
            Else
                mRelativeScoringEnabled = blnModeForceState
            End If

            For x = 0 To MAX_TEAM_INDEX
                With lblAltScore(x)
                    If mRelativeScoringEnabled And x <= MaxTeamIndexInGame Then
                        .Visible = True
                    Else
                        .Visible = False
                    End If
                End With
            Next x
            lblScoreMode.Visible = lblAltScore(0).Visible

        Catch ex As Exception
            HandleException("ToggleRelativeScoring", ex)
        End Try

    End Sub

    Public Sub UndoThrow()
        ' Reversal of code in RecordHit(...)
        Dim intCurrentTeamIndex, BoxIndex As Short
        Dim intUndoIndex As Short
        Dim AlreadyClosed As Boolean
        Dim intThisTeamIndex As Short
        Dim intPopulateBoardIndex, intDartsToPopulate As Short
        Dim intThisRowIndex As Short

        Try
            If mUndoRedoInProgress Then Exit Sub
            mUndoRedoInProgress = True

            If UndoHistoryCount > 0 Then
                If frmDartBoard.DartThrowCount > 0 Then
                    With UndoHistory(UndoHistoryCount)
                        intCurrentTeamIndex = .TeamIndex

                        ' Only undo this dart the number of times given by .ValidHits
                        For intUndoIndex = 1 To .ValidHits
                            Select Case mGameType
                                Case modDarts.gtGameTypeConstants.gt301
                                    ' Playing 301
                                    ' Update score by "subtracting" the negative of the dart value, i.e. adding back the value
                                    Subtract301Score(-.DartValue, 1, intCurrentTeamIndex)
                                Case modDarts.gtGameTypeConstants.gtGolf
                                    ' Do nothing
                                Case Else
                                    ' Playing Cricket
                                    BoxIndex = GetBoxIndex(.DartValue, intCurrentTeamIndex)
                                    If BoxIndex >= 0 Then
                                        ' See if all teams have closed this number
                                        DisableOrEnableRow(BoxIndex, False)

                                        ' Update picture, count tag, and score
                                        ChangePicAndTag(BoxIndex, -1)
                                        AlreadyClosed = IsClosed(intCurrentTeamIndex, BoxIndex)
                                        If AlreadyClosed Then
                                            AddScore(-.DartValue, BoxIndex, intCurrentTeamIndex)
                                        End If
                                    End If
                            End Select
                        Next intUndoIndex
                    End With

                    ' Hide the Win/Lose/Out labels if not game Over
                    If Not CheckForGameOver(True) Then
                        For intThisTeamIndex = 0 To MaxTeamIndexInGame
                            lblWinStatus(intThisTeamIndex).Visible = False
                            ' Make sure correct pictures are showing
                            EnableColumn(intThisTeamIndex)
                        Next intThisTeamIndex

                        ' Now re-dim rows if necessary
                        For intThisRowIndex = 0 To 6
                            DisableOrEnableRow(intThisRowIndex, True)
                        Next intThisRowIndex
                    End If

                    ' Remove the most recent dart dot from the Dart Board (if present)
                    ' Note that this will set boolLastActionUndo = True
                    frmDartBoard.RemoveMostRecentThrow()

                    ' Decrement HistoryCount
                    UndoHistoryCount = UndoHistoryCount - 1

                    lblStatus.Text = "Turn undone"
                    mPauseDelay = SHORT_TIME_DELAY
                Else
                    ' Decrement team list if frmDartboard.DartThrowCount = 0
                    Do While UndoHistory(UndoHistoryCount).TeamIndex = lstCurrentTeam.SelectedIndex
                        ' Make sure the correct team is displayed in lstCurrentTeam.listindex
                        ' It would not be if the user pressed the Next Team or Previous Team buttons
                        '  on frmCricket (those buttons do not adjust the score automatically)
                        SelectPreviousTeam()
                    Loop

                    Do
                        SelectPreviousTeam()
                    Loop While lstCurrentTeam.SelectedIndex <> UndoHistory(UndoHistoryCount).TeamIndex

                    ' If playing golf, decrement current hole
                    If mGameType = modDarts.gtGameTypeConstants.gtGolf Then
                        intCurrentTeamIndex = lstCurrentTeam.SelectedIndex
                        intCurrentHole(intCurrentTeamIndex) = intCurrentHole(intCurrentTeamIndex) - 1
                        lblCurrentHole.Text = CStr(intCurrentHole(intCurrentTeamIndex))
                    End If

                    ' The cmdPreviousTeam button cleared the dart board and updated lstCurrentTeam.listIndex
                    ' Populate it with the previous three darts (assuming they exist and all were for the same player)
                    intDartsToPopulate = 0
                    For intPopulateBoardIndex = UndoHistoryCount To UndoHistoryCount - 2 Step -1
                        If intPopulateBoardIndex > 0 Then
                            If UndoHistory(intPopulateBoardIndex).TeamIndex = UndoHistory(UndoHistoryCount).TeamIndex Then
                                intDartsToPopulate = intDartsToPopulate + 1
                            Else
                                Exit For
                            End If
                        End If
                    Next intPopulateBoardIndex

                    If intDartsToPopulate > 0 Then
                        For intPopulateBoardIndex = UndoHistoryCount - intDartsToPopulate + 1 To UndoHistoryCount
                            With UndoHistory(intPopulateBoardIndex)
                                frmDartBoard.PlaceDart(.DartValue, .Multiplier)
                            End With
                        Next intPopulateBoardIndex

                        ' Note: SelectPreviousTeam(), used above, had the side effect of setting
                        '       boolLastActionUndo = False , so need to set it true again
                        frmDartBoard.SetLastActionUndo()
                    End If

                    ' Update HistoryIndexOfMostRecentTurn to the new value
                    HistoryIndexOfMostRecentTurn = UndoHistoryCount - intDartsToPopulate

                    ' For Golf, decrement score of most recent dart
                    If mGameType = modDarts.gtGameTypeConstants.gtGolf Then
                        With UndoHistory(UndoHistoryCount)
                            Dim intDartScore As Short
                            intDartScore = ComputeGolfDartScore(intCurrentHole(intCurrentTeamIndex), .DartValue, .Multiplier, .DistanceFromCenter)

                            UpdateTeamScore(intCurrentTeamIndex, GetTeamScore(intCurrentTeamIndex) - intDartScore)
                        End With
                    End If
                End If
            End If

        Catch ex As Exception
            HandleException("UndoThrow", ex)
        End Try

        mUndoRedoInProgress = False
    End Sub

    Private Sub UpdateRealTimeStats()
        Dim intIndex As Short
        Dim intPlayerIndex As Short

        Dim intMatchIndex As Short
        Dim intPlayerCount As Short

        Dim udtRealtimeStats() As udtRealTimeStatsType ' 0-based array; one player per row

        ' There are a maximum of MAX_TEAM_INDEX+1 teams, with a maximum of two players per team

        intPlayerCount = 0
        ReDim udtRealtimeStats((MAX_TEAM_INDEX + 1) * 2)

        For intIndex = 1 To UndoHistoryCount
            With UndoHistory(intIndex)

                ' Find .PlayerName in udtRealTimeStats
                intMatchIndex = -1
                For intPlayerIndex = 0 To intPlayerCount - 1
                    If udtRealtimeStats(intPlayerIndex).PlayerName = .PlayerName Then
                        intMatchIndex = intPlayerIndex
                        Exit For
                    End If
                Next intPlayerIndex

                If intMatchIndex = -1 Then
                    udtRealtimeStats(intPlayerCount).PlayerName = .PlayerName
                    intMatchIndex = intPlayerCount
                    intPlayerCount = intPlayerCount + 1
                End If

                udtRealtimeStats(intMatchIndex).ThrowCount = udtRealtimeStats(intMatchIndex).ThrowCount + 1
                udtRealtimeStats(intMatchIndex).ScoreTotal = udtRealtimeStats(intMatchIndex).ScoreTotal + .DartValue * .Multiplier
            End With
        Next intIndex

        frmRealtimeStatistics.UpdateRealtimeStats(udtRealtimeStats, intPlayerCount)

    End Sub

    Protected Sub UpdateTeamScore(ByVal intTeamIndex As Integer, ByVal strNewScore As String)
        UpdateTeamScore(intTeamIndex, CShort(strNewScore))
    End Sub

    Protected Sub UpdateTeamScore(ByVal intTeamIndex As Integer, ByVal intNewScore As Integer)
        Dim BestScoreVal As Short
        Dim ScoreCompare As Short
        Dim x As Integer

        lblScore(intTeamIndex).Text = intNewScore.ToString()

        BestScoreVal = intNewScore
        For x = 1 To MaxTeamIndexInGame
            ScoreCompare = GetTeamScore(x)
            If ScoreCompare < BestScoreVal Then
                BestScoreVal = ScoreCompare
            End If
        Next x

        For x = 0 To MaxTeamIndexInGame
            lblAltScore(x).Text = (GetTeamScore(x) - BestScoreVal).ToString
        Next x

    End Sub

    Public Sub WriteStatsFile(ByVal eSourceFormGameType As gtGameTypeConstants, ByVal MaxTeamIndexInGame As Short, _
                              ByVal StartTime As System.DateTime, ByRef UndoHistory() As usrUndoHistory, ByVal UndoHistoryCount As Short)

        Dim x As Short

        Dim PlayerStatsOut As frmPlayerStats.udtPlayerStatsType
        Dim TimeElapsedString As String
        Dim dtGameTime As System.DateTime
        Dim StatsFilePath, StatsExtendedFilePath As String

        Dim swOutFile As System.IO.StreamWriter

        dtGameTime = System.DateTime.Now

        TimeElapsedString = MinutesToTimeString(dtGameTime.Subtract(StartTime).TotalMinutes)

        Try
            ' Make sure all of the player boxes have names
            For x = 0 To MaxTeamIndexInGame

                PlayerStatsOut.PlayerName = GetComboBoxItemText(cboPlayerList(x * 2))
                PlayerStatsOut.PartnerName = GetComboBoxItemText(cboPlayerList(x * 2 + 1))

                If String.IsNullOrEmpty(PlayerStatsOut.PlayerName) And String.IsNullOrEmpty(PlayerStatsOut.PartnerName) Then
                    Dim strMessage As String
                    strMessage = "You have not entered player names for one or more teams.  Statistics will not be saved.  In order to make this game count, select player names for all teams, click the undo button, and click the redo button."
                    System.Windows.Forms.MessageBox.Show(strMessage, "Missing names", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                ElseIf String.IsNullOrEmpty(PlayerStatsOut.PlayerName) And String.IsNullOrEmpty(PlayerStatsOut.PartnerName) Then
                    ' Swap the second player with the first player so the first isn't blank
                    cboPlayerList(x * 2).SelectedIndex = cboPlayerList(x * 2 + 1).SelectedIndex
                    cboPlayerList(x * 2 + 1).SelectedIndex = 0
                End If
            Next x

            ' Record Simple Stats
            ' Append the current year and month to StatsFileNameBase
            ' This way, all stats for the current month will reside in the same file
            StatsFilePath = StatsFileNameBase & "_" & dtGameTime.ToString("yyyyMM") & ".ini"

            swOutFile = New System.IO.StreamWriter(New System.IO.FileStream(StatsFilePath, IO.FileMode.Append, IO.FileAccess.Write, IO.FileShare.Read))

            For x = 0 To MaxTeamIndexInGame

                PlayerStatsOut.GameDateTime = dtGameTime
                PlayerStatsOut.GameTimeElapsed = TimeElapsedString
                PlayerStatsOut.PlayerName = GetComboBoxItemText(cboPlayerList(x * 2))
                PlayerStatsOut.PartnerName = GetComboBoxItemText(cboPlayerList(x * 2 + 1))

                If eSourceFormGameType = gtGameTypeConstants.gt301 Then
                    If lblScore(x).Text = "0" Then PlayerStatsOut.GameWon = True Else PlayerStatsOut.GameWon = False
                Else
                    If lblWinStatus(x).Text = "Win" Then PlayerStatsOut.GameWon = True Else PlayerStatsOut.GameWon = False
                End If
                PlayerStatsOut.GameName = LookupGameStringByType(eSourceFormGameType)
                PlayerStatsOut.Points = lblScore(x).Text

                With PlayerStatsOut
                    ' =8/6/1999 2:44:16 PM ,10:23,
                    swOutFile.WriteLine("Stat=" & _
                                        .GameDateTime.ToString("M/d/yyyy h:mm:ss tt") & "," & _
                                        .GameTimeElapsed & "," & _
                                        .PlayerName & "," & _
                                        .PartnerName & "," & _
                                        .GameWon & "," & _
                                        .Points & "," & _
                                        .GameName)
                End With
            Next x

            swOutFile.Close()

            ' Record Extended Stats
            ' Append the current year and month to StatsExtendedFilenameBase
            ' This way, all stats for the current month will reside in the same file
            StatsExtendedFilePath = StatsExtendedFilenameBase & "_" & dtGameTime.ToString("yyyyMM") & ".ini"

            swOutFile = New System.IO.StreamWriter(New System.IO.FileStream(StatsExtendedFilePath, IO.FileMode.Append, IO.FileAccess.Write, IO.FileShare.Read))

            For x = 1 To UndoHistoryCount
                With UndoHistory(x)
                    swOutFile.WriteLine("ExtStat=" & _
                                        dtGameTime.ToString("M/d/yyyy h:mm:ss tt") & "," & _
                                        .TeamIndex + 1 & "," & _
                                        .PlayerName & "," & _
                                        .DartValue & "," & _
                                        .Multiplier & "," & _
                                        .ValidHits)
                End With
            Next x
            swOutFile.Close()

            PlayWaveFileForPlayer("DartGameOver", False, False)

            System.Windows.Forms.MessageBox.Show("Game over; statistics have been saved.", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show("Game over, but unable to save the stats: " & ex.Message, "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    'UPGRADE_WARNING: Event cboPlayerList.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub cboPlayerList_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboPlayerList.SelectedIndexChanged
        Dim intIndex As Short

        intIndex = cboPlayerList.GetIndex(eventSender)

        HighlightCurrentPlayer(PlayerRow)
        PlayWaveFileForPlayer(GetComboBoxItemText(cboPlayerList(intIndex)), False, False)
    End Sub

    Private Sub chkDoubleIn_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkDoubleIn.CheckStateChanged
        glbBoolRequireDoubleIn = CChkBox(chkDoubleIn)
    End Sub

    Private Sub chkDoubleOut_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkDoubleOut.CheckStateChanged
        glbBoolRequireDoubleOut = CChkBox(chkDoubleOut)
    End Sub

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        HideGameForms(True)
    End Sub

    Private Sub cmdHelp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdHelp.Click
        ShowHelp()
    End Sub

    Private Sub cmdNextTeam_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNextTeam.Click
        AdvanceToNextTeam(False)
    End Sub

    Private Sub cmdPreviousTeam_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPreviousTeam.Click
        SelectPreviousTeam()
    End Sub

    Private Sub cmdRedo_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRedo.Click
        RedoThrow()
    End Sub

    Private Sub cmdScoreMode_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdScoreMode.Click
        ToggleRelativeScoring(True)
    End Sub

    Private Sub cmdShowRealtimeStatistics_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdShowRealtimeStatistics.Click
        ShowRealTimeStatistics()
    End Sub

    Private Sub cmdStartNewGame_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdStartNewGame.Click
        ' Set mNewGameButtonClicked to True to assure that the DartGameStart sound is played
        mNewGameButtonClicked = True

        StartNewGameWrapper(mGameType)

        mNewGameButtonClicked = False
    End Sub

    Private Sub cmdShowDartBoard_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdShowDartBoard.Click
        frmDartBoard.Show()
    End Sub

    Private Sub cmdUndo_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUndo.Click
        UndoThrow()
    End Sub

    'UPGRADE_WARNING: Form event frmCricket.Activate has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
    Private Sub frmCricket_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated

        HighlightCurrentPlayer(PlayerRow)

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

    End Sub

    Private Sub frmCricket_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim x As Short

        Try
            ' Load Team Names and Player Lists
            LoadTeamControls()

            ' Load Score Boxes
            LoadScoreBoxes(MaxBoxIndex, 6)

            ' Load Win Labels, Score Labels, and Alt Score Labels
            LoadScoreLabels()

            ' Set the Default 301 Starting Score
            txtStartNumber.Text = glbDefault301StartScore

            ' Set Double In/Out values
            If glbBoolRequireDoubleIn Then
                chkDoubleIn.CheckState = System.Windows.Forms.CheckState.Checked
            Else
                chkDoubleIn.CheckState = System.Windows.Forms.CheckState.Unchecked
            End If

            If glbBoolRequireDoubleOut Then
                chkDoubleOut.CheckState = System.Windows.Forms.CheckState.Checked
            Else
                chkDoubleOut.CheckState = System.Windows.Forms.CheckState.Unchecked
            End If

            ' Initialize the boolDoubledIn array (used in 301)
            ReDim boolDoubledIn(MAX_TEAM_INDEX + 1)

            ' Fill Teams Box
            For x = 1 To MAX_TEAM_INDEX + 1
                cboNumberOfTeams.Items.Add(x.ToString)
            Next x
            cboNumberOfTeams.SelectedIndex = 1

            ' Position the forms
            Me.Left = 0
            Me.Top = 0

            FillPlayerBoxes()
            SetScoreFontSizes(True)

            SetScoreAreaSize(modDarts.glbScoreAreaSizeVal)

            frmDartBoard.Left = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - frmDartBoard.Width
            frmDartBoard.Top = 0

            ' Set up new game (will show/hide controls and position as needed)
            StartNewGameWrapper(mGameType)

            tmrTimer.Interval = 1000
            tmrTimer.Enabled = True


        Catch ex As Exception
            HandleException("frmCricket_Load", ex)
        End Try

    End Sub

    Private Sub frmCricket_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If eventArgs.CloseReason = CloseReason.UserClosing Then
            eventArgs.Cancel = True
            HideGameForms(False)
        End If

    End Sub


    Private Sub tmrTimer_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrTimer.Tick

        If mPauseDelay <= 0 Then
            lblStatus.Text = MinutesToTimeString(System.DateTime.Now.Subtract(mStartTime).TotalMinutes) & " elapsed."
        Else
            mPauseDelay -= 1
        End If

        If System.DateTime.Now.Subtract(mLastClickTime).TotalSeconds > CLICK_KEEP_TIME Then
            ' Reset mLastClickTeam and hide txtHitCount
            mLastClickTeam = -1
            txtHitCount.Visible = False
        End If

    End Sub

    Private Sub txtStartNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtStartNumber.KeyPress
        TextBoxKeyPressHandler(txtStartNumber, e, True, False)
    End Sub

End Class