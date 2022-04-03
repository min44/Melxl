module Melxl.Utils.Debugs

open Melxl.Utils

let PrintSeq source = source |> Seq.iteri(fun i x -> Logger.Debug($"{i}: {x}"))