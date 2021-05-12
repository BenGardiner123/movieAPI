using movieAPI.Entites;
using System.Collections.Generic;

namespace movieAPI.Services
{
    public interface IRepository
    {
        Genre GetGenreById(int id);
        public List<Genre> GetGenres();
    }
}