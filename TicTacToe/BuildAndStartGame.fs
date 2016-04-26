module BuildAndStartGame
open Game
open GameSettings
open PlayerValues
open CleanInput
open userInputException

let invertedGame() : bool =
    let mutable invaildOption = true
    let mutable invert = ""
    let mutable message = ""
    while invaildOption do
        System.Console.Clear()
        try 
            printfn "%s" message
            printfn "Would you like to The game Inverted? "
            printf "Y/N: "
            invert <- SanitizeYesOrNo(System.Console.ReadLine())
            invaildOption <- false
        with
            | :? InvaildOption -> message <- "Must be a Y or N"
   
    if( invert = "Y" ) then
        true
    else
        false

let getFirstPlayer() : int =
    let mutable invaildPlayer = true
    let mutable first = ""
    let mutable message = ""
    while invaildPlayer do
        System.Console.Clear()
        try 
            printfn "%s" message
            printfn "Would you like to go first / Be Player One? "
            printf "Y/N: "
            first <- SanitizeYesOrNo(System.Console.ReadLine())
            invaildPlayer <- false
        with
            | :? InvaildOption -> message <- "Must be a Y or N"
   
    if( first = "Y" ) then
        int playerVals.Human
    else
        int playerVals.AI

let getPlayerTwoGlyph(playerOneglyph : string) : string =
    let mutable invaildGlyph = true
    let mutable glyph = ""
    let mutable message = ""
    while invaildGlyph do
        System.Console.Clear()
        try 
            printfn "%s" message
            printfn "What glyph would you like for player two?"
            printf "glyph: "
            glyph <- SanitizeGlyph(System.Console.ReadLine())
            if playerOneglyph = glyph then
                message <- "Must be diffent, pick another glyph"
            else
                invaildGlyph <- false
        with
            | :? InvaildGlyph -> message <- "Length Must be one"
    glyph

let getPlayerOneGlyph() : string =
    let mutable invaildGlyph = true
    let mutable glyph = ""
    let mutable message = ""
    while invaildGlyph do
        System.Console.Clear()
        try 
            printfn "%s" message
            printfn "What glyph would you like for player one?"
            printf "glyph: "
            glyph <- SanitizeGlyph(System.Console.ReadLine())
            invaildGlyph <- false
        with
            | :? InvaildGlyph -> message <- "Length Must be one"
    glyph

let makeTicTacToeBox(size : int) : array<string> =
    if size = 3 then
        let ticTacToeBox = [|"1"; "2"; "3"; 
                         "4"; "5"; "6"; 
                         "7"; "8"; "9"|]
        ticTacToeBox
    elif size =  4 then 
        let ticTacToeBox = [|"1"; "2"; "3"; "4"; 
                         "5"; "6"; "7"; "8"; 
                         "9"; "10"; "11"; "12";
                         "13"; "14"; "15"; "16"|]
        ticTacToeBox
    elif size < 3 then
        raise(OutOfBoundsUnderFlow("Invaild Box Size"))
    else
        raise(OutOfBoundsOverFlow("Invaild Box Size"))

let getBoxSize() : int = 
    let mutable invaildBoxSize = true
    let mutable boxSize = 0
    let mutable message = ""
    while invaildBoxSize do
        System.Console.Clear()
        try 
            printfn "%s" message
            printfn "Would you like to play on a 3x3 or 4x4 Board"
            printf "3 or 4: "
            boxSize <- SanitizeBoxSize(System.Console.ReadLine())
            invaildBoxSize <- false
        with
            | :? NonIntError -> message <- "Invaild Box Size, Enter 3 or 4"
            | :? OutOfBoundsOverFlow -> message <- "Invaild Box Size, Enter 3 or 4"
            | :? OutOfBoundsUnderFlow -> message <- "Invaild Box Size, Enter 3 or 4"
    boxSize

let builder() : gameSetting =
    let ticTacToeBox = makeTicTacToeBox(getBoxSize())
    let whoFirst = getFirstPlayer()
    let playerOneGlyph = getPlayerOneGlyph()
    let playerTwoGlyph = getPlayerTwoGlyph(playerOneGlyph)
    let inverted = invertedGame()

    craftGameSetting (ticTacToeBox)(playerOneGlyph)
                (playerTwoGlyph)(whoFirst)(inverted)(false)

let buildGame() : gameSetting =
    let mutable invaildOption = true
    let mutable  good = ""
    let mutable message = ""
    let mutable builtGame = builder()
    while invaildOption do
        System.Console.Clear()
        try 
            printfn "%s" message
            printfn "These are the options you picked"
            if builtGame.ticTacToeBox.Length = 9 then 
                printfn "TicTacToeBox is: 3x3"
            else
                printfn "TicTacToeBox is: 4x4"
            if builtGame.firstPlayer = int playerVals.Human then
                printfn "You are Player One, and going first"
            else
                printfn "You are Player Two, and going second"
            printfn "Player One Glyph %s " builtGame.playerOneGlyph
            printfn "Player Two Glyph %s " builtGame.playerTwoGlyph
            if builtGame.inverted then
                printfn "Board Inverted"
            else
                printfn "Board Inverted"
            printfn ""
            printfn "Would you like to change anything?"
            printf "Y/N: "
            good <- SanitizeYesOrNo(System.Console.ReadLine())
        with
            | :? InvaildOption -> message <- "Must be a Y or N"
   
        if( good = "N" ) then
            invaildOption <- false
        else
            builtGame <- builder()
    builtGame


let buildAndStartGame() = 

    let game = buildGame()
    startGame(game) |> ignore