module Game
open CleanInput
open TicTacToeBoxEdit
open AI
open CheckForWinnerOrTie
open ScreenEdit
open GameSettings
open GameStatusCodes
open userInputException
open PlayerValues

exception GameStillInSession of string

let aIPlayer(ticTacToeBox : array<string>) : int =
    let mutable place = 0
    for i = 0 to 8 do
        if ticTacToeBox.[i] = "X" then
            ticTacToeBox.[i] <- "@"
        elif ticTacToeBox.[i] = "@" then
            ticTacToeBox.[i] <- "X"
    place <- computerMove(ticTacToeBox)
    for i = 0 to 8 do
        if ticTacToeBox.[i] = "X" then
            ticTacToeBox.[i] <- "@"
        elif ticTacToeBox.[i] = "@" then
            ticTacToeBox.[i] <- "X"
    place

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

let startGame (gameOption : gameSetting) : int = 
    let mutable game = gameOption
    let mutable currentPlayer = game.firstPlayer
    let mutable message = ""
    while not (isGameOver(game.ticTacToeBox)) do
        try
            if not game.aIvAI then
                if game.firstPlayer = int playerVals.Human then
                    writeToScreen(game.ticTacToeBox) (message)
                    printf "Input: "
                    game.ticTacToeBox <- InsertUserOption (game.ticTacToeBox) 
                                            (SanitizeHumanPickedPlace 
                                            (System.Console.ReadLine()))   
                 else
                    game.ticTacToeBox <- AIMove (game.ticTacToeBox)
            else
                game.ticTacToeBox <- InsertUserOption (game.ticTacToeBox)(aIPlayer(game.ticTacToeBox) + 1)
            
            if not (isGameOver(game.ticTacToeBox)) then
                if game.firstPlayer = int playerVals.Human then
                    game.ticTacToeBox <- AIMove (game.ticTacToeBox)
                else
                    writeToScreen(game.ticTacToeBox) (message)
                    printf "Input: "
                    game.ticTacToeBox <- InsertUserOption (game.ticTacToeBox) 
                                            (SanitizeHumanPickedPlace 
                                            (System.Console.ReadLine()))
            if isGameOver(game.ticTacToeBox) then
                if not game.aIvAI then
                    writeToScreen(game.ticTacToeBox) (gameEndingMessage(game.ticTacToeBox))
            message <- ""
        with
            | :? NonIntError -> message <- "Invaild Number"
            | :? OutOfBoundsOverFlow ->  message <- "Value to large"
            | :? OutOfBoundsUnderFlow -> message <- "Value to small"
            | :? SpotAlreayTaken -> message <- "Spot Taken"
    
    checkForWinnerOrTie(game.ticTacToeBox)