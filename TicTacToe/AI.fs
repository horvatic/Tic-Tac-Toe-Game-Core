module AI
open CheckForWinnerOrTie
open PlayerValues
open GameStatusCodes
open System.Collections.Generic
open GameSettings

(*
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
               ( depth : int )
             : int =
    
    let boxSide = getBoxLength(ticTacToeBox.Length)
    let mutable currentPlayer = player
    let mutable score = 0
    let mutable moves = makeEmptyTicTacToeBox(ticTacToeBox.Length)
    
    for i = 0 to ticTacToeBox.Length - 1 do
        moves.[i] <- ticTacToeBox.[i]

    score <- checkForAlreadyMadeTree(oldTrees) 
            (ticTacToeBoxToString(moves))
    if score = -9999 then
        score <- checkForWinnerOrTie(moves)(game.playerGlyph)(game.aIGlyph)
    
    if score = int GenResult.NoWinner then
        let mutable scores = makeEmptyScore(ticTacToeBox.Length)
        for i = 0 to ticTacToeBox.Length - 1 do
            if (not (moves.[i] = game.playerGlyph || moves.[i] = game.aIGlyph)) then
                if currentPlayer = int playerVals.AI then
                    moves.[i] <- game.aIGlyph
                    scores.[i] <- minimax(moves)(currentPlayer * -1)(oldTrees)(game)(depth + 1)
                    if not (oldTrees.ContainsKey(ticTacToeBoxToString(moves))) then
                        oldTrees.Add(ticTacToeBoxToString(moves), scores.[i])
                else
                    moves.[i] <- game.playerGlyph
                    scores.[i] <- minimax(moves)(currentPlayer * -1)(oldTrees)(game)(depth + 1)
                    if not (oldTrees.ContainsKey(ticTacToeBoxToString(moves))) then
                        oldTrees.Add(ticTacToeBoxToString(moves), scores.[i])
                moves.[i] <- string (i+1)
            
        if currentPlayer = int playerVals.AI then
            let mutable bestScore = -999
            let mutable place = -1
            for i = 0 to ticTacToeBox.Length - 1 do
                if bestScore < scores.[i] && not (moves.[i] = game.playerGlyph || moves.[i] = game.aIGlyph) then
                    bestScore <- scores.[i]
                    score <- bestScore
                    place <- i
            moves.[place] <- game.aIGlyph
            
        else
            let mutable bestScore = 999
            let mutable place = -1
            for i = 0 to ticTacToeBox.Length - 1 do
                if bestScore > scores.[i] && not (moves.[i] = game.playerGlyph || moves.[i] = game.aIGlyph) then
                    bestScore <- scores.[i]
                    score <- bestScore
                    place <- i
            moves.[place] <- game.playerGlyph
   
    currentPlayer <- currentPlayer * -1
    if currentPlayer = int playerVals.AI then
        score <- (score - depth)
    else
        score <- ( depth + score )
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

let computerMove(game : gameSetting)
             : int =

    if movesCount(game.ticTacToeBox)(game) < 2 && game.ticTacToeBox.Length = 16 then
        moveHere(game.ticTacToeBox)(game)
    else
        let mutable place = -1
        let oldTrees = new Dictionary<string, int>()
        let mutable scores = makeEmptyScore(game.ticTacToeBox.Length)
        for i = 0 to game.ticTacToeBox.Length - 1 do
            if (not (game.ticTacToeBox.[i] = game.playerGlyph || game.ticTacToeBox.[i] = game.aIGlyph)) then
                game.ticTacToeBox.[i] <- game.aIGlyph
                scores.[i] <- minimax(game.ticTacToeBox)(int playerVals.Human)(oldTrees)(game)(1)
                let stringOffset = i + 1
                game.ticTacToeBox.[i] <- string ("-"+string stringOffset+"-")
    
        let mutable bestScore = -999
        for i = 0 to game.ticTacToeBox.Length - 1 do
            if bestScore < scores.[i] && not (game.ticTacToeBox.[i] = game.playerGlyph || game.ticTacToeBox.[i] = game.aIGlyph) then
                bestScore <- scores.[i]
                place <- i
        place
*)

let insertPlayerGlyph(ticTacToeBox : array<string>)
                     (insetPostion : int)
                     (playerGlyph : string)
                     (aIGlyph : string) : bool =
    if ticTacToeBox.[insetPostion] = playerGlyph || ticTacToeBox.[insetPostion] = aIGlyph then
        false
    else
        ticTacToeBox.[insetPostion] <- playerGlyph
        true

