using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movieAPI.DTOs;
using movieAPI.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieAPI.Controllers
{
    [Route("api/ratings")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
    public class RatingsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<IdentityUser> userManager;

        public RatingsController(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Post([FromBody] RatingDTO ratingDTO)
        {
            //by extracting the value from the JWT we cna be sure of the truth of it, 
            //you could for example totry to get the email from the front end , but it would be possible to forge
            //this way we know that JWT was constructed using the secret key and the email can be trusted
            var email = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "email").Value;

            var user = await userManager.FindByEmailAsync(email);

            var userId = user.Id;

            var currentRate = await dbContext.Ratings
                .FirstOrDefaultAsync(x => x.MovieId == ratingDTO.MovieId && x.UserId == userId);
            if(currentRate == null)
            {
                var rating = new Rating();
                rating.MovieId = ratingDTO.MovieId;
                rating.Rate = ratingDTO.Rating;
                rating.UserId = userId;
                dbContext.Add(rating);
            }
            else
            {
                currentRate.Rate = ratingDTO.Rating;
            }

            await dbContext.SaveChangesAsync();
            return NoContent();

        }
    }
}
