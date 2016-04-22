module GameSettingsTest
open GameSettings
open Xunit 
open FsUnit
open PlayerValues
open userInputException


[<Fact>]   // test
let Make_A_Corrct_User_Setting() =
    let gameTest = gameSetting([|"1"; "2"; "3"; "4"; "5"; "6"; "7"; "8"; "9"|],
                               "X", "O", int playerVals.Human, false, false)
    let gameTestCreate = craftGameSetting ([|"1"; "2"; "3"; "4"; "5"; "6"; "7"; "8"; "9"|]) 
                                          ("X") ("O") (int playerVals.Human)(false)(false)
    Assert.Equal<gameSetting>(gameTest, gameTestCreate)

[<Fact>]   // test
let Make_A_Corrct_User_4X4_Setting() =
    let gameTest = gameSetting([|"1"; "2"; "3"; "4"; 
                                 "5"; "6"; "7"; "8"; 
                                 "9"; "10"; "11"; "12";
                                 "13"; "14"; "15"; "16"|],
                                  "X", "O", int playerVals.Human, false, false)
    let gameTestCreate = craftGameSetting ([|"1"; "2"; "3"; "4"; 
                                             "5"; "6"; "7"; "8"; 
                                             "9"; "10"; "11"; "12";
                                             "13"; "14"; "15"; "16"|]) 
                                          ("X") ("O") (int playerVals.Human)(false)(false)
    Assert.Equal<gameSetting>(gameTest, gameTestCreate)
    
[<Fact>]   // test
let Make_A_Incorrect_Box_Size_Setting() =
    let TicTacToeInccorectBox = [|"1"; "2"; "3"; "4"|]
    let playerOneGlyph = "X"
    let playerTwoGlyph = "1"
    let firstPlayer = int playerVals.Human
    (fun () -> craftGameSetting TicTacToeInccorectBox playerOneGlyph playerTwoGlyph firstPlayer false false |> ignore) |> should throw typeof<InvaildSizeOfBox>

[<Fact>]   // test
let Make_Same_Glyph_Error() =
    let TicTacToeInccorectBox = [|"1"; "2"; "3"; "4"; "5"; "6"; "7"; "8"; "9"|]
    let playerOneGlyph = "X"
    let playerTwoGlyph = "X"
    let firstPlayer = int playerVals.Human
    (fun () -> craftGameSetting TicTacToeInccorectBox playerOneGlyph playerTwoGlyph firstPlayer false false |> ignore) |> should throw typeof<InvaildGlyph>

[<Fact>]   // test
let Make_Inncorect_Player() =
    let TicTacToeInccorectBox = [|"1"; "2"; "3"; "4"; "5"; "6"; "7"; "8"; "9"|]
    let playerOneGlyph = "X"
    let playerTwoGlyph = "1"
    let firstPlayer = 999
    (fun () -> craftGameSetting TicTacToeInccorectBox playerOneGlyph playerTwoGlyph firstPlayer false false |> ignore) |> should throw typeof<InvaildPlayer>

[<Fact>]   // test
let Make_Player_Two_Invaild_Glyph_Error() =
    let TicTacToeInccorectBox = [|"1"; "2"; "3"; "4"; "5"; "6"; "7"; "8"; "9"|]
    let playerOneGlyph = "X"
    let playerTwoGlyph = "X3"
    let firstPlayer = int playerVals.Human
    (fun () -> craftGameSetting TicTacToeInccorectBox playerOneGlyph playerTwoGlyph firstPlayer false false |> ignore) |> should throw typeof<InvaildGlyph>

[<Fact>]   // test
let Make_Player_One_Invaild_Glyph_Player() =
    let TicTacToeInccorectBox = [|"1"; "2"; "3"; "4"; "5"; "6"; "7"; "8"; "9"|]
    let playerOneGlyph = "X2"
    let playerTwoGlyph = "1"
    let firstPlayer = 999
    (fun () -> craftGameSetting TicTacToeInccorectBox playerOneGlyph playerTwoGlyph firstPlayer false false |> ignore) |> should throw typeof<InvaildGlyph>