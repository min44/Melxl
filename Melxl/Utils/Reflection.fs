module Melxl.Reflection

open System
open Microsoft.FSharp.Reflection

let GetCaseInfos<'T1> = FSharpType.GetUnionCases(typeof<'T1>)

let MakeCase<'T1> (caseInfo: UnionCaseInfo) = FSharpValue.MakeUnion(caseInfo, [||]) :?> 'T1

let rec GetAllCaseObjects t = [|
    for unionCaseInfo in FSharpType.GetUnionCases t do
        match unionCaseInfo.GetFields() with
        | [|propertyInfo|] when FSharpType.IsUnion propertyInfo.PropertyType ->
            for x in GetAllCaseObjects propertyInfo.PropertyType -> FSharpValue.MakeUnion(unionCaseInfo, [|x|])
        | _ -> yield FSharpValue.MakeUnion(unionCaseInfo, [||]) |]

let GetAllCases<'T1> = GetAllCaseObjects typeof<'T1> |> Seq.cast<'T1> |> List.ofSeq
        
let GetCaseByName<'T1> name =
    try 
        let allCases = GetAllCases<'T1>
        let case = allCases |> Seq.tryFind (fun x -> x.ToString() = name)
        match case with
        | Some valueCase -> valueCase
        | None -> raise <| Exception $"Error: Case name {name} is not exist in {typeof<'T1>}"
    with ex -> raise <| Exception ex.Message