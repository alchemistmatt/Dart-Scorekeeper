Option Strict Off
Option Explicit On

Friend Class frmRankHelp
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
    
    Private Sub cmdok_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdok.Click
        Me.Close()
    End Sub
    
    Private Sub frmRankHelp_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        
        Dim strHelpText As String

        
        ' Set height and width
        Me.Width = 42
        Me.Height = 20

        ' Position form in window
        Me.Left = (2 * System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - Me.Width) / 3
        Me.Top = (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - Me.Height) / 3

        strHelpText = "The formula for computing rankings is taken from a football ranking system used " & _
                      "by Matthew Welch.  His philosophy is that 'running up the score doesn't prove a " & _
                      "damn thing, thus this is another Win is a Win is a Win formula; points are not " & _
                      "entered into the formula.'  However, the player's record is not the only factor; " & _
                      "the record of the player's opponents is also taken into consideration. Lastly, " & _
                      "the number of games played is taken into condsideration in order to reward those who play more often."

        lblHelp0.text = strHelpText

        strHelpText = "The actual rank is computed as the sum of a number of factors, then normalized to a value between 0 and 1.  " & _
                      "The first factor considered is the player's win percentage (games won divided by games played).  " & _
                      "The second factor is the strength of the opponents, determined by examining the win percentage of the opponents played.  " & _
                      "The final factor is the number of games won, relative to the highest number of games won by any player.  Combining these, " & _
                      "Ranking = 0.5 * (player win%)  + [0.35 * (opponents' average win%) for games won] +  [0.15 * (winner's average win%) for games lost] + 0.1 * (games won / max games won)"

        lblHelp1.text = strHelpText

        strHelpText = "In the Ranking, the opponents' average win% is weighted differently depending on whether the player won a game or not.  If the player wins a game, " & _
                      "the win% of all opponents in that game is averaged and taken times 0.35; however, if a player loses a game, the win% of only the winners " & _
                      "in the game is used, and is taken times just 0.15.  This is done because, when a player loses a game, only the win% of the winning team should be considered; " & _
                      "however, when a player wins a game, that player has beaten everbody, so everybody else's win% is used."
        lblHelp2.text = strHelpText

    End Sub
End Class
