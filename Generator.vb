Imports System.Drawing

<Serializable>
Public Class Generator
    Implements IDisposable
    Public Property Nodes As Node(,)
    Public Property Height As Integer
    Public Property Width As Integer
    Protected Friend NodeWidth As Integer
    Protected Friend NodeHeight As Integer
    Protected Friend NodeXmin As Integer
    Protected Friend NodeYmin As Integer
    Protected Friend Bounds As Size
    Protected Friend Randomizer As Random
    Sub New(Height As Integer, Width As Integer, Bounds As Size)
        Me.Randomizer = New Random(Me.GetHashCode)
        Me.Height = Height
        Me.Width = Width
        Me.Bounds = Bounds
        Me.Randomize()
    End Sub
    Public Sub Draw(g As Graphics)
        For y As Integer = 0 To Me.Nodes.GetUpperBound(0)
            For x As Integer = 0 To Me.Nodes.GetUpperBound(1)
                Me.Nodes(y, x).Draw(g)
            Next
        Next
    End Sub
    Public Sub Randomize()
        Me.NodeWidth = Me.Bounds.Width \ (Me.Width + 2)
        Me.NodeHeight = Me.Bounds.Height \ (Me.Height + 2)
        Me.NodeXmin = (Me.Bounds.Width - Me.Width * Me.NodeWidth) \ 2
        Me.NodeYmin = (Me.Bounds.Height - Me.Height * Me.NodeHeight) \ 2
        Me.Nodes = Me.CreateNodes(Me.Width, Me.Height)
        Me.Nodes(0, 0).Parent = Me.Nodes(0, 0)
        Me.CreateWalls(Me.Nodes(0, 0))
    End Sub
    Private Function CreateNodes(w As Integer, h As Integer) As Node(,)
        Dim nodes As Node(,) = New Node(h - 1, w - 1) {}, y As Integer, x As Integer, c As Integer = 1
        For row As Integer = 0 To h - 1
            y = Me.NodeYmin + Me.NodeHeight * row
            For column As Integer = 0 To w - 1
                x = Me.NodeXmin + Me.NodeWidth * column
                nodes(row, column) = New Node(Me, c, row, column, x, y, Me.NodeWidth, Me.NodeHeight)
                c += 1
            Next
        Next
        For row As Integer = 0 To h - 1
            For column As Integer = 0 To w - 1
                If (row > 0) Then
                    nodes(row, column).Neighbours(Direction.North) = nodes(row - 1, column)
                End If
                If (row < h - 1) Then
                    nodes(row, column).Neighbours(Direction.South) = nodes(row + 1, column)
                End If
                If (column > 0) Then
                    nodes(row, column).Neighbours(Direction.West) = nodes(row, column - 1)
                End If
                If (column < w - 1) Then
                    nodes(row, column).Neighbours(Direction.East) = nodes(row, column + 1)
                End If
            Next
        Next
        Return nodes
    End Function
    Private Sub CreateWalls(source As Node)
        Dim buffer As New List(Of Link), index As Integer, current As Link, target As Node

        For Each n As Node In source.Neighbours
            If (n IsNot Nothing) Then
                buffer.Add(New Link(source, n))
            End If
        Next
        Do
            index = Me.Randomizer.Next(0, buffer.Count)
            current = buffer(index)
            buffer.RemoveAt(index)
            target = current.Destination
            current.Destination.Parent = current.Source

            For i As Integer = buffer.Count - 1 To 0
                If (buffer(i).Destination.Parent IsNot Nothing) Then
                    buffer.RemoveAt(i)
                End If
            Next
            For Each node As Node In target.Neighbours
                If (node IsNot Nothing AndAlso node.Parent Is Nothing) Then
                    buffer.Add(New Link(target, node))
                End If
            Next
        Loop While buffer.Count > 0
    End Sub
#Region "IDisposable Support"
    Private disposedValue As Boolean
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                Erase Me.Nodes
            End If
        End If
        Me.disposedValue = True
    End Sub
    Public Sub Dispose() Implements IDisposable.Dispose
        Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
End Class
