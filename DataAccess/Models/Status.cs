using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Status
    {
        public int StatusId { get; set; }

        public string StatusName { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
    }   
}
