module GameTest
open TicTacToe.Core 
open Xunit 
open FsUnit
open Game
open CheckForWinnerOrTie
open GameStatusCodes
open TicTacToeBoxClass
open Translate

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


