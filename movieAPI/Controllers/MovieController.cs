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
    [Route("api/movies")]
    [ApiController]
    public class MovieController: ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IFileStorageService storageService;
        private string container = "movies";

        public MovieController(ApplicationDbContext dbContext, IMapper mapper, IFileStorageService storageService)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.storageService = storageService;
        }

        [HttpGet("PostGet")]
        public async Task<ActionResult<MoviePostGetDTO>> PostGet()
        {
            var movieTheaters = await dbContext.MovieTheaters.OrderBy(x => x.Name).ToListAsync();
            var genres = await dbContext.Genres.OrderBy(x => x.Name).ToListAsync();

            var movieTheatersDTO = mapper.Map<List<MovieTheaterDTO>>(movieTheaters);
            var genresDTO = mapper.Map<List<GenreDTO>>(genres);

            return new MoviePostGetDTO() { Genres = genresDTO, MovieTheaters = movieTheatersDTO };
        }


        [HttpPost]
        private async Task<ActionResult> Post([FromForm] MovieCreationDTO movieCreationDTO) 
        {
            var movie = mapper.Map<Movie>(movieCreationDTO);

            if (movieCreationDTO.Poster != null)
            {
                movie.Poster = await storageService.SaveFile(container, movieCreationDTO.Poster);

            }

            AnnotateActorsOrder(movie);
            dbContext.Add(movie);
            await dbContext.SaveChangesAsync(); 
            return NoContent(); 
        }

        //this changes the order they are stored in the db
        private void AnnotateActorsOrder(Movie movie)
        {
            if (movie.MoviesActors != null)
            {
                for (int i = 0; i < movie.MoviesActors.Count; i++)
                {
                    //this appraently orders the actors in the cast list in the orer they come in from the front end
                    movie.MoviesActors[i].Order = i;
                }
            }
        }


    }
}



