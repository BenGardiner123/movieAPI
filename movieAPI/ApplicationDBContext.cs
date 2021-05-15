using Microsoft.EntityFrameworkCore;
using movieAPI.Entites;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace movieAPI
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext([NotNullAttribute] DbContextOptions options) : base(options)
        {

        }

        public DbSet<Genre> Genres  { get; set; }

    }
}
