module UserSettings
exception InvaildSizeOfBox of string

type userSetting =
    struct 
       val mutable ticTacToeBox : array<string>
    end
    new(newTicTacToeBox : array<string>) = { ticTacToeBox = newTicTacToeBox }

let craftUserSetting(newTicTacToeBox : array<string>) : userSetting =
    if newTicTacToeBox.Length = 9 then
        userSetting(newTicTacToeBox)
    else
        raise(InvaildSizeOfBox("Invaild TicTacToe Box Size"))