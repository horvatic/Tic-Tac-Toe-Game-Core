module BuildAndStartGame
open Game
open GameSettings
open PlayerValues
open CleanInput
open userInputException
open InputOutPut
open IInputOutPut
open Translate

let getTicTacToeBoxSize(size : int) : int =
    if size = 3 then
        3
    elif size =  4 then 
        4
    elif size < 3 then
        raise(OutOfBoundsUnderFlow())
    else
        raise(OutOfBoundsOverFlow())

let rec getaIGlyph(io : IInputOut)
                  (message : int)
                  (playerGlyph : string) : string =
    io.cleanScreen()
    io.printNoScreenFlush([message; What_Glyph_Would_You_Like_Other_Player])
    try 
            let aiGlypg = SanitizeGlyph(io.getUserInput())
            if aiGlypg = playerGlyph then
                getaIGlyph(io)(Glyph_Must_Differ)(playerGlyph)
            else
                aiGlypg
    with
        | :? InvaildGlyph -> getaIGlyph(io)(Length_Must_Be_One)(playerGlyph)

let rec getplayerGlyph (io : IInputOut)(message : int)( aiVsAi : bool ) : string =
    if aiVsAi then
        io.cleanScreen()
        io.printNoScreenFlush([message; What_Glyph_Would_You_For_One_AI_Players])
    else
        io.cleanScreen()
        io.printNoScreenFlush([message; What_Glyph_Would_You_Like])
    
    try 
            SanitizeGlyph(io.getUserInput())
    with
        | :? InvaildGlyph -> getplayerGlyph(io)(Length_Must_Be_One)(aiVsAi)

let rec getBoxOfUserSize(io : IInputOut)(message : int) : int =
    io.cleanScreen()
    io.printNoScreenFlush([message; Would_You_Like_To_Play_On_A_3x3_Or_4x4_Board])
    try
        getTicTacToeBoxSize(SanitizeBoxSize(io.getUserInput()))
    with
        | :? NonIntError -> getBoxOfUserSize(io)(Invaild_Box_Size_3_Or_4)
        | :? OutOfBoundsOverFlow -> getBoxOfUserSize(io)(Invaild_Box_Size_3_Or_4)
        | :? OutOfBoundsUnderFlow -> getBoxOfUserSize(io)(Invaild_Box_Size_3_Or_4)

let rec isHuamnVSHuman(io : IInputOut)(message : int)(aiVsAi : bool) : bool =
    if aiVsAi then
        false
    else
        io.cleanScreen()
        io.printNoScreenFlush([message; Would_You_Like_Human_Vs_Human; Y_N])
        try 
            let humanVsHuman = SanitizeYesOrNo(io.getUserInput())
            if humanVsHuman = "Y" || humanVsHuman = "S" then
                true
            else
                false
        with
            | :? InvaildOption -> isHuamnVSHuman(io)(Must_Be_A_Y_Or_N)(aiVsAi)

let rec isGameInverted(io : IInputOut)(message : int) : bool =
    io.cleanScreen()
    io.printNoScreenFlush([message; Would_You_Like_To_The_Game_Inverted; Y_N])
    try 
        let invert = SanitizeYesOrNo(io.getUserInput())
        if invert = "Y" || invert = "S" then
            true
        else
            false
    with
        | :? InvaildOption -> isGameInverted(io)(Must_Be_A_Y_Or_N)

let rec aiVsAi(io : IInputOut)(message : int) : bool  =
    io.cleanScreen()
    io.printNoScreenFlush([message; Would_You_Like_AI_VS_AI; Y_N])
    try 
        let aivai = SanitizeYesOrNo(io.getUserInput())
        if aivai = "Y" || aivai = "S" then
            true
        else
            false
    with
        | :? InvaildOption -> aiVsAi(io)(Must_Be_A_Y_Or_N)

