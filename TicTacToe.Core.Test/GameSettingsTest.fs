module GameSettingsTest
open GameSettings
open Xunit 
open FsUnit
open PlayerValues
open userInputException

[<Fact>]   // test
let Make_A_Corrct_User_Setting() =
    let gameTest = gameSetting(3,"X", "O", int playerVals.Human, false, false, false)
    let gameTestCreate = craftGameSetting (3)("X") ("O") (int playerVals.Human)(false)(false)(false)
    Assert.Equal<gameSetting>(gameTest, gameTestCreate)

[<Fact>]   // test
let Make_A_Corrct_User_4X4_Setting() =
    let gameTest = gameSetting(4,"X", "O", int playerVals.Human, false, false, false)
    let gameTestCreate = craftGameSetting (4)("X") ("O") (int playerVals.Human)(false)(false)(false)
    Assert.Equal<gameSetting>(gameTest, gameTestCreate)

[<Fact>]   // test
let Make_A_Incorrect_Box_Size_Setting() =
    let playerGlyph = "X"
    let aIGlyph = "-1-"
    let firstPlayer = int playerVals.Human
    (fun () -> craftGameSetting 2 playerGlyph aIGlyph firstPlayer false false false |> ignore) |> should throw typeof<InvaildSizeOfBox>

[<Fact>]   // test
let Make_Same_Glyph_Error() =
    let playerGlyph = "X"
    let aIGlyph = "X"
    let firstPlayer = int playerVals.Human
    (fun () -> craftGameSetting 3 playerGlyph aIGlyph firstPlayer false false false |> ignore) |> should throw typeof<InvaildGlyph>

[<Fact>]   // test
let Make_Inncorect_Player() =
    let playerGlyph = "X"
    let aIGlyph = "1"
    let firstPlayer = 999
    (fun () -> craftGameSetting 3 playerGlyph aIGlyph firstPlayer false false false |> ignore) |> should throw typeof<InvaildPlayer>

[<Fact>]   // test
let Make_Player_Two_Invaild_Glyph_Error() =
    let playerGlyph = "X"
    let aIGlyph = "X3"
    let firstPlayer = int playerVals.Human
    (fun () -> craftGameSetting 3 playerGlyph aIGlyph firstPlayer false false false |> ignore) |> should throw typeof<InvaildGlyph>

[<Fact>]   // test
let Make_Player_One_Invaild_Glyph_Player() =
    let playerGlyph = "X2"
    let aIGlyph = "-1-"
    let firstPlayer = 999
    (fun () -> craftGameSetting 3 playerGlyph aIGlyph firstPlayer false false false |> ignore) |> should throw typeof<InvaildGlyph>
