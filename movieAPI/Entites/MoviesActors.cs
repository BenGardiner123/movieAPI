using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieAPI.Entites
{
    public class MoviesActors
    {
        public int ActorId { get; set; }
        public int MovieId { get; set; }
        public string Character { get; set; }
        //this will help order the actors order of appearance in the move detail screen
        public int Order { get; set; }
        public
    }
}
