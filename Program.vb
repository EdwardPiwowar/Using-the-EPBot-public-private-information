Imports System
Imports System.Runtime.CompilerServices

Module Program
    Sub Main(args As String())
        Dim i As Long, j As Integer, k As Integer, n As Integer
        Dim str_hand As String
        Dim suits()() As String
        Dim arr_leads() As String
        Dim arr_leaders() As Integer
        Dim info() As Integer
        Dim info_min() As Integer
        Dim info_max() As Integer
        ReDim hand(3)
        ReDim suits(3)
        ReDim arr_leads(63)
        ReDim arr_leaders(51)

        For k = 0 To 3
            ReDim hand(k).suit(3)
        Next
        For k = 0 To 3
            Player(k) = New EPBot86.EPBot
            'Player(k) = New EPBot64.EPBot
            'Player(k) = New EPBotARM64.EPBot
        Next k

        set_board()
        set_dealers()
        set_vulnerability()
        set_strain_mark()



        vulnerable = 3
        deal = 1
        dealer = 0

        ReDim arr_bids(63)
        arr_bids(0) = "00"
        arr_bids(1) = "08"
        arr_bids(2) = "00"
        arr_bids(3) = "14*Jacoby 2NT"
        arr_bids(4) = "00"
        arr_bids(5) = "16*shortness  !D"
        arr_bids(6) = "01"
        arr_bids(7) = "20*Cue bid, a !C stopper"
        arr_bids(8) = "00"
        arr_bids(9) = "24*Blackwood 0314, for !S"
        arr_bids(10) = "00"
        arr_bids(11) = "25*A=0/5 or 3/5"
        arr_bids(12) = "00"
        arr_bids(13) = "33"
        arr_bids(14) = "00"
        arr_bids(15) = "00"
        arr_bids(16) = "00"

        For k = 0 To 3
            With Player(k)
                'IMPORTANT - it is required to establish a system for both lines
                .system_type(0) = T_21GF
                .system_type(1) = T_21GF
                'set hand
                '.new_hand(k, hand(k).suit, dealer, vulnerable)
                ''set the entire auction
                .set_arr_bids(arr_bids)
                Console.WriteLine("Player " & k)
                For n = 0 To 3
                    Console.WriteLine("Position " & n)
                    info = .info_feature(n)
                    Console.WriteLine("HCP " & info(402) & "-" & info(403))
                    info_min = .info_min_length(n)
                    info_max = .info_max_length(n)
                    For i = 0 To 3
                        Console.WriteLine("Length " & info_min(i) & "-" & info_max(i))
                    Next i
                Next n


                Console.WriteLine("")
            End With
            Console.WriteLine("")
        Next k
        Console.ReadKey()
        Console.WriteLine("")
    End Sub
End Module
