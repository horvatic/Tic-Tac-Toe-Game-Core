namespace TicTacToe.Core  
module CleanInput =
    open userInputException
    exception NonIntError of unit
    exception InvaildOption of unit

    let inputWithinBoundsOfTiCTacToeBox ( userInput : int ) ( boxSize : int ) : int32 =
        if userInput > boxSize then
            raise(OutOfBoundsOverFlow())
        elif userInput < 1 then
            raise(OutOfBoundsUnderFlow())
        userInput

    let SanitizeHumanPickedPlace ( input : string ) ( boxSize : int ) : int32 =
        try
            let userInput = int input
            inputWithinBoundsOfTiCTacToeBox(userInput)(boxSize)
        with
            | :? System.FormatException -> raise(NonIntError())