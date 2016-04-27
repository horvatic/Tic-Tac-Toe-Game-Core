module AI
open CheckForWinnerOrTie
open PlayerValues
open GameStatusCodes
open System.Collections.Generic
open GameSettings


let ticTacToeBoxToString( ticTacToeBox : array<string>) : string =
    ticTacToeBox |> String.concat ""

let checkForAlreadyMadeTree( oldTrees : Dictionary<string, int> )
                           (key : string ) : int =
    if oldTrees.ContainsKey(key) then
        let returnScore = ref 0
        if oldTrees.TryGetValue(key, returnScore) then
            returnScore.Value
        else
            -9999
    else
        -9999
    

let getBoxLength( arrayLength : int ) : int =
    let length = sqrt( float arrayLength )
    int length

let makeEmptyScore ( length : int ) : array<int> =
    if length = 9 then
        let scoces = [|0; 0; 0; 0; 0; 0; 0; 0; 0|]
        scoces
    else
        let scoces = [|0; 0; 0; 0; 
                       0; 0; 0; 0;
                       0; 0; 0; 0;
                       0; 0; 0; 0;|]
        scoces 

let makeEmptyTicTacToeBox( length : int ) : array<string> =
    if length = 9 then
        let ticTacToeBox = [|"-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"|]
        ticTacToeBox
    else
        let ticTacToeBox = [|"-1-"; "-2-"; "-3-"; "-4-"; 
                        "-5-"; "-6-"; "-7-"; "-8-"; 
                        "-9-"; "-10-"; "-11-"; "-12-";
                        "-13-"; "-14-"; "-15-"; "-16-"|]
        ticTacToeBox

let rec minimax( ticTacToeBox : array<string>)(player : int)
               (oldTrees : Dictionary<string, int>)(game : gameSetting)
             : int =
    
    let boxSide = getBoxLength(ticTacToeBox.Length)
    let mutable currentPlayer = player
    let mutable score = -9999
    let mutable moves = makeEmptyTicTacToeBox(ticTacToeBox.Length)
    let mutable searchDepth = 0
    
    for i = 0 to ticTacToeBox.Length - 1 do
        moves.[i] <- ticTacToeBox.[i]

    score <- checkForAlreadyMadeTree(oldTrees) 
            (ticTacToeBoxToString(moves))
    if score = -9999 then
        score <- checkForWinnerOrTie(moves)(game)
    
    if score = int GenResult.NoWinner then
        while score = int GenResult.NoWinner do
            let mutable scores = makeEmptyScore(ticTacToeBox.Length)
            for i = 0 to ticTacToeBox.Length - 1 do
                if (not (moves.[i] = game.playerGlyph || moves.[i] = game.aIGlyph)) then
                    if currentPlayer = int playerVals.AI then
                        moves.[i] <- game.aIGlyph
                        scores.[i] <- minimax(moves)(currentPlayer * -1)(oldTrees)(game)
                        if not (oldTrees.ContainsKey(ticTacToeBoxToString(moves))) then
                            oldTrees.Add(ticTacToeBoxToString(moves), scores.[i])
                    else
                        moves.[i] <- game.playerGlyph
                        scores.[i] <- minimax(moves)(currentPlayer * -1)(oldTrees)(game)
                        if not (oldTrees.ContainsKey(ticTacToeBoxToString(moves))) then
                           oldTrees.Add(ticTacToeBoxToString(moves), scores.[i])
                    moves.[i] <- string (i+1)
            
            if currentPlayer = int playerVals.AI then
                let mutable bestScore = -999
                let mutable place = -1
                for i = 0 to ticTacToeBox.Length - 1 do
                    if bestScore < scores.[i] && not (moves.[i] = game.playerGlyph || moves.[i] = game.aIGlyph) then
                        bestScore <- scores.[i]
                        place <- i
                moves.[place] <- game.aIGlyph
            
            else
                let mutable bestScore = 999
                let mutable place = -1
                for i = 0 to ticTacToeBox.Length - 1 do
                    if bestScore > scores.[i] && not (moves.[i] = game.playerGlyph || moves.[i] = game.aIGlyph) then
                        bestScore <- scores.[i]
                        place <- i
                moves.[place] <- game.playerGlyph

            score <- checkForWinnerOrTie(moves)(game)
            searchDepth <- searchDepth + 1 
    
    if currentPlayer = int playerVals.AI then
        score <- ( score - searchDepth)
    else
        score <- ( searchDepth + score )
    score

let movesCount ( ticTacToeBox : array<string>)(game : gameSetting) : int =
    let mutable count = 0
    for i = 0 to ticTacToeBox.Length - 1 do
        if ticTacToeBox.[i] = game.playerGlyph || ticTacToeBox.[i] = game.aIGlyph then
            count <- count + 1
    count

let moveHere( ticTacToeBox : array<string>)(game : gameSetting)
             : int =
    let mutable place = -1
    let mutable i = 0
    while place = -1 do
        if not (ticTacToeBox.[i] = game.playerGlyph || ticTacToeBox.[i] = game.aIGlyph) then
            place <- i
        else
            i <- i + 1
    place

let computerMove( ticTacToeBox : array<string>)(game : gameSetting)
             : int =

    if movesCount(ticTacToeBox)(game) < 4 && ticTacToeBox.Length = 16 then
        moveHere(ticTacToeBox)(game)
    else
        let mutable place = -1
        let oldTrees = new Dictionary<string, int>()
        let mutable scores = makeEmptyScore(ticTacToeBox.Length)
        for i = 0 to ticTacToeBox.Length - 1 do
            if (not (ticTacToeBox.[i] = game.playerGlyph || ticTacToeBox.[i] = game.aIGlyph)) then
                ticTacToeBox.[i] <- game.aIGlyph
                scores.[i] <- minimax(ticTacToeBox)(int playerVals.Human)(oldTrees)(game)
                let stringOffset = i + 1
                ticTacToeBox.[i] <- string ("-"+string stringOffset+"-")
    
        let mutable bestScore = -999
        for i = 0 to ticTacToeBox.Length - 1 do
            if bestScore < scores.[i] && not (ticTacToeBox.[i] = game.playerGlyph || ticTacToeBox.[i] = game.aIGlyph) then
                bestScore <- scores.[i]
                place <- i
        place

let AIMove( ticTacToeBox : array<string>)(game : gameSetting)
          : array<string> =
   
    ticTacToeBox.[computerMove(ticTacToeBox)(game)] <- game.aIGlyph
    ticTacToeBox
