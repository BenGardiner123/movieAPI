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
        public async Task<ActionResult<List<Genre>>> Get()
        {
            return await repository.GetGenres();
        }

        [HttpGet("{id:int}/{param2= Ben}")]
        public ActionResult<Genre> Getexample(int Id)
        {
           var Genre = repository.GetGenreById(Id);
            if (Genre == null)
            {
                return NotFound();
            }

            return Genre;
        }

        [HttpPut]
        //note i fyou use IActionResults you can return ok(somtghing).. but you cant use thetype casting in that action result gives you
        public ActionResult Put()
        {
            return NoContent();
        }

        [HttpPost]
        public ActionResult Post()
        {
            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete()
        {
            return NoContent();
        }

    }
}
