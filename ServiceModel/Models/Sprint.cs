using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceModel.Models
{
    public class Sprint
    {
        public int SprintId { get; set; }
        public string SprintName { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal SprintPoints { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual ICollection<Issue> Issues { get; set; }
        public int SprintStatusId { get; set; }
        [NotMapped ]
        public string SprintStatusName { get; set; }
        public SprintStatus SprintStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ReleaseId { get; set; }
        public Release Release { get; set; }    
    }
}
