module Composer

let addToList string =
    sprintf "l[%s]" string

let squareToString (x, y, c) : string =
    sprintf "m[\"x\"; %d; \"y\"; %d; \"v\"; \"%c\"]" x y c


let serialize (list:(int * int * char)list) =
    let rec serialize2nd string (list:(string)list) =
        if list.IsEmpty then string
        else let newString = string + "; " + list.Head
             serialize2nd newString list.Tail

    let sqStrings = List.map squareToString list
    let members = serialize2nd sqStrings.Head sqStrings.Tail
    addToList members