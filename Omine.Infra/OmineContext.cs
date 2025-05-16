using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Omine.Domain.Entities;

namespace Omine.Infra
{
    public class OmineContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public OmineContext(DbContextOptions<OmineContext> contextOptions, IConfiguration configuration) : base(contextOptions)
        {
            _configuration = configuration;
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comentario>().ToTable("Comentarios");
            modelBuilder.Entity<Anime>().ToTable("Animes");
            modelBuilder.Entity<Lista>().ToTable("Listas");
            modelBuilder.Entity<Genero>().ToTable("Generos");
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Anime> Animes { get; set; }
        public DbSet<Lista> Listas { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}