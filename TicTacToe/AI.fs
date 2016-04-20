module AI
open CheckForWinnerOrTie
type playerVals =
    | AI = 1
    | Human = -1

let rec minimax( ticTacToeBox : array<string>)(player : int)
             : array<int> =
    let mutable bestScoreAndPlace = [|0; 0|]
    let mutable moveSpace = 1
    let mutable score = checkForWinnerOrTie(ticTacToeBox) 
    if score = int Result.NoWinner then
        score <- 0
        let mutable scores = [|0; 0; 0; 0; 0; 0; 0; 0; 0|]
        let mutable moves = [|"1"; "2"; "3"; "4"; "5"; "6"; "7"; "8"; "9"|]
        for i = 0 to 8 do
            moves.[i] <- ticTacToeBox.[i]
        
        let mutable bestScoreAndPlaceCans = [|0; 0|]
        for i = 0 to 8 do
            if not (moves.[i] = "X" || moves.[i] = "@") then
                if player = int playerVals.AI then
                    moves.[i] <- "@"
                else
                    moves.[i] <- "X"
                bestScoreAndPlaceCans <- minimax( ticTacToeBox )(player * -1)
                scores.[i] <- bestScoreAndPlaceCans.[0]
                moves.[i] <- string i
            else 
                scores.[i] <- 99999

        moveSpace <- -1
        if player = int playerVals.AI then
            for i = 0 to 8 do
                if scores.[i] > score && score < 99999 then
                    score <- scores.[i]
                    moveSpace <- i
        else
            for i = 0 to 8 do
                if scores.[i] < score && score < 99999 then
                    score <- scores.[i]
                    moveSpace <- i
            
        if player = int playerVals.AI && moveSpace > -1 then
            moves.[moveSpace] <- "@"
        elif player = int playerVals.Human && moveSpace > -1 then
            moves.[moveSpace] <- "X"

    elif score = int Result.Tie then
        score <- 0
    bestScoreAndPlace.[0] <- score
    bestScoreAndPlace.[1] <- moveSpace
    bestScoreAndPlace

let computerMove( ticTacToeBox : array<string>)
             : int =
    let mutable bestScoreAndPlace = minimax(ticTacToeBox)(int playerVals.AI)
    bestScoreAndPlace.[1]

let AIMove( ticTacToeBox : array<string>)( firstMove : bool )
          : array<string> =
   
    ticTacToeBox.[computerMove(ticTacToeBox)] <- "@"
    ticTacToeBox
