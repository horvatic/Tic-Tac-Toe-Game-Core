module AI
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

let getEditedTicTacToeBox(ticTacToeBox : list<string>)(editPos : int)(editSymbol : string) : list<string> =
        [
            for i in 0 .. ticTacToeBox.Length - 1 -> 
                        (if editPos = i then
                            editSymbol
                        else
                            ticTacToeBox.[i])
        ]

let rec getMinScore(ticTacToeBox : list<string>)
                   (currentPos : int)
                   (playerGlyph : string)
                   (aIGlyph : string)
                   (prevoiusScore : int)
                   (depth : int ) : int = 

    if currentPos >= ticTacToeBox.Length then
        prevoiusScore
    else
        if ticTacToeBox.[currentPos] = playerGlyph || ticTacToeBox.[currentPos] = aIGlyph then 
            getMinScore(ticTacToeBox)(currentPos+1)(playerGlyph)(aIGlyph)(prevoiusScore)(depth)
        else
            let checkScore = miniMaxMaxium(getEditedTicTacToeBox(ticTacToeBox)(currentPos)(playerGlyph))
                                            (playerGlyph)
                                            (aIGlyph)
                                            (depth)
            
            let currentScore = getMinScore(ticTacToeBox)
                                          (currentPos+1)
                                          (playerGlyph)
                                          (aIGlyph)
                                          (checkScore)
                                          (depth)
            
            if currentScore < prevoiusScore then
                currentScore
            else
                prevoiusScore


and getMaxScore(ticTacToeBox : list<string>)
                   (currentPos : int)
                   (playerGlyph : string)
                   (aIGlyph : string)
                   (prevoiusScore : int)
                   (depth : int ) : int = 
    
    if currentPos >= ticTacToeBox.Length then
        prevoiusScore
    else
        if ticTacToeBox.[currentPos] = playerGlyph || ticTacToeBox.[currentPos] = aIGlyph then 
            getMaxScore(ticTacToeBox)(currentPos+1)(playerGlyph)(aIGlyph)(prevoiusScore)(depth)
        else
            let checkScore = miniMaxMinimize(getEditedTicTacToeBox(ticTacToeBox)(currentPos)(aIGlyph))
                                            (playerGlyph)
                                            (aIGlyph)
                                            (depth)
            
            let currentScore = getMaxScore(ticTacToeBox)
                                          (currentPos+1)
                                          (playerGlyph)
                                          (aIGlyph)
                                          (checkScore)
                                          (depth)
            
            if currentScore > prevoiusScore then
                currentScore
            else
                prevoiusScore

and miniMaxMaxium(ticTacToeBox : list<string>)
                (playerGlyph : string)
                (aIGlyph : string)
                (depth : int )
                : int =

    let score = checkForWinnerOrTie(ticTacToeBox |> List.toArray)(playerGlyph)(aIGlyph) 
    if score = int GenResult.NoWinner then
        getMaxScore(ticTacToeBox)(0)(playerGlyph)(aIGlyph)(-999)(depth + 1)
    else
        minimizeScoreCutOff(score)(depth)

and miniMaxMinimize(ticTacToeBox : list<string>)
                   (playerGlyph : string)
                   (aIGlyph : string) 
                   (depth : int )
                   : int =

    let score = checkForWinnerOrTie(ticTacToeBox |> List.toArray)(playerGlyph)(aIGlyph) 
    if score = int GenResult.NoWinner then
        getMinScore(ticTacToeBox)(0)(playerGlyph)(aIGlyph)(999)(depth + 1)
    else
        maxiumeScoreCutOff(score)(depth)


let rec computingMove(ticTacToeBox : list<string>)
                     (playerGlyph : string)
                     (aIGlyph : string)      
                     (prevoiusScoreAndPos : list<int>)
                     (currentPos : int)
                     : list<int> = 
   
    if currentPos >= ticTacToeBox.Length then
       prevoiusScoreAndPos
    else
        if ticTacToeBox.[currentPos] = playerGlyph || ticTacToeBox.[currentPos] = aIGlyph then 
            computingMove(ticTacToeBox)(playerGlyph)(aIGlyph)(prevoiusScoreAndPos)(currentPos + 1)
        else
            let checkScore = miniMaxMinimize(getEditedTicTacToeBox(ticTacToeBox)(currentPos)(aIGlyph))
                                            (playerGlyph)
                                            (aIGlyph)
                                            (0)
            
            let currentScoreAndPos = computingMove(ticTacToeBox)
                                                  (playerGlyph)(aIGlyph)
                                                  ([checkScore; currentPos])
                                                  (currentPos + 1)
            
            if currentScoreAndPos.[0] > prevoiusScoreAndPos.[0] then
                currentScoreAndPos
            else
                prevoiusScoreAndPos

let computerMove(ticTacToeBox : list<string>)
                (playerGlyph : string)
                (aIGlyph : string)
                : int =
    
    (computingMove(ticTacToeBox)(playerGlyph)(aIGlyph)([-999;-1])(0)).[1]


let aIMove(game : gameSetting) =
    game.ticTacToeBox.[computerMove(game.ticTacToeBox |> Array.toList)(game.playerGlyph)(game.aIGlyph)] <- game.aIGlyph