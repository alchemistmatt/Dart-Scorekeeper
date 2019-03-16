Option Strict On

''' <summary>
''' Use this class to dynamically create label controls on a form and refer to them using array notation
''' Concept from http://visualbasic.about.com/od/usingvbnet/l/bldykctrlarraya.htm
''' </summary>
''' <remarks></remarks>
Public Class clsLabelArray
    Inherits CollectionBase

    Private ReadOnly HostForm As Form
    Private mControlName As String

    Public Property ControlName() As String
        Get
            Return mControlName
        End Get
        Set
            If String.IsNullOrEmpty(Value) Then Value = ""
            mControlName = Value
        End Set
    End Property

    Public Function AddNewLabel() As Label
        ' Create a new instance of the Label class.
        Dim objLabel As New Label

        ' Add the Label to the collection's internal list.
        Me.List.Add(objLabel)

        ' Add the Label to the HostForm form's Controls collection
        HostForm.Controls.Add(objLabel)

        ' Set intial properties for the Label object.
        objLabel.BackColor = SystemColors.Control
        objLabel.Cursor = Cursors.Default
        objLabel.Font = New Font("Arial", 12.0!, FontStyle.Bold, GraphicsUnit.Point, 0)
        objLabel.ForeColor = Color.FromArgb(0, 0, 192)
        objLabel.Location = New Point(168, 400)
        objLabel.Name = ControlName + Count.ToString()
        objLabel.Size = New Size(49, 17)
        objLabel.Text = "0"
        objLabel.TextAlign = ContentAlignment.TopCenter

        Return objLabel
    End Function

    Public Sub New(host As Form, Name As String)
        HostForm = host
        If String.IsNullOrEmpty(Name) Then Name = "Label"
        Me.ControlName = Name
        Me.AddNewLabel()
    End Sub

    Default Public ReadOnly Property Item(Index As Integer) As Label
        Get
            Return CType(Me.List.Item(Index), Label)
        End Get
    End Property

    Public Sub Remove()
        ' Check to be sure there is a Label to remove.
        If Me.Count > 0 Then
            ' Remove the last Label added to the array from HostForm
            ' Note the use of the default property in accessing the array.
            HostForm.Controls.Remove(Me(Me.Count - 1))
            Me.List.RemoveAt(Me.Count - 1)
        End If
    End Sub
End Class
