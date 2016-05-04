module CheckForWinnerOrTieTest
open Xunit 
open FsUnit
open CheckForWinnerOrTie
open GameStatusCodes
open GameSettings
open PlayerValues

let gameTestCreate = craftGameSetting ([|"-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"|]) 
                                          ("X") ("@") (int playerVals.Human)(false)(false)(false)

[<Fact>]   // test
let Check_3X3_Box_Legnth_Is_3() =
    let ticTacToeBox = [|"@"; "@"; "@"; "-4-"; "X"; "-6-"; "-7-"; "-8-"; "-9-"|]
    Assert.Equal(3, findBoxLength ticTacToeBox)

[<Fact>]   // test
let Check_4X4_Box_Legnth_Is_4() =
    let ticTacToeBox = [|"@"; "@"; "@"; "@"; 
                        "X"; "X"; "X"; "-8-"; 
                        "-9-"; "-10-"; "-11-"; "-12-";
                        "-13-"; "-14-"; "-15-"; "-16-"|]
    Assert.Equal(4, findBoxLength ticTacToeBox)

[<Fact>]   // test
let Check_If_AI_Won_4X4_Row_First() =
    let ticTacToeBox = [|"@"; "@"; "@"; "@"; 
                        "X"; "X"; "X"; "-8-"; 
                        "-9-"; "-10-"; "-11-"; "-12-";
                        "-13-"; "-14-"; "-15-"; "-16-"|]
    let winningValue = int (getWinningAIValue(ticTacToeBox))
    Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate.playerGlyph gameTestCreate.aIGlyph)

[<Fact>]   // test
let Check_If_AI_Won_Row_4X4_Second() =
    let ticTacToeBox = [|"X"; "X"; "X"; "-4-"; 
                        "@"; "@"; "@"; "@"; 
                        "-9-"; "-10-"; "-11-"; "-12-";
                        "-13-"; "-14-"; "-15-"; "-16-"|]
    let winningValue = int (getWinningAIValue(ticTacToeBox))
    Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate.playerGlyph gameTestCreate.aIGlyph)

[<Fact>]   // test
let Check_If_AI_Won_Row_4X4_Thrid() =
    let ticTacToeBox = [|"X"; "X"; "X"; "-4-"; 
                        "-5-"; "-6-"; "-7-"; "-8-"; 
                        "@"; "@"; "@"; "@";
                        "-13-"; "-14-"; "-15-"; "-16-"|]
    let winningValue = int (getWinningAIValue(ticTacToeBox))
    Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate.playerGlyph gameTestCreate.aIGlyph)

[<Fact>]   // test
let Check_If_AI_Won_Row_4X4_Fourth() =
    let ticTacToeBox = [|"X"; "X"; "X"; "-4-"; 
                        "-5-"; "-6-"; "-7-"; "-8-"; 
                        "-9-"; "-10-"; "-11-"; "-12-";
                        "@"; "@"; "@"; "@"|]
    let winningValue = int (getWinningAIValue(ticTacToeBox))
    Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate.playerGlyph gameTestCreate.aIGlyph)

[<Fact>]   // test
let Check_If_AI_Won_3X3_Row_First() =
    let ticTacToeBox = [|"@"; "@"; "@"; "-4-"; "X"; "-6-"; "-7-"; "-8-"; "-9-"|]
    let winningValue = int (getWinningAIValue(ticTacToeBox))
    Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate.playerGlyph gameTestCreate.aIGlyph)

[<Fact>]   // test
let Check_If_AI_Won_Row_3X3_Second() =
    let ticTacToeBox = [|"-1-"; "-2-"; "-3-"; "@"; "@"; "@"; "-7-"; "-8-"; "-9-"|]
    let winningValue = int (getWinningAIValue(ticTacToeBox))
    Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate.playerGlyph gameTestCreate.aIGlyph)

[<Fact>]   // test
let Check_If_AI_Won_Row_3X3_Thrid() =
    let ticTacToeBox = [|"-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "@"; "@"; "@"|]
    let winningValue = int (getWinningAIValue(ticTacToeBox))
    Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate.playerGlyph gameTestCreate.aIGlyph)

[<Fact>]   // test
let Check_If_Human_Won_Row_3X3_First() =
    let ticTacToeBox = [|"X"; "X"; "X"; "-4-"; "@"; "-6-"; "-7-"; "-8-"; "-9-"|]
    
    let winningValue = int (getWinningHumanValue(ticTacToeBox))
    Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate.playerGlyph gameTestCreate.aIGlyph)

