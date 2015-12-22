#light
namespace TicTacToe
module Main =
    [<EntryPoint>]
    let main args =
        //Some random gibber to make our life easier
        let gameID = "toast7"
        let string = "l[m[\"x\"; 2; \"y\"; 0; \"v\"; \"x\"]; m[\"x\"; 0; \"y\"; 2; \"v\"; \"o\"]; m[\"x\"; 1; \"y\"; 2; \"v\"; \"x\"]; m[\"x\"; 0; \"y\"; 0; \"v\"; \"o\"]; m[\"x\"; 0; \"y\"; 1; \"v\"; \"x\"]; m[\"x\"; 1; \"y\"; 1; \"v\"; \"o\"]; m[\"x\"; 2; \"y\"; 1; \"v\"; \"x\"]; m[\"x\"; 1; \"y\"; 0; \"v\"; \"o\"]; m[\"x\"; 2; \"y\"; 2; \"v\"; \"x\"]]"
        let moveBoard = Parser.parse string
        System.Console.WriteLine(sprintf "board = %O" moveBoard)
        TicTacToe.justDoIt gameID moveBoard

        0