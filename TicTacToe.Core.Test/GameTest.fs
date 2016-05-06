module GameTest
open Xunit 
open FsUnit
open Game
open GameSettings
open PlayerValues
open CheckForWinnerOrTie
open GameStatusCodes
open GameSettings
open InputOutPutTestGame


[<Fact>]
let Flip_Board() =
    let ticTacToeBox = [|"X"; "-2-"; "@"; 
                         "-4-"; "X"; "-6-"; 
                         "@"; "-6-"; "-9-"|]
    
    let ticTacToeBoxFliped = [|"@"; "-2-"; "X"; 
                             "-4-"; "@"; "-6-"; 
                             "X"; "-6-"; "-9-"|]
    
    flipBoard(ticTacToeBox)("X")("@")
    Assert.Equal<string>(ticTacToeBoxFliped, ticTacToeBox)
(*
[<Fact>]
let Ai_Vs_AI() =
    let gameTestCreate = craftGameSetting ([|"-1-"; "-2-"; "-3-"; 
                                            "-4-"; "-5-"; "-6-"; 
                                            "-7-"; "-6-"; "-9-"|]) 
                                          ("X") ("@") 
                                          (int playerVals.Human)(false)(false)(true)
    let io = new InputOutTestGame([|1; 9; 2; 
                                    8; 3; 7; 
                                    5; 6; 4|])
    Assert.Equal(int GenResult.Tie
                    , startGame gameTestCreate io)
*)
[<Fact>]
let Human_Vs_Human_PlayerOneFirst() =
    let io = new InputOutTestGame([|1; 9; 2; 
                                    8; 3; 7; 
                                    5; 6; 4|])

    let gameTestCreate = craftGameSetting ([|"-1-"; "-2-"; "-3-"; 
                                             "-4-"; "-5-"; "-6-"; 
                                             "-7-"; "-6-"; "-9-"|]) 
                                          ("X") ("@") 
                                          (int playerVals.Human)(false)(true)(false)
    
    Assert.Equal(getWinningHumanValue(gameTestCreate.ticTacToeBox)
                    , startGame gameTestCreate io)

[<Fact>]
let Human_Vs_Human_PlayerTwoFirst() =
    let io = new InputOutTestGame([|1; 9; 2; 
                                    8; 3; 7; 
                                    5; 6; 4|])

    let gameTestCreate = craftGameSetting ([|"-1-"; "-2-"; "-3-"; 
                                             "-4-"; "-5-"; "-6-"; 
                                             "-7-"; "-6-"; "-9-"|]) 
                                          ("X") ("@") 
                                          (int playerVals.AI)(false)(true)(false)
    
    Assert.Equal(getWinningAIValue(gameTestCreate.ticTacToeBox)
                    , startGame gameTestCreate io)

[<Fact>]    // test
let Human_Won_The_Game() =
    
    let gameTestCreate = craftGameSetting ([|"-1-"; "X"; "-3-"; 
                                             "-4-"; "X"; "-6-"; 
                                             "-7-"; "X"; "-9-"|]) 
                                          ("X") ("@") 
                                          (int playerVals.AI)(false)(false)(false)

    Assert.Equal("Player Won"
                    , gameEndingMessage 
                    gameTestCreate.ticTacToeBox 
                    gameTestCreate.playerGlyph 
                    gameTestCreate.aIGlyph)

[<Fact>]    // test
let AI_Won_The_Game() =
    let gameTestCreate = craftGameSetting ([|"@"; "-2-"; "-3-"; 
                                             "-4-"; "@"; "-6-"; 
                                             "-7-"; "-8-"; "@"|]) 
                                          ("X") ("@") 
                                          (int playerVals.AI)(false)(false)(false)

    Assert.Equal("Other Player Won"
                    , gameEndingMessage 
                      gameTestCreate.ticTacToeBox 
                      gameTestCreate.playerGlyph 
                      gameTestCreate.aIGlyph)

[<Fact>]    // test
let Tie_Game() =
    let gameTestCreate = craftGameSetting ([|"-1-"; "-2-"; "-3-"; 
                                             "-4-"; "-5-"; "-6-"; 
                                             "-7-"; "-8-"; "-9-"|]) 
                                          ("X") ("@") 
                                          (int playerVals.AI)(false)(false)(false)

    Assert.Equal("Tie"
                    , gameEndingMessage 
                    gameTestCreate.ticTacToeBox 
                    gameTestCreate.playerGlyph 
                    gameTestCreate.aIGlyph)

