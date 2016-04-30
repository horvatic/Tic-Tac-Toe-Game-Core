module InputOutPutTestGame
open IInputOutPut

type InputOutTestGame(moves : array<int>) =
    member val moves = moves
    member val nextMove = -1 with get, set
    member this.print(output : array<string>) 
        = (this :> IInputOut).print(output : array<string>)
    member this.getUserInput() : string 
        = (this :> IInputOut).getUserInput() : string
    interface IInputOut with
        member this.print(output : array<string>) = 
            "Should" |> ignore

        member this.getUserInput() : string =
            this.nextMove <- this.nextMove + 1
            string this.moves.[this.nextMove]
            