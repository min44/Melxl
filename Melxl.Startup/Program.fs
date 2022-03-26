module Melxl.Startup.Program

open Elmish
open Elmish.WPF
open Melxl.Domain
open Melxl.DataAccess
open SqlProvider

type Model =
    { Persons: Person list
      State: string }

let init () =
    { Persons = []
      State = "Hello!" }, []

let PersonProperties:unit -> Binding<'a * Person,'b> list =
    fun () ->
      [ "Id"         |> Binding.oneWay (fun (_, e) -> e.Id)
        "Name"       |> Binding.oneWay (fun (_, e) -> e.Name)
        "Age"        |> Binding.oneWay (fun (_, e) -> e.Age) ]
     
type Msg =
    | Rendered
    | SetPersons of Person list
    | SetState of string
    | EscPress

let FetchDataCmd: Sub<Msg>  =
    fun dispatch ->
        async {
            dispatch <| SetState "Rendered Fetch Data"
        } |> Async.StartImmediate

let update msg m =
    match msg with
    | Rendered -> { m with State = "___" }, [ FetchDataCmd ]
    | SetPersons b -> { m with Persons = b }, Cmd.none
    | SetState s -> { m with State = s }, Cmd.none
    | EscPress -> { m with State = "ESC!" }, Cmd.none

let bindings () =
    [ "Rendered" |> Binding.cmd Rendered
      "EscPress" |> Binding.cmd EscPress
      "Persons"  |> Binding.subModelSeq((fun m -> m.Persons), (fun s -> s.Id), PersonProperties)
      "State"    |> Binding.oneWay(fun m -> m.State) ]

let main window =
    Program.mkProgramWpf
        init
        update
        bindings
    |> Program.startElmishLoop ElmConfig.Default window