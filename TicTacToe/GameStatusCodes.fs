module GameStatusCodes

type GenResult =
    | Tie = 0
    | NoWinner = -9999

type Result3X3 =
   | AiWins = 10
   | HumanWins = -10

type Result4X4 =
   | AiWins = 17
   | HumanWins = -17

let getWinningAIValue(ticTacToeBox : array<string> ) : int =
    if ticTacToeBox.Length = 9 then
        int Result3X3.AiWins
    else
        int Result4X4.AiWins

let getWinningHumanValue(ticTacToeBox : array<string> ) : int =
    if ticTacToeBox.Length = 9 then
        int Result3X3.HumanWins
    else
        int Result4X4.HumanWins