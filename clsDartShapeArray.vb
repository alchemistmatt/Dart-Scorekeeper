Option Strict On

Imports Microsoft.VisualBasic.PowerPacks

Public Class clsDartShapeArray
    Inherits System.Collections.CollectionBase

    Private ReadOnly HostForm As System.Windows.Forms.Form

    Public Function AddNewDart() As Microsoft.VisualBasic.PowerPacks.OvalShape
        ' Create a new instance of an oval shape
        Dim ctlShape As New Microsoft.VisualBasic.PowerPacks.OvalShape

        ' Add the OvalShape to the collection's internal list.
        Me.List.Add(ctlShape)

        ' Add the OvalShape to the Controls collection   
        ' of the Form referenced by the HostForm field.
        HostForm.Controls.Add(ctlShape)

        ' Set intial properties for the Label object.
        ctlShape.Top = Count * 25
        ctlShape.Width = 50
        ctlShape.Left = 140
        ctlShape.Tag = Me.Count
        ctlShape.Text = "Label " & Me.Count.ToString
        Return ctlShape
    End Function
    Public Sub New( _
 ByVal host As System.Windows.Forms.Form)
        HostForm = host
        Me.AddNewLabel()
    End Sub
    Default Public ReadOnly Property _
        Item(ByVal Index As Integer) As  _
        System.Windows.Forms.Label
        Get
            Return CType(Me.List.Item(Index),  _
  System.Windows.Forms.Label)
        End Get
    End Property
    Public Sub Remove()
        ' Check to be sure there is a Label to remove.
        If Me.Count > 0 Then
            ' Remove the last Label added to the array 
            ' from the host form controls collection. 
            ' Note the use of the default property in 
            ' accessing the array.
            HostForm.Controls.Remove(Me(Me.Count - 1))
            Me.List.RemoveAt(Me.Count - 1)
        End If
    End Sub

End Class
