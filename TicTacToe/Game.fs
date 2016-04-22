module Game
open CleanInput
open TicTacToeBoxEdit
open AI
open CheckForWinnerOrTie
open ScreenEdit
open UserSettings

exception GameStillInSession of string

let isGameOver(ticTacToeBox : array<string>) : bool =
    if checkForWinnerOrTie(ticTacToeBox) = int Result.NoWinner then
        false
    else
        true

let gameEndingMessage(ticTacToeBox : array<string>) : string =
    let mutable message = ""
    let endResult = checkForWinnerOrTie(ticTacToeBox)
    if endResult = int Result.AiWins then
        message <- "AI Won"
    elif endResult = int Result.HumanWins then
        message <- "Human Won"
    elif endResult = int Result.Tie then
        message <- "Tie" 
    else
        raise(GameStillInSession("Game is still going"))
    message

let startGame () = 
    let mutable userOption = userSetting([|"1"; "2"; "3"; "4"; "5"; "6"; "7"; "8"; "9"|])
    let mutable message = ""
    while not (isGameOver(userOption.ticTacToeBox)) do
        try
            writeToScreen(userOption.ticTacToeBox) (message)
            printf "Input: "
            userOption.ticTacToeBox <- InsertUserOption (userOption.ticTacToeBox) (Sanitize (System.Console.ReadLine()))           
            
            if not (isGameOver(userOption.ticTacToeBox)) then
                userOption.ticTacToeBox <- AIMove (userOption.ticTacToeBox)
            if isGameOver(userOption.ticTacToeBox) then
                writeToScreen(userOption.ticTacToeBox) (gameEndingMessage(userOption.ticTacToeBox))
            message <- ""
        with
            | :? NonIntError -> message <- "Invaild Number"
            | :? OutOfBoundsOverFlow ->  message <- "Value to large"
            | :? OutOfBoundsUnderFlow -> message <- "Value to small"
            | :? SpotAlreayTaken -> message <- "Spot Taken"
