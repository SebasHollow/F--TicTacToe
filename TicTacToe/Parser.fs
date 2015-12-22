module Parser

let splitComma (s : string) (c : char) = s.Split[|c|]
let splitSlash (s : string) = 
    let sepAry = [|"\""|]
    let splits = s.Split (sepAry, System.StringSplitOptions.None)
    splits.[1]

let parseValue (s : string) : (int * int * char)=
    let elems = splitComma s ';'
    let x = System.Int32.Parse elems.[1]
    let y = System.Int32.Parse elems.[3]
    let c = splitSlash elems.[5]
    (x, y, c.[0])


let parseElems (s : string) =
    match s with
    | "" | null -> []
    | _ -> let strings = splitComma s 'm' |> Array.toList
           strings.Tail

let parse (s : string) : (int * int * char)list =
    parseElems s |> List.map parseValue
