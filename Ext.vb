Public Module Ext
    <Runtime.CompilerServices.Extension>
    Public Function Pop(src As List(Of Link), index As Integer) As Link
        Dim link As Link = src(index)
        src.RemoveAt(index)
        Return link
    End Function
    <Runtime.CompilerServices.Extension>
    Public Function AsDestination(link As Link) As Node
        Dim node As Node = link.Destination
        link.Destination.Parent = link.Source
        Return node
    End Function
    <Runtime.CompilerServices.Extension>
    Public Function HasParent(n As Node) As Boolean
        Return n.Parent IsNot Nothing
    End Function
End Module
