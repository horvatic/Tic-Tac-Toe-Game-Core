module Translator
open Translate
open English
open Spanish

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

let translatorSpanish(wordToTranslate : int) : string =
    match wordToTranslate with
    | Input -> Input_Sp
    | Other_Player_Won -> Other_Player_Won_Sp
    | Player_Won -> Player_Won_Sp 
    | Tie -> Tie_Sp
    | Value_Not_A_Number -> Value_Not_A_Number_Sp
    | Value_Out_Of_Bounds -> Value_Out_Of_Bounds_Sp
    | Spot_Taken -> Spot_Taken_Sp
    | What_Glyph_Would_You_Like_Other_Player -> What_Glyph_Would_You_Like_Other_Player_Sp
    | Glyph_Must_Differ -> Glyph_Must_Differ_Sp
    | Length_Must_Be_One -> Length_Must_Be_One_Sp
    | What_Glyph_Would_You_For_One_AI_Players -> What_Glyph_Would_You_For_One_AI_Players_Sp
    | What_Glyph_Would_You_Like -> What_Glyph_Would_You_Like_Sp
    | Would_You_Like_To_Play_On_A_3x3_Or_4x4_Board -> Would_You_Like_To_Play_On_A_3x3_Or_4x4_Board_Sp
    | Invaild_Box_Size_3_Or_4 -> Invaild_Box_Size_3_Or_4_Sp
    | Would_You_Like_Human_Vs_Human -> Would_You_Like_Human_Vs_Human_Sp
    | Y_N -> Y_N_Sp
    | Y -> Y_Sp
    | Must_Be_A_Y_Or_N -> Must_Be_A_Y_Or_N_Sp
    | Would_You_Like_To_The_Game_Inverted -> Would_You_Like_To_The_Game_Inverted_Sp
    | Would_You_Like_AI_VS_AI -> Would_You_Like_AI_VS_AI_Sp
    | Would_You_Like_To_Go_First -> Would_You_Like_To_Go_First_Sp
    | Other_Player_Is_Going_First -> Other_Player_Is_Going_First_Sp
    | AI_Is_Playing -> AI_Is_Playing_Sp
    | Your_Going_First -> Your_Going_First_Sp
    | Human_Vs_Human -> Human_Vs_Human_Sp
    | AI_vs_AI -> AI_vs_AI_Sp
    | Human_Vs_AI -> Human_Vs_AI_Sp
    | Here_Are_Your_Current_Settings -> Here_Are_Your_Current_Settings_Sp
    | Current_Board_Size_Is -> Current_Board_Size_Is_Sp
    | Player_Glyph -> Player_Glyph_Sp
    | Other_Player_Glyph -> Other_Player_Glyph_Sp
    | Game_Inverted -> Game_Inverted_Sp
    | Are_These_The_Setting_You_Want -> Are_These_The_Setting_You_Want_Sp
    | Another_Game_Y_N -> Another_Game_Y_N_Sp
    | Same_Settings_Y_N -> Same_Settings_Y_N_Sp
    | Board_Size_3X3 -> Board_Size_3X3_Sp
    | Board_Size_4X4 -> Board_Size_4X4_Sp
    | Blank -> ""
    | True_Word -> True_Word_Sp
    | False_Word -> False_Word_Sp
    | _ -> "Sin traducción"

let translator(currentLanguage : language)(wordToTranslate : int) : string =
    if currentLanguage = language.english then
        translatorEnglish(wordToTranslate)
    else
        translatorSpanish(wordToTranslate)
