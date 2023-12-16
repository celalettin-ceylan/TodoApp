using Microsoft.EntityFrameworkCore;
using NetApp.Models;

namespace NetApp.Data;


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