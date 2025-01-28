Imports System
Imports System.Runtime.CompilerServices

Module Program
    Sub Main(args As String())
        Dim j As Integer, k As Integer, n As Integer, new_bid As Integer
        Dim str_hand As String, entered_hand As String
        Dim suits()() As String
        Dim arr_leads() As String
        Dim arr_leaders() As Integer
        Dim arr_suits() As String
        'Dim info() As Integer
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

        '---example hand
        str_hand = "53.532.K87.AT872 J82.T84.AQT54.KQ AKQT94.AKQJ9.J9. 76.76.632.J96543"
        Console.WriteLine("Current deal: " & str_hand)
        Do
            Console.WriteLine("Enter another deal or skip")
            entered_hand = Console.ReadLine()
        Loop While Len(entered_hand) <> 0 And Len(entered_hand) <> 67
        If entered_hand = vbNullString Then
            entered_hand = str_hand
        End If
        Console.WriteLine("Entered deal: " & entered_hand)
        Console.WriteLine("")
        set_hand(entered_hand)
        vulnerable = 0
        deal = 1

        For k = 0 To 3
            dealer = (k + 0) Mod 4
            For n = 0 To 3
                'IMPORTANT - it is required to establish a system for both lines
                Player(n).system_type(0) = T_21GF
                Player(n).system_type(1) = T_21GF
                Player(n).new_hand(n, hand((n - k + 4) Mod 4).suit, dealer, vulnerable)
            Next n
            Console.WriteLine("Player cards visible from position: " & CStr(k) & " - dealer = " & CStr(dealer))
            bid()
            'Console.WriteLine(Join(arr_bids, " "))
            Console.WriteLine("W" + vbTab + "N" + vbTab + "E" + vbTab + "S" + vbTab)
            Console.WriteLine(bidding_body)

            With Player(k)
                'IMPORTANT - it is required to establish a system for both lines
                .system_type(0) = T_21GF
                .system_type(1) = T_21GF
                'set hand
                .new_hand(k, hand(0).suit, dealer, vulnerable)
                ''set the entire auction
                .set_arr_bids(arr_bids)

                new_bid = .get_bid
                ''obtain all hands
                arr_suits = .get_arr_suits()
                Console.WriteLine("")
                For i = C_SPADES To C_CLUBS Step -1
                    Console.WriteLine(vbTab + arr_suits(i))
                Next i
                Console.WriteLine("")
                For i = C_SPADES To C_CLUBS Step -1
                    Console.WriteLine(arr_suits(12 + i) + vbTab + vbTab + arr_suits(4 + i))
                Next i
                Console.WriteLine("")
                For i = C_SPADES To C_CLUBS Step -1
                    Console.WriteLine(vbTab + arr_suits(8 + i))
                Next i
                Console.WriteLine("")
            End With
            Console.WriteLine("")
        Next k
        Console.ReadKey()
        Console.WriteLine("")
    End Sub
End Module
