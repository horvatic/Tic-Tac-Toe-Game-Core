module ScreenEditTest
open ScreenEdit
open Xunit
open FsUnit
open TicTacToeBoxClass
open ScreenEditTestInputOut
open Translate

[<Fact>]
let Board_Of_3X3_Simple_Message_Inverted() =
    let board = new TicTacToeBox(["-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"])
    let correctOutput = 
                [
                "-------------------------------------------------";
                "|\t"+ board.getGlyphAtLocation(2)+"\t|\t"+ board.getGlyphAtLocation(1)+"\t|\t"+ board.getGlyphAtLocation(0)+"\t|";
                "-------------------------------------------------";
                "|\t"+ board.getGlyphAtLocation(5)+"\t|\t"+ board.getGlyphAtLocation(4)+"\t|\t"+ board.getGlyphAtLocation(3)+"\t|";
                "-------------------------------------------------";
                "|\t"+ board.getGlyphAtLocation(8)+"\t|\t"+ board.getGlyphAtLocation(7)+"\t|\t"+ board.getGlyphAtLocation(6)+"\t|";
                "-------------------------------------------------";
                ]
    let io = new InputOutTestGame(correctOutput, [Blank;])
    writeToScreen(board)(true)(Blank)(io)

[<Fact>]
let Board_Of_3X3_Simple_Message_Non_Inverted() =
    let board = new TicTacToeBox(["-1-"; "-2-"; "-3-"; "-4-"; "-5-"; "-6-"; "-7-"; "-8-"; "-9-"])
    let correctOutput = 
                [
                "-------------------------------------------------";
                "|\t"+ board.getGlyphAtLocation(0)+"\t|\t"+ board.getGlyphAtLocation(1)+"\t|\t"+ board.getGlyphAtLocation(2)+"\t|";
                "-------------------------------------------------";
                "|\t"+ board.getGlyphAtLocation(3)+"\t|\t"+ board.getGlyphAtLocation(4)+"\t|\t"+ board.getGlyphAtLocation(5)+"\t|";
                "-------------------------------------------------";
                "|\t"+ board.getGlyphAtLocation(6)+"\t|\t"+ board.getGlyphAtLocation(7)+"\t|\t"+ board.getGlyphAtLocation(8)+"\t|";
                "-------------------------------------------------";
                ]
    let io = new InputOutTestGame(correctOutput, [Blank;])
    writeToScreen(board)(false)(Blank)(io)

[<Fact>]
let Board_Of_4X4_Simple_Message_Inverted() =
    let board = new TicTacToeBox(["X"; "X"; "X"; "-4-"; 
                                "-5-"; "-6-"; "-7-"; "-8-"; 
                                "@"; "@"; "@"; "@";
                                "-13-"; "-14-"; "-15-"; "-16-"])
    let correctOutput = 
            [
             "-----------------------------------------------------------------";
             "|\t"+ board.getGlyphAtLocation(3)+"\t|\t"+ board.getGlyphAtLocation(2)+"\t|\t"+ board.getGlyphAtLocation(1)+"\t|\t"+ board.getGlyphAtLocation(0)+"\t|";
             "-----------------------------------------------------------------";
             "|\t"+ board.getGlyphAtLocation(7)+"\t|\t"+ board.getGlyphAtLocation(6)+"\t|\t"+ board.getGlyphAtLocation(5)+"\t|\t"+ board.getGlyphAtLocation(4)+"\t|";
             "-----------------------------------------------------------------";
             "|\t"+ board.getGlyphAtLocation(11)+"\t|\t"+ board.getGlyphAtLocation(10)+"\t|\t"+ board.getGlyphAtLocation(9)+"\t|\t"+ board.getGlyphAtLocation(8)+"\t|";
             "-----------------------------------------------------------------";
             "|\t"+ board.getGlyphAtLocation(15)+"\t|\t"+ board.getGlyphAtLocation(14)+"\t|\t"+ board.getGlyphAtLocation(13)+"\t|\t"+ board.getGlyphAtLocation(12)+"\t|";
             "-----------------------------------------------------------------";
            ]
    let io = new InputOutTestGame(correctOutput, [Blank;])
    writeToScreen(board)(true)(Blank)(io)

[<Fact>]
let Board_Of_4X4_Simple_Message_Non_Inverted() =
    let board = new TicTacToeBox(["X"; "X"; "X"; "-4-"; 
                                "-5-"; "-6-"; "-7-"; "-8-"; 
                                "@"; "@"; "@"; "@";
                                "-13-"; "-14-"; "-15-"; "-16-"])
    let correctOutput = 
            [
             "-----------------------------------------------------------------";
             "|\t"+ board.getGlyphAtLocation(0)+"\t|\t"+ board.getGlyphAtLocation(1)+"\t|\t"+ board.getGlyphAtLocation(2)+"\t|\t"+ board.getGlyphAtLocation(3)+"\t|";
             "-----------------------------------------------------------------";
             "|\t"+ board.getGlyphAtLocation(4)+"\t|\t"+ board.getGlyphAtLocation(5)+"\t|\t"+ board.getGlyphAtLocation(6)+"\t|\t"+ board.getGlyphAtLocation(7)+"\t|";
             "-----------------------------------------------------------------";
             "|\t"+ board.getGlyphAtLocation(8)+"\t|\t"+ board.getGlyphAtLocation(9)+"\t|\t"+ board.getGlyphAtLocation(10)+"\t|\t"+ board.getGlyphAtLocation(11)+"\t|";
             "-----------------------------------------------------------------";
             "|\t"+ board.getGlyphAtLocation(12)+"\t|\t"+ board.getGlyphAtLocation(13)+"\t|\t"+ board.getGlyphAtLocation(14)+"\t|\t"+ board.getGlyphAtLocation(15)+"\t|";
             "-----------------------------------------------------------------";
            ]
    let io = new InputOutTestGame(correctOutput, [Blank;])
    writeToScreen(board)(false)(Blank)(io)