module ScreenEdit
exception InvaildBox of string

let writeToScreen(ticTacToeBox : array<string>) (message : string) =
    if ticTacToeBox.Length = 9 then
        System.Console.Clear()
        printfn "%s" message
        printfn "------------------------"
        printfn "|  %s   |   %s   |   %s   |" (string ticTacToeBox.[0]) (string ticTacToeBox.[1]) (string ticTacToeBox.[2])
        printfn "------------------------"
        printfn "|  %s   |   %s   |   %s   |" (string ticTacToeBox.[3]) (string ticTacToeBox.[4]) (string ticTacToeBox.[5])
        printfn "------------------------"
        printfn "|  %s   |   %s   |   %s   |" (string ticTacToeBox.[6]) (string ticTacToeBox.[7]) (string ticTacToeBox.[8])
        printfn "------------------------"
    
    elif ticTacToeBox.Length = 16 then
        System.Console.Clear()
        printfn "%s" message
        printfn "------------------------------------"
        printfn "|   %s   |   %s   |    %s   |    %s    |" (string ticTacToeBox.[0]) (string ticTacToeBox.[1]) (string ticTacToeBox.[2])(string ticTacToeBox.[3])
        printfn "------------------------------------"
        printfn "|   %s   |   %s   |    %s   |    %s    |" (string ticTacToeBox.[4]) (string ticTacToeBox.[5])(string ticTacToeBox.[6]) (string ticTacToeBox.[7])
        printfn "------------------------------------"
        printfn "|   %s   |  %s  |    %s   |   %s    |" (string ticTacToeBox.[8]) (string ticTacToeBox.[9]) (string ticTacToeBox.[10]) (string ticTacToeBox.[11])
        printfn "------------------------------------"
        printfn "|  %s   |  %s  |    %s   |   %s    |" (string ticTacToeBox.[12]) (string ticTacToeBox.[13]) (string ticTacToeBox.[14]) (string ticTacToeBox.[15])
        printfn "------------------------------------"
    else
        raise(InvaildBox("Box size incorect"))
