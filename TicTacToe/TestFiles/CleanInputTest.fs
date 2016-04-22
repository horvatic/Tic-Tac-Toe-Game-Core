module CleanInputTest
open Xunit 
open FsUnit
open CleanInput

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