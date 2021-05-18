using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace movieAPI.DTOs
{
    public class ActorCreationDTO
    {
        [Required]
        [StringLength(120)]
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Biography { get; set; }

        // the picture is a string because we are going to store a URL here
        public IFormFile Picture { get; set; }
    }
}
