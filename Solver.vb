
Public Class Solver
    Protected Friend Generator As Generator
    Sub New(Gen As Generator)
        Me.Generator = Gen
    End Sub
    Public Function Search(Start As Node, Destination As Node, ByRef Result As List(Of Node)) As Boolean
        Dim open As New List(Of Node) From {Start}
        Dim closed As New List(Of Node)
        Dim current As Node = Start, distance As Double

        While open.Count <> 0 AndAlso Not closed.Exists(Function(x) x Is Destination)
            current = open(0)
            open.Remove(current)
            closed.Add(current)
            For Each n As Node In current.GetNeighbours
                If (Not closed.Contains(n) AndAlso current.IsAccessible(n)) Then
                    If Not open.Contains(n) Then
                        n.Reminder = current
                        distance = n.GetDistance(Destination)
                        n.Cost = 1 + n.Reminder.Cost
                        open.Add(n)
                        open = open.OrderBy(Function(x) x.F(Destination)).ToList
                    End If
                End If
            Next
        End While
        If (Not closed.Any(Function(x) x Is Destination)) Then
            Return False
        Else
            Result.AddRange(Me.BuildPath(closed, current, Start))
            Return True
        End If
    End Function
    Private Function BuildPath(closed As List(Of Node), current As Node, start As Node) As List(Of Node)
        Dim node As Node = closed(closed.IndexOf(current)), path As New Stack(Of Node)
        While node.Reminder IsNot Nothing
            path.Push(node)
            node = node.Reminder
        End While
        path.Push(start)
        Return path.ToList
    End Function
End Class