[<Fact>]   // test
let Check_If_Human_Won_Row_3X3_Second() =
    let ticTacToeBox = [|"-1-"; "-2-"; "-3-"; "X"; "X"; "X"; "-7-"; "-8-"; "-9-"|]
    let winningValue = int (getWinningHumanValue(ticTacToeBox))
    Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate.playerGlyph gameTestCreate.aIGlyph)

[<Fact>]   // test
let Check_If_Human_Won_Row_3X3_Thrid() =
    let ticTacToeBox = [|"-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "X"; "X"; "X"|]
    let winningValue = int (getWinningHumanValue(ticTacToeBox))
    Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate.playerGlyph gameTestCreate.aIGlyph)

[<Fact>]   // test
let Check_If_AI_Won_3X3_Coulmn_One() =
    let ticTacToeBox = [|"@"; "-2-"; "-3-"; "@"; "-5-"; "-6-"; "@"; "-8-"; "-9-"|]
    let winningValue = int (getWinningAIValue(ticTacToeBox))
    Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate.playerGlyph gameTestCreate.aIGlyph)

[<Fact>]   // test
let Check_If_AI_Won__3X3_Coulmn_Two() =
    let ticTacToeBox = [|"-1-"; "@"; "-3-"; "-4-"; "@"; "-6-"; "-7-"; "@"; "-9-"|]
    let winningValue = int (getWinningAIValue(ticTacToeBox))
    Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate.playerGlyph gameTestCreate.aIGlyph)

[<Fact>]   // test
let Check_If_AI_Won_3X3_Coulmn_Three() =
    let ticTacToeBox = [|"-1-"; "-2-"; "@"; "-4-"; "-5-"; "@"; "-7-"; "-8-"; "@"|]
    let winningValue = int (getWinningAIValue(ticTacToeBox))
    Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate.playerGlyph gameTestCreate.aIGlyph)

[<Fact>]   // test
let Check_If_AI_Won_4X4_Coulmn_One() =
    let ticTacToeBox = [|"@"; "-2-"; "-3-"; "-4-"; 
                        "@"; "-6-"; "-7-"; "-8-"; 
                        "@"; "-10-"; "-11-"; "-12-";
                        "@"; "-14-"; "-15-"; "-16-"|]
    let winningValue = int (getWinningAIValue(ticTacToeBox))
    Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate.playerGlyph gameTestCreate.aIGlyph)

[<Fact>]   // test
let Check_If_AI_Won_4X4_Coulmn_Two() =
    let ticTacToeBox = [|"-1-"; "@"; "-3-"; "-4-"; 
                        "-5-"; "@"; "-7-"; "-8-"; 
                        "-9-"; "@"; "-11-"; "-12-";
                        "-13-"; "@"; "-15-"; "-16-"|]
    let winningValue = int (getWinningAIValue(ticTacToeBox))
    Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate.playerGlyph gameTestCreate.aIGlyph)

[<Fact>]   // test
let Check_If_AI_Won_4X4_Coulmn_Three() =
    let ticTacToeBox = [|"-1-"; "-2-"; "@"; "-4-"; 
                        "-5-"; "-6-"; "@"; "-8-"; 
                        "-9-"; "-10-"; "@"; "-12-";
                        "-13-"; "-14-"; "@"; "-16-"|]
    let winningValue = int (getWinningAIValue(ticTacToeBox))
    Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate.playerGlyph gameTestCreate.aIGlyph)

[<Fact>]   // test
let Check_If_AI_Won_4X4_Coulmn_Four() =
    let ticTacToeBox = [|"-1-"; "-2-"; "-3-"; "@"; 
                        "-5-"; "-6-"; "-7-"; "@"; 
                        "-9-"; "-10-"; "-11-"; "@";
                        "-13-"; "-14-"; "-15-"; "@"|]
    let winningValue = int (getWinningAIValue(ticTacToeBox))
    Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate.playerGlyph gameTestCreate.aIGlyph)

[<Fact>]   // test
let Check_If_Human_Won_3X3_Coulmn_One() =
    let ticTacToeBox = [|"X"; "-2-"; "-3-"; "X"; "-5-"; "-6-"; "X"; "-8-"; "-9-"|]
    let winningValue = int (getWinningHumanValue(ticTacToeBox))
    Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate.playerGlyph gameTestCreate.aIGlyph)

