module Melxl.DataAccess.SqlProvider

open System.Collections.Generic
open System.Collections
open FSharp.Data.Sql
open FSharp.Data.Sql.Common
open Melxl.Domain
open Melxl.Utils
open Debugs

let [<Literal>] connectionString = "Data Source=C:\Users\MSbook\RiderProjects\Melxl\Melxl.DataAccess\SqlData\data.db; Version=3; foreign keys=true"
let [<Literal>] resolutionPath = @"C:\Users\MSbook\.nuget\packages\system.data.sqlite.core\1.0.111\lib\netstandard2.0"


type sql =
    SqlDataProvider<
        DatabaseProviderTypes.SQLITE,
        SQLiteLibrary=SQLiteLibrary.SystemDataSQLite,
        ConnectionString=connectionString,
        ResolutionPath=resolutionPath,
        CaseSensitivityChange=CaseSensitivityChange.ORIGINAL>
        
let ctx = sql.GetDataContext()
let personsContext = ctx.Main.Persons


let AddNewPersonsAsync() =
    Logger.Debug("AddNewPersonsAsync")
    let alex = personsContext.``Create(Age, Name)``(20, "Alex")
    personsContext.``Create(Age, Name)``(21, "Helen") |> ignore
    personsContext.``Create(Age, Name)``(18, "Wolf")  |> ignore
    personsContext.``Create(Age, Name)``(28, "Andre") |> ignore
    Logger.Debug($"alex: {alex.Name} created")
    ctx.SubmitUpdatesAsync()

let MapToPerson (ctx: sql.dataContext.``main.PersonsEntity``) =
    { Id = int ctx.Id
      Name = ctx.Name
      Age = int ctx.Age
      IsSelected = false }

let GetPersons() =
    Logger.Debug("GetPersons")
    query { for row in personsContext do select row }
    |> Seq.map MapToPerson |> Seq.toList
    
let RemovePersons ids =
    Logger.Debug("RemovePersons")
    PrintSeq ids
    let ids = ids |> Seq.map int64 |> Seq.toArray
    query {
        for row in personsContext do
        where (System.Collections.Immutable.ImmutableArray.Create<int64>(ids).Contains(row.Id))
        select row.Id
    }
    |> Seq.``delete all items from single table``
    |> Async.RunSynchronously