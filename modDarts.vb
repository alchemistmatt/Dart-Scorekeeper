Option Strict Off
Option Explicit On

Imports System.Collections.Generic
Imports System.IO
Imports System.Reflection
Imports System.Threading 'Imports VB = Microsoft.VisualBasic

Module modDarts

    ' -------------------------------------------------------------------------------
    ' Dart Scorekeeper
    ' Written by Matthew Monroe in 1999
    ' Portions of this program are modeled after the Cricket LabView program by Kevin Lan
    '
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

    ' Revision History
    ' Version 1.0 completed 7/31/1999
    ' Version 2.0: started 4/22/2001 -- Added visual dart board for entering hits
    ' Version 2.1: started 5/8/2001 -- Added extended 301 stats
    ' Version 2.2: started 6/17/2001 -- Added game of Golf
    ' Version 2.3: started 10/1/2001 -- Added sound
    ' Version 2.32: started 10/30/2001 -- Added capability of looking for sounds in directories and choosing at random
    ' Version 2.4: started 1/25/2002 -- Added 180 sound for game of 301; Removed Microsoft Progress Bar control from frmProgress and replaced with simply two boxes
    ' Version 2.5: Updated a few things (not sure what)
    ' Version 2.6: Added option to play a sound file for any turn with a total score of 60 or higher
    ' Version 2.7: Extended sound playing option to look for a sound file for any score (user must enable option on options form)
    ' Version 2.8: Added option to use smaller score boxes so that 4 teams will fit on one monitor on a 12" laptop screen
    ' Version 2.9: Added mean score per throw per day extended stat and real-time mean score per throw
    ' Version 3.00: Now creating a new Stats_xxx.ini and StatsExtd_xxx.ini file for each month
    '              Fixed bug with computing mean score per throw per day
    ' Version 3.01, March 9, 2004 -- minor bug fixes
    ' Version 3.02, March 4, 2006 -- Released as open source software under the Apache License, Version 2.0
    ' Version 3.03, December 24, 2010 - Bug fix in AddScore when playing cut-throat cricket but high score wins
    ' Version 4.0, December 26, 2010 -- Ported to VB.NET
    ' Version 4.1, March 15, 2019 -- Updated to .NET 4.6.2


    ' ToDo: Get cutthroat scoring where higher score wins to work

#Region "Version Info"
    Public Const PROGRAM_DATE As String = "March 15, 2019"
    Public Const PROGRAM_VERSION As String = "4.1"
    Private mShowExceptionMessageBoxes As Boolean = False
#End Region

#Region "Constants and Enums"
    Public Const MAX_PLAYER_COUNT As Short = 150

    Public Const DISTANCE_BETWEEN_COLUMNS As Short = 88     ' Pixels
    Public Const MAX_TEAM_INDEX As Short = 5
    Public Const SHORT_TIME_DELAY As Short = 1      ' Seconds
    Public Const LONG_TIME_DELAY As Short = 5       ' Seconds
    Public Const CLICK_KEEP_TIME As Short = 5       ' Seconds
    Public Const MIN_GAME_LENGTH_THROWS_TO_COUNT As Short = 6
    Public Const MAX_TOTAL_HITS As Integer = 99999
    Public Const MAX_PARSELINE_COUNT As Short = 10
    Public Const DEFAULT_SCORE_FONT_SIZE As Short = 14

    ' Sound files
    Public Const SOUND_NEXT_PLAYER As String = "NextPlayer.Wav"

    Public Enum sasScoreAreaSizeConstants
        sasNormal = 0
        sasSmall = 1
    End Enum

    Public Enum bsBoardSizeConstants
        bsSmall = 0
        bsMedium = 1
        bsLarge = 2
        bsHuge = 3
    End Enum

    Public Enum gtGameTypeConstants
        gtUnknown = -1
        gtCricket = 0
        gt301 = 1
        gtGolf = 2
    End Enum

    Public Enum ctCutThroatModeConstants
        LowScoreWindows = 0
        HighScoreWindows = 1
    End Enum
#End Region

#Region "Structures"
    Public Structure HitStatsType
        Public TotalHits As Integer
        Public HitsBetweenRotate As Integer
        Public CurrentWinmauNumber As Short
        Public LastRotateHit As Integer
        Public RotateBoardClockwise As Boolean
    End Structure

    Public Structure usrXYLocation
        Public intX As Short
        Public intY As Short
    End Structure

    Public Structure udtDartBoardRadii

        ' Center point
        Public CenterPoint As usrXYLocation

        ' Distances from the center of the dart board to the given location, in pixels
        Public DoubleBullRing As Short
        Public SingleBullRing As Short
        Public TripleRingInsideEdge As Short
        Public TripleRingOutsideEdge As Short
        Public DoubleRingInsideEdge As Short
        Public DoubleRingOutsideEdge As Short
    End Structure
#End Region

#Region "Global Variables"
    Public StatsFileNameBase, IniFilePath, StatsExtendedFilenameBase As String

    Public glbPlayerCount As Integer
    Public glbPlayers() As String               ' 1-based array, with Player 1 at glbPlayers(1); We purposely have glbPlayers(0) = String.Empty

    Public glbHitAndRotateStats As HitStatsType
    Public glbBoolCutThroatCricket As Boolean
    Public glbCutThroatMode As ctCutThroatModeConstants
    Public glbDefault301StartScore As Short = 301
    Public glbBoolRequireDoubleIn As Boolean
    Public glbBoolRequireDoubleOut As Boolean
    Public glbScoreFontSize As Short
    Public glbBoolPlayWaveFileForPlayer As Boolean
    Public glbMinimumScoreToPlaySound As Short
    Public glbScoreAreaSizeVal As sasScoreAreaSizeConstants
    Public glbDartBoardSizeVal As bsBoardSizeConstants

    Public glbDartBoardSizes As udtDartBoardRadii
