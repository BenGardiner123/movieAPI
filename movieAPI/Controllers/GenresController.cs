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

        [HttpGet] //api/genres/
        [HttpGet("list")] //api/genres/list
        [HttpGet("/allgenres")] //allgenres (the slash drops the route prefix at the top of the controller)
        public List<Genre> Get()
        {
            return repository.GetGenres();
        }

        [HttpGet("{id: int }/{param2= Ben}")]
        public Genre Getexample(int Id)
        {
           var Genre = repository.GetGenreById(Id);
            if (Genre == null)
            {
                //return NotFound();
            }

            return Genre;
        }

        [HttpPut]
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
