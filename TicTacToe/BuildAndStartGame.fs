module BuildAndStartGame
open Game
open GameSettings
open PlayerValues
open CleanInput
open userInputException
open InputOutPut
open IInputOutPut

let makeTicTacToeBox(size : int) : array<string> =
    if size = 3 then
        [|"-1-"; "-2-"; "-3-"; 
        "-4-"; "-5-"; "-6-"; 
        "-7-"; "-8-"; "-9-"|]
    elif size =  4 then 
        [|"-1-"; "-2-"; "-3-"; "-4-"; 
        "-5-"; "-6-"; "-7-"; "-8-"; 
        "-9-"; "-10-"; "-11-"; "-12-";
        "-13-"; "-14-"; "-15-"; "-16-"|]
    elif size < 3 then
        raise(OutOfBoundsUnderFlow("Invaild Box Size"))
    else
        raise(OutOfBoundsOverFlow("Invaild Box Size"))

let rec getaIGlyph(io : IInputOut)
                  (message : string)
                  (playerGlyph : string) : string =
    io.print([|message; "What glyph would you like for the other player?"|])
    try 
            let aiGlypg = SanitizeGlyph(io.getUserInput())
            if aiGlypg = playerGlyph then
                getaIGlyph(io)("glyph must differ")(playerGlyph)
            else
                aiGlypg
    with
        | :? InvaildGlyph -> getaIGlyph(io)("Length Must be one")(playerGlyph)

let rec getplayerGlyph (io : IInputOut)(message : string)( aiVsAi : bool ) : string =
    if aiVsAi then
        io.print([|message; "What glyph would you like for one of the AI players?"|])
    else
        io.print([|message; "What glyph would you like?"|])
    
    try 
            SanitizeGlyph(io.getUserInput())
    with
        | :? InvaildGlyph -> getplayerGlyph(io)("Length Must be one")(aiVsAi)

let rec getBoxOfUserSize(io : IInputOut)(message : string) : array<string> =
    io.print([|message; "Would you like to play on a 3x3 or 4x4 Board? "|])
    try
        makeTicTacToeBox(SanitizeBoxSize(io.getUserInput()))
    with
        | :? NonIntError -> getBoxOfUserSize(io)("Invaild Box Size, Enter 3 or 4")
        | :? OutOfBoundsOverFlow -> getBoxOfUserSize(io)("Invaild Box Size, Enter 3 or 4")
        | :? OutOfBoundsUnderFlow -> getBoxOfUserSize(io)("Invaild Box Size, Enter 3 or 4")

let rec isHuamnVSHuman(io : IInputOut)(message : string)(aiVsAi : bool) : bool =
    if aiVsAi then
        false
    else
        io.print([|message; "Would you like human vs human? "; "Y/N"|])
        try 
            let humanVsHuman = SanitizeYesOrNo(io.getUserInput())
            if humanVsHuman = "Y" then
                true
            else
                false
        with
            | :? InvaildOption -> isHuamnVSHuman(io)("Must be a Y or N")(aiVsAi)

let rec isGameInverted(io : IInputOut)(message : string) : bool =
    io.print([|message; "Would you like to The game Inverted? "; "Y/N"|])
    try 
        let invert = SanitizeYesOrNo(io.getUserInput())
        if invert = "Y" then
            true
        else
            false
    with
        | :? InvaildOption -> isGameInverted(io)("Must be a Y or N")

let rec aiVsAi(io : IInputOut)(message : string) : bool  =
    io.print([|message; "Would you like AI VS AI "; "Y/N"|])
    try 
        let aivai = SanitizeYesOrNo(io.getUserInput())
        if aivai = "Y" then
            true
        else
            false
    with
        | :? InvaildOption -> aiVsAi(io)("Must be a Y or N")

let rec whoGoingFirst(io : IInputOut)(message : string)(aivAi : bool) : int  =
    if aivAi then
       int playerVals.AI
    else 
        io.print([|message; "Would you like to go first? "; "Y/N"|])    
        try 
            let goFirst = SanitizeYesOrNo(io.getUserInput())
            if goFirst = "Y" then
                int playerVals.Human
            else
                int playerVals.AI
        with
            | :? InvaildOption -> whoGoingFirst(io)("Must be a Y or N")(aivAi)

let rec settingGood(io : IInputOut)
               (playerBox : array<string>)
               (humanVsHuman : bool)
               (firstPlayer : int)
               (playerGlyph : string)
               (aIGlyph : string)
               (gameInverted : bool)
               (message : string)
               (aiVAi : bool ) 
               : bool =
    let PlayerMessage = 
        if firstPlayer = int playerVals.AI && not aiVAi then 
            "Other Player is going first"
        elif aiVAi then
            "AI is playing" 
        else 
            "Your going first"
    let gameMode = 
        if humanVsHuman then 
            "Human Vs Human"
        elif aiVAi then
            "AI vs AI" 
        else 
            "Human Vs AI"
    io.print[|message;
              "Here are your current Settings";
              "Current Board Size is: " 
                + string (sqrt(float playerBox.Length))
                + "X" + string (sqrt(float playerBox.Length));
              gameMode;
              PlayerMessage;
              "Player Glyph: " + playerGlyph;
              "Other Player Glyph: " + aIGlyph;
              "Game Inverted: " + string gameInverted;
              "Are These the setting you want?";            
            |]
    try 
        let invert = SanitizeYesOrNo(io.getUserInput())
        if invert = "Y" then
            true
        else
            false
    with
        | :? InvaildOption -> settingGood(io)(playerBox)(humanVsHuman)(firstPlayer)
                                         (playerGlyph)(aIGlyph)
                                         (gameInverted)("Must be a Y or N")(aiVAi)
   

let rec buildGame(io : IInputOut) : gameSetting =
    let playerBox = getBoxOfUserSize(io)("")
    let aivAi = aiVsAi(io)("")
    let humanVsHuman = isHuamnVSHuman(io)("")(aivAi)
    let firstPlayer = whoGoingFirst(io)("")(aivAi)
    let playerGlyph = getplayerGlyph(io)("")(aivAi)
    let aIGlyph = getaIGlyph(io)("")(playerGlyph)
    let gameInverted = isGameInverted(io)("")
    if settingGood(io)(playerBox)(humanVsHuman)(firstPlayer)(playerGlyph)(aIGlyph)(gameInverted)("")(aivAi) then
        craftGameSetting(playerBox) 
                        (playerGlyph) 
                        (aIGlyph) 
                        (firstPlayer)
                        (gameInverted)
                        (humanVsHuman)
                        (aivAi)
    else
        buildGame(io)

let playGame(game : gameSetting)(io : InputOut) : bool =
    startGame(game)(io) |> ignore
    io.printNoScreenWhip([|"Another Game? Y/N: "|])
    let input = io.getUserInput()
    if not (input = "Y" || input = "y") then
        false
    else
        true

let buildAndStartGame() = 
    let io = new InputOut()
    let mutable game = buildGame(io)
    while playGame(game)(io) do
        io.printNoScreenWhip([|"Same Settings? Y/N: "|])
        let input = io.getUserInput()
        if input = "N" || input = "n" then
            game <- buildGame(io)
        else
            game.ticTacToeBox <- makeTicTacToeBox(int (sqrt(float game.ticTacToeBox.Length)))