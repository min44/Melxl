module Melxl.Program

open FSharp.Interop.Excel

module private Data = 
    type DataTypes = ExcelFile<"Data\Data.xlsx">
    type Row = DataTypes.Row
    let dataTypes = new DataTypes()
    let nameNotIsNull (row:Row) = row.Name |> isNull |> not
    let data = dataTypes.Data |> Seq.filter nameNotIsNull |> List.ofSeq

open Data
let persons = data |> List.map (fun x -> x.Name)

printf $"{persons}"
