module Melxl.DataAccess.SqlProvider

open FSharp.Data.Sql
open FSharp.Data.Sql.Common
open Melxl.Domain

[<Literal>]
let connectionString =
    "Data Source="
    + @"C:\Users\MSbook\RiderProjects\Melxl\Melxl.DataAccess\blogging.db;"
    +
    //    __SOURCE_DIRECTORY__ + @"/../../../tests/SqlProvider.Tests/scripts/northwindEF.db;" +
    "Version=3;foreign keys=true"

[<Literal>]
let resolutionPath =
    @"C:\Users\MSbook\.nuget\packages\system.data.sqlite.core\1.0.111\lib\netstandard2.0"

type sql =
    SqlDataProvider<
        DatabaseProviderTypes.SQLITE,
        SQLiteLibrary=SQLiteLibrary.SystemDataSQLite,
        ResolutionPath=resolutionPath,
        ConnectionString=connectionString,
        CaseSensitivityChange=CaseSensitivityChange.ORIGINAL>


let ctx = sql.GetDataContext()