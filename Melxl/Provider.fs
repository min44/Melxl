module Melxl.Provider

open System
open FSharp.Interop.Excel
open Melxl.Domain
open Reflection

module private Data = 
    type DataTypes = ExcelFile<"Data\Persons.xlsx", ForceString=true>
    type Row = DataTypes.Row
    let dataTypes = new DataTypes()
    let nameNotIsNull (row:Row) = row.Name |> isNull |> not
    let data = dataTypes.Data |> Seq.filter nameNotIsNull |> List.ofSeq
    let createPerson (r: Row) =
        PersonConstructor.Create
            r.Name
            (Int32.Parse r.Age)
            (GetCaseByName r.Gender)
    let persons = data |> Seq.map createPerson 
    

open Data
let Persons = persons
