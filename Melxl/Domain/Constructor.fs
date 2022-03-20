namespace Melxl.Domain

module PersonInfoConstructor =
    let Create name age gender =
        { Name = name
          Age = age
          Gender = gender }