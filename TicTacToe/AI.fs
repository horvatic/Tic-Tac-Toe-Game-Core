module AI
open CheckForWinnerOrTie
type playerVals =
    | AI = 1
    | Human = -1

let rec minimax( ticTacToeBox : array<string>)(player : int)
             : int =
    
    let mutable currentPlayer = player
    let mutable score = 0
    let mutable moves = [|"1"; "2"; "3"; "4"; "5"; "6"; "7"; "8"; "9"|]
    
    for i = 0 to 8 do
        moves.[i] <- ticTacToeBox.[i]

    score <- checkForWinnerOrTie(moves)
    if score = int Result.NoWinner then
        while score = int Result.NoWinner do
            let mutable scores = [|0; 0; 0; 0; 0; 0; 0; 0; 0|]
            for i = 0 to 8 do
                if not (moves.[i] = "X" || moves.[i] = "@") then
                    if currentPlayer = int playerVals.AI then
                        moves.[i] <- "@"
                        scores.[i] <- minimax(moves)(currentPlayer * -1)
                    else
                        moves.[i] <- "X"
                        scores.[i] <- minimax(moves)(currentPlayer * -1)
                    moves.[i] <- string (i+1)
                    printfn "%i %i %i %i %i %i %i %i %i %i" currentPlayer scores.[0] scores.[1] scores.[2] scores.[3] scores.[4] scores.[5] scores.[6] scores.[7] scores.[8]
        
            if currentPlayer = int playerVals.AI then
                let mutable bestScore = 0
                let mutable place = 0
                for i = 0 to 8 do
                    if bestScore < scores.[i] then
                        bestScore <- scores.[i]
                        place <- i
                moves.[place] <- "@"
            else
                let mutable bestScore = 0
                let mutable place = 0
                for i = 0 to 8 do
                    if bestScore > scores.[i] then
                        bestScore <- scores.[i]
                        place <- i
                moves.[place] <- "X"
            currentPlayer <- currentPlayer * -1
            score <- checkForWinnerOrTie(moves)   
    score

let computerMove( ticTacToeBox : array<string>)
             : int =
    let mutable scores = [|0; 0; 0; 0; 0; 0; 0; 0; 0|]
    for i = 0 to 8 do
        if not (ticTacToeBox.[i] = "X" || ticTacToeBox.[i] = "@") then
            ticTacToeBox.[i] <- "@"
            scores.[i] <- minimax(ticTacToeBox)(int playerVals.Human)
            ticTacToeBox.[i] <- string (i+1)
    
    let mutable bestScore = 0
    let mutable place = 0
    for i = 0 to 8 do
        if bestScore < scores.[i] then
            bestScore <- scores.[i]
            place <- i
    place

let AIMove( ticTacToeBox : array<string>)( firstMove : bool )
          : array<string> =
   
    ticTacToeBox.[computerMove(ticTacToeBox)] <- "@"
    ticTacToeBox
