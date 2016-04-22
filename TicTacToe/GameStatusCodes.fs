module GameStatusCodes

type Result =
   | Tie = 0
   | AiWins = 10
   | HumanWins = -10
   | NoWinner = -9999