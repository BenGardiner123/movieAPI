using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieAPI.DTOs
{
    public class PaginationDTO
    {
        public int Page { get; set; }
        public int recordsPerPage = 10;
        private readonly int maxAmount = 50;
        public int RecordsPerPage
        {
            get
            {
                return recordsPerPage;
            }
            set
            {
                //this just says if records per page value is greater than maxAmount 
                //make it equal to maxAmount otherwise make it equal to the original value
                recordsPerPage = (value > maxAmount) ? maxAmount : value;
            }
        }
                
    }
}