[<Fact>]   // test
let Check_If_Human_Won_3X3_Coulmn_Two() =
    let ticTacToeBox = [|"-1-"; "X"; "-3-"; "-4-"; "X"; "-6-"; "-7-"; "X"; "-9-"|]
    let winningValue = int (getWinningHumanValue(ticTacToeBox))
    Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate.playerGlyph gameTestCreate.aIGlyph)

[<Fact>]   // test
let Check_If_Human_Won_3X3_Coulmn_Three() =
    let ticTacToeBox = [|"-1-"; "-2-"; "X"; "-4-"; "-5-"; "X"; "-7-"; "-8-"; "X"|]
    let winningValue = int (getWinningHumanValue(ticTacToeBox))
    Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate.playerGlyph gameTestCreate.aIGlyph)

[<Fact>]   // test
let Check_If_Ai_Won_Right_3X3_Diangle() =
    let ticTacToeBox = [|"@"; "-2-"; "-3-"; "-4-"; "@"; "-6-"; "-7-"; "-8-"; "@"|]
    let winningValue = int (getWinningAIValue(ticTacToeBox))
    Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate.playerGlyph gameTestCreate.aIGlyph)

[<Fact>]   // test
let Check_If_Ai_Won_Left_3X3_Diangle() =
   let ticTacToeBox = [|"-1-"; "-2-"; "@"; "-4-"; "@"; "-6-"; "@"; "-8-"; "-9-"|]
   let winningValue = int (getWinningAIValue(ticTacToeBox))
   Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate.playerGlyph gameTestCreate.aIGlyph)

[<Fact>]   // test
let Check_If_Ai_Won_Right_4X4_Diangle() =
    let ticTacToeBox = [|"@"; "-2-"; "-3-"; "-4-"; 
                        "-5-"; "@"; "-4-"; "-8-"; 
                        "-9-"; "-10-"; "@"; "-12-";
                        "-13-"; "-14-"; "-15-"; "@"|]
    let winningValue = int (getWinningAIValue(ticTacToeBox))
    Assert.Equal(winningValue,checkForWinnerOrTie ticTacToeBox gameTestCreate.playerGlyph gameTestCreate.aIGlyph)

[<Fact>]   // test
let Check_If_Ai_Won_Left_4X4_Diangle() =
   let ticTacToeBox = [|"-1-"; "-2-"; "-3-"; "@"; 
                        "-5-"; "-6-"; "@"; "-8-"; 
                        "-9-"; "@"; "-11-"; "-12-";
                        "@"; "-14-"; "-15-"; "-16-"|]
   let winningValue = int (getWinningAIValue(ticTacToeBox))
   Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate.playerGlyph gameTestCreate.aIGlyph)

[<Fact>]   // test
let Check_If_Human_Won_Right_3X3_Diangle() =
    let ticTacToeBox = [|"X"; "-2-"; "-3-"; "-4-"; "X"; "-6-"; "-7-"; "-8-"; "X"|]
    let winningValue = int (getWinningHumanValue(ticTacToeBox))
    Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate.playerGlyph gameTestCreate.aIGlyph)

[<Fact>]   // test
let Check_If_Human_Won_Left_3X3_Diangle() =
   let ticTacToeBox = [|"-1-"; "-2-"; "X"; "-4-"; "X"; "-6-"; "X"; "-8-"; "-9-"|]
   let winningValue = int (getWinningHumanValue(ticTacToeBox))
   Assert.Equal(winningValue, checkForWinnerOrTie ticTacToeBox gameTestCreate.playerGlyph gameTestCreate.aIGlyph)

[<Fact>]   // test
let Check_If_Tie_3X3() =
   let ticTacToeBox = [|"X"; "X"; "@"; "@"; "@"; "X"; "X"; "X"; "@"|]
   Assert.Equal(int GenResult.Tie, checkForWinnerOrTie ticTacToeBox gameTestCreate.playerGlyph gameTestCreate.aIGlyph)

[<Fact>]   // test
let Check_If_Tie_4X4() =
   let ticTacToeBox = [|"@"; "X"; "@"; "@"; 
                        "X"; "X"; "@"; "@"; 
                        "@"; "X"; "X"; "X";
                        "@"; "@"; "@"; "X"|]
   Assert.Equal(int GenResult.Tie, checkForWinnerOrTie ticTacToeBox gameTestCreate.playerGlyph gameTestCreate.aIGlyph)