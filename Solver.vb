<Serializable>
Public MustInherit Class Solver
    Public Function Solve(Start As Node, Destination As Node, ByRef Result As List(Of Node)) As Boolean
        Dim open As New List(Of Node) From {Start}
        Dim closed As New List(Of Node)
        Dim current As Node = Start, distance As Double
        While open.Any AndAlso Not closed.Any(Function(x) x Is Destination)
            current = open.First
            open.Remove(current)
            closed.Add(current)
            For Each node As Node In current.GetNeighbours
                If (Not closed.Contains(node) AndAlso current.IsAccessible(node)) Then
                    If (Not open.Contains(node)) Then
                        node.Reminder = current
                        distance = node.GetDistance(Destination)
                        node.Cost = 1 + node.Reminder.Cost
                        open.Add(node)
                        open = open.OrderBy(Function(x) x.F(Destination)).ToList
                    End If
                End If
            Next
        End While
        If (Not closed.Any(Function(x) x Is Destination)) Then
            Return False
        Else
            Result.AddRange(Me.GetPath(closed, current, Start))
            Return True
        End If
    End Function
    Private Function GetPath(closed As List(Of Node), current As Node, start As Node) As List(Of Node)
        Dim node As Node = closed(closed.IndexOf(current)), path As New Stack(Of Node)
        While node.Reminder IsNot Nothing
            path.Push(node)
            node = node.Reminder
        End While
        path.Push(start)
        Return path.ToList
    End Function
End Class
