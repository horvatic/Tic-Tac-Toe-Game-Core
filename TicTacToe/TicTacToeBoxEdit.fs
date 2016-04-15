module TicTacToeBoxEdit
exception SpotAlreayTaken of string

let InsertUserOption ( ticTacToeBox : array<string>) (userInput: int32) : array<string> =
    if ticTacToeBox.[userInput-1] = "X" || ticTacToeBox.[userInput-1] = "O" then
        raise(SpotAlreayTaken("Spot Taken"))
    ticTacToeBox.[userInput-1] <- "X"
    ticTacToeBox