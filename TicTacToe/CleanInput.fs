module CleanInput

exception NonIntError of string
exception OutOfBoundsOverFlow of string
exception OutOfBoundsUnderFlow of string

let Sanitize ( input : string ) : int32 =
    let mutable userInput = 0;
    try
        userInput <- int input
        if userInput > 9 then
            raise(OutOfBoundsOverFlow(""))
        elif userInput < 1 then
            raise(OutOfBoundsUnderFlow(""))
    with
        | :? System.FormatException -> raise(NonIntError("Not an Int"))
        | :? OutOfBoundsOverFlow -> raise(OutOfBoundsOverFlow("Value to large"))
        | :? OutOfBoundsUnderFlow -> raise(OutOfBoundsUnderFlow("Value to small"))
    userInput