Imports System
Imports System.Runtime.CompilerServices

Module Program
    Sub Main(args As String())
        Dim j As Integer, k As Integer, n As Integer, position As Integer, new_bid As Integer
        Dim str_hand As String, entered_hand As String
        Dim suits()() As String
        Dim arr_leads() As String
        Dim arr_leaders() As Integer
        Dim arr_suits() As String
        Dim info() As Integer
        ReDim hand(3)
        ReDim suits(3)
        ReDim arr_bids(63)
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
        Console.WriteLine("Enter another deal or skip")
        entered_hand = Console.ReadLine()
        Console.WriteLine("Entered deal: " & str_hand)
        set_hand(str_hand)
        vulnerable = 0
        deal = 1
        For position = 0 To 2 Step 2
            Console.WriteLine("")

            dealer = (position + 1) Mod 4
            For k = 0 To 3
                n = (k + position) Mod 4
                Player(k).new_hand(k, hand(n).suit, dealer, vulnerable)
            Next k
            Console.WriteLine("position = " & CStr(position))
            Console.WriteLine("dealer = " & CStr(dealer))
            bid()
            Console.WriteLine("W" + vbTab + "N" + vbTab + "E" + vbTab + "S" + vbTab)
            Console.WriteLine(bidding_body)
            Console.WriteLine("")
            Console.WriteLine("Player cards visible from position: " & CStr(position))

            k = position
            n = (k + position) Mod 4
            With Player(k)
                'set hand
                .new_hand(k, hand(n).suit, dealer, vulnerable)
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
        Next position
        Console.ReadKey()
        Console.WriteLine("")
    End Sub
End Module
