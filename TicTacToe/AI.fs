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
               (oldTrees : Dictionary<string, int>)
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
        score <- checkForWinnerOrTie(moves)
    
    if score = int GenResult.NoWinner then
        while score = int GenResult.NoWinner do
            let mutable scores = makeEmptyScore(ticTacToeBox.Length)
            for i = 0 to ticTacToeBox.Length - 1 do
                if (not (moves.[i] = "X" || moves.[i] = "@")) then
                    if currentPlayer = int playerVals.AI then
                        moves.[i] <- "@"
                        scores.[i] <- minimax(moves)(currentPlayer * -1)(oldTrees)
                        if not (oldTrees.ContainsKey(ticTacToeBoxToString(moves))) then
                            oldTrees.Add(ticTacToeBoxToString(moves), scores.[i])
                    else
                        moves.[i] <- "X"
                        scores.[i] <- minimax(moves)(currentPlayer * -1)(oldTrees)
                        if not (oldTrees.ContainsKey(ticTacToeBoxToString(moves))) then
                           oldTrees.Add(ticTacToeBoxToString(moves), scores.[i])
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
            searchDepth <- searchDepth + 1 
    
    if player = int playerVals.AI then
        score <- ( score - searchDepth)
    else
        score <- ( searchDepth + score )
    score

let movesCount ( ticTacToeBox : array<string>) : int =
    let mutable count = 0
    for i = 0 to ticTacToeBox.Length - 1 do
        if ticTacToeBox.[i] = "X" || ticTacToeBox.[i] = "@" then
            count <- count + 1
    count

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

    if movesCount(ticTacToeBox) < 4 && ticTacToeBox.Length = 16 then
        moveHere(ticTacToeBox)
    elif movesCount(ticTacToeBox) = 1 && ticTacToeBox.Length = 9 then
        if (not (ticTacToeBox.[4] = "X" || ticTacToeBox.[4] = "@")) then
            4
        else
            8
    else
        let mutable place = -1
        let oldTrees = new Dictionary<string, int>()
        let mutable scores = makeEmptyScore(ticTacToeBox.Length)
        for i = 0 to ticTacToeBox.Length - 1 do
            if (not (ticTacToeBox.[i] = "X" || ticTacToeBox.[i] = "@")) then
                ticTacToeBox.[i] <- "@"
                scores.[i] <- minimax(ticTacToeBox)(int playerVals.Human)(oldTrees)
                ticTacToeBox.[i] <- string (i+1)
    
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
