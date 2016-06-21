namespace TicTacToe.Core 
module Game =
    open AI
    open CleanInput
    open TicTacToeBoxEdit
    open CheckForWinnerOrTie
    open GameSettings
    open GameStatusCodes
    open userInputException
    open PlayerValues
    open ITicTacToeBoxClass
    open TicTacToeBoxClass
    open Translate

    let makeTicTacToeBox(size : int) : list<string> =
        if size = 3 then
            ["-1-"; "-2-"; "-3-"; 
            "-4-"; "-5-"; "-6-"; 
            "-7-"; "-8-"; "-9-"]
    
        else 
            ["-1-"; "-2-"; "-3-"; "-4-"; 
            "-5-"; "-6-"; "-7-"; "-8-"; 
            "-9-"; "-10-"; "-11-"; "-12-";
            "-13-"; "-14-"; "-15-"; "-16-"]

    let isInputANumber(postion : string) : bool =
        try
            let posAsInt = int postion
            true
        with
            | :? System.FormatException -> false


    let isOutBounds(arrayLenth : int)(postion : int) : bool =
        if postion > arrayLenth - 1  || postion < 0 then
            true
        else
            false

    let isSpotTaken(board : ITicTacToeBox)
                   (postion : int)
                   (playerGlyph : string) 
                   (aIGlyph : string)
                   : bool =
        if board.getGlyphAtLocation(postion) = playerGlyph || board.getGlyphAtLocation(postion) = aIGlyph then
            true
        else
            false
        
    let isUserInputCorrect(board : ITicTacToeBox)
                          (postion : string)
                          (playerGlyph : string) 
                          (aIGlyph : string) : int =
        if not (isInputANumber(postion)) then
            Value_Not_A_Number
        elif isOutBounds(board.cellCount())(int postion - 1) then
            Value_Out_Of_Bounds
        elif isSpotTaken(board)(int postion - 1)(playerGlyph)(aIGlyph) then
            Spot_Taken
        else
            Blank
    let convertStringToInt(pos : string) : int =
        int pos