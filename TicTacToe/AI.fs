module AI
open CheckForWinnerOrTie
open PlayerValues
open GameStatusCodes
open System.Collections.Generic
open GameSettings

//***************************************TEST CODE REMOVE IN REFACOR*************************
let insertPlayerGlyph(ticTacToeBox : array<string>)
                     (insetPostion : int)
                     (playerGlyph : string)
                     (aIGlyph : string) : bool =
    if ticTacToeBox.[insetPostion] = playerGlyph || ticTacToeBox.[insetPostion] = aIGlyph then
        false
    else
        ticTacToeBox.[insetPostion] <- playerGlyph
        true

let insertAiGlyph(ticTacToeBox : array<string>)
                 (insetPostion : int)
                 (playerGlyph : string)
                 (aIGlyph : string) : bool =
    if ticTacToeBox.[insetPostion] = playerGlyph || ticTacToeBox.[insetPostion] = aIGlyph then
        false
    else
        ticTacToeBox.[insetPostion] <- aIGlyph
        true

let makeEmptyScoreMax ( length : int ) : array<int> =
    if length = 9 then
        [|999; 999; 999; 999; 999; 999; 999; 999; 999|]
    else
        [|999; 999; 999; 999; 
        999; 999; 999; 999;
        999; 999; 999; 999;
        999; 999; 999; 999;|]

let makeEmptyScoreMin ( length : int ) : array<int> =
    if length = 9 then
        [|-999; -999; -999; -999; -999; -999; -999; -999; -999|]
    else
        [|-999; -999; -999; -999; 
        -999; -999; -999; -999;
        -999; -999; -999; -999;
        -999; -999; -999; -999;|]

let makeDeepCopyOfArray(copyTo : array<string>)
                       (copyFrom : array<string> ) 
                       : array<string> = 
    for i = 0 to copyFrom.Length - 1 do
        copyTo.[i] <- copyFrom.[i]
    copyTo

let makeEmptyTicTacToeBox( length : int ) : array<string> =
    if length = 9 then
        [|"-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"|]
    else
        [|"-1-"; "-2-"; "-3-"; "-4-"; 
        "-5-"; "-6-"; "-7-"; "-8-"; 
        "-9-"; "-10-"; "-11-"; "-12-";
        "-13-"; "-14-"; "-15-"; "-16-"|]
//**************************************************************************************************




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
    
    
    (*
    let tempTicTacToeBox = ticTacToeBox |> List.toArray
    let moves =
        makeDeepCopyOfArray(makeEmptyTicTacToeBox(ticTacToeBox.Length))(tempTicTacToeBox)
    let scores = makeEmptyScoreMin(moves.Length)
    let mutable largestScore = -999
    let mutable pos = -1
    for i = 0 to moves.Length - 1 do
        if (insertAiGlyph(moves)(i)(playerGlyph)(aIGlyph)) then
            scores.[i] <- miniMaxMinimize(moves |> Array.toList)(playerGlyph)(aIGlyph)(0)
            moves.[i] <- "-"+string (int i + int 1)+"-"
            if scores.[i] > largestScore then
                largestScore <- scores.[i]
                pos <- i
    pos
    *)

let aIMove(game : gameSetting) =
    game.ticTacToeBox.[computerMove(game.ticTacToeBox |> Array.toList)(game.playerGlyph)(game.aIGlyph)] <- game.aIGlyph