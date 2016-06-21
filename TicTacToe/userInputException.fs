namespace TicTacToe.Core 

module userInputException =

    exception InvaildGlyph of unit
    exception InvaildSizeOfBox of unit
    exception InvaildPlayer of unit
    exception OutOfBoundsOverFlow of unit
    exception OutOfBoundsUnderFlow of unit