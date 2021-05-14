using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<GenresController> logger;

        public GenresController(IRepository repository, ILogger<GenresController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        [HttpGet] //api/genres/
        [HttpGet("list")] //api/genres/list
        [HttpGet("/allgenres")] //allgenres (the slash drops the route prefix at the top of the controller)
        //this i s awesome - this will set the imter fo r60 secs after the endpoints is hit to return from the
        //cache rather than hitting the endpoint.
        [ResponseCache(Duration = 60)]
        public async Task<ActionResult<List<Genre>>> Get()
        {
            logger.LogInformation("getting all the stuff");
            return await repository.GetGenres();
        }

        [HttpGet("{id:int}")]
        public ActionResult<Genre> Get(int Id)
        {
            logger.LogDebug("get by ID method executng");
            var Genre = repository.GetGenreById(Id);

            if (Genre == null)
            {
                logger.LogWarning($"Genre with the Id {Id} not found");
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
