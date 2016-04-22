module UserSettingsTest
open UserSettings
open Xunit 
open FsUnit

[<Fact>]   // test
let Make_A_Corrct_User_Setting() =
    let userTest = userSetting([|"1"; "2"; "3"; "4"; "5"; "6"; "7"; "8"; "9"|])
    Assert.Equal<userSetting>(userTest, craftUserSetting [|"1"; "2"; "3"; "4"; "5"; "6"; "7"; "8"; "9"|])
    
[<Fact>]   // test
let Make_A_Incorrect_User_Setting() =
    let TicTacToeInccorectBox = [|"1"; "2"; "3"; "4"|]
    (fun () -> craftUserSetting TicTacToeInccorectBox |> ignore) |> should throw typeof<InvaildSizeOfBox>