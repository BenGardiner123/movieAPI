using Microsoft.EntityFrameworkCore;
using movieAPI.Entites;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace movieAPI
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }
        //once you add the dbset here you have to go to the nuget console in the tools dropdown and 
        //add-migration .... then
        //update-database
        //to push the changes

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<MovieTheater>  MovieTheaters{ get; set; }


    }
}
