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
*)
let rec humanAndAIPlay3X3(ticTacToeBox : array<string>)
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
            if (insertPlayerGlyph(moves)(i)(playerGlyph)(aIGlyph)) then
                humanAndAIPlay3X3(moves)(playerGlyph)(aIGlyph)(game) |> ignore
                moves.[i] <- "-"+string (int i + int 1)+"-"
        else
            Assert.NotEqual(score, int Result3X3.HumanWins)
    else
        Assert.NotEqual(score, int Result3X3.HumanWins)

[<Fact>]
let Evey_Possabile_Combination_Game_3X3_AI_First() =
    let gameTestCreate = craftGameSetting ([|"-1-"; "-2-"; "-3-"; 
                                             "-4-"; "-5-"; "-6-"; 
                                             "-7-"; "-8-"; "-9-"|]) 
                                          ("X") ("@") 
                                          (int playerVals.Human)(false)(false)(false)
    aIMove(gameTestCreate)
    let moves =
        makeDeepCopyOfArray(makeEmptyTicTacToeBox(gameTestCreate.ticTacToeBox.Length))(gameTestCreate.ticTacToeBox)
    for i = 0 to moves.Length - 1 do
        if (insertPlayerGlyph(moves)(i)("X")("@")) then
            humanAndAIPlay3X3(moves)("X")("@")(gameTestCreate)|> ignore
            moves.[i] <- "-"+string (int i + int 1)+"-"

(*
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
[<Fact>]
let Evey_Possabile_Combination_Game_3X3_Huamn_First() =
    let gameTestCreate = craftGameSetting ([|"-1-"; "-2-"; "-3-"; 
                                             "-4-"; "-5-"; "-6-"; 
                                             "-7-"; "-8-"; "-9-"|]) 
                                          ("X") ("@") 
                                          (int playerVals.Human)(false)(false)(false)
    let moves =
        makeDeepCopyOfArray(makeEmptyTicTacToeBox(gameTestCreate.ticTacToeBox.Length))(gameTestCreate.ticTacToeBox)
    for i = 0 to moves.Length - 1 do
        if (insertPlayerGlyph(moves)(i)("X")("@")) then
            humanAndAIPlay3X3(moves)("X")("@")(gameTestCreate)|> ignore
            moves.[i] <- "-"+string (int i + int 1)+"-"

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
let Insert__Player_Glyph_Sucessfuly() =
    let ticTacToeBox = [|"-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"|]
    Assert.Equal(true, insertPlayerGlyph ticTacToeBox 0 "X" "@")

[<Fact>] 
let Insert__Player_Glyph_unSucessfuly_With_AI() =
    let ticTacToeBox = [|"@"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"|]
    Assert.Equal(false, insertPlayerGlyph ticTacToeBox 0 "X" "@")

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
let Insert__AI_Glyph_Sucessfuly() =
    let ticTacToeBox = [|"-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"|]
    Assert.Equal(true, insertAiGlyph ticTacToeBox 0 "X" "@")

[<Fact>] 
let Insert__AI_Glyph_unSucessfuly_With_AI() =
    let ticTacToeBox = [|"@"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"|]
    Assert.Equal(false, insertAiGlyph ticTacToeBox 0 "X" "@")

[<Fact>] 
let Insert__AI_Glyph_unSucessfuly_With_Human() =
    let ticTacToeBox = [|"X"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"|]
    Assert.Equal(false, insertAiGlyph ticTacToeBox 0 "X" "@")

[<Fact>] //test
let Make_Empty_Score_Min_3X3() =
    let scores = [|-999; -999; -999; -999; -999; -999; -999; -999; -999|]
    Assert.Equal<int>(scores, makeEmptyScoreMin scores.Length )

[<Fact>] //test
let Make_Empty_Score_Min_4X4() =
    let scores = [|-999; -999; -999; -999; 
                    -999; -999; -999; -999; 
                    -999; -999; -999; -999;
                    -999; -999; -999; -999|]
    Assert.Equal<int>(scores, makeEmptyScoreMin scores.Length )

[<Fact>] //test
let Make_Empty_Score_Max_3X3() =
    let scores = [|999; 999; 999; 999; 999; 999; 999; 999; 999|]
    Assert.Equal<int>(scores, makeEmptyScoreMax scores.Length )

[<Fact>] //test
let Make_Empty_Score_Max_4X4() =
    let scores = [|999; 999; 999; 999; 
                    999; 999; 999; 999; 
                    999; 999; 999; 999;
                    999; 999; 999; 999|]
    Assert.Equal<int>(scores, makeEmptyScoreMax scores.Length )

[<Fact>]
let Make_Deep_Copy_Of_TicTacToeBox() =
    let ticTacToeBoxCopy = [|"x"; "x"; "-3-"; "@"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"|]
    let ticTacToeBox = [|"-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"|]

    Assert.Equal<string>(ticTacToeBoxCopy, makeDeepCopyOfArray ticTacToeBox ticTacToeBoxCopy)
[<Fact>] //test
let Make_Empty_Tic_Tac_Toe_Box_3X3() =
    let ticTacToeBox = [|"-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"|]
    Assert.Equal<string>(ticTacToeBox, makeEmptyTicTacToeBox ticTacToeBox.Length )

[<Fact>] //test
let Make_Empty_Tic_Tac_Toe_Box_4X4() =
    let ticTacToeBox = [|"-1-"; "-2-"; "-3-"; "-4-"; 
                        "-5-"; "-6-"; "-7-"; "-8-"; 
                        "-9-"; "-10-"; "-11-"; "-12-";
                        "-13-"; "-14-"; "-15-"; "-16-"|]
    Assert.Equal<string>(ticTacToeBox, makeEmptyTicTacToeBox ticTacToeBox.Length )


(*
[<Fact>] //test
let Find_Smallest_Value() =
    let scores = [1; -10; 10; 9; 6; -1; 2; 3; 1]
    Assert.Equal(-10, findSmallestScore scores )

[<Fact>] //test
let Find_Largest_Value() =
    let scores = [1; -10; 10; 9; 6; -1; 2; 3; 1]
    Assert.Equal(10, findLargestScore scores )

*)