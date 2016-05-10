module ScreenEditTestInputOut
open IInputOutPut
open Xunit
open FsUnit

type InputOutTestGame(newCorrectOutPut : list<string>) =
    member val private correctOutPut = newCorrectOutPut

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
            "Not needed For Testing"

         member this.printNoScreenFlush(output : list<string>) =
            for i = 0 to output.Length - 1 do
                Assert.Equal(output.[i], this.correctOutPut.[i])
