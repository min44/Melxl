﻿module Melxl.Export

open System
open System.IO
open SwiftExcel

let ExportToExcel data =
    let id = Random().Next(0, 9999)
    let desktop = Environment.GetFolderPath Environment.SpecialFolder.Desktop
    let fileName = Path.ChangeExtension($"melxl_export_{id}", ".xlsx")
    let dstPath = Path.Combine(desktop, fileName)
    let sheet = Sheet()
    sheet.ColumnsWidth <- [| 60.0 |]
    use ev = new ExcelWriter(dstPath, sheet)
    data |> Seq.iteri(fun i x -> ev.Write(x, 1, i + 1))
    dstPath