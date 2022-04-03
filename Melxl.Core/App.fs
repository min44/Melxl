module Melxl.Startup.App

open Elmish
open Elmish.WPF
open Melxl.Domain
open Melxl.DataAccess
open Melxl.Utils
open SqlProvider
open Debugs

type Model =
    { Persons: Person list
      State: string }

let init () =
    { Persons = []
      State = "Hello!" }, []

type Msg =
    | Rendered
    | Remove
    | SetPersons of Person list
    | SetState of string
    | EscPress
    | SetIsSelected of int * bool

let FetchDataCmd =
    fun dispatch ->
        async {
            dispatch <| SetState "Rendered Fetch Data"
            do! Async.Sleep(1000)
            GetPersons() |> SetPersons |> dispatch
        } |> Async.StartImmediate

let AddPersonsCmd =
    fun dispatch ->
        async {
            dispatch <| SetState "Try to add new persons"
            do! Async.Sleep(1000)
            do! AddNewPersonsAsync()
            GetPersons() |> SetPersons |> dispatch 
        } |> Async.StartImmediate

let RemoveCmd m =
    fun dispatch ->
        async {
            dispatch <| SetState "Try to add remove persons"
            do! Async.Sleep(1000)
            let ids = m.Persons |> Seq.filter(fun x -> x.IsSelected) |> Seq.map(fun x -> x.Id)
            PrintSeq ids
            let result =
                try RemovePersons ids
                with ex ->
                    Logger.Debug($"ex: {ex}")
                    failwith ex.Message
            Logger.Debug($"result: {result}")
            GetPersons() |> SetPersons |> dispatch
        } |> Async.StartImmediate

module UpdateUtils =
    let Select m id isSelected =
        let func e = if e.Id = id then { e with IsSelected = isSelected } else e
        { m with Persons = m.Persons |> List.map func }

open UpdateUtils

      
let update msg m =
    match msg with
    | Rendered        -> { m with State = "___" }, [ FetchDataCmd ]
    | Remove          -> m, [ RemoveCmd m]
    | SetPersons b    -> { m with Persons = b }, Cmd.none
    | SetState s      -> { m with State = s }, Cmd.none
    | EscPress        -> { m with State = "ESC!" }, [ AddPersonsCmd ]
    | SetIsSelected (id, isSelected) -> Select m id isSelected, Cmd.none

let PersonProperties =
    fun () ->
      [ "Id"         |> Binding.oneWay (fun (_, e) -> e.Id)
        "Name"       |> Binding.oneWay (fun (_, e) -> e.Name)
        "IsSelected" |> Binding.twoWay ((fun (_, e) -> e.IsSelected), (fun isSelected (_, e) -> SetIsSelected (e.Id, isSelected)))
        "Age"        |> Binding.oneWay (fun (_, e) -> e.Age) ]
      
let bindings() =
    [ "Rendered"            |> Binding.cmd Rendered
      "EscPress"            |> Binding.cmd EscPress
      "Remove"              |> Binding.cmd Remove
      "Persons"             |> Binding.subModelSeq((fun m -> m.Persons), (fun s -> s.Id), PersonProperties)
      "Selected"            |> Binding.oneWay(fun m ->
          m.Persons
          |> Seq.filter(fun x -> x.IsSelected)
          |> Seq.map(fun x -> x.Name))
      "State"               |> Binding.oneWay(fun m -> m.State) ]

let Run window =
    Program.mkProgramWpf
        init
        update
        bindings
    |> Program.startElmishLoop ElmConfig.Default window 