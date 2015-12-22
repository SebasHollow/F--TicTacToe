namespace TicTacToe

module TicTacToe =
    open System
    open FSharp.Data
    open FSharp.Data.HttpRequestHeaders
         
    //Get and Post functions
    let postData url board = 
        let msg = Composer.serialize board
        Http.RequestString(url, headers = ["Content-Type", "application/m-expr+list"], body = TextRequest (msg))
    
    let getData url =
        let response = Http.RequestString(url, headers = ["Accept", "application/m-expr+list"], httpMethod = "GET")
        Parser.parse response

    //Action happens here:
    let justDoIt gameID (moveBoard:(Board.Square)list) = 
        let formatUrl gameID playerID =
            let i = sprintf "%i" playerID
            "http://tictactoe.homedir.eu/game/" + gameID + "/player/" + i
        let urlWithID = formatUrl gameID

        let rec getAndPost playerID =
            let url = urlWithID playerID
            let board = getData url
            let turn = board.Length

            if moveBoard.Length > turn
                then let newBoard = board@[Board.getSquareAt turn moveBoard]
                     let response = postData url newBoard
                     match playerID with
                     | 2 -> getAndPost 2
                     | 1 -> getAndPost 2
                     | _ -> raise (System.ArgumentException("Uh-oh! Something went wrong."))
        
        //First POST
        //let we = postData (urlWithID 1) [moveBoard.Head]
        //System.Console.WriteLine(sprintf "%O" we)
        getAndPost 2
