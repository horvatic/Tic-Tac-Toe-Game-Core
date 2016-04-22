module CleanInput
open userInputException

exception NonIntError of string
exception InvaildOption of string

let SanitizeHumanPickedPlace ( input : string ) : int32 =
    let mutable userInput = 0
    try
        userInput <- int input
    with
        | :? System.FormatException -> raise(NonIntError("Not an Int"))
    if userInput > 9 then
        raise(OutOfBoundsOverFlow("Value to large"))
    elif userInput < 1 then
        raise(OutOfBoundsUnderFlow("Value to small"))
    userInput

let SanitizeGlyph( input : string) : string =
    if input.Length = 1 then
        input
    else
        raise(InvaildGlyph("Length Must be one"))

let SanitizeBoxSize(input : string) : int =
    let mutable userInput = 0
    try
        userInput <- int input
    with
        | :? System.FormatException -> raise(NonIntError("Not an Int"))
    if userInput > 4 then
        raise(OutOfBoundsOverFlow("Value to large"))
    elif userInput < 3 then
        raise(OutOfBoundsUnderFlow("Value to small"))

    userInput

let SanitizeYesOrNo(input : string) : string =
    let mutable userInput = input
    userInput <- userInput.ToUpper()
    if not( userInput = "Y") && not( userInput = "N" ) then
        raise(InvaildOption("Must be a Y or N"))
    userInput
