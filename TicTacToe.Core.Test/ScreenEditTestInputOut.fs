module ScreenEditTestInputOut
open TicTacToe.Core 
open IInputOutPut
open Xunit
open FsUnit

type InputOutTestGame(newCorrectOutPutNoTrans : list<string>, newCorrectOutPutTrans : list<int>) =
    member val private correctOutPutNoTrans = newCorrectOutPutNoTrans
    member val private correctOutPutTrans = newCorrectOutPutTrans

    member this.printNoScreenFlush(output : list<int>) 
        = (this :> IInputOut).printNoScreenFlush(output : list<int>)
    member this.printNoScreenFlushNoTranslate(output : list<string>) 
        = (this :> IInputOut).printNoScreenFlushNoTranslate(output : list<string>)
    member this.getUserInput() : string 
        = (this :> IInputOut).getUserInput() : string
    interface IInputOut with
        member this.cleanScreen() = 
            "Should" |> ignore

        member this.getUserInput() : string =
            "Not needed For Testing"

         member this.printNoScreenFlush(output : list<int>) =
            for i = 0 to output.Length - 1 do
                Assert.Equal(output.[i], this.correctOutPutTrans.[i])
         
         member this.printNoScreenFlushNoTranslate(output : list<string>)  =
            for i = 0 to output.Length - 1 do
                Assert.Equal(output.[i], this.correctOutPutNoTrans.[i])
