// Learn more about F# at http://fsharp.org

let shopping = [ "bread"; "milk"; "butter" ]
let numbers  = [ 1..10 ]

let rec length list =
  match list with
  | [] -> 0
  | head :: tail -> 1 + length tail
// empty
// head :: tail