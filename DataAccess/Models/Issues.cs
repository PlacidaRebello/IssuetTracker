using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public class Issue
    {
        public int IssueId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string AssignedTo { get; set; }
        public string Tags { get; set; }
        public int IssueStatusId { get; set; }
        [NotMapped]
        public string StatusName { get; set; }
        public IssueStatus IssueStatus { get; set; }
        public virtual Sprint Sprint { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
