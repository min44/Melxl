module Melxl.DataAccess.EntityProvider

open System.ComponentModel.DataAnnotations
open Microsoft.EntityFrameworkCore
open EntityFrameworkCore.FSharp
open Extensions

[<CLIMutable>]
type Blog = {
    [<Key>] Id: int
    Url: string }

[<Keyless>]
type Language =
    | ENU
    | RUS
    | FRA

[<CLIMutable>]
type LocalizedValue =
    { Language: Language
      Value: string }

[<CLIMutable>]
type ComboValue =
    { ListOfValues: obj list
      CurrentValue: obj }

[<Keyless>]
type ValueType =
    | Boolean of bool
    | String of LocalizedValue
    | Float of float
    | Integer of int
    | Combo of ComboValue
    
[<CLIMutable>]
type Property =
    { [<Key>] Id: int
      Name: string
      Value: ValueType }

[<CLIMutable>] 
type Post = {
    [<Key>] Id: int
    Title: string
    BlogId: int
    Blog: Blog
    Properties: Property list
}

type BloggingContext() =
    inherit DbContext()

    [<DefaultValue>] val mutable blogs : DbSet<Blog>
    member this.Blogs with get() = this.blogs and set v = this.blogs <- v

    [<DefaultValue>] val mutable posts : DbSet<Post>
    member this.Posts with get() = this.posts and set v = this.posts <- v

    override _.OnModelCreating builder = builder.RegisterOptionTypes()

    override _.OnConfiguring(options: DbContextOptionsBuilder) : unit =
        options.UseSqlite("Data Source=blogging.db") |> ignore
        

let AddNewBlog() =
    let context = new BloggingContext()
    ()
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    