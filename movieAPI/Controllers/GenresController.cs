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
    public class GenresController
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
