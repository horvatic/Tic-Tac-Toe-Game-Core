module InputOutPutTestBuildGame
open TicTacToe.Core 
open IInputOutPut
open System.Collections.Generic

type InputOutTestBuildGame(option : string) =
    member val option = option
    member this.print() 
        = (this :> IInputOut).cleanScreen()
    member this.getUserInput() : string 
        = (this :> IInputOut).getUserInput() : string
    member this.printNoScreenFlushNoTranslate(output : list<string>) 
        = (this :> IInputOut).printNoScreenFlushNoTranslate(output : list<string>)
    member this.printNoScreenFlush(output : list<int>) 
        = (this :> IInputOut).printNoScreenFlush(output : list<int>)
    interface IInputOut with
        member this.cleanScreen() = 
            "Should" |> ignore

        member this.getUserInput() : string =
            option

        member this.printNoScreenFlush(output : list<int>) = 
            "Should" |> ignore

        member this.printNoScreenFlushNoTranslate(output : list<string>) =
            "Should" |> ignore

type InputOutTestBuildGameManyOps(moves : Queue<string>) =
    member val moves = moves
    
    member this.printNoScreenFlushNoTranslate(output : list<string>) 
        = (this :> IInputOut).printNoScreenFlushNoTranslate(output : list<string>)
    member this.printNoScreenFlush(output : list<int>) 
        = (this :> IInputOut).printNoScreenFlush(output : list<int>)
    member this.getUserInput() : string 
        = (this :> IInputOut).getUserInput() : string
    interface IInputOut with
        member this.cleanScreen() = 
            "Should" |> ignore

        member this.getUserInput() : string =
            moves.Dequeue()
        
        member this.printNoScreenFlush(output : list<int>) = 
            "Should" |> ignore

        member this.printNoScreenFlushNoTranslate(output : list<string>) =
            "Should" |> ignore