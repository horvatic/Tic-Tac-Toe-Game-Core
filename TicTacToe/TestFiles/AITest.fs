module AITest
open Xunit 
open FsUnit
open AI
open CheckForWinnerOrTie

[<Fact>]   // test
let Check_If_Unbeatable() =
    let mutable place = -1
    let mutable currentPlayer = int playerVals.AI
    let mutable matchResult = int Result.NoWinner
    let mutable gameOver = false
    for i = 0 to 8 do
        let ticTacToeBox = [|"1"; "2"; "3"; "4"; "5"; "6"; "7"; "8"; "9"|]
        place <- -1
        currentPlayer <- int playerVals.AI
        matchResult <- int Result.NoWinner
        gameOver <- false
        ticTacToeBox.[i] <- "X"
        for i = 0 to 8 do
            if not gameOver then
                if currentPlayer = int playerVals.Human then
                    for i = 0 to 8 do
                        if ticTacToeBox.[i] = "X" then
                            ticTacToeBox.[i] <- "@"
                        elif ticTacToeBox.[i] = "@" then
                            ticTacToeBox.[i] <- "X"
                    place <- computerMove(ticTacToeBox)
                    for i = 0 to 8 do
                        if ticTacToeBox.[i] = "X" then
                            ticTacToeBox.[i] <- "@"
                        elif ticTacToeBox.[i] = "@" then
                            ticTacToeBox.[i] <- "X"
                    ticTacToeBox.[place] <- "X"
                else
                    place <- computerMove(ticTacToeBox)
                    ticTacToeBox.[place] <- "@"
                currentPlayer <- currentPlayer * -1
                matchResult <- checkForWinnerOrTie(ticTacToeBox)
                if not (matchResult = int Result.NoWinner) then
                    gameOver <- true
        Assert.Equal(int Result.Tie, int matchResult )