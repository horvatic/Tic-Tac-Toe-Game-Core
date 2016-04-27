module CheckForWinnerOrTie
open GameStatusCodes
open GameSettings

let findBoxLength( ticTacToeBox : array<string>) : int =
    let result = sqrt(float ticTacToeBox.Length)
    int result

let hasTie ( ticTacToeBox : array<string>)(game : gameSetting) : bool =
    let mutable tie = true
    for i = 0 to ticTacToeBox.Length - 1 do
        if not (ticTacToeBox.[i] = game.playerGlyph || ticTacToeBox.[i] = game.aIGlyph) then
            tie <- false
    tie

let hasDiangleWin ( ticTacToeBox : array<string>) 
                  ( search : string)
                  ( notSearching : string)
                  : bool =
    let boxLength = findBoxLength(ticTacToeBox)
    let mutable nonSearchCnt = 0
    let mutable searchCnt = 0
    let mutable winner = false
    let mutable offset = 0
    //going right
    while offset < ticTacToeBox.Length do
            if ticTacToeBox.[offset] = notSearching then
                nonSearchCnt <- nonSearchCnt + 1
            elif ticTacToeBox.[offset] = search then
                searchCnt <- searchCnt + 1
            offset <- offset + boxLength + 1
    //going left
    if not (searchCnt = boxLength && nonSearchCnt = 0) then
        searchCnt <- 0
        nonSearchCnt <- 0
        offset <- boxLength - 1
        while offset < ticTacToeBox.Length - 1 do
            if ticTacToeBox.[offset] = notSearching then
                nonSearchCnt <- nonSearchCnt + 1
            elif ticTacToeBox.[offset] = search then
                searchCnt <- searchCnt + 1
            offset <- offset + boxLength - 1
    else
        winner <- true
    if searchCnt = boxLength && nonSearchCnt = 0 then
        winner <- true
    winner

let hasVerticalWin ( ticTacToeBox : array<string>) 
                   ( search : string)
                   ( notSearching : string)
                   : bool =
    let boxLength = findBoxLength(ticTacToeBox)
    let mutable nonSearchCnt = 0
    let mutable searchCnt = 0
    let mutable winner = false
    let mutable x = 0
    let mutable offset = 0
    while x < boxLength do
        offset <- 0
        nonSearchCnt <- 0
        searchCnt <- 0
        while offset < (boxLength*boxLength) - 2 do
            if ticTacToeBox.[x+offset] = notSearching then
                nonSearchCnt <- nonSearchCnt + 1
            elif ticTacToeBox.[x+offset] = search then
                searchCnt <- searchCnt + 1
            offset <- offset + boxLength
        if searchCnt = boxLength && nonSearchCnt = 0 then
            x <- 99
            offset <- 99
            winner <- true
        x <- x+1
    winner

let hasHorzontailWin ( ticTacToeBox : array<string>) 
                     ( search : string)
                     ( notSearching : string)
                     : bool =
    let boxLength = findBoxLength(ticTacToeBox)
    let mutable nonSearchCnt = 0
    let mutable searchCnt = 0
    let mutable winner = false
    let mutable x = -1
    let mutable offset = 0
    while offset < (boxLength*boxLength) - 2 do
        x <- 0
        nonSearchCnt <- 0
        searchCnt <- 0
        while x < boxLength do
            if ticTacToeBox.[x+offset] = notSearching then
                nonSearchCnt <- nonSearchCnt + 1
            elif ticTacToeBox.[x+offset] = search then
                searchCnt <- searchCnt + 1
            x <- x+1
        if searchCnt = boxLength && nonSearchCnt = 0 then
            x <- 99
            offset <- 99
            winner <- true
        offset <- offset + boxLength
    winner

let checkForWinnerOrTie( ticTacToeBox : array<string>)(game : gameSetting) : int =
    let mutable AiWinner = false
    let mutable HumanWinner = false
    let mutable resultsOfTest = int GenResult.NoWinner
    AiWinner <- hasHorzontailWin(ticTacToeBox) (game.aIGlyph) (game.playerGlyph)
    if not AiWinner then
        AiWinner <- hasVerticalWin(ticTacToeBox) (game.aIGlyph) (game.playerGlyph)
    if not AiWinner then
        AiWinner <- hasDiangleWin(ticTacToeBox) (game.aIGlyph) (game.playerGlyph)
    if not AiWinner then
        HumanWinner <- hasHorzontailWin(ticTacToeBox) (game.playerGlyph) (game.aIGlyph)
    if not HumanWinner then
        HumanWinner <- hasVerticalWin(ticTacToeBox) (game.playerGlyph) (game.aIGlyph)
    if not HumanWinner then
        HumanWinner <- hasDiangleWin(ticTacToeBox) (game.playerGlyph) (game.aIGlyph)

    if AiWinner then
        resultsOfTest <- getWinningAIValue(ticTacToeBox)
    elif HumanWinner then
        resultsOfTest <- getWinningHumanValue(ticTacToeBox)
    else
        if hasTie(ticTacToeBox)(game) then
            resultsOfTest <- int GenResult.Tie
        else
            resultsOfTest <- int GenResult.NoWinner
    resultsOfTest