using System;
using Microsoft.EntityFrameworkCore;

namespace backend.Models;

public class AppDataContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=LucasCunha.db");
    }
}
