module TranslatorTestEnglish
open Translator
open Translate
open Xunit
open FsUnit

[<Fact>]
let Tranlate_Input_To_English() =
    Assert.Equal("Input: ", translator language.english Input)

[<Fact>]
let Tranlate_Other_Player_Won_To_English() =
    Assert.Equal("Other Player Won", translator language.english Other_Player_Won)

[<Fact>]
let Tranlate_Player_Won_En_To_English() =
    Assert.Equal("Player Won", translator language.english Player_Won)

[<Fact>]
let Tranlate_Tie_To_English() =
    Assert.Equal("Tie", translator language.english Tie)

[<Fact>]
let Tranlate_Value_Not_A_Number_To_English() =
    Assert.Equal("Value not a number", translator language.english Value_Not_A_Number)

[<Fact>]
let Tranlate_Value_Out_Of_Bounds_To_English() =
    Assert.Equal("Value out of bounds", translator language.english Value_Out_Of_Bounds)

[<Fact>]
let Tranlate_Spot_Taken_To_English() =
    Assert.Equal("Spot Taken", translator language.english Spot_Taken)

[<Fact>]
let Tranlate_What_Glyph_Would_You_Like_Other_Player_To_English() =
    Assert.Equal("What glyph would you like for the other player?", translator language.english What_Glyph_Would_You_Like_Other_Player)

[<Fact>]
let Tranlate_Glyph_Must_Differ_To_English() =
    Assert.Equal("glyph must differ", translator language.english Glyph_Must_Differ)

[<Fact>]
let Tranlate_Length_Must_Be_One_To_English() =
    Assert.Equal("Length Must be one", translator language.english Length_Must_Be_One)

[<Fact>]
let Tranlate_What_Glyph_Would_You_For_One_AI_Players_To_English() =
    Assert.Equal("What glyph would you like for one of the AI players?", translator language.english What_Glyph_Would_You_For_One_AI_Players)

[<Fact>]
let Tranlate_What_Glyph_Would_You_Like_To_English() =
    Assert.Equal("What glyph would you like?", translator language.english What_Glyph_Would_You_Like)

[<Fact>]
let Tranlate_Would_You_Like_To_Play_On_A_3x3_Or_4x4_Board_To_English() =
    Assert.Equal("Would you like to play on a 3x3 or 4x4 Board?", translator language.english Would_You_Like_To_Play_On_A_3x3_Or_4x4_Board)

[<Fact>]
let Tranlate_Invaild_Box_Size_3_Or_4_To_English() =
    Assert.Equal("Invaild Box Size, Enter 3 or 4", translator language.english Invaild_Box_Size_3_Or_4)

[<Fact>]
let Tranlate_Would_You_Like_Human_Vs_Human_To_English() =
    Assert.Equal("Would you like human vs human?", translator language.english Would_You_Like_Human_Vs_Human)

[<Fact>]
let Tranlate_Y_N_To_English() =
    Assert.Equal("Y/N", translator language.english Y_N)

[<Fact>]
let Tranlate_Y_To_English() =
    Assert.Equal("Y", translator language.english Y)

[<Fact>]
let Tranlate_Must_Be_A_Y_Or_N_To_English() =
    Assert.Equal("Must be a Y or N", translator language.english Must_Be_A_Y_Or_N)

[<Fact>]
let Tranlate_Would_You_Like_To_The_Game_Inverted_To_English() =
    Assert.Equal("Would you like to have the game Inverted? ", translator language.english Would_You_Like_To_The_Game_Inverted)

[<Fact>]
let Tranlate_Would_You_Like_AI_VS_AI_To_English() =
    Assert.Equal("Would you like AI VS AI?", translator language.english Would_You_Like_AI_VS_AI)

[<Fact>]
let Tranlate_Would_You_Like_To_Go_First_To_English() =
    Assert.Equal("Would you like to go first?", translator language.english Would_You_Like_To_Go_First)

[<Fact>]
let Tranlate_Other_Player_Is_Going_First_To_English() =
    Assert.Equal("Other Player is going first", translator language.english Other_Player_Is_Going_First)

[<Fact>]
let Tranlate_AI_Is_Playing_To_English() =
    Assert.Equal("AI is playing", translator language.english AI_Is_Playing)

[<Fact>]
let Tranlate_Your_Going_First_To_English() =
    Assert.Equal("Your going first", translator language.english Your_Going_First)

[<Fact>]
let Tranlate_Human_Vs_Human_To_English() =
    Assert.Equal("Human Vs Human", translator language.english Human_Vs_Human)

[<Fact>]
let Tranlate_AI_vs_AI_To_English() =
    Assert.Equal("AI vs AI" , translator language.english AI_vs_AI)

[<Fact>]
let Tranlate_Human_Vs_AI_To_English() =
    Assert.Equal("Human Vs AI" , translator language.english Human_Vs_AI)

[<Fact>]
let Tranlate_Here_Are_Your_Current_Settings_To_English() =
    Assert.Equal("Here are your current Settings" , translator language.english Here_Are_Your_Current_Settings)

[<Fact>]
let Tranlate_Current_Board_Size_Is_To_English() =
    Assert.Equal("Current Board Size is: " , translator language.english Current_Board_Size_Is)

[<Fact>]
let Tranlate_Player_Glyph_To_English() =
    Assert.Equal("Player Glyph: " , translator language.english Player_Glyph)

[<Fact>]
let Tranlate_Other_Player_Glyph_To_English() =
    Assert.Equal("Other Player Glyph: " , translator language.english Other_Player_Glyph)

[<Fact>]
let Tranlate_Game_Inverted_To_English() =
    Assert.Equal("Game Inverted: " , translator language.english Game_Inverted)

[<Fact>]
let Tranlate_Are_These_The_Setting_You_Want_To_English() =
    Assert.Equal("Are These the setting you want?" , translator language.english Are_These_The_Setting_You_Want)

[<Fact>]
let Tranlate_Another_Game_Y_N_To_English() =
    Assert.Equal("Another Game? Y/N: " , translator language.english Another_Game_Y_N)

[<Fact>]
let Tranlate_Same_Settings_Y_N_To_English() =
    Assert.Equal("Same Settings? Y/N: " , translator language.english Same_Settings_Y_N)

[<Fact>]
let Tranlate_Board_Size_3X3_To_English() =
    Assert.Equal("3X3" , translator language.english Board_Size_3X3)

[<Fact>]
let Tranlate_Board_Size_4X4_To_English() =
    Assert.Equal("4X4" , translator language.english Board_Size_4X4)

[<Fact>]
let Tranlate_No_Translation_To_English() =
    Assert.Equal("No Translation" , translator language.english 999)

[<Fact>]
let Tranlate_Blank_To_English() =
    Assert.Equal("" , translator language.english Blank)
