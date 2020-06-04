using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceModel.Models
{
    public class Issue
    {
        public int IssueId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        [Column("AssignedTo")]
        public string UserId { get; set; }
        public string User { get; set; }
        public string Tags { get; set; }
        public int IssueStatusId { get; set; }
        [NotMapped]
        public string StatusName { get; set; }
        public IssueStatus IssueStatus { get; set; }
        public int SprintId { get; set; }
        public Sprint Sprint { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Order { get; set; }
        public int IssueTypeId { get; set; }
        [NotMapped]
        public string IssueTypeName { get; set; }
        public IssueDetails IssueDetails { get; set; }
    }
}
