module AITest
open Xunit 
open FsUnit
open AI
open CheckForWinnerOrTie
open PlayerValues
open GameStatusCodes
open System.Collections.Generic
open GameSettings
open InputOutPutTestGame

let rec humanAndAIPlay3X3(ticTacToeBox : list<string>)
                       (playerGlyph : string)
                       (aIGlyph : string)
                       (game : gameSetting)  =
    
    let game = craftGameSetting (ticTacToeBox |> List.toArray) 
                                (playerGlyph) (aIGlyph) 
                                (int playerVals.Human)(false)(false)(false)
    
    if checkForWinnerOrTie(game.ticTacToeBox)(playerGlyph)(aIGlyph)  = int GenResult.NoWinner then
        aIMove(game)
        if checkForWinnerOrTie(game.ticTacToeBox)(playerGlyph)(aIGlyph)  = int GenResult.NoWinner then
            for i = 0 to game.ticTacToeBox.Length - 1 do
                if not(game.ticTacToeBox.[i] = playerGlyph || game.ticTacToeBox.[i] = aIGlyph) then 
                    humanAndAIPlay3X3((getEditedTicTacToeBox(game.ticTacToeBox |> Array.toList)(i)(playerGlyph)))
                                     (playerGlyph)(aIGlyph)(game)
        else
            Assert.NotEqual(checkForWinnerOrTie(game.ticTacToeBox)
                                               (playerGlyph)
                                               (aIGlyph), int Result3X3.HumanWins)
    else
        Assert.NotEqual(checkForWinnerOrTie(game.ticTacToeBox)
                                           (playerGlyph)
                                           (aIGlyph), int Result3X3.HumanWins)

[<Fact>]
let Evey_Possabile_Combination_Game_3X3_Huamn_First() =
    let gameTestCreate = craftGameSetting ([|"-1-"; "-2-"; "-3-"; 
                                             "-4-"; "-5-"; "-6-"; 
                                             "-7-"; "-8-"; "-9-"|]) 
                                          ("X") ("@") 
                                          (int playerVals.Human)(false)(false)(false)
    let ticTacToeBox = gameTestCreate.ticTacToeBox |> Array.toList
    for i = 0 to ticTacToeBox.Length - 1 do
        if not(ticTacToeBox.[i] = gameTestCreate.playerGlyph || ticTacToeBox.[i] = gameTestCreate.aIGlyph) then
            humanAndAIPlay3X3(getEditedTicTacToeBox(ticTacToeBox)(i)(gameTestCreate.playerGlyph))
                             (gameTestCreate.playerGlyph)(gameTestCreate.aIGlyph)(gameTestCreate)

[<Fact>]
let Evey_Possabile_Combination_Game_3X3_AI_First() =
    let gameTestCreate = craftGameSetting ([|"-1-"; "-2-"; "-3-"; 
                                             "-4-"; "-5-"; "-6-"; 
                                             "-7-"; "-8-"; "-9-"|]) 
                                          ("X") ("@") 
                                          (int playerVals.Human)(false)(false)(false)
    aIMove(gameTestCreate)
    let ticTacToeBox = gameTestCreate.ticTacToeBox |> Array.toList
    for i = 0 to ticTacToeBox.Length - 1 do
        if not(ticTacToeBox.[i] = gameTestCreate.playerGlyph || ticTacToeBox.[i] = gameTestCreate.aIGlyph) then
            humanAndAIPlay3X3(getEditedTicTacToeBox(ticTacToeBox)(i)(gameTestCreate.playerGlyph))
                             (gameTestCreate.playerGlyph)(gameTestCreate.aIGlyph)(gameTestCreate)


[<Fact>]
let Maxiume_Lossess() = 
    let gameTestCreate = craftGameSetting ([|"-1-"; "X"; "-3-"; 
                                             "-4-"; "-5-"; "X"; 
                                             "@"; "@"; "X"|]) 
                                          ("X") ("@") 
                                          (int playerVals.Human)(false)(false)(false)
    let ticTacToeBox = gameTestCreate.ticTacToeBox |> Array.toList
    Assert.Equal(2, computerMove ticTacToeBox gameTestCreate.playerGlyph gameTestCreate.aIGlyph)

