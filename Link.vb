Public Class Link
    Implements IComparable(Of Link)
    Public Property Source As Node
    Public Property Destination As Node
    Sub New(Source As Node, Destination As Node)
        Me.Source = Source
        Me.Destination = Destination
    End Sub
    Public Overrides Function ToString() As String
        Return String.Format("{0}->{1}", Me.Source.ToString, Me.Destination.ToString)
    End Function
    Public Function CompareTo(other As Link) As Integer Implements IComparable(Of Link).CompareTo
        If (Me.Source.Index > Me.Destination.Index) Then
            Return 1
        ElseIf (Me.Source.Index < Me.Destination.Index) Then
            Return -1
        Else
            Return 0
        End If
    End Function
End Class