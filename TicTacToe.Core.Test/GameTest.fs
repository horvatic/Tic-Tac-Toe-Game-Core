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
open TicTacToeBoxClass
open System.Collections.Generic
open Translate

[<Fact>]
let Ai_Vs_Ai_Ai_Player_Two_First() =
    let gameTestCreate = craftGameSetting (3)("X") ("@") 
                                          (int playerVals.Human)(false)(true)(false)
    let aIPlayerTwoGame = craftGameSetting(gameTestCreate.ticTacToeBoxSize)(gameTestCreate.aIGlyph)
                                          (gameTestCreate.playerGlyph)(gameTestCreate.firstPlayer)
                                          (gameTestCreate.inverted)(false)(true)
    let board = new TicTacToeBox(["-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9"])
    let io = new InputOutTestGame(new Queue<int>([1; 99; 7; 
                                                    9; 8; 6; 
                                                    5; 4; 3]))
    
    Assert.Equal(int GenResult.Tie, aIPlayerTwoTurn gameTestCreate aIPlayerTwoGame board io)

[<Fact>]
let Make_4X4_Tic_Tac_Toe_Box() =
    let box = ["-1-"; "-2-"; "-3-"; "-4-"; 
                "-5-"; "-6-"; "-7-"; "-8-"; 
                "-9-"; "-10-"; "-11-"; "-12-";
                "-13-"; "-14-"; "-15-"; "-16-"]
    Assert.Equal<string>(box, makeTicTacToeBox 4)

[<Fact>]
let Make_3X3_Tic_Tac_Toe_Box() =
    let box = ["-1-"; "-2-"; "-3-"; 
            "-4-"; "-5-"; "-6-"; 
            "-7-"; "-8-"; "-9-"]
    Assert.Equal<string>(box, makeTicTacToeBox 3)

[<Fact>]
let User_Input_Edit_Not_Spot_Taken_TicTacToeBox() =
    let gameTestCreate = craftGameSetting (3)("X") ("@") (int playerVals.Human)(false)(false)(false)
    let board = new TicTacToeBox(["-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9"])
    Assert.Equal(Blank, userInputOkToEditTicTacToeBox gameTestCreate board "1")

[<Fact>]
let User_Input_Edit_Not_A_Number_TicTacToeBox() =
    let gameTestCreate = craftGameSetting (3)("X") ("@") (int playerVals.Human)(false)(false)(false)
    let board = new TicTacToeBox(["-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9"])
    Assert.Equal(Value_Not_A_Number, userInputOkToEditTicTacToeBox gameTestCreate board "werwer")

[<Fact>]
let User_Input_Edit__Out_Of_Bounds_To_Big_TicTacToeBox() =
    let gameTestCreate = craftGameSetting (3)("X") ("@") (int playerVals.Human)(false)(false)(false)
    let board = new TicTacToeBox(["-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9"])
    Assert.Equal(Value_Out_Of_Bounds, userInputOkToEditTicTacToeBox gameTestCreate board "99")

[<Fact>]
let User_Input_Edit__Out_Of_Bounds__To_Small_TicTacToeBox() =
    let gameTestCreate = craftGameSetting (3)("X") ("@") (int playerVals.Human)(false)(false)(false)
    let board = new TicTacToeBox(["-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9"])
    Assert.Equal(Value_Out_Of_Bounds, userInputOkToEditTicTacToeBox gameTestCreate board "0")

[<Fact>]
let User_Input_Edit_TicTacToeBox() =
    let gameTestCreate = craftGameSetting (3)("X") ("@") (int playerVals.Human)(false)(false)(false)

    let board = new TicTacToeBox(["-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9"])

    Assert.Equal(Blank, userInputOkToEditTicTacToeBox gameTestCreate board "1")


[<Fact>]
let Other_User_Input_Edit_Not_Spot_Taken_TicTacToeBox() =
    let gameTestCreate = craftGameSetting (3)("X") ("@") (int playerVals.Human)(false)(false)(false)
    let board = new TicTacToeBox(["-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9"])
    Assert.Equal(Blank, otherUserInputOkToEditTicTacToeBox gameTestCreate board "1")

