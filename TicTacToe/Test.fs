module Test
open Xunit 
open FsUnit
open CleanInput
open TicTacToeBoxEdit

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