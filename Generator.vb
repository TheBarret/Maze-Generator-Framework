﻿Imports System.Drawing
Imports System.Security.Cryptography
Imports Maze.Algorithms

Public Class Generator
    Inherits Solver
    Implements IDisposable
    Public Property Nodes As Node(,)
    Public Property NodesY As Integer
    Public Property NodesX As Integer
    Protected Friend NodeWidth As Integer
    Protected Friend NodeHeight As Integer
    Protected Friend NodeXmin As Integer
    Protected Friend NodeYmin As Integer
    Protected Friend Bounds As Size
    Protected Friend Randomizer As Random
    Sub New(NodesX As Integer, NodesY As Integer, Bounds As Size)
        Me.Randomizer = New Random(Generator.Seed)
        Me.NodesY = NodesY
        Me.NodesX = NodesX
        Me.Bounds = Bounds
        Me.Randomize()
    End Sub
    Public Sub Draw(g As Graphics, Optional grid As Boolean = False)
        For y As Integer = 0 To Me.Nodes.GetUpperBound(0)
            For x As Integer = 0 To Me.Nodes.GetUpperBound(1)
                Me.Nodes(y, x).Draw(g, grid)
                If (Me.Nodes(y, x) Is Me.First) Then
                    g.FillEllipse(Brushes.Green, Me.Nodes(y, x).Center.X - 2, Me.Nodes(y, x).Center.Y - 2, 4, 4)
                ElseIf (Me.Nodes(y, x) Is Me.Last) Then
                    g.FillEllipse(Brushes.Red, Me.Nodes(y, x).Center.X - 2, Me.Nodes(y, x).Center.Y - 2, 4, 4)
                End If
            Next
        Next
    End Sub
    Public Sub Randomize()
        Me.NodeWidth = Me.Bounds.Width \ (Me.NodesX + 2)
        Me.NodeHeight = Me.Bounds.Height \ (Me.NodesY + 2)
        Me.NodeXmin = (Me.Bounds.Width - Me.NodesX * Me.NodeWidth) \ 2
        Me.NodeYmin = (Me.Bounds.Height - Me.NodesY * Me.NodeHeight) \ 2
        Me.Nodes = Me.CreateNodes(Me.NodesX, Me.NodesY)
        Me.CreateMaze(AddressOf Backtrack.Build, Me.First)
    End Sub
    Private Function CreateNodes(w As Integer, h As Integer) As Node(,)
        Dim nodes As Node(,) = New Node(h - 1, w - 1) {}, y As Integer, x As Integer, c As Integer = 1
        For row As Integer = 0 To h - 1
            y = Me.NodeYmin + Me.NodeHeight * row
            For column As Integer = 0 To w - 1
                x = Me.NodeXmin + Me.NodeWidth * column
                nodes(row, column) = New Node(c, row, column, x, y, Me.NodeWidth, Me.NodeHeight)
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
    Private Sub CreateMaze(algorithm As Action(Of Generator, Node), start As Node)
        algorithm(Me, start)
    End Sub
    Private Shared Function Seed() As Int32
        Using rng As New RNGCryptoServiceProvider
            Dim output() As Byte = New Byte(3) {}
            rng.GetBytes(output)
            Return BitConverter.ToInt32(output, 0)
        End Using
    End Function
    Public ReadOnly Property First As Node
        Get
            Return Me.Nodes(0, 0)
        End Get
    End Property
    Public ReadOnly Property Last As Node
        Get
            Return Me.Nodes(Me.Nodes.GetUpperBound(0), Me.Nodes.GetUpperBound(1))
        End Get
    End Property
    Public ReadOnly Property Count As Integer
        Get
            Return Me.Nodes.GetUpperBound(0) * Me.Nodes.GetUpperBound(1)
        End Get
    End Property
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
