module CleanInputTest
open TicTacToe.Core 
open Xunit 
open FsUnit
open CleanInput
open userInputException

[<Fact>]   // test
let Sanitize_5_String_To_5_4X4() =
    Assert.Equal(5, SanitizeHumanPickedPlace "5" 16 )

[<Fact>]   // test
let Sanitize_fail_String_To_Exception_4X4() =
    (fun () -> SanitizeHumanPickedPlace "fe" 16 |> ignore) |> should throw typeof<NonIntError>

[<Fact>]   // test
let Sanitize_fail_val_high_To_Exception_4X4() =
    (fun () -> SanitizeHumanPickedPlace "22" 16 |> ignore) |> should throw typeof<OutOfBoundsOverFlow>

[<Fact>]   // test
let Sanitize_fail_val_low_To_Exception_4X4() =
    (fun () -> SanitizeHumanPickedPlace "0" 16 |> ignore) |> should throw typeof<OutOfBoundsUnderFlow>

[<Fact>]   // test
let Sanitize_fail_String_To_Exception_3X3() =
    (fun () -> SanitizeHumanPickedPlace "fe" 9 |> ignore) |> should throw typeof<NonIntError>

[<Fact>]   // test
let Sanitize_fail_val_high_To_Exception_3X3() =
    (fun () -> SanitizeHumanPickedPlace "12" 9 |> ignore) |> should throw typeof<OutOfBoundsOverFlow>

[<Fact>]   // test
let Sanitize_fail_val_low_To_Exception_3X3() =
    (fun () -> SanitizeHumanPickedPlace "0" 9 |> ignore) |> should throw typeof<OutOfBoundsUnderFlow>

