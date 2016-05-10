module IInputOutPut

type IInputOut = 
    abstract member printNoScreenNoFlush : list<string> -> unit
    abstract member print : list<string> -> unit
    abstract member getUserInput : unit -> string

