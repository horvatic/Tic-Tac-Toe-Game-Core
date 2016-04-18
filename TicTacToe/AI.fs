module AI

let firstAIMove ( ticTacToeBox : array<string>) : int =
    let mutable moveVal = 0
    if not (ticTacToeBox.[4] = "X") then
        moveVal <- 4
    else
        moveVal <- 8
    moveVal
let blockTwoOnEdge( ticTacToeBox : array<string> )
                  ( search : string )
                  ( notSearching : string )
                  : int =
    let mutable moveVal = -1
    if ticTacToeBox.[1] = "X" && ticTacToeBox.[3] = "X"
        && not (ticTacToeBox.[0] = "@") && not (ticTacToeBox.[0] = "X") then 
        moveVal <- 0
    elif ticTacToeBox.[1] = "X" && ticTacToeBox.[6] = "X"
        && not (ticTacToeBox.[0] = "@") && not (ticTacToeBox.[0] = "X") then 
        moveVal <- 0
    elif ticTacToeBox.[1] = "X" && ticTacToeBox.[5] = "X"
        && not (ticTacToeBox.[2] = "@") && not (ticTacToeBox.[2] = "X") then 
        moveVal <- 2
    elif ticTacToeBox.[1] = "X" && ticTacToeBox.[8] = "X"
        && not (ticTacToeBox.[2] = "@") && not (ticTacToeBox.[2] = "X") then 
        moveVal <- 2
    elif ticTacToeBox.[3] = "X" && ticTacToeBox.[7] = "X"
        && not (ticTacToeBox.[6] = "@") && not (ticTacToeBox.[6] = "X") then 
        moveVal <- 6
    elif ticTacToeBox.[3] = "X" && ticTacToeBox.[8] = "X"
        && not (ticTacToeBox.[6] = "@") && not (ticTacToeBox.[6] = "X") then 
        moveVal <- 6
    elif ticTacToeBox.[5] = "X" && ticTacToeBox.[7] = "X"
        && not (ticTacToeBox.[8] = "@") && not (ticTacToeBox.[8] = "X") then 
        moveVal <- 8
    elif ticTacToeBox.[5] = "X" && ticTacToeBox.[6] = "X"
        && not (ticTacToeBox.[8] = "@") && not (ticTacToeBox.[8] = "X") then 
        moveVal <- 8
    moveVal

let bestMoveLittleInformation ( ticTacToeBox : array<string>)
             (userPos : int)
             (startConnor : bool)
             (startEdge : bool)
             : int =
    let mutable putPostion = userPos
    let mutable alreadyPlaces = false
    let mutable largeShiftPos = 6
    let mutable smallShiftPos = 3
    let mutable largeShiftNeg = 6
    let mutable smallShiftNeg = 3
    if startEdge then
        largeShiftPos <- largeShiftPos - 1
        smallShiftPos <- smallShiftPos - 1
        largeShiftNeg <- largeShiftNeg + 1
        smallShiftNeg <- smallShiftNeg + 1
    while not alreadyPlaces do
        if putPostion + largeShiftPos < 9  
            && ticTacToeBox.[putPostion] = "X" 
            && not startConnor then
            if not (ticTacToeBox.[putPostion + largeShiftPos] = "X" 
                || ticTacToeBox.[putPostion + largeShiftPos] = "@") then
                    putPostion <- putPostion + largeShiftPos
                    alreadyPlaces <- true
                else
                    putPostion <- putPostion + 1
        elif putPostion - largeShiftNeg > 0  
            && ticTacToeBox.[putPostion] = "X" 
            && not startConnor then
            if not (ticTacToeBox.[putPostion - largeShiftNeg] = "X" 
                || ticTacToeBox.[putPostion - largeShiftNeg] = "@") then
                    putPostion <- putPostion - largeShiftNeg
                    alreadyPlaces <- true
                else
                    putPostion <- putPostion + 1
        elif putPostion + smallShiftPos < 9  
            && ticTacToeBox.[putPostion] = "X" then
            if not (ticTacToeBox.[putPostion + smallShiftPos] = "X" 
                || ticTacToeBox.[putPostion + smallShiftPos] = "@") then
                putPostion <- putPostion + smallShiftPos
                alreadyPlaces <- true
            else
                putPostion <- putPostion + 1
        
        elif putPostion - smallShiftNeg > 0 
            && ticTacToeBox.[putPostion] = "X" then
            if not (ticTacToeBox.[putPostion - smallShiftNeg] = "X" 
                || ticTacToeBox.[putPostion - smallShiftNeg] = "@") then
                putPostion <- putPostion - smallShiftNeg
                alreadyPlaces <- true
            else
                putPostion <- putPostion + 1
        else
           putPostion <- putPostion + 1
        
        if putPostion >= 9 then
            putPostion <- 0
            while ticTacToeBox.[putPostion] = "X" 
                || ticTacToeBox.[putPostion] = "@" do
                putPostion <- putPostion + 1
            alreadyPlaces <- true
    putPostion

