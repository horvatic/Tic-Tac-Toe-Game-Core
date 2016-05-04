module GameSettings
open PlayerValues
open userInputException

type gameSetting =
    struct 
        val mutable ticTacToeBox : array<string>
        val playerGlyph : string
        val aIGlyph : string
        val firstPlayer : int
        val inverted : bool
        val humanVsHuman : bool
        val aIvAI : bool
        new(newTicTacToeBox, newplayerGlyph, newaIGlyph, 
            newfirstPlayer, newInverted, newhumanVsHuman, newAIvAI)
            = { ticTacToeBox = newTicTacToeBox; playerGlyph = newplayerGlyph;
                aIGlyph = newaIGlyph; firstPlayer = newfirstPlayer;
                inverted = newInverted; humanVsHuman = newhumanVsHuman;
                aIvAI = newAIvAI; }
end

let craftGameSetting
    (ticTacToeBox : array<string>)
    (playerGlyph : string)
    (aIGlyph : string) 
    (firstPlayer : int)
    (inverted : bool) 
    (humanVsHuman : bool) 
    (aIvAI : bool)
    : gameSetting =
    if not (ticTacToeBox.Length = 9) && not (ticTacToeBox.Length = 16) then
        raise(InvaildSizeOfBox("Invaild TicTacToe Box Size"))
    if not (playerGlyph.Length = 1) || not (aIGlyph.Length = 1) then
        raise(InvaildGlyph("Glyph must be one Char"))
    if playerGlyph = aIGlyph then 
        raise(InvaildGlyph("Players Glyph must differ"))
    if not (firstPlayer = int playerVals.Human) && not (firstPlayer = int playerVals.AI) then 
        raise(InvaildPlayer("Player Vals can be " +  string playerVals.Human + " or " + string playerVals.AI))
    gameSetting(ticTacToeBox, playerGlyph, aIGlyph, 
               firstPlayer, inverted, humanVsHuman, aIvAI)
