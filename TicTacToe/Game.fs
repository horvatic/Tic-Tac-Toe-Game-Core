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
open IInputOutPut
open InputOutPut

exception GameStillInSession of string

let gameEndingMessage( ticTacToeBox : array<string>) 
                     ( playerGlyph : string)
                     ( aIGlyph : string)  : string =
    let endResult = checkForWinnerOrTie(ticTacToeBox)(playerGlyph)(aIGlyph)
    if endResult = getWinningAIValue(ticTacToeBox) then
        "Other Player Won"
    elif endResult = getWinningHumanValue(ticTacToeBox) then
        "Player Won"
    else
        "Tie" 

let isInputANumber(postion : string) : bool =
    try
        let posAsInt = int postion
        true
    with
        | :? System.FormatException -> false


let isOutBounds(arrayLenth : int)(postion : int) : bool =
    if postion > arrayLenth - 1  || postion < 0 then
        true
    else
        false

let isSpotTaken(ticTacToeBox : array<string>)
               (postion : int)
               (playerGlyph : string) 
               (aIGlyph : string)
               : bool =
    if ticTacToeBox.[postion] = playerGlyph || ticTacToeBox.[postion] = aIGlyph then
        true
    else
        false
        
let isUserInputCorrect(ticTacToeBox : array<string>)
                      (postion : string)
                      (playerGlyph : string) 
                      (aIGlyph : string) : string =
    if not (isInputANumber(postion)) then
        "Value not a number"
    elif isOutBounds(ticTacToeBox.Length)(int postion - 1) then
        "Value out of bounds"
    elif isSpotTaken(ticTacToeBox)(int postion - 1)(playerGlyph)(aIGlyph) then
        "Spot Taken"
    else
        ""
let convertStringToInt(pos : string) : int =
    int pos

let userInputEditTicTacToeBox(game : gameSetting)(postion : string) : string = 
    let message = isUserInputCorrect(game.ticTacToeBox)
                    (postion)(game.playerGlyph)(game.aIGlyph)
    if( message = "" ) then
        insertUserOption(game.ticTacToeBox)
                        (convertStringToInt(postion))
                        (game.playerGlyph)
                        (game.aIGlyph)
        ""
    else
        message


let otherUserInputEditTicTacToeBox(game : gameSetting)(postion : string) : string = 
    let message = isUserInputCorrect(game.ticTacToeBox)
                    (postion)(game.playerGlyph)(game.aIGlyph)
    if( message = "" ) then
        insertOtherUserOption(game.ticTacToeBox)
                            (convertStringToInt(postion))
                            (game.playerGlyph)
                            (game.aIGlyph)
        ""
    else
        message

let aIInputEditTicTacToeBox(game : gameSetting) : bool =
    aIMove(game)
    true

let isGameOver(game : gameSetting) : bool =
    if checkForWinnerOrTie(game.ticTacToeBox)(game.playerGlyph)(game.aIGlyph) 
            = int GenResult.NoWinner then
        false
    else
        true

let humanVsAiFirstGame(game : gameSetting) (io : IInputOut) : int =
    aIInputEditTicTacToeBox(game) |> ignore
    writeToScreen(game.ticTacToeBox)(game.inverted)("")(io) |> ignore
    while not (isGameOver(game)) do
        let message = 
            userInputEditTicTacToeBox(game)(io.getUserInput())
        if message = "" 
            && checkForWinnerOrTie(game.ticTacToeBox)(game.playerGlyph)(game.aIGlyph) = int GenResult.NoWinner then
           aIInputEditTicTacToeBox(game) |> ignore
        writeToScreen(game.ticTacToeBox)(game.inverted)(message)(io) |> ignore
    checkForWinnerOrTie(game.ticTacToeBox)(game.playerGlyph)(game.aIGlyph) 

let humanFirstVsAiGame(game : gameSetting) (io : IInputOut) : int =
    writeToScreen(game.ticTacToeBox)(game.inverted)("")(io) |> ignore
    while not (isGameOver(game)) do
        let message = 
            userInputEditTicTacToeBox(game)(io.getUserInput())
        
        if message = "" 
            && checkForWinnerOrTie(game.ticTacToeBox)(game.playerGlyph)(game.aIGlyph) = int GenResult.NoWinner then
           aIInputEditTicTacToeBox(game) |> ignore
        
        writeToScreen(game.ticTacToeBox)(game.inverted)(message)(io) |> ignore
    checkForWinnerOrTie(game.ticTacToeBox)(game.playerGlyph)(game.aIGlyph) 
    
