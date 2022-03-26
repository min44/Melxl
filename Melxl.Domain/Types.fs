namespace Melxl.Domain

open System

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
    { Id: int64
      Name: string
      Age: int64 }
    
//type Company = { Id: int; Name: string }