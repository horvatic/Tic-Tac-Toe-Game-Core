module TicTacToeBoxClass
open ITicTacToeBoxClass
open System

exception IndexOutOfBoundsException of unit
exception SpotTakenException of unit

type TicTacToeBox(newTicTacToeBoard : list<string>) =
    member val private ticTacToebox = newTicTacToeBoard

    member this.cellCount() : int =
        this.ticTacToebox.Length

    member this.getGlyphAtLocation(postion : int) : string =
        if postion > this.ticTacToebox.Length - 1 || postion  < 0 then
            raise(IndexOutOfBoundsException())
        this.ticTacToebox.[postion]

    member this.victoryCellCount() : int =
        int (sqrt(float this.ticTacToebox.Length))

    member this.getTicTacToeBoxEdited(editPos : int, editSymbol : string, playerGlyph : string, aIGlyph : string) 
        : TicTacToeBox = 
        (new TicTacToeBox 
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
       
    (*
    member val private ticTacToeBoard = [|"-1-"; "-2-"; "-3-"; 
                                        "-4-"; "-5-"; "-6-"; 
                                        "-7-"; "-8-"; "-9-"|]
    
    member private this.isInBounds(position : int) : unit =
        if position < 1 then
            raise(IndexOutOfBoundsException("Index is too small"))
        elif position > 9 then
            raise(IndexOutOfBoundsException("Index is too large"))
        
    member this.clone() : ITicTacToeBox
        = (this :> ITicTacToeBox).clone() : ITicTacToeBox
    member this.cellCount() : int 
        = (this :> ITicTacToeBox).cellCount() : int
    member this.victoryCellCount() : int
        = (this :> ITicTacToeBox).victoryCellCount() : int
    member this.getCellGlyph(position : int) : string
        = (this :> ITicTacToeBox).getCellGlyph(position : int) : string
    member this.insertCellGlyphAt(position : int, glyph : string)
        = (this :> ITicTacToeBox).insertCellGlyphAt(position : int)(glyph : string)
    interface ITicTacToeBox with
        member this.clone() : ITicTacToeBox =
            let clonedBoard = new TicTacToeBox3X3()
            for i = 1 to this.cellCount() do
                if not (this.getCellGlyph(i) = "") then
                    clonedBoard.insertCellGlyphAt(i, this.getCellGlyph(i))
            clonedBoard :> ITicTacToeBox

        member this.cellCount() : int  =
            this.ticTacToeBoard.Length
      
        member this.victoryCellCount() : int =
            int (sqrt(float this.ticTacToeBoard.Length))
       
        member this.getCellGlyph(position : int) : string =
            this.isInBounds(position)
            if (String.Format("-{0}-", position) = this.ticTacToeBoard.[position - 1]) then
               ""
            else
                 this.ticTacToeBoard.[position - 1]


        member this.insertCellGlyphAt(position : int)(glyph : string) =
            this.isInBounds(position)
            if this.getCellGlyph(position) = "" then
                this.ticTacToeBoard.[position - 1] <- glyph
            else
                raise(SpotTakenException())
        *)