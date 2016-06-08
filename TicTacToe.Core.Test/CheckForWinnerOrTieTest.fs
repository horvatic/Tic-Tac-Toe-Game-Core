module CheckForWinnerOrTieTest
open TicTacToe.Core 
open Xunit 
open FsUnit
open CheckForWinnerOrTie
open GameStatusCodes
open GameSettings
open PlayerValues
open TicTacToeBoxClass


let gameTestCreate3X3 = craftGameSetting (3)("X") ("@") (int playerVals.Human)(false)(false)(false)
let gameTestCreate4X4 = craftGameSetting (4)("X") ("@") (int playerVals.Human)(false)(false)(false)

[<Fact>]
let Check_For_Diange_Win_Left_WithOffset() =
    let ticTacToeBox = new TicTacToeBox (["-1-"; "-2-"; "@"; 
                                            "-4-"; "@"; "-6-"; 
                                            "@"; "-7-"; "-8-"])
    Assert.Equal(true, checkForDiangeWinLeft ticTacToeBox gameTestCreate3X3.aIGlyph 2)

[<Fact>]
let Check_For_Diange_Win_Left_WithOffset_Inccorect() =
    let ticTacToeBox = new TicTacToeBox (["-1-"; "-2-"; "@"; 
                                            "-4-"; "@"; "-6-"; 
                                            "@"; "-7-"; "-8-"])
    Assert.Equal(true, checkForDiangeWinLeft ticTacToeBox gameTestCreate3X3.aIGlyph 999)

[<Fact>]
let Check_For_Diange_Win_Right_WithOffset() =
    let ticTacToeBox = new TicTacToeBox (["@"; "-2-"; "-3-"; 
                                        "-4-"; "@"; "-6-"; 
                                        "-7-"; "-8-"; "@"])
    Assert.Equal(true, checkForDiangeWinRight ticTacToeBox gameTestCreate3X3.aIGlyph 0)

[<Fact>]
let Check_For_Diange_Win_Right_WithOffset_Incorrect() =
    let ticTacToeBox = new TicTacToeBox (["@"; "-2-"; "-3-"; 
                                        "-4-"; "@"; "-6-"; 
                                        "-7-"; "-8-"; "@"])
    Assert.Equal(true, checkForDiangeWinRight ticTacToeBox gameTestCreate3X3.aIGlyph 999)

[<Fact>]
let Check_For_Diange_Win_Left() =
    let ticTacToeBox = new TicTacToeBox (["-1-"; "-2-"; "@"; 
                                        "-4-"; "@"; "-6-"; 
                                        "@"; "-8-"; "-8-"])
    Assert.Equal(true, hasDiangleWin ticTacToeBox gameTestCreate3X3.aIGlyph)

[<Fact>]
let Check_For_Diange_Win_Right() =
    let ticTacToeBox = new TicTacToeBox (["@"; "-2-"; "-3-"; 
                                        "-4-"; "@"; "-6-"; 
                                        "-7-"; "-8-"; "@"])
    Assert.Equal(true, hasDiangleWin ticTacToeBox gameTestCreate3X3.aIGlyph)

[<Fact>]   // test
let AI_Won_3X3_Row_No_Does_Have_Horztonal_Victory() =
    let ticTacToeBox = new TicTacToeBox (["-1-"; "-2-"; "-3-"; "-4-"; "X"; "-6-"; "-7-"; "-8-"; "-9-"])
    Assert.Equal(false, hasHorzontailWin ticTacToeBox gameTestCreate3X3.aIGlyph 0)

[<Fact>]   // test
let AI_Won_3X3_Row_First_Does_Have_Horztonal_Victory() =
    let ticTacToeBox = new TicTacToeBox (["@"; "@"; "@"; "-4-"; "X"; "-6-"; "-7-"; "-8-"; "-9-"])
    Assert.Equal(true, hasHorzontailWin ticTacToeBox gameTestCreate3X3.aIGlyph 0)

[<Fact>]   // test
let AI_Won_3X3_Row_Second_Does_Have_Horztonal_Victory() =
    let ticTacToeBox = new TicTacToeBox (["-1-"; "-2-"; "-3-"; "@"; "@"; "@"; "-7-"; "-8-"; "-9-"])
    Assert.Equal(true, hasHorzontailWin ticTacToeBox gameTestCreate3X3.aIGlyph 0)

