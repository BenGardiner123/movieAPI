using Microsoft.AspNetCore.Mvc;
using movieAPI.Entites;
using movieAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieAPI.Controllers
{
    [Route("api/genres")]
    public class GenresController: ControllerBase
    {
        private readonly IRepository repository;

        public GenresController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public List<Genre> Get()
        {
            return repository.GetGenres();
        }

        public Genre Get(int Id)
        {
           var Genre = repository.GetGenreById(Id);
            if (Genre == null)
            {
                //return NotFound();
            }

            return Genre;
        }

        [HttpPost]
        public void Put()
        {

        }

        [HttpPost]
        public void Post()
        {

        }

        [HttpDelete]
        public void Delete()
        {

        }

    }
}
