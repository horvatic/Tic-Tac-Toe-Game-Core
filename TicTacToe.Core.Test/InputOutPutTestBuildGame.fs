module InputOutPutTestBuildGame
open IInputOutPut
open System.Collections.Generic

type InputOutTestBuildGame(option : string) =
    member val option = option
    member this.print() 
        = (this :> IInputOut).cleanScreen()
    member this.getUserInput() : string 
        = (this :> IInputOut).getUserInput() : string
    member this.printNoScreenFlush(output : list<string>) 
        = (this :> IInputOut).printNoScreenFlush(output : list<string>)
    interface IInputOut with
        member this.cleanScreen() = 
            "Should" |> ignore

        member this.getUserInput() : string =
            option

        member this.printNoScreenFlush(output : list<string>) = 
            "Should" |> ignore

type InputOutTestBuildGameManyOps(moves : Queue<string>) =
    member val moves = moves
    member this.print(output : list<string>) 
        = (this :> IInputOut).cleanScreen()
    member this.getUserInput() : string 
        = (this :> IInputOut).getUserInput() : string
    interface IInputOut with
        member this.cleanScreen() = 
            "Should" |> ignore

        member this.getUserInput() : string =
            moves.Dequeue()
        
        member this.printNoScreenFlush(output : list<string>) = 
            "Should" |> ignore