let rec whoGoingFirst(io : IInputOut)(message : int)(aivAi : bool) : int  =
    if aivAi then
       int playerVals.AI
    else 
        io.cleanScreen()
        io.printNoScreenFlush([message; Would_You_Like_To_Go_First; Y_N])    
        try 
            let goFirst = SanitizeYesOrNo(io.getUserInput())
            if goFirst = "Y" || goFirst = "S" then
                int playerVals.Human
            else
                int playerVals.AI
        with
            | :? InvaildOption -> whoGoingFirst(io)(Must_Be_A_Y_Or_N)(aivAi)

let rec settingGood(io : IInputOut)
               (playerBox : int)
               (humanVsHuman : bool)
               (firstPlayer : int)
               (playerGlyph : string)
               (aIGlyph : string)
               (gameInverted : bool)
               (message : int)
               (aiVAi : bool ) 
               : bool =
    let PlayerMessage = 
        if firstPlayer = int playerVals.AI && not aiVAi then 
            Other_Player_Is_Going_First
        elif aiVAi then
            AI_Is_Playing
        else 
            Your_Going_First
    let gameMode = 
        if humanVsHuman then 
            Human_Vs_Human
        elif aiVAi then
            AI_vs_AI 
        else 
            Human_Vs_AI
    let boardSize = 
        if playerBox = 3 then
            Board_Size_3X3
        else
            Board_Size_4X4
    io.cleanScreen()
    io.printNoScreenFlush([message;
              Here_Are_Your_Current_Settings;
              Current_Board_Size_Is;
              boardSize;
              gameMode;
              PlayerMessage;])
    io.printNoScreenFlush([Player_Glyph;])
    io.printNoScreenFlushNoTranslate([playerGlyph;])
    io.printNoScreenFlush([Other_Player_Glyph;])
    io.printNoScreenFlushNoTranslate([aIGlyph;])
    io.printNoScreenFlush([Game_Inverted;])
    io.printNoScreenFlushNoTranslate([string gameInverted;])
    io.printNoScreenFlush([Are_These_The_Setting_You_Want;])
    try 
        let invert = SanitizeYesOrNo(io.getUserInput())
        if invert = "Y" || invert = "S" then
            true
        else
            false
    with
        | :? InvaildOption -> settingGood(io)(playerBox)(humanVsHuman)(firstPlayer)
                                         (playerGlyph)(aIGlyph)
                                         (gameInverted)(Must_Be_A_Y_Or_N)(aiVAi)
   

let rec buildGame(io : IInputOut) : gameSetting =
    let playerBox = getBoxOfUserSize(io)(Blank)
    let aivAi = aiVsAi(io)(Blank)
    let humanVsHuman = isHuamnVSHuman(io)(Blank)(aivAi)
    let firstPlayer = whoGoingFirst(io)(Blank)(aivAi)
    let playerGlyph = getplayerGlyph(io)(Blank)(aivAi)
    let aIGlyph = getaIGlyph(io)(Blank)(playerGlyph)
    let gameInverted = isGameInverted(io)(Blank)
    if settingGood(io)(playerBox)(humanVsHuman)(firstPlayer)(playerGlyph)(aIGlyph)(gameInverted)(Blank)(aivAi) then
        craftGameSetting(playerBox) 
                        (playerGlyph) 
                        (aIGlyph) 
                        (firstPlayer)
                        (gameInverted)
                        (humanVsHuman)
                        (aivAi)
    else
        buildGame(io)

let playGame(game : gameSetting)(io : IInputOut) : bool =
    startGame(game)(io) |> ignore
    io.printNoScreenFlush([Another_Game_Y_N])
    let input = io.getUserInput()
    if not (input = "Y" || input = "y" || input = "S" || input = "s") then
        false
    else
        true

let rec prepGame(game : gameSetting)(io : IInputOut) =
    if playGame(game)(io) then
        io.printNoScreenFlush([Same_Settings_Y_N])
        let input = io.getUserInput()
        if input = "Y" || input = "y" || input = "S" || input = "s" then
            prepGame(game)(io)
        else
            prepGame(buildGame(io))(io)

let buildAndStartGame(io : IInputOut) : int = 
    let game = buildGame(io)
    prepGame(game)(io)
    0
    