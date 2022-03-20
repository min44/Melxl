module Melxl.Program

open Melxl
open Melxl.Domain
open Provider
open Export
open System.Diagnostics

let personsGreetings =
    Info
    |> Seq.map Person
    |> Seq.map(fun x -> x.GreetingsText)

let file = ExportToExcel personsGreetings
let myProcess = new Process()
myProcess.StartInfo.UseShellExecute <- true
myProcess.StartInfo.FileName <- file
myProcess.StartInfo.WindowStyle <- ProcessWindowStyle.Maximized
myProcess.Start() |> ignore
myProcess.WaitForExit()