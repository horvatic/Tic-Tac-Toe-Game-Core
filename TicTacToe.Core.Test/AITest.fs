module AITest
open Xunit 
open FsUnit
open TicTacToe.Core 
open AI
open ITicTacToeBoxClass
open CheckForWinnerOrTie
open PlayerValues
open GameStatusCodes
open System.Collections.Generic
open GameSettings
open InputOutPutTestGame
open TicTacToeBoxClass


let rec humanAndAIPlay3X3(board : ITicTacToeBox)
                       (playerGlyph : string)
                       (aIGlyph : string)
                       (game : gameSetting)  =
    
    let game = craftGameSetting (3)(playerGlyph) (aIGlyph) 
                                (int playerVals.Human)(false)(false)(false)
    
    if checkForWinnerOrTie(board)(playerGlyph)(aIGlyph)  = int GenResult.NoWinner then
        let aiTicTacToeMove = aIMove(game)(board)
        if checkForWinnerOrTie(aiTicTacToeMove)(playerGlyph)(aIGlyph)  = int GenResult.NoWinner then
            for i = 0 to aiTicTacToeMove.cellCount() - 1 do
                if not(aiTicTacToeMove.getGlyphAtLocation(i) = playerGlyph 
                    || aiTicTacToeMove.getGlyphAtLocation(i) = aIGlyph) then 
                    let moveTicTacToeBoard = aiTicTacToeMove.getTicTacToeBoxEdited(i)(playerGlyph)(playerGlyph)(aIGlyph)
                    humanAndAIPlay3X3(moveTicTacToeBoard)(playerGlyph)(aIGlyph)(game)
        else
            Assert.NotEqual(checkForWinnerOrTie(aiTicTacToeMove)
                                               (playerGlyph)
                                               (aIGlyph), int Result3X3.HumanWins)
    else
        Assert.NotEqual(checkForWinnerOrTie(board)
                                           (playerGlyph)
                                           (aIGlyph), int Result3X3.HumanWins)

[<Fact>]
let Evey_Possabile_Combination_Game_3X3_Huamn_First() =
    let gameTestCreate = craftGameSetting (3)("X") ("@") 
                                          (int playerVals.Human)(false)(false)(false)
    
    let board = new TicTacToeBox(["-1-"; "-2-"; "-3-"; 
                                "-4-"; "-5-"; "-6-"; 
                                "-7-"; "-8-"; "-9-"])
    for i = 0 to board.cellCount() - 1 do
        if not(board.getGlyphAtLocation(i) = gameTestCreate.playerGlyph 
            || board.getGlyphAtLocation(i) = gameTestCreate.aIGlyph) then
            humanAndAIPlay3X3(board.getTicTacToeBoxEdited(i)(gameTestCreate.playerGlyph)(gameTestCreate.playerGlyph)(gameTestCreate.aIGlyph))
                             (gameTestCreate.playerGlyph)(gameTestCreate.aIGlyph)(gameTestCreate)

[<Fact>]
let Evey_Possabile_Combination_Game_3X3_AI_First() =
    let gameTestCreate = craftGameSetting (3)("X") ("@") 
                                          (int playerVals.Human)(false)(false)(false)
    let aiTicTacToeMove = aIMove(gameTestCreate)(new TicTacToeBox (["-1-"; "-2-"; "-3-"; 
                                                                     "-4-"; "-5-"; "-6-"; 
                                                                     "-7-"; "-8-"; "-9-"]))
    for i = 0 to aiTicTacToeMove.cellCount() - 1 do
        if not(aiTicTacToeMove.getGlyphAtLocation(i) = gameTestCreate.playerGlyph 
            || aiTicTacToeMove.getGlyphAtLocation(i) = gameTestCreate.aIGlyph) then
            humanAndAIPlay3X3(aiTicTacToeMove.getTicTacToeBoxEdited(i)(gameTestCreate.playerGlyph)(gameTestCreate.playerGlyph)(gameTestCreate.aIGlyph))
                             (gameTestCreate.playerGlyph)(gameTestCreate.aIGlyph)(gameTestCreate)

[<Fact>]
let Maxiume_Lossess() = 
    let gameTestCreate = craftGameSetting (3)("X") ("@") 
                                          (int playerVals.Human)(false)(false)(false)
    let board = new TicTacToeBox(["-1-"; "X"; "-3-"; 
                                "-4-"; "-5-"; "X"; 
                                "@"; "@"; "X"])
    Assert.Equal(2, computerMove board gameTestCreate.playerGlyph gameTestCreate.aIGlyph)

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


[<Fact>]
let Mini_Max_Minimize_Win() = 
    let gameTestCreate = craftGameSetting (3)("X") ("@") (int playerVals.Human)(false)(false)(false)
    
    let board = new TicTacToeBox(["@"; "@"; "-3-"; "-4-"; "-5-"; "-6-"; "X"; "X"; "-9-"])
    Assert.Equal(int Result3X3.HumanWins + 1, miniMaxMinimize 
                                            board
                                            gameTestCreate.playerGlyph
                                            gameTestCreate.aIGlyph
                                            0)

    let gameTestCreate = craftGameSetting (3)("X") ("@") (int playerVals.Human)(false)(false)(false)
    let board = new TicTacToeBox(["X"; "X"; "-3-"; "@"; "@"; "-6-"; "X"; "X"; "-9-"])
    Assert.Equal(int Result3X3.HumanWins + 1, miniMaxMinimize 
                                            board
                                            gameTestCreate.playerGlyph
                                            gameTestCreate.aIGlyph
                                            0)

[<Fact>]
let Mini_Max_Maxium_Win() = 
    let gameTestCreate = craftGameSetting (3)("X") ("@") (int playerVals.Human)(false)(false)(false)
    let board = new TicTacToeBox(["X"; "X"; "-3-"; "-4-"; "-5-"; "-6-"; "@"; "@"; "-9-"])
    Assert.Equal(int Result3X3.AiWins - 1, miniMaxMaxium 
                                            board
                                            gameTestCreate.playerGlyph
                                            gameTestCreate.aIGlyph
                                            0)

[<Fact>]
let Mini_Max_Maxium_Tie() = 
    let gameTestCreate = craftGameSetting (3)("X") ("@") (int playerVals.Human)(false)(false)(false)
    let board = new TicTacToeBox(["-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"])
    Assert.Equal(int GenResult.Tie, miniMaxMaxium 
                                    board
                                    gameTestCreate.playerGlyph
                                    gameTestCreate.aIGlyph
                                    0)

[<Fact>]
let Mini_Max_Minimize_Tie() = 
    let gameTestCreate = craftGameSetting (3)("X") ("@") (int playerVals.Human)(false)(false)(false)
    let board = new TicTacToeBox(["-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"])
    Assert.Equal(int GenResult.Tie, miniMaxMinimize 
                                    board
                                    gameTestCreate.playerGlyph
                                    gameTestCreate.aIGlyph
                                    0)