[<Fact>]   // test
let AI_Won_3X3_Row_Third_Does_Have_Horztonal_Victory() =
    let ticTacToeBox = new TicTacToeBox (["-1-"; "-2-"; "-3-"; "-4-"; "X"; "-6-"; "@"; "@"; "@";])
    Assert.Equal(true, hasHorzontailWin ticTacToeBox gameTestCreate3X3.aIGlyph 0)

[<Fact>]   // test
let Score_List_Is_Just_False() =
    let scoreList = new TicTacToeBox (["X"; "X"; "-1-"])
    Assert.Equal(false, horzontailTrurthValue scoreList "X" 0 0 3)

[<Fact>]   // test
let Score_List_Is_Just_False_InncorectSize() =
    let scoreList = new TicTacToeBox (["X"; "X"; "-1-"])
    Assert.Equal(true, horzontailTrurthValue scoreList "X" 999 999 999)

[<Fact>]   // test
let Score_List_Has_A_True() =
    let scoreList = new TicTacToeBox (["@"; "@"; "@";])
    Assert.Equal(true, horzontailTrurthValue scoreList "@" 0 0 3)

[<Fact>]   // test
let Vertical_Score_List_Is_Just_False() =
    let scoreList = new TicTacToeBox (["X"; "2"; "3"; 
                    "X"; "@"; "-6-"; 
                    "-7-"; "-8-"; "-9-"])
    Assert.Equal(false, verticalTrurthValue scoreList "X" 0 3)

[<Fact>]   // test
let Vertical_Score_List_Has_A_True() =
    let scoreList = new TicTacToeBox (["@"; "2"; "3"; 
                    "@"; "X"; "-6-"; 
                    "@"; "-8-"; "-9-"])
    Assert.Equal(true, verticalTrurthValue scoreList "@" 0 3)

[<Fact>]   // test
let Vertical_Score_List_Has_A_True_Inccorect_Size() =
    let scoreList = new TicTacToeBox (["@"; "2"; "3"; 
                    "@"; "X"; "-6-"; 
                    "@"; "-8-"; "-9-"])
    Assert.Equal(true, verticalTrurthValue scoreList "@" 999 999)

[<Fact>]   // test
let AI_Won_3X3_Row_No_Does_Have_Vertical_Victory() =
    let ticTacToeBox = new TicTacToeBox (["-1-"; "-2-"; "-3-"; "-4-"; "X"; "-6-"; "-7-"; "-8-"; "-9-"])
    Assert.Equal(false, hasVerticalWin ticTacToeBox gameTestCreate3X3.aIGlyph 0)

[<Fact>]   // test
let AI_Won_3X3_Row_First_Does_Have_Vertial_Victory() =
    let ticTacToeBox = new TicTacToeBox (["@"; "2"; "3"; 
                        "@"; "X"; "-6-"; 
                        "@"; "-8-"; "-9-"])
    Assert.Equal(true, hasVerticalWin ticTacToeBox gameTestCreate3X3.aIGlyph 0)

[<Fact>]   // test
let AI_Won_3X3_Row_Second_Does_Have_Vertial_Victory() =
    let ticTacToeBox = new TicTacToeBox (["-1-"; "@"; "3"; 
                        "-2-"; "@"; "-6-"; 
                        "-3-"; "@"; "-9-"])
    Assert.Equal(true, hasVerticalWin ticTacToeBox gameTestCreate3X3.aIGlyph 0)

[<Fact>]   // test
let AI_Won_3X3_Row_Thrid_Does_Have_Vertial_Victory() =
    let ticTacToeBox = new TicTacToeBox (["1"; "2"; "@"; 
                        "2"; "X"; "@"; 
                        "3"; "-8-"; "@"])
    Assert.Equal(true, hasVerticalWin ticTacToeBox gameTestCreate3X3.aIGlyph 0)

[<Fact>]
let Has_AI_Winner_No_Winner() =
    let ticTacToeBox = new TicTacToeBox (["-1-"; "-2-"; "-3-"; 
                        "-4-"; "-5-"; "-6-"; 
                        "-7-"; "-8-"; "-9-"])
    Assert.Equal(false, hasAiWinner ticTacToeBox gameTestCreate3X3.playerGlyph gameTestCreate3X3.aIGlyph)

