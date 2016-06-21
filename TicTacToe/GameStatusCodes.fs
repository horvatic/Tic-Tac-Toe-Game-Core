namespace TicTacToe.Core 
module GameStatusCodes =

    type GenResult =
        | Tie = 0
        | NoWinner = -9999

    type Result3X3 =
       | AiWins = 10
       | HumanWins = -10

    type Result4X4 =
       | AiWins = 7
       | HumanWins = -7

    let getWinningAIValue(ticTacToeBoxsize : int ) : int =
        if ticTacToeBoxsize = 3 then
            int Result3X3.AiWins
        else
            int Result4X4.AiWins

    let getWinningHumanValue(ticTacToeBoxsize : int ) : int =
        if ticTacToeBoxsize = 3 then
            int Result3X3.HumanWins
        else
            int Result4X4.HumanWins