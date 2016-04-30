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
    io.print([|message; "What glyph would you like for the AI?"|])
    try 
            let aiGlypg = SanitizeGlyph(io.getUserInput())
            if aiGlypg = playerGlyph then
                getaIGlyph(io)("glyph must differ")(playerGlyph)
            else
                aiGlypg
    with
        | :? InvaildGlyph -> getaIGlyph(io)("Length Must be one")(playerGlyph)

let rec getplayerGlyph (io : IInputOut)(message : string) : string =
    io.print([|message; "What glyph would you like?"|])
    try 
            SanitizeGlyph(io.getUserInput())
    with
        | :? InvaildGlyph -> getplayerGlyph(io)("Length Must be one")

let rec getBoxOfUserSize(io : IInputOut)(message : string) : array<string> =
    io.print([|message; "Would you like to play on a 3x3 or 4x4 Board? "|])
    try
        makeTicTacToeBox(SanitizeBoxSize(io.getUserInput()))
    with
        | :? NonIntError -> getBoxOfUserSize(io)("Invaild Box Size, Enter 3 or 4")
        | :? OutOfBoundsOverFlow -> getBoxOfUserSize(io)("Invaild Box Size, Enter 3 or 4")
        | :? OutOfBoundsUnderFlow -> getBoxOfUserSize(io)("Invaild Box Size, Enter 3 or 4")

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

let rec settingGood(io : IInputOut)
               (playerBox : array<string>)
               (playerGlyph : string)
               (aIGlyph : string)
               (gameInverted : bool)
               (message : string) : bool =
    io.print[|message;
              "Here are your current Settings";
              "Current Board Size is: " 
                + string (sqrt(float playerBox.Length))
                + "X" + string (sqrt(float playerBox.Length));
              "Player Glyph: " + playerGlyph;
              "AI Glyph: " + aIGlyph;
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
        | :? InvaildOption -> settingGood(io)(playerBox)
                                         (playerGlyph)(aIGlyph)
                                         (gameInverted)("Must be a Y or N")
    

let rec buildGame(io : IInputOut) : gameSetting =
    let playerBox = getBoxOfUserSize(io)("")
    let playerGlyph = getplayerGlyph(io)("")
    let aIGlyph = getaIGlyph(io)("")(playerGlyph)
    let gameInverted = isGameInverted(io)("")
    if settingGood(io)(playerBox)(playerGlyph)(aIGlyph)(gameInverted)("") then
        craftGameSetting(playerBox) 
                        (playerGlyph) 
                        (aIGlyph) 
                        (int playerVals.AI)
                        (gameInverted)
                        (false)
    else
        buildGame(io)

let buildAndStartGame(io : IInputOut) : int = 
    let game = buildGame(io)
    startGame(game)(io)