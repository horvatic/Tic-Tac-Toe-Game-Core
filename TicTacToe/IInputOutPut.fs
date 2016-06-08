namespace TicTacToe.Core 
module IInputOutPut =

    type IInputOut = 
        abstract member printNoScreenFlush : list<int> -> unit
        abstract member printNoScreenFlushNoTranslate : list<string> -> unit
        abstract member cleanScreen : unit -> unit
        abstract member getUserInput : unit -> string

