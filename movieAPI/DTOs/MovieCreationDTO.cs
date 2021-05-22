using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using moviesAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieAPI.DTOs
{
    public class MovieCreationDTO
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Trailer { get; set; }
        public bool InTheaters { get; set; }
        public DateTime ReleaseDate { get; set; }
        //because the front end is sending a file
        public IFormFile Poster { get; set; }
        //----------------------------------------------------------------
        //this is pretty cool, this custom type binder will basically deserialize the type and turn it into GenreIds - because we used generics can apply to any attribute just pass the type into the filter
        [ModelBinder(BinderType = typeof(TypeBinder<List<int>>))]
        public List<int> GenreIds { get; set; }
        //----------------------------------------------------------------
        [ModelBinder(BinderType = typeof(TypeBinder<List<int>>))]
        public List<int> MovieTheaterIds { get; set; }
        //-----------------------------------------------------------------
        [ModelBinder(BinderType = typeof(TypeBinder<List<MoviesActorsCreationDTO>>))]
        public List<MoviesActorsCreationDTO> Actors { get; set; }

    }
}
