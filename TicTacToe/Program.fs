open CleanInput
open TicTacToeBoxEdit
open AI
open CheckForWinnerOrTie

let startGame () = 
    let mutable gameNotOver = true
    let mutable endResult = -1
    let mutable firstMove = true
    let mutable userInput = 0
    let mutable ticTacToeBox = [|"1"; "2"; "3"; "4"; "5"; "6"; "7"; "8"; "9"|]
    let mutable message = ""
    while gameNotOver do
        try
            System.Console.Clear()
            printfn "%s" message
            printfn "------------------------"
            printfn "|  %s   |   %s   |   %s   |" (string ticTacToeBox.[0]) (string ticTacToeBox.[1]) (string ticTacToeBox.[2])
            printfn "------------------------"
            printfn "|  %s   |   %s   |   %s   |" (string ticTacToeBox.[3]) (string ticTacToeBox.[4]) (string ticTacToeBox.[5])
            printfn "------------------------"
            printfn "|  %s   |   %s   |   %s   |" (string ticTacToeBox.[6]) (string ticTacToeBox.[7]) (string ticTacToeBox.[8])
            printfn "------------------------"
            printf "Input: "
            userInput <- Sanitize (System.Console.ReadLine())
            ticTacToeBox <- InsertUserOption (ticTacToeBox) (userInput)
            endResult <- checkForWinnerOrTie(ticTacToeBox)
            if not (endResult = int Result.NoWinner) then
                gameNotOver <- false
            else
                ticTacToeBox <- AIMove (ticTacToeBox) (userInput-1) (firstMove)
                endResult <- checkForWinnerOrTie(ticTacToeBox)
                if not (endResult = int Result.NoWinner) then
                    gameNotOver <- false

            if not gameNotOver then
                if endResult = int Result.AiWins then
                    message <- "AI Won"
                elif endResult = int Result.HumanWins then
                    message <- "Human Won"
                elif endResult = int Result.Tie then
                    message <- "Tie"
                System.Console.Clear()
                printfn "%s" message
                printfn "------------------------"
                printfn "|  %s   |   %s   |   %s   |" (string ticTacToeBox.[0]) (string ticTacToeBox.[1]) (string ticTacToeBox.[2])
                printfn "------------------------"
                printfn "|  %s   |   %s   |   %s   |" (string ticTacToeBox.[3]) (string ticTacToeBox.[4]) (string ticTacToeBox.[5])
                printfn "------------------------"
                printfn "|  %s   |   %s   |   %s   |" (string ticTacToeBox.[6]) (string ticTacToeBox.[7]) (string ticTacToeBox.[8])
                printfn "------------------------"
            firstMove <- false
            message <- ""
        with
            | :? NonIntError -> message <- "Invaild Number"
            | :? OutOfBoundsOverFlow ->  message <- "Value to large"
            | :? OutOfBoundsUnderFlow -> message <- "Value to small"
            | :? SpotAlreayTaken -> message <- "Spot Taken"

[<EntryPoint>]
let main argv =
    let mutable playgame = true
    let mutable input = ""
    while playgame do
        startGame()
        printf "Another Game? Y/N: "
        input <- System.Console.ReadLine()
        if not (input = "Y" || input = "y") then
            playgame <- false

    0 // return an integer exit code

