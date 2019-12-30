using System.Collections.Generic;

namespace DataAccess.Models
{
    public class SprintStatus
    {
        public int SprintStatusId { get; set; }
        public string SprintStatusName { get; set; }
        public ICollection<Sprint> Sprint { get; set; }
    }
}
