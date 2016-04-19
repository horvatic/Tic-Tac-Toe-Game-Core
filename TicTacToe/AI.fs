module AI
open CheckForWinnerOrTie
type playerVals =
    | AI = 1
    | Human = -1

let rec minimax( ticTacToeBox : array<string>)(player : int)
             : int =
    0
let computerMove( ticTacToeBox : array<string>)
             : int =
    
    0

let AIMove( ticTacToeBox : array<string>)( firstMove : bool )
          : array<string> =
   
    ticTacToeBox.[computerMove(ticTacToeBox)] <- "@"
    ticTacToeBox
