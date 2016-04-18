open Game

[<EntryPoint>]
let main argv =
    let mutable playgame = true
    let mutable input = ""
    while playgame do
        startGame()
        printf "Another Game? Y/N: "
        input <- System.Console.ReadLine()
        if not (input = "Y" || input = "y") then
            playgame <- false

    0 // return an integer exit code

