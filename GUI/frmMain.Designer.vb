<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Canvas = New System.Windows.Forms.PictureBox()
        Me.Scroller = New System.Windows.Forms.HScrollBar()
        Me.btnRandomize = New System.Windows.Forms.Button()
        Me.cbAutoSolve = New System.Windows.Forms.CheckBox()
        CType(Me.Canvas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Canvas
        '
        Me.Canvas.Location = New System.Drawing.Point(12, 12)
        Me.Canvas.Name = "Canvas"
        Me.Canvas.Size = New System.Drawing.Size(500, 500)
        Me.Canvas.TabIndex = 0
        Me.Canvas.TabStop = False
        '
        'Scroller
        '
        Me.Scroller.LargeChange = 2
        Me.Scroller.Location = New System.Drawing.Point(9, 531)
        Me.Scroller.Maximum = 25
        Me.Scroller.Minimum = 2
        Me.Scroller.Name = "Scroller"
        Me.Scroller.Size = New System.Drawing.Size(283, 31)
        Me.Scroller.TabIndex = 1
        Me.Scroller.Value = 10
        '
        'btnRandomize
        '
        Me.btnRandomize.Location = New System.Drawing.Point(295, 531)
        Me.btnRandomize.Name = "btnRandomize"
        Me.btnRandomize.Size = New System.Drawing.Size(114, 31)
        Me.btnRandomize.TabIndex = 2
        Me.btnRandomize.Text = "Randomize"
        Me.btnRandomize.UseVisualStyleBackColor = True
        '
        'cbAutoSolve
        '
        Me.cbAutoSolve.Appearance = System.Windows.Forms.Appearance.Button
        Me.cbAutoSolve.Location = New System.Drawing.Point(415, 531)
        Me.cbAutoSolve.Name = "cbAutoSolve"
        Me.cbAutoSolve.Size = New System.Drawing.Size(101, 31)
        Me.cbAutoSolve.TabIndex = 3
        Me.cbAutoSolve.Text = "Auto Solve"
        Me.cbAutoSolve.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cbAutoSolve.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(528, 577)
        Me.Controls.Add(Me.cbAutoSolve)
        Me.Controls.Add(Me.btnRandomize)
        Me.Controls.Add(Me.Scroller)
        Me.Controls.Add(Me.Canvas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Maze"
        CType(Me.Canvas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Canvas As System.Windows.Forms.PictureBox
    Friend WithEvents Scroller As System.Windows.Forms.HScrollBar
    Friend WithEvents btnRandomize As System.Windows.Forms.Button
    Friend WithEvents cbAutoSolve As System.Windows.Forms.CheckBox

End Class
