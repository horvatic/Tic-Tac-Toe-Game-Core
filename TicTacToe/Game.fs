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
    if checkForWinnerOrTie(ticTacToeBox) = int GenResult.NoWinner then
        false
    else
        true

let gameEndingMessage(ticTacToeBox : array<string>) : string =
    let mutable message = ""
    let endResult = checkForWinnerOrTie(ticTacToeBox)
    if endResult = getWinningAIValue(ticTacToeBox) then
        message <- "AI Won"
    elif endResult = getWinningHumanValue(ticTacToeBox) then
        message <- "Human Won"
    elif endResult = int GenResult.Tie then
        message <- "Tie" 
    else
        raise(GameStillInSession("Game is still going"))
    message

let startGame (gameOption : gameSetting) : int =
    let mutable game = gameOption
    let mutable currentPlayer = game.firstPlayer
    let mutable message = ""
    let mutable userError = false
    if not game.aIvAI then
        System.Console.Clear()
        printfn "Starting game..."
    while not (isGameOver(game.ticTacToeBox)) do
        try
            if not game.aIvAI then
                if game.firstPlayer = int playerVals.Human then
                    writeToScreen(game.ticTacToeBox) (message)
                    printf "Input: "
                    game.ticTacToeBox <- InsertUserOption (game.ticTacToeBox) 
                                            (SanitizeHumanPickedPlace 
                                            (System.Console.ReadLine())
                                            (game.ticTacToeBox.Length))   
                 else
                    if not userError then
                        game.ticTacToeBox <- AIMove (game.ticTacToeBox)
            else
                game.ticTacToeBox <- InsertUserOption (game.ticTacToeBox)(aIPlayer(game.ticTacToeBox) + 1)
            
            if not (isGameOver(game.ticTacToeBox)) then
                if game.firstPlayer = int playerVals.Human && not userError then
                    game.ticTacToeBox <- AIMove (game.ticTacToeBox)
                else
                    writeToScreen(game.ticTacToeBox) (message)
                    printf "Input: "
                    game.ticTacToeBox <- InsertUserOption (game.ticTacToeBox) 
                                            (SanitizeHumanPickedPlace 
                                            (System.Console.ReadLine())
                                            (game.ticTacToeBox.Length))
            if isGameOver(game.ticTacToeBox) then
                if not game.aIvAI then
                    writeToScreen(game.ticTacToeBox) (gameEndingMessage(game.ticTacToeBox))
            message <- ""
            userError <- false
        with
            | :? NonIntError -> message <- "Invaild Number"; userError <- true
            | :? OutOfBoundsOverFlow ->  message <- "Value to large"; userError <- true
            | :? OutOfBoundsUnderFlow -> message <- "Value to small"; userError <- true
            | :? SpotAlreayTaken -> message <- "Spot Taken"; userError <- true
    
    checkForWinnerOrTie(game.ticTacToeBox)