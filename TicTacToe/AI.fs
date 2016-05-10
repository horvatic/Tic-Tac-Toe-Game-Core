module AI
open TicTacToeBoxClass
open CheckForWinnerOrTie
open PlayerValues
open GameStatusCodes
open System.Collections.Generic
open GameSettings

let maxiumeScoreCutOff(score : int)(depth : int ) : int =
    if score - depth < int GenResult.Tie then
        int GenResult.Tie
    else
        score - depth

let minimizeScoreCutOff(score : int)(depth : int ) : int =
    if score + depth > int GenResult.Tie then
        int GenResult.Tie
    else
        score + depth

let rec getMinScore(board : TicTacToeBox)
                   (currentPos : int)
                   (playerGlyph : string)
                   (aIGlyph : string)
                   (prevoiusScore : int)
                   (depth : int ) : int = 

    if currentPos >= board.cellCount() then
        prevoiusScore
    else
        if board.getGlyphAtLocation(currentPos) = playerGlyph || board.getGlyphAtLocation(currentPos) = aIGlyph then 
            getMinScore(board)(currentPos+1)(playerGlyph)(aIGlyph)(prevoiusScore)(depth)
        else
            let checkScore = miniMaxMaxium(board.getTicTacToeBoxEdited(currentPos, playerGlyph, playerGlyph, aIGlyph))
                                            (playerGlyph)
                                            (aIGlyph)
                                            (depth)
            
            let currentScore = getMinScore(board)
                                          (currentPos+1)
                                          (playerGlyph)
                                          (aIGlyph)
                                          (checkScore)
                                          (depth)
            
            if currentScore < prevoiusScore then
                currentScore
            else
                prevoiusScore


and getMaxScore(board : TicTacToeBox)
                   (currentPos : int)
                   (playerGlyph : string)
                   (aIGlyph : string)
                   (prevoiusScore : int)
                   (depth : int ) : int = 
    
    if currentPos >= board.cellCount() then
        prevoiusScore
    else
        if board.getGlyphAtLocation(currentPos) = playerGlyph || board.getGlyphAtLocation(currentPos) = aIGlyph then 
            getMaxScore(board)(currentPos+1)(playerGlyph)(aIGlyph)(prevoiusScore)(depth)
        else
            let checkScore = miniMaxMinimize(board.getTicTacToeBoxEdited(currentPos, aIGlyph, playerGlyph, aIGlyph))
                                            (playerGlyph)
                                            (aIGlyph)
                                            (depth)
            
            let currentScore = getMaxScore(board)
                                          (currentPos+1)
                                          (playerGlyph)
                                          (aIGlyph)
                                          (checkScore)
                                          (depth)
            
            if currentScore > prevoiusScore then
                currentScore
            else
                prevoiusScore

and miniMaxMaxium(board : TicTacToeBox)
                (playerGlyph : string)
                (aIGlyph : string)
                (depth : int )
                : int =

    let score = checkForWinnerOrTie(board)(playerGlyph)(aIGlyph) 
    if score = int GenResult.NoWinner then
        getMaxScore(board)(0)(playerGlyph)(aIGlyph)(-999)(depth + 1)
    else
        minimizeScoreCutOff(score)(depth)

and miniMaxMinimize(board : TicTacToeBox)
                   (playerGlyph : string)
                   (aIGlyph : string) 
                   (depth : int )
                   : int =

    let score = checkForWinnerOrTie(board)(playerGlyph)(aIGlyph) 
    if score = int GenResult.NoWinner then
        getMinScore(board)(0)(playerGlyph)(aIGlyph)(999)(depth + 1)
    else
        maxiumeScoreCutOff(score)(depth)


let rec computingMove(board : TicTacToeBox)
                     (playerGlyph : string)
                     (aIGlyph : string)      
                     (prevoiusScoreAndPos : list<int>)
                     (currentPos : int)
                     : list<int> = 
   
    if currentPos >= board.cellCount() then
       prevoiusScoreAndPos
    else
        if board.getGlyphAtLocation(currentPos) = playerGlyph || board.getGlyphAtLocation(currentPos) = aIGlyph then 
            computingMove(board)(playerGlyph)(aIGlyph)(prevoiusScoreAndPos)(currentPos + 1)
        else
            let checkScore = miniMaxMinimize(board.getTicTacToeBoxEdited(currentPos, aIGlyph, playerGlyph, aIGlyph))
                                            (playerGlyph)
                                            (aIGlyph)
                                            (0)
            
            let currentScoreAndPos = computingMove(board)
                                                  (playerGlyph)(aIGlyph)
                                                  ([checkScore; currentPos])
                                                  (currentPos + 1)
            
            if currentScoreAndPos.[0] > prevoiusScoreAndPos.[0] then
                currentScoreAndPos
            else
                prevoiusScoreAndPos

let computerMove(board : TicTacToeBox)
                (playerGlyph : string)
                (aIGlyph : string)
                : int =
    
    (computingMove(board)(playerGlyph)(aIGlyph)([-999;-1])(0)).[1]


let aIMove(game : gameSetting)(board : TicTacToeBox) : TicTacToeBox =
    board.getTicTacToeBoxEdited(computerMove(board)(game.playerGlyph)(game.aIGlyph), game.aIGlyph, game.playerGlyph, game.aIGlyph)
    