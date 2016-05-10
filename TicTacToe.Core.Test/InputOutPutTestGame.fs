module InputOutPutTestGame
open IInputOutPut
open System.Collections.Generic

type InputOutTestGame(moves : Queue<int>) =
    member val moves = moves
    member this.printNoScreenFlush(output : list<string>) 
        = (this :> IInputOut).printNoScreenFlush(output : list<string>)
    member this.print() 
        = (this :> IInputOut).cleanScreen()
    member this.getUserInput() : string 
        = (this :> IInputOut).getUserInput() : string
    interface IInputOut with
        member this.cleanScreen() = 
            "Should" |> ignore

        member this.getUserInput() : string =
            string (moves.Dequeue())

         member this.printNoScreenFlush(output : list<string>) =
            "Should" |> ignore
            