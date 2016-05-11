module GameSettings
open PlayerValues
open userInputException

type gameSetting =
    struct 
        val ticTacToeBoxSize : int
        val playerGlyph : string
        val aIGlyph : string
        val firstPlayer : int
        val inverted : bool
        val humanVsHuman : bool
        val aIvAI : bool
        new(newTicTacToeBoxSize, newplayerGlyph, newaIGlyph, 
            newfirstPlayer, newInverted, newhumanVsHuman, newAIvAI)
            = { ticTacToeBoxSize = newTicTacToeBoxSize; playerGlyph = newplayerGlyph;
                aIGlyph = newaIGlyph; firstPlayer = newfirstPlayer;
                inverted = newInverted; humanVsHuman = newhumanVsHuman;
                aIvAI = newAIvAI; }
end

let craftGameSetting
    (newTicTacToeBoxSize : int)
    (playerGlyph : string)
    (aIGlyph : string) 
    (firstPlayer : int)
    (inverted : bool) 
    (humanVsHuman : bool) 
    (aIvAI : bool)
    : gameSetting =
    if not (newTicTacToeBoxSize = 3) && not (newTicTacToeBoxSize = 4) then
        raise(InvaildSizeOfBox())
    if not (playerGlyph.Length = 1) || not (aIGlyph.Length = 1) then
        raise(InvaildGlyph())
    if playerGlyph = aIGlyph then 
        raise(InvaildGlyph())
    if not (firstPlayer = int playerVals.Human) && not (firstPlayer = int playerVals.AI) then 
        raise(InvaildPlayer())
    gameSetting(newTicTacToeBoxSize, playerGlyph, aIGlyph, 
               firstPlayer, inverted, humanVsHuman, aIvAI)