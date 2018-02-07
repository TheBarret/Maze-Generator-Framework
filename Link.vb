<Serializable>
Public Class Link
    Public Property Source As Node
    Public Property Destination As Node
    Sub New(Source As Node, Destination As Node)
        Me.Source = Source
        Me.Destination = Destination
    End Sub
    Public Overrides Function ToString() As String
        Return String.Format("{0}->{1}", Me.Source.ToString, Me.Destination.ToString)
    End Function
End Class