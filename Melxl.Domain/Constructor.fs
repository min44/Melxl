namespace Melxl.Domain

open System

[<RequireQualifiedAccess>]
module PersonConstructor =
    let Create name age gender =
        { Id = Random().Next(10000, 99999)
          Name = name
          Age = age
          Gender = gender
          Parameters = [] }