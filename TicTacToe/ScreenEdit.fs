module ScreenEdit
open GameSettings
open IInputOutPut
exception InvaildBox of string

let invertedScreen(ticTacToeBox : array<string>)
                  (message : string)
                  (io : IInputOut) : unit =
    if ticTacToeBox.Length = 9 then
            let package = 
                [|
                 message;
                "-------------------------------------------------";
                "|\t"+string ticTacToeBox.[2]+"\t|\t"+string ticTacToeBox.[1]+"\t|\t"+string ticTacToeBox.[0]+"\t|";
                "-------------------------------------------------";
                "|\t"+string ticTacToeBox.[5]+"\t|\t"+string ticTacToeBox.[4]+"\t|\t"+string ticTacToeBox.[3]+"\t|";
                "-------------------------------------------------";
                "|\t"+string ticTacToeBox.[8]+"\t|\t"+string ticTacToeBox.[7]+"\t|\t"+string ticTacToeBox.[6]+"\t|";
                "-------------------------------------------------";
                |]
            io.print(package)
    else
        let package = 
            [|
            message;
             "-----------------------------------------------------------------";
             "|\t"+string ticTacToeBox.[3]+"\t|\t"+string ticTacToeBox.[2]+"\t|\t"+string ticTacToeBox.[1]+"\t|\t"+string ticTacToeBox.[0]+"\t|";
             "-----------------------------------------------------------------";
             "|\t"+string ticTacToeBox.[7]+"\t|\t"+string ticTacToeBox.[6]+"\t|\t"+string ticTacToeBox.[5]+"\t|\t"+string ticTacToeBox.[4]+"\t|";
             "-----------------------------------------------------------------";
             "|\t"+string ticTacToeBox.[11]+"\t|\t"+string ticTacToeBox.[10]+"\t|\t"+string ticTacToeBox.[9]+"\t|\t"+string ticTacToeBox.[8]+"\t|";
             "-----------------------------------------------------------------";
             "|\t"+string ticTacToeBox.[15]+"\t|\t"+string ticTacToeBox.[14]+"\t|\t"+string ticTacToeBox.[13]+"\t|\t"+string ticTacToeBox.[12]+"\t|";
             "-----------------------------------------------------------------";
            |]
        io.print(package)
let nonInvertedScreen(ticTacToeBox : array<string>)
                     (message : string)
                     (io : IInputOut) : unit =
    if ticTacToeBox.Length = 9 then
        let package = 
            [|
            message;
            "-------------------------------------------------";
            "|\t"+string ticTacToeBox.[0]+"\t|\t"+string ticTacToeBox.[1]+"\t|\t"+string ticTacToeBox.[2]+"\t|";
            "-------------------------------------------------";
            "|\t"+string ticTacToeBox.[3]+"\t|\t"+string ticTacToeBox.[4]+"\t|\t"+string ticTacToeBox.[5]+"\t|";
            "-------------------------------------------------";
            "|\t"+string ticTacToeBox.[6]+"\t|\t"+string ticTacToeBox.[7]+"\t|\t"+string ticTacToeBox.[8]+"\t|";
            "-------------------------------------------------";
            |]
        io.print(package)

    else
        let package = 
            [|
             message;
             "-----------------------------------------------------------------";
             "|\t"+string ticTacToeBox.[0]+"\t|\t"+string ticTacToeBox.[1]+"\t|\t"+string ticTacToeBox.[2]+"\t|\t"+string ticTacToeBox.[3]+"\t|";
             "-----------------------------------------------------------------";
             "|\t"+string ticTacToeBox.[4]+"\t|\t"+string ticTacToeBox.[5]+"\t|\t"+string ticTacToeBox.[6]+"\t|\t"+string ticTacToeBox.[7]+"\t|";
             "-----------------------------------------------------------------";
             "|\t"+string ticTacToeBox.[8]+"\t|\t"+string ticTacToeBox.[9]+"\t|\t"+string ticTacToeBox.[10]+"\t|\t"+string ticTacToeBox.[11]+"\t|";
             "-----------------------------------------------------------------";
             "|\t"+string ticTacToeBox.[12]+"\t|\t"+string ticTacToeBox.[13]+"\t|\t"+string ticTacToeBox.[14]+"\t|\t"+string ticTacToeBox.[15]+"\t|";
             "-----------------------------------------------------------------";
            |]
        io.print(package)

let writeToScreen(ticTacToeBox : array<string>)
                 (inverted : bool )(message : string)
                 (io : IInputOut) : unit =
    if not inverted then
        nonInvertedScreen(ticTacToeBox)(message)(io)
    else
        invertedScreen(ticTacToeBox)(message)(io)

