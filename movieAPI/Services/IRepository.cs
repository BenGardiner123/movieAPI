using movieAPI.Entites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace movieAPI.Services
{
    public interface IRepository
    {
        Genre GetGenreById(int id);
        public Task<List<Genre>> GetGenres();
    }
}