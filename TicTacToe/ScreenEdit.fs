module ScreenEdit
open GameSettings
open IInputOutPut
open TicTacToeBoxClass
exception InvaildBox of string

let invertedScreen(board : TicTacToeBox)
                  (message : string)
                  (io : IInputOut) : unit =
    if board.ticTacToebox.Length = 9 then
            let package = 
                [
                 message;
                "-------------------------------------------------";
                "|\t"+string board.ticTacToebox.[2]+"\t|\t"+string board.ticTacToebox.[1]+"\t|\t"+string board.ticTacToebox.[0]+"\t|";
                "-------------------------------------------------";
                "|\t"+string board.ticTacToebox.[5]+"\t|\t"+string board.ticTacToebox.[4]+"\t|\t"+string board.ticTacToebox.[3]+"\t|";
                "-------------------------------------------------";
                "|\t"+string board.ticTacToebox.[8]+"\t|\t"+string board.ticTacToebox.[7]+"\t|\t"+string board.ticTacToebox.[6]+"\t|";
                "-------------------------------------------------";
                ]
            io.print(package)
    else
        let package = 
            [
            message;
             "-----------------------------------------------------------------";
             "|\t"+string board.ticTacToebox.[3]+"\t|\t"+string board.ticTacToebox.[2]+"\t|\t"+string board.ticTacToebox.[1]+"\t|\t"+string board.ticTacToebox.[0]+"\t|";
             "-----------------------------------------------------------------";
             "|\t"+string board.ticTacToebox.[7]+"\t|\t"+string board.ticTacToebox.[6]+"\t|\t"+string board.ticTacToebox.[5]+"\t|\t"+string board.ticTacToebox.[4]+"\t|";
             "-----------------------------------------------------------------";
             "|\t"+string board.ticTacToebox.[11]+"\t|\t"+string board.ticTacToebox.[10]+"\t|\t"+string board.ticTacToebox.[9]+"\t|\t"+string board.ticTacToebox.[8]+"\t|";
             "-----------------------------------------------------------------";
             "|\t"+string board.ticTacToebox.[15]+"\t|\t"+string board.ticTacToebox.[14]+"\t|\t"+string board.ticTacToebox.[13]+"\t|\t"+string board.ticTacToebox.[12]+"\t|";
             "-----------------------------------------------------------------";
            ]
        io.print(package)
let nonInvertedScreen(board : TicTacToeBox)
                     (message : string)
                     (io : IInputOut) : unit =
    if board.ticTacToebox.Length = 9 then
        let package = 
            [
            message;
            "-------------------------------------------------";
            "|\t"+string board.ticTacToebox.[0]+"\t|\t"+string board.ticTacToebox.[1]+"\t|\t"+string board.ticTacToebox.[2]+"\t|";
            "-------------------------------------------------";
            "|\t"+string board.ticTacToebox.[3]+"\t|\t"+string board.ticTacToebox.[4]+"\t|\t"+string board.ticTacToebox.[5]+"\t|";
            "-------------------------------------------------";
            "|\t"+string board.ticTacToebox.[6]+"\t|\t"+string board.ticTacToebox.[7]+"\t|\t"+string board.ticTacToebox.[8]+"\t|";
            "-------------------------------------------------";
            ]
        io.print(package)

    else
        let package = 
            [
             message;
             "-----------------------------------------------------------------";
             "|\t"+string board.ticTacToebox.[0]+"\t|\t"+string board.ticTacToebox.[1]+"\t|\t"+string board.ticTacToebox.[2]+"\t|\t"+string board.ticTacToebox.[3]+"\t|";
             "-----------------------------------------------------------------";
             "|\t"+string board.ticTacToebox.[4]+"\t|\t"+string board.ticTacToebox.[5]+"\t|\t"+string board.ticTacToebox.[6]+"\t|\t"+string board.ticTacToebox.[7]+"\t|";
             "-----------------------------------------------------------------";
             "|\t"+string board.ticTacToebox.[8]+"\t|\t"+string board.ticTacToebox.[9]+"\t|\t"+string board.ticTacToebox.[10]+"\t|\t"+string board.ticTacToebox.[11]+"\t|";
             "-----------------------------------------------------------------";
             "|\t"+string board.ticTacToebox.[12]+"\t|\t"+string board.ticTacToebox.[13]+"\t|\t"+string board.ticTacToebox.[14]+"\t|\t"+string board.ticTacToebox.[15]+"\t|";
             "-----------------------------------------------------------------";
            ]
        io.print(package)

let writeToScreen(board : TicTacToeBox)
                 (inverted : bool )(message : string)
                 (io : IInputOut) : unit =
    if not inverted then
        nonInvertedScreen(board)(message)(io)
    else
        invertedScreen(board)(message)(io)
