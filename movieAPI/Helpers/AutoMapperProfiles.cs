using AutoMapper;
using movieAPI.Controllers;
using movieAPI.DTOs;
using movieAPI.Entites;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieAPI.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles(GeometryFactory geometryFactory)
        {
            CreateMap<GenreDTO, Genre>().ReverseMap();
            CreateMap<GenreCreationDTO, Genre>();

            CreateMap<ActorDTO, Actor>().ReverseMap();
            CreateMap<ActorCreationDTO, Actor>()
                //adding this because the front end is going to send a file not a string
                //so ignoring for now using this
                .ForMember(x => x.Picture, options => options.Ignore());
            CreateMap<MovieTheater, MovieTheaterDTO>()
                //expanding out the built in Point attribute because we are not exposing the Point attribute itself
                .ForMember(x => x.Latitude, dto => dto.MapFrom(prop => prop.Location.Y))
                .ForMember(x => x.Longitude, dto => dto.MapFrom(prop => prop.Location.X));

            CreateMap<MovieTheaterCreationDTO, MovieTheater>()
            .ForMember(x => x.Location, x => x.MapFrom(dto =>
            geometryFactory.CreatePoint(new Coordinate(dto.Longitude, dto.Latitude))));

            CreateMap<MovieCreationDTO, Movie>()
                .ForMember(x => x.Poster, options => options.Ignore())
                .ForMember(x => x.MoviesGenres, options => options.MapFrom(MapMoviesGenres))
                .ForMember(x => x.MoviesTheatersMovies, options => options.MapFrom(MapMovieTheatersMovies))
                .ForMember(x => x.MoviesActors, options => options.MapFrom(MapMoviesActors));
        }


        //these are custom mapping funtions becuase im assuming that the automapper wont work with the generic lists inside the Movie.cs file.
        //we pass in the two objects the target and the base
        private List<MoviesGenres> MapMoviesGenres(MovieCreationDTO movieCreationDTO, Movie movie)
        {
            var result = new List<MoviesGenres>();
            //if the list is empty then there is nothing to map so exit
            if (movieCreationDTO.GenreIds == null) { return result; }
            //otherwise creata a new list then push all the id's into it.
            foreach (var id in movieCreationDTO.GenreIds)
            {
                result.Add(new MoviesGenres() { GenreId = id });
            }

            return result; 
        }
        private List<MovieTheatersMovies> MapMovieTheatersMovies(MovieCreationDTO movieCreationDTO, Movie movie)
        {
            var result = new List<MovieTheatersMovies>();

            if (movieCreationDTO.MovieTheaterIds == null) { return result; }

            foreach (var id in movieCreationDTO.MovieTheaterIds)
            {
                result.Add(new MovieTheatersMovies() { MovieTheaterId = id });
            }

            return result;
        }
        private List<MoviesActors> MapMoviesActors(MovieCreationDTO movieCreationDTO, Movie movie)
        {
            var result = new List<MoviesActors>();

            if (movieCreationDTO.Actors == null) { return result; }

            foreach (var actors in movieCreationDTO.Actors)
            {
                result.Add(new MoviesActors() { ActorId = actors.Id , Character = actors.Character });
            }

            return result;
        }
    }
}
