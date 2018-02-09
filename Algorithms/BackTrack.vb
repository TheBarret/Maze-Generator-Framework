Namespace Algorithms
    Public Class Backtrack
        Public Shared Sub Build(gen As Generator, start As Node, Optional interval As Integer = 3)
            Dim visited As New List(Of Node), stack As New Stack(Of Node)
            Dim neighbours As List(Of Node), current As Node = start, node As Node
            Do
                visited.Add(current)
                neighbours = current.GetNeighbours.Where(Function(y) Not visited.Contains(y)).ToList
                If (neighbours.Count > 0) Then
                    node = neighbours.ElementAt(gen.Randomizer.Next(neighbours.Count))
                    node.Parent = current
                    stack.Push(node)
                    current = node
                Else
                    current = stack.Pop
                End If
                If (stack.Count Mod interval = 0) Then
                    BackTrack.Shuffle(gen, stack)
                End If
            Loop While stack.Count > 0
        End Sub
        Private Shared Function Shuffle(gen As Generator, stack As Stack(Of Node)) As Stack(Of Node)
            Dim buffer As List(Of Node) = stack.ToList, value As Node, n As Integer, k As Integer
            n = buffer.Count
            While (n > 1)
                n -= 1
                k = gen.Randomizer.Next(n + 1)
                value = buffer(k)
                buffer(k) = buffer(n)
                buffer(n) = value
            End While
            stack.Clear()
            buffer.ForEach(Sub(x) stack.Push(x))
            Return stack
        End Function
    End Class
End Namespace