using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using movieAPI.Entites;
using movieAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieAPI.Controllers
{
    [Route("api/genres")]
    [ApiController]
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

        [HttpGet("{id:int}")]
        public ActionResult<Genre> Get(int Id, [BindRequired] string param2)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var Genre = repository.GetGenreById(Id);
            if (Genre == null)
            {
                return NotFound();
            }

            return Genre;
        }

        [HttpPut]
        //note i fyou use IActionResults you can return ok(somtghing).. but you cant use thetype casting in that action result gives you
        public ActionResult Put([FromBody]Genre genre)
        {
            return NoContent();
        }

        [HttpPost]
        public ActionResult Post([FromBody]Genre genre)
        {
            repository.AddGenre(genre);
            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete()
        {
            return NoContent();
        }

    }
}
