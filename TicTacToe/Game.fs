namespace TicTacToe.Core 
module Game =
    open AI
    open CleanInput
    open TicTacToeBoxEdit
    open CheckForWinnerOrTie
    open ScreenEdit
    open GameSettings
    open GameStatusCodes
    open userInputException
    open PlayerValues
    open IInputOutPut
    open InputOutPut
    open ITicTacToeBoxClass
    open TicTacToeBoxClass
    open Translate

    let makeTicTacToeBox(size : int) : list<string> =
        if size = 3 then
            ["-1-"; "-2-"; "-3-"; 
            "-4-"; "-5-"; "-6-"; 
            "-7-"; "-8-"; "-9-"]
    
        else 
            ["-1-"; "-2-"; "-3-"; "-4-"; 
            "-5-"; "-6-"; "-7-"; "-8-"; 
            "-9-"; "-10-"; "-11-"; "-12-";
            "-13-"; "-14-"; "-15-"; "-16-"]

    let gameEndingMessage( board : ITicTacToeBox) 
                         ( playerGlyph : string)
                         ( aIGlyph : string)  : int =
        let endResult = checkForWinnerOrTie(board)(playerGlyph)(aIGlyph)
        if endResult = getWinningAIValue(board.victoryCellCount()) then
            Other_Player_Won
        elif endResult = getWinningHumanValue(board.victoryCellCount()) then
             Player_Won
        else
            Tie

    let isGameOver(game : gameSetting)(board : ITicTacToeBox)(io : IInputOut) : bool =
        if checkForWinnerOrTie(board)(game.playerGlyph)(game.aIGlyph) 
                = int GenResult.NoWinner then
            false
        else
            writeToScreen(board)
                         (game.inverted)
                         (gameEndingMessage(board)
                                       (game.playerGlyph)
                                       (game.aIGlyph))
                      (io) |> ignore
            true

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

    let isSpotTaken(board : ITicTacToeBox)
                   (postion : int)
                   (playerGlyph : string) 
                   (aIGlyph : string)
                   : bool =
        if board.getGlyphAtLocation(postion) = playerGlyph || board.getGlyphAtLocation(postion) = aIGlyph then
            true
        else
            false
        
    let isUserInputCorrect(board : ITicTacToeBox)
                          (postion : string)
                          (playerGlyph : string) 
                          (aIGlyph : string) : int =
        if not (isInputANumber(postion)) then
            Value_Not_A_Number
        elif isOutBounds(board.cellCount())(int postion - 1) then
            Value_Out_Of_Bounds
        elif isSpotTaken(board)(int postion - 1)(playerGlyph)(aIGlyph) then
            Spot_Taken
        else
            Blank
    let convertStringToInt(pos : string) : int =
        int pos

    let userInputOkToEditTicTacToeBox(game : gameSetting)(board : ITicTacToeBox)(postion : string) : int = 
        let message = isUserInputCorrect(board)
                        (postion)(game.playerGlyph)(game.aIGlyph)
        if( message = Blank ) then
            Blank
        else
            message


    let otherUserInputOkToEditTicTacToeBox(game : gameSetting)(board : ITicTacToeBox)(postion : string) : int = 
        let message = isUserInputCorrect(board)
                        (postion)(game.playerGlyph)(game.aIGlyph)
        if( message = Blank ) then
            Blank
        else
            message

    let rec humanOneturn(game : gameSetting)(board : ITicTacToeBox)(io : IInputOut)(message : int) : int =
        if not (isGameOver(game)(board)(io)) then
            writeToScreen(board)(game.inverted)(message)(io)
            let userPickedPos = io.getUserInput()
            if userInputOkToEditTicTacToeBox(game)(board)(userPickedPos) = Blank then
                humanTwoTurn(game)
                            (insertUserOption(board)
                                             (int userPickedPos)
                                             (game.playerGlyph)
                                             (game.aIGlyph))
                            (io)
                            (Blank)
            else
                humanOneturn(game)(board)(io)(userInputOkToEditTicTacToeBox(game)(board)(userPickedPos))
        else
            checkForWinnerOrTie(board)(game.playerGlyph)(game.aIGlyph) 

    and humanTwoTurn(game : gameSetting)(board : ITicTacToeBox)(io : IInputOut)(message : int) : int =
        if not (isGameOver(game)(board)(io)) then
            writeToScreen(board)(game.inverted)(message)(io)
            let userPickedPos = io.getUserInput()
            if userInputOkToEditTicTacToeBox(game)(board)(userPickedPos) = Blank then
                humanOneturn(game)
                            (insertOtherUserOption(board)
                                             (int userPickedPos)
                                             (game.playerGlyph)
                                             (game.aIGlyph))
                            (io)
                            (Blank)
            else
                humanTwoTurn(game)(board)(io)(userInputOkToEditTicTacToeBox(game)(board)(userPickedPos))
        else
            checkForWinnerOrTie(board)(game.playerGlyph)(game.aIGlyph) 

    let rec humanChoseMove(game : gameSetting)(board : ITicTacToeBox)(io : IInputOut)(message : int) : int =
        if not (isGameOver(game)(board)(io)) then
            writeToScreen(board)(game.inverted)(message)(io)
            let userPickedPos = io.getUserInput()
            if userInputOkToEditTicTacToeBox(game)(board)(userPickedPos) = Blank then
                aiChoseMove(game)
                       (insertUserOption(board)
                                        (int userPickedPos)
                                        (game.playerGlyph)
                                        (game.aIGlyph))
                            (io)
            else
                humanChoseMove(game)(board)(io)(userInputOkToEditTicTacToeBox(game)(board)(userPickedPos))
        else
            checkForWinnerOrTie(board)(game.playerGlyph)(game.aIGlyph) 

    and aiChoseMove(game : gameSetting)(board : ITicTacToeBox)(io : IInputOut) : int =
        if not (isGameOver(game)(board)(io)) then
            humanChoseMove(game)(aIMove(game)(board))(io)(Blank)
        else
            checkForWinnerOrTie(board)(game.playerGlyph)(game.aIGlyph) 

    let humanVsHuman(game : gameSetting)(board : ITicTacToeBox)(io : IInputOut) : int =
        if int playerVals.Human = game.firstPlayer then
            humanOneturn(game)(board)(io)(Blank)
        else
            humanTwoTurn(game)(board)(io)(Blank)

    let humanFirstVsAiGame(game : gameSetting)(ticTacToeBox : ITicTacToeBox)(io : IInputOut) : int =
        humanChoseMove(game)(ticTacToeBox)(io)(Blank)

    let humanVsAiFirstGame(game : gameSetting)(ticTacToeBox : ITicTacToeBox)(io : IInputOut) : int =
        aiChoseMove(game)(ticTacToeBox)(io)

    let rec aIPlayerOneTurn(playerOneSettings : gameSetting)(playerTwoSettings : gameSetting)
                           (board : ITicTacToeBox)(io : IInputOut) : int =
    
        if not (isGameOver(playerOneSettings)(board)(io)) then
            aIPlayerTwoTurn(playerOneSettings)(playerTwoSettings)
                       (aIMove(playerOneSettings)(board))(io)
        else
            checkForWinnerOrTie(board)(playerOneSettings.playerGlyph)(playerOneSettings.aIGlyph) 

    and aIPlayerTwoTurn(playerOneSettings : gameSetting)(playerTwoSettings : gameSetting)
                       (board : ITicTacToeBox)(io : IInputOut) : int =
    
        if not (isGameOver(playerOneSettings)(board)(io)) then
            aIPlayerOneTurn(playerOneSettings)(playerTwoSettings)
                       (aIMove(playerTwoSettings)(board))(io)
        else
            checkForWinnerOrTie(board)(playerOneSettings.playerGlyph)(playerOneSettings.aIGlyph) 

    let aIvsAI(game : gameSetting)(board : ITicTacToeBox)(io : IInputOut) : int =
        let aIPlayerTwoGame = craftGameSetting(game.ticTacToeBoxSize)(game.aIGlyph)
                                              (game.playerGlyph)(game.firstPlayer)
                                              (game.inverted)(false)(true)
        aIPlayerOneTurn(game)(aIPlayerTwoGame)(board)(io)

    let gameRunner(game : gameSetting)(io : IInputOut) : int =
        let ticTacToeBoard = new TicTacToeBox(makeTicTacToeBox(game.ticTacToeBoxSize))
        if game.firstPlayer = int playerVals.Human && not game.humanVsHuman && not game.aIvAI then
            humanFirstVsAiGame(game)(ticTacToeBoard)(io)
        elif game.humanVsHuman then
            humanVsHuman(game)(ticTacToeBoard)(io)
        elif game.aIvAI then
            aIvsAI(game)(ticTacToeBoard)(io)
        else
            humanVsAiFirstGame(game)(ticTacToeBoard)(io) 

    let startGame (game : gameSetting)(io : IInputOut) : int =
        let result = gameRunner(game)(io)
        result
