namespace TicTacToe.Core 
module Translator =
    open Translate
    open English

    type language =
        | english = 1
        | spanish = 2

    let translatorEnglish(wordToTranslate : int) : string =
        match wordToTranslate with
        | Input -> Input_En
        | Other_Player_Won -> Other_Player_Won_En
        | Player_Won -> Player_Won_En 
        | Tie -> Tie_En
        | Value_Not_A_Number -> Value_Not_A_Number_En
        | Value_Out_Of_Bounds -> Value_Out_Of_Bounds_En
        | Spot_Taken -> Spot_Taken_En
        | What_Glyph_Would_You_Like_Other_Player -> What_Glyph_Would_You_Like_Other_Player_En
        | Glyph_Must_Differ -> Glyph_Must_Differ_En
        | Length_Must_Be_One -> Length_Must_Be_One_En
        | What_Glyph_Would_You_For_One_AI_Players -> What_Glyph_Would_You_For_One_AI_Players_En
        | What_Glyph_Would_You_Like -> What_Glyph_Would_You_Like_En
        | Would_You_Like_To_Play_On_A_3x3_Or_4x4_Board -> Would_You_Like_To_Play_On_A_3x3_Or_4x4_Board_En
        | Invaild_Box_Size_3_Or_4 -> Invaild_Box_Size_3_Or_4_En
        | Would_You_Like_Human_Vs_Human -> Would_You_Like_Human_Vs_Human_En
        | Y_N -> Y_N_En
        | Y -> Y_En
        | Must_Be_A_Y_Or_N -> Must_Be_A_Y_Or_N_En
        | Would_You_Like_To_The_Game_Inverted -> Would_You_Like_To_The_Game_Inverted_En
        | Would_You_Like_AI_VS_AI -> Would_You_Like_AI_VS_AI_En
        | Would_You_Like_To_Go_First -> Would_You_Like_To_Go_First_En
        | Other_Player_Is_Going_First -> Other_Player_Is_Going_First_En
        | AI_Is_Playing -> AI_Is_Playing_En
        | Your_Going_First -> Your_Going_First_En
        | Human_Vs_Human -> Human_Vs_Human_En
        | AI_vs_AI -> AI_vs_AI_En
        | Human_Vs_AI -> Human_Vs_AI_En
        | Here_Are_Your_Current_Settings -> Here_Are_Your_Current_Settings_En
        | Current_Board_Size_Is -> Current_Board_Size_Is_En
        | Player_Glyph -> Player_Glyph_En
        | Other_Player_Glyph -> Other_Player_Glyph_En
        | Game_Inverted -> Game_Inverted_En
        | Are_These_The_Setting_You_Want -> Are_These_The_Setting_You_Want_En
        | Another_Game_Y_N -> Another_Game_Y_N_En
        | Same_Settings_Y_N -> Same_Settings_Y_N_En
        | Board_Size_3X3 -> Board_Size_3X3_En
        | Board_Size_4X4 -> Board_Size_4X4_En
        | Blank -> ""
        | True_Word -> True_Word_En
        | False_Word -> False_Word_En
        | _ -> "No Translation"

    let translator(currentLanguage : language)(wordToTranslate : int) : string =
            translatorEnglish(wordToTranslate)
