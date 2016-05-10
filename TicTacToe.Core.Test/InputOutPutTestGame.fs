module InputOutPutTestGame
open IInputOutPut
open System.Collections.Generic

type InputOutTestGame(moves : Queue<int>) =
    member val moves = moves
    member this.printNoScreenNoFlush(output : list<string>) 
        = (this :> IInputOut).printNoScreenNoFlush(output : list<string>)
    member this.print(output : list<string>) 
        = (this :> IInputOut).print(output : list<string>)
    member this.getUserInput() : string 
        = (this :> IInputOut).getUserInput() : string
    interface IInputOut with
        member this.print(output : list<string>) = 
            "Should" |> ignore

        member this.getUserInput() : string =
            string (moves.Dequeue())

         member this.printNoScreenNoFlush(output : list<string>) =
            "Should" |> ignore
            