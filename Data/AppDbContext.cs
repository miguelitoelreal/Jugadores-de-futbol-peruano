using Microsoft.EntityFrameworkCore;
using JugadoresFutbolPeruano.Models;

namespace JugadoresFutbolPeruano.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Assignment> Assignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de relaciones
            modelBuilder.Entity<Assignment>()
                .HasOne(a => a.Player)
                .WithMany(p => p.Assignments)
                .HasForeignKey(a => a.PlayerId);

            modelBuilder.Entity<Assignment>()
                .HasOne(a => a.Team)
                .WithMany(t => t.Assignments)
                .HasForeignKey(a => a.TeamId);

            // Restricción de unicidad: un jugador no puede estar dos veces en el mismo equipo
            modelBuilder.Entity<Assignment>()
                .HasIndex(a => new { a.PlayerId, a.TeamId })
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }

        public static void SeedData(AppDbContext context)
        {
            if (!context.Teams.Any())
            {
                context.Teams.AddRange(
                    new Team { Name = "Alianza Lima" },
                    new Team { Name = "Universitario" },
                    new Team { Name = "Sporting Cristal" }
                );
                context.SaveChanges();
            }

            if (!context.Players.Any())
            {
                var firstTeam = context.Teams.OrderBy(t => t.Id).FirstOrDefault();
                if (firstTeam != null)
                {
                    context.Players.AddRange(
                        new Player { Name = "Paolo Guerrero", Age = 39, Position = "Delantero", TeamId = firstTeam.Id },
                        new Player { Name = "Jefferson Farfán", Age = 37, Position = "Delantero", TeamId = firstTeam.Id }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}