using BlazorPeliculas.Shared.Entidades;
using Microsoft.EntityFrameworkCore;

namespace BlazorPeliculas.Server.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GeneroPelicula>().HasKey(x => new { x.GeneroId, x.PeliculaId });
        modelBuilder.Entity<PeliculaActor>().HasKey(x => new { x.PeliculaId, x.PersonaId });

        base.OnModelCreating(modelBuilder);
    }

    DbSet<GeneroPelicula> GeneroPeliculas { get; set; }
    DbSet<Pelicula> Peliculas { get; set; }
    DbSet<Genero> Generos { get; set; }
    DbSet<Persona> Personas { get; set; }
    DbSet<PeliculaActor> PeliculaActores { get; set; }
}
