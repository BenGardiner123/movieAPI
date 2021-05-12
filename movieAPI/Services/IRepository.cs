using movieAPI.Entites;
using System.Collections.Generic;

namespace movieAPI.Services
{
    public interface IRepository
    {
        public List<Genre> GetGenres();
    }
}