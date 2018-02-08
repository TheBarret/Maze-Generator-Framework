Imports Maze

Public Class frmMain
    Private Property Maze As Maze.Generator
    Private Property DoUpdate As Boolean
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DoUpdate = False
        Me.Maze = New Maze.Generator(Me.Scroller.Value, Me.Scroller.Value, Me.Canvas.Size)
        Me.Redraw()
    End Sub
    Private Sub btnRandomize_Click(sender As Object, e As EventArgs) Handles btnRandomize.Click
        Me.Redraw()
    End Sub
    Private Sub cbAutoSolve_CheckedChanged(sender As Object, e As EventArgs) Handles cbAutoSolve.CheckedChanged
        Me.DoUpdate = True
        Me.Refresh()
    End Sub
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        If (Me.DoUpdate) Then
            Using bm As New Bitmap(Me.Canvas.Width, Me.Canvas.Height)
                Using g As Graphics = Graphics.FromImage(bm)

                    g.Clear(Color.CornflowerBlue)
                    g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality

                    '// Draw maze
                    Me.Maze.Draw(g)

                    '// Auto solve?
                    If (Me.cbAutoSolve.Checked) Then
                        Dim solution As New List(Of Node)
                        If (Me.Maze.Solve(Me.Maze.First, Me.Maze.Last, solution)) Then
                            g.DrawLines(Pens.Red, solution.Select(Function(x) x.Center).ToArray)
                        End If
                    End If

                End Using

                '// Copy to control
                Me.Canvas.BackgroundImage = CType(bm.Clone, Image)
            End Using
            Me.DoUpdate = False
        End If
        MyBase.OnPaint(e)
    End Sub
    Private Sub Scroller_ValueChanged(sender As Object, e As EventArgs) Handles Scroller.ValueChanged
        '// Prevent NullReference when initializing form
        If (Me.Maze IsNot Nothing) Then Me.Redraw()
    End Sub
    Private Sub Redraw()
        Me.DoUpdate = True
        Me.Maze.NodesX = Me.Scroller.Value
        Me.Maze.NodesY = Me.Scroller.Value
        Me.Maze.Randomize()
        Me.Refresh()
    End Sub
End Class
