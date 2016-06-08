module TicTacToeBoxEditTest
open TicTacToe.Core 
open TicTacToeBoxEdit
open TicTacToeBoxClass
open Xunit 
open FsUnit
open GameSettings
open PlayerValues

let gameTestCreate = craftGameSetting (3)("X") ("@") (int playerVals.Human)(false)(false)(false)

[<Fact>]   // test
let input_Is_Sucessful() =
    let ticTacToeBoxEdit = new TicTacToeBox(["-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"])
    let ticTacToeBoxExample = ["X"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"]
    let ticTacToeResult = insertUserOption(ticTacToeBoxEdit)(1)(gameTestCreate.playerGlyph)(gameTestCreate.aIGlyph)
    
    for i = 0 to ticTacToeResult.cellCount() - 1 do
        Assert.Equal(ticTacToeBoxExample.[i], ticTacToeResult.getGlyphAtLocation(i))

[<Fact>]   // test
let input_Is_UnSucessfulWith() =
    let ticTacToeBox = ["X"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"]
    let editedBox = new TicTacToeBox(ticTacToeBox)
    (fun () -> insertUserOption editedBox 1 gameTestCreate.playerGlyph gameTestCreate.aIGlyph 
                |> ignore) |> should throw typeof<SpotAlreayTaken>

[<Fact>]   // test
let Other_User_Input_Is_UnSucessfulWith() =
    let ticTacToeBox = ["X"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"]
    let editedBox = new TicTacToeBox(ticTacToeBox)
    (fun () -> insertOtherUserOption editedBox 1 gameTestCreate.playerGlyph gameTestCreate.aIGlyph 
                |> ignore) |> should throw typeof<SpotAlreayTaken>
