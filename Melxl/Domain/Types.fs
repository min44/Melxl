namespace Melxl.Domain

open System
open Melxl.Domain

type PersonInfo =
    { Name: string
      Age: int
      Gender: Gender }


type Person(info: PersonInfo) =
    member x.Info = info
    member x.GreetingsText = $"Hello my name is {x.Info.Name}. I'm {x.Info.Age} years old {x.Info.Gender}"

type Treasure = Treasure

type Finder(person: Person) =
    inherit Person(person.Info)
    let SuccessfulFindingProbability = 5
    member x.FindTreasure() =
        if Random().Next(0, 100) < SuccessfulFindingProbability
        then Ok Treasure
        else Error "Unable to find treasure. Try go to disputing"