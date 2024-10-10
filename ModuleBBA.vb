Module ModuleBBA
    Public Const C_PASS As Integer = 0
    Public Const C_CLUBS As Integer = 0
    Public Const C_DIAMONDS As Integer = 1
    Public Const C_HEARTS As Integer = 2
    Public Const C_SPADES As Integer = 3
    Public Const C_NT As Integer = 4
    Public Const C_NORTH As Integer = 0
    Public Const C_EAST As Integer = 1
    Public Const C_SOUTH As Integer = 2
    Public Const C_WEST As Integer = 3
    Public Const C_NONE As Integer = 0
    Public Const C_NS As Integer = 2
    Public Const C_WE As Integer = 1
    Public Const C_BOTH As Integer = 3
    Public Const C_FIVE As Integer = 5
    Public Const C_LONGER As String = "AKQJT98765432"
    Public Const C_INTERPRETED As Long = 13
    Public Const F_MIN_HCP As Integer = 102
    Public Const F_MAX_HCP As Integer = 103
    Public Const F_MIN_PKT As Integer = 104
    Public Const F_MAX_PKT As Integer = 105
    Public board(0 To 3, 0 To 3) As Integer
    Public dealers(0 To 15) As Integer
    Public vulnerability(15) As Integer
    Public strain_mark(5) As String
    Public Structure TYPE_HAND
        Dim suit() As String
    End Structure

    Public Sub set_board()
        '---standard number of a board
        board(C_NORTH, C_NONE) = 1
        board(C_EAST, C_NS) = 2
        board(C_SOUTH, C_WE) = 3
        board(C_WEST, C_BOTH) = 4
        board(C_NORTH, C_NS) = 5
        board(C_EAST, C_WE) = 6
        board(C_SOUTH, C_BOTH) = 7
        board(C_WEST, C_NONE) = 8
        board(C_NORTH, C_WE) = 9
        board(C_EAST, C_BOTH) = 10
        board(C_SOUTH, C_NONE) = 11
        board(C_WEST, C_NS) = 12
        board(C_NORTH, C_BOTH) = 13
        board(C_EAST, C_NONE) = 14
        board(C_SOUTH, C_NS) = 15
        board(C_WEST, C_WE) = 16
    End Sub
    Public Sub set_dealers()
        Dim k As Integer
        For k = 0 To 12 Step 4
            dealers(0 + k) = C_NORTH
            dealers(1 + k) = C_EAST
            dealers(2 + k) = C_SOUTH
            dealers(3 + k) = C_WEST
        Next k
    End Sub
    Public Sub set_vulnerability()
        vulnerability(0) = C_NONE
        vulnerability(1) = C_NS
        vulnerability(2) = C_WE
        vulnerability(3) = C_BOTH
        vulnerability(4) = C_NS
        vulnerability(5) = C_WE
        vulnerability(6) = C_BOTH
        vulnerability(7) = C_NONE
        vulnerability(8) = C_WE
        vulnerability(9) = C_BOTH
        vulnerability(10) = C_NONE
        vulnerability(11) = C_NS
        vulnerability(12) = C_BOTH
        vulnerability(13) = C_NONE
        vulnerability(14) = C_NS
        vulnerability(15) = C_WE
    End Sub
    Public Sub set_strain_mark()
        strain_mark(C_CLUBS) = "C"
        strain_mark(C_DIAMONDS) = "D"
        strain_mark(C_HEARTS) = "H"
        strain_mark(C_SPADES) = "S"
        strain_mark(C_NT) = "N"
        strain_mark(5) = ""
    End Sub









End Module
