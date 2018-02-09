Public Enum MazeAlgorithm
    DepthFirst = 0
    BackTracker
    Kruskal
    Prim
    Division
End Enum
Public Enum Direction As Int32
    North = 0
    South = 1
    East = 2
    West = 3
End Enum
Public Enum Accessibility As Int32
    Open = 0
    Closed = 1
    Start = 2
    Destination = 3
    Solid = 4
End Enum