using CinemaTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaTickets.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Actor-Movie relationship
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new { am.ActorId, am.MovieId });
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.MovieId);
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Actor).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.ActorId);

            // Cinema-Movie relationship
            modelBuilder.Entity<Movie>()
                .HasOne<Cinema>(m => m.Cinema)
                .WithMany(c => c.Movies)
                .HasForeignKey(m => m.CinemaId);

            // Producer-Movie relationship
            modelBuilder.Entity<Movie>()
                .HasOne<Producer>(m => m.Producer)
                .WithMany(p => p.Movies)
                .HasForeignKey(m => m.ProducerId);

            base.OnModelCreating(modelBuilder);
        }




        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor_Movie> Actors_Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Producer> Producers { get; set; }

        //orders related tables
        public DbSet<Order> Orders { get; set; }
        public DbSet<Order> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

    }
}