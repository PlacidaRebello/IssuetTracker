using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public class Release
    {
        public int ReleaseId { get; set; }
        public string ReleaseName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual ICollection<Sprint> Sprints { get; set; }
        public int SprintStatusId { get; set; }
        [NotMapped]
        public string SprintStatusName { get; set; }
        public SprintStatus SprintStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
