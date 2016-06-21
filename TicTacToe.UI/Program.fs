open TicTacToe.Core 
open BuildAndStartGame
open InputOutPut

[<EntryPoint>]
let main argv =
    buildAndStartGame(new InputOut())

