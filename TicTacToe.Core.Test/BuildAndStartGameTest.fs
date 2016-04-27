module BuildAndStartGameTest
open Xunit
open FsUnit
open BuildAndStartGame
open userInputException

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

