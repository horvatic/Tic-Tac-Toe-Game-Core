module AITest
open Xunit 
open FsUnit
open AI
open CheckForWinnerOrTie
open PlayerValues
open GameStatusCodes
open System.Collections.Generic
open GameSettings

let gameTestCreate = craftGameSetting ([|"-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"|]) 
                                          ("X") ("@") (int playerVals.Human)(false)(false)

[<Fact>] //test
let Get_Box_Legnth_3x3() =
    let ticTacToeBox = [|"-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"|]
    Assert.Equal(3, getBoxLength ticTacToeBox.Length )

[<Fact>] //test
let Get_Box_Legnth_4x4() =
    let ticTacToeBox = [|"-1-"; "-2-"; "-3-"; "-4-"; 
                        "-5-"; "-6-"; "-7-"; "-8-"; 
                        "-9-"; "-10-"; "-11-"; "-12-";
                        "-13-"; "-14-"; "-15-"; "-16-"|]
    Assert.Equal(4, getBoxLength ticTacToeBox.Length )

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


[<Fact>] //test
let Make_Empty_Score_3X3() =
    let scores = [|0; 0; 0; 0; 0; 0; 0; 0; 0|]
    Assert.Equal<int>(scores, makeEmptyScore scores.Length )

[<Fact>] //test
let Make_Empty_Score_4X4() =
    let scores = [|0; 0; 0; 0; 
                        0; 0; 0; 0; 
                        0; 0; 0; 0;
                        0; 0; 0; 0|]
    Assert.Equal<int>(scores, makeEmptyScore scores.Length )

[<Fact>] //test
let Test_Scan_For_Already_Made_Trees() =
    let oldTrees = new Dictionary<string, int>()
    oldTrees.Add("XO3456789", -10)
    oldTrees.Add("XO3X56789", -5)
    Assert.Equal(-10, checkForAlreadyMadeTree oldTrees "XO3456789" )

[<Fact>] //test
let Test_Scan_For_NoValue_In_Already_Made_Trees() =
    let oldTrees = new Dictionary<string, int>()
    oldTrees.Add("XO3456789", -10)
    Assert.Equal(-9999, checkForAlreadyMadeTree oldTrees "X23456789" )

[<Fact>] //test
let Test_Scan_For_NoValue_In_None_Made_Trees() =
    let oldTrees = new Dictionary<string, int>()
    Assert.Equal(-9999, checkForAlreadyMadeTree oldTrees "X23456789" )

[<Fact>] //test
let TicTacToeBox_To_String() =
    let ticTacToeBox = [|"-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"|]
    Assert.Equal("-1--2--3--4--5--6--7--8--9-", 
        ticTacToeBoxToString ticTacToeBox )
