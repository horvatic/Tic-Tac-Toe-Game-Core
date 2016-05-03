module ITicTacToeBoxClass

type ITicTacToeBox =
    abstract member cellCount : unit -> int
    abstract member victoryCellCount : unit -> int
    abstract member getCellGlyph : int -> string    
    abstract member insertCellGlyphAt : int -> string -> unit
    abstract member clone : unit -> ITicTacToeBox