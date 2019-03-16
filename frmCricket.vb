'Option Strict On
Option Explicit On

Imports System.IO 'Imports VB = Microsoft.VisualBasic

Friend Class frmCricket
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

#Region "Constants and Enums"
    Private Const MAX_UNDO_HISTORY As Short = 5000
    Private Const MAX_BOX_INDEX As Short = 41
    Private Const BOXES_PER_COL As Short = 7

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
    Private mUndoHistory(MAX_UNDO_HISTORY) As usrUndoHistory ' 1-based array
    Private boolDoubledIn() As Boolean
    Private intCurrentHole() As Short
    Private intMostRecentGolfScore As Short

    Private mUndoHistoryCount, mMaxUndoHistoryCount As Short
    Private HistoryIndexOfMostRecentTurn As Short

    Private mMaxTeamIndexInGame, mMaxBoxIndexInGame As Short
    Private mStartTime, mLastClickTime As DateTime
    Private mLastClickTeam As Short
    Private mPauseDelay As Integer
    Private mPlayerRow, mPlayerColumn As Short ' Both are 0-based

    ' The following variables are used to prevent the history buffer from getting scrambled
    Private mUndoRedoInProgress As Boolean
    Private mNewGameButtonClicked As Boolean

    Private mRelativeScoringEnabled As Boolean
    Private mScoreAreaSize As sasScoreAreaSizeConstants

    Private mGameType As gtGameTypeConstants = gtGameTypeConstants.gtCricket

