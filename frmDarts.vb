Option Strict Off
Option Explicit On
'Imports VB = Microsoft.VisualBasic

Friend Class frmDarts
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

#Region "Module-wide variables"

#End Region

    Private Sub EndProgram()
        Me.Close()
    End Sub

    Private Sub SetDefaultOptions()
        ' Set defaults
        glbBoolCutThroatCricket = True
        glbCutThroatMode = 0
        With glbHitAndRotateStats
            .TotalHits = 0
            .HitsBetweenRotate = 100
            .CurrentWinmauNumber = 8
            .LastRotateHit = 0
            .RotateBoardClockwise = True
        End With
        glbDefault301StartScore = 301
        glbBoolRequireDoubleIn = True
        glbBoolRequireDoubleOut = True
        glbScoreFontSize = DEFAULT_SCORE_FONT_SIZE
        glbBoolPlayWaveFileForPlayer = True
        glbMinimumScoreToPlaySound = 60
        modDarts.glbDartBoardSizeVal = modDarts.bsBoardSizeConstants.bsMedium

        UpdateDartBoardSize()
    End Sub

    Private Sub ShowPlayerStats()
        Try

            frmPlayerStats.ShowDialog()
            frmPlayerStats.Close()

        Catch ex As Exception
            HandleException("frmMain.ShowPlayerStats", ex)
        End Try

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Public Sub StartNewGameType(ByVal eGameTypeNewGame As gtGameTypeConstants)
        Dim eResponse As Windows.Forms.DialogResult
        Dim eCurrentGameType As gtGameTypeConstants
        Dim strMessage As String

        Try

            eCurrentGameType = frmCricket.GetGameType()

            ' See if strGameName was last game type played
            If eCurrentGameType <> eGameTypeNewGame Then
                ' See if a game is in progress
                If frmCricket.GameInProgress Then
                    ' See if game is over
                    If Not frmCricket.CheckForGameOver(True) Then
                        strMessage = "A " & LookupGameStringByType(eCurrentGameType) & " game is currently in progress.  Abort game and start a new game of " & LookupGameStringByType(eGameTypeNewGame) & "?"

                        eResponse = System.Windows.Forms.MessageBox.Show(strMessage, "Game in Progress", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

                        If eResponse <> DialogResult.Yes Then
                            Exit Sub
                        End If
                    End If
                End If
            End If

            If frmCricket.GetGameType() <> eGameTypeNewGame Then
                frmCricket.StartNewGame(False, eGameTypeNewGame)
            End If

            frmDartBoard.Show()
            frmCricket.Show() 'vbModeLess

            If eGameTypeNewGame = gtGameTypeConstants.gtGolf Then
                frmCricket.HideRealTimeStatistics()
            Else
                frmCricket.ShowRealTimeStatistics()
            End If

        Catch ex As Exception
            HandleException("StartNewGameType", ex)
        End Try

    End Sub

    Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
        EndProgram()
    End Sub

    Private Sub cmdGolf_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdGolf.Click
        StartNewGameType(modDarts.gtGameTypeConstants.gtGolf)
    End Sub

    Private Sub cmdPlay301_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPlay301.Click
        StartNewGameType(modDarts.gtGameTypeConstants.gt301)
    End Sub

    Private Sub cmdPlayCricket_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPlayCricket.Click
        StartNewGameType(modDarts.gtGameTypeConstants.gtCricket)
    End Sub

    Private Sub cmdShowStats_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdShowStats.Click
        ShowPlayerStats()
    End Sub

    'UPGRADE_WARNING: Form event frmDarts.Activate has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
    Private Sub frmDarts_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        Dim LabelColor As System.Drawing.Color

        Try
            LabelColor = System.Drawing.Color.Black

            lblDatePhrase.Text = DateLabelText(LabelColor)
            lblDatePhrase.ForeColor = LabelColor

            If Me.WindowState <> System.Windows.Forms.FormWindowState.Minimized Then
                If lblDatePhrase.Text.Length > 45 Then
                    lblDatePhrase.Width = 333
                    Me.Width = 360
                Else
                    Me.Width = 284
                End If
            End If

        Catch ex As Exception
            HandleException("frmDarts_Activated", ex)
        End Try


    End Sub

    Private Sub frmDarts_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' Save players and number of hits in Darts.ini file
        frmOptions.WriteIniFile(False)
    End Sub

    Private Sub frmDarts_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        Try

            ' Set height and width
            Me.Width = 284              ' 4260 Twips; This number is in Form_activate also
            Me.Height = 253             ' 3800 Twips

            ' Center form in window
            Me.Left = (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
            Me.Top = (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2

            ' Reserve memory for arrays
            ReserveMemoryForGlobalArrays()

            SetDefaultOptions()

            IniFilePath = System.IO.Path.Combine(GetAppDataFolderPath, "Darts.ini")
            StatsFileNameBase = System.IO.Path.Combine(GetAppDataFolderPath, "Stats")
            StatsExtendedFilenameBase = System.IO.Path.Combine(GetAppDataFolderPath, "StatsExtd")

            frmOptions.ReadIniFile()

        Catch ex As Exception
            HandleException("frmMain_Load", ex)
        End Try

    End Sub

    Public Sub mnu301_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnu301.Click
        StartNewGameType(modDarts.gtGameTypeConstants.gt301)
    End Sub

    Public Sub mnuAbout_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuAbout.Click

        Try
            frmAbout.ShowDialog()

            frmAbout.Close()

        Catch ex As Exception
            HandleException("frmMain.mnuAbout_Click", ex)
        End Try

    End Sub

    Public Sub mnuCricket_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuCricket.Click
        StartNewGameType(modDarts.gtGameTypeConstants.gtCricket)
    End Sub

    Public Sub mnuEditPlayers_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuEditPlayers.Click

        Try
            frmEditPlayers.ShowDialog()

            If frmEditPlayers.PlayerListChanged Then
                frmCricket.FillPlayerBoxes()
            End If

            frmEditPlayers.Close()

        Catch ex As Exception
            HandleException("frmMain.mnuEditPlayers_Click", ex)
        End Try

    End Sub

    Public Sub mnuExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuExit.Click
        EndProgram()
    End Sub

    Public Sub mnuGolf_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuGolf.Click
        StartNewGameType(modDarts.gtGameTypeConstants.gtGolf)
    End Sub

    Public Sub mnuProgramOptions_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuProgramOptions.Click

        Try
            frmOptions.ShowDialog()

            frmOptions.Close()

        Catch ex As Exception
            HandleException("frmMain.mnuProgramOptions_Click", ex)
        End Try

    End Sub

    Public Sub mnuStats_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuStats.Click
        ShowPlayerStats()
    End Sub
End Class