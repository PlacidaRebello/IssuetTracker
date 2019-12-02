using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Issue
    {
        public int IssueId { get; set; }        
        public string Subject { get; set; }
        public string Description { get; set; }        
        public string AssignedTo { get; set; }
        public string Tags { get; set; }

        public Status Status{ get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }   
    }
}