[<Fact>]
let Has_AI_Winner_Diange() =
    let ticTacToeBox = new TicTacToeBox (["@"; "-2-"; "-3-"; 
                        "-4-"; "@"; "-6-"; 
                        "-7-"; "-8-"; "@"])
    Assert.Equal(true, hasAiWinner ticTacToeBox gameTestCreate3X3.playerGlyph gameTestCreate3X3.aIGlyph)

[<Fact>]
let Has_AI_Winner_Vertical() =
    let ticTacToeBox = new TicTacToeBox (["-1-"; "@"; "-3-"; 
                        "-4-"; "@"; "-6-"; 
                        "-7-"; "@"; "-9-"])
    Assert.Equal(true, hasAiWinner ticTacToeBox gameTestCreate3X3.playerGlyph gameTestCreate3X3.aIGlyph)

[<Fact>]
let Has_AI_Winner_Horzontal() =
    let ticTacToeBox = new TicTacToeBox (["@"; "@"; "@"; 
                        "-4-"; "X"; "-6-"; 
                        "-7-"; "-8-"; "-9-"])
    Assert.Equal(true, hasAiWinner ticTacToeBox gameTestCreate3X3.playerGlyph gameTestCreate3X3.aIGlyph)

[<Fact>]
let Has_Human_Winner_No_Winner() =
    let ticTacToeBox = new TicTacToeBox (["-1-"; "-2-"; "-3-"; 
                        "-4-"; "-5-"; "-6-"; 
                        "-7-"; "-8-"; "-9-"])
    Assert.Equal(false, hasHumanWinner ticTacToeBox gameTestCreate3X3.playerGlyph gameTestCreate3X3.aIGlyph)

[<Fact>]
let Has_Human_Winner_Diange() =
    let ticTacToeBox = new TicTacToeBox (["X"; "-2-"; "-3-"; 
                        "-4-"; "X"; "-6-"; 
                        "-7-"; "-8-"; "X"])
    Assert.Equal(true, hasHumanWinner ticTacToeBox gameTestCreate3X3.playerGlyph gameTestCreate3X3.aIGlyph)

[<Fact>]
let Has_Human_Winner_Vertical() =
    let ticTacToeBox = new TicTacToeBox (["-1-"; "X"; "-3-"; 
                        "-4-"; "X"; "-6-"; 
                        "-7-"; "X"; "-9-"])
    Assert.Equal(true, hasHumanWinner ticTacToeBox gameTestCreate3X3.playerGlyph gameTestCreate3X3.aIGlyph)

[<Fact>]
let Has_Human_Winner_Horzontal() =
    let ticTacToeBox = new TicTacToeBox (["X"; "X"; "X"; 
                        "-4-"; "@"; "-6-"; 
                        "-7-"; "-8-"; "-9-"])
    Assert.Equal(true, hasHumanWinner ticTacToeBox gameTestCreate3X3.playerGlyph gameTestCreate3X3.aIGlyph)


[<Fact>]
let Check_does_Have_Tie_Has_Tie() =
   let ticTacToeBox = new TicTacToeBox (["X"; "X"; "@"; "@"; "@"; "X"; "X"; "X"; "@"])
   Assert.Equal(true, doesHaveTie ticTacToeBox gameTestCreate3X3.playerGlyph gameTestCreate3X3.aIGlyph 0)

[<Fact>]
let Check_does_Have_Tie_Not_Have_Tie() =
   let ticTacToeBox = new TicTacToeBox (["-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"])
   Assert.Equal(false, doesHaveTie ticTacToeBox gameTestCreate3X3.playerGlyph gameTestCreate3X3.aIGlyph 0)

[<Fact>]   // test
let Check_If_AI_Won_4X4_Row_First() =
    let ticTacToeBox = new TicTacToeBox (["@"; "@"; "@"; "@"; 
                        "X"; "X"; "X"; "-8-"; 
                        "-9-"; "-10-"; "-11-"; "-12-";
                        "-13-"; "-14-"; "-15-"; "-16-"])
    let winningValue = int (getWinningAIValue(gameTestCreate4X4.ticTacToeBoxSize))
    Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate3X3.playerGlyph gameTestCreate3X3.aIGlyph)

