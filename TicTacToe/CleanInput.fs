module CleanInput

exception NonIntError of string
exception OutOfBoundsOverFlow of string
exception OutOfBoundsUnderFlow of string

let Sanitize ( input : string ) : int32 =
    let mutable userInput = 0;
    try
        userInput <- int input
        if userInput > 9 then
            raise(OutOfBoundsOverFlow("Value to large"))
        elif userInput < 1 then
            raise(OutOfBoundsUnderFlow("Value to small"))
    with
        | :? System.FormatException -> raise(NonIntError("Not an Int"))
        | :? OutOfBoundsOverFlow -> raise(OutOfBoundsOverFlow("Value to large"))
        | :? OutOfBoundsUnderFlow -> raise(OutOfBoundsUnderFlow("Value to small"))
    userInput