[<Fact>]
let Game_Starts_Sucessfuly_Human_Vs_AI_First() =
    let gameTestCreate = craftGameSetting ([|"-1-"; "-2-"; "-3-"; 
                                             "-4-"; "-5-"; "-6-"; 
                                             "-7-"; "-8-"; "-9-"|]) 
                                          ("X") ("@") 
                                          (int playerVals.AI)(false)(false)(false)
    let io = new InputOutTestGame([|1; 99; 7; 
                                9; 8; 6; 
                                5; 4; 3|])

    Assert.Equal(getWinningAIValue(gameTestCreate.ticTacToeBox)
                    , startGame gameTestCreate io)

[<Fact>]
let Game_Starts_Sucessfuly_Human_First_Vs_AI() =
    let gameTestCreate = craftGameSetting ([|"-1-"; "-2-"; "-3-"; 
                                             "-4-"; "-5-"; "-6-"; 
                                             "-7-"; "-8-"; "-9-"|]) 
                                          ("X") ("@") 
                                          (int playerVals.Human)(false)(false)(false)
    let io = new InputOutTestGame([|1; 99; 7; 
                                9; 8; 6; 
                                5; 4; 3|])

    Assert.Equal(getWinningAIValue(gameTestCreate.ticTacToeBox)
                    , startGame gameTestCreate io)

[<Fact>]    // test
let game_Human_Vs_Ai_First_Ai_Doesnt_Stall() =
    let gameTestCreate = craftGameSetting ([|"-1-"; "-2-"; "-3-"; 
                                             "-4-"; "-5-"; "-6-"; 
                                             "-7-"; "-8-"; "-9-"|]) 
                                          ("X") ("@") 
                                          (int playerVals.Human)(false)(false)(false)
    let io = new InputOutTestGame([|1; 99; 7; 
                                9; 8; 6; 
                                5; 4; 3|])

    Assert.Equal(getWinningAIValue(gameTestCreate.ticTacToeBox)
                    , humanVsAiFirstGame gameTestCreate io)

[<Fact>]    // test
let game_Human_Vs_Ai_Ai_First() =
    let gameTestCreate = craftGameSetting ([|"-1-"; "-2-"; "-3-"; 
                                             "-4-"; "-5-"; "-6-"; 
                                             "-7-"; "-8-"; "-9-"|]) 
                                          ("X") ("@") 
                                          (int playerVals.Human)(false)(false)(false)
    let io = new InputOutTestGame([|1; 2; 3; 
                                4; 5; 6; 
                                7; 8; 9|])

    Assert.Equal(getWinningAIValue(gameTestCreate.ticTacToeBox)
                    , humanVsAiFirstGame gameTestCreate io)

[<Fact>]    // test
let game_Human_First_Vs_Ai_Ai_Doesnt_Stall() =
    let gameTestCreate = craftGameSetting ([|"-1-"; "-2-"; "-3-"; 
                                             "-4-"; "-5-"; "-6-"; 
                                             "-7-"; "-8-"; "-9-"|]) 
                                          ("X") ("@") 
                                          (int playerVals.Human)(false)(false)(false)
    let io = new InputOutTestGame([|1; 99; 7; 
                                9; 8; 6; 
                                5; 4; 3|])

    Assert.Equal(getWinningAIValue(gameTestCreate.ticTacToeBox)
                    , humanFirstVsAiGame gameTestCreate io)

[<Fact>]    // test
let game_First_Human_Vs_Ai() =
    let gameTestCreate = craftGameSetting ([|"-1-"; "-2-"; "-3-"; 
                                             "-4-"; "-5-"; "-6-"; 
                                             "-7-"; "-8-"; "-9-"|]) 
                                          ("X") ("@") 
                                          (int playerVals.Human)(false)(false)(false)
    let io = new InputOutTestGame([|1; 2; 3; 
                                4; 5; 6; 
                                7; 8; 9|])

    Assert.Equal(getWinningAIValue(gameTestCreate.ticTacToeBox)
                    , humanFirstVsAiGame gameTestCreate io)

[<Fact>]    // test
let Game_Is_Over_AI_Won() =
    let gameTestCreate = craftGameSetting ([|"@"; "@"; "@"; 
                                             "-4-"; "X"; "-6-"; 
                                             "X"; "-8-"; "X"|]) 
                                          ("X") ("@") 
                                          (int playerVals.Human)(false)(false)(false)
    Assert.Equal(true, isGameOver gameTestCreate)

