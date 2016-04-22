module GameTest
open Xunit 
open FsUnit
open Game
open CheckForWinnerOrTie

[<Fact>]    // test
let Game_Is_Over_AI_Won() =
    let ticTacToeBox = [|"@"; "@"; "@"; 
                         "4"; "X"; "6"; 
                         "X"; "8"; "X"|]
    Assert.Equal(true, isGameOver ticTacToeBox)

[<Fact>]    // test
let Game_Is_Over_Human_Won() =
    let ticTacToeBox = [|"X"; "X"; "X"; 
                         "@"; "X"; "6"; 
                         "@"; "8"; "@"|]
    Assert.Equal(true, isGameOver ticTacToeBox)

[<Fact>]    // test
let Game_Is_Over_Tie() =
    let ticTacToeBox = [|"X"; "@"; "X"; 
                         "@"; "X"; "@"; 
                         "@"; "X"; "@"|]
    Assert.Equal(true, isGameOver ticTacToeBox)

[<Fact>]    // test
let Game_Is_Not_Over =
    let ticTacToeBox = [|"1"; "2"; "3"; 
                         "4"; "5"; "6"; 
                         "7"; "8"; "9"|]
    Assert.Equal(false, isGameOver ticTacToeBox)

[<Fact>]    // test
let Human_Won_The_Game =
    let ticTacToeBox = [|"X"; "X"; "X"; 
                         "@"; "X"; "6"; 
                         "@"; "8"; "@"|]
    Assert.Equal("Human Won", gameEndingMessage ticTacToeBox)

[<Fact>]    // test
let AI_Won_The_Game =
    let ticTacToeBox = [|"@"; "@"; "@"; 
                         "4"; "X"; "6"; 
                         "X"; "8"; "X"|]
    Assert.Equal("AI Won", gameEndingMessage ticTacToeBox)

[<Fact>]    // test
let Tie_Game =
    let ticTacToeBox = [|"X"; "@"; "X"; 
                         "@"; "X"; "@"; 
                         "@"; "X"; "@"|]
    Assert.Equal("Tie", gameEndingMessage ticTacToeBox)

[<Fact>]   // test
let Game_Still_In_Session_Exception() =
    let ticTacToeBox = [|"1"; "2"; "3"; 
                         "4"; "5"; "6"; 
                         "7"; "8"; "9"|]
    (fun () -> gameEndingMessage ticTacToeBox |> ignore) |> should throw typeof<GameStillInSession>