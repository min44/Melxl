module Melxl.Test



let data = [1;2;3;4;5;6;7]
let oddMaker x = x%2 = 0
let dataFiltered = data |> Seq.filter oddMaker  

printfn $"{dataFiltered}"
