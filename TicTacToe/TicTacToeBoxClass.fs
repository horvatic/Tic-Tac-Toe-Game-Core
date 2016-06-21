namespace TicTacToe.Core 

module TicTacToeBoxClass =
    open ITicTacToeBoxClass
    open System

    exception IndexOutOfBoundsException of unit
    exception SpotTakenException of unit

    type TicTacToeBox(newTicTacToeBoard : list<string>) =
        member val private ticTacToebox = newTicTacToeBoard
    
        member this.getGlyphAtLocation(postion : int) : string
            = (this :> ITicTacToeBox).getGlyphAtLocation(postion : int) : string
        member this.cellCount() : int
            = (this :> ITicTacToeBox).cellCount() : int
        member this.victoryCellCount() : int
            = (this :> ITicTacToeBox).victoryCellCount() : int
        member this.getTicTacToeBoxEdited(editPos : int)(editSymbol : string)(playerGlyph : string)
                                         (aIGlyph : string) : ITicTacToeBox 
            = (this :> ITicTacToeBox).getTicTacToeBoxEdited(editPos : int)
                                                           (editSymbol : string)(playerGlyph : string)
                                                           (aIGlyph : string) : ITicTacToeBox 

        interface ITicTacToeBox with
            member this.cellCount() : int =
                this.ticTacToebox.Length

            member this.getGlyphAtLocation(postion : int) : string =
                if postion > this.ticTacToebox.Length - 1 || postion  < 0 then
                    raise(IndexOutOfBoundsException())
                this.ticTacToebox.[postion]

            member this.victoryCellCount() : int =
                int (sqrt(float this.ticTacToebox.Length))

            member this.getTicTacToeBoxEdited(editPos : int)(editSymbol : string)(playerGlyph : string)(aIGlyph : string) 
                : ITicTacToeBox = 
                if editPos > this.ticTacToebox.Length - 1 || editPos  < 0 then
                    raise(IndexOutOfBoundsException())
                let ticTacToeBox =(new TicTacToeBox 
                                    (
                                        [
                                        for i in 0 .. this.ticTacToebox.Length - 1 -> 
                                            (if editPos = i then
                                                if playerGlyph = this.ticTacToebox.[i] || aIGlyph = this.ticTacToebox.[i] then
                                                    raise(SpotTakenException())
                                                editSymbol
                                            else
                                                this.ticTacToebox.[i])
                                        ]
                                    )
                               )
                ticTacToeBox :> ITicTacToeBox
