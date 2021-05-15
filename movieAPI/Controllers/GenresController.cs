using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using movieAPI.DTOs;
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
        private readonly IMapper mapper;

        public GenresController( ILogger<GenresController> logger, ApplicationDbContext dbContext, IMapper mapper)
        {
            
            this.logger = logger;
            this._dbContext = dbContext;
            this.mapper = mapper;
        }

        [HttpGet] //api/genres/
       
        public async Task<ActionResult<List<GenreDTO>>> Get()
        {
            logger.LogInformation("getting all the stuff");
            var genres = await _dbContext.Genres.ToListAsync();
            return mapper.Map<List<GenreDTO>>(genres);
        

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
        public async Task<ActionResult> Post([FromBody]GenreCreationDTO genreCreationDTO)
        {
            var genre = mapper.Map<Genre>(genreCreationDTO);
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
