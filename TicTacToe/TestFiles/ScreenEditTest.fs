module ScreenEditTest
open Xunit
open FsUnit
open ScreenEdit

[<Fact>]
 let Trow_If_Box_Size_Invaild() =
    let TextBox = [|"1"|]
    ( fun() -> writeToScreen TextBox "" |> ignore ) |> should throw typeof<InvaildBox>