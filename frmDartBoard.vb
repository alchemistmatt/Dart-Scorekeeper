Option Strict Off
Option Explicit On
'Imports VB = Microsoft.VisualBasic
'Imports Microsoft.VisualBasic.PowerPacks

Friend Class frmDartBoard
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

#Region "Structures"
    Public Structure usrDartHitStats
        Public intMultiplier As Short
        Public intValue As Short
    End Structure
#End Region

#Region "Module-wide variables"
    Private mLastActionUndo As Boolean
    Private mCompletingTurn As Boolean
    
    Private mDartThrowCount As Short ' 0, 1, 2, or 3
    Private mLastThreeDarts(3) As Short ' 1-based array; Keep track of most recent three darts
    Private mLastThreeDartMultipliers(3) As Short ' 1-based array; Also keep track of the multipliers
    
    Private mDartClickTime As System.DateTime

#End Region

#Region "Properties"
    Public ReadOnly Property DartThrowCount() As Short
        Get
            Return mDartThrowCount
        End Get
    End Property
#End Region

    Public Sub ClearDartBoard()
        Dim intThisDart As Short

        For intThisDart = 0 To 2
            GetDartPicture(intThisDart).Visible = False
            GetDartScoreLabel(intThisDart).Visible = False
        Next intThisDart
        mDartThrowCount = 0
    End Sub

    Public Sub CompleteTurn(ByVal eGameType As modDarts.gtGameTypeConstants)
        Dim intComboMatchValues As System.Collections.Generic.SortedDictionary(Of Short, Short)

        Dim intThisDartIndex, intDartsThrownAlready As Short
        Dim intDartValueTotal, intTurnTotal As Short

        Dim intSearchIndex, intComboSum As Short

        Dim strSoundFileToPlay As String = String.Empty

        ' Initialize intComboMatchValues
        intComboMatchValues = New System.Collections.Generic.SortedDictionary(Of Short, Short)

        intComboMatchValues.Add(1, 0)
        intComboMatchValues.Add(5, 0)
        intComboMatchValues.Add(20, 0)


        ' Set this to true to prevent the trmShowDart_Timer even from firing if playing
        '  sounds takes too long
        mCompletingTurn = True

        Select Case eGameType
            Case modDarts.gtGameTypeConstants.gt301, modDarts.gtGameTypeConstants.gtCricket
                If eGameType = modDarts.gtGameTypeConstants.gtCricket AndAlso _
                   frmCricket.lblWinStatus(frmCricket.lstCurrentTeam.SelectedIndex).Text = "Out" Then
                    mCompletingTurn = False
                    Exit Sub
                End If

                intTurnTotal = frmCricket.LastThreeDartsTotal

                ' Make sure 3 darts have been placed on the board.  If they haven't, add them, counting
                ' them as misses
                If mDartThrowCount < 3 Then
                    intDartsThrownAlready = mDartThrowCount
                    For intThisDartIndex = intDartsThrownAlready + 1 To 3
                        ' Show "Miss" on DartBoard
                        PlaceDart(0, 0)

                        ' Wait 500 milliseconds
                        Wait(500)

                        ' Add "Miss" to History
                        frmCricket.RecordHit(0, 0, 0)

                    Next intThisDartIndex
                End If

            Case modDarts.gtGameTypeConstants.gtGolf
                If mDartThrowCount = 0 Then
                    ' No darts were thrown, so assume a miss
                    ' Show "Miss" on DartBoard
                    PlaceDart(0, 0)

                    ' Wait 500 milliseconds
                    Wait(500)

                    ' Add "Miss" to History
                    frmCricket.RecordHit(0, 0, 0)
                End If
                frmCricket.CompleteGolfTurn()
        End Select

        If mDartThrowCount = 3 Then
            ' Check for three misses, "The Combo", or 180
            intDartValueTotal = mLastThreeDarts(1) + mLastThreeDarts(2) + mLastThreeDarts(3)

            If intDartValueTotal = 0 Then
                ' Triple Miss
                strSoundFileToPlay = "DartTripleMiss"
            ElseIf intDartValueTotal = 60 Then
                ' Threw three 20's, see if all three were triples
                If intTurnTotal = 180 Then
                    ' Hit three triple 20's
                    strSoundFileToPlay = "Dart180"
                End If
            Else
                ' Check for the Combo
                For intSearchIndex = 1 To 3
                    ' Look for mLastThreeDarts(intSearchIndex) in intComboMatchValues
                    If intComboMatchValues.TryGetValue(mLastThreeDarts(intSearchIndex), 0) Then
                        intComboMatchValues(mLastThreeDarts(intSearchIndex)) += 1
                    End If
                Next intSearchIndex

                ' See if each of the entries in intComboMatchValues has a value of 1 (meaning the dart value was hit once and only once)
                intComboSum = 0
                For Each intValue As Short In intComboMatchValues.Values()
                    If intValue = 1 Then intComboSum += 1
                Next

                If intComboSum = 3 Then
                    ' Combo thrown (1, 5, and 20)
                    strSoundFileToPlay = "DartCombo"

                    If Not System.IO.File.Exists(System.IO.Path.Combine(GetAppFolderPath(), strSoundFileToPlay & ".wav")) Then
                        strSoundFileToPlay = String.Empty
                    End If
                End If

            End If

        End If

        If String.IsNullOrEmpty(strSoundFileToPlay) And intTurnTotal >= glbMinimumScoreToPlaySound Then
            ' Score was above minimum value for playing sounds; see if a file named Dart##.wav exists
            '  based on frmCricket.LastThreeDartsTotal
            strSoundFileToPlay = System.IO.Path.Combine(GetAppFolderPath(), "Dart" & intTurnTotal.ToString() & ".wav")

            If Not System.IO.File.Exists(strSoundFileToPlay) Then
                strSoundFileToPlay = String.Empty
            End If
        End If

        If Not String.IsNullOrEmpty(strSoundFileToPlay) Then
            PlayWaveFileForPlayer(strSoundFileToPlay, False, False)

            ' Delay 500 msec
            Wait(500)
        End If

        mCompletingTurn = False

    End Sub

    Private Function GetDartScoreLabel(ByVal DartIndex As Integer) As Label

        Select Case DartIndex
            Case 0
                Return lblDartScore0
            Case 1
                Return lblDartScore1
            Case 2
                Return lblDartScore2
            Case Else
                Return Nothing
        End Select

    End Function

    Private Function GetDartPicture(ByVal DartIndex As Integer) As PictureBox

        Select Case DartIndex
            Case 0
                Return shpDart0
            Case 1
                Return shpDart1
            Case 2
                Return shpDart2
            Case Else
                Return Nothing
        End Select

    End Function

    Public Function LookUpScore(ByVal intDistance As Short, ByVal intAngle As Short) As usrDartHitStats
        Dim ScoreToAdd As usrDartHitStats

        If intDistance <= glbDartBoardSizes.SingleBullRing Then
            ' Single or double bull
            ScoreToAdd.intValue = 25
            If intDistance < glbDartBoardSizes.DoubleBullRing Then
                ' Double bull
                ScoreToAdd.intMultiplier = 2
            Else
                ' Single bull
                ScoreToAdd.intMultiplier = 1
            End If
        Else
            ' Not at bullseye
            Select Case intDistance
                Case glbDartBoardSizes.TripleRingInsideEdge To glbDartBoardSizes.TripleRingOutsideEdge
                    ' Triple ring
                    ScoreToAdd.intMultiplier = 3
                Case glbDartBoardSizes.DoubleRingInsideEdge To glbDartBoardSizes.DoubleRingOutsideEdge
                    ' Double Ring
                    ScoreToAdd.intMultiplier = 2
                Case Else
                    If intDistance < glbDartBoardSizes.DoubleRingInsideEdge Then
                        ScoreToAdd.intMultiplier = 1
                    Else
                        ' Do not count it, not on dart board
                        ScoreToAdd.intMultiplier = 0
                    End If
            End Select

            Select Case intAngle
                Case 352 To 360, 0 To 9
                    ScoreToAdd.intValue = 20
                Case 10 To 27
                    ScoreToAdd.intValue = 1
                Case 28 To 45
                    ScoreToAdd.intValue = 18
                Case 46 To 63
                    ScoreToAdd.intValue = 4
                Case 64 To 81
                    ScoreToAdd.intValue = 13
                Case 82 To 99
                    ScoreToAdd.intValue = 6
                Case 100 To 117
                    ScoreToAdd.intValue = 10
                Case 118 To 135
                    ScoreToAdd.intValue = 15
                Case 136 To 153
                    ScoreToAdd.intValue = 2
                Case 154 To 171
                    ScoreToAdd.intValue = 17
                Case 172 To 189
                    ScoreToAdd.intValue = 3
                Case 190 To 207
                    ScoreToAdd.intValue = 19
                Case 208 To 225
                    ScoreToAdd.intValue = 7
                Case 226 To 243
                    ScoreToAdd.intValue = 16
                Case 244 To 261
                    ScoreToAdd.intValue = 8
                Case 262 To 279
                    ScoreToAdd.intValue = 11
                Case 280 To 297
                    ScoreToAdd.intValue = 14
                Case 298 To 315
                    ScoreToAdd.intValue = 9
                Case 316 To 333
                    ScoreToAdd.intValue = 12
                Case 334 To 351
                    ScoreToAdd.intValue = 5
                Case Else
                    ScoreToAdd.intValue = 0
            End Select
        End If

        If ScoreToAdd.intMultiplier = 0 Then
            ScoreToAdd.intValue = 0
        End If

        Return ScoreToAdd

    End Function

    Private Sub ShowHitDescription(ByVal intDartValue As Short, ByVal intDartMultiplier As Short, ByVal intDistance As Short)

        If frmCricket.GetGameType() = modDarts.gtGameTypeConstants.gtGolf Then
            ' Playing Golf
            With GetDartScoreLabel(mDartThrowCount - 1)
                .Text = CStr(ComputeGolfDartScore(CShort(frmCricket.lblCurrentHole.Text), intDartValue, intDartMultiplier, intDistance))
                .Visible = True
            End With

        Else
            With GetDartScoreLabel(mDartThrowCount - 1)
                If intDartMultiplier = 0 Then
                    .Text = "Miss"
                Else
                    .Text = String.Empty
                    Select Case intDartMultiplier
                        Case 2 : .Text = "Double "
                        Case 3 : .Text = "Triple "
                    End Select
                    If intDartValue = 25 Then
                        ' Bull
                        .Text = .Text & "Bull"
                    Else
                        .Text = .Text & intDartValue.ToString("#0")
                    End If

                End If
                .Visible = True
            End With

        End If
    End Sub

    Public Sub SmartAdvanceToNextTeam()

        ' Complete the turn (requiring three darts, or recording score if golf)
        CompleteTurn(frmCricket.GetGameType())

        ' Erase history of last three darts
        System.Array.Clear(mLastThreeDarts, 0, mLastThreeDarts.Length)
        System.Array.Clear(mLastThreeDartMultipliers, 0, mLastThreeDartMultipliers.Length)

        If frmCricket.CheckForGameOver(True) Then
            Exit Sub
        End If

        frmCricket.AdvanceToNextTeam(True)
    End Sub

    Public Sub PlaceDart(ByVal DartValue As Short, ByVal Multiplier As Short)
        Dim intNewDartDistance As Short

        If mDartThrowCount < 3 Then
            mDartThrowCount = mDartThrowCount + 1

            ' Record in mLastThreeDarts
            mLastThreeDarts(mDartThrowCount) = DartValue
            mLastThreeDartMultipliers(mDartThrowCount) = Multiplier

            intNewDartDistance = PositionDartShape(mDartThrowCount)
            ShowHitDescription(DartValue, Multiplier, intNewDartDistance)
            mDartClickTime = System.DateTime.Now
            mLastActionUndo = False
        End If

    End Sub

    Public Function PositionDartShape(ByVal intDartThrowNumber As Short) As Short
        ' Returns the dart distance

        Dim objDart As PictureBox

        Dim intNewDartAngle, intNewDartDistance As Short
        Dim intDeltaX, intWorkingAngle, intDeltaY As Short
        Dim intSwapLoc As Short

        Dim intDartValue As Short
        Dim intMultiplier As Short

        intDartValue = mLastThreeDarts(intDartThrowNumber)
        intMultiplier = mLastThreeDartMultipliers(intDartThrowNumber)

        objDart = GetDartPicture(intDartThrowNumber - 1)

        With objDart
            If intDartValue < 1 Or intMultiplier = 0 Then
                ' Missed Dart, place at upper right of picture
                .Left = Me.Width - 4 * .Width
                .Top = (10 * intDartThrowNumber + .Height) * 2 - 17
                .Visible = True
            Else
                If intDartValue = 25 Then
                    ' Bull - space evenly around bullseye
                    Select Case intDartThrowNumber
                        Case 1 : intNewDartAngle = 270
                        Case 3 : intNewDartAngle = 90
                        Case Else : intNewDartAngle = 0
                    End Select
                    If intMultiplier = 1 Then
                        intNewDartDistance = ComputeMidDistance(glbDartBoardSizes.SingleBullRing, glbDartBoardSizes.DoubleBullRing)
                    Else
                        intNewDartDistance = ComputeMidDistance(glbDartBoardSizes.DoubleBullRing, 0)
                    End If
                Else
                    ' Determine correct angle, then offset by intDartThrowNumber to avoid overlaps
                    intNewDartAngle = LookUpAngle(intDartValue)
                    Select Case intDartThrowNumber
                        Case 1 : intNewDartAngle = intNewDartAngle - 5
                        Case 3 : intNewDartAngle = intNewDartAngle + 5
                    End Select

                    With glbDartBoardSizes
                        ' Determine correct distance from center
                        Select Case intMultiplier
                            Case 2 : intNewDartDistance = ComputeMidDistance(.DoubleRingOutsideEdge, .DoubleRingInsideEdge)
                            Case 3 : intNewDartDistance = ComputeMidDistance(.TripleRingOutsideEdge, .TripleRingInsideEdge)
                            Case Else : intNewDartDistance = ComputeMidDistance(.DoubleRingInsideEdge, .TripleRingOutsideEdge)
                        End Select
                    End With
                End If

                ' Find the Working angle, an angle between 0 and 90 degrees that can
                ' be converted to radians
                intWorkingAngle = intNewDartAngle
                Do While intWorkingAngle >= 90
                    intWorkingAngle = intWorkingAngle - 90
                Loop

                ' Determine X-Y coordinate based on Angle and Distance from Center
                ' By keeping intWorkingAngle < 90 degrees, both intDeltaX and intDeltaY should
                '  always be positive
                intDeltaX = intNewDartDistance * System.Math.Sin(intWorkingAngle * 2 * Math.PI / 360)
                intDeltaY = intNewDartDistance * System.Math.Cos(intWorkingAngle * 2 * Math.PI / 360)

                ' Determine correct sin of intDeltaX and intDeltaY
                If intNewDartAngle < 90 Then
                    ' Quadrant 1, DeltaY is negative
                    intDeltaY = -intDeltaY
                ElseIf intNewDartAngle >= 180 And intNewDartAngle < 270 Then
                    ' Quadrant 3, DeltaX is negative
                    intDeltaX = -intDeltaX
                ElseIf intNewDartAngle >= 270 Then
                    ' Quadrant 4, swap intDeltaX and intDeltaY, and make both negative
                    intSwapLoc = intDeltaX
                    intDeltaX = intDeltaY
                    intDeltaY = intSwapLoc
                    intDeltaX = -intDeltaX
                    intDeltaY = -intDeltaY
                Else
                    ' Quadrant 2, swap intDeltaX and intDeltaY
                    intSwapLoc = intDeltaX
                    intDeltaX = intDeltaY
                    intDeltaY = intSwapLoc
                End If

                ' Place new dot at position given by Center + intDeltaX, Center + intDeltaY
                .Left = glbDartBoardSizes.CenterPoint.intX + intDeltaX - .Width / 2
                .Top = glbDartBoardSizes.CenterPoint.intY + intDeltaY - .Height / 2
                .Visible = True

            End If
        End With

        Return intNewDartDistance

    End Function

    Public Sub PositionControls(Optional ByVal blnResizeForm As Boolean = False)

        If blnResizeForm Then
            Me.Width = pctDartBoard.Width + 17
            Me.Height = pctDartBoard.Height + 73
        End If

        With pctDartBoard
            fraPreviousNext.Top = .Top + .Height + 12
            fraPreviousNext.Left = 8
            fraUndoRedo.Top = fraPreviousNext.Top
            fraUndoRedo.Left = .Left + .Width / 2 - fraUndoRedo.Width / 2 + 6
            cmdClose.Top = fraUndoRedo.Top
            cmdClose.Left = .Left + .Width - cmdClose.Width - 8
        End With

        With lblDirections
            .Height = 27
            .Width = 110
            If modDarts.glbDartBoardSizeVal = modDarts.bsBoardSizeConstants.bsSmall Then
                .Top = pctDartBoard.ClientRectangle.Height - .Height
            Else
                .Top = pctDartBoard.ClientRectangle.Height - .Height - 4
            End If

            .Left = pctDartBoard.ClientRectangle.Width - .Width - 4
        End With

        Dim objDartScoreLabel0 As Label
        objDartScoreLabel0 = GetDartScoreLabel(0)

        With objDartScoreLabel0
            Select Case modDarts.glbDartBoardSizeVal
                Case modDarts.bsBoardSizeConstants.bsSmall
                    .Font = UpdateFontSize(.Font, 12)
                Case modDarts.bsBoardSizeConstants.bsLarge
                    .Font = UpdateFontSize(.Font, 12)
                Case modDarts.bsBoardSizeConstants.bsHuge
                    .Font = UpdateFontSize(.Font, 12)
                Case Else
                    ' Includes .bsMedium
                    .Font = UpdateFontSize(.Font, 12)
            End Select

            .Left = 3
            .Top = pctDartBoard.ClientRectangle.Height - .Height * 3
        End With

        With GetDartScoreLabel(1)
            .Font = objDartScoreLabel0.Font
            .Height = objDartScoreLabel0.Height
            .Left = objDartScoreLabel0.Left
            .Top = objDartScoreLabel0.Top + objDartScoreLabel0.Height
        End With

        With GetDartScoreLabel(2)
            .Font = objDartScoreLabel0.Font
            .Height = objDartScoreLabel0.Height
            .Left = objDartScoreLabel0.Left
            .Top = objDartScoreLabel0.Top + objDartScoreLabel0.Height * 2
        End With

    End Sub

    Private Sub RedoThrow()
        frmCricket.RedoThrow()
    End Sub
   
    Public Sub RemoveMostRecentThrow()
        If mDartThrowCount > 0 Then
            GetDartPicture(mDartThrowCount - 1).Visible = False
            GetDartScoreLabel(mDartThrowCount - 1).Visible = False
            mDartThrowCount = mDartThrowCount - 1
            mLastActionUndo = True
        End If
    End Sub

    Public Sub SetLastActionUndo()
        mLastActionUndo = True
    End Sub

    Private Sub UndoThrow()
        frmCricket.UndoThrow()
    End Sub

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        Me.Hide()
    End Sub

    Private Sub cmdNextTeam_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNextTeam.Click
        SmartAdvanceToNextTeam()
    End Sub

    Private Sub cmdPreviousTeam_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPreviousTeam.Click
        frmCricket.SelectPreviousTeam()
    End Sub

    Private Sub cmdRedo_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRedo.Click
        RedoThrow()
    End Sub

    Private Sub cmdUndo_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUndo.Click
        UndoThrow()
    End Sub

    Private Sub frmDartBoard_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim intThisDart As Short

        For intThisDart = 0 To 2
            With GetDartPicture(intThisDart)
                '.Height = 13
                '.Width = 13
                .Visible = False
            End With
            GetDartScoreLabel(intThisDart).Visible = False
        Next intThisDart

        mDartClickTime = System.DateTime.Now.Subtract(New System.TimeSpan(0, 0, CLICK_KEEP_TIME * 2))
        mDartThrowCount = 0

        UpdateDartBoardSize()

    End Sub

    Private Sub frmDartBoard_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub pctDartBoard_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles pctDartBoard.MouseDown

        Dim ptCurrentLoc As usrXYLocation
        Dim intDistance, intAngle As Short
        Dim usrScoreToAdd As usrDartHitStats
        Dim intCurrentTeamIndex As Short

        ' Make sure game isn't over
        If frmCricket.CheckForGameOver(True) Then
            Exit Sub
        End If

        If frmCricket.GetGameType() = modDarts.gtGameTypeConstants.gtCricket Then
            ' Assure team throwing dart is not mathematically eliminated (if playing cricket)
            intCurrentTeamIndex = frmCricket.lstCurrentTeam.SelectedIndex
            If intCurrentTeamIndex >= 0 Then
                With frmCricket.lblWinStatus(intCurrentTeamIndex)
                    If .Visible And .Text = "Out" Then
                        Dim strMessage As String
                        strMessage = "Team " & (intCurrentTeamIndex + 1).ToString() & " has been mathematically eliminated.  Advancing to next team."
                        System.Windows.Forms.MessageBox.Show(strMessage, "Team is out", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        SmartAdvanceToNextTeam()
                        Exit Sub
                    End If
                End With
            End If
        End If

        If eventArgs.Button <> Windows.Forms.MouseButtons.Left Then
            ' User undoing a dart throw -- Click cmdUndo for user
            UndoThrow()
        Else
            ptCurrentLoc.intX = eventArgs.X
            ptCurrentLoc.intY = eventArgs.Y

            intDistance = FindDistance(glbDartBoardSizes.CenterPoint, ptCurrentLoc)

            intAngle = FindAngle(glbDartBoardSizes.CenterPoint, ptCurrentLoc)

            ' Lookup Score based on position
            usrScoreToAdd = LookUpScore(intDistance, intAngle)

            ''        lblScoreToAdd = "Score to add = " & usrScoreToAdd.intValue * usrScoreToAdd.intMultiplier

            If mDartThrowCount = 3 Then
                ' Automatically click the cmdUndo button before recording this dart
                UndoThrow()
            End If

            If mDartThrowCount < 3 Then
                mDartThrowCount = mDartThrowCount + 1
            End If

            With GetDartPicture(mDartThrowCount - 1)
                ' Draw a mark where the user clicked
                .Left = eventArgs.X - .Width / 2
                .Top = eventArgs.Y - .Width / 2
                .Visible = True
            End With

            ShowHitDescription(usrScoreToAdd.intValue, usrScoreToAdd.intMultiplier, intDistance)

            ' Record Hit
            frmCricket.RecordHit(usrScoreToAdd.intValue, usrScoreToAdd.intMultiplier, intDistance)

            ' Add dart to mLastThreeDarts
            mLastThreeDarts(mDartThrowCount) = usrScoreToAdd.intValue

            mDartClickTime = System.DateTime.Now
            mLastActionUndo = False
        End If

    End Sub

    Private Sub pctDartBoard_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles pctDartBoard.MouseMove

        Me.Cursor = System.Windows.Forms.Cursors.Cross

        If chkShowMousePos.Checked Then
            lblMouseCoord.Text = "Mouse Pos: " & eventArgs.X & ", " & eventArgs.Y
        End If
    End Sub

    Private Sub tmrShowDart_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrShowDart.Tick
        If mDartThrowCount >= 3 Then
            If Not mLastActionUndo AndAlso Not mCompletingTurn Then
                If System.DateTime.Now.Subtract(mDartClickTime).TotalSeconds >= 2 Then
                    ' Automatically click Next Team button, unless last event was an Undo Event
                    SmartAdvanceToNextTeam()
                End If
            End If
        End If
    End Sub

    Private Sub chkShowMousePos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowMousePos.CheckedChanged
        lblMouseCoord.Visible = chkShowMousePos.Checked
    End Sub
End Class
