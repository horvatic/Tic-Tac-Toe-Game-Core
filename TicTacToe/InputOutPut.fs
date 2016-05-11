module InputOutPut
open IInputOutPut
open Translator
open Translate

let newCurrentLanguage() =
    printfn "For English Press 1: "
    printfn "Para la prensa española , pero cualquier tecla 1"
    if System.Console.ReadLine() = "1" then
        language.english
    else
        language.spanish

type InputOut() =
    member val private currentLanguage = newCurrentLanguage()

    member this.printNoScreenFlush(output : list<int>) 
        = (this :> IInputOut).printNoScreenFlush(output : list<int>)
    member this.printNoScreenFlushNoTranslate(output : list<string>) 
        = (this :> IInputOut).printNoScreenFlushNoTranslate(output : list<string>)
    member this.cleanScreen() 
        = (this :> IInputOut).cleanScreen()
    member this.getUserInput() : string 
        = (this :> IInputOut).getUserInput() : string
    interface IInputOut with
        member this.cleanScreen() = 
            System.Console.Clear()

        member this.getUserInput() : string =
            printf "%s" (translator(this.currentLanguage)(Input))
            System.Console.ReadLine()

        member this.printNoScreenFlush(output : list<int>) 
            = for i = 0 to output.Length - 1 do
                printfn "%s" (translator(this.currentLanguage)(output.[i]))

        member this.printNoScreenFlushNoTranslate(output : list<string>) 
            = for i = 0 to output.Length - 1 do
                printfn "%s" output.[i]