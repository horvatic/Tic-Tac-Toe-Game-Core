module InputOutPutTestGame
open TicTacToe.Core 
open IInputOutPut
open System.Collections.Generic

type InputOutTestGame(moves : Queue<int>) =
    member val moves = moves
    member this.printNoScreenFlush(output : list<int>) 
        = (this :> IInputOut).printNoScreenFlush(output : list<int>)
    member this.printNoScreenFlushNoTranslate(output : list<string>) 
        = (this :> IInputOut).printNoScreenFlushNoTranslate(output : list<string>)
    member this.print() 
        = (this :> IInputOut).cleanScreen()
    member this.getUserInput() : string 
        = (this :> IInputOut).getUserInput() : string
    interface IInputOut with
        member this.cleanScreen() = 
            "Should" |> ignore

        member this.getUserInput() : string =
            string (moves.Dequeue())

         member this.printNoScreenFlush(output : list<int>) =
            "Should" |> ignore

        member this.printNoScreenFlushNoTranslate(output : list<string>) =
            "Should" |> ignore
            