using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using movieAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieAPI.Controllers
{
    public class MovieController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IFileStorageService storageService;

        public MovieController(ApplicationDbContext dbContext, IMapper mapper, IFileStorageService storageService)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.storageService = storageService;
        }

        [HttpPost]
        private async Task<ActionResult> Post([FromForm])
        {

        }


    }


}
