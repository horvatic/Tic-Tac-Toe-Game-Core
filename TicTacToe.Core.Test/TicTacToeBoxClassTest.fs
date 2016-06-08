module TicTacToeBoxClassTest
open TicTacToe.Core 
open ITicTacToeBoxClass
open TicTacToeBoxClass
open Xunit 
open FsUnit


[<Fact>]
let Create_New_TicTacToe_Object() =
    let ticTacToeBoard = new TicTacToeBox(["-1-"; "-2-"; "-3-"; 
                                            "-4-"; "-5-"; "-6-"; 
                                            "-7-"; "-8-"; "-9"])
    Assert.NotNull(ticTacToeBoard)

[<Fact>]
let get_Glyph_At_Location_One() =
    let ticTacToeBoard = new TicTacToeBox(["-1-"; "-2-"; "-3-"; 
                                            "-4-"; "-5-"; "-6-"; 
                                            "-7-"; "-8-"; "-9"])
    Assert.Equal("-2-", ticTacToeBoard.getGlyphAtLocation(1) )

[<Fact>]
let Cell_Count_Is_9() =
    let ticTacToeBoard = new TicTacToeBox(["-1-"; "-2-"; "-3-"; 
                                            "-4-"; "-5-"; "-6-"; 
                                            "-7-"; "-8-"; "-9"])
    Assert.Equal(9, ticTacToeBoard.cellCount() )

[<Fact>]
let Victory_Cell_Count_Is_3() =
    let ticTacToeBoard = new TicTacToeBox(["-1-"; "-2-"; "-3-"; 
                                            "-4-"; "-5-"; "-6-"; 
                                            "-7-"; "-8-"; "-9"])
    Assert.Equal(3, ticTacToeBoard.victoryCellCount() )

[<Fact>]
let Get_Edited_Box() =
    let ticTacToeBoard = new TicTacToeBox(["-1-"; "-2-"; "-3-"; 
                                            "-4-"; "-5-"; "-6-"; 
                                            "-7-"; "-8-"; "-9"])

    let ticTacToeBoxEdited = ["-1-"; "-2-"; "-3-"; 
                            "-4-"; "-5-"; "-6-"; 
                            "-7-"; "X"; "-9"]
    let returnedBox = ticTacToeBoard.getTicTacToeBoxEdited(7)("X")("X")("@") 
    for i = 0 to returnedBox.cellCount() - 1 do
        Assert.Equal(ticTacToeBoxEdited.[i], returnedBox.getGlyphAtLocation(i))

[<Fact>]
let Spot_Already_Taken() =

    let ticTacToeBoxEdited = new TicTacToeBox(["-1-"; "-2-"; "-3-"; 
                            "-4-"; "-5-"; "-6-"; 
                            "-7-"; "X"; "-9"])
    (fun() -> ticTacToeBoxEdited.getTicTacToeBoxEdited(7)("X")("X")("@") |> ignore ) 
        |> should throw typeof<SpotTakenException>


[<Theory>]
[<InlineData(-1)>]
[<InlineData(10)>]
let Index_Out_Of_Bounds_Inserting_Glyph(position : int) =
    let ticTacToeBoard = new TicTacToeBox(["-1-"; "-2-"; "-3-"; 
                                            "-4-"; "-5-"; "-6-"; 
                                            "-7-"; "-8-"; "-9"])
    (fun() -> ticTacToeBoard.getTicTacToeBoxEdited(position)("X")("X")("@") |> ignore ) 
        |> should throw typeof<IndexOutOfBoundsException>

[<Theory>]
[<InlineData(-1)>]
[<InlineData(10)>]
let Index_Out_Of_Bounds_Get_Cell_Glyph(position : int) =
    let ticTacToeBoard = new TicTacToeBox(["-1-"; "-2-"; "-3-"; 
                                            "-4-"; "-5-"; "-6-"; 
                                            "-7-"; "-8-"; "-9"])
    (fun() -> ticTacToeBoard.getGlyphAtLocation position |> ignore ) |> should throw typeof<IndexOutOfBoundsException>