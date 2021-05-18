using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movieAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieAPI.Controllers
{
    [Route("api/actors")]
    [ApiController]
    public class ActorsController: ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ActorsController(ApplicationDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ActorDTO>>> Get()
        {
            var actors = await _dbContext.Actors.ToListAsync();
            return _mapper.Map<List<ActorDTO>>(actors);


        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ActorDTO>> Get(int id)
        {
            var actor = await _dbContext.Actors.FirstOrDefaultAsync( x => x.Id == id);

            if(actor == null)
            {
                return NotFound();
            }

            return _mapper.Map<ActorDTO>(actor);


        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] ActorCreationDTO actorCreationDTO)
        {
            return NoContent();
            throw new NotImplementedException();
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ActorCreationDTO actorCreationDTO)
        {
           
            throw new NotImplementedException();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            //check if there is an actor with this id in the db
            var actor = await _dbContext.Actors.FirstOrDefaultAsync(x => x.Id == id);
            //if the actor doesnt exist we return couldnt find anything
            if(actor == null)
            {
                return NotFound();
            }
            //otherwise we remove the actor with the coresponding id and thensave the changes
            _dbContext.Remove(actor);
            await _dbContext.SaveChangesAsync();
            return NoContent();

        }

    }
}