[<Fact>]    // test
let Game_Is_Over_Human_Won() =
    let gameTestCreate = craftGameSetting ([|"X"; "X"; "X"; 
                                             "@"; "X"; "-6-"; 
                                             "@"; "-8-"; "@"|]) 
                                          ("X") ("@") 
                                          (int playerVals.Human)(false)(false)(false)
    Assert.Equal(true, isGameOver  gameTestCreate)

[<Fact>]    // test
let Game_Is_Over_Tie() =
    let gameTestCreate = craftGameSetting ([|"X"; "@"; "X"; 
                                             "@"; "X"; "@"; 
                                             "@"; "X"; "@"|]) 
                                          ("X") ("@") (int playerVals.Human)(false)(false)(false)
    Assert.Equal(true, isGameOver gameTestCreate)

[<Fact>]    // test
let Game_Is_Not_Over =
    let gameTestCreate = craftGameSetting ([|"-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"|]) 
                                          ("X") ("@") (int playerVals.Human)(false)(false)(false)
    
    Assert.Equal(false, isGameOver gameTestCreate)

[<Fact>]
let AI_Edit_TicTacToeBox() =
    let gameTestCreate = craftGameSetting ([|"X"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"|]) 
                                          ("X") ("@") (int playerVals.Human)(false)(false)(false)

    Assert.Equal(true, aIInputEditTicTacToeBox gameTestCreate)


[<Fact>]
let User_Input_Edit_Not_Spot_Taken_TicTacToeBox() =
    let gameTestCreate = craftGameSetting ([|"X"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"|]) 
                                          ("X") ("@") (int playerVals.Human)(false)(false)(false)

    Assert.Equal("Spot Taken", userInputEditTicTacToeBox gameTestCreate "1")

[<Fact>]
let User_Input_Edit_Not_A_Number_TicTacToeBox() =
    let gameTestCreate = craftGameSetting ([|"-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"|]) 
                                          ("X") ("@") (int playerVals.Human)(false)(false)(false)

    Assert.Equal("Value not a number", userInputEditTicTacToeBox gameTestCreate "werwer")

[<Fact>]
let User_Input_Edit__Out_Of_Bounds_To_Big_TicTacToeBox() =
    let gameTestCreate = craftGameSetting ([|"-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"|]) 
                                          ("X") ("@") (int playerVals.Human)(false)(false)(false)

    Assert.Equal("Value out of bounds", userInputEditTicTacToeBox gameTestCreate "99")

[<Fact>]
let User_Input_Edit__Out_Of_Bounds__To_Small_TicTacToeBox() =
    let gameTestCreate = craftGameSetting ([|"-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"|]) 
                                          ("X") ("@") (int playerVals.Human)(false)(false)(false)

    Assert.Equal("Value out of bounds", userInputEditTicTacToeBox gameTestCreate "0")

[<Fact>]
let User_Input_Edit_TicTacToeBox() =
    let gameTestCreate = craftGameSetting ([|"-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"|]) 
                                          ("X") ("@") (int playerVals.Human)(false)(false)(false)

    let ticTacToeBoxEdit = [|"X"; "-2-"; "-3-"; 
                             "-4-"; "-5-"; "-6-"; 
                             "-7-"; "-8-"; "-9-"|]

    Assert.Equal("", userInputEditTicTacToeBox gameTestCreate "1")
    Assert.Equal<string>(ticTacToeBoxEdit, gameTestCreate.ticTacToeBox)

[<Fact>]
let Convert_User_Input_To_Int() =
    Assert.Equal(1, convertStringToInt "1")

[<Fact>]
let User_Input_Is_A_Word() =
    Assert.Equal(false, isInputANumber "opw")

[<Fact>]
let User_Input_Is_A_Number() =
    Assert.Equal(true, isInputANumber "1")

[<Fact>]
let User_Pick_Out_Bound_Upper_Spot() =
    Assert.Equal(true, isOutBounds 9 10)

[<Fact>]
let User_Pick_In_Bound_Correct_Spot() =
    Assert.Equal(false, isOutBounds 9 0)

[<Fact>]
let User_Pick_Out_Bound_Lower_Spot() =
    Assert.Equal(true, isOutBounds 9 -1)

[<Fact>]
let User_Pick_In_Bound_Spot() =
    Assert.Equal(false, isOutBounds 9 1)

[<Fact>]
let User_Pick_Non_Taken_Spot() =
    let ticTacToeBox = [|"-1-"; "-2-"; "-3-"; 
                         "-4-"; "-5-"; "-6-"; 
                         "-7-"; "-8-"; "-9-"|]
    Assert.Equal(false, isSpotTaken ticTacToeBox 1 "X" "@")

[<Fact>]
let User_Pick_Taken_Spot() =
    let ticTacToeBox = [|"X"; "-2-"; "-3-"; 
                         "-4-"; "-5-"; "-6-"; 
                         "-7-"; "-8-"; "-9-"|]
    Assert.Equal(true, isSpotTaken ticTacToeBox 0 "X" "@")

[<Fact>]
let User_Pick_Pos_Correct() =
    let ticTacToeBox = [|"-1-"; "-2-"; "-3-"; 
                         "-4-"; "-5-"; "-6-"; 
                         "-7-"; "-8-"; "-9-"|]
    Assert.Equal("", isUserInputCorrect ticTacToeBox "1" "X" "@")

[<Fact>]
let User_Pick_Pos_Spot_Taken() =
    let message = ref ""
    let ticTacToeBox = [|"X"; "-2-"; "-3-"; 
                         "-4-"; "-5-"; "-6-"; 
                         "-7-"; "-8-"; "-9-"|]
    Assert.Equal("Spot Taken", isUserInputCorrect ticTacToeBox "1" "X" "@")

[<Fact>]
let User_Pick_Pos_is_Not_A_Input_Number() =
    let ticTacToeBox = [|"X"; "-2-"; "-3-"; 
                         "-4-"; "-5-"; "-6-"; 
                         "-7-"; "-8-"; "-9-"|]
    Assert.Equal("Value not a number", isUserInputCorrect ticTacToeBox "addas" "X" "@")

[<Fact>]
let User_Pick_Pos_OutOfBounds() =
    let ticTacToeBox = [|"X"; "-2-"; "-3-"; 
                         "-4-"; "-5-"; "-6-"; 
                         "-7-"; "-8-"; "-9-"|]
    Assert.Equal("Value out of bounds", isUserInputCorrect ticTacToeBox "20" "X" "@")

(*
let gameTestCreate = craftGameSetting ([|"-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"|]) 
                                          ("X") ("@") (int playerVals.Human)(false)(false)

[<Fact>]    // test
let Game_Is_Over_AI_Won() =
    let ticTacToeBox = [|"@"; "@"; "@"; 
                         "-4-"; "X"; "-6-"; 
                         "X"; "-8-"; "X"|]
    Assert.Equal(true, isGameOver ticTacToeBox gameTestCreate)

[<Fact>]    // test
let Game_Is_Over_Human_Won() =
    let ticTacToeBox = [|"X"; "X"; "X"; 
                         "@"; "X"; "-6-"; 
                         "@"; "-8-"; "@"|]
    Assert.Equal(true, isGameOver ticTacToeBox gameTestCreate)

[<Fact>]    // test
let Game_Is_Over_Tie() =
    let ticTacToeBox = [|"X"; "@"; "X"; 
                         "@"; "X"; "@"; 
                         "@"; "X"; "@"|]
    Assert.Equal(true, isGameOver ticTacToeBox gameTestCreate)

[<Fact>]    // test
let Game_Is_Not_Over =
    let ticTacToeBox = [|"-1-"; "-2-"; "-3-"; 
                         "-4-"; "-5-"; "-6-"; 
                         "-7-"; "-8-"; "-9-"|]
    Assert.Equal(false, isGameOver ticTacToeBox gameTestCreate)

[<Fact>]    // test
let Human_Won_The_Game =
    let ticTacToeBox = [|"X"; "X"; "X"; 
                         "@"; "X"; "-6-"; 
                         "@"; "-8-"; "@"|]
    Assert.Equal("Human Won", gameEndingMessage ticTacToeBox gameTestCreate)

[<Fact>]    // test
let AI_Won_The_Game =
    let ticTacToeBox = [|"@"; "@"; "@"; 
                         "-4-"; "X"; "-6-"; 
                         "X"; "-8-"; "X"|]
    Assert.Equal("AI Won", gameEndingMessage ticTacToeBox gameTestCreate)

[<Fact>]    // test
let Tie_Game =
    let ticTacToeBox = [|"X"; "@"; "X"; 
                         "@"; "X"; "@"; 
                         "@"; "X"; "@"|]
    Assert.Equal("Tie", gameEndingMessage ticTacToeBox gameTestCreate)

[<Fact>]   // test
let Game_Still_In_Session_Exception() =
    let ticTacToeBox = [|"-1-"; "-2-"; "-3-"; 
                         "-4-"; "-5-"; "-6-"; 
                         "-7-"; "-8-"; "-9-"|]
    (fun () -> gameEndingMessage ticTacToeBox gameTestCreate |> ignore) |> should throw typeof<GameStillInSession>

*)