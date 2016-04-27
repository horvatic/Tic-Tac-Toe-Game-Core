module TicTacToeBoxEdit
open GameSettings
exception SpotAlreayTaken of string

let InsertUserOption ( ticTacToeBox : array<string>) (userInput: int32)(game : gameSetting) : array<string> =
    if ticTacToeBox.[userInput-1] = game.playerGlyph || ticTacToeBox.[userInput-1] = game.aIGlyph then
        raise(SpotAlreayTaken("Spot Taken"))
    ticTacToeBox.[userInput-1] <- game.playerGlyph
    ticTacToeBox