﻿module Test
open Xunit 
open CleanInput
open FsUnit

[<Fact>]   // test
let Sanitize_5_String_To_5() =
    Assert.Equal(5, Sanitize "5" )

[<Fact>]   // test
let Sanitize_fail_String_To_Exception() =
    (fun () -> Sanitize "fe" |> ignore) |> should throw typeof<NonIntError>