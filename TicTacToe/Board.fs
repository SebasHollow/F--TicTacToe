module Board

type Square = (int * int * char)
let emptyBoard = [for a in 0 .. 2 do for b in 0 .. 2 do yield (a, b, ' ')]

let split n list =
    let rec not_a_loop xs = function
    | (0, ys) | (_, ([] as ys)) -> (List.rev xs), ys
    | (n, x::ys) -> not_a_loop (x::xs) (n-1, ys)
    not_a_loop [] (n, list)

let replaceSquare (list:(Square)list) (sq : Square) =

    let replaceAt n item list =
        let (a, b) = split n list
        a@item::b.Tail

    match sq with
    | (x, y, _) -> let i = 3 * x + y
                   replaceAt i sq list

let getSquareAt n list =
    let (a, b) = split n list
    b.Head


let replaceChar (sq : Square) (c : char) : Square = 
    match sq with
    | (a, b, _) -> (a, b, c)


let rec loadBoard board items : (Square)list =
    let length = List.length items
    //ToDo: Clean up
    let newBoard = replaceSquare 
    match length with
    | 0 -> board
    | 1 -> replaceSquare board items.Head
    | _ -> loadBoard (replaceSquare board items.Head) items.Tail

