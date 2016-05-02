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
        "AI Won"
    elif endResult = getWinningHumanValue(ticTacToeBox) then
        "Human Won"
    else
        "Tie" 

let isInputANumber(postion : string) : bool =
    try
        let posAsInt = int postion
        true
    with
        | :? System.FormatException -> false


let isOutBounds(arrayLenth : int)(postion : int) : bool =
    if arrayLenth < postion || postion < 0 then
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
    writeToScreen(game.ticTacToeBox)
                 (game.inverted)
                 (gameEndingMessage(game.ticTacToeBox)
                                   (game.playerGlyph)
                                   (game.aIGlyph))
                  (io) |> ignore
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
    writeToScreen(game.ticTacToeBox)
                 (game.inverted)
                 (gameEndingMessage(game.ticTacToeBox)
                                   (game.playerGlyph)
                                   (game.aIGlyph))
                  (io) |> ignore
    checkForWinnerOrTie(game.ticTacToeBox)(game.playerGlyph)(game.aIGlyph) 
    
            

let startGame (game : gameSetting)(io : IInputOut) : int =
    if game.firstPlayer = int playerVals.Human then
        humanFirstVsAiGame(game)(io)
    else
        humanVsAiFirstGame(game)(io)