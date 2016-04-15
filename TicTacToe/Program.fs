open CleanInput
open TicTacToeBoxEdit
open AI

[<EntryPoint>]
let main argv =
    let mutable nonLost = true
    let mutable firstMove = true
    let mutable userInput = 0
    let mutable ticTacToeBox = [|"1"; "2"; "3"; "4"; "5"; "6"; "7"; "8"; "9"|]
    let mutable message = ""
    while nonLost do
        try
            System.Console.Clear()
            printfn "%s" message
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
            ticTacToeBox <- AIMove (ticTacToeBox) (firstMove)
            firstMove <- false
            message <- ""
        with
            | :? NonIntError -> message <- "Invaild Number"
            | :? OutOfBoundsOverFlow ->  message <- "Value to large"
            | :? OutOfBoundsUnderFlow -> message <- "Value to small"
            | :? SpotAlreayTaken -> message <- "Spot Taken"
    
    0 // return an integer exit code
