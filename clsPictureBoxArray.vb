Option Strict On

''' <summary>
''' Use this class to dynamically create picturebox controls on a form and refer to them using array notation
''' Concept from http://visualbasic.about.com/od/usingvbnet/l/bldykctrlarraya.htm
''' </summary>
''' <remarks></remarks>

Public Class clsPictureBoxArray
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

    Public Function AddNewPictureBox() As PictureBox
        ' Create a new instance of the PictureBox class.
        Dim objPctBox As New PictureBox

        ' Add the Picturebox to the collection's internal list.
        Me.List.Add(objPctBox)

        ' Add the PictureBox to the HostForm form's Controls collection
        HostForm.Controls.Add(objPctBox)

        ' Set intial properties for the PictureBox object.
        objPctBox.Top = 200 + Count * 25
        objPctBox.Left = 170
        objPctBox.Width = 33
        objPctBox.Height = 33
        objPctBox.Name = Me.ControlName + Count.ToString()
        objPctBox.Tag = String.Empty
        objPctBox.Text = String.Empty

        Return objPctBox
    End Function

    Public Sub New(host As Form, Name As String)
        HostForm = host
        If String.IsNullOrEmpty(Name) Then Name = "PictureBox"
        Me.ControlName = Name
        Me.AddNewPictureBox()
    End Sub

    Default Public ReadOnly Property Item(Index As Integer) As PictureBox
        Get
            Return CType(Me.List.Item(Index), PictureBox)
        End Get
    End Property

    Public Sub Remove()
        ' Check to be sure there is a Label to remove.
        If Me.Count > 0 Then
            ' Remove the last PictureBox added to the array from HostForm
            ' Note the use of the default property in accessing the array.
            HostForm.Controls.Remove(Me(Me.Count - 1))
            Me.List.RemoveAt(Me.Count - 1)
        End If
    End Sub
End Class
