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

