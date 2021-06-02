using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using movieAPI.Entites;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace movieAPI
{
    ///adding the identity dbContext - also need to have base.onmodelCreating - thats what identity expects to get cretaed through
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MoviesActors>()
                ///making a composite primary key like this
                .HasKey(x => new { x.ActorId, x.MovieId });
            modelBuilder.Entity<MoviesGenres>()
                ///making a composite primary key like this
                .HasKey(x => new { x.GenreId, x.MovieId });
            modelBuilder.Entity<MovieTheatersMovies>()
                ///making a composite primary key like this
                .HasKey(x => new { x.MovieTheaterId, x.MovieId });
            base.OnModelCreating(modelBuilder);
        }
        //once you add the dbset here you have to go to the nuget console in the tools dropdown and 
        //add-migration .... then
        //update-database
        //to push the changes

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<MovieTheater> MovieTheaters{ get; set; }
        public DbSet<Movie> Movies { get; set; }

        public DbSet<MoviesActors> MoviesActors { get; set; }
        public DbSet<MoviesGenres> MoviesGenres { get; set; }
        public DbSet<MovieTheatersMovies> movieTheatersMovies { get; set; }


    }
}