[<Fact>]   // test
let Check_If_AI_Won_Row_4X4_Second() =
    let ticTacToeBox = new TicTacToeBox (["X"; "X"; "X"; "-4-"; 
                        "@"; "@"; "@"; "@"; 
                        "-9-"; "-10-"; "-11-"; "-12-";
                        "-13-"; "-14-"; "-15-"; "-16-"])
    let winningValue = int (getWinningAIValue(gameTestCreate4X4.ticTacToeBoxSize))
    Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate3X3.playerGlyph gameTestCreate3X3.aIGlyph)

[<Fact>]   // test
let Check_If_AI_Won_Row_4X4_Thrid() =
    let ticTacToeBox = new TicTacToeBox (["X"; "X"; "X"; "-4-"; 
                        "-5-"; "-6-"; "-7-"; "-8-"; 
                        "@"; "@"; "@"; "@";
                        "-13-"; "-14-"; "-15-"; "-16-"])
    let winningValue = int (getWinningAIValue(gameTestCreate4X4.ticTacToeBoxSize))
    Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate3X3.playerGlyph gameTestCreate3X3.aIGlyph)

[<Fact>]   // test
let Check_If_AI_Won_Row_4X4_Fourth() =
    let ticTacToeBox = new TicTacToeBox (["X"; "X"; "X"; "-4-"; 
                        "-5-"; "-6-"; "-7-"; "-8-"; 
                        "-9-"; "-10-"; "-11-"; "-12-";
                        "@"; "@"; "@"; "@"])
    let winningValue = int (getWinningAIValue(gameTestCreate4X4.ticTacToeBoxSize))
    Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate3X3.playerGlyph gameTestCreate3X3.aIGlyph)

[<Fact>]   // test
let Check_If_AI_Won_3X3_Row_First() =
    let ticTacToeBox = new TicTacToeBox (["@"; "@"; "@"; "-4-"; "X"; "-6-"; "-7-"; "-8-"; "-9-"])
    let winningValue = int (getWinningAIValue(gameTestCreate3X3.ticTacToeBoxSize))
    Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate3X3.playerGlyph gameTestCreate3X3.aIGlyph)

[<Fact>]   // test
let Check_If_AI_Won_Row_3X3_Second() =
    let ticTacToeBox = new TicTacToeBox (["-1-"; "-2-"; "-3-"; "@"; "@"; "@"; "-7-"; "-8-"; "-9-"])
    let winningValue = int (getWinningAIValue(gameTestCreate3X3.ticTacToeBoxSize))
    Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate3X3.playerGlyph gameTestCreate3X3.aIGlyph)

[<Fact>]   // test
let Check_If_AI_Won_Row_3X3_Thrid() =
    let ticTacToeBox = new TicTacToeBox (["-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "@"; "@"; "@"])
    let winningValue = int (getWinningAIValue(gameTestCreate3X3.ticTacToeBoxSize))
    Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate3X3.playerGlyph gameTestCreate3X3.aIGlyph)

[<Fact>]   // test
let Check_If_Human_Won_Row_3X3_First() =
    let ticTacToeBox = new TicTacToeBox (["X"; "X"; "X"; "-4-"; "@"; "-6-"; "-7-"; "-8-"; "-9-"])
    
    let winningValue = int (getWinningHumanValue(gameTestCreate3X3.ticTacToeBoxSize))
    Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate3X3.playerGlyph gameTestCreate3X3.aIGlyph)

[<Fact>]   // test
let Check_If_Human_Won_Row_3X3_Second() =
    let ticTacToeBox = new TicTacToeBox (["-1-"; "-2-"; "-3-"; "X"; "X"; "X"; "-7-"; "-8-"; "-9-"])
    let winningValue = int (getWinningHumanValue(gameTestCreate3X3.ticTacToeBoxSize))
    Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate3X3.playerGlyph gameTestCreate3X3.aIGlyph)

[<Fact>]   // test
let Check_If_Human_Won_Row_3X3_Thrid() =
    let ticTacToeBox = new TicTacToeBox (["-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "X"; "X"; "X"])
    let winningValue = int (getWinningHumanValue(gameTestCreate3X3.ticTacToeBoxSize))
    Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate3X3.playerGlyph gameTestCreate3X3.aIGlyph)

[<Fact>]   // test
let Check_If_AI_Won_3X3_Coulmn_One() =
    let ticTacToeBox = new TicTacToeBox (["@"; "-2-"; "-3-"; "@"; "-5-"; "-6-"; "@"; "-8-"; "-9-"])
    let winningValue = int (getWinningAIValue(gameTestCreate3X3.ticTacToeBoxSize))
    Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate3X3.playerGlyph gameTestCreate3X3.aIGlyph)

