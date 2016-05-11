module TranslatorTestSpanish

open Translator
open Translate
open Xunit
open FsUnit

[<Fact>]
let Tranlate_Input_To_Spanish() =
    Assert.Equal("Entrada: ", translator language.spanish Input)

[<Fact>]
let Tranlate_Other_Player_Won_To_Spanish() =
    Assert.Equal("Otro jugador Won", translator language.spanish Other_Player_Won)

[<Fact>]
let Tranlate_Player_Won_En_To_Spanish() =
    Assert.Equal("jugador ganó", translator language.spanish Player_Won)

[<Fact>]
let Tranlate_Tie_To_Spanish() =
    Assert.Equal("Corbata", translator language.spanish Tie)

[<Fact>]
let Tranlate_Value_Not_A_Number_To_Spanish() =
    Assert.Equal("Valor no es un número", translator language.spanish Value_Not_A_Number)

[<Fact>]
let Tranlate_Value_Out_Of_Bounds_To_Spanish() =
    Assert.Equal("Valor fuera de los límites", translator language.spanish Value_Out_Of_Bounds)

[<Fact>]
let Tranlate_Spot_Taken_To_Spanish() =
    Assert.Equal("Tomado punto", translator language.spanish Spot_Taken)

[<Fact>]
let Tranlate_What_Glyph_Would_You_Like_Other_Player_To_Spanish() =
    Assert.Equal("¿Qué le gustaría glifo para el otro jugador?", translator language.spanish What_Glyph_Would_You_Like_Other_Player)

[<Fact>]
let Tranlate_Glyph_Must_Differ_To_Spanish() =
    Assert.Equal("glifo debe diferir", translator language.spanish Glyph_Must_Differ)

[<Fact>]
let Tranlate_Length_Must_Be_One_To_Spanish() =
    Assert.Equal("La longitud debe ser uno", translator language.spanish Length_Must_Be_One)

[<Fact>]
let Tranlate_What_Glyph_Would_You_For_One_AI_Players_To_Spanish() =
    Assert.Equal("¿Qué le gustaría glifo para uno de los jugadores de la IA ?", translator language.spanish What_Glyph_Would_You_For_One_AI_Players)

[<Fact>]
let Tranlate_What_Glyph_Would_You_Like_To_Spanish() =
    Assert.Equal("¿Lo glifo le gustaría?", translator language.spanish What_Glyph_Would_You_Like)

[<Fact>]
let Tranlate_Would_You_Like_To_Play_On_A_3x3_Or_4x4_Board_To_Spanish() =
    Assert.Equal("¿Le gustaría jugar en un tablero de 3x3 o 4x4?", translator language.spanish Would_You_Like_To_Play_On_A_3x3_Or_4x4_Board)

[<Fact>]
let Tranlate_Invaild_Box_Size_3_Or_4_To_Spanish() =
    Assert.Equal("Invaild Tamaño de la caja , Entrar 3 ó 4", translator language.spanish Invaild_Box_Size_3_Or_4)

[<Fact>]
let Tranlate_Would_You_Like_Human_Vs_Human_To_Spanish() =
    Assert.Equal("¿Le gustaría ser humano vs humano?", translator language.spanish Would_You_Like_Human_Vs_Human)

[<Fact>]
let Tranlate_Y_N_To_Spanish() =
    Assert.Equal("S/N", translator language.spanish Y_N)

[<Fact>]
let Tranlate_Y_To_Spanish() =
    Assert.Equal("S", translator language.spanish Y)

[<Fact>]
let Tranlate_Must_Be_A_Y_Or_N_To_Spanish() =
    Assert.Equal("Debe ser un S o N", translator language.spanish Must_Be_A_Y_Or_N)

[<Fact>]
let Tranlate_Would_You_Like_To_The_Game_Inverted_To_Spanish() =
    Assert.Equal("¿Le gustaría tener el juego invertida?", translator language.spanish Would_You_Like_To_The_Game_Inverted)

[<Fact>]
let Tranlate_Would_You_Like_AI_VS_AI_To_Spanish() =
    Assert.Equal("¿Le gustaría IA IA VS ?", translator language.spanish Would_You_Like_AI_VS_AI)

[<Fact>]
let Tranlate_Would_You_Like_To_Go_First_To_Spanish() =
    Assert.Equal("¿Quieres ser el primero?", translator language.spanish Would_You_Like_To_Go_First)

[<Fact>]
let Tranlate_Other_Player_Is_Going_First_To_Spanish() =
    Assert.Equal("Otro jugador va primero", translator language.spanish Other_Player_Is_Going_First)

[<Fact>]
let Tranlate_AI_Is_Playing_To_Spanish() =
    Assert.Equal("IA está jugando", translator language.spanish AI_Is_Playing)

[<Fact>]
let Tranlate_Your_Going_First_To_Spanish() =
    Assert.Equal("Su yendo primero", translator language.spanish Your_Going_First)

[<Fact>]
let Tranlate_Human_Vs_Human_To_Spanish() =
    Assert.Equal("Humana Vs humana", translator language.spanish Human_Vs_Human)

[<Fact>]
let Tranlate_AI_vs_AI_To_Spanish() =
    Assert.Equal("IA vs IA" , translator language.spanish AI_vs_AI)

[<Fact>]
let Tranlate_Human_Vs_AI_To_Spanish() =
    Assert.Equal("IA humana Vs" , translator language.spanish Human_Vs_AI)

[<Fact>]
let Tranlate_Here_Are_Your_Current_Settings_To_Spanish() =
    Assert.Equal("Aquí están sus actuales ajustes" , translator language.spanish Here_Are_Your_Current_Settings)

[<Fact>]
let Tranlate_Current_Board_Size_Is_To_Spanish() =
    Assert.Equal("Tamaño actual Junta es: " , translator language.spanish Current_Board_Size_Is)

[<Fact>]
let Tranlate_Player_Glyph_To_Spanish() =
    Assert.Equal("Glifo jugador: " , translator language.spanish Player_Glyph)

[<Fact>]
let Tranlate_Other_Player_Glyph_To_Spanish() =
    Assert.Equal("Otro glifo del jugador: " , translator language.spanish Other_Player_Glyph)

[<Fact>]
let Tranlate_Game_Inverted_To_Spanish() =
    Assert.Equal("juego invertido: " , translator language.spanish Game_Inverted)

[<Fact>]
let Tranlate_Are_These_The_Setting_You_Want_To_Spanish() =
    Assert.Equal("¿Estos son el ajuste que desea?" , translator language.spanish Are_These_The_Setting_You_Want)

[<Fact>]
let Tranlate_Another_Game_Y_N_To_Spanish() =
    Assert.Equal("¿Otro juego? S / N: " , translator language.spanish Another_Game_Y_N)

[<Fact>]
let Tranlate_Same_Settings_Y_N_To_Spanish() =
    Assert.Equal("Mismos ajustes? S / N: " , translator language.spanish Same_Settings_Y_N)


[<Fact>]
let Tranlate_No_Translation_To_Spanish() =
    Assert.Equal("Sin traducción" , translator language.spanish 999)