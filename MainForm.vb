Imports System.Collections.ObjectModel
Imports System.ComponentModel

Public Class MainForm

    Private _nextPersonId As UInteger = 0UI
    Private _employees As KeyedCollection(Of UInteger, Person)
    Private _bsEmployees As BindingSource

    Private Sub ImportButtonOnClick(sender As Object, e As EventArgs) Handles ImportButton.Click
        ImportEmployees()
    End Sub

    Private Sub ResetButtonOnClick(sender As Object, e As EventArgs) Handles ResetButton.Click
        ResetEmployeeList()
    End Sub

    Private Sub AddButtonOnClick(sender As Object, e As EventArgs) Handles AddButton.Click
        If String.IsNullOrEmpty(txtFirstName.Text) Then
            MsgBox("Employee may not have blank first name", MsgBoxStyle.Information, "Missing First Name Information")
            Return
        ElseIf String.IsNullOrEmpty(txtLastName.Text) Then
            MsgBox("Employee may not have a blank last name", MsgBoxStyle.Information, "Missing Last Name Information")
            Return
        End If
        _bsEmployees.Add(New Person(txtFirstName.Text, txtLastName.Text, _nextPersonId))
        _nextPersonId += 1UI
    End Sub

    Private Sub FrmMainOnLoad(sender As Object, e As EventArgs) Handles MyBase.Load
        ResetEmployeeList()
    End Sub

    Private Sub ImportEmployees()
        _bsEmployees.Add(New Person("Amy", "Brown", _nextPersonId))
        _bsEmployees.Add(New Person("James", "Garcia", _nextPersonId + 1UI))
        _bsEmployees.Add(New Person("Ivan", "Smith", _nextPersonId + 2UI))
        _nextPersonId += 3UI
    End Sub

    ' GridView Helper Procedures
    Private Sub ResetEmployeeList()
        _employees = New PersonCollection()
        _nextPersonId = UInteger.Parse(My.Resources.NextUserID)
        _bsEmployees = New BindingSource()
        EmployeeDataGridView.DataSource = _bsEmployees
        _bsEmployees.DataSource = _employees
        EmployeeDataGridViewSetup()
    End Sub

    Private Sub EmployeeDataGridViewSetup()
        ' 816x489 to 775x340 = 41 x 149
        EmployeeDataGridView.Size = New Size(Me.Size.Width - 41, Me.Size.Height - 149)
        'EmployeeDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        EmployeeDataGridView.Columns("FirstName").DisplayIndex = 0
        EmployeeDataGridView.Columns("LastName").DisplayIndex = 1
        EmployeeDataGridView.Columns("PersonID").DisplayIndex = 2
    End Sub

    Private Sub MainForm_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        'Somehow onload counts as a size change.  Protect app crash here
        If EmployeeDataGridView.Columns.Count = 0 Then
            Return
        End If

        EmployeeDataGridViewSetup()
    End Sub
End Class
