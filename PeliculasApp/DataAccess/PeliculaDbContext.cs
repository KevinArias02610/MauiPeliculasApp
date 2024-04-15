using Microsoft.EntityFrameworkCore;
using PeliculasApp.Models;
using PeliculasApp.Utilidades;

namespace PeliculasApp.DataAccess
{
    public class PeliculaDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<ValoratedMovie> ValoratedMovies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conexionDB = $"Filename={ConexionDB.DevolverRuta("dbpeliculas.db")}";
            optionsBuilder.UseSqlite(conexionDB);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(col => col.Id);
            });
            modelBuilder.Entity<ValoratedMovie>(entity =>
            {
                entity.HasKey(col => col.Id);
            });
        }
    }
}
