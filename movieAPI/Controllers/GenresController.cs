using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using movieAPI.Entites;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace movieAPI.Controllers
{
    [Route("api/genres")]
    [ApiController]
    //putting this here covers every endpoint in the controller with auth 
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GenresController: ControllerBase
    {
       
        private readonly ILogger<GenresController> logger;
        private readonly ApplicationDbContext _dbContext;

        public GenresController( ILogger<GenresController> logger, ApplicationDbContext dbContext)
        {
            
            this.logger = logger;
            this._dbContext = dbContext;
        }

        [HttpGet] //api/genres/
       
        public async Task<ActionResult<List<Genre>>> Get()
        {
            logger.LogInformation("getting all the stuff");
            return await _dbContext.Genres.ToListAsync();

        }

        [HttpGet("{id:int}")]
        public ActionResult<Genre> Get(int Id)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        //note i fyou use IActionResults you can return ok(somtghing).. but you cant use thetype casting in that action result gives you
        public ActionResult Put([FromBody]Genre genre)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]Genre genre)
        {
            _dbContext.Add(genre);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete()
        {
            throw new NotImplementedException();
        }

    }
}
