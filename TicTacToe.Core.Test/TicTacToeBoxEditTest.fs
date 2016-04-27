module TicTacToeBoxEditTest
open TicTacToeBoxEdit
open Xunit 
open FsUnit
open GameSettings
open PlayerValues

let gameTestCreate = craftGameSetting ([|"-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"|]) 
                                          ("X") ("@") (int playerVals.Human)(false)(false)

[<Fact>]   // test
let input_Is_Sucessful() =
    let mutable ticTacToeBoxEdit = [|"-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"|]
    let ticTacToeBox = [|"X"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"|]
    Assert.Equal<string>(ticTacToeBox, InsertUserOption ticTacToeBoxEdit 1 gameTestCreate)

[<Fact>]   // test
let input_Is_UnSucessfulWithX() =
    let mutable ticTacToeBoxEdit = [|"-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"|]
    InsertUserOption (ticTacToeBoxEdit) (1) gameTestCreate |> ignore
    (fun () -> InsertUserOption ticTacToeBoxEdit 1 gameTestCreate |> ignore) |> should throw typeof<SpotAlreayTaken>

[<Fact>]   // test
let input_Is_UnSucessfulWithO() =
    let ticTacToeBox = [|"@"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"|]
    (fun () -> InsertUserOption ticTacToeBox 1 gameTestCreate |> ignore) |> should throw typeof<SpotAlreayTaken>
