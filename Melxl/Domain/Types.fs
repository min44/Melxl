namespace Melxl.Domain

type PersonInfo =
    { Name: string
      Age: int
      Gender: Gender }
    
type Person(info: PersonInfo) =
    member x.Info = info
    member x.GreetingsText = $"Hello my name is {x.Info.Name}. I'm {x.Info.Age} years old {x.Info.Gender}"