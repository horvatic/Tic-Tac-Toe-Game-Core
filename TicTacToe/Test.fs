module Test
open Xunit 
open FsUnit
open CleanInput
open TicTacToeBoxEdit
open AI
open CheckForWinnerOrTie

[<Fact>]   // test
let Sanitize_5_String_To_5() =
    Assert.Equal(5, Sanitize "5" )

[<Fact>]   // test
let Sanitize_fail_String_To_Exception() =
    (fun () -> Sanitize "fe" |> ignore) |> should throw typeof<NonIntError>

[<Fact>]   // test
let Sanitize_fail_val_high_To_Exception() =
    (fun () -> Sanitize "12" |> ignore) |> should throw typeof<OutOfBoundsOverFlow>

[<Fact>]   // test
let Sanitize_fail_val_low_To_Exception() =
    (fun () -> Sanitize "0" |> ignore) |> should throw typeof<OutOfBoundsUnderFlow>

[<Fact>]   // test
let input_Is_Sucessful() =
    let mutable ticTacToeBoxEdit = [|"1"; "2"; "3"; "4"; "5"; "6"; "7"; "8"; "9"|]
    let ticTacToeBox = [|"X"; "2"; "3"; "4"; "5"; "6"; "7"; "8"; "9"|]
    Assert.Equal<string>(ticTacToeBox, InsertUserOption ticTacToeBoxEdit 1 )

[<Fact>]   // test
let input_Is_UnSucessfulWithX() =
    let mutable ticTacToeBoxEdit = [|"1"; "2"; "3"; "4"; "5"; "6"; "7"; "8"; "9"|]
    InsertUserOption (ticTacToeBoxEdit) (1) |> ignore
    (fun () -> InsertUserOption ticTacToeBoxEdit 1 |> ignore) |> should throw typeof<SpotAlreayTaken>

[<Fact>]   // test
let input_Is_UnSucessfulWithO() =
    let ticTacToeBox = [|"@"; "2"; "3"; "4"; "5"; "6"; "7"; "8"; "9"|]
    (fun () -> InsertUserOption ticTacToeBox 1 |> ignore) |> should throw typeof<SpotAlreayTaken>


[<Fact>]   // test
let AI_Picks_Winning_Move_Horzontail_Row_One() =
    let ticTacToeBox = [|"@"; "@"; "3"; "4"; "5"; "6"; "7"; "8"; "9"|]
    Assert.Equal(2, moveBeHorzontail ticTacToeBox "@" "X" )

[<Fact>]   // test
let AI_Picks_Winning_Move_Horzontail_Row_Two() =
    let ticTacToeBox = [|"1"; "2"; "3"; "@"; "@"; "6"; "7"; "8"; "9"|]
    Assert.Equal(5, moveBeHorzontail ticTacToeBox "@" "X" )

[<Fact>]   // test
let AI_Picks_Winning_Move_Horzontail_Row_Three() =
    let ticTacToeBox = [|"1"; "2"; "3"; "4"; "5"; "6"; "@"; "@"; "9"|]
    Assert.Equal(8, moveBeHorzontail ticTacToeBox "@" "X" )

[<Fact>]   // test
let AI_Picks_Winning_Move_Vertical_Row_One() =
    let ticTacToeBox = [|"@"; "2"; "3"; "@"; "5"; "6"; "7"; "8"; "9"|]
    Assert.Equal(6, moveBeVertical ticTacToeBox "@" "X" )

[<Fact>]   // test
let AI_Picks_Winning_Move_Vertical_Row_Two() =
    let ticTacToeBox = [|"1"; "@"; "3"; "4"; "@"; "6"; "7"; "8"; "9"|]
    Assert.Equal(7, moveBeVertical ticTacToeBox "@" "X" )

[<Fact>]   // test
let AI_Picks_Winning_Move_Vertical_Row_Three() =
    let ticTacToeBox = [|"1"; "2"; "@"; "4"; "5"; "@"; "7"; "8"; "9"|]
    Assert.Equal(8, moveBeVertical ticTacToeBox "@" "X" )

[<Fact>]   // test
let AI_Picks_Blocking_Move_Horzontail_Row_One() =
    let ticTacToeBox = [|"X"; "X"; "3"; "4"; "5"; "6"; "7"; "8"; "9"|]
    Assert.Equal(2, moveBeHorzontail ticTacToeBox "X" "@" )

[<Fact>]   // test
let AI_Picks_Blocking_Move_Horzontail_Row_Two() =
    let ticTacToeBox = [|"1"; "2"; "3"; "X"; "X"; "6"; "7"; "8"; "9"|]
    Assert.Equal(5, moveBeHorzontail ticTacToeBox "X" "@" )