[<Fact>]
let Maxiume_Score_Cut_Off_Not_Needed() = 
    let depth = 1
    let score = 8
    Assert.Equal(score - depth, maxiumeScoreCutOff score depth) 

[<Fact>]
let Maxiume_Score_Cut_Off_Needed() = 
    let depth = 10
    let score = -8
    Assert.Equal(int GenResult.Tie, maxiumeScoreCutOff score depth) 

[<Fact>]
let Minimize_Score_Cut_Off_Not_Needed() = 
    let depth = 1
    let score = -8
    Assert.Equal(score + depth, minimizeScoreCutOff score depth) 

[<Fact>]
let Minimize_Score_Cut_Off_Needed() = 
    let depth = 10
    let score = 8
    Assert.Equal(int GenResult.Tie, minimizeScoreCutOff score depth) 

[<Fact>]    // test
let Ai_Wins_Human_Puting_In_Order_Vals() =
    let gameTestCreate = craftGameSetting ([|"-1-"; "-2-"; "-3-"; 
                                             "-4-"; "-5-"; "-6-"; 
                                             "-7-"; "-8-"; "-9-"|]) 
                                          ("X") ("@") 
                                          (int playerVals.Human)(false)(false)(false)
    let io = new InputOutTestGame([|1; 2; 3; 
                                4; 5; 6; 
                                7; 8; 9|])
    while(checkForWinnerOrTie(gameTestCreate.ticTacToeBox)("X")("@") =  int GenResult.NoWinner) do
        let takePos = int (io.getUserInput())
        if not (gameTestCreate.ticTacToeBox.[takePos-1] = "X" || gameTestCreate.ticTacToeBox.[takePos-1] = "@") then
            gameTestCreate.ticTacToeBox.[takePos-1] <- "X"
            if checkForWinnerOrTie(gameTestCreate.ticTacToeBox)("X")("@") =  int GenResult.NoWinner then
                aIMove(gameTestCreate)

    let winningVaue = checkForWinnerOrTie(gameTestCreate.ticTacToeBox)("X")("@")
    Assert.Equal(getWinningAIValue(gameTestCreate.ticTacToeBox)
                    , winningVaue)

[<Fact>]
let Mini_Max_Minimize_Win() = 
    let gameTestCreate = craftGameSetting ([|"@"; "@"; "-3-"; "-4-"; "-5-"; "-6-"; "X"; "X"; "-9-"|]) 
                                          ("X") ("@") (int playerVals.Human)(false)(false)(false)
    let ticTacToeBox = gameTestCreate.ticTacToeBox |> Array.toList
    Assert.Equal(int Result3X3.HumanWins + 1, miniMaxMinimize 
                                            ticTacToeBox
                                            gameTestCreate.playerGlyph
                                            gameTestCreate.aIGlyph
                                            0)

    let gameTestCreate = craftGameSetting ([|"X"; "X"; "-3-"; "@"; "@"; "-6-"; "X"; "X"; "-9-"|]) 
                                          ("X") ("@") (int playerVals.Human)(false)(false)(false)
    let ticTacToeBox = gameTestCreate.ticTacToeBox |> Array.toList
    Assert.Equal(int Result3X3.HumanWins + 1, miniMaxMinimize 
                                            ticTacToeBox
                                            gameTestCreate.playerGlyph
                                            gameTestCreate.aIGlyph
                                            0)

[<Fact>]
let Mini_Max_Maxium_Win() = 
    let gameTestCreate = craftGameSetting ([|"X"; "X"; "-3-"; "-4-"; "-5-"; "-6-"; "@"; "@"; "-9-"|]) 
                                          ("X") ("@") (int playerVals.Human)(false)(false)(false)
    let ticTacToeBox = gameTestCreate.ticTacToeBox |> Array.toList
    Assert.Equal(int Result3X3.AiWins - 1, miniMaxMaxium 
                                            ticTacToeBox
                                            gameTestCreate.playerGlyph
                                            gameTestCreate.aIGlyph
                                            0)

