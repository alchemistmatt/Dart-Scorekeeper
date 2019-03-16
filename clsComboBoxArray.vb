Option Strict On

''' <summary>
''' Use this class to dynamically create combobox controls on a form and refer to them using array notation
''' Concept from http://visualbasic.about.com/od/usingvbnet/l/bldykctrlarraya.htm
''' </summary>
''' <remarks></remarks>

Public Class clsComboBoxArray
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

    Public Event SelectedIndexChanged(eventSender As Object, eventArgs As EventArgs)

    Public Function AddNewComboBox() As ComboBox
        ' Create a new instance of the ComboBox class.
        Dim objComboBox As New ComboBox

        AddHandler objComboBox.SelectedIndexChanged, AddressOf SelectedIndexChangedHandler

        ' Add the ComboBox to the collection's internal list.
        Me.List.Add(objComboBox)

        ' Add the ComboBox to the HostForm form's Controls collection
        HostForm.Controls.Add(objComboBox)

        ' Set intial properties for the ComboBox object.
        objComboBox.BackColor = SystemColors.Window
        objComboBox.Cursor = Cursors.Default
        objComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        objComboBox.Font = New Font("Arial", 8.0!, FontStyle.Regular, GraphicsUnit.Point, 0)
        objComboBox.ForeColor = SystemColors.WindowText
        objComboBox.Location = New Point(152, 64)
        objComboBox.Name = Me.ControlName + Count.ToString()
        objComboBox.Size = New Size(81, 22)
        objComboBox.Sorted = True
        objComboBox.Tag = Count

        Return objComboBox
    End Function

    Public Sub New(host As Form, Name As String)
        HostForm = host
        If String.IsNullOrEmpty(Name) Then Name = "ComboBox"
        Me.ControlName = Name
        Me.AddNewComboBox()
    End Sub

    Default Public ReadOnly Property Item(Index As Integer) As ComboBox
        Get
            Return CType(Me.List.Item(Index), ComboBox)
        End Get
    End Property

    Public Sub Remove()
        ' Check to be sure there is a Label to remove.
        If Me.Count > 0 Then
            ' Remove the last ComboBox added to the array from HostForm
            ' Note the use of the default property in accessing the array.
            HostForm.Controls.Remove(Me(Me.Count - 1))
            Me.List.RemoveAt(Me.Count - 1)
        End If
    End Sub

    Private Sub SelectedIndexChangedHandler(eventSender As Object, eventArgs As EventArgs)
        RaiseEvent SelectedIndexChanged(eventSender, eventArgs)
    End Sub

End Class
