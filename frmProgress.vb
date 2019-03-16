Option Strict Off
Option Explicit On

Friend Class frmProgress
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

    Public Sub InitializeForm(CurrentTask As String, ProgressBarMinNew As Integer, ProgressBarMaxNew As Integer)

        Try
            If ProgressBarMinNew < 0 Then ProgressBarMinNew = 0
            If ProgressBarMinNew > ProgressBarMaxNew Then ProgressBarMaxNew = ProgressBarMinNew + 1

            lblCurrentTask.Text = CurrentTask

            If ProgressBarMinNew < 0 Then ProgressBarMinNew = 0
            If ProgressBarMaxNew <= ProgressBarMinNew Then ProgressBarMaxNew = ProgressBarMinNew + 1

            pbarProgress.Minimum = ProgressBarMinNew
            pbarProgress.Maximum = ProgressBarMaxNew

            UpdateProgressBar(ProgressBarMinNew, True)

        Catch ex As Exception
            HandleException("frmProgress.InitializeForm", ex)
        End Try

        Me.Show()
        Me.Cursor = Cursors.WaitCursor

    End Sub

    Public Sub UpdateProgressBar(NewValue As Integer, Optional ByVal ResetStartTime As Boolean = False)

        Static StartTime As DateTime = DateTime.Now

        Dim MinutesTotal, MinutesElapsed, MinutesRemaining As Double
        Dim dblRatioCompleted As Double

        If ResetStartTime Then
            StartTime = DateTime.Now
        End If

        Try
            If NewValue < pbarProgress.Minimum Then NewValue = pbarProgress.Minimum
            If NewValue > pbarProgress.Maximum Then NewValue = pbarProgress.Maximum

            If pbarProgress.Maximum > 0 Then
                dblRatioCompleted = (NewValue - pbarProgress.Minimum) / pbarProgress.Maximum
            Else
                dblRatioCompleted = 0
            End If
            If dblRatioCompleted < 0 Then dblRatioCompleted = 0
            If dblRatioCompleted > 1 Then dblRatioCompleted = 1

            pbarProgress.Value = NewValue


            Try
                MinutesElapsed = DateTime.Now.Subtract(StartTime).TotalMinutes
                If dblRatioCompleted <> 0 Then
                    MinutesTotal = MinutesElapsed / dblRatioCompleted
                Else
                    MinutesTotal = 0
                End If
                MinutesRemaining = MinutesTotal - MinutesElapsed

                ' Could update a control here with MinutesElapsed and MinutesRemaining
                ' System.Windows.Forms.Application.DoEvents()

            Catch ex As Exception
                ' Ignore errors here
            End Try


        Catch ex As Exception
            HandleException("UpdateProgressBar", ex)
        End Try


    End Sub

    Public Sub UpdateCurrentTask(strNewTask As String)
        lblCurrentTask.Text = strNewTask

        Application.DoEvents()
    End Sub

    Private Sub frmProgress_Load(eventSender As Object, eventArgs As EventArgs) Handles MyBase.Load

        ' Put window in exact center of screen
        SizeAndCenterWindow(Me, cWindowExactCenter, 200, 100, False)

    End Sub

End Class