[<Fact>]   // test
let Check_If_AI_Won__3X3_Coulmn_Two() =
    let ticTacToeBox = new TicTacToeBox (["-1-"; "@"; "-3-"; "-4-"; "@"; "-6-"; "-7-"; "@"; "-9-"])
    let winningValue = int (getWinningAIValue(gameTestCreate3X3.ticTacToeBoxSize))
    Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate3X3.playerGlyph gameTestCreate3X3.aIGlyph)

[<Fact>]   // test
let Check_If_AI_Won_3X3_Coulmn_Three() =
    let ticTacToeBox = new TicTacToeBox (["-1-"; "-2-"; "@"; "-4-"; "-5-"; "@"; "-7-"; "-8-"; "@"])
    let winningValue = int (getWinningAIValue(gameTestCreate3X3.ticTacToeBoxSize))
    Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate3X3.playerGlyph gameTestCreate3X3.aIGlyph)

[<Fact>]   // test
let Check_If_AI_Won_4X4_Coulmn_One() =
    let ticTacToeBox = new TicTacToeBox (["@"; "-2-"; "-3-"; "-4-"; 
                        "@"; "-6-"; "-7-"; "-8-"; 
                        "@"; "-10-"; "-11-"; "-12-";
                        "@"; "-14-"; "-15-"; "-16-"])
    let winningValue = int (getWinningAIValue(gameTestCreate4X4.ticTacToeBoxSize))
    Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate3X3.playerGlyph gameTestCreate3X3.aIGlyph)

[<Fact>]   // test
let Check_If_AI_Won_4X4_Coulmn_Two() =
    let ticTacToeBox = new TicTacToeBox (["-1-"; "@"; "-3-"; "-4-"; 
                        "-5-"; "@"; "-7-"; "-8-"; 
                        "-9-"; "@"; "-11-"; "-12-";
                        "-13-"; "@"; "-15-"; "-16-"])
    let winningValue = int (getWinningAIValue(gameTestCreate4X4.ticTacToeBoxSize))
    Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate3X3.playerGlyph gameTestCreate3X3.aIGlyph)

[<Fact>]   // test
let Check_If_AI_Won_4X4_Coulmn_Three() =
    let ticTacToeBox = new TicTacToeBox (["-1-"; "-2-"; "@"; "-4-"; 
                        "-5-"; "-6-"; "@"; "-8-"; 
                        "-9-"; "-10-"; "@"; "-12-";
                        "-13-"; "-14-"; "@"; "-16-"])
    let winningValue = int (getWinningAIValue(gameTestCreate4X4.ticTacToeBoxSize))
    Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate3X3.playerGlyph gameTestCreate3X3.aIGlyph)

[<Fact>]   // test
let Check_If_AI_Won_4X4_Coulmn_Four() =
    let ticTacToeBox = new TicTacToeBox (["-1-"; "-2-"; "-3-"; "@"; 
                        "-5-"; "-6-"; "-7-"; "@"; 
                        "-9-"; "-10-"; "-11-"; "@";
                        "-13-"; "-14-"; "-15-"; "@"])
    let winningValue = int (getWinningAIValue(gameTestCreate4X4.ticTacToeBoxSize))
    Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate3X3.playerGlyph gameTestCreate3X3.aIGlyph)

[<Fact>]   // test
let Check_If_Human_Won_3X3_Coulmn_One() =
    let ticTacToeBox = new TicTacToeBox (["X"; "-2-"; "-3-"; "X"; "-5-"; "-6-"; "X"; "-8-"; "-9-"])
    let winningValue = int (getWinningHumanValue(gameTestCreate3X3.ticTacToeBoxSize))
    Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate3X3.playerGlyph gameTestCreate3X3.aIGlyph)

[<Fact>]   // test
let Check_If_Human_Won_3X3_Coulmn_Two() =
    let ticTacToeBox = new TicTacToeBox (["-1-"; "X"; "-3-"; "-4-"; "X"; "-6-"; "-7-"; "X"; "-9-"])
    let winningValue = int (getWinningHumanValue(gameTestCreate3X3.ticTacToeBoxSize))
    Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate3X3.playerGlyph gameTestCreate3X3.aIGlyph)

