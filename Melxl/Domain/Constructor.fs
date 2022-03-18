namespace Melxl.Domain

module PersonConstructor =
    let Create name age gender =
        { Name = name
          Age = age
          Gender = gender }