[<Fact>]
let Other_User_Input_Edit_Not_A_Number_TicTacToeBox() =
    let gameTestCreate = craftGameSetting (3)("X") ("@") (int playerVals.Human)(false)(false)(false)
    let board = new TicTacToeBox(["-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9"])
    Assert.Equal(Value_Not_A_Number, otherUserInputOkToEditTicTacToeBox gameTestCreate board "werwer")

[<Fact>]
let Other_User_Input_Edit__Out_Of_Bounds_To_Big_TicTacToeBox() =
    let gameTestCreate = craftGameSetting (3)("X") ("@") (int playerVals.Human)(false)(false)(false)
    let board = new TicTacToeBox(["-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9"])
    Assert.Equal(Value_Out_Of_Bounds, otherUserInputOkToEditTicTacToeBox gameTestCreate board "99")

[<Fact>]
let Other_User_Input_Edit__Out_Of_Bounds__To_Small_TicTacToeBox() =
    let gameTestCreate = craftGameSetting (3)("X") ("@") (int playerVals.Human)(false)(false)(false)
    let board = new TicTacToeBox(["-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9"])
    Assert.Equal(Value_Out_Of_Bounds, otherUserInputOkToEditTicTacToeBox gameTestCreate board "0")

[<Fact>]
let Other_User_Input_Edit_TicTacToeBox() =
    let gameTestCreate = craftGameSetting (3)("X") ("@") (int playerVals.Human)(false)(false)(false)

    let board = new TicTacToeBox(["-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9"])

    Assert.Equal(Blank, otherUserInputOkToEditTicTacToeBox gameTestCreate board "1")

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
    let board = new TicTacToeBox(["-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9"])
    Assert.Equal(false, isSpotTaken board 1 "X" "@")

