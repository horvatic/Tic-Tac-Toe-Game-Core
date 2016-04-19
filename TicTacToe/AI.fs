module AI
open CheckForWinnerOrTie
type playerVals =
    | AI = 1
    | Human = -1

let rec minimax( ticTacToeBox : array<string>)(player : int)
             : int =
    let winner = checkForWinnerOrTie(ticTacToeBox)
    let mutable score = -2
    if not (winner = int Result.NoWinner) then 
        if winner = int Result.AiWins then 
            score <- int playerVals.AI
        elif winner = int Result.AiWins then 
            score <- int playerVals.Human
    else
        let mutable move = -1
        let mutable tempScore = -999
        let mutable ticTacToeBoxTemp = [|"1"; "2"; "3"; "4"; "5"; "6"; "7"; "8"; "9"|]
        for i = 0 to 8 do
            ticTacToeBoxTemp.[i] <- ticTacToeBox.[i]
        for i = 0 to 8 do
            if not (ticTacToeBoxTemp.[i] = "X" || ticTacToeBoxTemp.[i] = "@") then
                if player = int playerVals.AI then
                    ticTacToeBoxTemp.[i] <- "@"
                else
                    ticTacToeBoxTemp.[i] <- "X"
                tempScore <- -1 * minimax(ticTacToeBoxTemp) (player * -1)
                if tempScore > score then
                    score <- tempScore
                    move <- i
                ticTacToeBoxTemp.[i] <- "5"
        if move = -1 then
            score <- 0
    score

let computerMove( ticTacToeBox : array<string>)
             : int =
    let mutable move = -1
    let mutable score = -2
    let mutable tempScore = -999
    let mutable ticTacToeBoxTemp = [|"1"; "2"; "3"; "4"; "5"; "6"; "7"; "8"; "9"|]
    for i = 0 to 8 do
        ticTacToeBoxTemp.[i] <- ticTacToeBox.[i]
    for i = 0 to 8 do
        if not (ticTacToeBoxTemp.[i] = "X" || ticTacToeBoxTemp.[i] = "@") then
            ticTacToeBoxTemp.[i] <- "@"
            tempScore <- -1 * minimax(ticTacToeBoxTemp) (int playerVals.Human)
            ticTacToeBoxTemp.[i] <- "5"
            if tempScore > score then
                score <- tempScore
                move <- i
    move

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

let blockMove( ticTacToeBox : array<string>) : int =
    let mutable moveVal = -1
    moveVal <- bestMoveBeHorzontail(ticTacToeBox) ("X") ("@")
    if moveVal = -1 then
        moveVal <- bestMoveBeDiangle(ticTacToeBox) ("X") ("@")
    if moveVal = -1 then
        moveVal <- bestMoveBeVertical(ticTacToeBox) ("X") ("@")
    moveVal

let AIMove( ticTacToeBox : array<string>)
          : array<string> =
    let mutable move = computerMove(ticTacToeBox)
    if move = -1 then
        move <- blockMove(ticTacToeBox)
    if move = -1 then
        for i = 0 to 8 do
            if not (ticTacToeBox.[i] = "X" || ticTacToeBox.[i] = "@") then
                move <- i
    ticTacToeBox.[move] <- "@"
    ticTacToeBox
