using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Omine.Domain.Entities;

namespace Omine.Infra
{
    public class OmineContext : DbContext
    {
        public OmineContext(DbContextOptions<OmineContext> contextOptions) : base(contextOptions)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnimeLista>()
                .HasKey(al => new { al.AnimeId, al.ListaId });

            modelBuilder.Entity<AnimeLista>()
                .HasOne(al => al.Anime)
                .WithMany()
                .HasForeignKey(al => al.AnimeId);

            modelBuilder.Entity<AnimeLista>()
                .HasOne(al => al.Lista)
                .WithMany()
                .HasForeignKey(al => al.ListaId);

            modelBuilder.Entity<AnimeGenero>()
                .HasKey(al => new { al.AnimeId, al.GeneroId });

            modelBuilder.Entity<AnimeGenero>()
                .HasOne(al => al.Anime)
                .WithMany()
                .HasForeignKey(al => al.AnimeId);

            modelBuilder.Entity<AnimeGenero>()
                .HasOne(al => al.Genero)
                .WithMany()
                .HasForeignKey(al => al.GeneroId);

            modelBuilder.Entity<Comentario>().ToTable("Comentarios");
            modelBuilder.Entity<Anime>().ToTable("Animes");
            modelBuilder.Entity<Lista>().ToTable("Listas");
            modelBuilder.Entity<Genero>().ToTable("Generos");
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<AnimeLista>().ToTable("AnimesListas");
            modelBuilder.Entity<AnimeGenero>().ToTable("AnimesGeneros");

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Anime> Animes { get; set; }
        public DbSet<Lista> Listas { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<AnimeLista> AnimesListas { get; set; }
        public DbSet<AnimeGenero> AnimesGeneros { get; set; }
    }

}