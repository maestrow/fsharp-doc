(**
# F# Cheat Sheet

## let

**let** is used to bind a name to a value. 
Each binding has a type.

*)

module valueBindings = 
  let anInt = 10
  let aFloat = 20.0
  let aString = "I'm a string!"

(**
### mutable
*)

module mulable =
  let mutable modifiable = "original value"
  modifiable <- "new value"

(**
## Functions

### Type will be inferred
*)

module inferred =
  let add x y =
    x + y
  add 2 2

(**
### Specify type explicitly
*)
module Specify_type_explicitly =
  let toHackerTalk (phrase:string) : string =
    phrase.Replace('t', '7').Replace('o', '0')

(**
### Anonymous functioncs
*)
module Anonymous =
  let twoTest test =
    test 2
  twoTest (fun x -> x < 0)

(**
### Recursive
*)
module Recursive =
  let rec slowMultiply a b =
    if b > 1 then
      a + slowMultiply a (b - 1)
    else
      a

(**
### Tail recursion
*)
module Tail =
  let slowMultiply a b =
    let rec loop acc counter =
      if counter > 1 then
        loop (acc + a) (counter - 1) (* tail recursive *)
      else
        acc
    loop a b

(**
### Currying and Partial Functions
*)
module Currying =
  open System
  let add x y = x + y
  let addFive = add 5
  Console.WriteLine(addFive 12) // prints 17

(**
### Chaining
*)
module Chaining =
  [0..100]
  |> List.filter (fun x -> x % 2 = 0)
  |> List.map (fun x -> x * 2)
  |> List.sum

(**
### Composition

How composition function declared
*)
module delaration =
  let inline (<<) f g x = f (g x)
  let inline (>>) f g x = g (f x)

(**
Samples
*)
module Composition_sample =
  let square x = x*x
  let half x = x/2
  let inc x = x+1
  4 |> (square >> half >> inc)  |> printfn "%d"

(**
## Pattern matching
*)
module Pattern_matching =
  let fn expr = 
    match expr with
    | (1, 1)
    | (2, 2) -> "ones or twos"
    | (a, b) when a > b -> sprintf "%d > %d" a b
    | (a, b) when a < b -> sprintf "%d < %d" a b
    | _ -> "default result"
  fn (5, 6)

(**
### Short functional syntax
*)
module Short_functional_syntax =
  let rec factorial = function
    | 0 | 1 -> 1
    | n -> n * factorial (n - 1)

(**
## Data Structures

### Lists & Arrays
*)
module lists =
  let list1 = [2; 4; 6; 8]
  let array1 = [|2;3|]
  let array2 = [|1..10|]
  array2.[2] (*element access*)

(**
### Sequences

Elements in the sequence are lazily evaluated, meaning that F# does not compute values in a sequence until the values are actually needed.
The seq type is defined as follows:
*)
module Sequences =
  type seq<'a> = System.Collections.Generic.IEnumerable<'a>

  let allEvens = 
    let rec loop x = seq { yield x; yield! loop (x + 2) }
    loop 0
  
  for a in (Seq.take 5 allEvens) do
    printfn "%i" a

