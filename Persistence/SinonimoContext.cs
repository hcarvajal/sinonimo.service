using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Persistence
{
    public sealed class SinonimoContext : DbContext
    {
       // private readonly IConfiguration _configuration;
        public SinonimoContext(DbContextOptions<SinonimoContext> options)
            : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Juegos> Juegos { get; set; }
        public DbSet<SubJuego> SubJuegos { get; set; }
        public DbSet<Boletos> Boletos { get; set; }
        public DbSet<ResultadoGanador> resultadoGanadors { get; set; }
        public DbSet<Resultados> resultados { get; set; }
        public DbSet<Transactions> transactions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SinonimoContext).Assembly);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        //}


    }
}
