using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movieAPI.DTOs;
using movieAPI.Entites;
using movieAPI.Helpers;
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
        private readonly IFileStorageService _fileStorageService;
        private readonly string containerName = "actors";

        public ActorsController(ApplicationDbContext dbContext,
                                IMapper mapper,
                                IFileStorageService fileStorageService)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
            this._fileStorageService = fileStorageService;
        }
        [HttpGet]
        public async Task<ActionResult<List<ActorDTO>>> Get([FromQuery] PaginationDTO paginationDTO)
        {
            var queryable = _dbContext.Actors.AsQueryable();
            await HttpContext.InsertParametersPaginationInHeader(queryable);
            var actors = await queryable.OrderBy(x => x.Name).Paginate(paginationDTO).ToListAsync();
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
            var actor = _mapper.Map<Actor>(actorCreationDTO);

            if(actorCreationDTO.Picture != null)
            {
                actor.Picture = await _fileStorageService.SaveFile(containerName, actorCreationDTO.Picture);

            }

            _dbContext.Add(actor);
            await _dbContext.SaveChangesAsync();
            return NoContent();

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromForm] ActorCreationDTO actorCreationDTO)
        {
            var actor = await _dbContext.Actors.FirstOrDefaultAsync(x => x.Id == id);

            if (actor == null)
            {
                return NotFound();
            }

            actor = _mapper.Map(actorCreationDTO, actor);

            if (actorCreationDTO.Picture != null)
            {
                actor.Picture = await _fileStorageService.EditFile(containerName,
                    actorCreationDTO.Picture, actor.Picture);
            }

            await _dbContext.SaveChangesAsync();
            return NoContent();
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

            await _fileStorageService.DeleteFile(actor.Picture, containerName);

            return NoContent();

        }

    }
}
