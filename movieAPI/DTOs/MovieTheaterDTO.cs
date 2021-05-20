using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;


namespace movieAPI.Controllers
{
    public class MovieTheaterDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }


    }
}