module Test
open Xunit 
open FsUnit
open CleanInput
open TicTacToeBoxEdit
open AI

[<Fact>]   // test
let Sanitize_5_String_To_5() =
    Assert.Equal(5, Sanitize "5" )

[<Fact>]   // test
let Sanitize_fail_String_To_Exception() =
    (fun () -> Sanitize "fe" |> ignore) |> should throw typeof<NonIntError>

[<Fact>]   // test
let Sanitize_fail_val_high_To_Exception() =
    (fun () -> Sanitize "12" |> ignore) |> should throw typeof<OutOfBoundsOverFlow>

[<Fact>]   // test
let Sanitize_fail_val_low_To_Exception() =
    (fun () -> Sanitize "0" |> ignore) |> should throw typeof<OutOfBoundsUnderFlow>

[<Fact>]   // test
let input_Is_Sucessful() =
    let mutable ticTacToeBoxEdit = [|"1"; "2"; "3"; "4"; "5"; "6"; "7"; "8"; "9"|]
    let ticTacToeBox = [|"X"; "2"; "3"; "4"; "5"; "6"; "7"; "8"; "9"|]
    Assert.Equal<string>(ticTacToeBox, InsertUserOption ticTacToeBoxEdit 1 )

[<Fact>]   // test
let input_Is_UnSucessfulWithX() =
    let mutable ticTacToeBoxEdit = [|"1"; "2"; "3"; "4"; "5"; "6"; "7"; "8"; "9"|]
    InsertUserOption (ticTacToeBoxEdit) (1) |> ignore
    (fun () -> InsertUserOption ticTacToeBoxEdit 1 |> ignore) |> should throw typeof<SpotAlreayTaken>

[<Fact>]   // test
let input_Is_UnSucessfulWithO() =
    let ticTacToeBox = [|"O"; "2"; "3"; "4"; "5"; "6"; "7"; "8"; "9"|]
    (fun () -> InsertUserOption ticTacToeBox 1 |> ignore) |> should throw typeof<SpotAlreayTaken>


[<Fact>]   // test
let AI_Picks_Winning_Move_Horzontail_Row_One() =
    let ticTacToeBox = [|"O"; "O"; "3"; "4"; "5"; "6"; "7"; "8"; "9"|]
    Assert.Equal(2, moveBeHorzontail ticTacToeBox "O" "X" )

[<Fact>]   // test
let AI_Picks_Winning_Move_Horzontail_Row_Two() =
    let ticTacToeBox = [|"1"; "2"; "3"; "O"; "O"; "6"; "7"; "8"; "9"|]
    Assert.Equal(5, moveBeHorzontail ticTacToeBox "O" "X" )

[<Fact>]   // test
let AI_Picks_Winning_Move_Horzontail_Row_Three() =
    let ticTacToeBox = [|"1"; "2"; "3"; "4"; "5"; "6"; "O"; "O"; "9"|]
    Assert.Equal(8, moveBeHorzontail ticTacToeBox "O" "X" )

[<Fact>]   // test
let AI_Picks_Winning_Move_Vertical_Row_One() =
    let ticTacToeBox = [|"O"; "2"; "3"; "O"; "5"; "6"; "7"; "8"; "9"|]
    Assert.Equal(6, moveBeVertical ticTacToeBox "O" "X" )

[<Fact>]   // test
let AI_Picks_Winning_Move_Vertical_Row_Two() =
    let ticTacToeBox = [|"1"; "O"; "3"; "4"; "O"; "6"; "7"; "8"; "9"|]
    Assert.Equal(7, moveBeVertical ticTacToeBox "O" "X" )

[<Fact>]   // test
let AI_Picks_Winning_Move_Vertical_Row_Three() =
    let ticTacToeBox = [|"1"; "2"; "O"; "4"; "5"; "O"; "7"; "8"; "9"|]
    Assert.Equal(8, moveBeVertical ticTacToeBox "O" "X" )

[<Fact>]   // test
let AI_Picks_Blocking_Move_Horzontail_Row_One() =
    let ticTacToeBox = [|"X"; "X"; "3"; "4"; "5"; "6"; "7"; "8"; "9"|]
    Assert.Equal(2, moveBeHorzontail ticTacToeBox "X" "O" )

[<Fact>]   // test
let AI_Picks_Blocking_Move_Horzontail_Row_Two() =
    let ticTacToeBox = [|"1"; "2"; "3"; "X"; "X"; "6"; "7"; "8"; "9"|]
    Assert.Equal(5, moveBeHorzontail ticTacToeBox "X" "O" )

[<Fact>]   // test
let AI_Picks_Blocking_Move_Horzontail_Row_Three() =
    let ticTacToeBox = [|"1"; "2"; "3"; "4"; "5"; "6"; "X"; "X"; "9"|]
    Assert.Equal(8, moveBeHorzontail ticTacToeBox "X" "O" )

[<Fact>]   // test
let AI_Picks_Blocking_Move_Vertical_Row_One() =
    let ticTacToeBox = [|"X"; "2"; "3"; "X"; "5"; "6"; "7"; "8"; "9"|]
    Assert.Equal(6, moveBeVertical ticTacToeBox "X" "O" )

[<Fact>]   // test
let AI_Picks_Blocking_Move_Vertical_Row_Two() =
    let ticTacToeBox = [|"1"; "X"; "3"; "4"; "X"; "6"; "7"; "8"; "9"|]
    Assert.Equal(7, moveBeVertical ticTacToeBox "X" "O" )

[<Fact>]   // test
let AI_Picks_Blocking_Move_Vertical_Row_Three() =
    let ticTacToeBox = [|"1"; "2"; "X"; "4"; "5"; "X"; "7"; "8"; "9"|]
    Assert.Equal(8, moveBeVertical ticTacToeBox "X" "O" )