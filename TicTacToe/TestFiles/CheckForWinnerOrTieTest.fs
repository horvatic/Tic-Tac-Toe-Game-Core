module CheckForWinnerOrTieTest
open Xunit 
open FsUnit
open CheckForWinnerOrTie
open GameStatusCodes

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