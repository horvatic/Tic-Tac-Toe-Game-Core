module TicTacToeBoxEditTest
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


(*
let gameTestCreate = craftGameSetting ([|"-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"|]) 
                                          ("X") ("@") (int playerVals.Human)(false)(false)(false)

[<Fact>]   // test
let input_Is_Sucessful() =
    let mutable ticTacToeBoxEdit = ["-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"]
    let ticTacToeBox = ["X"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"]
   
    Assert.Equal<string>(ticTacToeBox, insertUserOption 
                                            ticTacToeBoxEdit 1
                                            gameTestCreate.playerGlyph
                                            gameTestCreate.aIGlyph)

[<Fact>]   // test
let input_Is_UnSucessfulWithX() =
    let ticTacToeBox = ["-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"]
    let editedBox = insertUserOption (ticTacToeBox) (1) gameTestCreate.playerGlyph gameTestCreate.aIGlyph 
    (fun () -> insertUserOption editedBox 1 gameTestCreate.playerGlyph gameTestCreate.aIGlyph 
                |> ignore) |> should throw typeof<SpotAlreayTaken>

[<Fact>]   // test
let input_Is_UnSucessfulWithO() =
    let ticTacToeBox = ["@"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"]
    (fun () -> insertUserOption ticTacToeBox 1 gameTestCreate.playerGlyph gameTestCreate.aIGlyph 
                |> ignore) |> should throw typeof<SpotAlreayTaken>

[<Fact>]   // test
let input_Other_User_Is_Sucessful() =
    let mutable ticTacToeBoxEdit = ["-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"]
    let ticTacToeBox = ["@"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"]
    
    Assert.Equal<string>(ticTacToeBox, insertOtherUserOption 
                                            ticTacToeBoxEdit 1
                                            gameTestCreate.playerGlyph
                                            gameTestCreate.aIGlyph)

[<Fact>]   // test
let input_Other_User_Is_UnSucessfulWithX() =
    let mutable ticTacToeBoxEdit = ["-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"]
    let tempBox = insertOtherUserOption (ticTacToeBoxEdit) (1) gameTestCreate.playerGlyph gameTestCreate.aIGlyph
    (fun () -> insertOtherUserOption tempBox 1 gameTestCreate.playerGlyph gameTestCreate.aIGlyph 
                |> ignore) |> should throw typeof<SpotAlreayTaken>

[<Fact>]   // test
let input_Other_User_Is_UnSucessfulWithO() =
    let ticTacToeBox = ["X"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"]
    (fun () -> insertOtherUserOption ticTacToeBox 1 gameTestCreate.playerGlyph gameTestCreate.aIGlyph 
                |> ignore) |> should throw typeof<SpotAlreayTaken>
*)