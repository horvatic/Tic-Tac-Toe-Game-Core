module TicTacToeBoxEditTest
open TicTacToeBoxEdit
open Xunit 
open FsUnit
open GameSettings
open PlayerValues

let gameTestCreate = craftGameSetting ([|"-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"|]) 
                                          ("X") ("@") (int playerVals.Human)(false)(false)(false)

[<Fact>]   // test
let input_Is_Sucessful() =
    let mutable ticTacToeBoxEdit = [|"-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"|]
    let ticTacToeBox = [|"X"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"|]
    
    insertUserOption 
        (ticTacToeBoxEdit)(1)
        (gameTestCreate.playerGlyph)
        (gameTestCreate.aIGlyph)

    Assert.Equal<string>(ticTacToeBoxEdit, ticTacToeBox)

[<Fact>]   // test
let input_Is_UnSucessfulWithX() =
    let mutable ticTacToeBoxEdit = [|"-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"|]
    insertUserOption (ticTacToeBoxEdit) (1) gameTestCreate.playerGlyph gameTestCreate.aIGlyph 
                        |> ignore
    (fun () -> insertUserOption ticTacToeBoxEdit 1 gameTestCreate.playerGlyph gameTestCreate.aIGlyph 
                |> ignore) |> should throw typeof<SpotAlreayTaken>

[<Fact>]   // test
let input_Is_UnSucessfulWithO() =
    let ticTacToeBox = [|"@"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"|]
    (fun () -> insertUserOption ticTacToeBox 1 gameTestCreate.playerGlyph gameTestCreate.aIGlyph 
                |> ignore) |> should throw typeof<SpotAlreayTaken>

[<Fact>]   // test
let input_Other_User_Is_Sucessful() =
    let mutable ticTacToeBoxEdit = [|"-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"|]
    let ticTacToeBox = [|"@"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"|]
    
    insertOtherUserOption 
        (ticTacToeBoxEdit)(1)
        (gameTestCreate.playerGlyph)
        (gameTestCreate.aIGlyph)

    Assert.Equal<string>(ticTacToeBoxEdit, ticTacToeBox)

[<Fact>]   // test
let input_Other_User_Is_UnSucessfulWithX() =
    let mutable ticTacToeBoxEdit = [|"-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"|]
    insertOtherUserOption (ticTacToeBoxEdit) (1) gameTestCreate.playerGlyph gameTestCreate.aIGlyph 
                        |> ignore
    (fun () -> insertOtherUserOption ticTacToeBoxEdit 1 gameTestCreate.playerGlyph gameTestCreate.aIGlyph 
                |> ignore) |> should throw typeof<SpotAlreayTaken>

[<Fact>]   // test
let input_Other_User_Is_UnSucessfulWithO() =
    let ticTacToeBox = [|"X"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"|]
    (fun () -> insertOtherUserOption ticTacToeBox 1 gameTestCreate.playerGlyph gameTestCreate.aIGlyph 
                |> ignore) |> should throw typeof<SpotAlreayTaken>