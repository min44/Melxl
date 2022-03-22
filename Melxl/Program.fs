module Melxl.Program

open Melxl
open Melxl.Domain
open Provider
open Export

let personsGreetings =
    Info
    |> Seq.map Person
    |> Seq.map(fun x -> x.GreetingsText)

personsGreetings |> ExportToExcel |> OpenTable

let plusOne x y = x 2 + y
let interFunc y = plusOne float y 
let listOne = [1.0 .. 10.0]
let listPlusOne = Seq.map interFunc listOne