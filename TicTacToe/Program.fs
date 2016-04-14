open CleanInput
open TicTacToeBoxEdit

[<EntryPoint>]
let main argv =
    let mutable nonLost = true
    let mutable userInput = 0
    let mutable ticTacToeBox = [|"1"; "2"; "3"; "4"; "5"; "6"; "7"; "8"; "9"|]
    let mutable error = ""
    while nonLost do
        try
            System.Console.Clear()
            printfn "%s" error
            printfn "------------------------"
            printfn "|  %s   |   %s   |   %s   |" (string ticTacToeBox.[0]) (string ticTacToeBox.[1]) (string ticTacToeBox.[2])
            printfn "------------------------"
            printfn "|  %s   |   %s   |   %s   |" (string ticTacToeBox.[3]) (string ticTacToeBox.[4]) (string ticTacToeBox.[5])
            printfn "------------------------"
            printfn "|  %s   |   %s   |   %s   |" (string ticTacToeBox.[6]) (string ticTacToeBox.[7]) (string ticTacToeBox.[8])
            printfn "------------------------"
            printf "Input: "
            userInput <- Sanitize (System.Console.ReadLine())
            System.Console.Clear()
            ticTacToeBox <- InsertUserOption (ticTacToeBox) (userInput)
            error <- ""
        with
            | :? NonIntError -> error <- "Invaild Number"
            | :? OutOfBoundsOverFlow ->  error <- "Value to large"
            | :? OutOfBoundsUnderFlow -> error <- "Value to small"
            | :? SpotAlreayTaken -> error <- "Spot Taken"
    
    0 // return an integer exit code
