using movieAPI.Entites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace movieAPI.Services
{
    public interface IRepository
    {
        void AddGenre(Genre genre);
        Genre GetGenreById(int id);
        public Task<List<Genre>> GetGenres();
    }
}