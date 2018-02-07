Imports System.Drawing

<Serializable>
Public Class Node
    Public Property Index As Integer
    Public Property Row As Integer
    Public Property Column As Integer
    Public Property Pencil As Pen
    Public Property Dimensions As Rectangle
    Public Property Access As Accessibility
    Protected Friend Parent As Node
    Protected Friend Neighbours As Node()
    Sub New(index As Integer, row As Integer, column As Integer, x As Integer, y As Integer, w As Integer, h As Integer, Optional Access As Accessibility = Accessibility.Open)
        Me.Index = index
        Me.Row = row
        Me.Column = column
        Me.Access = Access
        Me.Neighbours = New Node(3) {}
        Me.Pencil = New Pen(Brushes.White, 2)
        Me.Dimensions = New Rectangle(x, y, w, h)
    End Sub
    Public Sub Draw(g As Graphics)
        For index As Integer = 0 To Me.Neighbours.Count - 1
            If (Me.HasNeighbourAt(index)) Then
                Me.Draw(g, CType(index, Direction))
            End If
        Next
    End Sub
    Public Sub Draw(g As Graphics, dir As Direction, Optional offset As Integer = 0)
        Select Case dir
            Case Direction.North : g.DrawLine(Me.Pencil, Me.Dimensions.Left + offset, Me.Dimensions.Top + offset, Me.Dimensions.Right - offset, Me.Dimensions.Top + offset)
            Case Direction.South : g.DrawLine(Me.Pencil, Me.Dimensions.Left + offset, Me.Dimensions.Bottom - offset, Me.Dimensions.Right - offset, Me.Dimensions.Bottom - offset)
            Case Direction.East : g.DrawLine(Me.Pencil, Me.Dimensions.Right - offset, Me.Dimensions.Top + offset, Me.Dimensions.Right - offset, Me.Dimensions.Bottom - offset)
            Case Direction.West : g.DrawLine(Me.Pencil, Me.Dimensions.Left + offset, Me.Dimensions.Top + offset, Me.Dimensions.Left + offset, Me.Dimensions.Bottom - offset)
        End Select
    End Sub
    Public Function IsAccessible(target As Node) As Boolean
        Return Me.Neighbours.Any(Function(n) n Is target AndAlso n.Parent Is Me)
    End Function
    Public Function IsInside(point As Point) As Boolean
        Return Me.Dimensions.Contains(point)
    End Function
    Public Function GetNeighbourAt(direction As Direction) As Node
        Return Me.GetNeighbourAt(CType(direction, Integer))
    End Function
    Public Function GetNeighbourAt(index As Integer) As Node
        If (Me.Neighbours(index) IsNot Nothing) Then
            Return Me.Neighbours(index)
        End If
        Return Nothing
    End Function
    Public Function GetNeighbours() As Node()
        Return Me.Neighbours.Where(Function(n) n IsNot Nothing).ToArray
    End Function
    Public Function HasNeighbourAt(direction As Direction) As Boolean
        Return Me.HasNeighbourAt(CType(direction, Integer))
    End Function
    Public Function HasNeighbourAt(index As Integer) As Boolean
        Return Me.Neighbours(index) Is Nothing OrElse
               Me.Neighbours(index).Parent IsNot Me AndAlso
               Me.Neighbours(index) IsNot Me.Parent
    End Function
    Public Function GetDistance(target As Node) As Double
        Return Math.Sqrt(Math.Pow(Math.Abs(Me.Center.X - target.Center.X), 2) + Math.Pow(Math.Abs(Me.Center.Y - target.Center.Y), 2))
    End Function
    Public Overrides Function ToString() As String
        Return String.Format("Node {0}", Me.Index)
    End Function
    Public ReadOnly Property Center As Point
        Get
            Return New Point(Me.Dimensions.Left + Me.Dimensions.Width \ 2, Me.Dimensions.Top + Me.Dimensions.Height \ 2)
        End Get
    End Property
End Class