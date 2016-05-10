module GameStatusCodesTest
open GameStatusCodes
open Xunit 
open FsUnit


[<Fact>]
let Winning_Value_Ai() =
    Assert.Equal(int Result3X3.AiWins, getWinningAIValue 3)
    Assert.Equal(int Result4X4.AiWins, getWinningAIValue 4)

[<Fact>]
let Winning_Value_Human() =
    Assert.Equal(int Result3X3.HumanWins, getWinningHumanValue 3)
    Assert.Equal(int Result4X4.HumanWins, getWinningHumanValue 4)