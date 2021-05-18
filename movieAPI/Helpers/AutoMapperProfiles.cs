using AutoMapper;
using movieAPI.DTOs;
using movieAPI.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieAPI.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<GenreDTO, Genre>().ReverseMap();
            CreateMap<GenreCreationDTO, Genre>();

            CreateMap<ActorDTO, Actor>().ReverseMap();
            CreateMap<ActorCreationDTO, Actor>()
                //adding this because the fron end is going to send a file not a string
                //so ignoring for now using this
                .ForMember(x => x.Picture, options => options.Ignore());
        }
    }
}
