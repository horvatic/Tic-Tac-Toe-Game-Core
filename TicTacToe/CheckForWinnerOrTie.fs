module CheckForWinnerOrTie
open GameStatusCodes
open GameSettings

let findBoxLength( ticTacToeBox : array<string>) : int =
    let result = sqrt(float ticTacToeBox.Length)
    int result

let rec doesHaveTie(ticTacToeBox : list<string>)
               (playerGlyph : string)
               (aIGlyph : string)
               (pos : int) : bool =

    if pos >= ticTacToeBox.Length then
        true
    elif not(ticTacToeBox.[pos] =  playerGlyph || ticTacToeBox.[pos] =  aIGlyph) then
        false
    else
        doesHaveTie(ticTacToeBox)(playerGlyph)(aIGlyph)(pos+1)
    

let hasTie ( ticTacToeBox : list<string>)
           ( playerGlyph : string)
           ( aIGlyph : string) : bool =
    
    doesHaveTie(ticTacToeBox)(playerGlyph)(aIGlyph)(0)

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

let hasHumanWinner(ticTacToeBox : list<string>) 
                  (playerGlyph : string)
                  (aIGlyph : string) : bool =
    if hasHorzontailWin(ticTacToeBox |> List.toArray) (playerGlyph) (aIGlyph)
        || hasVerticalWin(ticTacToeBox |> List.toArray)(playerGlyph)(aIGlyph)
        || hasDiangleWin(ticTacToeBox |> List.toArray)(playerGlyph)(aIGlyph) then
        true
    else
        false

let hasAiWinner(ticTacToeBox : list<string>) 
               (playerGlyph : string)
               (aIGlyph : string) : bool =
    
    if hasVerticalWin(ticTacToeBox |> List.toArray)(aIGlyph)(playerGlyph)
        || hasDiangleWin(ticTacToeBox |> List.toArray) (aIGlyph) (playerGlyph)
        || hasHorzontailWin(ticTacToeBox |> List.toArray) (aIGlyph) (playerGlyph) then
        true
    else
        false

let checkForWinnerOrTie( ticTacToeBox : array<string>) 
                       ( playerGlyph : string)
                       ( aIGlyph : string) : int =
    
    if hasAiWinner(ticTacToeBox |> Array.toList)(playerGlyph)(aIGlyph)then
        getWinningAIValue(ticTacToeBox)
    elif hasHumanWinner(ticTacToeBox |> Array.toList)(playerGlyph)(aIGlyph) then
         getWinningHumanValue(ticTacToeBox)
    elif hasTie(ticTacToeBox |> Array.toList)(playerGlyph)(aIGlyph) then
            int GenResult.Tie
    else
        int GenResult.NoWinner