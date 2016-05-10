module InputOutPut
open IInputOutPut

type InputOut() =
    member this.printNoScreenFlush(output : list<string>) 
        = (this :> IInputOut).printNoScreenFlush(output : list<string>)
    member this.cleanScreen() 
        = (this :> IInputOut).cleanScreen()
    member this.getUserInput() : string 
        = (this :> IInputOut).getUserInput() : string
    interface IInputOut with
        member this.cleanScreen() = 
            System.Console.Clear()

        member this.getUserInput() : string =
            printf "Input: "
            System.Console.ReadLine()

        member this.printNoScreenFlush(output : list<string>) 
            = for i = 0 to output.Length - 1 do
                printfn "%s" output.[i]