Option Strict Off
Option Explicit On

Friend Class frmOptions
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
    
    Private Const FONT_SIZE_MINIMUM As Short = 8
    Private Const FONT_SIZE_MAXIMUM As Short = 38
    
    Private mOptionsChangedLocal As Boolean
    Private mFormLoaded As Boolean

    Public Sub ReadIniFile()

        Dim srInFile As System.IO.StreamReader

        Dim strLineIn As String
        Dim KeyString As String
        Dim x As Short
        Dim intValue As Short

        Try

            If Not System.IO.File.Exists(IniFilePath) Then
                ' Must re-create the .ini file
                WriteIniFile(True)
            End If

            If Not System.IO.File.Exists(IniFilePath) Then
                System.Windows.Forms.MessageBox.Show("Ini file not found: " & IniFilePath, "File Missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            glbPlayerCount = 0
            ReDim glbPlayers(MAX_PLAYER_COUNT)

            srInFile = New System.IO.StreamReader(New System.IO.FileStream(IniFilePath, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read))

            Do While srInFile.Peek() >= 0

                strLineIn = srInFile.ReadLine

                x = strLineIn.IndexOf("=")
                If x > 0 Then
                    KeyString = strLineIn.Substring(x + 1)

                    Select Case strLineIn.Substring(0, x)
                        Case "TotalHits" : glbHitAndRotateStats.TotalHits = CInt(KeyString)
                        Case "HitsBetweenRotate" : glbHitAndRotateStats.HitsBetweenRotate = CInt(KeyString)
                        Case "CurrentRavenNumber" : glbHitAndRotateStats.CurrentWinmauNumber = CInt(KeyString)
                        Case "CurrentWinmauNumber" : glbHitAndRotateStats.CurrentWinmauNumber = CInt(KeyString)
                        Case "LastRotateHit" : glbHitAndRotateStats.LastRotateHit = CInt(KeyString)
                        Case "RotateBoardClockwise" : glbHitAndRotateStats.RotateBoardClockwise = CBool(KeyString)
                        Case "CutThroatCricket" : glbBoolCutThroatCricket = CBool(KeyString)
                        Case "CutThroatScoringMode" : glbCutThroatMode = CInt(KeyString)
                        Case "Default301StartScore" : glbDefault301StartScore = CInt(KeyString)
                        Case "ScoreFontSize" : glbScoreFontSize = CInt(KeyString)
                        Case "Require301DoubleIn" : glbBoolRequireDoubleIn = CBool(KeyString)
                        Case "Require301DoubleOut" : glbBoolRequireDoubleOut = CBool(KeyString)
                        Case "PlayWaveFile" : glbBoolPlayWaveFileForPlayer = CBool(KeyString)
                        Case "MinimumScoreToPlaySound" : glbMinimumScoreToPlaySound = CInt(KeyString)
                        Case "ScoreAreaSize"
                            intValue = CInt(KeyString)
                            If intValue >= sasScoreAreaSizeConstants.sasNormal And intValue <= sasScoreAreaSizeConstants.sasSmall Then
                                glbScoreAreaSizeVal = intValue
                            End If
                        Case "DartBoardSize"
                            intValue = CInt(KeyString)
                            If intValue >= bsBoardSizeConstants.bsSmall And intValue <= bsBoardSizeConstants.bsHuge Then
                                glbDartBoardSizeVal = intValue
                            End If
                        Case "Player"
                            If glbPlayerCount < MAX_PLAYER_COUNT Then
                                glbPlayerCount += 1
                                glbPlayers(glbPlayerCount) = String.Copy(KeyString)
                            End If
                        Case Else
                            ' Unknown Key Name
                            System.Console.WriteLine("Unknown entry in .Ini file: " & strLineIn)
                    End Select
                End If
            Loop
            srInFile.Close()

            Try
                SetFontSizes()
            Catch ex As Exception
                HandleException("ReadIniFile.SetFontSizes", ex)
            End Try

            Try
                UpdateDartBoardSize()
            Catch ex As Exception
                HandleException("ReadIniFile.UpdateDartBoardSize", ex)
            End Try

            Try
                UpdateScoreAreaSize()
            Catch ex As Exception
                HandleException("ReadIniFile.UpdateScoreAreaSize", ex)
            End Try


            If glbPlayerCount = 0 Then
                glbPlayerCount = 4
                glbPlayers(0) = String.Empty
                For x = 1 To glbPlayerCount
                    glbPlayers(x) = "Player " & (x).ToString
                Next x
            End If

            UpdateRotateStatus()

        Catch ex As Exception
            HandleException("ReadIniFile", ex)
        End Try

    End Sub

    Private Sub SetFontSizes()

        If glbScoreFontSize = 0 Then glbScoreFontSize = DEFAULT_SCORE_FONT_SIZE

        frmCricket.SetScoreFontSizes(False)

    End Sub

    Private Sub ShowDefaultOptions()
        
        Try

            txtHitsBetweenRotate.Text = "1000"
            chkRotateBoardClockwise.CheckState = System.Windows.Forms.CheckState.Unchecked
            chkCutThroatCricket.CheckState = System.Windows.Forms.CheckState.Checked
            optScoringModeLowScoreWins.Checked = True

            txtDefault301StartScore.Text = "301"
            chkPlaySounds.CheckState = System.Windows.Forms.CheckState.Checked

            txtMinimumScoreToPlaySound.Text = "60"
            cboScoreAreaSize.SelectedIndex = modDarts.sasScoreAreaSizeConstants.sasNormal
            cboDartBoardSize.SelectedIndex = modDarts.bsBoardSizeConstants.bsMedium

            cboScoreFontSize.SelectedIndex = DEFAULT_SCORE_FONT_SIZE - FONT_SIZE_MINIMUM

        Catch ex As Exception
            HandleException("Options->ShowDefaultOptions", ex)
        End Try

    End Sub

    Private Sub UpdateRotateStatus()
        ' Determines if the board needs to be rotated and says which direction to rotate it
        Dim x, NewWinmau, y As Short

        ' NumberOrder contains every other number on the board, in order, clockwise around the board
        Dim NumberOrder() As Integer = New Integer() {20, 18, 13, 10, 2, 3, 7, 8, 14, 12}

        Try

            If glbHitAndRotateStats.HitsBetweenRotate = 0 Then glbHitAndRotateStats.HitsBetweenRotate = 1000

            If glbHitAndRotateStats.TotalHits > glbHitAndRotateStats.LastRotateHit + glbHitAndRotateStats.HitsBetweenRotate Then
                For x = 0 To NumberOrder.Length - 1
                    If glbHitAndRotateStats.CurrentWinmauNumber = NumberOrder(x) Then
                        If glbHitAndRotateStats.RotateBoardClockwise = False Then
                            y = x - 1
                            If y < 0 Then y = 9
                        Else
                            y = x + 1
                            If y > 9 Then y = 0
                        End If
                        NewWinmau = NumberOrder(y)
                        Exit For
                    End If
                Next x

                If x > 9 Then
                    ' No match
                    NewWinmau = 8
                End If

                glbHitAndRotateStats.CurrentWinmauNumber = NewWinmau
                glbHitAndRotateStats.LastRotateHit = glbHitAndRotateStats.TotalHits

                Dim strMessage As String
                strMessage = glbHitAndRotateStats.HitsBetweenRotate & " hits have occured since the last dart board rotation.  Please rotate the board so the word Winmau lines up with the number " & NewWinmau

                System.Windows.Forms.MessageBox.Show(strMessage, "Rotate Board", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            frmDarts.lblWinmau.Text = "Winmau at " & glbHitAndRotateStats.CurrentWinmauNumber.ToString()

        Catch ex As Exception
            HandleException("UpdateRotateStatus", ex)
        End Try

    End Sub

    Public Sub UpdateScoreAreaSize()
        frmCricket.SetScoreAreaSize(glbScoreAreaSizeVal)        
    End Sub

    Public Sub WriteIniFile(ByVal Initialize As Boolean)

        Dim x As Short
        Dim swOutFile As System.IO.StreamWriter

        UpdateRotateStatus()

        Try
            swOutFile = New System.IO.StreamWriter(New System.IO.FileStream(IniFilePath, IO.FileMode.Create, IO.FileAccess.Write, IO.FileShare.Read))

            swOutFile.WriteLine("; Darts Ini File (v" & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "  Build " & My.Application.Info.Version.Revision & ")")

            If Initialize Then
                swOutFile.WriteLine("TotalHits=0")
                swOutFile.WriteLine("HitsBetweenRotate=1000")
                swOutFile.WriteLine("CurrentWinmauNumber=14")
                swOutFile.WriteLine("LastRotateHit=0")
                swOutFile.WriteLine("RotateBoardClockwise=True")
                swOutFile.WriteLine("CutThroatCricket=-1")
                swOutFile.WriteLine("CutThroatScoringMode=0")
                swOutFile.WriteLine("Default301StartScore=301")
                swOutFile.WriteLine("Require301DoubleIn=True")
                swOutFile.WriteLine("Require301DoubleOut=True")
                swOutFile.WriteLine("ScoreFontSize=12")
                swOutFile.WriteLine("PlayWaveFile=True")
                swOutFile.WriteLine("MinimumScoreToPlaySound=60")
                swOutFile.WriteLine("DartBoardSize=1")
                For x = 0 To 3
                    swOutFile.WriteLine("Player=Player " & (x + 1).ToString())
                Next x
            Else
                swOutFile.WriteLine("TotalHits=" & glbHitAndRotateStats.TotalHits)
                swOutFile.WriteLine("HitsBetweenRotate=" & glbHitAndRotateStats.HitsBetweenRotate)
                swOutFile.WriteLine("CurrentWinmauNumber=" & glbHitAndRotateStats.CurrentWinmauNumber)
                swOutFile.WriteLine("LastRotateHit=" & glbHitAndRotateStats.LastRotateHit)
                swOutFile.WriteLine("RotateBoardClockwise=" & glbHitAndRotateStats.RotateBoardClockwise)
                swOutFile.WriteLine("CutThroatCricket=" & glbBoolCutThroatCricket)
                swOutFile.WriteLine("CutThroatScoringMode=" & glbCutThroatMode)
                swOutFile.WriteLine("Default301StartScore=" & glbDefault301StartScore)
                swOutFile.WriteLine("Require301DoubleIn=" & glbBoolRequireDoubleIn)
                swOutFile.WriteLine("Require301DoubleOut=" & glbBoolRequireDoubleOut)
                swOutFile.WriteLine("ScoreFontSize=" & glbScoreFontSize)
                swOutFile.WriteLine("PlayWaveFile=" & glbBoolPlayWaveFileForPlayer)
                swOutFile.WriteLine("MinimumScoreToPlaySound=" & glbMinimumScoreToPlaySound)
                swOutFile.WriteLine("ScoreAreaSize=" & glbScoreAreaSizeVal)
                swOutFile.WriteLine("DartBoardSize=" & glbDartBoardSizeVal)

                glbPlayers(0) = String.Empty
                For x = 1 To glbPlayerCount
                    swOutFile.WriteLine("Player=" & glbPlayers(x))
                Next x
            End If

            swOutFile.Close()

        Catch ex As Exception
            HandleException("WriteIniFile", ex)
        End Try

    End Sub

    Private Sub cboDartBoardSize_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboDartBoardSize.SelectedIndexChanged
        If mFormLoaded Then
            mOptionsChangedLocal = True
            modDarts.glbDartBoardSizeVal = cboDartBoardSize.SelectedIndex
            UpdateDartBoardSize()
        End If
    End Sub

    Private Sub cboScoreAreaSize_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboScoreAreaSize.SelectedIndexChanged
        If mFormLoaded Then
            mOptionsChangedLocal = True
            modDarts.glbScoreAreaSizeVal = cboScoreAreaSize.SelectedIndex
            UpdateScoreAreaSize()
        End If
    End Sub

    Private Sub cboScoreFontSize_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboScoreFontSize.SelectedIndexChanged
        If mFormLoaded Then
            mOptionsChangedLocal = True
            glbScoreFontSize = CStr(cboScoreFontSize.SelectedItem)
            SetFontSizes()
        End If
    End Sub

    Private Sub chkCutThroatCricket_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkCutThroatCricket.CheckedChanged
        If mFormLoaded Then
            mOptionsChangedLocal = True
            glbBoolCutThroatCricket = CChkBox(chkCutThroatCricket)
            optScoringModeLowScoreWins.Enabled = glbBoolCutThroatCricket
            optScoringModeHighScoreWins.Enabled = glbBoolCutThroatCricket
        End If
    End Sub

    Private Sub chkRotateBoardClockwise_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRotateBoardClockwise.CheckedChanged
        If mFormLoaded Then
            mOptionsChangedLocal = True
            glbHitAndRotateStats.RotateBoardClockwise = CChkBox(chkRotateBoardClockwise)
        End If
    End Sub

    Private Sub chkPlaySounds_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPlaySounds.CheckedChanged
        If mFormLoaded Then
            mOptionsChangedLocal = True
            glbBoolPlayWaveFileForPlayer = CChkBox(chkPlaySounds)
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        Dim eResponse As System.Windows.Forms.DialogResult

        If mOptionsChangedLocal Then
            ' Abort changes by reloading data from file
            eResponse = System.Windows.Forms.MessageBox.Show("Are you sure you want to cancel any changes made?", "Cancel Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

            If eResponse = Windows.Forms.DialogResult.Yes Then
                ReadIniFile()
            Else
                Exit Sub
            End If
        End If

        Me.Close()

    End Sub

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click

        ' Save Changes
        If mOptionsChangedLocal = True Then
            WriteIniFile(False)
            SetFontSizes()
        End If
        Me.Close()

    End Sub

    Private Sub cmdDefaults_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDefaults.Click
        ShowDefaultOptions()
    End Sub

    Private Sub frmOptions_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim intFontSize As Short

        Try
            mFormLoaded = False

            ' Set height and width
            Me.Width = 427
            Me.Height = 510

            ' Position form in window
            Me.Left = (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
            Me.Top = (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - Me.Height) / 3

            mOptionsChangedLocal = False

            ' Fill textboxes and correctly check the checkboxes

            If glbBoolCutThroatCricket Then
                chkCutThroatCricket.CheckState = System.Windows.Forms.CheckState.Checked
            Else
                chkCutThroatCricket.CheckState = System.Windows.Forms.CheckState.Unchecked
            End If
            optScoringModeLowScoreWins.Enabled = glbBoolCutThroatCricket
            optScoringModeHighScoreWins.Enabled = glbBoolCutThroatCricket

            If glbCutThroatMode = ctCutThroatModeConstants.LowScoreWindows Then
                optScoringModeLowScoreWins.Checked = True
            Else
                optScoringModeHighScoreWins.Checked = True
            End If

            With glbHitAndRotateStats
                txtTotalHits.Text = CStr(.TotalHits)
                txtHitsBetweenRotate.Text = CStr(.HitsBetweenRotate)
                txtCurrentWinmauNumber.Text = CStr(.CurrentWinmauNumber)
                txtLastRotateHit.Text = CStr(.LastRotateHit)
                If .RotateBoardClockwise Then
                    chkRotateBoardClockwise.CheckState = System.Windows.Forms.CheckState.Checked
                Else
                    chkRotateBoardClockwise.CheckState = System.Windows.Forms.CheckState.Unchecked
                End If
            End With

            txtDefault301StartScore.Text = CStr(glbDefault301StartScore)

            If glbBoolPlayWaveFileForPlayer Then
                chkPlaySounds.CheckState = System.Windows.Forms.CheckState.Checked
            Else
                chkPlaySounds.CheckState = System.Windows.Forms.CheckState.Unchecked
            End If

            txtMinimumScoreToPlaySound.Text = CStr(glbMinimumScoreToPlaySound)

            ' Populate the combo boxes
            With cboScoreFontSize
                .Items.Clear()
                For intFontSize = FONT_SIZE_MINIMUM To FONT_SIZE_MAXIMUM
                    .Items.Add(Trim(CStr(intFontSize)))
                    If intFontSize = glbScoreFontSize Then
                        .SelectedIndex = .Items.Count - 1
                    End If
                Next intFontSize
                If .SelectedIndex < 0 Then
                    .SelectedIndex = DEFAULT_SCORE_FONT_SIZE - FONT_SIZE_MINIMUM
                End If
            End With

            With cboScoreAreaSize
                .Items.Clear()
                .Items.Add("Normal")
                .Items.Add("Small")
                .SelectedIndex = modDarts.glbScoreAreaSizeVal
            End With

            With cboDartBoardSize
                .Items.Clear()
                .Items.Add("Small")
                .Items.Add("Medium")
                .Items.Add("Large")
                .Items.Add("Huge")
                .SelectedIndex = modDarts.glbDartBoardSizeVal
            End With

        Catch ex As Exception
            HandleException("frmOptions.Form_Load", ex)
        End Try

        mFormLoaded = True

    End Sub

    Private Sub txtCurrentWinmauNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCurrentWinmauNumber.KeyPress
        TextBoxKeyPressHandler(txtCurrentWinmauNumber, e, True)
    End Sub

    Private Sub txtCurrentWinmauNumber_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCurrentWinmauNumber.Validating
        Dim intNewValue As Integer

        If mFormLoaded Then

            If Not Integer.TryParse(txtCurrentWinmauNumber.Text, intNewValue) Then
                intNewValue = 20
                txtCurrentWinmauNumber.Text = intNewValue.ToString()
            End If

            ' NumberOrder contains every other number on the board, in order, clockwise around the board
            Dim NumberOrder() As Integer = New Integer() {20, 18, 13, 10, 2, 3, 7, 8, 14, 12}

            If Array.IndexOf(NumberOrder, intNewValue) >= 0 Then
                If glbHitAndRotateStats.CurrentWinmauNumber <> intNewValue Then
                    mOptionsChangedLocal = True
                    glbHitAndRotateStats.CurrentWinmauNumber = intNewValue
                End If
            Else
                System.Windows.Forms.MessageBox.Show("Invalid value; Must be 20, 18, 13, 10, 2, 3, 7, 8, 14, or 12", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                e.Cancel = True
            End If

        End If

    End Sub

    Private Sub txtDefault301StartScore_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDefault301StartScore.KeyPress
        TextBoxKeyPressHandler(txtDefault301StartScore, e, True)
    End Sub

    Private Sub txtDefault301StartScore_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDefault301StartScore.Validating
        Dim intNewValue As Integer

        If mFormLoaded Then
            If Integer.TryParse(txtDefault301StartScore.Text, intNewValue) Then
                If intNewValue >= 0 AndAlso intNewValue <= 50000 Then
                    mOptionsChangedLocal = True
                    glbDefault301StartScore = intNewValue
                Else
                    System.Windows.Forms.MessageBox.Show("Invalid value; must be between 0 and 50,000", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    e.Cancel = True
                End If
            End If

        End If

    End Sub

    Private Sub txtHitsBetweenRotate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHitsBetweenRotate.KeyPress
        TextBoxKeyPressHandler(txtHitsBetweenRotate, e, True)
    End Sub

    Private Sub txtHitsBetweenRotate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtHitsBetweenRotate.Validating
        Dim intNewValue As Integer

        If mFormLoaded Then
            If Integer.TryParse(txtHitsBetweenRotate.Text, intNewValue) Then
                If intNewValue >= 0 AndAlso intNewValue <= 100000 Then
                    mOptionsChangedLocal = True
                    glbHitAndRotateStats.HitsBetweenRotate = intNewValue
                Else
                    System.Windows.Forms.MessageBox.Show("Invalid value; must be between 0 and 100,000", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    e.Cancel = True
                End If
            End If

        End If

    End Sub

    Private Sub txtLastRotateHit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLastRotateHit.KeyPress
        TextBoxKeyPressHandler(txtLastRotateHit, e, True)
    End Sub

    Private Sub txtLastRotateHit_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLastRotateHit.Validating
        Dim intNewValue As Integer

        If mFormLoaded Then
            If Integer.TryParse(txtLastRotateHit.Text, intNewValue) Then
                If intNewValue >= 0 AndAlso intNewValue <= 2000000000 Then
                    mOptionsChangedLocal = True
                    glbHitAndRotateStats.LastRotateHit = intNewValue
                Else
                    System.Windows.Forms.MessageBox.Show("Invalid value; must be between 0 and 2,000,000,000", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    e.Cancel = True
                End If
            End If

        End If

    End Sub

    Private Sub txtMinimumScoreToPlaySound_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMinimumScoreToPlaySound.KeyPress
        TextBoxKeyPressHandler(txtMinimumScoreToPlaySound, e, True)
    End Sub

    Private Sub txtMinimumScoreToPlaySound_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtMinimumScoreToPlaySound.Validating
        Dim intMinimumScore As Integer

        If mFormLoaded Then
            If Integer.TryParse(txtMinimumScoreToPlaySound.Text, intMinimumScore) Then
                If intMinimumScore >= 0 AndAlso intMinimumScore <= 300 Then
                    mOptionsChangedLocal = True
                    glbMinimumScoreToPlaySound = intMinimumScore
                Else
                    System.Windows.Forms.MessageBox.Show("Invalid value; must be between 0 and 300", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    e.Cancel = True
                End If
            End If

        End If

    End Sub

    Private Sub txtTotalHits_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotalHits.KeyPress
        TextBoxKeyPressHandler(txtTotalHits, e, True)
    End Sub

    Private Sub txtTotalHits_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTotalHits.Validating
        Dim intTotalHits As Integer

        If mFormLoaded Then
            If Integer.TryParse(txtTotalHits.Text, intTotalHits) Then
                If intTotalHits >= 0 AndAlso intTotalHits <= MAX_TOTAL_HITS Then
                    mOptionsChangedLocal = True
                    glbHitAndRotateStats.TotalHits = intTotalHits
                Else
                    System.Windows.Forms.MessageBox.Show("Invalid value for Total Hits; must be between 0 and " & MAX_TOTAL_HITS.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    e.Cancel = True
                End If
            End If

        End If

    End Sub

    Private Sub optScoringModeLowScoreWins_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optScoringModeLowScoreWins.CheckedChanged
        If mFormLoaded Then
            mOptionsChangedLocal = True
            glbCutThroatMode = ctCutThroatModeConstants.LowScoreWindows
        End If
    End Sub

    Private Sub optScoringModeHighScoreWins_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optScoringModeHighScoreWins.CheckedChanged
        If mFormLoaded Then
            mOptionsChangedLocal = True
            glbCutThroatMode = ctCutThroatModeConstants.HighScoreWindows
        End If
    End Sub

End Class
