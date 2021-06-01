using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieAPI.DTOs
{
    public class HomeDTO
    {
        public List<MovieDTO> InTheaters { get; set; }
        public List<MovieDTO> UpcomingReleases { get; set; }
    }
}