[<Fact>]
let User_Pick_Taken_Spot() =
    let board = new TicTacToeBox(["X"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9"])
    Assert.Equal(true, isSpotTaken board 0 "X" "@")

[<Fact>]
let User_Pick_Pos_Correct() =
    let board = new TicTacToeBox(["-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9"])
    Assert.Equal(Blank, isUserInputCorrect board "1" "X" "@")

[<Fact>]
let User_Pick_Pos_Spot_Taken() =
    let board = new TicTacToeBox(["X"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9"])
    Assert.Equal(Spot_Taken, isUserInputCorrect board "1" "X" "@")

[<Fact>]
let User_Pick_Pos_is_Not_A_Input_Number() =
    let board = new TicTacToeBox(["-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9"])
    Assert.Equal(Value_Not_A_Number, isUserInputCorrect board "addas" "X" "@")

[<Fact>]
let User_Pick_Pos_OutOfBounds() =
    let board = new TicTacToeBox(["-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9"])
    Assert.Equal(Value_Out_Of_Bounds, isUserInputCorrect board "20" "X" "@")

[<Fact>]
let Human_Vs_Human_PlayerOneFirst() =
    let io = new InputOutTestGame(new Queue<int>([99; 1; 9; 2; 
                                                    8; 3; 7; 
                                                    5; 6; 4]))

    let gameTestCreate = craftGameSetting (3)("X") ("@") 
                                          (int playerVals.Human)(false)(true)(false)

    let ticTacToeBox = new TicTacToeBox(["-1-"; "-2-"; "-3-"; 
                                        "-4-"; "-5-"; "-6-"; 
                                        "-7-"; "-8-"; "-9"])
    let gameResult = startGame(gameTestCreate)(io)
    
    Assert.Equal(getWinningHumanValue(gameTestCreate.ticTacToeBoxSize), gameResult)

[<Fact>]
let Human_Vs_Human_PlayerTwoFirst() =
    let io = new InputOutTestGame(new Queue<int>([99; 1; 9; 2; 
                                                    8; 3; 7; 
                                                    5; 6; 4]))

    let gameTestCreate = craftGameSetting (3)("X") ("@") 
                                          (int playerVals.AI)(false)(true)(false)

    let ticTacToeBox = new TicTacToeBox(["-1-"; "-2-"; "-3-"; 
                                        "-4-"; "-5-"; "-6-"; 
                                        "-7-"; "-8-"; "-9"])
    let gameResult = startGame(gameTestCreate)(io)
    Assert.Equal(getWinningAIValue(gameTestCreate.ticTacToeBoxSize), gameResult)

[<Fact>]    // test
let game_First_Human_Vs_Ai() =
    let gameTestCreate = craftGameSetting (3)("X") ("@") 
                                          (int playerVals.Human)(false)(false)(false)
    let io = new InputOutTestGame(new Queue<int>([1; 2; 3; 
                                                    4; 5; 6; 
                                                    7; 8; 9]))
    let board = new TicTacToeBox(["-1-"; "-2-"; "-3-"; 
                                "-4-"; "-5-"; "-6-"; 
                                "-7-"; "-8-"; "-9"])
    Assert.Equal(getWinningAIValue(gameTestCreate.ticTacToeBoxSize)
                    , humanFirstVsAiGame gameTestCreate board io)


[<Fact>]    // test
let game_Human_First_Vs_Ai_Ai_Doesnt_Stall() =
    let gameTestCreate = craftGameSetting (3)("X") ("@") 
                                          (int playerVals.Human)(false)(false)(false)
    let io = new InputOutTestGame(new Queue<int>([1; 99; 7; 
                                                    9; 8; 6; 
                                                    5; 4; 3]))
    let board = new TicTacToeBox(["-1-"; "-2-"; "-3-"; 
                                "-4-"; "-5-"; "-6-"; 
                                "-7-"; "-8-"; "-9"])
    Assert.Equal(getWinningAIValue(gameTestCreate.ticTacToeBoxSize)
                    , humanFirstVsAiGame gameTestCreate board io)

[<Fact>]    // test
let game_Human_Vs_First_Ai() =
    let gameTestCreate = craftGameSetting (3)("X") ("@") 
                                          (int playerVals.Human)(false)(false)(false)
    let io = new InputOutTestGame(new Queue<int>([1; 2; 3; 
                                                    4; 5; 6; 
                                                    7; 8; 9]))
    let board = new TicTacToeBox(["-1-"; "-2-"; "-3-"; 
                                "-4-"; "-5-"; "-6-"; 
                                "-7-"; "-8-"; "-9"])
    Assert.Equal(getWinningAIValue(gameTestCreate.ticTacToeBoxSize)
                    , humanVsAiFirstGame gameTestCreate board io)


[<Fact>]    // test
let game_Human_Vs_First_Ai_Ai_Doesnt_Stall() =
    let gameTestCreate = craftGameSetting (3)("X") ("@") 
                                          (int playerVals.Human)(false)(false)(false)
    let io = new InputOutTestGame(new Queue<int>([1; 99; 7; 
                                                    9; 8; 6; 
                                                    5; 4; 3]))
    let board = new TicTacToeBox(["-1-"; "-2-"; "-3-"; 
                                "-4-"; "-5-"; "-6-"; 
                                "-7-"; "-8-"; "-9"])
    Assert.Equal(getWinningAIValue(gameTestCreate.ticTacToeBoxSize)
                    , humanVsAiFirstGame gameTestCreate board io)

[<Fact>]    // test
let game_AI_Vs_AI() =
    let gameTestCreate = craftGameSetting (3)("X") ("@") 
                                          (int playerVals.Human)(false)(false)(false)

    let io = new InputOutTestGame(new Queue<int>([1; 99; 7; 
                                                    9; 8; 6; 
                                                    5; 4; 3]))
    let board = new TicTacToeBox(["-1-"; "-2-"; "-3-"; 
                                "-4-"; "-5-"; "-6-"; 
                                "-7-"; "-8-"; "-9"])
    Assert.Equal(int GenResult.Tie, aIvsAI gameTestCreate board io)

