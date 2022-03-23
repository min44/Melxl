module Melxl.Program

open Melxl
open Melxl.Domain
open Provider

let Persons = Info |> Seq.map Person
let Finder = Persons |> Seq.head |> Finder
let searchingResult = Finder.FindTreasure()

match searchingResult with
| Ok value -> printfn $"{value}"
| Error value -> printfn $"{value}"

