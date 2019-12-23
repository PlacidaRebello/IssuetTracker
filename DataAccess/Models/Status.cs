using System;

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
