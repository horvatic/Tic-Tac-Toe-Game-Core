module TicTacToeBoxEdit
open TicTacToeBoxClass
open GameSettings
exception SpotAlreayTaken of string

let insertUserOption (board : TicTacToeBox) 
                     (userInput: int)(playerGlyph : string )
                     (aIGlyph : string ) : TicTacToeBox =
    if board.getGlyphAtLocation(userInput-1) = playerGlyph || board.getGlyphAtLocation(userInput-1) = aIGlyph then
        raise(SpotAlreayTaken("Spot Taken"))
    board.getTicTacToeBoxEdited(userInput - 1, playerGlyph, playerGlyph, aIGlyph)

let insertOtherUserOption(board : TicTacToeBox) 
                         (userInput: int)(playerGlyph : string )
                         (aIGlyph : string ) =
    if board.getGlyphAtLocation(userInput-1) = playerGlyph || board.getGlyphAtLocation(userInput-1) = aIGlyph then
        raise(SpotAlreayTaken("Spot Taken"))
    board.getTicTacToeBoxEdited(userInput - 1, aIGlyph, playerGlyph, aIGlyph)