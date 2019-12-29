using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    public class SprintStatus
    {
        public int SprintStatusId { get; set; }
        public string SprintStatusName { get; set; }
        public ICollection<Sprint> Sprint { get; set; }
    }
}
