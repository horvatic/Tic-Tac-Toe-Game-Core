open BuildAndStartGame
open InputOutPut

[<EntryPoint>]
let main argv =
    let io = new InputOut()
    let mutable playgame = true
    while playgame do
        buildAndStartGame(io)
        io.printNoScreenWhip([|"Another Game? Y/N: "|])
        let input = io.getUserInput()
        if not (input = "Y" || input = "y") then
            playgame <- false

    0 // return an integer exit code

