Option Strict Off
Option Explicit On
Friend Class frmRealtimeStatistics
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
            HandleException("frmRealTimeStatistics->SortLists", ex)
        End Try

    End Sub

    Public Sub UpdateRealtimeStats(ByRef udtRealTimeStats() As frmCricket.udtRealTimeStatsType, intPlayerCount As Integer)

        Dim intPlayerIndex As Integer
        Dim sngMeanScorePerThrow As Single

        lstPlayers.Items.Clear()
        lstMeanScorePerThrow.Items.Clear()

        For intPlayerIndex = 0 To intPlayerCount - 1
            With udtRealTimeStats(intPlayerIndex)
                If .ThrowCount > 0 Then
                    sngMeanScorePerThrow = .ScoreTotal / .ThrowCount
                Else
                    sngMeanScorePerThrow = 0
                End If

                lstPlayers.Items.Add(.PlayerName)
                lstMeanScorePerThrow.Items.Add(CStr(Math.Round(sngMeanScorePerThrow, 1)))

            End With
        Next intPlayerIndex

        ' Auto-adjust the height of mRealtimeStatsWindow
        If intPlayerCount < 2 Then intPlayerCount = 2
        Me.Height = intPlayerCount * 12 + 153

    End Sub

    Private Sub cmdok_Click(eventSender As Object, eventArgs As EventArgs) Handles cmdOK.Click
        Me.Close()
    End Sub

    Private Sub lblMeanScorePerThrow_Click(eventSender As Object, eventArgs As EventArgs) Handles lblMeanScorePerThrow.Click
        SortLists(lstMeanScorePerThrow)
    End Sub

    Private Sub lblPlayer_Click(eventSender As Object, eventArgs As EventArgs) Handles lblPlayer.Click
        SortLists(lstPlayers)
    End Sub

    'UPGRADE_WARNING: Event lstMeanScorePerThrow.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub lstMeanScorePerThrow_SelectedIndexChanged(eventSender As Object, eventArgs As EventArgs) Handles lstMeanScorePerThrow.SelectedIndexChanged
        lstPlayers.SelectedIndex = lstMeanScorePerThrow.SelectedIndex
    End Sub

    'UPGRADE_WARNING: Event lstPlayers.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub lstPlayers_SelectedIndexChanged(eventSender As Object, eventArgs As EventArgs) Handles lstPlayers.SelectedIndexChanged

        Dim objThisControl As Control

        For Each objThisControl In Me.Controls
            If TypeOf objThisControl Is ListBox Then
                If objThisControl.Name <> "lstPlayers" Then
                    CType(objThisControl, ListBox).SelectedIndex = lstPlayers.SelectedIndex
                End If
            End If
        Next objThisControl

    End Sub
End Class