#End Region

    ' API Declares
    Private Declare Function sndPlaySound Lib "WINMM.DLL" Alias "sndPlaySoundA" (lpszSoundName As String, uFlags As Integer) As Integer

    Const SND_SYNC As Integer = &H0 'Use this flag to stop your app from continuing until the .WAV finishes playing.
    Const SND_ASYNC As Integer = &H1 'Use this flag to allow your app to continue processing while the .WAV is playing.
    Const SND_NODEFAULT As Integer = &H2 ' If the file is missing, Windows plays the default sound; Add this to the flags to prevent the default sound from playing
    Const SND_LOOP As Integer = &H8 ' Play the specified .Wav continuously.  Must be used with SND_ASYNC.  To stop playing, call sndPlaySound with 0& as the first argument
    Const SND_NOSTOP As Integer = &H10 ' Normally, if a .WAV is playing when another sndPlaySound call is made, the first .WAV stops immediately.  Add this to the flags to allow any playing .WAV to finish before the next one starts

    ' Size and Center Constants
    Public Const cWindowExactCenter As Short = 0
    Public Const cWindowUpperThird As Short = 1
    Public Const cWindowLowerThird As Short = 2
    Public Const cWindowMiddleLeft As Short = 3
    Public Const cWindowMiddleRight As Short = 4
    Public Const cWindowTopCenter As Short = 5
    Public Const cWindowBottomCenter As Short = 6
    Public Const cWindowBottomRight As Short = 7
    Public Const cWindowBottomLeft As Short = 8
    Public Const cWindowTopRight As Short = 9
    Public Const cWindowTopLeft As Short = 10

    Public Declare Function SetWindowPos Lib "user32" (hwnd As Integer, hWndInsertAfter As Integer, x As Integer, y As Integer, cx As Integer, cy As Integer, wFlags As Integer) As Integer

    ' Set some constant values (from WIN32API.TXT).
    Private Const conHwndTopmost As Short = -1
    Private Const conHwndNoTopmost As Short = -2
    Private Const conSwpNoActivate As Integer = &H10
    Private Const conSwpShowWindow As Integer = &H40

    Public Function BaseIndexValue(BoxIndex As Short, BoxesPerCol As Short) As Short
        ' Subtracts 7 (BoxesPerCol) until index is in range 0 to 6 (BoxesPerCol-1)

        Do While BoxIndex > BoxesPerCol - 1
            BoxIndex -= BoxesPerCol
        Loop

        Return BoxIndex

    End Function

    Public Sub UpdateDartBoardSize()
        Dim intIndex As Short

        SetDartboardDistances(glbDartBoardSizeVal)

        If glbDartBoardSizeVal >= bsBoardSizeConstants.bsSmall And glbDartBoardSizeVal <= bsBoardSizeConstants.bsHuge Then
            With frmDartBoard
                .pctDartBoard.BackgroundImageLayout = ImageLayout.None

                Select Case glbDartBoardSizeVal
                    Case 0
                        .pctDartBoard.BackgroundImage = .pctDartBoardSourcePicTiny.Image
                    Case 1
                        .pctDartBoard.BackgroundImage = .pctDartBoardSourcePicSmall.Image
                    Case 2
                        .pctDartBoard.BackgroundImage = .pctDartBoardSourcePicMedium.Image
                    Case 3
                        .pctDartBoard.BackgroundImage = .pctDartBoardSourcePicLarge.Image
                    Case Else
                        .pctDartBoard.BackgroundImage = .pctDartBoardSourcePicMedium.Image
                End Select

                .PositionControls(True)

                For intIndex = 1 To .DartThrowCount
                    .PositionDartShape(intIndex)
                Next intIndex
            End With
        End If

    End Sub

    Public Function UpdateFontSize(objFont As Font, NewSizePts As Short) As Font
        Return New Font(objFont.Name, NewSizePts, objFont.Style)
    End Function

    Public Function UpdateFontBold(objFont As Font, IsBold As Boolean) As Font
        If IsBold Then
            Return New Font(objFont.Name, objFont.Size, FontStyle.Bold)
        Else
            Return New Font(objFont.Name, objFont.Size, FontStyle.Regular)
        End If
    End Function

    Public Function DateLabelText(ByRef Color As Color) As String
        Dim strDate As String = String.Empty
        Dim strMessage As String = String.Empty

        Try

            strDate = DateTime.Now.ToString("dddd, MMMM d, yyyy")

            ' Check for special dates
            If DateS(strMessage, Color) Then
                strDate &= strMessage
            End If

        Catch ex As Exception
            HandleException("DateLabelText", ex)
        End Try

        Return strDate

    End Function

    Public Function CheckForZero(intValueToCheck As Short) As String
        ' Returns "" if intValueToCheck = 0
        If intValueToCheck = 0 Then
            Return String.Empty
        Else
            Return intValueToCheck.ToString.Trim
        End If
    End Function

    Public Function CheckForZeroSng(sngValueToCheck As Single) As String
        ' Returns "" if intValueToCheck = 0
        If Math.Abs(sngValueToCheck - 0) < 0.01 Then
            Return String.Empty
        Else
            Return sngValueToCheck.ToString.Trim
        End If
    End Function

    Public Function CheckForInfinity(intValueToCheck As Short) As String
        ' Returns the number as a string, unless it is 32767 or -32767,
        '  in which case it returns ""

        If intValueToCheck > Short.MinValue And intValueToCheck < Short.MaxValue Then
            Return intValueToCheck.ToString.Trim()
        Else
            Return String.Empty
        End If
    End Function

    Public Function CChkBox(ByRef chkThisCheckBox As CheckBox) As Boolean
        If chkThisCheckBox.Checked Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function ComputeGolfDartScore(intTargetHole As Short,
                                         intDartValue As Short,
                                         intMultiplier As Short,
                                         intDistanceFromCenter As Short) As Short

        ' Return -2 for the Triple ring
        '        -1 for the Double ring
        '         0 for the inner triangle (between Bull and Triple ring)
        '         1 for the outer rectangle (between Triple ring and Double ring)
        '         2 for anything else

        Dim intReturnVal As Short

        If intDartValue <> intTargetHole Then
            ' Miss
            intReturnVal = 2
        Else
            Select Case intMultiplier
                Case 1
                    ' Determine if outer or inner region
                    Select Case intDistanceFromCenter
                        Case glbDartBoardSizes.SingleBullRing To glbDartBoardSizes.TripleRingInsideEdge
                            ' Between bull and Triple ring
                            intReturnVal = 0
                        Case glbDartBoardSizes.TripleRingOutsideEdge To glbDartBoardSizes.DoubleRingInsideEdge
                            ' Between Triple ring and Double Ring
                            intReturnVal = 1
                        Case Else
                            intReturnVal = 2
                    End Select
                Case 2
                    intReturnVal = -1
                Case 3
                    intReturnVal = -2
                Case Else ' Includes 0
                    intReturnVal = 2
            End Select
        End If

        Return intReturnVal

    End Function

    Public Function ComputeMidDistance(lngDistance1 As Integer, lngDistance2 As Integer) As Integer

        ComputeMidDistance = (lngDistance1 + lngDistance2) / 2

    End Function

    Private Function DateDayC(currDay As Short) As Short
        DateDayC = Math.Floor((currDay - 1) / 7) + 1
    End Function

    Private Function DateS(ByRef message As String,
                           ByRef Color As Color,
                           Optional ByVal blnOverrideDate As Boolean = False,
                           Optional ByVal DateOverride As String = "") As Boolean

        ' This function contains coded messages that are displayed on certain dates of the year
        ' It returns True if a special date is found


        Dim dd, mm, y, intWeekDay As Short
        Dim dtDate As DateTime

        Try
            If blnOverrideDate Then
                dtDate = CDate(DateOverride)
            Else
                dtDate = DateTime.Now
            End If

            mm = dtDate.Month
            dd = dtDate.Day
            y = dtDate.Year
            intWeekDay = dtDate.DayOfWeek

            If mm = NumC(2) AndAlso dd = NumC(2) Then
                message = MsgC("072097112112121032078101119032089101097114")
                Color = Color.White
                Return True
            End If

            If mm = NumC(7) AndAlso dd = NumC(67) Then
                message = MsgC("087097116099104032111117116032102111114032067117112105100039115032065114114111119")
                Color = Color.Red
                Return True
            End If

            If mm = NumC(12) AndAlso dd = NumC(82) Then
                message = MsgC("065114101032121111117032119101097114105110103032103114101101110063")
                Color = Color.Lime
                Return True
            End If

            If mm = NumC(17) AndAlso dd = NumC(2) Then
                message = MsgC("089111117114032115104111101108097099101115032097114101032117110116105101100033")
                Color = Color.Cyan
                Return True
            End If

            If mm = NumC(32) AndAlso dd = NumC(17) Then
                message = MsgC("069110106111121032116104101032070105114101119111114107115")
                Color = Color.Blue
                Return True
            End If

            If mm = NumC(52) And intWeekDay = 5 And DateDayC(dd) = 4 Then
                message = MsgC("072097112112121032084117114107101121032068097121")
                Color = Color.Magenta
                Return True
            End If

            If mm = NumC(57) AndAlso dd = NumC(122) Then
                message = MsgC("077101114114121032067104114105115116109097115")
                Color = Color.Lime
                Return True
            End If

            Dim EM, e, b, d, q, ED As Short
            b = 225 - 11 * (y Mod 19)
            d = ((b - 21) Mod 30) + 21
            If d > 48 Then d = d - 1
            e = (y + (y / 4) + d + 1) Mod 7
            q = d + 7 - e
            If q < 32 Then
                EM = 3
                ED = q
            Else
                EM = 4
                ED = q - 31
            End If

            If mm = EM AndAlso dd = ED Then
                ' (valid only 1900-2100)
                message = MsgC("072097112112121032069097115116101114")
                Color = Color.Yellow
                Return True
            End If

        Catch ex As Exception
            ' Ignore errors here
        End Try

        Return False
    End Function

    Public Sub CheckDates()
        ' Cycles through a range of dates and displays the special date messages in the debug window

        Dim dtDate As DateTime

        Dim strDate As String
        Dim strMessage As String = String.Empty

        Dim Color As Color

        Try
            dtDate = #1/1/2009#

            Do While dtDate < #1/1/2011#
                strDate = dtDate.ToString("yyyy-MM-dd")

                If DateS(strMessage, Color, True, strDate) Then
                    Console.WriteLine(strDate & ": " & strMessage)
                End If

                dtDate = dtDate.AddDays(1)
            Loop

        Catch ex As Exception
            HandleException("CheckDates", ex)
        End Try

    End Sub

    Public Function FindAngle(ByRef Point1 As usrXYLocation, ByRef Point2 As usrXYLocation) As Single
        Dim intDeltaX, intDeltaY As Short
        Dim sngAngle As Single
        Dim intQuadrant As Short

        intDeltaX = Point2.intX - Point1.intX
        intDeltaY = Point2.intY - Point1.intY

        ' Angle (theta) between two points is found using:
        '  Tangent(Theta) = Side2 / Side1
        '  Theta = ArcTangent (Side2 / Side1)

        ' Figure out which quadrant we're in (classic X-Y quadrants, I, II, III, and IV going
        '  counterclockwise around an X-Y grid:             |
        '                                                IV | I
        '                                               --------
        '                                               III | II
        '                                                   |
        If intDeltaX >= 0 And intDeltaY < 0 Then
            intQuadrant = 1
        ElseIf intDeltaX >= 0 And intDeltaY >= 0 Then
            intQuadrant = 2
        ElseIf intDeltaX < 0 And intDeltaY >= 0 Then
            intQuadrant = 3
        Else
            intQuadrant = 4
        End If

        intDeltaX = Math.Abs(intDeltaX)
        intDeltaY = Math.Abs(intDeltaY)

        If intDeltaY <> 0 Then
            sngAngle = Math.Atan(intDeltaX / intDeltaY)
            ' Convert from Radians to degrees
            sngAngle = sngAngle * 360 / (2 * Math.PI)
        Else
            sngAngle = 90
        End If

        ' Convert to 360 degreen system since sngAngle will always be between 0 and 90 degrees
        Select Case intQuadrant
            Case 1
                ' Do nothing
            Case 2
                sngAngle = 180 - sngAngle
            Case 3
                sngAngle = 180 + sngAngle
            Case Else
                ' Includes case 4
                sngAngle = 360 - sngAngle
        End Select

        FindAngle = sngAngle
    End Function

    Public Function FindDistance(ByRef Point1 As usrXYLocation, ByRef Point2 As usrXYLocation) As Single
        Dim intDeltaX, intDeltaY As Short

        intDeltaX = Point1.intX - Point2.intX
        intDeltaY = Point1.intY - Point2.intY

        ' Distance between points is found using Pythagorean's theorem:
        '  Hypotenuse^2 = Side1^2 + Side2^2
        '  Hypotenuse = Square Root(Side1^2 + Side2^2)
        FindDistance = Math.Sqrt(intDeltaX ^ 2 + intDeltaY ^ 2)

    End Function

    Public Function GetAppDataFolderPath() As String
        Return GetAppDataFolderPath("DartScoreKeeper")
    End Function

    Public Function GetAppDataFolderPath(strAppName As String) As String
        Dim strAppDataFolder As String

        If String.IsNullOrEmpty(strAppName) Then
            strAppName = String.Empty
        End If

        Try
            strAppDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), strAppName)
            If Not Directory.Exists(strAppDataFolder) Then
                Directory.CreateDirectory(strAppDataFolder)
            End If

        Catch ex As Exception
            ' Error creating the folder, revert to using the system Temp folder
            strAppDataFolder = Path.GetTempPath()
        End Try

        Return strAppDataFolder

    End Function

    Public Function GetAppFolderPath() As String
        ' Could use Application.StartupPath, but .GetExecutingAssembly is better
        Return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
    End Function

    Public Function GetComboBoxItemText(cboComboBox As ComboBox) As String

        Try
            If cboComboBox.SelectedIndex >= 0 Then
                Return cboComboBox.SelectedItem.ToString
            Else
                Return String.Empty
            End If
        Catch ex As Exception
            Console.WriteLine("Error looking up selected item for " & cboComboBox.Name)
            Return String.Empty
        End Try

    End Function

    Public Sub HandleException(strCallingFunction As String, ex As Exception)
        Console.WriteLine()
        Console.WriteLine("-------------------------------------------------------------")
        Console.WriteLine("Error in " & strCallingFunction & ": " & ex.Message)
        Console.WriteLine("-------------------------------------------------------------")

        If mShowExceptionMessageBoxes Then
            MessageBox.Show("Error in " & strCallingFunction & ": " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

    End Sub

    Public Function LookUpAngle(intScore As Short) As Short
        Dim intCentralAngle As Short

        Select Case intScore
            Case 20 : intCentralAngle = 0
            Case 1 : intCentralAngle = 18
            Case 18 : intCentralAngle = 36
            Case 4 : intCentralAngle = 54
            Case 13 : intCentralAngle = 72
            Case 6 : intCentralAngle = 90
            Case 10 : intCentralAngle = 108
            Case 15 : intCentralAngle = 126
            Case 2 : intCentralAngle = 144
            Case 17 : intCentralAngle = 162
            Case 3 : intCentralAngle = 180
            Case 19 : intCentralAngle = 198
            Case 7 : intCentralAngle = 216
            Case 16 : intCentralAngle = 234
            Case 8 : intCentralAngle = 252
            Case 11 : intCentralAngle = 270
            Case 14 : intCentralAngle = 288
            Case 9 : intCentralAngle = 306
            Case 12 : intCentralAngle = 324
            Case 5 : intCentralAngle = 342
            Case Else : intCentralAngle = 0 ' Includes bull (25 points)
        End Select

        LookUpAngle = intCentralAngle

    End Function

    Public Function LookupGameTypeByString(strGameName As String) As gtGameTypeConstants

        Select Case strGameName.ToLower()
            Case "301"
                Return gtGameTypeConstants.gt301
            Case "cricket"
                Return gtGameTypeConstants.gtCricket
            Case "golf"
                Return gtGameTypeConstants.gtGolf
            Case Else
                ' Unknown mode
                Return gtGameTypeConstants.gtUnknown
        End Select
    End Function

    Public Function LookupGameStringByType(eGameType As gtGameTypeConstants) As String
        Select Case eGameType
            Case gtGameTypeConstants.gt301
                Return "301"
            Case gtGameTypeConstants.gtCricket
                Return "Cricket"
            Case gtGameTypeConstants.gtGolf
                Return "Golf"
            Case gtGameTypeConstants.gtUnknown
                Return "Unknown game type"
            Case Else
                Return "Invalid game type"
        End Select
    End Function

    Public Function MaxVal(intFirstVal As Short, intSecondVal As Short, intThirdVal As Short) As Short
        Return Math.Max(Math.Max(intFirstVal, intSecondVal), intThirdVal)
    End Function

    Public Function MinVal(intFirstVal As Short, intSecondVal As Short, intThirdVal As Short, boolAllowZero As Boolean) As Short
        Dim intMinValue As Short

        intMinValue = Short.MaxValue
        If intFirstVal < intMinValue Then
            If boolAllowZero Or (Not boolAllowZero And intFirstVal > 0) Then
                intMinValue = intFirstVal
            End If
        End If

        If intSecondVal < intMinValue Then
            If boolAllowZero Or (Not boolAllowZero And intSecondVal > 0) Then
                intMinValue = intSecondVal
            End If
        End If

        If intThirdVal < intMinValue Then
            If boolAllowZero Or (Not boolAllowZero And intThirdVal > 0) Then
                intMinValue = intThirdVal
            End If
        End If

        If intMinValue = Short.MaxValue Then intMinValue = 0
        Return intMinValue

    End Function

    Public Function MinutesToTimeString(dblTotalMinutes As Double) As String

        Return CInt(Math.Floor(dblTotalMinutes)).ToString() & ":" &
                    Math.Round((dblTotalMinutes - Math.Floor(dblTotalMinutes)) * 60, 0).ToString("00")

    End Function

    Private Function MsgC(s As String) As String
        ' This function is used to decode coded messages that are displayed on special dates

        Dim x, a As Short
        Dim b As String
        Dim n As String = String.Empty
        Dim w As String

        Try
            If IsNumeric(s) Then
                n = Space(5)
                For x = 1 To Len(s) Step 3
                    w = Mid(s, x, 3)
                    n &= Chr(Val(w))
                Next x
            Else
                For x = 1 To Len(s)
                    a = Asc(Mid(s, x, 1))
                    b = a.ToString.Trim
                    Do While Len(b) < 3
                        b = "0" & b
                    Loop
                    n &= b
                Next x
            End If

        Catch ex As Exception
            ' Ignore errors here
        End Try

        Return n

    End Function

    Private Function NumC(v As Short) As Short
        NumC = (v + 3) / 5
    End Function

    ''' <summary>
    ''' Plays appropriate sound for player
    ''' </summary>
    ''' <param name="strPlayerName"></param>
    ''' <param name="boolPlayDefaultSoundIfCustomNotFound"></param>
    ''' <param name="boolWaitForSoundFileToEnd"></param>
    ''' <returns>True if a sound file was successfully found and played (even if it is just the default sound file)</returns>
    Public Function PlayWaveFileForPlayer(strPlayerName As String,
                                          Optional ByVal boolPlayDefaultSoundIfCustomNotFound As Boolean = True,
                                          Optional ByVal boolWaitForSoundFileToEnd As Boolean = True) As Boolean

        Static objRandom As New Random()

        Try

            Const MAX_SOUND_FILE_COUNT As Short = 100
            Dim diSoundFolder As DirectoryInfo
            Dim diSoundFile As FileInfo

            Dim strSoundFilePaths As New List(Of String)
            Dim strFilePathMatch As String

            If String.IsNullOrEmpty(strPlayerName) Then
                ' Look for and play (if found) the default next player sound
                WaveFilePlay(String.Empty, False, boolWaitForSoundFileToEnd)
            End If

            ' First look for folder matching strPlayerName
            diSoundFolder = New DirectoryInfo(Path.Combine(GetAppFolderPath, strPlayerName.Trim()))

            If diSoundFolder.Exists Then
                ' Folder found with name of player and containing .Wav files
                ' Get list of all .Wav files in folder

                For Each diSoundFile In diSoundFolder.GetFiles("*.wav")
                    strSoundFilePaths.Add(diSoundFile.FullName)
                    If strSoundFilePaths.Count >= MAX_SOUND_FILE_COUNT Then Exit For
                Next

                ' Pick a random file
                Dim intIndexToUse As Integer
                intIndexToUse = objRandom.Next(0, strSoundFilePaths.Count - 1)
                strFilePathMatch = strSoundFilePaths.Item(intIndexToUse)
            Else
                ' Player folder not found, now look for file with name strPlayerName
                strFilePathMatch = Path.Combine(GetAppFolderPath, strPlayerName.Trim() & ".wav")

                If Not File.Exists(strFilePathMatch) Then
                    strFilePathMatch = String.Empty
                End If
            End If


            If strFilePathMatch.Length = 0 Then
                ' Call WaveFilePlay with no arguments so that default file is played
                If boolPlayDefaultSoundIfCustomNotFound Then
                    Return WaveFilePlay(String.Empty, False, boolWaitForSoundFileToEnd)
                End If
            Else
                Return WaveFilePlay(strFilePathMatch, False, boolWaitForSoundFileToEnd)
            End If

        Catch ex As Exception
            HandleException("PlayWaveFileForPlayer", ex)
        End Try

        Return False

    End Function

    Public Sub ReserveMemoryForGlobalArrays()

        ReDim glbPlayers(MAX_PLAYER_COUNT)

    End Sub

    Public Sub SetDartboardDistances(eBoardSize As bsBoardSizeConstants)

        Dim sngDiameterMultiplier As Single

        Select Case eBoardSize
            Case bsBoardSizeConstants.bsSmall
                sngDiameterMultiplier = 0.75
            Case bsBoardSizeConstants.bsMedium
                sngDiameterMultiplier = 1
            Case bsBoardSizeConstants.bsLarge
                sngDiameterMultiplier = 1.25
            Case Else
                ' Includes bsBoardSizeConstants.bsHuge
                sngDiameterMultiplier = 1.5
        End Select

        With glbDartBoardSizes
            .CenterPoint.intX = 291 * sngDiameterMultiplier
            .CenterPoint.intY = 291 * sngDiameterMultiplier

            .DoubleBullRing = 9 * sngDiameterMultiplier
            .SingleBullRing = 22 * sngDiameterMultiplier
            .TripleRingInsideEdge = 120 * sngDiameterMultiplier
            .TripleRingOutsideEdge = 136 * sngDiameterMultiplier
            .DoubleRingInsideEdge = 192 * sngDiameterMultiplier
            .DoubleRingOutsideEdge = 218 * sngDiameterMultiplier
        End With

    End Sub

    Public Sub SizeAndCenterWindow(ByRef frmThisForm As Form,
                                   Optional ByVal intCenterMode As Short = 0,
                                   Optional ByVal lngWindowWidth As Integer = -1,
                                   Optional ByVal lngWindowHeight As Integer = -1,
                                   Optional ByVal boolSizeAndCenterOnlyOncePerProgramSession As Boolean = True,
                                   Optional ByVal intDualMonitorToUse As Short = -1)

        ' Sub revision 1.23

        ' Center Mode uses one of the following:
        '    Public Const cWindowExactCenter = 0
        '    Public Const cWindowUpperThird = 1
        '    Public Const cWindowLowerThird = 2
        '    Public Const cWindowMiddleLeft = 3
        '    Public Const cWindowMiddleRight = 4
        '    Public Const cWindowTopCenter = 5
        '    Public Const cWindowBottomCenter = 6
        '    Public Const cWindowBottomRight = 7
        '    Public Const cWindowBottomLeft = 8
        '    Public Const cWindowTopRight = 9
        '    Public Const cWindowTopLeft = 10

        ' This sub routine properly recognizes dual monitors, centering the form to just one monitor

        ' lngWindowWidth and lngWindowHeight are in pixels (there are 15 twips in one pixel)
        ' intDualMonitorToUse can be 0 or 1, signifying the first or second monitor
        ' boolSizeAndCenterOnlyOncePerProgramSession is useful when the SizeAndCenterWindow sub is called from the Form_Activate sub of a form
        '  Note: It is suggested that this be set to false if called from Form_Load in case the user closes the form (thus unloading it)

        Static strFormsCentered As New List(Of String)

        Dim lngWindowAreaWidth, lngWindowAreaHeight As Integer
        Dim dblAspectRatio As Double
        Dim lngWorkingAreaWidth, lngWorkingAreaHeight As Integer
        Dim boolDualMonitor, boolHorizontalDual As Boolean
        Dim lngWindowTopToSet, lngWindowLeftToSet As Integer
        Dim frmMainAppForm As Form
        Dim boolSubCalledPreviously As Boolean

        ' See if the form has already called this sub
        ' If not, add to strFormsCentered()
        boolSubCalledPreviously = strFormsCentered.Contains(frmThisForm.Name)

        If Not boolSubCalledPreviously Then
            ' First time sub called this sub
            ' Add to strFormsCentered()
            strFormsCentered.Add(frmThisForm.Name)
        End If

        ' If form called previously and boolSizeAndCenterOnlyOncePerProgramSessionis true, then exit sub
        If boolSizeAndCenterOnlyOncePerProgramSession And boolSubCalledPreviously Then
            Exit Sub
        End If

        ' Resize Window
        With frmThisForm
            .WindowState = FormWindowState.Normal
            If lngWindowWidth > 0 Then .Width = lngWindowWidth
            If lngWindowHeight > 0 Then .Height = lngWindowHeight
        End With

        ' Assume the first form loaded is the main form
        ' May need to be customized if ported to other applications
        frmMainAppForm = My.Application.OpenForms.Item(0)

        ' Find the desktop area (width and height)
        lngWindowAreaWidth = Screen.PrimaryScreen.Bounds.Width
        lngWindowAreaHeight = Screen.PrimaryScreen.Bounds.Height

        ' Check the aspect ratio of WindowAreaWidth / WindowAreaHeight
        If lngWindowAreaHeight > 0 Then
            dblAspectRatio = lngWindowAreaWidth / lngWindowAreaHeight
        Else
            dblAspectRatio = 1.333
        End If

        ' Typical desktop areas and aspect ratios
        ' Normal Desktops have aspect ratios of 1.33 or 1.5
        ' HDTV desktops have an aspect ratio of 1.6 or 1.7
        ' Horizontal Dual Monitors have an aspect ratio of 2.66 or 2.5
        ' Vertical Dual Monitors have an aspect ratio of 0.67 or 0.62

        ' Determine if using dual monitors
        If dblAspectRatio < 1 Or dblAspectRatio > 2 Then
            boolDualMonitor = True
            If dblAspectRatio > 2 Then
                ' Aspect ratio greater than 2 - using horizontal dual monitors
                boolHorizontalDual = True
                lngWorkingAreaWidth = Screen.PrimaryScreen.Bounds.Width / 2
                lngWorkingAreaHeight = Screen.PrimaryScreen.Bounds.Height

                If frmMainAppForm.Left > lngWorkingAreaWidth Then
                    ' Main app window on second monitor
                    ' Set intDualMonitorToUse if not explicitly set
                    If intDualMonitorToUse < 0 Then
                        intDualMonitorToUse = 1
                    End If
                End If
            Else
                ' Aspect ratio must be less than 1 - using vertical dual monitors
                boolHorizontalDual = False
                lngWorkingAreaWidth = Screen.PrimaryScreen.Bounds.Width
                lngWorkingAreaHeight = Screen.PrimaryScreen.Bounds.Height / 2

                If frmMainAppForm.Top > lngWorkingAreaHeight Then
                    ' Main app window on second monitor
                    ' Set intDualMonitorToUse if not explicitly set
                    If intDualMonitorToUse < 0 Then
                        intDualMonitorToUse = 1
                    End If
                End If
            End If
        Else
            ' Aspect ratio between 1 and 2
            ' Using a single monitor
            boolDualMonitor = False
            lngWorkingAreaWidth = Screen.PrimaryScreen.Bounds.Width
            lngWorkingAreaHeight = Screen.PrimaryScreen.Bounds.Height
        End If

        With frmThisForm
            ' Position window
            Select Case intCenterMode
                Case cWindowUpperThird
                    lngWindowLeftToSet = (lngWorkingAreaWidth - .Width) \ 2
                    lngWindowTopToSet = (lngWorkingAreaHeight - .Height) \ 3
                Case cWindowLowerThird
                    lngWindowLeftToSet = (lngWorkingAreaWidth - .Width) \ 2
                    lngWindowTopToSet = (lngWorkingAreaHeight - .Height) * 2 \ 3
                Case cWindowMiddleLeft
                    lngWindowLeftToSet = 0
                    lngWindowTopToSet = (lngWorkingAreaHeight - .Height) \ 2
                Case cWindowMiddleRight
                    lngWindowLeftToSet = lngWorkingAreaWidth - .Width
                    lngWindowTopToSet = (lngWorkingAreaHeight - .Height) \ 2
                Case cWindowTopCenter
                    lngWindowLeftToSet = (lngWorkingAreaWidth - .Width) \ 2
                    lngWindowTopToSet = 0
                Case cWindowBottomCenter
                    lngWindowLeftToSet = (lngWorkingAreaWidth - .Width) \ 2
                    lngWindowTopToSet = lngWorkingAreaHeight - .Height - 500
                Case cWindowBottomRight
                    lngWindowLeftToSet = lngWorkingAreaWidth - .Width
                    lngWindowTopToSet = lngWorkingAreaHeight - .Height - 500
                Case cWindowBottomLeft
                    lngWindowLeftToSet = 0
                    lngWindowTopToSet = lngWorkingAreaHeight - .Height - 500
                Case cWindowTopRight
                    lngWindowLeftToSet = lngWorkingAreaWidth - .Width
                    lngWindowTopToSet = 0
                Case cWindowTopLeft
                    lngWindowLeftToSet = 0
                    lngWindowTopToSet = 0
                Case Else ' Includes cWindowExactCenter = 0
                    lngWindowLeftToSet = (lngWorkingAreaWidth - .Width) \ 2
                    lngWindowTopToSet = (lngWorkingAreaHeight - .Height) \ 2
            End Select

            ' Move to second monitor if explicitly stated or if the main MwtWin window is already on the second monitor
            If boolDualMonitor And intDualMonitorToUse > 0 Then
                ' Place window on second monitor
                If boolHorizontalDual Then
                    ' Horizontal dual - Shift to the right
                    lngWindowLeftToSet = lngWindowLeftToSet + lngWorkingAreaWidth
                Else
                    ' Vertical dual - Shift down
                    lngWindowTopToSet = lngWindowTopToSet + lngWorkingAreaHeight
                End If
            End If

            ' Actually position the window
            .SetBounds(lngWindowLeftToSet, lngWindowTopToSet, 0, 0, BoundsSpecified.X Or BoundsSpecified.Y)
        End With

    End Sub

    Public Function SortCompare(blnSortReverse As Boolean, Item1 As String, Item2 As String, NumericCompare As Boolean) As Boolean
        Dim SwapThem As Boolean
        Dim UseItem1, UseItem2 As String
        Dim x As Short

        Dim blnItem1IsNumeric, blnItem2IsNumeric As Boolean
        Dim dblItem1, dblItem2 As Double

        Try
            SwapThem = False
            If NumericCompare Then
                UseItem1 = Item1
                UseItem2 = Item2

                x = UseItem1.IndexOf("/"c)
                If x > 0 Then
                    ' Old Code from VB6:
                    ' x = InStr(UseItem1, "/")
                    ' UseItem1 = Trim(Left(UseItem1, x - 1))
                    UseItem1 = UseItem1.Substring(0, x).Trim()
                End If

                x = UseItem2.IndexOf("/"c)
                If x > 0 Then
                    ' Old Code from VB6:
                    ' x = InStr(UseItem2, "/")
                    ' UseItem2 = Trim(Left(UseItem2, x - 1))
                    UseItem2 = UseItem2.Substring(0, x).Trim()
                End If

                If Double.TryParse(UseItem1, dblItem1) Then
                    blnItem1IsNumeric = True
                End If

                If Double.TryParse(UseItem2, dblItem2) Then
                    blnItem2IsNumeric = True
                End If

                If Not blnItem1IsNumeric AndAlso Not blnItem2IsNumeric Then
                    SwapThem = False

                ElseIf Not blnItem1IsNumeric Then
                    If Not blnSortReverse Then SwapThem = True

                ElseIf Not blnItem2IsNumeric Then
                    If blnSortReverse Then SwapThem = True
                Else
                    ' Numeric compare
                    If Not blnSortReverse Then
                        If dblItem1 < dblItem2 Then SwapThem = True
                    Else
                        If dblItem1 > dblItem2 Then SwapThem = True
                    End If
                End If
            Else
                ' Text compare
                If blnSortReverse Then
                    If Item1 < Item2 Then SwapThem = True
                Else
                    If Item1 > Item2 Then SwapThem = True
                End If
            End If
        Catch ex As Exception
            HandleException("SortCompare", ex)
        End Try

        Return SwapThem

    End Function

    Public Sub TextBoxKeyPressHandlerCheckControlChars(ByRef txtThisTextBox As TextBox, ByRef e As KeyPressEventArgs, Optional ByVal AllowCutCopyPaste As Boolean = True)
        If Char.IsControl(e.KeyChar) Then
            Select Case Convert.ToInt32(e.KeyChar)
                Case 1
                    ' Ctrl+A -- Highlight entire text box
                    txtThisTextBox.SelectionStart = 0
                    txtThisTextBox.SelectionLength = txtThisTextBox.TextLength
                    e.Handled = True
                Case 24, 3, 22
                    ' Ctrl+X, Ctrl+C, Ctrl+V
                    ' Cut, copy, or paste, was pressed; possibly suppress
                    If Not AllowCutCopyPaste Then e.Handled = True
                Case 26
                    ' Ctrl+Z = Undo; allow VB.NET to handle this
                Case 8
                    ' Backspace is allowed
                Case Else
                    ' Ignore it
                    e.Handled = True
            End Select
        End If
    End Sub

    Public Sub TextBoxKeyPressHandler(ByRef txtThisTextBox As TextBox, ByRef e As KeyPressEventArgs, Optional ByVal AllowNumbers As Boolean = True, Optional ByVal AllowDecimalPoint As Boolean = False, Optional ByVal AllowNegativeSign As Boolean = False, Optional ByVal AllowCharacters As Boolean = False, Optional ByVal AllowPlusSign As Boolean = False, Optional ByVal AllowUnderscore As Boolean = False, Optional ByVal AllowDollarSign As Boolean = False, Optional ByVal AllowEmailChars As Boolean = False, Optional ByVal AllowSpaces As Boolean = False, Optional ByVal AllowECharacter As Boolean = False, Optional ByVal AllowCutCopyPaste As Boolean = True, Optional ByVal AllowDateSeparatorChars As Boolean = False)
        ' Checks e.KeyChar to see if it's valid
        ' If it isn't, e.Handled is set to True to ignore it

        If Char.IsDigit(e.KeyChar) Then
            If Not AllowNumbers Then e.Handled = True
        ElseIf Char.IsLetter(e.KeyChar) Then
            If Not AllowCharacters Then
                If AllowECharacter AndAlso Char.ToLower(e.KeyChar) = "e"c Then
                    ' Allow character
                Else
                    ' Ignore character
                    e.Handled = True
                End If
            End If
        ElseIf Char.IsControl(e.KeyChar) Then
            TextBoxKeyPressHandlerCheckControlChars(txtThisTextBox, e, AllowCutCopyPaste)
        ElseIf e.KeyChar = " "c Then
            If Not AllowSpaces Then e.Handled = True
        ElseIf e.KeyChar = "_"c Then
            If Not AllowUnderscore Then e.Handled = True
        ElseIf e.KeyChar = "$"c Then
            If Not AllowDollarSign Then e.Handled = True
        ElseIf e.KeyChar = "+"c Then
            If Not AllowPlusSign Then e.Handled = True
        ElseIf e.KeyChar = "-"c Then
            If Not AllowNegativeSign Then e.Handled = True
        ElseIf e.KeyChar = "@"c Then
            If Not AllowEmailChars Then e.Handled = True
        ElseIf e.KeyChar = "."c Then
            If Not AllowDecimalPoint Then e.Handled = True
        ElseIf e.KeyChar = "-"c Then
            If Not (AllowNegativeSign Or AllowDateSeparatorChars) Then e.Handled = True
        ElseIf e.KeyChar = "/" Then
            If Not AllowDateSeparatorChars Then e.Handled = True
        Else
            ' Ignore the key
            e.Handled = True
        End If
    End Sub

    Public Sub TextBoxGotFocusHandler(ByRef txtThisTextBox As TextBox, Optional ByVal blnSelectAll As Boolean = True)
        ' Selects the text in the given textbox if blnSelectAll = true

        If blnSelectAll Then
            txtThisTextBox.SelectionStart = 0
            txtThisTextBox.SelectionLength = Len(txtThisTextBox.Text)
        End If

    End Sub

    Public Sub Wait()
        Wait(250)
    End Sub

    Public Sub Wait(Milliseconds As Integer)
        ' Wait the specified number of milliseconds

        Const THREAD_SLEEP_INTERVAL_MSEC As Short = 10

        Dim dtStart = DateTime.UtcNow

        Do
            Thread.Sleep(THREAD_SLEEP_INTERVAL_MSEC)
            Application.DoEvents()
        Loop While DateTime.UtcNow.Subtract(dtStart).TotalMilliseconds < Milliseconds

    End Sub

    Public Sub WaveFileStop()

        sndPlaySound(CStr(0), SND_NODEFAULT)

    End Sub

    Public Function WaveFilePlay(Optional ByVal strSoundFilePath As String = "",
                                 Optional ByVal boolPlayDefaultSoundIfWaveNotFound As Boolean = False,
                                 Optional ByVal boolWaitForCompletion As Boolean = True,
                                 Optional ByVal boolLoop As Boolean = False) As Boolean

        ' Returns True if wave file successfully played

        Dim blnPlaySound As Boolean = False

        Dim lngReturnValue As Integer
        Dim wFlags As Short

        If String.IsNullOrEmpty(strSoundFilePath) Then

            strSoundFilePath = Path.Combine(GetAppFolderPath(), SOUND_NEXT_PLAYER)
        End If

        If Not File.Exists(strSoundFilePath) Then
            ' Uncomment the following to hear the default beep if the file isn't found
            ''If strFilePathSearch = "" Then boolPlayDefaultSoundIfWaveNotFound = True
            blnPlaySound = False
            strSoundFilePath = String.Empty
        End If

        If Not boolPlayDefaultSoundIfWaveNotFound Then
            wFlags = SND_NODEFAULT
        End If

        If blnPlaySound Or boolPlayDefaultSoundIfWaveNotFound Then
            If boolWaitForCompletion Then
                wFlags = wFlags Or SND_SYNC
            Else
                wFlags = wFlags Or SND_ASYNC
                If boolLoop Then
                    wFlags = wFlags Or SND_LOOP
                End If
            End If

            lngReturnValue = sndPlaySound(strSoundFilePath, wFlags)

            If lngReturnValue = 0 Then
                Return False
            Else
                Return True
            End If

        End If

        Return False
    End Function

    Public Sub WindowStayOnTop(hwnd As Integer, boolStayOnTop As Boolean, Optional ByVal lngFormPosLeft As Integer = 0, Optional ByVal lngFormPosTop As Integer = 0, Optional ByVal lngFormPosWidth As Integer = 600, Optional ByVal lngFormPosHeight As Integer = 500)

        ' Toggles the behavior of the given window to "stay on top" of all other windows
        ' The new form sizes (lngFormPosLeft, lngFormPosTop, lngFormPosWidth, lngFormPosHeight)
        '  are in pixels

        Dim lngTopMostSwitch As Integer

        If boolStayOnTop Then
            ' Turn on the TopMost attribute.
            lngTopMostSwitch = conHwndTopmost
        Else
            ' Turn off the TopMost attribute.
            lngTopMostSwitch = conHwndNoTopmost
        End If

        SetWindowPos(hwnd, lngTopMostSwitch, lngFormPosLeft, lngFormPosTop, lngFormPosWidth, lngFormPosHeight, conSwpNoActivate Or conSwpShowWindow)
    End Sub

End Module