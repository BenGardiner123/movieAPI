using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieAPI.Entites
{
    public class MoviesGenres
    {
        public int GenreId { get; set; }
        public int MovieId { get; set; }

        //these are intermiediate classes i think thats like a
        //foreign key back to the original entity
        public Genre Genre { get; set; }
        public Movie Movie { get; set; }
    }
}
