using System;
using Microsoft.EntityFrameworkCore;
using RockPaperScissors.Models;

namespace RockPaperScissors.Contexts
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().ToTable("Game");
            modelBuilder.Entity<Game>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Game>().Property(x => x.Tie).IsRequired().HasColumnType("boolean");
            modelBuilder.Entity<Game>().Property(x => x.Win).HasColumnType("varchar(15)");
        }
    }
}