let playerOneTurn(game : gameSetting) (io : IInputOut) : string =
    userInputEditTicTacToeBox(game)(io.getUserInput())

let playerTwoTurn(game : gameSetting) (io : IInputOut) : string =
    otherUserInputEditTicTacToeBox(game)(io.getUserInput())

let playerOneFirstVsHuman(game : gameSetting) (io : IInputOut) : int =
    let mesages = [|""; "";|]
    while not (isGameOver(game)) do
        if mesages.[1] = "" 
            && checkForWinnerOrTie(game.ticTacToeBox)(game.playerGlyph)(game.aIGlyph) = int GenResult.NoWinner then
            writeToScreen(game.ticTacToeBox)(game.inverted)(mesages.[0])(io) |> ignore
            mesages.[0] <- playerOneTurn(game : gameSetting) (io : IInputOut)
        if mesages.[0] = "" 
            && checkForWinnerOrTie(game.ticTacToeBox)(game.playerGlyph)(game.aIGlyph) = int GenResult.NoWinner then
            writeToScreen(game.ticTacToeBox)(game.inverted)(mesages.[1])(io) |> ignore
            mesages.[1] <- playerTwoTurn(game : gameSetting) (io : IInputOut)
    checkForWinnerOrTie(game.ticTacToeBox)(game.playerGlyph)(game.aIGlyph) 

let playerTwoFirstVsHuman(game : gameSetting) (io : IInputOut) : int =
    let mesages = [|""; "";|]
    while not (isGameOver(game)) do
        if mesages.[1] = "" 
            && checkForWinnerOrTie(game.ticTacToeBox)(game.playerGlyph)(game.aIGlyph) = int GenResult.NoWinner then
            writeToScreen(game.ticTacToeBox)(game.inverted)(mesages.[0])(io) |> ignore
            mesages.[0] <- playerTwoTurn(game : gameSetting) (io : IInputOut)
        if mesages.[0] = "" 
            && checkForWinnerOrTie(game.ticTacToeBox)(game.playerGlyph)(game.aIGlyph) = int GenResult.NoWinner then
            writeToScreen(game.ticTacToeBox)(game.inverted)(mesages.[1])(io) |> ignore
            mesages.[1] <- playerOneTurn(game : gameSetting) (io : IInputOut)
    checkForWinnerOrTie(game.ticTacToeBox)(game.playerGlyph)(game.aIGlyph)  

let humanVsHuman(game : gameSetting)(io : IInputOut) : int =
    if int playerVals.Human = game.firstPlayer then
        playerOneFirstVsHuman(game)(io)
    else
        playerTwoFirstVsHuman(game)(io)

let flipBoard(ticTacToeBoardFlip : array<string>)(glyphOne : string)(glyphTwo : string) =
    for i = 0 to ticTacToeBoardFlip.Length - 1 do
        if ticTacToeBoardFlip.[i] = glyphOne then
            ticTacToeBoardFlip.[i] <-  glyphTwo
        elif ticTacToeBoardFlip.[i] = glyphTwo then
            ticTacToeBoardFlip.[i] <-  glyphOne

let aIvsAI(game : gameSetting)(io : IInputOut) : int =
    while not (isGameOver(game)) do
        aIInputEditTicTacToeBox(game) |> ignore
        flipBoard(game.ticTacToeBox)(game.playerGlyph)(game.aIGlyph)
   
    checkForWinnerOrTie(game.ticTacToeBox)(game.playerGlyph)(game.aIGlyph)  

let gameRunner(game : gameSetting)(io : IInputOut) =
    if game.firstPlayer = int playerVals.Human && not game.humanVsHuman && not game.aIvAI then
        humanFirstVsAiGame(game)(io)
    elif game.humanVsHuman then
        humanVsHuman(game)(io)
    elif game.aIvAI then
        aIvsAI(game)(io)
    else
        humanVsAiFirstGame(game)(io) 

let startGame (game : gameSetting)(io : IInputOut) : int =
    let result = gameRunner(game)(io)
    writeToScreen(game.ticTacToeBox)
                 (game.inverted)
                 (gameEndingMessage(game.ticTacToeBox)
                                   (game.playerGlyph)
                                   (game.aIGlyph))
                  (io) |> ignore
    result