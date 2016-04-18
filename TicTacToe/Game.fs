module Game
open CleanInput
open TicTacToeBoxEdit
open AI
open CheckForWinnerOrTie

let writeToScreen(ticTacToeBox : array<string>) (message : string) =
    System.Console.Clear()
    printfn "%s" message
    printfn "------------------------"
    printfn "|  %s   |   %s   |   %s   |" (string ticTacToeBox.[0]) (string ticTacToeBox.[1]) (string ticTacToeBox.[2])
    printfn "------------------------"
    printfn "|  %s   |   %s   |   %s   |" (string ticTacToeBox.[3]) (string ticTacToeBox.[4]) (string ticTacToeBox.[5])
    printfn "------------------------"
    printfn "|  %s   |   %s   |   %s   |" (string ticTacToeBox.[6]) (string ticTacToeBox.[7]) (string ticTacToeBox.[8])
    printfn "------------------------"

let startGame () = 
    let mutable gameNotOver = true
    let mutable endResult = -1
    let mutable firstMove = true
    let mutable startConnor = false
    let mutable userInput = 0
    let mutable ticTacToeBox = [|"1"; "2"; "3"; "4"; "5"; "6"; "7"; "8"; "9"|]
    let mutable message = ""
    while gameNotOver do
        try
            writeToScreen(ticTacToeBox) (message)
            printf "Input: "
            userInput <- Sanitize (System.Console.ReadLine())
            ticTacToeBox <- InsertUserOption (ticTacToeBox) (userInput)
            endResult <- checkForWinnerOrTie(ticTacToeBox)
            if not (endResult = int Result.NoWinner) then
                gameNotOver <- false
            else
                if firstMove then
                    if ticTacToeBox.[0] = "X" || ticTacToeBox.[2] = "X" 
                    || ticTacToeBox.[6] = "X"  || ticTacToeBox.[8] = "X" then
                        startConnor <- true
                ticTacToeBox <- AIMove (ticTacToeBox) (userInput-1) (firstMove) ( startConnor )
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
                writeToScreen(ticTacToeBox) (message)
            firstMove <- false
            message <- ""
        with
            | :? NonIntError -> message <- "Invaild Number"
            | :? OutOfBoundsOverFlow ->  message <- "Value to large"
            | :? OutOfBoundsUnderFlow -> message <- "Value to small"
            | :? SpotAlreayTaken -> message <- "Spot Taken"


