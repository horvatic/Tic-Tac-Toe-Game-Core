module InputOutPut
open IInputOutPut

type InputOut() =
    member this.print(output : array<string>) 
        = (this :> IInputOut).print(output : array<string>)
    member this.getUserInput() : string 
        = (this :> IInputOut).getUserInput() : string
    interface IInputOut with
        member this.print(output : array<string>) = 
            System.Console.Clear()
            for i = 0 to output.Length - 1 do
                printfn "%s" output.[i]

        member this.getUserInput() : string =
            printf "Input: "
            System.Console.ReadLine()