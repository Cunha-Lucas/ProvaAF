using System;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Models;

public class AppDataContext : DbContext
{
    public DbSet<Aluno> Aluno {get; set;}
    public DbSet<IMC> IMC {get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=LucasCunha.db");
    }
}
