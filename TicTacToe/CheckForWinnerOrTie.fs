module CheckForWinnerOrTie
type Result =
   | Tie = 0
   | AiWins = 10
   | HumanWins = -10
   | NoWinner = -9999

let hasTie ( ticTacToeBox : array<string>) : bool =
    let mutable tie = true
    for i = 0 to 8 do
        if not (ticTacToeBox.[i] = "X" || ticTacToeBox.[i] = "@") then
            tie <- false
    tie

let hasDiangleWin ( ticTacToeBox : array<string>) 
                  ( search : string)
                  ( notSearching : string)
                  : bool =
    let mutable nonSearchCnt = 0
    let mutable searchCnt = 0
    let mutable winner = false
    let mutable offset = 0
    //going right
    while offset < 9 do
            if ticTacToeBox.[offset] = notSearching then
                nonSearchCnt <- nonSearchCnt + 1
            elif ticTacToeBox.[offset] = search then
                searchCnt <- searchCnt + 1
            offset <- offset + 4
    //going left
    if not (searchCnt = 3 && nonSearchCnt = 0) then
        searchCnt <- 0
        nonSearchCnt <- 0
        offset <- 2
        while offset < 8 do
            if ticTacToeBox.[offset] = notSearching then
                nonSearchCnt <- nonSearchCnt + 1
            elif ticTacToeBox.[offset] = search then
                searchCnt <- searchCnt + 1
            offset <- offset + 2
    else
        winner <- true
    if searchCnt = 3 && nonSearchCnt = 0 then
        winner <- true
    winner

let hasVerticalWin ( ticTacToeBox : array<string>) 
                   ( search : string)
                   ( notSearching : string)
                   : bool =
    let mutable nonSearchCnt = 0
    let mutable searchCnt = 0
    let mutable winner = false
    let mutable x = 0
    let mutable offset = 0
    while x < 3 do
        offset <- 0
        nonSearchCnt <- 0
        searchCnt <- 0
        while offset < 7 do
            if ticTacToeBox.[x+offset] = notSearching then
                nonSearchCnt <- nonSearchCnt + 1
            elif ticTacToeBox.[x+offset] = search then
                searchCnt <- searchCnt + 1
            offset <- offset + 3
        if searchCnt = 3 && nonSearchCnt = 0 then
            x <- 99
            offset <- 99
            winner <- true
        x <- x+1
    winner

let hasHorzontailWin ( ticTacToeBox : array<string>) 
                     ( search : string)
                     ( notSearching : string)
                     : bool =
    let mutable nonSearchCnt = 0
    let mutable searchCnt = 0
    let mutable winner = false
    let mutable x = -1
    let mutable offset = 0
    while offset < 7 do
        x <- 0
        nonSearchCnt <- 0
        searchCnt <- 0
        while x < 3 do
            if ticTacToeBox.[x+offset] = notSearching then
                nonSearchCnt <- nonSearchCnt + 1
            elif ticTacToeBox.[x+offset] = search then
                searchCnt <- searchCnt + 1
            x <- x+1
        if searchCnt = 3 && nonSearchCnt = 0 then
            x <- 99
            offset <- 99
            winner <- true
        offset <- offset + 3
    winner

let checkForWinnerOrTie( ticTacToeBox : array<string>) : int =
    let mutable AiWinner = false
    let mutable HumanWinner = false
    let mutable resultsOfTest = int Result.NoWinner
    AiWinner <- hasHorzontailWin(ticTacToeBox) ("@") ("X")
    if not AiWinner then
        AiWinner <- hasVerticalWin(ticTacToeBox) ("@") ("X")
    if not AiWinner then
        AiWinner <- hasDiangleWin(ticTacToeBox) ("@") ("X")
    if not AiWinner then
        HumanWinner <- hasHorzontailWin(ticTacToeBox) ("X") ("@")
    if not HumanWinner then
        HumanWinner <- hasVerticalWin(ticTacToeBox) ("X") ("@")
    if not HumanWinner then
        HumanWinner <- hasDiangleWin(ticTacToeBox) ("X") ("@")

    if AiWinner then
        resultsOfTest <- int Result.AiWins
    elif HumanWinner then
        resultsOfTest <- int Result.HumanWins
    else
        if hasTie(ticTacToeBox) then
            resultsOfTest <- int Result.Tie
        else
            resultsOfTest <- int Result.NoWinner
    resultsOfTest