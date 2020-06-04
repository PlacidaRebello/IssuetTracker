using System.Collections.Generic;

namespace ServiceModel.Models
{
    public class SprintStatus
    {
        public int SprintStatusId { get; set; }
        public string SprintStatusName { get; set; }
        public ICollection<Sprint> Sprint { get; set; }
        public ICollection<Release> Release { get; set; }
    }
}