[<Fact>]
let Mini_Max_Maxium_Tie() = 
    let gameTestCreate = craftGameSetting ([|"-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"|]) 
                                          ("X") ("@") (int playerVals.Human)(false)(false)(false)
    let ticTacToeBox = gameTestCreate.ticTacToeBox |> Array.toList
    Assert.Equal(int GenResult.Tie, miniMaxMaxium 
                                    ticTacToeBox
                                    gameTestCreate.playerGlyph
                                    gameTestCreate.aIGlyph
                                    0)

[<Fact>]
let Mini_Max_Minimize_Tie() = 
    let gameTestCreate = craftGameSetting ([|"-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"|]) 
                                          ("X") ("@") (int playerVals.Human)(false)(false)(false)
    let ticTacToeBox = gameTestCreate.ticTacToeBox |> Array.toList
    Assert.Equal(int GenResult.Tie, miniMaxMinimize 
                                    ticTacToeBox
                                    gameTestCreate.playerGlyph
                                    gameTestCreate.aIGlyph
                                    0)

[<Fact>]
let Edit_Tic_Tac_Toe_Box() =
    let ticTacToeBox = ["-1-"; "-2-"; "-3-"; 
                        "-4-"; "-5-"; "-6-"; 
                        "-7-"; "-8-"; "-9-"]
    let ticTacToeBoxEdited = ["-1-"; "-2-"; "-3-"; 
                            "-4-"; "-5-"; "-6-"; 
                            "-7-"; "X"; "-9-"]
    Assert.Equal<string>(ticTacToeBoxEdited, getEditedTicTacToeBox ticTacToeBox 7 "X")


(*
let rec humanAndAIPlay4X4(ticTacToeBox : array<string>)
                       (playerGlyph : string)
                       (aIGlyph : string)
                       (game : gameSetting)  =
    let moves =
        makeDeepCopyOfArray(makeEmptyTicTacToeBox(ticTacToeBox.Length))(ticTacToeBox)
    let game = craftGameSetting (moves) 
                                (playerGlyph) (aIGlyph) 
                                (int playerVals.Human)(false)(false)(false)
    let mutable score = checkForWinnerOrTie(moves)(playerGlyph)(aIGlyph) 
    if score = int GenResult.NoWinner then
        aIMove(game)
        score <- checkForWinnerOrTie(moves)(playerGlyph)(aIGlyph) 
        if score = int GenResult.NoWinner then
            for i = 0 to moves.Length - 1 do
            if (insertPlayerGlyph(moves)(i)("X")("@")) then
                humanAndAIPlay4X4(moves)("X")("@")(game) |> ignore
                moves.[i] <- "-"+string (int i + int 1)+"-"
        else
            Assert.NotEqual(score, int Result4X4.HumanWins)
    else
        Assert.NotEqual(score, int Result4X4.HumanWins)

[<Fact>]
let Evey_Possabile_Combination_Game_4X4_AI_First() =
    let gameTestCreate = craftGameSetting ([|"-1-"; "-2-"; "-3-"; "-4-"; 
                                            "-5-"; "-6-"; "-7-"; "-8-"; 
                                            "-9-"; "-10-"; "-11-"; "-12-";
                                            "-13-"; "-14-"; "-15-"; "-16-"|]) 
                                          ("X") ("@") 
                                          (int playerVals.Human)(false)(false)(false)
    aIMove(gameTestCreate)
    let moves =
        makeDeepCopyOfArray(makeEmptyTicTacToeBox(gameTestCreate.ticTacToeBox.Length))(gameTestCreate.ticTacToeBox)
    for i = 0 to moves.Length - 1 do
        if (insertPlayerGlyph(moves)(i)("X")("@")) then
            humanAndAIPlay4X4(moves)("X")("@")(gameTestCreate)|> ignore
            moves.[i] <- "-"+string (int i + int 1)+"-"
*)