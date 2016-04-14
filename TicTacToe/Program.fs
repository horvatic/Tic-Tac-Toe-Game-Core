open CleanInput

[<EntryPoint>]
let main argv =
    let mutable nonLost = true;
    let mutable cnt = 0;
    while nonLost do
        printfn "-----------------------------------------------------------"
        try
            cnt <- Sanitize (System.Console.ReadLine())
            printfn "%i" cnt
            if cnt > 10 then
                nonLost <- false
        with
            | :? NonIntError -> printfn "Invaild Number"
    
    0 // return an integer exit code