#End Region

    Public Sub AdvanceToNextTeam(boolSkipEliminatedTeams As Boolean)

        Try

            Do
                If lstCurrentTeam.SelectedIndex < mMaxTeamIndexInGame Then
                    lstCurrentTeam.SelectedIndex = lstCurrentTeam.SelectedIndex + 1
                    mPlayerColumn += 1S
                Else
                    lstCurrentTeam.SelectedIndex = 0
                    mPlayerColumn = 0
                    If mPlayerRow = 1 Then mPlayerRow = 0 Else mPlayerRow = 1
                End If
            Loop While boolSkipEliminatedTeams AndAlso
                       lblWinStatus.Item(lstCurrentTeam.SelectedIndex).Visible AndAlso
                       lblWinStatus.Item(lstCurrentTeam.SelectedIndex).Text = "Out"

            HighlightCurrentPlayer(mPlayerRow, True)

            frmDartBoard.ClearDartBoard()

            If mUndoHistoryCount >= mMaxUndoHistoryCount Then
                HistoryIndexOfMostRecentTurn = mUndoHistoryCount
            End If

            ' Update real-time statistics
            UpdateRealTimeStats()

            lblCurrentHole.Text = CStr(intCurrentHole(lstCurrentTeam.SelectedIndex))

        Catch ex As Exception
            HandleException("AdvanceToNextTeam", ex)
        End Try

    End Sub

    Private Sub AddScore(ScoreAmt As Short, ScoreBoxIndex As Short, ScoringTeamIndex As Short)
        Dim x As Short

        Try

            If glbBoolCutThroatCricket Then
                If glbCutThroatMode = 0 Then
                    ' Other teams receive points; low score wins
                    For x = 0 To mMaxTeamIndexInGame
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

    Private Sub ChangePicAndTag(BoxIndex As Short, increment As Short)
        Dim CurrentVal As Short

        Try
            CurrentVal = GetScoreBoxHitCount(BoxIndex)
            CurrentVal += increment

            If CurrentVal >= 0 Then
                pctScoreBox.Item(BoxIndex).Tag = CurrentVal.ToString
            End If

            ' Update and position HitCount box
            txtHitCount.Text = CType(pctScoreBox.Item(BoxIndex).Tag, String)
            txtHitCount.Top = pctScoreBox.Item(BoxIndex).Top
            txtHitCount.Left = pctScoreBox.Item(BoxIndex).Left - pctScoreBox.Item(BoxIndex).Width
            txtHitCount.Visible = True

            If CurrentVal >= spScorePictureConstants.spZero And CurrentVal <= spScorePictureConstants.spThree Then
                SetPicture(pctScoreBox.Item(BoxIndex), CType(CurrentVal, spScorePictureConstants))
            End If

            If CurrentVal = spScorePictureConstants.spThree Then
                ' Player just closed the number; play a sound
                PlayWaveFileForPlayer("DartClose", False, True)
            End If

            mLastClickTime = DateTime.Now

        Catch ex As Exception
            HandleException("ChangePicAndTag", ex)
        End Try

    End Sub

    Public Function CheckForGameOver(SuppressNotify As Boolean) As Boolean
        Dim I, y, x, z, intScoreBoxHitCount As Short
        Dim intLowestScore As Short
        Dim boolPlayingGolf As Boolean
        Dim boolBestScore, boolGameIsOver As Boolean
        Dim boolAlreadyKnowGameIsOver As Boolean

        Try

            ' If lblWinStatus.Item(0) is visible and does not contain the word Out, then
            '   it either contains the word Lose or Win
            ' In this case, the game _must_ be over
            If lblWinStatus.Item(0).Visible = True And lblWinStatus.Item(0).Text <> "Out" Then
                boolAlreadyKnowGameIsOver = True
            End If

            ' Check for Game Over
            ' if a team is all closed _and_ has lower score than others, then game over
            ' If playing 301 I don't check for game over until past the first "If boolGameIsOver Then" statement
            For x = 0 To mMaxTeamIndexInGame
                boolGameIsOver = True ' Assume game over (set false later if not)
                boolPlayingGolf = False
                Select Case mGameType
                    Case gtGameTypeConstants.gtCricket
                        For y = 0 To BOXES_PER_COL - 1
                            If Not IsClosed(x, y) Then
                                ' Not all boxes are closed, game not over yet
                                boolGameIsOver = False
                                Exit For
                            End If
                        Next y
                    Case gtGameTypeConstants.gtGolf
                        ' Game is over if all teams are done with hole 18 (and on hole 19)
                        If intCurrentHole(mMaxTeamIndexInGame) <= 18 Then
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
                        Case gtGameTypeConstants.gtCricket
                            ' Playing Cricket
                            For z = 0 To mMaxTeamIndexInGame
                                If z <> x AndAlso glbCutThroatMode = 0 AndAlso GetTeamScore(z) < GetTeamScore(x) OrElse
                                  z <> x AndAlso glbCutThroatMode = 1 AndAlso GetTeamScore(z) > GetTeamScore(x) Then
                                    boolBestScore = False
                                    Exit For
                                End If
                            Next z
                            boolGameIsOver = boolBestScore

                        Case gtGameTypeConstants.gtGolf
                            ' Teams(s) with lowest score have won
                            intLowestScore = GetTeamScore(x)
                            For z = 0 To mMaxTeamIndexInGame
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
                        For z = 0 To mMaxTeamIndexInGame
                            If (boolPlayingGolf AndAlso GetTeamScore(z) = intLowestScore) OrElse
                               (Not boolPlayingGolf AndAlso z = x) Then
                                lblWinStatus.Item(z).Text = "Win"
                                lblWinStatus.Item(z).Font = UpdateFontBold(lblWinStatus.Item(z).Font, True)
                            Else
                                lblWinStatus.Item(z).Text = "Lose"
                                lblWinStatus.Item(z).Font = UpdateFontBold(lblWinStatus.Item(z).Font, False)
                            End If
                        Next z

                        ' Update real-time statistics
                        UpdateRealTimeStats()

                        If Not SuppressNotify And Not boolAlreadyKnowGameIsOver Then
                            ' Only write the Stats file when user is first notified of game over
                            ' If user hits undo, then wins again, file WILL be written to again
                            ' However, if user clicks chart more after game is won, file will NOT be written
                            WriteStatsFile(mGameType, mMaxTeamIndexInGame, mStartTime, mUndoHistory, mUndoHistoryCount)
                        End If

                        For z = 0 To mMaxTeamIndexInGame
                            lblWinStatus.Item(z).Visible = True
                        Next z

                        mPauseDelay = LONG_TIME_DELAY

                        Exit For
                    Else
                        If mGameType = gtGameTypeConstants.gtCricket Then
                            ' Find teams with scores higher/lower than this team and mark as Out of Play
                            For z = 0 To mMaxTeamIndexInGame
                                If (glbCutThroatMode = 0 AndAlso GetTeamScore(z) > GetTeamScore(x)) OrElse
                                   (glbCutThroatMode = 1 AndAlso GetTeamScore(z) < GetTeamScore(x)) Then
                                    lblWinStatus.Item(z).Text = "Out"
                                    lblWinStatus.Item(z).Font = UpdateFontBold(lblWinStatus.Item(z).Font, True)
                                    lblWinStatus.Item(z).Visible = True

                                    ' Create this team's boxes
                                    For I = z * BOXES_PER_COL To CShort((z + 1) * BOXES_PER_COL - 1)

                                        intScoreBoxHitCount = GetScoreBoxHitCount(I)
                                        If intScoreBoxHitCount >= spScorePictureConstants.spZero And intScoreBoxHitCount <= spScorePictureConstants.spThree Then
                                            SetPicture(pctScoreBox.Item(I), intScoreBoxHitCount + SCOREBOX_DIM_ADDON)
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

            For x = 0 To MAX_BOX_INDEX
                SetPicture(pctScoreBox.Item(x), spScorePictureConstants.spZero)
                pctScoreBox.Item(x).Tag = spScorePictureConstants.spZero.ToString().Trim
            Next x

        Catch ex As Exception
            HandleException("ClearAllBoxes", ex)
        End Try

    End Sub

    Private Sub DisableOrEnableRow(ScoreIndex As Short, Disable As Boolean)
        ' If disable = true then Disable if all closed
        ' if disable = false then Enable if not all closed

        Dim intScoreBoxHitCount As Short

        Try

            Dim x As Short
            Dim RowClosed As Boolean

            ' Check row for all closed
            RowClosed = True
            For x = 0 To mMaxTeamIndexInGame
                If Not IsClosed(x, ScoreIndex) Then
                    RowClosed = False
                    Exit For
                End If
            Next x

            If Disable And RowClosed Then
                ' Disable these boxes
                x = BaseIndexValue(ScoreIndex, BOXES_PER_COL)
                Do While x <= mMaxBoxIndexInGame
                    SetPicture(pctScoreBox.Item(x), spScorePictureConstants.spClosed)

                    pctScoreBox.Item(x).Enabled = False
                    x = x + BOXES_PER_COL
                Loop
            ElseIf Not Disable Then
                ' Enable these boxes and make sure Correct Picture is Showing
                x = BaseIndexValue(ScoreIndex, BOXES_PER_COL)
                Do While x <= mMaxBoxIndexInGame
                    intScoreBoxHitCount = GetScoreBoxHitCount(x)

                    If intScoreBoxHitCount >= 3 Then
                        SetPicture(pctScoreBox.Item(x), spScorePictureConstants.spThree)
                    End If
                    pctScoreBox.Item(x).Enabled = True
                    x += BOXES_PER_COL
                Loop
            End If

        Catch ex As Exception
            HandleException("DisableOrEnableRow", ex)
        End Try

    End Sub

    Private Sub EnableColumn(intThisTeamIndex As Short)
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

            SetPicture(pctScoreBox.Item(intThisBoxIndex), eScorePictureIndex)

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
                With cboPlayerList.Item(x)

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

        If mUndoHistoryCount > 0 Then
            GameInProgress = True
        Else
            GameInProgress = False
        End If
    End Function

    Private Function GetBoxIndex(intDartValue As Short, intTeamIndex As Short) As Short

        If intDartValue <= 20 And intDartValue >= 15 Then
            Return 20 - intDartValue + 7 * intTeamIndex
        ElseIf intDartValue = 25 Then
            Return 6 + 7 * intTeamIndex
        Else
            Return -1
        End If

    End Function

    Protected Function GetScoreBoxHitCount(intScoreBoxIndex As Short) As Short

        Dim intScoreBoxHitCount As Short

        If Short.TryParse(pctScoreBox.Item(intScoreBoxIndex).Tag, intScoreBoxHitCount) Then
            Return intScoreBoxHitCount
        Else
            Return 0
        End If

    End Function

    Public Function GetGameType() As gtGameTypeConstants
        Return mGameType
    End Function

    Protected Function GetTeamScore(intTeamIndex As Integer) As Short
        Return CShort(lblScore.Item(intTeamIndex).Text)
    End Function

    Private Sub HideGameForms(blnCallFormCloseMethod As Boolean)

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

    Public Sub HighlightCurrentPlayer(currentPlayerRow As Short, Optional ByVal boolPlayWaveFile As Boolean = False)
        Dim intPlayerListIndex, intPlayerListWorkingIndex As Short

        Try
            ' First color all of the players white
            For intPlayerListIndex = 0 To MAX_TEAM_INDEX
                Me.cboPlayerList.Item(intPlayerListIndex * 2).BackColor = Color.White
                Me.cboPlayerList.Item(intPlayerListIndex * 2 + 1).BackColor = Color.White
            Next intPlayerListIndex

            ' Determine the index to highlight
            If Me.lstCurrentTeam.SelectedIndex >= 0 Then
                If currentPlayerRow = 1 AndAlso Me.cboPlayerList.Item(Me.lstCurrentTeam.SelectedIndex * 2 + 1).SelectedIndex <> 0 Then
                    intPlayerListWorkingIndex = Me.lstCurrentTeam.SelectedIndex * 2 + 1
                Else
                    intPlayerListWorkingIndex = Me.lstCurrentTeam.SelectedIndex * 2
                End If
            End If

            ' Highlight the player
            With Me.cboPlayerList.Item(intPlayerListWorkingIndex)
                .BackColor = Color.Yellow

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


    Private Function IsClosed(TeamIndex As Short, ScoreBoxIndex As Short) As Boolean
        Dim CheckIndex As Short
        Dim intScoreBoxHitCount As Short

        Try
            CheckIndex = BaseIndexValue(ScoreBoxIndex, BOXES_PER_COL) + BOXES_PER_COL * TeamIndex

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
        ' Uses mUndoHistory() to do this

        Dim lngIndex, lngTotalScore As Integer
        Dim strPlayerName As String

        Try
            lngTotalScore = 0
            If mUndoHistoryCount >= 1 Then
                strPlayerName = mUndoHistory(mUndoHistoryCount).PlayerName
                For lngIndex = mUndoHistoryCount To mUndoHistoryCount - 2 Step -1
                    If lngIndex < 0 Then Exit For
                    If mUndoHistory(lngIndex).PlayerName = strPlayerName Then
                        lngTotalScore = lngTotalScore + mUndoHistory(lngIndex).DartValue * mUndoHistory(lngIndex).Multiplier
                    End If
                Next lngIndex
            End If

        Catch ex As Exception
            HandleException("LastThreeDartsTotal", ex)
        End Try

        Return lngTotalScore

    End Function

    Private Sub LoadScoreBoxes(MaxBoxIndex As Short, MaxBoxNameIndex As Short)
        Dim x As Short

        Try
            ' Note that the pctScoreBox and lblBoxName arrays start off already containing one item, at index 0

            For x = 1 To MaxBoxIndex
                pctScoreBox.AddNewPictureBox()
            Next x

            For x = 1 To MaxBoxNameIndex * 2 + 1
                lblBoxName.AddNewLabel()
            Next x

        Catch ex As Exception
            HandleException("LoadScoreBoxes", ex)
        End Try

    End Sub

    Private Sub LoadScoreLabels()
        Dim x As Short

        Try
            ' Note that these label array classes start off already containing one item, at index 0

            For x = 1 To MAX_TEAM_INDEX
                lblWinStatus.AddNewLabel()
                lblScore.AddNewLabel()
                lblAltScore.AddNewLabel()
            Next x

            For x = 0 To lblWinStatus.Count - 1
                lblWinStatus.Item(x).Text = "Win"
            Next

        Catch ex As Exception
            HandleException("LoadScoreLabels", ex)
        End Try

    End Sub

    Private Sub LoadSourcePictures()
        Dim intIndex As Integer

        ' Note that the pctSource and pctSourceSmall arrays start off already containing one item, at index 0

        pctSource.Item(0).Visible = False
        pctSourceSmall.Item(0).Visible = False

        For intIndex = 1 To 9
            pctSource.AddNewPictureBox()
            pctSourceSmall.AddNewPictureBox()
            pctSource.Item(intIndex).Visible = False
            pctSourceSmall.Item(intIndex).Visible = False
        Next

        pctSource.Item(0).Image = _pctSource_0.Image
        pctSource.Item(1).Image = _pctSource_1.Image
        pctSource.Item(2).Image = _pctSource_2.Image
        pctSource.Item(3).Image = _pctSource_3.Image
        pctSource.Item(4).Image = _pctSource_4.Image
        pctSource.Item(5).Image = _pctSource_5.Image
        pctSource.Item(6).Image = _pctSource_6.Image
        pctSource.Item(7).Image = _pctSource_7.Image
        pctSource.Item(8).Image = _pctSource_8.Image
        pctSource.Item(9).Image = _pctSource_9.Image

        pctSourceSmall.Item(0).Image = _pctSourceSmall_0.Image
        pctSourceSmall.Item(1).Image = _pctSourceSmall_1.Image
        pctSourceSmall.Item(2).Image = _pctSourceSmall_2.Image
        pctSourceSmall.Item(3).Image = _pctSourceSmall_3.Image
        pctSourceSmall.Item(4).Image = _pctSourceSmall_4.Image
        pctSourceSmall.Item(5).Image = _pctSourceSmall_5.Image
        pctSourceSmall.Item(6).Image = _pctSourceSmall_6.Image
        pctSourceSmall.Item(7).Image = _pctSourceSmall_7.Image
        pctSourceSmall.Item(8).Image = _pctSourceSmall_8.Image
        pctSourceSmall.Item(9).Image = _pctSourceSmall_9.Image

    End Sub

    Private Sub LoadTeamControls()
        Dim x As Short

        Try
            ' Note that the cboPlayerList array starts off already containing one item, at index 0

            For x = 1 To MAX_TEAM_INDEX
                lblTeamName.AddNewLabel()

                ' Add two player list combox boxes for each team
                cboPlayerList.AddNewComboBox()
                cboPlayerList.AddNewComboBox()
            Next x

            ' Add one extra combo box
            cboPlayerList.AddNewComboBox()

        Catch ex As Exception
            HandleException("LoadTeamControls", ex)
        End Try


    End Sub

    Private Sub PositionTeamControls(maxTeamIndex As Short, blnPlayingCricket As Boolean)
        Dim intPosTop, x, intPosLeft As Short
        Dim intTopRowFinalIndex As Short

        Try

            Select Case maxTeamIndex
                Case 2 To 3
                    intTopRowFinalIndex = 1
                Case Else
                    ' Includes 0, 1, 4, 5
                    intTopRowFinalIndex = 2
            End Select

            If mScoreAreaSize = sasScoreAreaSizeConstants.sasNormal Then
                lblTeamName.Item(0).Top = 3
            Else
                lblTeamName.Item(0).Top = 3
            End If

            cboPlayerList.Item(0).Top = lblTeamName.Item(0).Top + 20
            If cboPlayerList.Count > 1 Then
                cboPlayerList.Item(1).Top = cboPlayerList.Item(0).Top + 23
            End If

            For x = 0 To MAX_TEAM_INDEX
                If x <= intTopRowFinalIndex Then
                    intPosTop = lblTeamName.Item(0).Top
                    intPosLeft = lblTeamName.Item(0).Left + x * DISTANCE_BETWEEN_COLUMNS
                Else
                    If blnPlayingCricket Then
                        If mScoreAreaSize = sasScoreAreaSizeConstants.sasNormal Then
                            intPosTop = lblTeamName.Item(0).Top + 360
                        Else
                            intPosTop = lblTeamName.Item(0).Top + 267
                        End If
                    Else
                        intPosTop = lblTeamName.Item(0).Top + 167
                    End If

                    If x - (intTopRowFinalIndex + 1) < lblTeamName.Count Then
                        intPosLeft = lblTeamName.Item(x - (intTopRowFinalIndex + 1)).Left
                    Else
                        intPosLeft = lblTeamName.Item(0).Left + x * DISTANCE_BETWEEN_COLUMNS
                    End If

                End If

                If x < lblTeamName.Count Then
                    lblTeamName.Item(x).Top = intPosTop
                    lblTeamName.Item(x).Left = intPosLeft
                    lblTeamName.Item(x).Text = "Team " & x.ToString

                    If x <= maxTeamIndex Then
                        lblTeamName.Item(x).Visible = True
                    Else
                        lblTeamName.Item(x).Visible = False
                    End If
                End If

                If x * 2 < cboPlayerList.Count Then
                    cboPlayerList.Item(x * 2).Top = lblTeamName.Item(x).Top + 20
                    cboPlayerList.Item(x * 2).Left = intPosLeft
                    cboPlayerList.Item(x * 2).Visible = lblTeamName.Item(x).Visible
                End If

                If x * 2 + 1 < cboPlayerList.Count Then
                    cboPlayerList.Item(x * 2 + 1).Top = cboPlayerList.Item(x * 2).Top + 23
                    cboPlayerList.Item(x * 2 + 1).Left = intPosLeft
                    cboPlayerList.Item(x * 2 + 1).Visible = lblTeamName.Item(x).Visible
                End If
            Next x

        Catch ex As Exception
            HandleException("Cricket->PositionTeamControls", ex)
        End Try

    End Sub

    Private Sub PositionAllControls(Optional ByVal blnClearPictures As Boolean = True)
        Dim blnPlayingCricket As Boolean
        Dim lngHeightDiff As Integer

        If mGameType = gtGameTypeConstants.gtCricket Then
            blnPlayingCricket = True
        Else
            blnPlayingCricket = False
        End If

        PositionTeamControls(mMaxTeamIndexInGame, blnPlayingCricket)
        PositionScoreBoxes(MAX_BOX_INDEX, BOXES_PER_COL, mMaxTeamIndexInGame, blnPlayingCricket, blnClearPictures)
        PositionScoreLabels(mMaxTeamIndexInGame, blnPlayingCricket)

        ' Position Current Hole labels
        lblCurrentHoleLabel.Top = lblBoxName.Item(0).Top + 33

        lngHeightDiff = Math.Abs((lblCurrentHole.Height - lblCurrentHoleLabel.Height) / 2)

        If lblCurrentHole.Height <= lblCurrentHoleLabel.Height Then
            lblCurrentHole.Top = lblCurrentHoleLabel.Top + lngHeightDiff + 2
        Else
            lblCurrentHole.Top = lblCurrentHoleLabel.Top - lngHeightDiff + 2
        End If

        Me.Refresh()

    End Sub

    Private Sub PositionScoreBoxes(MaxBoxIndex As Short, BoxesPerCol As Short, MaxTeamIndexInGame As Short, blnPlayingCricket As Boolean, Optional ByVal blnClearPictures As Boolean = True)
        Dim intPosTop, x, intPosLeft As Short
        Dim intDistanceBetweenScoreBoxes As Short
        Dim intLabelOffset As Short

        Dim intTargetArrayIndex As Short

        Try

            If mScoreAreaSize = sasScoreAreaSizeConstants.sasNormal Then
                intDistanceBetweenScoreBoxes = 33
                intLabelOffset = 8
            Else
                intDistanceBetweenScoreBoxes = 25
                intLabelOffset = 4
            End If

            For x = 0 To MaxBoxIndex
                If x < pctScoreBox.Count Then
                    If Not blnPlayingCricket Then
                        pctScoreBox.Item(x).Visible = False
                    Else
                        If Math.Floor(x / 7) <= MaxTeamIndexInGame Then
                            pctScoreBox.Item(x).Visible = True
                        Else
                            pctScoreBox.Item(x).Visible = False
                        End If

                        If x Mod 7 = 0 Then
                            ' First box in column, position based on Team Player Names position
                            intTargetArrayIndex = Math.Floor(x / 7) * 2 + 1
                            If intTargetArrayIndex < cboPlayerList.Count Then
                                intPosTop = cboPlayerList.Item(intTargetArrayIndex).Top + intDistanceBetweenScoreBoxes
                                If mScoreAreaSize = sasScoreAreaSizeConstants.sasNormal Then
                                    intPosTop += 200
                                End If
                            End If

                            intTargetArrayIndex = Math.Floor(x / 7) * 2
                            If intTargetArrayIndex >= cboPlayerList.Count Then
                                intTargetArrayIndex = 0
                            End If

                            With cboPlayerList.Item(intTargetArrayIndex)
                                intPosLeft = .Left + .Width / 2 - pctScoreBox.Item(x).Width / 2
                            End With
                        Else
                            ' Remaining boxes in column, position based on first box in column
                            intTargetArrayIndex = Math.Floor(x / 7) * 7
                            If intTargetArrayIndex >= pctScoreBox.Count Then
                                intTargetArrayIndex = 0
                            End If

                            intPosTop = pctScoreBox.Item(intTargetArrayIndex).Top + intDistanceBetweenScoreBoxes * BaseIndexValue(x, BoxesPerCol)
                            intPosLeft = pctScoreBox.Item(intTargetArrayIndex).Left
                        End If

                        pctScoreBox.Item(x).Left = intPosLeft
                        pctScoreBox.Item(x).Top = intPosTop
                        pctScoreBox.Item(x).Width = pctScoreBox.Item(0).Width
                        pctScoreBox.Item(x).Height = pctScoreBox.Item(0).Height
                        If blnClearPictures Then pctScoreBox.Item(x).Image = pctScoreBox.Item(0).Image

                    End If
                End If
            Next x

            If blnPlayingCricket Then
                For x = 0 To 6
                    If x < lblBoxName.Count Then
                        lblBoxName.Item(x).Left = pctScoreBox.Item(x).Left - lblBoxName.Item(0).Width + 2
                        lblBoxName.Item(x).Top = pctScoreBox.Item(x).Top + intLabelOffset
                        lblBoxName.Item(x).Width = lblBoxName.Item(0).Width
                        lblBoxName.Item(x).Height = lblBoxName.Item(0).Height
                        lblBoxName.Item(x).Text = (20 - x).ToString()

                        lblBoxName.Item(x).Visible = True

                        If x = 6 Then
                            lblBoxName.Item(x).Text = "Bull"
                            lblBoxName.Item(x).Left = lblBoxName.Item(x).Left - 12
                            lblBoxName.Item(x).Width = lblBoxName.Item(x).Width + intLabelOffset
                        End If
                    End If

                Next x

                For x = 7 To 13
                    If x < lblBoxName.Count Then
                        If MaxTeamIndexInGame > 1 Then
                            lblBoxName.Item(x).Left = lblBoxName.Item(x - 7).Left
                            lblBoxName.Item(x).Top = pctScoreBox.Item((x - 7) + Math.Floor(MaxBoxIndex / 2) + 1).Top + intLabelOffset
                            lblBoxName.Item(x).Width = lblBoxName.Item(x - 7).Width
                            lblBoxName.Item(x).Height = lblBoxName.Item(x - 7).Height
                            lblBoxName.Item(x).Text = lblBoxName.Item(x - 7).Text
                            lblBoxName.Item(x).Visible = True
                        Else
                            lblBoxName.Item(x).Visible = False
                        End If
                    End If
                Next x
            Else
                For x = 0 To 12
                    If x < lblBoxName.Count Then
                        lblBoxName.Item(x).Visible = False
                    End If
                Next x
            End If

        Catch ex As Exception
            HandleException("PositionScoreBoxes", ex)
        End Try

    End Sub

    Private Sub PositionScoreLabels(MaxTeamIndexInGame As Short, blnPlayingCricket As Boolean)
        Dim x, intFirstBoxIndex As Short
        Dim intLabelTopOffset As Short

        Try

            If mScoreAreaSize = sasScoreAreaSizeConstants.sasNormal Then
                intLabelTopOffset = 3
            Else
                intLabelTopOffset = 1
            End If

            For x = 0 To MAX_TEAM_INDEX

                intFirstBoxIndex = x * 7

                If x < lblWinStatus.Count Then
                    If x * 2 + 1 < cboPlayerList.Count Then
                        With cboPlayerList.Item(x * 2 + 1)
                            lblWinStatus.Item(x).Top = .Top + .Height + intLabelTopOffset
                            If mScoreAreaSize = sasScoreAreaSizeConstants.sasNormal Or Not blnPlayingCricket Then
                                lblWinStatus.Item(x).Left = .Left + .Width / 2 - lblWinStatus.Item(x).Width / 2
                            Else
                                lblWinStatus.Item(x).Left = pctScoreBox.Item(intFirstBoxIndex).Left + pctScoreBox.Item(intFirstBoxIndex).Width + 2
                            End If

                        End With
                    End If
                    lblWinStatus.Item(x).Text = "Win"
                    lblWinStatus.Item(x).Visible = False
                End If

                If x < lblScore.Count Then
                    If blnPlayingCricket Then
                        If intFirstBoxIndex + 6 < pctScoreBox.Count Then
                            With pctScoreBox.Item(intFirstBoxIndex + 6)
                                lblScore.Item(x).Top = .Top + .Height + intLabelTopOffset
                                lblScore.Item(x).Left = .Left + .Width / 2 - lblScore.Item(x).Width / 2
                            End With
                        End If

                    Else
                        If x < lblWinStatus.Count Then
                            With lblWinStatus.Item(x)
                                lblScore.Item(x).Top = .Top + .Height + intLabelTopOffset
                                lblScore.Item(x).Left = .Left + .Width / 2 - lblScore.Item(x).Width / 2
                            End With
                        End If
                    End If

                    If x <= MaxTeamIndexInGame Then
                        lblScore.Item(x).Visible = True
                    Else
                        lblScore.Item(x).Visible = False
                    End If

                    lblAltScore.Item(x).Top = lblScore.Item(x).Top
                    lblAltScore.Item(x).Left = lblScore.Item(x).Left
                    lblAltScore.Item(x).Visible = mRelativeScoringEnabled
                    lblAltScore.Item(x).BringToFront() ' Bring to front

                End If

            Next x

        Catch ex As Exception
            HandleException("PositionScoreLabels", ex)
        End Try

    End Sub

    ' Note: the intDistanceFromCenter variable is only used during the game of Golf
    Public Sub RecordHit(intDartValue As Short, intMultiplier As Short, intDistanceFromCenter As Short, Optional ByVal boolRedoHit As Boolean = False)
        Dim intCurrentTeamIndex, BoxIndex As Short
        Dim intMultiplierIndex As Short
        Dim boolValidMove, AlreadyClosed, boolDoubledInAlready As Boolean
        Dim intRollBackIndex, intRollBackCount As Short

        Try

            intCurrentTeamIndex = lstCurrentTeam.SelectedIndex

            If Not boolRedoHit Then
                ' Add to Undo History (if not re-doing)
                mUndoHistoryCount = mUndoHistoryCount + 1
                With mUndoHistory(mUndoHistoryCount)
                    If cboPlayerList.Item(mPlayerColumn * 2 + mPlayerRow).SelectedIndex > 0 Then
                        .PlayerName = GetComboBoxItemText(cboPlayerList.Item(mPlayerColumn * 2 + mPlayerRow))
                    Else
                        .PlayerName = GetComboBoxItemText(cboPlayerList.Item(mPlayerColumn * 2))
                    End If
                    .TeamIndex = intCurrentTeamIndex
                    .DartValue = intDartValue
                    .DistanceFromCenter = intDistanceFromCenter
                    .Multiplier = intMultiplier
                    .ValidHits = 0 ' Assume, for now, that dart doesn't count (i.e. is a miss)
                End With
                If mMaxUndoHistoryCount < mUndoHistoryCount Then mMaxUndoHistoryCount = mUndoHistoryCount
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
                Case gtGameTypeConstants.gt301
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
                                ' Increment .ValidHits in mUndoHistory() (if not re-doing)
                                mUndoHistory(mUndoHistoryCount).ValidHits = mUndoHistory(mUndoHistoryCount).ValidHits + intMultiplier
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
                Case gtGameTypeConstants.gtGolf
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
                            If pctScoreBox.Item(BoxIndex).Enabled = True Then
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
                                    ' Increment .ValidHits in mUndoHistory() (if not re-doing)
                                    mUndoHistory(mUndoHistoryCount).ValidHits = mUndoHistory(mUndoHistoryCount).ValidHits + 1
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

            If mUndoHistoryCount < mMaxUndoHistoryCount Then

                mUndoHistoryCount = mUndoHistoryCount + 1
                With mUndoHistory(mUndoHistoryCount)
                    ' Increment team list (if necessary)
                    If lstCurrentTeam.SelectedIndex <> .TeamIndex Then
                        ' If playing golf, need to use SmartAdvanceTeam
                        If Me.GetGameType() = gtGameTypeConstants.gtGolf Then
                            frmDartBoard.SmartAdvanceToNextTeam()
                        Else
                            AdvanceToNextTeam(False)
                        End If
                    End If

                    RecordHit(.DartValue, .Multiplier, .DistanceFromCenter, True)

                    ' Put the dart dot back on the dart board (if one of the most recent darts)
                    If mUndoHistoryCount > HistoryIndexOfMostRecentTurn Then
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

        If mGameType = gtGameTypeConstants.gt301 Or mGameType = gtGameTypeConstants.gtGolf Then
            ' Playing 301
            If mMaxTeamIndexInGame < 3 Then
                If mMaxTeamIndexInGame <= 1 Then
                    Me.Width = WIDTH_BASE + WIDTH_ADDER * 2
                Else
                    Me.Width = WIDTH_BASE + WIDTH_ADDER * (mMaxTeamIndexInGame + 1)
                End If
            Else
                Me.Width = WIDTH_BASE + WIDTH_ADDER * 3
            End If
            Me.Height = HEIGHT_BASE
        Else
            If mGameType <> gtGameTypeConstants.gtCricket Then
                MessageBox.Show("mGameType has an unknown value in ResizeFormToDefaults: " & mGameType.ToString(), "Unexpected value", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            ' Playing Cricket
            Select Case mMaxTeamIndexInGame
                Case 0 To 3 : Me.Width = WIDTH_BASE + WIDTH_ADDER * 2
                Case 4 To 5 : Me.Width = WIDTH_BASE + WIDTH_ADDER * 3
            End Select

            Select Case mMaxTeamIndexInGame
                Case 0 To 1 : Me.Height = HEIGHT_BASE
                Case Else
                    If mScoreAreaSize = sasScoreAreaSizeConstants.sasNormal Then
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
                mPlayerColumn = mPlayerColumn - 1
            Else
                lstCurrentTeam.SelectedIndex = mMaxTeamIndexInGame
                mPlayerColumn = mMaxTeamIndexInGame
                If mPlayerRow = 1 Then mPlayerRow = 0 Else mPlayerRow = 1
            End If

            HighlightCurrentPlayer(mPlayerRow, True)

            frmDartBoard.ClearDartBoard()

            lblCurrentHole.Text = CStr(intCurrentHole(lstCurrentTeam.SelectedIndex))

        Catch ex As Exception
            HandleException("SelectPreviousTeam", ex)
        End Try
    End Sub

    Public Sub SetScoreAreaSize(eScoreAreaSize As sasScoreAreaSizeConstants)
        Dim intIndex As Short
        Dim lngScoreBoxSize As Integer
        Dim CurrentVal As Short
        Dim intAddOn As Short

        mScoreAreaSize = eScoreAreaSize

        If mScoreAreaSize = sasScoreAreaSizeConstants.sasNormal Then
            lngScoreBoxSize = SCOREBOX_SIZE_NORMAL
        Else
            lngScoreBoxSize = SCOREBOX_SIZE_SMALL
        End If

        For intIndex = 0 To MAX_BOX_INDEX
            If intIndex < pctScoreBox.Count Then

                pctScoreBox.Item(intIndex).Width = lngScoreBoxSize
                pctScoreBox.Item(intIndex).Height = lngScoreBoxSize

                CurrentVal = GetScoreBoxHitCount(intIndex)

                '        If pctScoreBox.Item(intIndex).Enabled Then
                '            intAddOn = 0
                '        Else
                '            intAddOn = SCOREBOX_DIM_ADDON
                '        End If

                If CurrentVal >= spScorePictureConstants.spThree Then
                    SetPicture(pctScoreBox.Item(intIndex), spScorePictureConstants.spThree + intAddOn)
                ElseIf CurrentVal >= spScorePictureConstants.spZero And CurrentVal <= spScorePictureConstants.spTwo Then
                    SetPicture(pctScoreBox.Item(intIndex), CurrentVal + intAddOn)
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

        lblCurrentHole.Font = New Font("Arial", glbScoreFontSize, FontStyle.Regular)
        lblCurrentHole.Height = glbScoreFontSize * sngHeightScalar
        lblCurrentHole.Width = glbScoreFontSize * sngWidthScalar

        For intBoxIndex = 0 To lblScore.Count - 1
            lblScore.Item(intBoxIndex).Font = lblCurrentHole.Font.Clone
            lblScore.Item(intBoxIndex).Height = glbScoreFontSize * sngHeightScalar
            lblScore.Item(intBoxIndex).Width = glbScoreFontSize * sngWidthScalar

            lblAltScore.Item(intBoxIndex).Font = lblCurrentHole.Font.Clone
            lblAltScore.Item(intBoxIndex).Height = glbScoreFontSize * sngHeightScalar
            lblAltScore.Item(intBoxIndex).Width = glbScoreFontSize * sngWidthScalar
        Next intBoxIndex


        PositionAllControls(blnClearPictures)

    End Sub

    Private Sub SetPicture(ByRef pctThisPicture As PictureBox, ePictureToShow As spScorePictureConstants)
        Try
            If mScoreAreaSize = sasScoreAreaSizeConstants.sasNormal Then
                pctThisPicture.Image = pctSource.Item(ePictureToShow).Image
            Else
                pctThisPicture.Image = pctSourceSmall.Item(ePictureToShow).Image
            End If
        Catch ex As Exception
            HandleException("SetPicture", ex)
        End Try

    End Sub

    Private Sub ShowHelp()
        Dim strMessage As String
        Dim strTitle As String

        Select Case mGameType
            Case gtGameTypeConstants.gt301
                strMessage = "The object of 301 is to be the first player to reach exactly zero by subtracting each region's point value from the initial score of 301.  " &
                             "Hitting in the small outer ring of a number counts as a 'double', and the small middle ring counts as a 'triple'.  " &
                             "Further, the center bullseye counts as a 'double bull'.  " &
                             "If the player goes below zero, then that player 'busts', and his score is set back to what it was prior to throwing the dart; further, his turn is forfeited.  " &
                             "You can change the initial score to a value besides 301 if desired.  " &
                             "A variation on 301 is to require Double In or Double Out.  " &
                             "Double In means that the player must score a hit in the double ring before he can begin subtracting hits from his score.  " &
                             "In Double Out, the player has to go out on a double.  " &
                             "For example, if you have 10 points, you can close on a double 5."

                strTitle = "How to play 301"

            Case gtGameTypeConstants.gtCricket
                strMessage = "The object of Cricket is to 'close' regions fifteen through twenty and the bullseye before your opponent(s).  " &
                             "In order to close an area, you must hit it three times.  " &
                             "Hitting in the small outer ring of a number counts as a 'double', and the small middle ring counts as a 'triple'.  " &
                             "Further, the center bullseye counts as a 'double bull'.  " &
                             "On the scoreboard, a single slash represents one hit, an X represents two, and a circled X indicates that the region has been closed.  " &
                             "In Cutthroat Cricket, if you close a region before your opponent, any additional hits on that region will cause points to be scored on any opponents who have not closed that region.  " &
                             "The game is over when a player/team closes the numbers 15 through 20, closes the bull, and has the same or fewer points as any other player/team."

                strTitle = "How to play Cricket"

            Case gtGameTypeConstants.gtGolf
                strMessage = "The object of Golf is to hit the corresponding region for the current hole.  " &
                             "You start with hole 1, then, 2, etc.  You can throw one, two, or three darts on each hole, but only the last dart thrown counts.  " &
                             "Hitting the triple ring gives you two under par (-2) for the current hole; " &
                             "hitting the double ring gives you one under par (-1) for the current hole; " &
                             "hitting the inner triangle (between the Bull and the Triple ring) is par for the hole (0); " &
                             "hitting the outeger triangle (between the Triple ring and the Double ring) is one over par (+1); " &
                             "any other location is two over par (+2). Your score at the end of the game is the sum of your score value for each hole (holes 1 through 18)."
                strTitle = "How to play Golf"
            Case Else
                strMessage = "Unknown game type; help not available."
                strTitle = "How to Play"

        End Select

        MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Public Sub ShowRealTimeStatistics()

        If mGameType <> gtGameTypeConstants.gtGolf Then
            frmRealtimeStatistics.Show()

            With frmRealtimeStatistics
                .Top = Me.Top + 400
                If mMaxTeamIndexInGame <= 1 Then
                    .Left = Me.Left + 187
                ElseIf mMaxTeamIndexInGame <= 2 Then
                    .Left = Me.Left + 300
                ElseIf mMaxTeamIndexInGame <= 4 Then
                    .Left = Me.Left + 347
                Else
                    .Left = Me.Left + 437
                End If

                .TopMost = True
            End With

        End If

    End Sub

    Public Sub StartNewGameWrapper(eGameType As gtGameTypeConstants)
        Select Case eGameType
            Case gtGameTypeConstants.gt301
                StartNewGame(True, gtGameTypeConstants.gt301)
            Case gtGameTypeConstants.gtGolf
                StartNewGame(True, gtGameTypeConstants.gtGolf)
            Case Else
                StartNewGame(True, gtGameTypeConstants.gtCricket)
        End Select
    End Sub

    Public Sub StartNewGame(boolNotifyGameInProgress As Boolean, eGameTypeNewGame As gtGameTypeConstants)
        Dim x, y As Short
        Dim eResponse As DialogResult
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

                    eResponse = MessageBox.Show(strMessage, "Game in Progress", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

                    If eResponse <> DialogResult.Yes Then
                        Exit Sub
                    End If

                End If
            End If

            ' Determine game type
            Select Case eGameTypeNewGame
                Case gtGameTypeConstants.gt301
                    blnSuccess = Short.TryParse(txtStartNumber.Text, intStartNumber301)

                    If Not blnSuccess Then
                        strMessage = "The start number box must contain a numeric value.  Changing to 301."
                        MessageBox.Show(strMessage, "Invalid Start Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                        intStartNumber301 = 301
                        txtStartNumber.Text = intStartNumber301.ToString

                    ElseIf intStartNumber301 < 2 Or intStartNumber301 >= 50000 Then
                        strMessage = "Invalid starting number; typical values are 101, 301, or 501.  Cannot start new game."
                        MessageBox.Show(strMessage, "Invalid Start Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub

                    End If
                    boolPlaying301 = True

                    glbDefault301StartScore = intStartNumber301

                Case gtGameTypeConstants.gtGolf
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
            mUndoHistoryCount = 0
            mMaxUndoHistoryCount = 0
            HistoryIndexOfMostRecentTurn = 0
            mUndoRedoInProgress = False

            mStartTime = DateTime.Now
            mLastClickTime = DateTime.Now.AddSeconds(-CLICK_KEEP_TIME * 2)

            txtHitCount.Visible = False

            ' Set Max Team Index
            Dim strTeamCount As String
            strTeamCount = GetComboBoxItemText(cboNumberOfTeams)

            If strTeamCount.Length > 0 Then
                mMaxTeamIndexInGame = CInt(strTeamCount) - 1
            Else
                mMaxTeamIndexInGame = 1
            End If

            ' Set mMaxBoxIndexInGame (used in cricket only)
            mMaxBoxIndexInGame = (mMaxTeamIndexInGame + 1) * BOXES_PER_COL - 1

            ' Re-initialize the boolDoubledIn array (used in 301 only)
            ReDim boolDoubledIn(mMaxTeamIndexInGame)

            ' Re-initialize Golf data (used in Golf only)
            lblCurrentHole.Text = CStr(1)
            ReDim intCurrentHole(MAX_TEAM_INDEX)

            For x = 0 To MAX_TEAM_INDEX
                If x <= mMaxTeamIndexInGame Then
                    boolValue = True
                Else
                    boolValue = False
                End If

                For y = x * 7 To (x + 1) * 7 - 1
                    If blnPlayingCricket Then
                        pctScoreBox.Item(y).Enabled = boolValue
                        pctScoreBox.Item(y).Visible = boolValue
                    Else
                        pctScoreBox.Item(y).Visible = False
                    End If
                Next y

                lblTeamName.Item(x).Visible = boolValue
                cboPlayerList.Item(x * 2).Visible = boolValue
                cboPlayerList.Item(x * 2 + 1).Visible = boolValue
                cboPlayerList.Item(x * 2).BackColor = Color.White
                cboPlayerList.Item(x * 2 + 1).BackColor = Color.White

                lblScore.Item(x).Visible = boolValue
                If boolPlaying301 Then
                    ' Playing 301
                    UpdateTeamScore(x, intStartNumber301)
                Else
                    UpdateTeamScore(x, 0)
                End If
                lblAltScore.Item(x).Visible = False
                lblWinStatus.Item(x).Visible = False

                intCurrentHole(x) = 1
            Next x

            ' Initialize the team list
            lstCurrentTeam.Items.Clear()
            For x = 1 To mMaxTeamIndexInGame + 1
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
            mPlayerRow = 0
            mPlayerColumn = 0
            HighlightCurrentPlayer(mPlayerRow, Not boolSoundPlayed)

            ' Resize form as needed
            ResizeFormToDefaults()

            ' Make sure dart board is shown
            'frmDartboard.Show

        Catch ex As Exception
            HandleException("StartNewGame", ex)
        End Try

    End Sub

    Private Function Subtract301Score(ScoreAmt As Short, intMultiplier As Short, intCurrentTeamIndex As Short) As Boolean
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
                With lblAltScore.Item(x)
                    If mRelativeScoringEnabled And x <= mMaxTeamIndexInGame Then
                        .Visible = True
                    Else
                        .Visible = False
                    End If
                End With
            Next x
            lblScoreMode.Visible = lblAltScore.Item(0).Visible

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

            If mUndoHistoryCount > 0 Then
                If frmDartBoard.DartThrowCount > 0 Then
                    With mUndoHistory(mUndoHistoryCount)
                        intCurrentTeamIndex = .TeamIndex

                        ' Only undo this dart the number of times given by .ValidHits
                        For intUndoIndex = 1 To .ValidHits
                            Select Case mGameType
                                Case gtGameTypeConstants.gt301
                                    ' Playing 301
                                    ' Update score by "subtracting" the negative of the dart value, i.e. adding back the value
                                    Subtract301Score(- .DartValue, 1, intCurrentTeamIndex)
                                Case gtGameTypeConstants.gtGolf
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
                                            AddScore(- .DartValue, BoxIndex, intCurrentTeamIndex)
                                        End If
                                    End If
                            End Select
                        Next intUndoIndex
                    End With

                    ' Hide the Win/Lose/Out labels if not game Over
                    If Not CheckForGameOver(True) Then
                        For intThisTeamIndex = 0 To mMaxTeamIndexInGame
                            lblWinStatus.Item(intThisTeamIndex).Visible = False
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
                    mUndoHistoryCount = mUndoHistoryCount - 1

                    lblStatus.Text = "Turn undone"
                    mPauseDelay = SHORT_TIME_DELAY
                Else
                    ' Decrement team list if frmDartboard.DartThrowCount = 0
                    Do While mUndoHistory(mUndoHistoryCount).TeamIndex = lstCurrentTeam.SelectedIndex
                        ' Make sure the correct team is displayed in lstCurrentTeam.listindex
                        ' It would not be if the user pressed the Next Team or Previous Team buttons
                        '  on frmCricket (those buttons do not adjust the score automatically)
                        SelectPreviousTeam()
                    Loop

                    Do
                        SelectPreviousTeam()
                    Loop While lstCurrentTeam.SelectedIndex <> mUndoHistory(mUndoHistoryCount).TeamIndex

                    ' If playing golf, decrement current hole
                    If mGameType = gtGameTypeConstants.gtGolf Then
                        intCurrentTeamIndex = lstCurrentTeam.SelectedIndex
                        intCurrentHole(intCurrentTeamIndex) = intCurrentHole(intCurrentTeamIndex) - 1
                        lblCurrentHole.Text = CStr(intCurrentHole(intCurrentTeamIndex))
                    End If

                    ' The cmdPreviousTeam button cleared the dart board and updated lstCurrentTeam.listIndex
                    ' Populate it with the previous three darts (assuming they exist and all were for the same player)
                    intDartsToPopulate = 0
                    For intPopulateBoardIndex = mUndoHistoryCount To mUndoHistoryCount - 2 Step -1
                        If intPopulateBoardIndex > 0 Then
                            If mUndoHistory(intPopulateBoardIndex).TeamIndex = mUndoHistory(mUndoHistoryCount).TeamIndex Then
                                intDartsToPopulate = intDartsToPopulate + 1
                            Else
                                Exit For
                            End If
                        End If
                    Next intPopulateBoardIndex

                    If intDartsToPopulate > 0 Then
                        For intPopulateBoardIndex = mUndoHistoryCount - intDartsToPopulate + 1 To mUndoHistoryCount
                            With mUndoHistory(intPopulateBoardIndex)
                                frmDartBoard.PlaceDart(.DartValue, .Multiplier)
                            End With
                        Next intPopulateBoardIndex

                        ' Note: SelectPreviousTeam(), used above, had the side effect of setting
                        '       boolLastActionUndo = False , so need to set it true again
                        frmDartBoard.SetLastActionUndo()
                    End If

                    ' Update HistoryIndexOfMostRecentTurn to the new value
                    HistoryIndexOfMostRecentTurn = mUndoHistoryCount - intDartsToPopulate

                    ' For Golf, decrement score of most recent dart
                    If mGameType = gtGameTypeConstants.gtGolf Then
                        With mUndoHistory(mUndoHistoryCount)
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

        For intIndex = 1 To mUndoHistoryCount
            With mUndoHistory(intIndex)

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

    Protected Sub UpdateTeamScore(intTeamIndex As Integer, strNewScore As String)
        UpdateTeamScore(intTeamIndex, CShort(strNewScore))
    End Sub

    Protected Sub UpdateTeamScore(intTeamIndex As Integer, intNewScore As Integer)
        Dim BestScoreVal As Short
        Dim ScoreCompare As Short
        Dim x As Integer

        lblScore.Item(intTeamIndex).Text = intNewScore.ToString()

        BestScoreVal = intNewScore
        For x = 1 To mMaxTeamIndexInGame
            ScoreCompare = GetTeamScore(x)
            If ScoreCompare < BestScoreVal Then
                BestScoreVal = ScoreCompare
            End If
        Next x

        For x = 0 To mMaxTeamIndexInGame
            lblAltScore.Item(x).Text = (GetTeamScore(x) - BestScoreVal).ToString
        Next x

    End Sub

    Public Sub WriteStatsFile(eSourceFormGameType As gtGameTypeConstants, MaxTeamIndexInGame As Short,
                              StartTime As DateTime, ByRef currentUndoHistory() As usrUndoHistory, currentUndoHistoryCount As Short)

        Dim x As Short

        Dim PlayerStatsOut As frmPlayerStats.udtPlayerStatsType
        Dim TimeElapsedString As String
        Dim dtGameTime As DateTime
        Dim StatsFilePath, StatsExtendedFilePath As String

        Dim swOutFile As StreamWriter

        dtGameTime = DateTime.Now

        TimeElapsedString = MinutesToTimeString(dtGameTime.Subtract(StartTime).TotalMinutes)

        Try
            ' Make sure all of the player boxes have names
            For x = 0 To MaxTeamIndexInGame

                PlayerStatsOut.PlayerName = GetComboBoxItemText(cboPlayerList.Item(x * 2))
                PlayerStatsOut.PartnerName = GetComboBoxItemText(cboPlayerList.Item(x * 2 + 1))

                If String.IsNullOrEmpty(PlayerStatsOut.PlayerName) And String.IsNullOrEmpty(PlayerStatsOut.PartnerName) Then
                    Dim strMessage As String
                    strMessage = "You have not entered player names for one or more teams.  Statistics will not be saved.  In order to make this game count, select player names for all teams, click the undo button, and click the redo button."
                    MessageBox.Show(strMessage, "Missing names", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                ElseIf String.IsNullOrEmpty(PlayerStatsOut.PlayerName) And String.IsNullOrEmpty(PlayerStatsOut.PartnerName) Then
                    ' Swap the second player with the first player so the first isn't blank
                    cboPlayerList.Item(x * 2).SelectedIndex = cboPlayerList.Item(x * 2 + 1).SelectedIndex
                    cboPlayerList.Item(x * 2 + 1).SelectedIndex = 0
                End If
            Next x

            ' Record Simple Stats
            ' Append the current year and month to StatsFileNameBase
            ' This way, all stats for the current month will reside in the same file
            StatsFilePath = StatsFileNameBase & "_" & dtGameTime.ToString("yyyyMM") & ".ini"

            swOutFile = New StreamWriter(New FileStream(StatsFilePath, FileMode.Append, FileAccess.Write, FileShare.Read))

            For x = 0 To MaxTeamIndexInGame

                PlayerStatsOut.GameDateTime = dtGameTime
                PlayerStatsOut.GameTimeElapsed = TimeElapsedString
                PlayerStatsOut.PlayerName = GetComboBoxItemText(cboPlayerList.Item(x * 2))
                PlayerStatsOut.PartnerName = GetComboBoxItemText(cboPlayerList.Item(x * 2 + 1))

                If eSourceFormGameType = gtGameTypeConstants.gt301 Then
                    If lblScore.Item(x).Text = "0" Then PlayerStatsOut.GameWon = True Else PlayerStatsOut.GameWon = False
                Else
                    If lblWinStatus.Item(x).Text = "Win" Then PlayerStatsOut.GameWon = True Else PlayerStatsOut.GameWon = False
                End If
                PlayerStatsOut.GameName = LookupGameStringByType(eSourceFormGameType)
                PlayerStatsOut.Points = lblScore.Item(x).Text

                With PlayerStatsOut
                    ' =8/6/1999 2:44:16 PM ,10:23,
                    swOutFile.WriteLine("Stat=" &
                                        .GameDateTime.ToString("M/d/yyyy h:mm:ss tt") & "," &
                                        .GameTimeElapsed & "," &
                                        .PlayerName & "," &
                                        .PartnerName & "," &
                                        .GameWon & "," &
                                        .Points & "," &
                                        .GameName)
                End With
            Next x

            swOutFile.Close()

            ' Record Extended Stats
            ' Append the current year and month to StatsExtendedFilenameBase
            ' This way, all stats for the current month will reside in the same file
            StatsExtendedFilePath = StatsExtendedFilenameBase & "_" & dtGameTime.ToString("yyyyMM") & ".ini"

            swOutFile = New StreamWriter(New FileStream(StatsExtendedFilePath, FileMode.Append, FileAccess.Write, FileShare.Read))

            For x = 1 To currentUndoHistoryCount
                With currentUndoHistory(x)
                    swOutFile.WriteLine("ExtStat=" &
                                        dtGameTime.ToString("M/d/yyyy h:mm:ss tt") & "," &
                                        .TeamIndex + 1 & "," &
                                        .PlayerName & "," &
                                        .DartValue & "," &
                                        .Multiplier & "," &
                                        .ValidHits)
                End With
            Next x
            swOutFile.Close()

            PlayWaveFileForPlayer("DartGameOver", False, False)

            MessageBox.Show("Game over; statistics have been saved.", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Game over, but unable to save the stats: " & ex.Message, "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Private Sub cboPlayerList_SelectedIndexChanged(eventSender As Object, eventArgs As EventArgs) Handles cboPlayerList.SelectedIndexChanged
        Dim objControl As ComboBox

        objControl = CType(eventSender, ComboBox)

        HighlightCurrentPlayer(mPlayerRow)
        PlayWaveFileForPlayer(GetComboBoxItemText(objControl), False, False)

    End Sub

    Private Sub chkDoubleIn_CheckStateChanged(eventSender As Object, eventArgs As EventArgs) Handles chkDoubleIn.CheckStateChanged
        glbBoolRequireDoubleIn = CChkBox(chkDoubleIn)
    End Sub

    Private Sub chkDoubleOut_CheckStateChanged(eventSender As Object, eventArgs As EventArgs) Handles chkDoubleOut.CheckStateChanged
        glbBoolRequireDoubleOut = CChkBox(chkDoubleOut)
    End Sub

    Private Sub cmdClose_Click(eventSender As Object, eventArgs As EventArgs) Handles cmdClose.Click
        HideGameForms(True)
    End Sub

    Private Sub cmdHelp_Click(eventSender As Object, eventArgs As EventArgs) Handles cmdHelp.Click
        ShowHelp()
    End Sub

    Private Sub cmdNextTeam_Click(eventSender As Object, eventArgs As EventArgs) Handles cmdNextTeam.Click
        AdvanceToNextTeam(False)
    End Sub

    Private Sub cmdPreviousTeam_Click(eventSender As Object, eventArgs As EventArgs) Handles cmdPreviousTeam.Click
        SelectPreviousTeam()
    End Sub

    Private Sub cmdRedo_Click(eventSender As Object, eventArgs As EventArgs) Handles cmdRedo.Click
        RedoThrow()
    End Sub

    Private Sub cmdScoreMode_Click(eventSender As Object, eventArgs As EventArgs) Handles cmdScoreMode.Click
        ToggleRelativeScoring(True)
    End Sub

    Private Sub cmdShowRealtimeStatistics_Click(eventSender As Object, eventArgs As EventArgs) Handles cmdShowRealtimeStatistics.Click
        ShowRealTimeStatistics()
    End Sub

    Private Sub cmdStartNewGame_Click(eventSender As Object, eventArgs As EventArgs) Handles cmdStartNewGame.Click
        ' Set mNewGameButtonClicked to True to assure that the DartGameStart sound is played
        mNewGameButtonClicked = True

        StartNewGameWrapper(mGameType)

        mNewGameButtonClicked = False
    End Sub

    Private Sub cmdShowDartBoard_Click(eventSender As Object, eventArgs As EventArgs) Handles cmdShowDartBoard.Click
        frmDartBoard.Show()
    End Sub

    Private Sub cmdUndo_Click(eventSender As Object, eventArgs As EventArgs) Handles cmdUndo.Click
        UndoThrow()
    End Sub

    'UPGRADE_WARNING: Form event frmCricket.Activate has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
    Private Sub frmCricket_Activated(eventSender As Object, eventArgs As EventArgs) Handles MyBase.Activated

        HighlightCurrentPlayer(mPlayerRow)

        Cursor.Current = Cursors.Default

    End Sub

    Private Sub frmCricket_Load(eventSender As Object, eventArgs As EventArgs) Handles MyBase.Load
        Dim x As Short

        Try
            ' Load source pictures
            LoadSourcePictures()

            ' Load Team Names and Player Lists
            LoadTeamControls()

            ' Load Score Boxes
            LoadScoreBoxes(MAX_BOX_INDEX, 6)

            ' Load Win Labels, Score Labels, and Alt Score Labels
            LoadScoreLabels()

            ' Set the Default 301 Starting Score
            txtStartNumber.Text = glbDefault301StartScore

            ' Set Double In/Out values
            If glbBoolRequireDoubleIn Then
                chkDoubleIn.CheckState = CheckState.Checked
            Else
                chkDoubleIn.CheckState = CheckState.Unchecked
            End If

            If glbBoolRequireDoubleOut Then
                chkDoubleOut.CheckState = CheckState.Checked
            Else
                chkDoubleOut.CheckState = CheckState.Unchecked
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

            SetScoreAreaSize(glbScoreAreaSizeVal)

            frmDartBoard.Left = Screen.PrimaryScreen.Bounds.Width - frmDartBoard.Width
            frmDartBoard.Top = 0

            ' Set up new game (will show/hide controls and position as needed)
            StartNewGameWrapper(mGameType)

            tmrTimer.Interval = 1000
            tmrTimer.Enabled = True


        Catch ex As Exception
            HandleException("frmCricket_Load", ex)
        End Try

    End Sub

    Private Sub frmCricket_FormClosing(eventSender As Object, eventArgs As FormClosingEventArgs) Handles Me.FormClosing

        If eventArgs.CloseReason = CloseReason.UserClosing Then
            eventArgs.Cancel = True
            HideGameForms(False)
        End If

    End Sub


    Private Sub tmrTimer_Tick(eventSender As Object, eventArgs As EventArgs) Handles tmrTimer.Tick

        If mPauseDelay <= 0 Then
            lblStatus.Text = MinutesToTimeString(DateTime.Now.Subtract(mStartTime).TotalMinutes) & " elapsed."
        Else
            mPauseDelay -= 1
        End If

        If DateTime.Now.Subtract(mLastClickTime).TotalSeconds > CLICK_KEEP_TIME Then
            ' Reset mLastClickTeam and hide txtHitCount
            mLastClickTeam = -1
            txtHitCount.Visible = False
        End If

    End Sub

    Private Sub txtStartNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtStartNumber.KeyPress
        TextBoxKeyPressHandler(txtStartNumber, e, True, False)
    End Sub

End Class