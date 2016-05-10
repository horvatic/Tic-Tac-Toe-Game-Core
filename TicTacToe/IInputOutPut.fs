module IInputOutPut

type IInputOut = 
    abstract member printNoScreenFlush : list<string> -> unit
    abstract member cleanScreen : unit -> unit
    abstract member getUserInput : unit -> string

