module CleanInputTest
open Xunit 
open FsUnit
open CleanInput
open userInputException

[<Fact>]   // test
let Sanitize_5_String_To_5() =
    Assert.Equal(5, SanitizeHumanPickedPlace "5" )

[<Fact>]   // test
let Sanitize_fail_String_To_Exception() =
    (fun () -> SanitizeHumanPickedPlace "fe" |> ignore) |> should throw typeof<NonIntError>

[<Fact>]   // test
let Sanitize_fail_val_high_To_Exception() =
    (fun () -> SanitizeHumanPickedPlace "12" |> ignore) |> should throw typeof<OutOfBoundsOverFlow>

[<Fact>]   // test
let Sanitize_fail_val_low_To_Exception() =
    (fun () -> SanitizeHumanPickedPlace "0" |> ignore) |> should throw typeof<OutOfBoundsUnderFlow>

[<Fact>]   // test
let Sanitize_Player_Picked_Glyph() =
    Assert.Equal("5", SanitizeGlyph "5" )

[<Fact>]   // test
let Sanitize_Player_Picked_Glyph_To_Exception() =
    (fun () -> SanitizeGlyph "fe" |> ignore) |> should throw typeof<InvaildGlyph>

[<Fact>]   // test
let Sanitize_Use_Box_Size_3() =
    Assert.Equal(3, SanitizeBoxSize "3" )

[<Fact>]   // test
let Sanitize_Use_Box_Size_4() =
    Assert.Equal(4, SanitizeBoxSize "4" )

[<Fact>]   // test
let Sanitize_Box_Size_To_Exception() =
    (fun () -> SanitizeBoxSize "3m" |> ignore) |> should throw typeof<NonIntError>

[<Fact>]   // test
let Sanitize_Box_Size_EmptyString_To_Exception() =
    (fun () -> SanitizeBoxSize "" |> ignore) |> should throw typeof<NonIntError>

[<Fact>]   // test
let Sanitize_Box_Size_Empty_To_Exception() =
    (fun () -> SanitizeBoxSize "0" |> ignore) |> should throw typeof<OutOfBoundsUnderFlow>

[<Fact>]   // test
let Sanitize_Box_Size_9_To_Exception() =
    (fun () -> SanitizeBoxSize "9" |> ignore) |> should throw typeof<OutOfBoundsOverFlow>

[<Fact>]   // test
let Sanitize_User_Go_First_Or_Not_UpperCase_Y() =
    Assert.Equal("Y", SanitizeYesOrNo "Y" )

[<Fact>]   // test
let Sanitize_User_Go_First_Or_Not_LowerCase_y() =
    Assert.Equal("Y", SanitizeYesOrNo "y" )

[<Fact>]   // test
let Sanitize_User_Go_First_Or_Not_LowerCase_n() =
    Assert.Equal("N", SanitizeYesOrNo "n" )

[<Fact>]   // test
let Sanitize_User_Go_First_Or_Not_UpperCase_N() =
    Assert.Equal("N", SanitizeYesOrNo "N" )

[<Fact>]   // test
let Sanitize_User_Go_First_Or_Not_9_To_Exception() =
    (fun () -> SanitizeYesOrNo "9" |> ignore) |> should throw typeof<InvaildOption>

let Sanitize_User_Go_First_Or_Not_rge_To_Exception() =
    (fun () -> SanitizeYesOrNo"rge" |> ignore) |> should throw typeof<InvaildOption>