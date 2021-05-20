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
        }
    }
}
