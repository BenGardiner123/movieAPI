using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using movieAPI.DTOs;
using movieAPI.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var genres = await _dbContext.Genres.OrderBy(x => x.Name).ToListAsync();
            return mapper.Map<List<GenreDTO>>(genres);
        

        }

        [HttpGet("{id:int}", Name="getGenre")]
        public async Task<ActionResult<GenreDTO>> Get(int Id)
        {
            var genre = await _dbContext.Genres.FirstOrDefaultAsync(x => x.Id == Id);

            if(genre == null)
            {
                return NotFound();
            }
            return mapper.Map<GenreDTO>(genre);

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] GenreCreationDTO genreCreationDTO)
        {
            var genre = mapper.Map<Genre>(genreCreationDTO);
            genre.Id = id;
            _dbContext.Entry(genre).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]GenreCreationDTO genreCreationDTO)
        {
            var genre = mapper.Map<Genre>(genreCreationDTO);
            _dbContext.Add(genre);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete()
        {
            throw new NotImplementedException();
        }

    }
}