[<Fact>]   // test
let Check_If_Human_Won_3X3_Coulmn_Three() =
    let ticTacToeBox = new TicTacToeBox (["-1-"; "-2-"; "X"; "-4-"; "-5-"; "X"; "-7-"; "-8-"; "X"])
    let winningValue = int (getWinningHumanValue(gameTestCreate3X3.ticTacToeBoxSize))
    Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate3X3.playerGlyph gameTestCreate3X3.aIGlyph)

[<Fact>]   // test
let Check_If_Ai_Won_Right_3X3_Diangle() =
    let ticTacToeBox = new TicTacToeBox (["@"; "-2-"; "-3-"; "-4-"; "@"; "-6-"; "-7-"; "-8-"; "@"])
    let winningValue = int (getWinningAIValue(gameTestCreate3X3.ticTacToeBoxSize))
    Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate3X3.playerGlyph gameTestCreate3X3.aIGlyph)

[<Fact>]   // test
let Check_If_Ai_Won_Left_3X3_Diangle() =
   let ticTacToeBox = new TicTacToeBox (["-1-"; "-2-"; "@"; "-4-"; "@"; "-6-"; "@"; "-8-"; "-9-"])
   let winningValue = int (getWinningAIValue(gameTestCreate3X3.ticTacToeBoxSize))
   Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate3X3.playerGlyph gameTestCreate3X3.aIGlyph)

[<Fact>]   // test
let Check_If_Ai_Won_Right_4X4_Diangle() =
    let ticTacToeBox = new TicTacToeBox (["@"; "-2-"; "-3-"; "-4-"; 
                        "-5-"; "@"; "-4-"; "-8-"; 
                        "-9-"; "-10-"; "@"; "-12-";
                        "-13-"; "-14-"; "-15-"; "@"])
    let winningValue = int (getWinningAIValue(gameTestCreate4X4.ticTacToeBoxSize))
    Assert.Equal(winningValue,checkForWinnerOrTie ticTacToeBox gameTestCreate3X3.playerGlyph gameTestCreate3X3.aIGlyph)

[<Fact>]   // test
let Check_If_Ai_Won_Left_4X4_Diangle() =
   let ticTacToeBox = new TicTacToeBox (["-1-"; "-2-"; "-3-"; "@"; 
                        "-5-"; "-6-"; "@"; "-8-"; 
                        "-9-"; "@"; "-11-"; "-12-";
                        "@"; "-14-"; "-15-"; "-16-"])
   let winningValue = int (getWinningAIValue(gameTestCreate4X4.ticTacToeBoxSize))
   Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate3X3.playerGlyph gameTestCreate3X3.aIGlyph)

[<Fact>]   // test
let Check_If_Human_Won_Right_3X3_Diangle() =
    let ticTacToeBox = new TicTacToeBox (["X"; "-2-"; "-3-"; "-4-"; "X"; "-6-"; "-7-"; "-8-"; "X"])
    let winningValue = int (getWinningHumanValue(gameTestCreate3X3.ticTacToeBoxSize))
    Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate3X3.playerGlyph gameTestCreate3X3.aIGlyph)

[<Fact>]   // test
let Check_If_Human_Won_Left_3X3_Diangle() =
   let ticTacToeBox = new TicTacToeBox (["-1-"; "-2-"; "X"; "-4-"; "X"; "-6-"; "X"; "-8-"; "-9-"])
   let winningValue = int (getWinningHumanValue(gameTestCreate3X3.ticTacToeBoxSize))
   Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate3X3.playerGlyph gameTestCreate3X3.aIGlyph)

[<Fact>]   // test
let Check_If_Tie_3X3() =
   let ticTacToeBox = new TicTacToeBox (["X"; "X"; "@"; "@"; "@"; "X"; "X"; "X"; "@"])
   Assert.Equal(int GenResult.Tie, checkForWinnerOrTie ticTacToeBox gameTestCreate3X3.playerGlyph gameTestCreate3X3.aIGlyph)

[<Fact>]   // test
let Check_If_Tie_4X4() =
   let ticTacToeBox = new TicTacToeBox (["@"; "X"; "@"; "@"; 
                        "X"; "X"; "@"; "@"; 
                        "@"; "X"; "X"; "X";
                        "@"; "@"; "@"; "X"])
   Assert.Equal(int GenResult.Tie, checkForWinnerOrTie ticTacToeBox gameTestCreate3X3.playerGlyph gameTestCreate3X3.aIGlyph)