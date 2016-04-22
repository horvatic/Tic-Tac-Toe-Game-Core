module BuildAndStartGame
open Game
open GameSettings
open PlayerValues

let buildAndStartGame() = 
    let gameOptions = 
        craftGameSetting([|"1"; "2"; "3"; "4"; "5"; "6"; "7"; "8"; "9"|])
                        ("x")("O")(int playerVals.Human)(false)(false)
    startGame(gameOptions)
