Imports System.Collections.ObjectModel

Public Class Person

    Public Property PersonId As UInteger = Nothing
    Public Property FirstName As String = Nothing
    Public Property LastName As String = Nothing

    Public Sub New(ByVal first As String, ByVal last As String, ByVal id As UInteger)
        If String.IsNullOrEmpty(first) Then
            Throw New ArgumentException(first)
        ElseIf String.IsNullOrEmpty(last) Then
            Throw New ArgumentException(last)
        End If
        FirstName = first
        LastName = last
        PersonId = id
    End Sub

End Class

Public Class PersonCollection
    Inherits KeyedCollection(Of UInteger, Person)

    Protected Overrides Function GetKeyForItem(per As Person) As UInteger
        Return per.PersonId
    End Function
End Class
