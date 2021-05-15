using movieAPI.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace movieAPI.DTOs
{
    public class GenreCreationDTO
    {
       
        [Required(ErrorMessage = "The field with the name {0} is required mate")]
        [StringLength(50)]
        [FirstLetterUppercaseAttribute]
        public string Name { get; set; }

    }
}
