namespace TicTacToe.Core 
module CheckForWinnerOrTie =
    open GameStatusCodes
    open GameSettings
    open ITicTacToeBoxClass

    let rec doesHaveTie(board : ITicTacToeBox)
                   (playerGlyph : string)
                   (aIGlyph : string)
                   (pos : int) : bool =

        if pos >= board.cellCount() then
            true
        elif not(board.getGlyphAtLocation(pos) =  playerGlyph || board.getGlyphAtLocation(pos) =  aIGlyph) then
            false
        else
            doesHaveTie(board)(playerGlyph)(aIGlyph)(pos+1)
    

    let hasTie ( ticTacToeBox : ITicTacToeBox)
               ( playerGlyph : string)
               ( aIGlyph : string) : bool =
        doesHaveTie(ticTacToeBox)(playerGlyph)(aIGlyph)(0)


    let rec checkForDiangeWinRight(board : ITicTacToeBox) 
                                  (search : string)
                                  (searchIndex : int)
                                  : bool =
        if searchIndex < board.cellCount() then
            if board.getGlyphAtLocation(searchIndex) = search then
                let boxLength = board.victoryCellCount()
                if searchIndex + boxLength + 1 > board.cellCount() - 1 then
                    true
                else
                    (true && checkForDiangeWinRight(board)(search)(searchIndex + boxLength + 1))
            else
                false
        else
            true
        


    let rec checkForDiangeWinLeft(board : ITicTacToeBox) 
                             (search : string)
                             (searchIndex : int)
                             : bool =
        if searchIndex < board.cellCount() then
            if board.getGlyphAtLocation(searchIndex) = search then
                let boxLength = board.victoryCellCount()
                if searchIndex + boxLength - 1 > board.cellCount() - 2 then
                    true
                else
                    (true && checkForDiangeWinLeft(board)(search)(searchIndex + boxLength - 1))
            else
                false
        else
            true

    let hasDiangleWin(board : ITicTacToeBox) 
                    (search : string)
                    : bool =
        if checkForDiangeWinRight(board)(search)(0) = true then
            true
        elif checkForDiangeWinLeft(board)(search)(board.victoryCellCount() - 1) = true then
            true
        else
            false

    let rec verticalTrurthValue(board : ITicTacToeBox)
                               (search : string)
                               (indexOfSearch : int)
                               (searchSpacSize : int) : bool =
        if indexOfSearch < board.cellCount() then
            if board.getGlyphAtLocation(indexOfSearch) = search then
                if (indexOfSearch + searchSpacSize) > board.cellCount() - 1 then
                    true
                else
                    (true && verticalTrurthValue(board)(search)(indexOfSearch + searchSpacSize)(searchSpacSize))
            else
                false
        else
            true

    let rec hasVerticalWin(board : ITicTacToeBox) 
                            (search : string)
                            (indexSearch : int)
                            : bool =
        let boxLength = board.victoryCellCount()
        if indexSearch < boxLength then
            if(verticalTrurthValue(board)(search)(indexSearch)(boxLength) = true) then 
                true
            else
                hasVerticalWin(board)(search)(indexSearch + 1)
        else
            false

    let rec horzontailTrurthValue(board : ITicTacToeBox)
                                 (search : string)
                                 (indexOfSearch : int)
                                 (offset : int)
                                 (searchSpacSize : int) : bool =

        if(indexOfSearch + offset) < board.cellCount() then
            if board.getGlyphAtLocation(indexOfSearch + offset) = search then
                if (indexOfSearch + 1) > searchSpacSize - 1 then
                    true
                else
                    (true && horzontailTrurthValue(board)(search)(indexOfSearch + 1)(offset)(searchSpacSize))
            else
                false
        else
            true

    let rec hasHorzontailWin(ticTacToeBox : ITicTacToeBox) 
                            (search : string)
                            (offset : int)
                            : bool =
        let boxLength = ticTacToeBox.victoryCellCount()
        if offset < (boxLength*boxLength) - 1 then
            if(horzontailTrurthValue(ticTacToeBox)(search)(0)(offset)(boxLength) = true) then 
                true
            else
                hasHorzontailWin(ticTacToeBox)(search)(offset+boxLength)
        else
            false

    let hasHumanWinner(ticTacToeBox : ITicTacToeBox) 
                      (playerGlyph : string)
                      (aIGlyph : string) : bool =
        if hasHorzontailWin(ticTacToeBox) (playerGlyph)(0)
            || hasVerticalWin(ticTacToeBox)(playerGlyph)(0)
            || hasDiangleWin(ticTacToeBox)(playerGlyph) then
            true
        else
            false

    let hasAiWinner(ticTacToeBox : ITicTacToeBox) 
                   (playerGlyph : string)
                   (aIGlyph : string) : bool =
    
        if hasVerticalWin(ticTacToeBox)(aIGlyph)(0)
            || hasDiangleWin(ticTacToeBox)(aIGlyph)
            || hasHorzontailWin(ticTacToeBox)(aIGlyph)(0) then
            true
        else
            false

    let checkForWinnerOrTie( ticTacToeBox : ITicTacToeBox) 
                           ( playerGlyph : string)
                           ( aIGlyph : string) : int =
    
        if hasAiWinner(ticTacToeBox)(playerGlyph)(aIGlyph)then
            getWinningAIValue(ticTacToeBox.victoryCellCount())
        elif hasHumanWinner(ticTacToeBox)(playerGlyph)(aIGlyph) then
             getWinningHumanValue(ticTacToeBox.victoryCellCount())
        elif hasTie(ticTacToeBox)(playerGlyph)(aIGlyph) then
                int GenResult.Tie
        else
            int GenResult.NoWinner