module Melxl.DataAccess.SqlFunProvider

open System.Data.SQLite
open SqlFun
open Melxl.Domain
open Queries
open GeneratorConfig
open Sqlite

let connectionString = "Data Source=C:\Users\MSbook\RiderProjects\Melxl\Melxl.DataAccess\SqlData\Persons.db"
let createConnection() = new SQLiteConnection(connectionString)
let generatorConfig = createDefaultConfig createConnection |> representDatesAsStrings
let run f = DbAction.run createConnection f
let sql commandText = sql generatorConfig commandText

type TestQueries() =
    static member getPersons: DbAction<Person list> = sql "select * from Persons"