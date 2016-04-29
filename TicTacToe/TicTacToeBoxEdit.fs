module TicTacToeBoxEdit
open GameSettings
exception SpotAlreayTaken of string

let insertUserOption (ticTacToeBox : array<string>) 
                     (userInput: int)(playerGlyph : string )
                     (aIGlyph : string ) =
    if ticTacToeBox.[userInput-1] = playerGlyph || ticTacToeBox.[userInput-1] = aIGlyph then
        raise(SpotAlreayTaken("Spot Taken"))
    ticTacToeBox.[userInput-1] <- playerGlyph