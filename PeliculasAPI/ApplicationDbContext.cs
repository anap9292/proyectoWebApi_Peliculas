using Microsoft.EntityFrameworkCore;
using PeliculasAPI.Entidades;

namespace PeliculasAPI
{
    public class ApplicationDbContext : DbContext

    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        //ApiFluente
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //PeliculasActores
            modelBuilder.Entity<PeliculasActores>()
                 .HasKey(x => new { x.ActorId, x.PeliculaId });

            //PeliculasGeneros
            modelBuilder.Entity<PeliculasGeneros>()
               .HasKey(x => new { x.GeneroId, x.PeliculaId });


            //Peliculas Salas de Cine
            modelBuilder.Entity<PeliculasSalasDeCine>()
                .HasKey(x => new { x.PeliculaId , x.SalaDeCineId});

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Actor> Actores { get; set; }
        public DbSet<Pelicula> Peliculas { get; set;}
        public DbSet<PeliculasActores> PeliculasActores { get; set;}
        public DbSet<PeliculasGeneros> PeliculasGeneros { get;}

        public DbSet<SalaDeCine> SalasDeCines { get; set; }
        public DbSet<PeliculasSalasDeCine> PeliculasSalasDeCines { get; set; }  



    }
}
