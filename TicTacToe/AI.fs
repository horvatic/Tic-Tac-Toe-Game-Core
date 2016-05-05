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

let findSmallestScore(scores : array<int>) : int = 
    let sortedScores = Array.sort(scores)
    sortedScores.[0]

let findLargestScore(scores : array<int>) : int = 
    let sortedScores = Array.sort(scores)
    sortedScores.[sortedScores.Length - 1]

let rec miniMaxMaxium(ticTacToeBox : array<string>)
                     (playerGlyph : string)
                     (aIGlyph : string)
                     (depth : int )
                     : int =
    if depth > 6 && ticTacToeBox.Length = 16 then
         minimizeScoreCutOff(int Result4X4.HumanWins)(depth)
    else
        let moves =
            makeDeepCopyOfArray(makeEmptyTicTacToeBox(ticTacToeBox.Length))(ticTacToeBox)
        let score = checkForWinnerOrTie(moves)(playerGlyph)(aIGlyph) 
        if score = int GenResult.NoWinner then
            let scores = makeEmptyScoreMin(moves.Length)
            for i = 0 to moves.Length - 1 do
                if (insertAiGlyph(moves)(i)(playerGlyph)(aIGlyph)) then
                    scores.[i] <- miniMaxMinimize(moves)(playerGlyph)(aIGlyph)(depth + 1)
                    moves.[i] <- "-"+string (int i + int 1)+"-"
            findLargestScore(scores)
        else
            minimizeScoreCutOff(score)(depth)

and miniMaxMinimize(ticTacToeBox : array<string>)
                   (playerGlyph : string)
                   (aIGlyph : string) 
                   (depth : int )
                   : int =

    if depth > 6 && ticTacToeBox.Length = 16 then
       maxiumeScoreCutOff(int Result4X4.AiWins)(depth)
    else
        let moves =
            makeDeepCopyOfArray(makeEmptyTicTacToeBox(ticTacToeBox.Length))(ticTacToeBox)
        let score = checkForWinnerOrTie(moves)(playerGlyph)(aIGlyph) 
        if score = int GenResult.NoWinner then
            let scores = makeEmptyScoreMax(moves.Length)
            for i = 0 to moves.Length - 1 do
                if (insertPlayerGlyph(moves)(i)(playerGlyph)(aIGlyph)) then
                    scores.[i] <- miniMaxMaxium(moves)(playerGlyph)(aIGlyph)(depth + 1)
                    moves.[i] <- "-"+string (int i + int 1)+"-"
            findSmallestScore(scores)
        else
            maxiumeScoreCutOff(score)(depth)

let computerMove(ticTacToeBox : array<string>)
                (playerGlyph : string)
                (aIGlyph : string)
                : int =
    let moves =
        makeDeepCopyOfArray(makeEmptyTicTacToeBox(ticTacToeBox.Length))(ticTacToeBox)
    let scores = makeEmptyScoreMin(moves.Length)
    let mutable largestScore = -999
    let mutable pos = -1
    for i = 0 to moves.Length - 1 do
        if (insertAiGlyph(moves)(i)(playerGlyph)(aIGlyph)) then
            scores.[i] <- miniMaxMinimize(moves)(playerGlyph)(aIGlyph)(1)
            moves.[i] <- "-"+string (int i + int 1)+"-"
            if scores.[i] > largestScore then
                largestScore <- scores.[i]
                pos <- i
    pos


let aIMove(game : gameSetting) =
    game.ticTacToeBox.[computerMove(game.ticTacToeBox)(game.playerGlyph)(game.aIGlyph)] <- game.aIGlyph