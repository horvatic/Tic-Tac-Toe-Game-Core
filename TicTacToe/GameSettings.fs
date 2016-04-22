module GameSettings
open PlayerValues
open userInputException

type gameSetting =
    struct 
        val mutable ticTacToeBox : array<string>
        val playerOneGlyph : string
        val playerTwoGlyph : string
        val firstPlayer : int
        val inverted : bool
        val aIvAI : bool
        new(newTicTacToeBox, newplayerOneGlyph, newplayerTwoGlyph, 
            newfirstPlayer, newInverted, newAIvAI)
            = { ticTacToeBox = newTicTacToeBox; playerOneGlyph = newplayerOneGlyph;
                playerTwoGlyph = newplayerTwoGlyph; firstPlayer = newfirstPlayer;
                inverted = newInverted; aIvAI = newAIvAI; }
end

let craftGameSetting
    (ticTacToeBox : array<string>)
    (playerOneGlyph : string)
    (playerTwoGlyph : string) 
    (firstPlayer : int)
    (inverted : bool) 
    (aIvAI : bool)
    : gameSetting =
    if not (ticTacToeBox.Length = 9) then
        raise(InvaildSizeOfBox("Invaild TicTacToe Box Size"))
    if not (playerOneGlyph.Length = 1) || not (playerTwoGlyph.Length = 1) then
        raise(InvaildGlyph("Glyph must be one Char"))
    if playerOneGlyph = playerTwoGlyph then 
        raise(InvaildGlyph("Players Glyph must differ"))
    if not (firstPlayer = int playerVals.Human) && not (firstPlayer = int playerVals.AI) then 
        raise(InvaildPlayer("Player Vals can be " +  string playerVals.Human + " or " + string playerVals.AI))
    gameSetting(ticTacToeBox, playerOneGlyph, playerTwoGlyph, 
               firstPlayer, inverted, aIvAI)
