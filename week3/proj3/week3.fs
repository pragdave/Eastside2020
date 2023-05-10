
/////////////////////////////////// ignore this ////////////////////////
let check expected actual =
  match expected = actual  with
  | true  -> printfn "OK"
  | false -> printfn "Error: expected '%A', got '%A'" expected actual
/////////////////////////// stop ignoring now /////////////////////////

// This week we're looking at reducers
//
// Here's some test data

let animals = [  "buffalo"; "elephant"; "cat"; "ant"; "dingo" ]
let numbers  = [4; -3; -7; 8; 1; 0; -5 ]




// ----- (1)
// write a function find the smallest number in
// a list. You'll want to use `List.reduce`, not `List.fold`
//
let smallest = List.reduce min
check -7 (smallest numbers)


// ----- (2)
// You can also use `min` and `max` with strings. A string is
// considered to be greater than another based on alphabetical ordering.
//
// Write a function to find the maximum element of a list
//
// let maxOf list = // your code...
//
let maxOf = List.reduce max
check "elephant" (maxOf animals)

// ---- (3)
// The function `String.length` returns the length of a string (duh).
//
// Write a function that returns the longest string in a
// list. If might be an idea to create a helper function
// that takes two strings and returns the longer one
//
let stringMax a b =
  if String.length a > String.length b
  then a
  else b

let longest  = List.reduce stringMax
check "elephant" (longest animals)


// ---- (4)
// Use List.fold to reverse a (potentially empty) list
//
let reverse list = List.fold (fun result next -> next::result) [] list
check [] (reverse [])
check [3;2;1] (reverse [1;2;3])
check [3] (reverse [3])
check ["cat";"bee";"ant"] (reverse ["ant";"bee";"cat"])
