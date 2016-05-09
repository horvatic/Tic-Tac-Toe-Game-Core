module TicTacToeBoxClassTest
open TicTacToeBoxClass
open Xunit 
open FsUnit

[<Fact>]
let Create_New_TicTacToe_Object() =
    let ticTacToeBoard = new TicTacToeBox(["-1-"; "-2-"; "-3-"; 
                                            "-4-"; "-5-"; "-6-"; 
                                            "-7-"; "-8-"; "-9-"])
    Assert.NotNull(ticTacToeBoard)

[<Fact>]
let Victory_Cell_Count_Is_3() =
    let ticTacToeBoard = new TicTacToeBox(["-1-"; "-2-"; "-3-"; 
                                            "-4-"; "-5-"; "-6-"; 
                                            "-7-"; "-8-"; "-9-"])
    Assert.Equal(3, ticTacToeBoard.victoryCellCount() )

[<Fact>]
let Get_Edited_Box() =
    let ticTacToeBoard = new TicTacToeBox(["-1-"; "-2-"; "-3-"; 
                                            "-4-"; "-5-"; "-6-"; 
                                            "-7-"; "-8-"; "-9-"])

    let ticTacToeBoxEdited = ["-1-"; "-2-"; "-3-"; 
                            "-4-"; "-5-"; "-6-"; 
                            "-7-"; "X"; "-9-"]
    let returnedBox = ticTacToeBoard.getTicTacToeBoxEdited(7, "X")
    Assert.Equal<string>(ticTacToeBoxEdited, returnedBox.ticTacToebox)
    
(*
[<Fact>]
let Create_New_TicTacToe_Object() =
    let ticTacToeBoard = new TicTacToeBox3X3()
    Assert.NotNull(ticTacToeBoard)

[<Fact>]
let Check_Cell_Count_Is_9() =
    let ticTacToeBoard = new TicTacToeBox3X3()
    Assert.Equal(9, ticTacToeBoard.cellCount() )

[<Fact>]
let Victory_Cell_Count_Is_3() =
    let ticTacToeBoard = new TicTacToeBox3X3()
    Assert.Equal(3, ticTacToeBoard.victoryCellCount() )

[<Theory>]
[<InlineData(0)>]
[<InlineData(10)>]
let Index_Out_Of_Bounds_Get_Cell_Glyph(position : int) =
    let ticTacToeBoard = new TicTacToeBox3X3()
    (fun() -> ticTacToeBoard.getCellGlyph position |> ignore ) |> should throw typeof<IndexOutOfBoundsException>

[<Theory>]
[<InlineData(1)>]
[<InlineData(5)>]
[<InlineData(9)>]
let Get_Cell_Glyph_On_A_New_Board(position : int) =
    let ticTacToeBoard = new TicTacToeBox3X3()
    Assert.Equal("", ticTacToeBoard.getCellGlyph position)

[<Theory>]
[<InlineData(0)>]
[<InlineData(10)>]
let Index_Out_Of_Bounds_Insert_Cell_Glyph_At(position : int) =
    let ticTacToeBoard = new TicTacToeBox3X3()
    (fun() -> ticTacToeBoard.insertCellGlyphAt(position, "X") |> ignore ) |> should throw typeof<IndexOutOfBoundsException>

[<Theory>]
[<InlineData(1)>]
[<InlineData(5)>]
[<InlineData(9)>]
let Insert_Sucessful_In_Tic_Tac_Toe_Box(position : int) =
    let ticTacToeBoard = new TicTacToeBox3X3()
    ticTacToeBoard.insertCellGlyphAt(position, "X")
    Assert.Equal("X", ticTacToeBoard.getCellGlyph(position))

[<Fact>]
let Spot_Already_Taken_Same_Player() =
    let ticTacToeBoard = new TicTacToeBox3X3()
    ticTacToeBoard.insertCellGlyphAt(1, "X")
    (fun() -> ticTacToeBoard.insertCellGlyphAt(1, "X") |> ignore ) |> should throw typeof<SpotTakenException>

[<Fact>]
let Spot_Already_Taken_Differnt_Player() =
    let ticTacToeBoard = new TicTacToeBox3X3()
    ticTacToeBoard.insertCellGlyphAt(1, "X")
    (fun() -> ticTacToeBoard.insertCellGlyphAt(1, "O") |> ignore ) |> should throw typeof<SpotTakenException>

[<Fact>]
let Clone_Tic_Tac_Toe_Obejct_Sucessful() =
    let ticTacToeBoard = new TicTacToeBox3X3()
    ticTacToeBoard.insertCellGlyphAt(1, "X")
    let clonedTicTacToeBoard = ticTacToeBoard.clone() :?> TicTacToeBox3X3
    Assert.Equal("X", clonedTicTacToeBoard.getCellGlyph(1))
*)