module AI
open CheckForWinnerOrTie
open PlayerValues
open GameStatusCodes
open System.Collections.Generic

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
        let ticTacToeBox = [|"1"; "2"; "3"; "4"; "5"; "6"; "7"; "8"; "9"|]
        ticTacToeBox
    else
        let ticTacToeBox = [|"1"; "2"; "3"; "4"; 
                        "5"; "6"; "7"; "8"; 
                        "9"; "10"; "11"; "12";
                        "13"; "14"; "15"; "16"|]
        ticTacToeBox

let rec minimax( ticTacToeBox : array<string>)(player : int)
               ( depth : int)(oldTrees : Dictionary<string, int>)
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
        score <- checkForWinnerOrTie(moves)
    if score = int GenResult.NoWinner then
        while score = int GenResult.NoWinner do
            let mutable scores = makeEmptyScore(ticTacToeBox.Length)
            let mutable skip = false
            for i = 0 to ticTacToeBox.Length - 1 do
                if (not (moves.[i] = "X" || moves.[i] = "@")) && not skip then
                    if currentPlayer = int playerVals.AI then
                        moves.[i] <- "@"
                        scores.[i] <- minimax(moves)(currentPlayer * -1)(depth + 1)(oldTrees)
                        if not (oldTrees.ContainsKey(ticTacToeBoxToString(moves))) then
                            oldTrees.Add(ticTacToeBoxToString(moves), scores.[i])
                        if scores.[i] = int (getWinningAIValue(ticTacToeBox)) - (depth + 1) then
                            skip <- true
                    else
                        moves.[i] <- "X"
                        scores.[i] <- minimax(moves)(currentPlayer * -1)(depth + 1)(oldTrees)
                        if not (oldTrees.ContainsKey(ticTacToeBoxToString(moves))) then
                            oldTrees.Add(ticTacToeBoxToString(moves), scores.[i])
                        if scores.[i] = (depth + 1) + (getWinningHumanValue(ticTacToeBox)) then
                            skip <- true
                    moves.[i] <- string (i+1)
            if currentPlayer = int playerVals.AI then
                let mutable bestScore = -999
                let mutable place = -1
                for i = 0 to ticTacToeBox.Length - 1 do
                    if bestScore < scores.[i] && not (moves.[i] = "X" || moves.[i] = "@") then
                        bestScore <- scores.[i]
                        place <- i
                moves.[place] <- "@"
            else
                let mutable bestScore = 999
                let mutable place = -1
                for i = 0 to ticTacToeBox.Length - 1 do
                    if bestScore > scores.[i] && not (moves.[i] = "X" || moves.[i] = "@") then
                        bestScore <- scores.[i]
                        place <- i
                moves.[place] <- "X"

            score <- checkForWinnerOrTie(moves)
            if currentPlayer = int playerVals.AI then
                if not (score = int GenResult.NoWinner) then
                    score <- ( score - depth)
            else
                if not (score = int GenResult.NoWinner) then
                    score <- ( depth + score )
            currentPlayer <- currentPlayer * -1
    score

let isFirstThreeMoves ( ticTacToeBox : array<string>) : bool =
    let mutable count = 0
    for i = 0 to ticTacToeBox.Length - 1 do
        if ticTacToeBox.[i] = "X" || ticTacToeBox.[i] = "@" then
            count <- count + 1
    if count < 4 then
        true
    else
        false

let moveHere( ticTacToeBox : array<string>)
             : int =
    let mutable place = -1
    let mutable i = 0
    while place = -1 do
        if not (ticTacToeBox.[i] = "X" || ticTacToeBox.[i] = "@") then
            place <- i
        else
            i <- i + 1
    place

let computerMove( ticTacToeBox : array<string>)
             : int =

    if isFirstThreeMoves(ticTacToeBox) && ticTacToeBox.Length = 16 then
        moveHere(ticTacToeBox)
    else
    let oldTrees = new Dictionary<string, int>()
    let mutable place = -1
    let mutable skip = false
    let mutable scores = makeEmptyScore(ticTacToeBox.Length)
    for i = 0 to ticTacToeBox.Length - 1 do
        if (not (ticTacToeBox.[i] = "X" || ticTacToeBox.[i] = "@")) && not skip then
            ticTacToeBox.[i] <- "@"
            scores.[i] <- minimax(ticTacToeBox)(int playerVals.Human)(1)(oldTrees)
            ticTacToeBox.[i] <- string (i+1)
            if scores.[i] = 9 then
                skip <- true
    
        let mutable bestScore = -999
        for i = 0 to ticTacToeBox.Length - 1 do
            if bestScore < scores.[i] && not (ticTacToeBox.[i] = "X" || ticTacToeBox.[i] = "@") then
                bestScore <- scores.[i]
                place <- i
    place

let AIMove( ticTacToeBox : array<string>)
          : array<string> =
   
    ticTacToeBox.[computerMove(ticTacToeBox)] <- "@"
    ticTacToeBox
