module AI
open CheckForWinnerOrTie
type playerVals =
    | AI = 1
    | Human = -1

let rec minimax( ticTacToeBox : array<string>)(player : int)( depth : int)
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
                        scores.[i] <- minimax(moves)(currentPlayer * -1)(depth + 1)
                    else
                        moves.[i] <- "X"
                        scores.[i] <- minimax(moves)(currentPlayer * -1)(depth + 1)
                    moves.[i] <- string (i+1)
            if currentPlayer = int playerVals.AI then
                let mutable bestScore = -999
                let mutable place = -1
                for i = 0 to 8 do
                    if bestScore < scores.[i] && not (moves.[i] = "X" || moves.[i] = "@") then
                        bestScore <- scores.[i]
                        place <- i
                moves.[place] <- "@"
            else
                let mutable bestScore = 999
                let mutable place = -1
                for i = 0 to 8 do
                    if bestScore > scores.[i] && not (moves.[i] = "X" || moves.[i] = "@") then
                        bestScore <- scores.[i]
                        place <- i
                moves.[place] <- "X"

            score <- checkForWinnerOrTie(moves)
            if currentPlayer = int playerVals.AI then
                if not (score = int Result.NoWinner) then
                    score <- ( score - depth)
            else
                if not (score = int Result.NoWinner) then
                    score <- ( depth + score )
            currentPlayer <- currentPlayer * -1
    score

let computerMove( ticTacToeBox : array<string>)
             : int =
    
    let mutable place = -1
    let mutable scores = [|0; 0; 0; 0; 0; 0; 0; 0; 0|]
    for i = 0 to 8 do
        if not (ticTacToeBox.[i] = "X" || ticTacToeBox.[i] = "@") then
            ticTacToeBox.[i] <- "@"
            scores.[i] <- minimax(ticTacToeBox)(int playerVals.Human)(1)
            ticTacToeBox.[i] <- string (i+1)
    
    let mutable bestScore = -999
    for i = 0 to 8 do
        if bestScore < scores.[i] && not (ticTacToeBox.[i] = "X" || ticTacToeBox.[i] = "@") then
            bestScore <- scores.[i]
            place <- i
    place

let AIMove( ticTacToeBox : array<string>)
          : array<string> =
   
    ticTacToeBox.[computerMove(ticTacToeBox)] <- "@"
    ticTacToeBox
