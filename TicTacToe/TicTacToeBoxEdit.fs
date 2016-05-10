module TicTacToeBoxEdit
open ITicTacToeBoxClass
open GameSettings
exception SpotAlreayTaken of string

let insertUserOption (board : ITicTacToeBox) 
                     (userInput: int)(playerGlyph : string )
                     (aIGlyph : string ) : ITicTacToeBox =
    if board.getGlyphAtLocation(userInput-1) = playerGlyph || board.getGlyphAtLocation(userInput-1) = aIGlyph then
        raise(SpotAlreayTaken("Spot Taken"))
    board.getTicTacToeBoxEdited(userInput - 1)(playerGlyph)(playerGlyph)(aIGlyph)

let insertOtherUserOption(board : ITicTacToeBox) 
                         (userInput: int)(playerGlyph : string )
                         (aIGlyph : string ) : ITicTacToeBox =
    if board.getGlyphAtLocation(userInput-1) = playerGlyph || board.getGlyphAtLocation(userInput-1) = aIGlyph then
        raise(SpotAlreayTaken("Spot Taken"))
    board.getTicTacToeBoxEdited(userInput - 1)(aIGlyph)(playerGlyph)(aIGlyph)