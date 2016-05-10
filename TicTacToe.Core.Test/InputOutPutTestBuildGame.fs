module InputOutPutTestBuildGame
open IInputOutPut
open System.Collections.Generic

type InputOutTestBuildGame(option : string) =
    member val option = option
    member this.print(output : list<string>) 
        = (this :> IInputOut).print(output : list<string>)
    member this.getUserInput() : string 
        = (this :> IInputOut).getUserInput() : string
    member this.printNoScreenNoFlush(output : list<string>) 
        = (this :> IInputOut).printNoScreenNoFlush(output : list<string>)
    interface IInputOut with
        member this.print(output : list<string>) = 
            "Should" |> ignore

        member this.getUserInput() : string =
            option

        member this.printNoScreenNoFlush(output : list<string>) = 
            "Should" |> ignore

type InputOutTestBuildGameManyOps(moves : Queue<string>) =
    member val moves = moves
    member this.print(output : list<string>) 
        = (this :> IInputOut).print(output : list<string>)
    member this.getUserInput() : string 
        = (this :> IInputOut).getUserInput() : string
    interface IInputOut with
        member this.print(output : list<string>) = 
            "Should" |> ignore

        member this.getUserInput() : string =
            moves.Dequeue()
        
        member this.printNoScreenNoFlush(output : list<string>) = 
            "Should" |> ignore