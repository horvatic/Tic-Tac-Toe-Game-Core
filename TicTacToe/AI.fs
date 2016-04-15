module AI

let firstAIMove ( ticTacToeBox : array<string>) : int =
    let mutable moveVal = 0
    if not (ticTacToeBox.[4] = "X") then
        moveVal <- 4
    else
        moveVal <- 8
    moveVal

let bestMove ( ticTacToeBox : array<string>) : int =
    let mutable putPostion = 0
    let mutable alreadyPlaces = false
    while not alreadyPlaces do
        if putPostion + 3 < 9  && ticTacToeBox.[putPostion] = "X" then
            if not (ticTacToeBox.[putPostion + 3] = "X" || ticTacToeBox.[putPostion + 3] = "@") then
                putPostion <- putPostion + 3
                alreadyPlaces <- true
            else
                putPostion <- putPostion + 1
        elif putPostion - 3 > 0 && ticTacToeBox.[putPostion] = "X" then
            if not (ticTacToeBox.[putPostion - 3] = "X" || ticTacToeBox.[putPostion - 3] = "@") then
                putPostion <- putPostion - 3
                alreadyPlaces <- true
            else
                putPostion <- putPostion + 1
        else
           putPostion <- putPostion + 1
        if putPostion = 8 then
            putPostion <- 0
            while not (ticTacToeBox.[putPostion - 3] = "X" || ticTacToeBox.[putPostion - 3] = "@") do
                putPostion <- putPostion + 1
            alreadyPlaces <- true
    putPostion

let moveBeDiangle ( ticTacToeBox : array<string>)
                  ( search : string)
                  ( notSearching : string)
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

let whichMove( ticTacToeBox : array<string>) 
             ( firstMove: bool )
             : int =
    let mutable moveVal = 0
    if not firstMove then
        moveVal <- moveBeHorzontail(ticTacToeBox) ("@") ("X")
        if moveVal = -1 then
            moveVal <- moveBeVertical(ticTacToeBox) ("@") ("X")
        if moveVal = -1 then
            moveVal <- moveBeDiangle(ticTacToeBox) ("@") ("X")
        if moveVal = -1 then
            moveVal <- moveBeHorzontail(ticTacToeBox) ("X") ("@")
        if moveVal = -1 then
            moveVal <- moveBeDiangle(ticTacToeBox) ("X") ("@")
        if moveVal = -1 then
            moveVal <- moveBeVertical(ticTacToeBox) ("X") ("@")
        if moveVal = -1 then
            moveVal <- bestMove (ticTacToeBox)
    else
        moveVal <- firstAIMove(ticTacToeBox)
    moveVal

let AIMove( ticTacToeBox : array<string>) 
          ( firstMove : bool )
          : array<string> =
    ticTacToeBox.[whichMove(ticTacToeBox)(firstMove)] <- "@"
    ticTacToeBox
