module Melxl.Program

open Melxl
open Melxl.Domain
open Provider


Persons
|> Seq.filter(fun x -> x.Gender = NonBinary Xenogender )
|> Seq.iter(fun x -> printfn $"{x.Name}")
// Nick and Franсois only