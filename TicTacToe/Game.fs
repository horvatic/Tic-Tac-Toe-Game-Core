module Game
open CleanInput
open TicTacToeBoxEdit
open AI
open CheckForWinnerOrTie
open ScreenEdit

let startGame () = 
    let mutable gameNotOver = true
    let mutable endResult = -1
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
                ticTacToeBox <- AIMove (ticTacToeBox)
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
            message <- ""
        with
            | :? NonIntError -> message <- "Invaild Number"
            | :? OutOfBoundsOverFlow ->  message <- "Value to large"
            | :? OutOfBoundsUnderFlow -> message <- "Value to small"
            | :? SpotAlreayTaken -> message <- "Spot Taken"


