using CinemaTickets.Models;
using Microsoft.EntityFrameworkCore;


namespace CinemaTickets.Data
{
    public class AppDbContext: Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        //util atunci cand cream autentificarile, creaza identifierii automat, nu mai trebuie definiti manual
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.ActorId,
                am.MovieId
            });

            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.MovieId);
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Actor).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.ActorId);
            modelBuilder.Entity<Movie>()
        .HasOne(m => m.Cinema) // Movie has one Cinema
        .WithMany(c => c.Movies) // Cinema has many Movies
        .HasForeignKey(m => m.CinemaId);

            base.OnModelCreating(modelBuilder);
        }
        //corespondenta model- baza de date
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor_Movie> Actors_Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Producer> Producers { get; set; }

    }
}
