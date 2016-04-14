open CleanInput

[<EntryPoint>]
let main argv =
    let mutable nonLost = true;
    let mutable userInput = 0;
    while nonLost do
        printfn "-----------------------------------------------------------"
        try
            userInput <- Sanitize (System.Console.ReadLine())
            printfn "%i" userInput
            if userInput > 5 then
                nonLost <- false
        with
            | :? NonIntError -> printfn "Invaild Number"
            | :? OutOfBoundsOverFlow ->  printfn "Value to large"
            | :? OutOfBoundsUnderFlow -> printfn "Value to small"
    
    0 // return an integer exit code
