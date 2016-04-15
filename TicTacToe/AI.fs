module AI

let bestMove ( ticTacToeBox : array<string>) : int =
    0

let moveBeVertical ( ticTacToeBox : array<string>)
                   ( search : string)
                   ( notSearching : string)
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

let moveBeHorzontail ( ticTacToeBox : array<string>) 
                     ( search : string)
                     ( notSearching : string)
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

let whichMove( ticTacToeBox : array<string>) :  int =
    let mutable moveVal = moveBeHorzontail(ticTacToeBox) ("O") ("X")
    if moveVal = -1 then
        moveVal <- moveBeVertical(ticTacToeBox) ("O") ("X")
    if moveVal = -1 then
        moveVal <- bestMove(ticTacToeBox)
    moveVal

let AIMove( ticTacToeBox : array<string>) : array<string> =
    ticTacToeBox.[whichMove(ticTacToeBox)] <- "O"
    ticTacToeBox
