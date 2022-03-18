module Melxl.Program

open Melxl
open Melxl.Domain
open Provider


Persons
|> Seq.filter(fun x -> x.Gender = Male)
|> Seq.iter(fun x -> printfn $"{x.Name}")
// Nick and Franсois only