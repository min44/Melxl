module Melxl.Provider

open System
open FSharp.Interop.Excel
open Melxl.Domain
open Reflection

module private Data = 
    type DataTypes = ExcelFile<"Data\Info.xlsx", ForceString=true>
    type Row = DataTypes.Row
    let dataTypes = new DataTypes()
    let nameNotIsNull (row:Row) = row.Name |> isNull |> not
    let data = dataTypes.Data |> Seq.filter nameNotIsNull |> List.ofSeq
    let createInfo (r: Row) =
        PersonInfoConstructor.Create
            r.Name
            (Int32.Parse r.Age)
            (GetCaseByName r.Gender)
    let info = Seq.map createInfo data 

open Data
let Info = info