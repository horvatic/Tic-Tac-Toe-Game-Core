module CleanInput
open userInputException
exception NonIntError of string
exception InvaildOption of string

let inputWithinBoundsOfTiCTacToeBox ( userInput : int ) ( boxSize : int ) : int32 =
    if userInput > boxSize then
        raise(OutOfBoundsOverFlow("Value to large"))
    elif userInput < 1 then
        raise(OutOfBoundsUnderFlow("Value to small"))
    userInput

let SanitizeHumanPickedPlace ( input : string ) ( boxSize : int ) : int32 =
    try
        let userInput = int input
        inputWithinBoundsOfTiCTacToeBox(userInput)(boxSize)
    with
        | :? System.FormatException -> raise(NonIntError("Not an Int"))


let SanitizeGlyph( input : string) : string =
    if input.Length = 1 then
        input
    else
        raise(InvaildGlyph("Length Must be one"))
 
let boxSizeWithinBound(userInput : int ) : int =
    if userInput > 4 then
        raise(OutOfBoundsOverFlow("Value to large"))
    elif userInput < 3 then
        raise(OutOfBoundsUnderFlow("Value to small"))
    userInput

let SanitizeBoxSize(input : string) : int =
    try
        let userInput = int input
        boxSizeWithinBound(userInput)
    with
        | :? System.FormatException -> raise(NonIntError("Not an Int"))


let SanitizeYesOrNo(input : string) : string =
    let userInput = input
    if not( userInput.ToUpper() = "Y") && not( userInput.ToUpper() = "N" ) then
        raise(InvaildOption("Must be a Y or N"))
    userInput.ToUpper()