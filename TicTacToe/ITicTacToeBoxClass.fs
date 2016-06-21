namespace TicTacToe.Core 

module ITicTacToeBoxClass =

    type ITicTacToeBox =
        abstract member cellCount : unit -> int
        abstract member getGlyphAtLocation : int -> string
        abstract member victoryCellCount : unit -> int
        abstract member getTicTacToeBoxEdited : int -> string -> string -> string -> ITicTacToeBox
