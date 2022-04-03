module Melxl.DataAccess.Provider

module private Data =
    open System
    open FSharp.Interop.Excel
    open Melxl.Utils
    open Melxl.Domain
    open Reflection
    type DataTypes = ExcelFile<"C:\Users\MSbook\RiderProjects\Melxl\Melxl.DataAccess\ExcelData\Info.xlsx", ForceString=true>
    type Row = DataTypes.Row
    let dataTypes = DataTypes()
    let nameNotIsNull (row:Row) = row.Name |> isNull |> not
    let data = dataTypes.Data |> Seq.filter nameNotIsNull |> List.ofSeq
    let createInfo (r: Row) =
        PersonConstructor.Create
            r.Name
            (Int32.Parse r.Age)
            (GetCaseByName r.Gender)
    let persons = Seq.map createInfo data |> Seq.toList

open Data
let GetAllPersons() = persons