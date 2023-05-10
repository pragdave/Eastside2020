
/////////////////////////////////// ignore this ////////////////////////
let check expected actual =
  match expected = actual  with
  | true  -> printfn "OK"
  | false -> printfn "Error: expected '%A', got '%A'" expected actual
/////////////////////////// stop ignoring now /////////////////////////

// This week we're looking at lists and the recusrive functions that
// process them
//
// Here's some test data

let shopping = [ "bread"; "milk"; "butter" ]
let numbers  = [ 1..10 ]

// And here's an example  -- (0)
let rec length list =
  match list with
  | [] -> 0
  | head :: tail -> 1 + length tail

check 3 (length shopping)
check 10 (length numbers)

// ----- (1)
// write a function to sum the elements in a list
//
// let sum list = "your code goes here"
// check 55 (sum numbers)

// ----- (2)
// write a function that returns `true` if a list contains
// a given element, false otherwise
//
// A good way to do this is to use a `when` clause. These are associated
// with pattern matches, and can be used to check the actual values
// being matched. For example
//
//     lec rec countPositive list =
//       match list with
//       | head::tail when head > 0 -> 1 + countPositive(tail)
//       | head::tail -> countPositive(tail)
//
//

let rec contains list element =
  match list with
  | [] -> false
  | head :: tail when head = element -> true
  | head :: tail -> contains tail element


check true (contains numbers 4)
check false (contains numbers 44)
check true (contains shopping "milk")
check false (contains shopping "toilet-paper")

// ---- (3)
//write the list [1;2;3;4] using :: notation
//
let answer = 1::2::3::4::[];;
check [1;2;3;4] answer

// ---- (4)
// You can pattern match against multiple elements at the start of a
// list, and you can pattern match aginst fixed sized lists:
//
//    match list when
//    | [ x ] -> "list contains exactly on element (which gets put in `x`)
//    | h1::h2::t -> "list is at least 2 elements long. The first two
//                     are put in h1 and h2, and the rest in t.
//
// Write a function that returns `true` if a list has an even number of
// elements, false otherwise. And empty list _does_ have an even number
// of elements.
//
let rec evenLength list =
  match list with
  | [] -> true
  | [_] -> false
  | _ :: _ :: rest -> evenLength rest

check true (evenLength [])
check false (evenLength [1])
check false (evenLength [1;3;5])
check true (evenLength [1;3])
