using CinemaTickets.Models;
using Microsoft.EntityFrameworkCore;


namespace CinemaTickets.Data
{
    public class AppDbContext: Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
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

            base.OnModelCreating(modelBuilder);

        }
        //corespondenta model- baza de date
        public DbSet<Actor> Actors { get; set; }

        public DbSet<Movie> Movie { get; set; }

        public DbSet<Actor_Movie> Actors_Movies { get; set; }

        public DbSet<Producer> Producers { get; set; }

        public DbSet<Cinema> Cinemas { get; set; }

    }
}
