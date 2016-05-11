module InputOutPut
open IInputOutPut
open Translator

let newCurrentLanguage() =
    printfn "For English Press 1: "
    printfn "Para la prensa española , pero cualquier tecla 1"
    if System.Console.ReadLine() = "1" then
        language.english
    else
        language.spanish

type InputOut() =
    member val private currentLanguage = newCurrentLanguage()

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