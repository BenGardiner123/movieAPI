
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
    [ApiController]
    [Route("api/movietheaters")]
    public class MovieTheatersController: ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        
      
        public MovieTheatersController(ApplicationDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<List<MovieTheaterDTO>>> Get() {

            var entites = await _dbContext.MovieTheaters.ToListAsync();
            return _mapper.Map<List<MovieTheaterDTO>>(entites);
            

        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<MovieTheaterDTO>> Get(int id)
        {
            var movieTheater = await _dbContext.MovieTheaters.FirstOrDefaultAsync( x => x.Id == id);

            if(movieTheater == null)
            {
                return NotFound();
            }

            return _mapper.Map<MovieTheaterDTO>(movieTheater);
        }

        [HttpPost]
        public async Task<ActionResult> Post(MovieTheaterCreationDTO movieCreationDTO)
        {
            var movieTheater = _mapper.Map<MovieTheater>(movieCreationDTO);
            _dbContext.Add(movieTheater);
            await _dbContext.SaveChangesAsync();
            return NoContent();

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, MovieTheaterCreationDTO movieCreationDTO)
        {
            //find the movieTheater with the id == the apram id
            var movieTheater = await _dbContext.MovieTheaters.FirstOrDefaultAsync(x => x.Id == id);

            //null check
            if (movieTheater == null)
            {
                return NotFound();
            }


            movieTheater = _mapper.Map(movieCreationDTO, movieTheater);
            await _dbContext.SaveChangesAsync();

            return NoContent();


        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            //samae pattern as in the other controller - find matching record
            //if nothing found return an actionResult
            //then remove the record from the instance of dbContext and then push the changes to the DB using EF
            var movieTheater = await _dbContext.MovieTheaters.FirstOrDefaultAsync(x => x.Id == id);

            if (movieTheater == null)
            {
                return NotFound();
            }

            _dbContext.Remove(movieTheater);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
            

    }
}
