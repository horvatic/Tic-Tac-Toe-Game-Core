module BuildAndStartGameTest
open Xunit
open FsUnit
open BuildAndStartGame
open userInputException
open InputOutPutTestBuildGame

[<Fact>]
let User_Setting_Bad() = 
    let io = new InputOutTestBuildGameManyOps([|"N";|])
    let ticTacToeBox = [|"-1-"; "-2-"; "-3-"; 
                         "-4-"; "-5-"; "-6-"; 
                         "-7-"; "-8-"; "-9-"|]

    Assert.Equal(false, settingGood io ticTacToeBox "X" "#" false "")

[<Fact>]
let User_Setting_Good() = 
    let io = new InputOutTestBuildGameManyOps([|"Y";|])
    let ticTacToeBox = [|"-1-"; "-2-"; "-3-"; 
                         "-4-"; "-5-"; "-6-"; 
                         "-7-"; "-8-"; "-9-"|]
    Assert.Equal(true, settingGood io ticTacToeBox "X" "#" false "")

[<Fact>]
let User_Setting_Bad_Take_Three_Tries() = 
    let io = new InputOutTestBuildGameManyOps([|"X"; "X"; "N";|])
    let ticTacToeBox = [|"-1-"; "-2-"; "-3-"; 
                         "-4-"; "-5-"; "-6-"; 
                         "-7-"; "-8-"; "-9-"|]

    Assert.Equal(false, settingGood io ticTacToeBox "X" "#" false "")

[<Fact>]
let User_Setting_Good_Take_Three_Tries() = 
    let io = new InputOutTestBuildGameManyOps([|"X"; "X"; "Y";|])
    let ticTacToeBox = [|"-1-"; "-2-"; "-3-"; 
                         "-4-"; "-5-"; "-6-"; 
                         "-7-"; "-8-"; "-9-"|]

    Assert.Equal(true, settingGood io ticTacToeBox "X" "#" false "")

[<Fact>]
let User_Picks_AI_Glyph_unsucsfully_Until_No_Pick_Players() = 
    let io = new InputOutTestBuildGameManyOps([|"X"; "X"; "@";|])
    let aIGlyph = "@"
    Assert.Equal(aIGlyph, getaIGlyph io "" "X")

[<Fact>]
let User_Picks_AI_Glyph_unsucsfully_Until_FithPick() = 
    let io = new InputOutTestBuildGameManyOps([|"33"; "222"; "3m"; "3m"; "3"|])
    let aIGlyph = "3"
    Assert.Equal(aIGlyph, getaIGlyph io "" "X")

[<Fact>]
let User_Picks_AI_Glyph_Sucsfully() = 
    let io = new InputOutTestBuildGame("3")
    let aIGlyph = "3"
    Assert.Equal(aIGlyph, getaIGlyph io "" "X")

[<Fact>]
let User_Picks_Player_Glyph_unsucsfully_Until_FithPick() = 
    let io = new InputOutTestBuildGameManyOps([|"33"; "222"; "3m"; "3m"; "3"|])
    let userGlyph = "3"
    Assert.Equal(userGlyph, getplayerGlyph io "")

[<Fact>]
let User_Picks_Player_Glyph_Sucsfully() = 
    let io = new InputOutTestBuildGame("3")
    let userGlyph = "3"
    Assert.Equal(userGlyph, getplayerGlyph io "")

[<Fact>]
let User_Picks_4X4_Three_Tries_Box() = 
    let ticTacToeBox = [|"-1-"; "-2-"; "-3-"; "-4-"; 
                         "-5-"; "-6-"; "-7-"; "-8-"; 
                         "-9-"; "-10-"; "-11-"; "-12-";
                         "-13-"; "-14-"; "-15-"; "-16-"|]
    let io = new InputOutTestBuildGameManyOps([|"dfef"; "dwq"; "4"|])
    Assert.Equal<string>(ticTacToeBox, getBoxOfUserSize io "")

[<Fact>]
let User_Picks_3X3_Three_Tries_Box() = 
    let ticTacToeBox = [|"-1-"; "-2-"; "-3-"; 
                         "-4-"; "-5-"; "-6-"; 
                         "-7-"; "-8-"; "-9-"|]
    let io = new InputOutTestBuildGameManyOps([|"dfef"; "dwq"; "3"|])
    Assert.Equal<string>(ticTacToeBox, getBoxOfUserSize io "")

[<Fact>]
let User_Picks_4X4_Box() = 
    let ticTacToeBox = [|"-1-"; "-2-"; "-3-"; "-4-"; 
                         "-5-"; "-6-"; "-7-"; "-8-"; 
                         "-9-"; "-10-"; "-11-"; "-12-";
                         "-13-"; "-14-"; "-15-"; "-16-"|]
    let io = new InputOutTestBuildGame("4")
    Assert.Equal<string>(ticTacToeBox, getBoxOfUserSize io "")

[<Fact>]
let User_Picks_3X3_Box() = 
    let ticTacToeBox = [|"-1-"; "-2-"; "-3-"; 
                         "-4-"; "-5-"; "-6-"; 
                         "-7-"; "-8-"; "-9-"|]
    let io = new InputOutTestBuildGame("3")
    Assert.Equal<string>(ticTacToeBox, getBoxOfUserSize io "")

[<Fact>]
let Set_Game_Is_Inverted() =
    let io = new InputOutTestBuildGame("y")
    Assert.Equal(true, isGameInverted io "")

[<Fact>]
let Set_Game_Is_Not_Inverted() =
    let io = new InputOutTestBuildGame("n")
    Assert.Equal(false, isGameInverted io "")

[<Fact>]
let Set_Game_Is_Takes_Two_Tries_Non_Inverted() =
    let io = new InputOutTestBuildGameManyOps([|"wqeqw"; "n"|])
    Assert.Equal(false, isGameInverted io "")

[<Fact>]
let Set_Game_Is_Not_Takes_Two_Tries_Inverted() =
    let io = new InputOutTestBuildGameManyOps([|"wqeqw"; "y"|])
    Assert.Equal(true, isGameInverted io "")

[<Fact>]
let Make_Tic_Tac_Toe_Box_3X3_Correct() =
    let ticTacToeBox = [|"-1-"; "-2-"; "-3-"; 
                         "-4-"; "-5-"; "-6-"; 
                         "-7-"; "-8-"; "-9-"|]
    Assert.Equal<string>(ticTacToeBox, makeTicTacToeBox 3)

[<Fact>]
let Make_Tic_Tac_Toe_Box_4X4_Correct() =
    let ticTacToeBox = [|"-1-"; "-2-"; "-3-"; "-4-"; 
                         "-5-"; "-6-"; "-7-"; "-8-"; 
                         "-9-"; "-10-"; "-11-"; "-12-";
                         "-13-"; "-14-"; "-15-"; "-16-"|]
    Assert.Equal<string>(ticTacToeBox, makeTicTacToeBox 4)

[<Fact>]   // test
let Make_Tic_Tac_Toe_Box_5X5_Correct_To_Exception() =
    (fun () -> makeTicTacToeBox 5 |> ignore) |> should throw typeof<OutOfBoundsOverFlow>

[<Fact>]   // test
let Make_Tic_Tac_Toe_Box_0X0_Correct_To_Exception() =
    (fun () -> makeTicTacToeBox 0 |> ignore) |> should throw typeof<OutOfBoundsUnderFlow>

