namespace Melxl.Domain

type Parameter =
    { Id: int
      Name: string
      Value: obj }

type PersonAlt =
    { Id: int
      Name: string
      Age: int
      Gender: Gender
      Parameters: Parameter list }
  
type Person =
    { Id: int
      Name: string
      IsSelected: bool
      Age: int }