[<Fact>]   // test
let AI_Picks_Blocking_Move_Horzontail_Row_Three() =
    let ticTacToeBox = [|"1"; "2"; "3"; "4"; "5"; "6"; "X"; "X"; "9"|]
    Assert.Equal(8, moveBeHorzontail ticTacToeBox "X" "@" )

[<Fact>]   // test
let AI_Picks_Blocking_Move_Vertical_Row_One() =
    let ticTacToeBox = [|"X"; "2"; "3"; "X"; "5"; "6"; "7"; "8"; "9"|]
    Assert.Equal(6, moveBeVertical ticTacToeBox "X" "@" )

[<Fact>]   // test
let AI_Picks_Blocking_Move_Vertical_Row_Two() =
    let ticTacToeBox = [|"1"; "X"; "3"; "4"; "X"; "6"; "7"; "8"; "9"|]
    Assert.Equal(7, moveBeVertical ticTacToeBox "X" "@" )

[<Fact>]   // test
let AI_Picks_Blocking_Move_Vertical_Row_Three() =
    let ticTacToeBox = [|"1"; "2"; "X"; "4"; "5"; "X"; "7"; "8"; "9"|]
    Assert.Equal(8, moveBeVertical ticTacToeBox "X" "@" )

[<Fact>]   // test
let AI_Human_First_Move_Center() =
    let mutable ticTacToeBoxEdit = [|"1"; "2"; "3"; "4"; "X"; "6"; "7"; "8"; "9"|]
    let ticTacToeBox = [|"1"; "2"; "3"; "4"; "X"; "6"; "7"; "8"; "@"|]
    Assert.Equal<string>(ticTacToeBox, AIMove (ticTacToeBox)(0)(true)(false) )

[<Fact>]   // test
let AI_Human_First_Move_Conner() =
    let mutable ticTacToeBoxEdit = [|"X"; "2"; "3"; "4"; "5"; "6"; "7"; "8"; "9"|]
    let ticTacToeBox = [|"X"; "2"; "3"; "4"; "@"; "6"; "7"; "8"; "9"|]
    Assert.Equal<string>(ticTacToeBox, AIMove (ticTacToeBox)(0)(true)(true) )

[<Fact>]   // test
let AI_Human_First_Move_Conner_Second_Move_Conner() =
    let mutable ticTacToeBoxEdit = [|"X"; "2"; "X"; "4"; "@"; "6"; "7"; "8"; "9"|]
    let ticTacToeBox = [|"X"; "2"; "3"; "4"; "@"; "@"; "7"; "8"; "9"|]
    Assert.Equal<string>(ticTacToeBox, AIMove (ticTacToeBox)(0)(true)(true) )

[<Fact>]   // test
let AI_Picks_Winning_Move_Diangle_Going_Right() =
    let ticTacToeBox = [|"@"; "2"; "3"; "4"; "@"; "6"; "7"; "8"; "9"|]
    Assert.Equal(8, moveBeDiangle ticTacToeBox "@" "X" )

[<Fact>]   // test
let AI_Picks_Blocking_Move_Diangle_Going_Right() =
    let ticTacToeBox = [|"X"; "2"; "3"; "4"; "X"; "6"; "7"; "8"; "9"|]
    Assert.Equal(8, moveBeDiangle ticTacToeBox "X" "@" )

[<Fact>]   // test
let AI_Picks_Winning_Move_Diangle_Going_Left() =
    let ticTacToeBox = [|"1"; "2"; "@"; "4"; "@"; "6"; "7"; "8"; "9"|]
    Assert.Equal(6, moveBeDiangle ticTacToeBox "@" "X" )

[<Fact>]   // test
let AI_Picks_Blocking_Move_Diangle_Going_Left() =
    let ticTacToeBox = [|"1"; "2"; "X"; "4"; "X"; "6"; "7"; "8"; "9"|]
    Assert.Equal(6, moveBeDiangle ticTacToeBox "X" "@" )

[<Fact>]   // test
let Check_If_AI_Won_Row_First() =
    let ticTacToeBox = [|"@"; "@"; "@"; "4"; "X"; "6"; "7"; "8"; "9"|]
    Assert.Equal(int Result.AiWins, checkForWinnerOrTie ticTacToeBox)

[<Fact>]   // test
let Check_If_AI_Won_Row_Second() =
    let ticTacToeBox = [|"1"; "2"; "3"; "@"; "@"; "@"; "7"; "8"; "9"|]
    Assert.Equal(int Result.AiWins, checkForWinnerOrTie ticTacToeBox)

