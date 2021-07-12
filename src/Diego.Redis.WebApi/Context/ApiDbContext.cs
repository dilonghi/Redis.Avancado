using Diego.Redis.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace Diego.Redis.WebApi.Context
{
    public class ApiDbContext : DbContext
    {
        public DbSet<TrajetoPrevisto> TrajetoPrevisto { get; set; }
        public DbSet<TrajetoPrevistoParada> TrajetoPrevistoParada { get; set; }
        public DbSet<TrajetoPrevistoTracejado> TrajetoPrevistoTracejado { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string strConnection = "Data Source=DESKTOP-0HU77DE\\SQLEXPRESS; Initial Catalog=RoteirizadorDb; Integrated Security=true; ";

            optionsBuilder
                .UseSqlServer(strConnection)
                .EnableSensitiveDataLogging()
                .LogTo(Console.WriteLine, LogLevel.Information);
        }
    }
}
