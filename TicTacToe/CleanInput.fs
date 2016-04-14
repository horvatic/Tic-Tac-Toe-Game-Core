module CleanInput
exception NonIntError of string

let Sanitize ( input : string ) : int32 =
    let mutable cnt = 0;
    try
            cnt <- int input
    with
        | :? System.FormatException -> raise(NonIntError("Not an Int"))
    cnt