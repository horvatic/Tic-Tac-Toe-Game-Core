module AI
open CheckForWinnerOrTie
type playerVals =
    | AI = 1
    | Human = -1

let bestMoveBeDiangle ( ticTacToeBox : array<string> )
                      ( search : string )
                      ( notSearching : string )
                      : int =
    let mutable nonSearchCnt = 0
    let mutable searchCnt = 0
    let mutable freePostion = -1
    let mutable offset = 0
    //going right
    while offset < 9 do
            if ticTacToeBox.[offset] = notSearching then
                nonSearchCnt <- nonSearchCnt + 1
            elif ticTacToeBox.[offset] = search then
                searchCnt <- searchCnt + 1
            else
                freePostion <- offset
            offset <- offset + 4
    //going left
    if not (searchCnt = 2 && nonSearchCnt = 0) then
        freePostion <- -1
        searchCnt <- 0
        nonSearchCnt <- 0
        offset <- 2
        while offset < 8 do
            if ticTacToeBox.[offset] = notSearching then
                nonSearchCnt <- nonSearchCnt + 1
            elif ticTacToeBox.[offset] = search then
                searchCnt <- searchCnt + 1
            else
                freePostion <- offset
            offset <- offset + 2
    if not (searchCnt = 2 && nonSearchCnt = 0) then
        freePostion <- -1
    freePostion

let bestMoveBeVertical ( ticTacToeBox : array<string> )
                       ( search : string )
                       ( notSearching : string )
                       : int =
    let mutable nonSearchCnt = 0
    let mutable searchCnt = 0
    let mutable freePostion = -1
    let mutable x = 0
    let mutable offset = 0
    while x < 3 do
        offset <- 0
        freePostion <- -1
        nonSearchCnt <- 0
        searchCnt <- 0
        while offset < 7 do
            if ticTacToeBox.[x+offset] = notSearching then
                nonSearchCnt <- nonSearchCnt + 1
            elif ticTacToeBox.[x+offset] = search then
                searchCnt <- searchCnt + 1
            else
                freePostion <- x+offset
            offset <- offset + 3
        if searchCnt = 2 && nonSearchCnt = 0 then
            x <- 99
            offset <- 99
        else
            freePostion <- -1
        x <- x+1
    freePostion

let bestMoveBeHorzontail ( ticTacToeBox : array<string> ) 
                         ( search : string )
                         ( notSearching : string )
                         : int =
    let mutable nonSearchCnt = 0
    let mutable searchCnt = 0
    let mutable freePostion = -1
    let mutable x = -1
    let mutable offset = 0
    while offset < 7 do
        x <- 0
        freePostion <- -1
        nonSearchCnt <- 0
        searchCnt <- 0
        while x < 3 do
            if ticTacToeBox.[x+offset] = notSearching then
                nonSearchCnt <- nonSearchCnt + 1
            elif ticTacToeBox.[x+offset] = search then
                searchCnt <- searchCnt + 1
            else
                freePostion <- x+offset
            x <- x+1
        if searchCnt = 2 && nonSearchCnt = 0 then
            x <- 99
            offset <- 99
        else
            freePostion <- -1
        offset <- offset + 3
    freePostion

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

            if currentPlayer = int playerVals.AI then
                score <- ( checkForWinnerOrTie(moves) )
            else
                score <- ( checkForWinnerOrTie(moves) )
            currentPlayer <- currentPlayer * -1
    if score = int Result.Tie then
        score <- 0
    score

let computerMove( ticTacToeBox : array<string>)
             : int =
    
    let mutable place = -1
    place <- bestMoveBeHorzontail(ticTacToeBox) ("@") ("X")
    if place = -1 then
        place <- bestMoveBeVertical(ticTacToeBox) ("@") ("X")
    if place = -1 then
        place <- bestMoveBeDiangle(ticTacToeBox) ("@") ("X")
    if place = -1 then
        let mutable scores = [|0; 0; 0; 0; 0; 0; 0; 0; 0|]
        for i = 0 to 8 do
            if not (ticTacToeBox.[i] = "X" || ticTacToeBox.[i] = "@") then
                ticTacToeBox.[i] <- "@"
                scores.[i] <- minimax(ticTacToeBox)(int playerVals.Human)
                ticTacToeBox.[i] <- string (i+1)
    
        let mutable bestScore = -999
        for i = 0 to 8 do
            if bestScore < scores.[i] && not (ticTacToeBox.[i] = "X" || ticTacToeBox.[i] = "@") then
                bestScore <- scores.[i]
                place <- i
    place

let AIMove( ticTacToeBox : array<string>)( firstMove : bool )
          : array<string> =
   
    ticTacToeBox.[computerMove(ticTacToeBox)] <- "@"
    ticTacToeBox
