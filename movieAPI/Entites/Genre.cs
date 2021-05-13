using movieAPI.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace movieAPI.Entites
{
    public class Genre
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The field with the name {0} is required mate")]
        [StringLength(10)]
        [FirstLetterUppercaseAttribute]
        public string Name { get; set; }

        //these are some of the cool built in validators you can use on your attributes
        //pretty obvious but these only target single properties not entire models
        [Range(18, 120)]
        public int Age { get; set; }
        [CreditCard]
        public string CreditCard { get; set; }
        [Url]
        public string Url { get; set; }
    }

}

