using System.Data.Entity;
using AhorcadoMVC.Models;

namespace AhorcadoMVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("DefaultConnection") { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Palabra> Palabras { get; set; }
        public DbSet<Partida> Partidas { get; set; }
    }
}
