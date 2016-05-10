module InputOutPutTest
open InputOutPut
open Xunit
open FsUnit
open System.IO

[<Fact>]
let Read_Output() =
    let programOutput = new StringWriter()
    System.Console.SetOut(programOutput)
    let io = new InputOut()

    io.printNoScreenFlush(["Hello World"])
    Assert.Equal("Hello World", programOutput.ToString().TrimEnd())

[<Fact>]
let Clean_Screen()=
    let io = new InputOut()
    ( fun() -> io.cleanScreen() |> ignore) |> should throw typeof<System.IO.IOException>

[<Fact>]
let User_Input()=
    let programOutput = new StringReader("1")
    System.Console.SetIn(programOutput)
    let io = new InputOut()

    Assert.Equal("1", io.getUserInput())