[<Fact>]   // test
let Check_If_AI_Won_Row_Thrid() =
    let ticTacToeBox = [|"1"; "2"; "3"; "4"; "5"; "6"; "@"; "@"; "@"|]
    Assert.Equal(int Result.AiWins, checkForWinnerOrTie ticTacToeBox)

[<Fact>]   // test
let Check_If_Human_Won_Row_First() =
    let ticTacToeBox = [|"X"; "X"; "X"; "4"; "@"; "6"; "7"; "8"; "9"|]
    Assert.Equal(int Result.HumanWins, checkForWinnerOrTie ticTacToeBox)

[<Fact>]   // test
let Check_If_Human_Won_Row_Second() =
    let ticTacToeBox = [|"1"; "2"; "3"; "X"; "X"; "X"; "7"; "8"; "9"|]
    Assert.Equal(int Result.HumanWins, checkForWinnerOrTie ticTacToeBox)

[<Fact>]   // test
let Check_If_Human_Won_Row_Thrid() =
    let ticTacToeBox = [|"1"; "2"; "3"; "4"; "5"; "6"; "X"; "X"; "X"|]
    Assert.Equal(int Result.HumanWins, checkForWinnerOrTie ticTacToeBox)

[<Fact>]   // test
let Check_If_AI_Won_Vertical_Row_One() =
    let ticTacToeBox = [|"@"; "2"; "3"; "@"; "5"; "6"; "@"; "8"; "9"|]
    Assert.Equal(int Result.AiWins, checkForWinnerOrTie ticTacToeBox )

[<Fact>]   // test
let Check_If_AI_Won__Vertical_Row_Two() =
    let ticTacToeBox = [|"1"; "@"; "3"; "4"; "@"; "6"; "7"; "@"; "9"|]
    Assert.Equal(int Result.AiWins, checkForWinnerOrTie ticTacToeBox )

[<Fact>]   // test
let Check_If_AI_Won__Vertical_Row_Three() =
    let ticTacToeBox = [|"1"; "2"; "@"; "4"; "5"; "@"; "7"; "8"; "@"|]
    Assert.Equal(int Result.AiWins, checkForWinnerOrTie ticTacToeBox )

[<Fact>]   // test
let Check_If_Human_Won_Vertical_Row_One() =
    let ticTacToeBox = [|"X"; "2"; "3"; "X"; "5"; "6"; "X"; "8"; "9"|]
    Assert.Equal(int Result.HumanWins, checkForWinnerOrTie ticTacToeBox )

[<Fact>]   // test
let Check_If_Human_Won_Vertical_Row_Two() =
    let ticTacToeBox = [|"1"; "X"; "3"; "4"; "X"; "6"; "7"; "X"; "9"|]
    Assert.Equal(int Result.HumanWins, checkForWinnerOrTie ticTacToeBox )

[<Fact>]   // test
let Check_If_Human_Won_Vertical_Row_Three() =
    let ticTacToeBox = [|"1"; "2"; "X"; "4"; "5"; "X"; "7"; "8"; "X"|]
    Assert.Equal(int Result.HumanWins, checkForWinnerOrTie ticTacToeBox )

[<Fact>]   // test
let Check_If_Ai_Won_Right_Diangle() =
    let ticTacToeBox = [|"@"; "2"; "3"; "4"; "@"; "6"; "7"; "8"; "@"|]
    Assert.Equal(int Result.AiWins, checkForWinnerOrTie ticTacToeBox )

[<Fact>]   // test
let Check_If_Ai_Won_Left_Diangle() =
   let ticTacToeBox = [|"1"; "2"; "@"; "4"; "@"; "6"; "@"; "8"; "9"|]
   Assert.Equal(int Result.AiWins, checkForWinnerOrTie ticTacToeBox )

[<Fact>]   // test
let Check_If_Human_Won_Right_Diangle() =
    let ticTacToeBox = [|"X"; "2"; "3"; "4"; "X"; "6"; "7"; "8"; "X"|]
    Assert.Equal(int Result.HumanWins, checkForWinnerOrTie ticTacToeBox )

[<Fact>]   // test
let Check_If_Human_Won_Left_Diangle() =
   let ticTacToeBox = [|"1"; "2"; "X"; "4"; "X"; "6"; "X"; "8"; "9"|]
   Assert.Equal(int Result.HumanWins, checkForWinnerOrTie ticTacToeBox )

[<Fact>]   // test
let Check_If_Tie() =
   let ticTacToeBox = [|"X"; "X"; "@"; "@"; "@"; "X"; "X"; "X"; "@"|]
   Assert.Equal(int Result.Tie, checkForWinnerOrTie ticTacToeBox )