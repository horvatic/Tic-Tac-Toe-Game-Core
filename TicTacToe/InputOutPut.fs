module InputOutPut
open IInputOutPut

type InputOut() =
    member this.printNoScreenNoFlush(output : list<string>) 
        = (this :> IInputOut).printNoScreenNoFlush(output : list<string>)
    member this.print(output : list<string>) 
        = (this :> IInputOut).print(output : list<string>)
    member this.getUserInput() : string 
        = (this :> IInputOut).getUserInput() : string
    interface IInputOut with
        member this.print(output : list<string>) = 
            System.Console.Clear()
            for i = 0 to output.Length - 1 do
                printfn "%s" output.[i]

        member this.getUserInput() : string =
            printf "Input: "
            System.Console.ReadLine()

        member this.printNoScreenNoFlush(output : list<string>) 
            = for i = 0 to output.Length - 1 do
                printfn "%s" output.[i]