let bestMoveBeDiangle ( ticTacToeBox : array<string> )
                      ( search : string )
                      ( notSearching : string )
                      : int =
    let mutable nonSearchCnt = 0
    let mutable searchCnt = 0
    let mutable freePostion = -1
    let mutable offset = 0
    //going right
    while offset < 9 do
            if ticTacToeBox.[offset] = notSearching then
                nonSearchCnt <- nonSearchCnt + 1
            elif ticTacToeBox.[offset] = search then
                searchCnt <- searchCnt + 1
            else
                freePostion <- offset
            offset <- offset + 4
    //going left
    if not (searchCnt = 2 && nonSearchCnt = 0) then
        freePostion <- -1
        searchCnt <- 0
        nonSearchCnt <- 0
        offset <- 2
        while offset < 8 do
            if ticTacToeBox.[offset] = notSearching then
                nonSearchCnt <- nonSearchCnt + 1
            elif ticTacToeBox.[offset] = search then
                searchCnt <- searchCnt + 1
            else
                freePostion <- offset
            offset <- offset + 2
    if not (searchCnt = 2 && nonSearchCnt = 0) then
        freePostion <- -1
    freePostion

let bestMoveBeVertical ( ticTacToeBox : array<string> )
                       ( search : string )
                       ( notSearching : string )
                       : int =
    let mutable nonSearchCnt = 0
    let mutable searchCnt = 0
    let mutable freePostion = -1
    let mutable x = 0
    let mutable offset = 0
    while x < 3 do
        offset <- 0
        freePostion <- -1
        nonSearchCnt <- 0
        searchCnt <- 0
        while offset < 7 do
            if ticTacToeBox.[x+offset] = notSearching then
                nonSearchCnt <- nonSearchCnt + 1
            elif ticTacToeBox.[x+offset] = search then
                searchCnt <- searchCnt + 1
            else
                freePostion <- x+offset
            offset <- offset + 3
        if searchCnt = 2 && nonSearchCnt = 0 then
            x <- 99
            offset <- 99
        else
            freePostion <- -1
        x <- x+1
    freePostion

let bestMoveBeHorzontail ( ticTacToeBox : array<string> ) 
                         ( search : string )
                         ( notSearching : string )
                         : int =
    let mutable nonSearchCnt = 0
    let mutable searchCnt = 0
    let mutable freePostion = -1
    let mutable x = -1
    let mutable offset = 0
    while offset < 7 do
        x <- 0
        freePostion <- -1
        nonSearchCnt <- 0
        searchCnt <- 0
        while x < 3 do
            if ticTacToeBox.[x+offset] = notSearching then
                nonSearchCnt <- nonSearchCnt + 1
            elif ticTacToeBox.[x+offset] = search then
                searchCnt <- searchCnt + 1
            else
                freePostion <- x+offset
            x <- x+1
        if searchCnt = 2 && nonSearchCnt = 0 then
            x <- 99
            offset <- 99
        else
            freePostion <- -1
        offset <- offset + 3
    freePostion

let whichMove( ticTacToeBox : array<string>) 
             ( userPos : int )
             ( firstMove: bool )
             (startConnor : bool)
             (startEdge : bool)
             : int =
    let mutable moveVal = 0
    if not firstMove then
        moveVal <- bestMoveBeHorzontail(ticTacToeBox) ("@") ("X")
        if moveVal = -1 then
            moveVal <- bestMoveBeVertical(ticTacToeBox) ("@") ("X")
        if moveVal = -1 then
            moveVal <- bestMoveBeDiangle(ticTacToeBox) ("@") ("X")
        if moveVal = -1 then
            moveVal <- bestMoveBeHorzontail(ticTacToeBox) ("X") ("@")
        if moveVal = -1 then
            moveVal <- bestMoveBeDiangle(ticTacToeBox) ("X") ("@")
        if moveVal = -1 then
            moveVal <- bestMoveBeVertical(ticTacToeBox) ("X") ("@")
        if moveVal = -1 then
            moveVal <- blockTwoOnEdge(ticTacToeBox) ("X") ("@")
        if moveVal = -1 then
            moveVal <- bestMoveLittleInformation (ticTacToeBox)(userPos)(startConnor)(startEdge)
    else
        moveVal <- firstAIMove(ticTacToeBox)
    moveVal

let AIMove( ticTacToeBox : array<string>) 
          ( userPos : int )
          ( firstMove : bool )
          ( startConnor : bool)
          ( startEdge : bool)
          : array<string> =
    ticTacToeBox.[whichMove(ticTacToeBox)(userPos)(firstMove)(startConnor)(startEdge)] <- "@"
    ticTacToeBox
