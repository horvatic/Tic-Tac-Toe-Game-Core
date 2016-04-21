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

[<Fact>]   // test
let Check_If_Unbeatable() =
    let mutable place = -1
    let mutable currentPlayer = int playerVals.AI
    let mutable matchResult = int Result.NoWinner
    let mutable gameOver = false
    for i = 0 to 8 do
        let ticTacToeBox = [|"1"; "2"; "3"; "4"; "5"; "6"; "7"; "8"; "9"|]
        place <- -1
        currentPlayer <- int playerVals.AI
        matchResult <- int Result.NoWinner
        gameOver <- false
        ticTacToeBox.[i] <- "X"
        for i = 0 to 8 do
            if not gameOver then
                if currentPlayer = int playerVals.Human then
                    for i = 0 to 8 do
                        if ticTacToeBox.[i] = "X" then
                            ticTacToeBox.[i] <- "@"
                        elif ticTacToeBox.[i] = "@" then
                            ticTacToeBox.[i] <- "X"
                    place <- computerMove(ticTacToeBox)
                    for i = 0 to 8 do
                        if ticTacToeBox.[i] = "X" then
                            ticTacToeBox.[i] <- "@"
                        elif ticTacToeBox.[i] = "@" then
                            ticTacToeBox.[i] <- "X"
                    ticTacToeBox.[place] <- "X"
                else
                    place <- computerMove(ticTacToeBox)
                    ticTacToeBox.[place] <- "@"
                currentPlayer <- currentPlayer * -1
                matchResult <- checkForWinnerOrTie(ticTacToeBox)
                if not (matchResult = int Result.NoWinner) then
                    gameOver <- true
        Assert.Equal(int Result.Tie, int matchResult )