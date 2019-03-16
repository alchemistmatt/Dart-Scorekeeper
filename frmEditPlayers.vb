Option Strict Off
Option Explicit On

Friend Class frmEditPlayers
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

    Private mPlayerCountSave As Short
    Private mPlayersSave() As String

    Private mPlayerListChangedLocal As Boolean

    Public ReadOnly Property PlayerListChanged() As Boolean
        Get
            Return mPlayerListChangedLocal
        End Get
    End Property

    Private Sub EditPlayer()

        Try

            If lstPlayers.SelectedIndex >= 0 Then

                frmEditPlayerDialog.PlayerName = CStr(lstPlayers.SelectedItem)

                frmEditPlayerDialog.ShowDialog()


                If frmEditPlayerDialog.PlayerNameUpdated Then
                    ' Update list
                    lstPlayers.SelectedItem = frmEditPlayerDialog.PlayerName
                    mPlayerListChangedLocal = True
                End If

                frmEditPlayerDialog.Close()

            End If
        Catch ex As Exception
            HandleException("frmEditPlayers.EditPlayer", ex)
        End Try

    End Sub

    Private Sub SaveChanges()
        Dim x As Short

        Try

            ' Save Changes
            If mPlayerListChangedLocal Then

                ReDim glbPlayers(MAX_PLAYER_COUNT)
                For x = 0 To lstPlayers.Items.Count - 1
                    glbPlayers(x) = CStr(lstPlayers.Items(x))
                Next x
                glbPlayerCount = lstPlayers.Items.Count

                frmOptions.WriteIniFile(False)

            End If

        Catch ex As Exception
            HandleException("frmEditPlayers.SaveChanges", ex)
        End Try

    End Sub

    Private Sub cmdAddPlayer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAddPlayer.Click

        Try

            frmEditPlayerDialog.PlayerName = String.Empty
            frmEditPlayerDialog.ShowDialog()

            If frmEditPlayerDialog.PlayerNameUpdated Then
                ' Add to list
                lstPlayers.Items.Add(frmEditPlayerDialog.PlayerName)
                mPlayerListChangedLocal = True
            End If

            frmEditPlayerDialog.Close()

        Catch ex As Exception
            HandleException("frmEditPlayers.cmdAddPlayer_click", ex)
        End Try

    End Sub

    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        Dim eResponse As Windows.Forms.DialogResult
        Dim x As Short

        Try

            If mPlayerListChangedLocal Then
                ' Abort changes by copying data from save array
                eResponse = System.Windows.Forms.MessageBox.Show("Are you sure you want to cancel any changes made?", "Cancel", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

                If eResponse <> Windows.Forms.DialogResult.Yes Then
                    Exit Sub
                End If

                ReDim glbPlayers(MAX_PLAYER_COUNT)
                For x = 0 To MAX_PLAYER_COUNT
                    glbPlayers(x) = mPlayersSave(x)
                Next x
                glbPlayerCount = mPlayerCountSave
            End If

            Me.Close()

        Catch ex As Exception
            HandleException("frmEditPlayers.cmdCancel_Click", ex)
        End Try

    End Sub

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        SaveChanges()
        Me.Close()

    End Sub

    Private Sub cmdEdit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEdit.Click
        EditPlayer()
    End Sub

    Private Sub cmdRemove_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRemove.Click

        Try
            If lstPlayers.SelectedIndex >= 0 Then
                lstPlayers.Items.RemoveAt(lstPlayers.SelectedIndex)
                mPlayerListChangedLocal = True
            End If

            System.Windows.Forms.Application.DoEvents()
        Catch ex As Exception
            HandleException("frmEditPlayers.cmdRemove_click", ex)
        End Try

    End Sub

    Private Sub frmEditPlayers_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim x As Short

        Try

            ' Position form in window
            Me.Left = (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
            Me.Top = (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - Me.Height) / 3

            ReDim mPlayersSave(MAX_PLAYER_COUNT)
            For x = 0 To glbPlayerCount
                mPlayersSave(x) = glbPlayers(x)
            Next x
            mPlayerCountSave = glbPlayerCount

            lstPlayers.Items.Clear()
            For x = 0 To glbPlayerCount
                lstPlayers.Items.Add(glbPlayers(x))
            Next x

            mPlayerListChangedLocal = False

        Catch ex As Exception
            HandleException("frmEditPlayers.Form_Load", ex)
        End Try

    End Sub
	
	Private Sub lstPlayers_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstPlayers.DoubleClick
        EditPlayer()		
	End Sub
End Class