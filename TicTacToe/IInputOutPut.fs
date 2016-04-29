module IInputOutPut

type IInputOut = 
    abstract member print : array<string> -> unit
    abstract member getUserInput : unit -> string

