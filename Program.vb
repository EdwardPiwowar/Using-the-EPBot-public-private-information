Imports System
''EPBot is a namespace 
Module Program

    Sub Main(args As String())
        Dim k As Integer, position As Integer, dealer As Integer, vulnerability As Integer, new_bid As Integer
        Dim str_hand As String
        Dim blocks() As String
        Dim subblocks() As String
        Dim suits()() As String
        Dim hand() As TYPE_HAND
        Dim Player(3) As EPBot86.EPBot
        ''Dim Player(3) As EPBot64.EPBot
        ''Dim Player(3) As EPBotARM64.EPBot
        Dim arr_bids() As String
        Dim arr_leads() As String
        Dim arr_leaders() As Integer
        Dim arr_suits() As String
        ReDim hand(3)
        ReDim suits(3)

        For k = 0 To 3
            ReDim hand(k).suit(3)
        Next

        set_board()
        set_dealers()
        set_vulnerability()
        set_strain_mark()

        '---example hand
        str_hand = "Q.K6.AQT6.KQT852 T642.Q982.842.73 AK85.T5.J975.AJ6 J973.AJ743.K3.94"

        Console.WriteLine("Enter hand")
        str_hand = Console.ReadLine()
        Console.WriteLine("Entered hand: " & str_hand)

        blocks = Split(str_hand, " ")
        For k = 0 To 3
            subblocks = Split(blocks(k), ".")
            For i = 0 To 3
                hand(k).suit(i) = subblocks(3 - i)
            Next i
        Next k

        Console.WriteLine("")
        Console.WriteLine("Entered hands:")
        Console.WriteLine("")

        For i = C_SPADES To C_CLUBS Step -1
            Console.WriteLine(vbTab + hand(0).suit(i))
        Next i
        Console.WriteLine("")
        For i = C_SPADES To C_CLUBS Step -1
            Console.WriteLine(hand(3).suit(i) + vbTab + vbTab + hand(1).suit(i))
        Next i
        Console.WriteLine("")
        For i = C_SPADES To C_CLUBS Step -1
            Console.WriteLine(vbTab + hand(2).suit(i))
        Next i
        Console.WriteLine("")



        '---example
        position = C_NORTH
        dealer = C_EAST
        vulnerability = 1


        For k = 0 To 3
            Player(k) = New EPBot86.EPBot
            'Player(k) = New EPBot64.EPBot
            'Player(k) = New EPBotARM64.EPBot
        Next k

        With Player(position)
            .new_hand(position, hand(position).suit, dealer, vulnerability)
            .scoring = 0

            Console.WriteLine("W	N	E	S
		P	1D
1H	2H*1	3H	4D
P	4H*2	X	4S*3
P	5D	P	P
P
*1 limit raise or better in !D
*2 Cue bid, a !H stopper
*3 Cue bid, a !S stopper")


            ReDim arr_bids(63)
            arr_bids(0) = "00"
            arr_bids(1) = "06"
            arr_bids(2) = "07"
            arr_bids(3) = "12*limit raise or better in !D"
            arr_bids(4) = "17"
            arr_bids(5) = "21"
            arr_bids(6) = "00"
            arr_bids(7) = "22*Cue bid, a !H stopper"
            arr_bids(8) = "01"
            arr_bids(9) = "23Cue bid, a !S stopper"
            arr_bids(10) = "00"
            arr_bids(11) = "26"
            arr_bids(12) = "00"
            arr_bids(13) = "00"
            arr_bids(14) = "00"



            ''getting all hands after bidding and during play
            ReDim arr_leads(63)
            ReDim arr_leaders(51)
            For k = 0 To 3
                Console.WriteLine("")
                Console.WriteLine("Player cards visible from position: " & CStr(k))
                'set hand
                .new_hand(k, hand(k).suit, dealer, vulnerability)
                ''set the entire auction
                .set_arr_bids(arr_bids)
                ''optional set dummy
                .set_dummy(2, hand(2).suit)
                ''optional set leads
                arr_leaders(0) = 3
                arr_leads(0) = "AH"
                .set_arr_leads(arr_leaders, arr_leads)
                ''
                new_bid = .get_bid
                ''
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
            Next k
            Console.ReadKey()
        End With
    End Sub
End Module
