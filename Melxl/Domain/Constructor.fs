namespace Melxl.Domain

module PersonConstructor =
    let CreatePerson name y z =
        { Name = name
          Age = y
          Gender = z }