let insertAiGlyph(ticTacToeBox : array<string>)
                 (insetPostion : int)
                 (playerGlyph : string)
                 (aIGlyph : string) : bool =
    if ticTacToeBox.[insetPostion] = playerGlyph || ticTacToeBox.[insetPostion] = aIGlyph then
        false
    else
        ticTacToeBox.[insetPostion] <- aIGlyph
        true

let makeEmptyScore ( length : int ) : array<int> =
    if length = 9 then
        [|0; 0; 0; 0; 0; 0; 0; 0; 0|]
    else
        [|0; 0; 0; 0; 
        0; 0; 0; 0;
        0; 0; 0; 0;
        0; 0; 0; 0;|]

let makeDeepCopyOfArray(copyTo : array<string>)
                       (copyFrom : array<string> ) 
                       : array<string> = 
    for i = 0 to copyFrom.Length - 1 do
        copyTo.[i] <- copyFrom.[i]
    copyTo

let makeEmptyTicTacToeBox( length : int ) : array<string> =
    if length = 9 then
        [|"-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"|]
    else
        [|"-1-"; "-2-"; "-3-"; "-4-"; 
        "-5-"; "-6-"; "-7-"; "-8-"; 
        "-9-"; "-10-"; "-11-"; "-12-";
        "-13-"; "-14-"; "-15-"; "-16-"|]

let findSmallestScore(scores : array<int>) : int = 
    let sortedScores = Array.sort(scores)
    sortedScores.[0]

let findLargestScore(scores : array<int>) : int = 
    let sortedScores = Array.sort(scores)
    sortedScores.[sortedScores.Length - 1]

let rec miniMaxMaxium(ticTacToeBox : array<string>)
                     (playerGlyph : string)
                     (aIGlyph : string)
                     (depth : int )
                     : int =
    let moves =
        makeDeepCopyOfArray(makeEmptyTicTacToeBox(ticTacToeBox.Length))(ticTacToeBox)
    let score = checkForWinnerOrTie(moves)(playerGlyph)(aIGlyph) 
    if score = int GenResult.NoWinner then
        let scores = makeEmptyScore(moves.Length)
        for i = 0 to moves.Length - 1 do
            if (insertAiGlyph(moves)(i)(playerGlyph)(aIGlyph)) then
                scores.[i] <- miniMaxMinimize(moves)(playerGlyph)(aIGlyph)(depth + 1)
                moves.[i] <- "-"+string (int i + int 1)+"-"
        findLargestScore(scores)
    else
        score - depth

and miniMaxMinimize(ticTacToeBox : array<string>)
                   (playerGlyph : string)
                   (aIGlyph : string) 
                   (depth : int )
                   : int =
    let moves =
        makeDeepCopyOfArray(makeEmptyTicTacToeBox(ticTacToeBox.Length))(ticTacToeBox)
    let score = checkForWinnerOrTie(moves)(playerGlyph)(aIGlyph) 
    if score = int GenResult.NoWinner then
        let scores = makeEmptyScore(moves.Length)
        for i = 0 to moves.Length - 1 do
            if (insertPlayerGlyph(moves)(i)(playerGlyph)(aIGlyph)) then
                scores.[i] <- miniMaxMaxium(moves)(playerGlyph)(aIGlyph)(depth + 1)
                moves.[i] <- "-"+string (int i + int 1)+"-"
        findSmallestScore(scores)
    else
        depth + score

let computerMove(ticTacToeBox : array<string>)
                (playerGlyph : string)
                (aIGlyph : string)
                : int =
    let moves =
        makeDeepCopyOfArray(makeEmptyTicTacToeBox(ticTacToeBox.Length))(ticTacToeBox)
    let scores = makeEmptyScore(moves.Length)
    let mutable largestScore = -999
    let mutable pos = -1
    for i = 0 to moves.Length - 1 do
        if (insertAiGlyph(moves)(i)(playerGlyph)(aIGlyph)) then
            scores.[i] <- miniMaxMinimize(moves)(playerGlyph)(aIGlyph)(1)
            moves.[i] <- "-"+string (int i + int 1)+"-"
            if scores.[i] > largestScore then
                largestScore <- scores.[i]
                pos <- i
    pos

let aIMove(game : gameSetting) =
    game.ticTacToeBox.[computerMove(game.ticTacToeBox)(game.playerGlyph)(game.aIGlyph)] <- game.aIGlyph