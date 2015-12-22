module ParserTests

open System.Text.RegularExpressions
open NUnit.Framework
open FsUnit
open FsCheck
open FsCheck.Xunit

let isThrashSymbol c =
    match c with
    | ';' -> true
    | 'm' -> true
    | '"' -> true
    | _ -> false

[<Property>]
let fullSerialization x y c =
    if not (isThrashSymbol c) then
        let board = [(x, y, c)]
        let board2 = (Composer.serialize board) |> Parser.parse
        board = board2
    else true

[<Property>]
let ayySquare x y c =
    if not (isThrashSymbol c) then
        let square = (x, y, c)
        let square2 = Composer.squareToString square |> Parser.parseValue 
        square = square2
    else true

[<Test>]
let ``I didn't touch your square!`` () =
    Check.Quick ayySquare

[<Test>]
let ``Just as new`` () =
    Check.Quick fullSerialization
