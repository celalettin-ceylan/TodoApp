# TODO APP
This app is my first dotnet core 8 mvc project. SQLite database was used for storage in backend. 

## Dotnet CLI Commands

```bash
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

## AppDbContext
I share the my DBcContext class below. Also this show auto incredement and Db configure statements,too.

```C#
public class NetAppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=NetAppDB.sqlite");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoItem>().Property(p => p.Id).ValueGeneratedOnAdd();
    }

    public DbSet<TodoItem> TodoItems {get; set;}
}
```

After creating model, you run the below command in VS Code terminal for creat table(s):

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
``` 