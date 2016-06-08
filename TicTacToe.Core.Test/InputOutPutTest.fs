module InputOutPutTest
open TicTacToe.Core 
open InputOutPut
open Xunit
open FsUnit
open System.IO
open Translator
open Translate

[<Fact>]
let User_Pick_English() =
    let trashData = new StringWriter()
    System.Console.SetOut(trashData)
    let userInput = new StringReader("1")
    System.Console.SetIn(userInput)
    let selectedlang = int (newCurrentLanguage())
    let correctLang = int language.english
    Assert.Equal(correctLang, selectedlang )

[<Fact>]
let User_Pick_Spanish() =
    let trashData = new StringWriter()
    System.Console.SetOut(trashData)
    let userInput = new StringReader("2")
    System.Console.SetIn(userInput)
    let selectedlang = int (newCurrentLanguage())
    let correctLang = int language.spanish
    Assert.Equal(correctLang, selectedlang )

[<Fact>]
let Read_Output() =
    let trashData = new StringWriter()
    System.Console.SetOut(trashData)
    let programInput = new StringReader("1")
    System.Console.SetIn(programInput)
    let io = new InputOut()
    let programOutput = new StringWriter()
    System.Console.SetOut(programOutput)
    io.printNoScreenFlush([Your_Going_First])
    Assert.Equal("Your going first", programOutput.ToString().TrimEnd())

[<Fact>]
let Read_Output_No_Trans() =
    let trashData = new StringWriter()
    System.Console.SetOut(trashData)
    let programInput = new StringReader("1")
    System.Console.SetIn(programInput)
    let io = new InputOut()
    let programOutput = new StringWriter()
    System.Console.SetOut(programOutput)
    io.printNoScreenFlushNoTranslate(["Hello"])
    Assert.Equal("Hello", programOutput.ToString().TrimEnd())

[<Fact>]
let Clean_Screen()=
    let io = new InputOut()
    ( fun() -> io.cleanScreen() |> ignore) |> should throw typeof<System.IO.IOException>

[<Fact>]
let User_Input()=
    let trashData = new StringWriter()
    System.Console.SetOut(trashData)
    let padInput = new StringReader("1")
    System.Console.SetIn(padInput)
    let io = new InputOut()
    let userInput = new StringReader("1")
    System.Console.SetIn(userInput)
    Assert.Equal("1", io.getUserInput())
